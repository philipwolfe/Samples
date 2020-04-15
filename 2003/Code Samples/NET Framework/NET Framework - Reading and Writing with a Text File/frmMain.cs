//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.IO;

public class frmMain: System.Windows.Forms.Form 
{
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

    private System.Windows.Forms.TextBox txtFileText;

    private System.Windows.Forms.Label lblFileText;

    private System.Windows.Forms.Label lblFileName;

    private System.Windows.Forms.TextBox txtFileName;

    private System.Windows.Forms.Button btnStreamWriterCreateFile;

    private System.Windows.Forms.Button btnStreamWriterAppendToFile;

    private System.Windows.Forms.Button btnStringReaderReadFileInLines;

    private System.Windows.Forms.Button btnStreamReaderReadFromFile;

    private System.Windows.Forms.SaveFileDialog sdlgFile;

    private System.Windows.Forms.Button btnNewFileName;

    private System.Windows.Forms.Button btnOpenFileName;

    private System.Windows.Forms.Button btnStreamReaderReadInChars;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.txtFileText = new System.Windows.Forms.TextBox();

        this.lblFileText = new System.Windows.Forms.Label();

        this.lblFileName = new System.Windows.Forms.Label();

        this.txtFileName = new System.Windows.Forms.TextBox();

        this.btnStreamWriterCreateFile = new System.Windows.Forms.Button();

        this.btnStreamWriterAppendToFile = new System.Windows.Forms.Button();

        this.btnStreamReaderReadFromFile = new System.Windows.Forms.Button();

        this.btnStringReaderReadFileInLines = new System.Windows.Forms.Button();

        this.sdlgFile = new System.Windows.Forms.SaveFileDialog();

        this.btnNewFileName = new System.Windows.Forms.Button();

        this.btnOpenFileName = new System.Windows.Forms.Button();

        this.btnStreamReaderReadInChars = new System.Windows.Forms.Button();

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

        //txtFileText

        //

        this.txtFileText.AccessibleDescription = resources.GetString("txtFileText.AccessibleDescription");

        this.txtFileText.AccessibleName = resources.GetString("txtFileText.AccessibleName");

        this.txtFileText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtFileText.Anchor");

        this.txtFileText.AutoSize = (bool) resources.GetObject("txtFileText.AutoSize");

        this.txtFileText.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtFileText.BackgroundImage");

        this.txtFileText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtFileText.Dock");

        this.txtFileText.Enabled = (bool) resources.GetObject("txtFileText.Enabled");

        this.txtFileText.Font = (System.Drawing.Font) resources.GetObject("txtFileText.Font");

        this.txtFileText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtFileText.ImeMode");

        this.txtFileText.Location = (System.Drawing.Point) resources.GetObject("txtFileText.Location");

        this.txtFileText.MaxLength = (int) resources.GetObject("txtFileText.MaxLength");

        this.txtFileText.Multiline = (bool) resources.GetObject("txtFileText.Multiline");

        this.txtFileText.Name = "txtFileText";

        this.txtFileText.PasswordChar = (char) resources.GetObject("txtFileText.PasswordChar");

        this.txtFileText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtFileText.RightToLeft");

        this.txtFileText.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtFileText.ScrollBars");

        this.txtFileText.Size = (System.Drawing.Size) resources.GetObject("txtFileText.Size");

        this.txtFileText.TabIndex = (int) resources.GetObject("txtFileText.TabIndex");

        this.txtFileText.Text = resources.GetString("txtFileText.Text");

        this.txtFileText.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtFileText.TextAlign");

        this.txtFileText.Visible = (bool) resources.GetObject("txtFileText.Visible");

        this.txtFileText.WordWrap = (bool) resources.GetObject("txtFileText.WordWrap");

        //

        //lblFileText

        //

        this.lblFileText.AccessibleDescription = resources.GetString("lblFileText.AccessibleDescription");

        this.lblFileText.AccessibleName = resources.GetString("lblFileText.AccessibleName");

        this.lblFileText.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblFileText.Anchor");

        this.lblFileText.AutoSize = (bool) resources.GetObject("lblFileText.AutoSize");

        this.lblFileText.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblFileText.Dock");

        this.lblFileText.Enabled = (bool) resources.GetObject("lblFileText.Enabled");

        this.lblFileText.Font = (System.Drawing.Font) resources.GetObject("lblFileText.Font");

