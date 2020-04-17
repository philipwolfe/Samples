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
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.txtSubmittedBy = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.lstvwExpenseReports = New System.Windows.Forms.ListView
        Me.ExpenseReportId = New System.Windows.Forms.ColumnHeader
        Me.Amount = New System.Windows.Forms.ColumnHeader
        Me.SubmittedTime = New System.Windows.Forms.ColumnHeader
        Me.SubmittedBy = New System.Windows.Forms.ColumnHeader
        Me.Status = New System.Windows.Forms.ColumnHeader
        Me.button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(13, 25)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtAmount.TabIndex = 6
        Me.txtAmount.Text = "1500"
        '
        'txtSubmittedBy
        '
        Me.txtSubmittedBy.Location = New System.Drawing.Point(145, 25)
        Me.txtSubmittedBy.Name = "txtSubmittedBy"
        Me.txtSubmittedBy.Size = New System.Drawing.Size(136, 20)
        Me.txtSubmittedBy.TabIndex = 7
        Me.txtSubmittedBy.Text = "Ari Bixhorn"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(144, 9)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(72, 13)
        Me.label2.TabIndex = 12
        Me.label2.Text = "Submitted By:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(46, 13)
        Me.label1.TabIndex = 11
        Me.label1.Text = "Amount:"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(412, 215)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(109, 23)
        Me.btnRefresh.TabIndex = 10
        Me.btnRefresh.Text = "Refresh Reports"
        '
        'lstvwExpenseReports
        '
        Me.lstvwExpenseReports.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ExpenseReportId, Me.Amount, Me.SubmittedTime, Me.SubmittedBy, Me.Status})
        Me.lstvwExpenseReports.FullRowSelect = True
        Me.lstvwExpenseReports.GridLines = True
        Me.lstvwExpenseReports.Location = New System.Drawing.Point(0, 77)
        Me.lstvwExpenseReports.Name = "lstvwExpenseReports"
        Me.lstvwExpenseReports.Size = New System.Drawing.Size(521, 132)
        Me.lstvwExpenseReports.TabIndex = 9
        Me.lstvwExpenseReports.UseCompatibleStateImageBehavior = False
        Me.lstvwExpenseReports.View = System.Windows.Forms.View.Details
        '
        'ExpenseReportId
        '
        Me.ExpenseReportId.Text = "Expense Report Id"
        Me.ExpenseReportId.Width = 126
        '
        'Amount
        '
        Me.Amount.Text = "Amount"
        Me.Amount.Width = 86
        '
        'SubmittedTime
        '
        Me.SubmittedTime.Text = "SubmittedTime"
        Me.SubmittedTime.Width = 119
        '
        'SubmittedBy
        '
        Me.SubmittedBy.DisplayIndex = 4
        Me.SubmittedBy.Text = "Submitted By"
        Me.SubmittedBy.Width = 92
        '
        'Status
        '
        Me.Status.DisplayIndex = 3
        Me.Status.Text = "Status"
        Me.Status.Width = 86
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(298, 23)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(104, 23)
        Me.button1.TabIndex = 8
        Me.button1.Text = "Submit Report"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 248)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtSubmittedBy)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lstvwExpenseReports)
        Me.Controls.Add(Me.button1)
        Me.Name = "Form1"
        Me.Text = "Expense Reporting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtAmount As System.Windows.Forms.TextBox
    Private WithEvents txtSubmittedBy As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnRefresh As System.Windows.Forms.Button
    Private WithEvents lstvwExpenseReports As System.Windows.Forms.ListView
    Private WithEvents ExpenseReportId As System.Windows.Forms.ColumnHeader
    Private WithEvents Amount As System.Windows.Forms.ColumnHeader
    Private WithEvents SubmittedTime As System.Windows.Forms.ColumnHeader
    Private WithEvents SubmittedBy As System.Windows.Forms.ColumnHeader
    Private WithEvents Status As System.Windows.Forms.ColumnHeader
    Private WithEvents button1 As System.Windows.Forms.Button

End Class
