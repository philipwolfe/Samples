//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Data;


public class frmMain : System.Windows.Forms.Form {
    // dsCustomers will hold all customers in the USA
    protected CustomersDataSet dsCustomers = new CustomersDataSet();
    protected CustomersDataSet dsCustomerChanges = new CustomersDataSet();
    protected SqlDataAdapter daCustomers;

    // Used to reference the table containing employee information in 
    // Employee Data.
    protected const string CUSTOMER_TABLE_NAME  = "Customers";
    protected const string SQL_CONNECTION_STRING  = "Server=localhost;" + 
													"DataBase=Northwind;" + 
													"Integrated Security=SSPI";

    protected const string MSDE_CONNECTION_STRING  = "Server=(local)/NetSDK;" + 
											         "DataBase=Northwind;" + 
													 "Integrated Security=SSPI";

    bool DidPreviouslyConnect = false;
    bool IsAdding  = false;

#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

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

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.TextBox tbCustomerID;

    private System.Windows.Forms.TextBox tbCompanyName;

    private System.Windows.Forms.TextBox tbContactName;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.TextBox tbContactTitle;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.TextBox tbAddress;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.TextBox tbCity;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.Label Label7;

    private System.Windows.Forms.TextBox tbRegion;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.TextBox tbPostalCode;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.TextBox tbPhone;

    private System.Windows.Forms.TextBox tbFax;

    private System.Windows.Forms.Label Label10;

    private System.Windows.Forms.Button bnLast;

    private System.Windows.Forms.Button bnNext;

    private System.Windows.Forms.Button bnPrev;

    private System.Windows.Forms.Button bnFirst;

    private System.Windows.Forms.Label lblPosition;

    private System.Windows.Forms.Button bnCancel;

    private System.Windows.Forms.Button bnDelete;

    private System.Windows.Forms.Button bnAdd;

    private System.Windows.Forms.Button bnCancelAll;

    private System.Windows.Forms.Label Label11;

    private System.Windows.Forms.TextBox tbCountry;

    private System.Windows.Forms.Button bnReset;

    private System.Windows.Forms.CheckBox chkWorkOffline;

    private System.Windows.Forms.Button bnSaveCustomers;

    private System.Windows.Forms.Button bnGetCustomers;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.Label1 = new System.Windows.Forms.Label();

        this.Label2 = new System.Windows.Forms.Label();

        this.tbCustomerID = new System.Windows.Forms.TextBox();

        this.tbCompanyName = new System.Windows.Forms.TextBox();

        this.tbContactName = new System.Windows.Forms.TextBox();

        this.Label3 = new System.Windows.Forms.Label();

        this.tbContactTitle = new System.Windows.Forms.TextBox();

        this.Label4 = new System.Windows.Forms.Label();

        this.tbAddress = new System.Windows.Forms.TextBox();

        this.Label5 = new System.Windows.Forms.Label();

        this.tbCity = new System.Windows.Forms.TextBox();

        this.Label6 = new System.Windows.Forms.Label();

        this.Label7 = new System.Windows.Forms.Label();

        this.tbRegion = new System.Windows.Forms.TextBox();

        this.Label8 = new System.Windows.Forms.Label();

        this.tbPostalCode = new System.Windows.Forms.TextBox();

        this.Label9 = new System.Windows.Forms.Label();

        this.tbPhone = new System.Windows.Forms.TextBox();

        this.tbFax = new System.Windows.Forms.TextBox();

        this.Label10 = new System.Windows.Forms.Label();

        this.bnLast = new System.Windows.Forms.Button();

        this.bnNext = new System.Windows.Forms.Button();

        this.bnPrev = new System.Windows.Forms.Button();

        this.bnFirst = new System.Windows.Forms.Button();

        this.lblPosition = new System.Windows.Forms.Label();

        this.bnAdd = new System.Windows.Forms.Button();

        this.bnSaveCustomers = new System.Windows.Forms.Button();

        this.bnDelete = new System.Windows.Forms.Button();

        this.bnCancel = new System.Windows.Forms.Button();

        this.bnCancelAll = new System.Windows.Forms.Button();

        this.tbCountry = new System.Windows.Forms.TextBox();

        this.Label11 = new System.Windows.Forms.Label();

        this.bnGetCustomers = new System.Windows.Forms.Button();

        this.bnReset = new System.Windows.Forms.Button();

        this.chkWorkOffline = new System.Windows.Forms.CheckBox();

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

        //tbCustomerID

        //

        this.tbCustomerID.AccessibleDescription = resources.GetString("tbCustomerID.AccessibleDescription");

        this.tbCustomerID.AccessibleName = resources.GetString("tbCustomerID.AccessibleName");

        this.tbCustomerID.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbCustomerID.Anchor");

        this.tbCustomerID.AutoSize = (bool) resources.GetObject("tbCustomerID.AutoSize");

        this.tbCustomerID.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbCustomerID.BackgroundImage");

        this.tbCustomerID.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbCustomerID.Dock");

        this.tbCustomerID.Enabled = (bool) resources.GetObject("tbCustomerID.Enabled");

        this.tbCustomerID.Font = (System.Drawing.Font) resources.GetObject("tbCustomerID.Font");

        this.tbCustomerID.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbCustomerID.ImeMode");

        this.tbCustomerID.Location = (System.Drawing.Point) resources.GetObject("tbCustomerID.Location");

        this.tbCustomerID.MaxLength = (int) resources.GetObject("tbCustomerID.MaxLength");

        this.tbCustomerID.Multiline = (bool) resources.GetObject("tbCustomerID.Multiline");

        this.tbCustomerID.Name = "tbCustomerID";

        this.tbCustomerID.PasswordChar = (char) resources.GetObject("tbCustomerID.PasswordChar");

        this.tbCustomerID.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbCustomerID.RightToLeft");

        this.tbCustomerID.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbCustomerID.ScrollBars");

        this.tbCustomerID.Size = (System.Drawing.Size) resources.GetObject("tbCustomerID.Size");

        this.tbCustomerID.TabIndex = (int) resources.GetObject("tbCustomerID.TabIndex");

        this.tbCustomerID.Text = resources.GetString("tbCustomerID.Text");

        this.tbCustomerID.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbCustomerID.TextAlign");

        this.tbCustomerID.Visible = (bool) resources.GetObject("tbCustomerID.Visible");

        this.tbCustomerID.WordWrap = (bool) resources.GetObject("tbCustomerID.WordWrap");

        //

        //tbCompanyName

        //

        this.tbCompanyName.AccessibleDescription = resources.GetString("tbCompanyName.AccessibleDescription");

        this.tbCompanyName.AccessibleName = resources.GetString("tbCompanyName.AccessibleName");

        this.tbCompanyName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbCompanyName.Anchor");

        this.tbCompanyName.AutoSize = (bool) resources.GetObject("tbCompanyName.AutoSize");

        this.tbCompanyName.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbCompanyName.BackgroundImage");

        this.tbCompanyName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbCompanyName.Dock");

        this.tbCompanyName.Enabled = (bool) resources.GetObject("tbCompanyName.Enabled");

        this.tbCompanyName.Font = (System.Drawing.Font) resources.GetObject("tbCompanyName.Font");

        this.tbCompanyName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbCompanyName.ImeMode");

        this.tbCompanyName.Location = (System.Drawing.Point) resources.GetObject("tbCompanyName.Location");

        this.tbCompanyName.MaxLength = (int) resources.GetObject("tbCompanyName.MaxLength");

        this.tbCompanyName.Multiline = (bool) resources.GetObject("tbCompanyName.Multiline");

        this.tbCompanyName.Name = "tbCompanyName";

        this.tbCompanyName.PasswordChar = (char) resources.GetObject("tbCompanyName.PasswordChar");

        this.tbCompanyName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbCompanyName.RightToLeft");

        this.tbCompanyName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbCompanyName.ScrollBars");

        this.tbCompanyName.Size = (System.Drawing.Size) resources.GetObject("tbCompanyName.Size");

        this.tbCompanyName.TabIndex = (int) resources.GetObject("tbCompanyName.TabIndex");

        this.tbCompanyName.Text = resources.GetString("tbCompanyName.Text");

