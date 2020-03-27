'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
Option Strict On

Imports System.Web.Services
Imports System.Data.SqlClient

<WebService(Namespace:="http://msdn.microsoft.com/vbasic/")> _
Public Class Main
	Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Web Services Designer.
		InitializeComponent()

		'Add your own initialization code after the InitializeComponent() call

	End Sub

	'Required by the Web Services Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Web Services Designer
	'It can be modified using the Web Services Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		components = New System.ComponentModel.Container()
	End Sub

	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		'CODEGEN: This procedure is required by the Web Services Designer
		'Do not modify it using the code editor.
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

#End Region

#Region " Helper Function "
	<WebMethod()> Public Function About() As String
		' Uses the StringWriter to build a string with carriage returns & line feeds to
		' return back to a calling client the Title, Version, and Description by
		' reading Assembly meta-data originally entered in the AssemblyInfo.vb file
		' using the AssemblyInfo class defined in the same file.

		Try
			Dim sw As New System.IO.StringWriter()
			Dim ainfo As New AssemblyInfo()

			With sw
				.WriteLine(ainfo.Title)
				.WriteLine(String.Format("Version {0}", ainfo.Version))
				.WriteLine(ainfo.Copyright)
				.WriteLine("")
				.WriteLine(ainfo.Description)
				.WriteLine("")
				.WriteLine(ainfo.CodeBase)
			End With

			Dim strRetVal As String = sw.ToString
			sw.Close()

			Return strRetVal
		Catch exp As Exception
			Return exp.Message
		End Try
	End Function
#End Region

    ' Initialize constants for connecting to the database
    ' and displaying a connection error to the user.
    Protected Const CONNECTION_ERROR_MSG As String = _
        "To run this sample, you must have SQL " & _
        "or MSDE with the Northwind database installed.  For " & _
        "instructions on installing MSDE, view the ReadMe file."

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=northwind;" & _
        "Integrated Security=SSPI"

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=northwind;" & _
        "Integrated Security=SSPI"

    Protected strConn As String = SQL_CONNECTION_STRING

    <WebMethod(Description:="Get an instance of the custom class " & _
    "CustomerAndOrderHistoryInfo, which has a field containing a typed " & _
    "DataSet of products that the customer has ordered and a field " & _
    "for the company name.")> _
    Public Function GetCustomerOrderHistory(ByVal strCustID As String) _
        As CustomerAndOrderHistoryInfo

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim IsConnecting As Boolean = True
        While IsConnecting
            ' The SqlConnection class allows you to communicate with SQL Server.
            ' The constructor accepts a connection string as an argument.  This
            ' connection string uses Integrated Security, which means that you 
            ' must have a login in SQL Server, or be part of the Administrators
            ' group for this to work.
            Dim scnnNW As New SqlConnection(strConn)

            ' A SqlCommand object is used to execute the SQL commands.
            Dim scmd As New SqlCommand("CustOrderHist", scnnNW)

            ' Create an instance of the custom return type.
            Dim cohi As New CustomerAndOrderHistoryInfo()

            Try
                ' Tell the Command object that the text you passed when creating
                ' the object was for a stored procedure instead of ad hoc SQL.
                scmd.CommandType = CommandType.StoredProcedure

                ' Add a SqlParamter object to pass to the stored procedure.
                scmd.Parameters.Add(New SqlParameter("@CustomerID", _
                    SqlDbType.NChar, 5)).Value = strCustID

                ' A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
                Dim sda As New SqlDataAdapter(scmd)

                ' Create an instance of the typed DataSet.
                Dim dsOrderHistory As New dsCustOrderHist()

                ' Unlike generic DataSets, When filling a typed DataSet you must 
                ' pass the DataTable (or DataTableName, e.g., this is acceptable
                ' also: sda.Fill(dsOrderHistory, dsOrderHistory.Tables(0).TableName).
                ' If you just pass the typed DataSet instance there will be no 
                ' runtime error but you'll have no results in the DataTable, which
                ' could be quite puzzling if you know (using SQL Server Profiler) 
                ' that the SQL executed and returned data. Also, notice that the 
                ' table takes the same name as the stored procedure.
                sda.Fill(dsOrderHistory.CustOrderHist)

                ' Data has been successfully retrieved, so break out of the loop
                ' and close the status form.
                IsConnecting = False

                ' Assign the filled, typed DataSet to the Orders field of the custom
                ' type.
                cohi.Orders = dsOrderHistory

                ' Change the Command text to retrieve the company name.
                scmd.CommandText = _
                    "SELECT CompanyName " & _
                    "FROM Customers " & _
                    "WHERE CustomerID = @CustomerID"

                ' Change the CommandType to ad hoc SQL.
                scmd.CommandType = CommandType.Text

                ' Open a connection and execute the new SQL statement. Use 
                ' ExecuteScalar() for performance gains because you know you 
                ' are only interested in the first column of the first row 
                ' of data returned. (In this case that is all that is returned 
                ' anyway.) Only set the CompanyName property if a name is found.
                ' Without this you generate an exception for a bad Customer ID.
                scnnNW.Open()
                Dim objReturnVal As Object = scmd.ExecuteScalar()
                If Not IsDBNull(objReturnVal) Then
                    cohi.CompanyName = objReturnVal.ToString
                End If

            Catch expSql As SqlException
                Throw New Exception(expSql.Message)

            Catch exp As Exception
                If strConn = SQL_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    strConn = MSDE_CONNECTION_STRING
                Else
                    ' Unable to connect to SQL Server or MSDE
                    Throw New Exception(exp.Message)
                End If
            Finally
                ' Close the connection.
                scnnNW.Close()
            End Try

            Return cohi
        End While
    End Function

    <WebMethod(Description:="Get an untyped DataSet of the ten most expensive " & _
    "products from the Northwind database.")> _
    Public Function GetTenMostExpensiveProducts() As DataSet

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim IsConnecting As Boolean = True
        While IsConnecting
            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim scnnNW As New SqlConnection(strConn)

                ' A SqlCommand object is used to execute the SQL commands. Place 
                ' the stored procedure name in brackets because it contains spaces.
                Dim scmd As New SqlCommand("[Ten Most Expensive Products]", _
                    scnnNW)

                ' Tell the Command object that the text you passed when creating
                ' the object was for a stored procedure instead of ad hoc SQL.
                scmd.CommandType = CommandType.StoredProcedure

                ' A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
                Dim sda As New SqlDataAdapter(scmd)

                ' Create and fill the DataSet.
                Dim dsTenMostExpProds As New DataSet()
                sda.Fill(dsTenMostExpProds)

                ' Data has been successfully retrieved, so break out of the loop
                ' and close the status form.
                IsConnecting = False

                Return dsTenMostExpProds

            Catch expSql As SqlException
                Throw New Exception(expSql.Message)
                Exit Function

            Catch exp As Exception
                If strConn = SQL_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    strConn = MSDE_CONNECTION_STRING
                Else
                    ' Unable to connect to SQL Server or MSDE
                    Throw New Exception(exp.Message)
                End If
            End Try
        End While
    End Function

End Class
