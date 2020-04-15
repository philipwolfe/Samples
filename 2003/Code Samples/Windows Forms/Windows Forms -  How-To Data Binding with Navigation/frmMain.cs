//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
//Requires SQL Server or MSDE with the Northwind sample database installed.

using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using HowTo.DataBindingWithNavigation;

public class frmMain: System.Windows.Forms.Form 
{

	protected ProductDataSet productInfo = new ProductDataSet();

	protected const string SQL_CONNECTION_STRING = "Server=localhost;" + 
		"DataBase=Northwind;Integrated Security=SSPI";

	protected const string MSDE_CONNECTION_STRING = @"Server=(local)\NetSDK;" +
		"DataBase=Northwind;Integrated Security=SSPI";

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

	#region " Windows Form Designer generated code "

	public frmMain () 
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

	private System.Windows.Forms.Label Label6;

	private System.Windows.Forms.Label Label7;

	private System.Windows.Forms.Label Label8;

	private System.Windows.Forms.Label Label9;

	private System.Windows.Forms.Label Label10;

	private System.Windows.Forms.TextBox txtProductID;

	private System.Windows.Forms.TextBox txtProductName;

	private System.Windows.Forms.TextBox txtSupplier;

	private System.Windows.Forms.TextBox txtCategory;

	private System.Windows.Forms.TextBox txtQuantityPerUnit;

	private System.Windows.Forms.TextBox txtUnitPrice;

	private System.Windows.Forms.TextBox txtUnitsInStock;

	private System.Windows.Forms.TextBox txtUnitsOnOrder;

	private System.Windows.Forms.TextBox txtReorderLevel;

	private System.Windows.Forms.TextBox txtDiscontinued;

	private System.Windows.Forms.Button btnFirst;

	private System.Windows.Forms.Button btnPrevious;

	private System.Windows.Forms.Button btnNext;

	private System.Windows.Forms.Button btnLast;

	private System.Windows.Forms.Label lblRecordNumber;

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

		this.Label6 = new System.Windows.Forms.Label();

		this.Label7 = new System.Windows.Forms.Label();

		this.Label8 = new System.Windows.Forms.Label();

		this.Label9 = new System.Windows.Forms.Label();

		this.Label10 = new System.Windows.Forms.Label();

		this.txtProductID = new System.Windows.Forms.TextBox();

		this.txtProductName = new System.Windows.Forms.TextBox();

		this.txtSupplier = new System.Windows.Forms.TextBox();

		this.txtCategory = new System.Windows.Forms.TextBox();

		this.txtQuantityPerUnit = new System.Windows.Forms.TextBox();

		this.txtUnitPrice = new System.Windows.Forms.TextBox();

		this.txtUnitsInStock = new System.Windows.Forms.TextBox();

		this.txtUnitsOnOrder = new System.Windows.Forms.TextBox();

		this.txtReorderLevel = new System.Windows.Forms.TextBox();

		this.txtDiscontinued = new System.Windows.Forms.TextBox();

		this.btnFirst = new System.Windows.Forms.Button();

		this.btnPrevious = new System.Windows.Forms.Button();

		this.btnNext = new System.Windows.Forms.Button();

		this.btnLast = new System.Windows.Forms.Button();

		this.lblRecordNumber = new System.Windows.Forms.Label();

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

		//

		//Label1

		//

		this.Label1.AccessibleDescription = (string) resources.GetObject("Label1.AccessibleDescription");

		this.Label1.AccessibleName = (string) resources.GetObject("Label1.AccessibleName");

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

		this.Label2.AccessibleDescription = (string) resources.GetObject("Label2.AccessibleDescription");

		this.Label2.AccessibleName = (string) resources.GetObject("Label2.AccessibleName");

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

		this.Label3.AccessibleDescription = (string) resources.GetObject("Label3.AccessibleDescription");

		this.Label3.AccessibleName = (string) resources.GetObject("Label3.AccessibleName");

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

		this.Label4.AccessibleDescription = (string) resources.GetObject("Label4.AccessibleDescription");

		this.Label4.AccessibleName = (string) resources.GetObject("Label4.AccessibleName");

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

		this.Label5.AccessibleDescription = (string) resources.GetObject("Label5.AccessibleDescription");

		this.Label5.AccessibleName = (string) resources.GetObject("Label5.AccessibleName");

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

		//Label6

		//

		this.Label6.AccessibleDescription = (string) resources.GetObject("Label6.AccessibleDescription");

		this.Label6.AccessibleName = (string) resources.GetObject("Label6.AccessibleName");

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

		//Label7

		//

		this.Label7.AccessibleDescription = (string) resources.GetObject("Label7.AccessibleDescription");

		this.Label7.AccessibleName = (string) resources.GetObject("Label7.AccessibleName");

		this.Label7.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label7.Anchor");

		this.Label7.AutoSize = (bool) resources.GetObject("Label7.AutoSize");

		this.Label7.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label7.Dock");

		this.Label7.Enabled = (bool) resources.GetObject("Label7.Enabled");

		this.Label7.Font = (System.Drawing.Font) resources.GetObject("Label7.Font");

		this.Label7.Image = (System.Drawing.Image) resources.GetObject("Label7.Image");

		this.Label7.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label7.ImageAlign");

		this.Label7.ImageIndex = (int) resources.GetObject("Label7.ImageIndex");

