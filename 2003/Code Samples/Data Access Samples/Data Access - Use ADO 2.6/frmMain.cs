//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using ADODB;

public class frmMain : System.Windows.Forms.Form 
{
    protected const string MSDE_CONNECTION_STRING = "driver={SQL Server};server=(local)/VSDotNet;uid=;pwd=;database=Northwind";
    protected const string SQL_CONNECTION_STRING = "driver={SQL Server};server=localhost;uid=;pwd=;database=Northwind";

    private string Connectionstring  = SQL_CONNECTION_STRING;

    private bool HasConnected  = false;

    Connection cnn = new Connection();
    Command cm = new Command();
    Recordset rs = new Recordset();

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
        PopulateSimpleNavigationForm();
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

    private System.Windows.Forms.TabControl tcMain;

    private System.Windows.Forms.TabPage tpDatasetExample;

    private System.Windows.Forms.Button btnDataset;

    private System.Windows.Forms.DataGrid dgMain;

    private System.Windows.Forms.TabPage tpRecordNavigation;

    private System.Windows.Forms.TextBox txtPhone;

    private System.Windows.Forms.TextBox txtContactName;

    private System.Windows.Forms.TextBox txtCompanyName;

    private System.Windows.Forms.Button btnFirst;

    private System.Windows.Forms.Button btnPrev;

    private System.Windows.Forms.Button btnNext;

    private System.Windows.Forms.Button btnLast;

    private System.Windows.Forms.TabPage tpInsert;

    private System.Windows.Forms.TextBox txtCategoryName;

    private System.Windows.Forms.TextBox txtDescription;

    private System.Windows.Forms.Button btnInsert;

    private System.Windows.Forms.Label lblCategoryName;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.TabPage tpUpdate;

    private System.Windows.Forms.Button btnUpdate;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.ComboBox cbCategoryName;

    private System.Windows.Forms.TextBox txtUpdateDescription;

    private System.Windows.Forms.Label Label7;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.Label Label10;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.tcMain = new System.Windows.Forms.TabControl();

        this.tpRecordNavigation = new System.Windows.Forms.TabPage();

        this.Label7 = new System.Windows.Forms.Label();

        this.Label6 = new System.Windows.Forms.Label();

        this.Label5 = new System.Windows.Forms.Label();

        this.Label4 = new System.Windows.Forms.Label();

        this.btnLast = new System.Windows.Forms.Button();

        this.btnNext = new System.Windows.Forms.Button();

        this.btnPrev = new System.Windows.Forms.Button();

        this.btnFirst = new System.Windows.Forms.Button();

        this.txtPhone = new System.Windows.Forms.TextBox();

        this.txtContactName = new System.Windows.Forms.TextBox();

        this.txtCompanyName = new System.Windows.Forms.TextBox();

        this.tpInsert = new System.Windows.Forms.TabPage();

        this.Label8 = new System.Windows.Forms.Label();

        this.Label1 = new System.Windows.Forms.Label();

        this.lblCategoryName = new System.Windows.Forms.Label();

        this.btnInsert = new System.Windows.Forms.Button();

        this.txtDescription = new System.Windows.Forms.TextBox();

        this.txtCategoryName = new System.Windows.Forms.TextBox();

        this.tpUpdate = new System.Windows.Forms.TabPage();

        this.Label9 = new System.Windows.Forms.Label();

        this.Label2 = new System.Windows.Forms.Label();

        this.Label3 = new System.Windows.Forms.Label();

        this.txtUpdateDescription = new System.Windows.Forms.TextBox();

        this.cbCategoryName = new System.Windows.Forms.ComboBox();

        this.btnUpdate = new System.Windows.Forms.Button();

        this.tpDatasetExample = new System.Windows.Forms.TabPage();

        this.Label10 = new System.Windows.Forms.Label();

        this.btnDataset = new System.Windows.Forms.Button();

        this.dgMain = new System.Windows.Forms.DataGrid();

        this.tcMain.SuspendLayout();

        this.tpRecordNavigation.SuspendLayout();

        this.tpInsert.SuspendLayout();

        this.tpUpdate.SuspendLayout();

        this.tpDatasetExample.SuspendLayout();
				
        ((System.ComponentModel.ISupportInitialize) this.dgMain).BeginInit(); 
		
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

		this.mnuExit.Click += new EventHandler(mnuExit_Click);

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

		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
        //

        //tcMain

        //

        this.tcMain.AccessibleDescription = (string) resources.GetObject("tcMain.AccessibleDescription");

        this.tcMain.AccessibleName = (string) resources.GetObject("tcMain.AccessibleName");

        this.tcMain.Alignment = (System.Windows.Forms.TabAlignment) resources.GetObject("tcMain.Alignment");

        this.tcMain.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tcMain.Anchor");

        this.tcMain.Appearance = (System.Windows.Forms.TabAppearance) resources.GetObject("tcMain.Appearance");

        this.tcMain.BackgroundImage = (System.Drawing.Image) resources.GetObject("tcMain.BackgroundImage");

        this.tcMain.Controls.AddRange(new System.Windows.Forms.Control[] {this.tpRecordNavigation, this.tpInsert, this.tpUpdate, this.tpDatasetExample});

        this.tcMain.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tcMain.Dock");

        this.tcMain.Enabled = (bool) resources.GetObject("tcMain.Enabled");

        this.tcMain.Font = (System.Drawing.Font) resources.GetObject("tcMain.Font");

        this.tcMain.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tcMain.ImeMode");

        this.tcMain.ItemSize = (System.Drawing.Size) resources.GetObject("tcMain.ItemSize");

        this.tcMain.Location = (System.Drawing.Point) resources.GetObject("tcMain.Location");

        this.tcMain.Name = "tcMain";

        this.tcMain.Padding = (System.Drawing.Point) resources.GetObject("tcMain.Padding");

        this.tcMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tcMain.RightToLeft");
		
