/// Disk Space Explorer
/// 
/// Author: Minh T. Nguyen
/// Email: nguyentriminh@yahoo.com
/// Website: http://www.vnorganizations.com/minh
/// 
/// Description: I needed a program to analyze my disk space usage, because I keep
/// on running out of disk space. So, this program goes through all folders on the
/// hard disk and adds up their sizes and displays them in a tree view, to find out
/// which folders I need to concentrate on deleting.

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MinhNguyen.DiskSpaceExplorer
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label thisSpace;
		private System.Windows.Forms.Label thisFiles;
		private System.Windows.Forms.Button chooseDrive;
		private System.Windows.Forms.Button exit;
		private System.Windows.Forms.GroupBox thisGroup;
		private System.Windows.Forms.GroupBox allGroup;
		public System.Windows.Forms.TreeView folderTree;
		private System.Windows.Forms.Label thisFolders;
		private System.Windows.Forms.Label totalFolders;
		private System.Windows.Forms.Label totalFiles;
		private System.Windows.Forms.Label totalSpace;


		#region boring windows stuff

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.folderTree = new System.Windows.Forms.TreeView();
			this.thisGroup = new System.Windows.Forms.GroupBox();
			this.thisFolders = new System.Windows.Forms.Label();
			this.thisFiles = new System.Windows.Forms.Label();
			this.thisSpace = new System.Windows.Forms.Label();
			this.allGroup = new System.Windows.Forms.GroupBox();
			this.totalFolders = new System.Windows.Forms.Label();
			this.totalFiles = new System.Windows.Forms.Label();
			this.totalSpace = new System.Windows.Forms.Label();
			this.chooseDrive = new System.Windows.Forms.Button();
			this.exit = new System.Windows.Forms.Button();
			this.thisGroup.SuspendLayout();
			this.allGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// folderTree
			// 
			this.folderTree.ImageIndex = -1;
			this.folderTree.Location = new System.Drawing.Point(8, 8);
			this.folderTree.Name = "folderTree";
			this.folderTree.SelectedImageIndex = -1;
			this.folderTree.Size = new System.Drawing.Size(368, 288);
			this.folderTree.TabIndex = 0;
			this.folderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.folderTree_AfterSelect);
			// 
			// thisGroup
			// 
			this.thisGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.thisFolders,
																					this.thisFiles,
																					this.thisSpace});
			this.thisGroup.Location = new System.Drawing.Point(384, 112);
			this.thisGroup.Name = "thisGroup";
			this.thisGroup.Size = new System.Drawing.Size(152, 96);
			this.thisGroup.TabIndex = 1;
			this.thisGroup.TabStop = false;
			this.thisGroup.Text = "This directory";
			// 
			// thisFolders
			// 
			this.thisFolders.Location = new System.Drawing.Point(8, 72);
			this.thisFolders.Name = "thisFolders";
			this.thisFolders.Size = new System.Drawing.Size(136, 16);
			this.thisFolders.TabIndex = 2;
			this.thisFolders.Text = "Folders: 0";
			// 
			// thisFiles
			// 
			this.thisFiles.Location = new System.Drawing.Point(8, 48);
			this.thisFiles.Name = "thisFiles";
			this.thisFiles.Size = new System.Drawing.Size(136, 16);
			this.thisFiles.TabIndex = 1;
			this.thisFiles.Text = "Files: 0";
			// 
			// thisSpace
			// 
			this.thisSpace.Location = new System.Drawing.Point(8, 24);
			this.thisSpace.Name = "thisSpace";
			this.thisSpace.Size = new System.Drawing.Size(136, 16);
			this.thisSpace.TabIndex = 0;
			this.thisSpace.Text = "Space: 0 MB";
			// 
			// allGroup
			// 
			this.allGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.totalFolders,
																				   this.totalFiles,
																				   this.totalSpace});
			this.allGroup.Location = new System.Drawing.Point(384, 8);
			this.allGroup.Name = "allGroup";
			this.allGroup.Size = new System.Drawing.Size(152, 96);
			this.allGroup.TabIndex = 2;
			this.allGroup.TabStop = false;
			this.allGroup.Text = "This + all sub-directories";
			// 
			// totalFolders
			// 
			this.totalFolders.Location = new System.Drawing.Point(8, 72);
			this.totalFolders.Name = "totalFolders";
			this.totalFolders.Size = new System.Drawing.Size(128, 16);
			this.totalFolders.TabIndex = 2;
			this.totalFolders.Text = "Folders: 0";
			// 
			// totalFiles
			// 
			this.totalFiles.Location = new System.Drawing.Point(8, 48);
			this.totalFiles.Name = "totalFiles";
			this.totalFiles.Size = new System.Drawing.Size(136, 16);
			this.totalFiles.TabIndex = 1;
			this.totalFiles.Text = "Files: 0";
			// 
			// totalSpace
			// 
			this.totalSpace.Location = new System.Drawing.Point(8, 24);
			this.totalSpace.Name = "totalSpace";
			this.totalSpace.Size = new System.Drawing.Size(136, 16);
			this.totalSpace.TabIndex = 0;
			this.totalSpace.Text = "Space: 0 MB";
			// 
			// chooseDrive
			// 
			this.chooseDrive.Location = new System.Drawing.Point(384, 240);
			this.chooseDrive.Name = "chooseDrive";
			this.chooseDrive.Size = new System.Drawing.Size(152, 23);
			this.chooseDrive.TabIndex = 3;
			this.chooseDrive.Text = "&Choose different drive";
			this.chooseDrive.Click += new System.EventHandler(this.chooseDrive_Click);
			// 
			// exit
			// 
			this.exit.Location = new System.Drawing.Point(384, 272);
			this.exit.Name = "exit";
			this.exit.Size = new System.Drawing.Size(152, 23);
			this.exit.TabIndex = 4;
			this.exit.Text = "E&xit";
			this.exit.Click += new System.EventHandler(this.exit_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 310);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.exit,
																		  this.chooseDrive,
																		  this.allGroup,
																		  this.thisGroup,
																		  this.folderTree});
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "MainForm";
			this.Text = "Minh\'s Disk Space Explorer";
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.thisGroup.ResumeLayout(false);
			this.allGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void MainForm_Resize(object sender, System.EventArgs e)
		{
			int horizontalGap = 15;
			int verticalGap = 55;

			// resize right controls
			allGroup.Left = this.Width - allGroup.Width - horizontalGap;
			thisGroup.Left = this.Width - thisGroup.Width - horizontalGap;
			chooseDrive.Left = this.Width - chooseDrive.Width - horizontalGap;
			exit.Left = this.Width - exit.Width - horizontalGap;
			chooseDrive.Top = this.Height - 100;
			exit.Top = this.Height - 70;

			// resize folder tree
			folderTree.Width = this.Width - allGroup.Width - horizontalGap*2;
			folderTree.Height = this.Height - verticalGap;
		}

		private void exit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#endregion

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			(new DriveChoice(this)).ShowDialog();
		}

		private void chooseDrive_Click(object sender, System.EventArgs e)
		{
			(new DriveChoice(this)).ShowDialog();
		}


		private void folderTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			FolderNode folderNode = (FolderNode) e.Node;

			thisFiles.Text = "Files: " + folderNode.thisFiles;
			thisFolders.Text = "Folders: " + folderNode.thisFolders;

			// display space usage
			if (folderNode.thisBytes < 1024)
				thisSpace.Text = "Space: " + folderNode.thisBytes + " B";
			else if (folderNode.thisBytes*1.0/1024 < 1024)
				thisSpace.Text = "Space: " + Convert.ToDouble(folderNode.thisBytes*1.0/1024).ToString("0.00") + " KB";
			else if ((folderNode.thisBytes*1.0/1024)/1024 < 1024)
				thisSpace.Text = "Space: " + Convert.ToDouble((folderNode.thisBytes*1.0/1024)/1024).ToString("0.00") + " MB";
			else if (((folderNode.thisBytes*1.0/1024)/1024)/1024 < 1024)
				thisSpace.Text = "Space: " + Convert.ToDouble(((folderNode.thisBytes*1.0/1024)/1024)/1024).ToString("0.00") + " GB";
			else
				thisSpace.Text = "Space: >1 TB";


			totalFiles.Text = "Files: " + folderNode.totalFiles;
			totalFolders.Text = "Folders: " + folderNode.totalFolders;

			// display space usage
			if (folderNode.totalBytes < 1024)
				totalSpace.Text = "Space: " + folderNode.totalBytes + " B";
			else if (folderNode.totalBytes*1.0/1024 < 1024)
				totalSpace.Text = "Space: " + Convert.ToDouble(folderNode.totalBytes*1.0/1024).ToString("0.00") + " KB";
			else if ((folderNode.totalBytes*1.0/1024)/1024 < 1024)
				totalSpace.Text = "Space: " + Convert.ToDouble((folderNode.totalBytes*1.0/1024)/1024).ToString("0.00") + " MB";
			else if (((folderNode.totalBytes*1.0/1024)/1024)/1024 < 1024)
				totalSpace.Text = "Space: " + Convert.ToDouble(((folderNode.totalBytes*1.0/1024)/1024)/1024).ToString("0.00") + " GB";
			else
				totalSpace.Text = "Space: >1 TB";

		}
	}
}
