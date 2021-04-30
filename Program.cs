using System;
using System.IO;
using System.Threading;
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
            ConfigureDatabaseFileLocation();

            Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException
            );
            Application.ThreadException += OnThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ProgressWindow.Instance.Status =
                "Loading employee records from the system...";
            ProgressWindow.Instance.ShowAndRunTask(ConnectToDatabase);

            Application.Run(MainWindow.Instance);
        }

        /// <summary>
        ///     Logs the error info from the <paramref name="exception" /> object reference
        ///     provided.
        /// </summary>
        /// <param name="exception">
        ///     A <see cref="T:System.Exception" /> that contains the
        ///     error information.
        /// </param>
        /// <remarks>
        ///     This method does nothing if the <paramref name="exception" />
        ///     parameter has a <c>null</c> value.
        /// </remarks>
        private static void CaptureErrorInfo(Exception exception)
        {
            if (exception == null) return;

            var logPath = Path.Combine(
                Path.GetTempPath(),
                $"{Path.GetFileNameWithoutExtension(Application.ExecutablePath)}.log"
            );
            if (File.Exists(logPath))
                File.Delete(logPath);

            File.WriteAllLines(
                logPath,
                new[]
                {
                    $"Most recent connection string used: {EmployeesConnectionTester.LastUsedConnectionString}",
                    $"Exception details: {exception.Message}\r\n\t{exception.StackTrace}"
                }
            );
        }

        /// <summary>
        ///     Sets up the database files that this application utilizes to be installed
        ///     in the current user's local application data directory path.
        /// </summary>
        /// <remarks>
        ///     Each user on the same computer who utilizes this application gets the
        ///     same local copy of the database.
        /// </remarks>
        private static void ConfigureDatabaseFileLocation()
        {
            // ASSUMING that our deploy_db.bat script copies our .mdf and .ldf files
            // to %PROGRAMDATA%\xyLOGIX, LLC, we need to switch the data directory in
            // the app.config to be there
            var appDataDir = Environment.ExpandEnvironmentVariables(
                @"%PROGRAMDATA%\xyLOGIX, LLC\EmployeeManager\Data"
            );

            try
            {
                if (!Directory.Exists(appDataDir))
                    Directory.CreateDirectory(appDataDir);

                var destMdfFilePath = Path.Combine(appDataDir, "Employees.mdf");
                var destDatabaseLogFilePath = Path.Combine(
                    appDataDir, "Employees_log.ldf"
                );
                var appInstallationDir =
                    Path.GetDirectoryName(Application.ExecutablePath);
                if (appInstallationDir == null)
                    return;

                // don't overwrite the database that all users see
                if (!File.Exists(destMdfFilePath))
                    new FileInfo(
                        Path.Combine(appInstallationDir, "Employees.mdf")
                    ).CopyTo(destMdfFilePath);
                if (!File.Exists(destDatabaseLogFilePath))
                    new FileInfo(
                        Path.Combine(appInstallationDir, "Employees_log.ldf")
                    ).CopyTo(destDatabaseLogFilePath);

                AppDomain.CurrentDomain.SetData("DataDirectory", appDataDir);
            }
            catch (Exception ex)
            {
                // some sort of error occurred.
                ProgressWindow.Instance.Hide();
                MessageBox.Show(
                    Resources.Error_CannotFindDatabase, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop
                );

                CaptureErrorInfo(ex);
            }
        }

        /// <summary>
        ///     Checks to ensure the database is available, and then connects to it.
        /// </summary>
        private static void ConnectToDatabase()
        {
            // double check that the database is available.
            if (!EmployeesConnectionTester.IsDatabaseOnline())
            {
                CaptureErrorInfo(EmployeesConnectionTester.LastError);

                ProgressWindow.Instance.Hide();

                MessageBox.Show(
                    Resources.Error_CannotFindDatabase, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop
                );
                Environment.Exit(-1);
            }

            EmployeesServiceManager.Instance.InitializeAll();
        }

        /// <summary>
        ///     Handles the
        ///     <see cref="E:System.Windows.Forms.Application.ThreadException" /> event.
        /// </summary>
        /// <param name="sender">
        ///     Reference to the instance of the object that raised this
        ///     event.
        /// </param>
        /// <param name="e">
        ///     A <see cref="T:System.Threading.ThreadExceptionEventArgs" />
        ///     that contains the event data.
        /// </param>
        private static void OnThreadException(object sender,
            ThreadExceptionEventArgs e)
        {
            CaptureErrorInfo(e.Exception);
        }
    }
}