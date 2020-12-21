using System;
using System.Windows.Forms;
using EmployeeManager.BusinessLayer;
using EmployeeManager.Properties;

namespace EmployeeManager
{
    /// <summary>
    ///     The application class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ProgressWindow.Instance.Status =
                "Loading employee records from the system...";
            ProgressWindow.Instance.ShowAndRunTask(ConnectToDatabase);

            Application.Run(MainWindow.Instance);
        }

        /// <summary>
        ///     Checks to ensure the database is available, and then connects to it.
        /// </summary>
        private static void ConnectToDatabase()
        {
            // double check that the database is available.
            if (!EmployeesConnectionTester.IsDatabaseOnline())
            {
                ProgressWindow.Instance.Hide();

                MessageBox.Show(
                    Resources.Error_CannotFindDatabase, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop
                );
                Environment.Exit(-1);
            }

            EmployeesServiceManager.Instance.InitializeAll();
        }
    }
}