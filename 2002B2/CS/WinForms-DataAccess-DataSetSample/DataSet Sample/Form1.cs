using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace DataSet_Sample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstBox;
		private System.Windows.Forms.Button cmdLoadDRList;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblCustomerListBox;
		private System.Windows.Forms.Button cmdLoadDSGrid;
		private System.Windows.Forms.Button cmdLoadDSList;
		private System.Windows.Forms.DataGrid grdDataGrid;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		//Sql connection object
		private SqlConnection objConnection = new SqlConnection("server=localhost;uid=sa;pwd=;database=northwind");

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//Open the connection to the database
			objConnection.Open();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			//Make sure the connection has been closed and released
			if(objConnection != null)
			{
				if (objConnection.State == ConnectionState.Open)
				{
					objConnection.Close();
				}
				objConnection = null;
			}

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
			this.lstBox = new System.Windows.Forms.ListBox();
			this.cmdLoadDRList = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblCustomerListBox = new System.Windows.Forms.Label();
			this.cmdLoadDSGrid = new System.Windows.Forms.Button();
			this.cmdLoadDSList = new System.Windows.Forms.Button();
			this.grdDataGrid = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.grdDataGrid)).BeginInit();
			this.lstBox.Location = new System.Drawing.Point(16, 144);
			this.lstBox.Size = new System.Drawing.Size(256, 394);
			this.lstBox.TabIndex = 7;
			this.lstBox.SelectedIndexChanged += new System.EventHandler(this.lstBox_SelectedIndexChanged);
			this.cmdLoadDRList.Location = new System.Drawing.Point(16, 88);
			this.cmdLoadDRList.Size = new System.Drawing.Size(224, 23);
			this.cmdLoadDRList.TabIndex = 0;
			this.cmdLoadDRList.Text = "Load DataReader into List Box";
			this.cmdLoadDRList.Click += new System.EventHandler(this.cmdLoadDRList_Click);
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
			this.lblTitle.Location = new System.Drawing.Point(16, 8);
			this.lblTitle.Size = new System.Drawing.Size(904, 23);
			this.lblTitle.TabIndex = 12;
			this.lblTitle.Text = "Win Form Data Access";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
			this.lblCustomerListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.lblCustomerListBox.Location = new System.Drawing.Point(16, 128);
			this.lblCustomerListBox.Size = new System.Drawing.Size(208, 16);
			this.lblCustomerListBox.TabIndex = 8;
			this.lblCustomerListBox.Text = "Company Name from Customer Table";
			this.lblCustomerListBox.Click += new System.EventHandler(this.lblCustomerListBox_Click);
			this.cmdLoadDSGrid.Location = new System.Drawing.Point(296, 48);
			this.cmdLoadDSGrid.Size = new System.Drawing.Size(224, 23);
			this.cmdLoadDSGrid.TabIndex = 9;
			this.cmdLoadDSGrid.Text = "Load DataSet into Data Grid";
			this.cmdLoadDSGrid.Click += new System.EventHandler(this.cmdLoadDSGrid_Click);
			this.cmdLoadDSList.Location = new System.Drawing.Point(16, 48);
			this.cmdLoadDSList.Size = new System.Drawing.Size(224, 23);
			this.cmdLoadDSList.TabIndex = 11;
			this.cmdLoadDSList.Text = "Load DataSet into List Box";
			this.cmdLoadDSList.Click += new System.EventHandler(this.cmdLoadDSList_Click);
			this.grdDataGrid.AccessibleDescription = "Customer Table";
			this.grdDataGrid.AccessibleName = "Customer Table";
			this.grdDataGrid.CaptionText = "Customer Table";
			this.grdDataGrid.DataMember = "";
			this.grdDataGrid.Location = new System.Drawing.Point(296, 144);
			this.grdDataGrid.PreferredColumnWidth = 100;
			this.grdDataGrid.Size = new System.Drawing.Size(624, 392);
			this.grdDataGrid.TabIndex = 6;
			this.grdDataGrid.Navigate += new System.Windows.Forms.NavigateEventHandler(this.grdDataGrid_Navigate);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(936, 557);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdLoadDSList,
																		  this.cmdLoadDRList,
																		  this.lblCustomerListBox,
																		  this.grdDataGrid,
																		  this.lstBox,
																		  this.cmdLoadDSGrid,
																		  this.lblTitle});
			this.Text = "DataSets";
			((System.ComponentModel.ISupportInitialize)(this.grdDataGrid)).EndInit();

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

		private void lstBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		private void cmdLoadDSGrid_Click(object sender, System.EventArgs e)
		{
			DataSet objDataSet = new DataSet();
			SqlDataAdapter objDataAdapter = new SqlDataAdapter();
			SqlCommand objCommand = new SqlCommand("Select * from customers");

			//Set the command to the current connection
			objCommand.Connection = objConnection;
			//Specify the sqlcommand object that contains SQL query
			objDataAdapter.SelectCommand = objCommand;

			//Fill Data Set
			objDataAdapter.Fill(objDataSet, "Customers");

			//Set Data Set equal to DataGrid
			this.grdDataGrid.DataSource = objDataSet.Tables[0];
			this.grdDataGrid.Visible = true;
			this.grdDataGrid.AllowSorting = true;
		}

		private void cmdLoadDSList_Click(object sender, System.EventArgs e)
		{
			DataSet objDataSet;
			SqlDataAdapter objDataAdapter;
			//DataRow objDRCustomer;
			SqlCommand objCommand;

			this.lstBox.Items.Clear();

			objDataSet = new DataSet();
			//Create new command object
			objCommand = new SqlCommand("Select * from customers");
			//Create new SqlDataAdapter
			objDataAdapter = new SqlDataAdapter(objCommand);

			//Set the command object connection to the current connection
			objCommand.Connection = objConnection;

			//Fill Data Set
			objDataAdapter.Fill(objDataSet, "Customers");

			//For every row in Customer Table add it to the list box
			foreach (DataRow objDR in objDataSet.Tables[0].Rows)
			{
				this.lstBox.Items.Add(objDR["CompanyName"].ToString());				
			}
		}

		private void cmdLoadDRList_Click(object sender, System.EventArgs e)
		{
			SqlDataReader objSqlDataReader;
			SqlCommand objCommand = new SqlCommand("Select * from customers");
			objCommand.Connection = objConnection;

			this.lstBox.Items.Clear();

			//Execute the DataReader Command
			objSqlDataReader = objCommand.ExecuteReader();

			//DataReader is always set to the first row of the data set
			while (objSqlDataReader.Read())
			{
				//For each row we add the CompanyName to the DataReader ListBox
				this.lstBox.Items.Add(objSqlDataReader["CompanyName"].ToString());
			}

			//Close the SqlDataReader
			if (!objSqlDataReader.IsClosed) 
			{
				objSqlDataReader.Close();
			}
		}

		private void lblCustomerListBox_Click(object sender, System.EventArgs e)
		{

		}

		private void lblTitle_Click(object sender, System.EventArgs e)
		{

		}

		private void grdDataGrid_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{

		}
	}
}
