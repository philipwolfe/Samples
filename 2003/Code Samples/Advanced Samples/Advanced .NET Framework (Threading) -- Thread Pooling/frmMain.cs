//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class frmMain : System.Windows.Forms.Form
{
	protected AutoResetEvent autoResetEvent1 = new AutoResetEvent(false);
	protected ManualResetEvent manualResetEvent1 = new ManualResetEvent(false);
	protected Mutex mutex1 = new Mutex(true);
	protected ProcessGroup processGroup1;
	protected ProcessGroup processGroup2;
	protected ProcessGroup processGroup3;
	protected TimerGroup timerGroup1;
	protected TimerGroup timerGroup2;

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    
#region " Windows Form Designer generated code "

    public frmMain() 
	{
        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.
        AssemblyInfo ainfo = new AssemblyInfo();
        this.Text = ainfo.Title;
        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
    }

    //Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing) {
        if (disposing) {
            if (components != null) {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components = null;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    private System.Windows.Forms.MainMenu mnuMain;

    private System.Windows.Forms.MenuItem mnuFile;

    private System.Windows.Forms.MenuItem mnuExit;

    private System.Windows.Forms.MenuItem mnuHelp;

    private System.Windows.Forms.MenuItem mnuAbout;

    private System.Windows.Forms.TabControl MainTabControl;

    private System.Windows.Forms.GroupBox Process1GroupBox;

    private System.Windows.Forms.Button btnNonthreaded;

    private System.Windows.Forms.Label lblProcess1Active;

    private System.Windows.Forms.GroupBox Process2GroupBox;

    private System.Windows.Forms.Label lblProcess2Active;

    private System.Windows.Forms.GroupBox Process3GroupBox;

    private System.Windows.Forms.Label lblProcess3Active;

    private System.Windows.Forms.Label lblThreadNumber;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Label lblProcess1ThreadNum;

    private System.Windows.Forms.Label lblProcess2ThreadNum;

    private System.Windows.Forms.Label lblProcess3ThreadNum;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label lblProcess1IsPoolThread;

    private System.Windows.Forms.Label lblProcess2IsPoolThread;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.Label lblProcess3IsPoolThread;

    private System.Windows.Forms.Label Label7;

    private System.Windows.Forms.Button btnThreaded;

    private System.Windows.Forms.Button btnThreadPool;

    private System.Windows.Forms.TabPage FunctionTabPage;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.CheckBox chkHighIntensity;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.Label lblSecondsElapsed;

    private System.Windows.Forms.TabPage TimersTabPage;

    private System.Windows.Forms.GroupBox Timer1GroupBox;

    private System.Windows.Forms.Label lblTimer1IsThreadPool;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.Label lblTimer1ThreadNum;

    private System.Windows.Forms.Label Label11;

    private System.Windows.Forms.Label lblTimer1Output;

    private System.Windows.Forms.GroupBox Timer2GroupBox;

    private System.Windows.Forms.Label Label14;

    private System.Windows.Forms.Label lblTimer2ThreadNum;

    private System.Windows.Forms.Label Label16;

    private System.Windows.Forms.Label lblTimer2Output;

    private System.Windows.Forms.Label lblTimer2IsThreadPool;

    private System.Windows.Forms.Button btnStartStop;

    private System.Windows.Forms.TabPage SyncObjectsTabPage;

    private System.Windows.Forms.GroupBox MutexGroupBox;

    private System.Windows.Forms.Label Label10;

    private System.Windows.Forms.Label lblMutexThreadNum;

    private System.Windows.Forms.Label Label13;

    private System.Windows.Forms.Label lblMutexThreadStatus;

    private System.Windows.Forms.GroupBox ManualEventGroupBox;

    private System.Windows.Forms.Label Label18;

    private System.Windows.Forms.Label Label20;

    private System.Windows.Forms.GroupBox AutoEventGroupBox;

    private System.Windows.Forms.Label Label23;

    private System.Windows.Forms.Label Label25;

    private System.Windows.Forms.Button btnWaitForMutex;

    private System.Windows.Forms.Button btnReleaseMutex;

    private System.Windows.Forms.Label lblMutexIsPoolThread;

    private System.Windows.Forms.Label lblManualEventIsPoolThread;

    private System.Windows.Forms.Label lblManualEventThreadNum;

    private System.Windows.Forms.Label lblManualEventThreadStatus;

    private System.Windows.Forms.Button btnWaitForManualEvent;

    private System.Windows.Forms.Button btnSetManualEvent;

    private System.Windows.Forms.Label lblAutoEventIsPoolThread;

    private System.Windows.Forms.Label lblAutoEventThreadNum;

    private System.Windows.Forms.Label lblAutoEventStatus;

    private System.Windows.Forms.Button btnWaitForAutoEvent;

    private System.Windows.Forms.Button btnSetAutoEvent;

    private System.Windows.Forms.Button btnSetReleaseAll;

    private System.Windows.Forms.Label lblInstructions;

    private System.Windows.Forms.Label lblInstructions2;

    private System.Windows.Forms.Label lblInstructions3;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.MainTabControl = new System.Windows.Forms.TabControl();
		this.FunctionTabPage = new System.Windows.Forms.TabPage();
		this.lblInstructions = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.chkHighIntensity = new System.Windows.Forms.CheckBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.btnThreadPool = new System.Windows.Forms.Button();
		this.btnThreaded = new System.Windows.Forms.Button();
		this.lblSecondsElapsed = new System.Windows.Forms.Label();
		this.Process3GroupBox = new System.Windows.Forms.GroupBox();
		this.lblProcess3IsPoolThread = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.lblProcess3ThreadNum = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.lblProcess3Active = new System.Windows.Forms.Label();
		this.Process2GroupBox = new System.Windows.Forms.GroupBox();
		this.lblProcess2IsPoolThread = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.lblProcess2ThreadNum = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.lblProcess2Active = new System.Windows.Forms.Label();
		this.btnNonthreaded = new System.Windows.Forms.Button();
		this.Process1GroupBox = new System.Windows.Forms.GroupBox();
		this.lblProcess1IsPoolThread = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.lblProcess1ThreadNum = new System.Windows.Forms.Label();
		this.lblThreadNumber = new System.Windows.Forms.Label();
		this.lblProcess1Active = new System.Windows.Forms.Label();
		this.TimersTabPage = new System.Windows.Forms.TabPage();
		this.lblInstructions2 = new System.Windows.Forms.Label();
		this.btnStartStop = new System.Windows.Forms.Button();
		this.Timer2GroupBox = new System.Windows.Forms.GroupBox();
		this.lblTimer2IsThreadPool = new System.Windows.Forms.Label();
		this.Label14 = new System.Windows.Forms.Label();
		this.lblTimer2ThreadNum = new System.Windows.Forms.Label();
		this.Label16 = new System.Windows.Forms.Label();
		this.lblTimer2Output = new System.Windows.Forms.Label();
		this.Timer1GroupBox = new System.Windows.Forms.GroupBox();
		this.lblTimer1IsThreadPool = new System.Windows.Forms.Label();
		this.Label9 = new System.Windows.Forms.Label();
		this.lblTimer1ThreadNum = new System.Windows.Forms.Label();
		this.Label11 = new System.Windows.Forms.Label();
		this.lblTimer1Output = new System.Windows.Forms.Label();
		this.SyncObjectsTabPage = new System.Windows.Forms.TabPage();
		this.lblInstructions3 = new System.Windows.Forms.Label();
		this.btnSetReleaseAll = new System.Windows.Forms.Button();
		this.btnSetAutoEvent = new System.Windows.Forms.Button();
		this.btnWaitForAutoEvent = new System.Windows.Forms.Button();
		this.btnSetManualEvent = new System.Windows.Forms.Button();
		this.btnWaitForManualEvent = new System.Windows.Forms.Button();
		this.btnReleaseMutex = new System.Windows.Forms.Button();
		this.btnWaitForMutex = new System.Windows.Forms.Button();
		this.AutoEventGroupBox = new System.Windows.Forms.GroupBox();
		this.lblAutoEventIsPoolThread = new System.Windows.Forms.Label();
		this.Label23 = new System.Windows.Forms.Label();
		this.lblAutoEventThreadNum = new System.Windows.Forms.Label();
		this.Label25 = new System.Windows.Forms.Label();
		this.lblAutoEventStatus = new System.Windows.Forms.Label();
		this.ManualEventGroupBox = new System.Windows.Forms.GroupBox();
		this.lblManualEventIsPoolThread = new System.Windows.Forms.Label();
		this.Label18 = new System.Windows.Forms.Label();
		this.lblManualEventThreadNum = new System.Windows.Forms.Label();
		this.Label20 = new System.Windows.Forms.Label();
		this.lblManualEventThreadStatus = new System.Windows.Forms.Label();
		this.MutexGroupBox = new System.Windows.Forms.GroupBox();
		this.lblMutexIsPoolThread = new System.Windows.Forms.Label();
		this.Label10 = new System.Windows.Forms.Label();
		this.lblMutexThreadNum = new System.Windows.Forms.Label();
		this.Label13 = new System.Windows.Forms.Label();
		this.lblMutexThreadStatus = new System.Windows.Forms.Label();
		this.MainTabControl.SuspendLayout();
		this.FunctionTabPage.SuspendLayout();
		this.Process3GroupBox.SuspendLayout();
		this.Process2GroupBox.SuspendLayout();
		this.Process1GroupBox.SuspendLayout();
		this.TimersTabPage.SuspendLayout();
		this.Timer2GroupBox.SuspendLayout();
		this.Timer1GroupBox.SuspendLayout();
		this.SyncObjectsTabPage.SuspendLayout();
		this.AutoEventGroupBox.SuspendLayout();
		this.ManualEventGroupBox.SuspendLayout();
		this.MutexGroupBox.SuspendLayout();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuHelp});
		this.mnuMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mnuMain.RightToLeft")));
		// 
		// mnuFile
		// 
		this.mnuFile.Enabled = ((bool)(resources.GetObject("mnuFile.Enabled")));
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuExit});
		this.mnuFile.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuFile.Shortcut")));
		this.mnuFile.ShowShortcut = ((bool)(resources.GetObject("mnuFile.ShowShortcut")));
		this.mnuFile.Text = resources.GetString("mnuFile.Text");
		this.mnuFile.Visible = ((bool)(resources.GetObject("mnuFile.Visible")));
		// 
		// mnuExit
		// 
		this.mnuExit.Enabled = ((bool)(resources.GetObject("mnuExit.Enabled")));
		this.mnuExit.Index = 0;
		this.mnuExit.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuExit.Shortcut")));
		this.mnuExit.ShowShortcut = ((bool)(resources.GetObject("mnuExit.ShowShortcut")));
		this.mnuExit.Text = resources.GetString("mnuExit.Text");
		this.mnuExit.Visible = ((bool)(resources.GetObject("mnuExit.Visible")));
		this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Enabled = ((bool)(resources.GetObject("mnuHelp.Enabled")));
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuAbout});
		this.mnuHelp.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuHelp.Shortcut")));
		this.mnuHelp.ShowShortcut = ((bool)(resources.GetObject("mnuHelp.ShowShortcut")));
		this.mnuHelp.Text = resources.GetString("mnuHelp.Text");
		this.mnuHelp.Visible = ((bool)(resources.GetObject("mnuHelp.Visible")));
		// 
		// mnuAbout
		// 
		this.mnuAbout.Enabled = ((bool)(resources.GetObject("mnuAbout.Enabled")));
		this.mnuAbout.Index = 0;
		this.mnuAbout.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuAbout.Shortcut")));
		this.mnuAbout.ShowShortcut = ((bool)(resources.GetObject("mnuAbout.ShowShortcut")));
		this.mnuAbout.Text = resources.GetString("mnuAbout.Text");
		this.mnuAbout.Visible = ((bool)(resources.GetObject("mnuAbout.Visible")));
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
		// 
		// MainTabControl
		// 
		this.MainTabControl.AccessibleDescription = resources.GetString("MainTabControl.AccessibleDescription");
		this.MainTabControl.AccessibleName = resources.GetString("MainTabControl.AccessibleName");
		this.MainTabControl.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("MainTabControl.Alignment")));
		this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("MainTabControl.Anchor")));
		this.MainTabControl.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("MainTabControl.Appearance")));
		this.MainTabControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainTabControl.BackgroundImage")));
		this.MainTabControl.Controls.Add(this.FunctionTabPage);
		this.MainTabControl.Controls.Add(this.TimersTabPage);
		this.MainTabControl.Controls.Add(this.SyncObjectsTabPage);
		this.MainTabControl.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("MainTabControl.Dock")));
		this.MainTabControl.Enabled = ((bool)(resources.GetObject("MainTabControl.Enabled")));
		this.MainTabControl.Font = ((System.Drawing.Font)(resources.GetObject("MainTabControl.Font")));
		this.MainTabControl.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("MainTabControl.ImeMode")));
		this.MainTabControl.ItemSize = ((System.Drawing.Size)(resources.GetObject("MainTabControl.ItemSize")));
		this.MainTabControl.Location = ((System.Drawing.Point)(resources.GetObject("MainTabControl.Location")));
		this.MainTabControl.Name = "MainTabControl";
		this.MainTabControl.Padding = ((System.Drawing.Point)(resources.GetObject("MainTabControl.Padding")));
		this.MainTabControl.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("MainTabControl.RightToLeft")));
		this.MainTabControl.SelectedIndex = 0;
		this.MainTabControl.ShowToolTips = ((bool)(resources.GetObject("MainTabControl.ShowToolTips")));
		this.MainTabControl.Size = ((System.Drawing.Size)(resources.GetObject("MainTabControl.Size")));
		this.MainTabControl.TabIndex = ((int)(resources.GetObject("MainTabControl.TabIndex")));
		this.MainTabControl.Text = resources.GetString("MainTabControl.Text");
		this.MainTabControl.Visible = ((bool)(resources.GetObject("MainTabControl.Visible")));
		// 
		// FunctionTabPage
		// 
		this.FunctionTabPage.AccessibleDescription = resources.GetString("FunctionTabPage.AccessibleDescription");
		this.FunctionTabPage.AccessibleName = resources.GetString("FunctionTabPage.AccessibleName");
		this.FunctionTabPage.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("FunctionTabPage.Anchor")));
		this.FunctionTabPage.AutoScroll = ((bool)(resources.GetObject("FunctionTabPage.AutoScroll")));
		this.FunctionTabPage.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("FunctionTabPage.AutoScrollMargin")));
		this.FunctionTabPage.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("FunctionTabPage.AutoScrollMinSize")));
		this.FunctionTabPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FunctionTabPage.BackgroundImage")));
		this.FunctionTabPage.Controls.Add(this.lblInstructions);
		this.FunctionTabPage.Controls.Add(this.Label8);
		this.FunctionTabPage.Controls.Add(this.chkHighIntensity);
		this.FunctionTabPage.Controls.Add(this.Label6);
		this.FunctionTabPage.Controls.Add(this.btnThreadPool);
		this.FunctionTabPage.Controls.Add(this.btnThreaded);
		this.FunctionTabPage.Controls.Add(this.lblSecondsElapsed);
		this.FunctionTabPage.Controls.Add(this.Process3GroupBox);
		this.FunctionTabPage.Controls.Add(this.Process2GroupBox);
		this.FunctionTabPage.Controls.Add(this.btnNonthreaded);
		this.FunctionTabPage.Controls.Add(this.Process1GroupBox);
		this.FunctionTabPage.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("FunctionTabPage.Dock")));
		this.FunctionTabPage.Enabled = ((bool)(resources.GetObject("FunctionTabPage.Enabled")));
		this.FunctionTabPage.Font = ((System.Drawing.Font)(resources.GetObject("FunctionTabPage.Font")));
		this.FunctionTabPage.ImageIndex = ((int)(resources.GetObject("FunctionTabPage.ImageIndex")));
		this.FunctionTabPage.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("FunctionTabPage.ImeMode")));
		this.FunctionTabPage.Location = ((System.Drawing.Point)(resources.GetObject("FunctionTabPage.Location")));
		this.FunctionTabPage.Name = "FunctionTabPage";
		this.FunctionTabPage.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("FunctionTabPage.RightToLeft")));
		this.FunctionTabPage.Size = ((System.Drawing.Size)(resources.GetObject("FunctionTabPage.Size")));
		this.FunctionTabPage.TabIndex = ((int)(resources.GetObject("FunctionTabPage.TabIndex")));
		this.FunctionTabPage.Text = resources.GetString("FunctionTabPage.Text");
		this.FunctionTabPage.ToolTipText = resources.GetString("FunctionTabPage.ToolTipText");
		this.FunctionTabPage.Visible = ((bool)(resources.GetObject("FunctionTabPage.Visible")));
		this.FunctionTabPage.Click += new System.EventHandler(this.FunctionTabPage_Click);
		// 
		// lblInstructions
		// 
		this.lblInstructions.AccessibleDescription = resources.GetString("lblInstructions.AccessibleDescription");
		this.lblInstructions.AccessibleName = resources.GetString("lblInstructions.AccessibleName");
		this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblInstructions.Anchor")));
		this.lblInstructions.AutoSize = ((bool)(resources.GetObject("lblInstructions.AutoSize")));
		this.lblInstructions.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblInstructions.Dock")));
		this.lblInstructions.Enabled = ((bool)(resources.GetObject("lblInstructions.Enabled")));
		this.lblInstructions.Font = ((System.Drawing.Font)(resources.GetObject("lblInstructions.Font")));
		this.lblInstructions.ForeColor = System.Drawing.Color.Blue;
		this.lblInstructions.Image = ((System.Drawing.Image)(resources.GetObject("lblInstructions.Image")));
		this.lblInstructions.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions.ImageAlign")));
		this.lblInstructions.ImageIndex = ((int)(resources.GetObject("lblInstructions.ImageIndex")));
		this.lblInstructions.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblInstructions.ImeMode")));
		this.lblInstructions.Location = ((System.Drawing.Point)(resources.GetObject("lblInstructions.Location")));
		this.lblInstructions.Name = "lblInstructions";
		this.lblInstructions.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblInstructions.RightToLeft")));
		this.lblInstructions.Size = ((System.Drawing.Size)(resources.GetObject("lblInstructions.Size")));
		this.lblInstructions.TabIndex = ((int)(resources.GetObject("lblInstructions.TabIndex")));
		this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
		this.lblInstructions.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions.TextAlign")));
		this.lblInstructions.Visible = ((bool)(resources.GetObject("lblInstructions.Visible")));
		// 
		// Label8
		// 
		this.Label8.AccessibleDescription = resources.GetString("Label8.AccessibleDescription");
		this.Label8.AccessibleName = resources.GetString("Label8.AccessibleName");
		this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label8.Anchor")));
		this.Label8.AutoSize = ((bool)(resources.GetObject("Label8.AutoSize")));
		this.Label8.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label8.Dock")));
		this.Label8.Enabled = ((bool)(resources.GetObject("Label8.Enabled")));
		this.Label8.Font = ((System.Drawing.Font)(resources.GetObject("Label8.Font")));
		this.Label8.Image = ((System.Drawing.Image)(resources.GetObject("Label8.Image")));
		this.Label8.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label8.ImageAlign")));
		this.Label8.ImageIndex = ((int)(resources.GetObject("Label8.ImageIndex")));
		this.Label8.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label8.ImeMode")));
		this.Label8.Location = ((System.Drawing.Point)(resources.GetObject("Label8.Location")));
		this.Label8.Name = "Label8";
		this.Label8.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label8.RightToLeft")));
		this.Label8.Size = ((System.Drawing.Size)(resources.GetObject("Label8.Size")));
		this.Label8.TabIndex = ((int)(resources.GetObject("Label8.TabIndex")));
		this.Label8.Text = resources.GetString("Label8.Text");
		this.Label8.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label8.TextAlign")));
		this.Label8.Visible = ((bool)(resources.GetObject("Label8.Visible")));
		// 
		// chkHighIntensity
		// 
		this.chkHighIntensity.AccessibleDescription = resources.GetString("chkHighIntensity.AccessibleDescription");
		this.chkHighIntensity.AccessibleName = resources.GetString("chkHighIntensity.AccessibleName");
		this.chkHighIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkHighIntensity.Anchor")));
		this.chkHighIntensity.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkHighIntensity.Appearance")));
		this.chkHighIntensity.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkHighIntensity.BackgroundImage")));
		this.chkHighIntensity.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkHighIntensity.CheckAlign")));
		this.chkHighIntensity.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkHighIntensity.Dock")));
		this.chkHighIntensity.Enabled = ((bool)(resources.GetObject("chkHighIntensity.Enabled")));
		this.chkHighIntensity.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkHighIntensity.FlatStyle")));
		this.chkHighIntensity.Font = ((System.Drawing.Font)(resources.GetObject("chkHighIntensity.Font")));
		this.chkHighIntensity.Image = ((System.Drawing.Image)(resources.GetObject("chkHighIntensity.Image")));
		this.chkHighIntensity.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkHighIntensity.ImageAlign")));
		this.chkHighIntensity.ImageIndex = ((int)(resources.GetObject("chkHighIntensity.ImageIndex")));
		this.chkHighIntensity.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkHighIntensity.ImeMode")));
		this.chkHighIntensity.Location = ((System.Drawing.Point)(resources.GetObject("chkHighIntensity.Location")));
		this.chkHighIntensity.Name = "chkHighIntensity";
		this.chkHighIntensity.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkHighIntensity.RightToLeft")));
		this.chkHighIntensity.Size = ((System.Drawing.Size)(resources.GetObject("chkHighIntensity.Size")));
		this.chkHighIntensity.TabIndex = ((int)(resources.GetObject("chkHighIntensity.TabIndex")));
		this.chkHighIntensity.Text = resources.GetString("chkHighIntensity.Text");
		this.chkHighIntensity.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkHighIntensity.TextAlign")));
		this.chkHighIntensity.Visible = ((bool)(resources.GetObject("chkHighIntensity.Visible")));
		this.chkHighIntensity.CheckedChanged += new System.EventHandler(this.chkHighIntensity_CheckedChanged);
		// 
		// Label6
		// 
		this.Label6.AccessibleDescription = resources.GetString("Label6.AccessibleDescription");
		this.Label6.AccessibleName = resources.GetString("Label6.AccessibleName");
		this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label6.Anchor")));
		this.Label6.AutoSize = ((bool)(resources.GetObject("Label6.AutoSize")));
		this.Label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label6.Dock")));
		this.Label6.Enabled = ((bool)(resources.GetObject("Label6.Enabled")));
		this.Label6.Font = ((System.Drawing.Font)(resources.GetObject("Label6.Font")));
		this.Label6.Image = ((System.Drawing.Image)(resources.GetObject("Label6.Image")));
		this.Label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label6.ImageAlign")));
		this.Label6.ImageIndex = ((int)(resources.GetObject("Label6.ImageIndex")));
		this.Label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label6.ImeMode")));
		this.Label6.Location = ((System.Drawing.Point)(resources.GetObject("Label6.Location")));
		this.Label6.Name = "Label6";
		this.Label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label6.RightToLeft")));
		this.Label6.Size = ((System.Drawing.Size)(resources.GetObject("Label6.Size")));
		this.Label6.TabIndex = ((int)(resources.GetObject("Label6.TabIndex")));
		this.Label6.Text = resources.GetString("Label6.Text");
		this.Label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label6.TextAlign")));
		this.Label6.Visible = ((bool)(resources.GetObject("Label6.Visible")));
		// 
		// btnThreadPool
		// 
		this.btnThreadPool.AccessibleDescription = resources.GetString("btnThreadPool.AccessibleDescription");
		this.btnThreadPool.AccessibleName = resources.GetString("btnThreadPool.AccessibleName");
		this.btnThreadPool.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnThreadPool.Anchor")));
		this.btnThreadPool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThreadPool.BackgroundImage")));
		this.btnThreadPool.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnThreadPool.Dock")));
		this.btnThreadPool.Enabled = ((bool)(resources.GetObject("btnThreadPool.Enabled")));
		this.btnThreadPool.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnThreadPool.FlatStyle")));
		this.btnThreadPool.Font = ((System.Drawing.Font)(resources.GetObject("btnThreadPool.Font")));
		this.btnThreadPool.Image = ((System.Drawing.Image)(resources.GetObject("btnThreadPool.Image")));
		this.btnThreadPool.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnThreadPool.ImageAlign")));
		this.btnThreadPool.ImageIndex = ((int)(resources.GetObject("btnThreadPool.ImageIndex")));
		this.btnThreadPool.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnThreadPool.ImeMode")));
		this.btnThreadPool.Location = ((System.Drawing.Point)(resources.GetObject("btnThreadPool.Location")));
		this.btnThreadPool.Name = "btnThreadPool";
		this.btnThreadPool.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnThreadPool.RightToLeft")));
		this.btnThreadPool.Size = ((System.Drawing.Size)(resources.GetObject("btnThreadPool.Size")));
		this.btnThreadPool.TabIndex = ((int)(resources.GetObject("btnThreadPool.TabIndex")));
		this.btnThreadPool.Text = resources.GetString("btnThreadPool.Text");
		this.btnThreadPool.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnThreadPool.TextAlign")));
		this.btnThreadPool.Visible = ((bool)(resources.GetObject("btnThreadPool.Visible")));
		this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
		// 
		// btnThreaded
		// 
		this.btnThreaded.AccessibleDescription = resources.GetString("btnThreaded.AccessibleDescription");
		this.btnThreaded.AccessibleName = resources.GetString("btnThreaded.AccessibleName");
		this.btnThreaded.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnThreaded.Anchor")));
		this.btnThreaded.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThreaded.BackgroundImage")));
		this.btnThreaded.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnThreaded.Dock")));
		this.btnThreaded.Enabled = ((bool)(resources.GetObject("btnThreaded.Enabled")));
		this.btnThreaded.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnThreaded.FlatStyle")));
		this.btnThreaded.Font = ((System.Drawing.Font)(resources.GetObject("btnThreaded.Font")));
		this.btnThreaded.Image = ((System.Drawing.Image)(resources.GetObject("btnThreaded.Image")));
		this.btnThreaded.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnThreaded.ImageAlign")));
		this.btnThreaded.ImageIndex = ((int)(resources.GetObject("btnThreaded.ImageIndex")));
		this.btnThreaded.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnThreaded.ImeMode")));
		this.btnThreaded.Location = ((System.Drawing.Point)(resources.GetObject("btnThreaded.Location")));
		this.btnThreaded.Name = "btnThreaded";
		this.btnThreaded.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnThreaded.RightToLeft")));
		this.btnThreaded.Size = ((System.Drawing.Size)(resources.GetObject("btnThreaded.Size")));
		this.btnThreaded.TabIndex = ((int)(resources.GetObject("btnThreaded.TabIndex")));
		this.btnThreaded.Text = resources.GetString("btnThreaded.Text");
		this.btnThreaded.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnThreaded.TextAlign")));
		this.btnThreaded.Visible = ((bool)(resources.GetObject("btnThreaded.Visible")));
		this.btnThreaded.Click += new System.EventHandler(this.btnThreaded_Click);
		// 
		// lblSecondsElapsed
		// 
		this.lblSecondsElapsed.AccessibleDescription = resources.GetString("lblSecondsElapsed.AccessibleDescription");
		this.lblSecondsElapsed.AccessibleName = resources.GetString("lblSecondsElapsed.AccessibleName");
		this.lblSecondsElapsed.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblSecondsElapsed.Anchor")));
		this.lblSecondsElapsed.AutoSize = ((bool)(resources.GetObject("lblSecondsElapsed.AutoSize")));
		this.lblSecondsElapsed.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblSecondsElapsed.Dock")));
		this.lblSecondsElapsed.Enabled = ((bool)(resources.GetObject("lblSecondsElapsed.Enabled")));
		this.lblSecondsElapsed.Font = ((System.Drawing.Font)(resources.GetObject("lblSecondsElapsed.Font")));
		this.lblSecondsElapsed.Image = ((System.Drawing.Image)(resources.GetObject("lblSecondsElapsed.Image")));
		this.lblSecondsElapsed.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblSecondsElapsed.ImageAlign")));
		this.lblSecondsElapsed.ImageIndex = ((int)(resources.GetObject("lblSecondsElapsed.ImageIndex")));
		this.lblSecondsElapsed.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblSecondsElapsed.ImeMode")));
		this.lblSecondsElapsed.Location = ((System.Drawing.Point)(resources.GetObject("lblSecondsElapsed.Location")));
		this.lblSecondsElapsed.Name = "lblSecondsElapsed";
		this.lblSecondsElapsed.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblSecondsElapsed.RightToLeft")));
		this.lblSecondsElapsed.Size = ((System.Drawing.Size)(resources.GetObject("lblSecondsElapsed.Size")));
		this.lblSecondsElapsed.TabIndex = ((int)(resources.GetObject("lblSecondsElapsed.TabIndex")));
		this.lblSecondsElapsed.Text = resources.GetString("lblSecondsElapsed.Text");
		this.lblSecondsElapsed.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblSecondsElapsed.TextAlign")));
		this.lblSecondsElapsed.Visible = ((bool)(resources.GetObject("lblSecondsElapsed.Visible")));
		// 
		// Process3GroupBox
		// 
		this.Process3GroupBox.AccessibleDescription = resources.GetString("Process3GroupBox.AccessibleDescription");
		this.Process3GroupBox.AccessibleName = resources.GetString("Process3GroupBox.AccessibleName");
		this.Process3GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Process3GroupBox.Anchor")));
		this.Process3GroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Process3GroupBox.BackgroundImage")));
		this.Process3GroupBox.Controls.Add(this.lblProcess3IsPoolThread);
		this.Process3GroupBox.Controls.Add(this.Label7);
		this.Process3GroupBox.Controls.Add(this.lblProcess3ThreadNum);
		this.Process3GroupBox.Controls.Add(this.Label2);
		this.Process3GroupBox.Controls.Add(this.lblProcess3Active);
		this.Process3GroupBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Process3GroupBox.Dock")));
		this.Process3GroupBox.Enabled = ((bool)(resources.GetObject("Process3GroupBox.Enabled")));
		this.Process3GroupBox.Font = ((System.Drawing.Font)(resources.GetObject("Process3GroupBox.Font")));
		this.Process3GroupBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Process3GroupBox.ImeMode")));
		this.Process3GroupBox.Location = ((System.Drawing.Point)(resources.GetObject("Process3GroupBox.Location")));
		this.Process3GroupBox.Name = "Process3GroupBox";
		this.Process3GroupBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Process3GroupBox.RightToLeft")));
		this.Process3GroupBox.Size = ((System.Drawing.Size)(resources.GetObject("Process3GroupBox.Size")));
		this.Process3GroupBox.TabIndex = ((int)(resources.GetObject("Process3GroupBox.TabIndex")));
		this.Process3GroupBox.TabStop = false;
		this.Process3GroupBox.Text = resources.GetString("Process3GroupBox.Text");
		this.Process3GroupBox.Visible = ((bool)(resources.GetObject("Process3GroupBox.Visible")));
		// 
		// lblProcess3IsPoolThread
		// 
		this.lblProcess3IsPoolThread.AccessibleDescription = resources.GetString("lblProcess3IsPoolThread.AccessibleDescription");
		this.lblProcess3IsPoolThread.AccessibleName = resources.GetString("lblProcess3IsPoolThread.AccessibleName");
		this.lblProcess3IsPoolThread.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblProcess3IsPoolThread.Anchor")));
		this.lblProcess3IsPoolThread.AutoSize = ((bool)(resources.GetObject("lblProcess3IsPoolThread.AutoSize")));
		this.lblProcess3IsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblProcess3IsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblProcess3IsPoolThread.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblProcess3IsPoolThread.Dock")));
		this.lblProcess3IsPoolThread.Enabled = ((bool)(resources.GetObject("lblProcess3IsPoolThread.Enabled")));
		this.lblProcess3IsPoolThread.Font = ((System.Drawing.Font)(resources.GetObject("lblProcess3IsPoolThread.Font")));
		this.lblProcess3IsPoolThread.Image = ((System.Drawing.Image)(resources.GetObject("lblProcess3IsPoolThread.Image")));
		this.lblProcess3IsPoolThread.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess3IsPoolThread.ImageAlign")));
		this.lblProcess3IsPoolThread.ImageIndex = ((int)(resources.GetObject("lblProcess3IsPoolThread.ImageIndex")));
		this.lblProcess3IsPoolThread.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblProcess3IsPoolThread.ImeMode")));
		this.lblProcess3IsPoolThread.Location = ((System.Drawing.Point)(resources.GetObject("lblProcess3IsPoolThread.Location")));
		this.lblProcess3IsPoolThread.Name = "lblProcess3IsPoolThread";
		this.lblProcess3IsPoolThread.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblProcess3IsPoolThread.RightToLeft")));
		this.lblProcess3IsPoolThread.Size = ((System.Drawing.Size)(resources.GetObject("lblProcess3IsPoolThread.Size")));
		this.lblProcess3IsPoolThread.TabIndex = ((int)(resources.GetObject("lblProcess3IsPoolThread.TabIndex")));
		this.lblProcess3IsPoolThread.Text = resources.GetString("lblProcess3IsPoolThread.Text");
		this.lblProcess3IsPoolThread.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess3IsPoolThread.TextAlign")));
		this.lblProcess3IsPoolThread.Visible = ((bool)(resources.GetObject("lblProcess3IsPoolThread.Visible")));
		// 
		// Label7
		// 
		this.Label7.AccessibleDescription = resources.GetString("Label7.AccessibleDescription");
		this.Label7.AccessibleName = resources.GetString("Label7.AccessibleName");
		this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label7.Anchor")));
		this.Label7.AutoSize = ((bool)(resources.GetObject("Label7.AutoSize")));
		this.Label7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label7.Dock")));
		this.Label7.Enabled = ((bool)(resources.GetObject("Label7.Enabled")));
		this.Label7.Font = ((System.Drawing.Font)(resources.GetObject("Label7.Font")));
		this.Label7.Image = ((System.Drawing.Image)(resources.GetObject("Label7.Image")));
		this.Label7.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label7.ImageAlign")));
		this.Label7.ImageIndex = ((int)(resources.GetObject("Label7.ImageIndex")));
		this.Label7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label7.ImeMode")));
		this.Label7.Location = ((System.Drawing.Point)(resources.GetObject("Label7.Location")));
		this.Label7.Name = "Label7";
		this.Label7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label7.RightToLeft")));
		this.Label7.Size = ((System.Drawing.Size)(resources.GetObject("Label7.Size")));
		this.Label7.TabIndex = ((int)(resources.GetObject("Label7.TabIndex")));
		this.Label7.Text = resources.GetString("Label7.Text");
		this.Label7.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label7.TextAlign")));
		this.Label7.Visible = ((bool)(resources.GetObject("Label7.Visible")));
		// 
		// lblProcess3ThreadNum
		// 
		this.lblProcess3ThreadNum.AccessibleDescription = resources.GetString("lblProcess3ThreadNum.AccessibleDescription");
		this.lblProcess3ThreadNum.AccessibleName = resources.GetString("lblProcess3ThreadNum.AccessibleName");
		this.lblProcess3ThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblProcess3ThreadNum.Anchor")));
		this.lblProcess3ThreadNum.AutoSize = ((bool)(resources.GetObject("lblProcess3ThreadNum.AutoSize")));
		this.lblProcess3ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblProcess3ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblProcess3ThreadNum.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblProcess3ThreadNum.Dock")));
		this.lblProcess3ThreadNum.Enabled = ((bool)(resources.GetObject("lblProcess3ThreadNum.Enabled")));
		this.lblProcess3ThreadNum.Font = ((System.Drawing.Font)(resources.GetObject("lblProcess3ThreadNum.Font")));
		this.lblProcess3ThreadNum.Image = ((System.Drawing.Image)(resources.GetObject("lblProcess3ThreadNum.Image")));
		this.lblProcess3ThreadNum.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess3ThreadNum.ImageAlign")));
		this.lblProcess3ThreadNum.ImageIndex = ((int)(resources.GetObject("lblProcess3ThreadNum.ImageIndex")));
		this.lblProcess3ThreadNum.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblProcess3ThreadNum.ImeMode")));
		this.lblProcess3ThreadNum.Location = ((System.Drawing.Point)(resources.GetObject("lblProcess3ThreadNum.Location")));
		this.lblProcess3ThreadNum.Name = "lblProcess3ThreadNum";
		this.lblProcess3ThreadNum.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblProcess3ThreadNum.RightToLeft")));
		this.lblProcess3ThreadNum.Size = ((System.Drawing.Size)(resources.GetObject("lblProcess3ThreadNum.Size")));
		this.lblProcess3ThreadNum.TabIndex = ((int)(resources.GetObject("lblProcess3ThreadNum.TabIndex")));
		this.lblProcess3ThreadNum.Text = resources.GetString("lblProcess3ThreadNum.Text");
		this.lblProcess3ThreadNum.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess3ThreadNum.TextAlign")));
		this.lblProcess3ThreadNum.Visible = ((bool)(resources.GetObject("lblProcess3ThreadNum.Visible")));
		// 
		// Label2
		// 
		this.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription");
		this.Label2.AccessibleName = resources.GetString("Label2.AccessibleName");
		this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label2.Anchor")));
		this.Label2.AutoSize = ((bool)(resources.GetObject("Label2.AutoSize")));
		this.Label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label2.Dock")));
		this.Label2.Enabled = ((bool)(resources.GetObject("Label2.Enabled")));
		this.Label2.Font = ((System.Drawing.Font)(resources.GetObject("Label2.Font")));
		this.Label2.Image = ((System.Drawing.Image)(resources.GetObject("Label2.Image")));
		this.Label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label2.ImageAlign")));
		this.Label2.ImageIndex = ((int)(resources.GetObject("Label2.ImageIndex")));
		this.Label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label2.ImeMode")));
		this.Label2.Location = ((System.Drawing.Point)(resources.GetObject("Label2.Location")));
		this.Label2.Name = "Label2";
		this.Label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label2.RightToLeft")));
		this.Label2.Size = ((System.Drawing.Size)(resources.GetObject("Label2.Size")));
		this.Label2.TabIndex = ((int)(resources.GetObject("Label2.TabIndex")));
		this.Label2.Text = resources.GetString("Label2.Text");
		this.Label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label2.TextAlign")));
		this.Label2.Visible = ((bool)(resources.GetObject("Label2.Visible")));
		// 
		// lblProcess3Active
		// 
		this.lblProcess3Active.AccessibleDescription = resources.GetString("lblProcess3Active.AccessibleDescription");
		this.lblProcess3Active.AccessibleName = resources.GetString("lblProcess3Active.AccessibleName");
		this.lblProcess3Active.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblProcess3Active.Anchor")));
		this.lblProcess3Active.AutoSize = ((bool)(resources.GetObject("lblProcess3Active.AutoSize")));
		this.lblProcess3Active.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblProcess3Active.Dock")));
		this.lblProcess3Active.Enabled = ((bool)(resources.GetObject("lblProcess3Active.Enabled")));
		this.lblProcess3Active.Font = ((System.Drawing.Font)(resources.GetObject("lblProcess3Active.Font")));
		this.lblProcess3Active.ForeColor = System.Drawing.Color.Red;
		this.lblProcess3Active.Image = ((System.Drawing.Image)(resources.GetObject("lblProcess3Active.Image")));
		this.lblProcess3Active.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess3Active.ImageAlign")));
		this.lblProcess3Active.ImageIndex = ((int)(resources.GetObject("lblProcess3Active.ImageIndex")));
		this.lblProcess3Active.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblProcess3Active.ImeMode")));
		this.lblProcess3Active.Location = ((System.Drawing.Point)(resources.GetObject("lblProcess3Active.Location")));
		this.lblProcess3Active.Name = "lblProcess3Active";
		this.lblProcess3Active.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblProcess3Active.RightToLeft")));
		this.lblProcess3Active.Size = ((System.Drawing.Size)(resources.GetObject("lblProcess3Active.Size")));
		this.lblProcess3Active.TabIndex = ((int)(resources.GetObject("lblProcess3Active.TabIndex")));
		this.lblProcess3Active.Text = resources.GetString("lblProcess3Active.Text");
		this.lblProcess3Active.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess3Active.TextAlign")));
		this.lblProcess3Active.Visible = ((bool)(resources.GetObject("lblProcess3Active.Visible")));
		// 
		// Process2GroupBox
		// 
		this.Process2GroupBox.AccessibleDescription = resources.GetString("Process2GroupBox.AccessibleDescription");
		this.Process2GroupBox.AccessibleName = resources.GetString("Process2GroupBox.AccessibleName");
		this.Process2GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Process2GroupBox.Anchor")));
		this.Process2GroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Process2GroupBox.BackgroundImage")));
		this.Process2GroupBox.Controls.Add(this.lblProcess2IsPoolThread);
		this.Process2GroupBox.Controls.Add(this.Label5);
		this.Process2GroupBox.Controls.Add(this.lblProcess2ThreadNum);
		this.Process2GroupBox.Controls.Add(this.Label1);
		this.Process2GroupBox.Controls.Add(this.lblProcess2Active);
		this.Process2GroupBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Process2GroupBox.Dock")));
		this.Process2GroupBox.Enabled = ((bool)(resources.GetObject("Process2GroupBox.Enabled")));
		this.Process2GroupBox.Font = ((System.Drawing.Font)(resources.GetObject("Process2GroupBox.Font")));
		this.Process2GroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
		this.Process2GroupBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Process2GroupBox.ImeMode")));
		this.Process2GroupBox.Location = ((System.Drawing.Point)(resources.GetObject("Process2GroupBox.Location")));
		this.Process2GroupBox.Name = "Process2GroupBox";
		this.Process2GroupBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Process2GroupBox.RightToLeft")));
		this.Process2GroupBox.Size = ((System.Drawing.Size)(resources.GetObject("Process2GroupBox.Size")));
		this.Process2GroupBox.TabIndex = ((int)(resources.GetObject("Process2GroupBox.TabIndex")));
		this.Process2GroupBox.TabStop = false;
		this.Process2GroupBox.Text = resources.GetString("Process2GroupBox.Text");
		this.Process2GroupBox.Visible = ((bool)(resources.GetObject("Process2GroupBox.Visible")));
		// 
		// lblProcess2IsPoolThread
		// 
		this.lblProcess2IsPoolThread.AccessibleDescription = resources.GetString("lblProcess2IsPoolThread.AccessibleDescription");
		this.lblProcess2IsPoolThread.AccessibleName = resources.GetString("lblProcess2IsPoolThread.AccessibleName");
		this.lblProcess2IsPoolThread.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblProcess2IsPoolThread.Anchor")));
		this.lblProcess2IsPoolThread.AutoSize = ((bool)(resources.GetObject("lblProcess2IsPoolThread.AutoSize")));
		this.lblProcess2IsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblProcess2IsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblProcess2IsPoolThread.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblProcess2IsPoolThread.Dock")));
		this.lblProcess2IsPoolThread.Enabled = ((bool)(resources.GetObject("lblProcess2IsPoolThread.Enabled")));
		this.lblProcess2IsPoolThread.Font = ((System.Drawing.Font)(resources.GetObject("lblProcess2IsPoolThread.Font")));
		this.lblProcess2IsPoolThread.Image = ((System.Drawing.Image)(resources.GetObject("lblProcess2IsPoolThread.Image")));
		this.lblProcess2IsPoolThread.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess2IsPoolThread.ImageAlign")));
		this.lblProcess2IsPoolThread.ImageIndex = ((int)(resources.GetObject("lblProcess2IsPoolThread.ImageIndex")));
		this.lblProcess2IsPoolThread.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblProcess2IsPoolThread.ImeMode")));
		this.lblProcess2IsPoolThread.Location = ((System.Drawing.Point)(resources.GetObject("lblProcess2IsPoolThread.Location")));
		this.lblProcess2IsPoolThread.Name = "lblProcess2IsPoolThread";
		this.lblProcess2IsPoolThread.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblProcess2IsPoolThread.RightToLeft")));
		this.lblProcess2IsPoolThread.Size = ((System.Drawing.Size)(resources.GetObject("lblProcess2IsPoolThread.Size")));
		this.lblProcess2IsPoolThread.TabIndex = ((int)(resources.GetObject("lblProcess2IsPoolThread.TabIndex")));
		this.lblProcess2IsPoolThread.Text = resources.GetString("lblProcess2IsPoolThread.Text");
		this.lblProcess2IsPoolThread.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess2IsPoolThread.TextAlign")));
		this.lblProcess2IsPoolThread.Visible = ((bool)(resources.GetObject("lblProcess2IsPoolThread.Visible")));
		// 
		// Label5
		// 
		this.Label5.AccessibleDescription = resources.GetString("Label5.AccessibleDescription");
		this.Label5.AccessibleName = resources.GetString("Label5.AccessibleName");
		this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label5.Anchor")));
		this.Label5.AutoSize = ((bool)(resources.GetObject("Label5.AutoSize")));
		this.Label5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label5.Dock")));
		this.Label5.Enabled = ((bool)(resources.GetObject("Label5.Enabled")));
		this.Label5.Font = ((System.Drawing.Font)(resources.GetObject("Label5.Font")));
		this.Label5.Image = ((System.Drawing.Image)(resources.GetObject("Label5.Image")));
		this.Label5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label5.ImageAlign")));
		this.Label5.ImageIndex = ((int)(resources.GetObject("Label5.ImageIndex")));
		this.Label5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label5.ImeMode")));
		this.Label5.Location = ((System.Drawing.Point)(resources.GetObject("Label5.Location")));
		this.Label5.Name = "Label5";
		this.Label5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label5.RightToLeft")));
		this.Label5.Size = ((System.Drawing.Size)(resources.GetObject("Label5.Size")));
		this.Label5.TabIndex = ((int)(resources.GetObject("Label5.TabIndex")));
		this.Label5.Text = resources.GetString("Label5.Text");
		this.Label5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label5.TextAlign")));
		this.Label5.Visible = ((bool)(resources.GetObject("Label5.Visible")));
		// 
		// lblProcess2ThreadNum
		// 
		this.lblProcess2ThreadNum.AccessibleDescription = resources.GetString("lblProcess2ThreadNum.AccessibleDescription");
		this.lblProcess2ThreadNum.AccessibleName = resources.GetString("lblProcess2ThreadNum.AccessibleName");
		this.lblProcess2ThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblProcess2ThreadNum.Anchor")));
		this.lblProcess2ThreadNum.AutoSize = ((bool)(resources.GetObject("lblProcess2ThreadNum.AutoSize")));
		this.lblProcess2ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblProcess2ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblProcess2ThreadNum.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblProcess2ThreadNum.Dock")));
		this.lblProcess2ThreadNum.Enabled = ((bool)(resources.GetObject("lblProcess2ThreadNum.Enabled")));
		this.lblProcess2ThreadNum.Font = ((System.Drawing.Font)(resources.GetObject("lblProcess2ThreadNum.Font")));
		this.lblProcess2ThreadNum.Image = ((System.Drawing.Image)(resources.GetObject("lblProcess2ThreadNum.Image")));
		this.lblProcess2ThreadNum.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess2ThreadNum.ImageAlign")));
		this.lblProcess2ThreadNum.ImageIndex = ((int)(resources.GetObject("lblProcess2ThreadNum.ImageIndex")));
		this.lblProcess2ThreadNum.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblProcess2ThreadNum.ImeMode")));
		this.lblProcess2ThreadNum.Location = ((System.Drawing.Point)(resources.GetObject("lblProcess2ThreadNum.Location")));
		this.lblProcess2ThreadNum.Name = "lblProcess2ThreadNum";
		this.lblProcess2ThreadNum.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblProcess2ThreadNum.RightToLeft")));
		this.lblProcess2ThreadNum.Size = ((System.Drawing.Size)(resources.GetObject("lblProcess2ThreadNum.Size")));
		this.lblProcess2ThreadNum.TabIndex = ((int)(resources.GetObject("lblProcess2ThreadNum.TabIndex")));
		this.lblProcess2ThreadNum.Text = resources.GetString("lblProcess2ThreadNum.Text");
		this.lblProcess2ThreadNum.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess2ThreadNum.TextAlign")));
		this.lblProcess2ThreadNum.Visible = ((bool)(resources.GetObject("lblProcess2ThreadNum.Visible")));
		// 
		// Label1
		// 
		this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");
		this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");
		this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label1.Anchor")));
		this.Label1.AutoSize = ((bool)(resources.GetObject("Label1.AutoSize")));
		this.Label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label1.Dock")));
		this.Label1.Enabled = ((bool)(resources.GetObject("Label1.Enabled")));
		this.Label1.Font = ((System.Drawing.Font)(resources.GetObject("Label1.Font")));
		this.Label1.Image = ((System.Drawing.Image)(resources.GetObject("Label1.Image")));
		this.Label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.ImageAlign")));
		this.Label1.ImageIndex = ((int)(resources.GetObject("Label1.ImageIndex")));
		this.Label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label1.ImeMode")));
		this.Label1.Location = ((System.Drawing.Point)(resources.GetObject("Label1.Location")));
		this.Label1.Name = "Label1";
		this.Label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label1.RightToLeft")));
		this.Label1.Size = ((System.Drawing.Size)(resources.GetObject("Label1.Size")));
		this.Label1.TabIndex = ((int)(resources.GetObject("Label1.TabIndex")));
		this.Label1.Text = resources.GetString("Label1.Text");
		this.Label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.TextAlign")));
		this.Label1.Visible = ((bool)(resources.GetObject("Label1.Visible")));
		// 
		// lblProcess2Active
		// 
		this.lblProcess2Active.AccessibleDescription = resources.GetString("lblProcess2Active.AccessibleDescription");
		this.lblProcess2Active.AccessibleName = resources.GetString("lblProcess2Active.AccessibleName");
		this.lblProcess2Active.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblProcess2Active.Anchor")));
		this.lblProcess2Active.AutoSize = ((bool)(resources.GetObject("lblProcess2Active.AutoSize")));
		this.lblProcess2Active.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblProcess2Active.Dock")));
		this.lblProcess2Active.Enabled = ((bool)(resources.GetObject("lblProcess2Active.Enabled")));
		this.lblProcess2Active.Font = ((System.Drawing.Font)(resources.GetObject("lblProcess2Active.Font")));
		this.lblProcess2Active.ForeColor = System.Drawing.Color.Red;
		this.lblProcess2Active.Image = ((System.Drawing.Image)(resources.GetObject("lblProcess2Active.Image")));
		this.lblProcess2Active.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess2Active.ImageAlign")));
		this.lblProcess2Active.ImageIndex = ((int)(resources.GetObject("lblProcess2Active.ImageIndex")));
		this.lblProcess2Active.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblProcess2Active.ImeMode")));
		this.lblProcess2Active.Location = ((System.Drawing.Point)(resources.GetObject("lblProcess2Active.Location")));
		this.lblProcess2Active.Name = "lblProcess2Active";
		this.lblProcess2Active.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblProcess2Active.RightToLeft")));
		this.lblProcess2Active.Size = ((System.Drawing.Size)(resources.GetObject("lblProcess2Active.Size")));
		this.lblProcess2Active.TabIndex = ((int)(resources.GetObject("lblProcess2Active.TabIndex")));
		this.lblProcess2Active.Text = resources.GetString("lblProcess2Active.Text");
		this.lblProcess2Active.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess2Active.TextAlign")));
		this.lblProcess2Active.Visible = ((bool)(resources.GetObject("lblProcess2Active.Visible")));
		// 
		// btnNonthreaded
		// 
		this.btnNonthreaded.AccessibleDescription = resources.GetString("btnNonthreaded.AccessibleDescription");
		this.btnNonthreaded.AccessibleName = resources.GetString("btnNonthreaded.AccessibleName");
		this.btnNonthreaded.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnNonthreaded.Anchor")));
		this.btnNonthreaded.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNonthreaded.BackgroundImage")));
		this.btnNonthreaded.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnNonthreaded.Dock")));
		this.btnNonthreaded.Enabled = ((bool)(resources.GetObject("btnNonthreaded.Enabled")));
		this.btnNonthreaded.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnNonthreaded.FlatStyle")));
		this.btnNonthreaded.Font = ((System.Drawing.Font)(resources.GetObject("btnNonthreaded.Font")));
		this.btnNonthreaded.Image = ((System.Drawing.Image)(resources.GetObject("btnNonthreaded.Image")));
		this.btnNonthreaded.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnNonthreaded.ImageAlign")));
		this.btnNonthreaded.ImageIndex = ((int)(resources.GetObject("btnNonthreaded.ImageIndex")));
		this.btnNonthreaded.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnNonthreaded.ImeMode")));
		this.btnNonthreaded.Location = ((System.Drawing.Point)(resources.GetObject("btnNonthreaded.Location")));
		this.btnNonthreaded.Name = "btnNonthreaded";
		this.btnNonthreaded.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnNonthreaded.RightToLeft")));
		this.btnNonthreaded.Size = ((System.Drawing.Size)(resources.GetObject("btnNonthreaded.Size")));
		this.btnNonthreaded.TabIndex = ((int)(resources.GetObject("btnNonthreaded.TabIndex")));
		this.btnNonthreaded.Text = resources.GetString("btnNonthreaded.Text");
		this.btnNonthreaded.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnNonthreaded.TextAlign")));
		this.btnNonthreaded.Visible = ((bool)(resources.GetObject("btnNonthreaded.Visible")));
		this.btnNonthreaded.Click += new System.EventHandler(this.btnNonthreaded_Click);
		// 
		// Process1GroupBox
		// 
		this.Process1GroupBox.AccessibleDescription = resources.GetString("Process1GroupBox.AccessibleDescription");
		this.Process1GroupBox.AccessibleName = resources.GetString("Process1GroupBox.AccessibleName");
		this.Process1GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Process1GroupBox.Anchor")));
		this.Process1GroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Process1GroupBox.BackgroundImage")));
		this.Process1GroupBox.Controls.Add(this.lblProcess1IsPoolThread);
		this.Process1GroupBox.Controls.Add(this.Label3);
		this.Process1GroupBox.Controls.Add(this.lblProcess1ThreadNum);
		this.Process1GroupBox.Controls.Add(this.lblThreadNumber);
		this.Process1GroupBox.Controls.Add(this.lblProcess1Active);
		this.Process1GroupBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Process1GroupBox.Dock")));
		this.Process1GroupBox.Enabled = ((bool)(resources.GetObject("Process1GroupBox.Enabled")));
		this.Process1GroupBox.Font = ((System.Drawing.Font)(resources.GetObject("Process1GroupBox.Font")));
		this.Process1GroupBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Process1GroupBox.ImeMode")));
		this.Process1GroupBox.Location = ((System.Drawing.Point)(resources.GetObject("Process1GroupBox.Location")));
		this.Process1GroupBox.Name = "Process1GroupBox";
		this.Process1GroupBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Process1GroupBox.RightToLeft")));
		this.Process1GroupBox.Size = ((System.Drawing.Size)(resources.GetObject("Process1GroupBox.Size")));
		this.Process1GroupBox.TabIndex = ((int)(resources.GetObject("Process1GroupBox.TabIndex")));
		this.Process1GroupBox.TabStop = false;
		this.Process1GroupBox.Text = resources.GetString("Process1GroupBox.Text");
		this.Process1GroupBox.Visible = ((bool)(resources.GetObject("Process1GroupBox.Visible")));
		// 
		// lblProcess1IsPoolThread
		// 
		this.lblProcess1IsPoolThread.AccessibleDescription = resources.GetString("lblProcess1IsPoolThread.AccessibleDescription");
		this.lblProcess1IsPoolThread.AccessibleName = resources.GetString("lblProcess1IsPoolThread.AccessibleName");
		this.lblProcess1IsPoolThread.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblProcess1IsPoolThread.Anchor")));
		this.lblProcess1IsPoolThread.AutoSize = ((bool)(resources.GetObject("lblProcess1IsPoolThread.AutoSize")));
		this.lblProcess1IsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblProcess1IsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblProcess1IsPoolThread.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblProcess1IsPoolThread.Dock")));
		this.lblProcess1IsPoolThread.Enabled = ((bool)(resources.GetObject("lblProcess1IsPoolThread.Enabled")));
		this.lblProcess1IsPoolThread.Font = ((System.Drawing.Font)(resources.GetObject("lblProcess1IsPoolThread.Font")));
		this.lblProcess1IsPoolThread.Image = ((System.Drawing.Image)(resources.GetObject("lblProcess1IsPoolThread.Image")));
		this.lblProcess1IsPoolThread.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess1IsPoolThread.ImageAlign")));
		this.lblProcess1IsPoolThread.ImageIndex = ((int)(resources.GetObject("lblProcess1IsPoolThread.ImageIndex")));
		this.lblProcess1IsPoolThread.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblProcess1IsPoolThread.ImeMode")));
		this.lblProcess1IsPoolThread.Location = ((System.Drawing.Point)(resources.GetObject("lblProcess1IsPoolThread.Location")));
		this.lblProcess1IsPoolThread.Name = "lblProcess1IsPoolThread";
		this.lblProcess1IsPoolThread.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblProcess1IsPoolThread.RightToLeft")));
		this.lblProcess1IsPoolThread.Size = ((System.Drawing.Size)(resources.GetObject("lblProcess1IsPoolThread.Size")));
		this.lblProcess1IsPoolThread.TabIndex = ((int)(resources.GetObject("lblProcess1IsPoolThread.TabIndex")));
		this.lblProcess1IsPoolThread.Text = resources.GetString("lblProcess1IsPoolThread.Text");
		this.lblProcess1IsPoolThread.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess1IsPoolThread.TextAlign")));
		this.lblProcess1IsPoolThread.Visible = ((bool)(resources.GetObject("lblProcess1IsPoolThread.Visible")));
		// 
		// Label3
		// 
		this.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription");
		this.Label3.AccessibleName = resources.GetString("Label3.AccessibleName");
		this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label3.Anchor")));
		this.Label3.AutoSize = ((bool)(resources.GetObject("Label3.AutoSize")));
		this.Label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label3.Dock")));
		this.Label3.Enabled = ((bool)(resources.GetObject("Label3.Enabled")));
		this.Label3.Font = ((System.Drawing.Font)(resources.GetObject("Label3.Font")));
		this.Label3.Image = ((System.Drawing.Image)(resources.GetObject("Label3.Image")));
		this.Label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label3.ImageAlign")));
		this.Label3.ImageIndex = ((int)(resources.GetObject("Label3.ImageIndex")));
		this.Label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label3.ImeMode")));
		this.Label3.Location = ((System.Drawing.Point)(resources.GetObject("Label3.Location")));
		this.Label3.Name = "Label3";
		this.Label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label3.RightToLeft")));
		this.Label3.Size = ((System.Drawing.Size)(resources.GetObject("Label3.Size")));
		this.Label3.TabIndex = ((int)(resources.GetObject("Label3.TabIndex")));
		this.Label3.Text = resources.GetString("Label3.Text");
		this.Label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label3.TextAlign")));
		this.Label3.Visible = ((bool)(resources.GetObject("Label3.Visible")));
		// 
		// lblProcess1ThreadNum
		// 
		this.lblProcess1ThreadNum.AccessibleDescription = resources.GetString("lblProcess1ThreadNum.AccessibleDescription");
		this.lblProcess1ThreadNum.AccessibleName = resources.GetString("lblProcess1ThreadNum.AccessibleName");
		this.lblProcess1ThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblProcess1ThreadNum.Anchor")));
		this.lblProcess1ThreadNum.AutoSize = ((bool)(resources.GetObject("lblProcess1ThreadNum.AutoSize")));
		this.lblProcess1ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblProcess1ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblProcess1ThreadNum.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblProcess1ThreadNum.Dock")));
		this.lblProcess1ThreadNum.Enabled = ((bool)(resources.GetObject("lblProcess1ThreadNum.Enabled")));
		this.lblProcess1ThreadNum.Font = ((System.Drawing.Font)(resources.GetObject("lblProcess1ThreadNum.Font")));
		this.lblProcess1ThreadNum.Image = ((System.Drawing.Image)(resources.GetObject("lblProcess1ThreadNum.Image")));
		this.lblProcess1ThreadNum.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess1ThreadNum.ImageAlign")));
		this.lblProcess1ThreadNum.ImageIndex = ((int)(resources.GetObject("lblProcess1ThreadNum.ImageIndex")));
		this.lblProcess1ThreadNum.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblProcess1ThreadNum.ImeMode")));
		this.lblProcess1ThreadNum.Location = ((System.Drawing.Point)(resources.GetObject("lblProcess1ThreadNum.Location")));
		this.lblProcess1ThreadNum.Name = "lblProcess1ThreadNum";
		this.lblProcess1ThreadNum.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblProcess1ThreadNum.RightToLeft")));
		this.lblProcess1ThreadNum.Size = ((System.Drawing.Size)(resources.GetObject("lblProcess1ThreadNum.Size")));
		this.lblProcess1ThreadNum.TabIndex = ((int)(resources.GetObject("lblProcess1ThreadNum.TabIndex")));
		this.lblProcess1ThreadNum.Text = resources.GetString("lblProcess1ThreadNum.Text");
		this.lblProcess1ThreadNum.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess1ThreadNum.TextAlign")));
		this.lblProcess1ThreadNum.Visible = ((bool)(resources.GetObject("lblProcess1ThreadNum.Visible")));
		// 
		// lblThreadNumber
		// 
		this.lblThreadNumber.AccessibleDescription = resources.GetString("lblThreadNumber.AccessibleDescription");
		this.lblThreadNumber.AccessibleName = resources.GetString("lblThreadNumber.AccessibleName");
		this.lblThreadNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblThreadNumber.Anchor")));
		this.lblThreadNumber.AutoSize = ((bool)(resources.GetObject("lblThreadNumber.AutoSize")));
		this.lblThreadNumber.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblThreadNumber.Dock")));
		this.lblThreadNumber.Enabled = ((bool)(resources.GetObject("lblThreadNumber.Enabled")));
		this.lblThreadNumber.Font = ((System.Drawing.Font)(resources.GetObject("lblThreadNumber.Font")));
		this.lblThreadNumber.Image = ((System.Drawing.Image)(resources.GetObject("lblThreadNumber.Image")));
		this.lblThreadNumber.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblThreadNumber.ImageAlign")));
		this.lblThreadNumber.ImageIndex = ((int)(resources.GetObject("lblThreadNumber.ImageIndex")));
		this.lblThreadNumber.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblThreadNumber.ImeMode")));
		this.lblThreadNumber.Location = ((System.Drawing.Point)(resources.GetObject("lblThreadNumber.Location")));
		this.lblThreadNumber.Name = "lblThreadNumber";
		this.lblThreadNumber.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblThreadNumber.RightToLeft")));
		this.lblThreadNumber.Size = ((System.Drawing.Size)(resources.GetObject("lblThreadNumber.Size")));
		this.lblThreadNumber.TabIndex = ((int)(resources.GetObject("lblThreadNumber.TabIndex")));
		this.lblThreadNumber.Text = resources.GetString("lblThreadNumber.Text");
		this.lblThreadNumber.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblThreadNumber.TextAlign")));
		this.lblThreadNumber.Visible = ((bool)(resources.GetObject("lblThreadNumber.Visible")));
		// 
		// lblProcess1Active
		// 
		this.lblProcess1Active.AccessibleDescription = resources.GetString("lblProcess1Active.AccessibleDescription");
		this.lblProcess1Active.AccessibleName = resources.GetString("lblProcess1Active.AccessibleName");
		this.lblProcess1Active.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblProcess1Active.Anchor")));
		this.lblProcess1Active.AutoSize = ((bool)(resources.GetObject("lblProcess1Active.AutoSize")));
		this.lblProcess1Active.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblProcess1Active.Dock")));
		this.lblProcess1Active.Enabled = ((bool)(resources.GetObject("lblProcess1Active.Enabled")));
		this.lblProcess1Active.Font = ((System.Drawing.Font)(resources.GetObject("lblProcess1Active.Font")));
		this.lblProcess1Active.ForeColor = System.Drawing.Color.Red;
		this.lblProcess1Active.Image = ((System.Drawing.Image)(resources.GetObject("lblProcess1Active.Image")));
		this.lblProcess1Active.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess1Active.ImageAlign")));
		this.lblProcess1Active.ImageIndex = ((int)(resources.GetObject("lblProcess1Active.ImageIndex")));
		this.lblProcess1Active.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblProcess1Active.ImeMode")));
		this.lblProcess1Active.Location = ((System.Drawing.Point)(resources.GetObject("lblProcess1Active.Location")));
		this.lblProcess1Active.Name = "lblProcess1Active";
		this.lblProcess1Active.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblProcess1Active.RightToLeft")));
		this.lblProcess1Active.Size = ((System.Drawing.Size)(resources.GetObject("lblProcess1Active.Size")));
		this.lblProcess1Active.TabIndex = ((int)(resources.GetObject("lblProcess1Active.TabIndex")));
		this.lblProcess1Active.Text = resources.GetString("lblProcess1Active.Text");
		this.lblProcess1Active.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblProcess1Active.TextAlign")));
		this.lblProcess1Active.Visible = ((bool)(resources.GetObject("lblProcess1Active.Visible")));
		// 
		// TimersTabPage
		// 
		this.TimersTabPage.AccessibleDescription = resources.GetString("TimersTabPage.AccessibleDescription");
		this.TimersTabPage.AccessibleName = resources.GetString("TimersTabPage.AccessibleName");
		this.TimersTabPage.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("TimersTabPage.Anchor")));
		this.TimersTabPage.AutoScroll = ((bool)(resources.GetObject("TimersTabPage.AutoScroll")));
		this.TimersTabPage.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("TimersTabPage.AutoScrollMargin")));
		this.TimersTabPage.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("TimersTabPage.AutoScrollMinSize")));
		this.TimersTabPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TimersTabPage.BackgroundImage")));
		this.TimersTabPage.Controls.Add(this.lblInstructions2);
		this.TimersTabPage.Controls.Add(this.btnStartStop);
		this.TimersTabPage.Controls.Add(this.Timer2GroupBox);
		this.TimersTabPage.Controls.Add(this.Timer1GroupBox);
		this.TimersTabPage.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("TimersTabPage.Dock")));
		this.TimersTabPage.Enabled = ((bool)(resources.GetObject("TimersTabPage.Enabled")));
		this.TimersTabPage.Font = ((System.Drawing.Font)(resources.GetObject("TimersTabPage.Font")));
		this.TimersTabPage.ImageIndex = ((int)(resources.GetObject("TimersTabPage.ImageIndex")));
		this.TimersTabPage.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("TimersTabPage.ImeMode")));
		this.TimersTabPage.Location = ((System.Drawing.Point)(resources.GetObject("TimersTabPage.Location")));
		this.TimersTabPage.Name = "TimersTabPage";
		this.TimersTabPage.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("TimersTabPage.RightToLeft")));
		this.TimersTabPage.Size = ((System.Drawing.Size)(resources.GetObject("TimersTabPage.Size")));
		this.TimersTabPage.TabIndex = ((int)(resources.GetObject("TimersTabPage.TabIndex")));
		this.TimersTabPage.Text = resources.GetString("TimersTabPage.Text");
		this.TimersTabPage.ToolTipText = resources.GetString("TimersTabPage.ToolTipText");
		this.TimersTabPage.Visible = ((bool)(resources.GetObject("TimersTabPage.Visible")));
		this.TimersTabPage.Click += new System.EventHandler(this.TimersTabPage_Click);
		// 
		// lblInstructions2
		// 
		this.lblInstructions2.AccessibleDescription = resources.GetString("lblInstructions2.AccessibleDescription");
		this.lblInstructions2.AccessibleName = resources.GetString("lblInstructions2.AccessibleName");
		this.lblInstructions2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblInstructions2.Anchor")));
		this.lblInstructions2.AutoSize = ((bool)(resources.GetObject("lblInstructions2.AutoSize")));
		this.lblInstructions2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblInstructions2.Dock")));
		this.lblInstructions2.Enabled = ((bool)(resources.GetObject("lblInstructions2.Enabled")));
		this.lblInstructions2.Font = ((System.Drawing.Font)(resources.GetObject("lblInstructions2.Font")));
		this.lblInstructions2.ForeColor = System.Drawing.Color.Blue;
		this.lblInstructions2.Image = ((System.Drawing.Image)(resources.GetObject("lblInstructions2.Image")));
		this.lblInstructions2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions2.ImageAlign")));
		this.lblInstructions2.ImageIndex = ((int)(resources.GetObject("lblInstructions2.ImageIndex")));
		this.lblInstructions2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblInstructions2.ImeMode")));
		this.lblInstructions2.Location = ((System.Drawing.Point)(resources.GetObject("lblInstructions2.Location")));
		this.lblInstructions2.Name = "lblInstructions2";
		this.lblInstructions2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblInstructions2.RightToLeft")));
		this.lblInstructions2.Size = ((System.Drawing.Size)(resources.GetObject("lblInstructions2.Size")));
		this.lblInstructions2.TabIndex = ((int)(resources.GetObject("lblInstructions2.TabIndex")));
		this.lblInstructions2.Text = resources.GetString("lblInstructions2.Text");
		this.lblInstructions2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions2.TextAlign")));
		this.lblInstructions2.Visible = ((bool)(resources.GetObject("lblInstructions2.Visible")));
		// 
		// btnStartStop
		// 
		this.btnStartStop.AccessibleDescription = resources.GetString("btnStartStop.AccessibleDescription");
		this.btnStartStop.AccessibleName = resources.GetString("btnStartStop.AccessibleName");
		this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnStartStop.Anchor")));
		this.btnStartStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStartStop.BackgroundImage")));
		this.btnStartStop.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnStartStop.Dock")));
		this.btnStartStop.Enabled = ((bool)(resources.GetObject("btnStartStop.Enabled")));
		this.btnStartStop.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnStartStop.FlatStyle")));
		this.btnStartStop.Font = ((System.Drawing.Font)(resources.GetObject("btnStartStop.Font")));
		this.btnStartStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStartStop.Image")));
		this.btnStartStop.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnStartStop.ImageAlign")));
		this.btnStartStop.ImageIndex = ((int)(resources.GetObject("btnStartStop.ImageIndex")));
		this.btnStartStop.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnStartStop.ImeMode")));
		this.btnStartStop.Location = ((System.Drawing.Point)(resources.GetObject("btnStartStop.Location")));
		this.btnStartStop.Name = "btnStartStop";
		this.btnStartStop.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnStartStop.RightToLeft")));
		this.btnStartStop.Size = ((System.Drawing.Size)(resources.GetObject("btnStartStop.Size")));
		this.btnStartStop.TabIndex = ((int)(resources.GetObject("btnStartStop.TabIndex")));
		this.btnStartStop.Text = resources.GetString("btnStartStop.Text");
		this.btnStartStop.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnStartStop.TextAlign")));
		this.btnStartStop.Visible = ((bool)(resources.GetObject("btnStartStop.Visible")));
		this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
		// 
		// Timer2GroupBox
		// 
		this.Timer2GroupBox.AccessibleDescription = resources.GetString("Timer2GroupBox.AccessibleDescription");
		this.Timer2GroupBox.AccessibleName = resources.GetString("Timer2GroupBox.AccessibleName");
		this.Timer2GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Timer2GroupBox.Anchor")));
		this.Timer2GroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Timer2GroupBox.BackgroundImage")));
		this.Timer2GroupBox.Controls.Add(this.lblTimer2IsThreadPool);
		this.Timer2GroupBox.Controls.Add(this.Label14);
		this.Timer2GroupBox.Controls.Add(this.lblTimer2ThreadNum);
		this.Timer2GroupBox.Controls.Add(this.Label16);
		this.Timer2GroupBox.Controls.Add(this.lblTimer2Output);
		this.Timer2GroupBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Timer2GroupBox.Dock")));
		this.Timer2GroupBox.Enabled = ((bool)(resources.GetObject("Timer2GroupBox.Enabled")));
		this.Timer2GroupBox.Font = ((System.Drawing.Font)(resources.GetObject("Timer2GroupBox.Font")));
		this.Timer2GroupBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Timer2GroupBox.ImeMode")));
		this.Timer2GroupBox.Location = ((System.Drawing.Point)(resources.GetObject("Timer2GroupBox.Location")));
		this.Timer2GroupBox.Name = "Timer2GroupBox";
		this.Timer2GroupBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Timer2GroupBox.RightToLeft")));
		this.Timer2GroupBox.Size = ((System.Drawing.Size)(resources.GetObject("Timer2GroupBox.Size")));
		this.Timer2GroupBox.TabIndex = ((int)(resources.GetObject("Timer2GroupBox.TabIndex")));
		this.Timer2GroupBox.TabStop = false;
		this.Timer2GroupBox.Text = resources.GetString("Timer2GroupBox.Text");
		this.Timer2GroupBox.Visible = ((bool)(resources.GetObject("Timer2GroupBox.Visible")));
		// 
		// lblTimer2IsThreadPool
		// 
		this.lblTimer2IsThreadPool.AccessibleDescription = resources.GetString("lblTimer2IsThreadPool.AccessibleDescription");
		this.lblTimer2IsThreadPool.AccessibleName = resources.GetString("lblTimer2IsThreadPool.AccessibleName");
		this.lblTimer2IsThreadPool.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblTimer2IsThreadPool.Anchor")));
		this.lblTimer2IsThreadPool.AutoSize = ((bool)(resources.GetObject("lblTimer2IsThreadPool.AutoSize")));
		this.lblTimer2IsThreadPool.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblTimer2IsThreadPool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTimer2IsThreadPool.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblTimer2IsThreadPool.Dock")));
		this.lblTimer2IsThreadPool.Enabled = ((bool)(resources.GetObject("lblTimer2IsThreadPool.Enabled")));
		this.lblTimer2IsThreadPool.Font = ((System.Drawing.Font)(resources.GetObject("lblTimer2IsThreadPool.Font")));
		this.lblTimer2IsThreadPool.Image = ((System.Drawing.Image)(resources.GetObject("lblTimer2IsThreadPool.Image")));
		this.lblTimer2IsThreadPool.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer2IsThreadPool.ImageAlign")));
		this.lblTimer2IsThreadPool.ImageIndex = ((int)(resources.GetObject("lblTimer2IsThreadPool.ImageIndex")));
		this.lblTimer2IsThreadPool.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblTimer2IsThreadPool.ImeMode")));
		this.lblTimer2IsThreadPool.Location = ((System.Drawing.Point)(resources.GetObject("lblTimer2IsThreadPool.Location")));
		this.lblTimer2IsThreadPool.Name = "lblTimer2IsThreadPool";
		this.lblTimer2IsThreadPool.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblTimer2IsThreadPool.RightToLeft")));
		this.lblTimer2IsThreadPool.Size = ((System.Drawing.Size)(resources.GetObject("lblTimer2IsThreadPool.Size")));
		this.lblTimer2IsThreadPool.TabIndex = ((int)(resources.GetObject("lblTimer2IsThreadPool.TabIndex")));
		this.lblTimer2IsThreadPool.Text = resources.GetString("lblTimer2IsThreadPool.Text");
		this.lblTimer2IsThreadPool.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer2IsThreadPool.TextAlign")));
		this.lblTimer2IsThreadPool.Visible = ((bool)(resources.GetObject("lblTimer2IsThreadPool.Visible")));
		// 
		// Label14
		// 
		this.Label14.AccessibleDescription = resources.GetString("Label14.AccessibleDescription");
		this.Label14.AccessibleName = resources.GetString("Label14.AccessibleName");
		this.Label14.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label14.Anchor")));
		this.Label14.AutoSize = ((bool)(resources.GetObject("Label14.AutoSize")));
		this.Label14.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label14.Dock")));
		this.Label14.Enabled = ((bool)(resources.GetObject("Label14.Enabled")));
		this.Label14.Font = ((System.Drawing.Font)(resources.GetObject("Label14.Font")));
		this.Label14.Image = ((System.Drawing.Image)(resources.GetObject("Label14.Image")));
		this.Label14.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label14.ImageAlign")));
		this.Label14.ImageIndex = ((int)(resources.GetObject("Label14.ImageIndex")));
		this.Label14.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label14.ImeMode")));
		this.Label14.Location = ((System.Drawing.Point)(resources.GetObject("Label14.Location")));
		this.Label14.Name = "Label14";
		this.Label14.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label14.RightToLeft")));
		this.Label14.Size = ((System.Drawing.Size)(resources.GetObject("Label14.Size")));
		this.Label14.TabIndex = ((int)(resources.GetObject("Label14.TabIndex")));
		this.Label14.Text = resources.GetString("Label14.Text");
		this.Label14.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label14.TextAlign")));
		this.Label14.Visible = ((bool)(resources.GetObject("Label14.Visible")));
		// 
		// lblTimer2ThreadNum
		// 
		this.lblTimer2ThreadNum.AccessibleDescription = resources.GetString("lblTimer2ThreadNum.AccessibleDescription");
		this.lblTimer2ThreadNum.AccessibleName = resources.GetString("lblTimer2ThreadNum.AccessibleName");
		this.lblTimer2ThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblTimer2ThreadNum.Anchor")));
		this.lblTimer2ThreadNum.AutoSize = ((bool)(resources.GetObject("lblTimer2ThreadNum.AutoSize")));
		this.lblTimer2ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblTimer2ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTimer2ThreadNum.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblTimer2ThreadNum.Dock")));
		this.lblTimer2ThreadNum.Enabled = ((bool)(resources.GetObject("lblTimer2ThreadNum.Enabled")));
		this.lblTimer2ThreadNum.Font = ((System.Drawing.Font)(resources.GetObject("lblTimer2ThreadNum.Font")));
		this.lblTimer2ThreadNum.Image = ((System.Drawing.Image)(resources.GetObject("lblTimer2ThreadNum.Image")));
		this.lblTimer2ThreadNum.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer2ThreadNum.ImageAlign")));
		this.lblTimer2ThreadNum.ImageIndex = ((int)(resources.GetObject("lblTimer2ThreadNum.ImageIndex")));
		this.lblTimer2ThreadNum.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblTimer2ThreadNum.ImeMode")));
		this.lblTimer2ThreadNum.Location = ((System.Drawing.Point)(resources.GetObject("lblTimer2ThreadNum.Location")));
		this.lblTimer2ThreadNum.Name = "lblTimer2ThreadNum";
		this.lblTimer2ThreadNum.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblTimer2ThreadNum.RightToLeft")));
		this.lblTimer2ThreadNum.Size = ((System.Drawing.Size)(resources.GetObject("lblTimer2ThreadNum.Size")));
		this.lblTimer2ThreadNum.TabIndex = ((int)(resources.GetObject("lblTimer2ThreadNum.TabIndex")));
		this.lblTimer2ThreadNum.Text = resources.GetString("lblTimer2ThreadNum.Text");
		this.lblTimer2ThreadNum.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer2ThreadNum.TextAlign")));
		this.lblTimer2ThreadNum.Visible = ((bool)(resources.GetObject("lblTimer2ThreadNum.Visible")));
		// 
		// Label16
		// 
		this.Label16.AccessibleDescription = resources.GetString("Label16.AccessibleDescription");
		this.Label16.AccessibleName = resources.GetString("Label16.AccessibleName");
		this.Label16.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label16.Anchor")));
		this.Label16.AutoSize = ((bool)(resources.GetObject("Label16.AutoSize")));
		this.Label16.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label16.Dock")));
		this.Label16.Enabled = ((bool)(resources.GetObject("Label16.Enabled")));
		this.Label16.Font = ((System.Drawing.Font)(resources.GetObject("Label16.Font")));
		this.Label16.Image = ((System.Drawing.Image)(resources.GetObject("Label16.Image")));
		this.Label16.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label16.ImageAlign")));
		this.Label16.ImageIndex = ((int)(resources.GetObject("Label16.ImageIndex")));
		this.Label16.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label16.ImeMode")));
		this.Label16.Location = ((System.Drawing.Point)(resources.GetObject("Label16.Location")));
		this.Label16.Name = "Label16";
		this.Label16.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label16.RightToLeft")));
		this.Label16.Size = ((System.Drawing.Size)(resources.GetObject("Label16.Size")));
		this.Label16.TabIndex = ((int)(resources.GetObject("Label16.TabIndex")));
		this.Label16.Text = resources.GetString("Label16.Text");
		this.Label16.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label16.TextAlign")));
		this.Label16.Visible = ((bool)(resources.GetObject("Label16.Visible")));
		// 
		// lblTimer2Output
		// 
		this.lblTimer2Output.AccessibleDescription = resources.GetString("lblTimer2Output.AccessibleDescription");
		this.lblTimer2Output.AccessibleName = resources.GetString("lblTimer2Output.AccessibleName");
		this.lblTimer2Output.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblTimer2Output.Anchor")));
		this.lblTimer2Output.AutoSize = ((bool)(resources.GetObject("lblTimer2Output.AutoSize")));
		this.lblTimer2Output.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblTimer2Output.Dock")));
		this.lblTimer2Output.Enabled = ((bool)(resources.GetObject("lblTimer2Output.Enabled")));
		this.lblTimer2Output.Font = ((System.Drawing.Font)(resources.GetObject("lblTimer2Output.Font")));
		this.lblTimer2Output.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblTimer2Output.Image = ((System.Drawing.Image)(resources.GetObject("lblTimer2Output.Image")));
		this.lblTimer2Output.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer2Output.ImageAlign")));
		this.lblTimer2Output.ImageIndex = ((int)(resources.GetObject("lblTimer2Output.ImageIndex")));
		this.lblTimer2Output.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblTimer2Output.ImeMode")));
		this.lblTimer2Output.Location = ((System.Drawing.Point)(resources.GetObject("lblTimer2Output.Location")));
		this.lblTimer2Output.Name = "lblTimer2Output";
		this.lblTimer2Output.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblTimer2Output.RightToLeft")));
		this.lblTimer2Output.Size = ((System.Drawing.Size)(resources.GetObject("lblTimer2Output.Size")));
		this.lblTimer2Output.TabIndex = ((int)(resources.GetObject("lblTimer2Output.TabIndex")));
		this.lblTimer2Output.Text = resources.GetString("lblTimer2Output.Text");
		this.lblTimer2Output.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer2Output.TextAlign")));
		this.lblTimer2Output.Visible = ((bool)(resources.GetObject("lblTimer2Output.Visible")));
		// 
		// Timer1GroupBox
		// 
		this.Timer1GroupBox.AccessibleDescription = resources.GetString("Timer1GroupBox.AccessibleDescription");
		this.Timer1GroupBox.AccessibleName = resources.GetString("Timer1GroupBox.AccessibleName");
		this.Timer1GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Timer1GroupBox.Anchor")));
		this.Timer1GroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Timer1GroupBox.BackgroundImage")));
		this.Timer1GroupBox.Controls.Add(this.lblTimer1IsThreadPool);
		this.Timer1GroupBox.Controls.Add(this.Label9);
		this.Timer1GroupBox.Controls.Add(this.lblTimer1ThreadNum);
		this.Timer1GroupBox.Controls.Add(this.Label11);
		this.Timer1GroupBox.Controls.Add(this.lblTimer1Output);
		this.Timer1GroupBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Timer1GroupBox.Dock")));
		this.Timer1GroupBox.Enabled = ((bool)(resources.GetObject("Timer1GroupBox.Enabled")));
		this.Timer1GroupBox.Font = ((System.Drawing.Font)(resources.GetObject("Timer1GroupBox.Font")));
		this.Timer1GroupBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Timer1GroupBox.ImeMode")));
		this.Timer1GroupBox.Location = ((System.Drawing.Point)(resources.GetObject("Timer1GroupBox.Location")));
		this.Timer1GroupBox.Name = "Timer1GroupBox";
		this.Timer1GroupBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Timer1GroupBox.RightToLeft")));
		this.Timer1GroupBox.Size = ((System.Drawing.Size)(resources.GetObject("Timer1GroupBox.Size")));
		this.Timer1GroupBox.TabIndex = ((int)(resources.GetObject("Timer1GroupBox.TabIndex")));
		this.Timer1GroupBox.TabStop = false;
		this.Timer1GroupBox.Text = resources.GetString("Timer1GroupBox.Text");
		this.Timer1GroupBox.Visible = ((bool)(resources.GetObject("Timer1GroupBox.Visible")));
		// 
		// lblTimer1IsThreadPool
		// 
		this.lblTimer1IsThreadPool.AccessibleDescription = resources.GetString("lblTimer1IsThreadPool.AccessibleDescription");
		this.lblTimer1IsThreadPool.AccessibleName = resources.GetString("lblTimer1IsThreadPool.AccessibleName");
		this.lblTimer1IsThreadPool.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblTimer1IsThreadPool.Anchor")));
		this.lblTimer1IsThreadPool.AutoSize = ((bool)(resources.GetObject("lblTimer1IsThreadPool.AutoSize")));
		this.lblTimer1IsThreadPool.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblTimer1IsThreadPool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTimer1IsThreadPool.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblTimer1IsThreadPool.Dock")));
		this.lblTimer1IsThreadPool.Enabled = ((bool)(resources.GetObject("lblTimer1IsThreadPool.Enabled")));
		this.lblTimer1IsThreadPool.Font = ((System.Drawing.Font)(resources.GetObject("lblTimer1IsThreadPool.Font")));
		this.lblTimer1IsThreadPool.Image = ((System.Drawing.Image)(resources.GetObject("lblTimer1IsThreadPool.Image")));
		this.lblTimer1IsThreadPool.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer1IsThreadPool.ImageAlign")));
		this.lblTimer1IsThreadPool.ImageIndex = ((int)(resources.GetObject("lblTimer1IsThreadPool.ImageIndex")));
		this.lblTimer1IsThreadPool.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblTimer1IsThreadPool.ImeMode")));
		this.lblTimer1IsThreadPool.Location = ((System.Drawing.Point)(resources.GetObject("lblTimer1IsThreadPool.Location")));
		this.lblTimer1IsThreadPool.Name = "lblTimer1IsThreadPool";
		this.lblTimer1IsThreadPool.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblTimer1IsThreadPool.RightToLeft")));
		this.lblTimer1IsThreadPool.Size = ((System.Drawing.Size)(resources.GetObject("lblTimer1IsThreadPool.Size")));
		this.lblTimer1IsThreadPool.TabIndex = ((int)(resources.GetObject("lblTimer1IsThreadPool.TabIndex")));
		this.lblTimer1IsThreadPool.Text = resources.GetString("lblTimer1IsThreadPool.Text");
		this.lblTimer1IsThreadPool.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer1IsThreadPool.TextAlign")));
		this.lblTimer1IsThreadPool.Visible = ((bool)(resources.GetObject("lblTimer1IsThreadPool.Visible")));
		// 
		// Label9
		// 
		this.Label9.AccessibleDescription = resources.GetString("Label9.AccessibleDescription");
		this.Label9.AccessibleName = resources.GetString("Label9.AccessibleName");
		this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label9.Anchor")));
		this.Label9.AutoSize = ((bool)(resources.GetObject("Label9.AutoSize")));
		this.Label9.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label9.Dock")));
		this.Label9.Enabled = ((bool)(resources.GetObject("Label9.Enabled")));
		this.Label9.Font = ((System.Drawing.Font)(resources.GetObject("Label9.Font")));
		this.Label9.Image = ((System.Drawing.Image)(resources.GetObject("Label9.Image")));
		this.Label9.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label9.ImageAlign")));
		this.Label9.ImageIndex = ((int)(resources.GetObject("Label9.ImageIndex")));
		this.Label9.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label9.ImeMode")));
		this.Label9.Location = ((System.Drawing.Point)(resources.GetObject("Label9.Location")));
		this.Label9.Name = "Label9";
		this.Label9.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label9.RightToLeft")));
		this.Label9.Size = ((System.Drawing.Size)(resources.GetObject("Label9.Size")));
		this.Label9.TabIndex = ((int)(resources.GetObject("Label9.TabIndex")));
		this.Label9.Text = resources.GetString("Label9.Text");
		this.Label9.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label9.TextAlign")));
		this.Label9.Visible = ((bool)(resources.GetObject("Label9.Visible")));
		// 
		// lblTimer1ThreadNum
		// 
		this.lblTimer1ThreadNum.AccessibleDescription = resources.GetString("lblTimer1ThreadNum.AccessibleDescription");
		this.lblTimer1ThreadNum.AccessibleName = resources.GetString("lblTimer1ThreadNum.AccessibleName");
		this.lblTimer1ThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblTimer1ThreadNum.Anchor")));
		this.lblTimer1ThreadNum.AutoSize = ((bool)(resources.GetObject("lblTimer1ThreadNum.AutoSize")));
		this.lblTimer1ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblTimer1ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTimer1ThreadNum.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblTimer1ThreadNum.Dock")));
		this.lblTimer1ThreadNum.Enabled = ((bool)(resources.GetObject("lblTimer1ThreadNum.Enabled")));
		this.lblTimer1ThreadNum.Font = ((System.Drawing.Font)(resources.GetObject("lblTimer1ThreadNum.Font")));
		this.lblTimer1ThreadNum.Image = ((System.Drawing.Image)(resources.GetObject("lblTimer1ThreadNum.Image")));
		this.lblTimer1ThreadNum.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer1ThreadNum.ImageAlign")));
		this.lblTimer1ThreadNum.ImageIndex = ((int)(resources.GetObject("lblTimer1ThreadNum.ImageIndex")));
		this.lblTimer1ThreadNum.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblTimer1ThreadNum.ImeMode")));
		this.lblTimer1ThreadNum.Location = ((System.Drawing.Point)(resources.GetObject("lblTimer1ThreadNum.Location")));
		this.lblTimer1ThreadNum.Name = "lblTimer1ThreadNum";
		this.lblTimer1ThreadNum.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblTimer1ThreadNum.RightToLeft")));
		this.lblTimer1ThreadNum.Size = ((System.Drawing.Size)(resources.GetObject("lblTimer1ThreadNum.Size")));
		this.lblTimer1ThreadNum.TabIndex = ((int)(resources.GetObject("lblTimer1ThreadNum.TabIndex")));
		this.lblTimer1ThreadNum.Text = resources.GetString("lblTimer1ThreadNum.Text");
		this.lblTimer1ThreadNum.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer1ThreadNum.TextAlign")));
		this.lblTimer1ThreadNum.Visible = ((bool)(resources.GetObject("lblTimer1ThreadNum.Visible")));
		// 
		// Label11
		// 
		this.Label11.AccessibleDescription = resources.GetString("Label11.AccessibleDescription");
		this.Label11.AccessibleName = resources.GetString("Label11.AccessibleName");
		this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label11.Anchor")));
		this.Label11.AutoSize = ((bool)(resources.GetObject("Label11.AutoSize")));
		this.Label11.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label11.Dock")));
		this.Label11.Enabled = ((bool)(resources.GetObject("Label11.Enabled")));
		this.Label11.Font = ((System.Drawing.Font)(resources.GetObject("Label11.Font")));
		this.Label11.Image = ((System.Drawing.Image)(resources.GetObject("Label11.Image")));
		this.Label11.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label11.ImageAlign")));
		this.Label11.ImageIndex = ((int)(resources.GetObject("Label11.ImageIndex")));
		this.Label11.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label11.ImeMode")));
		this.Label11.Location = ((System.Drawing.Point)(resources.GetObject("Label11.Location")));
		this.Label11.Name = "Label11";
		this.Label11.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label11.RightToLeft")));
		this.Label11.Size = ((System.Drawing.Size)(resources.GetObject("Label11.Size")));
		this.Label11.TabIndex = ((int)(resources.GetObject("Label11.TabIndex")));
		this.Label11.Text = resources.GetString("Label11.Text");
		this.Label11.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label11.TextAlign")));
		this.Label11.Visible = ((bool)(resources.GetObject("Label11.Visible")));
		// 
		// lblTimer1Output
		// 
		this.lblTimer1Output.AccessibleDescription = resources.GetString("lblTimer1Output.AccessibleDescription");
		this.lblTimer1Output.AccessibleName = resources.GetString("lblTimer1Output.AccessibleName");
		this.lblTimer1Output.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblTimer1Output.Anchor")));
		this.lblTimer1Output.AutoSize = ((bool)(resources.GetObject("lblTimer1Output.AutoSize")));
		this.lblTimer1Output.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblTimer1Output.Dock")));
		this.lblTimer1Output.Enabled = ((bool)(resources.GetObject("lblTimer1Output.Enabled")));
		this.lblTimer1Output.Font = ((System.Drawing.Font)(resources.GetObject("lblTimer1Output.Font")));
		this.lblTimer1Output.ForeColor = System.Drawing.SystemColors.ControlText;
		this.lblTimer1Output.Image = ((System.Drawing.Image)(resources.GetObject("lblTimer1Output.Image")));
		this.lblTimer1Output.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer1Output.ImageAlign")));
		this.lblTimer1Output.ImageIndex = ((int)(resources.GetObject("lblTimer1Output.ImageIndex")));
		this.lblTimer1Output.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblTimer1Output.ImeMode")));
		this.lblTimer1Output.Location = ((System.Drawing.Point)(resources.GetObject("lblTimer1Output.Location")));
		this.lblTimer1Output.Name = "lblTimer1Output";
		this.lblTimer1Output.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblTimer1Output.RightToLeft")));
		this.lblTimer1Output.Size = ((System.Drawing.Size)(resources.GetObject("lblTimer1Output.Size")));
		this.lblTimer1Output.TabIndex = ((int)(resources.GetObject("lblTimer1Output.TabIndex")));
		this.lblTimer1Output.Text = resources.GetString("lblTimer1Output.Text");
		this.lblTimer1Output.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblTimer1Output.TextAlign")));
		this.lblTimer1Output.Visible = ((bool)(resources.GetObject("lblTimer1Output.Visible")));
		// 
		// SyncObjectsTabPage
		// 
		this.SyncObjectsTabPage.AccessibleDescription = resources.GetString("SyncObjectsTabPage.AccessibleDescription");
		this.SyncObjectsTabPage.AccessibleName = resources.GetString("SyncObjectsTabPage.AccessibleName");
		this.SyncObjectsTabPage.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("SyncObjectsTabPage.Anchor")));
		this.SyncObjectsTabPage.AutoScroll = ((bool)(resources.GetObject("SyncObjectsTabPage.AutoScroll")));
		this.SyncObjectsTabPage.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("SyncObjectsTabPage.AutoScrollMargin")));
		this.SyncObjectsTabPage.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("SyncObjectsTabPage.AutoScrollMinSize")));
		this.SyncObjectsTabPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SyncObjectsTabPage.BackgroundImage")));
		this.SyncObjectsTabPage.Controls.Add(this.lblInstructions3);
		this.SyncObjectsTabPage.Controls.Add(this.btnSetReleaseAll);
		this.SyncObjectsTabPage.Controls.Add(this.btnSetAutoEvent);
		this.SyncObjectsTabPage.Controls.Add(this.btnWaitForAutoEvent);
		this.SyncObjectsTabPage.Controls.Add(this.btnSetManualEvent);
		this.SyncObjectsTabPage.Controls.Add(this.btnWaitForManualEvent);
		this.SyncObjectsTabPage.Controls.Add(this.btnReleaseMutex);
		this.SyncObjectsTabPage.Controls.Add(this.btnWaitForMutex);
		this.SyncObjectsTabPage.Controls.Add(this.AutoEventGroupBox);
		this.SyncObjectsTabPage.Controls.Add(this.ManualEventGroupBox);
		this.SyncObjectsTabPage.Controls.Add(this.MutexGroupBox);
		this.SyncObjectsTabPage.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("SyncObjectsTabPage.Dock")));
		this.SyncObjectsTabPage.Enabled = ((bool)(resources.GetObject("SyncObjectsTabPage.Enabled")));
		this.SyncObjectsTabPage.Font = ((System.Drawing.Font)(resources.GetObject("SyncObjectsTabPage.Font")));
		this.SyncObjectsTabPage.ImageIndex = ((int)(resources.GetObject("SyncObjectsTabPage.ImageIndex")));
		this.SyncObjectsTabPage.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("SyncObjectsTabPage.ImeMode")));
		this.SyncObjectsTabPage.Location = ((System.Drawing.Point)(resources.GetObject("SyncObjectsTabPage.Location")));
		this.SyncObjectsTabPage.Name = "SyncObjectsTabPage";
		this.SyncObjectsTabPage.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("SyncObjectsTabPage.RightToLeft")));
		this.SyncObjectsTabPage.Size = ((System.Drawing.Size)(resources.GetObject("SyncObjectsTabPage.Size")));
		this.SyncObjectsTabPage.TabIndex = ((int)(resources.GetObject("SyncObjectsTabPage.TabIndex")));
		this.SyncObjectsTabPage.Text = resources.GetString("SyncObjectsTabPage.Text");
		this.SyncObjectsTabPage.ToolTipText = resources.GetString("SyncObjectsTabPage.ToolTipText");
		this.SyncObjectsTabPage.Visible = ((bool)(resources.GetObject("SyncObjectsTabPage.Visible")));
		// 
		// lblInstructions3
		// 
		this.lblInstructions3.AccessibleDescription = resources.GetString("lblInstructions3.AccessibleDescription");
		this.lblInstructions3.AccessibleName = resources.GetString("lblInstructions3.AccessibleName");
		this.lblInstructions3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblInstructions3.Anchor")));
		this.lblInstructions3.AutoSize = ((bool)(resources.GetObject("lblInstructions3.AutoSize")));
		this.lblInstructions3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblInstructions3.Dock")));
		this.lblInstructions3.Enabled = ((bool)(resources.GetObject("lblInstructions3.Enabled")));
		this.lblInstructions3.Font = ((System.Drawing.Font)(resources.GetObject("lblInstructions3.Font")));
		this.lblInstructions3.ForeColor = System.Drawing.Color.Blue;
		this.lblInstructions3.Image = ((System.Drawing.Image)(resources.GetObject("lblInstructions3.Image")));
		this.lblInstructions3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions3.ImageAlign")));
		this.lblInstructions3.ImageIndex = ((int)(resources.GetObject("lblInstructions3.ImageIndex")));
		this.lblInstructions3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblInstructions3.ImeMode")));
		this.lblInstructions3.Location = ((System.Drawing.Point)(resources.GetObject("lblInstructions3.Location")));
		this.lblInstructions3.Name = "lblInstructions3";
		this.lblInstructions3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblInstructions3.RightToLeft")));
		this.lblInstructions3.Size = ((System.Drawing.Size)(resources.GetObject("lblInstructions3.Size")));
		this.lblInstructions3.TabIndex = ((int)(resources.GetObject("lblInstructions3.TabIndex")));
		this.lblInstructions3.Text = resources.GetString("lblInstructions3.Text");
		this.lblInstructions3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstructions3.TextAlign")));
		this.lblInstructions3.Visible = ((bool)(resources.GetObject("lblInstructions3.Visible")));
		// 
		// btnSetReleaseAll
		// 
		this.btnSetReleaseAll.AccessibleDescription = resources.GetString("btnSetReleaseAll.AccessibleDescription");
		this.btnSetReleaseAll.AccessibleName = resources.GetString("btnSetReleaseAll.AccessibleName");
		this.btnSetReleaseAll.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSetReleaseAll.Anchor")));
		this.btnSetReleaseAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetReleaseAll.BackgroundImage")));
		this.btnSetReleaseAll.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSetReleaseAll.Dock")));
		this.btnSetReleaseAll.Enabled = ((bool)(resources.GetObject("btnSetReleaseAll.Enabled")));
		this.btnSetReleaseAll.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSetReleaseAll.FlatStyle")));
		this.btnSetReleaseAll.Font = ((System.Drawing.Font)(resources.GetObject("btnSetReleaseAll.Font")));
		this.btnSetReleaseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSetReleaseAll.Image")));
		this.btnSetReleaseAll.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetReleaseAll.ImageAlign")));
		this.btnSetReleaseAll.ImageIndex = ((int)(resources.GetObject("btnSetReleaseAll.ImageIndex")));
		this.btnSetReleaseAll.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSetReleaseAll.ImeMode")));
		this.btnSetReleaseAll.Location = ((System.Drawing.Point)(resources.GetObject("btnSetReleaseAll.Location")));
		this.btnSetReleaseAll.Name = "btnSetReleaseAll";
		this.btnSetReleaseAll.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSetReleaseAll.RightToLeft")));
		this.btnSetReleaseAll.Size = ((System.Drawing.Size)(resources.GetObject("btnSetReleaseAll.Size")));
		this.btnSetReleaseAll.TabIndex = ((int)(resources.GetObject("btnSetReleaseAll.TabIndex")));
		this.btnSetReleaseAll.Text = resources.GetString("btnSetReleaseAll.Text");
		this.btnSetReleaseAll.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetReleaseAll.TextAlign")));
		this.btnSetReleaseAll.Visible = ((bool)(resources.GetObject("btnSetReleaseAll.Visible")));
		this.btnSetReleaseAll.Click += new System.EventHandler(this.btnSetReleaseAll_Click);
		// 
		// btnSetAutoEvent
		// 
		this.btnSetAutoEvent.AccessibleDescription = resources.GetString("btnSetAutoEvent.AccessibleDescription");
		this.btnSetAutoEvent.AccessibleName = resources.GetString("btnSetAutoEvent.AccessibleName");
		this.btnSetAutoEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSetAutoEvent.Anchor")));
		this.btnSetAutoEvent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetAutoEvent.BackgroundImage")));
		this.btnSetAutoEvent.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSetAutoEvent.Dock")));
		this.btnSetAutoEvent.Enabled = ((bool)(resources.GetObject("btnSetAutoEvent.Enabled")));
		this.btnSetAutoEvent.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSetAutoEvent.FlatStyle")));
		this.btnSetAutoEvent.Font = ((System.Drawing.Font)(resources.GetObject("btnSetAutoEvent.Font")));
		this.btnSetAutoEvent.Image = ((System.Drawing.Image)(resources.GetObject("btnSetAutoEvent.Image")));
		this.btnSetAutoEvent.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetAutoEvent.ImageAlign")));
		this.btnSetAutoEvent.ImageIndex = ((int)(resources.GetObject("btnSetAutoEvent.ImageIndex")));
		this.btnSetAutoEvent.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSetAutoEvent.ImeMode")));
		this.btnSetAutoEvent.Location = ((System.Drawing.Point)(resources.GetObject("btnSetAutoEvent.Location")));
		this.btnSetAutoEvent.Name = "btnSetAutoEvent";
		this.btnSetAutoEvent.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSetAutoEvent.RightToLeft")));
		this.btnSetAutoEvent.Size = ((System.Drawing.Size)(resources.GetObject("btnSetAutoEvent.Size")));
		this.btnSetAutoEvent.TabIndex = ((int)(resources.GetObject("btnSetAutoEvent.TabIndex")));
		this.btnSetAutoEvent.Text = resources.GetString("btnSetAutoEvent.Text");
		this.btnSetAutoEvent.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetAutoEvent.TextAlign")));
		this.btnSetAutoEvent.Visible = ((bool)(resources.GetObject("btnSetAutoEvent.Visible")));
		this.btnSetAutoEvent.Click += new System.EventHandler(this.btnSetAutoEvent_Click);
		// 
		// btnWaitForAutoEvent
		// 
		this.btnWaitForAutoEvent.AccessibleDescription = resources.GetString("btnWaitForAutoEvent.AccessibleDescription");
		this.btnWaitForAutoEvent.AccessibleName = resources.GetString("btnWaitForAutoEvent.AccessibleName");
		this.btnWaitForAutoEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnWaitForAutoEvent.Anchor")));
		this.btnWaitForAutoEvent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWaitForAutoEvent.BackgroundImage")));
		this.btnWaitForAutoEvent.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnWaitForAutoEvent.Dock")));
		this.btnWaitForAutoEvent.Enabled = ((bool)(resources.GetObject("btnWaitForAutoEvent.Enabled")));
		this.btnWaitForAutoEvent.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnWaitForAutoEvent.FlatStyle")));
		this.btnWaitForAutoEvent.Font = ((System.Drawing.Font)(resources.GetObject("btnWaitForAutoEvent.Font")));
		this.btnWaitForAutoEvent.Image = ((System.Drawing.Image)(resources.GetObject("btnWaitForAutoEvent.Image")));
		this.btnWaitForAutoEvent.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnWaitForAutoEvent.ImageAlign")));
		this.btnWaitForAutoEvent.ImageIndex = ((int)(resources.GetObject("btnWaitForAutoEvent.ImageIndex")));
		this.btnWaitForAutoEvent.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnWaitForAutoEvent.ImeMode")));
		this.btnWaitForAutoEvent.Location = ((System.Drawing.Point)(resources.GetObject("btnWaitForAutoEvent.Location")));
		this.btnWaitForAutoEvent.Name = "btnWaitForAutoEvent";
		this.btnWaitForAutoEvent.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnWaitForAutoEvent.RightToLeft")));
		this.btnWaitForAutoEvent.Size = ((System.Drawing.Size)(resources.GetObject("btnWaitForAutoEvent.Size")));
		this.btnWaitForAutoEvent.TabIndex = ((int)(resources.GetObject("btnWaitForAutoEvent.TabIndex")));
		this.btnWaitForAutoEvent.Text = resources.GetString("btnWaitForAutoEvent.Text");
		this.btnWaitForAutoEvent.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnWaitForAutoEvent.TextAlign")));
		this.btnWaitForAutoEvent.Visible = ((bool)(resources.GetObject("btnWaitForAutoEvent.Visible")));
		this.btnWaitForAutoEvent.Click += new System.EventHandler(this.btnWaitForAutoEvent_Click);
		// 
		// btnSetManualEvent
		// 
		this.btnSetManualEvent.AccessibleDescription = resources.GetString("btnSetManualEvent.AccessibleDescription");
		this.btnSetManualEvent.AccessibleName = resources.GetString("btnSetManualEvent.AccessibleName");
		this.btnSetManualEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSetManualEvent.Anchor")));
		this.btnSetManualEvent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetManualEvent.BackgroundImage")));
		this.btnSetManualEvent.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSetManualEvent.Dock")));
		this.btnSetManualEvent.Enabled = ((bool)(resources.GetObject("btnSetManualEvent.Enabled")));
		this.btnSetManualEvent.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSetManualEvent.FlatStyle")));
		this.btnSetManualEvent.Font = ((System.Drawing.Font)(resources.GetObject("btnSetManualEvent.Font")));
		this.btnSetManualEvent.Image = ((System.Drawing.Image)(resources.GetObject("btnSetManualEvent.Image")));
		this.btnSetManualEvent.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetManualEvent.ImageAlign")));
		this.btnSetManualEvent.ImageIndex = ((int)(resources.GetObject("btnSetManualEvent.ImageIndex")));
		this.btnSetManualEvent.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSetManualEvent.ImeMode")));
		this.btnSetManualEvent.Location = ((System.Drawing.Point)(resources.GetObject("btnSetManualEvent.Location")));
		this.btnSetManualEvent.Name = "btnSetManualEvent";
		this.btnSetManualEvent.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSetManualEvent.RightToLeft")));
		this.btnSetManualEvent.Size = ((System.Drawing.Size)(resources.GetObject("btnSetManualEvent.Size")));
		this.btnSetManualEvent.TabIndex = ((int)(resources.GetObject("btnSetManualEvent.TabIndex")));
		this.btnSetManualEvent.Text = resources.GetString("btnSetManualEvent.Text");
		this.btnSetManualEvent.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetManualEvent.TextAlign")));
		this.btnSetManualEvent.Visible = ((bool)(resources.GetObject("btnSetManualEvent.Visible")));
		this.btnSetManualEvent.Click += new System.EventHandler(this.btnSetManualEvent_Click);
		// 
		// btnWaitForManualEvent
		// 
		this.btnWaitForManualEvent.AccessibleDescription = resources.GetString("btnWaitForManualEvent.AccessibleDescription");
		this.btnWaitForManualEvent.AccessibleName = resources.GetString("btnWaitForManualEvent.AccessibleName");
		this.btnWaitForManualEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnWaitForManualEvent.Anchor")));
		this.btnWaitForManualEvent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWaitForManualEvent.BackgroundImage")));
		this.btnWaitForManualEvent.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnWaitForManualEvent.Dock")));
		this.btnWaitForManualEvent.Enabled = ((bool)(resources.GetObject("btnWaitForManualEvent.Enabled")));
		this.btnWaitForManualEvent.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnWaitForManualEvent.FlatStyle")));
		this.btnWaitForManualEvent.Font = ((System.Drawing.Font)(resources.GetObject("btnWaitForManualEvent.Font")));
		this.btnWaitForManualEvent.Image = ((System.Drawing.Image)(resources.GetObject("btnWaitForManualEvent.Image")));
		this.btnWaitForManualEvent.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnWaitForManualEvent.ImageAlign")));
		this.btnWaitForManualEvent.ImageIndex = ((int)(resources.GetObject("btnWaitForManualEvent.ImageIndex")));
		this.btnWaitForManualEvent.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnWaitForManualEvent.ImeMode")));
		this.btnWaitForManualEvent.Location = ((System.Drawing.Point)(resources.GetObject("btnWaitForManualEvent.Location")));
		this.btnWaitForManualEvent.Name = "btnWaitForManualEvent";
		this.btnWaitForManualEvent.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnWaitForManualEvent.RightToLeft")));
		this.btnWaitForManualEvent.Size = ((System.Drawing.Size)(resources.GetObject("btnWaitForManualEvent.Size")));
		this.btnWaitForManualEvent.TabIndex = ((int)(resources.GetObject("btnWaitForManualEvent.TabIndex")));
		this.btnWaitForManualEvent.Text = resources.GetString("btnWaitForManualEvent.Text");
		this.btnWaitForManualEvent.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnWaitForManualEvent.TextAlign")));
		this.btnWaitForManualEvent.Visible = ((bool)(resources.GetObject("btnWaitForManualEvent.Visible")));
		this.btnWaitForManualEvent.Click += new System.EventHandler(this.btnWaitForManualEvent_Click);
		// 
		// btnReleaseMutex
		// 
		this.btnReleaseMutex.AccessibleDescription = resources.GetString("btnReleaseMutex.AccessibleDescription");
		this.btnReleaseMutex.AccessibleName = resources.GetString("btnReleaseMutex.AccessibleName");
		this.btnReleaseMutex.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnReleaseMutex.Anchor")));
		this.btnReleaseMutex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReleaseMutex.BackgroundImage")));
		this.btnReleaseMutex.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnReleaseMutex.Dock")));
		this.btnReleaseMutex.Enabled = ((bool)(resources.GetObject("btnReleaseMutex.Enabled")));
		this.btnReleaseMutex.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnReleaseMutex.FlatStyle")));
		this.btnReleaseMutex.Font = ((System.Drawing.Font)(resources.GetObject("btnReleaseMutex.Font")));
		this.btnReleaseMutex.Image = ((System.Drawing.Image)(resources.GetObject("btnReleaseMutex.Image")));
		this.btnReleaseMutex.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnReleaseMutex.ImageAlign")));
		this.btnReleaseMutex.ImageIndex = ((int)(resources.GetObject("btnReleaseMutex.ImageIndex")));
		this.btnReleaseMutex.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnReleaseMutex.ImeMode")));
		this.btnReleaseMutex.Location = ((System.Drawing.Point)(resources.GetObject("btnReleaseMutex.Location")));
		this.btnReleaseMutex.Name = "btnReleaseMutex";
		this.btnReleaseMutex.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnReleaseMutex.RightToLeft")));
		this.btnReleaseMutex.Size = ((System.Drawing.Size)(resources.GetObject("btnReleaseMutex.Size")));
		this.btnReleaseMutex.TabIndex = ((int)(resources.GetObject("btnReleaseMutex.TabIndex")));
		this.btnReleaseMutex.Text = resources.GetString("btnReleaseMutex.Text");
		this.btnReleaseMutex.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnReleaseMutex.TextAlign")));
		this.btnReleaseMutex.Visible = ((bool)(resources.GetObject("btnReleaseMutex.Visible")));
		this.btnReleaseMutex.Click += new System.EventHandler(this.btnReleaseMutex_Click);
		// 
		// btnWaitForMutex
		// 
		this.btnWaitForMutex.AccessibleDescription = resources.GetString("btnWaitForMutex.AccessibleDescription");
		this.btnWaitForMutex.AccessibleName = resources.GetString("btnWaitForMutex.AccessibleName");
		this.btnWaitForMutex.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnWaitForMutex.Anchor")));
		this.btnWaitForMutex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnWaitForMutex.BackgroundImage")));
		this.btnWaitForMutex.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnWaitForMutex.Dock")));
		this.btnWaitForMutex.Enabled = ((bool)(resources.GetObject("btnWaitForMutex.Enabled")));
		this.btnWaitForMutex.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnWaitForMutex.FlatStyle")));
		this.btnWaitForMutex.Font = ((System.Drawing.Font)(resources.GetObject("btnWaitForMutex.Font")));
		this.btnWaitForMutex.Image = ((System.Drawing.Image)(resources.GetObject("btnWaitForMutex.Image")));
		this.btnWaitForMutex.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnWaitForMutex.ImageAlign")));
		this.btnWaitForMutex.ImageIndex = ((int)(resources.GetObject("btnWaitForMutex.ImageIndex")));
		this.btnWaitForMutex.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnWaitForMutex.ImeMode")));
		this.btnWaitForMutex.Location = ((System.Drawing.Point)(resources.GetObject("btnWaitForMutex.Location")));
		this.btnWaitForMutex.Name = "btnWaitForMutex";
		this.btnWaitForMutex.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnWaitForMutex.RightToLeft")));
		this.btnWaitForMutex.Size = ((System.Drawing.Size)(resources.GetObject("btnWaitForMutex.Size")));
		this.btnWaitForMutex.TabIndex = ((int)(resources.GetObject("btnWaitForMutex.TabIndex")));
		this.btnWaitForMutex.Text = resources.GetString("btnWaitForMutex.Text");
		this.btnWaitForMutex.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnWaitForMutex.TextAlign")));
		this.btnWaitForMutex.Visible = ((bool)(resources.GetObject("btnWaitForMutex.Visible")));
		this.btnWaitForMutex.Click += new System.EventHandler(this.btnWaitForMutex_Click);
		// 
		// AutoEventGroupBox
		// 
		this.AutoEventGroupBox.AccessibleDescription = resources.GetString("AutoEventGroupBox.AccessibleDescription");
		this.AutoEventGroupBox.AccessibleName = resources.GetString("AutoEventGroupBox.AccessibleName");
		this.AutoEventGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("AutoEventGroupBox.Anchor")));
		this.AutoEventGroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AutoEventGroupBox.BackgroundImage")));
		this.AutoEventGroupBox.Controls.Add(this.lblAutoEventIsPoolThread);
		this.AutoEventGroupBox.Controls.Add(this.Label23);
		this.AutoEventGroupBox.Controls.Add(this.lblAutoEventThreadNum);
		this.AutoEventGroupBox.Controls.Add(this.Label25);
		this.AutoEventGroupBox.Controls.Add(this.lblAutoEventStatus);
		this.AutoEventGroupBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("AutoEventGroupBox.Dock")));
		this.AutoEventGroupBox.Enabled = ((bool)(resources.GetObject("AutoEventGroupBox.Enabled")));
		this.AutoEventGroupBox.Font = ((System.Drawing.Font)(resources.GetObject("AutoEventGroupBox.Font")));
		this.AutoEventGroupBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("AutoEventGroupBox.ImeMode")));
		this.AutoEventGroupBox.Location = ((System.Drawing.Point)(resources.GetObject("AutoEventGroupBox.Location")));
		this.AutoEventGroupBox.Name = "AutoEventGroupBox";
		this.AutoEventGroupBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("AutoEventGroupBox.RightToLeft")));
		this.AutoEventGroupBox.Size = ((System.Drawing.Size)(resources.GetObject("AutoEventGroupBox.Size")));
		this.AutoEventGroupBox.TabIndex = ((int)(resources.GetObject("AutoEventGroupBox.TabIndex")));
		this.AutoEventGroupBox.TabStop = false;
		this.AutoEventGroupBox.Text = resources.GetString("AutoEventGroupBox.Text");
		this.AutoEventGroupBox.Visible = ((bool)(resources.GetObject("AutoEventGroupBox.Visible")));
		// 
		// lblAutoEventIsPoolThread
		// 
		this.lblAutoEventIsPoolThread.AccessibleDescription = resources.GetString("lblAutoEventIsPoolThread.AccessibleDescription");
		this.lblAutoEventIsPoolThread.AccessibleName = resources.GetString("lblAutoEventIsPoolThread.AccessibleName");
		this.lblAutoEventIsPoolThread.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblAutoEventIsPoolThread.Anchor")));
		this.lblAutoEventIsPoolThread.AutoSize = ((bool)(resources.GetObject("lblAutoEventIsPoolThread.AutoSize")));
		this.lblAutoEventIsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblAutoEventIsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblAutoEventIsPoolThread.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblAutoEventIsPoolThread.Dock")));
		this.lblAutoEventIsPoolThread.Enabled = ((bool)(resources.GetObject("lblAutoEventIsPoolThread.Enabled")));
		this.lblAutoEventIsPoolThread.Font = ((System.Drawing.Font)(resources.GetObject("lblAutoEventIsPoolThread.Font")));
		this.lblAutoEventIsPoolThread.Image = ((System.Drawing.Image)(resources.GetObject("lblAutoEventIsPoolThread.Image")));
		this.lblAutoEventIsPoolThread.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblAutoEventIsPoolThread.ImageAlign")));
		this.lblAutoEventIsPoolThread.ImageIndex = ((int)(resources.GetObject("lblAutoEventIsPoolThread.ImageIndex")));
		this.lblAutoEventIsPoolThread.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblAutoEventIsPoolThread.ImeMode")));
		this.lblAutoEventIsPoolThread.Location = ((System.Drawing.Point)(resources.GetObject("lblAutoEventIsPoolThread.Location")));
		this.lblAutoEventIsPoolThread.Name = "lblAutoEventIsPoolThread";
		this.lblAutoEventIsPoolThread.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblAutoEventIsPoolThread.RightToLeft")));
		this.lblAutoEventIsPoolThread.Size = ((System.Drawing.Size)(resources.GetObject("lblAutoEventIsPoolThread.Size")));
		this.lblAutoEventIsPoolThread.TabIndex = ((int)(resources.GetObject("lblAutoEventIsPoolThread.TabIndex")));
		this.lblAutoEventIsPoolThread.Text = resources.GetString("lblAutoEventIsPoolThread.Text");
		this.lblAutoEventIsPoolThread.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblAutoEventIsPoolThread.TextAlign")));
		this.lblAutoEventIsPoolThread.Visible = ((bool)(resources.GetObject("lblAutoEventIsPoolThread.Visible")));
		// 
		// Label23
		// 
		this.Label23.AccessibleDescription = resources.GetString("Label23.AccessibleDescription");
		this.Label23.AccessibleName = resources.GetString("Label23.AccessibleName");
		this.Label23.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label23.Anchor")));
		this.Label23.AutoSize = ((bool)(resources.GetObject("Label23.AutoSize")));
		this.Label23.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label23.Dock")));
		this.Label23.Enabled = ((bool)(resources.GetObject("Label23.Enabled")));
		this.Label23.Font = ((System.Drawing.Font)(resources.GetObject("Label23.Font")));
		this.Label23.Image = ((System.Drawing.Image)(resources.GetObject("Label23.Image")));
		this.Label23.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label23.ImageAlign")));
		this.Label23.ImageIndex = ((int)(resources.GetObject("Label23.ImageIndex")));
		this.Label23.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label23.ImeMode")));
		this.Label23.Location = ((System.Drawing.Point)(resources.GetObject("Label23.Location")));
		this.Label23.Name = "Label23";
		this.Label23.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label23.RightToLeft")));
		this.Label23.Size = ((System.Drawing.Size)(resources.GetObject("Label23.Size")));
		this.Label23.TabIndex = ((int)(resources.GetObject("Label23.TabIndex")));
		this.Label23.Text = resources.GetString("Label23.Text");
		this.Label23.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label23.TextAlign")));
		this.Label23.Visible = ((bool)(resources.GetObject("Label23.Visible")));
		// 
		// lblAutoEventThreadNum
		// 
		this.lblAutoEventThreadNum.AccessibleDescription = resources.GetString("lblAutoEventThreadNum.AccessibleDescription");
		this.lblAutoEventThreadNum.AccessibleName = resources.GetString("lblAutoEventThreadNum.AccessibleName");
		this.lblAutoEventThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblAutoEventThreadNum.Anchor")));
		this.lblAutoEventThreadNum.AutoSize = ((bool)(resources.GetObject("lblAutoEventThreadNum.AutoSize")));
		this.lblAutoEventThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblAutoEventThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblAutoEventThreadNum.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblAutoEventThreadNum.Dock")));
		this.lblAutoEventThreadNum.Enabled = ((bool)(resources.GetObject("lblAutoEventThreadNum.Enabled")));
		this.lblAutoEventThreadNum.Font = ((System.Drawing.Font)(resources.GetObject("lblAutoEventThreadNum.Font")));
		this.lblAutoEventThreadNum.Image = ((System.Drawing.Image)(resources.GetObject("lblAutoEventThreadNum.Image")));
		this.lblAutoEventThreadNum.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblAutoEventThreadNum.ImageAlign")));
		this.lblAutoEventThreadNum.ImageIndex = ((int)(resources.GetObject("lblAutoEventThreadNum.ImageIndex")));
		this.lblAutoEventThreadNum.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblAutoEventThreadNum.ImeMode")));
		this.lblAutoEventThreadNum.Location = ((System.Drawing.Point)(resources.GetObject("lblAutoEventThreadNum.Location")));
		this.lblAutoEventThreadNum.Name = "lblAutoEventThreadNum";
		this.lblAutoEventThreadNum.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblAutoEventThreadNum.RightToLeft")));
		this.lblAutoEventThreadNum.Size = ((System.Drawing.Size)(resources.GetObject("lblAutoEventThreadNum.Size")));
		this.lblAutoEventThreadNum.TabIndex = ((int)(resources.GetObject("lblAutoEventThreadNum.TabIndex")));
		this.lblAutoEventThreadNum.Text = resources.GetString("lblAutoEventThreadNum.Text");
		this.lblAutoEventThreadNum.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblAutoEventThreadNum.TextAlign")));
		this.lblAutoEventThreadNum.Visible = ((bool)(resources.GetObject("lblAutoEventThreadNum.Visible")));
		// 
		// Label25
		// 
		this.Label25.AccessibleDescription = resources.GetString("Label25.AccessibleDescription");
		this.Label25.AccessibleName = resources.GetString("Label25.AccessibleName");
		this.Label25.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label25.Anchor")));
		this.Label25.AutoSize = ((bool)(resources.GetObject("Label25.AutoSize")));
		this.Label25.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label25.Dock")));
		this.Label25.Enabled = ((bool)(resources.GetObject("Label25.Enabled")));
		this.Label25.Font = ((System.Drawing.Font)(resources.GetObject("Label25.Font")));
		this.Label25.Image = ((System.Drawing.Image)(resources.GetObject("Label25.Image")));
		this.Label25.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label25.ImageAlign")));
		this.Label25.ImageIndex = ((int)(resources.GetObject("Label25.ImageIndex")));
		this.Label25.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label25.ImeMode")));
		this.Label25.Location = ((System.Drawing.Point)(resources.GetObject("Label25.Location")));
		this.Label25.Name = "Label25";
		this.Label25.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label25.RightToLeft")));
		this.Label25.Size = ((System.Drawing.Size)(resources.GetObject("Label25.Size")));
		this.Label25.TabIndex = ((int)(resources.GetObject("Label25.TabIndex")));
		this.Label25.Text = resources.GetString("Label25.Text");
		this.Label25.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label25.TextAlign")));
		this.Label25.Visible = ((bool)(resources.GetObject("Label25.Visible")));
		// 
		// lblAutoEventStatus
		// 
		this.lblAutoEventStatus.AccessibleDescription = resources.GetString("lblAutoEventStatus.AccessibleDescription");
		this.lblAutoEventStatus.AccessibleName = resources.GetString("lblAutoEventStatus.AccessibleName");
		this.lblAutoEventStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblAutoEventStatus.Anchor")));
		this.lblAutoEventStatus.AutoSize = ((bool)(resources.GetObject("lblAutoEventStatus.AutoSize")));
		this.lblAutoEventStatus.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblAutoEventStatus.Dock")));
		this.lblAutoEventStatus.Enabled = ((bool)(resources.GetObject("lblAutoEventStatus.Enabled")));
		this.lblAutoEventStatus.Font = ((System.Drawing.Font)(resources.GetObject("lblAutoEventStatus.Font")));
		this.lblAutoEventStatus.ForeColor = System.Drawing.Color.Red;
		this.lblAutoEventStatus.Image = ((System.Drawing.Image)(resources.GetObject("lblAutoEventStatus.Image")));
		this.lblAutoEventStatus.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblAutoEventStatus.ImageAlign")));
		this.lblAutoEventStatus.ImageIndex = ((int)(resources.GetObject("lblAutoEventStatus.ImageIndex")));
		this.lblAutoEventStatus.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblAutoEventStatus.ImeMode")));
		this.lblAutoEventStatus.Location = ((System.Drawing.Point)(resources.GetObject("lblAutoEventStatus.Location")));
		this.lblAutoEventStatus.Name = "lblAutoEventStatus";
		this.lblAutoEventStatus.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblAutoEventStatus.RightToLeft")));
		this.lblAutoEventStatus.Size = ((System.Drawing.Size)(resources.GetObject("lblAutoEventStatus.Size")));
		this.lblAutoEventStatus.TabIndex = ((int)(resources.GetObject("lblAutoEventStatus.TabIndex")));
		this.lblAutoEventStatus.Text = resources.GetString("lblAutoEventStatus.Text");
		this.lblAutoEventStatus.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblAutoEventStatus.TextAlign")));
		this.lblAutoEventStatus.Visible = ((bool)(resources.GetObject("lblAutoEventStatus.Visible")));
		// 
		// ManualEventGroupBox
		// 
		this.ManualEventGroupBox.AccessibleDescription = resources.GetString("ManualEventGroupBox.AccessibleDescription");
		this.ManualEventGroupBox.AccessibleName = resources.GetString("ManualEventGroupBox.AccessibleName");
		this.ManualEventGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("ManualEventGroupBox.Anchor")));
		this.ManualEventGroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ManualEventGroupBox.BackgroundImage")));
		this.ManualEventGroupBox.Controls.Add(this.lblManualEventIsPoolThread);
		this.ManualEventGroupBox.Controls.Add(this.Label18);
		this.ManualEventGroupBox.Controls.Add(this.lblManualEventThreadNum);
		this.ManualEventGroupBox.Controls.Add(this.Label20);
		this.ManualEventGroupBox.Controls.Add(this.lblManualEventThreadStatus);
		this.ManualEventGroupBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("ManualEventGroupBox.Dock")));
		this.ManualEventGroupBox.Enabled = ((bool)(resources.GetObject("ManualEventGroupBox.Enabled")));
		this.ManualEventGroupBox.Font = ((System.Drawing.Font)(resources.GetObject("ManualEventGroupBox.Font")));
		this.ManualEventGroupBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("ManualEventGroupBox.ImeMode")));
		this.ManualEventGroupBox.Location = ((System.Drawing.Point)(resources.GetObject("ManualEventGroupBox.Location")));
		this.ManualEventGroupBox.Name = "ManualEventGroupBox";
		this.ManualEventGroupBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("ManualEventGroupBox.RightToLeft")));
		this.ManualEventGroupBox.Size = ((System.Drawing.Size)(resources.GetObject("ManualEventGroupBox.Size")));
		this.ManualEventGroupBox.TabIndex = ((int)(resources.GetObject("ManualEventGroupBox.TabIndex")));
		this.ManualEventGroupBox.TabStop = false;
		this.ManualEventGroupBox.Text = resources.GetString("ManualEventGroupBox.Text");
		this.ManualEventGroupBox.Visible = ((bool)(resources.GetObject("ManualEventGroupBox.Visible")));
		// 
		// lblManualEventIsPoolThread
		// 
		this.lblManualEventIsPoolThread.AccessibleDescription = resources.GetString("lblManualEventIsPoolThread.AccessibleDescription");
		this.lblManualEventIsPoolThread.AccessibleName = resources.GetString("lblManualEventIsPoolThread.AccessibleName");
		this.lblManualEventIsPoolThread.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblManualEventIsPoolThread.Anchor")));
		this.lblManualEventIsPoolThread.AutoSize = ((bool)(resources.GetObject("lblManualEventIsPoolThread.AutoSize")));
		this.lblManualEventIsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblManualEventIsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblManualEventIsPoolThread.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblManualEventIsPoolThread.Dock")));
		this.lblManualEventIsPoolThread.Enabled = ((bool)(resources.GetObject("lblManualEventIsPoolThread.Enabled")));
		this.lblManualEventIsPoolThread.Font = ((System.Drawing.Font)(resources.GetObject("lblManualEventIsPoolThread.Font")));
		this.lblManualEventIsPoolThread.Image = ((System.Drawing.Image)(resources.GetObject("lblManualEventIsPoolThread.Image")));
		this.lblManualEventIsPoolThread.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblManualEventIsPoolThread.ImageAlign")));
		this.lblManualEventIsPoolThread.ImageIndex = ((int)(resources.GetObject("lblManualEventIsPoolThread.ImageIndex")));
		this.lblManualEventIsPoolThread.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblManualEventIsPoolThread.ImeMode")));
		this.lblManualEventIsPoolThread.Location = ((System.Drawing.Point)(resources.GetObject("lblManualEventIsPoolThread.Location")));
		this.lblManualEventIsPoolThread.Name = "lblManualEventIsPoolThread";
		this.lblManualEventIsPoolThread.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblManualEventIsPoolThread.RightToLeft")));
		this.lblManualEventIsPoolThread.Size = ((System.Drawing.Size)(resources.GetObject("lblManualEventIsPoolThread.Size")));
		this.lblManualEventIsPoolThread.TabIndex = ((int)(resources.GetObject("lblManualEventIsPoolThread.TabIndex")));
		this.lblManualEventIsPoolThread.Text = resources.GetString("lblManualEventIsPoolThread.Text");
		this.lblManualEventIsPoolThread.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblManualEventIsPoolThread.TextAlign")));
		this.lblManualEventIsPoolThread.Visible = ((bool)(resources.GetObject("lblManualEventIsPoolThread.Visible")));
		// 
		// Label18
		// 
		this.Label18.AccessibleDescription = resources.GetString("Label18.AccessibleDescription");
		this.Label18.AccessibleName = resources.GetString("Label18.AccessibleName");
		this.Label18.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label18.Anchor")));
		this.Label18.AutoSize = ((bool)(resources.GetObject("Label18.AutoSize")));
		this.Label18.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label18.Dock")));
		this.Label18.Enabled = ((bool)(resources.GetObject("Label18.Enabled")));
		this.Label18.Font = ((System.Drawing.Font)(resources.GetObject("Label18.Font")));
		this.Label18.Image = ((System.Drawing.Image)(resources.GetObject("Label18.Image")));
		this.Label18.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label18.ImageAlign")));
		this.Label18.ImageIndex = ((int)(resources.GetObject("Label18.ImageIndex")));
		this.Label18.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label18.ImeMode")));
		this.Label18.Location = ((System.Drawing.Point)(resources.GetObject("Label18.Location")));
		this.Label18.Name = "Label18";
		this.Label18.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label18.RightToLeft")));
		this.Label18.Size = ((System.Drawing.Size)(resources.GetObject("Label18.Size")));
		this.Label18.TabIndex = ((int)(resources.GetObject("Label18.TabIndex")));
		this.Label18.Text = resources.GetString("Label18.Text");
		this.Label18.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label18.TextAlign")));
		this.Label18.Visible = ((bool)(resources.GetObject("Label18.Visible")));
		// 
		// lblManualEventThreadNum
		// 
		this.lblManualEventThreadNum.AccessibleDescription = resources.GetString("lblManualEventThreadNum.AccessibleDescription");
		this.lblManualEventThreadNum.AccessibleName = resources.GetString("lblManualEventThreadNum.AccessibleName");
		this.lblManualEventThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblManualEventThreadNum.Anchor")));
		this.lblManualEventThreadNum.AutoSize = ((bool)(resources.GetObject("lblManualEventThreadNum.AutoSize")));
		this.lblManualEventThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblManualEventThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblManualEventThreadNum.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblManualEventThreadNum.Dock")));
		this.lblManualEventThreadNum.Enabled = ((bool)(resources.GetObject("lblManualEventThreadNum.Enabled")));
		this.lblManualEventThreadNum.Font = ((System.Drawing.Font)(resources.GetObject("lblManualEventThreadNum.Font")));
		this.lblManualEventThreadNum.Image = ((System.Drawing.Image)(resources.GetObject("lblManualEventThreadNum.Image")));
		this.lblManualEventThreadNum.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblManualEventThreadNum.ImageAlign")));
		this.lblManualEventThreadNum.ImageIndex = ((int)(resources.GetObject("lblManualEventThreadNum.ImageIndex")));
		this.lblManualEventThreadNum.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblManualEventThreadNum.ImeMode")));
		this.lblManualEventThreadNum.Location = ((System.Drawing.Point)(resources.GetObject("lblManualEventThreadNum.Location")));
		this.lblManualEventThreadNum.Name = "lblManualEventThreadNum";
		this.lblManualEventThreadNum.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblManualEventThreadNum.RightToLeft")));
		this.lblManualEventThreadNum.Size = ((System.Drawing.Size)(resources.GetObject("lblManualEventThreadNum.Size")));
		this.lblManualEventThreadNum.TabIndex = ((int)(resources.GetObject("lblManualEventThreadNum.TabIndex")));
		this.lblManualEventThreadNum.Text = resources.GetString("lblManualEventThreadNum.Text");
		this.lblManualEventThreadNum.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblManualEventThreadNum.TextAlign")));
		this.lblManualEventThreadNum.Visible = ((bool)(resources.GetObject("lblManualEventThreadNum.Visible")));
		// 
		// Label20
		// 
		this.Label20.AccessibleDescription = resources.GetString("Label20.AccessibleDescription");
		this.Label20.AccessibleName = resources.GetString("Label20.AccessibleName");
		this.Label20.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label20.Anchor")));
		this.Label20.AutoSize = ((bool)(resources.GetObject("Label20.AutoSize")));
		this.Label20.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label20.Dock")));
		this.Label20.Enabled = ((bool)(resources.GetObject("Label20.Enabled")));
		this.Label20.Font = ((System.Drawing.Font)(resources.GetObject("Label20.Font")));
		this.Label20.Image = ((System.Drawing.Image)(resources.GetObject("Label20.Image")));
		this.Label20.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label20.ImageAlign")));
		this.Label20.ImageIndex = ((int)(resources.GetObject("Label20.ImageIndex")));
		this.Label20.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label20.ImeMode")));
		this.Label20.Location = ((System.Drawing.Point)(resources.GetObject("Label20.Location")));
		this.Label20.Name = "Label20";
		this.Label20.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label20.RightToLeft")));
		this.Label20.Size = ((System.Drawing.Size)(resources.GetObject("Label20.Size")));
		this.Label20.TabIndex = ((int)(resources.GetObject("Label20.TabIndex")));
		this.Label20.Text = resources.GetString("Label20.Text");
		this.Label20.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label20.TextAlign")));
		this.Label20.Visible = ((bool)(resources.GetObject("Label20.Visible")));
		// 
		// lblManualEventThreadStatus
		// 
		this.lblManualEventThreadStatus.AccessibleDescription = resources.GetString("lblManualEventThreadStatus.AccessibleDescription");
		this.lblManualEventThreadStatus.AccessibleName = resources.GetString("lblManualEventThreadStatus.AccessibleName");
		this.lblManualEventThreadStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblManualEventThreadStatus.Anchor")));
		this.lblManualEventThreadStatus.AutoSize = ((bool)(resources.GetObject("lblManualEventThreadStatus.AutoSize")));
		this.lblManualEventThreadStatus.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblManualEventThreadStatus.Dock")));
		this.lblManualEventThreadStatus.Enabled = ((bool)(resources.GetObject("lblManualEventThreadStatus.Enabled")));
		this.lblManualEventThreadStatus.Font = ((System.Drawing.Font)(resources.GetObject("lblManualEventThreadStatus.Font")));
		this.lblManualEventThreadStatus.ForeColor = System.Drawing.Color.Red;
		this.lblManualEventThreadStatus.Image = ((System.Drawing.Image)(resources.GetObject("lblManualEventThreadStatus.Image")));
		this.lblManualEventThreadStatus.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblManualEventThreadStatus.ImageAlign")));
		this.lblManualEventThreadStatus.ImageIndex = ((int)(resources.GetObject("lblManualEventThreadStatus.ImageIndex")));
		this.lblManualEventThreadStatus.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblManualEventThreadStatus.ImeMode")));
		this.lblManualEventThreadStatus.Location = ((System.Drawing.Point)(resources.GetObject("lblManualEventThreadStatus.Location")));
		this.lblManualEventThreadStatus.Name = "lblManualEventThreadStatus";
		this.lblManualEventThreadStatus.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblManualEventThreadStatus.RightToLeft")));
		this.lblManualEventThreadStatus.Size = ((System.Drawing.Size)(resources.GetObject("lblManualEventThreadStatus.Size")));
		this.lblManualEventThreadStatus.TabIndex = ((int)(resources.GetObject("lblManualEventThreadStatus.TabIndex")));
		this.lblManualEventThreadStatus.Text = resources.GetString("lblManualEventThreadStatus.Text");
		this.lblManualEventThreadStatus.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblManualEventThreadStatus.TextAlign")));
		this.lblManualEventThreadStatus.Visible = ((bool)(resources.GetObject("lblManualEventThreadStatus.Visible")));
		// 
		// MutexGroupBox
		// 
		this.MutexGroupBox.AccessibleDescription = resources.GetString("MutexGroupBox.AccessibleDescription");
		this.MutexGroupBox.AccessibleName = resources.GetString("MutexGroupBox.AccessibleName");
		this.MutexGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("MutexGroupBox.Anchor")));
		this.MutexGroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MutexGroupBox.BackgroundImage")));
		this.MutexGroupBox.Controls.Add(this.lblMutexIsPoolThread);
		this.MutexGroupBox.Controls.Add(this.Label10);
		this.MutexGroupBox.Controls.Add(this.lblMutexThreadNum);
		this.MutexGroupBox.Controls.Add(this.Label13);
		this.MutexGroupBox.Controls.Add(this.lblMutexThreadStatus);
		this.MutexGroupBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("MutexGroupBox.Dock")));
		this.MutexGroupBox.Enabled = ((bool)(resources.GetObject("MutexGroupBox.Enabled")));
		this.MutexGroupBox.Font = ((System.Drawing.Font)(resources.GetObject("MutexGroupBox.Font")));
		this.MutexGroupBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("MutexGroupBox.ImeMode")));
		this.MutexGroupBox.Location = ((System.Drawing.Point)(resources.GetObject("MutexGroupBox.Location")));
		this.MutexGroupBox.Name = "MutexGroupBox";
		this.MutexGroupBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("MutexGroupBox.RightToLeft")));
		this.MutexGroupBox.Size = ((System.Drawing.Size)(resources.GetObject("MutexGroupBox.Size")));
		this.MutexGroupBox.TabIndex = ((int)(resources.GetObject("MutexGroupBox.TabIndex")));
		this.MutexGroupBox.TabStop = false;
		this.MutexGroupBox.Text = resources.GetString("MutexGroupBox.Text");
		this.MutexGroupBox.Visible = ((bool)(resources.GetObject("MutexGroupBox.Visible")));
		// 
		// lblMutexIsPoolThread
		// 
		this.lblMutexIsPoolThread.AccessibleDescription = resources.GetString("lblMutexIsPoolThread.AccessibleDescription");
		this.lblMutexIsPoolThread.AccessibleName = resources.GetString("lblMutexIsPoolThread.AccessibleName");
		this.lblMutexIsPoolThread.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblMutexIsPoolThread.Anchor")));
		this.lblMutexIsPoolThread.AutoSize = ((bool)(resources.GetObject("lblMutexIsPoolThread.AutoSize")));
		this.lblMutexIsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblMutexIsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblMutexIsPoolThread.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblMutexIsPoolThread.Dock")));
		this.lblMutexIsPoolThread.Enabled = ((bool)(resources.GetObject("lblMutexIsPoolThread.Enabled")));
		this.lblMutexIsPoolThread.Font = ((System.Drawing.Font)(resources.GetObject("lblMutexIsPoolThread.Font")));
		this.lblMutexIsPoolThread.Image = ((System.Drawing.Image)(resources.GetObject("lblMutexIsPoolThread.Image")));
		this.lblMutexIsPoolThread.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMutexIsPoolThread.ImageAlign")));
		this.lblMutexIsPoolThread.ImageIndex = ((int)(resources.GetObject("lblMutexIsPoolThread.ImageIndex")));
		this.lblMutexIsPoolThread.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblMutexIsPoolThread.ImeMode")));
		this.lblMutexIsPoolThread.Location = ((System.Drawing.Point)(resources.GetObject("lblMutexIsPoolThread.Location")));
		this.lblMutexIsPoolThread.Name = "lblMutexIsPoolThread";
		this.lblMutexIsPoolThread.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblMutexIsPoolThread.RightToLeft")));
		this.lblMutexIsPoolThread.Size = ((System.Drawing.Size)(resources.GetObject("lblMutexIsPoolThread.Size")));
		this.lblMutexIsPoolThread.TabIndex = ((int)(resources.GetObject("lblMutexIsPoolThread.TabIndex")));
		this.lblMutexIsPoolThread.Text = resources.GetString("lblMutexIsPoolThread.Text");
		this.lblMutexIsPoolThread.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMutexIsPoolThread.TextAlign")));
		this.lblMutexIsPoolThread.Visible = ((bool)(resources.GetObject("lblMutexIsPoolThread.Visible")));
		// 
		// Label10
		// 
		this.Label10.AccessibleDescription = resources.GetString("Label10.AccessibleDescription");
		this.Label10.AccessibleName = resources.GetString("Label10.AccessibleName");
		this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label10.Anchor")));
		this.Label10.AutoSize = ((bool)(resources.GetObject("Label10.AutoSize")));
		this.Label10.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label10.Dock")));
		this.Label10.Enabled = ((bool)(resources.GetObject("Label10.Enabled")));
		this.Label10.Font = ((System.Drawing.Font)(resources.GetObject("Label10.Font")));
		this.Label10.Image = ((System.Drawing.Image)(resources.GetObject("Label10.Image")));
		this.Label10.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label10.ImageAlign")));
		this.Label10.ImageIndex = ((int)(resources.GetObject("Label10.ImageIndex")));
		this.Label10.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label10.ImeMode")));
		this.Label10.Location = ((System.Drawing.Point)(resources.GetObject("Label10.Location")));
		this.Label10.Name = "Label10";
		this.Label10.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label10.RightToLeft")));
		this.Label10.Size = ((System.Drawing.Size)(resources.GetObject("Label10.Size")));
		this.Label10.TabIndex = ((int)(resources.GetObject("Label10.TabIndex")));
		this.Label10.Text = resources.GetString("Label10.Text");
		this.Label10.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label10.TextAlign")));
		this.Label10.Visible = ((bool)(resources.GetObject("Label10.Visible")));
		// 
		// lblMutexThreadNum
		// 
		this.lblMutexThreadNum.AccessibleDescription = resources.GetString("lblMutexThreadNum.AccessibleDescription");
		this.lblMutexThreadNum.AccessibleName = resources.GetString("lblMutexThreadNum.AccessibleName");
		this.lblMutexThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblMutexThreadNum.Anchor")));
		this.lblMutexThreadNum.AutoSize = ((bool)(resources.GetObject("lblMutexThreadNum.AutoSize")));
		this.lblMutexThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblMutexThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblMutexThreadNum.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblMutexThreadNum.Dock")));
		this.lblMutexThreadNum.Enabled = ((bool)(resources.GetObject("lblMutexThreadNum.Enabled")));
		this.lblMutexThreadNum.Font = ((System.Drawing.Font)(resources.GetObject("lblMutexThreadNum.Font")));
		this.lblMutexThreadNum.Image = ((System.Drawing.Image)(resources.GetObject("lblMutexThreadNum.Image")));
		this.lblMutexThreadNum.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMutexThreadNum.ImageAlign")));
		this.lblMutexThreadNum.ImageIndex = ((int)(resources.GetObject("lblMutexThreadNum.ImageIndex")));
		this.lblMutexThreadNum.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblMutexThreadNum.ImeMode")));
		this.lblMutexThreadNum.Location = ((System.Drawing.Point)(resources.GetObject("lblMutexThreadNum.Location")));
		this.lblMutexThreadNum.Name = "lblMutexThreadNum";
		this.lblMutexThreadNum.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblMutexThreadNum.RightToLeft")));
		this.lblMutexThreadNum.Size = ((System.Drawing.Size)(resources.GetObject("lblMutexThreadNum.Size")));
		this.lblMutexThreadNum.TabIndex = ((int)(resources.GetObject("lblMutexThreadNum.TabIndex")));
		this.lblMutexThreadNum.Text = resources.GetString("lblMutexThreadNum.Text");
		this.lblMutexThreadNum.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMutexThreadNum.TextAlign")));
		this.lblMutexThreadNum.Visible = ((bool)(resources.GetObject("lblMutexThreadNum.Visible")));
		// 
		// Label13
		// 
		this.Label13.AccessibleDescription = resources.GetString("Label13.AccessibleDescription");
		this.Label13.AccessibleName = resources.GetString("Label13.AccessibleName");
		this.Label13.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label13.Anchor")));
		this.Label13.AutoSize = ((bool)(resources.GetObject("Label13.AutoSize")));
		this.Label13.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label13.Dock")));
		this.Label13.Enabled = ((bool)(resources.GetObject("Label13.Enabled")));
		this.Label13.Font = ((System.Drawing.Font)(resources.GetObject("Label13.Font")));
		this.Label13.Image = ((System.Drawing.Image)(resources.GetObject("Label13.Image")));
		this.Label13.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label13.ImageAlign")));
		this.Label13.ImageIndex = ((int)(resources.GetObject("Label13.ImageIndex")));
		this.Label13.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label13.ImeMode")));
		this.Label13.Location = ((System.Drawing.Point)(resources.GetObject("Label13.Location")));
		this.Label13.Name = "Label13";
		this.Label13.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label13.RightToLeft")));
		this.Label13.Size = ((System.Drawing.Size)(resources.GetObject("Label13.Size")));
		this.Label13.TabIndex = ((int)(resources.GetObject("Label13.TabIndex")));
		this.Label13.Text = resources.GetString("Label13.Text");
		this.Label13.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label13.TextAlign")));
		this.Label13.Visible = ((bool)(resources.GetObject("Label13.Visible")));
		// 
		// lblMutexThreadStatus
		// 
		this.lblMutexThreadStatus.AccessibleDescription = resources.GetString("lblMutexThreadStatus.AccessibleDescription");
		this.lblMutexThreadStatus.AccessibleName = resources.GetString("lblMutexThreadStatus.AccessibleName");
		this.lblMutexThreadStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblMutexThreadStatus.Anchor")));
		this.lblMutexThreadStatus.AutoSize = ((bool)(resources.GetObject("lblMutexThreadStatus.AutoSize")));
		this.lblMutexThreadStatus.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblMutexThreadStatus.Dock")));
		this.lblMutexThreadStatus.Enabled = ((bool)(resources.GetObject("lblMutexThreadStatus.Enabled")));
		this.lblMutexThreadStatus.Font = ((System.Drawing.Font)(resources.GetObject("lblMutexThreadStatus.Font")));
		this.lblMutexThreadStatus.ForeColor = System.Drawing.Color.Red;
		this.lblMutexThreadStatus.Image = ((System.Drawing.Image)(resources.GetObject("lblMutexThreadStatus.Image")));
		this.lblMutexThreadStatus.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMutexThreadStatus.ImageAlign")));
		this.lblMutexThreadStatus.ImageIndex = ((int)(resources.GetObject("lblMutexThreadStatus.ImageIndex")));
		this.lblMutexThreadStatus.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblMutexThreadStatus.ImeMode")));
		this.lblMutexThreadStatus.Location = ((System.Drawing.Point)(resources.GetObject("lblMutexThreadStatus.Location")));
		this.lblMutexThreadStatus.Name = "lblMutexThreadStatus";
		this.lblMutexThreadStatus.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblMutexThreadStatus.RightToLeft")));
		this.lblMutexThreadStatus.Size = ((System.Drawing.Size)(resources.GetObject("lblMutexThreadStatus.Size")));
		this.lblMutexThreadStatus.TabIndex = ((int)(resources.GetObject("lblMutexThreadStatus.TabIndex")));
		this.lblMutexThreadStatus.Text = resources.GetString("lblMutexThreadStatus.Text");
		this.lblMutexThreadStatus.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMutexThreadStatus.TextAlign")));
		this.lblMutexThreadStatus.Visible = ((bool)(resources.GetObject("lblMutexThreadStatus.Visible")));
		// 
		// frmMain
		// 
		this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
		this.AccessibleName = resources.GetString("$this.AccessibleName");
		this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
		this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
		this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
		this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
		this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
		this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
		this.Controls.Add(this.MainTabControl);
		this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
		this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
		this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
		this.MaximizeBox = false;
		this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
		this.Menu = this.mnuMain;
		this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
		this.Name = "frmMain";
		this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
		this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
		this.Text = resources.GetString("$this.Text");
		this.Load += new System.EventHandler(this.frmMain_Load);
		this.MainTabControl.ResumeLayout(false);
		this.FunctionTabPage.ResumeLayout(false);
		this.Process3GroupBox.ResumeLayout(false);
		this.Process2GroupBox.ResumeLayout(false);
		this.Process1GroupBox.ResumeLayout(false);
		this.TimersTabPage.ResumeLayout(false);
		this.Timer2GroupBox.ResumeLayout(false);
		this.Timer1GroupBox.ResumeLayout(false);
		this.SyncObjectsTabPage.ResumeLayout(false);
		this.AutoEventGroupBox.ResumeLayout(false);
		this.ManualEventGroupBox.ResumeLayout(false);
		this.MutexGroupBox.ResumeLayout(false);
		this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "

    // This code simply shows the About form.
    private void mnuAbout_Click(object sender, System.EventArgs e)
	{
        // Open the About form in Dialog Mode
        frmAbout frm = new frmAbout();
        frm.ShowDialog(this);
        frm.Dispose();
    }

    // This code will close the form.
    private void mnuExit_Click(object sender, System.EventArgs e) 
	{
        // Close the current form
        this.Close();
    }

