//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

public class ExplorerStyleViewer: System.Windows.Forms.Form 
	{

    // Declare variables to hold instances of each of the custom classes

    private DirectoryTreeView dtvwDirectory;
    private FileListView flvFiles;
    private MenuItemView mivChecked;

#region " Windows Form Designer generated code. NOTE: void new() altered for the How To.";

	public ExplorerStyleViewer() 
	{

		//This call is required by the Windows Form Designer.

		InitializeComponent();
		//Add any initialization after the InitializeComponent() call
		// End default How To code. Begin code added for this particular How To...
		// Create a flvFilesView instance.
		flvFiles = new FileListView();
		flvFiles.Parent = this;
		flvFiles.Dock = DockStyle.Fill;

		// Create a Splitter instance.
		Splitter split = new Splitter();
		split.Parent = this;
		split.Dock = DockStyle.Left;
		split.BackColor = SystemColors.Control;
		// Create a DirectoryTreeView instance and add an OnAfterSelect event handler.

		dtvwDirectory = new DirectoryTreeView();
		dtvwDirectory.Parent = this;
		dtvwDirectory.Dock = DockStyle.Left;
		// Dynamically add an AfterSelect event handler.

		dtvwDirectory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(DirectoryTreeViewOnAfterSelect);

		// Add a View menu command to the existing main menu.

		MenuItem mnuView = new MenuItem("&View");
		mnuView.Index = 1;
		this.mnuMain.MenuItems.Add(mnuView);

		// Add four menu items to the new View menu. Start by creating arrays to set
		// properties of each menu item.

		string[] astrView = {"Lar&ge Icons", "S&mall Icons", "&List", "&Details"};
		View[] aview  = {View.LargeIcon, View.SmallIcon, View.List, View.Details};

		// Create an event handler for the menu items.

		EventHandler eh = new System.EventHandler(MenuOnViewSelect);

		for (int i = 0; i <= 3; i++)				  
		{
			// Use a custom class MenuItemView, which extends MenuItem to support a 
			// View property.

		MenuItemView miv = new MenuItemView();
		miv.Text = astrView[i];
		miv.view = aview[i];
		miv.RadioCheck = true;

		// Associate the handler created earlier with the Click event.
		miv.Click += eh;

		// Set the Default view to Details.

		if (i == 3) 
		{
			mivChecked = miv;
			mivChecked.Checked = true;
			flvFiles.View = mivChecked.view;
		}

		// Add the new menu item to the View menu.
		mnuView.MenuItems.Add(miv);
	}

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

    private System.Windows.Forms.Label lblDevNote;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ExplorerStyleViewer));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.lblDevNote = new System.Windows.Forms.Label();

        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile});

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

        //lblDevNote

        //

        this.lblDevNote.AccessibleDescription = (string) resources.GetObject("lblDevNote.AccessibleDescription");

        this.lblDevNote.AccessibleName = (string) resources.GetObject("lblDevNote.AccessibleName");

        this.lblDevNote.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblDevNote.Anchor");

        this.lblDevNote.AutoSize = (bool) resources.GetObject("lblDevNote.AutoSize");

        this.lblDevNote.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblDevNote.Dock");

        this.lblDevNote.Enabled = (bool) resources.GetObject("lblDevNote.Enabled");

        this.lblDevNote.Font = (System.Drawing.Font) resources.GetObject("lblDevNote.Font");

        this.lblDevNote.Image = (System.Drawing.Image) resources.GetObject("lblDevNote.Image");

        this.lblDevNote.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblDevNote.ImageAlign");

        this.lblDevNote.ImageIndex = (int) resources.GetObject("lblDevNote.ImageIndex");

        this.lblDevNote.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblDevNote.ImeMode");

        this.lblDevNote.Location = (System.Drawing.Point) resources.GetObject("lblDevNote.Location");

        this.lblDevNote.Name = "lblDevNote";

        this.lblDevNote.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblDevNote.RightToLeft");

        this.lblDevNote.Size = (System.Drawing.Size) resources.GetObject("lblDevNote.Size");

        this.lblDevNote.TabIndex = (int) resources.GetObject("lblDevNote.TabIndex");

        this.lblDevNote.Text = resources.GetString("lblDevNote.Text");

        this.lblDevNote.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblDevNote.TextAlign");

        this.lblDevNote.Visible = (bool) resources.GetObject("lblDevNote.Visible");

        //

        //ExplorerStyleViewer

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblDevNote});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.Menu = this.mnuMain;

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "ExplorerStyleViewer";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.ResumeLayout(false);

		this.Load +=new System.EventHandler(ExplorerStyleViewer_Load);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);

    }

#endregion

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

    private void mnuExit_Click(object sender, System.EventArgs e) {

        // Close the current form

        this.Close();

    }

#endregion

    // the AfterSelect event for the DirectoryTreeView, which causes the

    // FileListView object to display the contents of the selected directory.

    void DirectoryTreeViewOnAfterSelect(object obj, TreeViewEventArgs tvea)
	{

        flvFiles.ShowFiles(tvea.Node.FullPath);

    }

    // This subroutine handles the Form Load event.

    private void ExplorerStyleViewer_Load(object sender, System.EventArgs e)
{

        // Turn off the developer note that is only for when viewing the Form in 

        // Design View.

        lblDevNote.Visible = false;

    }

    // the OnViewSelect event for the View menu items.

    void MenuOnViewSelect(object obj, EventArgs ea)
	{

        // Uncheck the currently checked item.
        mivChecked.Checked = false;
        // Cast the event sender and check it.
        mivChecked = (MenuItemView) obj;
        mivChecked.Checked = true;
        // Change how the files are viewed in the FileListView control.
        flvFiles.View = mivChecked.view;

    }

}

