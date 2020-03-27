'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO

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
	Friend WithEvents grpInputs As System.Windows.Forms.GroupBox
	Friend WithEvents grpCommands As System.Windows.Forms.GroupBox
	Friend WithEvents cmdNoTryCatch As System.Windows.Forms.Button
	Friend WithEvents txtFileName As System.Windows.Forms.TextBox
	Friend WithEvents lblFileName As System.Windows.Forms.Label
	Friend WithEvents cmdBasicTryCatch As System.Windows.Forms.Button
	Friend WithEvents cmdDetailedTryCatch As System.Windows.Forms.Button
	Friend WithEvents cmdTryCatchFinally As System.Windows.Forms.Button
	Friend WithEvents cmdCustomMessage As System.Windows.Forms.Button
	Friend WithEvents txtMessage As System.Windows.Forms.TextBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.grpInputs = New System.Windows.Forms.GroupBox()
		Me.txtMessage = New System.Windows.Forms.TextBox()
		Me.lblFileName = New System.Windows.Forms.Label()
		Me.txtFileName = New System.Windows.Forms.TextBox()
		Me.grpCommands = New System.Windows.Forms.GroupBox()
		Me.cmdCustomMessage = New System.Windows.Forms.Button()
		Me.cmdTryCatchFinally = New System.Windows.Forms.Button()
		Me.cmdDetailedTryCatch = New System.Windows.Forms.Button()
		Me.cmdBasicTryCatch = New System.Windows.Forms.Button()
		Me.cmdNoTryCatch = New System.Windows.Forms.Button()
		Me.grpInputs.SuspendLayout()
		Me.grpCommands.SuspendLayout()
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
		'grpInputs
		'
		Me.grpInputs.AccessibleDescription = CType(resources.GetObject("grpInputs.AccessibleDescription"), String)
		Me.grpInputs.AccessibleName = CType(resources.GetObject("grpInputs.AccessibleName"), String)
		Me.grpInputs.Anchor = CType(resources.GetObject("grpInputs.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.grpInputs.BackgroundImage = CType(resources.GetObject("grpInputs.BackgroundImage"), System.Drawing.Image)
		Me.grpInputs.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMessage, Me.lblFileName, Me.txtFileName})
		Me.grpInputs.Dock = CType(resources.GetObject("grpInputs.Dock"), System.Windows.Forms.DockStyle)
		Me.grpInputs.Enabled = CType(resources.GetObject("grpInputs.Enabled"), Boolean)
		Me.grpInputs.Font = CType(resources.GetObject("grpInputs.Font"), System.Drawing.Font)
		Me.grpInputs.ImeMode = CType(resources.GetObject("grpInputs.ImeMode"), System.Windows.Forms.ImeMode)
		Me.grpInputs.Location = CType(resources.GetObject("grpInputs.Location"), System.Drawing.Point)
		Me.grpInputs.Name = "grpInputs"
		Me.grpInputs.RightToLeft = CType(resources.GetObject("grpInputs.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.grpInputs.Size = CType(resources.GetObject("grpInputs.Size"), System.Drawing.Size)
		Me.grpInputs.TabIndex = CType(resources.GetObject("grpInputs.TabIndex"), Integer)
		Me.grpInputs.TabStop = False
		Me.grpInputs.Text = resources.GetString("grpInputs.Text")
		Me.grpInputs.Visible = CType(resources.GetObject("grpInputs.Visible"), Boolean)
		'
		'txtMessage
		'
		Me.txtMessage.AccessibleDescription = CType(resources.GetObject("txtMessage.AccessibleDescription"), String)
		Me.txtMessage.AccessibleName = CType(resources.GetObject("txtMessage.AccessibleName"), String)
		Me.txtMessage.Anchor = CType(resources.GetObject("txtMessage.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.txtMessage.AutoSize = CType(resources.GetObject("txtMessage.AutoSize"), Boolean)
		Me.txtMessage.BackColor = System.Drawing.SystemColors.Control
		Me.txtMessage.BackgroundImage = CType(resources.GetObject("txtMessage.BackgroundImage"), System.Drawing.Image)
		Me.txtMessage.Dock = CType(resources.GetObject("txtMessage.Dock"), System.Windows.Forms.DockStyle)
		Me.txtMessage.Enabled = CType(resources.GetObject("txtMessage.Enabled"), Boolean)
		Me.txtMessage.Font = CType(resources.GetObject("txtMessage.Font"), System.Drawing.Font)
		Me.txtMessage.ImeMode = CType(resources.GetObject("txtMessage.ImeMode"), System.Windows.Forms.ImeMode)
		Me.txtMessage.Location = CType(resources.GetObject("txtMessage.Location"), System.Drawing.Point)
		Me.txtMessage.MaxLength = CType(resources.GetObject("txtMessage.MaxLength"), Integer)
		Me.txtMessage.Multiline = CType(resources.GetObject("txtMessage.Multiline"), Boolean)
		Me.txtMessage.Name = "txtMessage"
		Me.txtMessage.PasswordChar = CType(resources.GetObject("txtMessage.PasswordChar"), Char)
		Me.txtMessage.ReadOnly = True
		Me.txtMessage.RightToLeft = CType(resources.GetObject("txtMessage.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.txtMessage.ScrollBars = CType(resources.GetObject("txtMessage.ScrollBars"), System.Windows.Forms.ScrollBars)
		Me.txtMessage.Size = CType(resources.GetObject("txtMessage.Size"), System.Drawing.Size)
		Me.txtMessage.TabIndex = CType(resources.GetObject("txtMessage.TabIndex"), Integer)
		Me.txtMessage.Text = resources.GetString("txtMessage.Text")
		Me.txtMessage.TextAlign = CType(resources.GetObject("txtMessage.TextAlign"), System.Windows.Forms.HorizontalAlignment)
		Me.txtMessage.Visible = CType(resources.GetObject("txtMessage.Visible"), Boolean)
		Me.txtMessage.WordWrap = CType(resources.GetObject("txtMessage.WordWrap"), Boolean)
		'
		'lblFileName
		'
		Me.lblFileName.AccessibleDescription = CType(resources.GetObject("lblFileName.AccessibleDescription"), String)
		Me.lblFileName.AccessibleName = CType(resources.GetObject("lblFileName.AccessibleName"), String)
		Me.lblFileName.Anchor = CType(resources.GetObject("lblFileName.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.lblFileName.AutoSize = CType(resources.GetObject("lblFileName.AutoSize"), Boolean)
		Me.lblFileName.Dock = CType(resources.GetObject("lblFileName.Dock"), System.Windows.Forms.DockStyle)
		Me.lblFileName.Enabled = CType(resources.GetObject("lblFileName.Enabled"), Boolean)
		Me.lblFileName.Font = CType(resources.GetObject("lblFileName.Font"), System.Drawing.Font)
		Me.lblFileName.Image = CType(resources.GetObject("lblFileName.Image"), System.Drawing.Image)
		Me.lblFileName.ImageAlign = CType(resources.GetObject("lblFileName.ImageAlign"), System.Drawing.ContentAlignment)
		Me.lblFileName.ImageIndex = CType(resources.GetObject("lblFileName.ImageIndex"), Integer)
		Me.lblFileName.ImeMode = CType(resources.GetObject("lblFileName.ImeMode"), System.Windows.Forms.ImeMode)
		Me.lblFileName.Location = CType(resources.GetObject("lblFileName.Location"), System.Drawing.Point)
		Me.lblFileName.Name = "lblFileName"
		Me.lblFileName.RightToLeft = CType(resources.GetObject("lblFileName.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.lblFileName.Size = CType(resources.GetObject("lblFileName.Size"), System.Drawing.Size)
		Me.lblFileName.TabIndex = CType(resources.GetObject("lblFileName.TabIndex"), Integer)
		Me.lblFileName.Text = resources.GetString("lblFileName.Text")
		Me.lblFileName.TextAlign = CType(resources.GetObject("lblFileName.TextAlign"), System.Drawing.ContentAlignment)
		Me.lblFileName.Visible = CType(resources.GetObject("lblFileName.Visible"), Boolean)
		'
		'txtFileName
		'
		Me.txtFileName.AccessibleDescription = CType(resources.GetObject("txtFileName.AccessibleDescription"), String)
		Me.txtFileName.AccessibleName = CType(resources.GetObject("txtFileName.AccessibleName"), String)
		Me.txtFileName.Anchor = CType(resources.GetObject("txtFileName.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.txtFileName.AutoSize = CType(resources.GetObject("txtFileName.AutoSize"), Boolean)
		Me.txtFileName.BackgroundImage = CType(resources.GetObject("txtFileName.BackgroundImage"), System.Drawing.Image)
		Me.txtFileName.Dock = CType(resources.GetObject("txtFileName.Dock"), System.Windows.Forms.DockStyle)
		Me.txtFileName.Enabled = CType(resources.GetObject("txtFileName.Enabled"), Boolean)
		Me.txtFileName.Font = CType(resources.GetObject("txtFileName.Font"), System.Drawing.Font)
		Me.txtFileName.ImeMode = CType(resources.GetObject("txtFileName.ImeMode"), System.Windows.Forms.ImeMode)
		Me.txtFileName.Location = CType(resources.GetObject("txtFileName.Location"), System.Drawing.Point)
		Me.txtFileName.MaxLength = CType(resources.GetObject("txtFileName.MaxLength"), Integer)
		Me.txtFileName.Multiline = CType(resources.GetObject("txtFileName.Multiline"), Boolean)
		Me.txtFileName.Name = "txtFileName"
		Me.txtFileName.PasswordChar = CType(resources.GetObject("txtFileName.PasswordChar"), Char)
		Me.txtFileName.RightToLeft = CType(resources.GetObject("txtFileName.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.txtFileName.ScrollBars = CType(resources.GetObject("txtFileName.ScrollBars"), System.Windows.Forms.ScrollBars)
		Me.txtFileName.Size = CType(resources.GetObject("txtFileName.Size"), System.Drawing.Size)
		Me.txtFileName.TabIndex = CType(resources.GetObject("txtFileName.TabIndex"), Integer)
		Me.txtFileName.Text = resources.GetString("txtFileName.Text")
		Me.txtFileName.TextAlign = CType(resources.GetObject("txtFileName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
		Me.txtFileName.Visible = CType(resources.GetObject("txtFileName.Visible"), Boolean)
		Me.txtFileName.WordWrap = CType(resources.GetObject("txtFileName.WordWrap"), Boolean)
		'
		'grpCommands
		'
		Me.grpCommands.AccessibleDescription = CType(resources.GetObject("grpCommands.AccessibleDescription"), String)
		Me.grpCommands.AccessibleName = CType(resources.GetObject("grpCommands.AccessibleName"), String)
		Me.grpCommands.Anchor = CType(resources.GetObject("grpCommands.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.grpCommands.BackgroundImage = CType(resources.GetObject("grpCommands.BackgroundImage"), System.Drawing.Image)
		Me.grpCommands.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCustomMessage, Me.cmdTryCatchFinally, Me.cmdDetailedTryCatch, Me.cmdBasicTryCatch, Me.cmdNoTryCatch})
		Me.grpCommands.Dock = CType(resources.GetObject("grpCommands.Dock"), System.Windows.Forms.DockStyle)
		Me.grpCommands.Enabled = CType(resources.GetObject("grpCommands.Enabled"), Boolean)
		Me.grpCommands.Font = CType(resources.GetObject("grpCommands.Font"), System.Drawing.Font)
		Me.grpCommands.ImeMode = CType(resources.GetObject("grpCommands.ImeMode"), System.Windows.Forms.ImeMode)
		Me.grpCommands.Location = CType(resources.GetObject("grpCommands.Location"), System.Drawing.Point)
		Me.grpCommands.Name = "grpCommands"
		Me.grpCommands.RightToLeft = CType(resources.GetObject("grpCommands.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.grpCommands.Size = CType(resources.GetObject("grpCommands.Size"), System.Drawing.Size)
		Me.grpCommands.TabIndex = CType(resources.GetObject("grpCommands.TabIndex"), Integer)
		Me.grpCommands.TabStop = False
		Me.grpCommands.Text = resources.GetString("grpCommands.Text")
		Me.grpCommands.Visible = CType(resources.GetObject("grpCommands.Visible"), Boolean)
		'
		'cmdCustomMessage
		'
		Me.cmdCustomMessage.AccessibleDescription = CType(resources.GetObject("cmdCustomMessage.AccessibleDescription"), String)
		Me.cmdCustomMessage.AccessibleName = CType(resources.GetObject("cmdCustomMessage.AccessibleName"), String)
		Me.cmdCustomMessage.Anchor = CType(resources.GetObject("cmdCustomMessage.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdCustomMessage.BackgroundImage = CType(resources.GetObject("cmdCustomMessage.BackgroundImage"), System.Drawing.Image)
		Me.cmdCustomMessage.Dock = CType(resources.GetObject("cmdCustomMessage.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdCustomMessage.Enabled = CType(resources.GetObject("cmdCustomMessage.Enabled"), Boolean)
		Me.cmdCustomMessage.FlatStyle = CType(resources.GetObject("cmdCustomMessage.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdCustomMessage.Font = CType(resources.GetObject("cmdCustomMessage.Font"), System.Drawing.Font)
		Me.cmdCustomMessage.Image = CType(resources.GetObject("cmdCustomMessage.Image"), System.Drawing.Image)
		Me.cmdCustomMessage.ImageAlign = CType(resources.GetObject("cmdCustomMessage.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdCustomMessage.ImageIndex = CType(resources.GetObject("cmdCustomMessage.ImageIndex"), Integer)
		Me.cmdCustomMessage.ImeMode = CType(resources.GetObject("cmdCustomMessage.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdCustomMessage.Location = CType(resources.GetObject("cmdCustomMessage.Location"), System.Drawing.Point)
		Me.cmdCustomMessage.Name = "cmdCustomMessage"
		Me.cmdCustomMessage.RightToLeft = CType(resources.GetObject("cmdCustomMessage.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdCustomMessage.Size = CType(resources.GetObject("cmdCustomMessage.Size"), System.Drawing.Size)
		Me.cmdCustomMessage.TabIndex = CType(resources.GetObject("cmdCustomMessage.TabIndex"), Integer)
		Me.cmdCustomMessage.Text = resources.GetString("cmdCustomMessage.Text")
		Me.cmdCustomMessage.TextAlign = CType(resources.GetObject("cmdCustomMessage.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdCustomMessage.Visible = CType(resources.GetObject("cmdCustomMessage.Visible"), Boolean)
		'
		'cmdTryCatchFinally
		'
		Me.cmdTryCatchFinally.AccessibleDescription = CType(resources.GetObject("cmdTryCatchFinally.AccessibleDescription"), String)
		Me.cmdTryCatchFinally.AccessibleName = CType(resources.GetObject("cmdTryCatchFinally.AccessibleName"), String)
		Me.cmdTryCatchFinally.Anchor = CType(resources.GetObject("cmdTryCatchFinally.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdTryCatchFinally.BackgroundImage = CType(resources.GetObject("cmdTryCatchFinally.BackgroundImage"), System.Drawing.Image)
		Me.cmdTryCatchFinally.Dock = CType(resources.GetObject("cmdTryCatchFinally.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdTryCatchFinally.Enabled = CType(resources.GetObject("cmdTryCatchFinally.Enabled"), Boolean)
		Me.cmdTryCatchFinally.FlatStyle = CType(resources.GetObject("cmdTryCatchFinally.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdTryCatchFinally.Font = CType(resources.GetObject("cmdTryCatchFinally.Font"), System.Drawing.Font)
		Me.cmdTryCatchFinally.Image = CType(resources.GetObject("cmdTryCatchFinally.Image"), System.Drawing.Image)
		Me.cmdTryCatchFinally.ImageAlign = CType(resources.GetObject("cmdTryCatchFinally.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdTryCatchFinally.ImageIndex = CType(resources.GetObject("cmdTryCatchFinally.ImageIndex"), Integer)
		Me.cmdTryCatchFinally.ImeMode = CType(resources.GetObject("cmdTryCatchFinally.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdTryCatchFinally.Location = CType(resources.GetObject("cmdTryCatchFinally.Location"), System.Drawing.Point)
		Me.cmdTryCatchFinally.Name = "cmdTryCatchFinally"
		Me.cmdTryCatchFinally.RightToLeft = CType(resources.GetObject("cmdTryCatchFinally.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdTryCatchFinally.Size = CType(resources.GetObject("cmdTryCatchFinally.Size"), System.Drawing.Size)
		Me.cmdTryCatchFinally.TabIndex = CType(resources.GetObject("cmdTryCatchFinally.TabIndex"), Integer)
		Me.cmdTryCatchFinally.Text = resources.GetString("cmdTryCatchFinally.Text")
		Me.cmdTryCatchFinally.TextAlign = CType(resources.GetObject("cmdTryCatchFinally.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdTryCatchFinally.Visible = CType(resources.GetObject("cmdTryCatchFinally.Visible"), Boolean)
		'
		'cmdDetailedTryCatch
		'
		Me.cmdDetailedTryCatch.AccessibleDescription = CType(resources.GetObject("cmdDetailedTryCatch.AccessibleDescription"), String)
		Me.cmdDetailedTryCatch.AccessibleName = CType(resources.GetObject("cmdDetailedTryCatch.AccessibleName"), String)
		Me.cmdDetailedTryCatch.Anchor = CType(resources.GetObject("cmdDetailedTryCatch.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdDetailedTryCatch.BackgroundImage = CType(resources.GetObject("cmdDetailedTryCatch.BackgroundImage"), System.Drawing.Image)
		Me.cmdDetailedTryCatch.Dock = CType(resources.GetObject("cmdDetailedTryCatch.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdDetailedTryCatch.Enabled = CType(resources.GetObject("cmdDetailedTryCatch.Enabled"), Boolean)
		Me.cmdDetailedTryCatch.FlatStyle = CType(resources.GetObject("cmdDetailedTryCatch.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdDetailedTryCatch.Font = CType(resources.GetObject("cmdDetailedTryCatch.Font"), System.Drawing.Font)
		Me.cmdDetailedTryCatch.Image = CType(resources.GetObject("cmdDetailedTryCatch.Image"), System.Drawing.Image)
		Me.cmdDetailedTryCatch.ImageAlign = CType(resources.GetObject("cmdDetailedTryCatch.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdDetailedTryCatch.ImageIndex = CType(resources.GetObject("cmdDetailedTryCatch.ImageIndex"), Integer)
		Me.cmdDetailedTryCatch.ImeMode = CType(resources.GetObject("cmdDetailedTryCatch.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdDetailedTryCatch.Location = CType(resources.GetObject("cmdDetailedTryCatch.Location"), System.Drawing.Point)
		Me.cmdDetailedTryCatch.Name = "cmdDetailedTryCatch"
		Me.cmdDetailedTryCatch.RightToLeft = CType(resources.GetObject("cmdDetailedTryCatch.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdDetailedTryCatch.Size = CType(resources.GetObject("cmdDetailedTryCatch.Size"), System.Drawing.Size)
		Me.cmdDetailedTryCatch.TabIndex = CType(resources.GetObject("cmdDetailedTryCatch.TabIndex"), Integer)
		Me.cmdDetailedTryCatch.Text = resources.GetString("cmdDetailedTryCatch.Text")
		Me.cmdDetailedTryCatch.TextAlign = CType(resources.GetObject("cmdDetailedTryCatch.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdDetailedTryCatch.Visible = CType(resources.GetObject("cmdDetailedTryCatch.Visible"), Boolean)
		'
		'cmdBasicTryCatch
		'
		Me.cmdBasicTryCatch.AccessibleDescription = CType(resources.GetObject("cmdBasicTryCatch.AccessibleDescription"), String)
		Me.cmdBasicTryCatch.AccessibleName = CType(resources.GetObject("cmdBasicTryCatch.AccessibleName"), String)
		Me.cmdBasicTryCatch.Anchor = CType(resources.GetObject("cmdBasicTryCatch.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdBasicTryCatch.BackgroundImage = CType(resources.GetObject("cmdBasicTryCatch.BackgroundImage"), System.Drawing.Image)
		Me.cmdBasicTryCatch.Dock = CType(resources.GetObject("cmdBasicTryCatch.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdBasicTryCatch.Enabled = CType(resources.GetObject("cmdBasicTryCatch.Enabled"), Boolean)
		Me.cmdBasicTryCatch.FlatStyle = CType(resources.GetObject("cmdBasicTryCatch.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdBasicTryCatch.Font = CType(resources.GetObject("cmdBasicTryCatch.Font"), System.Drawing.Font)
		Me.cmdBasicTryCatch.Image = CType(resources.GetObject("cmdBasicTryCatch.Image"), System.Drawing.Image)
		Me.cmdBasicTryCatch.ImageAlign = CType(resources.GetObject("cmdBasicTryCatch.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdBasicTryCatch.ImageIndex = CType(resources.GetObject("cmdBasicTryCatch.ImageIndex"), Integer)
		Me.cmdBasicTryCatch.ImeMode = CType(resources.GetObject("cmdBasicTryCatch.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdBasicTryCatch.Location = CType(resources.GetObject("cmdBasicTryCatch.Location"), System.Drawing.Point)
		Me.cmdBasicTryCatch.Name = "cmdBasicTryCatch"
		Me.cmdBasicTryCatch.RightToLeft = CType(resources.GetObject("cmdBasicTryCatch.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdBasicTryCatch.Size = CType(resources.GetObject("cmdBasicTryCatch.Size"), System.Drawing.Size)
		Me.cmdBasicTryCatch.TabIndex = CType(resources.GetObject("cmdBasicTryCatch.TabIndex"), Integer)
		Me.cmdBasicTryCatch.Text = resources.GetString("cmdBasicTryCatch.Text")
		Me.cmdBasicTryCatch.TextAlign = CType(resources.GetObject("cmdBasicTryCatch.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdBasicTryCatch.Visible = CType(resources.GetObject("cmdBasicTryCatch.Visible"), Boolean)
		'
		'cmdNoTryCatch
		'
		Me.cmdNoTryCatch.AccessibleDescription = CType(resources.GetObject("cmdNoTryCatch.AccessibleDescription"), String)
		Me.cmdNoTryCatch.AccessibleName = CType(resources.GetObject("cmdNoTryCatch.AccessibleName"), String)
		Me.cmdNoTryCatch.Anchor = CType(resources.GetObject("cmdNoTryCatch.Anchor"), System.Windows.Forms.AnchorStyles)
		Me.cmdNoTryCatch.BackgroundImage = CType(resources.GetObject("cmdNoTryCatch.BackgroundImage"), System.Drawing.Image)
		Me.cmdNoTryCatch.Dock = CType(resources.GetObject("cmdNoTryCatch.Dock"), System.Windows.Forms.DockStyle)
		Me.cmdNoTryCatch.Enabled = CType(resources.GetObject("cmdNoTryCatch.Enabled"), Boolean)
		Me.cmdNoTryCatch.FlatStyle = CType(resources.GetObject("cmdNoTryCatch.FlatStyle"), System.Windows.Forms.FlatStyle)
		Me.cmdNoTryCatch.Font = CType(resources.GetObject("cmdNoTryCatch.Font"), System.Drawing.Font)
		Me.cmdNoTryCatch.Image = CType(resources.GetObject("cmdNoTryCatch.Image"), System.Drawing.Image)
		Me.cmdNoTryCatch.ImageAlign = CType(resources.GetObject("cmdNoTryCatch.ImageAlign"), System.Drawing.ContentAlignment)
		Me.cmdNoTryCatch.ImageIndex = CType(resources.GetObject("cmdNoTryCatch.ImageIndex"), Integer)
		Me.cmdNoTryCatch.ImeMode = CType(resources.GetObject("cmdNoTryCatch.ImeMode"), System.Windows.Forms.ImeMode)
		Me.cmdNoTryCatch.Location = CType(resources.GetObject("cmdNoTryCatch.Location"), System.Drawing.Point)
		Me.cmdNoTryCatch.Name = "cmdNoTryCatch"
		Me.cmdNoTryCatch.RightToLeft = CType(resources.GetObject("cmdNoTryCatch.RightToLeft"), System.Windows.Forms.RightToLeft)
		Me.cmdNoTryCatch.Size = CType(resources.GetObject("cmdNoTryCatch.Size"), System.Drawing.Size)
		Me.cmdNoTryCatch.TabIndex = CType(resources.GetObject("cmdNoTryCatch.TabIndex"), Integer)
		Me.cmdNoTryCatch.Text = resources.GetString("cmdNoTryCatch.Text")
		Me.cmdNoTryCatch.TextAlign = CType(resources.GetObject("cmdNoTryCatch.TextAlign"), System.Drawing.ContentAlignment)
		Me.cmdNoTryCatch.Visible = CType(resources.GetObject("cmdNoTryCatch.Visible"), Boolean)
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
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpCommands, Me.grpInputs})
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
		Me.grpInputs.ResumeLayout(False)
		Me.grpCommands.ResumeLayout(False)
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
	' Load the message for the text box that is below the file name text box.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' The code below uses the new StringWriter to build a string in memory.
		' The WriteLine commands append code to the string buffer with carriage return and line feed.
		Dim txt As StringWriter = New StringWriter()

		With txt
			.WriteLine("Enter a file name & path to test error handling. ")
			.WriteLine("Try different combinations for example:")
			.WriteLine("")
			.WriteLine("  C:\nofile.txt")
			.WriteLine("  c:\nodir\nofile.txt")
			.WriteLine("  \\noserver\noshare\nofile.txt")
		End With

		' Ask the StringWriter to covert its buffer to a string
		Me.txtMessage.Text = txt.ToString()
	End Sub

#End Region

	Private Sub cmdNoTryCatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoTryCatch.Click
		' Ask to make sure the user is willing to possibly blow up the program.
		Dim strMsg As String = "The following code has no error handling and will cause an unhandled exception if a file is not found. Do you want to continue?"
		If MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
			' Use the FileStream class from the System.IO Namespace (see Imports at top of file).
			Dim fs As FileStream

			' This command will fail if the file does not exist.
			fs = File.Open(Me.txtFileName.Text, FileMode.Open)
			MessageBox.Show("The size of the file is: " & fs.Length, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			fs.Close()

		End If
	End Sub

	Private Sub cmdBasicTryCatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBasicTryCatch.Click
		' This procedure will perform a basic Try, Catch.
		' Use the FileStream class from the System.IO Namespace (see Imports at top of file).
		Dim fs As FileStream

		Try
			' This command will fail if the file does not exist.
			fs = File.Open(Me.txtFileName.Text, FileMode.Open)
			MessageBox.Show("The size of the file is: " & fs.Length, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			fs.Close()

		Catch exp As Exception
			' Will catch any error that we're not explicitly trapping.
			MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
		End Try
	End Sub

	Private Sub cmdDetailedTryCatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDetailedTryCatch.Click
		' This procedure will perform a specific Try, Catch looking for any IO related errors.
		' Use the FileStream class from the System.IO Namespace (see Imports at top of file).
		Dim fs As FileStream

		Try
			' This command will fail if the file does not exist.
			fs = File.Open(Me.txtFileName.Text, FileMode.Open)
			MessageBox.Show("The size of the file is: " & fs.Length, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			fs.Close()
		Catch exp As FileNotFoundException
			' Will catch an error when the file requested does not exist.
			MessageBox.Show("The file you requested does not exist.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Catch exp As DirectoryNotFoundException
			' Will catch an error when the directory requested does not exist.
			MessageBox.Show("The directory you requested does not exist.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Catch exp As IOException
			' Will catch any generic IO exception.
			MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Catch exp As Exception
			' Will catch any error that we're not explicitly trapping.
			MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

		End Try
	End Sub

	Private Sub cmdCustomMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomMessage.Click
		' This procedure will perform a specific Try, Catch looking for any IO related errors
		' Use the FileStream class from the System.IO Namespace (see Imports at top of file)
		Dim fs As FileStream

		Try
			' This command will fail if the file does not exist
			fs = File.Open(Me.txtFileName.Text, FileMode.Open)
			MessageBox.Show("The size of the file is: " & fs.Length, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			fs.Close()

		Catch exp As IOException
			' Will catch any generic IO exception
			' You could use the StringWriter to build a multi-line string in memory.
			' However, it's overkill for this simple message.
			' FYI StringWriter comes from the System.IO Namespace.
			Dim strMsg As String
			strMsg = "I was unable to open the file you requested, " & Me.txtFileName.Text & vbCrLf & vbCrLf & _
			  "Detailed Error Information below:" & vbCrLf & vbCrLf & _
			  "  Message: " & exp.Message & vbCrLf & _
			  "  Source: " & exp.Source & vbCrLf & vbCrLf & _
			  "  Stack Trace:" & vbCrLf

			Dim strStackTrace As String

			' Accessing an exception objects StackTrace could cause an exception
			' thus we need to wrap the call in its own Try, Catch block.
			Try
				strStackTrace = exp.StackTrace()
			Catch stExp As Security.SecurityException
				strStackTrace = "Unable to access stack trace due to security restrictions."

			Catch stExp As Exception
				strStackTrace = "Unable to access stack trace."
			End Try

			strMsg = strMsg & strStackTrace

			MessageBox.Show(strMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Catch exp As System.Exception
			' This catch will trap any error unexpected error.
			MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

		End Try
	End Sub

	Private Sub cmdTryCatchFinally_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTryCatchFinally.Click
		' This procedure will perform a basic Try, Catch, and then a Finally.
		' Use the FileStream class from the System.IO Namespace (see Imports at top of file).
		Dim fs As FileStream

		Try
			' This command will fail if the file does not exist.
			fs = File.Open(Me.txtFileName.Text, FileMode.Open)
			MessageBox.Show("The size of the file is: " & fs.Length, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch exp As Exception
			' Will catch any error that we're not explicitly trapping.
			MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Finally
			' If we didn't open the file successfully, then our reference will be Nothing.
			If Not fs Is Nothing Then
				fs.Close()
				MessageBox.Show("File closed successfully in Finally block", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
		End Try
	End Sub
End Class