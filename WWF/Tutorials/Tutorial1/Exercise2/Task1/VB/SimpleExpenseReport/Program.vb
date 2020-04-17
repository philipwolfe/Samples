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
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Hosting
Imports System.Workflow.Activities
Imports System.Threading

Namespace Microsoft.Samples.Workflow.Tutorials.SequentialWorkflow
    Public Class MainForm : Inherits Form
        Private label1 As System.Windows.Forms.Label
        Private result As System.Windows.Forms.TextBox
        Private label2 As System.Windows.Forms.Label
        Private WithEvents submitButton As System.Windows.Forms.Button
        Private approvalState As System.Windows.Forms.Label
        Private WithEvents approveButton As System.Windows.Forms.Button
        Private WithEvents rejectButton As System.Windows.Forms.Button
        Private WithEvents amount As System.Windows.Forms.TextBox
        Private panel1 As System.Windows.Forms.Panel

        Private components As System.ComponentModel.IContainer = Nothing

        Private workflowRuntime As WorkflowRuntime = Nothing
        Private workflowInstance As WorkflowInstance = Nothing

        Public Sub New()
            InitializeComponent()

            ' Collapse approve/reject panel
            Me.Height = Me.MinimumSize.Height

            Me.workflowRuntime = New WorkflowRuntime()
            workflowRuntime.StartRuntime()

            AddHandler workflowRuntime.WorkflowCompleted, _
                AddressOf Me.workflowRuntime_WorkflowCompleted
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not components Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label()
            Me.result = New System.Windows.Forms.TextBox()
            Me.label2 = New System.Windows.Forms.Label()
            Me.submitButton = New System.Windows.Forms.Button()
            Me.approvalState = New System.Windows.Forms.Label()
            Me.approveButton = New System.Windows.Forms.Button()
            Me.rejectButton = New System.Windows.Forms.Button()
            Me.amount = New System.Windows.Forms.TextBox()
            Me.panel1 = New System.Windows.Forms.Panel()
            Me.panel1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(10, 13)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(43, 13)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Amount"
            ' 
            ' result
            ' 
            Me.result.Location = New System.Drawing.Point(13, 70)
            Me.result.Name = "result"
            Me.result.ReadOnly = True
            Me.result.Size = New System.Drawing.Size(162, 20)
            Me.result.TabIndex = 1
            Me.result.TabStop = False
            ' 
            ' label2
            ' 
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(10, 54)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(37, 13)
            Me.label2.TabIndex = 3
            Me.label2.Text = "Result"
            ' 
            ' submitButton
            ' 
            Me.submitButton.Enabled = False
            Me.submitButton.Location = New System.Drawing.Point(56, 95)
            Me.submitButton.Name = "submitButton"
            Me.submitButton.Size = New System.Drawing.Size(75, 23)
            Me.submitButton.TabIndex = 2
            Me.submitButton.Text = "Submit"
            ' 
            ' approvalState
            ' 
            Me.approvalState.AutoSize = True
            Me.approvalState.Location = New System.Drawing.Point(10, 9)
            Me.approvalState.Name = "approvalState"
            Me.approvalState.Size = New System.Drawing.Size(49, 13)
            Me.approvalState.TabIndex = 4
            Me.approvalState.Text = "Approval"
            ' 
            ' approveButton
            ' 
            Me.approveButton.Enabled = False
            Me.approveButton.Location = New System.Drawing.Point(11, 25)
            Me.approveButton.Name = "approveButton"
            Me.approveButton.Size = New System.Drawing.Size(75, 23)
            Me.approveButton.TabIndex = 0
            Me.approveButton.Text = "Approve"
            ' 
            ' rejectButton
            ' 
            Me.rejectButton.Enabled = False
            Me.rejectButton.Location = New System.Drawing.Point(86, 25)
            Me.rejectButton.Name = "rejectButton"
            Me.rejectButton.Size = New System.Drawing.Size(75, 23)
            Me.rejectButton.TabIndex = 1
            Me.rejectButton.Text = "Reject"
            ' 
            ' amount
            ' 
            Me.amount.Location = New System.Drawing.Point(13, 29)
            Me.amount.MaxLength = 9
            Me.amount.Name = "amount"
            Me.amount.Size = New System.Drawing.Size(162, 20)
            Me.amount.TabIndex = 0
            ' 
            ' panel1
            ' 
            Me.panel1.Controls.Add(Me.approvalState)
            Me.panel1.Controls.Add(Me.approveButton)
            Me.panel1.Controls.Add(Me.rejectButton)
            Me.panel1.Location = New System.Drawing.Point(7, 124)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(172, 66)
            Me.panel1.TabIndex = 8
            ' 
            ' MainForm
            ' 
            Me.AcceptButton = Me.submitButton
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(187, 201)
            Me.MinimumSize = New System.Drawing.Size(197,155)
            Me.Controls.Add(Me.result)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.panel1)
            Me.Controls.Add(Me.amount)
            Me.Controls.Add(Me.submitButton)
            Me.Controls.Add(Me.label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "MainForm"
            Me.Text = "Simple Expense Report"
            Me.panel1.ResumeLayout(False)
            Me.panel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private Sub submitButton_Click(ByVal sender As Object, _
                  ByVal e As EventArgs) Handles submitButton.Click
            Dim type As Type = GetType(ExpenseReportWorkflow)

            ' Construct workflow parameters
            Dim properties As Dictionary(Of String, Object) = _
                New Dictionary(Of String, Object)()
            properties.Add("Amount", Int32.Parse(Me.amount.Text))

            ' Start the workflow
            workflowInstance = workflowRuntime.CreateWorkflow(type, properties)
            workflowInstance.Start()
        End Sub

        Private Sub workflowRuntime_WorkflowCompleted(ByVal sender As Object, _
                  ByVal e As WorkflowCompletedEventArgs)
            If Me.result.InvokeRequired Then
                Me.result.Invoke(New EventHandler(Of WorkflowCompletedEventArgs) _
                    (AddressOf Me.workflowRuntime_WorkflowCompleted), _
                    New Object() {sender, e})
            Else
                Me.result.Text = e.OutputParameters("Result").ToString()

                ' Clear fields
                Me.amount.Text = String.Empty

                ' Disable buttons
                Me.approveButton.Enabled = False
                Me.rejectButton.Enabled = False
            End If
        End Sub

        Private Sub approveButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
                  Handles approveButton.Click
        End Sub

        Private Sub rejectButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
                  Handles rejectButton.Click
        End Sub

        Private Sub amount_KeyPress(ByVal sender As Object, _
                  ByVal e As KeyPressEventArgs) Handles amount.KeyPress
            If (Not Char.IsControl(e.KeyChar)) AndAlso _
                ((Not Char.IsDigit(e.KeyChar))) Then
                e.KeyChar = Char.MinValue
            End If
        End Sub

        Private Sub amount_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
                  Handles amount.TextChanged
            submitButton.Enabled = amount.Text.Length > 0
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