		this.tcMain.SelectedIndexChanged += new EventHandler(tcMain_SelectedIndexChanged);

        this.tcMain.SelectedIndex = 0;

        this.tcMain.ShowToolTips = (bool) resources.GetObject("tcMain.ShowToolTips");

        this.tcMain.Size = (System.Drawing.Size) resources.GetObject("tcMain.Size");

        this.tcMain.TabIndex = (int) resources.GetObject("tcMain.TabIndex");

        this.tcMain.Text = resources.GetString("tcMain.Text");

        this.tcMain.Visible = (bool) resources.GetObject("tcMain.Visible");

		

        //

        //tpRecordNavigation

        //

        this.tpRecordNavigation.AccessibleDescription = (string) resources.GetObject("tpRecordNavigation.AccessibleDescription");

        this.tpRecordNavigation.AccessibleName = (string) resources.GetObject("tpRecordNavigation.AccessibleName");

        this.tpRecordNavigation.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpRecordNavigation.Anchor");

        this.tpRecordNavigation.AutoScroll = (bool) resources.GetObject("tpRecordNavigation.AutoScroll");

        this.tpRecordNavigation.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpRecordNavigation.AutoScrollMargin");

        this.tpRecordNavigation.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpRecordNavigation.AutoScrollMinSize");

        this.tpRecordNavigation.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpRecordNavigation.BackgroundImage");

