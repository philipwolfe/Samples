//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;

public class frmMain : System.Windows.Forms.Form
{
    const int STRING_BUFFER_LENGTH = 255;

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

    private System.Windows.Forms.ListView lvwProcessList;

    private System.Windows.Forms.ColumnHeader WindowsTitle;

    private System.Windows.Forms.ColumnHeader ClassName;

    private System.Windows.Forms.ColumnHeader WindowsHandle;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.TabControl MainTabControl;

    private System.Windows.Forms.TabPage tpActiveProcesses;

    private System.Windows.Forms.TabPage tpActiveWindows;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Button btnRefreshActiveWindows;

    private System.Windows.Forms.ListBox lbActiveWindows;

    private System.Windows.Forms.TabPage tpShowWindow;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.Button btnShow;

    private System.Windows.Forms.TextBox txtWindowCaption;

    private System.Windows.Forms.TextBox txtClassName;

    private System.Windows.Forms.Label lblFunctionCalled;

    private System.Windows.Forms.Button btnRefreshActiveProcesses;

    private System.Windows.Forms.TabPage tpAPICalls;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.Button btnGetFreeSpace;

    private System.Windows.Forms.TextBox txtDriveLetter;

    private System.Windows.Forms.TextBox txtFunctionOutput;

    private System.Windows.Forms.Button btnGetDiskFreeSpaceEx;

    private System.Windows.Forms.Button btnGetDriveType;

    private System.Windows.Forms.GroupBox DriveGroupBox;

    private System.Windows.Forms.Button btnCreateDirectory;

    private System.Windows.Forms.TextBox txtDirectory;

    private System.Windows.Forms.GroupBox DirectoryGroupBox;

    private System.Windows.Forms.GroupBox MiscGroupBox;

    private System.Windows.Forms.Button btnGetOSVersion;

    private System.Windows.Forms.Label Label9;

    private System.Windows.Forms.Button btnHibernate;

    private System.Windows.Forms.Button btnBeep;

    private System.Windows.Forms.RadioButton rbAuto;

    private System.Windows.Forms.RadioButton rbANSI;

    private System.Windows.Forms.RadioButton rbUnicode;

    private System.Windows.Forms.RadioButton rbDLLImport;

    private System.Windows.Forms.RadioButton rbDeclare;

    private System.Windows.Forms.GroupBox MouseGroupBox;

    private System.Windows.Forms.Button btnResetMouseButton;

    private System.Windows.Forms.Button btnSwapMouseButton;

    private System.Windows.Forms.GroupBox CallingVariationGroupBox;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.MainTabControl = new System.Windows.Forms.TabControl();

        this.tpActiveProcesses = new System.Windows.Forms.TabPage();

        this.Label2 = new System.Windows.Forms.Label();

        this.btnRefreshActiveProcesses = new System.Windows.Forms.Button();

        this.lvwProcessList = new System.Windows.Forms.ListView();

        this.WindowsTitle = new System.Windows.Forms.ColumnHeader();

        this.ClassName = new System.Windows.Forms.ColumnHeader();

        this.WindowsHandle = new System.Windows.Forms.ColumnHeader();

        this.tpActiveWindows = new System.Windows.Forms.TabPage();

        this.btnRefreshActiveWindows = new System.Windows.Forms.Button();

        this.Label1 = new System.Windows.Forms.Label();

        this.lbActiveWindows = new System.Windows.Forms.ListBox();

        this.tpShowWindow = new System.Windows.Forms.TabPage();

        this.lblFunctionCalled = new System.Windows.Forms.Label();

        this.btnShow = new System.Windows.Forms.Button();

        this.Label6 = new System.Windows.Forms.Label();

        this.txtClassName = new System.Windows.Forms.TextBox();

        this.txtWindowCaption = new System.Windows.Forms.TextBox();

        this.Label5 = new System.Windows.Forms.Label();

        this.Label4 = new System.Windows.Forms.Label();

        this.Label3 = new System.Windows.Forms.Label();

        this.tpAPICalls = new System.Windows.Forms.TabPage();

        this.CallingVariationGroupBox = new System.Windows.Forms.GroupBox();

        this.btnBeep = new System.Windows.Forms.Button();

        this.rbAuto = new System.Windows.Forms.RadioButton();

        this.rbANSI = new System.Windows.Forms.RadioButton();

        this.rbUnicode = new System.Windows.Forms.RadioButton();

        this.rbDLLImport = new System.Windows.Forms.RadioButton();

        this.rbDeclare = new System.Windows.Forms.RadioButton();

        this.Label9 = new System.Windows.Forms.Label();

        this.DirectoryGroupBox = new System.Windows.Forms.GroupBox();

        this.txtDirectory = new System.Windows.Forms.TextBox();

        this.btnCreateDirectory = new System.Windows.Forms.Button();

        this.MouseGroupBox = new System.Windows.Forms.GroupBox();

        this.btnResetMouseButton = new System.Windows.Forms.Button();

        this.btnSwapMouseButton = new System.Windows.Forms.Button();

        this.DriveGroupBox = new System.Windows.Forms.GroupBox();

        this.Label8 = new System.Windows.Forms.Label();

        this.txtDriveLetter = new System.Windows.Forms.TextBox();

        this.btnGetDriveType = new System.Windows.Forms.Button();

        this.btnGetDiskFreeSpaceEx = new System.Windows.Forms.Button();

        this.btnGetFreeSpace = new System.Windows.Forms.Button();

        this.txtFunctionOutput = new System.Windows.Forms.TextBox();

        this.MiscGroupBox = new System.Windows.Forms.GroupBox();

        this.btnHibernate = new System.Windows.Forms.Button();

        this.btnGetOSVersion = new System.Windows.Forms.Button();

        this.MainTabControl.SuspendLayout();

        this.tpActiveProcesses.SuspendLayout();

        this.tpActiveWindows.SuspendLayout();

        this.tpShowWindow.SuspendLayout();

        this.tpAPICalls.SuspendLayout();

        this.CallingVariationGroupBox.SuspendLayout();

        this.DirectoryGroupBox.SuspendLayout();

        this.MouseGroupBox.SuspendLayout();

        this.DriveGroupBox.SuspendLayout();

        this.MiscGroupBox.SuspendLayout();

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

        //MainTabControl

        //

        this.MainTabControl.AccessibleDescription = resources.GetString("MainTabControl.AccessibleDescription");

        this.MainTabControl.AccessibleName = resources.GetString("MainTabControl.AccessibleName");

        this.MainTabControl.Alignment = (System.Windows.Forms.TabAlignment) resources.GetObject("MainTabControl.Alignment");

        this.MainTabControl.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("MainTabControl.Anchor");

        this.MainTabControl.Appearance = (System.Windows.Forms.TabAppearance) resources.GetObject("MainTabControl.Appearance");

        this.MainTabControl.BackgroundImage = (System.Drawing.Image) resources.GetObject("MainTabControl.BackgroundImage");

        this.MainTabControl.Controls.AddRange(new System.Windows.Forms.Control[] {this.tpActiveProcesses, this.tpActiveWindows, this.tpShowWindow, this.tpAPICalls});

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

        //tpActiveProcesses

        //

        this.tpActiveProcesses.AccessibleDescription = resources.GetString("tpActiveProcesses.AccessibleDescription");

        this.tpActiveProcesses.AccessibleName = resources.GetString("tpActiveProcesses.AccessibleName");

        this.tpActiveProcesses.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpActiveProcesses.Anchor");

        this.tpActiveProcesses.AutoScroll = (bool) resources.GetObject("tpActiveProcesses.AutoScroll");

        this.tpActiveProcesses.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpActiveProcesses.AutoScrollMargin");

        this.tpActiveProcesses.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpActiveProcesses.AutoScrollMinSize");

        this.tpActiveProcesses.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpActiveProcesses.BackgroundImage");

