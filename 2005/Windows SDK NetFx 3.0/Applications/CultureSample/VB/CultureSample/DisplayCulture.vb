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
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
'Imports System.Data
Imports System.Windows.Forms
Imports System.Globalization



'/ <summary>
'/ Form to display a culture
'/ </summary>

Public Class DisplayCulture
    Inherits System.Windows.Forms.UserControl
    #Region "Windows Form Designer declarations"
    Private groupBoxRegion As System.Windows.Forms.GroupBox
    Private textBoxLanguage As System.Windows.Forms.TextBox
    Private textBoxCountryRegion As System.Windows.Forms.TextBox
    Private labelCountryRegion As System.Windows.Forms.Label
    Private labelLanguage As System.Windows.Forms.Label
    Private groupBoxSample As System.Windows.Forms.GroupBox
    Private textBoxPositiveCurrency As System.Windows.Forms.TextBox
    Private textBoxNegativeCurrency As System.Windows.Forms.TextBox
    Private labelNegativeCurrency As System.Windows.Forms.Label
    Private labelPositiveCurrency As System.Windows.Forms.Label
    Private textBoxPositiveNumber As System.Windows.Forms.TextBox
    Private textBoxNegativeNumber As System.Windows.Forms.TextBox
    Private labelNegativeNumber As System.Windows.Forms.Label
    Private labelPositiveNumber As System.Windows.Forms.Label
    Private groupBoxDateTime As System.Windows.Forms.GroupBox
    Private textBoxTime As System.Windows.Forms.TextBox
    Private textBoxLongDate As System.Windows.Forms.TextBox
    Private labelTime As System.Windows.Forms.Label
    Private labelLongDate As System.Windows.Forms.Label
    Private textBoxShortDate As System.Windows.Forms.TextBox
    Private labelShortDate As System.Windows.Forms.Label
    Private WithEvents comboBoxLocale As System.Windows.Forms.ComboBox
    Private labelLocale As System.Windows.Forms.Label
    #End Region
    
    '/ <summary> 
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    
    
    Public Sub New() 
        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()
    
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
    
    #Region "Component Designer generated code"
    
    '/ <summary> 
    '/ Required method for Designer support - do not modify 
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent() 
        Me.groupBoxRegion = New System.Windows.Forms.GroupBox()
        Me.textBoxLanguage = New System.Windows.Forms.TextBox()
        Me.textBoxCountryRegion = New System.Windows.Forms.TextBox()
        Me.labelCountryRegion = New System.Windows.Forms.Label()
        Me.labelLanguage = New System.Windows.Forms.Label()
        Me.labelLocale = New System.Windows.Forms.Label()
        Me.comboBoxLocale = New System.Windows.Forms.ComboBox()
        Me.groupBoxSample = New System.Windows.Forms.GroupBox()
        Me.textBoxPositiveCurrency = New System.Windows.Forms.TextBox()
        Me.textBoxNegativeCurrency = New System.Windows.Forms.TextBox()
        Me.labelNegativeCurrency = New System.Windows.Forms.Label()
        Me.labelPositiveCurrency = New System.Windows.Forms.Label()
        Me.textBoxPositiveNumber = New System.Windows.Forms.TextBox()
        Me.textBoxNegativeNumber = New System.Windows.Forms.TextBox()
        Me.labelNegativeNumber = New System.Windows.Forms.Label()
        Me.labelPositiveNumber = New System.Windows.Forms.Label()
        Me.groupBoxDateTime = New System.Windows.Forms.GroupBox()
        Me.textBoxTime = New System.Windows.Forms.TextBox()
        Me.textBoxLongDate = New System.Windows.Forms.TextBox()
        Me.labelTime = New System.Windows.Forms.Label()
        Me.labelLongDate = New System.Windows.Forms.Label()
        Me.textBoxShortDate = New System.Windows.Forms.TextBox()
        Me.labelShortDate = New System.Windows.Forms.Label()
        Me.groupBoxRegion.SuspendLayout()
        Me.groupBoxSample.SuspendLayout()
        Me.groupBoxDateTime.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' groupBoxRegion
        ' 
        Me.groupBoxRegion.Controls.Add(Me.textBoxLanguage)
        Me.groupBoxRegion.Controls.Add(Me.textBoxCountryRegion)
        Me.groupBoxRegion.Controls.Add(Me.labelCountryRegion)
        Me.groupBoxRegion.Controls.Add(Me.labelLanguage)
        Me.groupBoxRegion.Location = New System.Drawing.Point(4, 45)
        Me.groupBoxRegion.Name = "groupBoxRegion"
        Me.groupBoxRegion.Size = New System.Drawing.Size(358, 69)
        Me.groupBoxRegion.TabIndex = 9
        Me.groupBoxRegion.TabStop = False
        Me.groupBoxRegion.Text = "Region"
        ' 
        ' textBoxLanguage
        ' 
        Me.textBoxLanguage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(238))
        Me.textBoxLanguage.Location = New System.Drawing.Point(181, 14)
        Me.textBoxLanguage.Name = "textBoxLanguage"
        Me.textBoxLanguage.ReadOnly = True
        Me.textBoxLanguage.Size = New System.Drawing.Size(159, 20)
        Me.textBoxLanguage.TabIndex = 3
        ' 
        ' textBoxCountryRegion
        ' 
        Me.textBoxCountryRegion.Location = New System.Drawing.Point(181, 39)
        Me.textBoxCountryRegion.Name = "textBoxCountryRegion"
        Me.textBoxCountryRegion.ReadOnly = True
        Me.textBoxCountryRegion.Size = New System.Drawing.Size(159, 20)
        Me.textBoxCountryRegion.TabIndex = 4
        ' 
        ' labelCountryRegion
        ' 
        Me.labelCountryRegion.Location = New System.Drawing.Point(49, 39)
        Me.labelCountryRegion.Name = "labelCountryRegion"
        Me.labelCountryRegion.Size = New System.Drawing.Size(119, 23)
        Me.labelCountryRegion.TabIndex = 1
        Me.labelCountryRegion.Text = "Country/Region code"
        ' 
        ' labelLanguage
        ' 
        Me.labelLanguage.Location = New System.Drawing.Point(49, 14)
        Me.labelLanguage.Name = "labelLanguage"
        Me.labelLanguage.Size = New System.Drawing.Size(160, 23)
        Me.labelLanguage.TabIndex = 0
        Me.labelLanguage.Text = "Name:"
        ' 
        ' labelLocale
        ' 
        Me.labelLocale.Location = New System.Drawing.Point(6, 13)
        Me.labelLocale.Name = "labelLocale"
        Me.labelLocale.Size = New System.Drawing.Size(57, 23)
        Me.labelLocale.TabIndex = 13
        Me.labelLocale.Text = "Locale:"
        ' 
        ' comboBoxLocale
        ' 
        Me.comboBoxLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxLocale.Location = New System.Drawing.Point(70, 13)
        Me.comboBoxLocale.Name = "comboBoxLocale"
        Me.comboBoxLocale.Size = New System.Drawing.Size(292, 21)
        Me.comboBoxLocale.TabIndex = 1
        ' 
        ' groupBoxSample
        ' 
        Me.groupBoxSample.Controls.Add(Me.textBoxPositiveCurrency)
        Me.groupBoxSample.Controls.Add(Me.textBoxNegativeCurrency)
        Me.groupBoxSample.Controls.Add(Me.labelNegativeCurrency)
        Me.groupBoxSample.Controls.Add(Me.labelPositiveCurrency)
        Me.groupBoxSample.Controls.Add(Me.textBoxPositiveNumber)
        Me.groupBoxSample.Controls.Add(Me.textBoxNegativeNumber)
        Me.groupBoxSample.Controls.Add(Me.labelNegativeNumber)
        Me.groupBoxSample.Controls.Add(Me.labelPositiveNumber)
        Me.groupBoxSample.Location = New System.Drawing.Point(4, 118)
        Me.groupBoxSample.Name = "groupBoxSample"
        Me.groupBoxSample.Size = New System.Drawing.Size(358, 126)
        Me.groupBoxSample.TabIndex = 8
        Me.groupBoxSample.TabStop = False
        Me.groupBoxSample.Text = "Number and Currency"
        ' 
        ' textBoxPositiveCurrency
        ' 
        Me.textBoxPositiveCurrency.Location = New System.Drawing.Point(182, 67)
        Me.textBoxPositiveCurrency.Name = "textBoxPositiveCurrency"
        Me.textBoxPositiveCurrency.ReadOnly = True
        Me.textBoxPositiveCurrency.Size = New System.Drawing.Size(158, 20)
        Me.textBoxPositiveCurrency.TabIndex = 7
        ' 
        ' textBoxNegativeCurrency
        ' 
        Me.textBoxNegativeCurrency.Location = New System.Drawing.Point(182, 96)
        Me.textBoxNegativeCurrency.Name = "textBoxNegativeCurrency"
        Me.textBoxNegativeCurrency.ReadOnly = True
        Me.textBoxNegativeCurrency.Size = New System.Drawing.Size(158, 20)
        Me.textBoxNegativeCurrency.TabIndex = 8
        ' 
        ' labelNegativeCurrency
        ' 
        Me.labelNegativeCurrency.Location = New System.Drawing.Point(48, 92)
        Me.labelNegativeCurrency.Name = "labelNegativeCurrency"
        Me.labelNegativeCurrency.TabIndex = 5
        Me.labelNegativeCurrency.Text = "Negative currency:"
        ' 
        ' labelPositiveCurrency
        ' 
        Me.labelPositiveCurrency.Location = New System.Drawing.Point(48, 67)
        Me.labelPositiveCurrency.Name = "labelPositiveCurrency"
        Me.labelPositiveCurrency.TabIndex = 4
        Me.labelPositiveCurrency.Text = "Positive currency:"
        ' 
        ' textBoxPositiveNumber
        ' 
        Me.textBoxPositiveNumber.Location = New System.Drawing.Point(182, 11)
        Me.textBoxPositiveNumber.Name = "textBoxPositiveNumber"
        Me.textBoxPositiveNumber.ReadOnly = True
        Me.textBoxPositiveNumber.Size = New System.Drawing.Size(158, 20)
        Me.textBoxPositiveNumber.TabIndex = 5
        ' 
        ' textBoxNegativeNumber
        ' 
        Me.textBoxNegativeNumber.Location = New System.Drawing.Point(182, 37)
        Me.textBoxNegativeNumber.Name = "textBoxNegativeNumber"
        Me.textBoxNegativeNumber.ReadOnly = True
        Me.textBoxNegativeNumber.Size = New System.Drawing.Size(158, 20)
        Me.textBoxNegativeNumber.TabIndex = 6
        ' 
        ' labelNegativeNumber
        ' 
        Me.labelNegativeNumber.Location = New System.Drawing.Point(48, 42)
        Me.labelNegativeNumber.Name = "labelNegativeNumber"
        Me.labelNegativeNumber.TabIndex = 1
        Me.labelNegativeNumber.Text = "Negative number:"
        ' 
        ' labelPositiveNumber
        ' 
        Me.labelPositiveNumber.Location = New System.Drawing.Point(48, 17)
        Me.labelPositiveNumber.Name = "labelPositiveNumber"
        Me.labelPositiveNumber.TabIndex = 0
        Me.labelPositiveNumber.Text = "Positive number:"
        ' 
        ' groupBoxDateTime
        ' 
        Me.groupBoxDateTime.Controls.Add(Me.textBoxTime)
        Me.groupBoxDateTime.Controls.Add(Me.textBoxLongDate)
        Me.groupBoxDateTime.Controls.Add(Me.labelTime)
        Me.groupBoxDateTime.Controls.Add(Me.labelLongDate)
        Me.groupBoxDateTime.Controls.Add(Me.textBoxShortDate)
        Me.groupBoxDateTime.Controls.Add(Me.labelShortDate)
        Me.groupBoxDateTime.Location = New System.Drawing.Point(4, 249)
        Me.groupBoxDateTime.Name = "groupBoxDateTime"
        Me.groupBoxDateTime.Size = New System.Drawing.Size(358, 113)
        Me.groupBoxDateTime.TabIndex = 7
        Me.groupBoxDateTime.TabStop = False
        Me.groupBoxDateTime.Text = "Date and Time"
        ' 
        ' textBoxTime
        ' 
        Me.textBoxTime.Location = New System.Drawing.Point(184, 75)
        Me.textBoxTime.Name = "textBoxTime"
        Me.textBoxTime.ReadOnly = True
        Me.textBoxTime.Size = New System.Drawing.Size(156, 20)
        Me.textBoxTime.TabIndex = 15
        ' 
        ' textBoxLongDate
        ' 
        Me.textBoxLongDate.Location = New System.Drawing.Point(184, 45)
        Me.textBoxLongDate.Name = "textBoxLongDate"
        Me.textBoxLongDate.ReadOnly = True
        Me.textBoxLongDate.Size = New System.Drawing.Size(156, 20)
        Me.textBoxLongDate.TabIndex = 10
        ' 
        ' labelTime
        ' 
        Me.labelTime.Location = New System.Drawing.Point(44, 72)
        Me.labelTime.Name = "labelTime"
        Me.labelTime.Size = New System.Drawing.Size(80, 23)
        Me.labelTime.TabIndex = 13
        Me.labelTime.Text = "Time:"
        ' 
        ' labelLongDate
        ' 
        Me.labelLongDate.Location = New System.Drawing.Point(44, 46)
        Me.labelLongDate.Name = "labelLongDate"
        Me.labelLongDate.Size = New System.Drawing.Size(80, 23)
        Me.labelLongDate.TabIndex = 12
        Me.labelLongDate.Text = "Long date:"
        ' 
        ' textBoxShortDate
        ' 
        Me.textBoxShortDate.Location = New System.Drawing.Point(184, 17)
        Me.textBoxShortDate.Name = "textBoxShortDate"
        Me.textBoxShortDate.ReadOnly = True
        Me.textBoxShortDate.Size = New System.Drawing.Size(156, 20)
        Me.textBoxShortDate.TabIndex = 9
        ' 
        ' labelShortDate
        ' 
        Me.labelShortDate.Location = New System.Drawing.Point(44, 19)
        Me.labelShortDate.Name = "labelShortDate"
        Me.labelShortDate.TabIndex = 0
        Me.labelShortDate.Text = "Short date :"
        ' 
        ' DisplayCulture
        ' 
        Me.Controls.Add(groupBoxRegion)
        Me.Controls.Add(groupBoxSample)
        Me.Controls.Add(groupBoxDateTime)
        Me.Controls.Add(comboBoxLocale)
        Me.Controls.Add(labelLocale)
        Me.Name = "DisplayCulture"
        Me.Size = New System.Drawing.Size(369, 374)
        Me.groupBoxRegion.ResumeLayout(False)
        Me.groupBoxRegion.PerformLayout()
        Me.groupBoxSample.ResumeLayout(False)
        Me.groupBoxSample.PerformLayout()
        Me.groupBoxDateTime.ResumeLayout(False)
        Me.groupBoxDateTime.PerformLayout()
        Me.ResumeLayout(False)
    
    End Sub 'InitializeComponent 
    #End Region
    
    
    '*
