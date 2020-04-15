//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

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

    //Do not modify it using the code editor.
    private System.Windows.Forms.MainMenu mnuMain;
    private System.Windows.Forms.MenuItem mnuFile;
    private System.Windows.Forms.MenuItem mnuExit;
    private System.Windows.Forms.MenuItem mnuHelp;
    private System.Windows.Forms.MenuItem mnuAbout;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.RadioButton optTripleDESAdv;
    private System.Windows.Forms.RadioButton optRijndaelAdv;
    private System.Windows.Forms.Button btnCreateKey;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.CheckBox chkAdvanced;
    private System.Windows.Forms.OpenFileDialog odlgSourceFile;
    private System.Windows.Forms.TextBox txtCrypto;
    private System.Windows.Forms.Button btnDecrypt;
    private System.Windows.Forms.Button btnEncrypt;
    private System.Windows.Forms.Label lblPassword;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.btnLoad = new System.Windows.Forms.Button();

        this.btnDecrypt = new System.Windows.Forms.Button();

        this.btnEncrypt = new System.Windows.Forms.Button();

        this.txtCrypto = new System.Windows.Forms.TextBox();

        this.optTripleDESAdv = new System.Windows.Forms.RadioButton();

        this.optRijndaelAdv = new System.Windows.Forms.RadioButton();

        this.btnCreateKey = new System.Windows.Forms.Button();

        this.txtPassword = new System.Windows.Forms.TextBox();

        this.lblPassword = new System.Windows.Forms.Label();

        this.chkAdvanced = new System.Windows.Forms.CheckBox();

        this.odlgSourceFile = new System.Windows.Forms.OpenFileDialog();

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

        //btnLoad

        //

        this.btnLoad.AccessibleDescription = resources.GetString("btnLoad.AccessibleDescription");

        this.btnLoad.AccessibleName = resources.GetString("btnLoad.AccessibleName");

        this.btnLoad.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnLoad.Anchor");

        this.btnLoad.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnLoad.BackgroundImage");

        this.btnLoad.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnLoad.Dock");

        this.btnLoad.Enabled = (bool) resources.GetObject("btnLoad.Enabled");

        this.btnLoad.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnLoad.FlatStyle");

        this.btnLoad.Font = (System.Drawing.Font) resources.GetObject("btnLoad.Font");

        this.btnLoad.Image = (System.Drawing.Image) resources.GetObject("btnLoad.Image");

        this.btnLoad.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnLoad.ImageAlign");

        this.btnLoad.ImageIndex = (int) resources.GetObject("btnLoad.ImageIndex");

        this.btnLoad.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnLoad.ImeMode");

        this.btnLoad.Location = (System.Drawing.Point) resources.GetObject("btnLoad.Location");

        this.btnLoad.Name = "btnLoad";

        this.btnLoad.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnLoad.RightToLeft");

        this.btnLoad.Size = (System.Drawing.Size) resources.GetObject("btnLoad.Size");

        this.btnLoad.TabIndex = (int) resources.GetObject("btnLoad.TabIndex");

        this.btnLoad.Text = resources.GetString("btnLoad.Text");

        this.btnLoad.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnLoad.TextAlign");

        this.btnLoad.Visible = (bool) resources.GetObject("btnLoad.Visible");

        //

        //btnDecrypt

        //

        this.btnDecrypt.AccessibleDescription = resources.GetString("btnDecrypt.AccessibleDescription");

        this.btnDecrypt.AccessibleName = resources.GetString("btnDecrypt.AccessibleName");

        this.btnDecrypt.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnDecrypt.Anchor");

        this.btnDecrypt.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnDecrypt.BackgroundImage");

        this.btnDecrypt.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnDecrypt.Dock");

        this.btnDecrypt.Enabled = (bool) resources.GetObject("btnDecrypt.Enabled");

        this.btnDecrypt.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnDecrypt.FlatStyle");

        this.btnDecrypt.Font = (System.Drawing.Font) resources.GetObject("btnDecrypt.Font");

        this.btnDecrypt.Image = (System.Drawing.Image) resources.GetObject("btnDecrypt.Image");

        this.btnDecrypt.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDecrypt.ImageAlign");

        this.btnDecrypt.ImageIndex = (int) resources.GetObject("btnDecrypt.ImageIndex");

        this.btnDecrypt.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnDecrypt.ImeMode");

        this.btnDecrypt.Location = (System.Drawing.Point) resources.GetObject("btnDecrypt.Location");

        this.btnDecrypt.Name = "btnDecrypt";

        this.btnDecrypt.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnDecrypt.RightToLeft");

        this.btnDecrypt.Size = (System.Drawing.Size) resources.GetObject("btnDecrypt.Size");

        this.btnDecrypt.TabIndex = (int) resources.GetObject("btnDecrypt.TabIndex");

        this.btnDecrypt.Text = resources.GetString("btnDecrypt.Text");

        this.btnDecrypt.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDecrypt.TextAlign");

        this.btnDecrypt.Visible = (bool) resources.GetObject("btnDecrypt.Visible");

        //

        //btnEncrypt

        //

        this.btnEncrypt.AccessibleDescription = resources.GetString("btnEncrypt.AccessibleDescription");

        this.btnEncrypt.AccessibleName = resources.GetString("btnEncrypt.AccessibleName");

        this.btnEncrypt.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnEncrypt.Anchor");

        this.btnEncrypt.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnEncrypt.BackgroundImage");

        this.btnEncrypt.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnEncrypt.Dock");

        this.btnEncrypt.Enabled = (bool) resources.GetObject("btnEncrypt.Enabled");

        this.btnEncrypt.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnEncrypt.FlatStyle");

        this.btnEncrypt.Font = (System.Drawing.Font) resources.GetObject("btnEncrypt.Font");

        this.btnEncrypt.Image = (System.Drawing.Image) resources.GetObject("btnEncrypt.Image");

        this.btnEncrypt.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnEncrypt.ImageAlign");

        this.btnEncrypt.ImageIndex = (int) resources.GetObject("btnEncrypt.ImageIndex");

        this.btnEncrypt.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnEncrypt.ImeMode");

        this.btnEncrypt.Location = (System.Drawing.Point) resources.GetObject("btnEncrypt.Location");

        this.btnEncrypt.Name = "btnEncrypt";

        this.btnEncrypt.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnEncrypt.RightToLeft");

        this.btnEncrypt.Size = (System.Drawing.Size) resources.GetObject("btnEncrypt.Size");

        this.btnEncrypt.TabIndex = (int) resources.GetObject("btnEncrypt.TabIndex");

        this.btnEncrypt.Text = resources.GetString("btnEncrypt.Text");

        this.btnEncrypt.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnEncrypt.TextAlign");

        this.btnEncrypt.Visible = (bool) resources.GetObject("btnEncrypt.Visible");

        //

        //txtCrypto

        //

        this.txtCrypto.AccessibleDescription = resources.GetString("txtCrypto.AccessibleDescription");

        this.txtCrypto.AccessibleName = resources.GetString("txtCrypto.AccessibleName");

        this.txtCrypto.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCrypto.Anchor");

        this.txtCrypto.AutoSize = (bool) resources.GetObject("txtCrypto.AutoSize");

        this.txtCrypto.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCrypto.BackgroundImage");

        this.txtCrypto.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCrypto.Dock");

        this.txtCrypto.Enabled = (bool) resources.GetObject("txtCrypto.Enabled");

        this.txtCrypto.Font = (System.Drawing.Font) resources.GetObject("txtCrypto.Font");

        this.txtCrypto.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCrypto.ImeMode");

        this.txtCrypto.Location = (System.Drawing.Point) resources.GetObject("txtCrypto.Location");

        this.txtCrypto.MaxLength = (int) resources.GetObject("txtCrypto.MaxLength");

        this.txtCrypto.Multiline = (bool) resources.GetObject("txtCrypto.Multiline");

        this.txtCrypto.Name = "txtCrypto";

        this.txtCrypto.PasswordChar = (char) resources.GetObject("txtCrypto.PasswordChar");

        this.txtCrypto.ReadOnly = true;

        this.txtCrypto.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCrypto.RightToLeft");

        this.txtCrypto.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCrypto.ScrollBars");

        this.txtCrypto.Size = (System.Drawing.Size) resources.GetObject("txtCrypto.Size");

        this.txtCrypto.TabIndex = (int) resources.GetObject("txtCrypto.TabIndex");

        this.txtCrypto.Text = resources.GetString("txtCrypto.Text");

        this.txtCrypto.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCrypto.TextAlign");

        this.txtCrypto.Visible = (bool) resources.GetObject("txtCrypto.Visible");

        this.txtCrypto.WordWrap = (bool) resources.GetObject("txtCrypto.WordWrap");

        //

        //optTripleDESAdv

        //

        this.optTripleDESAdv.AccessibleDescription = resources.GetString("optTripleDESAdv.AccessibleDescription");

        this.optTripleDESAdv.AccessibleName = resources.GetString("optTripleDESAdv.AccessibleName");

        this.optTripleDESAdv.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optTripleDESAdv.Anchor");

        this.optTripleDESAdv.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optTripleDESAdv.Appearance");

        this.optTripleDESAdv.BackgroundImage = (System.Drawing.Image) resources.GetObject("optTripleDESAdv.BackgroundImage");

        this.optTripleDESAdv.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optTripleDESAdv.CheckAlign");

        this.optTripleDESAdv.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optTripleDESAdv.Dock");

        this.optTripleDESAdv.Enabled = (bool) resources.GetObject("optTripleDESAdv.Enabled");

        this.optTripleDESAdv.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optTripleDESAdv.FlatStyle");

        this.optTripleDESAdv.Font = (System.Drawing.Font) resources.GetObject("optTripleDESAdv.Font");

        this.optTripleDESAdv.Image = (System.Drawing.Image) resources.GetObject("optTripleDESAdv.Image");

        this.optTripleDESAdv.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optTripleDESAdv.ImageAlign");

        this.optTripleDESAdv.ImageIndex = (int) resources.GetObject("optTripleDESAdv.ImageIndex");

        this.optTripleDESAdv.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optTripleDESAdv.ImeMode");

        this.optTripleDESAdv.Location = (System.Drawing.Point) resources.GetObject("optTripleDESAdv.Location");

        this.optTripleDESAdv.Name = "optTripleDESAdv";

        this.optTripleDESAdv.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optTripleDESAdv.RightToLeft");

        this.optTripleDESAdv.Size = (System.Drawing.Size) resources.GetObject("optTripleDESAdv.Size");

        this.optTripleDESAdv.TabIndex = (int) resources.GetObject("optTripleDESAdv.TabIndex");

        this.optTripleDESAdv.Tag = string.Empty;

        this.optTripleDESAdv.Text = resources.GetString("optTripleDESAdv.Text");

        this.optTripleDESAdv.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optTripleDESAdv.TextAlign");

        this.optTripleDESAdv.Visible = (bool) resources.GetObject("optTripleDESAdv.Visible");

        //

        //optRijndaelAdv

        //

        this.optRijndaelAdv.AccessibleDescription = resources.GetString("optRijndaelAdv.AccessibleDescription");

        this.optRijndaelAdv.AccessibleName = resources.GetString("optRijndaelAdv.AccessibleName");

        this.optRijndaelAdv.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optRijndaelAdv.Anchor");

        this.optRijndaelAdv.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optRijndaelAdv.Appearance");

        this.optRijndaelAdv.BackgroundImage = (System.Drawing.Image) resources.GetObject("optRijndaelAdv.BackgroundImage");

        this.optRijndaelAdv.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optRijndaelAdv.CheckAlign");

        this.optRijndaelAdv.Checked = true;

        this.optRijndaelAdv.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optRijndaelAdv.Dock");

        this.optRijndaelAdv.Enabled = (bool) resources.GetObject("optRijndaelAdv.Enabled");

        this.optRijndaelAdv.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optRijndaelAdv.FlatStyle");

        this.optRijndaelAdv.Font = (System.Drawing.Font) resources.GetObject("optRijndaelAdv.Font");

        this.optRijndaelAdv.Image = (System.Drawing.Image) resources.GetObject("optRijndaelAdv.Image");

        this.optRijndaelAdv.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optRijndaelAdv.ImageAlign");

        this.optRijndaelAdv.ImageIndex = (int) resources.GetObject("optRijndaelAdv.ImageIndex");

        this.optRijndaelAdv.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optRijndaelAdv.ImeMode");

        this.optRijndaelAdv.Location = (System.Drawing.Point) resources.GetObject("optRijndaelAdv.Location");

        this.optRijndaelAdv.Name = "optRijndaelAdv";

        this.optRijndaelAdv.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optRijndaelAdv.RightToLeft");

        this.optRijndaelAdv.Size = (System.Drawing.Size) resources.GetObject("optRijndaelAdv.Size");

        this.optRijndaelAdv.TabIndex = (int) resources.GetObject("optRijndaelAdv.TabIndex");

        this.optRijndaelAdv.TabStop = true;

        this.optRijndaelAdv.Text = resources.GetString("optRijndaelAdv.Text");

        this.optRijndaelAdv.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optRijndaelAdv.TextAlign");

        this.optRijndaelAdv.Visible = (bool) resources.GetObject("optRijndaelAdv.Visible");

        //

        //btnCreateKey

        //

        this.btnCreateKey.AccessibleDescription = resources.GetString("btnCreateKey.AccessibleDescription");

        this.btnCreateKey.AccessibleName = resources.GetString("btnCreateKey.AccessibleName");

        this.btnCreateKey.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateKey.Anchor");

        this.btnCreateKey.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateKey.BackgroundImage");

        this.btnCreateKey.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateKey.Dock");

        this.btnCreateKey.Enabled = (bool) resources.GetObject("btnCreateKey.Enabled");

        this.btnCreateKey.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateKey.FlatStyle");

        this.btnCreateKey.Font = (System.Drawing.Font) resources.GetObject("btnCreateKey.Font");

        this.btnCreateKey.Image = (System.Drawing.Image) resources.GetObject("btnCreateKey.Image");

        this.btnCreateKey.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateKey.ImageAlign");

        this.btnCreateKey.ImageIndex = (int) resources.GetObject("btnCreateKey.ImageIndex");

        this.btnCreateKey.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateKey.ImeMode");

        this.btnCreateKey.Location = (System.Drawing.Point) resources.GetObject("btnCreateKey.Location");

        this.btnCreateKey.Name = "btnCreateKey";

        this.btnCreateKey.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateKey.RightToLeft");

        this.btnCreateKey.Size = (System.Drawing.Size) resources.GetObject("btnCreateKey.Size");

        this.btnCreateKey.TabIndex = (int) resources.GetObject("btnCreateKey.TabIndex");

        this.btnCreateKey.Text = resources.GetString("btnCreateKey.Text");

        this.btnCreateKey.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateKey.TextAlign");

        this.btnCreateKey.Visible = (bool) resources.GetObject("btnCreateKey.Visible");

        //

        //txtPassword

        //

        this.txtPassword.AccessibleDescription = resources.GetString("txtPassword.AccessibleDescription");

        this.txtPassword.AccessibleName = resources.GetString("txtPassword.AccessibleName");

        this.txtPassword.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtPassword.Anchor");

        this.txtPassword.AutoSize = (bool) resources.GetObject("txtPassword.AutoSize");

        this.txtPassword.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtPassword.BackgroundImage");

        this.txtPassword.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtPassword.Dock");

        this.txtPassword.Enabled = (bool) resources.GetObject("txtPassword.Enabled");

        this.txtPassword.Font = (System.Drawing.Font) resources.GetObject("txtPassword.Font");

        this.txtPassword.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtPassword.ImeMode");

        this.txtPassword.Location = (System.Drawing.Point) resources.GetObject("txtPassword.Location");

        this.txtPassword.MaxLength = (int) resources.GetObject("txtPassword.MaxLength");

        this.txtPassword.Multiline = (bool) resources.GetObject("txtPassword.Multiline");

        this.txtPassword.Name = "txtPassword";

        this.txtPassword.PasswordChar = (char) resources.GetObject("txtPassword.PasswordChar");

        this.txtPassword.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtPassword.RightToLeft");

        this.txtPassword.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtPassword.ScrollBars");

        this.txtPassword.Size = (System.Drawing.Size) resources.GetObject("txtPassword.Size");

        this.txtPassword.TabIndex = (int) resources.GetObject("txtPassword.TabIndex");

        this.txtPassword.Text = resources.GetString("txtPassword.Text");

        this.txtPassword.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtPassword.TextAlign");

        this.txtPassword.Visible = (bool) resources.GetObject("txtPassword.Visible");

        this.txtPassword.WordWrap = (bool) resources.GetObject("txtPassword.WordWrap");

        //

        //lblPassword

        //

        this.lblPassword.AccessibleDescription = resources.GetString("lblPassword.AccessibleDescription");

        this.lblPassword.AccessibleName = resources.GetString("lblPassword.AccessibleName");

        this.lblPassword.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblPassword.Anchor");

        this.lblPassword.AutoSize = (bool) resources.GetObject("lblPassword.AutoSize");

        this.lblPassword.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblPassword.Dock");

        this.lblPassword.Enabled = (bool) resources.GetObject("lblPassword.Enabled");

        this.lblPassword.Font = (System.Drawing.Font) resources.GetObject("lblPassword.Font");

        this.lblPassword.Image = (System.Drawing.Image) resources.GetObject("lblPassword.Image");

        this.lblPassword.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblPassword.ImageAlign");

        this.lblPassword.ImageIndex = (int) resources.GetObject("lblPassword.ImageIndex");

        this.lblPassword.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblPassword.ImeMode");

        this.lblPassword.Location = (System.Drawing.Point) resources.GetObject("lblPassword.Location");

        this.lblPassword.Name = "lblPassword";

        this.lblPassword.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblPassword.RightToLeft");

        this.lblPassword.Size = (System.Drawing.Size) resources.GetObject("lblPassword.Size");

        this.lblPassword.TabIndex = (int) resources.GetObject("lblPassword.TabIndex");

        this.lblPassword.Text = resources.GetString("lblPassword.Text");

        this.lblPassword.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblPassword.TextAlign");

        this.lblPassword.Visible = (bool) resources.GetObject("lblPassword.Visible");

        //

        //chkAdvanced

        //

        this.chkAdvanced.AccessibleDescription = resources.GetString("chkAdvanced.AccessibleDescription");

        this.chkAdvanced.AccessibleName = resources.GetString("chkAdvanced.AccessibleName");

        this.chkAdvanced.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkAdvanced.Anchor");

        this.chkAdvanced.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkAdvanced.Appearance");

        this.chkAdvanced.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkAdvanced.BackgroundImage");

        this.chkAdvanced.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkAdvanced.CheckAlign");

        this.chkAdvanced.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkAdvanced.Dock");

        this.chkAdvanced.Enabled = (bool) resources.GetObject("chkAdvanced.Enabled");

        this.chkAdvanced.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkAdvanced.FlatStyle");

        this.chkAdvanced.Font = (System.Drawing.Font) resources.GetObject("chkAdvanced.Font");

        this.chkAdvanced.Image = (System.Drawing.Image) resources.GetObject("chkAdvanced.Image");

        this.chkAdvanced.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkAdvanced.ImageAlign");

        this.chkAdvanced.ImageIndex = (int) resources.GetObject("chkAdvanced.ImageIndex");

        this.chkAdvanced.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkAdvanced.ImeMode");

        this.chkAdvanced.Location = (System.Drawing.Point) resources.GetObject("chkAdvanced.Location");

        this.chkAdvanced.Name = "chkAdvanced";

        this.chkAdvanced.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkAdvanced.RightToLeft");

        this.chkAdvanced.Size = (System.Drawing.Size) resources.GetObject("chkAdvanced.Size");

        this.chkAdvanced.TabIndex = (int) resources.GetObject("chkAdvanced.TabIndex");

        this.chkAdvanced.Text = resources.GetString("chkAdvanced.Text");

        this.chkAdvanced.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkAdvanced.TextAlign");

        this.chkAdvanced.Visible = (bool) resources.GetObject("chkAdvanced.Visible");

        //

        //odlgSourceFile

        //

        this.odlgSourceFile.Filter = resources.GetString("odlgSourceFile.Filter");

        this.odlgSourceFile.Title = resources.GetString("odlgSourceFile.Title");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkAdvanced, this.btnCreateKey, this.txtPassword, this.lblPassword, this.btnLoad, this.btnDecrypt, this.btnEncrypt, this.txtCrypto, this.optTripleDESAdv, this.optRijndaelAdv});

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
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.btnCreateKey.Click +=new EventHandler(btnCreateKey_Click);
		this.btnEncrypt.Click +=new EventHandler(EncryptDecrypt_Click);
		this.btnDecrypt.Click +=new EventHandler(EncryptDecrypt_Click);
		this.btnLoad.Click +=new EventHandler(btnLoad_Click);
		this.chkAdvanced.CheckedChanged +=new EventHandler(chkAdvanced_CheckedChanged);
		this.optRijndaelAdv.CheckedChanged +=new EventHandler(RadioButtons_CheckedChanged);
		this.optTripleDESAdv.CheckedChanged +=new EventHandler(RadioButtons_CheckedChanged);


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

    private SampleCrypto crpSample;
    private bool FormHasLoaded = false;
    private string strCurrentKeyFile;
    private string strSourcePath;
    private string strRijndaelSaltIVFile;
    private string strTripleDESSaltIVFile;

    // This routine handles the "Create Salt / IV Key" button click event.

    private void btnCreateKey_Click(object sender, System.EventArgs e) 
	{
        try {

			if (PasswordIsValid()) 
			{

				crpSample.Password = txtPassword.Text;
			}
			else 
			{
				return;
			}

            if (crpSample.CreateSaltIVFile(strCurrentKeyFile)) 
			{
                MessageBox.Show("Salt and IV successfully generated and saved to a .dat " + Environment.NewLine + 
                    "file in the Visual Studio .NET Solution root folder.", 
                    this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

       } catch( Exception exp)
		{
            MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

    }

    // This routine handles the "Encrypt" and "Decrypt" button click events.

    private void EncryptDecrypt_Click(object sender, System.EventArgs e) 
	{
        Button btn = (Button) sender;

        try {

            if (chkAdvanced.Checked) {

				if (IsValid()) 
				{
					crpSample.SaltIVFile = strCurrentKeyFile;
					crpSample.Password = txtPassword.Text;
				}
				else 
				{
					return;
				}

            }
            crpSample.SourceFileName = strSourcePath;
			if (btn.Name == "btnEncrypt") 
			{
				crpSample.EncryptFile();
			}
			else 
			{
				crpSample.DecryptFile();
			}

            txtCrypto.Text = ReadFileAsstring(strSourcePath);

       } 
		catch(CryptographicException expCrypto)
		{
            MessageBox.Show("The file could not be decrypted. Make sure you entered " + 
                "the correct password. " + Environment.NewLine + "This error can also be caused by changing " + 
                "crypto type between encryption and decryption.", 
                this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);

       } catch( Exception exp)
		{
            MessageBox.Show(exp.Message, this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

    }

    // This routine handles the "Load" button click event.

    private void btnLoad_Click(object sender, System.EventArgs e) 
	{

            odlgSourceFile.InitialDirectory = @"C:\";

            // The file could be of any type. The Filter is restricted to Text Format 
            // files only for demonstration purposes.

            odlgSourceFile.Filter = "Text Format (*.txt)|*.txt";
            odlgSourceFile.FilterIndex = 1;

            // The OpenFileDialog control only has an Open button, not an OK button.
            // However, there is no DialogResult.Open enum so use DialogResult.OK.

            if (odlgSourceFile.ShowDialog() == DialogResult.OK) {
                try {
                    txtCrypto.Text = ReadFileAsstring(odlgSourceFile.FileName);
                    strSourcePath = odlgSourceFile.FileName;

               } 
				catch( ArgumentException exp)
				{
                    MessageBox.Show(exp.Message, this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
    }

    // This routine handles the CheckedChanged event for the "Advanced" checkbox.

    private void chkAdvanced_CheckedChanged(object sender, System.EventArgs e) 
	{

		if (chkAdvanced.Checked) 
		{
			lblPassword.Enabled = true;
			txtPassword.Enabled = true;
			btnCreateKey.Enabled = true;
		}
		else 
		{
			lblPassword.Enabled = false;
			txtPassword.Enabled = false;
			btnCreateKey.Enabled = false;
		}
    }

    // This routine handles the Form's Load event, setting up the sample.

    private void frmMain_Load(object sender, System.EventArgs e) 
	{

        // Set the default crypto type.

        crpSample = new SampleCrypto("Rijndael");

        // Set the path to save the key file to the Solution root folder by stripping 

        // "bin" from the current directory.

        string strCurrentDirectory = Environment.CurrentDirectory.Substring(
			Environment.CurrentDirectory.Length - 2);

        // Initialize paths for both types of key files.

        strRijndaelSaltIVFile = strCurrentDirectory + "RijndaelSaltIV.dat";
        strTripleDESSaltIVFile = strCurrentDirectory + "TripleDESSaltIV.dat";

        // Set the current key file path to the key for default crypto type.

        strCurrentKeyFile = strRijndaelSaltIVFile;

        // Call Select() to put focus on the "Encrypt" button and prevent the text in 
        // the TextBox from being automatically highlighted.

        btnEncrypt.Select();
        FormHasLoaded = true;

    }

    // This routine handles the CheckedChanged event for the RadioButton controls.

    private void RadioButtons_CheckedChanged(object sender, System.EventArgs e) 
	{
		if (FormHasLoaded)
		{
			if (optRijndaelAdv.Checked) 
			{
				crpSample = new SampleCrypto("Rijndael");
				strCurrentKeyFile = strRijndaelSaltIVFile;
			}
			else 
			{
				crpSample = new SampleCrypto("TripleDES");
				strCurrentKeyFile = strTripleDESSaltIVFile;
			}
        }
    }

    // This routine validates all data entry.

    private bool IsValid() 
	{

        if (!PasswordIsValid()) 
			{
            return false;
        }

        if (strSourcePath == "") {
            MessageBox.Show("You must first load a source file!", this.Text, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            return false;
        }
        return true;
    }

    // This routine validates the password.

    private bool PasswordIsValid()
		{
        if (!Regex.IsMatch(txtPassword.Text, @"^\s*(\w){8}\s*$")) 
{
            MessageBox.Show("You must enter an 8-digit password consisting of numbers " + 
                "and/or letters.", this.Text,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;

        }

        return true;

    }

    // This routine reads in the contents of a file and converts it to a string.

    static string ReadFileAsstring(string path)
{

        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        byte[] abyt = new byte[Convert.ToInt32(fs.Length)];
        fs.Read(abyt, 0, abyt.Length);
        fs.Close();
        return Encoding.UTF8.GetString(abyt);

    }

}

