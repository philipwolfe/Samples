//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

public class frmMain : System.Windows.Forms.Form 
{
    private FullTimeEmployee c_empFull;
    private PartTimeEmployee c_empPart;
    private TempEmployee c_empTemp;

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
        txtName.Text = "Carlos Programmer";
        txtHireDate.Text = "7/1/2002";
        txtSalary.Text = "50000";
        txtSocialServicesID.Text = "12345678901";
        txtExpectedTermDate.Text = "10/1/2002";
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

    private System.Windows.Forms.ComboBox cboEmployeeType;

    private System.Windows.Forms.TextBox txtName;

    private System.Windows.Forms.TextBox txtHireDate;

    private System.Windows.Forms.TextBox txtSalary;

    private System.Windows.Forms.TextBox txtSocialServicesID;

    private System.Windows.Forms.TextBox txtExpectedTermDate;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.Button btnHire;

    private System.Windows.Forms.Button btnClear;

    private System.Windows.Forms.TextBox txtResults;

    private System.Windows.Forms.Button btnSave;

    private System.Windows.Forms.Label Label7;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.cboEmployeeType = new System.Windows.Forms.ComboBox();

        this.Label1 = new System.Windows.Forms.Label();

        this.txtName = new System.Windows.Forms.TextBox();

        this.txtHireDate = new System.Windows.Forms.TextBox();

        this.txtSalary = new System.Windows.Forms.TextBox();

        this.txtSocialServicesID = new System.Windows.Forms.TextBox();

        this.txtExpectedTermDate = new System.Windows.Forms.TextBox();

        this.Label2 = new System.Windows.Forms.Label();

        this.Label3 = new System.Windows.Forms.Label();

        this.Label4 = new System.Windows.Forms.Label();

        this.Label5 = new System.Windows.Forms.Label();

        this.Label6 = new System.Windows.Forms.Label();

        this.btnHire = new System.Windows.Forms.Button();

        this.txtResults = new System.Windows.Forms.TextBox();

        this.btnClear = new System.Windows.Forms.Button();

        this.btnSave = new System.Windows.Forms.Button();

        this.Label7 = new System.Windows.Forms.Label();

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

        //cboEmployeeType

        //

        this.cboEmployeeType.AccessibleDescription = resources.GetString("cboEmployeeType.AccessibleDescription");

        this.cboEmployeeType.AccessibleName = resources.GetString("cboEmployeeType.AccessibleName");

        this.cboEmployeeType.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboEmployeeType.Anchor");

        this.cboEmployeeType.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboEmployeeType.BackgroundImage");

        this.cboEmployeeType.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboEmployeeType.Dock");

        this.cboEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        this.cboEmployeeType.Enabled = (bool) resources.GetObject("cboEmployeeType.Enabled");

        this.cboEmployeeType.Font = (System.Drawing.Font) resources.GetObject("cboEmployeeType.Font");

        this.cboEmployeeType.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboEmployeeType.ImeMode");

        this.cboEmployeeType.IntegralHeight = (bool) resources.GetObject("cboEmployeeType.IntegralHeight");

        this.cboEmployeeType.ItemHeight = (int) resources.GetObject("cboEmployeeType.ItemHeight");

        this.cboEmployeeType.Items.AddRange(new object[] {resources.GetString("cboEmployeeType.Items.Items"), resources.GetString("cboEmployeeType.Items.Items1"), resources.GetString("cboEmployeeType.Items.Items2")});

        this.cboEmployeeType.Location = (System.Drawing.Point) resources.GetObject("cboEmployeeType.Location");

        this.cboEmployeeType.MaxDropDownItems = (int) resources.GetObject("cboEmployeeType.MaxDropDownItems");

        this.cboEmployeeType.MaxLength = (int) resources.GetObject("cboEmployeeType.MaxLength");

        this.cboEmployeeType.Name = "cboEmployeeType";

        this.cboEmployeeType.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboEmployeeType.RightToLeft");

        this.cboEmployeeType.Size = (System.Drawing.Size) resources.GetObject("cboEmployeeType.Size");

