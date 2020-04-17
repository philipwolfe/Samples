'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOrderProcessed = New System.Windows.Forms.Button
        Me.btnOrderCanceled = New System.Windows.Forms.Button
        Me.btnOrderUpdated = New System.Windows.Forms.Button
        Me.btnOrderShipped = New System.Windows.Forms.Button
        Me.lstvwOrders = New System.Windows.Forms.ListView
        Me.colWorkflowInstanceID = New System.Windows.Forms.ColumnHeader
        Me.colOrderID = New System.Windows.Forms.ColumnHeader
        Me.colOrderState = New System.Windows.Forms.ColumnHeader
        Me.colWorkflowStatus = New System.Windows.Forms.ColumnHeader
        Me.txtOrderID = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.btnOrderCreated = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnOrderProcessed
        '
        Me.btnOrderProcessed.Location = New System.Drawing.Point(282, 206)
        Me.btnOrderProcessed.Name = "btnOrderProcessed"
        Me.btnOrderProcessed.Size = New System.Drawing.Size(99, 23)
        Me.btnOrderProcessed.TabIndex = 17
        Me.btnOrderProcessed.Text = "Order Processed"
        '
        'btnOrderCanceled
        '
        Me.btnOrderCanceled.Location = New System.Drawing.Point(165, 206)
        Me.btnOrderCanceled.Name = "btnOrderCanceled"
        Me.btnOrderCanceled.Size = New System.Drawing.Size(99, 23)
        Me.btnOrderCanceled.TabIndex = 16
        Me.btnOrderCanceled.Text = "Order Canceled"
        '
        'btnOrderUpdated
        '
        Me.btnOrderUpdated.Location = New System.Drawing.Point(48, 206)
        Me.btnOrderUpdated.Name = "btnOrderUpdated"
        Me.btnOrderUpdated.Size = New System.Drawing.Size(99, 23)
        Me.btnOrderUpdated.TabIndex = 15
        Me.btnOrderUpdated.Text = "Order Updated"
        '
        'btnOrderShipped
        '
        Me.btnOrderShipped.Location = New System.Drawing.Point(399, 206)
        Me.btnOrderShipped.Name = "btnOrderShipped"
        Me.btnOrderShipped.Size = New System.Drawing.Size(99, 23)
        Me.btnOrderShipped.TabIndex = 14
        Me.btnOrderShipped.Text = "Order Shipped"
        '
        'lstvwOrders
        '
        Me.lstvwOrders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colWorkflowInstanceID, Me.colOrderID, Me.colOrderState, Me.colWorkflowStatus})
        Me.lstvwOrders.FullRowSelect = True
        Me.lstvwOrders.GridLines = True
        Me.lstvwOrders.Location = New System.Drawing.Point(12, 80)
        Me.lstvwOrders.MultiSelect = False
        Me.lstvwOrders.Name = "lstvwOrders"
        Me.lstvwOrders.Size = New System.Drawing.Size(571, 109)
        Me.lstvwOrders.TabIndex = 13
        Me.lstvwOrders.UseCompatibleStateImageBehavior = False
        Me.lstvwOrders.View = System.Windows.Forms.View.Details
        '
        'colWorkflowInstanceID
        '
        Me.colWorkflowInstanceID.Text = "Workflow InstanceID"
        Me.colWorkflowInstanceID.Width = 186
        '
        'colOrderID
        '
        Me.colOrderID.Text = "OrderID"
        Me.colOrderID.Width = 100
        '
        'colOrderState
        '
        Me.colOrderState.Text = "Order State"
        Me.colOrderState.Width = 160
        '
        'colWorkflowStatus
        '
        Me.colWorkflowStatus.Text = "Workflow Status"
        Me.colWorkflowStatus.Width = 101
        '
        'txtOrderID
        '
        Me.txtOrderID.Location = New System.Drawing.Point(-130, 53)
        Me.txtOrderID.Name = "txtOrderID"
        Me.txtOrderID.Size = New System.Drawing.Size(122, 20)
        Me.txtOrderID.TabIndex = 12
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(-130, 38)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(44, 13)
        Me.label1.TabIndex = 11
        Me.label1.Text = "OrderID"
        '
        'btnOrderCreated
        '
        Me.btnOrderCreated.Location = New System.Drawing.Point(156, 52)
        Me.btnOrderCreated.Name = "btnOrderCreated"
        Me.btnOrderCreated.Size = New System.Drawing.Size(99, 23)
        Me.btnOrderCreated.TabIndex = 10
        Me.btnOrderCreated.Text = "Order Created"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 54)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(122, 20)
        Me.TextBox1.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "OrderID"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 266)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnOrderProcessed)
        Me.Controls.Add(Me.btnOrderCanceled)
        Me.Controls.Add(Me.btnOrderUpdated)
        Me.Controls.Add(Me.btnOrderShipped)
        Me.Controls.Add(Me.lstvwOrders)
        Me.Controls.Add(Me.txtOrderID)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnOrderCreated)
        Me.Name = "Form1"
        Me.Text = "Order Application - State Machine Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnOrderProcessed As System.Windows.Forms.Button
    Private WithEvents btnOrderCanceled As System.Windows.Forms.Button
    Private WithEvents btnOrderUpdated As System.Windows.Forms.Button
    Private WithEvents btnOrderShipped As System.Windows.Forms.Button
    Private WithEvents lstvwOrders As System.Windows.Forms.ListView
    Private WithEvents colWorkflowInstanceID As System.Windows.Forms.ColumnHeader
    Private WithEvents colOrderID As System.Windows.Forms.ColumnHeader
    Private WithEvents colOrderState As System.Windows.Forms.ColumnHeader
    Private WithEvents colWorkflowStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents txtOrderID As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnOrderCreated As System.Windows.Forms.Button
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label

End Class
