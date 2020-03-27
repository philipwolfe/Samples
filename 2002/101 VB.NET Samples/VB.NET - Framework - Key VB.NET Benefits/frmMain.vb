'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Text
Imports System.IO
Imports System.Threading

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' Employee variables for Inheritance tab
    Private c_empFull As FullTimeEmployee
    Private c_empPart As PartTimeEmployee
    Private c_empTemp As TempEmployee

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' So that we only need to set the title of the application once,
        ' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
        ' to read the AssemblyTitle attribute.
        Dim ainfo As New AssemblyInfo()

        Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

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
    Friend WithEvents sbrStatus As System.Windows.Forms.StatusBar
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pgeFiles As System.Windows.Forms.TabPage
    Friend WithEvents pgeDebugging As System.Windows.Forms.TabPage
    Friend WithEvents pgeInheritance As System.Windows.Forms.TabPage
    Friend WithEvents pgeThreading As System.Windows.Forms.TabPage
    Friend WithEvents sbrPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbrPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents pgeStringBuilder As System.Windows.Forms.TabPage
    Friend WithEvents pgeTips As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstDebugFunction As System.Windows.Forms.ListBox
    Friend WithEvents txtDebugInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnDebugFunction As System.Windows.Forms.Button
    Friend WithEvents txtTips As System.Windows.Forms.TextBox
    Friend WithEvents pgeForms As System.Windows.Forms.TabPage
    Friend WithEvents btnOpenDemoForm As System.Windows.Forms.Button
    Friend WithEvents btnThreadFunction As System.Windows.Forms.Button
    Friend WithEvents txtThreadResult As System.Windows.Forms.TextBox
    Friend WithEvents btnStringBuilderFunction As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtStrResults As System.Windows.Forms.TextBox
    Friend WithEvents txtSBResults As System.Windows.Forms.TextBox
    Friend WithEvents txtStrIterations As System.Windows.Forms.TextBox
    Friend WithEvents txtSBIterations As System.Windows.Forms.TextBox
    Friend WithEvents txtSBAppend As System.Windows.Forms.TextBox
    Friend WithEvents txtSBOrig As System.Windows.Forms.TextBox
    Friend WithEvents lblSBAppend As System.Windows.Forms.Label
    Friend WithEvents txtFileResult As System.Windows.Forms.TextBox
    Friend WithEvents btnFileFunction As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lstFileFunction As System.Windows.Forms.ListBox
    Friend WithEvents txtExceptionHandlingResult As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents pgeExceptionHandling As System.Windows.Forms.TabPage
    Friend WithEvents lstExceptionHandling As System.Windows.Forms.ListBox
    Friend WithEvents btnExceptionHandlingFunction As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents btnHire As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtExpectedTermDate As System.Windows.Forms.TextBox
    Friend WithEvents txtSocialServicesID As System.Windows.Forms.TextBox
    Friend WithEvents txtSalary As System.Windows.Forms.TextBox
    Friend WithEvents txtHireDate As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboEmployeeType As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnShowGraphics As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.sbrStatus = New System.Windows.Forms.StatusBar()
        Me.sbrPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.sbrPanel2 = New System.Windows.Forms.StatusBarPanel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pgeFiles = New System.Windows.Forms.TabPage()
        Me.txtFileResult = New System.Windows.Forms.TextBox()
        Me.btnFileFunction = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lstFileFunction = New System.Windows.Forms.ListBox()
        Me.pgeExceptionHandling = New System.Windows.Forms.TabPage()
        Me.txtExceptionHandlingResult = New System.Windows.Forms.TextBox()
        Me.btnExceptionHandlingFunction = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lstExceptionHandling = New System.Windows.Forms.ListBox()
        Me.pgeDebugging = New System.Windows.Forms.TabPage()
        Me.btnDebugFunction = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDebugInfo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstDebugFunction = New System.Windows.Forms.ListBox()
        Me.pgeStringBuilder = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSBIterations = New System.Windows.Forms.TextBox()
        Me.txtStrIterations = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSBResults = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSBAppend = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSBAppend = New System.Windows.Forms.TextBox()
        Me.txtStrResults = New System.Windows.Forms.TextBox()
        Me.txtSBOrig = New System.Windows.Forms.TextBox()
        Me.btnStringBuilderFunction = New System.Windows.Forms.Button()
        Me.pgeForms = New System.Windows.Forms.TabPage()
        Me.btnShowGraphics = New System.Windows.Forms.Button()
        Me.btnOpenDemoForm = New System.Windows.Forms.Button()
        Me.pgeThreading = New System.Windows.Forms.TabPage()
        Me.btnThreadFunction = New System.Windows.Forms.Button()
        Me.txtThreadResult = New System.Windows.Forms.TextBox()
        Me.pgeInheritance = New System.Windows.Forms.TabPage()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.btnHire = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtExpectedTermDate = New System.Windows.Forms.TextBox()
        Me.txtSocialServicesID = New System.Windows.Forms.TextBox()
        Me.txtSalary = New System.Windows.Forms.TextBox()
        Me.txtHireDate = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboEmployeeType = New System.Windows.Forms.ComboBox()
        Me.pgeTips = New System.Windows.Forms.TabPage()
        Me.txtTips = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.sbrPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbrPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.pgeFiles.SuspendLayout()
        Me.pgeExceptionHandling.SuspendLayout()
        Me.pgeDebugging.SuspendLayout()
        Me.pgeStringBuilder.SuspendLayout()
        Me.pgeForms.SuspendLayout()
        Me.pgeThreading.SuspendLayout()
        Me.pgeInheritance.SuspendLayout()
        Me.pgeTips.SuspendLayout()
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
        'sbrStatus
        '
        Me.sbrStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbrStatus.Location = New System.Drawing.Point(0, 363)
        Me.sbrStatus.Name = "sbrStatus"
        Me.sbrStatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbrPanel1, Me.sbrPanel2})
        Me.sbrStatus.ShowPanels = True
        Me.sbrStatus.Size = New System.Drawing.Size(634, 24)
        Me.sbrStatus.SizingGrip = False
        Me.sbrStatus.TabIndex = 2
        '
        'sbrPanel1
        '
        Me.sbrPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
        Me.sbrPanel1.Width = 15
        '
        'sbrPanel2
        '
        Me.sbrPanel2.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
        Me.sbrPanel2.MinWidth = 10000
        Me.sbrPanel2.Width = 10000
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeFiles, Me.pgeExceptionHandling, Me.pgeDebugging, Me.pgeStringBuilder, Me.pgeForms, Me.pgeThreading, Me.pgeInheritance, Me.pgeTips})
        Me.TabControl1.Location = New System.Drawing.Point(16, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(600, 312)
        Me.TabControl1.TabIndex = 0
        '
        'pgeFiles
        '
        Me.pgeFiles.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFileResult, Me.btnFileFunction, Me.Label9, Me.lstFileFunction})
        Me.pgeFiles.Location = New System.Drawing.Point(4, 22)
        Me.pgeFiles.Name = "pgeFiles"
        Me.pgeFiles.Size = New System.Drawing.Size(592, 286)
        Me.pgeFiles.TabIndex = 1
        Me.pgeFiles.Text = "Files"
        '
        'txtFileResult
        '
        Me.txtFileResult.Location = New System.Drawing.Point(312, 16)
        Me.txtFileResult.Multiline = True
        Me.txtFileResult.Name = "txtFileResult"
        Me.txtFileResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFileResult.Size = New System.Drawing.Size(272, 176)
        Me.txtFileResult.TabIndex = 2
        Me.txtFileResult.Text = ""
        '
        'btnFileFunction
        '
        Me.btnFileFunction.Location = New System.Drawing.Point(472, 208)
        Me.btnFileFunction.Name = "btnFileFunction"
        Me.btnFileFunction.Size = New System.Drawing.Size(112, 23)
        Me.btnFileFunction.TabIndex = 3
        Me.btnFileFunction.Text = "&Do File Function"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Choose one"
        '
        'lstFileFunction
        '
        Me.lstFileFunction.Items.AddRange(New Object() {"Reading a file: StreamReader object", "Writing a file: StreamWriter object", "File Size: FileInfo object", "File version info: FileVersionInfo object", "Temp file name: GetTempFileName function"})
        Me.lstFileFunction.Location = New System.Drawing.Point(80, 16)
        Me.lstFileFunction.Name = "lstFileFunction"
        Me.lstFileFunction.Size = New System.Drawing.Size(224, 212)
        Me.lstFileFunction.TabIndex = 1
        '
        'pgeExceptionHandling
        '
        Me.pgeExceptionHandling.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtExceptionHandlingResult, Me.btnExceptionHandlingFunction, Me.Label23, Me.lstExceptionHandling})
        Me.pgeExceptionHandling.Location = New System.Drawing.Point(4, 22)
        Me.pgeExceptionHandling.Name = "pgeExceptionHandling"
        Me.pgeExceptionHandling.Size = New System.Drawing.Size(592, 286)
        Me.pgeExceptionHandling.TabIndex = 3
        Me.pgeExceptionHandling.Text = "Exception Handling"
        '
        'txtExceptionHandlingResult
        '
        Me.txtExceptionHandlingResult.Location = New System.Drawing.Point(312, 16)
        Me.txtExceptionHandlingResult.Multiline = True
        Me.txtExceptionHandlingResult.Name = "txtExceptionHandlingResult"
        Me.txtExceptionHandlingResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtExceptionHandlingResult.Size = New System.Drawing.Size(272, 176)
        Me.txtExceptionHandlingResult.TabIndex = 2
        Me.txtExceptionHandlingResult.Text = ""
        '
        'btnExceptionHandlingFunction
        '
        Me.btnExceptionHandlingFunction.Location = New System.Drawing.Point(408, 200)
        Me.btnExceptionHandlingFunction.Name = "btnExceptionHandlingFunction"
        Me.btnExceptionHandlingFunction.Size = New System.Drawing.Size(176, 23)
        Me.btnExceptionHandlingFunction.TabIndex = 3
        Me.btnExceptionHandlingFunction.Text = "&Do Exception Handling Function"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Choose one"
        '
        'lstExceptionHandling
        '
        Me.lstExceptionHandling.Items.AddRange(New Object() {"Basic exception handling", "Focused exception handling"})
        Me.lstExceptionHandling.Location = New System.Drawing.Point(80, 16)
        Me.lstExceptionHandling.Name = "lstExceptionHandling"
        Me.lstExceptionHandling.Size = New System.Drawing.Size(224, 212)
        Me.lstExceptionHandling.TabIndex = 1
        '
        'pgeDebugging
        '
        Me.pgeDebugging.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDebugFunction, Me.Label11, Me.txtDebugInfo, Me.Label4, Me.lstDebugFunction})
        Me.pgeDebugging.Location = New System.Drawing.Point(4, 22)
        Me.pgeDebugging.Name = "pgeDebugging"
        Me.pgeDebugging.Size = New System.Drawing.Size(592, 286)
        Me.pgeDebugging.TabIndex = 2
        Me.pgeDebugging.Text = "Tracing/Debugging"
        '
        'btnDebugFunction
        '
        Me.btnDebugFunction.Location = New System.Drawing.Point(336, 48)
        Me.btnDebugFunction.Name = "btnDebugFunction"
        Me.btnDebugFunction.Size = New System.Drawing.Size(168, 23)
        Me.btnDebugFunction.TabIndex = 4
        Me.btnDebugFunction.Text = "Do Debug Function"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Trace string"
        '
        'txtDebugInfo
        '
        Me.txtDebugInfo.Location = New System.Drawing.Point(80, 16)
        Me.txtDebugInfo.Name = "txtDebugInfo"
        Me.txtDebugInfo.Size = New System.Drawing.Size(480, 20)
        Me.txtDebugInfo.TabIndex = 1
        Me.txtDebugInfo.Text = "My trace string"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Choose one"
        '
        'lstDebugFunction
        '
        Me.lstDebugFunction.Items.AddRange(New Object() {"Debug", "    Write to Console", "    Write to File", "    Write to Event Log", "Trace", "    Write to Console", "    Write to File", "    Write to Event Log"})
        Me.lstDebugFunction.Location = New System.Drawing.Point(80, 48)
        Me.lstDebugFunction.Name = "lstDebugFunction"
        Me.lstDebugFunction.Size = New System.Drawing.Size(248, 212)
        Me.lstDebugFunction.TabIndex = 3
        '
        'pgeStringBuilder
        '
        Me.pgeStringBuilder.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label16, Me.txtSBIterations, Me.txtStrIterations, Me.Label15, Me.Label14, Me.txtSBResults, Me.Label3, Me.lblSBAppend, Me.Label12, Me.txtSBAppend, Me.txtStrResults, Me.txtSBOrig, Me.btnStringBuilderFunction})
        Me.pgeStringBuilder.Location = New System.Drawing.Point(4, 22)
        Me.pgeStringBuilder.Name = "pgeStringBuilder"
        Me.pgeStringBuilder.Size = New System.Drawing.Size(592, 286)
        Me.pgeStringBuilder.TabIndex = 6
        Me.pgeStringBuilder.Text = "StringBuilder"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(144, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "SB Iterations"
        '
        'txtSBIterations
        '
        Me.txtSBIterations.Location = New System.Drawing.Point(216, 64)
        Me.txtSBIterations.Name = "txtSBIterations"
        Me.txtSBIterations.ReadOnly = True
        Me.txtSBIterations.Size = New System.Drawing.Size(72, 20)
        Me.txtSBIterations.TabIndex = 23
        Me.txtSBIterations.Text = "200000"
        '
        'txtStrIterations
        '
        Me.txtStrIterations.Location = New System.Drawing.Point(88, 64)
        Me.txtStrIterations.Name = "txtStrIterations"
        Me.txtStrIterations.ReadOnly = True
        Me.txtStrIterations.Size = New System.Drawing.Size(52, 20)
        Me.txtStrIterations.TabIndex = 22
        Me.txtStrIterations.Text = "10000"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(296, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Mill. Str"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(440, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Mill SB."
        '
        'txtSBResults
        '
        Me.txtSBResults.Location = New System.Drawing.Point(504, 64)
        Me.txtSBResults.Name = "txtSBResults"
        Me.txtSBResults.ReadOnly = True
        Me.txtSBResults.Size = New System.Drawing.Size(72, 20)
        Me.txtSBResults.TabIndex = 19
        Me.txtSBResults.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Str Iterations"
        '
        'lblSBAppend
        '
        Me.lblSBAppend.AutoSize = True
        Me.lblSBAppend.Location = New System.Drawing.Point(8, 40)
        Me.lblSBAppend.Name = "lblSBAppend"
        Me.lblSBAppend.Size = New System.Drawing.Size(43, 13)
        Me.lblSBAppend.TabIndex = 2
        Me.lblSBAppend.Text = "Append"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Original string"
        '
        'txtSBAppend
        '
        Me.txtSBAppend.Location = New System.Drawing.Point(88, 40)
        Me.txtSBAppend.Name = "txtSBAppend"
        Me.txtSBAppend.Size = New System.Drawing.Size(200, 20)
        Me.txtSBAppend.TabIndex = 3
        Me.txtSBAppend.Text = ""
        '
        'txtStrResults
        '
        Me.txtStrResults.Location = New System.Drawing.Point(360, 64)
        Me.txtStrResults.Name = "txtStrResults"
        Me.txtStrResults.ReadOnly = True
        Me.txtStrResults.Size = New System.Drawing.Size(72, 20)
        Me.txtStrResults.TabIndex = 15
        Me.txtStrResults.Text = ""
        '
        'txtSBOrig
        '
        Me.txtSBOrig.Location = New System.Drawing.Point(88, 16)
        Me.txtSBOrig.Name = "txtSBOrig"
        Me.txtSBOrig.Size = New System.Drawing.Size(488, 20)
        Me.txtSBOrig.TabIndex = 1
        Me.txtSBOrig.Text = ""
        '
        'btnStringBuilderFunction
        '
        Me.btnStringBuilderFunction.Location = New System.Drawing.Point(360, 104)
        Me.btnStringBuilderFunction.Name = "btnStringBuilderFunction"
        Me.btnStringBuilderFunction.Size = New System.Drawing.Size(216, 23)
        Me.btnStringBuilderFunction.TabIndex = 4
        Me.btnStringBuilderFunction.Text = "Concatenate"
        '
        'pgeForms
        '
        Me.pgeForms.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnShowGraphics, Me.btnOpenDemoForm})
        Me.pgeForms.Location = New System.Drawing.Point(4, 22)
        Me.pgeForms.Name = "pgeForms"
        Me.pgeForms.Size = New System.Drawing.Size(592, 286)
        Me.pgeForms.TabIndex = 8
        Me.pgeForms.Text = "Forms and Graphics"
        '
        'btnShowGraphics
        '
        Me.btnShowGraphics.Location = New System.Drawing.Point(16, 64)
        Me.btnShowGraphics.Name = "btnShowGraphics"
        Me.btnShowGraphics.Size = New System.Drawing.Size(176, 23)
        Me.btnShowGraphics.TabIndex = 1
        Me.btnShowGraphics.Text = "Graphics Support"
        '
        'btnOpenDemoForm
        '
        Me.btnOpenDemoForm.Location = New System.Drawing.Point(16, 24)
        Me.btnOpenDemoForm.Name = "btnOpenDemoForm"
        Me.btnOpenDemoForm.Size = New System.Drawing.Size(176, 23)
        Me.btnOpenDemoForm.TabIndex = 0
        Me.btnOpenDemoForm.Text = "Show Anchoring and Docking"
        '
        'pgeThreading
        '
        Me.pgeThreading.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnThreadFunction, Me.txtThreadResult})
        Me.pgeThreading.Location = New System.Drawing.Point(4, 22)
        Me.pgeThreading.Name = "pgeThreading"
        Me.pgeThreading.Size = New System.Drawing.Size(592, 286)
        Me.pgeThreading.TabIndex = 5
        Me.pgeThreading.Text = "Threading"
        '
        'btnThreadFunction
        '
        Me.btnThreadFunction.Location = New System.Drawing.Point(400, 32)
        Me.btnThreadFunction.Name = "btnThreadFunction"
        Me.btnThreadFunction.Size = New System.Drawing.Size(168, 23)
        Me.btnThreadFunction.TabIndex = 1
        Me.btnThreadFunction.Text = "Start Thread"
        '
        'txtThreadResult
        '
        Me.txtThreadResult.Location = New System.Drawing.Point(16, 32)
        Me.txtThreadResult.Multiline = True
        Me.txtThreadResult.Name = "txtThreadResult"
        Me.txtThreadResult.Size = New System.Drawing.Size(376, 224)
        Me.txtThreadResult.TabIndex = 0
        Me.txtThreadResult.Text = ""
        '
        'pgeInheritance
        '
        Me.pgeInheritance.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label21, Me.btnSave, Me.btnClear, Me.txtResults, Me.btnHire, Me.Label6, Me.Label5, Me.Label17, Me.Label18, Me.Label19, Me.txtExpectedTermDate, Me.txtSocialServicesID, Me.txtSalary, Me.txtHireDate, Me.txtName, Me.Label20, Me.cboEmployeeType})
        Me.pgeInheritance.Location = New System.Drawing.Point(4, 22)
        Me.pgeInheritance.Name = "pgeInheritance"
        Me.pgeInheritance.Size = New System.Drawing.Size(592, 286)
        Me.pgeInheritance.TabIndex = 4
        Me.pgeInheritance.Text = "Inheritance"
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(51, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(264, 23)
        Me.Label21.TabIndex = 32
        Me.Label21.Text = "Employee Management"
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "btnSave"
        Me.btnSave.AccessibleName = "Save data button"
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(408, 240)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 23)
        Me.btnSave.TabIndex = 29
        Me.btnSave.Text = "&Save"
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = "Clear data"
        Me.btnClear.AccessibleName = "btnClear"
        Me.btnClear.Location = New System.Drawing.Point(488, 240)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 23)
        Me.btnClear.TabIndex = 30
        Me.btnClear.Text = "&Clear"
        '
        'txtResults
        '
        Me.txtResults.AccessibleDescription = "Results"
        Me.txtResults.AccessibleName = "txtResults"
        Me.txtResults.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtResults.BackColor = System.Drawing.SystemColors.Menu
        Me.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResults.Location = New System.Drawing.Point(331, 64)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ReadOnly = True
        Me.txtResults.Size = New System.Drawing.Size(229, 165)
        Me.txtResults.TabIndex = 31
        Me.txtResults.Text = ""
        '
        'btnHire
        '
        Me.btnHire.AccessibleDescription = "Hire button"
        Me.btnHire.AccessibleName = "btnHire"
        Me.btnHire.Enabled = False
        Me.btnHire.Location = New System.Drawing.Point(328, 240)
        Me.btnHire.Name = "btnHire"
        Me.btnHire.Size = New System.Drawing.Size(72, 23)
        Me.btnHire.TabIndex = 28
        Me.btnHire.Text = "H&ire"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Expected Term. Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(51, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Social Services ID"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(51, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Salary"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(51, 120)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Hire Date"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(51, 96)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Name"
        '
        'txtExpectedTermDate
        '
        Me.txtExpectedTermDate.AccessibleDescription = "Expected Termination Date"
        Me.txtExpectedTermDate.AccessibleName = "txtExpectedTermDate"
        Me.txtExpectedTermDate.Enabled = False
        Me.txtExpectedTermDate.Location = New System.Drawing.Point(163, 208)
        Me.txtExpectedTermDate.Name = "txtExpectedTermDate"
        Me.txtExpectedTermDate.Size = New System.Drawing.Size(160, 20)
        Me.txtExpectedTermDate.TabIndex = 27
        Me.txtExpectedTermDate.Text = ""
        '
        'txtSocialServicesID
        '
        Me.txtSocialServicesID.AccessibleDescription = "Social Services ID"
        Me.txtSocialServicesID.AccessibleName = "txtSocialServicesID"
        Me.txtSocialServicesID.Enabled = False
        Me.txtSocialServicesID.Location = New System.Drawing.Point(163, 176)
        Me.txtSocialServicesID.Name = "txtSocialServicesID"
        Me.txtSocialServicesID.Size = New System.Drawing.Size(160, 20)
        Me.txtSocialServicesID.TabIndex = 25
        Me.txtSocialServicesID.Text = ""
        '
        'txtSalary
        '
        Me.txtSalary.AccessibleDescription = "Salary"
        Me.txtSalary.AccessibleName = "txtSalary"
        Me.txtSalary.Enabled = False
        Me.txtSalary.Location = New System.Drawing.Point(163, 152)
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.Size = New System.Drawing.Size(160, 20)
        Me.txtSalary.TabIndex = 23
        Me.txtSalary.Text = ""
        '
        'txtHireDate
        '
        Me.txtHireDate.AccessibleDescription = "Hire date"
        Me.txtHireDate.AccessibleName = "txtHireDate"
        Me.txtHireDate.Enabled = False
        Me.txtHireDate.Location = New System.Drawing.Point(163, 120)
        Me.txtHireDate.Name = "txtHireDate"
        Me.txtHireDate.Size = New System.Drawing.Size(160, 20)
        Me.txtHireDate.TabIndex = 21
        Me.txtHireDate.Text = ""
        '
        'txtName
        '
        Me.txtName.AccessibleDescription = "Employee name"
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(163, 96)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(160, 20)
        Me.txtName.TabIndex = 19
        Me.txtName.Text = ""
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(51, 64)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 13)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Employee &type"
        '
        'cboEmployeeType
        '
        Me.cboEmployeeType.AccessibleDescription = "Employee type combo box"
        Me.cboEmployeeType.AccessibleName = "cboEmployeeType"
        Me.cboEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeType.Items.AddRange(New Object() {"Full-time", "Part-time", "Temporary"})
        Me.cboEmployeeType.Location = New System.Drawing.Point(163, 64)
        Me.cboEmployeeType.Name = "cboEmployeeType"
        Me.cboEmployeeType.Size = New System.Drawing.Size(160, 21)
        Me.cboEmployeeType.TabIndex = 17
        '
        'pgeTips
        '
        Me.pgeTips.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTips})
        Me.pgeTips.Location = New System.Drawing.Point(4, 22)
        Me.pgeTips.Name = "pgeTips"
        Me.pgeTips.Size = New System.Drawing.Size(592, 286)
        Me.pgeTips.TabIndex = 7
        Me.pgeTips.Text = "Tips"
        '
        'txtTips
        '
        Me.txtTips.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTips.Multiline = True
        Me.txtTips.Name = "txtTips"
        Me.txtTips.Size = New System.Drawing.Size(592, 286)
        Me.txtTips.TabIndex = 0
        Me.txtTips.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VB.NET Benefits"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(634, 387)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.TabControl1, Me.sbrStatus})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        CType(Me.sbrPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbrPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.pgeFiles.ResumeLayout(False)
        Me.pgeExceptionHandling.ResumeLayout(False)
        Me.pgeDebugging.ResumeLayout(False)
        Me.pgeStringBuilder.ResumeLayout(False)
        Me.pgeForms.ResumeLayout(False)
        Me.pgeThreading.ResumeLayout(False)
        Me.pgeInheritance.ResumeLayout(False)
        Me.pgeTips.ResumeLayout(False)
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

