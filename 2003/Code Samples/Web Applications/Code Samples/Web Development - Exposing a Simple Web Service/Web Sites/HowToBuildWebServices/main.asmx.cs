//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Web.Services;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System;

[WebService(Namespace="http://msdn.microsoft.com/csharp/")]
public class Main: System.Web.Services.WebService
{

#region " Web Services Designer Generated Code ";

	public Main() {
		//This call is required by the Web Services Designer.
		InitializeComponent();
		//Add your own initialization code after the InitializeComponent() call
	}

	//Required by the Web Services Designer

	private System.ComponentModel.IContainer components = null;
	//NOTE: The following procedure is required by the Web Services Designer
	//It can be modified using the Web Services Designer.  
	//Do not modify it using the code editor.

	private void InitializeComponent() {

		components = new System.ComponentModel.Container();

	}

	protected override void Dispose(bool disposing) {

		//CODEGEN: This procedure is required by the Web Services Designer

		//Do not modify it using the code editor.

		if (disposing) {

			if (components != null) {

				components.Dispose();

			}

		}

		base.Dispose(disposing);

	}

#endregion

#region " Helper Class ";

	[WebMethod()] public string About()
	{

		// Uses the stringWriter to build a string with carriage returns + line feeds to
		// return back to a calling client the Title, Version, and Description by
		// reading Assembly meta-data originally entered in the AssemblyInfo.cs file
		// using the AssemblyInfo class defined in the same file.

		try 
		{

			StringWriter sw = new StringWriter();

			AssemblyInfo ainfo = new AssemblyInfo();
			sw.WriteLine(ainfo.Title);
			sw.WriteLine(string.Format("Version {0}", ainfo.Version));
			sw.WriteLine(ainfo.Copyright);
			sw.WriteLine("");
			sw.WriteLine(ainfo.Description);
			sw.WriteLine("");
			sw.WriteLine(ainfo.CodeBase);
			string strRetVal = sw.ToString();
			sw.Close();
			return strRetVal;
		}
		catch (Exception exp) 
		{
			return exp.Message;
		}

	}

#endregion

    // Initialize constants for connecting to the database

    // and displaying a connection error to the user.

    protected const string CONNECTION_ERROR_MSG = 
        "To run this sample, you must have SQL " + 
        "or MSDE with the Northwind database installed.  For " + 
        "instructions on installing MSDE, view the ReadMe file.";

    protected const string MSDE_CONNECTION_STRING = 
        @"Server=(local)\NetSDK;" + 
        "DataBase=northwind;" + 
        "Integrated Security=SSPI";

    protected const string SQL_CONNECTION_STRING = 
        "Server=localhost;" + 
        "DataBase=northwind;" + 
        "Integrated Security=SSPI";

    protected string strConn = SQL_CONNECTION_STRING;

    [WebMethod(Description="get {an instance of the custom class " + 
    "CustomerAndOrderHistoryInfo, which has a field containing a typed " + 
    "Dataset of products that the customer has ordered and a field " + 
    "for the company name.")] 

