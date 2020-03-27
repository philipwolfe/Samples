'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Data.SqlClient

Module modMain
    private dsProducts as new DataSet
    private dvProducts as DataView
    
    private PROMPT_MESSAGE as String = "Enter a product ID to display information or 'QUIT' to end this application."
    private WELCOME_MESSAGE as String = "Welcome to How-To Work with the Console Product Finder"

    private Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI" 
        
    private Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI" 

    Sub Main()

        dim strInput as String
        dim indexData as Integer

      
        console.WriteLine(WELCOME_MESSAGE)
        
        'Connect to SQL Server, populate the dataset with the products table
        ' and create a sorted view of the products table on the product ID field
        myConnect()
        
        console.WriteLine()
        console.WriteLine(PROMPT_MESSAGE)

        strInput=ucase(console.ReadLine())
        while strInput <> "QUIT"
            
            'check to ensure that a number was entered as product ID
            while not (isnumeric(strInput) or ucase(strInput) = "QUIT") 
                console.WriteLine("A numeric product ID is required.")
                console.WriteLine("Please reenter the Product ID or QUIT to continue.")
                strInput=console.ReadLine()
            end while

            'exit on quit
            if ucase(strInput) = "QUIT" then
                end
            End If

            'display the product information if a valid product id was found
            ' if the product id was not found, display an exception message
            indexData = dvProducts.Find(strInput)
            if indexData = -1 then
                console.WriteLine("No product found.")
            else
                console.Write("Product Name: " )
                console.WriteLine(dvProducts(indexData)("ProductName"))
                console.Write("Quantity Per Unit: " )
                console.WriteLine(dvProducts(indexData)("QuantityPerUnit"))
                console.Write("Unit Price: " )
                console.WriteLine(dvProducts(indexData)("UnitPrice"))
                console.Write("Units In Stock: " )
                console.WriteLine(dvProducts(indexData)("UnitsInStock"))
                console.Write("Units on Order: " )
                console.WriteLine(dvProducts(indexData)("UnitsOnOrder"))
                console.Write("Reorder Level: " )
                console.WriteLine(dvProducts(indexData)("ReorderLevel"))
                console.Write("Discontinued: " )
                if cbool(dvProducts(indexData)("Discontinued")) = False  then
                    console.WriteLine("False")
                else
                    console.WriteLine("True")
                End If
            End If
            console.WriteLine
            console.WriteLine(PROMPT_MESSAGE)
            strInput=ucase(console.ReadLine())
        End While
        End

    End Sub

    sub myConnect()
        dim strConnection As String = SQL_CONNECTION_STRING
        
        ' Display a status message saying that we're attempting to connect to SQL Server.
        ' This only needs to be done the very first time a connection is
        ' attempted.  
        console.WriteLine("Attempting to Connect to SQL Server ")

        ' Attempt to connect first to the local SQL server instance, 
        ' if that is not successful try a local
        ' MSDE installation (with the Northwind DB).  
        Dim IsConnecting As Boolean = True
        While IsConnecting

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in to SQL Server, or be part of the Administrators
                ' group on your local machine for this to work. No password or user id is 
                ' included in this type of string.
                

                Dim northwindConnection As New SqlConnection(strConnection)

                ' The SqlDataAdapter is used to populate a DataSet 
                Dim ProductAdapter As New SqlDataAdapter( _
                    "SELECT * " _
                    & "FROM products", _
                    northwindConnection)

                ' Populate the DataSet with the information from the products
                ' table.  Since a DataSet can hold multiple result sets, it's
                ' a good idea to "name" the result set when you populate the
                ' DataSet.  In this case, the result set is named "Products".
                ProductAdapter.Fill(dsProducts, "Products")

                'create the dataview; use a constructor to specify
                ' the sort criteria 
                dvProducts = new dataView(dsProducts.Tables("products"),"","ProductID ASC",DataViewRowState.OriginalRows)
                
                ' Data has been retrieved successfully  
                ' Signal to break out of the loop by setting isConnecting to false.
                IsConnecting = False
            
            'Handle the situation where a connection attempt has failed
            Catch exc As Exception
                If strConnection = SQL_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    strConnection = MSDE_CONNECTION_STRING
                    console.writeline("Attempting to Connecting to MSDE")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    console.writeline("To run this sample, you must have SQL " & _
                    "or MSDE with the Northwind database installed.  For " & _
                    "instructions on installing MSDE, view  ReadMe.")
                    'quit the program; could not connect to either SQL Server 
                    End         
                End If
            End Try
        End While

        Console.WriteLine("Connected to SQL Server")
    End Sub
End Module