        this.tbCompanyName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbCompanyName.TextAlign");

        this.tbCompanyName.Visible = (bool) resources.GetObject("tbCompanyName.Visible");

        this.tbCompanyName.WordWrap = (bool) resources.GetObject("tbCompanyName.WordWrap");

        //

        //tbContactName

        //

        this.tbContactName.AccessibleDescription = resources.GetString("tbContactName.AccessibleDescription");

        this.tbContactName.AccessibleName = resources.GetString("tbContactName.AccessibleName");

        this.tbContactName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbContactName.Anchor");

        this.tbContactName.AutoSize = (bool) resources.GetObject("tbContactName.AutoSize");

        this.tbContactName.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbContactName.BackgroundImage");

        this.tbContactName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbContactName.Dock");

        this.tbContactName.Enabled = (bool) resources.GetObject("tbContactName.Enabled");

        this.tbContactName.Font = (System.Drawing.Font) resources.GetObject("tbContactName.Font");

        this.tbContactName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbContactName.ImeMode");

        this.tbContactName.Location = (System.Drawing.Point) resources.GetObject("tbContactName.Location");

        this.tbContactName.MaxLength = (int) resources.GetObject("tbContactName.MaxLength");

        this.tbContactName.Multiline = (bool) resources.GetObject("tbContactName.Multiline");

        this.tbContactName.Name = "tbContactName";

        this.tbContactName.PasswordChar = (char) resources.GetObject("tbContactName.PasswordChar");

        this.tbContactName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbContactName.RightToLeft");

        this.tbContactName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbContactName.ScrollBars");

        this.tbContactName.Size = (System.Drawing.Size) resources.GetObject("tbContactName.Size");

        this.tbContactName.TabIndex = (int) resources.GetObject("tbContactName.TabIndex");

        this.tbContactName.Text = resources.GetString("tbContactName.Text");

        this.tbContactName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbContactName.TextAlign");

        this.tbContactName.Visible = (bool) resources.GetObject("tbContactName.Visible");

        this.tbContactName.WordWrap = (bool) resources.GetObject("tbContactName.WordWrap");

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

        //tbContactTitle

        //

        this.tbContactTitle.AccessibleDescription = resources.GetString("tbContactTitle.AccessibleDescription");

        this.tbContactTitle.AccessibleName = resources.GetString("tbContactTitle.AccessibleName");

        this.tbContactTitle.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbContactTitle.Anchor");

        this.tbContactTitle.AutoSize = (bool) resources.GetObject("tbContactTitle.AutoSize");

        this.tbContactTitle.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbContactTitle.BackgroundImage");

        this.tbContactTitle.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbContactTitle.Dock");

        this.tbContactTitle.Enabled = (bool) resources.GetObject("tbContactTitle.Enabled");

        this.tbContactTitle.Font = (System.Drawing.Font) resources.GetObject("tbContactTitle.Font");

        this.tbContactTitle.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbContactTitle.ImeMode");

        this.tbContactTitle.Location = (System.Drawing.Point) resources.GetObject("tbContactTitle.Location");

        this.tbContactTitle.MaxLength = (int) resources.GetObject("tbContactTitle.MaxLength");

        this.tbContactTitle.Multiline = (bool) resources.GetObject("tbContactTitle.Multiline");

        this.tbContactTitle.Name = "tbContactTitle";

        this.tbContactTitle.PasswordChar = (char) resources.GetObject("tbContactTitle.PasswordChar");

        this.tbContactTitle.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbContactTitle.RightToLeft");

        this.tbContactTitle.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbContactTitle.ScrollBars");

        this.tbContactTitle.Size = (System.Drawing.Size) resources.GetObject("tbContactTitle.Size");

        this.tbContactTitle.TabIndex = (int) resources.GetObject("tbContactTitle.TabIndex");

        this.tbContactTitle.Text = resources.GetString("tbContactTitle.Text");

        this.tbContactTitle.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbContactTitle.TextAlign");

        this.tbContactTitle.Visible = (bool) resources.GetObject("tbContactTitle.Visible");

        this.tbContactTitle.WordWrap = (bool) resources.GetObject("tbContactTitle.WordWrap");

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

        //tbAddress

        //

        this.tbAddress.AccessibleDescription = resources.GetString("tbAddress.AccessibleDescription");

        this.tbAddress.AccessibleName = resources.GetString("tbAddress.AccessibleName");

        this.tbAddress.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbAddress.Anchor");

        this.tbAddress.AutoSize = (bool) resources.GetObject("tbAddress.AutoSize");

        this.tbAddress.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbAddress.BackgroundImage");

        this.tbAddress.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbAddress.Dock");

        this.tbAddress.Enabled = (bool) resources.GetObject("tbAddress.Enabled");

        this.tbAddress.Font = (System.Drawing.Font) resources.GetObject("tbAddress.Font");

        this.tbAddress.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbAddress.ImeMode");

        this.tbAddress.Location = (System.Drawing.Point) resources.GetObject("tbAddress.Location");

        this.tbAddress.MaxLength = (int) resources.GetObject("tbAddress.MaxLength");

        this.tbAddress.Multiline = (bool) resources.GetObject("tbAddress.Multiline");

        this.tbAddress.Name = "tbAddress";

        this.tbAddress.PasswordChar = (char) resources.GetObject("tbAddress.PasswordChar");

        this.tbAddress.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbAddress.RightToLeft");

        this.tbAddress.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbAddress.ScrollBars");

        this.tbAddress.Size = (System.Drawing.Size) resources.GetObject("tbAddress.Size");

        this.tbAddress.TabIndex = (int) resources.GetObject("tbAddress.TabIndex");

        this.tbAddress.Text = resources.GetString("tbAddress.Text");

        this.tbAddress.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbAddress.TextAlign");

        this.tbAddress.Visible = (bool) resources.GetObject("tbAddress.Visible");

        this.tbAddress.WordWrap = (bool) resources.GetObject("tbAddress.WordWrap");

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

        //tbCity

        //

        this.tbCity.AccessibleDescription = resources.GetString("tbCity.AccessibleDescription");

        this.tbCity.AccessibleName = resources.GetString("tbCity.AccessibleName");

        this.tbCity.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbCity.Anchor");

        this.tbCity.AutoSize = (bool) resources.GetObject("tbCity.AutoSize");

        this.tbCity.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbCity.BackgroundImage");

        this.tbCity.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbCity.Dock");

        this.tbCity.Enabled = (bool) resources.GetObject("tbCity.Enabled");

        this.tbCity.Font = (System.Drawing.Font) resources.GetObject("tbCity.Font");

        this.tbCity.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbCity.ImeMode");

        this.tbCity.Location = (System.Drawing.Point) resources.GetObject("tbCity.Location");

        this.tbCity.MaxLength = (int) resources.GetObject("tbCity.MaxLength");

        this.tbCity.Multiline = (bool) resources.GetObject("tbCity.Multiline");

        this.tbCity.Name = "tbCity";

        this.tbCity.PasswordChar = (char) resources.GetObject("tbCity.PasswordChar");

        this.tbCity.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbCity.RightToLeft");

        this.tbCity.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbCity.ScrollBars");

        this.tbCity.Size = (System.Drawing.Size) resources.GetObject("tbCity.Size");

        this.tbCity.TabIndex = (int) resources.GetObject("tbCity.TabIndex");

        this.tbCity.Text = resources.GetString("tbCity.Text");

        this.tbCity.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbCity.TextAlign");

        this.tbCity.Visible = (bool) resources.GetObject("tbCity.Visible");

        this.tbCity.WordWrap = (bool) resources.GetObject("tbCity.WordWrap");

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

        //tbRegion

        //

        this.tbRegion.AccessibleDescription = resources.GetString("tbRegion.AccessibleDescription");

        this.tbRegion.AccessibleName = resources.GetString("tbRegion.AccessibleName");

        this.tbRegion.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbRegion.Anchor");

        this.tbRegion.AutoSize = (bool) resources.GetObject("tbRegion.AutoSize");

        this.tbRegion.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbRegion.BackgroundImage");

        this.tbRegion.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbRegion.Dock");

        this.tbRegion.Enabled = (bool) resources.GetObject("tbRegion.Enabled");

