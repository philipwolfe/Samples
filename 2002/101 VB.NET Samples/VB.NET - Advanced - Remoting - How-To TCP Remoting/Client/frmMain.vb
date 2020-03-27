'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Runtime.Remoting
Imports RemotingSample

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
	Friend WithEvents cmdClear As System.Windows.Forms.Button
	Friend WithEvents lstResponses As System.Windows.Forms.ListBox
	Friend WithEvents cmdCreate As System.Windows.Forms.Button
	Friend WithEvents cmdGet As System.Windows.Forms.Button
	Friend WithEvents cmdUpdate As System.Windows.Forms.Button
	Friend WithEvents cmdRelease As System.Windows.Forms.Button
	Friend WithEvents cmdDebugData As System.Windows.Forms.Button
	Friend WithEvents gbInputData As System.Windows.Forms.GroupBox
	Friend WithEvents txtNewAge As System.Windows.Forms.TextBox
	Friend WithEvents txtNewName As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents lblDefAgeValue As System.Windows.Forms.Label
	Friend WithEvents lblDefNameValue As System.Windows.Forms.Label
	Friend WithEvents lblDefAge As System.Windows.Forms.Label
	Friend WithEvents lblDefName As System.Windows.Forms.Label
	Friend WithEvents cmdUpdateAndGet As System.Windows.Forms.Button
	Friend WithEvents gbTwo As System.Windows.Forms.GroupBox
	Friend WithEvents rbClient As System.Windows.Forms.RadioButton
	Friend WithEvents rbSingle As System.Windows.Forms.RadioButton
	Friend WithEvents gbSingle As System.Windows.Forms.GroupBox
	Friend WithEvents cmdSingleDebug As System.Windows.Forms.Button
	Friend WithEvents cmdSingleCall As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.cmdClear = New System.Windows.Forms.Button()
		Me.lstResponses = New System.Windows.Forms.ListBox()
		Me.gbTwo = New System.Windows.Forms.GroupBox()
		Me.rbSingle = New System.Windows.Forms.RadioButton()
		Me.rbClient = New System.Windows.Forms.RadioButton()
		Me.cmdUpdateAndGet = New System.Windows.Forms.Button()
		Me.cmdDebugData = New System.Windows.Forms.Button()
		Me.cmdRelease = New System.Windows.Forms.Button()
		Me.cmdUpdate = New System.Windows.Forms.Button()
		Me.cmdGet = New System.Windows.Forms.Button()
		Me.cmdCreate = New System.Windows.Forms.Button()
		Me.gbInputData = New System.Windows.Forms.GroupBox()
		Me.txtNewAge = New System.Windows.Forms.TextBox()
		Me.txtNewName = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblDefAgeValue = New System.Windows.Forms.Label()
		Me.lblDefNameValue = New System.Windows.Forms.Label()
		Me.lblDefAge = New System.Windows.Forms.Label()
		Me.lblDefName = New System.Windows.Forms.Label()
		Me.gbSingle = New System.Windows.Forms.GroupBox()
		Me.cmdSingleDebug = New System.Windows.Forms.Button()
		Me.cmdSingleCall = New System.Windows.Forms.Button()
		Me.gbTwo.SuspendLayout()
		Me.gbInputData.SuspendLayout()
		Me.gbSingle.SuspendLayout()
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
		'cmdClear
		'
		Me.cmdClear.AccessibleDescription = CType(resources.GetObject("cmdClear.AccessibleDescription"), String)
		Me.cmdClear.AccessibleName = CType(resources.GetObject("cmdClear.AccessibleName"), String)
		Me.cmdClear.Anchor = CType(resources.GetObject("cmdClear.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdClear.BackgroundImage = CType(resources.GetObject("cmdClear.BackgroundImage"), System.Drawing.Image)
		Me.cmdClear.Dock = CType(resources.GetObject("cmdClear.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdClear.Enabled = CType(resources.GetObject("cmdClear.Enabled"), Boolean)
		Me.cmdClear.FlatStyle = CType(resources.GetObject("cmdClear.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdClear.Font = CType(resources.GetObject("cmdClear.Font"), System.Drawing.Font)
		Me.cmdClear.Image = CType(resources.GetObject("cmdClear.Image"), System.Drawing.Image)
		Me.cmdClear.ImageAlign = CType(resources.GetObject("cmdClear.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdClear.ImageIndex = CType(resources.GetObject("cmdClear.ImageIndex"), Integer)
		Me.cmdClear.ImeMode = CType(resources.GetObject("cmdClear.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdClear.Location = CType(resources.GetObject("cmdClear.Location"), System.Drawing.Point)
		Me.cmdClear.Name = "cmdClear"
		Me.cmdClear.RightToLeft = CType(resources.GetObject("cmdClear.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdClear.Size = CType(resources.GetObject("cmdClear.Size"), System.Drawing.Size)
		Me.cmdClear.TabIndex = CType(resources.GetObject("cmdClear.TabIndex"), Integer)
		Me.cmdClear.Text = resources.GetString("cmdClear.Text")
		Me.cmdClear.TextAlign = CType(resources.GetObject("cmdClear.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdClear.Visible = CType(resources.GetObject("cmdClear.Visible"), Boolean)
		'
		'lstResponses
		'
		Me.lstResponses.AccessibleDescription = CType(resources.GetObject("lstResponses.AccessibleDescription"), String)
		Me.lstResponses.AccessibleName = CType(resources.GetObject("lstResponses.AccessibleName"), String)
		Me.lstResponses.Anchor = CType(resources.GetObject("lstResponses.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.lstResponses.BackgroundImage = CType(resources.GetObject("lstResponses.BackgroundImage"), System.Drawing.Image)
		Me.lstResponses.ColumnWidth = CType(resources.GetObject("lstResponses.ColumnWidth"), Integer)
		Me.lstResponses.Dock = CType(resources.GetObject("lstResponses.Dock"), System.Windows.Forms.DockStyle)
		Me.lstResponses.Enabled = CType(resources.GetObject("lstResponses.Enabled"), Boolean)
		Me.lstResponses.Font = CType(resources.GetObject("lstResponses.Font"), System.Drawing.Font)
		Me.lstResponses.HorizontalExtent = CType(resources.GetObject("lstResponses.HorizontalExtent"), Integer)
		Me.lstResponses.HorizontalScrollbar = CType(resources.GetObject("lstResponses.HorizontalScrollbar"), Boolean)
		Me.lstResponses.ImeMode = CType(resources.GetObject("lstResponses.ImeMode"), System.Windows.Forms.ImeMode)
		Me.lstResponses.IntegralHeight = CType(resources.GetObject("lstResponses.IntegralHeight"), Boolean)
		Me.lstResponses.ItemHeight = CType(resources.GetObject("lstResponses.ItemHeight"), Integer)
		Me.lstResponses.Location = CType(resources.GetObject("lstResponses.Location"), System.Drawing.Point)
		Me.lstResponses.Name = "lstResponses"
		Me.lstResponses.RightToLeft = CType(resources.GetObject("lstResponses.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.lstResponses.ScrollAlwaysVisible = CType(resources.GetObject("lstResponses.ScrollAlwaysVisible"), Boolean)
		Me.lstResponses.Size = CType(resources.GetObject("lstResponses.Size"), System.Drawing.Size)
		Me.lstResponses.TabIndex = CType(resources.GetObject("lstResponses.TabIndex"), Integer)
		Me.lstResponses.Visible = CType(resources.GetObject("lstResponses.Visible"), Boolean)
		'
		'gbTwo
		'
		Me.gbTwo.AccessibleDescription = CType(resources.GetObject("gbTwo.AccessibleDescription"), String)
		Me.gbTwo.AccessibleName = CType(resources.GetObject("gbTwo.AccessibleName"), String)
		Me.gbTwo.Anchor = CType(resources.GetObject("gbTwo.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.gbTwo.BackgroundImage = CType(resources.GetObject("gbTwo.BackgroundImage"), System.Drawing.Image)
		Me.gbTwo.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbSingle, Me.rbClient, Me.cmdUpdateAndGet, Me.cmdDebugData, Me.cmdRelease, Me.cmdUpdate, Me.cmdGet, Me.cmdCreate})
		Me.gbTwo.Dock = CType(resources.GetObject("gbTwo.Dock"), System.Windows.Forms.DockStyle)
		Me.gbTwo.Enabled = CType(resources.GetObject("gbTwo.Enabled"), Boolean)
		Me.gbTwo.Font = CType(resources.GetObject("gbTwo.Font"), System.Drawing.Font)
		Me.gbTwo.ImeMode = CType(resources.GetObject("gbTwo.ImeMode"), System.Windows.Forms.ImeMode)
		Me.gbTwo.Location = CType(resources.GetObject("gbTwo.Location"), System.Drawing.Point)
		Me.gbTwo.Name = "gbTwo"
		Me.gbTwo.RightToLeft = CType(resources.GetObject("gbTwo.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.gbTwo.Size = CType(resources.GetObject("gbTwo.Size"), System.Drawing.Size)
		Me.gbTwo.TabIndex = CType(resources.GetObject("gbTwo.TabIndex"), Integer)
		Me.gbTwo.TabStop = False
		Me.gbTwo.Text = resources.GetString("gbTwo.Text")
		Me.gbTwo.Visible = CType(resources.GetObject("gbTwo.Visible"), Boolean)
		'
		'rbSingle
		'
		Me.rbSingle.AccessibleDescription = CType(resources.GetObject("rbSingle.AccessibleDescription"), String)
		Me.rbSingle.AccessibleName = CType(resources.GetObject("rbSingle.AccessibleName"), String)
		Me.rbSingle.Anchor = CType(resources.GetObject("rbSingle.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.rbSingle.Appearance = CType(resources.GetObject("rbSingle.Appearance"), System.Windows.Forms.Appearance)
		Me.rbSingle.BackgroundImage = CType(resources.GetObject("rbSingle.BackgroundImage"), System.Drawing.Image)
		Me.rbSingle.CheckAlign = CType(resources.GetObject("rbSingle.CheckAlign"), System.Drawing.ContentAlignment)
		Me.rbSingle.Dock = CType(resources.GetObject("rbSingle.Dock"), System.Windows.Forms.DockStyle)
		Me.rbSingle.Enabled = CType(resources.GetObject("rbSingle.Enabled"), Boolean)
		Me.rbSingle.FlatStyle = CType(resources.GetObject("rbSingle.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.rbSingle.Font = CType(resources.GetObject("rbSingle.Font"), System.Drawing.Font)
		Me.rbSingle.Image = CType(resources.GetObject("rbSingle.Image"), System.Drawing.Image)
		Me.rbSingle.ImageAlign = CType(resources.GetObject("rbSingle.ImageAlign"), System.Drawing.ContentAlignment)
		Me.rbSingle.ImageIndex = CType(resources.GetObject("rbSingle.ImageIndex"), Integer)
		Me.rbSingle.ImeMode = CType(resources.GetObject("rbSingle.ImeMode"), System.Windows.Forms.ImeMode)
		Me.rbSingle.Location = CType(resources.GetObject("rbSingle.Location"), System.Drawing.Point)
		Me.rbSingle.Name = "rbSingle"
		Me.rbSingle.RightToLeft = CType(resources.GetObject("rbSingle.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.rbSingle.Size = CType(resources.GetObject("rbSingle.Size"), System.Drawing.Size)
		Me.rbSingle.TabIndex = CType(resources.GetObject("rbSingle.TabIndex"), Integer)
		Me.rbSingle.Text = resources.GetString("rbSingle.Text")
		Me.rbSingle.TextAlign = CType(resources.GetObject("rbSingle.TextAlign"), System.Drawing.ContentAlignment)
		Me.rbSingle.Visible = CType(resources.GetObject("rbSingle.Visible"), Boolean)
		'
		'rbClient
		'
		Me.rbClient.AccessibleDescription = CType(resources.GetObject("rbClient.AccessibleDescription"), String)
		Me.rbClient.AccessibleName = CType(resources.GetObject("rbClient.AccessibleName"), String)
		Me.rbClient.Anchor = CType(resources.GetObject("rbClient.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.rbClient.Appearance = CType(resources.GetObject("rbClient.Appearance"), System.Windows.Forms.Appearance)
		Me.rbClient.BackgroundImage = CType(resources.GetObject("rbClient.BackgroundImage"), System.Drawing.Image)
		Me.rbClient.CheckAlign = CType(resources.GetObject("rbClient.CheckAlign"), System.Drawing.ContentAlignment)
		Me.rbClient.Checked = True
		Me.rbClient.Dock = CType(resources.GetObject("rbClient.Dock"), System.Windows.Forms.DockStyle)
		Me.rbClient.Enabled = CType(resources.GetObject("rbClient.Enabled"), Boolean)
		Me.rbClient.FlatStyle = CType(resources.GetObject("rbClient.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.rbClient.Font = CType(resources.GetObject("rbClient.Font"), System.Drawing.Font)
		Me.rbClient.Image = CType(resources.GetObject("rbClient.Image"), System.Drawing.Image)
		Me.rbClient.ImageAlign = CType(resources.GetObject("rbClient.ImageAlign"), System.Drawing.ContentAlignment)
		Me.rbClient.ImageIndex = CType(resources.GetObject("rbClient.ImageIndex"), Integer)
		Me.rbClient.ImeMode = CType(resources.GetObject("rbClient.ImeMode"), System.Windows.Forms.ImeMode)
		Me.rbClient.Location = CType(resources.GetObject("rbClient.Location"), System.Drawing.Point)
		Me.rbClient.Name = "rbClient"
		Me.rbClient.RightToLeft = CType(resources.GetObject("rbClient.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.rbClient.Size = CType(resources.GetObject("rbClient.Size"), System.Drawing.Size)
		Me.rbClient.TabIndex = CType(resources.GetObject("rbClient.TabIndex"), Integer)
		Me.rbClient.TabStop = True
		Me.rbClient.Text = resources.GetString("rbClient.Text")
		Me.rbClient.TextAlign = CType(resources.GetObject("rbClient.TextAlign"), System.Drawing.ContentAlignment)
		Me.rbClient.Visible = CType(resources.GetObject("rbClient.Visible"), Boolean)
		'
		'cmdUpdateAndGet
		'
		Me.cmdUpdateAndGet.AccessibleDescription = CType(resources.GetObject("cmdUpdateAndGet.AccessibleDescription"), String)
		Me.cmdUpdateAndGet.AccessibleName = CType(resources.GetObject("cmdUpdateAndGet.AccessibleName"), String)
		Me.cmdUpdateAndGet.Anchor = CType(resources.GetObject("cmdUpdateAndGet.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdUpdateAndGet.BackgroundImage = CType(resources.GetObject("cmdUpdateAndGet.BackgroundImage"), System.Drawing.Image)
		Me.cmdUpdateAndGet.Dock = CType(resources.GetObject("cmdUpdateAndGet.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdUpdateAndGet.Enabled = CType(resources.GetObject("cmdUpdateAndGet.Enabled"), Boolean)
		Me.cmdUpdateAndGet.FlatStyle = CType(resources.GetObject("cmdUpdateAndGet.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdUpdateAndGet.Font = CType(resources.GetObject("cmdUpdateAndGet.Font"), System.Drawing.Font)
		Me.cmdUpdateAndGet.Image = CType(resources.GetObject("cmdUpdateAndGet.Image"), System.Drawing.Image)
		Me.cmdUpdateAndGet.ImageAlign = CType(resources.GetObject("cmdUpdateAndGet.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdUpdateAndGet.ImageIndex = CType(resources.GetObject("cmdUpdateAndGet.ImageIndex"), Integer)
		Me.cmdUpdateAndGet.ImeMode = CType(resources.GetObject("cmdUpdateAndGet.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdUpdateAndGet.Location = CType(resources.GetObject("cmdUpdateAndGet.Location"), System.Drawing.Point)
		Me.cmdUpdateAndGet.Name = "cmdUpdateAndGet"
		Me.cmdUpdateAndGet.RightToLeft = CType(resources.GetObject("cmdUpdateAndGet.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdUpdateAndGet.Size = CType(resources.GetObject("cmdUpdateAndGet.Size"), System.Drawing.Size)
		Me.cmdUpdateAndGet.TabIndex = CType(resources.GetObject("cmdUpdateAndGet.TabIndex"), Integer)
		Me.cmdUpdateAndGet.Text = resources.GetString("cmdUpdateAndGet.Text")
		Me.cmdUpdateAndGet.TextAlign = CType(resources.GetObject("cmdUpdateAndGet.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdUpdateAndGet.Visible = CType(resources.GetObject("cmdUpdateAndGet.Visible"), Boolean)
		'
		'cmdDebugData
		'
		Me.cmdDebugData.AccessibleDescription = CType(resources.GetObject("cmdDebugData.AccessibleDescription"), String)
		Me.cmdDebugData.AccessibleName = CType(resources.GetObject("cmdDebugData.AccessibleName"), String)
		Me.cmdDebugData.Anchor = CType(resources.GetObject("cmdDebugData.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdDebugData.BackgroundImage = CType(resources.GetObject("cmdDebugData.BackgroundImage"), System.Drawing.Image)
		Me.cmdDebugData.Dock = CType(resources.GetObject("cmdDebugData.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdDebugData.Enabled = CType(resources.GetObject("cmdDebugData.Enabled"), Boolean)
		Me.cmdDebugData.FlatStyle = CType(resources.GetObject("cmdDebugData.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdDebugData.Font = CType(resources.GetObject("cmdDebugData.Font"), System.Drawing.Font)
		Me.cmdDebugData.Image = CType(resources.GetObject("cmdDebugData.Image"), System.Drawing.Image)
		Me.cmdDebugData.ImageAlign = CType(resources.GetObject("cmdDebugData.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdDebugData.ImageIndex = CType(resources.GetObject("cmdDebugData.ImageIndex"), Integer)
		Me.cmdDebugData.ImeMode = CType(resources.GetObject("cmdDebugData.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdDebugData.Location = CType(resources.GetObject("cmdDebugData.Location"), System.Drawing.Point)
		Me.cmdDebugData.Name = "cmdDebugData"
		Me.cmdDebugData.RightToLeft = CType(resources.GetObject("cmdDebugData.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdDebugData.Size = CType(resources.GetObject("cmdDebugData.Size"), System.Drawing.Size)
		Me.cmdDebugData.TabIndex = CType(resources.GetObject("cmdDebugData.TabIndex"), Integer)
		Me.cmdDebugData.Text = resources.GetString("cmdDebugData.Text")
		Me.cmdDebugData.TextAlign = CType(resources.GetObject("cmdDebugData.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdDebugData.Visible = CType(resources.GetObject("cmdDebugData.Visible"), Boolean)
		'
		'cmdRelease
		'
		Me.cmdRelease.AccessibleDescription = CType(resources.GetObject("cmdRelease.AccessibleDescription"), String)
		Me.cmdRelease.AccessibleName = CType(resources.GetObject("cmdRelease.AccessibleName"), String)
		Me.cmdRelease.Anchor = CType(resources.GetObject("cmdRelease.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdRelease.BackgroundImage = CType(resources.GetObject("cmdRelease.BackgroundImage"), System.Drawing.Image)
		Me.cmdRelease.Dock = CType(resources.GetObject("cmdRelease.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdRelease.Enabled = CType(resources.GetObject("cmdRelease.Enabled"), Boolean)
		Me.cmdRelease.FlatStyle = CType(resources.GetObject("cmdRelease.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdRelease.Font = CType(resources.GetObject("cmdRelease.Font"), System.Drawing.Font)
		Me.cmdRelease.Image = CType(resources.GetObject("cmdRelease.Image"), System.Drawing.Image)
		Me.cmdRelease.ImageAlign = CType(resources.GetObject("cmdRelease.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdRelease.ImageIndex = CType(resources.GetObject("cmdRelease.ImageIndex"), Integer)
		Me.cmdRelease.ImeMode = CType(resources.GetObject("cmdRelease.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdRelease.Location = CType(resources.GetObject("cmdRelease.Location"), System.Drawing.Point)
		Me.cmdRelease.Name = "cmdRelease"
		Me.cmdRelease.RightToLeft = CType(resources.GetObject("cmdRelease.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdRelease.Size = CType(resources.GetObject("cmdRelease.Size"), System.Drawing.Size)
		Me.cmdRelease.TabIndex = CType(resources.GetObject("cmdRelease.TabIndex"), Integer)
		Me.cmdRelease.Text = resources.GetString("cmdRelease.Text")
		Me.cmdRelease.TextAlign = CType(resources.GetObject("cmdRelease.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdRelease.Visible = CType(resources.GetObject("cmdRelease.Visible"), Boolean)
		'
		'cmdUpdate
		'
		Me.cmdUpdate.AccessibleDescription = CType(resources.GetObject("cmdUpdate.AccessibleDescription"), String)
		Me.cmdUpdate.AccessibleName = CType(resources.GetObject("cmdUpdate.AccessibleName"), String)
		Me.cmdUpdate.Anchor = CType(resources.GetObject("cmdUpdate.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdUpdate.BackgroundImage = CType(resources.GetObject("cmdUpdate.BackgroundImage"), System.Drawing.Image)
		Me.cmdUpdate.Dock = CType(resources.GetObject("cmdUpdate.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdUpdate.Enabled = CType(resources.GetObject("cmdUpdate.Enabled"), Boolean)
		Me.cmdUpdate.FlatStyle = CType(resources.GetObject("cmdUpdate.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdUpdate.Font = CType(resources.GetObject("cmdUpdate.Font"), System.Drawing.Font)
		Me.cmdUpdate.Image = CType(resources.GetObject("cmdUpdate.Image"), System.Drawing.Image)
		Me.cmdUpdate.ImageAlign = CType(resources.GetObject("cmdUpdate.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdUpdate.ImageIndex = CType(resources.GetObject("cmdUpdate.ImageIndex"), Integer)
		Me.cmdUpdate.ImeMode = CType(resources.GetObject("cmdUpdate.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdUpdate.Location = CType(resources.GetObject("cmdUpdate.Location"), System.Drawing.Point)
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.cmdUpdate.RightToLeft = CType(resources.GetObject("cmdUpdate.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdUpdate.Size = CType(resources.GetObject("cmdUpdate.Size"), System.Drawing.Size)
		Me.cmdUpdate.TabIndex = CType(resources.GetObject("cmdUpdate.TabIndex"), Integer)
		Me.cmdUpdate.Text = resources.GetString("cmdUpdate.Text")
		Me.cmdUpdate.TextAlign = CType(resources.GetObject("cmdUpdate.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdUpdate.Visible = CType(resources.GetObject("cmdUpdate.Visible"), Boolean)
		'
		'cmdGet
		'
		Me.cmdGet.AccessibleDescription = CType(resources.GetObject("cmdGet.AccessibleDescription"), String)
		Me.cmdGet.AccessibleName = CType(resources.GetObject("cmdGet.AccessibleName"), String)
		Me.cmdGet.Anchor = CType(resources.GetObject("cmdGet.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdGet.BackgroundImage = CType(resources.GetObject("cmdGet.BackgroundImage"), System.Drawing.Image)
		Me.cmdGet.Dock = CType(resources.GetObject("cmdGet.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdGet.Enabled = CType(resources.GetObject("cmdGet.Enabled"), Boolean)
		Me.cmdGet.FlatStyle = CType(resources.GetObject("cmdGet.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdGet.Font = CType(resources.GetObject("cmdGet.Font"), System.Drawing.Font)
		Me.cmdGet.Image = CType(resources.GetObject("cmdGet.Image"), System.Drawing.Image)
		Me.cmdGet.ImageAlign = CType(resources.GetObject("cmdGet.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdGet.ImageIndex = CType(resources.GetObject("cmdGet.ImageIndex"), Integer)
		Me.cmdGet.ImeMode = CType(resources.GetObject("cmdGet.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdGet.Location = CType(resources.GetObject("cmdGet.Location"), System.Drawing.Point)
		Me.cmdGet.Name = "cmdGet"
		Me.cmdGet.RightToLeft = CType(resources.GetObject("cmdGet.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdGet.Size = CType(resources.GetObject("cmdGet.Size"), System.Drawing.Size)
		Me.cmdGet.TabIndex = CType(resources.GetObject("cmdGet.TabIndex"), Integer)
		Me.cmdGet.Text = resources.GetString("cmdGet.Text")
		Me.cmdGet.TextAlign = CType(resources.GetObject("cmdGet.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdGet.Visible = CType(resources.GetObject("cmdGet.Visible"), Boolean)
		'
		'cmdCreate
		'
		Me.cmdCreate.AccessibleDescription = CType(resources.GetObject("cmdCreate.AccessibleDescription"), String)
		Me.cmdCreate.AccessibleName = CType(resources.GetObject("cmdCreate.AccessibleName"), String)
		Me.cmdCreate.Anchor = CType(resources.GetObject("cmdCreate.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdCreate.BackgroundImage = CType(resources.GetObject("cmdCreate.BackgroundImage"), System.Drawing.Image)
		Me.cmdCreate.Dock = CType(resources.GetObject("cmdCreate.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdCreate.Enabled = CType(resources.GetObject("cmdCreate.Enabled"), Boolean)
		Me.cmdCreate.FlatStyle = CType(resources.GetObject("cmdCreate.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdCreate.Font = CType(resources.GetObject("cmdCreate.Font"), System.Drawing.Font)
		Me.cmdCreate.Image = CType(resources.GetObject("cmdCreate.Image"), System.Drawing.Image)
		Me.cmdCreate.ImageAlign = CType(resources.GetObject("cmdCreate.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdCreate.ImageIndex = CType(resources.GetObject("cmdCreate.ImageIndex"), Integer)
		Me.cmdCreate.ImeMode = CType(resources.GetObject("cmdCreate.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdCreate.Location = CType(resources.GetObject("cmdCreate.Location"), System.Drawing.Point)
		Me.cmdCreate.Name = "cmdCreate"
		Me.cmdCreate.RightToLeft = CType(resources.GetObject("cmdCreate.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdCreate.Size = CType(resources.GetObject("cmdCreate.Size"), System.Drawing.Size)
		Me.cmdCreate.TabIndex = CType(resources.GetObject("cmdCreate.TabIndex"), Integer)
		Me.cmdCreate.Text = resources.GetString("cmdCreate.Text")
		Me.cmdCreate.TextAlign = CType(resources.GetObject("cmdCreate.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdCreate.Visible = CType(resources.GetObject("cmdCreate.Visible"), Boolean)
		'
		'gbInputData
		'
		Me.gbInputData.AccessibleDescription = CType(resources.GetObject("gbInputData.AccessibleDescription"), String)
		Me.gbInputData.AccessibleName = CType(resources.GetObject("gbInputData.AccessibleName"), String)
		Me.gbInputData.Anchor = CType(resources.GetObject("gbInputData.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.gbInputData.BackgroundImage = CType(resources.GetObject("gbInputData.BackgroundImage"), System.Drawing.Image)
		Me.gbInputData.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNewAge, Me.txtNewName, Me.Label1, Me.Label2, Me.lblDefAgeValue, Me.lblDefNameValue, Me.lblDefAge, Me.lblDefName})
		Me.gbInputData.Dock = CType(resources.GetObject("gbInputData.Dock"), System.Windows.Forms.DockStyle)
		Me.gbInputData.Enabled = CType(resources.GetObject("gbInputData.Enabled"), Boolean)
		Me.gbInputData.Font = CType(resources.GetObject("gbInputData.Font"), System.Drawing.Font)
		Me.gbInputData.ImeMode = CType(resources.GetObject("gbInputData.ImeMode"), System.Windows.Forms.ImeMode)
		Me.gbInputData.Location = CType(resources.GetObject("gbInputData.Location"), System.Drawing.Point)
		Me.gbInputData.Name = "gbInputData"
		Me.gbInputData.RightToLeft = CType(resources.GetObject("gbInputData.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.gbInputData.Size = CType(resources.GetObject("gbInputData.Size"), System.Drawing.Size)
		Me.gbInputData.TabIndex = CType(resources.GetObject("gbInputData.TabIndex"), Integer)
		Me.gbInputData.TabStop = False
		Me.gbInputData.Text = resources.GetString("gbInputData.Text")
		Me.gbInputData.Visible = CType(resources.GetObject("gbInputData.Visible"), Boolean)
		'
		'txtNewAge
		'
		Me.txtNewAge.AccessibleDescription = CType(resources.GetObject("txtNewAge.AccessibleDescription"), String)
		Me.txtNewAge.AccessibleName = CType(resources.GetObject("txtNewAge.AccessibleName"), String)
		Me.txtNewAge.Anchor = CType(resources.GetObject("txtNewAge.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.txtNewAge.AutoSize = CType(resources.GetObject("txtNewAge.AutoSize"), Boolean)
		Me.txtNewAge.BackgroundImage = CType(resources.GetObject("txtNewAge.BackgroundImage"), System.Drawing.Image)
		Me.txtNewAge.Dock = CType(resources.GetObject("txtNewAge.Dock"), System.Windows.Forms.DockStyle)
		Me.txtNewAge.Enabled = CType(resources.GetObject("txtNewAge.Enabled"), Boolean)
		Me.txtNewAge.Font = CType(resources.GetObject("txtNewAge.Font"), System.Drawing.Font)
		Me.txtNewAge.ImeMode = CType(resources.GetObject("txtNewAge.ImeMode"), System.Windows.Forms.ImeMode)
		Me.txtNewAge.Location = CType(resources.GetObject("txtNewAge.Location"), System.Drawing.Point)
		Me.txtNewAge.MaxLength = CType(resources.GetObject("txtNewAge.MaxLength"), Integer)
		Me.txtNewAge.Multiline = CType(resources.GetObject("txtNewAge.Multiline"), Boolean)
		Me.txtNewAge.Name = "txtNewAge"
		Me.txtNewAge.PasswordChar = CType(resources.GetObject("txtNewAge.PasswordChar"), Char)
		Me.txtNewAge.RightToLeft = CType(resources.GetObject("txtNewAge.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.txtNewAge.ScrollBars = CType(resources.GetObject("txtNewAge.ScrollBars"), System.Windows.Forms.ScrollBars)
		Me.txtNewAge.Size = CType(resources.GetObject("txtNewAge.Size"), System.Drawing.Size)
		Me.txtNewAge.TabIndex = CType(resources.GetObject("txtNewAge.TabIndex"), Integer)
		Me.txtNewAge.Text = resources.GetString("txtNewAge.Text")
		Me.txtNewAge.TextAlign = CType(resources.GetObject("txtNewAge.TextAlign"), System.Windows.Forms.HorizontalAlignment)
		Me.txtNewAge.Visible = CType(resources.GetObject("txtNewAge.Visible"), Boolean)
		Me.txtNewAge.WordWrap = CType(resources.GetObject("txtNewAge.WordWrap"), Boolean)
		'
		'txtNewName
		'
		Me.txtNewName.AccessibleDescription = CType(resources.GetObject("txtNewName.AccessibleDescription"), String)
		Me.txtNewName.AccessibleName = CType(resources.GetObject("txtNewName.AccessibleName"), String)
		Me.txtNewName.Anchor = CType(resources.GetObject("txtNewName.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.txtNewName.AutoSize = CType(resources.GetObject("txtNewName.AutoSize"), Boolean)
		Me.txtNewName.BackgroundImage = CType(resources.GetObject("txtNewName.BackgroundImage"), System.Drawing.Image)
		Me.txtNewName.Dock = CType(resources.GetObject("txtNewName.Dock"), System.Windows.Forms.DockStyle)
		Me.txtNewName.Enabled = CType(resources.GetObject("txtNewName.Enabled"), Boolean)
		Me.txtNewName.Font = CType(resources.GetObject("txtNewName.Font"), System.Drawing.Font)
		Me.txtNewName.ImeMode = CType(resources.GetObject("txtNewName.ImeMode"), System.Windows.Forms.ImeMode)
		Me.txtNewName.Location = CType(resources.GetObject("txtNewName.Location"), System.Drawing.Point)
		Me.txtNewName.MaxLength = CType(resources.GetObject("txtNewName.MaxLength"), Integer)
		Me.txtNewName.Multiline = CType(resources.GetObject("txtNewName.Multiline"), Boolean)
		Me.txtNewName.Name = "txtNewName"
		Me.txtNewName.PasswordChar = CType(resources.GetObject("txtNewName.PasswordChar"), Char)
		Me.txtNewName.RightToLeft = CType(resources.GetObject("txtNewName.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.txtNewName.ScrollBars = CType(resources.GetObject("txtNewName.ScrollBars"), System.Windows.Forms.ScrollBars)
		Me.txtNewName.Size = CType(resources.GetObject("txtNewName.Size"), System.Drawing.Size)
		Me.txtNewName.TabIndex = CType(resources.GetObject("txtNewName.TabIndex"), Integer)
		Me.txtNewName.Text = resources.GetString("txtNewName.Text")
		Me.txtNewName.TextAlign = CType(resources.GetObject("txtNewName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
		Me.txtNewName.Visible = CType(resources.GetObject("txtNewName.Visible"), Boolean)
		Me.txtNewName.WordWrap = CType(resources.GetObject("txtNewName.WordWrap"), Boolean)
		'
		'Label1
		'
		Me.Label1.AccessibleDescription = CType(resources.GetObject("Label1.AccessibleDescription"), String)
		Me.Label1.AccessibleName = CType(resources.GetObject("Label1.AccessibleName"), String)
		Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
		Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
		Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
		Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
		Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
		Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
		Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
		Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
		Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
		Me.Label1.Name = "Label1"
		Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
		Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
		Me.Label1.Text = resources.GetString("Label1.Text")
		Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
		Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
		'
		'Label2
		'
		Me.Label2.AccessibleDescription = CType(resources.GetObject("Label2.AccessibleDescription"), String)
		Me.Label2.AccessibleName = CType(resources.GetObject("Label2.AccessibleName"), String)
		Me.Label2.Anchor = CType(resources.GetObject("Label2.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.Label2.AutoSize = CType(resources.GetObject("Label2.AutoSize"), Boolean)
		Me.Label2.Dock = CType(resources.GetObject("Label2.Dock"), System.Windows.Forms.DockStyle)
		Me.Label2.Enabled = CType(resources.GetObject("Label2.Enabled"), Boolean)
		Me.Label2.Font = CType(resources.GetObject("Label2.Font"), System.Drawing.Font)
		Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
		Me.Label2.ImageAlign = CType(resources.GetObject("Label2.ImageAlign"), System.Drawing.ContentAlignment)
		Me.Label2.ImageIndex = CType(resources.GetObject("Label2.ImageIndex"), Integer)
		Me.Label2.ImeMode = CType(resources.GetObject("Label2.ImeMode"), System.Windows.Forms.ImeMode)
		Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.Point)
		Me.Label2.Name = "Label2"
		Me.Label2.RightToLeft = CType(resources.GetObject("Label2.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.Label2.Size = CType(resources.GetObject("Label2.Size"), System.Drawing.Size)
		Me.Label2.TabIndex = CType(resources.GetObject("Label2.TabIndex"), Integer)
		Me.Label2.Text = resources.GetString("Label2.Text")
		Me.Label2.TextAlign = CType(resources.GetObject("Label2.TextAlign"), System.Drawing.ContentAlignment)
		Me.Label2.Visible = CType(resources.GetObject("Label2.Visible"), Boolean)
		'
		'lblDefAgeValue
		'
		Me.lblDefAgeValue.AccessibleDescription = CType(resources.GetObject("lblDefAgeValue.AccessibleDescription"), String)
		Me.lblDefAgeValue.AccessibleName = CType(resources.GetObject("lblDefAgeValue.AccessibleName"), String)
		Me.lblDefAgeValue.Anchor = CType(resources.GetObject("lblDefAgeValue.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.lblDefAgeValue.AutoSize = CType(resources.GetObject("lblDefAgeValue.AutoSize"), Boolean)
		Me.lblDefAgeValue.Dock = CType(resources.GetObject("lblDefAgeValue.Dock"), System.Windows.Forms.DockStyle)
		Me.lblDefAgeValue.Enabled = CType(resources.GetObject("lblDefAgeValue.Enabled"), Boolean)
		Me.lblDefAgeValue.Font = CType(resources.GetObject("lblDefAgeValue.Font"), System.Drawing.Font)
		Me.lblDefAgeValue.Image = CType(resources.GetObject("lblDefAgeValue.Image"), System.Drawing.Image)
		Me.lblDefAgeValue.ImageAlign = CType(resources.GetObject("lblDefAgeValue.ImageAlign"), System.Drawing.ContentAlignment)
		Me.lblDefAgeValue.ImageIndex = CType(resources.GetObject("lblDefAgeValue.ImageIndex"), Integer)
		Me.lblDefAgeValue.ImeMode = CType(resources.GetObject("lblDefAgeValue.ImeMode"), System.Windows.Forms.ImeMode)
		Me.lblDefAgeValue.Location = CType(resources.GetObject("lblDefAgeValue.Location"), System.Drawing.Point)
		Me.lblDefAgeValue.Name = "lblDefAgeValue"
		Me.lblDefAgeValue.RightToLeft = CType(resources.GetObject("lblDefAgeValue.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.lblDefAgeValue.Size = CType(resources.GetObject("lblDefAgeValue.Size"), System.Drawing.Size)
		Me.lblDefAgeValue.TabIndex = CType(resources.GetObject("lblDefAgeValue.TabIndex"), Integer)
		Me.lblDefAgeValue.Text = resources.GetString("lblDefAgeValue.Text")
		Me.lblDefAgeValue.TextAlign = CType(resources.GetObject("lblDefAgeValue.TextAlign"), System.Drawing.ContentAlignment)
		Me.lblDefAgeValue.Visible = CType(resources.GetObject("lblDefAgeValue.Visible"), Boolean)
		'
		'lblDefNameValue
		'
		Me.lblDefNameValue.AccessibleDescription = CType(resources.GetObject("lblDefNameValue.AccessibleDescription"), String)
		Me.lblDefNameValue.AccessibleName = CType(resources.GetObject("lblDefNameValue.AccessibleName"), String)
		Me.lblDefNameValue.Anchor = CType(resources.GetObject("lblDefNameValue.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.lblDefNameValue.AutoSize = CType(resources.GetObject("lblDefNameValue.AutoSize"), Boolean)
		Me.lblDefNameValue.Dock = CType(resources.GetObject("lblDefNameValue.Dock"), System.Windows.Forms.DockStyle)
		Me.lblDefNameValue.Enabled = CType(resources.GetObject("lblDefNameValue.Enabled"), Boolean)
		Me.lblDefNameValue.Font = CType(resources.GetObject("lblDefNameValue.Font"), System.Drawing.Font)
		Me.lblDefNameValue.Image = CType(resources.GetObject("lblDefNameValue.Image"), System.Drawing.Image)
		Me.lblDefNameValue.ImageAlign = CType(resources.GetObject("lblDefNameValue.ImageAlign"), System.Drawing.ContentAlignment)
		Me.lblDefNameValue.ImageIndex = CType(resources.GetObject("lblDefNameValue.ImageIndex"), Integer)
		Me.lblDefNameValue.ImeMode = CType(resources.GetObject("lblDefNameValue.ImeMode"), System.Windows.Forms.ImeMode)
		Me.lblDefNameValue.Location = CType(resources.GetObject("lblDefNameValue.Location"), System.Drawing.Point)
		Me.lblDefNameValue.Name = "lblDefNameValue"
		Me.lblDefNameValue.RightToLeft = CType(resources.GetObject("lblDefNameValue.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.lblDefNameValue.Size = CType(resources.GetObject("lblDefNameValue.Size"), System.Drawing.Size)
		Me.lblDefNameValue.TabIndex = CType(resources.GetObject("lblDefNameValue.TabIndex"), Integer)
		Me.lblDefNameValue.Text = resources.GetString("lblDefNameValue.Text")
		Me.lblDefNameValue.TextAlign = CType(resources.GetObject("lblDefNameValue.TextAlign"), System.Drawing.ContentAlignment)
		Me.lblDefNameValue.Visible = CType(resources.GetObject("lblDefNameValue.Visible"), Boolean)
		'
		'lblDefAge
		'
		Me.lblDefAge.AccessibleDescription = CType(resources.GetObject("lblDefAge.AccessibleDescription"), String)
		Me.lblDefAge.AccessibleName = CType(resources.GetObject("lblDefAge.AccessibleName"), String)
		Me.lblDefAge.Anchor = CType(resources.GetObject("lblDefAge.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.lblDefAge.AutoSize = CType(resources.GetObject("lblDefAge.AutoSize"), Boolean)
		Me.lblDefAge.Dock = CType(resources.GetObject("lblDefAge.Dock"), System.Windows.Forms.DockStyle)
		Me.lblDefAge.Enabled = CType(resources.GetObject("lblDefAge.Enabled"), Boolean)
		Me.lblDefAge.Font = CType(resources.GetObject("lblDefAge.Font"), System.Drawing.Font)
		Me.lblDefAge.Image = CType(resources.GetObject("lblDefAge.Image"), System.Drawing.Image)
		Me.lblDefAge.ImageAlign = CType(resources.GetObject("lblDefAge.ImageAlign"), System.Drawing.ContentAlignment)
		Me.lblDefAge.ImageIndex = CType(resources.GetObject("lblDefAge.ImageIndex"), Integer)
		Me.lblDefAge.ImeMode = CType(resources.GetObject("lblDefAge.ImeMode"), System.Windows.Forms.ImeMode)
		Me.lblDefAge.Location = CType(resources.GetObject("lblDefAge.Location"), System.Drawing.Point)
		Me.lblDefAge.Name = "lblDefAge"
		Me.lblDefAge.RightToLeft = CType(resources.GetObject("lblDefAge.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.lblDefAge.Size = CType(resources.GetObject("lblDefAge.Size"), System.Drawing.Size)
		Me.lblDefAge.TabIndex = CType(resources.GetObject("lblDefAge.TabIndex"), Integer)
		Me.lblDefAge.Text = resources.GetString("lblDefAge.Text")
		Me.lblDefAge.TextAlign = CType(resources.GetObject("lblDefAge.TextAlign"), System.Drawing.ContentAlignment)
		Me.lblDefAge.Visible = CType(resources.GetObject("lblDefAge.Visible"), Boolean)
		'
		'lblDefName
		'
		Me.lblDefName.AccessibleDescription = CType(resources.GetObject("lblDefName.AccessibleDescription"), String)
		Me.lblDefName.AccessibleName = CType(resources.GetObject("lblDefName.AccessibleName"), String)
		Me.lblDefName.Anchor = CType(resources.GetObject("lblDefName.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.lblDefName.AutoSize = CType(resources.GetObject("lblDefName.AutoSize"), Boolean)
		Me.lblDefName.Dock = CType(resources.GetObject("lblDefName.Dock"), System.Windows.Forms.DockStyle)
		Me.lblDefName.Enabled = CType(resources.GetObject("lblDefName.Enabled"), Boolean)
		Me.lblDefName.Font = CType(resources.GetObject("lblDefName.Font"), System.Drawing.Font)
		Me.lblDefName.Image = CType(resources.GetObject("lblDefName.Image"), System.Drawing.Image)
		Me.lblDefName.ImageAlign = CType(resources.GetObject("lblDefName.ImageAlign"), System.Drawing.ContentAlignment)
		Me.lblDefName.ImageIndex = CType(resources.GetObject("lblDefName.ImageIndex"), Integer)
		Me.lblDefName.ImeMode = CType(resources.GetObject("lblDefName.ImeMode"), System.Windows.Forms.ImeMode)
		Me.lblDefName.Location = CType(resources.GetObject("lblDefName.Location"), System.Drawing.Point)
		Me.lblDefName.Name = "lblDefName"
		Me.lblDefName.RightToLeft = CType(resources.GetObject("lblDefName.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.lblDefName.Size = CType(resources.GetObject("lblDefName.Size"), System.Drawing.Size)
		Me.lblDefName.TabIndex = CType(resources.GetObject("lblDefName.TabIndex"), Integer)
		Me.lblDefName.Text = resources.GetString("lblDefName.Text")
		Me.lblDefName.TextAlign = CType(resources.GetObject("lblDefName.TextAlign"), System.Drawing.ContentAlignment)
		Me.lblDefName.Visible = CType(resources.GetObject("lblDefName.Visible"), Boolean)
		'
		'gbSingle
		'
		Me.gbSingle.AccessibleDescription = CType(resources.GetObject("gbSingle.AccessibleDescription"), String)
		Me.gbSingle.AccessibleName = CType(resources.GetObject("gbSingle.AccessibleName"), String)
		Me.gbSingle.Anchor = CType(resources.GetObject("gbSingle.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.gbSingle.BackgroundImage = CType(resources.GetObject("gbSingle.BackgroundImage"), System.Drawing.Image)
		Me.gbSingle.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdSingleDebug, Me.cmdSingleCall})
		Me.gbSingle.Dock = CType(resources.GetObject("gbSingle.Dock"), System.Windows.Forms.DockStyle)
		Me.gbSingle.Enabled = CType(resources.GetObject("gbSingle.Enabled"), Boolean)
		Me.gbSingle.Font = CType(resources.GetObject("gbSingle.Font"), System.Drawing.Font)
		Me.gbSingle.ImeMode = CType(resources.GetObject("gbSingle.ImeMode"), System.Windows.Forms.ImeMode)
		Me.gbSingle.Location = CType(resources.GetObject("gbSingle.Location"), System.Drawing.Point)
		Me.gbSingle.Name = "gbSingle"
		Me.gbSingle.RightToLeft = CType(resources.GetObject("gbSingle.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.gbSingle.Size = CType(resources.GetObject("gbSingle.Size"), System.Drawing.Size)
		Me.gbSingle.TabIndex = CType(resources.GetObject("gbSingle.TabIndex"), Integer)
		Me.gbSingle.TabStop = False
		Me.gbSingle.Text = resources.GetString("gbSingle.Text")
		Me.gbSingle.Visible = CType(resources.GetObject("gbSingle.Visible"), Boolean)
		'
		'cmdSingleDebug
		'
		Me.cmdSingleDebug.AccessibleDescription = CType(resources.GetObject("cmdSingleDebug.AccessibleDescription"), String)
		Me.cmdSingleDebug.AccessibleName = CType(resources.GetObject("cmdSingleDebug.AccessibleName"), String)
		Me.cmdSingleDebug.Anchor = CType(resources.GetObject("cmdSingleDebug.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdSingleDebug.BackgroundImage = CType(resources.GetObject("cmdSingleDebug.BackgroundImage"), System.Drawing.Image)
		Me.cmdSingleDebug.Dock = CType(resources.GetObject("cmdSingleDebug.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdSingleDebug.Enabled = CType(resources.GetObject("cmdSingleDebug.Enabled"), Boolean)
		Me.cmdSingleDebug.FlatStyle = CType(resources.GetObject("cmdSingleDebug.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdSingleDebug.Font = CType(resources.GetObject("cmdSingleDebug.Font"), System.Drawing.Font)
		Me.cmdSingleDebug.Image = CType(resources.GetObject("cmdSingleDebug.Image"), System.Drawing.Image)
		Me.cmdSingleDebug.ImageAlign = CType(resources.GetObject("cmdSingleDebug.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdSingleDebug.ImageIndex = CType(resources.GetObject("cmdSingleDebug.ImageIndex"), Integer)
		Me.cmdSingleDebug.ImeMode = CType(resources.GetObject("cmdSingleDebug.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdSingleDebug.Location = CType(resources.GetObject("cmdSingleDebug.Location"), System.Drawing.Point)
		Me.cmdSingleDebug.Name = "cmdSingleDebug"
		Me.cmdSingleDebug.RightToLeft = CType(resources.GetObject("cmdSingleDebug.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdSingleDebug.Size = CType(resources.GetObject("cmdSingleDebug.Size"), System.Drawing.Size)
		Me.cmdSingleDebug.TabIndex = CType(resources.GetObject("cmdSingleDebug.TabIndex"), Integer)
		Me.cmdSingleDebug.Text = resources.GetString("cmdSingleDebug.Text")
		Me.cmdSingleDebug.TextAlign = CType(resources.GetObject("cmdSingleDebug.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdSingleDebug.Visible = CType(resources.GetObject("cmdSingleDebug.Visible"), Boolean)
		'
		'cmdSingleCall
		'
		Me.cmdSingleCall.AccessibleDescription = CType(resources.GetObject("cmdSingleCall.AccessibleDescription"), String)
		Me.cmdSingleCall.AccessibleName = CType(resources.GetObject("cmdSingleCall.AccessibleName"), String)
		Me.cmdSingleCall.Anchor = CType(resources.GetObject("cmdSingleCall.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdSingleCall.BackgroundImage = CType(resources.GetObject("cmdSingleCall.BackgroundImage"), System.Drawing.Image)
		Me.cmdSingleCall.Dock = CType(resources.GetObject("cmdSingleCall.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdSingleCall.Enabled = CType(resources.GetObject("cmdSingleCall.Enabled"), Boolean)
		Me.cmdSingleCall.FlatStyle = CType(resources.GetObject("cmdSingleCall.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdSingleCall.Font = CType(resources.GetObject("cmdSingleCall.Font"), System.Drawing.Font)
		Me.cmdSingleCall.Image = CType(resources.GetObject("cmdSingleCall.Image"), System.Drawing.Image)
		Me.cmdSingleCall.ImageAlign = CType(resources.GetObject("cmdSingleCall.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdSingleCall.ImageIndex = CType(resources.GetObject("cmdSingleCall.ImageIndex"), Integer)
		Me.cmdSingleCall.ImeMode = CType(resources.GetObject("cmdSingleCall.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdSingleCall.Location = CType(resources.GetObject("cmdSingleCall.Location"), System.Drawing.Point)
		Me.cmdSingleCall.Name = "cmdSingleCall"
		Me.cmdSingleCall.RightToLeft = CType(resources.GetObject("cmdSingleCall.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdSingleCall.Size = CType(resources.GetObject("cmdSingleCall.Size"), System.Drawing.Size)
		Me.cmdSingleCall.TabIndex = CType(resources.GetObject("cmdSingleCall.TabIndex"), Integer)
		Me.cmdSingleCall.Text = resources.GetString("cmdSingleCall.Text")
		Me.cmdSingleCall.TextAlign = CType(resources.GetObject("cmdSingleCall.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdSingleCall.Visible = CType(resources.GetObject("cmdSingleCall.Visible"), Boolean)
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
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbSingle, Me.gbInputData, Me.gbTwo, Me.lstResponses, Me.cmdClear})
		Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
		Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
		Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
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
		Me.gbTwo.ResumeLayout(False)
		Me.gbInputData.ResumeLayout(False)
		Me.gbSingle.ResumeLayout(False)
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

	' To be used to obtain a reference to a Client Activated type
	' This is similar to DCOM style programming.
	Private mCustomer As Customer

	' This is to be used when we want multiple clients to connect
	' to the same object instance on the server
	Private mSCustomer As SingletonCustomer

	Private Sub SetCtlState(ByVal NewState As Boolean)
		' Ensable the create command button
		Me.cmdCreate.Enabled = NewState

		' Disable other command buttons
		Me.cmdGet.Enabled = (Not NewState)
		Me.cmdUpdate.Enabled = (Not NewState)
		Me.cmdUpdateAndGet.Enabled = (Not NewState)
		Me.cmdDebugData.Enabled = (Not NewState)
		Me.cmdRelease.Enabled = (Not NewState)

		' Set the radio buttons
		Me.rbClient.Enabled = NewState
		Me.rbSingle.Enabled = NewState

	End Sub

	Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
		'clear all items from the listbox
		Me.lstResponses.Items.Clear()
	End Sub

	Private Sub cmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
		Dim txt As String		  ' Used in the catch handlers
		Try
			Dim objNotCreated As Boolean = False

			If Me.rbClient.Checked = True Then
				' Use Client Activated Type
				' Notice that in this call to New you can pass parameters to the constructor
				' This type of object is very similar to a DCOM style object.
				mCustomer = New Customer(Me.lblDefNameValue.Text, CByte(Me.lblDefAgeValue.Text))
				objNotCreated = (mCustomer Is Nothing)
			Else
				' Use Server Activated Type
				' Notice that you can not pass values to a constructor in this case.
				' this is becuase the server creates the instance and makes it available 
				' to all as a singleton.  All we are doing is obtaining a reference to
				' the running instance via a proxy.
				Dim args() As Object
				mSCustomer = CType(Activator.CreateInstance(GetType(RemotingSample.SingletonCustomer), args), RemotingSample.SingletonCustomer)
				mSCustomer.NewClient()
				objNotCreated = (mSCustomer Is Nothing)
			End If

			' Change the command buttons state
			SetCtlState(objNotCreated)

		Catch exp As RemotingException
			' Will catch any generic Remoting exception
			txt = "I was unable to access the remote customer object." & vbCrLf & vbCrLf & _
			  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
			  "  Message: " & exp.Message & vbCrLf & _
			  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
			  "  Stack Trace:" & vbCrLf & _
			  exp.StackTrace()

			MessageBox.Show(txt, "Remoting Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Catch exp As System.Net.Sockets.SocketException
			' This will catch any Sockets exceptions.
			' This can be caused since we're using the binary
			' remoting interface which uses Sockets.
			txt = "I was unable to access the remote customer object." & vbCrLf & _
			  "Is it possible the server is not running?" & vbCrLf & vbCrLf & _
			  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
			  "  Message: " & exp.Message & vbCrLf & _
			  "  Source: " & exp.Source & vbCrLf & _
			  "  Error Code: " & exp.ErrorCode.ToString() & vbCrLf & _
			  "  Native Error Code: " & exp.NativeErrorCode.ToString() & vbCrLf & vbCrLf & _
			  "  Stack Trace:" & vbCrLf & _
			  exp.StackTrace

			MessageBox.Show(txt, "Socket Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Catch exp As Exception
			' Will catch any generic exception
			txt = "I was unable to access the remote customer object." & vbCrLf & vbCrLf & _
			  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
			  "  Message: " & exp.Message & vbCrLf & _
			  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
			  "  Stack Trace:" & vbCrLf & _
			  exp.StackTrace

			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

		End Try
	End Sub

	Private Sub cmdDebugData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDebugData.Click
		' Get debug data from the Client Activated type
		If ((Not mCustomer Is Nothing) Or (Not mSCustomer Is Nothing)) Then
			Try
				If Me.rbClient.Checked = True Then
					With Me.lstResponses.Items
						.Add("Debug data follows:")
						.Add(String.Format("  Creation Time: {0}", mCustomer.DebugCreationTime.ToString))
						.Add(String.Format("  Code Base: {0}", mCustomer.DebugCodeBase))
						.Add(String.Format("  Fully Qualified Name: {0}", mCustomer.DebugFQName))
						.Add(String.Format("  Remote Host Name: {0}", mCustomer.DebugHostName))
						.Add("End Debug Data")
					End With
				Else
					With Me.lstResponses.Items
						.Add("Debug data follows:")
						.Add(String.Format("  Creation Time: {0}", mSCustomer.DebugCreationTime.ToString))
						.Add(String.Format("  Code Base: {0}", mSCustomer.DebugCodeBase))
						.Add(String.Format("  Fully Qualified Name: {0}", mSCustomer.DebugFQName))
						.Add(String.Format("  Remote Host Name: {0}", mSCustomer.DebugHostName))
						.Add(String.Format("  Number of connected clients: {0}", mSCustomer.Connected.ToString()))
						.Add("End Debug Data")
					End With
				End If
			Catch exp As Exception
				' Will catch any generic exception
				' See the code in cmdCreate for more detailed examples.
				Dim txt As String
				txt = "I was unable to access the remote customer object." & vbCrLf & vbCrLf & _
				  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
				  "  Message: " & exp.Message & vbCrLf & _
				  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
				  "  Stack Trace:" & vbCrLf & _
				  exp.StackTrace

				MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

			End Try
		End If
	End Sub

	Private Sub cmdGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGet.Click
		' Ask the server for the customer data 
		Try
			If Me.rbClient.Checked = True Then
				Me.lstResponses.Items.Add(mCustomer.GetCustomerInfo())
			Else
				Me.lstResponses.Items.Add(mSCustomer.GetCustomerInfo())
			End If

		Catch exp As Exception
			' Will catch any generic exception
			' See the code in cmdCreate for more detailed examples.
			Dim txt As String
			txt = "I was unable to access the remote customer object." & vbCrLf & vbCrLf & _
			  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
			  "  Message: " & exp.Message & vbCrLf & _
			  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
			  "  Stack Trace:" & vbCrLf & _
			  exp.StackTrace

			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

		End Try
	End Sub

	Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
		' Update the values on the server using public properties.
		' Might not be the most effcient way to update data (esp. if you want a return value).
		' See cmdUpdateAndGet for another example.
		If ((Not mCustomer Is Nothing) Or (Not mSCustomer Is Nothing)) Then
			Try
				If Me.rbClient.Checked = True Then
					mCustomer.Name = Me.txtNewName.Text
					mCustomer.Age = CByte(Me.txtNewAge.Text)
				Else
					mSCustomer.Name = Me.txtNewName.Text
					mSCustomer.Age = CByte(Me.txtNewAge.Text)
				End If

				Me.lstResponses.Items.Add("Update using properties successful!")

			Catch exp As Exception
				' Will catch any generic exception
				' See the code in cmdCreate for more detailed examples.
				Dim txt As String
				txt = "I was unable to access the remote customer object." & vbCrLf & vbCrLf & _
				  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
				  "  Message: " & exp.Message & vbCrLf & _
				  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
				  "  Stack Trace:" & vbCrLf & _
				  exp.StackTrace

				MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

			End Try
		End If
	End Sub

	Private Sub cmdUpdateAndGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateAndGet.Click
		' Update the values on the server using a function that accepts both values
		' and get the return data of the Client Activated type.
		' This is generally a better format the code in cmdUpdate since it
		' gets more work done in fewer round-trips.
		If ((Not mCustomer Is Nothing) Or (Not mSCustomer Is Nothing)) Then
			Try
				If Me.rbClient.Checked = True Then
					With Me.lstResponses.Items
						.Add(mCustomer.UpdateCustomerInfo(Me.txtNewName.Text, CByte(Me.txtNewAge.Text)))
					End With
				Else
					With Me.lstResponses.Items
						.Add(mSCustomer.UpdateCustomerInfo(Me.txtNewName.Text, CByte(Me.txtNewAge.Text)))
					End With
				End If

			Catch exp As Exception
				' Will catch any generic exception
				' See the code in cmdCreate for more detailed examples.
				Dim txt As String
				txt = "I was unable to access the remote customer object." & vbCrLf & vbCrLf & _
				  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
				  "  Message: " & exp.Message & vbCrLf & _
				  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
				  "  Stack Trace:" & vbCrLf & _
				  exp.StackTrace

				MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			End Try
		End If

	End Sub

	Private Sub cmdRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRelease.Click
		' Release our reference to the server object
		If ((Not mCustomer Is Nothing) Or (Not mSCustomer Is Nothing)) Then
			Dim objReleased As Boolean = False
			If rbClient.Checked = True Then
				' Let go of the proxy reference
				mCustomer = Nothing
				objReleased = (mCustomer Is Nothing)
			Else
				' Since the object exposes the method, we should call it.
				' In our example it doesn't do anything fancy. It simply
				' lowers the connected count.
				mSCustomer.Dispose()
				mSCustomer = Nothing
				objReleased = (mSCustomer Is Nothing)
			End If

			' Change the command buttons state
			SetCtlState(objReleased)
		End If
	End Sub

	Private Sub cmdSingleCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSingleCall.Click
		' SingleCall objects only live for the life of one method call.
		' While the properties exist, they can only be used when the object is not
		' being used in SingleCall mode.
		' This model is very similar to a correct MTS/COM+ component implementation.

		' Even though we're not providing arguments, we must pass
		' array defined as object. Nothing won't work.
		Dim args() As Object
		Dim cust As SingleCallCustomer

		Try
			cust = CType(Activator.CreateInstance(GetType(RemotingSample.SingleCallCustomer), args), RemotingSample.SingleCallCustomer)
			With Me.lstResponses.Items
				.Add("SingleCall.UpdateCustomerInfo: " & cust.UpdateCustomerInfo(Me.txtNewName.Text, CByte(Me.txtNewAge.Text)))
				.Add("Update Successful!")
			End With
		Catch exp As Exception
			' Will catch any generic exception
			' See the code in cmdCreate for more detailed examples.
			Dim txt As String
			txt = "I was unable to access the remote customer object." & vbCrLf & vbCrLf & _
			  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
			  "  Message: " & exp.Message & vbCrLf & _
			  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
			  "  Stack Trace:" & vbCrLf & _
			  exp.StackTrace

			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

		End Try
	End Sub

	Private Sub cmdSingleDebug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSingleDebug.Click
		' SingleCall objects only live for the life of one method call.
		' Each time we go and get debug data, we're getting it from a 
		' new instance of the object.

		' Even though we're not providing arguments, we must pass
		' array defined as object. Nothing won't work.
		Dim args() As Object
		Dim scCust As SingleCallCustomer

		Try
			scCust = CType(Activator.CreateInstance(GetType(RemotingSample.SingleCallCustomer), args), RemotingSample.SingleCallCustomer)
			With Me.lstResponses.Items
				.Add("Debug data follows:")
				.Add(String.Format("  Creation Time: {0}", scCust.DebugCreationTime.ToString))
				.Add(String.Format("  Code Base: {0}", scCust.DebugCodeBase))
				.Add(String.Format("  Fully Qualified Name: {0}", scCust.DebugFQName))
				.Add(String.Format("  Remote Host Name: {0}", scCust.DebugHostName))
				' Notice how the creation time is different!
				.Add(String.Format("  Creation Time: {0}", scCust.DebugCreationTime.ToString))
				.Add("End Debug Data")
			End With

		Catch exp As Exception
			' Will catch any generic exception
			' See the code in cmdCreate for more detailed examples.
			Dim txt As String
			txt = "I was unable to access the remote customer object." & vbCrLf & vbCrLf & _
			  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
			  "  Message: " & exp.Message & vbCrLf & _
			  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
			  "  Stack Trace:" & vbCrLf & _
			  exp.StackTrace

			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

		End Try

	End Sub

	Private Sub frmMain_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		' Let go of any objects we may still be holding on to
		If Not mCustomer Is Nothing Then
			mCustomer = Nothing
		End If
	End Sub

	Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'Read in the application configuration file (client.exe.config).  This file has the remoting configuration
		'information for the client side remoting infrastructure.
		Try
			' This assumes the file is in the same directory as this exe.
			RemotingConfiguration.Configure("client.exe.config")

		Catch exp As Exception
			' Will catch any generic exception
			Dim txt As String
			txt = "I was unable to load the file config.xml." & vbCrLf & _
			  "Please make sure it is located in the same directory as this exe " & _
			  " and that it is in the correct format." & vbCrLf & _
			  "Please see the Help, About box for the location of this exe." & vbCrLf & vbCrLf & _
			  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
			  "  Message: " & exp.Message & vbCrLf & _
			  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
			  "  Stack Trace:" & vbCrLf & _
			  exp.StackTrace

			MessageBox.Show(txt, "Generic Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)

			' turn of the create command buttons
			Me.cmdCreate.Enabled = False
		End Try

	End Sub

	Private Sub txtNewAge_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNewAge.Validating
		' Check to make sure only numeric values are entered
		' and check to see if the datatype is a byte
		Try
			Dim d As Byte = CByte(Me.txtNewAge.Text)
		Catch exp As Exception
			Dim txt As String
			txt = "The value you entered, '{0}', for the Customer's New Age is incorrect." & vbCrLf & _
			"Please enter a value in the range of 0 to 255." & vbCrLf & _
			"The value will be reset to 0 by default."

			MessageBox.Show(String.Format(txt, Me.txtNewAge.Text), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

			' Set the default value to 0 and cancel the field exit.
			Me.txtNewAge.Text = "0"
			e.Cancel = True
		End Try
	End Sub
End Class