//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.IO;

public class frmMain: System.Windows.Forms.Form 
{

#region " Windows Form Designer generated code "

	public frmMain() 
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
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

	private System.Windows.Forms.TreeView tvwRoot;

	private System.Windows.Forms.Label lblLength;

	private System.Windows.Forms.Label lblRoot;

	private System.Windows.Forms.Label lblParent;

	private System.Windows.Forms.Label lblName;

	private System.Windows.Forms.Label lblFullName;

	private System.Windows.Forms.Label lblExtension;

	private System.Windows.Forms.Label lblLastWriteTime;

	private System.Windows.Forms.Label lblLastAccessTime;

	private System.Windows.Forms.Label lblCreationTime;

	private System.Windows.Forms.Label lblLengthLabel;

	private System.Windows.Forms.Label lblRootLabel;

	private System.Windows.Forms.Label lblParentLabel;

	private System.Windows.Forms.Label Label7;

	private System.Windows.Forms.Label Label6;

	private System.Windows.Forms.Label Label5;

	private System.Windows.Forms.Label Label4;

	private System.Windows.Forms.Label Label3;

	private System.Windows.Forms.Label Label2;

	private System.Windows.Forms.Label lblAttributes;

	private System.Windows.Forms.Label Label1;

	private System.Windows.Forms.MenuItem mnuRefresh;

