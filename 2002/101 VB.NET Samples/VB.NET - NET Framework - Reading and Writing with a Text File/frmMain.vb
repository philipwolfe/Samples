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
    Friend WithEvents txtFileText As System.Windows.Forms.TextBox
    Friend WithEvents lblFileText As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnStreamWriterCreateFile As System.Windows.Forms.Button
    Friend WithEvents btnStreamWriterAppendToFile As System.Windows.Forms.Button
    Friend WithEvents btnStringReaderReadFileInLines As System.Windows.Forms.Button
    Friend WithEvents btnStreamReaderReadFromFile As System.Windows.Forms.Button
    Friend WithEvents sdlgFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnNewFileName As System.Windows.Forms.Button
    Friend WithEvents btnOpenFileName As System.Windows.Forms.Button
    Friend WithEvents btnStreamReaderReadInChars As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.txtFileText = New System.Windows.Forms.TextBox()
        Me.lblFileText = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnStreamWriterCreateFile = New System.Windows.Forms.Button()
        Me.btnStreamWriterAppendToFile = New System.Windows.Forms.Button()
        Me.btnStreamReaderReadFromFile = New System.Windows.Forms.Button()
        Me.btnStringReaderReadFileInLines = New System.Windows.Forms.Button()
        Me.sdlgFile = New System.Windows.Forms.SaveFileDialog()
        Me.btnNewFileName = New System.Windows.Forms.Button()
        Me.btnOpenFileName = New System.Windows.Forms.Button()
        Me.btnStreamReaderReadInChars = New System.Windows.Forms.Button()
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
        'txtFileText
        '
        Me.txtFileText.AccessibleDescription = resources.GetString("txtFileText.AccessibleDescription")
        Me.txtFileText.AccessibleName = resources.GetString("txtFileText.AccessibleName")
        Me.txtFileText.Anchor = CType(resources.GetObject("txtFileText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtFileText.AutoSize = CType(resources.GetObject("txtFileText.AutoSize"), Boolean)
        Me.txtFileText.BackgroundImage = CType(resources.GetObject("txtFileText.BackgroundImage"), System.Drawing.Image)
        Me.txtFileText.Dock = CType(resources.GetObject("txtFileText.Dock"), System.Windows.Forms.DockStyle)
        Me.txtFileText.Enabled = CType(resources.GetObject("txtFileText.Enabled"), Boolean)
        Me.txtFileText.Font = CType(resources.GetObject("txtFileText.Font"), System.Drawing.Font)
        Me.txtFileText.ImeMode = CType(resources.GetObject("txtFileText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtFileText.Location = CType(resources.GetObject("txtFileText.Location"), System.Drawing.Point)
        Me.txtFileText.MaxLength = CType(resources.GetObject("txtFileText.MaxLength"), Integer)
        Me.txtFileText.Multiline = CType(resources.GetObject("txtFileText.Multiline"), Boolean)
        Me.txtFileText.Name = "txtFileText"
        Me.txtFileText.PasswordChar = CType(resources.GetObject("txtFileText.PasswordChar"), Char)
        Me.txtFileText.RightToLeft = CType(resources.GetObject("txtFileText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtFileText.ScrollBars = CType(resources.GetObject("txtFileText.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtFileText.Size = CType(resources.GetObject("txtFileText.Size"), System.Drawing.Size)
        Me.txtFileText.TabIndex = CType(resources.GetObject("txtFileText.TabIndex"), Integer)
        Me.txtFileText.Text = resources.GetString("txtFileText.Text")
        Me.txtFileText.TextAlign = CType(resources.GetObject("txtFileText.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtFileText.Visible = CType(resources.GetObject("txtFileText.Visible"), Boolean)
        Me.txtFileText.WordWrap = CType(resources.GetObject("txtFileText.WordWrap"), Boolean)
        '
        'lblFileText
        '
        Me.lblFileText.AccessibleDescription = resources.GetString("lblFileText.AccessibleDescription")
        Me.lblFileText.AccessibleName = resources.GetString("lblFileText.AccessibleName")
        Me.lblFileText.Anchor = CType(resources.GetObject("lblFileText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblFileText.AutoSize = CType(resources.GetObject("lblFileText.AutoSize"), Boolean)
        Me.lblFileText.Dock = CType(resources.GetObject("lblFileText.Dock"), System.Windows.Forms.DockStyle)
        Me.lblFileText.Enabled = CType(resources.GetObject("lblFileText.Enabled"), Boolean)
        Me.lblFileText.Font = CType(resources.GetObject("lblFileText.Font"), System.Drawing.Font)
        Me.lblFileText.Image = CType(resources.GetObject("lblFileText.Image"), System.Drawing.Image)
        Me.lblFileText.ImageAlign = CType(resources.GetObject("lblFileText.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblFileText.ImageIndex = CType(resources.GetObject("lblFileText.ImageIndex"), Integer)
        Me.lblFileText.ImeMode = CType(resources.GetObject("lblFileText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblFileText.Location = CType(resources.GetObject("lblFileText.Location"), System.Drawing.Point)
        Me.lblFileText.Name = "lblFileText"
        Me.lblFileText.RightToLeft = CType(resources.GetObject("lblFileText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblFileText.Size = CType(resources.GetObject("lblFileText.Size"), System.Drawing.Size)
        Me.lblFileText.TabIndex = CType(resources.GetObject("lblFileText.TabIndex"), Integer)
        Me.lblFileText.Text = resources.GetString("lblFileText.Text")
        Me.lblFileText.TextAlign = CType(resources.GetObject("lblFileText.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblFileText.Visible = CType(resources.GetObject("lblFileText.Visible"), Boolean)
        '
        'lblFileName
        '
        Me.lblFileName.AccessibleDescription = resources.GetString("lblFileName.AccessibleDescription")
        Me.lblFileName.AccessibleName = resources.GetString("lblFileName.AccessibleName")
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
        Me.txtFileName.AccessibleDescription = resources.GetString("txtFileName.AccessibleDescription")
        Me.txtFileName.AccessibleName = resources.GetString("txtFileName.AccessibleName")
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
        'btnStreamWriterCreateFile
        '
        Me.btnStreamWriterCreateFile.AccessibleDescription = resources.GetString("btnStreamWriterCreateFile.AccessibleDescription")
        Me.btnStreamWriterCreateFile.AccessibleName = resources.GetString("btnStreamWriterCreateFile.AccessibleName")
        Me.btnStreamWriterCreateFile.Anchor = CType(resources.GetObject("btnStreamWriterCreateFile.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStreamWriterCreateFile.BackgroundImage = CType(resources.GetObject("btnStreamWriterCreateFile.BackgroundImage"), System.Drawing.Image)
        Me.btnStreamWriterCreateFile.Dock = CType(resources.GetObject("btnStreamWriterCreateFile.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStreamWriterCreateFile.Enabled = CType(resources.GetObject("btnStreamWriterCreateFile.Enabled"), Boolean)
        Me.btnStreamWriterCreateFile.FlatStyle = CType(resources.GetObject("btnStreamWriterCreateFile.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStreamWriterCreateFile.Font = CType(resources.GetObject("btnStreamWriterCreateFile.Font"), System.Drawing.Font)
        Me.btnStreamWriterCreateFile.Image = CType(resources.GetObject("btnStreamWriterCreateFile.Image"), System.Drawing.Image)
        Me.btnStreamWriterCreateFile.ImageAlign = CType(resources.GetObject("btnStreamWriterCreateFile.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStreamWriterCreateFile.ImageIndex = CType(resources.GetObject("btnStreamWriterCreateFile.ImageIndex"), Integer)
        Me.btnStreamWriterCreateFile.ImeMode = CType(resources.GetObject("btnStreamWriterCreateFile.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStreamWriterCreateFile.Location = CType(resources.GetObject("btnStreamWriterCreateFile.Location"), System.Drawing.Point)
        Me.btnStreamWriterCreateFile.Name = "btnStreamWriterCreateFile"
        Me.btnStreamWriterCreateFile.RightToLeft = CType(resources.GetObject("btnStreamWriterCreateFile.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStreamWriterCreateFile.Size = CType(resources.GetObject("btnStreamWriterCreateFile.Size"), System.Drawing.Size)
        Me.btnStreamWriterCreateFile.TabIndex = CType(resources.GetObject("btnStreamWriterCreateFile.TabIndex"), Integer)
        Me.btnStreamWriterCreateFile.Text = resources.GetString("btnStreamWriterCreateFile.Text")
        Me.btnStreamWriterCreateFile.TextAlign = CType(resources.GetObject("btnStreamWriterCreateFile.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStreamWriterCreateFile.Visible = CType(resources.GetObject("btnStreamWriterCreateFile.Visible"), Boolean)
        '
        'btnStreamWriterAppendToFile
        '
        Me.btnStreamWriterAppendToFile.AccessibleDescription = resources.GetString("btnStreamWriterAppendToFile.AccessibleDescription")
        Me.btnStreamWriterAppendToFile.AccessibleName = resources.GetString("btnStreamWriterAppendToFile.AccessibleName")
        Me.btnStreamWriterAppendToFile.Anchor = CType(resources.GetObject("btnStreamWriterAppendToFile.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStreamWriterAppendToFile.BackgroundImage = CType(resources.GetObject("btnStreamWriterAppendToFile.BackgroundImage"), System.Drawing.Image)
        Me.btnStreamWriterAppendToFile.Dock = CType(resources.GetObject("btnStreamWriterAppendToFile.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStreamWriterAppendToFile.Enabled = CType(resources.GetObject("btnStreamWriterAppendToFile.Enabled"), Boolean)
        Me.btnStreamWriterAppendToFile.FlatStyle = CType(resources.GetObject("btnStreamWriterAppendToFile.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStreamWriterAppendToFile.Font = CType(resources.GetObject("btnStreamWriterAppendToFile.Font"), System.Drawing.Font)
        Me.btnStreamWriterAppendToFile.Image = CType(resources.GetObject("btnStreamWriterAppendToFile.Image"), System.Drawing.Image)
        Me.btnStreamWriterAppendToFile.ImageAlign = CType(resources.GetObject("btnStreamWriterAppendToFile.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStreamWriterAppendToFile.ImageIndex = CType(resources.GetObject("btnStreamWriterAppendToFile.ImageIndex"), Integer)
        Me.btnStreamWriterAppendToFile.ImeMode = CType(resources.GetObject("btnStreamWriterAppendToFile.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStreamWriterAppendToFile.Location = CType(resources.GetObject("btnStreamWriterAppendToFile.Location"), System.Drawing.Point)
        Me.btnStreamWriterAppendToFile.Name = "btnStreamWriterAppendToFile"
        Me.btnStreamWriterAppendToFile.RightToLeft = CType(resources.GetObject("btnStreamWriterAppendToFile.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStreamWriterAppendToFile.Size = CType(resources.GetObject("btnStreamWriterAppendToFile.Size"), System.Drawing.Size)
        Me.btnStreamWriterAppendToFile.TabIndex = CType(resources.GetObject("btnStreamWriterAppendToFile.TabIndex"), Integer)
        Me.btnStreamWriterAppendToFile.Text = resources.GetString("btnStreamWriterAppendToFile.Text")
        Me.btnStreamWriterAppendToFile.TextAlign = CType(resources.GetObject("btnStreamWriterAppendToFile.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStreamWriterAppendToFile.Visible = CType(resources.GetObject("btnStreamWriterAppendToFile.Visible"), Boolean)
        '
        'btnStreamReaderReadFromFile
        '
        Me.btnStreamReaderReadFromFile.AccessibleDescription = resources.GetString("btnStreamReaderReadFromFile.AccessibleDescription")
        Me.btnStreamReaderReadFromFile.AccessibleName = resources.GetString("btnStreamReaderReadFromFile.AccessibleName")
        Me.btnStreamReaderReadFromFile.Anchor = CType(resources.GetObject("btnStreamReaderReadFromFile.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStreamReaderReadFromFile.BackgroundImage = CType(resources.GetObject("btnStreamReaderReadFromFile.BackgroundImage"), System.Drawing.Image)
        Me.btnStreamReaderReadFromFile.Dock = CType(resources.GetObject("btnStreamReaderReadFromFile.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStreamReaderReadFromFile.Enabled = CType(resources.GetObject("btnStreamReaderReadFromFile.Enabled"), Boolean)
        Me.btnStreamReaderReadFromFile.FlatStyle = CType(resources.GetObject("btnStreamReaderReadFromFile.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStreamReaderReadFromFile.Font = CType(resources.GetObject("btnStreamReaderReadFromFile.Font"), System.Drawing.Font)
        Me.btnStreamReaderReadFromFile.Image = CType(resources.GetObject("btnStreamReaderReadFromFile.Image"), System.Drawing.Image)
        Me.btnStreamReaderReadFromFile.ImageAlign = CType(resources.GetObject("btnStreamReaderReadFromFile.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStreamReaderReadFromFile.ImageIndex = CType(resources.GetObject("btnStreamReaderReadFromFile.ImageIndex"), Integer)
        Me.btnStreamReaderReadFromFile.ImeMode = CType(resources.GetObject("btnStreamReaderReadFromFile.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStreamReaderReadFromFile.Location = CType(resources.GetObject("btnStreamReaderReadFromFile.Location"), System.Drawing.Point)
        Me.btnStreamReaderReadFromFile.Name = "btnStreamReaderReadFromFile"
        Me.btnStreamReaderReadFromFile.RightToLeft = CType(resources.GetObject("btnStreamReaderReadFromFile.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStreamReaderReadFromFile.Size = CType(resources.GetObject("btnStreamReaderReadFromFile.Size"), System.Drawing.Size)
        Me.btnStreamReaderReadFromFile.TabIndex = CType(resources.GetObject("btnStreamReaderReadFromFile.TabIndex"), Integer)
        Me.btnStreamReaderReadFromFile.Text = resources.GetString("btnStreamReaderReadFromFile.Text")
        Me.btnStreamReaderReadFromFile.TextAlign = CType(resources.GetObject("btnStreamReaderReadFromFile.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStreamReaderReadFromFile.Visible = CType(resources.GetObject("btnStreamReaderReadFromFile.Visible"), Boolean)
        '
        'btnStringReaderReadFileInLines
        '
        Me.btnStringReaderReadFileInLines.AccessibleDescription = resources.GetString("btnStringReaderReadFileInLines.AccessibleDescription")
        Me.btnStringReaderReadFileInLines.AccessibleName = resources.GetString("btnStringReaderReadFileInLines.AccessibleName")
        Me.btnStringReaderReadFileInLines.Anchor = CType(resources.GetObject("btnStringReaderReadFileInLines.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStringReaderReadFileInLines.BackgroundImage = CType(resources.GetObject("btnStringReaderReadFileInLines.BackgroundImage"), System.Drawing.Image)
        Me.btnStringReaderReadFileInLines.Dock = CType(resources.GetObject("btnStringReaderReadFileInLines.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStringReaderReadFileInLines.Enabled = CType(resources.GetObject("btnStringReaderReadFileInLines.Enabled"), Boolean)
        Me.btnStringReaderReadFileInLines.FlatStyle = CType(resources.GetObject("btnStringReaderReadFileInLines.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStringReaderReadFileInLines.Font = CType(resources.GetObject("btnStringReaderReadFileInLines.Font"), System.Drawing.Font)
        Me.btnStringReaderReadFileInLines.Image = CType(resources.GetObject("btnStringReaderReadFileInLines.Image"), System.Drawing.Image)
        Me.btnStringReaderReadFileInLines.ImageAlign = CType(resources.GetObject("btnStringReaderReadFileInLines.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStringReaderReadFileInLines.ImageIndex = CType(resources.GetObject("btnStringReaderReadFileInLines.ImageIndex"), Integer)
        Me.btnStringReaderReadFileInLines.ImeMode = CType(resources.GetObject("btnStringReaderReadFileInLines.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStringReaderReadFileInLines.Location = CType(resources.GetObject("btnStringReaderReadFileInLines.Location"), System.Drawing.Point)
        Me.btnStringReaderReadFileInLines.Name = "btnStringReaderReadFileInLines"
        Me.btnStringReaderReadFileInLines.RightToLeft = CType(resources.GetObject("btnStringReaderReadFileInLines.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStringReaderReadFileInLines.Size = CType(resources.GetObject("btnStringReaderReadFileInLines.Size"), System.Drawing.Size)
        Me.btnStringReaderReadFileInLines.TabIndex = CType(resources.GetObject("btnStringReaderReadFileInLines.TabIndex"), Integer)
        Me.btnStringReaderReadFileInLines.Text = resources.GetString("btnStringReaderReadFileInLines.Text")
        Me.btnStringReaderReadFileInLines.TextAlign = CType(resources.GetObject("btnStringReaderReadFileInLines.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStringReaderReadFileInLines.Visible = CType(resources.GetObject("btnStringReaderReadFileInLines.Visible"), Boolean)
        '
        'sdlgFile
        '
        Me.sdlgFile.Filter = resources.GetString("sdlgFile.Filter")
        Me.sdlgFile.InitialDirectory = "c:\"
        Me.sdlgFile.Title = resources.GetString("sdlgFile.Title")
        '
        'btnNewFileName
        '
        Me.btnNewFileName.AccessibleDescription = resources.GetString("btnNewFileName.AccessibleDescription")
        Me.btnNewFileName.AccessibleName = resources.GetString("btnNewFileName.AccessibleName")
        Me.btnNewFileName.Anchor = CType(resources.GetObject("btnNewFileName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnNewFileName.BackgroundImage = CType(resources.GetObject("btnNewFileName.BackgroundImage"), System.Drawing.Image)
        Me.btnNewFileName.Dock = CType(resources.GetObject("btnNewFileName.Dock"), System.Windows.Forms.DockStyle)
        Me.btnNewFileName.Enabled = CType(resources.GetObject("btnNewFileName.Enabled"), Boolean)
        Me.btnNewFileName.FlatStyle = CType(resources.GetObject("btnNewFileName.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnNewFileName.Font = CType(resources.GetObject("btnNewFileName.Font"), System.Drawing.Font)
        Me.btnNewFileName.Image = CType(resources.GetObject("btnNewFileName.Image"), System.Drawing.Image)
        Me.btnNewFileName.ImageAlign = CType(resources.GetObject("btnNewFileName.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnNewFileName.ImageIndex = CType(resources.GetObject("btnNewFileName.ImageIndex"), Integer)
        Me.btnNewFileName.ImeMode = CType(resources.GetObject("btnNewFileName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnNewFileName.Location = CType(resources.GetObject("btnNewFileName.Location"), System.Drawing.Point)
        Me.btnNewFileName.Name = "btnNewFileName"
        Me.btnNewFileName.RightToLeft = CType(resources.GetObject("btnNewFileName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnNewFileName.Size = CType(resources.GetObject("btnNewFileName.Size"), System.Drawing.Size)
        Me.btnNewFileName.TabIndex = CType(resources.GetObject("btnNewFileName.TabIndex"), Integer)
        Me.btnNewFileName.Text = resources.GetString("btnNewFileName.Text")
        Me.btnNewFileName.TextAlign = CType(resources.GetObject("btnNewFileName.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnNewFileName.Visible = CType(resources.GetObject("btnNewFileName.Visible"), Boolean)
        '
        'btnOpenFileName
        '
        Me.btnOpenFileName.AccessibleDescription = resources.GetString("btnOpenFileName.AccessibleDescription")
        Me.btnOpenFileName.AccessibleName = resources.GetString("btnOpenFileName.AccessibleName")
        Me.btnOpenFileName.Anchor = CType(resources.GetObject("btnOpenFileName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnOpenFileName.BackgroundImage = CType(resources.GetObject("btnOpenFileName.BackgroundImage"), System.Drawing.Image)
        Me.btnOpenFileName.Dock = CType(resources.GetObject("btnOpenFileName.Dock"), System.Windows.Forms.DockStyle)
        Me.btnOpenFileName.Enabled = CType(resources.GetObject("btnOpenFileName.Enabled"), Boolean)
        Me.btnOpenFileName.FlatStyle = CType(resources.GetObject("btnOpenFileName.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnOpenFileName.Font = CType(resources.GetObject("btnOpenFileName.Font"), System.Drawing.Font)
        Me.btnOpenFileName.Image = CType(resources.GetObject("btnOpenFileName.Image"), System.Drawing.Image)
        Me.btnOpenFileName.ImageAlign = CType(resources.GetObject("btnOpenFileName.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnOpenFileName.ImageIndex = CType(resources.GetObject("btnOpenFileName.ImageIndex"), Integer)
        Me.btnOpenFileName.ImeMode = CType(resources.GetObject("btnOpenFileName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnOpenFileName.Location = CType(resources.GetObject("btnOpenFileName.Location"), System.Drawing.Point)
        Me.btnOpenFileName.Name = "btnOpenFileName"
        Me.btnOpenFileName.RightToLeft = CType(resources.GetObject("btnOpenFileName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnOpenFileName.Size = CType(resources.GetObject("btnOpenFileName.Size"), System.Drawing.Size)
        Me.btnOpenFileName.TabIndex = CType(resources.GetObject("btnOpenFileName.TabIndex"), Integer)
        Me.btnOpenFileName.Text = resources.GetString("btnOpenFileName.Text")
        Me.btnOpenFileName.TextAlign = CType(resources.GetObject("btnOpenFileName.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnOpenFileName.Visible = CType(resources.GetObject("btnOpenFileName.Visible"), Boolean)
        '
        'btnStreamReaderReadInChars
        '
        Me.btnStreamReaderReadInChars.AccessibleDescription = resources.GetString("btnStreamReaderReadInChars.AccessibleDescription")
        Me.btnStreamReaderReadInChars.AccessibleName = resources.GetString("btnStreamReaderReadInChars.AccessibleName")
        Me.btnStreamReaderReadInChars.Anchor = CType(resources.GetObject("btnStreamReaderReadInChars.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStreamReaderReadInChars.BackgroundImage = CType(resources.GetObject("btnStreamReaderReadInChars.BackgroundImage"), System.Drawing.Image)
        Me.btnStreamReaderReadInChars.Dock = CType(resources.GetObject("btnStreamReaderReadInChars.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStreamReaderReadInChars.Enabled = CType(resources.GetObject("btnStreamReaderReadInChars.Enabled"), Boolean)
        Me.btnStreamReaderReadInChars.FlatStyle = CType(resources.GetObject("btnStreamReaderReadInChars.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStreamReaderReadInChars.Font = CType(resources.GetObject("btnStreamReaderReadInChars.Font"), System.Drawing.Font)
        Me.btnStreamReaderReadInChars.Image = CType(resources.GetObject("btnStreamReaderReadInChars.Image"), System.Drawing.Image)
        Me.btnStreamReaderReadInChars.ImageAlign = CType(resources.GetObject("btnStreamReaderReadInChars.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStreamReaderReadInChars.ImageIndex = CType(resources.GetObject("btnStreamReaderReadInChars.ImageIndex"), Integer)
        Me.btnStreamReaderReadInChars.ImeMode = CType(resources.GetObject("btnStreamReaderReadInChars.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStreamReaderReadInChars.Location = CType(resources.GetObject("btnStreamReaderReadInChars.Location"), System.Drawing.Point)
        Me.btnStreamReaderReadInChars.Name = "btnStreamReaderReadInChars"
        Me.btnStreamReaderReadInChars.RightToLeft = CType(resources.GetObject("btnStreamReaderReadInChars.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStreamReaderReadInChars.Size = CType(resources.GetObject("btnStreamReaderReadInChars.Size"), System.Drawing.Size)
        Me.btnStreamReaderReadInChars.TabIndex = CType(resources.GetObject("btnStreamReaderReadInChars.TabIndex"), Integer)
        Me.btnStreamReaderReadInChars.Text = resources.GetString("btnStreamReaderReadInChars.Text")
        Me.btnStreamReaderReadInChars.TextAlign = CType(resources.GetObject("btnStreamReaderReadInChars.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStreamReaderReadInChars.Visible = CType(resources.GetObject("btnStreamReaderReadInChars.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnStreamReaderReadInChars, Me.btnOpenFileName, Me.btnNewFileName, Me.btnStringReaderReadFileInLines, Me.btnStreamReaderReadFromFile, Me.btnStreamWriterAppendToFile, Me.btnStreamWriterCreateFile, Me.txtFileName, Me.lblFileName, Me.lblFileText, Me.txtFileText})
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

    ' This subroutine allows the user to specify a new file and directory
    '   using a SaveFileDialog object. To demonstrate the use drag-and-drop
    '   programming, this subroutine uses a SaveFileDialog created in the 
    '   visual designer.
    Private Sub btnNewFileName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFileName.Click
        ' Use the SaveFileDialog and put the path and name of the
        '   desired file in the txtFileName text box.
        If Me.sdlgFile.ShowDialog = DialogResult.OK Then
            Me.txtFileName.Text = sdlgFile.FileName
        End If
    End Sub

    ' This subroutine allows the user to specify a file and directory of an existing
    '   file using an OpenFileDialog object. To demonstrate the programmatic 
    '   creation of the OpenFileDialog object, this subroutine defines and creates
    '   a new OpenFileDialog object in code.
    Private Sub btnOpenFileName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFileName.Click
        ' Create the OpenFileDialog object
        Dim myOpenFileDialog As New OpenFileDialog()

        ' Set properties as appropriate.
        myOpenFileDialog.CheckFileExists = True
        myOpenFileDialog.DefaultExt = "txt"
        myOpenFileDialog.InitialDirectory = "C:\"
        myOpenFileDialog.Multiselect = False

        ' Use the OpenFileDialog and put the path and name of the
        '   selected file in the txtFileName text box.
        If myOpenFileDialog.ShowDialog = DialogResult.OK Then
            Me.txtFileName.Text = myOpenFileDialog.FileName
        End If

    End Sub

    ' This subrouting uses a StreamWriter object to append text to a currently
    '   existing file. If the file doesn't exist, it is created.
    Private Sub btnStreamWriterAppendToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStreamWriterAppendToFile.Click

        ' The StreamWriter must be defined outside of the Try-Catch block
        '   in order to reference it in the Finally block.
        Dim myStreamWriter As StreamWriter

        ' Ensure that the creation of the new StreamWriter is wrapped in a 
        '   Try-Catch block, since an invalid filename could have been used.
        Try
            ' Create a StreamWriter using a Shared (static) File class.
            myStreamWriter = File.AppendText(txtFileName.Text)

            ' Write the entire contents of the txtFileText text box
            '   to the StreamWriter in one shot.
            myStreamWriter.Write(txtFileText.Text)
            ' Flush the stream to ensure everything is flushed
            myStreamWriter.Flush()
        Catch exc As Exception
            MsgBox("File could not be opened or written to." + vbCrLf + _
                "Please verify that the filename is correct, " + _
                "and that you have read permissions for the desired " + _
                "directory." + vbCrLf + vbCrLf + "Exception: " + exc.Message)
        Finally
            ' Close the object if it has been created.
            If Not myStreamWriter Is Nothing Then
                myStreamWriter.Close()
            End If
        End Try
    End Sub

    ' This subrouting uses a StreamWriter object to create a new file
    '   and fill it with the text in txtFileText. It first checks to see
    '   if the file already exists and prompts to overwrite it.
    Private Sub btnStreamWriterCreateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStreamWriterCreateFile.Click

        ' Check to see if the user is writing over an existing file.
        If File.Exists(txtFileName.Text) Then
            If MsgBox("That file exists. Would you like to overwrite it?", _
                MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then

                ' Leave the subroutine
                Return
            End If
        End If

        ' The StreamWriter must be defined outside of the Try-Catch block
        '   in order to reference it in the Finally block.
        Dim myStreamWriter As StreamWriter

        ' Ensure that the creation of the new StreamWriter is wrapped in a 
        '   Try-Catch block, since an invalid filename could have been used.
        Try
            ' Create a StreamWriter using a Shared (static) File class.
            myStreamWriter = File.CreateText(txtFileName.Text)

            ' Write the entire contents of the txtFileText text box
            '   to the StreamWriter in one shot.
            myStreamWriter.Write(txtFileText.Text)
            myStreamWriter.Flush()
        Catch exc As Exception
            ' Show the error to the user.
            MsgBox("File could not be created or written to." + vbCrLf + _
                "Please verify that the filename is correct, " + _
                "and that you have write permissions for the desired " + _
                "directory." + vbCrLf + vbCrLf + "Exception: " + exc.Message)
        Finally
            ' Close the object if it has been created.
            If Not myStreamWriter Is Nothing Then
                myStreamWriter.Close()
            End If
        End Try
    End Sub

    ' This subrouting uses a StreamReader object to open an existing file
    '   and read it line by line. It then outputs each line, with a line
    '   number to the txtFileText textbox.
    Private Sub btnStringReaderReadFileInLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStringReaderReadFileInLines.Click

        ' The StreamReader must be defined outside of the Try-Catch block
        '   in order to reference it in the Finally block.
        Dim myStreamReader As StreamReader
        Dim myInputString As String
        Dim rowCount As Integer = 0

        ' Ensure that the creation of the new StreamReader is wrapped in a 
        '   Try-Catch block, since an invalid filename could have been used.
        Try
            ' Create a StreamReader using a Shared (static) File class.
            myStreamReader = File.OpenText(txtFileName.Text)
            txtFileText.Clear() ' Clear the TextBox

            ' Begin by reading a single line
            myInputString = myStreamReader.ReadLine()
            ' Continue reading while there are still lines to be read
            While Not myInputString Is Nothing
                ' Output the text with a line number
                txtFileText.Text += rowCount.ToString() + ": " + _
                    myInputString + vbCrLf
                rowCount += 1
                ' Read the next line.
                myInputString = myStreamReader.ReadLine()
            End While
        Catch exc As Exception
            ' Show the error to the user.
            MsgBox("File could not be opened or read." + vbCrLf + _
                "Please verify that the filename is correct, " + _
                "and that you have read permissions for the desired " + _
                "directory." + vbCrLf + vbCrLf + "Exception: " + exc.Message)
        Finally
            ' Close the object if it has been created.
            If Not myStreamReader Is Nothing Then
                myStreamReader.Close()
            End If
        End Try
    End Sub

    ' This subrouting uses a StreamReader object to open an existing file
    '   and read it in one pass and place the text in the txtFileText text box.
    Private Sub btnStreamReaderReadFromFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStreamReaderReadFromFile.Click
        ' The StreamReader must be defined outside of the Try-Catch block
        '   in order to reference it in the Finally block.
        Dim myStreamReader As StreamReader

        ' Ensure that the creation of the new StreamReader is wrapped in a 
        '   Try-Catch block, since an invalid filename could have been used.
        Try
            ' Create a StreamReader using a Shared (static) File class.
            myStreamReader = File.OpenText(txtFileName.Text)
            ' Read the entire file in one pass, and add the contents to 
            '   txtFileText text box.
            Me.txtFileText.Text = myStreamReader.ReadToEnd()
        Catch exc As Exception
            ' Show the exception to the user.
            MsgBox("File could not be opened or read." + vbCrLf + _
                "Please verify that the filename is correct, " + _
                "and that you have read permissions for the desired " + _
                "directory." + vbCrLf + vbCrLf + "Exception: " + exc.Message)
        Finally
            ' Close the object if it has been created.
            If Not myStreamReader Is Nothing Then
                myStreamReader.Close()
            End If
        End Try
    End Sub

    ' This subrouting uses a StreamReader object to open an existing file
    '   and read it character by character. It then outputs each character
    '   after a short pause, to show the user that the file is being read
    '   by characters. The output is added to the txtFileText text box.
    Private Sub btnStreamReaderReadInChars_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStreamReaderReadInChars.Click
        ' The StreamReader must be defined outside of the Try-Catch block
        '   in order to reference it in the Finally block.
        Dim myStreamReader As StreamReader
        Dim myNextInt As Integer

        ' Ensure that the creation of the new StreamWriter is wrapped in a 
        '   Try-Catch block, since an invalid filename could have been used.
        Try
            ' Create a StreamReader using a Shared (static) File class.
            myStreamReader = File.OpenText(txtFileName.Text)
            txtFileText.Clear() ' Clear the TextBox

            ' The Read() method returns an integer. 
            myNextInt = myStreamReader.Read()
            ' The Read() method returns '-1' when the end of the
            '   file has been reached
            While myNextInt <> -1
                ' Convert the integer to a unicode Char and add it
                '   to the text box.
                txtFileText.Text += ChrW(myNextInt)
                ' Read the next value from the Stream
                myNextInt = myStreamReader.Read()
                ' Refresh the text box so that the user can see
                '   the characters being added.
                txtFileText.Refresh()
                ' Sleep for 100 milliseconds, so that the user can
                '   see that the characters are being read one at a 
                '   time. Otherwise, they display too quickly.
                System.Threading.Thread.CurrentThread.Sleep(100)
            End While
        Catch exc As Exception
            ' Show the exception to the user.
            MsgBox("File could not be opened or read." + vbCrLf + _
                "Please verify that the filename is correct, " + _
                "and that you have read permissions for the desired " + _
                "directory." + vbCrLf + vbCrLf + "Exception: " + exc.Message)
        Finally
            ' Close the object if it has been created.
            If Not myStreamReader Is Nothing Then
                myStreamReader.Close()
            End If
        End Try

    End Sub


End Class