'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO

Public Class Business
    Protected m_FileName As String

    Public Property FileName() As String
        ' Read/Write FileName property for use by
        ' data access procedures.
        Get
            ' Read FileName
            Return m_FileName
        End Get
        Set(ByVal Value As String)
            ' Write FileName
            m_FileName = Value
        End Set
    End Property

    Public Function GetCustomers() As DataTable
        ' Extract records from file and return
        ' in a DataTable.  If file format changed
        ' this procedure would change internally,
        ' but all of the apps that use it would go 
        ' untouched.

        ' Check that a filename was passed
        If m_FileName = "" Then
            Throw (New ArgumentNullException("FileName", "No value for FileName"))
        End If

        Dim objStreamReader As StreamReader = New StreamReader(m_FileName)
        Dim strLine As String
        Dim strColumns() As String

        Dim dtCustomers As New DataTable()
        Dim drCustomer As DataRow

        ' Define the schema of the table,
        ' used to define new rows.
        dtCustomers.Columns.Add("CustomerID")
        dtCustomers.Columns.Add("CompanyName")
        dtCustomers.Columns.Add("ContactName")
        dtCustomers.Columns.Add("Phone")

        ' Extract line from file
        strLine = objStreamReader.ReadLine

        ' Enter loop is data is found
        Do While (Not strLine Is Nothing)
            ' Create a DataRow to hold line
            drCustomer = dtCustomers.NewRow

            ' Create an array of columns separated by commas
            strColumns = Split(strLine, ",")

            ' Quickly fill row with column values
            drCustomer.ItemArray = strColumns

            ' Append row to DataTable
            dtCustomers.Rows.Add(drCustomer)

            'Extract another line
            strLine = objStreamReader.ReadLine
        Loop

        ' Display results
        Return dtCustomers
    End Function

    Public Sub New()
        MyBase.new()
    End Sub

    Public Sub New(ByVal FileName As String)
        ' Allow component to be instantiated
        ' and passed a file at the same time
        MyBase.new()

        m_FileName = FileName
    End Sub
End Class
