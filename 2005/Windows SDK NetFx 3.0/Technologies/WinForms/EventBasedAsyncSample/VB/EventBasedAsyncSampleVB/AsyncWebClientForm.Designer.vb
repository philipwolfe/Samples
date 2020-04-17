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
Partial Public Class AsyncWebClientForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsyncWebClientForm))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.WebClientOperationToolStripTextProgressPanel = New System.Windows.Forms.ToolStripStatusLabel
        Me.WebClientOperationToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.GroupBoxFileDownload = New System.Windows.Forms.GroupBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtToLocation = New System.Windows.Forms.TextBox
        Me.btnDownloadFile = New System.Windows.Forms.Button
        Me.lblFrom = New System.Windows.Forms.Label
        Me.txtFromLocation = New System.Windows.Forms.TextBox
        Me.GroupBoxInstructions = New System.Windows.Forms.GroupBox
        Me.InstructionsLinkLabel = New System.Windows.Forms.LinkLabel
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBoxFileDownload.SuspendLayout()
        Me.GroupBoxInstructions.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(128, 73)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WebClientOperationToolStripTextProgressPanel, Me.WebClientOperationToolStripProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 213)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(443, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'WebClientOperationToolStripTextProgressPanel
        '
        Me.WebClientOperationToolStripTextProgressPanel.Name = "WebClientOperationToolStripTextProgressPanel"
        Me.WebClientOperationToolStripTextProgressPanel.Size = New System.Drawing.Size(0, 17)
        '
        'WebClientOperationToolStripProgressBar
        '
        Me.WebClientOperationToolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.WebClientOperationToolStripProgressBar.Name = "WebClientOperationToolStripProgressBar"
        Me.WebClientOperationToolStripProgressBar.Size = New System.Drawing.Size(100, 15)
        Me.WebClientOperationToolStripProgressBar.Step = 1
        '
        'GroupBoxFileDownload
        '
        Me.GroupBoxFileDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxFileDownload.Controls.Add(Me.btnBrowse)
        Me.GroupBoxFileDownload.Controls.Add(Me.lblTo)
        Me.GroupBoxFileDownload.Controls.Add(Me.btnCancel)
        Me.GroupBoxFileDownload.Controls.Add(Me.txtToLocation)
        Me.GroupBoxFileDownload.Controls.Add(Me.btnDownloadFile)
        Me.GroupBoxFileDownload.Controls.Add(Me.lblFrom)
        Me.GroupBoxFileDownload.Controls.Add(Me.txtFromLocation)
        Me.GroupBoxFileDownload.Location = New System.Drawing.Point(10, 100)
        Me.GroupBoxFileDownload.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.GroupBoxFileDownload.Name = "GroupBoxFileDownload"
        Me.GroupBoxFileDownload.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBoxFileDownload.Size = New System.Drawing.Size(418, 104)
        Me.GroupBoxFileDownload.TabIndex = 0
        Me.GroupBoxFileDownload.TabStop = False
        Me.GroupBoxFileDownload.Text = "File download"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(335, 46)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "&Browse . . ."
        '
        'lblTo
        '
        Me.lblTo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(7, 51)
        Me.lblTo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(23, 13)
        Me.lblTo.TabIndex = 11
        Me.lblTo.Text = "To:"
        '
        'txtToLocation
        '
        Me.txtToLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtToLocation.Location = New System.Drawing.Point(45, 48)
        Me.txtToLocation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.txtToLocation.Name = "txtToLocation"
        Me.txtToLocation.Size = New System.Drawing.Size(284, 20)
        Me.txtToLocation.TabIndex = 1
        Me.txtToLocation.Text = "bigdownload.txt"
        '
        'btnDownloadFile
        '
        Me.btnDownloadFile.Location = New System.Drawing.Point(45, 73)
        Me.btnDownloadFile.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnDownloadFile.Name = "btnDownloadFile"
        Me.btnDownloadFile.Size = New System.Drawing.Size(76, 23)
        Me.btnDownloadFile.TabIndex = 3
        Me.btnDownloadFile.Text = "&Download"
        '
        'lblFrom
        '
        Me.lblFrom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(7, 25)
        Me.lblFrom.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(33, 13)
        Me.lblFrom.TabIndex = 3
        Me.lblFrom.Text = "From:"
        '
        'txtFromLocation
        '
        Me.txtFromLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFromLocation.Location = New System.Drawing.Point(45, 22)
        Me.txtFromLocation.Margin = New System.Windows.Forms.Padding(2, 2, 3, 3)
        Me.txtFromLocation.Name = "txtFromLocation"
        Me.txtFromLocation.Size = New System.Drawing.Size(284, 20)
        Me.txtFromLocation.TabIndex = 0
        Me.txtFromLocation.Text = "http://localhost/big.txt"
        '
        'GroupBoxInstructions
        '
        Me.GroupBoxInstructions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxInstructions.Controls.Add(Me.InstructionsLinkLabel)
        Me.GroupBoxInstructions.Location = New System.Drawing.Point(8, 13)
        Me.GroupBoxInstructions.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.GroupBoxInstructions.Name = "GroupBoxInstructions"
        Me.GroupBoxInstructions.Padding = New System.Windows.Forms.Padding(9)
        Me.GroupBoxInstructions.Size = New System.Drawing.Size(425, 75)
        Me.GroupBoxInstructions.TabIndex = 1
        Me.GroupBoxInstructions.TabStop = False
        Me.GroupBoxInstructions.Text = "Instructions"
        '
        'InstructionsLinkLabel
        '
        Me.InstructionsLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InstructionsLinkLabel.Location = New System.Drawing.Point(9, 22)
        Me.InstructionsLinkLabel.Name = "InstructionsLinkLabel"
        Me.InstructionsLinkLabel.Size = New System.Drawing.Size(407, 44)
        Me.InstructionsLinkLabel.TabIndex = 6
        Me.InstructionsLinkLabel.TabStop = True
        Me.InstructionsLinkLabel.Text = resources.GetString("InstructionsLinkLabel.Text")
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.AddExtension = False
        '
        'AsyncWebClientForm
        '
        Me.AcceptButton = Me.btnDownloadFile
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(443, 235)
        Me.Controls.Add(Me.GroupBoxInstructions)
        Me.Controls.Add(Me.GroupBoxFileDownload)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MinimumSize = New System.Drawing.Size(451, 269)
        Me.Name = "AsyncWebClientForm"
        Me.Text = "Async WebClient Sample"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBoxFileDownload.ResumeLayout(False)
        Me.GroupBoxFileDownload.PerformLayout()
        Me.GroupBoxInstructions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents WebClientOperationToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents GroupBoxFileDownload As System.Windows.Forms.GroupBox
    Friend WithEvents btnDownloadFile As System.Windows.Forms.Button
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents txtFromLocation As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxInstructions As System.Windows.Forms.GroupBox
    Friend WithEvents WorkaroundPanel As System.Windows.Forms.Panel
    Friend WithEvents InstructionsLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtToLocation As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents WebClientOperationToolStripTextProgressPanel As System.Windows.Forms.ToolStripStatusLabel
End Class
