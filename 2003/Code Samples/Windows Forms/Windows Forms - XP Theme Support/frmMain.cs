//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;
using System.Windows.Forms;
using System.Data;

public class frmMain:System.Windows.Forms.Form 
{
   private string entree = "";
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
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
    private System.Windows.Forms.TabPage TabPage1;
    private System.Windows.Forms.TabPage TabPage2;
    private System.Windows.Forms.ListBox ListBox1;
    private System.Windows.Forms.TabPage TabPage3;
    private System.Windows.Forms.DataGrid DataGrid1;
    private System.Windows.Forms.TabControl tabMain;
    private System.Windows.Forms.CheckedListBox CheckedListBox1;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.Label Label5;
    private System.Windows.Forms.GroupBox grpMainCourse;
    private System.Windows.Forms.GroupBox grpCondiments;
    private System.Windows.Forms.CheckBox chkMustard;
    private System.Windows.Forms.RadioButton optHamburger;
    private System.Windows.Forms.CheckBox chkKetchup;
    private System.Windows.Forms.CheckBox chkMayo;
    private System.Windows.Forms.RadioButton optCheesburger;
    private System.Windows.Forms.RadioButton optHotDog;
    private System.Windows.Forms.TextBox txtFirstName;
    private System.Windows.Forms.TextBox txtLastName;
    private System.Windows.Forms.Label Label6;
    private System.Windows.Forms.Label Label7;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.Label Label8;
    private System.Windows.Forms.Label lbl1;
    private System.Windows.Forms.MonthCalendar calArrivalDate;
    private System.Windows.Forms.MonthCalendar calDepartureDate;
    private System.Windows.Forms.ComboBox cboArrivalCity;
    private System.Windows.Forms.ComboBox cboDepartureCity;
    private System.Windows.Forms.Label Label9;
    private System.Windows.Forms.DomainUpDown dudMaleFemale;
    private System.Windows.Forms.Label Label10;
    private System.Windows.Forms.Label Label11;
    private System.Windows.Forms.Button btnSubmitOrder;