        this.lblFileText.Image = (System.Drawing.Image) resources.GetObject("lblFileText.Image");

        this.lblFileText.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblFileText.ImageAlign");

        this.lblFileText.ImageIndex = (int) resources.GetObject("lblFileText.ImageIndex");

        this.lblFileText.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblFileText.ImeMode");

        this.lblFileText.Location = (System.Drawing.Point) resources.GetObject("lblFileText.Location");

        this.lblFileText.Name = "lblFileText";

        this.lblFileText.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblFileText.RightToLeft");

        this.lblFileText.Size = (System.Drawing.Size) resources.GetObject("lblFileText.Size");

        this.lblFileText.TabIndex = (int) resources.GetObject("lblFileText.TabIndex");

        this.lblFileText.Text = resources.GetString("lblFileText.Text");

        this.lblFileText.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblFileText.TextAlign");

        this.lblFileText.Visible = (bool) resources.GetObject("lblFileText.Visible");

        //

        //lblFileName

        //

        this.lblFileName.AccessibleDescription = resources.GetString("lblFileName.AccessibleDescription");

        this.lblFileName.AccessibleName = resources.GetString("lblFileName.AccessibleName");

        this.lblFileName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblFileName.Anchor");

        this.lblFileName.AutoSize = (bool) resources.GetObject("lblFileName.AutoSize");

        this.lblFileName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblFileName.Dock");

        this.lblFileName.Enabled = (bool) resources.GetObject("lblFileName.Enabled");

        this.lblFileName.Font = (System.Drawing.Font) resources.GetObject("lblFileName.Font");

        this.lblFileName.Image = (System.Drawing.Image) resources.GetObject("lblFileName.Image");

        this.lblFileName.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblFileName.ImageAlign");

        this.lblFileName.ImageIndex = (int) resources.GetObject("lblFileName.ImageIndex");

        this.lblFileName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblFileName.ImeMode");

        this.lblFileName.Location = (System.Drawing.Point) resources.GetObject("lblFileName.Location");

        this.lblFileName.Name = "lblFileName";

        this.lblFileName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblFileName.RightToLeft");

        this.lblFileName.Size = (System.Drawing.Size) resources.GetObject("lblFileName.Size");

        this.lblFileName.TabIndex = (int) resources.GetObject("lblFileName.TabIndex");

        this.lblFileName.Text = resources.GetString("lblFileName.Text");

        this.lblFileName.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblFileName.TextAlign");

        this.lblFileName.Visible = (bool) resources.GetObject("lblFileName.Visible");

        //

        //txtFileName

        //

        this.txtFileName.AccessibleDescription = resources.GetString("txtFileName.AccessibleDescription");

        this.txtFileName.AccessibleName = resources.GetString("txtFileName.AccessibleName");

        this.txtFileName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtFileName.Anchor");

        this.txtFileName.AutoSize = (bool) resources.GetObject("txtFileName.AutoSize");

        this.txtFileName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtFileName.BackgroundImage");

        this.txtFileName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtFileName.Dock");

        this.txtFileName.Enabled = (bool) resources.GetObject("txtFileName.Enabled");

        this.txtFileName.Font = (System.Drawing.Font) resources.GetObject("txtFileName.Font");

        this.txtFileName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtFileName.ImeMode");

        this.txtFileName.Location = (System.Drawing.Point) resources.GetObject("txtFileName.Location");

        this.txtFileName.MaxLength = (int) resources.GetObject("txtFileName.MaxLength");

        this.txtFileName.Multiline = (bool) resources.GetObject("txtFileName.Multiline");

        this.txtFileName.Name = "txtFileName";

        this.txtFileName.PasswordChar = (char) resources.GetObject("txtFileName.PasswordChar");

        this.txtFileName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtFileName.RightToLeft");

        this.txtFileName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtFileName.ScrollBars");

        this.txtFileName.Size = (System.Drawing.Size) resources.GetObject("txtFileName.Size");

        this.txtFileName.TabIndex = (int) resources.GetObject("txtFileName.TabIndex");

        this.txtFileName.Text = resources.GetString("txtFileName.Text");

        this.txtFileName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtFileName.TextAlign");

        this.txtFileName.Visible = (bool) resources.GetObject("txtFileName.Visible");

        this.txtFileName.WordWrap = (bool) resources.GetObject("txtFileName.WordWrap");

        //

        //btnStreamWriterCreateFile

        //

