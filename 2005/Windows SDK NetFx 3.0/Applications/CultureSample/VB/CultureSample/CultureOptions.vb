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
'/ Form to dispaly the properties of a culture for editing 
'/ </summary>

Public Class CultureOptions
    Inherits System.Windows.Forms.Form
    #Region "Windows Form Designer declarations"
    Private tabControlMain As System.Windows.Forms.TabControl
    Private tabPageTime As System.Windows.Forms.TabPage
    Private tabPageDate As System.Windows.Forms.TabPage
    Private groupBoxSample As System.Windows.Forms.GroupBox
    Private labelPositive As System.Windows.Forms.Label
    Private textBoxPositive As System.Windows.Forms.TextBox
    Private labelNegative As System.Windows.Forms.Label
    Private textBoxNegative As System.Windows.Forms.TextBox
    Private labelSymbol As System.Windows.Forms.Label
    Private labelDigits As System.Windows.Forms.Label
    Private labelGrouping As System.Windows.Forms.Label
    Private labelNegativeSign As System.Windows.Forms.Label
    Private labelNegativeNumber As System.Windows.Forms.Label
    Private labelSeparator As System.Windows.Forms.Label
    Private comboBoxSymbol As System.Windows.Forms.ComboBox
    Private comboBoxGrouping As System.Windows.Forms.ComboBox
    Private comboBoxNegativeSign As System.Windows.Forms.ComboBox
    Private comboBoxNegativeNumber As System.Windows.Forms.ComboBox
    Private comboBoxDigits As System.Windows.Forms.ComboBox
    Private comboBoxSeparator As System.Windows.Forms.ComboBox
    Private textBoxNegativeCurrency As System.Windows.Forms.TextBox
    Private groupBoxCurrencySample As System.Windows.Forms.GroupBox
    Private textBoxPositiveCurrency As System.Windows.Forms.TextBox
    Private labelNegativeCurrency As System.Windows.Forms.Label
    Private labelPositiveCurrency As System.Windows.Forms.Label
    Private labelSymbolCurrency As System.Windows.Forms.Label
    Private labelNegCurrency As System.Windows.Forms.Label
    Private labelPosCurrency As System.Windows.Forms.Label
    Private labelDecimal As System.Windows.Forms.Label
    Private labelDecimalDigits As System.Windows.Forms.Label
    Private labelGroupingCurrency As System.Windows.Forms.Label
    Private comboBoxDecimal As System.Windows.Forms.ComboBox
    Private comboBoxGroupingCurrency As System.Windows.Forms.ComboBox
    Private comboBoxNegative As System.Windows.Forms.ComboBox
    Private comboBoxCurrencySymbol As System.Windows.Forms.ComboBox
    Private comboBoxPositive As System.Windows.Forms.ComboBox
    Private comboBoxDecimalDigits As System.Windows.Forms.ComboBox
    Private groupBoxSampleTime As System.Windows.Forms.GroupBox
    Private labelSample As System.Windows.Forms.Label
    Private comboBoxAM As System.Windows.Forms.ComboBox
    Private comboBoxPM As System.Windows.Forms.ComboBox
    Private label1 As System.Windows.Forms.Label
    Private labelPM As System.Windows.Forms.Label
    Private labelAM As System.Windows.Forms.Label
    Private comboBoxFormat As System.Windows.Forms.ComboBox
    Private WithEvents buttonOk As System.Windows.Forms.Button
    Private WithEvents buttonCancel As System.Windows.Forms.Button
    Private labelShortDate As System.Windows.Forms.Label
    Private groupBoxShortDate As System.Windows.Forms.GroupBox
    Private textBoxShortDate As System.Windows.Forms.TextBox
    Private labelShortDateFormat As System.Windows.Forms.Label
    Private comboBoxShortDateFormat As System.Windows.Forms.ComboBox
    Private comboBoxDateSeparator As System.Windows.Forms.ComboBox
    Private labelDateSeparator As System.Windows.Forms.Label
    Private groupBoxLongDate As System.Windows.Forms.GroupBox
    Private labelLongDate As System.Windows.Forms.Label
    Private comboBoxLongDateFormat As System.Windows.Forms.ComboBox
    Private labelLongDateFormat As System.Windows.Forms.Label
    Private textBoxLongDate As System.Windows.Forms.TextBox
    Private textBoxSample As System.Windows.Forms.TextBox
    Private tabPageNumber As System.Windows.Forms.TabPage
    Private tabPageCurrency As System.Windows.Forms.TabPage
    #End Region
    
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.Container = Nothing
    Private helper As CultureInfoHelper
    
    'Locale names in case the form is used for mixing cultures
    'The names are null otherwise
    Private locale1, locale2 As String
    Private language, regionName As String


    Public Sub New(ByVal thisHelper As CultureInfoHelper, ByVal lang As String, ByVal reg As String)
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()

        helper = thisHelper
        language = lang
        regionName = reg

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
        Me.tabControlMain = New System.Windows.Forms.TabControl()
        Me.tabPageNumber = New System.Windows.Forms.TabPage()
        Me.comboBoxSeparator = New System.Windows.Forms.ComboBox()
        Me.comboBoxNegativeNumber = New System.Windows.Forms.ComboBox()
        Me.comboBoxDigits = New System.Windows.Forms.ComboBox()
        Me.comboBoxNegativeSign = New System.Windows.Forms.ComboBox()
        Me.comboBoxGrouping = New System.Windows.Forms.ComboBox()
        Me.comboBoxSymbol = New System.Windows.Forms.ComboBox()
        Me.labelSeparator = New System.Windows.Forms.Label()
        Me.labelNegativeNumber = New System.Windows.Forms.Label()
        Me.labelNegativeSign = New System.Windows.Forms.Label()
        Me.labelGrouping = New System.Windows.Forms.Label()
        Me.labelDigits = New System.Windows.Forms.Label()
        Me.labelSymbol = New System.Windows.Forms.Label()
        Me.groupBoxSample = New System.Windows.Forms.GroupBox()
        Me.textBoxPositive = New System.Windows.Forms.TextBox()
        Me.textBoxNegative = New System.Windows.Forms.TextBox()
        Me.labelNegative = New System.Windows.Forms.Label()
        Me.labelPositive = New System.Windows.Forms.Label()
        Me.tabPageCurrency = New System.Windows.Forms.TabPage()
        Me.comboBoxGroupingCurrency = New System.Windows.Forms.ComboBox()
        Me.comboBoxDecimalDigits = New System.Windows.Forms.ComboBox()
        Me.comboBoxPositive = New System.Windows.Forms.ComboBox()
        Me.comboBoxDecimal = New System.Windows.Forms.ComboBox()
        Me.comboBoxNegative = New System.Windows.Forms.ComboBox()
        Me.comboBoxCurrencySymbol = New System.Windows.Forms.ComboBox()
        Me.labelGroupingCurrency = New System.Windows.Forms.Label()
        Me.labelDecimalDigits = New System.Windows.Forms.Label()
        Me.labelDecimal = New System.Windows.Forms.Label()
        Me.labelNegCurrency = New System.Windows.Forms.Label()
        Me.labelPosCurrency = New System.Windows.Forms.Label()
        Me.labelSymbolCurrency = New System.Windows.Forms.Label()
        Me.groupBoxCurrencySample = New System.Windows.Forms.GroupBox()
        Me.textBoxPositiveCurrency = New System.Windows.Forms.TextBox()
        Me.textBoxNegativeCurrency = New System.Windows.Forms.TextBox()
        Me.labelNegativeCurrency = New System.Windows.Forms.Label()
        Me.labelPositiveCurrency = New System.Windows.Forms.Label()
        Me.tabPageTime = New System.Windows.Forms.TabPage()
        Me.comboBoxAM = New System.Windows.Forms.ComboBox()
        Me.comboBoxPM = New System.Windows.Forms.ComboBox()
        Me.comboBoxFormat = New System.Windows.Forms.ComboBox()
        Me.labelPM = New System.Windows.Forms.Label()
        Me.labelAM = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBoxSampleTime = New System.Windows.Forms.GroupBox()
        Me.textBoxSample = New System.Windows.Forms.TextBox()
        Me.labelSample = New System.Windows.Forms.Label()
        Me.tabPageDate = New System.Windows.Forms.TabPage()
        Me.groupBoxLongDate = New System.Windows.Forms.GroupBox()
        Me.comboBoxLongDateFormat = New System.Windows.Forms.ComboBox()
        Me.labelLongDateFormat = New System.Windows.Forms.Label()
        Me.textBoxLongDate = New System.Windows.Forms.TextBox()
        Me.labelLongDate = New System.Windows.Forms.Label()
        Me.groupBoxShortDate = New System.Windows.Forms.GroupBox()
        Me.comboBoxDateSeparator = New System.Windows.Forms.ComboBox()
        Me.comboBoxShortDateFormat = New System.Windows.Forms.ComboBox()
        Me.labelDateSeparator = New System.Windows.Forms.Label()
        Me.labelShortDateFormat = New System.Windows.Forms.Label()
        Me.textBoxShortDate = New System.Windows.Forms.TextBox()
        Me.labelShortDate = New System.Windows.Forms.Label()
        Me.buttonOk = New System.Windows.Forms.Button()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.tabControlMain.SuspendLayout()
        Me.tabPageNumber.SuspendLayout()
        Me.groupBoxSample.SuspendLayout()
        Me.tabPageCurrency.SuspendLayout()
        Me.groupBoxCurrencySample.SuspendLayout()
        Me.tabPageTime.SuspendLayout()
        Me.groupBoxSampleTime.SuspendLayout()
        Me.tabPageDate.SuspendLayout()
        Me.groupBoxLongDate.SuspendLayout()
        Me.groupBoxShortDate.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' tabControlMain
        ' 
        Me.tabControlMain.Controls.Add(Me.tabPageNumber)
        Me.tabControlMain.Controls.Add(Me.tabPageCurrency)
        Me.tabControlMain.Controls.Add(Me.tabPageTime)
        Me.tabControlMain.Controls.Add(Me.tabPageDate)
        Me.tabControlMain.Location = New System.Drawing.Point(7, 14)
        Me.tabControlMain.Name = "tabControlMain"
        Me.tabControlMain.SelectedIndex = 0
        Me.tabControlMain.Size = New System.Drawing.Size(402, 346)
        Me.tabControlMain.TabIndex = 0
        ' 
        ' tabPageNumber
        ' 
        Me.tabPageNumber.BackColor = System.Drawing.SystemColors.Window
        Me.tabPageNumber.Controls.Add(Me.comboBoxSeparator)
        Me.tabPageNumber.Controls.Add(Me.comboBoxNegativeNumber)
        Me.tabPageNumber.Controls.Add(Me.comboBoxDigits)
        Me.tabPageNumber.Controls.Add(Me.comboBoxNegativeSign)
        Me.tabPageNumber.Controls.Add(Me.comboBoxGrouping)
        Me.tabPageNumber.Controls.Add(Me.comboBoxSymbol)
        Me.tabPageNumber.Controls.Add(Me.labelSeparator)
        Me.tabPageNumber.Controls.Add(Me.labelNegativeNumber)
        Me.tabPageNumber.Controls.Add(Me.labelNegativeSign)
        Me.tabPageNumber.Controls.Add(Me.labelGrouping)
        Me.tabPageNumber.Controls.Add(Me.labelDigits)
        Me.tabPageNumber.Controls.Add(Me.labelSymbol)
        Me.tabPageNumber.Controls.Add(Me.groupBoxSample)
        Me.tabPageNumber.Location = New System.Drawing.Point(4, 22)
        Me.tabPageNumber.Name = "tabPageNumber"
        Me.tabPageNumber.Size = New System.Drawing.Size(394, 320)
        Me.tabPageNumber.TabIndex = 0
        Me.tabPageNumber.Text = "Number"
        ' 
        ' comboBoxSeparator
        ' 
        Me.comboBoxSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxSeparator.Location = New System.Drawing.Point(201, 248)
        Me.comboBoxSeparator.Name = "comboBoxSeparator"
        Me.comboBoxSeparator.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxSeparator.TabIndex = 13
        ' 
        ' comboBoxNegativeNumber
        ' 
        Me.comboBoxNegativeNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxNegativeNumber.Location = New System.Drawing.Point(201, 196)
        Me.comboBoxNegativeNumber.Name = "comboBoxNegativeNumber"
        Me.comboBoxNegativeNumber.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxNegativeNumber.TabIndex = 12
        ' 
        ' comboBoxDigits
        ' 
        Me.comboBoxDigits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxDigits.Location = New System.Drawing.Point(201, 118)
        Me.comboBoxDigits.Name = "comboBoxDigits"
        Me.comboBoxDigits.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxDigits.TabIndex = 9
        ' 
        ' comboBoxNegativeSign
        ' 
        Me.comboBoxNegativeSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxNegativeSign.Location = New System.Drawing.Point(201, 170)
        Me.comboBoxNegativeSign.Name = "comboBoxNegativeSign"
        Me.comboBoxNegativeSign.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxNegativeSign.TabIndex = 11
        ' 
        ' comboBoxGrouping
        ' 
        Me.comboBoxGrouping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxGrouping.Location = New System.Drawing.Point(201, 144)
        Me.comboBoxGrouping.Name = "comboBoxGrouping"
        Me.comboBoxGrouping.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxGrouping.TabIndex = 10
        ' 
        ' comboBoxSymbol
        ' 
        Me.comboBoxSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxSymbol.Location = New System.Drawing.Point(201, 92)
        Me.comboBoxSymbol.Name = "comboBoxSymbol"
        Me.comboBoxSymbol.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxSymbol.TabIndex = 8
        ' 
        ' labelSeparator
        ' 
        Me.labelSeparator.Location = New System.Drawing.Point(36, 248)
        Me.labelSeparator.Name = "labelSeparator"
        Me.labelSeparator.Size = New System.Drawing.Size(136, 23)
        Me.labelSeparator.TabIndex = 7
        Me.labelSeparator.Text = "List separator:"
        ' 
        ' labelNegativeNumber
        ' 
        Me.labelNegativeNumber.Location = New System.Drawing.Point(36, 196)
        Me.labelNegativeNumber.Name = "labelNegativeNumber"
        Me.labelNegativeNumber.Size = New System.Drawing.Size(136, 23)
        Me.labelNegativeNumber.TabIndex = 5
        Me.labelNegativeNumber.Text = "Negative number format:"
        ' 
        ' labelNegativeSign
        ' 
        Me.labelNegativeSign.Location = New System.Drawing.Point(36, 170)
        Me.labelNegativeSign.Name = "labelNegativeSign"
        Me.labelNegativeSign.Size = New System.Drawing.Size(136, 23)
        Me.labelNegativeSign.TabIndex = 4
        Me.labelNegativeSign.Text = "Negative sign symbol:"
        ' 
        ' labelGrouping
        ' 
        Me.labelGrouping.Location = New System.Drawing.Point(36, 144)
        Me.labelGrouping.Name = "labelGrouping"
        Me.labelGrouping.Size = New System.Drawing.Size(136, 23)
        Me.labelGrouping.TabIndex = 3
        Me.labelGrouping.Text = "Digit grouping:"
        ' 
        ' labelDigits
        ' 
        Me.labelDigits.Location = New System.Drawing.Point(36, 118)
        Me.labelDigits.Name = "labelDigits"
        Me.labelDigits.Size = New System.Drawing.Size(136, 23)
        Me.labelDigits.TabIndex = 2
        Me.labelDigits.Text = "No. of digits after decimal:"
        ' 
        ' labelSymbol
        ' 
        Me.labelSymbol.Location = New System.Drawing.Point(36, 92)
        Me.labelSymbol.Name = "labelSymbol"
        Me.labelSymbol.Size = New System.Drawing.Size(136, 23)
        Me.labelSymbol.TabIndex = 1
        Me.labelSymbol.Text = "Decimal symbol:"
        ' 
        ' groupBoxSample
        ' 
        Me.groupBoxSample.Controls.Add(Me.textBoxPositive)
        Me.groupBoxSample.Controls.Add(Me.textBoxNegative)
        Me.groupBoxSample.Controls.Add(Me.labelNegative)
        Me.groupBoxSample.Controls.Add(Me.labelPositive)
        Me.groupBoxSample.Location = New System.Drawing.Point(11, 4)
        Me.groupBoxSample.Name = "groupBoxSample"
        Me.groupBoxSample.Size = New System.Drawing.Size(370, 71)
        Me.groupBoxSample.TabIndex = 0
        Me.groupBoxSample.TabStop = False
        Me.groupBoxSample.Text = "Sample"
        ' 
        ' textBoxPositive
        ' 
        Me.textBoxPositive.Location = New System.Drawing.Point(53, 28)
        Me.textBoxPositive.Name = "textBoxPositive"
        Me.textBoxPositive.ReadOnly = True
        Me.textBoxPositive.Size = New System.Drawing.Size(123, 20)
        Me.textBoxPositive.TabIndex = 3
        ' 
        ' textBoxNegative
        ' 
        Me.textBoxNegative.Location = New System.Drawing.Point(239, 28)
        Me.textBoxNegative.Name = "textBoxNegative"
        Me.textBoxNegative.ReadOnly = True
        Me.textBoxNegative.Size = New System.Drawing.Size(123, 20)
        Me.textBoxNegative.TabIndex = 4
        ' 
        ' labelNegative
        ' 
        Me.labelNegative.Location = New System.Drawing.Point(188, 28)
        Me.labelNegative.Name = "labelNegative"
        Me.labelNegative.TabIndex = 1
        Me.labelNegative.Text = "Negative:"
        ' 
        ' labelPositive
        ' 
        Me.labelPositive.Location = New System.Drawing.Point(4, 28)
        Me.labelPositive.Name = "labelPositive"
        Me.labelPositive.TabIndex = 0
        Me.labelPositive.Text = "Positive:"
        ' 
        ' tabPageCurrency
        ' 
        Me.tabPageCurrency.BackColor = System.Drawing.SystemColors.Window
        Me.tabPageCurrency.Controls.Add(Me.comboBoxGroupingCurrency)
        Me.tabPageCurrency.Controls.Add(Me.comboBoxDecimalDigits)
        Me.tabPageCurrency.Controls.Add(Me.comboBoxPositive)
        Me.tabPageCurrency.Controls.Add(Me.comboBoxDecimal)
        Me.tabPageCurrency.Controls.Add(Me.comboBoxNegative)
        Me.tabPageCurrency.Controls.Add(Me.comboBoxCurrencySymbol)
        Me.tabPageCurrency.Controls.Add(Me.labelGroupingCurrency)
        Me.tabPageCurrency.Controls.Add(Me.labelDecimalDigits)
        Me.tabPageCurrency.Controls.Add(Me.labelDecimal)
        Me.tabPageCurrency.Controls.Add(Me.labelNegCurrency)
        Me.tabPageCurrency.Controls.Add(Me.labelPosCurrency)
        Me.tabPageCurrency.Controls.Add(Me.labelSymbolCurrency)
        Me.tabPageCurrency.Controls.Add(Me.groupBoxCurrencySample)
        Me.tabPageCurrency.Location = New System.Drawing.Point(4, 22)
        Me.tabPageCurrency.Name = "tabPageCurrency"
        Me.tabPageCurrency.Size = New System.Drawing.Size(394, 320)
        Me.tabPageCurrency.TabIndex = 1
        Me.tabPageCurrency.Text = "Currency"
        ' 
        ' comboBoxGroupingCurrency
        ' 
        Me.comboBoxGroupingCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxGroupingCurrency.Location = New System.Drawing.Point(201, 247)
        Me.comboBoxGroupingCurrency.Name = "comboBoxGroupingCurrency"
        Me.comboBoxGroupingCurrency.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxGroupingCurrency.TabIndex = 28
        ' 
        ' comboBoxDecimalDigits
        ' 
        Me.comboBoxDecimalDigits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxDecimalDigits.Location = New System.Drawing.Point(201, 206)
        Me.comboBoxDecimalDigits.Name = "comboBoxDecimalDigits"
        Me.comboBoxDecimalDigits.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxDecimalDigits.TabIndex = 26
        ' 
        ' comboBoxPositive
        ' 
        Me.comboBoxPositive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxPositive.Location = New System.Drawing.Point(201, 116)
        Me.comboBoxPositive.Name = "comboBoxPositive"
        Me.comboBoxPositive.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxPositive.TabIndex = 23
        ' 
        ' comboBoxDecimal
        ' 
        Me.comboBoxDecimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxDecimal.Location = New System.Drawing.Point(201, 180)
        Me.comboBoxDecimal.Name = "comboBoxDecimal"
        Me.comboBoxDecimal.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxDecimal.TabIndex = 25
        ' 
        ' comboBoxNegative
        ' 
        Me.comboBoxNegative.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxNegative.Location = New System.Drawing.Point(201, 142)
        Me.comboBoxNegative.Name = "comboBoxNegative"
        Me.comboBoxNegative.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxNegative.TabIndex = 24
        ' 
        ' comboBoxCurrencySymbol
        ' 
        Me.comboBoxCurrencySymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxCurrencySymbol.Location = New System.Drawing.Point(201, 90)
        Me.comboBoxCurrencySymbol.Name = "comboBoxCurrencySymbol"
        Me.comboBoxCurrencySymbol.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxCurrencySymbol.TabIndex = 22
        ' 
        ' labelGroupingCurrency
        ' 
        Me.labelGroupingCurrency.Location = New System.Drawing.Point(36, 247)
        Me.labelGroupingCurrency.Name = "labelGroupingCurrency"
        Me.labelGroupingCurrency.Size = New System.Drawing.Size(136, 23)
        Me.labelGroupingCurrency.TabIndex = 21
        Me.labelGroupingCurrency.Text = "Digit grouping: "
        ' 
        ' labelDecimalDigits
        ' 
        Me.labelDecimalDigits.Location = New System.Drawing.Point(36, 206)
        Me.labelDecimalDigits.Name = "labelDecimalDigits"
        Me.labelDecimalDigits.Size = New System.Drawing.Size(136, 23)
        Me.labelDecimalDigits.TabIndex = 19
        Me.labelDecimalDigits.Text = "No. of digits after decimal:"
        ' 
        ' labelDecimal
        ' 
        Me.labelDecimal.Location = New System.Drawing.Point(36, 180)
        Me.labelDecimal.Name = "labelDecimal"
        Me.labelDecimal.Size = New System.Drawing.Size(136, 23)
        Me.labelDecimal.TabIndex = 18
        Me.labelDecimal.Text = "Decimal symbol:"
        ' 
        ' labelNegCurrency
        ' 
        Me.labelNegCurrency.Location = New System.Drawing.Point(36, 142)
        Me.labelNegCurrency.Name = "labelNegCurrency"
        Me.labelNegCurrency.Size = New System.Drawing.Size(136, 23)
        Me.labelNegCurrency.TabIndex = 17
        Me.labelNegCurrency.Text = "Negative currency:"
        ' 
        ' labelPosCurrency
        ' 
        Me.labelPosCurrency.Location = New System.Drawing.Point(36, 116)
        Me.labelPosCurrency.Name = "labelPosCurrency"
        Me.labelPosCurrency.Size = New System.Drawing.Size(136, 23)
        Me.labelPosCurrency.TabIndex = 16
        Me.labelPosCurrency.Text = "Positive currency:"
        ' 
        ' labelSymbolCurrency
        ' 
        Me.labelSymbolCurrency.Location = New System.Drawing.Point(36, 90)
        Me.labelSymbolCurrency.Name = "labelSymbolCurrency"
        Me.labelSymbolCurrency.Size = New System.Drawing.Size(136, 23)
        Me.labelSymbolCurrency.TabIndex = 15
        Me.labelSymbolCurrency.Text = "Currency symbol:"
        ' 
        ' groupBoxCurrencySample
        ' 
        Me.groupBoxCurrencySample.Controls.Add(Me.textBoxPositiveCurrency)
        Me.groupBoxCurrencySample.Controls.Add(Me.textBoxNegativeCurrency)
        Me.groupBoxCurrencySample.Controls.Add(Me.labelNegativeCurrency)
        Me.groupBoxCurrencySample.Controls.Add(Me.labelPositiveCurrency)
        Me.groupBoxCurrencySample.Location = New System.Drawing.Point(11, 4)
        Me.groupBoxCurrencySample.Name = "groupBoxCurrencySample"
        Me.groupBoxCurrencySample.Size = New System.Drawing.Size(370, 71)
        Me.groupBoxCurrencySample.TabIndex = 1
        Me.groupBoxCurrencySample.TabStop = False
        Me.groupBoxCurrencySample.Text = "Sample"
        ' 
        ' textBoxPositiveCurrency
        ' 
        Me.textBoxPositiveCurrency.Location = New System.Drawing.Point(53, 28)
        Me.textBoxPositiveCurrency.Name = "textBoxPositiveCurrency"
        Me.textBoxPositiveCurrency.ReadOnly = True
        Me.textBoxPositiveCurrency.Size = New System.Drawing.Size(123, 20)
        Me.textBoxPositiveCurrency.TabIndex = 3
        ' 
        ' textBoxNegativeCurrency
        ' 
        Me.textBoxNegativeCurrency.Location = New System.Drawing.Point(239, 28)
        Me.textBoxNegativeCurrency.Name = "textBoxNegativeCurrency"
        Me.textBoxNegativeCurrency.ReadOnly = True
        Me.textBoxNegativeCurrency.Size = New System.Drawing.Size(123, 20)
        Me.textBoxNegativeCurrency.TabIndex = 4
        ' 
        ' labelNegativeCurrency
        ' 
        Me.labelNegativeCurrency.Location = New System.Drawing.Point(188, 28)
        Me.labelNegativeCurrency.Name = "labelNegativeCurrency"
        Me.labelNegativeCurrency.TabIndex = 1
        Me.labelNegativeCurrency.Text = "Negative:"
        ' 
        ' labelPositiveCurrency
        ' 
        Me.labelPositiveCurrency.Location = New System.Drawing.Point(4, 28)
        Me.labelPositiveCurrency.Name = "labelPositiveCurrency"
        Me.labelPositiveCurrency.TabIndex = 0
        Me.labelPositiveCurrency.Text = "Positive:"
        ' 
        ' tabPageTime
        ' 
        Me.tabPageTime.BackColor = System.Drawing.SystemColors.Window
        Me.tabPageTime.Controls.Add(Me.comboBoxAM)
        Me.tabPageTime.Controls.Add(Me.comboBoxPM)
        Me.tabPageTime.Controls.Add(Me.comboBoxFormat)
        Me.tabPageTime.Controls.Add(Me.labelPM)
        Me.tabPageTime.Controls.Add(Me.labelAM)
        Me.tabPageTime.Controls.Add(Me.label1)
        Me.tabPageTime.Controls.Add(Me.groupBoxSampleTime)
        Me.tabPageTime.Location = New System.Drawing.Point(4, 22)
        Me.tabPageTime.Name = "tabPageTime"
        Me.tabPageTime.Size = New System.Drawing.Size(394, 320)
        Me.tabPageTime.TabIndex = 2
        Me.tabPageTime.Text = "Time"
        ' 
        ' comboBoxAM
        ' 
        Me.comboBoxAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxAM.Location = New System.Drawing.Point(104, 142)
        Me.comboBoxAM.Name = "comboBoxAM"
        Me.comboBoxAM.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxAM.TabIndex = 31
        ' 
        ' comboBoxPM
        ' 
        Me.comboBoxPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxPM.Location = New System.Drawing.Point(104, 186)
        Me.comboBoxPM.Name = "comboBoxPM"
        Me.comboBoxPM.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxPM.TabIndex = 32
        ' 
        ' comboBoxFormat
        ' 
        Me.comboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxFormat.Location = New System.Drawing.Point(104, 98)
        Me.comboBoxFormat.Name = "comboBoxFormat"
        Me.comboBoxFormat.Size = New System.Drawing.Size(144, 21)
        Me.comboBoxFormat.TabIndex = 29
        ' 
        ' labelPM
        ' 
        Me.labelPM.Location = New System.Drawing.Point(22, 181)
        Me.labelPM.Name = "labelPM"
        Me.labelPM.Size = New System.Drawing.Size(136, 23)
        Me.labelPM.TabIndex = 28
        Me.labelPM.Text = "PM:"
        ' 
        ' labelAM
        ' 
        Me.labelAM.Location = New System.Drawing.Point(22, 141)
        Me.labelAM.Name = "labelAM"
        Me.labelAM.Size = New System.Drawing.Size(136, 23)
        Me.labelAM.TabIndex = 27
        Me.labelAM.Text = "AM:"
        ' 
        ' label1
        ' 
        Me.label1.Location = New System.Drawing.Point(22, 101)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(136, 23)
        Me.label1.TabIndex = 26
        Me.label1.Text = "Time format:"
        ' 
        ' groupBoxSampleTime
        ' 
        Me.groupBoxSampleTime.Controls.Add(Me.textBoxSample)
        Me.groupBoxSampleTime.Controls.Add(Me.labelSample)
        Me.groupBoxSampleTime.Location = New System.Drawing.Point(11, 4)
        Me.groupBoxSampleTime.Name = "groupBoxSampleTime"
        Me.groupBoxSampleTime.Size = New System.Drawing.Size(370, 71)
        Me.groupBoxSampleTime.TabIndex = 2
        Me.groupBoxSampleTime.TabStop = False
        Me.groupBoxSampleTime.Text = "Sample"
        ' 
        ' textBoxSample
        ' 
        Me.textBoxSample.Location = New System.Drawing.Point(97, 28)
        Me.textBoxSample.Name = "textBoxSample"
        Me.textBoxSample.ReadOnly = True
        Me.textBoxSample.Size = New System.Drawing.Size(123, 20)
        Me.textBoxSample.TabIndex = 3
        ' 
        ' labelSample
        ' 
        Me.labelSample.Location = New System.Drawing.Point(4, 28)
        Me.labelSample.Name = "labelSample"
        Me.labelSample.TabIndex = 0
        Me.labelSample.Text = "Time sample:"
        ' 
        ' tabPageDate
        ' 
        Me.tabPageDate.BackColor = System.Drawing.SystemColors.Window
        Me.tabPageDate.Controls.Add(Me.groupBoxLongDate)
        Me.tabPageDate.Controls.Add(Me.groupBoxShortDate)
        Me.tabPageDate.Location = New System.Drawing.Point(4, 22)
        Me.tabPageDate.Name = "tabPageDate"
        Me.tabPageDate.Size = New System.Drawing.Size(394, 320)
        Me.tabPageDate.TabIndex = 3
        Me.tabPageDate.Text = "Date"
        ' 
        ' groupBoxLongDate
        ' 
        Me.groupBoxLongDate.Controls.Add(Me.comboBoxLongDateFormat)
        Me.groupBoxLongDate.Controls.Add(Me.labelLongDateFormat)
        Me.groupBoxLongDate.Controls.Add(Me.textBoxLongDate)
        Me.groupBoxLongDate.Controls.Add(Me.labelLongDate)
        Me.groupBoxLongDate.Location = New System.Drawing.Point(12, 158)
        Me.groupBoxLongDate.Name = "groupBoxLongDate"
        Me.groupBoxLongDate.Size = New System.Drawing.Size(370, 97)
        Me.groupBoxLongDate.TabIndex = 4
        Me.groupBoxLongDate.TabStop = False
        Me.groupBoxLongDate.Text = "Long Date"
        ' 
        ' comboBoxLongDateFormat
        ' 
        Me.comboBoxLongDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxLongDateFormat.Location = New System.Drawing.Point(140, 50)
        Me.comboBoxLongDateFormat.Name = "comboBoxLongDateFormat"
        Me.comboBoxLongDateFormat.Size = New System.Drawing.Size(170, 21)
        Me.comboBoxLongDateFormat.TabIndex = 18
        ' 
        ' labelLongDateFormat
        ' 
        Me.labelLongDateFormat.Location = New System.Drawing.Point(9, 52)
        Me.labelLongDateFormat.Name = "labelLongDateFormat"
        Me.labelLongDateFormat.Size = New System.Drawing.Size(136, 23)
        Me.labelLongDateFormat.TabIndex = 17
        Me.labelLongDateFormat.Text = "Long date format"
        ' 
        ' textBoxLongDate
        ' 
        Me.textBoxLongDate.Location = New System.Drawing.Point(140, 19)
        Me.textBoxLongDate.Name = "textBoxLongDate"
        Me.textBoxLongDate.ReadOnly = True
        Me.textBoxLongDate.Size = New System.Drawing.Size(170, 20)
        Me.textBoxLongDate.TabIndex = 16
        ' 
        ' labelLongDate
        ' 
        Me.labelLongDate.Location = New System.Drawing.Point(9, 25)
        Me.labelLongDate.Name = "labelLongDate"
        Me.labelLongDate.TabIndex = 15
        Me.labelLongDate.Text = "Long date sample:"
        ' 
        ' groupBoxShortDate
        ' 
        Me.groupBoxShortDate.Controls.Add(Me.comboBoxDateSeparator)
        Me.groupBoxShortDate.Controls.Add(Me.comboBoxShortDateFormat)
        Me.groupBoxShortDate.Controls.Add(Me.labelDateSeparator)
        Me.groupBoxShortDate.Controls.Add(Me.labelShortDateFormat)
        Me.groupBoxShortDate.Controls.Add(Me.textBoxShortDate)
        Me.groupBoxShortDate.Controls.Add(Me.labelShortDate)
        Me.groupBoxShortDate.Location = New System.Drawing.Point(11, 4)
        Me.groupBoxShortDate.Name = "groupBoxShortDate"
        Me.groupBoxShortDate.Size = New System.Drawing.Size(370, 132)
        Me.groupBoxShortDate.TabIndex = 3
        Me.groupBoxShortDate.TabStop = False
        Me.groupBoxShortDate.Text = "Short date"
        ' 
        ' comboBoxDateSeparator
        ' 
        Me.comboBoxDateSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxDateSeparator.Location = New System.Drawing.Point(142, 84)
        Me.comboBoxDateSeparator.Name = "comboBoxDateSeparator"
        Me.comboBoxDateSeparator.Size = New System.Drawing.Size(77, 21)
        Me.comboBoxDateSeparator.TabIndex = 15
        ' 
        ' comboBoxShortDateFormat
        ' 
        Me.comboBoxShortDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxShortDateFormat.Location = New System.Drawing.Point(142, 53)
        Me.comboBoxShortDateFormat.Name = "comboBoxShortDateFormat"
        Me.comboBoxShortDateFormat.Size = New System.Drawing.Size(170, 21)
        Me.comboBoxShortDateFormat.TabIndex = 14
        ' 
        ' labelDateSeparator
        ' 
        Me.labelDateSeparator.Location = New System.Drawing.Point(4, 84)
        Me.labelDateSeparator.Name = "labelDateSeparator"
        Me.labelDateSeparator.Size = New System.Drawing.Size(136, 23)
        Me.labelDateSeparator.TabIndex = 13
        Me.labelDateSeparator.Text = "Date separator:"
        ' 
        ' labelShortDateFormat
        ' 
        Me.labelShortDateFormat.Location = New System.Drawing.Point(4, 56)
        Me.labelShortDateFormat.Name = "labelShortDateFormat"
        Me.labelShortDateFormat.Size = New System.Drawing.Size(136, 23)
        Me.labelShortDateFormat.TabIndex = 12
        Me.labelShortDateFormat.Text = "Short date format"
        ' 
        ' textBoxShortDate
        ' 
        Me.textBoxShortDate.Location = New System.Drawing.Point(142, 24)
        Me.textBoxShortDate.Name = "textBoxShortDate"
        Me.textBoxShortDate.ReadOnly = True
        Me.textBoxShortDate.Size = New System.Drawing.Size(170, 20)
        Me.textBoxShortDate.TabIndex = 3
        ' 
        ' labelShortDate
        ' 
        Me.labelShortDate.Location = New System.Drawing.Point(4, 28)
        Me.labelShortDate.Name = "labelShortDate"
        Me.labelShortDate.TabIndex = 0
        Me.labelShortDate.Text = "Short date sample:"
        ' 
        ' buttonOk
        ' 
        Me.buttonOk.Location = New System.Drawing.Point(248, 374)
        Me.buttonOk.Name = "buttonOk"
        Me.buttonOk.TabIndex = 40
        Me.buttonOk.Text = "OK"
        ' 
        ' buttonCancel
        ' 
        Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancel.Location = New System.Drawing.Point(334, 374)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.TabIndex = 42
        Me.buttonCancel.Text = "Cancel"
        ' 
        ' CultureOptions
        ' 
        Me.AcceptButton = Me.buttonOk
        Me.CancelButton = Me.buttonCancel
        Me.ClientSize = New System.Drawing.Size(415, 406)
        Me.Controls.Add(buttonCancel)
        Me.Controls.Add(buttonOk)
        Me.Controls.Add(tabControlMain)
        Me.Name = "CultureOptions"
        Me.Text = "Culture Options"
        Me.tabControlMain.ResumeLayout(False)
        Me.tabPageNumber.ResumeLayout(False)
        Me.groupBoxSample.ResumeLayout(False)
        Me.groupBoxSample.PerformLayout()
        Me.tabPageCurrency.ResumeLayout(False)
        Me.groupBoxCurrencySample.ResumeLayout(False)
        Me.groupBoxCurrencySample.PerformLayout()
        Me.tabPageTime.ResumeLayout(False)
        Me.groupBoxSampleTime.ResumeLayout(False)
        Me.groupBoxSampleTime.PerformLayout()
        Me.tabPageDate.ResumeLayout(False)
        Me.groupBoxLongDate.ResumeLayout(False)
        Me.groupBoxLongDate.PerformLayout()
        Me.groupBoxShortDate.ResumeLayout(False)
        Me.groupBoxShortDate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent 
