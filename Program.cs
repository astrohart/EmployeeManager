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

        private static void ConfigureDatabaseFileLocation()
        {
            // ASSUMING that our deploy_db.bat script copies our .mdf and .ldf files
            // to %LOCALAPPDATA%\xyLOGIX, LLC, we need to switch the data directory in
            // the app.config to be there
            var appDataDir = Environment
                .ExpandEnvironmentVariables(@"%LOCALAPPDATA%\xyLOGIX, LLC")
                .ToUpperInvariant();

            /* obviously, File I/O here should be done inside a try/catch, but
             we are going to, for expediency, make the naive assumption here that
            our I/O will work just fine. */

            if (!Directory.Exists(appDataDir))
                Directory.CreateDirectory(appDataDir);

            var appInstallationDir =
                Path.GetDirectoryName(Application.ExecutablePath);
            if (appInstallationDir == null)
                return;

            new FileInfo(Path.Combine(appInstallationDir, "Employees.mdf"))
                .CopyTo(Path.Combine(appDataDir, "Employees.mdf"), true);
            new FileInfo(Path.Combine(appInstallationDir, "Employees_log.ldf"))
                .CopyTo(Path.Combine(appDataDir, "Employees_log.ldf"), true);

            AppDomain.CurrentDomain.SetData("DataDirectory", appDataDir);
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