        this.cboEmployeeType.TabIndex = (int) resources.GetObject("cboEmployeeType.TabIndex");

        this.cboEmployeeType.Text = resources.GetString("cboEmployeeType.Text");

        this.cboEmployeeType.Visible = (bool) resources.GetObject("cboEmployeeType.Visible");

		this.cboEmployeeType.SelectedIndexChanged += new EventHandler(TextBoxes_TextChanged);

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

        //txtName

        //

        this.txtName.AccessibleDescription = resources.GetString("txtName.AccessibleDescription");

        this.txtName.AccessibleName = (string) resources.GetObject("txtName.AccessibleName");

        this.txtName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtName.Anchor");

        this.txtName.AutoSize = (bool) resources.GetObject("txtName.AutoSize");

        this.txtName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtName.BackgroundImage");

        this.txtName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtName.Dock");

        this.txtName.Enabled = (bool) resources.GetObject("txtName.Enabled");

        this.txtName.Font = (System.Drawing.Font) resources.GetObject("txtName.Font");

        this.txtName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtName.ImeMode");

        this.txtName.Location = (System.Drawing.Point) resources.GetObject("txtName.Location");

        this.txtName.MaxLength = (int) resources.GetObject("txtName.MaxLength");

        this.txtName.Multiline = (bool) resources.GetObject("txtName.Multiline");

        this.txtName.Name = "txtName";

        this.txtName.PasswordChar = (char) resources.GetObject("txtName.PasswordChar");

        this.txtName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtName.RightToLeft");

        this.txtName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtName.ScrollBars");

        this.txtName.Size = (System.Drawing.Size) resources.GetObject("txtName.Size");

        this.txtName.TabIndex = (int) resources.GetObject("txtName.TabIndex");

        this.txtName.Text = resources.GetString("txtName.Text");

        this.txtName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtName.TextAlign");

        this.txtName.Visible = (bool) resources.GetObject("txtName.Visible");

        this.txtName.WordWrap = (bool) resources.GetObject("txtName.WordWrap");

		this.txtName.TextChanged += new EventHandler(TextBoxes_TextChanged);

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

		this.txtHireDate.TextChanged += new EventHandler(TextBoxes_TextChanged);

        //

        //txtSalary

        //

        this.txtSalary.AccessibleDescription = resources.GetString("txtSalary.AccessibleDescription");

        this.txtSalary.AccessibleName = resources.GetString("txtSalary.AccessibleName");

        this.txtSalary.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtSalary.Anchor");

        this.txtSalary.AutoSize = (bool) resources.GetObject("txtSalary.AutoSize");

        this.txtSalary.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtSalary.BackgroundImage");

        this.txtSalary.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtSalary.Dock");

        this.txtSalary.Enabled = (bool) resources.GetObject("txtSalary.Enabled");

        this.txtSalary.Font = (System.Drawing.Font) resources.GetObject("txtSalary.Font");

        this.txtSalary.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtSalary.ImeMode");

        this.txtSalary.Location = (System.Drawing.Point) resources.GetObject("txtSalary.Location");

        this.txtSalary.MaxLength = (int) resources.GetObject("txtSalary.MaxLength");

        this.txtSalary.Multiline = (bool) resources.GetObject("txtSalary.Multiline");

        this.txtSalary.Name = "txtSalary";

        this.txtSalary.PasswordChar = (char) resources.GetObject("txtSalary.PasswordChar");

        this.txtSalary.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtSalary.RightToLeft");

        this.txtSalary.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtSalary.ScrollBars");

        this.txtSalary.Size = (System.Drawing.Size) resources.GetObject("txtSalary.Size");

        this.txtSalary.TabIndex = (int) resources.GetObject("txtSalary.TabIndex");

        this.txtSalary.Text = resources.GetString("txtSalary.Text");

        this.txtSalary.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtSalary.TextAlign");

        this.txtSalary.Visible = (bool) resources.GetObject("txtSalary.Visible");

        this.txtSalary.WordWrap = (bool) resources.GetObject("txtSalary.WordWrap");

