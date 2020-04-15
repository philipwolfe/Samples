//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

// This allows use of WMI objects, to get this statement to compile a reference must
// be set.

using System.Management;
using System;
using System.Windows.Forms;

public class frmMain: System.Windows.Forms.Form {

    const string CRLF = "\r\n";

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

    private System.Windows.Forms.TabPage tpWMIQueries;

    private System.Windows.Forms.TextBox txtOutput;

    private System.Windows.Forms.Button btnOperatingSytem;

    private System.Windows.Forms.Button btnComputerSystem;

    private System.Windows.Forms.Button btnProcessor;

    private System.Windows.Forms.Button btnBios;

    private System.Windows.Forms.Button btnTimeZone;

    private System.Windows.Forms.TabPage tpAsynchEnum;

    private System.Windows.Forms.ColumnHeader DriveName;

    private System.Windows.Forms.Button btnStartEnum;

    private System.Windows.Forms.ColumnHeader DriveLabel;

    private System.Windows.Forms.ColumnHeader DriveSize;

    private System.Windows.Forms.ColumnHeader DriveFreeSpace;

    private System.Windows.Forms.ListView lvDriveList;

    private System.Windows.Forms.TabPage tpWMIClasses;

    private System.Windows.Forms.ListBox lstWMIClasses;

    private System.Windows.Forms.Button btnClassEnum;

    private System.Windows.Forms.Label lblInstructions;

    private System.Windows.Forms.Label lblInstructions2;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.CheckBox chkIncludeSubclasses;

    private System.Windows.Forms.TabControl MainTabControl;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.MainTabControl = new System.Windows.Forms.TabControl();

        this.tpWMIQueries = new System.Windows.Forms.TabPage();

        this.lblInstructions = new System.Windows.Forms.Label();

        this.btnTimeZone = new System.Windows.Forms.Button();

        this.btnBios = new System.Windows.Forms.Button();

        this.btnProcessor = new System.Windows.Forms.Button();

        this.btnComputerSystem = new System.Windows.Forms.Button();

        this.btnOperatingSytem = new System.Windows.Forms.Button();

        this.txtOutput = new System.Windows.Forms.TextBox();

        this.tpAsynchEnum = new System.Windows.Forms.TabPage();

        this.lblInstructions2 = new System.Windows.Forms.Label();

        this.btnStartEnum = new System.Windows.Forms.Button();

        this.lvDriveList = new System.Windows.Forms.ListView();

        this.DriveName = new System.Windows.Forms.ColumnHeader();

        this.DriveLabel = new System.Windows.Forms.ColumnHeader();

        this.DriveSize = new System.Windows.Forms.ColumnHeader();

        this.DriveFreeSpace = new System.Windows.Forms.ColumnHeader();

        this.tpWMIClasses = new System.Windows.Forms.TabPage();

        this.chkIncludeSubclasses = new System.Windows.Forms.CheckBox();

        this.Label1 = new System.Windows.Forms.Label();

        this.btnClassEnum = new System.Windows.Forms.Button();

        this.lstWMIClasses = new System.Windows.Forms.ListBox();

        this.MainTabControl.SuspendLayout();

        this.tpWMIQueries.SuspendLayout();

        this.tpAsynchEnum.SuspendLayout();

        this.tpWMIClasses.SuspendLayout();

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

        //MainTabControl

        //

        this.MainTabControl.AccessibleDescription = resources.GetString("MainTabControl.AccessibleDescription");

        this.MainTabControl.AccessibleName = resources.GetString("MainTabControl.AccessibleName");

        this.MainTabControl.Alignment = (System.Windows.Forms.TabAlignment) resources.GetObject("MainTabControl.Alignment");

        this.MainTabControl.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("MainTabControl.Anchor");

        this.MainTabControl.Appearance = (System.Windows.Forms.TabAppearance) resources.GetObject("MainTabControl.Appearance");

        this.MainTabControl.BackgroundImage = (System.Drawing.Image) resources.GetObject("MainTabControl.BackgroundImage");

        this.MainTabControl.Controls.AddRange(new System.Windows.Forms.Control[] {this.tpWMIQueries, this.tpAsynchEnum, this.tpWMIClasses});

        this.MainTabControl.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("MainTabControl.Dock");

        this.MainTabControl.Enabled = (bool) resources.GetObject("MainTabControl.Enabled");

        this.MainTabControl.Font = (System.Drawing.Font) resources.GetObject("MainTabControl.Font");

        this.MainTabControl.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("MainTabControl.ImeMode");

        this.MainTabControl.ItemSize = (System.Drawing.Size) resources.GetObject("MainTabControl.ItemSize");

        this.MainTabControl.Location = (System.Drawing.Point) resources.GetObject("MainTabControl.Location");

        this.MainTabControl.Name = "MainTabControl";

        this.MainTabControl.Padding = (System.Drawing.Point) resources.GetObject("MainTabControl.Padding");

        this.MainTabControl.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("MainTabControl.RightToLeft");

        this.MainTabControl.SelectedIndex = 0;

        this.MainTabControl.ShowToolTips = (bool) resources.GetObject("MainTabControl.ShowToolTips");

        this.MainTabControl.Size = (System.Drawing.Size) resources.GetObject("MainTabControl.Size");

        this.MainTabControl.TabIndex = (int) resources.GetObject("MainTabControl.TabIndex");

        this.MainTabControl.Text = resources.GetString("MainTabControl.Text");

        this.MainTabControl.Visible = (bool) resources.GetObject("MainTabControl.Visible");

        //

        //tpWMIQueries

        //

