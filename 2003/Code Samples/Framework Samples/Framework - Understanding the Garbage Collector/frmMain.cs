//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

    // Declare a class variable containing  a GcTest object.

    private GcTest m_TestObject;

    private const int OBJECT_DEPTH  = 3;

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

	protected override void Dispose(bool disposing) 
	{

		if (disposing) 
		{

			if (components != null) 
			{

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

    private System.Windows.Forms.ListBox lstCreatedObjects;

    private System.Windows.Forms.TextBox txtActivity;

    private System.Windows.Forms.Button btnKillObject;

    private System.Windows.Forms.Button btnDisposeObject;

    private System.Windows.Forms.Button btnClear;

    private System.Windows.Forms.Button btnRunGC;

    private System.Windows.Forms.CheckBox chkIsFinalizeSuppressed;

    private System.Windows.Forms.Button btnCreateObjects;

    private System.Windows.Forms.Label lblActivityLog;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.txtActivity = new System.Windows.Forms.TextBox();

        this.btnCreateObjects = new System.Windows.Forms.Button();

        this.lstCreatedObjects = new System.Windows.Forms.ListBox();

        this.btnKillObject = new System.Windows.Forms.Button();

        this.btnDisposeObject = new System.Windows.Forms.Button();

        this.btnClear = new System.Windows.Forms.Button();

        this.btnRunGC = new System.Windows.Forms.Button();

        this.chkIsFinalizeSuppressed = new System.Windows.Forms.CheckBox();

        this.lblActivityLog = new System.Windows.Forms.Label();

        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

        this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

        //

        //mnuFile

        //

        this.mnuFile.Enabled = (bool) resources.GetObject("mnuFile.Enabled");

        this.mnuFile.Index = 0;

        this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

        this.mnuFile.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuFile.Shortcut");

        this.mnuFile.ShowShortcut = (bool) resources.GetObject("mnuFile.ShowShortcut");

        this.mnuFile.Text = resources.GetString("mnuFile.Text");

        this.mnuFile.Visible = (bool) resources.GetObject("mnuFile.Visible");

        //

        //mnuExit

        //

        this.mnuExit.Enabled = (bool) resources.GetObject("mnuExit.Enabled");

        this.mnuExit.Index = 0;

        this.mnuExit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuExit.Shortcut");

        this.mnuExit.ShowShortcut = (bool) resources.GetObject("mnuExit.ShowShortcut");

        this.mnuExit.Text = resources.GetString("mnuExit.Text");

        this.mnuExit.Visible = (bool) resources.GetObject("mnuExit.Visible");
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
        //

        //mnuHelp

        //

        this.mnuHelp.Enabled = (bool) resources.GetObject("mnuHelp.Enabled");

        this.mnuHelp.Index = 1;

        this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

        this.mnuHelp.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuHelp.Shortcut");

        this.mnuHelp.ShowShortcut = (bool) resources.GetObject("mnuHelp.ShowShortcut");

        this.mnuHelp.Text = resources.GetString("mnuHelp.Text");

        this.mnuHelp.Visible = (bool) resources.GetObject("mnuHelp.Visible");

        //

        //mnuAbout

        //

        this.mnuAbout.Enabled = (bool) resources.GetObject("mnuAbout.Enabled");

        this.mnuAbout.Index = 0;

        this.mnuAbout.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuAbout.Shortcut");

        this.mnuAbout.ShowShortcut = (bool) resources.GetObject("mnuAbout.ShowShortcut");

        this.mnuAbout.Text = resources.GetString("mnuAbout.Text");

        this.mnuAbout.Visible = (bool) resources.GetObject("mnuAbout.Visible");
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);

        //

        //txtActivity

        //

        this.txtActivity.AccessibleDescription = resources.GetString("txtActivity.AccessibleDescription");

        this.txtActivity.AccessibleName = resources.GetString("txtActivity.AccessibleName");

        this.txtActivity.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtActivity.Anchor");

        this.txtActivity.AutoSize = (bool) resources.GetObject("txtActivity.AutoSize");

        this.txtActivity.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtActivity.BackgroundImage");

        this.txtActivity.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtActivity.Dock");

        this.txtActivity.Enabled = (bool) resources.GetObject("txtActivity.Enabled");

        this.txtActivity.Font = (System.Drawing.Font) resources.GetObject("txtActivity.Font");

        this.txtActivity.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtActivity.ImeMode");

        this.txtActivity.Location = (System.Drawing.Point) resources.GetObject("txtActivity.Location");

        this.txtActivity.MaxLength = (int) resources.GetObject("txtActivity.MaxLength");

        this.txtActivity.Multiline = (bool) resources.GetObject("txtActivity.Multiline");

        this.txtActivity.Name = "txtActivity";

        this.txtActivity.PasswordChar = (char) resources.GetObject("txtActivity.PasswordChar");

        this.txtActivity.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtActivity.RightToLeft");

        this.txtActivity.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtActivity.ScrollBars");

        this.txtActivity.Size = (System.Drawing.Size) resources.GetObject("txtActivity.Size");

        this.txtActivity.TabIndex = (int) resources.GetObject("txtActivity.TabIndex");

        this.txtActivity.TabStop = false;

        this.txtActivity.Text = resources.GetString("txtActivity.Text");

        this.txtActivity.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtActivity.TextAlign");

        this.txtActivity.Visible = (bool) resources.GetObject("txtActivity.Visible");

        this.txtActivity.WordWrap = (bool) resources.GetObject("txtActivity.WordWrap");

        //

        //btnCreateObjects

        //

        this.btnCreateObjects.AccessibleDescription = resources.GetString("btnCreateObjects.AccessibleDescription");

        this.btnCreateObjects.AccessibleName = resources.GetString("btnCreateObjects.AccessibleName");

        this.btnCreateObjects.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateObjects.Anchor");

        this.btnCreateObjects.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateObjects.BackgroundImage");

        this.btnCreateObjects.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateObjects.Dock");

        this.btnCreateObjects.Enabled = (bool) resources.GetObject("btnCreateObjects.Enabled");

        this.btnCreateObjects.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateObjects.FlatStyle");

        this.btnCreateObjects.Font = (System.Drawing.Font) resources.GetObject("btnCreateObjects.Font");

        this.btnCreateObjects.Image = (System.Drawing.Image) resources.GetObject("btnCreateObjects.Image");

        this.btnCreateObjects.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateObjects.ImageAlign");

        this.btnCreateObjects.ImageIndex = (int) resources.GetObject("btnCreateObjects.ImageIndex");

        this.btnCreateObjects.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateObjects.ImeMode");

        this.btnCreateObjects.Location = (System.Drawing.Point) resources.GetObject("btnCreateObjects.Location");

        this.btnCreateObjects.Name = "btnCreateObjects";

        this.btnCreateObjects.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateObjects.RightToLeft");

        this.btnCreateObjects.Size = (System.Drawing.Size) resources.GetObject("btnCreateObjects.Size");

        this.btnCreateObjects.TabIndex = (int) resources.GetObject("btnCreateObjects.TabIndex");

        this.btnCreateObjects.Text = resources.GetString("btnCreateObjects.Text");

        this.btnCreateObjects.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateObjects.TextAlign");

        this.btnCreateObjects.Visible = (bool) resources.GetObject("btnCreateObjects.Visible");

        this.btnCreateObjects.Click +=new EventHandler(btnCreateObjects_Click);
		//

        //lstCreatedObjects

        //

        this.lstCreatedObjects.AccessibleDescription = resources.GetString("lstCreatedObjects.AccessibleDescription");

        this.lstCreatedObjects.AccessibleName = resources.GetString("lstCreatedObjects.AccessibleName");

        this.lstCreatedObjects.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lstCreatedObjects.Anchor");

        this.lstCreatedObjects.BackgroundImage = (System.Drawing.Image) resources.GetObject("lstCreatedObjects.BackgroundImage");

        this.lstCreatedObjects.ColumnWidth = (int) resources.GetObject("lstCreatedObjects.ColumnWidth");

        this.lstCreatedObjects.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lstCreatedObjects.Dock");

        this.lstCreatedObjects.Enabled = (bool) resources.GetObject("lstCreatedObjects.Enabled");

        this.lstCreatedObjects.Font = (System.Drawing.Font) resources.GetObject("lstCreatedObjects.Font");

        this.lstCreatedObjects.HorizontalExtent = (int) resources.GetObject("lstCreatedObjects.HorizontalExtent");

        this.lstCreatedObjects.HorizontalScrollbar = (bool) resources.GetObject("lstCreatedObjects.HorizontalScrollbar");

        this.lstCreatedObjects.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lstCreatedObjects.ImeMode");

        this.lstCreatedObjects.IntegralHeight = (bool) resources.GetObject("lstCreatedObjects.IntegralHeight");

        this.lstCreatedObjects.ItemHeight = (int) resources.GetObject("lstCreatedObjects.ItemHeight");

        this.lstCreatedObjects.Location = (System.Drawing.Point) resources.GetObject("lstCreatedObjects.Location");

        this.lstCreatedObjects.Name = "lstCreatedObjects";

        this.lstCreatedObjects.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lstCreatedObjects.RightToLeft");

        this.lstCreatedObjects.ScrollAlwaysVisible = (bool) resources.GetObject("lstCreatedObjects.ScrollAlwaysVisible");

        this.lstCreatedObjects.Size = (System.Drawing.Size) resources.GetObject("lstCreatedObjects.Size");

        this.lstCreatedObjects.TabIndex = (int) resources.GetObject("lstCreatedObjects.TabIndex");

        this.lstCreatedObjects.TabStop = false;

        this.lstCreatedObjects.Visible = (bool) resources.GetObject("lstCreatedObjects.Visible");

        //

        //btnKillObject

        //

        this.btnKillObject.AccessibleDescription = resources.GetString("btnKillObject.AccessibleDescription");

        this.btnKillObject.AccessibleName = resources.GetString("btnKillObject.AccessibleName");

        this.btnKillObject.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnKillObject.Anchor");

        this.btnKillObject.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnKillObject.BackgroundImage");

        this.btnKillObject.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnKillObject.Dock");

        this.btnKillObject.Enabled = (bool) resources.GetObject("btnKillObject.Enabled");

        this.btnKillObject.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnKillObject.FlatStyle");

        this.btnKillObject.Font = (System.Drawing.Font) resources.GetObject("btnKillObject.Font");

        this.btnKillObject.Image = (System.Drawing.Image) resources.GetObject("btnKillObject.Image");

        this.btnKillObject.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnKillObject.ImageAlign");

        this.btnKillObject.ImageIndex = (int) resources.GetObject("btnKillObject.ImageIndex");

        this.btnKillObject.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnKillObject.ImeMode");

        this.btnKillObject.Location = (System.Drawing.Point) resources.GetObject("btnKillObject.Location");

        this.btnKillObject.Name = "btnKillObject";

        this.btnKillObject.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnKillObject.RightToLeft");

        this.btnKillObject.Size = (System.Drawing.Size) resources.GetObject("btnKillObject.Size");

        this.btnKillObject.TabIndex = (int) resources.GetObject("btnKillObject.TabIndex");

        this.btnKillObject.Text = resources.GetString("btnKillObject.Text");

        this.btnKillObject.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnKillObject.TextAlign");

        this.btnKillObject.Visible = (bool) resources.GetObject("btnKillObject.Visible");
		
		this.btnKillObject.Click+=new EventHandler(btnKillObject_Click);
        //

        //btnDisposeObject

        //

        this.btnDisposeObject.AccessibleDescription = resources.GetString("btnDisposeObject.AccessibleDescription");

        this.btnDisposeObject.AccessibleName = resources.GetString("btnDisposeObject.AccessibleName");

        this.btnDisposeObject.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnDisposeObject.Anchor");

        this.btnDisposeObject.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnDisposeObject.BackgroundImage");

        this.btnDisposeObject.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnDisposeObject.Dock");

        this.btnDisposeObject.Enabled = (bool) resources.GetObject("btnDisposeObject.Enabled");

        this.btnDisposeObject.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnDisposeObject.FlatStyle");

        this.btnDisposeObject.Font = (System.Drawing.Font) resources.GetObject("btnDisposeObject.Font");

        this.btnDisposeObject.Image = (System.Drawing.Image) resources.GetObject("btnDisposeObject.Image");

        this.btnDisposeObject.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDisposeObject.ImageAlign");

        this.btnDisposeObject.ImageIndex = (int) resources.GetObject("btnDisposeObject.ImageIndex");

        this.btnDisposeObject.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnDisposeObject.ImeMode");

        this.btnDisposeObject.Location = (System.Drawing.Point) resources.GetObject("btnDisposeObject.Location");

        this.btnDisposeObject.Name = "btnDisposeObject";

        this.btnDisposeObject.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnDisposeObject.RightToLeft");

        this.btnDisposeObject.Size = (System.Drawing.Size) resources.GetObject("btnDisposeObject.Size");

        this.btnDisposeObject.TabIndex = (int) resources.GetObject("btnDisposeObject.TabIndex");

        this.btnDisposeObject.Text = resources.GetString("btnDisposeObject.Text");

        this.btnDisposeObject.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDisposeObject.TextAlign");

        this.btnDisposeObject.Visible = (bool) resources.GetObject("btnDisposeObject.Visible");
		
		this.btnDisposeObject.Click+=new EventHandler(btnDisposeObject_Click);
        //

        //btnClear

        //

        this.btnClear.AccessibleDescription = resources.GetString("btnClear.AccessibleDescription");

        this.btnClear.AccessibleName = resources.GetString("btnClear.AccessibleName");

        this.btnClear.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnClear.Anchor");

        this.btnClear.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnClear.BackgroundImage");

        this.btnClear.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnClear.Dock");

        this.btnClear.Enabled = (bool) resources.GetObject("btnClear.Enabled");

        this.btnClear.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnClear.FlatStyle");

        this.btnClear.Font = (System.Drawing.Font) resources.GetObject("btnClear.Font");

        this.btnClear.Image = (System.Drawing.Image) resources.GetObject("btnClear.Image");

        this.btnClear.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnClear.ImageAlign");

        this.btnClear.ImageIndex = (int) resources.GetObject("btnClear.ImageIndex");

        this.btnClear.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnClear.ImeMode");

        this.btnClear.Location = (System.Drawing.Point) resources.GetObject("btnClear.Location");

        this.btnClear.Name = "btnClear";

        this.btnClear.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnClear.RightToLeft");

        this.btnClear.Size = (System.Drawing.Size) resources.GetObject("btnClear.Size");

        this.btnClear.TabIndex = (int) resources.GetObject("btnClear.TabIndex");

        this.btnClear.Text = resources.GetString("btnClear.Text");

        this.btnClear.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnClear.TextAlign");

        this.btnClear.Visible = (bool) resources.GetObject("btnClear.Visible");
		this.btnClear.Click +=new EventHandler(btnClear_Click);

        //

        //btnRunGC

        //

        this.btnRunGC.AccessibleDescription = resources.GetString("btnRunGC.AccessibleDescription");

        this.btnRunGC.AccessibleName = resources.GetString("btnRunGC.AccessibleName");

        this.btnRunGC.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRunGC.Anchor");

        this.btnRunGC.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRunGC.BackgroundImage");

        this.btnRunGC.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRunGC.Dock");

        this.btnRunGC.Enabled = (bool) resources.GetObject("btnRunGC.Enabled");

        this.btnRunGC.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRunGC.FlatStyle");

        this.btnRunGC.Font = (System.Drawing.Font) resources.GetObject("btnRunGC.Font");

        this.btnRunGC.Image = (System.Drawing.Image) resources.GetObject("btnRunGC.Image");

        this.btnRunGC.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRunGC.ImageAlign");

        this.btnRunGC.ImageIndex = (int) resources.GetObject("btnRunGC.ImageIndex");

        this.btnRunGC.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRunGC.ImeMode");

        this.btnRunGC.Location = (System.Drawing.Point) resources.GetObject("btnRunGC.Location");

        this.btnRunGC.Name = "btnRunGC";

        this.btnRunGC.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRunGC.RightToLeft");

        this.btnRunGC.Size = (System.Drawing.Size) resources.GetObject("btnRunGC.Size");

        this.btnRunGC.TabIndex = (int) resources.GetObject("btnRunGC.TabIndex");

        this.btnRunGC.Text = resources.GetString("btnRunGC.Text");

        this.btnRunGC.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRunGC.TextAlign");

        this.btnRunGC.Visible = (bool) resources.GetObject("btnRunGC.Visible");
		this.btnRunGC.Click +=new EventHandler(btnRunGC_Click);

        //

        //chkIsFinalizeSuppressed

        //

        this.chkIsFinalizeSuppressed.AccessibleDescription = resources.GetString("chkIsFinalizeSuppressed.AccessibleDescription");

        this.chkIsFinalizeSuppressed.AccessibleName = resources.GetString("chkIsFinalizeSuppressed.AccessibleName");

        this.chkIsFinalizeSuppressed.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkIsFinalizeSuppressed.Anchor");

        this.chkIsFinalizeSuppressed.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkIsFinalizeSuppressed.Appearance");

        this.chkIsFinalizeSuppressed.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkIsFinalizeSuppressed.BackgroundImage");

        this.chkIsFinalizeSuppressed.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIsFinalizeSuppressed.CheckAlign");

        this.chkIsFinalizeSuppressed.Checked = true;

        this.chkIsFinalizeSuppressed.CheckState = System.Windows.Forms.CheckState.Checked;

        this.chkIsFinalizeSuppressed.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkIsFinalizeSuppressed.Dock");

        this.chkIsFinalizeSuppressed.Enabled = (bool) resources.GetObject("chkIsFinalizeSuppressed.Enabled");

        this.chkIsFinalizeSuppressed.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkIsFinalizeSuppressed.FlatStyle");

        this.chkIsFinalizeSuppressed.Font = (System.Drawing.Font) resources.GetObject("chkIsFinalizeSuppressed.Font");

        this.chkIsFinalizeSuppressed.Image = (System.Drawing.Image) resources.GetObject("chkIsFinalizeSuppressed.Image");

        this.chkIsFinalizeSuppressed.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIsFinalizeSuppressed.ImageAlign");

        this.chkIsFinalizeSuppressed.ImageIndex = (int) resources.GetObject("chkIsFinalizeSuppressed.ImageIndex");

        this.chkIsFinalizeSuppressed.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkIsFinalizeSuppressed.ImeMode");

        this.chkIsFinalizeSuppressed.Location = (System.Drawing.Point) resources.GetObject("chkIsFinalizeSuppressed.Location");

        this.chkIsFinalizeSuppressed.Name = "chkIsFinalizeSuppressed";

        this.chkIsFinalizeSuppressed.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkIsFinalizeSuppressed.RightToLeft");

        this.chkIsFinalizeSuppressed.Size = (System.Drawing.Size) resources.GetObject("chkIsFinalizeSuppressed.Size");

        this.chkIsFinalizeSuppressed.TabIndex = (int) resources.GetObject("chkIsFinalizeSuppressed.TabIndex");

        this.chkIsFinalizeSuppressed.Text = resources.GetString("chkIsFinalizeSuppressed.Text");

        this.chkIsFinalizeSuppressed.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIsFinalizeSuppressed.TextAlign");

        this.chkIsFinalizeSuppressed.Visible = (bool) resources.GetObject("chkIsFinalizeSuppressed.Visible");
		
        //

        //lblActivityLog

        //

        this.lblActivityLog.AccessibleDescription = resources.GetString("lblActivityLog.AccessibleDescription");

        this.lblActivityLog.AccessibleName = resources.GetString("lblActivityLog.AccessibleName");

        this.lblActivityLog.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblActivityLog.Anchor");

        this.lblActivityLog.AutoSize = (bool) resources.GetObject("lblActivityLog.AutoSize");

        this.lblActivityLog.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblActivityLog.Dock");

        this.lblActivityLog.Enabled = (bool) resources.GetObject("lblActivityLog.Enabled");

        this.lblActivityLog.Font = (System.Drawing.Font) resources.GetObject("lblActivityLog.Font");

        this.lblActivityLog.Image = (System.Drawing.Image) resources.GetObject("lblActivityLog.Image");

        this.lblActivityLog.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblActivityLog.ImageAlign");

        this.lblActivityLog.ImageIndex = (int) resources.GetObject("lblActivityLog.ImageIndex");

        this.lblActivityLog.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblActivityLog.ImeMode");

        this.lblActivityLog.Location = (System.Drawing.Point) resources.GetObject("lblActivityLog.Location");

        this.lblActivityLog.Name = "lblActivityLog";

        this.lblActivityLog.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblActivityLog.RightToLeft");

        this.lblActivityLog.Size = (System.Drawing.Size) resources.GetObject("lblActivityLog.Size");

        this.lblActivityLog.TabIndex = (int) resources.GetObject("lblActivityLog.TabIndex");

        this.lblActivityLog.Text = resources.GetString("lblActivityLog.Text");

        this.lblActivityLog.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblActivityLog.TextAlign");

        this.lblActivityLog.Visible = (bool) resources.GetObject("lblActivityLog.Visible");

        //

        //frmMain

        //

        this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");

        this.AccessibleName = resources.GetString("$this.AccessibleName");

        this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

        this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

        this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

        this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

        this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

        this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

        this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblActivityLog, this.btnRunGC, this.btnClear, this.btnDisposeObject, this.btnKillObject, this.lstCreatedObjects, this.btnCreateObjects, this.txtActivity, this.chkIsFinalizeSuppressed});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximizeBox = false;

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.Menu = this.mnuMain;

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmMain";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

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

    // This subroutine simple clears the txtActivity TextBox so that 

    //   the user can get a new clean look at activity.

    private void btnClear_Click(object sender, System.EventArgs e)
	{

        // Clear the TextBox.

        txtActivity.Clear();

    }

    // This subroutine creates a hierarchy of OBJECT_DEPTH + 1 objects -- the 

    //   main object, and OBJECT_DEPTH children

    private void btnCreateObjects_Click(object sender, System.EventArgs e) 
	{

        // Test for existence of m_TextObject. Only allow the user to create

        //   one object tree at a time.

		if (m_TestObject == null)
		{

			// Output activity to log.

			this.AddToActivityLog(" -- Creating Object Tree -- ");

			// Create the test object. This will automatically create the 
			//   object hierarchy since the GcTest constructor automatically
			//   calls itself recursively OBJECT_DEPTH number of times.

			m_TestObject = new GcTest("TestObject", OBJECT_DEPTH);

			// Add an event handler to handle the information events that
			//   are raised by the GcTest object

			m_TestObject.ObjectGcInfo +=new GcTest.InfoEventHandler(myObjectEventHandler);
				
			// Show the generation numbers and display them in the activity log.

			// Output the ArrayList strings (Generations) to the Activity Log

            

			foreach(Object myObject in m_TestObject.GetSelfAndChildGenerations())
			{

				AddToActivityLog(myObject.ToString());

			}

			// Redisplay the object hierarchy in the ListBox

			ShowTestObjects();
		}
		else 
		{

			// Only let the user create one tree. Object exists so just
			//   warn the user.

			MessageBox.Show("Please Kill existing objects before creating new objects.", this.Text);

		}

    }

    // This subroutine disposes of the object selected in the lstCreatedObjects
    //   ListBox. How the objects are Disposed depends on whether the 
    //   chkIsFinalizeSuppressed is checked. if it is checked, then the Dispose
    //   method will suppress the finalization of the object and its children, 
    //   otherwise the garbage collector will run.
    // The way the Dispose method of the GcTest class is designed, it will Dispose
    //   and kill each of its child objects, but will not kill itself.

    private void btnDisposeObject_Click(object sender, System.EventArgs e)
	{

        // Check to ensure that there is a selected item 

        if (this.lstCreatedObjects.SelectedItem == null)
		{

            return;

        }

        // Get the name of the selected object from the ListBox

        string strName  = this.lstCreatedObjects.SelectedItem.ToString();

        // Output activity to log.

        AddToActivityLog(" -- Disposing of " + strName + " -- ");

        // Check to see what object is being Disposed. if it is not 
        //   the current object, then call the DisposeChildNamed() 
        //   subroutine to try to find the right object to dispose of.

		if (strName == this.m_TestObject.Name)
		{

			// Dispose of m_TestObject.

			m_TestObject.Dispose(chkIsFinalizeSuppressed.Checked);

			// Set it equal to null.

			m_TestObject = null;
		}
		else 
		{

			// try { to find object to Dispose by searching through
			//   child hierarchy.

			m_TestObject.DisposeChildNamed(strName,chkIsFinalizeSuppressed.Checked);

		}

        // Redisplay the object hierarchy in the ListBox.

        ShowTestObjects();

    }

    // This subroutine kills the object selected in the lstCreatedObjects
    //   ListBox by setting it to null, which opens it up for Garbage
    //   Collection. 

    private void btnKillObject_Click(object sender, System.EventArgs e) 
	{

        // Check to ensure that there is a selected item 

        if (this.lstCreatedObjects.SelectedItem == null)
		{

            return;

        }

        // Get the name of the selected object from the ListBox

        string strName  = this.lstCreatedObjects.SelectedItem.ToString();

        // Output activity to log.

        this.AddToActivityLog(" -- Killing " + strName + " -- ");

        // Check to see what object is being killed. if it is not 
        //   the current object, then call the KillChildNamed() 
        //   subroutine to try to find the right object to kill.

		if (strName == this.m_TestObject.Name)
		{

			// Kill m_TestObject by setting it equal to null.

			m_TestObject = null;
		}
		else 
		{

			// try { to find object to Dispose by searching through
			//   child hierarchy.

			m_TestObject.KillChildNamed(strName);
		}

        // Redisplay the object hierarchy in the ListBox
        ShowTestObjects();

    }

    // This subroutine forces the Garbage Collector (GC) to run. Remember, though, 
    //  even the GC.Collect() method is not deterministic. That means that the OS 
    //  may delay running the Garbage Collector to finish some currently running
    //  tasks. In practice, you can expect the GC to run within a second or
    //  so of the Collect() method being called.

    private void btnRunGC_Click(object sender, System.EventArgs e)
	{

        // Get rid of reference to object in the ListBox

        this.lstCreatedObjects.Items.Clear();
        this.lstCreatedObjects.Refresh();

        // Output activity to log.

        this.AddToActivityLog(" -- Running GC -- ");

        // Run the Garbage Collector.

        GC.Collect();

        // Tell the current thread to wait until all of the
        //   Finalizers have been called. This method stops the 
        //   tread from executing further instructions, until all 
        //   Finalize methods have been called for objects that
        //   are awaiting finalization.

        GC.WaitForPendingFinalizers();

        // if m_TestObject exists, get the generation numbers and display them.

        if (m_TestObject != null)
		{

            // Output the ArrayList strings to the Activity Log

            

            foreach(Object myObject in m_TestObject.GetSelfAndChildGenerations())
			{

                // Add the information to the Activity Log
                this.AddToActivityLog(myObject.ToString());

            }

        }

        // Display any objects that may have been created in the ListBox

        ShowTestObjects();

    }

    // Simple function to add text to the Activity Textbox

    private void AddToActivityLog(string message )
	{

        try 
		{

            this.txtActivity.AppendText(message + Environment.NewLine);

            this.txtActivity.ScrollToCaret();

		} 
		catch( ObjectDisposedException ode )
		{

            // This occurs when the User closes the form. This causes the TextBox
            //   to be disposed. Yet objects are still being garbage collected
            //   (finalized in this case), and so this method is still being
            //   called. Therefore, simple catch this exception and use a 
            //   MsgBox instead. (Thrown by the ScrollToCaret method.)

            MessageBox.Show(message, this.Text);
		}

        
	catch(System.ArgumentOutOfRangeException aoor)
		{
            // This occurs when the User closes the form. This causes the TextBox
            //   to be disposed. Yet objects are still being garbage collected
            //   (finalized in this case), and so this method is still being
            //   called. Therefore, simple catch this exception and use a 
            //   MsgBox instead. (Thrown by the AppendText method.)

            MessageBox.Show(message,this.Text);

       } 
		catch(Exception ex )
		{

            // Alert the user to the exception.

            MessageBox.Show("Exception Occurred. " + ex.ToString(), this.Text);

        }

    }

    // This subroutine handles all of the events raised by 
    //   the GcTest objects. It simply outputs the passed message
    //   to the Activity Log.

    private void myObjectEventHandler(string message )
	{

        // Add the message to the Activity Log.

        AddToActivityLog(message);

    }

    // This subroutine clears and fills the lstCreatedObjects
    //   ListBox.

    private void ShowTestObjects()
	{

        // Clear the ListBox.

        this.lstCreatedObjects.Items.Clear();

        // Fill the ListBox with the created GcTest object names hierarchy.
        // Test to ensure that m_TestObject has been created.

        if (this.m_TestObject != null)
		{

           
            // Add the names of the objects to the ListBox

            foreach(Object tmpObject in m_TestObject.GetSelfAndChildNames())
			{																			   
                this.lstCreatedObjects.Items.Add(tmpObject);

            }

        }

    }

}

