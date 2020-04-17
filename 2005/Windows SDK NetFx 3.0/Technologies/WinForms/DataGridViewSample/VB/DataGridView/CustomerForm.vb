'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
'
' Copyright (C) Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Option Explicit On
Option Strict On
Imports System.Data

' Form to show the list of customers.
Public Class CustomerForm
    Private northwindDS As DataSet

    Private Sub ViewOrders(ByVal customerId As String)
        ' Show the CustomerOrders dialog, passing in the
        ' customer ID.
        Dim co As CustomerOrdersForm = New CustomerOrdersForm

        co.ShowDialog(customerId, Me, northwindDS)
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Load the DataSet that represents the offline version of the 
        ' Northwind database.

        northwindDS = New DataSet("Northwind")
        northwindDS.ReadXmlSchema(".\NorthwindCustomerOrders.xsd")
        northwindDS.ReadXml(".\NorthwindCustomerOrders.xml", XmlReadMode.Auto)
        northwindDS.Locale = System.Globalization.CultureInfo.CurrentUICulture

        dataGridView1.AutoGenerateColumns = False
        dataGridView1.DataSource = northwindDS
        dataGridView1.DataMember = "Customers"
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
    End Sub

    Private Sub dataGridView1_RowValidating(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles dataGridView1.RowValidating
        ' Calculate the customer ID for offline mode. Currently this is done by handling
        ' the RowValidating event, but note that this event fires each time focus leaves 
        ' a row. Currently the row index has to be special cased to decide when to perform
        ' calculate the customerID.            

        If (e.RowIndex = (dataGridView1.Rows.Count - 2)) AndAlso _
           dataGridView1.Rows(e.RowIndex + 1).IsNewRow Then

            Dim row As DataGridViewRow = dataGridView1.Rows(e.RowIndex)

            ' Only want to calculate the CustomerID if it hasn't been calculated.
            If Not row.Cells("CustomerID").Value Is Nothing Then

                If row.Cells("CustomerID").Value.ToString = "<AUTO>" Then

                    ' CustomerID is calculated by taking the first 2 characters 
                    ' of the Company name and appending the RowIndex. 
                    Dim coname As String = TryCast(row.Cells("Company").Value, String)

                    If Not (coname Is Nothing) Then
                        Dim coid As String = coname.ToUpper.Substring(0, Math.Min(2, coname.Length)) + e.RowIndex.ToString
                        row.Cells("CustomerID").Value = coid
                        e.Cancel = False
                    End If
                End If
            End If
         End If
    End Sub

    Private Sub dataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As DataGridViewRowEventArgs) Handles dataGridView1.DefaultValuesNeeded
        ' Identify to the user that the CustomerID is auto-generated.
        e.Row.Cells("CustomerID").Value = "<AUTO>"
    End Sub

    Private Sub dataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles dataGridView1.DataError
        ' Show the row error text if data error occurs on commit of data.
        If e.Context = DataGridViewDataErrorContexts.Commit Then
            dataGridView1.Rows(e.RowIndex).ErrorText = e.Exception.ToString
            e.Cancel = True
        End If
    End Sub

    Private Sub dataGridView1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        ' Show the customer order screen when the user clicks the link.
        If e.ColumnIndex = 1 AndAlso Not dataGridView1.Rows(e.RowIndex).IsNewRow Then

            Dim customerID As String = TryCast(dataGridView1.Rows(e.RowIndex).Cells("CustomerID").Value, String)
            If Not (customerID Is Nothing) Then
                Me.ViewOrders(customerID)
            End If
        End If
    End Sub

    Private Sub dataGridView1_RowEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView1.RowEnter
        ' Ensure that the row is selected when focus moves to a row except
        ' for the new row where selection should be cell based.
        If dataGridView1.Rows(e.RowIndex).IsNewRow Then

            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
            dataGridView1.Rows(e.RowIndex).Selected = False

            If Not dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected Then
                dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
            End If
        Else

            ' Without this the first time the dialog is shown the first row is not
            ' fully selected.
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If Not dataGridView1.Rows(e.RowIndex).Selected Then
                dataGridView1.Rows(e.RowIndex).Selected = True
            End If
        End If
    End Sub

    Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles dataGridView1.CellValidating
        ' Validate that the content length will fit into the DataSet.
        If dataGridView1.IsCurrentCellDirty Then

            Dim maxLength As Integer = northwindDS.Tables("Customers").Columns(e.ColumnIndex).MaxLength
            If e.FormattedValue.ToString.Length > maxLength Then

                ' Show error icon/text since the value cannot fit.
                dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "Column value cannot exceed " + maxLength.ToString(System.Globalization.CultureInfo.CurrentUICulture) + " characters."
                e.Cancel = False
            Else
                ' Clear the error icon/text.
                Dim c As DataGridViewCell = dataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)
                If Not (c.ErrorText = String.Empty) Then
                    c.ErrorText = String.Empty
                End If
            End If
        End If
    End Sub

    Private Sub dataGridView1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dataGridView1.KeyDown
        ' Show the customer order screen when the user presses Enter except for
        ' where the Customer ID is not yet known (such as the New Row).
        If e.KeyData = Keys.Enter Then

            Dim customerID As String = TryCast(dataGridView1.Rows(dataGridView1.CurrentCellAddress.Y).Cells("CustomerID").Value, String)

            If Not (customerID Is Nothing) Then
                ' Stop the DataGridView from processing the enter.
                e.Handled = True
                Me.ViewOrders(customerID)
            End If
        End If
    End Sub

    Private Sub newToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newToolStripMenuItem.Click
        ' Move focus to the new row and start editing.
        If Not dataGridView1.IsCurrentCellInEditMode Then
            dataGridView1.CurrentCell = dataGridView1.Rows(dataGridView1.Rows.Count - 1).Cells("Company")
        End If

    End Sub

    Private Sub viewOrdersToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles viewOrdersToolStripMenuItem.Click
        ' Show the customer order screen when the user presses Enter except for
        ' where the Customer ID is not yet known (such as the New Row).
        Dim customerID As String = TryCast(dataGridView1.Rows(dataGridView1.CurrentCellAddress.Y).Cells("CustomerID").Value, String)

        If Not (customerID Is Nothing) Then
            Me.ViewOrders(customerID)
        End If
    End Sub

    Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
        ' Close the form to exit the application.
        Me.Close()
    End Sub

End Class
