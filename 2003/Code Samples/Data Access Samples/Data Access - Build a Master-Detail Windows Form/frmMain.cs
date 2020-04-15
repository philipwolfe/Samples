//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Data.SqlClient;

public class frmMain:System.Windows.Forms.Form 
{
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

    private System.Windows.Forms.DataGrid grdOrders;

    private System.Windows.Forms.TextBox txtHireDate;

    private System.Windows.Forms.MenuItem MenuItem1;

    private System.Windows.Forms.Label lblRecordNumber;

    private System.Windows.Forms.Button btnLast;

    private System.Windows.Forms.Button btnNext;

    private System.Windows.Forms.Button btnPrevious;

    private System.Windows.Forms.Button btnFirst;

    private System.Windows.Forms.TextBox txtSalesToDate;

    private System.Windows.Forms.TextBox txtFirstName;

    private System.Windows.Forms.TextBox txtLastName;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.MenuItem MenuItem2;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.MenuItem MenuItem3;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.MenuItem MenuItem4;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.DataGrid grdOrderDetails;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.grdOrders = new System.Windows.Forms.DataGrid();

        this.txtHireDate = new System.Windows.Forms.TextBox();

        this.MenuItem1 = new System.Windows.Forms.MenuItem();

        this.lblRecordNumber = new System.Windows.Forms.Label();

        this.btnLast = new System.Windows.Forms.Button();

        this.btnNext = new System.Windows.Forms.Button();

        this.btnPrevious = new System.Windows.Forms.Button();

        this.btnFirst = new System.Windows.Forms.Button();

        this.txtSalesToDate = new System.Windows.Forms.TextBox();

        this.txtFirstName = new System.Windows.Forms.TextBox();

        this.txtLastName = new System.Windows.Forms.TextBox();

        this.Label5 = new System.Windows.Forms.Label();

        this.MenuItem2 = new System.Windows.Forms.MenuItem();

        this.Label3 = new System.Windows.Forms.Label();

        this.MenuItem3 = new System.Windows.Forms.MenuItem();

        this.Label2 = new System.Windows.Forms.Label();

        this.MenuItem4 = new System.Windows.Forms.MenuItem();

        this.Label1 = new System.Windows.Forms.Label();

        this.grdOrderDetails = new System.Windows.Forms.DataGrid();

        ((System.ComponentModel.ISupportInitialize) this.grdOrders).BeginInit();

        ((System.ComponentModel.ISupportInitialize) this.grdOrderDetails).BeginInit();

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

        //grdOrders

        //

        this.grdOrders.AccessibleDescription = resources.GetString("grdOrders.AccessibleDescription");

        this.grdOrders.AccessibleName = resources.GetString("grdOrders.AccessibleName");

        this.grdOrders.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdOrders.Anchor");

        this.grdOrders.BackgroundImage = (System.Drawing.Image) resources.GetObject("grdOrders.BackgroundImage");

        this.grdOrders.CaptionFont = (System.Drawing.Font) resources.GetObject("grdOrders.CaptionFont");

        this.grdOrders.CaptionText = resources.GetString("grdOrders.CaptionText");

        this.grdOrders.DataMember = string.Empty;

        this.grdOrders.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grdOrders.Dock");

        this.grdOrders.Enabled = (bool) resources.GetObject("grdOrders.Enabled");

        this.grdOrders.Font = (System.Drawing.Font) resources.GetObject("grdOrders.Font");

        this.grdOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.grdOrders.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grdOrders.ImeMode");

        this.grdOrders.Location = (System.Drawing.Point) resources.GetObject("grdOrders.Location");

        this.grdOrders.Name = "grdOrders";

        this.grdOrders.ReadOnly = true;

        this.grdOrders.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grdOrders.RightToLeft");

        this.grdOrders.Size = (System.Drawing.Size) resources.GetObject("grdOrders.Size");

        this.grdOrders.TabIndex = (int) resources.GetObject("grdOrders.TabIndex");

        this.grdOrders.Visible = (bool) resources.GetObject("grdOrders.Visible");

		this.grdOrders.Click+=new EventHandler(grdOrders_Click);

		this.grdOrders.CurrentCellChanged+=new EventHandler(grdOrders_CurrentCellChanged);

        //

        //txtHireDate

        //

        this.txtHireDate.AccessibleDescription = resources.GetString("txtHireDate.AccessibleDescription");

        this.txtHireDate.AccessibleName = resources.GetString("txtHireDate.AccessibleName");

        this.txtHireDate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtHireDate.Anchor");

        this.txtHireDate.AutoSize = (bool) resources.GetObject("txtHireDate.AutoSize");

        this.txtHireDate.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtHireDate.BackgroundImage");

        this.txtHireDate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtHireDate.Dock");

        this.txtHireDate.Enabled = (bool) resources.GetObject("txtHireDate.Enabled");

        this.txtHireDate.Font = (System.Drawing.Font) resources.GetObject("txtHireDate.Font");

        this.txtHireDate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtHireDate.ImeMode");

        this.txtHireDate.Location = (System.Drawing.Point) resources.GetObject("txtHireDate.Location");

        this.txtHireDate.MaxLength = (int) resources.GetObject("txtHireDate.MaxLength");

        this.txtHireDate.Multiline = (bool) resources.GetObject("txtHireDate.Multiline");

        this.txtHireDate.Name = "txtHireDate";

        this.txtHireDate.PasswordChar = (char) resources.GetObject("txtHireDate.PasswordChar");

        this.txtHireDate.ReadOnly = true;

        this.txtHireDate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtHireDate.RightToLeft");

        this.txtHireDate.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtHireDate.ScrollBars");

        this.txtHireDate.Size = (System.Drawing.Size) resources.GetObject("txtHireDate.Size");

        this.txtHireDate.TabIndex = (int) resources.GetObject("txtHireDate.TabIndex");

        this.txtHireDate.Text = resources.GetString("txtHireDate.Text");

        this.txtHireDate.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtHireDate.TextAlign");

        this.txtHireDate.Visible = (bool) resources.GetObject("txtHireDate.Visible");

        this.txtHireDate.WordWrap = (bool) resources.GetObject("txtHireDate.WordWrap");

        //

        //MenuItem1

        //

        this.MenuItem1.Enabled = (bool) resources.GetObject("MenuItem1.Enabled");