        this.btnStreamWriterCreateFile.AccessibleDescription = resources.GetString("btnStreamWriterCreateFile.AccessibleDescription");

        this.btnStreamWriterCreateFile.AccessibleName = resources.GetString("btnStreamWriterCreateFile.AccessibleName");

        this.btnStreamWriterCreateFile.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnStreamWriterCreateFile.Anchor");

        this.btnStreamWriterCreateFile.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnStreamWriterCreateFile.BackgroundImage");

        this.btnStreamWriterCreateFile.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnStreamWriterCreateFile.Dock");

        this.btnStreamWriterCreateFile.Enabled = (bool) resources.GetObject("btnStreamWriterCreateFile.Enabled");

        this.btnStreamWriterCreateFile.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnStreamWriterCreateFile.FlatStyle");

        this.btnStreamWriterCreateFile.Font = (System.Drawing.Font) resources.GetObject("btnStreamWriterCreateFile.Font");

        this.btnStreamWriterCreateFile.Image = (System.Drawing.Image) resources.GetObject("btnStreamWriterCreateFile.Image");

        this.btnStreamWriterCreateFile.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStreamWriterCreateFile.ImageAlign");

        this.btnStreamWriterCreateFile.ImageIndex = (int) resources.GetObject("btnStreamWriterCreateFile.ImageIndex");

        this.btnStreamWriterCreateFile.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnStreamWriterCreateFile.ImeMode");

        this.btnStreamWriterCreateFile.Location = (System.Drawing.Point) resources.GetObject("btnStreamWriterCreateFile.Location");

        this.btnStreamWriterCreateFile.Name = "btnStreamWriterCreateFile";

        this.btnStreamWriterCreateFile.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnStreamWriterCreateFile.RightToLeft");

        this.btnStreamWriterCreateFile.Size = (System.Drawing.Size) resources.GetObject("btnStreamWriterCreateFile.Size");

        this.btnStreamWriterCreateFile.TabIndex = (int) resources.GetObject("btnStreamWriterCreateFile.TabIndex");

        this.btnStreamWriterCreateFile.Text = resources.GetString("btnStreamWriterCreateFile.Text");

        this.btnStreamWriterCreateFile.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStreamWriterCreateFile.TextAlign");

        this.btnStreamWriterCreateFile.Visible = (bool) resources.GetObject("btnStreamWriterCreateFile.Visible");

        //

        //btnStreamWriterAppendToFile

        //

        this.btnStreamWriterAppendToFile.AccessibleDescription = resources.GetString("btnStreamWriterAppendToFile.AccessibleDescription");

        this.btnStreamWriterAppendToFile.AccessibleName = resources.GetString("btnStreamWriterAppendToFile.AccessibleName");

        this.btnStreamWriterAppendToFile.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnStreamWriterAppendToFile.Anchor");

        this.btnStreamWriterAppendToFile.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnStreamWriterAppendToFile.BackgroundImage");

        this.btnStreamWriterAppendToFile.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnStreamWriterAppendToFile.Dock");

        this.btnStreamWriterAppendToFile.Enabled = (bool) resources.GetObject("btnStreamWriterAppendToFile.Enabled");

        this.btnStreamWriterAppendToFile.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnStreamWriterAppendToFile.FlatStyle");

        this.btnStreamWriterAppendToFile.Font = (System.Drawing.Font) resources.GetObject("btnStreamWriterAppendToFile.Font");

        this.btnStreamWriterAppendToFile.Image = (System.Drawing.Image) resources.GetObject("btnStreamWriterAppendToFile.Image");

        this.btnStreamWriterAppendToFile.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStreamWriterAppendToFile.ImageAlign");

        this.btnStreamWriterAppendToFile.ImageIndex = (int) resources.GetObject("btnStreamWriterAppendToFile.ImageIndex");

        this.btnStreamWriterAppendToFile.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnStreamWriterAppendToFile.ImeMode");

        this.btnStreamWriterAppendToFile.Location = (System.Drawing.Point) resources.GetObject("btnStreamWriterAppendToFile.Location");

        this.btnStreamWriterAppendToFile.Name = "btnStreamWriterAppendToFile";

        this.btnStreamWriterAppendToFile.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnStreamWriterAppendToFile.RightToLeft");

        this.btnStreamWriterAppendToFile.Size = (System.Drawing.Size) resources.GetObject("btnStreamWriterAppendToFile.Size");

