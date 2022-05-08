using System.Diagnostics;

namespace Live_Console
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] processes = Process.GetProcessesByName(Application.ProductName);
            if (processes.Length > 1)
            {
                MessageBox.Show("应用程序正在运行中...");
                Environment.Exit(1);
            }
            else
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new FrmMain());
                
            }
        }
    }
}
