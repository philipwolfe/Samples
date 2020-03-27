namespace How_To_Service_Manager
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.cmdResume = new System.Windows.Forms.Button();
            this.cmdPause = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.chSvcType = new System.Windows.Forms.ColumnHeader();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.chStatus = new System.Windows.Forms.ColumnHeader();
            this.lvServices = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.pnlCommands = new System.Windows.Forms.Panel();
            this.mnuTools = new System.Windows.Forms.MenuItem();
            this.mnuRelist = new System.Windows.Forms.MenuItem();
            this.MenuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuRefresh = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuHelp = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.sbInfo = new System.Windows.Forms.StatusBar();
            this.pnlCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.Checked = true;
            this.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRefresh.Location = new System.Drawing.Point(336, 8);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(104, 24);
            this.chkAutoRefresh.TabIndex = 4;
            this.chkAutoRefresh.Text = "&Auto Refresh";
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // cmdResume
            // 
            this.cmdResume.Location = new System.Drawing.Point(248, 8);
            this.cmdResume.Name = "cmdResume";
            this.cmdResume.Size = new System.Drawing.Size(75, 23);
            this.cmdResume.TabIndex = 3;
            this.cmdResume.Text = "&Resume";
            this.cmdResume.Click += new System.EventHandler(this.cmdResume_Click);
            // 
            // cmdPause
            // 
            this.cmdPause.Location = new System.Drawing.Point(168, 8);
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(75, 23);
            this.cmdPause.TabIndex = 2;
            this.cmdPause.Text = "&Pause";
            this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(88, 8);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStop.TabIndex = 1;
            this.cmdStop.Text = "S&top";
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(8, 8);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 0;
            this.cmdStart.Text = "&Start";
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // chSvcType
            // 
            this.chSvcType.Text = "Service Type";
            this.chSvcType.Width = 225;
            // 
            // tmrStatus
            // 
            this.tmrStatus.Enabled = true;
            this.tmrStatus.Interval = 5000;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            this.chStatus.Width = 100;
            // 
            // lvServices
            // 
            this.lvServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chStatus,
            this.chSvcType});
            this.lvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServices.FullRowSelect = true;
            this.lvServices.HideSelection = false;
            this.lvServices.Location = new System.Drawing.Point(0, 0);
            this.lvServices.MultiSelect = false;
            this.lvServices.Name = "lvServices";
            this.lvServices.Size = new System.Drawing.Size(629, 293);
            this.lvServices.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvServices.TabIndex = 3;
            this.lvServices.UseCompatibleStateImageBehavior = false;
            this.lvServices.View = System.Windows.Forms.View.Details;
            this.lvServices.SelectedIndexChanged += new System.EventHandler(this.lvServices_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 200;
            // 
            // pnlCommands
            // 
            this.pnlCommands.Controls.Add(this.chkAutoRefresh);
            this.pnlCommands.Controls.Add(this.cmdResume);
            this.pnlCommands.Controls.Add(this.cmdPause);
            this.pnlCommands.Controls.Add(this.cmdStop);
            this.pnlCommands.Controls.Add(this.cmdStart);
            this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommands.Location = new System.Drawing.Point(0, 293);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Size = new System.Drawing.Size(629, 40);
            this.pnlCommands.TabIndex = 4;
            // 
            // mnuTools
            // 
            this.mnuTools.Index = 1;
            this.mnuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuRelist,
            this.MenuItem3,
            this.mnuRefresh});
            this.mnuTools.Text = "&Tools";
            // 
            // mnuRelist
            // 
            this.mnuRelist.Index = 0;
            this.mnuRelist.Text = "Relist &All Services";
            this.mnuRelist.Click += new System.EventHandler(this.mnuRelist_Click);
            // 
            // MenuItem3
            // 
            this.MenuItem3.Index = 1;
            this.MenuItem3.Text = "-";
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Index = 2;
            this.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.mnuRefresh.Text = "&Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 0;
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuTools,
            this.mnuHelp});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuExit});
            this.mnuFile.Text = "&File";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Index = 2;
            this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbout});
            this.mnuHelp.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 0;
            this.mnuAbout.Text = "Text Comes from AssemblyInfo";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // sbInfo
            // 
            this.sbInfo.Location = new System.Drawing.Point(0, 333);
            this.sbInfo.Name = "sbInfo";
            this.sbInfo.Size = new System.Drawing.Size(629, 22);
            this.sbInfo.TabIndex = 5;
            this.sbInfo.Text = "Ready";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 355);
            this.Controls.Add(this.lvServices);
            this.Controls.Add(this.pnlCommands);
            this.Controls.Add(this.sbInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "Title Comes from Assembly Info";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.Button cmdResume;
        private System.Windows.Forms.Button cmdPause;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.ColumnHeader chSvcType;
        private System.Windows.Forms.Timer tmrStatus;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ListView lvServices;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.Panel pnlCommands;
        private System.Windows.Forms.MenuItem mnuTools;
        private System.Windows.Forms.MenuItem mnuRelist;
        private System.Windows.Forms.MenuItem MenuItem3;
        private System.Windows.Forms.MenuItem mnuRefresh;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuHelp;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.StatusBar sbInfo;
    }
}

