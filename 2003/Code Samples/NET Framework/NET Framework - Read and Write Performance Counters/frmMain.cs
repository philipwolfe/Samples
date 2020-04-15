//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;

public class frmMain: System.Windows.Forms.Form 
{
    private PerformanceCounter m_Counter;

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

    private System.Windows.Forms.Timer tmrUpdateUI;

    private System.Windows.Forms.ComboBox cboCounters;

    private System.Windows.Forms.Label lblSelectTimer;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.ComboBox cboCategories;

    private System.Windows.Forms.TextBox txtCounterValue;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.TextBox txtCounterType;

    private System.Windows.Forms.Label lblCounterType;

    private System.Windows.Forms.TextBox txtCounterHelp;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label lblBuiltInOrCustom;

    private System.Windows.Forms.TextBox txtBuiltInOrCustom;

    private System.Windows.Forms.Button btnIncrementCounter;

    private System.Windows.Forms.Button btnDecrementCounter;

    private System.Windows.Forms.StatusBar sbrStatus;

    private System.Windows.Forms.Label lblAddingACustomControl;

    private System.Windows.Forms.Button btnRefreshCategories;

    private void InitializeComponent() 
	{
        this.components = new System.ComponentModel.Container();

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.tmrUpdateUI = new System.Windows.Forms.Timer(this.components);

        this.cboCounters = new System.Windows.Forms.ComboBox();

        this.lblSelectTimer = new System.Windows.Forms.Label();

        this.Label1 = new System.Windows.Forms.Label();

        this.cboCategories = new System.Windows.Forms.ComboBox();

        this.txtCounterValue = new System.Windows.Forms.TextBox();

        this.Label2 = new System.Windows.Forms.Label();

        this.txtCounterType = new System.Windows.Forms.TextBox();

        this.lblCounterType = new System.Windows.Forms.Label();

        this.txtCounterHelp = new System.Windows.Forms.TextBox();

        this.Label3 = new System.Windows.Forms.Label();

        this.lblBuiltInOrCustom = new System.Windows.Forms.Label();

        this.txtBuiltInOrCustom = new System.Windows.Forms.TextBox();

        this.btnIncrementCounter = new System.Windows.Forms.Button();

        this.btnDecrementCounter = new System.Windows.Forms.Button();

        this.sbrStatus = new System.Windows.Forms.StatusBar();

        this.lblAddingACustomControl = new System.Windows.Forms.Label();

        this.btnRefreshCategories = new System.Windows.Forms.Button();

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

        //tmrUpdateUI

        //

        //

        //cboCounters

        //

        this.cboCounters.AccessibleDescription = resources.GetString("cboCounters.AccessibleDescription");

        this.cboCounters.AccessibleName = resources.GetString("cboCounters.AccessibleName");

        this.cboCounters.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboCounters.Anchor");

        this.cboCounters.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboCounters.BackgroundImage");

        this.cboCounters.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboCounters.Dock");

        this.cboCounters.Enabled = (bool) resources.GetObject("cboCounters.Enabled");

        this.cboCounters.Font = (System.Drawing.Font) resources.GetObject("cboCounters.Font");

        this.cboCounters.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboCounters.ImeMode");

        this.cboCounters.IntegralHeight = (bool) resources.GetObject("cboCounters.IntegralHeight");

        this.cboCounters.ItemHeight = (int) resources.GetObject("cboCounters.ItemHeight");

        this.cboCounters.Location = (System.Drawing.Point) resources.GetObject("cboCounters.Location");

        this.cboCounters.MaxDropDownItems = (int) resources.GetObject("cboCounters.MaxDropDownItems");

        this.cboCounters.MaxLength = (int) resources.GetObject("cboCounters.MaxLength");

        this.cboCounters.Name = "cboCounters";

        this.cboCounters.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboCounters.RightToLeft");

        this.cboCounters.Size = (System.Drawing.Size) resources.GetObject("cboCounters.Size");

        this.cboCounters.TabIndex = (int) resources.GetObject("cboCounters.TabIndex");

        this.cboCounters.Text = resources.GetString("cboCounters.Text");

        this.cboCounters.Visible = (bool) resources.GetObject("cboCounters.Visible");

        //

        //lblSelectTimer

        //

        this.lblSelectTimer.AccessibleDescription = resources.GetString("lblSelectTimer.AccessibleDescription");

        this.lblSelectTimer.AccessibleName = resources.GetString("lblSelectTimer.AccessibleName");

        this.lblSelectTimer.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblSelectTimer.Anchor");

        this.lblSelectTimer.AutoSize = (bool) resources.GetObject("lblSelectTimer.AutoSize");

        this.lblSelectTimer.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblSelectTimer.Dock");

        this.lblSelectTimer.Enabled = (bool) resources.GetObject("lblSelectTimer.Enabled");

        this.lblSelectTimer.Font = (System.Drawing.Font) resources.GetObject("lblSelectTimer.Font");

        this.lblSelectTimer.Image = (System.Drawing.Image) resources.GetObject("lblSelectTimer.Image");

        this.lblSelectTimer.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblSelectTimer.ImageAlign");

        this.lblSelectTimer.ImageIndex = (int) resources.GetObject("lblSelectTimer.ImageIndex");

        this.lblSelectTimer.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblSelectTimer.ImeMode");

        this.lblSelectTimer.Location = (System.Drawing.Point) resources.GetObject("lblSelectTimer.Location");

        this.lblSelectTimer.Name = "lblSelectTimer";

        this.lblSelectTimer.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblSelectTimer.RightToLeft");

        this.lblSelectTimer.Size = (System.Drawing.Size) resources.GetObject("lblSelectTimer.Size");

        this.lblSelectTimer.TabIndex = (int) resources.GetObject("lblSelectTimer.TabIndex");

        this.lblSelectTimer.Text = resources.GetString("lblSelectTimer.Text");

        this.lblSelectTimer.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblSelectTimer.TextAlign");

        this.lblSelectTimer.Visible = (bool) resources.GetObject("lblSelectTimer.Visible");

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

        //cboCategories

        //

        this.cboCategories.AccessibleDescription = resources.GetString("cboCategories.AccessibleDescription");

        this.cboCategories.AccessibleName = resources.GetString("cboCategories.AccessibleName");

        this.cboCategories.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboCategories.Anchor");

        this.cboCategories.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboCategories.BackgroundImage");

        this.cboCategories.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboCategories.Dock");

        this.cboCategories.Enabled = (bool) resources.GetObject("cboCategories.Enabled");

        this.cboCategories.Font = (System.Drawing.Font) resources.GetObject("cboCategories.Font");

        this.cboCategories.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboCategories.ImeMode");

        this.cboCategories.IntegralHeight = (bool) resources.GetObject("cboCategories.IntegralHeight");

        this.cboCategories.ItemHeight = (int) resources.GetObject("cboCategories.ItemHeight");

        this.cboCategories.Location = (System.Drawing.Point) resources.GetObject("cboCategories.Location");

        this.cboCategories.MaxDropDownItems = (int) resources.GetObject("cboCategories.MaxDropDownItems");

        this.cboCategories.MaxLength = (int) resources.GetObject("cboCategories.MaxLength");

        this.cboCategories.Name = "cboCategories";

        this.cboCategories.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboCategories.RightToLeft");

        this.cboCategories.Size = (System.Drawing.Size) resources.GetObject("cboCategories.Size");

        this.cboCategories.TabIndex = (int) resources.GetObject("cboCategories.TabIndex");

        this.cboCategories.Text = resources.GetString("cboCategories.Text");

        this.cboCategories.Visible = (bool) resources.GetObject("cboCategories.Visible");

        //

        //txtCounterValue

        //

        this.txtCounterValue.AccessibleDescription = resources.GetString("txtCounterValue.AccessibleDescription");

        this.txtCounterValue.AccessibleName = resources.GetString("txtCounterValue.AccessibleName");

        this.txtCounterValue.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCounterValue.Anchor");

        this.txtCounterValue.AutoSize = (bool) resources.GetObject("txtCounterValue.AutoSize");

        this.txtCounterValue.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCounterValue.BackgroundImage");

        this.txtCounterValue.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCounterValue.Dock");

        this.txtCounterValue.Enabled = (bool) resources.GetObject("txtCounterValue.Enabled");

        this.txtCounterValue.Font = (System.Drawing.Font) resources.GetObject("txtCounterValue.Font");

        this.txtCounterValue.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCounterValue.ImeMode");

        this.txtCounterValue.Location = (System.Drawing.Point) resources.GetObject("txtCounterValue.Location");

        this.txtCounterValue.MaxLength = (int) resources.GetObject("txtCounterValue.MaxLength");

        this.txtCounterValue.Multiline = (bool) resources.GetObject("txtCounterValue.Multiline");

        this.txtCounterValue.Name = "txtCounterValue";

        this.txtCounterValue.PasswordChar = (char) resources.GetObject("txtCounterValue.PasswordChar");

        this.txtCounterValue.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCounterValue.RightToLeft");

        this.txtCounterValue.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCounterValue.ScrollBars");

        this.txtCounterValue.Size = (System.Drawing.Size) resources.GetObject("txtCounterValue.Size");

        this.txtCounterValue.TabIndex = (int) resources.GetObject("txtCounterValue.TabIndex");

        this.txtCounterValue.TabStop = false;

        this.txtCounterValue.Text = resources.GetString("txtCounterValue.Text");

        this.txtCounterValue.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCounterValue.TextAlign");

        this.txtCounterValue.Visible = (bool) resources.GetObject("txtCounterValue.Visible");

        this.txtCounterValue.WordWrap = (bool) resources.GetObject("txtCounterValue.WordWrap");

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

        //txtCounterType

        //

        this.txtCounterType.AccessibleDescription = resources.GetString("txtCounterType.AccessibleDescription");

        this.txtCounterType.AccessibleName = resources.GetString("txtCounterType.AccessibleName");

        this.txtCounterType.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCounterType.Anchor");

        this.txtCounterType.AutoSize = (bool) resources.GetObject("txtCounterType.AutoSize");

        this.txtCounterType.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCounterType.BackgroundImage");

        this.txtCounterType.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCounterType.Dock");

        this.txtCounterType.Enabled = (bool) resources.GetObject("txtCounterType.Enabled");

        this.txtCounterType.Font = (System.Drawing.Font) resources.GetObject("txtCounterType.Font");

        this.txtCounterType.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCounterType.ImeMode");

        this.txtCounterType.Location = (System.Drawing.Point) resources.GetObject("txtCounterType.Location");

        this.txtCounterType.MaxLength = (int) resources.GetObject("txtCounterType.MaxLength");

        this.txtCounterType.Multiline = (bool) resources.GetObject("txtCounterType.Multiline");

        this.txtCounterType.Name = "txtCounterType";

        this.txtCounterType.PasswordChar = (char) resources.GetObject("txtCounterType.PasswordChar");

        this.txtCounterType.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCounterType.RightToLeft");

        this.txtCounterType.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCounterType.ScrollBars");

        this.txtCounterType.Size = (System.Drawing.Size) resources.GetObject("txtCounterType.Size");

        this.txtCounterType.TabIndex = (int) resources.GetObject("txtCounterType.TabIndex");

        this.txtCounterType.TabStop = false;

        this.txtCounterType.Text = resources.GetString("txtCounterType.Text");

        this.txtCounterType.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCounterType.TextAlign");

        this.txtCounterType.Visible = (bool) resources.GetObject("txtCounterType.Visible");

        this.txtCounterType.WordWrap = (bool) resources.GetObject("txtCounterType.WordWrap");

        //

        //lblCounterType

        //

        this.lblCounterType.AccessibleDescription = resources.GetString("lblCounterType.AccessibleDescription");

        this.lblCounterType.AccessibleName = resources.GetString("lblCounterType.AccessibleName");

        this.lblCounterType.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblCounterType.Anchor");

        this.lblCounterType.AutoSize = (bool) resources.GetObject("lblCounterType.AutoSize");

        this.lblCounterType.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblCounterType.Dock");

        this.lblCounterType.Enabled = (bool) resources.GetObject("lblCounterType.Enabled");

        this.lblCounterType.Font = (System.Drawing.Font) resources.GetObject("lblCounterType.Font");

        this.lblCounterType.Image = (System.Drawing.Image) resources.GetObject("lblCounterType.Image");

        this.lblCounterType.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCounterType.ImageAlign");

        this.lblCounterType.ImageIndex = (int) resources.GetObject("lblCounterType.ImageIndex");

        this.lblCounterType.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblCounterType.ImeMode");

        this.lblCounterType.Location = (System.Drawing.Point) resources.GetObject("lblCounterType.Location");

        this.lblCounterType.Name = "lblCounterType";

        this.lblCounterType.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblCounterType.RightToLeft");

        this.lblCounterType.Size = (System.Drawing.Size) resources.GetObject("lblCounterType.Size");

        this.lblCounterType.TabIndex = (int) resources.GetObject("lblCounterType.TabIndex");

        this.lblCounterType.Text = resources.GetString("lblCounterType.Text");

        this.lblCounterType.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCounterType.TextAlign");

        this.lblCounterType.Visible = (bool) resources.GetObject("lblCounterType.Visible");

        //

        //txtCounterHelp

        //

        this.txtCounterHelp.AccessibleDescription = resources.GetString("txtCounterHelp.AccessibleDescription");

        this.txtCounterHelp.AccessibleName = resources.GetString("txtCounterHelp.AccessibleName");

        this.txtCounterHelp.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCounterHelp.Anchor");

        this.txtCounterHelp.AutoSize = (bool) resources.GetObject("txtCounterHelp.AutoSize");

        this.txtCounterHelp.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCounterHelp.BackgroundImage");

        this.txtCounterHelp.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCounterHelp.Dock");

        this.txtCounterHelp.Enabled = (bool) resources.GetObject("txtCounterHelp.Enabled");

        this.txtCounterHelp.Font = (System.Drawing.Font) resources.GetObject("txtCounterHelp.Font");

        this.txtCounterHelp.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCounterHelp.ImeMode");

        this.txtCounterHelp.Location = (System.Drawing.Point) resources.GetObject("txtCounterHelp.Location");

        this.txtCounterHelp.MaxLength = (int) resources.GetObject("txtCounterHelp.MaxLength");

        this.txtCounterHelp.Multiline = (bool) resources.GetObject("txtCounterHelp.Multiline");

        this.txtCounterHelp.Name = "txtCounterHelp";

        this.txtCounterHelp.PasswordChar = (char) resources.GetObject("txtCounterHelp.PasswordChar");

        this.txtCounterHelp.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCounterHelp.RightToLeft");

        this.txtCounterHelp.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCounterHelp.ScrollBars");

        this.txtCounterHelp.Size = (System.Drawing.Size) resources.GetObject("txtCounterHelp.Size");

        this.txtCounterHelp.TabIndex = (int) resources.GetObject("txtCounterHelp.TabIndex");

        this.txtCounterHelp.TabStop = false;

        this.txtCounterHelp.Text = resources.GetString("txtCounterHelp.Text");

        this.txtCounterHelp.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCounterHelp.TextAlign");

        this.txtCounterHelp.Visible = (bool) resources.GetObject("txtCounterHelp.Visible");

        this.txtCounterHelp.WordWrap = (bool) resources.GetObject("txtCounterHelp.WordWrap");

        //

        //Label3

        //

        this.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription");

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

        //lblBuiltInOrCustom

        //

        this.lblBuiltInOrCustom.AccessibleDescription = resources.GetString("lblBuiltInOrCustom.AccessibleDescription");

        this.lblBuiltInOrCustom.AccessibleName = resources.GetString("lblBuiltInOrCustom.AccessibleName");

        this.lblBuiltInOrCustom.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblBuiltInOrCustom.Anchor");

        this.lblBuiltInOrCustom.AutoSize = (bool) resources.GetObject("lblBuiltInOrCustom.AutoSize");

        this.lblBuiltInOrCustom.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblBuiltInOrCustom.Dock");

        this.lblBuiltInOrCustom.Enabled = (bool) resources.GetObject("lblBuiltInOrCustom.Enabled");

        this.lblBuiltInOrCustom.Font = (System.Drawing.Font) resources.GetObject("lblBuiltInOrCustom.Font");

        this.lblBuiltInOrCustom.Image = (System.Drawing.Image) resources.GetObject("lblBuiltInOrCustom.Image");

        this.lblBuiltInOrCustom.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblBuiltInOrCustom.ImageAlign");

        this.lblBuiltInOrCustom.ImageIndex = (int) resources.GetObject("lblBuiltInOrCustom.ImageIndex");

        this.lblBuiltInOrCustom.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblBuiltInOrCustom.ImeMode");

        this.lblBuiltInOrCustom.Location = (System.Drawing.Point) resources.GetObject("lblBuiltInOrCustom.Location");

        this.lblBuiltInOrCustom.Name = "lblBuiltInOrCustom";

        this.lblBuiltInOrCustom.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblBuiltInOrCustom.RightToLeft");

        this.lblBuiltInOrCustom.Size = (System.Drawing.Size) resources.GetObject("lblBuiltInOrCustom.Size");

        this.lblBuiltInOrCustom.TabIndex = (int) resources.GetObject("lblBuiltInOrCustom.TabIndex");

        this.lblBuiltInOrCustom.Text = resources.GetString("lblBuiltInOrCustom.Text");

        this.lblBuiltInOrCustom.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblBuiltInOrCustom.TextAlign");

        this.lblBuiltInOrCustom.Visible = (bool) resources.GetObject("lblBuiltInOrCustom.Visible");

        //

        //txtBuiltInOrCustom

        //

        this.txtBuiltInOrCustom.AccessibleDescription = resources.GetString("txtBuiltInOrCustom.AccessibleDescription");

        this.txtBuiltInOrCustom.AccessibleName = resources.GetString("txtBuiltInOrCustom.AccessibleName");

        this.txtBuiltInOrCustom.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtBuiltInOrCustom.Anchor");

        this.txtBuiltInOrCustom.AutoSize = (bool) resources.GetObject("txtBuiltInOrCustom.AutoSize");

        this.txtBuiltInOrCustom.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtBuiltInOrCustom.BackgroundImage");

        this.txtBuiltInOrCustom.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtBuiltInOrCustom.Dock");

        this.txtBuiltInOrCustom.Enabled = (bool) resources.GetObject("txtBuiltInOrCustom.Enabled");

        this.txtBuiltInOrCustom.Font = (System.Drawing.Font) resources.GetObject("txtBuiltInOrCustom.Font");

        this.txtBuiltInOrCustom.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtBuiltInOrCustom.ImeMode");

        this.txtBuiltInOrCustom.Location = (System.Drawing.Point) resources.GetObject("txtBuiltInOrCustom.Location");

        this.txtBuiltInOrCustom.MaxLength = (int) resources.GetObject("txtBuiltInOrCustom.MaxLength");

        this.txtBuiltInOrCustom.Multiline = (bool) resources.GetObject("txtBuiltInOrCustom.Multiline");

        this.txtBuiltInOrCustom.Name = "txtBuiltInOrCustom";

        this.txtBuiltInOrCustom.PasswordChar = (char) resources.GetObject("txtBuiltInOrCustom.PasswordChar");

        this.txtBuiltInOrCustom.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtBuiltInOrCustom.RightToLeft");

        this.txtBuiltInOrCustom.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtBuiltInOrCustom.ScrollBars");

        this.txtBuiltInOrCustom.Size = (System.Drawing.Size) resources.GetObject("txtBuiltInOrCustom.Size");

        this.txtBuiltInOrCustom.TabIndex = (int) resources.GetObject("txtBuiltInOrCustom.TabIndex");

        this.txtBuiltInOrCustom.Text = resources.GetString("txtBuiltInOrCustom.Text");

        this.txtBuiltInOrCustom.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtBuiltInOrCustom.TextAlign");

        this.txtBuiltInOrCustom.Visible = (bool) resources.GetObject("txtBuiltInOrCustom.Visible");

        this.txtBuiltInOrCustom.WordWrap = (bool) resources.GetObject("txtBuiltInOrCustom.WordWrap");

        //

        //btnIncrementCounter

        //

        this.btnIncrementCounter.AccessibleDescription = resources.GetString("btnIncrementCounter.AccessibleDescription");

        this.btnIncrementCounter.AccessibleName = resources.GetString("btnIncrementCounter.AccessibleName");

        this.btnIncrementCounter.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnIncrementCounter.Anchor");

        this.btnIncrementCounter.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnIncrementCounter.BackgroundImage");

        this.btnIncrementCounter.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnIncrementCounter.Dock");

        this.btnIncrementCounter.Enabled = (bool) resources.GetObject("btnIncrementCounter.Enabled");

        this.btnIncrementCounter.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnIncrementCounter.FlatStyle");

        this.btnIncrementCounter.Font = (System.Drawing.Font) resources.GetObject("btnIncrementCounter.Font");

        this.btnIncrementCounter.Image = (System.Drawing.Image) resources.GetObject("btnIncrementCounter.Image");

        this.btnIncrementCounter.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnIncrementCounter.ImageAlign");

        this.btnIncrementCounter.ImageIndex = (int) resources.GetObject("btnIncrementCounter.ImageIndex");

        this.btnIncrementCounter.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnIncrementCounter.ImeMode");

        this.btnIncrementCounter.Location = (System.Drawing.Point) resources.GetObject("btnIncrementCounter.Location");

        this.btnIncrementCounter.Name = "btnIncrementCounter";

        this.btnIncrementCounter.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnIncrementCounter.RightToLeft");

        this.btnIncrementCounter.Size = (System.Drawing.Size) resources.GetObject("btnIncrementCounter.Size");

        this.btnIncrementCounter.TabIndex = (int) resources.GetObject("btnIncrementCounter.TabIndex");

        this.btnIncrementCounter.Text = resources.GetString("btnIncrementCounter.Text");

        this.btnIncrementCounter.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnIncrementCounter.TextAlign");

        this.btnIncrementCounter.Visible = (bool) resources.GetObject("btnIncrementCounter.Visible");

        //

        //btnDecrementCounter

        //

        this.btnDecrementCounter.AccessibleDescription = resources.GetString("btnDecrementCounter.AccessibleDescription");

        this.btnDecrementCounter.AccessibleName = resources.GetString("btnDecrementCounter.AccessibleName");

        this.btnDecrementCounter.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnDecrementCounter.Anchor");

        this.btnDecrementCounter.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnDecrementCounter.BackgroundImage");

        this.btnDecrementCounter.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnDecrementCounter.Dock");

        this.btnDecrementCounter.Enabled = (bool) resources.GetObject("btnDecrementCounter.Enabled");

        this.btnDecrementCounter.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnDecrementCounter.FlatStyle");

        this.btnDecrementCounter.Font = (System.Drawing.Font) resources.GetObject("btnDecrementCounter.Font");

        this.btnDecrementCounter.Image = (System.Drawing.Image) resources.GetObject("btnDecrementCounter.Image");

        this.btnDecrementCounter.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDecrementCounter.ImageAlign");

        this.btnDecrementCounter.ImageIndex = (int) resources.GetObject("btnDecrementCounter.ImageIndex");

        this.btnDecrementCounter.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnDecrementCounter.ImeMode");

        this.btnDecrementCounter.Location = (System.Drawing.Point) resources.GetObject("btnDecrementCounter.Location");

        this.btnDecrementCounter.Name = "btnDecrementCounter";

        this.btnDecrementCounter.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnDecrementCounter.RightToLeft");

        this.btnDecrementCounter.Size = (System.Drawing.Size) resources.GetObject("btnDecrementCounter.Size");

        this.btnDecrementCounter.TabIndex = (int) resources.GetObject("btnDecrementCounter.TabIndex");

        this.btnDecrementCounter.Text = resources.GetString("btnDecrementCounter.Text");

        this.btnDecrementCounter.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDecrementCounter.TextAlign");

        this.btnDecrementCounter.Visible = (bool) resources.GetObject("btnDecrementCounter.Visible");

        //

        //sbrStatus

        //

        this.sbrStatus.AccessibleDescription = resources.GetString("sbrStatus.AccessibleDescription");

        this.sbrStatus.AccessibleName = resources.GetString("sbrStatus.AccessibleName");

        this.sbrStatus.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("sbrStatus.Anchor");

        this.sbrStatus.BackgroundImage = (System.Drawing.Image) resources.GetObject("sbrStatus.BackgroundImage");

        this.sbrStatus.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("sbrStatus.Dock");

        this.sbrStatus.Enabled = (bool) resources.GetObject("sbrStatus.Enabled");

        this.sbrStatus.Font = (System.Drawing.Font) resources.GetObject("sbrStatus.Font");

        this.sbrStatus.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("sbrStatus.ImeMode");

        this.sbrStatus.Location = (System.Drawing.Point) resources.GetObject("sbrStatus.Location");

        this.sbrStatus.Name = "sbrStatus";

        this.sbrStatus.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("sbrStatus.RightToLeft");

        this.sbrStatus.Size = (System.Drawing.Size) resources.GetObject("sbrStatus.Size");

        this.sbrStatus.TabIndex = (int) resources.GetObject("sbrStatus.TabIndex");

        this.sbrStatus.Text = resources.GetString("sbrStatus.Text");

        this.sbrStatus.Visible = (bool) resources.GetObject("sbrStatus.Visible");

        //

        //lblAddingACustomControl

        //

        this.lblAddingACustomControl.AccessibleDescription = resources.GetString("lblAddingACustomControl.AccessibleDescription");

        this.lblAddingACustomControl.AccessibleName = resources.GetString("lblAddingACustomControl.AccessibleName");

        this.lblAddingACustomControl.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblAddingACustomControl.Anchor");

        this.lblAddingACustomControl.AutoSize = (bool) resources.GetObject("lblAddingACustomControl.AutoSize");

        this.lblAddingACustomControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.lblAddingACustomControl.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblAddingACustomControl.Dock");

        this.lblAddingACustomControl.Enabled = (bool) resources.GetObject("lblAddingACustomControl.Enabled");

        this.lblAddingACustomControl.Font = (System.Drawing.Font) resources.GetObject("lblAddingACustomControl.Font");

        this.lblAddingACustomControl.Image = (System.Drawing.Image) resources.GetObject("lblAddingACustomControl.Image");

        this.lblAddingACustomControl.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblAddingACustomControl.ImageAlign");

        this.lblAddingACustomControl.ImageIndex = (int) resources.GetObject("lblAddingACustomControl.ImageIndex");

        this.lblAddingACustomControl.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblAddingACustomControl.ImeMode");

        this.lblAddingACustomControl.Location = (System.Drawing.Point) resources.GetObject("lblAddingACustomControl.Location");

        this.lblAddingACustomControl.Name = "lblAddingACustomControl";

        this.lblAddingACustomControl.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblAddingACustomControl.RightToLeft");

        this.lblAddingACustomControl.Size = (System.Drawing.Size) resources.GetObject("lblAddingACustomControl.Size");

        this.lblAddingACustomControl.TabIndex = (int) resources.GetObject("lblAddingACustomControl.TabIndex");

        this.lblAddingACustomControl.Text = resources.GetString("lblAddingACustomControl.Text");

        this.lblAddingACustomControl.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblAddingACustomControl.TextAlign");

        this.lblAddingACustomControl.Visible = (bool) resources.GetObject("lblAddingACustomControl.Visible");

        //

        //btnRefreshCategories

        //

        this.btnRefreshCategories.AccessibleDescription = resources.GetString("btnRefreshCategories.AccessibleDescription");

        this.btnRefreshCategories.AccessibleName = resources.GetString("btnRefreshCategories.AccessibleName");

        this.btnRefreshCategories.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRefreshCategories.Anchor");

        this.btnRefreshCategories.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRefreshCategories.BackgroundImage");

        this.btnRefreshCategories.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRefreshCategories.Dock");

        this.btnRefreshCategories.Enabled = (bool) resources.GetObject("btnRefreshCategories.Enabled");

        this.btnRefreshCategories.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRefreshCategories.FlatStyle");

        this.btnRefreshCategories.Font = (System.Drawing.Font) resources.GetObject("btnRefreshCategories.Font");

        this.btnRefreshCategories.Image = (System.Drawing.Image) resources.GetObject("btnRefreshCategories.Image");

        this.btnRefreshCategories.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefreshCategories.ImageAlign");

        this.btnRefreshCategories.ImageIndex = (int) resources.GetObject("btnRefreshCategories.ImageIndex");

        this.btnRefreshCategories.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRefreshCategories.ImeMode");

        this.btnRefreshCategories.Location = (System.Drawing.Point) resources.GetObject("btnRefreshCategories.Location");

        this.btnRefreshCategories.Name = "btnRefreshCategories";

        this.btnRefreshCategories.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRefreshCategories.RightToLeft");

        this.btnRefreshCategories.Size = (System.Drawing.Size) resources.GetObject("btnRefreshCategories.Size");

        this.btnRefreshCategories.TabIndex = (int) resources.GetObject("btnRefreshCategories.TabIndex");

        this.btnRefreshCategories.Text = resources.GetString("btnRefreshCategories.Text");

        this.btnRefreshCategories.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefreshCategories.TextAlign");

        this.btnRefreshCategories.Visible = (bool) resources.GetObject("btnRefreshCategories.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnRefreshCategories, this.lblAddingACustomControl, this.sbrStatus, this.btnDecrementCounter, this.btnIncrementCounter, this.txtBuiltInOrCustom, this.lblBuiltInOrCustom, this.Label3, this.txtCounterHelp, this.lblCounterType, this.txtCounterType, this.Label2, this.txtCounterValue, this.Label1, this.cboCategories, this.lblSelectTimer, this.cboCounters});

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
		this.Load += new EventHandler(frmMain_Load);
		this.btnDecrementCounter.Click += new EventHandler(btnDecrementCounter_Click);
		this.btnIncrementCounter.Click += new EventHandler(btnIncrementCounter_Click);
		this.btnRefreshCategories.Click += new EventHandler(btnRefreshCategories_Click);
		this.cboCategories.SelectedIndexChanged += new EventHandler(cboCategories_SelectedIndexChanged);
		this.cboCounters.SelectedIndexChanged += new EventHandler(cboCounters_SelectedIndexChanged);
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
		this.tmrUpdateUI.Tick += new EventHandler(tmrUpdateUI_Tick);
    }
	#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

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

    // This subroutine decrements the value of a custom counter. It 
    //   can only be executed when the counter selected is a
    //   custom counter -- only custom counters can have their readonly properies
    //   set to false. 
	private void btnDecrementCounter_Click(object sender, System.EventArgs e) 
	{
        // This button is only enabled when the selected
        //   counter is a Custom counter, so we can set the read-only to
        //   false, and use it. Still, use a try-Catch...
        try 
		{
            // Set readonly to false, so that the counter can be manipulated
            m_Counter.ReadOnly = false;

            // Only decrement the counter if it has a value > 0
            //   Although this isn't technically necessary, it makes logical
            //   sense.  
			if (m_Counter.RawValue > 0)
			{
				m_Counter.Decrement();
				sbrStatus.Text = string.Empty;
			}
            else 
			{
				// Display the status to the user.
				sbrStatus.Text = "Counter is already zero.";
			}
		}
		catch(Exception)
		{
            // In case an Exception is raised, explain that the counter
            //   could not be decremented.
            sbrStatus.Text = "Could not decrement counter.";
        }
    }

	// This subroutine increments the value of a custom counter. It 
    //   can only be executed when the counter selected is a
    //   custom counter -- only custom counters can have their readonly properies
    //   set to false. 
    private void btnIncrementCounter_Click(object sender, System.EventArgs e) 
	{
        // This button is only enabled when the selected
        //   counter is a Custom counter, so we can set the read-only to
        //   false, and use it. Still, use a try-catch...
		try 
		{
			// Set readonly to false, so that the counter can be manipulated
			m_Counter.ReadOnly = false;
			m_Counter.Increment();
			sbrStatus.Text = string.Empty;
		}
		catch
		{
            // In case an Exception is raised, explain that the counter
            //   could not be incremented.
            sbrStatus.Text = "Could not increment counter.";
        }
    }

    // This subroutine enables the user to refresh the form after adding
    //   a custom PerformanceCounter using the Server Explorer.
    private void btnRefreshCategories_Click(object sender, System.EventArgs e)
	{
        // Reset the User Interface
        this.cboCategories.Items.Clear();
        this.cboCounters.Items.Clear();
        this.m_Counter = null;
        this.txtBuiltInOrCustom.Text = string.Empty;
        this.txtCounterHelp.Text = string.Empty;
        this.txtCounterType.Text = string.Empty;
        this.txtCounterValue.Text = string.Empty;
        this.btnDecrementCounter.Enabled = false;
        this.btnIncrementCounter.Enabled = false;
        this.cboCategories.Text = string.Empty;
        this.cboCounters.Text = string.Empty;

		// Call the Form_Load event
        this.frmMain_Load(this, new System.EventArgs());
    }

    // This event handler is fired whenever the user changes the selected 
    //   counter category. It then changes the cboCounters combo box to 
    //   reflect the counters available for that category. 

	// Note that this routine makes heavy use of the CounterDisplayItem
    //   class that is defined in this How-To. The CounterDisplayItem allows
    //   us to take advantage of the way a combo box displays items -- if it
    //   contains an object, the Tostring() method is called to fill the display.
    //   This is very important, since we must take into account both the 
    //   "instance" (what process to watch) and the particular counter that
    //   is associated with that instance. (For instance, you can measure the 
    //   number of CLR bytes compiled overall in the system, or just for a 
    //   particular instance of a running .NET program.)
    private void cboCategories_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        PerformanceCounterCategory myCategory;
        ArrayList myCounters = new ArrayList();
        string[] myCounterNames;

        if (cboCategories.SelectedIndex != -1)
		{
            // Fill cboCounters with Counter names
            try 
			{
                // Get the available category
                myCategory = new PerformanceCounterCategory(this.cboCategories.SelectedItem.ToString());
                
                // Get all available instances for the selected category
                myCounterNames = myCategory.GetInstanceNames();

                // if there are no instances, then the counters are likely
                //   generic, so get the counters that are available (they
                //   will have no instance value).

				if (myCounterNames.Length == 0)
				{
					myCounters.AddRange(myCategory.GetCounters());
				}
				else 
				{
					for(int i = 0; i < myCounterNames.Length; i++)
					{	
						myCounters.AddRange(myCategory.GetCounters(myCounterNames[i]));
					}
                }

                // Clear the cboCounter box + reset text
                this.cboCounters.Items.Clear();
                this.cboCounters.Text = string.Empty;

                // Add the counters to the cboCounters combo box. Use the
                //   CounterDisplayItem class to ensure that they are properly
                //   displayed, and also to ensure that there is a reference
                //   to the actual counter stored in the combo box item.
                foreach(PerformanceCounter myCounter in myCounters)
				{
                    this.cboCounters.Items.Add(new CounterDisplayItem(myCounter));
                }
			} 
			catch(Exception)
			{
				// Alert the user, if the program is unable to list the 
                //   counters in this category.
                MessageBox.Show("Unable to list the Counters in this Category. Please select another Category.");
            }
        }
    }

