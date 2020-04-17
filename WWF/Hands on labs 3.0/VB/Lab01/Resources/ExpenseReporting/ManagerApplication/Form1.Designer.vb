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
        Me.btnReject = New System.Windows.Forms.Button
        Me.btnApprove = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.lstvwExpenseReports = New System.Windows.Forms.ListView
        Me.ExpenseReportId = New System.Windows.Forms.ColumnHeader
        Me.Amount = New System.Windows.Forms.ColumnHeader
        Me.SubmittedTime = New System.Windows.Forms.ColumnHeader
        Me.SubmittedBy = New System.Windows.Forms.ColumnHeader
        Me.Status = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'btnReject
        '
        Me.btnReject.Location = New System.Drawing.Point(401, 150)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(75, 23)
        Me.btnReject.TabIndex = 10
        Me.btnReject.Text = "Reject"
        '
        'btnApprove
        '
        Me.btnApprove.Location = New System.Drawing.Point(320, 150)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(75, 23)
        Me.btnApprove.TabIndex = 9
        Me.btnApprove.Text = "Approve"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(482, 150)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "Refresh"
        '
        'lstvwExpenseReports
        '
        Me.lstvwExpenseReports.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ExpenseReportId, Me.Amount, Me.SubmittedTime, Me.SubmittedBy, Me.Status})
        Me.lstvwExpenseReports.Dock = System.Windows.Forms.DockStyle.Top
        Me.lstvwExpenseReports.FullRowSelect = True
        Me.lstvwExpenseReports.GridLines = True
        Me.lstvwExpenseReports.Location = New System.Drawing.Point(0, 0)
        Me.lstvwExpenseReports.Name = "lstvwExpenseReports"
        Me.lstvwExpenseReports.Size = New System.Drawing.Size(569, 132)
        Me.lstvwExpenseReports.TabIndex = 7
        Me.lstvwExpenseReports.UseCompatibleStateImageBehavior = False
        Me.lstvwExpenseReports.View = System.Windows.Forms.View.Details
        '
        'ExpenseReportId
        '
        Me.ExpenseReportId.Text = "Expense Report Id"
        Me.ExpenseReportId.Width = 138
        '
        'Amount
        '
        Me.Amount.Text = "Amount"
        Me.Amount.Width = 86
        '
        'SubmittedTime
        '
        Me.SubmittedTime.Text = "Submitted Time"
        Me.SubmittedTime.Width = 119
        '
        'SubmittedBy
        '
        Me.SubmittedBy.DisplayIndex = 4
        Me.SubmittedBy.Text = "Submitted By"
        Me.SubmittedBy.Width = 115
        '
        'Status
        '
        Me.Status.DisplayIndex = 3
        Me.Status.Text = "Status"
        Me.Status.Width = 88
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 176)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lstvwExpenseReports)
        Me.Name = "Form1"
        Me.Text = "Manager Expense Report Review"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnReject As System.Windows.Forms.Button
    Private WithEvents btnApprove As System.Windows.Forms.Button
    Private WithEvents btnRefresh As System.Windows.Forms.Button
    Private WithEvents lstvwExpenseReports As System.Windows.Forms.ListView
    Private WithEvents ExpenseReportId As System.Windows.Forms.ColumnHeader
    Private WithEvents Amount As System.Windows.Forms.ColumnHeader
    Private WithEvents SubmittedTime As System.Windows.Forms.ColumnHeader
    Private WithEvents SubmittedBy As System.Windows.Forms.ColumnHeader
    Private WithEvents Status As System.Windows.Forms.ColumnHeader

End Class
