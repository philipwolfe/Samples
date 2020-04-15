//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.

//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER

//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF

//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Data.SqlClient;

public class Supplier;

    private m_strConnectionstring string;

#region " Constants for Database connections ";

    // Database connection constants.

    protected const SQL_CONNECTION_STRING string = _;

        "Server=localhost;" + _;

        "DataBase=Northwind;" + _;

        "Integrated Security=SSPI";

    protected const MSDE_CONNECTION_STRING string = _;

        "Server=(local)\NetSDK;" + _;

        "DataBase=Northwind;" + _;

        "Integrated Security=SSPI";

#endregion

#region "Constructors";

    // Default constructor.

    public () {

        

        // Set the default connection string. 

        m_strConnectionstring = SQL_CONNECTION_STRING;

    }

#endregion

#region " Methods for managing suppliers ";

    // Simulates a call to a stored procedure to add a supplier to the

    // Suppliers table.

    public void AddSupplier(CompanyName string, Phone string);

        //...

        try {

            //cmd = new SqlCommand("AddSupplier", cnn)

            //...

            //cmd.ExecuteNonQuery()

            DoTracing("Supplier.AddSupplier called at " + DateTime.Now.ToLongTimestring);

       } catch( exp Exception;

            throw new Exception(exp.Message, exp.InnerException);

        }

    }

    // Simulates a call to a stored procedure to delete a supplier.

    public void DeleteSupplier(SupplierID int);

        //...

        try {

            //cmd = new SqlCommand("DeleteSupplier", cnn)

            //...

            //cmd.ExecuteNonQuery()

            DoTracing("Supplier.DeleteSupplier called at " + DateTime.Now.ToLongTimestring);

       } catch( exp Exception;

            throw new Exception(exp.Message, exp.InnerException);

        }

    }

    // Simulates a call to a stored procedure to get a list of all

    // suppliers in Suppliers table.

    public DATA_TYPE_HERE GetSuppliers() DataTable;

        //...

        try {

            //...

            //da.Fill(dt)

            DoTracing("Supplier.GetSuppliers called at " + DateTime.Now.ToLongTimestring);

            //return dt

       } catch( exp Exception;

            throw new Exception(exp.Message, exp.InnerException);

        }

    }

    // Simulates a call to a stored procedure to update a supplier.

    public void UpdateSupplier(SupplierID int, CompanyName string, Phone string);

        //...

        try {

            //cmd = new SqlCommand("UpdateSupplier", cnn)

            //...

            //cmd.ExecuteNonQuery()

            DoTracing("Supplier.UpdateSupplier called at " + DateTime.Now.ToLongTimestring);

       } catch( exp Exception;

            throw new Exception(exp.Message, exp.InnerException);

        }

    }

#endregion

#region "Utility functions";

    // Writes to Application Log.

    private void WriteToLog(strMsg string);

        oEventLog new EventLog("Application");

        oEventLog.Source = "VBNET.HowTo.Contrast C# with VB6";

        oEventLog.WriteEntry(strMsg);

    }

    // Reports on current object status in various ways.

    private void DoTracing(strMsg string);

        // Create a trace listener for the event log.

        //logTraceListener new EventLogTraceListener("Supplier--C# How-To:ContrastVBNETwithVB6")

        // Add the trace listener to the collection.

        //Trace.Listeners.Add(logTraceListener)

        // Create a trace listener that will send send trace output to the console

        // It could have written to a file or stream instead.

        consoleTraceListener new TextWriterTraceListener(System.Console.Out);

        // Add the trace listener to the collection.

        Trace.Listeners.Add(consoleTraceListener);

        // Write output.

        Trace.WriteLine(strMsg);

    }

#endregion

}

