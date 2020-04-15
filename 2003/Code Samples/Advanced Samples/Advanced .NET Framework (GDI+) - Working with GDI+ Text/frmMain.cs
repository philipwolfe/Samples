//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class frmMain : System.Windows.Forms.Form 
{
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

    private System.Windows.Forms.Label Label12;

    private System.Windows.Forms.NumericUpDown nudShadowDepth;

    private System.Windows.Forms.Button btnShadowText;

    private System.Windows.Forms.Button btnBrushText;

    private System.Windows.Forms.Label Label11;

    private System.Windows.Forms.TextBox txtShortText;

    private System.Windows.Forms.Button btnSimpleText;

    private System.Windows.Forms.TextBox txtLongText;

    private System.Windows.Forms.RadioButton optGradient;

    private System.Windows.Forms.RadioButton optHatch;

    private System.Windows.Forms.PictureBox picDemoArea;

    private System.Windows.Forms.NumericUpDown nudFontSize;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Button btnEmboss;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.NumericUpDown nudEmbossDepth;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.NumericUpDown nudBlockDepth;

    private System.Windows.Forms.Button btnBlockText;

    private System.Windows.Forms.Button btnReflectedText;

    private System.Windows.Forms.Button btnShearText;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.NumericUpDown nudSkew;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.Label12 = new System.Windows.Forms.Label();

        this.nudShadowDepth = new System.Windows.Forms.NumericUpDown();

        this.btnShadowText = new System.Windows.Forms.Button();

        this.btnBrushText = new System.Windows.Forms.Button();

        this.Label11 = new System.Windows.Forms.Label();

        this.txtShortText = new System.Windows.Forms.TextBox();

        this.btnSimpleText = new System.Windows.Forms.Button();

        this.txtLongText = new System.Windows.Forms.TextBox();

        this.optGradient = new System.Windows.Forms.RadioButton();

        this.optHatch = new System.Windows.Forms.RadioButton();

        this.picDemoArea = new System.Windows.Forms.PictureBox();

        this.nudFontSize = new System.Windows.Forms.NumericUpDown();

        this.Label1 = new System.Windows.Forms.Label();

        this.btnEmboss = new System.Windows.Forms.Button();

        this.Label2 = new System.Windows.Forms.Label();

        this.nudEmbossDepth = new System.Windows.Forms.NumericUpDown();

        this.Label3 = new System.Windows.Forms.Label();

        this.nudBlockDepth = new System.Windows.Forms.NumericUpDown();

        this.btnBlockText = new System.Windows.Forms.Button();

        this.btnReflectedText = new System.Windows.Forms.Button();

        this.btnShearText = new System.Windows.Forms.Button();

        this.Label4 = new System.Windows.Forms.Label();

        this.nudSkew = new System.Windows.Forms.NumericUpDown();

        ((System.ComponentModel.ISupportInitialize) this.nudShadowDepth).BeginInit();

        ((System.ComponentModel.ISupportInitialize) this.nudFontSize).BeginInit();

        ((System.ComponentModel.ISupportInitialize) this.nudEmbossDepth).BeginInit();

        ((System.ComponentModel.ISupportInitialize) this.nudBlockDepth).BeginInit();

        ((System.ComponentModel.ISupportInitialize) this.nudSkew).BeginInit();

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

        //nudShadowDepth

        //

        this.nudShadowDepth.AccessibleDescription = resources.GetString("nudShadowDepth.AccessibleDescription");

        this.nudShadowDepth.AccessibleName = resources.GetString("nudShadowDepth.AccessibleName");

        this.nudShadowDepth.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("nudShadowDepth.Anchor");

        this.nudShadowDepth.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("nudShadowDepth.Dock");

        this.nudShadowDepth.Enabled = (bool) resources.GetObject("nudShadowDepth.Enabled");

        this.nudShadowDepth.Font = (System.Drawing.Font) resources.GetObject("nudShadowDepth.Font");

        this.nudShadowDepth.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("nudShadowDepth.ImeMode");

        this.nudShadowDepth.Location = (System.Drawing.Point) resources.GetObject("nudShadowDepth.Location");

        this.nudShadowDepth.Maximum = new Decimal(new int[] {40, 0, 0, 0});

        this.nudShadowDepth.Name = "nudShadowDepth";

        this.nudShadowDepth.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("nudShadowDepth.RightToLeft");

        this.nudShadowDepth.Size = (System.Drawing.Size) resources.GetObject("nudShadowDepth.Size");

        this.nudShadowDepth.TabIndex = (int) resources.GetObject("nudShadowDepth.TabIndex");

        this.nudShadowDepth.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("nudShadowDepth.TextAlign");

        this.nudShadowDepth.ThousandsSeparator = (bool) resources.GetObject("nudShadowDepth.ThousandsSeparator");

        this.nudShadowDepth.UpDownAlign = (System.Windows.Forms.LeftRightAlignment) resources.GetObject("nudShadowDepth.UpDownAlign");

        this.nudShadowDepth.Value = new Decimal(new int[] {10, 0, 0, 0});

        this.nudShadowDepth.Visible = (bool) resources.GetObject("nudShadowDepth.Visible");

        //

        //btnShadowText

        //

        this.btnShadowText.AccessibleDescription = resources.GetString("btnShadowText.AccessibleDescription");

        this.btnShadowText.AccessibleName = resources.GetString("btnShadowText.AccessibleName");

        this.btnShadowText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnShadowText.Anchor");

        this.btnShadowText.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnShadowText.BackgroundImage");

        this.btnShadowText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnShadowText.Dock");

        this.btnShadowText.Enabled = (bool) resources.GetObject("btnShadowText.Enabled");

        this.btnShadowText.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnShadowText.FlatStyle");

        this.btnShadowText.Font = (System.Drawing.Font) resources.GetObject("btnShadowText.Font");

        this.btnShadowText.Image = (System.Drawing.Image) resources.GetObject("btnShadowText.Image");

        this.btnShadowText.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShadowText.ImageAlign");

        this.btnShadowText.ImageIndex = (int) resources.GetObject("btnShadowText.ImageIndex");

        this.btnShadowText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnShadowText.ImeMode");

        this.btnShadowText.Location = (System.Drawing.Point) resources.GetObject("btnShadowText.Location");

        this.btnShadowText.Name = "btnShadowText";

        this.btnShadowText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnShadowText.RightToLeft");

        this.btnShadowText.Size = (System.Drawing.Size) resources.GetObject("btnShadowText.Size");

        this.btnShadowText.TabIndex = (int) resources.GetObject("btnShadowText.TabIndex");

        this.btnShadowText.Text = resources.GetString("btnShadowText.Text");

        this.btnShadowText.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShadowText.TextAlign");

        this.btnShadowText.Visible = (bool) resources.GetObject("btnShadowText.Visible");

		this.btnShadowText.Click += new EventHandler(btnShadowText_Click);

        //

        //btnBrushText

        //

        this.btnBrushText.AccessibleDescription = resources.GetString("btnBrushText.AccessibleDescription");

        this.btnBrushText.AccessibleName = resources.GetString("btnBrushText.AccessibleName");

        this.btnBrushText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnBrushText.Anchor");

        this.btnBrushText.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnBrushText.BackgroundImage");

        this.btnBrushText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnBrushText.Dock");

        this.btnBrushText.Enabled = (bool) resources.GetObject("btnBrushText.Enabled");

        this.btnBrushText.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnBrushText.FlatStyle");

        this.btnBrushText.Font = (System.Drawing.Font) resources.GetObject("btnBrushText.Font");

        this.btnBrushText.Image = (System.Drawing.Image) resources.GetObject("btnBrushText.Image");

        this.btnBrushText.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBrushText.ImageAlign");

        this.btnBrushText.ImageIndex = (int) resources.GetObject("btnBrushText.ImageIndex");

        this.btnBrushText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnBrushText.ImeMode");

        this.btnBrushText.Location = (System.Drawing.Point) resources.GetObject("btnBrushText.Location");

        this.btnBrushText.Name = "btnBrushText";

        this.btnBrushText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnBrushText.RightToLeft");

        this.btnBrushText.Size = (System.Drawing.Size) resources.GetObject("btnBrushText.Size");

        this.btnBrushText.TabIndex = (int) resources.GetObject("btnBrushText.TabIndex");

        this.btnBrushText.Text = resources.GetString("btnBrushText.Text");

        this.btnBrushText.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBrushText.TextAlign");

        this.btnBrushText.Visible = (bool) resources.GetObject("btnBrushText.Visible");

		this.btnBrushText.Click += new EventHandler(btnBrushText_Click);

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

        //txtShortText

        //

        this.txtShortText.AccessibleDescription = resources.GetString("txtShortText.AccessibleDescription");

        this.txtShortText.AccessibleName = resources.GetString("txtShortText.AccessibleName");

        this.txtShortText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtShortText.Anchor");

        this.txtShortText.AutoSize = (bool) resources.GetObject("txtShortText.AutoSize");

        this.txtShortText.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtShortText.BackgroundImage");

        this.txtShortText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtShortText.Dock");

        this.txtShortText.Enabled = (bool) resources.GetObject("txtShortText.Enabled");

        this.txtShortText.Font = (System.Drawing.Font) resources.GetObject("txtShortText.Font");

        this.txtShortText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtShortText.ImeMode");

        this.txtShortText.Location = (System.Drawing.Point) resources.GetObject("txtShortText.Location");

        this.txtShortText.MaxLength = (int) resources.GetObject("txtShortText.MaxLength");

        this.txtShortText.Multiline = (bool) resources.GetObject("txtShortText.Multiline");

        this.txtShortText.Name = "txtShortText";

        this.txtShortText.PasswordChar = (char) resources.GetObject("txtShortText.PasswordChar");

        this.txtShortText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtShortText.RightToLeft");

        this.txtShortText.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtShortText.ScrollBars");

        this.txtShortText.Size = (System.Drawing.Size) resources.GetObject("txtShortText.Size");

        this.txtShortText.TabIndex = (int) resources.GetObject("txtShortText.TabIndex");

        this.txtShortText.Text = resources.GetString("txtShortText.Text");

        this.txtShortText.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtShortText.TextAlign");

        this.txtShortText.Visible = (bool) resources.GetObject("txtShortText.Visible");

        this.txtShortText.WordWrap = (bool) resources.GetObject("txtShortText.WordWrap");

        //

        //btnSimpleText

        //

        this.btnSimpleText.AccessibleDescription = resources.GetString("btnSimpleText.AccessibleDescription");

        this.btnSimpleText.AccessibleName = resources.GetString("btnSimpleText.AccessibleName");

        this.btnSimpleText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSimpleText.Anchor");

        this.btnSimpleText.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSimpleText.BackgroundImage");

        this.btnSimpleText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSimpleText.Dock");

        this.btnSimpleText.Enabled = (bool) resources.GetObject("btnSimpleText.Enabled");

        this.btnSimpleText.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSimpleText.FlatStyle");

        this.btnSimpleText.Font = (System.Drawing.Font) resources.GetObject("btnSimpleText.Font");

        this.btnSimpleText.Image = (System.Drawing.Image) resources.GetObject("btnSimpleText.Image");

        this.btnSimpleText.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSimpleText.ImageAlign");

        this.btnSimpleText.ImageIndex = (int) resources.GetObject("btnSimpleText.ImageIndex");

        this.btnSimpleText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSimpleText.ImeMode");

        this.btnSimpleText.Location = (System.Drawing.Point) resources.GetObject("btnSimpleText.Location");

        this.btnSimpleText.Name = "btnSimpleText";

        this.btnSimpleText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSimpleText.RightToLeft");

        this.btnSimpleText.Size = (System.Drawing.Size) resources.GetObject("btnSimpleText.Size");

        this.btnSimpleText.TabIndex = (int) resources.GetObject("btnSimpleText.TabIndex");

        this.btnSimpleText.Text = resources.GetString("btnSimpleText.Text");

        this.btnSimpleText.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSimpleText.TextAlign");

        this.btnSimpleText.Visible = (bool) resources.GetObject("btnSimpleText.Visible");

		this.btnSimpleText.Click += new EventHandler(btnSimpleText_Click);

        //

        //txtLongText

        //

        this.txtLongText.AccessibleDescription = resources.GetString("txtLongText.AccessibleDescription");

        this.txtLongText.AccessibleName = resources.GetString("txtLongText.AccessibleName");

        this.txtLongText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtLongText.Anchor");

        this.txtLongText.AutoSize = (bool) resources.GetObject("txtLongText.AutoSize");

        this.txtLongText.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtLongText.BackgroundImage");

        this.txtLongText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtLongText.Dock");

        this.txtLongText.Enabled = (bool) resources.GetObject("txtLongText.Enabled");

        this.txtLongText.Font = (System.Drawing.Font) resources.GetObject("txtLongText.Font");

        this.txtLongText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtLongText.ImeMode");

        this.txtLongText.Location = (System.Drawing.Point) resources.GetObject("txtLongText.Location");

        this.txtLongText.MaxLength = (int) resources.GetObject("txtLongText.MaxLength");

        this.txtLongText.Multiline = (bool) resources.GetObject("txtLongText.Multiline");

        this.txtLongText.Name = "txtLongText";

        this.txtLongText.PasswordChar = (char) resources.GetObject("txtLongText.PasswordChar");

        this.txtLongText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtLongText.RightToLeft");

        this.txtLongText.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtLongText.ScrollBars");

        this.txtLongText.Size = (System.Drawing.Size) resources.GetObject("txtLongText.Size");

        this.txtLongText.TabIndex = (int) resources.GetObject("txtLongText.TabIndex");

        this.txtLongText.Text = resources.GetString("txtLongText.Text");

        this.txtLongText.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtLongText.TextAlign");

        this.txtLongText.Visible = (bool) resources.GetObject("txtLongText.Visible");

        this.txtLongText.WordWrap = (bool) resources.GetObject("txtLongText.WordWrap");

        //

        //optGradient

        //

        this.optGradient.AccessibleDescription = resources.GetString("optGradient.AccessibleDescription");

        this.optGradient.AccessibleName = resources.GetString("optGradient.AccessibleName");

        this.optGradient.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optGradient.Anchor");

        this.optGradient.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optGradient.Appearance");

        this.optGradient.BackgroundImage = (System.Drawing.Image) resources.GetObject("optGradient.BackgroundImage");

        this.optGradient.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optGradient.CheckAlign");

        this.optGradient.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optGradient.Dock");

        this.optGradient.Enabled = (bool) resources.GetObject("optGradient.Enabled");

        this.optGradient.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optGradient.FlatStyle");

        this.optGradient.Font = (System.Drawing.Font) resources.GetObject("optGradient.Font");

        this.optGradient.Image = (System.Drawing.Image) resources.GetObject("optGradient.Image");

        this.optGradient.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optGradient.ImageAlign");

        this.optGradient.ImageIndex = (int) resources.GetObject("optGradient.ImageIndex");

        this.optGradient.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optGradient.ImeMode");

        this.optGradient.Location = (System.Drawing.Point) resources.GetObject("optGradient.Location");

        this.optGradient.Name = "optGradient";

        this.optGradient.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optGradient.RightToLeft");

        this.optGradient.Size = (System.Drawing.Size) resources.GetObject("optGradient.Size");

        this.optGradient.TabIndex = (int) resources.GetObject("optGradient.TabIndex");

        this.optGradient.TabStop = true;

        this.optGradient.Text = resources.GetString("optGradient.Text");

        this.optGradient.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optGradient.TextAlign");

        this.optGradient.Visible = (bool) resources.GetObject("optGradient.Visible");

        //

        //optHatch

        //

        this.optHatch.AccessibleDescription = resources.GetString("optHatch.AccessibleDescription");

        this.optHatch.AccessibleName = resources.GetString("optHatch.AccessibleName");

        this.optHatch.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optHatch.Anchor");

        this.optHatch.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optHatch.Appearance");

        this.optHatch.BackgroundImage = (System.Drawing.Image) resources.GetObject("optHatch.BackgroundImage");

        this.optHatch.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optHatch.CheckAlign");

        this.optHatch.Checked = true;

        this.optHatch.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optHatch.Dock");

        this.optHatch.Enabled = (bool) resources.GetObject("optHatch.Enabled");

        this.optHatch.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optHatch.FlatStyle");

        this.optHatch.Font = (System.Drawing.Font) resources.GetObject("optHatch.Font");

        this.optHatch.Image = (System.Drawing.Image) resources.GetObject("optHatch.Image");

        this.optHatch.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optHatch.ImageAlign");

        this.optHatch.ImageIndex = (int) resources.GetObject("optHatch.ImageIndex");

        this.optHatch.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optHatch.ImeMode");

        this.optHatch.Location = (System.Drawing.Point) resources.GetObject("optHatch.Location");

        this.optHatch.Name = "optHatch";

        this.optHatch.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optHatch.RightToLeft");

        this.optHatch.Size = (System.Drawing.Size) resources.GetObject("optHatch.Size");

        this.optHatch.TabIndex = (int) resources.GetObject("optHatch.TabIndex");

        this.optHatch.TabStop = true;

        this.optHatch.Text = resources.GetString("optHatch.Text");

        this.optHatch.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optHatch.TextAlign");

        this.optHatch.Visible = (bool) resources.GetObject("optHatch.Visible");

        //

        //picDemoArea

        //

        this.picDemoArea.AccessibleDescription = resources.GetString("picDemoArea.AccessibleDescription");

        this.picDemoArea.AccessibleName = resources.GetString("picDemoArea.AccessibleName");

        this.picDemoArea.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("picDemoArea.Anchor");

        this.picDemoArea.BackgroundImage = (System.Drawing.Image) resources.GetObject("picDemoArea.BackgroundImage");

        this.picDemoArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.picDemoArea.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("picDemoArea.Dock");

        this.picDemoArea.Enabled = (bool) resources.GetObject("picDemoArea.Enabled");

        this.picDemoArea.Font = (System.Drawing.Font) resources.GetObject("picDemoArea.Font");

        this.picDemoArea.Image = (System.Drawing.Image) resources.GetObject("picDemoArea.Image");

        this.picDemoArea.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("picDemoArea.ImeMode");

        this.picDemoArea.Location = (System.Drawing.Point) resources.GetObject("picDemoArea.Location");

        this.picDemoArea.Name = "picDemoArea";

        this.picDemoArea.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("picDemoArea.RightToLeft");

        this.picDemoArea.Size = (System.Drawing.Size) resources.GetObject("picDemoArea.Size");

        this.picDemoArea.SizeMode = (System.Windows.Forms.PictureBoxSizeMode) resources.GetObject("picDemoArea.SizeMode");

        this.picDemoArea.TabIndex = (int) resources.GetObject("picDemoArea.TabIndex");

        this.picDemoArea.TabStop = false;

        this.picDemoArea.Text = resources.GetString("picDemoArea.Text");

        this.picDemoArea.Visible = (bool) resources.GetObject("picDemoArea.Visible");

        //

        //nudFontSize

        //

        this.nudFontSize.AccessibleDescription = resources.GetString("nudFontSize.AccessibleDescription");

        this.nudFontSize.AccessibleName = resources.GetString("nudFontSize.AccessibleName");

        this.nudFontSize.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("nudFontSize.Anchor");

        this.nudFontSize.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("nudFontSize.Dock");

        this.nudFontSize.Enabled = (bool) resources.GetObject("nudFontSize.Enabled");

        this.nudFontSize.Font = (System.Drawing.Font) resources.GetObject("nudFontSize.Font");

        this.nudFontSize.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("nudFontSize.ImeMode");

        this.nudFontSize.Increment = new Decimal(new int[] {5, 0, 0, 0});

        this.nudFontSize.Location = (System.Drawing.Point) resources.GetObject("nudFontSize.Location");

        this.nudFontSize.Maximum = new Decimal(new int[] {150, 0, 0, 0});

        this.nudFontSize.Name = "nudFontSize";

        this.nudFontSize.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("nudFontSize.RightToLeft");

        this.nudFontSize.Size = (System.Drawing.Size) resources.GetObject("nudFontSize.Size");

        this.nudFontSize.TabIndex = (int) resources.GetObject("nudFontSize.TabIndex");

        this.nudFontSize.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("nudFontSize.TextAlign");

        this.nudFontSize.ThousandsSeparator = (bool) resources.GetObject("nudFontSize.ThousandsSeparator");

        this.nudFontSize.UpDownAlign = (System.Windows.Forms.LeftRightAlignment) resources.GetObject("nudFontSize.UpDownAlign");

        this.nudFontSize.Value = new Decimal(new int[] {50, 0, 0, 0});

        this.nudFontSize.Visible = (bool) resources.GetObject("nudFontSize.Visible");

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

        //btnEmboss

        //

        this.btnEmboss.AccessibleDescription = resources.GetString("btnEmboss.AccessibleDescription");

        this.btnEmboss.AccessibleName = resources.GetString("btnEmboss.AccessibleName");

        this.btnEmboss.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnEmboss.Anchor");

        this.btnEmboss.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnEmboss.BackgroundImage");

        this.btnEmboss.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnEmboss.Dock");

        this.btnEmboss.Enabled = (bool) resources.GetObject("btnEmboss.Enabled");

        this.btnEmboss.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnEmboss.FlatStyle");

        this.btnEmboss.Font = (System.Drawing.Font) resources.GetObject("btnEmboss.Font");

        this.btnEmboss.Image = (System.Drawing.Image) resources.GetObject("btnEmboss.Image");

        this.btnEmboss.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnEmboss.ImageAlign");

        this.btnEmboss.ImageIndex = (int) resources.GetObject("btnEmboss.ImageIndex");

        this.btnEmboss.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnEmboss.ImeMode");

        this.btnEmboss.Location = (System.Drawing.Point) resources.GetObject("btnEmboss.Location");

        this.btnEmboss.Name = "btnEmboss";

        this.btnEmboss.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnEmboss.RightToLeft");

        this.btnEmboss.Size = (System.Drawing.Size) resources.GetObject("btnEmboss.Size");

        this.btnEmboss.TabIndex = (int) resources.GetObject("btnEmboss.TabIndex");

        this.btnEmboss.Text = resources.GetString("btnEmboss.Text");

        this.btnEmboss.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnEmboss.TextAlign");

        this.btnEmboss.Visible = (bool) resources.GetObject("btnEmboss.Visible");

		this.btnEmboss.Click += new EventHandler(btnEmboss_Click);

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

        //nudEmbossDepth

        //

        this.nudEmbossDepth.AccessibleDescription = resources.GetString("nudEmbossDepth.AccessibleDescription");

        this.nudEmbossDepth.AccessibleName = resources.GetString("nudEmbossDepth.AccessibleName");

        this.nudEmbossDepth.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("nudEmbossDepth.Anchor");

        this.nudEmbossDepth.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("nudEmbossDepth.Dock");

        this.nudEmbossDepth.Enabled = (bool) resources.GetObject("nudEmbossDepth.Enabled");

        this.nudEmbossDepth.Font = (System.Drawing.Font) resources.GetObject("nudEmbossDepth.Font");

        this.nudEmbossDepth.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("nudEmbossDepth.ImeMode");

        this.nudEmbossDepth.Location = (System.Drawing.Point) resources.GetObject("nudEmbossDepth.Location");

        this.nudEmbossDepth.Maximum = new Decimal(new int[] {10, 0, 0, 0});

        this.nudEmbossDepth.Name = "nudEmbossDepth";

        this.nudEmbossDepth.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("nudEmbossDepth.RightToLeft");

        this.nudEmbossDepth.Size = (System.Drawing.Size) resources.GetObject("nudEmbossDepth.Size");

        this.nudEmbossDepth.TabIndex = (int) resources.GetObject("nudEmbossDepth.TabIndex");

        this.nudEmbossDepth.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("nudEmbossDepth.TextAlign");

        this.nudEmbossDepth.ThousandsSeparator = (bool) resources.GetObject("nudEmbossDepth.ThousandsSeparator");

        this.nudEmbossDepth.UpDownAlign = (System.Windows.Forms.LeftRightAlignment) resources.GetObject("nudEmbossDepth.UpDownAlign");

        this.nudEmbossDepth.Value = new Decimal(new int[] {1, 0, 0, 0});

        this.nudEmbossDepth.Visible = (bool) resources.GetObject("nudEmbossDepth.Visible");

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

        //nudBlockDepth

        //

        this.nudBlockDepth.AccessibleDescription = resources.GetString("nudBlockDepth.AccessibleDescription");

        this.nudBlockDepth.AccessibleName = resources.GetString("nudBlockDepth.AccessibleName");

        this.nudBlockDepth.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("nudBlockDepth.Anchor");

        this.nudBlockDepth.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("nudBlockDepth.Dock");

        this.nudBlockDepth.Enabled = (bool) resources.GetObject("nudBlockDepth.Enabled");

        this.nudBlockDepth.Font = (System.Drawing.Font) resources.GetObject("nudBlockDepth.Font");

        this.nudBlockDepth.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("nudBlockDepth.ImeMode");

        this.nudBlockDepth.Location = (System.Drawing.Point) resources.GetObject("nudBlockDepth.Location");

        this.nudBlockDepth.Maximum = new Decimal(new int[] {40, 0, 0, 0});

        this.nudBlockDepth.Name = "nudBlockDepth";

        this.nudBlockDepth.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("nudBlockDepth.RightToLeft");

        this.nudBlockDepth.Size = (System.Drawing.Size) resources.GetObject("nudBlockDepth.Size");

        this.nudBlockDepth.TabIndex = (int) resources.GetObject("nudBlockDepth.TabIndex");

        this.nudBlockDepth.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("nudBlockDepth.TextAlign");

        this.nudBlockDepth.ThousandsSeparator = (bool) resources.GetObject("nudBlockDepth.ThousandsSeparator");

        this.nudBlockDepth.UpDownAlign = (System.Windows.Forms.LeftRightAlignment) resources.GetObject("nudBlockDepth.UpDownAlign");

        this.nudBlockDepth.Value = new Decimal(new int[] {10, 0, 0, 0});

        this.nudBlockDepth.Visible = (bool) resources.GetObject("nudBlockDepth.Visible");

        //

        //btnBlockText

        //

        this.btnBlockText.AccessibleDescription = resources.GetString("btnBlockText.AccessibleDescription");

        this.btnBlockText.AccessibleName = resources.GetString("btnBlockText.AccessibleName");

        this.btnBlockText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnBlockText.Anchor");

        this.btnBlockText.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnBlockText.BackgroundImage");

        this.btnBlockText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnBlockText.Dock");

        this.btnBlockText.Enabled = (bool) resources.GetObject("btnBlockText.Enabled");

        this.btnBlockText.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnBlockText.FlatStyle");

        this.btnBlockText.Font = (System.Drawing.Font) resources.GetObject("btnBlockText.Font");

        this.btnBlockText.Image = (System.Drawing.Image) resources.GetObject("btnBlockText.Image");

        this.btnBlockText.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBlockText.ImageAlign");

        this.btnBlockText.ImageIndex = (int) resources.GetObject("btnBlockText.ImageIndex");

        this.btnBlockText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnBlockText.ImeMode");

        this.btnBlockText.Location = (System.Drawing.Point) resources.GetObject("btnBlockText.Location");

        this.btnBlockText.Name = "btnBlockText";

        this.btnBlockText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnBlockText.RightToLeft");

        this.btnBlockText.Size = (System.Drawing.Size) resources.GetObject("btnBlockText.Size");

        this.btnBlockText.TabIndex = (int) resources.GetObject("btnBlockText.TabIndex");

        this.btnBlockText.Text = resources.GetString("btnBlockText.Text");

        this.btnBlockText.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBlockText.TextAlign");

        this.btnBlockText.Visible = (bool) resources.GetObject("btnBlockText.Visible");

		this.btnBlockText.Click += new EventHandler(btnBlockText_Click);

        //

        //btnReflectedText

        //

        this.btnReflectedText.AccessibleDescription = resources.GetString("btnReflectedText.AccessibleDescription");

        this.btnReflectedText.AccessibleName = resources.GetString("btnReflectedText.AccessibleName");

        this.btnReflectedText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnReflectedText.Anchor");

        this.btnReflectedText.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnReflectedText.BackgroundImage");

        this.btnReflectedText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnReflectedText.Dock");

        this.btnReflectedText.Enabled = (bool) resources.GetObject("btnReflectedText.Enabled");

        this.btnReflectedText.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnReflectedText.FlatStyle");

        this.btnReflectedText.Font = (System.Drawing.Font) resources.GetObject("btnReflectedText.Font");

        this.btnReflectedText.Image = (System.Drawing.Image) resources.GetObject("btnReflectedText.Image");

        this.btnReflectedText.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnReflectedText.ImageAlign");

        this.btnReflectedText.ImageIndex = (int) resources.GetObject("btnReflectedText.ImageIndex");

        this.btnReflectedText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnReflectedText.ImeMode");

        this.btnReflectedText.Location = (System.Drawing.Point) resources.GetObject("btnReflectedText.Location");

        this.btnReflectedText.Name = "btnReflectedText";

        this.btnReflectedText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnReflectedText.RightToLeft");

        this.btnReflectedText.Size = (System.Drawing.Size) resources.GetObject("btnReflectedText.Size");

        this.btnReflectedText.TabIndex = (int) resources.GetObject("btnReflectedText.TabIndex");

        this.btnReflectedText.Text = resources.GetString("btnReflectedText.Text");

        this.btnReflectedText.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnReflectedText.TextAlign");

        this.btnReflectedText.Visible = (bool) resources.GetObject("btnReflectedText.Visible");

		this.btnReflectedText.Click += new EventHandler(btnReflectedText_Click);

        //

        //btnShearText

        //

        this.btnShearText.AccessibleDescription = resources.GetString("btnShearText.AccessibleDescription");

        this.btnShearText.AccessibleName = resources.GetString("btnShearText.AccessibleName");

        this.btnShearText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnShearText.Anchor");

        this.btnShearText.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnShearText.BackgroundImage");

        this.btnShearText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnShearText.Dock");

        this.btnShearText.Enabled = (bool) resources.GetObject("btnShearText.Enabled");

        this.btnShearText.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnShearText.FlatStyle");

        this.btnShearText.Font = (System.Drawing.Font) resources.GetObject("btnShearText.Font");

        this.btnShearText.Image = (System.Drawing.Image) resources.GetObject("btnShearText.Image");

        this.btnShearText.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShearText.ImageAlign");

        this.btnShearText.ImageIndex = (int) resources.GetObject("btnShearText.ImageIndex");

        this.btnShearText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnShearText.ImeMode");

        this.btnShearText.Location = (System.Drawing.Point) resources.GetObject("btnShearText.Location");

        this.btnShearText.Name = "btnShearText";

        this.btnShearText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnShearText.RightToLeft");

        this.btnShearText.Size = (System.Drawing.Size) resources.GetObject("btnShearText.Size");

        this.btnShearText.TabIndex = (int) resources.GetObject("btnShearText.TabIndex");

        this.btnShearText.Text = resources.GetString("btnShearText.Text");

        this.btnShearText.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShearText.TextAlign");

        this.btnShearText.Visible = (bool) resources.GetObject("btnShearText.Visible");

		this.btnShearText.Click += new EventHandler(btnShearText_Click);

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

        //nudSkew

        //

        this.nudSkew.AccessibleDescription = resources.GetString("nudSkew.AccessibleDescription");

        this.nudSkew.AccessibleName = resources.GetString("nudSkew.AccessibleName");

        this.nudSkew.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("nudSkew.Anchor");

        this.nudSkew.DecimalPlaces = 1;

        this.nudSkew.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("nudSkew.Dock");

        this.nudSkew.Enabled = (bool) resources.GetObject("nudSkew.Enabled");

        this.nudSkew.Font = (System.Drawing.Font) resources.GetObject("nudSkew.Font");

        this.nudSkew.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("nudSkew.ImeMode");

        this.nudSkew.Increment = new Decimal(new int[] {1, 0, 0, 65536});

        this.nudSkew.Location = (System.Drawing.Point) resources.GetObject("nudSkew.Location");

        this.nudSkew.Maximum = new Decimal(new int[] {2, 0, 0, 0});

        this.nudSkew.Minimum = new Decimal(new int[] {2, 0, 0, -2147483648});

        this.nudSkew.Name = "nudSkew";

        this.nudSkew.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("nudSkew.RightToLeft");

        this.nudSkew.Size = (System.Drawing.Size) resources.GetObject("nudSkew.Size");

        this.nudSkew.TabIndex = (int) resources.GetObject("nudSkew.TabIndex");

        this.nudSkew.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("nudSkew.TextAlign");

        this.nudSkew.ThousandsSeparator = (bool) resources.GetObject("nudSkew.ThousandsSeparator");

        this.nudSkew.UpDownAlign = (System.Windows.Forms.LeftRightAlignment) resources.GetObject("nudSkew.UpDownAlign");

        this.nudSkew.Value = new Decimal(new int[] {1, 0, 0, 0});

        this.nudSkew.Visible = (bool) resources.GetObject("nudSkew.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label4, this.nudSkew, this.btnShearText, this.btnReflectedText, this.Label3, this.nudBlockDepth, this.btnBlockText, this.Label2, this.nudEmbossDepth, this.btnEmboss, this.Label1, this.nudFontSize, this.picDemoArea, this.Label12, this.nudShadowDepth, this.btnShadowText, this.btnBrushText, this.Label11, this.txtShortText, this.btnSimpleText, this.txtLongText, this.optGradient, this.optHatch});

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

        ((System.ComponentModel.ISupportInitialize) this.nudShadowDepth).EndInit();

        ((System.ComponentModel.ISupportInitialize) this.nudFontSize).EndInit();

        ((System.ComponentModel.ISupportInitialize) this.nudEmbossDepth).EndInit();

        ((System.ComponentModel.ISupportInitialize) this.nudBlockDepth).EndInit();

        ((System.ComponentModel.ISupportInitialize) this.nudSkew).EndInit();

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

    // This void creates The Sample Text with an Embossed look
    //   To create effect, The Sample Text is drawn twice.  The first
    //   time it is in Black and offset, then drawn in aquamarine.
    // This gives the impression of the text being raised.
    // To give the imporession of being engraved, simply use the
    //   negative of the Offset.
    private void btnBlockText_Click(object sender, System.EventArgs e) 
	{
        SizeF textSize ;
        Graphics g ;
        Brush myBackBrush  = Brushes.Black;
        Brush myForeBrush  = Brushes.Aquamarine;
        Font myFont = new Font("Times new Roman", Convert.ToSingle(this.nudFontSize.Value), FontStyle.Regular);
        Single xLocation, yLocation ; //' Used for the location;
        int i ;
        // Create a Graphics object from the picture box + clear it
        g = picDemoArea.CreateGraphics();
        g.Clear(Color.White);
        // Find the Size required to draw the Sample Text
        textSize = g.MeasureString(this.txtShortText.Text, myFont);
        // Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2;
        yLocation = (picDemoArea.Height - textSize.Height) / 2;
        // Draw the Black background first
        //   To get the effect, the text must be drawn repeatedly
        //   from the offset right up to where the main text
        //   will be drawn.
        // Since people tend to think of light coming from the 
        //   upper right, it often makes more sense to subtract
        //   the offset depth from the X dimension, instead of 
        //   adding it. Otherwise, it looks more like a shadow.
        for (i = Convert.ToInt32(nudBlockDepth.Value);i >= 0; i--)
		{
            g.DrawString(txtShortText.Text, myFont, myBackBrush,
                    xLocation - i, yLocation + i);
        }
        // Draw the aquamarine main text over the black text
        g.DrawString(txtShortText.Text, myFont, myForeBrush, xLocation, yLocation);
    }

    // This void creates the Sample Text with a brush (Hatch or Gradient)
    private void btnBrushText_Click(object sender, System.EventArgs e) 
	{
        SizeF textSize ;
        Graphics g ;
        Brush myBrush ;
        RectangleF gradientRectangle ;
        Font myFont = new Font("Times new Roman", Convert.ToSingle(this.nudFontSize.Value), FontStyle.Regular);
        // Create a Graphics object from the picture box + clear it
        g = picDemoArea.CreateGraphics();
        g.Clear(Color.White);
        // Find the Size required to draw the Sample Text
        textSize = g.MeasureString(this.txtShortText.Text, myFont);
        // Create the required brush

		if (this.optHatch.Checked)
		{
			// Create a HatchBrush. In this case, simply a Diagonal Brick
			myBrush = new HatchBrush(HatchStyle.DiagonalBrick,
				Color.Blue, Color.Yellow);
		}
		else 
		{
			// Create a LinearGradientBrush. In this case, simply a 
			//   Diagonal Gradient 
			gradientRectangle = new RectangleF(new PointF(0, 0), textSize);
			myBrush = new LinearGradientBrush(gradientRectangle, Color.Blue,
				Color.Yellow, LinearGradientMode.ForwardDiagonal);
		}
        // Draw the text
        g.DrawString(txtShortText.Text, myFont, myBrush,
                (picDemoArea.Width - textSize.Width) / 2,
                (picDemoArea.Height - textSize.Height) / 2);
    }

    // This void creates the Sample Text with an Embossed look
    //   To create effect, the Sample Text is drawn twice.  The first
    //   time it is in Black and offset, then drawn in white, The 
    //   current background color.
    // This gives the impression of the text being raised.
    // To give the imporession of being engraved, simply use the
    //   negative of the Offset.
    private void btnEmboss_Click(object sender, System.EventArgs e) 
	{
        SizeF textSize ;
        Graphics g ;
        Brush myBackBrush  = Brushes.Black;
        Brush myForeBrush  = Brushes.White;
        Font myFont = new Font("Times new Roman", Convert.ToSingle(this.nudFontSize.Value), FontStyle.Regular);
        Single xLocation, yLocation;  //' Used for the location;
        // Create a Graphics object from the picture box + clear it
        g = picDemoArea.CreateGraphics();
        g.Clear(Color.White);
        // Find the Size required to draw the Sample Text
        textSize = g.MeasureString(this.txtShortText.Text, myFont);
        // Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2;
        yLocation = (picDemoArea.Height - textSize.Height) / 2;
        // Draw the Black background first
        // (Note: if you instead subtract the mudEmbossDepth, you will get
        //   an Engrave effect.)
        g.DrawString(txtShortText.Text, myFont, myBackBrush,
                xLocation + Convert.ToSingle(this.nudEmbossDepth.Value),
                yLocation + Convert.ToSingle(this.nudEmbossDepth.Value));
        // Draw the white main text over the black text
        g.DrawString(txtShortText.Text, myFont, myForeBrush, xLocation, yLocation);
    }

    // This sub reflects text around the baseline of the characters.
    //   This is the first example that requires careful measurement of 
    //   the text, and is more advanced than most of the other examples.
    private void btnReflectedText_Click(object sender, System.EventArgs e) 
	{
        SizeF textSize ;
        Graphics g ;
        Brush myBackBrush  = Brushes.Gray;
        Brush myForeBrush  = Brushes.Black;
        Font myFont = new Font("Times new Roman", Convert.ToSingle(this.nudFontSize.Value), FontStyle.Regular);
        GraphicsState myState ; //' Used to store current state of Graphics;
        Single xLocation, yLocation;   //' Used for the location;
        Single textHeight ;
        int i;  //' For Loops;

        // Create a Graphics object from the picture box + clear it
        g = picDemoArea.CreateGraphics();
        g.Clear(Color.White);

        // Find the Size required to draw the Sample Text
        textSize = g.MeasureString(this.txtShortText.Text, myFont);
        // Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2;
        yLocation = (picDemoArea.Height - textSize.Height) / 2;
        // Because we will be scaling, and scaling effects the ENTIRE
        //   graphics object, not just the text, we need to reposition
        //   the Origin of the Graphics object (0,0) to the (xLocation,
        //   yLocation) point. if we don't, when we attempt to flip 
        //   the text with a scaling transform, it will merely draw the
        //   reflected text at (xLocation, -yLocation) which is outside
        //   the viewable area.
        g.TranslateTransform(xLocation, yLocation);
        // Reflecting around the Origin still poses problems. The
        //   origin represents the upper left corner of the rectangle.
        //   This means the reflection will occur at the TOP of the 
        //   original drawing. This is not how people are used to 
        //   seing reflected text. Thus, we need to determine where to
        //   draw the text. This can be done only when we have calculated
        //   the height required by the Drawing.
        // This is not simple it may seem. The Height returned 
        //   from the Measurestring method includes some extra spacing 
        //   for descenders and whitespace. We want ONLY the height from
        //   the BASELINE (which is the line which all caps sit). Any
        //   characters with descenders drop below the baseline. To 
        //   calculate the height above the baseline, use the 
        //   GetCellAscent method. Since GetCellAscent returns a Design
        //   Metric value it must be converted to pixels, and scaled for
        //   the font size.
        // Note: this looks best with characters that can be reflected
        //   over the baseline nicely -- like caps. Characters with descenders
        //   look odd. To fix that uncomment the two lines below, which
        //   then reflect across the lowest descender height.
        int lineAscent ;
        int lineSpacing ;
        Single lineHeight ;
        lineAscent = myFont.FontFamily.GetCellAscent(myFont.Style);
        lineSpacing = myFont.FontFamily.GetLineSpacing(myFont.Style);
        lineHeight = myFont.GetHeight(g);
        textHeight = lineHeight * lineAscent / lineSpacing;
        //' Uncomment these lines to reflect over lowest portion
        //'   of the characters.
        //lineDescent int ' used for reflecting descending characters
        //lineDescent = myFont.FontFamily.GetCellDescent(myFont.Style)
        //textHeight = lineHeight * (lineAscent + lineDescent) / lineSpacing
        // Draw the reflected one first. The only reason to draw the
        //   Reflected one first is to demonstrate the use of the
        //   GraphicsState object. 
        // A GraphicsState object maintains the state of the Graphics
        //   object it currently stands. You can then scale, resize and
        //   otherwise transform the Graphics object. You can 
        //   immediately go back to a previous state using the Restore
        //   method of the Graphics object.
        // Had we drawn the main one first, we would not have needed the 
        //   Restore method or the GraphicsState object.
        // First Save the graphics state
        myState = g.Save();
        // To draw the reflection, use the ScaleTransform with a negative
        //   value. Using -1 will reflect the Text with no distortion.
        // Remember to account for the fact that the origin has been reset.
        g.ScaleTransform(1, -1.0F); //' Only reflecting in the Y direction;
        g.DrawString(txtShortText.Text, myFont, myBackBrush, 0, -textHeight);
        // Reset the graphics state to before the transform
        g.Restore(myState);
        // Draw the main text
        g.DrawString(txtShortText.Text, myFont, myForeBrush, 0, -textHeight);
    }

    // This void creates the Sample Text with a solid brush and shadow
    //   To create the shadow, The Sample Text is drawn twice.  The first
    //   time it is in Grey and offset, then normally in Black.
    //   Other colors can, of course, be used.
    private void btnShadowText_Click(object sender, System.EventArgs e)
	{
        SizeF textSize ;
        Graphics g ;
        Brush myShadowBrush  = Brushes.Gray;
        Brush myForeBrush  = Brushes.Black;
        Font myFont = new Font("Times new Roman", Convert.ToSingle(this.nudFontSize.Value), FontStyle.Regular);
        Single xLocation, yLocation;  //' Used for the location;
        // Create a Graphics object from the picture box + clear it
        g = picDemoArea.CreateGraphics();
        g.Clear(Color.White);
        // Find the Size required to draw the Sample Text
        textSize = g.MeasureString(this.txtShortText.Text, myFont);
        // Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2;
        yLocation = (picDemoArea.Height - textSize.Height) / 2;
        // Draw the Shadow first
        g.DrawString(txtShortText.Text, myFont, myShadowBrush,
                xLocation + Convert.ToSingle(this.nudShadowDepth.Value),
                yLocation + Convert.ToSingle(this.nudShadowDepth.Value));
        // Draw the Main text over the shadow
        g.DrawString(txtShortText.Text, myFont, myForeBrush, xLocation, yLocation);
    }

    // This sub shears the text so that it appears angled. This requires
    //   The use of a Matrix which defines the shear. 
    private void btnShearText_Click(object sender, System.EventArgs e) 
	{
        SizeF textSize ;
        Graphics g ;
        Brush myForeBrush  = Brushes.Black;
        Font myFont = new Font("Times new Roman", Convert.ToSingle(this.nudFontSize.Value), FontStyle.Regular);
        Matrix myTransform ;  //' Used for shearing text;
        Single xLocation, yLocation;  //' Used for the location;
        Single textHeight ;
        int i;  //' For Loops;
        // Create a Graphics object from the picture box + clear it
        g = picDemoArea.CreateGraphics();
        g.Clear(Color.White);
        // Find the Size required to draw the Sample Text
        textSize = g.MeasureString(this.txtShortText.Text, myFont);
        // Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2;
        yLocation = (picDemoArea.Height - textSize.Height) / 2;
        // Because we will be scaling, and scaling effects the ENTIRE
        //   graphics object, not just the text, we need to reposition
        //   the Origin of the Graphics object (0,0) to the (xLocation,
        //   yLocation) point. 
        g.TranslateTransform(xLocation, yLocation);
        // Get the transform for the current Graphics object, and
        //   Shear it by the specified amount 
        myTransform = g.Transform;
        myTransform.Shear(Convert.ToSingle(nudSkew.Value), 0);
        g.Transform = myTransform;
        // Draw the main text
        g.DrawString(txtShortText.Text, myFont, myForeBrush, 0, 0);
    }

    // This sub simply takes the lines of text in the textbox and places
    //   them in the picDemoArea PictureBox.  It will word wrap as
    //   necessary, but will not scroll.
    private void btnSimpleText_Click(object sender, System.EventArgs e)
	{
        SizeF textSize ;
        Graphics g ;
        Brush myForeBrush  = Brushes.Black;
        Font myFont = new Font("Times new Roman", Convert.ToSingle(this.nudFontSize.Value), FontStyle.Regular);
        Single textHeight ;
        int i;  //' For Loops;
        // Create a Graphics object from the picture box + clear it
        g = picDemoArea.CreateGraphics();
        g.Clear(Color.White);
        // Find the Size required to draw the Sample Text
        textSize = g.MeasureString(txtLongText.Text, myFont);
        // Draw the main text

        g.DrawString(txtLongText.Text, myFont, myForeBrush,
            new RectangleF(0, 0, picDemoArea.Width, picDemoArea.Height));
    }
}