        this.tpWMIQueries.AccessibleDescription = resources.GetString("tpWMIQueries.AccessibleDescription");

        this.tpWMIQueries.AccessibleName = resources.GetString("tpWMIQueries.AccessibleName");

        this.tpWMIQueries.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpWMIQueries.Anchor");

        this.tpWMIQueries.AutoScroll = (bool) resources.GetObject("tpWMIQueries.AutoScroll");

        this.tpWMIQueries.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpWMIQueries.AutoScrollMargin");

        this.tpWMIQueries.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpWMIQueries.AutoScrollMinSize");

        this.tpWMIQueries.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpWMIQueries.BackgroundImage");

        this.tpWMIQueries.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblInstructions, this.btnTimeZone, this.btnBios, this.btnProcessor, this.btnComputerSystem, this.btnOperatingSytem, this.txtOutput});

        this.tpWMIQueries.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpWMIQueries.Dock");

        this.tpWMIQueries.Enabled = (bool) resources.GetObject("tpWMIQueries.Enabled");

        this.tpWMIQueries.Font = (System.Drawing.Font) resources.GetObject("tpWMIQueries.Font");

        this.tpWMIQueries.ImageIndex = (int) resources.GetObject("tpWMIQueries.ImageIndex");

        this.tpWMIQueries.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpWMIQueries.ImeMode");

        this.tpWMIQueries.Location = (System.Drawing.Point) resources.GetObject("tpWMIQueries.Location");

        this.tpWMIQueries.Name = "tpWMIQueries";

        this.tpWMIQueries.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpWMIQueries.RightToLeft");

        this.tpWMIQueries.Size = (System.Drawing.Size) resources.GetObject("tpWMIQueries.Size");

        this.tpWMIQueries.TabIndex = (int) resources.GetObject("tpWMIQueries.TabIndex");

        this.tpWMIQueries.Text = resources.GetString("tpWMIQueries.Text");

        this.tpWMIQueries.ToolTipText = resources.GetString("tpWMIQueries.ToolTipText");

        this.tpWMIQueries.Visible = (bool) resources.GetObject("tpWMIQueries.Visible");

        //

        //lblInstructions

        //

        this.lblInstructions.AccessibleDescription = (string) resources.GetObject("lblInstructions.AccessibleDescription");

        this.lblInstructions.AccessibleName = (string) resources.GetObject("lblInstructions.AccessibleName");

        this.lblInstructions.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblInstructions.Anchor");

        this.lblInstructions.AutoSize = (bool) resources.GetObject("lblInstructions.AutoSize");

        this.lblInstructions.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblInstructions.Dock");

        this.lblInstructions.Enabled = (bool) resources.GetObject("lblInstructions.Enabled");

        this.lblInstructions.Font = (System.Drawing.Font) resources.GetObject("lblInstructions.Font");

        this.lblInstructions.ForeColor = System.Drawing.Color.Blue;

        this.lblInstructions.Image = (System.Drawing.Image) resources.GetObject("lblInstructions.Image");

        this.lblInstructions.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblInstructions.ImageAlign");

        this.lblInstructions.ImageIndex = (int) resources.GetObject("lblInstructions.ImageIndex");

        this.lblInstructions.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblInstructions.ImeMode");

        this.lblInstructions.Location = (System.Drawing.Point) resources.GetObject("lblInstructions.Location");

        this.lblInstructions.Name = "lblInstructions";

        this.lblInstructions.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblInstructions.RightToLeft");

        this.lblInstructions.Size = (System.Drawing.Size) resources.GetObject("lblInstructions.Size");

        this.lblInstructions.TabIndex = (int) resources.GetObject("lblInstructions.TabIndex");

        this.lblInstructions.Text = resources.GetString("lblInstructions.Text");

        this.lblInstructions.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblInstructions.TextAlign");

        this.lblInstructions.Visible = (bool) resources.GetObject("lblInstructions.Visible");

        //

        //btnTimeZone

        //

        this.btnTimeZone.AccessibleDescription = resources.GetString("btnTimeZone.AccessibleDescription");

        this.btnTimeZone.AccessibleName = resources.GetString("btnTimeZone.AccessibleName");

        this.btnTimeZone.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnTimeZone.Anchor");

        this.btnTimeZone.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnTimeZone.BackgroundImage");

        this.btnTimeZone.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnTimeZone.Dock");

        this.btnTimeZone.Enabled = (bool) resources.GetObject("btnTimeZone.Enabled");

        this.btnTimeZone.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnTimeZone.FlatStyle");

        this.btnTimeZone.Font = (System.Drawing.Font) resources.GetObject("btnTimeZone.Font");

        this.btnTimeZone.Image = (System.Drawing.Image) resources.GetObject("btnTimeZone.Image");

        this.btnTimeZone.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTimeZone.ImageAlign");

        this.btnTimeZone.ImageIndex = (int) resources.GetObject("btnTimeZone.ImageIndex");

        this.btnTimeZone.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnTimeZone.ImeMode");

        this.btnTimeZone.Location = (System.Drawing.Point) resources.GetObject("btnTimeZone.Location");

        this.btnTimeZone.Name = "btnTimeZone";

        this.btnTimeZone.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnTimeZone.RightToLeft");

        this.btnTimeZone.Size = (System.Drawing.Size) resources.GetObject("btnTimeZone.Size");

        this.btnTimeZone.TabIndex = (int) resources.GetObject("btnTimeZone.TabIndex");

        this.btnTimeZone.Text = resources.GetString("btnTimeZone.Text");

        this.btnTimeZone.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTimeZone.TextAlign");

        this.btnTimeZone.Visible = (bool) resources.GetObject("btnTimeZone.Visible");

        //

        //btnBios

        //

        this.btnBios.AccessibleDescription = resources.GetString("btnBios.AccessibleDescription");

        this.btnBios.AccessibleName = resources.GetString("btnBios.AccessibleName");

        this.btnBios.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnBios.Anchor");

        this.btnBios.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnBios.BackgroundImage");

        this.btnBios.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnBios.Dock");

        this.btnBios.Enabled = (bool) resources.GetObject("btnBios.Enabled");

        this.btnBios.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnBios.FlatStyle");

        this.btnBios.Font = (System.Drawing.Font) resources.GetObject("btnBios.Font");

        this.btnBios.Image = (System.Drawing.Image) resources.GetObject("btnBios.Image");

        this.btnBios.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBios.ImageAlign");

        this.btnBios.ImageIndex = (int) resources.GetObject("btnBios.ImageIndex");

        this.btnBios.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnBios.ImeMode");

        this.btnBios.Location = (System.Drawing.Point) resources.GetObject("btnBios.Location");

        this.btnBios.Name = "btnBios";

        this.btnBios.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnBios.RightToLeft");

        this.btnBios.Size = (System.Drawing.Size) resources.GetObject("btnBios.Size");

        this.btnBios.TabIndex = (int) resources.GetObject("btnBios.TabIndex");

        this.btnBios.Text = resources.GetString("btnBios.Text");

        this.btnBios.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBios.TextAlign");

        this.btnBios.Visible = (bool) resources.GetObject("btnBios.Visible");

        //

        //btnProcessor

        //

        this.btnProcessor.AccessibleDescription = resources.GetString("btnProcessor.AccessibleDescription");

        this.btnProcessor.AccessibleName = resources.GetString("btnProcessor.AccessibleName");

        this.btnProcessor.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnProcessor.Anchor");

        this.btnProcessor.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnProcessor.BackgroundImage");

        this.btnProcessor.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnProcessor.Dock");

        this.btnProcessor.Enabled = (bool) resources.GetObject("btnProcessor.Enabled");

        this.btnProcessor.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnProcessor.FlatStyle");

        this.btnProcessor.Font = (System.Drawing.Font) resources.GetObject("btnProcessor.Font");

        this.btnProcessor.Image = (System.Drawing.Image) resources.GetObject("btnProcessor.Image");

        this.btnProcessor.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnProcessor.ImageAlign");

        this.btnProcessor.ImageIndex = (int) resources.GetObject("btnProcessor.ImageIndex");

        this.btnProcessor.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnProcessor.ImeMode");

        this.btnProcessor.Location = (System.Drawing.Point) resources.GetObject("btnProcessor.Location");

        this.btnProcessor.Name = "btnProcessor";

        this.btnProcessor.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnProcessor.RightToLeft");

        this.btnProcessor.Size = (System.Drawing.Size) resources.GetObject("btnProcessor.Size");

        this.btnProcessor.TabIndex = (int) resources.GetObject("btnProcessor.TabIndex");

        this.btnProcessor.Text = resources.GetString("btnProcessor.Text");

        this.btnProcessor.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnProcessor.TextAlign");

        this.btnProcessor.Visible = (bool) resources.GetObject("btnProcessor.Visible");

        //

        //btnComputerSystem

        //

        this.btnComputerSystem.AccessibleDescription = resources.GetString("btnComputerSystem.AccessibleDescription");

        this.btnComputerSystem.AccessibleName = resources.GetString("btnComputerSystem.AccessibleName");

        this.btnComputerSystem.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnComputerSystem.Anchor");

        this.btnComputerSystem.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnComputerSystem.BackgroundImage");

        this.btnComputerSystem.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnComputerSystem.Dock");

        this.btnComputerSystem.Enabled = (bool) resources.GetObject("btnComputerSystem.Enabled");

        this.btnComputerSystem.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnComputerSystem.FlatStyle");

        this.btnComputerSystem.Font = (System.Drawing.Font) resources.GetObject("btnComputerSystem.Font");

        this.btnComputerSystem.Image = (System.Drawing.Image) resources.GetObject("btnComputerSystem.Image");

        this.btnComputerSystem.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnComputerSystem.ImageAlign");

        this.btnComputerSystem.ImageIndex = (int) resources.GetObject("btnComputerSystem.ImageIndex");

        this.btnComputerSystem.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnComputerSystem.ImeMode");

        this.btnComputerSystem.Location = (System.Drawing.Point) resources.GetObject("btnComputerSystem.Location");

        this.btnComputerSystem.Name = "btnComputerSystem";

        this.btnComputerSystem.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnComputerSystem.RightToLeft");

        this.btnComputerSystem.Size = (System.Drawing.Size) resources.GetObject("btnComputerSystem.Size");

        this.btnComputerSystem.TabIndex = (int) resources.GetObject("btnComputerSystem.TabIndex");

        this.btnComputerSystem.Text = resources.GetString("btnComputerSystem.Text");

        this.btnComputerSystem.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnComputerSystem.TextAlign");

        this.btnComputerSystem.Visible = (bool) resources.GetObject("btnComputerSystem.Visible");

        //

        //btnOperatingSytem

        //

        this.btnOperatingSytem.AccessibleDescription = resources.GetString("btnOperatingSytem.AccessibleDescription");

        this.btnOperatingSytem.AccessibleName = resources.GetString("btnOperatingSytem.AccessibleName");

        this.btnOperatingSytem.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnOperatingSytem.Anchor");

        this.btnOperatingSytem.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnOperatingSytem.BackgroundImage");

        this.btnOperatingSytem.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnOperatingSytem.Dock");

        this.btnOperatingSytem.Enabled = (bool) resources.GetObject("btnOperatingSytem.Enabled");

        this.btnOperatingSytem.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnOperatingSytem.FlatStyle");

        this.btnOperatingSytem.Font = (System.Drawing.Font) resources.GetObject("btnOperatingSytem.Font");

        this.btnOperatingSytem.Image = (System.Drawing.Image) resources.GetObject("btnOperatingSytem.Image");

        this.btnOperatingSytem.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnOperatingSytem.ImageAlign");

        this.btnOperatingSytem.ImageIndex = (int) resources.GetObject("btnOperatingSytem.ImageIndex");

        this.btnOperatingSytem.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnOperatingSytem.ImeMode");

        this.btnOperatingSytem.Location = (System.Drawing.Point) resources.GetObject("btnOperatingSytem.Location");

        this.btnOperatingSytem.Name = "btnOperatingSytem";

        this.btnOperatingSytem.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnOperatingSytem.RightToLeft");

        this.btnOperatingSytem.Size = (System.Drawing.Size) resources.GetObject("btnOperatingSytem.Size");

        this.btnOperatingSytem.TabIndex = (int) resources.GetObject("btnOperatingSytem.TabIndex");

        this.btnOperatingSytem.Text = resources.GetString("btnOperatingSytem.Text");

        this.btnOperatingSytem.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnOperatingSytem.TextAlign");

        this.btnOperatingSytem.Visible = (bool) resources.GetObject("btnOperatingSytem.Visible");

        //

        //txtOutput

        //

        this.txtOutput.AccessibleDescription = resources.GetString("txtOutput.AccessibleDescription");

        this.txtOutput.AccessibleName = resources.GetString("txtOutput.AccessibleName");

        this.txtOutput.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtOutput.Anchor");

        this.txtOutput.AutoSize = (bool) resources.GetObject("txtOutput.AutoSize");

        this.txtOutput.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtOutput.BackgroundImage");

        this.txtOutput.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtOutput.Dock");

        this.txtOutput.Enabled = (bool) resources.GetObject("txtOutput.Enabled");

        this.txtOutput.Font = (System.Drawing.Font) resources.GetObject("txtOutput.Font");

        this.txtOutput.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtOutput.ImeMode");

        this.txtOutput.Location = (System.Drawing.Point) resources.GetObject("txtOutput.Location");

        this.txtOutput.MaxLength = (int) resources.GetObject("txtOutput.MaxLength");

        this.txtOutput.Multiline = (bool) resources.GetObject("txtOutput.Multiline");

        this.txtOutput.Name = "txtOutput";

        this.txtOutput.PasswordChar = (char) resources.GetObject("txtOutput.PasswordChar");

        this.txtOutput.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtOutput.RightToLeft");

        this.txtOutput.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtOutput.ScrollBars");

        this.txtOutput.Size = (System.Drawing.Size) resources.GetObject("txtOutput.Size");

        this.txtOutput.TabIndex = (int) resources.GetObject("txtOutput.TabIndex");

        this.txtOutput.Text = resources.GetString("txtOutput.Text");

        this.txtOutput.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtOutput.TextAlign");

        this.txtOutput.Visible = (bool) resources.GetObject("txtOutput.Visible");

        this.txtOutput.WordWrap = (bool) resources.GetObject("txtOutput.WordWrap");

        //

        //tpAsynchEnum

        //

        this.tpAsynchEnum.AccessibleDescription = resources.GetString("tpAsynchEnum.AccessibleDescription");

        this.tpAsynchEnum.AccessibleName = resources.GetString("tpAsynchEnum.AccessibleName");

        this.tpAsynchEnum.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpAsynchEnum.Anchor");

        this.tpAsynchEnum.AutoScroll = (bool) resources.GetObject("tpAsynchEnum.AutoScroll");

        this.tpAsynchEnum.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpAsynchEnum.AutoScrollMargin");

        this.tpAsynchEnum.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpAsynchEnum.AutoScrollMinSize");

        this.tpAsynchEnum.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpAsynchEnum.BackgroundImage");

        this.tpAsynchEnum.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblInstructions2, this.btnStartEnum, this.lvDriveList});

        this.tpAsynchEnum.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpAsynchEnum.Dock");

        this.tpAsynchEnum.Enabled = (bool) resources.GetObject("tpAsynchEnum.Enabled");

        this.tpAsynchEnum.Font = (System.Drawing.Font) resources.GetObject("tpAsynchEnum.Font");

        this.tpAsynchEnum.ImageIndex = (int) resources.GetObject("tpAsynchEnum.ImageIndex");

        this.tpAsynchEnum.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpAsynchEnum.ImeMode");

        this.tpAsynchEnum.Location = (System.Drawing.Point) resources.GetObject("tpAsynchEnum.Location");

        this.tpAsynchEnum.Name = "tpAsynchEnum";

        this.tpAsynchEnum.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpAsynchEnum.RightToLeft");

        this.tpAsynchEnum.Size = (System.Drawing.Size) resources.GetObject("tpAsynchEnum.Size");

        this.tpAsynchEnum.TabIndex = (int) resources.GetObject("tpAsynchEnum.TabIndex");

        this.tpAsynchEnum.Text = resources.GetString("tpAsynchEnum.Text");

        this.tpAsynchEnum.ToolTipText = resources.GetString("tpAsynchEnum.ToolTipText");

        this.tpAsynchEnum.Visible = (bool) resources.GetObject("tpAsynchEnum.Visible");

        //

        //lblInstructions2

        //

        this.lblInstructions2.AccessibleDescription = (string) resources.GetObject("lblInstructions2.AccessibleDescription");

        this.lblInstructions2.AccessibleName = (string) resources.GetObject("lblInstructions2.AccessibleName");

        this.lblInstructions2.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblInstructions2.Anchor");

        this.lblInstructions2.AutoSize = (bool) resources.GetObject("lblInstructions2.AutoSize");

        this.lblInstructions2.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblInstructions2.Dock");

        this.lblInstructions2.Enabled = (bool) resources.GetObject("lblInstructions2.Enabled");

        this.lblInstructions2.Font = (System.Drawing.Font) resources.GetObject("lblInstructions2.Font");

        this.lblInstructions2.ForeColor = System.Drawing.Color.Blue;

        this.lblInstructions2.Image = (System.Drawing.Image) resources.GetObject("lblInstructions2.Image");

        this.lblInstructions2.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblInstructions2.ImageAlign");

        this.lblInstructions2.ImageIndex = (int) resources.GetObject("lblInstructions2.ImageIndex");

        this.lblInstructions2.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblInstructions2.ImeMode");

        this.lblInstructions2.Location = (System.Drawing.Point) resources.GetObject("lblInstructions2.Location");

        this.lblInstructions2.Name = "lblInstructions2";

        this.lblInstructions2.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblInstructions2.RightToLeft");

        this.lblInstructions2.Size = (System.Drawing.Size) resources.GetObject("lblInstructions2.Size");

        this.lblInstructions2.TabIndex = (int) resources.GetObject("lblInstructions2.TabIndex");

        this.lblInstructions2.Text = resources.GetString("lblInstructions2.Text");

        this.lblInstructions2.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblInstructions2.TextAlign");

        this.lblInstructions2.Visible = (bool) resources.GetObject("lblInstructions2.Visible");

        //

        //btnStartEnum

        //

        this.btnStartEnum.AccessibleDescription = resources.GetString("btnStartEnum.AccessibleDescription");

        this.btnStartEnum.AccessibleName = resources.GetString("btnStartEnum.AccessibleName");

        this.btnStartEnum.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnStartEnum.Anchor");

        this.btnStartEnum.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnStartEnum.BackgroundImage");

        this.btnStartEnum.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnStartEnum.Dock");

        this.btnStartEnum.Enabled = (bool) resources.GetObject("btnStartEnum.Enabled");

        this.btnStartEnum.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnStartEnum.FlatStyle");

        this.btnStartEnum.Font = (System.Drawing.Font) resources.GetObject("btnStartEnum.Font");

        this.btnStartEnum.Image = (System.Drawing.Image) resources.GetObject("btnStartEnum.Image");

        this.btnStartEnum.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStartEnum.ImageAlign");

        this.btnStartEnum.ImageIndex = (int) resources.GetObject("btnStartEnum.ImageIndex");

        this.btnStartEnum.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnStartEnum.ImeMode");

        this.btnStartEnum.Location = (System.Drawing.Point) resources.GetObject("btnStartEnum.Location");

        this.btnStartEnum.Name = "btnStartEnum";

        this.btnStartEnum.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnStartEnum.RightToLeft");

        this.btnStartEnum.Size = (System.Drawing.Size) resources.GetObject("btnStartEnum.Size");

        this.btnStartEnum.TabIndex = (int) resources.GetObject("btnStartEnum.TabIndex");

        this.btnStartEnum.Text = resources.GetString("btnStartEnum.Text");

        this.btnStartEnum.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStartEnum.TextAlign");

        this.btnStartEnum.Visible = (bool) resources.GetObject("btnStartEnum.Visible");

        //

        //lvDriveList

        //

        this.lvDriveList.AccessibleDescription = resources.GetString("lvDriveList.AccessibleDescription");

        this.lvDriveList.AccessibleName = resources.GetString("lvDriveList.AccessibleName");

        this.lvDriveList.Alignment = (System.Windows.Forms.ListViewAlignment) resources.GetObject("lvDriveList.Alignment");

        this.lvDriveList.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lvDriveList.Anchor");

        this.lvDriveList.BackgroundImage = (System.Drawing.Image) resources.GetObject("lvDriveList.BackgroundImage");

        this.lvDriveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.DriveName, this.DriveLabel, this.DriveSize, this.DriveFreeSpace});

        this.lvDriveList.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lvDriveList.Dock");

        this.lvDriveList.Enabled = (bool) resources.GetObject("lvDriveList.Enabled");

        this.lvDriveList.Font = (System.Drawing.Font) resources.GetObject("lvDriveList.Font");

        this.lvDriveList.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lvDriveList.ImeMode");

        this.lvDriveList.LabelWrap = (bool) resources.GetObject("lvDriveList.LabelWrap");

        this.lvDriveList.Location = (System.Drawing.Point) resources.GetObject("lvDriveList.Location");

        this.lvDriveList.Name = "lvDriveList";

        this.lvDriveList.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lvDriveList.RightToLeft");

        this.lvDriveList.Size = (System.Drawing.Size) resources.GetObject("lvDriveList.Size");

        this.lvDriveList.TabIndex = (int) resources.GetObject("lvDriveList.TabIndex");

        this.lvDriveList.Text = resources.GetString("lvDriveList.Text");

        this.lvDriveList.View = System.Windows.Forms.View.Details;

        this.lvDriveList.Visible = (bool) resources.GetObject("lvDriveList.Visible");

        //

        //DriveName

        //

        this.DriveName.Text = resources.GetString("DriveName.Text");

        this.DriveName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("DriveName.TextAlign");

        this.DriveName.Width = (int) resources.GetObject("DriveName.Width");

        //

        //DriveLabel

        //

        this.DriveLabel.Text = resources.GetString("DriveLabel.Text");

        this.DriveLabel.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("DriveLabel.TextAlign");

        this.DriveLabel.Width = (int) resources.GetObject("DriveLabel.Width");

        //

        //DriveSize

        //

        this.DriveSize.Text = resources.GetString("DriveSize.Text");

        this.DriveSize.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("DriveSize.TextAlign");

        this.DriveSize.Width = (int) resources.GetObject("DriveSize.Width");

        //

        //DriveFreeSpace

        //

        this.DriveFreeSpace.Text = resources.GetString("DriveFreeSpace.Text");

        this.DriveFreeSpace.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("DriveFreeSpace.TextAlign");

        this.DriveFreeSpace.Width = (int) resources.GetObject("DriveFreeSpace.Width");

        //

        //tpWMIClasses

        //

        this.tpWMIClasses.AccessibleDescription = (string) resources.GetObject("tpWMIClasses.AccessibleDescription");

        this.tpWMIClasses.AccessibleName = (string) resources.GetObject("tpWMIClasses.AccessibleName");

        this.tpWMIClasses.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpWMIClasses.Anchor");

        this.tpWMIClasses.AutoScroll = (bool) resources.GetObject("tpWMIClasses.AutoScroll");

        this.tpWMIClasses.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpWMIClasses.AutoScrollMargin");

        this.tpWMIClasses.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpWMIClasses.AutoScrollMinSize");

        this.tpWMIClasses.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpWMIClasses.BackgroundImage");

        this.tpWMIClasses.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkIncludeSubclasses, this.Label1, this.btnClassEnum, this.lstWMIClasses});

        this.tpWMIClasses.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpWMIClasses.Dock");

        this.tpWMIClasses.Enabled = (bool) resources.GetObject("tpWMIClasses.Enabled");

        this.tpWMIClasses.Font = (System.Drawing.Font) resources.GetObject("tpWMIClasses.Font");

        this.tpWMIClasses.ImageIndex = (int) resources.GetObject("tpWMIClasses.ImageIndex");

        this.tpWMIClasses.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpWMIClasses.ImeMode");

        this.tpWMIClasses.Location = (System.Drawing.Point) resources.GetObject("tpWMIClasses.Location");

        this.tpWMIClasses.Name = "tpWMIClasses";

        this.tpWMIClasses.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpWMIClasses.RightToLeft");

        this.tpWMIClasses.Size = (System.Drawing.Size) resources.GetObject("tpWMIClasses.Size");

        this.tpWMIClasses.TabIndex = (int) resources.GetObject("tpWMIClasses.TabIndex");

        this.tpWMIClasses.Text = resources.GetString("tpWMIClasses.Text");

        this.tpWMIClasses.ToolTipText = resources.GetString("tpWMIClasses.ToolTipText");

        this.tpWMIClasses.Visible = (bool) resources.GetObject("tpWMIClasses.Visible");

        //

        //chkIncludeSubclasses

        //

        this.chkIncludeSubclasses.AccessibleDescription = resources.GetString("chkIncludeSubclasses.AccessibleDescription");

        this.chkIncludeSubclasses.AccessibleName = resources.GetString("chkIncludeSubclasses.AccessibleName");

        this.chkIncludeSubclasses.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkIncludeSubclasses.Anchor");

        this.chkIncludeSubclasses.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkIncludeSubclasses.Appearance");

        this.chkIncludeSubclasses.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkIncludeSubclasses.BackgroundImage");

        this.chkIncludeSubclasses.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIncludeSubclasses.CheckAlign");

        this.chkIncludeSubclasses.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkIncludeSubclasses.Dock");

        this.chkIncludeSubclasses.Enabled = (bool) resources.GetObject("chkIncludeSubclasses.Enabled");

        this.chkIncludeSubclasses.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkIncludeSubclasses.FlatStyle");

        this.chkIncludeSubclasses.Font = (System.Drawing.Font) resources.GetObject("chkIncludeSubclasses.Font");

        this.chkIncludeSubclasses.Image = (System.Drawing.Image) resources.GetObject("chkIncludeSubclasses.Image");

        this.chkIncludeSubclasses.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIncludeSubclasses.ImageAlign");

        this.chkIncludeSubclasses.ImageIndex = (int) resources.GetObject("chkIncludeSubclasses.ImageIndex");

        this.chkIncludeSubclasses.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkIncludeSubclasses.ImeMode");

        this.chkIncludeSubclasses.Location = (System.Drawing.Point) resources.GetObject("chkIncludeSubclasses.Location");

        this.chkIncludeSubclasses.Name = "chkIncludeSubclasses";

        this.chkIncludeSubclasses.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkIncludeSubclasses.RightToLeft");

        this.chkIncludeSubclasses.Size = (System.Drawing.Size) resources.GetObject("chkIncludeSubclasses.Size");

        this.chkIncludeSubclasses.TabIndex = (int) resources.GetObject("chkIncludeSubclasses.TabIndex");

        this.chkIncludeSubclasses.Text = resources.GetString("chkIncludeSubclasses.Text");

        this.chkIncludeSubclasses.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkIncludeSubclasses.TextAlign");

        this.chkIncludeSubclasses.Visible = (bool) resources.GetObject("chkIncludeSubclasses.Visible");

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

        this.Label1.ForeColor = System.Drawing.Color.Blue;

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

        //btnClassEnum

        //

        this.btnClassEnum.AccessibleDescription = resources.GetString("btnClassEnum.AccessibleDescription");

        this.btnClassEnum.AccessibleName = resources.GetString("btnClassEnum.AccessibleName");

        this.btnClassEnum.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnClassEnum.Anchor");

        this.btnClassEnum.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnClassEnum.BackgroundImage");

        this.btnClassEnum.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnClassEnum.Dock");

        this.btnClassEnum.Enabled = (bool) resources.GetObject("btnClassEnum.Enabled");

        this.btnClassEnum.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnClassEnum.FlatStyle");

        this.btnClassEnum.Font = (System.Drawing.Font) resources.GetObject("btnClassEnum.Font");

        this.btnClassEnum.Image = (System.Drawing.Image) resources.GetObject("btnClassEnum.Image");

        this.btnClassEnum.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnClassEnum.ImageAlign");

        this.btnClassEnum.ImageIndex = (int) resources.GetObject("btnClassEnum.ImageIndex");

        this.btnClassEnum.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnClassEnum.ImeMode");

        this.btnClassEnum.Location = (System.Drawing.Point) resources.GetObject("btnClassEnum.Location");

        this.btnClassEnum.Name = "btnClassEnum";

        this.btnClassEnum.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnClassEnum.RightToLeft");

        this.btnClassEnum.Size = (System.Drawing.Size) resources.GetObject("btnClassEnum.Size");

        this.btnClassEnum.TabIndex = (int) resources.GetObject("btnClassEnum.TabIndex");

        this.btnClassEnum.Text = resources.GetString("btnClassEnum.Text");

        this.btnClassEnum.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnClassEnum.TextAlign");

        this.btnClassEnum.Visible = (bool) resources.GetObject("btnClassEnum.Visible");

        //

        //lstWMIClasses

        //

        this.lstWMIClasses.AccessibleDescription = (string) resources.GetObject("lstWMIClasses.AccessibleDescription");

        this.lstWMIClasses.AccessibleName = (string) resources.GetObject("lstWMIClasses.AccessibleName");

        this.lstWMIClasses.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lstWMIClasses.Anchor");

        this.lstWMIClasses.BackgroundImage = (System.Drawing.Image) resources.GetObject("lstWMIClasses.BackgroundImage");

        this.lstWMIClasses.ColumnWidth = (int) resources.GetObject("lstWMIClasses.ColumnWidth");

        this.lstWMIClasses.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lstWMIClasses.Dock");

        this.lstWMIClasses.Enabled = (bool) resources.GetObject("lstWMIClasses.Enabled");

        this.lstWMIClasses.Font = (System.Drawing.Font) resources.GetObject("lstWMIClasses.Font");

        this.lstWMIClasses.HorizontalExtent = (int) resources.GetObject("lstWMIClasses.HorizontalExtent");

        this.lstWMIClasses.HorizontalScrollbar = (bool) resources.GetObject("lstWMIClasses.HorizontalScrollbar");

        this.lstWMIClasses.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lstWMIClasses.ImeMode");

        this.lstWMIClasses.IntegralHeight = (bool) resources.GetObject("lstWMIClasses.IntegralHeight");

        this.lstWMIClasses.ItemHeight = (int) resources.GetObject("lstWMIClasses.ItemHeight");

        this.lstWMIClasses.Location = (System.Drawing.Point) resources.GetObject("lstWMIClasses.Location");

        this.lstWMIClasses.Name = "lstWMIClasses";

        this.lstWMIClasses.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lstWMIClasses.RightToLeft");

        this.lstWMIClasses.ScrollAlwaysVisible = (bool) resources.GetObject("lstWMIClasses.ScrollAlwaysVisible");

        this.lstWMIClasses.Size = (System.Drawing.Size) resources.GetObject("lstWMIClasses.Size");

        this.lstWMIClasses.TabIndex = (int) resources.GetObject("lstWMIClasses.TabIndex");

        this.lstWMIClasses.Visible = (bool) resources.GetObject("lstWMIClasses.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.MainTabControl});

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

        this.MainTabControl.ResumeLayout(false);

        this.tpWMIQueries.ResumeLayout(false);

        this.tpAsynchEnum.ResumeLayout(false);

        this.tpWMIClasses.ResumeLayout(false);

        this.ResumeLayout(false);
		
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.btnBios.Click +=new EventHandler(btnBios_Click);
		this.btnComputerSystem.Click +=new EventHandler(btnComputerSystem_Click);
		this.btnClassEnum.Click +=new EventHandler(btnClassEnum_Click);
		this.btnOperatingSytem.Click +=new EventHandler(btnOperatingSytem_Click);
		this.btnProcessor.Click +=new EventHandler(btnProcessor_Click);
		this.btnStartEnum.Click +=new EventHandler(btnStartEnum_Click);
		this.btnTimeZone.Click +=new EventHandler(btnTimeZone_Click);
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

    // This subroutine fills in the output text box with bios information from WMI

    private void btnBios_Click(object sender, System.EventArgs e) 
	{
        // This is to show how to use the SelectQuery object in the place of a SELECT 
        // statement.

        SelectQuery query = new SelectQuery("Win32_bios");

        //ManagementObjectSearcher retrieves a collection of WMI objects based on 
        // the query.

        ManagementObjectSearcher search = new ManagementObjectSearcher(query);

        // Display each entry for Win32_bios

        foreach(ManagementObject info in search.Get())
		{
            txtOutput.Text = "Bios version: " + info["version"].ToString() + CRLF;
        }

    }

    // This subroutine fills in the output text box with computer system information
    // from WMI

    private void btnComputerSystem_Click(object sender, System.EventArgs e) 
	{
        // ManagementObjectSearcher retrieves a collection of WMI objects based on 
        // the query.  In this case a string is used instead of a SelectQuery object.

        ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");

        // Display each entry for Win32_ComputerSystem

        foreach(ManagementObject info in search.Get())
			{
            txtOutput.Text = "Manufacturer: " + info["manufacturer"].ToString() + CRLF;
            txtOutput.Text += "Model: " + info["model"].ToString() + CRLF;
            txtOutput.Text += "System Type: " + info["systemtype"].ToString() + CRLF;
            txtOutput.Text += "Total Physical Memory: " + 
                info["totalphysicalmemory"].ToString() + CRLF;
        }
    }

    // This subroutine fills a list box with all WMI classes. 

    private void btnClassEnum_Click(object sender, System.EventArgs e) 
	{
        // Clear out the list box

        lstWMIClasses.Items.Clear();

        // Default constructor for Managementclass will return cim root.  

        ManagementClass root = new ManagementClass();

        // if voidclasses checkbox check we will get all subclasses well the top
        // level classes.

        EnumerationOptions options = new EnumerationOptions();
        options.EnumerateDeep = chkIncludeSubclasses.Checked;

        // Add each WMI class in the enumeration to the list box.

        foreach(ManagementObject info in root.GetSubclasses(options))
		{
            lstWMIClasses.Items.Add(info["__Class"]);
        }

    }

    // This subroutine fills in the output text box with Operating System information
    // from WMI

    private void btnOperatingSytem_Click(object sender, System.EventArgs e) 
		{
        // ManagementObjectSearcher retrieves a collection of WMI objects based on 
        // the query.  In this case a string is used instead of a SelectQuery object.

        ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

        // Display each entry for Win32_OperatingSystem

        foreach(ManagementObject info in search.Get())
		{
            txtOutput.Text = "Name: " + info["name"].ToString() + CRLF;
            txtOutput.Text += "Version: " + info["version"].ToString() + CRLF;
            txtOutput.Text += "Manufacturer: " + info["manufacturer"].ToString() + CRLF;
            txtOutput.Text += "Computer name: " + info["csname"].ToString() + CRLF;
            txtOutput.Text += "Windows Directory: " + 
                info["windowsdirectory"].ToString() + CRLF;
        }

    }

    // This subroutine fills in the output text box with Processor information
    // from WMI

    private void btnProcessor_Click(object sender, System.EventArgs e) 
	{
        // This is to show how to use the SelectQuery object in the place of a SELECT 
        // statement.

        SelectQuery query = new SelectQuery("Win32_processor");

        //ManagementObjectSearcher retrieves a collection of WMI objects based on 
        // the query.

        ManagementObjectSearcher search = new ManagementObjectSearcher(query);

        // Display each entry for Win32_processor

		foreach(ManagementObject info in search.Get())
		{

			txtOutput.Text = "Processor: " + info["caption"].ToString() + CRLF;

		}

    }

    // This subroutine starts an asynchronous operation to fill the DriveList list view
    // with all logical drives.

    private void btnStartEnum_Click(object sender, System.EventArgs e) 
	{
        // Clear out the list view

        lvDriveList.Items.Clear();

        // Get the WMI object for Win32_Logical_Disk

        ManagementClass disks = new ManagementClass("Win32_LogicalDisk");

        // ManagementOperationObserver handles the the collection asynchronously
        // by use of a callback.

        ManagementOperationObserver observer = new ManagementOperationObserver();

        // Add an event handler for the observer to call for each logical drive.

		observer.ObjectReady +=new ObjectReadyEventHandler(OnEnumObjectReady);

        // Returns the collection of all Logical drives, asynchronously.

        disks.GetInstances(observer);

    }

    // This subroutine fills in the output text box with Time zone information from WMI

    private void btnTimeZone_Click(object sender, System.EventArgs e) 
	{
        // This is to show how to use the SelectQuery object in the place of a SELECT 
        // statement.

        SelectQuery query = new SelectQuery("Win32_timezone");

        //ManagementObjectSearcher retrieves a collection of WMI objects based on 
        // the query.

        ManagementObjectSearcher search = new ManagementObjectSearcher(query);

        // Display each entry for Win32_timezone

        foreach(ManagementObject info in search.Get())
		{

            txtOutput.Text = "Time zone: " + info["caption"].ToString() + CRLF;

        }

    }

    // This is the callback subroutine that the WMI class ManagementOperationObserver
    // calls in btnStartEnum_Click.

    void OnEnumObjectReady(object sender, ObjectReadyEventArgs e)
	{

        // Create a new item to add to DriveList ListView, add drive letter
        ListViewItem item = new ListViewItem(e.NewObject["Name"].ToString(), 0);

        // if VolumeName is null (A: without disk, Cd-ROM empty, etc.) then only
        // list the drive letter

        if (e.NewObject["VolumeName"] != null) {
            item.SubItems.Add(e.NewObject["VolumeName"].ToString());
            item.SubItems.Add(e.NewObject["Size"].ToString() + " bytes");
            // if 0 bytes display (none)

			if (e.NewObject["FreeSpace"].ToString() != "0") 
			{
				item.SubItems.Add(e.NewObject["FreeSpace"].ToString() + " bytes");
			}
			else 
			{
				item.SubItems.Add("(none)");
			}

        }

        // Add the item

        lvDriveList.Items.Add(item);

    }

}

