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
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.btnStartWorkflow = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(96, 74)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(154, 20)
        Me.txtLastName.TabIndex = 7
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(96, 45)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(154, 20)
        Me.txtFirstName.TabIndex = 6
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(30, 77)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(59, 13)
        Me.label2.TabIndex = 10
        Me.label2.Text = "Last name:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(29, 48)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 13)
        Me.label1.TabIndex = 9
        Me.label1.Text = "First name:"
        '
        'btnStartWorkflow
        '
        Me.btnStartWorkflow.Location = New System.Drawing.Point(143, 112)
        Me.btnStartWorkflow.Name = "btnStartWorkflow"
        Me.btnStartWorkflow.Size = New System.Drawing.Size(107, 23)
        Me.btnStartWorkflow.TabIndex = 8
        Me.btnStartWorkflow.Text = "Start Workflow"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(281, 156)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnStartWorkflow)
        Me.Name = "Form1"
        Me.Text = "Hello World Workflow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtLastName As System.Windows.Forms.TextBox
    Private WithEvents txtFirstName As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnStartWorkflow As System.Windows.Forms.Button

End Class
