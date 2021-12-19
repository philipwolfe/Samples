using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ADO26InterOp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblState;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.Label lblStreet;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblCity;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.TextBox txtStreet;
		private System.Windows.Forms.ComboBox cmbName;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.TextBox txtZip;
		private System.Windows.Forms.Label lblZip;
		private System.Windows.Forms.TextBox txtCity;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			//load the list of names in the combo box
			loadNames();
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

		private void loadNames()
		{
			ADODB.Recordset rsName = new ADODB.Recordset();
			Address objAddress = new Address();

			//Call the GetName Methods from clsAddress to get a list of names from the database.
			rsName = objAddress.GetName();

			//Populate the Name Combo Box			
			do
			{
				this.cmbName.Items.Add(rsName.Fields["Name"].Value);
				rsName.MoveNext();
			}
			while (rsName.EOF != true);
			

			//Set the default textbox values.
			this.txtStreet.Text = "";
			this.txtCity.Text = "";
			this.txtState.Text = "";
			this.txtZip.Text = "";
			this.txtPhone.Text = "";

			//Release object reference.
			rsName = null;
			objAddress = null;
        
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblState = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.lblStreet = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblCity = new System.Windows.Forms.Label();
			this.lblPhone = new System.Windows.Forms.Label();
			this.txtStreet = new System.Windows.Forms.TextBox();
			this.cmbName = new System.Windows.Forms.ComboBox();
			this.txtState = new System.Windows.Forms.TextBox();
			this.txtZip = new System.Windows.Forms.TextBox();
			this.lblZip = new System.Windows.Forms.Label();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.lblState.Location = new System.Drawing.Point(120, 104);
			this.lblState.Size = new System.Drawing.Size(32, 16);
			this.lblState.TabIndex = 10;
			this.lblState.Text = "State";
			this.txtPhone.Location = new System.Drawing.Point(8, 168);
			this.txtPhone.TabIndex = 7;
			this.txtPhone.Text = "";
			this.lblStreet.Location = new System.Drawing.Point(8, 56);
			this.lblStreet.Size = new System.Drawing.Size(100, 16);
			this.lblStreet.TabIndex = 8;
			this.lblStreet.Text = "Street";
			this.lblName.Location = new System.Drawing.Point(8, 8);
			this.lblName.Size = new System.Drawing.Size(272, 16);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "Name";
			this.lblCity.Location = new System.Drawing.Point(8, 104);
			this.lblCity.Size = new System.Drawing.Size(100, 16);
			this.lblCity.TabIndex = 9;
			this.lblCity.Text = "City";
			this.lblPhone.Location = new System.Drawing.Point(8, 152);
			this.lblPhone.Size = new System.Drawing.Size(100, 16);
			this.lblPhone.TabIndex = 12;
			this.lblPhone.Text = "Phone";
			this.txtStreet.Location = new System.Drawing.Point(8, 72);
			this.txtStreet.Size = new System.Drawing.Size(256, 20);
			this.txtStreet.TabIndex = 3;
			this.txtStreet.Text = "";
			this.cmbName.DropDownWidth = 256;
			this.cmbName.Location = new System.Drawing.Point(8, 24);
			this.cmbName.Size = new System.Drawing.Size(256, 21);
			this.cmbName.TabIndex = 0;
			this.cmbName.SelectedIndexChanged += new System.EventHandler(this.cmbName_SelectedIndexChanged);
			this.txtState.Location = new System.Drawing.Point(120, 120);
			this.txtState.Size = new System.Drawing.Size(32, 20);
			this.txtState.TabIndex = 5;
			this.txtState.Text = "";
			this.txtZip.Location = new System.Drawing.Point(160, 120);
			this.txtZip.TabIndex = 6;
			this.txtZip.Text = "";
			this.lblZip.Location = new System.Drawing.Point(160, 104);
			this.lblZip.Size = new System.Drawing.Size(100, 16);
			this.lblZip.TabIndex = 11;
			this.lblZip.Text = "Zip";
			this.txtCity.Location = new System.Drawing.Point(8, 120);
			this.txtCity.TabIndex = 4;
			this.txtCity.Text = "";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 229);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtPhone,
																		  this.lblZip,
																		  this.txtState,
																		  this.txtZip,
																		  this.txtStreet,
																		  this.txtCity,
																		  this.lblCity,
																		  this.lblName,
																		  this.lblStreet,
																		  this.lblPhone,
																		  this.lblState,
																		  this.cmbName});
			this.Text = "ADO 2.6 InterOp Address Book";

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

		private void cmbName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ADODB.Recordset rsAddress = new ADODB.Recordset();
			Address objAddress = new Address();
			//Call GetAddress method and using selected combo box name as Name parameter of method
			rsAddress = objAddress.GetAddress(cmbName.Text);

			//Set the textbox values to the reAddress values
			this.txtStreet.Text = Convert.ToString(rsAddress.Fields["Street"].Value);
			this.txtCity.Text = Convert.ToString(rsAddress.Fields["City"].Value);
			this.txtState.Text = Convert.ToString(rsAddress.Fields["State"].Value);
			this.txtZip.Text = Convert.ToString(rsAddress.Fields["Zip"].Value);
			this.txtPhone.Text = Convert.ToString(rsAddress.Fields["Phone"].Value);

			//Release object reference.
			rsAddress = null;
			objAddress = null;
		}
	}
}