        this.tbRegion.Font = (System.Drawing.Font) resources.GetObject("tbRegion.Font");

        this.tbRegion.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbRegion.ImeMode");

        this.tbRegion.Location = (System.Drawing.Point) resources.GetObject("tbRegion.Location");

        this.tbRegion.MaxLength = (int) resources.GetObject("tbRegion.MaxLength");

        this.tbRegion.Multiline = (bool) resources.GetObject("tbRegion.Multiline");

        this.tbRegion.Name = "tbRegion";

        this.tbRegion.PasswordChar = (char) resources.GetObject("tbRegion.PasswordChar");

        this.tbRegion.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbRegion.RightToLeft");

        this.tbRegion.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbRegion.ScrollBars");

        this.tbRegion.Size = (System.Drawing.Size) resources.GetObject("tbRegion.Size");

        this.tbRegion.TabIndex = (int) resources.GetObject("tbRegion.TabIndex");

        this.tbRegion.Text = resources.GetString("tbRegion.Text");

        this.tbRegion.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbRegion.TextAlign");

        this.tbRegion.Visible = (bool) resources.GetObject("tbRegion.Visible");

        this.tbRegion.WordWrap = (bool) resources.GetObject("tbRegion.WordWrap");

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

        //tbPostalCode

        //

        this.tbPostalCode.AccessibleDescription = resources.GetString("tbPostalCode.AccessibleDescription");

        this.tbPostalCode.AccessibleName = resources.GetString("tbPostalCode.AccessibleName");

        this.tbPostalCode.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbPostalCode.Anchor");

        this.tbPostalCode.AutoSize = (bool) resources.GetObject("tbPostalCode.AutoSize");

        this.tbPostalCode.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbPostalCode.BackgroundImage");

        this.tbPostalCode.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbPostalCode.Dock");

        this.tbPostalCode.Enabled = (bool) resources.GetObject("tbPostalCode.Enabled");

        this.tbPostalCode.Font = (System.Drawing.Font) resources.GetObject("tbPostalCode.Font");

        this.tbPostalCode.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbPostalCode.ImeMode");

        this.tbPostalCode.Location = (System.Drawing.Point) resources.GetObject("tbPostalCode.Location");

        this.tbPostalCode.MaxLength = (int) resources.GetObject("tbPostalCode.MaxLength");

        this.tbPostalCode.Multiline = (bool) resources.GetObject("tbPostalCode.Multiline");

        this.tbPostalCode.Name = "tbPostalCode";

        this.tbPostalCode.PasswordChar = (char) resources.GetObject("tbPostalCode.PasswordChar");

        this.tbPostalCode.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbPostalCode.RightToLeft");

        this.tbPostalCode.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbPostalCode.ScrollBars");

        this.tbPostalCode.Size = (System.Drawing.Size) resources.GetObject("tbPostalCode.Size");

        this.tbPostalCode.TabIndex = (int) resources.GetObject("tbPostalCode.TabIndex");

        this.tbPostalCode.Text = resources.GetString("tbPostalCode.Text");

        this.tbPostalCode.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbPostalCode.TextAlign");

        this.tbPostalCode.Visible = (bool) resources.GetObject("tbPostalCode.Visible");

        this.tbPostalCode.WordWrap = (bool) resources.GetObject("tbPostalCode.WordWrap");

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

        //tbPhone

        //

        this.tbPhone.AccessibleDescription = resources.GetString("tbPhone.AccessibleDescription");

        this.tbPhone.AccessibleName = resources.GetString("tbPhone.AccessibleName");

        this.tbPhone.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbPhone.Anchor");

        this.tbPhone.AutoSize = (bool) resources.GetObject("tbPhone.AutoSize");

        this.tbPhone.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbPhone.BackgroundImage");

        this.tbPhone.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbPhone.Dock");

        this.tbPhone.Enabled = (bool) resources.GetObject("tbPhone.Enabled");

        this.tbPhone.Font = (System.Drawing.Font) resources.GetObject("tbPhone.Font");

        this.tbPhone.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbPhone.ImeMode");

        this.tbPhone.Location = (System.Drawing.Point) resources.GetObject("tbPhone.Location");

        this.tbPhone.MaxLength = (int) resources.GetObject("tbPhone.MaxLength");

        this.tbPhone.Multiline = (bool) resources.GetObject("tbPhone.Multiline");

        this.tbPhone.Name = "tbPhone";

        this.tbPhone.PasswordChar = (char) resources.GetObject("tbPhone.PasswordChar");

        this.tbPhone.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbPhone.RightToLeft");

        this.tbPhone.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbPhone.ScrollBars");

        this.tbPhone.Size = (System.Drawing.Size) resources.GetObject("tbPhone.Size");

        this.tbPhone.TabIndex = (int) resources.GetObject("tbPhone.TabIndex");

        this.tbPhone.Text = resources.GetString("tbPhone.Text");

        this.tbPhone.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbPhone.TextAlign");

        this.tbPhone.Visible = (bool) resources.GetObject("tbPhone.Visible");

        this.tbPhone.WordWrap = (bool) resources.GetObject("tbPhone.WordWrap");

        //

        //tbFax

        //

        this.tbFax.AccessibleDescription = resources.GetString("tbFax.AccessibleDescription");

        this.tbFax.AccessibleName = resources.GetString("tbFax.AccessibleName");

        this.tbFax.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbFax.Anchor");

        this.tbFax.AutoSize = (bool) resources.GetObject("tbFax.AutoSize");

        this.tbFax.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbFax.BackgroundImage");

        this.tbFax.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbFax.Dock");

        this.tbFax.Enabled = (bool) resources.GetObject("tbFax.Enabled");

        this.tbFax.Font = (System.Drawing.Font) resources.GetObject("tbFax.Font");

        this.tbFax.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbFax.ImeMode");

        this.tbFax.Location = (System.Drawing.Point) resources.GetObject("tbFax.Location");

        this.tbFax.MaxLength = (int) resources.GetObject("tbFax.MaxLength");

        this.tbFax.Multiline = (bool) resources.GetObject("tbFax.Multiline");

        this.tbFax.Name = "tbFax";

        this.tbFax.PasswordChar = (char) resources.GetObject("tbFax.PasswordChar");

        this.tbFax.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbFax.RightToLeft");

        this.tbFax.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbFax.ScrollBars");

        this.tbFax.Size = (System.Drawing.Size) resources.GetObject("tbFax.Size");

        this.tbFax.TabIndex = (int) resources.GetObject("tbFax.TabIndex");

        this.tbFax.Text = resources.GetString("tbFax.Text");

        this.tbFax.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbFax.TextAlign");

        this.tbFax.Visible = (bool) resources.GetObject("tbFax.Visible");

        this.tbFax.WordWrap = (bool) resources.GetObject("tbFax.WordWrap");

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

        //bnLast

        //

        this.bnLast.AccessibleDescription = (string) resources.GetObject("bnLast.AccessibleDescription");

        this.bnLast.AccessibleName = resources.GetString("bnLast.AccessibleName");

        this.bnLast.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnLast.Anchor");

        this.bnLast.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnLast.BackgroundImage");

        this.bnLast.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnLast.Dock");

        this.bnLast.Enabled = (bool) resources.GetObject("bnLast.Enabled");

        this.bnLast.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnLast.FlatStyle");

        this.bnLast.Font = (System.Drawing.Font) resources.GetObject("bnLast.Font");

        this.bnLast.Image = (System.Drawing.Image) resources.GetObject("bnLast.Image");

        this.bnLast.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnLast.ImageAlign");

        this.bnLast.ImageIndex = (int) resources.GetObject("bnLast.ImageIndex");

        this.bnLast.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnLast.ImeMode");

        this.bnLast.Location = (System.Drawing.Point) resources.GetObject("bnLast.Location");

        this.bnLast.Name = "bnLast";

        this.bnLast.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnLast.RightToLeft");

        this.bnLast.Size = (System.Drawing.Size) resources.GetObject("bnLast.Size");

        this.bnLast.TabIndex = (int) resources.GetObject("bnLast.TabIndex");

        this.bnLast.Text = resources.GetString("bnLast.Text");

        this.bnLast.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnLast.TextAlign");

