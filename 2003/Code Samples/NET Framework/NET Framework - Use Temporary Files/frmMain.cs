//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Security;
using System.Windows.Forms;
using System.IO;

public class frmMain: System.Windows.Forms.Form 
{
    // Create a class variable to store the temporary file name
    string m_FileName = string.Empty;

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

	private System.Windows.Forms.Label lblTempDirectory;

    private System.Windows.Forms.Button btnFindTempDirectory;

    private System.Windows.Forms.TextBox txtTempDirectory;

    private System.Windows.Forms.StatusBar sbrStatus;

    private System.Windows.Forms.TextBox txtTempFile;

    private System.Windows.Forms.Button btnCreateTempFile;

    private System.Windows.Forms.Label lblTempFile;

    private System.Windows.Forms.Button btnUseTempFilebtnUseTempFile;

    private System.Windows.Forms.Button btnDeleteTempFile;

    private void InitializeComponent() 
	{
        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.lblTempDirectory = new System.Windows.Forms.Label();

        this.btnFindTempDirectory = new System.Windows.Forms.Button();

        this.txtTempDirectory = new System.Windows.Forms.TextBox();

        this.sbrStatus = new System.Windows.Forms.StatusBar();

        this.txtTempFile = new System.Windows.Forms.TextBox();

        this.btnCreateTempFile = new System.Windows.Forms.Button();

        this.lblTempFile = new System.Windows.Forms.Label();

        this.btnUseTempFilebtnUseTempFile = new System.Windows.Forms.Button();

        this.btnDeleteTempFile = new System.Windows.Forms.Button();

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

        //lblTempDirectory

        //

        this.lblTempDirectory.AccessibleDescription = resources.GetString("lblTempDirectory.AccessibleDescription");

        this.lblTempDirectory.AccessibleName = resources.GetString("lblTempDirectory.AccessibleName");

        this.lblTempDirectory.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblTempDirectory.Anchor");

        this.lblTempDirectory.AutoSize = (bool) resources.GetObject("lblTempDirectory.AutoSize");

        this.lblTempDirectory.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblTempDirectory.Dock");

        this.lblTempDirectory.Enabled = (bool) resources.GetObject("lblTempDirectory.Enabled");

        this.lblTempDirectory.Font = (System.Drawing.Font) resources.GetObject("lblTempDirectory.Font");

        this.lblTempDirectory.Image = (System.Drawing.Image) resources.GetObject("lblTempDirectory.Image");

        this.lblTempDirectory.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTempDirectory.ImageAlign");

        this.lblTempDirectory.ImageIndex = (int) resources.GetObject("lblTempDirectory.ImageIndex");

        this.lblTempDirectory.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblTempDirectory.ImeMode");

        this.lblTempDirectory.Location = (System.Drawing.Point) resources.GetObject("lblTempDirectory.Location");

        this.lblTempDirectory.Name = "lblTempDirectory";

        this.lblTempDirectory.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblTempDirectory.RightToLeft");

        this.lblTempDirectory.Size = (System.Drawing.Size) resources.GetObject("lblTempDirectory.Size");

        this.lblTempDirectory.TabIndex = (int) resources.GetObject("lblTempDirectory.TabIndex");

        this.lblTempDirectory.Text = resources.GetString("lblTempDirectory.Text");

        this.lblTempDirectory.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTempDirectory.TextAlign");

        this.lblTempDirectory.Visible = (bool) resources.GetObject("lblTempDirectory.Visible");

        //

        //btnFindTempDirectory

        //

        this.btnFindTempDirectory.AccessibleDescription = resources.GetString("btnFindTempDirectory.AccessibleDescription");

        this.btnFindTempDirectory.AccessibleName = resources.GetString("btnFindTempDirectory.AccessibleName");

        this.btnFindTempDirectory.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnFindTempDirectory.Anchor");

        this.btnFindTempDirectory.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnFindTempDirectory.BackgroundImage");

        this.btnFindTempDirectory.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnFindTempDirectory.Dock");

        this.btnFindTempDirectory.Enabled = (bool) resources.GetObject("btnFindTempDirectory.Enabled");

        this.btnFindTempDirectory.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnFindTempDirectory.FlatStyle");

        this.btnFindTempDirectory.Font = (System.Drawing.Font) resources.GetObject("btnFindTempDirectory.Font");

        this.btnFindTempDirectory.Image = (System.Drawing.Image) resources.GetObject("btnFindTempDirectory.Image");

        this.btnFindTempDirectory.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFindTempDirectory.ImageAlign");

        this.btnFindTempDirectory.ImageIndex = (int) resources.GetObject("btnFindTempDirectory.ImageIndex");

        this.btnFindTempDirectory.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnFindTempDirectory.ImeMode");

        this.btnFindTempDirectory.Location = (System.Drawing.Point) resources.GetObject("btnFindTempDirectory.Location");

        this.btnFindTempDirectory.Name = "btnFindTempDirectory";

        this.btnFindTempDirectory.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnFindTempDirectory.RightToLeft");

        this.btnFindTempDirectory.Size = (System.Drawing.Size) resources.GetObject("btnFindTempDirectory.Size");

        this.btnFindTempDirectory.TabIndex = (int) resources.GetObject("btnFindTempDirectory.TabIndex");

        this.btnFindTempDirectory.Text = resources.GetString("btnFindTempDirectory.Text");

        this.btnFindTempDirectory.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnFindTempDirectory.TextAlign");

        this.btnFindTempDirectory.Visible = (bool) resources.GetObject("btnFindTempDirectory.Visible");

        //

        //txtTempDirectory

        //

        this.txtTempDirectory.AccessibleDescription = resources.GetString("txtTempDirectory.AccessibleDescription");

        this.txtTempDirectory.AccessibleName = resources.GetString("txtTempDirectory.AccessibleName");

        this.txtTempDirectory.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtTempDirectory.Anchor");

        this.txtTempDirectory.AutoSize = (bool) resources.GetObject("txtTempDirectory.AutoSize");

        this.txtTempDirectory.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtTempDirectory.BackgroundImage");

        this.txtTempDirectory.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtTempDirectory.Dock");

        this.txtTempDirectory.Enabled = (bool) resources.GetObject("txtTempDirectory.Enabled");

        this.txtTempDirectory.Font = (System.Drawing.Font) resources.GetObject("txtTempDirectory.Font");

        this.txtTempDirectory.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtTempDirectory.ImeMode");

        this.txtTempDirectory.Location = (System.Drawing.Point) resources.GetObject("txtTempDirectory.Location");

        this.txtTempDirectory.MaxLength = (int) resources.GetObject("txtTempDirectory.MaxLength");

        this.txtTempDirectory.Multiline = (bool) resources.GetObject("txtTempDirectory.Multiline");

        this.txtTempDirectory.Name = "txtTempDirectory";

        this.txtTempDirectory.PasswordChar = (char) resources.GetObject("txtTempDirectory.PasswordChar");

        this.txtTempDirectory.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtTempDirectory.RightToLeft");

        this.txtTempDirectory.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtTempDirectory.ScrollBars");

        this.txtTempDirectory.Size = (System.Drawing.Size) resources.GetObject("txtTempDirectory.Size");

        this.txtTempDirectory.TabIndex = (int) resources.GetObject("txtTempDirectory.TabIndex");

        this.txtTempDirectory.TabStop = false;

        this.txtTempDirectory.Text = resources.GetString("txtTempDirectory.Text");

        this.txtTempDirectory.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtTempDirectory.TextAlign");

        this.txtTempDirectory.Visible = (bool) resources.GetObject("txtTempDirectory.Visible");

        this.txtTempDirectory.WordWrap = (bool) resources.GetObject("txtTempDirectory.WordWrap");

        //

        //sbrStatus

        //

        this.sbrStatus.AccessibleDescription = (string) resources.GetObject("sbrStatus.AccessibleDescription");

        this.sbrStatus.AccessibleName = (string) resources.GetObject("sbrStatus.AccessibleName");

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

        //txtTempFile

        //

        this.txtTempFile.AccessibleDescription = resources.GetString("txtTempFile.AccessibleDescription");

        this.txtTempFile.AccessibleName = resources.GetString("txtTempFile.AccessibleName");

        this.txtTempFile.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtTempFile.Anchor");

        this.txtTempFile.AutoSize = (bool) resources.GetObject("txtTempFile.AutoSize");

        this.txtTempFile.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtTempFile.BackgroundImage");

        this.txtTempFile.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtTempFile.Dock");

        this.txtTempFile.Enabled = (bool) resources.GetObject("txtTempFile.Enabled");

        this.txtTempFile.Font = (System.Drawing.Font) resources.GetObject("txtTempFile.Font");

        this.txtTempFile.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtTempFile.ImeMode");

        this.txtTempFile.Location = (System.Drawing.Point) resources.GetObject("txtTempFile.Location");

        this.txtTempFile.MaxLength = (int) resources.GetObject("txtTempFile.MaxLength");

        this.txtTempFile.Multiline = (bool) resources.GetObject("txtTempFile.Multiline");

        this.txtTempFile.Name = "txtTempFile";

        this.txtTempFile.PasswordChar = (char) resources.GetObject("txtTempFile.PasswordChar");

        this.txtTempFile.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtTempFile.RightToLeft");

        this.txtTempFile.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtTempFile.ScrollBars");

        this.txtTempFile.Size = (System.Drawing.Size) resources.GetObject("txtTempFile.Size");

        this.txtTempFile.TabIndex = (int) resources.GetObject("txtTempFile.TabIndex");

        this.txtTempFile.TabStop = false;

        this.txtTempFile.Text = resources.GetString("txtTempFile.Text");

        this.txtTempFile.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtTempFile.TextAlign");

        this.txtTempFile.Visible = (bool) resources.GetObject("txtTempFile.Visible");

        this.txtTempFile.WordWrap = (bool) resources.GetObject("txtTempFile.WordWrap");

        //

        //btnCreateTempFile

        //

        this.btnCreateTempFile.AccessibleDescription = resources.GetString("btnCreateTempFile.AccessibleDescription");

        this.btnCreateTempFile.AccessibleName = resources.GetString("btnCreateTempFile.AccessibleName");

        this.btnCreateTempFile.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateTempFile.Anchor");

        this.btnCreateTempFile.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateTempFile.BackgroundImage");

        this.btnCreateTempFile.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateTempFile.Dock");

        this.btnCreateTempFile.Enabled = (bool) resources.GetObject("btnCreateTempFile.Enabled");

        this.btnCreateTempFile.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateTempFile.FlatStyle");

        this.btnCreateTempFile.Font = (System.Drawing.Font) resources.GetObject("btnCreateTempFile.Font");

        this.btnCreateTempFile.Image = (System.Drawing.Image) resources.GetObject("btnCreateTempFile.Image");

        this.btnCreateTempFile.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateTempFile.ImageAlign");

        this.btnCreateTempFile.ImageIndex = (int) resources.GetObject("btnCreateTempFile.ImageIndex");

        this.btnCreateTempFile.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateTempFile.ImeMode");

        this.btnCreateTempFile.Location = (System.Drawing.Point) resources.GetObject("btnCreateTempFile.Location");

        this.btnCreateTempFile.Name = "btnCreateTempFile";

        this.btnCreateTempFile.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateTempFile.RightToLeft");

        this.btnCreateTempFile.Size = (System.Drawing.Size) resources.GetObject("btnCreateTempFile.Size");

        this.btnCreateTempFile.TabIndex = (int) resources.GetObject("btnCreateTempFile.TabIndex");

        this.btnCreateTempFile.Text = resources.GetString("btnCreateTempFile.Text");

        this.btnCreateTempFile.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateTempFile.TextAlign");

        this.btnCreateTempFile.Visible = (bool) resources.GetObject("btnCreateTempFile.Visible");

        //

        //lblTempFile

        //

        this.lblTempFile.AccessibleDescription = resources.GetString("lblTempFile.AccessibleDescription");

        this.lblTempFile.AccessibleName = resources.GetString("lblTempFile.AccessibleName");

        this.lblTempFile.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblTempFile.Anchor");

        this.lblTempFile.AutoSize = (bool) resources.GetObject("lblTempFile.AutoSize");

        this.lblTempFile.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblTempFile.Dock");

        this.lblTempFile.Enabled = (bool) resources.GetObject("lblTempFile.Enabled");

        this.lblTempFile.Font = (System.Drawing.Font) resources.GetObject("lblTempFile.Font");

        this.lblTempFile.Image = (System.Drawing.Image) resources.GetObject("lblTempFile.Image");

        this.lblTempFile.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTempFile.ImageAlign");

        this.lblTempFile.ImageIndex = (int) resources.GetObject("lblTempFile.ImageIndex");

        this.lblTempFile.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblTempFile.ImeMode");

        this.lblTempFile.Location = (System.Drawing.Point) resources.GetObject("lblTempFile.Location");

        this.lblTempFile.Name = "lblTempFile";

        this.lblTempFile.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblTempFile.RightToLeft");

        this.lblTempFile.Size = (System.Drawing.Size) resources.GetObject("lblTempFile.Size");

        this.lblTempFile.TabIndex = (int) resources.GetObject("lblTempFile.TabIndex");

        this.lblTempFile.Text = resources.GetString("lblTempFile.Text");

        this.lblTempFile.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTempFile.TextAlign");

        this.lblTempFile.Visible = (bool) resources.GetObject("lblTempFile.Visible");

        //

        //btnUseTempFilebtnUseTempFile

        //

        this.btnUseTempFilebtnUseTempFile.AccessibleDescription = resources.GetString("btnUseTempFilebtnUseTempFile.AccessibleDescription");

        this.btnUseTempFilebtnUseTempFile.AccessibleName = resources.GetString("btnUseTempFilebtnUseTempFile.AccessibleName");

        this.btnUseTempFilebtnUseTempFile.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnUseTempFilebtnUseTempFile.Anchor");

        this.btnUseTempFilebtnUseTempFile.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnUseTempFilebtnUseTempFile.BackgroundImage");

        this.btnUseTempFilebtnUseTempFile.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnUseTempFilebtnUseTempFile.Dock");

        this.btnUseTempFilebtnUseTempFile.Enabled = (bool) resources.GetObject("btnUseTempFilebtnUseTempFile.Enabled");

        this.btnUseTempFilebtnUseTempFile.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnUseTempFilebtnUseTempFile.FlatStyle");

        this.btnUseTempFilebtnUseTempFile.Font = (System.Drawing.Font) resources.GetObject("btnUseTempFilebtnUseTempFile.Font");

        this.btnUseTempFilebtnUseTempFile.Image = (System.Drawing.Image) resources.GetObject("btnUseTempFilebtnUseTempFile.Image");

        this.btnUseTempFilebtnUseTempFile.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUseTempFilebtnUseTempFile.ImageAlign");

        this.btnUseTempFilebtnUseTempFile.ImageIndex = (int) resources.GetObject("btnUseTempFilebtnUseTempFile.ImageIndex");

        this.btnUseTempFilebtnUseTempFile.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnUseTempFilebtnUseTempFile.ImeMode");

        this.btnUseTempFilebtnUseTempFile.Location = (System.Drawing.Point) resources.GetObject("btnUseTempFilebtnUseTempFile.Location");

        this.btnUseTempFilebtnUseTempFile.Name = "btnUseTempFilebtnUseTempFile";

        this.btnUseTempFilebtnUseTempFile.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnUseTempFilebtnUseTempFile.RightToLeft");

        this.btnUseTempFilebtnUseTempFile.Size = (System.Drawing.Size) resources.GetObject("btnUseTempFilebtnUseTempFile.Size");

        this.btnUseTempFilebtnUseTempFile.TabIndex = (int) resources.GetObject("btnUseTempFilebtnUseTempFile.TabIndex");

        this.btnUseTempFilebtnUseTempFile.Text = resources.GetString("btnUseTempFilebtnUseTempFile.Text");

        this.btnUseTempFilebtnUseTempFile.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUseTempFilebtnUseTempFile.TextAlign");

        this.btnUseTempFilebtnUseTempFile.Visible = (bool) resources.GetObject("btnUseTempFilebtnUseTempFile.Visible");

        //

        //btnDeleteTempFile

        //

        this.btnDeleteTempFile.AccessibleDescription = resources.GetString("btnDeleteTempFile.AccessibleDescription");

        this.btnDeleteTempFile.AccessibleName = resources.GetString("btnDeleteTempFile.AccessibleName");

        this.btnDeleteTempFile.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnDeleteTempFile.Anchor");

        this.btnDeleteTempFile.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnDeleteTempFile.BackgroundImage");

        this.btnDeleteTempFile.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnDeleteTempFile.Dock");

        this.btnDeleteTempFile.Enabled = (bool) resources.GetObject("btnDeleteTempFile.Enabled");

        this.btnDeleteTempFile.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnDeleteTempFile.FlatStyle");

        this.btnDeleteTempFile.Font = (System.Drawing.Font) resources.GetObject("btnDeleteTempFile.Font");

        this.btnDeleteTempFile.Image = (System.Drawing.Image) resources.GetObject("btnDeleteTempFile.Image");

        this.btnDeleteTempFile.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDeleteTempFile.ImageAlign");

        this.btnDeleteTempFile.ImageIndex = (int) resources.GetObject("btnDeleteTempFile.ImageIndex");

        this.btnDeleteTempFile.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnDeleteTempFile.ImeMode");

        this.btnDeleteTempFile.Location = (System.Drawing.Point) resources.GetObject("btnDeleteTempFile.Location");

        this.btnDeleteTempFile.Name = "btnDeleteTempFile";

        this.btnDeleteTempFile.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnDeleteTempFile.RightToLeft");

        this.btnDeleteTempFile.Size = (System.Drawing.Size) resources.GetObject("btnDeleteTempFile.Size");

        this.btnDeleteTempFile.TabIndex = (int) resources.GetObject("btnDeleteTempFile.TabIndex");

        this.btnDeleteTempFile.Text = resources.GetString("btnDeleteTempFile.Text");

        this.btnDeleteTempFile.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDeleteTempFile.TextAlign");

        this.btnDeleteTempFile.Visible = (bool) resources.GetObject("btnDeleteTempFile.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnDeleteTempFile, this.btnUseTempFilebtnUseTempFile, this.txtTempFile, this.btnCreateTempFile, this.lblTempFile, this.sbrStatus, this.txtTempDirectory, this.btnFindTempDirectory, this.lblTempDirectory});

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
		this.btnCreateTempFile.Click += new EventHandler(btnCreateTempFile_Click);
		this.btnDeleteTempFile.Click += new EventHandler(btnDeleteTempFile_Click);
		this.btnFindTempDirectory.Click += new EventHandler(btnFindTempDirectory_Click);
		this.btnUseTempFilebtnUseTempFile.Click += new EventHandler(btnUseTempFilebtnUseTempFile_Click);
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
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

    // This subrouting Creates a Temporary file and sets its Attribute
    //   property to Temporary.
    private void btnCreateTempFile_Click(object sender, System.EventArgs e)
	{
        // Clear the Status Bar
        this.sbrStatus.Text = string.Empty;
        try 
		{
            // return the path and name of a newly created Temporary
            //   file. Note that the GetTempFileName() method actually creates
            //   a 0-byte file and returns the name of the created file.
            m_FileName = Path.GetTempFileName();

            // Craete a FileInfo object to manipulate properties of 
            //   the created temporary file
            FileInfo myFileInfo = new FileInfo(m_FileName);

            // Use the FileInfo object to set the Attribute property of this
            //   file to Temporary. Although this is not completely necessary, 
            //   the .NET Framework is able to optimize the use of Temporary
            //   files by keeping them cached in memory.
            // Inexplicably, the Attribute given to a file created with
            //   the GetTempFileName() method is Archive, which prevents the 
            //   .NET Framework from optimizing its use.
            myFileInfo.Attributes = FileAttributes.Temporary;
		} 
		catch(Exception exc)
		{
            // Warn the user if there is a problem
            this.sbrStatus.Text = "Unable to create a TEMP file or set its attributes: " + exc.Message;
        }

        // Display the Temporary Filename in the txtTempFile text box.
        this.txtTempFile.Text = m_FileName;
    }

    // This subrouting deletes the temporary file that was created earlier.
    private void btnDeleteTempFile_Click(object sender, System.EventArgs e) 
	{
        // Clear the Status Bar or show error if there is no current file
		if (m_FileName == string.Empty)
		{
			this.sbrStatus.Text = "Temp file not yet created.";
			return;
		}
        else 
		{
			this.sbrStatus.Text = string.Empty;
		}

        // Attempt to delete the file.
        try 
		{
            File.Delete(m_FileName);
            m_FileName = string.Empty;
            this.txtTempFile.Text = string.Empty;
		}
		catch(Exception exc)
		{
            // Show error to user.
            this.sbrStatus.Text = "Error deleteing Temp file: " + exc.Message;
        }
    }

    // This subroutine finds the path to the Temp directory
    //   on the local machine. It is ALWAYS important to wrap any Path
    //   method calls in a try-catch block since exceptions are thrown based
    //   on the permissions granted to the current user.
    private void btnFindTempDirectory_Click(object sender, System.EventArgs e) 
	{
        // Create outside of try {-Catch, and initialize to an empty string.
        string tempPathstring = string.Empty;

		// Clear the Status Bar.
        this.sbrStatus.Text = string.Empty;

        // Attempt to get the path to the Temp directory
        try 
		{
            tempPathstring = Path.GetTempPath();
		}
		catch(SecurityException sex)
		{
            // Show error to user, if they don't have the proper permissions
            this.sbrStatus.Text = "You do not have the required permissions.";

        }
		catch(Exception exc)
		{
            // Show error to user.
            this.sbrStatus.Text = "Unable to retrieve TEMP directory path.";
        }

        // Set txtTempDirectory equal to the Temp path.
        this.txtTempDirectory.Text = tempPathstring;
    }

    // This subroutine uses the temp file that was created earlier.
    private void btnUseTempFilebtnUseTempFile_Click(object sender, System.EventArgs e)
	{
        // Clear the Status Bar or show error if there is no current file
		if (m_FileName == string.Empty)
		{
			this.sbrStatus.Text = "Temp file not yet created.";
			return;
		}
		else 
		{
			this.sbrStatus.Text = string.Empty;
		}

        // Attempt to use the temporary file, by adding some text to it
        //   and reading the text back out.
        try 
		{
            // Write to the temp file.
            StreamWriter myWriter = File.AppendText(m_FileName);
            myWriter.WriteLine("Data written to temporary file.");
            myWriter.Flush();
            myWriter.Close();

			// Read from the temp file.
            StreamReader myReader = File.OpenText(m_FileName);

            // Show contents of temp file to user.
            this.sbrStatus.Text = "Temp file: " + myReader.ReadToEnd();
            myReader.Close();

		}
		catch(Exception exc)
		{
            // Show error to user.
            this.sbrStatus.Text = "Error writing to or reading from Temp file: " + exc.Message;
        }
    }
}