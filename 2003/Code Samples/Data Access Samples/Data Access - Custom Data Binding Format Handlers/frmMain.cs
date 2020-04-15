//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}


	// Initialize constants for connecting to the database
	// and displaying a connection error to the user.

	protected const string SQL_CONNECTION_STRING = "Server=localhost;" +
		"DataBase=northwind;" +
		"Integrated Security=SSPI";

	protected const string MSDE_CONNECTION_STRING=@"Server=(local)\NetSDK;" +
		"DataBase=northwind;" +
		"Integrated Security=SSPI";

	protected const string CONNECTION_ERROR_MSG ="To run this sample, you must have SQL " +
		"or MSDE with the Northwind database installed.  For " +
		"instructions on installing MSDE, view the ReadMe file.";

	protected bool blnDidPreviouslyConnect  = false;

	protected string connectionstring  = SQL_CONNECTION_STRING;

	private SqlDataAdapter da;

	private DataTable dtEmployeeInfo;

	private DataTable dtEmployeeOrders;

	private DataTable dtEmployeeSales;

	private DataView dvEmployeeOrders;

	private DataView dvEmployeeSales;

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

	private System.Windows.Forms.Label Label1;

	private System.Windows.Forms.Label Label2;

	private System.Windows.Forms.Label Label3;

	private System.Windows.Forms.Label Label4;

	private System.Windows.Forms.Label Label5;

	private System.Windows.Forms.TextBox txtLastName;

	private System.Windows.Forms.TextBox txtFirstName;

	private System.Windows.Forms.TextBox txtRegion;

	private System.Windows.Forms.TextBox txtSalesToDate;

	private System.Windows.Forms.Button btnLast;

	private System.Windows.Forms.Button btnNext;

	private System.Windows.Forms.Button btnPrevious;

	private System.Windows.Forms.Button btnFirst;

	private System.Windows.Forms.Label Label6;

	private System.Windows.Forms.CheckBox chkIsMarried;

	private System.Windows.Forms.Label lblRecordNumber;

	private System.Windows.Forms.TextBox txtHireDate;

	private System.Windows.Forms.DataGrid grdOrders;

	private System.Windows.Forms.Button btnSave;

	private void InitializeComponent() 
	{

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.Label1 = new System.Windows.Forms.Label();

		this.Label2 = new System.Windows.Forms.Label();

		this.Label3 = new System.Windows.Forms.Label();

		this.Label4 = new System.Windows.Forms.Label();

		this.Label5 = new System.Windows.Forms.Label();

		this.txtLastName = new System.Windows.Forms.TextBox();

		this.txtFirstName = new System.Windows.Forms.TextBox();

		this.txtRegion = new System.Windows.Forms.TextBox();

		this.txtSalesToDate = new System.Windows.Forms.TextBox();

		this.btnLast = new System.Windows.Forms.Button();

		this.btnNext = new System.Windows.Forms.Button();

		this.btnPrevious = new System.Windows.Forms.Button();

		this.btnFirst = new System.Windows.Forms.Button();

		this.Label6 = new System.Windows.Forms.Label();

		this.chkIsMarried = new System.Windows.Forms.CheckBox();

		this.lblRecordNumber = new System.Windows.Forms.Label();

		this.txtHireDate = new System.Windows.Forms.TextBox();

		this.grdOrders = new System.Windows.Forms.DataGrid();

		this.btnSave = new System.Windows.Forms.Button();

		((System.ComponentModel.ISupportInitialize) this.grdOrders).BeginInit();

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

		//Label4

		//

		this.Label4.AccessibleDescription = resources.GetString("Label4.AccessibleDescription");

		this.Label4.AccessibleName = resources.GetString("Label4.AccessibleName");

		this.Label4.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label4.Anchor");

		this.Label4.AutoSize = (bool) resources.GetObject("Label4.AutoSize");

		this.Label4.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label4.Dock");

		this.Label4.Enabled = (bool) resources.GetObject("Label4.Enabled");

		this.Label4.Font = (System.Drawing.Font) resources.GetObject("Label4.Font");

		this.Label4.Image = (System.Drawing.Image) resources.GetObject("Label4.Image");

		this.Label4.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label4.ImageAlign");

		this.Label4.ImageIndex = (int) resources.GetObject("Label4.ImageIndex");

		this.Label4.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label4.ImeMode");

		this.Label4.Location = (System.Drawing.Point) resources.GetObject("Label4.Location");

		this.Label4.Name = "Label4";

		this.Label4.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label4.RightToLeft");

		this.Label4.Size = (System.Drawing.Size) resources.GetObject("Label4.Size");

		this.Label4.TabIndex = (int) resources.GetObject("Label4.TabIndex");

		this.Label4.Text = resources.GetString("Label4.Text");

		this.Label4.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label4.TextAlign");

		this.Label4.Visible = (bool) resources.GetObject("Label4.Visible");

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

		this.txtLastName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtLastName.RightToLeft");

		this.txtLastName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtLastName.ScrollBars");

		this.txtLastName.Size = (System.Drawing.Size) resources.GetObject("txtLastName.Size");

		this.txtLastName.TabIndex = (int) resources.GetObject("txtLastName.TabIndex");

		this.txtLastName.Text = resources.GetString("txtLastName.Text");

		this.txtLastName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtLastName.TextAlign");

		this.txtLastName.Visible = (bool) resources.GetObject("txtLastName.Visible");

		this.txtLastName.WordWrap = (bool) resources.GetObject("txtLastName.WordWrap");

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

		this.txtFirstName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtFirstName.RightToLeft");

		this.txtFirstName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtFirstName.ScrollBars");

		this.txtFirstName.Size = (System.Drawing.Size) resources.GetObject("txtFirstName.Size");

		this.txtFirstName.TabIndex = (int) resources.GetObject("txtFirstName.TabIndex");

		this.txtFirstName.Text = resources.GetString("txtFirstName.Text");

		this.txtFirstName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtFirstName.TextAlign");

		this.txtFirstName.Visible = (bool) resources.GetObject("txtFirstName.Visible");

		this.txtFirstName.WordWrap = (bool) resources.GetObject("txtFirstName.WordWrap");

		//

		//txtRegion

		//

		this.txtRegion.AccessibleDescription = resources.GetString("txtRegion.AccessibleDescription");

		this.txtRegion.AccessibleName = resources.GetString("txtRegion.AccessibleName");

		this.txtRegion.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtRegion.Anchor");

		this.txtRegion.AutoSize = (bool) resources.GetObject("txtRegion.AutoSize");

		this.txtRegion.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtRegion.BackgroundImage");

		this.txtRegion.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtRegion.Dock");

		this.txtRegion.Enabled = (bool) resources.GetObject("txtRegion.Enabled");

		this.txtRegion.Font = (System.Drawing.Font) resources.GetObject("txtRegion.Font");

		this.txtRegion.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtRegion.ImeMode");

		this.txtRegion.Location = (System.Drawing.Point) resources.GetObject("txtRegion.Location");

		this.txtRegion.MaxLength = (int) resources.GetObject("txtRegion.MaxLength");

		this.txtRegion.Multiline = (bool) resources.GetObject("txtRegion.Multiline");

		this.txtRegion.Name = "txtRegion";

		this.txtRegion.PasswordChar = (char) resources.GetObject("txtRegion.PasswordChar");

		this.txtRegion.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtRegion.RightToLeft");

		this.txtRegion.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtRegion.ScrollBars");

		this.txtRegion.Size = (System.Drawing.Size) resources.GetObject("txtRegion.Size");

		this.txtRegion.TabIndex = (int) resources.GetObject("txtRegion.TabIndex");

		this.txtRegion.Text = resources.GetString("txtRegion.Text");

		this.txtRegion.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtRegion.TextAlign");

		this.txtRegion.Visible = (bool) resources.GetObject("txtRegion.Visible");

		this.txtRegion.WordWrap = (bool) resources.GetObject("txtRegion.WordWrap");

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

		//Label6

		//

		this.Label6.AccessibleDescription = resources.GetString("Label6.AccessibleDescription");

		this.Label6.AccessibleName = resources.GetString("Label6.AccessibleName");

		this.Label6.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label6.Anchor");

		this.Label6.AutoSize = (bool) resources.GetObject("Label6.AutoSize");

		this.Label6.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label6.Dock");

		this.Label6.Enabled = (bool) resources.GetObject("Label6.Enabled");

		this.Label6.Font = (System.Drawing.Font) resources.GetObject("Label6.Font");

		this.Label6.Image = (System.Drawing.Image) resources.GetObject("Label6.Image");

		this.Label6.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label6.ImageAlign");

		this.Label6.ImageIndex = (int) resources.GetObject("Label6.ImageIndex");

		this.Label6.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label6.ImeMode");

		this.Label6.Location = (System.Drawing.Point) resources.GetObject("Label6.Location");

		this.Label6.Name = "Label6";

		this.Label6.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label6.RightToLeft");

		this.Label6.Size = (System.Drawing.Size) resources.GetObject("Label6.Size");

		this.Label6.TabIndex = (int) resources.GetObject("Label6.TabIndex");

		this.Label6.Text = resources.GetString("Label6.Text");

		this.Label6.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label6.TextAlign");

		this.Label6.Visible = (bool) resources.GetObject("Label6.Visible");

		//

		//chkIsMarried

		//

		this.chkIsMarried.AccessibleDescription = resources.GetString("chkIsMarried.AccessibleDescription");

		this.chkIsMarried.AccessibleName = resources.GetString("chkIsMarried.AccessibleName");

		this.chkIsMarried.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkIsMarried.Anchor");

		this.chkIsMarried.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkIsMarried.Appearance");

		this.chkIsMarried.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkIsMarried.BackgroundImage");

		this.chkIsMarried.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIsMarried.CheckAlign");

		this.chkIsMarried.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkIsMarried.Dock");

		this.chkIsMarried.Enabled = (bool) resources.GetObject("chkIsMarried.Enabled");

		this.chkIsMarried.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkIsMarried.FlatStyle");

		this.chkIsMarried.Font = (System.Drawing.Font) resources.GetObject("chkIsMarried.Font");

		this.chkIsMarried.Image = (System.Drawing.Image) resources.GetObject("chkIsMarried.Image");

		this.chkIsMarried.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIsMarried.ImageAlign");

		this.chkIsMarried.ImageIndex = (int) resources.GetObject("chkIsMarried.ImageIndex");

		this.chkIsMarried.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkIsMarried.ImeMode");

		this.chkIsMarried.Location = (System.Drawing.Point) resources.GetObject("chkIsMarried.Location");

		this.chkIsMarried.Name = "chkIsMarried";

		this.chkIsMarried.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkIsMarried.RightToLeft");

		this.chkIsMarried.Size = (System.Drawing.Size) resources.GetObject("chkIsMarried.Size");

		this.chkIsMarried.TabIndex = (int) resources.GetObject("chkIsMarried.TabIndex");

		this.chkIsMarried.Text = resources.GetString("chkIsMarried.Text");

		this.chkIsMarried.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIsMarried.TextAlign");

		this.chkIsMarried.Visible = (bool) resources.GetObject("chkIsMarried.Visible");

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

		this.txtHireDate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtHireDate.RightToLeft");

		this.txtHireDate.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtHireDate.ScrollBars");

		this.txtHireDate.Size = (System.Drawing.Size) resources.GetObject("txtHireDate.Size");

		this.txtHireDate.TabIndex = (int) resources.GetObject("txtHireDate.TabIndex");

		this.txtHireDate.Text = resources.GetString("txtHireDate.Text");

		this.txtHireDate.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtHireDate.TextAlign");

		this.txtHireDate.Visible = (bool) resources.GetObject("txtHireDate.Visible");

		this.txtHireDate.WordWrap = (bool) resources.GetObject("txtHireDate.WordWrap");

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

		//

		//btnSave

		//

		this.btnSave.AccessibleDescription = resources.GetString("btnSave.AccessibleDescription");

		this.btnSave.AccessibleName = resources.GetString("btnSave.AccessibleName");

		this.btnSave.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSave.Anchor");

		this.btnSave.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSave.BackgroundImage");

		this.btnSave.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSave.Dock");

		this.btnSave.Enabled = (bool) resources.GetObject("btnSave.Enabled");

		this.btnSave.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSave.FlatStyle");

		this.btnSave.Font = (System.Drawing.Font) resources.GetObject("btnSave.Font");

		this.btnSave.Image = (System.Drawing.Image) resources.GetObject("btnSave.Image");

		this.btnSave.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSave.ImageAlign");

		this.btnSave.ImageIndex = (int) resources.GetObject("btnSave.ImageIndex");

		this.btnSave.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSave.ImeMode");

		this.btnSave.Location = (System.Drawing.Point) resources.GetObject("btnSave.Location");

		this.btnSave.Name = "btnSave";

		this.btnSave.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSave.RightToLeft");

		this.btnSave.Size = (System.Drawing.Size) resources.GetObject("btnSave.Size");

		this.btnSave.TabIndex = (int) resources.GetObject("btnSave.TabIndex");

		this.btnSave.Text = resources.GetString("btnSave.Text");

		this.btnSave.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSave.TextAlign");

		this.btnSave.Visible = (bool) resources.GetObject("btnSave.Visible");

		this.btnSave.Click+=new EventHandler(btnSave_Click);

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

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnSave, this.grdOrders, this.txtHireDate, this.lblRecordNumber, this.chkIsMarried, this.Label6, this.btnLast, this.btnNext, this.btnPrevious, this.btnFirst, this.txtSalesToDate, this.txtRegion, this.txtFirstName, this.txtLastName, this.Label5, this.Label4, this.Label3, this.Label2, this.Label1});

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

		this.Load+=new EventHandler(frmMain_Load);

		this.KeyDown+=new KeyEventHandler(frmMain_KeyDown);

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

	#region " Creating the Demo Dataset ";

	// This sub adds a new demo table to Northwind based on the Employees table.
	// It then loads the table with some additional dummy data to show how a 
	// DateTime and a SmallInt field (that is used a bool in the
	// application) can be formatted with the handlers. A Dataset is then created.

	void CreateDataSet()
	{

		// Display a status message saying that the user is attempting to connect.
		// This only needs to be done the very first time a connection is
		// attempted.  After we've determined that MSDE or SQL Server is
		// installed, this message no longer needs to be displayed.

		frmStatus frmStatusMessage = new frmStatus();

		if (blnDidPreviouslyConnect==false) 
		{

			frmStatusMessage.Show("Connecting to SQL Server");

		}

		// Attempt to connect to the local SQL server instance, and a local
		// MSDE installation (with Northwind).  

		bool blnIsConnecting  = true;

		while (blnIsConnecting)
		{

			try 
			{

				// The SqlConnection class allows you to communicate with SQL Server.
				// The constructor accepts a connection string an argument.  This
				// connection string uses Integrated Security, which means that you 
				// must have a login in SQL Server, or be part of the Administrators
				// group for this to work.

				SqlConnection cnnNW = new SqlConnection(connectionstring);

				// Build a SQL string that checks for the existence of the new table
				// you will add for this demo. if necessary, drop and then create the
				// table based on the current Employees table. { add two additional
				// columns for dummy data.

				string strSQL = "IF EXISTS (" +
					"SELECT * " +
					"FROM northwind.dbo.sysobjects " +
					"WHERE NAME = 'newEmployees' " +
					"AND TYPE = 'u')" + Environment.NewLine +
					"BEGIN" + Environment.NewLine +
					"DROP TABLE northwind.dbo.newEmployees" + Environment.NewLine +
					"END" + Environment.NewLine +
					"SELECT EmployeeID, LastName, FirstName, HireDate, Region " +
					"INTO newEmployees " +
					"FROM Employees " + Environment.NewLine +
					"ALTER Table newEmployees " +
					"ADD " +
					"IsMarried SmallInt NULL, " +
					"CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED" +
					"(EmployeeID)";

				// A SqlCommand object is used to execute the SQL commands.

				SqlCommand cmd = new SqlCommand(strSQL, cnnNW);

				// Open the connection and execute the SQL statements.

				cnnNW.Open();
				cmd.ExecuteNonQuery();

				// For demo purposes: data to be used to fill additional column.

				ArrayList arlIsMarried = new ArrayList();
				arlIsMarried.Add(1);
				arlIsMarried.Add(0);
				arlIsMarried.Add(0);
				arlIsMarried.Add(1);
				arlIsMarried.Add(1);
				arlIsMarried.Add(1);
				arlIsMarried.Add(0);
				arlIsMarried.Add(1);
				arlIsMarried.Add(0);

				// Add SQL parameters for use when filling the additional column
				// with demo data.

				SqlParameter paramIsMarried = new SqlParameter("@IsMarried",
					SqlDbType.SmallInt);
				cmd.Parameters.Add(paramIsMarried);
				SqlParameter paramEmployeeID = new SqlParameter("@EmployeeID",
					SqlDbType.Int);
				cmd.Parameters.Add(paramEmployeeID);

				// Update the command text for filling the extra column with data.

				cmd.CommandText ="UPDATE newEmployees " +
					"SET IsMarried = @IsMarried " +
					"WHERE EmployeeID = @EmployeeID";

				// Fill the additional columns with the ArrayList data.

				Int32 i=0;

				foreach(Object obj in arlIsMarried)
				{
					paramIsMarried.Value = arlIsMarried[i];
					paramEmployeeID.Value = i + 1;
					cmd.ExecuteNonQuery();
					i += 1;
				}

				// Reset the CommandText to get the Employee data.

				cmd.CommandText ="SELECT EmployeeID, LastName, FirstName, HireDate, Region, " +
					"       IsMarried " +
					"FROM newEmployees";

				// A SqlDataAdapter uses the SqlCommand object to fill a DataSet.

				 da = new SqlDataAdapter(cmd);

				// A SqlCommandBuilder automatically generates the SQL commands needed
				// to update the database later (in the btnSave_Click event handler).

				SqlCommandBuilder scb = new SqlCommandBuilder(da);

				// The commands generated by the SqlCommandBuilder are based on the 
				// currently set CommandText of the SqlCommand object. this will
				// be changing to a SQL statement that won't be needed for an Update 
				// in the btnSave Click event handler, you can call GetUpdateCommand
				// explicitly to generate the Update command based on the current 
				// CommandText property value.

				scb.GetUpdateCommand();

				// Create and fill a new DataSet.

				DataSet dsEmployees = new DataSet();
				da.Fill(dsEmployees, "EmployeeInfo");

				// Reset the CommandText to get the Employee orders.

				cmd.CommandText ="SELECT od.OrderID, SUM(CONVERT(money, (od.UnitPrice * " +
					"   od.Quantity) * (1 - od.Discount) / 100) * 100) " +
					"   AS voidtotal, o.EmployeeID" + Environment.NewLine +
					"FROM [Order Details] od INNER JOIN Orders o " +
					"    ON od.OrderID = o.OrderID" + Environment.NewLine +
					"GROUP BY od.OrderID, o.EmployeeID";

				// Fill the second table in the DataSet.

				da.Fill(dsEmployees, "EmployeeOrders");

				// Reset the CommandText to get the Employee Sales To Date.

				cmd.CommandText ="SELECT e.employeeid, sum(UnitPrice * Quantity) " +
					"   'SalesToDate' " +
					"FROM [order details] od " +
					"INNER JOIN orders o " +
					"ON o.orderid = od.orderid " +
					"INNER JOIN employees e " +
					"ON e.employeeid = o.employeeid" + Environment.NewLine +
					"GROUP BY e.employeeid";

				// Fill the third table in the DataSet.

				da.Fill(dsEmployees, "EmployeeSales");

				// Set variables for the two DataTables for use later.

				dtEmployeeInfo = dsEmployees.Tables[0];
				dtEmployeeOrders = dsEmployees.Tables[1];
				dtEmployeeSales = dsEmployees.Tables[2];

				// Set up DataViews for the DataGrid and SalesToDate
				// TextBox.

				dvEmployeeOrders = dtEmployeeOrders.DefaultView;
				dvEmployeeSales = dtEmployeeSales.DefaultView;

				// Data has been successfully retrieved, so break out of the loop
				// and close the status form.

				blnIsConnecting = false;
				blnDidPreviouslyConnect = true;
				frmStatusMessage.Close();

			} 
			catch(SqlException sqlExc)
			{
				MessageBox.Show(sqlExc.ToString(), "SQL Exception Error!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

			} 
			catch(Exception exp)
			{
				MessageBox.Show(exp.Message);

				if (connectionstring == SQL_CONNECTION_STRING)
				{
					// Couldn't connect to SQL Server.  Now try MSDE.

					connectionstring = MSDE_CONNECTION_STRING;

					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{

					// Unable to connect to SQL Server or MSDE

					frmStatusMessage.Close();

					MessageBox.Show(CONNECTION_ERROR_MSG,
						"Connection Failed!", MessageBoxButtons.OK,
						MessageBoxIcon.Error);

					Application.Exit();
				}
			}
		}
	}

	#endregion

	// the << Button click event.

	private void btnFirst_Click(object sender, System.EventArgs e)
	{

		// Move to the first record

		FirstRecord();

	}

	// the >> Button click event.

	private void btnLast_Click(object sender, System.EventArgs e)
	{

		// Move to the last record

		LastRecord();

	}

	// the > Button click event.

	private void btnNext_Click(object sender, System.EventArgs e)
	{

		// Move to the next record

		NextRecord();

	}

	// the < Button click event.

	private void btnPrevious_Click(object sender, System.EventArgs e)
	{

		// Move to the previous record

		PreviousRecord();

	}

	// if you were updating a database you would call the Update method of the 
	// SqlDataAdapter object, passing in the DataSet.

	private void btnSave_Click(object sender, System.EventArgs e)
	{

		try 
		{

			// End the Current edit. if you do not do this, when the user makes a 
			// change and then clicks the Save button prior to stepping to another
			// records, the changes will not be propagated.

			this.BindingContext[dtEmployeeInfo].EndCurrentEdit();

			// Update the database with the changes made to the local resident DataSet.

			da.Update(this.dtEmployeeInfo);
			MessageBox.Show("Database successfully updated.",
				"Custom Formatting Handler Demo", MessageBoxButtons.OK,
				MessageBoxIcon.Information);

		} 
		catch(Exception exp)
		{

			MessageBox.Show("There was an error when attempting to update " +
				"the database: " + exp.Message,
				this.Text, MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}

	}

	// This handler fires when the PositionChanged event of the BindingContext fires.
	// The two are related via the AddHandler assignment in frmMain_Load.

	protected void dtEmployeeInfo_PositionChanged(object sender, System.EventArgs e)
	{

		BindAndFormatGrid();
		ShowTotalSales();
		ShowCurrentRecordNumber();
	}

	// the KeyDown event for the Form. For this event to fire the KeyPreview
	// property on the Form must be set to true. It is false by default.

	private void frmMain_KeyDown(object sender,  System.Windows.Forms.KeyEventArgs e) 
	{

	// Let the user scroll through the records using the cursor keys.
	// Left and right are next and previous. Home and end are first and last.

	if (e.KeyCode == Keys.Right) 
	{ 
		NextRecord();
	}
	if (e.KeyCode == Keys.Right) 
	{ 
		PreviousRecord();
	}
	if (e.KeyCode == Keys.Right) 
	{ 
		FirstRecord();
	}
	if (e.KeyCode == Keys.Right) 
	{ 
		LastRecord();
	}
     
    }

    // the Form load event. The databindings and custom formatting handlers
    // are all set up here.

    private void frmMain_Load(object sender, System.EventArgs e) 
	{

        // Create the Dataset with the addition of some fake demo data.

        CreateDataSet();

        // Begin to set up all the bindings for various controls.

        txtLastName.DataBindings.Add("Text", dtEmployeeInfo, "LastName");

        // Using the Tag property you can bind a hidden value that is useful when
        // stepping through the records. In this demo, the EmployeeID numbers match
        // the DataTable row numbers, so you could just use the Position property
        // in ShowCurrentRecordNumber.

        txtLastName.DataBindings.Add("Tag", dtEmployeeInfo, "EmployeeID");

        txtFirstName.DataBindings.Add("Text", dtEmployeeInfo, "FirstName");

        Binding dbnHireDate = new Binding("Text", dtEmployeeInfo, "HireDate");

		dbnHireDate.Format+=new ConvertEventHandler(DateTostring);

		dbnHireDate.Parse+=new ConvertEventHandler(stringToDate);

        txtHireDate.DataBindings.Add(dbnHireDate);

        Binding dbnRegion = new Binding("Text", dtEmployeeInfo, "Region");

		dbnRegion.Format+=new ConvertEventHandler(NullTostring);

		dbnRegion.Parse+=new ConvertEventHandler(stringToNull);
        
		txtRegion.DataBindings.Add(dbnRegion);

        Binding dbnIsMarried = new Binding("Checked", dtEmployeeInfo, "IsMarried");

        // See the comments about this AddHandler for the 
        // CreateDataset method and in the Readme file.

        
		dbnIsMarried.Format+=new ConvertEventHandler(SmallIntTobool);
        
		dbnIsMarried.Parse+=new ConvertEventHandler(boolToSmallInt);
        
		chkIsMarried.DataBindings.Add(dbnIsMarried);

        Binding dbnSalesToDate = new Binding("Text", dtEmployeeSales, "SalesToDate");

        
		dbnSalesToDate.Format+=new ConvertEventHandler(MoneyTostring);
        
		dbnSalesToDate.Parse+=new ConvertEventHandler(stringToMoney);
        
		txtSalesToDate.DataBindings.Add(dbnSalesToDate);

		this.BindingContext[dtEmployeeInfo].PositionChanged+=new EventHandler(dtEmployeeInfo_PositionChanged);

        BindAndFormatGrid();

        ShowCurrentRecordNumber();

    }

    // Binds the DataGrid to the EmployeeOrders table and applies custom formatting.

    void BindAndFormatGrid()
	{

        // Filter the OrderIDs based on the value of the Tag property bound earlier.

        dvEmployeeOrders.RowFilter = "EmployeeID = " + txtLastName.Tag.ToString();

        grdOrders.CaptionText = "Orders";
        grdOrders.DataSource = dvEmployeeOrders;
        
		// You must clear out the TableStyles collection before 

        grdOrders.TableStyles.Clear();

        DataGridTableStyle grdTableStyle1 = new DataGridTableStyle();

            // You must always set the MappingName, even with a DataView that has
            // only one Table. if not, you will get no errors but the formatting
            // will not appear.

		grdTableStyle1.MappingName = "EmployeeOrders";

        // The use of column styles overrides the automatic generation of columns 
        // for every column in the DataTable. When column style objects are used,
        // every column you want to display has to have an associate column style 
        // object.

        DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();

        grdColStyle1.MappingName = "OrderID";
        grdColStyle1.HeaderText = "Order ID";
        grdColStyle1.Width = 75;

        DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();

        grdColStyle2.MappingName = "voidtotal";
        grdColStyle2.HeaderText = "Sub Total";
        grdColStyle2.Format = "c";
        grdColStyle2.Width = 75;
    
        // Add the column style objects to the table style's collection of 
        // column styles. Without this the styles do not take effect.        

        grdTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[] {grdColStyle1, grdColStyle2});
        grdOrders.TableStyles.Add(grdTableStyle1);

    }

    // the Parse event for the CheckBox control

    protected void boolToSmallInt(object sender, ConvertEventArgs e)
	{

        switch((bool) e.Value)
		{

            case true:

                e.Value = 1;
				break;
            default: 

                e.Value = 0;
				break;
        }

    }

    // the Format event for the Hire Date TextBox

    protected void DateTostring(object sender,  ConvertEventArgs e)
	{

        // You could use either of the following to convert to the proper date 
        // format:
        //e.Value = CType(e.Value, DateTime).ToString()("d")

        e.Value = ((DateTime) e.Value).ToShortDateString();
    }

    // Moves the BindingContext Position to the first record.

    public void FirstRecord()
	{

        // The position of the binding context controls the "current record"
        // Position the first record is record 0 (! 1).

        this.BindingContext[dtEmployeeInfo].Position = 0;

    }

    // Moves the BindingContext Position to the last record.

    public void LastRecord()
	{

        // The position of the binding context controls the "current record". 
        // Use dsEmployees("EmployeeInfo").Rows.Count to figure out the total 
        // number of records.  -1 because position is zero based.

        this.BindingContext[dtEmployeeInfo].Position = dtEmployeeInfo.Rows.Count - 1;

    }

    // the Format event for the SalesToDate TextBox.

    protected void MoneyTostring(object sender,  ConvertEventArgs e)
	{

        e.Value = ((Decimal) e.Value).ToString("c");

    }

    // Moves the BindingContext Position to the next record.

    public void NextRecord()
	{

        // The position of the binding context controls the "current record"

        this.BindingContext[dtEmployeeInfo].Position += 1;

    }

    // the Format event for the Region TextBox.

    protected void NullTostring(object sender,  ConvertEventArgs e)
	{

		if (e.Value == DBNull.Value)
		{
			e.Value = "[N/A]";
		}
		else if (e.Value.ToString().Trim().Length == 0)
		{
			e.Value = "[N/A]";
		}

    }

    // Moves the BindingContext Position to the previous record.

    public void PreviousRecord()
	{

        // The position of the binding context controls the "current record"

        this.BindingContext[dtEmployeeInfo].Position -= 1;

    }

    // Outputs the current record number.

    protected void ShowCurrentRecordNumber()
	{

        // The position  of the binding context contains the current record.
        // Add 1 so that the first record displays record 1 (instead of 0).
        // dtEmployeeInfo.Rows.Count gives the total number of records.

        lblRecordNumber.Text = "Record " +
							   (this.BindingContext[dtEmployeeInfo].Position + 1) + " of " +
							   dtEmployeeInfo.Rows.Count;
    }

    // Updates the value of the Sales To Date for each employee the user
    // steps through the records.

    protected void ShowTotalSales()
	{

        // Filter the sales total based on the value of the Tag property bound 
        // earlier.

        dvEmployeeSales.RowFilter = "EmployeeID = " + txtLastName.Tag.ToString();

    }

    // the Format event for the CheckBox control.

    protected void SmallIntTobool(object sender,  ConvertEventArgs e)
	{
        switch(Convert.ToInt16(e.Value))
		{
            case 1:
                e.Value = true;
				break;
            default: 
                e.Value = false;
				break;
        }
    }

    // the Parse event for the Hire Date TextBox.

    protected void stringToDate(object sender,  ConvertEventArgs e)
	{

        try 
		{

            e.Value = Convert.ToDateTime(e.Value);

		} 
		catch(Exception exp)
		{

            MessageBox.Show("Data entry error: " + exp.Message, this.Text,
							MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }

    // the Parse event for the Sales To Date TextBox.

    protected void stringToMoney(object sender,  ConvertEventArgs e)
	{
        try 
		{

            // double is equivalent to a Money SQL data type.
            e.Value = (Double) e.Value;

		} 
		catch(Exception exp)
		{

            MessageBox.Show("Data entry error: " + exp.Message, this.Text,
							MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }

    // the Parse event for the Region TextBox.

    protected void stringToNull(object sender, ConvertEventArgs e)
	{

        if (e.Value.ToString() == "[N/A]" | e.Value.ToString().Trim().Length == 0)
		{
            try 
			{

                e.Value = DBNull.Value;

			} 
			catch(Exception exp)
			{

                MessageBox.Show("Data entry error: " + exp.Message, this.Text,
								MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    }

}