#Region " Form_load "

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetupTips()
        lstFileFunction.SelectedIndex = 0
        lstDebugFunction.SelectedIndex = 0
        txtSBAppend.Text = "My string"
        lstExceptionHandling.SelectedIndex = 0
    End Sub

#End Region

#Region " Utility functions "

    Private Sub AddTip(ByVal strTip As String)
        txtTips.Text &= strTip & vbCrLf
    End Sub

    Private Sub AddTip2(ByVal strTip As String)
        txtTips.Text &= strTip & vbCrLf & vbCrLf
    End Sub

    Private Sub SetupTips()
        txtTips.Clear()
        AddTip2("Strings: Whenever you expect to make multiple adjustments to a string, use the StringBuilder. It is orders of magnitude faster than traditional string manipulation.")
        AddTip("Debugging: Use the Debug class if you only want output in the Debug version of your program. Use the Trace class if you want output in both the Debug and Release versions.")
        AddTip2("Try setting your project to Release mode and see the difference.")
        AddTip2("Inheritance: See the classes named Employee, EmployeeDataManager, FullTimeEmployee, PartTimeEmployee, and TempEmployee for extensive comments on inheritance, overloading, overriding and scoping.")
    End Sub

#End Region

    Private Sub btnOpenDemoForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenDemoForm.Click
        ' Open a new instance of the form
        Dim frm As New frmControls()
        ' Show it in dialog mode
        frm.ShowDialog()
    End Sub

    Private Sub btnShowGraphics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowGraphics.Click
        Dim frmG As New frmGraphics()
        frmG.ShowDialog()
    End Sub

    Private Sub btnStringBuilderFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStringBuilderFunction.Click
        Dim strSBOrig As String = txtSBOrig.Text.Trim
        Dim strConcatenated As String
        Dim strSBAppend As String = txtSBAppend.Text.Trim
        Dim intStrIterations As Integer = CInt(txtStrIterations.Text)
        Dim intSBIterations As Integer = CInt(txtSBIterations.Text)
        Dim sb As New StringBuilder(strSBAppend.Length * intSBIterations)
        Dim tmr As New TimeCheck()

        Dim i As Integer
        Try
            txtStrResults.Text = vbNullString
            txtSBResults.Text = vbNullString
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            ' Concatenate the VB6 way
            tmr.Begin()
            strConcatenated = strSBOrig
            For i = 1 To intStrIterations
                strConcatenated = strConcatenated & strSBAppend
            Next
            tmr.End()
            txtStrResults.Text = tmr.Milliseconds.ToString()

            ' Now use the StringBuilder
            tmr.Begin()
            For i = 1 To intSBIterations
                sb.Append(strSBAppend)
            Next
            tmr.End()
            txtSBResults.Text = tmr.Milliseconds.ToString()
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, Me.Text)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    ' Accept only numbers in textbox
    Private Sub txtStrIterations_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStrIterations.KeyPress
        Dim KeyStroke As Char
        Dim chrNullCharacter As Char = Chr(0)

        KeyStroke = e.KeyChar
        Select Case KeyStroke
            Case "0"c To "9"c, CChar(vbBack), CChar(vbCr)    ' digits 0-9, backspace, return
                ' These keys are fine, don't do anything
            Case Else
                ' throw everything else away
                KeyStroke = chrNullCharacter
        End Select

        If KeyStroke = chrNullCharacter Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub lstFileFunction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFileFunction.SelectedIndexChanged
        Select Case lstFileFunction.SelectedIndex
            Case 0 ' Reading a file
                btnFileFunction.Text = "&Read file"
            Case 1 ' Writing a file
                btnFileFunction.Text = "&Write file"
            Case 2 ' File Size
                btnFileFunction.Text = "&Get file size"
            Case 3 ' File version info
                btnFileFunction.Text = "&Get file version"
            Case 4 ' Temporary file name
                btnFileFunction.Text = "&Get temp file name"
        End Select
    End Sub

    Private Sub btnFileFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileFunction.Click

        ' File IO is now handled by the classes in the System.IO namespace.
        ' Classes here allow for the reading and writing of files as well
        ' as other streams such as memory streams, network streams etc.

        Dim strFile As String = "..\DemoText.txt"
        Dim strFileWrite As String = "..\DemoText_Write.txt"

        Select Case lstFileFunction.SelectedIndex
            Case 0 ' Reading a file
                Dim srFile As New StreamReader(strFile)
                txtFileResult.Text = srFile.ReadToEnd()
                srFile.Close()
            Case 1 ' Writing a file
                Dim swFile As StreamWriter = File.CreateText(strFileWrite)
                swFile.WriteLine("The quick brown fox jumped over the lazy dogs.")
                swFile.Flush()
                swFile.Close()
                Dim sr As New StreamReader(strFileWrite)
                txtFileResult.Text = sr.ReadToEnd()
                sr.Close()
            Case 2 ' File Size
                Dim fiFile As New FileInfo(strFileWrite)
                txtFileResult.Text = "Size of " & strFileWrite.Substring(InStr("/", strFileWrite)) & ": " & _
                    fiFile.Length.ToString + " bytes."
            Case 3 ' File version info
                ' The environment class contains many useful functions that previously were API calls.
                Dim env As System.Environment
                strFile = env.SystemDirectory & "\Notepad.exe"
                Dim viVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(strFile)
                txtFileResult.Text = "Version of " & strFile & ": " & viVersionInfo.FileVersion & vbCrLf
                txtFileResult.Text &= "Description of " & strFile & ": " & viVersionInfo.FileDescription
            Case 4 ' Temporary file name
                txtFileResult.Text = "Temp file name: " & Path.GetTempFileName
        End Select
    End Sub

    Private Sub lstExceptionHandling_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstExceptionHandling.SelectedIndexChanged
        Select Case lstExceptionHandling.SelectedIndex
            Case 0
                btnExceptionHandlingFunction.Text = "&Basic Exception Handling"
            Case 1
                btnExceptionHandlingFunction.Text = "&Focused Exception Handling"
        End Select
    End Sub

    Private Sub btnExceptionHandlingFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExceptionHandlingFunction.Click
        Select Case lstExceptionHandling.SelectedIndex
            Case 0 ' Basic
                BasicException()
            Case 1 ' Focused
                ExceptionReadingFromFile()
        End Select
    End Sub

    Private Sub BasicException()

        ' Exception Handling takes the place of On Error.  Exception handling is
        ' much more robust and extensible.

        Dim dblNum1 As Double = 5
        Dim dblNum2 As Double = 0
        Dim intResult As Integer
        Try
            intResult = CInt(dblNum1 / dblNum2)
        Catch exp As Exception
            ' Report just the exception message.
            ' exp could be any valid name you choose.
            txtExceptionHandlingResult.Text = exp.Message
        End Try
    End Sub

    Private Sub ExceptionReadingFromFile()
        Try
            ' Try to open the file.
            ' Bad Directory name. 
            Dim sw As New StreamWriter("c:\12345678asdf\baddirectory.txt")
        Catch dirNotFoundEX As DirectoryNotFoundException
            '  You can easily target specific exceptions found in the framework or even
            '  create your own derived from ApplicationException
            '  exp.ToString() provides not only the error message, but much more detail on the exception, including exactly where it occurred.
            txtExceptionHandlingResult.Text = "Message: " & dirNotFoundEX.Message & vbCrLf & vbCrLf
            txtExceptionHandlingResult.Text &= "Stack Trace: " & dirNotFoundEX.StackTrace
        Catch exp As Exception
            ' Catch any other kind of error.
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    ' Use the Debug class if you only want output in the Debug version of your program. 
    ' Use the Trace class if you want output in both the Debug and Release versions."

    Private Sub lstDebugFunction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDebugFunction.SelectedIndexChanged
        Select Case lstDebugFunction.SelectedIndex
            Case 0 ' Debug:
                lstDebugFunction.SelectedIndex = 1
            Case 1 ' Debug: Write to Console
                btnDebugFunction.Text = "&Debug: Write to Console"
            Case 2 ' Debug: Write to File
                btnDebugFunction.Text = "&Debug: Write to File"
            Case 3 ' Debug: Write to Event Log
                btnDebugFunction.Text = "&Debug: Write to Event Log"
            Case 4 ' Trace:
                lstDebugFunction.SelectedIndex = 5
            Case 5 ' Trace: Write to Console
                btnDebugFunction.Text = "&Trace: Write to Console"
            Case 6 ' Trace: Write to File
                btnDebugFunction.Text = "&Trace: Write to File"
            Case 7 ' Trace: Write to Event Log
                btnDebugFunction.Text = "&Trace: Write to Event Log"
        End Select
    End Sub

    Private Sub btnDebugFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDebugFunction.Click
        Dim strDebug As String = txtDebugInfo.Text
        Debug.Indent()

        Select Case lstDebugFunction.SelectedIndex
            Case 0 ' Debug:
            Case 1 ' Debug: Write to Console
                ' Use the default Listener: to Console
                Debug.WriteLine(strDebug)
                Debug.Flush()
                sbrPanel2.Text = "Wrote debug output to console"
            Case 2 ' Debug: Write to File
                ' Create a file for output
                Dim strFile As String = "C:\DebugOutput.txt"
                Dim stmFile As Stream = File.Create(strFile)

                ' Create a new text writer using the output stream, and add it to
                ' the debug listeners. 
                ' For demo purposes, we'll first clear all listeners.
                Dim twTextListener As New TextWriterTraceListener(stmFile)
                With Debug.Listeners
                    .Clear()
                    .Add(twTextListener)
                End With

                ' Write output to the file.
                Debug.Write(strDebug)
                Debug.Flush()
                sbrPanel2.Text = "Wrote debug output to " & strFile
            Case 3 ' Debug: Write to Event Log
                ' Create a debug listener for the event log.
                Dim logdebugListener As New EventLogTraceListener("VB.NET How-To:ContrastVBNETwithVB6")

                ' Add the debug listener to the collection.
                ' For demo purposes, we'll first clear all listeners.
                With Debug.Listeners
                    .Clear()
                    .Add(logdebugListener)
                End With
                Debug.Write(strDebug)
                Debug.Flush()
                sbrPanel2.Text = "Wrote debug output to Event Log"
            Case 4 ' Trace:
            Case 5 ' Trace: Write to Console
                ' Create a custom listener, point it to the Console,
                ' and add it to the listeners collection.
                ' For demo purposes, we'll first clear all listeners.
                With Trace.Listeners
                    .Clear()
                    .Add(New TextWriterTraceListener(Console.Out))
                End With
                Trace.WriteLine("Testing Trace to Console.")
                Console.WriteLine(strDebug)
                Console.WriteLine("Note that the debug/trace strings are indented for ease of reading.")
                Console.WriteLine("Option: Debug.Indent()")
                Trace.WriteLine("Done testing Trace to Console.")
                Trace.Flush()
                sbrPanel2.Text = "Wrote trace output to console"
            Case 6 ' Trace: Write to File
                ' Create a file for output
                Dim strFile As String = "C:\TraceOutput.txt"
                Dim stmFile As Stream = File.Create(strfile)

                ' Create a new text writer using the output stream, and add it to
                ' the trace listeners. 
                Dim twTextListener As New TextWriterTraceListener(stmFile)
                ' For demo purposes, we'll first clear all listeners.
                With Trace.Listeners
                    .Clear()
                    .Add(twTextListener)
                End With
                ' Write output to the file.
                Trace.Write(strDebug)
                Trace.Flush()
                sbrPanel2.Text = "Wrote trace output to " & strFile
            Case 7 ' Trace: Write to Event Log
                ' Create a trace listener for the event log.
                Dim logTraceListener As New EventLogTraceListener("VB.NET How-To:ContrastVBNETwithVB6")

                ' Add the trace listener to the collection.
                ' For demo purposes, we'll first clear all listeners.
                With Trace.Listeners
                    .Clear()
                    .Add(logTraceListener)
                End With
                Trace.Write(strDebug)
                Trace.Flush()
                sbrPanel2.Text = "Wrote trace output to Event Log"
        End Select
        Debug.Unindent()
    End Sub

