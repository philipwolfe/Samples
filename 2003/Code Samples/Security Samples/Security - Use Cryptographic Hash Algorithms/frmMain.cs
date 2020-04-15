//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;
using System.Windows.Forms;
using System.Data;

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

	private System.Windows.Forms.MainMenu mnuMain;

	private System.Windows.Forms.MenuItem mnuFile;

	private System.Windows.Forms.MenuItem mnuExit;

	private System.Windows.Forms.MenuItem mnuHelp;

	private System.Windows.Forms.MenuItem mnuAbout;

    private System.Windows.Forms.TextBox txtXML;

    private System.Windows.Forms.RadioButton optSHA1;

    private System.Windows.Forms.RadioButton optMD5;

    private System.Windows.Forms.RadioButton optSHA384;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Label lblResults;

    private System.Windows.Forms.TextBox txtHashForCompare;

    private System.Windows.Forms.TextBox txtHashOriginal;

    private System.Windows.Forms.Button btnCompare;

    private System.Windows.Forms.Button btnRestore;

    private System.Windows.Forms.Label Label3;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.txtXML = new System.Windows.Forms.TextBox();

        this.optSHA1 = new System.Windows.Forms.RadioButton();

        this.optMD5 = new System.Windows.Forms.RadioButton();

        this.optSHA384 = new System.Windows.Forms.RadioButton();

        this.btnCompare = new System.Windows.Forms.Button();

        this.Label1 = new System.Windows.Forms.Label();

        this.Label2 = new System.Windows.Forms.Label();

        this.lblResults = new System.Windows.Forms.Label();

        this.txtHashOriginal = new System.Windows.Forms.TextBox();

        this.txtHashForCompare = new System.Windows.Forms.TextBox();

        this.btnRestore = new System.Windows.Forms.Button();

        this.Label3 = new System.Windows.Forms.Label();

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

        //txtXML

        //

        this.txtXML.AccessibleDescription = resources.GetString("txtXML.AccessibleDescription");

        this.txtXML.AccessibleName = resources.GetString("txtXML.AccessibleName");

        this.txtXML.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtXML.Anchor");

        this.txtXML.AutoSize = (bool) resources.GetObject("txtXML.AutoSize");

        this.txtXML.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtXML.BackgroundImage");

        this.txtXML.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtXML.Dock");

        this.txtXML.Enabled = (bool) resources.GetObject("txtXML.Enabled");

        this.txtXML.Font = (System.Drawing.Font) resources.GetObject("txtXML.Font");

        this.txtXML.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtXML.ImeMode");

        this.txtXML.Location = (System.Drawing.Point) resources.GetObject("txtXML.Location");

        this.txtXML.MaxLength = (int) resources.GetObject("txtXML.MaxLength");

        this.txtXML.Multiline = (bool) resources.GetObject("txtXML.Multiline");

        this.txtXML.Name = "txtXML";

        this.txtXML.PasswordChar = (char) resources.GetObject("txtXML.PasswordChar");

        this.txtXML.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtXML.RightToLeft");

        this.txtXML.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtXML.ScrollBars");

        this.txtXML.Size = (System.Drawing.Size) resources.GetObject("txtXML.Size");

        this.txtXML.TabIndex = (int) resources.GetObject("txtXML.TabIndex");

        this.txtXML.Text = resources.GetString("txtXML.Text");

        this.txtXML.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtXML.TextAlign");

        this.txtXML.Visible = (bool) resources.GetObject("txtXML.Visible");

        this.txtXML.WordWrap = (bool) resources.GetObject("txtXML.WordWrap");

        //

        //optSHA1

        //

        this.optSHA1.AccessibleDescription = resources.GetString("optSHA1.AccessibleDescription");

        this.optSHA1.AccessibleName = resources.GetString("optSHA1.AccessibleName");

        this.optSHA1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optSHA1.Anchor");

        this.optSHA1.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optSHA1.Appearance");

        this.optSHA1.BackgroundImage = (System.Drawing.Image) resources.GetObject("optSHA1.BackgroundImage");

        this.optSHA1.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSHA1.CheckAlign");

        this.optSHA1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optSHA1.Dock");

        this.optSHA1.Enabled = (bool) resources.GetObject("optSHA1.Enabled");

        this.optSHA1.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optSHA1.FlatStyle");

        this.optSHA1.Font = (System.Drawing.Font) resources.GetObject("optSHA1.Font");

        this.optSHA1.Image = (System.Drawing.Image) resources.GetObject("optSHA1.Image");

        this.optSHA1.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSHA1.ImageAlign");

        this.optSHA1.ImageIndex = (int) resources.GetObject("optSHA1.ImageIndex");

        this.optSHA1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optSHA1.ImeMode");

        this.optSHA1.Location = (System.Drawing.Point) resources.GetObject("optSHA1.Location");

        this.optSHA1.Name = "optSHA1";

        this.optSHA1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optSHA1.RightToLeft");

        this.optSHA1.Size = (System.Drawing.Size) resources.GetObject("optSHA1.Size");

        this.optSHA1.TabIndex = (int) resources.GetObject("optSHA1.TabIndex");

        this.optSHA1.Text = resources.GetString("optSHA1.Text");

        this.optSHA1.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSHA1.TextAlign");

        this.optSHA1.Visible = (bool) resources.GetObject("optSHA1.Visible");

        //

        //optMD5

        //

        this.optMD5.AccessibleDescription = resources.GetString("optMD5.AccessibleDescription");

        this.optMD5.AccessibleName = resources.GetString("optMD5.AccessibleName");

        this.optMD5.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optMD5.Anchor");

        this.optMD5.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optMD5.Appearance");

        this.optMD5.BackgroundImage = (System.Drawing.Image) resources.GetObject("optMD5.BackgroundImage");

        this.optMD5.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optMD5.CheckAlign");

        this.optMD5.Checked = true;

        this.optMD5.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optMD5.Dock");

        this.optMD5.Enabled = (bool) resources.GetObject("optMD5.Enabled");

        this.optMD5.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optMD5.FlatStyle");

        this.optMD5.Font = (System.Drawing.Font) resources.GetObject("optMD5.Font");

        this.optMD5.Image = (System.Drawing.Image) resources.GetObject("optMD5.Image");

        this.optMD5.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optMD5.ImageAlign");

        this.optMD5.ImageIndex = (int) resources.GetObject("optMD5.ImageIndex");

        this.optMD5.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optMD5.ImeMode");

        this.optMD5.Location = (System.Drawing.Point) resources.GetObject("optMD5.Location");

        this.optMD5.Name = "optMD5";

        this.optMD5.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optMD5.RightToLeft");

        this.optMD5.Size = (System.Drawing.Size) resources.GetObject("optMD5.Size");

        this.optMD5.TabIndex = (int) resources.GetObject("optMD5.TabIndex");

        this.optMD5.TabStop = true;

        this.optMD5.Text = resources.GetString("optMD5.Text");

        this.optMD5.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optMD5.TextAlign");

        this.optMD5.Visible = (bool) resources.GetObject("optMD5.Visible");

        //

        //optSHA384

        //

        this.optSHA384.AccessibleDescription = resources.GetString("optSHA384.AccessibleDescription");

        this.optSHA384.AccessibleName = resources.GetString("optSHA384.AccessibleName");

        this.optSHA384.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optSHA384.Anchor");

        this.optSHA384.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optSHA384.Appearance");

        this.optSHA384.BackgroundImage = (System.Drawing.Image) resources.GetObject("optSHA384.BackgroundImage");

        this.optSHA384.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSHA384.CheckAlign");

        this.optSHA384.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optSHA384.Dock");

        this.optSHA384.Enabled = (bool) resources.GetObject("optSHA384.Enabled");

        this.optSHA384.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optSHA384.FlatStyle");

        this.optSHA384.Font = (System.Drawing.Font) resources.GetObject("optSHA384.Font");

        this.optSHA384.Image = (System.Drawing.Image) resources.GetObject("optSHA384.Image");

        this.optSHA384.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSHA384.ImageAlign");

        this.optSHA384.ImageIndex = (int) resources.GetObject("optSHA384.ImageIndex");

        this.optSHA384.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optSHA384.ImeMode");

        this.optSHA384.Location = (System.Drawing.Point) resources.GetObject("optSHA384.Location");

        this.optSHA384.Name = "optSHA384";

        this.optSHA384.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optSHA384.RightToLeft");

        this.optSHA384.Size = (System.Drawing.Size) resources.GetObject("optSHA384.Size");

        this.optSHA384.TabIndex = (int) resources.GetObject("optSHA384.TabIndex");

        this.optSHA384.Text = resources.GetString("optSHA384.Text");

        this.optSHA384.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optSHA384.TextAlign");

        this.optSHA384.Visible = (bool) resources.GetObject("optSHA384.Visible");

        //

        //btnCompare

        //

        this.btnCompare.AccessibleDescription = resources.GetString("btnCompare.AccessibleDescription");

        this.btnCompare.AccessibleName = resources.GetString("btnCompare.AccessibleName");

        this.btnCompare.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCompare.Anchor");

        this.btnCompare.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCompare.BackgroundImage");

        this.btnCompare.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCompare.Dock");

        this.btnCompare.Enabled = (bool) resources.GetObject("btnCompare.Enabled");

        this.btnCompare.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCompare.FlatStyle");

        this.btnCompare.Font = (System.Drawing.Font) resources.GetObject("btnCompare.Font");

        this.btnCompare.Image = (System.Drawing.Image) resources.GetObject("btnCompare.Image");

        this.btnCompare.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCompare.ImageAlign");

        this.btnCompare.ImageIndex = (int) resources.GetObject("btnCompare.ImageIndex");

        this.btnCompare.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCompare.ImeMode");

        this.btnCompare.Location = (System.Drawing.Point) resources.GetObject("btnCompare.Location");

        this.btnCompare.Name = "btnCompare";

        this.btnCompare.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCompare.RightToLeft");

        this.btnCompare.Size = (System.Drawing.Size) resources.GetObject("btnCompare.Size");

        this.btnCompare.TabIndex = (int) resources.GetObject("btnCompare.TabIndex");

        this.btnCompare.Text = resources.GetString("btnCompare.Text");

        this.btnCompare.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCompare.TextAlign");

        this.btnCompare.Visible = (bool) resources.GetObject("btnCompare.Visible");

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

        //txtHashOriginal

        //

        this.txtHashOriginal.AccessibleDescription = resources.GetString("txtHashOriginal.AccessibleDescription");

        this.txtHashOriginal.AccessibleName = resources.GetString("txtHashOriginal.AccessibleName");

        this.txtHashOriginal.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtHashOriginal.Anchor");

        this.txtHashOriginal.AutoSize = (bool) resources.GetObject("txtHashOriginal.AutoSize");

        this.txtHashOriginal.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtHashOriginal.BackgroundImage");

        this.txtHashOriginal.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtHashOriginal.Dock");

        this.txtHashOriginal.Enabled = (bool) resources.GetObject("txtHashOriginal.Enabled");

        this.txtHashOriginal.Font = (System.Drawing.Font) resources.GetObject("txtHashOriginal.Font");

        this.txtHashOriginal.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtHashOriginal.ImeMode");

        this.txtHashOriginal.Location = (System.Drawing.Point) resources.GetObject("txtHashOriginal.Location");

        this.txtHashOriginal.MaxLength = (int) resources.GetObject("txtHashOriginal.MaxLength");

        this.txtHashOriginal.Multiline = (bool) resources.GetObject("txtHashOriginal.Multiline");

        this.txtHashOriginal.Name = "txtHashOriginal";

        this.txtHashOriginal.PasswordChar = (char) resources.GetObject("txtHashOriginal.PasswordChar");

        this.txtHashOriginal.ReadOnly = true;

        this.txtHashOriginal.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtHashOriginal.RightToLeft");

        this.txtHashOriginal.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtHashOriginal.ScrollBars");

        this.txtHashOriginal.Size = (System.Drawing.Size) resources.GetObject("txtHashOriginal.Size");

        this.txtHashOriginal.TabIndex = (int) resources.GetObject("txtHashOriginal.TabIndex");

        this.txtHashOriginal.Text = resources.GetString("txtHashOriginal.Text");

        this.txtHashOriginal.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtHashOriginal.TextAlign");

        this.txtHashOriginal.Visible = (bool) resources.GetObject("txtHashOriginal.Visible");

        this.txtHashOriginal.WordWrap = (bool) resources.GetObject("txtHashOriginal.WordWrap");

        //

        //txtHashForCompare

        //

        this.txtHashForCompare.AccessibleDescription = resources.GetString("txtHashForCompare.AccessibleDescription");

        this.txtHashForCompare.AccessibleName = resources.GetString("txtHashForCompare.AccessibleName");

        this.txtHashForCompare.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtHashForCompare.Anchor");

        this.txtHashForCompare.AutoSize = (bool) resources.GetObject("txtHashForCompare.AutoSize");

        this.txtHashForCompare.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtHashForCompare.BackgroundImage");

        this.txtHashForCompare.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtHashForCompare.Dock");

        this.txtHashForCompare.Enabled = (bool) resources.GetObject("txtHashForCompare.Enabled");

        this.txtHashForCompare.Font = (System.Drawing.Font) resources.GetObject("txtHashForCompare.Font");

        this.txtHashForCompare.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtHashForCompare.ImeMode");

        this.txtHashForCompare.Location = (System.Drawing.Point) resources.GetObject("txtHashForCompare.Location");

        this.txtHashForCompare.MaxLength = (int) resources.GetObject("txtHashForCompare.MaxLength");

        this.txtHashForCompare.Multiline = (bool) resources.GetObject("txtHashForCompare.Multiline");

        this.txtHashForCompare.Name = "txtHashForCompare";

        this.txtHashForCompare.PasswordChar = (char) resources.GetObject("txtHashForCompare.PasswordChar");

        this.txtHashForCompare.ReadOnly = true;

        this.txtHashForCompare.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtHashForCompare.RightToLeft");

        this.txtHashForCompare.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtHashForCompare.ScrollBars");

        this.txtHashForCompare.Size = (System.Drawing.Size) resources.GetObject("txtHashForCompare.Size");

        this.txtHashForCompare.TabIndex = (int) resources.GetObject("txtHashForCompare.TabIndex");

        this.txtHashForCompare.Text = resources.GetString("txtHashForCompare.Text");

        this.txtHashForCompare.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtHashForCompare.TextAlign");

        this.txtHashForCompare.Visible = (bool) resources.GetObject("txtHashForCompare.Visible");

        this.txtHashForCompare.WordWrap = (bool) resources.GetObject("txtHashForCompare.WordWrap");

        //

        //btnRestore

        //

        this.btnRestore.AccessibleDescription = resources.GetString("btnRestore.AccessibleDescription");

        this.btnRestore.AccessibleName = resources.GetString("btnRestore.AccessibleName");

        this.btnRestore.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRestore.Anchor");

        this.btnRestore.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRestore.BackgroundImage");

        this.btnRestore.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRestore.Dock");

        this.btnRestore.Enabled = (bool) resources.GetObject("btnRestore.Enabled");

        this.btnRestore.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRestore.FlatStyle");

        this.btnRestore.Font = (System.Drawing.Font) resources.GetObject("btnRestore.Font");

        this.btnRestore.Image = (System.Drawing.Image) resources.GetObject("btnRestore.Image");

        this.btnRestore.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRestore.ImageAlign");

        this.btnRestore.ImageIndex = (int) resources.GetObject("btnRestore.ImageIndex");

        this.btnRestore.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRestore.ImeMode");

        this.btnRestore.Location = (System.Drawing.Point) resources.GetObject("btnRestore.Location");

        this.btnRestore.Name = "btnRestore";

        this.btnRestore.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRestore.RightToLeft");

        this.btnRestore.Size = (System.Drawing.Size) resources.GetObject("btnRestore.Size");

        this.btnRestore.TabIndex = (int) resources.GetObject("btnRestore.TabIndex");

        this.btnRestore.Text = resources.GetString("btnRestore.Text");

        this.btnRestore.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRestore.TextAlign");

        this.btnRestore.Visible = (bool) resources.GetObject("btnRestore.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label3, this.btnRestore, this.txtHashForCompare, this.txtHashOriginal, this.lblResults, this.Label2, this.Label1, this.btnCompare, this.optSHA384, this.optMD5, this.optSHA1, this.txtXML});

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

		this.Load +=new EventHandler(frmMain_Load);
		this.btnCompare.Click +=new EventHandler(btnCompare_Click);
		this.btnRestore.Click +=new EventHandler(btnRestore_Click);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.optMD5.CheckedChanged +=new EventHandler(RadioButtons_CheckedChanged);
		this.optSHA1.CheckedChanged +=new EventHandler(RadioButtons_CheckedChanged);
		this.optSHA384.CheckedChanged +=new EventHandler(RadioButtons_CheckedChanged);


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

    protected const string COMPARE_INSTRUCTIONS = 
		"Click Compare! to generate a hash digest based on the product listing " +
		"to the left. The original and new hash digests will then be compared " + 
        "to authenticate the displayed product listing.";

    protected const string CONNECTION_ERROR_MSG =
        "To run this sample, you must have SQL " +
        "or MSDE with the Northwind database installed.  For " +
        "instructions on installing MSDE, view the ReadMe file.";

    protected const string MSDE_CONNECTION_STRING =
        @"Server=(local)\NetSDK;" + 
        "DataBase=northwind;" + 
		"Integrated Security=SSPI";

    protected const string SQL_CONNECTION_STRING =
        "Server=localhost;" + 
        "DataBase=northwind;" +
        "Integrated Security=SSPI";

    private bool DidPreviouslyConnect = false;
    private bool FormHasLoaded = false;
	private byte[] hash;

    private string strConn = SQL_CONNECTION_STRING;

    private string strOriginalXML;

    // This routine handles the "Compare!" button click event. It compares, byte for
    // byte, the original hash digest with the hash digest generated from the contents
    // of the TextBox.

    private void btnCompare_Click(object sender, System.EventArgs e) 
	{
        // Create an Encoding object so that you can use the convenient GetBytes 
        // method to obtain byte arrays.

        UnicodeEncoding uEncode = new UnicodeEncoding();

        // Create a byte array from the original XML file sent by the Northwind
        // Corporation.

        Byte[] bytHashOriginal  = uEncode.GetBytes(txtHashOriginal.Text);

        // Generate a hash digest from the contents of the TextBox. The contents 
        // simulate the XML received from the Northwind Corporation over the wire.
        // You want to compare the new hash with the original hash to make sure
        // the XML has not been corrupted in transit.

        string strHashForCompare = GenerateHashDigest(txtXML.Text);

        // From the new hash digest create a byte array for comparison with the
        // original hash digest byte array.

        Byte[] bytHashForCompare  = uEncode.GetBytes(strHashForCompare);

        // Display the new hash digest in a TextBox.

        txtHashForCompare.Text = strHashForCompare;

        //Loop through all the bytes in the hashed values.

		for (int i=0;i < bytHashOriginal.Length; i++)
		{
			// Compare each byte. if any do not match display an appropriate message
			// and exit the loop.

			if (bytHashOriginal[i] != bytHashForCompare[i]) 
			{
				lblResults.Text = "Data has been corrupted!";
				break;
			}
			else 
			{
				// Every byte matched so the "transmitted" XML has been authenticated.
				lblResults.Text = "Comparison Successful.";
			}

		}

    }

    // This routine handles the "Restore XML" button click event. This provides the user 
    // with an easy way to return the XML displayed in the TextBox to its uncorrupted state.

    private void btnRestore_Click(object sender, System.EventArgs e) 
	{
        txtXML.Text = strOriginalXML;

    }

    // This routine handles the Form Load event. It calls another routine to create the 
    // original XML data document, reads in the XML, displays it in the large TextBox,
    // and then calls a function to generate an MD5 hash digest to display in the upper 
    // left TextBox.

    private void frmMain_Load(object sender, System.EventArgs e)
		{

        // Create the XML data document simulating the original products list
        // held by the Northwind Company.

        CreateOriginalProductsList();

        // Open the XML data document and convert to a string. This simulates the
        // the product listing being transferred over the wire to a client.

        StreamReader sr = new StreamReader(@"..\products.xml");
        strOriginalXML = sr.ReadToEnd();
        sr.Close();

        // Display the "transmitted" XML and the hash digest that is used for 
        // authenticating the transmitted XML. This digest is generated from the
        // contents of the original document, not the XML displayed in the 
        // TextBox.

        txtXML.Text = strOriginalXML;
        txtHashOriginal.Text = GenerateHashDigest(strOriginalXML);
        txtHashForCompare.Text = COMPARE_INSTRUCTIONS;

        // Call Select() to put focus on the "Compare!" button and prevent the XML
        // in the TextBox from being automatically highlighted.

        btnCompare.Select();

        // This is used to prevent the code in the CheckedChanged event handler from
        // running prior to the Form being loaded.

        FormHasLoaded = true;

    }

    // This routine handles the CheckedChanged event for all three RadioButton 
    // controls. This routine generates a new hash digest based on the selected 
    // type and resets the UI. The code is wrapped in a FormHasLoaded check to ensure 
    // that it does not run before the Form has fully loaded. 

    private void RadioButtons_CheckedChanged(object sender, System.EventArgs e) 
	{
        if (FormHasLoaded) {

            txtHashOriginal.Text = GenerateHashDigest(strOriginalXML);
            txtHashForCompare.Text = COMPARE_INSTRUCTIONS;
            lblResults.Text = string.Empty;
            btnCompare.Focus();

        }

    }

    // This routine creates the XML data document used for the hash comparison.

    void CreateOriginalProductsList()
	{

        // Display a status message saying that the user is attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();

        if (!DidPreviouslyConnect) 
			{
            frmStatusMessage.Show("Connecting to SQL Server");
        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool IsConnecting = true;

        while (IsConnecting)
		{

            try {

                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in SQL Server, or be part of the Administrators
                // group for this to work.

                SqlConnection scnnNW = new SqlConnection(strConn);
                string strSQL = "SELECT ProductID, ProductName, UnitPrice " +
                    "FROM Products";

                // A SqlCommand object is used to execute the SQL commands.

                SqlCommand scmd = new SqlCommand(strSQL, scnnNW);

                // A SqlDataAdapter uses the SqlCommand object to fill a DataSet.

                SqlDataAdapter sda = new SqlDataAdapter(scmd);

                // Create a new Dataset and fill its first DataTable.

                DataSet dsProducts = new DataSet();
                sda.Fill(dsProducts);

                // Persist the Dataset to XML.

                try {

                    dsProducts.WriteXml(@"..\products.xml");

               } catch (Exception exp)
				{
                    MessageBox.Show(exp.Message, this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                // The data has been successfully retrieved, so break out of the loop
                // and close the status form.

                IsConnecting = false;
                DidPreviouslyConnect = true;
                frmStatusMessage.Close();
           } catch(SqlException expSql)
			{
                MessageBox.Show(expSql.Message, this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
           } 
			catch
			{
				if (strConn == SQL_CONNECTION_STRING) 
				{
					// Couldn't connect to SQL Server.  Now try MSDE.
					strConn = MSDE_CONNECTION_STRING;
					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{
					// Unable to connect to SQL Server or MSDE
					frmStatusMessage.Close();
					MessageBox.Show(CONNECTION_ERROR_MSG, this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);
					Application.Exit();
				}
            }
        }
    }

    // This function performs the encryption work, generating the various
    // hash digests.

    string GenerateHashDigest(string strSource)
	{

        // Create an Encoding object so that you can use the convenient GetBytes 
        // method to obtain byte arrays.

        UnicodeEncoding uEncode = new UnicodeEncoding();

        // Create a byte array from the source text passed an argument.

        byte[] bytProducts = uEncode.GetBytes(strSource);

        // The code is almost identical for all three hash types.

		if (optMD5.Checked) 
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			hash = md5.ComputeHash(bytProducts);
		} 
		else if (optSHA1.Checked) 
		{
			SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
			hash = sha1.ComputeHash(bytProducts);
		}
		else 
		{
			SHA384Managed sha384 = new SHA384Managed();
			hash = sha384.ComputeHash(bytProducts);
		}

        // Base64 is a method of encoding binary data ASCII text.

        return Convert.ToBase64String(hash);

    }
}

