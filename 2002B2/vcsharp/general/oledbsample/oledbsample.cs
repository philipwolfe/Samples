//
//  (c)2000 Microsoft Corporation
//
//  Build this sample with the command line
//
//	csc /r:system.dll /r:system.data.dll /r:system.xml.dll oledbsample.cs
//

using System;
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;

public class MainClass {
    public static void Main ()
    {
		// set Access connection and select strings
		// The path to BugTypes.MDB must be changed if you build the sample from the command line
#if USINGPROJECTSYSTEM
		string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\BugTypes.MDB";
#else
		string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BugTypes.MDB";
#endif
		string strAccessSelect = "SELECT * FROM Categories";

		//Create the dataset and add the Categories table to it
		DataSet myDataSet = new DataSet();
		myDataSet.Tables.Add("Categories");
		
		// create my Access objects
		OleDbConnection myAccessConn = new OleDbConnection(strAccessConn);
		OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect,myAccessConn);
		OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

		myAccessConn.Open();

		try
		{
			myDataAdapter.Fill(myDataSet,"Categories");
		}
		finally
		{
			myAccessConn.Close();
		}

		try
		{
			// A dataSet can contain multiple tables, so let's get them all into an array
			DataTableCollection dta = myDataSet.Tables;
			foreach (DataTable dt in dta)
			{
				Console.WriteLine("Found data table {0}", dt.TableName);
			}
			
			//The next two lines show two different ways you can get the count of tables in a dataset
			Console.WriteLine("{0} tables in data set", myDataSet.Tables.Count);
			Console.WriteLine("{0} tables in data set", dta.Count);
			//The next several lines show how to get information on a specific table by name from the dataset
			Console.WriteLine("{0} rows in Categories table", myDataSet.Tables["Categories"].Rows.Count);
			//The column info is automatically fetched from the database, so we can read it here
			Console.WriteLine("{0} columns in Categories table", myDataSet.Tables["Categories"].Columns.Count);
			DataColumnCollection drc = myDataSet.Tables["Categories"].Columns;
			int i = 0;
			foreach (DataColumn dc in drc)
			{
				//Print the column subscript, then the column's name and its data type
				Console.WriteLine("Column name[{0}] is {1}, of type {2}",i++ , dc.ColumnName, dc.DataType);
			}
			DataRowCollection dra = myDataSet.Tables["Categories"].Rows;
			foreach (DataRow dr in dra)
			{
				//Print the CategoryID as a subscript, then the CategoryName
				Console.WriteLine("CategoryName[{0}] is {1}", dr[0], dr[1]);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("Oooops.  Caught an exception:\n{0}", e.Message);
		}
	}
}