	// This event handler is fired whenever the user changes the selected 
    //   counter. It then set the class variable 'm_Counter' to the actual
    //   value of the counter (using the CounterDisplayItem object that was
    //   stored in the cboCounters combo box). After the assignment is made,
    //   information about the counter is displayed in the UI.

	// Note that this routine makes use of the CounterDisplayItem
    //   class that is defined in this How-To. 
    private void cboCounters_SelectedIndexChanged(object sender, System.EventArgs e)
	{
        CounterDisplayItem myCounterDisplay;
        
		try 
		{
			// Get the CounterDisplayItem associated with the selection
			myCounterDisplay = (CounterDisplayItem) cboCounters.SelectedItem;

			// Get the PerformanceCounter object stored in the CounterDisplayItem
			m_Counter = myCounterDisplay.Counter;

			// Display information about the Counter to the user
			this.txtCounterType.Text = m_Counter.CounterType.ToString();
			this.txtCounterHelp.Text = m_Counter.CounterHelp.ToString();
			this.sbrStatus.Text = string.Empty;

			// if the counter is a custom counter, enable the appropriate
			//   buttons.  Only custom items can be written to.

			// Note: the CounterDisplayItem shows the code necessary to determine
			//   if a counter is custom or not.
			if (myCounterDisplay.IsCustom) 
			{
				// Enable Increment and Decrement buttons
				this.txtBuiltInOrCustom.Text = "Custom";
				this.btnDecrementCounter.Enabled = true;
				this.btnIncrementCounter.Enabled = true;
			}
			else 
			{
				// Disable Increment and Decrement buttons
				this.txtBuiltInOrCustom.Text = "Built-In";
				this.btnDecrementCounter.Enabled = false;
				this.btnIncrementCounter.Enabled = false;
			}

		}
		catch(Exception)
		{
			// Set the class counter to null if there was an error.
			m_Counter = null;
		}
    }

