using ProcessWatcher.Process;
using System.Threading;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace ProcessWatcher
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private System.Threading.Timer timer;

        public MainForm()
        {
            InitializeComponent();

            style_manager.Owner = this;

            datagrid_view.BackgroundColor = style_manager.Theme == MetroFramework.MetroThemeStyle.Dark ? BackColor : Color.WhiteSmoke;
            datagrid_view.BorderStyle = System.Windows.Forms.BorderStyle.None;
            datagrid_view.RowHeadersVisible = false;
            datagrid_view.RowHeadersWidth = 4;

            datagrid_view.ColumnHeadersDefaultCellStyle.BackColor = style_manager.Theme == MetroFramework.MetroThemeStyle.Dark ? Color.Black : Color.White;
            datagrid_view.ColumnHeadersDefaultCellStyle.ForeColor = style_manager.Theme == MetroFramework.MetroThemeStyle.Dark ? Color.WhiteSmoke : Color.Gray;
            datagrid_view.ColumnHeadersDefaultCellStyle.SelectionForeColor = style_manager.Theme == MetroFramework.MetroThemeStyle.Dark ? Color.White : Color.Black;
            datagrid_view.ColumnHeadersDefaultCellStyle.SelectionBackColor = style_manager.Theme == MetroFramework.MetroThemeStyle.Dark ? Color.Black : Color.White;

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

        private void datagrid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}