    private void InitializeComponent() 
	{
        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
        this.mnuMain = new System.Windows.Forms.MainMenu();
        this.mnuFile = new System.Windows.Forms.MenuItem();
        this.mnuExit = new System.Windows.Forms.MenuItem();
        this.mnuHelp = new System.Windows.Forms.MenuItem();
        this.mnuAbout = new System.Windows.Forms.MenuItem();
        this.txtFirstName = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.txtLastName = new System.Windows.Forms.TextBox();
        this.tabMain = new System.Windows.Forms.TabControl();
        this.TabPage1 = new System.Windows.Forms.TabPage();
        this.Label11 = new System.Windows.Forms.Label();
        this.lbl1 = new System.Windows.Forms.Label();
        this.cboArrivalCity = new System.Windows.Forms.ComboBox();
        this.Label8 = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.Label7 = new System.Windows.Forms.Label();
        this.Label6 = new System.Windows.Forms.Label();
        this.calArrivalDate = new System.Windows.Forms.MonthCalendar();
        this.ListBox1 = new System.Windows.Forms.ListBox();
        this.cboDepartureCity = new System.Windows.Forms.ComboBox();
        this.calDepartureDate = new System.Windows.Forms.MonthCalendar();
        this.TabPage3 = new System.Windows.Forms.TabPage();
        this.btnSubmitOrder = new System.Windows.Forms.Button();
        this.Label10 = new System.Windows.Forms.Label();
        this.optHotDog = new System.Windows.Forms.RadioButton();
        this.optCheesburger = new System.Windows.Forms.RadioButton();
        this.chkMayo = new System.Windows.Forms.CheckBox();
        this.chkKetchup = new System.Windows.Forms.CheckBox();
        this.Label5 = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.chkMustard = new System.Windows.Forms.CheckBox();
        this.optHamburger = new System.Windows.Forms.RadioButton();
        this.grpMainCourse = new System.Windows.Forms.GroupBox();
        this.grpCondiments = new System.Windows.Forms.GroupBox();
        this.TabPage2 = new System.Windows.Forms.TabPage();
        this.Label9 = new System.Windows.Forms.Label();
        this.CheckedListBox1 = new System.Windows.Forms.CheckedListBox();
        this.DataGrid1 = new System.Windows.Forms.DataGrid();
        this.dudMaleFemale = new System.Windows.Forms.DomainUpDown();
        this.tabMain.SuspendLayout();
        this.TabPage1.SuspendLayout();
        this.TabPage3.SuspendLayout();
        this.TabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();
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

        //tabMain

        //

        this.tabMain.AccessibleDescription = (string) resources.GetObject("tabMain.AccessibleDescription");

        this.tabMain.AccessibleName = (string) resources.GetObject("tabMain.AccessibleName");

        this.tabMain.Alignment = (System.Windows.Forms.TabAlignment) resources.GetObject("tabMain.Alignment");

        this.tabMain.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tabMain.Anchor");

        this.tabMain.Appearance = (System.Windows.Forms.TabAppearance) resources.GetObject("tabMain.Appearance");

        this.tabMain.BackgroundImage = (System.Drawing.Image) resources.GetObject("tabMain.BackgroundImage");

        this.tabMain.Controls.AddRange(new System.Windows.Forms.Control[] {this.TabPage1, this.TabPage3, this.TabPage2});

        this.tabMain.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tabMain.Dock");

        this.tabMain.Enabled = (bool) resources.GetObject("tabMain.Enabled");

        this.tabMain.Font = (System.Drawing.Font) resources.GetObject("tabMain.Font");

        this.tabMain.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tabMain.ImeMode");

        this.tabMain.ItemSize = (System.Drawing.Size) resources.GetObject("tabMain.ItemSize");

        this.tabMain.Location = (System.Drawing.Point) resources.GetObject("tabMain.Location");

        this.tabMain.Name = "tabMain";

        this.tabMain.Padding = (System.Drawing.Point) resources.GetObject("tabMain.Padding");

        this.tabMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tabMain.RightToLeft");

        this.tabMain.SelectedIndex = 0;

        this.tabMain.ShowToolTips = (bool) resources.GetObject("tabMain.ShowToolTips");

        this.tabMain.Size = (System.Drawing.Size) resources.GetObject("tabMain.Size");

        this.tabMain.TabIndex = (int) resources.GetObject("tabMain.TabIndex");

        this.tabMain.Text = resources.GetString("tabMain.Text");

        this.tabMain.Visible = (bool) resources.GetObject("tabMain.Visible");

        //

        //TabPage1

        //

        this.TabPage1.AccessibleDescription = (string) resources.GetObject("TabPage1.AccessibleDescription");

        this.TabPage1.AccessibleName = (string) resources.GetObject("TabPage1.AccessibleName");

        this.TabPage1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("TabPage1.Anchor");

        this.TabPage1.AutoScroll = (bool) resources.GetObject("TabPage1.AutoScroll");

        this.TabPage1.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("TabPage1.AutoScrollMargin");

        this.TabPage1.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("TabPage1.AutoScrollMinSize");

        this.TabPage1.BackgroundImage = (System.Drawing.Image) resources.GetObject("TabPage1.BackgroundImage");

        this.TabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label11, this.lbl1, this.cboArrivalCity, this.Label8, this.Label3, this.Label7, this.Label6, this.calArrivalDate, this.ListBox1, this.cboDepartureCity, this.calDepartureDate, this.Label1, this.txtFirstName, this.Label2, this.txtLastName});

        this.TabPage1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("TabPage1.Dock");

        this.TabPage1.Enabled = (bool) resources.GetObject("TabPage1.Enabled");

        this.TabPage1.Font = (System.Drawing.Font) resources.GetObject("TabPage1.Font");

        this.TabPage1.ImageIndex = (int) resources.GetObject("TabPage1.ImageIndex");

        this.TabPage1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("TabPage1.ImeMode");

        this.TabPage1.Location = (System.Drawing.Point) resources.GetObject("TabPage1.Location");

        this.TabPage1.Name = "TabPage1";

        this.TabPage1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("TabPage1.RightToLeft");

        this.TabPage1.Size = (System.Drawing.Size) resources.GetObject("TabPage1.Size");

        this.TabPage1.TabIndex = (int) resources.GetObject("TabPage1.TabIndex");

        this.TabPage1.Tag = "Supported_Controls";

        this.TabPage1.Text = resources.GetString("TabPage1.Text");

        this.TabPage1.ToolTipText = resources.GetString("TabPage1.ToolTipText");

        this.TabPage1.Visible = (bool) resources.GetObject("TabPage1.Visible");

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

        //lbl1

        //

        this.lbl1.AccessibleDescription = (string) resources.GetObject("lbl1.AccessibleDescription");

        this.lbl1.AccessibleName = (string) resources.GetObject("lbl1.AccessibleName");

        this.lbl1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lbl1.Anchor");

        this.lbl1.AutoSize = (bool) resources.GetObject("lbl1.AutoSize");

        this.lbl1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lbl1.Dock");

        this.lbl1.Enabled = (bool) resources.GetObject("lbl1.Enabled");

        this.lbl1.Font = (System.Drawing.Font) resources.GetObject("lbl1.Font");

        this.lbl1.Image = (System.Drawing.Image) resources.GetObject("lbl1.Image");

        this.lbl1.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lbl1.ImageAlign");

        this.lbl1.ImageIndex = (int) resources.GetObject("lbl1.ImageIndex");

        this.lbl1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lbl1.ImeMode");

        this.lbl1.Location = (System.Drawing.Point) resources.GetObject("lbl1.Location");

        this.lbl1.Name = "lbl1";

        this.lbl1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lbl1.RightToLeft");

        this.lbl1.Size = (System.Drawing.Size) resources.GetObject("lbl1.Size");

        this.lbl1.TabIndex = (int) resources.GetObject("lbl1.TabIndex");

        this.lbl1.Text = resources.GetString("lbl1.Text");

        this.lbl1.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lbl1.TextAlign");

        this.lbl1.Visible = (bool) resources.GetObject("lbl1.Visible");

        //

        //cboArrivalCity

        //

        this.cboArrivalCity.AccessibleDescription = resources.GetString("cboArrivalCity.AccessibleDescription");

        this.cboArrivalCity.AccessibleName = resources.GetString("cboArrivalCity.AccessibleName");

        this.cboArrivalCity.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboArrivalCity.Anchor");

        this.cboArrivalCity.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboArrivalCity.BackgroundImage");

        this.cboArrivalCity.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboArrivalCity.Dock");

        this.cboArrivalCity.Enabled = (bool) resources.GetObject("cboArrivalCity.Enabled");

        this.cboArrivalCity.Font = (System.Drawing.Font) resources.GetObject("cboArrivalCity.Font");

        this.cboArrivalCity.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboArrivalCity.ImeMode");

        this.cboArrivalCity.IntegralHeight = (bool) resources.GetObject("cboArrivalCity.IntegralHeight");

        this.cboArrivalCity.ItemHeight = (int) resources.GetObject("cboArrivalCity.ItemHeight");

       this.cboArrivalCity.Items.AddRange(new Object[]{resources.GetString("cboArrivalCity.Items.Items"), resources.GetString("cboArrivalCity.Items.Items1"), resources.GetString("cboArrivalCity.Items.Items2"), resources.GetString("cboArrivalCity.Items.Items3"), resources.GetString("cboArrivalCity.Items.Items4")});

        this.cboArrivalCity.Location = (System.Drawing.Point) resources.GetObject("cboArrivalCity.Location");

        this.cboArrivalCity.MaxDropDownItems = (int) resources.GetObject("cboArrivalCity.MaxDropDownItems");

        this.cboArrivalCity.MaxLength = (int) resources.GetObject("cboArrivalCity.MaxLength");

        this.cboArrivalCity.Name = "cboArrivalCity";

        this.cboArrivalCity.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboArrivalCity.RightToLeft");

        this.cboArrivalCity.Size = (System.Drawing.Size) resources.GetObject("cboArrivalCity.Size");

        this.cboArrivalCity.TabIndex = (int) resources.GetObject("cboArrivalCity.TabIndex");

        this.cboArrivalCity.Text = resources.GetString("cboArrivalCity.Text");

        this.cboArrivalCity.Visible = (bool) resources.GetObject("cboArrivalCity.Visible");

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

        //calArrivalDate

        //

        this.calArrivalDate.AccessibleDescription = resources.GetString("calArrivalDate.AccessibleDescription");

        this.calArrivalDate.AccessibleName = resources.GetString("calArrivalDate.AccessibleName");

        this.calArrivalDate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("calArrivalDate.Anchor");

        this.calArrivalDate.AnnuallyBoldedDates = (DateTime[]) resources.GetObject("calArrivalDate.AnnuallyBoldedDates");

        this.calArrivalDate.BackgroundImage = (System.Drawing.Image) resources.GetObject("calArrivalDate.BackgroundImage");

        this.calArrivalDate.BoldedDates = (DateTime[]) resources.GetObject("calArrivalDate.BoldedDates");

        this.calArrivalDate.CalendarDimensions = (System.Drawing.Size) resources.GetObject("calArrivalDate.CalendarDimensions");

        this.calArrivalDate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("calArrivalDate.Dock");

        this.calArrivalDate.Enabled = (bool) resources.GetObject("calArrivalDate.Enabled");

        this.calArrivalDate.FirstDayOfWeek = (System.Windows.Forms.Day) resources.GetObject("calArrivalDate.FirstDayOfWeek");

        this.calArrivalDate.Font = (System.Drawing.Font) resources.GetObject("calArrivalDate.Font");

        this.calArrivalDate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("calArrivalDate.ImeMode");

        this.calArrivalDate.Location = (System.Drawing.Point) resources.GetObject("calArrivalDate.Location");

        this.calArrivalDate.MonthlyBoldedDates = (DateTime[]) resources.GetObject("calArrivalDate.MonthlyBoldedDates");

        this.calArrivalDate.Name = "calArrivalDate";

        this.calArrivalDate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("calArrivalDate.RightToLeft");

        this.calArrivalDate.ShowWeekNumbers = (bool) resources.GetObject("calArrivalDate.ShowWeekNumbers");

        this.calArrivalDate.Size = (System.Drawing.Size) resources.GetObject("calArrivalDate.Size");

        this.calArrivalDate.TabIndex = (int) resources.GetObject("calArrivalDate.TabIndex");

        this.calArrivalDate.Visible = (bool) resources.GetObject("calArrivalDate.Visible");

        //

        //ListBox1

        //

        this.ListBox1.AccessibleDescription = resources.GetString("ListBox1.AccessibleDescription");

        this.ListBox1.AccessibleName = resources.GetString("ListBox1.AccessibleName");

        this.ListBox1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("ListBox1.Anchor");

        this.ListBox1.BackgroundImage = (System.Drawing.Image) resources.GetObject("ListBox1.BackgroundImage");

        this.ListBox1.ColumnWidth = (int) resources.GetObject("ListBox1.ColumnWidth");

        this.ListBox1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("ListBox1.Dock");

        this.ListBox1.Enabled = (bool) resources.GetObject("ListBox1.Enabled");

        this.ListBox1.Font = (System.Drawing.Font) resources.GetObject("ListBox1.Font");

        this.ListBox1.HorizontalExtent = (int) resources.GetObject("ListBox1.HorizontalExtent");

        this.ListBox1.HorizontalScrollbar = (bool) resources.GetObject("ListBox1.HorizontalScrollbar");

        this.ListBox1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("ListBox1.ImeMode");

        this.ListBox1.IntegralHeight = (bool) resources.GetObject("ListBox1.IntegralHeight");

        this.ListBox1.ItemHeight = (int) resources.GetObject("ListBox1.ItemHeight");

       this.ListBox1.Items.AddRange(new Object[] {resources.GetString("ListBox1.Items.Items"), resources.GetString("ListBox1.Items.Items1"), resources.GetString("ListBox1.Items.Items2")});

        this.ListBox1.Location = (System.Drawing.Point) resources.GetObject("ListBox1.Location");

        this.ListBox1.Name = "ListBox1";

        this.ListBox1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("ListBox1.RightToLeft");

        this.ListBox1.ScrollAlwaysVisible = (bool) resources.GetObject("ListBox1.ScrollAlwaysVisible");

        this.ListBox1.Size = (System.Drawing.Size) resources.GetObject("ListBox1.Size");

        this.ListBox1.TabIndex = (int) resources.GetObject("ListBox1.TabIndex");

        this.ListBox1.Visible = (bool) resources.GetObject("ListBox1.Visible");

        //

        //cboDepartureCity

        //

        this.cboDepartureCity.AccessibleDescription = resources.GetString("cboDepartureCity.AccessibleDescription");

        this.cboDepartureCity.AccessibleName = resources.GetString("cboDepartureCity.AccessibleName");

        this.cboDepartureCity.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboDepartureCity.Anchor");

        this.cboDepartureCity.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboDepartureCity.BackgroundImage");

        this.cboDepartureCity.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboDepartureCity.Dock");

        this.cboDepartureCity.Enabled = (bool) resources.GetObject("cboDepartureCity.Enabled");

        this.cboDepartureCity.Font = (System.Drawing.Font) resources.GetObject("cboDepartureCity.Font");

        this.cboDepartureCity.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboDepartureCity.ImeMode");

        this.cboDepartureCity.IntegralHeight = (bool) resources.GetObject("cboDepartureCity.IntegralHeight");

        this.cboDepartureCity.ItemHeight = (int) resources.GetObject("cboDepartureCity.ItemHeight");

        this.cboDepartureCity.Items.AddRange(new Object[] {resources.GetString("cboDepartureCity.Items.Items"), resources.GetString("cboDepartureCity.Items.Items1"), resources.GetString("cboDepartureCity.Items.Items2"), resources.GetString("cboDepartureCity.Items.Items3"), resources.GetString("cboDepartureCity.Items.Items4")});

        this.cboDepartureCity.Location = (System.Drawing.Point) resources.GetObject("cboDepartureCity.Location");

        this.cboDepartureCity.MaxDropDownItems = (int) resources.GetObject("cboDepartureCity.MaxDropDownItems");

        this.cboDepartureCity.MaxLength = (int) resources.GetObject("cboDepartureCity.MaxLength");

        this.cboDepartureCity.Name = "cboDepartureCity";

        this.cboDepartureCity.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboDepartureCity.RightToLeft");

        this.cboDepartureCity.Size = (System.Drawing.Size) resources.GetObject("cboDepartureCity.Size");

        this.cboDepartureCity.TabIndex = (int) resources.GetObject("cboDepartureCity.TabIndex");

        this.cboDepartureCity.Text = resources.GetString("cboDepartureCity.Text");

        this.cboDepartureCity.Visible = (bool) resources.GetObject("cboDepartureCity.Visible");

        //

        //calDepartureDate

        //

        this.calDepartureDate.AccessibleDescription = resources.GetString("calDepartureDate.AccessibleDescription");

        this.calDepartureDate.AccessibleName = resources.GetString("calDepartureDate.AccessibleName");

        this.calDepartureDate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("calDepartureDate.Anchor");

        this.calDepartureDate.AnnuallyBoldedDates = (DateTime[]) resources.GetObject("calDepartureDate.AnnuallyBoldedDates");

        this.calDepartureDate.BackgroundImage = (System.Drawing.Image) resources.GetObject("calDepartureDate.BackgroundImage");

        this.calDepartureDate.BoldedDates = (DateTime[]) resources.GetObject("calDepartureDate.BoldedDates");

        this.calDepartureDate.CalendarDimensions = (System.Drawing.Size) resources.GetObject("calDepartureDate.CalendarDimensions");

        this.calDepartureDate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("calDepartureDate.Dock");

        this.calDepartureDate.Enabled = (bool) resources.GetObject("calDepartureDate.Enabled");

        this.calDepartureDate.FirstDayOfWeek = (System.Windows.Forms.Day) resources.GetObject("calDepartureDate.FirstDayOfWeek");

        this.calDepartureDate.Font = (System.Drawing.Font) resources.GetObject("calDepartureDate.Font");

        this.calDepartureDate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("calDepartureDate.ImeMode");

        this.calDepartureDate.Location = (System.Drawing.Point) resources.GetObject("calDepartureDate.Location");

        this.calDepartureDate.MonthlyBoldedDates = (DateTime[]) resources.GetObject("calDepartureDate.MonthlyBoldedDates");

        this.calDepartureDate.Name = "calDepartureDate";

        this.calDepartureDate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("calDepartureDate.RightToLeft");

        this.calDepartureDate.ShowWeekNumbers = (bool) resources.GetObject("calDepartureDate.ShowWeekNumbers");

        this.calDepartureDate.Size = (System.Drawing.Size) resources.GetObject("calDepartureDate.Size");

        this.calDepartureDate.TabIndex = (int) resources.GetObject("calDepartureDate.TabIndex");

        this.calDepartureDate.Visible = (bool) resources.GetObject("calDepartureDate.Visible");

        //

        //TabPage3

        //

        this.TabPage3.AccessibleDescription = (string) resources.GetObject("TabPage3.AccessibleDescription");

        this.TabPage3.AccessibleName = (string) resources.GetObject("TabPage3.AccessibleName");

        this.TabPage3.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("TabPage3.Anchor");

        this.TabPage3.AutoScroll = (bool) resources.GetObject("TabPage3.AutoScroll");

        this.TabPage3.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("TabPage3.AutoScrollMargin");

        this.TabPage3.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("TabPage3.AutoScrollMinSize");

        this.TabPage3.BackgroundImage = (System.Drawing.Image) resources.GetObject("TabPage3.BackgroundImage");

        this.TabPage3.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnSubmitOrder, this.Label10, this.optHotDog, this.optCheesburger, this.chkMayo, this.chkKetchup, this.Label5, this.Label4, this.chkMustard, this.optHamburger, this.grpMainCourse, this.grpCondiments});

        this.TabPage3.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("TabPage3.Dock");

        this.TabPage3.Enabled = (bool) resources.GetObject("TabPage3.Enabled");

        this.TabPage3.Font = (System.Drawing.Font) resources.GetObject("TabPage3.Font");

        this.TabPage3.ImageIndex = (int) resources.GetObject("TabPage3.ImageIndex");

        this.TabPage3.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("TabPage3.ImeMode");

        this.TabPage3.Location = (System.Drawing.Point) resources.GetObject("TabPage3.Location");

        this.TabPage3.Name = "TabPage3";

        this.TabPage3.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("TabPage3.RightToLeft");

        this.TabPage3.Size = (System.Drawing.Size) resources.GetObject("TabPage3.Size");

        this.TabPage3.TabIndex = (int) resources.GetObject("TabPage3.TabIndex");

        this.TabPage3.Tag = "Requires_Flat_Style_Set";

        this.TabPage3.Text = resources.GetString("TabPage3.Text");

        this.TabPage3.ToolTipText = resources.GetString("TabPage3.ToolTipText");

        this.TabPage3.Visible = (bool) resources.GetObject("TabPage3.Visible");

        //

        //btnSubmitOrder

        //

        this.btnSubmitOrder.AccessibleDescription = resources.GetString("btnSubmitOrder.AccessibleDescription");

        this.btnSubmitOrder.AccessibleName = resources.GetString("btnSubmitOrder.AccessibleName");

        this.btnSubmitOrder.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSubmitOrder.Anchor");

        this.btnSubmitOrder.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSubmitOrder.BackgroundImage");

        this.btnSubmitOrder.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSubmitOrder.Dock");

        this.btnSubmitOrder.Enabled = (bool) resources.GetObject("btnSubmitOrder.Enabled");

        this.btnSubmitOrder.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSubmitOrder.FlatStyle");

        this.btnSubmitOrder.Font = (System.Drawing.Font) resources.GetObject("btnSubmitOrder.Font");

        this.btnSubmitOrder.Image = (System.Drawing.Image) resources.GetObject("btnSubmitOrder.Image");

        this.btnSubmitOrder.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSubmitOrder.ImageAlign");

        this.btnSubmitOrder.ImageIndex = (int) resources.GetObject("btnSubmitOrder.ImageIndex");

        this.btnSubmitOrder.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSubmitOrder.ImeMode");

        this.btnSubmitOrder.Location = (System.Drawing.Point) resources.GetObject("btnSubmitOrder.Location");

        this.btnSubmitOrder.Name = "btnSubmitOrder";

        this.btnSubmitOrder.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSubmitOrder.RightToLeft");

        this.btnSubmitOrder.Size = (System.Drawing.Size) resources.GetObject("btnSubmitOrder.Size");

        this.btnSubmitOrder.TabIndex = (int) resources.GetObject("btnSubmitOrder.TabIndex");

        this.btnSubmitOrder.Text = resources.GetString("btnSubmitOrder.Text");

        this.btnSubmitOrder.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSubmitOrder.TextAlign");

        this.btnSubmitOrder.Visible = (bool) resources.GetObject("btnSubmitOrder.Visible");

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

        //optHotDog

        //

        this.optHotDog.AccessibleDescription = resources.GetString("optHotDog.AccessibleDescription");

        this.optHotDog.AccessibleName = resources.GetString("optHotDog.AccessibleName");

        this.optHotDog.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optHotDog.Anchor");

        this.optHotDog.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optHotDog.Appearance");

        this.optHotDog.BackgroundImage = (System.Drawing.Image) resources.GetObject("optHotDog.BackgroundImage");

        this.optHotDog.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optHotDog.CheckAlign");

        this.optHotDog.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optHotDog.Dock");

        this.optHotDog.Enabled = (bool) resources.GetObject("optHotDog.Enabled");

        this.optHotDog.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optHotDog.FlatStyle");

        this.optHotDog.Font = (System.Drawing.Font) resources.GetObject("optHotDog.Font");

        this.optHotDog.Image = (System.Drawing.Image) resources.GetObject("optHotDog.Image");

        this.optHotDog.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optHotDog.ImageAlign");

        this.optHotDog.ImageIndex = (int) resources.GetObject("optHotDog.ImageIndex");

        this.optHotDog.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optHotDog.ImeMode");

        this.optHotDog.Location = (System.Drawing.Point) resources.GetObject("optHotDog.Location");

        this.optHotDog.Name = "optHotDog";

        this.optHotDog.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optHotDog.RightToLeft");

        this.optHotDog.Size = (System.Drawing.Size) resources.GetObject("optHotDog.Size");

        this.optHotDog.TabIndex = (int) resources.GetObject("optHotDog.TabIndex");

        this.optHotDog.Text = resources.GetString("optHotDog.Text");

        this.optHotDog.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optHotDog.TextAlign");

        this.optHotDog.Visible = (bool) resources.GetObject("optHotDog.Visible");

        //

        //optCheesburger

        //

        this.optCheesburger.AccessibleDescription = resources.GetString("optCheesburger.AccessibleDescription");

        this.optCheesburger.AccessibleName = resources.GetString("optCheesburger.AccessibleName");

        this.optCheesburger.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optCheesburger.Anchor");

        this.optCheesburger.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optCheesburger.Appearance");

        this.optCheesburger.BackgroundImage = (System.Drawing.Image) resources.GetObject("optCheesburger.BackgroundImage");

        this.optCheesburger.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCheesburger.CheckAlign");

        this.optCheesburger.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optCheesburger.Dock");

        this.optCheesburger.Enabled = (bool) resources.GetObject("optCheesburger.Enabled");

        this.optCheesburger.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optCheesburger.FlatStyle");

        this.optCheesburger.Font = (System.Drawing.Font) resources.GetObject("optCheesburger.Font");

        this.optCheesburger.Image = (System.Drawing.Image) resources.GetObject("optCheesburger.Image");

        this.optCheesburger.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCheesburger.ImageAlign");

        this.optCheesburger.ImageIndex = (int) resources.GetObject("optCheesburger.ImageIndex");

        this.optCheesburger.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optCheesburger.ImeMode");

        this.optCheesburger.Location = (System.Drawing.Point) resources.GetObject("optCheesburger.Location");

        this.optCheesburger.Name = "optCheesburger";

        this.optCheesburger.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optCheesburger.RightToLeft");

        this.optCheesburger.Size = (System.Drawing.Size) resources.GetObject("optCheesburger.Size");

        this.optCheesburger.TabIndex = (int) resources.GetObject("optCheesburger.TabIndex");

        this.optCheesburger.Text = resources.GetString("optCheesburger.Text");

        this.optCheesburger.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCheesburger.TextAlign");

        this.optCheesburger.Visible = (bool) resources.GetObject("optCheesburger.Visible");

        //

        //chkMayo

        //

        this.chkMayo.AccessibleDescription = resources.GetString("chkMayo.AccessibleDescription");

        this.chkMayo.AccessibleName = resources.GetString("chkMayo.AccessibleName");

        this.chkMayo.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkMayo.Anchor");

        this.chkMayo.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkMayo.Appearance");

        this.chkMayo.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkMayo.BackgroundImage");

        this.chkMayo.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMayo.CheckAlign");

        this.chkMayo.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkMayo.Dock");

        this.chkMayo.Enabled = (bool) resources.GetObject("chkMayo.Enabled");

        this.chkMayo.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkMayo.FlatStyle");

        this.chkMayo.Font = (System.Drawing.Font) resources.GetObject("chkMayo.Font");

        this.chkMayo.Image = (System.Drawing.Image) resources.GetObject("chkMayo.Image");

        this.chkMayo.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMayo.ImageAlign");

        this.chkMayo.ImageIndex = (int) resources.GetObject("chkMayo.ImageIndex");

        this.chkMayo.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkMayo.ImeMode");

        this.chkMayo.Location = (System.Drawing.Point) resources.GetObject("chkMayo.Location");

        this.chkMayo.Name = "chkMayo";

        this.chkMayo.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkMayo.RightToLeft");

        this.chkMayo.Size = (System.Drawing.Size) resources.GetObject("chkMayo.Size");

        this.chkMayo.TabIndex = (int) resources.GetObject("chkMayo.TabIndex");

        this.chkMayo.Text = resources.GetString("chkMayo.Text");

        this.chkMayo.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMayo.TextAlign");

        this.chkMayo.Visible = (bool) resources.GetObject("chkMayo.Visible");

        //

        //chkKetchup

        //

        this.chkKetchup.AccessibleDescription = resources.GetString("chkKetchup.AccessibleDescription");

        this.chkKetchup.AccessibleName = resources.GetString("chkKetchup.AccessibleName");

        this.chkKetchup.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkKetchup.Anchor");

        this.chkKetchup.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkKetchup.Appearance");

        this.chkKetchup.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkKetchup.BackgroundImage");

        this.chkKetchup.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkKetchup.CheckAlign");

        this.chkKetchup.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkKetchup.Dock");

        this.chkKetchup.Enabled = (bool) resources.GetObject("chkKetchup.Enabled");

        this.chkKetchup.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkKetchup.FlatStyle");

        this.chkKetchup.Font = (System.Drawing.Font) resources.GetObject("chkKetchup.Font");

        this.chkKetchup.Image = (System.Drawing.Image) resources.GetObject("chkKetchup.Image");

        this.chkKetchup.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkKetchup.ImageAlign");

        this.chkKetchup.ImageIndex = (int) resources.GetObject("chkKetchup.ImageIndex");

        this.chkKetchup.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkKetchup.ImeMode");

        this.chkKetchup.Location = (System.Drawing.Point) resources.GetObject("chkKetchup.Location");

        this.chkKetchup.Name = "chkKetchup";

        this.chkKetchup.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkKetchup.RightToLeft");

        this.chkKetchup.Size = (System.Drawing.Size) resources.GetObject("chkKetchup.Size");

        this.chkKetchup.TabIndex = (int) resources.GetObject("chkKetchup.TabIndex");

        this.chkKetchup.Text = resources.GetString("chkKetchup.Text");

        this.chkKetchup.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkKetchup.TextAlign");

        this.chkKetchup.Visible = (bool) resources.GetObject("chkKetchup.Visible");

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

        //chkMustard

        //

        this.chkMustard.AccessibleDescription = resources.GetString("chkMustard.AccessibleDescription");

        this.chkMustard.AccessibleName = resources.GetString("chkMustard.AccessibleName");

        this.chkMustard.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkMustard.Anchor");

        this.chkMustard.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkMustard.Appearance");

        this.chkMustard.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkMustard.BackgroundImage");

        this.chkMustard.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMustard.CheckAlign");

        this.chkMustard.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkMustard.Dock");

        this.chkMustard.Enabled = (bool) resources.GetObject("chkMustard.Enabled");

        this.chkMustard.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkMustard.FlatStyle");

        this.chkMustard.Font = (System.Drawing.Font) resources.GetObject("chkMustard.Font");

        this.chkMustard.Image = (System.Drawing.Image) resources.GetObject("chkMustard.Image");

        this.chkMustard.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMustard.ImageAlign");

        this.chkMustard.ImageIndex = (int) resources.GetObject("chkMustard.ImageIndex");

        this.chkMustard.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkMustard.ImeMode");

        this.chkMustard.Location = (System.Drawing.Point) resources.GetObject("chkMustard.Location");

        this.chkMustard.Name = "chkMustard";

        this.chkMustard.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkMustard.RightToLeft");

        this.chkMustard.Size = (System.Drawing.Size) resources.GetObject("chkMustard.Size");

        this.chkMustard.TabIndex = (int) resources.GetObject("chkMustard.TabIndex");

        this.chkMustard.Text = resources.GetString("chkMustard.Text");

        this.chkMustard.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMustard.TextAlign");

        this.chkMustard.Visible = (bool) resources.GetObject("chkMustard.Visible");

        //

        //optHamburger

        //

        this.optHamburger.AccessibleDescription = resources.GetString("optHamburger.AccessibleDescription");

        this.optHamburger.AccessibleName = resources.GetString("optHamburger.AccessibleName");

        this.optHamburger.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optHamburger.Anchor");

        this.optHamburger.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optHamburger.Appearance");

        this.optHamburger.BackgroundImage = (System.Drawing.Image) resources.GetObject("optHamburger.BackgroundImage");

        this.optHamburger.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optHamburger.CheckAlign");

        this.optHamburger.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optHamburger.Dock");

        this.optHamburger.Enabled = (bool) resources.GetObject("optHamburger.Enabled");

        this.optHamburger.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optHamburger.FlatStyle");

        this.optHamburger.Font = (System.Drawing.Font) resources.GetObject("optHamburger.Font");

        this.optHamburger.Image = (System.Drawing.Image) resources.GetObject("optHamburger.Image");

        this.optHamburger.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optHamburger.ImageAlign");

        this.optHamburger.ImageIndex = (int) resources.GetObject("optHamburger.ImageIndex");

        this.optHamburger.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optHamburger.ImeMode");

        this.optHamburger.Location = (System.Drawing.Point) resources.GetObject("optHamburger.Location");

        this.optHamburger.Name = "optHamburger";

        this.optHamburger.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optHamburger.RightToLeft");

        this.optHamburger.Size = (System.Drawing.Size) resources.GetObject("optHamburger.Size");

        this.optHamburger.TabIndex = (int) resources.GetObject("optHamburger.TabIndex");

        this.optHamburger.Text = resources.GetString("optHamburger.Text");

        this.optHamburger.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optHamburger.TextAlign");

        this.optHamburger.Visible = (bool) resources.GetObject("optHamburger.Visible");

        //

        //grpMainCourse

        //

        this.grpMainCourse.AccessibleDescription = (string) resources.GetObject("grpMainCourse.AccessibleDescription");

        this.grpMainCourse.AccessibleName = (string) resources.GetObject("grpMainCourse.AccessibleName");

        this.grpMainCourse.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grpMainCourse.Anchor");

        this.grpMainCourse.BackgroundImage = (System.Drawing.Image) resources.GetObject("grpMainCourse.BackgroundImage");

        this.grpMainCourse.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grpMainCourse.Dock");

        this.grpMainCourse.Enabled = (bool) resources.GetObject("grpMainCourse.Enabled");

        this.grpMainCourse.FlatStyle = System.Windows.Forms.FlatStyle.System;

        this.grpMainCourse.Font = (System.Drawing.Font) resources.GetObject("grpMainCourse.Font");

        this.grpMainCourse.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grpMainCourse.ImeMode");

        this.grpMainCourse.Location = (System.Drawing.Point) resources.GetObject("grpMainCourse.Location");

        this.grpMainCourse.Name = "grpMainCourse";

        this.grpMainCourse.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grpMainCourse.RightToLeft");

        this.grpMainCourse.Size = (System.Drawing.Size) resources.GetObject("grpMainCourse.Size");

        this.grpMainCourse.TabIndex = (int) resources.GetObject("grpMainCourse.TabIndex");

        this.grpMainCourse.TabStop = false;

        this.grpMainCourse.Text = resources.GetString("grpMainCourse.Text");

        this.grpMainCourse.Visible = (bool) resources.GetObject("grpMainCourse.Visible");

        //

        //grpCondiments

        //

        this.grpCondiments.AccessibleDescription = (string) resources.GetObject("grpCondiments.AccessibleDescription");

        this.grpCondiments.AccessibleName = (string) resources.GetObject("grpCondiments.AccessibleName");

        this.grpCondiments.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grpCondiments.Anchor");

        this.grpCondiments.BackgroundImage = (System.Drawing.Image) resources.GetObject("grpCondiments.BackgroundImage");

        this.grpCondiments.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grpCondiments.Dock");

        this.grpCondiments.Enabled = (bool) resources.GetObject("grpCondiments.Enabled");

        this.grpCondiments.FlatStyle = System.Windows.Forms.FlatStyle.System;

        this.grpCondiments.Font = (System.Drawing.Font) resources.GetObject("grpCondiments.Font");

        this.grpCondiments.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grpCondiments.ImeMode");

        this.grpCondiments.Location = (System.Drawing.Point) resources.GetObject("grpCondiments.Location");

        this.grpCondiments.Name = "grpCondiments";

        this.grpCondiments.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grpCondiments.RightToLeft");

        this.grpCondiments.Size = (System.Drawing.Size) resources.GetObject("grpCondiments.Size");

        this.grpCondiments.TabIndex = (int) resources.GetObject("grpCondiments.TabIndex");

        this.grpCondiments.TabStop = false;

        this.grpCondiments.Text = resources.GetString("grpCondiments.Text");

        this.grpCondiments.Visible = (bool) resources.GetObject("grpCondiments.Visible");

        //

        //TabPage2

        //

        this.TabPage2.AccessibleDescription = (string) resources.GetObject("TabPage2.AccessibleDescription");

        this.TabPage2.AccessibleName = (string) resources.GetObject("TabPage2.AccessibleName");

        this.TabPage2.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("TabPage2.Anchor");

        this.TabPage2.AutoScroll = (bool) resources.GetObject("TabPage2.AutoScroll");

        this.TabPage2.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("TabPage2.AutoScrollMargin");

        this.TabPage2.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("TabPage2.AutoScrollMinSize");

        this.TabPage2.BackgroundImage = (System.Drawing.Image) resources.GetObject("TabPage2.BackgroundImage");

        this.TabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label9, this.CheckedListBox1, this.DataGrid1, this.dudMaleFemale});

        this.TabPage2.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("TabPage2.Dock");

        this.TabPage2.Enabled = (bool) resources.GetObject("TabPage2.Enabled");

        this.TabPage2.Font = (System.Drawing.Font) resources.GetObject("TabPage2.Font");

        this.TabPage2.ImageIndex = (int) resources.GetObject("TabPage2.ImageIndex");

        this.TabPage2.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("TabPage2.ImeMode");

        this.TabPage2.Location = (System.Drawing.Point) resources.GetObject("TabPage2.Location");

        this.TabPage2.Name = "TabPage2";

        this.TabPage2.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("TabPage2.RightToLeft");

        this.TabPage2.Size = (System.Drawing.Size) resources.GetObject("TabPage2.Size");

        this.TabPage2.TabIndex = (int) resources.GetObject("TabPage2.TabIndex");

        this.TabPage2.Tag = "Non_Supported_Controls";

        this.TabPage2.Text = resources.GetString("TabPage2.Text");

        this.TabPage2.ToolTipText = resources.GetString("TabPage2.ToolTipText");

        this.TabPage2.Visible = (bool) resources.GetObject("TabPage2.Visible");

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

        //CheckedListBox1

        //

        this.CheckedListBox1.AccessibleDescription = resources.GetString("CheckedListBox1.AccessibleDescription");

        this.CheckedListBox1.AccessibleName = resources.GetString("CheckedListBox1.AccessibleName");

        this.CheckedListBox1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("CheckedListBox1.Anchor");

        this.CheckedListBox1.BackgroundImage = (System.Drawing.Image) resources.GetObject("CheckedListBox1.BackgroundImage");

        this.CheckedListBox1.ColumnWidth = (int) resources.GetObject("CheckedListBox1.ColumnWidth");

        this.CheckedListBox1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("CheckedListBox1.Dock");

        this.CheckedListBox1.Enabled = (bool) resources.GetObject("CheckedListBox1.Enabled");

        this.CheckedListBox1.Font = (System.Drawing.Font) resources.GetObject("CheckedListBox1.Font");

        this.CheckedListBox1.HorizontalExtent = (int) resources.GetObject("CheckedListBox1.HorizontalExtent");

        this.CheckedListBox1.HorizontalScrollbar = (bool) resources.GetObject("CheckedListBox1.HorizontalScrollbar");

        this.CheckedListBox1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("CheckedListBox1.ImeMode");

        this.CheckedListBox1.IntegralHeight = (bool) resources.GetObject("CheckedListBox1.IntegralHeight");

        this.CheckedListBox1.Items.AddRange(new Object[] {resources.GetString("CheckedListBox1.Items.Items"), resources.GetString("CheckedListBox1.Items.Items1")});

        this.CheckedListBox1.Location = (System.Drawing.Point) resources.GetObject("CheckedListBox1.Location");

        this.CheckedListBox1.Name = "CheckedListBox1";

        this.CheckedListBox1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("CheckedListBox1.RightToLeft");

        this.CheckedListBox1.ScrollAlwaysVisible = (bool) resources.GetObject("CheckedListBox1.ScrollAlwaysVisible");

        this.CheckedListBox1.Size = (System.Drawing.Size) resources.GetObject("CheckedListBox1.Size");

        this.CheckedListBox1.TabIndex = (int) resources.GetObject("CheckedListBox1.TabIndex");

        this.CheckedListBox1.Visible = (bool) resources.GetObject("CheckedListBox1.Visible");

        //

        //DataGrid1

        //

        this.DataGrid1.AccessibleDescription = resources.GetString("DataGrid1.AccessibleDescription");

        this.DataGrid1.AccessibleName = resources.GetString("DataGrid1.AccessibleName");

        this.DataGrid1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("DataGrid1.Anchor");

        this.DataGrid1.BackgroundImage = (System.Drawing.Image) resources.GetObject("DataGrid1.BackgroundImage");

        this.DataGrid1.CaptionFont = (System.Drawing.Font) resources.GetObject("DataGrid1.CaptionFont");

        this.DataGrid1.CaptionText = resources.GetString("DataGrid1.CaptionText");

        this.DataGrid1.DataMember = "";

        this.DataGrid1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("DataGrid1.Dock");

        this.DataGrid1.Enabled = (bool) resources.GetObject("DataGrid1.Enabled");

        this.DataGrid1.FlatMode = true;

        this.DataGrid1.Font = (System.Drawing.Font) resources.GetObject("DataGrid1.Font");

        this.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.DataGrid1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("DataGrid1.ImeMode");

        this.DataGrid1.Location = (System.Drawing.Point) resources.GetObject("DataGrid1.Location");

        this.DataGrid1.Name = "DataGrid1";

        this.DataGrid1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("DataGrid1.RightToLeft");

        this.DataGrid1.Size = (System.Drawing.Size) resources.GetObject("DataGrid1.Size");

        this.DataGrid1.TabIndex = (int) resources.GetObject("DataGrid1.TabIndex");

        this.DataGrid1.Visible = (bool) resources.GetObject("DataGrid1.Visible");

        //

        //dudMaleFemale

        //

        this.dudMaleFemale.AccessibleDescription = resources.GetString("dudMaleFemale.AccessibleDescription");

        this.dudMaleFemale.AccessibleName = resources.GetString("dudMaleFemale.AccessibleName");

        this.dudMaleFemale.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("dudMaleFemale.Anchor");

        this.dudMaleFemale.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("dudMaleFemale.Dock");

        this.dudMaleFemale.Enabled = (bool) resources.GetObject("dudMaleFemale.Enabled");

        this.dudMaleFemale.Font = (System.Drawing.Font) resources.GetObject("dudMaleFemale.Font");

        this.dudMaleFemale.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("dudMaleFemale.ImeMode");

        this.dudMaleFemale.Items.Add(resources.GetString("dudMaleFemale.Items.Items"));

        this.dudMaleFemale.Items.Add(resources.GetString("dudMaleFemale.Items.Items1"));

        this.dudMaleFemale.Location = (System.Drawing.Point) resources.GetObject("dudMaleFemale.Location");

        this.dudMaleFemale.Name = "dudMaleFemale";

        this.dudMaleFemale.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("dudMaleFemale.RightToLeft");

        this.dudMaleFemale.Size = (System.Drawing.Size) resources.GetObject("dudMaleFemale.Size");

        this.dudMaleFemale.TabIndex = (int) resources.GetObject("dudMaleFemale.TabIndex");

        this.dudMaleFemale.Text = resources.GetString("dudMaleFemale.Text");

        this.dudMaleFemale.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("dudMaleFemale.TextAlign");

        this.dudMaleFemale.UpDownAlign = (System.Windows.Forms.LeftRightAlignment) resources.GetObject("dudMaleFemale.UpDownAlign");

        this.dudMaleFemale.Visible = (bool) resources.GetObject("dudMaleFemale.Visible");

        this.dudMaleFemale.Wrap = (bool) resources.GetObject("dudMaleFemale.Wrap");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.tabMain});

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
        this.tabMain.ResumeLayout(false);
        this.TabPage1.ResumeLayout(false);
        this.TabPage3.ResumeLayout(false);
        this.TabPage2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
		this.Load += new EventHandler(frmMain_Load);
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
        this.ResumeLayout(false);

    }