    public CustomerAndOrderHistoryInfo GetCustomerOrderHistory(string strCustID) 
	{

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool IsConnecting = true;
		CustomerAndOrderHistoryInfo cohi = null;

        while (IsConnecting)
		{
            // The SqlConnection class allows you to communicate with SQL Server.
            // The constructor accepts a connection string an argument.  This
            // connection string uses Integrated Security, which means that you 
            // must have a login in SQL Server, or be part of the Administrators
            // group for this to work.

            SqlConnection scnnNW = new SqlConnection(strConn);

            // A SqlCommand object is used to execute the SQL commands.

            SqlCommand scmd = new SqlCommand("CustOrderHist", scnnNW);

            // Create an instance of the custom return type.

            cohi = new CustomerAndOrderHistoryInfo();

			try 
			{
				// Tell the Command object that the text you passed when creating
				// the object was for a stored procedure instead of ad hoc SQL.
				scmd.CommandType = CommandType.StoredProcedure;
				// Add a SqlParamter object to pass to the stored procedure.
				scmd.Parameters.Add(new SqlParameter("@CustomerID", 
					SqlDbType.NChar, 5)).Value = strCustID;
				// A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
				SqlDataAdapter sda = new SqlDataAdapter(scmd);
				// Create an instance of the typed DataSet.
				dsCustOrderHist dsOrderHistory = new dsCustOrderHist();

				// Unlike generic DataSets, When filling a typed Dataset you must 
				// pass the DataTable (or DataTableName, e.g., this is acceptable
				// also: sda.Fill(dsOrderHistory, dsOrderHistory.Tables(0).TableName).
				// if you just pass the typed Dataset instance there will be no 
				// runtime error but you'll have no results in the DataTable, which
				// could be quite puzzling if you know (using SQL Server Profiler) 
				// that the SQL executed and returned data. Also, notice that the 
				// table takes the same name the stored procedure.

				sda.Fill(dsOrderHistory.CustOrderHist);

				// Data has been successfully retrieved, so break out of the loop
				// and close the status form.

				IsConnecting = false;

				// Assign the filled, typed Dataset to the Orders field of the custom
				// type.

				cohi.Orders = dsOrderHistory;

				// Change the Command text to retrieve the company name.

				scmd.CommandText = 
					"SELECT CompanyName " + 
					"FROM Customers " + 
					"WHERE CustomerID = @CustomerID";

				// Change the CommandType to ad hoc SQL.

				scmd.CommandType = CommandType.Text;

				// Open a connection and execute the new SQL statement. Use 
				// ExecuteScalar() for performance gains because you know you 
				// are only interested in the first column of the first row 
				// of data returned. (In this case that is all that is returned 
				// anyway.) Only set the CompanyName property if a name is found.
				// Without this you generate an exception for a bad Customer ID.

				scnnNW.Open();
				object objReturnVal = scmd.ExecuteScalar();

				if (objReturnVal != System.DBNull.Value) 
				{
					cohi.CompanyName = objReturnVal.ToString();
				} 
			}
			catch(SqlException expSql)
			{

				throw new Exception(expSql.Message);

			} 
			catch(Exception exp)
			{
				if (strConn == SQL_CONNECTION_STRING) 
				{
					// Couldn't connect to SQL Server.  Now try MSDE.
					strConn = MSDE_CONNECTION_STRING;
				}
				else 
				{
					// Unable to connect to SQL Server or MSDE
					throw new Exception(exp.Message);
				}
			}
			finally
			{
				// Close the connection.
				scnnNW.Close();
			}
        }

		return cohi;
    }

	[WebMethod(Description="get {an untyped Dataset of the ten most expensive " + 
		 "products from the Northwind database.")]
	public DataSet GetTenMostExpensiveProducts() 
	{

		// Attempt to connect to the local SQL server instance, and a local
		// MSDE installation (with Northwind).  

		bool IsConnecting = true;
		DataSet dsTenMostExpProds = null;

		while (IsConnecting)
		{
			try 
			{
				// The SqlConnection class allows you to communicate with SQL Server.
				// The constructor accepts a connection string an argument.  This
				// connection string uses Integrated Security, which means that you 
				// must have a login in SQL Server, or be part of the Administrators
				// group for this to work.

				SqlConnection scnnNW = new SqlConnection(strConn);

				// A SqlCommand object is used to execute the SQL commands. Place 
				// the stored procedure name in brackets because it contains spaces.

				SqlCommand scmd = new SqlCommand("[Ten Most Expensive Products]", 
					scnnNW);

				// Tell the Command object that the text you passed when creating
				// the object was for a stored procedure instead of ad hoc SQL.

				scmd.CommandType = CommandType.StoredProcedure;

				// A SqlDataAdapter uses the SqlCommand object to fill a DataSet.

				SqlDataAdapter sda = new SqlDataAdapter(scmd);

				// Create and fill the DataSet.

				dsTenMostExpProds = new DataSet();
				sda.Fill(dsTenMostExpProds);

				// Data has been successfully retrieved, so break out of the loop
				// and close the status form.

				IsConnecting = false;
                

			} 
			catch(SqlException expSql)
			{
				throw new Exception(expSql.Message);
				break;
			} 
			catch(Exception exp)
			{

				if (strConn == SQL_CONNECTION_STRING) 
				{
					// Couldn't connect to SQL Server.  Now try MSDE.
					strConn = MSDE_CONNECTION_STRING;
				}
				else 
				{
					// Unable to connect to SQL Server or MSDE
					throw new Exception(exp.Message);
				}
			}
		}

		return dsTenMostExpProds;
	}
}

