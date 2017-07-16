using Microsoft.Win32;
using ProcessWatcher.Process;
using System;
using System.Windows.Forms;

namespace ProcessWatcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            StartMonitor();

            Application.Run(new MainForm());
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            foreach (ProcessContainer pw in ServerFactory.servers)
                pw.CloseProcess();

            ServerFactory.Save();
        }

        static void StartMonitor()
        {
            ServerFactory.OnServerAdded += ServerFactory_OnServerAdded;
            ServerFactory.Load();
        }

        private static void ServerFactory_OnServerAdded(ProcessContainer pc)
        {
            Console.WriteLine($"Server '{pc.name}': {pc.path} was added.");
        }

        private static void RunOnStartUp(bool run)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (run)
                rk.SetValue(AppDomain.CurrentDomain.FriendlyName, Application.ExecutablePath);
            else
                rk.DeleteValue(AppDomain.CurrentDomain.FriendlyName, false);
        }

    }
}
