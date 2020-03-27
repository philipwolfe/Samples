'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
	Friend WithEvents lblMaxValue As System.Windows.Forms.Label
	Friend WithEvents lblMinValue As System.Windows.Forms.Label
	Friend WithEvents lblUtcNow As System.Windows.Forms.Label
	Friend WithEvents lblToday As System.Windows.Forms.Label
	Friend WithEvents lblNow As System.Windows.Forms.Label
	Friend WithEvents lblFromOADate As System.Windows.Forms.Label
	Friend WithEvents lblIsLeapYear As System.Windows.Forms.Label
	Friend WithEvents lblDaysInMonth As System.Windows.Forms.Label
	Friend WithEvents txtMonth As System.Windows.Forms.TextBox
	Friend WithEvents txtFromOADate As System.Windows.Forms.TextBox
	Friend WithEvents txtIsLeapYear As System.Windows.Forms.TextBox
	Friend WithEvents txtYear As System.Windows.Forms.TextBox
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents btnRefreshShared As System.Windows.Forms.Button
	Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
	Friend WithEvents txtYears As System.Windows.Forms.TextBox
	Friend WithEvents txtTicks As System.Windows.Forms.TextBox
	Friend WithEvents txtSeconds As System.Windows.Forms.TextBox
	Friend WithEvents txtMonths As System.Windows.Forms.TextBox
	Friend WithEvents txtMinutes As System.Windows.Forms.TextBox
	Friend WithEvents txtMilliseconds As System.Windows.Forms.TextBox
	Friend WithEvents txtHours As System.Windows.Forms.TextBox
	Friend WithEvents txtDays As System.Windows.Forms.TextBox
	Friend WithEvents btnRefreshCalculation As System.Windows.Forms.Button
	Friend WithEvents lblAddSeconds As System.Windows.Forms.Label
	Friend WithEvents lblAddMonths As System.Windows.Forms.Label
	Friend WithEvents lblAddMinutes As System.Windows.Forms.Label
	Friend WithEvents lblAddMilliseconds As System.Windows.Forms.Label
	Friend WithEvents lblAddHours As System.Windows.Forms.Label
	Friend WithEvents lblAddDays As System.Windows.Forms.Label
	Friend WithEvents lblAddTicks As System.Windows.Forms.Label
	Friend WithEvents lblAddYears As System.Windows.Forms.Label
	Friend WithEvents lblNow3 As System.Windows.Forms.Label
	Friend WithEvents Label49 As System.Windows.Forms.Label
	Friend WithEvents Label50 As System.Windows.Forms.Label
	Friend WithEvents Label51 As System.Windows.Forms.Label
	Friend WithEvents Label52 As System.Windows.Forms.Label
	Friend WithEvents Label53 As System.Windows.Forms.Label
	Friend WithEvents Label54 As System.Windows.Forms.Label
	Friend WithEvents Label55 As System.Windows.Forms.Label
	Friend WithEvents Label56 As System.Windows.Forms.Label
	Friend WithEvents Label57 As System.Windows.Forms.Label
	Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
	Friend WithEvents lblMillisecond As System.Windows.Forms.Label
	Friend WithEvents lblHour As System.Windows.Forms.Label
	Friend WithEvents lblDayOfYear As System.Windows.Forms.Label
	Friend WithEvents lblDayOfWeek As System.Windows.Forms.Label
	Friend WithEvents lblDate As System.Windows.Forms.Label
	Friend WithEvents lblDay As System.Windows.Forms.Label
	Friend WithEvents lblMinute As System.Windows.Forms.Label
	Friend WithEvents lblMonth As System.Windows.Forms.Label
	Friend WithEvents lblSecond As System.Windows.Forms.Label
	Friend WithEvents lblTicks As System.Windows.Forms.Label
	Friend WithEvents lblYear As System.Windows.Forms.Label
	Friend WithEvents lblTimeOfDay As System.Windows.Forms.Label
	Friend WithEvents lblNow1 As System.Windows.Forms.Label
	Friend WithEvents Label21 As System.Windows.Forms.Label
	Friend WithEvents Label20 As System.Windows.Forms.Label
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents Label18 As System.Windows.Forms.Label
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents Label16 As System.Windows.Forms.Label
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents Label14 As System.Windows.Forms.Label
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents Label12 As System.Windows.Forms.Label
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents Label10 As System.Windows.Forms.Label
	Friend WithEvents btnRefreshProperties As System.Windows.Forms.Button
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
	Friend WithEvents lblToShortDateString As System.Windows.Forms.Label
	Friend WithEvents lblToOADate As System.Windows.Forms.Label
	Friend WithEvents lblToLongTimeString As System.Windows.Forms.Label
	Friend WithEvents lblToLongDateString As System.Windows.Forms.Label
	Friend WithEvents lblToLocalTime As System.Windows.Forms.Label
	Friend WithEvents lblToFileTime As System.Windows.Forms.Label
	Friend WithEvents lblToShortTimeString As System.Windows.Forms.Label
	Friend WithEvents lblToString As System.Windows.Forms.Label
	Friend WithEvents lblToUniversalTime As System.Windows.Forms.Label
	Friend WithEvents Label38 As System.Windows.Forms.Label
	Friend WithEvents Label39 As System.Windows.Forms.Label
	Friend WithEvents Label40 As System.Windows.Forms.Label
	Friend WithEvents Label41 As System.Windows.Forms.Label
	Friend WithEvents Label42 As System.Windows.Forms.Label
	Friend WithEvents Label43 As System.Windows.Forms.Label
	Friend WithEvents Label44 As System.Windows.Forms.Label
	Friend WithEvents Label45 As System.Windows.Forms.Label
	Friend WithEvents Label46 As System.Windows.Forms.Label
	Friend WithEvents lblNow2 As System.Windows.Forms.Label
	Friend WithEvents btnRefreshConversion As System.Windows.Forms.Button
	Friend WithEvents Label23 As System.Windows.Forms.Label
	Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
	Friend WithEvents lblTotalSeconds As System.Windows.Forms.Label
	Friend WithEvents Label61 As System.Windows.Forms.Label
	Friend WithEvents lblTotalMinutes As System.Windows.Forms.Label
	Friend WithEvents Label62 As System.Windows.Forms.Label
	Friend WithEvents lblTotalMilliseconds As System.Windows.Forms.Label
	Friend WithEvents Label63 As System.Windows.Forms.Label
	Friend WithEvents lblTotalHours As System.Windows.Forms.Label
	Friend WithEvents Label64 As System.Windows.Forms.Label
	Friend WithEvents lblTotalDays As System.Windows.Forms.Label
	Friend WithEvents Label65 As System.Windows.Forms.Label
	Friend WithEvents lblTimeSpanTicks As System.Windows.Forms.Label
	Friend WithEvents Label67 As System.Windows.Forms.Label
	Friend WithEvents lblSeconds As System.Windows.Forms.Label
	Friend WithEvents Label68 As System.Windows.Forms.Label
	Friend WithEvents lblMinutes As System.Windows.Forms.Label
	Friend WithEvents Label69 As System.Windows.Forms.Label
	Friend WithEvents lblMilliseconds As System.Windows.Forms.Label
	Friend WithEvents Label70 As System.Windows.Forms.Label
	Friend WithEvents lblHours As System.Windows.Forms.Label
	Friend WithEvents Label71 As System.Windows.Forms.Label
	Friend WithEvents lblDays As System.Windows.Forms.Label
	Friend WithEvents Label72 As System.Windows.Forms.Label
	Friend WithEvents tabTimeSpan As System.Windows.Forms.TabControl
	Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
	Friend WithEvents btnRefreshTSProperties As System.Windows.Forms.Button
	Friend WithEvents Label28 As System.Windows.Forms.Label
	Friend WithEvents Label31 As System.Windows.Forms.Label
	Friend WithEvents txtEnd As System.Windows.Forms.TextBox
	Friend WithEvents txtStart As System.Windows.Forms.TextBox
	Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
	Friend WithEvents btnCalcParse As System.Windows.Forms.Button
	Friend WithEvents txtParse As System.Windows.Forms.TextBox
	Friend WithEvents Label33 As System.Windows.Forms.Label
	Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
	Friend WithEvents btnRefreshTSMethods As System.Windows.Forms.Button
	Friend WithEvents txtFromHours As System.Windows.Forms.TextBox
	Friend WithEvents lblFromHours As System.Windows.Forms.Label
	Friend WithEvents Label34 As System.Windows.Forms.Label
	Friend WithEvents txtFromSeconds As System.Windows.Forms.TextBox
	Friend WithEvents lblFromSeconds As System.Windows.Forms.Label
	Friend WithEvents Label35 As System.Windows.Forms.Label
	Friend WithEvents txtFromTicks As System.Windows.Forms.TextBox
	Friend WithEvents lblFromTicks As System.Windows.Forms.Label
	Friend WithEvents Label36 As System.Windows.Forms.Label
	Friend WithEvents txtFromMilliseconds As System.Windows.Forms.TextBox
	Friend WithEvents lblFromMilliseconds As System.Windows.Forms.Label
	Friend WithEvents Label37 As System.Windows.Forms.Label
	Friend WithEvents txtFromMinutes As System.Windows.Forms.TextBox
	Friend WithEvents lblFromMinutes As System.Windows.Forms.Label
	Friend WithEvents Label47 As System.Windows.Forms.Label
	Friend WithEvents txtFromDays As System.Windows.Forms.TextBox
	Friend WithEvents lblFromDays As System.Windows.Forms.Label
	Friend WithEvents Label48 As System.Windows.Forms.Label
	Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
	Friend WithEvents lblZero As System.Windows.Forms.Label
	Friend WithEvents Label22 As System.Windows.Forms.Label
	Friend WithEvents lblTicksPerSecond As System.Windows.Forms.Label
	Friend WithEvents Label25 As System.Windows.Forms.Label
	Friend WithEvents lblTicksPerMinute As System.Windows.Forms.Label
	Friend WithEvents Label27 As System.Windows.Forms.Label
	Friend WithEvents lblTicksPerMillisecond As System.Windows.Forms.Label
	Friend WithEvents Label29 As System.Windows.Forms.Label
	Friend WithEvents lblTicksPerHour As System.Windows.Forms.Label
	Friend WithEvents Label24 As System.Windows.Forms.Label
	Friend WithEvents lblTicksPerDay As System.Windows.Forms.Label
	Friend WithEvents Label26 As System.Windows.Forms.Label
	Friend WithEvents lblMinValueTS As System.Windows.Forms.Label
	Friend WithEvents Label30 As System.Windows.Forms.Label
	Friend WithEvents lblMaxValueTS As System.Windows.Forms.Label
	Friend WithEvents Label32 As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblMaxValue = New System.Windows.Forms.Label()
        Me.lblMinValue = New System.Windows.Forms.Label()
        Me.lblUtcNow = New System.Windows.Forms.Label()
        Me.lblToday = New System.Windows.Forms.Label()
        Me.lblNow = New System.Windows.Forms.Label()
        Me.lblFromOADate = New System.Windows.Forms.Label()
        Me.lblIsLeapYear = New System.Windows.Forms.Label()
        Me.lblDaysInMonth = New System.Windows.Forms.Label()
        Me.txtMonth = New System.Windows.Forms.TextBox()
        Me.txtFromOADate = New System.Windows.Forms.TextBox()
        Me.txtIsLeapYear = New System.Windows.Forms.TextBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefreshShared = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtYears = New System.Windows.Forms.TextBox()
        Me.txtTicks = New System.Windows.Forms.TextBox()
        Me.txtSeconds = New System.Windows.Forms.TextBox()
        Me.txtMonths = New System.Windows.Forms.TextBox()
        Me.txtMinutes = New System.Windows.Forms.TextBox()
        Me.txtMilliseconds = New System.Windows.Forms.TextBox()
        Me.txtHours = New System.Windows.Forms.TextBox()
        Me.txtDays = New System.Windows.Forms.TextBox()
        Me.btnRefreshCalculation = New System.Windows.Forms.Button()
        Me.lblAddSeconds = New System.Windows.Forms.Label()
        Me.lblAddMonths = New System.Windows.Forms.Label()
        Me.lblAddMinutes = New System.Windows.Forms.Label()
        Me.lblAddMilliseconds = New System.Windows.Forms.Label()
        Me.lblAddHours = New System.Windows.Forms.Label()
        Me.lblAddDays = New System.Windows.Forms.Label()
        Me.lblAddTicks = New System.Windows.Forms.Label()
        Me.lblAddYears = New System.Windows.Forms.Label()
        Me.lblNow3 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblMillisecond = New System.Windows.Forms.Label()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.lblDayOfYear = New System.Windows.Forms.Label()
        Me.lblDayOfWeek = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblMinute = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblSecond = New System.Windows.Forms.Label()
        Me.lblTicks = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblTimeOfDay = New System.Windows.Forms.Label()
        Me.lblNow1 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnRefreshProperties = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblToShortDateString = New System.Windows.Forms.Label()
        Me.lblToOADate = New System.Windows.Forms.Label()
        Me.lblToLongTimeString = New System.Windows.Forms.Label()
        Me.lblToLongDateString = New System.Windows.Forms.Label()
        Me.lblToLocalTime = New System.Windows.Forms.Label()
        Me.lblToFileTime = New System.Windows.Forms.Label()
        Me.lblToShortTimeString = New System.Windows.Forms.Label()
        Me.lblToString = New System.Windows.Forms.Label()
        Me.lblToUniversalTime = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.lblNow2 = New System.Windows.Forms.Label()
        Me.btnRefreshConversion = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.lblTotalSeconds = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.lblTotalMinutes = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.lblTotalMilliseconds = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.lblTotalHours = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.lblTotalDays = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.lblTimeSpanTicks = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.lblSeconds = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.lblMinutes = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.lblMilliseconds = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.lblHours = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.lblDays = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.tabTimeSpan = New System.Windows.Forms.TabControl()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.btnRefreshTSProperties = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtEnd = New System.Windows.Forms.TextBox()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.btnCalcParse = New System.Windows.Forms.Button()
        Me.txtParse = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.btnRefreshTSMethods = New System.Windows.Forms.Button()
        Me.txtFromHours = New System.Windows.Forms.TextBox()
        Me.lblFromHours = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtFromSeconds = New System.Windows.Forms.TextBox()
        Me.lblFromSeconds = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtFromTicks = New System.Windows.Forms.TextBox()
        Me.lblFromTicks = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtFromMilliseconds = New System.Windows.Forms.TextBox()
        Me.lblFromMilliseconds = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtFromMinutes = New System.Windows.Forms.TextBox()
        Me.lblFromMinutes = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtFromDays = New System.Windows.Forms.TextBox()
        Me.lblFromDays = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.lblZero = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblTicksPerSecond = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblTicksPerMinute = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblTicksPerMillisecond = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblTicksPerHour = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblTicksPerDay = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblMinValueTS = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblMaxValueTS = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.tabTimeSpan.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.TabPage10.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 0
        Me.mnuExit.Text = "E&xit"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage4, Me.TabPage2, Me.TabPage3, Me.TabPage6, Me.TabPage7, Me.TabPage5})
        Me.TabControl1.ItemSize = New System.Drawing.Size(92, 18)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(600, 304)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMaxValue, Me.lblMinValue, Me.lblUtcNow, Me.lblToday, Me.lblNow, Me.lblFromOADate, Me.lblIsLeapYear, Me.lblDaysInMonth, Me.txtMonth, Me.txtFromOADate, Me.txtIsLeapYear, Me.txtYear, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.btnRefreshShared})
        Me.TabPage1.Location = New System.Drawing.Point(4, 40)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(592, 260)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DateTime Shared Members"
        '
        'lblMaxValue
        '
        Me.lblMaxValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMaxValue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMaxValue.Location = New System.Drawing.Point(136, 128)
        Me.lblMaxValue.Name = "lblMaxValue"
        Me.lblMaxValue.Size = New System.Drawing.Size(200, 23)
        Me.lblMaxValue.TabIndex = 20
        Me.lblMaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMinValue
        '
        Me.lblMinValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinValue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMinValue.Location = New System.Drawing.Point(136, 104)
        Me.lblMinValue.Name = "lblMinValue"
        Me.lblMinValue.Size = New System.Drawing.Size(200, 23)
        Me.lblMinValue.TabIndex = 19
        Me.lblMinValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUtcNow
        '
        Me.lblUtcNow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUtcNow.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUtcNow.Location = New System.Drawing.Point(136, 80)
        Me.lblUtcNow.Name = "lblUtcNow"
        Me.lblUtcNow.Size = New System.Drawing.Size(200, 23)
        Me.lblUtcNow.TabIndex = 18
        Me.lblUtcNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToday
        '
        Me.lblToday.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToday.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToday.Location = New System.Drawing.Point(136, 56)
        Me.lblToday.Name = "lblToday"
        Me.lblToday.Size = New System.Drawing.Size(200, 23)
        Me.lblToday.TabIndex = 17
        Me.lblToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNow
        '
        Me.lblNow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNow.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNow.Location = New System.Drawing.Point(136, 32)
        Me.lblNow.Name = "lblNow"
        Me.lblNow.Size = New System.Drawing.Size(200, 23)
        Me.lblNow.TabIndex = 16
        Me.lblNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFromOADate
        '
        Me.lblFromOADate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFromOADate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFromOADate.Location = New System.Drawing.Point(264, 224)
        Me.lblFromOADate.Name = "lblFromOADate"
        Me.lblFromOADate.Size = New System.Drawing.Size(200, 23)
        Me.lblFromOADate.TabIndex = 15
        Me.lblFromOADate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIsLeapYear
        '
        Me.lblIsLeapYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIsLeapYear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIsLeapYear.Location = New System.Drawing.Point(264, 200)
        Me.lblIsLeapYear.Name = "lblIsLeapYear"
        Me.lblIsLeapYear.Size = New System.Drawing.Size(200, 23)
        Me.lblIsLeapYear.TabIndex = 14
        Me.lblIsLeapYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDaysInMonth
        '
        Me.lblDaysInMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDaysInMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDaysInMonth.Location = New System.Drawing.Point(264, 176)
        Me.lblDaysInMonth.Name = "lblDaysInMonth"
        Me.lblDaysInMonth.Size = New System.Drawing.Size(200, 23)
        Me.lblDaysInMonth.TabIndex = 13
        Me.lblDaysInMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(232, 176)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(24, 20)
        Me.txtMonth.TabIndex = 12
        Me.txtMonth.Text = "2"
        '
        'txtFromOADate
        '
        Me.txtFromOADate.Location = New System.Drawing.Point(136, 224)
        Me.txtFromOADate.Name = "txtFromOADate"
        Me.txtFromOADate.Size = New System.Drawing.Size(88, 20)
        Me.txtFromOADate.TabIndex = 11
        Me.txtFromOADate.Text = "36578.325"
        '
        'txtIsLeapYear
        '
        Me.txtIsLeapYear.Location = New System.Drawing.Point(136, 200)
        Me.txtIsLeapYear.Name = "txtIsLeapYear"
        Me.txtIsLeapYear.Size = New System.Drawing.Size(88, 20)
        Me.txtIsLeapYear.TabIndex = 10
        Me.txtIsLeapYear.Text = "2002"
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(136, 176)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(88, 20)
        Me.txtYear.TabIndex = 9
        Me.txtYear.Text = "2002"
        '
        'Label8
        '
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(16, 224)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "FromOADate"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(16, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "IsLeapYear"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(16, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "DaysInMonth"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(16, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "MaxValue"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(16, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "MinValue"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(16, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "UtcNow"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Today"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Now"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRefreshShared
        '
        Me.btnRefreshShared.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefreshShared.Location = New System.Drawing.Point(16, 8)
        Me.btnRefreshShared.Name = "btnRefreshShared"
        Me.btnRefreshShared.Size = New System.Drawing.Size(75, 24)
        Me.btnRefreshShared.TabIndex = 0
        Me.btnRefreshShared.Text = "&Refresh"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtYears, Me.txtTicks, Me.txtSeconds, Me.txtMonths, Me.txtMinutes, Me.txtMilliseconds, Me.txtHours, Me.txtDays, Me.btnRefreshCalculation, Me.lblAddSeconds, Me.lblAddMonths, Me.lblAddMinutes, Me.lblAddMilliseconds, Me.lblAddHours, Me.lblAddDays, Me.lblAddTicks, Me.lblAddYears, Me.lblNow3, Me.Label49, Me.Label50, Me.Label51, Me.Label52, Me.Label53, Me.Label54, Me.Label55, Me.Label56, Me.Label57})
        Me.TabPage4.Location = New System.Drawing.Point(4, 40)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(592, 260)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "DateTime Calculation Methods"
        Me.TabPage4.Visible = False
        '
        'txtYears
        '
        Me.txtYears.Location = New System.Drawing.Point(136, 224)
        Me.txtYears.Name = "txtYears"
        Me.txtYears.Size = New System.Drawing.Size(48, 20)
        Me.txtYears.TabIndex = 64
        Me.txtYears.Text = "3"
        '
        'txtTicks
        '
        Me.txtTicks.Location = New System.Drawing.Point(136, 200)
        Me.txtTicks.Name = "txtTicks"
        Me.txtTicks.Size = New System.Drawing.Size(48, 20)
        Me.txtTicks.TabIndex = 63
        Me.txtTicks.Text = "3"
        '
        'txtSeconds
        '
        Me.txtSeconds.Location = New System.Drawing.Point(136, 176)
        Me.txtSeconds.Name = "txtSeconds"
        Me.txtSeconds.Size = New System.Drawing.Size(48, 20)
        Me.txtSeconds.TabIndex = 62
        Me.txtSeconds.Text = "3"
        '
        'txtMonths
        '
        Me.txtMonths.Location = New System.Drawing.Point(136, 152)
        Me.txtMonths.Name = "txtMonths"
        Me.txtMonths.Size = New System.Drawing.Size(48, 20)
        Me.txtMonths.TabIndex = 61
        Me.txtMonths.Text = "3"
        '
        'txtMinutes
        '
        Me.txtMinutes.Location = New System.Drawing.Point(136, 128)
        Me.txtMinutes.Name = "txtMinutes"
        Me.txtMinutes.Size = New System.Drawing.Size(48, 20)
        Me.txtMinutes.TabIndex = 60
        Me.txtMinutes.Text = "3"
        '
        'txtMilliseconds
        '
        Me.txtMilliseconds.Location = New System.Drawing.Point(136, 104)
        Me.txtMilliseconds.Name = "txtMilliseconds"
        Me.txtMilliseconds.Size = New System.Drawing.Size(48, 20)
        Me.txtMilliseconds.TabIndex = 59
        Me.txtMilliseconds.Text = "3"
        '
        'txtHours
        '
        Me.txtHours.Location = New System.Drawing.Point(136, 80)
        Me.txtHours.Name = "txtHours"
        Me.txtHours.Size = New System.Drawing.Size(48, 20)
        Me.txtHours.TabIndex = 58
        Me.txtHours.Text = "3"
        '
        'txtDays
        '
        Me.txtDays.Location = New System.Drawing.Point(136, 56)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Size = New System.Drawing.Size(48, 20)
        Me.txtDays.TabIndex = 57
        Me.txtDays.Text = "3"
        '
        'btnRefreshCalculation
        '
        Me.btnRefreshCalculation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefreshCalculation.Location = New System.Drawing.Point(16, 8)
        Me.btnRefreshCalculation.Name = "btnRefreshCalculation"
        Me.btnRefreshCalculation.Size = New System.Drawing.Size(75, 24)
        Me.btnRefreshCalculation.TabIndex = 56
        Me.btnRefreshCalculation.Text = "Refresh"
        '
        'lblAddSeconds
        '
        Me.lblAddSeconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddSeconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddSeconds.Location = New System.Drawing.Point(184, 176)
        Me.lblAddSeconds.Name = "lblAddSeconds"
        Me.lblAddSeconds.Size = New System.Drawing.Size(200, 23)
        Me.lblAddSeconds.TabIndex = 55
        Me.lblAddSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddMonths
        '
        Me.lblAddMonths.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddMonths.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddMonths.Location = New System.Drawing.Point(184, 152)
        Me.lblAddMonths.Name = "lblAddMonths"
        Me.lblAddMonths.Size = New System.Drawing.Size(200, 23)
        Me.lblAddMonths.TabIndex = 54
        Me.lblAddMonths.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddMinutes
        '
        Me.lblAddMinutes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddMinutes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddMinutes.Location = New System.Drawing.Point(184, 128)
        Me.lblAddMinutes.Name = "lblAddMinutes"
        Me.lblAddMinutes.Size = New System.Drawing.Size(200, 23)
        Me.lblAddMinutes.TabIndex = 53
        Me.lblAddMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddMilliseconds
        '
        Me.lblAddMilliseconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddMilliseconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddMilliseconds.Location = New System.Drawing.Point(184, 104)
        Me.lblAddMilliseconds.Name = "lblAddMilliseconds"
        Me.lblAddMilliseconds.Size = New System.Drawing.Size(200, 23)
        Me.lblAddMilliseconds.TabIndex = 52
        Me.lblAddMilliseconds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddHours
        '
        Me.lblAddHours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddHours.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddHours.Location = New System.Drawing.Point(184, 80)
        Me.lblAddHours.Name = "lblAddHours"
        Me.lblAddHours.Size = New System.Drawing.Size(200, 23)
        Me.lblAddHours.TabIndex = 51
        Me.lblAddHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddDays
        '
        Me.lblAddDays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddDays.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddDays.Location = New System.Drawing.Point(184, 56)
        Me.lblAddDays.Name = "lblAddDays"
        Me.lblAddDays.Size = New System.Drawing.Size(200, 23)
        Me.lblAddDays.TabIndex = 50
        Me.lblAddDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddTicks
        '
        Me.lblAddTicks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddTicks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddTicks.Location = New System.Drawing.Point(184, 200)
        Me.lblAddTicks.Name = "lblAddTicks"
        Me.lblAddTicks.Size = New System.Drawing.Size(200, 23)
        Me.lblAddTicks.TabIndex = 49
        Me.lblAddTicks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddYears
        '
        Me.lblAddYears.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAddYears.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddYears.Location = New System.Drawing.Point(184, 224)
        Me.lblAddYears.Name = "lblAddYears"
        Me.lblAddYears.Size = New System.Drawing.Size(200, 23)
        Me.lblAddYears.TabIndex = 48
        Me.lblAddYears.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNow3
        '
        Me.lblNow3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNow3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNow3.Location = New System.Drawing.Point(184, 32)
        Me.lblNow3.Name = "lblNow3"
        Me.lblNow3.Size = New System.Drawing.Size(200, 23)
        Me.lblNow3.TabIndex = 43
        Me.lblNow3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label49
        '
        Me.Label49.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label49.Location = New System.Drawing.Point(16, 224)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(112, 20)
        Me.Label49.TabIndex = 38
        Me.Label49.Text = "AddYears"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label50
        '
        Me.Label50.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label50.Location = New System.Drawing.Point(16, 200)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(112, 20)
        Me.Label50.TabIndex = 37
        Me.Label50.Text = "AddTicks"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label51
        '
        Me.Label51.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label51.Location = New System.Drawing.Point(16, 176)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(112, 20)
        Me.Label51.TabIndex = 36
        Me.Label51.Text = "AddSeconds"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label52
        '
        Me.Label52.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label52.Location = New System.Drawing.Point(16, 152)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(112, 20)
        Me.Label52.TabIndex = 35
        Me.Label52.Text = "AddMonths"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label53
        '
        Me.Label53.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label53.Location = New System.Drawing.Point(16, 128)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(112, 20)
        Me.Label53.TabIndex = 34
        Me.Label53.Text = "AddMinutes"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label54
        '
        Me.Label54.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label54.Location = New System.Drawing.Point(16, 104)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(112, 20)
        Me.Label54.TabIndex = 33
        Me.Label54.Text = "AddMilliseconds"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label55
        '
        Me.Label55.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label55.Location = New System.Drawing.Point(16, 80)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(112, 20)
        Me.Label55.TabIndex = 32
        Me.Label55.Text = "AddHours"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label56
        '
        Me.Label56.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label56.Location = New System.Drawing.Point(16, 56)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(112, 20)
        Me.Label56.TabIndex = 31
        Me.Label56.Text = "AddDays"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label57
        '
        Me.Label57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label57.Location = New System.Drawing.Point(16, 32)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(112, 20)
        Me.Label57.TabIndex = 30
        Me.Label57.Text = "Now"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMillisecond, Me.lblHour, Me.lblDayOfYear, Me.lblDayOfWeek, Me.lblDate, Me.lblDay, Me.lblMinute, Me.lblMonth, Me.lblSecond, Me.lblTicks, Me.lblYear, Me.lblTimeOfDay, Me.lblNow1, Me.Label21, Me.Label20, Me.Label19, Me.Label18, Me.Label17, Me.Label16, Me.Label15, Me.Label14, Me.Label13, Me.Label12, Me.Label11, Me.Label10, Me.btnRefreshProperties, Me.Label9})
        Me.TabPage2.Location = New System.Drawing.Point(4, 40)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(592, 260)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DateTime Properties"
        Me.TabPage2.Visible = False
        '
        'lblMillisecond
        '
        Me.lblMillisecond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMillisecond.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMillisecond.Location = New System.Drawing.Point(392, 32)
        Me.lblMillisecond.Name = "lblMillisecond"
        Me.lblMillisecond.Size = New System.Drawing.Size(136, 23)
        Me.lblMillisecond.TabIndex = 29
        Me.lblMillisecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHour
        '
        Me.lblHour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHour.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHour.Location = New System.Drawing.Point(136, 152)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(136, 23)
        Me.lblHour.TabIndex = 28
        Me.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDayOfYear
        '
        Me.lblDayOfYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDayOfYear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDayOfYear.Location = New System.Drawing.Point(136, 128)
        Me.lblDayOfYear.Name = "lblDayOfYear"
        Me.lblDayOfYear.Size = New System.Drawing.Size(136, 23)
        Me.lblDayOfYear.TabIndex = 27
        Me.lblDayOfYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDayOfWeek
        '
        Me.lblDayOfWeek.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDayOfWeek.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDayOfWeek.Location = New System.Drawing.Point(136, 104)
        Me.lblDayOfWeek.Name = "lblDayOfWeek"
        Me.lblDayOfWeek.Size = New System.Drawing.Size(136, 23)
        Me.lblDayOfWeek.TabIndex = 26
        Me.lblDayOfWeek.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDate
        '
        Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDate.Location = New System.Drawing.Point(136, 80)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(136, 23)
        Me.lblDate.TabIndex = 25
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDay
        '
        Me.lblDay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDay.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDay.Location = New System.Drawing.Point(136, 56)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(136, 23)
        Me.lblDay.TabIndex = 24
        Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMinute
        '
        Me.lblMinute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinute.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMinute.Location = New System.Drawing.Point(392, 56)
        Me.lblMinute.Name = "lblMinute"
        Me.lblMinute.Size = New System.Drawing.Size(136, 23)
        Me.lblMinute.TabIndex = 23
        Me.lblMinute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMonth
        '
        Me.lblMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMonth.Location = New System.Drawing.Point(392, 80)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(136, 23)
        Me.lblMonth.TabIndex = 22
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSecond
        '
        Me.lblSecond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSecond.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSecond.Location = New System.Drawing.Point(392, 104)
        Me.lblSecond.Name = "lblSecond"
        Me.lblSecond.Size = New System.Drawing.Size(136, 23)
        Me.lblSecond.TabIndex = 21
        Me.lblSecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTicks
        '
        Me.lblTicks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTicks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTicks.Location = New System.Drawing.Point(392, 128)
        Me.lblTicks.Name = "lblTicks"
        Me.lblTicks.Size = New System.Drawing.Size(136, 23)
        Me.lblTicks.TabIndex = 20
        Me.lblTicks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblYear
        '
        Me.lblYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblYear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblYear.Location = New System.Drawing.Point(392, 176)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(136, 23)
        Me.lblYear.TabIndex = 19
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTimeOfDay
        '
        Me.lblTimeOfDay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTimeOfDay.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTimeOfDay.Location = New System.Drawing.Point(392, 152)
        Me.lblTimeOfDay.Name = "lblTimeOfDay"
        Me.lblTimeOfDay.Size = New System.Drawing.Size(136, 23)
        Me.lblTimeOfDay.TabIndex = 18
        Me.lblTimeOfDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNow1
        '
        Me.lblNow1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNow1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNow1.Location = New System.Drawing.Point(136, 32)
        Me.lblNow1.Name = "lblNow1"
        Me.lblNow1.Size = New System.Drawing.Size(136, 23)
        Me.lblNow1.TabIndex = 17
        Me.lblNow1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(296, 176)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 20)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Year"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(296, 152)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 20)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "TimeOfDay"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(296, 128)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 20)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Ticks"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(296, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 20)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Second"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(296, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 20)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Month"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(296, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 20)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Minute"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(296, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 20)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Millisecond"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(40, 152)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 20)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Hour"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(40, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 20)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "DayOfYear"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(40, 104)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 20)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "DayOfWeek"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(40, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 20)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Day"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(40, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 20)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Date"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRefreshProperties
        '
        Me.btnRefreshProperties.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefreshProperties.Location = New System.Drawing.Point(16, 8)
        Me.btnRefreshProperties.Name = "btnRefreshProperties"
        Me.btnRefreshProperties.Size = New System.Drawing.Size(75, 24)
        Me.btnRefreshProperties.TabIndex = 3
        Me.btnRefreshProperties.Text = "Refresh"
        '
        'Label9
        '
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(40, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 20)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Now"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage3
        '
        Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblToShortDateString, Me.lblToOADate, Me.lblToLongTimeString, Me.lblToLongDateString, Me.lblToLocalTime, Me.lblToFileTime, Me.lblToShortTimeString, Me.lblToString, Me.lblToUniversalTime, Me.Label38, Me.Label39, Me.Label40, Me.Label41, Me.Label42, Me.Label43, Me.Label44, Me.Label45, Me.Label46, Me.lblNow2, Me.btnRefreshConversion, Me.Label23})
        Me.TabPage3.Location = New System.Drawing.Point(4, 40)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(592, 260)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "DateTime Conversion Methods"
        Me.TabPage3.Visible = False
        '
        'lblToShortDateString
        '
        Me.lblToShortDateString.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToShortDateString.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToShortDateString.Location = New System.Drawing.Point(416, 56)
        Me.lblToShortDateString.Name = "lblToShortDateString"
        Me.lblToShortDateString.Size = New System.Drawing.Size(160, 23)
        Me.lblToShortDateString.TabIndex = 53
        Me.lblToShortDateString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToOADate
        '
        Me.lblToOADate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToOADate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToOADate.Location = New System.Drawing.Point(416, 32)
        Me.lblToOADate.Name = "lblToOADate"
        Me.lblToOADate.Size = New System.Drawing.Size(160, 23)
        Me.lblToOADate.TabIndex = 52
        Me.lblToOADate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToLongTimeString
        '
        Me.lblToLongTimeString.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToLongTimeString.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToLongTimeString.Location = New System.Drawing.Point(136, 128)
        Me.lblToLongTimeString.Name = "lblToLongTimeString"
        Me.lblToLongTimeString.Size = New System.Drawing.Size(144, 23)
        Me.lblToLongTimeString.TabIndex = 51
        Me.lblToLongTimeString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToLongDateString
        '
        Me.lblToLongDateString.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToLongDateString.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToLongDateString.Location = New System.Drawing.Point(136, 104)
        Me.lblToLongDateString.Name = "lblToLongDateString"
        Me.lblToLongDateString.Size = New System.Drawing.Size(144, 23)
        Me.lblToLongDateString.TabIndex = 50
        Me.lblToLongDateString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToLocalTime
        '
        Me.lblToLocalTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToLocalTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToLocalTime.Location = New System.Drawing.Point(136, 80)
        Me.lblToLocalTime.Name = "lblToLocalTime"
        Me.lblToLocalTime.Size = New System.Drawing.Size(144, 23)
        Me.lblToLocalTime.TabIndex = 49
        Me.lblToLocalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToFileTime
        '
        Me.lblToFileTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToFileTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToFileTime.Location = New System.Drawing.Point(136, 56)
        Me.lblToFileTime.Name = "lblToFileTime"
        Me.lblToFileTime.Size = New System.Drawing.Size(144, 23)
        Me.lblToFileTime.TabIndex = 48
        Me.lblToFileTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToShortTimeString
        '
        Me.lblToShortTimeString.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToShortTimeString.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToShortTimeString.Location = New System.Drawing.Point(416, 80)
        Me.lblToShortTimeString.Name = "lblToShortTimeString"
        Me.lblToShortTimeString.Size = New System.Drawing.Size(160, 23)
        Me.lblToShortTimeString.TabIndex = 47
        Me.lblToShortTimeString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToString
        '
        Me.lblToString.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToString.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToString.Location = New System.Drawing.Point(416, 104)
        Me.lblToString.Name = "lblToString"
        Me.lblToString.Size = New System.Drawing.Size(160, 23)
        Me.lblToString.TabIndex = 46
        Me.lblToString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblToUniversalTime
        '
        Me.lblToUniversalTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblToUniversalTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToUniversalTime.Location = New System.Drawing.Point(416, 128)
        Me.lblToUniversalTime.Name = "lblToUniversalTime"
        Me.lblToUniversalTime.Size = New System.Drawing.Size(160, 23)
        Me.lblToUniversalTime.TabIndex = 45
        Me.lblToUniversalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(296, 128)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(112, 20)
        Me.Label38.TabIndex = 38
        Me.Label38.Text = "ToUniversalTime"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label39
        '
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(296, 104)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(112, 20)
        Me.Label39.TabIndex = 37
        Me.Label39.Text = "ToString"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label40.Location = New System.Drawing.Point(296, 80)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(112, 20)
        Me.Label40.TabIndex = 36
        Me.Label40.Text = "ToShortTimeString"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label41
        '
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(296, 56)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(112, 20)
        Me.Label41.TabIndex = 35
        Me.Label41.Text = "ToShortDateString"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label42
        '
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(296, 32)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(112, 20)
        Me.Label42.TabIndex = 34
        Me.Label42.Text = "ToOADate"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label43
        '
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(16, 128)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(112, 20)
        Me.Label43.TabIndex = 33
        Me.Label43.Text = "ToLongTimeString"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label44
        '
        Me.Label44.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label44.Location = New System.Drawing.Point(16, 104)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(112, 20)
        Me.Label44.TabIndex = 32
        Me.Label44.Text = "ToLongDateString"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label45.Location = New System.Drawing.Point(16, 80)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(112, 20)
        Me.Label45.TabIndex = 31
        Me.Label45.Text = "ToLocalTime"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label46
        '
        Me.Label46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label46.Location = New System.Drawing.Point(16, 56)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(112, 20)
        Me.Label46.TabIndex = 30
        Me.Label46.Text = "ToFileTime"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNow2
        '
        Me.lblNow2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNow2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNow2.Location = New System.Drawing.Point(136, 32)
        Me.lblNow2.Name = "lblNow2"
        Me.lblNow2.Size = New System.Drawing.Size(144, 23)
        Me.lblNow2.TabIndex = 20
        Me.lblNow2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRefreshConversion
        '
        Me.btnRefreshConversion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefreshConversion.Location = New System.Drawing.Point(16, 8)
        Me.btnRefreshConversion.Name = "btnRefreshConversion"
        Me.btnRefreshConversion.Size = New System.Drawing.Size(75, 24)
        Me.btnRefreshConversion.TabIndex = 19
        Me.btnRefreshConversion.Text = "Refresh"
        '
        'Label23
        '
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(16, 32)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 20)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "Now"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage6
        '
        Me.TabPage6.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTotalSeconds, Me.Label61, Me.lblTotalMinutes, Me.Label62, Me.lblTotalMilliseconds, Me.Label63, Me.lblTotalHours, Me.Label64, Me.lblTotalDays, Me.Label65, Me.lblTimeSpanTicks, Me.Label67, Me.lblSeconds, Me.Label68, Me.lblMinutes, Me.Label69, Me.lblMilliseconds, Me.Label70, Me.lblHours, Me.Label71, Me.lblDays, Me.Label72, Me.tabTimeSpan})
        Me.TabPage6.Location = New System.Drawing.Point(4, 40)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(592, 260)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "TimeSpan Properties"
        Me.TabPage6.Visible = False
        '
        'lblTotalSeconds
        '
        Me.lblTotalSeconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalSeconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalSeconds.Location = New System.Drawing.Point(376, 232)
        Me.lblTotalSeconds.Name = "lblTotalSeconds"
        Me.lblTotalSeconds.Size = New System.Drawing.Size(136, 23)
        Me.lblTotalSeconds.TabIndex = 50
        Me.lblTotalSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label61
        '
        Me.Label61.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label61.Location = New System.Drawing.Point(272, 232)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(96, 20)
        Me.Label61.TabIndex = 49
        Me.Label61.Text = "TotalSeconds"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalMinutes
        '
        Me.lblTotalMinutes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalMinutes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalMinutes.Location = New System.Drawing.Point(376, 208)
        Me.lblTotalMinutes.Name = "lblTotalMinutes"
        Me.lblTotalMinutes.Size = New System.Drawing.Size(136, 23)
        Me.lblTotalMinutes.TabIndex = 48
        Me.lblTotalMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label62
        '
        Me.Label62.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label62.Location = New System.Drawing.Point(272, 208)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(96, 20)
        Me.Label62.TabIndex = 47
        Me.Label62.Text = "TotalMinutes"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalMilliseconds
        '
        Me.lblTotalMilliseconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalMilliseconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalMilliseconds.Location = New System.Drawing.Point(376, 184)
        Me.lblTotalMilliseconds.Name = "lblTotalMilliseconds"
        Me.lblTotalMilliseconds.Size = New System.Drawing.Size(136, 23)
        Me.lblTotalMilliseconds.TabIndex = 46
        Me.lblTotalMilliseconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label63
        '
        Me.Label63.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label63.Location = New System.Drawing.Point(272, 184)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(96, 20)
        Me.Label63.TabIndex = 45
        Me.Label63.Text = "TotalMilliseconds"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalHours
        '
        Me.lblTotalHours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalHours.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalHours.Location = New System.Drawing.Point(376, 160)
        Me.lblTotalHours.Name = "lblTotalHours"
        Me.lblTotalHours.Size = New System.Drawing.Size(136, 23)
        Me.lblTotalHours.TabIndex = 44
        Me.lblTotalHours.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label64
        '
        Me.Label64.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label64.Location = New System.Drawing.Point(272, 160)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(96, 20)
        Me.Label64.TabIndex = 43
        Me.Label64.Text = "TotalHours"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalDays
        '
        Me.lblTotalDays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalDays.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalDays.Location = New System.Drawing.Point(376, 136)
        Me.lblTotalDays.Name = "lblTotalDays"
        Me.lblTotalDays.Size = New System.Drawing.Size(136, 23)
        Me.lblTotalDays.TabIndex = 42
        Me.lblTotalDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label65
        '
        Me.Label65.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label65.Location = New System.Drawing.Point(272, 136)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(96, 20)
        Me.Label65.TabIndex = 41
        Me.Label65.Text = "TotalDays"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTimeSpanTicks
        '
        Me.lblTimeSpanTicks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTimeSpanTicks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTimeSpanTicks.Location = New System.Drawing.Point(376, 112)
        Me.lblTimeSpanTicks.Name = "lblTimeSpanTicks"
        Me.lblTimeSpanTicks.Size = New System.Drawing.Size(136, 23)
        Me.lblTimeSpanTicks.TabIndex = 40
        Me.lblTimeSpanTicks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label67
        '
        Me.Label67.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label67.Location = New System.Drawing.Point(272, 112)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(96, 20)
        Me.Label67.TabIndex = 39
        Me.Label67.Text = "Ticks"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSeconds
        '
        Me.lblSeconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSeconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSeconds.Location = New System.Drawing.Point(120, 208)
        Me.lblSeconds.Name = "lblSeconds"
        Me.lblSeconds.Size = New System.Drawing.Size(136, 23)
        Me.lblSeconds.TabIndex = 38
        Me.lblSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label68
        '
        Me.Label68.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label68.Location = New System.Drawing.Point(16, 208)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(96, 20)
        Me.Label68.TabIndex = 37
        Me.Label68.Text = "Seconds"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMinutes
        '
        Me.lblMinutes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinutes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMinutes.Location = New System.Drawing.Point(120, 184)
        Me.lblMinutes.Name = "lblMinutes"
        Me.lblMinutes.Size = New System.Drawing.Size(136, 23)
        Me.lblMinutes.TabIndex = 36
        Me.lblMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label69
        '
        Me.Label69.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label69.Location = New System.Drawing.Point(16, 184)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(96, 20)
        Me.Label69.TabIndex = 35
        Me.Label69.Text = "Minutes"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMilliseconds
        '
        Me.lblMilliseconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMilliseconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMilliseconds.Location = New System.Drawing.Point(120, 160)
        Me.lblMilliseconds.Name = "lblMilliseconds"
        Me.lblMilliseconds.Size = New System.Drawing.Size(136, 23)
        Me.lblMilliseconds.TabIndex = 34
        Me.lblMilliseconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label70
        '
        Me.Label70.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label70.Location = New System.Drawing.Point(16, 160)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(96, 20)
        Me.Label70.TabIndex = 33
        Me.Label70.Text = "Milliseconds"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHours
        '
        Me.lblHours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHours.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHours.Location = New System.Drawing.Point(120, 136)
        Me.lblHours.Name = "lblHours"
        Me.lblHours.Size = New System.Drawing.Size(136, 23)
        Me.lblHours.TabIndex = 32
        Me.lblHours.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label71
        '
        Me.Label71.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label71.Location = New System.Drawing.Point(16, 136)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(96, 20)
        Me.Label71.TabIndex = 31
        Me.Label71.Text = "Hours"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDays
        '
        Me.lblDays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDays.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDays.Location = New System.Drawing.Point(120, 112)
        Me.lblDays.Name = "lblDays"
        Me.lblDays.Size = New System.Drawing.Size(136, 23)
        Me.lblDays.TabIndex = 30
        Me.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label72
        '
        Me.Label72.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label72.Location = New System.Drawing.Point(16, 112)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(96, 20)
        Me.Label72.TabIndex = 29
        Me.Label72.Text = "Days"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabTimeSpan
        '
        Me.tabTimeSpan.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage9, Me.TabPage10})
        Me.tabTimeSpan.ItemSize = New System.Drawing.Size(136, 18)
        Me.tabTimeSpan.Location = New System.Drawing.Point(8, 8)
        Me.tabTimeSpan.Name = "tabTimeSpan"
        Me.tabTimeSpan.SelectedIndex = 0
        Me.tabTimeSpan.Size = New System.Drawing.Size(440, 96)
        Me.tabTimeSpan.TabIndex = 10
        '
        'TabPage9
        '
        Me.TabPage9.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshTSProperties, Me.Label28, Me.Label31, Me.txtEnd, Me.txtStart})
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(432, 70)
        Me.TabPage9.TabIndex = 0
        Me.TabPage9.Text = "Enter Start and End Times"
        '
        'btnRefreshTSProperties
        '
        Me.btnRefreshTSProperties.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefreshTSProperties.Location = New System.Drawing.Point(304, 8)
        Me.btnRefreshTSProperties.Name = "btnRefreshTSProperties"
        Me.btnRefreshTSProperties.Size = New System.Drawing.Size(120, 23)
        Me.btnRefreshTSProperties.TabIndex = 9
        Me.btnRefreshTSProperties.Text = "Refresh"
        '
        'Label28
        '
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(8, 40)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(104, 20)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "Ending Time"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(8, 8)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(104, 20)
        Me.Label31.TabIndex = 7
        Me.Label31.Text = "Starting Time"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnd
        '
        Me.txtEnd.Location = New System.Drawing.Point(120, 40)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(176, 20)
        Me.txtEnd.TabIndex = 6
        Me.txtEnd.Text = "5:25:17 PM"
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(120, 8)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(176, 20)
        Me.txtStart.TabIndex = 5
        Me.txtStart.Text = "8:14:12 AM"
        '
        'TabPage10
        '
        Me.TabPage10.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCalcParse, Me.txtParse, Me.Label33})
        Me.TabPage10.Location = New System.Drawing.Point(4, 22)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(432, 70)
        Me.TabPage10.TabIndex = 1
        Me.TabPage10.Text = "Parse TimeSpan"
        Me.TabPage10.Visible = False
        '
        'btnCalcParse
        '
        Me.btnCalcParse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCalcParse.Location = New System.Drawing.Point(304, 8)
        Me.btnCalcParse.Name = "btnCalcParse"
        Me.btnCalcParse.Size = New System.Drawing.Size(120, 23)
        Me.btnCalcParse.TabIndex = 8
        Me.btnCalcParse.Text = "Refresh"
        '
        'txtParse
        '
        Me.txtParse.Location = New System.Drawing.Point(120, 8)
        Me.txtParse.Name = "txtParse"
        Me.txtParse.Size = New System.Drawing.Size(176, 20)
        Me.txtParse.TabIndex = 6
        Me.txtParse.Text = "3.14:55:26.27"
        '
        'Label33
        '
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(16, 8)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(96, 20)
        Me.Label33.TabIndex = 7
        Me.Label33.Text = "Parse"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage7
        '
        Me.TabPage7.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshTSMethods, Me.txtFromHours, Me.lblFromHours, Me.Label34, Me.txtFromSeconds, Me.lblFromSeconds, Me.Label35, Me.txtFromTicks, Me.lblFromTicks, Me.Label36, Me.txtFromMilliseconds, Me.lblFromMilliseconds, Me.Label37, Me.txtFromMinutes, Me.lblFromMinutes, Me.Label47, Me.txtFromDays, Me.lblFromDays, Me.Label48})
        Me.TabPage7.Location = New System.Drawing.Point(4, 40)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(592, 260)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "TimeSpan Methods"
        Me.TabPage7.Visible = False
        '
        'btnRefreshTSMethods
        '
        Me.btnRefreshTSMethods.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefreshTSMethods.Location = New System.Drawing.Point(16, 8)
        Me.btnRefreshTSMethods.Name = "btnRefreshTSMethods"
        Me.btnRefreshTSMethods.Size = New System.Drawing.Size(75, 24)
        Me.btnRefreshTSMethods.TabIndex = 27
        Me.btnRefreshTSMethods.Text = "Refresh"
        '
        'txtFromHours
        '
        Me.txtFromHours.Location = New System.Drawing.Point(136, 56)
        Me.txtFromHours.Name = "txtFromHours"
        Me.txtFromHours.Size = New System.Drawing.Size(104, 20)
        Me.txtFromHours.TabIndex = 35
        Me.txtFromHours.Text = "47.6"
        Me.txtFromHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFromHours
        '
        Me.lblFromHours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFromHours.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFromHours.Location = New System.Drawing.Point(248, 56)
        Me.lblFromHours.Name = "lblFromHours"
        Me.lblFromHours.Size = New System.Drawing.Size(152, 23)
        Me.lblFromHours.TabIndex = 41
        Me.lblFromHours.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(24, 56)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(104, 20)
        Me.Label34.TabIndex = 29
        Me.Label34.Text = "FromHours"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFromSeconds
        '
        Me.txtFromSeconds.Location = New System.Drawing.Point(136, 128)
        Me.txtFromSeconds.Name = "txtFromSeconds"
        Me.txtFromSeconds.Size = New System.Drawing.Size(104, 20)
        Me.txtFromSeconds.TabIndex = 38
        Me.txtFromSeconds.Text = "289"
        Me.txtFromSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFromSeconds
        '
        Me.lblFromSeconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFromSeconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFromSeconds.Location = New System.Drawing.Point(248, 128)
        Me.lblFromSeconds.Name = "lblFromSeconds"
        Me.lblFromSeconds.Size = New System.Drawing.Size(152, 23)
        Me.lblFromSeconds.TabIndex = 44
        Me.lblFromSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label35
        '
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(24, 128)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(104, 20)
        Me.Label35.TabIndex = 32
        Me.Label35.Text = "FromSeconds"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFromTicks
        '
        Me.txtFromTicks.Location = New System.Drawing.Point(136, 152)
        Me.txtFromTicks.Name = "txtFromTicks"
        Me.txtFromTicks.Size = New System.Drawing.Size(104, 20)
        Me.txtFromTicks.TabIndex = 39
        Me.txtFromTicks.Text = "123456789"
        Me.txtFromTicks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFromTicks
        '
        Me.lblFromTicks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFromTicks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFromTicks.Location = New System.Drawing.Point(248, 152)
        Me.lblFromTicks.Name = "lblFromTicks"
        Me.lblFromTicks.Size = New System.Drawing.Size(152, 23)
        Me.lblFromTicks.TabIndex = 45
        Me.lblFromTicks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label36
        '
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(24, 152)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(104, 20)
        Me.Label36.TabIndex = 33
        Me.Label36.Text = "FromTicks"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFromMilliseconds
        '
        Me.txtFromMilliseconds.Location = New System.Drawing.Point(136, 80)
        Me.txtFromMilliseconds.Name = "txtFromMilliseconds"
        Me.txtFromMilliseconds.Size = New System.Drawing.Size(104, 20)
        Me.txtFromMilliseconds.TabIndex = 36
        Me.txtFromMilliseconds.Text = "20098"
        Me.txtFromMilliseconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFromMilliseconds
        '
        Me.lblFromMilliseconds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFromMilliseconds.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFromMilliseconds.Location = New System.Drawing.Point(248, 80)
        Me.lblFromMilliseconds.Name = "lblFromMilliseconds"
        Me.lblFromMilliseconds.Size = New System.Drawing.Size(152, 23)
        Me.lblFromMilliseconds.TabIndex = 42
        Me.lblFromMilliseconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label37
        '
        Me.Label37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label37.Location = New System.Drawing.Point(24, 80)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(104, 20)
        Me.Label37.TabIndex = 30
        Me.Label37.Text = "FromMilliseconds"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFromMinutes
        '
        Me.txtFromMinutes.Location = New System.Drawing.Point(136, 104)
        Me.txtFromMinutes.Name = "txtFromMinutes"
        Me.txtFromMinutes.Size = New System.Drawing.Size(104, 20)
        Me.txtFromMinutes.TabIndex = 37
        Me.txtFromMinutes.Text = "128"
        Me.txtFromMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFromMinutes
        '
        Me.lblFromMinutes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFromMinutes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFromMinutes.Location = New System.Drawing.Point(248, 104)
        Me.lblFromMinutes.Name = "lblFromMinutes"
        Me.lblFromMinutes.Size = New System.Drawing.Size(152, 23)
        Me.lblFromMinutes.TabIndex = 43
        Me.lblFromMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label47
        '
        Me.Label47.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label47.Location = New System.Drawing.Point(24, 104)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(104, 20)
        Me.Label47.TabIndex = 31
        Me.Label47.Text = "FromMinutes"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFromDays
        '
        Me.txtFromDays.Location = New System.Drawing.Point(136, 32)
        Me.txtFromDays.Name = "txtFromDays"
        Me.txtFromDays.Size = New System.Drawing.Size(104, 20)
        Me.txtFromDays.TabIndex = 34
        Me.txtFromDays.Text = "13.456"
        Me.txtFromDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFromDays
        '
        Me.lblFromDays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFromDays.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFromDays.Location = New System.Drawing.Point(248, 32)
        Me.lblFromDays.Name = "lblFromDays"
        Me.lblFromDays.Size = New System.Drawing.Size(152, 23)
        Me.lblFromDays.TabIndex = 40
        Me.lblFromDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label48
        '
        Me.Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label48.Location = New System.Drawing.Point(24, 32)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(104, 20)
        Me.Label48.TabIndex = 28
        Me.Label48.Text = "FromDays"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage5
        '
        Me.TabPage5.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblZero, Me.Label22, Me.lblTicksPerSecond, Me.Label25, Me.lblTicksPerMinute, Me.Label27, Me.lblTicksPerMillisecond, Me.Label29, Me.lblTicksPerHour, Me.Label24, Me.lblTicksPerDay, Me.Label26, Me.lblMinValueTS, Me.Label30, Me.lblMaxValueTS, Me.Label32})
        Me.TabPage5.Location = New System.Drawing.Point(4, 40)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(592, 260)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "TimeSpan Fields"
        Me.TabPage5.Visible = False
        '
        'lblZero
        '
        Me.lblZero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblZero.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblZero.Location = New System.Drawing.Point(136, 200)
        Me.lblZero.Name = "lblZero"
        Me.lblZero.Size = New System.Drawing.Size(200, 23)
        Me.lblZero.TabIndex = 40
        Me.lblZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(16, 200)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(112, 20)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "Zero"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTicksPerSecond
        '
        Me.lblTicksPerSecond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTicksPerSecond.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTicksPerSecond.Location = New System.Drawing.Point(136, 176)
        Me.lblTicksPerSecond.Name = "lblTicksPerSecond"
        Me.lblTicksPerSecond.Size = New System.Drawing.Size(200, 23)
        Me.lblTicksPerSecond.TabIndex = 38
        Me.lblTicksPerSecond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(16, 176)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 20)
        Me.Label25.TabIndex = 37
        Me.Label25.Text = "TicksPerSecond"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTicksPerMinute
        '
        Me.lblTicksPerMinute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTicksPerMinute.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTicksPerMinute.Location = New System.Drawing.Point(136, 152)
        Me.lblTicksPerMinute.Name = "lblTicksPerMinute"
        Me.lblTicksPerMinute.Size = New System.Drawing.Size(200, 23)
        Me.lblTicksPerMinute.TabIndex = 36
        Me.lblTicksPerMinute.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(16, 152)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(112, 20)
        Me.Label27.TabIndex = 35
        Me.Label27.Text = "TicksPerMinute"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTicksPerMillisecond
        '
        Me.lblTicksPerMillisecond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTicksPerMillisecond.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTicksPerMillisecond.Location = New System.Drawing.Point(136, 128)
        Me.lblTicksPerMillisecond.Name = "lblTicksPerMillisecond"
        Me.lblTicksPerMillisecond.Size = New System.Drawing.Size(200, 23)
        Me.lblTicksPerMillisecond.TabIndex = 34
        Me.lblTicksPerMillisecond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(16, 128)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 20)
        Me.Label29.TabIndex = 33
        Me.Label29.Text = "TicksPerMillisecond"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTicksPerHour
        '
        Me.lblTicksPerHour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTicksPerHour.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTicksPerHour.Location = New System.Drawing.Point(136, 104)
        Me.lblTicksPerHour.Name = "lblTicksPerHour"
        Me.lblTicksPerHour.Size = New System.Drawing.Size(200, 23)
        Me.lblTicksPerHour.TabIndex = 32
        Me.lblTicksPerHour.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(16, 104)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 20)
        Me.Label24.TabIndex = 31
        Me.Label24.Text = "TicksPerHour"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTicksPerDay
        '
        Me.lblTicksPerDay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTicksPerDay.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTicksPerDay.Location = New System.Drawing.Point(136, 80)
        Me.lblTicksPerDay.Name = "lblTicksPerDay"
        Me.lblTicksPerDay.Size = New System.Drawing.Size(200, 23)
        Me.lblTicksPerDay.TabIndex = 30
        Me.lblTicksPerDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(16, 80)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 20)
        Me.Label26.TabIndex = 29
        Me.Label26.Text = "TicksPerDay"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMinValueTS
        '
        Me.lblMinValueTS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMinValueTS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMinValueTS.Location = New System.Drawing.Point(136, 56)
        Me.lblMinValueTS.Name = "lblMinValueTS"
        Me.lblMinValueTS.Size = New System.Drawing.Size(200, 23)
        Me.lblMinValueTS.TabIndex = 28
        Me.lblMinValueTS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(16, 56)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(112, 20)
        Me.Label30.TabIndex = 27
        Me.Label30.Text = "MinValue"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMaxValueTS
        '
        Me.lblMaxValueTS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMaxValueTS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMaxValueTS.Location = New System.Drawing.Point(136, 32)
        Me.lblMaxValueTS.Name = "lblMaxValueTS"
        Me.lblMaxValueTS.Size = New System.Drawing.Size(200, 23)
        Me.lblMaxValueTS.TabIndex = 26
        Me.lblMaxValueTS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label32
        '
        Me.Label32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label32.Location = New System.Drawing.Point(16, 32)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(112, 20)
        Me.Label32.TabIndex = 25
        Me.Label32.Text = "MaxValue"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(618, 324)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.tabTimeSpan.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage10.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
		' Open the About form in Dialog Mode
		Dim frm As New frmAbout()
		frm.ShowDialog(Me)
		frm.Dispose()
	End Sub

	' This code will close the form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
		' Close the current form
		Me.Close()
	End Sub
