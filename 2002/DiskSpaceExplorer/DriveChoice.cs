using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace MinhNguyen.DiskSpaceExplorer
{
	/// <summary>
	/// Summary description for DriveChoice.
	/// </summary>
	public class DriveChoice : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox driveChoices;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button cancel;
		private MainForm mainForm;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region boring windows stuff

		public DriveChoice(MainForm mainForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.mainForm = mainForm;


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


		#endregion


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.driveChoices = new System.Windows.Forms.ComboBox();
			this.OK = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// driveChoices
			// 
			this.driveChoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.driveChoices.Location = new System.Drawing.Point(16, 16);
			this.driveChoices.Name = "driveChoices";
			this.driveChoices.Size = new System.Drawing.Size(144, 21);
			this.driveChoices.TabIndex = 0;
			// 
			// OK
			// 
			this.OK.Location = new System.Drawing.Point(16, 48);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(60, 23);
			this.OK.TabIndex = 1;
			this.OK.Text = "&OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// cancel
			// 
			this.cancel.Location = new System.Drawing.Point(96, 48);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(60, 23);
			this.cancel.TabIndex = 2;
			this.cancel.Text = "&Cancel";
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// DriveChoice
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(176, 86);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cancel,
																		  this.OK,
																		  this.driveChoices});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DriveChoice";
			this.Text = "Choose Drive";
			this.Load += new System.EventHandler(this.driveChoice_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void cancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void OK_Click(object sender, System.EventArgs e)
		{
			ProgressForm progressForm = new ProgressForm(mainForm, driveChoices.SelectedItem.ToString());
			progressForm.Show();
			this.Hide();
			progressForm.Analyze();
			this.Close();
		}

		private void driveChoice_Load(object sender, System.EventArgs e)
		{
			driveChoices.DataSource = Environment.GetLogicalDrives();
		}
	}
}
