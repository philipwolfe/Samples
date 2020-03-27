'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Text

Public Class frmMain
	Inherits System.Windows.Forms.Form

    ' Declare necessary class variables.
    Private m_CommPort As New Rs232()
    Private m_IsModemFound As Boolean = False
    Private m_ModemPort As Integer = 0

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
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents tmrReadCommPort As System.Windows.Forms.Timer
    Friend WithEvents clstPorts As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnCheckForPorts As System.Windows.Forms.Button
    Friend WithEvents btnCheckModems As System.Windows.Forms.Button
    Friend WithEvents txtSelectedModem As System.Windows.Forms.TextBox
    Friend WithEvents btnSendATCommand As System.Windows.Forms.Button
    Friend WithEvents txtUserCommand As System.Windows.Forms.TextBox
    Friend WithEvents btnSendUserCommand As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnCheckForPorts = New System.Windows.Forms.Button()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.tmrReadCommPort = New System.Windows.Forms.Timer(Me.components)
        Me.clstPorts = New System.Windows.Forms.CheckedListBox()
        Me.btnCheckModems = New System.Windows.Forms.Button()
        Me.txtSelectedModem = New System.Windows.Forms.TextBox()
        Me.btnSendATCommand = New System.Windows.Forms.Button()
        Me.btnSendUserCommand = New System.Windows.Forms.Button()
        Me.txtUserCommand = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'mnuFile
        '
        Me.mnuFile.Enabled = CType(resources.GetObject("mnuFile.Enabled"), Boolean)
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Shortcut = CType(resources.GetObject("mnuFile.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuFile.ShowShortcut = CType(resources.GetObject("mnuFile.ShowShortcut"), Boolean)
        Me.mnuFile.Text = resources.GetString("mnuFile.Text")
        Me.mnuFile.Visible = CType(resources.GetObject("mnuFile.Visible"), Boolean)
        '
        'mnuExit
        '
        Me.mnuExit.Enabled = CType(resources.GetObject("mnuExit.Enabled"), Boolean)
        Me.mnuExit.Index = 0
        Me.mnuExit.Shortcut = CType(resources.GetObject("mnuExit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuExit.ShowShortcut = CType(resources.GetObject("mnuExit.ShowShortcut"), Boolean)
        Me.mnuExit.Text = resources.GetString("mnuExit.Text")
        Me.mnuExit.Visible = CType(resources.GetObject("mnuExit.Visible"), Boolean)
        '
        'mnuHelp
        '
        Me.mnuHelp.Enabled = CType(resources.GetObject("mnuHelp.Enabled"), Boolean)
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Shortcut = CType(resources.GetObject("mnuHelp.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuHelp.ShowShortcut = CType(resources.GetObject("mnuHelp.ShowShortcut"), Boolean)
        Me.mnuHelp.Text = resources.GetString("mnuHelp.Text")
        Me.mnuHelp.Visible = CType(resources.GetObject("mnuHelp.Visible"), Boolean)
        '
        'mnuAbout
        '
        Me.mnuAbout.Enabled = CType(resources.GetObject("mnuAbout.Enabled"), Boolean)
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Shortcut = CType(resources.GetObject("mnuAbout.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuAbout.ShowShortcut = CType(resources.GetObject("mnuAbout.ShowShortcut"), Boolean)
        Me.mnuAbout.Text = resources.GetString("mnuAbout.Text")
        Me.mnuAbout.Visible = CType(resources.GetObject("mnuAbout.Visible"), Boolean)
        '
        'btnCheckForPorts
        '
        Me.btnCheckForPorts.AccessibleDescription = resources.GetString("btnCheckForPorts.AccessibleDescription")
        Me.btnCheckForPorts.AccessibleName = resources.GetString("btnCheckForPorts.AccessibleName")
        Me.btnCheckForPorts.Anchor = CType(resources.GetObject("btnCheckForPorts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCheckForPorts.BackgroundImage = CType(resources.GetObject("btnCheckForPorts.BackgroundImage"), System.Drawing.Image)
        Me.btnCheckForPorts.Dock = CType(resources.GetObject("btnCheckForPorts.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCheckForPorts.Enabled = CType(resources.GetObject("btnCheckForPorts.Enabled"), Boolean)
        Me.btnCheckForPorts.FlatStyle = CType(resources.GetObject("btnCheckForPorts.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCheckForPorts.Font = CType(resources.GetObject("btnCheckForPorts.Font"), System.Drawing.Font)
        Me.btnCheckForPorts.Image = CType(resources.GetObject("btnCheckForPorts.Image"), System.Drawing.Image)
        Me.btnCheckForPorts.ImageAlign = CType(resources.GetObject("btnCheckForPorts.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCheckForPorts.ImageIndex = CType(resources.GetObject("btnCheckForPorts.ImageIndex"), Integer)
        Me.btnCheckForPorts.ImeMode = CType(resources.GetObject("btnCheckForPorts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCheckForPorts.Location = CType(resources.GetObject("btnCheckForPorts.Location"), System.Drawing.Point)
        Me.btnCheckForPorts.Name = "btnCheckForPorts"
        Me.btnCheckForPorts.RightToLeft = CType(resources.GetObject("btnCheckForPorts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCheckForPorts.Size = CType(resources.GetObject("btnCheckForPorts.Size"), System.Drawing.Size)
        Me.btnCheckForPorts.TabIndex = CType(resources.GetObject("btnCheckForPorts.TabIndex"), Integer)
        Me.btnCheckForPorts.Text = resources.GetString("btnCheckForPorts.Text")
        Me.btnCheckForPorts.TextAlign = CType(resources.GetObject("btnCheckForPorts.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCheckForPorts.Visible = CType(resources.GetObject("btnCheckForPorts.Visible"), Boolean)
        '
        'txtStatus
        '
        Me.txtStatus.AccessibleDescription = resources.GetString("txtStatus.AccessibleDescription")
        Me.txtStatus.AccessibleName = resources.GetString("txtStatus.AccessibleName")
        Me.txtStatus.Anchor = CType(resources.GetObject("txtStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.AutoSize = CType(resources.GetObject("txtStatus.AutoSize"), Boolean)
        Me.txtStatus.BackgroundImage = CType(resources.GetObject("txtStatus.BackgroundImage"), System.Drawing.Image)
        Me.txtStatus.Dock = CType(resources.GetObject("txtStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.txtStatus.Enabled = CType(resources.GetObject("txtStatus.Enabled"), Boolean)
        Me.txtStatus.Font = CType(resources.GetObject("txtStatus.Font"), System.Drawing.Font)
        Me.txtStatus.ImeMode = CType(resources.GetObject("txtStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtStatus.Location = CType(resources.GetObject("txtStatus.Location"), System.Drawing.Point)
        Me.txtStatus.MaxLength = CType(resources.GetObject("txtStatus.MaxLength"), Integer)
        Me.txtStatus.Multiline = CType(resources.GetObject("txtStatus.Multiline"), Boolean)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.PasswordChar = CType(resources.GetObject("txtStatus.PasswordChar"), Char)
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.RightToLeft = CType(resources.GetObject("txtStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtStatus.ScrollBars = CType(resources.GetObject("txtStatus.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtStatus.Size = CType(resources.GetObject("txtStatus.Size"), System.Drawing.Size)
        Me.txtStatus.TabIndex = CType(resources.GetObject("txtStatus.TabIndex"), Integer)
        Me.txtStatus.Text = resources.GetString("txtStatus.Text")
        Me.txtStatus.TextAlign = CType(resources.GetObject("txtStatus.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtStatus.Visible = CType(resources.GetObject("txtStatus.Visible"), Boolean)
        Me.txtStatus.WordWrap = CType(resources.GetObject("txtStatus.WordWrap"), Boolean)
        '
        'tmrReadCommPort
        '
        '
        'clstPorts
        '
        Me.clstPorts.AccessibleDescription = resources.GetString("clstPorts.AccessibleDescription")
        Me.clstPorts.AccessibleName = resources.GetString("clstPorts.AccessibleName")
        Me.clstPorts.Anchor = CType(resources.GetObject("clstPorts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.clstPorts.BackgroundImage = CType(resources.GetObject("clstPorts.BackgroundImage"), System.Drawing.Image)
        Me.clstPorts.ColumnWidth = CType(resources.GetObject("clstPorts.ColumnWidth"), Integer)
        Me.clstPorts.Dock = CType(resources.GetObject("clstPorts.Dock"), System.Windows.Forms.DockStyle)
        Me.clstPorts.Enabled = CType(resources.GetObject("clstPorts.Enabled"), Boolean)
        Me.clstPorts.Font = CType(resources.GetObject("clstPorts.Font"), System.Drawing.Font)
        Me.clstPorts.HorizontalExtent = CType(resources.GetObject("clstPorts.HorizontalExtent"), Integer)
        Me.clstPorts.HorizontalScrollbar = CType(resources.GetObject("clstPorts.HorizontalScrollbar"), Boolean)
        Me.clstPorts.ImeMode = CType(resources.GetObject("clstPorts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.clstPorts.IntegralHeight = CType(resources.GetObject("clstPorts.IntegralHeight"), Boolean)
        Me.clstPorts.Items.AddRange(New Object() {resources.GetString("clstPorts.Items.Items"), resources.GetString("clstPorts.Items.Items1"), resources.GetString("clstPorts.Items.Items2"), resources.GetString("clstPorts.Items.Items3")})
        Me.clstPorts.Location = CType(resources.GetObject("clstPorts.Location"), System.Drawing.Point)
        Me.clstPorts.Name = "clstPorts"
        Me.clstPorts.RightToLeft = CType(resources.GetObject("clstPorts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.clstPorts.ScrollAlwaysVisible = CType(resources.GetObject("clstPorts.ScrollAlwaysVisible"), Boolean)
        Me.clstPorts.Size = CType(resources.GetObject("clstPorts.Size"), System.Drawing.Size)
        Me.clstPorts.TabIndex = CType(resources.GetObject("clstPorts.TabIndex"), Integer)
        Me.clstPorts.TabStop = False
        Me.clstPorts.Visible = CType(resources.GetObject("clstPorts.Visible"), Boolean)
        '
        'btnCheckModems
        '
        Me.btnCheckModems.AccessibleDescription = resources.GetString("btnCheckModems.AccessibleDescription")
        Me.btnCheckModems.AccessibleName = resources.GetString("btnCheckModems.AccessibleName")
        Me.btnCheckModems.Anchor = CType(resources.GetObject("btnCheckModems.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCheckModems.BackgroundImage = CType(resources.GetObject("btnCheckModems.BackgroundImage"), System.Drawing.Image)
        Me.btnCheckModems.Dock = CType(resources.GetObject("btnCheckModems.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCheckModems.Enabled = CType(resources.GetObject("btnCheckModems.Enabled"), Boolean)
        Me.btnCheckModems.FlatStyle = CType(resources.GetObject("btnCheckModems.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCheckModems.Font = CType(resources.GetObject("btnCheckModems.Font"), System.Drawing.Font)
        Me.btnCheckModems.Image = CType(resources.GetObject("btnCheckModems.Image"), System.Drawing.Image)
        Me.btnCheckModems.ImageAlign = CType(resources.GetObject("btnCheckModems.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCheckModems.ImageIndex = CType(resources.GetObject("btnCheckModems.ImageIndex"), Integer)
        Me.btnCheckModems.ImeMode = CType(resources.GetObject("btnCheckModems.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCheckModems.Location = CType(resources.GetObject("btnCheckModems.Location"), System.Drawing.Point)
        Me.btnCheckModems.Name = "btnCheckModems"
        Me.btnCheckModems.RightToLeft = CType(resources.GetObject("btnCheckModems.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCheckModems.Size = CType(resources.GetObject("btnCheckModems.Size"), System.Drawing.Size)
        Me.btnCheckModems.TabIndex = CType(resources.GetObject("btnCheckModems.TabIndex"), Integer)
        Me.btnCheckModems.Text = resources.GetString("btnCheckModems.Text")
        Me.btnCheckModems.TextAlign = CType(resources.GetObject("btnCheckModems.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCheckModems.Visible = CType(resources.GetObject("btnCheckModems.Visible"), Boolean)
        '
        'txtSelectedModem
        '
        Me.txtSelectedModem.AccessibleDescription = resources.GetString("txtSelectedModem.AccessibleDescription")
        Me.txtSelectedModem.AccessibleName = resources.GetString("txtSelectedModem.AccessibleName")
        Me.txtSelectedModem.Anchor = CType(resources.GetObject("txtSelectedModem.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtSelectedModem.AutoSize = CType(resources.GetObject("txtSelectedModem.AutoSize"), Boolean)
        Me.txtSelectedModem.BackgroundImage = CType(resources.GetObject("txtSelectedModem.BackgroundImage"), System.Drawing.Image)
        Me.txtSelectedModem.Dock = CType(resources.GetObject("txtSelectedModem.Dock"), System.Windows.Forms.DockStyle)
        Me.txtSelectedModem.Enabled = CType(resources.GetObject("txtSelectedModem.Enabled"), Boolean)
        Me.txtSelectedModem.Font = CType(resources.GetObject("txtSelectedModem.Font"), System.Drawing.Font)
        Me.txtSelectedModem.ImeMode = CType(resources.GetObject("txtSelectedModem.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtSelectedModem.Location = CType(resources.GetObject("txtSelectedModem.Location"), System.Drawing.Point)
        Me.txtSelectedModem.MaxLength = CType(resources.GetObject("txtSelectedModem.MaxLength"), Integer)
        Me.txtSelectedModem.Multiline = CType(resources.GetObject("txtSelectedModem.Multiline"), Boolean)
        Me.txtSelectedModem.Name = "txtSelectedModem"
        Me.txtSelectedModem.PasswordChar = CType(resources.GetObject("txtSelectedModem.PasswordChar"), Char)
        Me.txtSelectedModem.RightToLeft = CType(resources.GetObject("txtSelectedModem.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtSelectedModem.ScrollBars = CType(resources.GetObject("txtSelectedModem.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtSelectedModem.Size = CType(resources.GetObject("txtSelectedModem.Size"), System.Drawing.Size)
        Me.txtSelectedModem.TabIndex = CType(resources.GetObject("txtSelectedModem.TabIndex"), Integer)
        Me.txtSelectedModem.Text = resources.GetString("txtSelectedModem.Text")
        Me.txtSelectedModem.TextAlign = CType(resources.GetObject("txtSelectedModem.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtSelectedModem.Visible = CType(resources.GetObject("txtSelectedModem.Visible"), Boolean)
        Me.txtSelectedModem.WordWrap = CType(resources.GetObject("txtSelectedModem.WordWrap"), Boolean)
        '
        'btnSendATCommand
        '
        Me.btnSendATCommand.AccessibleDescription = resources.GetString("btnSendATCommand.AccessibleDescription")
        Me.btnSendATCommand.AccessibleName = resources.GetString("btnSendATCommand.AccessibleName")
        Me.btnSendATCommand.Anchor = CType(resources.GetObject("btnSendATCommand.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSendATCommand.BackgroundImage = CType(resources.GetObject("btnSendATCommand.BackgroundImage"), System.Drawing.Image)
        Me.btnSendATCommand.Dock = CType(resources.GetObject("btnSendATCommand.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSendATCommand.Enabled = CType(resources.GetObject("btnSendATCommand.Enabled"), Boolean)
        Me.btnSendATCommand.FlatStyle = CType(resources.GetObject("btnSendATCommand.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSendATCommand.Font = CType(resources.GetObject("btnSendATCommand.Font"), System.Drawing.Font)
        Me.btnSendATCommand.Image = CType(resources.GetObject("btnSendATCommand.Image"), System.Drawing.Image)
        Me.btnSendATCommand.ImageAlign = CType(resources.GetObject("btnSendATCommand.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSendATCommand.ImageIndex = CType(resources.GetObject("btnSendATCommand.ImageIndex"), Integer)
        Me.btnSendATCommand.ImeMode = CType(resources.GetObject("btnSendATCommand.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSendATCommand.Location = CType(resources.GetObject("btnSendATCommand.Location"), System.Drawing.Point)
        Me.btnSendATCommand.Name = "btnSendATCommand"
        Me.btnSendATCommand.RightToLeft = CType(resources.GetObject("btnSendATCommand.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSendATCommand.Size = CType(resources.GetObject("btnSendATCommand.Size"), System.Drawing.Size)
        Me.btnSendATCommand.TabIndex = CType(resources.GetObject("btnSendATCommand.TabIndex"), Integer)
        Me.btnSendATCommand.Text = resources.GetString("btnSendATCommand.Text")
        Me.btnSendATCommand.TextAlign = CType(resources.GetObject("btnSendATCommand.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSendATCommand.Visible = CType(resources.GetObject("btnSendATCommand.Visible"), Boolean)
        '
        'btnSendUserCommand
        '
        Me.btnSendUserCommand.AccessibleDescription = resources.GetString("btnSendUserCommand.AccessibleDescription")
        Me.btnSendUserCommand.AccessibleName = resources.GetString("btnSendUserCommand.AccessibleName")
        Me.btnSendUserCommand.Anchor = CType(resources.GetObject("btnSendUserCommand.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSendUserCommand.BackgroundImage = CType(resources.GetObject("btnSendUserCommand.BackgroundImage"), System.Drawing.Image)
        Me.btnSendUserCommand.Dock = CType(resources.GetObject("btnSendUserCommand.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSendUserCommand.Enabled = CType(resources.GetObject("btnSendUserCommand.Enabled"), Boolean)
        Me.btnSendUserCommand.FlatStyle = CType(resources.GetObject("btnSendUserCommand.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSendUserCommand.Font = CType(resources.GetObject("btnSendUserCommand.Font"), System.Drawing.Font)
        Me.btnSendUserCommand.Image = CType(resources.GetObject("btnSendUserCommand.Image"), System.Drawing.Image)
        Me.btnSendUserCommand.ImageAlign = CType(resources.GetObject("btnSendUserCommand.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSendUserCommand.ImageIndex = CType(resources.GetObject("btnSendUserCommand.ImageIndex"), Integer)
        Me.btnSendUserCommand.ImeMode = CType(resources.GetObject("btnSendUserCommand.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSendUserCommand.Location = CType(resources.GetObject("btnSendUserCommand.Location"), System.Drawing.Point)
        Me.btnSendUserCommand.Name = "btnSendUserCommand"
        Me.btnSendUserCommand.RightToLeft = CType(resources.GetObject("btnSendUserCommand.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSendUserCommand.Size = CType(resources.GetObject("btnSendUserCommand.Size"), System.Drawing.Size)
        Me.btnSendUserCommand.TabIndex = CType(resources.GetObject("btnSendUserCommand.TabIndex"), Integer)
        Me.btnSendUserCommand.Text = resources.GetString("btnSendUserCommand.Text")
        Me.btnSendUserCommand.TextAlign = CType(resources.GetObject("btnSendUserCommand.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSendUserCommand.Visible = CType(resources.GetObject("btnSendUserCommand.Visible"), Boolean)
        '
        'txtUserCommand
        '
        Me.txtUserCommand.AccessibleDescription = resources.GetString("txtUserCommand.AccessibleDescription")
        Me.txtUserCommand.AccessibleName = resources.GetString("txtUserCommand.AccessibleName")
        Me.txtUserCommand.Anchor = CType(resources.GetObject("txtUserCommand.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtUserCommand.AutoSize = CType(resources.GetObject("txtUserCommand.AutoSize"), Boolean)
        Me.txtUserCommand.BackgroundImage = CType(resources.GetObject("txtUserCommand.BackgroundImage"), System.Drawing.Image)
        Me.txtUserCommand.Dock = CType(resources.GetObject("txtUserCommand.Dock"), System.Windows.Forms.DockStyle)
        Me.txtUserCommand.Enabled = CType(resources.GetObject("txtUserCommand.Enabled"), Boolean)
        Me.txtUserCommand.Font = CType(resources.GetObject("txtUserCommand.Font"), System.Drawing.Font)
        Me.txtUserCommand.ImeMode = CType(resources.GetObject("txtUserCommand.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtUserCommand.Location = CType(resources.GetObject("txtUserCommand.Location"), System.Drawing.Point)
        Me.txtUserCommand.MaxLength = CType(resources.GetObject("txtUserCommand.MaxLength"), Integer)
        Me.txtUserCommand.Multiline = CType(resources.GetObject("txtUserCommand.Multiline"), Boolean)
        Me.txtUserCommand.Name = "txtUserCommand"
        Me.txtUserCommand.PasswordChar = CType(resources.GetObject("txtUserCommand.PasswordChar"), Char)
        Me.txtUserCommand.RightToLeft = CType(resources.GetObject("txtUserCommand.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUserCommand.ScrollBars = CType(resources.GetObject("txtUserCommand.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUserCommand.Size = CType(resources.GetObject("txtUserCommand.Size"), System.Drawing.Size)
        Me.txtUserCommand.TabIndex = CType(resources.GetObject("txtUserCommand.TabIndex"), Integer)
        Me.txtUserCommand.Text = resources.GetString("txtUserCommand.Text")
        Me.txtUserCommand.TextAlign = CType(resources.GetObject("txtUserCommand.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUserCommand.Visible = CType(resources.GetObject("txtUserCommand.Visible"), Boolean)
        Me.txtUserCommand.WordWrap = CType(resources.GetObject("txtUserCommand.WordWrap"), Boolean)
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = resources.GetString("btnClear.AccessibleDescription")
        Me.btnClear.AccessibleName = resources.GetString("btnClear.AccessibleName")
        Me.btnClear.Anchor = CType(resources.GetObject("btnClear.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackgroundImage = CType(resources.GetObject("btnClear.BackgroundImage"), System.Drawing.Image)
        Me.btnClear.Dock = CType(resources.GetObject("btnClear.Dock"), System.Windows.Forms.DockStyle)
        Me.btnClear.Enabled = CType(resources.GetObject("btnClear.Enabled"), Boolean)
        Me.btnClear.FlatStyle = CType(resources.GetObject("btnClear.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnClear.Font = CType(resources.GetObject("btnClear.Font"), System.Drawing.Font)
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageAlign = CType(resources.GetObject("btnClear.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnClear.ImageIndex = CType(resources.GetObject("btnClear.ImageIndex"), Integer)
        Me.btnClear.ImeMode = CType(resources.GetObject("btnClear.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnClear.Location = CType(resources.GetObject("btnClear.Location"), System.Drawing.Point)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = CType(resources.GetObject("btnClear.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnClear.Size = CType(resources.GetObject("btnClear.Size"), System.Drawing.Size)
        Me.btnClear.TabIndex = CType(resources.GetObject("btnClear.TabIndex"), Integer)
        Me.btnClear.Text = resources.GetString("btnClear.Text")
        Me.btnClear.TextAlign = CType(resources.GetObject("btnClear.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnClear.Visible = CType(resources.GetObject("btnClear.Visible"), Boolean)
        '
        'frmMain
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.txtUserCommand, Me.btnSendUserCommand, Me.btnSendATCommand, Me.txtSelectedModem, Me.btnCheckModems, Me.clstPorts, Me.txtStatus, Me.btnCheckForPorts})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmMain"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
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

    ' This subroutine checks for available ports on the local machine. It does 
    '   this by attempting to open ports 1 through 4.
    Private Sub btnCheckForPorts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckForPorts.Click

        ' Check for Availability of each of the 4 Comm Ports, and
        '   place a check in the list box items that have openable ports.
        Dim i As Integer
        For i = 1 To 4
            WriteMessage("Testing COM" + i.ToString())
            If IsPortAvailable(i) Then
                ' Check the box for available ports.
                Me.clstPorts.SetItemChecked(i - 1, True)
            Else
                ' Uncheck the box for unavailable ports.
                Me.clstPorts.SetItemChecked(i - 1, False)
            End If
        Next
        ' Enable the Find Modems button.
        Me.btnCheckModems.Enabled = True
    End Sub

    ' This subroutine attempts to send an AT command to any active Comm Ports.
    '   If a response is returned then a usable modem has been detected
    '   on that port.
    Private Sub btnCheckModems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckModems.Click
        Dim i As Integer
        For i = 0 To 3
            If Me.clstPorts.GetItemChecked(i) Then
                ' Item is checked so it MIGHT be a valid port.
                ' Test for validity.
                If IsPortAvailable(i + 1) Then
                    ' Check if port responds to an AT command.
                    If IsPortAModem(i + 1) Then
                        ' Set the class variables to the last modem found.
                        Me.m_IsModemFound = True
                        Me.m_ModemPort = i + 1
                        ' Write message to the user.
                        WriteMessage("Port " + (i + 1).ToString() + _
                            " is a responsive modem.")
                    Else
                        ' Write message to the user.
                        WriteMessage("Port " + (i + 1).ToString() + _
                            " is not a responsive modem.")
                    End If
                End If
            End If
        Next
        ' If a modem was found, enable the rest of the buttons, so the user
        '   can interact with the modem.
        If Me.m_IsModemFound Then
            Me.txtSelectedModem.Text = "Using Modem on COM" + _
                Me.m_ModemPort.ToString()
            Me.txtUserCommand.Enabled = True
            Me.btnSendATCommand.Enabled = True
            Me.btnSendUserCommand.Enabled = True
        End If
    End Sub


    ' This subroutine clears the TextBox.
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtStatus.Clear()
    End Sub


    ' This subroutine sends an AT command to the modem, and records its response.
    '   It depends on the timer to do the reading of the response.
    Private Sub btnSendATCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendATCommand.Click

        ' Always wrap up working with Comm Ports in exception handlers.
        Try
            ' Enable the timer.
            Me.tmrReadCommPort.Enabled = True
            ' Attempt to open the port.
            m_CommPort.Open(m_ModemPort, 115200, 8, Rs232.DataParity.Parity_None, _
                Rs232.DataStopBit.StopBit_1, 4096)

            ' Write an AT Command to the Port.
            m_CommPort.Write(Encoding.ASCII.GetBytes("AT" & Chr(13)))
            ' Sleep long enough for the modem to respond and the timer to fire.
            System.Threading.Thread.Sleep(200)
            Application.DoEvents()
            m_CommPort.Close()

        Catch ex As Exception
            ' Warn the user.
            MessageBox.Show("Unable to communicate with Modem")
        Finally
            ' Disable the timer.
            Me.tmrReadCommPort.Enabled = False
        End Try

    End Sub


    ' This subroutine sends a user specified command to the modem, and records its 
    '   response. It depends on the timer to do the reading of the response.
    Private Sub btnSendUserCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendUserCommand.Click

        ' Always wrap up working with Comm Ports in exception handlers.
        Try
            ' Enable the timer.
            Me.tmrReadCommPort.Enabled = True
            ' Attempt to open the port.
            m_CommPort.Open(m_ModemPort, 115200, 8, Rs232.DataParity.Parity_None, Rs232.DataStopBit.StopBit_1, 4096)

            ' Write an user specified Command to the Port.
            m_CommPort.Write(Encoding.ASCII.GetBytes(Me.txtUserCommand.Text & Chr(13)))
            ' Sleep long enough for the modem to respond and the timer to fire.
            System.Threading.Thread.Sleep(200)
            Application.DoEvents()
            m_CommPort.Close()

        Catch ex As Exception
            ' Warn the user.
            MessageBox.Show("Unable to communicate with Modem")
        Finally
            ' Disable the timer.
            Me.tmrReadCommPort.Enabled = False
        End Try

    End Sub

    ' This subroutine is fired when the timer event is raised. It writes whatever
    '   is in the Comm Port buffer to the output window.
    Private Sub tmrReadCommPort_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReadCommPort.Tick
        Try
            ' As long as there is information, read one byte at a time and 
            '   output it.
            While (m_CommPort.Read(1) <> -1)
                ' Write the output to the screen.
                WriteMessage(Chr(m_CommPort.InputStream(0)), False)
            End While
        Catch exc As Exception
            ' An exception is raised when there is no information to read.
            '   Don't do anything here, just let the exception go.
        End Try

    End Sub


    ' This function checks to see if the port is a modem, by sending 
    '   an AT command to the port. If the port responds, it is assumed to 
    '   be a modem. The function returns a Boolean.
    Private Function IsPortAModem(ByVal port As Integer) As Boolean

        ' Always wrap up working with Comm Ports in exception handlers.
        Try
            ' Attempt to open the port.
            m_CommPort.Open(port, 115200, 8, Rs232.DataParity.Parity_None, _
                Rs232.DataStopBit.StopBit_1, 4096)

            ' Write an AT Command to the Port.
            m_CommPort.Write(Encoding.ASCII.GetBytes("AT" & Chr(13)))
            ' Sleep long enough for the modem to respond.
            System.Threading.Thread.Sleep(200)
            Application.DoEvents()
            ' Try to get info from the Comm Port.
            Try
                Dim b As Byte
                ' Try to read a single byte. If you get it, then assume
                '   that the port contains a modem. Clear the buffer before 
                '   leaving.
                m_CommPort.Read(1)
                m_CommPort.ClearInputBuffer()
                m_CommPort.Close()
                Return True
            Catch exc As Exception
                ' Nothing to read from the Comm Port, so set to False
                m_CommPort.Close()
                Return False
            End Try
        Catch exc As Exception
            ' Port could not be opened or written to.
            Me.clstPorts.SetItemChecked(port - 1, False)
            MsgBox("Could not open port.", MsgBoxStyle.OKOnly, Me.Text)
            Return False
        End Try


    End Function

    ' This function attempts to open the passed Comm Port. If it is
    '   available, it returns True, else it returns False. To determine
    '   availability a Try-Catch block is used.
    Private Function IsPortAvailable(ByVal ComPort As Integer) As Boolean
        Try
            m_CommPort.Open(ComPort, 115200, 8, Rs232.DataParity.Parity_None, _
                Rs232.DataStopBit.StopBit_1, 4096)
            ' If it makes it to here, then the Comm Port is available.
            m_CommPort.Close()
            Return True
        Catch
            ' If it gets here, then the attempt to open the Comm Port
            '   was unsuccessful.
            Return False
        End Try
    End Function

    ' This subroutine writes a message to the txtStatus TextBox.
    Private Sub WriteMessage(ByVal message As String)
        Me.txtStatus.Text += message + vbCrLf
    End Sub

    ' This subroutine writes a message to the txtStatus TextBox and allows
    '   the line feed to be suppressed.
    Private Sub WriteMessage(ByVal message As String, ByVal linefeed As Boolean)
        Me.txtStatus.Text += message
        If linefeed Then
            Me.txtStatus.Text += vbCrLf
        End If
    End Sub

End Class