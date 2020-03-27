namespace How_To_Process_Viewer
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
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuView = new System.Windows.Forms.MenuItem();
            this.mnuModules = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuRefresh = new System.Windows.Forms.MenuItem();
            this.mnuHelp = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.chProcessName = new System.Windows.Forms.ColumnHeader();
            this.chPID = new System.Windows.Forms.ColumnHeader();
            this.chProcessorTime = new System.Windows.Forms.ColumnHeader();
            this.chPriv = new System.Windows.Forms.ColumnHeader();
            this.chUser = new System.Windows.Forms.ColumnHeader();
            this.ctxView = new System.Windows.Forms.ContextMenu();
            this.ctxViewMods = new System.Windows.Forms.MenuItem();
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.ctxRefresh = new System.Windows.Forms.MenuItem();
            this.lvProcessDetail = new System.Windows.Forms.ListView();
            this.chItem = new System.Windows.Forms.ColumnHeader();
            this.chValue = new System.Windows.Forms.ColumnHeader();
            this.sbInfo = new System.Windows.Forms.StatusBar();
            this.splHor = new System.Windows.Forms.Splitter();
            this.lvThreads = new System.Windows.Forms.ListView();
            this.chThreads = new System.Windows.Forms.ColumnHeader();
            this.chBasePri = new System.Windows.Forms.ColumnHeader();
            this.chCurrentPri = new System.Windows.Forms.ColumnHeader();
            this.chPriBoostEnabled = new System.Windows.Forms.ColumnHeader();
            this.chPriLevel = new System.Windows.Forms.ColumnHeader();
            this.chPrivProcTime = new System.Windows.Forms.ColumnHeader();
            this.chStartAddress = new System.Windows.Forms.ColumnHeader();
            this.chStartTime = new System.Windows.Forms.ColumnHeader();
            this.chTotalProcTime = new System.Windows.Forms.ColumnHeader();
            this.chUserProcTime = new System.Windows.Forms.ColumnHeader();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuExit});
            this.mnuFile.Text = "&File";
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
            this.mnuView,
            this.mnuHelp});
            // 
            // mnuView
            // 
            this.mnuView.Index = 1;
            this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuModules,
            this.MenuItem2,
            this.mnuRefresh});
            this.mnuView.Text = "&View";
            // 
            // mnuModules
            // 
            this.mnuModules.Index = 0;
            this.mnuModules.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.mnuModules.Text = "&Modules";
            this.mnuModules.Click += new System.EventHandler(this.mnuModules_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Index = 1;
            this.MenuItem2.Text = "-";
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Index = 2;
            this.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.mnuRefresh.Text = "&Refresh";
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
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
            // lvProcesses
            // 
            this.lvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProcessName,
            this.chPID,
            this.chProcessorTime,
            this.chPriv,
            this.chUser});
            this.lvProcesses.ContextMenu = this.ctxView;
            this.lvProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcesses.FullRowSelect = true;
            this.lvProcesses.Location = new System.Drawing.Point(0, 0);
            this.lvProcesses.MultiSelect = false;
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(575, 475);
            this.lvProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProcesses.TabIndex = 15;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            this.lvProcesses.SelectedIndexChanged += new System.EventHandler(this.lvProcesses_SelectedIndexChanged);
            // 
            // chProcessName
            // 
            this.chProcessName.Text = "Process Name";
            this.chProcessName.Width = 150;
            // 
            // chPID
            // 
            this.chPID.Text = "PID";
            // 
            // chProcessorTime
            // 
            this.chProcessorTime.Text = "Processor Time";
            this.chProcessorTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chProcessorTime.Width = 150;
            // 
            // chPriv
            // 
            this.chPriv.Text = "Priviledged";
            this.chPriv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chPriv.Width = 80;
            // 
            // chUser
            // 
            this.chUser.Text = "User";
            this.chUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chUser.Width = 80;
            // 
            // ctxView
            // 
            this.ctxView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctxViewMods,
            this.MenuItem1,
            this.ctxRefresh});
            // 
            // ctxViewMods
            // 
            this.ctxViewMods.Index = 0;
            this.ctxViewMods.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.ctxViewMods.Text = "View &Modules";
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 1;
            this.MenuItem1.Text = "-";
            // 
            // ctxRefresh
            // 
            this.ctxRefresh.Index = 2;
            this.ctxRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.ctxRefresh.Text = "&Refresh";
            // 
            // lvProcessDetail
            // 
            this.lvProcessDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chItem,
            this.chValue});
            this.lvProcessDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcessDetail.Location = new System.Drawing.Point(0, 0);
            this.lvProcessDetail.MultiSelect = false;
            this.lvProcessDetail.Name = "lvProcessDetail";
            this.lvProcessDetail.Size = new System.Drawing.Size(337, 475);
            this.lvProcessDetail.TabIndex = 13;
            this.lvProcessDetail.UseCompatibleStateImageBehavior = false;
            this.lvProcessDetail.View = System.Windows.Forms.View.Details;
            // 
            // chItem
            // 
            this.chItem.Text = "Item";
            this.chItem.Width = 165;
            // 
            // chValue
            // 
            this.chValue.Text = "Value";
            this.chValue.Width = 206;
            // 
            // sbInfo
            // 
            this.sbInfo.Location = new System.Drawing.Point(0, 630);
            this.sbInfo.Name = "sbInfo";
            this.sbInfo.Size = new System.Drawing.Size(916, 22);
            this.sbInfo.TabIndex = 21;
            this.sbInfo.Text = "Ready";
            // 
            // splHor
            // 
            this.splHor.Dock = System.Windows.Forms.DockStyle.Top;
            this.splHor.Location = new System.Drawing.Point(0, 0);
            this.splHor.Name = "splHor";
            this.splHor.Size = new System.Drawing.Size(916, 3);
            this.splHor.TabIndex = 24;
            this.splHor.TabStop = false;
            // 
            // lvThreads
            // 
            this.lvThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chThreads,
            this.chBasePri,
            this.chCurrentPri,
            this.chPriBoostEnabled,
            this.chPriLevel,
            this.chPrivProcTime,
            this.chStartAddress,
            this.chStartTime,
            this.chTotalProcTime,
            this.chUserProcTime});
            this.lvThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvThreads.FullRowSelect = true;
            this.lvThreads.Location = new System.Drawing.Point(0, 0);
            this.lvThreads.MultiSelect = false;
            this.lvThreads.Name = "lvThreads";
            this.lvThreads.Size = new System.Drawing.Size(916, 148);
            this.lvThreads.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvThreads.TabIndex = 15;
            this.lvThreads.UseCompatibleStateImageBehavior = false;
            this.lvThreads.View = System.Windows.Forms.View.Details;
            // 
            // chThreads
            // 
            this.chThreads.Text = "Thread(s)";
            // 
            // chBasePri
            // 
            this.chBasePri.Text = "Base Priority";
            this.chBasePri.Width = 75;
            // 
            // chCurrentPri
            // 
            this.chCurrentPri.Text = "Current Priority";
            this.chCurrentPri.Width = 85;
            // 
            // chPriBoostEnabled
            // 
            this.chPriBoostEnabled.Text = "Priority Boost Enabled";
            this.chPriBoostEnabled.Width = 115;
            // 
            // chPriLevel
            // 
            this.chPriLevel.Text = "Priority Level";
            this.chPriLevel.Width = 75;
            // 
            // chPrivProcTime
            // 
            this.chPrivProcTime.Text = "Privileged";
            // 
            // chStartAddress
            // 
            this.chStartAddress.Text = "Start Address";
            this.chStartAddress.Width = 80;
            // 
            // chStartTime
            // 
            this.chStartTime.Text = "Start Time";
            this.chStartTime.Width = 120;
            // 
            // chTotalProcTime
            // 
            this.chTotalProcTime.Text = "Processor Time";
            this.chTotalProcTime.Width = 120;
            // 
            // chUserProcTime
            // 
            this.chUserProcTime.Text = "User";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvThreads);
            this.splitContainer1.Size = new System.Drawing.Size(916, 627);
            this.splitContainer1.SplitterDistance = 475;
            this.splitContainer1.TabIndex = 25;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvProcesses);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lvProcessDetail);
            this.splitContainer2.Size = new System.Drawing.Size(916, 475);
            this.splitContainer2.SplitterDistance = 575;
            this.splitContainer2.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 652);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sbInfo);
            this.Controls.Add(this.splHor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "Title Comes from Assembly Info";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuView;
        private System.Windows.Forms.MenuItem mnuModules;
        private System.Windows.Forms.MenuItem MenuItem2;
        private System.Windows.Forms.MenuItem mnuRefresh;
        private System.Windows.Forms.MenuItem mnuHelp;
        private System.Windows.Forms.MenuItem mnuAbout;
        private System.Windows.Forms.ListView lvProcesses;
        private System.Windows.Forms.ColumnHeader chProcessName;
        private System.Windows.Forms.ColumnHeader chPID;
        private System.Windows.Forms.ColumnHeader chProcessorTime;
        private System.Windows.Forms.ColumnHeader chPriv;
        private System.Windows.Forms.ColumnHeader chUser;
        private System.Windows.Forms.ContextMenu ctxView;
        private System.Windows.Forms.MenuItem ctxViewMods;
        private System.Windows.Forms.MenuItem MenuItem1;
        private System.Windows.Forms.MenuItem ctxRefresh;
        private System.Windows.Forms.ListView lvProcessDetail;
        private System.Windows.Forms.ColumnHeader chItem;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.StatusBar sbInfo;
        private System.Windows.Forms.Splitter splHor;
        private System.Windows.Forms.ListView lvThreads;
        private System.Windows.Forms.ColumnHeader chThreads;
        private System.Windows.Forms.ColumnHeader chBasePri;
        private System.Windows.Forms.ColumnHeader chCurrentPri;
        private System.Windows.Forms.ColumnHeader chPriBoostEnabled;
        private System.Windows.Forms.ColumnHeader chPriLevel;
        private System.Windows.Forms.ColumnHeader chPrivProcTime;
        private System.Windows.Forms.ColumnHeader chStartAddress;
        private System.Windows.Forms.ColumnHeader chStartTime;
        private System.Windows.Forms.ColumnHeader chTotalProcTime;
        private System.Windows.Forms.ColumnHeader chUserProcTime;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}

