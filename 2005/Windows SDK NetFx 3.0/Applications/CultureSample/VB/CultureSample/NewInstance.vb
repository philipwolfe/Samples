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
'Imports System.Data

Imports System.Globalization

'/ <summary>
'/ Summary description for form.
'/ </summary>

Public Class NewInstance
    Inherits System.Windows.Forms.Form
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    Private labelHeading As System.Windows.Forms.Label
    Private WithEvents buttonCancel As System.Windows.Forms.Button
    Private labelName As System.Windows.Forms.Label
    Private comboBoxLocale As System.Windows.Forms.ComboBox
    Private textBoxName As System.Windows.Forms.TextBox
    Private labelLocale As System.Windows.Forms.Label
    Private WithEvents buttonNext As System.Windows.Forms.Button
    
    'private CultureInfoHelper to be passed on to the child form
    Private helper As CultureInfoHelper
    
    
    Public Sub New(ByVal thisHelper As CultureInfoHelper) 
        InitializeComponent()
        helper = thisHelper
        comboBoxLocale.Items.AddRange(helper.GetCultures(CultureTypes.InstalledWin32Cultures))
        comboBoxLocale.SelectedIndex = 0
    
    End Sub 'New
    
    
    Private Sub buttonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)  Handles buttonCancel.Click
        Me.Close()
    
    End Sub 'buttonCancel_Click
    
    
    Private Sub buttonNext_Click_1(ByVal sender As Object, ByVal e As System.EventArgs)  Handles buttonNext.Click
        If textBoxName.Text.Length = 0 Then
            Return
        End If
        If textBoxName.Text.Contains(Constants.Space) Then
            MessageBox.Show(Constants.ErrorInvalidName)
            textBoxName.Clear()
            Return
        End If
        'Using the helper register the new instance
        helper.NewCultureInstance(CStr(comboBoxLocale.SelectedItem), textBoxName.Text)
        Me.Close()
    
    End Sub 'buttonNext_Click_1
    
    #Region "Windows designer code"
    
    Private Sub InitializeComponent() 
        Me.labelHeading = New System.Windows.Forms.Label()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.labelName = New System.Windows.Forms.Label()
        Me.comboBoxLocale = New System.Windows.Forms.ComboBox()
        Me.textBoxName = New System.Windows.Forms.TextBox()
        Me.labelLocale = New System.Windows.Forms.Label()
        Me.buttonNext = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' labelHeading
        ' 
        Me.labelHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0))
        Me.labelHeading.Location = New System.Drawing.Point(84, 34)
        Me.labelHeading.Name = "labelHeading"
        Me.labelHeading.Size = New System.Drawing.Size(142, 23)
        Me.labelHeading.TabIndex = 22
        Me.labelHeading.Text = "Create a new instance"
        ' 
        ' buttonCancel
        ' 
        Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancel.Location = New System.Drawing.Point(151, 210)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.TabIndex = 29
        Me.buttonCancel.Text = "Cancel"
        ' 
        ' labelName
        ' 
        Me.labelName.Location = New System.Drawing.Point(36, 140)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(63, 23)
        Me.labelName.TabIndex = 23
        Me.labelName.Text = "Name:"
        ' 
        ' comboBoxLocale
        ' 
        Me.comboBoxLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxLocale.Location = New System.Drawing.Point(115, 104)
        Me.comboBoxLocale.Name = "comboBoxLocale"
        Me.comboBoxLocale.Size = New System.Drawing.Size(142, 21)
        Me.comboBoxLocale.TabIndex = 26
        ' 
        ' textBoxName
        ' 
        Me.textBoxName.Location = New System.Drawing.Point(115, 140)
        Me.textBoxName.Name = "textBoxName"
        Me.textBoxName.Size = New System.Drawing.Size(142, 20)
        Me.textBoxName.TabIndex = 27
        ' 
        ' labelLocale
        ' 
        Me.labelLocale.Location = New System.Drawing.Point(36, 104)
        Me.labelLocale.Name = "labelLocale"
        Me.labelLocale.Size = New System.Drawing.Size(57, 23)
        Me.labelLocale.TabIndex = 24
        Me.labelLocale.Text = "Locale:"
        ' 
        ' buttonNext
        ' 
        Me.buttonNext.Location = New System.Drawing.Point(52, 210)
        Me.buttonNext.Name = "buttonNext"
        Me.buttonNext.TabIndex = 28
        Me.buttonNext.Text = "OK"
        ' 
        ' NewInstance
        ' 
        Me.AcceptButton = Me.buttonNext
        Me.AutoSize = True
        Me.CancelButton = Me.buttonCancel
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(buttonNext)
        Me.Controls.Add(labelName)
        Me.Controls.Add(comboBoxLocale)
        Me.Controls.Add(textBoxName)
        Me.Controls.Add(labelLocale)
        Me.Controls.Add(labelHeading)
        Me.Controls.Add(buttonCancel)
        Me.Name = "NewInstance"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.Text = "New Instance"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    
    End Sub 'InitializeComponent 
    #End Region
    
    
    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean) 
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    
    End Sub 'Dispose
End Class 'NewInstance 