        this.bnLast.Visible = (bool) resources.GetObject("bnLast.Visible");

		this.bnLast.Click += new EventHandler(bnLast_Click);

        //

        //bnNext

        //

        this.bnNext.AccessibleDescription = (string) resources.GetObject("bnNext.AccessibleDescription");

        this.bnNext.AccessibleName = resources.GetString("bnNext.AccessibleName");

        this.bnNext.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnNext.Anchor");

        this.bnNext.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnNext.BackgroundImage");

        this.bnNext.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnNext.Dock");

        this.bnNext.Enabled = (bool) resources.GetObject("bnNext.Enabled");

        this.bnNext.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnNext.FlatStyle");

        this.bnNext.Font = (System.Drawing.Font) resources.GetObject("bnNext.Font");

        this.bnNext.Image = (System.Drawing.Image) resources.GetObject("bnNext.Image");

        this.bnNext.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnNext.ImageAlign");

        this.bnNext.ImageIndex = (int) resources.GetObject("bnNext.ImageIndex");

        this.bnNext.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnNext.ImeMode");

        this.bnNext.Location = (System.Drawing.Point) resources.GetObject("bnNext.Location");

        this.bnNext.Name = "bnNext";

        this.bnNext.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnNext.RightToLeft");

        this.bnNext.Size = (System.Drawing.Size) resources.GetObject("bnNext.Size");

        this.bnNext.TabIndex = (int) resources.GetObject("bnNext.TabIndex");

        this.bnNext.Text = resources.GetString("bnNext.Text");

        this.bnNext.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnNext.TextAlign");

        this.bnNext.Visible = (bool) resources.GetObject("bnNext.Visible");

		this.bnNext.Click += new EventHandler(bnNext_Click);

        //

        //bnPrev

        //

        this.bnPrev.AccessibleDescription = (string) resources.GetObject("bnPrev.AccessibleDescription");

        this.bnPrev.AccessibleName = resources.GetString("bnPrev.AccessibleName");

        this.bnPrev.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnPrev.Anchor");

        this.bnPrev.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnPrev.BackgroundImage");

        this.bnPrev.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnPrev.Dock");

        this.bnPrev.Enabled = (bool) resources.GetObject("bnPrev.Enabled");

        this.bnPrev.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnPrev.FlatStyle");

        this.bnPrev.Font = (System.Drawing.Font) resources.GetObject("bnPrev.Font");

        this.bnPrev.Image = (System.Drawing.Image) resources.GetObject("bnPrev.Image");

        this.bnPrev.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnPrev.ImageAlign");

        this.bnPrev.ImageIndex = (int) resources.GetObject("bnPrev.ImageIndex");

        this.bnPrev.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnPrev.ImeMode");

        this.bnPrev.Location = (System.Drawing.Point) resources.GetObject("bnPrev.Location");

        this.bnPrev.Name = "bnPrev";

        this.bnPrev.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnPrev.RightToLeft");

        this.bnPrev.Size = (System.Drawing.Size) resources.GetObject("bnPrev.Size");

        this.bnPrev.TabIndex = (int) resources.GetObject("bnPrev.TabIndex");

        this.bnPrev.Text = resources.GetString("bnPrev.Text");

        this.bnPrev.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnPrev.TextAlign");

        this.bnPrev.Visible = (bool) resources.GetObject("bnPrev.Visible");

		this.bnPrev.Click += new EventHandler(bnPrev_Click);

        //

        //bnFirst

        //

        this.bnFirst.AccessibleDescription = (string) resources.GetObject("bnFirst.AccessibleDescription");

        this.bnFirst.AccessibleName = resources.GetString("bnFirst.AccessibleName");

        this.bnFirst.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnFirst.Anchor");

        this.bnFirst.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnFirst.BackgroundImage");

        this.bnFirst.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnFirst.Dock");

        this.bnFirst.Enabled = (bool) resources.GetObject("bnFirst.Enabled");

        this.bnFirst.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnFirst.FlatStyle");

        this.bnFirst.Font = (System.Drawing.Font) resources.GetObject("bnFirst.Font");

        this.bnFirst.Image = (System.Drawing.Image) resources.GetObject("bnFirst.Image");

        this.bnFirst.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnFirst.ImageAlign");

        this.bnFirst.ImageIndex = (int) resources.GetObject("bnFirst.ImageIndex");

        this.bnFirst.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnFirst.ImeMode");

        this.bnFirst.Location = (System.Drawing.Point) resources.GetObject("bnFirst.Location");

        this.bnFirst.Name = "bnFirst";

        this.bnFirst.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnFirst.RightToLeft");

        this.bnFirst.Size = (System.Drawing.Size) resources.GetObject("bnFirst.Size");

        this.bnFirst.TabIndex = (int) resources.GetObject("bnFirst.TabIndex");

        this.bnFirst.Text = resources.GetString("bnFirst.Text");

        this.bnFirst.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnFirst.TextAlign");

        this.bnFirst.Visible = (bool) resources.GetObject("bnFirst.Visible");

		this.bnFirst.Click += new EventHandler(bnFirst_Click);

        //

        //lblPosition

        //

        this.lblPosition.AccessibleDescription = resources.GetString("lblPosition.AccessibleDescription");

        this.lblPosition.AccessibleName = resources.GetString("lblPosition.AccessibleName");

        this.lblPosition.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblPosition.Anchor");

        this.lblPosition.AutoSize = (bool) resources.GetObject("lblPosition.AutoSize");

        this.lblPosition.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblPosition.Dock");

        this.lblPosition.Enabled = (bool) resources.GetObject("lblPosition.Enabled");

        this.lblPosition.Font = (System.Drawing.Font) resources.GetObject("lblPosition.Font");

        this.lblPosition.Image = (System.Drawing.Image) resources.GetObject("lblPosition.Image");

        this.lblPosition.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblPosition.ImageAlign");

        this.lblPosition.ImageIndex = (int) resources.GetObject("lblPosition.ImageIndex");

        this.lblPosition.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblPosition.ImeMode");

        this.lblPosition.Location = (System.Drawing.Point) resources.GetObject("lblPosition.Location");

        this.lblPosition.Name = "lblPosition";

        this.lblPosition.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblPosition.RightToLeft");

        this.lblPosition.Size = (System.Drawing.Size) resources.GetObject("lblPosition.Size");

        this.lblPosition.TabIndex = (int) resources.GetObject("lblPosition.TabIndex");

        this.lblPosition.Text = resources.GetString("lblPosition.Text");

        this.lblPosition.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblPosition.TextAlign");

        this.lblPosition.Visible = (bool) resources.GetObject("lblPosition.Visible");

        //

        //bnAdd

        //

        this.bnAdd.AccessibleDescription = resources.GetString("bnAdd.AccessibleDescription");

        this.bnAdd.AccessibleName = resources.GetString("bnAdd.AccessibleName");

        this.bnAdd.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnAdd.Anchor");

        this.bnAdd.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnAdd.BackgroundImage");

        this.bnAdd.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnAdd.Dock");

        this.bnAdd.Enabled = (bool) resources.GetObject("bnAdd.Enabled");

        this.bnAdd.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnAdd.FlatStyle");

        this.bnAdd.Font = (System.Drawing.Font) resources.GetObject("bnAdd.Font");

        this.bnAdd.Image = (System.Drawing.Image) resources.GetObject("bnAdd.Image");

        this.bnAdd.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnAdd.ImageAlign");

        this.bnAdd.ImageIndex = (int) resources.GetObject("bnAdd.ImageIndex");

        this.bnAdd.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnAdd.ImeMode");

        this.bnAdd.Location = (System.Drawing.Point) resources.GetObject("bnAdd.Location");

        this.bnAdd.Name = "bnAdd";

        this.bnAdd.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnAdd.RightToLeft");

        this.bnAdd.Size = (System.Drawing.Size) resources.GetObject("bnAdd.Size");

        this.bnAdd.TabIndex = (int) resources.GetObject("bnAdd.TabIndex");

        this.bnAdd.Text = resources.GetString("bnAdd.Text");

        this.bnAdd.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnAdd.TextAlign");

        this.bnAdd.Visible = (bool) resources.GetObject("bnAdd.Visible");