        this.tpActiveProcesses.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2, this.btnRefreshActiveProcesses, this.lvwProcessList});

        this.tpActiveProcesses.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpActiveProcesses.Dock");

        this.tpActiveProcesses.Enabled = (bool) resources.GetObject("tpActiveProcesses.Enabled");

        this.tpActiveProcesses.Font = (System.Drawing.Font) resources.GetObject("tpActiveProcesses.Font");

        this.tpActiveProcesses.ImageIndex = (int) resources.GetObject("tpActiveProcesses.ImageIndex");

        this.tpActiveProcesses.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpActiveProcesses.ImeMode");

        this.tpActiveProcesses.Location = (System.Drawing.Point) resources.GetObject("tpActiveProcesses.Location");

        this.tpActiveProcesses.Name = "tpActiveProcesses";

        this.tpActiveProcesses.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpActiveProcesses.RightToLeft");

        this.tpActiveProcesses.Size = (System.Drawing.Size) resources.GetObject("tpActiveProcesses.Size");

        this.tpActiveProcesses.TabIndex = (int) resources.GetObject("tpActiveProcesses.TabIndex");

        this.tpActiveProcesses.Text = resources.GetString("tpActiveProcesses.Text");

        this.tpActiveProcesses.ToolTipText = resources.GetString("tpActiveProcesses.ToolTipText");

        this.tpActiveProcesses.Visible = (bool) resources.GetObject("tpActiveProcesses.Visible");

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

        this.Label2.ForeColor = System.Drawing.Color.Black;

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

        //btnRefreshActiveProcesses

        //

        this.btnRefreshActiveProcesses.AccessibleDescription = resources.GetString("btnRefreshActiveProcesses.AccessibleDescription");

        this.btnRefreshActiveProcesses.AccessibleName = resources.GetString("btnRefreshActiveProcesses.AccessibleName");

        this.btnRefreshActiveProcesses.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRefreshActiveProcesses.Anchor");

        this.btnRefreshActiveProcesses.BackColor = System.Drawing.SystemColors.Control;

        this.btnRefreshActiveProcesses.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRefreshActiveProcesses.BackgroundImage");

        this.btnRefreshActiveProcesses.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRefreshActiveProcesses.Dock");

        this.btnRefreshActiveProcesses.Enabled = (bool) resources.GetObject("btnRefreshActiveProcesses.Enabled");

        this.btnRefreshActiveProcesses.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRefreshActiveProcesses.FlatStyle");

        this.btnRefreshActiveProcesses.Font = (System.Drawing.Font) resources.GetObject("btnRefreshActiveProcesses.Font");

        this.btnRefreshActiveProcesses.ForeColor = System.Drawing.SystemColors.WindowText;

        this.btnRefreshActiveProcesses.Image = (System.Drawing.Image) resources.GetObject("btnRefreshActiveProcesses.Image");

        this.btnRefreshActiveProcesses.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefreshActiveProcesses.ImageAlign");

        this.btnRefreshActiveProcesses.ImageIndex = (int) resources.GetObject("btnRefreshActiveProcesses.ImageIndex");

        this.btnRefreshActiveProcesses.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRefreshActiveProcesses.ImeMode");

        this.btnRefreshActiveProcesses.Location = (System.Drawing.Point) resources.GetObject("btnRefreshActiveProcesses.Location");

        this.btnRefreshActiveProcesses.Name = "btnRefreshActiveProcesses";

        this.btnRefreshActiveProcesses.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRefreshActiveProcesses.RightToLeft");

        this.btnRefreshActiveProcesses.Size = (System.Drawing.Size) resources.GetObject("btnRefreshActiveProcesses.Size");

        this.btnRefreshActiveProcesses.TabIndex = (int) resources.GetObject("btnRefreshActiveProcesses.TabIndex");

        this.btnRefreshActiveProcesses.Text = resources.GetString("btnRefreshActiveProcesses.Text");

        this.btnRefreshActiveProcesses.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefreshActiveProcesses.TextAlign");

        this.btnRefreshActiveProcesses.Visible = (bool) resources.GetObject("btnRefreshActiveProcesses.Visible");

		this.btnRefreshActiveProcesses.Click += new EventHandler(btnRefreshActiveProcesses_Click);

        //

        //lvwProcessList

        //

        this.lvwProcessList.AccessibleDescription = resources.GetString("lvwProcessList.AccessibleDescription");

        this.lvwProcessList.AccessibleName = resources.GetString("lvwProcessList.AccessibleName");

        this.lvwProcessList.Alignment = (System.Windows.Forms.ListViewAlignment) resources.GetObject("lvwProcessList.Alignment");

        this.lvwProcessList.AllowColumnReorder = true;

        this.lvwProcessList.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lvwProcessList.Anchor");

        this.lvwProcessList.BackgroundImage = (System.Drawing.Image) resources.GetObject("lvwProcessList.BackgroundImage");

        this.lvwProcessList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.WindowsTitle, this.ClassName, this.WindowsHandle});

        this.lvwProcessList.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lvwProcessList.Dock");

        this.lvwProcessList.Enabled = (bool) resources.GetObject("lvwProcessList.Enabled");

        this.lvwProcessList.Font = (System.Drawing.Font) resources.GetObject("lvwProcessList.Font");

        this.lvwProcessList.FullRowSelect = true;

        this.lvwProcessList.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lvwProcessList.ImeMode");

        this.lvwProcessList.LabelWrap = (bool) resources.GetObject("lvwProcessList.LabelWrap");

        this.lvwProcessList.Location = (System.Drawing.Point) resources.GetObject("lvwProcessList.Location");

        this.lvwProcessList.Name = "lvwProcessList";

        this.lvwProcessList.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lvwProcessList.RightToLeft");

        this.lvwProcessList.Size = (System.Drawing.Size) resources.GetObject("lvwProcessList.Size");

        this.lvwProcessList.TabIndex = (int) resources.GetObject("lvwProcessList.TabIndex");

        this.lvwProcessList.Text = resources.GetString("lvwProcessList.Text");

        this.lvwProcessList.View = System.Windows.Forms.View.Details;

        this.lvwProcessList.Visible = (bool) resources.GetObject("lvwProcessList.Visible");

        //

        //WindowsTitle

        //

        this.WindowsTitle.Text = resources.GetString("WindowsTitle.Text");

        this.WindowsTitle.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("WindowsTitle.TextAlign");

        this.WindowsTitle.Width = (int) resources.GetObject("WindowsTitle.Width");

        //

        //ClassName

        //

        this.ClassName.Text = resources.GetString("ClassName.Text");

        this.ClassName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("ClassName.TextAlign");

        this.ClassName.Width = (int) resources.GetObject("ClassName.Width");

        //

        //WindowsHandle

        //

        this.WindowsHandle.Text = resources.GetString("WindowsHandle.Text");

        this.WindowsHandle.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("WindowsHandle.TextAlign");

        this.WindowsHandle.Width = (int) resources.GetObject("WindowsHandle.Width");

        //

        //tpActiveWindows

        //

        this.tpActiveWindows.AccessibleDescription = resources.GetString("tpActiveWindows.AccessibleDescription");

        this.tpActiveWindows.AccessibleName = resources.GetString("tpActiveWindows.AccessibleName");

        this.tpActiveWindows.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpActiveWindows.Anchor");

        this.tpActiveWindows.AutoScroll = (bool) resources.GetObject("tpActiveWindows.AutoScroll");

        this.tpActiveWindows.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpActiveWindows.AutoScrollMargin");

        this.tpActiveWindows.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpActiveWindows.AutoScrollMinSize");

        this.tpActiveWindows.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpActiveWindows.BackgroundImage");

        this.tpActiveWindows.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnRefreshActiveWindows, this.Label1, this.lbActiveWindows});

        this.tpActiveWindows.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpActiveWindows.Dock");

        this.tpActiveWindows.Enabled = (bool) resources.GetObject("tpActiveWindows.Enabled");

        this.tpActiveWindows.Font = (System.Drawing.Font) resources.GetObject("tpActiveWindows.Font");

        this.tpActiveWindows.ImageIndex = (int) resources.GetObject("tpActiveWindows.ImageIndex");

        this.tpActiveWindows.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpActiveWindows.ImeMode");

        this.tpActiveWindows.Location = (System.Drawing.Point) resources.GetObject("tpActiveWindows.Location");

        this.tpActiveWindows.Name = "tpActiveWindows";

        this.tpActiveWindows.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpActiveWindows.RightToLeft");

        this.tpActiveWindows.Size = (System.Drawing.Size) resources.GetObject("tpActiveWindows.Size");

        this.tpActiveWindows.TabIndex = (int) resources.GetObject("tpActiveWindows.TabIndex");

        this.tpActiveWindows.Text = resources.GetString("tpActiveWindows.Text");

        this.tpActiveWindows.ToolTipText = resources.GetString("tpActiveWindows.ToolTipText");

        this.tpActiveWindows.Visible = (bool) resources.GetObject("tpActiveWindows.Visible");

        //

        //btnRefreshActiveWindows

        //

        this.btnRefreshActiveWindows.AccessibleDescription = resources.GetString("btnRefreshActiveWindows.AccessibleDescription");

        this.btnRefreshActiveWindows.AccessibleName = resources.GetString("btnRefreshActiveWindows.AccessibleName");

        this.btnRefreshActiveWindows.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRefreshActiveWindows.Anchor");

        this.btnRefreshActiveWindows.BackColor = System.Drawing.SystemColors.Control;

        this.btnRefreshActiveWindows.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRefreshActiveWindows.BackgroundImage");

        this.btnRefreshActiveWindows.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRefreshActiveWindows.Dock");

        this.btnRefreshActiveWindows.Enabled = (bool) resources.GetObject("btnRefreshActiveWindows.Enabled");

        this.btnRefreshActiveWindows.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRefreshActiveWindows.FlatStyle");

        this.btnRefreshActiveWindows.Font = (System.Drawing.Font) resources.GetObject("btnRefreshActiveWindows.Font");

        this.btnRefreshActiveWindows.ForeColor = System.Drawing.SystemColors.WindowText;

        this.btnRefreshActiveWindows.Image = (System.Drawing.Image) resources.GetObject("btnRefreshActiveWindows.Image");

        this.btnRefreshActiveWindows.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefreshActiveWindows.ImageAlign");

        this.btnRefreshActiveWindows.ImageIndex = (int) resources.GetObject("btnRefreshActiveWindows.ImageIndex");

        this.btnRefreshActiveWindows.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRefreshActiveWindows.ImeMode");

        this.btnRefreshActiveWindows.Location = (System.Drawing.Point) resources.GetObject("btnRefreshActiveWindows.Location");

        this.btnRefreshActiveWindows.Name = "btnRefreshActiveWindows";

        this.btnRefreshActiveWindows.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRefreshActiveWindows.RightToLeft");

        this.btnRefreshActiveWindows.Size = (System.Drawing.Size) resources.GetObject("btnRefreshActiveWindows.Size");

        this.btnRefreshActiveWindows.TabIndex = (int) resources.GetObject("btnRefreshActiveWindows.TabIndex");

        this.btnRefreshActiveWindows.Text = resources.GetString("btnRefreshActiveWindows.Text");

        this.btnRefreshActiveWindows.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefreshActiveWindows.TextAlign");

        this.btnRefreshActiveWindows.Visible = (bool) resources.GetObject("btnRefreshActiveWindows.Visible");

		this.btnRefreshActiveWindows.Click += new EventHandler(btnRefreshActiveWindows_Click);

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

        this.Label1.ForeColor = System.Drawing.Color.Black;

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

        //lbActiveWindows

        //

        this.lbActiveWindows.AccessibleDescription = resources.GetString("lbActiveWindows.AccessibleDescription");

        this.lbActiveWindows.AccessibleName = resources.GetString("lbActiveWindows.AccessibleName");

        this.lbActiveWindows.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lbActiveWindows.Anchor");

        this.lbActiveWindows.BackgroundImage = (System.Drawing.Image) resources.GetObject("lbActiveWindows.BackgroundImage");

        this.lbActiveWindows.ColumnWidth = (int) resources.GetObject("lbActiveWindows.ColumnWidth");

        this.lbActiveWindows.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lbActiveWindows.Dock");

        this.lbActiveWindows.Enabled = (bool) resources.GetObject("lbActiveWindows.Enabled");

        this.lbActiveWindows.Font = (System.Drawing.Font) resources.GetObject("lbActiveWindows.Font");

        this.lbActiveWindows.HorizontalExtent = (int) resources.GetObject("lbActiveWindows.HorizontalExtent");

        this.lbActiveWindows.HorizontalScrollbar = (bool) resources.GetObject("lbActiveWindows.HorizontalScrollbar");

        this.lbActiveWindows.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lbActiveWindows.ImeMode");

        this.lbActiveWindows.IntegralHeight = (bool) resources.GetObject("lbActiveWindows.IntegralHeight");

        this.lbActiveWindows.ItemHeight = (int) resources.GetObject("lbActiveWindows.ItemHeight");

        this.lbActiveWindows.Location = (System.Drawing.Point) resources.GetObject("lbActiveWindows.Location");

        this.lbActiveWindows.Name = "lbActiveWindows";

        this.lbActiveWindows.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lbActiveWindows.RightToLeft");

        this.lbActiveWindows.ScrollAlwaysVisible = (bool) resources.GetObject("lbActiveWindows.ScrollAlwaysVisible");

        this.lbActiveWindows.Size = (System.Drawing.Size) resources.GetObject("lbActiveWindows.Size");

        this.lbActiveWindows.TabIndex = (int) resources.GetObject("lbActiveWindows.TabIndex");

        this.lbActiveWindows.Visible = (bool) resources.GetObject("lbActiveWindows.Visible");

        //

        //tpShowWindow

        //

        this.tpShowWindow.AccessibleDescription = resources.GetString("tpShowWindow.AccessibleDescription");

        this.tpShowWindow.AccessibleName = resources.GetString("tpShowWindow.AccessibleName");

        this.tpShowWindow.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpShowWindow.Anchor");

        this.tpShowWindow.AutoScroll = (bool) resources.GetObject("tpShowWindow.AutoScroll");

        this.tpShowWindow.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpShowWindow.AutoScrollMargin");

        this.tpShowWindow.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpShowWindow.AutoScrollMinSize");

        this.tpShowWindow.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpShowWindow.BackgroundImage");

        this.tpShowWindow.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblFunctionCalled, this.btnShow, this.Label6, this.txtClassName, this.txtWindowCaption, this.Label5, this.Label4, this.Label3});

        this.tpShowWindow.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpShowWindow.Dock");

        this.tpShowWindow.Enabled = (bool) resources.GetObject("tpShowWindow.Enabled");

        this.tpShowWindow.Font = (System.Drawing.Font) resources.GetObject("tpShowWindow.Font");

        this.tpShowWindow.ImageIndex = (int) resources.GetObject("tpShowWindow.ImageIndex");

        this.tpShowWindow.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpShowWindow.ImeMode");

        this.tpShowWindow.Location = (System.Drawing.Point) resources.GetObject("tpShowWindow.Location");

        this.tpShowWindow.Name = "tpShowWindow";

        this.tpShowWindow.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpShowWindow.RightToLeft");

        this.tpShowWindow.Size = (System.Drawing.Size) resources.GetObject("tpShowWindow.Size");

        this.tpShowWindow.TabIndex = (int) resources.GetObject("tpShowWindow.TabIndex");

        this.tpShowWindow.Text = resources.GetString("tpShowWindow.Text");

        this.tpShowWindow.ToolTipText = resources.GetString("tpShowWindow.ToolTipText");

        this.tpShowWindow.Visible = (bool) resources.GetObject("tpShowWindow.Visible");

        //

        //lblFunctionCalled

        //

        this.lblFunctionCalled.AccessibleDescription = resources.GetString("lblFunctionCalled.AccessibleDescription");

        this.lblFunctionCalled.AccessibleName = resources.GetString("lblFunctionCalled.AccessibleName");

        this.lblFunctionCalled.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblFunctionCalled.Anchor");

        this.lblFunctionCalled.AutoSize = (bool) resources.GetObject("lblFunctionCalled.AutoSize");

        this.lblFunctionCalled.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblFunctionCalled.Dock");

        this.lblFunctionCalled.Enabled = (bool) resources.GetObject("lblFunctionCalled.Enabled");

        this.lblFunctionCalled.Font = (System.Drawing.Font) resources.GetObject("lblFunctionCalled.Font");

        this.lblFunctionCalled.Image = (System.Drawing.Image) resources.GetObject("lblFunctionCalled.Image");

        this.lblFunctionCalled.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblFunctionCalled.ImageAlign");

        this.lblFunctionCalled.ImageIndex = (int) resources.GetObject("lblFunctionCalled.ImageIndex");

        this.lblFunctionCalled.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblFunctionCalled.ImeMode");

        this.lblFunctionCalled.Location = (System.Drawing.Point) resources.GetObject("lblFunctionCalled.Location");

        this.lblFunctionCalled.Name = "lblFunctionCalled";

        this.lblFunctionCalled.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblFunctionCalled.RightToLeft");

        this.lblFunctionCalled.Size = (System.Drawing.Size) resources.GetObject("lblFunctionCalled.Size");

        this.lblFunctionCalled.TabIndex = (int) resources.GetObject("lblFunctionCalled.TabIndex");

        this.lblFunctionCalled.Text = resources.GetString("lblFunctionCalled.Text");

        this.lblFunctionCalled.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblFunctionCalled.TextAlign");

        this.lblFunctionCalled.Visible = (bool) resources.GetObject("lblFunctionCalled.Visible");

        //

        //btnShow

        //

        this.btnShow.AccessibleDescription = resources.GetString("btnShow.AccessibleDescription");

        this.btnShow.AccessibleName = resources.GetString("btnShow.AccessibleName");

        this.btnShow.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnShow.Anchor");

        this.btnShow.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnShow.BackgroundImage");

        this.btnShow.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnShow.Dock");

        this.btnShow.Enabled = (bool) resources.GetObject("btnShow.Enabled");

        this.btnShow.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnShow.FlatStyle");

        this.btnShow.Font = (System.Drawing.Font) resources.GetObject("btnShow.Font");

        this.btnShow.Image = (System.Drawing.Image) resources.GetObject("btnShow.Image");

        this.btnShow.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShow.ImageAlign");

        this.btnShow.ImageIndex = (int) resources.GetObject("btnShow.ImageIndex");

        this.btnShow.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnShow.ImeMode");

        this.btnShow.Location = (System.Drawing.Point) resources.GetObject("btnShow.Location");

        this.btnShow.Name = "btnShow";

        this.btnShow.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnShow.RightToLeft");

        this.btnShow.Size = (System.Drawing.Size) resources.GetObject("btnShow.Size");

        this.btnShow.TabIndex = (int) resources.GetObject("btnShow.TabIndex");

        this.btnShow.Text = resources.GetString("btnShow.Text");

        this.btnShow.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShow.TextAlign");

        this.btnShow.Visible = (bool) resources.GetObject("btnShow.Visible");

		this.btnShow.Click += new EventHandler(btnShow_Click);

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

        this.Label6.ForeColor = System.Drawing.Color.Black;

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

        //txtClassName

        //

        this.txtClassName.AccessibleDescription = resources.GetString("txtClassName.AccessibleDescription");

        this.txtClassName.AccessibleName = resources.GetString("txtClassName.AccessibleName");

        this.txtClassName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtClassName.Anchor");

        this.txtClassName.AutoSize = (bool) resources.GetObject("txtClassName.AutoSize");

        this.txtClassName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtClassName.BackgroundImage");

        this.txtClassName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtClassName.Dock");

        this.txtClassName.Enabled = (bool) resources.GetObject("txtClassName.Enabled");

        this.txtClassName.Font = (System.Drawing.Font) resources.GetObject("txtClassName.Font");

        this.txtClassName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtClassName.ImeMode");

        this.txtClassName.Location = (System.Drawing.Point) resources.GetObject("txtClassName.Location");

        this.txtClassName.MaxLength = (int) resources.GetObject("txtClassName.MaxLength");

        this.txtClassName.Multiline = (bool) resources.GetObject("txtClassName.Multiline");

        this.txtClassName.Name = "txtClassName";

        this.txtClassName.PasswordChar = (char) resources.GetObject("txtClassName.PasswordChar");

        this.txtClassName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtClassName.RightToLeft");

        this.txtClassName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtClassName.ScrollBars");

        this.txtClassName.Size = (System.Drawing.Size) resources.GetObject("txtClassName.Size");

        this.txtClassName.TabIndex = (int) resources.GetObject("txtClassName.TabIndex");

        this.txtClassName.Text = resources.GetString("txtClassName.Text");

        this.txtClassName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtClassName.TextAlign");

        this.txtClassName.Visible = (bool) resources.GetObject("txtClassName.Visible");

        this.txtClassName.WordWrap = (bool) resources.GetObject("txtClassName.WordWrap");

		this.txtClassName.TextChanged += new EventHandler(txtClassName_TextChanged);

        //

        //txtWindowCaption

        //

        this.txtWindowCaption.AccessibleDescription = resources.GetString("txtWindowCaption.AccessibleDescription");

        this.txtWindowCaption.AccessibleName = resources.GetString("txtWindowCaption.AccessibleName");

        this.txtWindowCaption.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtWindowCaption.Anchor");

        this.txtWindowCaption.AutoSize = (bool) resources.GetObject("txtWindowCaption.AutoSize");

        this.txtWindowCaption.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtWindowCaption.BackgroundImage");

        this.txtWindowCaption.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtWindowCaption.Dock");

        this.txtWindowCaption.Enabled = (bool) resources.GetObject("txtWindowCaption.Enabled");

        this.txtWindowCaption.Font = (System.Drawing.Font) resources.GetObject("txtWindowCaption.Font");

        this.txtWindowCaption.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtWindowCaption.ImeMode");

        this.txtWindowCaption.Location = (System.Drawing.Point) resources.GetObject("txtWindowCaption.Location");

        this.txtWindowCaption.MaxLength = (int) resources.GetObject("txtWindowCaption.MaxLength");

        this.txtWindowCaption.Multiline = (bool) resources.GetObject("txtWindowCaption.Multiline");

        this.txtWindowCaption.Name = "txtWindowCaption";

        this.txtWindowCaption.PasswordChar = (char) resources.GetObject("txtWindowCaption.PasswordChar");

        this.txtWindowCaption.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtWindowCaption.RightToLeft");

        this.txtWindowCaption.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtWindowCaption.ScrollBars");

        this.txtWindowCaption.Size = (System.Drawing.Size) resources.GetObject("txtWindowCaption.Size");

        this.txtWindowCaption.TabIndex = (int) resources.GetObject("txtWindowCaption.TabIndex");

        this.txtWindowCaption.Text = resources.GetString("txtWindowCaption.Text");

        this.txtWindowCaption.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtWindowCaption.TextAlign");

        this.txtWindowCaption.Visible = (bool) resources.GetObject("txtWindowCaption.Visible");

        this.txtWindowCaption.WordWrap = (bool) resources.GetObject("txtWindowCaption.WordWrap");

		this.txtWindowCaption.TextChanged += new EventHandler(txtWindowCaption_TextChanged);

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

        //Label3

        //

        this.Label3.AccessibleDescription = (string) resources.GetObject("Label3.AccessibleDescription");

        this.Label3.AccessibleName = (string) resources.GetObject("Label3.AccessibleName");

        this.Label3.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label3.Anchor");

        this.Label3.AutoSize = (bool) resources.GetObject("Label3.AutoSize");

        this.Label3.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label3.Dock");

        this.Label3.Enabled = (bool) resources.GetObject("Label3.Enabled");

        this.Label3.Font = (System.Drawing.Font) resources.GetObject("Label3.Font");

        this.Label3.ForeColor = System.Drawing.Color.Black;

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

        //tpAPICalls

        //

        this.tpAPICalls.AccessibleDescription = resources.GetString("tpAPICalls.AccessibleDescription");

        this.tpAPICalls.AccessibleName = resources.GetString("tpAPICalls.AccessibleName");

        this.tpAPICalls.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tpAPICalls.Anchor");

        this.tpAPICalls.AutoScroll = (bool) resources.GetObject("tpAPICalls.AutoScroll");

        this.tpAPICalls.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("tpAPICalls.AutoScrollMargin");

        this.tpAPICalls.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("tpAPICalls.AutoScrollMinSize");

        this.tpAPICalls.BackgroundImage = (System.Drawing.Image) resources.GetObject("tpAPICalls.BackgroundImage");

        this.tpAPICalls.Controls.AddRange(new System.Windows.Forms.Control[] {this.CallingVariationGroupBox, this.Label9, this.DirectoryGroupBox, this.MouseGroupBox, this.DriveGroupBox, this.txtFunctionOutput, this.MiscGroupBox});

        this.tpAPICalls.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tpAPICalls.Dock");

        this.tpAPICalls.Enabled = (bool) resources.GetObject("tpAPICalls.Enabled");

        this.tpAPICalls.Font = (System.Drawing.Font) resources.GetObject("tpAPICalls.Font");

        this.tpAPICalls.ImageIndex = (int) resources.GetObject("tpAPICalls.ImageIndex");

        this.tpAPICalls.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tpAPICalls.ImeMode");

        this.tpAPICalls.Location = (System.Drawing.Point) resources.GetObject("tpAPICalls.Location");

        this.tpAPICalls.Name = "tpAPICalls";

        this.tpAPICalls.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tpAPICalls.RightToLeft");

        this.tpAPICalls.Size = (System.Drawing.Size) resources.GetObject("tpAPICalls.Size");

        this.tpAPICalls.TabIndex = (int) resources.GetObject("tpAPICalls.TabIndex");

        this.tpAPICalls.Text = resources.GetString("tpAPICalls.Text");

        this.tpAPICalls.ToolTipText = resources.GetString("tpAPICalls.ToolTipText");

        this.tpAPICalls.Visible = (bool) resources.GetObject("tpAPICalls.Visible");

        //

        //CallingVariationGroupBox

        //

        this.CallingVariationGroupBox.AccessibleDescription = (string) resources.GetObject("CallingVariationGroupBox.AccessibleDescription");

        this.CallingVariationGroupBox.AccessibleName = (string) resources.GetObject("CallingVariationGroupBox.AccessibleName");

        this.CallingVariationGroupBox.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("CallingVariationGroupBox.Anchor");

        this.CallingVariationGroupBox.BackgroundImage = (System.Drawing.Image) resources.GetObject("CallingVariationGroupBox.BackgroundImage");

        this.CallingVariationGroupBox.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnBeep, this.rbAuto, this.rbANSI, this.rbUnicode, this.rbDLLImport, this.rbDeclare});

        this.CallingVariationGroupBox.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("CallingVariationGroupBox.Dock");

        this.CallingVariationGroupBox.Enabled = (bool) resources.GetObject("CallingVariationGroupBox.Enabled");

        this.CallingVariationGroupBox.Font = (System.Drawing.Font) resources.GetObject("CallingVariationGroupBox.Font");

        this.CallingVariationGroupBox.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("CallingVariationGroupBox.ImeMode");

        this.CallingVariationGroupBox.Location = (System.Drawing.Point) resources.GetObject("CallingVariationGroupBox.Location");

        this.CallingVariationGroupBox.Name = "CallingVariationGroupBox";

        this.CallingVariationGroupBox.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("CallingVariationGroupBox.RightToLeft");

        this.CallingVariationGroupBox.Size = (System.Drawing.Size) resources.GetObject("CallingVariationGroupBox.Size");

        this.CallingVariationGroupBox.TabIndex = (int) resources.GetObject("CallingVariationGroupBox.TabIndex");

        this.CallingVariationGroupBox.TabStop = false;

        this.CallingVariationGroupBox.Text = resources.GetString("CallingVariationGroupBox.Text");

        this.CallingVariationGroupBox.Visible = (bool) resources.GetObject("CallingVariationGroupBox.Visible");

        //

        //btnBeep

        //

        this.btnBeep.AccessibleDescription = resources.GetString("btnBeep.AccessibleDescription");

        this.btnBeep.AccessibleName = resources.GetString("btnBeep.AccessibleName");

        this.btnBeep.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnBeep.Anchor");

        this.btnBeep.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnBeep.BackgroundImage");

        this.btnBeep.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnBeep.Dock");

        this.btnBeep.Enabled = (bool) resources.GetObject("btnBeep.Enabled");

        this.btnBeep.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnBeep.FlatStyle");

        this.btnBeep.Font = (System.Drawing.Font) resources.GetObject("btnBeep.Font");

        this.btnBeep.Image = (System.Drawing.Image) resources.GetObject("btnBeep.Image");

        this.btnBeep.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBeep.ImageAlign");

        this.btnBeep.ImageIndex = (int) resources.GetObject("btnBeep.ImageIndex");

        this.btnBeep.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnBeep.ImeMode");

        this.btnBeep.Location = (System.Drawing.Point) resources.GetObject("btnBeep.Location");

        this.btnBeep.Name = "btnBeep";

        this.btnBeep.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnBeep.RightToLeft");

        this.btnBeep.Size = (System.Drawing.Size) resources.GetObject("btnBeep.Size");

        this.btnBeep.TabIndex = (int) resources.GetObject("btnBeep.TabIndex");

        this.btnBeep.Text = resources.GetString("btnBeep.Text");

        this.btnBeep.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBeep.TextAlign");

        this.btnBeep.Visible = (bool) resources.GetObject("btnBeep.Visible");

		this.btnBeep.Click += new EventHandler(btnBeep_Click);

        //

        //rbAuto

        //

        this.rbAuto.AccessibleDescription = resources.GetString("rbAuto.AccessibleDescription");

        this.rbAuto.AccessibleName = resources.GetString("rbAuto.AccessibleName");

        this.rbAuto.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rbAuto.Anchor");

        this.rbAuto.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("rbAuto.Appearance");

        this.rbAuto.BackgroundImage = (System.Drawing.Image) resources.GetObject("rbAuto.BackgroundImage");

        this.rbAuto.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbAuto.CheckAlign");

        this.rbAuto.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rbAuto.Dock");

        this.rbAuto.Enabled = (bool) resources.GetObject("rbAuto.Enabled");

        this.rbAuto.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("rbAuto.FlatStyle");

        this.rbAuto.Font = (System.Drawing.Font) resources.GetObject("rbAuto.Font");

        this.rbAuto.Image = (System.Drawing.Image) resources.GetObject("rbAuto.Image");

        this.rbAuto.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbAuto.ImageAlign");

        this.rbAuto.ImageIndex = (int) resources.GetObject("rbAuto.ImageIndex");

        this.rbAuto.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rbAuto.ImeMode");

        this.rbAuto.Location = (System.Drawing.Point) resources.GetObject("rbAuto.Location");

        this.rbAuto.Name = "rbAuto";

        this.rbAuto.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rbAuto.RightToLeft");

        this.rbAuto.Size = (System.Drawing.Size) resources.GetObject("rbAuto.Size");

        this.rbAuto.TabIndex = (int) resources.GetObject("rbAuto.TabIndex");

        this.rbAuto.Text = resources.GetString("rbAuto.Text");

        this.rbAuto.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbAuto.TextAlign");

        this.rbAuto.Visible = (bool) resources.GetObject("rbAuto.Visible");

        //

        //rbANSI

        //

        this.rbANSI.AccessibleDescription = resources.GetString("rbANSI.AccessibleDescription");

        this.rbANSI.AccessibleName = resources.GetString("rbANSI.AccessibleName");

        this.rbANSI.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rbANSI.Anchor");

        this.rbANSI.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("rbANSI.Appearance");

        this.rbANSI.BackgroundImage = (System.Drawing.Image) resources.GetObject("rbANSI.BackgroundImage");

        this.rbANSI.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbANSI.CheckAlign");

        this.rbANSI.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rbANSI.Dock");

        this.rbANSI.Enabled = (bool) resources.GetObject("rbANSI.Enabled");

        this.rbANSI.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("rbANSI.FlatStyle");

        this.rbANSI.Font = (System.Drawing.Font) resources.GetObject("rbANSI.Font");

        this.rbANSI.Image = (System.Drawing.Image) resources.GetObject("rbANSI.Image");

        this.rbANSI.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbANSI.ImageAlign");

        this.rbANSI.ImageIndex = (int) resources.GetObject("rbANSI.ImageIndex");

        this.rbANSI.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rbANSI.ImeMode");

        this.rbANSI.Location = (System.Drawing.Point) resources.GetObject("rbANSI.Location");

        this.rbANSI.Name = "rbANSI";

        this.rbANSI.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rbANSI.RightToLeft");

        this.rbANSI.Size = (System.Drawing.Size) resources.GetObject("rbANSI.Size");

        this.rbANSI.TabIndex = (int) resources.GetObject("rbANSI.TabIndex");

        this.rbANSI.Text = resources.GetString("rbANSI.Text");

        this.rbANSI.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbANSI.TextAlign");

        this.rbANSI.Visible = (bool) resources.GetObject("rbANSI.Visible");

        //

        //rbUnicode

        //

        this.rbUnicode.AccessibleDescription = resources.GetString("rbUnicode.AccessibleDescription");

        this.rbUnicode.AccessibleName = resources.GetString("rbUnicode.AccessibleName");

        this.rbUnicode.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rbUnicode.Anchor");

        this.rbUnicode.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("rbUnicode.Appearance");

        this.rbUnicode.BackgroundImage = (System.Drawing.Image) resources.GetObject("rbUnicode.BackgroundImage");

        this.rbUnicode.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbUnicode.CheckAlign");

        this.rbUnicode.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rbUnicode.Dock");

        this.rbUnicode.Enabled = (bool) resources.GetObject("rbUnicode.Enabled");

        this.rbUnicode.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("rbUnicode.FlatStyle");

        this.rbUnicode.Font = (System.Drawing.Font) resources.GetObject("rbUnicode.Font");

        this.rbUnicode.Image = (System.Drawing.Image) resources.GetObject("rbUnicode.Image");

        this.rbUnicode.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbUnicode.ImageAlign");

        this.rbUnicode.ImageIndex = (int) resources.GetObject("rbUnicode.ImageIndex");

        this.rbUnicode.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rbUnicode.ImeMode");

        this.rbUnicode.Location = (System.Drawing.Point) resources.GetObject("rbUnicode.Location");

        this.rbUnicode.Name = "rbUnicode";

        this.rbUnicode.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rbUnicode.RightToLeft");

        this.rbUnicode.Size = (System.Drawing.Size) resources.GetObject("rbUnicode.Size");

        this.rbUnicode.TabIndex = (int) resources.GetObject("rbUnicode.TabIndex");

        this.rbUnicode.Text = resources.GetString("rbUnicode.Text");

        this.rbUnicode.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbUnicode.TextAlign");

        this.rbUnicode.Visible = (bool) resources.GetObject("rbUnicode.Visible");

        //

        //rbDLLImport

        //

        this.rbDLLImport.AccessibleDescription = resources.GetString("rbDLLImport.AccessibleDescription");

        this.rbDLLImport.AccessibleName = resources.GetString("rbDLLImport.AccessibleName");

        this.rbDLLImport.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rbDLLImport.Anchor");

        this.rbDLLImport.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("rbDLLImport.Appearance");

        this.rbDLLImport.BackgroundImage = (System.Drawing.Image) resources.GetObject("rbDLLImport.BackgroundImage");

        this.rbDLLImport.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbDLLImport.CheckAlign");

        this.rbDLLImport.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rbDLLImport.Dock");

        this.rbDLLImport.Enabled = (bool) resources.GetObject("rbDLLImport.Enabled");

        this.rbDLLImport.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("rbDLLImport.FlatStyle");

        this.rbDLLImport.Font = (System.Drawing.Font) resources.GetObject("rbDLLImport.Font");

        this.rbDLLImport.Image = (System.Drawing.Image) resources.GetObject("rbDLLImport.Image");

        this.rbDLLImport.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbDLLImport.ImageAlign");

        this.rbDLLImport.ImageIndex = (int) resources.GetObject("rbDLLImport.ImageIndex");

        this.rbDLLImport.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rbDLLImport.ImeMode");

        this.rbDLLImport.Location = (System.Drawing.Point) resources.GetObject("rbDLLImport.Location");

        this.rbDLLImport.Name = "rbDLLImport";

        this.rbDLLImport.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rbDLLImport.RightToLeft");

        this.rbDLLImport.Size = (System.Drawing.Size) resources.GetObject("rbDLLImport.Size");

        this.rbDLLImport.TabIndex = (int) resources.GetObject("rbDLLImport.TabIndex");

        this.rbDLLImport.Text = resources.GetString("rbDLLImport.Text");

        this.rbDLLImport.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbDLLImport.TextAlign");

        this.rbDLLImport.Visible = (bool) resources.GetObject("rbDLLImport.Visible");

        //

        //rbDeclare

        //

        this.rbDeclare.AccessibleDescription = resources.GetString("rbDeclare.AccessibleDescription");

        this.rbDeclare.AccessibleName = resources.GetString("rbDeclare.AccessibleName");

        this.rbDeclare.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rbDeclare.Anchor");

        this.rbDeclare.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("rbDeclare.Appearance");

        this.rbDeclare.BackgroundImage = (System.Drawing.Image) resources.GetObject("rbDeclare.BackgroundImage");

        this.rbDeclare.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbDeclare.CheckAlign");

        this.rbDeclare.Checked = true;

        this.rbDeclare.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rbDeclare.Dock");

        this.rbDeclare.Enabled = (bool) resources.GetObject("rbDeclare.Enabled");

        this.rbDeclare.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("rbDeclare.FlatStyle");

        this.rbDeclare.Font = (System.Drawing.Font) resources.GetObject("rbDeclare.Font");

        this.rbDeclare.Image = (System.Drawing.Image) resources.GetObject("rbDeclare.Image");

        this.rbDeclare.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbDeclare.ImageAlign");

        this.rbDeclare.ImageIndex = (int) resources.GetObject("rbDeclare.ImageIndex");

        this.rbDeclare.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rbDeclare.ImeMode");

        this.rbDeclare.Location = (System.Drawing.Point) resources.GetObject("rbDeclare.Location");

        this.rbDeclare.Name = "rbDeclare";

        this.rbDeclare.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rbDeclare.RightToLeft");

        this.rbDeclare.Size = (System.Drawing.Size) resources.GetObject("rbDeclare.Size");

        this.rbDeclare.TabIndex = (int) resources.GetObject("rbDeclare.TabIndex");

        this.rbDeclare.TabStop = true;

        this.rbDeclare.Text = resources.GetString("rbDeclare.Text");

        this.rbDeclare.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("rbDeclare.TextAlign");

        this.rbDeclare.Visible = (bool) resources.GetObject("rbDeclare.Visible");

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

        this.Label9.ForeColor = System.Drawing.Color.Black;

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

        //DirectoryGroupBox

        //

        this.DirectoryGroupBox.AccessibleDescription = (string) resources.GetObject("DirectoryGroupBox.AccessibleDescription");

        this.DirectoryGroupBox.AccessibleName = (string) resources.GetObject("DirectoryGroupBox.AccessibleName");

        this.DirectoryGroupBox.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("DirectoryGroupBox.Anchor");

        this.DirectoryGroupBox.BackgroundImage = (System.Drawing.Image) resources.GetObject("DirectoryGroupBox.BackgroundImage");

        this.DirectoryGroupBox.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtDirectory, this.btnCreateDirectory});

        this.DirectoryGroupBox.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("DirectoryGroupBox.Dock");

        this.DirectoryGroupBox.Enabled = (bool) resources.GetObject("DirectoryGroupBox.Enabled");

        this.DirectoryGroupBox.Font = (System.Drawing.Font) resources.GetObject("DirectoryGroupBox.Font");

        this.DirectoryGroupBox.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("DirectoryGroupBox.ImeMode");

        this.DirectoryGroupBox.Location = (System.Drawing.Point) resources.GetObject("DirectoryGroupBox.Location");

        this.DirectoryGroupBox.Name = "DirectoryGroupBox";

        this.DirectoryGroupBox.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("DirectoryGroupBox.RightToLeft");

        this.DirectoryGroupBox.Size = (System.Drawing.Size) resources.GetObject("DirectoryGroupBox.Size");

        this.DirectoryGroupBox.TabIndex = (int) resources.GetObject("DirectoryGroupBox.TabIndex");

        this.DirectoryGroupBox.TabStop = false;

        this.DirectoryGroupBox.Text = resources.GetString("DirectoryGroupBox.Text");

        this.DirectoryGroupBox.Visible = (bool) resources.GetObject("DirectoryGroupBox.Visible");

        //

        //txtDirectory

        //

        this.txtDirectory.AccessibleDescription = resources.GetString("txtDirectory.AccessibleDescription");

        this.txtDirectory.AccessibleName = resources.GetString("txtDirectory.AccessibleName");

        this.txtDirectory.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtDirectory.Anchor");

        this.txtDirectory.AutoSize = (bool) resources.GetObject("txtDirectory.AutoSize");

        this.txtDirectory.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtDirectory.BackgroundImage");

        this.txtDirectory.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtDirectory.Dock");

        this.txtDirectory.Enabled = (bool) resources.GetObject("txtDirectory.Enabled");

        this.txtDirectory.Font = (System.Drawing.Font) resources.GetObject("txtDirectory.Font");

        this.txtDirectory.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtDirectory.ImeMode");

        this.txtDirectory.Location = (System.Drawing.Point) resources.GetObject("txtDirectory.Location");

        this.txtDirectory.MaxLength = (int) resources.GetObject("txtDirectory.MaxLength");

        this.txtDirectory.Multiline = (bool) resources.GetObject("txtDirectory.Multiline");

        this.txtDirectory.Name = "txtDirectory";

        this.txtDirectory.PasswordChar = (char) resources.GetObject("txtDirectory.PasswordChar");

        this.txtDirectory.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtDirectory.RightToLeft");

        this.txtDirectory.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtDirectory.ScrollBars");

        this.txtDirectory.Size = (System.Drawing.Size) resources.GetObject("txtDirectory.Size");

        this.txtDirectory.TabIndex = (int) resources.GetObject("txtDirectory.TabIndex");

        this.txtDirectory.Text = resources.GetString("txtDirectory.Text");

        this.txtDirectory.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtDirectory.TextAlign");

        this.txtDirectory.Visible = (bool) resources.GetObject("txtDirectory.Visible");

        this.txtDirectory.WordWrap = (bool) resources.GetObject("txtDirectory.WordWrap");

        //

        //btnCreateDirectory

        //

        this.btnCreateDirectory.AccessibleDescription = resources.GetString("btnCreateDirectory.AccessibleDescription");

        this.btnCreateDirectory.AccessibleName = resources.GetString("btnCreateDirectory.AccessibleName");

        this.btnCreateDirectory.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateDirectory.Anchor");

        this.btnCreateDirectory.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateDirectory.BackgroundImage");

        this.btnCreateDirectory.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateDirectory.Dock");

        this.btnCreateDirectory.Enabled = (bool) resources.GetObject("btnCreateDirectory.Enabled");

        this.btnCreateDirectory.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateDirectory.FlatStyle");

        this.btnCreateDirectory.Font = (System.Drawing.Font) resources.GetObject("btnCreateDirectory.Font");

        this.btnCreateDirectory.Image = (System.Drawing.Image) resources.GetObject("btnCreateDirectory.Image");

        this.btnCreateDirectory.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateDirectory.ImageAlign");

        this.btnCreateDirectory.ImageIndex = (int) resources.GetObject("btnCreateDirectory.ImageIndex");

        this.btnCreateDirectory.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateDirectory.ImeMode");

        this.btnCreateDirectory.Location = (System.Drawing.Point) resources.GetObject("btnCreateDirectory.Location");

        this.btnCreateDirectory.Name = "btnCreateDirectory";

        this.btnCreateDirectory.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateDirectory.RightToLeft");

        this.btnCreateDirectory.Size = (System.Drawing.Size) resources.GetObject("btnCreateDirectory.Size");

        this.btnCreateDirectory.TabIndex = (int) resources.GetObject("btnCreateDirectory.TabIndex");

        this.btnCreateDirectory.Text = resources.GetString("btnCreateDirectory.Text");

        this.btnCreateDirectory.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateDirectory.TextAlign");

        this.btnCreateDirectory.Visible = (bool) resources.GetObject("btnCreateDirectory.Visible");

		this.btnCreateDirectory.Click += new EventHandler(btnCreateDirectory_Click);

        //

        //MouseGroupBox

        //

        this.MouseGroupBox.AccessibleDescription = (string) resources.GetObject("MouseGroupBox.AccessibleDescription");

        this.MouseGroupBox.AccessibleName = (string) resources.GetObject("MouseGroupBox.AccessibleName");

        this.MouseGroupBox.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("MouseGroupBox.Anchor");

        this.MouseGroupBox.BackgroundImage = (System.Drawing.Image) resources.GetObject("MouseGroupBox.BackgroundImage");

        this.MouseGroupBox.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnResetMouseButton, this.btnSwapMouseButton});

        this.MouseGroupBox.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("MouseGroupBox.Dock");

        this.MouseGroupBox.Enabled = (bool) resources.GetObject("MouseGroupBox.Enabled");

        this.MouseGroupBox.Font = (System.Drawing.Font) resources.GetObject("MouseGroupBox.Font");

        this.MouseGroupBox.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("MouseGroupBox.ImeMode");

        this.MouseGroupBox.Location = (System.Drawing.Point) resources.GetObject("MouseGroupBox.Location");

        this.MouseGroupBox.Name = "MouseGroupBox";

        this.MouseGroupBox.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("MouseGroupBox.RightToLeft");

        this.MouseGroupBox.Size = (System.Drawing.Size) resources.GetObject("MouseGroupBox.Size");

        this.MouseGroupBox.TabIndex = (int) resources.GetObject("MouseGroupBox.TabIndex");

        this.MouseGroupBox.TabStop = false;

        this.MouseGroupBox.Text = resources.GetString("MouseGroupBox.Text");

        this.MouseGroupBox.Visible = (bool) resources.GetObject("MouseGroupBox.Visible");

        //

        //btnResetMouseButton

        //

        this.btnResetMouseButton.AccessibleDescription = resources.GetString("btnResetMouseButton.AccessibleDescription");

        this.btnResetMouseButton.AccessibleName = resources.GetString("btnResetMouseButton.AccessibleName");

        this.btnResetMouseButton.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnResetMouseButton.Anchor");

        this.btnResetMouseButton.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnResetMouseButton.BackgroundImage");

        this.btnResetMouseButton.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnResetMouseButton.Dock");

        this.btnResetMouseButton.Enabled = (bool) resources.GetObject("btnResetMouseButton.Enabled");

        this.btnResetMouseButton.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnResetMouseButton.FlatStyle");

        this.btnResetMouseButton.Font = (System.Drawing.Font) resources.GetObject("btnResetMouseButton.Font");

        this.btnResetMouseButton.Image = (System.Drawing.Image) resources.GetObject("btnResetMouseButton.Image");

        this.btnResetMouseButton.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnResetMouseButton.ImageAlign");

        this.btnResetMouseButton.ImageIndex = (int) resources.GetObject("btnResetMouseButton.ImageIndex");

        this.btnResetMouseButton.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnResetMouseButton.ImeMode");

        this.btnResetMouseButton.Location = (System.Drawing.Point) resources.GetObject("btnResetMouseButton.Location");

        this.btnResetMouseButton.Name = "btnResetMouseButton";

        this.btnResetMouseButton.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnResetMouseButton.RightToLeft");

        this.btnResetMouseButton.Size = (System.Drawing.Size) resources.GetObject("btnResetMouseButton.Size");

        this.btnResetMouseButton.TabIndex = (int) resources.GetObject("btnResetMouseButton.TabIndex");

        this.btnResetMouseButton.Text = resources.GetString("btnResetMouseButton.Text");

        this.btnResetMouseButton.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnResetMouseButton.TextAlign");

        this.btnResetMouseButton.Visible = (bool) resources.GetObject("btnResetMouseButton.Visible");

		this.btnResetMouseButton.Click += new EventHandler(btnResetMouseButton_Click);

        //

        //btnSwapMouseButton

        //

        this.btnSwapMouseButton.AccessibleDescription = resources.GetString("btnSwapMouseButton.AccessibleDescription");

        this.btnSwapMouseButton.AccessibleName = resources.GetString("btnSwapMouseButton.AccessibleName");

        this.btnSwapMouseButton.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSwapMouseButton.Anchor");

        this.btnSwapMouseButton.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSwapMouseButton.BackgroundImage");

        this.btnSwapMouseButton.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSwapMouseButton.Dock");

        this.btnSwapMouseButton.Enabled = (bool) resources.GetObject("btnSwapMouseButton.Enabled");

        this.btnSwapMouseButton.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSwapMouseButton.FlatStyle");

        this.btnSwapMouseButton.Font = (System.Drawing.Font) resources.GetObject("btnSwapMouseButton.Font");

        this.btnSwapMouseButton.Image = (System.Drawing.Image) resources.GetObject("btnSwapMouseButton.Image");

        this.btnSwapMouseButton.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSwapMouseButton.ImageAlign");

        this.btnSwapMouseButton.ImageIndex = (int) resources.GetObject("btnSwapMouseButton.ImageIndex");

        this.btnSwapMouseButton.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSwapMouseButton.ImeMode");

        this.btnSwapMouseButton.Location = (System.Drawing.Point) resources.GetObject("btnSwapMouseButton.Location");

        this.btnSwapMouseButton.Name = "btnSwapMouseButton";

        this.btnSwapMouseButton.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSwapMouseButton.RightToLeft");

        this.btnSwapMouseButton.Size = (System.Drawing.Size) resources.GetObject("btnSwapMouseButton.Size");

        this.btnSwapMouseButton.TabIndex = (int) resources.GetObject("btnSwapMouseButton.TabIndex");

        this.btnSwapMouseButton.Text = resources.GetString("btnSwapMouseButton.Text");

        this.btnSwapMouseButton.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSwapMouseButton.TextAlign");

        this.btnSwapMouseButton.Visible = (bool) resources.GetObject("btnSwapMouseButton.Visible");

		this.btnSwapMouseButton.Click += new EventHandler(btnSwapMouseButton_Click);

        //

        //DriveGroupBox

        //

        this.DriveGroupBox.AccessibleDescription = (string) resources.GetObject("DriveGroupBox.AccessibleDescription");

        this.DriveGroupBox.AccessibleName = (string) resources.GetObject("DriveGroupBox.AccessibleName");

        this.DriveGroupBox.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("DriveGroupBox.Anchor");

        this.DriveGroupBox.BackgroundImage = (System.Drawing.Image) resources.GetObject("DriveGroupBox.BackgroundImage");

        this.DriveGroupBox.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label8, this.txtDriveLetter, this.btnGetDriveType, this.btnGetDiskFreeSpaceEx, this.btnGetFreeSpace});

        this.DriveGroupBox.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("DriveGroupBox.Dock");

        this.DriveGroupBox.Enabled = (bool) resources.GetObject("DriveGroupBox.Enabled");

        this.DriveGroupBox.Font = (System.Drawing.Font) resources.GetObject("DriveGroupBox.Font");

        this.DriveGroupBox.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("DriveGroupBox.ImeMode");

        this.DriveGroupBox.Location = (System.Drawing.Point) resources.GetObject("DriveGroupBox.Location");

        this.DriveGroupBox.Name = "DriveGroupBox";

        this.DriveGroupBox.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("DriveGroupBox.RightToLeft");

        this.DriveGroupBox.Size = (System.Drawing.Size) resources.GetObject("DriveGroupBox.Size");

        this.DriveGroupBox.TabIndex = (int) resources.GetObject("DriveGroupBox.TabIndex");

        this.DriveGroupBox.TabStop = false;

        this.DriveGroupBox.Text = resources.GetString("DriveGroupBox.Text");

        this.DriveGroupBox.Visible = (bool) resources.GetObject("DriveGroupBox.Visible");

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

        //txtDriveLetter

        //

        this.txtDriveLetter.AccessibleDescription = resources.GetString("txtDriveLetter.AccessibleDescription");

        this.txtDriveLetter.AccessibleName = resources.GetString("txtDriveLetter.AccessibleName");

        this.txtDriveLetter.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtDriveLetter.Anchor");

        this.txtDriveLetter.AutoSize = (bool) resources.GetObject("txtDriveLetter.AutoSize");

        this.txtDriveLetter.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtDriveLetter.BackgroundImage");

        this.txtDriveLetter.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtDriveLetter.Dock");

        this.txtDriveLetter.Enabled = (bool) resources.GetObject("txtDriveLetter.Enabled");

        this.txtDriveLetter.Font = (System.Drawing.Font) resources.GetObject("txtDriveLetter.Font");

        this.txtDriveLetter.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtDriveLetter.ImeMode");

        this.txtDriveLetter.Location = (System.Drawing.Point) resources.GetObject("txtDriveLetter.Location");

        this.txtDriveLetter.MaxLength = (int) resources.GetObject("txtDriveLetter.MaxLength");

        this.txtDriveLetter.Multiline = (bool) resources.GetObject("txtDriveLetter.Multiline");

        this.txtDriveLetter.Name = "txtDriveLetter";

        this.txtDriveLetter.PasswordChar = (char) resources.GetObject("txtDriveLetter.PasswordChar");

        this.txtDriveLetter.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtDriveLetter.RightToLeft");

        this.txtDriveLetter.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtDriveLetter.ScrollBars");

        this.txtDriveLetter.Size = (System.Drawing.Size) resources.GetObject("txtDriveLetter.Size");

        this.txtDriveLetter.TabIndex = (int) resources.GetObject("txtDriveLetter.TabIndex");

        this.txtDriveLetter.Text = resources.GetString("txtDriveLetter.Text");

        this.txtDriveLetter.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtDriveLetter.TextAlign");

        this.txtDriveLetter.Visible = (bool) resources.GetObject("txtDriveLetter.Visible");

        this.txtDriveLetter.WordWrap = (bool) resources.GetObject("txtDriveLetter.WordWrap");

        //

        //btnGetDriveType

        //

        this.btnGetDriveType.AccessibleDescription = resources.GetString("btnGetDriveType.AccessibleDescription");

        this.btnGetDriveType.AccessibleName = resources.GetString("btnGetDriveType.AccessibleName");

        this.btnGetDriveType.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGetDriveType.Anchor");

        this.btnGetDriveType.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGetDriveType.BackgroundImage");

        this.btnGetDriveType.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGetDriveType.Dock");

        this.btnGetDriveType.Enabled = (bool) resources.GetObject("btnGetDriveType.Enabled");

        this.btnGetDriveType.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGetDriveType.FlatStyle");

        this.btnGetDriveType.Font = (System.Drawing.Font) resources.GetObject("btnGetDriveType.Font");

        this.btnGetDriveType.Image = (System.Drawing.Image) resources.GetObject("btnGetDriveType.Image");

        this.btnGetDriveType.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetDriveType.ImageAlign");

        this.btnGetDriveType.ImageIndex = (int) resources.GetObject("btnGetDriveType.ImageIndex");

        this.btnGetDriveType.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGetDriveType.ImeMode");

        this.btnGetDriveType.Location = (System.Drawing.Point) resources.GetObject("btnGetDriveType.Location");

        this.btnGetDriveType.Name = "btnGetDriveType";

        this.btnGetDriveType.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGetDriveType.RightToLeft");

        this.btnGetDriveType.Size = (System.Drawing.Size) resources.GetObject("btnGetDriveType.Size");

        this.btnGetDriveType.TabIndex = (int) resources.GetObject("btnGetDriveType.TabIndex");

        this.btnGetDriveType.Text = resources.GetString("btnGetDriveType.Text");

        this.btnGetDriveType.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetDriveType.TextAlign");

        this.btnGetDriveType.Visible = (bool) resources.GetObject("btnGetDriveType.Visible");

		this.btnGetDriveType.Click += new EventHandler(btnGetDriveType_Click);

        //

        //btnGetDiskFreeSpaceEx

        //

        this.btnGetDiskFreeSpaceEx.AccessibleDescription = resources.GetString("btnGetDiskFreeSpaceEx.AccessibleDescription");

        this.btnGetDiskFreeSpaceEx.AccessibleName = resources.GetString("btnGetDiskFreeSpaceEx.AccessibleName");

        this.btnGetDiskFreeSpaceEx.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGetDiskFreeSpaceEx.Anchor");

        this.btnGetDiskFreeSpaceEx.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGetDiskFreeSpaceEx.BackgroundImage");

        this.btnGetDiskFreeSpaceEx.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGetDiskFreeSpaceEx.Dock");

        this.btnGetDiskFreeSpaceEx.Enabled = (bool) resources.GetObject("btnGetDiskFreeSpaceEx.Enabled");

        this.btnGetDiskFreeSpaceEx.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGetDiskFreeSpaceEx.FlatStyle");

        this.btnGetDiskFreeSpaceEx.Font = (System.Drawing.Font) resources.GetObject("btnGetDiskFreeSpaceEx.Font");

        this.btnGetDiskFreeSpaceEx.Image = (System.Drawing.Image) resources.GetObject("btnGetDiskFreeSpaceEx.Image");

        this.btnGetDiskFreeSpaceEx.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetDiskFreeSpaceEx.ImageAlign");

        this.btnGetDiskFreeSpaceEx.ImageIndex = (int) resources.GetObject("btnGetDiskFreeSpaceEx.ImageIndex");

        this.btnGetDiskFreeSpaceEx.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGetDiskFreeSpaceEx.ImeMode");

        this.btnGetDiskFreeSpaceEx.Location = (System.Drawing.Point) resources.GetObject("btnGetDiskFreeSpaceEx.Location");

        this.btnGetDiskFreeSpaceEx.Name = "btnGetDiskFreeSpaceEx";

        this.btnGetDiskFreeSpaceEx.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGetDiskFreeSpaceEx.RightToLeft");

        this.btnGetDiskFreeSpaceEx.Size = (System.Drawing.Size) resources.GetObject("btnGetDiskFreeSpaceEx.Size");

        this.btnGetDiskFreeSpaceEx.TabIndex = (int) resources.GetObject("btnGetDiskFreeSpaceEx.TabIndex");

        this.btnGetDiskFreeSpaceEx.Text = resources.GetString("btnGetDiskFreeSpaceEx.Text");

        this.btnGetDiskFreeSpaceEx.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetDiskFreeSpaceEx.TextAlign");

        this.btnGetDiskFreeSpaceEx.Visible = (bool) resources.GetObject("btnGetDiskFreeSpaceEx.Visible");

		this.btnGetDiskFreeSpaceEx.Click += new EventHandler(btnGetDiskFreeSpaceEx_Click);

        //

        //btnGetFreeSpace

        //

        this.btnGetFreeSpace.AccessibleDescription = resources.GetString("btnGetFreeSpace.AccessibleDescription");

        this.btnGetFreeSpace.AccessibleName = resources.GetString("btnGetFreeSpace.AccessibleName");

        this.btnGetFreeSpace.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGetFreeSpace.Anchor");

        this.btnGetFreeSpace.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGetFreeSpace.BackgroundImage");

        this.btnGetFreeSpace.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGetFreeSpace.Dock");

        this.btnGetFreeSpace.Enabled = (bool) resources.GetObject("btnGetFreeSpace.Enabled");

        this.btnGetFreeSpace.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGetFreeSpace.FlatStyle");

        this.btnGetFreeSpace.Font = (System.Drawing.Font) resources.GetObject("btnGetFreeSpace.Font");

        this.btnGetFreeSpace.Image = (System.Drawing.Image) resources.GetObject("btnGetFreeSpace.Image");

        this.btnGetFreeSpace.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetFreeSpace.ImageAlign");

        this.btnGetFreeSpace.ImageIndex = (int) resources.GetObject("btnGetFreeSpace.ImageIndex");

        this.btnGetFreeSpace.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGetFreeSpace.ImeMode");

        this.btnGetFreeSpace.Location = (System.Drawing.Point) resources.GetObject("btnGetFreeSpace.Location");

        this.btnGetFreeSpace.Name = "btnGetFreeSpace";

        this.btnGetFreeSpace.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGetFreeSpace.RightToLeft");

        this.btnGetFreeSpace.Size = (System.Drawing.Size) resources.GetObject("btnGetFreeSpace.Size");

        this.btnGetFreeSpace.TabIndex = (int) resources.GetObject("btnGetFreeSpace.TabIndex");

        this.btnGetFreeSpace.Text = resources.GetString("btnGetFreeSpace.Text");

        this.btnGetFreeSpace.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetFreeSpace.TextAlign");

        this.btnGetFreeSpace.Visible = (bool) resources.GetObject("btnGetFreeSpace.Visible");

		this.btnGetFreeSpace.Click += new EventHandler(btnGetFreeSpace_Click);

        //

        //txtFunctionOutput

        //

        this.txtFunctionOutput.AccessibleDescription = resources.GetString("txtFunctionOutput.AccessibleDescription");

        this.txtFunctionOutput.AccessibleName = resources.GetString("txtFunctionOutput.AccessibleName");

        this.txtFunctionOutput.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtFunctionOutput.Anchor");

        this.txtFunctionOutput.AutoSize = (bool) resources.GetObject("txtFunctionOutput.AutoSize");

        this.txtFunctionOutput.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtFunctionOutput.BackgroundImage");

        this.txtFunctionOutput.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtFunctionOutput.Dock");

        this.txtFunctionOutput.Enabled = (bool) resources.GetObject("txtFunctionOutput.Enabled");

        this.txtFunctionOutput.Font = (System.Drawing.Font) resources.GetObject("txtFunctionOutput.Font");

        this.txtFunctionOutput.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtFunctionOutput.ImeMode");

        this.txtFunctionOutput.Location = (System.Drawing.Point) resources.GetObject("txtFunctionOutput.Location");

        this.txtFunctionOutput.MaxLength = (int) resources.GetObject("txtFunctionOutput.MaxLength");

        this.txtFunctionOutput.Multiline = (bool) resources.GetObject("txtFunctionOutput.Multiline");

        this.txtFunctionOutput.Name = "txtFunctionOutput";

        this.txtFunctionOutput.PasswordChar = (char) resources.GetObject("txtFunctionOutput.PasswordChar");

        this.txtFunctionOutput.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtFunctionOutput.RightToLeft");

        this.txtFunctionOutput.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtFunctionOutput.ScrollBars");

        this.txtFunctionOutput.Size = (System.Drawing.Size) resources.GetObject("txtFunctionOutput.Size");

        this.txtFunctionOutput.TabIndex = (int) resources.GetObject("txtFunctionOutput.TabIndex");

        this.txtFunctionOutput.Text = resources.GetString("txtFunctionOutput.Text");

        this.txtFunctionOutput.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtFunctionOutput.TextAlign");

        this.txtFunctionOutput.Visible = (bool) resources.GetObject("txtFunctionOutput.Visible");

        this.txtFunctionOutput.WordWrap = (bool) resources.GetObject("txtFunctionOutput.WordWrap");

        //

        //MiscGroupBox

        //

        this.MiscGroupBox.AccessibleDescription = (string) resources.GetObject("MiscGroupBox.AccessibleDescription");

        this.MiscGroupBox.AccessibleName = (string) resources.GetObject("MiscGroupBox.AccessibleName");

        this.MiscGroupBox.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("MiscGroupBox.Anchor");

        this.MiscGroupBox.BackgroundImage = (System.Drawing.Image) resources.GetObject("MiscGroupBox.BackgroundImage");

        this.MiscGroupBox.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnHibernate, this.btnGetOSVersion});

        this.MiscGroupBox.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("MiscGroupBox.Dock");

        this.MiscGroupBox.Enabled = (bool) resources.GetObject("MiscGroupBox.Enabled");

        this.MiscGroupBox.Font = (System.Drawing.Font) resources.GetObject("MiscGroupBox.Font");

        this.MiscGroupBox.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("MiscGroupBox.ImeMode");

        this.MiscGroupBox.Location = (System.Drawing.Point) resources.GetObject("MiscGroupBox.Location");

        this.MiscGroupBox.Name = "MiscGroupBox";

        this.MiscGroupBox.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("MiscGroupBox.RightToLeft");

        this.MiscGroupBox.Size = (System.Drawing.Size) resources.GetObject("MiscGroupBox.Size");

        this.MiscGroupBox.TabIndex = (int) resources.GetObject("MiscGroupBox.TabIndex");

        this.MiscGroupBox.TabStop = false;

        this.MiscGroupBox.Text = resources.GetString("MiscGroupBox.Text");

        this.MiscGroupBox.Visible = (bool) resources.GetObject("MiscGroupBox.Visible");

        //

        //btnHibernate

        //

        this.btnHibernate.AccessibleDescription = resources.GetString("btnHibernate.AccessibleDescription");

        this.btnHibernate.AccessibleName = resources.GetString("btnHibernate.AccessibleName");

        this.btnHibernate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnHibernate.Anchor");

        this.btnHibernate.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnHibernate.BackgroundImage");

        this.btnHibernate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnHibernate.Dock");

        this.btnHibernate.Enabled = (bool) resources.GetObject("btnHibernate.Enabled");

        this.btnHibernate.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnHibernate.FlatStyle");

        this.btnHibernate.Font = (System.Drawing.Font) resources.GetObject("btnHibernate.Font");

        this.btnHibernate.Image = (System.Drawing.Image) resources.GetObject("btnHibernate.Image");

        this.btnHibernate.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnHibernate.ImageAlign");

        this.btnHibernate.ImageIndex = (int) resources.GetObject("btnHibernate.ImageIndex");

        this.btnHibernate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnHibernate.ImeMode");

        this.btnHibernate.Location = (System.Drawing.Point) resources.GetObject("btnHibernate.Location");

        this.btnHibernate.Name = "btnHibernate";

        this.btnHibernate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnHibernate.RightToLeft");

        this.btnHibernate.Size = (System.Drawing.Size) resources.GetObject("btnHibernate.Size");

        this.btnHibernate.TabIndex = (int) resources.GetObject("btnHibernate.TabIndex");

        this.btnHibernate.Text = resources.GetString("btnHibernate.Text");

        this.btnHibernate.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnHibernate.TextAlign");

        this.btnHibernate.Visible = (bool) resources.GetObject("btnHibernate.Visible");

		this.btnHibernate.Click += new EventHandler(btnHibernate_Click);

        //

        //btnGetOSVersion

        //

        this.btnGetOSVersion.AccessibleDescription = resources.GetString("btnGetOSVersion.AccessibleDescription");

        this.btnGetOSVersion.AccessibleName = resources.GetString("btnGetOSVersion.AccessibleName");

        this.btnGetOSVersion.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnGetOSVersion.Anchor");

        this.btnGetOSVersion.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnGetOSVersion.BackgroundImage");

        this.btnGetOSVersion.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnGetOSVersion.Dock");

        this.btnGetOSVersion.Enabled = (bool) resources.GetObject("btnGetOSVersion.Enabled");

        this.btnGetOSVersion.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnGetOSVersion.FlatStyle");

        this.btnGetOSVersion.Font = (System.Drawing.Font) resources.GetObject("btnGetOSVersion.Font");

        this.btnGetOSVersion.Image = (System.Drawing.Image) resources.GetObject("btnGetOSVersion.Image");

        this.btnGetOSVersion.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetOSVersion.ImageAlign");

        this.btnGetOSVersion.ImageIndex = (int) resources.GetObject("btnGetOSVersion.ImageIndex");

        this.btnGetOSVersion.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnGetOSVersion.ImeMode");

        this.btnGetOSVersion.Location = (System.Drawing.Point) resources.GetObject("btnGetOSVersion.Location");

        this.btnGetOSVersion.Name = "btnGetOSVersion";

        this.btnGetOSVersion.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnGetOSVersion.RightToLeft");

        this.btnGetOSVersion.Size = (System.Drawing.Size) resources.GetObject("btnGetOSVersion.Size");

        this.btnGetOSVersion.TabIndex = (int) resources.GetObject("btnGetOSVersion.TabIndex");

        this.btnGetOSVersion.Text = resources.GetString("btnGetOSVersion.Text");

        this.btnGetOSVersion.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnGetOSVersion.TextAlign");

        this.btnGetOSVersion.Visible = (bool) resources.GetObject("btnGetOSVersion.Visible");

		this.btnGetOSVersion.Click += new EventHandler(btnGetOSVersion_Click);

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

        this.tpActiveProcesses.ResumeLayout(false);

        this.tpActiveWindows.ResumeLayout(false);

        this.tpShowWindow.ResumeLayout(false);

        this.tpAPICalls.ResumeLayout(false);

        this.CallingVariationGroupBox.ResumeLayout(false);

        this.DirectoryGroupBox.ResumeLayout(false);

        this.MouseGroupBox.ResumeLayout(false);

        this.DriveGroupBox.ResumeLayout(false);

        this.MiscGroupBox.ResumeLayout(false);

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

