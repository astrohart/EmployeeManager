using System;
using System.Threading;
using System.Windows.Forms;
using EmployeeManager.BusinessLayer;
using EmployeeManager.Data;
using EmployeeManager.Properties;

namespace EmployeeManager
{
    /// <summary>
    ///     Main window of the application.
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        ///     Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static MainWindow() { }

        /// <summary>
        ///     Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected MainWindow() => InitializeComponent();

        /// <summary>
        ///     Gets a reference to the one and only instance of
        ///     <see cref="T:EmployeeManager.MainWindow" />.
        /// </summary>
        public static MainWindow Instance { get; } = new MainWindow();

        public string RowsAffectedReport
        {
            get => rowsAffectedLabel.Text;
            set => rowsAffectedLabel.Text = value;
        }

        /// <summary>
        ///     Gets or sets the message to be displayed on the Status Bar.
        /// </summary>
        public string StatusBarMessage
        {
            get => messageLabel.Text;
            set => messageLabel.Text = value;
        }

        /// <summary>
        ///     Gets a value indicating whether this form's data needs to be saved.
        /// </summary>
        private static bool IsDirty =>
            EmployeesServiceManager.Instance.HasChanges;

        /// <summary>
        ///     Gets a reference to the instance of
        ///     <see cref="T:EmployeeManager.Data.Employee" /> that corresponds to the
        ///     currently-selected row.
        /// </summary>
        private Employee CurrentEmployee =>
            (Employee)employeeBindingSource.Current;

        /// <summary>
        ///     Gets a string containing the full name of the currently-selected employee.
        /// </summary>
        private string CurrentEmployeeFullName =>
            $"{CurrentEmployee.FirstName} {CurrentEmployee.LastName}";

        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.Form.FormClosing" />
        ///     event.
        /// </summary>
        /// <param name="e">
        ///     A <see cref="T:System.Windows.Forms.FormClosingEventArgs" />
        ///     that contains the event data.
        /// </param>
        protected override void OnFormClosing(FormClosingEventArgs e) =>
            e.Cancel = !CanClose(e.CloseReason);

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.</summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> that contains the event
        ///     data.
        /// </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadData();