		this.txtSalary.TextChanged += new EventHandler(TextBoxes_TextChanged);

        //

        //txtSocialServicesID

        //

        this.txtSocialServicesID.AccessibleDescription = resources.GetString("txtSocialServicesID.AccessibleDescription");

        this.txtSocialServicesID.AccessibleName = resources.GetString("txtSocialServicesID.AccessibleName");

        this.txtSocialServicesID.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtSocialServicesID.Anchor");

        this.txtSocialServicesID.AutoSize = (bool) resources.GetObject("txtSocialServicesID.AutoSize");

        this.txtSocialServicesID.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtSocialServicesID.BackgroundImage");

        this.txtSocialServicesID.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtSocialServicesID.Dock");

        this.txtSocialServicesID.Enabled = (bool) resources.GetObject("txtSocialServicesID.Enabled");

        this.txtSocialServicesID.Font = (System.Drawing.Font) resources.GetObject("txtSocialServicesID.Font");

        this.txtSocialServicesID.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtSocialServicesID.ImeMode");

        this.txtSocialServicesID.Location = (System.Drawing.Point) resources.GetObject("txtSocialServicesID.Location");

        this.txtSocialServicesID.MaxLength = (int) resources.GetObject("txtSocialServicesID.MaxLength");

        this.txtSocialServicesID.Multiline = (bool) resources.GetObject("txtSocialServicesID.Multiline");

        this.txtSocialServicesID.Name = "txtSocialServicesID";

        this.txtSocialServicesID.PasswordChar = (char) resources.GetObject("txtSocialServicesID.PasswordChar");

        this.txtSocialServicesID.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtSocialServicesID.RightToLeft");

        this.txtSocialServicesID.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtSocialServicesID.ScrollBars");

        this.txtSocialServicesID.Size = (System.Drawing.Size) resources.GetObject("txtSocialServicesID.Size");

        this.txtSocialServicesID.TabIndex = (int) resources.GetObject("txtSocialServicesID.TabIndex");

        this.txtSocialServicesID.Text = resources.GetString("txtSocialServicesID.Text");

        this.txtSocialServicesID.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtSocialServicesID.TextAlign");

        this.txtSocialServicesID.Visible = (bool) resources.GetObject("txtSocialServicesID.Visible");

        this.txtSocialServicesID.WordWrap = (bool) resources.GetObject("txtSocialServicesID.WordWrap");

		this.txtSocialServicesID.TextChanged += new EventHandler(TextBoxes_TextChanged);

        //

        //txtExpectedTermDate

        //

        this.txtExpectedTermDate.AccessibleDescription = resources.GetString("txtExpectedTermDate.AccessibleDescription");

        this.txtExpectedTermDate.AccessibleName = resources.GetString("txtExpectedTermDate.AccessibleName");

        this.txtExpectedTermDate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtExpectedTermDate.Anchor");

        this.txtExpectedTermDate.AutoSize = (bool) resources.GetObject("txtExpectedTermDate.AutoSize");

        this.txtExpectedTermDate.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtExpectedTermDate.BackgroundImage");

        this.txtExpectedTermDate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtExpectedTermDate.Dock");

        this.txtExpectedTermDate.Enabled = (bool) resources.GetObject("txtExpectedTermDate.Enabled");

        this.txtExpectedTermDate.Font = (System.Drawing.Font) resources.GetObject("txtExpectedTermDate.Font");

        this.txtExpectedTermDate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtExpectedTermDate.ImeMode");

        this.txtExpectedTermDate.Location = (System.Drawing.Point) resources.GetObject("txtExpectedTermDate.Location");

        this.txtExpectedTermDate.MaxLength = (int) resources.GetObject("txtExpectedTermDate.MaxLength");

        this.txtExpectedTermDate.Multiline = (bool) resources.GetObject("txtExpectedTermDate.Multiline");

        this.txtExpectedTermDate.Name = "txtExpectedTermDate";

        this.txtExpectedTermDate.PasswordChar = (char) resources.GetObject("txtExpectedTermDate.PasswordChar");

        this.txtExpectedTermDate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtExpectedTermDate.RightToLeft");

