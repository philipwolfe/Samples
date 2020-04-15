
//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Diagnostics;

public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}
  

    //When writing to an event log you need to pass the machine name where 
    //the log resides.  Here the MachineName DATA_TYPE_HERE of the Environment class 
    //is used to determine the name of the local machine.  Assuming you have 
    //the appropriate permissions it is also easy to write to event logs on 
    //other machines.

    private string machineName  = Environment.MachineName;

    

    frmWrite frmWrite =new frmWrite();

    frmRead frmRead =new frmRead();

    frmCreateDelete frmCreateDelete =new frmCreateDelete();

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

		if (disposing) 
		{

			if (components != null) 
			{

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

    private System.Windows.Forms.Button btnWrite;

    private System.Windows.Forms.Button btnRead;

    private System.Windows.Forms.Button btnCreateDelete;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.btnWrite = new System.Windows.Forms.Button();

        this.btnRead = new System.Windows.Forms.Button();

        this.btnCreateDelete = new System.Windows.Forms.Button();

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
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);

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
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);

        //

        //btnWrite

        //

        this.btnWrite.AccessibleDescription = resources.GetString("btnWrite.AccessibleDescription");

        this.btnWrite.AccessibleName = resources.GetString("btnWrite.AccessibleName");

        this.btnWrite.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnWrite.Anchor");

        this.btnWrite.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnWrite.BackgroundImage");

        this.btnWrite.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnWrite.Dock");

        this.btnWrite.Enabled = (bool) resources.GetObject("btnWrite.Enabled");

        this.btnWrite.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnWrite.FlatStyle");

        this.btnWrite.Font = (System.Drawing.Font) resources.GetObject("btnWrite.Font");

        this.btnWrite.Image = (System.Drawing.Image) resources.GetObject("btnWrite.Image");

        this.btnWrite.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnWrite.ImageAlign");

        this.btnWrite.ImageIndex = (int) resources.GetObject("btnWrite.ImageIndex");

        this.btnWrite.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnWrite.ImeMode");

        this.btnWrite.Location = (System.Drawing.Point) resources.GetObject("btnWrite.Location");

        this.btnWrite.Name = "btnWrite";

        this.btnWrite.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnWrite.RightToLeft");

        this.btnWrite.Size = (System.Drawing.Size) resources.GetObject("btnWrite.Size");

        this.btnWrite.TabIndex = (int) resources.GetObject("btnWrite.TabIndex");

        this.btnWrite.Text = resources.GetString("btnWrite.Text");

        this.btnWrite.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnWrite.TextAlign");

        this.btnWrite.Visible = (bool) resources.GetObject("btnWrite.Visible");
		this.btnWrite.Click +=new EventHandler(btnWrite_Click);

        //

        //btnRead

        //

        this.btnRead.AccessibleDescription = resources.GetString("btnRead.AccessibleDescription");

        this.btnRead.AccessibleName = resources.GetString("btnRead.AccessibleName");

        this.btnRead.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRead.Anchor");

        this.btnRead.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRead.BackgroundImage");

        this.btnRead.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRead.Dock");

        this.btnRead.Enabled = (bool) resources.GetObject("btnRead.Enabled");

        this.btnRead.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRead.FlatStyle");

        this.btnRead.Font = (System.Drawing.Font) resources.GetObject("btnRead.Font");

        this.btnRead.Image = (System.Drawing.Image) resources.GetObject("btnRead.Image");

        this.btnRead.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRead.ImageAlign");

        this.btnRead.ImageIndex = (int) resources.GetObject("btnRead.ImageIndex");

        this.btnRead.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRead.ImeMode");

        this.btnRead.Location = (System.Drawing.Point) resources.GetObject("btnRead.Location");

        this.btnRead.Name = "btnRead";

        this.btnRead.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRead.RightToLeft");

        this.btnRead.Size = (System.Drawing.Size) resources.GetObject("btnRead.Size");

        this.btnRead.TabIndex = (int) resources.GetObject("btnRead.TabIndex");

        this.btnRead.Text = resources.GetString("btnRead.Text");

        this.btnRead.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRead.TextAlign");

        this.btnRead.Visible = (bool) resources.GetObject("btnRead.Visible");
		this.btnRead.Click +=new EventHandler(btnRead_Click);

        //

        //btnCreateDelete

        //

        this.btnCreateDelete.AccessibleDescription = resources.GetString("btnCreateDelete.AccessibleDescription");

        this.btnCreateDelete.AccessibleName = resources.GetString("btnCreateDelete.AccessibleName");

        this.btnCreateDelete.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCreateDelete.Anchor");

        this.btnCreateDelete.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCreateDelete.BackgroundImage");

        this.btnCreateDelete.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCreateDelete.Dock");

        this.btnCreateDelete.Enabled = (bool) resources.GetObject("btnCreateDelete.Enabled");

        this.btnCreateDelete.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCreateDelete.FlatStyle");

        this.btnCreateDelete.Font = (System.Drawing.Font) resources.GetObject("btnCreateDelete.Font");

        this.btnCreateDelete.Image = (System.Drawing.Image) resources.GetObject("btnCreateDelete.Image");

        this.btnCreateDelete.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateDelete.ImageAlign");

        this.btnCreateDelete.ImageIndex = (int) resources.GetObject("btnCreateDelete.ImageIndex");

        this.btnCreateDelete.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCreateDelete.ImeMode");

        this.btnCreateDelete.Location = (System.Drawing.Point) resources.GetObject("btnCreateDelete.Location");

        this.btnCreateDelete.Name = "btnCreateDelete";

        this.btnCreateDelete.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCreateDelete.RightToLeft");

        this.btnCreateDelete.Size = (System.Drawing.Size) resources.GetObject("btnCreateDelete.Size");

        this.btnCreateDelete.TabIndex = (int) resources.GetObject("btnCreateDelete.TabIndex");

        this.btnCreateDelete.Text = resources.GetString("btnCreateDelete.Text");

        this.btnCreateDelete.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCreateDelete.TextAlign");

        this.btnCreateDelete.Visible = (bool) resources.GetObject("btnCreateDelete.Visible");
		this.btnCreateDelete.Click +=new EventHandler(btnCreateDelete_Click);

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnCreateDelete, this.btnRead, this.btnWrite});

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

    private void btnWrite_Click(object sender, System.EventArgs e)
	{

        if (frmWrite == null || frmWrite.IsDisposed)
		{

            frmWrite  = new frmWrite();
        }

        frmWrite.Show();

        frmWrite.BringToFront();

    }

    private void btnRead_Click(object sender, System.EventArgs e)
	{

        if (frmRead == null || frmRead.IsDisposed)
		{

            frmRead  = new frmRead();

        }

        frmRead.Show();

        frmRead.BringToFront();

    }

    private void btnCreateDelete_Click(object sender, System.EventArgs e)
	{
        if (frmCreateDelete == null || frmCreateDelete.IsDisposed)
		{
            frmCreateDelete = new frmCreateDelete();
        }

        frmCreateDelete.Show();

        frmCreateDelete.BringToFront();

    }

}

