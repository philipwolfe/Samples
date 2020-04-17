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

' Form to show the order's for a customer.
Public Class CustomerOrdersForm
    Private checkState As System.Collections.Generic.Dictionary(Of Integer, Boolean)

    Public Overloads Sub ShowDialog(ByVal customerId As String, ByVal parent As IWin32Window, ByVal northwindDS As DataSet)
        statusStripPanel1.Width = 150

        ' Put the customer id in the window title.
        Me.Text = "Orders for Customer ID: " + customerId

        ' Create a DataView of the Orders table to filter on the specified customerID.
        Dim dv As DataView = New DataView(northwindDS.Tables("Orders"))
        dv.RowFilter = "CustomerID = '" + customerId + "'"
        dv.Sort = "OrderID"
        dataGridView1.AutoGenerateColumns = False
        dataGridView1.DataSource = dv

        ' The check box column will be virtual.
        dataGridView1.VirtualMode = True
        dataGridView1.Columns.Insert(0, New DataGridViewCheckBoxColumn)

        ' Modify the first column
        With dataGridView1.Columns(0)
            ' Don't allow the column to be resizable.
            .Resizable = DataGridViewTriState.False

            ' Make the check box column frozen so it is always visible.
            .Frozen = True

            ' Put an extra border to make the frozen column more visible
            .DividerWidth = 1
        End With

        ' Make all columns except the first read only.
        For Each c As DataGridViewColumn In dataGridView1.Columns
            If Not (c.Index = 0) Then
                c.ReadOnly = True
            End If
        Next

        ' Initialize the dictionary that contains the boolean check state.
        checkState = New System.Collections.Generic.Dictionary(Of Integer, Boolean)

        ' Show the dialog.
        Me.ShowDialog(parent)
    End Sub

    Private Sub dataGridView1_CellValuePushed(ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs) Handles dataGridView1.CellValuePushed
        ' Handle the notification that the value for a cell in the virtual column
        ' needs to be pushed back to the dictionary.

        If e.ColumnIndex = 0 Then
            ' Get the orderID from the OrderID column.
            Dim orderID As Integer = CType(dataGridView1.Rows(e.RowIndex).Cells("OrderID").Value, Integer)

            ' Add or update the checked value to the dictionary depending on if the 
            ' key (orderID) already exists.
            If Not checkState.ContainsKey(orderID) Then
                checkState.Add(orderID, CType(e.Value, Boolean))
            Else
                checkState(orderID) = CType(e.Value, Boolean)
            End If
        End If
    End Sub

    Private Sub dataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView1.CellValueChanged
        ' Update the status bar when the cell value changes.
        If e.ColumnIndex = 0 Then
            ' Get the orderID from the OrderID column.
            With dataGridView1.Rows(e.RowIndex).Cells("OrderID")
                Dim orderID As Integer = CType(.Value, Integer)
                checkState(orderID) = CType(.Value, Boolean)

                Me.UpdateStatusBar()
            End With
        End If
    End Sub

    Private Sub dataGridView1_CellValueNeeded(ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs) Handles dataGridView1.CellValueNeeded
        ' Handle the notification that the value for a cell in the virtual column
        ' is needed. Get the value from the dictionary if the key exists.
        If e.ColumnIndex = 0 Then
            Dim orderID As Integer = CType(dataGridView1.Rows(e.RowIndex).Cells("OrderID").Value, Integer)

            If checkState.ContainsKey(orderID) Then
                e.Value = checkState(orderID)
            Else
                e.Value = False
            End If
        End If
    End Sub

    Private Sub dataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs) Handles dataGridView1.RowPostPaint
        ' Paint the row number on the row header.
        ' The using statement automatically disposes the brush.
        Using b As SolidBrush = New SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor)

            e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture), _
                                  dataGridView1.DefaultCellStyle.Font, _
                                  b, _
                                  e.RowBounds.Location.X + 20, _
                                  e.RowBounds.Location.Y + 4)

        End Using
    End Sub

    Private Sub UpdateStatusBar()
        ' Calculate the number of checked values in the dictionary and update the status bar.

        Dim number As Integer = 0
        For Each isChecked As Boolean In checkState.Values
            If isChecked Then
                number = number + 1
            End If
        Next

        statusStripPanel1.Text = "Number of orders selected: " & _
                                 number.ToString(System.Globalization.CultureInfo.CurrentUICulture)
    End Sub

    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles dataGridView1.CellFormatting

        ' Format the RequirdDate and ShippedDate cells differently if the shipped date was passed or near the required date.
        If e.ColumnIndex = dataGridView1.Columns("RequiredDate").Index _
           OrElse e.ColumnIndex = dataGridView1.Columns("ShippedDate").Index Then

            ' Get the object value first to check for DBNull since DateTime is a value type.
            Dim shippedDateObject As Object = dataGridView1.Rows(e.RowIndex).Cells("ShippedDate").Value
            Dim requiredDateObject As Object = dataGridView1.Rows(e.RowIndex).Cells("RequiredDate").Value
            
            Dim shippedDate As DateTime
            Dim requiredDate As DateTime

            If Not (DBNull.Equals(shippedDateObject, System.DBNull.Value)) AndAlso _
               Not (DBNull.Equals(requiredDateObject, System.DBNull.Value)) Then

                Try
                    shippedDate = CType(shippedDateObject, DateTime)
                    requiredDate = CType(requiredDateObject, DateTime)
                Catch generatedExceptionVariable0 As InvalidCastException
                    ' Either the shipped date or the required date could not be
                    ' cast to a DateTime. Don't perform any more formatting of the cell.
                    Return
                End Try

                ' Format the cells as red if the Shipped Date was past the Required Date.
                If shippedDate.Date > requiredDate.Date Then
                    e.CellStyle.BackColor = Color.Red
                    e.CellStyle.SelectionBackColor = Color.Red
                    e.CellStyle.SelectionForeColor = Color.Black
                Else
                    ' Format the cells as yellow if the Shipped Date was within 5 days of the Required Date.
                    If Math.Abs((shippedDate.Date - requiredDate.Date).Days) <= 5 Then
                        e.CellStyle.BackColor = Color.Yellow
                        e.CellStyle.SelectionBackColor = Color.Yellow
                        e.CellStyle.SelectionForeColor = Color.Black
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dataGridView1_RowEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView1.RowEnter
        ' Ensure that the row is selected when focus moves to a row.
        ' Without this the first time the dialog is shown the first row is not
        ' fully selected.
        If Not dataGridView1.Rows(e.RowIndex).Selected Then
            dataGridView1.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub CustomerOrdersForm_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyUp
        ' Close the dialog if the user presses Escape.
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub dataGridView1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dataGridView1.KeyDown
        ' Pressing the space bar will toggle the checked state of the row.
        If Not (dataGridView1.CurrentCellAddress.X = 0) Then
            If e.KeyCode = Keys.Space Then

                ' Alternate the selected checked state of the current row.
                With dataGridView1.Rows(dataGridView1.CurrentCellAddress.Y).Cells(0)
                    Dim checkedValue As Boolean = CType(.Value, Boolean)
                    .Value = Not checkedValue
                End With
            End If
        End If
    End Sub

    Private Sub dataGridView1_DataBindingComplete(ByVal sender As Object, ByVal e As DataGridViewBindingCompleteEventArgs) Handles dataGridView1.DataBindingComplete
        ' Auto size columns after the grid data binding is complete.
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub dataGridView1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        ' Update the status bar when the cell value changes.
        If e.ColumnIndex = 0 Then

            ' Force the update of the value for the checkbox column.
            ' Without this, the value doens't get updated until you move off from the cell.
            With dataGridView1.Rows(e.RowIndex).Cells(0)
                .Value = CType(.FormattedValue, Boolean)
            End With
        End If
    End Sub

    Private Sub processToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles processToolStripButton.Click
        ' Perform processing here.
        MessageBox.Show("Process orders here...")
    End Sub
End Class