        this.btnStreamWriterAppendToFile.TabIndex = (int) resources.GetObject("btnStreamWriterAppendToFile.TabIndex");

        this.btnStreamWriterAppendToFile.Text = resources.GetString("btnStreamWriterAppendToFile.Text");

        this.btnStreamWriterAppendToFile.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStreamWriterAppendToFile.TextAlign");

        this.btnStreamWriterAppendToFile.Visible = (bool) resources.GetObject("btnStreamWriterAppendToFile.Visible");

        //

        //btnStreamReaderReadFromFile

        //

        this.btnStreamReaderReadFromFile.AccessibleDescription = resources.GetString("btnStreamReaderReadFromFile.AccessibleDescription");

        this.btnStreamReaderReadFromFile.AccessibleName = resources.GetString("btnStreamReaderReadFromFile.AccessibleName");

        this.btnStreamReaderReadFromFile.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnStreamReaderReadFromFile.Anchor");

        this.btnStreamReaderReadFromFile.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnStreamReaderReadFromFile.BackgroundImage");

        this.btnStreamReaderReadFromFile.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnStreamReaderReadFromFile.Dock");

        this.btnStreamReaderReadFromFile.Enabled = (bool) resources.GetObject("btnStreamReaderReadFromFile.Enabled");

        this.btnStreamReaderReadFromFile.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnStreamReaderReadFromFile.FlatStyle");

        this.btnStreamReaderReadFromFile.Font = (System.Drawing.Font) resources.GetObject("btnStreamReaderReadFromFile.Font");

        this.btnStreamReaderReadFromFile.Image = (System.Drawing.Image) resources.GetObject("btnStreamReaderReadFromFile.Image");

        this.btnStreamReaderReadFromFile.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStreamReaderReadFromFile.ImageAlign");

        this.btnStreamReaderReadFromFile.ImageIndex = (int) resources.GetObject("btnStreamReaderReadFromFile.ImageIndex");

        this.btnStreamReaderReadFromFile.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnStreamReaderReadFromFile.ImeMode");

        this.btnStreamReaderReadFromFile.Location = (System.Drawing.Point) resources.GetObject("btnStreamReaderReadFromFile.Location");

        this.btnStreamReaderReadFromFile.Name = "btnStreamReaderReadFromFile";

        this.btnStreamReaderReadFromFile.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnStreamReaderReadFromFile.RightToLeft");

        this.btnStreamReaderReadFromFile.Size = (System.Drawing.Size) resources.GetObject("btnStreamReaderReadFromFile.Size");

        this.btnStreamReaderReadFromFile.TabIndex = (int) resources.GetObject("btnStreamReaderReadFromFile.TabIndex");

        this.btnStreamReaderReadFromFile.Text = resources.GetString("btnStreamReaderReadFromFile.Text");

        this.btnStreamReaderReadFromFile.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStreamReaderReadFromFile.TextAlign");

        this.btnStreamReaderReadFromFile.Visible = (bool) resources.GetObject("btnStreamReaderReadFromFile.Visible");

        //

        //btnStringReaderReadFileInLines

        //

        this.btnStringReaderReadFileInLines.AccessibleDescription = resources.GetString("btnStringReaderReadFileInLines.AccessibleDescription");

        this.btnStringReaderReadFileInLines.AccessibleName = resources.GetString("btnStringReaderReadFileInLines.AccessibleName");

        this.btnStringReaderReadFileInLines.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnStringReaderReadFileInLines.Anchor");

        this.btnStringReaderReadFileInLines.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnStringReaderReadFileInLines.BackgroundImage");

        this.btnStringReaderReadFileInLines.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnStringReaderReadFileInLines.Dock");

        this.btnStringReaderReadFileInLines.Enabled = (bool) resources.GetObject("btnStringReaderReadFileInLines.Enabled");

        this.btnStringReaderReadFileInLines.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnStringReaderReadFileInLines.FlatStyle");

        this.btnStringReaderReadFileInLines.Font = (System.Drawing.Font) resources.GetObject("btnStringReaderReadFileInLines.Font");

        this.btnStringReaderReadFileInLines.Image = (System.Drawing.Image) resources.GetObject("btnStringReaderReadFileInLines.Image");

        this.btnStringReaderReadFileInLines.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStringReaderReadFileInLines.ImageAlign");

        this.btnStringReaderReadFileInLines.ImageIndex = (int) resources.GetObject("btnStringReaderReadFileInLines.ImageIndex");

