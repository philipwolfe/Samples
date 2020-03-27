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
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Button btnShowDataGridForm;
    private System.Windows.Forms.Button btnShowRichTextBoxForm;

    private void InitializeComponent() {
        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.Label1 = new System.Windows.Forms.Label();

        this.btnShowDataGridForm = new System.Windows.Forms.Button();

        this.btnShowRichTextBoxForm = new System.Windows.Forms.Button();

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

        //Label1

        //

        this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");

        this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");

        this.Label1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label1.Anchor");

        this.Label1.AutoSize = (bool) resources.GetObject("Label1.AutoSize");

        this.Label1.BackColor = System.Drawing.SystemColors.Control;

        this.Label1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label1.Dock");

        this.Label1.Enabled = (bool) resources.GetObject("Label1.Enabled");

        this.Label1.Font = (System.Drawing.Font) resources.GetObject("Label1.Font");

        this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;

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

        //btnShowDataGridForm

        //

        this.btnShowDataGridForm.AccessibleDescription = resources.GetString("btnShowDataGridForm.AccessibleDescription");

        this.btnShowDataGridForm.AccessibleName = resources.GetString("btnShowDataGridForm.AccessibleName");

        this.btnShowDataGridForm.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnShowDataGridForm.Anchor");

        this.btnShowDataGridForm.BackColor = System.Drawing.SystemColors.Control;

        this.btnShowDataGridForm.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnShowDataGridForm.BackgroundImage");

        this.btnShowDataGridForm.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnShowDataGridForm.Dock");

        this.btnShowDataGridForm.Enabled = (bool) resources.GetObject("btnShowDataGridForm.Enabled");

        this.btnShowDataGridForm.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnShowDataGridForm.FlatStyle");

        this.btnShowDataGridForm.Font = (System.Drawing.Font) resources.GetObject("btnShowDataGridForm.Font");

        this.btnShowDataGridForm.ForeColor = System.Drawing.SystemColors.ControlText;

        this.btnShowDataGridForm.Image = (System.Drawing.Image) resources.GetObject("btnShowDataGridForm.Image");

        this.btnShowDataGridForm.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShowDataGridForm.ImageAlign");

        this.btnShowDataGridForm.ImageIndex = (int) resources.GetObject("btnShowDataGridForm.ImageIndex");

        this.btnShowDataGridForm.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnShowDataGridForm.ImeMode");

        this.btnShowDataGridForm.Location = (System.Drawing.Point) resources.GetObject("btnShowDataGridForm.Location");

        this.btnShowDataGridForm.Name = "btnShowDataGridForm";

        this.btnShowDataGridForm.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnShowDataGridForm.RightToLeft");

        this.btnShowDataGridForm.Size = (System.Drawing.Size) resources.GetObject("btnShowDataGridForm.Size");

        this.btnShowDataGridForm.TabIndex = (int) resources.GetObject("btnShowDataGridForm.TabIndex");

        this.btnShowDataGridForm.Text = resources.GetString("btnShowDataGridForm.Text");

        this.btnShowDataGridForm.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShowDataGridForm.TextAlign");

        this.btnShowDataGridForm.Visible = (bool) resources.GetObject("btnShowDataGridForm.Visible");

        //

        //btnShowRichTextBoxForm

        //

        this.btnShowRichTextBoxForm.AccessibleDescription = resources.GetString("btnShowRichTextBoxForm.AccessibleDescription");

        this.btnShowRichTextBoxForm.AccessibleName = resources.GetString("btnShowRichTextBoxForm.AccessibleName");

        this.btnShowRichTextBoxForm.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnShowRichTextBoxForm.Anchor");

        this.btnShowRichTextBoxForm.BackColor = System.Drawing.SystemColors.Control;

        this.btnShowRichTextBoxForm.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnShowRichTextBoxForm.BackgroundImage");

        this.btnShowRichTextBoxForm.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnShowRichTextBoxForm.Dock");

        this.btnShowRichTextBoxForm.Enabled = (bool) resources.GetObject("btnShowRichTextBoxForm.Enabled");

        this.btnShowRichTextBoxForm.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnShowRichTextBoxForm.FlatStyle");

        this.btnShowRichTextBoxForm.Font = (System.Drawing.Font) resources.GetObject("btnShowRichTextBoxForm.Font");

        this.btnShowRichTextBoxForm.ForeColor = System.Drawing.SystemColors.ControlText;

        this.btnShowRichTextBoxForm.Image = (System.Drawing.Image) resources.GetObject("btnShowRichTextBoxForm.Image");

        this.btnShowRichTextBoxForm.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShowRichTextBoxForm.ImageAlign");

        this.btnShowRichTextBoxForm.ImageIndex = (int) resources.GetObject("btnShowRichTextBoxForm.ImageIndex");

        this.btnShowRichTextBoxForm.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnShowRichTextBoxForm.ImeMode");

        this.btnShowRichTextBoxForm.Location = (System.Drawing.Point) resources.GetObject("btnShowRichTextBoxForm.Location");

        this.btnShowRichTextBoxForm.Name = "btnShowRichTextBoxForm";

        this.btnShowRichTextBoxForm.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnShowRichTextBoxForm.RightToLeft");

        this.btnShowRichTextBoxForm.Size = (System.Drawing.Size) resources.GetObject("btnShowRichTextBoxForm.Size");

        this.btnShowRichTextBoxForm.TabIndex = (int) resources.GetObject("btnShowRichTextBoxForm.TabIndex");

        this.btnShowRichTextBoxForm.Text = resources.GetString("btnShowRichTextBoxForm.Text");

        this.btnShowRichTextBoxForm.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnShowRichTextBoxForm.TextAlign");

        this.btnShowRichTextBoxForm.Visible = (bool) resources.GetObject("btnShowRichTextBoxForm.Visible");

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnShowRichTextBoxForm, this.btnShowDataGridForm, this.Label1});

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
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.btnShowDataGridForm.Click +=new EventHandler(btnShowDataGridForm_Click);
		this.btnShowRichTextBoxForm.Click +=new EventHandler(btnShowRichTextBoxForm_Click);


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

    // the "Show DataGrid Form" button click event.

    private void btnShowDataGridForm_Click(object sender, System.EventArgs e) 
	{
        frmDataGrid frmDG = new frmDataGrid();
        frmDG.Show();

    }

    // the "Show RichTextBox Form" button click event.

    private void btnShowRichTextBoxForm_Click(object sender, System.EventArgs e) 
	{
        frmRichTextBox frmRTB = new frmRichTextBox();
        frmRTB.Show();

    }

    private void frmMain_Load(object sender, System.EventArgs e) {

    }

}