		this.bnAdd.Click += new EventHandler(bnAdd_Click);

        //

        //bnSaveCustomers

        //

        this.bnSaveCustomers.AccessibleDescription = resources.GetString("bnSaveCustomers.AccessibleDescription");

        this.bnSaveCustomers.AccessibleName = resources.GetString("bnSaveCustomers.AccessibleName");

        this.bnSaveCustomers.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnSaveCustomers.Anchor");

        this.bnSaveCustomers.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnSaveCustomers.BackgroundImage");

        this.bnSaveCustomers.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnSaveCustomers.Dock");

        this.bnSaveCustomers.Enabled = (bool) resources.GetObject("bnSaveCustomers.Enabled");

        this.bnSaveCustomers.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnSaveCustomers.FlatStyle");

        this.bnSaveCustomers.Font = (System.Drawing.Font) resources.GetObject("bnSaveCustomers.Font");

        this.bnSaveCustomers.Image = (System.Drawing.Image) resources.GetObject("bnSaveCustomers.Image");

        this.bnSaveCustomers.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnSaveCustomers.ImageAlign");

        this.bnSaveCustomers.ImageIndex = (int) resources.GetObject("bnSaveCustomers.ImageIndex");

        this.bnSaveCustomers.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnSaveCustomers.ImeMode");

        this.bnSaveCustomers.Location = (System.Drawing.Point) resources.GetObject("bnSaveCustomers.Location");

        this.bnSaveCustomers.Name = "bnSaveCustomers";

        this.bnSaveCustomers.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnSaveCustomers.RightToLeft");

        this.bnSaveCustomers.Size = (System.Drawing.Size) resources.GetObject("bnSaveCustomers.Size");

        this.bnSaveCustomers.TabIndex = (int) resources.GetObject("bnSaveCustomers.TabIndex");

        this.bnSaveCustomers.Text = resources.GetString("bnSaveCustomers.Text");

        this.bnSaveCustomers.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnSaveCustomers.TextAlign");

        this.bnSaveCustomers.Visible = (bool) resources.GetObject("bnSaveCustomers.Visible");

		this.bnSaveCustomers.Click += new EventHandler(bnSaveCustomers_Click);

        //

        //bnDelete

        //

        this.bnDelete.AccessibleDescription = resources.GetString("bnDelete.AccessibleDescription");

        this.bnDelete.AccessibleName = resources.GetString("bnDelete.AccessibleName");

        this.bnDelete.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnDelete.Anchor");

        this.bnDelete.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnDelete.BackgroundImage");

        this.bnDelete.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnDelete.Dock");

        this.bnDelete.Enabled = (bool) resources.GetObject("bnDelete.Enabled");

        this.bnDelete.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnDelete.FlatStyle");

        this.bnDelete.Font = (System.Drawing.Font) resources.GetObject("bnDelete.Font");

        this.bnDelete.Image = (System.Drawing.Image) resources.GetObject("bnDelete.Image");

        this.bnDelete.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnDelete.ImageAlign");

        this.bnDelete.ImageIndex = (int) resources.GetObject("bnDelete.ImageIndex");

        this.bnDelete.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnDelete.ImeMode");

        this.bnDelete.Location = (System.Drawing.Point) resources.GetObject("bnDelete.Location");

        this.bnDelete.Name = "bnDelete";

        this.bnDelete.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnDelete.RightToLeft");

        this.bnDelete.Size = (System.Drawing.Size) resources.GetObject("bnDelete.Size");

        this.bnDelete.TabIndex = (int) resources.GetObject("bnDelete.TabIndex");

        this.bnDelete.Text = resources.GetString("bnDelete.Text");

        this.bnDelete.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnDelete.TextAlign");

        this.bnDelete.Visible = (bool) resources.GetObject("bnDelete.Visible");

		this.bnDelete.Click += new EventHandler(bnDelete_Click);

        //

        //bnCancel

        //

        this.bnCancel.AccessibleDescription = resources.GetString("bnCancel.AccessibleDescription");

        this.bnCancel.AccessibleName = resources.GetString("bnCancel.AccessibleName");

        this.bnCancel.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnCancel.Anchor");

        this.bnCancel.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnCancel.BackgroundImage");

        this.bnCancel.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnCancel.Dock");

        this.bnCancel.Enabled = (bool) resources.GetObject("bnCancel.Enabled");

        this.bnCancel.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnCancel.FlatStyle");

        this.bnCancel.Font = (System.Drawing.Font) resources.GetObject("bnCancel.Font");

        this.bnCancel.Image = (System.Drawing.Image) resources.GetObject("bnCancel.Image");

        this.bnCancel.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnCancel.ImageAlign");

        this.bnCancel.ImageIndex = (int) resources.GetObject("bnCancel.ImageIndex");

        this.bnCancel.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnCancel.ImeMode");

        this.bnCancel.Location = (System.Drawing.Point) resources.GetObject("bnCancel.Location");

        this.bnCancel.Name = "bnCancel";

        this.bnCancel.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnCancel.RightToLeft");

        this.bnCancel.Size = (System.Drawing.Size) resources.GetObject("bnCancel.Size");

        this.bnCancel.TabIndex = (int) resources.GetObject("bnCancel.TabIndex");

        this.bnCancel.Text = resources.GetString("bnCancel.Text");

        this.bnCancel.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnCancel.TextAlign");

        this.bnCancel.Visible = (bool) resources.GetObject("bnCancel.Visible");

		this.bnCancel.Click += new EventHandler(bnCancel_Click);

        //

        //bnCancelAll

        //

        this.bnCancelAll.AccessibleDescription = resources.GetString("bnCancelAll.AccessibleDescription");

        this.bnCancelAll.AccessibleName = resources.GetString("bnCancelAll.AccessibleName");

        this.bnCancelAll.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnCancelAll.Anchor");

        this.bnCancelAll.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnCancelAll.BackgroundImage");

        this.bnCancelAll.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnCancelAll.Dock");

        this.bnCancelAll.Enabled = (bool) resources.GetObject("bnCancelAll.Enabled");

        this.bnCancelAll.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnCancelAll.FlatStyle");

        this.bnCancelAll.Font = (System.Drawing.Font) resources.GetObject("bnCancelAll.Font");

        this.bnCancelAll.Image = (System.Drawing.Image) resources.GetObject("bnCancelAll.Image");

        this.bnCancelAll.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnCancelAll.ImageAlign");

        this.bnCancelAll.ImageIndex = (int) resources.GetObject("bnCancelAll.ImageIndex");

        this.bnCancelAll.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnCancelAll.ImeMode");

        this.bnCancelAll.Location = (System.Drawing.Point) resources.GetObject("bnCancelAll.Location");

        this.bnCancelAll.Name = "bnCancelAll";

        this.bnCancelAll.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnCancelAll.RightToLeft");

        this.bnCancelAll.Size = (System.Drawing.Size) resources.GetObject("bnCancelAll.Size");

        this.bnCancelAll.TabIndex = (int) resources.GetObject("bnCancelAll.TabIndex");

        this.bnCancelAll.Text = resources.GetString("bnCancelAll.Text");

        this.bnCancelAll.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnCancelAll.TextAlign");

        this.bnCancelAll.Visible = (bool) resources.GetObject("bnCancelAll.Visible");

		this.bnCancelAll.Click += new EventHandler(bnCancelAll_Click);

        //

        //tbCountry

        //

        this.tbCountry.AccessibleDescription = resources.GetString("tbCountry.AccessibleDescription");

        this.tbCountry.AccessibleName = resources.GetString("tbCountry.AccessibleName");

        this.tbCountry.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tbCountry.Anchor");

        this.tbCountry.AutoSize = (bool) resources.GetObject("tbCountry.AutoSize");

        this.tbCountry.BackgroundImage = (System.Drawing.Image) resources.GetObject("tbCountry.BackgroundImage");

        this.tbCountry.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tbCountry.Dock");

        this.tbCountry.Enabled = (bool) resources.GetObject("tbCountry.Enabled");

        this.tbCountry.Font = (System.Drawing.Font) resources.GetObject("tbCountry.Font");

        this.tbCountry.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tbCountry.ImeMode");