        this.MenuItem1.Index = 0;

        this.MenuItem1.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem1.Shortcut");

        this.MenuItem1.ShowShortcut = (bool) resources.GetObject("MenuItem1.ShowShortcut");

        this.MenuItem1.Text = resources.GetString("MenuItem1.Text");

        this.MenuItem1.Visible = (bool) resources.GetObject("MenuItem1.Visible");

        //

        //lblRecordNumber

        //

        this.lblRecordNumber.AccessibleDescription = resources.GetString("lblRecordNumber.AccessibleDescription");

        this.lblRecordNumber.AccessibleName = resources.GetString("lblRecordNumber.AccessibleName");

        this.lblRecordNumber.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblRecordNumber.Anchor");

        this.lblRecordNumber.AutoSize = (bool) resources.GetObject("lblRecordNumber.AutoSize");

        this.lblRecordNumber.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblRecordNumber.Dock");

        this.lblRecordNumber.Enabled = (bool) resources.GetObject("lblRecordNumber.Enabled");

        this.lblRecordNumber.Font = (System.Drawing.Font) resources.GetObject("lblRecordNumber.Font");

        this.lblRecordNumber.Image = (System.Drawing.Image) resources.GetObject("lblRecordNumber.Image");

        this.lblRecordNumber.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblRecordNumber.ImageAlign");

        this.lblRecordNumber.ImageIndex = (int) resources.GetObject("lblRecordNumber.ImageIndex");

        this.lblRecordNumber.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblRecordNumber.ImeMode");

        this.lblRecordNumber.Location = (System.Drawing.Point) resources.GetObject("lblRecordNumber.Location");

        this.lblRecordNumber.Name = "lblRecordNumber";

        this.lblRecordNumber.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblRecordNumber.RightToLeft");

        this.lblRecordNumber.Size = (System.Drawing.Size) resources.GetObject("lblRecordNumber.Size");

        this.lblRecordNumber.TabIndex = (int) resources.GetObject("lblRecordNumber.TabIndex");

        this.lblRecordNumber.Text = resources.GetString("lblRecordNumber.Text");

        this.lblRecordNumber.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblRecordNumber.TextAlign");

        this.lblRecordNumber.Visible = (bool) resources.GetObject("lblRecordNumber.Visible");

        //

        //btnLast

        //

        this.btnLast.AccessibleDescription = resources.GetString("btnLast.AccessibleDescription");

        this.btnLast.AccessibleName = resources.GetString("btnLast.AccessibleName");

        this.btnLast.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnLast.Anchor");

        this.btnLast.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnLast.BackgroundImage");

        this.btnLast.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnLast.Dock");

        this.btnLast.Enabled = (bool) resources.GetObject("btnLast.Enabled");

        this.btnLast.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnLast.FlatStyle");

        this.btnLast.Font = (System.Drawing.Font) resources.GetObject("btnLast.Font");

        this.btnLast.Image = (System.Drawing.Image) resources.GetObject("btnLast.Image");

        this.btnLast.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnLast.ImageAlign");

        this.btnLast.ImageIndex = (int) resources.GetObject("btnLast.ImageIndex");

        this.btnLast.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnLast.ImeMode");

        this.btnLast.Location = (System.Drawing.Point) resources.GetObject("btnLast.Location");

        this.btnLast.Name = "btnLast";

        this.btnLast.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnLast.RightToLeft");

        this.btnLast.Size = (System.Drawing.Size) resources.GetObject("btnLast.Size");

        this.btnLast.TabIndex = (int) resources.GetObject("btnLast.TabIndex");

        this.btnLast.Text = resources.GetString("btnLast.Text");

        this.btnLast.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnLast.TextAlign");

        this.btnLast.Visible = (bool) resources.GetObject("btnLast.Visible");

		this.btnLast.Click+=new EventHandler(btnLast_Click);

        //

        //btnNext

        //

        this.btnNext.AccessibleDescription = resources.GetString("btnNext.AccessibleDescription");

        this.btnNext.AccessibleName = resources.GetString("btnNext.AccessibleName");

        this.btnNext.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnNext.Anchor");

        this.btnNext.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnNext.BackgroundImage");

        this.btnNext.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnNext.Dock");

        this.btnNext.Enabled = (bool) resources.GetObject("btnNext.Enabled");

        this.btnNext.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnNext.FlatStyle");

        this.btnNext.Font = (System.Drawing.Font) resources.GetObject("btnNext.Font");

        this.btnNext.Image = (System.Drawing.Image) resources.GetObject("btnNext.Image");

        this.btnNext.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnNext.ImageAlign");

        this.btnNext.ImageIndex = (int) resources.GetObject("btnNext.ImageIndex");

        this.btnNext.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnNext.ImeMode");

        this.btnNext.Location = (System.Drawing.Point) resources.GetObject("btnNext.Location");

        this.btnNext.Name = "btnNext";

        this.btnNext.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnNext.RightToLeft");

        this.btnNext.Size = (System.Drawing.Size) resources.GetObject("btnNext.Size");

        this.btnNext.TabIndex = (int) resources.GetObject("btnNext.TabIndex");

        this.btnNext.Text = resources.GetString("btnNext.Text");

        this.btnNext.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnNext.TextAlign");

        this.btnNext.Visible = (bool) resources.GetObject("btnNext.Visible");

		this.btnNext.Click+=new EventHandler(btnNext_Click);

        //

        //btnPrevious

        //

        this.btnPrevious.AccessibleDescription = resources.GetString("btnPrevious.AccessibleDescription");

        this.btnPrevious.AccessibleName = resources.GetString("btnPrevious.AccessibleName");

        this.btnPrevious.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPrevious.Anchor");

        this.btnPrevious.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPrevious.BackgroundImage");

        this.btnPrevious.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPrevious.Dock");

        this.btnPrevious.Enabled = (bool) resources.GetObject("btnPrevious.Enabled");

        this.btnPrevious.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPrevious.FlatStyle");

        this.btnPrevious.Font = (System.Drawing.Font) resources.GetObject("btnPrevious.Font");

        this.btnPrevious.Image = (System.Drawing.Image) resources.GetObject("btnPrevious.Image");

        this.btnPrevious.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrevious.ImageAlign");

        this.btnPrevious.ImageIndex = (int) resources.GetObject("btnPrevious.ImageIndex");

        this.btnPrevious.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPrevious.ImeMode");