        this.txtExpectedTermDate.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtExpectedTermDate.ScrollBars");

        this.txtExpectedTermDate.Size = (System.Drawing.Size) resources.GetObject("txtExpectedTermDate.Size");

        this.txtExpectedTermDate.TabIndex = (int) resources.GetObject("txtExpectedTermDate.TabIndex");

        this.txtExpectedTermDate.Text = resources.GetString("txtExpectedTermDate.Text");

        this.txtExpectedTermDate.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtExpectedTermDate.TextAlign");

        this.txtExpectedTermDate.Visible = (bool) resources.GetObject("txtExpectedTermDate.Visible");

        this.txtExpectedTermDate.WordWrap = (bool) resources.GetObject("txtExpectedTermDate.WordWrap");

		this.txtExpectedTermDate.TextChanged += new EventHandler(TextBoxes_TextChanged);

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

        //btnHire

        //

        this.btnHire.AccessibleDescription = resources.GetString("btnHire.AccessibleDescription");

        this.btnHire.AccessibleName = resources.GetString("btnHire.AccessibleName");

        this.btnHire.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnHire.Anchor");

        this.btnHire.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnHire.BackgroundImage");

        this.btnHire.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnHire.Dock");

        this.btnHire.Enabled = (bool) resources.GetObject("btnHire.Enabled");

        this.btnHire.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnHire.FlatStyle");

        this.btnHire.Font = (System.Drawing.Font) resources.GetObject("btnHire.Font");

        this.btnHire.Image = (System.Drawing.Image) resources.GetObject("btnHire.Image");

        this.btnHire.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnHire.ImageAlign");

        this.btnHire.ImageIndex = (int) resources.GetObject("btnHire.ImageIndex");

        this.btnHire.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnHire.ImeMode");

        this.btnHire.Location = (System.Drawing.Point) resources.GetObject("btnHire.Location");

        this.btnHire.Name = "btnHire";

        this.btnHire.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnHire.RightToLeft");

        this.btnHire.Size = (System.Drawing.Size) resources.GetObject("btnHire.Size");

        this.btnHire.TabIndex = (int) resources.GetObject("btnHire.TabIndex");

        this.btnHire.Text = resources.GetString("btnHire.Text");

        this.btnHire.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnHire.TextAlign");

        this.btnHire.Visible = (bool) resources.GetObject("btnHire.Visible");

		this.btnHire.Click += new EventHandler(btnHire_Click);

        //

        //txtResults

        //

        this.txtResults.AccessibleDescription = resources.GetString("txtResults.AccessibleDescription");

        this.txtResults.AccessibleName = resources.GetString("txtResults.AccessibleName");

        this.txtResults.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtResults.Anchor");

        this.txtResults.AutoSize = (bool) resources.GetObject("txtResults.AutoSize");

        this.txtResults.BackColor = System.Drawing.SystemColors.Menu;

        this.txtResults.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtResults.BackgroundImage");

        this.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.txtResults.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtResults.Dock");

        this.txtResults.Enabled = (bool) resources.GetObject("txtResults.Enabled");

        this.txtResults.Font = (System.Drawing.Font) resources.GetObject("txtResults.Font");

        this.txtResults.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtResults.ImeMode");

        this.txtResults.Location = (System.Drawing.Point) resources.GetObject("txtResults.Location");

        this.txtResults.MaxLength = (int) resources.GetObject("txtResults.MaxLength");

        this.txtResults.Multiline = (bool) resources.GetObject("txtResults.Multiline");

        this.txtResults.Name = "txtResults";

        this.txtResults.PasswordChar = (char) resources.GetObject("txtResults.PasswordChar");

        this.txtResults.ReadOnly = true;

        this.txtResults.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtResults.RightToLeft");

        this.txtResults.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtResults.ScrollBars");

        this.txtResults.Size = (System.Drawing.Size) resources.GetObject("txtResults.Size");

        this.txtResults.TabIndex = (int) resources.GetObject("txtResults.TabIndex");

        this.txtResults.Text = resources.GetString("txtResults.Text");

