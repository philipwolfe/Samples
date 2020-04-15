//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Data.SqlClient;
using System.Data;

public class MainModule
{
    private static DataSet dsProducts = new DataSet();
    private static DataView dvProducts;
    private static string PROMPT_MESSAGE = "Enter a product ID to display information or 'QUIT' to end this application.";
    private static string WELCOME_MESSAGE = "Welcome to How-To Work with the Console Product Finder";
    private static readonly string SQL_CONNECTION_STRING = "Server=localhost;DataBase=Northwind;Integrated Security=SSPI";
    private static readonly string MSDE_CONNECTION_STRING = @"Server=(local)\NetSDK;DataBase=Northwind;Integrated Security=SSPI";

	[STAThread]
    static void Main()
	{
        string strInput;
        int indexData;

        Console.WriteLine(WELCOME_MESSAGE);

        // Connect to SQL Server, populate the dataset with the products table
        // and create a sorted view of the products table on the product ID field
        myConnect();

		Console.WriteLine();
        Console.WriteLine(PROMPT_MESSAGE);

		strInput = Console.ReadLine().ToUpper();

        while (strInput != "QUIT")
		{
            //check to ensure that a number was entered product ID
            while (!IsNumeric(strInput) || (strInput.ToUpper() == "QUIT"))
			{
                Console.WriteLine("A numeric product ID is required.");
                Console.WriteLine("Please reenter the Product ID or QUIT to continue.");
                strInput = Console.ReadLine();
            }

            //exit on quit
            if (strInput.ToUpper() == "QUIT")
			{
				System.Environment.Exit(0);
				return;
            }

            //display the product information if a valid product id was found
            // if the product id was not found, display an exception message
            indexData = dvProducts.Find(strInput);
			if(indexData == -1) 
			{
				Console.WriteLine("No product found.");
			}
			else
			{
				Console.Write("Product Name: " );
				Console.WriteLine(dvProducts[indexData]["ProductName"]);
				Console.Write("Quantity Per Unit: " );
				Console.WriteLine(dvProducts[indexData]["QuantityPerUnit"]);
				Console.Write("Unit Price: " );
				Console.WriteLine(dvProducts[indexData]["UnitPrice"]);
				Console.Write("Units In Stock: " );
				Console.WriteLine(dvProducts[indexData]["UnitsInStock"]);
				Console.Write("Units on Order: " );
				Console.WriteLine(dvProducts[indexData]["UnitsOnOrder"]);
				Console.Write("Reorder Level: " );
				Console.WriteLine(dvProducts[indexData]["ReorderLevel"]);
				Console.Write("Discontinued: " );

				if (Convert.ToBoolean(dvProducts[indexData]["Discontinued"]) == false) 
				{
					Console.WriteLine("false");
				}
				else
				{
					Console.WriteLine("true");
				}
			}

				Console.WriteLine();
				Console.WriteLine(PROMPT_MESSAGE);            
			
				strInput = Console.ReadLine().ToUpper();
			}

        System.Environment.Exit(0);
		return;
    }

    public static void myConnect()
	{

        string strConnection = SQL_CONNECTION_STRING;
        
		// Display a status message saying that we're attempting to connect to SQL Server.
        // This only needs to be done the very first time a connection is
        // attempted.  

        Console.WriteLine("Attempting to Connect to SQL Server ");

        // Attempt to connect first to the local SQL server instance, 
        // if that is not successful try a local
        // MSDE installation (with the Northwind DB).  
		bool IsConnecting = true;

        while(IsConnecting)
		{
            try 
			{
                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in to SQL Server, or be part of the Administrators
                // group on your local machine for this to work. No password or user id is 
                // included in this type of string.
				SqlConnection northwindConnection = new SqlConnection(strConnection);

                // The SqlDataAdapter is used to populate a Dataset 
                SqlDataAdapter ProductAdapter = new SqlDataAdapter("SELECT * FROM products", northwindConnection);

                // Populate the Dataset with the information from the products
                // table.  Since a Dataset can hold multiple result sets, it's
                // a good idea to "name" the result set when you populate the
                // DataSet.  In this case, the result set is named "Products".
                ProductAdapter.Fill(dsProducts, "Products");

                //create the dataview; use a constructor to specify
                // the sort criteria 
                dvProducts = new DataView(dsProducts.Tables["products"],"","ProductID ASC",DataViewRowState.OriginalRows);

                // Data has been retrieved successfully  
                // Signal to break out of the loop by setting isConnecting to false.
                IsConnecting = false;

			//Handle the situation where a connection attempt has failed
			} 
			catch(Exception exp)
			{
				if (strConnection == SQL_CONNECTION_STRING)
				{
					// Couldn't connect to SQL Server.  Now try MSDE.
					strConnection = MSDE_CONNECTION_STRING;
					Console.WriteLine("Attempting to Connect to MSDE");
				}
				else 
				{
					// Unable to connect to SQL Server or MSDE
					Console.WriteLine("To run this sample, you must have SQL or MSDE with the Northwind database installed.  For instructions on installing MSDE, view Readthis. Error: " + exp.Message);
					
					//quit the program; could not connect to either SQL Server 
					System.Environment.Exit(-1);
					return;
				}
            }
        }
		// success
        Console.WriteLine("Connected to SQL Server");
    }

	// Simple version of VB's IsNumeric()
	public static bool IsNumeric(string val)
	{
		try
		{
			double result = 0;
			return Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out result);
		}
		catch
		{
			return false;
		}
	}
}