		this.Label7.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label7.ImeMode");

		this.Label7.Location = (System.Drawing.Point) resources.GetObject("Label7.Location");

		this.Label7.Name = "Label7";

		this.Label7.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label7.RightToLeft");

		this.Label7.Size = (System.Drawing.Size) resources.GetObject("Label7.Size");

		this.Label7.TabIndex = (int) resources.GetObject("Label7.TabIndex");

		this.Label7.Text = resources.GetString("Label7.Text");

		this.Label7.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label7.TextAlign");

		this.Label7.Visible = (bool) resources.GetObject("Label7.Visible");

		//

		//Label8

		//

		this.Label8.AccessibleDescription = (string) resources.GetObject("Label8.AccessibleDescription");

		this.Label8.AccessibleName = (string) resources.GetObject("Label8.AccessibleName");

		this.Label8.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label8.Anchor");

		this.Label8.AutoSize = (bool) resources.GetObject("Label8.AutoSize");

		this.Label8.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label8.Dock");

		this.Label8.Enabled = (bool) resources.GetObject("Label8.Enabled");

		this.Label8.Font = (System.Drawing.Font) resources.GetObject("Label8.Font");

		this.Label8.Image = (System.Drawing.Image) resources.GetObject("Label8.Image");

		this.Label8.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label8.ImageAlign");

		this.Label8.ImageIndex = (int) resources.GetObject("Label8.ImageIndex");

		this.Label8.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label8.ImeMode");

		this.Label8.Location = (System.Drawing.Point) resources.GetObject("Label8.Location");

		this.Label8.Name = "Label8";

		this.Label8.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label8.RightToLeft");

		this.Label8.Size = (System.Drawing.Size) resources.GetObject("Label8.Size");

		this.Label8.TabIndex = (int) resources.GetObject("Label8.TabIndex");

		this.Label8.Text = resources.GetString("Label8.Text");

		this.Label8.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label8.TextAlign");

		this.Label8.Visible = (bool) resources.GetObject("Label8.Visible");

		//

		//Label9

		//

		this.Label9.AccessibleDescription = (string) resources.GetObject("Label9.AccessibleDescription");

		this.Label9.AccessibleName = (string) resources.GetObject("Label9.AccessibleName");

		this.Label9.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label9.Anchor");

		this.Label9.AutoSize = (bool) resources.GetObject("Label9.AutoSize");

		this.Label9.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label9.Dock");

		this.Label9.Enabled = (bool) resources.GetObject("Label9.Enabled");

		this.Label9.Font = (System.Drawing.Font) resources.GetObject("Label9.Font");

		this.Label9.Image = (System.Drawing.Image) resources.GetObject("Label9.Image");

		this.Label9.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label9.ImageAlign");

		this.Label9.ImageIndex = (int) resources.GetObject("Label9.ImageIndex");

		this.Label9.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label9.ImeMode");

		this.Label9.Location = (System.Drawing.Point) resources.GetObject("Label9.Location");

		this.Label9.Name = "Label9";

		this.Label9.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label9.RightToLeft");

		this.Label9.Size = (System.Drawing.Size) resources.GetObject("Label9.Size");

		this.Label9.TabIndex = (int) resources.GetObject("Label9.TabIndex");

		this.Label9.Text = resources.GetString("Label9.Text");

		this.Label9.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label9.TextAlign");

		this.Label9.Visible = (bool) resources.GetObject("Label9.Visible");

		//

		//Label10

		//

		this.Label10.AccessibleDescription = (string) resources.GetObject("Label10.AccessibleDescription");

		this.Label10.AccessibleName = (string) resources.GetObject("Label10.AccessibleName");

		this.Label10.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label10.Anchor");

		this.Label10.AutoSize = (bool) resources.GetObject("Label10.AutoSize");

		this.Label10.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label10.Dock");

		this.Label10.Enabled = (bool) resources.GetObject("Label10.Enabled");

		this.Label10.Font = (System.Drawing.Font) resources.GetObject("Label10.Font");

		this.Label10.Image = (System.Drawing.Image) resources.GetObject("Label10.Image");

		this.Label10.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label10.ImageAlign");

		this.Label10.ImageIndex = (int) resources.GetObject("Label10.ImageIndex");

		this.Label10.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label10.ImeMode");

		this.Label10.Location = (System.Drawing.Point) resources.GetObject("Label10.Location");

		this.Label10.Name = "Label10";

		this.Label10.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label10.RightToLeft");

		this.Label10.Size = (System.Drawing.Size) resources.GetObject("Label10.Size");

		this.Label10.TabIndex = (int) resources.GetObject("Label10.TabIndex");

		this.Label10.Text = resources.GetString("Label10.Text");

		this.Label10.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label10.TextAlign");

		this.Label10.Visible = (bool) resources.GetObject("Label10.Visible");

		//

		//txtProductID

		//

		this.txtProductID.AccessibleDescription = (string) resources.GetObject("txtProductID.AccessibleDescription");

		this.txtProductID.AccessibleName = (string) resources.GetObject("txtProductID.AccessibleName");

		this.txtProductID.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtProductID.Anchor");

		this.txtProductID.AutoSize = (bool) resources.GetObject("txtProductID.AutoSize");

		this.txtProductID.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtProductID.BackgroundImage");

