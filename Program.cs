using Microsoft.Win32;
using ProcessWatcher.Classes;
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

            StartMonitor();
            APIServer.Nancy.Start();

            Application.Run(new MainForm());
        }

        public static void OnProcessExit()
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
            util.Log($"Server '{pc.name}': {pc.path} was added.");
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
