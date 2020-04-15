//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

public class frmMain: System.Windows.Forms.Form {

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

    public frmMain() {

        

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

    private System.Windows.Forms.OpenFileDialog OpenFileDialog1;

    private System.Windows.Forms.TabControl TabControl1;

    private System.Windows.Forms.TabPage tabActiveX;

    private System.Windows.Forms.TabPage tabAutomation;

    private System.Windows.Forms.Button btnForward;

    private System.Windows.Forms.Button btnBack;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.TextBox tbAddress;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Button btnBrowse2;

    private System.Windows.Forms.TextBox tbAddress2;

    private AxSHDocVw.AxWebBrowser ieForHosting;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.CheckBox chkAddressBar;

    private System.Windows.Forms.CheckBox chkFullScreen;

    private System.Windows.Forms.Label Label7;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.Label Label10;

    private System.Windows.Forms.Label Label11;

    private System.Windows.Forms.Label Label12;

    private System.Windows.Forms.TextBox txtTop;

    private System.Windows.Forms.TextBox txtLeft;

    private System.Windows.Forms.TextBox txtHeight;

    private System.Windows.Forms.TextBox txtWidth;

    private System.Windows.Forms.CheckBox chkMenuBar;

    private System.Windows.Forms.CheckBox chkResizable;

    private System.Windows.Forms.CheckBox chkStatusBar;

    private System.Windows.Forms.CheckBox chkTheaterMode;

    private System.Windows.Forms.CheckBox chkToolBar;

    private System.Windows.Forms.Button btnBrowse;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.tabActiveX = new System.Windows.Forms.TabPage();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.btnForward = new System.Windows.Forms.Button();
		this.btnBack = new System.Windows.Forms.Button();
		this.btnBrowse = new System.Windows.Forms.Button();
		this.Label1 = new System.Windows.Forms.Label();
		this.tbAddress = new System.Windows.Forms.TextBox();
		this.ieForHosting = new AxSHDocVw.AxWebBrowser();
		this.tabAutomation = new System.Windows.Forms.TabPage();
		this.chkToolBar = new System.Windows.Forms.CheckBox();
		this.chkTheaterMode = new System.Windows.Forms.CheckBox();
		this.chkStatusBar = new System.Windows.Forms.CheckBox();
		this.chkResizable = new System.Windows.Forms.CheckBox();
		this.chkMenuBar = new System.Windows.Forms.CheckBox();
		this.txtWidth = new System.Windows.Forms.TextBox();
		this.txtHeight = new System.Windows.Forms.TextBox();
		this.txtLeft = new System.Windows.Forms.TextBox();
		this.txtTop = new System.Windows.Forms.TextBox();
		this.Label12 = new System.Windows.Forms.Label();
		this.Label11 = new System.Windows.Forms.Label();
		this.Label10 = new System.Windows.Forms.Label();
		this.Label9 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.chkFullScreen = new System.Windows.Forms.CheckBox();
		this.chkAddressBar = new System.Windows.Forms.CheckBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.btnBrowse2 = new System.Windows.Forms.Button();
		this.Label2 = new System.Windows.Forms.Label();
		this.tbAddress2 = new System.Windows.Forms.TextBox();
		this.TabControl1.SuspendLayout();
		this.tabActiveX.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.ieForHosting)).BeginInit();
		this.tabAutomation.SuspendLayout();
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
		// OpenFileDialog1
		// 
		this.OpenFileDialog1.Filter = resources.GetString("OpenFileDialog1.Filter");
		this.OpenFileDialog1.Title = resources.GetString("OpenFileDialog1.Title");
		// 
		// TabControl1
		// 
		this.TabControl1.AccessibleDescription = resources.GetString("TabControl1.AccessibleDescription");
		this.TabControl1.AccessibleName = resources.GetString("TabControl1.AccessibleName");
		this.TabControl1.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("TabControl1.Alignment")));
		this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("TabControl1.Anchor")));
		this.TabControl1.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("TabControl1.Appearance")));
		this.TabControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabControl1.BackgroundImage")));
		this.TabControl1.Controls.Add(this.tabActiveX);
		this.TabControl1.Controls.Add(this.tabAutomation);
		this.TabControl1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("TabControl1.Dock")));
		this.TabControl1.Enabled = ((bool)(resources.GetObject("TabControl1.Enabled")));
		this.TabControl1.Font = ((System.Drawing.Font)(resources.GetObject("TabControl1.Font")));
		this.TabControl1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("TabControl1.ImeMode")));
		this.TabControl1.ItemSize = ((System.Drawing.Size)(resources.GetObject("TabControl1.ItemSize")));
		this.TabControl1.Location = ((System.Drawing.Point)(resources.GetObject("TabControl1.Location")));
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.Padding = ((System.Drawing.Point)(resources.GetObject("TabControl1.Padding")));
		this.TabControl1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("TabControl1.RightToLeft")));
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.ShowToolTips = ((bool)(resources.GetObject("TabControl1.ShowToolTips")));
		this.TabControl1.Size = ((System.Drawing.Size)(resources.GetObject("TabControl1.Size")));
		this.TabControl1.TabIndex = ((int)(resources.GetObject("TabControl1.TabIndex")));
		this.TabControl1.Text = resources.GetString("TabControl1.Text");
		this.TabControl1.Visible = ((bool)(resources.GetObject("TabControl1.Visible")));
		// 
		// tabActiveX
		// 
		this.tabActiveX.AccessibleDescription = resources.GetString("tabActiveX.AccessibleDescription");
		this.tabActiveX.AccessibleName = resources.GetString("tabActiveX.AccessibleName");
		this.tabActiveX.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabActiveX.Anchor")));
		this.tabActiveX.AutoScroll = ((bool)(resources.GetObject("tabActiveX.AutoScroll")));
		this.tabActiveX.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("tabActiveX.AutoScrollMargin")));
		this.tabActiveX.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("tabActiveX.AutoScrollMinSize")));
		this.tabActiveX.BackColor = System.Drawing.SystemColors.Info;
		this.tabActiveX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabActiveX.BackgroundImage")));
		this.tabActiveX.Controls.Add(this.Label5);
		this.tabActiveX.Controls.Add(this.Label6);
		this.tabActiveX.Controls.Add(this.btnForward);
		this.tabActiveX.Controls.Add(this.btnBack);
		this.tabActiveX.Controls.Add(this.btnBrowse);
		this.tabActiveX.Controls.Add(this.Label1);
		this.tabActiveX.Controls.Add(this.tbAddress);
		this.tabActiveX.Controls.Add(this.ieForHosting);
		this.tabActiveX.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabActiveX.Dock")));
		this.tabActiveX.Enabled = ((bool)(resources.GetObject("tabActiveX.Enabled")));
		this.tabActiveX.Font = ((System.Drawing.Font)(resources.GetObject("tabActiveX.Font")));
		this.tabActiveX.ImageIndex = ((int)(resources.GetObject("tabActiveX.ImageIndex")));
		this.tabActiveX.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabActiveX.ImeMode")));
		this.tabActiveX.Location = ((System.Drawing.Point)(resources.GetObject("tabActiveX.Location")));
		this.tabActiveX.Name = "tabActiveX";
		this.tabActiveX.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabActiveX.RightToLeft")));
		this.tabActiveX.Size = ((System.Drawing.Size)(resources.GetObject("tabActiveX.Size")));
		this.tabActiveX.TabIndex = ((int)(resources.GetObject("tabActiveX.TabIndex")));
		this.tabActiveX.Text = resources.GetString("tabActiveX.Text");
		this.tabActiveX.ToolTipText = resources.GetString("tabActiveX.ToolTipText");
		this.tabActiveX.Visible = ((bool)(resources.GetObject("tabActiveX.Visible")));
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
		// Label6
		// 
		this.Label6.AccessibleDescription = resources.GetString("Label6.AccessibleDescription");
		this.Label6.AccessibleName = resources.GetString("Label6.AccessibleName");
		this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label6.Anchor")));
		this.Label6.AutoSize = ((bool)(resources.GetObject("Label6.AutoSize")));
		this.Label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label6.Dock")));
		this.Label6.Enabled = ((bool)(resources.GetObject("Label6.Enabled")));
		this.Label6.Font = ((System.Drawing.Font)(resources.GetObject("Label6.Font")));
		this.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
		// btnForward
		// 
		this.btnForward.AccessibleDescription = resources.GetString("btnForward.AccessibleDescription");
		this.btnForward.AccessibleName = resources.GetString("btnForward.AccessibleName");
		this.btnForward.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnForward.Anchor")));
		this.btnForward.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.btnForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnForward.BackgroundImage")));
		this.btnForward.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnForward.Dock")));
		this.btnForward.Enabled = ((bool)(resources.GetObject("btnForward.Enabled")));
		this.btnForward.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnForward.FlatStyle")));
		this.btnForward.Font = ((System.Drawing.Font)(resources.GetObject("btnForward.Font")));
		this.btnForward.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
		this.btnForward.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnForward.ImageAlign")));
		this.btnForward.ImageIndex = ((int)(resources.GetObject("btnForward.ImageIndex")));
		this.btnForward.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnForward.ImeMode")));
		this.btnForward.Location = ((System.Drawing.Point)(resources.GetObject("btnForward.Location")));
		this.btnForward.Name = "btnForward";
		this.btnForward.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnForward.RightToLeft")));
		this.btnForward.Size = ((System.Drawing.Size)(resources.GetObject("btnForward.Size")));
		this.btnForward.TabIndex = ((int)(resources.GetObject("btnForward.TabIndex")));
		this.btnForward.Text = resources.GetString("btnForward.Text");
		this.btnForward.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnForward.TextAlign")));
		this.btnForward.Visible = ((bool)(resources.GetObject("btnForward.Visible")));
		this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
		// 
		// btnBack
		// 
		this.btnBack.AccessibleDescription = resources.GetString("btnBack.AccessibleDescription");
		this.btnBack.AccessibleName = resources.GetString("btnBack.AccessibleName");
		this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnBack.Anchor")));
		this.btnBack.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
		this.btnBack.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnBack.Dock")));
		this.btnBack.Enabled = ((bool)(resources.GetObject("btnBack.Enabled")));
		this.btnBack.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnBack.FlatStyle")));
		this.btnBack.Font = ((System.Drawing.Font)(resources.GetObject("btnBack.Font")));
		this.btnBack.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
		this.btnBack.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBack.ImageAlign")));
		this.btnBack.ImageIndex = ((int)(resources.GetObject("btnBack.ImageIndex")));
		this.btnBack.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnBack.ImeMode")));
		this.btnBack.Location = ((System.Drawing.Point)(resources.GetObject("btnBack.Location")));
		this.btnBack.Name = "btnBack";
		this.btnBack.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnBack.RightToLeft")));
		this.btnBack.Size = ((System.Drawing.Size)(resources.GetObject("btnBack.Size")));
		this.btnBack.TabIndex = ((int)(resources.GetObject("btnBack.TabIndex")));
		this.btnBack.Text = resources.GetString("btnBack.Text");
		this.btnBack.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBack.TextAlign")));
		this.btnBack.Visible = ((bool)(resources.GetObject("btnBack.Visible")));
		this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
		// 
		// btnBrowse
		// 
		this.btnBrowse.AccessibleDescription = resources.GetString("btnBrowse.AccessibleDescription");
		this.btnBrowse.AccessibleName = resources.GetString("btnBrowse.AccessibleName");
		this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnBrowse.Anchor")));
		this.btnBrowse.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.btnBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowse.BackgroundImage")));
		this.btnBrowse.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnBrowse.Dock")));
		this.btnBrowse.Enabled = ((bool)(resources.GetObject("btnBrowse.Enabled")));
		this.btnBrowse.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnBrowse.FlatStyle")));
		this.btnBrowse.Font = ((System.Drawing.Font)(resources.GetObject("btnBrowse.Font")));
		this.btnBrowse.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
		this.btnBrowse.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBrowse.ImageAlign")));
		this.btnBrowse.ImageIndex = ((int)(resources.GetObject("btnBrowse.ImageIndex")));
		this.btnBrowse.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnBrowse.ImeMode")));
		this.btnBrowse.Location = ((System.Drawing.Point)(resources.GetObject("btnBrowse.Location")));
		this.btnBrowse.Name = "btnBrowse";
		this.btnBrowse.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnBrowse.RightToLeft")));
		this.btnBrowse.Size = ((System.Drawing.Size)(resources.GetObject("btnBrowse.Size")));
		this.btnBrowse.TabIndex = ((int)(resources.GetObject("btnBrowse.TabIndex")));
		this.btnBrowse.Text = resources.GetString("btnBrowse.Text");
		this.btnBrowse.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBrowse.TextAlign")));
		this.btnBrowse.Visible = ((bool)(resources.GetObject("btnBrowse.Visible")));
		this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
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
		this.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
		// tbAddress
		// 
		this.tbAddress.AccessibleDescription = resources.GetString("tbAddress.AccessibleDescription");
		this.tbAddress.AccessibleName = resources.GetString("tbAddress.AccessibleName");
		this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tbAddress.Anchor")));
		this.tbAddress.AutoSize = ((bool)(resources.GetObject("tbAddress.AutoSize")));
		this.tbAddress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbAddress.BackgroundImage")));
		this.tbAddress.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tbAddress.Dock")));
		this.tbAddress.Enabled = ((bool)(resources.GetObject("tbAddress.Enabled")));
		this.tbAddress.Font = ((System.Drawing.Font)(resources.GetObject("tbAddress.Font")));
		this.tbAddress.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tbAddress.ImeMode")));
		this.tbAddress.Location = ((System.Drawing.Point)(resources.GetObject("tbAddress.Location")));
		this.tbAddress.MaxLength = ((int)(resources.GetObject("tbAddress.MaxLength")));
		this.tbAddress.Multiline = ((bool)(resources.GetObject("tbAddress.Multiline")));
		this.tbAddress.Name = "tbAddress";
		this.tbAddress.PasswordChar = ((char)(resources.GetObject("tbAddress.PasswordChar")));
		this.tbAddress.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tbAddress.RightToLeft")));
		this.tbAddress.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("tbAddress.ScrollBars")));
		this.tbAddress.Size = ((System.Drawing.Size)(resources.GetObject("tbAddress.Size")));
		this.tbAddress.TabIndex = ((int)(resources.GetObject("tbAddress.TabIndex")));
		this.tbAddress.Text = resources.GetString("tbAddress.Text");
		this.tbAddress.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("tbAddress.TextAlign")));
		this.tbAddress.Visible = ((bool)(resources.GetObject("tbAddress.Visible")));
		this.tbAddress.WordWrap = ((bool)(resources.GetObject("tbAddress.WordWrap")));
		// 
		// ieForHosting
		// 
		this.ieForHosting.AccessibleDescription = resources.GetString("ieForHosting.AccessibleDescription");
		this.ieForHosting.AccessibleName = resources.GetString("ieForHosting.AccessibleName");
		this.ieForHosting.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("ieForHosting.Anchor")));
		this.ieForHosting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ieForHosting.BackgroundImage")));
		this.ieForHosting.ContainingControl = this;
		this.ieForHosting.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("ieForHosting.Dock")));
		this.ieForHosting.Enabled = ((bool)(resources.GetObject("ieForHosting.Enabled")));
		this.ieForHosting.Font = ((System.Drawing.Font)(resources.GetObject("ieForHosting.Font")));
		this.ieForHosting.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("ieForHosting.ImeMode")));
		this.ieForHosting.Location = ((System.Drawing.Point)(resources.GetObject("ieForHosting.Location")));
		this.ieForHosting.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ieForHosting.OcxState")));
		this.ieForHosting.RightToLeft = ((bool)(resources.GetObject("ieForHosting.RightToLeft")));
		this.ieForHosting.Size = ((System.Drawing.Size)(resources.GetObject("ieForHosting.Size")));
		this.ieForHosting.TabIndex = ((int)(resources.GetObject("ieForHosting.TabIndex")));
		this.ieForHosting.Text = resources.GetString("ieForHosting.Text");
		this.ieForHosting.Visible = ((bool)(resources.GetObject("ieForHosting.Visible")));
		this.ieForHosting.DocumentComplete += new AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.ieForHosting_DocumentComplete);
		// 
		// tabAutomation
		// 
		this.tabAutomation.AccessibleDescription = resources.GetString("tabAutomation.AccessibleDescription");
		this.tabAutomation.AccessibleName = resources.GetString("tabAutomation.AccessibleName");
		this.tabAutomation.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tabAutomation.Anchor")));
		this.tabAutomation.AutoScroll = ((bool)(resources.GetObject("tabAutomation.AutoScroll")));
		this.tabAutomation.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("tabAutomation.AutoScrollMargin")));
		this.tabAutomation.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("tabAutomation.AutoScrollMinSize")));
		this.tabAutomation.BackColor = System.Drawing.SystemColors.Info;
		this.tabAutomation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabAutomation.BackgroundImage")));
		this.tabAutomation.Controls.Add(this.chkToolBar);
		this.tabAutomation.Controls.Add(this.chkTheaterMode);
		this.tabAutomation.Controls.Add(this.chkStatusBar);
		this.tabAutomation.Controls.Add(this.chkResizable);
		this.tabAutomation.Controls.Add(this.chkMenuBar);
		this.tabAutomation.Controls.Add(this.txtWidth);
		this.tabAutomation.Controls.Add(this.txtHeight);
		this.tabAutomation.Controls.Add(this.txtLeft);
		this.tabAutomation.Controls.Add(this.txtTop);
		this.tabAutomation.Controls.Add(this.Label12);
		this.tabAutomation.Controls.Add(this.Label11);
		this.tabAutomation.Controls.Add(this.Label10);
		this.tabAutomation.Controls.Add(this.Label9);
		this.tabAutomation.Controls.Add(this.Label8);
		this.tabAutomation.Controls.Add(this.Label7);
		this.tabAutomation.Controls.Add(this.chkFullScreen);
		this.tabAutomation.Controls.Add(this.chkAddressBar);
		this.tabAutomation.Controls.Add(this.Label4);
		this.tabAutomation.Controls.Add(this.Label3);
		this.tabAutomation.Controls.Add(this.btnBrowse2);
		this.tabAutomation.Controls.Add(this.Label2);
		this.tabAutomation.Controls.Add(this.tbAddress2);
		this.tabAutomation.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tabAutomation.Dock")));
		this.tabAutomation.Enabled = ((bool)(resources.GetObject("tabAutomation.Enabled")));
		this.tabAutomation.Font = ((System.Drawing.Font)(resources.GetObject("tabAutomation.Font")));
		this.tabAutomation.ImageIndex = ((int)(resources.GetObject("tabAutomation.ImageIndex")));
		this.tabAutomation.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tabAutomation.ImeMode")));
		this.tabAutomation.Location = ((System.Drawing.Point)(resources.GetObject("tabAutomation.Location")));
		this.tabAutomation.Name = "tabAutomation";
		this.tabAutomation.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tabAutomation.RightToLeft")));
		this.tabAutomation.Size = ((System.Drawing.Size)(resources.GetObject("tabAutomation.Size")));
		this.tabAutomation.TabIndex = ((int)(resources.GetObject("tabAutomation.TabIndex")));
		this.tabAutomation.Text = resources.GetString("tabAutomation.Text");
		this.tabAutomation.ToolTipText = resources.GetString("tabAutomation.ToolTipText");
		this.tabAutomation.Visible = ((bool)(resources.GetObject("tabAutomation.Visible")));
		// 
		// chkToolBar
		// 
		this.chkToolBar.AccessibleDescription = resources.GetString("chkToolBar.AccessibleDescription");
		this.chkToolBar.AccessibleName = resources.GetString("chkToolBar.AccessibleName");
		this.chkToolBar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkToolBar.Anchor")));
		this.chkToolBar.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkToolBar.Appearance")));
		this.chkToolBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkToolBar.BackgroundImage")));
		this.chkToolBar.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkToolBar.CheckAlign")));
		this.chkToolBar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkToolBar.Dock")));
		this.chkToolBar.Enabled = ((bool)(resources.GetObject("chkToolBar.Enabled")));
		this.chkToolBar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkToolBar.FlatStyle")));
		this.chkToolBar.Font = ((System.Drawing.Font)(resources.GetObject("chkToolBar.Font")));
		this.chkToolBar.Image = ((System.Drawing.Image)(resources.GetObject("chkToolBar.Image")));
		this.chkToolBar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkToolBar.ImageAlign")));
		this.chkToolBar.ImageIndex = ((int)(resources.GetObject("chkToolBar.ImageIndex")));
		this.chkToolBar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkToolBar.ImeMode")));
		this.chkToolBar.Location = ((System.Drawing.Point)(resources.GetObject("chkToolBar.Location")));
		this.chkToolBar.Name = "chkToolBar";
		this.chkToolBar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkToolBar.RightToLeft")));
		this.chkToolBar.Size = ((System.Drawing.Size)(resources.GetObject("chkToolBar.Size")));
		this.chkToolBar.TabIndex = ((int)(resources.GetObject("chkToolBar.TabIndex")));
		this.chkToolBar.Text = resources.GetString("chkToolBar.Text");
		this.chkToolBar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkToolBar.TextAlign")));
		this.chkToolBar.Visible = ((bool)(resources.GetObject("chkToolBar.Visible")));
		// 
		// chkTheaterMode
		// 
		this.chkTheaterMode.AccessibleDescription = resources.GetString("chkTheaterMode.AccessibleDescription");
		this.chkTheaterMode.AccessibleName = resources.GetString("chkTheaterMode.AccessibleName");
		this.chkTheaterMode.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkTheaterMode.Anchor")));
		this.chkTheaterMode.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkTheaterMode.Appearance")));
		this.chkTheaterMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkTheaterMode.BackgroundImage")));
		this.chkTheaterMode.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkTheaterMode.CheckAlign")));
		this.chkTheaterMode.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkTheaterMode.Dock")));
		this.chkTheaterMode.Enabled = ((bool)(resources.GetObject("chkTheaterMode.Enabled")));
		this.chkTheaterMode.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkTheaterMode.FlatStyle")));
		this.chkTheaterMode.Font = ((System.Drawing.Font)(resources.GetObject("chkTheaterMode.Font")));
		this.chkTheaterMode.Image = ((System.Drawing.Image)(resources.GetObject("chkTheaterMode.Image")));
		this.chkTheaterMode.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkTheaterMode.ImageAlign")));
		this.chkTheaterMode.ImageIndex = ((int)(resources.GetObject("chkTheaterMode.ImageIndex")));
		this.chkTheaterMode.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkTheaterMode.ImeMode")));
		this.chkTheaterMode.Location = ((System.Drawing.Point)(resources.GetObject("chkTheaterMode.Location")));
		this.chkTheaterMode.Name = "chkTheaterMode";
		this.chkTheaterMode.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkTheaterMode.RightToLeft")));
		this.chkTheaterMode.Size = ((System.Drawing.Size)(resources.GetObject("chkTheaterMode.Size")));
		this.chkTheaterMode.TabIndex = ((int)(resources.GetObject("chkTheaterMode.TabIndex")));
		this.chkTheaterMode.Text = resources.GetString("chkTheaterMode.Text");
		this.chkTheaterMode.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkTheaterMode.TextAlign")));
		this.chkTheaterMode.Visible = ((bool)(resources.GetObject("chkTheaterMode.Visible")));
		// 
		// chkStatusBar
		// 
		this.chkStatusBar.AccessibleDescription = resources.GetString("chkStatusBar.AccessibleDescription");
		this.chkStatusBar.AccessibleName = resources.GetString("chkStatusBar.AccessibleName");
		this.chkStatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkStatusBar.Anchor")));
		this.chkStatusBar.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkStatusBar.Appearance")));
		this.chkStatusBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkStatusBar.BackgroundImage")));
		this.chkStatusBar.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkStatusBar.CheckAlign")));
		this.chkStatusBar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkStatusBar.Dock")));
		this.chkStatusBar.Enabled = ((bool)(resources.GetObject("chkStatusBar.Enabled")));
		this.chkStatusBar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkStatusBar.FlatStyle")));
		this.chkStatusBar.Font = ((System.Drawing.Font)(resources.GetObject("chkStatusBar.Font")));
		this.chkStatusBar.Image = ((System.Drawing.Image)(resources.GetObject("chkStatusBar.Image")));
		this.chkStatusBar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkStatusBar.ImageAlign")));
		this.chkStatusBar.ImageIndex = ((int)(resources.GetObject("chkStatusBar.ImageIndex")));
		this.chkStatusBar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkStatusBar.ImeMode")));
		this.chkStatusBar.Location = ((System.Drawing.Point)(resources.GetObject("chkStatusBar.Location")));
		this.chkStatusBar.Name = "chkStatusBar";
		this.chkStatusBar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkStatusBar.RightToLeft")));
		this.chkStatusBar.Size = ((System.Drawing.Size)(resources.GetObject("chkStatusBar.Size")));
		this.chkStatusBar.TabIndex = ((int)(resources.GetObject("chkStatusBar.TabIndex")));
		this.chkStatusBar.Text = resources.GetString("chkStatusBar.Text");
		this.chkStatusBar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkStatusBar.TextAlign")));
		this.chkStatusBar.Visible = ((bool)(resources.GetObject("chkStatusBar.Visible")));
		// 
		// chkResizable
		// 
		this.chkResizable.AccessibleDescription = resources.GetString("chkResizable.AccessibleDescription");
		this.chkResizable.AccessibleName = resources.GetString("chkResizable.AccessibleName");
		this.chkResizable.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkResizable.Anchor")));
		this.chkResizable.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkResizable.Appearance")));
		this.chkResizable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkResizable.BackgroundImage")));
		this.chkResizable.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkResizable.CheckAlign")));
		this.chkResizable.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkResizable.Dock")));
		this.chkResizable.Enabled = ((bool)(resources.GetObject("chkResizable.Enabled")));
		this.chkResizable.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkResizable.FlatStyle")));
		this.chkResizable.Font = ((System.Drawing.Font)(resources.GetObject("chkResizable.Font")));
		this.chkResizable.Image = ((System.Drawing.Image)(resources.GetObject("chkResizable.Image")));
		this.chkResizable.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkResizable.ImageAlign")));
		this.chkResizable.ImageIndex = ((int)(resources.GetObject("chkResizable.ImageIndex")));
		this.chkResizable.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkResizable.ImeMode")));
		this.chkResizable.Location = ((System.Drawing.Point)(resources.GetObject("chkResizable.Location")));
		this.chkResizable.Name = "chkResizable";
		this.chkResizable.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkResizable.RightToLeft")));
		this.chkResizable.Size = ((System.Drawing.Size)(resources.GetObject("chkResizable.Size")));
		this.chkResizable.TabIndex = ((int)(resources.GetObject("chkResizable.TabIndex")));
		this.chkResizable.Text = resources.GetString("chkResizable.Text");
		this.chkResizable.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkResizable.TextAlign")));
		this.chkResizable.Visible = ((bool)(resources.GetObject("chkResizable.Visible")));
		// 
		// chkMenuBar
		// 
		this.chkMenuBar.AccessibleDescription = resources.GetString("chkMenuBar.AccessibleDescription");
		this.chkMenuBar.AccessibleName = resources.GetString("chkMenuBar.AccessibleName");
		this.chkMenuBar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkMenuBar.Anchor")));
		this.chkMenuBar.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkMenuBar.Appearance")));
		this.chkMenuBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkMenuBar.BackgroundImage")));
		this.chkMenuBar.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkMenuBar.CheckAlign")));
		this.chkMenuBar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkMenuBar.Dock")));
		this.chkMenuBar.Enabled = ((bool)(resources.GetObject("chkMenuBar.Enabled")));
		this.chkMenuBar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkMenuBar.FlatStyle")));
		this.chkMenuBar.Font = ((System.Drawing.Font)(resources.GetObject("chkMenuBar.Font")));
		this.chkMenuBar.Image = ((System.Drawing.Image)(resources.GetObject("chkMenuBar.Image")));
		this.chkMenuBar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkMenuBar.ImageAlign")));
		this.chkMenuBar.ImageIndex = ((int)(resources.GetObject("chkMenuBar.ImageIndex")));
		this.chkMenuBar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkMenuBar.ImeMode")));
		this.chkMenuBar.Location = ((System.Drawing.Point)(resources.GetObject("chkMenuBar.Location")));
		this.chkMenuBar.Name = "chkMenuBar";
		this.chkMenuBar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkMenuBar.RightToLeft")));
		this.chkMenuBar.Size = ((System.Drawing.Size)(resources.GetObject("chkMenuBar.Size")));
		this.chkMenuBar.TabIndex = ((int)(resources.GetObject("chkMenuBar.TabIndex")));
		this.chkMenuBar.Text = resources.GetString("chkMenuBar.Text");
		this.chkMenuBar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkMenuBar.TextAlign")));
		this.chkMenuBar.Visible = ((bool)(resources.GetObject("chkMenuBar.Visible")));
		// 
		// txtWidth
		// 
		this.txtWidth.AccessibleDescription = resources.GetString("txtWidth.AccessibleDescription");
		this.txtWidth.AccessibleName = resources.GetString("txtWidth.AccessibleName");
		this.txtWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtWidth.Anchor")));
		this.txtWidth.AutoSize = ((bool)(resources.GetObject("txtWidth.AutoSize")));
		this.txtWidth.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtWidth.BackgroundImage")));
		this.txtWidth.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtWidth.Dock")));
		this.txtWidth.Enabled = ((bool)(resources.GetObject("txtWidth.Enabled")));
		this.txtWidth.Font = ((System.Drawing.Font)(resources.GetObject("txtWidth.Font")));
		this.txtWidth.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtWidth.ImeMode")));
		this.txtWidth.Location = ((System.Drawing.Point)(resources.GetObject("txtWidth.Location")));
		this.txtWidth.MaxLength = ((int)(resources.GetObject("txtWidth.MaxLength")));
		this.txtWidth.Multiline = ((bool)(resources.GetObject("txtWidth.Multiline")));
		this.txtWidth.Name = "txtWidth";
		this.txtWidth.PasswordChar = ((char)(resources.GetObject("txtWidth.PasswordChar")));
		this.txtWidth.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtWidth.RightToLeft")));
		this.txtWidth.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtWidth.ScrollBars")));
		this.txtWidth.Size = ((System.Drawing.Size)(resources.GetObject("txtWidth.Size")));
		this.txtWidth.TabIndex = ((int)(resources.GetObject("txtWidth.TabIndex")));
		this.txtWidth.Text = resources.GetString("txtWidth.Text");
		this.txtWidth.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtWidth.TextAlign")));
		this.txtWidth.Visible = ((bool)(resources.GetObject("txtWidth.Visible")));
		this.txtWidth.WordWrap = ((bool)(resources.GetObject("txtWidth.WordWrap")));
		// 
		// txtHeight
		// 
		this.txtHeight.AccessibleDescription = resources.GetString("txtHeight.AccessibleDescription");
		this.txtHeight.AccessibleName = resources.GetString("txtHeight.AccessibleName");
		this.txtHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtHeight.Anchor")));
		this.txtHeight.AutoSize = ((bool)(resources.GetObject("txtHeight.AutoSize")));
		this.txtHeight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtHeight.BackgroundImage")));
		this.txtHeight.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtHeight.Dock")));
		this.txtHeight.Enabled = ((bool)(resources.GetObject("txtHeight.Enabled")));
		this.txtHeight.Font = ((System.Drawing.Font)(resources.GetObject("txtHeight.Font")));
		this.txtHeight.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtHeight.ImeMode")));
		this.txtHeight.Location = ((System.Drawing.Point)(resources.GetObject("txtHeight.Location")));
		this.txtHeight.MaxLength = ((int)(resources.GetObject("txtHeight.MaxLength")));
		this.txtHeight.Multiline = ((bool)(resources.GetObject("txtHeight.Multiline")));
		this.txtHeight.Name = "txtHeight";
		this.txtHeight.PasswordChar = ((char)(resources.GetObject("txtHeight.PasswordChar")));
		this.txtHeight.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtHeight.RightToLeft")));
		this.txtHeight.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtHeight.ScrollBars")));
		this.txtHeight.Size = ((System.Drawing.Size)(resources.GetObject("txtHeight.Size")));
		this.txtHeight.TabIndex = ((int)(resources.GetObject("txtHeight.TabIndex")));
		this.txtHeight.Text = resources.GetString("txtHeight.Text");
		this.txtHeight.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtHeight.TextAlign")));
		this.txtHeight.Visible = ((bool)(resources.GetObject("txtHeight.Visible")));
		this.txtHeight.WordWrap = ((bool)(resources.GetObject("txtHeight.WordWrap")));
		// 
		// txtLeft
		// 
		this.txtLeft.AccessibleDescription = resources.GetString("txtLeft.AccessibleDescription");
		this.txtLeft.AccessibleName = resources.GetString("txtLeft.AccessibleName");
		this.txtLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtLeft.Anchor")));
		this.txtLeft.AutoSize = ((bool)(resources.GetObject("txtLeft.AutoSize")));
		this.txtLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtLeft.BackgroundImage")));
		this.txtLeft.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtLeft.Dock")));
		this.txtLeft.Enabled = ((bool)(resources.GetObject("txtLeft.Enabled")));
		this.txtLeft.Font = ((System.Drawing.Font)(resources.GetObject("txtLeft.Font")));
		this.txtLeft.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtLeft.ImeMode")));
		this.txtLeft.Location = ((System.Drawing.Point)(resources.GetObject("txtLeft.Location")));
		this.txtLeft.MaxLength = ((int)(resources.GetObject("txtLeft.MaxLength")));
		this.txtLeft.Multiline = ((bool)(resources.GetObject("txtLeft.Multiline")));
		this.txtLeft.Name = "txtLeft";
		this.txtLeft.PasswordChar = ((char)(resources.GetObject("txtLeft.PasswordChar")));
		this.txtLeft.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtLeft.RightToLeft")));
		this.txtLeft.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtLeft.ScrollBars")));
		this.txtLeft.Size = ((System.Drawing.Size)(resources.GetObject("txtLeft.Size")));
		this.txtLeft.TabIndex = ((int)(resources.GetObject("txtLeft.TabIndex")));
		this.txtLeft.Text = resources.GetString("txtLeft.Text");
		this.txtLeft.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtLeft.TextAlign")));
		this.txtLeft.Visible = ((bool)(resources.GetObject("txtLeft.Visible")));
		this.txtLeft.WordWrap = ((bool)(resources.GetObject("txtLeft.WordWrap")));
		// 
		// txtTop
		// 
		this.txtTop.AccessibleDescription = resources.GetString("txtTop.AccessibleDescription");
		this.txtTop.AccessibleName = resources.GetString("txtTop.AccessibleName");
		this.txtTop.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtTop.Anchor")));
		this.txtTop.AutoSize = ((bool)(resources.GetObject("txtTop.AutoSize")));
		this.txtTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtTop.BackgroundImage")));
		this.txtTop.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtTop.Dock")));
		this.txtTop.Enabled = ((bool)(resources.GetObject("txtTop.Enabled")));
		this.txtTop.Font = ((System.Drawing.Font)(resources.GetObject("txtTop.Font")));
		this.txtTop.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtTop.ImeMode")));
		this.txtTop.Location = ((System.Drawing.Point)(resources.GetObject("txtTop.Location")));
		this.txtTop.MaxLength = ((int)(resources.GetObject("txtTop.MaxLength")));
		this.txtTop.Multiline = ((bool)(resources.GetObject("txtTop.Multiline")));
		this.txtTop.Name = "txtTop";
		this.txtTop.PasswordChar = ((char)(resources.GetObject("txtTop.PasswordChar")));
		this.txtTop.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtTop.RightToLeft")));
		this.txtTop.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtTop.ScrollBars")));
		this.txtTop.Size = ((System.Drawing.Size)(resources.GetObject("txtTop.Size")));
		this.txtTop.TabIndex = ((int)(resources.GetObject("txtTop.TabIndex")));
		this.txtTop.Text = resources.GetString("txtTop.Text");
		this.txtTop.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtTop.TextAlign")));
		this.txtTop.Visible = ((bool)(resources.GetObject("txtTop.Visible")));
		this.txtTop.WordWrap = ((bool)(resources.GetObject("txtTop.WordWrap")));
		// 
		// Label12
		// 
		this.Label12.AccessibleDescription = resources.GetString("Label12.AccessibleDescription");
		this.Label12.AccessibleName = resources.GetString("Label12.AccessibleName");
		this.Label12.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label12.Anchor")));
		this.Label12.AutoSize = ((bool)(resources.GetObject("Label12.AutoSize")));
		this.Label12.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label12.Dock")));
		this.Label12.Enabled = ((bool)(resources.GetObject("Label12.Enabled")));
		this.Label12.Font = ((System.Drawing.Font)(resources.GetObject("Label12.Font")));
		this.Label12.Image = ((System.Drawing.Image)(resources.GetObject("Label12.Image")));
		this.Label12.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label12.ImageAlign")));
		this.Label12.ImageIndex = ((int)(resources.GetObject("Label12.ImageIndex")));
		this.Label12.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label12.ImeMode")));
		this.Label12.Location = ((System.Drawing.Point)(resources.GetObject("Label12.Location")));
		this.Label12.Name = "Label12";
		this.Label12.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label12.RightToLeft")));
		this.Label12.Size = ((System.Drawing.Size)(resources.GetObject("Label12.Size")));
		this.Label12.TabIndex = ((int)(resources.GetObject("Label12.TabIndex")));
		this.Label12.Text = resources.GetString("Label12.Text");
		this.Label12.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label12.TextAlign")));
		this.Label12.Visible = ((bool)(resources.GetObject("Label12.Visible")));
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
		// chkFullScreen
		// 
		this.chkFullScreen.AccessibleDescription = resources.GetString("chkFullScreen.AccessibleDescription");
		this.chkFullScreen.AccessibleName = resources.GetString("chkFullScreen.AccessibleName");
		this.chkFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkFullScreen.Anchor")));
		this.chkFullScreen.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkFullScreen.Appearance")));
		this.chkFullScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkFullScreen.BackgroundImage")));
		this.chkFullScreen.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkFullScreen.CheckAlign")));
		this.chkFullScreen.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkFullScreen.Dock")));
		this.chkFullScreen.Enabled = ((bool)(resources.GetObject("chkFullScreen.Enabled")));
		this.chkFullScreen.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkFullScreen.FlatStyle")));
		this.chkFullScreen.Font = ((System.Drawing.Font)(resources.GetObject("chkFullScreen.Font")));
		this.chkFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("chkFullScreen.Image")));
		this.chkFullScreen.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkFullScreen.ImageAlign")));
		this.chkFullScreen.ImageIndex = ((int)(resources.GetObject("chkFullScreen.ImageIndex")));
		this.chkFullScreen.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkFullScreen.ImeMode")));
		this.chkFullScreen.Location = ((System.Drawing.Point)(resources.GetObject("chkFullScreen.Location")));
		this.chkFullScreen.Name = "chkFullScreen";
		this.chkFullScreen.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkFullScreen.RightToLeft")));
		this.chkFullScreen.Size = ((System.Drawing.Size)(resources.GetObject("chkFullScreen.Size")));
		this.chkFullScreen.TabIndex = ((int)(resources.GetObject("chkFullScreen.TabIndex")));
		this.chkFullScreen.Text = resources.GetString("chkFullScreen.Text");
		this.chkFullScreen.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkFullScreen.TextAlign")));
		this.chkFullScreen.Visible = ((bool)(resources.GetObject("chkFullScreen.Visible")));
		// 
		// chkAddressBar
		// 
		this.chkAddressBar.AccessibleDescription = resources.GetString("chkAddressBar.AccessibleDescription");
		this.chkAddressBar.AccessibleName = resources.GetString("chkAddressBar.AccessibleName");
		this.chkAddressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkAddressBar.Anchor")));
		this.chkAddressBar.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkAddressBar.Appearance")));
		this.chkAddressBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkAddressBar.BackgroundImage")));
		this.chkAddressBar.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAddressBar.CheckAlign")));
		this.chkAddressBar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkAddressBar.Dock")));
		this.chkAddressBar.Enabled = ((bool)(resources.GetObject("chkAddressBar.Enabled")));
		this.chkAddressBar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkAddressBar.FlatStyle")));
		this.chkAddressBar.Font = ((System.Drawing.Font)(resources.GetObject("chkAddressBar.Font")));
		this.chkAddressBar.Image = ((System.Drawing.Image)(resources.GetObject("chkAddressBar.Image")));
		this.chkAddressBar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAddressBar.ImageAlign")));
		this.chkAddressBar.ImageIndex = ((int)(resources.GetObject("chkAddressBar.ImageIndex")));
		this.chkAddressBar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkAddressBar.ImeMode")));
		this.chkAddressBar.Location = ((System.Drawing.Point)(resources.GetObject("chkAddressBar.Location")));
		this.chkAddressBar.Name = "chkAddressBar";
		this.chkAddressBar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkAddressBar.RightToLeft")));
		this.chkAddressBar.Size = ((System.Drawing.Size)(resources.GetObject("chkAddressBar.Size")));
		this.chkAddressBar.TabIndex = ((int)(resources.GetObject("chkAddressBar.TabIndex")));
		this.chkAddressBar.Text = resources.GetString("chkAddressBar.Text");
		this.chkAddressBar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAddressBar.TextAlign")));
		this.chkAddressBar.Visible = ((bool)(resources.GetObject("chkAddressBar.Visible")));
		this.chkAddressBar.CheckedChanged += new System.EventHandler(this.chkAddressBar_CheckedChanged);
		// 
		// Label4
		// 
		this.Label4.AccessibleDescription = resources.GetString("Label4.AccessibleDescription");
		this.Label4.AccessibleName = resources.GetString("Label4.AccessibleName");
		this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label4.Anchor")));
		this.Label4.AutoSize = ((bool)(resources.GetObject("Label4.AutoSize")));
		this.Label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label4.Dock")));
		this.Label4.Enabled = ((bool)(resources.GetObject("Label4.Enabled")));
		this.Label4.Font = ((System.Drawing.Font)(resources.GetObject("Label4.Font")));
		this.Label4.Image = ((System.Drawing.Image)(resources.GetObject("Label4.Image")));
		this.Label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label4.ImageAlign")));
		this.Label4.ImageIndex = ((int)(resources.GetObject("Label4.ImageIndex")));
		this.Label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label4.ImeMode")));
		this.Label4.Location = ((System.Drawing.Point)(resources.GetObject("Label4.Location")));
		this.Label4.Name = "Label4";
		this.Label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label4.RightToLeft")));
		this.Label4.Size = ((System.Drawing.Size)(resources.GetObject("Label4.Size")));
		this.Label4.TabIndex = ((int)(resources.GetObject("Label4.TabIndex")));
		this.Label4.Text = resources.GetString("Label4.Text");
		this.Label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label4.TextAlign")));
		this.Label4.Visible = ((bool)(resources.GetObject("Label4.Visible")));
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
		this.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
		// btnBrowse2
		// 
		this.btnBrowse2.AccessibleDescription = resources.GetString("btnBrowse2.AccessibleDescription");
		this.btnBrowse2.AccessibleName = resources.GetString("btnBrowse2.AccessibleName");
		this.btnBrowse2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnBrowse2.Anchor")));
		this.btnBrowse2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.btnBrowse2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowse2.BackgroundImage")));
		this.btnBrowse2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnBrowse2.Dock")));
		this.btnBrowse2.Enabled = ((bool)(resources.GetObject("btnBrowse2.Enabled")));
		this.btnBrowse2.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnBrowse2.FlatStyle")));
		this.btnBrowse2.Font = ((System.Drawing.Font)(resources.GetObject("btnBrowse2.Font")));
		this.btnBrowse2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
		this.btnBrowse2.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse2.Image")));
		this.btnBrowse2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBrowse2.ImageAlign")));
		this.btnBrowse2.ImageIndex = ((int)(resources.GetObject("btnBrowse2.ImageIndex")));
		this.btnBrowse2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnBrowse2.ImeMode")));
		this.btnBrowse2.Location = ((System.Drawing.Point)(resources.GetObject("btnBrowse2.Location")));
		this.btnBrowse2.Name = "btnBrowse2";
		this.btnBrowse2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnBrowse2.RightToLeft")));
		this.btnBrowse2.Size = ((System.Drawing.Size)(resources.GetObject("btnBrowse2.Size")));
		this.btnBrowse2.TabIndex = ((int)(resources.GetObject("btnBrowse2.TabIndex")));
		this.btnBrowse2.Text = resources.GetString("btnBrowse2.Text");
		this.btnBrowse2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBrowse2.TextAlign")));
		this.btnBrowse2.Visible = ((bool)(resources.GetObject("btnBrowse2.Visible")));
		this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
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
		this.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
		// tbAddress2
		// 
		this.tbAddress2.AccessibleDescription = resources.GetString("tbAddress2.AccessibleDescription");
		this.tbAddress2.AccessibleName = resources.GetString("tbAddress2.AccessibleName");
		this.tbAddress2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("tbAddress2.Anchor")));
		this.tbAddress2.AutoSize = ((bool)(resources.GetObject("tbAddress2.AutoSize")));
		this.tbAddress2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbAddress2.BackgroundImage")));
		this.tbAddress2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("tbAddress2.Dock")));
		this.tbAddress2.Enabled = ((bool)(resources.GetObject("tbAddress2.Enabled")));
		this.tbAddress2.Font = ((System.Drawing.Font)(resources.GetObject("tbAddress2.Font")));
		this.tbAddress2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("tbAddress2.ImeMode")));
		this.tbAddress2.Location = ((System.Drawing.Point)(resources.GetObject("tbAddress2.Location")));
		this.tbAddress2.MaxLength = ((int)(resources.GetObject("tbAddress2.MaxLength")));
		this.tbAddress2.Multiline = ((bool)(resources.GetObject("tbAddress2.Multiline")));
		this.tbAddress2.Name = "tbAddress2";
		this.tbAddress2.PasswordChar = ((char)(resources.GetObject("tbAddress2.PasswordChar")));
		this.tbAddress2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("tbAddress2.RightToLeft")));
		this.tbAddress2.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("tbAddress2.ScrollBars")));
		this.tbAddress2.Size = ((System.Drawing.Size)(resources.GetObject("tbAddress2.Size")));
		this.tbAddress2.TabIndex = ((int)(resources.GetObject("tbAddress2.TabIndex")));
		this.tbAddress2.Text = resources.GetString("tbAddress2.Text");
		this.tbAddress2.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("tbAddress2.TextAlign")));
		this.tbAddress2.Visible = ((bool)(resources.GetObject("tbAddress2.Visible")));
		this.tbAddress2.WordWrap = ((bool)(resources.GetObject("tbAddress2.WordWrap")));
		// 
		// frmMain
		// 
		this.AcceptButton = this.btnBrowse;
		this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
		this.AccessibleName = resources.GetString("$this.AccessibleName");
		this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
		this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
		this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
		this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
		this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
		this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
		this.Controls.Add(this.TabControl1);
		this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
		this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
		this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
		this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
		this.Menu = this.mnuMain;
		this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
		this.Name = "frmMain";
		this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
		this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
		this.Text = resources.GetString("$this.Text");
		this.Load += new System.EventHandler(this.frmMain_Load);
		this.TabControl1.ResumeLayout(false);
		this.tabActiveX.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.ieForHosting)).EndInit();
		this.tabAutomation.ResumeLayout(false);
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

    protected mshtml.IHTMLDocument2 htmlDocAutomation;
	protected mshtml.IHTMLDocument2 htmlDocActiveX;
    protected SHDocVw.InternetExplorer ieForAutomation;
    protected mshtml.IHTMLElement ieElement;
    protected frmStatus fStatus;

    private void frmMain_Load(object sender, System.EventArgs e) {

        // ieForHosting is the embedded ActiveX control. The AxSHDocVw.WebBrowser 

        // object is used when you want to run IE an embedded control.

		object missing = null;

        ieForHosting.Navigate("www.microsoft.com",ref missing, ref missing, 
				ref missing, ref missing);

        EnableNavifHistory();

    }

    private void btnBrowse_Click(object sender, System.EventArgs e) 
	{
        // Notice here, unlike the Back and Forward button click event handlers, that 
        // you use the WebBrowser object not the Document object assigned to the 
        // htmlDocActiveX interface. if you use the latter the navigation will not occur. 
		object missing = null;
        ieForHosting.Navigate(tbAddress.Text, ref missing ,ref missing,
				ref missing, ref missing);

    }

    private void btnBack_Click(object sender, System.EventArgs e) 
	{
		object dir = -1;
        htmlDocActiveX.parentWindow.history.go(ref dir);
        tbAddress.Text = htmlDocActiveX.url;

    }

    private void btnForward_Click(object sender, System.EventArgs e)
	{
		
		object dir = 1;
        htmlDocActiveX.parentWindow.history.go(ref dir);

        tbAddress.Text = htmlDocActiveX.url;

    }

    private void btnBrowse2_Click(object sender, System.EventArgs e) 
{
        // Open internet explorer, and configure its user interface based on
        // the options selected by the user.

        if (ieForAutomation == null) {

            ieForAutomation = new SHDocVw.InternetExplorer();
			this.ieForAutomation.DocumentComplete +=new SHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(ieForAutomation_DocumentComplete);
			this.ieForAutomation.OnQuit +=new SHDocVw.DWebBrowserEvents2_OnQuitEventHandler(ieForAutomation_OnQuit);

        }
        ieForAutomation.AddressBar = chkAddressBar.Checked;
        ieForAutomation.FullScreen = chkFullScreen.Checked;
        ieForAutomation.MenuBar = chkMenuBar.Checked;
        ieForAutomation.Resizable = chkResizable.Checked;
        ieForAutomation.StatusBar = chkStatusBar.Checked;
        ieForAutomation.TheaterMode = chkTheaterMode.Checked;
        ieForAutomation.ToolBar = Convert.ToInt32(chkToolBar.Checked);

        if (IsNumeric(txtHeight.Text)) {

            ieForAutomation.Height = Int32.Parse(txtHeight.Text);

        }

        if (IsNumeric(txtWidth.Text)) {

            ieForAutomation.Width = Int32.Parse(txtWidth.Text);

        }

        if (IsNumeric(txtTop.Text)) {

            ieForAutomation.Top = Int32.Parse(txtTop.Text);

        }

        if (IsNumeric(txtLeft.Text)) {

            ieForAutomation.Left = Int32.Parse(txtLeft.Text);

        }

        this.Cursor = Cursors.WaitCursor;

        fStatus = new frmStatus();

        fStatus.Show("Connecting to Web page and processing HTML. Please stand by...");

        ieForAutomation.Visible = true;

		object missing = null;

        ieForAutomation.Navigate(tbAddress2.Text,ref missing, ref missing,
				ref missing, ref missing);

    }

    private void chkAddressBar_CheckedChanged(object sender, System.EventArgs e) 
	{
        // The address bar will only display if the toolbar is also enabled.

        if ((chkAddressBar.Checked == true) & (chkToolBar.Checked == false)) {

            if (MessageBox.Show("You must also enable the toolbar for the " + 
                "address bar to be visible.  Do you want to enable the " + 
                "tool bar?", 
                "Enable ToolBar?", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes) 
			{

                chkToolBar.Checked = true;

            }

        }

    }

    // Fires when the document has completely loaded.

    private void ieForAutomation_DocumentComplete(object pDisp, ref object URL) 
	{
        // This event will fire in a different thread than the one that created the
        // form.  You can only modify the user interface through the thread that
        // created it because the underlying UI libraries are not thread safe.
        // To overcome this problem, you "marshal" the information back to the main
        // thread through the Invoke method.



		HideStatusDelegate hd = new HideStatusDelegate(this.HideStatus);
		
		this.Invoke(hd);
        //this.Invoke(new HideStatusDelegate(AddressOf this.HideStatus));

    }

    private void ieForAutomation_OnQuit() 
	{
        ieForAutomation = null;

    }

    // Fires when the document has completely loaded. if you don't attempt to assign
    // htmlDocActiveX somewhere other than this handler you will get a null object reference 
    // if a document has not been completely loaded.

    private void ieForHosting_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e) 
	{
        htmlDocActiveX = (mshtml.IHTMLDocument2) ieForHosting.Document;

		OnCompleteDelegate ocd = new OnCompleteDelegate(this.OnComplete);

        this.Invoke(ocd, new Object[] {htmlDocActiveX});

    }

    protected void EnableNavifHistory()
	{

        // if the history is empty, disable the forward and back buttons.
		try
		{
			if ((htmlDocActiveX == null) | (htmlDocActiveX.parentWindow.history.length == 0)) 
			{
				btnBack.Enabled = false;
				btnForward.Enabled = false;
			}
			else 
			{
				btnBack.Enabled = true;
				btnForward.Enabled = true;
			}
		}
		catch
		{
			btnBack.Enabled = false;
			btnForward.Enabled = false;
		}

    }

    // Hide the status form when the page finishes loading.

    delegate void HideStatusDelegate();

    protected void HideStatus(){

        fStatus.Hide();
        this.Cursor = Cursors.Default;

    }

    // Fires when the browser ActiveX control finishes loading a document

    delegate void OnCompleteDelegate(mshtml.IHTMLDocument2 htmlDoc);

    public void OnComplete(mshtml.IHTMLDocument2 htmlDoc)
	{

        tbAddress.Text = htmlDoc.url;
        EnableNavifHistory();

    }

	public bool IsNumeric(string val)
	{
		try
		{
			double result = 0;
			return Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out result);
		}
		catch
		{
			return false;
		}
	}

}

