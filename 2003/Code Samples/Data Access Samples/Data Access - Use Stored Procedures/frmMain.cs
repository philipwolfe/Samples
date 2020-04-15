//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System;


public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}


    // Initialize constants for connecting to the database
    // and displaying a connection error to the user.

    protected const string SQL_CONNECTION_STRING  =
													"Server=localhost;" + 
													"DataBase=Northwind;" + 
													"Integrated Security=SSPI";

    protected const string MSDE_CONNECTION_STRING  = 
													@"Server=(local)\NetSDK;" + 
													"DataBase=Northwind;" + 
													"Integrated Security=SSPI";

    // Change the path to the Northwind database, needed. if you get a runtime 
    // error that the database can! be found, make sure you have installed
    // the Northwind database. See the Readme for more information.

    protected const string ACCESS_CONNECTION_STRING  = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\Northwind.mdb";

    protected const string CONNECTION_ERROR_MSG  = 
													"To run this sample, you must have SQL " + 
													"or MSDE with the Northwind database installed.  For " + 
													"instructions on installing MSDE, view the ReadMe file.";

    protected bool DidPreviouslyConnect  = false;

    protected bool HasCreatedSprocs  = false;

    protected string strConn;

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

    private System.Windows.Forms.TabControl tabApp;

    private System.Windows.Forms.TabPage pgeCreateSprocs;

    private System.Windows.Forms.TabPage pgeNoParams;

    private System.Windows.Forms.TabPage pgeInputParam;

    private System.Windows.Forms.TabPage pgeMSAccess;

    private System.Windows.Forms.Button btnCreateSprocs;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.DataGrid grdProducts;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Button btnGet10MostExpProds;

    private System.Windows.Forms.TextBox txtTenMostExpProds;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.Button btnGetProducts;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.Button btnGetProductCountAndAvgPrice;

    private System.Windows.Forms.Label lblProductCountAndAvgPrice;

    private System.Windows.Forms.Label Label7;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.TextBox txtBeginningDate;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.Label Label10;

    private System.Windows.Forms.TextBox txtEndingDate;

    private System.Windows.Forms.Button btnCreateReport;

    private System.Windows.Forms.DataGrid grdSales;

    private System.Windows.Forms.Label lblNoSales;

    private System.Windows.Forms.TabPage pgeAllTypes;

    private System.Windows.Forms.ComboBox cboCategoriesInputParam;

    private System.Windows.Forms.ComboBox cboCategoriesAllTypes;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.tabApp = new System.Windows.Forms.TabControl();

        this.pgeCreateSprocs = new System.Windows.Forms.TabPage();

        this.Label2 = new System.Windows.Forms.Label();

        this.btnCreateSprocs = new System.Windows.Forms.Button();

        this.pgeNoParams = new System.Windows.Forms.TabPage();

        this.txtTenMostExpProds = new System.Windows.Forms.TextBox();

        this.Label1 = new System.Windows.Forms.Label();

        this.btnGet10MostExpProds = new System.Windows.Forms.Button();

        this.pgeInputParam = new System.Windows.Forms.TabPage();

        this.Label4 = new System.Windows.Forms.Label();

        this.grdProducts = new System.Windows.Forms.DataGrid();

        this.btnGetProducts = new System.Windows.Forms.Button();

        this.cboCategoriesInputParam = new System.Windows.Forms.ComboBox();

        this.Label3 = new System.Windows.Forms.Label();

        this.pgeAllTypes = new System.Windows.Forms.TabPage();

        this.lblProductCountAndAvgPrice = new System.Windows.Forms.Label();

        this.Label5 = new System.Windows.Forms.Label();

        this.btnGetProductCountAndAvgPrice = new System.Windows.Forms.Button();

        this.cboCategoriesAllTypes = new System.Windows.Forms.ComboBox();

        this.Label6 = new System.Windows.Forms.Label();

        this.pgeMSAccess = new System.Windows.Forms.TabPage();

        this.btnCreateReport = new System.Windows.Forms.Button();

        this.txtEndingDate = new System.Windows.Forms.TextBox();

        this.Label10 = new System.Windows.Forms.Label();

        this.Label9 = new System.Windows.Forms.Label();

        this.txtBeginningDate = new System.Windows.Forms.TextBox();

        this.Label8 = new System.Windows.Forms.Label();

        this.grdSales = new System.Windows.Forms.DataGrid();

        this.lblNoSales = new System.Windows.Forms.Label();

        this.Label7 = new System.Windows.Forms.Label();

        this.tabApp.SuspendLayout();

        this.pgeCreateSprocs.SuspendLayout();

        this.pgeNoParams.SuspendLayout();

        this.pgeInputParam.SuspendLayout();

		((System.ComponentModel.ISupportInitialize) this.grdProducts).BeginInit();

        this.pgeAllTypes.SuspendLayout();

        this.pgeMSAccess.SuspendLayout();

        ((System.ComponentModel.ISupportInitialize) this.grdSales).BeginInit();
		
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

        //tabApp

        //

        this.tabApp.AccessibleDescription = resources.GetString("tabApp.AccessibleDescription");

        this.tabApp.AccessibleName = resources.GetString("tabApp.AccessibleName");

        this.tabApp.Alignment = (System.Windows.Forms.TabAlignment) resources.GetObject("tabApp.Alignment");

        this.tabApp.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tabApp.Anchor");

        this.tabApp.Appearance = (System.Windows.Forms.TabAppearance) resources.GetObject("tabApp.Appearance");

        this.tabApp.BackgroundImage = (System.Drawing.Image) resources.GetObject("tabApp.BackgroundImage");

        this.tabApp.Controls.AddRange(new System.Windows.Forms.Control[] {this.pgeCreateSprocs, this.pgeNoParams, this.pgeInputParam, this.pgeAllTypes, this.pgeMSAccess});

        this.tabApp.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tabApp.Dock");

        this.tabApp.Enabled = (bool) resources.GetObject("tabApp.Enabled");

        this.tabApp.Font = (System.Drawing.Font) resources.GetObject("tabApp.Font");

        this.tabApp.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tabApp.ImeMode");

        this.tabApp.ItemSize = (System.Drawing.Size) resources.GetObject("tabApp.ItemSize");

        this.tabApp.Location = (System.Drawing.Point) resources.GetObject("tabApp.Location");

        this.tabApp.Name = "tabApp";

        this.tabApp.Padding = (System.Drawing.Point) resources.GetObject("tabApp.Padding");

        this.tabApp.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tabApp.RightToLeft");

        this.tabApp.SelectedIndex = 0;

        this.tabApp.ShowToolTips = (bool) resources.GetObject("tabApp.ShowToolTips");

        this.tabApp.Size = (System.Drawing.Size) resources.GetObject("tabApp.Size");

        this.tabApp.TabIndex = (int) resources.GetObject("tabApp.TabIndex");

        this.tabApp.Text = resources.GetString("tabApp.Text");

        this.tabApp.Visible = (bool) resources.GetObject("tabApp.Visible");

		this.tabApp.SelectedIndexChanged+=new EventHandler(tabApp_SelectedIndexChanged);

        //

        //pgeCreateSprocs

        //

        this.pgeCreateSprocs.AccessibleDescription = resources.GetString("pgeCreateSprocs.AccessibleDescription");

        this.pgeCreateSprocs.AccessibleName = resources.GetString("pgeCreateSprocs.AccessibleName");

        this.pgeCreateSprocs.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeCreateSprocs.Anchor");

        this.pgeCreateSprocs.AutoScroll = (bool) resources.GetObject("pgeCreateSprocs.AutoScroll");

        this.pgeCreateSprocs.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeCreateSprocs.AutoScrollMargin");

        this.pgeCreateSprocs.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeCreateSprocs.AutoScrollMinSize");

        this.pgeCreateSprocs.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeCreateSprocs.BackgroundImage");

        this.pgeCreateSprocs.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2, this.btnCreateSprocs});

        this.pgeCreateSprocs.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeCreateSprocs.Dock");

        this.pgeCreateSprocs.Enabled = (bool) resources.GetObject("pgeCreateSprocs.Enabled");

        this.pgeCreateSprocs.Font = (System.Drawing.Font) resources.GetObject("pgeCreateSprocs.Font");

        this.pgeCreateSprocs.ImageIndex = (int) resources.GetObject("pgeCreateSprocs.ImageIndex");

        this.pgeCreateSprocs.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeCreateSprocs.ImeMode");

        this.pgeCreateSprocs.Location = (System.Drawing.Point) resources.GetObject("pgeCreateSprocs.Location");

        this.pgeCreateSprocs.Name = "pgeCreateSprocs";

        this.pgeCreateSprocs.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeCreateSprocs.RightToLeft");

        this.pgeCreateSprocs.Size = (System.Drawing.Size) resources.GetObject("pgeCreateSprocs.Size");

        this.pgeCreateSprocs.TabIndex = (int) resources.GetObject("pgeCreateSprocs.TabIndex");

        this.pgeCreateSprocs.Text = resources.GetString("pgeCreateSprocs.Text");

        this.pgeCreateSprocs.ToolTipText = resources.GetString("pgeCreateSprocs.ToolTipText");

        this.pgeCreateSprocs.Visible = (bool) resources.GetObject("pgeCreateSprocs.Visible");

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

        //btnCreateSprocs

        //

        this.btnCreateSprocs.AccessibleDescription = resources.GetString("btnCreateSprocs.AccessibleDescription");

        this.btnCreateSprocs.AccessibleName = resources.GetString("btnCreateSprocs.AccessibleName");

        this.btnCreateSprocs.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateSprocs.Anchor");

        this.btnCreateSprocs.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateSprocs.BackgroundImage");

        this.btnCreateSprocs.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateSprocs.Dock");

        this.btnCreateSprocs.Enabled = (bool) resources.GetObject("btnCreateSprocs.Enabled");

        this.btnCreateSprocs.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateSprocs.FlatStyle");

        this.btnCreateSprocs.Font = (System.Drawing.Font) resources.GetObject("btnCreateSprocs.Font");

        this.btnCreateSprocs.Image = (System.Drawing.Image) resources.GetObject("btnCreateSprocs.Image");

        this.btnCreateSprocs.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateSprocs.ImageAlign");

        this.btnCreateSprocs.ImageIndex = (int) resources.GetObject("btnCreateSprocs.ImageIndex");

        this.btnCreateSprocs.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateSprocs.ImeMode");

        this.btnCreateSprocs.Location = (System.Drawing.Point) resources.GetObject("btnCreateSprocs.Location");

        this.btnCreateSprocs.Name = "btnCreateSprocs";

        this.btnCreateSprocs.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateSprocs.RightToLeft");

        this.btnCreateSprocs.Size = (System.Drawing.Size) resources.GetObject("btnCreateSprocs.Size");

        this.btnCreateSprocs.TabIndex = (int) resources.GetObject("btnCreateSprocs.TabIndex");

        this.btnCreateSprocs.Text = resources.GetString("btnCreateSprocs.Text");

        this.btnCreateSprocs.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateSprocs.TextAlign");

        this.btnCreateSprocs.Visible = (bool) resources.GetObject("btnCreateSprocs.Visible");

		this.btnCreateSprocs.Click+=new EventHandler(btnCreateSprocs_Click);

        //

        //pgeNoParams

        //

        this.pgeNoParams.AccessibleDescription = resources.GetString("pgeNoParams.AccessibleDescription");

        this.pgeNoParams.AccessibleName = resources.GetString("pgeNoParams.AccessibleName");

        this.pgeNoParams.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeNoParams.Anchor");

        this.pgeNoParams.AutoScroll = (bool) resources.GetObject("pgeNoParams.AutoScroll");

        this.pgeNoParams.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeNoParams.AutoScrollMargin");

        this.pgeNoParams.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeNoParams.AutoScrollMinSize");

        this.pgeNoParams.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeNoParams.BackgroundImage");

        this.pgeNoParams.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtTenMostExpProds, this.Label1, this.btnGet10MostExpProds});

        this.pgeNoParams.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeNoParams.Dock");

        this.pgeNoParams.Enabled = (bool) resources.GetObject("pgeNoParams.Enabled");

        this.pgeNoParams.Font = (System.Drawing.Font) resources.GetObject("pgeNoParams.Font");

        this.pgeNoParams.ImageIndex = (int) resources.GetObject("pgeNoParams.ImageIndex");

        this.pgeNoParams.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeNoParams.ImeMode");

        this.pgeNoParams.Location = (System.Drawing.Point) resources.GetObject("pgeNoParams.Location");

        this.pgeNoParams.Name = "pgeNoParams";

        this.pgeNoParams.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeNoParams.RightToLeft");

        this.pgeNoParams.Size = (System.Drawing.Size) resources.GetObject("pgeNoParams.Size");

        this.pgeNoParams.TabIndex = (int) resources.GetObject("pgeNoParams.TabIndex");

        this.pgeNoParams.Text = resources.GetString("pgeNoParams.Text");

        this.pgeNoParams.ToolTipText = resources.GetString("pgeNoParams.ToolTipText");

        this.pgeNoParams.Visible = (bool) resources.GetObject("pgeNoParams.Visible");

        //

        //txtTenMostExpProds

        //

        this.txtTenMostExpProds.AccessibleDescription = resources.GetString("txtTenMostExpProds.AccessibleDescription");

        this.txtTenMostExpProds.AccessibleName = resources.GetString("txtTenMostExpProds.AccessibleName");

        this.txtTenMostExpProds.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtTenMostExpProds.Anchor");

        this.txtTenMostExpProds.AutoSize = (bool) resources.GetObject("txtTenMostExpProds.AutoSize");

        this.txtTenMostExpProds.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtTenMostExpProds.BackgroundImage");

        this.txtTenMostExpProds.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtTenMostExpProds.Dock");

        this.txtTenMostExpProds.Enabled = (bool) resources.GetObject("txtTenMostExpProds.Enabled");

        this.txtTenMostExpProds.Font = (System.Drawing.Font) resources.GetObject("txtTenMostExpProds.Font");

        this.txtTenMostExpProds.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtTenMostExpProds.ImeMode");

        this.txtTenMostExpProds.Location = (System.Drawing.Point) resources.GetObject("txtTenMostExpProds.Location");

        this.txtTenMostExpProds.MaxLength = (int) resources.GetObject("txtTenMostExpProds.MaxLength");

        this.txtTenMostExpProds.Multiline = (bool) resources.GetObject("txtTenMostExpProds.Multiline");

        this.txtTenMostExpProds.Name = "txtTenMostExpProds";

        this.txtTenMostExpProds.PasswordChar = (char) resources.GetObject("txtTenMostExpProds.PasswordChar");

        this.txtTenMostExpProds.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtTenMostExpProds.RightToLeft");

        this.txtTenMostExpProds.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtTenMostExpProds.ScrollBars");

        this.txtTenMostExpProds.Size = (System.Drawing.Size) resources.GetObject("txtTenMostExpProds.Size");

        this.txtTenMostExpProds.TabIndex = (int) resources.GetObject("txtTenMostExpProds.TabIndex");

        this.txtTenMostExpProds.Text = resources.GetString("txtTenMostExpProds.Text");

        this.txtTenMostExpProds.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtTenMostExpProds.TextAlign");

        this.txtTenMostExpProds.Visible = (bool) resources.GetObject("txtTenMostExpProds.Visible");

        this.txtTenMostExpProds.WordWrap = (bool) resources.GetObject("txtTenMostExpProds.WordWrap");

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

        //btnGet10MostExpProds

        //

        this.btnGet10MostExpProds.AccessibleDescription = resources.GetString("btnGet10MostExpProds.AccessibleDescription");

        this.btnGet10MostExpProds.AccessibleName = resources.GetString("btnGet10MostExpProds.AccessibleName");

        this.btnGet10MostExpProds.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGet10MostExpProds.Anchor");

        this.btnGet10MostExpProds.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGet10MostExpProds.BackgroundImage");

        this.btnGet10MostExpProds.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGet10MostExpProds.Dock");

        this.btnGet10MostExpProds.Enabled = (bool) resources.GetObject("btnGet10MostExpProds.Enabled");

        this.btnGet10MostExpProds.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGet10MostExpProds.FlatStyle");

        this.btnGet10MostExpProds.Font = (System.Drawing.Font) resources.GetObject("btnGet10MostExpProds.Font");

        this.btnGet10MostExpProds.Image = (System.Drawing.Image) resources.GetObject("btnGet10MostExpProds.Image");

        this.btnGet10MostExpProds.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGet10MostExpProds.ImageAlign");

        this.btnGet10MostExpProds.ImageIndex = (int) resources.GetObject("btnGet10MostExpProds.ImageIndex");

        this.btnGet10MostExpProds.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGet10MostExpProds.ImeMode");

        this.btnGet10MostExpProds.Location = (System.Drawing.Point) resources.GetObject("btnGet10MostExpProds.Location");

        this.btnGet10MostExpProds.Name = "btnGet10MostExpProds";

        this.btnGet10MostExpProds.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGet10MostExpProds.RightToLeft");

        this.btnGet10MostExpProds.Size = (System.Drawing.Size) resources.GetObject("btnGet10MostExpProds.Size");

        this.btnGet10MostExpProds.TabIndex = (int) resources.GetObject("btnGet10MostExpProds.TabIndex");

        this.btnGet10MostExpProds.Text = resources.GetString("btnGet10MostExpProds.Text");

        this.btnGet10MostExpProds.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGet10MostExpProds.TextAlign");

        this.btnGet10MostExpProds.Visible = (bool) resources.GetObject("btnGet10MostExpProds.Visible");

		this.btnGet10MostExpProds.Click+=new EventHandler(btnGet10MostExpProds_Click);

        //

        //pgeInputParam

        //

        this.pgeInputParam.AccessibleDescription = resources.GetString("pgeInputParam.AccessibleDescription");

        this.pgeInputParam.AccessibleName = resources.GetString("pgeInputParam.AccessibleName");

        this.pgeInputParam.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeInputParam.Anchor");

        this.pgeInputParam.AutoScroll = (bool) resources.GetObject("pgeInputParam.AutoScroll");

        this.pgeInputParam.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeInputParam.AutoScrollMargin");

        this.pgeInputParam.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeInputParam.AutoScrollMinSize");

        this.pgeInputParam.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeInputParam.BackgroundImage");

        this.pgeInputParam.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label4, this.grdProducts, this.btnGetProducts, this.cboCategoriesInputParam, this.Label3});

        this.pgeInputParam.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeInputParam.Dock");

        this.pgeInputParam.Enabled = (bool) resources.GetObject("pgeInputParam.Enabled");

        this.pgeInputParam.Font = (System.Drawing.Font) resources.GetObject("pgeInputParam.Font");

        this.pgeInputParam.ImageIndex = (int) resources.GetObject("pgeInputParam.ImageIndex");

        this.pgeInputParam.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeInputParam.ImeMode");

        this.pgeInputParam.Location = (System.Drawing.Point) resources.GetObject("pgeInputParam.Location");

        this.pgeInputParam.Name = "pgeInputParam";

        this.pgeInputParam.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeInputParam.RightToLeft");

        this.pgeInputParam.Size = (System.Drawing.Size) resources.GetObject("pgeInputParam.Size");

        this.pgeInputParam.TabIndex = (int) resources.GetObject("pgeInputParam.TabIndex");

        this.pgeInputParam.Text = resources.GetString("pgeInputParam.Text");

        this.pgeInputParam.ToolTipText = resources.GetString("pgeInputParam.ToolTipText");

        this.pgeInputParam.Visible = (bool) resources.GetObject("pgeInputParam.Visible");

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

        //grdProducts

        //

        this.grdProducts.AccessibleDescription = resources.GetString("grdProducts.AccessibleDescription");

        this.grdProducts.AccessibleName = resources.GetString("grdProducts.AccessibleName");

        this.grdProducts.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdProducts.Anchor");

        this.grdProducts.BackgroundImage = (System.Drawing.Image) resources.GetObject("grdProducts.BackgroundImage");

        this.grdProducts.CaptionFont = (System.Drawing.Font) resources.GetObject("grdProducts.CaptionFont");

        this.grdProducts.CaptionText = resources.GetString("grdProducts.CaptionText");

        this.grdProducts.DataMember = string.Empty;

        this.grdProducts.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grdProducts.Dock");

        this.grdProducts.Enabled = (bool) resources.GetObject("grdProducts.Enabled");

        this.grdProducts.Font = (System.Drawing.Font) resources.GetObject("grdProducts.Font");

        this.grdProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.grdProducts.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grdProducts.ImeMode");

        this.grdProducts.Location = (System.Drawing.Point) resources.GetObject("grdProducts.Location");

        this.grdProducts.Name = "grdProducts";

        this.grdProducts.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grdProducts.RightToLeft");

        this.grdProducts.Size = (System.Drawing.Size) resources.GetObject("grdProducts.Size");

        this.grdProducts.TabIndex = (int) resources.GetObject("grdProducts.TabIndex");

        this.grdProducts.Visible = (bool) resources.GetObject("grdProducts.Visible");

        //

        //btnGetProducts

        //

        this.btnGetProducts.AccessibleDescription = resources.GetString("btnGetProducts.AccessibleDescription");

        this.btnGetProducts.AccessibleName = resources.GetString("btnGetProducts.AccessibleName");

        this.btnGetProducts.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGetProducts.Anchor");

        this.btnGetProducts.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGetProducts.BackgroundImage");

        this.btnGetProducts.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGetProducts.Dock");

        this.btnGetProducts.Enabled = (bool) resources.GetObject("btnGetProducts.Enabled");

        this.btnGetProducts.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGetProducts.FlatStyle");

        this.btnGetProducts.Font = (System.Drawing.Font) resources.GetObject("btnGetProducts.Font");

        this.btnGetProducts.Image = (System.Drawing.Image) resources.GetObject("btnGetProducts.Image");

        this.btnGetProducts.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetProducts.ImageAlign");

        this.btnGetProducts.ImageIndex = (int) resources.GetObject("btnGetProducts.ImageIndex");

        this.btnGetProducts.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGetProducts.ImeMode");

        this.btnGetProducts.Location = (System.Drawing.Point) resources.GetObject("btnGetProducts.Location");

        this.btnGetProducts.Name = "btnGetProducts";

        this.btnGetProducts.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGetProducts.RightToLeft");

        this.btnGetProducts.Size = (System.Drawing.Size) resources.GetObject("btnGetProducts.Size");

        this.btnGetProducts.TabIndex = (int) resources.GetObject("btnGetProducts.TabIndex");

        this.btnGetProducts.Text = resources.GetString("btnGetProducts.Text");

        this.btnGetProducts.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetProducts.TextAlign");

        this.btnGetProducts.Visible = (bool) resources.GetObject("btnGetProducts.Visible");

		this.btnGetProducts.Click+=new EventHandler(btnGetProducts_Click);

        //

        //cboCategoriesInputParam

        //

        this.cboCategoriesInputParam.AccessibleDescription = resources.GetString("cboCategoriesInputParam.AccessibleDescription");

        this.cboCategoriesInputParam.AccessibleName = resources.GetString("cboCategoriesInputParam.AccessibleName");

        this.cboCategoriesInputParam.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboCategoriesInputParam.Anchor");

        this.cboCategoriesInputParam.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboCategoriesInputParam.BackgroundImage");

        this.cboCategoriesInputParam.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboCategoriesInputParam.Dock");

        this.cboCategoriesInputParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        this.cboCategoriesInputParam.Enabled = (bool) resources.GetObject("cboCategoriesInputParam.Enabled");

        this.cboCategoriesInputParam.Font = (System.Drawing.Font) resources.GetObject("cboCategoriesInputParam.Font");

        this.cboCategoriesInputParam.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboCategoriesInputParam.ImeMode");

        this.cboCategoriesInputParam.IntegralHeight = (bool) resources.GetObject("cboCategoriesInputParam.IntegralHeight");

        this.cboCategoriesInputParam.ItemHeight = (int) resources.GetObject("cboCategoriesInputParam.ItemHeight");

        this.cboCategoriesInputParam.Location = (System.Drawing.Point) resources.GetObject("cboCategoriesInputParam.Location");

        this.cboCategoriesInputParam.MaxDropDownItems = (int) resources.GetObject("cboCategoriesInputParam.MaxDropDownItems");

        this.cboCategoriesInputParam.MaxLength = (int) resources.GetObject("cboCategoriesInputParam.MaxLength");

        this.cboCategoriesInputParam.Name = "cboCategoriesInputParam";

        this.cboCategoriesInputParam.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboCategoriesInputParam.RightToLeft");

        this.cboCategoriesInputParam.Size = (System.Drawing.Size) resources.GetObject("cboCategoriesInputParam.Size");

        this.cboCategoriesInputParam.TabIndex = (int) resources.GetObject("cboCategoriesInputParam.TabIndex");

        this.cboCategoriesInputParam.Text = resources.GetString("cboCategoriesInputParam.Text");

        this.cboCategoriesInputParam.Visible = (bool) resources.GetObject("cboCategoriesInputParam.Visible");

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

        //pgeAllTypes

        //

        this.pgeAllTypes.AccessibleDescription = resources.GetString("pgeAllTypes.AccessibleDescription");

        this.pgeAllTypes.AccessibleName = resources.GetString("pgeAllTypes.AccessibleName");

        this.pgeAllTypes.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeAllTypes.Anchor");

        this.pgeAllTypes.AutoScroll = (bool) resources.GetObject("pgeAllTypes.AutoScroll");

        this.pgeAllTypes.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeAllTypes.AutoScrollMargin");

        this.pgeAllTypes.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeAllTypes.AutoScrollMinSize");

        this.pgeAllTypes.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeAllTypes.BackgroundImage");

        this.pgeAllTypes.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblProductCountAndAvgPrice, this.Label5, this.btnGetProductCountAndAvgPrice, this.cboCategoriesAllTypes, this.Label6});

        this.pgeAllTypes.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeAllTypes.Dock");

        this.pgeAllTypes.Enabled = (bool) resources.GetObject("pgeAllTypes.Enabled");

        this.pgeAllTypes.Font = (System.Drawing.Font) resources.GetObject("pgeAllTypes.Font");

        this.pgeAllTypes.ImageIndex = (int) resources.GetObject("pgeAllTypes.ImageIndex");

        this.pgeAllTypes.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeAllTypes.ImeMode");

        this.pgeAllTypes.Location = (System.Drawing.Point) resources.GetObject("pgeAllTypes.Location");

        this.pgeAllTypes.Name = "pgeAllTypes";

        this.pgeAllTypes.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeAllTypes.RightToLeft");

        this.pgeAllTypes.Size = (System.Drawing.Size) resources.GetObject("pgeAllTypes.Size");

        this.pgeAllTypes.TabIndex = (int) resources.GetObject("pgeAllTypes.TabIndex");

        this.pgeAllTypes.Text = resources.GetString("pgeAllTypes.Text");

        this.pgeAllTypes.ToolTipText = resources.GetString("pgeAllTypes.ToolTipText");

        this.pgeAllTypes.Visible = (bool) resources.GetObject("pgeAllTypes.Visible");

        //

        //lblProductCountAndAvgPrice

        //

        this.lblProductCountAndAvgPrice.AccessibleDescription = resources.GetString("lblProductCountAndAvgPrice.AccessibleDescription");

        this.lblProductCountAndAvgPrice.AccessibleName = resources.GetString("lblProductCountAndAvgPrice.AccessibleName");

        this.lblProductCountAndAvgPrice.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblProductCountAndAvgPrice.Anchor");

        this.lblProductCountAndAvgPrice.AutoSize = (bool) resources.GetObject("lblProductCountAndAvgPrice.AutoSize");

        this.lblProductCountAndAvgPrice.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblProductCountAndAvgPrice.Dock");

        this.lblProductCountAndAvgPrice.Enabled = (bool) resources.GetObject("lblProductCountAndAvgPrice.Enabled");

        this.lblProductCountAndAvgPrice.Font = (System.Drawing.Font) resources.GetObject("lblProductCountAndAvgPrice.Font");

        this.lblProductCountAndAvgPrice.Image = (System.Drawing.Image) resources.GetObject("lblProductCountAndAvgPrice.Image");

        this.lblProductCountAndAvgPrice.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProductCountAndAvgPrice.ImageAlign");

        this.lblProductCountAndAvgPrice.ImageIndex = (int) resources.GetObject("lblProductCountAndAvgPrice.ImageIndex");

        this.lblProductCountAndAvgPrice.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblProductCountAndAvgPrice.ImeMode");

        this.lblProductCountAndAvgPrice.Location = (System.Drawing.Point) resources.GetObject("lblProductCountAndAvgPrice.Location");

        this.lblProductCountAndAvgPrice.Name = "lblProductCountAndAvgPrice";

        this.lblProductCountAndAvgPrice.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblProductCountAndAvgPrice.RightToLeft");

        this.lblProductCountAndAvgPrice.Size = (System.Drawing.Size) resources.GetObject("lblProductCountAndAvgPrice.Size");

        this.lblProductCountAndAvgPrice.TabIndex = (int) resources.GetObject("lblProductCountAndAvgPrice.TabIndex");

        this.lblProductCountAndAvgPrice.Text = resources.GetString("lblProductCountAndAvgPrice.Text");

        this.lblProductCountAndAvgPrice.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProductCountAndAvgPrice.TextAlign");

        this.lblProductCountAndAvgPrice.Visible = (bool) resources.GetObject("lblProductCountAndAvgPrice.Visible");

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

        //btnGetProductCountAndAvgPrice

        //

        this.btnGetProductCountAndAvgPrice.AccessibleDescription = resources.GetString("btnGetProductCountAndAvgPrice.AccessibleDescription");

        this.btnGetProductCountAndAvgPrice.AccessibleName = resources.GetString("btnGetProductCountAndAvgPrice.AccessibleName");

        this.btnGetProductCountAndAvgPrice.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGetProductCountAndAvgPrice.Anchor");

        this.btnGetProductCountAndAvgPrice.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGetProductCountAndAvgPrice.BackgroundImage");

        this.btnGetProductCountAndAvgPrice.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGetProductCountAndAvgPrice.Dock");

        this.btnGetProductCountAndAvgPrice.Enabled = (bool) resources.GetObject("btnGetProductCountAndAvgPrice.Enabled");

        this.btnGetProductCountAndAvgPrice.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGetProductCountAndAvgPrice.FlatStyle");

        this.btnGetProductCountAndAvgPrice.Font = (System.Drawing.Font) resources.GetObject("btnGetProductCountAndAvgPrice.Font");

        this.btnGetProductCountAndAvgPrice.Image = (System.Drawing.Image) resources.GetObject("btnGetProductCountAndAvgPrice.Image");

        this.btnGetProductCountAndAvgPrice.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetProductCountAndAvgPrice.ImageAlign");

        this.btnGetProductCountAndAvgPrice.ImageIndex = (int) resources.GetObject("btnGetProductCountAndAvgPrice.ImageIndex");

        this.btnGetProductCountAndAvgPrice.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGetProductCountAndAvgPrice.ImeMode");

        this.btnGetProductCountAndAvgPrice.Location = (System.Drawing.Point) resources.GetObject("btnGetProductCountAndAvgPrice.Location");

        this.btnGetProductCountAndAvgPrice.Name = "btnGetProductCountAndAvgPrice";

        this.btnGetProductCountAndAvgPrice.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGetProductCountAndAvgPrice.RightToLeft");

        this.btnGetProductCountAndAvgPrice.Size = (System.Drawing.Size) resources.GetObject("btnGetProductCountAndAvgPrice.Size");

        this.btnGetProductCountAndAvgPrice.TabIndex = (int) resources.GetObject("btnGetProductCountAndAvgPrice.TabIndex");

        this.btnGetProductCountAndAvgPrice.Text = resources.GetString("btnGetProductCountAndAvgPrice.Text");

        this.btnGetProductCountAndAvgPrice.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetProductCountAndAvgPrice.TextAlign");

        this.btnGetProductCountAndAvgPrice.Visible = (bool) resources.GetObject("btnGetProductCountAndAvgPrice.Visible");

		this.btnGetProductCountAndAvgPrice.Click+=new EventHandler(btnGetProductCountAndAvgPrice_Click);

        //

        //cboCategoriesAllTypes

        //

        this.cboCategoriesAllTypes.AccessibleDescription = resources.GetString("cboCategoriesAllTypes.AccessibleDescription");

        this.cboCategoriesAllTypes.AccessibleName = resources.GetString("cboCategoriesAllTypes.AccessibleName");

        this.cboCategoriesAllTypes.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboCategoriesAllTypes.Anchor");

        this.cboCategoriesAllTypes.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboCategoriesAllTypes.BackgroundImage");

        this.cboCategoriesAllTypes.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboCategoriesAllTypes.Dock");

        this.cboCategoriesAllTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        this.cboCategoriesAllTypes.Enabled = (bool) resources.GetObject("cboCategoriesAllTypes.Enabled");

        this.cboCategoriesAllTypes.Font = (System.Drawing.Font) resources.GetObject("cboCategoriesAllTypes.Font");

        this.cboCategoriesAllTypes.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboCategoriesAllTypes.ImeMode");

        this.cboCategoriesAllTypes.IntegralHeight = (bool) resources.GetObject("cboCategoriesAllTypes.IntegralHeight");

        this.cboCategoriesAllTypes.ItemHeight = (int) resources.GetObject("cboCategoriesAllTypes.ItemHeight");

        this.cboCategoriesAllTypes.Location = (System.Drawing.Point) resources.GetObject("cboCategoriesAllTypes.Location");

        this.cboCategoriesAllTypes.MaxDropDownItems = (int) resources.GetObject("cboCategoriesAllTypes.MaxDropDownItems");

        this.cboCategoriesAllTypes.MaxLength = (int) resources.GetObject("cboCategoriesAllTypes.MaxLength");

        this.cboCategoriesAllTypes.Name = "cboCategoriesAllTypes";

        this.cboCategoriesAllTypes.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboCategoriesAllTypes.RightToLeft");

        this.cboCategoriesAllTypes.Size = (System.Drawing.Size) resources.GetObject("cboCategoriesAllTypes.Size");

        this.cboCategoriesAllTypes.TabIndex = (int) resources.GetObject("cboCategoriesAllTypes.TabIndex");

        this.cboCategoriesAllTypes.Text = resources.GetString("cboCategoriesAllTypes.Text");

        this.cboCategoriesAllTypes.Visible = (bool) resources.GetObject("cboCategoriesAllTypes.Visible");

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

        //pgeMSAccess

        //

        this.pgeMSAccess.AccessibleDescription = resources.GetString("pgeMSAccess.AccessibleDescription");

        this.pgeMSAccess.AccessibleName = resources.GetString("pgeMSAccess.AccessibleName");

        this.pgeMSAccess.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeMSAccess.Anchor");

        this.pgeMSAccess.AutoScroll = (bool) resources.GetObject("pgeMSAccess.AutoScroll");

        this.pgeMSAccess.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeMSAccess.AutoScrollMargin");

        this.pgeMSAccess.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeMSAccess.AutoScrollMinSize");

        this.pgeMSAccess.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeMSAccess.BackgroundImage");

        this.pgeMSAccess.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnCreateReport, this.txtEndingDate, this.Label10, this.Label9, this.txtBeginningDate, this.Label8, this.grdSales, this.lblNoSales});

        this.pgeMSAccess.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeMSAccess.Dock");

        this.pgeMSAccess.Enabled = (bool) resources.GetObject("pgeMSAccess.Enabled");

        this.pgeMSAccess.Font = (System.Drawing.Font) resources.GetObject("pgeMSAccess.Font");

        this.pgeMSAccess.ImageIndex = (int) resources.GetObject("pgeMSAccess.ImageIndex");

        this.pgeMSAccess.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeMSAccess.ImeMode");

        this.pgeMSAccess.Location = (System.Drawing.Point) resources.GetObject("pgeMSAccess.Location");

        this.pgeMSAccess.Name = "pgeMSAccess";

        this.pgeMSAccess.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeMSAccess.RightToLeft");

        this.pgeMSAccess.Size = (System.Drawing.Size) resources.GetObject("pgeMSAccess.Size");

        this.pgeMSAccess.TabIndex = (int) resources.GetObject("pgeMSAccess.TabIndex");

        this.pgeMSAccess.Text = resources.GetString("pgeMSAccess.Text");

        this.pgeMSAccess.ToolTipText = resources.GetString("pgeMSAccess.ToolTipText");

        this.pgeMSAccess.Visible = (bool) resources.GetObject("pgeMSAccess.Visible");

        //

        //btnCreateReport

        //

        this.btnCreateReport.AccessibleDescription = resources.GetString("btnCreateReport.AccessibleDescription");

        this.btnCreateReport.AccessibleName = resources.GetString("btnCreateReport.AccessibleName");

        this.btnCreateReport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateReport.Anchor");

        this.btnCreateReport.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateReport.BackgroundImage");

        this.btnCreateReport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateReport.Dock");

        this.btnCreateReport.Enabled = (bool) resources.GetObject("btnCreateReport.Enabled");

        this.btnCreateReport.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateReport.FlatStyle");

        this.btnCreateReport.Font = (System.Drawing.Font) resources.GetObject("btnCreateReport.Font");

        this.btnCreateReport.Image = (System.Drawing.Image) resources.GetObject("btnCreateReport.Image");

        this.btnCreateReport.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateReport.ImageAlign");

        this.btnCreateReport.ImageIndex = (int) resources.GetObject("btnCreateReport.ImageIndex");

        this.btnCreateReport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateReport.ImeMode");

        this.btnCreateReport.Location = (System.Drawing.Point) resources.GetObject("btnCreateReport.Location");

        this.btnCreateReport.Name = "btnCreateReport";

        this.btnCreateReport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateReport.RightToLeft");

        this.btnCreateReport.Size = (System.Drawing.Size) resources.GetObject("btnCreateReport.Size");

        this.btnCreateReport.TabIndex = (int) resources.GetObject("btnCreateReport.TabIndex");

        this.btnCreateReport.Text = resources.GetString("btnCreateReport.Text");

        this.btnCreateReport.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateReport.TextAlign");

        this.btnCreateReport.Visible = (bool) resources.GetObject("btnCreateReport.Visible");

		this.btnCreateReport.Click+=new EventHandler(btnCreateReport_Click);

        //

        //txtEndingDate

        //

        this.txtEndingDate.AccessibleDescription = resources.GetString("txtEndingDate.AccessibleDescription");

        this.txtEndingDate.AccessibleName = resources.GetString("txtEndingDate.AccessibleName");

        this.txtEndingDate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtEndingDate.Anchor");

        this.txtEndingDate.AutoSize = (bool) resources.GetObject("txtEndingDate.AutoSize");

        this.txtEndingDate.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtEndingDate.BackgroundImage");

        this.txtEndingDate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtEndingDate.Dock");

        this.txtEndingDate.Enabled = (bool) resources.GetObject("txtEndingDate.Enabled");

        this.txtEndingDate.Font = (System.Drawing.Font) resources.GetObject("txtEndingDate.Font");

        this.txtEndingDate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtEndingDate.ImeMode");

        this.txtEndingDate.Location = (System.Drawing.Point) resources.GetObject("txtEndingDate.Location");

        this.txtEndingDate.MaxLength = (int) resources.GetObject("txtEndingDate.MaxLength");

        this.txtEndingDate.Multiline = (bool) resources.GetObject("txtEndingDate.Multiline");

        this.txtEndingDate.Name = "txtEndingDate";

        this.txtEndingDate.PasswordChar = (char) resources.GetObject("txtEndingDate.PasswordChar");

        this.txtEndingDate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtEndingDate.RightToLeft");

        this.txtEndingDate.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtEndingDate.ScrollBars");

        this.txtEndingDate.Size = (System.Drawing.Size) resources.GetObject("txtEndingDate.Size");

        this.txtEndingDate.TabIndex = (int) resources.GetObject("txtEndingDate.TabIndex");

        this.txtEndingDate.Text = resources.GetString("txtEndingDate.Text");

        this.txtEndingDate.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtEndingDate.TextAlign");

        this.txtEndingDate.Visible = (bool) resources.GetObject("txtEndingDate.Visible");

        this.txtEndingDate.WordWrap = (bool) resources.GetObject("txtEndingDate.WordWrap");

        //

        //Label10

        //

        this.Label10.AccessibleDescription = resources.GetString("Label10.AccessibleDescription");

        this.Label10.AccessibleName = resources.GetString("Label10.AccessibleName");

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

        //Label9

        //

        this.Label9.AccessibleDescription = resources.GetString("Label9.AccessibleDescription");

        this.Label9.AccessibleName = resources.GetString("Label9.AccessibleName");

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

        //txtBeginningDate

        //

        this.txtBeginningDate.AccessibleDescription = resources.GetString("txtBeginningDate.AccessibleDescription");

        this.txtBeginningDate.AccessibleName = resources.GetString("txtBeginningDate.AccessibleName");

        this.txtBeginningDate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtBeginningDate.Anchor");

        this.txtBeginningDate.AutoSize = (bool) resources.GetObject("txtBeginningDate.AutoSize");

        this.txtBeginningDate.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtBeginningDate.BackgroundImage");

        this.txtBeginningDate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtBeginningDate.Dock");

        this.txtBeginningDate.Enabled = (bool) resources.GetObject("txtBeginningDate.Enabled");

        this.txtBeginningDate.Font = (System.Drawing.Font) resources.GetObject("txtBeginningDate.Font");

        this.txtBeginningDate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtBeginningDate.ImeMode");

        this.txtBeginningDate.Location = (System.Drawing.Point) resources.GetObject("txtBeginningDate.Location");

        this.txtBeginningDate.MaxLength = (int) resources.GetObject("txtBeginningDate.MaxLength");

        this.txtBeginningDate.Multiline = (bool) resources.GetObject("txtBeginningDate.Multiline");

        this.txtBeginningDate.Name = "txtBeginningDate";

        this.txtBeginningDate.PasswordChar = (char) resources.GetObject("txtBeginningDate.PasswordChar");

        this.txtBeginningDate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtBeginningDate.RightToLeft");

        this.txtBeginningDate.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtBeginningDate.ScrollBars");

        this.txtBeginningDate.Size = (System.Drawing.Size) resources.GetObject("txtBeginningDate.Size");

        this.txtBeginningDate.TabIndex = (int) resources.GetObject("txtBeginningDate.TabIndex");

        this.txtBeginningDate.Text = resources.GetString("txtBeginningDate.Text");

        this.txtBeginningDate.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtBeginningDate.TextAlign");

        this.txtBeginningDate.Visible = (bool) resources.GetObject("txtBeginningDate.Visible");

        this.txtBeginningDate.WordWrap = (bool) resources.GetObject("txtBeginningDate.WordWrap");

        //

        //Label8

        //

        this.Label8.AccessibleDescription = resources.GetString("Label8.AccessibleDescription");

        this.Label8.AccessibleName = resources.GetString("Label8.AccessibleName");

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

        //grdSales

        //

        this.grdSales.AccessibleDescription = resources.GetString("grdSales.AccessibleDescription");

        this.grdSales.AccessibleName = resources.GetString("grdSales.AccessibleName");

        this.grdSales.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdSales.Anchor");

        this.grdSales.BackgroundImage = (System.Drawing.Image) resources.GetObject("grdSales.BackgroundImage");

        this.grdSales.CaptionFont = (System.Drawing.Font) resources.GetObject("grdSales.CaptionFont");

        this.grdSales.CaptionText = resources.GetString("grdSales.CaptionText");

        this.grdSales.DataMember = string.Empty;

        this.grdSales.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grdSales.Dock");

        this.grdSales.Enabled = (bool) resources.GetObject("grdSales.Enabled");

        this.grdSales.Font = (System.Drawing.Font) resources.GetObject("grdSales.Font");

        this.grdSales.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.grdSales.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grdSales.ImeMode");

        this.grdSales.Location = (System.Drawing.Point) resources.GetObject("grdSales.Location");

        this.grdSales.Name = "grdSales";

        this.grdSales.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grdSales.RightToLeft");

        this.grdSales.Size = (System.Drawing.Size) resources.GetObject("grdSales.Size");

        this.grdSales.TabIndex = (int) resources.GetObject("grdSales.TabIndex");

        this.grdSales.Visible = (bool) resources.GetObject("grdSales.Visible");

        //

        //lblNoSales

        //

        this.lblNoSales.AccessibleDescription = resources.GetString("lblNoSales.AccessibleDescription");

        this.lblNoSales.AccessibleName = resources.GetString("lblNoSales.AccessibleName");

        this.lblNoSales.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblNoSales.Anchor");

        this.lblNoSales.AutoSize = (bool) resources.GetObject("lblNoSales.AutoSize");

        this.lblNoSales.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblNoSales.Dock");

        this.lblNoSales.Enabled = (bool) resources.GetObject("lblNoSales.Enabled");

        this.lblNoSales.Font = (System.Drawing.Font) resources.GetObject("lblNoSales.Font");

        this.lblNoSales.Image = (System.Drawing.Image) resources.GetObject("lblNoSales.Image");

        this.lblNoSales.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblNoSales.ImageAlign");

        this.lblNoSales.ImageIndex = (int) resources.GetObject("lblNoSales.ImageIndex");

        this.lblNoSales.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblNoSales.ImeMode");

        this.lblNoSales.Location = (System.Drawing.Point) resources.GetObject("lblNoSales.Location");

        this.lblNoSales.Name = "lblNoSales";

        this.lblNoSales.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblNoSales.RightToLeft");

        this.lblNoSales.Size = (System.Drawing.Size) resources.GetObject("lblNoSales.Size");

        this.lblNoSales.TabIndex = (int) resources.GetObject("lblNoSales.TabIndex");

        this.lblNoSales.Text = resources.GetString("lblNoSales.Text");

        this.lblNoSales.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblNoSales.TextAlign");

        this.lblNoSales.Visible = (bool) resources.GetObject("lblNoSales.Visible");

        //

        //Label7

        //

        this.Label7.AccessibleDescription = resources.GetString("Label7.AccessibleDescription");

        this.Label7.AccessibleName = resources.GetString("Label7.AccessibleName");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label7, this.tabApp});

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

        this.tabApp.ResumeLayout(false);

        this.pgeCreateSprocs.ResumeLayout(false);

        this.pgeNoParams.ResumeLayout(false);

        this.pgeInputParam.ResumeLayout(false);

        ((System.ComponentModel.ISupportInitialize) this.grdProducts).EndInit();

        this.pgeAllTypes.ResumeLayout(false);

        this.pgeMSAccess.ResumeLayout(false);

        ((System.ComponentModel.ISupportInitialize) this.grdSales).EndInit();

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

    // This subroutine handles the click event for the Create Report button, found 

    // on the MS Access tab. This routine uses classes from the System.Data.OleDb 

    // namespace to connect to the Northwind database found in Microsoft Access and 

    // execute a stored procedure that takes two input parameters.

    private void btnCreateReport_Click(object sender, System.EventArgs e) 
	{

        // Validate the beginning and end dates entered by the user.

        if (DatesAreValid()== false)
		{

            return;

        }

        strConn = ACCESS_CONNECTION_STRING;

        // Initialize variables to objects in the OleDb namespace.

        OleDbConnection ocnnNorthwind = new OleDbConnection(strConn);
        OleDbCommand ocmd  = new OleDbCommand("[Sales By Year]", ocnnNorthwind);
        OleDbDataAdapter oda = new OleDbDataAdapter(ocmd);

        // Create a Dataset to be filled using the OleDbDataAdapter.

        DataSet dsSales  = new DataSet();

        // By default the CommandType = Text (i.e., ad hoc SQL statements).

        ocmd.CommandType = CommandType.StoredProcedure;

        // Add the parameters required by the stored procedure and set their values.
        // These are added using shorthand notation. For longhand, see the 
        // btnGetProducts_Click event handler.

         

            ocmd.Parameters.Add(new OleDbParameter("@BeginningDate", OleDbType.Date)).Value = Convert.ToDateTime(txtBeginningDate.Text.Trim());
            ocmd.Parameters.Add(new OleDbParameter("@EndingDate", OleDbType.Date)).Value = Convert.ToDateTime(txtEndingDate.Text.Trim());

        try 
		{
            // Fill the DataSet. Optionally, you could also give the DataTable a 
            // specific name.

            oda.Fill(dsSales);

       } 
		catch(Exception exp)
		{
            MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK,MessageBoxIcon.Error);
            return;
        }

        // Only bind and show the DataGrid if the Dataset contains results.

		if (dsSales.Tables[0].Rows.Count > 0)
		{

			// Bind the DataGrid to the desired table in the DataSet. This
			// will cause the sales information to display.

			grdSales.DataSource = dsSales.Tables[0];

			// Continue to set DataGrid properties directly, but only
			// those that are not covered by DataGridTableStyle properties.

            

			grdSales.BackColor = Color.GhostWhite;

			grdSales.BackgroundColor = Color.Lavender;

			grdSales.BorderStyle = BorderStyle.None;

			grdSales.CaptionBackColor = Color.RoyalBlue;

			grdSales.CaptionFont = new Font("Tahoma", 10.0F, FontStyle.Bold);

			grdSales.CaptionForeColor = Color.Bisque;

			grdSales.CaptionText = "Northwind Sales By Year";

			grdSales.Font = new Font("Tahoma", 8.0F);

			grdSales.ParentRowsBackColor = Color.Lavender;

			grdSales.ParentRowsForeColor = Color.MidnightBlue;

			// Clear out all table style objects previously added or an
			// exception is thrown.

			grdSales.TableStyles.Clear();

            

			// Put much of the formatting possible here.

			DataGridTableStyle grdTableStyle1 = new DataGridTableStyle();

			grdTableStyle1.AlternatingBackColor = Color.GhostWhite;

			grdTableStyle1.BackColor = Color.GhostWhite;

			grdTableStyle1.ForeColor = Color.MidnightBlue;

			grdTableStyle1.GridLineColor = Color.RoyalBlue;

			grdTableStyle1.HeaderBackColor = Color.MidnightBlue;

			grdTableStyle1.HeaderFont = new Font("Tahoma", 8.0F, FontStyle.Bold);

			grdTableStyle1.HeaderForeColor = Color.Lavender;

			grdTableStyle1.SelectionBackColor = Color.Teal;

			grdTableStyle1.SelectionForeColor = Color.PaleGreen;

			// Do not forget to set the MappingName property. 
			// Without this, the DataGridTableStyle properties
			// and any associated DataGridColumnStyle objects
			// will have no effect.

			grdTableStyle1.MappingName = dsSales.Tables[0].TableName;

			grdTableStyle1.PreferredColumnWidth = 125;

			grdTableStyle1.PreferredRowHeight = 15;

			// Format each column that you want to appear in the DataGrid.
			// In most cases, the DataGridTextBoxColumn class is appropriate.
			// However, you can also use the DataGridBoolColumn class. Both
			// of these extend the MustInherit DataGridColumnStyle class. Notice
			// that the column style properties available to you are more limited
			// than those for the table style. For example, you can! change
			// the color of an individual column.

			DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();

			grdColStyle1.HeaderText = "Date Shipped";

			grdColStyle1.MappingName = "ShippedDate";

			grdColStyle1.Width = 100;

			DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();

			grdColStyle2.HeaderText = "Order ID";

			grdColStyle2.MappingName = "OrderID";

			DataGridTextBoxColumn grdColStyle3 = new DataGridTextBoxColumn();

			grdColStyle3.HeaderText = "void Total";

			grdColStyle3.MappingName = "Subtotal";

			grdColStyle3.Format = "c";

			grdColStyle3.Width = 75;

			grdColStyle3.ReadOnly = true;
            
			DataGridTextBoxColumn grdColStyle4 = new DataGridTextBoxColumn();

			grdColStyle4.HeaderText = "Year";

			grdColStyle4.MappingName = "Year";

			grdColStyle4.Width = 50;
            
			// Add the style objects to the table style's collection of 
			// column styles. Without this the styles do not take effect.        

			grdTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[]{grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4});

			grdSales.TableStyles.Add(grdTableStyle1);
		}
		else 
		{

			lblNoSales.Visible = true;
			grdSales.Visible = false;

		}

    }

    // This subroutine handles the click event for the Create Sprocs button, found 
    // on the Create Sprocs tab. This routine uses classes from the 
    // System.Data.SqlClient namespace to execute SQL statements that drop a stored 
    // procedure (if it exists) and then create it.

    private void btnCreateSprocs_Click(object sender, System.EventArgs e)
	{

        strConn = SQL_CONNECTION_STRING;

        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();

        if (DidPreviouslyConnect==false) 
		{

            frmStatusMessage.Show("Connecting to SQL Server");

        }

        // Attempt to connect to the local SQL server instance, or a local
        // MSDE installation.

        bool IsConnecting =true;

        while (IsConnecting)
		{

            try 
			{

                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in SQL Server, or be part of the Administrators
                // group for this to work.

                SqlConnection northwindConnection  = new SqlConnection(strConn);

                // DROP "GetCategories":
                // =====================
                // This SQL statement drops the stored procedure "GetCategories", 
                // if it exists.

                string strSQL  = "IF EXISTS (" + 
												"SELECT * " + 
												"FROM northwind.dbo.sysobjects " + 
												"WHERE Name = 'GetCategories' " + 
												"AND TYPE = 'p')" + Environment.NewLine + 
												"DROP PROCEDURE GetCategories";

                // A SqlCommand object is used to execute the SQL commands.

                SqlCommand scmd = new SqlCommand(strSQL, northwindConnection);

                try 
				{

                    // Open the connection and leave it open until last SQL statement
                    // is executed.

                    northwindConnection.Open();

                    // Connection successful so break out of the while loop and close 
                    // the status form.

                    IsConnecting = false;
                    DidPreviouslyConnect = true;
                    frmStatusMessage.Close();

                    // Execute the SQL statement using ExecuteNonQuery, which is more 
                    // efficient when not returning any data.

                    scmd.ExecuteNonQuery();

               } 
				catch(SqlException expSql)
				{

                    MessageBox.Show(expSql.ToString(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                // CREATE "GetCategories"
                // This SQL statement creates the stored procedure "GetCategories".

                scmd.CommandText = "CREATE PROCEDURE GetCategories " + Environment.NewLine + 
                    "AS " + Environment.NewLine + 
                    "SELECT CategoryID, CategoryName " + 
                    "FROM Northwind.dbo.Categories";

                try 
				{

                    scmd.ExecuteNonQuery();

				}
				catch(SqlException expSql) 
				{

                    MessageBox.Show(expSql.ToString(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                // DROP "GetProducts"
                // This SQL statement drops the stored procedure "GetProducts", 
                // if it exists.

					scmd.CommandText = "IF EXISTS (" + 
                    "SELECT * " + 
                    "FROM northwind.dbo.sysobjects " + 
                    "WHERE Name = 'GetProducts' " + 
                    "AND TYPE = 'p')" + Environment.NewLine + 
                    "DROP PROCEDURE GetProducts";

                try 
				{

                    scmd.ExecuteNonQuery();

				} 
				catch(SqlException expSql)
				{
                    
					MessageBox.Show(expSql.ToString(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                
				}

                // CREATE "GetProducts"
                // This SQL statement creates the stored procedure "GetProducts".

                scmd.CommandText = "CREATE PROCEDURE GetProducts " + Environment.NewLine + 
									"@CategoryID Int " + Environment.NewLine + 
									"AS " + Environment.NewLine + 
									"SELECT ProductID, ProductName, UnitPrice, UnitsInStock " + 
									"FROM Northwind.dbo.Products " + 
									"WHERE CategoryID = @CategoryID";

                try 
				{

                    scmd.ExecuteNonQuery();

				} 
				catch(SqlException expSql)
				{
                    MessageBox.Show(expSql.ToString(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // DROP "GetProductCountAndAveragePrice"
                // This SQL statement drops the stored procedure 
                // "GetProductCountAndAveragePrice", if it exists.

                scmd.CommandText = "IF EXISTS (" + 
									"SELECT * " + 
									"FROM northwind.dbo.sysobjects " + 
									"WHERE Name = 'GetProductCountAndAveragePrice' " + 
									"AND TYPE = 'p')" + Environment.NewLine + 
									"DROP PROCEDURE GetProductCountAndAveragePrice";

                try 
				{

                    scmd.ExecuteNonQuery();

				} 
				catch(SqlException expSql)
				{

                    MessageBox.Show(expSql.ToString(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                // CREATE "GetProductCountAndAveragePrice":
                // This SQL statement creates the stored procedure 
                // "GetProductCountAndAveragePrice".

                scmd.CommandText = "CREATE PROCEDURE GetProductCountAndAveragePrice " + Environment.NewLine + 
									"@CategoryID Int, " + Environment.NewLine + 
									"@AveragePrice Int OUT" + Environment.NewLine + 
									"AS " + Environment.NewLine + 
									"DECLARE @SumProdPrices Money " + Environment.NewLine + 
									"SELECT @AveragePrice = SUM(UnitPrice)/COUNT(ProductID) " + 
									"FROM Northwind.dbo.Products " + 
									"WHERE CategoryID = @CategoryID" + Environment.NewLine + 
									"RETURN " + 
									"(SELECT COUNT(ProductID) " + 
									"FROM Northwind.dbo.Products " + 
									"WHERE CategoryID = @CategoryID)";

				try 
				{

					scmd.ExecuteNonQuery();

				} 
				catch(SqlException expSql)
				{

					MessageBox.Show(expSql.ToString(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				finally
				{

					// For the final stored procedure, close the connection, no matter 
					// what happens. 

					northwindConnection.Close();

				}

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
					MessageBox.Show("To run this sample, you must have SQL " + 
									"or MSDE with the Northwind database installed.  For " + 
									"instructions on installing MSDE, view the ReadMe file.", 
									this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

					Application.Exit();

				}

            }

        }

        frmStatusMessage.Close();

        MessageBox.Show("The stored procedures were successfully added to the " + 
						"Northwind database.", this.Text, MessageBoxButtons.OK, 
						MessageBoxIcon.Information);

        HasCreatedSprocs = true;

    }

    // This subroutine handles the Click event for the get {Product Count and 
    // Avg Price button, found on the All Types tab. The stored procedure used
    // here requires a single input parameter and sends back both an output
    // parameter value well a return value. After the sproc is executed a 
    // Label is used to dislay the results.

    private void btnGetProductCountAndAvgPrice_Click(object sender, System.EventArgs e) 
	{
        strConn = SQL_CONNECTION_STRING;
        SqlConnection scnnNorthwind = new SqlConnection(strConn);
        SqlCommand scmd  = new SqlCommand("GetProductCountAndAveragePrice", scnnNorthwind);

        SqlDataAdapter sda  = new SqlDataAdapter(scmd);

        DataSet dsProducts = new DataSet();

        scmd.CommandType = CommandType.StoredProcedure;

        // Add the parameter required by the stored procedure. set {the input
        // parameter's value to that of the ComboBox control's selected value.
        // Set the Direction of the output parameter. Finally, add a paramter
        // to capture the return value, i.e., the value sent back from the 
        // stored procedure by the RETURN statement (or, if RETURN is not 
        // explicitly used in the stored procedure, the default success/fail
        // code returned by SQL Server).

        

            scmd.Parameters.Add(new SqlParameter("@CategoryID", SqlDbType.Int)).Value = cboCategoriesAllTypes.SelectedValue;

            // By default, the value of the Direction property is "Input",
            // so only in the next two parameters does Direction need to be
            // explicitly set.

            scmd.Parameters.Add(new SqlParameter("@AveragePrice", SqlDbType.Money)).Direction = ParameterDirection.Output;

            // Instead of adding a SqlParameter to obtain the return value you
            // can also just declare an integer variable and initialize it to
            // the value returned by the SqlDataAdapter Fill method, or 
            // whatever method you are using to execute the SQL statement
            // (as was done with the CREATE "GetProducts" stored procedure,
            // above).

            scmd.Parameters.Add(new SqlParameter("ReturnValue",SqlDbType.Int)).Direction = ParameterDirection.ReturnValue;

			try 
			{

			// For comments on this line of code see the try {...catch block
			// in the frmMain Load event handler.

			sda.Fill(dsProducts, "Products");
	
			} 
			catch(SqlException expSQL)
			{

            MessageBox.Show(expSQL.ToString(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

			}

        // Display the results.

        lblProductCountAndAvgPrice.Text = "There are " + 
											scmd.Parameters["ReturnValue"].Value.ToString() + " products " + 
											"in the " + cboCategoriesAllTypes.Text + " category, at an average " + "price of " + 
											Convert.ToDouble(scmd.Parameters["@AveragePrice"].Value.ToString());
                
			}

    // This subroutine handles the Click event for the get {Products button,
    // found on the Input Param tab. The "GetProducts" stored procedure requires
    // a single input parameter. The sproc is executed and a DataGrid used to
    // dislay the results.

    private void btnGetProducts_Click(object sender, System.EventArgs e)
	{
        strConn = SQL_CONNECTION_STRING;

        // For comments on these next three lines see the frmMain
        // Load event handler.

        SqlConnection scnnNorthwind  = new SqlConnection(strConn);
        SqlCommand scmd = new SqlCommand("GetProducts", scnnNorthwind);
        SqlDataAdapter sda  = new SqlDataAdapter(scmd);
        DataSet dsProducts  = new DataSet();

        // Add the parameter required by the stored procedure. set {the input
        // parameter's value to that of the ComboBox control's selected value.
        // The following syntax is the long way of adding a SqlParameter and
        // setting its properties. Look at btnGetProductCountAndAvgPrice_Click
        // event handler for a much shorter syntax.

        SqlParameter sparCatID  = new SqlParameter();
        sparCatID.ParameterName = "@CategoryID";
        sparCatID.SqlDbType = SqlDbType.Int;
        sparCatID.Value = cboCategoriesInputParam.SelectedValue;      
        scmd.Parameters.Add(sparCatID);
        scmd.CommandType = CommandType.StoredProcedure;

        try 
		{

            // Fill the Dataset and optionally name the DataTable.

            sda.Fill(dsProducts, "Products");

		}
		catch (SqlException expSQL)
		{
            
			MessageBox.Show(expSQL.ToString(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

        }

        // Bind the DataGrid to the desired table in the DataSet. This
        // will cause the product information to display.

        grdProducts.DataSource = dsProducts.Tables[0];

        // Continue to set DataGrid properties directly, but only
        // those that are not covered by DataGridTableStyle properties.

        grdProducts.BackColor = Color.GhostWhite;
        grdProducts.BackgroundColor = Color.Lavender;
        grdProducts.BorderStyle = BorderStyle.None;
        grdProducts.CaptionBackColor = Color.RoyalBlue;
        grdProducts.CaptionFont = new Font("Tahoma", 10.0F, FontStyle.Bold);
        grdProducts.CaptionForeColor = Color.Bisque;
        grdProducts.CaptionText = "Northwind Products";
        grdProducts.Font = new Font("Tahoma", 8.0F);
        grdProducts.ParentRowsBackColor = Color.Lavender;
        grdProducts.ParentRowsForeColor = Color.MidnightBlue;

        // Clear out all table style objects previously added or an
        // exception is thrown.

        grdProducts.TableStyles.Clear();
    
        // Put much of the formatting possible here.

        DataGridTableStyle grdTableStyle1  = new DataGridTableStyle();
        grdTableStyle1.AlternatingBackColor = Color.GhostWhite;
        grdTableStyle1.BackColor = Color.GhostWhite;
        grdTableStyle1.ForeColor = Color.MidnightBlue;
        grdTableStyle1.GridLineColor = Color.RoyalBlue;
        grdTableStyle1.HeaderBackColor = Color.MidnightBlue;
        grdTableStyle1.HeaderFont = new Font("Tahoma", 8.0F, FontStyle.Bold);
        grdTableStyle1.HeaderForeColor = Color.Lavender;
        grdTableStyle1.SelectionBackColor = Color.Teal;
        grdTableStyle1.SelectionForeColor = Color.PaleGreen;

        // Do not forget to set the MappingName property. 
        // Without this, the DataGridTableStyle properties
        // and any associated DataGridColumnStyle objects
        // will have no effect.

        grdTableStyle1.MappingName = dsProducts.Tables[0].TableName;
        grdTableStyle1.PreferredColumnWidth = 125;
        grdTableStyle1.PreferredRowHeight = 15;

        // Format each column that you want to appear in the DataGrid.
        // In most cases, the DataGridTextBoxColumn class is appropriate.
        // However, you can also use the DataGridBoolColumn class. Both
        // of these extend the MustInherit DataGridColumnStyle class. Notice
        // that the column style properties available to you are more limited
        // than those for the table style. For example, you can! change
        // the color of an individual column.

        DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();
        grdColStyle1.HeaderText = "ID";
        grdColStyle1.MappingName = "ProductID";
        grdColStyle1.Width = 50;
        DataGridTextBoxColumn grdColStyle2  = new DataGridTextBoxColumn();

        grdColStyle2.HeaderText = "Name";
        grdColStyle2.MappingName = "ProductName";

        DataGridTextBoxColumn grdColStyle3  = new DataGridTextBoxColumn();
        grdColStyle3.HeaderText = "Price";
        grdColStyle3.MappingName = "UnitPrice";
        grdColStyle3.Format = "c";
        grdColStyle3.Width = 75;
        grdColStyle3.ReadOnly = true;

        DataGridTextBoxColumn grdColStyle4  = new DataGridTextBoxColumn();

        grdColStyle4.HeaderText = "# In Stock";

        grdColStyle4.MappingName = "UnitsInStock";

        grdColStyle4.Width = 75;

        grdColStyle4.Alignment = HorizontalAlignment.Center;

        // Add the style objects to the table style's collection of 
        // column styles. Without this the styles do not take effect.        

        grdTableStyle1.GridColumnStyles.AddRange (new DataGridColumnStyle[] {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4});
        grdProducts.TableStyles.Add(grdTableStyle1);
    }

    // This subroutine handles the Click event for the Top Ten Products button,
    // found on the No Params tab. The stored procedure used here requires no  
    // input parameters.

    private void btnGet10MostExpProds_Click(object sender, System.EventArgs e)
	{

        SqlConnection scnnNorthwind = new SqlConnection(SQL_CONNECTION_STRING);

        // The SqlCommand object is responsible for executing SQL statements
        // and managing the associated SQL objects, like parameters. With ad
        // hoc SQL you would pass the SQL statement the first argument to 
        // the constructor. But when using stored procedures, you simply pass
        // the name of the stored procedure and set the CommandType property 
        // to the CommandType.StoredProcedure enum.

        SqlCommand scmd  = new SqlCommand("[Ten Most Expensive Products]", scnnNorthwind);
        scmd.CommandType = CommandType.StoredProcedure;

        // Open the connection to the database and execute the command, also passing 
        // in an enum value that immediately closes the connection. This is an option
        // to explicitly calling scnnNorthwind.Close().

        scnnNorthwind.Open();

        SqlDataReader sdr  = scmd.ExecuteReader(CommandBehavior.CloseConnection);

        // Instantiate a stringBuilder to concatenate the strings displayed in the
        // TextBox. The stringBuilder class is optimized for concatenation and is
        // to be preferred over the traditional += approach.

        StringBuilder sb  = new StringBuilder();

        sb.Append("Product Name");

        sb.Append(@"\t");

        sb.Append(@"\t");

        sb.Append(@"\t");

        sb.Append("Price");

        sb.Append(Environment.NewLine);

        sb.Append("========================");

        sb.Append(@"\t");

        sb.Append("==========");

        sb.Append(Environment.NewLine);

        // Loop through the contents of the SqlDataReader object.

        while (sdr.Read())
		{

            sb.Append(sdr.GetString(0));

            sb.Append(@"\t");

            sb.Append(@"\t");

            if (sdr.GetString(0).Length < 20)
			{

                sb.Append(@"\t");

            }

        // To format the string currency you must first convert it to a type
        // that implements the IFormattable interface.

		sb.Append(sdr.GetSqlMoney(1).ToDouble().ToString("c"));
        sb.Append(Environment.NewLine);

        }

        // Display the results.

        txtTenMostExpProds.Text = sb.ToString();

    }

    // This subroutine handles the SelectedIndexChanged for the TabControl. 
    // It ensures that the user can! run any of the examples prior to creating 
    // the stored procedures. if the sprocs have been created, the "GetCategories" 
    // sproc is executed to fill the product Categories ComboBox controls on the 
    // Input Param and All Types tab pages.

    private void tabApp_SelectedIndexChanged(object sender, System.EventArgs e)
	{

        if (HasCreatedSprocs==false & tabApp.SelectedTab.TabIndex > 0)
		{

            MessageBox.Show("You must first create the required stored procedures.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            tabApp.SelectedIndex = 0;

        } 
		else if (HasCreatedSprocs & cboCategoriesInputParam.Items.Count == 0)
		{
            // Fill ComboBox controls only if they are empty and the sprocs have 
            // been created.

            strConn = SQL_CONNECTION_STRING;

            // See other event handlers for comments about the following
            // lines of code.

            SqlConnection scnnNorthwind  = new SqlConnection(strConn);
            SqlCommand scmd  = new SqlCommand("GetCategories", scnnNorthwind);
            SqlDataAdapter sda  = new SqlDataAdapter(scmd);
            DataSet dsCategories = new DataSet();
            scmd.CommandType = CommandType.StoredProcedure;

            try 
			{

                // Fill the DataSet.

                sda.Fill(dsCategories);

			} 
			catch(SqlException expSql)
			{

                MessageBox.Show(expSql.ToString(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            // Bind the data to the ComboBox controls

            cboCategoriesInputParam.DataSource = dsCategories.Tables[0];
            cboCategoriesInputParam.DisplayMember = "CategoryName";
            cboCategoriesInputParam.ValueMember = "CategoryID";

            // Bind the data to the ComboBox controls

            cboCategoriesAllTypes.DataSource = dsCategories.Tables[0];
            cboCategoriesAllTypes.DisplayMember = "CategoryName";
            cboCategoriesAllTypes.ValueMember = "CategoryID";

        }

    }

    // Validates the dates entered into the TextBox controls on the MS Access tab.

    private bool DatesAreValid()
	{

        foreach(Object objControl in pgeMSAccess.Controls)
		{
            if (objControl.GetType().ToString() == "System.Windows.Forms.TextBox")
			{
                TextBox txt  = (TextBox) objControl;

                if (IsDate(txt.Text.Trim())==false)
				{
                    MessageBox.Show("You must enter a correct date in the form " + 
									"mm/dd/yyyy.", this.Text, MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txt.Focus();
                    txt.SelectAll();
                    return false;

                }

            }

        }

        return true;
    }
	public static bool IsDate(string strDate) 
	{
		DateTime dtDate;
		bool bValid = true;
		try 
		{
			dtDate = DateTime.Parse(strDate);
		}
		catch (FormatException eFormatException) 
		{
			// the Parse method failed => the string strDate cannot be converted to a date.
			bValid = false;
		}
		return bValid;
	}

}