        this.tbCountry.Location = (System.Drawing.Point) resources.GetObject("tbCountry.Location");

        this.tbCountry.MaxLength = (int) resources.GetObject("tbCountry.MaxLength");

        this.tbCountry.Multiline = (bool) resources.GetObject("tbCountry.Multiline");

        this.tbCountry.Name = "tbCountry";

        this.tbCountry.PasswordChar = (char) resources.GetObject("tbCountry.PasswordChar");

        this.tbCountry.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tbCountry.RightToLeft");

        this.tbCountry.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("tbCountry.ScrollBars");

        this.tbCountry.Size = (System.Drawing.Size) resources.GetObject("tbCountry.Size");

        this.tbCountry.TabIndex = (int) resources.GetObject("tbCountry.TabIndex");

        this.tbCountry.Text = resources.GetString("tbCountry.Text");

        this.tbCountry.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("tbCountry.TextAlign");

        this.tbCountry.Visible = (bool) resources.GetObject("tbCountry.Visible");

        this.tbCountry.WordWrap = (bool) resources.GetObject("tbCountry.WordWrap");

        //

        //Label11

        //

        this.Label11.AccessibleDescription = (string) resources.GetObject("Label11.AccessibleDescription");

        this.Label11.AccessibleName = (string) resources.GetObject("Label11.AccessibleName");

        this.Label11.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label11.Anchor");

        this.Label11.AutoSize = (bool) resources.GetObject("Label11.AutoSize");

        this.Label11.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label11.Dock");

        this.Label11.Enabled = (bool) resources.GetObject("Label11.Enabled");

        this.Label11.Font = (System.Drawing.Font) resources.GetObject("Label11.Font");

        this.Label11.Image = (System.Drawing.Image) resources.GetObject("Label11.Image");

        this.Label11.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label11.ImageAlign");

        this.Label11.ImageIndex = (int) resources.GetObject("Label11.ImageIndex");

        this.Label11.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label11.ImeMode");

        this.Label11.Location = (System.Drawing.Point) resources.GetObject("Label11.Location");

        this.Label11.Name = "Label11";

        this.Label11.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label11.RightToLeft");

        this.Label11.Size = (System.Drawing.Size) resources.GetObject("Label11.Size");

        this.Label11.TabIndex = (int) resources.GetObject("Label11.TabIndex");

        this.Label11.Text = resources.GetString("Label11.Text");

        this.Label11.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label11.TextAlign");

        this.Label11.Visible = (bool) resources.GetObject("Label11.Visible");

        //

        //bnGetCustomers

        //

        this.bnGetCustomers.AccessibleDescription = resources.GetString("bnGetCustomers.AccessibleDescription");

        this.bnGetCustomers.AccessibleName = resources.GetString("bnGetCustomers.AccessibleName");

        this.bnGetCustomers.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnGetCustomers.Anchor");

        this.bnGetCustomers.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnGetCustomers.BackgroundImage");

        this.bnGetCustomers.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnGetCustomers.Dock");

        this.bnGetCustomers.Enabled = (bool) resources.GetObject("bnGetCustomers.Enabled");

        this.bnGetCustomers.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnGetCustomers.FlatStyle");

        this.bnGetCustomers.Font = (System.Drawing.Font) resources.GetObject("bnGetCustomers.Font");

        this.bnGetCustomers.Image = (System.Drawing.Image) resources.GetObject("bnGetCustomers.Image");

        this.bnGetCustomers.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnGetCustomers.ImageAlign");

        this.bnGetCustomers.ImageIndex = (int) resources.GetObject("bnGetCustomers.ImageIndex");

        this.bnGetCustomers.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnGetCustomers.ImeMode");

        this.bnGetCustomers.Location = (System.Drawing.Point) resources.GetObject("bnGetCustomers.Location");

        this.bnGetCustomers.Name = "bnGetCustomers";

        this.bnGetCustomers.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnGetCustomers.RightToLeft");

        this.bnGetCustomers.Size = (System.Drawing.Size) resources.GetObject("bnGetCustomers.Size");

        this.bnGetCustomers.TabIndex = (int) resources.GetObject("bnGetCustomers.TabIndex");

        this.bnGetCustomers.Text = resources.GetString("bnGetCustomers.Text");

        this.bnGetCustomers.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnGetCustomers.TextAlign");

        this.bnGetCustomers.Visible = (bool) resources.GetObject("bnGetCustomers.Visible");

		this.bnGetCustomers.Click += new EventHandler(bnGetCustomers_Click);

        //

        //bnReset

        //

        this.bnReset.AccessibleDescription = resources.GetString("bnReset.AccessibleDescription");

        this.bnReset.AccessibleName = resources.GetString("bnReset.AccessibleName");

        this.bnReset.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("bnReset.Anchor");

        this.bnReset.BackgroundImage = (System.Drawing.Image) resources.GetObject("bnReset.BackgroundImage");

        this.bnReset.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("bnReset.Dock");

        this.bnReset.Enabled = (bool) resources.GetObject("bnReset.Enabled");

        this.bnReset.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("bnReset.FlatStyle");

        this.bnReset.Font = (System.Drawing.Font) resources.GetObject("bnReset.Font");

        this.bnReset.Image = (System.Drawing.Image) resources.GetObject("bnReset.Image");

        this.bnReset.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnReset.ImageAlign");

        this.bnReset.ImageIndex = (int) resources.GetObject("bnReset.ImageIndex");

        this.bnReset.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("bnReset.ImeMode");

        this.bnReset.Location = (System.Drawing.Point) resources.GetObject("bnReset.Location");

        this.bnReset.Name = "bnReset";

        this.bnReset.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("bnReset.RightToLeft");

        this.bnReset.Size = (System.Drawing.Size) resources.GetObject("bnReset.Size");

        this.bnReset.TabIndex = (int) resources.GetObject("bnReset.TabIndex");

        this.bnReset.Text = resources.GetString("bnReset.Text");

        this.bnReset.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("bnReset.TextAlign");

        this.bnReset.Visible = (bool) resources.GetObject("bnReset.Visible");

		this.bnReset.Click += new EventHandler(bnReset_Click);

        //

        //chkWorkOffline

        //

        this.chkWorkOffline.AccessibleDescription = (string) resources.GetObject("chkWorkOffline.AccessibleDescription");

        this.chkWorkOffline.AccessibleName = (string) resources.GetObject("chkWorkOffline.AccessibleName");

        this.chkWorkOffline.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkWorkOffline.Anchor");

        this.chkWorkOffline.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkWorkOffline.Appearance");

        this.chkWorkOffline.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkWorkOffline.BackgroundImage");

        this.chkWorkOffline.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkWorkOffline.CheckAlign");

        this.chkWorkOffline.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkWorkOffline.Dock");

        this.chkWorkOffline.Enabled = (bool) resources.GetObject("chkWorkOffline.Enabled");

        this.chkWorkOffline.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkWorkOffline.FlatStyle");

        this.chkWorkOffline.Font = (System.Drawing.Font) resources.GetObject("chkWorkOffline.Font");

        this.chkWorkOffline.Image = (System.Drawing.Image) resources.GetObject("chkWorkOffline.Image");

        this.chkWorkOffline.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkWorkOffline.ImageAlign");

        this.chkWorkOffline.ImageIndex = (int) resources.GetObject("chkWorkOffline.ImageIndex");

        this.chkWorkOffline.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkWorkOffline.ImeMode");

        this.chkWorkOffline.Location = (System.Drawing.Point) resources.GetObject("chkWorkOffline.Location");

        this.chkWorkOffline.Name = "chkWorkOffline";

        this.chkWorkOffline.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkWorkOffline.RightToLeft");

        this.chkWorkOffline.Size = (System.Drawing.Size) resources.GetObject("chkWorkOffline.Size");

        this.chkWorkOffline.TabIndex = (int) resources.GetObject("chkWorkOffline.TabIndex");

        this.chkWorkOffline.Text = resources.GetString("chkWorkOffline.Text");

        this.chkWorkOffline.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkWorkOffline.TextAlign");