		this.txtProductID.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtProductID.Dock");

		this.txtProductID.Enabled = (bool) resources.GetObject("txtProductID.Enabled");

		this.txtProductID.Font = (System.Drawing.Font) resources.GetObject("txtProductID.Font");

		this.txtProductID.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtProductID.ImeMode");

		this.txtProductID.Location = (System.Drawing.Point) resources.GetObject("txtProductID.Location");

		this.txtProductID.MaxLength = (int) resources.GetObject("txtProductID.MaxLength");

		this.txtProductID.Multiline = (bool) resources.GetObject("txtProductID.Multiline");

		this.txtProductID.Name = "txtProductID";

		this.txtProductID.PasswordChar = (char) resources.GetObject("txtProductID.PasswordChar");

		this.txtProductID.ReadOnly = true;

		this.txtProductID.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtProductID.RightToLeft");

		this.txtProductID.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtProductID.ScrollBars");

		this.txtProductID.Size = (System.Drawing.Size) resources.GetObject("txtProductID.Size");

		this.txtProductID.TabIndex = (int) resources.GetObject("txtProductID.TabIndex");

		this.txtProductID.Text = resources.GetString("txtProductID.Text");

		this.txtProductID.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtProductID.TextAlign");

		this.txtProductID.Visible = (bool) resources.GetObject("txtProductID.Visible");

		this.txtProductID.WordWrap = (bool) resources.GetObject("txtProductID.WordWrap");

		//

		//txtProductName

		//

		this.txtProductName.AccessibleDescription = (string) resources.GetObject("txtProductName.AccessibleDescription");

		this.txtProductName.AccessibleName = (string) resources.GetObject("txtProductName.AccessibleName");

		this.txtProductName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtProductName.Anchor");

		this.txtProductName.AutoSize = (bool) resources.GetObject("txtProductName.AutoSize");

		this.txtProductName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtProductName.BackgroundImage");

		this.txtProductName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtProductName.Dock");

		this.txtProductName.Enabled = (bool) resources.GetObject("txtProductName.Enabled");

		this.txtProductName.Font = (System.Drawing.Font) resources.GetObject("txtProductName.Font");

		this.txtProductName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtProductName.ImeMode");

		this.txtProductName.Location = (System.Drawing.Point) resources.GetObject("txtProductName.Location");

		this.txtProductName.MaxLength = (int) resources.GetObject("txtProductName.MaxLength");

		this.txtProductName.Multiline = (bool) resources.GetObject("txtProductName.Multiline");

		this.txtProductName.Name = "txtProductName";

		this.txtProductName.PasswordChar = (char) resources.GetObject("txtProductName.PasswordChar");

		this.txtProductName.ReadOnly = true;

		this.txtProductName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtProductName.RightToLeft");

		this.txtProductName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtProductName.ScrollBars");

		this.txtProductName.Size = (System.Drawing.Size) resources.GetObject("txtProductName.Size");

		this.txtProductName.TabIndex = (int) resources.GetObject("txtProductName.TabIndex");

		this.txtProductName.Text = resources.GetString("txtProductName.Text");

		this.txtProductName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtProductName.TextAlign");

		this.txtProductName.Visible = (bool) resources.GetObject("txtProductName.Visible");

		this.txtProductName.WordWrap = (bool) resources.GetObject("txtProductName.WordWrap");

		//

		//txtSupplier

		//

		this.txtSupplier.AccessibleDescription = (string) resources.GetObject("txtSupplier.AccessibleDescription");

		this.txtSupplier.AccessibleName = (string) resources.GetObject("txtSupplier.AccessibleName");

		this.txtSupplier.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtSupplier.Anchor");

		this.txtSupplier.AutoSize = (bool) resources.GetObject("txtSupplier.AutoSize");

		this.txtSupplier.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtSupplier.BackgroundImage");

		this.txtSupplier.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtSupplier.Dock");

		this.txtSupplier.Enabled = (bool) resources.GetObject("txtSupplier.Enabled");

		this.txtSupplier.Font = (System.Drawing.Font) resources.GetObject("txtSupplier.Font");

		this.txtSupplier.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtSupplier.ImeMode");

		this.txtSupplier.Location = (System.Drawing.Point) resources.GetObject("txtSupplier.Location");

		this.txtSupplier.MaxLength = (int) resources.GetObject("txtSupplier.MaxLength");

		this.txtSupplier.Multiline = (bool) resources.GetObject("txtSupplier.Multiline");

		this.txtSupplier.Name = "txtSupplier";

		this.txtSupplier.PasswordChar = (char) resources.GetObject("txtSupplier.PasswordChar");

		this.txtSupplier.ReadOnly = true;

		this.txtSupplier.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtSupplier.RightToLeft");

		this.txtSupplier.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtSupplier.ScrollBars");

		this.txtSupplier.Size = (System.Drawing.Size) resources.GetObject("txtSupplier.Size");

		this.txtSupplier.TabIndex = (int) resources.GetObject("txtSupplier.TabIndex");

		this.txtSupplier.Text = resources.GetString("txtSupplier.Text");

		this.txtSupplier.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtSupplier.TextAlign");

		this.txtSupplier.Visible = (bool) resources.GetObject("txtSupplier.Visible");

