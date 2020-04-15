//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.

//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 

//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 

//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Collections;

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

	//Do ! modify it using the code editor.

	private System.Windows.Forms.MainMenu mnuMain;
	private System.Windows.Forms.MenuItem mnuFile;
	private System.Windows.Forms.MenuItem mnuExit;
	private System.Windows.Forms.MenuItem mnuHelp;
	private System.Windows.Forms.MenuItem mnuAbout;
    private System.Windows.Forms.TabPage pgeNumeric;
    private System.Windows.Forms.TabPage pgeDateTime;
    private System.Windows.Forms.TabPage pgeEnum;
    private System.Windows.Forms.TabControl tabExamples;
    private System.Windows.Forms.RadioButton optStandardNumeric;
    private System.Windows.Forms.RadioButton optCustomNumeric;
    private System.Windows.Forms.TextBox txtNumeric;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.RadioButton optCustomDateTime;
    private System.Windows.Forms.RadioButton optStandardDateTime;
    private System.Windows.Forms.TextBox txtDateTime;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.ComboBox cboCultureInfoDateTime;
    private System.Windows.Forms.ComboBox cboCultureInfoNumeric;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.Label Label5;
    private System.Windows.Forms.TextBox txtEnum;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.tabExamples = new System.Windows.Forms.TabControl();

        this.pgeNumeric = new System.Windows.Forms.TabPage();

        this.cboCultureInfoNumeric = new System.Windows.Forms.ComboBox();

        this.Label4 = new System.Windows.Forms.Label();

        this.Label1 = new System.Windows.Forms.Label();

        this.optCustomNumeric = new System.Windows.Forms.RadioButton();

        this.optStandardNumeric = new System.Windows.Forms.RadioButton();

        this.txtNumeric = new System.Windows.Forms.TextBox();

        this.pgeDateTime = new System.Windows.Forms.TabPage();

        this.cboCultureInfoDateTime = new System.Windows.Forms.ComboBox();

        this.Label3 = new System.Windows.Forms.Label();

        this.Label2 = new System.Windows.Forms.Label();

        this.optCustomDateTime = new System.Windows.Forms.RadioButton();

        this.optStandardDateTime = new System.Windows.Forms.RadioButton();

        this.txtDateTime = new System.Windows.Forms.TextBox();

        this.pgeEnum = new System.Windows.Forms.TabPage();

        this.Label5 = new System.Windows.Forms.Label();

        this.txtEnum = new System.Windows.Forms.TextBox();

        this.tabExamples.SuspendLayout();

        this.pgeNumeric.SuspendLayout();

        this.pgeDateTime.SuspendLayout();

        this.pgeEnum.SuspendLayout();

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

        //tabExamples

        //

        this.tabExamples.AccessibleDescription = resources.GetString("tabExamples.AccessibleDescription");

        this.tabExamples.AccessibleName = resources.GetString("tabExamples.AccessibleName");

        this.tabExamples.Alignment = (System.Windows.Forms.TabAlignment) resources.GetObject("tabExamples.Alignment");

        this.tabExamples.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tabExamples.Anchor");

        this.tabExamples.Appearance = (System.Windows.Forms.TabAppearance) resources.GetObject("tabExamples.Appearance");

        this.tabExamples.BackgroundImage = (System.Drawing.Image) resources.GetObject("tabExamples.BackgroundImage");

        this.tabExamples.Controls.AddRange(new System.Windows.Forms.Control[] {this.pgeNumeric, this.pgeDateTime, this.pgeEnum});

        this.tabExamples.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tabExamples.Dock");

        this.tabExamples.Enabled = (bool) resources.GetObject("tabExamples.Enabled");

        this.tabExamples.Font = (System.Drawing.Font) resources.GetObject("tabExamples.Font");

        this.tabExamples.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tabExamples.ImeMode");

        this.tabExamples.ItemSize = (System.Drawing.Size) resources.GetObject("tabExamples.ItemSize");

        this.tabExamples.Location = (System.Drawing.Point) resources.GetObject("tabExamples.Location");

        this.tabExamples.Name = "tabExamples";

        this.tabExamples.Padding = (System.Drawing.Point) resources.GetObject("tabExamples.Padding");

        this.tabExamples.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tabExamples.RightToLeft");

        this.tabExamples.SelectedIndex = 0;

        this.tabExamples.ShowToolTips = (bool) resources.GetObject("tabExamples.ShowToolTips");

        this.tabExamples.Size = (System.Drawing.Size) resources.GetObject("tabExamples.Size");

        this.tabExamples.TabIndex = (int) resources.GetObject("tabExamples.TabIndex");

        this.tabExamples.Text = resources.GetString("tabExamples.Text");

        this.tabExamples.Visible = (bool) resources.GetObject("tabExamples.Visible");

        //

        //pgeNumeric

        //

        this.pgeNumeric.AccessibleDescription = resources.GetString("pgeNumeric.AccessibleDescription");

        this.pgeNumeric.AccessibleName = resources.GetString("pgeNumeric.AccessibleName");

        this.pgeNumeric.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeNumeric.Anchor");

        this.pgeNumeric.AutoScroll = (bool) resources.GetObject("pgeNumeric.AutoScroll");

        this.pgeNumeric.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeNumeric.AutoScrollMargin");

        this.pgeNumeric.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeNumeric.AutoScrollMinSize");

        this.pgeNumeric.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeNumeric.BackgroundImage");

        this.pgeNumeric.Controls.AddRange(new System.Windows.Forms.Control[] {this.cboCultureInfoNumeric, this.Label4, this.Label1, this.optCustomNumeric, this.optStandardNumeric, this.txtNumeric});

        this.pgeNumeric.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeNumeric.Dock");

        this.pgeNumeric.Enabled = (bool) resources.GetObject("pgeNumeric.Enabled");

        this.pgeNumeric.Font = (System.Drawing.Font) resources.GetObject("pgeNumeric.Font");

        this.pgeNumeric.ImageIndex = (int) resources.GetObject("pgeNumeric.ImageIndex");

        this.pgeNumeric.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeNumeric.ImeMode");

        this.pgeNumeric.Location = (System.Drawing.Point) resources.GetObject("pgeNumeric.Location");

        this.pgeNumeric.Name = "pgeNumeric";

        this.pgeNumeric.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeNumeric.RightToLeft");

        this.pgeNumeric.Size = (System.Drawing.Size) resources.GetObject("pgeNumeric.Size");

        this.pgeNumeric.TabIndex = (int) resources.GetObject("pgeNumeric.TabIndex");

        this.pgeNumeric.Text = resources.GetString("pgeNumeric.Text");

        this.pgeNumeric.ToolTipText = resources.GetString("pgeNumeric.ToolTipText");

        this.pgeNumeric.Visible = (bool) resources.GetObject("pgeNumeric.Visible");

        //

        //cboCultureInfoNumeric

        //

        this.cboCultureInfoNumeric.AccessibleDescription = resources.GetString("cboCultureInfoNumeric.AccessibleDescription");

        this.cboCultureInfoNumeric.AccessibleName = resources.GetString("cboCultureInfoNumeric.AccessibleName");

        this.cboCultureInfoNumeric.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboCultureInfoNumeric.Anchor");

        this.cboCultureInfoNumeric.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboCultureInfoNumeric.BackgroundImage");

        this.cboCultureInfoNumeric.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboCultureInfoNumeric.Dock");

        this.cboCultureInfoNumeric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        this.cboCultureInfoNumeric.Enabled = (bool) resources.GetObject("cboCultureInfoNumeric.Enabled");

        this.cboCultureInfoNumeric.Font = (System.Drawing.Font) resources.GetObject("cboCultureInfoNumeric.Font");

        this.cboCultureInfoNumeric.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboCultureInfoNumeric.ImeMode");

        this.cboCultureInfoNumeric.IntegralHeight = (bool) resources.GetObject("cboCultureInfoNumeric.IntegralHeight");

        this.cboCultureInfoNumeric.ItemHeight = (int) resources.GetObject("cboCultureInfoNumeric.ItemHeight");

        this.cboCultureInfoNumeric.Location = (System.Drawing.Point) resources.GetObject("cboCultureInfoNumeric.Location");

        this.cboCultureInfoNumeric.MaxDropDownItems = (int) resources.GetObject("cboCultureInfoNumeric.MaxDropDownItems");

        this.cboCultureInfoNumeric.MaxLength = (int) resources.GetObject("cboCultureInfoNumeric.MaxLength");

        this.cboCultureInfoNumeric.Name = "cboCultureInfoNumeric";

        this.cboCultureInfoNumeric.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboCultureInfoNumeric.RightToLeft");

        this.cboCultureInfoNumeric.Size = (System.Drawing.Size) resources.GetObject("cboCultureInfoNumeric.Size");

        this.cboCultureInfoNumeric.TabIndex = (int) resources.GetObject("cboCultureInfoNumeric.TabIndex");

        this.cboCultureInfoNumeric.Text = resources.GetString("cboCultureInfoNumeric.Text");

        this.cboCultureInfoNumeric.Visible = (bool) resources.GetObject("cboCultureInfoNumeric.Visible");

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

        //optCustomNumeric

        //

        this.optCustomNumeric.AccessibleDescription = resources.GetString("optCustomNumeric.AccessibleDescription");

        this.optCustomNumeric.AccessibleName = resources.GetString("optCustomNumeric.AccessibleName");

        this.optCustomNumeric.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optCustomNumeric.Anchor");

        this.optCustomNumeric.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optCustomNumeric.Appearance");

        this.optCustomNumeric.BackgroundImage = (System.Drawing.Image) resources.GetObject("optCustomNumeric.BackgroundImage");

        this.optCustomNumeric.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCustomNumeric.CheckAlign");

        this.optCustomNumeric.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optCustomNumeric.Dock");

        this.optCustomNumeric.Enabled = (bool) resources.GetObject("optCustomNumeric.Enabled");

        this.optCustomNumeric.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optCustomNumeric.FlatStyle");

        this.optCustomNumeric.Font = (System.Drawing.Font) resources.GetObject("optCustomNumeric.Font");

        this.optCustomNumeric.Image = (System.Drawing.Image) resources.GetObject("optCustomNumeric.Image");

        this.optCustomNumeric.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCustomNumeric.ImageAlign");

        this.optCustomNumeric.ImageIndex = (int) resources.GetObject("optCustomNumeric.ImageIndex");

        this.optCustomNumeric.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optCustomNumeric.ImeMode");

        this.optCustomNumeric.Location = (System.Drawing.Point) resources.GetObject("optCustomNumeric.Location");

        this.optCustomNumeric.Name = "optCustomNumeric";

        this.optCustomNumeric.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optCustomNumeric.RightToLeft");

        this.optCustomNumeric.Size = (System.Drawing.Size) resources.GetObject("optCustomNumeric.Size");

        this.optCustomNumeric.TabIndex = (int) resources.GetObject("optCustomNumeric.TabIndex");

        this.optCustomNumeric.Text = resources.GetString("optCustomNumeric.Text");

        this.optCustomNumeric.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCustomNumeric.TextAlign");

        this.optCustomNumeric.Visible = (bool) resources.GetObject("optCustomNumeric.Visible");

        //

        //optStandardNumeric

        //

        this.optStandardNumeric.AccessibleDescription = resources.GetString("optStandardNumeric.AccessibleDescription");

        this.optStandardNumeric.AccessibleName = resources.GetString("optStandardNumeric.AccessibleName");

        this.optStandardNumeric.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optStandardNumeric.Anchor");

        this.optStandardNumeric.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optStandardNumeric.Appearance");

        this.optStandardNumeric.BackgroundImage = (System.Drawing.Image) resources.GetObject("optStandardNumeric.BackgroundImage");

        this.optStandardNumeric.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optStandardNumeric.CheckAlign");

        this.optStandardNumeric.Checked = true;

        this.optStandardNumeric.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optStandardNumeric.Dock");

        this.optStandardNumeric.Enabled = (bool) resources.GetObject("optStandardNumeric.Enabled");

        this.optStandardNumeric.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optStandardNumeric.FlatStyle");

        this.optStandardNumeric.Font = (System.Drawing.Font) resources.GetObject("optStandardNumeric.Font");

        this.optStandardNumeric.Image = (System.Drawing.Image) resources.GetObject("optStandardNumeric.Image");

        this.optStandardNumeric.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optStandardNumeric.ImageAlign");

        this.optStandardNumeric.ImageIndex = (int) resources.GetObject("optStandardNumeric.ImageIndex");

        this.optStandardNumeric.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optStandardNumeric.ImeMode");

        this.optStandardNumeric.Location = (System.Drawing.Point) resources.GetObject("optStandardNumeric.Location");

        this.optStandardNumeric.Name = "optStandardNumeric";

        this.optStandardNumeric.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optStandardNumeric.RightToLeft");

        this.optStandardNumeric.Size = (System.Drawing.Size) resources.GetObject("optStandardNumeric.Size");

        this.optStandardNumeric.TabIndex = (int) resources.GetObject("optStandardNumeric.TabIndex");

        this.optStandardNumeric.TabStop = true;

        this.optStandardNumeric.Text = resources.GetString("optStandardNumeric.Text");

        this.optStandardNumeric.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optStandardNumeric.TextAlign");

        this.optStandardNumeric.Visible = (bool) resources.GetObject("optStandardNumeric.Visible");

        //

        //txtNumeric

        //

        this.txtNumeric.AccessibleDescription = resources.GetString("txtNumeric.AccessibleDescription");

        this.txtNumeric.AccessibleName = resources.GetString("txtNumeric.AccessibleName");

        this.txtNumeric.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtNumeric.Anchor");

        this.txtNumeric.AutoSize = (bool) resources.GetObject("txtNumeric.AutoSize");

        this.txtNumeric.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtNumeric.BackgroundImage");

        this.txtNumeric.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtNumeric.Dock");

        this.txtNumeric.Enabled = (bool) resources.GetObject("txtNumeric.Enabled");

        this.txtNumeric.Font = (System.Drawing.Font) resources.GetObject("txtNumeric.Font");

        this.txtNumeric.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtNumeric.ImeMode");

        this.txtNumeric.Location = (System.Drawing.Point) resources.GetObject("txtNumeric.Location");

        this.txtNumeric.MaxLength = (int) resources.GetObject("txtNumeric.MaxLength");

        this.txtNumeric.Multiline = (bool) resources.GetObject("txtNumeric.Multiline");

        this.txtNumeric.Name = "txtNumeric";

        this.txtNumeric.PasswordChar = (char) resources.GetObject("txtNumeric.PasswordChar");

        this.txtNumeric.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtNumeric.RightToLeft");

        this.txtNumeric.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtNumeric.ScrollBars");

        this.txtNumeric.Size = (System.Drawing.Size) resources.GetObject("txtNumeric.Size");

        this.txtNumeric.TabIndex = (int) resources.GetObject("txtNumeric.TabIndex");

        this.txtNumeric.Text = resources.GetString("txtNumeric.Text");

        this.txtNumeric.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtNumeric.TextAlign");

        this.txtNumeric.Visible = (bool) resources.GetObject("txtNumeric.Visible");

        this.txtNumeric.WordWrap = (bool) resources.GetObject("txtNumeric.WordWrap");

        //

        //pgeDateTime

        //

        this.pgeDateTime.AccessibleDescription = resources.GetString("pgeDateTime.AccessibleDescription");

        this.pgeDateTime.AccessibleName = resources.GetString("pgeDateTime.AccessibleName");

        this.pgeDateTime.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeDateTime.Anchor");

        this.pgeDateTime.AutoScroll = (bool) resources.GetObject("pgeDateTime.AutoScroll");

        this.pgeDateTime.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeDateTime.AutoScrollMargin");

        this.pgeDateTime.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeDateTime.AutoScrollMinSize");

        this.pgeDateTime.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeDateTime.BackgroundImage");

        this.pgeDateTime.Controls.AddRange(new System.Windows.Forms.Control[] {this.cboCultureInfoDateTime, this.Label3, this.Label2, this.optCustomDateTime, this.optStandardDateTime, this.txtDateTime});

        this.pgeDateTime.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeDateTime.Dock");

        this.pgeDateTime.Enabled = (bool) resources.GetObject("pgeDateTime.Enabled");

        this.pgeDateTime.Font = (System.Drawing.Font) resources.GetObject("pgeDateTime.Font");

        this.pgeDateTime.ImageIndex = (int) resources.GetObject("pgeDateTime.ImageIndex");

        this.pgeDateTime.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeDateTime.ImeMode");

        this.pgeDateTime.Location = (System.Drawing.Point) resources.GetObject("pgeDateTime.Location");

        this.pgeDateTime.Name = "pgeDateTime";

        this.pgeDateTime.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeDateTime.RightToLeft");

        this.pgeDateTime.Size = (System.Drawing.Size) resources.GetObject("pgeDateTime.Size");

        this.pgeDateTime.TabIndex = (int) resources.GetObject("pgeDateTime.TabIndex");

        this.pgeDateTime.Text = resources.GetString("pgeDateTime.Text");

        this.pgeDateTime.ToolTipText = resources.GetString("pgeDateTime.ToolTipText");

        this.pgeDateTime.Visible = (bool) resources.GetObject("pgeDateTime.Visible");

        //

        //cboCultureInfoDateTime

        //

        this.cboCultureInfoDateTime.AccessibleDescription = resources.GetString("cboCultureInfoDateTime.AccessibleDescription");

        this.cboCultureInfoDateTime.AccessibleName = resources.GetString("cboCultureInfoDateTime.AccessibleName");

        this.cboCultureInfoDateTime.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboCultureInfoDateTime.Anchor");

        this.cboCultureInfoDateTime.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboCultureInfoDateTime.BackgroundImage");

        this.cboCultureInfoDateTime.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboCultureInfoDateTime.Dock");

        this.cboCultureInfoDateTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        this.cboCultureInfoDateTime.Enabled = (bool) resources.GetObject("cboCultureInfoDateTime.Enabled");

        this.cboCultureInfoDateTime.Font = (System.Drawing.Font) resources.GetObject("cboCultureInfoDateTime.Font");

        this.cboCultureInfoDateTime.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboCultureInfoDateTime.ImeMode");

        this.cboCultureInfoDateTime.IntegralHeight = (bool) resources.GetObject("cboCultureInfoDateTime.IntegralHeight");

        this.cboCultureInfoDateTime.ItemHeight = (int) resources.GetObject("cboCultureInfoDateTime.ItemHeight");

        this.cboCultureInfoDateTime.Location = (System.Drawing.Point) resources.GetObject("cboCultureInfoDateTime.Location");

        this.cboCultureInfoDateTime.MaxDropDownItems = (int) resources.GetObject("cboCultureInfoDateTime.MaxDropDownItems");

        this.cboCultureInfoDateTime.MaxLength = (int) resources.GetObject("cboCultureInfoDateTime.MaxLength");

        this.cboCultureInfoDateTime.Name = "cboCultureInfoDateTime";

        this.cboCultureInfoDateTime.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboCultureInfoDateTime.RightToLeft");

        this.cboCultureInfoDateTime.Size = (System.Drawing.Size) resources.GetObject("cboCultureInfoDateTime.Size");

        this.cboCultureInfoDateTime.TabIndex = (int) resources.GetObject("cboCultureInfoDateTime.TabIndex");

        this.cboCultureInfoDateTime.Text = resources.GetString("cboCultureInfoDateTime.Text");

        this.cboCultureInfoDateTime.Visible = (bool) resources.GetObject("cboCultureInfoDateTime.Visible");

        //

        //Label3

        //

        this.Label3.AccessibleDescription = (string) resources.GetObject("Label3.AccessibleDescription");

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

        //optCustomDateTime

        //

        this.optCustomDateTime.AccessibleDescription = resources.GetString("optCustomDateTime.AccessibleDescription");

        this.optCustomDateTime.AccessibleName = resources.GetString("optCustomDateTime.AccessibleName");

        this.optCustomDateTime.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optCustomDateTime.Anchor");

        this.optCustomDateTime.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optCustomDateTime.Appearance");

        this.optCustomDateTime.BackgroundImage = (System.Drawing.Image) resources.GetObject("optCustomDateTime.BackgroundImage");

        this.optCustomDateTime.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCustomDateTime.CheckAlign");

        this.optCustomDateTime.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optCustomDateTime.Dock");

        this.optCustomDateTime.Enabled = (bool) resources.GetObject("optCustomDateTime.Enabled");

        this.optCustomDateTime.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optCustomDateTime.FlatStyle");

        this.optCustomDateTime.Font = (System.Drawing.Font) resources.GetObject("optCustomDateTime.Font");

        this.optCustomDateTime.Image = (System.Drawing.Image) resources.GetObject("optCustomDateTime.Image");

        this.optCustomDateTime.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCustomDateTime.ImageAlign");

        this.optCustomDateTime.ImageIndex = (int) resources.GetObject("optCustomDateTime.ImageIndex");

        this.optCustomDateTime.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optCustomDateTime.ImeMode");

        this.optCustomDateTime.Location = (System.Drawing.Point) resources.GetObject("optCustomDateTime.Location");

        this.optCustomDateTime.Name = "optCustomDateTime";

        this.optCustomDateTime.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optCustomDateTime.RightToLeft");

        this.optCustomDateTime.Size = (System.Drawing.Size) resources.GetObject("optCustomDateTime.Size");

        this.optCustomDateTime.TabIndex = (int) resources.GetObject("optCustomDateTime.TabIndex");

        this.optCustomDateTime.Text = resources.GetString("optCustomDateTime.Text");

        this.optCustomDateTime.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optCustomDateTime.TextAlign");

        this.optCustomDateTime.Visible = (bool) resources.GetObject("optCustomDateTime.Visible");

        //

        //optStandardDateTime

        //

        this.optStandardDateTime.AccessibleDescription = resources.GetString("optStandardDateTime.AccessibleDescription");

        this.optStandardDateTime.AccessibleName = resources.GetString("optStandardDateTime.AccessibleName");

        this.optStandardDateTime.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optStandardDateTime.Anchor");

        this.optStandardDateTime.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optStandardDateTime.Appearance");

        this.optStandardDateTime.BackgroundImage = (System.Drawing.Image) resources.GetObject("optStandardDateTime.BackgroundImage");

        this.optStandardDateTime.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optStandardDateTime.CheckAlign");

        this.optStandardDateTime.Checked = true;

        this.optStandardDateTime.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optStandardDateTime.Dock");

        this.optStandardDateTime.Enabled = (bool) resources.GetObject("optStandardDateTime.Enabled");

        this.optStandardDateTime.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optStandardDateTime.FlatStyle");

        this.optStandardDateTime.Font = (System.Drawing.Font) resources.GetObject("optStandardDateTime.Font");

        this.optStandardDateTime.Image = (System.Drawing.Image) resources.GetObject("optStandardDateTime.Image");

        this.optStandardDateTime.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optStandardDateTime.ImageAlign");

        this.optStandardDateTime.ImageIndex = (int) resources.GetObject("optStandardDateTime.ImageIndex");

        this.optStandardDateTime.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optStandardDateTime.ImeMode");

        this.optStandardDateTime.Location = (System.Drawing.Point) resources.GetObject("optStandardDateTime.Location");

        this.optStandardDateTime.Name = "optStandardDateTime";

        this.optStandardDateTime.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optStandardDateTime.RightToLeft");

        this.optStandardDateTime.Size = (System.Drawing.Size) resources.GetObject("optStandardDateTime.Size");

        this.optStandardDateTime.TabIndex = (int) resources.GetObject("optStandardDateTime.TabIndex");

        this.optStandardDateTime.TabStop = true;

        this.optStandardDateTime.Text = resources.GetString("optStandardDateTime.Text");

        this.optStandardDateTime.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optStandardDateTime.TextAlign");

        this.optStandardDateTime.Visible = (bool) resources.GetObject("optStandardDateTime.Visible");

        //

        //txtDateTime

        //

        this.txtDateTime.AccessibleDescription = resources.GetString("txtDateTime.AccessibleDescription");

        this.txtDateTime.AccessibleName = resources.GetString("txtDateTime.AccessibleName");

        this.txtDateTime.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtDateTime.Anchor");

        this.txtDateTime.AutoSize = (bool) resources.GetObject("txtDateTime.AutoSize");

        this.txtDateTime.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtDateTime.BackgroundImage");

        this.txtDateTime.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtDateTime.Dock");

        this.txtDateTime.Enabled = (bool) resources.GetObject("txtDateTime.Enabled");

        this.txtDateTime.Font = (System.Drawing.Font) resources.GetObject("txtDateTime.Font");

        this.txtDateTime.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtDateTime.ImeMode");

        this.txtDateTime.Location = (System.Drawing.Point) resources.GetObject("txtDateTime.Location");

        this.txtDateTime.MaxLength = (int) resources.GetObject("txtDateTime.MaxLength");

        this.txtDateTime.Multiline = (bool) resources.GetObject("txtDateTime.Multiline");

        this.txtDateTime.Name = "txtDateTime";

        this.txtDateTime.PasswordChar = (char) resources.GetObject("txtDateTime.PasswordChar");

        this.txtDateTime.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtDateTime.RightToLeft");

        this.txtDateTime.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtDateTime.ScrollBars");

        this.txtDateTime.Size = (System.Drawing.Size) resources.GetObject("txtDateTime.Size");

        this.txtDateTime.TabIndex = (int) resources.GetObject("txtDateTime.TabIndex");

        this.txtDateTime.Text = resources.GetString("txtDateTime.Text");

        this.txtDateTime.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtDateTime.TextAlign");

        this.txtDateTime.Visible = (bool) resources.GetObject("txtDateTime.Visible");

        this.txtDateTime.WordWrap = (bool) resources.GetObject("txtDateTime.WordWrap");

        //

        //pgeEnum

        //

        this.pgeEnum.AccessibleDescription = resources.GetString("pgeEnum.AccessibleDescription");

        this.pgeEnum.AccessibleName = resources.GetString("pgeEnum.AccessibleName");

        this.pgeEnum.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("pgeEnum.Anchor");

        this.pgeEnum.AutoScroll = (bool) resources.GetObject("pgeEnum.AutoScroll");

        this.pgeEnum.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("pgeEnum.AutoScrollMargin");

        this.pgeEnum.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("pgeEnum.AutoScrollMinSize");

        this.pgeEnum.BackgroundImage = (System.Drawing.Image) resources.GetObject("pgeEnum.BackgroundImage");

        this.pgeEnum.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label5, this.txtEnum});

        this.pgeEnum.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("pgeEnum.Dock");

        this.pgeEnum.Enabled = (bool) resources.GetObject("pgeEnum.Enabled");

        this.pgeEnum.Font = (System.Drawing.Font) resources.GetObject("pgeEnum.Font");

        this.pgeEnum.ImageIndex = (int) resources.GetObject("pgeEnum.ImageIndex");

        this.pgeEnum.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("pgeEnum.ImeMode");

        this.pgeEnum.Location = (System.Drawing.Point) resources.GetObject("pgeEnum.Location");

        this.pgeEnum.Name = "pgeEnum";

        this.pgeEnum.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("pgeEnum.RightToLeft");

        this.pgeEnum.Size = (System.Drawing.Size) resources.GetObject("pgeEnum.Size");

        this.pgeEnum.TabIndex = (int) resources.GetObject("pgeEnum.TabIndex");

        this.pgeEnum.Text = resources.GetString("pgeEnum.Text");

        this.pgeEnum.ToolTipText = resources.GetString("pgeEnum.ToolTipText");

        this.pgeEnum.Visible = (bool) resources.GetObject("pgeEnum.Visible");

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

        //txtEnum

        //

        this.txtEnum.AccessibleDescription = resources.GetString("txtEnum.AccessibleDescription");

        this.txtEnum.AccessibleName = resources.GetString("txtEnum.AccessibleName");

        this.txtEnum.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtEnum.Anchor");

        this.txtEnum.AutoSize = (bool) resources.GetObject("txtEnum.AutoSize");

        this.txtEnum.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtEnum.BackgroundImage");

        this.txtEnum.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtEnum.Dock");

        this.txtEnum.Enabled = (bool) resources.GetObject("txtEnum.Enabled");

        this.txtEnum.Font = (System.Drawing.Font) resources.GetObject("txtEnum.Font");

        this.txtEnum.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtEnum.ImeMode");

        this.txtEnum.Location = (System.Drawing.Point) resources.GetObject("txtEnum.Location");

        this.txtEnum.MaxLength = (int) resources.GetObject("txtEnum.MaxLength");

        this.txtEnum.Multiline = (bool) resources.GetObject("txtEnum.Multiline");

        this.txtEnum.Name = "txtEnum";

        this.txtEnum.PasswordChar = (char) resources.GetObject("txtEnum.PasswordChar");

        this.txtEnum.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtEnum.RightToLeft");

        this.txtEnum.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtEnum.ScrollBars");

        this.txtEnum.Size = (System.Drawing.Size) resources.GetObject("txtEnum.Size");

        this.txtEnum.TabIndex = (int) resources.GetObject("txtEnum.TabIndex");

        this.txtEnum.Text = resources.GetString("txtEnum.Text");

        this.txtEnum.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtEnum.TextAlign");

        this.txtEnum.Visible = (bool) resources.GetObject("txtEnum.Visible");

        this.txtEnum.WordWrap = (bool) resources.GetObject("txtEnum.WordWrap");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.tabExamples});

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

        this.tabExamples.ResumeLayout(false);

        this.pgeNumeric.ResumeLayout(false);

        this.pgeDateTime.ResumeLayout(false);

        this.pgeEnum.ResumeLayout(false);

        this.ResumeLayout(false);
		
		this.Load +=new EventHandler(frmMain_Load);
		this.cboCultureInfoDateTime.SelectedValueChanged +=new EventHandler(cboCultureInfoDateTime_SelectedValueChanged);
		this.cboCultureInfoNumeric.SelectedValueChanged +=new EventHandler(cboCultureInfoNumeric_SelectedValueChanged);
		this.optStandardNumeric.CheckedChanged +=new EventHandler(RadioButtons_CheckedChanged);
		this.optCustomNumeric.CheckedChanged+=new EventHandler(RadioButtons_CheckedChanged);
		this.optCustomDateTime.CheckedChanged+=new EventHandler(RadioButtons_CheckedChanged);
		this.optStandardDateTime.CheckedChanged+=new EventHandler(RadioButtons_CheckedChanged);
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

    // The Culture class is a custom type that is used for databinding to a ComboBox.
    // Notice the use of public properties instead of merely public fields. You might
    // think you could use the following construct:
    //
    //   public class Culture
    //       public ID string
    //       public Description string
    //       void new(strID string, strDesc string)
    //           ID = strID
    //           Description = strDesc
    //       }
    //   }
    //
    // This will, however, throw a runtime InvalidArgumentException stating that it 
    // can! bind to the new DisplayMember. 
    