#Region " Threading tab "

    Private Sub btnThreadFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThreadFunction.Click
        ' Create a thread and send it off to run a particular procedure.
        ' Meanwhile the cuyrrent thread continues its work.
        Dim newThread As New Thread(New ThreadStart(AddressOf CalledByThread))
        newThread.Start()
    End Sub

    ' The procedure called by the new thread.
    Private Sub CalledByThread()
        txtThreadResult.Text = "This method is running on another thread, started at " & DateTime.Now.ToShortTimeString & vbCrLf
        txtThreadResult.Text &= "Gone to sleep for 5 seconds." & vbCrLf
        Thread.Sleep(5000)
        txtThreadResult.Text &= "Now resuming." & vbCrLf
        txtThreadResult.Text &= "Method called by thread now ended."
    End Sub

#End Region

    ' See extensive notes on Inheritance, overriding, overloading and scoping 
    ' in the Employee class and related classes.

    ' Clear the summary textbox.
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim ctl As Control
        cboEmployeeType.SelectedIndex = -1
        For Each ctl In Me.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = vbNullString
            End If
        Next
    End Sub

    ' Hire an employee.
    Private Sub btnHire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHire.Click
        If Not ValidateData() Then
            Return
        End If
        Select Case cboEmployeeType.SelectedIndex
            Case -1
                Exit Sub
            Case 0
                HireFullTimeEmployee()
            Case 1
                HirePartTimeEmployee()
            Case 2
                HireTempEmployee()
        End Select
    End Sub

    ' Save employee info to disk.
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strResult As String

        ' These simulated save-to-database actions use a shared method
        ' of the EmployeeDataManager class.
        Select Case cboEmployeeType.SelectedIndex
            Case -1
                Exit Sub
            Case 0
                strResult = EmployeeDataManager.WriteEmployeeData(c_empFull)
            Case 1
                strResult = EmployeeDataManager.WriteEmployeeData(c_empPart)
            Case 2
                strResult = EmployeeDataManager.WriteEmployeeData(c_empTemp)
        End Select
        MsgBox(strResult, MsgBoxStyle.Information, Me.Text)
    End Sub

    ' This procedure watches for changes in the textboxes and the
    ' combobox, and enables the Hire button only when the textboxes all
    ' have data.
    Private Sub TextBoxes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged, txtHireDate.TextChanged, txtSalary.TextChanged, txtSocialServicesID.TextChanged, txtExpectedTermDate.TextChanged, cboEmployeeType.SelectedIndexChanged
        ' Create an instance of the PartTimeEmployee class which is derived from
        ' Employee.
        Select Case cboEmployeeType.SelectedIndex
            Case -1
                txtName.Enabled = False
                txtHireDate.Enabled = False
                txtSalary.Enabled = False
                txtSocialServicesID.Enabled = False
                txtExpectedTermDate.Enabled = False
            Case 0, 1
                txtName.Enabled = True
                txtHireDate.Enabled = True
                txtSalary.Enabled = True
                txtSocialServicesID.Enabled = True
                txtExpectedTermDate.Enabled = False
            Case 2
                txtName.Enabled = True
                txtHireDate.Enabled = True
                txtSalary.Enabled = True
                txtSocialServicesID.Enabled = True
                txtExpectedTermDate.Enabled = True
        End Select

        btnHire.Enabled = _
            txtName.Text.Trim.Length <> 0 And _
            txtHireDate.Text.Trim.Length <> 0 And _
            txtSalary.Text.Trim.Length <> 0 And _
            txtSocialServicesID.Text.Trim.Length <> 0 And _
            cboEmployeeType.SelectedIndex >= 0

        ' If Temp Employee is chosen, test for text in the ExpectedTermDate text box.
        If cboEmployeeType.SelectedIndex = 2 Then
            btnHire.Enabled = btnHire.Enabled And txtExpectedTermDate.Text.Trim.Length <> 0
        End If
        btnSave.Enabled = False
    End Sub

    Private Sub HireFullTimeEmployee()
        ' Create an instance of the HireFullTimeEmployee class which is derived from
        ' Employee.
        c_empFull = New FullTimeEmployee()
        Try
            With c_empFull
                .Hire(txtName.Text.Trim, CType(txtHireDate.Text.Trim, DateTime), _
                    CType(txtSalary.Text.Trim, Decimal))
                .SocialServicesID = txtSocialServicesID.Text.Trim
                txtResults.Clear()
                txtResults.Text &= "Name: " & .Name & vbCrLf & _
                    "Hire date: " & .HireDate & vbCrLf & _
                    "Salary: " & .Salary & vbCrLf & _
                    "Social Services ID: " & .SocialServicesID & vbCrLf & _
                    "Bonus: " & .Bonus & vbCrLf & _
                    "Annual Leave: " & .AnnualLeave & " days"
            End With
            btnSave.Enabled = True
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub HirePartTimeEmployee()
        ' Create an instance of the PartTimeEmployee class which is derived from
        ' Employee.
        c_empPart = New PartTimeEmployee()
        Try
            With c_empPart
                .Hire(txtName.Text.Trim, CType(txtHireDate.Text.Trim, DateTime), _
                    CType(txtSalary.Text.Trim, Decimal), 20)
                .SocialServicesID = txtSocialServicesID.Text.Trim
                txtResults.Clear()
                txtResults.Text &= "Name: " & .Name & vbCrLf & _
                    "Hire date: " & .HireDate & vbCrLf & _
                    "Salary: " & .Salary & vbCrLf & _
                    "Social Services ID: " & .SocialServicesID & vbCrLf & _
                    "Bonus: " & .Bonus & vbCrLf & _
                    "Min hrs. per week: " & .MinHoursPerWeek
            End With
            btnSave.Enabled = True
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub HireTempEmployee()
        ' Create an instance of the TempEmployee class which is derived from
        ' Employee.
        Dim c_empTemp As New TempEmployee()
        Try
            With c_empTemp
                .Hire(txtName.Text.Trim, CType(txtHireDate.Text.Trim, DateTime), _
                    CType(txtSalary.Text.Trim, Decimal), CType(txtExpectedTermDate.Text.Trim, DateTime))
                .SocialServicesID = txtSocialServicesID.Text.Trim
                txtResults.Clear()
                txtResults.Text &= "Name: " & .Name & vbCrLf & _
                    "Hire date: " & .HireDate & vbCrLf & _
                    "Salary: " & .Salary & vbCrLf & _
                    "Social Services ID: " & .SocialServicesID & vbCrLf & _
                    "Bonus: " & .Bonus & vbCrLf & _
                    "Expected termination date: " & .ExpectedTermDate.ToShortDateString
            End With
            btnSave.Enabled = True
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Function ValidateData() As Boolean

        ' Called by the Hire event handler.  Simply checks to make sure that 
        ' two values HireDate and SocialServicesID are in the correct format.

        Dim dataInValid As Boolean = True

        If Not IsDate(txtHireDate.Text) Then
            MsgBox("Hire Date must be a date in the format MM/DD/YY.", _
                MsgBoxStyle.Exclamation, Me.Text)
            dataInValid = False
        End If

        If txtSocialServicesID.Text.Length <> 11 Then
            MsgBox("Social Services ID must be 11 characters in length", _
             MsgBoxStyle.Exclamation, Me.Text)
            dataInValid = False
        End If

        Return (dataInValid)

    End Function

End Class