		this.txtSupplier.WordWrap = (bool) resources.GetObject("txtSupplier.WordWrap");

		//

		//txtCategory

		//

		this.txtCategory.AccessibleDescription = (string) resources.GetObject("txtCategory.AccessibleDescription");

		this.txtCategory.AccessibleName = (string) resources.GetObject("txtCategory.AccessibleName");

		this.txtCategory.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCategory.Anchor");

		this.txtCategory.AutoSize = (bool) resources.GetObject("txtCategory.AutoSize");

		this.txtCategory.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCategory.BackgroundImage");

		this.txtCategory.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCategory.Dock");

		this.txtCategory.Enabled = (bool) resources.GetObject("txtCategory.Enabled");

		this.txtCategory.Font = (System.Drawing.Font) resources.GetObject("txtCategory.Font");

		this.txtCategory.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCategory.ImeMode");

		this.txtCategory.Location = (System.Drawing.Point) resources.GetObject("txtCategory.Location");

		this.txtCategory.MaxLength = (int) resources.GetObject("txtCategory.MaxLength");

		this.txtCategory.Multiline = (bool) resources.GetObject("txtCategory.Multiline");

		this.txtCategory.Name = "txtCategory";

		this.txtCategory.PasswordChar = (char) resources.GetObject("txtCategory.PasswordChar");

		this.txtCategory.ReadOnly = true;

		this.txtCategory.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCategory.RightToLeft");

		this.txtCategory.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCategory.ScrollBars");

		this.txtCategory.Size = (System.Drawing.Size) resources.GetObject("txtCategory.Size");

		this.txtCategory.TabIndex = (int) resources.GetObject("txtCategory.TabIndex");

		this.txtCategory.Text = resources.GetString("txtCategory.Text");

		this.txtCategory.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCategory.TextAlign");

		this.txtCategory.Visible = (bool) resources.GetObject("txtCategory.Visible");

		this.txtCategory.WordWrap = (bool) resources.GetObject("txtCategory.WordWrap");

		//

		//txtQuantityPerUnit

		//

		this.txtQuantityPerUnit.AccessibleDescription = (string) resources.GetObject("txtQuantityPerUnit.AccessibleDescription");

		this.txtQuantityPerUnit.AccessibleName = (string) resources.GetObject("txtQuantityPerUnit.AccessibleName");

		this.txtQuantityPerUnit.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtQuantityPerUnit.Anchor");

		this.txtQuantityPerUnit.AutoSize = (bool) resources.GetObject("txtQuantityPerUnit.AutoSize");

		this.txtQuantityPerUnit.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtQuantityPerUnit.BackgroundImage");

		this.txtQuantityPerUnit.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtQuantityPerUnit.Dock");

		this.txtQuantityPerUnit.Enabled = (bool) resources.GetObject("txtQuantityPerUnit.Enabled");

		this.txtQuantityPerUnit.Font = (System.Drawing.Font) resources.GetObject("txtQuantityPerUnit.Font");

		this.txtQuantityPerUnit.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtQuantityPerUnit.ImeMode");

		this.txtQuantityPerUnit.Location = (System.Drawing.Point) resources.GetObject("txtQuantityPerUnit.Location");

		this.txtQuantityPerUnit.MaxLength = (int) resources.GetObject("txtQuantityPerUnit.MaxLength");

		this.txtQuantityPerUnit.Multiline = (bool) resources.GetObject("txtQuantityPerUnit.Multiline");

		this.txtQuantityPerUnit.Name = "txtQuantityPerUnit";

		this.txtQuantityPerUnit.PasswordChar = (char) resources.GetObject("txtQuantityPerUnit.PasswordChar");

		this.txtQuantityPerUnit.ReadOnly = true;

		this.txtQuantityPerUnit.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtQuantityPerUnit.RightToLeft");

		this.txtQuantityPerUnit.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtQuantityPerUnit.ScrollBars");

		this.txtQuantityPerUnit.Size = (System.Drawing.Size) resources.GetObject("txtQuantityPerUnit.Size");

		this.txtQuantityPerUnit.TabIndex = (int) resources.GetObject("txtQuantityPerUnit.TabIndex");

		this.txtQuantityPerUnit.Text = resources.GetString("txtQuantityPerUnit.Text");

		this.txtQuantityPerUnit.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtQuantityPerUnit.TextAlign");

		this.txtQuantityPerUnit.Visible = (bool) resources.GetObject("txtQuantityPerUnit.Visible");

		this.txtQuantityPerUnit.WordWrap = (bool) resources.GetObject("txtQuantityPerUnit.WordWrap");

		//

		//txtUnitPrice

		//

		this.txtUnitPrice.AccessibleDescription = (string) resources.GetObject("txtUnitPrice.AccessibleDescription");

		this.txtUnitPrice.AccessibleName = (string) resources.GetObject("txtUnitPrice.AccessibleName");

		this.txtUnitPrice.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtUnitPrice.Anchor");

		this.txtUnitPrice.AutoSize = (bool) resources.GetObject("txtUnitPrice.AutoSize");

		this.txtUnitPrice.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtUnitPrice.BackgroundImage");

		this.txtUnitPrice.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtUnitPrice.Dock");

		this.txtUnitPrice.Enabled = (bool) resources.GetObject("txtUnitPrice.Enabled");

		this.txtUnitPrice.Font = (System.Drawing.Font) resources.GetObject("txtUnitPrice.Font");

