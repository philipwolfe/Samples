'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

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
    Friend WithEvents txtXML As System.Windows.Forms.TextBox
    Friend WithEvents optSHA1 As System.Windows.Forms.RadioButton
    Friend WithEvents optMD5 As System.Windows.Forms.RadioButton
    Friend WithEvents optSHA384 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblResults As System.Windows.Forms.Label
    Friend WithEvents txtHashForCompare As System.Windows.Forms.TextBox
    Friend WithEvents txtHashOriginal As System.Windows.Forms.TextBox
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.txtXML = New System.Windows.Forms.TextBox()
        Me.optSHA1 = New System.Windows.Forms.RadioButton()
        Me.optMD5 = New System.Windows.Forms.RadioButton()
        Me.optSHA384 = New System.Windows.Forms.RadioButton()
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.txtHashOriginal = New System.Windows.Forms.TextBox()
        Me.txtHashForCompare = New System.Windows.Forms.TextBox()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
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
        'txtXML
        '
        Me.txtXML.AccessibleDescription = resources.GetString("txtXML.AccessibleDescription")
        Me.txtXML.AccessibleName = resources.GetString("txtXML.AccessibleName")
        Me.txtXML.Anchor = CType(resources.GetObject("txtXML.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtXML.AutoSize = CType(resources.GetObject("txtXML.AutoSize"), Boolean)
        Me.txtXML.BackgroundImage = CType(resources.GetObject("txtXML.BackgroundImage"), System.Drawing.Image)
        Me.txtXML.Dock = CType(resources.GetObject("txtXML.Dock"), System.Windows.Forms.DockStyle)
        Me.txtXML.Enabled = CType(resources.GetObject("txtXML.Enabled"), Boolean)
        Me.txtXML.Font = CType(resources.GetObject("txtXML.Font"), System.Drawing.Font)
        Me.txtXML.ImeMode = CType(resources.GetObject("txtXML.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtXML.Location = CType(resources.GetObject("txtXML.Location"), System.Drawing.Point)
        Me.txtXML.MaxLength = CType(resources.GetObject("txtXML.MaxLength"), Integer)
        Me.txtXML.Multiline = CType(resources.GetObject("txtXML.Multiline"), Boolean)
        Me.txtXML.Name = "txtXML"
        Me.txtXML.PasswordChar = CType(resources.GetObject("txtXML.PasswordChar"), Char)
        Me.txtXML.RightToLeft = CType(resources.GetObject("txtXML.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtXML.ScrollBars = CType(resources.GetObject("txtXML.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtXML.Size = CType(resources.GetObject("txtXML.Size"), System.Drawing.Size)
        Me.txtXML.TabIndex = CType(resources.GetObject("txtXML.TabIndex"), Integer)
        Me.txtXML.Text = resources.GetString("txtXML.Text")
        Me.txtXML.TextAlign = CType(resources.GetObject("txtXML.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtXML.Visible = CType(resources.GetObject("txtXML.Visible"), Boolean)
        Me.txtXML.WordWrap = CType(resources.GetObject("txtXML.WordWrap"), Boolean)
        '
        'optSHA1
        '
        Me.optSHA1.AccessibleDescription = resources.GetString("optSHA1.AccessibleDescription")
        Me.optSHA1.AccessibleName = resources.GetString("optSHA1.AccessibleName")
        Me.optSHA1.Anchor = CType(resources.GetObject("optSHA1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optSHA1.Appearance = CType(resources.GetObject("optSHA1.Appearance"), System.Windows.Forms.Appearance)
        Me.optSHA1.BackgroundImage = CType(resources.GetObject("optSHA1.BackgroundImage"), System.Drawing.Image)
        Me.optSHA1.CheckAlign = CType(resources.GetObject("optSHA1.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optSHA1.Dock = CType(resources.GetObject("optSHA1.Dock"), System.Windows.Forms.DockStyle)
        Me.optSHA1.Enabled = CType(resources.GetObject("optSHA1.Enabled"), Boolean)
        Me.optSHA1.FlatStyle = CType(resources.GetObject("optSHA1.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optSHA1.Font = CType(resources.GetObject("optSHA1.Font"), System.Drawing.Font)
        Me.optSHA1.Image = CType(resources.GetObject("optSHA1.Image"), System.Drawing.Image)
        Me.optSHA1.ImageAlign = CType(resources.GetObject("optSHA1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optSHA1.ImageIndex = CType(resources.GetObject("optSHA1.ImageIndex"), Integer)
        Me.optSHA1.ImeMode = CType(resources.GetObject("optSHA1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optSHA1.Location = CType(resources.GetObject("optSHA1.Location"), System.Drawing.Point)
        Me.optSHA1.Name = "optSHA1"
        Me.optSHA1.RightToLeft = CType(resources.GetObject("optSHA1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optSHA1.Size = CType(resources.GetObject("optSHA1.Size"), System.Drawing.Size)
        Me.optSHA1.TabIndex = CType(resources.GetObject("optSHA1.TabIndex"), Integer)
        Me.optSHA1.Text = resources.GetString("optSHA1.Text")
        Me.optSHA1.TextAlign = CType(resources.GetObject("optSHA1.TextAlign"), System.Drawing.ContentAlignment)
        Me.optSHA1.Visible = CType(resources.GetObject("optSHA1.Visible"), Boolean)
        '
        'optMD5
        '
        Me.optMD5.AccessibleDescription = resources.GetString("optMD5.AccessibleDescription")
        Me.optMD5.AccessibleName = resources.GetString("optMD5.AccessibleName")
        Me.optMD5.Anchor = CType(resources.GetObject("optMD5.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optMD5.Appearance = CType(resources.GetObject("optMD5.Appearance"), System.Windows.Forms.Appearance)
        Me.optMD5.BackgroundImage = CType(resources.GetObject("optMD5.BackgroundImage"), System.Drawing.Image)
        Me.optMD5.CheckAlign = CType(resources.GetObject("optMD5.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optMD5.Checked = True
        Me.optMD5.Dock = CType(resources.GetObject("optMD5.Dock"), System.Windows.Forms.DockStyle)
        Me.optMD5.Enabled = CType(resources.GetObject("optMD5.Enabled"), Boolean)
        Me.optMD5.FlatStyle = CType(resources.GetObject("optMD5.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optMD5.Font = CType(resources.GetObject("optMD5.Font"), System.Drawing.Font)
        Me.optMD5.Image = CType(resources.GetObject("optMD5.Image"), System.Drawing.Image)
        Me.optMD5.ImageAlign = CType(resources.GetObject("optMD5.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optMD5.ImageIndex = CType(resources.GetObject("optMD5.ImageIndex"), Integer)
        Me.optMD5.ImeMode = CType(resources.GetObject("optMD5.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optMD5.Location = CType(resources.GetObject("optMD5.Location"), System.Drawing.Point)
        Me.optMD5.Name = "optMD5"
        Me.optMD5.RightToLeft = CType(resources.GetObject("optMD5.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optMD5.Size = CType(resources.GetObject("optMD5.Size"), System.Drawing.Size)
        Me.optMD5.TabIndex = CType(resources.GetObject("optMD5.TabIndex"), Integer)
        Me.optMD5.TabStop = True
        Me.optMD5.Text = resources.GetString("optMD5.Text")
        Me.optMD5.TextAlign = CType(resources.GetObject("optMD5.TextAlign"), System.Drawing.ContentAlignment)
        Me.optMD5.Visible = CType(resources.GetObject("optMD5.Visible"), Boolean)
        '
        'optSHA384
        '
        Me.optSHA384.AccessibleDescription = resources.GetString("optSHA384.AccessibleDescription")
        Me.optSHA384.AccessibleName = resources.GetString("optSHA384.AccessibleName")
        Me.optSHA384.Anchor = CType(resources.GetObject("optSHA384.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optSHA384.Appearance = CType(resources.GetObject("optSHA384.Appearance"), System.Windows.Forms.Appearance)
        Me.optSHA384.BackgroundImage = CType(resources.GetObject("optSHA384.BackgroundImage"), System.Drawing.Image)
        Me.optSHA384.CheckAlign = CType(resources.GetObject("optSHA384.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optSHA384.Dock = CType(resources.GetObject("optSHA384.Dock"), System.Windows.Forms.DockStyle)
        Me.optSHA384.Enabled = CType(resources.GetObject("optSHA384.Enabled"), Boolean)
        Me.optSHA384.FlatStyle = CType(resources.GetObject("optSHA384.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optSHA384.Font = CType(resources.GetObject("optSHA384.Font"), System.Drawing.Font)
        Me.optSHA384.Image = CType(resources.GetObject("optSHA384.Image"), System.Drawing.Image)
        Me.optSHA384.ImageAlign = CType(resources.GetObject("optSHA384.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optSHA384.ImageIndex = CType(resources.GetObject("optSHA384.ImageIndex"), Integer)
        Me.optSHA384.ImeMode = CType(resources.GetObject("optSHA384.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optSHA384.Location = CType(resources.GetObject("optSHA384.Location"), System.Drawing.Point)
        Me.optSHA384.Name = "optSHA384"
        Me.optSHA384.RightToLeft = CType(resources.GetObject("optSHA384.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optSHA384.Size = CType(resources.GetObject("optSHA384.Size"), System.Drawing.Size)
        Me.optSHA384.TabIndex = CType(resources.GetObject("optSHA384.TabIndex"), Integer)
        Me.optSHA384.Text = resources.GetString("optSHA384.Text")
        Me.optSHA384.TextAlign = CType(resources.GetObject("optSHA384.TextAlign"), System.Drawing.ContentAlignment)
        Me.optSHA384.Visible = CType(resources.GetObject("optSHA384.Visible"), Boolean)
        '
        'btnCompare
        '
        Me.btnCompare.AccessibleDescription = resources.GetString("btnCompare.AccessibleDescription")
        Me.btnCompare.AccessibleName = resources.GetString("btnCompare.AccessibleName")
        Me.btnCompare.Anchor = CType(resources.GetObject("btnCompare.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCompare.BackgroundImage = CType(resources.GetObject("btnCompare.BackgroundImage"), System.Drawing.Image)
        Me.btnCompare.Dock = CType(resources.GetObject("btnCompare.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCompare.Enabled = CType(resources.GetObject("btnCompare.Enabled"), Boolean)
        Me.btnCompare.FlatStyle = CType(resources.GetObject("btnCompare.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCompare.Font = CType(resources.GetObject("btnCompare.Font"), System.Drawing.Font)
        Me.btnCompare.Image = CType(resources.GetObject("btnCompare.Image"), System.Drawing.Image)
        Me.btnCompare.ImageAlign = CType(resources.GetObject("btnCompare.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCompare.ImageIndex = CType(resources.GetObject("btnCompare.ImageIndex"), Integer)
        Me.btnCompare.ImeMode = CType(resources.GetObject("btnCompare.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCompare.Location = CType(resources.GetObject("btnCompare.Location"), System.Drawing.Point)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.RightToLeft = CType(resources.GetObject("btnCompare.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCompare.Size = CType(resources.GetObject("btnCompare.Size"), System.Drawing.Size)
        Me.btnCompare.TabIndex = CType(resources.GetObject("btnCompare.TabIndex"), Integer)
        Me.btnCompare.Text = resources.GetString("btnCompare.Text")
        Me.btnCompare.TextAlign = CType(resources.GetObject("btnCompare.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCompare.Visible = CType(resources.GetObject("btnCompare.Visible"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription")
        Me.Label1.AccessibleName = resources.GetString("Label1.AccessibleName")
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
        Me.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription")
        Me.Label2.AccessibleName = resources.GetString("Label2.AccessibleName")
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
        'lblResults
        '
        Me.lblResults.AccessibleDescription = resources.GetString("lblResults.AccessibleDescription")
        Me.lblResults.AccessibleName = resources.GetString("lblResults.AccessibleName")
        Me.lblResults.Anchor = CType(resources.GetObject("lblResults.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblResults.AutoSize = CType(resources.GetObject("lblResults.AutoSize"), Boolean)
        Me.lblResults.Dock = CType(resources.GetObject("lblResults.Dock"), System.Windows.Forms.DockStyle)
        Me.lblResults.Enabled = CType(resources.GetObject("lblResults.Enabled"), Boolean)
        Me.lblResults.Font = CType(resources.GetObject("lblResults.Font"), System.Drawing.Font)
        Me.lblResults.Image = CType(resources.GetObject("lblResults.Image"), System.Drawing.Image)
        Me.lblResults.ImageAlign = CType(resources.GetObject("lblResults.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblResults.ImageIndex = CType(resources.GetObject("lblResults.ImageIndex"), Integer)
        Me.lblResults.ImeMode = CType(resources.GetObject("lblResults.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblResults.Location = CType(resources.GetObject("lblResults.Location"), System.Drawing.Point)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.RightToLeft = CType(resources.GetObject("lblResults.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblResults.Size = CType(resources.GetObject("lblResults.Size"), System.Drawing.Size)
        Me.lblResults.TabIndex = CType(resources.GetObject("lblResults.TabIndex"), Integer)
        Me.lblResults.Text = resources.GetString("lblResults.Text")
        Me.lblResults.TextAlign = CType(resources.GetObject("lblResults.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblResults.Visible = CType(resources.GetObject("lblResults.Visible"), Boolean)
        '
        'txtHashOriginal
        '
        Me.txtHashOriginal.AccessibleDescription = resources.GetString("txtHashOriginal.AccessibleDescription")
        Me.txtHashOriginal.AccessibleName = resources.GetString("txtHashOriginal.AccessibleName")
        Me.txtHashOriginal.Anchor = CType(resources.GetObject("txtHashOriginal.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtHashOriginal.AutoSize = CType(resources.GetObject("txtHashOriginal.AutoSize"), Boolean)
        Me.txtHashOriginal.BackgroundImage = CType(resources.GetObject("txtHashOriginal.BackgroundImage"), System.Drawing.Image)
        Me.txtHashOriginal.Dock = CType(resources.GetObject("txtHashOriginal.Dock"), System.Windows.Forms.DockStyle)
        Me.txtHashOriginal.Enabled = CType(resources.GetObject("txtHashOriginal.Enabled"), Boolean)
        Me.txtHashOriginal.Font = CType(resources.GetObject("txtHashOriginal.Font"), System.Drawing.Font)
        Me.txtHashOriginal.ImeMode = CType(resources.GetObject("txtHashOriginal.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtHashOriginal.Location = CType(resources.GetObject("txtHashOriginal.Location"), System.Drawing.Point)
        Me.txtHashOriginal.MaxLength = CType(resources.GetObject("txtHashOriginal.MaxLength"), Integer)
        Me.txtHashOriginal.Multiline = CType(resources.GetObject("txtHashOriginal.Multiline"), Boolean)
        Me.txtHashOriginal.Name = "txtHashOriginal"
        Me.txtHashOriginal.PasswordChar = CType(resources.GetObject("txtHashOriginal.PasswordChar"), Char)
        Me.txtHashOriginal.ReadOnly = True
        Me.txtHashOriginal.RightToLeft = CType(resources.GetObject("txtHashOriginal.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtHashOriginal.ScrollBars = CType(resources.GetObject("txtHashOriginal.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtHashOriginal.Size = CType(resources.GetObject("txtHashOriginal.Size"), System.Drawing.Size)
        Me.txtHashOriginal.TabIndex = CType(resources.GetObject("txtHashOriginal.TabIndex"), Integer)
        Me.txtHashOriginal.Text = resources.GetString("txtHashOriginal.Text")
        Me.txtHashOriginal.TextAlign = CType(resources.GetObject("txtHashOriginal.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtHashOriginal.Visible = CType(resources.GetObject("txtHashOriginal.Visible"), Boolean)
        Me.txtHashOriginal.WordWrap = CType(resources.GetObject("txtHashOriginal.WordWrap"), Boolean)
        '
        'txtHashForCompare
        '
        Me.txtHashForCompare.AccessibleDescription = resources.GetString("txtHashForCompare.AccessibleDescription")
        Me.txtHashForCompare.AccessibleName = resources.GetString("txtHashForCompare.AccessibleName")
        Me.txtHashForCompare.Anchor = CType(resources.GetObject("txtHashForCompare.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtHashForCompare.AutoSize = CType(resources.GetObject("txtHashForCompare.AutoSize"), Boolean)
        Me.txtHashForCompare.BackgroundImage = CType(resources.GetObject("txtHashForCompare.BackgroundImage"), System.Drawing.Image)
        Me.txtHashForCompare.Dock = CType(resources.GetObject("txtHashForCompare.Dock"), System.Windows.Forms.DockStyle)
        Me.txtHashForCompare.Enabled = CType(resources.GetObject("txtHashForCompare.Enabled"), Boolean)
        Me.txtHashForCompare.Font = CType(resources.GetObject("txtHashForCompare.Font"), System.Drawing.Font)
        Me.txtHashForCompare.ImeMode = CType(resources.GetObject("txtHashForCompare.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtHashForCompare.Location = CType(resources.GetObject("txtHashForCompare.Location"), System.Drawing.Point)
        Me.txtHashForCompare.MaxLength = CType(resources.GetObject("txtHashForCompare.MaxLength"), Integer)
        Me.txtHashForCompare.Multiline = CType(resources.GetObject("txtHashForCompare.Multiline"), Boolean)
        Me.txtHashForCompare.Name = "txtHashForCompare"
        Me.txtHashForCompare.PasswordChar = CType(resources.GetObject("txtHashForCompare.PasswordChar"), Char)
        Me.txtHashForCompare.ReadOnly = True
        Me.txtHashForCompare.RightToLeft = CType(resources.GetObject("txtHashForCompare.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtHashForCompare.ScrollBars = CType(resources.GetObject("txtHashForCompare.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtHashForCompare.Size = CType(resources.GetObject("txtHashForCompare.Size"), System.Drawing.Size)
        Me.txtHashForCompare.TabIndex = CType(resources.GetObject("txtHashForCompare.TabIndex"), Integer)
        Me.txtHashForCompare.Text = resources.GetString("txtHashForCompare.Text")
        Me.txtHashForCompare.TextAlign = CType(resources.GetObject("txtHashForCompare.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtHashForCompare.Visible = CType(resources.GetObject("txtHashForCompare.Visible"), Boolean)
        Me.txtHashForCompare.WordWrap = CType(resources.GetObject("txtHashForCompare.WordWrap"), Boolean)
        '
        'btnRestore
        '
        Me.btnRestore.AccessibleDescription = resources.GetString("btnRestore.AccessibleDescription")
        Me.btnRestore.AccessibleName = resources.GetString("btnRestore.AccessibleName")
        Me.btnRestore.Anchor = CType(resources.GetObject("btnRestore.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.BackgroundImage = CType(resources.GetObject("btnRestore.BackgroundImage"), System.Drawing.Image)
        Me.btnRestore.Dock = CType(resources.GetObject("btnRestore.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRestore.Enabled = CType(resources.GetObject("btnRestore.Enabled"), Boolean)
        Me.btnRestore.FlatStyle = CType(resources.GetObject("btnRestore.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRestore.Font = CType(resources.GetObject("btnRestore.Font"), System.Drawing.Font)
        Me.btnRestore.Image = CType(resources.GetObject("btnRestore.Image"), System.Drawing.Image)
        Me.btnRestore.ImageAlign = CType(resources.GetObject("btnRestore.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRestore.ImageIndex = CType(resources.GetObject("btnRestore.ImageIndex"), Integer)
        Me.btnRestore.ImeMode = CType(resources.GetObject("btnRestore.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRestore.Location = CType(resources.GetObject("btnRestore.Location"), System.Drawing.Point)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.RightToLeft = CType(resources.GetObject("btnRestore.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRestore.Size = CType(resources.GetObject("btnRestore.Size"), System.Drawing.Size)
        Me.btnRestore.TabIndex = CType(resources.GetObject("btnRestore.TabIndex"), Integer)
        Me.btnRestore.Text = resources.GetString("btnRestore.Text")
        Me.btnRestore.TextAlign = CType(resources.GetObject("btnRestore.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRestore.Visible = CType(resources.GetObject("btnRestore.Visible"), Boolean)
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription")
        Me.Label3.AccessibleName = resources.GetString("Label3.AccessibleName")
        Me.Label3.Anchor = CType(resources.GetObject("Label3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = CType(resources.GetObject("Label3.AutoSize"), Boolean)
        Me.Label3.Dock = CType(resources.GetObject("Label3.Dock"), System.Windows.Forms.DockStyle)
        Me.Label3.Enabled = CType(resources.GetObject("Label3.Enabled"), Boolean)
        Me.Label3.Font = CType(resources.GetObject("Label3.Font"), System.Drawing.Font)
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = CType(resources.GetObject("Label3.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label3.ImageIndex = CType(resources.GetObject("Label3.ImageIndex"), Integer)
        Me.Label3.ImeMode = CType(resources.GetObject("Label3.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.Point)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = CType(resources.GetObject("Label3.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label3.Size = CType(resources.GetObject("Label3.Size"), System.Drawing.Size)
        Me.Label3.TabIndex = CType(resources.GetObject("Label3.TabIndex"), Integer)
        Me.Label3.Text = resources.GetString("Label3.Text")
        Me.Label3.TextAlign = CType(resources.GetObject("Label3.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label3.Visible = CType(resources.GetObject("Label3.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.btnRestore, Me.txtHashForCompare, Me.txtHashOriginal, Me.lblResults, Me.Label2, Me.Label1, Me.btnCompare, Me.optSHA384, Me.optMD5, Me.optSHA1, Me.txtXML})
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

    Protected Const COMPARE_INSTRUCTIONS As String = _
        "Click Compare! to generate a hash digest based on the product listing " & _
        "to the left. The original and new hash digests will then be compared " & _
        "to authenticate the displayed product listing."

    Protected Const CONNECTION_ERROR_MSG As String = _
        "To run this sample, you must have SQL " & _
        "or MSDE with the Northwind database installed.  For " & _
        "instructions on installing MSDE, view the ReadMe file."

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=northwind;" & _
        "Integrated Security=SSPI"

    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=northwind;" & _
        "Integrated Security=SSPI"

    Private DidPreviouslyConnect As Boolean = False
    Private FormHasLoaded As Boolean = False
    Private hash As Byte()
    Private strConn As String = SQL_CONNECTION_STRING
    Private strOriginalXML As String

    ' This routine handles the "Compare!" button click event. It compares, byte for
    ' byte, the original hash digest with the hash digest generated from the contents
    ' of the TextBox.
    Private Sub btnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click
        ' Create an Encoding object so that you can use the convenient GetBytes 
        ' method to obtain byte arrays.
        Dim uEncode As New UnicodeEncoding()
        ' Create a byte array from the original XML file sent by the Northwind
        ' Corporation.
        Dim bytHashOriginal As Byte() = uEncode.GetBytes(txtHashOriginal.Text)

        ' Generate a hash digest from the contents of the TextBox. The contents 
        ' simulate the XML received from the Northwind Corporation over the wire.
        ' You want to compare the new hash with the original hash to make sure
        ' the XML has not been corrupted in transit.
        Dim strHashForCompare As String = GenerateHashDigest(txtXML.Text)
        ' From the new hash digest create a byte array for comparison with the
        ' original hash digest byte array.
        Dim bytHashForCompare As Byte() = uEncode.GetBytes(strHashForCompare)
        ' Display the new hash digest in a TextBox.
        txtHashForCompare.Text = strHashForCompare

        'Loop through all the bytes in the hashed values.
        Dim i As Integer
        For i = 0 To bytHashOriginal.Length - 1
            ' Compare each byte. If any do not match display an appropriate message
            ' and exit the loop.
            If bytHashOriginal(i) <> bytHashForCompare(i) Then
                lblResults.Text = "Data has been corrupted!"
                Exit For
            Else
                ' Every byte matched so the "transmitted" XML has been authenticated.
                lblResults.Text = "Comparison Successful."
            End If
        Next i
    End Sub

    ' This routine handles the "Restore XML" button click event. This provides the user 
    ' with an easy way to return the XML displayed in the TextBox to its uncorrupted state.
    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        txtXML.Text = strOriginalXML
    End Sub

    ' This routine handles the Form Load event. It calls another routine to create the 
    ' original XML data document, reads in the XML, displays it in the large TextBox,
    ' and then calls a function to generate an MD5 hash digest to display in the upper 
    ' left TextBox.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create the XML data document simulating the original products list
        ' held by the Northwind Company.
        CreateOriginalProductsList()

        ' Open the XML data document and convert to a string. This simulates the
        ' the product listing being transferred over the wire to a client.
        Dim sr As New StreamReader("..\products.xml")
        strOriginalXML = sr.ReadToEnd
        sr.Close()

        ' Display the "transmitted" XML and the hash digest that is used for 
        ' authenticating the transmitted XML. This digest is generated from the
        ' contents of the original document, not the XML as displayed in the 
        ' TextBox.
        txtXML.Text = strOriginalXML
        txtHashOriginal.Text = GenerateHashDigest(strOriginalXML)
        txtHashForCompare.Text = COMPARE_INSTRUCTIONS

        ' Call Select() to put focus on the "Compare!" button and prevent the XML
        ' in the TextBox from being automatically highlighted.
        btnCompare.Select()

        ' This is used to prevent the code in the CheckedChanged event handler from
        ' running prior to the Form being loaded.
        FormHasLoaded = True
    End Sub

    ' This routine handles the CheckedChanged event for all three RadioButton 
    ' controls. This routine generates a new hash digest based on the selected 
    ' type and resets the UI. The code is wrapped in a FormHasLoaded check to ensure 
    ' that it does not run before the Form has fully loaded. 
    Private Sub RadioButtons_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSHA1.CheckedChanged, optMD5.CheckedChanged, optSHA384.CheckedChanged
        If FormHasLoaded Then
            txtHashOriginal.Text = GenerateHashDigest(strOriginalXML)
            txtHashForCompare.Text = COMPARE_INSTRUCTIONS
            lblResults.Text = ""
            btnCompare.Focus()
        End If
    End Sub

    ' This routine creates the XML data document used for the hash comparison.
    Sub CreateOriginalProductsList()
        ' Display a status message saying that the user is attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to SQL Server")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim IsConnecting As Boolean = True
        While IsConnecting
            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim scnnNW As New SqlConnection(strConn)

                Dim strSQL As String = _
                    "SELECT ProductID, ProductName, UnitPrice " & _
                    "FROM Products"

                ' A SqlCommand object is used to execute the SQL commands.
                Dim scmd As New SqlCommand(strSQL, scnnNW)

                ' A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
                Dim sda As New SqlDataAdapter(scmd)

                ' Create a new DataSet and fill its first DataTable.
                Dim dsProducts As New DataSet()
                sda.Fill(dsProducts)

                ' Persist the DataSet to XML.
                Try
                    dsProducts.WriteXml("..\products.xml")
                Catch exp As Exception
                    MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
                End Try

                ' The data has been successfully retrieved, so break out of the loop
                ' and close the status form.
                IsConnecting = False
                DidPreviouslyConnect = True
                frmStatusMessage.Close()

            Catch expSql As SqlException
                MsgBox(expSql.Message, MsgBoxStyle.Critical, Me.Text)
                Exit Sub

            Catch exp As Exception
                If strConn = SQL_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    strConn = MSDE_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to MSDE")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MsgBox(CONNECTION_ERROR_MSG, MsgBoxStyle.Critical, Me.Text)
                    End
                End If
            End Try
        End While
    End Sub

    ' This function performs the encryption work, generating the various
    ' hash digests.
    Function GenerateHashDigest(ByVal strSource As String) As String
        ' Create an Encoding object so that you can use the convenient GetBytes 
        ' method to obtain byte arrays.
        Dim uEncode As New UnicodeEncoding()
        ' Create a byte array from the source text passed as an argument.
        Dim bytProducts() As Byte = uEncode.GetBytes(strSource)

        ' The code is almost identical for all three hash types.
        If optMD5.Checked Then
            Dim md5 As New MD5CryptoServiceProvider()
            hash = md5.ComputeHash(bytProducts)
        ElseIf optSHA1.Checked Then
            Dim sha1 As New SHA1CryptoServiceProvider()
            hash = sha1.ComputeHash(bytProducts)
        Else
            Dim sha384 As New SHA384Managed()
            hash = sha384.ComputeHash(bytProducts)
        End If

        ' Base64 is a method of encoding binary data as ASCII text.
        Return Convert.ToBase64String(hash)
    End Function
End Class