        this.tpRecordNavigation.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label7, this.Label6, this.Label5, this.Label4, this.btnLast, this.btnNext, this.btnPrev, this.btnFirst, this.txtPhone, this.txtContactName, this.txtCompanyName});

        this.tpRecordNavigation.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpRecordNavigation.Dock");

        this.tpRecordNavigation.Enabled = (bool) resources.GetObject("tpRecordNavigation.Enabled");

        this.tpRecordNavigation.Font = (System.Drawing.Font) resources.GetObject("tpRecordNavigation.Font");

        this.tpRecordNavigation.ImageIndex = (int) resources.GetObject("tpRecordNavigation.ImageIndex");

        this.tpRecordNavigation.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpRecordNavigation.ImeMode");

        this.tpRecordNavigation.Location = (System.Drawing.Point) resources.GetObject("tpRecordNavigation.Location");

        this.tpRecordNavigation.Name = "tpRecordNavigation";

        this.tpRecordNavigation.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpRecordNavigation.RightToLeft");

        this.tpRecordNavigation.Size = (System.Drawing.Size) resources.GetObject("tpRecordNavigation.Size");

        this.tpRecordNavigation.TabIndex = (int) resources.GetObject("tpRecordNavigation.TabIndex");

        this.tpRecordNavigation.Text = resources.GetString("tpRecordNavigation.Text");

        this.tpRecordNavigation.ToolTipText = resources.GetString("tpRecordNavigation.ToolTipText");

        this.tpRecordNavigation.Visible = (bool) resources.GetObject("tpRecordNavigation.Visible");

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

        this.Label7.ForeColor = System.Drawing.Color.Blue;

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

		this.btnLast.Click += new EventHandler(btnLast_Click);
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

		this.btnNext.Click += new EventHandler(btnNext_Click);
        //

        //btnPrev

        //

        this.btnPrev.AccessibleDescription = (string) resources.GetObject("btnPrev.AccessibleDescription");

        this.btnPrev.AccessibleName = (string) resources.GetObject("btnPrev.AccessibleName");

        this.btnPrev.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPrev.Anchor");

        this.btnPrev.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPrev.BackgroundImage");

        this.btnPrev.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPrev.Dock");

        this.btnPrev.Enabled = (bool) resources.GetObject("btnPrev.Enabled");

        this.btnPrev.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPrev.FlatStyle");

        this.btnPrev.Font = (System.Drawing.Font) resources.GetObject("btnPrev.Font");

        this.btnPrev.Image = (System.Drawing.Image) resources.GetObject("btnPrev.Image");

        this.btnPrev.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrev.ImageAlign");

        this.btnPrev.ImageIndex = (int) resources.GetObject("btnPrev.ImageIndex");

        this.btnPrev.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPrev.ImeMode");

        this.btnPrev.Location = (System.Drawing.Point) resources.GetObject("btnPrev.Location");

        this.btnPrev.Name = "btnPrev";

        this.btnPrev.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPrev.RightToLeft");

        this.btnPrev.Size = (System.Drawing.Size) resources.GetObject("btnPrev.Size");

        this.btnPrev.TabIndex = (int) resources.GetObject("btnPrev.TabIndex");

        this.btnPrev.Text = resources.GetString("btnPrev.Text");

        this.btnPrev.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrev.TextAlign");

        this.btnPrev.Visible = (bool) resources.GetObject("btnPrev.Visible");

		this.btnPrev.Click += new EventHandler(btnPrev_Click);
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

		this.btnFirst.Click += new EventHandler(btnFirst_Click);
        //

        //txtPhone

        //

        this.txtPhone.AccessibleDescription = (string) resources.GetObject("txtPhone.AccessibleDescription");

        this.txtPhone.AccessibleName = (string) resources.GetObject("txtPhone.AccessibleName");

        this.txtPhone.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtPhone.Anchor");

        this.txtPhone.AutoSize = (bool) resources.GetObject("txtPhone.AutoSize");

        this.txtPhone.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtPhone.BackgroundImage");

        this.txtPhone.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtPhone.Dock");

        this.txtPhone.Enabled = (bool) resources.GetObject("txtPhone.Enabled");

        this.txtPhone.Font = (System.Drawing.Font) resources.GetObject("txtPhone.Font");

        this.txtPhone.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtPhone.ImeMode");

        this.txtPhone.Location = (System.Drawing.Point) resources.GetObject("txtPhone.Location");

        this.txtPhone.MaxLength = (int) resources.GetObject("txtPhone.MaxLength");

        this.txtPhone.Multiline = (bool) resources.GetObject("txtPhone.Multiline");

        this.txtPhone.Name = "txtPhone";

        this.txtPhone.PasswordChar = (char) resources.GetObject("txtPhone.PasswordChar");

        this.txtPhone.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtPhone.RightToLeft");

        this.txtPhone.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtPhone.ScrollBars");

        this.txtPhone.Size = (System.Drawing.Size) resources.GetObject("txtPhone.Size");

        this.txtPhone.TabIndex = (int) resources.GetObject("txtPhone.TabIndex");

        this.txtPhone.Text = resources.GetString("txtPhone.Text");

        this.txtPhone.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtPhone.TextAlign");

        this.txtPhone.Visible = (bool) resources.GetObject("txtPhone.Visible");

        this.txtPhone.WordWrap = (bool) resources.GetObject("txtPhone.WordWrap");

        //

        //txtContactName

        //

        this.txtContactName.AccessibleDescription = (string) resources.GetObject("txtContactName.AccessibleDescription");

        this.txtContactName.AccessibleName = (string) resources.GetObject("txtContactName.AccessibleName");

        this.txtContactName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtContactName.Anchor");

        this.txtContactName.AutoSize = (bool) resources.GetObject("txtContactName.AutoSize");

        this.txtContactName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtContactName.BackgroundImage");

        this.txtContactName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtContactName.Dock");

        this.txtContactName.Enabled = (bool) resources.GetObject("txtContactName.Enabled");

        this.txtContactName.Font = (System.Drawing.Font) resources.GetObject("txtContactName.Font");

        this.txtContactName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtContactName.ImeMode");

        this.txtContactName.Location = (System.Drawing.Point) resources.GetObject("txtContactName.Location");

        this.txtContactName.MaxLength = (int) resources.GetObject("txtContactName.MaxLength");

        this.txtContactName.Multiline = (bool) resources.GetObject("txtContactName.Multiline");

        this.txtContactName.Name = "txtContactName";

        this.txtContactName.PasswordChar = (char) resources.GetObject("txtContactName.PasswordChar");

        this.txtContactName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtContactName.RightToLeft");

        this.txtContactName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtContactName.ScrollBars");

        this.txtContactName.Size = (System.Drawing.Size) resources.GetObject("txtContactName.Size");

        this.txtContactName.TabIndex = (int) resources.GetObject("txtContactName.TabIndex");

        this.txtContactName.Text = resources.GetString("txtContactName.Text");

        this.txtContactName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtContactName.TextAlign");

        this.txtContactName.Visible = (bool) resources.GetObject("txtContactName.Visible");

        this.txtContactName.WordWrap = (bool) resources.GetObject("txtContactName.WordWrap");

        //

        //txtCompanyName

        //

        this.txtCompanyName.AccessibleDescription = (string) resources.GetObject("txtCompanyName.AccessibleDescription");

        this.txtCompanyName.AccessibleName = (string) resources.GetObject("txtCompanyName.AccessibleName");

        this.txtCompanyName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCompanyName.Anchor");

        this.txtCompanyName.AutoSize = (bool) resources.GetObject("txtCompanyName.AutoSize");

        this.txtCompanyName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCompanyName.BackgroundImage");

        this.txtCompanyName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCompanyName.Dock");

        this.txtCompanyName.Enabled = (bool) resources.GetObject("txtCompanyName.Enabled");

        this.txtCompanyName.Font = (System.Drawing.Font) resources.GetObject("txtCompanyName.Font");

        this.txtCompanyName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCompanyName.ImeMode");

        this.txtCompanyName.Location = (System.Drawing.Point) resources.GetObject("txtCompanyName.Location");

        this.txtCompanyName.MaxLength = (int) resources.GetObject("txtCompanyName.MaxLength");

        this.txtCompanyName.Multiline = (bool) resources.GetObject("txtCompanyName.Multiline");

        this.txtCompanyName.Name = "txtCompanyName";

        this.txtCompanyName.PasswordChar = (char) resources.GetObject("txtCompanyName.PasswordChar");

        this.txtCompanyName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCompanyName.RightToLeft");

        this.txtCompanyName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCompanyName.ScrollBars");

        this.txtCompanyName.Size = (System.Drawing.Size) resources.GetObject("txtCompanyName.Size");

        this.txtCompanyName.TabIndex = (int) resources.GetObject("txtCompanyName.TabIndex");

        this.txtCompanyName.Text = resources.GetString("txtCompanyName.Text");

        this.txtCompanyName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCompanyName.TextAlign");

        this.txtCompanyName.Visible = (bool) resources.GetObject("txtCompanyName.Visible");

        this.txtCompanyName.WordWrap = (bool) resources.GetObject("txtCompanyName.WordWrap");

        //

        //tpInsert

        //

        this.tpInsert.AccessibleDescription = (string) resources.GetObject("tpInsert.AccessibleDescription");

        this.tpInsert.AccessibleName = (string) resources.GetObject("tpInsert.AccessibleName");

        this.tpInsert.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpInsert.Anchor");

        this.tpInsert.AutoScroll = (bool) resources.GetObject("tpInsert.AutoScroll");

        this.tpInsert.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpInsert.AutoScrollMargin");

        this.tpInsert.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpInsert.AutoScrollMinSize");

        this.tpInsert.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpInsert.BackgroundImage");

        this.tpInsert.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label8, this.Label1, this.lblCategoryName, this.btnInsert, this.txtDescription, this.txtCategoryName});

        this.tpInsert.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpInsert.Dock");

        this.tpInsert.Enabled = (bool) resources.GetObject("tpInsert.Enabled");

        this.tpInsert.Font = (System.Drawing.Font) resources.GetObject("tpInsert.Font");

        this.tpInsert.ImageIndex = (int) resources.GetObject("tpInsert.ImageIndex");

        this.tpInsert.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpInsert.ImeMode");

        this.tpInsert.Location = (System.Drawing.Point) resources.GetObject("tpInsert.Location");

        this.tpInsert.Name = "tpInsert";

        this.tpInsert.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpInsert.RightToLeft");

        this.tpInsert.Size = (System.Drawing.Size) resources.GetObject("tpInsert.Size");

        this.tpInsert.TabIndex = (int) resources.GetObject("tpInsert.TabIndex");

        this.tpInsert.Text = resources.GetString("tpInsert.Text");

        this.tpInsert.ToolTipText = resources.GetString("tpInsert.ToolTipText");

        this.tpInsert.Visible = (bool) resources.GetObject("tpInsert.Visible");

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

        this.Label8.ForeColor = System.Drawing.Color.Blue;

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

        //lblCategoryName

        //

        this.lblCategoryName.AccessibleDescription = (string) resources.GetObject("lblCategoryName.AccessibleDescription");

        this.lblCategoryName.AccessibleName = (string) resources.GetObject("lblCategoryName.AccessibleName");

        this.lblCategoryName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblCategoryName.Anchor");

        this.lblCategoryName.AutoSize = (bool) resources.GetObject("lblCategoryName.AutoSize");

        this.lblCategoryName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblCategoryName.Dock");

        this.lblCategoryName.Enabled = (bool) resources.GetObject("lblCategoryName.Enabled");

        this.lblCategoryName.Font = (System.Drawing.Font) resources.GetObject("lblCategoryName.Font");

        this.lblCategoryName.Image = (System.Drawing.Image) resources.GetObject("lblCategoryName.Image");

        this.lblCategoryName.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCategoryName.ImageAlign");

        this.lblCategoryName.ImageIndex = (int) resources.GetObject("lblCategoryName.ImageIndex");

        this.lblCategoryName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblCategoryName.ImeMode");

        this.lblCategoryName.Location = (System.Drawing.Point) resources.GetObject("lblCategoryName.Location");

        this.lblCategoryName.Name = "lblCategoryName";

        this.lblCategoryName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblCategoryName.RightToLeft");

        this.lblCategoryName.Size = (System.Drawing.Size) resources.GetObject("lblCategoryName.Size");

        this.lblCategoryName.TabIndex = (int) resources.GetObject("lblCategoryName.TabIndex");

        this.lblCategoryName.Text = resources.GetString("lblCategoryName.Text");

        this.lblCategoryName.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCategoryName.TextAlign");

        this.lblCategoryName.Visible = (bool) resources.GetObject("lblCategoryName.Visible");

        //

        //btnInsert

        //

        this.btnInsert.AccessibleDescription = (string) resources.GetObject("btnInsert.AccessibleDescription");

        this.btnInsert.AccessibleName = (string) resources.GetObject("btnInsert.AccessibleName");

        this.btnInsert.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnInsert.Anchor");

        this.btnInsert.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnInsert.BackgroundImage");

        this.btnInsert.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnInsert.Dock");

        this.btnInsert.Enabled = (bool) resources.GetObject("btnInsert.Enabled");

        this.btnInsert.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnInsert.FlatStyle");

        this.btnInsert.Font = (System.Drawing.Font) resources.GetObject("btnInsert.Font");

        this.btnInsert.Image = (System.Drawing.Image) resources.GetObject("btnInsert.Image");

        this.btnInsert.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnInsert.ImageAlign");

        this.btnInsert.ImageIndex = (int) resources.GetObject("btnInsert.ImageIndex");

        this.btnInsert.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnInsert.ImeMode");

        this.btnInsert.Location = (System.Drawing.Point) resources.GetObject("btnInsert.Location");

        this.btnInsert.Name = "btnInsert";

        this.btnInsert.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnInsert.RightToLeft");

        this.btnInsert.Size = (System.Drawing.Size) resources.GetObject("btnInsert.Size");

        this.btnInsert.TabIndex = (int) resources.GetObject("btnInsert.TabIndex");

        this.btnInsert.Text = resources.GetString("btnInsert.Text");

        this.btnInsert.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnInsert.TextAlign");

        this.btnInsert.Visible = (bool) resources.GetObject("btnInsert.Visible");

		this.btnInsert.Click += new EventHandler(btnInsert_Click);
        //

        //txtDescription

        //

        this.txtDescription.AccessibleDescription = (string) resources.GetObject("txtDescription.AccessibleDescription");

        this.txtDescription.AccessibleName = (string) resources.GetObject("txtDescription.AccessibleName");

        this.txtDescription.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtDescription.Anchor");

        this.txtDescription.AutoSize = (bool) resources.GetObject("txtDescription.AutoSize");

        this.txtDescription.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtDescription.BackgroundImage");

        this.txtDescription.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtDescription.Dock");

        this.txtDescription.Enabled = (bool) resources.GetObject("txtDescription.Enabled");

        this.txtDescription.Font = (System.Drawing.Font) resources.GetObject("txtDescription.Font");

        this.txtDescription.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtDescription.ImeMode");

        this.txtDescription.Location = (System.Drawing.Point) resources.GetObject("txtDescription.Location");

        this.txtDescription.MaxLength = (int) resources.GetObject("txtDescription.MaxLength");

        this.txtDescription.Multiline = (bool) resources.GetObject("txtDescription.Multiline");

        this.txtDescription.Name = "txtDescription";

        this.txtDescription.PasswordChar = (char) resources.GetObject("txtDescription.PasswordChar");

        this.txtDescription.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtDescription.RightToLeft");

        this.txtDescription.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtDescription.ScrollBars");

        this.txtDescription.Size = (System.Drawing.Size) resources.GetObject("txtDescription.Size");

        this.txtDescription.TabIndex = (int) resources.GetObject("txtDescription.TabIndex");

        this.txtDescription.Text = resources.GetString("txtDescription.Text");

        this.txtDescription.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtDescription.TextAlign");

        this.txtDescription.Visible = (bool) resources.GetObject("txtDescription.Visible");

        this.txtDescription.WordWrap = (bool) resources.GetObject("txtDescription.WordWrap");

        //

        //txtCategoryName

        //

        this.txtCategoryName.AccessibleDescription = (string) resources.GetObject("txtCategoryName.AccessibleDescription");

        this.txtCategoryName.AccessibleName = (string) resources.GetObject("txtCategoryName.AccessibleName");

        this.txtCategoryName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCategoryName.Anchor");

        this.txtCategoryName.AutoSize = (bool) resources.GetObject("txtCategoryName.AutoSize");

        this.txtCategoryName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCategoryName.BackgroundImage");

        this.txtCategoryName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCategoryName.Dock");

        this.txtCategoryName.Enabled = (bool) resources.GetObject("txtCategoryName.Enabled");

        this.txtCategoryName.Font = (System.Drawing.Font) resources.GetObject("txtCategoryName.Font");

        this.txtCategoryName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCategoryName.ImeMode");

        this.txtCategoryName.Location = (System.Drawing.Point) resources.GetObject("txtCategoryName.Location");

        this.txtCategoryName.MaxLength = (int) resources.GetObject("txtCategoryName.MaxLength");

        this.txtCategoryName.Multiline = (bool) resources.GetObject("txtCategoryName.Multiline");

        this.txtCategoryName.Name = "txtCategoryName";

        this.txtCategoryName.PasswordChar = (char) resources.GetObject("txtCategoryName.PasswordChar");

        this.txtCategoryName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCategoryName.RightToLeft");

        this.txtCategoryName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCategoryName.ScrollBars");

        this.txtCategoryName.Size = (System.Drawing.Size) resources.GetObject("txtCategoryName.Size");

        this.txtCategoryName.TabIndex = (int) resources.GetObject("txtCategoryName.TabIndex");

        this.txtCategoryName.Text = resources.GetString("txtCategoryName.Text");

        this.txtCategoryName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCategoryName.TextAlign");

        this.txtCategoryName.Visible = (bool) resources.GetObject("txtCategoryName.Visible");

        this.txtCategoryName.WordWrap = (bool) resources.GetObject("txtCategoryName.WordWrap");

        //

        //tpUpdate

        //

        this.tpUpdate.AccessibleDescription = (string) resources.GetObject("tpUpdate.AccessibleDescription");

        this.tpUpdate.AccessibleName = (string) resources.GetObject("tpUpdate.AccessibleName");

        this.tpUpdate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpUpdate.Anchor");

        this.tpUpdate.AutoScroll = (bool) resources.GetObject("tpUpdate.AutoScroll");

        this.tpUpdate.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpUpdate.AutoScrollMargin");

        this.tpUpdate.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpUpdate.AutoScrollMinSize");

        this.tpUpdate.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpUpdate.BackgroundImage");

        this.tpUpdate.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label9, this.Label2, this.Label3, this.txtUpdateDescription, this.cbCategoryName, this.btnUpdate});

        this.tpUpdate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpUpdate.Dock");

        this.tpUpdate.Enabled = (bool) resources.GetObject("tpUpdate.Enabled");

        this.tpUpdate.Font = (System.Drawing.Font) resources.GetObject("tpUpdate.Font");

        this.tpUpdate.ImageIndex = (int) resources.GetObject("tpUpdate.ImageIndex");

        this.tpUpdate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpUpdate.ImeMode");

        this.tpUpdate.Location = (System.Drawing.Point) resources.GetObject("tpUpdate.Location");

        this.tpUpdate.Name = "tpUpdate";

        this.tpUpdate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpUpdate.RightToLeft");

        this.tpUpdate.Size = (System.Drawing.Size) resources.GetObject("tpUpdate.Size");

        this.tpUpdate.TabIndex = (int) resources.GetObject("tpUpdate.TabIndex");

        this.tpUpdate.Text = resources.GetString("tpUpdate.Text");

        this.tpUpdate.ToolTipText = resources.GetString("tpUpdate.ToolTipText");

        this.tpUpdate.Visible = (bool) resources.GetObject("tpUpdate.Visible");

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

        this.Label9.ForeColor = System.Drawing.Color.Blue;

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

        //txtUpdateDescription

        //

        this.txtUpdateDescription.AccessibleDescription = (string) resources.GetObject("txtUpdateDescription.AccessibleDescription");

        this.txtUpdateDescription.AccessibleName = (string) resources.GetObject("txtUpdateDescription.AccessibleName");

        this.txtUpdateDescription.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtUpdateDescription.Anchor");

        this.txtUpdateDescription.AutoSize = (bool) resources.GetObject("txtUpdateDescription.AutoSize");

        this.txtUpdateDescription.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtUpdateDescription.BackgroundImage");

        this.txtUpdateDescription.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtUpdateDescription.Dock");

        this.txtUpdateDescription.Enabled = (bool) resources.GetObject("txtUpdateDescription.Enabled");

        this.txtUpdateDescription.Font = (System.Drawing.Font) resources.GetObject("txtUpdateDescription.Font");

        this.txtUpdateDescription.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtUpdateDescription.ImeMode");

        this.txtUpdateDescription.Location = (System.Drawing.Point) resources.GetObject("txtUpdateDescription.Location");

        this.txtUpdateDescription.MaxLength = (int) resources.GetObject("txtUpdateDescription.MaxLength");

        this.txtUpdateDescription.Multiline = (bool) resources.GetObject("txtUpdateDescription.Multiline");

        this.txtUpdateDescription.Name = "txtUpdateDescription";

        this.txtUpdateDescription.PasswordChar = (char) resources.GetObject("txtUpdateDescription.PasswordChar");

        this.txtUpdateDescription.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtUpdateDescription.RightToLeft");

        this.txtUpdateDescription.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtUpdateDescription.ScrollBars");

        this.txtUpdateDescription.Size = (System.Drawing.Size) resources.GetObject("txtUpdateDescription.Size");

        this.txtUpdateDescription.TabIndex = (int) resources.GetObject("txtUpdateDescription.TabIndex");

        this.txtUpdateDescription.Text = resources.GetString("txtUpdateDescription.Text");

        this.txtUpdateDescription.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtUpdateDescription.TextAlign");

        this.txtUpdateDescription.Visible = (bool) resources.GetObject("txtUpdateDescription.Visible");

        this.txtUpdateDescription.WordWrap = (bool) resources.GetObject("txtUpdateDescription.WordWrap");

        //

        //cbCategoryName

        //

        this.cbCategoryName.AccessibleDescription = resources.GetString("cbCategoryName.AccessibleDescription");

        this.cbCategoryName.AccessibleName = resources.GetString("cbCategoryName.AccessibleName");

        this.cbCategoryName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cbCategoryName.Anchor");

        this.cbCategoryName.BackgroundImage = (System.Drawing.Image) resources.GetObject("cbCategoryName.BackgroundImage");

        this.cbCategoryName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cbCategoryName.Dock");

        this.cbCategoryName.Enabled = (bool) resources.GetObject("cbCategoryName.Enabled");

        this.cbCategoryName.Font = (System.Drawing.Font) resources.GetObject("cbCategoryName.Font");

        this.cbCategoryName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cbCategoryName.ImeMode");

        this.cbCategoryName.IntegralHeight = (bool) resources.GetObject("cbCategoryName.IntegralHeight");

        this.cbCategoryName.ItemHeight = (int) resources.GetObject("cbCategoryName.ItemHeight");

        this.cbCategoryName.Location = (System.Drawing.Point) resources.GetObject("cbCategoryName.Location");

        this.cbCategoryName.MaxDropDownItems = (int) resources.GetObject("cbCategoryName.MaxDropDownItems");

        this.cbCategoryName.MaxLength = (int) resources.GetObject("cbCategoryName.MaxLength");

        this.cbCategoryName.Name = "cbCategoryName";

        this.cbCategoryName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cbCategoryName.RightToLeft");

        this.cbCategoryName.Size = (System.Drawing.Size) resources.GetObject("cbCategoryName.Size");

        this.cbCategoryName.TabIndex = (int) resources.GetObject("cbCategoryName.TabIndex");

        this.cbCategoryName.Text = resources.GetString("cbCategoryName.Text");

        this.cbCategoryName.Visible = (bool) resources.GetObject("cbCategoryName.Visible");

		this.cbCategoryName.SelectedIndexChanged += new EventHandler(cbCategoryName_SelectedIndexChanged);

        //

        //btnUpdate

        //

        this.btnUpdate.AccessibleDescription = resources.GetString("btnUpdate.AccessibleDescription");

        this.btnUpdate.AccessibleName = resources.GetString("btnUpdate.AccessibleName");

        this.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnUpdate.Anchor");

        this.btnUpdate.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnUpdate.BackgroundImage");

        this.btnUpdate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnUpdate.Dock");

        this.btnUpdate.Enabled = (bool) resources.GetObject("btnUpdate.Enabled");

        this.btnUpdate.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnUpdate.FlatStyle");

        this.btnUpdate.Font = (System.Drawing.Font) resources.GetObject("btnUpdate.Font");

        this.btnUpdate.Image = (System.Drawing.Image) resources.GetObject("btnUpdate.Image");

        this.btnUpdate.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUpdate.ImageAlign");

        this.btnUpdate.ImageIndex = (int) resources.GetObject("btnUpdate.ImageIndex");

        this.btnUpdate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnUpdate.ImeMode");

        this.btnUpdate.Location = (System.Drawing.Point) resources.GetObject("btnUpdate.Location");

        this.btnUpdate.Name = "btnUpdate";

        this.btnUpdate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnUpdate.RightToLeft");

        this.btnUpdate.Size = (System.Drawing.Size) resources.GetObject("btnUpdate.Size");

        this.btnUpdate.TabIndex = (int) resources.GetObject("btnUpdate.TabIndex");

        this.btnUpdate.Text = resources.GetString("btnUpdate.Text");

        this.btnUpdate.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUpdate.TextAlign");

        this.btnUpdate.Visible = (bool) resources.GetObject("btnUpdate.Visible");

		this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        //

        //tpDatasetExample

        //

        this.tpDatasetExample.AccessibleDescription = (string) resources.GetObject("tpDatasetExample.AccessibleDescription");

        this.tpDatasetExample.AccessibleName = (string) resources.GetObject("tpDatasetExample.AccessibleName");

        this.tpDatasetExample.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpDatasetExample.Anchor");

        this.tpDatasetExample.AutoScroll = (bool) resources.GetObject("tpDatasetExample.AutoScroll");

        this.tpDatasetExample.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpDatasetExample.AutoScrollMargin");

        this.tpDatasetExample.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpDatasetExample.AutoScrollMinSize");

        this.tpDatasetExample.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpDatasetExample.BackgroundImage");

        this.tpDatasetExample.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label10, this.btnDataset, this.dgMain});

        this.tpDatasetExample.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpDatasetExample.Dock");

        this.tpDatasetExample.Enabled = (bool) resources.GetObject("tpDatasetExample.Enabled");

        this.tpDatasetExample.Font = (System.Drawing.Font) resources.GetObject("tpDatasetExample.Font");

        this.tpDatasetExample.ImageIndex = (int) resources.GetObject("tpDatasetExample.ImageIndex");

        this.tpDatasetExample.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpDatasetExample.ImeMode");

        this.tpDatasetExample.Location = (System.Drawing.Point) resources.GetObject("tpDatasetExample.Location");

        this.tpDatasetExample.Name = "tpDatasetExample";

        this.tpDatasetExample.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpDatasetExample.RightToLeft");

        this.tpDatasetExample.Size = (System.Drawing.Size) resources.GetObject("tpDatasetExample.Size");

        this.tpDatasetExample.TabIndex = (int) resources.GetObject("tpDatasetExample.TabIndex");

        this.tpDatasetExample.Text = resources.GetString("tpDatasetExample.Text");

        this.tpDatasetExample.ToolTipText = resources.GetString("tpDatasetExample.ToolTipText");

        this.tpDatasetExample.Visible = (bool) resources.GetObject("tpDatasetExample.Visible");

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

        this.Label10.ForeColor = System.Drawing.Color.Blue;

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

        //btnDataset

        //

        this.btnDataset.AccessibleDescription = resources.GetString("btnDataset.AccessibleDescription");

        this.btnDataset.AccessibleName = resources.GetString("btnDataset.AccessibleName");

        this.btnDataset.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnDataset.Anchor");

        this.btnDataset.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnDataset.BackgroundImage");

        this.btnDataset.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnDataset.Dock");

        this.btnDataset.Enabled = (bool) resources.GetObject("btnDataset.Enabled");

        this.btnDataset.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnDataset.FlatStyle");

        this.btnDataset.Font = (System.Drawing.Font) resources.GetObject("btnDataset.Font");

        this.btnDataset.Image = (System.Drawing.Image) resources.GetObject("btnDataset.Image");

        this.btnDataset.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDataset.ImageAlign");

        this.btnDataset.ImageIndex = (int) resources.GetObject("btnDataset.ImageIndex");

        this.btnDataset.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnDataset.ImeMode");

        this.btnDataset.Location = (System.Drawing.Point) resources.GetObject("btnDataset.Location");

        this.btnDataset.Name = "btnDataset";

        this.btnDataset.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnDataset.RightToLeft");

        this.btnDataset.Size = (System.Drawing.Size) resources.GetObject("btnDataset.Size");

        this.btnDataset.TabIndex = (int) resources.GetObject("btnDataset.TabIndex");

        this.btnDataset.Text = resources.GetString("btnDataset.Text");

        this.btnDataset.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDataset.TextAlign");

        this.btnDataset.Visible = (bool) resources.GetObject("btnDataset.Visible");
		
		this.btnDataset.Click += new EventHandler(btnDataset_Click);
        //

        //dgMain

        //

        this.dgMain.AccessibleDescription = resources.GetString("dgMain.AccessibleDescription");

        this.dgMain.AccessibleName = resources.GetString("dgMain.AccessibleName");

        this.dgMain.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("dgMain.Anchor");

        this.dgMain.BackgroundImage = (System.Drawing.Image) resources.GetObject("dgMain.BackgroundImage");

        this.dgMain.CaptionFont = (System.Drawing.Font) resources.GetObject("dgMain.CaptionFont");

        this.dgMain.CaptionText = resources.GetString("dgMain.CaptionText");

        this.dgMain.DataMember = string.Empty;

        this.dgMain.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("dgMain.Dock");

        this.dgMain.Enabled = (bool) resources.GetObject("dgMain.Enabled");

        this.dgMain.Font = (System.Drawing.Font) resources.GetObject("dgMain.Font");

        this.dgMain.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.dgMain.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("dgMain.ImeMode");

        this.dgMain.Location = (System.Drawing.Point) resources.GetObject("dgMain.Location");

        this.dgMain.Name = "dgMain";

        this.dgMain.ReadOnly = true;

        this.dgMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("dgMain.RightToLeft");

        this.dgMain.Size = (System.Drawing.Size) resources.GetObject("dgMain.Size");

        this.dgMain.TabIndex = (int) resources.GetObject("dgMain.TabIndex");

        this.dgMain.Visible = (bool) resources.GetObject("dgMain.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.tcMain});

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

        this.tcMain.ResumeLayout(false);

        this.tpRecordNavigation.ResumeLayout(false);

        this.tpInsert.ResumeLayout(false);

        this.tpUpdate.ResumeLayout(false);

        this.tpDatasetExample.ResumeLayout(false);

        ((System.ComponentModel.ISupportInitialize) this.dgMain).EndInit(); 

		
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

    private void btnDataset_Click(object sender, System.EventArgs e)
	{
        // An ADO 2.6 connection and recordset are created to pull back
        // data using a SELECT statement.  A data adapter and dataset are
        // created.  The data Adapters fill method is used to populate
        // the dataset with the data in the ADO 2.6 recordset.
        // The dataset is then assigned to the data grid control.
		object ra = null;
        string strSQL  = "SELECT CustomerID, " + "       CompanyName, " + "       ContactName, " + "       COuntry, " + "       Region, " + "       Phone, " + "       Fax " + "FROM Customers";
        rs = cnn.Execute(strSQL,out ra,0);

        // Create Dataset and data adapter objects
        DataSet ds = new DataSet("Recordset");
        OleDbDataAdapter da = new OleDbDataAdapter();

        // Call data adapter's Fill method to fill data from ADO
        // Recordset to ADO.NET dataset
        da.Fill(ds, rs, "Customers");

        // Assign data set to grid control
        dgMain.DataSource = ds;
        dgMain.DataMember = "Customers";
    }

    private void btnFirst_Click(object sender, System.EventArgs e)
	{
        rs.MoveFirst();
        PopulateSimpleNavigationForm();
    }

    private void btnLast_Click(object sender, System.EventArgs e)
	{
        rs.MoveLast();
        PopulateSimpleNavigationForm();
    }

    private void btnNext_Click(object sender, System.EventArgs e)
	{
        // this code is used to prevent going to EOF
        if (!rs.EOF) {
            rs.MoveNext();
            if (rs.EOF) {
                rs.MovePrevious();
            }
            PopulateSimpleNavigationForm();
        }
    }

    private void btnPrev_Click(object sender, System.EventArgs e)
	{
        // this code is used to prevent going to BOF
        if (!rs.BOF) {
            rs.MovePrevious();
            if (rs.BOF) {
                rs.MoveNext();
            }
            PopulateSimpleNavigationForm();
        }
    }

    private void btnInsert_Click(object sender, System.EventArgs e)
	{
        // This event will insert a new record into the Categories table
        // Validate form
        if ((txtCategoryName.Text == "") || (txtDescription.Text == "")) {

            MessageBox.Show("Please fill in all the text boxes.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        Object recordsEffected;
        string strSQL  = "INSERT INTO Categories(CategoryName, Description) " + "VALUES ('" + txtCategoryName.Text + "','" + txtDescription.Text + "')";

        // Execute SQL statement
        cnn.Execute(strSQL, out recordsEffected, 0);

        if (Convert.ToInt32(recordsEffected) == 1) {
				MessageBox.Show("Insert Successful!", this.Text, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }
    }

    private void btnUpdate_Click(object sender, System.EventArgs e)
	{
        // This event updates the description field of the categories
        // table with the value in the description text box
        if (txtUpdateDescription.Text == "") 
		{
            MessageBox.Show("Please fill in description text box.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string strSQL  = "UPDATE Categories SET Description = " + "'" + txtUpdateDescription.Text + "' " + "WHERE CategoryName = " + "'" + cbCategoryName.Text + "'";
        cm.ActiveConnection = cnn;
        cm.CommandText = strSQL;
        Object recordsEffected;
		Object parameters = 0;
        cm.Execute(out recordsEffected, ref parameters,0);

        // Check to see if 1 record was effected
		if (Convert.ToInt32(recordsEffected) > 0) 
		{
			MessageBox.Show("Update Successful!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else 
		{
			MessageBox.Show("Update Failed!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
    }

    private void cbCategoryName_SelectedIndexChanged(object sender, System.EventArgs e)
	{
        // This event controls what heppens when a category is selected
        // on the Update example.
        // When a category is selected the description is displayed
        // in the test box so the user can change it.

        string strSQL  = "SELECT Description " + "FROM Categories " + "WHERE CategoryName = '" + cbCategoryName.Text + "'";

        rs.ActiveConnection = cnn;
        rs.CursorType = CursorTypeEnum.adOpenStatic;
        rs.Open(strSQL,cnn,ADODB.CursorTypeEnum.adOpenDynamic,ADODB.LockTypeEnum.adLockOptimistic,0);

        // Set the text box to the value in the result
        txtUpdateDescription.Text = Convert.ToString(rs.Fields["Description"].Value);
        rs.Close();
    }

    private void tcMain_SelectedIndexChanged(object sender, System.EventArgs e)
	{
        // Close recordset if tab is changed
        if (rs.State == 1) 
		{
            rs.Close();
        }

        // Run init subs for sertain tabs when they are selected
        switch( tcMain.SelectedIndex )
		{

            case 0:
                InitRecordNavigation();
				break;

            case 2:
                InitSimpleUpdate();
				break;
        }
    }

    private void InitRecordNavigation()
	{
        // Simple code showing how to connect to a database
        // using ADO 2.6 and navigate a recordset

        frmStatus frmStatusMessage = new frmStatus();
        if (!HasConnected) 
		{
            frmStatusMessage.Show("Connecting to SQL Server");

            // Attempt to connect to SQL server or MSDE
            bool IsConnecting  = true;

            while (IsConnecting)
			{
                try {
                    // Open a Connection 
                    cnn.ConnectionTimeout = 5;
                    cnn.Open(Connectionstring, null,null,0);

                    if (cnn.State != 1) 
					{
                        throw new System.Exception("Connection failed.");
                    }
                    if (!HasConnected) 
					{
                        frmStatusMessage.Close();
                    }
                    IsConnecting = false;
                    HasConnected = true;
               } 
				catch
				{
					if (Connectionstring == SQL_CONNECTION_STRING) 
					{
						// Couldn't connect to SQL server. Now try MSDE
						Connectionstring = MSDE_CONNECTION_STRING;
						frmStatusMessage.Show("Connecting to MSDE");
					}
					else 
					{
						// Unable to connect to SQL Server or MSDE
						frmStatusMessage.Close();

						MessageBox.Show("To run this sample you must have SQL Server ot MSDE with the Northwind database installed.  For instructions on installing MSDE, view the Readme file." + MessageBoxIcon.Warning + "SQL Server/MSDE not found");
						// Quit program if neither connection method was successful.
						Application.Exit();
					}
                }
            }
        }

        // Build SQL statement.
        string strSQL  = "SELECT CompanyName, " + "       ContactName, " + "       Phone " + "FROM Customers";

        rs.ActiveConnection = cnn;
        rs.CursorType = CursorTypeEnum.adOpenStatic;
        rs.Open(strSQL,cnn,ADODB.CursorTypeEnum.adOpenDynamic,ADODB.LockTypeEnum.adLockOptimistic,0);
        rs.MoveFirst();
    }

    private void InitSimpleUpdate()
	{
        // Populate Combo box with categories
        string strSQL  = "SELECT CategoryName " + "FROM Categories";

        rs.ActiveConnection = cnn;
        rs.CursorType = CursorTypeEnum.adOpenStatic;
        rs.Open(strSQL,cnn,ADODB.CursorTypeEnum.adOpenDynamic,ADODB.LockTypeEnum.adLockOptimistic,0);
        // Loop through records and add them to the combo box

        while (!rs.EOF)
		{
            cbCategoryName.Items.Add(rs.Fields["CategoryName"].Value);
            rs.MoveNext();
        }

        rs.Close();
        cbCategoryName.SelectedIndex = 0;
    }

    private void PopulateSimpleNavigationForm()
	{
        // Populate form with data from recordset
        txtCompanyName.Text = Convert.ToString(rs.Fields["CompanyName"].Value);

        txtContactName.Text = Convert.ToString(rs.Fields["ContactName"].Value);
        txtPhone.Text = Convert.ToString(rs.Fields["Phone"].Value);
    }

}

