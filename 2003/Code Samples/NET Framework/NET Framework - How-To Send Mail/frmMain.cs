//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Web.Mail;
using System.Text;
using System.ServiceProcess;
using System.Collections;

public class frmMain: System.Windows.Forms.Form {

    // For use with the WndProc override routine

    const int WM_SYSCOMMAND = 0x112;
    const int SC_CLOSE = 0xF060;

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

    private System.Windows.Forms.Button btnSend;

    private System.Windows.Forms.Label lblFrom;

    private System.Windows.Forms.Label lblTo;

    private System.Windows.Forms.Label lblSubject;

    private System.Windows.Forms.Label lblBody;

    private System.Windows.Forms.Label lblBCC;

    private System.Windows.Forms.Label lblCC;

    private System.Windows.Forms.ErrorProvider erpEmailAddresses;

    private System.Windows.Forms.TextBox txtFrom;

    private System.Windows.Forms.TextBox txtTo;

    private System.Windows.Forms.TextBox txtSubject;

    private System.Windows.Forms.TextBox txtBody;

    private System.Windows.Forms.TextBox txtCC;

    private System.Windows.Forms.TextBox txtBCC;

    private System.Windows.Forms.ComboBox cboPriority;

    private System.Windows.Forms.Button btnBrowse;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.OpenFileDialog odlgAttachment;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.ListBox lstAttachments;

