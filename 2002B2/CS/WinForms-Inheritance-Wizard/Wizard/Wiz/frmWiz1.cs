using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Wiz
{
	/// <summary>
	/// Summary description for frmWiz1.
	/// </summary>
	public class frmWiz1 : FIWiz.frmWizardForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblLastName;
		private System.Windows.Forms.Label lblMiddleName;
		private System.Windows.Forms.Label lblFirstName;
		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.TextBox txtMiddleName;
		private System.Windows.Forms.TextBox txtFirstName;

		public frmWiz1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			btnCancel.Visible = true;
			btnBack.Enabled = false;
			btnNext.Visible = true;
			btnFinish.Enabled = false;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			if(components != null)
			{
				components.Dispose();
			}
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		/// 

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Text = "frmWiz1";
			this.txtMiddleName = new System.Windows.Forms.TextBox();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.lblMiddleName = new System.Windows.Forms.Label();
			this.lblLastName = new System.Windows.Forms.Label();
			this.lblFirstName = new System.Windows.Forms.Label();
			this.SuspendLayout();

			txtMiddleName.Location = new System.Drawing.Point(132, 96);
			txtMiddleName.TabIndex = 5;
			txtMiddleName.Name = "txtMiddleName";
			txtMiddleName.Size = new System.Drawing.Size(176, 20);

			txtFirstName.Location = new System.Drawing.Point(132, 48);
			txtFirstName.TabIndex = 4;
			txtFirstName.Name = "txtFirstName";
			txtFirstName.Size = new System.Drawing.Size(176, 20);

			txtLastName.Location = new System.Drawing.Point(132, 144);
			txtLastName.TabIndex = 6;
			txtLastName.Name = "txtLastName";
			txtLastName.Size = new System.Drawing.Size(176, 20);

			btnNext.Enabled = true;

			lblMiddleName.Location = new System.Drawing.Point(132, 80);
			lblMiddleName.Text = "Middle Name";
			lblMiddleName.Size = new System.Drawing.Size(176, 16);
			lblMiddleName.Name = "lblMiddleName";
			lblMiddleName.TabIndex = 8;

			lblLastName.Location = new System.Drawing.Point(132, 128);
			lblLastName.Text = "Last Name";
			lblLastName.Size = new System.Drawing.Size(176, 16);
			lblLastName.Name = "lblLastName";
			lblLastName.TabIndex = 9;

			lblFirstName.Location = new System.Drawing.Point(132, 32);
			lblFirstName.Text = "First Name";
			lblFirstName.Size = new System.Drawing.Size(176, 16);
			lblFirstName.Name = "lblFirstName";
			lblFirstName.TabIndex = 7;

			btnCancel.Enabled = true;
			this.Text = "Step 1 of 3";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

			this.Controls.Add(lblLastName);
			this.Controls.Add(lblMiddleName);
			this.Controls.Add(lblFirstName);
			this.Controls.Add(txtLastName);
			this.Controls.Add(txtMiddleName);
			this.Controls.Add(txtFirstName);

			this.ResumeLayout(false);

		}
		#endregion
	
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmWiz1());
		}

		//Overide the Click event of the Next button
		protected override void btnNext_Click(Object sender, System.EventArgs e)
		{
			//show the next page of the wizard
			frmWiz2 Wiz2 = new frmWiz2();
			Wiz2.Show();
			this.Hide();
		}

	}
}
