//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Diagnostics;

public class frmMain: System.Windows.Forms.Form {

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

    private System.Windows.Forms.MainMenu mnuMain ;
    private System.Windows.Forms.MenuItem mnuFile ;
    private System.Windows.Forms.MenuItem mnuExit ;
    private System.Windows.Forms.MenuItem mnuHelp ;
    private System.Windows.Forms.MenuItem mnuAbout ;
    private System.Windows.Forms.TabControl TabControl1;
    private System.Windows.Forms.TabPage pgeScreenScrape;
    private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
    private System.Windows.Forms.Label lblResultCount;
    private System.Windows.Forms.CheckBox chkShowCaptures;
    private System.Windows.Forms.CheckBox chkShowGroups;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.TextBox txtSource;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.Button btnReplace;
    private System.Windows.Forms.CheckBox chkMultiline;
    private System.Windows.Forms.CheckBox chkIgnoreCase;
    private System.Windows.Forms.Button btnSplit;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.TextBox txtReplace;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.OpenFileDialog OpenFileDialog2;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.TextBox txtResults;
    private System.Windows.Forms.TabPage pgeRegExTester;
    private System.Windows.Forms.TextBox txtRegEx;
    private System.Windows.Forms.Label Label10;
    private System.Windows.Forms.ListView lvwImages;
    private System.Windows.Forms.TextBox txtURL;
    private System.Windows.Forms.Button btnScrape;
    private System.Windows.Forms.RadioButton optImages;
    private System.Windows.Forms.RadioButton optLinks;
    private System.Windows.Forms.ColumnHeader lvcSrc;
    private System.Windows.Forms.ColumnHeader lvcAlt;
    private System.Windows.Forms.ColumnHeader lvcHeight;
    private System.Windows.Forms.ColumnHeader lvcWidth;
    private System.Windows.Forms.ListView lvwLinks;
    private System.Windows.Forms.ColumnHeader lvcUrl;
    private System.Windows.Forms.TabPage pgeSimple;
    private System.Windows.Forms.CheckBox chkSingleLine;
    private System.Windows.Forms.GroupBox grpValidation;
    private System.Windows.Forms.Label Label11;
    private System.Windows.Forms.Label Label9;
    private System.Windows.Forms.Label Label8;
    private System.Windows.Forms.Button btnValidate;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.TextBox txtDate;
    private System.Windows.Forms.TextBox txtZip;
    private System.Windows.Forms.Label Label5;
    private System.Windows.Forms.Label Label7;
    private System.Windows.Forms.Label Label6;
    private System.Windows.Forms.GroupBox GroupBox1;
    private System.Windows.Forms.Label lblResults;
    private System.Windows.Forms.Button btnFindNumber;
    private System.Windows.Forms.Label Label12;
    private System.Windows.Forms.TextBox txtFindNumber;
    private System.Windows.Forms.Label lblValid;


    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
        this.mnuMain = new System.Windows.Forms.MainMenu();
        this.mnuFile = new System.Windows.Forms.MenuItem();
        this.mnuExit = new System.Windows.Forms.MenuItem();
        this.mnuHelp = new System.Windows.Forms.MenuItem();
        this.mnuAbout = new System.Windows.Forms.MenuItem();
        this.TabControl1 = new System.Windows.Forms.TabControl();
        this.pgeSimple = new System.Windows.Forms.TabPage();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.lblResults = new System.Windows.Forms.Label();
        this.btnFindNumber = new System.Windows.Forms.Button();
        this.Label12 = new System.Windows.Forms.Label();
        this.txtFindNumber = new System.Windows.Forms.TextBox();
        this.grpValidation = new System.Windows.Forms.GroupBox();
        this.Label11 = new System.Windows.Forms.Label();
        this.Label9 = new System.Windows.Forms.Label();
        this.Label8 = new System.Windows.Forms.Label();
        this.btnValidate = new System.Windows.Forms.Button();
        this.txtEmail = new System.Windows.Forms.TextBox();
        this.txtDate = new System.Windows.Forms.TextBox();
        this.txtZip = new System.Windows.Forms.TextBox();
        this.Label5 = new System.Windows.Forms.Label();
        this.Label7 = new System.Windows.Forms.Label();
        this.Label6 = new System.Windows.Forms.Label();
        this.pgeScreenScrape = new System.Windows.Forms.TabPage();
        this.optImages = new System.Windows.Forms.RadioButton();
        this.optLinks = new System.Windows.Forms.RadioButton();
        this.btnScrape = new System.Windows.Forms.Button();
        this.txtURL = new System.Windows.Forms.TextBox();
        this.Label10 = new System.Windows.Forms.Label();
        this.lvwImages = new System.Windows.Forms.ListView();
        this.lvcSrc = new System.Windows.Forms.ColumnHeader();
        this.lvcAlt = new System.Windows.Forms.ColumnHeader();
        this.lvcHeight = new System.Windows.Forms.ColumnHeader();
        this.lvcWidth = new System.Windows.Forms.ColumnHeader();
        this.lvwLinks = new System.Windows.Forms.ListView();
        this.lvcUrl = new System.Windows.Forms.ColumnHeader();
        this.pgeRegExTester = new System.Windows.Forms.TabPage();
        this.chkSingleLine = new System.Windows.Forms.CheckBox();
        this.txtResults = new System.Windows.Forms.TextBox();
        this.txtSource = new System.Windows.Forms.TextBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.btnReplace = new System.Windows.Forms.Button();
        this.btnSplit = new System.Windows.Forms.Button();
        this.btnFind = new System.Windows.Forms.Button();
        this.txtReplace = new System.Windows.Forms.TextBox();
        this.txtRegEx = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.lblResultCount = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.chkMultiline = new System.Windows.Forms.CheckBox();
        this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
        this.chkShowCaptures = new System.Windows.Forms.CheckBox();
        this.chkShowGroups = new System.Windows.Forms.CheckBox();
        this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        this.OpenFileDialog2 = new System.Windows.Forms.OpenFileDialog();
        this.lblValid = new System.Windows.Forms.Label();
        this.TabControl1.SuspendLayout();
        this.pgeSimple.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.grpValidation.SuspendLayout();
        this.pgeScreenScrape.SuspendLayout();
        this.pgeRegExTester.SuspendLayout();
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

        //TabControl1

        //

        this.TabControl1.AccessibleDescription = resources.GetString("TabControl1.AccessibleDescription");

        this.TabControl1.AccessibleName = resources.GetString("TabControl1.AccessibleName");

        this.TabControl1.Alignment = (System.Windows.Forms.TabAlignment) resources.GetObject("TabControl1.Alignment");

        this.TabControl1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("TabControl1.Anchor");

        this.TabControl1.Appearance = (System.Windows.Forms.TabAppearance) resources.GetObject("TabControl1.Appearance");

        this.TabControl1.BackgroundImage = (System.Drawing.Image) resources.GetObject("TabControl1.BackgroundImage");