	private void InitializeComponent() 
	{

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.btnSend = new System.Windows.Forms.Button();

		this.txtFrom = new System.Windows.Forms.TextBox();

		this.lblFrom = new System.Windows.Forms.Label();

		this.lblTo = new System.Windows.Forms.Label();

		this.lblSubject = new System.Windows.Forms.Label();

		this.lblBody = new System.Windows.Forms.Label();

		this.txtTo = new System.Windows.Forms.TextBox();

		this.txtSubject = new System.Windows.Forms.TextBox();

		this.txtBody = new System.Windows.Forms.TextBox();

		this.txtCC = new System.Windows.Forms.TextBox();

		this.lblBCC = new System.Windows.Forms.Label();

		this.lblCC = new System.Windows.Forms.Label();

		this.erpEmailAddresses = new System.Windows.Forms.ErrorProvider();

		this.txtBCC = new System.Windows.Forms.TextBox();

		this.cboPriority = new System.Windows.Forms.ComboBox();

		this.btnBrowse = new System.Windows.Forms.Button();

		this.Label1 = new System.Windows.Forms.Label();

		this.lstAttachments = new System.Windows.Forms.ListBox();

		this.Label2 = new System.Windows.Forms.Label();

		this.odlgAttachment = new System.Windows.Forms.OpenFileDialog();

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

		//btnSend

		//

		this.btnSend.AccessibleDescription = (string) resources.GetObject("btnSend.AccessibleDescription");

		this.btnSend.AccessibleName = (string) resources.GetObject("btnSend.AccessibleName");

		this.btnSend.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSend.Anchor");

		this.btnSend.BackColor = System.Drawing.SystemColors.Control;

		this.btnSend.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSend.BackgroundImage");

		this.btnSend.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSend.Dock");

		this.btnSend.Enabled = (bool) resources.GetObject("btnSend.Enabled");

		this.erpEmailAddresses.SetError(this.btnSend, resources.GetString("btnSend.Error"));

		this.btnSend.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSend.FlatStyle");

		this.btnSend.Font = (System.Drawing.Font) resources.GetObject("btnSend.Font");

		this.btnSend.ForeColor = System.Drawing.SystemColors.ControlText;
        
		this.erpEmailAddresses.SetIconAlignment(this.btnSend, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("btnSend.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.btnSend, (int) resources.GetObject("btnSend.IconPadding"));

		this.btnSend.Image = (System.Drawing.Bitmap) resources.GetObject("btnSend.Image");

		this.btnSend.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSend.ImageAlign");

		this.btnSend.ImageIndex = (int) resources.GetObject("btnSend.ImageIndex");

		this.btnSend.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSend.ImeMode");

		this.btnSend.Location = (System.Drawing.Point) resources.GetObject("btnSend.Location");

		this.btnSend.Name = "btnSend";

		this.btnSend.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSend.RightToLeft");

		this.btnSend.Size = (System.Drawing.Size) resources.GetObject("btnSend.Size");

		this.btnSend.TabIndex = (int) resources.GetObject("btnSend.TabIndex");

		this.btnSend.Text = resources.GetString("btnSend.Text");

		this.btnSend.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSend.TextAlign");

		this.btnSend.Visible = (bool) resources.GetObject("btnSend.Visible");

		//

		//txtFrom

		//

		this.txtFrom.AccessibleDescription = (string) resources.GetObject("txtFrom.AccessibleDescription");

		this.txtFrom.AccessibleName = (string) resources.GetObject("txtFrom.AccessibleName");

		this.txtFrom.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtFrom.Anchor");

		this.txtFrom.AutoSize = (bool) resources.GetObject("txtFrom.AutoSize");

		this.txtFrom.BackColor = System.Drawing.SystemColors.Window;

		this.txtFrom.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtFrom.BackgroundImage");

		this.txtFrom.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtFrom.Dock");

		this.txtFrom.Enabled = (bool) resources.GetObject("txtFrom.Enabled");

		this.erpEmailAddresses.SetError(this.txtFrom, resources.GetString("txtFrom.Error"));

		this.txtFrom.Font = (System.Drawing.Font) resources.GetObject("txtFrom.Font");

		this.erpEmailAddresses.SetIconAlignment(this.txtFrom, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("txtFrom.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.txtFrom, (int) resources.GetObject("txtFrom.IconPadding"));

		this.txtFrom.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtFrom.ImeMode");

		this.txtFrom.Location = (System.Drawing.Point) resources.GetObject("txtFrom.Location");

		this.txtFrom.MaxLength = (int) resources.GetObject("txtFrom.MaxLength");

		this.txtFrom.Multiline = (bool) resources.GetObject("txtFrom.Multiline");

		this.txtFrom.Name = "txtFrom";

		this.txtFrom.PasswordChar = (char) resources.GetObject("txtFrom.PasswordChar");

		this.txtFrom.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtFrom.RightToLeft");

		this.txtFrom.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtFrom.ScrollBars");

		this.txtFrom.Size = (System.Drawing.Size) resources.GetObject("txtFrom.Size");

		this.txtFrom.TabIndex = (int) resources.GetObject("txtFrom.TabIndex");

		this.txtFrom.Text = resources.GetString("txtFrom.Text");

		this.txtFrom.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtFrom.TextAlign");

		this.txtFrom.Visible = (bool) resources.GetObject("txtFrom.Visible");

		this.txtFrom.WordWrap = (bool) resources.GetObject("txtFrom.WordWrap");

		//

		//lblFrom

		//

		this.lblFrom.AccessibleDescription = (string) resources.GetObject("lblFrom.AccessibleDescription");

		this.lblFrom.AccessibleName = (string) resources.GetObject("lblFrom.AccessibleName");

		this.lblFrom.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblFrom.Anchor");

		this.lblFrom.AutoSize = (bool) resources.GetObject("lblFrom.AutoSize");

		this.lblFrom.BackColor = System.Drawing.SystemColors.Control;

		this.lblFrom.CausesValidation = false;

		this.lblFrom.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblFrom.Dock");

		this.lblFrom.Enabled = (bool) resources.GetObject("lblFrom.Enabled");

		this.erpEmailAddresses.SetError(this.lblFrom, resources.GetString("lblFrom.Error"));

		this.lblFrom.Font = (System.Drawing.Font) resources.GetObject("lblFrom.Font");

		this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlText;

		this.erpEmailAddresses.SetIconAlignment(this.lblFrom, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("lblFrom.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.lblFrom, (int) resources.GetObject("lblFrom.IconPadding"));

		this.lblFrom.Image = (System.Drawing.Image) resources.GetObject("lblFrom.Image");

		this.lblFrom.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblFrom.ImageAlign");

		this.lblFrom.ImageIndex = (int) resources.GetObject("lblFrom.ImageIndex");

		this.lblFrom.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblFrom.ImeMode");

		this.lblFrom.Location = (System.Drawing.Point) resources.GetObject("lblFrom.Location");

		this.lblFrom.Name = "lblFrom";

		this.lblFrom.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblFrom.RightToLeft");

		this.lblFrom.Size = (System.Drawing.Size) resources.GetObject("lblFrom.Size");

		this.lblFrom.TabIndex = (int) resources.GetObject("lblFrom.TabIndex");

		this.lblFrom.Text = resources.GetString("lblFrom.Text");

		this.lblFrom.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblFrom.TextAlign");

		this.lblFrom.Visible = (bool) resources.GetObject("lblFrom.Visible");

		//

		//lblTo

		//

		this.lblTo.AccessibleDescription = (string) resources.GetObject("lblTo.AccessibleDescription");

		this.lblTo.AccessibleName = (string) resources.GetObject("lblTo.AccessibleName");

		this.lblTo.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblTo.Anchor");

		this.lblTo.AutoSize = (bool) resources.GetObject("lblTo.AutoSize");

		this.lblTo.BackColor = System.Drawing.SystemColors.Control;

		this.lblTo.CausesValidation = false;

		this.lblTo.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblTo.Dock");

		this.lblTo.Enabled = (bool) resources.GetObject("lblTo.Enabled");

		this.erpEmailAddresses.SetError(this.lblTo, resources.GetString("lblTo.Error"));

		this.lblTo.Font = (System.Drawing.Font) resources.GetObject("lblTo.Font");

		this.lblTo.ForeColor = System.Drawing.SystemColors.ControlText;

		this.erpEmailAddresses.SetIconAlignment(this.lblTo, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("lblTo.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.lblTo, (int) resources.GetObject("lblTo.IconPadding"));

		this.lblTo.Image = (System.Drawing.Image) resources.GetObject("lblTo.Image");

		this.lblTo.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTo.ImageAlign");

		this.lblTo.ImageIndex = (int) resources.GetObject("lblTo.ImageIndex");

		this.lblTo.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblTo.ImeMode");

		this.lblTo.Location = (System.Drawing.Point) resources.GetObject("lblTo.Location");

		this.lblTo.Name = "lblTo";

		this.lblTo.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblTo.RightToLeft");

		this.lblTo.Size = (System.Drawing.Size) resources.GetObject("lblTo.Size");

		this.lblTo.TabIndex = (int) resources.GetObject("lblTo.TabIndex");

		this.lblTo.Text = resources.GetString("lblTo.Text");

		this.lblTo.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTo.TextAlign");

		this.lblTo.Visible = (bool) resources.GetObject("lblTo.Visible");

		//

		//lblSubject

		//

		this.lblSubject.AccessibleDescription = (string) resources.GetObject("lblSubject.AccessibleDescription");

		this.lblSubject.AccessibleName = (string) resources.GetObject("lblSubject.AccessibleName");

		this.lblSubject.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblSubject.Anchor");

		this.lblSubject.AutoSize = (bool) resources.GetObject("lblSubject.AutoSize");

		this.lblSubject.BackColor = System.Drawing.SystemColors.Control;

		this.lblSubject.CausesValidation = false;

		this.lblSubject.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblSubject.Dock");

		this.lblSubject.Enabled = (bool) resources.GetObject("lblSubject.Enabled");

		this.erpEmailAddresses.SetError(this.lblSubject, resources.GetString("lblSubject.Error"));

		this.lblSubject.Font = (System.Drawing.Font) resources.GetObject("lblSubject.Font");

		this.lblSubject.ForeColor = System.Drawing.SystemColors.ControlText;

		this.erpEmailAddresses.SetIconAlignment(this.lblSubject, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("lblSubject.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.lblSubject, (int) resources.GetObject("lblSubject.IconPadding"));

		this.lblSubject.Image = (System.Drawing.Image) resources.GetObject("lblSubject.Image");

		this.lblSubject.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblSubject.ImageAlign");

		this.lblSubject.ImageIndex = (int) resources.GetObject("lblSubject.ImageIndex");

		this.lblSubject.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblSubject.ImeMode");

		this.lblSubject.Location = (System.Drawing.Point) resources.GetObject("lblSubject.Location");

		this.lblSubject.Name = "lblSubject";

		this.lblSubject.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblSubject.RightToLeft");

		this.lblSubject.Size = (System.Drawing.Size) resources.GetObject("lblSubject.Size");

		this.lblSubject.TabIndex = (int) resources.GetObject("lblSubject.TabIndex");

		this.lblSubject.Text = resources.GetString("lblSubject.Text");

		this.lblSubject.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblSubject.TextAlign");

		this.lblSubject.Visible = (bool) resources.GetObject("lblSubject.Visible");

		//

		//lblBody

		//

		this.lblBody.AccessibleDescription = (string) resources.GetObject("lblBody.AccessibleDescription");

		this.lblBody.AccessibleName = (string) resources.GetObject("lblBody.AccessibleName");

		this.lblBody.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblBody.Anchor");

		this.lblBody.AutoSize = (bool) resources.GetObject("lblBody.AutoSize");

		this.lblBody.BackColor = System.Drawing.SystemColors.Control;

		this.lblBody.CausesValidation = false;

		this.lblBody.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblBody.Dock");

		this.lblBody.Enabled = (bool) resources.GetObject("lblBody.Enabled");

		this.erpEmailAddresses.SetError(this.lblBody, resources.GetString("lblBody.Error"));

		this.lblBody.Font = (System.Drawing.Font) resources.GetObject("lblBody.Font");

		this.lblBody.ForeColor = System.Drawing.SystemColors.ControlText;

		this.erpEmailAddresses.SetIconAlignment(this.lblBody, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("lblBody.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.lblBody, (int) resources.GetObject("lblBody.IconPadding"));

		this.lblBody.Image = (System.Drawing.Image) resources.GetObject("lblBody.Image");

		this.lblBody.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblBody.ImageAlign");

		this.lblBody.ImageIndex = (int) resources.GetObject("lblBody.ImageIndex");

		this.lblBody.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblBody.ImeMode");

		this.lblBody.Location = (System.Drawing.Point) resources.GetObject("lblBody.Location");

		this.lblBody.Name = "lblBody";

		this.lblBody.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblBody.RightToLeft");

		this.lblBody.Size = (System.Drawing.Size) resources.GetObject("lblBody.Size");

		this.lblBody.TabIndex = (int) resources.GetObject("lblBody.TabIndex");

		this.lblBody.Text = resources.GetString("lblBody.Text");

		this.lblBody.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblBody.TextAlign");

		this.lblBody.Visible = (bool) resources.GetObject("lblBody.Visible");

		//

		//txtTo

		//

		this.txtTo.AccessibleDescription = (string) resources.GetObject("txtTo.AccessibleDescription");

		this.txtTo.AccessibleName = (string) resources.GetObject("txtTo.AccessibleName");

		this.txtTo.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtTo.Anchor");

		this.txtTo.AutoSize = (bool) resources.GetObject("txtTo.AutoSize");

		this.txtTo.BackColor = System.Drawing.SystemColors.Window;

		this.txtTo.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtTo.BackgroundImage");

		this.txtTo.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtTo.Dock");

		this.txtTo.Enabled = (bool) resources.GetObject("txtTo.Enabled");

		this.erpEmailAddresses.SetError(this.txtTo, resources.GetString("txtTo.Error"));

		this.txtTo.Font = (System.Drawing.Font) resources.GetObject("txtTo.Font");

		this.erpEmailAddresses.SetIconAlignment(this.txtTo, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("txtTo.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.txtTo, (int) resources.GetObject("txtTo.IconPadding"));

		this.txtTo.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtTo.ImeMode");

		this.txtTo.Location = (System.Drawing.Point) resources.GetObject("txtTo.Location");

		this.txtTo.MaxLength = (int) resources.GetObject("txtTo.MaxLength");

		this.txtTo.Multiline = (bool) resources.GetObject("txtTo.Multiline");

		this.txtTo.Name = "txtTo";

		this.txtTo.PasswordChar = (char) resources.GetObject("txtTo.PasswordChar");

		this.txtTo.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtTo.RightToLeft");

		this.txtTo.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtTo.ScrollBars");

		this.txtTo.Size = (System.Drawing.Size) resources.GetObject("txtTo.Size");

		this.txtTo.TabIndex = (int) resources.GetObject("txtTo.TabIndex");

		this.txtTo.Text = resources.GetString("txtTo.Text");

		this.txtTo.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtTo.TextAlign");

		this.txtTo.Visible = (bool) resources.GetObject("txtTo.Visible");

		this.txtTo.WordWrap = (bool) resources.GetObject("txtTo.WordWrap");

		//

		//txtSubject

		//

		this.txtSubject.AccessibleDescription = (string) resources.GetObject("txtSubject.AccessibleDescription");

		this.txtSubject.AccessibleName = (string) resources.GetObject("txtSubject.AccessibleName");

		this.txtSubject.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtSubject.Anchor");

		this.txtSubject.AutoSize = (bool) resources.GetObject("txtSubject.AutoSize");

		this.txtSubject.BackColor = System.Drawing.SystemColors.Window;

		this.txtSubject.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtSubject.BackgroundImage");

		this.txtSubject.CausesValidation = false;

		this.txtSubject.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtSubject.Dock");

		this.txtSubject.Enabled = (bool) resources.GetObject("txtSubject.Enabled");

		this.erpEmailAddresses.SetError(this.txtSubject, resources.GetString("txtSubject.Error"));

		this.txtSubject.Font = (System.Drawing.Font) resources.GetObject("txtSubject.Font");

		this.erpEmailAddresses.SetIconAlignment(this.txtSubject, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("txtSubject.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.txtSubject, (int) resources.GetObject("txtSubject.IconPadding"));

		this.txtSubject.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtSubject.ImeMode");

		this.txtSubject.Location = (System.Drawing.Point) resources.GetObject("txtSubject.Location");

		this.txtSubject.MaxLength = (int) resources.GetObject("txtSubject.MaxLength");

		this.txtSubject.Multiline = (bool) resources.GetObject("txtSubject.Multiline");

		this.txtSubject.Name = "txtSubject";

		this.txtSubject.PasswordChar = (char) resources.GetObject("txtSubject.PasswordChar");

		this.txtSubject.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtSubject.RightToLeft");

		this.txtSubject.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtSubject.ScrollBars");

		this.txtSubject.Size = (System.Drawing.Size) resources.GetObject("txtSubject.Size");

		this.txtSubject.TabIndex = (int) resources.GetObject("txtSubject.TabIndex");

		this.txtSubject.Text = resources.GetString("txtSubject.Text");

		this.txtSubject.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtSubject.TextAlign");

		this.txtSubject.Visible = (bool) resources.GetObject("txtSubject.Visible");

		this.txtSubject.WordWrap = (bool) resources.GetObject("txtSubject.WordWrap");

		//

		//txtBody

		//

		this.txtBody.AccessibleDescription = (string) resources.GetObject("txtBody.AccessibleDescription");

		this.txtBody.AccessibleName = (string) resources.GetObject("txtBody.AccessibleName");

		this.txtBody.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtBody.Anchor");

		this.txtBody.AutoSize = (bool) resources.GetObject("txtBody.AutoSize");

		this.txtBody.BackColor = System.Drawing.SystemColors.Window;

		this.txtBody.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtBody.BackgroundImage");

		this.txtBody.CausesValidation = false;

		this.txtBody.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtBody.Dock");

		this.txtBody.Enabled = (bool) resources.GetObject("txtBody.Enabled");

		this.erpEmailAddresses.SetError(this.txtBody, resources.GetString("txtBody.Error"));

		this.txtBody.Font = (System.Drawing.Font) resources.GetObject("txtBody.Font");

		this.erpEmailAddresses.SetIconAlignment(this.txtBody, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("txtBody.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.txtBody, (int) resources.GetObject("txtBody.IconPadding"));

		this.txtBody.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtBody.ImeMode");

		this.txtBody.Location = (System.Drawing.Point) resources.GetObject("txtBody.Location");

		this.txtBody.MaxLength = (int) resources.GetObject("txtBody.MaxLength");

		this.txtBody.Multiline = (bool) resources.GetObject("txtBody.Multiline");

		this.txtBody.Name = "txtBody";

		this.txtBody.PasswordChar = (char) resources.GetObject("txtBody.PasswordChar");

		this.txtBody.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtBody.RightToLeft");

		this.txtBody.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtBody.ScrollBars");

		this.txtBody.Size = (System.Drawing.Size) resources.GetObject("txtBody.Size");

		this.txtBody.TabIndex = (int) resources.GetObject("txtBody.TabIndex");

		this.txtBody.Text = resources.GetString("txtBody.Text");

		this.txtBody.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtBody.TextAlign");

		this.txtBody.Visible = (bool) resources.GetObject("txtBody.Visible");

		this.txtBody.WordWrap = (bool) resources.GetObject("txtBody.WordWrap");

		//

		//txtCC

		//

		this.txtCC.AccessibleDescription = (string) resources.GetObject("txtCC.AccessibleDescription");

		this.txtCC.AccessibleName = (string) resources.GetObject("txtCC.AccessibleName");

		this.txtCC.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCC.Anchor");

		this.txtCC.AutoSize = (bool) resources.GetObject("txtCC.AutoSize");

		this.txtCC.BackColor = System.Drawing.SystemColors.Window;

		this.txtCC.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCC.BackgroundImage");

		this.txtCC.CausesValidation = false;

		this.txtCC.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCC.Dock");

		this.txtCC.Enabled = (bool) resources.GetObject("txtCC.Enabled");

		this.erpEmailAddresses.SetError(this.txtCC, resources.GetString("txtCC.Error"));

		this.txtCC.Font = (System.Drawing.Font) resources.GetObject("txtCC.Font");

		this.erpEmailAddresses.SetIconAlignment(this.txtCC, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("txtCC.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.txtCC, (int) resources.GetObject("txtCC.IconPadding"));

		this.txtCC.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCC.ImeMode");

		this.txtCC.Location = (System.Drawing.Point) resources.GetObject("txtCC.Location");

		this.txtCC.MaxLength = (int) resources.GetObject("txtCC.MaxLength");

		this.txtCC.Multiline = (bool) resources.GetObject("txtCC.Multiline");

		this.txtCC.Name = "txtCC";

		this.txtCC.PasswordChar = (char) resources.GetObject("txtCC.PasswordChar");

		this.txtCC.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCC.RightToLeft");

		this.txtCC.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCC.ScrollBars");

		this.txtCC.Size = (System.Drawing.Size) resources.GetObject("txtCC.Size");

		this.txtCC.TabIndex = (int) resources.GetObject("txtCC.TabIndex");

		this.txtCC.Text = resources.GetString("txtCC.Text");

		this.txtCC.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCC.TextAlign");

		this.txtCC.Visible = (bool) resources.GetObject("txtCC.Visible");

		this.txtCC.WordWrap = (bool) resources.GetObject("txtCC.WordWrap");

		//

		//lblBCC

		//

		this.lblBCC.AccessibleDescription = (string) resources.GetObject("lblBCC.AccessibleDescription");

		this.lblBCC.AccessibleName = (string) resources.GetObject("lblBCC.AccessibleName");

		this.lblBCC.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblBCC.Anchor");

		this.lblBCC.AutoSize = (bool) resources.GetObject("lblBCC.AutoSize");

		this.lblBCC.BackColor = System.Drawing.SystemColors.Control;

		this.lblBCC.CausesValidation = false;

		this.lblBCC.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblBCC.Dock");

		this.lblBCC.Enabled = (bool) resources.GetObject("lblBCC.Enabled");

		this.erpEmailAddresses.SetError(this.lblBCC, resources.GetString("lblBCC.Error"));

		this.lblBCC.Font = (System.Drawing.Font) resources.GetObject("lblBCC.Font");

		this.lblBCC.ForeColor = System.Drawing.SystemColors.ControlText;

		this.erpEmailAddresses.SetIconAlignment(this.lblBCC, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("lblBCC.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.lblBCC, (int) resources.GetObject("lblBCC.IconPadding"));

		this.lblBCC.Image = (System.Drawing.Image) resources.GetObject("lblBCC.Image");

		this.lblBCC.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblBCC.ImageAlign");

		this.lblBCC.ImageIndex = (int) resources.GetObject("lblBCC.ImageIndex");

		this.lblBCC.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblBCC.ImeMode");

		this.lblBCC.Location = (System.Drawing.Point) resources.GetObject("lblBCC.Location");

		this.lblBCC.Name = "lblBCC";

		this.lblBCC.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblBCC.RightToLeft");

		this.lblBCC.Size = (System.Drawing.Size) resources.GetObject("lblBCC.Size");

		this.lblBCC.TabIndex = (int) resources.GetObject("lblBCC.TabIndex");

		this.lblBCC.Text = resources.GetString("lblBCC.Text");

		this.lblBCC.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblBCC.TextAlign");

		this.lblBCC.Visible = (bool) resources.GetObject("lblBCC.Visible");

		//

		//lblCC

		//

		this.lblCC.AccessibleDescription = (string) resources.GetObject("lblCC.AccessibleDescription");

		this.lblCC.AccessibleName = (string) resources.GetObject("lblCC.AccessibleName");

		this.lblCC.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblCC.Anchor");

		this.lblCC.AutoSize = (bool) resources.GetObject("lblCC.AutoSize");

		this.lblCC.BackColor = System.Drawing.SystemColors.Control;

		this.lblCC.CausesValidation = false;

		this.lblCC.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblCC.Dock");

		this.lblCC.Enabled = (bool) resources.GetObject("lblCC.Enabled");

		this.erpEmailAddresses.SetError(this.lblCC, resources.GetString("lblCC.Error"));

		this.lblCC.Font = (System.Drawing.Font) resources.GetObject("lblCC.Font");

		this.lblCC.ForeColor = System.Drawing.SystemColors.ControlText;

		this.erpEmailAddresses.SetIconAlignment(this.lblCC, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("lblCC.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.lblCC, (int) resources.GetObject("lblCC.IconPadding"));

		this.lblCC.Image = (System.Drawing.Image) resources.GetObject("lblCC.Image");

		this.lblCC.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCC.ImageAlign");

		this.lblCC.ImageIndex = (int) resources.GetObject("lblCC.ImageIndex");

		this.lblCC.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblCC.ImeMode");

		this.lblCC.Location = (System.Drawing.Point) resources.GetObject("lblCC.Location");

		this.lblCC.Name = "lblCC";

		this.lblCC.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblCC.RightToLeft");

		this.lblCC.Size = (System.Drawing.Size) resources.GetObject("lblCC.Size");

		this.lblCC.TabIndex = (int) resources.GetObject("lblCC.TabIndex");

		this.lblCC.Text = resources.GetString("lblCC.Text");

		this.lblCC.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCC.TextAlign");

		this.lblCC.Visible = (bool) resources.GetObject("lblCC.Visible");

		//

		//erpEmailAddresses

		//

		this.erpEmailAddresses.Icon = (System.Drawing.Icon) resources.GetObject("erpEmailAddresses.Icon");

		//

		//txtBCC

		//

		this.txtBCC.AccessibleDescription = (string) resources.GetObject("txtBCC.AccessibleDescription");

		this.txtBCC.AccessibleName = (string) resources.GetObject("txtBCC.AccessibleName");

		this.txtBCC.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtBCC.Anchor");

		this.txtBCC.AutoSize = (bool) resources.GetObject("txtBCC.AutoSize");

		this.txtBCC.BackColor = System.Drawing.SystemColors.Window;

		this.txtBCC.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtBCC.BackgroundImage");

		this.txtBCC.CausesValidation = false;

		this.txtBCC.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtBCC.Dock");

		this.txtBCC.Enabled = (bool) resources.GetObject("txtBCC.Enabled");

		this.erpEmailAddresses.SetError(this.txtBCC, resources.GetString("txtBCC.Error"));

		this.txtBCC.Font = (System.Drawing.Font) resources.GetObject("txtBCC.Font");

		this.erpEmailAddresses.SetIconAlignment(this.txtBCC, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("txtBCC.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.txtBCC, (int) resources.GetObject("txtBCC.IconPadding"));

		this.txtBCC.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtBCC.ImeMode");

		this.txtBCC.Location = (System.Drawing.Point) resources.GetObject("txtBCC.Location");

		this.txtBCC.MaxLength = (int) resources.GetObject("txtBCC.MaxLength");

		this.txtBCC.Multiline = (bool) resources.GetObject("txtBCC.Multiline");

		this.txtBCC.Name = "txtBCC";

		this.txtBCC.PasswordChar = (char) resources.GetObject("txtBCC.PasswordChar");

		this.txtBCC.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtBCC.RightToLeft");

		this.txtBCC.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtBCC.ScrollBars");

		this.txtBCC.Size = (System.Drawing.Size) resources.GetObject("txtBCC.Size");

		this.txtBCC.TabIndex = (int) resources.GetObject("txtBCC.TabIndex");

		this.txtBCC.Text = resources.GetString("txtBCC.Text");

		this.txtBCC.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtBCC.TextAlign");

		this.txtBCC.Visible = (bool) resources.GetObject("txtBCC.Visible");

		this.txtBCC.WordWrap = (bool) resources.GetObject("txtBCC.WordWrap");

		//

		//cboPriority

		//

		this.cboPriority.AccessibleDescription = (string) resources.GetObject("cboPriority.AccessibleDescription");

		this.cboPriority.AccessibleName = (string) resources.GetObject("cboPriority.AccessibleName");

		this.cboPriority.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboPriority.Anchor");

		this.cboPriority.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboPriority.BackgroundImage");

		this.cboPriority.CausesValidation = false;

		this.cboPriority.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboPriority.Dock");

		this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

		this.cboPriority.Enabled = (bool) resources.GetObject("cboPriority.Enabled");

		this.erpEmailAddresses.SetError(this.cboPriority, resources.GetString("cboPriority.Error"));

		this.cboPriority.Font = (System.Drawing.Font) resources.GetObject("cboPriority.Font");

		this.erpEmailAddresses.SetIconAlignment(this.cboPriority, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("cboPriority.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.cboPriority, (int) resources.GetObject("cboPriority.IconPadding"));

		this.cboPriority.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboPriority.ImeMode");

		this.cboPriority.IntegralHeight = (bool) resources.GetObject("cboPriority.IntegralHeight");

		this.cboPriority.ItemHeight = (int) resources.GetObject("cboPriority.ItemHeight");

		this.cboPriority.Location = (System.Drawing.Point) resources.GetObject("cboPriority.Location");

		this.cboPriority.MaxDropDownItems = (int) resources.GetObject("cboPriority.MaxDropDownItems");

		this.cboPriority.MaxLength = (int) resources.GetObject("cboPriority.MaxLength");

		this.cboPriority.Name = "cboPriority";

		this.cboPriority.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboPriority.RightToLeft");

		this.cboPriority.Size = (System.Drawing.Size) resources.GetObject("cboPriority.Size");

		this.cboPriority.TabIndex = (int) resources.GetObject("cboPriority.TabIndex");

		this.cboPriority.Text = resources.GetString("cboPriority.Text");

		this.cboPriority.Visible = (bool) resources.GetObject("cboPriority.Visible");

		//

		//btnBrowse

		//

		this.btnBrowse.AccessibleDescription = (string) resources.GetObject("btnBrowse.AccessibleDescription");

		this.btnBrowse.AccessibleName = (string) resources.GetObject("btnBrowse.AccessibleName");

		this.btnBrowse.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnBrowse.Anchor");

		this.btnBrowse.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnBrowse.BackgroundImage");

		this.btnBrowse.CausesValidation = false;

		this.btnBrowse.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnBrowse.Dock");

		this.btnBrowse.Enabled = (bool) resources.GetObject("btnBrowse.Enabled");

		this.erpEmailAddresses.SetError(this.btnBrowse, resources.GetString("btnBrowse.Error"));

		this.btnBrowse.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnBrowse.FlatStyle");

		this.btnBrowse.Font = (System.Drawing.Font) resources.GetObject("btnBrowse.Font");

		this.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText;

		this.erpEmailAddresses.SetIconAlignment(this.btnBrowse, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("btnBrowse.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.btnBrowse, (int) resources.GetObject("btnBrowse.IconPadding"));

		this.btnBrowse.Image = (System.Drawing.Bitmap) resources.GetObject("btnBrowse.Image");

		this.btnBrowse.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBrowse.ImageAlign");

		this.btnBrowse.ImageIndex = (int) resources.GetObject("btnBrowse.ImageIndex");

		this.btnBrowse.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnBrowse.ImeMode");

		this.btnBrowse.Location = (System.Drawing.Point) resources.GetObject("btnBrowse.Location");

		this.btnBrowse.Name = "btnBrowse";

		this.btnBrowse.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnBrowse.RightToLeft");

		this.btnBrowse.Size = (System.Drawing.Size) resources.GetObject("btnBrowse.Size");

		this.btnBrowse.TabIndex = (int) resources.GetObject("btnBrowse.TabIndex");

		this.btnBrowse.Text = resources.GetString("btnBrowse.Text");

		this.btnBrowse.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnBrowse.TextAlign");

		this.btnBrowse.Visible = (bool) resources.GetObject("btnBrowse.Visible");

		//

		//Label1

		//

		this.Label1.AccessibleDescription = (string) resources.GetObject("Label1.AccessibleDescription");

		this.Label1.AccessibleName = (string) resources.GetObject("Label1.AccessibleName");

		this.Label1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label1.Anchor");

		this.Label1.AutoSize = (bool) resources.GetObject("Label1.AutoSize");

		this.Label1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label1.Dock");

		this.Label1.Enabled = (bool) resources.GetObject("Label1.Enabled");

		this.erpEmailAddresses.SetError(this.Label1, resources.GetString("Label1.Error"));

		this.Label1.Font = (System.Drawing.Font) resources.GetObject("Label1.Font");

		this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;

		this.erpEmailAddresses.SetIconAlignment(this.Label1, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("Label1.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.Label1, (int) resources.GetObject("Label1.IconPadding"));

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

		//lstAttachments

		//

		this.lstAttachments.AccessibleDescription = (string) resources.GetObject("lstAttachments.AccessibleDescription");

		this.lstAttachments.AccessibleName = (string) resources.GetObject("lstAttachments.AccessibleName");

		this.lstAttachments.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lstAttachments.Anchor");

		this.lstAttachments.BackgroundImage = (System.Drawing.Image) resources.GetObject("lstAttachments.BackgroundImage");

		this.lstAttachments.CausesValidation = false;

		this.lstAttachments.ColumnWidth = (int) resources.GetObject("lstAttachments.ColumnWidth");

		this.lstAttachments.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lstAttachments.Dock");

		this.lstAttachments.Enabled = (bool) resources.GetObject("lstAttachments.Enabled");

		this.erpEmailAddresses.SetError(this.lstAttachments, resources.GetString("lstAttachments.Error"));

		this.lstAttachments.Font = (System.Drawing.Font) resources.GetObject("lstAttachments.Font");

		this.lstAttachments.HorizontalExtent = (int) resources.GetObject("lstAttachments.HorizontalExtent");

		this.lstAttachments.HorizontalScrollbar = (bool) resources.GetObject("lstAttachments.HorizontalScrollbar");

		this.erpEmailAddresses.SetIconAlignment(this.lstAttachments, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("lstAttachments.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.lstAttachments, (int) resources.GetObject("lstAttachments.IconPadding"));

		this.lstAttachments.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lstAttachments.ImeMode");

		this.lstAttachments.IntegralHeight = (bool) resources.GetObject("lstAttachments.IntegralHeight");

		this.lstAttachments.ItemHeight = (int) resources.GetObject("lstAttachments.ItemHeight");

		this.lstAttachments.Items.AddRange(new Object[] {resources.GetString("lstAttachments.Items.Items")});

		this.lstAttachments.Location = (System.Drawing.Point) resources.GetObject("lstAttachments.Location");

		this.lstAttachments.Name = "lstAttachments";

		this.lstAttachments.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lstAttachments.RightToLeft");

		this.lstAttachments.ScrollAlwaysVisible = (bool) resources.GetObject("lstAttachments.ScrollAlwaysVisible");

		this.lstAttachments.Size = (System.Drawing.Size) resources.GetObject("lstAttachments.Size");

		this.lstAttachments.TabIndex = (int) resources.GetObject("lstAttachments.TabIndex");

		this.lstAttachments.Visible = (bool) resources.GetObject("lstAttachments.Visible");

		//

		//Label2

		//

		this.Label2.AccessibleDescription = (string) resources.GetObject("Label2.AccessibleDescription");

		this.Label2.AccessibleName = (string) resources.GetObject("Label2.AccessibleName");

		this.Label2.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label2.Anchor");

		this.Label2.AutoSize = (bool) resources.GetObject("Label2.AutoSize");

		this.Label2.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label2.Dock");

		this.Label2.Enabled = (bool) resources.GetObject("Label2.Enabled");

		this.erpEmailAddresses.SetError(this.Label2, resources.GetString("Label2.Error"));

		this.Label2.Font = (System.Drawing.Font) resources.GetObject("Label2.Font");

		this.erpEmailAddresses.SetIconAlignment(this.Label2, (System.Windows.Forms.ErrorIconAlignment) resources.GetObject("Label2.IconAlignment"));

		this.erpEmailAddresses.SetIconPadding(this.Label2, (int) resources.GetObject("Label2.IconPadding"));

		this.Label2.Image = (System.Drawing.Bitmap) resources.GetObject("Label2.Image");

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

		//odlgAttachment

		//

		this.odlgAttachment.Filter = resources.GetString("odlgAttachment.Filter");

		this.odlgAttachment.Title = resources.GetString("odlgAttachment.Title");

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

		this.CausesValidation = false;

		this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2, this.lstAttachments, this.btnBrowse, this.cboPriority, this.txtBCC, this.txtCC, this.lblBCC, this.lblCC, this.txtBody, this.txtSubject, this.txtTo, this.txtFrom, this.btnSend, this.lblBody, this.lblSubject, this.lblTo, this.lblFrom, this.Label1});

		this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

		this.Enabled = (bool) resources.GetObject("$this.Enabled");

		this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

		this.ForeColor = System.Drawing.Color.Blue;

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
		this.btnBrowse.Click +=new EventHandler(btnBrowse_Click);
		this.btnSend.Click +=new EventHandler(btnSend_Click);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.txtFrom.Validating +=new System.ComponentModel.CancelEventHandler(emailAddresses_Validating);
		this.txtTo.Validating +=new System.ComponentModel.CancelEventHandler(emailAddresses_Validating);
		this.txtFrom.Validated +=new EventHandler(emailAddresses_Validated);
		this.txtTo.Validated +=new EventHandler(emailAddresses_Validated);
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

        // Turn of validation for all controls with CausesValidation = true or else

        // you will not be able to close the Form until valid data is entered.

        txtTo.CausesValidation = false;

        txtFrom.CausesValidation = false;

        // Close the current form

        this.Close();

    }

#endregion

    ArrayList arlAttachments;

    // Checks for empty strings and does basic check for valid email
    // address.

    private void ValidateEmailAddress(TextBox txt)
	{

        // Confirm there is text in the control.

		if (txt.TextLength == 0) 
		{

			throw new Exception("Email address is a required field");
		}
		else 
		{

			// Confirm that there is a "." and an "@" in the e-mail address.

			if ((txt.Text.IndexOf(".") == -1) | (txt.Text.IndexOf("@") == -1)) 
			{
				throw new Exception("E-mail address must be valid e-mail " + 
					"address format." + "\r" + "For example " + 
				"'someone@microsoft.com'");
			}
		}
    }

    // This method overrides the WndProc of the Form and catches the Close message

    // passed when the user attempts to exit the Form. Without this there is no way

    // to prevent the ErrorProvider control from attempting to validate the "To" and 

    // "From" TextBox controls (the only controls with CausesValidation = true). if

    // invalid or no data is entered when the user attempts to close the Form, the

    // validators fire and the Form will not close.

    protected override void WndProc(ref System.Windows.Forms.Message m)
	{

        if (m.Msg == WM_SYSCOMMAND) {

            if (m.WParam.ToInt32() == SC_CLOSE) {

                // Turn off validation for all controls with CausesValidation = true or else
                // you will not be able to close the Form until valid data is entered.

                txtTo.CausesValidation = false;

                txtFrom.CausesValidation = false;

            }

        }

        // Pass other messages on to the original WndProc.

        base.WndProc(ref m);

    }

    // the Browse button click event. Uses an OpenFileDialog to allow the 
    // user to find an attachment to send, which is then added to an arraylist of
    // MailAttachment objects.

    private void btnBrowse_Click(object sender, System.EventArgs e) 
	{	

            odlgAttachment.InitialDirectory = @"C:\";
            odlgAttachment.Filter = "All Files (*.*)|*.*|HTML Files (*.htm;*.html)|*.htm|Microsoft Mail Documents (*.msg)|*.msg|Word Documents (*.doc)|*.doc|Excel Files(*.xl*)|*.xl*|Excel Worksheets (*.xls)|*.xls|Excel Charts (*.xlc)|*.xlc|PowerPoint Presentations (*.ppt)|*.ppt|Text Files (*.txt)|*.txt";
            odlgAttachment.FilterIndex = 1;
            // The OpenFileDialog control only has an Open button, not an OK button.
            // However, there is no DialogResult.Open enum so use DialogResult.OK.
            if (odlgAttachment.ShowDialog() == DialogResult.OK) {
                if (arlAttachments == null) {
                    arlAttachments = new ArrayList();
                    // Clear the "(No Attachments)" default text in the ListView
                    lstAttachments.Items.Clear();
                }
                arlAttachments.Add(new MailAttachment(odlgAttachment.FileName));
                // You only want to show the file name. The OpenFileDialog.FileName
                // property contains the full path. So Split the path and reverse it
                // to grab the first string in the array, which is just the FileName.
                string[] strFileName= odlgAttachment.FileName.Split(Convert.ToChar(@"\"));
				Array.Reverse(strFileName);
                lstAttachments.Items.Add(strFileName[0]);

            }

        

    }

    // the Send button click event. This routine checks for valid email

    // addresses, builds the body of a message using stringBuilder, creates a 

    // mail message, and then attempts to send it.

    private void btnSend_Click(object sender, System.EventArgs e) 
	{
        // Perform validation on the To and From email address fields, which are

        // both required for sending an email.

        try {

            ValidateEmailAddress(txtFrom);

       } catch( Exception ex)
		{
            txtFrom.Select(0, txtFrom.Text.Length);

            // Set the ErrorProvider error with the text to display. 

            erpEmailAddresses.SetError(txtFrom, ex.Message);

            return;

        }

        try {

            ValidateEmailAddress(txtTo);

       } catch( Exception exp)
		{
            txtTo.Select(0, txtTo.Text.Length);

            // Set the ErrorProvider error with the text to display. 

            erpEmailAddresses.SetError(txtTo, exp.Message);

            return;

        }

        // Use the stringBuilder class instead of traditional string concatenation.
        // It is optimized for building strings because it is capable of modifying
        // the underlying buffer instead of having to make a copy of the string for 
        // each concatenation. Consult the SDK documentation for more information on 
        // this new class.

        StringBuilder sb = new StringBuilder();

        // Build the email message body.
        sb.Append("The following email was sent to you from the Send Mail How-To " + 
            "sample application:");
        sb.Append(Environment.NewLine);
        sb.Append(Environment.NewLine);
        sb.Append("SUBJECT: ");
        sb.Append(txtSubject.Text.Trim());
        sb.Append(Environment.NewLine);
        sb.Append(Environment.NewLine);
        sb.Append("MESSAGE: ");
        sb.Append(txtBody.Text.Trim());
        sb.Append(Environment.NewLine);

        // Creating a mail message is simple instantiating a class and 
        // setting a few properties.

        MailMessage mailMsg = new MailMessage();

            mailMsg.From = txtFrom.Text.Trim();
            mailMsg.To = txtTo.Text.Trim();
            mailMsg.Cc = txtCC.Text.Trim();
            mailMsg.Bcc = txtBCC.Text.Trim();
            mailMsg.Subject = txtSubject.Text.Trim();
            mailMsg.Body = sb.ToString();
            mailMsg.Priority = (MailPriority) cboPriority.SelectedIndex;

            if (arlAttachments != null) {

                foreach(object mailAttachment in arlAttachments)
				{
                    mailMsg.Attachments.Add(mailAttachment);

                }

            }

        

        // Set the SmtpServer name. This can be any of the following depending on
        // your local security settings:
        // a) Local IP Address (assuming your local machine's SMTP server has the 
        // right to send messages through a local firewall (if present).
        // b) 127.0.0.1 the loopback of the local machine.
        // c) "smarthost" or the name or the IP address of the exchange server you 
        // utilize for messaging. This is usually what is needed if you are behind
        // a corporate firewall.
        // See the Readme file for more information.

        SmtpMail.SmtpServer = "smarthost";

        // Use structured error handling to attempt to send the email message and 
        // provide feedback to the user about the success or failure of their 
        // attempt.

        try {
            SmtpMail.Send(mailMsg);
            lstAttachments.Items.Clear();
            lstAttachments.Items.Add("(No Attachments)");
            MessageBox.Show("Your email has been successfully sent!", 
                "Email Send Status", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
       } catch( Exception exp)
		{
            MessageBox.Show("The following problem occurred when attempting to " + 
                "send your email: " + exp.Message, 
                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }

    // the event fired when the control is validated.

    private void emailAddresses_Validated(object sender, System.EventArgs e) 
	{
        // Clear the ErrorProvider of errors.

        erpEmailAddresses.SetError((TextBox) sender, "");

    }

    // the event fired when the control starts validating. Cast the sender 
    // instead of hardcoding the ID of the TextBox (e.g., "txtFrom") undergoing 
    // validation so that a single routine can handle the validating event for 
    // more than one TextBox control.

    private void emailAddresses_Validating(object sender, System.ComponentModel.CancelEventArgs e) 
	{
        TextBox txt = (TextBox) sender;

        try {

            ValidateEmailAddress(txt);

       } catch( Exception exp)
		{
            // Cancel the event and highlight the text to be corrected by the user.

            e.Cancel = true;

            txt.Select(0, txt.Text.Length);

            // Set the ErrorProvider error with the text to display. 

            erpEmailAddresses.SetError(txt, exp.Message);

        }

    }

    // the form Load event. Checks to make sure that the SMTP Service is 
    // both installed and running.

    private void frmMain_Load(object sender, System.EventArgs e) {

        // Ensure the SMTP Service is installed.

        ServiceController[] services = ServiceController.GetServices();
        bool blnHasSmtpService = false;
		ServiceController smtpServ = null;
		frmStatus frmStatusMessage = null;

        // Loop through all the services on the machine and find the SMTP Service.

        foreach(ServiceController service in services)
		{
            if (service.ServiceName.ToLower() == "smtpsvc") 
			{
                blnHasSmtpService = true;
				smtpServ = service;
                break;
            }

        }

        if (!blnHasSmtpService) {
            MessageBox.Show("You do not have SMTP Service installed on this " + 
                "machine. Please check the Readme file for information on how " + 
                "to install SMTP Service.", this.Text, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        // Ensure the SMTP Service is running. if not, start it.
		if (smtpServ != null)
		{
			if (smtpServ.Status != ServiceControllerStatus.Running) 
			{
				frmStatusMessage = new frmStatus();
				frmStatusMessage.Show("SMTP Service not currently running. " + 
					"Starting service...");
			}
			try 
			{

				smtpServ.Start();

				frmStatusMessage.Close();

			} 
			catch 
			{
				MessageBox.Show("There was an error when attempting " + 
					"to start SMTP Service. Please consult the Readme " + 
					"file for more information.", this.Text, 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        // Fill the Priority ComboBox with the MailPriority values

            cboPriority.Items.AddRange(new string[] {"Normal", "Low", "High"});
            cboPriority.SelectedIndex = 0;

    }

}