#endregion

#region " Standard Menu Code "

	// has been added to some procedures since they are

	// not the focus of the demo. Remove them if you wish to debug the procedures.

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

#region "SetupControlDefaultValues";

    private void SetupControlDefaultValues()
	{

        // Set some default values for the controls on the form.

        cboDepartureCity.SelectedIndex = 0;

        cboArrivalCity.SelectedIndex = 1;

        calDepartureDate.ShowToday = false;

        calArrivalDate.ShowToday = false;

        calDepartureDate.SetDate(DateTime.Now.AddDays(7));

        calArrivalDate.SetDate(DateTime.Now.AddDays(14));
		
		System.Data.DataTable dt = new DataTable();
        dt.Columns.Add("Product Name");

        dt.Columns.Add("Product Price");

        DataRow dr = dt.NewRow();
        // Add Row 1
        //dr = dt.NewRow();
		
        dr["Product Name"] = "Ketchup";
        dr["Product Price"] = "1.24";

        dt.Rows.Add(dr);

        // Add Row 2

        dr = dt.NewRow();

        dr["Product Name"] = "Mustard";

        dr["Product Price"] = "1.37";

        dt.Rows.Add(dr);

        DataGrid1.DataSource = dt;

        dudMaleFemale.SelectedIndex = 0;

    }

#endregion

    // Enabling XP Theme support is largely a matter of associating your application with the appropriate

    // defined manifest file.

    // Information on how to do this is placed in the readme.htm associated with this How-To.

    // A manifest file is already associated with this application and thererfore the application 

    // will automatically support the current theme for controls that support themeing.

    // No code and only the setting of a single property on a few controls that do not automatically

    // support themes with their default property settings is all that is needed.

    private void frmMain_Load(object sender, System.EventArgs e)
	{

        SetupControlDefaultValues();

    }

}