		this.txtUnitPrice.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtUnitPrice.ImeMode");

		this.txtUnitPrice.Location = (System.Drawing.Point) resources.GetObject("txtUnitPrice.Location");

		this.txtUnitPrice.MaxLength = (int) resources.GetObject("txtUnitPrice.MaxLength");

		this.txtUnitPrice.Multiline = (bool) resources.GetObject("txtUnitPrice.Multiline");

		this.txtUnitPrice.Name = "txtUnitPrice";

		this.txtUnitPrice.PasswordChar = (char) resources.GetObject("txtUnitPrice.PasswordChar");

		this.txtUnitPrice.ReadOnly = true;

		this.txtUnitPrice.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtUnitPrice.RightToLeft");

		this.txtUnitPrice.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtUnitPrice.ScrollBars");

		this.txtUnitPrice.Size = (System.Drawing.Size) resources.GetObject("txtUnitPrice.Size");

		this.txtUnitPrice.TabIndex = (int) resources.GetObject("txtUnitPrice.TabIndex");

		this.txtUnitPrice.Text = resources.GetString("txtUnitPrice.Text");

		this.txtUnitPrice.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtUnitPrice.TextAlign");

		this.txtUnitPrice.Visible = (bool) resources.GetObject("txtUnitPrice.Visible");

		this.txtUnitPrice.WordWrap = (bool) resources.GetObject("txtUnitPrice.WordWrap");

		//

		//txtUnitsInStock

		//

		this.txtUnitsInStock.AccessibleDescription = (string) resources.GetObject("txtUnitsInStock.AccessibleDescription");

		this.txtUnitsInStock.AccessibleName = (string) resources.GetObject("txtUnitsInStock.AccessibleName");

		this.txtUnitsInStock.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtUnitsInStock.Anchor");

		this.txtUnitsInStock.AutoSize = (bool) resources.GetObject("txtUnitsInStock.AutoSize");

		this.txtUnitsInStock.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtUnitsInStock.BackgroundImage");

		this.txtUnitsInStock.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtUnitsInStock.Dock");

		this.txtUnitsInStock.Enabled = (bool) resources.GetObject("txtUnitsInStock.Enabled");

		this.txtUnitsInStock.Font = (System.Drawing.Font) resources.GetObject("txtUnitsInStock.Font");

		this.txtUnitsInStock.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtUnitsInStock.ImeMode");

		this.txtUnitsInStock.Location = (System.Drawing.Point) resources.GetObject("txtUnitsInStock.Location");

		this.txtUnitsInStock.MaxLength = (int) resources.GetObject("txtUnitsInStock.MaxLength");

		this.txtUnitsInStock.Multiline = (bool) resources.GetObject("txtUnitsInStock.Multiline");

		this.txtUnitsInStock.Name = "txtUnitsInStock";

		this.txtUnitsInStock.PasswordChar = (char) resources.GetObject("txtUnitsInStock.PasswordChar");

		this.txtUnitsInStock.ReadOnly = true;

		this.txtUnitsInStock.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtUnitsInStock.RightToLeft");

		this.txtUnitsInStock.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtUnitsInStock.ScrollBars");

		this.txtUnitsInStock.Size = (System.Drawing.Size) resources.GetObject("txtUnitsInStock.Size");

		this.txtUnitsInStock.TabIndex = (int) resources.GetObject("txtUnitsInStock.TabIndex");

		this.txtUnitsInStock.Text = resources.GetString("txtUnitsInStock.Text");

		this.txtUnitsInStock.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtUnitsInStock.TextAlign");

		this.txtUnitsInStock.Visible = (bool) resources.GetObject("txtUnitsInStock.Visible");

		this.txtUnitsInStock.WordWrap = (bool) resources.GetObject("txtUnitsInStock.WordWrap");

		//

		//txtUnitsOnOrder

		//

		this.txtUnitsOnOrder.AccessibleDescription = (string) resources.GetObject("txtUnitsOnOrder.AccessibleDescription");

		this.txtUnitsOnOrder.AccessibleName = (string) resources.GetObject("txtUnitsOnOrder.AccessibleName");

		this.txtUnitsOnOrder.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtUnitsOnOrder.Anchor");

		this.txtUnitsOnOrder.AutoSize = (bool) resources.GetObject("txtUnitsOnOrder.AutoSize");

		this.txtUnitsOnOrder.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtUnitsOnOrder.BackgroundImage");

		this.txtUnitsOnOrder.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtUnitsOnOrder.Dock");

		this.txtUnitsOnOrder.Enabled = (bool) resources.GetObject("txtUnitsOnOrder.Enabled");

		this.txtUnitsOnOrder.Font = (System.Drawing.Font) resources.GetObject("txtUnitsOnOrder.Font");

		this.txtUnitsOnOrder.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtUnitsOnOrder.ImeMode");

		this.txtUnitsOnOrder.Location = (System.Drawing.Point) resources.GetObject("txtUnitsOnOrder.Location");

		this.txtUnitsOnOrder.MaxLength = (int) resources.GetObject("txtUnitsOnOrder.MaxLength");

		this.txtUnitsOnOrder.Multiline = (bool) resources.GetObject("txtUnitsOnOrder.Multiline");

