//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Drawing;

public class frmMain: System.Windows.Forms.Form {

    // The following strings hold the various ways of formatting the
    //   "The Clipboard is Cool!" text.

    string strText = "The Clipboard is Cool!";

	string strHTML = "<P>The <B><FONT size='4'><U>Clipboard</U></FONT></B>" +
			"is <FONT size='5'>Cool!</FONT></P>";

    string strRTF = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}}\viewkind4\uc1\pard\f0\fs20 The \ul\b\fs24 Clipboard\ulnone\b0  \fs20 is \fs36 Cool!\par}";

    string strXML = "<?xml version='1.0'?><Message>The Clipboard is Cool!</Message>";

    // myImage holds a Bitmap image of two dogs in memory.

    System.Drawing.Bitmap myImage = new System.Drawing.Bitmap("..\\..\\twodogs.jpg");

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
    private System.Windows.Forms.MenuItem mnuEdit;
    private System.Windows.Forms.TextBox txtPaste;
    private System.Windows.Forms.RichTextBox rtbPaste;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.MenuItem mnuCopyTextAs;
    private System.Windows.Forms.MenuItem mnuCopyTextAsText;
    private System.Windows.Forms.MenuItem mnuCopyTextAsHTML;
    private System.Windows.Forms.MenuItem mnuCopyTextAsRTF;
    private System.Windows.Forms.MenuItem mnuCopyTextAsAllFormats;
    private System.Windows.Forms.MenuItem mnuCopyImageAs;
    private System.Windows.Forms.MenuItem mnuCopyImageAsBitmap;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.PictureBox picturePaste;
    private System.Windows.Forms.MenuItem mnuCopyTextAsXML;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
        this.mnuMain = new System.Windows.Forms.MainMenu();
        this.mnuFile = new System.Windows.Forms.MenuItem();
        this.mnuExit = new System.Windows.Forms.MenuItem();
        this.mnuEdit = new System.Windows.Forms.MenuItem();
        this.mnuCopyTextAs = new System.Windows.Forms.MenuItem();
        this.mnuCopyTextAsText = new System.Windows.Forms.MenuItem();
        this.mnuCopyTextAsHTML = new System.Windows.Forms.MenuItem();
        this.mnuCopyTextAsRTF = new System.Windows.Forms.MenuItem();
        this.mnuCopyTextAsXML = new System.Windows.Forms.MenuItem();
        this.mnuCopyTextAsAllFormats = new System.Windows.Forms.MenuItem();
        this.mnuCopyImageAs = new System.Windows.Forms.MenuItem();
        this.mnuCopyImageAsBitmap = new System.Windows.Forms.MenuItem();
        this.mnuHelp = new System.Windows.Forms.MenuItem();
        this.mnuAbout = new System.Windows.Forms.MenuItem();
        this.txtPaste = new System.Windows.Forms.TextBox();
        this.rtbPaste = new System.Windows.Forms.RichTextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.picturePaste = new System.Windows.Forms.PictureBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        //
        //mnuMain
        //
        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuEdit, this.mnuHelp});
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
        //mnuEdit
        //
        this.mnuEdit.Enabled = (bool) resources.GetObject("mnuEdit.Enabled");
        this.mnuEdit.Index = 1;
        this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuCopyTextAs, this.mnuCopyImageAs});
        this.mnuEdit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuEdit.Shortcut");
        this.mnuEdit.ShowShortcut = (bool) resources.GetObject("mnuEdit.ShowShortcut");
        this.mnuEdit.Text = resources.GetString("mnuEdit.Text");
        this.mnuEdit.Visible = (bool) resources.GetObject("mnuEdit.Visible");
        //
        //mnuCopyTextAs
        //
        this.mnuCopyTextAs.Enabled = (bool) resources.GetObject("mnuCopyTextAs.Enabled");
        this.mnuCopyTextAs.Index = 0;
        this.mnuCopyTextAs.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuCopyTextAsText, this.mnuCopyTextAsHTML, this.mnuCopyTextAsRTF, this.mnuCopyTextAsXML, this.mnuCopyTextAsAllFormats});
        this.mnuCopyTextAs.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCopyTextAs.Shortcut");
        this.mnuCopyTextAs.ShowShortcut = (bool) resources.GetObject("mnuCopyTextAs.ShowShortcut");
        this.mnuCopyTextAs.Text = resources.GetString("mnuCopyTextAs.Text");
        this.mnuCopyTextAs.Visible = (bool) resources.GetObject("mnuCopyTextAs.Visible");
        //
        //mnuCopyTextAsText
        //
        this.mnuCopyTextAsText.Enabled = (bool) resources.GetObject("mnuCopyTextAsText.Enabled");
        this.mnuCopyTextAsText.Index = 0;
        this.mnuCopyTextAsText.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCopyTextAsText.Shortcut");
        this.mnuCopyTextAsText.ShowShortcut = (bool) resources.GetObject("mnuCopyTextAsText.ShowShortcut");
        this.mnuCopyTextAsText.Text = resources.GetString("mnuCopyTextAsText.Text");
        this.mnuCopyTextAsText.Visible = (bool) resources.GetObject("mnuCopyTextAsText.Visible");
        //
        //mnuCopyTextAsHTML
        //
        this.mnuCopyTextAsHTML.Enabled = (bool) resources.GetObject("mnuCopyTextAsHTML.Enabled");
        this.mnuCopyTextAsHTML.Index = 1;
        this.mnuCopyTextAsHTML.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCopyTextAsHTML.Shortcut");
        this.mnuCopyTextAsHTML.ShowShortcut = (bool) resources.GetObject("mnuCopyTextAsHTML.ShowShortcut");
        this.mnuCopyTextAsHTML.Text = resources.GetString("mnuCopyTextAsHTML.Text");
        this.mnuCopyTextAsHTML.Visible = (bool) resources.GetObject("mnuCopyTextAsHTML.Visible");
        //
        //mnuCopyTextAsRTF
        //
        this.mnuCopyTextAsRTF.Enabled = (bool) resources.GetObject("mnuCopyTextAsRTF.Enabled");
        this.mnuCopyTextAsRTF.Index = 2;
        this.mnuCopyTextAsRTF.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCopyTextAsRTF.Shortcut");
        this.mnuCopyTextAsRTF.ShowShortcut = (bool) resources.GetObject("mnuCopyTextAsRTF.ShowShortcut");
        this.mnuCopyTextAsRTF.Text = resources.GetString("mnuCopyTextAsRTF.Text");
        this.mnuCopyTextAsRTF.Visible = (bool) resources.GetObject("mnuCopyTextAsRTF.Visible");
        //
        //mnuCopyTextAsXML
        //
        this.mnuCopyTextAsXML.Enabled = (bool) resources.GetObject("mnuCopyTextAsXML.Enabled");
        this.mnuCopyTextAsXML.Index = 3;
        this.mnuCopyTextAsXML.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCopyTextAsXML.Shortcut");
        this.mnuCopyTextAsXML.ShowShortcut = (bool) resources.GetObject("mnuCopyTextAsXML.ShowShortcut");
        this.mnuCopyTextAsXML.Text = resources.GetString("mnuCopyTextAsXML.Text");
        this.mnuCopyTextAsXML.Visible = (bool) resources.GetObject("mnuCopyTextAsXML.Visible");
        //
        //mnuCopyTextAsAllFormats
        //
        this.mnuCopyTextAsAllFormats.Enabled = (bool) resources.GetObject("mnuCopyTextAsAllFormats.Enabled");
        this.mnuCopyTextAsAllFormats.Index = 4;
        this.mnuCopyTextAsAllFormats.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCopyTextAsAllFormats.Shortcut");
        this.mnuCopyTextAsAllFormats.ShowShortcut = (bool) resources.GetObject("mnuCopyTextAsAllFormats.ShowShortcut");
        this.mnuCopyTextAsAllFormats.Text = resources.GetString("mnuCopyTextAsAllFormats.Text");
        this.mnuCopyTextAsAllFormats.Visible = (bool) resources.GetObject("mnuCopyTextAsAllFormats.Visible");
        //
        //mnuCopyImageAs
        //
        this.mnuCopyImageAs.Enabled = (bool) resources.GetObject("mnuCopyImageAs.Enabled");
        this.mnuCopyImageAs.Index = 1;
        this.mnuCopyImageAs.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuCopyImageAsBitmap});
        this.mnuCopyImageAs.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCopyImageAs.Shortcut");
        this.mnuCopyImageAs.ShowShortcut = (bool) resources.GetObject("mnuCopyImageAs.ShowShortcut");
        this.mnuCopyImageAs.Text = resources.GetString("mnuCopyImageAs.Text");
        this.mnuCopyImageAs.Visible = (bool) resources.GetObject("mnuCopyImageAs.Visible");
        //
        //mnuCopyImageAsBitmap
        //
        this.mnuCopyImageAsBitmap.Enabled = (bool) resources.GetObject("mnuCopyImageAsBitmap.Enabled");
        this.mnuCopyImageAsBitmap.Index = 0;
        this.mnuCopyImageAsBitmap.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuCopyImageAsBitmap.Shortcut");
        this.mnuCopyImageAsBitmap.ShowShortcut = (bool) resources.GetObject("mnuCopyImageAsBitmap.ShowShortcut");
        this.mnuCopyImageAsBitmap.Text = resources.GetString("mnuCopyImageAsBitmap.Text");
        this.mnuCopyImageAsBitmap.Visible = (bool) resources.GetObject("mnuCopyImageAsBitmap.Visible");
        //
        //mnuHelp
        //
        this.mnuHelp.Enabled = (bool) resources.GetObject("mnuHelp.Enabled");
        this.mnuHelp.Index = 2;
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
        //txtPaste
        //
        this.txtPaste.AccessibleDescription = (string) resources.GetObject("txtPaste.AccessibleDescription");
        this.txtPaste.AccessibleName = (string) resources.GetObject("txtPaste.AccessibleName");
        this.txtPaste.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtPaste.Anchor");
        this.txtPaste.AutoSize = (bool) resources.GetObject("txtPaste.AutoSize");
        this.txtPaste.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtPaste.BackgroundImage");
        this.txtPaste.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtPaste.Dock");
        this.txtPaste.Enabled = (bool) resources.GetObject("txtPaste.Enabled");
        this.txtPaste.Font = (System.Drawing.Font) resources.GetObject("txtPaste.Font");
        this.txtPaste.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtPaste.ImeMode");
        this.txtPaste.Location = (System.Drawing.Point) resources.GetObject("txtPaste.Location");
        this.txtPaste.MaxLength = (int) resources.GetObject("txtPaste.MaxLength");
        this.txtPaste.Multiline = (bool) resources.GetObject("txtPaste.Multiline");

        this.txtPaste.Name = "txtPaste";
        this.txtPaste.PasswordChar = (char) resources.GetObject("txtPaste.PasswordChar");
        this.txtPaste.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtPaste.RightToLeft");
        this.txtPaste.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtPaste.ScrollBars");
        this.txtPaste.Size = (System.Drawing.Size) resources.GetObject("txtPaste.Size");
        this.txtPaste.TabIndex = (int) resources.GetObject("txtPaste.TabIndex");
        this.txtPaste.Text = resources.GetString("txtPaste.Text");
        this.txtPaste.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtPaste.TextAlign");
        this.txtPaste.Visible = (bool) resources.GetObject("txtPaste.Visible");
        this.txtPaste.WordWrap = (bool) resources.GetObject("txtPaste.WordWrap");
        //
        //rtbPaste

        //

        this.rtbPaste.AccessibleDescription = (string) resources.GetObject("rtbPaste.AccessibleDescription");

        this.rtbPaste.AccessibleName = (string) resources.GetObject("rtbPaste.AccessibleName");

        this.rtbPaste.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rtbPaste.Anchor");

        this.rtbPaste.AutoSize = (bool) resources.GetObject("rtbPaste.AutoSize");

        this.rtbPaste.BackgroundImage = (System.Drawing.Image) resources.GetObject("rtbPaste.BackgroundImage");

        this.rtbPaste.BulletIndent = (int) resources.GetObject("rtbPaste.BulletIndent");

        this.rtbPaste.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rtbPaste.Dock");

        this.rtbPaste.Enabled = (bool) resources.GetObject("rtbPaste.Enabled");

        this.rtbPaste.Font = (System.Drawing.Font) resources.GetObject("rtbPaste.Font");

        this.rtbPaste.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rtbPaste.ImeMode");

        this.rtbPaste.Location = (System.Drawing.Point) resources.GetObject("rtbPaste.Location");

        this.rtbPaste.MaxLength = (int) resources.GetObject("rtbPaste.MaxLength");

        this.rtbPaste.Multiline = (bool) resources.GetObject("rtbPaste.Multiline");

        this.rtbPaste.Name = "rtbPaste";

        this.rtbPaste.RightMargin = (int) resources.GetObject("rtbPaste.RightMargin");

        this.rtbPaste.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rtbPaste.RightToLeft");

        this.rtbPaste.ScrollBars = (System.Windows.Forms.RichTextBoxScrollBars) resources.GetObject("rtbPaste.ScrollBars");

        this.rtbPaste.Size = (System.Drawing.Size) resources.GetObject("rtbPaste.Size");

        this.rtbPaste.TabIndex = (int) resources.GetObject("rtbPaste.TabIndex");

        this.rtbPaste.Text = resources.GetString("rtbPaste.Text");

        this.rtbPaste.Visible = (bool) resources.GetObject("rtbPaste.Visible");

        this.rtbPaste.WordWrap = (bool) resources.GetObject("rtbPaste.WordWrap");

        this.rtbPaste.ZoomFactor = (Single) resources.GetObject("rtbPaste.ZoomFactor");

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

        this.Label2.AccessibleDescription = (string) resources.GetObject("Label2.AccessibleDescription");

        this.Label2.AccessibleName = (string) resources.GetObject("Label2.AccessibleName");

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

        //picturePaste

        //

        this.picturePaste.AccessibleDescription = (string) resources.GetObject("picturePaste.AccessibleDescription");

        this.picturePaste.AccessibleName = (string) resources.GetObject("picturePaste.AccessibleName");

        this.picturePaste.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("picturePaste.Anchor");

        this.picturePaste.BackColor = System.Drawing.SystemColors.Window;

        this.picturePaste.BackgroundImage = (System.Drawing.Image) resources.GetObject("picturePaste.BackgroundImage");

        this.picturePaste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.picturePaste.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("picturePaste.Dock");

        this.picturePaste.Enabled = (bool) resources.GetObject("picturePaste.Enabled");

        this.picturePaste.Font = (System.Drawing.Font) resources.GetObject("picturePaste.Font");

        this.picturePaste.Image = (System.Drawing.Image) resources.GetObject("picturePaste.Image");

        this.picturePaste.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("picturePaste.ImeMode");

        this.picturePaste.Location = (System.Drawing.Point) resources.GetObject("picturePaste.Location");

        this.picturePaste.Name = "picturePaste";

        this.picturePaste.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("picturePaste.RightToLeft");

        this.picturePaste.Size = (System.Drawing.Size) resources.GetObject("picturePaste.Size");

        this.picturePaste.SizeMode = (System.Windows.Forms.PictureBoxSizeMode) resources.GetObject("picturePaste.SizeMode");

        this.picturePaste.TabIndex = (int) resources.GetObject("picturePaste.TabIndex");

        this.picturePaste.TabStop = false;

        this.picturePaste.Text = resources.GetString("picturePaste.Text");

        this.picturePaste.Visible = (bool) resources.GetObject("picturePaste.Visible");

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

        //Label4

        //

        this.Label4.AccessibleDescription = (string) resources.GetObject("Label4.AccessibleDescription");

        this.Label4.AccessibleName = (string) resources.GetObject("Label4.AccessibleName");

        this.Label4.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label4.Anchor");

        this.Label4.AutoSize = (bool) resources.GetObject("Label4.AutoSize");

        this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label4, this.Label3, this.picturePaste, this.Label2, this.Label1, this.rtbPaste, this.txtPaste});

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

		this.mnuCopyImageAsBitmap.Click +=new System.EventHandler(mnuCopyImageAsBitmap_Click);
		this.mnuCopyTextAsAllFormats.Click += new System.EventHandler(mnuCopyTextAsAllFormats_Click);
		this.mnuCopyTextAsHTML.Click +=new System.EventHandler(mnuCopyTextAsHTML_Click);
		this.mnuCopyTextAsRTF.Click +=new System.EventHandler(mnuCopyTextAsRTF_Click);
		this.mnuCopyTextAsText.Click +=new System.EventHandler(mnuCopyTextAsText_Click);
		this.mnuCopyTextAsXML.Click +=new System.EventHandler(mnuCopyTextAsXML_Click);
		this.mnuEdit.Popup+=new System.EventHandler(mnuEdit_Popup);
    }