        this.chkWorkOffline.Visible = (bool) resources.GetObject("chkWorkOffline.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkWorkOffline, this.bnReset, this.bnGetCustomers, this.Label11, this.tbCountry, this.bnCancelAll, this.bnCancel, this.bnDelete, this.bnSaveCustomers, this.bnAdd, this.lblPosition, this.bnFirst, this.bnPrev, this.bnNext, this.bnLast, this.Label10, this.tbFax, this.tbPhone, this.Label9, this.tbPostalCode, this.Label8, this.tbRegion, this.Label7, this.Label6, this.tbCity, this.Label5, this.tbAddress, this.Label4, this.tbContactTitle, this.Label3, this.tbContactName, this.tbCompanyName, this.tbCustomerID, this.Label2, this.Label1});

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

    private void bnAdd_Click(object sender, System.EventArgs e)
	{
        try {
            //Close any editing
            BindingContext[dsCustomers, "Customers"].EndCurrentEdit();
            BindingContext[dsCustomers, "Customers"].AddNew();
			
       } 
		catch( Exception exc )
		{
            MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }

        // Adding a new record.  View State enables buttons
        // based on this value

        IsAdding = true;
        UpdateViewState();
    }

    private void bnCancel_Click(object sender, System.EventArgs e) 
	{
        // return row to original value
        BindingContext[dsCustomers, "Customers"].CancelCurrentEdit();
        IsAdding = false;
        UpdateViewState();
    }

    private void bnCancelAll_Click(object sender, System.EventArgs e)
	{
        // return Dataset to original values
        dsCustomers.Customers.RejectChanges();
    }

    private void bnDelete_Click(object sender, System.EventArgs e) 
	{
        //Use Delete method instead of the RemoveAt method
        //when the Dataset will update a data source

        dsCustomers.Customers[BindingContext[dsCustomers, "Customers"].Position].Delete();
        UpdateViewState();
    }

    private void bnFirst_Click(object sender, System.EventArgs e)
	{
        BindingContext[dsCustomers, "Customers"].Position = 0;
        UpdateViewState();
    }

    private void bnGetCustomers_Click(object sender, System.EventArgs e)
	{
        // Data can be retrieved from XML or the server

		if (chkWorkOffline.Checked) 
		{
			dsCustomers = GetCustomersFromXML();
		}
		else 
		{
			dsCustomers = GetCustomersFromServer();
		}

        BindData();
        UpdateViewState();
    }

    private void bnLast_Click(object sender, System.EventArgs e)
	{
        BindingContext[dsCustomers, "Customers"].Position = BindingContext[dsCustomers, "Customers"].Count;
        UpdateViewState();
    }

    private void bnNext_Click(object sender, System.EventArgs e)
	{
        BindingContext[dsCustomers, "Customers"].Position += 1;
        UpdateViewState();
    }

    private void bnPrev_Click(object sender, System.EventArgs e) 
	{
        BindingContext[dsCustomers, "Customers"].Position -= 1;
        UpdateViewState();
    }

    private void bnReset_Click(object sender, System.EventArgs e)
	{
        // Empty Customers table
        dsCustomers.Customers.Clear();
        // Update Viewstate to allow retrieval of data
        UpdateViewState();
    }

    private void bnSaveCustomers_Click(object sender, System.EventArgs e)
	{
        // Flush changes into DataSet
        BindingContext[dsCustomers, "Customers"].EndCurrentEdit();

        // Updates can be performed in XML or the server
		if (chkWorkOffline.Checked) 
		{
			// Send Dataset to be written to XML file
			SaveCustomersInXML(dsCustomers);
		}
		else 
		{
			// Extract changed records from dsCustomers DataSet
			dsCustomerChanges = (CustomersDataSet) dsCustomers.GetChanges();
			// Update data source if changes exist and merge back into
			// current DataSet
			if ( !(dsCustomerChanges == null))
			{
				dsCustomerChanges = SaveCustomersOnServer(dsCustomerChanges);
				// Merge changes into Dataset if any are returned
				if (!(dsCustomerChanges == null)) 
				{
					dsCustomers.Merge(dsCustomerChanges);
				}
			}
		}
    }

    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        // Copy Customers table to CustomersHT to
        // prevent foreign key constraint errors

        SetupTable();
        UpdateViewState();
    }

    void BindData()
	{
        // Clear all data bindings
        tbCustomerID.DataBindings.Clear();

        tbCompanyName.DataBindings.Clear();

        tbContactName.DataBindings.Clear();

        tbContactTitle.DataBindings.Clear();

        tbAddress.DataBindings.Clear();

        tbCity.DataBindings.Clear();

        tbRegion.DataBindings.Clear();

        tbPostalCode.DataBindings.Clear();

        tbCountry.DataBindings.Clear();

        tbPhone.DataBindings.Clear();

        tbFax.DataBindings.Clear();

        // Bind the control's property to a field in dsCustomers
        // so that the data will display that control.  DataBinding will
        // manage the displaying of the data the user navigates, inserts, 
        // updates and deletes the data in the dataset.

        tbCustomerID.DataBindings.Add("Text", dsCustomers, "Customers.CustomerID");

        tbCompanyName.DataBindings.Add("Text", dsCustomers, "Customers.CompanyName");

        tbContactName.DataBindings.Add("Text", dsCustomers, "Customers.ContactName");

        tbContactTitle.DataBindings.Add("Text", dsCustomers, "Customers.ContactTitle");

        tbAddress.DataBindings.Add("Text", dsCustomers, "Customers.Address");

        tbCity.DataBindings.Add("Text", dsCustomers, "Customers.City");

        tbRegion.DataBindings.Add("Text", dsCustomers, "Customers.Region");

        tbPostalCode.DataBindings.Add("Text", dsCustomers, "Customers.PostalCode");

        tbCountry.DataBindings.Add("Text", dsCustomers, "Customers.Country");

        tbPhone.DataBindings.Add("Text", dsCustomers, "Customers.Phone");

        tbFax.DataBindings.Add("Text", dsCustomers, "Customers.Fax");

    }