public class Culture
	{

        private string _ID;
        private string _desc;

        public Culture(string strDesc, string strID)
		{
            _ID = strID;
            _desc = strDesc;
        }

        public string ID
		{
            get {
                return _ID;
            }
        }

        public string Description {
            get {
                return _desc;
            }
        }
    }

    private string crlf = System.Environment.NewLine;
    private bool FormHasLoaded = false;
    private string strCultureValue;
    private string tab = @"\t";

    // Calls the method to display the DateTime formatting examples based on a 
    // user-selected CultureInfo.

    private void cboCultureInfoDateTime_SelectedValueChanged(object sender, System.EventArgs e)
		{
        // Handler should work only if the Form has loaded SelectedValueChanged 
        // fires during databinding and causes undesirable results.

        if (FormHasLoaded) 
			{
            LoadDateTimeFormats();
        }

    }

    // Calls the method to display the Numeric formatting examples based on a 
    // user-selected CultureInfo.

    private void cboCultureInfoNumeric_SelectedValueChanged(object sender, System.EventArgs e) //cboCultureInfoNumeric.SelectedIndexChanged;
		{
        // Handler should work only if the Form has loaded SelectedValueChanged 
        // fires during databinding and causes undesirable results.

        if (FormHasLoaded) 
			{
            LoadNumericFormats();
        }
    }

    // Loads the ComboBox controls from an ArrayList and calls the methods to display 
    // the various formatting examples.

    private void frmMain_Load(object sender, System.EventArgs e) 
		{

        // Databind the ComboBox controls to an ArrayList of custom objects. Refer to
        // the comments about the Culture class for more information.

        ArrayList arlCultureInfo = new ArrayList();
        arlCultureInfo.Add(new Culture("English - United States", "en-US"));
        arlCultureInfo.Add(new Culture("English - United Kingdom", "en-GB"));
        arlCultureInfo.Add(new Culture("English - new Zealand", "en-NZ"));
        arlCultureInfo.Add(new Culture("German - Germany", "de-DE"));
        arlCultureInfo.Add(new Culture("Spanish - Spain", "es-ES"));
        arlCultureInfo.Add(new Culture("French - France", "fr-FR"));
        arlCultureInfo.Add(new Culture("Portuguese - Brazil", "pt-BR"));
        arlCultureInfo.Add(new Culture("Malay - Malaysia", "ms-MY"));
        arlCultureInfo.Add(new Culture("Afrikaans - South Africa", "af-ZA"));
       
        cboCultureInfoDateTime.DataSource = arlCultureInfo;
        cboCultureInfoDateTime.DisplayMember = "Description";
        cboCultureInfoDateTime.ValueMember = "ID";
        cboCultureInfoNumeric.DataSource = arlCultureInfo;
        cboCultureInfoNumeric.DisplayMember = "Description";
        cboCultureInfoNumeric.ValueMember = "ID";
        LoadEnumFormats();
        LoadDateTimeFormats();
        LoadNumericFormats();
        FormHasLoaded = true;
    }

    // Calls the methods to display the formatting examples based on whether
    // the user selects "standard" or "custom" formatting.

    private void RadioButtons_CheckedChanged(object sender, System.EventArgs e) 
		{
        // Handler should work only if the Form has loaded SelectedValueChanged 
        // fires during databinding and causes undesirable results.

        if (FormHasLoaded) 
			{
            RadioButton opt = (RadioButton) sender;
            switch(opt.Name)
				{
                case "optStandardNumeric":
					{
                    LoadNumericFormats();
					break;
					}
				case "optCustomNumeric":
					{
                    LoadNumericFormats();
					break;
					}
                case "optStandardDateTime":
					{
					LoadDateTimeFormats();
					break;
					} 
				case "optCustomDateTime":
					{
                    LoadDateTimeFormats();
					break;
					}
                default: 
					{
                    LoadEnumFormats();
					break;
					}
            }

        }

    }

    // Displays the DateTime formatting examples.

    private void LoadDateTimeFormats()
		{
        DateTime dtmNow = DateTime.Now;

        StringBuilder sb = new StringBuilder();

        strCultureValue = cboCultureInfoDateTime.SelectedValue.ToString();

        Thread.CurrentThread.CurrentCulture = new CultureInfo(strCultureValue);

        sb.Append("When using " + strCultureValue + " CultureInfo, today's date and time will format follows:");

        sb.Append(crlf);

        sb.Append(crlf);

        if (optStandardDateTime.Checked) 
			{
                sb.Append(dtmNow.ToString("d"));
                sb.Append(" [Short date pattern]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("D"));
                sb.Append(" [Long date pattern]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("t"));
                sb.Append(" [Short time pattern]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("T"));
                sb.Append(" [Long time pattern]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("F"));
                sb.Append(" [Full date/time pattern (long)]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("f"));
                sb.Append(" [Full date/time pattern (short)]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("G"));
                sb.Append(" [General date/time pattern (long)]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("g"));
                sb.Append(" [General date/time pattern (short)]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("M"));
                sb.Append(" [Month day pattern]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("R"));
                sb.Append(" [RFC1123 pattern]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("s"));
                sb.Append(" [Sortable date/time pattern]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("u"));
                sb.Append(" [Universable sortable date/time pattern]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("y"));
                sb.Append(" [Year month pattern]");
                sb.Append(crlf);
                sb.Append(crlf);
        } 
		else if (optCustomDateTime.Checked) 
		{
                sb.Append(dtmNow.ToString("d, M"));
                sb.Append(" [d, M]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("d MMMM"));
                sb.Append(" [d MMMM]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("dddd MMMM yy gg"));
                sb.Append(" [dddd MMMM yy gg]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("h , m: s"));
                sb.Append(" [h , m: s]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("hh,mm:ss"));
                sb.Append(" [hh,mm:ss]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString("HH-mm-ss-tt"));
                sb.Append(" [HH-mm-ss-tt]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString(@"hh:mm, G\MT z"));
                sb.Append(@" [hh:mm, G\MT z]");
                sb.Append(crlf);
                sb.Append(dtmNow.ToString(@"hh:mm, G\MT zzz"));
                sb.Append(@" [hh:mm, G\MT zzz]");
            
        }

        txtDateTime.Text = sb.ToString();

    }

    // Displays the enum formatting examples.

    private void LoadEnumFormats()
	{

        DayOfWeek day = DayOfWeek.Friday;
        StringBuilder sb = new StringBuilder();
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        sb.Append("When using any CultureInfo, the system enumeration DayOfWeek.Friday will format follows:");
        sb.Append(crlf);
        sb.Append(crlf);
        sb.Append(day.ToString("G"));
        sb.Append(" [G or g]");
        sb.Append(crlf);
        sb.Append(day.ToString("F"));
        sb.Append(" [F or f]");
        sb.Append(crlf);
        sb.Append(day.ToString("D"));
        sb.Append(" [D or d]");
        sb.Append(crlf);
        sb.Append(day.ToString("X"));
        sb.Append(" [X or x]");
        txtEnum.Text = sb.ToString();

    }

    // Displays the Numeric formatting examples.

    private void LoadNumericFormats()
	{

        Int32 intNumber = 1234567890;
        StringBuilder sb = new StringBuilder();
        strCultureValue = cboCultureInfoNumeric.SelectedValue.ToString();
        Thread.CurrentThread.CurrentCulture = new CultureInfo(strCultureValue);
        sb.Append("When using " + strCultureValue + " CultureInfo, the int 1234567890 will format follows:");
        sb.Append(crlf);
        sb.Append(crlf);
		if (optStandardNumeric.Checked)
		{
			sb.Append(intNumber.ToString("C"));
			sb.Append(" [Currency]");
			sb.Append(crlf);
			sb.Append(intNumber.ToString("E"));
			sb.Append(" [Scientific (Exponential)]");
			sb.Append(crlf);
			sb.Append(intNumber.ToString("P"));
			sb.Append(" [Percent]");
			sb.Append(crlf);
			sb.Append(intNumber.ToString("N"));
			sb.Append(" [Number]");
			sb.Append(crlf);
			sb.Append(intNumber.ToString("F"));
			sb.Append(" [Fixed-point]");
			sb.Append(crlf);
			sb.Append(intNumber.ToString("X"));
			sb.Append(" [Hexadecimal]");
			sb.Append(crlf);
			sb.Append(crlf);
		}
        else if (optCustomNumeric.Checked) 
			{
                sb.Append(intNumber.ToString("#####"));
                sb.Append(" [#####]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("00000"));
                sb.Append(" [00000]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("(###) ### - ####"));
                sb.Append(" [(###) ### - ####]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("#.##"));
                sb.Append(" [#.##]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("00.00"));
                sb.Append(" [00.00]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("#,#"));
                sb.Append(" [#,#]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("#,,"));
                sb.Append(" [#,,]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("#.##"));
                sb.Append(" [#.##]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("#,,,"));
                sb.Append(" [#,,,]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("#,##0,,"));
                sb.Append(" [#,##0,,]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("#0.##%"));
                sb.Append(" [#0.##%]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("0.###E+000"));
                sb.Append(" [0.###E+000]");
                sb.Append(crlf);
                sb.Append(intNumber.ToString("##;(##)"));
                sb.Append(" [##;(##)]");
                sb.Append(crlf);
        }

        txtNumeric.Text = sb.ToString();
    }
}