        this.btnStringReaderReadFileInLines.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnStringReaderReadFileInLines.ImeMode");

        this.btnStringReaderReadFileInLines.Location = (System.Drawing.Point) resources.GetObject("btnStringReaderReadFileInLines.Location");

        this.btnStringReaderReadFileInLines.Name = "btnStringReaderReadFileInLines";

        this.btnStringReaderReadFileInLines.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnStringReaderReadFileInLines.RightToLeft");

        this.btnStringReaderReadFileInLines.Size = (System.Drawing.Size) resources.GetObject("btnStringReaderReadFileInLines.Size");

        this.btnStringReaderReadFileInLines.TabIndex = (int) resources.GetObject("btnStringReaderReadFileInLines.TabIndex");

        this.btnStringReaderReadFileInLines.Text = resources.GetString("btnStringReaderReadFileInLines.Text");

        this.btnStringReaderReadFileInLines.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStringReaderReadFileInLines.TextAlign");

        this.btnStringReaderReadFileInLines.Visible = (bool) resources.GetObject("btnStringReaderReadFileInLines.Visible");

        //

        //sdlgFile

        //

        this.sdlgFile.Filter = resources.GetString("sdlgFile.Filter");

        this.sdlgFile.InitialDirectory = @"C:\";

        this.sdlgFile.Title = resources.GetString("sdlgFile.Title");

        //

        //btnNewFileName

        //

        this.btnNewFileName.AccessibleDescription = resources.GetString("btnNewFileName.AccessibleDescription");

        this.btnNewFileName.AccessibleName = resources.GetString("btnNewFileName.AccessibleName");

        this.btnNewFileName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnNewFileName.Anchor");

        this.btnNewFileName.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnNewFileName.BackgroundImage");

        this.btnNewFileName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnNewFileName.Dock");

        this.btnNewFileName.Enabled = (bool) resources.GetObject("btnNewFileName.Enabled");

        this.btnNewFileName.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnNewFileName.FlatStyle");

        this.btnNewFileName.Font = (System.Drawing.Font) resources.GetObject("btnNewFileName.Font");

        this.btnNewFileName.Image = (System.Drawing.Image) resources.GetObject("btnNewFileName.Image");

        this.btnNewFileName.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnNewFileName.ImageAlign");

        this.btnNewFileName.ImageIndex = (int) resources.GetObject("btnNewFileName.ImageIndex");

        this.btnNewFileName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnNewFileName.ImeMode");

        this.btnNewFileName.Location = (System.Drawing.Point) resources.GetObject("btnNewFileName.Location");

        this.btnNewFileName.Name = "btnNewFileName";

        this.btnNewFileName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnNewFileName.RightToLeft");

        this.btnNewFileName.Size = (System.Drawing.Size) resources.GetObject("btnNewFileName.Size");

        this.btnNewFileName.TabIndex = (int) resources.GetObject("btnNewFileName.TabIndex");

        this.btnNewFileName.Text = resources.GetString("btnNewFileName.Text");

        this.btnNewFileName.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnNewFileName.TextAlign");

        this.btnNewFileName.Visible = (bool) resources.GetObject("btnNewFileName.Visible");

        //

        //btnOpenFileName

        //

        this.btnOpenFileName.AccessibleDescription = resources.GetString("btnOpenFileName.AccessibleDescription");

        this.btnOpenFileName.AccessibleName = resources.GetString("btnOpenFileName.AccessibleName");

        this.btnOpenFileName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnOpenFileName.Anchor");

        this.btnOpenFileName.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnOpenFileName.BackgroundImage");

        this.btnOpenFileName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnOpenFileName.Dock");

        this.btnOpenFileName.Enabled = (bool) resources.GetObject("btnOpenFileName.Enabled");

        this.btnOpenFileName.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnOpenFileName.FlatStyle");

        this.btnOpenFileName.Font = (System.Drawing.Font) resources.GetObject("btnOpenFileName.Font");

        this.btnOpenFileName.Image = (System.Drawing.Image) resources.GetObject("btnOpenFileName.Image");

        this.btnOpenFileName.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnOpenFileName.ImageAlign");

        this.btnOpenFileName.ImageIndex = (int) resources.GetObject("btnOpenFileName.ImageIndex");

        this.btnOpenFileName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnOpenFileName.ImeMode");

        this.btnOpenFileName.Location = (System.Drawing.Point) resources.GetObject("btnOpenFileName.Location");

