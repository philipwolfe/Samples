'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
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

Partial Public Class SimpleBackgroundWorkerForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.OperationToolStripTextProgressPanel = New System.Windows.Forms.ToolStripStatusLabel
        Me.OperationToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.btnStart = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.lblInput = New System.Windows.Forms.Label
        Me.lblOutput = New System.Windows.Forms.Label
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.mtxtInput = New System.Windows.Forms.MaskedTextBox
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperationToolStripTextProgressPanel, Me.OperationToolStripProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 102)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(443, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'OperationToolStripTextProgressPanel
        '
        Me.OperationToolStripTextProgressPanel.Name = "OperationToolStripTextProgressPanel"
        Me.OperationToolStripTextProgressPanel.Size = New System.Drawing.Size(38, 17)
        Me.OperationToolStripTextProgressPanel.Text = "Ready"
        '
        'OperationToolStripProgressBar
        '
        Me.OperationToolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.OperationToolStripProgressBar.Name = "OperationToolStripProgressBar"
        Me.OperationToolStripProgressBar.Size = New System.Drawing.Size(100, 15)
        Me.OperationToolStripProgressBar.Step = 1
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(267, 67)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "&Start"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(349, 67)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.Location = New System.Drawing.Point(18, 16)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(34, 13)
        Me.lblInput.TabIndex = 18
        Me.lblInput.Text = "Input:"
        '
        'lblOutput
        '
        Me.lblOutput.AutoSize = True
        Me.lblOutput.Location = New System.Drawing.Point(18, 43)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(42, 13)
        Me.lblOutput.TabIndex = 19
        Me.lblOutput.Text = "Output:"
        '
        'txtOutput
        '
        Me.txtOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutput.Location = New System.Drawing.Point(66, 40)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(358, 20)
        Me.txtOutput.TabIndex = 1
        '
        'mtxtInput
        '
        Me.mtxtInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mtxtInput.Location = New System.Drawing.Point(66, 13)
        Me.mtxtInput.Mask = "00000"
        Me.mtxtInput.Name = "mtxtInput"
        Me.mtxtInput.Size = New System.Drawing.Size(358, 20)
        Me.mtxtInput.TabIndex = 0
        Me.mtxtInput.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'SimpleBackgroundWorkerForm
        '
        Me.AcceptButton = Me.btnStart
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(443, 124)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mtxtInput)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.lblOutput)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnStart)
        Me.MinimumSize = New System.Drawing.Size(451, 158)
        Me.Name = "SimpleBackgroundWorkerForm"
        Me.Text = "Async BackgroundWorker Sample"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents OperationToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents OperationToolStripTextProgressPanel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblInput As System.Windows.Forms.Label
    Friend WithEvents lblOutput As System.Windows.Forms.Label
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents mtxtInput As System.Windows.Forms.MaskedTextBox
End Class
