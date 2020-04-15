//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using RemotingSample;

public class frmMain : System.Windows.Forms.Form
{

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

	private System.Windows.Forms.Button cmdClear;

	private System.Windows.Forms.ListBox lstResponses;

	private System.Windows.Forms.Button cmdCreate;

	private System.Windows.Forms.Button cmdGet;

	private System.Windows.Forms.Button cmdUpdate;

	private System.Windows.Forms.Button cmdRelease;

	private System.Windows.Forms.Button cmdDebugData;

	private System.Windows.Forms.GroupBox gbInputData;

	private System.Windows.Forms.TextBox txtnewAge;

	private System.Windows.Forms.TextBox txtnewName;

	private System.Windows.Forms.Label Label1;

	private System.Windows.Forms.Label Label2;

	private System.Windows.Forms.Label lblDefAgeValue;

	private System.Windows.Forms.Label lblDefNameValue;

	private System.Windows.Forms.Label lblDefAge;

	private System.Windows.Forms.Label lblDefName;

	private System.Windows.Forms.Button cmdUpdateAndGet;

	private System.Windows.Forms.GroupBox gbTwo;

	private System.Windows.Forms.RadioButton rbClient;

	private System.Windows.Forms.RadioButton rbSingle;

	private System.Windows.Forms.GroupBox gbSingle;

	private System.Windows.Forms.Button cmdSingleDebug;

	private System.Windows.Forms.Button cmdSingleCall;