#region "API Calls";

    // This demonstrates the different calling variations using the function Beep.  Check
    // The declarations in class CallingVariations.
    private void btnBeep_Click(object sender, System.EventArgs e) 
	{
        if (rbDeclare.Checked)
		{
            CallingVariations.DeclareBeep(1000, 1000);
        } 
		else if ( rbDLLImport.Checked) 
		{
            CallingVariations.DLLImportBeep(1000, 1000);
        }
		else if ( rbANSI.Checked) 
		{
            CallingVariations.ANSIBeep(1000, 1000);
        }
		else if ( rbUnicode.Checked)
		{
            CallingVariations.UnicodeBeep(1000, 1000);
        }
		else if ( rbAuto.Checked)
		{
            CallingVariations.AutoBeep(1000, 1000);
        }
    }

    // This creates a directory if possible, and updates the status in the function 
    // output text box.
    private void btnCreateDirectory_Click(object sender, System.EventArgs e) 
	{
        Win32API.SECURITY_ATTRIBUTES security = new Win32API.SECURITY_ATTRIBUTES();

		if (Win32API.CreateDirectory(txtDirectory.Text, security))
		{
			txtFunctionOutput.Text = "Directory created.";
		}
		else 
		{
			txtFunctionOutput.Text = "Directory not created.";
		}
    }

    // This gets the number of free clusters on a disk, by Win32 API call GetDiskFreeSpace
    // and updates the function output textbox.
    private void btnGetFreeSpace_Click(object sender, System.EventArgs e) 
	{
        string rootPathName = "";
        int sectorsPerCluster = 0;
        int bytesPerSector = 0;
        int numberOfFreeClusters = 0;
        int totalNumberOfClusters = 0;

        rootPathName = txtDriveLetter.Text + ":\\";

        Win32API.GetDiskFreeSpace(rootPathName,ref sectorsPerCluster,ref bytesPerSector,
            ref numberOfFreeClusters,ref totalNumberOfClusters);

        txtFunctionOutput.Text = "Number of Free Clusters: " + 
            numberOfFreeClusters.ToString();
    }

    // This gets the number of free bytes on a disk, by Win32 API call GetDiskFreeSpaceEx
    // and updates the function output textbox.
    private void btnGetDiskFreeSpaceEx_Click(object sender, System.EventArgs e) 
	{
        string rootPathName = "";
        int freeBytesToCaller = 0;
        int totalNumberOfBytes = 0;
        UInt32 totalNumberOfFreeBytes = 0;

        rootPathName = txtDriveLetter.Text + ":\\";

        Win32API.GetDiskFreeSpaceEx(rootPathName,ref freeBytesToCaller,ref totalNumberOfBytes,
            ref totalNumberOfFreeBytes);

        txtFunctionOutput.Text = "Number of Free Bytes: " +
            totalNumberOfFreeBytes.ToString();
    }

    // This shows the drive type by Win32 API call GetDriveTypeand updates the function
    // output textbox.
    private void btnGetDriveType_Click(object sender, System.EventArgs e) 
	{
        string rootPathName;
        rootPathName = txtDriveLetter.Text + ":\\";

		switch( Win32API.GetDriveType(rootPathName))
		{
			case 2:
				txtFunctionOutput.Text = "Drive type: Removable";
				break;
			case 3:
				txtFunctionOutput.Text = "Drive type: Fixed";
				break;
			case 4:
				txtFunctionOutput.Text = "Drive type: Remote";
				break;
			case 5:
				txtFunctionOutput.Text = "Drive type: Cd-Rom";
				break;
			case 6:
				txtFunctionOutput.Text = "Drive type: Ram disk";
				break;
			default: 
				txtFunctionOutput.Text = "Drive type: Unrecognized";
				break;
		}
    }

    // This gets the Operating system version and updates the function output text box. 
    private void btnGetOSVersion_Click(object sender, System.EventArgs e)
	{
        Win32API.OSVersionInfo versionInfo = new Win32API.OSVersionInfo();
        //This is being passed into the struct so it knows the size
        versionInfo.OSVersionInfoSize = Marshal.SizeOf(versionInfo);
        Win32API.GetVersionEx(ref versionInfo);
        txtFunctionOutput.Text = "Build Number is: " + versionInfo.buildNumber.ToString() + (char) 13 + (char) 10;
        txtFunctionOutput.Text += "Major Version Number is: " + versionInfo.majorVersion.ToString();
    }

    // This suspends the computer if it is possible.
    private void btnHibernate_Click(object sender, System.EventArgs e)
	{
		if (Win32API.IsPwrHibernateAllowed() != 0)
		{
			Win32API.SetSuspendState(1, 0, 0);
		}
		else 
		{
			txtFunctionOutput.Text = "Your computer doesn't support hibernation.  " + 
			"This may be due to system settings or simply a computer bios that does not support hibernation.";
		}
    }

    // Sets the mouse buttons they should be.
    private void btnResetMouseButton_Click(object sender, System.EventArgs e) 
	{
        Win32API.SwapMouseButton(0);
    }

    // Swaps the mouse buttons.
    private void btnSwapMouseButton_Click(object sender, System.EventArgs e)
	{
        Win32API.SwapMouseButton(1);
    }

