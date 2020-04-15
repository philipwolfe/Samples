//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

public class frmMain: System.Windows.Forms.Form {

    // The necessary class variables are declared here
    Pen m_Pen = new Pen(Color.Black);
    Color m_penColor = Color.BurlyWood;
    Brush m_penBrush = new SolidBrush(Color.Black);
    Pen m_BlackThinPen = new Pen(Color.Black);
    Graphics graphic;
	bool suppressEvent = false;

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

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
    private System.Windows.Forms.Button btnSetColor;
    private System.Windows.Forms.TextBox txtColor;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.PictureBox pbLines;
    private System.Windows.Forms.Label Label5;
    private System.Windows.Forms.ComboBox comboShape;
    private System.Windows.Forms.NumericUpDown updownWidth;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.ComboBox comboStartCap;
    private System.Windows.Forms.ComboBox comboEndCap;
    private System.Windows.Forms.Label Label6;
    private System.Windows.Forms.ComboBox comboDashCap;
    private System.Windows.Forms.Label Label7;
    private System.Windows.Forms.ComboBox comboLineJoin;
    private System.Windows.Forms.Label Label8;
    private System.Windows.Forms.Label Label9;
    private System.Windows.Forms.ComboBox comboLineStyle;
    private System.Windows.Forms.ComboBox comboAlignment;
    private System.Windows.Forms.Label Label10;
    private System.Windows.Forms.GroupBox GroupBox1;
    private System.Windows.Forms.RadioButton radioBrush;
    private System.Windows.Forms.RadioButton radioColor;
    private System.Windows.Forms.ComboBox comboBrush;
    private System.Windows.Forms.Label Label11;
    private System.Windows.Forms.NumericUpDown updownMiterLimit;
    private System.Windows.Forms.Label Label12;
    private System.Windows.Forms.ComboBox comboTransform;
    private System.Windows.Forms.Button btnCycle;
    private System.Windows.Forms.Timer timerCycle;