'		 * Method to display formats of a culture
'		 
    Public Sub Print(ByVal ci As CultureInfo) 
        textBoxLanguage.Text = ci.Name
        textBoxCountryRegion.Text = ci.EnglishName
        
        Dim posInt As Int64 = Constants.LongNumber
        textBoxPositiveNumber.Text = posInt.ToString(Constants.NumberFormat, ci.NumberFormat)
        textBoxPositiveCurrency.Text = posInt.ToString(Constants.CurrencyFormat, ci.NumberFormat)
        posInt = - posInt
        textBoxNegativeNumber.Text = posInt.ToString(Constants.NumberFormat, ci.NumberFormat)
        textBoxNegativeCurrency.Text = posInt.ToString(Constants.CurrencyFormat, ci.NumberFormat)
        
        Dim dt As DateTime = DateTime.Now
        textBoxShortDate.Text = dt.ToString(Constants.ShortDateFormat, ci.DateTimeFormat)
        textBoxLongDate.Text = dt.ToString(Constants.LongDateFormat, ci.DateTimeFormat)
        textBoxTime.Text = dt.ToString(Constants.TimeFormat, ci.DateTimeFormat)
    
    End Sub 'Print
    
    
    '*
'		 * Method to populate the list initially
'		 
    Public Sub LoadComboBox(ByVal values() As Object) 
        comboBoxLocale.Items.AddRange(values)
    
    End Sub 'LoadComboBox
    
    
    Private Sub comboBoxLocale_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)  Handles comboBoxLocale.SelectedIndexChanged
        'Override the default values
        Dim ci As New CultureInfo(CStr(comboBoxLocale.SelectedItem), True)
        
        'Neutral cultures cannot be parsed
        If ci.IsNeutralCulture Then
            MessageBox.Show(Constants.ErrorNeutralCulture)
            ClearForm()
            Return
        End If
        
        Print(ci)
    
    End Sub 'comboBoxLocale_SelectedIndexChanged

    Private Sub ClearForm()

        textBoxCountryRegion.Text = ""
        textBoxLanguage.Text = ""
        textBoxPositiveNumber.Text = ""
        textBoxPositiveCurrency.Text = ""
        textBoxNegativeNumber.Text = ""
        textBoxNegativeCurrency.Text = ""

        textBoxShortDate.Text = ""
        textBoxLongDate.Text = ""
        textBoxTime.Text = ""

    End Sub


    '*
    '		 * Method to add a new Item to the list once a new culture is created
    '		 
    Public Sub AddSelectItem(ByVal itemName As String)
        'Insert the new item ont he top of the list and select it
        comboBoxLocale.Items.Insert(0, itemName)
        comboBoxLocale.SelectedIndex = 0

    End Sub 'AddSelectItem
End Class 'DisplayCulture