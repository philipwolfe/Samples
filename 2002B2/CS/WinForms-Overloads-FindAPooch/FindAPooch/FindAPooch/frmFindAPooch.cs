using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace FindAPooch
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private const long ALL_BREEDS = 0;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.DataGrid DataGrid1;
		private System.Windows.Forms.Button cmdAdopt;
		private System.Windows.Forms.TextBox txtCity;
		private System.Windows.Forms.ComboBox cboBreed;
		private System.Windows.Forms.GroupBox GroupBox1;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Button cmdSearch;
		private System.Windows.Forms.Label Label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		
		Pooch.clsPoochData objPooch = new Pooch.clsPoochData();
		private DataSet ds = new DataSet();
		private DataTable dt = new DataTable();

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			//We're setting the datasource for the Breed combo box to a datatable
			//returned by the GetBreedList method on the objPooch(clsPoochLogic)
			//object and then setting the member of the datasource(table) we want 
			//to display.
			ds = objPooch.BrowseByBreed();
			dt = ds.Tables["breeds"];
			this.cboBreed.DataSource = dt;	        
			this.cboBreed.DisplayMember = "breeddesc";

			//Set the default control values.
			this.txtCity.Text = "";
			this.txtState.Text = "";
			
			//this.cboBreed.SelectedIndex = 0;
	        
			//Release object reference.
			//objPooch = null;
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
			this.Label3 = new System.Windows.Forms.Label();
			this.DataGrid1 = new System.Windows.Forms.DataGrid();
			this.cmdAdopt = new System.Windows.Forms.Button();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.cmdSearch = new System.Windows.Forms.Button();
			this.cboBreed = new System.Windows.Forms.ComboBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.txtState = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).BeginInit();
			this.Label3.Location = new System.Drawing.Point(48, 64);
			this.Label3.Size = new System.Drawing.Size(40, 16);
			this.Label3.TabIndex = 7;
			this.Label3.Text = "Breed:";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.DataGrid1.CaptionText = "Available Pooches:";
			this.DataGrid1.DataMember = "";
			this.DataGrid1.Location = new System.Drawing.Point(8, 112);
			this.DataGrid1.ReadOnly = true;
			this.DataGrid1.Size = new System.Drawing.Size(376, 216);
			this.DataGrid1.TabIndex = 10;
			this.cmdAdopt.Location = new System.Drawing.Point(157, 344);
			this.cmdAdopt.TabIndex = 0;
			this.cmdAdopt.Text = "Adopt";
			this.cmdAdopt.Click += new System.EventHandler(this.cmdAdopt_Click);
			this.txtCity.Location = new System.Drawing.Point(96, 32);
			this.txtCity.Size = new System.Drawing.Size(136, 20);
			this.txtCity.TabIndex = 2;
			this.txtCity.Text = "";
			this.cmdSearch.Location = new System.Drawing.Point(264, 64);
			this.cmdSearch.TabIndex = 1;
			this.cmdSearch.Text = "Search";
			this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
			this.cboBreed.DropDownWidth = 136;
			this.cboBreed.Location = new System.Drawing.Point(96, 64);
			this.cboBreed.Size = new System.Drawing.Size(136, 21);
			this.cboBreed.TabIndex = 8;
			this.GroupBox1.Location = new System.Drawing.Point(32, 8);
			this.GroupBox1.Size = new System.Drawing.Size(328, 88);
			this.GroupBox1.TabIndex = 9;
			this.GroupBox1.TabStop = false;
			this.txtState.Location = new System.Drawing.Point(288, 32);
			this.txtState.Size = new System.Drawing.Size(48, 20);
			this.txtState.TabIndex = 3;
			this.txtState.Text = "";
			this.Label1.Location = new System.Drawing.Point(48, 32);
			this.Label1.Size = new System.Drawing.Size(40, 16);
			this.Label1.TabIndex = 5;
			this.Label1.Text = "City:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Label2.Location = new System.Drawing.Point(240, 32);
			this.Label2.Size = new System.Drawing.Size(40, 16);
			this.Label2.TabIndex = 6;
			this.Label2.Text = "State:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(390, 379);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label3,
																		  this.Label2,
																		  this.Label1,
																		  this.cmdAdopt,
																		  this.txtState,
																		  this.cmdSearch,
																		  this.cboBreed,
																		  this.DataGrid1,
																		  this.txtCity,
																		  this.GroupBox1});
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.DataGrid1)).EndInit();

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

		private void cmdSearch_Click(object sender, System.EventArgs e)
		{
			DataSet ds;
			//DataTable dt;
			//DataRow row;
			Pooch.clsPoochData objPooch;
			//string strBreed;

			//Call a method in the PoochData Class to return data
			objPooch = new Pooch.clsPoochData();

			//Here we're determining which parameters are valid,
			//sending them to the corresponding overloaded
			//Browse method on the objPooch(clsPoochData) object,
			//and then assigning the returned dataset to GetPooches.

			if (txtCity.Text == "" && txtState.Text != "" && Convert.ToInt16(this.cboBreed.SelectedIndex) <= 0)
			{
				//Get pooches by state.
				ds = objPooch.BrowseByState(txtState.Text);
			}
			else if (txtCity.Text != "" && txtState.Text != "" && Convert.ToInt16(this.cboBreed.SelectedIndex) <= 0)
			{
				//Get pooches by state && city.
				ds = objPooch.BrowseByState(txtState.Text, txtCity.Text);
			}
			else if (txtCity.Text == "" && txtState.Text != "" && Convert.ToInt16(this.cboBreed.SelectedIndex) > 0)
			{
				//Get pooches by breed && state
				ds = objPooch.BrowseByState(txtState.Text, Convert.ToInt16(this.cboBreed.SelectedIndex));
			}
			else if (txtCity.Text != "" && txtState.Text != "" && Convert.ToInt16(this.cboBreed.SelectedIndex) > 0)
			{
				//Get pooches by breed, state, && city
				ds = objPooch.BrowseByState(txtState.Text, txtCity.Text, Convert.ToInt16(this.cboBreed.SelectedIndex));
			}
			else if (txtCity.Text != "" && txtState.Text == "" && Convert.ToInt16(this.cboBreed.SelectedIndex) <= 0)
			{ 
				//Get pooches by city.
				ds = objPooch.BrowseByCity(txtCity.Text);
			}
			else if (txtCity.Text != "" && txtState.Text == "" && Convert.ToInt16(this.cboBreed.SelectedIndex) > 0)
			{
				//Get pooches by breed && city
				ds = objPooch.BrowseByCity(this.txtCity.Text, Convert.ToInt16(this.cboBreed.SelectedIndex));
			}
			else if (txtCity.Text == "" && txtState.Text == "" && Convert.ToInt16(this.cboBreed.SelectedIndex) > 0)
			{
				//Get pooches by breed.
				ds = objPooch.BrowseByBreed(Convert.ToInt16(this.cboBreed.SelectedIndex));
			}
			else
			{
				//Get all of the pooches.
				ds = objPooch.BrowseByBreed(ALL_BREEDS);
			}

	//objPooch = Nothing

	//Set the datasource of the data grid control
	//to the dataset we just retrieved. Set the 
	//datamember(table) to the "dogs" table.
	this.DataGrid1.DataSource = ds.Tables[0];

}

		private void cmdAdopt_Click(object sender, System.EventArgs e)
		{
			String strMsg;

			//Display a messagebox containing the name of the
			//pooch that was selected in the datagrid.
			strMsg = "Your new best friend is " + this.DataGrid1[this.DataGrid1.CurrentCell.RowNumber, 0].ToString() + "!";
			//intAnsr = MsgBox(strMsg, Microsoft.VisualBasic.MsgBoxStyle.Information, "Adopt")
			System.Windows.Forms.MessageBox.Show (strMsg);
		}
	}
}