    private void InitializeComponent() {

        this.components = new System.ComponentModel.Container();

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.comboAlignment = new System.Windows.Forms.ComboBox();

        this.Label1 = new System.Windows.Forms.Label();

        this.txtColor = new System.Windows.Forms.TextBox();

        this.btnSetColor = new System.Windows.Forms.Button();

        this.Label2 = new System.Windows.Forms.Label();

        this.Label3 = new System.Windows.Forms.Label();

        this.pbLines = new System.Windows.Forms.PictureBox();

        this.Label5 = new System.Windows.Forms.Label();

        this.comboShape = new System.Windows.Forms.ComboBox();

        this.updownWidth = new System.Windows.Forms.NumericUpDown();

        this.Label4 = new System.Windows.Forms.Label();

        this.comboStartCap = new System.Windows.Forms.ComboBox();

        this.comboEndCap = new System.Windows.Forms.ComboBox();

        this.Label6 = new System.Windows.Forms.Label();

        this.comboDashCap = new System.Windows.Forms.ComboBox();

        this.Label7 = new System.Windows.Forms.Label();

        this.comboLineJoin = new System.Windows.Forms.ComboBox();

        this.Label8 = new System.Windows.Forms.Label();

        this.comboLineStyle = new System.Windows.Forms.ComboBox();

        this.Label9 = new System.Windows.Forms.Label();

        this.comboBrush = new System.Windows.Forms.ComboBox();

        this.Label10 = new System.Windows.Forms.Label();

        this.GroupBox1 = new System.Windows.Forms.GroupBox();

        this.radioBrush = new System.Windows.Forms.RadioButton();

        this.radioColor = new System.Windows.Forms.RadioButton();

        this.Label11 = new System.Windows.Forms.Label();

        this.updownMiterLimit = new System.Windows.Forms.NumericUpDown();

        this.comboTransform = new System.Windows.Forms.ComboBox();

        this.Label12 = new System.Windows.Forms.Label();

        this.btnCycle = new System.Windows.Forms.Button();

        this.timerCycle = new System.Windows.Forms.Timer(this.components);

        ((System.ComponentModel.ISupportInitialize) this.updownWidth).BeginInit();

        this.GroupBox1.SuspendLayout();

        ((System.ComponentModel.ISupportInitialize) this.updownMiterLimit).BeginInit();

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

        //comboAlignment

        //

        this.comboAlignment.AccessibleDescription = resources.GetString("comboAlignment.AccessibleDescription");

        this.comboAlignment.AccessibleName = resources.GetString("comboAlignment.AccessibleName");

        this.comboAlignment.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("comboAlignment.Anchor");

        this.comboAlignment.BackgroundImage = (System.Drawing.Image) resources.GetObject("comboAlignment.BackgroundImage");

        this.comboAlignment.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("comboAlignment.Dock");

        this.comboAlignment.Enabled = (bool) resources.GetObject("comboAlignment.Enabled");

        this.comboAlignment.Font = (System.Drawing.Font) resources.GetObject("comboAlignment.Font");

        this.comboAlignment.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("comboAlignment.ImeMode");

        this.comboAlignment.IntegralHeight = (bool) resources.GetObject("comboAlignment.IntegralHeight");

        this.comboAlignment.ItemHeight = (int) resources.GetObject("comboAlignment.ItemHeight");

        this.comboAlignment.Location = (System.Drawing.Point) resources.GetObject("comboAlignment.Location");

        this.comboAlignment.MaxDropDownItems = (int) resources.GetObject("comboAlignment.MaxDropDownItems");

        this.comboAlignment.MaxLength = (int) resources.GetObject("comboAlignment.MaxLength");

        this.comboAlignment.Name = "comboAlignment";

        this.comboAlignment.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("comboAlignment.RightToLeft");

        this.comboAlignment.Size = (System.Drawing.Size) resources.GetObject("comboAlignment.Size");

        this.comboAlignment.TabIndex = (int) resources.GetObject("comboAlignment.TabIndex");

        this.comboAlignment.Text = resources.GetString("comboAlignment.Text");

        this.comboAlignment.Visible = (bool) resources.GetObject("comboAlignment.Visible");

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

        //txtColor

        //

        this.txtColor.AccessibleDescription = resources.GetString("txtColor.AccessibleDescription");

        this.txtColor.AccessibleName = resources.GetString("txtColor.AccessibleName");

        this.txtColor.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtColor.Anchor");

        this.txtColor.AutoSize = (bool) resources.GetObject("txtColor.AutoSize");

        this.txtColor.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtColor.BackgroundImage");

        this.txtColor.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtColor.Dock");

        this.txtColor.Enabled = (bool) resources.GetObject("txtColor.Enabled");

        this.txtColor.Font = (System.Drawing.Font) resources.GetObject("txtColor.Font");

        this.txtColor.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtColor.ImeMode");

        this.txtColor.Location = (System.Drawing.Point) resources.GetObject("txtColor.Location");

        this.txtColor.MaxLength = (int) resources.GetObject("txtColor.MaxLength");

        this.txtColor.Multiline = (bool) resources.GetObject("txtColor.Multiline");

        this.txtColor.Name = "txtColor";

        this.txtColor.PasswordChar = (char) resources.GetObject("txtColor.PasswordChar");

        this.txtColor.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtColor.RightToLeft");

        this.txtColor.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtColor.ScrollBars");

        this.txtColor.Size = (System.Drawing.Size) resources.GetObject("txtColor.Size");

        this.txtColor.TabIndex = (int) resources.GetObject("txtColor.TabIndex");

        this.txtColor.Text = resources.GetString("txtColor.Text");

        this.txtColor.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtColor.TextAlign");

        this.txtColor.Visible = (bool) resources.GetObject("txtColor.Visible");

        this.txtColor.WordWrap = (bool) resources.GetObject("txtColor.WordWrap");

        //

        //btnSetColor

        //

        this.btnSetColor.AccessibleDescription = resources.GetString("btnSetColor.AccessibleDescription");

        this.btnSetColor.AccessibleName = resources.GetString("btnSetColor.AccessibleName");

        this.btnSetColor.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSetColor.Anchor");

        this.btnSetColor.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSetColor.BackgroundImage");

        this.btnSetColor.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSetColor.Dock");

        this.btnSetColor.Enabled = (bool) resources.GetObject("btnSetColor.Enabled");

        this.btnSetColor.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSetColor.FlatStyle");

        this.btnSetColor.Font = (System.Drawing.Font) resources.GetObject("btnSetColor.Font");

        this.btnSetColor.Image = (System.Drawing.Image) resources.GetObject("btnSetColor.Image");

        this.btnSetColor.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSetColor.ImageAlign");

        this.btnSetColor.ImageIndex = (int) resources.GetObject("btnSetColor.ImageIndex");

        this.btnSetColor.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSetColor.ImeMode");

        this.btnSetColor.Location = (System.Drawing.Point) resources.GetObject("btnSetColor.Location");

        this.btnSetColor.Name = "btnSetColor";

        this.btnSetColor.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSetColor.RightToLeft");

        this.btnSetColor.Size = (System.Drawing.Size) resources.GetObject("btnSetColor.Size");

        this.btnSetColor.TabIndex = (int) resources.GetObject("btnSetColor.TabIndex");

        this.btnSetColor.Text = resources.GetString("btnSetColor.Text");

        this.btnSetColor.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSetColor.TextAlign");

        this.btnSetColor.Visible = (bool) resources.GetObject("btnSetColor.Visible");

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

        //pbLines

        //

        this.pbLines.AccessibleDescription = resources.GetString("pbLines.AccessibleDescription");

        this.pbLines.AccessibleName = resources.GetString("pbLines.AccessibleName");

        this.pbLines.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pbLines.Anchor");

        this.pbLines.BackgroundImage = (System.Drawing.Image) resources.GetObject("pbLines.BackgroundImage");

        this.pbLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.pbLines.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pbLines.Dock");

        this.pbLines.Enabled = (bool) resources.GetObject("pbLines.Enabled");

        this.pbLines.Font = (System.Drawing.Font) resources.GetObject("pbLines.Font");

        this.pbLines.Image = (System.Drawing.Image) resources.GetObject("pbLines.Image");

        this.pbLines.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pbLines.ImeMode");

        this.pbLines.Location = (System.Drawing.Point) resources.GetObject("pbLines.Location");

        this.pbLines.Name = "pbLines";

        this.pbLines.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pbLines.RightToLeft");

        this.pbLines.Size = (System.Drawing.Size) resources.GetObject("pbLines.Size");

        this.pbLines.SizeMode = (System.Windows.Forms.PictureBoxSizeMode) resources.GetObject("pbLines.SizeMode");

        this.pbLines.TabIndex = (int) resources.GetObject("pbLines.TabIndex");

        this.pbLines.TabStop = false;

        this.pbLines.Text = resources.GetString("pbLines.Text");

        this.pbLines.Visible = (bool) resources.GetObject("pbLines.Visible");

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

        //comboShape

        //

        this.comboShape.AccessibleDescription = resources.GetString("comboShape.AccessibleDescription");

        this.comboShape.AccessibleName = resources.GetString("comboShape.AccessibleName");

        this.comboShape.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("comboShape.Anchor");

        this.comboShape.BackgroundImage = (System.Drawing.Image) resources.GetObject("comboShape.BackgroundImage");

        this.comboShape.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("comboShape.Dock");

        this.comboShape.Enabled = (bool) resources.GetObject("comboShape.Enabled");

        this.comboShape.Font = (System.Drawing.Font) resources.GetObject("comboShape.Font");

        this.comboShape.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("comboShape.ImeMode");

        this.comboShape.IntegralHeight = (bool) resources.GetObject("comboShape.IntegralHeight");

        this.comboShape.ItemHeight = (int) resources.GetObject("comboShape.ItemHeight");

        this.comboShape.Items.AddRange(new Object[] {resources.GetString("comboShape.Items.Items"), resources.GetString("comboShape.Items.Items1"), resources.GetString("comboShape.Items.Items2")});

        this.comboShape.Location = (System.Drawing.Point) resources.GetObject("comboShape.Location");

        this.comboShape.MaxDropDownItems = (int) resources.GetObject("comboShape.MaxDropDownItems");

        this.comboShape.MaxLength = (int) resources.GetObject("comboShape.MaxLength");

        this.comboShape.Name = "comboShape";

        this.comboShape.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("comboShape.RightToLeft");

        this.comboShape.Size = (System.Drawing.Size) resources.GetObject("comboShape.Size");

        this.comboShape.TabIndex = (int) resources.GetObject("comboShape.TabIndex");

        this.comboShape.Text = resources.GetString("comboShape.Text");

        this.comboShape.Visible = (bool) resources.GetObject("comboShape.Visible");

        //

        //updownWidth

        //

        this.updownWidth.AccessibleDescription = resources.GetString("updownWidth.AccessibleDescription");

        this.updownWidth.AccessibleName = resources.GetString("updownWidth.AccessibleName");

        this.updownWidth.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("updownWidth.Anchor");

        this.updownWidth.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("updownWidth.Dock");

        this.updownWidth.Enabled = (bool) resources.GetObject("updownWidth.Enabled");

        this.updownWidth.Font = (System.Drawing.Font) resources.GetObject("updownWidth.Font");

        this.updownWidth.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("updownWidth.ImeMode");

        this.updownWidth.Location = (System.Drawing.Point) resources.GetObject("updownWidth.Location");

        this.updownWidth.Maximum = new Decimal(new int[] {50, 0, 0, 0});

        this.updownWidth.Minimum = new Decimal(new int[] {1, 0, 0, 0});

        this.updownWidth.Name = "updownWidth";

        this.updownWidth.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("updownWidth.RightToLeft");

        this.updownWidth.Size = (System.Drawing.Size) resources.GetObject("updownWidth.Size");

        this.updownWidth.TabIndex = (int) resources.GetObject("updownWidth.TabIndex");

        this.updownWidth.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("updownWidth.TextAlign");

        this.updownWidth.ThousandsSeparator = (bool) resources.GetObject("updownWidth.ThousandsSeparator");

        this.updownWidth.UpDownAlign = (System.Windows.Forms.LeftRightAlignment) resources.GetObject("updownWidth.UpDownAlign");

        this.updownWidth.Value = new Decimal(new int[] {25, 0, 0, 0});

        this.updownWidth.Visible = (bool) resources.GetObject("updownWidth.Visible");

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

        //comboStartCap

        //

        this.comboStartCap.AccessibleDescription = resources.GetString("comboStartCap.AccessibleDescription");

        this.comboStartCap.AccessibleName = resources.GetString("comboStartCap.AccessibleName");

        this.comboStartCap.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("comboStartCap.Anchor");

        this.comboStartCap.BackgroundImage = (System.Drawing.Image) resources.GetObject("comboStartCap.BackgroundImage");

        this.comboStartCap.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("comboStartCap.Dock");

        this.comboStartCap.Enabled = (bool) resources.GetObject("comboStartCap.Enabled");

        this.comboStartCap.Font = (System.Drawing.Font) resources.GetObject("comboStartCap.Font");

        this.comboStartCap.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("comboStartCap.ImeMode");

        this.comboStartCap.IntegralHeight = (bool) resources.GetObject("comboStartCap.IntegralHeight");

        this.comboStartCap.ItemHeight = (int) resources.GetObject("comboStartCap.ItemHeight");

        this.comboStartCap.Location = (System.Drawing.Point) resources.GetObject("comboStartCap.Location");

        this.comboStartCap.MaxDropDownItems = (int) resources.GetObject("comboStartCap.MaxDropDownItems");

        this.comboStartCap.MaxLength = (int) resources.GetObject("comboStartCap.MaxLength");

        this.comboStartCap.Name = "comboStartCap";

        this.comboStartCap.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("comboStartCap.RightToLeft");

        this.comboStartCap.Size = (System.Drawing.Size) resources.GetObject("comboStartCap.Size");

        this.comboStartCap.TabIndex = (int) resources.GetObject("comboStartCap.TabIndex");

        this.comboStartCap.Text = resources.GetString("comboStartCap.Text");

        this.comboStartCap.Visible = (bool) resources.GetObject("comboStartCap.Visible");

        //

        //comboEndCap

        //

        this.comboEndCap.AccessibleDescription = resources.GetString("comboEndCap.AccessibleDescription");

        this.comboEndCap.AccessibleName = resources.GetString("comboEndCap.AccessibleName");

        this.comboEndCap.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("comboEndCap.Anchor");

        this.comboEndCap.BackgroundImage = (System.Drawing.Image) resources.GetObject("comboEndCap.BackgroundImage");

        this.comboEndCap.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("comboEndCap.Dock");

        this.comboEndCap.Enabled = (bool) resources.GetObject("comboEndCap.Enabled");

        this.comboEndCap.Font = (System.Drawing.Font) resources.GetObject("comboEndCap.Font");

        this.comboEndCap.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("comboEndCap.ImeMode");

        this.comboEndCap.IntegralHeight = (bool) resources.GetObject("comboEndCap.IntegralHeight");

        this.comboEndCap.ItemHeight = (int) resources.GetObject("comboEndCap.ItemHeight");

        this.comboEndCap.Location = (System.Drawing.Point) resources.GetObject("comboEndCap.Location");

        this.comboEndCap.MaxDropDownItems = (int) resources.GetObject("comboEndCap.MaxDropDownItems");

        this.comboEndCap.MaxLength = (int) resources.GetObject("comboEndCap.MaxLength");

        this.comboEndCap.Name = "comboEndCap";

        this.comboEndCap.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("comboEndCap.RightToLeft");

        this.comboEndCap.Size = (System.Drawing.Size) resources.GetObject("comboEndCap.Size");

        this.comboEndCap.TabIndex = (int) resources.GetObject("comboEndCap.TabIndex");

        this.comboEndCap.Text = resources.GetString("comboEndCap.Text");

        this.comboEndCap.Visible = (bool) resources.GetObject("comboEndCap.Visible");

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

        //comboDashCap

        //

        this.comboDashCap.AccessibleDescription = resources.GetString("comboDashCap.AccessibleDescription");

        this.comboDashCap.AccessibleName = resources.GetString("comboDashCap.AccessibleName");

        this.comboDashCap.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("comboDashCap.Anchor");

        this.comboDashCap.BackgroundImage = (System.Drawing.Image) resources.GetObject("comboDashCap.BackgroundImage");

        this.comboDashCap.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("comboDashCap.Dock");

        this.comboDashCap.Enabled = (bool) resources.GetObject("comboDashCap.Enabled");

        this.comboDashCap.Font = (System.Drawing.Font) resources.GetObject("comboDashCap.Font");

        this.comboDashCap.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("comboDashCap.ImeMode");

        this.comboDashCap.IntegralHeight = (bool) resources.GetObject("comboDashCap.IntegralHeight");

        this.comboDashCap.ItemHeight = (int) resources.GetObject("comboDashCap.ItemHeight");

        this.comboDashCap.Location = (System.Drawing.Point) resources.GetObject("comboDashCap.Location");

        this.comboDashCap.MaxDropDownItems = (int) resources.GetObject("comboDashCap.MaxDropDownItems");

        this.comboDashCap.MaxLength = (int) resources.GetObject("comboDashCap.MaxLength");

        this.comboDashCap.Name = "comboDashCap";

        this.comboDashCap.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("comboDashCap.RightToLeft");

        this.comboDashCap.Size = (System.Drawing.Size) resources.GetObject("comboDashCap.Size");

        this.comboDashCap.TabIndex = (int) resources.GetObject("comboDashCap.TabIndex");

        this.comboDashCap.Text = resources.GetString("comboDashCap.Text");

        this.comboDashCap.Visible = (bool) resources.GetObject("comboDashCap.Visible");

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

        //comboLineJoin

        //

        this.comboLineJoin.AccessibleDescription = resources.GetString("comboLineJoin.AccessibleDescription");

        this.comboLineJoin.AccessibleName = resources.GetString("comboLineJoin.AccessibleName");

        this.comboLineJoin.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("comboLineJoin.Anchor");

        this.comboLineJoin.BackgroundImage = (System.Drawing.Image) resources.GetObject("comboLineJoin.BackgroundImage");

        this.comboLineJoin.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("comboLineJoin.Dock");

        this.comboLineJoin.Enabled = (bool) resources.GetObject("comboLineJoin.Enabled");

        this.comboLineJoin.Font = (System.Drawing.Font) resources.GetObject("comboLineJoin.Font");

        this.comboLineJoin.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("comboLineJoin.ImeMode");

        this.comboLineJoin.IntegralHeight = (bool) resources.GetObject("comboLineJoin.IntegralHeight");

        this.comboLineJoin.ItemHeight = (int) resources.GetObject("comboLineJoin.ItemHeight");

        this.comboLineJoin.Location = (System.Drawing.Point) resources.GetObject("comboLineJoin.Location");

        this.comboLineJoin.MaxDropDownItems = (int) resources.GetObject("comboLineJoin.MaxDropDownItems");

        this.comboLineJoin.MaxLength = (int) resources.GetObject("comboLineJoin.MaxLength");

        this.comboLineJoin.Name = "comboLineJoin";

        this.comboLineJoin.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("comboLineJoin.RightToLeft");

        this.comboLineJoin.Size = (System.Drawing.Size) resources.GetObject("comboLineJoin.Size");

        this.comboLineJoin.TabIndex = (int) resources.GetObject("comboLineJoin.TabIndex");

        this.comboLineJoin.Text = resources.GetString("comboLineJoin.Text");

        this.comboLineJoin.Visible = (bool) resources.GetObject("comboLineJoin.Visible");

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

        //comboLineStyle

        //

        this.comboLineStyle.AccessibleDescription = resources.GetString("comboLineStyle.AccessibleDescription");

        this.comboLineStyle.AccessibleName = resources.GetString("comboLineStyle.AccessibleName");

        this.comboLineStyle.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("comboLineStyle.Anchor");

        this.comboLineStyle.BackgroundImage = (System.Drawing.Image) resources.GetObject("comboLineStyle.BackgroundImage");

        this.comboLineStyle.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("comboLineStyle.Dock");

        this.comboLineStyle.Enabled = (bool) resources.GetObject("comboLineStyle.Enabled");

        this.comboLineStyle.Font = (System.Drawing.Font) resources.GetObject("comboLineStyle.Font");

        this.comboLineStyle.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("comboLineStyle.ImeMode");

        this.comboLineStyle.IntegralHeight = (bool) resources.GetObject("comboLineStyle.IntegralHeight");

        this.comboLineStyle.ItemHeight = (int) resources.GetObject("comboLineStyle.ItemHeight");

        this.comboLineStyle.Location = (System.Drawing.Point) resources.GetObject("comboLineStyle.Location");

        this.comboLineStyle.MaxDropDownItems = (int) resources.GetObject("comboLineStyle.MaxDropDownItems");

        this.comboLineStyle.MaxLength = (int) resources.GetObject("comboLineStyle.MaxLength");

        this.comboLineStyle.Name = "comboLineStyle";

        this.comboLineStyle.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("comboLineStyle.RightToLeft");

        this.comboLineStyle.Size = (System.Drawing.Size) resources.GetObject("comboLineStyle.Size");

        this.comboLineStyle.TabIndex = (int) resources.GetObject("comboLineStyle.TabIndex");

        this.comboLineStyle.Text = resources.GetString("comboLineStyle.Text");

        this.comboLineStyle.Visible = (bool) resources.GetObject("comboLineStyle.Visible");

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

        //comboBrush

        //

        this.comboBrush.AccessibleDescription = resources.GetString("comboBrush.AccessibleDescription");

        this.comboBrush.AccessibleName = resources.GetString("comboBrush.AccessibleName");

        this.comboBrush.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("comboBrush.Anchor");

        this.comboBrush.BackgroundImage = (System.Drawing.Image) resources.GetObject("comboBrush.BackgroundImage");

        this.comboBrush.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("comboBrush.Dock");

        this.comboBrush.Enabled = (bool) resources.GetObject("comboBrush.Enabled");

        this.comboBrush.Font = (System.Drawing.Font) resources.GetObject("comboBrush.Font");

        this.comboBrush.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("comboBrush.ImeMode");

        this.comboBrush.IntegralHeight = (bool) resources.GetObject("comboBrush.IntegralHeight");

        this.comboBrush.ItemHeight = (int) resources.GetObject("comboBrush.ItemHeight");

        this.comboBrush.Items.AddRange(new Object[] {resources.GetString("comboBrush.Items.Items"), resources.GetString("comboBrush.Items.Items1"), resources.GetString("comboBrush.Items.Items2"), resources.GetString("comboBrush.Items.Items3")});

        this.comboBrush.Location = (System.Drawing.Point) resources.GetObject("comboBrush.Location");

        this.comboBrush.MaxDropDownItems = (int) resources.GetObject("comboBrush.MaxDropDownItems");

        this.comboBrush.MaxLength = (int) resources.GetObject("comboBrush.MaxLength");

        this.comboBrush.Name = "comboBrush";

        this.comboBrush.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("comboBrush.RightToLeft");

        this.comboBrush.Size = (System.Drawing.Size) resources.GetObject("comboBrush.Size");

        this.comboBrush.TabIndex = (int) resources.GetObject("comboBrush.TabIndex");

        this.comboBrush.Text = resources.GetString("comboBrush.Text");

        this.comboBrush.Visible = (bool) resources.GetObject("comboBrush.Visible");

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

        //GroupBox1

        //

        this.GroupBox1.AccessibleDescription = (string) resources.GetObject("GroupBox1.AccessibleDescription");

        this.GroupBox1.AccessibleName = (string) resources.GetObject("GroupBox1.AccessibleName");

        this.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("GroupBox1.Anchor");

        this.GroupBox1.BackgroundImage = (System.Drawing.Image) resources.GetObject("GroupBox1.BackgroundImage");

        this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.radioBrush, this.radioColor});

        this.GroupBox1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("GroupBox1.Dock");

        this.GroupBox1.Enabled = (bool) resources.GetObject("GroupBox1.Enabled");

        this.GroupBox1.Font = (System.Drawing.Font) resources.GetObject("GroupBox1.Font");

        this.GroupBox1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("GroupBox1.ImeMode");

        this.GroupBox1.Location = (System.Drawing.Point) resources.GetObject("GroupBox1.Location");

        this.GroupBox1.Name = "GroupBox1";

        this.GroupBox1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("GroupBox1.RightToLeft");

        this.GroupBox1.Size = (System.Drawing.Size) resources.GetObject("GroupBox1.Size");

        this.GroupBox1.TabIndex = (int) resources.GetObject("GroupBox1.TabIndex");

        this.GroupBox1.TabStop = false;

        this.GroupBox1.Text = resources.GetString("GroupBox1.Text");

        this.GroupBox1.Visible = (bool) resources.GetObject("GroupBox1.Visible");

        //

        //radioBrush

        //

        this.radioBrush.AccessibleDescription = resources.GetString("radioBrush.AccessibleDescription");

        this.radioBrush.AccessibleName = resources.GetString("radioBrush.AccessibleName");

        this.radioBrush.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("radioBrush.Anchor");

        this.radioBrush.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("radioBrush.Appearance");

        this.radioBrush.BackgroundImage = (System.Drawing.Image) resources.GetObject("radioBrush.BackgroundImage");

        this.radioBrush.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("radioBrush.CheckAlign");

        this.radioBrush.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("radioBrush.Dock");

        this.radioBrush.Enabled = (bool) resources.GetObject("radioBrush.Enabled");

        this.radioBrush.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("radioBrush.FlatStyle");

        this.radioBrush.Font = (System.Drawing.Font) resources.GetObject("radioBrush.Font");

        this.radioBrush.Image = (System.Drawing.Image) resources.GetObject("radioBrush.Image");

        this.radioBrush.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("radioBrush.ImageAlign");

        this.radioBrush.ImageIndex = (int) resources.GetObject("radioBrush.ImageIndex");

        this.radioBrush.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("radioBrush.ImeMode");

        this.radioBrush.Location = (System.Drawing.Point) resources.GetObject("radioBrush.Location");

        this.radioBrush.Name = "radioBrush";

        this.radioBrush.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("radioBrush.RightToLeft");

        this.radioBrush.Size = (System.Drawing.Size) resources.GetObject("radioBrush.Size");

        this.radioBrush.TabIndex = (int) resources.GetObject("radioBrush.TabIndex");

        this.radioBrush.TabStop = true;

        this.radioBrush.Text = resources.GetString("radioBrush.Text");

        this.radioBrush.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("radioBrush.TextAlign");

        this.radioBrush.Visible = (bool) resources.GetObject("radioBrush.Visible");

        //

        //radioColor

        //

        this.radioColor.AccessibleDescription = resources.GetString("radioColor.AccessibleDescription");

        this.radioColor.AccessibleName = resources.GetString("radioColor.AccessibleName");

        this.radioColor.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("radioColor.Anchor");

        this.radioColor.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("radioColor.Appearance");

        this.radioColor.BackgroundImage = (System.Drawing.Image) resources.GetObject("radioColor.BackgroundImage");

        this.radioColor.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("radioColor.CheckAlign");

        this.radioColor.Checked = true;

        this.radioColor.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("radioColor.Dock");

        this.radioColor.Enabled = (bool) resources.GetObject("radioColor.Enabled");

        this.radioColor.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("radioColor.FlatStyle");

        this.radioColor.Font = (System.Drawing.Font) resources.GetObject("radioColor.Font");

        this.radioColor.Image = (System.Drawing.Image) resources.GetObject("radioColor.Image");

        this.radioColor.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("radioColor.ImageAlign");

        this.radioColor.ImageIndex = (int) resources.GetObject("radioColor.ImageIndex");

        this.radioColor.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("radioColor.ImeMode");

        this.radioColor.Location = (System.Drawing.Point) resources.GetObject("radioColor.Location");

        this.radioColor.Name = "radioColor";

        this.radioColor.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("radioColor.RightToLeft");

        this.radioColor.Size = (System.Drawing.Size) resources.GetObject("radioColor.Size");

        this.radioColor.TabIndex = (int) resources.GetObject("radioColor.TabIndex");

        this.radioColor.TabStop = true;

        this.radioColor.Text = resources.GetString("radioColor.Text");

        this.radioColor.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("radioColor.TextAlign");

        this.radioColor.Visible = (bool) resources.GetObject("radioColor.Visible");

        //

        //Label11

        //

        this.Label11.AccessibleDescription = resources.GetString("Label11.AccessibleDescription");

        this.Label11.AccessibleName = resources.GetString("Label11.AccessibleName");

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

        //updownMiterLimit

        //

        this.updownMiterLimit.AccessibleDescription = resources.GetString("updownMiterLimit.AccessibleDescription");

        this.updownMiterLimit.AccessibleName = resources.GetString("updownMiterLimit.AccessibleName");

        this.updownMiterLimit.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("updownMiterLimit.Anchor");

        this.updownMiterLimit.DecimalPlaces = 2;

        this.updownMiterLimit.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("updownMiterLimit.Dock");

        this.updownMiterLimit.Enabled = (bool) resources.GetObject("updownMiterLimit.Enabled");

        this.updownMiterLimit.Font = (System.Drawing.Font) resources.GetObject("updownMiterLimit.Font");

        this.updownMiterLimit.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("updownMiterLimit.ImeMode");

        this.updownMiterLimit.Increment = new Decimal(new int[] {25, 0, 0, 131072});

        this.updownMiterLimit.Location = (System.Drawing.Point) resources.GetObject("updownMiterLimit.Location");

        this.updownMiterLimit.Maximum = new Decimal(new int[] {15, 0, 0, 0});

        this.updownMiterLimit.Name = "updownMiterLimit";

        this.updownMiterLimit.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("updownMiterLimit.RightToLeft");

        this.updownMiterLimit.Size = (System.Drawing.Size) resources.GetObject("updownMiterLimit.Size");

        this.updownMiterLimit.TabIndex = (int) resources.GetObject("updownMiterLimit.TabIndex");

        this.updownMiterLimit.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("updownMiterLimit.TextAlign");

        this.updownMiterLimit.ThousandsSeparator = (bool) resources.GetObject("updownMiterLimit.ThousandsSeparator");

        this.updownMiterLimit.UpDownAlign = (System.Windows.Forms.LeftRightAlignment) resources.GetObject("updownMiterLimit.UpDownAlign");

        this.updownMiterLimit.Value = new Decimal(new int[] {4, 0, 0, 0});

        this.updownMiterLimit.Visible = (bool) resources.GetObject("updownMiterLimit.Visible");

        //

        //comboTransform

        //

        this.comboTransform.AccessibleDescription = resources.GetString("comboTransform.AccessibleDescription");

        this.comboTransform.AccessibleName = resources.GetString("comboTransform.AccessibleName");

        this.comboTransform.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("comboTransform.Anchor");

        this.comboTransform.BackgroundImage = (System.Drawing.Image) resources.GetObject("comboTransform.BackgroundImage");

        this.comboTransform.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("comboTransform.Dock");

        this.comboTransform.Enabled = (bool) resources.GetObject("comboTransform.Enabled");

        this.comboTransform.Font = (System.Drawing.Font) resources.GetObject("comboTransform.Font");

        this.comboTransform.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("comboTransform.ImeMode");

        this.comboTransform.IntegralHeight = (bool) resources.GetObject("comboTransform.IntegralHeight");

        this.comboTransform.ItemHeight = (int) resources.GetObject("comboTransform.ItemHeight");

        this.comboTransform.Items.AddRange(new Object[] {resources.GetString("comboTransform.Items.Items"), resources.GetString("comboTransform.Items.Items1"), resources.GetString("comboTransform.Items.Items2"), resources.GetString("comboTransform.Items.Items3")});

        this.comboTransform.Location = (System.Drawing.Point) resources.GetObject("comboTransform.Location");

        this.comboTransform.MaxDropDownItems = (int) resources.GetObject("comboTransform.MaxDropDownItems");

        this.comboTransform.MaxLength = (int) resources.GetObject("comboTransform.MaxLength");

        this.comboTransform.Name = "comboTransform";

        this.comboTransform.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("comboTransform.RightToLeft");

        this.comboTransform.Size = (System.Drawing.Size) resources.GetObject("comboTransform.Size");

        this.comboTransform.TabIndex = (int) resources.GetObject("comboTransform.TabIndex");

        this.comboTransform.Text = resources.GetString("comboTransform.Text");

        this.comboTransform.Visible = (bool) resources.GetObject("comboTransform.Visible");

        //

        //Label12

        //

        this.Label12.AccessibleDescription = resources.GetString("Label12.AccessibleDescription");

        this.Label12.AccessibleName = resources.GetString("Label12.AccessibleName");

        this.Label12.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label12.Anchor");

        this.Label12.AutoSize = (bool) resources.GetObject("Label12.AutoSize");

        this.Label12.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label12.Dock");

        this.Label12.Enabled = (bool) resources.GetObject("Label12.Enabled");

        this.Label12.Font = (System.Drawing.Font) resources.GetObject("Label12.Font");

        this.Label12.Image = (System.Drawing.Image) resources.GetObject("Label12.Image");

        this.Label12.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label12.ImageAlign");

        this.Label12.ImageIndex = (int) resources.GetObject("Label12.ImageIndex");

        this.Label12.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label12.ImeMode");

        this.Label12.Location = (System.Drawing.Point) resources.GetObject("Label12.Location");

        this.Label12.Name = "Label12";

        this.Label12.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label12.RightToLeft");

        this.Label12.Size = (System.Drawing.Size) resources.GetObject("Label12.Size");

        this.Label12.TabIndex = (int) resources.GetObject("Label12.TabIndex");

        this.Label12.Text = resources.GetString("Label12.Text");

        this.Label12.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label12.TextAlign");

        this.Label12.Visible = (bool) resources.GetObject("Label12.Visible");

        //

        //btnCycle

        //

        this.btnCycle.AccessibleDescription = resources.GetString("btnCycle.AccessibleDescription");

        this.btnCycle.AccessibleName = resources.GetString("btnCycle.AccessibleName");

        this.btnCycle.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCycle.Anchor");

        this.btnCycle.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCycle.BackgroundImage");

        this.btnCycle.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCycle.Dock");

        this.btnCycle.Enabled = (bool) resources.GetObject("btnCycle.Enabled");

        this.btnCycle.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCycle.FlatStyle");

        this.btnCycle.Font = (System.Drawing.Font) resources.GetObject("btnCycle.Font");

        this.btnCycle.Image = (System.Drawing.Image) resources.GetObject("btnCycle.Image");

        this.btnCycle.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCycle.ImageAlign");

        this.btnCycle.ImageIndex = (int) resources.GetObject("btnCycle.ImageIndex");

        this.btnCycle.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCycle.ImeMode");

        this.btnCycle.Location = (System.Drawing.Point) resources.GetObject("btnCycle.Location");

        this.btnCycle.Name = "btnCycle";

        this.btnCycle.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCycle.RightToLeft");

        this.btnCycle.Size = (System.Drawing.Size) resources.GetObject("btnCycle.Size");

        this.btnCycle.TabIndex = (int) resources.GetObject("btnCycle.TabIndex");

        this.btnCycle.Text = resources.GetString("btnCycle.Text");

        this.btnCycle.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCycle.TextAlign");

        this.btnCycle.Visible = (bool) resources.GetObject("btnCycle.Visible");

        //

        //timerCycle

        //

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnCycle, this.comboTransform, this.Label12, this.Label11, this.updownMiterLimit, this.GroupBox1, this.comboLineStyle, this.Label9, this.comboLineJoin, this.Label8, this.comboEndCap, this.Label6, this.comboStartCap, this.Label4, this.updownWidth, this.Label5, this.comboShape, this.pbLines, this.Label3, this.Label2, this.btnSetColor, this.txtColor, this.Label1, this.comboAlignment, this.comboDashCap, this.Label7, this.comboBrush, this.Label10});

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

        ((System.ComponentModel.ISupportInitialize) this.updownWidth).EndInit();

        this.GroupBox1.ResumeLayout(false);

        ((System.ComponentModel.ISupportInitialize) this.updownMiterLimit).EndInit();

        this.ResumeLayout(false);

		this.Load +=new EventHandler(frmMain_Load);
		this.btnCycle.Click +=new EventHandler(btnCycle_Click);
		this.btnSetColor.Click +=new EventHandler(btnSetColor_Click);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.radioColor.CheckedChanged +=new EventHandler(radioColor_CheckedChanged);
		base.Activated +=new EventHandler(RedrawPicture);
		this.comboShape.SelectedIndexChanged +=new EventHandler(RedrawPicture);
		this.updownWidth.ValueChanged +=new EventHandler(RedrawPicture);
		this.txtColor.TextChanged +=new EventHandler(RedrawPicture);
		this.comboAlignment.SelectedIndexChanged +=new EventHandler(RedrawPicture);
		this.comboStartCap.SelectedIndexChanged +=new EventHandler(RedrawPicture);
		this.comboEndCap.SelectedIndexChanged +=new EventHandler(RedrawPicture);
		this.comboDashCap.SelectedIndexChanged +=new EventHandler(RedrawPicture);
		this.comboLineJoin.SelectedIndexChanged +=new EventHandler(RedrawPicture);
		this.comboLineStyle.SelectedIndexChanged +=new EventHandler(RedrawPicture);
		this.updownMiterLimit.ValueChanged +=new EventHandler(RedrawPicture);
		this.comboTransform.SelectedIndexChanged +=new EventHandler(RedrawPicture);
		this.comboBrush.SelectedIndexChanged +=new EventHandler(RedrawPicture);
		this.timerCycle.Tick +=new EventHandler(timerCycle_Tick);

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

    // This is used to turn on and off the timer that handles
    //   the cycling of the dots and dashes.

    private void btnCycle_Click(object sender, System.EventArgs e) 
	{
        timerCycle.Interval = 333;

        timerCycle.Enabled = !timerCycle.Enabled;

		if (timerCycle.Enabled) 
		{

			btnCycle.Text = "Stop!";
		}
		else 
		{

			btnCycle.Text = "Animate";

		}

    }

    // This void sets the Color based on the user selection from

    //   a ColorDialog

    private void btnSetColor_Click(object sender, System.EventArgs e) 
	{
        ColorDialog cdlg = new ColorDialog();

        if (cdlg.ShowDialog() == DialogResult.OK) {

            m_penColor = cdlg.Color;

            txtColor.Text = cdlg.Color.ToString();

            txtColor.BackColor = cdlg.Color;

        }

    }

    // When the frmMain is loaded, this void sets up defaults for the page
    //   and builds the necessary combo boxes. Notice that the combo
    //   boxes here hold various objects, instead of standard strings. This
    //   way they can be used directly when assigning their values to 
    //   other objects.

    private void frmMain_Load(object sender, System.EventArgs e) {

        // Set up the ComboBoxes for the form
        // Set up the StartCap combo
        comboStartCap.Items.Add(LineCap.DiamondAnchor);
        comboStartCap.Items.Add(LineCap.ArrowAnchor);
        comboStartCap.Items.Add(LineCap.DiamondAnchor);
        comboStartCap.Items.Add(LineCap.Flat);
        comboStartCap.Items.Add(LineCap.Round);
        comboStartCap.Items.Add(LineCap.RoundAnchor);
        // Set up the EndCap combo
        comboEndCap.Items.Add(LineCap.DiamondAnchor);
        comboEndCap.Items.Add(LineCap.ArrowAnchor);
        comboEndCap.Items.Add(LineCap.DiamondAnchor);
        comboEndCap.Items.Add(LineCap.Flat);
        comboEndCap.Items.Add(LineCap.Round);
        comboEndCap.Items.Add(LineCap.RoundAnchor);
        // Set up Dash Cap
        comboDashCap.Items.Add(DashCap.Flat);
        comboDashCap.Items.Add(DashCap.Round);
        comboDashCap.Items.Add(DashCap.Triangle);
        // Set up Line Join
        comboLineJoin.Items.Add(LineJoin.Bevel);
        comboLineJoin.Items.Add(LineJoin.Miter);
        comboLineJoin.Items.Add(LineJoin.MiterClipped);
        comboLineJoin.Items.Add(LineJoin.Round);
        // Set up Line Join
        comboLineStyle.Items.Add(DashStyle.Solid);
        comboLineStyle.Items.Add(DashStyle.Dash);
        comboLineStyle.Items.Add(DashStyle.DashDot);
        comboLineStyle.Items.Add(DashStyle.DashDotDot);
        comboLineStyle.Items.Add(DashStyle.Dot);
        comboLineStyle.Items.Add(DashStyle.Custom);
        // Set up Alignment
        comboAlignment.Items.Add(PenAlignment.Center);
        comboAlignment.Items.Add(PenAlignment.Inset);
        comboAlignment.Items.Add(PenAlignment.Left);
        comboAlignment.Items.Add(PenAlignment.Outset);
        comboAlignment.Items.Add(PenAlignment.Right);

		suppressEvent = true;
		comboStartCap.SelectedIndex = 0;
		comboEndCap.SelectedIndex = 0;
		comboDashCap.SelectedIndex = 0;
		comboLineJoin.SelectedIndex = 0;
		comboLineStyle.SelectedIndex = 0;
		comboAlignment.SelectedIndex = 0;
		suppressEvent = false;
		

    }

