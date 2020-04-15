//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.

//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER

//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF

//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Data.SqlClient;

public class Product;

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

        DoTracing("Product instantiated at " + DateTime.Now.ToLongTimestring);

    }

#endregion

#region " Methods for managing products ";

    // Simulates a call to a stored procedure to add a supplier to the

    // Suppliers table.

    public void AddProduct(ProductName string, SupplierID int, UnitPrice Decimal);

        //...

        try {

            //cmd = new SqlCommand("AddProduct", cnn)

            //...

            //cmd.ExecuteNonQuery()

            DoTracing("Product.AddProduct called at " + DateTime.Now.ToLongTimestring);

       } catch( exp Exception;

            throw new Exception(exp.Message, exp.InnerException);

        }

    }

    // Simulates a call to a stored procedure to delete a product.

    public void DeleteProduct(ProductID int);

        //...

        try {

            //cmd = new SqlCommand("DeleteProduct", cnn)

            //...

            //cmd.ExecuteNonQuery()

            DoTracing("Product.DeleteProduct called at " + DateTime.Now.ToLongTimestring);

       } catch( exp Exception;

            throw new Exception(exp.Message, exp.InnerException);

        }

    }

    // Simulates a call to a stored procedure to get a list of all

    // products in Products table.

    public DATA_TYPE_HERE GetProducts() DataTable;

        //...

        try {

            //...

            //da.Fill(dt)

            DoTracing("Product.GetProducts called at " + DateTime.Now.ToLongTimestring);

            //return dt

       } catch( exp Exception;

            throw new Exception(exp.Message, exp.InnerException);

        }

    }

    // Simulates a call to a stored procedure to update a product.

    public void UpdateProduct(ProductID int, ProductName string, SupplierID int, UnitPrice Decimal);

        //...

        try {

            //cmd = new SqlCommand("UpdateProduct", cnn)

            //...

            //cmd.ExecuteNonQuery()

            DoTracing("Product.UpdateProduct called at " + DateTime.Now.ToLongTimestring);

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

        //logTraceListener new EventLogTraceListener("Product--C# How-To: ContrastVBNETwithVB6")

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

