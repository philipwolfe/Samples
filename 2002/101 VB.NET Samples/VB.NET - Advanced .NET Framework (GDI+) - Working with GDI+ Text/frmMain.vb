'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Drawing.Drawing2D

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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents nudShadowDepth As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnShadowText As System.Windows.Forms.Button
    Friend WithEvents btnBrushText As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtShortText As System.Windows.Forms.TextBox
    Friend WithEvents btnSimpleText As System.Windows.Forms.Button
    Friend WithEvents txtLongText As System.Windows.Forms.TextBox
    Friend WithEvents optGradient As System.Windows.Forms.RadioButton
    Friend WithEvents optHatch As System.Windows.Forms.RadioButton
    Friend WithEvents picDemoArea As System.Windows.Forms.PictureBox
    Friend WithEvents nudFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEmboss As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudEmbossDepth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudBlockDepth As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnBlockText As System.Windows.Forms.Button
    Friend WithEvents btnReflectedText As System.Windows.Forms.Button
    Friend WithEvents btnShearText As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudSkew As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.nudShadowDepth = New System.Windows.Forms.NumericUpDown()
        Me.btnShadowText = New System.Windows.Forms.Button()
        Me.btnBrushText = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtShortText = New System.Windows.Forms.TextBox()
        Me.btnSimpleText = New System.Windows.Forms.Button()
        Me.txtLongText = New System.Windows.Forms.TextBox()
        Me.optGradient = New System.Windows.Forms.RadioButton()
        Me.optHatch = New System.Windows.Forms.RadioButton()
        Me.picDemoArea = New System.Windows.Forms.PictureBox()
        Me.nudFontSize = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEmboss = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudEmbossDepth = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudBlockDepth = New System.Windows.Forms.NumericUpDown()
        Me.btnBlockText = New System.Windows.Forms.Button()
        Me.btnReflectedText = New System.Windows.Forms.Button()
        Me.btnShearText = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudSkew = New System.Windows.Forms.NumericUpDown()
        CType(Me.nudShadowDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudEmbossDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBlockDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSkew, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label12
        '
        Me.Label12.AccessibleDescription = resources.GetString("Label12.AccessibleDescription")
        Me.Label12.AccessibleName = resources.GetString("Label12.AccessibleName")
        Me.Label12.Anchor = CType(resources.GetObject("Label12.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = CType(resources.GetObject("Label12.AutoSize"), Boolean)
        Me.Label12.Dock = CType(resources.GetObject("Label12.Dock"), System.Windows.Forms.DockStyle)
        Me.Label12.Enabled = CType(resources.GetObject("Label12.Enabled"), Boolean)
        Me.Label12.Font = CType(resources.GetObject("Label12.Font"), System.Drawing.Font)
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.ImageAlign = CType(resources.GetObject("Label12.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label12.ImageIndex = CType(resources.GetObject("Label12.ImageIndex"), Integer)
        Me.Label12.ImeMode = CType(resources.GetObject("Label12.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label12.Location = CType(resources.GetObject("Label12.Location"), System.Drawing.Point)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = CType(resources.GetObject("Label12.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label12.Size = CType(resources.GetObject("Label12.Size"), System.Drawing.Size)
        Me.Label12.TabIndex = CType(resources.GetObject("Label12.TabIndex"), Integer)
        Me.Label12.Text = resources.GetString("Label12.Text")
        Me.Label12.TextAlign = CType(resources.GetObject("Label12.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label12.Visible = CType(resources.GetObject("Label12.Visible"), Boolean)
        '
        'nudShadowDepth
        '
        Me.nudShadowDepth.AccessibleDescription = resources.GetString("nudShadowDepth.AccessibleDescription")
        Me.nudShadowDepth.AccessibleName = resources.GetString("nudShadowDepth.AccessibleName")
        Me.nudShadowDepth.Anchor = CType(resources.GetObject("nudShadowDepth.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.nudShadowDepth.Dock = CType(resources.GetObject("nudShadowDepth.Dock"), System.Windows.Forms.DockStyle)
        Me.nudShadowDepth.Enabled = CType(resources.GetObject("nudShadowDepth.Enabled"), Boolean)
        Me.nudShadowDepth.Font = CType(resources.GetObject("nudShadowDepth.Font"), System.Drawing.Font)
        Me.nudShadowDepth.ImeMode = CType(resources.GetObject("nudShadowDepth.ImeMode"), System.Windows.Forms.ImeMode)
        Me.nudShadowDepth.Location = CType(resources.GetObject("nudShadowDepth.Location"), System.Drawing.Point)
        Me.nudShadowDepth.Maximum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.nudShadowDepth.Name = "nudShadowDepth"
        Me.nudShadowDepth.RightToLeft = CType(resources.GetObject("nudShadowDepth.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.nudShadowDepth.Size = CType(resources.GetObject("nudShadowDepth.Size"), System.Drawing.Size)
        Me.nudShadowDepth.TabIndex = CType(resources.GetObject("nudShadowDepth.TabIndex"), Integer)
        Me.nudShadowDepth.TextAlign = CType(resources.GetObject("nudShadowDepth.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.nudShadowDepth.ThousandsSeparator = CType(resources.GetObject("nudShadowDepth.ThousandsSeparator"), Boolean)
        Me.nudShadowDepth.UpDownAlign = CType(resources.GetObject("nudShadowDepth.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.nudShadowDepth.Value = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudShadowDepth.Visible = CType(resources.GetObject("nudShadowDepth.Visible"), Boolean)
        '
        'btnShadowText
        '
        Me.btnShadowText.AccessibleDescription = resources.GetString("btnShadowText.AccessibleDescription")
        Me.btnShadowText.AccessibleName = resources.GetString("btnShadowText.AccessibleName")
        Me.btnShadowText.Anchor = CType(resources.GetObject("btnShadowText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnShadowText.BackgroundImage = CType(resources.GetObject("btnShadowText.BackgroundImage"), System.Drawing.Image)
        Me.btnShadowText.Dock = CType(resources.GetObject("btnShadowText.Dock"), System.Windows.Forms.DockStyle)
        Me.btnShadowText.Enabled = CType(resources.GetObject("btnShadowText.Enabled"), Boolean)
        Me.btnShadowText.FlatStyle = CType(resources.GetObject("btnShadowText.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnShadowText.Font = CType(resources.GetObject("btnShadowText.Font"), System.Drawing.Font)
        Me.btnShadowText.Image = CType(resources.GetObject("btnShadowText.Image"), System.Drawing.Image)
        Me.btnShadowText.ImageAlign = CType(resources.GetObject("btnShadowText.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnShadowText.ImageIndex = CType(resources.GetObject("btnShadowText.ImageIndex"), Integer)
        Me.btnShadowText.ImeMode = CType(resources.GetObject("btnShadowText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnShadowText.Location = CType(resources.GetObject("btnShadowText.Location"), System.Drawing.Point)
        Me.btnShadowText.Name = "btnShadowText"
        Me.btnShadowText.RightToLeft = CType(resources.GetObject("btnShadowText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnShadowText.Size = CType(resources.GetObject("btnShadowText.Size"), System.Drawing.Size)
        Me.btnShadowText.TabIndex = CType(resources.GetObject("btnShadowText.TabIndex"), Integer)
        Me.btnShadowText.Text = resources.GetString("btnShadowText.Text")
        Me.btnShadowText.TextAlign = CType(resources.GetObject("btnShadowText.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnShadowText.Visible = CType(resources.GetObject("btnShadowText.Visible"), Boolean)
        '
        'btnBrushText
        '
        Me.btnBrushText.AccessibleDescription = resources.GetString("btnBrushText.AccessibleDescription")
        Me.btnBrushText.AccessibleName = resources.GetString("btnBrushText.AccessibleName")
        Me.btnBrushText.Anchor = CType(resources.GetObject("btnBrushText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBrushText.BackgroundImage = CType(resources.GetObject("btnBrushText.BackgroundImage"), System.Drawing.Image)
        Me.btnBrushText.Dock = CType(resources.GetObject("btnBrushText.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBrushText.Enabled = CType(resources.GetObject("btnBrushText.Enabled"), Boolean)
        Me.btnBrushText.FlatStyle = CType(resources.GetObject("btnBrushText.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBrushText.Font = CType(resources.GetObject("btnBrushText.Font"), System.Drawing.Font)
        Me.btnBrushText.Image = CType(resources.GetObject("btnBrushText.Image"), System.Drawing.Image)
        Me.btnBrushText.ImageAlign = CType(resources.GetObject("btnBrushText.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBrushText.ImageIndex = CType(resources.GetObject("btnBrushText.ImageIndex"), Integer)
        Me.btnBrushText.ImeMode = CType(resources.GetObject("btnBrushText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBrushText.Location = CType(resources.GetObject("btnBrushText.Location"), System.Drawing.Point)
        Me.btnBrushText.Name = "btnBrushText"
        Me.btnBrushText.RightToLeft = CType(resources.GetObject("btnBrushText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBrushText.Size = CType(resources.GetObject("btnBrushText.Size"), System.Drawing.Size)
        Me.btnBrushText.TabIndex = CType(resources.GetObject("btnBrushText.TabIndex"), Integer)
        Me.btnBrushText.Text = resources.GetString("btnBrushText.Text")
        Me.btnBrushText.TextAlign = CType(resources.GetObject("btnBrushText.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBrushText.Visible = CType(resources.GetObject("btnBrushText.Visible"), Boolean)
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = resources.GetString("Label11.AccessibleDescription")
        Me.Label11.AccessibleName = resources.GetString("Label11.AccessibleName")
        Me.Label11.Anchor = CType(resources.GetObject("Label11.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = CType(resources.GetObject("Label11.AutoSize"), Boolean)
        Me.Label11.Dock = CType(resources.GetObject("Label11.Dock"), System.Windows.Forms.DockStyle)
        Me.Label11.Enabled = CType(resources.GetObject("Label11.Enabled"), Boolean)
        Me.Label11.Font = CType(resources.GetObject("Label11.Font"), System.Drawing.Font)
        Me.Label11.Image = CType(resources.GetObject("Label11.Image"), System.Drawing.Image)
        Me.Label11.ImageAlign = CType(resources.GetObject("Label11.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label11.ImageIndex = CType(resources.GetObject("Label11.ImageIndex"), Integer)
        Me.Label11.ImeMode = CType(resources.GetObject("Label11.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label11.Location = CType(resources.GetObject("Label11.Location"), System.Drawing.Point)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = CType(resources.GetObject("Label11.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label11.Size = CType(resources.GetObject("Label11.Size"), System.Drawing.Size)
        Me.Label11.TabIndex = CType(resources.GetObject("Label11.TabIndex"), Integer)
        Me.Label11.Text = resources.GetString("Label11.Text")
        Me.Label11.TextAlign = CType(resources.GetObject("Label11.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label11.Visible = CType(resources.GetObject("Label11.Visible"), Boolean)
        '
        'txtShortText
        '
        Me.txtShortText.AccessibleDescription = resources.GetString("txtShortText.AccessibleDescription")
        Me.txtShortText.AccessibleName = resources.GetString("txtShortText.AccessibleName")
        Me.txtShortText.Anchor = CType(resources.GetObject("txtShortText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtShortText.AutoSize = CType(resources.GetObject("txtShortText.AutoSize"), Boolean)
        Me.txtShortText.BackgroundImage = CType(resources.GetObject("txtShortText.BackgroundImage"), System.Drawing.Image)
        Me.txtShortText.Dock = CType(resources.GetObject("txtShortText.Dock"), System.Windows.Forms.DockStyle)
        Me.txtShortText.Enabled = CType(resources.GetObject("txtShortText.Enabled"), Boolean)
        Me.txtShortText.Font = CType(resources.GetObject("txtShortText.Font"), System.Drawing.Font)
        Me.txtShortText.ImeMode = CType(resources.GetObject("txtShortText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtShortText.Location = CType(resources.GetObject("txtShortText.Location"), System.Drawing.Point)
        Me.txtShortText.MaxLength = CType(resources.GetObject("txtShortText.MaxLength"), Integer)
        Me.txtShortText.Multiline = CType(resources.GetObject("txtShortText.Multiline"), Boolean)
        Me.txtShortText.Name = "txtShortText"
        Me.txtShortText.PasswordChar = CType(resources.GetObject("txtShortText.PasswordChar"), Char)
        Me.txtShortText.RightToLeft = CType(resources.GetObject("txtShortText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtShortText.ScrollBars = CType(resources.GetObject("txtShortText.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtShortText.Size = CType(resources.GetObject("txtShortText.Size"), System.Drawing.Size)
        Me.txtShortText.TabIndex = CType(resources.GetObject("txtShortText.TabIndex"), Integer)
        Me.txtShortText.Text = resources.GetString("txtShortText.Text")
        Me.txtShortText.TextAlign = CType(resources.GetObject("txtShortText.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtShortText.Visible = CType(resources.GetObject("txtShortText.Visible"), Boolean)
        Me.txtShortText.WordWrap = CType(resources.GetObject("txtShortText.WordWrap"), Boolean)
        '
        'btnSimpleText
        '
        Me.btnSimpleText.AccessibleDescription = resources.GetString("btnSimpleText.AccessibleDescription")
        Me.btnSimpleText.AccessibleName = resources.GetString("btnSimpleText.AccessibleName")
        Me.btnSimpleText.Anchor = CType(resources.GetObject("btnSimpleText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSimpleText.BackgroundImage = CType(resources.GetObject("btnSimpleText.BackgroundImage"), System.Drawing.Image)
        Me.btnSimpleText.Dock = CType(resources.GetObject("btnSimpleText.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSimpleText.Enabled = CType(resources.GetObject("btnSimpleText.Enabled"), Boolean)
        Me.btnSimpleText.FlatStyle = CType(resources.GetObject("btnSimpleText.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSimpleText.Font = CType(resources.GetObject("btnSimpleText.Font"), System.Drawing.Font)
        Me.btnSimpleText.Image = CType(resources.GetObject("btnSimpleText.Image"), System.Drawing.Image)
        Me.btnSimpleText.ImageAlign = CType(resources.GetObject("btnSimpleText.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSimpleText.ImageIndex = CType(resources.GetObject("btnSimpleText.ImageIndex"), Integer)
        Me.btnSimpleText.ImeMode = CType(resources.GetObject("btnSimpleText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSimpleText.Location = CType(resources.GetObject("btnSimpleText.Location"), System.Drawing.Point)
        Me.btnSimpleText.Name = "btnSimpleText"
        Me.btnSimpleText.RightToLeft = CType(resources.GetObject("btnSimpleText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSimpleText.Size = CType(resources.GetObject("btnSimpleText.Size"), System.Drawing.Size)
        Me.btnSimpleText.TabIndex = CType(resources.GetObject("btnSimpleText.TabIndex"), Integer)
        Me.btnSimpleText.Text = resources.GetString("btnSimpleText.Text")
        Me.btnSimpleText.TextAlign = CType(resources.GetObject("btnSimpleText.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSimpleText.Visible = CType(resources.GetObject("btnSimpleText.Visible"), Boolean)
        '
        'txtLongText
        '
        Me.txtLongText.AccessibleDescription = resources.GetString("txtLongText.AccessibleDescription")
        Me.txtLongText.AccessibleName = resources.GetString("txtLongText.AccessibleName")
        Me.txtLongText.Anchor = CType(resources.GetObject("txtLongText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtLongText.AutoSize = CType(resources.GetObject("txtLongText.AutoSize"), Boolean)
        Me.txtLongText.BackgroundImage = CType(resources.GetObject("txtLongText.BackgroundImage"), System.Drawing.Image)
        Me.txtLongText.Dock = CType(resources.GetObject("txtLongText.Dock"), System.Windows.Forms.DockStyle)
        Me.txtLongText.Enabled = CType(resources.GetObject("txtLongText.Enabled"), Boolean)
        Me.txtLongText.Font = CType(resources.GetObject("txtLongText.Font"), System.Drawing.Font)
        Me.txtLongText.ImeMode = CType(resources.GetObject("txtLongText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtLongText.Location = CType(resources.GetObject("txtLongText.Location"), System.Drawing.Point)
        Me.txtLongText.MaxLength = CType(resources.GetObject("txtLongText.MaxLength"), Integer)
        Me.txtLongText.Multiline = CType(resources.GetObject("txtLongText.Multiline"), Boolean)
        Me.txtLongText.Name = "txtLongText"
        Me.txtLongText.PasswordChar = CType(resources.GetObject("txtLongText.PasswordChar"), Char)
        Me.txtLongText.RightToLeft = CType(resources.GetObject("txtLongText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtLongText.ScrollBars = CType(resources.GetObject("txtLongText.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtLongText.Size = CType(resources.GetObject("txtLongText.Size"), System.Drawing.Size)
        Me.txtLongText.TabIndex = CType(resources.GetObject("txtLongText.TabIndex"), Integer)
        Me.txtLongText.Text = resources.GetString("txtLongText.Text")
        Me.txtLongText.TextAlign = CType(resources.GetObject("txtLongText.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtLongText.Visible = CType(resources.GetObject("txtLongText.Visible"), Boolean)
        Me.txtLongText.WordWrap = CType(resources.GetObject("txtLongText.WordWrap"), Boolean)
        '
        'optGradient
        '
        Me.optGradient.AccessibleDescription = resources.GetString("optGradient.AccessibleDescription")
        Me.optGradient.AccessibleName = resources.GetString("optGradient.AccessibleName")
        Me.optGradient.Anchor = CType(resources.GetObject("optGradient.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optGradient.Appearance = CType(resources.GetObject("optGradient.Appearance"), System.Windows.Forms.Appearance)
        Me.optGradient.BackgroundImage = CType(resources.GetObject("optGradient.BackgroundImage"), System.Drawing.Image)
        Me.optGradient.CheckAlign = CType(resources.GetObject("optGradient.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optGradient.Dock = CType(resources.GetObject("optGradient.Dock"), System.Windows.Forms.DockStyle)
        Me.optGradient.Enabled = CType(resources.GetObject("optGradient.Enabled"), Boolean)
        Me.optGradient.FlatStyle = CType(resources.GetObject("optGradient.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optGradient.Font = CType(resources.GetObject("optGradient.Font"), System.Drawing.Font)
        Me.optGradient.Image = CType(resources.GetObject("optGradient.Image"), System.Drawing.Image)
        Me.optGradient.ImageAlign = CType(resources.GetObject("optGradient.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optGradient.ImageIndex = CType(resources.GetObject("optGradient.ImageIndex"), Integer)
        Me.optGradient.ImeMode = CType(resources.GetObject("optGradient.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optGradient.Location = CType(resources.GetObject("optGradient.Location"), System.Drawing.Point)
        Me.optGradient.Name = "optGradient"
        Me.optGradient.RightToLeft = CType(resources.GetObject("optGradient.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optGradient.Size = CType(resources.GetObject("optGradient.Size"), System.Drawing.Size)
        Me.optGradient.TabIndex = CType(resources.GetObject("optGradient.TabIndex"), Integer)
        Me.optGradient.TabStop = True
        Me.optGradient.Text = resources.GetString("optGradient.Text")
        Me.optGradient.TextAlign = CType(resources.GetObject("optGradient.TextAlign"), System.Drawing.ContentAlignment)
        Me.optGradient.Visible = CType(resources.GetObject("optGradient.Visible"), Boolean)
        '
        'optHatch
        '
        Me.optHatch.AccessibleDescription = resources.GetString("optHatch.AccessibleDescription")
        Me.optHatch.AccessibleName = resources.GetString("optHatch.AccessibleName")
        Me.optHatch.Anchor = CType(resources.GetObject("optHatch.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optHatch.Appearance = CType(resources.GetObject("optHatch.Appearance"), System.Windows.Forms.Appearance)
        Me.optHatch.BackgroundImage = CType(resources.GetObject("optHatch.BackgroundImage"), System.Drawing.Image)
        Me.optHatch.CheckAlign = CType(resources.GetObject("optHatch.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optHatch.Checked = True
        Me.optHatch.Dock = CType(resources.GetObject("optHatch.Dock"), System.Windows.Forms.DockStyle)
        Me.optHatch.Enabled = CType(resources.GetObject("optHatch.Enabled"), Boolean)
        Me.optHatch.FlatStyle = CType(resources.GetObject("optHatch.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optHatch.Font = CType(resources.GetObject("optHatch.Font"), System.Drawing.Font)
        Me.optHatch.Image = CType(resources.GetObject("optHatch.Image"), System.Drawing.Image)
        Me.optHatch.ImageAlign = CType(resources.GetObject("optHatch.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optHatch.ImageIndex = CType(resources.GetObject("optHatch.ImageIndex"), Integer)
        Me.optHatch.ImeMode = CType(resources.GetObject("optHatch.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optHatch.Location = CType(resources.GetObject("optHatch.Location"), System.Drawing.Point)
        Me.optHatch.Name = "optHatch"
        Me.optHatch.RightToLeft = CType(resources.GetObject("optHatch.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optHatch.Size = CType(resources.GetObject("optHatch.Size"), System.Drawing.Size)
        Me.optHatch.TabIndex = CType(resources.GetObject("optHatch.TabIndex"), Integer)
        Me.optHatch.TabStop = True
        Me.optHatch.Text = resources.GetString("optHatch.Text")
        Me.optHatch.TextAlign = CType(resources.GetObject("optHatch.TextAlign"), System.Drawing.ContentAlignment)
        Me.optHatch.Visible = CType(resources.GetObject("optHatch.Visible"), Boolean)
        '
        'picDemoArea
        '
        Me.picDemoArea.AccessibleDescription = resources.GetString("picDemoArea.AccessibleDescription")
        Me.picDemoArea.AccessibleName = resources.GetString("picDemoArea.AccessibleName")
        Me.picDemoArea.Anchor = CType(resources.GetObject("picDemoArea.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.picDemoArea.BackgroundImage = CType(resources.GetObject("picDemoArea.BackgroundImage"), System.Drawing.Image)
        Me.picDemoArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picDemoArea.Dock = CType(resources.GetObject("picDemoArea.Dock"), System.Windows.Forms.DockStyle)
        Me.picDemoArea.Enabled = CType(resources.GetObject("picDemoArea.Enabled"), Boolean)
        Me.picDemoArea.Font = CType(resources.GetObject("picDemoArea.Font"), System.Drawing.Font)
        Me.picDemoArea.Image = CType(resources.GetObject("picDemoArea.Image"), System.Drawing.Image)
        Me.picDemoArea.ImeMode = CType(resources.GetObject("picDemoArea.ImeMode"), System.Windows.Forms.ImeMode)
        Me.picDemoArea.Location = CType(resources.GetObject("picDemoArea.Location"), System.Drawing.Point)
        Me.picDemoArea.Name = "picDemoArea"
        Me.picDemoArea.RightToLeft = CType(resources.GetObject("picDemoArea.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.picDemoArea.Size = CType(resources.GetObject("picDemoArea.Size"), System.Drawing.Size)
        Me.picDemoArea.SizeMode = CType(resources.GetObject("picDemoArea.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.picDemoArea.TabIndex = CType(resources.GetObject("picDemoArea.TabIndex"), Integer)
        Me.picDemoArea.TabStop = False
        Me.picDemoArea.Text = resources.GetString("picDemoArea.Text")
        Me.picDemoArea.Visible = CType(resources.GetObject("picDemoArea.Visible"), Boolean)
        '
        'nudFontSize
        '
        Me.nudFontSize.AccessibleDescription = resources.GetString("nudFontSize.AccessibleDescription")
        Me.nudFontSize.AccessibleName = resources.GetString("nudFontSize.AccessibleName")
        Me.nudFontSize.Anchor = CType(resources.GetObject("nudFontSize.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.nudFontSize.Dock = CType(resources.GetObject("nudFontSize.Dock"), System.Windows.Forms.DockStyle)
        Me.nudFontSize.Enabled = CType(resources.GetObject("nudFontSize.Enabled"), Boolean)
        Me.nudFontSize.Font = CType(resources.GetObject("nudFontSize.Font"), System.Drawing.Font)
        Me.nudFontSize.ImeMode = CType(resources.GetObject("nudFontSize.ImeMode"), System.Windows.Forms.ImeMode)
        Me.nudFontSize.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudFontSize.Location = CType(resources.GetObject("nudFontSize.Location"), System.Drawing.Point)
        Me.nudFontSize.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.nudFontSize.Name = "nudFontSize"
        Me.nudFontSize.RightToLeft = CType(resources.GetObject("nudFontSize.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.nudFontSize.Size = CType(resources.GetObject("nudFontSize.Size"), System.Drawing.Size)
        Me.nudFontSize.TabIndex = CType(resources.GetObject("nudFontSize.TabIndex"), Integer)
        Me.nudFontSize.TextAlign = CType(resources.GetObject("nudFontSize.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.nudFontSize.ThousandsSeparator = CType(resources.GetObject("nudFontSize.ThousandsSeparator"), Boolean)
        Me.nudFontSize.UpDownAlign = CType(resources.GetObject("nudFontSize.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.nudFontSize.Value = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudFontSize.Visible = CType(resources.GetObject("nudFontSize.Visible"), Boolean)
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
        'btnEmboss
        '
        Me.btnEmboss.AccessibleDescription = resources.GetString("btnEmboss.AccessibleDescription")
        Me.btnEmboss.AccessibleName = resources.GetString("btnEmboss.AccessibleName")
        Me.btnEmboss.Anchor = CType(resources.GetObject("btnEmboss.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnEmboss.BackgroundImage = CType(resources.GetObject("btnEmboss.BackgroundImage"), System.Drawing.Image)
        Me.btnEmboss.Dock = CType(resources.GetObject("btnEmboss.Dock"), System.Windows.Forms.DockStyle)
        Me.btnEmboss.Enabled = CType(resources.GetObject("btnEmboss.Enabled"), Boolean)
        Me.btnEmboss.FlatStyle = CType(resources.GetObject("btnEmboss.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnEmboss.Font = CType(resources.GetObject("btnEmboss.Font"), System.Drawing.Font)
        Me.btnEmboss.Image = CType(resources.GetObject("btnEmboss.Image"), System.Drawing.Image)
        Me.btnEmboss.ImageAlign = CType(resources.GetObject("btnEmboss.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnEmboss.ImageIndex = CType(resources.GetObject("btnEmboss.ImageIndex"), Integer)
        Me.btnEmboss.ImeMode = CType(resources.GetObject("btnEmboss.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnEmboss.Location = CType(resources.GetObject("btnEmboss.Location"), System.Drawing.Point)
        Me.btnEmboss.Name = "btnEmboss"
        Me.btnEmboss.RightToLeft = CType(resources.GetObject("btnEmboss.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnEmboss.Size = CType(resources.GetObject("btnEmboss.Size"), System.Drawing.Size)
        Me.btnEmboss.TabIndex = CType(resources.GetObject("btnEmboss.TabIndex"), Integer)
        Me.btnEmboss.Text = resources.GetString("btnEmboss.Text")
        Me.btnEmboss.TextAlign = CType(resources.GetObject("btnEmboss.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnEmboss.Visible = CType(resources.GetObject("btnEmboss.Visible"), Boolean)
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
        'nudEmbossDepth
        '
        Me.nudEmbossDepth.AccessibleDescription = resources.GetString("nudEmbossDepth.AccessibleDescription")
        Me.nudEmbossDepth.AccessibleName = resources.GetString("nudEmbossDepth.AccessibleName")
        Me.nudEmbossDepth.Anchor = CType(resources.GetObject("nudEmbossDepth.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.nudEmbossDepth.Dock = CType(resources.GetObject("nudEmbossDepth.Dock"), System.Windows.Forms.DockStyle)
        Me.nudEmbossDepth.Enabled = CType(resources.GetObject("nudEmbossDepth.Enabled"), Boolean)
        Me.nudEmbossDepth.Font = CType(resources.GetObject("nudEmbossDepth.Font"), System.Drawing.Font)
        Me.nudEmbossDepth.ImeMode = CType(resources.GetObject("nudEmbossDepth.ImeMode"), System.Windows.Forms.ImeMode)
        Me.nudEmbossDepth.Location = CType(resources.GetObject("nudEmbossDepth.Location"), System.Drawing.Point)
        Me.nudEmbossDepth.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudEmbossDepth.Name = "nudEmbossDepth"
        Me.nudEmbossDepth.RightToLeft = CType(resources.GetObject("nudEmbossDepth.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.nudEmbossDepth.Size = CType(resources.GetObject("nudEmbossDepth.Size"), System.Drawing.Size)
        Me.nudEmbossDepth.TabIndex = CType(resources.GetObject("nudEmbossDepth.TabIndex"), Integer)
        Me.nudEmbossDepth.TextAlign = CType(resources.GetObject("nudEmbossDepth.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.nudEmbossDepth.ThousandsSeparator = CType(resources.GetObject("nudEmbossDepth.ThousandsSeparator"), Boolean)
        Me.nudEmbossDepth.UpDownAlign = CType(resources.GetObject("nudEmbossDepth.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.nudEmbossDepth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudEmbossDepth.Visible = CType(resources.GetObject("nudEmbossDepth.Visible"), Boolean)
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
        'nudBlockDepth
        '
        Me.nudBlockDepth.AccessibleDescription = resources.GetString("nudBlockDepth.AccessibleDescription")
        Me.nudBlockDepth.AccessibleName = resources.GetString("nudBlockDepth.AccessibleName")
        Me.nudBlockDepth.Anchor = CType(resources.GetObject("nudBlockDepth.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.nudBlockDepth.Dock = CType(resources.GetObject("nudBlockDepth.Dock"), System.Windows.Forms.DockStyle)
        Me.nudBlockDepth.Enabled = CType(resources.GetObject("nudBlockDepth.Enabled"), Boolean)
        Me.nudBlockDepth.Font = CType(resources.GetObject("nudBlockDepth.Font"), System.Drawing.Font)
        Me.nudBlockDepth.ImeMode = CType(resources.GetObject("nudBlockDepth.ImeMode"), System.Windows.Forms.ImeMode)
        Me.nudBlockDepth.Location = CType(resources.GetObject("nudBlockDepth.Location"), System.Drawing.Point)
        Me.nudBlockDepth.Maximum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.nudBlockDepth.Name = "nudBlockDepth"
        Me.nudBlockDepth.RightToLeft = CType(resources.GetObject("nudBlockDepth.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.nudBlockDepth.Size = CType(resources.GetObject("nudBlockDepth.Size"), System.Drawing.Size)
        Me.nudBlockDepth.TabIndex = CType(resources.GetObject("nudBlockDepth.TabIndex"), Integer)
        Me.nudBlockDepth.TextAlign = CType(resources.GetObject("nudBlockDepth.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.nudBlockDepth.ThousandsSeparator = CType(resources.GetObject("nudBlockDepth.ThousandsSeparator"), Boolean)
        Me.nudBlockDepth.UpDownAlign = CType(resources.GetObject("nudBlockDepth.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.nudBlockDepth.Value = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudBlockDepth.Visible = CType(resources.GetObject("nudBlockDepth.Visible"), Boolean)
        '
        'btnBlockText
        '
        Me.btnBlockText.AccessibleDescription = resources.GetString("btnBlockText.AccessibleDescription")
        Me.btnBlockText.AccessibleName = resources.GetString("btnBlockText.AccessibleName")
        Me.btnBlockText.Anchor = CType(resources.GetObject("btnBlockText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBlockText.BackgroundImage = CType(resources.GetObject("btnBlockText.BackgroundImage"), System.Drawing.Image)
        Me.btnBlockText.Dock = CType(resources.GetObject("btnBlockText.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBlockText.Enabled = CType(resources.GetObject("btnBlockText.Enabled"), Boolean)
        Me.btnBlockText.FlatStyle = CType(resources.GetObject("btnBlockText.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBlockText.Font = CType(resources.GetObject("btnBlockText.Font"), System.Drawing.Font)
        Me.btnBlockText.Image = CType(resources.GetObject("btnBlockText.Image"), System.Drawing.Image)
        Me.btnBlockText.ImageAlign = CType(resources.GetObject("btnBlockText.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBlockText.ImageIndex = CType(resources.GetObject("btnBlockText.ImageIndex"), Integer)
        Me.btnBlockText.ImeMode = CType(resources.GetObject("btnBlockText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBlockText.Location = CType(resources.GetObject("btnBlockText.Location"), System.Drawing.Point)
        Me.btnBlockText.Name = "btnBlockText"
        Me.btnBlockText.RightToLeft = CType(resources.GetObject("btnBlockText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBlockText.Size = CType(resources.GetObject("btnBlockText.Size"), System.Drawing.Size)
        Me.btnBlockText.TabIndex = CType(resources.GetObject("btnBlockText.TabIndex"), Integer)
        Me.btnBlockText.Text = resources.GetString("btnBlockText.Text")
        Me.btnBlockText.TextAlign = CType(resources.GetObject("btnBlockText.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBlockText.Visible = CType(resources.GetObject("btnBlockText.Visible"), Boolean)
        '
        'btnReflectedText
        '
        Me.btnReflectedText.AccessibleDescription = resources.GetString("btnReflectedText.AccessibleDescription")
        Me.btnReflectedText.AccessibleName = resources.GetString("btnReflectedText.AccessibleName")
        Me.btnReflectedText.Anchor = CType(resources.GetObject("btnReflectedText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnReflectedText.BackgroundImage = CType(resources.GetObject("btnReflectedText.BackgroundImage"), System.Drawing.Image)
        Me.btnReflectedText.Dock = CType(resources.GetObject("btnReflectedText.Dock"), System.Windows.Forms.DockStyle)
        Me.btnReflectedText.Enabled = CType(resources.GetObject("btnReflectedText.Enabled"), Boolean)
        Me.btnReflectedText.FlatStyle = CType(resources.GetObject("btnReflectedText.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnReflectedText.Font = CType(resources.GetObject("btnReflectedText.Font"), System.Drawing.Font)
        Me.btnReflectedText.Image = CType(resources.GetObject("btnReflectedText.Image"), System.Drawing.Image)
        Me.btnReflectedText.ImageAlign = CType(resources.GetObject("btnReflectedText.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnReflectedText.ImageIndex = CType(resources.GetObject("btnReflectedText.ImageIndex"), Integer)
        Me.btnReflectedText.ImeMode = CType(resources.GetObject("btnReflectedText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnReflectedText.Location = CType(resources.GetObject("btnReflectedText.Location"), System.Drawing.Point)
        Me.btnReflectedText.Name = "btnReflectedText"
        Me.btnReflectedText.RightToLeft = CType(resources.GetObject("btnReflectedText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnReflectedText.Size = CType(resources.GetObject("btnReflectedText.Size"), System.Drawing.Size)
        Me.btnReflectedText.TabIndex = CType(resources.GetObject("btnReflectedText.TabIndex"), Integer)
        Me.btnReflectedText.Text = resources.GetString("btnReflectedText.Text")
        Me.btnReflectedText.TextAlign = CType(resources.GetObject("btnReflectedText.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnReflectedText.Visible = CType(resources.GetObject("btnReflectedText.Visible"), Boolean)
        '
        'btnShearText
        '
        Me.btnShearText.AccessibleDescription = resources.GetString("btnShearText.AccessibleDescription")
        Me.btnShearText.AccessibleName = resources.GetString("btnShearText.AccessibleName")
        Me.btnShearText.Anchor = CType(resources.GetObject("btnShearText.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnShearText.BackgroundImage = CType(resources.GetObject("btnShearText.BackgroundImage"), System.Drawing.Image)
        Me.btnShearText.Dock = CType(resources.GetObject("btnShearText.Dock"), System.Windows.Forms.DockStyle)
        Me.btnShearText.Enabled = CType(resources.GetObject("btnShearText.Enabled"), Boolean)
        Me.btnShearText.FlatStyle = CType(resources.GetObject("btnShearText.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnShearText.Font = CType(resources.GetObject("btnShearText.Font"), System.Drawing.Font)
        Me.btnShearText.Image = CType(resources.GetObject("btnShearText.Image"), System.Drawing.Image)
        Me.btnShearText.ImageAlign = CType(resources.GetObject("btnShearText.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnShearText.ImageIndex = CType(resources.GetObject("btnShearText.ImageIndex"), Integer)
        Me.btnShearText.ImeMode = CType(resources.GetObject("btnShearText.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnShearText.Location = CType(resources.GetObject("btnShearText.Location"), System.Drawing.Point)
        Me.btnShearText.Name = "btnShearText"
        Me.btnShearText.RightToLeft = CType(resources.GetObject("btnShearText.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnShearText.Size = CType(resources.GetObject("btnShearText.Size"), System.Drawing.Size)
        Me.btnShearText.TabIndex = CType(resources.GetObject("btnShearText.TabIndex"), Integer)
        Me.btnShearText.Text = resources.GetString("btnShearText.Text")
        Me.btnShearText.TextAlign = CType(resources.GetObject("btnShearText.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnShearText.Visible = CType(resources.GetObject("btnShearText.Visible"), Boolean)
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = resources.GetString("Label4.AccessibleDescription")
        Me.Label4.AccessibleName = resources.GetString("Label4.AccessibleName")
        Me.Label4.Anchor = CType(resources.GetObject("Label4.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = CType(resources.GetObject("Label4.AutoSize"), Boolean)
        Me.Label4.Dock = CType(resources.GetObject("Label4.Dock"), System.Windows.Forms.DockStyle)
        Me.Label4.Enabled = CType(resources.GetObject("Label4.Enabled"), Boolean)
        Me.Label4.Font = CType(resources.GetObject("Label4.Font"), System.Drawing.Font)
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = CType(resources.GetObject("Label4.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label4.ImageIndex = CType(resources.GetObject("Label4.ImageIndex"), Integer)
        Me.Label4.ImeMode = CType(resources.GetObject("Label4.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label4.Location = CType(resources.GetObject("Label4.Location"), System.Drawing.Point)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = CType(resources.GetObject("Label4.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label4.Size = CType(resources.GetObject("Label4.Size"), System.Drawing.Size)
        Me.Label4.TabIndex = CType(resources.GetObject("Label4.TabIndex"), Integer)
        Me.Label4.Text = resources.GetString("Label4.Text")
        Me.Label4.TextAlign = CType(resources.GetObject("Label4.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label4.Visible = CType(resources.GetObject("Label4.Visible"), Boolean)
        '
        'nudSkew
        '
        Me.nudSkew.AccessibleDescription = resources.GetString("nudSkew.AccessibleDescription")
        Me.nudSkew.AccessibleName = resources.GetString("nudSkew.AccessibleName")
        Me.nudSkew.Anchor = CType(resources.GetObject("nudSkew.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.nudSkew.DecimalPlaces = 1
        Me.nudSkew.Dock = CType(resources.GetObject("nudSkew.Dock"), System.Windows.Forms.DockStyle)
        Me.nudSkew.Enabled = CType(resources.GetObject("nudSkew.Enabled"), Boolean)
        Me.nudSkew.Font = CType(resources.GetObject("nudSkew.Font"), System.Drawing.Font)
        Me.nudSkew.ImeMode = CType(resources.GetObject("nudSkew.ImeMode"), System.Windows.Forms.ImeMode)
        Me.nudSkew.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudSkew.Location = CType(resources.GetObject("nudSkew.Location"), System.Drawing.Point)
        Me.nudSkew.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudSkew.Minimum = New Decimal(New Integer() {2, 0, 0, -2147483648})
        Me.nudSkew.Name = "nudSkew"
        Me.nudSkew.RightToLeft = CType(resources.GetObject("nudSkew.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.nudSkew.Size = CType(resources.GetObject("nudSkew.Size"), System.Drawing.Size)
        Me.nudSkew.TabIndex = CType(resources.GetObject("nudSkew.TabIndex"), Integer)
        Me.nudSkew.TextAlign = CType(resources.GetObject("nudSkew.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.nudSkew.ThousandsSeparator = CType(resources.GetObject("nudSkew.ThousandsSeparator"), Boolean)
        Me.nudSkew.UpDownAlign = CType(resources.GetObject("nudSkew.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        Me.nudSkew.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSkew.Visible = CType(resources.GetObject("nudSkew.Visible"), Boolean)
        '
        'frmMain
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.nudSkew, Me.btnShearText, Me.btnReflectedText, Me.Label3, Me.nudBlockDepth, Me.btnBlockText, Me.Label2, Me.nudEmbossDepth, Me.btnEmboss, Me.Label1, Me.nudFontSize, Me.picDemoArea, Me.Label12, Me.nudShadowDepth, Me.btnShadowText, Me.btnBrushText, Me.Label11, Me.txtShortText, Me.btnSimpleText, Me.txtLongText, Me.optGradient, Me.optHatch})
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
        CType(Me.nudShadowDepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudEmbossDepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBlockDepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSkew, System.ComponentModel.ISupportInitialize).EndInit()
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

    ' This Sub creates the Sample Text with an Embossed look
    '   To create effect, the Sample Text is drawn twice.  The first
    '   time it is in Black and offset, then drawn in aquamarine.
    ' This gives the impression of the text being raised.
    ' To give the imporession of being engraved, simply use the
    '   negative of the Offset.
    Private Sub btnBlockText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlockText.Click
        Dim textSize As SizeF
        Dim g As Graphics
        Dim myBackBrush As Brush = Brushes.Black
        Dim myForeBrush As Brush = Brushes.Aquamarine
        Dim myFont As New Font("Times New Roman", Me.nudFontSize.Value, FontStyle.Regular)
        Dim xLocation, yLocation As Single ' Used for the location
        Dim i As Integer

        ' Create a Graphics object from the picture box & clear it
        g = picDemoArea.CreateGraphics()
        g.Clear(Color.White)

        ' Find the Size required to draw the Sample Text
        textSize = g.MeasureString(Me.txtShortText.Text, myFont)

        ' Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2
        yLocation = (picDemoArea.Height - textSize.Height) / 2

        ' Draw the Black background first
        '   To get the effect, the text must be drawn repeatedly
        '   from the offset right up to where the main text
        '   will be drawn.
        ' Since people tend to think of light coming from the 
        '   upper right, it often makes more sense to subtract
        '   the offset depth from the X dimension, instead of 
        '   adding it. Otherwise, it looks more like a shadow.
        For i = CInt(nudBlockDepth.Value) To 0 Step -1
            g.DrawString(txtShortText.Text, myFont, myBackBrush, _
                    xLocation - i, yLocation + i)
        Next

        ' Draw the aquamarine main text over the black text
        g.DrawString(txtShortText.Text, myFont, myForeBrush, xLocation, yLocation)
    End Sub

    ' This Sub creates the Sample Text with a brush (Hatch or Gradient)
    Private Sub btnBrushText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrushText.Click

        Dim textSize As SizeF
        Dim g As Graphics
        Dim myBrush As Brush
        Dim gradientRectangle As RectangleF
        Dim myFont As New Font("Times New Roman", Me.nudFontSize.Value, FontStyle.Regular)

        ' Create a Graphics object from the picture box & clear it
        g = picDemoArea.CreateGraphics()
        g.Clear(Color.White)

        ' Find the Size required to draw the Sample Text
        textSize = g.MeasureString(Me.txtShortText.Text, myFont)

        ' Create the required brush
        If Me.optHatch.Checked Then
            ' Create a HatchBrush. In this case, simply a Diagonal Brick
            myBrush = New HatchBrush(HatchStyle.DiagonalBrick, _
                Color.Blue, Color.Yellow)
        Else
            ' Create a LinearGradientBrush. In this case, simply a 
            '   Diagonal Gradient 
            gradientRectangle = New RectangleF(New PointF(0, 0), textSize)
            myBrush = New LinearGradientBrush(gradientRectangle, Color.Blue, _
                Color.Yellow, LinearGradientMode.ForwardDiagonal)
        End If

        ' Draw the text
        g.DrawString(txtShortText.Text, myFont, myBrush, _
                (picDemoArea.Width - textSize.Width) / 2, _
                (picDemoArea.Height - textSize.Height) / 2)
    End Sub

    ' This Sub creates the Sample Text with an Embossed look
    '   To create effect, the Sample Text is drawn twice.  The first
    '   time it is in Black and offset, then drawn in white, the 
    '   current background color.
    ' This gives the impression of the text being raised.
    ' To give the imporession of being engraved, simply use the
    '   negative of the Offset.
    Private Sub btnEmboss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmboss.Click
        Dim textSize As SizeF
        Dim g As Graphics
        Dim myBackBrush As Brush = Brushes.Black
        Dim myForeBrush As Brush = Brushes.White
        Dim myFont As New Font("Times New Roman", Me.nudFontSize.Value, FontStyle.Regular)
        Dim xLocation, yLocation As Single ' Used for the location

        ' Create a Graphics object from the picture box & clear it
        g = picDemoArea.CreateGraphics()
        g.Clear(Color.White)

        ' Find the Size required to draw the Sample Text
        textSize = g.MeasureString(Me.txtShortText.Text, myFont)

        ' Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2
        yLocation = (picDemoArea.Height - textSize.Height) / 2

        ' Draw the Black background first
        ' (Note: if you instead subtract the mudEmbossDepth, you will get
        '   an Engrave effect.)
        g.DrawString(txtShortText.Text, myFont, myBackBrush, _
                xLocation + Me.nudEmbossDepth.Value, _
                yLocation + Me.nudEmbossDepth.Value)

        ' Draw the white main text over the black text
        g.DrawString(txtShortText.Text, myFont, myForeBrush, xLocation, yLocation)
    End Sub

    ' This sub reflects text around the baseline of the characters.
    '   This is the first example that requires careful measurement of 
    '   the text, and is more advanced than most of the other examples.
    Private Sub btnReflectedText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReflectedText.Click
        Dim textSize As SizeF
        Dim g As Graphics
        Dim myBackBrush As Brush = Brushes.Gray
        Dim myForeBrush As Brush = Brushes.Black
        Dim myFont As New Font("Times New Roman", Me.nudFontSize.Value, FontStyle.Regular)
        Dim myState As GraphicsState ' Used to store current state of Graphics
        Dim xLocation, yLocation As Single ' Used for the location
        Dim textHeight As Single
        Dim i As Integer ' For Loops

        ' Create a Graphics object from the picture box & clear it
        g = picDemoArea.CreateGraphics()
        g.Clear(Color.White)

        ' Find the Size required to draw the Sample Text
        textSize = g.MeasureString(Me.txtShortText.Text, myFont)

        ' Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2
        yLocation = (picDemoArea.Height - textSize.Height) / 2

        ' Because we will be scaling, and scaling effects the ENTIRE
        '   graphics object, not just the text, we need to reposition
        '   the Origin of the Graphics object (0,0) to the (xLocation,
        '   yLocation) point. If we don't, when we attempt to flip 
        '   the text with a scaling transform, it will merely draw the
        '   reflected text at (xLocation, -yLocation) which is outside
        '   the viewable area.
        g.TranslateTransform(xLocation, yLocation)

        ' Reflecting around the Origin still poses problems. The
        '   origin represents the upper left corner of the rectangle.
        '   This means the reflection will occur at the TOP of the 
        '   original drawing. This is not how people are used to 
        '   seing reflected text. Thus, we need to determine where to
        '   draw the text. This can be done only when we have calculated
        '   the height required by the Drawing.
        ' This is not as simple as it may seem. The Height returned 
        '   from the MeasureString method includes some extra spacing 
        '   for descenders and whitespace. We want ONLY the height from
        '   the BASELINE (which is the line which all caps sit). Any
        '   characters with descenders drop below the baseline. To 
        '   calculate the height above the baseline, use the 
        '   GetCellAscent method. Since GetCellAscent returns a Design
        '   Metric value it must be converted to pixels, and scaled for
        '   the font size.
        ' Note: this looks best with characters that can be reflected
        '   over the baseline nicely -- like caps. Characters with descenders
        '   look odd. To fix that uncomment the two lines below, which
        '   then reflect across the lowest descender height.

        Dim lineAscent As Integer
        Dim lineSpacing As Integer
        Dim lineHeight As Single

        lineAscent = myFont.FontFamily.GetCellAscent(myFont.Style)
        lineSpacing = myFont.FontFamily.GetLineSpacing(myFont.Style)
        lineHeight = myFont.GetHeight(g)
        textHeight = lineHeight * lineAscent / lineSpacing

        '' Uncomment these lines to reflect over lowest portion
        ''   of the characters.
        'Dim lineDescent As Integer ' used for reflecting descending characters
        'lineDescent = myFont.FontFamily.GetCellDescent(myFont.Style)
        'textHeight = lineHeight * (lineAscent + lineDescent) / lineSpacing


        ' Draw the reflected one first. The only reason to draw the
        '   Reflected one first is to demonstrate the use of the
        '   GraphicsState object. 
        ' A GraphicsState object maintains the state of the Graphics
        '   object as it currently stands. You can then scale, resize and
        '   otherwise transform the Graphics object. You can 
        '   immediately go back to a previous state using the Restore
        '   method of the Graphics object.
        ' Had we drawn the main one first, we would not have needed the 
        '   Restore method or the GraphicsState object.

        ' First Save the graphics state
        myState = g.Save()

        ' To draw the reflection, use the ScaleTransform with a negative
        '   value. Using -1 will reflect the Text with no distortion.
        ' Remember to account for the fact that the origin has been reset.
        g.ScaleTransform(1, -1.0F) ' Only reflecting in the Y direction
        g.DrawString(txtShortText.Text, myFont, myBackBrush, 0, -textHeight)

        ' Reset the graphics state to before the transform
        g.Restore(myState)

        ' Draw the main text
        g.DrawString(txtShortText.Text, myFont, myForeBrush, 0, -textHeight)

    End Sub

    ' This Sub creates the Sample Text with a solid brush and shadow
    '   To create the shadow, the Sample Text is drawn twice.  The first
    '   time it is in Grey and offset, then normally in Black.
    '   Other colors can, of course, be used.
    Private Sub btnShadowText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShadowText.Click
        Dim textSize As SizeF
        Dim g As Graphics
        Dim myShadowBrush As Brush = Brushes.Gray
        Dim myForeBrush As Brush = Brushes.Black
        Dim myFont As New Font("Times New Roman", Me.nudFontSize.Value, FontStyle.Regular)
        Dim xLocation, yLocation As Single ' Used for the location

        ' Create a Graphics object from the picture box & clear it
        g = picDemoArea.CreateGraphics()
        g.Clear(Color.White)

        ' Find the Size required to draw the Sample Text
        textSize = g.MeasureString(Me.txtShortText.Text, myFont)

        ' Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2
        yLocation = (picDemoArea.Height - textSize.Height) / 2

        ' Draw the Shadow first
        g.DrawString(txtShortText.Text, myFont, myShadowBrush, _
                xLocation + Me.nudShadowDepth.Value, _
                yLocation + Me.nudShadowDepth.Value)

        ' Draw the Main text over the shadow
        g.DrawString(txtShortText.Text, myFont, myForeBrush, xLocation, yLocation)

    End Sub

    ' This sub shears the text so that it appears angled. This requires
    '   the use of a Matrix which defines the shear. 
    Private Sub btnShearText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShearText.Click
        Dim textSize As SizeF
        Dim g As Graphics
        Dim myForeBrush As Brush = Brushes.Black
        Dim myFont As New Font("Times New Roman", Me.nudFontSize.Value, FontStyle.Regular)
        Dim myTransform As Matrix ' Used for shearing text
        Dim xLocation, yLocation As Single ' Used for the location
        Dim textHeight As Single
        Dim i As Integer ' For Loops

        ' Create a Graphics object from the picture box & clear it
        g = picDemoArea.CreateGraphics()
        g.Clear(Color.White)

        ' Find the Size required to draw the Sample Text
        textSize = g.MeasureString(Me.txtShortText.Text, myFont)

        ' Get the locations once to eliminate redundant calculations
        xLocation = (picDemoArea.Width - textSize.Width) / 2
        yLocation = (picDemoArea.Height - textSize.Height) / 2

        ' Because we will be scaling, and scaling effects the ENTIRE
        '   graphics object, not just the text, we need to reposition
        '   the Origin of the Graphics object (0,0) to the (xLocation,
        '   yLocation) point. 
        g.TranslateTransform(xLocation, yLocation)

        ' Get the transform for the current Graphics object, and
        '   Shear it by the specified amount 
        myTransform = g.Transform
        myTransform.Shear(nudSkew.Value, 0)
        g.Transform = myTransform

        ' Draw the main text
        g.DrawString(txtShortText.Text, myFont, myForeBrush, 0, 0)

    End Sub

    ' This sub simply takes the lines of text in the textbox and places
    '   them in the picDemoArea PictureBox.  It will word wrap as
    '   necessary, but will not scroll.
    Private Sub btnSimpleText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpleText.Click
        Dim textSize As SizeF
        Dim g As Graphics
        Dim myForeBrush As Brush = Brushes.Black
        Dim myFont As New Font("Times New Roman", Me.nudFontSize.Value, FontStyle.Regular)
        Dim textHeight As Single
        Dim i As Integer ' For Loops

        ' Create a Graphics object from the picture box & clear it
        g = picDemoArea.CreateGraphics()
        g.Clear(Color.White)

        ' Find the Size required to draw the Sample Text
        textSize = g.MeasureString(txtLongText.Text, myFont)

        ' Draw the main text
        g.DrawString(txtLongText.Text, myFont, myForeBrush, _
            New RectangleF(0, 0, picDemoArea.Width, picDemoArea.Height))

    End Sub
End Class