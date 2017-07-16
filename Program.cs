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

            Application.Run(new MainForm());
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

    }
}