            Application.Idle += OnApplicationIdle;
        }

        /// <summary>
        ///     Prompts the user to save any unsaved changes before the application exits.
        /// </summary>
        /// <returns>
        ///     True if the application can exit; false if the user decided to cancel
        ///     the Exit operation.
        /// </returns>
        private bool CanClose(CloseReason reason)
        {
            // If the Windows Operating System is currently going through a Shut Down
            // phase, or if the Task Manager is trying to kill us, cancel the edit
            // operation (if any) currently in progress and then allow an immediate exit.
            // The user will lose any pending changes, but we have little choice here.
            if (reason == CloseReason.WindowsShutDown ||
                reason == CloseReason.TaskManagerClosing)
            {
                employeeDataGridView.CancelEdit();
                return true;
            }

            if (!Validate())
                return false; // do not allow Exit if the data is not valid

            // If either no rows are currently selected or there are zero pending
            // changes, then allow the exit.
            if (CurrentEmployee == null) return true;
            if (!IsDirty) return true;

            // Otherwise, prompt the user whether they want to save changes before
            // exiting or not, or cancel the process.
            switch (MessageBox.Show(
                this, Resources.Confirm_SaveChangesOnExit,
                Application.ProductName, MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2
            ))
            {
                case DialogResult.Yes:
                    fileSave.PerformClick();
                    return true;

                case DialogResult.No:
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        ///     Gets a value that indicates whether the user has confirmed that the user
        ///     wants to delete the currently-selected employee.
        /// </summary>
        /// <returns>
        ///     Either <c>true</c> to indicate that the user has confirmed they want
        ///     to delete the current employee, or <c>false</c> to indicate the user has
        ///     changed their mind.
        /// </returns>
        private bool CanDeleteEmployee() =>
            MessageBox.Show(
                this,
                string.Format(
                    Resources.Confirm_DeleteEmployee, CurrentEmployeeFullName
                ), Application.ProductName, MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2
            ) == DialogResult.Yes;

        /// <summary>
        ///     Loads data from the data source and populates the grid view and combo boxes
        ///     with it.
        /// </summary>
        private void LoadData()
        {
            // Filling the binding sources is super breezy -
            // just call GetAll()!
            employeeTypeBindingSource.DataSource =
                EmployeeTypeService.Instance.GetAll();
            employeeBindingSource.DataSource =
                EmployeeService.Instance.GetAll();
        }

        /// <summary>
        ///     Handles the <see cref="E:System.Windows.Forms.Application.Idle" /> event.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised the
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A <see cref="T:System.EventArgs" /> that contains the event
        ///     data.
        /// </param>
        /// <remarks>
        ///     This event is raised continually during the run of our application,
        ///     several thousand times per second.  We check the states of various program
        ///     elements and data values, and grey and ungrey menu items and toolbar
        ///     buttons accordingly.
        /// </remarks>
        private void OnApplicationIdle(object sender, EventArgs e)
        {
            // If the data is dirty, then enable the Save button and menu item.
            // Otherwise, grey them out to show the user there are no pending
            // changes to be saved.
            employeeBindingNavigatorSaveItem.Enabled = IsDirty;
        }

        /// <summary>
        ///     Handles the <see cref="E:System.Windows.Forms.DataGridView.DataError" />
        ///     event.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised the
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A
        ///     <see cref="T:System.Windows.Forms.DataGridViewDataErrorEventArgs" /> that
        ///     contains the event data.
        /// </param>
        /// <remarks>
        ///     This event is raised needlessly more than the authors of the
        ///     DataGridView control would like to admit, and on an entirely superfluous
        ///     basis.  Therefore, we handle it here just to set the
        ///     <see cref="P:System.ComponentModel.CancelEventArgs.Cancel" /> property to
        ///     <c>true</c> in order to suppress the annoying message boxes that otherwise
        ///     would constantly be appearing on screen.
        /// </remarks>
        private void OnDataError(object sender,
            DataGridViewDataErrorEventArgs e)
        {
            // We do this in order to suppress these stupid
            // errors that result merely because one of our
            // columns is a ComboBox!
            e.Cancel = true;
        }

        /// <summary>
        ///     Called when the user selects the Delete command on the Employee menu.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised the
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A <see cref="T:System.EventArgs" /> that contains the event
        ///     data.
        /// </param>
        private void OnEmployeeDelete(object sender, EventArgs e) =>
            bindingNavigatorDeleteItem.PerformClick();

        /// <summary>
        ///     Called when the user chooses the Exit command on the File menu.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised the
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A <see cref="T:System.EventArgs" /> that contains the event
        ///     data.
        /// </param>
        private void OnFileExit(object sender, EventArgs e) => Close();

        /// <summary>
        ///     Called when the user clicks the File menu and it's just about to drop down.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised the
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A <see cref="T:System.EventArgs" /> that contains the event
        ///     data.
        /// </param>
        /// <remarks>
        ///     We take a moment here to check if menu items need to be greyed out or
        ///     ungreyed.
        /// </remarks>
        private void OnFileMenuDropDownOpening(object sender, EventArgs e)
        {
            // Enable the File -> Save menu item if there are pending changes to be saved;
            // otherwise, grey it out, since then it does not make sense.
            fileSave.Enabled = IsDirty;
        }

        /// <summary>
        ///     Called when the user chooses the Add New Employee command on the File menu.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised the
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A <see cref="T:System.EventArgs" /> that contains the event
        ///     data.
        /// </param>
        private void OnFileNew(object sender, EventArgs e) =>
            bindingNavigatorAddNewItem.PerformClick();

        /// <summary>
        ///     Called when the user chooses the Save command on the File menu.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised the
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A <see cref="T:System.EventArgs" /> that contains the event
        ///     data.
        /// </param>
        private void OnFileSave(object sender, EventArgs e)
        {
            // Check that all data entered on the form is valid.
            // If not, then stop.
            if (!Validate()) return;

            // Tell the user we are saving changes
            StatusBarMessage = Resources.App_SavingChangesMessage;
            Application.DoEvents();
            Thread.Sleep(50);

            employeeDataGridView.EndEdit();

            var totalRowsAffected = 0;

            // Save the changes to the database.
            ProgressWindow.Instance.Status =
                Resources.App_SavingChangesProgressWindowMessage;
            ProgressWindow.Instance.ShowAndRunTask(
                () => totalRowsAffected =
                    // Be careful -- calling SaveAll saves ALL changes
                    // to the WHOLE database, from wherever in your
                    // app they were made from.  If that is not what you
                    // want, then call Save on the <table-name>Service class
                    // who corresponds to the table that the view is displaying
                    // currently.
                    EmployeesServiceManager.Instance.SaveAll()
            );

            // Refresh the Grid View control to show the values
            // that were generated by the database.
            RefreshAll();

            ReportSaveResults(totalRowsAffected);
        }

        /// <summary>
        ///     Handles the
        ///     <see cref="E:System.Windows.Forms.DataGridView.UserDeletingRow" /> event.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised the
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A
        ///     <see cref="T:System.Windows.Forms.DataGridViewRowCancelEventArgs" /> that
        ///     contains the event data.
        /// </param>
        /// <remarks>
        ///     We handle this event in the case that the user selects to delete an
        ///     employee.  Here, we show the user a confirmation request, making sure the
        ///     user is confident they are deleting the correct record.  In the message,
        ///     the user is shown the name of the employee they are about to delete.
        /// </remarks>
        private void OnUserDeletingRow(object sender,
            DataGridViewRowCancelEventArgs e) =>
            e.Cancel = !CanDeleteEmployee();

        /// <summary>
        ///     Handles the
        ///     <see cref="E:System.Windows.Forms.DataGridView.CellValidating" /> event.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised the
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A
        ///     <see cref="T:System.Windows.Forms.DataGridViewCellValidatingEventArgs" />
        ///     that contains the event data.
        /// </param>
        /// <remarks>
        ///     This method's only task in life is to ensure that, if the employee
        ///     first and/or last name are filled in, then an Employee Type value is also
        ///     filled out.  This must be so; otherwise, the Save operation on the database
        ///     will fail.  If we fail validation, then we display a suitable error message
        ///     to the user.
        /// </remarks>
        private void OnValidatingEmployeeType(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            // do nothing if an employee name has not been typed in yet
            if (CurrentEmployee == null ||
                string.IsNullOrWhiteSpace(CurrentEmployee.FirstName) ||
                string.IsNullOrWhiteSpace(CurrentEmployee.LastName))
                return;

            var headerText = employeeDataGridView.Columns[e.ColumnIndex]
                .HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals(Resources.ColumnHeader_EmployeeType)) return;

            // If a cell has a combo box and the user does not select
            // any of that combo box's entries, the e.FormattedValue is
            // the empty string in the case that the DisplayMember is a
            // string property that corresponds to a textual database field.
            if (!string.IsNullOrWhiteSpace(e.FormattedValue.ToString().Trim()))
                return;

            MessageBox.Show(
                this,
                string.Format(
                    Resources.Error_SelectionOfEmployeeTypeRequired,
                    CurrentEmployeeFullName
                ), Application.ProductName, MessageBoxButtons.OK,
                MessageBoxIcon.Stop
            );

            e.Cancel = true; // cancel the current row edit operation.
        }

        /// <summary>
        ///     Refreshes the data in the GridView by fetching all rows from the data
        ///     source.
        /// </summary>
        private void RefreshAll()
        {
            employeeDataGridView.Refresh();
        }

        /// <summary>
        ///     Describes for the user the results of the most-recently run Save operation.
        /// </summary>
        /// <param name="totalRowsAffected">
        ///     (Required.) Specifies the total number of rows
        ///     affected by the Save operation.
        /// </param>
        /// <remarks>
        ///     This method resets the main Status Bar message back to the Idle
        ///     Message (Ready), and then updates the Rows Affected panel to display how
        ///     many row(s) in the database got hit by the Save operation.
        /// </remarks>
        private void ReportSaveResults(int totalRowsAffected)
        {
            RowsAffectedReport = totalRowsAffected <= 0
                ? Resources.App_ZeroRowsAffected
                : string.Format(
                    Resources.App_NonzeroRowsAffectedFormat, totalRowsAffected
                );
            StatusBarMessage = Resources.App_IdleMessage;
            Application.DoEvents();
            Thread.Sleep(50);
        }
    }
}