//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;
using System.Windows.Forms;

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

	//Do ! modify it using the code editor.

	private System.Windows.Forms.MainMenu mnuMain;

	private System.Windows.Forms.MenuItem mnuFile;

	private System.Windows.Forms.MenuItem mnuExit;

	private System.Windows.Forms.MenuItem mnuHelp;

	private System.Windows.Forms.MenuItem mnuAbout;

    private System.Windows.Forms.Button btnTextModMenu;

    private System.Windows.Forms.Button btnIconModMenu;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.btnTextModMenu = new System.Windows.Forms.Button();

        this.btnIconModMenu = new System.Windows.Forms.Button();

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

        //btnTextModMenu

        //

        this.btnTextModMenu.AccessibleDescription = (string) resources.GetObject("btnTextModMenu.AccessibleDescription");

        this.btnTextModMenu.AccessibleName = (string) resources.GetObject("btnTextModMenu.AccessibleName");

        this.btnTextModMenu.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnTextModMenu.Anchor");

        this.btnTextModMenu.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnTextModMenu.BackgroundImage");

        this.btnTextModMenu.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnTextModMenu.Dock");

        this.btnTextModMenu.Enabled = (bool) resources.GetObject("btnTextModMenu.Enabled");

        this.btnTextModMenu.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnTextModMenu.FlatStyle");

        this.btnTextModMenu.Font = (System.Drawing.Font) resources.GetObject("btnTextModMenu.Font");

        this.btnTextModMenu.Image = (System.Drawing.Image) resources.GetObject("btnTextModMenu.Image");

        this.btnTextModMenu.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTextModMenu.ImageAlign");

        this.btnTextModMenu.ImageIndex = (int) resources.GetObject("btnTextModMenu.ImageIndex");

        this.btnTextModMenu.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnTextModMenu.ImeMode");

        this.btnTextModMenu.Location = (System.Drawing.Point) resources.GetObject("btnTextModMenu.Location");

        this.btnTextModMenu.Name = "btnTextModMenu";

        this.btnTextModMenu.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnTextModMenu.RightToLeft");

        this.btnTextModMenu.Size = (System.Drawing.Size) resources.GetObject("btnTextModMenu.Size");

        this.btnTextModMenu.TabIndex = (int) resources.GetObject("btnTextModMenu.TabIndex");

        this.btnTextModMenu.Text = resources.GetString("btnTextModMenu.Text");

        this.btnTextModMenu.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnTextModMenu.TextAlign");

        this.btnTextModMenu.Visible = (bool) resources.GetObject("btnTextModMenu.Visible");

        //

        //btnIconModMenu

        //

        this.btnIconModMenu.AccessibleDescription = (string) resources.GetObject("btnIconModMenu.AccessibleDescription");

        this.btnIconModMenu.AccessibleName = (string) resources.GetObject("btnIconModMenu.AccessibleName");

        this.btnIconModMenu.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnIconModMenu.Anchor");

        this.btnIconModMenu.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnIconModMenu.BackgroundImage");

        this.btnIconModMenu.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnIconModMenu.Dock");

        this.btnIconModMenu.Enabled = (bool) resources.GetObject("btnIconModMenu.Enabled");

        this.btnIconModMenu.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnIconModMenu.FlatStyle");

        this.btnIconModMenu.Font = (System.Drawing.Font) resources.GetObject("btnIconModMenu.Font");

        this.btnIconModMenu.Image = (System.Drawing.Image) resources.GetObject("btnIconModMenu.Image");

        this.btnIconModMenu.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnIconModMenu.ImageAlign");

        this.btnIconModMenu.ImageIndex = (int) resources.GetObject("btnIconModMenu.ImageIndex");

        this.btnIconModMenu.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnIconModMenu.ImeMode");

        this.btnIconModMenu.Location = (System.Drawing.Point) resources.GetObject("btnIconModMenu.Location");

        this.btnIconModMenu.Name = "btnIconModMenu";

        this.btnIconModMenu.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnIconModMenu.RightToLeft");

        this.btnIconModMenu.Size = (System.Drawing.Size) resources.GetObject("btnIconModMenu.Size");

        this.btnIconModMenu.TabIndex = (int) resources.GetObject("btnIconModMenu.TabIndex");

        this.btnIconModMenu.Text = resources.GetString("btnIconModMenu.Text");

        this.btnIconModMenu.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnIconModMenu.TextAlign");

        this.btnIconModMenu.Visible = (bool) resources.GetObject("btnIconModMenu.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnIconModMenu, this.btnTextModMenu});

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

		this.btnIconModMenu.Click +=new System.EventHandler(btnIconModMenu_Click);
		this.btnTextModMenu.Click +=new System.EventHandler(btnTextModMenu_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);

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

    private void btnTextModMenu_Click(object sender, System.EventArgs e)
	{
        frmTextModMenu frmText = new frmTextModMenu();
        frmText.ShowDialog();

    }

    private void btnIconModMenu_Click(object sender, System.EventArgs e)
	{
        frmIconModMenu frmIcon = new frmIconModMenu();
        frmIcon.ShowDialog();
    }

}

