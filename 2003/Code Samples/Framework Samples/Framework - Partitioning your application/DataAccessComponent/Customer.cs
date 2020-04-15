//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.IO;
using System.Data;

public class Business
{
    protected string m_FileName;

    public string FileName
	{
        // Read/Write FileName property for use by
        // data access procedures.
        get {
            // Read FileName
            return m_FileName;
        }
        set {
            // Write FileName
            m_FileName = value;
        }
    }

    public DataTable GetCustomers() 
	{
        // Extract records from file and return
        // in a DataTable.  if file format changed
        // this procedure would change internally,
        // but all of the apps that use it would go 
        // untouched.
        // Check that a filename was passed
        if (m_FileName == "") 
		{
            throw (new ArgumentNullException("FileName", "No value for FileName"));
        }
        StreamReader objStreamReader = new StreamReader(m_FileName);
        string strLine;
        string[] strColumns;
        DataTable dtCustomers = new DataTable();
        DataRow drCustomer;
        // Define the schema of the table,
        // used to define new rows.
        dtCustomers.Columns.Add("CustomerID");
        dtCustomers.Columns.Add("CompanyName");
        dtCustomers.Columns.Add("ContactName");
        dtCustomers.Columns.Add("Phone");
        // Extract line from file
        strLine = objStreamReader.ReadLine();
        // Enter loop is data is found

		do{
			// Create a DataRow to hold line
			drCustomer = dtCustomers.NewRow();
			// Create an array of columns separated by commas
			strColumns = strLine.Split(',');
			// Quickly fill row with column values
			drCustomer.ItemArray = strColumns;
			// Append row to DataTable
			dtCustomers.Rows.Add(drCustomer);
			//Extract another line
			strLine = objStreamReader.ReadLine();
		   }while ( strLine != null);
        // Display results
        return dtCustomers;
    }
    public Business() {
    }

    public Business(string FileName)
	{
        // Allow component to be instantiated
        // and passed a file at the same time
        m_FileName = FileName;
    }
}

