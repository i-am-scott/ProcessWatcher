using ProcessWatcher.Process;
using System.Threading;
using System;
using System.Windows.Forms;

namespace ProcessWatcher
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private System.Threading.Timer timer;

        public MainForm()
        {
            InitializeComponent();
            FormClosed += (object sender, FormClosedEventArgs e) => {
                Program.OnProcessExit();
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer = new System.Threading.Timer(new TimerCallback(CheckServerStatus), null, 1000, Timeout.Infinite);
        }

        private void CheckServerStatus(object state)
        {
            foreach (ProcessContainer pc in ServerFactory.servers)
                pc.PollStatus(true);

            timer.Change(1000, Timeout.Infinite);
        }
    }
}