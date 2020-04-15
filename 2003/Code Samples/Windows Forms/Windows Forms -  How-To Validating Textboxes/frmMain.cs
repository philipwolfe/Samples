//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

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
    private System.Windows.Forms.Label Label1;
    private RegExTextBox rexUsZipcode;
    private System.Windows.Forms.Label Label2;
    private EMailTextBox rexEmail;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.Label Label4;
    private SsnTextBox rexSsn;
    private System.Windows.Forms.Label Label5;
    private PhoneTextBox rexPhone;
    private System.Windows.Forms.Button Button1;
    private System.Windows.Forms.TextBox txtInvalidControls;
    private IPAddressTextBox rexIpAddress;

	private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.Label1 = new System.Windows.Forms.Label();

        this.rexUsZipcode = new RegExTextBox();

        this.Label2 = new System.Windows.Forms.Label();

        this.rexEmail = new EMailTextBox();

        this.Label3 = new System.Windows.Forms.Label();

        this.rexIpAddress = new IPAddressTextBox();

        this.Label4 = new System.Windows.Forms.Label();

        this.rexSsn = new SsnTextBox();

        this.Label5 = new System.Windows.Forms.Label();

        this.rexPhone = new PhoneTextBox();

        this.Button1 = new System.Windows.Forms.Button();

        this.txtInvalidControls = new System.Windows.Forms.TextBox();

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

        //rexUsZipcode

        //

        this.rexUsZipcode.AccessibleDescription = (string) resources.GetObject("rexUsZipcode.AccessibleDescription");

        this.rexUsZipcode.AccessibleName = (string) resources.GetObject("rexUsZipcode.AccessibleName");

        this.rexUsZipcode.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rexUsZipcode.Anchor");

        this.rexUsZipcode.AutoSize = (bool) resources.GetObject("rexUsZipcode.AutoSize");

        this.rexUsZipcode.BackgroundImage = (System.Drawing.Image) resources.GetObject("rexUsZipcode.BackgroundImage");

        this.rexUsZipcode.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rexUsZipcode.Dock");

        this.rexUsZipcode.Enabled = (bool) resources.GetObject("rexUsZipcode.Enabled");

        this.rexUsZipcode.ErrorColor = System.Drawing.Color.Red;

        this.rexUsZipcode.ErrorMessage = "The zip-code must be in the format 55555";

        this.rexUsZipcode.Font = (System.Drawing.Font) resources.GetObject("rexUsZipcode.Font");

        this.rexUsZipcode.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rexUsZipcode.ImeMode");

        this.rexUsZipcode.Location = (System.Drawing.Point) resources.GetObject("rexUsZipcode.Location");

        this.rexUsZipcode.MaxLength = (int) resources.GetObject("rexUsZipcode.MaxLength");

        this.rexUsZipcode.Multiline = (bool) resources.GetObject("rexUsZipcode.Multiline");

        this.rexUsZipcode.Name = "rexUsZipcode";

        this.rexUsZipcode.PasswordChar = (Char) resources.GetObject("rexUsZipcode.PasswordChar");

        this.rexUsZipcode.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rexUsZipcode.RightToLeft");

        this.rexUsZipcode.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("rexUsZipcode.ScrollBars");

        this.rexUsZipcode.Size = (System.Drawing.Size) resources.GetObject("rexUsZipcode.Size");

        this.rexUsZipcode.TabIndex = (int) resources.GetObject("rexUsZipcode.TabIndex");

        this.rexUsZipcode.Text = resources.GetString("rexUsZipcode.Text");

        this.rexUsZipcode.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("rexUsZipcode.TextAlign");

        this.rexUsZipcode.ValidationExpression = @"^\d{5}$";

        this.rexUsZipcode.Visible = (bool) resources.GetObject("rexUsZipcode.Visible");

        this.rexUsZipcode.WordWrap = (bool) resources.GetObject("rexUsZipcode.WordWrap");

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

        //rexEmail

        //

        this.rexEmail.AccessibleDescription = (string) resources.GetObject("rexEmail.AccessibleDescription");

        this.rexEmail.AccessibleName = (string) resources.GetObject("rexEmail.AccessibleName");

        this.rexEmail.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rexEmail.Anchor");

        this.rexEmail.AutoSize = (bool) resources.GetObject("rexEmail.AutoSize");

        this.rexEmail.BackgroundImage = (System.Drawing.Image) resources.GetObject("rexEmail.BackgroundImage");

        this.rexEmail.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rexEmail.Dock");

        this.rexEmail.Enabled = (bool) resources.GetObject("rexEmail.Enabled");

        this.rexEmail.ErrorColor = System.Drawing.Color.Red;

        this.rexEmail.ErrorMessage = "The e-mail address must be in the form of abc@microsoft.com";

        this.rexEmail.Font = (System.Drawing.Font) resources.GetObject("rexEmail.Font");

        this.rexEmail.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rexEmail.ImeMode");

        this.rexEmail.Location = (System.Drawing.Point) resources.GetObject("rexEmail.Location");

        this.rexEmail.MaxLength = (int) resources.GetObject("rexEmail.MaxLength");

        this.rexEmail.Multiline = (bool) resources.GetObject("rexEmail.Multiline");

        this.rexEmail.Name = "rexEmail";

        this.rexEmail.PasswordChar = (Char) resources.GetObject("rexEmail.PasswordChar");

        this.rexEmail.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rexEmail.RightToLeft");

        this.rexEmail.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("rexEmail.ScrollBars");

        this.rexEmail.Size = (System.Drawing.Size) resources.GetObject("rexEmail.Size");

        this.rexEmail.TabIndex = (int) resources.GetObject("rexEmail.TabIndex");

        this.rexEmail.Text = resources.GetString("rexEmail.Text");

        this.rexEmail.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("rexEmail.TextAlign");

        this.rexEmail.ValidationExpression = @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$";

        this.rexEmail.Visible = (bool) resources.GetObject("rexEmail.Visible");

        this.rexEmail.WordWrap = (bool) resources.GetObject("rexEmail.WordWrap");

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

        //rexIpAddress

        //

        this.rexIpAddress.AccessibleDescription = (string) resources.GetObject("rexIpAddress.AccessibleDescription");

        this.rexIpAddress.AccessibleName = (string) resources.GetObject("rexIpAddress.AccessibleName");

        this.rexIpAddress.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rexIpAddress.Anchor");

        this.rexIpAddress.AutoSize = (bool) resources.GetObject("rexIpAddress.AutoSize");

        this.rexIpAddress.BackgroundImage = (System.Drawing.Image) resources.GetObject("rexIpAddress.BackgroundImage");

        this.rexIpAddress.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rexIpAddress.Dock");

        this.rexIpAddress.Enabled = (bool) resources.GetObject("rexIpAddress.Enabled");

        this.rexIpAddress.ErrorColor = System.Drawing.Color.Red;

        this.rexIpAddress.ErrorMessage = "The IP address must be in the form of 111.111.111.111";

        this.rexIpAddress.Font = (System.Drawing.Font) resources.GetObject("rexIpAddress.Font");

        this.rexIpAddress.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rexIpAddress.ImeMode");

        this.rexIpAddress.Location = (System.Drawing.Point) resources.GetObject("rexIpAddress.Location");

        this.rexIpAddress.MaxLength = (int) resources.GetObject("rexIpAddress.MaxLength");

        this.rexIpAddress.Multiline = (bool) resources.GetObject("rexIpAddress.Multiline");

        this.rexIpAddress.Name = "rexIpAddress";

        this.rexIpAddress.PasswordChar = (Char) resources.GetObject("rexIpAddress.PasswordChar");

        this.rexIpAddress.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rexIpAddress.RightToLeft");

        this.rexIpAddress.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("rexIpAddress.ScrollBars");

        this.rexIpAddress.Size = (System.Drawing.Size) resources.GetObject("rexIpAddress.Size");

        this.rexIpAddress.TabIndex = (int) resources.GetObject("rexIpAddress.TabIndex");

        this.rexIpAddress.Text = resources.GetString("rexIpAddress.Text");

        this.rexIpAddress.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("rexIpAddress.TextAlign");

        this.rexIpAddress.ValidationExpression = @"^((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])$";

        this.rexIpAddress.Visible = (bool) resources.GetObject("rexIpAddress.Visible");

        this.rexIpAddress.WordWrap = (bool) resources.GetObject("rexIpAddress.WordWrap");

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

        //rexSsn

        //

        this.rexSsn.AccessibleDescription = (string) resources.GetObject("rexSsn.AccessibleDescription");

        this.rexSsn.AccessibleName = (string) resources.GetObject("rexSsn.AccessibleName");

        this.rexSsn.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rexSsn.Anchor");

        this.rexSsn.AutoSize = (bool) resources.GetObject("rexSsn.AutoSize");

        this.rexSsn.BackgroundImage = (System.Drawing.Image) resources.GetObject("rexSsn.BackgroundImage");

        this.rexSsn.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rexSsn.Dock");

        this.rexSsn.Enabled = (bool) resources.GetObject("rexSsn.Enabled");

        this.rexSsn.ErrorColor = System.Drawing.Color.Red;

        this.rexSsn.ErrorMessage = "The social security number must be in the form of 555-55-5555";

        this.rexSsn.Font = (System.Drawing.Font) resources.GetObject("rexSsn.Font");

        this.rexSsn.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rexSsn.ImeMode");

        this.rexSsn.Location = (System.Drawing.Point) resources.GetObject("rexSsn.Location");

        this.rexSsn.MaxLength = (int) resources.GetObject("rexSsn.MaxLength");

        this.rexSsn.Multiline = (bool) resources.GetObject("rexSsn.Multiline");

        this.rexSsn.Name = "rexSsn";

        this.rexSsn.PasswordChar = (Char) resources.GetObject("rexSsn.PasswordChar");

        this.rexSsn.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rexSsn.RightToLeft");

        this.rexSsn.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("rexSsn.ScrollBars");

        this.rexSsn.Size = (System.Drawing.Size) resources.GetObject("rexSsn.Size");

        this.rexSsn.TabIndex = (int) resources.GetObject("rexSsn.TabIndex");

        this.rexSsn.Text = resources.GetString("rexSsn.Text");

        this.rexSsn.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("rexSsn.TextAlign");

        this.rexSsn.ValidationExpression = @"^\d{3}-\d{2}-\d{4}$";

        this.rexSsn.Visible = (bool) resources.GetObject("rexSsn.Visible");

        this.rexSsn.WordWrap = (bool) resources.GetObject("rexSsn.WordWrap");

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

        //rexPhone

        //

        this.rexPhone.AccessibleDescription = (string) resources.GetObject("rexPhone.AccessibleDescription");

        this.rexPhone.AccessibleName = (string) resources.GetObject("rexPhone.AccessibleName");

        this.rexPhone.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rexPhone.Anchor");

        this.rexPhone.AutoSize = (bool) resources.GetObject("rexPhone.AutoSize");

        this.rexPhone.BackgroundImage = (System.Drawing.Image) resources.GetObject("rexPhone.BackgroundImage");

        this.rexPhone.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rexPhone.Dock");

        this.rexPhone.Enabled = (bool) resources.GetObject("rexPhone.Enabled");

        this.rexPhone.ErrorColor = System.Drawing.Color.Red;

        this.rexPhone.ErrorMessage = "The phone number must be in the form of (555) 555-1212 or 555-555-1212.";

        this.rexPhone.Font = (System.Drawing.Font) resources.GetObject("rexPhone.Font");

        this.rexPhone.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rexPhone.ImeMode");

        this.rexPhone.Location = (System.Drawing.Point) resources.GetObject("rexPhone.Location");

        this.rexPhone.MaxLength = (int) resources.GetObject("rexPhone.MaxLength");

        this.rexPhone.Multiline = (bool) resources.GetObject("rexPhone.Multiline");

        this.rexPhone.Name = "rexPhone";

        this.rexPhone.PasswordChar = (Char) resources.GetObject("rexPhone.PasswordChar");

        this.rexPhone.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rexPhone.RightToLeft");

        this.rexPhone.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("rexPhone.ScrollBars");

        this.rexPhone.Size = (System.Drawing.Size) resources.GetObject("rexPhone.Size");

        this.rexPhone.TabIndex = (int) resources.GetObject("rexPhone.TabIndex");

        this.rexPhone.Text = resources.GetString("rexPhone.Text");

        this.rexPhone.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("rexPhone.TextAlign");

        this.rexPhone.ValidationExpression = @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$";

        this.rexPhone.Visible = (bool) resources.GetObject("rexPhone.Visible");

        this.rexPhone.WordWrap = (bool) resources.GetObject("rexPhone.WordWrap");

        //

        //Button1

        //

        this.Button1.AccessibleDescription = (string) resources.GetObject("Button1.AccessibleDescription");

        this.Button1.AccessibleName = (string) resources.GetObject("Button1.AccessibleName");

        this.Button1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Button1.Anchor");

        this.Button1.BackgroundImage = (System.Drawing.Image) resources.GetObject("Button1.BackgroundImage");

        this.Button1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Button1.Dock");

        this.Button1.Enabled = (bool) resources.GetObject("Button1.Enabled");

        this.Button1.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("Button1.FlatStyle");

        this.Button1.Font = (System.Drawing.Font) resources.GetObject("Button1.Font");

        this.Button1.Image = (System.Drawing.Image) resources.GetObject("Button1.Image");

        this.Button1.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Button1.ImageAlign");

        this.Button1.ImageIndex = (int) resources.GetObject("Button1.ImageIndex");

        this.Button1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Button1.ImeMode");

        this.Button1.Location = (System.Drawing.Point) resources.GetObject("Button1.Location");

        this.Button1.Name = "Button1";

        this.Button1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Button1.RightToLeft");

        this.Button1.Size = (System.Drawing.Size) resources.GetObject("Button1.Size");

        this.Button1.TabIndex = (int) resources.GetObject("Button1.TabIndex");

        this.Button1.Text = resources.GetString("Button1.Text");

        this.Button1.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Button1.TextAlign");

        this.Button1.Visible = (bool) resources.GetObject("Button1.Visible");
		this.Button1.Click += new EventHandler(Button1_Click);
        
        //

        //txtInvalidControls

        //

        this.txtInvalidControls.AccessibleDescription = (string) resources.GetObject("txtInvalidControls.AccessibleDescription");

        this.txtInvalidControls.AccessibleName = (string) resources.GetObject("txtInvalidControls.AccessibleName");

        this.txtInvalidControls.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtInvalidControls.Anchor");

        this.txtInvalidControls.AutoSize = (bool) resources.GetObject("txtInvalidControls.AutoSize");

        this.txtInvalidControls.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtInvalidControls.BackgroundImage");

        this.txtInvalidControls.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtInvalidControls.Dock");

        this.txtInvalidControls.Enabled = (bool) resources.GetObject("txtInvalidControls.Enabled");

        this.txtInvalidControls.Font = (System.Drawing.Font) resources.GetObject("txtInvalidControls.Font");

        this.txtInvalidControls.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtInvalidControls.ImeMode");

        this.txtInvalidControls.Location = (System.Drawing.Point) resources.GetObject("txtInvalidControls.Location");

        this.txtInvalidControls.MaxLength = (int) resources.GetObject("txtInvalidControls.MaxLength");

        this.txtInvalidControls.Multiline = (bool) resources.GetObject("txtInvalidControls.Multiline");

        this.txtInvalidControls.Name = "txtInvalidControls";

        this.txtInvalidControls.PasswordChar = (Char) resources.GetObject("txtInvalidControls.PasswordChar");

        this.txtInvalidControls.ReadOnly = true;

        this.txtInvalidControls.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtInvalidControls.RightToLeft");

        this.txtInvalidControls.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtInvalidControls.ScrollBars");

        this.txtInvalidControls.Size = (System.Drawing.Size) resources.GetObject("txtInvalidControls.Size");

        this.txtInvalidControls.TabIndex = (int) resources.GetObject("txtInvalidControls.TabIndex");

        this.txtInvalidControls.Text = resources.GetString("txtInvalidControls.Text");

        this.txtInvalidControls.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtInvalidControls.TextAlign");

        this.txtInvalidControls.Visible = (bool) resources.GetObject("txtInvalidControls.Visible");

        this.txtInvalidControls.WordWrap = (bool) resources.GetObject("txtInvalidControls.WordWrap");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtInvalidControls, this.Button1, this.rexPhone, this.Label5, this.Label4, this.Label3, this.Label2, this.Label1, this.rexSsn, this.rexIpAddress, this.rexEmail, this.rexUsZipcode});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

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

	// has been added to some procedures since they are
	// not the focus of the demo. Remove them if you wish to debug the procedures.
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

    private void Button1_Click(object sender, System.EventArgs e)
	{
		// Holds the message that will be displayed to the user indicating whether
        // all the controls contain valid input.
        string validationMessage = string.Empty;

        // Loop through all the controls on the form.
        foreach(Control genericControl in this.Controls)
		{
			Control ctrl = genericControl as RegExTextBox;

			// if the current control is a RegExTextBox, or inherits RegExTextbox
            if (ctrl != null)
			{
                // Cast it from a ctrl type to a RegExTextBox type.  This
                // will allow you to access the IsValid property
                RegExTextBox regExControl = (RegExTextBox) ctrl;

                // if the text in the control isn't correct, then add this control
                // to the list of invalid controls.
                if (!regExControl.IsValid)
				{
                    validationMessage += regExControl.Name + ":" + regExControl.ErrorMessage + Environment.NewLine;
                }
            }
        }

        // Are there any controls that contain invalid text?
		if (validationMessage != string.Empty)
		{
			// Output those controls in the textbox.
			txtInvalidControls.Text = "The following controls have invalid values : " + Environment.NewLine + validationMessage;
		}
		else 
		{
			// Otherwise, indicate that everything is ok.
			txtInvalidControls.Text = "All controls contain valid input";
		}
    }
}
