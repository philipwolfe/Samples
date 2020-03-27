'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Environment

Public Class frmMain
	Inherits System.Windows.Forms.Form

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
	Friend WithEvents btnRefreshTickCount As System.Windows.Forms.Button
	Friend WithEvents btnStackTrace As System.Windows.Forms.Button
	Friend WithEvents lblWorkingSet As System.Windows.Forms.Label
	Friend WithEvents Label21 As System.Windows.Forms.Label
	Friend WithEvents lblVersion As System.Windows.Forms.Label
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents lblUserName As System.Windows.Forms.Label
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents lblUserDomainName As System.Windows.Forms.Label
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents lblOSVersion As System.Windows.Forms.Label
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents lblMachineName As System.Windows.Forms.Label
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents lblTickCount As System.Windows.Forms.Label
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents lblSystemDirectory As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents lblCurrentDirectory As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents lblCommandLine As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents lstLogicalDrives As System.Windows.Forms.ListBox
	Friend WithEvents Label12 As System.Windows.Forms.Label
	Friend WithEvents lstCommandLineArgs As System.Windows.Forms.ListBox
	Friend WithEvents Label10 As System.Windows.Forms.Label
	Friend WithEvents btnExpand As System.Windows.Forms.Button
	Friend WithEvents lblExpandResults As System.Windows.Forms.Label
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents txtExpand As System.Windows.Forms.TextBox
	Friend WithEvents nudExitCode As System.Windows.Forms.NumericUpDown
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents btnExit As System.Windows.Forms.Button
	Friend WithEvents lblSystemFolder As System.Windows.Forms.Label
	Friend WithEvents btnGetSystemFolder As System.Windows.Forms.Button
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents lblSpecialFolder As System.Windows.Forms.Label
	Friend WithEvents lstFolders As System.Windows.Forms.ListBox
	Friend WithEvents lblTEMP As System.Windows.Forms.Label
	Friend WithEvents btnGetEnvironmentVariable As System.Windows.Forms.Button
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents lblEnvironmentVariable As System.Windows.Forms.Label
	Friend WithEvents lstEnvironmentVariables As System.Windows.Forms.ListBox
    Friend WithEvents colProperty As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValue As System.Windows.Forms.ColumnHeader
	Friend WithEvents tabExplore As System.Windows.Forms.TabControl
	Friend WithEvents grpMethods As System.Windows.Forms.GroupBox
	Friend WithEvents pgeProperties As System.Windows.Forms.TabPage
	Friend WithEvents pgeMethods As System.Windows.Forms.TabPage
	Friend WithEvents pgeSpecialFolders As System.Windows.Forms.TabPage
	Friend WithEvents pgeEnvironmentVariables As System.Windows.Forms.TabPage
	Friend WithEvents pgeSystemInformation As System.Windows.Forms.TabPage
    Friend WithEvents lvwSystemInformation As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tabExplore = New System.Windows.Forms.TabControl()
        Me.pgeProperties = New System.Windows.Forms.TabPage()
        Me.btnRefreshTickCount = New System.Windows.Forms.Button()
        Me.btnStackTrace = New System.Windows.Forms.Button()
        Me.lblWorkingSet = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblUserDomainName = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblOSVersion = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblTickCount = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblSystemDirectory = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCurrentDirectory = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCommandLine = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pgeMethods = New System.Windows.Forms.TabPage()
        Me.lstLogicalDrives = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lstCommandLineArgs = New System.Windows.Forms.ListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grpMethods = New System.Windows.Forms.GroupBox()
        Me.btnExpand = New System.Windows.Forms.Button()
        Me.lblExpandResults = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtExpand = New System.Windows.Forms.TextBox()
        Me.nudExitCode = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.pgeSpecialFolders = New System.Windows.Forms.TabPage()
        Me.lblSystemFolder = New System.Windows.Forms.Label()
        Me.btnGetSystemFolder = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSpecialFolder = New System.Windows.Forms.Label()
        Me.lstFolders = New System.Windows.Forms.ListBox()
        Me.pgeEnvironmentVariables = New System.Windows.Forms.TabPage()
        Me.lblTEMP = New System.Windows.Forms.Label()
        Me.btnGetEnvironmentVariable = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblEnvironmentVariable = New System.Windows.Forms.Label()
        Me.lstEnvironmentVariables = New System.Windows.Forms.ListBox()
        Me.pgeSystemInformation = New System.Windows.Forms.TabPage()
        Me.lvwSystemInformation = New System.Windows.Forms.ListView()
        Me.colProperty = New System.Windows.Forms.ColumnHeader()
        Me.colValue = New System.Windows.Forms.ColumnHeader()
        Me.tabExplore.SuspendLayout()
        Me.pgeProperties.SuspendLayout()
        Me.pgeMethods.SuspendLayout()
        Me.grpMethods.SuspendLayout()
        CType(Me.nudExitCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgeSpecialFolders.SuspendLayout()
        Me.pgeEnvironmentVariables.SuspendLayout()
        Me.pgeSystemInformation.SuspendLayout()
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
        'tabExplore
        '
        Me.tabExplore.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeProperties, Me.pgeSpecialFolders, Me.pgeMethods, Me.pgeEnvironmentVariables, Me.pgeSystemInformation})
        Me.tabExplore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabExplore.ItemSize = New System.Drawing.Size(59, 18)
        Me.tabExplore.Name = "tabExplore"
        Me.tabExplore.SelectedIndex = 0
        Me.tabExplore.Size = New System.Drawing.Size(554, 308)
        Me.tabExplore.TabIndex = 1
        '
        'pgeProperties
        '
        Me.pgeProperties.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshTickCount, Me.btnStackTrace, Me.lblWorkingSet, Me.Label21, Me.lblVersion, Me.Label19, Me.lblUserName, Me.Label17, Me.lblUserDomainName, Me.Label15, Me.lblOSVersion, Me.Label13, Me.lblMachineName, Me.Label11, Me.lblTickCount, Me.Label9, Me.lblSystemDirectory, Me.Label7, Me.lblCurrentDirectory, Me.Label5, Me.lblCommandLine, Me.Label3})
        Me.pgeProperties.Location = New System.Drawing.Point(4, 22)
        Me.pgeProperties.Name = "pgeProperties"
        Me.pgeProperties.Size = New System.Drawing.Size(546, 282)
        Me.pgeProperties.TabIndex = 2
        Me.pgeProperties.Text = "Properties"
        '
        'btnRefreshTickCount
        '
        Me.btnRefreshTickCount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefreshTickCount.Location = New System.Drawing.Point(285, 129)
        Me.btnRefreshTickCount.Name = "btnRefreshTickCount"
        Me.btnRefreshTickCount.TabIndex = 21
        Me.btnRefreshTickCount.Text = "&Refresh"
        '
        'btnStackTrace
        '
        Me.btnStackTrace.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnStackTrace.Location = New System.Drawing.Point(144, 256)
        Me.btnStackTrace.Name = "btnStackTrace"
        Me.btnStackTrace.Size = New System.Drawing.Size(224, 23)
        Me.btnStackTrace.TabIndex = 20
        Me.btnStackTrace.Text = "&Display Current Stack Trace"
        '
        'lblWorkingSet
        '
        Me.lblWorkingSet.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblWorkingSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWorkingSet.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWorkingSet.Location = New System.Drawing.Point(144, 224)
        Me.lblWorkingSet.Name = "lblWorkingSet"
        Me.lblWorkingSet.Size = New System.Drawing.Size(394, 23)
        Me.lblWorkingSet.TabIndex = 19
        Me.lblWorkingSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(8, 224)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(136, 23)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "WorkingSet"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVersion.Location = New System.Drawing.Point(144, 200)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(394, 23)
        Me.lblVersion.TabIndex = 17
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(8, 200)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(136, 23)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "Version"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUserName.Location = New System.Drawing.Point(144, 176)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(394, 23)
        Me.lblUserName.TabIndex = 15
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(8, 176)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 23)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "UserName"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserDomainName
        '
        Me.lblUserDomainName.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblUserDomainName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUserDomainName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUserDomainName.Location = New System.Drawing.Point(144, 152)
        Me.lblUserDomainName.Name = "lblUserDomainName"
        Me.lblUserDomainName.Size = New System.Drawing.Size(394, 23)
        Me.lblUserDomainName.TabIndex = 13
        Me.lblUserDomainName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(8, 152)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(136, 23)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "UserDomainName"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOSVersion
        '
        Me.lblOSVersion.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblOSVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOSVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOSVersion.Location = New System.Drawing.Point(144, 80)
        Me.lblOSVersion.Name = "lblOSVersion"
        Me.lblOSVersion.Size = New System.Drawing.Size(394, 23)
        Me.lblOSVersion.TabIndex = 11
        Me.lblOSVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(8, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(136, 23)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "OSVersion"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachineName
        '
        Me.lblMachineName.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMachineName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMachineName.Location = New System.Drawing.Point(144, 56)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(394, 23)
        Me.lblMachineName.TabIndex = 9
        Me.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(8, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 23)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "MachineName"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTickCount
        '
        Me.lblTickCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTickCount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTickCount.Location = New System.Drawing.Point(144, 128)
        Me.lblTickCount.Name = "lblTickCount"
        Me.lblTickCount.Size = New System.Drawing.Size(128, 23)
        Me.lblTickCount.TabIndex = 7
        Me.lblTickCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(8, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 23)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "TickCount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSystemDirectory
        '
        Me.lblSystemDirectory.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblSystemDirectory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemDirectory.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSystemDirectory.Location = New System.Drawing.Point(144, 104)
        Me.lblSystemDirectory.Name = "lblSystemDirectory"
        Me.lblSystemDirectory.Size = New System.Drawing.Size(394, 23)
        Me.lblSystemDirectory.TabIndex = 5
        Me.lblSystemDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(8, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 23)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "SystemDirectory"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCurrentDirectory
        '
        Me.lblCurrentDirectory.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblCurrentDirectory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCurrentDirectory.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCurrentDirectory.Location = New System.Drawing.Point(144, 32)
        Me.lblCurrentDirectory.Name = "lblCurrentDirectory"
        Me.lblCurrentDirectory.Size = New System.Drawing.Size(394, 23)
        Me.lblCurrentDirectory.TabIndex = 3
        Me.lblCurrentDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(8, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 23)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "CurrentDirectory"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCommandLine
        '
        Me.lblCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCommandLine.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCommandLine.Location = New System.Drawing.Point(144, 8)
        Me.lblCommandLine.Name = "lblCommandLine"
        Me.lblCommandLine.Size = New System.Drawing.Size(394, 23)
        Me.lblCommandLine.TabIndex = 1
        Me.lblCommandLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CommandLine:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgeMethods
        '
        Me.pgeMethods.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstLogicalDrives, Me.Label12, Me.lstCommandLineArgs, Me.Label10, Me.grpMethods, Me.nudExitCode, Me.Label4, Me.btnExit})
        Me.pgeMethods.Location = New System.Drawing.Point(4, 22)
        Me.pgeMethods.Name = "pgeMethods"
        Me.pgeMethods.Size = New System.Drawing.Size(546, 282)
        Me.pgeMethods.TabIndex = 3
        Me.pgeMethods.Text = "Methods"
        Me.pgeMethods.Visible = False
        '
        'lstLogicalDrives
        '
        Me.lstLogicalDrives.Location = New System.Drawing.Point(16, 152)
        Me.lstLogicalDrives.Name = "lstLogicalDrives"
        Me.lstLogicalDrives.Size = New System.Drawing.Size(56, 95)
        Me.lstLogicalDrives.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(8, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 23)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "GetLogicalDrives"
        '
        'lstCommandLineArgs
        '
        Me.lstCommandLineArgs.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lstCommandLineArgs.HorizontalScrollbar = True
        Me.lstCommandLineArgs.Location = New System.Drawing.Point(144, 152)
        Me.lstCommandLineArgs.Name = "lstCommandLineArgs"
        Me.lstCommandLineArgs.Size = New System.Drawing.Size(386, 95)
        Me.lstCommandLineArgs.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(136, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 23)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "GetCommandLineArgs"
        '
        'grpMethods
        '
        Me.grpMethods.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpMethods.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExpand, Me.lblExpandResults, Me.Label8, Me.Label6, Me.txtExpand})
        Me.grpMethods.Location = New System.Drawing.Point(8, 40)
        Me.grpMethods.Name = "grpMethods"
        Me.grpMethods.Size = New System.Drawing.Size(530, 80)
        Me.grpMethods.TabIndex = 3
        Me.grpMethods.TabStop = False
        Me.grpMethods.Text = "ExpandEnvironmentVariables"
        '
        'btnExpand
        '
        Me.btnExpand.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnExpand.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExpand.Location = New System.Drawing.Point(410, 16)
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(112, 23)
        Me.btnExpand.TabIndex = 2
        Me.btnExpand.Text = "&Expand"
        '
        'lblExpandResults
        '
        Me.lblExpandResults.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblExpandResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblExpandResults.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblExpandResults.Location = New System.Drawing.Point(104, 48)
        Me.lblExpandResults.Name = "lblExpandResults"
        Me.lblExpandResults.Size = New System.Drawing.Size(418, 24)
        Me.lblExpandResults.TabIndex = 4
        Me.lblExpandResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(16, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Results:"
        '
        'Label6
        '
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(16, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Input:"
        '
        'txtExpand
        '
        Me.txtExpand.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtExpand.Location = New System.Drawing.Point(104, 16)
        Me.txtExpand.Name = "txtExpand"
        Me.txtExpand.Size = New System.Drawing.Size(298, 20)
        Me.txtExpand.TabIndex = 1
        Me.txtExpand.Text = "windir = %windir%"
        '
        'nudExitCode
        '
        Me.nudExitCode.Location = New System.Drawing.Point(192, 8)
        Me.nudExitCode.Name = "nudExitCode"
        Me.nudExitCode.Size = New System.Drawing.Size(40, 20)
        Me.nudExitCode.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(104, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Exit &Code:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExit
        '
        Me.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExit.Location = New System.Drawing.Point(8, 8)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 24)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "E&xit"
        '
        'pgeSpecialFolders
        '
        Me.pgeSpecialFolders.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSystemFolder, Me.btnGetSystemFolder, Me.Label1, Me.lblSpecialFolder, Me.lstFolders})
        Me.pgeSpecialFolders.Location = New System.Drawing.Point(4, 22)
        Me.pgeSpecialFolders.Name = "pgeSpecialFolders"
        Me.pgeSpecialFolders.Size = New System.Drawing.Size(546, 282)
        Me.pgeSpecialFolders.TabIndex = 0
        Me.pgeSpecialFolders.Text = "Special Folders"
        Me.pgeSpecialFolders.Visible = False
        '
        'lblSystemFolder
        '
        Me.lblSystemFolder.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblSystemFolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSystemFolder.Location = New System.Drawing.Point(224, 168)
        Me.lblSystemFolder.Name = "lblSystemFolder"
        Me.lblSystemFolder.Size = New System.Drawing.Size(314, 23)
        Me.lblSystemFolder.TabIndex = 4
        Me.lblSystemFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGetSystemFolder
        '
        Me.btnGetSystemFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGetSystemFolder.Location = New System.Drawing.Point(224, 144)
        Me.btnGetSystemFolder.Name = "btnGetSystemFolder"
        Me.btnGetSystemFolder.Size = New System.Drawing.Size(152, 23)
        Me.btnGetSystemFolder.TabIndex = 3
        Me.btnGetSystemFolder.Text = "&Get System Folder"
        '
        'Label1
        '
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(224, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Special Folder Path:"
        '
        'lblSpecialFolder
        '
        Me.lblSpecialFolder.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblSpecialFolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSpecialFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSpecialFolder.Location = New System.Drawing.Point(224, 32)
        Me.lblSpecialFolder.Name = "lblSpecialFolder"
        Me.lblSpecialFolder.Size = New System.Drawing.Size(314, 96)
        Me.lblSpecialFolder.TabIndex = 2
        '
        'lstFolders
        '
        Me.lstFolders.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.lstFolders.Location = New System.Drawing.Point(8, 8)
        Me.lstFolders.Name = "lstFolders"
        Me.lstFolders.Size = New System.Drawing.Size(208, 251)
        Me.lstFolders.TabIndex = 0
        '
        'pgeEnvironmentVariables
        '
        Me.pgeEnvironmentVariables.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTEMP, Me.btnGetEnvironmentVariable, Me.Label2, Me.lblEnvironmentVariable, Me.lstEnvironmentVariables})
        Me.pgeEnvironmentVariables.Location = New System.Drawing.Point(4, 22)
        Me.pgeEnvironmentVariables.Name = "pgeEnvironmentVariables"
        Me.pgeEnvironmentVariables.Size = New System.Drawing.Size(546, 282)
        Me.pgeEnvironmentVariables.TabIndex = 1
        Me.pgeEnvironmentVariables.Text = "Environment Variables"
        Me.pgeEnvironmentVariables.Visible = False
        '
        'lblTEMP
        '
        Me.lblTEMP.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTEMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTEMP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTEMP.Location = New System.Drawing.Point(224, 168)
        Me.lblTEMP.Name = "lblTEMP"
        Me.lblTEMP.Size = New System.Drawing.Size(314, 23)
        Me.lblTEMP.TabIndex = 4
        Me.lblTEMP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGetEnvironmentVariable
        '
        Me.btnGetEnvironmentVariable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGetEnvironmentVariable.Location = New System.Drawing.Point(224, 144)
        Me.btnGetEnvironmentVariable.Name = "btnGetEnvironmentVariable"
        Me.btnGetEnvironmentVariable.Size = New System.Drawing.Size(152, 23)
        Me.btnGetEnvironmentVariable.TabIndex = 3
        Me.btnGetEnvironmentVariable.Text = "&Get TEMP Variable"
        '
        'Label2
        '
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(224, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Environment Variable Value:"
        '
        'lblEnvironmentVariable
        '
        Me.lblEnvironmentVariable.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblEnvironmentVariable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEnvironmentVariable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEnvironmentVariable.Location = New System.Drawing.Point(224, 32)
        Me.lblEnvironmentVariable.Name = "lblEnvironmentVariable"
        Me.lblEnvironmentVariable.Size = New System.Drawing.Size(314, 96)
        Me.lblEnvironmentVariable.TabIndex = 2
        '
        'lstEnvironmentVariables
        '
        Me.lstEnvironmentVariables.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.lstEnvironmentVariables.Location = New System.Drawing.Point(8, 8)
        Me.lstEnvironmentVariables.Name = "lstEnvironmentVariables"
        Me.lstEnvironmentVariables.Size = New System.Drawing.Size(208, 251)
        Me.lstEnvironmentVariables.TabIndex = 0
        '
        'pgeSystemInformation
        '
        Me.pgeSystemInformation.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvwSystemInformation})
        Me.pgeSystemInformation.Location = New System.Drawing.Point(4, 22)
        Me.pgeSystemInformation.Name = "pgeSystemInformation"
        Me.pgeSystemInformation.Size = New System.Drawing.Size(546, 282)
        Me.pgeSystemInformation.TabIndex = 4
        Me.pgeSystemInformation.Text = "System Information"
        Me.pgeSystemInformation.Visible = False
        '
        'lvwSystemInformation
        '
        Me.lvwSystemInformation.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colProperty, Me.colValue})
        Me.lvwSystemInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwSystemInformation.Name = "lvwSystemInformation"
        Me.lvwSystemInformation.Size = New System.Drawing.Size(546, 282)
        Me.lvwSystemInformation.TabIndex = 0
        Me.lvwSystemInformation.View = System.Windows.Forms.View.Details
        '
        'colProperty
        '
        Me.colProperty.Text = "Property"
        Me.colProperty.Width = 117
        '
        'colValue
        '
        Me.colValue.Text = "Value"
        Me.colValue.Width = 341
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(554, 308)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabExplore})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.tabExplore.ResumeLayout(False)
        Me.pgeProperties.ResumeLayout(False)
        Me.pgeMethods.ResumeLayout(False)
        Me.grpMethods.ResumeLayout(False)
        CType(Me.nudExitCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgeSpecialFolders.ResumeLayout(False)
        Me.pgeEnvironmentVariables.ResumeLayout(False)
        Me.pgeSystemInformation.ResumeLayout(False)
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

#Region " Enum Handling "
	Private Sub LoadList(ByVal lst As ListBox, ByVal typ As Type)
		lst.DataSource = System.Enum.GetNames(typ)
	End Sub

	Private Function GetSpecialFolderFromList() As Environment.SpecialFolder
		' lstFolders.SelectedItem returns the name of the 
		' special folder. System.Enum.Parse will turn that
		' into an object corresponding to the enumerated value
		' matching the specific text. CType then converts the
		' object into an Environment.SpecialFolder object.
		' This is all required because Option Strict is on.
		Return CType( _
		System.Enum.Parse(GetType(Environment.SpecialFolder), _
		lstFolders.SelectedItem.ToString), _
		Environment.SpecialFolder)
	End Function

	Private Sub LoadList(ByVal lst As ListBox, ByVal ic As ICollection)
		' This procedure sets the data source 
		' for a list box to be the contents
		' of an object that implements
		' the ICollection interface. You must
		' first copy the contents to something
		' that implements IList (such as an array)
		' and then bind to that.
		Dim astrItems(ic.Count - 1) As String
		ic.CopyTo(astrItems, 0)
		lst.DataSource = astrItems
	End Sub
#End Region

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Environment.Exit(CInt(nudExitCode.Value))
	End Sub

	Private Sub btnExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpand.Click
		lblExpandResults.Text = Environment.ExpandEnvironmentVariables(txtExpand.Text)
	End Sub

	Private Sub btnGetEnvironmentVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetEnvironmentVariable.Click
		lblTEMP.Text = Environment.GetEnvironmentVariable("TEMP")
	End Sub

	Private Sub btnGetSystemFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSystemFolder.Click
		' If you just want to retrieve a single 
		' special folder path, pass in one of the
		' SpecialFolder enumeration values.
		' GetFolderPath is actually System.Environment.GetFolderPath.
		' See the Imports statement at the top of this file.
		lblSystemFolder.Text = GetFolderPath(SpecialFolder.System)
	End Sub

	Private Sub btnRefreshTickCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshTickCount.Click
		lblTickCount.Text = Environment.TickCount.ToString
	End Sub

	Private Sub btnStackTrace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStackTrace.Click
		Try
			MsgBox(Environment.StackTrace, MsgBoxStyle.OKOnly, Me.Text)
		Catch exp As System.Security.SecurityException
			MsgBox("A security exception occurred." & vbCrLf & exp.Message, MsgBoxStyle.Critical, exp.Source)
		Catch exp As System.Exception
			MsgBox("An unexpected error occurred accessing the StackTrace." & vbCrLf & exp.Message, MsgBoxStyle.Critical, exp.Source)
		End Try
	End Sub

	Private Sub frmEnvironment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' The LoadList procedure is in 
		' the "Enum Handling" region above.
		' It loads a list box with all the 
		' elements of an enumeration. If you're
		' interested, give it a look. You could load
		' the list with items one at a time, but this
		' technique is far simpler.
		LoadList(lstFolders, GetType(Environment.SpecialFolder))

		' LoadList (in the "Enum Handling" 
		' region) also loads a list box given
		' an ICollection object. The alternative would be 
		' to loop through all the elements of the collection.
		LoadList(lstEnvironmentVariables, GetEnvironmentVariables.Keys)

		' Display properties on the Properties tab.
		LoadProperties()

		' Set up simple methods.
		RunMethods()

		' Load values from SystemInformation class
		LoadSystemInformation()
	End Sub

	Private Sub lstEnvironmentVariables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEnvironmentVariables.SelectedIndexChanged
		' GetEnvironmentVariable is actually 
		' System.Environment.GetEnvironmentVariable.
		' lstEnvironmentVariables contains a list
		' of all the current environment variables.
		' GetEnvironmentVariable returns the value
		' associated with an environment variable.
		lblEnvironmentVariable.Text = _
		GetEnvironmentVariable(lstEnvironmentVariables.SelectedItem.ToString)
	End Sub

	Private Sub lstFolders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFolders.SelectedIndexChanged
		Dim sf As Environment.SpecialFolder

		' GetSpecialFolderFromList is a method
		' in the hidden "Enum Handling" region 
		' above. It returns a member of the
		' Environment.SpecialFolder enumeration, 
		' and is specific to this demonstration.
		sf = GetSpecialFolderFromList()

		' GetFolderPath is a method provided by 
		' the System.Environment namespace.

		' Specifically, you could call the GetFolderPath
		' method like this:
		' YourPath = GetFolderPath(SpecialFolder.Favorites)

		' GetFolderPath is actually System.Environment.GetFolderPath.
		' See the Imports statement at the top of this file.
		lblSpecialFolder.Text = GetFolderPath(sf)
	End Sub

    Private Sub lvwSystemInformation_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSystemInformation.Resize
		lvwSystemInformation.Columns(1).Width = _
		lvwSystemInformation.ClientRectangle.Width - lvwSystemInformation.Columns(0).Width
    End Sub

    Private Sub LoadProperties()
        ' This procedure fills in items
        ' on the Properties tab. These are
        ' most of the properties provided by the 
        ' Environment class.
        lblWorkingSet.Text = Environment.WorkingSet.ToString
        lblVersion.Text = Environment.Version.ToString
        lblUserName.Text = Environment.UserName
        lblUserDomainName.Text = Environment.UserDomainName
        lblTickCount.Text = Environment.TickCount.ToString
        lblSystemDirectory.Text = Environment.SystemDirectory
        lblOSVersion.Text = Environment.OSVersion.ToString
        lblMachineName.Text = Environment.MachineName
        lblCurrentDirectory.Text = Environment.CurrentDirectory
        lblCommandLine.Text = Environment.CommandLine
    End Sub

    Private Sub LoadSystemInformation()
        ' Add information about the Shared properties
        ' of the SystemInformation class to a ListView control.
        ' The text for the item is the name 
        ' of the property provided by the 
        ' SystemInformation class. The first (and only)
        ' subitem is the value of the property.
        ' See help on the SystemInformation class
        ' for more details about each individual 
        ' property.
        With lvwSystemInformation.Items.Add("ArrangeDirection")
            .SubItems.Add(SystemInformation.ArrangeDirection.ToString())
        End With
        With lvwSystemInformation.Items.Add("ArrangeStartingPosition")
            .SubItems.Add(SystemInformation.ArrangeStartingPosition.ToString())
        End With
        With lvwSystemInformation.Items.Add("BootMode")
            .SubItems.Add(SystemInformation.BootMode.ToString())
        End With
        With lvwSystemInformation.Items.Add("Border3DSize")
            .SubItems.Add(SystemInformation.Border3DSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("BorderSize")
            .SubItems.Add(SystemInformation.BorderSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("CaptionButtonSize")
            .SubItems.Add(SystemInformation.CaptionButtonSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("CaptionHeight")
            .SubItems.Add(SystemInformation.CaptionHeight.ToString())
        End With
        With lvwSystemInformation.Items.Add("ComputerName")
            .SubItems.Add(SystemInformation.ComputerName.ToString())
        End With
        With lvwSystemInformation.Items.Add("CursorSize")
            .SubItems.Add(SystemInformation.CursorSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("DbcsEnabled")
            .SubItems.Add(SystemInformation.DbcsEnabled.ToString())
        End With
        With lvwSystemInformation.Items.Add("DebugOS")
            .SubItems.Add(SystemInformation.DebugOS.ToString())
        End With
        With lvwSystemInformation.Items.Add("DoubleClickSize")
            .SubItems.Add(SystemInformation.DoubleClickSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("DoubleClickTime")
            .SubItems.Add(SystemInformation.DoubleClickTime.ToString())
        End With
        With lvwSystemInformation.Items.Add("DragFullWindows")
            .SubItems.Add(SystemInformation.DragFullWindows.ToString())
        End With
        With lvwSystemInformation.Items.Add("DragSize")
            .SubItems.Add(SystemInformation.DragSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("FixedFrameBorderSize")
            .SubItems.Add(SystemInformation.FixedFrameBorderSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("FrameBorderSize")
            .SubItems.Add(SystemInformation.FrameBorderSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("HighContrast")
            .SubItems.Add(SystemInformation.HighContrast.ToString())
        End With
        With lvwSystemInformation.Items.Add("HorizontalScrollBarArrowWidth")
            .SubItems.Add(SystemInformation.HorizontalScrollBarArrowWidth.ToString())
        End With
        With lvwSystemInformation.Items.Add("HorizontalScrollBarHeight")
            .SubItems.Add(SystemInformation.HorizontalScrollBarHeight.ToString())
        End With
        With lvwSystemInformation.Items.Add("HorizontalScrollBarThumbWidth")
            .SubItems.Add(SystemInformation.HorizontalScrollBarThumbWidth.ToString())
        End With
        With lvwSystemInformation.Items.Add("IconSize")
            .SubItems.Add(SystemInformation.IconSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("IconSpacingSize")
            .SubItems.Add(SystemInformation.IconSpacingSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("KanjiWindowHeight")
            .SubItems.Add(SystemInformation.KanjiWindowHeight.ToString())
        End With
        With lvwSystemInformation.Items.Add("MaxWindowTrackSize")
            .SubItems.Add(SystemInformation.MaxWindowTrackSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("MenuButtonSize")
            .SubItems.Add(SystemInformation.MenuButtonSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("MenuCheckSize")
            .SubItems.Add(SystemInformation.MenuCheckSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("MenuFont")
            .SubItems.Add(SystemInformation.MenuFont.ToString())
        End With
        With lvwSystemInformation.Items.Add("MenuHeight")
            .SubItems.Add(SystemInformation.MenuHeight.ToString())
        End With
        With lvwSystemInformation.Items.Add("MidEastEnabled")
            .SubItems.Add(SystemInformation.MidEastEnabled.ToString())
        End With
        With lvwSystemInformation.Items.Add("MinimizedWindowSize")
            .SubItems.Add(SystemInformation.MinimizedWindowSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("MinimizedWindowSpacingSize")
            .SubItems.Add(SystemInformation.MinimizedWindowSpacingSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("MinimumWindowSize")
            .SubItems.Add(SystemInformation.MinimumWindowSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("MinWindowTrackSize")
            .SubItems.Add(SystemInformation.MinWindowTrackSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("MonitorCount")
            .SubItems.Add(SystemInformation.MonitorCount.ToString())
        End With
        With lvwSystemInformation.Items.Add("MonitorsSameDisplayFormat")
            .SubItems.Add(SystemInformation.MonitorsSameDisplayFormat.ToString())
        End With
        With lvwSystemInformation.Items.Add("MouseButtons")
            .SubItems.Add(SystemInformation.MouseButtons.ToString())
        End With
        With lvwSystemInformation.Items.Add("MouseButtonsSwapped")
            .SubItems.Add(SystemInformation.MouseButtonsSwapped.ToString())
        End With
        With lvwSystemInformation.Items.Add("MousePresent")
            .SubItems.Add(SystemInformation.MousePresent.ToString())
        End With
        With lvwSystemInformation.Items.Add("MouseWheelPresent")
            .SubItems.Add(SystemInformation.MouseWheelPresent.ToString())
        End With
        With lvwSystemInformation.Items.Add("MouseWheelScrollLines")
            .SubItems.Add(SystemInformation.MouseWheelScrollLines.ToString())
        End With
        With lvwSystemInformation.Items.Add("NativeMouseWheelSupport")
            .SubItems.Add(SystemInformation.NativeMouseWheelSupport.ToString())
        End With
        With lvwSystemInformation.Items.Add("Network")
            .SubItems.Add(SystemInformation.Network.ToString())
        End With
        With lvwSystemInformation.Items.Add("PenWindows")
            .SubItems.Add(SystemInformation.PenWindows.ToString())
        End With
        With lvwSystemInformation.Items.Add("PrimaryMonitorMaximizedWindowSize")
            .SubItems.Add(SystemInformation.PrimaryMonitorMaximizedWindowSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("PrimaryMonitorSize")
            .SubItems.Add(SystemInformation.PrimaryMonitorSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("RightAlignedMenus")
            .SubItems.Add(SystemInformation.RightAlignedMenus.ToString())
        End With
        With lvwSystemInformation.Items.Add("Secure")
            .SubItems.Add(SystemInformation.Secure.ToString())
        End With
        With lvwSystemInformation.Items.Add("ShowSounds")
            .SubItems.Add(SystemInformation.ShowSounds.ToString())
        End With
        With lvwSystemInformation.Items.Add("SmallIconSize")
            .SubItems.Add(SystemInformation.SmallIconSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("ToolWindowCaptionButtonSize")
            .SubItems.Add(SystemInformation.ToolWindowCaptionButtonSize.ToString())
        End With
        With lvwSystemInformation.Items.Add("ToolWindowCaptionHeight")
            .SubItems.Add(SystemInformation.ToolWindowCaptionHeight.ToString())
        End With
        With lvwSystemInformation.Items.Add("UserDomainName")
            .SubItems.Add(SystemInformation.UserDomainName.ToString())
        End With
        With lvwSystemInformation.Items.Add("UserInteractive")
            .SubItems.Add(SystemInformation.UserInteractive.ToString())
        End With
        With lvwSystemInformation.Items.Add("UserName")
            .SubItems.Add(SystemInformation.UserName.ToString())
        End With
        With lvwSystemInformation.Items.Add("VerticalScrollBarArrowHeight")
            .SubItems.Add(SystemInformation.VerticalScrollBarArrowHeight.ToString())
        End With
        With lvwSystemInformation.Items.Add("VerticalScrollBarThumbHeight")
            .SubItems.Add(SystemInformation.VerticalScrollBarThumbHeight.ToString())
        End With
        With lvwSystemInformation.Items.Add("VerticalScrollBarWidth")
            .SubItems.Add(SystemInformation.VerticalScrollBarWidth.ToString())
        End With
        With lvwSystemInformation.Items.Add("VirtualScreen")
            .SubItems.Add(SystemInformation.VirtualScreen.ToString())
        End With
        With lvwSystemInformation.Items.Add("WorkingArea")
			.SubItems.Add(SystemInformation.WorkingArea.ToString())
		End With
	End Sub

	Private Sub RunMethods()
		' Environment.GetLogicalDrives returns an 
		' array of drive names. You can iterate
		' through the array just like you would with 
		' any other array, or you can use the array
		' as the data source for a list, as seen here.

		' Once you have a list of drives, you might
		' want to retrieve information about the files
		' on those drives. See the File and Directory
		' classes for more infomation on working 
		' with those logical entities.
		lstLogicalDrives.DataSource = _
		Environment.GetLogicalDrives()

		lstCommandLineArgs.DataSource = _
		Environment.GetCommandLineArgs()
	End Sub

End Class