		this.txtUnitsOnOrder.Name = "txtUnitsOnOrder";

		this.txtUnitsOnOrder.PasswordChar = (char) resources.GetObject("txtUnitsOnOrder.PasswordChar");

		this.txtUnitsOnOrder.ReadOnly = true;

		this.txtUnitsOnOrder.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtUnitsOnOrder.RightToLeft");

		this.txtUnitsOnOrder.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtUnitsOnOrder.ScrollBars");

		this.txtUnitsOnOrder.Size = (System.Drawing.Size) resources.GetObject("txtUnitsOnOrder.Size");

		this.txtUnitsOnOrder.TabIndex = (int) resources.GetObject("txtUnitsOnOrder.TabIndex");

		this.txtUnitsOnOrder.Text = resources.GetString("txtUnitsOnOrder.Text");

		this.txtUnitsOnOrder.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtUnitsOnOrder.TextAlign");

		this.txtUnitsOnOrder.Visible = (bool) resources.GetObject("txtUnitsOnOrder.Visible");

		this.txtUnitsOnOrder.WordWrap = (bool) resources.GetObject("txtUnitsOnOrder.WordWrap");

		//

		//txtReorderLevel

		//

		this.txtReorderLevel.AccessibleDescription = (string) resources.GetObject("txtReorderLevel.AccessibleDescription");

		this.txtReorderLevel.AccessibleName = (string) resources.GetObject("txtReorderLevel.AccessibleName");

		this.txtReorderLevel.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtReorderLevel.Anchor");

		this.txtReorderLevel.AutoSize = (bool) resources.GetObject("txtReorderLevel.AutoSize");

		this.txtReorderLevel.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtReorderLevel.BackgroundImage");

		this.txtReorderLevel.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtReorderLevel.Dock");

		this.txtReorderLevel.Enabled = (bool) resources.GetObject("txtReorderLevel.Enabled");

		this.txtReorderLevel.Font = (System.Drawing.Font) resources.GetObject("txtReorderLevel.Font");

		this.txtReorderLevel.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtReorderLevel.ImeMode");

		this.txtReorderLevel.Location = (System.Drawing.Point) resources.GetObject("txtReorderLevel.Location");

		this.txtReorderLevel.MaxLength = (int) resources.GetObject("txtReorderLevel.MaxLength");

		this.txtReorderLevel.Multiline = (bool) resources.GetObject("txtReorderLevel.Multiline");

		this.txtReorderLevel.Name = "txtReorderLevel";

		this.txtReorderLevel.PasswordChar = (char) resources.GetObject("txtReorderLevel.PasswordChar");

		this.txtReorderLevel.ReadOnly = true;

		this.txtReorderLevel.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtReorderLevel.RightToLeft");

		this.txtReorderLevel.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtReorderLevel.ScrollBars");

		this.txtReorderLevel.Size = (System.Drawing.Size) resources.GetObject("txtReorderLevel.Size");

		this.txtReorderLevel.TabIndex = (int) resources.GetObject("txtReorderLevel.TabIndex");

		this.txtReorderLevel.Text = resources.GetString("txtReorderLevel.Text");

		this.txtReorderLevel.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtReorderLevel.TextAlign");

		this.txtReorderLevel.Visible = (bool) resources.GetObject("txtReorderLevel.Visible");

		this.txtReorderLevel.WordWrap = (bool) resources.GetObject("txtReorderLevel.WordWrap");

		//

		//txtDiscontinued

		//

		this.txtDiscontinued.AccessibleDescription = (string) resources.GetObject("txtDiscontinued.AccessibleDescription");

		this.txtDiscontinued.AccessibleName = (string) resources.GetObject("txtDiscontinued.AccessibleName");

		this.txtDiscontinued.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtDiscontinued.Anchor");

		this.txtDiscontinued.AutoSize = (bool) resources.GetObject("txtDiscontinued.AutoSize");

		this.txtDiscontinued.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtDiscontinued.BackgroundImage");

		this.txtDiscontinued.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtDiscontinued.Dock");

		this.txtDiscontinued.Enabled = (bool) resources.GetObject("txtDiscontinued.Enabled");

		this.txtDiscontinued.Font = (System.Drawing.Font) resources.GetObject("txtDiscontinued.Font");

		this.txtDiscontinued.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtDiscontinued.ImeMode");

		this.txtDiscontinued.Location = (System.Drawing.Point) resources.GetObject("txtDiscontinued.Location");

		this.txtDiscontinued.MaxLength = (int) resources.GetObject("txtDiscontinued.MaxLength");

		this.txtDiscontinued.Multiline = (bool) resources.GetObject("txtDiscontinued.Multiline");

		this.txtDiscontinued.Name = "txtDiscontinued";

		this.txtDiscontinued.PasswordChar = (char) resources.GetObject("txtDiscontinued.PasswordChar");

		this.txtDiscontinued.ReadOnly = true;

		this.txtDiscontinued.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtDiscontinued.RightToLeft");

		this.txtDiscontinued.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtDiscontinued.ScrollBars");

		this.txtDiscontinued.Size = (System.Drawing.Size) resources.GetObject("txtDiscontinued.Size");

		this.txtDiscontinued.TabIndex = (int) resources.GetObject("txtDiscontinued.TabIndex");

		this.txtDiscontinued.Text = resources.GetString("txtDiscontinued.Text");

