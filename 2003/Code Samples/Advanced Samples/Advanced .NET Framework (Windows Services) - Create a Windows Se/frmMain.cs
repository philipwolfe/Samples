//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.ServiceProcess;
using System.Windows.Forms;

public class frmMain : System.Windows.Forms.Form 
{
    private bool isServiceInstalled = false;
    private bool isServiceRunning;
    private ServiceController myService;  //' Used a reference to the service;

#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

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

    private System.Windows.Forms.Label lblInstructions;

    private System.Windows.Forms.Label lblInstallationStatus;

    private System.Windows.Forms.Button btnStart;

    private System.Windows.Forms.Button btnPause;

    private System.Windows.Forms.Button btnContinue;

    private System.Windows.Forms.Button btnStop;

    private System.Windows.Forms.StatusBar sbrServiceStatus;

    private System.Windows.Forms.Timer tmrCheckStatus;

    private System.Windows.Forms.Button btnVerifyInstall;

    private void InitializeComponent() {
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.lblInstructions = new System.Windows.Forms.Label();
		this.lblInstallationStatus = new System.Windows.Forms.Label();
		this.btnStart = new System.Windows.Forms.Button();
		this.sbrServiceStatus = new System.Windows.Forms.StatusBar();
		this.btnPause = new System.Windows.Forms.Button();
		this.btnContinue = new System.Windows.Forms.Button();
		this.btnStop = new System.Windows.Forms.Button();
		this.btnVerifyInstall = new System.Windows.Forms.Button();
		this.tmrCheckStatus = new System.Windows.Forms.Timer(this.components);
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
		// lblInstructions
		// 
		this.lblInstructions.AccessibleDescription = resources.GetString("lblInstructions.AccessibleDescription");
		this.lblInstructions.AccessibleName = resources.GetString("lblInstructions.AccessibleName");
		this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblInstructions.Anchor")));
		this.lblInstructions.AutoSize = ((bool)(resources.GetObject("lblInstructions.AutoSize")));
		this.lblInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblInstructions.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblInstructions.Dock")));
		this.lblInstructions.Enabled = ((bool)(resources.GetObject("lblInstructions.Enabled")));
		this.lblInstructions.Font = ((System.Drawing.Font)(resources.GetObject("lblInstructions.Font")));
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
		// lblInstallationStatus
		// 
		this.lblInstallationStatus.AccessibleDescription = resources.GetString("lblInstallationStatus.AccessibleDescription");
		this.lblInstallationStatus.AccessibleName = resources.GetString("lblInstallationStatus.AccessibleName");
		this.lblInstallationStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblInstallationStatus.Anchor")));
		this.lblInstallationStatus.AutoSize = ((bool)(resources.GetObject("lblInstallationStatus.AutoSize")));
		this.lblInstallationStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblInstallationStatus.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblInstallationStatus.Dock")));
		this.lblInstallationStatus.Enabled = ((bool)(resources.GetObject("lblInstallationStatus.Enabled")));
		this.lblInstallationStatus.Font = ((System.Drawing.Font)(resources.GetObject("lblInstallationStatus.Font")));
		this.lblInstallationStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.lblInstallationStatus.Image = ((System.Drawing.Image)(resources.GetObject("lblInstallationStatus.Image")));
		this.lblInstallationStatus.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstallationStatus.ImageAlign")));
		this.lblInstallationStatus.ImageIndex = ((int)(resources.GetObject("lblInstallationStatus.ImageIndex")));
		this.lblInstallationStatus.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblInstallationStatus.ImeMode")));
		this.lblInstallationStatus.Location = ((System.Drawing.Point)(resources.GetObject("lblInstallationStatus.Location")));
		this.lblInstallationStatus.Name = "lblInstallationStatus";
		this.lblInstallationStatus.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblInstallationStatus.RightToLeft")));
		this.lblInstallationStatus.Size = ((System.Drawing.Size)(resources.GetObject("lblInstallationStatus.Size")));
		this.lblInstallationStatus.TabIndex = ((int)(resources.GetObject("lblInstallationStatus.TabIndex")));
		this.lblInstallationStatus.Text = resources.GetString("lblInstallationStatus.Text");
		this.lblInstallationStatus.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblInstallationStatus.TextAlign")));
		this.lblInstallationStatus.Visible = ((bool)(resources.GetObject("lblInstallationStatus.Visible")));
		// 
		// btnStart
		// 
		this.btnStart.AccessibleDescription = resources.GetString("btnStart.AccessibleDescription");
		this.btnStart.AccessibleName = resources.GetString("btnStart.AccessibleName");
		this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnStart.Anchor")));
		this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
		this.btnStart.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnStart.Dock")));
		this.btnStart.Enabled = ((bool)(resources.GetObject("btnStart.Enabled")));
		this.btnStart.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnStart.FlatStyle")));
		this.btnStart.Font = ((System.Drawing.Font)(resources.GetObject("btnStart.Font")));
		this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
		this.btnStart.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnStart.ImageAlign")));
		this.btnStart.ImageIndex = ((int)(resources.GetObject("btnStart.ImageIndex")));
		this.btnStart.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnStart.ImeMode")));
		this.btnStart.Location = ((System.Drawing.Point)(resources.GetObject("btnStart.Location")));
		this.btnStart.Name = "btnStart";
		this.btnStart.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnStart.RightToLeft")));
		this.btnStart.Size = ((System.Drawing.Size)(resources.GetObject("btnStart.Size")));
		this.btnStart.TabIndex = ((int)(resources.GetObject("btnStart.TabIndex")));
		this.btnStart.Text = resources.GetString("btnStart.Text");
		this.btnStart.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnStart.TextAlign")));
		this.btnStart.Visible = ((bool)(resources.GetObject("btnStart.Visible")));
		this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
		// 
		// sbrServiceStatus
		// 
		this.sbrServiceStatus.AccessibleDescription = resources.GetString("sbrServiceStatus.AccessibleDescription");
		this.sbrServiceStatus.AccessibleName = resources.GetString("sbrServiceStatus.AccessibleName");
		this.sbrServiceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("sbrServiceStatus.Anchor")));
		this.sbrServiceStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbrServiceStatus.BackgroundImage")));
		this.sbrServiceStatus.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("sbrServiceStatus.Dock")));
		this.sbrServiceStatus.Enabled = ((bool)(resources.GetObject("sbrServiceStatus.Enabled")));
		this.sbrServiceStatus.Font = ((System.Drawing.Font)(resources.GetObject("sbrServiceStatus.Font")));
		this.sbrServiceStatus.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("sbrServiceStatus.ImeMode")));
		this.sbrServiceStatus.Location = ((System.Drawing.Point)(resources.GetObject("sbrServiceStatus.Location")));
		this.sbrServiceStatus.Name = "sbrServiceStatus";
		this.sbrServiceStatus.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("sbrServiceStatus.RightToLeft")));
		this.sbrServiceStatus.Size = ((System.Drawing.Size)(resources.GetObject("sbrServiceStatus.Size")));
		this.sbrServiceStatus.TabIndex = ((int)(resources.GetObject("sbrServiceStatus.TabIndex")));
		this.sbrServiceStatus.Text = resources.GetString("sbrServiceStatus.Text");
		this.sbrServiceStatus.Visible = ((bool)(resources.GetObject("sbrServiceStatus.Visible")));
		// 
		// btnPause
		// 
		this.btnPause.AccessibleDescription = resources.GetString("btnPause.AccessibleDescription");
		this.btnPause.AccessibleName = resources.GetString("btnPause.AccessibleName");
		this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnPause.Anchor")));
		this.btnPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPause.BackgroundImage")));
		this.btnPause.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnPause.Dock")));
		this.btnPause.Enabled = ((bool)(resources.GetObject("btnPause.Enabled")));
		this.btnPause.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnPause.FlatStyle")));
		this.btnPause.Font = ((System.Drawing.Font)(resources.GetObject("btnPause.Font")));
		this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
		this.btnPause.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnPause.ImageAlign")));
		this.btnPause.ImageIndex = ((int)(resources.GetObject("btnPause.ImageIndex")));
		this.btnPause.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnPause.ImeMode")));
		this.btnPause.Location = ((System.Drawing.Point)(resources.GetObject("btnPause.Location")));
		this.btnPause.Name = "btnPause";
		this.btnPause.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnPause.RightToLeft")));
		this.btnPause.Size = ((System.Drawing.Size)(resources.GetObject("btnPause.Size")));
		this.btnPause.TabIndex = ((int)(resources.GetObject("btnPause.TabIndex")));
		this.btnPause.Text = resources.GetString("btnPause.Text");
		this.btnPause.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnPause.TextAlign")));
		this.btnPause.Visible = ((bool)(resources.GetObject("btnPause.Visible")));
		this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
		// 
		// btnContinue
		// 
		this.btnContinue.AccessibleDescription = resources.GetString("btnContinue.AccessibleDescription");
		this.btnContinue.AccessibleName = resources.GetString("btnContinue.AccessibleName");
		this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnContinue.Anchor")));
		this.btnContinue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContinue.BackgroundImage")));
		this.btnContinue.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnContinue.Dock")));
		this.btnContinue.Enabled = ((bool)(resources.GetObject("btnContinue.Enabled")));
		this.btnContinue.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnContinue.FlatStyle")));
		this.btnContinue.Font = ((System.Drawing.Font)(resources.GetObject("btnContinue.Font")));
		this.btnContinue.Image = ((System.Drawing.Image)(resources.GetObject("btnContinue.Image")));
		this.btnContinue.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnContinue.ImageAlign")));
		this.btnContinue.ImageIndex = ((int)(resources.GetObject("btnContinue.ImageIndex")));
		this.btnContinue.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnContinue.ImeMode")));
		this.btnContinue.Location = ((System.Drawing.Point)(resources.GetObject("btnContinue.Location")));
		this.btnContinue.Name = "btnContinue";
		this.btnContinue.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnContinue.RightToLeft")));
		this.btnContinue.Size = ((System.Drawing.Size)(resources.GetObject("btnContinue.Size")));
		this.btnContinue.TabIndex = ((int)(resources.GetObject("btnContinue.TabIndex")));
		this.btnContinue.Text = resources.GetString("btnContinue.Text");
		this.btnContinue.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnContinue.TextAlign")));
		this.btnContinue.Visible = ((bool)(resources.GetObject("btnContinue.Visible")));
		this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
		// 
		// btnStop
		// 
		this.btnStop.AccessibleDescription = resources.GetString("btnStop.AccessibleDescription");
		this.btnStop.AccessibleName = resources.GetString("btnStop.AccessibleName");
		this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnStop.Anchor")));
		this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
		this.btnStop.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnStop.Dock")));
		this.btnStop.Enabled = ((bool)(resources.GetObject("btnStop.Enabled")));
		this.btnStop.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnStop.FlatStyle")));
		this.btnStop.Font = ((System.Drawing.Font)(resources.GetObject("btnStop.Font")));
		this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
		this.btnStop.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnStop.ImageAlign")));
		this.btnStop.ImageIndex = ((int)(resources.GetObject("btnStop.ImageIndex")));
		this.btnStop.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnStop.ImeMode")));
		this.btnStop.Location = ((System.Drawing.Point)(resources.GetObject("btnStop.Location")));
		this.btnStop.Name = "btnStop";
		this.btnStop.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnStop.RightToLeft")));
		this.btnStop.Size = ((System.Drawing.Size)(resources.GetObject("btnStop.Size")));
		this.btnStop.TabIndex = ((int)(resources.GetObject("btnStop.TabIndex")));
		this.btnStop.Text = resources.GetString("btnStop.Text");
		this.btnStop.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnStop.TextAlign")));
		this.btnStop.Visible = ((bool)(resources.GetObject("btnStop.Visible")));
		this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
		// 
		// btnVerifyInstall
		// 
		this.btnVerifyInstall.AccessibleDescription = resources.GetString("btnVerifyInstall.AccessibleDescription");
		this.btnVerifyInstall.AccessibleName = resources.GetString("btnVerifyInstall.AccessibleName");
		this.btnVerifyInstall.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnVerifyInstall.Anchor")));
		this.btnVerifyInstall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerifyInstall.BackgroundImage")));
		this.btnVerifyInstall.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnVerifyInstall.Dock")));
		this.btnVerifyInstall.Enabled = ((bool)(resources.GetObject("btnVerifyInstall.Enabled")));
		this.btnVerifyInstall.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnVerifyInstall.FlatStyle")));
		this.btnVerifyInstall.Font = ((System.Drawing.Font)(resources.GetObject("btnVerifyInstall.Font")));
		this.btnVerifyInstall.Image = ((System.Drawing.Image)(resources.GetObject("btnVerifyInstall.Image")));
		this.btnVerifyInstall.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnVerifyInstall.ImageAlign")));
		this.btnVerifyInstall.ImageIndex = ((int)(resources.GetObject("btnVerifyInstall.ImageIndex")));
		this.btnVerifyInstall.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnVerifyInstall.ImeMode")));
		this.btnVerifyInstall.Location = ((System.Drawing.Point)(resources.GetObject("btnVerifyInstall.Location")));
		this.btnVerifyInstall.Name = "btnVerifyInstall";
		this.btnVerifyInstall.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnVerifyInstall.RightToLeft")));
		this.btnVerifyInstall.Size = ((System.Drawing.Size)(resources.GetObject("btnVerifyInstall.Size")));
		this.btnVerifyInstall.TabIndex = ((int)(resources.GetObject("btnVerifyInstall.TabIndex")));
		this.btnVerifyInstall.Text = resources.GetString("btnVerifyInstall.Text");
		this.btnVerifyInstall.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnVerifyInstall.TextAlign")));
		this.btnVerifyInstall.Visible = ((bool)(resources.GetObject("btnVerifyInstall.Visible")));
		this.btnVerifyInstall.Click += new System.EventHandler(this.btnVerifyInstall_Click);
		// 
		// tmrCheckStatus
		// 
		this.tmrCheckStatus.Tick += new System.EventHandler(this.tmrCheckStatus_Tick);
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
		this.Controls.Add(this.btnVerifyInstall);
		this.Controls.Add(this.btnStop);
		this.Controls.Add(this.btnContinue);
		this.Controls.Add(this.btnPause);
		this.Controls.Add(this.sbrServiceStatus);
		this.Controls.Add(this.btnStart);
		this.Controls.Add(this.lblInstallationStatus);
		this.Controls.Add(this.lblInstructions);
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
		this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "

	// This code simply shows the About form.
	private void mnuAbout_Click(object sender, System.EventArgs e) {
		// Open the About form in Dialog Mode
		frmAbout frm = new frmAbout();
		frm.ShowDialog(this);
		frm.Dispose();
	}

	// This code will close the form.
	private void mnuExit_Click(object sender, System.EventArgs e) {
		// Close the current form
		this.Close();
	}

