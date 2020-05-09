using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace MinhNguyen.DiskSpaceExplorer
{
	/// <summary>
	/// Summary description for ProgressForm.
	/// </summary>
	public class ProgressForm : System.Windows.Forms.Form
	{

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cancel;
		private MainForm mainForm;
		private string rootFolder;
		private bool stopNow = false;
		private bool skipWarning = false;

		#region boring windows stuff

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProgressForm(MainForm mainForm, string rootFolder)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.mainForm = mainForm;
			this.rootFolder = rootFolder;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.label1 = new System.Windows.Forms.Label();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(440, 96);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please wait...";
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(376, 88);
			this.cancel.Name = "cancel";
			this.cancel.TabIndex = 1;
			this.cancel.Text = "&Cancel";
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// ProgressForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 120);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cancel,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProgressForm";
			this.Text = "Analyzing drive...";
			this.ResumeLayout(false);

		}
		#endregion

		private void cancel_Click(object sender, System.EventArgs e)
		{
			stopNow = true;
		}

		#endregion

		/// <summary>
		/// Starts analyzing drive
		/// </summary>
		public void Analyze() 
		{
			// initialize variables
			stopNow = false;
			skipWarning = false;

			// create root folder node
			FolderNode rootNode = new FolderNode(rootFolder.Substring(0, rootFolder.Length - 1));
			mainForm.folderTree.Nodes.Clear();
			mainForm.folderTree.Nodes.Add(rootNode);
			
			// start analyzing
			mainForm.SuspendLayout();
			analyzeFolder(rootNode);
			mainForm.ResumeLayout();
			this.Close();
		}


		/// <summary>
		/// Analyzes a specific folder
		/// </summary>
		/// <param name="currentNode">FoderNode corresponding to a directory</param>
		private void analyzeFolder(FolderNode currentNode) 
		{
			if (stopNow)
				return;

			DirectoryInfo[] subDirectories;
			FileInfo[] files;
			FolderNode subNode;

			// display current position
			label1.Text = currentNode.FullPath;
			Application.DoEvents();
			
			// grab directory info
			DirectoryInfo thisDirectory = new DirectoryInfo(currentNode.FullPath + "\\");
			
			// grab files
			try 
			{
				files = thisDirectory.GetFiles();
				subDirectories = thisDirectory.GetDirectories();
			} 
			catch (UnauthorizedAccessException) 
			{
				DialogResult result;

				if (!skipWarning) 
				{
					result = MessageBox.Show(this, "Access denied to directory " + thisDirectory.FullName + Environment.NewLine + Environment.NewLine + "Do you want to disable future warnings?", "DiskSpaceExplorer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (result == DialogResult.Yes)
						skipWarning = true;
				}

				files = new FileInfo[0];
				subDirectories = new DirectoryInfo[0];
			}

			// initialize numbers
			currentNode.thisFiles = files.Length;
			currentNode.thisFolders = subDirectories.Length;
			currentNode.totalFiles = files.Length;
			currentNode.totalFolders = subDirectories.Length;
			currentNode.thisBytes = 0;

			// add file sizes in this directory
			foreach(FileInfo file in files) 
			{
				// sometimes the file actually doesn't exists but shows up, weird huh?
				if (file.Exists)
					currentNode.thisBytes += Convert.ToInt64(file.Length);
			}

			// initialize total file size
			currentNode.totalBytes = currentNode.thisBytes;

			// recurse through each sub directories
			foreach(DirectoryInfo subDir in subDirectories) 
			{
				// create sub node
				subNode = new FolderNode(subDir.Name);

				// add node to tree
				currentNode.Nodes.Add(subNode);

				// analyze that folder
				analyzeFolder(subNode);

				// add up total numbers
				currentNode.totalFiles += subNode.totalFiles;
				currentNode.totalFolders += subNode.totalFolders;
				currentNode.totalBytes += subNode.totalBytes;

				// display form label changes
				Application.DoEvents();
			}
		}

	}
}
