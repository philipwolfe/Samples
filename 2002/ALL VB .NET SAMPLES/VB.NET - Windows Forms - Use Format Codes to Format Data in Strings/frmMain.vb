'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Threading
Imports System.Globalization
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
    Friend WithEvents pgeNumeric As System.Windows.Forms.TabPage
    Friend WithEvents pgeDateTime As System.Windows.Forms.TabPage
    Friend WithEvents pgeEnum As System.Windows.Forms.TabPage
    Friend WithEvents tabExamples As System.Windows.Forms.TabControl
    Friend WithEvents optStandardNumeric As System.Windows.Forms.RadioButton
    Friend WithEvents optCustomNumeric As System.Windows.Forms.RadioButton
    Friend WithEvents txtNumeric As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents optCustomDateTime As System.Windows.Forms.RadioButton
    Friend WithEvents optStandardDateTime As System.Windows.Forms.RadioButton
    Friend WithEvents txtDateTime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCultureInfoDateTime As System.Windows.Forms.ComboBox
    Friend WithEvents cboCultureInfoNumeric As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEnum As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tabExamples = New System.Windows.Forms.TabControl()
        Me.pgeNumeric = New System.Windows.Forms.TabPage()
        Me.cboCultureInfoNumeric = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optCustomNumeric = New System.Windows.Forms.RadioButton()
        Me.optStandardNumeric = New System.Windows.Forms.RadioButton()
        Me.txtNumeric = New System.Windows.Forms.TextBox()
        Me.pgeDateTime = New System.Windows.Forms.TabPage()
        Me.cboCultureInfoDateTime = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.optCustomDateTime = New System.Windows.Forms.RadioButton()
        Me.optStandardDateTime = New System.Windows.Forms.RadioButton()
        Me.txtDateTime = New System.Windows.Forms.TextBox()
        Me.pgeEnum = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEnum = New System.Windows.Forms.TextBox()
        Me.tabExamples.SuspendLayout()
        Me.pgeNumeric.SuspendLayout()
        Me.pgeDateTime.SuspendLayout()
        Me.pgeEnum.SuspendLayout()
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
        'tabExamples
        '
        Me.tabExamples.AccessibleDescription = resources.GetString("tabExamples.AccessibleDescription")
        Me.tabExamples.AccessibleName = resources.GetString("tabExamples.AccessibleName")
        Me.tabExamples.Alignment = CType(resources.GetObject("tabExamples.Alignment"), System.Windows.Forms.TabAlignment)
        Me.tabExamples.Anchor = CType(resources.GetObject("tabExamples.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tabExamples.Appearance = CType(resources.GetObject("tabExamples.Appearance"), System.Windows.Forms.TabAppearance)
        Me.tabExamples.BackgroundImage = CType(resources.GetObject("tabExamples.BackgroundImage"), System.Drawing.Image)
        Me.tabExamples.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeNumeric, Me.pgeDateTime, Me.pgeEnum})
        Me.tabExamples.Dock = CType(resources.GetObject("tabExamples.Dock"), System.Windows.Forms.DockStyle)
        Me.tabExamples.Enabled = CType(resources.GetObject("tabExamples.Enabled"), Boolean)
        Me.tabExamples.Font = CType(resources.GetObject("tabExamples.Font"), System.Drawing.Font)
        Me.tabExamples.ImeMode = CType(resources.GetObject("tabExamples.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tabExamples.ItemSize = CType(resources.GetObject("tabExamples.ItemSize"), System.Drawing.Size)
        Me.tabExamples.Location = CType(resources.GetObject("tabExamples.Location"), System.Drawing.Point)
        Me.tabExamples.Name = "tabExamples"
        Me.tabExamples.Padding = CType(resources.GetObject("tabExamples.Padding"), System.Drawing.Point)
        Me.tabExamples.RightToLeft = CType(resources.GetObject("tabExamples.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tabExamples.SelectedIndex = 0
        Me.tabExamples.ShowToolTips = CType(resources.GetObject("tabExamples.ShowToolTips"), Boolean)
        Me.tabExamples.Size = CType(resources.GetObject("tabExamples.Size"), System.Drawing.Size)
        Me.tabExamples.TabIndex = CType(resources.GetObject("tabExamples.TabIndex"), Integer)
        Me.tabExamples.Text = resources.GetString("tabExamples.Text")
        Me.tabExamples.Visible = CType(resources.GetObject("tabExamples.Visible"), Boolean)
        '
        'pgeNumeric
        '
        Me.pgeNumeric.AccessibleDescription = resources.GetString("pgeNumeric.AccessibleDescription")
        Me.pgeNumeric.AccessibleName = resources.GetString("pgeNumeric.AccessibleName")
        Me.pgeNumeric.Anchor = CType(resources.GetObject("pgeNumeric.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeNumeric.AutoScroll = CType(resources.GetObject("pgeNumeric.AutoScroll"), Boolean)
        Me.pgeNumeric.AutoScrollMargin = CType(resources.GetObject("pgeNumeric.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeNumeric.AutoScrollMinSize = CType(resources.GetObject("pgeNumeric.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeNumeric.BackgroundImage = CType(resources.GetObject("pgeNumeric.BackgroundImage"), System.Drawing.Image)
        Me.pgeNumeric.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCultureInfoNumeric, Me.Label4, Me.Label1, Me.optCustomNumeric, Me.optStandardNumeric, Me.txtNumeric})
        Me.pgeNumeric.Dock = CType(resources.GetObject("pgeNumeric.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeNumeric.Enabled = CType(resources.GetObject("pgeNumeric.Enabled"), Boolean)
        Me.pgeNumeric.Font = CType(resources.GetObject("pgeNumeric.Font"), System.Drawing.Font)
        Me.pgeNumeric.ImageIndex = CType(resources.GetObject("pgeNumeric.ImageIndex"), Integer)
        Me.pgeNumeric.ImeMode = CType(resources.GetObject("pgeNumeric.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeNumeric.Location = CType(resources.GetObject("pgeNumeric.Location"), System.Drawing.Point)
        Me.pgeNumeric.Name = "pgeNumeric"
        Me.pgeNumeric.RightToLeft = CType(resources.GetObject("pgeNumeric.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeNumeric.Size = CType(resources.GetObject("pgeNumeric.Size"), System.Drawing.Size)
        Me.pgeNumeric.TabIndex = CType(resources.GetObject("pgeNumeric.TabIndex"), Integer)
        Me.pgeNumeric.Text = resources.GetString("pgeNumeric.Text")
        Me.pgeNumeric.ToolTipText = resources.GetString("pgeNumeric.ToolTipText")
        Me.pgeNumeric.Visible = CType(resources.GetObject("pgeNumeric.Visible"), Boolean)
        '
        'cboCultureInfoNumeric
        '
        Me.cboCultureInfoNumeric.AccessibleDescription = resources.GetString("cboCultureInfoNumeric.AccessibleDescription")
        Me.cboCultureInfoNumeric.AccessibleName = resources.GetString("cboCultureInfoNumeric.AccessibleName")
        Me.cboCultureInfoNumeric.Anchor = CType(resources.GetObject("cboCultureInfoNumeric.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboCultureInfoNumeric.BackgroundImage = CType(resources.GetObject("cboCultureInfoNumeric.BackgroundImage"), System.Drawing.Image)
        Me.cboCultureInfoNumeric.Dock = CType(resources.GetObject("cboCultureInfoNumeric.Dock"), System.Windows.Forms.DockStyle)
        Me.cboCultureInfoNumeric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultureInfoNumeric.Enabled = CType(resources.GetObject("cboCultureInfoNumeric.Enabled"), Boolean)
        Me.cboCultureInfoNumeric.Font = CType(resources.GetObject("cboCultureInfoNumeric.Font"), System.Drawing.Font)
        Me.cboCultureInfoNumeric.ImeMode = CType(resources.GetObject("cboCultureInfoNumeric.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboCultureInfoNumeric.IntegralHeight = CType(resources.GetObject("cboCultureInfoNumeric.IntegralHeight"), Boolean)
        Me.cboCultureInfoNumeric.ItemHeight = CType(resources.GetObject("cboCultureInfoNumeric.ItemHeight"), Integer)
        Me.cboCultureInfoNumeric.Location = CType(resources.GetObject("cboCultureInfoNumeric.Location"), System.Drawing.Point)
        Me.cboCultureInfoNumeric.MaxDropDownItems = CType(resources.GetObject("cboCultureInfoNumeric.MaxDropDownItems"), Integer)
        Me.cboCultureInfoNumeric.MaxLength = CType(resources.GetObject("cboCultureInfoNumeric.MaxLength"), Integer)
        Me.cboCultureInfoNumeric.Name = "cboCultureInfoNumeric"
        Me.cboCultureInfoNumeric.RightToLeft = CType(resources.GetObject("cboCultureInfoNumeric.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboCultureInfoNumeric.Size = CType(resources.GetObject("cboCultureInfoNumeric.Size"), System.Drawing.Size)
        Me.cboCultureInfoNumeric.TabIndex = CType(resources.GetObject("cboCultureInfoNumeric.TabIndex"), Integer)
        Me.cboCultureInfoNumeric.Text = resources.GetString("cboCultureInfoNumeric.Text")
        Me.cboCultureInfoNumeric.Visible = CType(resources.GetObject("cboCultureInfoNumeric.Visible"), Boolean)
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
        'optCustomNumeric
        '
        Me.optCustomNumeric.AccessibleDescription = resources.GetString("optCustomNumeric.AccessibleDescription")
        Me.optCustomNumeric.AccessibleName = resources.GetString("optCustomNumeric.AccessibleName")
        Me.optCustomNumeric.Anchor = CType(resources.GetObject("optCustomNumeric.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optCustomNumeric.Appearance = CType(resources.GetObject("optCustomNumeric.Appearance"), System.Windows.Forms.Appearance)
        Me.optCustomNumeric.BackgroundImage = CType(resources.GetObject("optCustomNumeric.BackgroundImage"), System.Drawing.Image)
        Me.optCustomNumeric.CheckAlign = CType(resources.GetObject("optCustomNumeric.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optCustomNumeric.Dock = CType(resources.GetObject("optCustomNumeric.Dock"), System.Windows.Forms.DockStyle)
        Me.optCustomNumeric.Enabled = CType(resources.GetObject("optCustomNumeric.Enabled"), Boolean)
        Me.optCustomNumeric.FlatStyle = CType(resources.GetObject("optCustomNumeric.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optCustomNumeric.Font = CType(resources.GetObject("optCustomNumeric.Font"), System.Drawing.Font)
        Me.optCustomNumeric.Image = CType(resources.GetObject("optCustomNumeric.Image"), System.Drawing.Image)
        Me.optCustomNumeric.ImageAlign = CType(resources.GetObject("optCustomNumeric.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optCustomNumeric.ImageIndex = CType(resources.GetObject("optCustomNumeric.ImageIndex"), Integer)
        Me.optCustomNumeric.ImeMode = CType(resources.GetObject("optCustomNumeric.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optCustomNumeric.Location = CType(resources.GetObject("optCustomNumeric.Location"), System.Drawing.Point)
        Me.optCustomNumeric.Name = "optCustomNumeric"
        Me.optCustomNumeric.RightToLeft = CType(resources.GetObject("optCustomNumeric.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optCustomNumeric.Size = CType(resources.GetObject("optCustomNumeric.Size"), System.Drawing.Size)
        Me.optCustomNumeric.TabIndex = CType(resources.GetObject("optCustomNumeric.TabIndex"), Integer)
        Me.optCustomNumeric.Text = resources.GetString("optCustomNumeric.Text")
        Me.optCustomNumeric.TextAlign = CType(resources.GetObject("optCustomNumeric.TextAlign"), System.Drawing.ContentAlignment)
        Me.optCustomNumeric.Visible = CType(resources.GetObject("optCustomNumeric.Visible"), Boolean)
        '
        'optStandardNumeric
        '
        Me.optStandardNumeric.AccessibleDescription = resources.GetString("optStandardNumeric.AccessibleDescription")
        Me.optStandardNumeric.AccessibleName = resources.GetString("optStandardNumeric.AccessibleName")
        Me.optStandardNumeric.Anchor = CType(resources.GetObject("optStandardNumeric.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optStandardNumeric.Appearance = CType(resources.GetObject("optStandardNumeric.Appearance"), System.Windows.Forms.Appearance)
        Me.optStandardNumeric.BackgroundImage = CType(resources.GetObject("optStandardNumeric.BackgroundImage"), System.Drawing.Image)
        Me.optStandardNumeric.CheckAlign = CType(resources.GetObject("optStandardNumeric.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optStandardNumeric.Checked = True
        Me.optStandardNumeric.Dock = CType(resources.GetObject("optStandardNumeric.Dock"), System.Windows.Forms.DockStyle)
        Me.optStandardNumeric.Enabled = CType(resources.GetObject("optStandardNumeric.Enabled"), Boolean)
        Me.optStandardNumeric.FlatStyle = CType(resources.GetObject("optStandardNumeric.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optStandardNumeric.Font = CType(resources.GetObject("optStandardNumeric.Font"), System.Drawing.Font)
        Me.optStandardNumeric.Image = CType(resources.GetObject("optStandardNumeric.Image"), System.Drawing.Image)
        Me.optStandardNumeric.ImageAlign = CType(resources.GetObject("optStandardNumeric.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optStandardNumeric.ImageIndex = CType(resources.GetObject("optStandardNumeric.ImageIndex"), Integer)
        Me.optStandardNumeric.ImeMode = CType(resources.GetObject("optStandardNumeric.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optStandardNumeric.Location = CType(resources.GetObject("optStandardNumeric.Location"), System.Drawing.Point)
        Me.optStandardNumeric.Name = "optStandardNumeric"
        Me.optStandardNumeric.RightToLeft = CType(resources.GetObject("optStandardNumeric.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optStandardNumeric.Size = CType(resources.GetObject("optStandardNumeric.Size"), System.Drawing.Size)
        Me.optStandardNumeric.TabIndex = CType(resources.GetObject("optStandardNumeric.TabIndex"), Integer)
        Me.optStandardNumeric.TabStop = True
        Me.optStandardNumeric.Text = resources.GetString("optStandardNumeric.Text")
        Me.optStandardNumeric.TextAlign = CType(resources.GetObject("optStandardNumeric.TextAlign"), System.Drawing.ContentAlignment)
        Me.optStandardNumeric.Visible = CType(resources.GetObject("optStandardNumeric.Visible"), Boolean)
        '
        'txtNumeric
        '
        Me.txtNumeric.AccessibleDescription = resources.GetString("txtNumeric.AccessibleDescription")
        Me.txtNumeric.AccessibleName = resources.GetString("txtNumeric.AccessibleName")
        Me.txtNumeric.Anchor = CType(resources.GetObject("txtNumeric.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtNumeric.AutoSize = CType(resources.GetObject("txtNumeric.AutoSize"), Boolean)
        Me.txtNumeric.BackgroundImage = CType(resources.GetObject("txtNumeric.BackgroundImage"), System.Drawing.Image)
        Me.txtNumeric.Dock = CType(resources.GetObject("txtNumeric.Dock"), System.Windows.Forms.DockStyle)
        Me.txtNumeric.Enabled = CType(resources.GetObject("txtNumeric.Enabled"), Boolean)
        Me.txtNumeric.Font = CType(resources.GetObject("txtNumeric.Font"), System.Drawing.Font)
        Me.txtNumeric.ImeMode = CType(resources.GetObject("txtNumeric.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtNumeric.Location = CType(resources.GetObject("txtNumeric.Location"), System.Drawing.Point)
        Me.txtNumeric.MaxLength = CType(resources.GetObject("txtNumeric.MaxLength"), Integer)
        Me.txtNumeric.Multiline = CType(resources.GetObject("txtNumeric.Multiline"), Boolean)
        Me.txtNumeric.Name = "txtNumeric"
        Me.txtNumeric.PasswordChar = CType(resources.GetObject("txtNumeric.PasswordChar"), Char)
        Me.txtNumeric.RightToLeft = CType(resources.GetObject("txtNumeric.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtNumeric.ScrollBars = CType(resources.GetObject("txtNumeric.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtNumeric.Size = CType(resources.GetObject("txtNumeric.Size"), System.Drawing.Size)
        Me.txtNumeric.TabIndex = CType(resources.GetObject("txtNumeric.TabIndex"), Integer)
        Me.txtNumeric.Text = resources.GetString("txtNumeric.Text")
        Me.txtNumeric.TextAlign = CType(resources.GetObject("txtNumeric.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtNumeric.Visible = CType(resources.GetObject("txtNumeric.Visible"), Boolean)
        Me.txtNumeric.WordWrap = CType(resources.GetObject("txtNumeric.WordWrap"), Boolean)
        '
        'pgeDateTime
        '
        Me.pgeDateTime.AccessibleDescription = resources.GetString("pgeDateTime.AccessibleDescription")
        Me.pgeDateTime.AccessibleName = resources.GetString("pgeDateTime.AccessibleName")
        Me.pgeDateTime.Anchor = CType(resources.GetObject("pgeDateTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeDateTime.AutoScroll = CType(resources.GetObject("pgeDateTime.AutoScroll"), Boolean)
        Me.pgeDateTime.AutoScrollMargin = CType(resources.GetObject("pgeDateTime.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeDateTime.AutoScrollMinSize = CType(resources.GetObject("pgeDateTime.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeDateTime.BackgroundImage = CType(resources.GetObject("pgeDateTime.BackgroundImage"), System.Drawing.Image)
        Me.pgeDateTime.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCultureInfoDateTime, Me.Label3, Me.Label2, Me.optCustomDateTime, Me.optStandardDateTime, Me.txtDateTime})
        Me.pgeDateTime.Dock = CType(resources.GetObject("pgeDateTime.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeDateTime.Enabled = CType(resources.GetObject("pgeDateTime.Enabled"), Boolean)
        Me.pgeDateTime.Font = CType(resources.GetObject("pgeDateTime.Font"), System.Drawing.Font)
        Me.pgeDateTime.ImageIndex = CType(resources.GetObject("pgeDateTime.ImageIndex"), Integer)
        Me.pgeDateTime.ImeMode = CType(resources.GetObject("pgeDateTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeDateTime.Location = CType(resources.GetObject("pgeDateTime.Location"), System.Drawing.Point)
        Me.pgeDateTime.Name = "pgeDateTime"
        Me.pgeDateTime.RightToLeft = CType(resources.GetObject("pgeDateTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeDateTime.Size = CType(resources.GetObject("pgeDateTime.Size"), System.Drawing.Size)
        Me.pgeDateTime.TabIndex = CType(resources.GetObject("pgeDateTime.TabIndex"), Integer)
        Me.pgeDateTime.Text = resources.GetString("pgeDateTime.Text")
        Me.pgeDateTime.ToolTipText = resources.GetString("pgeDateTime.ToolTipText")
        Me.pgeDateTime.Visible = CType(resources.GetObject("pgeDateTime.Visible"), Boolean)
        '
        'cboCultureInfoDateTime
        '
        Me.cboCultureInfoDateTime.AccessibleDescription = resources.GetString("cboCultureInfoDateTime.AccessibleDescription")
        Me.cboCultureInfoDateTime.AccessibleName = resources.GetString("cboCultureInfoDateTime.AccessibleName")
        Me.cboCultureInfoDateTime.Anchor = CType(resources.GetObject("cboCultureInfoDateTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboCultureInfoDateTime.BackgroundImage = CType(resources.GetObject("cboCultureInfoDateTime.BackgroundImage"), System.Drawing.Image)
        Me.cboCultureInfoDateTime.Dock = CType(resources.GetObject("cboCultureInfoDateTime.Dock"), System.Windows.Forms.DockStyle)
        Me.cboCultureInfoDateTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCultureInfoDateTime.Enabled = CType(resources.GetObject("cboCultureInfoDateTime.Enabled"), Boolean)
        Me.cboCultureInfoDateTime.Font = CType(resources.GetObject("cboCultureInfoDateTime.Font"), System.Drawing.Font)
        Me.cboCultureInfoDateTime.ImeMode = CType(resources.GetObject("cboCultureInfoDateTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboCultureInfoDateTime.IntegralHeight = CType(resources.GetObject("cboCultureInfoDateTime.IntegralHeight"), Boolean)
        Me.cboCultureInfoDateTime.ItemHeight = CType(resources.GetObject("cboCultureInfoDateTime.ItemHeight"), Integer)
        Me.cboCultureInfoDateTime.Location = CType(resources.GetObject("cboCultureInfoDateTime.Location"), System.Drawing.Point)
        Me.cboCultureInfoDateTime.MaxDropDownItems = CType(resources.GetObject("cboCultureInfoDateTime.MaxDropDownItems"), Integer)
        Me.cboCultureInfoDateTime.MaxLength = CType(resources.GetObject("cboCultureInfoDateTime.MaxLength"), Integer)
        Me.cboCultureInfoDateTime.Name = "cboCultureInfoDateTime"
        Me.cboCultureInfoDateTime.RightToLeft = CType(resources.GetObject("cboCultureInfoDateTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboCultureInfoDateTime.Size = CType(resources.GetObject("cboCultureInfoDateTime.Size"), System.Drawing.Size)
        Me.cboCultureInfoDateTime.TabIndex = CType(resources.GetObject("cboCultureInfoDateTime.TabIndex"), Integer)
        Me.cboCultureInfoDateTime.Text = resources.GetString("cboCultureInfoDateTime.Text")
        Me.cboCultureInfoDateTime.Visible = CType(resources.GetObject("cboCultureInfoDateTime.Visible"), Boolean)
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = CType(resources.GetObject("Label3.AccessibleDescription"), String)
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
        'optCustomDateTime
        '
        Me.optCustomDateTime.AccessibleDescription = resources.GetString("optCustomDateTime.AccessibleDescription")
        Me.optCustomDateTime.AccessibleName = resources.GetString("optCustomDateTime.AccessibleName")
        Me.optCustomDateTime.Anchor = CType(resources.GetObject("optCustomDateTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optCustomDateTime.Appearance = CType(resources.GetObject("optCustomDateTime.Appearance"), System.Windows.Forms.Appearance)
        Me.optCustomDateTime.BackgroundImage = CType(resources.GetObject("optCustomDateTime.BackgroundImage"), System.Drawing.Image)
        Me.optCustomDateTime.CheckAlign = CType(resources.GetObject("optCustomDateTime.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optCustomDateTime.Dock = CType(resources.GetObject("optCustomDateTime.Dock"), System.Windows.Forms.DockStyle)
        Me.optCustomDateTime.Enabled = CType(resources.GetObject("optCustomDateTime.Enabled"), Boolean)
        Me.optCustomDateTime.FlatStyle = CType(resources.GetObject("optCustomDateTime.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optCustomDateTime.Font = CType(resources.GetObject("optCustomDateTime.Font"), System.Drawing.Font)
        Me.optCustomDateTime.Image = CType(resources.GetObject("optCustomDateTime.Image"), System.Drawing.Image)
        Me.optCustomDateTime.ImageAlign = CType(resources.GetObject("optCustomDateTime.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optCustomDateTime.ImageIndex = CType(resources.GetObject("optCustomDateTime.ImageIndex"), Integer)
        Me.optCustomDateTime.ImeMode = CType(resources.GetObject("optCustomDateTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optCustomDateTime.Location = CType(resources.GetObject("optCustomDateTime.Location"), System.Drawing.Point)
        Me.optCustomDateTime.Name = "optCustomDateTime"
        Me.optCustomDateTime.RightToLeft = CType(resources.GetObject("optCustomDateTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optCustomDateTime.Size = CType(resources.GetObject("optCustomDateTime.Size"), System.Drawing.Size)
        Me.optCustomDateTime.TabIndex = CType(resources.GetObject("optCustomDateTime.TabIndex"), Integer)
        Me.optCustomDateTime.Text = resources.GetString("optCustomDateTime.Text")
        Me.optCustomDateTime.TextAlign = CType(resources.GetObject("optCustomDateTime.TextAlign"), System.Drawing.ContentAlignment)
        Me.optCustomDateTime.Visible = CType(resources.GetObject("optCustomDateTime.Visible"), Boolean)
        '
        'optStandardDateTime
        '
        Me.optStandardDateTime.AccessibleDescription = resources.GetString("optStandardDateTime.AccessibleDescription")
        Me.optStandardDateTime.AccessibleName = resources.GetString("optStandardDateTime.AccessibleName")
        Me.optStandardDateTime.Anchor = CType(resources.GetObject("optStandardDateTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optStandardDateTime.Appearance = CType(resources.GetObject("optStandardDateTime.Appearance"), System.Windows.Forms.Appearance)
        Me.optStandardDateTime.BackgroundImage = CType(resources.GetObject("optStandardDateTime.BackgroundImage"), System.Drawing.Image)
        Me.optStandardDateTime.CheckAlign = CType(resources.GetObject("optStandardDateTime.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optStandardDateTime.Checked = True
        Me.optStandardDateTime.Dock = CType(resources.GetObject("optStandardDateTime.Dock"), System.Windows.Forms.DockStyle)
        Me.optStandardDateTime.Enabled = CType(resources.GetObject("optStandardDateTime.Enabled"), Boolean)
        Me.optStandardDateTime.FlatStyle = CType(resources.GetObject("optStandardDateTime.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optStandardDateTime.Font = CType(resources.GetObject("optStandardDateTime.Font"), System.Drawing.Font)
        Me.optStandardDateTime.Image = CType(resources.GetObject("optStandardDateTime.Image"), System.Drawing.Image)
        Me.optStandardDateTime.ImageAlign = CType(resources.GetObject("optStandardDateTime.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optStandardDateTime.ImageIndex = CType(resources.GetObject("optStandardDateTime.ImageIndex"), Integer)
        Me.optStandardDateTime.ImeMode = CType(resources.GetObject("optStandardDateTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optStandardDateTime.Location = CType(resources.GetObject("optStandardDateTime.Location"), System.Drawing.Point)
        Me.optStandardDateTime.Name = "optStandardDateTime"
        Me.optStandardDateTime.RightToLeft = CType(resources.GetObject("optStandardDateTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optStandardDateTime.Size = CType(resources.GetObject("optStandardDateTime.Size"), System.Drawing.Size)
        Me.optStandardDateTime.TabIndex = CType(resources.GetObject("optStandardDateTime.TabIndex"), Integer)
        Me.optStandardDateTime.TabStop = True
        Me.optStandardDateTime.Text = resources.GetString("optStandardDateTime.Text")
        Me.optStandardDateTime.TextAlign = CType(resources.GetObject("optStandardDateTime.TextAlign"), System.Drawing.ContentAlignment)
        Me.optStandardDateTime.Visible = CType(resources.GetObject("optStandardDateTime.Visible"), Boolean)
        '
        'txtDateTime
        '
        Me.txtDateTime.AccessibleDescription = resources.GetString("txtDateTime.AccessibleDescription")
        Me.txtDateTime.AccessibleName = resources.GetString("txtDateTime.AccessibleName")
        Me.txtDateTime.Anchor = CType(resources.GetObject("txtDateTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtDateTime.AutoSize = CType(resources.GetObject("txtDateTime.AutoSize"), Boolean)
        Me.txtDateTime.BackgroundImage = CType(resources.GetObject("txtDateTime.BackgroundImage"), System.Drawing.Image)
        Me.txtDateTime.Dock = CType(resources.GetObject("txtDateTime.Dock"), System.Windows.Forms.DockStyle)
        Me.txtDateTime.Enabled = CType(resources.GetObject("txtDateTime.Enabled"), Boolean)
        Me.txtDateTime.Font = CType(resources.GetObject("txtDateTime.Font"), System.Drawing.Font)
        Me.txtDateTime.ImeMode = CType(resources.GetObject("txtDateTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtDateTime.Location = CType(resources.GetObject("txtDateTime.Location"), System.Drawing.Point)
        Me.txtDateTime.MaxLength = CType(resources.GetObject("txtDateTime.MaxLength"), Integer)
        Me.txtDateTime.Multiline = CType(resources.GetObject("txtDateTime.Multiline"), Boolean)
        Me.txtDateTime.Name = "txtDateTime"
        Me.txtDateTime.PasswordChar = CType(resources.GetObject("txtDateTime.PasswordChar"), Char)
        Me.txtDateTime.RightToLeft = CType(resources.GetObject("txtDateTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtDateTime.ScrollBars = CType(resources.GetObject("txtDateTime.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtDateTime.Size = CType(resources.GetObject("txtDateTime.Size"), System.Drawing.Size)
        Me.txtDateTime.TabIndex = CType(resources.GetObject("txtDateTime.TabIndex"), Integer)
        Me.txtDateTime.Text = resources.GetString("txtDateTime.Text")
        Me.txtDateTime.TextAlign = CType(resources.GetObject("txtDateTime.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtDateTime.Visible = CType(resources.GetObject("txtDateTime.Visible"), Boolean)
        Me.txtDateTime.WordWrap = CType(resources.GetObject("txtDateTime.WordWrap"), Boolean)
        '
        'pgeEnum
        '
        Me.pgeEnum.AccessibleDescription = resources.GetString("pgeEnum.AccessibleDescription")
        Me.pgeEnum.AccessibleName = resources.GetString("pgeEnum.AccessibleName")
        Me.pgeEnum.Anchor = CType(resources.GetObject("pgeEnum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeEnum.AutoScroll = CType(resources.GetObject("pgeEnum.AutoScroll"), Boolean)
        Me.pgeEnum.AutoScrollMargin = CType(resources.GetObject("pgeEnum.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeEnum.AutoScrollMinSize = CType(resources.GetObject("pgeEnum.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeEnum.BackgroundImage = CType(resources.GetObject("pgeEnum.BackgroundImage"), System.Drawing.Image)
        Me.pgeEnum.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.txtEnum})
        Me.pgeEnum.Dock = CType(resources.GetObject("pgeEnum.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeEnum.Enabled = CType(resources.GetObject("pgeEnum.Enabled"), Boolean)
        Me.pgeEnum.Font = CType(resources.GetObject("pgeEnum.Font"), System.Drawing.Font)
        Me.pgeEnum.ImageIndex = CType(resources.GetObject("pgeEnum.ImageIndex"), Integer)
        Me.pgeEnum.ImeMode = CType(resources.GetObject("pgeEnum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeEnum.Location = CType(resources.GetObject("pgeEnum.Location"), System.Drawing.Point)
        Me.pgeEnum.Name = "pgeEnum"
        Me.pgeEnum.RightToLeft = CType(resources.GetObject("pgeEnum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeEnum.Size = CType(resources.GetObject("pgeEnum.Size"), System.Drawing.Size)
        Me.pgeEnum.TabIndex = CType(resources.GetObject("pgeEnum.TabIndex"), Integer)
        Me.pgeEnum.Text = resources.GetString("pgeEnum.Text")
        Me.pgeEnum.ToolTipText = resources.GetString("pgeEnum.ToolTipText")
        Me.pgeEnum.Visible = CType(resources.GetObject("pgeEnum.Visible"), Boolean)
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = resources.GetString("Label5.AccessibleDescription")
        Me.Label5.AccessibleName = resources.GetString("Label5.AccessibleName")
        Me.Label5.Anchor = CType(resources.GetObject("Label5.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = CType(resources.GetObject("Label5.AutoSize"), Boolean)
        Me.Label5.Dock = CType(resources.GetObject("Label5.Dock"), System.Windows.Forms.DockStyle)
        Me.Label5.Enabled = CType(resources.GetObject("Label5.Enabled"), Boolean)
        Me.Label5.Font = CType(resources.GetObject("Label5.Font"), System.Drawing.Font)
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = CType(resources.GetObject("Label5.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label5.ImageIndex = CType(resources.GetObject("Label5.ImageIndex"), Integer)
        Me.Label5.ImeMode = CType(resources.GetObject("Label5.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label5.Location = CType(resources.GetObject("Label5.Location"), System.Drawing.Point)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = CType(resources.GetObject("Label5.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label5.Size = CType(resources.GetObject("Label5.Size"), System.Drawing.Size)
        Me.Label5.TabIndex = CType(resources.GetObject("Label5.TabIndex"), Integer)
        Me.Label5.Text = resources.GetString("Label5.Text")
        Me.Label5.TextAlign = CType(resources.GetObject("Label5.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label5.Visible = CType(resources.GetObject("Label5.Visible"), Boolean)
        '
        'txtEnum
        '
        Me.txtEnum.AccessibleDescription = resources.GetString("txtEnum.AccessibleDescription")
        Me.txtEnum.AccessibleName = resources.GetString("txtEnum.AccessibleName")
        Me.txtEnum.Anchor = CType(resources.GetObject("txtEnum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtEnum.AutoSize = CType(resources.GetObject("txtEnum.AutoSize"), Boolean)
        Me.txtEnum.BackgroundImage = CType(resources.GetObject("txtEnum.BackgroundImage"), System.Drawing.Image)
        Me.txtEnum.Dock = CType(resources.GetObject("txtEnum.Dock"), System.Windows.Forms.DockStyle)
        Me.txtEnum.Enabled = CType(resources.GetObject("txtEnum.Enabled"), Boolean)
        Me.txtEnum.Font = CType(resources.GetObject("txtEnum.Font"), System.Drawing.Font)
        Me.txtEnum.ImeMode = CType(resources.GetObject("txtEnum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtEnum.Location = CType(resources.GetObject("txtEnum.Location"), System.Drawing.Point)
        Me.txtEnum.MaxLength = CType(resources.GetObject("txtEnum.MaxLength"), Integer)
        Me.txtEnum.Multiline = CType(resources.GetObject("txtEnum.Multiline"), Boolean)
        Me.txtEnum.Name = "txtEnum"
        Me.txtEnum.PasswordChar = CType(resources.GetObject("txtEnum.PasswordChar"), Char)
        Me.txtEnum.RightToLeft = CType(resources.GetObject("txtEnum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtEnum.ScrollBars = CType(resources.GetObject("txtEnum.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtEnum.Size = CType(resources.GetObject("txtEnum.Size"), System.Drawing.Size)
        Me.txtEnum.TabIndex = CType(resources.GetObject("txtEnum.TabIndex"), Integer)
        Me.txtEnum.Text = resources.GetString("txtEnum.Text")
        Me.txtEnum.TextAlign = CType(resources.GetObject("txtEnum.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtEnum.Visible = CType(resources.GetObject("txtEnum.Visible"), Boolean)
        Me.txtEnum.WordWrap = CType(resources.GetObject("txtEnum.WordWrap"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabExamples})
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
        Me.tabExamples.ResumeLayout(False)
        Me.pgeNumeric.ResumeLayout(False)
        Me.pgeDateTime.ResumeLayout(False)
        Me.pgeEnum.ResumeLayout(False)
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

    ' The Culture class is a custom type that is used for databinding to a ComboBox.
    ' Notice the use of public properties instead of merely public fields. You might
    ' think you could use the following construct:
    '
    '   Public Class Culture
    '       Public ID As String
    '       Public Description As String

    '       Sub New(ByVal strID As String, ByVal strDesc As String)
    '           ID = strID
    '           Description = strDesc
    '       End Sub
    '   End Class
    '
    ' This will, however, throw a runtime InvalidArgumentException stating that it 
    ' cannot bind to the new DisplayMember. The Property does not have to be 
    ' ReadOnly.
    Public Class Culture
        Private _ID As String
        Private _desc As String

        Sub New(ByVal strDesc As String, ByVal strID As String)
            _ID = strID
            _desc = strDesc
        End Sub

        Public ReadOnly Property ID() As String
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property Description() As String
            Get
                Return _desc
            End Get
        End Property
    End Class

    Private crlf As String = ControlChars.CrLf
    Private FormHasLoaded As Boolean = False
    Private strCultureValue As String
    Private tab As String = ControlChars.Tab

    ' Calls the method to display the DateTime formatting examples based on a 
    ' user-selected CultureInfo.
    Private Sub cboCultureInfoDateTime_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCultureInfoDateTime.SelectedIndexChanged
        ' Handler should work only if the Form has loaded as SelectedValueChanged 
        ' fires during databinding and causes undesirable results.
        If FormHasLoaded Then
            LoadDateTimeFormats()
        End If
    End Sub

    ' Calls the method to display the Numeric formatting examples based on a 
    ' user-selected CultureInfo.
    Private Sub cboCultureInfoNumeric_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCultureInfoNumeric.SelectedIndexChanged
        ' Handler should work only if the Form has loaded as SelectedValueChanged 
        ' fires during databinding and causes undesirable results.
        If FormHasLoaded Then
            LoadNumericFormats()
        End If
    End Sub

    ' Loads the ComboBox controls from an ArrayList and calls the methods to display 
    ' the various formatting examples.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Databind the ComboBox controls to an ArrayList of custom objects. Refer to
        ' the comments about the Culture class for more information.
        Dim arlCultureInfo As New ArrayList()
        With arlCultureInfo
            .Add(New Culture("English - United States", "en-US"))
            .Add(New Culture("English - United Kingdom", "en-GB"))
            .Add(New Culture("English - New Zealand", "en-NZ"))
            .Add(New Culture("German - Germany", "de-DE"))
            .Add(New Culture("Spanish - Spain", "es-ES"))
            .Add(New Culture("French - France", "fr-FR"))
            .Add(New Culture("Portuguese - Brazil", "pt-BR"))
            .Add(New Culture("Malay - Malaysia", "ms-MY"))
            .Add(New Culture("Afrikaans - South Africa", "af-ZA"))
        End With

        cboCultureInfoDateTime.DataSource = arlCultureInfo
        cboCultureInfoDateTime.DisplayMember = "Description"
        cboCultureInfoDateTime.ValueMember = "ID"

        cboCultureInfoNumeric.DataSource = arlCultureInfo
        cboCultureInfoNumeric.DisplayMember = "Description"
        cboCultureInfoNumeric.ValueMember = "ID"

        LoadEnumFormats()
        LoadDateTimeFormats()
        LoadNumericFormats()

        FormHasLoaded = True
    End Sub

    ' Calls the methods to display the formatting examples based on whether
    ' the user selects "standard" or "custom" formatting.
    Private Sub RadioButtons_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optStandardNumeric.CheckedChanged, optCustomNumeric.CheckedChanged, optCustomDateTime.CheckedChanged, optStandardDateTime.CheckedChanged
        ' Handler should work only if the Form has loaded as SelectedValueChanged 
        ' fires during databinding and causes undesirable results.
        If FormHasLoaded Then
            Dim opt As RadioButton = CType(sender, RadioButton)
            Select Case opt.Name
                Case "optStandardNumeric", "optCustomNumeric"
                    LoadNumericFormats()
                Case "optStandardDateTime", "optCustomDateTime"
                    LoadDateTimeFormats()
                Case Else
                    LoadEnumFormats()
            End Select
        End If
    End Sub

    ' Displays the DateTime formatting examples.
    Private Sub LoadDateTimeFormats()
        Dim dtmNow As DateTime = Now
        Dim sb As New StringBuilder()
        strCultureValue = cboCultureInfoDateTime.SelectedValue.ToString
        Thread.CurrentThread.CurrentCulture = New CultureInfo(strCultureValue)

        sb.Append("When using " & strCultureValue & " CultureInfo, today's date and time will format as follows:")
        sb.Append(crlf)
        sb.Append(crlf)

        If optStandardDateTime.Checked Then

            With sb
                .Append(dtmNow.ToString("d"))
                .Append(" [Short date pattern]")
                .Append(crlf)
                .Append(dtmNow.ToString("D"))
                .Append(" [Long date pattern]")
                .Append(crlf)
                .Append(dtmNow.ToString("t"))
                .Append(" [Short time pattern]")
                .Append(crlf)
                .Append(dtmNow.ToString("T"))
                .Append(" [Long time pattern]")
                .Append(crlf)
                .Append(dtmNow.ToString("F"))
                .Append(" [Full date/time pattern (long)]")
                .Append(crlf)
                .Append(dtmNow.ToString("f"))
                .Append(" [Full date/time pattern (short)]")
                .Append(crlf)
                .Append(dtmNow.ToString("G"))
                .Append(" [General date/time pattern (long)]")
                .Append(crlf)
                .Append(dtmNow.ToString("g"))
                .Append(" [General date/time pattern (short)]")
                .Append(crlf)
                .Append(dtmNow.ToString("M"))
                .Append(" [Month day pattern]")
                .Append(crlf)
                .Append(dtmNow.ToString("R"))
                .Append(" [RFC1123 pattern]")
                .Append(crlf)
                .Append(dtmNow.ToString("s"))
                .Append(" [Sortable date/time pattern]")
                .Append(crlf)
                .Append(dtmNow.ToString("u"))
                .Append(" [Universable sortable date/time pattern]")
                .Append(crlf)
                .Append(dtmNow.ToString("y"))
                .Append(" [Year month pattern]")
                .Append(crlf)
                .Append(crlf)
            End With

        ElseIf optCustomDateTime.Checked Then
            With sb
                .Append(dtmNow.ToString("d, M"))
                .Append(" [d, M]")
                .Append(crlf)
                .Append(dtmNow.ToString("d MMMM"))
                .Append(" [d MMMM]")
                .Append(crlf)
                .Append(dtmNow.ToString("dddd MMMM yy gg"))
                .Append(" [dddd MMMM yy gg]")
                .Append(crlf)
                .Append(dtmNow.ToString("h , m: s"))
                .Append(" [h , m: s]")
                .Append(crlf)
                .Append(dtmNow.ToString("hh,mm:ss"))
                .Append(" [hh,mm:ss]")
                .Append(crlf)
                .Append(dtmNow.ToString("HH-mm-ss-tt"))
                .Append(" [HH-mm-ss-tt]")
                .Append(crlf)
                .Append(dtmNow.ToString("hh:mm, G\MT z"))
                .Append(" [hh:mm, G\MT z]")
                .Append(crlf)
                .Append(dtmNow.ToString("hh:mm, G\MT zzz"))
                .Append(" [hh:mm, G\MT zzz]")
            End With
        End If

        txtDateTime.Text = sb.ToString
    End Sub

    ' Displays the Enum formatting examples.
    Private Sub LoadEnumFormats()
        Dim day As DayOfWeek = DayOfWeek.Friday
        Dim sb As New StringBuilder()
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")

        With sb
            .Append("When using any CultureInfo, the system enumeration DayOfWeek.Friday will format as follows:")
            .Append(crlf)
            .Append(crlf)
            .Append(day.ToString("G"))
            .Append(" [G or g]")
            .Append(crlf)
            .Append(day.ToString("F"))
            .Append(" [F or f]")
            .Append(crlf)
            .Append(day.ToString("D"))
            .Append(" [D or d]")
            .Append(crlf)
            .Append(day.ToString("X"))
            .Append(" [X or x]")
        End With

        txtEnum.Text = sb.ToString
    End Sub

    ' Displays the Numeric formatting examples.
    Private Sub LoadNumericFormats()
        Dim intNumber As Int32 = 1234567890
        Dim sb As New StringBuilder()
        strCultureValue = cboCultureInfoNumeric.SelectedValue.ToString
        Thread.CurrentThread.CurrentCulture = New CultureInfo(strCultureValue)

        sb.Append("When using " & strCultureValue & " CultureInfo, the Integer 1234567890 will format as follows:")
        sb.Append(crlf)
        sb.Append(crlf)

        If optStandardNumeric.Checked Then

            With sb
                .Append(intNumber.ToString("C"))
                .Append(" [Currency]")
                .Append(crlf)
                .Append(intNumber.ToString("E"))
                .Append(" [Scientific (Exponential)]")
                .Append(crlf)
                .Append(intNumber.ToString("P"))
                .Append(" [Percent]")
                .Append(crlf)
                .Append(intNumber.ToString("N"))
                .Append(" [Number]")
                .Append(crlf)
                .Append(intNumber.ToString("F"))
                .Append(" [Fixed-point]")
                .Append(crlf)
                .Append(intNumber.ToString("X"))
                .Append(" [Hexadecimal]")
                .Append(crlf)
                .Append(crlf)
            End With

        ElseIf optCustomNumeric.Checked Then
            With sb
                .Append(intNumber.ToString("#####"))
                .Append(" [#####]")
                .Append(crlf)
                .Append(intNumber.ToString("00000"))
                .Append(" [00000]")
                .Append(crlf)
                .Append(intNumber.ToString("(###) ### - ####"))
                .Append(" [(###) ### - ####]")
                .Append(crlf)
                .Append(intNumber.ToString("#.##"))
                .Append(" [#.##]")
                .Append(crlf)
                .Append(intNumber.ToString("00.00"))
                .Append(" [00.00]")
                .Append(crlf)
                .Append(intNumber.ToString("#,#"))
                .Append(" [#,#]")
                .Append(crlf)
                .Append(intNumber.ToString("#,,"))
                .Append(" [#,,]")
                .Append(crlf)
                .Append(intNumber.ToString("#.##"))
                .Append(" [#.##]")
                .Append(crlf)
                .Append(intNumber.ToString("#,,,"))
                .Append(" [#,,,]")
                .Append(crlf)
                .Append(intNumber.ToString("#,##0,,"))
                .Append(" [#,##0,,]")
                .Append(crlf)
                .Append(intNumber.ToString("#0.##%"))
                .Append(" [#0.##%]")
                .Append(crlf)
                .Append(intNumber.ToString("0.###E+000"))
                .Append(" [0.###E+000]")
                .Append(crlf)
                .Append(intNumber.ToString("##;(##)"))
                .Append(" [##;(##)]")
                .Append(crlf)
            End With
        End If

        txtNumeric.Text = sb.ToString
    End Sub
End Class