        this.btnPrevious.Location = (System.Drawing.Point) resources.GetObject("btnPrevious.Location");

        this.btnPrevious.Name = "btnPrevious";

        this.btnPrevious.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPrevious.RightToLeft");

        this.btnPrevious.Size = (System.Drawing.Size) resources.GetObject("btnPrevious.Size");

        this.btnPrevious.TabIndex = (int) resources.GetObject("btnPrevious.TabIndex");

        this.btnPrevious.Text = resources.GetString("btnPrevious.Text");

        this.btnPrevious.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrevious.TextAlign");

        this.btnPrevious.Visible = (bool) resources.GetObject("btnPrevious.Visible");

		this.btnPrevious.Click+=new EventHandler(btnPrevious_Click);

        //

        //btnFirst

        //

        this.btnFirst.AccessibleDescription = resources.GetString("btnFirst.AccessibleDescription");

        this.btnFirst.AccessibleName = resources.GetString("btnFirst.AccessibleName");

        this.btnFirst.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnFirst.Anchor");

        this.btnFirst.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnFirst.BackgroundImage");

        this.btnFirst.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnFirst.Dock");

        this.btnFirst.Enabled = (bool) resources.GetObject("btnFirst.Enabled");

        this.btnFirst.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnFirst.FlatStyle");

        this.btnFirst.Font = (System.Drawing.Font) resources.GetObject("btnFirst.Font");

        this.btnFirst.Image = (System.Drawing.Image) resources.GetObject("btnFirst.Image");

        this.btnFirst.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFirst.ImageAlign");

        this.btnFirst.ImageIndex = (int) resources.GetObject("btnFirst.ImageIndex");

        this.btnFirst.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnFirst.ImeMode");

        this.btnFirst.Location = (System.Drawing.Point) resources.GetObject("btnFirst.Location");

        this.btnFirst.Name = "btnFirst";

        this.btnFirst.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnFirst.RightToLeft");

        this.btnFirst.Size = (System.Drawing.Size) resources.GetObject("btnFirst.Size");

        this.btnFirst.TabIndex = (int) resources.GetObject("btnFirst.TabIndex");

        this.btnFirst.Text = resources.GetString("btnFirst.Text");

        this.btnFirst.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFirst.TextAlign");

        this.btnFirst.Visible = (bool) resources.GetObject("btnFirst.Visible");

		this.btnFirst.Click+=new EventHandler(btnFirst_Click);

        //

        //txtSalesToDate

        //

        this.txtSalesToDate.AccessibleDescription = resources.GetString("txtSalesToDate.AccessibleDescription");

        this.txtSalesToDate.AccessibleName = resources.GetString("txtSalesToDate.AccessibleName");

        this.txtSalesToDate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtSalesToDate.Anchor");

        this.txtSalesToDate.AutoSize = (bool) resources.GetObject("txtSalesToDate.AutoSize");

        this.txtSalesToDate.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtSalesToDate.BackgroundImage");

        this.txtSalesToDate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtSalesToDate.Dock");

        this.txtSalesToDate.Enabled = (bool) resources.GetObject("txtSalesToDate.Enabled");

        this.txtSalesToDate.Font = (System.Drawing.Font) resources.GetObject("txtSalesToDate.Font");

        this.txtSalesToDate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtSalesToDate.ImeMode");

        this.txtSalesToDate.Location = (System.Drawing.Point) resources.GetObject("txtSalesToDate.Location");

        this.txtSalesToDate.MaxLength = (int) resources.GetObject("txtSalesToDate.MaxLength");

        this.txtSalesToDate.Multiline = (bool) resources.GetObject("txtSalesToDate.Multiline");

        this.txtSalesToDate.Name = "txtSalesToDate";

        this.txtSalesToDate.PasswordChar = (char) resources.GetObject("txtSalesToDate.PasswordChar");

        this.txtSalesToDate.ReadOnly = true;

        this.txtSalesToDate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtSalesToDate.RightToLeft");

        this.txtSalesToDate.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtSalesToDate.ScrollBars");

        this.txtSalesToDate.Size = (System.Drawing.Size) resources.GetObject("txtSalesToDate.Size");

        this.txtSalesToDate.TabIndex = (int) resources.GetObject("txtSalesToDate.TabIndex");

        this.txtSalesToDate.Text = resources.GetString("txtSalesToDate.Text");

        this.txtSalesToDate.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtSalesToDate.TextAlign");

        this.txtSalesToDate.Visible = (bool) resources.GetObject("txtSalesToDate.Visible");

        this.txtSalesToDate.WordWrap = (bool) resources.GetObject("txtSalesToDate.WordWrap");

        //

        //txtFirstName

        //

        this.txtFirstName.AccessibleDescription = resources.GetString("txtFirstName.AccessibleDescription");

        this.txtFirstName.AccessibleName = resources.GetString("txtFirstName.AccessibleName");

        this.txtFirstName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtFirstName.Anchor");

        this.txtFirstName.AutoSize = (bool) resources.GetObject("txtFirstName.AutoSize");

        this.txtFirstName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtFirstName.BackgroundImage");

        this.txtFirstName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtFirstName.Dock");

        this.txtFirstName.Enabled = (bool) resources.GetObject("txtFirstName.Enabled");

        this.txtFirstName.Font = (System.Drawing.Font) resources.GetObject("txtFirstName.Font");

        this.txtFirstName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtFirstName.ImeMode");

        this.txtFirstName.Location = (System.Drawing.Point) resources.GetObject("txtFirstName.Location");

        this.txtFirstName.MaxLength = (int) resources.GetObject("txtFirstName.MaxLength");

        this.txtFirstName.Multiline = (bool) resources.GetObject("txtFirstName.Multiline");

        this.txtFirstName.Name = "txtFirstName";

        this.txtFirstName.PasswordChar = (char) resources.GetObject("txtFirstName.PasswordChar");

        this.txtFirstName.ReadOnly = true;

        this.txtFirstName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtFirstName.RightToLeft");

        this.txtFirstName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtFirstName.ScrollBars");

        this.txtFirstName.Size = (System.Drawing.Size) resources.GetObject("txtFirstName.Size");

        this.txtFirstName.TabIndex = (int) resources.GetObject("txtFirstName.TabIndex");

        this.txtFirstName.Text = resources.GetString("txtFirstName.Text");

