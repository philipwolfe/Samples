using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace BrowseView
{

	
	//DBConnData - used to put all connection parameters together
	//Wouldn't do this in a production environment, but it's a
	//Good test for marshalling user defined classes with web services
	public class DBConnData
	{
		public string serverName;                        //Name of the SQL server
		public string dbName;                            //Name of the database
		public string userName;                          //Name of the db-user (using sql authentication)
		public string pwd;                               //Pwd of the db-user (see name)
	}


	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	public class Service1 : System.Web.Services.WebService
	{
		private const string appName = "BrowseViewWS";

		public Service1()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
		}

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}


		protected DataSet ExecSQL(DBConnData dbConnInfo,string SQLStmt,string tabName)
		{
			SqlConnection dbConn = new SqlConnection();
			//Define db connection        
			dbConn.ConnectionString = "Application Name=" + this.Application.ToString() + ";Server=" + dbConnInfo.serverName + ";Initial Catalog=" + dbConnInfo.dbName + ";User ID=" + dbConnInfo.userName + ";Pwd=" + dbConnInfo.pwd;
				//select all view names from db's system views
				SqlDataAdapter dbCmd = new SqlDataAdapter(SQLStmt, dbConn);
			//load views in a data set
			DataSet dataSet = new DataSet();
			try
			{
				dbCmd.Fill(dataSet, tabName);
			}
			catch(Exception adoEx)
			{
				//In case of an error generate data set with one error row in it.
				DataTable errTable  = new DataTable(tabName);
				DataColumn errColumn;
				DataRow errRow;
				if (tabName == "views") 
				{
					//If we are returning list of views error row must contain two columns
					//with special names; could be done better; just a quick solution
					errColumn = new DataColumn();
					errColumn.DataType = System.Type.GetType("System.String");
					errColumn.ColumnName = "table_schema";
					errTable.Columns.Add(errColumn);
				}
				errColumn = new DataColumn();
				errColumn.DataType = System.Type.GetType("System.String");
				if (tabName == "views")
				{
					errColumn.ColumnName = "table_name";
				}
				else
				{
					errColumn.ColumnName = "ResultColumn";
				}
				errTable.Columns.Add(errColumn);
				dataSet.Tables.Add(errTable);
				errRow = errTable.NewRow();
				if (tabName == "views") 
				{
					errRow["table_schema"] = "";
					errRow["table_name"] = "Error during execution!";
				}
				else
				{
					errRow["ResultColumn"] = "Error during execution!";
				}
				errTable.Rows.Add(errRow);
			}
			return dataSet;
		}   

		//This function returns the names of all views of a database as a data set.
		[WebMethod()] public DataSet GetAllViews(DBConnData dbConnInfo)
		{
			return ExecSQL(dbConnInfo,"select table_schema, table_name from information_schema.views as views","views");
		}

		//This function returns all rows of a view a a data set.
		[WebMethod()] public DataSet QueryView(DBConnData dbConnInfo,string ViewName)
		{
			return ExecSQL(dbConnInfo, "select * from " + ViewName, "Result");
		}

	}
}
