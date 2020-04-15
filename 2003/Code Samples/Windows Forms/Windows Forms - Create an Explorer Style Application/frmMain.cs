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

#region " Windows Form Designer generated code.";

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

    private System.Windows.Forms.Button btnSimple;

    private System.Windows.Forms.Button btnExplorer;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.btnSimple = new System.Windows.Forms.Button();

        this.btnExplorer = new System.Windows.Forms.Button();

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

        //btnSimple

        //

        this.btnSimple.AccessibleDescription = resources.GetString("btnSimple.AccessibleDescription");

        this.btnSimple.AccessibleName = resources.GetString("btnSimple.AccessibleName");

        this.btnSimple.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnSimple.Anchor");

        this.btnSimple.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnSimple.BackgroundImage");

        this.btnSimple.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnSimple.Dock");

        this.btnSimple.Enabled = (bool) resources.GetObject("btnSimple.Enabled");

        this.btnSimple.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnSimple.FlatStyle");

        this.btnSimple.Font = (System.Drawing.Font) resources.GetObject("btnSimple.Font");

        this.btnSimple.Image = (System.Drawing.Image) resources.GetObject("btnSimple.Image");

        this.btnSimple.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSimple.ImageAlign");

        this.btnSimple.ImageIndex = (int) resources.GetObject("btnSimple.ImageIndex");

        this.btnSimple.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnSimple.ImeMode");

        this.btnSimple.Location = (System.Drawing.Point) resources.GetObject("btnSimple.Location");

        this.btnSimple.Name = "btnSimple";

        this.btnSimple.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnSimple.RightToLeft");

        this.btnSimple.Size = (System.Drawing.Size) resources.GetObject("btnSimple.Size");

        this.btnSimple.TabIndex = (int) resources.GetObject("btnSimple.TabIndex");

        this.btnSimple.Text = resources.GetString("btnSimple.Text");

        this.btnSimple.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnSimple.TextAlign");

        this.btnSimple.Visible = (bool) resources.GetObject("btnSimple.Visible");

        //

        //btnExplorer

        //

        this.btnExplorer.AccessibleDescription = resources.GetString("btnExplorer.AccessibleDescription");

        this.btnExplorer.AccessibleName = resources.GetString("btnExplorer.AccessibleName");

        this.btnExplorer.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnExplorer.Anchor");

        this.btnExplorer.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnExplorer.BackgroundImage");

        this.btnExplorer.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnExplorer.Dock");

        this.btnExplorer.Enabled = (bool) resources.GetObject("btnExplorer.Enabled");

        this.btnExplorer.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnExplorer.FlatStyle");

        this.btnExplorer.Font = (System.Drawing.Font) resources.GetObject("btnExplorer.Font");

        this.btnExplorer.Image = (System.Drawing.Image) resources.GetObject("btnExplorer.Image");

        this.btnExplorer.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnExplorer.ImageAlign");

        this.btnExplorer.ImageIndex = (int) resources.GetObject("btnExplorer.ImageIndex");

        this.btnExplorer.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnExplorer.ImeMode");

        this.btnExplorer.Location = (System.Drawing.Point) resources.GetObject("btnExplorer.Location");

        this.btnExplorer.Name = "btnExplorer";

        this.btnExplorer.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnExplorer.RightToLeft");

        this.btnExplorer.Size = (System.Drawing.Size) resources.GetObject("btnExplorer.Size");

        this.btnExplorer.TabIndex = (int) resources.GetObject("btnExplorer.TabIndex");

        this.btnExplorer.Text = resources.GetString("btnExplorer.Text");

        this.btnExplorer.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnExplorer.TextAlign");

        this.btnExplorer.Visible = (bool) resources.GetObject("btnExplorer.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnExplorer, this.btnSimple});

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

		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.btnExplorer.Click +=new EventHandler(btnExplorer_Click);
		this.btnSimple.Click +=new EventHandler(btnSimple_Click);

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

    // the Click event for the "Launch Directory Scanner" button.

    private void btnSimple_Click(object sender, System.EventArgs e) 
	{
        DirectoryScanner sdv = new DirectoryScanner();
        sdv.Show();

    }

    // the Click event for the "Launch Explorer-Style Viewer" button.

    private void btnExplorer_Click(object sender, System.EventArgs e) 
	{
        ExplorerStyleViewer esfv = new ExplorerStyleViewer();
        esfv.Show();
    }

}

