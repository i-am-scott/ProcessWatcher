using ProcessWatcher.Process;
using System.Threading;
using System;

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
            timer = new Timer(new TimerCallback(CheckServerStatus), null, 1000, Timeout.Infinite);
        }

        private void CheckServerStatus(object state)
        {
            foreach (ProcessContainer pc in ServerFactory.servers)
                pc.PollStatus(true);

            timer.Change(1000, Timeout.Infinite);
        }
    }
}