#endregion

    // This subroutine calls three process consecutively, without using threading.
    private void btnNonthreaded_Click(object sender, System.EventArgs e) 
	{
        // Do not allow another process to be kicked off till this one is finished.
        btnNonthreaded.Enabled = false;
        btnThreaded.Enabled = false;
        btnThreadPool.Enabled = false;
        // Prepare the shared variables to run
        ProcessGroup.PrepareToRun();
        // Run each process.
        processGroup1.Run();
        processGroup2.Run();
        processGroup3.Run();
    }

    // This subroutine releases the mutex, allowing OnMutexReleased to fire.
    private void btnReleaseMutex_Click(object sender, System.EventArgs e) 
	{
        // if mutex is released again before resetting exception will be thrown, so
        // disable the buttons to allow this.
        btnReleaseMutex.Enabled = false;
        btnSetReleaseAll.Enabled = false;
        mutex1.ReleaseMutex();
    }

    // This signals the Auto Reset event, allowing OnAutoEventset {to fire.
    private void btnSetAutoEvent_Click(object sender, System.EventArgs e) 
	{
        // Do not allow event to be set again till OnAutoEventset {finishes
        btnSetAutoEvent.Enabled = false;
        btnSetReleaseAll.Enabled = false;
       autoResetEvent1.Set();
    }

    // This signals the Manual Reset event, allowing OnManualEventset {to fire.
    private void btnSetManualEvent_Click(object sender, System.EventArgs e) 
	{
        // Do not allow the event to be set again, until it has been reset.
        btnSetManualEvent.Enabled = false;
        btnSetReleaseAll.Enabled = false;
        manualResetEvent1.Set();
    }

    // This releases the mutex, and sets the auto and manual reset events.
    private void btnSetReleaseAll_Click(object sender, System.EventArgs e) 
	{
        // Disable all release and set buttons till each finishes.
        btnReleaseMutex.Enabled = false;
        btnSetManualEvent.Enabled = false;
        btnSetAutoEvent.Enabled = false;
        btnSetReleaseAll.Enabled = false;
        mutex1.ReleaseMutex();
        manualResetEvent1.Set();
        autoResetEvent1.Set();
    }

    // This starts and stops the timers.  The button caption toggles between start and 
    // stop.
    private void btnStartStop_Click(object sender, System.EventArgs e) 
	{
        // if caption is "Start" then start a 1 second timer and a 2 second timer, 
        // and change the caption to stop, otherwise stop the timers and change the
        // caption to "Start"

		if (btnStartStop.Text == "&Start")
		{
		
			btnStartStop.Text = "&Stop";
			timerGroup1.StartTimer(1000);
			timerGroup2.StartTimer(2000);
		}
		else 
		{
			btnStartStop.Text = "&Start";
			timerGroup1.StopTimer();
			timerGroup2.StopTimer();
		}
    }

    // This subroutine calls three processes in three separate threads.
    private void btnThreaded_Click(object sender, System.EventArgs e) 
	{
        // Do not allow another process to be kicked off till this one is finished.
        btnNonthreaded.Enabled = false;
        btnThreaded.Enabled = false;
        btnThreadPool.Enabled = false;
        // Prepare the shared variables to run
        ProcessGroup.PrepareToRun();
        // Run each process in its own thread.
        processGroup1.StartThread();
        processGroup2.StartThread();
        processGroup3.StartThread();
    }

    // This subroutine calls requests the ThreadPool to run the three processes.
    private void btnThreadPool_Click(object sender, System.EventArgs e)
	{
        // Do not allow another process to be kicked off till this one is finished.
        btnNonthreaded.Enabled = false;
        btnThreaded.Enabled = false;
        btnThreadPool.Enabled = false;
        // Prepare the shared variables to run
        ProcessGroup.PrepareToRun();
        // Send requests to ThreadPool to run the three processes.
        processGroup1.StartPooledThread();
        processGroup2.StartPooledThread();
        processGroup3.StartPooledThread();
    }

    // This subroutine creates an auto reset event, and puts the auto reset process into
    // waiting until the event is set.
    private void btnWaitForAutoEvent_Click(object sender, System.EventArgs e) 
	{
        
        
        // Create a callback to function OnAutoEventSet
        WaitOrTimerCallback callback = new WaitOrTimerCallback(OnAutoEventSet);
        // Register the event to fire OnAutoEventset {when set, specifying it to continue 
        // to monitor the event even after it has run once.  This puts the process into
        // waiting.
        ThreadPool.RegisterWaitForSingleObject(autoResetEvent1, callback,
            null, Timeout.Infinite, false);
        // Show that process is waiting in blue.
        lblAutoEventStatus.Text = "Waiting";
        lblAutoEventStatus.ForeColor = Color.Blue;
        // Allow the event to be set, but don't let it be put into waiting again until
        // it has already been set.
        btnWaitForAutoEvent.Enabled = false;
        btnSetAutoEvent.Enabled = true;
        // if mutex and events are all in waiting status, allow SetRelease all button

        if ((! btnWaitForManualEvent.Enabled) && (! btnWaitForMutex.Enabled))
		{
            btnSetReleaseAll.Enabled = true;
        }
    }

    // This subroutine creates an manual reset event, and puts the manual reset process 
    // into waiting until the event is set.
    private void btnWaitForManualEvent_Click(object sender, System.EventArgs e) 
	{
        
        
        // Create a callback to function OnManualEventSet
        WaitOrTimerCallback callback = new WaitOrTimerCallback(OnManualEventSet);
        // Register the event to fire OnManualEventset {when set, specifying it to run
        // only once.  This puts the process into waiting.
        ThreadPool.RegisterWaitForSingleObject(manualResetEvent1, callback,
            null, Timeout.Infinite, true);
        // Show that process is waiting in blue.
        lblManualEventThreadStatus.Text = "Waiting";
        lblManualEventThreadStatus.ForeColor = Color.Blue;
        // Allow the event to be set, but don't let it be put into waiting again until
        // it has already been set.
        btnWaitForManualEvent.Enabled = false;
        btnSetManualEvent.Enabled = true;
        // if mutex and events are all in waiting status, allow SetRelease all button
        if ((! btnWaitForMutex.Enabled) && (! btnWaitForAutoEvent.Enabled))
		{
            btnSetReleaseAll.Enabled = true;
        }
    }

    // This subroutine creates an mutex, and puts the mutex process into waiting until
    // the mutex is released.
    private void btnWaitForMutex_Click(object sender, System.EventArgs e) 
	{
       
        // Create a callback to function OnMutexReleased
        WaitOrTimerCallback callback = new WaitOrTimerCallback(OnMutexReleased);
        // Register the mutex to fire OnManualEventset {when release, specifying it to run
        // only once.  This puts the process into waiting.
        ThreadPool.RegisterWaitForSingleObject(mutex1, callback, null,
            Timeout.Infinite, true);
        // Show that process is waiting in blue.
        lblMutexThreadStatus.Text = "Waiting";
        lblMutexThreadStatus.ForeColor = Color.Blue;
        // Allow the mutex to be released, but don't let it be put into waiting again 
        // until it has already been released.
        btnWaitForMutex.Enabled = false;
        btnReleaseMutex.Enabled = true;
        // if mutex and events are all in waiting status, allow SetRelease all button
        if ((! btnWaitForManualEvent.Enabled) && (! btnWaitForAutoEvent.Enabled)) 
		{
            btnSetReleaseAll.Enabled = true;
        }
    }

    // Toggles HighIntensity property for ProcessGroup  
    private void chkHighIntensity_CheckedChanged(object sender, System.EventArgs e) 
	{
        ProcessGroup.SetHighIntensity = chkHighIntensity.Checked;
    }

    // Set up all the groups and event handlers.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        processGroup1 = new ProcessGroup(lblProcess1Active, lblProcess1ThreadNum,
                                         lblProcess1IsPoolThread);
        processGroup2 = new ProcessGroup(lblProcess2Active, lblProcess2ThreadNum,
                                         lblProcess2IsPoolThread);
        processGroup3 = new ProcessGroup(lblProcess3Active, lblProcess3ThreadNum,
                                         lblProcess3IsPoolThread);

        processGroup1.Completed += new OnProcessesComplete(OnProcessesCompleted);
		processGroup2.Completed += new OnProcessesComplete(OnProcessesCompleted);
		processGroup3.Completed += new OnProcessesComplete(OnProcessesCompleted);

        ProcessGroup.PrepareToRun();

        timerGroup1 = new TimerGroup(lblTimer1Output, lblTimer1ThreadNum,
                                     lblTimer1IsThreadPool);
        timerGroup2 = new TimerGroup(lblTimer2Output, lblTimer2ThreadNum,
                                    lblTimer2IsThreadPool);
    }

    // This is the callback subroutine for when the auto reset event is set.
    private void OnAutoEventSet(object obj ,bool TimedOut)
	{
        // Show that process is running in green.
        lblAutoEventStatus.Text = "Running";
        lblAutoEventStatus.ForeColor = Color.Green;
        // Update ThreadNum label with current thread number.  GetHashCode will contain
        // a unique value for each thread.
        lblAutoEventThreadNum.Text = 
            Thread.CurrentThread.GetHashCode().ToString();
        // Update the IsThreadPooled label with Yes/No depending on whether the current
        // thread is a pool thread.

		if (Thread.CurrentThread.IsThreadPoolThread)
		{
			lblAutoEventIsPoolThread.Text = "Yes";
		}
		else 
		{
			lblAutoEventIsPoolThread.Text = "No";
		}

        // Put the current thread to sleep for 2 seconds.
        System.Threading.Thread.Sleep(2000);
        // Show that process is waiting in blue.
        lblAutoEventStatus.Text = "Waiting";
        lblAutoEventStatus.ForeColor = Color.Blue;
        // Since this is an auto reset event, reenable the set button.
        btnSetAutoEvent.Enabled = true;
        // if mutex and events are all waiting then allow SetReleaseAll button.

        if ((! btnWaitForManualEvent.Enabled) && (! btnWaitForMutex.Enabled))
		{
            btnSetReleaseAll.Enabled = true;
        }
    }

    // This is the callback subroutine for when the manual reset event is set.
    private void OnManualEventSet(object obj ,bool TimedOut )
	{
        // Show that process is running in green.
        lblManualEventThreadStatus.Text = "Running";
        lblManualEventThreadStatus.ForeColor = Color.Green;
        // Update ThreadNum label with current thread number.  GetHashCode will contain
        // a unique value for each thread.
        lblManualEventThreadNum.Text = 
            Thread.CurrentThread.GetHashCode().ToString();

        // Update the IsThreadPooled label with Yes/No depending on whether the current
        // thread is a pool thread.

		if (Thread.CurrentThread.IsThreadPoolThread)
		{
			lblManualEventIsPoolThread.Text = "Yes";
		}
		else 
		{
			lblManualEventIsPoolThread.Text = "No";
		}

        // Put the current thread to sleep for 2 seconds.
        System.Threading.Thread.Sleep(2000);

        // Show that the process is inactive in read.
        lblManualEventThreadStatus.Text = "Inactive";
        lblManualEventThreadStatus.ForeColor = Color.Red;
        // Dispose of the event.
        manualResetEvent1.Close();
        // Reenable the WaitForManualEvent button.
        btnWaitForManualEvent.Enabled = true;
    }

    // This is the callback subroutine for when the mutex is released.
    private void OnMutexReleased(Object obj ,bool TimedOut )
	{
        // Show that process is running in green.
        lblMutexThreadStatus.Text = "Running";
        lblMutexThreadStatus.ForeColor = Color.Green;
        // Update ThreadNum label with current thread number.  GetHashCode will contain
        // a unique value for each thread.
        lblMutexThreadNum.Text = Thread.CurrentThread.GetHashCode().ToString();
        // Update the IsThreadPooled label with Yes/No depending on whether the current
        // thread is a pool thread.

		if (Thread.CurrentThread.IsThreadPoolThread)
		{
			lblMutexIsPoolThread.Text = "Yes";
		}
		else 
		{
			lblMutexIsPoolThread.Text = "No";
		}

        // Put the current thread to sleep for 2 seconds.
        System.Threading.Thread.Sleep(2000);
        // Show that the process is inactive in read.
        lblMutexThreadStatus.Text = "Inactive";
        lblMutexThreadStatus.ForeColor = Color.Red;

        // Dispose of the mutex.
        mutex1.Close();
        // Reenable the WaitForMutex button.
        btnWaitForMutex.Enabled = true;
    }


//
//    // This is the subroutine that is called when all three processes are finished.
	
    private void OnProcessesCompleted()
	{
        // Get the number of seconds the processes took to run, and fill in the label.
        double secondsElapsed  = ProcessGroup.GetTicksElapsed / 1000;
        lblSecondsElapsed.Text = secondsElapsed.ToString();
        // Enable all of the process buttons.
        btnNonthreaded.Enabled = true;
        btnThreaded.Enabled = true;
        btnThreadPool.Enabled = true;
        // Reset the processed to run again.
        ProcessGroup.PrepareToRun();
    }

	private void FunctionTabPage_Click(object sender, System.EventArgs e)
	{
	
	}

	private void TimersTabPage_Click(object sender, System.EventArgs e)
	{
	
	}
}