#region "RadioCheckBox code";

    private void radioColor_CheckedChanged(object sender, System.EventArgs e) 
	{
        txtColor.Enabled = radioColor.Checked;
        btnSetColor.Enabled = radioColor.Checked;
        comboBrush.Enabled = radioBrush.Checked;

    }

#endregion

    // RedrawPicture collects all the user defined information, and uses it
    //   to create a Pen object, which is then used to draw one of three different
    //   drawings. Notice that this void handles virtually all of events triggered
    //   by the user interface.

    private void RedrawPicture(object sender, System.EventArgs e)
	{
        // Reset the PictureBox

		if (suppressEvent) 
		{
			return;
		}

        pbLines.CreateGraphics().Clear(pbLines.BackColor);
        pbLines.Refresh();

        // Get rid of any current transform on the Pen

        m_Pen.ResetTransform();

        // Set the DashPattern to use if Custom type of Dashed Line is selected

        m_Pen.DashPattern = new Single[] {0.5F, 0.25F, 0.75F, 1.5F};

        // Since a Pen can have either a Color or a Brush assigned, but not both,
        //   this code determines which should be used. Note that assigning a Color
        //   is identical to assigning the pen a SolidBrush.

			if (radioColor.Checked) 
			{
				m_Pen.Color = m_penColor;
			}
			else 
			{
				switch( comboBrush.Text)
				{
					case "Solid":
					{
						// The same assigning the Pen a Color
						m_penBrush = new SolidBrush(m_penColor);
						break;
					}
					case "Hatch":
					{
						// Defines a HatchBrush to use, in this case a Plaid one.
						m_penBrush = new HatchBrush(HatchStyle.Plaid, m_penColor);
						break;
					}	
					case "Texture":
					{
						// Assigns a bitmap image to be used the Brush.
						m_penBrush = new TextureBrush(
							new Bitmap(@"..\WaterLilies.jpg"), WrapMode.Tile);
						break;
					}
					case "Gradient":
					{
						// Builds a LinearGradientBrush to use the Brush. Other types
						//   of gradient brushes could be used here well.
						m_penBrush = new LinearGradientBrush(
							new Point(0, 0),
							new Point(pbLines.Width, pbLines.Height),
							Color.AliceBlue, Color.DarkBlue);
						break;
					}
				}

				m_Pen.Brush = m_penBrush;

			}

        // Set the user defined values for all the pen objects
        // Width of the Pen is in pixels 

        m_Pen.Width = (float) updownWidth.Value;

        // DashStyle determines the look of the line.
        //   It can be dashes, dots and dashes, or even custom

        m_Pen.DashStyle = (DashStyle) comboLineStyle.SelectedItem;

        // MiterLimit is a float that determines when the Miter edge of
        //   two adjacent lines should be clipped. The default is 10.0

        m_Pen.MiterLimit = (float) updownMiterLimit.Value;

        // StartCap determines the cap that should be put on
        //   the start of a line drawn by the pen

        m_Pen.StartCap = (LineCap) comboStartCap.SelectedItem;

        // EndCap determines the cap that should be put on
        //   the end of a line drawn by the pen

        m_Pen.EndCap = (LineCap) comboEndCap.SelectedItem;

        // DashCap determines the cap that should be put on
        //   both ends of any dashes in a line drawn by the pen

        m_Pen.DashCap = (DashCap) comboDashCap.SelectedItem;

        // LineJoin determines how two adjacent lines should be joined.
        //   For instance, they can have a rounded join, or a mitered join.

        m_Pen.LineJoin = (LineJoin) comboLineJoin.SelectedItem;

        // Alignment determines which 'side' of the designated line, that
        //   the pen should draw on. For instance, Inset will cause the
        //   pen to draw on the inside of a circle.

        m_Pen.Alignment = (PenAlignment) comboAlignment.SelectedItem;

        // Transforms are used for some advanced features of pens. You can,
        //   for instance, create a caligraphic style pen.

        switch( comboTransform.Text)
		{
			case "None":
			{
				// ResetTransform resets the pen to having no transform

				m_Pen.ResetTransform();
				break;
			}
			case "Scale":
			{
				// ScaleTransform  changes the appearance of the pen, by
				//   by changing the width and height of the pen. For instance,
				//   the transform below makes the width half thin the
				//   normal, and doubles the height.

				m_Pen.ScaleTransform(0.5F, 2);
				break;
			}
			case "Rotate":
			{
				// RotateTransform only is used if the underlying 
				//   Brush supports it. It rotates the brush by a number of 
				//   degrees.

				m_Pen.RotateTransform(45);
				break;
			}
			case "Translate":
			{
				// TranslateTransform only is used if the underlying 
				//   Brush supports it. It translates the underlying brush.

				m_Pen.TranslateTransform(2, 4);
				break;
			}
        }

        // Now that the Pen has been defined create a graphics object, and
        //   redraw the image on the PictureBox. Also draw a thin black line
        //   using the same command. This will allow the user to see where
        //   the line was intended to go, and aids in illuminating what
        //   various properties do.

        graphic = pbLines.CreateGraphics();

        if (this.comboShape.Text == "Lines") {

            // Draw 3 simple lines. 
            // Draw using the user defined pen

            graphic.DrawLine(m_Pen, 35, 35, pbLines.Width - 35, 35);
            graphic.DrawLine(m_Pen, 35, 80, 35, pbLines.Height - 35);
            graphic.DrawLine(m_Pen, 90, 90, pbLines.Width - 35,
                pbLines.Height - 35);

            // Draw using the thin black pen, to see effects

            graphic.DrawLine(m_BlackThinPen, 35, 35, pbLines.Width - 35, 35);
            graphic.DrawLine(m_BlackThinPen, 35, 80, 35, pbLines.Height - 35);
            graphic.DrawLine(m_BlackThinPen, 90, 90, pbLines.Width - 35, 
                    pbLines.Height - 35);

        } else if ( this.comboShape.Text == "Intersecting Lines") {
            // Draw a compound line
            // Create a more complex shape using an array of Points
            //   To define a multisegment line. if several independent
            //   lines are used instead, even if they connect, then the 
            //   end and start caps would be placed on each independent line.
            //   Here they are only placed on the beginning and end of the 
            //   compound line.

				PointF[] ptArray = new PointF[6];
				ptArray[0] = new PointF(35, 35);
				ptArray[1] = new PointF(70, pbLines.Height - 75);
				ptArray[2] = new PointF(100, 35);
				ptArray[3] = new PointF(pbLines.Width - 40, pbLines.Height / 2);
				ptArray[4] = new PointF(pbLines.Width / 2, pbLines.Height / 2);
				ptArray[5] = new PointF(pbLines.Width - 25, 25);

				// Draw the lines using the user defined Pen

				graphic.DrawLines(m_Pen, ptArray);

				// Draw the lines using the thin, black Pen

				graphic.DrawLines(m_BlackThinPen, ptArray);

        } else if ( this.comboShape.Text == "Circles and Curves") {

            // Draw a circle and a curve
            // Draw the curves using the user defined Pen

            graphic.DrawEllipse(m_Pen, 25, 25, 200, 200);
            graphic.DrawArc(m_Pen, 55, 55, pbLines.Height - 55, 
                pbLines.Height - 55, 110, 150);

            // Draw the curves using the thin, black Pen
            graphic.DrawEllipse(m_BlackThinPen, 25, 25, 200, 200);
            graphic.DrawArc(m_BlackThinPen, 55, 55, pbLines.Height - 55, 
                pbLines.Height - 55, 110, 150);

        }

    }

    // When the timer fires, the DashOffset property is incremented and the dots
    //   and dashes in a line apprear to animate.

    private void timerCycle_Tick(object sender, System.EventArgs e) 
	{
        m_Pen.DashOffset = (m_Pen.DashOffset + 0.5F) % 30;
        RedrawPicture(this, new System.EventArgs());

    }

}

