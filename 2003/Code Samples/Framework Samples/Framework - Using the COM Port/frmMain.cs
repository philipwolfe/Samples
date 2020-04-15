//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;
using System.Windows.Forms;
using System.Text;

public class frmMain: System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

	// Declare necessary class variables.

	private Rs232 m_CommPort = new Rs232();

	private bool m_IsModemFound = false;

	private int m_ModemPort = 0;

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

	private System.Windows.Forms.TextBox txtStatus;

	private System.Windows.Forms.Timer tmrReadCommPort;

	private System.Windows.Forms.CheckedListBox clstPorts;

	private System.Windows.Forms.Button btnCheckForPorts;

	private System.Windows.Forms.Button btnCheckModems;

	private System.Windows.Forms.TextBox txtSelectedModem;

	private System.Windows.Forms.Button btnSendATCommand;

	private System.Windows.Forms.TextBox txtUserCommand;

	private System.Windows.Forms.Button btnSendUserCommand;

	private System.Windows.Forms.Button btnClear;

	private void InitializeComponent() 
	{

		this.components = new System.ComponentModel.Container();

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.btnCheckForPorts = new System.Windows.Forms.Button();

		this.txtStatus = new System.Windows.Forms.TextBox();

		this.tmrReadCommPort = new System.Windows.Forms.Timer(this.components);

		this.clstPorts = new System.Windows.Forms.CheckedListBox();

		this.btnCheckModems = new System.Windows.Forms.Button();

		this.txtSelectedModem = new System.Windows.Forms.TextBox();

		this.btnSendATCommand = new System.Windows.Forms.Button();

		this.btnSendUserCommand = new System.Windows.Forms.Button();

		this.txtUserCommand = new System.Windows.Forms.TextBox();

		this.btnClear = new System.Windows.Forms.Button();

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

		this.mnuExit.Click+=new EventHandler(mnuExit_Click);

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

		this.mnuAbout.Click+=new EventHandler(mnuAbout_Click);
		//

		//btnCheckForPorts

		//

		this.btnCheckForPorts.AccessibleDescription = resources.GetString("btnCheckForPorts.AccessibleDescription");

		this.btnCheckForPorts.AccessibleName = resources.GetString("btnCheckForPorts.AccessibleName");

		this.btnCheckForPorts.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCheckForPorts.Anchor");

		this.btnCheckForPorts.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCheckForPorts.BackgroundImage");

		this.btnCheckForPorts.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCheckForPorts.Dock");

		this.btnCheckForPorts.Enabled = (bool) resources.GetObject("btnCheckForPorts.Enabled");

		this.btnCheckForPorts.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCheckForPorts.FlatStyle");

		this.btnCheckForPorts.Font = (System.Drawing.Font) resources.GetObject("btnCheckForPorts.Font");

		this.btnCheckForPorts.Image = (System.Drawing.Image) resources.GetObject("btnCheckForPorts.Image");

		this.btnCheckForPorts.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCheckForPorts.ImageAlign");

		this.btnCheckForPorts.ImageIndex = (int) resources.GetObject("btnCheckForPorts.ImageIndex");

		this.btnCheckForPorts.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCheckForPorts.ImeMode");

		this.btnCheckForPorts.Location = (System.Drawing.Point) resources.GetObject("btnCheckForPorts.Location");

		this.btnCheckForPorts.Name = "btnCheckForPorts";

		this.btnCheckForPorts.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCheckForPorts.RightToLeft");

		this.btnCheckForPorts.Size = (System.Drawing.Size) resources.GetObject("btnCheckForPorts.Size");

		this.btnCheckForPorts.TabIndex = (int) resources.GetObject("btnCheckForPorts.TabIndex");

		this.btnCheckForPorts.Text = resources.GetString("btnCheckForPorts.Text");

		this.btnCheckForPorts.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCheckForPorts.TextAlign");

		this.btnCheckForPorts.Visible = (bool) resources.GetObject("btnCheckForPorts.Visible");
		this.btnCheckForPorts.Click+=new EventHandler(btnCheckForPorts_Click);

		//

		//txtStatus

		//

		this.txtStatus.AccessibleDescription = resources.GetString("txtStatus.AccessibleDescription");

		this.txtStatus.AccessibleName = resources.GetString("txtStatus.AccessibleName");

		this.txtStatus.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtStatus.Anchor");

		this.txtStatus.AutoSize = (bool) resources.GetObject("txtStatus.AutoSize");

		this.txtStatus.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtStatus.BackgroundImage");

		this.txtStatus.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtStatus.Dock");

		this.txtStatus.Enabled = (bool) resources.GetObject("txtStatus.Enabled");

		this.txtStatus.Font = (System.Drawing.Font) resources.GetObject("txtStatus.Font");

		this.txtStatus.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtStatus.ImeMode");

		this.txtStatus.Location = (System.Drawing.Point) resources.GetObject("txtStatus.Location");

		this.txtStatus.MaxLength = (int) resources.GetObject("txtStatus.MaxLength");

		this.txtStatus.Multiline = (bool) resources.GetObject("txtStatus.Multiline");

		this.txtStatus.Name = "txtStatus";

		this.txtStatus.PasswordChar = (char) resources.GetObject("txtStatus.PasswordChar");

		this.txtStatus.ReadOnly = true;

		this.txtStatus.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtStatus.RightToLeft");

		this.txtStatus.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtStatus.ScrollBars");

		this.txtStatus.Size = (System.Drawing.Size) resources.GetObject("txtStatus.Size");

		this.txtStatus.TabIndex = (int) resources.GetObject("txtStatus.TabIndex");

		this.txtStatus.Text = resources.GetString("txtStatus.Text");

		this.txtStatus.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtStatus.TextAlign");

		this.txtStatus.Visible = (bool) resources.GetObject("txtStatus.Visible");

		this.txtStatus.WordWrap = (bool) resources.GetObject("txtStatus.WordWrap");

		//

		//tmrReadCommPort

		//
		this.tmrReadCommPort.Tick+=new EventHandler(tmrReadCommPort_Tick);

		//

		//clstPorts

		//

		this.clstPorts.AccessibleDescription = resources.GetString("clstPorts.AccessibleDescription");

		this.clstPorts.AccessibleName = resources.GetString("clstPorts.AccessibleName");

		this.clstPorts.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("clstPorts.Anchor");

		this.clstPorts.BackgroundImage = (System.Drawing.Image) resources.GetObject("clstPorts.BackgroundImage");

		this.clstPorts.ColumnWidth = (int) resources.GetObject("clstPorts.ColumnWidth");

		this.clstPorts.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("clstPorts.Dock");

		this.clstPorts.Enabled = (bool) resources.GetObject("clstPorts.Enabled");

		this.clstPorts.Font = (System.Drawing.Font) resources.GetObject("clstPorts.Font");

		this.clstPorts.HorizontalExtent = (int) resources.GetObject("clstPorts.HorizontalExtent");

		this.clstPorts.HorizontalScrollbar = (bool) resources.GetObject("clstPorts.HorizontalScrollbar");

		this.clstPorts.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("clstPorts.ImeMode");

		this.clstPorts.IntegralHeight = (bool) resources.GetObject("clstPorts.IntegralHeight");

		this.clstPorts.Items.AddRange(new Object[] {resources.GetString("clstPorts.Items.Items"), resources.GetString("clstPorts.Items.Items1"), resources.GetString("clstPorts.Items.Items2"), resources.GetString("clstPorts.Items.Items3")});

		this.clstPorts.Location = (System.Drawing.Point) resources.GetObject("clstPorts.Location");

		this.clstPorts.Name = "clstPorts";

		this.clstPorts.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("clstPorts.RightToLeft");

		this.clstPorts.ScrollAlwaysVisible = (bool) resources.GetObject("clstPorts.ScrollAlwaysVisible");

		this.clstPorts.Size = (System.Drawing.Size) resources.GetObject("clstPorts.Size");

		this.clstPorts.TabIndex = (int) resources.GetObject("clstPorts.TabIndex");

		this.clstPorts.TabStop = false;

		this.clstPorts.Visible = (bool) resources.GetObject("clstPorts.Visible");

		//

		//btnCheckModems

		//

		this.btnCheckModems.AccessibleDescription = resources.GetString("btnCheckModems.AccessibleDescription");

		this.btnCheckModems.AccessibleName = resources.GetString("btnCheckModems.AccessibleName");

		this.btnCheckModems.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCheckModems.Anchor");

		this.btnCheckModems.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCheckModems.BackgroundImage");

		this.btnCheckModems.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCheckModems.Dock");

		this.btnCheckModems.Enabled = (bool) resources.GetObject("btnCheckModems.Enabled");

		this.btnCheckModems.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCheckModems.FlatStyle");

		this.btnCheckModems.Font = (System.Drawing.Font) resources.GetObject("btnCheckModems.Font");

		this.btnCheckModems.Image = (System.Drawing.Image) resources.GetObject("btnCheckModems.Image");

		this.btnCheckModems.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCheckModems.ImageAlign");

		this.btnCheckModems.ImageIndex = (int) resources.GetObject("btnCheckModems.ImageIndex");

		this.btnCheckModems.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCheckModems.ImeMode");

		this.btnCheckModems.Location = (System.Drawing.Point) resources.GetObject("btnCheckModems.Location");

		this.btnCheckModems.Name = "btnCheckModems";

		this.btnCheckModems.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCheckModems.RightToLeft");

		this.btnCheckModems.Size = (System.Drawing.Size) resources.GetObject("btnCheckModems.Size");

		this.btnCheckModems.TabIndex = (int) resources.GetObject("btnCheckModems.TabIndex");

		this.btnCheckModems.Text = resources.GetString("btnCheckModems.Text");

		this.btnCheckModems.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCheckModems.TextAlign");

		this.btnCheckModems.Visible = (bool) resources.GetObject("btnCheckModems.Visible");

		this.btnCheckModems.Click+=new EventHandler(btnCheckModems_Click);
		//

		//txtSelectedModem

		//

		this.txtSelectedModem.AccessibleDescription = resources.GetString("txtSelectedModem.AccessibleDescription");

		this.txtSelectedModem.AccessibleName = resources.GetString("txtSelectedModem.AccessibleName");

		this.txtSelectedModem.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtSelectedModem.Anchor");

		this.txtSelectedModem.AutoSize = (bool) resources.GetObject("txtSelectedModem.AutoSize");

		this.txtSelectedModem.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtSelectedModem.BackgroundImage");

		this.txtSelectedModem.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtSelectedModem.Dock");

		this.txtSelectedModem.Enabled = (bool) resources.GetObject("txtSelectedModem.Enabled");

		this.txtSelectedModem.Font = (System.Drawing.Font) resources.GetObject("txtSelectedModem.Font");

		this.txtSelectedModem.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtSelectedModem.ImeMode");

		this.txtSelectedModem.Location = (System.Drawing.Point) resources.GetObject("txtSelectedModem.Location");

		this.txtSelectedModem.MaxLength = (int) resources.GetObject("txtSelectedModem.MaxLength");

		this.txtSelectedModem.Multiline = (bool) resources.GetObject("txtSelectedModem.Multiline");

		this.txtSelectedModem.Name = "txtSelectedModem";

		this.txtSelectedModem.PasswordChar = (char) resources.GetObject("txtSelectedModem.PasswordChar");

		this.txtSelectedModem.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtSelectedModem.RightToLeft");

		this.txtSelectedModem.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtSelectedModem.ScrollBars");

		this.txtSelectedModem.Size = (System.Drawing.Size) resources.GetObject("txtSelectedModem.Size");

		this.txtSelectedModem.TabIndex = (int) resources.GetObject("txtSelectedModem.TabIndex");

		this.txtSelectedModem.Text = resources.GetString("txtSelectedModem.Text");

		this.txtSelectedModem.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtSelectedModem.TextAlign");

		this.txtSelectedModem.Visible = (bool) resources.GetObject("txtSelectedModem.Visible");

		this.txtSelectedModem.WordWrap = (bool) resources.GetObject("txtSelectedModem.WordWrap");

		//

		//btnSendATCommand

		//

		this.btnSendATCommand.AccessibleDescription = resources.GetString("btnSendATCommand.AccessibleDescription");

		this.btnSendATCommand.AccessibleName = resources.GetString("btnSendATCommand.AccessibleName");

		this.btnSendATCommand.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSendATCommand.Anchor");

		this.btnSendATCommand.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSendATCommand.BackgroundImage");

		this.btnSendATCommand.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSendATCommand.Dock");

		this.btnSendATCommand.Enabled = (bool) resources.GetObject("btnSendATCommand.Enabled");

		this.btnSendATCommand.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSendATCommand.FlatStyle");

		this.btnSendATCommand.Font = (System.Drawing.Font) resources.GetObject("btnSendATCommand.Font");

		this.btnSendATCommand.Image = (System.Drawing.Image) resources.GetObject("btnSendATCommand.Image");

		this.btnSendATCommand.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSendATCommand.ImageAlign");

		this.btnSendATCommand.ImageIndex = (int) resources.GetObject("btnSendATCommand.ImageIndex");

		this.btnSendATCommand.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSendATCommand.ImeMode");

		this.btnSendATCommand.Location = (System.Drawing.Point) resources.GetObject("btnSendATCommand.Location");

		this.btnSendATCommand.Name = "btnSendATCommand";

		this.btnSendATCommand.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSendATCommand.RightToLeft");

		this.btnSendATCommand.Size = (System.Drawing.Size) resources.GetObject("btnSendATCommand.Size");

		this.btnSendATCommand.TabIndex = (int) resources.GetObject("btnSendATCommand.TabIndex");

		this.btnSendATCommand.Text = resources.GetString("btnSendATCommand.Text");

		this.btnSendATCommand.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSendATCommand.TextAlign");

		this.btnSendATCommand.Visible = (bool) resources.GetObject("btnSendATCommand.Visible");

		this.btnSendATCommand.Click+=new EventHandler(btnSendATCommand_Click);
		//

		//btnSendUserCommand

		//

		this.btnSendUserCommand.AccessibleDescription = resources.GetString("btnSendUserCommand.AccessibleDescription");

		this.btnSendUserCommand.AccessibleName = resources.GetString("btnSendUserCommand.AccessibleName");

		this.btnSendUserCommand.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSendUserCommand.Anchor");

		this.btnSendUserCommand.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSendUserCommand.BackgroundImage");

		this.btnSendUserCommand.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSendUserCommand.Dock");

		this.btnSendUserCommand.Enabled = (bool) resources.GetObject("btnSendUserCommand.Enabled");

		this.btnSendUserCommand.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSendUserCommand.FlatStyle");

		this.btnSendUserCommand.Font = (System.Drawing.Font) resources.GetObject("btnSendUserCommand.Font");

		this.btnSendUserCommand.Image = (System.Drawing.Image) resources.GetObject("btnSendUserCommand.Image");

		this.btnSendUserCommand.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSendUserCommand.ImageAlign");

		this.btnSendUserCommand.ImageIndex = (int) resources.GetObject("btnSendUserCommand.ImageIndex");

		this.btnSendUserCommand.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSendUserCommand.ImeMode");

		this.btnSendUserCommand.Location = (System.Drawing.Point) resources.GetObject("btnSendUserCommand.Location");

		this.btnSendUserCommand.Name = "btnSendUserCommand";

		this.btnSendUserCommand.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSendUserCommand.RightToLeft");

		this.btnSendUserCommand.Size = (System.Drawing.Size) resources.GetObject("btnSendUserCommand.Size");

		this.btnSendUserCommand.TabIndex = (int) resources.GetObject("btnSendUserCommand.TabIndex");

		this.btnSendUserCommand.Text = resources.GetString("btnSendUserCommand.Text");

		this.btnSendUserCommand.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSendUserCommand.TextAlign");

		this.btnSendUserCommand.Visible = (bool) resources.GetObject("btnSendUserCommand.Visible");

		this.btnSendUserCommand.Click+=new EventHandler(btnSendUserCommand_Click);
		//

		//txtUserCommand

		//

		this.txtUserCommand.AccessibleDescription = resources.GetString("txtUserCommand.AccessibleDescription");

		this.txtUserCommand.AccessibleName = resources.GetString("txtUserCommand.AccessibleName");

		this.txtUserCommand.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtUserCommand.Anchor");

		this.txtUserCommand.AutoSize = (bool) resources.GetObject("txtUserCommand.AutoSize");

		this.txtUserCommand.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtUserCommand.BackgroundImage");

		this.txtUserCommand.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtUserCommand.Dock");

		this.txtUserCommand.Enabled = (bool) resources.GetObject("txtUserCommand.Enabled");

		this.txtUserCommand.Font = (System.Drawing.Font) resources.GetObject("txtUserCommand.Font");

		this.txtUserCommand.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtUserCommand.ImeMode");

		this.txtUserCommand.Location = (System.Drawing.Point) resources.GetObject("txtUserCommand.Location");

		this.txtUserCommand.MaxLength = (int) resources.GetObject("txtUserCommand.MaxLength");

		this.txtUserCommand.Multiline = (bool) resources.GetObject("txtUserCommand.Multiline");

		this.txtUserCommand.Name = "txtUserCommand";

		this.txtUserCommand.PasswordChar = (char) resources.GetObject("txtUserCommand.PasswordChar");

		this.txtUserCommand.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtUserCommand.RightToLeft");

		this.txtUserCommand.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtUserCommand.ScrollBars");

		this.txtUserCommand.Size = (System.Drawing.Size) resources.GetObject("txtUserCommand.Size");

		this.txtUserCommand.TabIndex = (int) resources.GetObject("txtUserCommand.TabIndex");

		this.txtUserCommand.Text = resources.GetString("txtUserCommand.Text");

		this.txtUserCommand.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtUserCommand.TextAlign");

		this.txtUserCommand.Visible = (bool) resources.GetObject("txtUserCommand.Visible");

		this.txtUserCommand.WordWrap = (bool) resources.GetObject("txtUserCommand.WordWrap");

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

		this.btnClear.Click+=new EventHandler(btnClear_Click);

		//

		//frmMain

		//

		this.AccessibleDescription = (string) resources.GetObject("$this.AccessibleDescription");

		this.AccessibleName = (string) resources.GetObject("$this.AccessibleName");

		this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

		this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

		this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

		this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

		this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

		this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

		this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnClear, this.txtUserCommand, this.btnSendUserCommand, this.btnSendATCommand, this.txtSelectedModem, this.btnCheckModems, this.clstPorts, this.txtStatus, this.btnCheckForPorts});

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

	// This subroutine checks for available ports on the local machine. It does 

	//   this by attempting to open ports 1 through 4.

	private void btnCheckForPorts_Click(object sender, System.EventArgs e) 
		//btnCheckForPorts.Click;
	{
		// Check for Availability of each of the 4 Comm Ports, and

		//   place a check in the list box items that have openable ports.

		for (int i=1;i<5;i++)
		{

			WriteMessage("Testing COM" + i.ToString());

			if (IsPortAvailable(i)) 
			{

				// Check the box for available ports.

				this.clstPorts.SetItemChecked(i - 1, true);
			}
			else 
			{

				// Uncheck the box for unavailable ports.

				this.clstPorts.SetItemChecked(i - 1, false);

			}

		}

		// Enable the Find Modems button.

		this.btnCheckModems.Enabled = true;

	}

	// This subroutine attempts to send an AT command to any active Comm Ports.
	//   if a response is returned then a usable modem has been detected
	//   on that port.

	private void btnCheckModems_Click(object sender, System.EventArgs e) 
		//btnCheckModems.Click;
	{

		for (int i=0;i<4;i++)
		{

			if (this.clstPorts.GetItemChecked(i)) 
			{

				// Item is checked so it MIGHT be a valid port.
				// Test for validity.

				if (IsPortAvailable(i + 1)) 
				{

					// Check if port responds to an AT command.

					if (IsPortAModem(i + 1)) 
					{

						// Set the class variables to the last modem found.

						this.m_IsModemFound = true;

						this.m_ModemPort = i + 1;

						// Write message to the user.

						WriteMessage("Port " + (i + 1).ToString() +

							" is a responsive modem.");
					}
					else 
					{

						// Write message to the user.

						WriteMessage("Port " + (i + 1).ToString() +

							" is not a responsive modem.");

					}

				}

			}

		}

		// if a modem was found, enable the rest of the buttons, so the user

		//   can interact with the modem.

		if (this.m_IsModemFound) 
		{

			this.txtSelectedModem.Text = "Using Modem on COM" +
				this.m_ModemPort.ToString();

			this.txtUserCommand.Enabled = true;
			this.btnSendATCommand.Enabled = true;
			this.btnSendUserCommand.Enabled = true;

		}

	}

	// This subroutine clears the TextBox.

	private void btnClear_Click(object sender, System.EventArgs e) 
		//btnClear.Click;
	{
		this.txtStatus.Clear();

	}

	// This subroutine sends an AT command to the modem, and records its response.
	//   It depends on the timer to do the reading of the response.

	private void btnSendATCommand_Click(object sender, System.EventArgs e) 
		//btnSendATCommand.Click;
	{
		// Always wrap up working with Comm Ports in exception handlers.

		try 
		{

			// Enable the timer.

			this.tmrReadCommPort.Enabled = true;

			// Attempt to open the port.

			m_CommPort.Open(m_ModemPort, 115200, 8, Rs232.DataParity.Parity_None,
				Rs232.DataStopBit.StopBit_1, 4096);

			// Write an AT Command to the Port.

			m_CommPort.Write(Encoding.ASCII.GetBytes("AT" + "\r"));

			// Sleep long enough for the modem to respond and the timer to fire.

			System.Threading.Thread.Sleep(200);

			Application.DoEvents();

			m_CommPort.Close();

		} 
		catch( Exception ex)
		{
			// Warn the user.

			MessageBox.Show("Unable to communicate with Modem");
		}
		finally
		{
			// Disable the timer.

			this.tmrReadCommPort.Enabled = false;
		}

	}

	// This subroutine sends a user specified command to the modem, and records its 
	//   response. It depends on the timer to do the reading of the response.

	private void btnSendUserCommand_Click(object sender, System.EventArgs e) 
		//btnSendUserCommand.Click;
	{
		// Always wrap up working with Comm Ports in exception handlers.

		try 
		{

			// Enable the timer.

			this.tmrReadCommPort.Enabled = true;

			// Attempt to open the port.

			m_CommPort.Open(m_ModemPort, 115200, 8, Rs232.DataParity.Parity_None, Rs232.DataStopBit.StopBit_1, 4096);

			// Write an user specified Command to the Port.

			m_CommPort.Write(Encoding.ASCII.GetBytes(this.txtUserCommand.Text + "\n"));

			// Sleep long enough for the modem to respond and the timer to fire.

			System.Threading.Thread.Sleep(200);

			Application.DoEvents();

			m_CommPort.Close();

		} 
		catch( Exception ex)
		{

			// Warn the user.
			MessageBox.Show("Unable to communicate with Modem");
		}
		finally
		{

			// Disable the timer.

			this.tmrReadCommPort.Enabled = false;

		}

	}

	// This subroutine is fired when the timer event is raised. It writes whatever
	//   is in the Comm Port buffer to the output window.

	public void tmrReadCommPort_Tick(object sender, System.EventArgs e) 
	{

		try 
		{

			// long there is information, read one byte at a time and 

			//   output it.

			while (m_CommPort.Read(1) != -1)
			{

				// Write the output to the screen.

				WriteMessage(m_CommPort.InputStream[0].ToString(), false);

			}

		} 
		catch(Exception exc)
		{

			// An exception is raised when there is no information to read.
			//   Don't do anything here, just let the exception go.

		}

	}

	// This function checks to see if the port is a modem, by sending 
	//   an AT command to the port. if the port responds, it is assumed to 
	//   be a modem. The function returns a bool.

	private bool IsPortAModem(int port)
	{

		// Always wrap up working with Comm Ports in exception handlers.
		try 
		{

			// Attempt to open the port.

			m_CommPort.Open(port, 115200, 8, Rs232.DataParity.Parity_None,Rs232.DataStopBit.StopBit_1, 4096);

			// Write an AT Command to the Port.
			m_CommPort.Write(Encoding.ASCII.GetBytes("AT" + "\n"));

			// Sleep long enough for the modem to respond.

			System.Threading.Thread.Sleep(200);
			Application.DoEvents();

			// try { to get info from the Comm Port.

			try 
			{

				Byte b;

				// try { to read a single byte. if you get it, then assume
				//   that the port contains a modem. Clear the buffer before 
				//   leaving.

				m_CommPort.Read(1);
				m_CommPort.ClearInputBuffer();
				m_CommPort.Close();
				return true;

			} 
			catch( Exception exc)
			{	
				// null to read from the Comm Port, so set to false

				m_CommPort.Close();
				return false;
			}
		} 
		catch(Exception exc)	
		{	
			// Port could not be opened or written to.

			this.clstPorts.SetItemChecked(port - 1, false);
			MessageBox.Show("Could not open port.", this.Text);
			return false;

		}

	}

	// This function attempts to open the passed Comm Port. if it is
	//   available, it returns true, else it returns false. To determine
	//   availability a try {-catch block is used.

	private bool IsPortAvailable(int ComPort )
	{
		try 
		{

			m_CommPort.Open(ComPort, 115200, 8, Rs232.DataParity.Parity_None, Rs232.DataStopBit.StopBit_1, 4096);

			// if it makes it to here, then the Comm Port is available.
			m_CommPort.Close();
			return true;
		} 
		catch(Exception exc)
		{

			// if it gets here, then the attempt to open the Comm Port
			//   was unsuccessful.
			return false;
		}

	}

	// This subroutine writes a message to the txtStatus TextBox.

	private void WriteMessage(string message)
	{

		this.txtStatus.Text += message + Environment.NewLine;

	}

	// This subroutine writes a message to the txtStatus TextBox and allows
	//   the line feed to be suppressed.

	private void WriteMessage(string message , bool linefeed )
	{

		this.txtStatus.Text += message;

		if (linefeed)
		{
			this.txtStatus.Text += Environment.NewLine;
		}

	}
}