#endregion

    // This sub forces the service to Continue
    private void btnContinue_Click(object sender, System.EventArgs e) 
	{
        myService.Continue();
        UpdateServiceStatus();
    }

    // This sub forces the service to Pause
    private void btnPause_Click(object sender, System.EventArgs e) 
	{
        myService.Pause();
        UpdateServiceStatus();
    }

    // This sub forces the service to Stop
    private void btnStop_Click(object sender, System.EventArgs e) 
	{
        myService.Stop();
        UpdateServiceStatus();
    }

    // This sub forces the service to Start
    private void btnStart_Click(object sender, System.EventArgs e) 
	{
        myService.Start();
        UpdateServiceStatus();
    }

    // This sub is used to find if the Service is currently installed.
    private void btnVerifyInstall_Click(object sender, System.EventArgs e) 
	{
        CheckServiceInstallation();
    }

    // This sub runs when the form is loaded.  Basically, it checks to
    //   see if the service is installed, and what the status is.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        // This project is only here to provide an introduction and user
        //   interface to the How-To.  The important code is in the 
        //   C# How-To Windows Service Demo project.  This is where 
        //   the Windows Service is defined.  Also important, is the 
        //   C# How-To Windows Service - Time Track Install project. 
        //   This project shows how to create a deployment project for the 
        //   Windows Service.  (You can also use InstallUtil.exe to install
        //   a service.)
        // The following code ensures that the Service is already installed.
        //   if it isn't, it directs the user to run the included MSI file.
        CheckServiceInstallation();
        UpdateServiceStatus();
        this.tmrCheckStatus.Enabled = true;
    }

    // This sub updates the Service status every time it is fired.
    private void tmrCheckStatus_Tick(object sender, System.EventArgs e) 
	{
        UpdateServiceStatus();
    }

    // Methods are below
    // CheckServiceInstallation verifies that the service is actually
    //   installed on the system. It also assigns the service
    //   to the myService class variable if it is. 
    // The assignment to myService is important and must be refreshed, since
    //   unlike most objects, the myService doesn't get changes to the
    //   status of the actual service. So it must be continually reassigned.
    private void CheckServiceInstallation()
	{
        // Verify to see if the service is installed.
        ServiceController[] installedServices;      
        int i = 0;
        // Shut off the timer so it doesn't raise events while were
        //   in this code
        this.tmrCheckStatus.Enabled = false;
        installedServices = ServiceController.GetServices();

		foreach(ServiceController tmpService in installedServices)
		{
			if (tmpService.DisplayName == "C#_NET_HowTo_TimeTrackerService")
			{
				isServiceInstalled = true;
				this.lblInstallationStatus.Text = 
					"The Windows Service is currently installed.  Use the " + 
					"Computer Management console to Start and Stop the " + 
					"service. (On Windows XP, click Start, then right-click " + 
					"My Computer, then select Manage. { click on " + 
					"Services and Applications -> Services.) || use the " + 
					"buttons below";
				// Assign the service to myService, so we can use it later.
				myService = tmpService;
			}
		}
        this.tmrCheckStatus.Enabled = true;
    }

    private void UpdateServiceStatus()
	{
        // Shut off the timer so it doesn't raise events while were
        //   in this code
        this.tmrCheckStatus.Enabled = false;

		if (!(myService == null)) 
		{
			// Recreate myServer, otherwise the status for myServer never
			//   changes, despite changes in the status of the 
			//   windows service
			CheckServiceInstallation();

			switch( myService.Status)
			{
				case ServiceControllerStatus.Stopped:
					this.btnContinue.Enabled = false;
					this.btnPause.Enabled = false;
					this.btnStart.Enabled = true;
					this.btnStop.Enabled = false;
					break;
				case ServiceControllerStatus.Running:
					this.btnContinue.Enabled = false;
					this.btnPause.Enabled = true;
					this.btnStart.Enabled = false;
					this.btnStop.Enabled = true;
					break;
				case ServiceControllerStatus.Paused:
					this.btnContinue.Enabled = true;
					this.btnPause.Enabled = false;
					this.btnStart.Enabled = false;
					this.btnStop.Enabled = true;
					break;
				default: 
					// This can occur when an action is pending. In this case
					//   don't allow the user to push any buttons.
					this.btnContinue.Enabled = false;
					this.btnPause.Enabled = false;
					this.btnStart.Enabled = false;
					this.btnStop.Enabled = false;
					break;
			}
			// Output the status to the Status Bar
			this.sbrServiceStatus.Text = "Service Status: " + myService.Status.ToString();
		}
		else 
		{
			// The service isn't running so everything but refresh.
			this.btnContinue.Enabled = false;
			this.btnPause.Enabled = false;
			this.btnStart.Enabled = false;
			this.btnStop.Enabled = false;
		}
        this.tmrCheckStatus.Enabled = true;
    }
}