        this.txtResults.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtResults.TextAlign");

        this.txtResults.Visible = (bool) resources.GetObject("txtResults.Visible");

        this.txtResults.WordWrap = (bool) resources.GetObject("txtResults.WordWrap");

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

		this.btnClear.Click += new EventHandler(btnClear_Click);

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

		this.btnSave.Click += new EventHandler(btnSave_Click);

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label7, this.btnSave, this.btnClear, this.txtResults, this.btnHire, this.Label6, this.Label5, this.Label4, this.Label3, this.Label2, this.txtExpectedTermDate, this.txtSocialServicesID, this.txtSalary, this.txtHireDate, this.txtName, this.Label1, this.cboEmployeeType});

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

    private void btnClear_Click(object sender, System.EventArgs e) 
	{
        cboEmployeeType.SelectedIndex = -1;

        foreach(Control ctl in this.Controls)
		{
            if (ctl.GetType() == typeof(TextBox))
			{
                ctl.Text = string.Empty;
            }
        }
    }

    private void btnHire_Click(object sender, System.EventArgs e) 
	{
        if (! ValidateData())
		{
            return;
        }
        switch( cboEmployeeType.SelectedIndex)
		{
            case -1:
                return;
            case 0:
                HireFullTimeEmployee();
				break;
            case 1:
                HirePartTimeEmployee();
				break;
            case 2:
                HireTempEmployee();
				break;
        }
    }

    private void btnSave_Click(object sender, System.EventArgs e) 
	{
        string strResult = "";
        // These simulated save-to-database actions use a shared method
        // of the EmployeeDataManager class.
        switch( cboEmployeeType.SelectedIndex)
		{
            case -1:
                return;
            case 0:
                strResult = EmployeeDataManager.WriteEmployeeData(c_empFull);
				break;
            case 1:
                strResult = EmployeeDataManager.WriteEmployeeData(c_empPart);
				break;
            case 2:
                strResult = EmployeeDataManager.WriteEmployeeData(c_empTemp);
				break;
        }
        MessageBox.Show(strResult, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // This procedure watches for changes in the textboxes and the
    // combobox, and enables the Hire button only when the textboxes all
    // have data.
    private void TextBoxes_TextChanged(object sender, System.EventArgs e) //txtName.TextChanged, txtHireDate.TextChanged, txtSalary.TextChanged, txtSocialServicesID.TextChanged, txtExpectedTermDate.TextChanged, cboEmployeeType.SelectedIndexChanged;
	{
        switch( cboEmployeeType.SelectedIndex)
		{
            case -1:
                //btnHire.Enabled = false
                txtName.Enabled = false;
                txtHireDate.Enabled = false;
                txtSalary.Enabled = false;
                txtSocialServicesID.Enabled = false;
                txtExpectedTermDate.Enabled = false;
				break;
            case 0:
				//btnHire.Enabled = true
				txtName.Enabled = true;
				txtHireDate.Enabled = true;
				txtSalary.Enabled = true;
				txtSocialServicesID.Enabled = true;
				txtExpectedTermDate.Enabled = false;
				break;
			case 1:	
                //btnHire.Enabled = true
                txtName.Enabled = true;
                txtHireDate.Enabled = true;
                txtSalary.Enabled = true;
                txtSocialServicesID.Enabled = true;
                txtExpectedTermDate.Enabled = false;
				break;
            case 2:
                //btnHire.Enabled = true
                txtName.Enabled = true;
                txtHireDate.Enabled = true;
                txtSalary.Enabled = true;
                txtSocialServicesID.Enabled = true;
                txtExpectedTermDate.Enabled = true;
				break;
        }
        btnHire.Enabled = txtName.Text.Trim().Length != 0 &&
            txtHireDate.Text.Trim().Length != 0 && 
            txtSalary.Text.Trim().Length != 0 && 
            txtSocialServicesID.Text.Trim().Length != 0 && 
            cboEmployeeType.SelectedIndex >= 0;

        // if Temp Employee is chosen, test for text in the ExpectedTermDate text box.
        if (cboEmployeeType.SelectedIndex == 2) 
		{
            btnHire.Enabled = btnHire.Enabled && txtExpectedTermDate.Text.Trim().Length != 0;
        }
        btnSave.Enabled = false;
    }

    private void HireFullTimeEmployee()
	{
        c_empFull = new FullTimeEmployee();

        try 
		{
            c_empFull.Hire(txtName.Text.Trim(), (Convert.ToDateTime(txtHireDate.Text.Trim())), 
                (Convert.ToDecimal(txtSalary.Text.Trim())));
            c_empFull.SocialServicesID = txtSocialServicesID.Text.Trim();
            txtResults.Clear();
            txtResults.Text += "Name: " + c_empFull.Name + Environment.NewLine + 
                "Hire date: " + c_empFull.HireDate + Environment.NewLine + 
                "Salary: " + c_empFull.Salary + Environment.NewLine + 
                "Social Services ID: " + c_empFull.SocialServicesID + Environment.NewLine +
                "Bonus: " + c_empFull.Bonus + Environment.NewLine + 
                "Annual Leave: " + c_empFull.AnnualLeave + " days";
            btnSave.Enabled = true;
       } 
		catch( Exception exp)
		{
            MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void HirePartTimeEmployee()
	{
        c_empPart = new PartTimeEmployee();

        try 
		{
            c_empPart.Hire(txtName.Text.Trim(), (Convert.ToDateTime(txtHireDate.Text.Trim())),
                (Convert.ToDecimal(txtSalary.Text.Trim())), 20) ;
            c_empPart.SocialServicesID = txtSocialServicesID.Text.Trim();
            txtResults.Clear();
            txtResults.Text += "Name: " + c_empPart.Name + Environment.NewLine + 
                "Hire date: " +c_empPart .HireDate + Environment.NewLine + 
                "Salary: " + c_empPart.Salary + Environment.NewLine + 
                "Social Services ID: " + c_empPart.SocialServicesID + Environment.NewLine + 
                "Bonus: " + c_empPart.Bonus + Environment.NewLine +
                "Min hrs. per week: " + c_empPart.MinHoursPerWeek;
            btnSave.Enabled = true;
       }
		catch( Exception exp)
		{
            MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void HireTempEmployee()
	{
        c_empTemp = new TempEmployee();

        try {
            c_empTemp.Hire(txtName.Text.Trim(), (Convert.ToDateTime(txtHireDate.Text.Trim())),
                (Convert.ToDecimal(txtSalary.Text.Trim())), (Convert.ToDateTime(txtExpectedTermDate.Text.Trim())));
            c_empTemp.SocialServicesID = txtSocialServicesID.Text.Trim();
            txtResults.Clear();
            txtResults.Text += "Name: " + c_empTemp.Name + Environment.NewLine + 
                "Hire date: " + c_empTemp.HireDate + Environment.NewLine + 
                "Salary: " + c_empTemp.Salary + Environment.NewLine + 
                "Social Services ID: " + c_empTemp.SocialServicesID + Environment.NewLine +
                "Bonus: " + c_empTemp.Bonus + Environment.NewLine + 
                "Expected termination date: " + c_empTemp.ExpectedTermDate.ToShortDateString();
            btnSave.Enabled = true;
       }
		catch( Exception exp)
		{
            MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

	public static bool IsDate(string date) 
	{
		DateTime dt;
		bool isDate = true;
		try 
		{
			dt = DateTime.Parse(date);  
			//If this cannot parse, the format is incorrect
		}
		catch (FormatException e) 
		{
			//date string cannot be converted to a date.
			isDate = false;
		} 
		return isDate;
	} 


    private bool ValidateData() 
	{
        bool dataInValid  = true;

        if (! IsDate(txtHireDate.Text)) 
		{
            MessageBox.Show("Hire Date must be a date in the format MM/DD/YY.",
               this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            dataInValid = false;
        }
        if (txtSocialServicesID.Text.Length != 11)
		{
            MessageBox.Show("Social Services ID must be 11 characters in length",
				this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            dataInValid = false;
        }
        return (dataInValid);
    }
}

