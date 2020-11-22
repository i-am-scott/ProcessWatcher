using Microsoft.Win32;
using ProcessWatcher.Classes;
using ProcessWatcher.Process;
using System;
using System.Windows.Forms;

namespace ProcessWatcher
{
    static class App
    {
        public static Config Cfg;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Cfg = Config.Load();
            StartMonitor();

            if(Cfg.Web.Enabled)
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
            util.Log($"Server '{pc.ProcName}': {pc.Path} was added.");
            ServerFactory.Save();
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