		this.txtDiscontinued.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtDiscontinued.TextAlign");

		this.txtDiscontinued.Visible = (bool) resources.GetObject("txtDiscontinued.Visible");

		this.txtDiscontinued.WordWrap = (bool) resources.GetObject("txtDiscontinued.WordWrap");

		//

		//btnFirst

		//

		this.btnFirst.AccessibleDescription = (string) resources.GetObject("btnFirst.AccessibleDescription");

		this.btnFirst.AccessibleName = (string) resources.GetObject("btnFirst.AccessibleName");

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

		//

		//btnPrevious

		//

		this.btnPrevious.AccessibleDescription = (string) resources.GetObject("btnPrevious.AccessibleDescription");

		this.btnPrevious.AccessibleName = (string) resources.GetObject("btnPrevious.AccessibleName");

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

		//

		//btnNext

		//

		this.btnNext.AccessibleDescription = (string) resources.GetObject("btnNext.AccessibleDescription");

		this.btnNext.AccessibleName = (string) resources.GetObject("btnNext.AccessibleName");

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

		//

		//btnLast

		//

		this.btnLast.AccessibleDescription = (string) resources.GetObject("btnLast.AccessibleDescription");

		this.btnLast.AccessibleName = (string) resources.GetObject("btnLast.AccessibleName");

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

		//

		//lblRecordNumber

		//

		this.lblRecordNumber.AccessibleDescription = (string) resources.GetObject("lblRecordNumber.AccessibleDescription");

