using ProcessWatcher.Process;
using System.Threading;
using System;
using ProccessWatcher.Server;

namespace ProcessWatcher
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private Timer timer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer = new Timer(new TimerCallback(CheckServerStatus), null, 5000, Timeout.Infinite);
        }

        private void CheckServerStatus(object state)
        {
            foreach(ProcessContainer pc in ServerFactory.servers)
                pc.CheckStatus(true);

            timer.Change(5000, Timeout.Infinite);
        }
    }
}