	private void InitializeComponent() {

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuRefresh = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.tvwRoot = new System.Windows.Forms.TreeView();

		this.lblLength = new System.Windows.Forms.Label();

		this.lblRoot = new System.Windows.Forms.Label();

		this.lblParent = new System.Windows.Forms.Label();

		this.lblName = new System.Windows.Forms.Label();

		this.lblFullName = new System.Windows.Forms.Label();

		this.lblExtension = new System.Windows.Forms.Label();

		this.lblLastWriteTime = new System.Windows.Forms.Label();

		this.lblLastAccessTime = new System.Windows.Forms.Label();

		this.lblCreationTime = new System.Windows.Forms.Label();

		this.lblLengthLabel = new System.Windows.Forms.Label();

		this.lblRootLabel = new System.Windows.Forms.Label();

		this.lblParentLabel = new System.Windows.Forms.Label();

		this.Label7 = new System.Windows.Forms.Label();

		this.Label6 = new System.Windows.Forms.Label();

		this.Label5 = new System.Windows.Forms.Label();

		this.Label4 = new System.Windows.Forms.Label();

		this.Label3 = new System.Windows.Forms.Label();

		this.Label2 = new System.Windows.Forms.Label();

		this.lblAttributes = new System.Windows.Forms.Label();

		this.Label1 = new System.Windows.Forms.Label();

		this.SuspendLayout();

		//

		//mnuMain

		//

		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

		//

		//mnuFile

		//

		this.mnuFile.Index = 0;

		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuRefresh, this.mnuExit});

		this.mnuFile.Text = "&File";

		//

		//mnuRefresh

		//

		this.mnuRefresh.Index = 0;

		this.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;

		this.mnuRefresh.Text = "&Refresh";
		this.mnuRefresh.Click += new EventHandler(mnuRefresh_Click);

		//

		//mnuExit

		//

		this.mnuExit.Index = 1;

		this.mnuExit.Text = "E&xit";
		this.mnuExit.Click += new EventHandler(mnuExit_Click);

		//

		//mnuHelp

		//

		this.mnuHelp.Index = 1;

		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

		this.mnuHelp.Text = "&Help";

		//

		//mnuAbout

		//

		this.mnuAbout.Index = 0;

		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);

		//

		//tvwRoot

		//

		this.tvwRoot.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.tvwRoot.ImageIndex = -1;

		this.tvwRoot.Indent = 19;

		this.tvwRoot.ItemHeight = 16;

		this.tvwRoot.Location = new System.Drawing.Point(8, 8);

		this.tvwRoot.Name = "tvwRoot";

		this.tvwRoot.SelectedImageIndex = -1;

		this.tvwRoot.Size = new System.Drawing.Size(392, 195);

		this.tvwRoot.TabIndex = 0;
		this.tvwRoot.AfterSelect += new TreeViewEventHandler(tvwRoot_AfterSelect);
		this.tvwRoot.BeforeExpand += new TreeViewCancelEventHandler(tvwRoot_BeforeExpand);

		//

		//lblLength

		//

		this.lblLength.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblLength.BackColor = System.Drawing.Color.Transparent;

		this.lblLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblLength.ForeColor = System.Drawing.Color.Black;

		this.lblLength.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblLength.Location = new System.Drawing.Point(120, 435);

		this.lblLength.Name = "lblLength";

		this.lblLength.Size = new System.Drawing.Size(280, 20);

		this.lblLength.TabIndex = 66;

		this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//lblRoot

		//

		this.lblRoot.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblRoot.BackColor = System.Drawing.Color.Transparent;

		this.lblRoot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblRoot.ForeColor = System.Drawing.Color.Black;

		this.lblRoot.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblRoot.Location = new System.Drawing.Point(120, 411);

		this.lblRoot.Name = "lblRoot";

		this.lblRoot.Size = new System.Drawing.Size(280, 20);

		this.lblRoot.TabIndex = 65;

		this.lblRoot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//lblParent

		//

		this.lblParent.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblParent.BackColor = System.Drawing.Color.Transparent;

		this.lblParent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblParent.ForeColor = System.Drawing.Color.Black;

		this.lblParent.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblParent.Location = new System.Drawing.Point(120, 387);

		this.lblParent.Name = "lblParent";

		this.lblParent.Size = new System.Drawing.Size(280, 20);

		this.lblParent.TabIndex = 64;

		this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//lblName

		//

		this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblName.BackColor = System.Drawing.Color.Transparent;

		this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblName.ForeColor = System.Drawing.Color.Black;

		this.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblName.Location = new System.Drawing.Point(120, 363);

		this.lblName.Name = "lblName";

		this.lblName.Size = new System.Drawing.Size(280, 20);

		this.lblName.TabIndex = 63;

		this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//lblFullName

		//

		this.lblFullName.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblFullName.BackColor = System.Drawing.Color.Transparent;

		this.lblFullName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblFullName.ForeColor = System.Drawing.Color.Black;

		this.lblFullName.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblFullName.Location = new System.Drawing.Point(120, 339);

		this.lblFullName.Name = "lblFullName";

		this.lblFullName.Size = new System.Drawing.Size(280, 20);

		this.lblFullName.TabIndex = 62;

		this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//lblExtension

		//

		this.lblExtension.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblExtension.BackColor = System.Drawing.Color.Transparent;

		this.lblExtension.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblExtension.ForeColor = System.Drawing.Color.Black;

		this.lblExtension.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblExtension.Location = new System.Drawing.Point(120, 315);

		this.lblExtension.Name = "lblExtension";

		this.lblExtension.Size = new System.Drawing.Size(280, 20);

		this.lblExtension.TabIndex = 61;

		this.lblExtension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//lblLastWriteTime

		//

		this.lblLastWriteTime.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblLastWriteTime.BackColor = System.Drawing.Color.Transparent;

		this.lblLastWriteTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblLastWriteTime.ForeColor = System.Drawing.Color.Black;

		this.lblLastWriteTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblLastWriteTime.Location = new System.Drawing.Point(120, 283);

		this.lblLastWriteTime.Name = "lblLastWriteTime";

		this.lblLastWriteTime.Size = new System.Drawing.Size(280, 20);

		this.lblLastWriteTime.TabIndex = 60;

		this.lblLastWriteTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//lblLastAccessTime

		//

		this.lblLastAccessTime.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblLastAccessTime.BackColor = System.Drawing.Color.Transparent;

		this.lblLastAccessTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblLastAccessTime.ForeColor = System.Drawing.Color.Black;

		this.lblLastAccessTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblLastAccessTime.Location = new System.Drawing.Point(120, 259);

		this.lblLastAccessTime.Name = "lblLastAccessTime";

		this.lblLastAccessTime.Size = new System.Drawing.Size(280, 20);

		this.lblLastAccessTime.TabIndex = 59;

		this.lblLastAccessTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//lblCreationTime

		//

		this.lblCreationTime.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblCreationTime.BackColor = System.Drawing.Color.Transparent;

		this.lblCreationTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblCreationTime.ForeColor = System.Drawing.Color.Black;

		this.lblCreationTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblCreationTime.Location = new System.Drawing.Point(120, 235);

		this.lblCreationTime.Name = "lblCreationTime";

		this.lblCreationTime.Size = new System.Drawing.Size(280, 20);

		this.lblCreationTime.TabIndex = 58;

		this.lblCreationTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//lblLengthLabel

		//

		this.lblLengthLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.lblLengthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblLengthLabel.Location = new System.Drawing.Point(8, 434);

		this.lblLengthLabel.Name = "lblLengthLabel";

		this.lblLengthLabel.Size = new System.Drawing.Size(104, 23);

		this.lblLengthLabel.TabIndex = 57;

		this.lblLengthLabel.Text = "Length";

		this.lblLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//lblRootLabel

		//

		this.lblRootLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.lblRootLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblRootLabel.Location = new System.Drawing.Point(8, 410);

		this.lblRootLabel.Name = "lblRootLabel";

		this.lblRootLabel.Size = new System.Drawing.Size(104, 23);

		this.lblRootLabel.TabIndex = 56;

		this.lblRootLabel.Text = "Root";

		this.lblRootLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//lblParentLabel

		//

		this.lblParentLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.lblParentLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblParentLabel.Location = new System.Drawing.Point(8, 386);

		this.lblParentLabel.Name = "lblParentLabel";

		this.lblParentLabel.Size = new System.Drawing.Size(104, 23);

		this.lblParentLabel.TabIndex = 55;

		this.lblParentLabel.Text = "Parent";

		this.lblParentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//Label7

		//

		this.Label7.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.Label7.Location = new System.Drawing.Point(8, 362);

		this.Label7.Name = "Label7";

		this.Label7.Size = new System.Drawing.Size(104, 23);

		this.Label7.TabIndex = 54;

		this.Label7.Text = "Name";

		this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//Label6

		//

		this.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.Label6.Location = new System.Drawing.Point(8, 338);

		this.Label6.Name = "Label6";

		this.Label6.Size = new System.Drawing.Size(104, 23);

		this.Label6.TabIndex = 53;

		this.Label6.Text = "Full Name";

		this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//Label5

		//

		this.Label5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.Label5.Location = new System.Drawing.Point(8, 314);

		this.Label5.Name = "Label5";

		this.Label5.Size = new System.Drawing.Size(104, 23);

		this.Label5.TabIndex = 52;

		this.Label5.Text = "Extension";

		this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//Label4

		//

		this.Label4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.Label4.Location = new System.Drawing.Point(8, 282);

		this.Label4.Name = "Label4";

		this.Label4.Size = new System.Drawing.Size(104, 23);

		this.Label4.TabIndex = 51;

		this.Label4.Text = "Last Write Time";

		this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//Label3

		//

		this.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.Label3.Location = new System.Drawing.Point(8, 258);

		this.Label3.Name = "Label3";

		this.Label3.Size = new System.Drawing.Size(104, 23);

		this.Label3.TabIndex = 50;

		this.Label3.Text = "Last Access Time";

		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//Label2

		//

		this.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.Label2.Location = new System.Drawing.Point(8, 234);

		this.Label2.Name = "Label2";

		this.Label2.Size = new System.Drawing.Size(104, 23);

		this.Label2.TabIndex = 49;

		this.Label2.Text = "Creation Time";

		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//lblAttributes

		//

		this.lblAttributes.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lblAttributes.BackColor = System.Drawing.Color.Transparent;

		this.lblAttributes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblAttributes.ForeColor = System.Drawing.Color.Black;

		this.lblAttributes.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblAttributes.Location = new System.Drawing.Point(120, 211);

		this.lblAttributes.Name = "lblAttributes";

		this.lblAttributes.Size = new System.Drawing.Size(280, 20);

		this.lblAttributes.TabIndex = 48;

		this.lblAttributes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//Label1

		//

		this.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

		this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.Label1.Location = new System.Drawing.Point(8, 210);

		this.Label1.Name = "Label1";

		this.Label1.Size = new System.Drawing.Size(104, 23);

		this.Label1.TabIndex = 47;

		this.Label1.Text = "Attributes";

		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//frmMain

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(408, 458);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblLength, this.lblRoot, this.lblParent, this.lblName, this.lblFullName, this.lblExtension, this.lblLastWriteTime, this.lblLastAccessTime, this.lblCreationTime, this.lblLengthLabel, this.lblRootLabel, this.lblParentLabel, this.Label7, this.Label6, this.Label5, this.Label4, this.Label3, this.Label2, this.lblAttributes, this.Label1, this.tvwRoot});

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.Menu = this.mnuMain;

		this.MinimumSize = new System.Drawing.Size(416, 472);

		this.Name = "frmMain";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "Title Comes from Assembly Info";

		this.ResumeLayout(false);
		this.Load += new EventHandler(frmMain_Load);
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
	private void mnuExit_Click(object sender, System.EventArgs e) 
	{
		// Close the current form
		this.Close();
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

#region " Form Load "
	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.
		AssemblyInfo ainfo = new AssemblyInfo();

		this.Text = ainfo.Title;
		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
		LoadTreeView();
	}