        this.txtFirstName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtFirstName.TextAlign");

        this.txtFirstName.Visible = (bool) resources.GetObject("txtFirstName.Visible");

        this.txtFirstName.WordWrap = (bool) resources.GetObject("txtFirstName.WordWrap");

        //

        //txtLastName

        //

        this.txtLastName.AccessibleDescription = resources.GetString("txtLastName.AccessibleDescription");

        this.txtLastName.AccessibleName = resources.GetString("txtLastName.AccessibleName");

        this.txtLastName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtLastName.Anchor");

        this.txtLastName.AutoSize = (bool) resources.GetObject("txtLastName.AutoSize");

        this.txtLastName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtLastName.BackgroundImage");

        this.txtLastName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtLastName.Dock");

        this.txtLastName.Enabled = (bool) resources.GetObject("txtLastName.Enabled");

        this.txtLastName.Font = (System.Drawing.Font) resources.GetObject("txtLastName.Font");

        this.txtLastName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtLastName.ImeMode");

        this.txtLastName.Location = (System.Drawing.Point) resources.GetObject("txtLastName.Location");

        this.txtLastName.MaxLength = (int) resources.GetObject("txtLastName.MaxLength");

        this.txtLastName.Multiline = (bool) resources.GetObject("txtLastName.Multiline");

        this.txtLastName.Name = "txtLastName";

        this.txtLastName.PasswordChar = (char) resources.GetObject("txtLastName.PasswordChar");

        this.txtLastName.ReadOnly = true;

        this.txtLastName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtLastName.RightToLeft");

        this.txtLastName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtLastName.ScrollBars");

        this.txtLastName.Size = (System.Drawing.Size) resources.GetObject("txtLastName.Size");

        this.txtLastName.TabIndex = (int) resources.GetObject("txtLastName.TabIndex");

        this.txtLastName.Text = resources.GetString("txtLastName.Text");

        this.txtLastName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtLastName.TextAlign");

        this.txtLastName.Visible = (bool) resources.GetObject("txtLastName.Visible");

        this.txtLastName.WordWrap = (bool) resources.GetObject("txtLastName.WordWrap");

        //

        //Label5

        //

        this.Label5.AccessibleDescription = resources.GetString("Label5.AccessibleDescription");

        this.Label5.AccessibleName = resources.GetString("Label5.AccessibleName");

        this.Label5.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label5.Anchor");

        this.Label5.AutoSize = (bool) resources.GetObject("Label5.AutoSize");

        this.Label5.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label5.Dock");

        this.Label5.Enabled = (bool) resources.GetObject("Label5.Enabled");

        this.Label5.Font = (System.Drawing.Font) resources.GetObject("Label5.Font");

        this.Label5.Image = (System.Drawing.Image) resources.GetObject("Label5.Image");

        this.Label5.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label5.ImageAlign");

        this.Label5.ImageIndex = (int) resources.GetObject("Label5.ImageIndex");

        this.Label5.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label5.ImeMode");

        this.Label5.Location = (System.Drawing.Point) resources.GetObject("Label5.Location");

        this.Label5.Name = "Label5";

        this.Label5.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label5.RightToLeft");

        this.Label5.Size = (System.Drawing.Size) resources.GetObject("Label5.Size");

        this.Label5.TabIndex = (int) resources.GetObject("Label5.TabIndex");

        this.Label5.Text = resources.GetString("Label5.Text");

        this.Label5.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label5.TextAlign");

        this.Label5.Visible = (bool) resources.GetObject("Label5.Visible");

        //

        //MenuItem2

        //

        this.MenuItem2.Enabled = (bool) resources.GetObject("MenuItem2.Enabled");

        this.MenuItem2.Index = 0;

        this.MenuItem2.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem2.Shortcut");

        this.MenuItem2.ShowShortcut = (bool) resources.GetObject("MenuItem2.ShowShortcut");

        this.MenuItem2.Text = resources.GetString("MenuItem2.Text");

        this.MenuItem2.Visible = (bool) resources.GetObject("MenuItem2.Visible");

        //

        //Label3

        //

        this.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription");

        this.Label3.AccessibleName = resources.GetString("Label3.AccessibleName");

        this.Label3.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label3.Anchor");

        this.Label3.AutoSize = (bool) resources.GetObject("Label3.AutoSize");

        this.Label3.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label3.Dock");

        this.Label3.Enabled = (bool) resources.GetObject("Label3.Enabled");

        this.Label3.Font = (System.Drawing.Font) resources.GetObject("Label3.Font");

        this.Label3.Image = (System.Drawing.Image) resources.GetObject("Label3.Image");

        this.Label3.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label3.ImageAlign");

        this.Label3.ImageIndex = (int) resources.GetObject("Label3.ImageIndex");

        this.Label3.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label3.ImeMode");

        this.Label3.Location = (System.Drawing.Point) resources.GetObject("Label3.Location");

        this.Label3.Name = "Label3";

        this.Label3.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label3.RightToLeft");

        this.Label3.Size = (System.Drawing.Size) resources.GetObject("Label3.Size");

        this.Label3.TabIndex = (int) resources.GetObject("Label3.TabIndex");

        this.Label3.Text = resources.GetString("Label3.Text");

        this.Label3.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label3.TextAlign");

        this.Label3.Visible = (bool) resources.GetObject("Label3.Visible");

        //

        //MenuItem3

        //

        this.MenuItem3.Enabled = (bool) resources.GetObject("MenuItem3.Enabled");

        this.MenuItem3.Index = -1;

