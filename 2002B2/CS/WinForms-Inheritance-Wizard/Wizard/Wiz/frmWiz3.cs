using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Wiz
{
	/// <summary>
	/// Summary description for frmWiz3.
	/// </summary>
	public class frmWiz3 :FIWiz.frmWizardForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmWiz3()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			btnNext.Enabled = false;

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
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtPhone;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.lblPhone = new System.Windows.Forms.Label();
			this.lblEmail = new System.Windows.Forms.Label();
			this.SuspendLayout();

			this.Text = "frmWiz3";

			btnFinish.Enabled = true;

			txtEmail.Location = new System.Drawing.Point(148, 108);
			txtEmail.TabIndex = 5;
			txtEmail.Size = new System.Drawing.Size(184, 20);

			txtPhone.Location = new System.Drawing.Point(148, 60);
			txtPhone.TabIndex = 4;
			txtPhone.Size = new System.Drawing.Size(128, 20);

			btnBack.Enabled = true;

			lblPhone.Location = new System.Drawing.Point(148, 44);
			lblPhone.Text = "Phone";
			lblPhone.Size = new System.Drawing.Size(120, 16);
			lblPhone.TabIndex = 6;

			btnNext.Enabled = true;

			lblEmail.Location = new System.Drawing.Point(148, 92);
			lblEmail.Text = "Email";
			lblEmail.Size = new System.Drawing.Size(184, 16);
			lblEmail.TabIndex = 7;

			btnCancel.Enabled = true;
			this.Text = "Step 3 of 3";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

			this.Controls.Add(lblEmail);
			this.Controls.Add(lblPhone);
			this.Controls.Add(txtEmail);
			this.Controls.Add(txtPhone);

			this.ResumeLayout(false);

		}
		#endregion

		// Override the Click event of the Back button to return to Page 2
		protected override void btnBack_Click(Object sender, System.EventArgs e)
		{
			frmWiz2 Wiz2 = new frmWiz2();
			Wiz2.Show();
			this.Hide();
		}
	}
}
