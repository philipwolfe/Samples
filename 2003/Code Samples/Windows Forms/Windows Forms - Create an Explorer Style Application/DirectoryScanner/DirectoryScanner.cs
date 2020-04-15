//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;
using System.IO;
using System.Windows.Forms;

public class DirectoryScanner: System.Windows.Forms.Form 
	{

#region " Windows Form Designer generated code "

    public DirectoryScanner () {

        //This call is required by the Windows Form Designer.

        InitializeComponent();

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

    private System.Windows.Forms.Splitter Splitter1;
    private System.Windows.Forms.MainMenu mnuMain;
    private System.Windows.Forms.MenuItem mnuExit;
    private System.Windows.Forms.MenuItem mnuFile;
    private System.Windows.Forms.TreeView tvwDirectories;
    private System.Windows.Forms.StatusBar sbrScan;
    private System.Windows.Forms.ListView lvwDirectories;
    private System.Windows.Forms.MenuItem mnuScan;
    private System.Windows.Forms.MenuItem mnuScanAll;
    private System.Windows.Forms.MenuItem mnuScanFromOne;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DirectoryScanner));
        this.lvwDirectories = new System.Windows.Forms.ListView();
        this.sbrScan = new System.Windows.Forms.StatusBar();
        this.tvwDirectories = new System.Windows.Forms.TreeView();
        this.Splitter1 = new System.Windows.Forms.Splitter();
        this.mnuFile = new System.Windows.Forms.MenuItem();
        this.mnuExit = new System.Windows.Forms.MenuItem();
        this.mnuScanAll = new System.Windows.Forms.MenuItem();
        this.mnuScanFromOne = new System.Windows.Forms.MenuItem();
        this.mnuScan = new System.Windows.Forms.MenuItem();
        this.mnuMain = new System.Windows.Forms.MainMenu();
        this.SuspendLayout();
        //
        //lvwDirectories
        //
        this.lvwDirectories.AccessibleDescription = resources.GetString("lvwDirectories.AccessibleDescription");
        this.lvwDirectories.AccessibleName = resources.GetString("lvwDirectories.AccessibleName");
        this.lvwDirectories.Alignment = (System.Windows.Forms.ListViewAlignment) resources.GetObject("lvwDirectories.Alignment");
        this.lvwDirectories.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lvwDirectories.Anchor");
        this.lvwDirectories.BackgroundImage = (System.Drawing.Image) resources.GetObject("lvwDirectories.BackgroundImage");
        this.lvwDirectories.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lvwDirectories.Dock");
        this.lvwDirectories.Enabled = (bool) resources.GetObject("lvwDirectories.Enabled");
        this.lvwDirectories.Font = (System.Drawing.Font) resources.GetObject("lvwDirectories.Font");
        this.lvwDirectories.FullRowSelect = true;
        this.lvwDirectories.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lvwDirectories.ImeMode");
        this.lvwDirectories.LabelWrap = (bool) resources.GetObject("lvwDirectories.LabelWrap");

        this.lvwDirectories.Location = (System.Drawing.Point) resources.GetObject("lvwDirectories.Location");

        this.lvwDirectories.MultiSelect = false;

        this.lvwDirectories.Name = "lvwDirectories";

        this.lvwDirectories.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lvwDirectories.RightToLeft");

        this.lvwDirectories.Size = (System.Drawing.Size) resources.GetObject("lvwDirectories.Size");

        this.lvwDirectories.TabIndex = (int) resources.GetObject("lvwDirectories.TabIndex");

        this.lvwDirectories.Text = resources.GetString("lvwDirectories.Text");

        this.lvwDirectories.View = System.Windows.Forms.View.Details;

        this.lvwDirectories.Visible = (bool) resources.GetObject("lvwDirectories.Visible");

        //

        //sbrScan

        //

        this.sbrScan.AccessibleDescription = resources.GetString("sbrScan.AccessibleDescription");

        this.sbrScan.AccessibleName = resources.GetString("sbrScan.AccessibleName");

        this.sbrScan.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("sbrScan.Anchor");

        this.sbrScan.BackgroundImage = (System.Drawing.Image) resources.GetObject("sbrScan.BackgroundImage");

        this.sbrScan.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("sbrScan.Dock");

        this.sbrScan.Enabled = (bool) resources.GetObject("sbrScan.Enabled");

        this.sbrScan.Font = (System.Drawing.Font) resources.GetObject("sbrScan.Font");

        this.sbrScan.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("sbrScan.ImeMode");

        this.sbrScan.Location = (System.Drawing.Point) resources.GetObject("sbrScan.Location");

        this.sbrScan.Name = "sbrScan";

        this.sbrScan.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("sbrScan.RightToLeft");

        this.sbrScan.Size = (System.Drawing.Size) resources.GetObject("sbrScan.Size");

        this.sbrScan.TabIndex = (int) resources.GetObject("sbrScan.TabIndex");

        this.sbrScan.Text = resources.GetString("sbrScan.Text");

        this.sbrScan.Visible = (bool) resources.GetObject("sbrScan.Visible");

        //

        //tvwDirectories

        //

        this.tvwDirectories.AccessibleDescription = resources.GetString("tvwDirectories.AccessibleDescription");

        this.tvwDirectories.AccessibleName = resources.GetString("tvwDirectories.AccessibleName");

        this.tvwDirectories.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("tvwDirectories.Anchor");

        this.tvwDirectories.BackgroundImage = (System.Drawing.Image) resources.GetObject("tvwDirectories.BackgroundImage");

        this.tvwDirectories.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("tvwDirectories.Dock");

        this.tvwDirectories.Enabled = (bool) resources.GetObject("tvwDirectories.Enabled");

        this.tvwDirectories.Font = (System.Drawing.Font) resources.GetObject("tvwDirectories.Font");

        this.tvwDirectories.ForeColor = System.Drawing.SystemColors.WindowText;

        this.tvwDirectories.ImageIndex = (int) resources.GetObject("tvwDirectories.ImageIndex");

        this.tvwDirectories.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("tvwDirectories.ImeMode");

        this.tvwDirectories.Indent = (int) resources.GetObject("tvwDirectories.Indent");

        this.tvwDirectories.ItemHeight = (int) resources.GetObject("tvwDirectories.ItemHeight");

        this.tvwDirectories.Location = (System.Drawing.Point) resources.GetObject("tvwDirectories.Location");

        this.tvwDirectories.Name = "tvwDirectories";

        this.tvwDirectories.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("tvwDirectories.RightToLeft");

        this.tvwDirectories.SelectedImageIndex = (int) resources.GetObject("tvwDirectories.SelectedImageIndex");

        this.tvwDirectories.Size = (System.Drawing.Size) resources.GetObject("tvwDirectories.Size");

        this.tvwDirectories.TabIndex = (int) resources.GetObject("tvwDirectories.TabIndex");

        this.tvwDirectories.Text = resources.GetString("tvwDirectories.Text");

        this.tvwDirectories.Visible = (bool) resources.GetObject("tvwDirectories.Visible");

        //

        //Splitter1

        //

        this.Splitter1.AccessibleDescription = resources.GetString("Splitter1.AccessibleDescription");

        this.Splitter1.AccessibleName = resources.GetString("Splitter1.AccessibleName");

        this.Splitter1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Splitter1.Anchor");

        this.Splitter1.BackgroundImage = (System.Drawing.Image) resources.GetObject("Splitter1.BackgroundImage");

        this.Splitter1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Splitter1.Dock");

        this.Splitter1.Enabled = (bool) resources.GetObject("Splitter1.Enabled");

        this.Splitter1.Font = (System.Drawing.Font) resources.GetObject("Splitter1.Font");

        this.Splitter1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Splitter1.ImeMode");

        this.Splitter1.Location = (System.Drawing.Point) resources.GetObject("Splitter1.Location");

        this.Splitter1.MinExtra = (int) resources.GetObject("Splitter1.MinExtra");

        this.Splitter1.MinSize = (int) resources.GetObject("Splitter1.MinSize");

        this.Splitter1.Name = "Splitter1";

        this.Splitter1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Splitter1.RightToLeft");

        this.Splitter1.Size = (System.Drawing.Size) resources.GetObject("Splitter1.Size");

        this.Splitter1.TabIndex = (int) resources.GetObject("Splitter1.TabIndex");

        this.Splitter1.TabStop = false;

        this.Splitter1.Visible = (bool) resources.GetObject("Splitter1.Visible");

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

        //mnuScanAll

        //

        this.mnuScanAll.Enabled = (bool) resources.GetObject("mnuScanAll.Enabled");

        this.mnuScanAll.Index = 0;

        this.mnuScanAll.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuScanAll.Shortcut");

        this.mnuScanAll.ShowShortcut = (bool) resources.GetObject("mnuScanAll.ShowShortcut");

        this.mnuScanAll.Text = resources.GetString("mnuScanAll.Text");

        this.mnuScanAll.Visible = (bool) resources.GetObject("mnuScanAll.Visible");
		

        //

        //mnuScanFromOne

        //

        this.mnuScanFromOne.Enabled = (bool) resources.GetObject("mnuScanFromOne.Enabled");

        this.mnuScanFromOne.Index = 1;

        this.mnuScanFromOne.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuScanFromOne.Shortcut");

        this.mnuScanFromOne.ShowShortcut = (bool) resources.GetObject("mnuScanFromOne.ShowShortcut");

        this.mnuScanFromOne.Text = resources.GetString("mnuScanFromOne.Text");

        this.mnuScanFromOne.Visible = (bool) resources.GetObject("mnuScanFromOne.Visible");

        //

        //mnuScan

        //

        this.mnuScan.Enabled = (bool) resources.GetObject("mnuScan.Enabled");

        this.mnuScan.Index = 1;

        this.mnuScan.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuScanAll, this.mnuScanFromOne});

        this.mnuScan.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuScan.Shortcut");

        this.mnuScan.ShowShortcut = (bool) resources.GetObject("mnuScan.ShowShortcut");

        this.mnuScan.Text = resources.GetString("mnuScan.Text");

        this.mnuScan.Visible = (bool) resources.GetObject("mnuScan.Visible");

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuScan});

        this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

        //

        //DirectoryScanner

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lvwDirectories, this.Splitter1, this.tvwDirectories, this.sbrScan});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.Menu = this.mnuMain;

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "DirectoryScanner";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.ResumeLayout(false);

		this.Load +=new System.EventHandler(DirectoryScanner_Load);
		this.mnuExit.Click +=new System.EventHandler(mnuExit_Click);
		this.mnuScanAll.Click +=new EventHandler(mnuScanAll_Click);
		this.mnuScanFromOne.Click +=new EventHandler(mnuScanFromOne_Click);
		this.tvwDirectories.AfterExpand +=new TreeViewEventHandler(TreeView_AfterExpand);
		this.tvwDirectories.AfterSelect +=new TreeViewEventHandler(TreeView_AfterSelect);
    }