#End Region

#Region " Form Load "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
		Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

		' Call procedures that load values onto the form.
		LoadSharedMembers()
		LoadProperties()
		LoadConversionMethods()
		LoadCalculationMethods()
		LoadTimeSpanFields()

		LoadTSMethods()
	End Sub
#End Region

	Private Sub btnCalcParse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcParse.Click
		' Display TimeSpan properties given a string containing
		' a TimeSpan value to parse.
		Try
			' No need to use an explicit constructor
			' unless you need to specify a value
			' at the time the instance gets created.
			Dim ts As TimeSpan
			ts = TimeSpan.Parse(txtParse.Text)

			' Display the properties of the TimeSpan
			' instance you've created.
			DisplayTSProperties(ts)
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub btnRefreshCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshCalculation.Click
		LoadCalculationMethods()
	End Sub

	Private Sub btnRefreshConversion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshConversion.Click
		LoadConversionMethods()
	End Sub

	Private Sub btnRefreshProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshProperties.Click
		LoadProperties()
	End Sub

	Private Sub btnRefreshShared_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshShared.Click
		LoadSharedMembers()
	End Sub

	Private Sub btnRefreshTSMethods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshTSMethods.Click
		LoadTSMethods()
	End Sub

	Private Sub btnRefreshTSProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshTSProperties.Click
		Try
			' Create a TimeSpan instance based on 
			' DateTime values provided on the form.
			Dim ts As TimeSpan
			Dim dtStart As DateTime
			Dim dtEnd As DateTime

			' Parse the text from the text boxes.
			dtStart = DateTime.Parse(txtStart.Text)
			dtEnd = DateTime.Parse(txtEnd.Text)
			ts = dtEnd.Subtract(dtStart).Duration

			' Display the properties of the TimeSpan
			' instance you've created.
			DisplayTSProperties(ts)
		Catch Exp As Exception
			MessageBox.Show(Exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub tabTimeSpan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTimeSpan.SelectedIndexChanged
		' Clear out all the items on the page.
		' This is the only page that appears
		' empty until you refresh the data. 
		lblDays.Text = String.Empty
		lblHours.Text = String.Empty
		lblMilliseconds.Text = String.Empty
		lblMinutes.Text = String.Empty
		lblSeconds.Text = String.Empty
		lblTimeSpanTicks.Text = String.Empty
		lblTotalDays.Text = String.Empty
		lblTotalHours.Text = String.Empty
		lblTotalMilliseconds.Text = String.Empty
		lblTotalMinutes.Text = String.Empty
		lblTotalSeconds.Text = String.Empty
	End Sub

	Private Sub DisplayTSProperties(ByVal ts As TimeSpan)
		' Use instance properties of the TimeSpan type.
		' Demonstrates:
		'  TimeSpan.Days
		'  TimeSpan.Hours
		'  TimeSpan.Milliseconds
		'  TimeSpan.Minutes
		'  TimeSpan.Seconds
		'  TimeSpan.Ticks
		'  TimeSpan.TotalDays
		'  TimeSpan.TotalHours
		'  TimeSpan.TotalMilliseconds
		'  TimeSpan.TotalMinutes
		'  TimeSpan.TotalSeconds
		Try
			lblDays.Text = ts.Days.ToString
			lblHours.Text = ts.Hours.ToString
			lblMilliseconds.Text = ts.Milliseconds.ToString
			lblMinutes.Text = ts.Minutes.ToString
			lblSeconds.Text = ts.Seconds.ToString
			lblTimeSpanTicks.Text = ts.Ticks.ToString
			lblTotalDays.Text = ts.TotalDays.ToString
			lblTotalHours.Text = ts.TotalHours.ToString
			lblTotalMilliseconds.Text = ts.TotalMilliseconds.ToString
			lblTotalMinutes.Text = ts.TotalMinutes.ToString
			lblTotalSeconds.Text = ts.TotalSeconds.ToString
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub LoadCalculationMethods()
		' Use instance methods of the DateTime type.
		' Demonstrates:
		'  DateTime.AddDays
		'  DateTime.AddHours
		'  DateTime.AddMilliseconds
		'  DateTime.AddMinutes
		'  DateTime.AddMonths
		'  DateTime.AddSeconds
		'  DateTime.AddTicks
		'  DateTime.AddYears
		Try
			Dim dt As DateTime = DateTime.Now
			lblNow3.Text = dt.ToString

			lblAddDays.Text = dt.AddDays(CDbl(txtDays.Text)).ToString
			lblAddHours.Text = dt.AddHours(CDbl(txtHours.Text)).ToString
			lblAddMilliseconds.Text = dt.AddMilliseconds(CDbl(txtMilliseconds.Text)).ToString
			lblAddMinutes.Text = dt.AddMinutes(CDbl(txtMinutes.Text)).ToString
			lblAddMonths.Text = dt.AddMonths(CInt(txtMonths.Text)).ToString
			lblAddSeconds.Text = dt.AddSeconds(CDbl(txtSeconds.Text)).ToString
			lblAddTicks.Text = dt.AddTicks(CLng(txtTicks.Text)).ToString
			lblAddYears.Text = dt.AddYears(CInt(txtYears.Text)).ToString
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub LoadConversionMethods()
		' Use instance methods of the DateTime type.
		' Demonstrates:
		'  DateTime.ToFileTime
		'  DateTime.ToLocalTime
		'  DateTime.ToLongDateString
		'  DateTime.ToLongTimeString
		'  DateTime.ToOADate
		'  DateTime.ToShortDateString
		'  DateTime.ToShortTimeString
		'  DateTime.ToString
		'  DateTime.ToUniversalTime
		Try
			Dim dt As DateTime = DateTime.Now

			lblNow2.Text = dt.ToString
			lblToFileTime.Text = dt.ToFileTime.ToString
			lblToLocalTime.Text = dt.ToLocalTime.ToString
			lblToLongDateString.Text = dt.ToLongDateString
			lblToLongTimeString.Text = dt.ToLongTimeString
			lblToOADate.Text = dt.ToOADate.ToString
			lblToShortDateString.Text = dt.ToShortDateString
			lblToShortTimeString.Text = dt.ToShortTimeString
			lblToString.Text = dt.ToString
			lblToUniversalTime.Text = dt.ToUniversalTime.ToString
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub LoadProperties()
		' Use instance properties of the 
		' the DateTime type.
		' Demonstrates:
		'  DateTime.Now
		'  DateTime.Date
		'  DateTime.Day
		'  DateTime.DayOfYear
		'  DateTime.Hour
		'  DateTime.Millisecond
		'  DateTime.DayOfWeek
		'  DateTime.Minute
		'  DateTime.Month
		'  DateTime.Second
		'  DateTime.Ticks
		'  DateTime.TimeOfDay
		'  DateTime.Year
		Try
			' No need to use an explicit constructor
			' unless you need to specify a value
			' at the time the instance gets created.
			Dim dt As DateTime = DateTime.Now

			lblNow1.Text = dt.ToString
			lblDate.Text = dt.Date.ToString
			lblDay.Text = dt.Day.ToString
			lblDayOfYear.Text = dt.DayOfYear.ToString
			lblHour.Text = dt.Hour.ToString
			lblMillisecond.Text = dt.Millisecond.ToString
			lblDayOfWeek.Text = dt.DayOfWeek.ToString
			lblMinute.Text = dt.Minute.ToString
			lblMonth.Text = dt.Month.ToString
			lblSecond.Text = dt.Second.ToString
			lblTicks.Text = dt.Ticks.ToString
			lblTimeOfDay.Text = dt.TimeOfDay.ToString
			lblYear.Text = dt.Year.ToString
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub LoadSharedMembers()
		' Use shared members of the DateTime type.
		' Demonstrates these properties:
		'  DateTime.Now
		'  DateTime.UtcNow
		'  DateTime.MinValue
		'  DateTime.MaxValue

		' Demonstrates these methods:
		'  DateTime.FromOADate
		'  DateTime.IsLeapYear
		'  DateTime.DaysInMonth
		Try
			lblNow.Text = DateTime.Now.ToString
			lblToday.Text = DateTime.Today.ToString
			lblUtcNow.Text = DateTime.UtcNow.ToString
			lblMinValue.Text = DateTime.MinValue.ToString
			lblMaxValue.Text = DateTime.MaxValue.ToString

			lblFromOADate.Text = DateTime.FromOADate(CDbl(txtFromOADate.Text)).ToString
			lblIsLeapYear.Text = DateTime.IsLeapYear(CInt(txtIsLeapYear.Text)).ToString
			lblDaysInMonth.Text = DateTime.DaysInMonth( _
			 CInt(txtYear.Text), CInt(txtMonth.Text)).ToString
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub LoadTimeSpanFields()
		' Use shared fields provided by TimeSpan type.
		' Demonstrates:
		'  TimeSpan.MaxValue
		'  TimeSpan.Minvalue
		'  TimeSpan.TicksPerDay
		'  TimeSpan.TicksPerHour
		'  TimeSpan.TicksPerMillisecond
		'  TimeSpan.TicksPerMinute
		'  TimeSpan.TicksPerSecond
		'  TimeSpan.Zero
		Try
			lblMaxValueTS.Text = TimeSpan.MaxValue.ToString
			lblMinValueTS.Text = TimeSpan.MinValue.ToString
			lblTicksPerDay.Text = TimeSpan.TicksPerDay.ToString
			lblTicksPerHour.Text = TimeSpan.TicksPerHour.ToString
			lblTicksPerMillisecond.Text = TimeSpan.TicksPerMillisecond.ToString
			lblTicksPerMinute.Text = TimeSpan.TicksPerMinute.ToString
			lblTicksPerSecond.Text = TimeSpan.TicksPerSecond.ToString
			lblZero.Text = TimeSpan.Zero.ToString
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub

	Private Sub LoadTSMethods()
		' Use shared methods of the TimeSpan type.
		' Demonstrates:
		'  TimeSpan.FromDays
		'  TimeSpan.FromHours
		'  TimeSpan.FromMilliseconds
		'  TimeSpan.FromMinutes
		'  TimeSpan.FromSeconds
		'  TimeSpan.FromTicks
		Try
			lblFromDays.Text = TimeSpan.FromDays(CDbl(txtFromDays.Text)).ToString
			lblFromHours.Text = TimeSpan.FromHours(CDbl(txtFromHours.Text)).ToString
			lblFromMilliseconds.Text = TimeSpan.FromMilliseconds(CDbl(txtFromMilliseconds.Text)).ToString
			lblFromMinutes.Text = TimeSpan.FromMinutes(CDbl(txtFromMinutes.Text)).ToString
			lblFromSeconds.Text = TimeSpan.FromSeconds(CDbl(txtFromSeconds.Text)).ToString
			lblFromTicks.Text = TimeSpan.FromTicks(CLng(txtFromTicks.Text)).ToString
		Catch exp As Exception
			MessageBox.Show(exp.Message, Me.Text)
		End Try
	End Sub


End Class