        this.btnOpenFileName.Name = "btnOpenFileName";

        this.btnOpenFileName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnOpenFileName.RightToLeft");

        this.btnOpenFileName.Size = (System.Drawing.Size) resources.GetObject("btnOpenFileName.Size");

        this.btnOpenFileName.TabIndex = (int) resources.GetObject("btnOpenFileName.TabIndex");

        this.btnOpenFileName.Text = resources.GetString("btnOpenFileName.Text");

        this.btnOpenFileName.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnOpenFileName.TextAlign");

        this.btnOpenFileName.Visible = (bool) resources.GetObject("btnOpenFileName.Visible");

        //

        //btnStreamReaderReadInChars

        //

        this.btnStreamReaderReadInChars.AccessibleDescription = resources.GetString("btnStreamReaderReadInChars.AccessibleDescription");

        this.btnStreamReaderReadInChars.AccessibleName = resources.GetString("btnStreamReaderReadInChars.AccessibleName");

        this.btnStreamReaderReadInChars.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnStreamReaderReadInChars.Anchor");

        this.btnStreamReaderReadInChars.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnStreamReaderReadInChars.BackgroundImage");

        this.btnStreamReaderReadInChars.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnStreamReaderReadInChars.Dock");

        this.btnStreamReaderReadInChars.Enabled = (bool) resources.GetObject("btnStreamReaderReadInChars.Enabled");

        this.btnStreamReaderReadInChars.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnStreamReaderReadInChars.FlatStyle");

        this.btnStreamReaderReadInChars.Font = (System.Drawing.Font) resources.GetObject("btnStreamReaderReadInChars.Font");

        this.btnStreamReaderReadInChars.Image = (System.Drawing.Image) resources.GetObject("btnStreamReaderReadInChars.Image");

        this.btnStreamReaderReadInChars.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStreamReaderReadInChars.ImageAlign");

        this.btnStreamReaderReadInChars.ImageIndex = (int) resources.GetObject("btnStreamReaderReadInChars.ImageIndex");

        this.btnStreamReaderReadInChars.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnStreamReaderReadInChars.ImeMode");

        this.btnStreamReaderReadInChars.Location = (System.Drawing.Point) resources.GetObject("btnStreamReaderReadInChars.Location");

        this.btnStreamReaderReadInChars.Name = "btnStreamReaderReadInChars";

        this.btnStreamReaderReadInChars.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnStreamReaderReadInChars.RightToLeft");

        this.btnStreamReaderReadInChars.Size = (System.Drawing.Size) resources.GetObject("btnStreamReaderReadInChars.Size");

        this.btnStreamReaderReadInChars.TabIndex = (int) resources.GetObject("btnStreamReaderReadInChars.TabIndex");

        this.btnStreamReaderReadInChars.Text = resources.GetString("btnStreamReaderReadInChars.Text");

        this.btnStreamReaderReadInChars.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnStreamReaderReadInChars.TextAlign");