    CustomersDataSet GetCustomersFromServer()
	{
        // Gets customer records from CustomersHT table in the
        // Northwind database.

        string Connectionstring = SQL_CONNECTION_STRING;
        CustomersDataSet ds = new CustomersDataSet();

        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();

        if (! DidPreviouslyConnect) {
            frmStatusMessage.Show("Connecting to SQL Server");
        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool IsConnecting  = true;

        while (IsConnecting)
		{
            try {

                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in to SQL Server, or be part of the Administrators
                // group on your local machine for this to work.

                SqlConnection cnNorthwind = new SqlConnection(Connectionstring);

                // The SqlDataAdapter is used to populate a DataSet
                daCustomers = new SqlDataAdapter("SELECT CustomerID, CompanyName, ContactName, ContactTitle, " +
												 "Address, City, Region, PostalCode, Country, Phone, Fax " +
												 "FROM Customers", cnNorthwind);

                // Populate the Dataset with the information from the customers
                // table.  Since a Dataset can hold multiple result sets, it's
                // a good idea to "name" the result set when you populate the
                // DataSet.  In this case, the result set is named "Customers".

                daCustomers.Fill(ds, "Customers");

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
					"instructions on installing MSDE, view the ReadMe file.",
					"SQL Server/MSDE not found",
					MessageBoxButtons.OK, 
					MessageBoxIcon.Exclamation);
					Application.Exit();
				}
            }
        }
        frmStatusMessage.Close();
        daCustomers.Dispose();
        return ds;
    }

    CustomersDataSet GetCustomersFromXML()
	{
       CustomersDataSet ds = new CustomersDataSet();

        // Reads the XML file into the DataSet.  Use the DiffGram
        // mode so that RowState data can be used to update the 
        // data source when the SQL Data Adapter's Update method
        // is called.  The DiffGram mode must also be used when the
        // DataSet's WriteXML method was called.

        try 
		{
            ds.ReadXml("../dsCustomers.xml", XmlReadMode.DiffGram);
            ds.Tables[0].TableName = "Customers";
       } 
		catch(FileNotFoundException FileNotFound )
		{
            // The XML data must be written before it can be read
            MessageBox.Show(FileNotFound.Message, "No XML file available.  View data online and save to offline.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        return ds;
    }

    CustomersDataSet SaveCustomersOnServer(CustomersDataSet dsCustomerChanges )
	{
        // Update CustomersHT table with changes from the DataSet
       string Connectionstring  = SQL_CONNECTION_STRING;

        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

       frmStatus frmStatusMessage = new frmStatus();

        if (! DidPreviouslyConnect) {
            frmStatusMessage.Show("Connecting to SQL Server");
        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool IsConnecting = true;

        while (IsConnecting)
		{
            try {
                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in to SQL Server, or be part of the Administrators
                // group on your local machine for this to work.

               SqlConnection cnNorthwind = new SqlConnection(Connectionstring);

                // The SqlDataAdapter is used to populate a DataSet
                daCustomers = new SqlDataAdapter("SELECT CustomerID, CompanyName, ContactName, ContactTitle, " 
                      + "Address, City, Region, PostalCode, Country, Phone, Fax " 
                    + "FROM CustomersHT", 
                    cnNorthwind);

                // The SqlCommandBuilder examines the Select statement and
                // builds the SQL command text to perform inserts, updates 
                // and deletes.

               SqlCommandBuilder oCommandBuilder = new SqlCommandBuilder(daCustomers);

                daCustomers.InsertCommand = oCommandBuilder.GetInsertCommand();

                daCustomers.UpdateCommand = oCommandBuilder.GetUpdateCommand();

                daCustomers.DeleteCommand = oCommandBuilder.GetDeleteCommand();

                // Update the data source with the changed rows
                // and return the changes

				if (! (dsCustomerChanges == null)) 
				{
					// Must specify which table to update
					daCustomers.Update(dsCustomerChanges.Tables[0]);
					return dsCustomerChanges;
				}
				else 
				{
					return null;
				}

                // Data has been successfully updated, so break out of the loop.
                IsConnecting = false;
                DidPreviouslyConnect = true;

           } 
			catch(SqlException sqlExc )
			{
                switch( sqlExc.Number)
				{
                    case 17:
                        // SQL Server does not exist
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
							"instructions on installing MSDE, view the ReadMe file.", 
							"SQL Server/MSDE not found", 
							MessageBoxButtons.OK, 
							MessageBoxIcon.Exclamation);
							Application.Exit();
						}
						break;
                    case 2627:
                        //Primary Key Violation
						MessageBox.Show("2 Records were added with the same primary key.  Changes canceled.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dsCustomers.RejectChanges();
                        return null;
                }

           } 
			catch(Exception exc )
			{
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return null;
            }
        }
        frmStatusMessage.Close();
		return dsCustomerChanges;
    }

    void SetupTable()
	{
        // Creates CustomersHT and inserts records from the customers
        // table.
        string Connectionstring  = SQL_CONNECTION_STRING;

       CustomersDataSet ds = new CustomersDataSet();

        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

       frmStatus frmStatusMessage = new frmStatus();

        if (! DidPreviouslyConnect) 
		{
            frmStatusMessage.Show("Connecting to SQL Server");
        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

       bool IsConnecting  = true;

        while (IsConnecting)
		{
            try {
                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in to SQL Server, or be part of the Administrators
                // group on your local machine for this to work.
               SqlConnection cnNorthwind = new SqlConnection(Connectionstring);
                cnNorthwind.Open();

                // The table used for this How-To must be created
                // Instantiate Command Object to execute SQL Statements
               SqlCommand cmInitSQL = new SqlCommand();
                // Attach the command to the connection
                cmInitSQL.Connection = cnNorthwind;
                // Set the command type to Text
                cmInitSQL.CommandType = CommandType.Text;
                // Drop CustomerHT table if it exists.
                cmInitSQL.CommandText = "SELECT count(*) FROM dbo.sysobjects WHERE id = object_id('CustomersHT')";
                // Execute the statement
               int recordCount  = (int) cmInitSQL.ExecuteScalar();

                if (recordCount > 0) 
				{
                    // if table exists in the database return from the function if not create it.
                    // Destroy cmInitSQl and close connection
                    cmInitSQL.Dispose();
                    cnNorthwind.Close();
                    // Data has been successfully updated, so break out of the loop.
                    IsConnecting = false;
                    DidPreviouslyConnect = true;
                    return;
                }

                // Create CustomersHT Table
                cmInitSQL.CommandText = "CREATE TABLE [CustomersHT] ( " + 
                                        "[CustomerID] [nchar] (5) NOT NULL PRIMARY KEY ," + 
                                        "[CompanyName] [nvarchar] (40) NOT NULL , " +  
                                        "[ContactName] [nvarchar] (30) NULL , " +  
                                        "[ContactTitle] [nvarchar] (30) NULL , " +  
                                        "[Address] [nvarchar] (60)  NULL , " +  
                                        "[City] [nvarchar] (15) NULL , " +  
                                        "[Region] [nvarchar] (15) NULL , " +  
                                        "[PostalCode] [nvarchar] (10) NULL , " +  
                                        "[Country] [nvarchar] (15) NULL , " +  
                                        "[Phone] [nvarchar] (24) NULL , " +  
                                        "[Fax] [nvarchar] (24) NULL )";
                // Execute the statement
                cmInitSQL.ExecuteNonQuery();
                // Insert data into new CustomersHT table from Customers table in northwind
                cmInitSQL.CommandText = "INSERT INTO CustomersHT " + 
                                        "(CustomerID, CompanyName, ContactName," + 
                                        "ContactTitle, Address, City, Region," + 
                                        "PostalCode, Country, Phone, Fax) " + 
                                        "SELECT CustomerID, CompanyName, ContactName," + 
                                        "ContactTitle, Address, City, Region," + 
                                        "PostalCode, Country, Phone, Fax FROM Customers";
                // Execute the statement

                cmInitSQL.ExecuteNonQuery();
                // Destroy cmInitSQl and close connection
                cmInitSQL.Dispose();
                cnNorthwind.Close();
                // Data has been successfully updated, so break out of the loop.
                IsConnecting = false;
                DidPreviouslyConnect = true;
           } 
			catch(SqlException e )
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
					MessageBox.Show("To run this sample you must have SQL Server ot MSDE with " + 
						"the Northwind database installed.  For instructions on " +  
					"installing MSDE, view the Readme file.", "SQL Server/MSDE not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					// Quit program if neither connection method was successful.
					Application.Exit();
				}
           } 
			catch(Exception e )
			{
                MessageBox.Show(e.Message, "General Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    void UpdateViewState()
	{
        // Display the record position so the
        // user knows what record they are on and
        // how many are available.

        lblPosition.Text = (((BindingContext[dsCustomers, "Customers"].Position + 1).ToString() + " of  ") 
            + BindingContext[dsCustomers, "Customers"].Count.ToString());

        // if we have a Dataset with data in it then disable the
        // Read buttons and enable all the update buttons

			if (dsCustomers.Customers.Count != 0) 
			{
				bnGetCustomers.Enabled = false;
				bnAdd.Enabled = true;
				bnDelete.Enabled = true;
				bnCancel.Enabled = true;
				bnCancelAll.Enabled = true;
				bnSaveCustomers.Enabled = true;
				bnReset.Enabled = true;
			}
			else 
			{
				bnGetCustomers.Enabled = true;
				bnAdd.Enabled = false;
				bnDelete.Enabled = false;
				bnCancel.Enabled = false;
				bnCancelAll.Enabled = false;
				bnSaveCustomers.Enabled = false;
				bnReset.Enabled = false;
			}

        // Allow user to change CustomerID when
        // adding a record.  Do not allow deletes
        // while adding a record.

		if (IsAdding) 
		{
			tbCustomerID.Enabled = true;
			bnDelete.Enabled = false;
		}
		else 
		{
			tbCustomerID.Enabled = false;
		}
        // IsAdding is no longer needed
        IsAdding = false;
    }

   CustomersDataSet SaveCustomersInXML(CustomersDataSet dsCustomers ) 
   {
        // Write the Dataset to a local XML file.  Use the 
        // DiffGram mode to store the current all RowState data
        // so that the SQL Data Adapter can perform the appropriate
        // operation when the Update method is called.  DiffGram must
        // also be used when the data is read from the XML file.
        dsCustomers.WriteXml("../dsCustomers.xml", XmlWriteMode.DiffGram);
        return dsCustomers;
    }
}

