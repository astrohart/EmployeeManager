using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManager
{
    /// <summary>
    ///     Form that displays a progress dialog.
    /// </summary>
    public partial class ProgressWindow : Form
    {
        /// <summary>
        ///     Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static ProgressWindow() { }

        /// <summary>
        ///     Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected ProgressWindow() => InitializeComponent();

        /// <summary>
        ///     Gets a reference to the one and only instance of
        ///     <see cref="T:EmployeeManager.ProgressWindow" />.
        /// </summary>
        public static ProgressWindow Instance { get; } = new ProgressWindow();

        /// <summary>
        ///     Gets or sets the text displayed to the user above the progress bar.
        /// </summary>
        public string Status
        {
            get => statusLabel.Text;
            set => SetStatus(value);
        }

        /// <summary>
        ///     Shows this dialog box and runs the code specified by the
        ///     <paramref name="action" /> on a background thread, while the graphical UI
        ///     remains responsive to the user.
        /// </summary>
        /// <param name="action">
        ///     A <see cref="T:System.Action" /> that specifies the code
        ///     to be run.
        /// </param>
        /// <param name="owner">
        ///     Reference to an instance of an object that implements the
        ///     <see cref="T:System.Windows.Forms.IWin32Window" /> interface that will
        ///     serve as the parent window of this dialog box.
        /// </param>
        /// <returns>
        ///     A <see cref="T:System.Threading.Tasks.Task" /> that can be awaited
        ///     upon.
        /// </returns>
        public void ShowAndRunTask(Action action, IWin32Window owner = null)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            DisplayForm(owner);

            var task = Task.Run(action);

            WaitForTaskToFinish(task);

            Hide();
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.</summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> that contains the event
        ///     data.
        /// </param>
        protected override void OnLoad(EventArgs e) =>
            Text = Application.ProductName;

        /// <summary>
        ///     Displays this form in an aesthetically-pleasing way.
        /// </summary>
        /// <param name="owner">
        ///     Reference to an instance of an object that implements the
        ///     <see cref="T:System.Windows.Forms.IWin32Window" /> interface and which
        ///     represents this form's parent window.
        /// </param>
        private void DisplayForm(IWin32Window owner)
        {
            ShowInTaskbar = owner == null;
            StartPosition = owner == null
                ? FormStartPosition.CenterScreen
                : FormStartPosition.CenterParent;

            if (owner != null)
            {
                Show(owner);
            }
            else
            {
                CenterToScreen();
                Show();
            }
        }

        /// <summary>
        ///     Sets the text displayed on the status control of this dialog box.
        /// </summary>
        /// <param name="value">(Required.) String containing the new text.</param>
        private void SetStatus(string value)
        {
            if (statusLabel.InvokeRequired)
                statusLabel.Invoke(new Action<string>(SetStatus), value);
            else
                statusLabel.Text = value;
        }

        private void WaitForTaskToFinish(Task task)
        {
            while (!task.IsCompleted)
            {
                progressBar.Refresh();
                Application.DoEvents();
                Thread.Sleep(50);
            }
        }
    }
}