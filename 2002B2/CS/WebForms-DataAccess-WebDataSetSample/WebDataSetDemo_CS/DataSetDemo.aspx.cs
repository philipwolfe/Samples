using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


namespace WebDataSetDemo
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnLoadDRList;
		protected System.Web.UI.WebControls.Button btnLoadDSList;
		protected System.Web.UI.WebControls.Button btnLoadDSGrid;
		protected System.Web.UI.WebControls.DataGrid DataGrid;
		protected System.Web.UI.WebControls.ListBox ListBox;
	
		public WebForm1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Windows Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnLoadDRList.Click += new System.EventHandler(this.btnLoadDRList_Click);
			this.btnLoadDSGrid.Click += new System.EventHandler(this.btnLoadDSGrid_Click);
			this.btnLoadDSList.Click += new System.EventHandler(this.btnLoadDSList_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnLoadDSList_Click(object sender, System.EventArgs e)
		{
			System.Data.DataSet  objDataSet = new System.Data.DataSet();
			SqlDataAdapter objDSCommand;
			System.Data.DataRow DataRow;

			this.ListBox.Items.Clear();
            
            //Create New DataSet Command Object
			objDSCommand = new SqlDataAdapter("Select * from customers","server=localhost;uid=sa;pwd=;database=northwind");
            
			//Fill Data Set
			objDSCommand.Fill(objDataSet, "Customers");

			//For every row in Customer Table add it to the list box
        
			foreach(System.Data.DataRow dr in objDataSet.Tables[0].Rows)
			{
				this.ListBox.Items.Add(dr["CompanyName"].ToString());
			}
	        
		}

		private void btnLoadDRList_Click(object sender, System.EventArgs e)
		{
			
			SqlDataReader sqlDataReader;
			SqlConnection sqlConnection = new SqlConnection("Password=;User ID=sa; Initial Catalog=Northwind;Data Source=localhost");
			SqlCommand sqlCommand  = new SqlCommand("Select * from customers", sqlConnection);

			this.ListBox.Items.Clear();
        
			//Open the Connection to the Database
			sqlConnection.Open();
        
			//Execute the DataReader Command
			sqlDataReader = sqlCommand.ExecuteReader();
        
			//DataReader is always set to the first row of the data set
			
			while(sqlDataReader.Read())
			{
				//For each row we add the CompanyName to the DataReader ListBox
				this.ListBox.Items.Add(sqlDataReader["CompanyName"].ToString());
			}
        
			//Check on SQLConnection Object, Close it
			sqlConnection.Close();
        

		}

		private void btnLoadDSGrid_Click(object sender, System.EventArgs e)
		{
		DataSet objDataSet = new DataSet();
        SqlDataAdapter objDSCommand;

        //Create New DataSet Command Object
        objDSCommand = new SqlDataAdapter("Select * from customers","server=localhost;uid=sa;pwd=;database=northwind");

        //Fill Data Set
        objDSCommand.Fill(objDataSet, "Customers");

        //et Data Set equal to DataGrid
        this.DataGrid.DataSource = new DataView(objDataSet.Tables[0]);
        //Bind DataGrid
        DataGrid.DataBind();
        //Set DataGrid to be Visible
        DataGrid.Visible = true;

        
		}
	}
}
