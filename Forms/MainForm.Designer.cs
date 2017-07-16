namespace ProcessWatcher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tab_servers = new MetroFramework.Controls.MetroTabPage();
            this.tab_newprocess = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.lbl_name = new MetroFramework.Controls.MetroLabel();
            this.input_name = new MetroFramework.Controls.MetroTextBox();
            this.lblTarget = new MetroFramework.Controls.MetroLabel();
            this.input_target = new MetroFramework.Controls.MetroTextBox();
            this.lblStartUp = new MetroFramework.Controls.MetroLabel();
            this.btn_startup = new MetroFramework.Controls.MetroButton();
            this.input_process = new MetroFramework.Controls.MetroTextBox();
            this.SettingsTab = new MetroFramework.Controls.MetroTabPage();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.metroTabControl1.SuspendLayout();
            this.tab_newprocess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tab_servers);
            this.metroTabControl1.Controls.Add(this.tab_newprocess);
            this.metroTabControl1.Controls.Add(this.SettingsTab);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(512, 483);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tab_servers
            // 
            this.tab_servers.HorizontalScrollbarBarColor = true;
            this.tab_servers.HorizontalScrollbarHighlightOnWheel = false;
            this.tab_servers.HorizontalScrollbarSize = 10;
            this.tab_servers.Location = new System.Drawing.Point(4, 38);
            this.tab_servers.Name = "tab_servers";
            this.tab_servers.Size = new System.Drawing.Size(504, 441);
            this.tab_servers.TabIndex = 2;
            this.tab_servers.Text = "Servers";
            this.tab_servers.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tab_servers.VerticalScrollbarBarColor = true;
            this.tab_servers.VerticalScrollbarHighlightOnWheel = false;
            this.tab_servers.VerticalScrollbarSize = 10;
            // 
            // tab_newprocess
            // 
            this.tab_newprocess.Controls.Add(this.metroLabel1);
            this.tab_newprocess.Controls.Add(this.metroComboBox1);
            this.tab_newprocess.Controls.Add(this.lbl_name);
            this.tab_newprocess.Controls.Add(this.input_name);
            this.tab_newprocess.Controls.Add(this.lblTarget);
            this.tab_newprocess.Controls.Add(this.input_target);
            this.tab_newprocess.Controls.Add(this.lblStartUp);
            this.tab_newprocess.Controls.Add(this.btn_startup);
            this.tab_newprocess.Controls.Add(this.input_process);
            this.tab_newprocess.HorizontalScrollbarBarColor = true;
            this.tab_newprocess.HorizontalScrollbarHighlightOnWheel = false;
            this.tab_newprocess.HorizontalScrollbarSize = 10;
            this.tab_newprocess.Location = new System.Drawing.Point(4, 38);
            this.tab_newprocess.Name = "tab_newprocess";
            this.tab_newprocess.Size = new System.Drawing.Size(504, 441);
            this.tab_newprocess.TabIndex = 0;
            this.tab_newprocess.Text = "Add Process";
            this.tab_newprocess.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tab_newprocess.VerticalScrollbarBarColor = true;
            this.tab_newprocess.VerticalScrollbarHighlightOnWheel = false;
            this.tab_newprocess.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(-4, 177);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 19);
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "Priority";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.IntegralHeight = false;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "Low",
            "Below Normal",
            "Normal",
            "Above Normal",
            "High",
            "Realtime"});
            this.metroComboBox1.Location = new System.Drawing.Point(0, 199);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(233, 29);
            this.metroComboBox1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroComboBox1.TabIndex = 10;
            this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox1.UseSelectable = true;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(-4, 14);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(45, 19);
            this.lbl_name.TabIndex = 8;
            this.lbl_name.Text = "Name";
            this.lbl_name.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // input_name
            // 
            // 
            // 
            // 
            this.input_name.CustomButton.Image = null;
            this.input_name.CustomButton.Location = new System.Drawing.Point(482, 1);
            this.input_name.CustomButton.Name = "";
            this.input_name.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.input_name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.input_name.CustomButton.TabIndex = 1;
            this.input_name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.input_name.CustomButton.UseSelectable = true;
            this.input_name.CustomButton.Visible = false;
            this.input_name.Lines = new string[0];
            this.input_name.Location = new System.Drawing.Point(0, 36);
            this.input_name.MaxLength = 32767;
            this.input_name.Name = "input_name";
            this.input_name.PasswordChar = '\0';
            this.input_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.input_name.SelectedText = "";
            this.input_name.SelectionLength = 0;
            this.input_name.SelectionStart = 0;
            this.input_name.ShortcutsEnabled = true;
            this.input_name.Size = new System.Drawing.Size(504, 23);
            this.input_name.Style = MetroFramework.MetroColorStyle.Lime;
            this.input_name.TabIndex = 7;
            this.input_name.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.input_name.UseSelectable = true;
            this.input_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.input_name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(-4, 123);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(75, 19);
            this.lblTarget.TabIndex = 6;
            this.lblTarget.Text = "Parameters";
            this.lblTarget.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // input_target
            // 
            // 
            // 
            // 
            this.input_target.CustomButton.Image = null;
            this.input_target.CustomButton.Location = new System.Drawing.Point(482, 1);
            this.input_target.CustomButton.Name = "";
            this.input_target.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.input_target.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.input_target.CustomButton.TabIndex = 1;
            this.input_target.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.input_target.CustomButton.UseSelectable = true;
            this.input_target.CustomButton.Visible = false;
            this.input_target.Lines = new string[0];
            this.input_target.Location = new System.Drawing.Point(0, 145);
            this.input_target.MaxLength = 32767;
            this.input_target.Name = "input_target";
            this.input_target.PasswordChar = '\0';
            this.input_target.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.input_target.SelectedText = "";
            this.input_target.SelectionLength = 0;
            this.input_target.SelectionStart = 0;
            this.input_target.ShortcutsEnabled = true;
            this.input_target.Size = new System.Drawing.Size(504, 23);
            this.input_target.Style = MetroFramework.MetroColorStyle.Lime;
            this.input_target.TabIndex = 5;
            this.input_target.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.input_target.UseSelectable = true;
            this.input_target.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.input_target.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblStartUp
            // 
            this.lblStartUp.AutoSize = true;
            this.lblStartUp.Location = new System.Drawing.Point(-4, 69);
            this.lblStartUp.Name = "lblStartUp";
            this.lblStartUp.Size = new System.Drawing.Size(53, 19);
            this.lblStartUp.TabIndex = 4;
            this.lblStartUp.Text = "Process";
            this.lblStartUp.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btn_startup
            // 
            this.btn_startup.Location = new System.Drawing.Point(425, 91);
            this.btn_startup.Name = "btn_startup";
            this.btn_startup.Size = new System.Drawing.Size(79, 23);
            this.btn_startup.Style = MetroFramework.MetroColorStyle.Lime;
            this.btn_startup.TabIndex = 3;
            this.btn_startup.Text = "Browse";
            this.btn_startup.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_startup.UseSelectable = true;
            // 
            // input_process
            // 
            // 
            // 
            // 
            this.input_process.CustomButton.Image = null;
            this.input_process.CustomButton.Location = new System.Drawing.Point(397, 1);
            this.input_process.CustomButton.Name = "";
            this.input_process.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.input_process.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.input_process.CustomButton.TabIndex = 1;
            this.input_process.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.input_process.CustomButton.UseSelectable = true;
            this.input_process.CustomButton.Visible = false;
            this.input_process.Lines = new string[0];
            this.input_process.Location = new System.Drawing.Point(0, 91);
            this.input_process.MaxLength = 32767;
            this.input_process.Name = "input_process";
            this.input_process.PasswordChar = '\0';
            this.input_process.PromptText = "C:\\Windows\\Calc.exe";
            this.input_process.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.input_process.SelectedText = "";
            this.input_process.SelectionLength = 0;
            this.input_process.SelectionStart = 0;
            this.input_process.ShortcutsEnabled = true;
            this.input_process.Size = new System.Drawing.Size(419, 23);
            this.input_process.Style = MetroFramework.MetroColorStyle.Lime;
            this.input_process.TabIndex = 2;
            this.input_process.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.input_process.UseSelectable = true;
            this.input_process.WaterMark = "C:\\Windows\\Calc.exe";
            this.input_process.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.input_process.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SettingsTab
            // 
            this.SettingsTab.HorizontalScrollbarBarColor = true;
            this.SettingsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.SettingsTab.HorizontalScrollbarSize = 10;
            this.SettingsTab.Location = new System.Drawing.Point(4, 38);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SettingsTab.Size = new System.Drawing.Size(504, 441);
            this.SettingsTab.Style = MetroFramework.MetroColorStyle.Lime;
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SettingsTab.VerticalScrollbarBarColor = true;
            this.SettingsTab.VerticalScrollbarHighlightOnWheel = false;
            this.SettingsTab.VerticalScrollbarSize = 10;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(558, 569);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "MainForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Watcher";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.tab_newprocess.ResumeLayout(false);
            this.tab_newprocess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage tab_newprocess;
        private MetroFramework.Controls.MetroTabPage SettingsTab;
        private MetroFramework.Controls.MetroTabPage tab_servers;
        private MetroFramework.Controls.MetroTextBox input_process;
        private MetroFramework.Controls.MetroLabel lblStartUp;
        private MetroFramework.Controls.MetroButton btn_startup;
        private MetroFramework.Controls.MetroLabel lblTarget;
        private MetroFramework.Controls.MetroTextBox input_target;
        private MetroFramework.Controls.MetroLabel lbl_name;
        private MetroFramework.Controls.MetroTextBox input_name;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}