        this.TabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {this.pgeSimple, this.pgeScreenScrape, this.pgeRegExTester});

        this.TabControl1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("TabControl1.Dock");

        this.TabControl1.Enabled = (bool) resources.GetObject("TabControl1.Enabled");

        this.TabControl1.Font = (System.Drawing.Font) resources.GetObject("TabControl1.Font");

        this.TabControl1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("TabControl1.ImeMode");

        this.TabControl1.ItemSize = (System.Drawing.Size) resources.GetObject("TabControl1.ItemSize");

        this.TabControl1.Location = (System.Drawing.Point) resources.GetObject("TabControl1.Location");

        this.TabControl1.Name = "TabControl1";

        this.TabControl1.Padding = (System.Drawing.Point) resources.GetObject("TabControl1.Padding");

        this.TabControl1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("TabControl1.RightToLeft");

        this.TabControl1.SelectedIndex = 0;

        this.TabControl1.ShowToolTips = (bool) resources.GetObject("TabControl1.ShowToolTips");

        this.TabControl1.Size = (System.Drawing.Size) resources.GetObject("TabControl1.Size");

        this.TabControl1.TabIndex = (int) resources.GetObject("TabControl1.TabIndex");

        this.TabControl1.Text = resources.GetString("TabControl1.Text");

        this.TabControl1.Visible = (bool) resources.GetObject("TabControl1.Visible");

        //

        //pgeSimple

        //

        this.pgeSimple.AccessibleDescription = (string) resources.GetObject("pgeSimple.AccessibleDescription");

        this.pgeSimple.AccessibleName = (string) resources.GetObject("pgeSimple.AccessibleName");

        this.pgeSimple.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeSimple.Anchor");

        this.pgeSimple.AutoScroll = (bool) resources.GetObject("pgeSimple.AutoScroll");

        this.pgeSimple.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeSimple.AutoScrollMargin");

        this.pgeSimple.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeSimple.AutoScrollMinSize");

        this.pgeSimple.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeSimple.BackgroundImage");

        this.pgeSimple.Controls.AddRange(new System.Windows.Forms.Control[] {this.GroupBox1, this.grpValidation});

        this.pgeSimple.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeSimple.Dock");

        this.pgeSimple.Enabled = (bool) resources.GetObject("pgeSimple.Enabled");

        this.pgeSimple.Font = (System.Drawing.Font) resources.GetObject("pgeSimple.Font");

        this.pgeSimple.ImageIndex = (int) resources.GetObject("pgeSimple.ImageIndex");

        this.pgeSimple.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeSimple.ImeMode");

        this.pgeSimple.Location = (System.Drawing.Point) resources.GetObject("pgeSimple.Location");

        this.pgeSimple.Name = "pgeSimple";

        this.pgeSimple.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeSimple.RightToLeft");

        this.pgeSimple.Size = (System.Drawing.Size) resources.GetObject("pgeSimple.Size");

        this.pgeSimple.TabIndex = (int) resources.GetObject("pgeSimple.TabIndex");

        this.pgeSimple.Text = resources.GetString("pgeSimple.Text");

        this.pgeSimple.ToolTipText = resources.GetString("pgeSimple.ToolTipText");

        this.pgeSimple.Visible = (bool) resources.GetObject("pgeSimple.Visible");

        //

        //GroupBox1

        //

        this.GroupBox1.AccessibleDescription = resources.GetString("GroupBox1.AccessibleDescription");

        this.GroupBox1.AccessibleName = resources.GetString("GroupBox1.AccessibleName");

        this.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("GroupBox1.Anchor");

        this.GroupBox1.BackgroundImage = (System.Drawing.Image) resources.GetObject("GroupBox1.BackgroundImage");

        this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblResults, this.btnFindNumber, this.Label12, this.txtFindNumber});

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

        //lblResults

        //

        this.lblResults.AccessibleDescription = resources.GetString("lblResults.AccessibleDescription");

        this.lblResults.AccessibleName = resources.GetString("lblResults.AccessibleName");

        this.lblResults.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblResults.Anchor");

        this.lblResults.AutoSize = (bool) resources.GetObject("lblResults.AutoSize");

        this.lblResults.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblResults.Dock");

        this.lblResults.Enabled = (bool) resources.GetObject("lblResults.Enabled");

        this.lblResults.Font = (System.Drawing.Font) resources.GetObject("lblResults.Font");

        this.lblResults.Image = (System.Drawing.Image) resources.GetObject("lblResults.Image");

        this.lblResults.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblResults.ImageAlign");

        this.lblResults.ImageIndex = (int) resources.GetObject("lblResults.ImageIndex");

        this.lblResults.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblResults.ImeMode");

        this.lblResults.Location = (System.Drawing.Point) resources.GetObject("lblResults.Location");

        this.lblResults.Name = "lblResults";

        this.lblResults.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblResults.RightToLeft");

        this.lblResults.Size = (System.Drawing.Size) resources.GetObject("lblResults.Size");

        this.lblResults.TabIndex = (int) resources.GetObject("lblResults.TabIndex");

        this.lblResults.Text = resources.GetString("lblResults.Text");

        this.lblResults.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblResults.TextAlign");

        this.lblResults.Visible = (bool) resources.GetObject("lblResults.Visible");

        //

        //btnFindNumber

        //

        this.btnFindNumber.AccessibleDescription = resources.GetString("btnFindNumber.AccessibleDescription");

        this.btnFindNumber.AccessibleName = resources.GetString("btnFindNumber.AccessibleName");

        this.btnFindNumber.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnFindNumber.Anchor");

        this.btnFindNumber.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnFindNumber.BackgroundImage");

        this.btnFindNumber.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnFindNumber.Dock");

        this.btnFindNumber.Enabled = (bool) resources.GetObject("btnFindNumber.Enabled");

        this.btnFindNumber.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnFindNumber.FlatStyle");

        this.btnFindNumber.Font = (System.Drawing.Font) resources.GetObject("btnFindNumber.Font");

        this.btnFindNumber.Image = (System.Drawing.Image) resources.GetObject("btnFindNumber.Image");

        this.btnFindNumber.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFindNumber.ImageAlign");

        this.btnFindNumber.ImageIndex = (int) resources.GetObject("btnFindNumber.ImageIndex");

        this.btnFindNumber.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnFindNumber.ImeMode");

        this.btnFindNumber.Location = (System.Drawing.Point) resources.GetObject("btnFindNumber.Location");

        this.btnFindNumber.Name = "btnFindNumber";

        this.btnFindNumber.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnFindNumber.RightToLeft");

        this.btnFindNumber.Size = (System.Drawing.Size) resources.GetObject("btnFindNumber.Size");

        this.btnFindNumber.TabIndex = (int) resources.GetObject("btnFindNumber.TabIndex");

        this.btnFindNumber.Text = resources.GetString("btnFindNumber.Text");

        this.btnFindNumber.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFindNumber.TextAlign");

        this.btnFindNumber.Visible = (bool) resources.GetObject("btnFindNumber.Visible");

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

        //txtFindNumber

        //

        this.txtFindNumber.AccessibleDescription = resources.GetString("txtFindNumber.AccessibleDescription");

        this.txtFindNumber.AccessibleName = resources.GetString("txtFindNumber.AccessibleName");

        this.txtFindNumber.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtFindNumber.Anchor");

        this.txtFindNumber.AutoSize = (bool) resources.GetObject("txtFindNumber.AutoSize");

        this.txtFindNumber.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtFindNumber.BackgroundImage");

        this.txtFindNumber.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtFindNumber.Dock");

        this.txtFindNumber.Enabled = (bool) resources.GetObject("txtFindNumber.Enabled");

        this.txtFindNumber.Font = (System.Drawing.Font) resources.GetObject("txtFindNumber.Font");

        this.txtFindNumber.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtFindNumber.ImeMode");

        this.txtFindNumber.Location = (System.Drawing.Point) resources.GetObject("txtFindNumber.Location");

        this.txtFindNumber.MaxLength = (int) resources.GetObject("txtFindNumber.MaxLength");

        this.txtFindNumber.Multiline = (bool) resources.GetObject("txtFindNumber.Multiline");

        this.txtFindNumber.Name = "txtFindNumber";

        this.txtFindNumber.PasswordChar = (char) resources.GetObject("txtFindNumber.PasswordChar");

        this.txtFindNumber.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtFindNumber.RightToLeft");

        this.txtFindNumber.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtFindNumber.ScrollBars");

        this.txtFindNumber.Size = (System.Drawing.Size) resources.GetObject("txtFindNumber.Size");

        this.txtFindNumber.TabIndex = (int) resources.GetObject("txtFindNumber.TabIndex");

        this.txtFindNumber.Text = resources.GetString("txtFindNumber.Text");

        this.txtFindNumber.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtFindNumber.TextAlign");

        this.txtFindNumber.Visible = (bool) resources.GetObject("txtFindNumber.Visible");

        this.txtFindNumber.WordWrap = (bool) resources.GetObject("txtFindNumber.WordWrap");

        //

        //grpValidation

        //

        this.grpValidation.AccessibleDescription = resources.GetString("grpValidation.AccessibleDescription");

        this.grpValidation.AccessibleName = (string) resources.GetObject("grpValidation.AccessibleName");

        this.grpValidation.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grpValidation.Anchor");

        this.grpValidation.BackgroundImage = (System.Drawing.Image) resources.GetObject("grpValidation.BackgroundImage");

        this.grpValidation.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblValid, this.Label11, this.Label9, this.Label8, this.btnValidate, this.txtEmail, this.txtDate, this.txtZip, this.Label5, this.Label7, this.Label6});

        this.grpValidation.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grpValidation.Dock");

        this.grpValidation.Enabled = (bool) resources.GetObject("grpValidation.Enabled");

        this.grpValidation.Font = (System.Drawing.Font) resources.GetObject("grpValidation.Font");

        this.grpValidation.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grpValidation.ImeMode");

        this.grpValidation.Location = (System.Drawing.Point) resources.GetObject("grpValidation.Location");

        this.grpValidation.Name = "grpValidation";

        this.grpValidation.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grpValidation.RightToLeft");

        this.grpValidation.Size = (System.Drawing.Size) resources.GetObject("grpValidation.Size");

        this.grpValidation.TabIndex = (int) resources.GetObject("grpValidation.TabIndex");

        this.grpValidation.TabStop = false;

        this.grpValidation.Text = resources.GetString("grpValidation.Text");

        this.grpValidation.Visible = (bool) resources.GetObject("grpValidation.Visible");

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

        //btnValidate

        //

        this.btnValidate.AccessibleDescription = resources.GetString("btnValidate.AccessibleDescription");

        this.btnValidate.AccessibleName = resources.GetString("btnValidate.AccessibleName");

        this.btnValidate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnValidate.Anchor");

        this.btnValidate.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnValidate.BackgroundImage");

        this.btnValidate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnValidate.Dock");

        this.btnValidate.Enabled = (bool) resources.GetObject("btnValidate.Enabled");

        this.btnValidate.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnValidate.FlatStyle");

        this.btnValidate.Font = (System.Drawing.Font) resources.GetObject("btnValidate.Font");

        this.btnValidate.Image = (System.Drawing.Image) resources.GetObject("btnValidate.Image");

        this.btnValidate.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnValidate.ImageAlign");

        this.btnValidate.ImageIndex = (int) resources.GetObject("btnValidate.ImageIndex");

        this.btnValidate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnValidate.ImeMode");

        this.btnValidate.Location = (System.Drawing.Point) resources.GetObject("btnValidate.Location");

        this.btnValidate.Name = "btnValidate";

        this.btnValidate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnValidate.RightToLeft");

        this.btnValidate.Size = (System.Drawing.Size) resources.GetObject("btnValidate.Size");

        this.btnValidate.TabIndex = (int) resources.GetObject("btnValidate.TabIndex");

        this.btnValidate.Text = resources.GetString("btnValidate.Text");

        this.btnValidate.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnValidate.TextAlign");

        this.btnValidate.Visible = (bool) resources.GetObject("btnValidate.Visible");

        //

        //txtEmail

        //

        this.txtEmail.AccessibleDescription = resources.GetString("txtEmail.AccessibleDescription");

        this.txtEmail.AccessibleName = resources.GetString("txtEmail.AccessibleName");

        this.txtEmail.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtEmail.Anchor");

        this.txtEmail.AutoSize = (bool) resources.GetObject("txtEmail.AutoSize");

        this.txtEmail.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtEmail.BackgroundImage");

        this.txtEmail.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtEmail.Dock");

        this.txtEmail.Enabled = (bool) resources.GetObject("txtEmail.Enabled");

        this.txtEmail.Font = (System.Drawing.Font) resources.GetObject("txtEmail.Font");

        this.txtEmail.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtEmail.ImeMode");

        this.txtEmail.Location = (System.Drawing.Point) resources.GetObject("txtEmail.Location");

        this.txtEmail.MaxLength = (int) resources.GetObject("txtEmail.MaxLength");

        this.txtEmail.Multiline = (bool) resources.GetObject("txtEmail.Multiline");

        this.txtEmail.Name = "txtEmail";

        this.txtEmail.PasswordChar = (char) resources.GetObject("txtEmail.PasswordChar");

        this.txtEmail.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtEmail.RightToLeft");

        this.txtEmail.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtEmail.ScrollBars");

        this.txtEmail.Size = (System.Drawing.Size) resources.GetObject("txtEmail.Size");

        this.txtEmail.TabIndex = (int) resources.GetObject("txtEmail.TabIndex");

        this.txtEmail.Text = resources.GetString("txtEmail.Text");

        this.txtEmail.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtEmail.TextAlign");

        this.txtEmail.Visible = (bool) resources.GetObject("txtEmail.Visible");

        this.txtEmail.WordWrap = (bool) resources.GetObject("txtEmail.WordWrap");

        //

        //txtDate

        //

        this.txtDate.AccessibleDescription = resources.GetString("txtDate.AccessibleDescription");

        this.txtDate.AccessibleName = resources.GetString("txtDate.AccessibleName");

        this.txtDate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtDate.Anchor");

        this.txtDate.AutoSize = (bool) resources.GetObject("txtDate.AutoSize");

        this.txtDate.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtDate.BackgroundImage");

        this.txtDate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtDate.Dock");

        this.txtDate.Enabled = (bool) resources.GetObject("txtDate.Enabled");

        this.txtDate.Font = (System.Drawing.Font) resources.GetObject("txtDate.Font");

        this.txtDate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtDate.ImeMode");

        this.txtDate.Location = (System.Drawing.Point) resources.GetObject("txtDate.Location");

        this.txtDate.MaxLength = (int) resources.GetObject("txtDate.MaxLength");

        this.txtDate.Multiline = (bool) resources.GetObject("txtDate.Multiline");

        this.txtDate.Name = "txtDate";

        this.txtDate.PasswordChar = (char) resources.GetObject("txtDate.PasswordChar");

        this.txtDate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtDate.RightToLeft");

        this.txtDate.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtDate.ScrollBars");

        this.txtDate.Size = (System.Drawing.Size) resources.GetObject("txtDate.Size");

        this.txtDate.TabIndex = (int) resources.GetObject("txtDate.TabIndex");

        this.txtDate.Text = resources.GetString("txtDate.Text");

        this.txtDate.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtDate.TextAlign");

        this.txtDate.Visible = (bool) resources.GetObject("txtDate.Visible");

        this.txtDate.WordWrap = (bool) resources.GetObject("txtDate.WordWrap");

        //

        //txtZip

        //

        this.txtZip.AccessibleDescription = resources.GetString("txtZip.AccessibleDescription");

        this.txtZip.AccessibleName = resources.GetString("txtZip.AccessibleName");

        this.txtZip.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtZip.Anchor");

        this.txtZip.AutoSize = (bool) resources.GetObject("txtZip.AutoSize");

        this.txtZip.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtZip.BackgroundImage");

        this.txtZip.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtZip.Dock");

        this.txtZip.Enabled = (bool) resources.GetObject("txtZip.Enabled");

        this.txtZip.Font = (System.Drawing.Font) resources.GetObject("txtZip.Font");

        this.txtZip.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtZip.ImeMode");

        this.txtZip.Location = (System.Drawing.Point) resources.GetObject("txtZip.Location");

        this.txtZip.MaxLength = (int) resources.GetObject("txtZip.MaxLength");

        this.txtZip.Multiline = (bool) resources.GetObject("txtZip.Multiline");

        this.txtZip.Name = "txtZip";

        this.txtZip.PasswordChar = (char) resources.GetObject("txtZip.PasswordChar");

        this.txtZip.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtZip.RightToLeft");

        this.txtZip.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtZip.ScrollBars");

        this.txtZip.Size = (System.Drawing.Size) resources.GetObject("txtZip.Size");

        this.txtZip.TabIndex = (int) resources.GetObject("txtZip.TabIndex");

        this.txtZip.Text = resources.GetString("txtZip.Text");

        this.txtZip.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtZip.TextAlign");

        this.txtZip.Visible = (bool) resources.GetObject("txtZip.Visible");

        this.txtZip.WordWrap = (bool) resources.GetObject("txtZip.WordWrap");

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

        //pgeScreenScrape

        //

        this.pgeScreenScrape.AccessibleDescription = (string) resources.GetObject("pgeScreenScrape.AccessibleDescription");

        this.pgeScreenScrape.AccessibleName = (string) resources.GetObject("pgeScreenScrape.AccessibleName");

        this.pgeScreenScrape.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeScreenScrape.Anchor");

        this.pgeScreenScrape.AutoScroll = (bool) resources.GetObject("pgeScreenScrape.AutoScroll");

        this.pgeScreenScrape.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeScreenScrape.AutoScrollMargin");

        this.pgeScreenScrape.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeScreenScrape.AutoScrollMinSize");

        this.pgeScreenScrape.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeScreenScrape.BackgroundImage");

        this.pgeScreenScrape.Controls.AddRange(new System.Windows.Forms.Control[] {this.optImages, this.optLinks, this.btnScrape, this.txtURL, this.Label10, this.lvwImages, this.lvwLinks});

        this.pgeScreenScrape.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeScreenScrape.Dock");

        this.pgeScreenScrape.Enabled = (bool) resources.GetObject("pgeScreenScrape.Enabled");

        this.pgeScreenScrape.Font = (System.Drawing.Font) resources.GetObject("pgeScreenScrape.Font");

        this.pgeScreenScrape.ImageIndex = (int) resources.GetObject("pgeScreenScrape.ImageIndex");

        this.pgeScreenScrape.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeScreenScrape.ImeMode");

        this.pgeScreenScrape.Location = (System.Drawing.Point) resources.GetObject("pgeScreenScrape.Location");

        this.pgeScreenScrape.Name = "pgeScreenScrape";

        this.pgeScreenScrape.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeScreenScrape.RightToLeft");

        this.pgeScreenScrape.Size = (System.Drawing.Size) resources.GetObject("pgeScreenScrape.Size");

        this.pgeScreenScrape.TabIndex = (int) resources.GetObject("pgeScreenScrape.TabIndex");

        this.pgeScreenScrape.Text = resources.GetString("pgeScreenScrape.Text");

        this.pgeScreenScrape.ToolTipText = resources.GetString("pgeScreenScrape.ToolTipText");

        this.pgeScreenScrape.Visible = (bool) resources.GetObject("pgeScreenScrape.Visible");

        //

        //optImages

        //

        this.optImages.AccessibleDescription = resources.GetString("optImages.AccessibleDescription");

        this.optImages.AccessibleName = resources.GetString("optImages.AccessibleName");

        this.optImages.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optImages.Anchor");

        this.optImages.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optImages.Appearance");

        this.optImages.BackgroundImage = (System.Drawing.Image) resources.GetObject("optImages.BackgroundImage");

        this.optImages.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optImages.CheckAlign");

        this.optImages.Checked = true;

        this.optImages.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optImages.Dock");

        this.optImages.Enabled = (bool) resources.GetObject("optImages.Enabled");

        this.optImages.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optImages.FlatStyle");

        this.optImages.Font = (System.Drawing.Font) resources.GetObject("optImages.Font");

        this.optImages.Image = (System.Drawing.Image) resources.GetObject("optImages.Image");

        this.optImages.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optImages.ImageAlign");

        this.optImages.ImageIndex = (int) resources.GetObject("optImages.ImageIndex");

        this.optImages.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optImages.ImeMode");

        this.optImages.Location = (System.Drawing.Point) resources.GetObject("optImages.Location");

        this.optImages.Name = "optImages";

        this.optImages.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optImages.RightToLeft");

        this.optImages.Size = (System.Drawing.Size) resources.GetObject("optImages.Size");

        this.optImages.TabIndex = (int) resources.GetObject("optImages.TabIndex");

        this.optImages.TabStop = true;

        this.optImages.Text = resources.GetString("optImages.Text");

        this.optImages.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optImages.TextAlign");

        this.optImages.Visible = (bool) resources.GetObject("optImages.Visible");

        //

        //optLinks

        //

        this.optLinks.AccessibleDescription = resources.GetString("optLinks.AccessibleDescription");

        this.optLinks.AccessibleName = resources.GetString("optLinks.AccessibleName");

        this.optLinks.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optLinks.Anchor");

        this.optLinks.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optLinks.Appearance");

        this.optLinks.BackgroundImage = (System.Drawing.Image) resources.GetObject("optLinks.BackgroundImage");

        this.optLinks.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optLinks.CheckAlign");

        this.optLinks.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optLinks.Dock");

        this.optLinks.Enabled = (bool) resources.GetObject("optLinks.Enabled");

        this.optLinks.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optLinks.FlatStyle");

        this.optLinks.Font = (System.Drawing.Font) resources.GetObject("optLinks.Font");

        this.optLinks.Image = (System.Drawing.Image) resources.GetObject("optLinks.Image");

        this.optLinks.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optLinks.ImageAlign");

        this.optLinks.ImageIndex = (int) resources.GetObject("optLinks.ImageIndex");

        this.optLinks.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optLinks.ImeMode");

        this.optLinks.Location = (System.Drawing.Point) resources.GetObject("optLinks.Location");

        this.optLinks.Name = "optLinks";

        this.optLinks.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optLinks.RightToLeft");

        this.optLinks.Size = (System.Drawing.Size) resources.GetObject("optLinks.Size");

        this.optLinks.TabIndex = (int) resources.GetObject("optLinks.TabIndex");

        this.optLinks.Text = resources.GetString("optLinks.Text");

        this.optLinks.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optLinks.TextAlign");

        this.optLinks.Visible = (bool) resources.GetObject("optLinks.Visible");

        //

        //btnScrape

        //

        this.btnScrape.AccessibleDescription = resources.GetString("btnScrape.AccessibleDescription");

        this.btnScrape.AccessibleName = resources.GetString("btnScrape.AccessibleName");

        this.btnScrape.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnScrape.Anchor");

        this.btnScrape.BackColor = System.Drawing.SystemColors.Control;

        this.btnScrape.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnScrape.BackgroundImage");

        this.btnScrape.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnScrape.Dock");

        this.btnScrape.Enabled = (bool) resources.GetObject("btnScrape.Enabled");

        this.btnScrape.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnScrape.FlatStyle");

        this.btnScrape.Font = (System.Drawing.Font) resources.GetObject("btnScrape.Font");

        this.btnScrape.ForeColor = System.Drawing.SystemColors.ControlText;

        this.btnScrape.Image = (System.Drawing.Image) resources.GetObject("btnScrape.Image");

        this.btnScrape.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnScrape.ImageAlign");

        this.btnScrape.ImageIndex = (int) resources.GetObject("btnScrape.ImageIndex");

        this.btnScrape.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnScrape.ImeMode");

        this.btnScrape.Location = (System.Drawing.Point) resources.GetObject("btnScrape.Location");

        this.btnScrape.Name = "btnScrape";

        this.btnScrape.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnScrape.RightToLeft");

        this.btnScrape.Size = (System.Drawing.Size) resources.GetObject("btnScrape.Size");

        this.btnScrape.TabIndex = (int) resources.GetObject("btnScrape.TabIndex");

        this.btnScrape.Text = resources.GetString("btnScrape.Text");

        this.btnScrape.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnScrape.TextAlign");

        this.btnScrape.Visible = (bool) resources.GetObject("btnScrape.Visible");

        //

        //txtURL

        //

        this.txtURL.AccessibleDescription = resources.GetString("txtURL.AccessibleDescription");

        this.txtURL.AccessibleName = resources.GetString("txtURL.AccessibleName");

        this.txtURL.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtURL.Anchor");

        this.txtURL.AutoSize = (bool) resources.GetObject("txtURL.AutoSize");

        this.txtURL.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtURL.BackgroundImage");

        this.txtURL.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtURL.Dock");

        this.txtURL.Enabled = (bool) resources.GetObject("txtURL.Enabled");

        this.txtURL.Font = (System.Drawing.Font) resources.GetObject("txtURL.Font");

        this.txtURL.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtURL.ImeMode");

        this.txtURL.Location = (System.Drawing.Point) resources.GetObject("txtURL.Location");

        this.txtURL.MaxLength = (int) resources.GetObject("txtURL.MaxLength");

        this.txtURL.Multiline = (bool) resources.GetObject("txtURL.Multiline");

        this.txtURL.Name = "txtURL";

        this.txtURL.PasswordChar = (char) resources.GetObject("txtURL.PasswordChar");

        this.txtURL.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtURL.RightToLeft");

        this.txtURL.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtURL.ScrollBars");

        this.txtURL.Size = (System.Drawing.Size) resources.GetObject("txtURL.Size");

        this.txtURL.TabIndex = (int) resources.GetObject("txtURL.TabIndex");

        this.txtURL.Text = resources.GetString("txtURL.Text");

        this.txtURL.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtURL.TextAlign");

        this.txtURL.Visible = (bool) resources.GetObject("txtURL.Visible");

        this.txtURL.WordWrap = (bool) resources.GetObject("txtURL.WordWrap");

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

        this.Label10.ForeColor = System.Drawing.SystemColors.ControlText;

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

        //lvwImages

        //

        this.lvwImages.AccessibleDescription = resources.GetString("lvwImages.AccessibleDescription");

        this.lvwImages.AccessibleName = resources.GetString("lvwImages.AccessibleName");

        this.lvwImages.Alignment = (System.Windows.Forms.ListViewAlignment) resources.GetObject("lvwImages.Alignment");

        this.lvwImages.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lvwImages.Anchor");

        this.lvwImages.BackgroundImage = (System.Drawing.Image) resources.GetObject("lvwImages.BackgroundImage");

        this.lvwImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.lvcSrc, this.lvcAlt, this.lvcHeight, this.lvcWidth});

        this.lvwImages.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lvwImages.Dock");

        this.lvwImages.Enabled = (bool) resources.GetObject("lvwImages.Enabled");

        this.lvwImages.Font = (System.Drawing.Font) resources.GetObject("lvwImages.Font");

        this.lvwImages.FullRowSelect = true;

        this.lvwImages.GridLines = true;

        this.lvwImages.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lvwImages.ImeMode");

        this.lvwImages.LabelWrap = (bool) resources.GetObject("lvwImages.LabelWrap");

        this.lvwImages.Location = (System.Drawing.Point) resources.GetObject("lvwImages.Location");

        this.lvwImages.Name = "lvwImages";

        this.lvwImages.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lvwImages.RightToLeft");

        this.lvwImages.Size = (System.Drawing.Size) resources.GetObject("lvwImages.Size");

        this.lvwImages.TabIndex = (int) resources.GetObject("lvwImages.TabIndex");

        this.lvwImages.Text = resources.GetString("lvwImages.Text");

        this.lvwImages.View = System.Windows.Forms.View.Details;

        this.lvwImages.Visible = (bool) resources.GetObject("lvwImages.Visible");

        //

        //lvcSrc

        //

        this.lvcSrc.Text = resources.GetString("lvcSrc.Text");

        this.lvcSrc.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("lvcSrc.TextAlign");

        this.lvcSrc.Width = (int) resources.GetObject("lvcSrc.Width");

        //

        //lvcAlt

        //

        this.lvcAlt.Text = resources.GetString("lvcAlt.Text");

        this.lvcAlt.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("lvcAlt.TextAlign");

        this.lvcAlt.Width = (int) resources.GetObject("lvcAlt.Width");

        //

        //lvcHeight

        //

        this.lvcHeight.Text = resources.GetString("lvcHeight.Text");

        this.lvcHeight.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("lvcHeight.TextAlign");

        this.lvcHeight.Width = (int) resources.GetObject("lvcHeight.Width");

        //

        //lvcWidth

        //

        this.lvcWidth.Text = resources.GetString("lvcWidth.Text");

        this.lvcWidth.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("lvcWidth.TextAlign");

        this.lvcWidth.Width = (int) resources.GetObject("lvcWidth.Width");

        //

        //lvwLinks

        //

        this.lvwLinks.AccessibleDescription = resources.GetString("lvwLinks.AccessibleDescription");

        this.lvwLinks.AccessibleName = resources.GetString("lvwLinks.AccessibleName");

        this.lvwLinks.Alignment = (System.Windows.Forms.ListViewAlignment) resources.GetObject("lvwLinks.Alignment");

        this.lvwLinks.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lvwLinks.Anchor");

        this.lvwLinks.BackgroundImage = (System.Drawing.Image) resources.GetObject("lvwLinks.BackgroundImage");

        this.lvwLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.lvcUrl});

        this.lvwLinks.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lvwLinks.Dock");

        this.lvwLinks.Enabled = (bool) resources.GetObject("lvwLinks.Enabled");

        this.lvwLinks.Font = (System.Drawing.Font) resources.GetObject("lvwLinks.Font");

        this.lvwLinks.FullRowSelect = true;

        this.lvwLinks.GridLines = true;

        this.lvwLinks.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lvwLinks.ImeMode");

        this.lvwLinks.LabelWrap = (bool) resources.GetObject("lvwLinks.LabelWrap");

        this.lvwLinks.Location = (System.Drawing.Point) resources.GetObject("lvwLinks.Location");

        this.lvwLinks.Name = "lvwLinks";

        this.lvwLinks.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lvwLinks.RightToLeft");

        this.lvwLinks.Size = (System.Drawing.Size) resources.GetObject("lvwLinks.Size");

        this.lvwLinks.TabIndex = (int) resources.GetObject("lvwLinks.TabIndex");

        this.lvwLinks.Text = resources.GetString("lvwLinks.Text");

        this.lvwLinks.View = System.Windows.Forms.View.Details;

        this.lvwLinks.Visible = (bool) resources.GetObject("lvwLinks.Visible");

        //

        //lvcUrl

        //

        this.lvcUrl.Text = resources.GetString("lvcUrl.Text");

        this.lvcUrl.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("lvcUrl.TextAlign");

        this.lvcUrl.Width = (int) resources.GetObject("lvcUrl.Width");

        //

        //pgeRegExTester

        //

        this.pgeRegExTester.AccessibleDescription = (string) resources.GetObject("pgeRegExTester.AccessibleDescription");

        this.pgeRegExTester.AccessibleName = (string) resources.GetObject("pgeRegExTester.AccessibleName");

        this.pgeRegExTester.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeRegExTester.Anchor");

        this.pgeRegExTester.AutoScroll = (bool) resources.GetObject("pgeRegExTester.AutoScroll");

        this.pgeRegExTester.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeRegExTester.AutoScrollMargin");

        this.pgeRegExTester.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeRegExTester.AutoScrollMinSize");

        this.pgeRegExTester.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeRegExTester.BackgroundImage");

        this.pgeRegExTester.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkSingleLine, this.txtResults, this.txtSource, this.Label3, this.btnReplace, this.btnSplit, this.btnFind, this.txtReplace, this.txtRegEx, this.Label1, this.Label2, this.lblResultCount, this.Label4, this.chkMultiline, this.chkIgnoreCase, this.chkShowCaptures, this.chkShowGroups});

        this.pgeRegExTester.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeRegExTester.Dock");

        this.pgeRegExTester.Enabled = (bool) resources.GetObject("pgeRegExTester.Enabled");

        this.pgeRegExTester.Font = (System.Drawing.Font) resources.GetObject("pgeRegExTester.Font");

        this.pgeRegExTester.ImageIndex = (int) resources.GetObject("pgeRegExTester.ImageIndex");

        this.pgeRegExTester.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeRegExTester.ImeMode");

        this.pgeRegExTester.Location = (System.Drawing.Point) resources.GetObject("pgeRegExTester.Location");

        this.pgeRegExTester.Name = "pgeRegExTester";

        this.pgeRegExTester.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeRegExTester.RightToLeft");

        this.pgeRegExTester.Size = (System.Drawing.Size) resources.GetObject("pgeRegExTester.Size");

        this.pgeRegExTester.TabIndex = (int) resources.GetObject("pgeRegExTester.TabIndex");

        this.pgeRegExTester.Text = resources.GetString("pgeRegExTester.Text");

        this.pgeRegExTester.ToolTipText = resources.GetString("pgeRegExTester.ToolTipText");

        this.pgeRegExTester.Visible = (bool) resources.GetObject("pgeRegExTester.Visible");

        //

        //chkSingleLine

        //

        this.chkSingleLine.AccessibleDescription = resources.GetString("chkSingleLine.AccessibleDescription");

        this.chkSingleLine.AccessibleName = resources.GetString("chkSingleLine.AccessibleName");

        this.chkSingleLine.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkSingleLine.Anchor");

        this.chkSingleLine.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkSingleLine.Appearance");

        this.chkSingleLine.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkSingleLine.BackgroundImage");

        this.chkSingleLine.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkSingleLine.CheckAlign");

        this.chkSingleLine.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkSingleLine.Dock");

        this.chkSingleLine.Enabled = (bool) resources.GetObject("chkSingleLine.Enabled");

        this.chkSingleLine.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkSingleLine.FlatStyle");

        this.chkSingleLine.Font = (System.Drawing.Font) resources.GetObject("chkSingleLine.Font");

        this.chkSingleLine.Image = (System.Drawing.Image) resources.GetObject("chkSingleLine.Image");

        this.chkSingleLine.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkSingleLine.ImageAlign");

        this.chkSingleLine.ImageIndex = (int) resources.GetObject("chkSingleLine.ImageIndex");

        this.chkSingleLine.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkSingleLine.ImeMode");

        this.chkSingleLine.Location = (System.Drawing.Point) resources.GetObject("chkSingleLine.Location");

        this.chkSingleLine.Name = "chkSingleLine";

        this.chkSingleLine.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkSingleLine.RightToLeft");

        this.chkSingleLine.Size = (System.Drawing.Size) resources.GetObject("chkSingleLine.Size");

        this.chkSingleLine.TabIndex = (int) resources.GetObject("chkSingleLine.TabIndex");

        this.chkSingleLine.Text = resources.GetString("chkSingleLine.Text");

        this.chkSingleLine.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkSingleLine.TextAlign");

        this.chkSingleLine.Visible = (bool) resources.GetObject("chkSingleLine.Visible");

        //

        //txtResults

        //

        this.txtResults.AcceptsReturn = true;

        this.txtResults.AcceptsTab = true;

        this.txtResults.AccessibleDescription = resources.GetString("txtResults.AccessibleDescription");

        this.txtResults.AccessibleName = resources.GetString("txtResults.AccessibleName");

        this.txtResults.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtResults.Anchor");

        this.txtResults.AutoSize = (bool) resources.GetObject("txtResults.AutoSize");

        this.txtResults.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtResults.BackgroundImage");

        this.txtResults.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtResults.Dock");

        this.txtResults.Enabled = (bool) resources.GetObject("txtResults.Enabled");

        this.txtResults.Font = (System.Drawing.Font) resources.GetObject("txtResults.Font");

        this.txtResults.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtResults.ImeMode");

        this.txtResults.Location = (System.Drawing.Point) resources.GetObject("txtResults.Location");

        this.txtResults.MaxLength = (int) resources.GetObject("txtResults.MaxLength");

        this.txtResults.Multiline = (bool) resources.GetObject("txtResults.Multiline");

        this.txtResults.Name = "txtResults";

        this.txtResults.PasswordChar = (char) resources.GetObject("txtResults.PasswordChar");

        this.txtResults.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtResults.RightToLeft");

        this.txtResults.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtResults.ScrollBars");

        this.txtResults.Size = (System.Drawing.Size) resources.GetObject("txtResults.Size");

        this.txtResults.TabIndex = (int) resources.GetObject("txtResults.TabIndex");

        this.txtResults.Text = resources.GetString("txtResults.Text");

        this.txtResults.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtResults.TextAlign");

        this.txtResults.Visible = (bool) resources.GetObject("txtResults.Visible");

        this.txtResults.WordWrap = (bool) resources.GetObject("txtResults.WordWrap");

        //

        //txtSource

        //

        this.txtSource.AcceptsReturn = true;

        this.txtSource.AcceptsTab = true;

        this.txtSource.AccessibleDescription = resources.GetString("txtSource.AccessibleDescription");

        this.txtSource.AccessibleName = resources.GetString("txtSource.AccessibleName");

        this.txtSource.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtSource.Anchor");

        this.txtSource.AutoSize = (bool) resources.GetObject("txtSource.AutoSize");

        this.txtSource.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtSource.BackgroundImage");

        this.txtSource.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtSource.Dock");

        this.txtSource.Enabled = (bool) resources.GetObject("txtSource.Enabled");

        this.txtSource.Font = (System.Drawing.Font) resources.GetObject("txtSource.Font");

        this.txtSource.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtSource.ImeMode");

        this.txtSource.Location = (System.Drawing.Point) resources.GetObject("txtSource.Location");

        this.txtSource.MaxLength = (int) resources.GetObject("txtSource.MaxLength");

        this.txtSource.Multiline = (bool) resources.GetObject("txtSource.Multiline");

        this.txtSource.Name = "txtSource";

        this.txtSource.PasswordChar = (char) resources.GetObject("txtSource.PasswordChar");

        this.txtSource.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtSource.RightToLeft");

        this.txtSource.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtSource.ScrollBars");

        this.txtSource.Size = (System.Drawing.Size) resources.GetObject("txtSource.Size");

        this.txtSource.TabIndex = (int) resources.GetObject("txtSource.TabIndex");

        this.txtSource.Text = resources.GetString("txtSource.Text");

        this.txtSource.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtSource.TextAlign");

        this.txtSource.Visible = (bool) resources.GetObject("txtSource.Visible");

        this.txtSource.WordWrap = (bool) resources.GetObject("txtSource.WordWrap");

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

        //btnReplace

        //

        this.btnReplace.AccessibleDescription = resources.GetString("btnReplace.AccessibleDescription");

        this.btnReplace.AccessibleName = resources.GetString("btnReplace.AccessibleName");

        this.btnReplace.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnReplace.Anchor");

        this.btnReplace.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnReplace.BackgroundImage");

        this.btnReplace.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnReplace.Dock");

        this.btnReplace.Enabled = (bool) resources.GetObject("btnReplace.Enabled");

        this.btnReplace.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnReplace.FlatStyle");

        this.btnReplace.Font = (System.Drawing.Font) resources.GetObject("btnReplace.Font");

        this.btnReplace.Image = (System.Drawing.Image) resources.GetObject("btnReplace.Image");

        this.btnReplace.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnReplace.ImageAlign");

        this.btnReplace.ImageIndex = (int) resources.GetObject("btnReplace.ImageIndex");

        this.btnReplace.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnReplace.ImeMode");

        this.btnReplace.Location = (System.Drawing.Point) resources.GetObject("btnReplace.Location");

        this.btnReplace.Name = "btnReplace";

        this.btnReplace.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnReplace.RightToLeft");

        this.btnReplace.Size = (System.Drawing.Size) resources.GetObject("btnReplace.Size");

        this.btnReplace.TabIndex = (int) resources.GetObject("btnReplace.TabIndex");

        this.btnReplace.Text = resources.GetString("btnReplace.Text");

        this.btnReplace.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnReplace.TextAlign");

        this.btnReplace.Visible = (bool) resources.GetObject("btnReplace.Visible");

        //

        //btnSplit

        //

        this.btnSplit.AccessibleDescription = resources.GetString("btnSplit.AccessibleDescription");

        this.btnSplit.AccessibleName = resources.GetString("btnSplit.AccessibleName");

        this.btnSplit.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSplit.Anchor");

        this.btnSplit.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSplit.BackgroundImage");

        this.btnSplit.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSplit.Dock");

        this.btnSplit.Enabled = (bool) resources.GetObject("btnSplit.Enabled");

        this.btnSplit.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSplit.FlatStyle");

        this.btnSplit.Font = (System.Drawing.Font) resources.GetObject("btnSplit.Font");

        this.btnSplit.Image = (System.Drawing.Image) resources.GetObject("btnSplit.Image");

        this.btnSplit.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSplit.ImageAlign");

        this.btnSplit.ImageIndex = (int) resources.GetObject("btnSplit.ImageIndex");

        this.btnSplit.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSplit.ImeMode");

        this.btnSplit.Location = (System.Drawing.Point) resources.GetObject("btnSplit.Location");

        this.btnSplit.Name = "btnSplit";

        this.btnSplit.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSplit.RightToLeft");

        this.btnSplit.Size = (System.Drawing.Size) resources.GetObject("btnSplit.Size");

        this.btnSplit.TabIndex = (int) resources.GetObject("btnSplit.TabIndex");

        this.btnSplit.Text = resources.GetString("btnSplit.Text");

        this.btnSplit.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSplit.TextAlign");

        this.btnSplit.Visible = (bool) resources.GetObject("btnSplit.Visible");

        //

        //btnFind

        //

        this.btnFind.AccessibleDescription = resources.GetString("btnFind.AccessibleDescription");

        this.btnFind.AccessibleName = resources.GetString("btnFind.AccessibleName");

        this.btnFind.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnFind.Anchor");

        this.btnFind.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnFind.BackgroundImage");

        this.btnFind.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnFind.Dock");

        this.btnFind.Enabled = (bool) resources.GetObject("btnFind.Enabled");

        this.btnFind.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnFind.FlatStyle");

        this.btnFind.Font = (System.Drawing.Font) resources.GetObject("btnFind.Font");

        this.btnFind.Image = (System.Drawing.Image) resources.GetObject("btnFind.Image");

        this.btnFind.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFind.ImageAlign");

        this.btnFind.ImageIndex = (int) resources.GetObject("btnFind.ImageIndex");

        this.btnFind.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnFind.ImeMode");

        this.btnFind.Location = (System.Drawing.Point) resources.GetObject("btnFind.Location");

        this.btnFind.Name = "btnFind";

        this.btnFind.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnFind.RightToLeft");

        this.btnFind.Size = (System.Drawing.Size) resources.GetObject("btnFind.Size");

        this.btnFind.TabIndex = (int) resources.GetObject("btnFind.TabIndex");

        this.btnFind.Text = resources.GetString("btnFind.Text");

        this.btnFind.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFind.TextAlign");

        this.btnFind.Visible = (bool) resources.GetObject("btnFind.Visible");

        //

        //txtReplace

        //

        this.txtReplace.AccessibleDescription = resources.GetString("txtReplace.AccessibleDescription");

        this.txtReplace.AccessibleName = resources.GetString("txtReplace.AccessibleName");

        this.txtReplace.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtReplace.Anchor");

        this.txtReplace.AutoSize = (bool) resources.GetObject("txtReplace.AutoSize");

        this.txtReplace.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtReplace.BackgroundImage");

        this.txtReplace.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtReplace.Dock");

        this.txtReplace.Enabled = (bool) resources.GetObject("txtReplace.Enabled");

        this.txtReplace.Font = (System.Drawing.Font) resources.GetObject("txtReplace.Font");

        this.txtReplace.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtReplace.ImeMode");

        this.txtReplace.Location = (System.Drawing.Point) resources.GetObject("txtReplace.Location");

        this.txtReplace.MaxLength = (int) resources.GetObject("txtReplace.MaxLength");

        this.txtReplace.Multiline = (bool) resources.GetObject("txtReplace.Multiline");

        this.txtReplace.Name = "txtReplace";

        this.txtReplace.PasswordChar = (char) resources.GetObject("txtReplace.PasswordChar");

        this.txtReplace.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtReplace.RightToLeft");

        this.txtReplace.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtReplace.ScrollBars");

        this.txtReplace.Size = (System.Drawing.Size) resources.GetObject("txtReplace.Size");

        this.txtReplace.TabIndex = (int) resources.GetObject("txtReplace.TabIndex");

        this.txtReplace.Text = resources.GetString("txtReplace.Text");

        this.txtReplace.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtReplace.TextAlign");

        this.txtReplace.Visible = (bool) resources.GetObject("txtReplace.Visible");

        this.txtReplace.WordWrap = (bool) resources.GetObject("txtReplace.WordWrap");

        //

        //txtRegEx

        //

        this.txtRegEx.AccessibleDescription = resources.GetString("txtRegEx.AccessibleDescription");

        this.txtRegEx.AccessibleName = resources.GetString("txtRegEx.AccessibleName");

        this.txtRegEx.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtRegEx.Anchor");

        this.txtRegEx.AutoSize = (bool) resources.GetObject("txtRegEx.AutoSize");

        this.txtRegEx.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtRegEx.BackgroundImage");

        this.txtRegEx.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtRegEx.Dock");

        this.txtRegEx.Enabled = (bool) resources.GetObject("txtRegEx.Enabled");

        this.txtRegEx.Font = (System.Drawing.Font) resources.GetObject("txtRegEx.Font");

        this.txtRegEx.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtRegEx.ImeMode");

        this.txtRegEx.Location = (System.Drawing.Point) resources.GetObject("txtRegEx.Location");

        this.txtRegEx.MaxLength = (int) resources.GetObject("txtRegEx.MaxLength");

        this.txtRegEx.Multiline = (bool) resources.GetObject("txtRegEx.Multiline");

        this.txtRegEx.Name = "txtRegEx";

        this.txtRegEx.PasswordChar = (char) resources.GetObject("txtRegEx.PasswordChar");

        this.txtRegEx.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtRegEx.RightToLeft");

        this.txtRegEx.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtRegEx.ScrollBars");

        this.txtRegEx.Size = (System.Drawing.Size) resources.GetObject("txtRegEx.Size");

        this.txtRegEx.TabIndex = (int) resources.GetObject("txtRegEx.TabIndex");

        this.txtRegEx.Text = resources.GetString("txtRegEx.Text");

        this.txtRegEx.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtRegEx.TextAlign");

        this.txtRegEx.Visible = (bool) resources.GetObject("txtRegEx.Visible");

        this.txtRegEx.WordWrap = (bool) resources.GetObject("txtRegEx.WordWrap");

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

        //lblResultCount

        //

        this.lblResultCount.AccessibleDescription = resources.GetString("lblResultCount.AccessibleDescription");

        this.lblResultCount.AccessibleName = resources.GetString("lblResultCount.AccessibleName");

        this.lblResultCount.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblResultCount.Anchor");

        this.lblResultCount.AutoSize = (bool) resources.GetObject("lblResultCount.AutoSize");

        this.lblResultCount.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblResultCount.Dock");

        this.lblResultCount.Enabled = (bool) resources.GetObject("lblResultCount.Enabled");

        this.lblResultCount.Font = (System.Drawing.Font) resources.GetObject("lblResultCount.Font");

        this.lblResultCount.ForeColor = System.Drawing.SystemColors.ControlText;

        this.lblResultCount.Image = (System.Drawing.Image) resources.GetObject("lblResultCount.Image");

        this.lblResultCount.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblResultCount.ImageAlign");

        this.lblResultCount.ImageIndex = (int) resources.GetObject("lblResultCount.ImageIndex");

        this.lblResultCount.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblResultCount.ImeMode");

        this.lblResultCount.Location = (System.Drawing.Point) resources.GetObject("lblResultCount.Location");

        this.lblResultCount.Name = "lblResultCount";

        this.lblResultCount.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblResultCount.RightToLeft");

        this.lblResultCount.Size = (System.Drawing.Size) resources.GetObject("lblResultCount.Size");

        this.lblResultCount.TabIndex = (int) resources.GetObject("lblResultCount.TabIndex");

        this.lblResultCount.Text = resources.GetString("lblResultCount.Text");

        this.lblResultCount.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblResultCount.TextAlign");

        this.lblResultCount.Visible = (bool) resources.GetObject("lblResultCount.Visible");

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

        //chkMultiline

        //

        this.chkMultiline.AccessibleDescription = resources.GetString("chkMultiline.AccessibleDescription");

        this.chkMultiline.AccessibleName = resources.GetString("chkMultiline.AccessibleName");

        this.chkMultiline.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkMultiline.Anchor");

        this.chkMultiline.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkMultiline.Appearance");

        this.chkMultiline.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkMultiline.BackgroundImage");

        this.chkMultiline.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMultiline.CheckAlign");

        this.chkMultiline.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkMultiline.Dock");

        this.chkMultiline.Enabled = (bool) resources.GetObject("chkMultiline.Enabled");

        this.chkMultiline.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkMultiline.FlatStyle");

        this.chkMultiline.Font = (System.Drawing.Font) resources.GetObject("chkMultiline.Font");

        this.chkMultiline.Image = (System.Drawing.Image) resources.GetObject("chkMultiline.Image");

        this.chkMultiline.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMultiline.ImageAlign");

        this.chkMultiline.ImageIndex = (int) resources.GetObject("chkMultiline.ImageIndex");

        this.chkMultiline.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkMultiline.ImeMode");

        this.chkMultiline.Location = (System.Drawing.Point) resources.GetObject("chkMultiline.Location");

        this.chkMultiline.Name = "chkMultiline";

        this.chkMultiline.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkMultiline.RightToLeft");

        this.chkMultiline.Size = (System.Drawing.Size) resources.GetObject("chkMultiline.Size");

        this.chkMultiline.TabIndex = (int) resources.GetObject("chkMultiline.TabIndex");

        this.chkMultiline.Text = resources.GetString("chkMultiline.Text");

        this.chkMultiline.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkMultiline.TextAlign");

        this.chkMultiline.Visible = (bool) resources.GetObject("chkMultiline.Visible");

        //

        //chkIgnoreCase

        //

        this.chkIgnoreCase.AccessibleDescription = resources.GetString("chkIgnoreCase.AccessibleDescription");

        this.chkIgnoreCase.AccessibleName = resources.GetString("chkIgnoreCase.AccessibleName");

        this.chkIgnoreCase.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkIgnoreCase.Anchor");

        this.chkIgnoreCase.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkIgnoreCase.Appearance");

        this.chkIgnoreCase.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkIgnoreCase.BackgroundImage");

        this.chkIgnoreCase.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIgnoreCase.CheckAlign");

        this.chkIgnoreCase.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkIgnoreCase.Dock");

        this.chkIgnoreCase.Enabled = (bool) resources.GetObject("chkIgnoreCase.Enabled");

        this.chkIgnoreCase.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkIgnoreCase.FlatStyle");

        this.chkIgnoreCase.Font = (System.Drawing.Font) resources.GetObject("chkIgnoreCase.Font");

        this.chkIgnoreCase.Image = (System.Drawing.Image) resources.GetObject("chkIgnoreCase.Image");

        this.chkIgnoreCase.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIgnoreCase.ImageAlign");

        this.chkIgnoreCase.ImageIndex = (int) resources.GetObject("chkIgnoreCase.ImageIndex");

        this.chkIgnoreCase.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkIgnoreCase.ImeMode");

        this.chkIgnoreCase.Location = (System.Drawing.Point) resources.GetObject("chkIgnoreCase.Location");

        this.chkIgnoreCase.Name = "chkIgnoreCase";

        this.chkIgnoreCase.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkIgnoreCase.RightToLeft");

        this.chkIgnoreCase.Size = (System.Drawing.Size) resources.GetObject("chkIgnoreCase.Size");

        this.chkIgnoreCase.TabIndex = (int) resources.GetObject("chkIgnoreCase.TabIndex");

        this.chkIgnoreCase.Text = resources.GetString("chkIgnoreCase.Text");

        this.chkIgnoreCase.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIgnoreCase.TextAlign");

        this.chkIgnoreCase.Visible = (bool) resources.GetObject("chkIgnoreCase.Visible");

        //

        //chkShowCaptures

        //

        this.chkShowCaptures.AccessibleDescription = resources.GetString("chkShowCaptures.AccessibleDescription");

        this.chkShowCaptures.AccessibleName = resources.GetString("chkShowCaptures.AccessibleName");

        this.chkShowCaptures.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkShowCaptures.Anchor");

        this.chkShowCaptures.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkShowCaptures.Appearance");

        this.chkShowCaptures.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkShowCaptures.BackgroundImage");

        this.chkShowCaptures.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkShowCaptures.CheckAlign");

        this.chkShowCaptures.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkShowCaptures.Dock");

        this.chkShowCaptures.Enabled = (bool) resources.GetObject("chkShowCaptures.Enabled");

        this.chkShowCaptures.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkShowCaptures.FlatStyle");

        this.chkShowCaptures.Font = (System.Drawing.Font) resources.GetObject("chkShowCaptures.Font");

        this.chkShowCaptures.Image = (System.Drawing.Image) resources.GetObject("chkShowCaptures.Image");

        this.chkShowCaptures.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkShowCaptures.ImageAlign");

        this.chkShowCaptures.ImageIndex = (int) resources.GetObject("chkShowCaptures.ImageIndex");

        this.chkShowCaptures.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkShowCaptures.ImeMode");

        this.chkShowCaptures.Location = (System.Drawing.Point) resources.GetObject("chkShowCaptures.Location");

        this.chkShowCaptures.Name = "chkShowCaptures";

        this.chkShowCaptures.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkShowCaptures.RightToLeft");

        this.chkShowCaptures.Size = (System.Drawing.Size) resources.GetObject("chkShowCaptures.Size");

        this.chkShowCaptures.TabIndex = (int) resources.GetObject("chkShowCaptures.TabIndex");

        this.chkShowCaptures.Text = resources.GetString("chkShowCaptures.Text");

        this.chkShowCaptures.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkShowCaptures.TextAlign");

        this.chkShowCaptures.Visible = (bool) resources.GetObject("chkShowCaptures.Visible");

        //

        //chkShowGroups

        //

        this.chkShowGroups.AccessibleDescription = resources.GetString("chkShowGroups.AccessibleDescription");

        this.chkShowGroups.AccessibleName = resources.GetString("chkShowGroups.AccessibleName");

        this.chkShowGroups.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkShowGroups.Anchor");

        this.chkShowGroups.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkShowGroups.Appearance");

        this.chkShowGroups.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkShowGroups.BackgroundImage");

        this.chkShowGroups.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkShowGroups.CheckAlign");

        this.chkShowGroups.Checked = true;

        this.chkShowGroups.CheckState = System.Windows.Forms.CheckState.Checked;

        this.chkShowGroups.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkShowGroups.Dock");

        this.chkShowGroups.Enabled = (bool) resources.GetObject("chkShowGroups.Enabled");

        this.chkShowGroups.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkShowGroups.FlatStyle");

        this.chkShowGroups.Font = (System.Drawing.Font) resources.GetObject("chkShowGroups.Font");

        this.chkShowGroups.Image = (System.Drawing.Image) resources.GetObject("chkShowGroups.Image");

        this.chkShowGroups.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkShowGroups.ImageAlign");

        this.chkShowGroups.ImageIndex = (int) resources.GetObject("chkShowGroups.ImageIndex");

        this.chkShowGroups.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkShowGroups.ImeMode");

        this.chkShowGroups.Location = (System.Drawing.Point) resources.GetObject("chkShowGroups.Location");

        this.chkShowGroups.Name = "chkShowGroups";

        this.chkShowGroups.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkShowGroups.RightToLeft");

        this.chkShowGroups.Size = (System.Drawing.Size) resources.GetObject("chkShowGroups.Size");

        this.chkShowGroups.TabIndex = (int) resources.GetObject("chkShowGroups.TabIndex");

        this.chkShowGroups.Text = resources.GetString("chkShowGroups.Text");

        this.chkShowGroups.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkShowGroups.TextAlign");

        this.chkShowGroups.Visible = (bool) resources.GetObject("chkShowGroups.Visible");

        //

        //OpenFileDialog1

        //

        this.OpenFileDialog1.Filter = resources.GetString("OpenFileDialog1.Filter");

        this.OpenFileDialog1.Title = resources.GetString("OpenFileDialog1.Title");

        //

        //OpenFileDialog2

        //

        this.OpenFileDialog2.Filter = resources.GetString("OpenFileDialog2.Filter");

        this.OpenFileDialog2.Title = resources.GetString("OpenFileDialog2.Title");

        //

        //lblValid

        //

        this.lblValid.AccessibleDescription = (string) resources.GetObject("lblValid.AccessibleDescription");

        this.lblValid.AccessibleName = (string) resources.GetObject("lblValid.AccessibleName");

        this.lblValid.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblValid.Anchor");

        this.lblValid.AutoSize = (bool) resources.GetObject("lblValid.AutoSize");

        this.lblValid.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblValid.Dock");

        this.lblValid.Enabled = (bool) resources.GetObject("lblValid.Enabled");

        this.lblValid.Font = (System.Drawing.Font) resources.GetObject("lblValid.Font");

        this.lblValid.Image = (System.Drawing.Image) resources.GetObject("lblValid.Image");

        this.lblValid.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblValid.ImageAlign");

        this.lblValid.ImageIndex = (int) resources.GetObject("lblValid.ImageIndex");

        this.lblValid.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblValid.ImeMode");

        this.lblValid.Location = (System.Drawing.Point) resources.GetObject("lblValid.Location");

        this.lblValid.Name = "lblValid";

        this.lblValid.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblValid.RightToLeft");

        this.lblValid.Size = (System.Drawing.Size) resources.GetObject("lblValid.Size");

        this.lblValid.TabIndex = (int) resources.GetObject("lblValid.TabIndex");

        this.lblValid.Text = resources.GetString("lblValid.Text");

        this.lblValid.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblValid.TextAlign");

        this.lblValid.Visible = (bool) resources.GetObject("lblValid.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.TabControl1});

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

        this.TabControl1.ResumeLayout(false);

        this.pgeSimple.ResumeLayout(false);

        this.GroupBox1.ResumeLayout(false);

        this.grpValidation.ResumeLayout(false);

        this.pgeScreenScrape.ResumeLayout(false);

        this.pgeRegExTester.ResumeLayout(false);

        this.ResumeLayout(false);
		this.btnValidate.Click +=new EventHandler(btnValidate_Click);
		this.btnFind.Click +=new EventHandler(btnFind_Click);
		this.btnFindNumber.Click +=new EventHandler(btnFindNumber_Click);
		this.btnReplace.Click +=new EventHandler(btnReplace_Click);
		this.btnScrape.Click +=new EventHandler(btnScrape_Click);
		this.btnSplit.Click +=new EventHandler(btnSplit_Click);
		this.btnValidate.Click +=new EventHandler(btnValidate_Click);
		this.lvwLinks.DoubleClick +=new EventHandler(lvLinks_DoubleClick);
		this.lvwImages.DoubleClick +=new EventHandler(lvImages_DoubleClick);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.optImages.CheckedChanged +=new EventHandler(RadioButtons_CheckedChanged);
		this.optLinks.CheckedChanged +=new EventHandler(RadioButtons_CheckedChanged);
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

    private Hashtable htImages;
    protected frmImageViewer fImageViewer;
    private frmStatus fStatus;
    public string strDomain;
    public string strUrlEntered;
    private HttpWebResponse wresScrape;

    // the "Find" button click event on the "RegEx Tester" tab. This routin
    // finds matches in the source text and displays the group and capture values in 
    // the results TextBox.

    private void btnFind_Click(object sender, System.EventArgs e) // btnFind.Click;
		{
        Regex re;
        RegexOptions reOpt = GetRegexOptions();

        try {
            re = new Regex(txtRegEx.Text, reOpt);

       } 
		catch(Exception exp)
		{

            MessageBox.Show("An error was encountered when attempting to parse the source text. This is often caused by an invalid regex pattern. Check your expression and try again. Exp.Msg=" + exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;

        }

        // Get the collection of matches resulting from applying the pattern to the

        // source text.

        MatchCollection mc = re.Matches(txtSource.Text);

        // Display the number of matches and clear any existing results.

        lblResultCount.Text = mc.Count.ToString() + " matches";
        txtResults.Clear();

        // Iterate through the collection of matches and, based on UI settings, 

        // display the values of the groups and/or captures.

        foreach(Match m in mc)
			{
            AppendResults("'" + m.Value + "' at index " + m.Index);
            if (m.Groups.Count > 1 && chkShowGroups.Checked) 
				{

                // Skip the 0th group, which is the entire Match object.
                for(int i = 1; i<m.Groups.Count;i++)
					{
                    // Get a reference to the corresponding group.
                    Group g = m.Groups[i];
                    AppendResults(string.Format("   group({0}) = '{1}'", i, g.Value));
                    if (chkShowCaptures.Checked == true) {
                        // Get the capture collection for this group.                
                        CaptureCollection cc = g.Captures;
                        // Display information on each capture.
                        foreach(Capture c in cc)
							{
                            AppendResults(string.Format("      capture '{0}' at index {1}", c.Value, c.Index));
                        }

                    }

                }

            }

        }

    }

    // This routine handles the "Find the Number!" button Click event. It finds the 

    // first number in a character string and displays the number and its starting 

    // position in the string.

    private void btnFindNumber_Click(object sender, System.EventArgs e) //btnFindNumber.Click;
{

        // Create an instance of RegEx and pass in the pattern, which will find one 

        // or more digits.

        Regex re = new Regex(@"\d+");

        // Call Match, passing in the source text.
        Match m = re.Match(txtFindNumber.Text);
        // if a match is found, show the results. if not, display an "error" message.
		if (m.Success) 
		{
			lblResults.Text = string.Format("RegEx found " + m.Value + " at position " + m.Index.ToString());
		}
		else 
		{
			lblResults.Text = "You didn't enter a string containing a number!";
		}
    }

    // the Click event for the "Replace" button. Replaces text in the source
    // with the replacement text when a match is found.

    private void btnReplace_Click(object sender, System.EventArgs e) //btnReplace.Click;
		{
        try {
            txtResults.Text = Regex.Replace(txtSource.Text, txtRegEx.Text, txtReplace.Text, GetRegexOptions());
		
       } 
		catch(Exception exp){

            MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

    }

    // the "Scrape" button click event.

    private void btnScrape_Click(object sender, System.EventArgs e) //btnScrape.Click;
		{
        string strHttpSource;

        if (UrlIsValid()) {
            // Get a string containing the Web page's source code. See the two custom
            // functions used here for further comments.

            try {

                strHttpSource = ConvertStreamTostring(GetHttpStream(txtURL.Text));

           } 
			catch(Exception exp)
				{
                // Set text to exp.Message to show the custom error message set in the 
                // function that was called.

                MessageBox.Show(exp.Message, this.Text,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            string strRegExPattern;

            // Assign a variable to the full Url entered by the user. 
            strUrlEntered = txtURL.Text.Trim();

            // Get the Domain name for use in various places. It's best to set the 
            // value in the Click event so that the items displayed in either ListView
            // control are always associated with the correct Domain name. if this
            // value is assigned elsewhere, the user can change the Domain name and 
            // then double-click an item in the ListView, which could cause an invalid 
            // Url for the item.

            string [] astrDomain = Regex.Split(strUrlEntered, "/");

            // The first element (0) is "http:" and the 3rd element is the actual
            // Domain name.

            strDomain = astrDomain[0] + "//" + astrDomain[2];
            if (optLinks.Checked) 
				{
                ShowStatusIndicators("Connecting to Web page to screen scrape the links. Please stand by...");
                lvwLinks.Items.Clear();

                // The regular expression used here to parse an HTML anchor, e.g.,
                // <a href="http://www.microsoft.com/net">Microsoft</a> is explained 
                // as follows:
                //   <a          The beginning of the HTML anchor
                //   \s+         One or more white space characters
                //   href        Continuing with exact text in HTML anchor
                //   \s*         Zero or more white space characters
                //   =           Continuing with exact text in HTML anchor
                //   \s*         Zero or more white space characters
                //   ""?         Zero or none quotation mark (escaped)
                //   (           Start of group defining a substring: The anchor URL.
                //   [^"" >]+    One or more matches of any character except those 
                //               in brackets.
                //   )           End of first group defining a substring
                //   ""?         Zero or none quotation mark (escaped)
                //   >           Continuing with exact text in HTML anchor
                //   (.+)        A group matching any character: The anchor text.
                //   </a>        Ending exact text of HTML anchor               
                //
                // CAUTION: if you want to experiment with these patterns in the 
                // RegEx Tester, make sure you un-escape the double quotes.
                strRegExPattern = @"<a\s+href\s*=\s*""?([^"" >]+)""?>(.+)</a>";
				}
            else 
				{
                ShowStatusIndicators("Connecting to Web page to screen scrape the images. Please stand by...");
                htImages = new Hashtable();
                lvwImages.Items.Clear();
                // The regular expression to scrape images is conceptually similar to 
                // the pattern for scraping HTML anchors. However, in this case the 
                // pattern is conciderably more complex because we are capturing up to
                // four different attributes which can appear in any order.
                //
                // To keep the length and complexity of the regular expression used 
                // here within reason, the following assumptions are made about the 
                // HTML <img> tags being processed on any given Web page:
                //
                //   1. The src attribute is always present. It is the only required 
                //      attribute.
                //   2. The src attribute precedes width and height. if not, width and
                //      height are not grabbed.
                //   3. The alt attribute follows width and height. if not, alt is not 
                //      grabbed.
                //   4. Width and height can follow src in any order relative to each 
                //      other. The pattern covers both options.
                //
                // This ensures that all images on the page are scaped. It means, 
                // however, that some of the other attribute data may not appear.
                //
                // Some of the key phrases used in this pattern are:
                // 
                //   [^>]+       Match any characters except >. This is how you can 
                //               move to the next attribute you are interested in.
                //   (?:         Start a non-capturing group. This is used with a
                //               closing )? to create an optional group (zero or one
                //               match). This is how you make all attributes optional
                //               except src.
                //   |           Used with width and height as an || expression. Notice
                //               that in the first pair width comes first, and in the 
                //               second pair, the order is reversed.

                strRegExPattern = @"<img[^>]+(src)\s*=\s*""?([^ "">]+)""?(?:[^>]+(width|height)\s*=\s*""?([^ "">]+)""?\s+(height|width)\s*=\s*""?([^ "">]+)""?)?(?:[^>]+(alt)\s*=\s*""?([^"">]+)""?)?";

            }
            Regex re = new Regex(strRegExPattern, RegexOptions.IgnoreCase);
            Match m = re.Match(strHttpSource);

            // Process the HTML source code. Because the source is a long string, 
            // instead of using Matches method use the more efficient Match(), which
            // only returns one match at a time. The Success property determines
            // whether another match exists. NextMatch() causes the iteration.
            while (m.Success)
			{
                if (optImages.Checked) {

                    string strWidth, strHeight;

                    // Because the pattern gives optional ordering for the width and 
                    // height attributes, determine which attribute was listed first
                    // in order, and then assign the proper Group item value.

					if (m.Groups[3].Value.ToLower() == "width") 
					{
						strWidth = m.Groups[4].Value;
						strHeight = m.Groups[6].Value;
					}
					else 
					{ // The height attribute came first;
						strWidth = m.Groups[6].Value;
						strHeight = m.Groups[4].Value;
					}

                    // Call AddImage to add an instance of the custom ImageAttributes 
                    // object to a Hashtable. See AddImage for further comments on why
                    // a Hashtable is used.
                    AddImage(new ImageAttributes(m.Groups[2].Value, m.Groups[8].Value, strHeight, strWidth));
					}
                else {

                    // Create a ListViewItem object and set the first column's 
                    // text ("src").
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = m.Groups[1].Value;
                    lvwLinks.Items.Add(lvi);
                }
                // Continue the loop to the next match.
                m = m.NextMatch();
			}

            HideStatusIndicators();

            // Display controls appropriate the results.

			if (optImages.Checked) 
			{

				if (htImages != null) 
				{

					FillImagesListView();
				}
				else 
				{

					MessageBox.Show("No images were found whose attributes matched the regular expression.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

				}
			}
			else 
			{
				if (lvwLinks.Items.Count == 0)
				{

					MessageBox.Show("No links were found whose Url matched the regular expression.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

				}

			}

        }

    }

    // the "Split" button click event. This routine splits the source text
    // into a string array instead of a MatchCollection (as in the "Find" button).
    // RegEx.Split is similar to string.Split except that it defines the delimiter
    // by using a regular expression rather than a single character.

    private void btnSplit_Click(object sender, System.EventArgs e) //btnSplit.Click;
	{
        // Clear existing results and then split the source text.

        txtResults.Clear();

        // Here we are calling the shared Split method, without the use of a 
        // RegEx instance.  A good split pattern to try is \s*,\s*, which creates 
        // an array of any characters separated by a comma. 
        // You can further modify the regular expression to discard any empty 
        // elements in the resulting string array: \s*[,]+\s*
        string[] astrResults;

        try {

            astrResults = Regex.Split(txtSource.Text, txtRegEx.Text, GetRegexOptions());
			
       } 
		catch(Exception exp)
		{
            MessageBox.Show("An error was encountered when attempting to parse the source text. This is often caused by an invalid regex pattern." +
                "  Check your expression and try again. Exp.Msg=" + exp.Message, this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return;

        }

        // To be split a string array of at least two elements must be created.

		if (astrResults.Length > 1) 
		{
			AppendResults("The source text was split into " + astrResults.Length + " items.");
            
			foreach(string s in astrResults)
			{
				AppendResults(s);
			}
		}
		else 
		{
			AppendResults("The source text could not be split. Check your regular expression pattern and try again.");
		}

    }

    // the Validate! button click event on the "Simple Samples" tab.

    private void btnValidate_Click(object sender, System.EventArgs e)
	{
        bool IsValid = true;

        // When performing validation, a couple of pattern elements are normally
        // used all of the time:
        //
        //   ^ and $     The source string can only contain what is in between, i.e.,
        //               a date. It's a good idea to wrap validation patterns in
        //               these characters or else it will merely match the pattern
        //               whereever it appears. For example, if you do not, this would 
        //               pass as a valid date in this application: "kjdi12-25-2000xpL" 
        //
        //   \s*         At the beginning and end of the string, this indicates
        //               that white space is acceptable.
        //
        // The following pattern checks whether the input string is a valid zip
        // code in the format ddddd or ddddd-dddd, where d is any digit 0-9. Key 
        // pattern elements used are:
        //
        //   \d          Any digit (0-9).
        //   |           A pipe denotes that the Zip code can either be 5 digits
        //               or 5 digits followed by a dash and four digits.
        //
		if (!Regex.IsMatch(txtZip.Text, @"^\s*(\d{5}|(\d{5}-\d{4}))\s*$")) 
		{
			txtZip.ForeColor = Color.Red;
			IsValid = false;
		}
		else 
		{
			txtZip.ForeColor = Color.Black;
		}

        // The following pattern checks whether the input string is a date in the 
        // format mm-dd-yy or mm-dd-yyyy. Key pattern elements used are:
        //
        //   \d{1,2}     Month and day numbers can have 1 or 2 digits. The use of
        //               (\d{4}|\d{2}) means the year can have 2 or 4 digits.
        //   (/|-)       Either the slash or the dash are valid date separators.
        //   \1          The separator used for the day and year must be the same
        //               as the separator used for month and day. The 1 refers to the
        //               first numbered group, defined by parentheses, e.g, (/|-).
        //   
        // You could improve on this pattern by ensuring that digits do not start with
        // a zero and that they are in a valid numerical range.
        //
		if (!Regex.IsMatch(txtDate.Text, @"^\s*\d{1,2}(/|-)\d{1,2}\1(\d{4}|\d{2})\s*$")) 
		{
			txtDate.ForeColor = Color.Red;
			IsValid = false;
		}
		else 
		{
			txtDate.ForeColor = Color.Black;
		}

        // The following pattern checks whether the input string is a valid email 
        // address in the form "name@domain.com". Actually, it does not have to be a 
        // ".com" address. Any combination of letters following the last period are 
        // fine. Also, the email name can have a dash or be separated by one or more 
        // periods. The Domain name can also have multiple words separated by periods. 
        // Thus, it will validate bob@hotmail.com and bill.michaels@us.office.gov.
        //
        //   ([\w-]+\.)*?    Zero or more matches of any character (a-z, A-Z, 0-9, and
        //                   underscore) or dash, followed by only one period.
        //   [\w-]           On either side of the @ character this ensures the 
        //                   address is in the form name@domainname.
        //   +\.             Ensures there is at least one period in the domain name.
        //
		if (!Regex.IsMatch(txtEmail.Text, @"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")) 
		{
			txtEmail.ForeColor = Color.Red;
			IsValid = false;
		}
		else 
		{
			txtEmail.ForeColor = Color.Black;
		}

		if (IsValid) 
		{
			lblValid.Visible = true;
		}
		else 
		{
			lblValid.Visible = false;
		}
    }

    // This routine handles the DoubleClick event for the "Images" ListView.
    // Double-clicking an image opens frmImageViewer, requests the image as a Stream
    // from the Web server, and then displays it in a PictureBox.

    private void lvImages_DoubleClick(object sender, System.EventArgs e) //lvwImages.DoubleClick;
	{
        // Wrap all code in the validation check to ensure the user has not changed
        // the Url to an invalid value before double-clicking an item.

        if (UrlIsValid()) 
			{
            string strImgSrc = lvwImages.SelectedItems[0].Text;
            ShowStatusIndicators("Connecting to Web page to retrieve the selected image. Please stand by...");
            if (fImageViewer == null) 
				{
                fImageViewer = new frmImageViewer();
            }

            // if the image path clicked by the user is not an absolute path, correct
            // it and then Show the ImageViewer Form.

            if (strImgSrc.Substring(0, 7) != @"http://") 
				{
                strImgSrc = MakeRelativeUrlAbsolute(strImgSrc);

            }

            fImageViewer.Show(strImgSrc);
            HideStatusIndicators();
        }

    }

    // This routine handles the DoubleClick event for the "Links" ListView. 

    // Double-clicking a link starts a new instance of Internet Explorer and 

    // navigates to the requested page.

    private void lvLinks_DoubleClick(object sender, System.EventArgs e)
	{
        // Wrap all code in the validation check to ensure the user has not changed
        // the Url to an invalid value before double-clicking an item.

        if (UrlIsValid()) 
			{
            string strClickedUrl = lvwLinks.SelectedItems[0].Text;
            ShowStatusIndicators("Starting Internet Explorer and connecting to the selected Web page. Please stand by...");

            // if the path to the page clicked by the user is not an absolute path, 
            // correct it and then start Internet Explorer, navigating to the page.

            if (strClickedUrl.Substring(0,7) != @"http://") 
				{
                strClickedUrl = MakeRelativeUrlAbsolute(strClickedUrl);
            }

            // It is either a root-relative or relative path. So make the relative 
            // Url into an absolute Url.

            Process.Start("IExplore.exe", strClickedUrl);
            HideStatusIndicators();
        }
    }

    // This routine handles the CheckedChanged event for the RadioButton controls on 
    // the "Screen Scrape" tab. The ListView controls are swapped out depending on 
    // which option is checked.

    private void RadioButtons_CheckedChanged(object sender, System.EventArgs e)
	{
		if (optLinks.Checked) 
		{
			lvwLinks.Visible = true;
			lvwImages.Visible = false;
		}
		else 
		{
			lvwImages.Visible = true;
			lvwLinks.Visible = false;
		}
    }

    // This routine adds an ImageAttributes object to the HashTable if it has not
    // already been added. The "Src" attribute is used as the key for lookups. if
    // the Src key already exists, the object is not added. This prevents identical
    // images from appearing in the list more than once.

    protected void AddImage(ImageAttributes imgAttr)
	{

        if (!htImages.Contains(imgAttr.Src)) 
			{
            htImages.Add(imgAttr.Src, imgAttr);
        }
    }

    // This is a helper routine for appending text results.

    private void AppendResults(string msg)
	{
        txtResults.AppendText(msg + @"/r/n");
    }

    // This function reads a Stream returned by an HttpWebResponse object and 
    // converts it to a string for RegEx processing.

    private string ConvertStreamTostring(Stream stmSource)
	{
        StreamReader sr = null;

		if (stmSource != null) 
		{
			try 
			{
				sr = new StreamReader(stmSource);
				// Read and return the entire contents of the stream.
				return sr.ReadToEnd();
			} 
			catch
			{

				// Don't show a MsgBox. Simply forward the custom error message 
				// from GetHttpStream().
				throw new Exception();
			}
			finally
			{
				// Clean up both the Stream and the StreamReader.
				wresScrape.Close();
				sr.Close();
			}
		}
		else
		{
			return null;
		}
    }

    // This routine iterates through a HashTable and adds a ListViewItem with
    // ListViewItem.SubItems for each of the custom ImageAttributes objects in
    // the HashTable.

    protected void FillImagesListView()
	{

        foreach(string strSrc in htImages.Keys)
		{

            // Create a ListViewItem object and set the first column's text.

            ListViewItem lvi = new ListViewItem();
            lvi.Text = strSrc;

            // Set the text in the remaining columns and add the ListViewItem object
            // to the ListView.

            ImageAttributes imgAttr = (ImageAttributes)(htImages[strSrc]);
                lvi.SubItems.Add(imgAttr.Alt);
                lvi.SubItems.Add(imgAttr.Height);
                lvi.SubItems.Add(imgAttr.Width);

            // Add the ListViewItem to the ListView's Items collection.
            lvwImages.Items.Add(lvi);
        }
    }

    // This function uses .NET classes that derive from System.Net.WebRequest to 
    // retrieve an HTTP response Stream that becomes the RegEx parsing source or the 
    // image to be displayed when called by frmImageViewer.Show().

    public Stream GetHttpStream(string url)
	{

        // Create the request using the WebRequestFactory.
        HttpWebRequest wreqScrape = (HttpWebRequest)(WebRequest.Create(url));

            wreqScrape.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0b; Windows NT 5.1)";
            wreqScrape.Method = "GET";
            wreqScrape.Timeout = 10000;

        try {
            // return the response stream.
            wresScrape = (HttpWebResponse)(wreqScrape.GetResponse());
            return wresScrape.GetResponseStream();

       } 
		catch
		{

            // the error is most likely caused by a mistyped Url or not having
            // a connection to the Internet, create a custom error message that
            // is forwarded back to the calling function.

            throw new Exception("There was an error retrieving the Web page " +
				"you requested. Please check the Url and your connection to " +
                "the Internet, and try again.");

        }
    }

    // This is a helper routine to retrieve various regular expression pattern 
    // matching options.

	private RegexOptions GetRegexOptions()
	{

		RegexOptions ro = new RegexOptions();
		// Using any of the RegExOptions is the same as placing the entire regular
		// expression in parentheses (i.e., making the entire pattern its own group)
		// and then prefacing it inside the left parenthesis with the option 
		// character. if you want finer control over an option --i.e., within a 
		// particular group--create a group within the pattern and use the same
		// syntax. In this case you would not want to use one of the RegexOptions
		// because these are applied to the entire pattern. To turn off an option 
		// simply negate it (e.g., to turn case sensitivity off you would type
		// ?-i: inside the left parenthesis of a group).
		//
		// All Options are off by default.
		//
		// The Ignorecase enum turns case sensitivity on/off for the entire pattern.
		// Using this enum is the same as typing (?i:OriginalPattern) using only 
		// regular expression syntax.
		if (chkIgnoreCase.Checked) 
		{ 
			ro = RegexOptions.IgnoreCase;
		}
			// The Singleline enum changes the behavior of the . (dot) character so that
			// it now matches any character (instead of its default behavior of any 
			// character except the newline character, \r or \n). Using this enum is the 
			// same as typing (?s:OriginalPattern) using only regular expression syntax.
			// 
			// Note also that multiple RegExOptions can be used when separated by the
			// bitwise || operator. (Alternatively, you could enable multiple options
			// using only regular expression syntax by placing options together after the
			// ? character. For example, to turn on Singleline mode and ignore case, you 
			// would type (?si:OriginalPattern).
			if (chkSingleLine.Checked) 
			{
				ro = ro | RegexOptions.Singleline;
			}

			// The Multiline enum changes the behavior of the ^ and $ characters so that
			// they now match the beginning and end of a line instead of the beginning
			// and of an entire string. Using this enum is the same as typing 
			// (?m:OriginalPattern) using only regular expression syntax.
			//
			// It may seem confusing that you can enable both Singleline and Multiline
			// modes, but the confusion likely stems from the misleading names given to 
			// these options. if you disregard their name and consider what they actually
			// effect, there is no conflict.
			if (chkMultiline.Checked) 
			{
				ro = ro | RegexOptions.Multiline;
			}

		return ro;
		}
	
    // This routine turns off the status indicators enabled by ShowStatusIndicators.

    private void HideStatusIndicators()
	{
        fStatus.Hide();
        this.Cursor = Cursors.Default;
    }

    // This function takes a relative Url and makes it absolute. It is a helper 
    // for the DoubleClick event handlers on the "Screen Scrape" tab. The "href" or 
    // "url" attributes can contain an absolute path, a root-relative path, or a 
    // relative path. if the path to the clicked item is not absolute, this function
    // makes it absolute by prefacing it with the Domain name and a slash, if needed.

    public string MakeRelativeUrlAbsolute(string strRelativeUrl)
	{

        // if it is a root-relative path (has a leading "/"), then it needs to be 
        // prefaced by the Domain name. if it is a relative Url it needs to be 
        // prefaced with the full Url as entered by the user. 
        // == it a root-relative path?

		if (strRelativeUrl.Substring(0, 1) == @"/") 
		{
			// Preface the root-relative path with the Domain name.
			return strDomain + strRelativeUrl;

		} 
		else if (strRelativeUrl.Substring(0, 3) == "../") 
		{
			// Remove the dots and preface the root-relative path with the 
			// Domain name.
			return strDomain + strRelativeUrl.Replace("../", "/");
		}
		else 
		{
			// It is a relative path.;
			// Check to see if the Url entered by the user has a trailing "/". if not, 
			// add one.
			if (strUrlEntered.EndsWith(@"/"))
			{
				return strUrlEntered + strRelativeUrl;
			}
			else 
			{
				return strUrlEntered + "/" + strRelativeUrl;
			}
				   }
		}

    // This routine provides user feedback by showing a small status form with a 
    // message and setting the WaitCursor to indicate a task is being performed.

    private void ShowStatusIndicators(string strMsg)
	{
        fStatus = new frmStatus();
        fStatus.Show(strMsg);

        this.Cursor = Cursors.WaitCursor;

    }

    // This function checks whether the Url entered by the user starts with 
    // http://.

    private bool UrlIsValid()
	{
		string url = txtURL.Text;

		if (url.Substring(0,7).Trim() != @"http://") 
			{
            MessageBox.Show("The Url must begin with http://.");
            return false;
        }
        return true;
    }
}