		this.lblRecordNumber.AccessibleName = (string) resources.GetObject("lblRecordNumber.AccessibleName");

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

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblRecordNumber, this.btnLast, this.btnNext, this.btnPrevious, this.btnFirst, this.txtDiscontinued, this.txtReorderLevel, this.txtUnitsOnOrder, this.txtUnitsInStock, this.txtUnitPrice, this.txtQuantityPerUnit, this.txtCategory, this.txtSupplier, this.txtProductName, this.txtProductID, this.Label10, this.Label9, this.Label8, this.Label7, this.Label6, this.Label5, this.Label4, this.Label3, this.Label2, this.Label1});

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

		this.ResumeLayout(false);

		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.btnFirst.Click +=new EventHandler(btnFirst_Click);
		this.btnLast.Click +=new EventHandler(btnLast_Click);
		this.btnNext.Click +=new EventHandler(btnNext_Click);
		this.btnPrevious.Click +=new EventHandler(btnPrevious_Click);
		base.KeyDown +=new KeyEventHandler(frmMain_KeyDown);
		this.Load +=new EventHandler(frmMain_Load);

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

	// When databinding to a boolean value, this converts the true/false to

	// a yes/no string.

	protected void boolToYesNo(object sender, ConvertEventArgs e)
	{

		// The method converts only to string type. Test this using the DesiredType.

		if (e.DesiredType != typeof(string)) 
		{
			return;
		}

		// if the value is "true", convert to "Yes", otherwise "No"

		if (((bool)(e.Value)) == true) 
		{
			e.Value = "Yes";
		}
		else
		{
			e.Value = "No";
		}

	}

	protected void DecimalToCurrencystring(object sender, ConvertEventArgs e)
	{

		// The method converts only to string type. Test this using the DesiredType.

		if (e.DesiredType != typeof(string)) 
		{
			return;
		}

		// Use the Tostring method to format the value currency ("c").

		e.Value = ((Decimal)(e.Value)).ToString("c");

	}

	// Move Back 10 records

	public void Back10()
	{

		// The position of the binding context controls the "current record"

		this.BindingContext[productInfo.Products].Position -= 10;

	}

	// Move to the first record

	public void FirstRecord()
	{
		// The position of the binding context controls the "current record"

		// Position the first record is record 0 (! 1).

		this.BindingContext[productInfo.Products].Position = 0;

	}

	// Move forward 10 records

	public void Forward10()
	{

		// The position of the binding context controls the "current record"

		this.BindingContext[productInfo.Products].Position += 10;

	}

	// Move to the last record

	public void LastRecord()
	{

		// The position of the binding context controls the "current record". 
		// Use productInfo.Products.Count to figure out the total number of 
		// records.  -1 because position is zero based.

		this.BindingContext[productInfo.Products].Position =
			productInfo.Products.Count - 1;

	}

	// Move to the next record

	public void NextRecord()
	{

		// The position of the binding context controls the "current record"

		this.BindingContext[productInfo.Products].Position += 1;

	}

	// Move to the previous record

	public void PreviousRecord()
	{

		// The position of the binding context controls the "current record"

		this.BindingContext[productInfo.Products].Position -= 1;

	}

	// Output the number of the current record

	protected void ShowCurrentRecord()
	{

		// The position  of the binding context contains the current record.
		// +1 so that the first record displays record 1 (instead of 0).
		// productInfo.Products.Count gives the total number of records.

		lblRecordNumber.Text = "Record " +
			(this.BindingContext[productInfo.Products].Position + 1).ToString()
			+ " of " + productInfo.Products.Count;

	}

	private void btnFirst_Click(object sender, System.EventArgs e) 
	{	
		// Move to the first record

		FirstRecord();

	}

	private void btnLast_Click(object sender, System.EventArgs e) 
	{
		// Move to the last record

		LastRecord();

	}

	private void btnNext_Click(object sender, System.EventArgs e) 
	{
		// Move to the next record

		NextRecord();

	}

	private void btnPrevious_Click(object sender, System.EventArgs e) 
	{
		// Move to the previous record

		PreviousRecord();

	}

	private void frmMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) 
	{
		// Let the user scroll through the records using the cursor keys.
		// Left and right are next and previous.
		// Home and end are first and last.

		if (e.KeyCode == Keys.Right) { NextRecord();}
		if (e.KeyCode == Keys.Left) { PreviousRecord();}
		if (e.KeyCode == Keys.Home) { FirstRecord();}
		if (e.KeyCode == Keys.End) { LastRecord();}
		if (e.KeyCode == Keys.PageDown) { Forward10();}
		if (e.KeyCode == Keys.PageUp) { Back10();}

	}

	static string Connectionstring = SQL_CONNECTION_STRING;

	static bool DidPreviouslyConnect = false;

	private void frmMain_Load(object sender, System.EventArgs e) 
	{

		// Display a status message saying that we're attempting to connect.
		// This only needs to be done the very first time a connection is
		// attempted.  After we've determined that MSDE or SQL Server is
		// installed, this message no longer needs to be displayed.

		frmStatus frmStatusMessage = new frmStatus();

		if (!DidPreviouslyConnect) 
		{

			frmStatusMessage.Show("Connecting to SQL Server");

		}

		// Attempt to connect to the local SQL server instance, and a local
		// MSDE installation (with Northwind).  

		bool IsConnecting = true;

		while (IsConnecting)
		{

			try 
			{

				// The SqlConnection class allows you to communicate with SQL Server.
				// The constructor accepts a connection string an argument.  This
				// connection string uses Integrated Security, which means that you 
				// must have a login in SQL Server, or be part of the Administrators
				// group for this to work.

				SqlConnection northwindConnection = new SqlConnection(Connectionstring);

				// This select statement retrieves all the products, and looks up the
				// associated CategoryName, and SupplierName for each product.

				string selectCommand =
					"SELECT Products.ProductID, Products.ProductName, " +
					"Products.SupplierID, Products.CategoryID, " +
					"Products.QuantityPerUnit, Products.UnitPrice, " +
					"Products.UnitsInStock, Products.UnitsOnOrder, " +
					"Products.ReorderLevel, Products.Discontinued, " +
					"Suppliers.CompanyName AS SupplierName, " +
					"Categories.CategoryName " +
					"FROM Products INNER JOIN " + 
					"Suppliers ON Products.SupplierID = Suppliers.SupplierID INNER JOIN " +
					"Categories ON Products.CategoryID = Categories.CategoryID";

				// The SqlDataAdapter will actually issue the command to the database.

				SqlDataAdapter productAdapter =  new SqlDataAdapter(selectCommand, northwindConnection);

				// At this point, the 

				productAdapter.Fill(productInfo.Products);
				txtProductID.DataBindings.Add("Text", productInfo.Products, "ProductID");
				txtProductName.DataBindings.Add("Text", productInfo.Products, "ProductName");
				txtSupplier.DataBindings.Add("Text", productInfo.Products, "SupplierName");
				txtCategory.DataBindings.Add("Text", productInfo.Products, "CategoryName");
				txtQuantityPerUnit.DataBindings.Add("Text", productInfo.Products, "QuantityPerUnit");
				txtUnitsInStock.DataBindings.Add("Text", productInfo.Products, "UnitsInStock");
				txtUnitsOnOrder.DataBindings.Add("Text", productInfo.Products, "UnitsOnOrder");
				txtReorderLevel.DataBindings.Add("Text", productInfo.Products, "ReorderLevel");
				Binding UnitPriceBinding = new Binding("Text", productInfo.Products, "UnitPrice");
				UnitPriceBinding.Format += new System.Windows.Forms.ConvertEventHandler(DecimalToCurrencystring);
				txtUnitPrice.DataBindings.Add(UnitPriceBinding);
				Binding DiscontinuedBinding =new Binding("Text", productInfo.Products, "Discontinued");
				DiscontinuedBinding.Format += new System.Windows.Forms.ConvertEventHandler(boolToYesNo);
				txtDiscontinued.DataBindings.Add(DiscontinuedBinding);

				this.BindingContext[productInfo.Products].PositionChanged +=
					new System.EventHandler(ProductInfo_PositionChanged);

				// Data has been successfully retrieved, so break out of the loop.

				IsConnecting = false;

				DidPreviouslyConnect = true;

			} 
			catch
			{
				if (Connectionstring == SQL_CONNECTION_STRING) 
				{

					// Couldn't connect to SQL Server.  Now try MSDE.
					Connectionstring = MSDE_CONNECTION_STRING;
					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{
					// Unable to connect to SQL Server or MSDE
					frmStatusMessage.Close();
					MessageBox.Show("To run this sample, you must have SQL " +
						"or MSDE with the Northwind database installed.  For " +
						"instructions on installing MSDE, view the ReadMe file.");

					Application.Exit();

				}

			}

		}

		frmStatusMessage.Close();

		ShowCurrentRecord();

	}

	protected void ProductInfo_PositionChanged(object sender, System.EventArgs e)
	{

		ShowCurrentRecord();

	}

}