#endregion

    //  This subroutine clears the process list view and fills it with all active processes.
    private void btnRefreshActiveProcesses_Click(object sender, System.EventArgs e) 
	{
        lvwProcessList.Items.Clear();
        // Call WinAPI function EnumWindows, specifying FillActiveProcessList function as
        // the function to be called once per active process.  Since EnumWindows is 
        // unmanaged code, it is necessary to create a delegate to allow it to call 
        // FillActiveProcessList which is managed code.
		Win32API.EnumWindows(new Win32API.EnumWindowsCallback(FillActiveProcessList), 0);
    }

    // This subroutine clears the active windows list and fills it with all active windows.
    private void btnRefreshActiveWindows_Click(object sender, System.EventArgs e) 
	{
        lbActiveWindows.Items.Clear();
        // EnumWindowDllImport works the same in btnRefreshActiveProcesses_Click, 
        // however, it is defined using DllImport instead of Declare.
        Win32API.EnumWindowsDllImport(new Win32API.EnumWindowsCallback(FillActiveWindowsList), 0);
    }

    // This void finds an active window based on the values in the window caption and class 
    // name text boxes, and brings it to the foreground.
    private void btnShow_Click(object sender, System.EventArgs e) 
	{
        int hWnd;
        // There are four overloads for the Win32API function FindWindow in the Win32API 
        // class, allowing either a string or an int to be passed to the class name 
        // and window name.  if either of the fields are blank, passing a 0 to the 
        // parameter marshalls NULL to the function call.

		if ((txtWindowCaption.Text == "") && (txtClassName.Text == "" ))
		{
			// FindWindowAny takes to int parameters and finds any available window.
			hWnd = Win32API.FindWindowAny(0, 0);
		} 
		else if ( (txtWindowCaption.Text == "") && (txtClassName.Text != ""))
		{
			// FindWindowNullWindowCaption attempts to locate a window by class name alone.
			hWnd = Win32API.FindWindowNullWindowCaption(txtClassName.Text, 0);

		} 
		else if ((txtWindowCaption.Text != "") && (txtClassName.Text == "")) 
		{
			// FindWindowNullClassName attempts to locate a window by window name alone. 
			hWnd = Win32API.FindWindowNullClassName(0, txtWindowCaption.Text);
		}
		else 
		{
			// FindWindow searches for a window by class name and window name.
			hWnd = Win32API.FindWindow(txtClassName.Text, txtWindowCaption.Text);
		}
        // if the window isn't found FindWindow sets the windows handle to 0.  if the 
        // handle is 0 display an error message, otherwise bring window to foreground.
		if (hWnd == 0)
		{
			MessageBox.Show("Specified window is not running.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else 
		{
			// Set the window foreground.
			Win32API.SetForegroundWindow(hWnd);
			// if window is minimized, simply restore, otherwise show it.  Notice the 
			// declaration of Win32API.IsIconic defines the return value bool
			// allowing .NET to marshall the integer value to a bool.

			if (Win32API.IsIconic(hWnd)) 
			{
				Win32API.ShowWindow(hWnd, Win32API.SW_RESTORE);
			}
			else 
			{
				Win32API.ShowWindow(hWnd, Win32API.SW_SHOW);
			}
		}
	}

    // This void checks the window caption and class name text boxes and updates 
    // lblFunctionCalled label accordingly.  
    private void ChangeFunctionCalledLabel()
	{
		if ((txtWindowCaption.Text == "") && (txtClassName.Text == ""))
		{
			lblFunctionCalled.Text = 
				"FindWindow (ClassName int, WindowName int) will be called.";
		}
		else if ((txtWindowCaption.Text == "") && (txtClassName.Text != ""))
		{
			lblFunctionCalled.Text = 
				"FindWindow (ClassName string, WindowName int) will be called.";
		} 
		else if ((txtWindowCaption.Text != "") && (txtClassName.Text == "")) 
		{
			lblFunctionCalled.Text = 
				"FindWindow (ClassName int, WindowName string) will be called.";
		}
		else 
		{
			lblFunctionCalled.Text = 
			"FindWindow (ClassName string, WindowName string) will be called.";
		}
    }

    // This function is called once for each active process by EnumWindows.  It gets the
    // Window caption and class name and updates the process item listview.
    bool FillActiveProcessList(int hWnd, int lParam) 
	{
        StringBuilder windowText = new StringBuilder(STRING_BUFFER_LENGTH);
        StringBuilder className = new StringBuilder(STRING_BUFFER_LENGTH);
        // Get the Window Caption and class Name.  Notice that the definition of Win32API
        // functions in the Win32API class are declared differently than in VB6.  All Longs
        // have been replaced with ints, and strings by stringBuilders.
        Win32API.GetWindowText(hWnd, windowText, STRING_BUFFER_LENGTH);
        Win32API.GetClassName(hWnd, className, STRING_BUFFER_LENGTH);
        // Add a new process item to the Processes list view.
        ListViewItem processItem = new ListViewItem(windowText.ToString(), 0);
        processItem.SubItems.Add(className.ToString());
        processItem.SubItems.Add(hWnd.ToString());
        lvwProcessList.Items.Add(processItem);
        return true;
    }

    // This function is called once for each active process by EnumWindows.  
    // It calls ProcessIsActiveWindow to verify that it is a valid window, and
    // updates the active window listbox.
    bool FillActiveWindowsList(int hWnd, int lParam)
	{
        StringBuilder windowText = new StringBuilder(STRING_BUFFER_LENGTH);
        // Get the Window Caption.
        Win32API.GetWindowText(hWnd, windowText, STRING_BUFFER_LENGTH);
        // Only add valid windows to the active windows listbox.

        if (ProcessIsActiveWindow(hWnd)) 
		{
            lbActiveWindows.Items.Add(windowText);
        }
        return true;
    }

    // This function calls various Win32API functions to determine if a windows process
    // is a valid active window..

    bool ProcessIsActiveWindow(int hWnd)
	{
        StringBuilder windowText = new StringBuilder(STRING_BUFFER_LENGTH);
        bool windowIsOwned;
        int windowStyle;
        // Get the windows caption, owner information, and window style.
        Win32API.GetWindowText(hWnd, windowText, STRING_BUFFER_LENGTH);
        windowIsOwned = Win32API.GetWindow(hWnd, Win32API.GW_OWNER) != 0;
        windowStyle = Win32API.GetWindowLong(hWnd, Win32API.GWL_EXSTYLE);
        // Do not allow invisible processes.  
        if (! Win32API.IsWindowVisible(hWnd)) 
		{
            return false;
        }
        // Window must have a caption
        if (windowText.ToString().Equals(""))
		{
            return false;
        }
        // Should not have a parent
        if (Win32API.GetParent(hWnd) != 0)
		{
            return false;
        }
        // Don't allow unowned tool tips
        if ((windowStyle != 0) && (Win32API.WS_EX_TOOLWINDOW != 0) && (! windowIsOwned ))
		{
            return false;
        }
        // Don't allow applications with owners
        if ((windowStyle != 0) && (Win32API.WS_EX_APPWINDOW == 0) && windowIsOwned)
		{
            return false;
        }
        // All criteria were met, window is a valid active window.
        return true;
    }

    // When txtClassName changes, update the lblFunctionCalled label to show which 
    // function will be called.
    private void txtClassName_TextChanged(object sender, System.EventArgs e) 
	{
        ChangeFunctionCalledLabel();
    }

    // When txtWindowCaption changes, update the lblFunctionCalled label to show which 
    // function will be called.
    private void txtWindowCaption_TextChanged(object sender, System.EventArgs e) 
	{
        ChangeFunctionCalledLabel();
    }
}