	private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.cmdClear = new System.Windows.Forms.Button();
		this.lstResponses = new System.Windows.Forms.ListBox();
		this.gbTwo = new System.Windows.Forms.GroupBox();
		this.rbSingle = new System.Windows.Forms.RadioButton();
		this.rbClient = new System.Windows.Forms.RadioButton();
		this.cmdUpdateAndGet = new System.Windows.Forms.Button();
		this.cmdDebugData = new System.Windows.Forms.Button();
		this.cmdRelease = new System.Windows.Forms.Button();
		this.cmdUpdate = new System.Windows.Forms.Button();
		this.cmdGet = new System.Windows.Forms.Button();
		this.cmdCreate = new System.Windows.Forms.Button();
		this.gbInputData = new System.Windows.Forms.GroupBox();
		this.txtnewAge = new System.Windows.Forms.TextBox();
		this.txtnewName = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.lblDefAgeValue = new System.Windows.Forms.Label();
		this.lblDefNameValue = new System.Windows.Forms.Label();
		this.lblDefAge = new System.Windows.Forms.Label();
		this.lblDefName = new System.Windows.Forms.Label();
		this.gbSingle = new System.Windows.Forms.GroupBox();
		this.cmdSingleDebug = new System.Windows.Forms.Button();
		this.cmdSingleCall = new System.Windows.Forms.Button();
		this.gbTwo.SuspendLayout();
		this.gbInputData.SuspendLayout();
		this.gbSingle.SuspendLayout();
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
		// cmdClear
		// 
		this.cmdClear.AccessibleDescription = resources.GetString("cmdClear.AccessibleDescription");
		this.cmdClear.AccessibleName = resources.GetString("cmdClear.AccessibleName");
		this.cmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdClear.Anchor")));
		this.cmdClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdClear.BackgroundImage")));
		this.cmdClear.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdClear.Dock")));
		this.cmdClear.Enabled = ((bool)(resources.GetObject("cmdClear.Enabled")));
		this.cmdClear.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdClear.FlatStyle")));
		this.cmdClear.Font = ((System.Drawing.Font)(resources.GetObject("cmdClear.Font")));
		this.cmdClear.Image = ((System.Drawing.Image)(resources.GetObject("cmdClear.Image")));
		this.cmdClear.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdClear.ImageAlign")));
		this.cmdClear.ImageIndex = ((int)(resources.GetObject("cmdClear.ImageIndex")));
		this.cmdClear.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdClear.ImeMode")));
		this.cmdClear.Location = ((System.Drawing.Point)(resources.GetObject("cmdClear.Location")));
		this.cmdClear.Name = "cmdClear";
		this.cmdClear.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdClear.RightToLeft")));
		this.cmdClear.Size = ((System.Drawing.Size)(resources.GetObject("cmdClear.Size")));
		this.cmdClear.TabIndex = ((int)(resources.GetObject("cmdClear.TabIndex")));
		this.cmdClear.Text = resources.GetString("cmdClear.Text");
		this.cmdClear.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdClear.TextAlign")));
		this.cmdClear.Visible = ((bool)(resources.GetObject("cmdClear.Visible")));
		this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
		// 
		// lstResponses
		// 
		this.lstResponses.AccessibleDescription = resources.GetString("lstResponses.AccessibleDescription");
		this.lstResponses.AccessibleName = resources.GetString("lstResponses.AccessibleName");
		this.lstResponses.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lstResponses.Anchor")));
		this.lstResponses.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lstResponses.BackgroundImage")));
		this.lstResponses.ColumnWidth = ((int)(resources.GetObject("lstResponses.ColumnWidth")));
		this.lstResponses.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lstResponses.Dock")));
		this.lstResponses.Enabled = ((bool)(resources.GetObject("lstResponses.Enabled")));
		this.lstResponses.Font = ((System.Drawing.Font)(resources.GetObject("lstResponses.Font")));
		this.lstResponses.HorizontalExtent = ((int)(resources.GetObject("lstResponses.HorizontalExtent")));
		this.lstResponses.HorizontalScrollbar = ((bool)(resources.GetObject("lstResponses.HorizontalScrollbar")));
		this.lstResponses.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lstResponses.ImeMode")));
		this.lstResponses.IntegralHeight = ((bool)(resources.GetObject("lstResponses.IntegralHeight")));
		this.lstResponses.ItemHeight = ((int)(resources.GetObject("lstResponses.ItemHeight")));
		this.lstResponses.Location = ((System.Drawing.Point)(resources.GetObject("lstResponses.Location")));
		this.lstResponses.Name = "lstResponses";
		this.lstResponses.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lstResponses.RightToLeft")));
		this.lstResponses.ScrollAlwaysVisible = ((bool)(resources.GetObject("lstResponses.ScrollAlwaysVisible")));
		this.lstResponses.Size = ((System.Drawing.Size)(resources.GetObject("lstResponses.Size")));
		this.lstResponses.TabIndex = ((int)(resources.GetObject("lstResponses.TabIndex")));
		this.lstResponses.Visible = ((bool)(resources.GetObject("lstResponses.Visible")));
		// 
		// gbTwo
		// 
		this.gbTwo.AccessibleDescription = resources.GetString("gbTwo.AccessibleDescription");
		this.gbTwo.AccessibleName = resources.GetString("gbTwo.AccessibleName");
		this.gbTwo.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gbTwo.Anchor")));
		this.gbTwo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbTwo.BackgroundImage")));
		this.gbTwo.Controls.Add(this.rbSingle);
		this.gbTwo.Controls.Add(this.rbClient);
		this.gbTwo.Controls.Add(this.cmdUpdateAndGet);
		this.gbTwo.Controls.Add(this.cmdDebugData);
		this.gbTwo.Controls.Add(this.cmdRelease);
		this.gbTwo.Controls.Add(this.cmdUpdate);
		this.gbTwo.Controls.Add(this.cmdGet);
		this.gbTwo.Controls.Add(this.cmdCreate);
		this.gbTwo.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("gbTwo.Dock")));
		this.gbTwo.Enabled = ((bool)(resources.GetObject("gbTwo.Enabled")));
		this.gbTwo.Font = ((System.Drawing.Font)(resources.GetObject("gbTwo.Font")));
		this.gbTwo.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gbTwo.ImeMode")));
		this.gbTwo.Location = ((System.Drawing.Point)(resources.GetObject("gbTwo.Location")));
		this.gbTwo.Name = "gbTwo";
		this.gbTwo.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("gbTwo.RightToLeft")));
		this.gbTwo.Size = ((System.Drawing.Size)(resources.GetObject("gbTwo.Size")));
		this.gbTwo.TabIndex = ((int)(resources.GetObject("gbTwo.TabIndex")));
		this.gbTwo.TabStop = false;
		this.gbTwo.Text = resources.GetString("gbTwo.Text");
		this.gbTwo.Visible = ((bool)(resources.GetObject("gbTwo.Visible")));
		// 
		// rbSingle
		// 
		this.rbSingle.AccessibleDescription = resources.GetString("rbSingle.AccessibleDescription");
		this.rbSingle.AccessibleName = resources.GetString("rbSingle.AccessibleName");
		this.rbSingle.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rbSingle.Anchor")));
		this.rbSingle.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rbSingle.Appearance")));
		this.rbSingle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbSingle.BackgroundImage")));
		this.rbSingle.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rbSingle.CheckAlign")));
		this.rbSingle.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rbSingle.Dock")));
		this.rbSingle.Enabled = ((bool)(resources.GetObject("rbSingle.Enabled")));
		this.rbSingle.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rbSingle.FlatStyle")));
		this.rbSingle.Font = ((System.Drawing.Font)(resources.GetObject("rbSingle.Font")));
		this.rbSingle.Image = ((System.Drawing.Image)(resources.GetObject("rbSingle.Image")));
		this.rbSingle.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rbSingle.ImageAlign")));
		this.rbSingle.ImageIndex = ((int)(resources.GetObject("rbSingle.ImageIndex")));
		this.rbSingle.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rbSingle.ImeMode")));
		this.rbSingle.Location = ((System.Drawing.Point)(resources.GetObject("rbSingle.Location")));
		this.rbSingle.Name = "rbSingle";
		this.rbSingle.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rbSingle.RightToLeft")));
		this.rbSingle.Size = ((System.Drawing.Size)(resources.GetObject("rbSingle.Size")));
		this.rbSingle.TabIndex = ((int)(resources.GetObject("rbSingle.TabIndex")));
		this.rbSingle.Text = resources.GetString("rbSingle.Text");
		this.rbSingle.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rbSingle.TextAlign")));
		this.rbSingle.Visible = ((bool)(resources.GetObject("rbSingle.Visible")));
		// 
		// rbClient
		// 
		this.rbClient.AccessibleDescription = resources.GetString("rbClient.AccessibleDescription");
		this.rbClient.AccessibleName = resources.GetString("rbClient.AccessibleName");
		this.rbClient.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("rbClient.Anchor")));
		this.rbClient.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("rbClient.Appearance")));
		this.rbClient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rbClient.BackgroundImage")));
		this.rbClient.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rbClient.CheckAlign")));
		this.rbClient.Checked = true;
		this.rbClient.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("rbClient.Dock")));
		this.rbClient.Enabled = ((bool)(resources.GetObject("rbClient.Enabled")));
		this.rbClient.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("rbClient.FlatStyle")));
		this.rbClient.Font = ((System.Drawing.Font)(resources.GetObject("rbClient.Font")));
		this.rbClient.Image = ((System.Drawing.Image)(resources.GetObject("rbClient.Image")));
		this.rbClient.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rbClient.ImageAlign")));
		this.rbClient.ImageIndex = ((int)(resources.GetObject("rbClient.ImageIndex")));
		this.rbClient.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("rbClient.ImeMode")));
		this.rbClient.Location = ((System.Drawing.Point)(resources.GetObject("rbClient.Location")));
		this.rbClient.Name = "rbClient";
		this.rbClient.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("rbClient.RightToLeft")));
		this.rbClient.Size = ((System.Drawing.Size)(resources.GetObject("rbClient.Size")));
		this.rbClient.TabIndex = ((int)(resources.GetObject("rbClient.TabIndex")));
		this.rbClient.TabStop = true;
		this.rbClient.Text = resources.GetString("rbClient.Text");
		this.rbClient.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("rbClient.TextAlign")));
		this.rbClient.Visible = ((bool)(resources.GetObject("rbClient.Visible")));
		// 
		// cmdUpdateAndGet
		// 
		this.cmdUpdateAndGet.AccessibleDescription = resources.GetString("cmdUpdateAndGet.AccessibleDescription");
		this.cmdUpdateAndGet.AccessibleName = resources.GetString("cmdUpdateAndGet.AccessibleName");
		this.cmdUpdateAndGet.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdUpdateAndGet.Anchor")));
		this.cmdUpdateAndGet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdUpdateAndGet.BackgroundImage")));
		this.cmdUpdateAndGet.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdUpdateAndGet.Dock")));
		this.cmdUpdateAndGet.Enabled = ((bool)(resources.GetObject("cmdUpdateAndGet.Enabled")));
		this.cmdUpdateAndGet.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdUpdateAndGet.FlatStyle")));
		this.cmdUpdateAndGet.Font = ((System.Drawing.Font)(resources.GetObject("cmdUpdateAndGet.Font")));
		this.cmdUpdateAndGet.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdateAndGet.Image")));
		this.cmdUpdateAndGet.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdUpdateAndGet.ImageAlign")));
		this.cmdUpdateAndGet.ImageIndex = ((int)(resources.GetObject("cmdUpdateAndGet.ImageIndex")));
		this.cmdUpdateAndGet.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdUpdateAndGet.ImeMode")));
		this.cmdUpdateAndGet.Location = ((System.Drawing.Point)(resources.GetObject("cmdUpdateAndGet.Location")));
		this.cmdUpdateAndGet.Name = "cmdUpdateAndGet";
		this.cmdUpdateAndGet.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdUpdateAndGet.RightToLeft")));
		this.cmdUpdateAndGet.Size = ((System.Drawing.Size)(resources.GetObject("cmdUpdateAndGet.Size")));
		this.cmdUpdateAndGet.TabIndex = ((int)(resources.GetObject("cmdUpdateAndGet.TabIndex")));
		this.cmdUpdateAndGet.Text = resources.GetString("cmdUpdateAndGet.Text");
		this.cmdUpdateAndGet.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdUpdateAndGet.TextAlign")));
		this.cmdUpdateAndGet.Visible = ((bool)(resources.GetObject("cmdUpdateAndGet.Visible")));
		this.cmdUpdateAndGet.Click += new System.EventHandler(this.cmdUpdateAndGet_Click);
		// 
		// cmdDebugData
		// 
		this.cmdDebugData.AccessibleDescription = resources.GetString("cmdDebugData.AccessibleDescription");
		this.cmdDebugData.AccessibleName = resources.GetString("cmdDebugData.AccessibleName");
		this.cmdDebugData.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdDebugData.Anchor")));
		this.cmdDebugData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdDebugData.BackgroundImage")));
		this.cmdDebugData.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdDebugData.Dock")));
		this.cmdDebugData.Enabled = ((bool)(resources.GetObject("cmdDebugData.Enabled")));
		this.cmdDebugData.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdDebugData.FlatStyle")));
		this.cmdDebugData.Font = ((System.Drawing.Font)(resources.GetObject("cmdDebugData.Font")));
		this.cmdDebugData.Image = ((System.Drawing.Image)(resources.GetObject("cmdDebugData.Image")));
		this.cmdDebugData.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdDebugData.ImageAlign")));
		this.cmdDebugData.ImageIndex = ((int)(resources.GetObject("cmdDebugData.ImageIndex")));
		this.cmdDebugData.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdDebugData.ImeMode")));
		this.cmdDebugData.Location = ((System.Drawing.Point)(resources.GetObject("cmdDebugData.Location")));
		this.cmdDebugData.Name = "cmdDebugData";
		this.cmdDebugData.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdDebugData.RightToLeft")));
		this.cmdDebugData.Size = ((System.Drawing.Size)(resources.GetObject("cmdDebugData.Size")));
		this.cmdDebugData.TabIndex = ((int)(resources.GetObject("cmdDebugData.TabIndex")));
		this.cmdDebugData.Text = resources.GetString("cmdDebugData.Text");
		this.cmdDebugData.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdDebugData.TextAlign")));
		this.cmdDebugData.Visible = ((bool)(resources.GetObject("cmdDebugData.Visible")));
		this.cmdDebugData.Click += new System.EventHandler(this.cmdDebugData_Click);
		// 
		// cmdRelease
		// 
		this.cmdRelease.AccessibleDescription = resources.GetString("cmdRelease.AccessibleDescription");
		this.cmdRelease.AccessibleName = resources.GetString("cmdRelease.AccessibleName");
		this.cmdRelease.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdRelease.Anchor")));
		this.cmdRelease.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdRelease.BackgroundImage")));
		this.cmdRelease.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdRelease.Dock")));
		this.cmdRelease.Enabled = ((bool)(resources.GetObject("cmdRelease.Enabled")));
		this.cmdRelease.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdRelease.FlatStyle")));
		this.cmdRelease.Font = ((System.Drawing.Font)(resources.GetObject("cmdRelease.Font")));
		this.cmdRelease.Image = ((System.Drawing.Image)(resources.GetObject("cmdRelease.Image")));
		this.cmdRelease.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdRelease.ImageAlign")));
		this.cmdRelease.ImageIndex = ((int)(resources.GetObject("cmdRelease.ImageIndex")));
		this.cmdRelease.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdRelease.ImeMode")));
		this.cmdRelease.Location = ((System.Drawing.Point)(resources.GetObject("cmdRelease.Location")));
		this.cmdRelease.Name = "cmdRelease";
		this.cmdRelease.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdRelease.RightToLeft")));
		this.cmdRelease.Size = ((System.Drawing.Size)(resources.GetObject("cmdRelease.Size")));
		this.cmdRelease.TabIndex = ((int)(resources.GetObject("cmdRelease.TabIndex")));
		this.cmdRelease.Text = resources.GetString("cmdRelease.Text");
		this.cmdRelease.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdRelease.TextAlign")));
		this.cmdRelease.Visible = ((bool)(resources.GetObject("cmdRelease.Visible")));
		this.cmdRelease.Click += new System.EventHandler(this.cmdRelease_Click);
		// 
		// cmdUpdate
		// 
		this.cmdUpdate.AccessibleDescription = resources.GetString("cmdUpdate.AccessibleDescription");
		this.cmdUpdate.AccessibleName = resources.GetString("cmdUpdate.AccessibleName");
		this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdUpdate.Anchor")));
		this.cmdUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdUpdate.BackgroundImage")));
		this.cmdUpdate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdUpdate.Dock")));
		this.cmdUpdate.Enabled = ((bool)(resources.GetObject("cmdUpdate.Enabled")));
		this.cmdUpdate.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdUpdate.FlatStyle")));
		this.cmdUpdate.Font = ((System.Drawing.Font)(resources.GetObject("cmdUpdate.Font")));
		this.cmdUpdate.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdate.Image")));
		this.cmdUpdate.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdUpdate.ImageAlign")));
		this.cmdUpdate.ImageIndex = ((int)(resources.GetObject("cmdUpdate.ImageIndex")));
		this.cmdUpdate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdUpdate.ImeMode")));
		this.cmdUpdate.Location = ((System.Drawing.Point)(resources.GetObject("cmdUpdate.Location")));
		this.cmdUpdate.Name = "cmdUpdate";
		this.cmdUpdate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdUpdate.RightToLeft")));
		this.cmdUpdate.Size = ((System.Drawing.Size)(resources.GetObject("cmdUpdate.Size")));
		this.cmdUpdate.TabIndex = ((int)(resources.GetObject("cmdUpdate.TabIndex")));
		this.cmdUpdate.Text = resources.GetString("cmdUpdate.Text");
		this.cmdUpdate.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdUpdate.TextAlign")));
		this.cmdUpdate.Visible = ((bool)(resources.GetObject("cmdUpdate.Visible")));
		this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
		// 
		// cmdGet
		// 
		this.cmdGet.AccessibleDescription = resources.GetString("cmdGet.AccessibleDescription");
		this.cmdGet.AccessibleName = resources.GetString("cmdGet.AccessibleName");
		this.cmdGet.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdGet.Anchor")));
		this.cmdGet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdGet.BackgroundImage")));
		this.cmdGet.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdGet.Dock")));
		this.cmdGet.Enabled = ((bool)(resources.GetObject("cmdGet.Enabled")));
		this.cmdGet.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdGet.FlatStyle")));
		this.cmdGet.Font = ((System.Drawing.Font)(resources.GetObject("cmdGet.Font")));
		this.cmdGet.Image = ((System.Drawing.Image)(resources.GetObject("cmdGet.Image")));
		this.cmdGet.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdGet.ImageAlign")));
		this.cmdGet.ImageIndex = ((int)(resources.GetObject("cmdGet.ImageIndex")));
		this.cmdGet.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdGet.ImeMode")));
		this.cmdGet.Location = ((System.Drawing.Point)(resources.GetObject("cmdGet.Location")));
		this.cmdGet.Name = "cmdGet";
		this.cmdGet.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdGet.RightToLeft")));
		this.cmdGet.Size = ((System.Drawing.Size)(resources.GetObject("cmdGet.Size")));
		this.cmdGet.TabIndex = ((int)(resources.GetObject("cmdGet.TabIndex")));
		this.cmdGet.Text = resources.GetString("cmdGet.Text");
		this.cmdGet.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdGet.TextAlign")));
		this.cmdGet.Visible = ((bool)(resources.GetObject("cmdGet.Visible")));
		this.cmdGet.Click += new System.EventHandler(this.cmdGet_Click);
		// 
		// cmdCreate
		// 
		this.cmdCreate.AccessibleDescription = resources.GetString("cmdCreate.AccessibleDescription");
		this.cmdCreate.AccessibleName = resources.GetString("cmdCreate.AccessibleName");
		this.cmdCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdCreate.Anchor")));
		this.cmdCreate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCreate.BackgroundImage")));
		this.cmdCreate.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdCreate.Dock")));
		this.cmdCreate.Enabled = ((bool)(resources.GetObject("cmdCreate.Enabled")));
		this.cmdCreate.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdCreate.FlatStyle")));
		this.cmdCreate.Font = ((System.Drawing.Font)(resources.GetObject("cmdCreate.Font")));
		this.cmdCreate.Image = ((System.Drawing.Image)(resources.GetObject("cmdCreate.Image")));
		this.cmdCreate.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdCreate.ImageAlign")));
		this.cmdCreate.ImageIndex = ((int)(resources.GetObject("cmdCreate.ImageIndex")));
		this.cmdCreate.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdCreate.ImeMode")));
		this.cmdCreate.Location = ((System.Drawing.Point)(resources.GetObject("cmdCreate.Location")));
		this.cmdCreate.Name = "cmdCreate";
		this.cmdCreate.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdCreate.RightToLeft")));
		this.cmdCreate.Size = ((System.Drawing.Size)(resources.GetObject("cmdCreate.Size")));
		this.cmdCreate.TabIndex = ((int)(resources.GetObject("cmdCreate.TabIndex")));
		this.cmdCreate.Text = resources.GetString("cmdCreate.Text");
		this.cmdCreate.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdCreate.TextAlign")));
		this.cmdCreate.Visible = ((bool)(resources.GetObject("cmdCreate.Visible")));
		this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
		// 
		// gbInputData
		// 
		this.gbInputData.AccessibleDescription = resources.GetString("gbInputData.AccessibleDescription");
		this.gbInputData.AccessibleName = resources.GetString("gbInputData.AccessibleName");
		this.gbInputData.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gbInputData.Anchor")));
		this.gbInputData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbInputData.BackgroundImage")));
		this.gbInputData.Controls.Add(this.txtnewName);
		this.gbInputData.Controls.Add(this.Label1);
		this.gbInputData.Controls.Add(this.Label2);
		this.gbInputData.Controls.Add(this.lblDefAgeValue);
		this.gbInputData.Controls.Add(this.lblDefNameValue);
		this.gbInputData.Controls.Add(this.lblDefAge);
		this.gbInputData.Controls.Add(this.lblDefName);
		this.gbInputData.Controls.Add(this.txtnewAge);
		this.gbInputData.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("gbInputData.Dock")));
		this.gbInputData.Enabled = ((bool)(resources.GetObject("gbInputData.Enabled")));
		this.gbInputData.Font = ((System.Drawing.Font)(resources.GetObject("gbInputData.Font")));
		this.gbInputData.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gbInputData.ImeMode")));
		this.gbInputData.Location = ((System.Drawing.Point)(resources.GetObject("gbInputData.Location")));
		this.gbInputData.Name = "gbInputData";
		this.gbInputData.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("gbInputData.RightToLeft")));
		this.gbInputData.Size = ((System.Drawing.Size)(resources.GetObject("gbInputData.Size")));
		this.gbInputData.TabIndex = ((int)(resources.GetObject("gbInputData.TabIndex")));
		this.gbInputData.TabStop = false;
		this.gbInputData.Text = resources.GetString("gbInputData.Text");
		this.gbInputData.Visible = ((bool)(resources.GetObject("gbInputData.Visible")));
		// 
		// txtnewAge
		// 
		this.txtnewAge.AccessibleDescription = resources.GetString("txtnewAge.AccessibleDescription");
		this.txtnewAge.AccessibleName = resources.GetString("txtnewAge.AccessibleName");
		this.txtnewAge.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtnewAge.Anchor")));
		this.txtnewAge.AutoSize = ((bool)(resources.GetObject("txtnewAge.AutoSize")));
		this.txtnewAge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtnewAge.BackgroundImage")));
		this.txtnewAge.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtnewAge.Dock")));
		this.txtnewAge.Enabled = ((bool)(resources.GetObject("txtnewAge.Enabled")));
		this.txtnewAge.Font = ((System.Drawing.Font)(resources.GetObject("txtnewAge.Font")));
		this.txtnewAge.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtnewAge.ImeMode")));
		this.txtnewAge.Location = ((System.Drawing.Point)(resources.GetObject("txtnewAge.Location")));
		this.txtnewAge.MaxLength = ((int)(resources.GetObject("txtnewAge.MaxLength")));
		this.txtnewAge.Multiline = ((bool)(resources.GetObject("txtnewAge.Multiline")));
		this.txtnewAge.Name = "txtnewAge";
		this.txtnewAge.PasswordChar = ((char)(resources.GetObject("txtnewAge.PasswordChar")));
		this.txtnewAge.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtnewAge.RightToLeft")));
		this.txtnewAge.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtnewAge.ScrollBars")));
		this.txtnewAge.Size = ((System.Drawing.Size)(resources.GetObject("txtnewAge.Size")));
		this.txtnewAge.TabIndex = ((int)(resources.GetObject("txtnewAge.TabIndex")));
		this.txtnewAge.Text = resources.GetString("txtnewAge.Text");
		this.txtnewAge.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtnewAge.TextAlign")));
		this.txtnewAge.Visible = ((bool)(resources.GetObject("txtnewAge.Visible")));
		this.txtnewAge.WordWrap = ((bool)(resources.GetObject("txtnewAge.WordWrap")));
		this.txtnewAge.Validating += new System.ComponentModel.CancelEventHandler(this.txtnewAge_Validating);
		// 
		// txtnewName
		// 
		this.txtnewName.AccessibleDescription = resources.GetString("txtnewName.AccessibleDescription");
		this.txtnewName.AccessibleName = resources.GetString("txtnewName.AccessibleName");
		this.txtnewName.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtnewName.Anchor")));
		this.txtnewName.AutoSize = ((bool)(resources.GetObject("txtnewName.AutoSize")));
		this.txtnewName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtnewName.BackgroundImage")));
		this.txtnewName.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtnewName.Dock")));
		this.txtnewName.Enabled = ((bool)(resources.GetObject("txtnewName.Enabled")));
		this.txtnewName.Font = ((System.Drawing.Font)(resources.GetObject("txtnewName.Font")));
		this.txtnewName.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtnewName.ImeMode")));
		this.txtnewName.Location = ((System.Drawing.Point)(resources.GetObject("txtnewName.Location")));
		this.txtnewName.MaxLength = ((int)(resources.GetObject("txtnewName.MaxLength")));
		this.txtnewName.Multiline = ((bool)(resources.GetObject("txtnewName.Multiline")));
		this.txtnewName.Name = "txtnewName";
		this.txtnewName.PasswordChar = ((char)(resources.GetObject("txtnewName.PasswordChar")));
		this.txtnewName.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtnewName.RightToLeft")));
		this.txtnewName.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtnewName.ScrollBars")));
		this.txtnewName.Size = ((System.Drawing.Size)(resources.GetObject("txtnewName.Size")));
		this.txtnewName.TabIndex = ((int)(resources.GetObject("txtnewName.TabIndex")));
		this.txtnewName.Text = resources.GetString("txtnewName.Text");
		this.txtnewName.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtnewName.TextAlign")));
		this.txtnewName.Visible = ((bool)(resources.GetObject("txtnewName.Visible")));
		this.txtnewName.WordWrap = ((bool)(resources.GetObject("txtnewName.WordWrap")));
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
		// lblDefAgeValue
		// 
		this.lblDefAgeValue.AccessibleDescription = resources.GetString("lblDefAgeValue.AccessibleDescription");
		this.lblDefAgeValue.AccessibleName = resources.GetString("lblDefAgeValue.AccessibleName");
		this.lblDefAgeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblDefAgeValue.Anchor")));
		this.lblDefAgeValue.AutoSize = ((bool)(resources.GetObject("lblDefAgeValue.AutoSize")));
		this.lblDefAgeValue.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblDefAgeValue.Dock")));
		this.lblDefAgeValue.Enabled = ((bool)(resources.GetObject("lblDefAgeValue.Enabled")));
		this.lblDefAgeValue.Font = ((System.Drawing.Font)(resources.GetObject("lblDefAgeValue.Font")));
		this.lblDefAgeValue.Image = ((System.Drawing.Image)(resources.GetObject("lblDefAgeValue.Image")));
		this.lblDefAgeValue.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblDefAgeValue.ImageAlign")));
		this.lblDefAgeValue.ImageIndex = ((int)(resources.GetObject("lblDefAgeValue.ImageIndex")));
		this.lblDefAgeValue.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblDefAgeValue.ImeMode")));
		this.lblDefAgeValue.Location = ((System.Drawing.Point)(resources.GetObject("lblDefAgeValue.Location")));
		this.lblDefAgeValue.Name = "lblDefAgeValue";
		this.lblDefAgeValue.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblDefAgeValue.RightToLeft")));
		this.lblDefAgeValue.Size = ((System.Drawing.Size)(resources.GetObject("lblDefAgeValue.Size")));
		this.lblDefAgeValue.TabIndex = ((int)(resources.GetObject("lblDefAgeValue.TabIndex")));
		this.lblDefAgeValue.Text = resources.GetString("lblDefAgeValue.Text");
		this.lblDefAgeValue.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblDefAgeValue.TextAlign")));
		this.lblDefAgeValue.Visible = ((bool)(resources.GetObject("lblDefAgeValue.Visible")));
		// 
		// lblDefNameValue
		// 
		this.lblDefNameValue.AccessibleDescription = resources.GetString("lblDefNameValue.AccessibleDescription");
		this.lblDefNameValue.AccessibleName = resources.GetString("lblDefNameValue.AccessibleName");
		this.lblDefNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblDefNameValue.Anchor")));
		this.lblDefNameValue.AutoSize = ((bool)(resources.GetObject("lblDefNameValue.AutoSize")));
		this.lblDefNameValue.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblDefNameValue.Dock")));
		this.lblDefNameValue.Enabled = ((bool)(resources.GetObject("lblDefNameValue.Enabled")));
		this.lblDefNameValue.Font = ((System.Drawing.Font)(resources.GetObject("lblDefNameValue.Font")));
		this.lblDefNameValue.Image = ((System.Drawing.Image)(resources.GetObject("lblDefNameValue.Image")));
		this.lblDefNameValue.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblDefNameValue.ImageAlign")));
		this.lblDefNameValue.ImageIndex = ((int)(resources.GetObject("lblDefNameValue.ImageIndex")));
		this.lblDefNameValue.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblDefNameValue.ImeMode")));
		this.lblDefNameValue.Location = ((System.Drawing.Point)(resources.GetObject("lblDefNameValue.Location")));
		this.lblDefNameValue.Name = "lblDefNameValue";
		this.lblDefNameValue.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblDefNameValue.RightToLeft")));
		this.lblDefNameValue.Size = ((System.Drawing.Size)(resources.GetObject("lblDefNameValue.Size")));
		this.lblDefNameValue.TabIndex = ((int)(resources.GetObject("lblDefNameValue.TabIndex")));
		this.lblDefNameValue.Text = resources.GetString("lblDefNameValue.Text");
		this.lblDefNameValue.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblDefNameValue.TextAlign")));
		this.lblDefNameValue.Visible = ((bool)(resources.GetObject("lblDefNameValue.Visible")));
		// 
		// lblDefAge
		// 
		this.lblDefAge.AccessibleDescription = resources.GetString("lblDefAge.AccessibleDescription");
		this.lblDefAge.AccessibleName = resources.GetString("lblDefAge.AccessibleName");
		this.lblDefAge.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblDefAge.Anchor")));
		this.lblDefAge.AutoSize = ((bool)(resources.GetObject("lblDefAge.AutoSize")));
		this.lblDefAge.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblDefAge.Dock")));
		this.lblDefAge.Enabled = ((bool)(resources.GetObject("lblDefAge.Enabled")));
		this.lblDefAge.Font = ((System.Drawing.Font)(resources.GetObject("lblDefAge.Font")));
		this.lblDefAge.Image = ((System.Drawing.Image)(resources.GetObject("lblDefAge.Image")));
		this.lblDefAge.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblDefAge.ImageAlign")));
		this.lblDefAge.ImageIndex = ((int)(resources.GetObject("lblDefAge.ImageIndex")));
		this.lblDefAge.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblDefAge.ImeMode")));
		this.lblDefAge.Location = ((System.Drawing.Point)(resources.GetObject("lblDefAge.Location")));
		this.lblDefAge.Name = "lblDefAge";
		this.lblDefAge.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblDefAge.RightToLeft")));
		this.lblDefAge.Size = ((System.Drawing.Size)(resources.GetObject("lblDefAge.Size")));
		this.lblDefAge.TabIndex = ((int)(resources.GetObject("lblDefAge.TabIndex")));
		this.lblDefAge.Text = resources.GetString("lblDefAge.Text");
		this.lblDefAge.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblDefAge.TextAlign")));
		this.lblDefAge.Visible = ((bool)(resources.GetObject("lblDefAge.Visible")));
		// 
		// lblDefName
		// 
		this.lblDefName.AccessibleDescription = resources.GetString("lblDefName.AccessibleDescription");
		this.lblDefName.AccessibleName = resources.GetString("lblDefName.AccessibleName");
		this.lblDefName.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblDefName.Anchor")));
		this.lblDefName.AutoSize = ((bool)(resources.GetObject("lblDefName.AutoSize")));
		this.lblDefName.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblDefName.Dock")));
		this.lblDefName.Enabled = ((bool)(resources.GetObject("lblDefName.Enabled")));
		this.lblDefName.Font = ((System.Drawing.Font)(resources.GetObject("lblDefName.Font")));
		this.lblDefName.Image = ((System.Drawing.Image)(resources.GetObject("lblDefName.Image")));
		this.lblDefName.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblDefName.ImageAlign")));
		this.lblDefName.ImageIndex = ((int)(resources.GetObject("lblDefName.ImageIndex")));
		this.lblDefName.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblDefName.ImeMode")));
		this.lblDefName.Location = ((System.Drawing.Point)(resources.GetObject("lblDefName.Location")));
		this.lblDefName.Name = "lblDefName";
		this.lblDefName.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblDefName.RightToLeft")));
		this.lblDefName.Size = ((System.Drawing.Size)(resources.GetObject("lblDefName.Size")));
		this.lblDefName.TabIndex = ((int)(resources.GetObject("lblDefName.TabIndex")));
		this.lblDefName.Text = resources.GetString("lblDefName.Text");
		this.lblDefName.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblDefName.TextAlign")));
		this.lblDefName.Visible = ((bool)(resources.GetObject("lblDefName.Visible")));
		// 
		// gbSingle
		// 
		this.gbSingle.AccessibleDescription = resources.GetString("gbSingle.AccessibleDescription");
		this.gbSingle.AccessibleName = resources.GetString("gbSingle.AccessibleName");
		this.gbSingle.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gbSingle.Anchor")));
		this.gbSingle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbSingle.BackgroundImage")));
		this.gbSingle.Controls.Add(this.cmdSingleDebug);
		this.gbSingle.Controls.Add(this.cmdSingleCall);
		this.gbSingle.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("gbSingle.Dock")));
		this.gbSingle.Enabled = ((bool)(resources.GetObject("gbSingle.Enabled")));
		this.gbSingle.Font = ((System.Drawing.Font)(resources.GetObject("gbSingle.Font")));
		this.gbSingle.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gbSingle.ImeMode")));
		this.gbSingle.Location = ((System.Drawing.Point)(resources.GetObject("gbSingle.Location")));
		this.gbSingle.Name = "gbSingle";
		this.gbSingle.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("gbSingle.RightToLeft")));
		this.gbSingle.Size = ((System.Drawing.Size)(resources.GetObject("gbSingle.Size")));
		this.gbSingle.TabIndex = ((int)(resources.GetObject("gbSingle.TabIndex")));
		this.gbSingle.TabStop = false;
		this.gbSingle.Text = resources.GetString("gbSingle.Text");
		this.gbSingle.Visible = ((bool)(resources.GetObject("gbSingle.Visible")));
		// 
		// cmdSingleDebug
		// 
		this.cmdSingleDebug.AccessibleDescription = resources.GetString("cmdSingleDebug.AccessibleDescription");
		this.cmdSingleDebug.AccessibleName = resources.GetString("cmdSingleDebug.AccessibleName");
		this.cmdSingleDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdSingleDebug.Anchor")));
		this.cmdSingleDebug.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSingleDebug.BackgroundImage")));
		this.cmdSingleDebug.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdSingleDebug.Dock")));
		this.cmdSingleDebug.Enabled = ((bool)(resources.GetObject("cmdSingleDebug.Enabled")));
		this.cmdSingleDebug.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdSingleDebug.FlatStyle")));
		this.cmdSingleDebug.Font = ((System.Drawing.Font)(resources.GetObject("cmdSingleDebug.Font")));
		this.cmdSingleDebug.Image = ((System.Drawing.Image)(resources.GetObject("cmdSingleDebug.Image")));
		this.cmdSingleDebug.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdSingleDebug.ImageAlign")));
		this.cmdSingleDebug.ImageIndex = ((int)(resources.GetObject("cmdSingleDebug.ImageIndex")));
		this.cmdSingleDebug.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdSingleDebug.ImeMode")));
		this.cmdSingleDebug.Location = ((System.Drawing.Point)(resources.GetObject("cmdSingleDebug.Location")));
		this.cmdSingleDebug.Name = "cmdSingleDebug";
		this.cmdSingleDebug.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdSingleDebug.RightToLeft")));
		this.cmdSingleDebug.Size = ((System.Drawing.Size)(resources.GetObject("cmdSingleDebug.Size")));
		this.cmdSingleDebug.TabIndex = ((int)(resources.GetObject("cmdSingleDebug.TabIndex")));
		this.cmdSingleDebug.Text = resources.GetString("cmdSingleDebug.Text");
		this.cmdSingleDebug.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdSingleDebug.TextAlign")));
		this.cmdSingleDebug.Visible = ((bool)(resources.GetObject("cmdSingleDebug.Visible")));
		this.cmdSingleDebug.Click += new System.EventHandler(this.cmdSingleDebug_Click);
		// 
		// cmdSingleCall
		// 
		this.cmdSingleCall.AccessibleDescription = resources.GetString("cmdSingleCall.AccessibleDescription");
		this.cmdSingleCall.AccessibleName = resources.GetString("cmdSingleCall.AccessibleName");
		this.cmdSingleCall.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cmdSingleCall.Anchor")));
		this.cmdSingleCall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSingleCall.BackgroundImage")));
		this.cmdSingleCall.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cmdSingleCall.Dock")));
		this.cmdSingleCall.Enabled = ((bool)(resources.GetObject("cmdSingleCall.Enabled")));
		this.cmdSingleCall.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("cmdSingleCall.FlatStyle")));
		this.cmdSingleCall.Font = ((System.Drawing.Font)(resources.GetObject("cmdSingleCall.Font")));
		this.cmdSingleCall.Image = ((System.Drawing.Image)(resources.GetObject("cmdSingleCall.Image")));
		this.cmdSingleCall.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdSingleCall.ImageAlign")));
		this.cmdSingleCall.ImageIndex = ((int)(resources.GetObject("cmdSingleCall.ImageIndex")));
		this.cmdSingleCall.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cmdSingleCall.ImeMode")));
		this.cmdSingleCall.Location = ((System.Drawing.Point)(resources.GetObject("cmdSingleCall.Location")));
		this.cmdSingleCall.Name = "cmdSingleCall";
		this.cmdSingleCall.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cmdSingleCall.RightToLeft")));
		this.cmdSingleCall.Size = ((System.Drawing.Size)(resources.GetObject("cmdSingleCall.Size")));
		this.cmdSingleCall.TabIndex = ((int)(resources.GetObject("cmdSingleCall.TabIndex")));
		this.cmdSingleCall.Text = resources.GetString("cmdSingleCall.Text");
		this.cmdSingleCall.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("cmdSingleCall.TextAlign")));
		this.cmdSingleCall.Visible = ((bool)(resources.GetObject("cmdSingleCall.Visible")));
		this.cmdSingleCall.Click += new System.EventHandler(this.cmdSingleCall_Click);
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
		this.Controls.Add(this.gbSingle);
		this.Controls.Add(this.gbInputData);
		this.Controls.Add(this.gbTwo);
		this.Controls.Add(this.lstResponses);
		this.Controls.Add(this.cmdClear);
		this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
		this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
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
		this.Closed += new System.EventHandler(this.frmMain_Closed);
		this.gbTwo.ResumeLayout(false);
		this.gbInputData.ResumeLayout(false);
		this.gbSingle.ResumeLayout(false);
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

	// To be used to obtain a reference to a Client Activated type
	// This is similar to DCOM style programming.
	private Customer mCustomer;
	// This is to be used when we want multiple clients to connect
	// to the same object instance on the server
	private SingletonCustomer mSCustomer;

	private void SetCtlState(bool newState)
	{
		// Ensable the create command button
		this.cmdCreate.Enabled = newState;
		// Disable other command buttons
		this.cmdGet.Enabled = (! newState);
		this.cmdUpdate.Enabled = (! newState);
		this.cmdUpdateAndGet.Enabled = (! newState);
		this.cmdDebugData.Enabled = (! newState);
		this.cmdRelease.Enabled = (! newState);
		// Set the radio buttons
		this.rbClient.Enabled = newState;
		this.rbSingle.Enabled = newState;
	}

	private void cmdClear_Click(object sender, System.EventArgs e) 
	{
		//clear all items from the listbox
		this.lstResponses.Items.Clear();
	}

	private void cmdCreate_Click(object sender, System.EventArgs e) 
	{
		string txt;		  //' Used in the catch handlers;

		try 
		{
			bool objNotCreated = false;

			if (this.rbClient.Checked == true)
			{
				// Use Client Activated Type
				// Notice that in this call to new you can pass parameters to the constructor
				// This type of object is very similar to a DCOM style object.
				mCustomer = new Customer(this.lblDefNameValue.Text, Convert.ToByte(this.lblDefAgeValue.Text));
				objNotCreated = (mCustomer == null);
			}
			else 
			{
				// Use Server Activated Type
				// Notice that you can not pass values to a constructor in this case.
				// this is becuase the server creates the instance and makes it available 
				// to all a singleton.  All we are doing is obtaining a reference to
				// the running instance via a proxy.
				object[] args = null;
				mSCustomer = (RemotingSample.SingletonCustomer) (Activator.CreateInstance(typeof(RemotingSample.SingletonCustomer), args));
				mSCustomer.newClient();
				objNotCreated = (mSCustomer == null);
			}
			// Change the command buttons state
			SetCtlState(objNotCreated);
		}
		catch (RemotingException exp)
		{
			// Will catch any generic Remoting exception
			txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine + 
				"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
				"  Message: " + exp.Message + Environment.NewLine + 
				"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
				"  Stack Trace:" + Environment.NewLine + 
				exp.StackTrace;
			MessageBox.Show(txt, "Remoting Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
		catch (System.Net.Sockets.SocketException exp)
		{
			// This will catch any Sockets exceptions.
			// This can be caused since we're using the binary
			// remoting interface which uses Sockets.
			txt = "I was unable to access the remote customer object." + Environment.NewLine + 
				"Is it possible the server is not running?" + Environment.NewLine + Environment.NewLine + 
				"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
				"  Message: " + exp.Message + Environment.NewLine + 
				"  Source: " + exp.Source + Environment.NewLine + 
				"  Error Code: " + exp.ErrorCode.ToString() + Environment.NewLine + 
				"  Native Error Code: " + exp.NativeErrorCode.ToString() + Environment.NewLine + Environment.NewLine + 
				"  Stack Trace:" + Environment.NewLine + 
				exp.StackTrace;
			MessageBox.Show(txt, "Socket Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
			txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine + 
			"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
			"  Message: " + exp.Message + Environment.NewLine + 
			"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
			"  Stack Trace:" + Environment.NewLine + 
			exp.StackTrace;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}

	private void cmdDebugData_Click(object sender, System.EventArgs e) 
	{
		// Get debug data from the Client Activated type
		if (( mCustomer != null) || ( mSCustomer != null))
		{
			try 
			{
				if (this.rbClient.Checked == true)
				{
					this.lstResponses.Items.Add("Debug data follows:");
					this.lstResponses.Items.Add(string.Format("  Creation Time: {0}", mCustomer.DebugCreationTime.ToString()));
					this.lstResponses.Items.Add(string.Format("  Code Base: {0}", mCustomer.DebugCodeBase));
					this.lstResponses.Items.Add(string.Format("  Fully Qualified Name: {0}", mCustomer.DebugFQName));
					this.lstResponses.Items.Add(string.Format("  Remote Host Name: {0}", mCustomer.DebugHostName));
					this.lstResponses.Items.Add("End Debug Data");
				}	
				else 
				{
					this.lstResponses.Items.Add("Debug data follows:");
					this.lstResponses.Items.Add(string.Format("  Creation Time: {0}", mSCustomer.DebugCreationTime.ToString()));
					this.lstResponses.Items.Add(string.Format("  Code Base: {0}", mSCustomer.DebugCodeBase));
					this.lstResponses.Items.Add(string.Format("  Fully Qualified Name: {0}", mSCustomer.DebugFQName));
					this.lstResponses.Items.Add(string.Format("  Remote Host Name: {0}", mSCustomer.DebugHostName));
					this.lstResponses.Items.Add(string.Format("  Number of connected clients: {0}", mSCustomer.Connected.ToString()));
					this.lstResponses.Items.Add("End Debug Data");
				}
			}
			catch (Exception exp) 
			{
				// Will catch any generic exception
				// See the code in cmdCreate for more detailed examples.
				string txt;
				txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine + 
				"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
				"  Message: " + exp.Message + Environment.NewLine + 
				"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
				"  Stack Trace:" + Environment.NewLine + 
				exp.StackTrace;
				MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}
	}

	private void cmdGet_Click(object sender, System.EventArgs e) 
	{
		// Ask the server for the customer data 
		try 
		{

			if (this.rbClient.Checked == true)
			{
				this.lstResponses.Items.Add(mCustomer.GetCustomerInfo());
			}
			else 
			{
				this.lstResponses.Items.Add(mSCustomer.GetCustomerInfo());
			}
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
			// See the code in cmdCreate for more detailed examples.
			string txt;
			txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine + 
			"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
			"  Message: " + exp.Message + Environment.NewLine + 
			"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
			"  Stack Trace:" + Environment.NewLine + 
			exp.StackTrace;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}

	private void cmdUpdate_Click(object sender, System.EventArgs e) 
	{
		// Update the values on the server using public properties.
		// Might not be the most effcient way to update data (esp. if you want a return value).
		// See cmdUpdateAndget {for another example.
		if (( mCustomer != null) || ( mSCustomer != null)) 
		{
			try 
			{
				if (this.rbClient.Checked == true)
				{
					mCustomer.Name = this.txtnewName.Text;
					mCustomer.Age = Convert.ToByte(this.txtnewAge.Text);
				}
				else 
				{
					mSCustomer.Name = this.txtnewName.Text;
					mSCustomer.Age = Convert.ToByte(this.txtnewAge.Text);
				}
				this.lstResponses.Items.Add("Update using properties successful!");
			}
			catch (Exception exp) 
			{
				// Will catch any generic exception
				// See the code in cmdCreate for more detailed examples.
				string txt;
				txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine + 
				"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
				"  Message: " + exp.Message + Environment.NewLine + 
				"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
				"  Stack Trace:" + Environment.NewLine + 
				exp.StackTrace;
				MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}
	}

	private void cmdUpdateAndGet_Click(object sender, System.EventArgs e) 
	{
		// Update the values on the server using a function that accepts both values
		// and get the return data of the Client Activated type.
		// This is generally a better format the code in cmdUpdate since it
		// gets more work done in fewer round-trips.

		if (( mCustomer != null) || ( mSCustomer != null)) 
		{
			try 
			{
				if (this.rbClient.Checked == true)
				{
					this.lstResponses.Items.Add(mCustomer.UpdateCustomerInfo(this.txtnewName.Text, Convert.ToByte(this.txtnewAge.Text)));
				}
				else 
				{
					this.lstResponses.Items.Add(mSCustomer.UpdateCustomerInfo(this.txtnewName.Text, Convert.ToByte(this.txtnewAge.Text)));
				}
			}
			catch (Exception exp) 
			{
				// Will catch any generic exception
				// See the code in cmdCreate for more detailed examples.
				string txt;
				txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine +
				"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
				"  Message: " + exp.Message + Environment.NewLine + 
				"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
				"  Stack Trace:" + Environment.NewLine + 
				exp.StackTrace;
				MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}
	}

	private void cmdRelease_Click(object sender, System.EventArgs e) 
	{
		// Release our reference to the server object
		if (( mCustomer != null) || ( mSCustomer != null)) 
		{
			bool objReleased = false;

			if (rbClient.Checked == true)
			{
				// Let go of the proxy reference
				mCustomer = null;
				objReleased = (mCustomer == null);
			}
			else 
			{
				// Since the object exposes the method, we should call it.
				// In our example it doesn't do anything fancy. It simply
				// lowers the connected count.
				
				mSCustomer = null;
				objReleased = (mSCustomer == null);
			}
			// Change the command buttons state
			SetCtlState(objReleased);
		}
	}

	private void cmdSingleCall_Click(object sender, System.EventArgs e) 
	{
		// SingleCall objects only live for the life of one method call.
		// while the properties exist, they can only be used when the object is not
		// being used in SingleCall mode.
		// This model is very similar to a correct MTS/COM+ component implementation.
		// Even though we're not providing arguments, we must pass
		// array defined object. null won't work.
		object[] args = null;
		SingleCallCustomer cust;

		try 
		{
			cust = (RemotingSample.SingleCallCustomer) (Activator.CreateInstance(typeof(RemotingSample.SingleCallCustomer), args));
			this.lstResponses.Items.Add("SingleCall.UpdateCustomerInfo: " + cust.UpdateCustomerInfo(this.txtnewName.Text, Convert.ToByte(this.txtnewAge.Text)));
			this.lstResponses.Items.Add("Update Successful!");
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
			// See the code in cmdCreate for more detailed examples.
			string txt;
			txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine +
			"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
			"  Message: " + exp.Message + Environment.NewLine + 
			"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
			"  Stack Trace:" + Environment.NewLine + 
			exp.StackTrace;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}

	private void cmdSingleDebug_Click(object sender, System.EventArgs e) 
	{
		// SingleCall objects only live for the life of one method call.
		// Each time we go and get debug data, we're getting it from a 
		// new instance of the object.
		// Even though we're not providing arguments, we must pass
		// array defined object. null won't work.
		object[] args = null;
		SingleCallCustomer scCust;
		try 
		{
			scCust = (RemotingSample.SingleCallCustomer) (Activator.CreateInstance(typeof(RemotingSample.SingleCallCustomer), args));
			this.lstResponses.Items.Add("Debug data follows:");
			this.lstResponses.Items.Add(string.Format("  Creation Time: {0}", scCust.DebugCreationTime.ToString()));
			this.lstResponses.Items.Add(string.Format("  Code Base: {0}", scCust.DebugCodeBase));
			this.lstResponses.Items.Add(string.Format("  Fully Qualified Name: {0}", scCust.DebugFQName));
			this.lstResponses.Items.Add(string.Format("  Remote Host Name: {0}", scCust.DebugHostName));
			// Notice how the creation time is different!
			this.lstResponses.Items.Add(string.Format("  Creation Time: {0}", scCust.DebugCreationTime.ToString()));
			this.lstResponses.Items.Add("End Debug Data");
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
			// See the code in cmdCreate for more detailed examples.
			string txt;
			txt = "I was unable to access the remote customer object." + Environment.NewLine + Environment.NewLine + 
			"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
			"  Message: " + exp.Message + Environment.NewLine + 
			"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
			"  Stack Trace:" + Environment.NewLine + 
			exp.StackTrace;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}

	private void frmMain_Closed(object sender, System.EventArgs e) //base.Closed;
	{
		// Let go of any objects we may still be holding on to
		if ( mCustomer != null) 
		{
			mCustomer = null;
		}
	}

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		//Read in the application configuration file (client.exe.config).  This file has the remoting configuration
		//information for the client side remoting infrastructure.
		try 
		{
			// This assumes the file is in the same directory this exe.
			RemotingConfiguration.Configure("client.exe.config");
		}
		catch (Exception exp) 
		{
			// Will catch any generic exception
			string txt;
			txt = "I was unable to load the file config.xml." + Environment.NewLine + 
			"Please make sure it is located in the same directory this exe " + 
			" and that it is in the correct format." + Environment.NewLine + 
			"Please see the Help, About box for the location of this exe." + Environment.NewLine + Environment.NewLine + 
			"Detailed Error Information below:" + Environment.NewLine + Environment.NewLine + 
			"  Message: " + exp.Message + Environment.NewLine + 
			"  Source: " + exp.Source + Environment.NewLine + Environment.NewLine + 
			"  Stack Trace:" + Environment.NewLine + 
			exp.StackTrace;
			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			// turn of the create command buttons
			this.cmdCreate.Enabled = false;
		}
	}

	private void txtnewAge_Validating(object sender, System.ComponentModel.CancelEventArgs e) 
	{
		// Check to make sure only numeric values are entered
		// and check to see if the datatype is a byte
		try 
		{
			byte d = Convert.ToByte(this.txtnewAge.Text);
		}
		catch (Exception exp) 
		{
			string txt;
			txt = "The value you entered, '{0}', for the Customer's new Age is incorrect." + Environment.NewLine + 
			"Please enter a value in the range of 0 to 255." + Environment.NewLine + 
			"The value will be reset to 0 by default.";
			MessageBox.Show(string.Format(txt, this.txtnewAge.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			// Set the default value to 0 and cancel the field exit.
			this.txtnewAge.Text = "0";
			e.Cancel = true;
		}
	}
}

