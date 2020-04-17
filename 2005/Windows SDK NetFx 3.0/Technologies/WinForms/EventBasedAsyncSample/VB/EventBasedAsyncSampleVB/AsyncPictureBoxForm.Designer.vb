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
Partial Public Class AsyncPictureBoxForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InstructionsLinkLabel.TabStop = False


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
        Me.BigImagePictureBox = New System.Windows.Forms.PictureBox
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblLocation = New System.Windows.Forms.Label
        Me.ImageLoadProgressBar = New System.Windows.Forms.ProgressBar
        Me.btnLoad = New System.Windows.Forms.Button
        Me.GroupBoxInstructions = New System.Windows.Forms.GroupBox
        Me.InstructionsLinkLabel = New System.Windows.Forms.LinkLabel
        CType(Me.BigImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxInstructions.SuspendLayout()
        Me.SuspendLayout()
        '
        'BigImagePictureBox
        '
        Me.BigImagePictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BigImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BigImagePictureBox.Location = New System.Drawing.Point(11, 119)
        Me.BigImagePictureBox.Margin = New System.Windows.Forms.Padding(2, 3, 0, 3)
        Me.BigImagePictureBox.Name = "BigImagePictureBox"
        Me.BigImagePictureBox.Size = New System.Drawing.Size(421, 160)
        Me.BigImagePictureBox.TabIndex = 0
        Me.BigImagePictureBox.TabStop = False
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.Location = New System.Drawing.Point(101, 91)
        Me.txtLocation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(165, 20)
        Me.txtLocation.TabIndex = 0
        Me.txtLocation.Text = "big.bmp"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Enabled = False
        Me.btnCancel.Location = New System.Drawing.Point(358, 89)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(11, 94)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(2, 3, 3, 3)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(86, 13)
        Me.lblLocation.TabIndex = 0
        Me.lblLocation.Text = "Bitmap Location:"
        '
        'ImageLoadProgressBar
        '
        Me.ImageLoadProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageLoadProgressBar.Location = New System.Drawing.Point(11, 285)
        Me.ImageLoadProgressBar.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.ImageLoadProgressBar.Name = "ImageLoadProgressBar"
        Me.ImageLoadProgressBar.Size = New System.Drawing.Size(422, 23)
        Me.ImageLoadProgressBar.Step = 1
        Me.ImageLoadProgressBar.TabIndex = 0
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Location = New System.Drawing.Point(276, 89)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "&Load"
        '
        'GroupBoxInstructions
        '
        Me.GroupBoxInstructions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxInstructions.Controls.Add(Me.InstructionsLinkLabel)
        Me.GroupBoxInstructions.Location = New System.Drawing.Point(8, 11)
        Me.GroupBoxInstructions.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.GroupBoxInstructions.Name = "GroupBoxInstructions"
        Me.GroupBoxInstructions.Padding = New System.Windows.Forms.Padding(9)
        Me.GroupBoxInstructions.Size = New System.Drawing.Size(425, 72)
        Me.GroupBoxInstructions.TabIndex = 5
        Me.GroupBoxInstructions.TabStop = False
        Me.GroupBoxInstructions.Text = "Instructions"
        '
        'InstructionsLinkLabel
        '
        Me.InstructionsLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InstructionsLinkLabel.Location = New System.Drawing.Point(9, 22)
        Me.InstructionsLinkLabel.Name = "InstructionsLinkLabel"
        Me.InstructionsLinkLabel.Size = New System.Drawing.Size(407, 41)
        Me.InstructionsLinkLabel.TabIndex = 1
        Me.InstructionsLinkLabel.TabStop = True
        Me.InstructionsLinkLabel.Text = "For this sample to demo correctly you need to load a large bitmap into the Pictur" & _
            "eBox. Click here to generate a large bitmap called ""big.bmp"" in the same locatio" & _
            "n as the sample exe."
        '
        'AsyncPictureBoxForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 316)
        Me.Controls.Add(Me.GroupBoxInstructions)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.ImageLoadProgressBar)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.BigImagePictureBox)
        Me.MinimumSize = New System.Drawing.Size(451, 350)
        Me.Name = "AsyncPictureBoxForm"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Text = "Async PictureBox Sample"
        CType(Me.BigImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxInstructions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BigImagePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents ImageLoadProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents GroupBoxInstructions As System.Windows.Forms.GroupBox
    Friend WithEvents WorkaroundPanel As System.Windows.Forms.Panel
    Friend WithEvents InstructionsLinkLabel As System.Windows.Forms.LinkLabel



End Class
