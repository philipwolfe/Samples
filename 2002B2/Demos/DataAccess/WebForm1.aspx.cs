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

namespace scalar
{

	/* 
	 The methods in this form demonstrate basic use of the ADO.Net 
	 Scalar, DataReader, and DataSet features. In the Page_Load method, 
	 uncomment the method of the example you'd like to see. 
	 
	The dataconnection for the below methods is set up using the visual 
	tools. To see the properties, go to the design view of this page and 
	click on the dataconnection object in the bottom window of the designer
	NOTE: you should have the "pubs" database from the default install 
	of SQL2K installed.
	
	This code is written to illustrate the concepts as simply as possible and 
	should not be used in a production system of any kind.
	
	The DataForm demo is not included in this demo section, as that is set up 
	by a wizard at design time.  
	 */

	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
	
		public WebForm1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			/* 
			uncomment this method to see example of a Scalar call
			a scalar call reads the first value from the first column
			of the returned recordset and ignores all else 
			NOTE: Make sure you have a label named Label1 on the page when you
			run this method
			*/
			useScalar();
			
			/* 
			uncomment this method to see example of a DataReader call
			a DataReader is a forward only speed optimized stream of data 
			*/
			// useSqlDataReader();

			/* 
			uncomment this method to see example of a DataSet call
			a DataSet is a feature-rich disconnected cache of XML data
			that may represent highly complex relational or hierarchical data 
			*/
			// useDataSet();

			/* 
			uncomment this method to see example of binding a DataGrid web control
			to a Dataset.
			NOTE: Make sure you have a DataGrid web control named DataGrid1 on the page
			before you run this method
			*/
			// bindDataGrid();

			/* 
			uncomment this method to see example of working with a Dataview
			
			NOTE: Make sure you have two DataGrid web controls named DataGrid1 
			and DataGrid2 on the page before you run this method
			*/
			// useDataView();
		}

		private void useScalar()
		{
			//scalar: gets first column value for first record, ignores all else
			//output: sets a label with the returned value
			SqlCommand cmd = new SqlCommand("SELECT * FROM authors", sqlConnection1);
			cmd.Connection.Open();
			Label1.Text = cmd.ExecuteScalar().ToString();
			sqlConnection1.Close();
		}

		private void useSqlDataReader()
		{
			// datareader: forward only recordset when need for speed
			// output: writes the values to the browser using ASP-style Response.Write

			SqlCommand cmd = new SqlCommand("SELECT au_lname FROM authors", sqlConnection1);
			cmd.Connection.Open();

			SqlDataReader dr = cmd.ExecuteReader();
			
			while (dr.Read()) 
			{
				Response.Write(dr.GetString(0) + "<br>");
			}

			dr.Close();
			sqlConnection1.Close();
		}

		private void useDataSet()
		{
			// dataset: high powered xml-based data access and martialing
			// output: writes the retrieved XML to an XML document, c:\authors.xml
			
			SqlCommand cmd = new SqlCommand("SELECT au_lname FROM authors", sqlConnection1);
			cmd.Connection.Open();

			SqlDataAdapter sda = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet("myDS");
			
			ds.Tables.Add("table1");
			sda.Fill(ds.Tables["table1"]);

			// double slash necessary to escape the "\" character
			ds.WriteXml("c:\\authors.xml");

			sqlConnection1.Close();
		}

		private void bindDataGrid()
		{
			/* 
			 This method shows how to bind a WebForm control
			 to a DataSet
			 */

			SqlCommand cmd1 = new SqlCommand("SELECT * FROM authors", sqlConnection1);
			cmd1.Connection.Open();
			SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

			DataSet ds = new DataSet("myDS");
			ds.Tables.Add("table1");

			sda1.Fill(ds.Tables["table1"]);

			DataGrid1.DataSource = ds;
			DataGrid1.DataBind();

			sqlConnection1.Close();

		}

		
		private void useDataView()
		{
			/*
			 dataview: objects you can use to generate alternate view
			of data from the same source
			*/
			
			
			SqlCommand cmd = new SqlCommand("SELECT au_lname FROM authors", sqlConnection1);
			cmd.Connection.Open();

			SqlDataAdapter sda = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet("myDS");
			
			ds.Tables.Add("table1");
			sda.Fill(ds.Tables["table1"]);

			DataView dv1 = new DataView(ds.Tables["table1"]);
			dv1.RowFilter= "au_lname = 'Ringer'";

			DataGrid1.DataSource = ds;
			DataGrid1.DataBind();

			DataGrid2.DataSource = dv1;
			DataGrid2.DataBind();

			sqlConnection1.Close();

		}



		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=TIMCONXP;initial catalog=pubs;integrated security=SSPI;persist securi" +
				"ty info=True;workstation id=TIMCONXP;packet size=4096";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
