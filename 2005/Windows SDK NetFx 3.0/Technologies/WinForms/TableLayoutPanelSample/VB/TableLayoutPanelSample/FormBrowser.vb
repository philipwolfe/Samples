'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET SDK Code Samples.
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
'-----------------------------------------------------------------------
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Class formBrowser
    Inherits System.Windows.Forms.Form
    
    Private components As System.ComponentModel.IContainer = Nothing
    Private pendingForm As Form

    Public Sub New()

        Application.EnableVisualStyles()
        InitializeComponent()

    End Sub 'New

    Private Sub buttonViewForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonViewForm.Click

        Select Case comboSelectForm.SelectedIndex

            Case 0
                pendingForm = New BasicDataEntry()

            Case 1
                pendingForm = New TwoPaneProp()

        End Select

        ' locate new form away from browser form
        pendingForm.Location = New Point(Me.Location.X + Me.Size.Width, Me.Location.Y)
        pendingForm.Show()

    End Sub 'buttonViewForm_Click

    Private Sub formBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Populate list of available forms
        Me.comboSelectForm.Items.Add("Basic Data Entry Form")
        Me.comboSelectForm.Items.Add("Two-Paned Proportional Form")

        ' init combobox to basic data entry form
        comboSelectForm.SelectedIndex = 0

    End Sub 'formBrowser_Load

    Private Sub comboSelectForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboSelectForm.SelectedIndexChanged

        Select Case comboSelectForm.SelectedIndex

            Case 0
                pictureThumbnail.Image = TableLayoutPanelSample.My.Resources.Resource1.BasicDataEntry1
                textDescription.Text = "A simple data entry form, using the TableLayoutPanel to yield simple but robust resizing behavior." + vbCr + vbLf + vbCr + vbLf
                textDescription.Text += "A single TableLayoutPanel encompasses all controls except for the two Buttons at the bottom of the Form." + vbCr + vbLf + vbCr + vbLf

            Case 1
                pictureThumbnail.Image = TableLayoutPanelSample.My.Resources.Resource1.TwoPaneProp
                textDescription.Text = "A basic two-pane form, supporting proportional resizing of the two main panes, plus two absolutely positioned buttons within a central column."

        End Select

    End Sub

End Class 'formBrowser




