using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace FileWatcher
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox chkDateWritten;
		private System.Windows.Forms.Button cmdStop;
		private System.Windows.Forms.Button cmdStart;
		private System.Windows.Forms.CheckBox chkSize;
		private System.Windows.Forms.CheckBox chkAttributes;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.CheckBox chkSecurity;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox txtFile;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		private FileSystemWatcher fsWatcher;
		
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			fsWatcher = new FileSystemWatcher();
			this.fsWatcher.Changed += new System.IO.FileSystemEventHandler(this.fsWatcher_Changed);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.chkAttributes = new System.Windows.Forms.CheckBox();
			this.chkDateWritten = new System.Windows.Forms.CheckBox();
			this.cmdStart = new System.Windows.Forms.Button();
			this.chkSize = new System.Windows.Forms.CheckBox();
			this.chkSecurity = new System.Windows.Forms.CheckBox();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.cmdStop = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.chkAttributes.Location = new System.Drawing.Point(8, 16);
			this.chkAttributes.Size = new System.Drawing.Size(280, 16);
			this.chkAttributes.TabIndex = 0;
			this.chkAttributes.Text = "The attributes of the file or folder";
			this.chkDateWritten.Location = new System.Drawing.Point(8, 32);
			this.chkDateWritten.Size = new System.Drawing.Size(320, 16);
			this.chkDateWritten.TabIndex = 2;
			this.chkDateWritten.Text = "The date that the file or folder last had anything written to it.";
			this.cmdStart.Location = new System.Drawing.Point(120, 208);
			this.cmdStart.Size = new System.Drawing.Size(104, 32);
			this.cmdStart.TabIndex = 0;
			this.cmdStart.Text = "Start Watching";
			this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
			this.chkSize.Location = new System.Drawing.Point(8, 64);
			this.chkSize.Size = new System.Drawing.Size(280, 16);
			this.chkSize.TabIndex = 4;
			this.chkSize.Text = "The size of the file or folder.";
			this.chkSecurity.Location = new System.Drawing.Point(8, 48);
			this.chkSecurity.Size = new System.Drawing.Size(280, 16);
			this.chkSecurity.TabIndex = 3;
			this.chkSecurity.Text = "The security settings of the file or folder.";
			this.txtFilter.Location = new System.Drawing.Point(64, 64);
			this.txtFilter.Size = new System.Drawing.Size(56, 20);
			this.txtFilter.TabIndex = 6;
			this.txtFilter.Text = "*.*";
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkSize,
																					this.chkSecurity,
																					this.chkDateWritten,
																					this.chkAttributes});
			this.GroupBox1.Location = new System.Drawing.Point(8, 96);
			this.GroupBox1.Size = new System.Drawing.Size(336, 104);
			this.GroupBox1.TabIndex = 4;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Watch for...";
			this.Label2.Location = new System.Drawing.Point(8, 72);
			this.Label2.Size = new System.Drawing.Size(56, 16);
			this.Label2.TabIndex = 5;
			this.Label2.Text = "File filter:";
			this.cmdStop.Location = new System.Drawing.Point(232, 208);
			this.cmdStop.Size = new System.Drawing.Size(104, 32);
			this.cmdStop.TabIndex = 1;
			this.cmdStop.Text = "Stop Watching";
			this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
			this.Label1.Location = new System.Drawing.Point(8, 8);
			this.Label1.Size = new System.Drawing.Size(328, 32);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Enter a folder to watch.  You will be notified when any file which matches the fi" +
				"lter in that folder is modified.";
			this.txtFile.Location = new System.Drawing.Point(8, 40);
			this.txtFile.Size = new System.Drawing.Size(328, 20);
			this.txtFile.TabIndex = 2;
			this.txtFile.Text = "c:\\";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(346, 247);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtFilter,
																		  this.Label2,
																		  this.Label1,
																		  this.cmdStop,
																		  this.txtFile,
																		  this.cmdStart,
																		  this.GroupBox1});
			this.Text = "FileWatcher";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void fsWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
		{
			//Sub Implements Event Handler to tell user when files have changed according to their selections
			MessageBox.Show("'" + e.FullPath + "' has been modified.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void cmdStart_Click(object sender, System.EventArgs e)
		{

			NotifyFilters cf = new NotifyFilters();

			//Check to see which checkboxes are checked
			//Add to Changed Filters Object
			if (chkAttributes.Checked)
			{
				cf = cf | System.IO.NotifyFilters.Attributes;
			}
			if (chkDateWritten.Checked)
			{	
				cf = cf | NotifyFilters.LastWrite;
			}
			if (chkSecurity.Checked)
			{
				cf = cf | NotifyFilters.Security;
			}
			if (chkSize.Checked)
			{
				cf = cf | NotifyFilters.Size;
			}

			//if Add Watch returns true then disable all controls on form
			//Except for cmdStop control
			if (AddWatch(txtFile.Text, txtFilter.Text, cf))
			{
				foreach (Control ctl in this.Controls)
				{
					if (ctl != null && ctl.GetType() != Label1.GetType())
					{
						if (ctl.Equals(cmdStop))
						{
							ctl.Enabled = true;
						}
						else
						{
							ctl.Enabled = false;
						}
					}
				}
			}
		}

		private void cmdStop_Click(object sender, System.EventArgs e)
		{			
			//Enable all controls on form except for cmdStop control
			foreach (Control ctl in this.Controls)
			{
				if (ctl != null)
				{
					if (ctl.Equals(cmdStop))
					{
						ctl.Enabled = false;
					}
					else
					{
						ctl.Enabled = true;
					}
				}
			}
		}

		private bool AddWatch(string sFolder, string sFilter, NotifyFilters Filters)
		{
			//Error Handling
			//Create fsWatcher Object
			//Set Properties on Object Based on the ChangedFilters the User Selected
			if (fsWatcher == null)
			{
				fsWatcher = new FileSystemWatcher();
			}
		
			fsWatcher.Path = sFolder;
			fsWatcher.NotifyFilter = Filters;
			fsWatcher.Filter = sFilter;
			fsWatcher.EnableRaisingEvents = true;
			return true;
		}

	}
}
