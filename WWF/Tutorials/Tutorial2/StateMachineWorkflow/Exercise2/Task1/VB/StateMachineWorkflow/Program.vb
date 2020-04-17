'---------------------------------------------------------------------
'  This file is part of the Windows Workflow Foundation SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
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
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Hosting
Imports System.Workflow.Activities

Namespace Microsoft.Samples.Workflow.Tutorials.StateMachineWorkflow
    Public Class MainForm : Inherits Form
        Private label1 As System.Windows.Forms.Label
        Private itemsList As System.Windows.Forms.ComboBox
        Private label2 As System.Windows.Forms.Label
        Private itemQuantity As System.Windows.Forms.NumericUpDown
        Private WithEvents submitButton As System.Windows.Forms.Button
        Private groupBox1 As System.Windows.Forms.GroupBox
        Private WithEvents ordersIdList As System.Windows.Forms.ComboBox
        Private label3 As System.Windows.Forms.Label
        Private orderStatus As System.Windows.Forms.TextBox
        Private label4 As System.Windows.Forms.Label
        Private components As System.ComponentModel.IContainer = Nothing

        Private orderHistory As Dictionary(Of String, List(Of String))
        Private inventoryItems As String() = _
            {"Apple", "Orange", "Banana", "Pear", "Watermelon", "Grapes"}

        Private Delegate Sub ItemStatusUpdateDelegate _
            (ByVal orderId As Guid, ByVal newStatus As String)

        Public Sub New()
            InitializeComponent()
            ' Initialize the inventory items list
            For Each item As String In Me.inventoryItems
                Me.itemsList.Items.Add(item)
            Next item
            Me.itemsList.SelectedIndex = 0

            ' Initialize the order history collection
            Me.orderHistory = New Dictionary(Of String, List(Of String))
        End Sub

        Private Function GetOrderHistory(ByVal orderId As String) As String
            ' Retrieve the order status
            Dim itemHistory As StringBuilder = New StringBuilder()

            For Each status As String In Me.orderHistory(orderId)
                itemHistory.Append(status)
                itemHistory.Append(Environment.NewLine)
            Next status
            Return itemHistory.ToString()
        End Function

        Private Sub submitButton_Click(ByVal sender As Object, _
            ByVal e As EventArgs) Handles submitButton.Click
        End Sub

        Private Sub ordersIdList_SelectedIndexChanged(ByVal sender As Object, _
            ByVal e As EventArgs) Handles ordersIdList.SelectedIndexChanged
            Me.orderStatus.Text = GetOrderHistory(Me.ordersIdList.SelectedItem.ToString())
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not components Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label()
            Me.itemsList = New System.Windows.Forms.ComboBox()
            Me.label2 = New System.Windows.Forms.Label()
            Me.itemQuantity = New System.Windows.Forms.NumericUpDown()
            Me.submitButton = New System.Windows.Forms.Button()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.orderStatus = New System.Windows.Forms.TextBox()
            Me.label4 = New System.Windows.Forms.Label()
            Me.ordersIdList = New System.Windows.Forms.ComboBox()
            Me.label3 = New System.Windows.Forms.Label()
            CType(Me.itemQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.groupBox1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(12, 9)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(23, 13)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Item"
            ' 
            ' Me.itemsList
            ' 
            Me.itemsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.itemsList.FormattingEnabled = True
            Me.itemsList.Location = New System.Drawing.Point(13, 26)
            Me.itemsList.Name = "itemsList"
            Me.itemsList.Size = New System.Drawing.Size(161, 21)
            Me.itemsList.TabIndex = 0
            ' 
            ' label2
            ' 
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(12, 50)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(42, 13)
            Me.label2.TabIndex = 2
            Me.label2.Text = "Quantity"
            ' 
            ' Me.itemQuantity
            ' 
            Me.itemQuantity.Location = New System.Drawing.Point(13, 67)
            Me.itemQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.itemQuantity.Name = "itemQuantity"
            Me.itemQuantity.Size = New System.Drawing.Size(80, 20)
            Me.itemQuantity.TabIndex = 1
            Me.itemQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
            ' 
            ' submitButton
            ' 
            Me.submitButton.Location = New System.Drawing.Point(99, 64)
            Me.submitButton.Name = "submitButton"
            Me.submitButton.Size = New System.Drawing.Size(100, 23)
            Me.submitButton.TabIndex = 2
            Me.submitButton.Text = "Submit Order"
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Controls.Add(Me.orderStatus)
            Me.groupBox1.Controls.Add(Me.label4)
            Me.groupBox1.Controls.Add(Me.ordersIdList)
            Me.groupBox1.Controls.Add(Me.label3)
            Me.groupBox1.Location = New System.Drawing.Point(13, 93)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(247, 193)
            Me.groupBox1.TabIndex = 3
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Order Status"
            ' 
            ' Me.orderStatus
            ' 
            Me.orderStatus.Location = New System.Drawing.Point(7, 82)
            Me.orderStatus.Multiline = True
            Me.orderStatus.Name = "orderStatus"
            Me.orderStatus.ReadOnly = True
            Me.orderStatus.Size = New System.Drawing.Size(230, 105)
            Me.orderStatus.TabIndex = 3
            ' 
            ' label4
            ' 
            Me.label4.AutoSize = True
            Me.label4.Location = New System.Drawing.Point(8, 65)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(35, 13)
            Me.label4.TabIndex = 2
            Me.label4.Text = "History"
            ' 
            ' Me.ordersIdList
            ' 
            Me.ordersIdList.DropDownStyle = _
                System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ordersIdList.FormattingEnabled = True
            Me.ordersIdList.Location = New System.Drawing.Point(7, 37)
            Me.ordersIdList.Name = "ordersIdList"
            Me.ordersIdList.Size = New System.Drawing.Size(230, 21)
            Me.ordersIdList.TabIndex = 0
            ' 
            ' label3
            ' 
            Me.label3.AutoSize = True
            Me.label3.Location = New System.Drawing.Point(7, 20)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(41, 13)
            Me.label3.TabIndex = 0
            Me.label3.Text = "Order Id"
            ' 
            ' MainForm
            ' 
            Me.AcceptButton = Me.submitButton
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(272, 298)
            Me.Controls.Add(Me.groupBox1)
            Me.Controls.Add(Me.submitButton)
            Me.Controls.Add(Me.itemQuantity)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.itemsList)
            Me.Controls.Add(Me.label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "MainForm"
            Me.Text = "Simple Order Form"
            CType(Me.itemQuantity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub
    End Class

    Friend Class Program
        Private Sub New()
        End Sub
        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New MainForm())
        End Sub
    End Class
End Namespace