#endregion

#region " Standard Menu Code "

	// has been added to some procedures since they are
	// not the focus of the demo. Remove them if you wish to debug the procedures.
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

    // Copy an image of two dogs to the Clipboard as a bitmap.

    private void mnuCopyImageAsBitmap_Click(object sender, System.EventArgs e)
	{
        DataObject myDataObject = new DataObject();
        myDataObject.SetData(DataFormats.Bitmap, true, myImage);
        Clipboard.SetDataObject(myDataObject, true);
    }

    // Copy "The Clipboard is Cool!" to the Clipboard as all available
    //   formats. This can only be done by using a DataObject instance.
    //   The SetData method is called for all formats, along with their
    //   format name.

    private void mnuCopyTextAsAllFormats_Click(object sender, System.EventArgs e)
	{
        DataObject myDataObject = new DataObject();
        // Place text version in DataObject as text and unicode
        myDataObject.SetData(DataFormats.Text, strText);
        myDataObject.SetData(DataFormats.UnicodeText, strText);
        // Place HTML version in DataObject 
        myDataObject.SetData(DataFormats.Html, strHTML);
        // Place RTF version in DataObject 
        myDataObject.SetData(DataFormats.Rtf, strRTF);
        // Place XML version in DataObject 
        myDataObject.SetData("MyInternalXmlFormat", strXML);
        // Now place myDataObject, and thus all formats on the Clipboard
        Clipboard.SetDataObject(myDataObject, true);
    }

    // Copy "The Clipboard is Cool!" to the Clipboard as HTML.
    // Here the HTML is first added to a DataObject so that the proper
    // format can be specified.

    private void mnuCopyTextAsHTML_Click(object sender, System.EventArgs e)
	{
        DataObject myDataObject = new DataObject();
        myDataObject.SetData(DataFormats.Html, strHTML);
        Clipboard.SetDataObject(myDataObject, true);

    }

    // Copy "The Clipboard is Cool!" to the Clipboard as RTF.
    // Here the RTF is first added to a DataObject so that the proper
    // format can be specified.

    private void mnuCopyTextAsRTF_Click(object sender, System.EventArgs e)
	{
        DataObject myDataObject = new DataObject();
        myDataObject.SetData(DataFormats.Rtf, strRTF);
        Clipboard.SetDataObject(myDataObject, true);
    }

    // Copy "The Clipboard is Cool!" to the Clipboard as text.
    // Here the text is simply copied directly to the clipboard.

    private void mnuCopyTextAsText_Click(object sender, System.EventArgs e)
	{
        Clipboard.SetDataObject(strText, true);
    }

    // Copy "The Clipboard is Cool!" to the Clipboard as XML.
    // Here the XML is first added to a DataObject so that the proper
    // format can be specified.
    // Since XML is not inherently supported by the clipboard (except as 
    // Unicode Text), this represents a proprietary format. Since this 
    // format will likely have little meaning outside of this application,
    // the second parameter has been set to false, forcing the Clipboard to 
    // not allow other applications access to this data.

    private void mnuCopyTextAsXML_Click(object sender, System.EventArgs e)
{
        DataObject myDataObject = new DataObject();
        myDataObject.SetData("MyInternalXmlFormat", strXML);
        Clipboard.SetDataObject(myDataObject, false);

    }

    // MnuEdit_Popup ensures that the when the Edit menu is clicked that
    // the Paste menu item is fully populated with only those formats
    // that the Clipboard can support. 

    private void mnuEdit_Popup(object sender, System.EventArgs e)
	{
        MenuItem myPasteAsMenu; // Used to build the Paste menu;
		MenuItem[] myTypes = null;
        string[] strArray = null;  // array of different supported formats;

        // if the Clipboard is not empty, fill strArray with a 
        // list of all supported formats
        if (Clipboard.GetDataObject() != null) {

            // GetFormats() returns a string array with the suppored formats

            strArray = Clipboard.GetDataObject().GetFormats();
            myTypes = new MenuItem[strArray.Length];

            // Create several new MenuItems each using the 
            // PasteAsMenuEventHandler method as the event handler.

            for (int i = 0; i < strArray.Length; i++)
				{
                myTypes[i] = new MenuItem(strArray[i], new System.EventHandler(PasteAsMenuEventHandler));
            }

        }

        // Ensure that the .NET Framework handles showing the menu

        this.mnuEdit.OwnerDraw = false;
        // Create the Paste menu, with the available formats
        // as sub-menu items.

        myPasteAsMenu = new MenuItem("&Paste As", myTypes);
        // if it has been added before, delete it.

        if (mnuEdit.MenuItems.Count == 3) {
            mnuEdit.MenuItems.RemoveAt(2);
        }

        // Add the Paste menu to the Edit menu.
        this.mnuEdit.MenuItems.Add(myPasteAsMenu);

    }

    // PasteAsMenuEventHandler handles all of the Paste commands, regardless
    // of what format was selected. The string name of the format is passed
    // as the Text in the sending MenuItem.

    private void PasteAsMenuEventHandler(object sender, System.EventArgs e)
	{
        string strType; // holds the value of the Format;
        object obj; // used to hold data to be pasted;
        // Clear all output boxes for this paste
        this.rtbPaste.Clear();
        this.txtPaste.Clear();
        this.picturePaste.Image = null;
        // Get the user selected format as a string.
        strType = ((MenuItem)(sender)).Text;

        // Ensure that the Clipboard can support the selected format

        if (Clipboard.GetDataObject().GetDataPresent(strType)) {
            // Set obj to the data on the clipboard, in the requested format
            obj = Clipboard.GetDataObject().GetData(strType);
            if (obj != null) {
                // Paste into the RichTextBox using the Paste() method
                this.rtbPaste.Paste(DataFormats.GetFormat(strType));
                // Paste the textual representation into the TextBox
				if (obj.GetType().ToString() == "System.string") 
				{
					this.txtPaste.AppendText((string)obj);
				}
				else 
				{
					this.txtPaste.AppendText(obj.GetType().ToString());
				}

                // Attempt to paste into the PictureBox
                //   if it fails, the PictureBox does not support this
                //   format, so clear the image by setting Image to null.
                try {

                    picturePaste.Image = (Image) obj;

               } catch
				{
                    picturePaste.Image = null;
                }

            }

        }

    }

}