    // This subroutine loads the cboCategories combo box with a list
    //   of all the available categories on the local machine.  It also
    //   starts the timer, so that the UI will be updated every half second.
    private void frmMain_Load(object sender, System.EventArgs e) 
	{
        // Fill cboCounters with available counters
		PerformanceCounter myCounters;
        PerformanceCounterCategory[] myCategories;
		PerformanceCounterCategory myCategory;

        // Set myCategories to contain all of the available Categories
        myCategories = PerformanceCounterCategory.GetCategories();

        // Declare a string array with the proper length
        string[] myCategoryNames = new string[myCategories.Length];

		// Used a counter
        int i = 0; 

        // Loop through the available categories, adding them to an
        //   array of strings. (This is done so that the categories can be
        //   be sorted.)
        foreach(PerformanceCounterCategory someCategory in myCategories)
		{
            myCategoryNames[i] = someCategory.CategoryName;
            i++;
        }

		// Sort the array
        Array.Sort(myCategoryNames);

        // Add each value of the array to the cboCategories combo box.
        foreach(string namestring in myCategoryNames)
		{
            this.cboCategories.Items.Add(namestring);
        }

        // Start the timer
        this.tmrUpdateUI.Interval = 500;
        this.tmrUpdateUI.Enabled = true;
    }

    // This event handler updates the value of the counter in the 
    //   user interface.
    private void tmrUpdateUI_Tick(object sender, System.EventArgs e)
	{
        // Verify that a Counter exists
        //   if it does, get its type and value. (Use try-catch, just in case.)
		try 
		{
			if (m_Counter != null)
			{
				this.txtCounterValue.Text = m_Counter.NextValue().ToString();
			}
		}
		catch(Exception)
		{
            this.txtCounterValue.Text = string.Empty;
        }
    }
}