#endregion

	// Use this text for each "dummy" node in the
	// TreeView. See comments below for more information.
	private const string DUMMY = "DUMMY";

	// Keep track of whether a particular
	// item in the TreeView control is a file 
	// or a folder.
	private enum ItemType
	{
		Directory = 1,
		File = 2
	}
	
	private void mnuRefresh_Click(object sender, System.EventArgs e)
	{
		LoadTreeView();
	}

	private void tvwRoot_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) 
	{
		try 
		{
			if(e.Node.Tag is ItemType)
			{
				switch((ItemType) e.Node.Tag)
				{
					case ItemType.File:
					{
						// FileInfo objects don't supply 
						// Parent or Root properties:
						lblParent.Text = string.Empty;
						lblRoot.Text = string.Empty;

						// Disable/Enable labels.
						lblParentLabel.Enabled = false;
						lblRootLabel.Enabled = false;
						lblLengthLabel.Enabled = true;

						// Get a FileInfo object corresponding to 
						// the selected file, then display its 
						// properties.
						FileInfo fi = new FileInfo(e.Node.FullPath);
						lblLength.Text = fi.Length.ToString();
						DisplayFSIProperties(fi);
						break;
					}
					case ItemType.Directory:
					{
						// DirectoryInfo objects don't provide
						// a Length property:
						lblLength.Text = string.Empty;

						// Disable/Enable labels.
						lblLengthLabel.Enabled = false;
						lblParentLabel.Enabled = true;
						lblRootLabel.Enabled = true;

						// Get a DirectoryInfo object corresponding
						// to the selected directory, then display
						// its properties.
						DirectoryInfo di = new DirectoryInfo(e.Node.FullPath);

						lblParent.Text = di.Parent.Name;
						lblRoot.Text = di.Root.Name;
						DisplayFSIProperties(di);
						break;
					}
					default:
					{
						// Clear out the labels.
						ClearProperties();
						break;
					}
				}
			}
			else
			{
				// Clear out the labels.
				ClearProperties();
			}
		}
		catch (Exception exp)
		{
			MessageBox.Show(exp.Message, this.Text);
		}
	}

	private void tvwRoot_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
	{
		// Before expanding a node, remove existing child nodes. 
		// This emulates Windows Explorer's behavior -- if
		// there are directories and/or files within the drive, the
		// TreeView will display them. if not, the + sign simply 
		// disappears when you attempt to expand the node.
		try 
		{
			e.Node.Nodes.Clear();

			// Go out and get the folder and file names.
			AddFolders(e.Node);
			AddFiles(e.Node);
		}
		catch(IOException)
		{
			// Perhaps the drive isn't ready. In that
			// case, simply disregard the error.
		}
		catch(Exception exp)
		{
			// if any other error occurs, display an alert.
			MessageBox.Show(exp.ToString(), this.Text);
		}
	}

	private void AddFiles(TreeNode nod)
	{
		string strPath = nod.FullPath;

		foreach(string strFile in Directory.GetFiles(strPath))
		{
			TreeNode newNode = nod.Nodes.Add(Path.GetFileName(strFile));
			newNode.Tag = ItemType.File;
		}
	}

	private void AddFolders(TreeNode nod)
	{
		string strPath = nod.FullPath;

		foreach(string strDir in Directory.GetDirectories(strPath))
		{
			// Path.GetFileName returns just the file name portion
			// of the full path returned from the GetDirectories
			// method.
			TreeNode newNode = nod.Nodes.Add(Path.GetFileName(strDir));

			// Keep track that this item 
			// is, in fact, a directory. We'll need
			// that info later. 
			newNode.Tag = ItemType.Directory;

			// Add the DUMMY node, so the + sign appears.
			newNode.Nodes.Add(DUMMY);
		}
	}

	private void ClearProperties()
	{
		lblParent.Text = string.Empty;
		lblRoot.Text = string.Empty;
		lblLength.Text = string.Empty;
		lblAttributes.Text = string.Empty;
		lblCreationTime.Text = string.Empty;
		lblLastAccessTime.Text = string.Empty;
		lblLastWriteTime.Text = string.Empty;
		lblExtension.Text = string.Empty;
		lblFullName.Text = string.Empty;
		lblName.Text = string.Empty;
	}

	private void DisplayFSIProperties(FileSystemInfo fsi)
	{
		// Display properties common to both DirectoryInfo
		// and FileInfo objects. Note that this works 
		// because both objects inherit from FileSystemInfo.
		lblAttributes.Text = fsi.Attributes.ToString();
		lblCreationTime.Text = fsi.CreationTime.ToString();
		lblLastAccessTime.Text = fsi.LastAccessTime.ToString();
		lblLastWriteTime.Text = fsi.LastWriteTime.ToString();
		lblExtension.Text = fsi.Extension;
		lblFullName.Text = fsi.FullName;
		lblName.Text = fsi.Name;
	}

	private void LoadTreeView()
	{
		// Loop through all the drives installed on the 
		// computer, adding a node for each. In addition,
		// add a DUMMY node under each existing node,
		// so that the plus sign will appear.
		// Directory.GetLogicalDrives returns an array
		// of strings, each representing one of the
		// installed drives. The .NET Framework doesn't
		// supply methods for determining information about
		// drives -- use the COM-based FileSystemInfo class
		// instead.

		tvwRoot.Nodes.Clear();

		foreach(string strDrive in Directory.GetLogicalDrives())
		{
			TreeNode nod = tvwRoot.Nodes.Add(strDrive);
			nod.Nodes.Add(DUMMY);
		}
	}
}