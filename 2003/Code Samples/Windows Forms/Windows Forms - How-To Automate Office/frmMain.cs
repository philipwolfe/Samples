//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;

public class frmMain: System.Windows.Forms.Form {

	static object missing = Missing.Value;

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		System.Windows.Forms.Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

    public frmMain () {

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
    private System.Windows.Forms.Button btnSpeak;
    private System.Windows.Forms.GroupBox GroupBox1;
    private System.Windows.Forms.OpenFileDialog dlgOpenWordFile;
    private System.Windows.Forms.Button btnBrowseWord;
    private System.Windows.Forms.Button btnSpellCheck;
    private System.Windows.Forms.Button btnGetMenu;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.TabControl tabOfficeDemo;
    private System.Windows.Forms.RadioButton optDontRecognize;
    private System.Windows.Forms.RadioButton optWrite;
    private System.Windows.Forms.RadioButton optWave;
    private System.Windows.Forms.RadioButton optApplaud;
    private System.Windows.Forms.RadioButton optSurprised;
    private System.Windows.Forms.RadioButton optSuggest;
    private System.Windows.Forms.RadioButton optAnnounce;
    private System.Windows.Forms.RadioButton optDoMagic;
    private System.Windows.Forms.RadioButton optExplain;
    private System.Windows.Forms.RadioButton optCongrats;
    private System.Windows.Forms.TextBox txtSpeak;
    private System.Windows.Forms.CheckBox chkMerlinHide;
    private System.Windows.Forms.RichTextBox rtfDocument;
    private System.Windows.Forms.DataGrid grdMenu;
    private System.Windows.Forms.TabPage pgeWizard;
    private System.Windows.Forms.TabPage pgeWord;
    private System.Windows.Forms.TabPage pgeExcel;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.tabOfficeDemo = new System.Windows.Forms.TabControl();

        this.pgeWizard = new System.Windows.Forms.TabPage();

        this.GroupBox1 = new System.Windows.Forms.GroupBox();

        this.optDontRecognize = new System.Windows.Forms.RadioButton();

        this.optWrite = new System.Windows.Forms.RadioButton();

        this.optWave = new System.Windows.Forms.RadioButton();

        this.optApplaud = new System.Windows.Forms.RadioButton();

        this.optSurprised = new System.Windows.Forms.RadioButton();

        this.optSuggest = new System.Windows.Forms.RadioButton();

        this.optAnnounce = new System.Windows.Forms.RadioButton();

        this.optDoMagic = new System.Windows.Forms.RadioButton();

        this.optExplain = new System.Windows.Forms.RadioButton();

        this.optCongrats = new System.Windows.Forms.RadioButton();

        this.btnSpeak = new System.Windows.Forms.Button();

        this.txtSpeak = new System.Windows.Forms.TextBox();

        this.Label2 = new System.Windows.Forms.Label();

        this.pgeWord = new System.Windows.Forms.TabPage();

        this.btnSpellCheck = new System.Windows.Forms.Button();

        this.rtfDocument = new System.Windows.Forms.RichTextBox();

        this.btnBrowseWord = new System.Windows.Forms.Button();

        this.pgeExcel = new System.Windows.Forms.TabPage();

        this.btnExport = new System.Windows.Forms.Button();

        this.btnGetMenu = new System.Windows.Forms.Button();

        this.grdMenu = new System.Windows.Forms.DataGrid();

        this.Label1 = new System.Windows.Forms.Label();

        this.dlgOpenWordFile = new System.Windows.Forms.OpenFileDialog();

        this.chkMerlinHide = new System.Windows.Forms.CheckBox();

        this.tabOfficeDemo.SuspendLayout();

        this.pgeWizard.SuspendLayout();

        this.GroupBox1.SuspendLayout();

        this.pgeWord.SuspendLayout();

        this.pgeExcel.SuspendLayout();

        ((System.ComponentModel.ISupportInitialize)(this.grdMenu)).BeginInit() ;

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

        //tabOfficeDemo

        //

        this.tabOfficeDemo.AccessibleDescription = (string) resources.GetObject("tabOfficeDemo.AccessibleDescription");

        this.tabOfficeDemo.AccessibleName = (string) resources.GetObject("tabOfficeDemo.AccessibleName");

        this.tabOfficeDemo.Alignment = (System.Windows.Forms.TabAlignment) resources.GetObject("tabOfficeDemo.Alignment");

        this.tabOfficeDemo.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tabOfficeDemo.Anchor");

        this.tabOfficeDemo.Appearance = (System.Windows.Forms.TabAppearance) resources.GetObject("tabOfficeDemo.Appearance");

        this.tabOfficeDemo.BackgroundImage = (System.Drawing.Image) resources.GetObject("tabOfficeDemo.BackgroundImage");

        this.tabOfficeDemo.Controls.AddRange(new System.Windows.Forms.Control[] {this.pgeWizard, this.pgeWord, this.pgeExcel});

        this.tabOfficeDemo.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tabOfficeDemo.Dock");

        this.tabOfficeDemo.Enabled = (bool) resources.GetObject("tabOfficeDemo.Enabled");

        this.tabOfficeDemo.Font = (System.Drawing.Font) resources.GetObject("tabOfficeDemo.Font");

        this.tabOfficeDemo.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tabOfficeDemo.ImeMode");

        this.tabOfficeDemo.ItemSize = (System.Drawing.Size) resources.GetObject("tabOfficeDemo.ItemSize");

        this.tabOfficeDemo.Location = (System.Drawing.Point) resources.GetObject("tabOfficeDemo.Location");

        this.tabOfficeDemo.Name = "tabOfficeDemo";

        this.tabOfficeDemo.Padding = (System.Drawing.Point) resources.GetObject("tabOfficeDemo.Padding");

        this.tabOfficeDemo.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tabOfficeDemo.RightToLeft");

        this.tabOfficeDemo.SelectedIndex = 0;

        this.tabOfficeDemo.ShowToolTips = (bool) resources.GetObject("tabOfficeDemo.ShowToolTips");

        this.tabOfficeDemo.Size = (System.Drawing.Size) resources.GetObject("tabOfficeDemo.Size");

        this.tabOfficeDemo.TabIndex = (int) resources.GetObject("tabOfficeDemo.TabIndex");

        this.tabOfficeDemo.Text = resources.GetString("tabOfficeDemo.Text");

        this.tabOfficeDemo.Visible = (bool) resources.GetObject("tabOfficeDemo.Visible");

        //

        //pgeWizard

        //

        this.pgeWizard.AccessibleDescription = resources.GetString("pgeWizard.AccessibleDescription");

        this.pgeWizard.AccessibleName = resources.GetString("pgeWizard.AccessibleName");

        this.pgeWizard.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeWizard.Anchor");

        this.pgeWizard.AutoScroll = (bool) resources.GetObject("pgeWizard.AutoScroll");

        this.pgeWizard.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeWizard.AutoScrollMargin");

        this.pgeWizard.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeWizard.AutoScrollMinSize");

        this.pgeWizard.BackColor = System.Drawing.SystemColors.Control;

        this.pgeWizard.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeWizard.BackgroundImage");

        this.pgeWizard.Controls.AddRange(new System.Windows.Forms.Control[] {this.GroupBox1, this.btnSpeak, this.txtSpeak, this.Label2});

        this.pgeWizard.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeWizard.Dock");

        this.pgeWizard.Enabled = (bool) resources.GetObject("pgeWizard.Enabled");

        this.pgeWizard.Font = (System.Drawing.Font) resources.GetObject("pgeWizard.Font");

        this.pgeWizard.ImageIndex = (int) resources.GetObject("pgeWizard.ImageIndex");

        this.pgeWizard.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeWizard.ImeMode");

        this.pgeWizard.Location = (System.Drawing.Point) resources.GetObject("pgeWizard.Location");

        this.pgeWizard.Name = "pgeWizard";

        this.pgeWizard.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeWizard.RightToLeft");

        this.pgeWizard.Size = (System.Drawing.Size) resources.GetObject("pgeWizard.Size");

        this.pgeWizard.TabIndex = (int) resources.GetObject("pgeWizard.TabIndex");

        this.pgeWizard.Text = resources.GetString("pgeWizard.Text");

        this.pgeWizard.ToolTipText = resources.GetString("pgeWizard.ToolTipText");

        this.pgeWizard.Visible = (bool) resources.GetObject("pgeWizard.Visible");

        //

        //GroupBox1

        //

        this.GroupBox1.AccessibleDescription = resources.GetString("GroupBox1.AccessibleDescription");

        this.GroupBox1.AccessibleName = resources.GetString("GroupBox1.AccessibleName");

        this.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("GroupBox1.Anchor");

        this.GroupBox1.BackgroundImage = (System.Drawing.Image) resources.GetObject("GroupBox1.BackgroundImage");

        this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.optDontRecognize, this.optWrite, this.optWave, this.optApplaud, this.optSurprised, this.optSuggest, this.optAnnounce, this.optDoMagic, this.optExplain, this.optCongrats});

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

        //optDontRecognize

        //

        this.optDontRecognize.AccessibleDescription = resources.GetString("optDontRecognize.AccessibleDescription");

        this.optDontRecognize.AccessibleName = resources.GetString("optDontRecognize.AccessibleName");

        this.optDontRecognize.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optDontRecognize.Anchor");

        this.optDontRecognize.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optDontRecognize.Appearance");

        this.optDontRecognize.BackgroundImage = (System.Drawing.Image) resources.GetObject("optDontRecognize.BackgroundImage");

        this.optDontRecognize.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optDontRecognize.CheckAlign");

        this.optDontRecognize.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optDontRecognize.Dock");

        this.optDontRecognize.Enabled = (bool) resources.GetObject("optDontRecognize.Enabled");

        this.optDontRecognize.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optDontRecognize.FlatStyle");

        this.optDontRecognize.Font = (System.Drawing.Font) resources.GetObject("optDontRecognize.Font");

        this.optDontRecognize.Image = (System.Drawing.Image) resources.GetObject("optDontRecognize.Image");

        this.optDontRecognize.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optDontRecognize.ImageAlign");

        this.optDontRecognize.ImageIndex = (int) resources.GetObject("optDontRecognize.ImageIndex");

        this.optDontRecognize.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optDontRecognize.ImeMode");

        this.optDontRecognize.Location = (System.Drawing.Point) resources.GetObject("optDontRecognize.Location");

        this.optDontRecognize.Name = "optDontRecognize";

        this.optDontRecognize.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optDontRecognize.RightToLeft");

        this.optDontRecognize.Size = (System.Drawing.Size) resources.GetObject("optDontRecognize.Size");

        this.optDontRecognize.TabIndex = (int) resources.GetObject("optDontRecognize.TabIndex");

        this.optDontRecognize.Tag = "DontRecognize";

        this.optDontRecognize.Text = resources.GetString("optDontRecognize.Text");

        this.optDontRecognize.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optDontRecognize.TextAlign");

        this.optDontRecognize.Visible = (bool) resources.GetObject("optDontRecognize.Visible");

        //

        //optWrite

        //

        this.optWrite.AccessibleDescription = resources.GetString("optWrite.AccessibleDescription");

        this.optWrite.AccessibleName = resources.GetString("optWrite.AccessibleName");

        this.optWrite.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optWrite.Anchor");

        this.optWrite.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optWrite.Appearance");

        this.optWrite.BackgroundImage = (System.Drawing.Image) resources.GetObject("optWrite.BackgroundImage");

        this.optWrite.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optWrite.CheckAlign");

        this.optWrite.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optWrite.Dock");

        this.optWrite.Enabled = (bool) resources.GetObject("optWrite.Enabled");

        this.optWrite.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optWrite.FlatStyle");

        this.optWrite.Font = (System.Drawing.Font) resources.GetObject("optWrite.Font");

        this.optWrite.Image = (System.Drawing.Image) resources.GetObject("optWrite.Image");

        this.optWrite.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optWrite.ImageAlign");

        this.optWrite.ImageIndex = (int) resources.GetObject("optWrite.ImageIndex");

        this.optWrite.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optWrite.ImeMode");

        this.optWrite.Location = (System.Drawing.Point) resources.GetObject("optWrite.Location");

        this.optWrite.Name = "optWrite";

        this.optWrite.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optWrite.RightToLeft");

        this.optWrite.Size = (System.Drawing.Size) resources.GetObject("optWrite.Size");

        this.optWrite.TabIndex = (int) resources.GetObject("optWrite.TabIndex");

        this.optWrite.Tag = "Write";

        this.optWrite.Text = resources.GetString("optWrite.Text");

        this.optWrite.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optWrite.TextAlign");

        this.optWrite.Visible = (bool) resources.GetObject("optWrite.Visible");

        //

        //optWave

        //

        this.optWave.AccessibleDescription = resources.GetString("optWave.AccessibleDescription");

        this.optWave.AccessibleName = resources.GetString("optWave.AccessibleName");

        this.optWave.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optWave.Anchor");

        this.optWave.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optWave.Appearance");

        this.optWave.BackgroundImage = (System.Drawing.Image) resources.GetObject("optWave.BackgroundImage");

        this.optWave.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optWave.CheckAlign");

        this.optWave.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optWave.Dock");

        this.optWave.Enabled = (bool) resources.GetObject("optWave.Enabled");

        this.optWave.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optWave.FlatStyle");

        this.optWave.Font = (System.Drawing.Font) resources.GetObject("optWave.Font");

        this.optWave.Image = (System.Drawing.Image) resources.GetObject("optWave.Image");

        this.optWave.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optWave.ImageAlign");

        this.optWave.ImageIndex = (int) resources.GetObject("optWave.ImageIndex");

        this.optWave.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optWave.ImeMode");

        this.optWave.Location = (System.Drawing.Point) resources.GetObject("optWave.Location");

        this.optWave.Name = "optWave";

        this.optWave.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optWave.RightToLeft");

        this.optWave.Size = (System.Drawing.Size) resources.GetObject("optWave.Size");

        this.optWave.TabIndex = (int) resources.GetObject("optWave.TabIndex");

        this.optWave.Tag = "Wave";

        this.optWave.Text = resources.GetString("optWave.Text");

        this.optWave.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optWave.TextAlign");

        this.optWave.Visible = (bool) resources.GetObject("optWave.Visible");

        //

        //optApplaud

        //

        this.optApplaud.AccessibleDescription = resources.GetString("optApplaud.AccessibleDescription");

        this.optApplaud.AccessibleName = resources.GetString("optApplaud.AccessibleName");

        this.optApplaud.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optApplaud.Anchor");

        this.optApplaud.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optApplaud.Appearance");

        this.optApplaud.BackgroundImage = (System.Drawing.Image) resources.GetObject("optApplaud.BackgroundImage");

        this.optApplaud.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optApplaud.CheckAlign");

        this.optApplaud.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optApplaud.Dock");

        this.optApplaud.Enabled = (bool) resources.GetObject("optApplaud.Enabled");

        this.optApplaud.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optApplaud.FlatStyle");

        this.optApplaud.Font = (System.Drawing.Font) resources.GetObject("optApplaud.Font");

        this.optApplaud.Image = (System.Drawing.Image) resources.GetObject("optApplaud.Image");

        this.optApplaud.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optApplaud.ImageAlign");

        this.optApplaud.ImageIndex = (int) resources.GetObject("optApplaud.ImageIndex");

        this.optApplaud.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optApplaud.ImeMode");

        this.optApplaud.Location = (System.Drawing.Point) resources.GetObject("optApplaud.Location");

        this.optApplaud.Name = "optApplaud";

        this.optApplaud.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optApplaud.RightToLeft");

        this.optApplaud.Size = (System.Drawing.Size) resources.GetObject("optApplaud.Size");

        this.optApplaud.TabIndex = (int) resources.GetObject("optApplaud.TabIndex");

        this.optApplaud.Tag = "Applaud";

        this.optApplaud.Text = resources.GetString("optApplaud.Text");

        this.optApplaud.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optApplaud.TextAlign");

        this.optApplaud.Visible = (bool) resources.GetObject("optApplaud.Visible");

        //

        //optSurprised

        //

        this.optSurprised.AccessibleDescription = resources.GetString("optSurprised.AccessibleDescription");

        this.optSurprised.AccessibleName = resources.GetString("optSurprised.AccessibleName");

        this.optSurprised.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optSurprised.Anchor");

        this.optSurprised.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optSurprised.Appearance");

        this.optSurprised.BackgroundImage = (System.Drawing.Image) resources.GetObject("optSurprised.BackgroundImage");

        this.optSurprised.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSurprised.CheckAlign");

        this.optSurprised.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optSurprised.Dock");

        this.optSurprised.Enabled = (bool) resources.GetObject("optSurprised.Enabled");

        this.optSurprised.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optSurprised.FlatStyle");

        this.optSurprised.Font = (System.Drawing.Font) resources.GetObject("optSurprised.Font");

        this.optSurprised.Image = (System.Drawing.Image) resources.GetObject("optSurprised.Image");

        this.optSurprised.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSurprised.ImageAlign");

        this.optSurprised.ImageIndex = (int) resources.GetObject("optSurprised.ImageIndex");

        this.optSurprised.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optSurprised.ImeMode");

        this.optSurprised.Location = (System.Drawing.Point) resources.GetObject("optSurprised.Location");

        this.optSurprised.Name = "optSurprised";

        this.optSurprised.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optSurprised.RightToLeft");

        this.optSurprised.Size = (System.Drawing.Size) resources.GetObject("optSurprised.Size");

        this.optSurprised.TabIndex = (int) resources.GetObject("optSurprised.TabIndex");

        this.optSurprised.Tag = "Surprised";

        this.optSurprised.Text = resources.GetString("optSurprised.Text");

        this.optSurprised.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSurprised.TextAlign");

        this.optSurprised.Visible = (bool) resources.GetObject("optSurprised.Visible");

        //

        //optSuggest

        //

        this.optSuggest.AccessibleDescription = resources.GetString("optSuggest.AccessibleDescription");

        this.optSuggest.AccessibleName = resources.GetString("optSuggest.AccessibleName");

        this.optSuggest.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optSuggest.Anchor");

        this.optSuggest.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optSuggest.Appearance");

        this.optSuggest.BackgroundImage = (System.Drawing.Image) resources.GetObject("optSuggest.BackgroundImage");

        this.optSuggest.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSuggest.CheckAlign");

        this.optSuggest.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optSuggest.Dock");

        this.optSuggest.Enabled = (bool) resources.GetObject("optSuggest.Enabled");

        this.optSuggest.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optSuggest.FlatStyle");

        this.optSuggest.Font = (System.Drawing.Font) resources.GetObject("optSuggest.Font");

        this.optSuggest.Image = (System.Drawing.Image) resources.GetObject("optSuggest.Image");

        this.optSuggest.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSuggest.ImageAlign");

        this.optSuggest.ImageIndex = (int) resources.GetObject("optSuggest.ImageIndex");

        this.optSuggest.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optSuggest.ImeMode");

        this.optSuggest.Location = (System.Drawing.Point) resources.GetObject("optSuggest.Location");

        this.optSuggest.Name = "optSuggest";

        this.optSuggest.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optSuggest.RightToLeft");

        this.optSuggest.Size = (System.Drawing.Size) resources.GetObject("optSuggest.Size");

        this.optSuggest.TabIndex = (int) resources.GetObject("optSuggest.TabIndex");

        this.optSuggest.Tag = "Suggest";

        this.optSuggest.Text = resources.GetString("optSuggest.Text");

        this.optSuggest.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSuggest.TextAlign");

        this.optSuggest.Visible = (bool) resources.GetObject("optSuggest.Visible");

        //

        //optAnnounce

        //

        this.optAnnounce.AccessibleDescription = resources.GetString("optAnnounce.AccessibleDescription");

        this.optAnnounce.AccessibleName = resources.GetString("optAnnounce.AccessibleName");

        this.optAnnounce.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optAnnounce.Anchor");

        this.optAnnounce.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optAnnounce.Appearance");

        this.optAnnounce.BackgroundImage = (System.Drawing.Image) resources.GetObject("optAnnounce.BackgroundImage");

        this.optAnnounce.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optAnnounce.CheckAlign");

        this.optAnnounce.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optAnnounce.Dock");

        this.optAnnounce.Enabled = (bool) resources.GetObject("optAnnounce.Enabled");

        this.optAnnounce.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optAnnounce.FlatStyle");

        this.optAnnounce.Font = (System.Drawing.Font) resources.GetObject("optAnnounce.Font");

        this.optAnnounce.Image = (System.Drawing.Image) resources.GetObject("optAnnounce.Image");

        this.optAnnounce.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optAnnounce.ImageAlign");

        this.optAnnounce.ImageIndex = (int) resources.GetObject("optAnnounce.ImageIndex");

        this.optAnnounce.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optAnnounce.ImeMode");

        this.optAnnounce.Location = (System.Drawing.Point) resources.GetObject("optAnnounce.Location");

        this.optAnnounce.Name = "optAnnounce";

        this.optAnnounce.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optAnnounce.RightToLeft");

        this.optAnnounce.Size = (System.Drawing.Size) resources.GetObject("optAnnounce.Size");

        this.optAnnounce.TabIndex = (int) resources.GetObject("optAnnounce.TabIndex");

        this.optAnnounce.Tag = "Announce";

        this.optAnnounce.Text = resources.GetString("optAnnounce.Text");

        this.optAnnounce.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optAnnounce.TextAlign");

        this.optAnnounce.Visible = (bool) resources.GetObject("optAnnounce.Visible");

        //

        //optDoMagic

        //

        this.optDoMagic.AccessibleDescription = resources.GetString("optDoMagic.AccessibleDescription");

        this.optDoMagic.AccessibleName = resources.GetString("optDoMagic.AccessibleName");

        this.optDoMagic.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optDoMagic.Anchor");

        this.optDoMagic.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optDoMagic.Appearance");

        this.optDoMagic.BackgroundImage = (System.Drawing.Image) resources.GetObject("optDoMagic.BackgroundImage");

        this.optDoMagic.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optDoMagic.CheckAlign");

        this.optDoMagic.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optDoMagic.Dock");

        this.optDoMagic.Enabled = (bool) resources.GetObject("optDoMagic.Enabled");

        this.optDoMagic.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optDoMagic.FlatStyle");

        this.optDoMagic.Font = (System.Drawing.Font) resources.GetObject("optDoMagic.Font");

        this.optDoMagic.Image = (System.Drawing.Image) resources.GetObject("optDoMagic.Image");

        this.optDoMagic.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optDoMagic.ImageAlign");

        this.optDoMagic.ImageIndex = (int) resources.GetObject("optDoMagic.ImageIndex");

        this.optDoMagic.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optDoMagic.ImeMode");

        this.optDoMagic.Location = (System.Drawing.Point) resources.GetObject("optDoMagic.Location");

        this.optDoMagic.Name = "optDoMagic";

        this.optDoMagic.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optDoMagic.RightToLeft");

        this.optDoMagic.Size = (System.Drawing.Size) resources.GetObject("optDoMagic.Size");

        this.optDoMagic.TabIndex = (int) resources.GetObject("optDoMagic.TabIndex");

        this.optDoMagic.Tag = "GetAttention";

        this.optDoMagic.Text = resources.GetString("optDoMagic.Text");

        this.optDoMagic.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optDoMagic.TextAlign");

        this.optDoMagic.Visible = (bool) resources.GetObject("optDoMagic.Visible");

        //

        //optExplain

        //

        this.optExplain.AccessibleDescription = resources.GetString("optExplain.AccessibleDescription");

        this.optExplain.AccessibleName = resources.GetString("optExplain.AccessibleName");

        this.optExplain.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optExplain.Anchor");

        this.optExplain.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optExplain.Appearance");

        this.optExplain.BackgroundImage = (System.Drawing.Image) resources.GetObject("optExplain.BackgroundImage");

        this.optExplain.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optExplain.CheckAlign");

        this.optExplain.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optExplain.Dock");

        this.optExplain.Enabled = (bool) resources.GetObject("optExplain.Enabled");

        this.optExplain.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optExplain.FlatStyle");

        this.optExplain.Font = (System.Drawing.Font) resources.GetObject("optExplain.Font");

        this.optExplain.Image = (System.Drawing.Image) resources.GetObject("optExplain.Image");

        this.optExplain.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optExplain.ImageAlign");

        this.optExplain.ImageIndex = (int) resources.GetObject("optExplain.ImageIndex");

        this.optExplain.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optExplain.ImeMode");

        this.optExplain.Location = (System.Drawing.Point) resources.GetObject("optExplain.Location");

        this.optExplain.Name = "optExplain";

        this.optExplain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optExplain.RightToLeft");

        this.optExplain.Size = (System.Drawing.Size) resources.GetObject("optExplain.Size");

        this.optExplain.TabIndex = (int) resources.GetObject("optExplain.TabIndex");

        this.optExplain.Tag = "Explain";

        this.optExplain.Text = resources.GetString("optExplain.Text");

        this.optExplain.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optExplain.TextAlign");

        this.optExplain.Visible = (bool) resources.GetObject("optExplain.Visible");

        //

        //optCongrats

        //

        this.optCongrats.AccessibleDescription = resources.GetString("optCongrats.AccessibleDescription");

        this.optCongrats.AccessibleName = resources.GetString("optCongrats.AccessibleName");

        this.optCongrats.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optCongrats.Anchor");

        this.optCongrats.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optCongrats.Appearance");

        this.optCongrats.BackgroundImage = (System.Drawing.Image) resources.GetObject("optCongrats.BackgroundImage");

        this.optCongrats.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCongrats.CheckAlign");

        this.optCongrats.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optCongrats.Dock");

        this.optCongrats.Enabled = (bool) resources.GetObject("optCongrats.Enabled");

        this.optCongrats.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optCongrats.FlatStyle");

        this.optCongrats.Font = (System.Drawing.Font) resources.GetObject("optCongrats.Font");

        this.optCongrats.Image = (System.Drawing.Image) resources.GetObject("optCongrats.Image");

        this.optCongrats.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCongrats.ImageAlign");

        this.optCongrats.ImageIndex = (int) resources.GetObject("optCongrats.ImageIndex");

        this.optCongrats.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optCongrats.ImeMode");

        this.optCongrats.Location = (System.Drawing.Point) resources.GetObject("optCongrats.Location");

        this.optCongrats.Name = "optCongrats";

        this.optCongrats.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optCongrats.RightToLeft");

        this.optCongrats.Size = (System.Drawing.Size) resources.GetObject("optCongrats.Size");

        this.optCongrats.TabIndex = (int) resources.GetObject("optCongrats.TabIndex");

        this.optCongrats.Tag = "Congratulate";

        this.optCongrats.Text = resources.GetString("optCongrats.Text");

        this.optCongrats.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCongrats.TextAlign");

        this.optCongrats.Visible = (bool) resources.GetObject("optCongrats.Visible");

        //

        //btnSpeak

        //

        this.btnSpeak.AccessibleDescription = resources.GetString("btnSpeak.AccessibleDescription");

        this.btnSpeak.AccessibleName = resources.GetString("btnSpeak.AccessibleName");

        this.btnSpeak.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSpeak.Anchor");

        this.btnSpeak.BackColor = System.Drawing.SystemColors.Control;

        this.btnSpeak.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSpeak.BackgroundImage");

        this.btnSpeak.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSpeak.Dock");

        this.btnSpeak.Enabled = (bool) resources.GetObject("btnSpeak.Enabled");

        this.btnSpeak.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSpeak.FlatStyle");

        this.btnSpeak.Font = (System.Drawing.Font) resources.GetObject("btnSpeak.Font");

        this.btnSpeak.Image = (System.Drawing.Image) resources.GetObject("btnSpeak.Image");

        this.btnSpeak.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSpeak.ImageAlign");

        this.btnSpeak.ImageIndex = (int) resources.GetObject("btnSpeak.ImageIndex");

        this.btnSpeak.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSpeak.ImeMode");

        this.btnSpeak.Location = (System.Drawing.Point) resources.GetObject("btnSpeak.Location");

        this.btnSpeak.Name = "btnSpeak";

        this.btnSpeak.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSpeak.RightToLeft");

        this.btnSpeak.Size = (System.Drawing.Size) resources.GetObject("btnSpeak.Size");

        this.btnSpeak.TabIndex = (int) resources.GetObject("btnSpeak.TabIndex");

        this.btnSpeak.Text = resources.GetString("btnSpeak.Text");

        this.btnSpeak.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSpeak.TextAlign");

        this.btnSpeak.Visible = (bool) resources.GetObject("btnSpeak.Visible");

        //

        //txtSpeak

        //

        this.txtSpeak.AccessibleDescription = resources.GetString("txtSpeak.AccessibleDescription");

        this.txtSpeak.AccessibleName = resources.GetString("txtSpeak.AccessibleName");

        this.txtSpeak.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtSpeak.Anchor");

        this.txtSpeak.AutoSize = (bool) resources.GetObject("txtSpeak.AutoSize");

        this.txtSpeak.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtSpeak.BackgroundImage");

        this.txtSpeak.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtSpeak.Dock");

        this.txtSpeak.Enabled = (bool) resources.GetObject("txtSpeak.Enabled");

        this.txtSpeak.Font = (System.Drawing.Font) resources.GetObject("txtSpeak.Font");

        this.txtSpeak.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtSpeak.ImeMode");

        this.txtSpeak.Location = (System.Drawing.Point) resources.GetObject("txtSpeak.Location");

        this.txtSpeak.MaxLength = (int) resources.GetObject("txtSpeak.MaxLength");

        this.txtSpeak.Multiline = (bool) resources.GetObject("txtSpeak.Multiline");

        this.txtSpeak.Name = "txtSpeak";

        this.txtSpeak.PasswordChar = (char) resources.GetObject("txtSpeak.PasswordChar");

        this.txtSpeak.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtSpeak.RightToLeft");

        this.txtSpeak.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtSpeak.ScrollBars");

        this.txtSpeak.Size = (System.Drawing.Size) resources.GetObject("txtSpeak.Size");

        this.txtSpeak.TabIndex = (int) resources.GetObject("txtSpeak.TabIndex");

        this.txtSpeak.Text = resources.GetString("txtSpeak.Text");

        this.txtSpeak.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtSpeak.TextAlign");

        this.txtSpeak.Visible = (bool) resources.GetObject("txtSpeak.Visible");

        this.txtSpeak.WordWrap = (bool) resources.GetObject("txtSpeak.WordWrap");

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

        this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;

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

        //pgeWord

        //

        this.pgeWord.AccessibleDescription = resources.GetString("pgeWord.AccessibleDescription");

        this.pgeWord.AccessibleName = resources.GetString("pgeWord.AccessibleName");

        this.pgeWord.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeWord.Anchor");

        this.pgeWord.AutoScroll = (bool) resources.GetObject("pgeWord.AutoScroll");

        this.pgeWord.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeWord.AutoScrollMargin");

        this.pgeWord.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeWord.AutoScrollMinSize");

        this.pgeWord.BackColor = System.Drawing.SystemColors.Control;

        this.pgeWord.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeWord.BackgroundImage");

        this.pgeWord.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnSpellCheck, this.rtfDocument, this.btnBrowseWord});

        this.pgeWord.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeWord.Dock");

        this.pgeWord.Enabled = (bool) resources.GetObject("pgeWord.Enabled");

        this.pgeWord.Font = (System.Drawing.Font) resources.GetObject("pgeWord.Font");

        this.pgeWord.ImageIndex = (int) resources.GetObject("pgeWord.ImageIndex");

        this.pgeWord.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeWord.ImeMode");

        this.pgeWord.Location = (System.Drawing.Point) resources.GetObject("pgeWord.Location");

        this.pgeWord.Name = "pgeWord";

        this.pgeWord.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeWord.RightToLeft");

        this.pgeWord.Size = (System.Drawing.Size) resources.GetObject("pgeWord.Size");

        this.pgeWord.TabIndex = (int) resources.GetObject("pgeWord.TabIndex");

        this.pgeWord.Text = resources.GetString("pgeWord.Text");

        this.pgeWord.ToolTipText = resources.GetString("pgeWord.ToolTipText");

        this.pgeWord.Visible = (bool) resources.GetObject("pgeWord.Visible");

        //

        //btnSpellCheck

        //

        this.btnSpellCheck.AccessibleDescription = resources.GetString("btnSpellCheck.AccessibleDescription");

        this.btnSpellCheck.AccessibleName = resources.GetString("btnSpellCheck.AccessibleName");

        this.btnSpellCheck.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSpellCheck.Anchor");

        this.btnSpellCheck.BackColor = System.Drawing.SystemColors.Control;

        this.btnSpellCheck.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSpellCheck.BackgroundImage");

        this.btnSpellCheck.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSpellCheck.Dock");

        this.btnSpellCheck.Enabled = (bool) resources.GetObject("btnSpellCheck.Enabled");

        this.btnSpellCheck.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSpellCheck.FlatStyle");

        this.btnSpellCheck.Font = (System.Drawing.Font) resources.GetObject("btnSpellCheck.Font");

        this.btnSpellCheck.Image = (System.Drawing.Image) resources.GetObject("btnSpellCheck.Image");

        this.btnSpellCheck.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSpellCheck.ImageAlign");

        this.btnSpellCheck.ImageIndex = (int) resources.GetObject("btnSpellCheck.ImageIndex");

        this.btnSpellCheck.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSpellCheck.ImeMode");

        this.btnSpellCheck.Location = (System.Drawing.Point) resources.GetObject("btnSpellCheck.Location");

        this.btnSpellCheck.Name = "btnSpellCheck";

        this.btnSpellCheck.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSpellCheck.RightToLeft");

        this.btnSpellCheck.Size = (System.Drawing.Size) resources.GetObject("btnSpellCheck.Size");

        this.btnSpellCheck.TabIndex = (int) resources.GetObject("btnSpellCheck.TabIndex");

        this.btnSpellCheck.Text = resources.GetString("btnSpellCheck.Text");

        this.btnSpellCheck.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSpellCheck.TextAlign");

        this.btnSpellCheck.Visible = (bool) resources.GetObject("btnSpellCheck.Visible");

        //

        //rtfDocument

        //

        this.rtfDocument.AccessibleDescription = resources.GetString("rtfDocument.AccessibleDescription");

        this.rtfDocument.AccessibleName = resources.GetString("rtfDocument.AccessibleName");

        this.rtfDocument.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rtfDocument.Anchor");

        this.rtfDocument.AutoSize = (bool) resources.GetObject("rtfDocument.AutoSize");

        this.rtfDocument.BackgroundImage = (System.Drawing.Image) resources.GetObject("rtfDocument.BackgroundImage");

        this.rtfDocument.BulletIndent = (int) resources.GetObject("rtfDocument.BulletIndent");

        this.rtfDocument.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rtfDocument.Dock");

        this.rtfDocument.Enabled = (bool) resources.GetObject("rtfDocument.Enabled");

        this.rtfDocument.Font = (System.Drawing.Font) resources.GetObject("rtfDocument.Font");

        this.rtfDocument.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rtfDocument.ImeMode");

        this.rtfDocument.Location = (System.Drawing.Point) resources.GetObject("rtfDocument.Location");

        this.rtfDocument.MaxLength = (int) resources.GetObject("rtfDocument.MaxLength");

        this.rtfDocument.Multiline = (bool) resources.GetObject("rtfDocument.Multiline");

        this.rtfDocument.Name = "rtfDocument";

        this.rtfDocument.RightMargin = (int) resources.GetObject("rtfDocument.RightMargin");

        this.rtfDocument.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rtfDocument.RightToLeft");

        this.rtfDocument.ScrollBars = (System.Windows.Forms.RichTextBoxScrollBars) resources.GetObject("rtfDocument.ScrollBars");

        this.rtfDocument.Size = (System.Drawing.Size) resources.GetObject("rtfDocument.Size");

        this.rtfDocument.TabIndex = (int) resources.GetObject("rtfDocument.TabIndex");

        this.rtfDocument.Text = resources.GetString("rtfDocument.Text");

        this.rtfDocument.Visible = (bool) resources.GetObject("rtfDocument.Visible");

        this.rtfDocument.WordWrap = (bool) resources.GetObject("rtfDocument.WordWrap");

        this.rtfDocument.ZoomFactor = (Single) resources.GetObject("rtfDocument.ZoomFactor");

        //

        //btnBrowseWord

        //

        this.btnBrowseWord.AccessibleDescription = resources.GetString("btnBrowseWord.AccessibleDescription");

        this.btnBrowseWord.AccessibleName = resources.GetString("btnBrowseWord.AccessibleName");

        this.btnBrowseWord.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnBrowseWord.Anchor");

        this.btnBrowseWord.BackColor = System.Drawing.SystemColors.Control;

        this.btnBrowseWord.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnBrowseWord.BackgroundImage");

        this.btnBrowseWord.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnBrowseWord.Dock");

        this.btnBrowseWord.Enabled = (bool) resources.GetObject("btnBrowseWord.Enabled");

        this.btnBrowseWord.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnBrowseWord.FlatStyle");

        this.btnBrowseWord.Font = (System.Drawing.Font) resources.GetObject("btnBrowseWord.Font");

        this.btnBrowseWord.Image = (System.Drawing.Image) resources.GetObject("btnBrowseWord.Image");

        this.btnBrowseWord.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBrowseWord.ImageAlign");

        this.btnBrowseWord.ImageIndex = (int) resources.GetObject("btnBrowseWord.ImageIndex");

        this.btnBrowseWord.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnBrowseWord.ImeMode");

        this.btnBrowseWord.Location = (System.Drawing.Point) resources.GetObject("btnBrowseWord.Location");

        this.btnBrowseWord.Name = "btnBrowseWord";

        this.btnBrowseWord.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnBrowseWord.RightToLeft");

        this.btnBrowseWord.Size = (System.Drawing.Size) resources.GetObject("btnBrowseWord.Size");

        this.btnBrowseWord.TabIndex = (int) resources.GetObject("btnBrowseWord.TabIndex");

        this.btnBrowseWord.Text = resources.GetString("btnBrowseWord.Text");

        this.btnBrowseWord.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBrowseWord.TextAlign");

        this.btnBrowseWord.Visible = (bool) resources.GetObject("btnBrowseWord.Visible");

        //

        //pgeExcel

        //

        this.pgeExcel.AccessibleDescription = resources.GetString("pgeExcel.AccessibleDescription");

        this.pgeExcel.AccessibleName = resources.GetString("pgeExcel.AccessibleName");

        this.pgeExcel.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeExcel.Anchor");

        this.pgeExcel.AutoScroll = (bool) resources.GetObject("pgeExcel.AutoScroll");

        this.pgeExcel.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeExcel.AutoScrollMargin");

        this.pgeExcel.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeExcel.AutoScrollMinSize");

        this.pgeExcel.BackColor = System.Drawing.SystemColors.Control;

        this.pgeExcel.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeExcel.BackgroundImage");

        this.pgeExcel.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnExport, this.btnGetMenu, this.grdMenu});

        this.pgeExcel.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeExcel.Dock");

        this.pgeExcel.Enabled = (bool) resources.GetObject("pgeExcel.Enabled");

        this.pgeExcel.Font = (System.Drawing.Font) resources.GetObject("pgeExcel.Font");

        this.pgeExcel.ImageIndex = (int) resources.GetObject("pgeExcel.ImageIndex");

        this.pgeExcel.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeExcel.ImeMode");

        this.pgeExcel.Location = (System.Drawing.Point) resources.GetObject("pgeExcel.Location");

        this.pgeExcel.Name = "pgeExcel";

        this.pgeExcel.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeExcel.RightToLeft");

        this.pgeExcel.Size = (System.Drawing.Size) resources.GetObject("pgeExcel.Size");

        this.pgeExcel.TabIndex = (int) resources.GetObject("pgeExcel.TabIndex");

        this.pgeExcel.Text = resources.GetString("pgeExcel.Text");

        this.pgeExcel.ToolTipText = resources.GetString("pgeExcel.ToolTipText");

        this.pgeExcel.Visible = (bool) resources.GetObject("pgeExcel.Visible");

        //

        //btnExport

        //

        this.btnExport.AccessibleDescription = resources.GetString("btnExport.AccessibleDescription");

        this.btnExport.AccessibleName = resources.GetString("btnExport.AccessibleName");

        this.btnExport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnExport.Anchor");

        this.btnExport.BackColor = System.Drawing.SystemColors.Control;

        this.btnExport.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnExport.BackgroundImage");

        this.btnExport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnExport.Dock");

        this.btnExport.Enabled = (bool) resources.GetObject("btnExport.Enabled");

        this.btnExport.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnExport.FlatStyle");

        this.btnExport.Font = (System.Drawing.Font) resources.GetObject("btnExport.Font");

        this.btnExport.Image = (System.Drawing.Image) resources.GetObject("btnExport.Image");

        this.btnExport.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnExport.ImageAlign");

        this.btnExport.ImageIndex = (int) resources.GetObject("btnExport.ImageIndex");

        this.btnExport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnExport.ImeMode");

        this.btnExport.Location = (System.Drawing.Point) resources.GetObject("btnExport.Location");

        this.btnExport.Name = "btnExport";

        this.btnExport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnExport.RightToLeft");

        this.btnExport.Size = (System.Drawing.Size) resources.GetObject("btnExport.Size");

        this.btnExport.TabIndex = (int) resources.GetObject("btnExport.TabIndex");

        this.btnExport.Text = resources.GetString("btnExport.Text");

        this.btnExport.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnExport.TextAlign");

        this.btnExport.Visible = (bool) resources.GetObject("btnExport.Visible");

        //

        //btnGetMenu

        //

        this.btnGetMenu.AccessibleDescription = resources.GetString("btnGetMenu.AccessibleDescription");

        this.btnGetMenu.AccessibleName = resources.GetString("btnGetMenu.AccessibleName");

        this.btnGetMenu.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGetMenu.Anchor");

        this.btnGetMenu.BackColor = System.Drawing.SystemColors.Control;

        this.btnGetMenu.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGetMenu.BackgroundImage");

        this.btnGetMenu.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGetMenu.Dock");

        this.btnGetMenu.Enabled = (bool) resources.GetObject("btnGetMenu.Enabled");

        this.btnGetMenu.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGetMenu.FlatStyle");

        this.btnGetMenu.Font = (System.Drawing.Font) resources.GetObject("btnGetMenu.Font");

        this.btnGetMenu.Image = (System.Drawing.Image) resources.GetObject("btnGetMenu.Image");

        this.btnGetMenu.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetMenu.ImageAlign");

        this.btnGetMenu.ImageIndex = (int) resources.GetObject("btnGetMenu.ImageIndex");

        this.btnGetMenu.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGetMenu.ImeMode");

        this.btnGetMenu.Location = (System.Drawing.Point) resources.GetObject("btnGetMenu.Location");

        this.btnGetMenu.Name = "btnGetMenu";

        this.btnGetMenu.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGetMenu.RightToLeft");

        this.btnGetMenu.Size = (System.Drawing.Size) resources.GetObject("btnGetMenu.Size");

        this.btnGetMenu.TabIndex = (int) resources.GetObject("btnGetMenu.TabIndex");

        this.btnGetMenu.Text = resources.GetString("btnGetMenu.Text");

        this.btnGetMenu.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetMenu.TextAlign");

        this.btnGetMenu.Visible = (bool) resources.GetObject("btnGetMenu.Visible");

        //

        //grdMenu

        //

        this.grdMenu.AccessibleDescription = resources.GetString("grdMenu.AccessibleDescription");

        this.grdMenu.AccessibleName = resources.GetString("grdMenu.AccessibleName");

        this.grdMenu.AlternatingBackColor = System.Drawing.Color.Lavender;

        this.grdMenu.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdMenu.Anchor");

        this.grdMenu.BackColor = System.Drawing.Color.WhiteSmoke;

        this.grdMenu.BackgroundColor = System.Drawing.Color.LightGray;

        this.grdMenu.BackgroundImage = (System.Drawing.Image) resources.GetObject("grdMenu.BackgroundImage");

        this.grdMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;

        this.grdMenu.CaptionBackColor = System.Drawing.Color.LightSteelBlue;

        this.grdMenu.CaptionFont = (System.Drawing.Font) resources.GetObject("grdMenu.CaptionFont");

        this.grdMenu.CaptionForeColor = System.Drawing.Color.MidnightBlue;

        this.grdMenu.CaptionText = resources.GetString("grdMenu.CaptionText");

        this.grdMenu.DataMember = string.Empty;

        this.grdMenu.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grdMenu.Dock");

        this.grdMenu.Enabled = (bool) resources.GetObject("grdMenu.Enabled");

        this.grdMenu.FlatMode = true;

        this.grdMenu.Font = (System.Drawing.Font) resources.GetObject("grdMenu.Font");

        this.grdMenu.ForeColor = System.Drawing.Color.MidnightBlue;

        this.grdMenu.GridLineColor = System.Drawing.Color.Gainsboro;

        this.grdMenu.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;

        this.grdMenu.HeaderBackColor = System.Drawing.Color.MidnightBlue;

        this.grdMenu.HeaderFont = new System.Drawing.Font("Tahoma", (float)8.0, System.Drawing.FontStyle.Bold);

        this.grdMenu.HeaderForeColor = System.Drawing.Color.WhiteSmoke;

        this.grdMenu.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grdMenu.ImeMode");

        this.grdMenu.LinkColor = System.Drawing.Color.Teal;

        this.grdMenu.Location = (System.Drawing.Point) resources.GetObject("grdMenu.Location");

        this.grdMenu.Name = "grdMenu";

        this.grdMenu.ParentRowsBackColor = System.Drawing.Color.Gainsboro;

        this.grdMenu.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;

        this.grdMenu.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grdMenu.RightToLeft");

        this.grdMenu.SelectionBackColor = System.Drawing.Color.CadetBlue;

        this.grdMenu.SelectionForeColor = System.Drawing.Color.WhiteSmoke;

        this.grdMenu.Size = (System.Drawing.Size) resources.GetObject("grdMenu.Size");

        this.grdMenu.TabIndex = (int) resources.GetObject("grdMenu.TabIndex");

        this.grdMenu.Visible = (bool) resources.GetObject("grdMenu.Visible");

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

        this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;

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

        //dlgOpenWordFile

        //

        this.dlgOpenWordFile.Filter = resources.GetString("dlgOpenWordFile.Filter");

        this.dlgOpenWordFile.Title = resources.GetString("dlgOpenWordFile.Title");

        //

        //chkMerlinHide

        //

        this.chkMerlinHide.AccessibleDescription = resources.GetString("chkMerlinHide.AccessibleDescription");

        this.chkMerlinHide.AccessibleName = resources.GetString("chkMerlinHide.AccessibleName");

        this.chkMerlinHide.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkMerlinHide.Anchor");

        this.chkMerlinHide.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkMerlinHide.Appearance");

        this.chkMerlinHide.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkMerlinHide.BackgroundImage");

        this.chkMerlinHide.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMerlinHide.CheckAlign");

        this.chkMerlinHide.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkMerlinHide.Dock");

        this.chkMerlinHide.Enabled = (bool) resources.GetObject("chkMerlinHide.Enabled");

        this.chkMerlinHide.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkMerlinHide.FlatStyle");

        this.chkMerlinHide.Font = (System.Drawing.Font) resources.GetObject("chkMerlinHide.Font");

        this.chkMerlinHide.Image = (System.Drawing.Image) resources.GetObject("chkMerlinHide.Image");

        this.chkMerlinHide.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMerlinHide.ImageAlign");

        this.chkMerlinHide.ImageIndex = (int) resources.GetObject("chkMerlinHide.ImageIndex");

        this.chkMerlinHide.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkMerlinHide.ImeMode");

        this.chkMerlinHide.Location = (System.Drawing.Point) resources.GetObject("chkMerlinHide.Location");

        this.chkMerlinHide.Name = "chkMerlinHide";

        this.chkMerlinHide.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkMerlinHide.RightToLeft");

        this.chkMerlinHide.Size = (System.Drawing.Size) resources.GetObject("chkMerlinHide.Size");

        this.chkMerlinHide.TabIndex = (int) resources.GetObject("chkMerlinHide.TabIndex");

        this.chkMerlinHide.Text = resources.GetString("chkMerlinHide.Text");

        this.chkMerlinHide.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMerlinHide.TextAlign");

        this.chkMerlinHide.Visible = (bool) resources.GetObject("chkMerlinHide.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkMerlinHide, this.Label1, this.tabOfficeDemo});

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

        this.tabOfficeDemo.ResumeLayout(false);

        this.pgeWizard.ResumeLayout(false);

        this.GroupBox1.ResumeLayout(false);

        this.pgeWord.ResumeLayout(false);

        this.pgeExcel.ResumeLayout(false);

        ((System.ComponentModel.ISupportInitialize)(this.grdMenu)).EndInit();

        this.ResumeLayout(false);
		
		this.btnBrowseWord.Click +=new EventHandler(btnBrowseWord_Click);
		this.btnExport.Click +=new EventHandler(btnExport_Click);
		this.btnGetMenu.Click +=new EventHandler(btnGetMenu_Click);
		this.btnSpeak.Click +=new EventHandler(btnSpeak_Click);
		this.btnSpellCheck.Click +=new EventHandler(btnSpellCheck_Click);
		this.chkMerlinHide.CheckedChanged +=new EventHandler(chkMerlinOnOff_CheckedChanged);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.Load +=new EventHandler(frmMain_Load);
		this.optDontRecognize.Click +=new EventHandler(rdoAnimations_Click);
		this.optAnnounce.Click +=new EventHandler(rdoAnimations_Click);
		this.optApplaud.Click +=new EventHandler(rdoAnimations_Click);
		this.optCongrats.Click +=new EventHandler(rdoAnimations_Click);
		this.optDoMagic.Click +=new EventHandler(rdoAnimations_Click);
		this.optExplain.Click +=new EventHandler(rdoAnimations_Click);
		this.optSuggest.Click +=new EventHandler(rdoAnimations_Click);
		this.optSurprised.Click +=new EventHandler(rdoAnimations_Click);
		this.optWave.Click +=new EventHandler(rdoAnimations_Click);
		this.optWrite.Click +=new EventHandler(rdoAnimations_Click);
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

    private AgentObjects.IAgentCtlCharacter agentCharacter;
    private DataSet dsMenu;
    private bool styleAlreadyExists = false;

    // the Browse button on the Word tab which allows the user to find a
    // Text Format document on their hard drive and load it
    // into the RichTextBox control.

    private void btnBrowseWord_Click(object sender, System.EventArgs e) 
	{

            dlgOpenWordFile.InitialDirectory = @"C:\";
            dlgOpenWordFile.Filter = "Text Format (*.txt)|*.txt";
            dlgOpenWordFile.FilterIndex = 1;

            // The OpenFileDialog control only has an Open button, not an OK button.
            // However, there is no DialogResult.Open enum so use DialogResult.OK.
            if (dlgOpenWordFile.ShowDialog() == DialogResult.OK) 
				{
                try 
				{
                    rtfDocument.LoadFile(dlgOpenWordFile.FileName, RichTextBoxStreamType.PlainText);
               } 
				catch
				{
                    MessageBox.Show("The document you are attempting to load " +
                        "is not in the correct format.", "Document Load Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
    }

    // the "Export to Excel >>" button click event, which allows the user to
    // export the contents of the Dataset to an Excel spreadsheet and then run a
    // simple Average function to determine the calorie average for all the foods.

    private void btnExport_Click(object sender, System.EventArgs e) 
		{

        // An Excel spreadsheet involves a hierarchy of objects, from Application
       // to Workbook to Worksheet.

        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook excelBook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
        Excel._Worksheet excelWorksheet = (Excel._Worksheet) excelBook.Worksheets.get_Item(1);

        // Unlike the Word demo, we'll make the spreadsheet visible so you can see
        // the data being entered.
        excelApp.Visible = true;

            // Set the column headers and desired formatting for the spreadsheet.
            excelWorksheet.Columns.ColumnWidth = 21.71;
			excelWorksheet.get_Range("A1",missing).Value2 = "Item";
            excelWorksheet.get_Range("A1",missing).Font.Bold = true;
            excelWorksheet.get_Range("B1",missing).Value2 = "Price";
            excelWorksheet.get_Range("B1",missing).Font.Bold = true;
            excelWorksheet.get_Range("C1",missing).Value2 = "Calories";
            excelWorksheet.get_Range("C1",missing).Font.Bold = true;

            // Start the counter on the second row, following the column headers
            int i = 2;

            // Loop through the Rows collection of the Dataset and write the data
            // in each row to the cells in Excel. 

            foreach(DataRow dr in dsMenu.Tables[0].Rows)
			{
                excelWorksheet.get_Range("A" + i.ToString(),missing).Value2 = dr["Item"].ToString();
                excelWorksheet.get_Range("B" + i.ToString(),missing).Value2 = dr["Price"].ToString();
                excelWorksheet.get_Range("C" + i.ToString(),missing).Value2 = dr["Calories"].ToString();
                i += 1;
            }

            // Select and apply formatting to the cell that will display the calorie
            // average, then call the Average formula.
            excelWorksheet.get_Range("C7",missing).Select();
            excelWorksheet.get_Range("C7",missing).Font.Color = Color.FromArgb(255, 0, 0);
            excelWorksheet.get_Range("C7",missing).Font.Bold = true;
            excelApp.ActiveCell.FormulaR1C1 = "=AVERAGE(R[-5]C:R[-1]C)";     

    }

    // the "get {Menu" button click event, which creates and fills a DataSet
    // from an XML document, loads it into a DataGrid, and then applies custom
    // formatting to the DataGrid.

    private void btnGetMenu_Click(object sender, System.EventArgs e) 
	{

        // Fill a Dataset by loading an XML document with items from a fictitious 
        // lunch menu.

        dsMenu = new DataSet();
        dsMenu.ReadXml(System.Windows.Forms.Application.ExecutablePath + "..\\..\\..\\..\\menu.xml");

        // Set the DataGrid caption and bind it to the DataSet.

        grdMenu.CaptionText = "Today's Menu";
        grdMenu.DataSource = dsMenu.Tables[0];

        // Use a table style object to apply custom formatting to the DataGrid.
        // Only create this style the first time the data is loaded.

        if (!styleAlreadyExists) {
            DataGridTableStyle grdTableStyle1 = new DataGridTableStyle();

                grdTableStyle1.AlternatingBackColor = Color.Lavender;
                grdTableStyle1.BackColor = Color.WhiteSmoke;
                grdTableStyle1.ForeColor = Color.MidnightBlue;
                grdTableStyle1.GridLineColor = Color.Gainsboro;
                grdTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
                grdTableStyle1.HeaderBackColor = Color.MidnightBlue;
                grdTableStyle1.HeaderFont = new System.Drawing.Font("Tahoma", (float)8.0, FontStyle.Bold);
                grdTableStyle1.HeaderForeColor = Color.WhiteSmoke;
                grdTableStyle1.LinkColor = Color.Teal;
                // Do not forget to set the MappingName property. 
                // Without this, the DataGridTableStyle properties
                // and any associated DataGridColumnStyle objects
                // will have no effect.
                grdTableStyle1.MappingName = "Food";
                grdTableStyle1.SelectionBackColor = Color.CadetBlue;
                grdTableStyle1.SelectionForeColor = Color.WhiteSmoke;
            
            // Use column style objects to apply formatting specific to each column.
            DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();
            grdColStyle1.HeaderText = "Item";
            grdColStyle1.MappingName = "Item";
            grdColStyle1.Width = 125;
            DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();

                grdColStyle2.HeaderText = "Price";
                grdColStyle2.MappingName = "Price";
                grdColStyle2.Width = 50;
            
            DataGridTextBoxColumn grdColStyle3 = new DataGridTextBoxColumn();

                grdColStyle3.HeaderText = "Calories";
                grdColStyle3.MappingName = "Calories";
                grdColStyle3.Width = 70;

            // Add the column style objects to the tables style's column styles 
            // collection. if you fail to do this the column styles will not apply.

            grdTableStyle1.GridColumnStyles.AddRange (new DataGridColumnStyle[]
                {grdColStyle1, grdColStyle2, grdColStyle3});

            // Again, failure to add the style to the collection will cause the style
            // to not take effect.

            grdMenu.TableStyles.Add(grdTableStyle1);
            styleAlreadyExists = true;
        }

        // Now that the DataGrid is filled it is appropriate to show the button
        // that will allow the user to export the contents of the Dataset to 
        // an Excel spreadsheet.
        btnExport.Visible = true;
    }

    // the Speak button click event, which makes Merlin say whatever the
    // user enters into the TextBox.
    private void btnSpeak_Click(object sender, System.EventArgs e) 
	{
        agentCharacter.Speak(txtSpeak.Text,null);

    }

    // the Spellcheck button click event, allowing the user to run the Word
    // spellchecker against whatever text is in the RichTextBox control. Notice that
    // Word never needs to be seen.
    //
    // This method simply displays a dialog box.  However you could also leverage 
    // this functionality to create a more feature  rich application that mimics the
    // Word spell checker (allows the use of custom dictionaries etc.)
    private void btnSpellCheck_Click(object sender, System.EventArgs e) 
	{

        Word.Application wordApp = new Word.Application();

        bool  bolHasNoSpellingErrors = wordApp.CheckSpelling(rtfDocument.Text,
			ref missing, ref missing, ref missing, ref missing, ref missing,
			ref missing, ref missing, ref missing, ref missing, ref missing,
			ref missing, ref missing);
        string strSpellCheck = "Your document has spelling errors.";

        if (bolHasNoSpellingErrors) {
            strSpellCheck = "Congratulations, your document " +
                "is free of spelling errors.";
        }

        MessageBox.Show(strSpellCheck, "Spell Check Results", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);

    }

    // the CheckChanged event for the checkbox that hides or shows Merlin.

    private void chkMerlinOnOff_CheckedChanged(object sender, System.EventArgs e) 
	{

		if (chkMerlinHide.Checked) 
		{

			// Animations load into a queue and will play out before the next
			// command is executed. if you want Merlin to hide immediately when
			// the CheckBox is checked, you must call StopAll.

			agentCharacter.StopAll(null);
			agentCharacter.Hide(null);
		}
		else 
		{
			agentCharacter.Show(null);
		}

    }

    // the Form load event, which fires when the form is first loaded.

    private void frmMain_Load(object sender, System.EventArgs e) {

        // The Agent object is used to open a connection to the Agent server,
        // load the character, and then associate the character with the 
        // variable referencing the IAgentCtlCharacter interface. From then
        // on you program against the agentCharacter.

        AgentObjects.Agent agentController = new AgentObjects.Agent();
        agentController.Connected = true;
            agentController.Characters.Load("merlin", "merlin.acs");
            agentCharacter = agentController.Characters["merlin"];
        
        // Use the Location property to place Merlin relative to the upper left 
        // corner of the Form. 

            agentCharacter.MoveTo(Convert.ToInt16(this.Location.X + 420), Convert.ToInt16(this.Location.Y + 130),null);
            agentCharacter.Show(null);
            agentCharacter.Play("Announce");
            agentCharacter.Speak("Hello, my name is Merlin. Welcome to the Office Automation Demo!",null);
            agentCharacter.Play("GestureRight");

            // You can make Merlin's speech sound more natural by inserting speech
            // output tags like Pau (Pause), Chr (Character of the Voice), 
            // Emp (Emphasis) or Spd (Speed). Surround each name-value pair with a
            // backslash character. 

            agentCharacter.Speak(@"Make me say something,\pau=300\or\pau=500\...",null);
            agentCharacter.MoveTo(Convert.ToInt16(this.Location.X + 340), Convert.ToInt16(this.Location.Y + 250),null);
            agentCharacter.Play("GestureRight");
            agentCharacter.Speak("...try out some of my animations.",null);
        
        // Hide the "Export to Excel>>" Button on the Excel tab until the 
        // DataGrid is databound.

        btnExport.Visible = false;

    }

    // the click events of all the Merlin animations.

    private void rdoAnimations_Click(object sender, System.EventArgs e) 
		//optDontRecognize.Click, optWrite.Click, optWave.Click, optApplaud.Click, optSurprised.Click, optSuggest.Click, optAnnounce.Click, optDoMagic.Click, optExplain.Click, optCongrats.Click;
	{
        // Have Merlin immediately cease what he is doing when the user selects a 
        // new animation, or else the animations will stack up in a queue and might
        // appear not to work when selected.
        agentCharacter.StopAll(null);
        RadioButton radio = (RadioButton) sender;

            switch(radio.Tag.ToString())
			{
                case "GetAttention":

                    // Some animations require that you call a "Return" animation to
                    // get Merlin to return to a natural state. Others have this 
                    // return built in.
                    agentCharacter.Play("GetAttention");
                    agentCharacter.Play("GetAttentionReturn");
					break;
                case "Explain":
                    agentCharacter.Play("Explain");
					break;
                case "Congratulate":
                    agentCharacter.Play("Congratulate");
					break;
                case "Announce":
                    agentCharacter.Play("Announce");
					break;
                case "Applaud":
                    agentCharacter.Play("Congratulate_2");
					break;
                case "DontRecognize":
                    agentCharacter.Play("DontRecognize");
					break;
                case "Write":
                    agentCharacter.Play("Write");
					break;
                case "Surprised":
                    agentCharacter.Play("Surprised");
					break;
                case "Suggest":
                    agentCharacter.Play("Suggest");
					break;
                case "Wave":
                    agentCharacter.Play("Wave");
					break;
            }

        

    }

    // the TabControl's SelectedIndexChanged event, which fires when either
    // the Word or Excel tabs are clicked. This moves Merlin out of the way of the
    // user interface elements on these two tabs.

    private void tabOfficeDemo_SelectedIndexChanged(object sender, System.EventArgs e) 
		//tabOfficeDemo.SelectedIndexChanged;
	{
        if (tabOfficeDemo.SelectedIndex != 0) {
                agentCharacter.StopAll(null);
                agentCharacter.MoveTo(Convert.ToInt16(this.Location.X + 340), Convert.ToInt16(this.Location.Y + 40),null);
        }

    }

}

