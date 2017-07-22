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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tab_servers = new MetroFramework.Controls.MetroTabPage();
            this.datagrid_view = new System.Windows.Forms.DataGridView();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_uptime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cpu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_memusage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_start = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tab_newprocess = new MetroFramework.Controls.MetroTabPage();
            this.button_update = new MetroFramework.Controls.MetroButton();
            this.label_web_desc = new MetroFramework.Controls.MetroLabel();
            this.label_autostart_desc = new MetroFramework.Controls.MetroLabel();
            this.toggle_autostart = new MetroFramework.Controls.MetroToggle();
            this.label_autostart = new MetroFramework.Controls.MetroLabel();
            this.toggle_web = new MetroFramework.Controls.MetroToggle();
            this.label_web = new MetroFramework.Controls.MetroLabel();
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
            this.style_manager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.input_startfrom = new MetroFramework.Controls.MetroTextBox();
            this.button_delete = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.tab_servers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_view)).BeginInit();
            this.tab_newprocess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.style_manager)).BeginInit();
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
            this.metroTabControl1.Size = new System.Drawing.Size(580, 483);
            this.metroTabControl1.TabIndex = 0;
            // 
            // tab_servers
            // 
            this.tab_servers.Controls.Add(this.datagrid_view);
            this.tab_servers.HorizontalScrollbarBarColor = true;
            this.tab_servers.Location = new System.Drawing.Point(4, 35);
            this.tab_servers.Name = "tab_servers";
            this.tab_servers.Size = new System.Drawing.Size(572, 444);
            this.tab_servers.TabIndex = 2;
            this.tab_servers.Text = "Servers";
            this.tab_servers.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tab_servers.VerticalScrollbarBarColor = true;
            // 
            // datagrid_view
            // 
            this.datagrid_view.AllowUserToAddRows = false;
            this.datagrid_view.AllowUserToDeleteRows = false;
            this.datagrid_view.BackgroundColor = System.Drawing.SystemColors.Control;
            this.datagrid_view.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagrid_view.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datagrid_view.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuBar;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrid_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_name,
            this.col_uptime,
            this.col_cpu,
            this.col_memusage,
            this.col_start,
            this.col_edit});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrid_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagrid_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagrid_view.EnableHeadersVisualStyles = false;
            this.datagrid_view.Location = new System.Drawing.Point(0, 0);
            this.datagrid_view.Name = "datagrid_view";
            this.datagrid_view.ReadOnly = true;
            this.datagrid_view.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datagrid_view.RowHeadersVisible = false;
            this.datagrid_view.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagrid_view.Size = new System.Drawing.Size(572, 444);
            this.datagrid_view.TabIndex = 2;
            this.datagrid_view.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_view_CellContentClick);
            // 
            // col_name
            // 
            this.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_name.HeaderText = "Name";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            // 
            // col_uptime
            // 
            this.col_uptime.HeaderText = "Uptime";
            this.col_uptime.Name = "col_uptime";
            this.col_uptime.ReadOnly = true;
            this.col_uptime.Width = 65;
            // 
            // col_cpu
            // 
            this.col_cpu.HeaderText = "CPU";
            this.col_cpu.Name = "col_cpu";
            this.col_cpu.ReadOnly = true;
            this.col_cpu.Width = 65;
            // 
            // col_memusage
            // 
            this.col_memusage.HeaderText = "RAM";
            this.col_memusage.Name = "col_memusage";
            this.col_memusage.ReadOnly = true;
            this.col_memusage.Width = 65;
            // 
            // col_start
            // 
            this.col_start.HeaderText = "Start";
            this.col_start.Name = "col_start";
            this.col_start.ReadOnly = true;
            this.col_start.UseColumnTextForButtonValue = true;
            this.col_start.Width = 65;
            // 
            // col_edit
            // 
            this.col_edit.HeaderText = "Edit";
            this.col_edit.Name = "col_edit";
            this.col_edit.ReadOnly = true;
            this.col_edit.UseColumnTextForButtonValue = true;
            this.col_edit.Width = 65;
            // 
            // tab_newprocess
            // 
            this.tab_newprocess.Controls.Add(this.button_delete);
            this.tab_newprocess.Controls.Add(this.metroLabel2);
            this.tab_newprocess.Controls.Add(this.input_startfrom);
            this.tab_newprocess.Controls.Add(this.button_update);
            this.tab_newprocess.Controls.Add(this.label_web_desc);
            this.tab_newprocess.Controls.Add(this.label_autostart_desc);
            this.tab_newprocess.Controls.Add(this.toggle_autostart);
            this.tab_newprocess.Controls.Add(this.label_autostart);
            this.tab_newprocess.Controls.Add(this.toggle_web);
            this.tab_newprocess.Controls.Add(this.label_web);
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
            this.tab_newprocess.Location = new System.Drawing.Point(4, 35);
            this.tab_newprocess.Name = "tab_newprocess";
            this.tab_newprocess.Size = new System.Drawing.Size(572, 444);
            this.tab_newprocess.TabIndex = 0;
            this.tab_newprocess.Text = "Add Process";
            this.tab_newprocess.VerticalScrollbarBarColor = true;
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(464, 418);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(105, 23);
            this.button_update.TabIndex = 18;
            this.button_update.Text = "Create";
            // 
            // label_web_desc
            // 
            this.label_web_desc.AutoSize = true;
            this.label_web_desc.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label_web_desc.Location = new System.Drawing.Point(3, 325);
            this.label_web_desc.Name = "label_web_desc";
            this.label_web_desc.Size = new System.Drawing.Size(430, 15);
            this.label_web_desc.TabIndex = 17;
            this.label_web_desc.Text = "Enable remote viewing and editing of this process via the Nancy Webserver control" +
    "ler";
            // 
            // label_autostart_desc
            // 
            this.label_autostart_desc.AutoSize = true;
            this.label_autostart_desc.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label_autostart_desc.Location = new System.Drawing.Point(3, 284);
            this.label_autostart_desc.Name = "label_autostart_desc";
            this.label_autostart_desc.Size = new System.Drawing.Size(471, 15);
            this.label_autostart_desc.TabIndex = 16;
            this.label_autostart_desc.Text = "Determines if we should start this process once created and every time this appli" +
    "cation starts.";
            // 
            // toggle_autostart
            // 
            this.toggle_autostart.AutoSize = true;
            this.toggle_autostart.Location = new System.Drawing.Point(489, 284);
            this.toggle_autostart.Name = "toggle_autostart";
            this.toggle_autostart.Size = new System.Drawing.Size(80, 17);
            this.toggle_autostart.TabIndex = 15;
            this.toggle_autostart.Text = "Off";
            this.toggle_autostart.UseVisualStyleBackColor = true;
            // 
            // label_autostart
            // 
            this.label_autostart.AutoSize = true;
            this.label_autostart.Location = new System.Drawing.Point(3, 265);
            this.label_autostart.Name = "label_autostart";
            this.label_autostart.Size = new System.Drawing.Size(69, 19);
            this.label_autostart.TabIndex = 14;
            this.label_autostart.Text = "Auto Start";
            // 
            // toggle_web
            // 
            this.toggle_web.AutoSize = true;
            this.toggle_web.Checked = true;
            this.toggle_web.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggle_web.Location = new System.Drawing.Point(489, 325);
            this.toggle_web.Name = "toggle_web";
            this.toggle_web.Size = new System.Drawing.Size(80, 17);
            this.toggle_web.TabIndex = 13;
            this.toggle_web.Text = "On";
            this.toggle_web.UseVisualStyleBackColor = true;
            // 
            // label_web
            // 
            this.label_web.AutoSize = true;
            this.label_web.Location = new System.Drawing.Point(3, 306);
            this.label_web.Name = "label_web";
            this.label_web.Size = new System.Drawing.Size(84, 19);
            this.label_web.TabIndex = 12;
            this.label_web.Text = "Web Control";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 206);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 19);
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "Priority";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.metroComboBox1.Location = new System.Drawing.Point(3, 228);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(219, 29);
            this.metroComboBox1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroComboBox1.TabIndex = 10;
            this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(3, 14);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(45, 19);
            this.lbl_name.TabIndex = 8;
            this.lbl_name.Text = "Name";
            // 
            // input_name
            // 
            this.input_name.Location = new System.Drawing.Point(3, 36);
            this.input_name.Name = "input_name";
            this.input_name.Size = new System.Drawing.Size(569, 23);
            this.input_name.TabIndex = 7;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(0, 158);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(75, 19);
            this.lblTarget.TabIndex = 6;
            this.lblTarget.Text = "Parameters";
            // 
            // input_target
            // 
            this.input_target.Location = new System.Drawing.Point(3, 180);
            this.input_target.Name = "input_target";
            this.input_target.Size = new System.Drawing.Size(569, 23);
            this.input_target.TabIndex = 5;
            // 
            // lblStartUp
            // 
            this.lblStartUp.AutoSize = true;
            this.lblStartUp.Location = new System.Drawing.Point(3, 62);
            this.lblStartUp.Name = "lblStartUp";
            this.lblStartUp.Size = new System.Drawing.Size(45, 19);
            this.lblStartUp.TabIndex = 4;
            this.lblStartUp.Text = "Target";
            // 
            // btn_startup
            // 
            this.btn_startup.Location = new System.Drawing.Point(492, 84);
            this.btn_startup.Name = "btn_startup";
            this.btn_startup.Size = new System.Drawing.Size(80, 23);
            this.btn_startup.TabIndex = 3;
            this.btn_startup.Text = "Browse";
            // 
            // input_process
            // 
            this.input_process.Location = new System.Drawing.Point(3, 84);
            this.input_process.Name = "input_process";
            this.input_process.PromptText = "C:\\Windows\\Calc.exe";
            this.input_process.Size = new System.Drawing.Size(487, 23);
            this.input_process.TabIndex = 2;
            // 
            // SettingsTab
            // 
            this.SettingsTab.HorizontalScrollbarBarColor = true;
            this.SettingsTab.Location = new System.Drawing.Point(4, 35);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SettingsTab.Size = new System.Drawing.Size(572, 444);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.VerticalScrollbarBarColor = true;
            // 
            // style_manager
            // 
            this.style_manager.Owner = this;
            this.style_manager.Style = MetroFramework.MetroColorStyle.Red;
            this.style_manager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(-1, 110);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(51, 19);
            this.metroLabel2.TabIndex = 20;
            this.metroLabel2.Text = "Start In";
            // 
            // input_startfrom
            // 
            this.input_startfrom.Location = new System.Drawing.Point(3, 132);
            this.input_startfrom.Name = "input_startfrom";
            this.input_startfrom.Size = new System.Drawing.Size(569, 23);
            this.input_startfrom.TabIndex = 19;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(353, 418);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(105, 23);
            this.button_delete.Style = MetroFramework.MetroColorStyle.Red;
            this.button_delete.TabIndex = 21;
            this.button_delete.Text = "Delete";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 569);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.None;
            this.Text = "Watcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.tab_servers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_view)).EndInit();
            this.tab_newprocess.ResumeLayout(false);
            this.tab_newprocess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.style_manager)).EndInit();
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
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridView datagrid_view;
        protected MetroFramework.Components.MetroStyleManager style_manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_uptime;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cpu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_memusage;
        private System.Windows.Forms.DataGridViewButtonColumn col_start;
        private System.Windows.Forms.DataGridViewButtonColumn col_edit;
        private MetroFramework.Controls.MetroLabel label_web;
        private MetroFramework.Controls.MetroToggle toggle_web;
        private MetroFramework.Controls.MetroToggle toggle_autostart;
        private MetroFramework.Controls.MetroLabel label_autostart;
        private MetroFramework.Controls.MetroLabel label_autostart_desc;
        private MetroFramework.Controls.MetroLabel label_web_desc;
        private MetroFramework.Controls.MetroButton button_update;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox input_startfrom;
        private MetroFramework.Controls.MetroButton button_delete;
    }
}