        this.btnStreamReaderReadInChars.Visible = (bool) resources.GetObject("btnStreamReaderReadInChars.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnStreamReaderReadInChars, this.btnOpenFileName, this.btnNewFileName, this.btnStringReaderReadFileInLines, this.btnStreamReaderReadFromFile, this.btnStreamWriterAppendToFile, this.btnStreamWriterCreateFile, this.txtFileName, this.lblFileName, this.lblFileText, this.txtFileText});

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

		this.btnNewFileName.Click += new EventHandler(btnNewFileName_Click);
		this.btnOpenFileName.Click += new EventHandler(btnOpenFileName_Click);
		this.btnStreamReaderReadFromFile.Click += new EventHandler(btnStreamReaderReadFromFile_Click);
		this.btnStreamReaderReadInChars.Click += new EventHandler(btnStreamReaderReadInChars_Click);
		this.btnStreamWriterAppendToFile.Click += new EventHandler(btnStreamWriterAppendToFile_Click);
		this.btnStreamWriterCreateFile.Click += new EventHandler(btnStreamWriterCreateFile_Click);
		this.btnStringReaderReadFileInLines.Click += new EventHandler(btnStringReaderReadFileInLines_Click);
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
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

    // This subroutine allows the user to specify a new file and directory
    //   using a SaveFileDialog object. To demonstrate the use drag-and-drop
    //   programming, this subroutine uses a SaveFileDialog created in the 
    //   visual designer.
    private void btnNewFileName_Click(object sender, System.EventArgs e) 
	{
        // Use the SaveFileDialog and put the path and name of the
        //   desired file in the txtFileName text box.
        if (this.sdlgFile.ShowDialog() == DialogResult.OK) 
		{
            this.txtFileName.Text = sdlgFile.FileName;
        }
    }

    // This subroutine allows the user to specify a file and directory of an existing
    //   file using an OpenFileDialog object. To demonstrate the programmatic 
    //   creation of the OpenFileDialog object, this subroutine defines and creates
    //   a new OpenFileDialog object in code.
    private void btnOpenFileName_Click(object sender, System.EventArgs e) 
	{
        // Create the OpenFileDialog object
        OpenFileDialog myOpenFileDialog = new OpenFileDialog();

		// Set properties appropriate.
        myOpenFileDialog.CheckFileExists = true;
        myOpenFileDialog.DefaultExt = "txt";
        myOpenFileDialog.InitialDirectory = @"C:\";
        myOpenFileDialog.Multiselect = false;

        // Use the OpenFileDialog and put the path and name of the
        //   selected file in the txtFileName text box.
        if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
		{
            this.txtFileName.Text = myOpenFileDialog.FileName;
        }
    }

    // This subrouting uses a StreamWriter object to append text to a currently
    //   existing file. if the file doesn't exist, it is created.
    private void btnStreamWriterAppendToFile_Click(object sender, System.EventArgs e) 
	{
        // The StreamWriter must be defined outside of the try-catch block
        //   in order to reference it in the Finally block.
        StreamWriter myStreamWriter = null;

        // Ensure that the creation of the new StreamWriter is wrapped in a 
        //   try-catch block, since an invalid filename could have been used.
		try 
		{
			// Create a StreamWriter using a static File class.
			myStreamWriter = File.AppendText(txtFileName.Text);

			// Write the entire contents of the txtFileText text box
			//   to the StreamWriter in one shot.
			myStreamWriter.Write(txtFileText.Text);

			// Flush the stream to ensure everything is flushed
			myStreamWriter.Flush();

		} 
		catch(Exception exc)
		{
			MessageBox.Show("File could not be opened or written to." + Environment.NewLine + "Please verify that the filename is correct, and that you have read permissions for the desired directory." + Environment.NewLine + Environment.NewLine + "Exception: " + exc.Message);
		}
		finally
		{
            // Close the object if it has been created.
            if (myStreamWriter != null)
			{
                myStreamWriter.Close();
            }
        }
    }

    // This subrouting uses a StreamWriter object to create a new file
    //   and fill it with the text in txtFileText. It first checks to see
    //   if the file already exists and prompts to overwrite it.
    private void btnStreamWriterCreateFile_Click(object sender, System.EventArgs e)
	{
        // Check to see if the user is writing over an existing file.
        if (File.Exists(txtFileName.Text))
		{
            if(MessageBox.Show("That file exists. Would you like to overwrite it?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
                // exit method
                return;
            }
        }

        // The StreamWriter must be defined outside of the try-catch block
        //   in order to reference it in the Finally block.
        StreamWriter myStreamWriter = null;

        // Ensure that the creation of the new StreamWriter is wrapped in a 
        //   try-catch block, since an invalid filename could have been used.
		try 
		{
			// Create a StreamWriter using a static File class.
			myStreamWriter = File.CreateText(txtFileName.Text);

			// Write the entire contents of the txtFileText text box
			//   to the StreamWriter in one shot.
			myStreamWriter.Write(txtFileText.Text);
			myStreamWriter.Flush();
		} 
		catch(Exception exc)
		{
			// Show the error to the user.
			MessageBox.Show("File could not be created or written to." + Environment.NewLine + "Please verify that the filename is correct, and that you have write permissions for the desired directory." + Environment.NewLine + Environment.NewLine + "Exception: " + exc.Message);
		}
		finally
		{
            // Close the object if it has been created.
            if (myStreamWriter != null)
			{
                myStreamWriter.Close();
            }
        }
    }

    // This subrouting uses a StreamReader object to open an existing file
    //   and read it line by line. It then outputs each line, with a line
    //   number to the txtFileText textbox.
    private void btnStringReaderReadFileInLines_Click(object sender, System.EventArgs e) 
	{
		// The StreamReader must be defined outside of the try-catch block
        //   in order to reference it in the Finally block.
        StreamReader myStreamReader = null;
        string myInputstring;
        int rowCount = 0;

		// Ensure that the creation of the new StreamReader is wrapped in a 
        //   try-catch block, since an invalid filename could have been used.
		try 
		{
			// Create a StreamReader using a static File class.
			myStreamReader = File.OpenText(txtFileName.Text);
			
			//Clear the TextBox
			txtFileText.Clear();

			// Begin by reading a single line
			myInputstring = myStreamReader.ReadLine();

			// Continue reading while there are still lines to be read
			while (myInputstring != null)
			{
				// Output the text with a line number
				txtFileText.Text += rowCount.ToString() + ": " + myInputstring + Environment.NewLine;
				rowCount++;
                
				// Read the next line.
				myInputstring = myStreamReader.ReadLine();
			}

		} 
		catch(Exception exc)
		{
			// Show the error to the user.
			MessageBox.Show("File could not be opened or read." + Environment.NewLine + "Please verify that the filename is correct, and that you have read permissions for the desired directory." + Environment.NewLine + Environment.NewLine + "Exception: " + exc.Message);
		}
		finally
		{
            // Close the object if it has been created.
            if (myStreamReader != null)
			{
                myStreamReader.Close();
            }
        }
    }

	// This subrouting uses a StreamReader object to open an existing file
    //   and read it in one pass and place the text in the txtFileText text box.
    private void btnStreamReaderReadFromFile_Click(object sender, System.EventArgs e) 
	{
        // The StreamReader must be defined outside of the try-catch block
        //   in order to reference it in the Finally block.
        StreamReader myStreamReader = null;

        // Ensure that the creation of the new StreamReader is wrapped in a 
        //   try-catch block, since an invalid filename could have been used.
		try 
		{
			// Create a StreamReader using a static File class.
			myStreamReader = File.OpenText(txtFileName.Text);

			// Read the entire file in one pass, and add the contents to 
			//   txtFileText text box.
			this.txtFileText.Text = myStreamReader.ReadToEnd();
		}
		catch(Exception exc)
		{
			// Show the exception to the user.
			MessageBox.Show("File could not be opened or read." + Environment.NewLine + "Please verify that the filename is correct, and that you have read permissions for the desired directory." + Environment.NewLine + Environment.NewLine + "Exception: " + exc.Message);
		}
		finally
		{
            // Close the object if it has been created.
            if (myStreamReader != null)
			{
                myStreamReader.Close();
            }
        }
    }

	// This subrouting uses a StreamReader object to open an existing file
    //   and read it character by character. It then outputs each character
    //   after a short pause, to show the user that the file is being read
    //   by characters. The output is added to the txtFileText text box.
    private void btnStreamReaderReadInChars_Click(object sender, System.EventArgs e)
	{
		// The StreamReader must be defined outside of the try-catch block
		//   in order to reference it in the Finally block.
        StreamReader myStreamReader = null;
        int myNextInt;

        // Ensure that the creation of the new StreamWriter is wrapped in a 
        //   try-catch block, since an invalid filename could have been used.
		try 
		{
			// Create a StreamReader using a static File class.
			myStreamReader = File.OpenText(txtFileName.Text);
            
			// Clear the TextBox
			txtFileText.Clear();

			// The Read() method returns an integer. 
			myNextInt = myStreamReader.Read();

			// The Read() method returns '-1' when the end of the
			//   file has been reached
			while (myNextInt != -1)
			{
				// Convert the integer to a unicode char and add it
				//   to the text box.
				txtFileText.Text += Convert.ToChar(myNextInt);

				// Read the next value from the Stream
				myNextInt = myStreamReader.Read();

				// Refresh the text box so that the user can see
				//   the characters being added.
				txtFileText.Refresh();

				// Sleep for 100 milliseconds, so that the user can
				//   see that the characters are being read one at a 
				//   time. Otherwise, they display too quickly.
				System.Threading.Thread.Sleep(100);
			}
		} 
		catch(Exception exc)
		{
			// Show the exception to the user.
			MessageBox.Show("File could not be opened or read." + Environment.NewLine + "Please verify that the filename is correct, and that you have read permissions for the desired directory." + Environment.NewLine + Environment.NewLine + "Exception: " + exc.Message);
		}
		finally
		{
            // Close the object if it has been created.
            if (myStreamReader != null)
			{
                myStreamReader.Close();
            }
        }
    }
}