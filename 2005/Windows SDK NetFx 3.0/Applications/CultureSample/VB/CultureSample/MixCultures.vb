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
Imports System.Globalization


'/ <summary>
'/ Form for Mixing cultures.
'/ </summary>

Public Class MixCultures
    Inherits System.Windows.Forms.Form
    #Region "Windows Form Designer declarations"
    Private labelHeading As System.Windows.Forms.Label
    Private labelLocale1 As System.Windows.Forms.Label
    Private comboBoxLocale1 As System.Windows.Forms.ComboBox
    Private WithEvents buttonNext As System.Windows.Forms.Button
    Private labelLocale2 As System.Windows.Forms.Label
    Private comboBoxLocale2 As System.Windows.Forms.ComboBox
    Private labelName As System.Windows.Forms.Label
    Private labelHyphen As System.Windows.Forms.Label
    Private textBoxRegion As System.Windows.Forms.TextBox
    Private textBoxLang As System.Windows.Forms.TextBox
    Private WithEvents buttonClose As System.Windows.Forms.Button
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
        Dim arrayItems As Object() = helper.GetCultures(CultureTypes.InstalledWin32Cultures)
        comboBoxLocale1.Items.AddRange(arrayItems)
        comboBoxLocale2.Items.AddRange(arrayItems)
        
        Reset()
    
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
        Me.buttonClose = New System.Windows.Forms.Button()
        Me.labelLocale1 = New System.Windows.Forms.Label()
        Me.comboBoxLocale1 = New System.Windows.Forms.ComboBox()
        Me.buttonNext = New System.Windows.Forms.Button()
        Me.labelHeading = New System.Windows.Forms.Label()
        Me.labelLocale2 = New System.Windows.Forms.Label()
        Me.comboBoxLocale2 = New System.Windows.Forms.ComboBox()
        Me.labelName = New System.Windows.Forms.Label()
        Me.textBoxRegion = New System.Windows.Forms.TextBox()
        Me.textBoxLang = New System.Windows.Forms.TextBox()
        Me.labelHyphen = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        ' 
        ' buttonClose
        ' 
        Me.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonClose.Location = New System.Drawing.Point(151, 213)
        Me.buttonClose.Name = "buttonClose"
        Me.buttonClose.TabIndex = 24
        Me.buttonClose.Text = "Close"
        ' 
        ' labelLocale1
        ' 
        Me.labelLocale1.Location = New System.Drawing.Point(36, 83)
        Me.labelLocale1.Name = "labelLocale1"
        Me.labelLocale1.Size = New System.Drawing.Size(57, 23)
        Me.labelLocale1.TabIndex = 17
        Me.labelLocale1.Text = "Locale 1:"
        ' 
        ' comboBoxLocale1
        ' 
        Me.comboBoxLocale1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxLocale1.Location = New System.Drawing.Point(115, 83)
        Me.comboBoxLocale1.Name = "comboBoxLocale1"
        Me.comboBoxLocale1.Size = New System.Drawing.Size(142, 21)
        Me.comboBoxLocale1.TabIndex = 19
        ' 
        ' buttonNext
        ' 
        Me.buttonNext.Location = New System.Drawing.Point(65, 213)
        Me.buttonNext.Name = "buttonNext"
        Me.buttonNext.TabIndex = 23
        Me.buttonNext.Text = "Next >>"
        ' 
        ' labelHeading
        ' 
        Me.labelHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0))
        Me.labelHeading.Location = New System.Drawing.Point(99, 37)
        Me.labelHeading.Name = "labelHeading"
        Me.labelHeading.Size = New System.Drawing.Size(94, 23)
        Me.labelHeading.TabIndex = 22
        Me.labelHeading.Text = "Mix two cultures"
        ' 
        ' labelLocale2
        ' 
        Me.labelLocale2.Location = New System.Drawing.Point(36, 125)
        Me.labelLocale2.Name = "labelLocale2"
        Me.labelLocale2.Size = New System.Drawing.Size(57, 23)
        Me.labelLocale2.TabIndex = 23
        Me.labelLocale2.Text = "Locale 2:"
        ' 
        ' comboBoxLocale2
        ' 
        Me.comboBoxLocale2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxLocale2.Location = New System.Drawing.Point(115, 125)
        Me.comboBoxLocale2.Name = "comboBoxLocale2"
        Me.comboBoxLocale2.Size = New System.Drawing.Size(142, 21)
        Me.comboBoxLocale2.TabIndex = 20
        ' 
        ' labelName
        ' 
        Me.labelName.Location = New System.Drawing.Point(36, 172)
        Me.labelName.Name = "labelName"
        Me.labelName.Size = New System.Drawing.Size(69, 23)
        Me.labelName.TabIndex = 25
        Me.labelName.Text = "Name"
        ' 
        ' textBoxRegion
        ' 
        Me.textBoxRegion.Location = New System.Drawing.Point(173, 175)
        Me.textBoxRegion.Name = "textBoxRegion"
        Me.textBoxRegion.Size = New System.Drawing.Size(37, 20)
        Me.textBoxRegion.TabIndex = 22
        ' 
        ' textBoxLang
        ' 
        Me.textBoxLang.Location = New System.Drawing.Point(115, 175)
        Me.textBoxLang.Name = "textBoxLang"
        Me.textBoxLang.Size = New System.Drawing.Size(35, 20)
        Me.textBoxLang.TabIndex = 21
        ' 
        ' labelHyphen
        ' 
        Me.labelHyphen.Location = New System.Drawing.Point(159, 175)
        Me.labelHyphen.Name = "labelHyphen"
        Me.labelHyphen.Size = New System.Drawing.Size(39, 23)
        Me.labelHyphen.TabIndex = 28
        Me.labelHyphen.Text = "-"
        ' 
        ' MixCultures
        ' 
        Me.AcceptButton = Me.buttonNext
        Me.CancelButton = Me.buttonClose
        Me.ClientSize = New System.Drawing.Size(292, 272)
        Me.Controls.Add(textBoxRegion)
        Me.Controls.Add(textBoxLang)
        Me.Controls.Add(labelHyphen)
        Me.Controls.Add(labelName)
        Me.Controls.Add(comboBoxLocale2)
        Me.Controls.Add(labelLocale2)
        Me.Controls.Add(labelHeading)
        Me.Controls.Add(buttonClose)
        Me.Controls.Add(buttonNext)
        Me.Controls.Add(comboBoxLocale1)
        Me.Controls.Add(labelLocale1)
        Me.Name = "MixCultures"
        Me.Text = "Mix Cultures"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    
    End Sub 'InitializeComponent 
    #End Region
    
    
    Private Sub buttonClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)  Handles buttonClose.Click
        Me.Close()
    
    End Sub 'buttonClose_Click
    
    
    Private Sub Reset() 
        comboBoxLocale2.SelectedIndex = 0
        comboBoxLocale1.SelectedIndex = 0
        textBoxLang.Clear()
        textBoxRegion.Clear()
    
    End Sub 'Reset
    
    
    Private Sub buttonNext_Click(ByVal sender As Object, ByVal e As System.EventArgs)  Handles buttonNext.Click
        If textBoxLang.Text.Length = 0 OrElse textBoxRegion.Text.Length = 0 Then
            Reset()
            Return
        End If
        If textBoxLang.Text.Contains(Constants.Space) OrElse textBoxRegion.Text.Contains(Constants.Space) Then
            MessageBox.Show(Constants.ErrorInvalidName)
            Reset()
            Return
        End If
        Dim locale1 As String = CStr(comboBoxLocale1.SelectedItem)
        Dim locale2 As String = CStr(comboBoxLocale2.SelectedItem)
        
        ' Initialise the CultureOptions on the new cultures selected and show
        ' the form
        Dim options As New CultureOptions(helper, textBoxLang.Text, textBoxRegion.Text)
        options.SetFields(locale1, locale2)
        options.Show()
        Me.Close()
    
    End Sub 'buttonNext_Click
End Class 'MixCultures