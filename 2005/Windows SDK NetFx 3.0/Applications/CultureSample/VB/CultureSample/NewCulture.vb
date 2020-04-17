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


'/ <summary>
'/ Form for creating new culture.
'/ </summary>

Public Class NewCulture
    Inherits System.Windows.Forms.Form
    #Region "Windows Form Designer declarations"
    Private WithEvents buttonCancel As System.Windows.Forms.Button
    Private labelHeading As System.Windows.Forms.Label
    Private textBoxRegion As System.Windows.Forms.TextBox
    Private textBoxLang As System.Windows.Forms.TextBox
    Private labelHyphen As System.Windows.Forms.Label
    Private labelName As System.Windows.Forms.Label
    Private WithEvents buttonNext As System.Windows.Forms.Button
    #End Region
    
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.Container = Nothing
    
    'private CultureInfoHelper to be passed on to the child form
    Private helper As CultureInfoHelper
    
    
    Public Sub New(ByVal thisHelper As CultureInfoHelper) 
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
        helper = thisHelper
    
    End Sub 'New
    
    
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
    
    #Region "Windows Form Designer generated code"
    
    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent() 
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.labelHeading = New System.Windows.Forms.Label()
        Me.textBoxRegion = New System.Windows.Forms.TextBox()
        Me.textBoxLang = New System.Windows.Forms.TextBox()
        Me.labelHyphen = New System.Windows.Forms.Label()
        Me.labelName = New System.Windows.Forms.Label()
        Me.buttonNext = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' buttonCancel
        ' 
        Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancel.Location = New System.Drawing.Point(160, 213)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.TabIndex = 34
        Me.buttonCancel.Text = "Cancel"
        ' 
        ' labelHeading
        ' 
        Me.labelHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0))
        Me.labelHeading.Location = New System.Drawing.Point(83, 38)
        Me.labelHeading.Name = "labelHeading"
        Me.labelHeading.Size = New System.Drawing.Size(119, 23)
        Me.labelHeading.TabIndex = 15
        Me.labelHeading.Text = "Create a new culture"
        ' 
        ' textBoxRegion
        ' 
        Me.textBoxRegion.Location = New System.Drawing.Point(165, 114)
        Me.textBoxRegion.Name = "textBoxRegion"
        Me.textBoxRegion.Size = New System.Drawing.Size(37, 20)
        Me.textBoxRegion.TabIndex = 32
        ' 
        ' textBoxLang
        ' 
        Me.textBoxLang.Location = New System.Drawing.Point(112, 114)
        Me.textBoxLang.Name = "textBoxLang"
        Me.textBoxLang.Size = New System.Drawing.Size(35, 20)
        Me.textBoxLang.TabIndex = 31
        ' 
        ' labelHyphen
        ' 
        Me.labelHyphen.Location = New System.Drawing.Point(152, 114)
        Me.labelHyphen.Name = "labelHyphen"
        Me.labelHyphen.Size = New System.Drawing.Size(39, 23)
        Me.labelHyphen.TabIndex = 32
        Me.labelHyphen.Text = "-"
        ' 
        ' labelName
        ' 
        Me.labelName.Location = New System.Drawing.Point(64, 117)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(69, 23)
        Me.labelName.TabIndex = 29
        Me.labelName.Text = "Name:"
        ' 
        ' buttonNext
        ' 
        Me.buttonNext.Location = New System.Drawing.Point(56, 213)
        Me.buttonNext.Name = "buttonNext"
        Me.buttonNext.TabIndex = 33
        Me.buttonNext.Text = "Next >>"
        ' 
        ' NewCulture
        ' 
        Me.AcceptButton = Me.buttonNext
        Me.CancelButton = Me.buttonCancel
        Me.ClientSize = New System.Drawing.Size(290, 270)
        Me.Controls.Add(buttonNext)
        Me.Controls.Add(textBoxRegion)
        Me.Controls.Add(textBoxLang)
        Me.Controls.Add(labelHyphen)
        Me.Controls.Add(labelName)
        Me.Controls.Add(labelHeading)
        Me.Controls.Add(buttonCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewCulture"
        Me.Text = "New Culture"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    
    End Sub 'InitializeComponent 
    #End Region
    
    
    Private Sub buttonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)  Handles buttonCancel.Click
        Me.Close()
    
    End Sub 'buttonCancel_Click
    
    
    Private Sub buttonNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)  Handles buttonNext.Click
        If textBoxRegion.Text.Length = 0 OrElse textBoxLang.Text.Length = 0 Then
            Return
        End If
        If textBoxRegion.Text.Contains(Constants.Space) OrElse textBoxLang.Text.Contains(Constants.Space) Then
            MessageBox.Show(Constants.ErrorInvalidName)
            Reset()
            Return
        End If
        
        ' Initialise the CultureOptions on the new cultures selected and show
        ' the form
        Dim options As New CultureOptions(helper, textBoxLang.Text, textBoxRegion.Text)
        options.SetFields()
        options.Show()
        Me.Close()
    
    End Sub 'buttonNext_Click
    
    
    Private Sub Reset() 
        textBoxLang.Clear()
        textBoxRegion.Clear()
    
    End Sub 'Reset
End Class 'NewCulture