        this.MenuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.MenuItem2});

        this.MenuItem3.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem3.Shortcut");

        this.MenuItem3.ShowShortcut = (bool) resources.GetObject("MenuItem3.ShowShortcut");

        this.MenuItem3.Text = resources.GetString("MenuItem3.Text");

        this.MenuItem3.Visible = (bool) resources.GetObject("MenuItem3.Visible");

        //

        //Label2

        //

        this.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription");

        this.Label2.AccessibleName = resources.GetString("Label2.AccessibleName");

        this.Label2.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label2.Anchor");

        this.Label2.AutoSize = (bool) resources.GetObject("Label2.AutoSize");

        this.Label2.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label2.Dock");

        this.Label2.Enabled = (bool) resources.GetObject("Label2.Enabled");

        this.Label2.Font = (System.Drawing.Font) resources.GetObject("Label2.Font");

        this.Label2.Image = (System.Drawing.Image) resources.GetObject("Label2.Image");

        this.Label2.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label2.ImageAlign");

        this.Label2.ImageIndex = (int) resources.GetObject("Label2.ImageIndex");

        this.Label2.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label2.ImeMode");

        this.Label2.Location = (System.Drawing.Point) resources.GetObject("Label2.Location");

        this.Label2.Name = "Label2";

        this.Label2.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label2.RightToLeft");

        this.Label2.Size = (System.Drawing.Size) resources.GetObject("Label2.Size");

        this.Label2.TabIndex = (int) resources.GetObject("Label2.TabIndex");

        this.Label2.Text = resources.GetString("Label2.Text");

        this.Label2.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label2.TextAlign");

        this.Label2.Visible = (bool) resources.GetObject("Label2.Visible");

        //

        //MenuItem4

        //

        this.MenuItem4.Enabled = (bool) resources.GetObject("MenuItem4.Enabled");

        this.MenuItem4.Index = -1;

        this.MenuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.MenuItem1});

        this.MenuItem4.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem4.Shortcut");

        this.MenuItem4.ShowShortcut = (bool) resources.GetObject("MenuItem4.ShowShortcut");

        this.MenuItem4.Text = resources.GetString("MenuItem4.Text");

        this.MenuItem4.Visible = (bool) resources.GetObject("MenuItem4.Visible");

        //

        //Label1

        //

        this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");

        this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");

        this.Label1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label1.Anchor");

        this.Label1.AutoSize = (bool) resources.GetObject("Label1.AutoSize");

        this.Label1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label1.Dock");

        this.Label1.Enabled = (bool) resources.GetObject("Label1.Enabled");

        this.Label1.Font = (System.Drawing.Font) resources.GetObject("Label1.Font");

        this.Label1.Image = (System.Drawing.Image) resources.GetObject("Label1.Image");

        this.Label1.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label1.ImageAlign");

        this.Label1.ImageIndex = (int) resources.GetObject("Label1.ImageIndex");

        this.Label1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label1.ImeMode");

        this.Label1.Location = (System.Drawing.Point) resources.GetObject("Label1.Location");

        this.Label1.Name = "Label1";

        this.Label1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label1.RightToLeft");

        this.Label1.Size = (System.Drawing.Size) resources.GetObject("Label1.Size");

        this.Label1.TabIndex = (int) resources.GetObject("Label1.TabIndex");

        this.Label1.Text = resources.GetString("Label1.Text");

        this.Label1.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label1.TextAlign");

        this.Label1.Visible = (bool) resources.GetObject("Label1.Visible");

        //

        //grdOrderDetails

        //

        this.grdOrderDetails.AccessibleDescription = resources.GetString("grdOrderDetails.AccessibleDescription");

        this.grdOrderDetails.AccessibleName = resources.GetString("grdOrderDetails.AccessibleName");

        this.grdOrderDetails.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdOrderDetails.Anchor");

        this.grdOrderDetails.BackgroundImage = (System.Drawing.Image) resources.GetObject("grdOrderDetails.BackgroundImage");

        this.grdOrderDetails.CaptionFont = (System.Drawing.Font) resources.GetObject("grdOrderDetails.CaptionFont");

        this.grdOrderDetails.CaptionText = resources.GetString("grdOrderDetails.CaptionText");

        this.grdOrderDetails.DataMember = string.Empty;

        this.grdOrderDetails.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grdOrderDetails.Dock");

        this.grdOrderDetails.Enabled = (bool) resources.GetObject("grdOrderDetails.Enabled");

        this.grdOrderDetails.Font = (System.Drawing.Font) resources.GetObject("grdOrderDetails.Font");

        this.grdOrderDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.grdOrderDetails.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grdOrderDetails.ImeMode");

        this.grdOrderDetails.Location = (System.Drawing.Point) resources.GetObject("grdOrderDetails.Location");

        this.grdOrderDetails.Name = "grdOrderDetails";

        this.grdOrderDetails.ReadOnly = true;

        this.grdOrderDetails.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grdOrderDetails.RightToLeft");

        this.grdOrderDetails.Size = (System.Drawing.Size) resources.GetObject("grdOrderDetails.Size");

        this.grdOrderDetails.TabIndex = (int) resources.GetObject("grdOrderDetails.TabIndex");

        this.grdOrderDetails.Visible = (bool) resources.GetObject("grdOrderDetails.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.grdOrderDetails, this.grdOrders, this.txtHireDate, this.lblRecordNumber, this.btnLast, this.btnNext, this.btnPrevious, this.btnFirst, this.txtSalesToDate, this.txtFirstName, this.txtLastName, this.Label5, this.Label3, this.Label2, this.Label1});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.KeyPreview = true;

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

        ((System.ComponentModel.ISupportInitialize) this.grdOrders).EndInit();

        ((System.ComponentModel.ISupportInitialize) this.grdOrderDetails).EndInit();

		this.Load+=new EventHandler(frmMain_Load);

		this.KeyDown+=new KeyEventHandler(frmMain_KeyDown);

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

    // Initialize constants for connecting to the database

    // and displaying a connection error to the user.

    protected const string CONNECTION_ERROR_MSG  = "To run this sample, you must have SQL " + 
													"or MSDE with the Northwind database installed.  For " + 
													"instructions on installing MSDE, view the ReadMe file.";

    protected const string MSDE_CONNECTION_STRING  = @"Server=(local)\NetSDK;" + 
													"DataBase=northwind;" + 
													"Integrated Security=SSPI";

    protected const string SQL_CONNECTION_STRING  = "Server=localhost;" + 
													"DataBase=northwind;" + 
													"Integrated Security=SSPI";

    protected bool DidPreviouslyConnect  = false;

    private DataSet dsEmployeeOrders;

    private DataTable dtEmployee;

    private DataTable dtOrders;

    private DataTable dtOrderDetails;

    private DataTable dtSales;

    private DataView dvOrders;

    private DataView dvOrderDetails;

    private DataView dvSales;

    private SqlDataAdapter sda;

    protected string strConn  = SQL_CONNECTION_STRING;

    // Handle the << Button click event.

    private void btnFirst_Click(object sender, System.EventArgs e)
	{

        // Move to the first record
        FirstRecord();

    }

    // Handle the >> Button click event.

    private void btnLast_Click(object sender, System.EventArgs e)
	{

        // Move to the last record

        LastRecord();

    }

    // Handle the > Button click event.

    private void btnNext_Click(object sender, System.EventArgs e)
	{

        // Move to the next record

        NextRecord();

    }

    // Handle the < Button click event.

    private void btnPrevious_Click(object sender, System.EventArgs e)
	{

        // Move to the previous record

        PreviousRecord();

    }

    // Handle the PositionChanged event of the BindingContext. This event is fired in
    // response to Position changes initiated in the navigation button Click event 
    // handlers.

    protected void dtEmployee_PositionChanged(object sender, System.EventArgs e)
	{

        BindOrdersGrid();

        BindOrderDetailsGrid();

        ShowTotalSales();

        ShowCurrentRecordNumber();

    }

    // Handle the KeyDown event for the Form. For this event to fire the KeyPreview
    // property on the Form must be set to true. It is false by default.

    private void frmMain_KeyDown(object sender,  System.Windows.Forms.KeyEventArgs e) 
{

        // Let the user scroll through the records using the cursor keys.
        // Left and right are next and previous. Home and end are first and last.

       
		
		if (e.KeyCode == Keys.Right)
		{
			NextRecord();
		}

		if (e.KeyCode == Keys.Left)
		{
			PreviousRecord();
		}

		if (e.KeyCode == Keys.Home)
		{
			FirstRecord();
		}

		if (e.KeyCode == Keys.End)
		{
			LastRecord();
		}        
    }

    // Handle the Form load event.

    private void frmMain_Load(object sender, System.EventArgs e) 
	{

        CreateDataSet();

        InitializeBindings();

        BindOrdersGrid();

        BindOrderDetailsGrid();

        ShowCurrentRecordNumber();

    }

    // Handle the DataGrid Click event, which fires only when the DataGrid control 

    // frame--! the rows or cells--is clicked. Therefore, it's also a good idea 

    // to handle the CurrentCellChanged event.

    private void grdOrders_Click(object sender, System.EventArgs e) 
	{

        // Bind the Order Details grid based on the selection in grdOrders.

        BindOrderDetailsGrid();

    }

    // Handle the CurrentCellChanged event, which fires when the user clicks a 

    // different cell on the grid. Along with the DataGrid Click event, this ensures 

    // that the Order Details grid will update no matter where the user clicks on the 

    // Orders grid.

    private void grdOrders_CurrentCellChanged(object sender, System.EventArgs e)
	{

        // Highlight the entire row for user feedback.

        grdOrders.Select(grdOrders.CurrentCell.RowNumber);

        // Bind the Order Details grid based on the selection in grdOrders.

        BindOrderDetailsGrid();

    }

    // Bind and format the Order Details grid based on the user's current selection
    // in the Orders grid.

    void BindOrderDetailsGrid()
	{

        // Get the current OrderID by using the DataGrid's CurrentRowIndex, i.e.,
        // the currently selected row, and using it to match the row in the 
        // DataView. { access the "OrderID" column to get the OrderID for that
        // DataRowView.

        string strCurrentOrderID  = dvOrders[grdOrders.CurrentRowIndex]["OrderID"].ToString();

        // Filter the OrderDetails data based on the currently selected OrderID.

        dvOrderDetails.RowFilter = "OrderID = " + strCurrentOrderID;
        grdOrderDetails.CaptionText = "Order# " + strCurrentOrderID;
        grdOrderDetails.DataSource = dvOrderDetails;
 
        // You must clear out the TableStyles collection before 

        grdOrderDetails.TableStyles.Clear();

        DataGridTableStyle grdTableStyle1 = new DataGridTableStyle();

        // You must always set the MappingName, even with a DataView that has
        // only one Table. if not, you will get no errors but the formatting
        // will not appear. To avoid mistakes, instead of typing the name of 
        // the table used when creating the DataSet, you can access the 
        // TableName property.

        grdTableStyle1.MappingName = dvOrderDetails.Table.TableName;

        // The use of column styles overrides the automatic generation of columns 
        // for every column in the DataTable. When column style objects are used,
        // every column you want to display has to have an associate column style 
        // object.

        DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();

        grdColStyle1.MappingName = "ProductName";
        grdColStyle1.HeaderText = "Product";
        grdColStyle1.Width = 175;

        DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();

        grdColStyle2.MappingName = "UnitPrice";
        grdColStyle2.HeaderText = "Price";
        // Format the data currency.
        grdColStyle2.Format = "c";
        grdColStyle2.Width = 75;

        DataGridTextBoxColumn grdColStyle3 = new DataGridTextBoxColumn();
        grdColStyle3.MappingName = "Quantity";
        grdColStyle3.HeaderText = "Quantity";
        grdColStyle3.Width = 75;

        DataGridTextBoxColumn grdColStyle4 = new DataGridTextBoxColumn();

        grdColStyle4.MappingName = "SubTotal";
        grdColStyle4.HeaderText = "void Total";
        // Format the data currency.
        grdColStyle4.Format = "c";
        grdColStyle4.Width = 75;

        DataGridTextBoxColumn grdColStyle5 = new DataGridTextBoxColumn();
        
        grdColStyle5.MappingName = "Discount";
        grdColStyle5.HeaderText = "Discount";
        // Format the data to display an integer percentage. if the 0 was
        // left off the default precision of two decimal places would be used.
        grdColStyle5.Format = "P0";
        grdColStyle5.Width = 50;

        DataGridTextBoxColumn grdColStyle6 = new DataGridTextBoxColumn();

        grdColStyle6.MappingName = "CategoryName";
        grdColStyle6.HeaderText = "Category";
        grdColStyle6.Width = 125;

        // Add the column style objects to the table style's collection of 
        // column styles. Without this the styles do not take effect.        

        grdTableStyle1.GridColumnStyles.AddRange (new DataGridColumnStyle[] {grdColStyle1, grdColStyle2, 
												  grdColStyle3, grdColStyle4, grdColStyle5, grdColStyle6});
        grdOrderDetails.TableStyles.Add(grdTableStyle1);

    }

    // Bind and format the Orders grid based on the user's current Employee selection.
    void BindOrdersGrid()
	{

        // Filter the Orders data based on the value of the Tag property bound 
        // earlier. The tag contains the EmployeeID.

        dvOrders.RowFilter = "EmployeeID = " + txtLastName.Tag.ToString();

        grdOrders.CaptionText = "Orders";
        grdOrders.DataSource = dvOrders;

        // You must clear out the TableStyles collection before 
        grdOrders.TableStyles.Clear();

        DataGridTableStyle grdTableStyle1 = new DataGridTableStyle();

        // You must always set the MappingName, even with a DataView that has
        // only one Table. if not, you will get no errors but the formatting
        // will not appear. To avoid mistakes, instead of typing the name of 
        // the table used when creating the DataSet, you can access the 
        // TableName property.

        grdTableStyle1.MappingName = dvOrders.Table.TableName;

        // The use of column styles overrides the automatic generation of columns 
        // for every column in the DataTable. When column style objects are used,
        // every column you want to display has to have an associate column style 
        // object.

        DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();

        grdColStyle1.MappingName = "OrderID";
        grdColStyle1.HeaderText = "Order ID";
        grdColStyle1.Width = 50;        

        DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();

        grdColStyle2.MappingName = "CompanyName";
        grdColStyle2.HeaderText = "Customer";
        grdColStyle2.Width = 140;

        DataGridTextBoxColumn grdColStyle3 = new DataGridTextBoxColumn();

        grdColStyle3.MappingName = "OrderDate";

        // Format the data a date. This removes the time from the DateTime Sql
        // data type.

        grdColStyle3.Format = "d";
        grdColStyle3.HeaderText = "Order Date";
        grdColStyle3.Width = 75;

        DataGridTextBoxColumn grdColStyle4 = new DataGridTextBoxColumn();
            
		grdColStyle4.MappingName = "Total";
        grdColStyle4.HeaderText = "Total";

        // Format the data currency.
        grdColStyle4.Format = "c";
        grdColStyle4.Width = 75;

        // Add the column style objects to the table style's collection of 
        // column styles. Without this the styles do not take effect.        

        grdTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[] {grdColStyle1, grdColStyle2, 
											     grdColStyle3, grdColStyle4});
        grdOrders.TableStyles.Add(grdTableStyle1);

    }

    // Create the Dataset used in this sample. It contains four tables consisting of 
    // Employee info, the Employee's orders, Sales to Date, and the Order Details.

    void CreateDataSet()
	{

        // Display a status message saying that the user is attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();

        if (DidPreviouslyConnect==false)
		{

            frmStatusMessage.Show("Connecting to SQL Server");

        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool IsConnecting= true;

        while (IsConnecting)
		{

            try 
			{
                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in SQL Server, or be part of the Administrators
                // group for this to work.

                SqlConnection scnnNW = new SqlConnection(strConn);

                string strSQL  ="SELECT EmployeeID, LastName, FirstName, HireDate " + 
								"FROM Employees";

                // A SqlCommand object is used to execute the SQL commands.

                SqlCommand scmd = new SqlCommand(strSQL, scnnNW);

                // A SqlDataAdapter uses the SqlCommand object to fill a DataSet.

                sda = new SqlDataAdapter(scmd);

                // A SqlCommandBuilder automatically generates the SQL commands needed
                // to update the database later (in the btnSave_Click event handler).

                SqlCommandBuilder scb = new SqlCommandBuilder(sda);

                // The commands generated by the SqlCommandBuilder are based on the 
                // currently set CommandText of the SqlCommand object. this will
                // be changing to a SQL statement that won't be needed for an Update 
                // in the btnSave Click event handler, you can call GetUpdateCommand
                // explicitly to generate the Update command based on the current 
                // CommandText property value.

                scb.GetUpdateCommand();

                // Create a new Dataset and fill its first DataTable.

                DataSet dsEmployeeOrders = new DataSet();
                sda.Fill(dsEmployeeOrders, "Employee");

                // Reset the CommandText to get the Employee orders.

                scmd.CommandText = "SELECT od.OrderID, SUM(CONVERT(money, (od.UnitPrice * " + 
									"   od.Quantity) * (1 - od.Discount) / 100) * 100) " + 
									"   AS Total, o.EmployeeID, o.OrderDate, " + 
									"   c.CompanyName" + Environment.NewLine + 
									"FROM [Order Details] od " + 
									"   INNER JOIN Orders o " + 
									"   ON od.OrderID = o.OrderID" + Environment.NewLine + 
									"   INNER JOIN Customers c " + 
									"   ON o.CustomerID = c.CustomerID" + Environment.NewLine + 
									"GROUP BY od.OrderID, o.EmployeeID, o.OrderDate, c.CompanyName";

                // Fill the second table in the DataSet.

                sda.Fill(dsEmployeeOrders, "Orders");

                // Reset the CommandText to get the Employee Sales-To-Date.

                scmd.CommandText = "SELECT e.employeeid, sum(UnitPrice * Quantity) " + 
									"   'SalesToDate' " + 
									"FROM [order details] od " + 
									"   INNER JOIN orders o " + 
									"   ON o.orderid = od.orderid " + 
									"   INNER JOIN employees e " + 
									"   ON e.employeeid = o.employeeid" + Environment.NewLine + 
									"GROUP BY e.employeeid";

                // Fill the third table in the DataSet.

                sda.Fill(dsEmployeeOrders, "Sales");

                // Reset the CommandText to get the Order details.

                scmd.CommandText = "SELECT od.OrderID, od.UnitPrice, od.Quantity, od.Discount, " + 
									"       p.ProductName, c.CategoryName, " + 
									"       (od.UnitPrice * od.Quantity) voidTotal " + 
									"FROM [order details] od " + 
									"   INNER JOIN Products p ON od.ProductID = p.ProductID " + 
									"   INNER JOIN Categories c ON c.CategoryID = p.CategoryID " + 
									"ORDER BY od.OrderID";

                // Fill the fourth table in the DataSet.

                sda.Fill(dsEmployeeOrders, "OrderDetails");

                // Set variables for the DataTables for use later.

                dtEmployee = dsEmployeeOrders.Tables[0];

                dtOrders = dsEmployeeOrders.Tables[1];

                dtSales = dsEmployeeOrders.Tables[2];

                dtOrderDetails = dsEmployeeOrders.Tables[3];

                // Set up DataViews for the DataGrids and SalesToDate
                // TextBox.

                dvOrders = dtOrders.DefaultView;
                dvOrderDetails = dtOrderDetails.DefaultView;
                dvSales = dtSales.DefaultView;

                // OPTIONAL: To see a different kind of Master-Details interface,
                // in which both the master and details data is contained in the
                // same DataGrid, uncomment the following line of code, which sets
                // up a parent-child table relation. { re-run the app and 
                // expand the OrderID node and view order details all in the same
                // DataGrid (the Order Details grid is not needed then). On the 
                // Orders DataGrid, click the white arrow on the upper right to 
                // return to the Master view.
                //dsEmployeeOrders.Relations.Add("Order_OrderDetails", _
                //    dtOrders.Columns("OrderID"), dtOrderDetails.Columns("OrderID"))
                // Data has been successfully retrieved, so break out of the loop
                // and close the status form.

                IsConnecting = false;
                DidPreviouslyConnect = true;
                frmStatusMessage.Close();

			} 
			catch(SqlException expSql)
			{

                MessageBox.Show(expSql.Message, this.Text);
                return;

			} 
			catch(Exception exp)
			{
				if (strConn == SQL_CONNECTION_STRING)
				{
					// Couldn't connect to SQL Server.  Now try MSDE.

					strConn = MSDE_CONNECTION_STRING;
					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{

					// Unable to connect to SQL Server or MSDE

					frmStatusMessage.Close();
					MessageBox.Show(CONNECTION_ERROR_MSG, this.Text);
					Application.Exit();
				}

            }

            frmStatusMessage.Close();

        }

    }

    // Handle the Format event for the Hire Date TextBox

    void DateTostring(object sender, ConvertEventArgs e)
	{

        // You could use either of the following to convert to the proper date 
        // format:
        //e.Value = CType(e.Value, DateTime).Tostring("d")

        e.Value = ((DateTime) e.Value).ToShortDateString();

    }

    // Move the BindingContext Position to the first record.

    public void FirstRecord()
	{	

        // The position of the binding context controls the "current record"
        // Position the first record is record 0 (! 1).

        this.BindingContext[dtEmployee].Position = 0;

    }

    // Set up all the bindings for various controls.

    private void InitializeBindings()
	{

        txtLastName.DataBindings.Add("Text", dtEmployee, "LastName");

        // Using the Tag property you can bind a hidden value that is useful when
        // stepping through the records. In this demo, the EmployeeID numbers match
        // the DataTable row numbers, so you could just use the Position property
        // in ShowCurrentRecordNumber.

        txtLastName.DataBindings.Add("Tag", dtEmployee, "EmployeeID");

        txtFirstName.DataBindings.Add("Text", dtEmployee, "FirstName");

        // The Binding object binds a single property of a control to a single
        // field of the data source. After creating a Binding object you add it
        // to the ControlBindingCollection object exposed by all Windows Forms
        // controls via the DataBindings property.

        Binding dbnHireDate = new Binding("Text", dtEmployee, "HireDate");
        txtHireDate.DataBindings.Add(dbnHireDate);

        // if you are using custom format/parse handlers, add them next.

		dbnHireDate.Format+=new ConvertEventHandler(DateTostring);	
		dbnHireDate.Parse+=new ConvertEventHandler(stringToDate);
		Binding dbnSalesToDate = new Binding("Text", dtSales, "SalesToDate");
        txtSalesToDate.DataBindings.Add(dbnSalesToDate);
		dbnSalesToDate.Format+=new ConvertEventHandler(MoneyTostring);
		dbnSalesToDate.Parse+=new ConvertEventHandler(stringToMoney);

        // The Form's BindingContext property exposes the BindingManagerBase
        // object, which gathers all the Binding objects associated with the same
        // data source (in this case, the DataTable dtEmployee). This object fires
        // a PositionChanged event which is one of the key events to handle in a 
        // Master-Details application. The position is advanced programmatically in
        // the Click event handlers for the navigation buttons.

		this.BindingContext[dtEmployee].PositionChanged+=new EventHandler(dtEmployee_PositionChanged);
    }

    // Move the BindingContext Position to the last record.

    public void LastRecord()
	{

        // The position of the binding context controls the "current record". 
        // Use dsEmployeeOrders("EmployeeInfo").Rows.Count to figure out the total 
        // number of records.  -1 because position is zero based.

        this.BindingContext[dtEmployee].Position = dtEmployee.Rows.Count - 1;

    }

    // Handle the Format event for the SalesToDate TextBox.

    protected void MoneyTostring(object sender, ConvertEventArgs e )
	{

		e.Value = ((Decimal) e.Value).ToString("c");

    }

    // Move the BindingContext Position to the next record.

    public void NextRecord()
	{

        // The position of the binding context controls the "current record"

        this.BindingContext[dtEmployee].Position += 1;

    }

    // Move the BindingContext Position to the previous record.

    public void PreviousRecord()
	{

        // The position of the binding context controls the "current record"

        this.BindingContext[dtEmployee].Position -= 1;

    }

    // Display the current record number and total records.

    protected void ShowCurrentRecordNumber()
	{

        // The position  of the binding context contains the current record.
        // Add 1 so that the first record displays record 1 (instead of 0).
        // dtEmployee.Rows.Count gives the total number of records.

        lblRecordNumber.Text = "Record " + (this.BindingContext[dtEmployee].Position + 1) + " of " + 
								dtEmployee.Rows.Count;

    }

    // Update the value of the Sales To Date for each employee the user
    // steps through the records.

    protected void ShowTotalSales()
	{

        // Filter the sales total based on the value of the Tag property bound 
        // earlier.

        dvSales.RowFilter = "EmployeeID = " + txtLastName.Tag.ToString();

    }

    // Handle the Parse event for the Hire Date TextBox.

    protected void stringToDate(object sender, ConvertEventArgs e )
	{

        try 
		{

			e.Value = Convert.ToDateTime(e.Value);

		} 
		catch(Exception exp)
		{

            MessageBox.Show(exp.Message, this.Text);

        }

    }

    // Handle the Parse event for the Sales To Date TextBox.

    protected void stringToMoney(object sender,ConvertEventArgs e )
	{

        try 
		{
            // double is equivalent to a Money SQL data type.

            e.Value = (Double) e.Value;

		} 
		catch(Exception exp)
		{

            MessageBox.Show(exp.Message, this.Text);

        }

    }

}