#End Region


    Private Sub buttonOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonOk.Click
        SaveCulture()
        Me.Close()

    End Sub 'buttonOk_Click


    Private Sub buttonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonCancel.Click
        Me.Close()

    End Sub 'buttonCancel_Click


    '*
    '		 * Method to fill the fields appropriately for a new Culture
    '		 
    Public Overloads Sub SetFields()
        comboBoxSymbol.Items.AddRange(New String() {Constants.Dot, Constants.Comma})

        'Adding all the digits
        Dim i As Integer

        While i <= 9
            comboBoxDigits.Items.Add(i.ToString(CultureInfo.CurrentUICulture))
            comboBoxDecimalDigits.Items.Add(i.ToString(CultureInfo.CurrentUICulture))
            i += 1
        End While

        'Number tab
        comboBoxGrouping.Items.AddRange(New String() {Constants.Comma, Constants.Space})
        comboBoxNegativeSign.Items.AddRange(New String() {Constants.Hyphen})
        comboBoxNegativeNumber.Items.Add(Constants.GetNumberFormat(False, Constants.Minus, Constants.SampleNumber)(0))
        comboBoxNegativeNumber.Items.AddRange(Constants.GetNumberFormat(True, Constants.Minus, Constants.SampleNumber))
        comboBoxSeparator.Items.AddRange(New String() {Constants.Comma, Constants.SemiColon})

        'Currency tab
        comboBoxCurrencySymbol.Items.AddRange(New String() {Constants.Dollar, "", "z"})
        comboBoxPositive.Items.AddRange(Constants.GetNumberFormat(True, Constants.Dollar, Constants.SampleNumber))
        comboBoxNegative.Items.AddRange(Constants.GetNumberFormat(False, Constants.Dollar, Constants.SampleNumber))
        comboBoxDecimal.Items.AddRange(New String() {Constants.Dot, Constants.Comma})
        comboBoxGroupingCurrency.Items.AddRange(Constants.NumberGroupFormats)

        'Date tab
        comboBoxFormat.Items.AddRange(Constants.TimeFormats)
        comboBoxAM.Items.AddRange(New String() {"AM", Constants.Space})
        comboBoxPM.Items.AddRange(New String() {"PM", Constants.Space})

        'Time tab
        comboBoxShortDateFormat.Items.AddRange(Constants.ShortDateFormats)
        comboBoxDateSeparator.Items.AddRange(New String() {Constants.Slash, Constants.Hyphen, Constants.Dot})
        comboBoxLongDateFormat.Items.AddRange(Constants.LongDateFormats)

        SetSamples(CultureInfo.CurrentCulture)
        SelectItems()

    End Sub 'SetFields


    '*
    '		 * Method to fill the fields appropriately for a mixed Culture
    '		 
    Public Overloads Sub SetFields(ByVal loc1 As String, ByVal loc2 As String)
        locale1 = loc1
        locale2 = loc2
        SetSamples(CultureInfo.CurrentCulture)

        Dim ci1 As New CultureInfo(locale1, False)
        Dim ci2 As New CultureInfo(locale2, False)

        Dim nfi1 As NumberFormatInfo = ci1.NumberFormat
        Dim nfi2 As NumberFormatInfo = ci2.NumberFormat
        Dim posInt As Int64 = Constants.LongNumber

        'Number tab
        comboBoxSymbol.Items.Add(nfi1.NumberDecimalSeparator)
        comboBoxSymbol.Items.Add(nfi2.NumberDecimalSeparator)
        comboBoxDigits.Items.Add(nfi1.NumberDecimalDigits)
        comboBoxDigits.Items.Add(nfi2.NumberDecimalDigits)
        comboBoxGrouping.Items.Add(posInt.ToString(Constants.NumberFormat, nfi1))
        comboBoxGrouping.Items.Add(posInt.ToString(Constants.NumberFormat, nfi2))
        comboBoxNegativeSign.Items.Add(nfi1.NegativeSign)
        comboBoxNegativeSign.Items.Add(nfi2.NegativeSign)
        posInt = -posInt
        comboBoxNegativeNumber.Items.Add(posInt.ToString(Constants.NumberFormat, nfi1))
        comboBoxNegativeNumber.Items.Add(posInt.ToString(Constants.NumberFormat, nfi2))
        comboBoxSeparator.Items.Add(nfi1.NumberGroupSeparator)
        comboBoxSeparator.Items.Add(nfi2.NumberGroupSeparator)

        'Currency tab
        comboBoxCurrencySymbol.Items.Add(nfi1.CurrencySymbol)
        comboBoxCurrencySymbol.Items.Add(nfi2.CurrencySymbol)
        Dim curr As [Double] = 1.1
        comboBoxPositive.Items.Add(curr.ToString(Constants.CurrencyFormat, nfi1))
        comboBoxPositive.Items.Add(curr.ToString(Constants.CurrencyFormat, nfi2))
        curr = -curr
        comboBoxNegative.Items.Add(curr.ToString(Constants.CurrencyFormat, nfi1))
        comboBoxNegative.Items.Add(curr.ToString(Constants.CurrencyFormat, nfi2))

        comboBoxDecimal.Items.Add(nfi1.CurrencyDecimalSeparator.ToString(CultureInfo.CurrentUICulture))
        comboBoxDecimal.Items.Add(nfi2.CurrencyDecimalSeparator.ToString(CultureInfo.CurrentUICulture))
        comboBoxDecimalDigits.Items.Add(nfi1.CurrencyDecimalDigits.ToString(CultureInfo.CurrentUICulture))
        comboBoxDecimalDigits.Items.Add(nfi2.CurrencyDecimalDigits.ToString(CultureInfo.CurrentUICulture))
        posInt = -posInt
        comboBoxGroupingCurrency.Items.Add(posInt.ToString(Constants.CurrencyFormat, nfi1))
        comboBoxGroupingCurrency.Items.Add(posInt.ToString(Constants.CurrencyFormat, nfi2))

        'Time tab
        Dim dfi1 As DateTimeFormatInfo = ci1.DateTimeFormat
        Dim dfi2 As DateTimeFormatInfo = ci2.DateTimeFormat

        comboBoxFormat.Items.Add(dfi1.LongTimePattern)
        comboBoxFormat.Items.Add(dfi2.LongTimePattern)
        comboBoxAM.Items.Add(dfi1.AMDesignator)
        comboBoxAM.Items.Add(dfi2.AMDesignator)
        comboBoxPM.Items.Add(dfi1.PMDesignator)
        comboBoxPM.Items.Add(dfi2.PMDesignator)

        'Date tab
        comboBoxShortDateFormat.Items.Add(dfi1.ShortDatePattern)
        comboBoxShortDateFormat.Items.Add(dfi2.ShortDatePattern)
        comboBoxDateSeparator.Items.Add(dfi1.DateSeparator)
        comboBoxDateSeparator.Items.Add(dfi2.DateSeparator)
        comboBoxLongDateFormat.Items.Add(dfi1.LongDatePattern)
        comboBoxLongDateFormat.Items.Add(dfi2.LongDatePattern)

        SelectItems()

    End Sub 'SetFields


    Private Sub SelectItems()
        Dim i As Integer = 0
        comboBoxAM.SelectedIndex = i
        comboBoxCurrencySymbol.SelectedIndex = i
        comboBoxDateSeparator.SelectedIndex = i
        comboBoxDecimal.SelectedIndex = i
        comboBoxDecimalDigits.SelectedIndex = i
        comboBoxDigits.SelectedIndex = i
        comboBoxFormat.SelectedIndex = i
        comboBoxGrouping.SelectedIndex = i
        comboBoxGroupingCurrency.SelectedIndex = i
        comboBoxLongDateFormat.SelectedIndex = i
        comboBoxNegative.SelectedIndex = i
        comboBoxNegativeNumber.SelectedIndex = i
        comboBoxNegativeSign.SelectedIndex = i
        comboBoxPM.SelectedIndex = i
        comboBoxPositive.SelectedIndex = i
        comboBoxSeparator.SelectedIndex = i
        comboBoxShortDateFormat.SelectedIndex = i
        comboBoxSymbol.SelectedIndex = i

    End Sub 'SelectItems


    '*
    '		 * Method to set samples for the current UICulture
    '		 
    Private Sub SetSamples(ByVal ci As CultureInfo)
        Dim posInt As Int64 = Constants.LongNumber

        textBoxPositive.Text = posInt.ToString(Constants.NumberFormat, ci)
        textBoxPositiveCurrency.Text = posInt.ToString(Constants.CurrencyFormat, ci)
        posInt = -posInt
        textBoxNegative.Text = posInt.ToString(Constants.NumberFormat, ci)
        textBoxNegativeCurrency.Text = posInt.ToString(Constants.CurrencyFormat, ci)

        Dim dt As DateTime = DateTime.Now
        textBoxShortDate.Text = dt.ToString(Constants.ShortDateFormat, ci)
        textBoxLongDate.Text = dt.ToString(Constants.LongDateFormat, ci)
        textBoxSample.Text = dt.ToString(Constants.TimeFormat, ci)

    End Sub 'SetSamples


    '*
    '		 * Save the newly created culture
    '		 
    Private Sub SaveCulture()
        Dim nfi As New NumberFormatInfo()
        Dim dfi As New DateTimeFormatInfo()

        nfi.NumberDecimalSeparator = comboBoxSymbol.SelectedItem.ToString()
        nfi.NumberDecimalDigits = Int32.Parse(comboBoxDigits.SelectedItem.ToString(), CultureInfo.CurrentUICulture)
        nfi.NegativeSign = comboBoxNegativeSign.SelectedItem.ToString()
        nfi.NumberGroupSeparator = comboBoxSeparator.SelectedItem.ToString()

        nfi.CurrencySymbol = comboBoxCurrencySymbol.SelectedItem.ToString()
        nfi.CurrencyDecimalSeparator = comboBoxDecimal.SelectedItem.ToString()
        nfi.CurrencyDecimalDigits = Int32.Parse(comboBoxDecimalDigits.SelectedItem.ToString(), CultureInfo.CurrentUICulture)


        dfi.LongTimePattern = comboBoxFormat.SelectedItem.ToString()
        dfi.AMDesignator = comboBoxAM.SelectedItem.ToString()
        dfi.PMDesignator = comboBoxPM.SelectedItem.ToString()

        dfi.ShortDatePattern = comboBoxShortDateFormat.SelectedItem.ToString()
        dfi.DateSeparator = comboBoxDateSeparator.SelectedItem.ToString()
        dfi.LongDatePattern = comboBoxLongDateFormat.SelectedItem.ToString()

        'Save fields specific to particular mixed cultures and new cultures
        Dim name As String = language + Constants.Hyphen + regionName
        If Not (locale1 Is Nothing) Then 'Mix culture
            SaveForMixCulture(nfi)
            helper.GetNewCultureInfo(nfi, dfi, locale1, name)
            'New culture
        Else
            SaveForNewCulture(nfi)
            helper.GetNewCultureInfo(nfi, dfi, CultureInfo.InvariantCulture.Name, name)
        End If

    End Sub 'SaveCulture
    
    
    Private Sub SaveForMixCulture(ByVal nfi As NumberFormatInfo) 
        Dim ci1 As New CultureInfo(locale1)
        Dim ci2 As New CultureInfo(locale2)
        
        'Select the index and set from the corresponding culture
        nfi.CurrencyPositivePattern = IIf(comboBoxPositive.SelectedIndex = 0, ci1.NumberFormat.CurrencyPositivePattern, ci2.NumberFormat.CurrencyPositivePattern) 'TODO: For performance reasons this should be changed to nested IF statements
        
        nfi.CurrencyNegativePattern = IIf(comboBoxNegative.SelectedIndex = 0, ci1.NumberFormat.CurrencyNegativePattern, ci2.NumberFormat.CurrencyNegativePattern) 'TODO: For performance reasons this should be changed to nested IF statements
        
        nfi.NumberNegativePattern = IIf(comboBoxNegativeNumber.SelectedIndex = 0, ci1.NumberFormat.NumberNegativePattern, ci2.NumberFormat.NumberNegativePattern) 'TODO: For performance reasons this should be changed to nested IF statements
    
    End Sub 'SaveForMixCulture
    
    
    Private Sub SaveForNewCulture(ByVal nfi As NumberFormatInfo) 
        'Hard coded group sizes and Patterns
        nfi.NumberNegativePattern = comboBoxNegativeNumber.SelectedIndex
        nfi.NumberGroupSizes = ParseGroupString(comboBoxGrouping.SelectedIndex)
        
        nfi.CurrencyPositivePattern = comboBoxPositive.SelectedIndex
        nfi.CurrencyNegativePattern = comboBoxNegative.SelectedIndex
        nfi.CurrencyGroupSizes = ParseGroupString(comboBoxGroupingCurrency.SelectedIndex)
    
    End Sub 'SaveForNewCulture
    
    
    
    '*
'		 * Method to get array sizes
'		 
    Private Function ParseGroupString(ByVal index As Integer) As Integer() 
        Dim NumberGroupSizes As Integer()() =  {New Integer() {0}, New Integer() {3}, New Integer() {3, 2}}
        Return NumberGroupSizes(index)
    
    End Function 'ParseGroupString
End Class 'CultureOptions