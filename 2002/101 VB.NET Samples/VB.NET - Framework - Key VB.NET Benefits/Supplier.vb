'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient
Public Class Supplier

    Private m_strConnectionString As String

#Region " Constants for Database connections "
    ' Database connection constants.
    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"
#End Region

#Region "Constructors"

    ' Default constructor.
    Public Sub New()
        MyBase.New()
        ' Set the default connection string. 
        m_strConnectionString = SQL_CONNECTION_STRING
    End Sub

#End Region

#Region " Methods for managing suppliers "
    ' Simulates a call to a stored procedure to add a supplier to the
    ' Suppliers table.
    Public Sub AddSupplier(ByVal CompanyName As String, ByVal Phone As String)
        '...
        Try
            'cmd = New SqlCommand("AddSupplier", cnn)
            '...
            'cmd.ExecuteNonQuery()
            DoTracing("Supplier.AddSupplier called at " & DateTime.Now.ToLongTimeString)
        Catch exp As Exception
            Throw New Exception(exp.Message, exp.InnerException)
        End Try
    End Sub

    ' Simulates a call to a stored procedure to delete a supplier.
    Public Sub DeleteSupplier(ByVal SupplierID As Integer)
        '...
        Try
            'cmd = New SqlCommand("DeleteSupplier", cnn)
            '...
            'cmd.ExecuteNonQuery()
            DoTracing("Supplier.DeleteSupplier called at " & DateTime.Now.ToLongTimeString)
        Catch exp As Exception
            Throw New Exception(exp.Message, exp.InnerException)
        End Try
    End Sub

    ' Simulates a call to a stored procedure to get a list of all
    ' suppliers in Suppliers table.
    Public Function GetSuppliers() As DataTable
        '...
        Try
            '...
            'da.Fill(dt)
            DoTracing("Supplier.GetSuppliers called at " & DateTime.Now.ToLongTimeString)
            'Return dt
        Catch exp As Exception
            Throw New Exception(exp.Message, exp.InnerException)
        End Try
    End Function

    ' Simulates a call to a stored procedure to update a supplier.
    Public Sub UpdateSupplier(ByVal SupplierID As Integer, ByVal CompanyName As String, ByVal Phone As String)
        '...
        Try
            'cmd = New SqlCommand("UpdateSupplier", cnn)
            '...
            'cmd.ExecuteNonQuery()
            DoTracing("Supplier.UpdateSupplier called at " & DateTime.Now.ToLongTimeString)
        Catch exp As Exception
            Throw New Exception(exp.Message, exp.InnerException)
        End Try
    End Sub
#End Region

#Region "Utility functions"
    ' Writes to Application Log.
    Private Sub WriteToLog(ByVal strMsg As String)
        Dim oEventLog As New EventLog("Application")
        oEventLog.Source = "VBNET.HowTo.Contrast VB.NET with VB6"
        oEventLog.WriteEntry(strMsg)
    End Sub

    ' Reports on current object status in various ways.
    Private Sub DoTracing(ByVal strMsg As String)
        ' Create a trace listener for the event log.
        'Dim logTraceListener As New EventLogTraceListener("Supplier--VB.NET How-To:ContrastVBNETwithVB6")

        ' Add the trace listener to the collection.
        'Trace.Listeners.Add(logTraceListener)

        ' Create a trace listener that will send send trace output to the console
        ' It could have written to a file or stream instead.
        Dim consoleTraceListener As New TextWriterTraceListener(System.Console.Out)

        ' Add the trace listener to the collection.
        Trace.Listeners.Add(consoleTraceListener)

        ' Write output.
        Trace.WriteLine(strMsg)
    End Sub
#End Region

End Class
