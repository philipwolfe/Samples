//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
// Drawing2D is required to get access to 2 of the Brushes we'll use

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class frmMain : System.Windows.Forms.Form
{
    // Here all the class variables are defined
    // Since Brush is a MustInherit (abstract) class, this brush will
    //   actually be holding instances of the other 5 types of brushes
    Brush m_Brush;  //' Demonstration brush    
    Color m_Color1 = Color.Blue;  //' Mainly acts foreground color
    Color m_Color2 = Color.White;  //' Mainly acts background color
    Pen m_Pen;  //' Pen to use when drawing lines
    Rectangle m_BrushSize;  //' Rectangle used when tiling brushes
    Graphics myGraphics;  //' Graphics object used to draw brushes

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

    private System.Windows.Forms.PictureBox picDemoArea;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Button btnSetColor1;

    private System.Windows.Forms.TextBox txtColor1;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.ComboBox cboBrushType;

    private System.Windows.Forms.ComboBox cboDrawing;

    private System.Windows.Forms.Button btnSetColor2;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.TextBox txtColor2;

    private System.Windows.Forms.ComboBox cboBrushSize;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.ComboBox cboWrapMode;

    private System.Windows.Forms.Label Label7;

    private System.Windows.Forms.StatusBar sbrDrawingStatus;

    private System.Windows.Forms.ComboBox cboHatchStyle;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label Label10;

    private System.Windows.Forms.ComboBox cboGradientMode;

    private System.Windows.Forms.NumericUpDown nudRotation;

    private System.Windows.Forms.NumericUpDown nudGradientBlend;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.picDemoArea = new System.Windows.Forms.PictureBox();
		this.cboBrushType = new System.Windows.Forms.ComboBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.btnSetColor1 = new System.Windows.Forms.Button();
		this.txtColor1 = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.cboDrawing = new System.Windows.Forms.ComboBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.btnSetColor2 = new System.Windows.Forms.Button();
		this.txtColor2 = new System.Windows.Forms.TextBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.cboBrushSize = new System.Windows.Forms.ComboBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.cboWrapMode = new System.Windows.Forms.ComboBox();
		this.Label7 = new System.Windows.Forms.Label();
		this.sbrDrawingStatus = new System.Windows.Forms.StatusBar();
		this.cboHatchStyle = new System.Windows.Forms.ComboBox();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label9 = new System.Windows.Forms.Label();
		this.nudRotation = new System.Windows.Forms.NumericUpDown();
		this.Label1 = new System.Windows.Forms.Label();
		this.nudGradientBlend = new System.Windows.Forms.NumericUpDown();
		this.cboGradientMode = new System.Windows.Forms.ComboBox();
		this.Label10 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)(this.nudRotation)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.nudGradientBlend)).BeginInit();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuHelp});
		this.mnuMain.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mnuMain.RightToLeft")));
		// 
		// mnuFile
		// 
		this.mnuFile.Enabled = ((bool)(resources.GetObject("mnuFile.Enabled")));
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuExit});
		this.mnuFile.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuFile.Shortcut")));
		this.mnuFile.ShowShortcut = ((bool)(resources.GetObject("mnuFile.ShowShortcut")));
		this.mnuFile.Text = resources.GetString("mnuFile.Text");
		this.mnuFile.Visible = ((bool)(resources.GetObject("mnuFile.Visible")));
		// 
		// mnuExit
		// 
		this.mnuExit.Enabled = ((bool)(resources.GetObject("mnuExit.Enabled")));
		this.mnuExit.Index = 0;
		this.mnuExit.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuExit.Shortcut")));
		this.mnuExit.ShowShortcut = ((bool)(resources.GetObject("mnuExit.ShowShortcut")));
		this.mnuExit.Text = resources.GetString("mnuExit.Text");
		this.mnuExit.Visible = ((bool)(resources.GetObject("mnuExit.Visible")));
		this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Enabled = ((bool)(resources.GetObject("mnuHelp.Enabled")));
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuAbout});
		this.mnuHelp.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuHelp.Shortcut")));
		this.mnuHelp.ShowShortcut = ((bool)(resources.GetObject("mnuHelp.ShowShortcut")));
		this.mnuHelp.Text = resources.GetString("mnuHelp.Text");
		this.mnuHelp.Visible = ((bool)(resources.GetObject("mnuHelp.Visible")));
		// 
		// mnuAbout
		// 
		this.mnuAbout.Enabled = ((bool)(resources.GetObject("mnuAbout.Enabled")));
		this.mnuAbout.Index = 0;
		this.mnuAbout.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("mnuAbout.Shortcut")));
		this.mnuAbout.ShowShortcut = ((bool)(resources.GetObject("mnuAbout.ShowShortcut")));
		this.mnuAbout.Text = resources.GetString("mnuAbout.Text");
		this.mnuAbout.Visible = ((bool)(resources.GetObject("mnuAbout.Visible")));
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
		// 
		// picDemoArea
		// 
		this.picDemoArea.AccessibleDescription = resources.GetString("picDemoArea.AccessibleDescription");
		this.picDemoArea.AccessibleName = resources.GetString("picDemoArea.AccessibleName");
		this.picDemoArea.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("picDemoArea.Anchor")));
		this.picDemoArea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picDemoArea.BackgroundImage")));
		this.picDemoArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.picDemoArea.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("picDemoArea.Dock")));
		this.picDemoArea.Enabled = ((bool)(resources.GetObject("picDemoArea.Enabled")));
		this.picDemoArea.Font = ((System.Drawing.Font)(resources.GetObject("picDemoArea.Font")));
		this.picDemoArea.Image = ((System.Drawing.Image)(resources.GetObject("picDemoArea.Image")));
		this.picDemoArea.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("picDemoArea.ImeMode")));
		this.picDemoArea.Location = ((System.Drawing.Point)(resources.GetObject("picDemoArea.Location")));
		this.picDemoArea.Name = "picDemoArea";
		this.picDemoArea.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("picDemoArea.RightToLeft")));
		this.picDemoArea.Size = ((System.Drawing.Size)(resources.GetObject("picDemoArea.Size")));
		this.picDemoArea.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("picDemoArea.SizeMode")));
		this.picDemoArea.TabIndex = ((int)(resources.GetObject("picDemoArea.TabIndex")));
		this.picDemoArea.TabStop = false;
		this.picDemoArea.Text = resources.GetString("picDemoArea.Text");
		this.picDemoArea.Visible = ((bool)(resources.GetObject("picDemoArea.Visible")));
		// 
		// cboBrushType
		// 
		this.cboBrushType.AccessibleDescription = resources.GetString("cboBrushType.AccessibleDescription");
		this.cboBrushType.AccessibleName = resources.GetString("cboBrushType.AccessibleName");
		this.cboBrushType.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cboBrushType.Anchor")));
		this.cboBrushType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cboBrushType.BackgroundImage")));
		this.cboBrushType.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cboBrushType.Dock")));
		this.cboBrushType.Enabled = ((bool)(resources.GetObject("cboBrushType.Enabled")));
		this.cboBrushType.Font = ((System.Drawing.Font)(resources.GetObject("cboBrushType.Font")));
		this.cboBrushType.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cboBrushType.ImeMode")));
		this.cboBrushType.IntegralHeight = ((bool)(resources.GetObject("cboBrushType.IntegralHeight")));
		this.cboBrushType.ItemHeight = ((int)(resources.GetObject("cboBrushType.ItemHeight")));
		this.cboBrushType.Items.AddRange(new object[] {
														  resources.GetString("cboBrushType.Items"),
														  resources.GetString("cboBrushType.Items1"),
														  resources.GetString("cboBrushType.Items2"),
														  resources.GetString("cboBrushType.Items3"),
														  resources.GetString("cboBrushType.Items4")});
		this.cboBrushType.Location = ((System.Drawing.Point)(resources.GetObject("cboBrushType.Location")));
		this.cboBrushType.MaxDropDownItems = ((int)(resources.GetObject("cboBrushType.MaxDropDownItems")));
		this.cboBrushType.MaxLength = ((int)(resources.GetObject("cboBrushType.MaxLength")));
		this.cboBrushType.Name = "cboBrushType";
		this.cboBrushType.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboBrushType.RightToLeft")));
		this.cboBrushType.Size = ((System.Drawing.Size)(resources.GetObject("cboBrushType.Size")));
		this.cboBrushType.TabIndex = ((int)(resources.GetObject("cboBrushType.TabIndex")));
		this.cboBrushType.Text = resources.GetString("cboBrushType.Text");
		this.cboBrushType.Visible = ((bool)(resources.GetObject("cboBrushType.Visible")));
		this.cboBrushType.SelectedIndexChanged += new System.EventHandler(this.RedrawPicture);
		// 
		// Label2
		// 
		this.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription");
		this.Label2.AccessibleName = resources.GetString("Label2.AccessibleName");
		this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label2.Anchor")));
		this.Label2.AutoSize = ((bool)(resources.GetObject("Label2.AutoSize")));
		this.Label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label2.Dock")));
		this.Label2.Enabled = ((bool)(resources.GetObject("Label2.Enabled")));
		this.Label2.Font = ((System.Drawing.Font)(resources.GetObject("Label2.Font")));
		this.Label2.Image = ((System.Drawing.Image)(resources.GetObject("Label2.Image")));
		this.Label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label2.ImageAlign")));
		this.Label2.ImageIndex = ((int)(resources.GetObject("Label2.ImageIndex")));
		this.Label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label2.ImeMode")));
		this.Label2.Location = ((System.Drawing.Point)(resources.GetObject("Label2.Location")));
		this.Label2.Name = "Label2";
		this.Label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label2.RightToLeft")));
		this.Label2.Size = ((System.Drawing.Size)(resources.GetObject("Label2.Size")));
		this.Label2.TabIndex = ((int)(resources.GetObject("Label2.TabIndex")));
		this.Label2.Text = resources.GetString("Label2.Text");
		this.Label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label2.TextAlign")));
		this.Label2.Visible = ((bool)(resources.GetObject("Label2.Visible")));
		// 
		// btnSetColor1
		// 
		this.btnSetColor1.AccessibleDescription = resources.GetString("btnSetColor1.AccessibleDescription");
		this.btnSetColor1.AccessibleName = resources.GetString("btnSetColor1.AccessibleName");
		this.btnSetColor1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSetColor1.Anchor")));
		this.btnSetColor1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetColor1.BackgroundImage")));
		this.btnSetColor1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSetColor1.Dock")));
		this.btnSetColor1.Enabled = ((bool)(resources.GetObject("btnSetColor1.Enabled")));
		this.btnSetColor1.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSetColor1.FlatStyle")));
		this.btnSetColor1.Font = ((System.Drawing.Font)(resources.GetObject("btnSetColor1.Font")));
		this.btnSetColor1.Image = ((System.Drawing.Image)(resources.GetObject("btnSetColor1.Image")));
		this.btnSetColor1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetColor1.ImageAlign")));
		this.btnSetColor1.ImageIndex = ((int)(resources.GetObject("btnSetColor1.ImageIndex")));
		this.btnSetColor1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSetColor1.ImeMode")));
		this.btnSetColor1.Location = ((System.Drawing.Point)(resources.GetObject("btnSetColor1.Location")));
		this.btnSetColor1.Name = "btnSetColor1";
		this.btnSetColor1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSetColor1.RightToLeft")));
		this.btnSetColor1.Size = ((System.Drawing.Size)(resources.GetObject("btnSetColor1.Size")));
		this.btnSetColor1.TabIndex = ((int)(resources.GetObject("btnSetColor1.TabIndex")));
		this.btnSetColor1.Text = resources.GetString("btnSetColor1.Text");
		this.btnSetColor1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetColor1.TextAlign")));
		this.btnSetColor1.Visible = ((bool)(resources.GetObject("btnSetColor1.Visible")));
		this.btnSetColor1.Click += new System.EventHandler(this.btnSetColor1_Click);
		// 
		// txtColor1
		// 
		this.txtColor1.AccessibleDescription = resources.GetString("txtColor1.AccessibleDescription");
		this.txtColor1.AccessibleName = resources.GetString("txtColor1.AccessibleName");
		this.txtColor1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtColor1.Anchor")));
		this.txtColor1.AutoSize = ((bool)(resources.GetObject("txtColor1.AutoSize")));
		this.txtColor1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtColor1.BackgroundImage")));
		this.txtColor1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtColor1.Dock")));
		this.txtColor1.Enabled = ((bool)(resources.GetObject("txtColor1.Enabled")));
		this.txtColor1.Font = ((System.Drawing.Font)(resources.GetObject("txtColor1.Font")));
		this.txtColor1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtColor1.ImeMode")));
		this.txtColor1.Location = ((System.Drawing.Point)(resources.GetObject("txtColor1.Location")));
		this.txtColor1.MaxLength = ((int)(resources.GetObject("txtColor1.MaxLength")));
		this.txtColor1.Multiline = ((bool)(resources.GetObject("txtColor1.Multiline")));
		this.txtColor1.Name = "txtColor1";
		this.txtColor1.PasswordChar = ((char)(resources.GetObject("txtColor1.PasswordChar")));
		this.txtColor1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtColor1.RightToLeft")));
		this.txtColor1.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtColor1.ScrollBars")));
		this.txtColor1.Size = ((System.Drawing.Size)(resources.GetObject("txtColor1.Size")));
		this.txtColor1.TabIndex = ((int)(resources.GetObject("txtColor1.TabIndex")));
		this.txtColor1.Text = resources.GetString("txtColor1.Text");
		this.txtColor1.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtColor1.TextAlign")));
		this.txtColor1.Visible = ((bool)(resources.GetObject("txtColor1.Visible")));
		this.txtColor1.WordWrap = ((bool)(resources.GetObject("txtColor1.WordWrap")));
		this.txtColor1.TextChanged += new System.EventHandler(this.RedrawPicture);
		// 
		// Label3
		// 
		this.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription");
		this.Label3.AccessibleName = resources.GetString("Label3.AccessibleName");
		this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label3.Anchor")));
		this.Label3.AutoSize = ((bool)(resources.GetObject("Label3.AutoSize")));
		this.Label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label3.Dock")));
		this.Label3.Enabled = ((bool)(resources.GetObject("Label3.Enabled")));
		this.Label3.Font = ((System.Drawing.Font)(resources.GetObject("Label3.Font")));
		this.Label3.Image = ((System.Drawing.Image)(resources.GetObject("Label3.Image")));
		this.Label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label3.ImageAlign")));
		this.Label3.ImageIndex = ((int)(resources.GetObject("Label3.ImageIndex")));
		this.Label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label3.ImeMode")));
		this.Label3.Location = ((System.Drawing.Point)(resources.GetObject("Label3.Location")));
		this.Label3.Name = "Label3";
		this.Label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label3.RightToLeft")));
		this.Label3.Size = ((System.Drawing.Size)(resources.GetObject("Label3.Size")));
		this.Label3.TabIndex = ((int)(resources.GetObject("Label3.TabIndex")));
		this.Label3.Text = resources.GetString("Label3.Text");
		this.Label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label3.TextAlign")));
		this.Label3.Visible = ((bool)(resources.GetObject("Label3.Visible")));
		// 
		// cboDrawing
		// 
		this.cboDrawing.AccessibleDescription = resources.GetString("cboDrawing.AccessibleDescription");
		this.cboDrawing.AccessibleName = resources.GetString("cboDrawing.AccessibleName");
		this.cboDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cboDrawing.Anchor")));
		this.cboDrawing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cboDrawing.BackgroundImage")));
		this.cboDrawing.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cboDrawing.Dock")));
		this.cboDrawing.Enabled = ((bool)(resources.GetObject("cboDrawing.Enabled")));
		this.cboDrawing.Font = ((System.Drawing.Font)(resources.GetObject("cboDrawing.Font")));
		this.cboDrawing.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cboDrawing.ImeMode")));
		this.cboDrawing.IntegralHeight = ((bool)(resources.GetObject("cboDrawing.IntegralHeight")));
		this.cboDrawing.ItemHeight = ((int)(resources.GetObject("cboDrawing.ItemHeight")));
		this.cboDrawing.Items.AddRange(new object[] {
														resources.GetString("cboDrawing.Items"),
														resources.GetString("cboDrawing.Items1"),
														resources.GetString("cboDrawing.Items2")});
		this.cboDrawing.Location = ((System.Drawing.Point)(resources.GetObject("cboDrawing.Location")));
		this.cboDrawing.MaxDropDownItems = ((int)(resources.GetObject("cboDrawing.MaxDropDownItems")));
		this.cboDrawing.MaxLength = ((int)(resources.GetObject("cboDrawing.MaxLength")));
		this.cboDrawing.Name = "cboDrawing";
		this.cboDrawing.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboDrawing.RightToLeft")));
		this.cboDrawing.Size = ((System.Drawing.Size)(resources.GetObject("cboDrawing.Size")));
		this.cboDrawing.TabIndex = ((int)(resources.GetObject("cboDrawing.TabIndex")));
		this.cboDrawing.Text = resources.GetString("cboDrawing.Text");
		this.cboDrawing.Visible = ((bool)(resources.GetObject("cboDrawing.Visible")));
		this.cboDrawing.SelectedIndexChanged += new System.EventHandler(this.RedrawPicture);
		// 
		// Label4
		// 
		this.Label4.AccessibleDescription = resources.GetString("Label4.AccessibleDescription");
		this.Label4.AccessibleName = resources.GetString("Label4.AccessibleName");
		this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label4.Anchor")));
		this.Label4.AutoSize = ((bool)(resources.GetObject("Label4.AutoSize")));
		this.Label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label4.Dock")));
		this.Label4.Enabled = ((bool)(resources.GetObject("Label4.Enabled")));
		this.Label4.Font = ((System.Drawing.Font)(resources.GetObject("Label4.Font")));
		this.Label4.Image = ((System.Drawing.Image)(resources.GetObject("Label4.Image")));
		this.Label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label4.ImageAlign")));
		this.Label4.ImageIndex = ((int)(resources.GetObject("Label4.ImageIndex")));
		this.Label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label4.ImeMode")));
		this.Label4.Location = ((System.Drawing.Point)(resources.GetObject("Label4.Location")));
		this.Label4.Name = "Label4";
		this.Label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label4.RightToLeft")));
		this.Label4.Size = ((System.Drawing.Size)(resources.GetObject("Label4.Size")));
		this.Label4.TabIndex = ((int)(resources.GetObject("Label4.TabIndex")));
		this.Label4.Text = resources.GetString("Label4.Text");
		this.Label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label4.TextAlign")));
		this.Label4.Visible = ((bool)(resources.GetObject("Label4.Visible")));
		// 
		// btnSetColor2
		// 
		this.btnSetColor2.AccessibleDescription = resources.GetString("btnSetColor2.AccessibleDescription");
		this.btnSetColor2.AccessibleName = resources.GetString("btnSetColor2.AccessibleName");
		this.btnSetColor2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnSetColor2.Anchor")));
		this.btnSetColor2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetColor2.BackgroundImage")));
		this.btnSetColor2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnSetColor2.Dock")));
		this.btnSetColor2.Enabled = ((bool)(resources.GetObject("btnSetColor2.Enabled")));
		this.btnSetColor2.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnSetColor2.FlatStyle")));
		this.btnSetColor2.Font = ((System.Drawing.Font)(resources.GetObject("btnSetColor2.Font")));
		this.btnSetColor2.Image = ((System.Drawing.Image)(resources.GetObject("btnSetColor2.Image")));
		this.btnSetColor2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetColor2.ImageAlign")));
		this.btnSetColor2.ImageIndex = ((int)(resources.GetObject("btnSetColor2.ImageIndex")));
		this.btnSetColor2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnSetColor2.ImeMode")));
		this.btnSetColor2.Location = ((System.Drawing.Point)(resources.GetObject("btnSetColor2.Location")));
		this.btnSetColor2.Name = "btnSetColor2";
		this.btnSetColor2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnSetColor2.RightToLeft")));
		this.btnSetColor2.Size = ((System.Drawing.Size)(resources.GetObject("btnSetColor2.Size")));
		this.btnSetColor2.TabIndex = ((int)(resources.GetObject("btnSetColor2.TabIndex")));
		this.btnSetColor2.Text = resources.GetString("btnSetColor2.Text");
		this.btnSetColor2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnSetColor2.TextAlign")));
		this.btnSetColor2.Visible = ((bool)(resources.GetObject("btnSetColor2.Visible")));
		this.btnSetColor2.Click += new System.EventHandler(this.btnSetColor2_Click);
		// 
		// txtColor2
		// 
		this.txtColor2.AccessibleDescription = resources.GetString("txtColor2.AccessibleDescription");
		this.txtColor2.AccessibleName = resources.GetString("txtColor2.AccessibleName");
		this.txtColor2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtColor2.Anchor")));
		this.txtColor2.AutoSize = ((bool)(resources.GetObject("txtColor2.AutoSize")));
		this.txtColor2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtColor2.BackgroundImage")));
		this.txtColor2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtColor2.Dock")));
		this.txtColor2.Enabled = ((bool)(resources.GetObject("txtColor2.Enabled")));
		this.txtColor2.Font = ((System.Drawing.Font)(resources.GetObject("txtColor2.Font")));
		this.txtColor2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtColor2.ImeMode")));
		this.txtColor2.Location = ((System.Drawing.Point)(resources.GetObject("txtColor2.Location")));
		this.txtColor2.MaxLength = ((int)(resources.GetObject("txtColor2.MaxLength")));
		this.txtColor2.Multiline = ((bool)(resources.GetObject("txtColor2.Multiline")));
		this.txtColor2.Name = "txtColor2";
		this.txtColor2.PasswordChar = ((char)(resources.GetObject("txtColor2.PasswordChar")));
		this.txtColor2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtColor2.RightToLeft")));
		this.txtColor2.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtColor2.ScrollBars")));
		this.txtColor2.Size = ((System.Drawing.Size)(resources.GetObject("txtColor2.Size")));
		this.txtColor2.TabIndex = ((int)(resources.GetObject("txtColor2.TabIndex")));
		this.txtColor2.Text = resources.GetString("txtColor2.Text");
		this.txtColor2.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtColor2.TextAlign")));
		this.txtColor2.Visible = ((bool)(resources.GetObject("txtColor2.Visible")));
		this.txtColor2.WordWrap = ((bool)(resources.GetObject("txtColor2.WordWrap")));
		this.txtColor2.TextChanged += new System.EventHandler(this.RedrawPicture);
		// 
		// Label5
		// 
		this.Label5.AccessibleDescription = resources.GetString("Label5.AccessibleDescription");
		this.Label5.AccessibleName = resources.GetString("Label5.AccessibleName");
		this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label5.Anchor")));
		this.Label5.AutoSize = ((bool)(resources.GetObject("Label5.AutoSize")));
		this.Label5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label5.Dock")));
		this.Label5.Enabled = ((bool)(resources.GetObject("Label5.Enabled")));
		this.Label5.Font = ((System.Drawing.Font)(resources.GetObject("Label5.Font")));
		this.Label5.Image = ((System.Drawing.Image)(resources.GetObject("Label5.Image")));
		this.Label5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label5.ImageAlign")));
		this.Label5.ImageIndex = ((int)(resources.GetObject("Label5.ImageIndex")));
		this.Label5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label5.ImeMode")));
		this.Label5.Location = ((System.Drawing.Point)(resources.GetObject("Label5.Location")));
		this.Label5.Name = "Label5";
		this.Label5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label5.RightToLeft")));
		this.Label5.Size = ((System.Drawing.Size)(resources.GetObject("Label5.Size")));
		this.Label5.TabIndex = ((int)(resources.GetObject("Label5.TabIndex")));
		this.Label5.Text = resources.GetString("Label5.Text");
		this.Label5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label5.TextAlign")));
		this.Label5.Visible = ((bool)(resources.GetObject("Label5.Visible")));
		// 
		// cboBrushSize
		// 
		this.cboBrushSize.AccessibleDescription = resources.GetString("cboBrushSize.AccessibleDescription");
		this.cboBrushSize.AccessibleName = resources.GetString("cboBrushSize.AccessibleName");
		this.cboBrushSize.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cboBrushSize.Anchor")));
		this.cboBrushSize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cboBrushSize.BackgroundImage")));
		this.cboBrushSize.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cboBrushSize.Dock")));
		this.cboBrushSize.Enabled = ((bool)(resources.GetObject("cboBrushSize.Enabled")));
		this.cboBrushSize.Font = ((System.Drawing.Font)(resources.GetObject("cboBrushSize.Font")));
		this.cboBrushSize.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cboBrushSize.ImeMode")));
		this.cboBrushSize.IntegralHeight = ((bool)(resources.GetObject("cboBrushSize.IntegralHeight")));
		this.cboBrushSize.ItemHeight = ((int)(resources.GetObject("cboBrushSize.ItemHeight")));
		this.cboBrushSize.Items.AddRange(new object[] {
														  resources.GetString("cboBrushSize.Items"),
														  resources.GetString("cboBrushSize.Items1"),
														  resources.GetString("cboBrushSize.Items2")});
		this.cboBrushSize.Location = ((System.Drawing.Point)(resources.GetObject("cboBrushSize.Location")));
		this.cboBrushSize.MaxDropDownItems = ((int)(resources.GetObject("cboBrushSize.MaxDropDownItems")));
		this.cboBrushSize.MaxLength = ((int)(resources.GetObject("cboBrushSize.MaxLength")));
		this.cboBrushSize.Name = "cboBrushSize";
		this.cboBrushSize.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboBrushSize.RightToLeft")));
		this.cboBrushSize.Size = ((System.Drawing.Size)(resources.GetObject("cboBrushSize.Size")));
		this.cboBrushSize.TabIndex = ((int)(resources.GetObject("cboBrushSize.TabIndex")));
		this.cboBrushSize.Text = resources.GetString("cboBrushSize.Text");
		this.cboBrushSize.Visible = ((bool)(resources.GetObject("cboBrushSize.Visible")));
		this.cboBrushSize.SelectedIndexChanged += new System.EventHandler(this.cboBrushSize_SelectedIndexChanged);
		// 
		// Label6
		// 
		this.Label6.AccessibleDescription = resources.GetString("Label6.AccessibleDescription");
		this.Label6.AccessibleName = resources.GetString("Label6.AccessibleName");
		this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label6.Anchor")));
		this.Label6.AutoSize = ((bool)(resources.GetObject("Label6.AutoSize")));
		this.Label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label6.Dock")));
		this.Label6.Enabled = ((bool)(resources.GetObject("Label6.Enabled")));
		this.Label6.Font = ((System.Drawing.Font)(resources.GetObject("Label6.Font")));
		this.Label6.Image = ((System.Drawing.Image)(resources.GetObject("Label6.Image")));
		this.Label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label6.ImageAlign")));
		this.Label6.ImageIndex = ((int)(resources.GetObject("Label6.ImageIndex")));
		this.Label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label6.ImeMode")));
		this.Label6.Location = ((System.Drawing.Point)(resources.GetObject("Label6.Location")));
		this.Label6.Name = "Label6";
		this.Label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label6.RightToLeft")));
		this.Label6.Size = ((System.Drawing.Size)(resources.GetObject("Label6.Size")));
		this.Label6.TabIndex = ((int)(resources.GetObject("Label6.TabIndex")));
		this.Label6.Text = resources.GetString("Label6.Text");
		this.Label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label6.TextAlign")));
		this.Label6.Visible = ((bool)(resources.GetObject("Label6.Visible")));
		// 
		// cboWrapMode
		// 
		this.cboWrapMode.AccessibleDescription = resources.GetString("cboWrapMode.AccessibleDescription");
		this.cboWrapMode.AccessibleName = resources.GetString("cboWrapMode.AccessibleName");
		this.cboWrapMode.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cboWrapMode.Anchor")));
		this.cboWrapMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cboWrapMode.BackgroundImage")));
		this.cboWrapMode.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cboWrapMode.Dock")));
		this.cboWrapMode.Enabled = ((bool)(resources.GetObject("cboWrapMode.Enabled")));
		this.cboWrapMode.Font = ((System.Drawing.Font)(resources.GetObject("cboWrapMode.Font")));
		this.cboWrapMode.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cboWrapMode.ImeMode")));
		this.cboWrapMode.IntegralHeight = ((bool)(resources.GetObject("cboWrapMode.IntegralHeight")));
		this.cboWrapMode.ItemHeight = ((int)(resources.GetObject("cboWrapMode.ItemHeight")));
		this.cboWrapMode.Location = ((System.Drawing.Point)(resources.GetObject("cboWrapMode.Location")));
		this.cboWrapMode.MaxDropDownItems = ((int)(resources.GetObject("cboWrapMode.MaxDropDownItems")));
		this.cboWrapMode.MaxLength = ((int)(resources.GetObject("cboWrapMode.MaxLength")));
		this.cboWrapMode.Name = "cboWrapMode";
		this.cboWrapMode.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboWrapMode.RightToLeft")));
		this.cboWrapMode.Size = ((System.Drawing.Size)(resources.GetObject("cboWrapMode.Size")));
		this.cboWrapMode.TabIndex = ((int)(resources.GetObject("cboWrapMode.TabIndex")));
		this.cboWrapMode.Text = resources.GetString("cboWrapMode.Text");
		this.cboWrapMode.Visible = ((bool)(resources.GetObject("cboWrapMode.Visible")));
		this.cboWrapMode.SelectedIndexChanged += new System.EventHandler(this.RedrawPicture);
		// 
		// Label7
		// 
		this.Label7.AccessibleDescription = resources.GetString("Label7.AccessibleDescription");
		this.Label7.AccessibleName = resources.GetString("Label7.AccessibleName");
		this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label7.Anchor")));
		this.Label7.AutoSize = ((bool)(resources.GetObject("Label7.AutoSize")));
		this.Label7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label7.Dock")));
		this.Label7.Enabled = ((bool)(resources.GetObject("Label7.Enabled")));
		this.Label7.Font = ((System.Drawing.Font)(resources.GetObject("Label7.Font")));
		this.Label7.Image = ((System.Drawing.Image)(resources.GetObject("Label7.Image")));
		this.Label7.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label7.ImageAlign")));
		this.Label7.ImageIndex = ((int)(resources.GetObject("Label7.ImageIndex")));
		this.Label7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label7.ImeMode")));
		this.Label7.Location = ((System.Drawing.Point)(resources.GetObject("Label7.Location")));
		this.Label7.Name = "Label7";
		this.Label7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label7.RightToLeft")));
		this.Label7.Size = ((System.Drawing.Size)(resources.GetObject("Label7.Size")));
		this.Label7.TabIndex = ((int)(resources.GetObject("Label7.TabIndex")));
		this.Label7.Text = resources.GetString("Label7.Text");
		this.Label7.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label7.TextAlign")));
		this.Label7.Visible = ((bool)(resources.GetObject("Label7.Visible")));
		// 
		// sbrDrawingStatus
		// 
		this.sbrDrawingStatus.AccessibleDescription = resources.GetString("sbrDrawingStatus.AccessibleDescription");
		this.sbrDrawingStatus.AccessibleName = resources.GetString("sbrDrawingStatus.AccessibleName");
		this.sbrDrawingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("sbrDrawingStatus.Anchor")));
		this.sbrDrawingStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbrDrawingStatus.BackgroundImage")));
		this.sbrDrawingStatus.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("sbrDrawingStatus.Dock")));
		this.sbrDrawingStatus.Enabled = ((bool)(resources.GetObject("sbrDrawingStatus.Enabled")));
		this.sbrDrawingStatus.Font = ((System.Drawing.Font)(resources.GetObject("sbrDrawingStatus.Font")));
		this.sbrDrawingStatus.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("sbrDrawingStatus.ImeMode")));
		this.sbrDrawingStatus.Location = ((System.Drawing.Point)(resources.GetObject("sbrDrawingStatus.Location")));
		this.sbrDrawingStatus.Name = "sbrDrawingStatus";
		this.sbrDrawingStatus.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("sbrDrawingStatus.RightToLeft")));
		this.sbrDrawingStatus.Size = ((System.Drawing.Size)(resources.GetObject("sbrDrawingStatus.Size")));
		this.sbrDrawingStatus.TabIndex = ((int)(resources.GetObject("sbrDrawingStatus.TabIndex")));
		this.sbrDrawingStatus.Text = resources.GetString("sbrDrawingStatus.Text");
		this.sbrDrawingStatus.Visible = ((bool)(resources.GetObject("sbrDrawingStatus.Visible")));
		// 
		// cboHatchStyle
		// 
		this.cboHatchStyle.AccessibleDescription = resources.GetString("cboHatchStyle.AccessibleDescription");
		this.cboHatchStyle.AccessibleName = resources.GetString("cboHatchStyle.AccessibleName");
		this.cboHatchStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cboHatchStyle.Anchor")));
		this.cboHatchStyle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cboHatchStyle.BackgroundImage")));
		this.cboHatchStyle.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cboHatchStyle.Dock")));
		this.cboHatchStyle.Enabled = ((bool)(resources.GetObject("cboHatchStyle.Enabled")));
		this.cboHatchStyle.Font = ((System.Drawing.Font)(resources.GetObject("cboHatchStyle.Font")));
		this.cboHatchStyle.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cboHatchStyle.ImeMode")));
		this.cboHatchStyle.IntegralHeight = ((bool)(resources.GetObject("cboHatchStyle.IntegralHeight")));
		this.cboHatchStyle.ItemHeight = ((int)(resources.GetObject("cboHatchStyle.ItemHeight")));
		this.cboHatchStyle.Location = ((System.Drawing.Point)(resources.GetObject("cboHatchStyle.Location")));
		this.cboHatchStyle.MaxDropDownItems = ((int)(resources.GetObject("cboHatchStyle.MaxDropDownItems")));
		this.cboHatchStyle.MaxLength = ((int)(resources.GetObject("cboHatchStyle.MaxLength")));
		this.cboHatchStyle.Name = "cboHatchStyle";
		this.cboHatchStyle.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboHatchStyle.RightToLeft")));
		this.cboHatchStyle.Size = ((System.Drawing.Size)(resources.GetObject("cboHatchStyle.Size")));
		this.cboHatchStyle.TabIndex = ((int)(resources.GetObject("cboHatchStyle.TabIndex")));
		this.cboHatchStyle.Text = resources.GetString("cboHatchStyle.Text");
		this.cboHatchStyle.Visible = ((bool)(resources.GetObject("cboHatchStyle.Visible")));
		this.cboHatchStyle.SelectedIndexChanged += new System.EventHandler(this.RedrawPicture);
		// 
		// Label8
		// 
		this.Label8.AccessibleDescription = resources.GetString("Label8.AccessibleDescription");
		this.Label8.AccessibleName = resources.GetString("Label8.AccessibleName");
		this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label8.Anchor")));
		this.Label8.AutoSize = ((bool)(resources.GetObject("Label8.AutoSize")));
		this.Label8.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label8.Dock")));
		this.Label8.Enabled = ((bool)(resources.GetObject("Label8.Enabled")));
		this.Label8.Font = ((System.Drawing.Font)(resources.GetObject("Label8.Font")));
		this.Label8.Image = ((System.Drawing.Image)(resources.GetObject("Label8.Image")));
		this.Label8.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label8.ImageAlign")));
		this.Label8.ImageIndex = ((int)(resources.GetObject("Label8.ImageIndex")));
		this.Label8.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label8.ImeMode")));
		this.Label8.Location = ((System.Drawing.Point)(resources.GetObject("Label8.Location")));
		this.Label8.Name = "Label8";
		this.Label8.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label8.RightToLeft")));
		this.Label8.Size = ((System.Drawing.Size)(resources.GetObject("Label8.Size")));
		this.Label8.TabIndex = ((int)(resources.GetObject("Label8.TabIndex")));
		this.Label8.Text = resources.GetString("Label8.Text");
		this.Label8.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label8.TextAlign")));
		this.Label8.Visible = ((bool)(resources.GetObject("Label8.Visible")));
		// 
		// Label9
		// 
		this.Label9.AccessibleDescription = resources.GetString("Label9.AccessibleDescription");
		this.Label9.AccessibleName = resources.GetString("Label9.AccessibleName");
		this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label9.Anchor")));
		this.Label9.AutoSize = ((bool)(resources.GetObject("Label9.AutoSize")));
		this.Label9.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label9.Dock")));
		this.Label9.Enabled = ((bool)(resources.GetObject("Label9.Enabled")));
		this.Label9.Font = ((System.Drawing.Font)(resources.GetObject("Label9.Font")));
		this.Label9.Image = ((System.Drawing.Image)(resources.GetObject("Label9.Image")));
		this.Label9.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label9.ImageAlign")));
		this.Label9.ImageIndex = ((int)(resources.GetObject("Label9.ImageIndex")));
		this.Label9.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label9.ImeMode")));
		this.Label9.Location = ((System.Drawing.Point)(resources.GetObject("Label9.Location")));
		this.Label9.Name = "Label9";
		this.Label9.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label9.RightToLeft")));
		this.Label9.Size = ((System.Drawing.Size)(resources.GetObject("Label9.Size")));
		this.Label9.TabIndex = ((int)(resources.GetObject("Label9.TabIndex")));
		this.Label9.Text = resources.GetString("Label9.Text");
		this.Label9.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label9.TextAlign")));
		this.Label9.Visible = ((bool)(resources.GetObject("Label9.Visible")));
		// 
		// nudRotation
		// 
		this.nudRotation.AccessibleDescription = resources.GetString("nudRotation.AccessibleDescription");
		this.nudRotation.AccessibleName = resources.GetString("nudRotation.AccessibleName");
		this.nudRotation.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("nudRotation.Anchor")));
		this.nudRotation.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("nudRotation.Dock")));
		this.nudRotation.Enabled = ((bool)(resources.GetObject("nudRotation.Enabled")));
		this.nudRotation.Font = ((System.Drawing.Font)(resources.GetObject("nudRotation.Font")));
		this.nudRotation.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("nudRotation.ImeMode")));
		this.nudRotation.Increment = new System.Decimal(new int[] {
																	  5,
																	  0,
																	  0,
																	  0});
		this.nudRotation.Location = ((System.Drawing.Point)(resources.GetObject("nudRotation.Location")));
		this.nudRotation.Maximum = new System.Decimal(new int[] {
																	180,
																	0,
																	0,
																	0});
		this.nudRotation.Name = "nudRotation";
		this.nudRotation.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("nudRotation.RightToLeft")));
		this.nudRotation.Size = ((System.Drawing.Size)(resources.GetObject("nudRotation.Size")));
		this.nudRotation.TabIndex = ((int)(resources.GetObject("nudRotation.TabIndex")));
		this.nudRotation.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("nudRotation.TextAlign")));
		this.nudRotation.ThousandsSeparator = ((bool)(resources.GetObject("nudRotation.ThousandsSeparator")));
		this.nudRotation.UpDownAlign = ((System.Windows.Forms.LeftRightAlignment)(resources.GetObject("nudRotation.UpDownAlign")));
		this.nudRotation.Visible = ((bool)(resources.GetObject("nudRotation.Visible")));
		this.nudRotation.ValueChanged += new System.EventHandler(this.RedrawPicture);
		// 
		// Label1
		// 
		this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");
		this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");
		this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label1.Anchor")));
		this.Label1.AutoSize = ((bool)(resources.GetObject("Label1.AutoSize")));
		this.Label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label1.Dock")));
		this.Label1.Enabled = ((bool)(resources.GetObject("Label1.Enabled")));
		this.Label1.Font = ((System.Drawing.Font)(resources.GetObject("Label1.Font")));
		this.Label1.Image = ((System.Drawing.Image)(resources.GetObject("Label1.Image")));
		this.Label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.ImageAlign")));
		this.Label1.ImageIndex = ((int)(resources.GetObject("Label1.ImageIndex")));
		this.Label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label1.ImeMode")));
		this.Label1.Location = ((System.Drawing.Point)(resources.GetObject("Label1.Location")));
		this.Label1.Name = "Label1";
		this.Label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label1.RightToLeft")));
		this.Label1.Size = ((System.Drawing.Size)(resources.GetObject("Label1.Size")));
		this.Label1.TabIndex = ((int)(resources.GetObject("Label1.TabIndex")));
		this.Label1.Text = resources.GetString("Label1.Text");
		this.Label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.TextAlign")));
		this.Label1.Visible = ((bool)(resources.GetObject("Label1.Visible")));
		// 
		// nudGradientBlend
		// 
		this.nudGradientBlend.AccessibleDescription = resources.GetString("nudGradientBlend.AccessibleDescription");
		this.nudGradientBlend.AccessibleName = resources.GetString("nudGradientBlend.AccessibleName");
		this.nudGradientBlend.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("nudGradientBlend.Anchor")));
		this.nudGradientBlend.DecimalPlaces = 2;
		this.nudGradientBlend.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("nudGradientBlend.Dock")));
		this.nudGradientBlend.Enabled = ((bool)(resources.GetObject("nudGradientBlend.Enabled")));
		this.nudGradientBlend.Font = ((System.Drawing.Font)(resources.GetObject("nudGradientBlend.Font")));
		this.nudGradientBlend.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("nudGradientBlend.ImeMode")));
		this.nudGradientBlend.Increment = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   65536});
		this.nudGradientBlend.Location = ((System.Drawing.Point)(resources.GetObject("nudGradientBlend.Location")));
		this.nudGradientBlend.Maximum = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
		this.nudGradientBlend.Name = "nudGradientBlend";
		this.nudGradientBlend.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("nudGradientBlend.RightToLeft")));
		this.nudGradientBlend.Size = ((System.Drawing.Size)(resources.GetObject("nudGradientBlend.Size")));
		this.nudGradientBlend.TabIndex = ((int)(resources.GetObject("nudGradientBlend.TabIndex")));
		this.nudGradientBlend.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("nudGradientBlend.TextAlign")));
		this.nudGradientBlend.ThousandsSeparator = ((bool)(resources.GetObject("nudGradientBlend.ThousandsSeparator")));
		this.nudGradientBlend.UpDownAlign = ((System.Windows.Forms.LeftRightAlignment)(resources.GetObject("nudGradientBlend.UpDownAlign")));
		this.nudGradientBlend.Value = new System.Decimal(new int[] {
																	   1,
																	   0,
																	   0,
																	   0});
		this.nudGradientBlend.Visible = ((bool)(resources.GetObject("nudGradientBlend.Visible")));
		this.nudGradientBlend.ValueChanged += new System.EventHandler(this.RedrawPicture);
		// 
		// cboGradientMode
		// 
		this.cboGradientMode.AccessibleDescription = resources.GetString("cboGradientMode.AccessibleDescription");
		this.cboGradientMode.AccessibleName = resources.GetString("cboGradientMode.AccessibleName");
		this.cboGradientMode.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("cboGradientMode.Anchor")));
		this.cboGradientMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cboGradientMode.BackgroundImage")));
		this.cboGradientMode.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("cboGradientMode.Dock")));
		this.cboGradientMode.Enabled = ((bool)(resources.GetObject("cboGradientMode.Enabled")));
		this.cboGradientMode.Font = ((System.Drawing.Font)(resources.GetObject("cboGradientMode.Font")));
		this.cboGradientMode.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("cboGradientMode.ImeMode")));
		this.cboGradientMode.IntegralHeight = ((bool)(resources.GetObject("cboGradientMode.IntegralHeight")));
		this.cboGradientMode.ItemHeight = ((int)(resources.GetObject("cboGradientMode.ItemHeight")));
		this.cboGradientMode.Location = ((System.Drawing.Point)(resources.GetObject("cboGradientMode.Location")));
		this.cboGradientMode.MaxDropDownItems = ((int)(resources.GetObject("cboGradientMode.MaxDropDownItems")));
		this.cboGradientMode.MaxLength = ((int)(resources.GetObject("cboGradientMode.MaxLength")));
		this.cboGradientMode.Name = "cboGradientMode";
		this.cboGradientMode.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("cboGradientMode.RightToLeft")));
		this.cboGradientMode.Size = ((System.Drawing.Size)(resources.GetObject("cboGradientMode.Size")));
		this.cboGradientMode.TabIndex = ((int)(resources.GetObject("cboGradientMode.TabIndex")));
		this.cboGradientMode.Text = resources.GetString("cboGradientMode.Text");
		this.cboGradientMode.Visible = ((bool)(resources.GetObject("cboGradientMode.Visible")));
		this.cboGradientMode.SelectedIndexChanged += new System.EventHandler(this.RedrawPicture);
		// 
		// Label10
		// 
		this.Label10.AccessibleDescription = resources.GetString("Label10.AccessibleDescription");
		this.Label10.AccessibleName = resources.GetString("Label10.AccessibleName");
		this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label10.Anchor")));
		this.Label10.AutoSize = ((bool)(resources.GetObject("Label10.AutoSize")));
		this.Label10.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label10.Dock")));
		this.Label10.Enabled = ((bool)(resources.GetObject("Label10.Enabled")));
		this.Label10.Font = ((System.Drawing.Font)(resources.GetObject("Label10.Font")));
		this.Label10.Image = ((System.Drawing.Image)(resources.GetObject("Label10.Image")));
		this.Label10.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label10.ImageAlign")));
		this.Label10.ImageIndex = ((int)(resources.GetObject("Label10.ImageIndex")));
		this.Label10.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label10.ImeMode")));
		this.Label10.Location = ((System.Drawing.Point)(resources.GetObject("Label10.Location")));
		this.Label10.Name = "Label10";
		this.Label10.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label10.RightToLeft")));
		this.Label10.Size = ((System.Drawing.Size)(resources.GetObject("Label10.Size")));
		this.Label10.TabIndex = ((int)(resources.GetObject("Label10.TabIndex")));
		this.Label10.Text = resources.GetString("Label10.Text");
		this.Label10.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label10.TextAlign")));
		this.Label10.Visible = ((bool)(resources.GetObject("Label10.Visible")));
		// 
		// frmMain
		// 
		this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
		this.AccessibleName = resources.GetString("$this.AccessibleName");
		this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
		this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
		this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
		this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
		this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
		this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
		this.Controls.Add(this.cboGradientMode);
		this.Controls.Add(this.Label10);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.nudGradientBlend);
		this.Controls.Add(this.Label9);
		this.Controls.Add(this.nudRotation);
		this.Controls.Add(this.cboHatchStyle);
		this.Controls.Add(this.Label8);
		this.Controls.Add(this.sbrDrawingStatus);
		this.Controls.Add(this.cboWrapMode);
		this.Controls.Add(this.Label7);
		this.Controls.Add(this.cboBrushSize);
		this.Controls.Add(this.Label6);
		this.Controls.Add(this.btnSetColor2);
		this.Controls.Add(this.txtColor2);
		this.Controls.Add(this.txtColor1);
		this.Controls.Add(this.Label5);
		this.Controls.Add(this.cboDrawing);
		this.Controls.Add(this.Label4);
		this.Controls.Add(this.btnSetColor1);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.cboBrushType);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.picDemoArea);
		this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
		this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
		this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
		this.MaximizeBox = false;
		this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
		this.Menu = this.mnuMain;
		this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
		this.Name = "frmMain";
		this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
		this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
		this.Text = resources.GetString("$this.Text");
		this.Load += new System.EventHandler(this.frmMain_Load);
		((System.ComponentModel.ISupportInitialize)(this.nudRotation)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.nudGradientBlend)).EndInit();
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

    // This subroutine is used to set the m_Color1 value
    private void btnSetColor1_Click(object sender, System.EventArgs e) 
	{
        ColorDialog cdlg = new ColorDialog();
        if (cdlg.ShowDialog() == DialogResult.OK)
		{
		    m_Color1 = cdlg.Color;
            txtColor1.Text = cdlg.Color.ToString();
            txtColor1.BackColor = cdlg.Color;
        }
    }

    // This subroutine is used to set the m_Color2 value
    private void btnSetColor2_Click(object sender, System.EventArgs e) 
	{
        ColorDialog cdlg = new ColorDialog();
        if (cdlg.ShowDialog() == DialogResult.OK)
		{
            m_Color2 = cdlg.Color;
            txtColor2.Text = cdlg.Color.ToString();
            txtColor2.BackColor = cdlg.Color;
        }
    }

    // This subrouting changes the size of the brush used to draw in 
    //   the PictureBox by defining a new rectange. These rectangles could be
    //   any size, however, for demonstration simplicity, only three were
    //   defined.
    private void cboBrushSize_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        switch( cboBrushSize.Text)
		{
            case "Large":
                // "Large" takes up all of picDemoArea
                m_BrushSize = new Rectangle(0, 0,
                    picDemoArea.Width, picDemoArea.Height);
				break;
            case "Medium":
                // "Medium" breaks up picDemoArea into 4 pieces
                m_BrushSize = new Rectangle(0, 0,
                    picDemoArea.Width / 2, picDemoArea.Height / 2);
				break;
            case "Small":
                // "Small" breaks up picDemoArea into 16 pieces
                m_BrushSize = new Rectangle(0, 0, 
                    picDemoArea.Width / 4, picDemoArea.Height / 4);
				break;
        }
        // Call RedrawPicture
        RedrawPicture(cboBrushSize, new EventArgs());
    }

    // This subroutine ensures that the User interface is set up properly
    //   and sets some variables to their initial values.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
		int i;  //' Used for loops;
        // Set the brush size equal to the entire Picture Box area by defualt
        m_BrushSize = new Rectangle(0, 0, picDemoArea.Width, picDemoArea.Height);
        //Fill the combo boxes with appropriate values
        // Fill the cdoWrapMode combo box with the various WrapMode enum values
        cboWrapMode.Items.Add(WrapMode.Clamp);
        cboWrapMode.Items.Add(WrapMode.Tile);
        cboWrapMode.Items.Add(WrapMode.TileFlipX);
        cboWrapMode.Items.Add(WrapMode.TileFlipY);
        cboWrapMode.Items.Add(WrapMode.TileFlipXY);
		cboWrapMode.SelectedIndex = 0;

        // Fill the hatch style combo. We can loop though the enumeration
        //   and, since it is an enumeration, we can cast the integer used in
        //   the loop to the actual enumeration. (This is a very handy way
        //   of walking through an enumeration, long the enumerations are 
        //   consecutively numbered.)
        // The HatchStyle.Max value in .NET is incorrect. The actual value is 52.
        const int maxHatchStyle = 52;

        for (i = Convert.ToInt32(HatchStyle.Min); i <= maxHatchStyle; i++)
		{
            cboHatchStyle.Items.Add((HatchStyle) (i)) ;
        }
		cboHatchStyle.SelectedIndex = 0;

        // Fill the available GradientStyles
        cboGradientMode.Items.Add(LinearGradientMode.BackwardDiagonal);
        cboGradientMode.Items.Add(LinearGradientMode.ForwardDiagonal);
        cboGradientMode.Items.Add(LinearGradientMode.Horizontal);
        cboGradientMode.Items.Add(LinearGradientMode.Vertical);
		cboGradientMode.SelectedIndex = 0;
    }

    // This subroutine provides the meat of the demonstration. It creates one
    //   of 5 types of brushes, and assigns the appropriate user defined parameters
    //   to the brush. The brush is then assigned to m_Brush, which is used to 
    //   draw one of three different shapes.  There is also code to ensure that 
    //   the UI only displays the options that are appropriate for the type
    //   of brush being used.
    // Please note that this Error Handler handles virtually all of the events
    //   fired by the UI.
    private void RedrawPicture(object sender, System.EventArgs e)  //cboBrushType.SelectedIndexChanged, cboDrawing.SelectedIndexChanged, txtColor1.TextChanged, cboWrapMode.SelectedIndexChanged, cboHatchStyle.SelectedIndexChanged, txtColor2.TextChanged, cboGradientMode.SelectedIndexChanged, nudRotation.ValueChanged, nudGradientBlend.ValueChanged;
	{
        // Reset the PictureBox
        picDemoArea.CreateGraphics().Clear(Color.White);
        picDemoArea.Refresh();
        // Reset the Status Bar
        sbrDrawingStatus.Text = string.Empty;
        // Construct the brush with the user selected properties. One of five
        //   different brushes will be created based on the user selection.
        // The reason a brush of the specific type is created, and then assigned
        //   to m_Brush, is that Intellisense is available when working with 
        //   the specific brush objects.

        switch( cboBrushType.Text)
		{
            case "Solid": //' Use a SolidBrush;
                // Update the UI: deactivate and reactivate all the appropriate 
                //   controls for this brush
                this.cboBrushSize.Enabled = false;
                this.cboHatchStyle.Enabled = false;
                this.cboWrapMode.Enabled = false;
                this.txtColor2.Enabled = false;
                this.btnSetColor2.Enabled = false;
                this.nudGradientBlend.Enabled = false;
                this.nudRotation.Enabled = false;
                this.cboGradientMode.Enabled = false;
                // Create a solid brush based on selected color
                SolidBrush mySolidBrush = new SolidBrush(m_Color1);
                // Another good way to get a solid brush, if you know the color
                //   you want at design time is to use the Brushes class
                //   For instance, this line builds an AliceBlue brush
                // m_Brush = Brushes.AliceBlue
                // Set m_Brush equal to the newly created brush
                m_Brush = mySolidBrush;
				break;
            case "Hatch":  //' Use a HatchBrush;
                // Update the UI: deactivate and reactivate all the appropriate 
                //   controls for this brush
                this.cboBrushSize.Enabled = false;
                this.cboHatchStyle.Enabled = true;
                this.cboWrapMode.Enabled = false;
                this.txtColor2.Enabled = true;
                this.btnSetColor2.Enabled = true;
                this.nudGradientBlend.Enabled = false;
                this.nudRotation.Enabled = false;
                this.cboGradientMode.Enabled = false;
                // Create a new HatchBrush using the two colors for 
                //   foreground and background color settings.
                // Since the HatchStyle property is Read-Only the HatchStyle
                //   must be set at the creation of the HatchBrush
                HatchBrush myHatchBrush = new HatchBrush((HatchStyle) (cboHatchStyle.SelectedItem), m_Color1, m_Color2);
                // Set m_Brush equal to the newly created brush
                m_Brush = myHatchBrush;
				break;
            case "Texture":  //' Use a TextureBrush;
                // Update the UI: deactivate and reactivate all the appropriate 
                //   controls for this brush
                this.cboBrushSize.Enabled = true;
                this.cboHatchStyle.Enabled = false;
                this.cboWrapMode.Enabled = true;
                this.txtColor2.Enabled = false;
                this.btnSetColor2.Enabled = false;
                this.nudGradientBlend.Enabled = false;
                this.nudRotation.Enabled = true;
                this.cboGradientMode.Enabled = false;
                // Create a new TextureBrush based on a bitmap. This bitmap can
                //   also be a pattern that you have created. 
                // Be cautious here, since defining a Rectangle large that
                //   that the provided Bitmap will cause an OutOfMemory 
                //   exception to be thrown.

                TextureBrush myTextureBrush = new TextureBrush(
                    new Bitmap("..\\..\\waterlilies.jpg"), m_BrushSize);
                // The WrapMode determines how the brush will be tiled if it
                //   is not spread over the entire graphic area.
                myTextureBrush.WrapMode = (WrapMode) cboWrapMode.SelectedItem;
                // The RotateTransform method rotates the brush by the user
                //   specified amount
                myTextureBrush.RotateTransform(Convert.ToSingle(nudRotation.Value));
                // You can also use a ScaleTransform to deform the brush
                //   The following cuts the width of brush in half, and
                //   doubles the height.
                //myTextureBrush.ScaleTransform(0.5F, 2.0F)
                // Set m_Brush equal to the newly created brush
                m_Brush = myTextureBrush;
				break;
            case "LinearGradient": //' Use a LinearGradientBrush;
                // Update the UI: deactivate and reactivate all the appropriate 
                //   controls for this brush
                this.cboBrushSize.Enabled = true;
                this.cboHatchStyle.Enabled = false;
                this.cboWrapMode.Enabled = true;
                this.txtColor2.Enabled = true;
                this.btnSetColor2.Enabled = true;
                this.nudGradientBlend.Enabled = true;
                this.nudRotation.Enabled = true;
                this.cboGradientMode.Enabled = true;
                // Create a new LinearGradientBrush.  The brush is based on 
                //   a size defined by a rectangle, in this case using the
                //   user defined m_BrushSize. Two colors are used defining
                //   the start and end colors of the gradient. (More advanced 
                //   gradients can be built using the Blend property.)
                //   Finally, the LinearGradientMode is defined in the constructor.
                //   An angle can also be used, but for simplicity it is not here.
                LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush(
                    m_BrushSize, m_Color1, m_Color2,
                    (LinearGradientMode) cboGradientMode.SelectedItem);
                // The WrapMode determines how the brush will be tiled if it
                //   is not spread over the entire graphic area.
                // The LinearGradientBrush can! use the Clamp value for WrapMode

				if ((WrapMode) cboWrapMode.SelectedItem != WrapMode.Clamp )
				{
					myLinearGradientBrush.WrapMode = 
					(WrapMode) cboWrapMode.SelectedItem;
				}
				else 
				{
					this.sbrDrawingStatus.Text += 
					"A Linear Gradient Brush can! use the Clamp WrapMode.";
				}
                // The RotateTransform method rotates the brush by the user
                //   specified amount
                myLinearGradientBrush.RotateTransform(Convert.ToSingle(nudRotation.Value));
                // You can also use a ScaleTransform to deform the brush
                //   The following cuts the width of brush in half, and
                //   doubles the height.
                //myLinearGradientBrush.ScaleTransform(0.5F, 2.0F)
                // Set the point where the blending will focus.  Any single 
                // between 0 and 1 is allowed. The default is one.
                myLinearGradientBrush.SetBlendTriangularShape(Convert.ToSingle(nudGradientBlend.Value));
                // For more advanced uses, you can use the SetSigmaBellShape
                //   method to set where the center of the gradient occurs.
                //myLinearGradientBrush.SetSigmaBellShape(0.2)
                // Set m_Brush equal to the newly created brush
                m_Brush = myLinearGradientBrush;
				break;
            case "PathGradient":  //' Use a PathGradientBrush;
                // Update the UI: deactivate and reactivate all the appropriate 
                //   controls for this brush
                this.cboBrushSize.Enabled = true;
                this.cboHatchStyle.Enabled = false;
                this.cboWrapMode.Enabled = true;
                this.txtColor2.Enabled = true;
                this.btnSetColor2.Enabled = true;
                this.nudGradientBlend.Enabled = true;
                this.nudRotation.Enabled = true;
                this.cboGradientMode.Enabled = false;
                // Define a set of points to use for the path this gradient will
                //   follow. A GraphicsPath object could also be defined and used
                //   instead. In this case, we're using a simple triangle.
                Point[] pathPoint = {new Point(0, m_BrushSize.Height), 
                        new Point(m_BrushSize.Width, m_BrushSize.Height),
                        new Point(m_BrushSize.Width, 0)};
                // Create a new PathGradientBrush based on the path just created.
                //   (Anything not bounded by the path will be transparent, 
                //   instead of containing coloring.)
                PathGradientBrush myPathGradientBrush = new PathGradientBrush(pathPoint);
                // Set the Colors for the PathGradient, this is done differently
                //   from other gradients, since differnt colors can be used for 
                //   each side. In this case, only one color is used, but a color
                //   could be assigned to each side of the path.
                // The CenterColor is the color that the edges blend into.
                myPathGradientBrush.CenterColor = m_Color1;
                // The SurroundColors is an array of colors that defines the
                //   colors around the edge.
                myPathGradientBrush.SurroundColors = new Color[] {m_Color2};
                // For advanced uses, the CenterPoint property can be set 
                //   somewhere other that the center of the path (even outside 
                //   the rectangle bounding the path).
                //myPathGradientBrush.CenterPoint = new PointF(50, 50)
                // The WrapMode determines how the brush will be tiled if it
                //   is not spread over the entire graphic area.
                myPathGradientBrush.WrapMode = (WrapMode) cboWrapMode.SelectedItem;
                // The RotateTransform method rotates the brush by the user
                //   specified amount
                myPathGradientBrush.RotateTransform(Convert.ToSingle(nudRotation.Value));
                // You can also use a ScaleTransform to deform the brush
                //   The following cuts the width of brush in half, and
                //   doubles the height.
                //myPathGradientBrush.ScaleTransform(0.5F, 2.0F)
                // Set the blending
                myPathGradientBrush.SetBlendTriangularShape(Convert.ToSingle(nudGradientBlend.Value));
                // For more advanced uses, you can use the SetSigmaBellShape
                //   method to set where the center of the gradient occurs.
                //myPathGradientBrush.SetSigmaBellShape(0.2)
                // Set m_Brush equal to the newly created brush
                m_Brush = myPathGradientBrush;
				break;
        }
        // Use the brush to draw the appropriate Drawing in the picDemoArea
        myGraphics = picDemoArea.CreateGraphics();
        // Select the Type of drawing based on user input
        switch( cboDrawing.Text)
		{
            case "Fill":
                // "Fill" fills the entire PictureBox
                myGraphics.FillRectangle(m_Brush, 0, 0,
                    picDemoArea.Width, picDemoArea.Height);
				break;
            case "Ellipses":
                // "Ellipses" draws two intesecting ellipses
                myGraphics.FillEllipse(m_Brush, picDemoArea.Width / 10,
                    picDemoArea.Height / 10, picDemoArea.Width / 2,
                    picDemoArea.Height / 2);
                myGraphics.FillEllipse(m_Brush, picDemoArea.Width / 3,
                    picDemoArea.Height / 3, picDemoArea.Width / 2,
                    picDemoArea.Height / 2);
				break;
            case "Lines":
                // "Lines" draws a series of intersecting lines
                // First build a Pen based on the brush
                Pen myPen = new Pen(m_Brush, 40);
                // Now do the drawing from each corner to all other corners
                myGraphics.DrawLine(myPen, 0, 0, picDemoArea.Width, picDemoArea.Height);
                myGraphics.DrawLine(myPen, 0, 0, 0, picDemoArea.Height);
                myGraphics.DrawLine(myPen, 0, 0, picDemoArea.Width, 0);
                myGraphics.DrawLine(myPen, picDemoArea.Width, 0, picDemoArea.Width, picDemoArea.Height);
                myGraphics.DrawLine(myPen, 0, picDemoArea.Height, picDemoArea.Width, picDemoArea.Height);
                myGraphics.DrawLine(myPen, picDemoArea.Width, 0, 0, picDemoArea.Height);
				break;
        }
        // Set the Drawing Status to Success if there weren't any other problems
        if (this.sbrDrawingStatus.Text == "") 
		{
            this.sbrDrawingStatus.Text = "Success!";
        }
    }
}