#endregion

#region " Standard Menu Code "

    // This code simply shows the About form.

    [System.Diagnostics.DebuggerStepThroughAttribute()] private void mnuAbout_Click(object sender, System.EventArgs e)
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

    const Int64 MB = 1024 * 1024;

    // the Click event for the "Scan | All Directories" menu item.

    private void mnuScanAll_Click(object sender, System.EventArgs e) 
	{
        // Get an array of all logical drives.
        string[] Drives = Directory.GetLogicalDrives();
        tvwDirectories.Nodes.Clear();
        lvwDirectories.Items.Clear();
        foreach(string drive in Drives)
		{
            DirectoryNode dnDrive;
            try 
			{
                // Create a DirectoryNode that represents each logical drive and add
                // it to the TreeView.
                dnDrive = new DirectoryNode();
                dnDrive.Text = drive.Remove(drive.Length-1, 1);
                tvwDirectories.Nodes.Add(dnDrive);
                // Calculate the size of the drive by adding up the size of all its
                // sub-directories.
                dnDrive.Size += GetDirectorySize(drive, dnDrive);
           } catch
			{
                // Do nothing. Simply skip any directories that can't be read. Control
                // passes to the first line after }.
            }
        }
    }

    // the Click event for the "Scan | From One Directory" menu item.

    private void mnuScanFromOne_Click(object sender, System.EventArgs e) 
	{
        // Show the FolderBrowser dialog and set the initial directory to the 
        // user's selection.

        string strSelectedDirectory = FolderBrowser.ShowDialog();
        DirectoryNode dnSelectedDirectory;
        tvwDirectories.Nodes.Clear();
        lvwDirectories.Items.Clear();
        try {

            // Add the DirectoryNode that represents the selected directory to the
            // TreeView.

            dnSelectedDirectory = new DirectoryNode();
            dnSelectedDirectory.Text = strSelectedDirectory;
            tvwDirectories.Nodes.Add(dnSelectedDirectory);
            // Calculate the size of the selected directory by adding up the size of 
            // all its sub-directories.
            dnSelectedDirectory.Size += GetDirectorySize(strSelectedDirectory, 
				dnSelectedDirectory);

       } catch
		{

            // Do nothing. Simply skip any directories that can't be read. Control
            // passes to the first line after }.
        }

    }

    // the Load event for the DirectoryScanner.

    private void DirectoryScanner_Load(object sender, System.EventArgs e)
	{

        // Set up the initial ListView columns
        lvwDirectories.Columns.Add("Size", 90, HorizontalAlignment.Left);
        lvwDirectories.Columns.Add("Folder Name", 400, HorizontalAlignment.Left);

    }

    // the AfterExpand event for the TreeView, which does not occur after 
    // the TreeView is selected, but after the application decides that the user's 
    // attempt to expand the node should be allowed. The corresponding BeforeExpand 
    // event handler is used for this decision making, if desired. All Before______
    // events pass a TreeViewCancelEventArgs object that contains a Cancel property.
    // This property can be used for vetoing the user's action. Thus, the "AfterExpand"
    // event could rightly be named "AfterExpandApproval".

    private void TreeView_AfterExpand(object sender, TreeViewEventArgs e) 
	{

        e.Node.Expand();

        ShowSubDirectories((DirectoryNode) e.Node);

    }

    // the AfterSelect event for the TreeView, which does not occur after 
    // the TreeView is selected, but after the application decides that the user's 
    // attempt to select the node should be allowed. The corresponding BeforeSelect 
    // event handler is used for this decision making, if desired. All Before______
    // events pass a TreeViewCancelEventArgs object that contains a Cancel property.
    // This property can be used for vetoing the user's action. Thus, the "AfterSelect"
    // event could rightly be named "AfterSelectApproval".

    private void TreeView_AfterSelect(object sender, TreeViewEventArgs e) 
	{
        DirectoryNode strSubDirectory = (DirectoryNode) e.Node;
        lvwDirectories.Items.Clear();
        AddToListView(String.Format((strSubDirectory.Size /MB).ToString(),"F") + "MB", 
			strSubDirectory.Text);

    }

    // This subroutine adds the strSubDirectory that the user selects on the TreeView 
    // to the ListView, and sets the text, size, and color.

    private void AddToListView(string strSize, string strFolderName)
	{

        ListViewItem lvi = new ListViewItem();
        ListViewItem.ListViewSubItem lvsi;

        lvi.Text = strSize;
        lvi.ForeColor = GetSizeColor(strSize);
        lvsi = new ListViewItem.ListViewSubItem();
        lvsi.Text = strFolderName;
        lvi.SubItems.Add(lvsi);
        lvwDirectories.Items.Add(lvi);

    }

    // This subroutine returns a Color based on the combined size of the directory 
    // and all its subdirectories. This is one of two overloads.

    private System.Drawing.Color GetSizeColor(string strSize)
	{
        return GetSizeColor(Convert.ToInt64(Convert.ToDouble(strSize.Substring(0, strSize.LastIndexOf("M"))) * MB));
    }

    // This function returns a Color based on the combined size of the directory 
    // and all its subdirectories. This is the second of two overloads.

    private System.Drawing.Color GetSizeColor(Int64 intSize)
		{
		
		if ((intSize >= (200 * MB)) && (intSize <= (500 * MB)))
		{
			return System.Drawing.Color.Gold;
		}
		else if (intSize >= (500 * MB))
		{
			return System.Drawing.Color.Red;
		}
		else
		{
			return System.Drawing.Color.Green;
		}

    }

    // This function returns the size of a directory, and all its sub-directories.

    public Int64 GetDirectorySize(string strDirPath, DirectoryNode dnDriveOrDirectory)
	{

        // Show the current scan directory in the status bar.

        sbrScan.Text = "Scanning : " + strDirPath;

        try {

           string[] astrSubDirectories  = Directory.GetDirectories(strDirPath);

            // The size of the current directory is dependent on the size 
            // of the sub-directories in the array astrSubDirectories. So iterate
            // through the array and use recursion to end up with the total
            // size of the current directory and all its sub-directories.

            foreach(string strSubDirectory in astrSubDirectories)
			{
                DirectoryNode dnSubDirectoryNode;
                dnSubDirectoryNode = new DirectoryNode();

                // Set the node text = to only the last part of the full path.
                dnSubDirectoryNode.Text = 
					strSubDirectory.Remove(0, strSubDirectory.LastIndexOf(@"\"));

                // Note that the following line is recursive.

                dnDriveOrDirectory.Size +=
                    GetDirectorySize(strSubDirectory, dnSubDirectoryNode);
                dnDriveOrDirectory.Nodes.Add(dnSubDirectoryNode);

            }

            // Add to the size calcutate above all of the files in the current 
            // directory.

            string[] astrFiles = Directory.GetFiles(strDirPath);

            foreach(string strFileName in astrFiles)
				 {
				FileInfo fi = new FileInfo(strFileName);				  
                dnDriveOrDirectory.Size += fi.Length;
            }

            // Set the color of the TreeNode based on the total calculated size.

            dnDriveOrDirectory.ForeColor = GetSizeColor(dnDriveOrDirectory.Size);

       } catch
		{

            // Do nothing. Simply skip any directories that can't be read. Control

            // passes to the first line after }.

        }

        // Reset the StatusBar and return the total size for this directory.

        sbrScan.Text = string.Empty;

        return dnDriveOrDirectory.Size;

    }

    // When a directory node is expanded, add its subdirectories to the ListView.

    public void ShowSubDirectories(DirectoryNode dnDrive)
	{

        lvwDirectories.Items.Clear();

        foreach(DirectoryNode strSubDirectory in dnDrive.Nodes)
		{
            AddToListView(String.Format((strSubDirectory.Size / MB).ToString(), "F") + "MB",
                strSubDirectory.Text);

        }

    }

}

