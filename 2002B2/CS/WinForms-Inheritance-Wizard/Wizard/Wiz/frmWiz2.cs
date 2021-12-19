using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Wiz
{
	/// <summary>
	/// Summary description for frmWiz2.
	/// </summary>
	public class frmWiz2 : FIWiz.frmWizardForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System.ComponentModel.Container components = null;

		public frmWiz2()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//Enable/Disable the navigation buttons according for this page
			btnCancel.Enabled = true;
			btnBack.Enabled = true;
			btnNext.Enabled = true;
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
		System.Windows.Forms.Label lblZip;
		System.Windows.Forms.Label lblState;
		System.Windows.Forms.Label lblCity;
		System.Windows.Forms.Label lblStreet;
		System.Windows.Forms.TextBox txtZip;
		System.Windows.Forms.TextBox txtState;
		System.Windows.Forms.TextBox txtCity;
		System.Windows.Forms.TextBox txtStreet;

		void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblZip = new System.Windows.Forms.Label();
			this.txtState = new System.Windows.Forms.TextBox();
			this.txtZip = new System.Windows.Forms.TextBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.txtStreet = new System.Windows.Forms.TextBox();
			this.lblStreet = new System.Windows.Forms.Label();
			this.lblState = new System.Windows.Forms.Label();
			this.lblCity = new System.Windows.Forms.Label();
			this.SuspendLayout();

			lblZip.Location = new System.Drawing.Point(252, 92);
			lblZip.Text = "Zip";
			lblZip.Name = "lblZip";
			lblZip.Size = new System.Drawing.Size(100, 16);
			lblZip.TabIndex = 11;

			txtState.Location = new System.Drawing.Point(204, 108);
			txtState.Name = "txtState";
			txtState.TabIndex = 6;
			txtState.Size = new System.Drawing.Size(32, 20);

			txtZip.Location = new System.Drawing.Point(252, 108);
			txtZip.Name = "txtZip";
			txtZip.TabIndex = 7;
			txtZip.Size = new System.Drawing.Size(100, 20);

			txtCity.Location = new System.Drawing.Point(92, 108);
			txtCity.Name = "txtCity";
			txtCity.TabIndex = 5;
			txtCity.Size = new System.Drawing.Size(100, 20);

			txtStreet.Location = new System.Drawing.Point(92, 60);
			txtStreet.Name = "txtStreet";
			txtStreet.TabIndex = 4;
			txtStreet.Size = new System.Drawing.Size(256, 20);

			btnBack.Enabled = true;

			lblStreet.Location = new System.Drawing.Point(92, 44);
			lblStreet.Text = "Street";
			lblStreet.Name = "lblStreet";
			lblStreet.Size = new System.Drawing.Size(256, 16);
			lblStreet.TabIndex = 8;

			btnCancel.Enabled = true;

			btnNext.Enabled = true;

			lblState.Location = new System.Drawing.Point(204, 92);
			lblState.Text = "State";
			lblState.Name = "lblState";
			lblState.Size = new System.Drawing.Size(32, 16);
			lblState.TabIndex = 10;

			lblCity.Location = new System.Drawing.Point(92, 92);
			lblCity.Name = "lblCity";
			lblCity.Text = "City";
			lblCity.Size = new System.Drawing.Size(100, 16);
			lblCity.TabIndex = 9;
			this.Text = "Step 2 of 3";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

			this.Controls.Add(lblZip);
			this.Controls.Add(lblState);
			this.Controls.Add(lblCity);
			this.Controls.Add(lblStreet);
			this.Controls.Add(txtZip);
			this.Controls.Add(txtState);
			this.Controls.Add(txtCity);
			this.Controls.Add(txtStreet);


		}
		#endregion

		//Override the Click event of the Back button to return to Page 1
		protected override void btnBack_Click(Object sender, System.EventArgs e)
		{
			//Return to Page 1 of the wizard
			frmWiz1 Wiz1 = new frmWiz1();
			Wiz1.Show();
			this.Hide();
		}

			//Override the Click event of the Next button to display Page 3
		protected override void btnNext_Click(Object sender, System.EventArgs e)
		{
		//Show page 3 of the wizard
			frmWiz3 Wiz3 = new frmWiz3();
			Wiz3.Show();
			this.Hide();
		}

	}
}
