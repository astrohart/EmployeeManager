
namespace EmployeeManager
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.dataToolBar = new System.Windows.Forms.BindingNavigator(this.components);
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeRecordCountLabel = new System.Windows.Forms.ToolStripLabel();
            this.moveFirstButton = new System.Windows.Forms.ToolStripButton();
            this.movePrevButton = new System.Windows.Forms.ToolStripButton();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.positionTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveNextButton = new System.Windows.Forms.ToolStripButton();
            this.moveLastItem = new System.Windows.Forms.ToolStripButton();
            this.sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.employeeFirstNameTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeLastNameTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeTypeComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.employeeTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.sep4 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.messageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.rowsAffectedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataToolBar)).BeginInit();
            this.dataToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTypeBindingSource)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataToolBar
            // 
            this.dataToolBar.AddNewItem = this.addButton;
            this.dataToolBar.BindingSource = this.employeeBindingSource;
            this.dataToolBar.CountItem = this.employeeRecordCountLabel;
            this.dataToolBar.DeleteItem = null;
            this.dataToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveFirstButton,
            this.movePrevButton,
            this.sep1,
            this.positionTextBox,
            this.employeeRecordCountLabel,
            this.sep2,
            this.moveNextButton,
            this.moveLastItem,
            this.sep3,
            this.addButton,
            this.deleteButton,
            this.saveButton});
            this.dataToolBar.Location = new System.Drawing.Point(0, 24);
            this.dataToolBar.MoveFirstItem = this.moveFirstButton;
            this.dataToolBar.MoveLastItem = this.moveLastItem;
            this.dataToolBar.MoveNextItem = this.moveNextButton;
            this.dataToolBar.MovePreviousItem = this.movePrevButton;
            this.dataToolBar.Name = "dataToolBar";
            this.dataToolBar.PositionItem = this.positionTextBox;
            this.dataToolBar.Size = new System.Drawing.Size(732, 25);
            this.dataToolBar.TabIndex = 0;
            this.dataToolBar.Text = "bindingNavigator1";
            // 
            // addButton
            // 
            this.addButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.Name = "addButton";
            this.addButton.RightToLeftAutoMirrorImage = true;
            this.addButton.Size = new System.Drawing.Size(23, 22);
            this.addButton.Text = "&Add New Employee";
            this.addButton.ToolTipText = "Add New Employee (Ctrl + N)";
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(EmployeeManager.Data.Employee);
            // 
            // employeeRecordCountLabel
            // 
            this.employeeRecordCountLabel.Name = "employeeRecordCountLabel";
            this.employeeRecordCountLabel.Size = new System.Drawing.Size(35, 22);
            this.employeeRecordCountLabel.Text = "of {0}";
            this.employeeRecordCountLabel.ToolTipText = "Total number of items";
            // 
            // moveFirstButton
            // 
            this.moveFirstButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveFirstButton.Image = ((System.Drawing.Image)(resources.GetObject("moveFirstButton.Image")));
            this.moveFirstButton.Name = "moveFirstButton";
            this.moveFirstButton.RightToLeftAutoMirrorImage = true;
            this.moveFirstButton.Size = new System.Drawing.Size(23, 22);
            this.moveFirstButton.Text = "Move first";
            // 
            // movePrevButton
            // 
            this.movePrevButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.movePrevButton.Image = ((System.Drawing.Image)(resources.GetObject("movePrevButton.Image")));
            this.movePrevButton.Name = "movePrevButton";
            this.movePrevButton.RightToLeftAutoMirrorImage = true;
            this.movePrevButton.Size = new System.Drawing.Size(23, 22);
            this.movePrevButton.Text = "Move previous";
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(6, 25);
            // 
            // positionTextBox
            // 
            this.positionTextBox.AccessibleName = "Position";
            this.positionTextBox.AutoSize = false;
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(50, 23);
            this.positionTextBox.Text = "0";
            this.positionTextBox.ToolTipText = "Current position";
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(6, 25);
            // 
            // moveNextButton
            // 
            this.moveNextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveNextButton.Image = ((System.Drawing.Image)(resources.GetObject("moveNextButton.Image")));
            this.moveNextButton.Name = "moveNextButton";
            this.moveNextButton.RightToLeftAutoMirrorImage = true;
            this.moveNextButton.Size = new System.Drawing.Size(23, 22);
            this.moveNextButton.Text = "Move next";
            // 
            // moveLastItem
            // 
            this.moveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("moveLastItem.Image")));
            this.moveLastItem.Name = "moveLastItem";
            this.moveLastItem.RightToLeftAutoMirrorImage = true;
            this.moveLastItem.Size = new System.Drawing.Size(23, 22);
            this.moveLastItem.Text = "Move last";
            // 
            // sep3
            // 
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(6, 25);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.RightToLeftAutoMirrorImage = true;
            this.deleteButton.Size = new System.Drawing.Size(23, 22);
            this.deleteButton.Text = "&Delete";
            this.deleteButton.ToolTipText = "Delete (Del)";
            this.deleteButton.Click += new System.EventHandler(this.OnEmployeeDelete);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "&Save";
            this.saveButton.ToolTipText = "Save (Ctrl + S)";
            this.saveButton.Click += new System.EventHandler(this.OnFileSave);
            // 
            // employeeDataGridView
            // 
            this.employeeDataGridView.AllowUserToAddRows = false;
            this.employeeDataGridView.AutoGenerateColumns = false;
            this.employeeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeFirstNameTextBoxColumn,
            this.employeeLastNameTextBoxColumn,
            this.employeeTypeComboBoxColumn});
            this.employeeDataGridView.DataSource = this.employeeBindingSource;
            this.employeeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDataGridView.Location = new System.Drawing.Point(0, 49);
            this.employeeDataGridView.Name = "employeeDataGridView";
            this.employeeDataGridView.Size = new System.Drawing.Size(732, 349);
            this.employeeDataGridView.TabIndex = 1;
            this.employeeDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.OnValidatingEmployeeType);
            this.employeeDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnDataError);
            this.employeeDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.OnUserDeletingRow);
            // 
            // employeeFirstNameTextBoxColumn
            // 
            this.employeeFirstNameTextBoxColumn.DataPropertyName = "FirstName";
            this.employeeFirstNameTextBoxColumn.HeaderText = "First Name";
            this.employeeFirstNameTextBoxColumn.Name = "employeeFirstNameTextBoxColumn";
            // 
            // employeeLastNameTextBoxColumn
            // 
            this.employeeLastNameTextBoxColumn.DataPropertyName = "LastName";
            this.employeeLastNameTextBoxColumn.HeaderText = "Last Name";
            this.employeeLastNameTextBoxColumn.Name = "employeeLastNameTextBoxColumn";
            // 
            // employeeTypeComboBoxColumn
            // 
            this.employeeTypeComboBoxColumn.DataPropertyName = "EmployeeTypeId";
            this.employeeTypeComboBoxColumn.DataSource = this.employeeTypeBindingSource;
            this.employeeTypeComboBoxColumn.DisplayMember = "EmployeeTypeName";
            this.employeeTypeComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.employeeTypeComboBoxColumn.HeaderText = "Employee Type";
            this.employeeTypeComboBoxColumn.Name = "employeeTypeComboBoxColumn";
            this.employeeTypeComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeTypeComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.employeeTypeComboBoxColumn.ValueMember = "EmployeeTypeID";
            // 
            // employeeTypeBindingSource
            // 
            this.employeeTypeBindingSource.DataSource = typeof(EmployeeManager.Data.EmployeeType);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.employeeMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(732, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNew,
            this.fileSave,
            this.sep4,
            this.fileExit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            this.fileMenu.DropDownOpening += new System.EventHandler(this.OnFileMenuDropDownOpening);
            // 
            // fileNew
            // 
            this.fileNew.Image = ((System.Drawing.Image)(resources.GetObject("fileNew.Image")));
            this.fileNew.Name = "fileNew";
            this.fileNew.RightToLeftAutoMirrorImage = true;
            this.fileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.fileNew.Size = new System.Drawing.Size(221, 22);
            this.fileNew.Text = "&Add New Employee";
            this.fileNew.Click += new System.EventHandler(this.OnFileNew);
            // 
            // fileSave
            // 
            this.fileSave.Image = ((System.Drawing.Image)(resources.GetObject("fileSave.Image")));
            this.fileSave.Name = "fileSave";
            this.fileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.fileSave.Size = new System.Drawing.Size(221, 22);
            this.fileSave.Text = "&Save";
            this.fileSave.Click += new System.EventHandler(this.OnFileSave);
            // 
            // sep4
            // 
            this.sep4.Name = "sep4";
            this.sep4.Size = new System.Drawing.Size(218, 6);
            // 
            // fileExit
            // 
            this.fileExit.Name = "fileExit";
            this.fileExit.Size = new System.Drawing.Size(221, 22);
            this.fileExit.Text = "E&xit";
            this.fileExit.Click += new System.EventHandler(this.OnFileExit);
            // 
            // employeeMenu
            // 
            this.employeeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeDelete});
            this.employeeMenu.Name = "employeeMenu";
            this.employeeMenu.Size = new System.Drawing.Size(71, 20);
            this.employeeMenu.Text = "&Employee";
            this.employeeMenu.DropDownOpening += new System.EventHandler(this.OnEmployeeMenuDropDownOpening);
            // 
            // employeeDelete
            // 
            this.employeeDelete.Image = ((System.Drawing.Image)(resources.GetObject("employeeDelete.Image")));
            this.employeeDelete.Name = "employeeDelete";
            this.employeeDelete.RightToLeftAutoMirrorImage = true;
            this.employeeDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.employeeDelete.Size = new System.Drawing.Size(131, 22);
            this.employeeDelete.Text = "&Delete";
            this.employeeDelete.Click += new System.EventHandler(this.OnEmployeeDelete);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageLabel,
            this.rowsAffectedLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 374);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(732, 24);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusStrip1";
            // 
            // messageLabel
            // 
            this.messageLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(605, 19);
            this.messageLabel.Spring = true;
            this.messageLabel.Text = "Ready";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rowsAffectedLabel
            // 
            this.rowsAffectedLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.rowsAffectedLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.rowsAffectedLabel.Name = "rowsAffectedLabel";
            this.rowsAffectedLabel.Size = new System.Drawing.Size(112, 19);
            this.rowsAffectedLabel.Text = "No row(s) affected.";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(732, 398);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.employeeDataGridView);
            this.Controls.Add(this.dataToolBar);
            this.Controls.Add(this.mainMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xyLOGIX Employee Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataToolBar)).EndInit();
            this.dataToolBar.ResumeLayout(false);
            this.dataToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTypeBindingSource)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.BindingNavigator dataToolBar;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripLabel employeeRecordCountLabel;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton moveFirstButton;
        private System.Windows.Forms.ToolStripButton movePrevButton;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ToolStripTextBox positionTextBox;
        private System.Windows.Forms.ToolStripSeparator sep2;
        private System.Windows.Forms.ToolStripButton moveNextButton;
        private System.Windows.Forms.ToolStripButton moveLastItem;
        private System.Windows.Forms.ToolStripSeparator sep3;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.DataGridView employeeDataGridView;
        private System.Windows.Forms.BindingSource employeeTypeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeFirstNameTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeLastNameTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn employeeTypeComboBoxColumn;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSave;
        private System.Windows.Forms.ToolStripSeparator sep4;
        private System.Windows.Forms.ToolStripMenuItem fileExit;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel messageLabel;
        private System.Windows.Forms.ToolStripStatusLabel rowsAffectedLabel;
        private System.Windows.Forms.ToolStripMenuItem fileNew;
        private System.Windows.Forms.ToolStripMenuItem employeeMenu;
        private System.Windows.Forms.ToolStripMenuItem employeeDelete;
    }
}

