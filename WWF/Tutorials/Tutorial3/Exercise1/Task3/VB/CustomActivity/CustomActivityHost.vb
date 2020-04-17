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
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Workflow.Runtime

Namespace Microsoft.Samples.Workflow.Tutorials.CustomActivity
    Public Class MainForm : Inherits Form
        Private addressCaption As System.Windows.Forms.Label
        Private address As System.Windows.Forms.TextBox
        Private data As System.Windows.Forms.TextBox
        Private WithEvents goButton As System.Windows.Forms.Button
        Private components As System.ComponentModel.IContainer = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub goButton_Click(ByVal sender As Object, _
            ByVal e As EventArgs) Handles goButton.Click
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not components Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.addressCaption = New System.Windows.Forms.Label()
            Me.address = New System.Windows.Forms.TextBox()
            Me.data = New System.Windows.Forms.TextBox()
            Me.goButton = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' addressCaption
            ' 
            Me.addressCaption.AutoSize = True
            Me.addressCaption.Location = New System.Drawing.Point(15, 13)
            Me.addressCaption.Name = "addressCaption"
            Me.addressCaption.Size = New System.Drawing.Size(41, 13)
            Me.addressCaption.TabIndex = 0
            Me.addressCaption.Text = "Address"
            ' 
            ' address
            ' 
            Me.address.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or _
                         System.Windows.Forms.AnchorStyles.Left) Or _
                         System.Windows.Forms.AnchorStyles.Right), _
                         System.Windows.Forms.AnchorStyles))
            Me.address.Location = New System.Drawing.Point(16, 28)
            Me.address.Name = "address"
            Me.address.Size = New System.Drawing.Size(430, 20)
            Me.address.TabIndex = 0
            Me.address.Text = "http://"
            ' 
            ' data
            ' 
            Me.data.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or _
                         System.Windows.Forms.AnchorStyles.Bottom) Or _
                         System.Windows.Forms.AnchorStyles.Left) Or _
                         System.Windows.Forms.AnchorStyles.Right), _
                         System.Windows.Forms.AnchorStyles))
            Me.data.Location = New System.Drawing.Point(15, 55)
            Me.data.Multiline = True
            Me.data.Name = "data"
            Me.data.ReadOnly = True
            Me.data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.data.Size = New System.Drawing.Size(496, 320)
            Me.data.TabIndex = 2
            ' 
            ' goButton
            ' 
            Me.goButton.Location = New System.Drawing.Point(462, 25)
            Me.goButton.Name = "goButton"
            Me.goButton.Size = New System.Drawing.Size(49, 23)
            Me.goButton.TabIndex = 1
            Me.goButton.Text = "Go"
            Me.goButton.Anchor = CType( _
                (System.Windows.Forms.AnchorStyles.Top Or _
                System.Windows.Forms.AnchorStyles.Right), _
                System.Windows.Forms.AnchorStyles)
            ' 
            ' MainForm
            ' 
            Me.AcceptButton = Me.goButton
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(523, 407)
            Me.Controls.Add(Me.goButton)
            Me.Controls.Add(Me.data)
            Me.Controls.Add(Me.address)
            Me.Controls.Add(Me.addressCaption)
            Me.Name = "MainForm"
            Me.Text = "Web Tear"
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
