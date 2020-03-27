'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' Import the System.Diagnostics namespace to reduce typing.
Imports System.Diagnostics

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private m_Counter As PerformanceCounter

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
    Friend WithEvents tmrUpdateUI As System.Windows.Forms.Timer
    Friend WithEvents cboCounters As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelectTimer As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCategories As System.Windows.Forms.ComboBox
    Friend WithEvents txtCounterValue As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCounterType As System.Windows.Forms.TextBox
    Friend WithEvents lblCounterType As System.Windows.Forms.Label
    Friend WithEvents txtCounterHelp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblBuiltInOrCustom As System.Windows.Forms.Label
    Friend WithEvents txtBuiltInOrCustom As System.Windows.Forms.TextBox
    Friend WithEvents btnIncrementCounter As System.Windows.Forms.Button
    Friend WithEvents btnDecrementCounter As System.Windows.Forms.Button
    Friend WithEvents sbrStatus As System.Windows.Forms.StatusBar
    Friend WithEvents lblAddingACustomControl As System.Windows.Forms.Label
    Friend WithEvents btnRefreshCategories As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tmrUpdateUI = New System.Windows.Forms.Timer(Me.components)
        Me.cboCounters = New System.Windows.Forms.ComboBox()
        Me.lblSelectTimer = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCategories = New System.Windows.Forms.ComboBox()
        Me.txtCounterValue = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCounterType = New System.Windows.Forms.TextBox()
        Me.lblCounterType = New System.Windows.Forms.Label()
        Me.txtCounterHelp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBuiltInOrCustom = New System.Windows.Forms.Label()
        Me.txtBuiltInOrCustom = New System.Windows.Forms.TextBox()
        Me.btnIncrementCounter = New System.Windows.Forms.Button()
        Me.btnDecrementCounter = New System.Windows.Forms.Button()
        Me.sbrStatus = New System.Windows.Forms.StatusBar()
        Me.lblAddingACustomControl = New System.Windows.Forms.Label()
        Me.btnRefreshCategories = New System.Windows.Forms.Button()
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
        'tmrUpdateUI
        '
        '
        'cboCounters
        '
        Me.cboCounters.AccessibleDescription = resources.GetString("cboCounters.AccessibleDescription")
        Me.cboCounters.AccessibleName = resources.GetString("cboCounters.AccessibleName")
        Me.cboCounters.Anchor = CType(resources.GetObject("cboCounters.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboCounters.BackgroundImage = CType(resources.GetObject("cboCounters.BackgroundImage"), System.Drawing.Image)
        Me.cboCounters.Dock = CType(resources.GetObject("cboCounters.Dock"), System.Windows.Forms.DockStyle)
        Me.cboCounters.Enabled = CType(resources.GetObject("cboCounters.Enabled"), Boolean)
        Me.cboCounters.Font = CType(resources.GetObject("cboCounters.Font"), System.Drawing.Font)
        Me.cboCounters.ImeMode = CType(resources.GetObject("cboCounters.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboCounters.IntegralHeight = CType(resources.GetObject("cboCounters.IntegralHeight"), Boolean)
        Me.cboCounters.ItemHeight = CType(resources.GetObject("cboCounters.ItemHeight"), Integer)
        Me.cboCounters.Location = CType(resources.GetObject("cboCounters.Location"), System.Drawing.Point)
        Me.cboCounters.MaxDropDownItems = CType(resources.GetObject("cboCounters.MaxDropDownItems"), Integer)
        Me.cboCounters.MaxLength = CType(resources.GetObject("cboCounters.MaxLength"), Integer)
        Me.cboCounters.Name = "cboCounters"
        Me.cboCounters.RightToLeft = CType(resources.GetObject("cboCounters.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboCounters.Size = CType(resources.GetObject("cboCounters.Size"), System.Drawing.Size)
        Me.cboCounters.TabIndex = CType(resources.GetObject("cboCounters.TabIndex"), Integer)
        Me.cboCounters.Text = resources.GetString("cboCounters.Text")
        Me.cboCounters.Visible = CType(resources.GetObject("cboCounters.Visible"), Boolean)
        '
        'lblSelectTimer
        '
        Me.lblSelectTimer.AccessibleDescription = resources.GetString("lblSelectTimer.AccessibleDescription")
        Me.lblSelectTimer.AccessibleName = resources.GetString("lblSelectTimer.AccessibleName")
        Me.lblSelectTimer.Anchor = CType(resources.GetObject("lblSelectTimer.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblSelectTimer.AutoSize = CType(resources.GetObject("lblSelectTimer.AutoSize"), Boolean)
        Me.lblSelectTimer.Dock = CType(resources.GetObject("lblSelectTimer.Dock"), System.Windows.Forms.DockStyle)
        Me.lblSelectTimer.Enabled = CType(resources.GetObject("lblSelectTimer.Enabled"), Boolean)
        Me.lblSelectTimer.Font = CType(resources.GetObject("lblSelectTimer.Font"), System.Drawing.Font)
        Me.lblSelectTimer.Image = CType(resources.GetObject("lblSelectTimer.Image"), System.Drawing.Image)
        Me.lblSelectTimer.ImageAlign = CType(resources.GetObject("lblSelectTimer.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblSelectTimer.ImageIndex = CType(resources.GetObject("lblSelectTimer.ImageIndex"), Integer)
        Me.lblSelectTimer.ImeMode = CType(resources.GetObject("lblSelectTimer.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblSelectTimer.Location = CType(resources.GetObject("lblSelectTimer.Location"), System.Drawing.Point)
        Me.lblSelectTimer.Name = "lblSelectTimer"
        Me.lblSelectTimer.RightToLeft = CType(resources.GetObject("lblSelectTimer.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblSelectTimer.Size = CType(resources.GetObject("lblSelectTimer.Size"), System.Drawing.Size)
        Me.lblSelectTimer.TabIndex = CType(resources.GetObject("lblSelectTimer.TabIndex"), Integer)
        Me.lblSelectTimer.Text = resources.GetString("lblSelectTimer.Text")
        Me.lblSelectTimer.TextAlign = CType(resources.GetObject("lblSelectTimer.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblSelectTimer.Visible = CType(resources.GetObject("lblSelectTimer.Visible"), Boolean)
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
        'cboCategories
        '
        Me.cboCategories.AccessibleDescription = resources.GetString("cboCategories.AccessibleDescription")
        Me.cboCategories.AccessibleName = resources.GetString("cboCategories.AccessibleName")
        Me.cboCategories.Anchor = CType(resources.GetObject("cboCategories.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboCategories.BackgroundImage = CType(resources.GetObject("cboCategories.BackgroundImage"), System.Drawing.Image)
        Me.cboCategories.Dock = CType(resources.GetObject("cboCategories.Dock"), System.Windows.Forms.DockStyle)
        Me.cboCategories.Enabled = CType(resources.GetObject("cboCategories.Enabled"), Boolean)
        Me.cboCategories.Font = CType(resources.GetObject("cboCategories.Font"), System.Drawing.Font)
        Me.cboCategories.ImeMode = CType(resources.GetObject("cboCategories.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboCategories.IntegralHeight = CType(resources.GetObject("cboCategories.IntegralHeight"), Boolean)
        Me.cboCategories.ItemHeight = CType(resources.GetObject("cboCategories.ItemHeight"), Integer)
        Me.cboCategories.Location = CType(resources.GetObject("cboCategories.Location"), System.Drawing.Point)
        Me.cboCategories.MaxDropDownItems = CType(resources.GetObject("cboCategories.MaxDropDownItems"), Integer)
        Me.cboCategories.MaxLength = CType(resources.GetObject("cboCategories.MaxLength"), Integer)
        Me.cboCategories.Name = "cboCategories"
        Me.cboCategories.RightToLeft = CType(resources.GetObject("cboCategories.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboCategories.Size = CType(resources.GetObject("cboCategories.Size"), System.Drawing.Size)
        Me.cboCategories.TabIndex = CType(resources.GetObject("cboCategories.TabIndex"), Integer)
        Me.cboCategories.Text = resources.GetString("cboCategories.Text")
        Me.cboCategories.Visible = CType(resources.GetObject("cboCategories.Visible"), Boolean)
        '
        'txtCounterValue
        '
        Me.txtCounterValue.AccessibleDescription = resources.GetString("txtCounterValue.AccessibleDescription")
        Me.txtCounterValue.AccessibleName = resources.GetString("txtCounterValue.AccessibleName")
        Me.txtCounterValue.Anchor = CType(resources.GetObject("txtCounterValue.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCounterValue.AutoSize = CType(resources.GetObject("txtCounterValue.AutoSize"), Boolean)
        Me.txtCounterValue.BackgroundImage = CType(resources.GetObject("txtCounterValue.BackgroundImage"), System.Drawing.Image)
        Me.txtCounterValue.Dock = CType(resources.GetObject("txtCounterValue.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCounterValue.Enabled = CType(resources.GetObject("txtCounterValue.Enabled"), Boolean)
        Me.txtCounterValue.Font = CType(resources.GetObject("txtCounterValue.Font"), System.Drawing.Font)
        Me.txtCounterValue.ImeMode = CType(resources.GetObject("txtCounterValue.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCounterValue.Location = CType(resources.GetObject("txtCounterValue.Location"), System.Drawing.Point)
        Me.txtCounterValue.MaxLength = CType(resources.GetObject("txtCounterValue.MaxLength"), Integer)
        Me.txtCounterValue.Multiline = CType(resources.GetObject("txtCounterValue.Multiline"), Boolean)
        Me.txtCounterValue.Name = "txtCounterValue"
        Me.txtCounterValue.PasswordChar = CType(resources.GetObject("txtCounterValue.PasswordChar"), Char)
        Me.txtCounterValue.RightToLeft = CType(resources.GetObject("txtCounterValue.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCounterValue.ScrollBars = CType(resources.GetObject("txtCounterValue.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCounterValue.Size = CType(resources.GetObject("txtCounterValue.Size"), System.Drawing.Size)
        Me.txtCounterValue.TabIndex = CType(resources.GetObject("txtCounterValue.TabIndex"), Integer)
        Me.txtCounterValue.TabStop = False
        Me.txtCounterValue.Text = resources.GetString("txtCounterValue.Text")
        Me.txtCounterValue.TextAlign = CType(resources.GetObject("txtCounterValue.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCounterValue.Visible = CType(resources.GetObject("txtCounterValue.Visible"), Boolean)
        Me.txtCounterValue.WordWrap = CType(resources.GetObject("txtCounterValue.WordWrap"), Boolean)
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
        'txtCounterType
        '
        Me.txtCounterType.AccessibleDescription = resources.GetString("txtCounterType.AccessibleDescription")
        Me.txtCounterType.AccessibleName = resources.GetString("txtCounterType.AccessibleName")
        Me.txtCounterType.Anchor = CType(resources.GetObject("txtCounterType.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCounterType.AutoSize = CType(resources.GetObject("txtCounterType.AutoSize"), Boolean)
        Me.txtCounterType.BackgroundImage = CType(resources.GetObject("txtCounterType.BackgroundImage"), System.Drawing.Image)
        Me.txtCounterType.Dock = CType(resources.GetObject("txtCounterType.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCounterType.Enabled = CType(resources.GetObject("txtCounterType.Enabled"), Boolean)
        Me.txtCounterType.Font = CType(resources.GetObject("txtCounterType.Font"), System.Drawing.Font)
        Me.txtCounterType.ImeMode = CType(resources.GetObject("txtCounterType.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCounterType.Location = CType(resources.GetObject("txtCounterType.Location"), System.Drawing.Point)
        Me.txtCounterType.MaxLength = CType(resources.GetObject("txtCounterType.MaxLength"), Integer)
        Me.txtCounterType.Multiline = CType(resources.GetObject("txtCounterType.Multiline"), Boolean)
        Me.txtCounterType.Name = "txtCounterType"
        Me.txtCounterType.PasswordChar = CType(resources.GetObject("txtCounterType.PasswordChar"), Char)
        Me.txtCounterType.RightToLeft = CType(resources.GetObject("txtCounterType.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCounterType.ScrollBars = CType(resources.GetObject("txtCounterType.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCounterType.Size = CType(resources.GetObject("txtCounterType.Size"), System.Drawing.Size)
        Me.txtCounterType.TabIndex = CType(resources.GetObject("txtCounterType.TabIndex"), Integer)
        Me.txtCounterType.TabStop = False
        Me.txtCounterType.Text = resources.GetString("txtCounterType.Text")
        Me.txtCounterType.TextAlign = CType(resources.GetObject("txtCounterType.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCounterType.Visible = CType(resources.GetObject("txtCounterType.Visible"), Boolean)
        Me.txtCounterType.WordWrap = CType(resources.GetObject("txtCounterType.WordWrap"), Boolean)
        '
        'lblCounterType
        '
        Me.lblCounterType.AccessibleDescription = resources.GetString("lblCounterType.AccessibleDescription")
        Me.lblCounterType.AccessibleName = resources.GetString("lblCounterType.AccessibleName")
        Me.lblCounterType.Anchor = CType(resources.GetObject("lblCounterType.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblCounterType.AutoSize = CType(resources.GetObject("lblCounterType.AutoSize"), Boolean)
        Me.lblCounterType.Dock = CType(resources.GetObject("lblCounterType.Dock"), System.Windows.Forms.DockStyle)
        Me.lblCounterType.Enabled = CType(resources.GetObject("lblCounterType.Enabled"), Boolean)
        Me.lblCounterType.Font = CType(resources.GetObject("lblCounterType.Font"), System.Drawing.Font)
        Me.lblCounterType.Image = CType(resources.GetObject("lblCounterType.Image"), System.Drawing.Image)
        Me.lblCounterType.ImageAlign = CType(resources.GetObject("lblCounterType.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblCounterType.ImageIndex = CType(resources.GetObject("lblCounterType.ImageIndex"), Integer)
        Me.lblCounterType.ImeMode = CType(resources.GetObject("lblCounterType.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblCounterType.Location = CType(resources.GetObject("lblCounterType.Location"), System.Drawing.Point)
        Me.lblCounterType.Name = "lblCounterType"
        Me.lblCounterType.RightToLeft = CType(resources.GetObject("lblCounterType.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblCounterType.Size = CType(resources.GetObject("lblCounterType.Size"), System.Drawing.Size)
        Me.lblCounterType.TabIndex = CType(resources.GetObject("lblCounterType.TabIndex"), Integer)
        Me.lblCounterType.Text = resources.GetString("lblCounterType.Text")
        Me.lblCounterType.TextAlign = CType(resources.GetObject("lblCounterType.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblCounterType.Visible = CType(resources.GetObject("lblCounterType.Visible"), Boolean)
        '
        'txtCounterHelp
        '
        Me.txtCounterHelp.AccessibleDescription = resources.GetString("txtCounterHelp.AccessibleDescription")
        Me.txtCounterHelp.AccessibleName = resources.GetString("txtCounterHelp.AccessibleName")
        Me.txtCounterHelp.Anchor = CType(resources.GetObject("txtCounterHelp.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCounterHelp.AutoSize = CType(resources.GetObject("txtCounterHelp.AutoSize"), Boolean)
        Me.txtCounterHelp.BackgroundImage = CType(resources.GetObject("txtCounterHelp.BackgroundImage"), System.Drawing.Image)
        Me.txtCounterHelp.Dock = CType(resources.GetObject("txtCounterHelp.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCounterHelp.Enabled = CType(resources.GetObject("txtCounterHelp.Enabled"), Boolean)
        Me.txtCounterHelp.Font = CType(resources.GetObject("txtCounterHelp.Font"), System.Drawing.Font)
        Me.txtCounterHelp.ImeMode = CType(resources.GetObject("txtCounterHelp.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCounterHelp.Location = CType(resources.GetObject("txtCounterHelp.Location"), System.Drawing.Point)
        Me.txtCounterHelp.MaxLength = CType(resources.GetObject("txtCounterHelp.MaxLength"), Integer)
        Me.txtCounterHelp.Multiline = CType(resources.GetObject("txtCounterHelp.Multiline"), Boolean)
        Me.txtCounterHelp.Name = "txtCounterHelp"
        Me.txtCounterHelp.PasswordChar = CType(resources.GetObject("txtCounterHelp.PasswordChar"), Char)
        Me.txtCounterHelp.RightToLeft = CType(resources.GetObject("txtCounterHelp.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCounterHelp.ScrollBars = CType(resources.GetObject("txtCounterHelp.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCounterHelp.Size = CType(resources.GetObject("txtCounterHelp.Size"), System.Drawing.Size)
        Me.txtCounterHelp.TabIndex = CType(resources.GetObject("txtCounterHelp.TabIndex"), Integer)
        Me.txtCounterHelp.TabStop = False
        Me.txtCounterHelp.Text = resources.GetString("txtCounterHelp.Text")
        Me.txtCounterHelp.TextAlign = CType(resources.GetObject("txtCounterHelp.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCounterHelp.Visible = CType(resources.GetObject("txtCounterHelp.Visible"), Boolean)
        Me.txtCounterHelp.WordWrap = CType(resources.GetObject("txtCounterHelp.WordWrap"), Boolean)
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription")
        Me.Label3.AccessibleName = CType(resources.GetObject("Label3.AccessibleName"), String)
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
        'lblBuiltInOrCustom
        '
        Me.lblBuiltInOrCustom.AccessibleDescription = resources.GetString("lblBuiltInOrCustom.AccessibleDescription")
        Me.lblBuiltInOrCustom.AccessibleName = resources.GetString("lblBuiltInOrCustom.AccessibleName")
        Me.lblBuiltInOrCustom.Anchor = CType(resources.GetObject("lblBuiltInOrCustom.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblBuiltInOrCustom.AutoSize = CType(resources.GetObject("lblBuiltInOrCustom.AutoSize"), Boolean)
        Me.lblBuiltInOrCustom.Dock = CType(resources.GetObject("lblBuiltInOrCustom.Dock"), System.Windows.Forms.DockStyle)
        Me.lblBuiltInOrCustom.Enabled = CType(resources.GetObject("lblBuiltInOrCustom.Enabled"), Boolean)
        Me.lblBuiltInOrCustom.Font = CType(resources.GetObject("lblBuiltInOrCustom.Font"), System.Drawing.Font)
        Me.lblBuiltInOrCustom.Image = CType(resources.GetObject("lblBuiltInOrCustom.Image"), System.Drawing.Image)
        Me.lblBuiltInOrCustom.ImageAlign = CType(resources.GetObject("lblBuiltInOrCustom.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblBuiltInOrCustom.ImageIndex = CType(resources.GetObject("lblBuiltInOrCustom.ImageIndex"), Integer)
        Me.lblBuiltInOrCustom.ImeMode = CType(resources.GetObject("lblBuiltInOrCustom.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblBuiltInOrCustom.Location = CType(resources.GetObject("lblBuiltInOrCustom.Location"), System.Drawing.Point)
        Me.lblBuiltInOrCustom.Name = "lblBuiltInOrCustom"
        Me.lblBuiltInOrCustom.RightToLeft = CType(resources.GetObject("lblBuiltInOrCustom.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblBuiltInOrCustom.Size = CType(resources.GetObject("lblBuiltInOrCustom.Size"), System.Drawing.Size)
        Me.lblBuiltInOrCustom.TabIndex = CType(resources.GetObject("lblBuiltInOrCustom.TabIndex"), Integer)
        Me.lblBuiltInOrCustom.Text = resources.GetString("lblBuiltInOrCustom.Text")
        Me.lblBuiltInOrCustom.TextAlign = CType(resources.GetObject("lblBuiltInOrCustom.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblBuiltInOrCustom.Visible = CType(resources.GetObject("lblBuiltInOrCustom.Visible"), Boolean)
        '
        'txtBuiltInOrCustom
        '
        Me.txtBuiltInOrCustom.AccessibleDescription = resources.GetString("txtBuiltInOrCustom.AccessibleDescription")
        Me.txtBuiltInOrCustom.AccessibleName = resources.GetString("txtBuiltInOrCustom.AccessibleName")
        Me.txtBuiltInOrCustom.Anchor = CType(resources.GetObject("txtBuiltInOrCustom.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtBuiltInOrCustom.AutoSize = CType(resources.GetObject("txtBuiltInOrCustom.AutoSize"), Boolean)
        Me.txtBuiltInOrCustom.BackgroundImage = CType(resources.GetObject("txtBuiltInOrCustom.BackgroundImage"), System.Drawing.Image)
        Me.txtBuiltInOrCustom.Dock = CType(resources.GetObject("txtBuiltInOrCustom.Dock"), System.Windows.Forms.DockStyle)
        Me.txtBuiltInOrCustom.Enabled = CType(resources.GetObject("txtBuiltInOrCustom.Enabled"), Boolean)
        Me.txtBuiltInOrCustom.Font = CType(resources.GetObject("txtBuiltInOrCustom.Font"), System.Drawing.Font)
        Me.txtBuiltInOrCustom.ImeMode = CType(resources.GetObject("txtBuiltInOrCustom.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtBuiltInOrCustom.Location = CType(resources.GetObject("txtBuiltInOrCustom.Location"), System.Drawing.Point)
        Me.txtBuiltInOrCustom.MaxLength = CType(resources.GetObject("txtBuiltInOrCustom.MaxLength"), Integer)
        Me.txtBuiltInOrCustom.Multiline = CType(resources.GetObject("txtBuiltInOrCustom.Multiline"), Boolean)
        Me.txtBuiltInOrCustom.Name = "txtBuiltInOrCustom"
        Me.txtBuiltInOrCustom.PasswordChar = CType(resources.GetObject("txtBuiltInOrCustom.PasswordChar"), Char)
        Me.txtBuiltInOrCustom.RightToLeft = CType(resources.GetObject("txtBuiltInOrCustom.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtBuiltInOrCustom.ScrollBars = CType(resources.GetObject("txtBuiltInOrCustom.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtBuiltInOrCustom.Size = CType(resources.GetObject("txtBuiltInOrCustom.Size"), System.Drawing.Size)
        Me.txtBuiltInOrCustom.TabIndex = CType(resources.GetObject("txtBuiltInOrCustom.TabIndex"), Integer)
        Me.txtBuiltInOrCustom.Text = resources.GetString("txtBuiltInOrCustom.Text")
        Me.txtBuiltInOrCustom.TextAlign = CType(resources.GetObject("txtBuiltInOrCustom.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtBuiltInOrCustom.Visible = CType(resources.GetObject("txtBuiltInOrCustom.Visible"), Boolean)
        Me.txtBuiltInOrCustom.WordWrap = CType(resources.GetObject("txtBuiltInOrCustom.WordWrap"), Boolean)
        '
        'btnIncrementCounter
        '
        Me.btnIncrementCounter.AccessibleDescription = resources.GetString("btnIncrementCounter.AccessibleDescription")
        Me.btnIncrementCounter.AccessibleName = resources.GetString("btnIncrementCounter.AccessibleName")
        Me.btnIncrementCounter.Anchor = CType(resources.GetObject("btnIncrementCounter.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnIncrementCounter.BackgroundImage = CType(resources.GetObject("btnIncrementCounter.BackgroundImage"), System.Drawing.Image)
        Me.btnIncrementCounter.Dock = CType(resources.GetObject("btnIncrementCounter.Dock"), System.Windows.Forms.DockStyle)
        Me.btnIncrementCounter.Enabled = CType(resources.GetObject("btnIncrementCounter.Enabled"), Boolean)
        Me.btnIncrementCounter.FlatStyle = CType(resources.GetObject("btnIncrementCounter.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnIncrementCounter.Font = CType(resources.GetObject("btnIncrementCounter.Font"), System.Drawing.Font)
        Me.btnIncrementCounter.Image = CType(resources.GetObject("btnIncrementCounter.Image"), System.Drawing.Image)
        Me.btnIncrementCounter.ImageAlign = CType(resources.GetObject("btnIncrementCounter.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnIncrementCounter.ImageIndex = CType(resources.GetObject("btnIncrementCounter.ImageIndex"), Integer)
        Me.btnIncrementCounter.ImeMode = CType(resources.GetObject("btnIncrementCounter.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnIncrementCounter.Location = CType(resources.GetObject("btnIncrementCounter.Location"), System.Drawing.Point)
        Me.btnIncrementCounter.Name = "btnIncrementCounter"
        Me.btnIncrementCounter.RightToLeft = CType(resources.GetObject("btnIncrementCounter.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnIncrementCounter.Size = CType(resources.GetObject("btnIncrementCounter.Size"), System.Drawing.Size)
        Me.btnIncrementCounter.TabIndex = CType(resources.GetObject("btnIncrementCounter.TabIndex"), Integer)
        Me.btnIncrementCounter.Text = resources.GetString("btnIncrementCounter.Text")
        Me.btnIncrementCounter.TextAlign = CType(resources.GetObject("btnIncrementCounter.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnIncrementCounter.Visible = CType(resources.GetObject("btnIncrementCounter.Visible"), Boolean)
        '
        'btnDecrementCounter
        '
        Me.btnDecrementCounter.AccessibleDescription = resources.GetString("btnDecrementCounter.AccessibleDescription")
        Me.btnDecrementCounter.AccessibleName = resources.GetString("btnDecrementCounter.AccessibleName")
        Me.btnDecrementCounter.Anchor = CType(resources.GetObject("btnDecrementCounter.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnDecrementCounter.BackgroundImage = CType(resources.GetObject("btnDecrementCounter.BackgroundImage"), System.Drawing.Image)
        Me.btnDecrementCounter.Dock = CType(resources.GetObject("btnDecrementCounter.Dock"), System.Windows.Forms.DockStyle)
        Me.btnDecrementCounter.Enabled = CType(resources.GetObject("btnDecrementCounter.Enabled"), Boolean)
        Me.btnDecrementCounter.FlatStyle = CType(resources.GetObject("btnDecrementCounter.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnDecrementCounter.Font = CType(resources.GetObject("btnDecrementCounter.Font"), System.Drawing.Font)
        Me.btnDecrementCounter.Image = CType(resources.GetObject("btnDecrementCounter.Image"), System.Drawing.Image)
        Me.btnDecrementCounter.ImageAlign = CType(resources.GetObject("btnDecrementCounter.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnDecrementCounter.ImageIndex = CType(resources.GetObject("btnDecrementCounter.ImageIndex"), Integer)
        Me.btnDecrementCounter.ImeMode = CType(resources.GetObject("btnDecrementCounter.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnDecrementCounter.Location = CType(resources.GetObject("btnDecrementCounter.Location"), System.Drawing.Point)
        Me.btnDecrementCounter.Name = "btnDecrementCounter"
        Me.btnDecrementCounter.RightToLeft = CType(resources.GetObject("btnDecrementCounter.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnDecrementCounter.Size = CType(resources.GetObject("btnDecrementCounter.Size"), System.Drawing.Size)
        Me.btnDecrementCounter.TabIndex = CType(resources.GetObject("btnDecrementCounter.TabIndex"), Integer)
        Me.btnDecrementCounter.Text = resources.GetString("btnDecrementCounter.Text")
        Me.btnDecrementCounter.TextAlign = CType(resources.GetObject("btnDecrementCounter.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnDecrementCounter.Visible = CType(resources.GetObject("btnDecrementCounter.Visible"), Boolean)
        '
        'sbrStatus
        '
        Me.sbrStatus.AccessibleDescription = resources.GetString("sbrStatus.AccessibleDescription")
        Me.sbrStatus.AccessibleName = resources.GetString("sbrStatus.AccessibleName")
        Me.sbrStatus.Anchor = CType(resources.GetObject("sbrStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.sbrStatus.BackgroundImage = CType(resources.GetObject("sbrStatus.BackgroundImage"), System.Drawing.Image)
        Me.sbrStatus.Dock = CType(resources.GetObject("sbrStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.sbrStatus.Enabled = CType(resources.GetObject("sbrStatus.Enabled"), Boolean)
        Me.sbrStatus.Font = CType(resources.GetObject("sbrStatus.Font"), System.Drawing.Font)
        Me.sbrStatus.ImeMode = CType(resources.GetObject("sbrStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.sbrStatus.Location = CType(resources.GetObject("sbrStatus.Location"), System.Drawing.Point)
        Me.sbrStatus.Name = "sbrStatus"
        Me.sbrStatus.RightToLeft = CType(resources.GetObject("sbrStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.sbrStatus.Size = CType(resources.GetObject("sbrStatus.Size"), System.Drawing.Size)
        Me.sbrStatus.TabIndex = CType(resources.GetObject("sbrStatus.TabIndex"), Integer)
        Me.sbrStatus.Text = resources.GetString("sbrStatus.Text")
        Me.sbrStatus.Visible = CType(resources.GetObject("sbrStatus.Visible"), Boolean)
        '
        'lblAddingACustomControl
        '
        Me.lblAddingACustomControl.AccessibleDescription = resources.GetString("lblAddingACustomControl.AccessibleDescription")
        Me.lblAddingACustomControl.AccessibleName = resources.GetString("lblAddingACustomControl.AccessibleName")
        Me.lblAddingACustomControl.Anchor = CType(resources.GetObject("lblAddingACustomControl.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblAddingACustomControl.AutoSize = CType(resources.GetObject("lblAddingACustomControl.AutoSize"), Boolean)
        Me.lblAddingACustomControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAddingACustomControl.Dock = CType(resources.GetObject("lblAddingACustomControl.Dock"), System.Windows.Forms.DockStyle)
        Me.lblAddingACustomControl.Enabled = CType(resources.GetObject("lblAddingACustomControl.Enabled"), Boolean)
        Me.lblAddingACustomControl.Font = CType(resources.GetObject("lblAddingACustomControl.Font"), System.Drawing.Font)
        Me.lblAddingACustomControl.Image = CType(resources.GetObject("lblAddingACustomControl.Image"), System.Drawing.Image)
        Me.lblAddingACustomControl.ImageAlign = CType(resources.GetObject("lblAddingACustomControl.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblAddingACustomControl.ImageIndex = CType(resources.GetObject("lblAddingACustomControl.ImageIndex"), Integer)
        Me.lblAddingACustomControl.ImeMode = CType(resources.GetObject("lblAddingACustomControl.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblAddingACustomControl.Location = CType(resources.GetObject("lblAddingACustomControl.Location"), System.Drawing.Point)
        Me.lblAddingACustomControl.Name = "lblAddingACustomControl"
        Me.lblAddingACustomControl.RightToLeft = CType(resources.GetObject("lblAddingACustomControl.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblAddingACustomControl.Size = CType(resources.GetObject("lblAddingACustomControl.Size"), System.Drawing.Size)
        Me.lblAddingACustomControl.TabIndex = CType(resources.GetObject("lblAddingACustomControl.TabIndex"), Integer)
        Me.lblAddingACustomControl.Text = resources.GetString("lblAddingACustomControl.Text")
        Me.lblAddingACustomControl.TextAlign = CType(resources.GetObject("lblAddingACustomControl.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblAddingACustomControl.Visible = CType(resources.GetObject("lblAddingACustomControl.Visible"), Boolean)
        '
        'btnRefreshCategories
        '
        Me.btnRefreshCategories.AccessibleDescription = resources.GetString("btnRefreshCategories.AccessibleDescription")
        Me.btnRefreshCategories.AccessibleName = resources.GetString("btnRefreshCategories.AccessibleName")
        Me.btnRefreshCategories.Anchor = CType(resources.GetObject("btnRefreshCategories.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshCategories.BackgroundImage = CType(resources.GetObject("btnRefreshCategories.BackgroundImage"), System.Drawing.Image)
        Me.btnRefreshCategories.Dock = CType(resources.GetObject("btnRefreshCategories.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRefreshCategories.Enabled = CType(resources.GetObject("btnRefreshCategories.Enabled"), Boolean)
        Me.btnRefreshCategories.FlatStyle = CType(resources.GetObject("btnRefreshCategories.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRefreshCategories.Font = CType(resources.GetObject("btnRefreshCategories.Font"), System.Drawing.Font)
        Me.btnRefreshCategories.Image = CType(resources.GetObject("btnRefreshCategories.Image"), System.Drawing.Image)
        Me.btnRefreshCategories.ImageAlign = CType(resources.GetObject("btnRefreshCategories.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRefreshCategories.ImageIndex = CType(resources.GetObject("btnRefreshCategories.ImageIndex"), Integer)
        Me.btnRefreshCategories.ImeMode = CType(resources.GetObject("btnRefreshCategories.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRefreshCategories.Location = CType(resources.GetObject("btnRefreshCategories.Location"), System.Drawing.Point)
        Me.btnRefreshCategories.Name = "btnRefreshCategories"
        Me.btnRefreshCategories.RightToLeft = CType(resources.GetObject("btnRefreshCategories.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRefreshCategories.Size = CType(resources.GetObject("btnRefreshCategories.Size"), System.Drawing.Size)
        Me.btnRefreshCategories.TabIndex = CType(resources.GetObject("btnRefreshCategories.TabIndex"), Integer)
        Me.btnRefreshCategories.Text = resources.GetString("btnRefreshCategories.Text")
        Me.btnRefreshCategories.TextAlign = CType(resources.GetObject("btnRefreshCategories.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRefreshCategories.Visible = CType(resources.GetObject("btnRefreshCategories.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshCategories, Me.lblAddingACustomControl, Me.sbrStatus, Me.btnDecrementCounter, Me.btnIncrementCounter, Me.txtBuiltInOrCustom, Me.lblBuiltInOrCustom, Me.Label3, Me.txtCounterHelp, Me.lblCounterType, Me.txtCounterType, Me.Label2, Me.txtCounterValue, Me.Label1, Me.cboCategories, Me.lblSelectTimer, Me.cboCounters})
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

    ' This subroutine decrements the value of a custom counter. It 
    '   can only be executed when the counter selected is a
    '   custom counter -- only custom counters can have their ReadOnly properies
    '   set to False. 
    Private Sub btnDecrementCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecrementCounter.Click
        ' This button is only enabled when the selected
        '   counter is a Custom counter, so we can set the read-only to
        '   False, and use it. Still, use a Try-Catch...
        Try
            ' Set ReadOnly to False, so that the counter can be manipulated
            m_Counter.ReadOnly = False

            ' Only decrement the counter if it has a value > 0
            '   Although this isn't technically necessary, it makes logical
            '   sense.  
            If m_Counter.RawValue > 0 Then
                m_Counter.Decrement()
                sbrStatus.Text = ""
            Else
                ' Display the status to the user.
                sbrStatus.Text = "Counter is already zero."
            End If
        Catch exc As Exception
            ' In case an Exception is raised, explain that the counter
            '   could not be decremented.
            sbrStatus.Text = "Could not decrement counter."
        End Try

    End Sub

    ' This subroutine increments the value of a custom counter. It 
    '   can only be executed when the counter selected is a
    '   custom counter -- only custom counters can have their ReadOnly properies
    '   set to False. 
    Private Sub btnIncrementCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncrementCounter.Click
        ' This button is only enabled when the selected
        '   counter is a Custom counter, so we can set the read-only to
        '   False, and use it. Still, use a Try-Catch...
        Try
            ' Set ReadOnly to False, so that the counter can be manipulated
            m_Counter.ReadOnly = False
            m_Counter.Increment()
            sbrStatus.Text = ""
        Catch
            ' In case an Exception is raised, explain that the counter
            '   could not be incremented.
            sbrStatus.Text = "Could not increment counter."
        End Try
    End Sub

    ' This subroutine enables the user to refresh the form after adding
    '   a custom PerformanceCounter using the Server Explorer.
    Private Sub btnRefreshCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshCategories.Click
        ' Reset the User Interface
        Me.cboCategories.Items.Clear()
        Me.cboCounters.Items.Clear()
        Me.m_Counter = Nothing
        Me.txtBuiltInOrCustom.Text = ""
        Me.txtCounterHelp.Text = ""
        Me.txtCounterType.Text = ""
        Me.txtCounterValue.Text = ""
        Me.btnDecrementCounter.Enabled = False
        Me.btnIncrementCounter.Enabled = False
        Me.cboCategories.Text = ""
        Me.cboCounters.Text = ""

        ' Call the Form_Load event
        Me.frmMain_Load(Me, New System.EventArgs())
    End Sub

    ' This event handler is fired whenever the user changes the selected 
    '   counter category. It then changes the cboCounters combo box to 
    '   reflect the counters available for that category. 
    ' Note that this routine makes heavy use of the CounterDisplayItem
    '   class that is defined in this How-To. The CounterDisplayItem allows
    '   us to take advantage of the way a combo box displays items -- if it
    '   contains an object, the ToString() method is called to fill the display.
    '   This is very important, since we must take into account both the 
    '   "instance" (what process to watch) and the particular counter that
    '   is associated with that instance. (For instance, you can measure the 
    '   number of CLR bytes compiled overall in the system, or just for a 
    '   particular instance of a running .NET program.)
    Private Sub cboCategories_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategories.SelectedIndexChanged

        Dim myCategory As PerformanceCounterCategory
        Dim myCounters As New ArrayList()
        Dim myCounter As PerformanceCounter
        Dim myCounterNames() As String

        If cboCategories.SelectedIndex <> -1 Then
            ' Fill cboCounters with Counter names
            Try
                ' Get the available category
                myCategory = New PerformanceCounterCategory( _
                    Me.cboCategories.SelectedItem.ToString())

                ' Get all available instances for the selected category
                myCounterNames = myCategory.GetInstanceNames()

                ' If there are no instances, then the counters are likely
                '   generic, so get the counters that are available (they
                '   will have no instance value).
                If myCounterNames.Length = 0 Then
                    myCounters.AddRange(myCategory.GetCounters())
                Else
                    Dim i As Integer
                    For i = 0 To myCounterNames.Length - 1
                        myCounters.AddRange( _
                            myCategory.GetCounters(myCounterNames(i)))
                    Next
                End If

                ' Clear the cboCounter box & reset text
                Me.cboCounters.Items.Clear()
                Me.cboCounters.Text = ""

                ' Add the counters to the cboCounters combo box. Use the
                '   CounterDisplayItem class to ensure that they are properly
                '   displayed, and also to ensure that there is a reference
                '   to the actual counter stored in the combo box item.
                For Each myCounter In myCounters
                    Me.cboCounters.Items.Add(New CounterDisplayItem(myCounter))
                Next

            Catch exc As Exception
                ' Alert the user, if the program is unable to list the 
                '   counters in this category.
                MsgBox("Unable to list the Counters in this Category." + _
                    "Please select another Category.")
            End Try

        End If
    End Sub

    ' This event handler is fired whenever the user changes the selected 
    '   counter. It then set the class variable 'm_Counter' to the actual
    '   value of the counter (using the CounterDisplayItem object that was
    '   stored in the cboCounters combo box). After the assignment is made,
    '   information about the counter is displayed in the UI.
    ' Note that this routine makes use of the CounterDisplayItem
    '   class that is defined in this How-To. 
    Private Sub cboCounters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCounters.SelectedIndexChanged

        Dim myCounterDisplay As CounterDisplayItem
        Try
            ' Get the CounterDisplayItem associated with the selection
            myCounterDisplay = CType(cboCounters.SelectedItem, CounterDisplayItem)
            ' Get the PerformanceCounter object stored in the CounterDisplayItem
            m_Counter = myCounterDisplay.Counter
            ' Display information about the Counter to the user
            Me.txtCounterType.Text = m_Counter.CounterType.ToString()
            Me.txtCounterHelp.Text = m_Counter.CounterHelp.ToString()
            Me.sbrStatus.Text = ""

            ' If the counter is a custom counter, enable the appropriate
            '   buttons.  Only custom items can be written to.
            ' Note: the CounterDisplayItem shows the code necessary to determine
            '   if a counter is custom or not.
            If myCounterDisplay.IsCustom Then
                ' Enable Increment and Decrement buttons
                Me.txtBuiltInOrCustom.Text = "Custom"
                Me.btnDecrementCounter.Enabled = True
                Me.btnIncrementCounter.Enabled = True
            Else
                ' Disable Increment and Decrement buttons
                Me.txtBuiltInOrCustom.Text = "Built-In"
                Me.btnDecrementCounter.Enabled = False
                Me.btnIncrementCounter.Enabled = False
            End If

        Catch exc As Exception
            ' Set the class counter to Nothing if there was an error.
            m_Counter = Nothing
        End Try
    End Sub

    ' This subroutine loads the cboCategories combo box with a list
    '   of all the available categories on the local machine.  It also
    '   starts the timer, so that the UI will be updated every half second.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Fill cboCounters with available counters
        Dim myCounters As PerformanceCounter
        Dim myCategory As PerformanceCounterCategory
        Dim myCategories() As PerformanceCounterCategory
        ' Set myCategories to contain all of the available Categories
        myCategories = myCategory.GetCategories()

        ' Declare a string array with the proper length
        Dim myCategoryNames(myCategories.Length - 1) As String
        Dim i As Integer = 0 ' Used as a counter

        ' Loop through the available categories, adding them to an
        '   array of strings. (This is done so that the categories can be
        '   be sorted.)
        For Each myCategory In myCategories
            myCategoryNames(i) = myCategory.CategoryName
            i += 1
        Next

        ' Sort the array
        Array.Sort(myCategoryNames)

        ' Add each value of the array to the cboCategories combo box.
        Dim nameString As String
        For Each nameString In myCategoryNames
            Me.cboCategories.Items.Add(nameString)
        Next

        ' Start the timer
        Me.tmrUpdateUI.Interval = 500
        Me.tmrUpdateUI.Enabled = True
    End Sub

    ' This event handler updates the value of the counter in the 
    '   user interface.
    Private Sub tmrUpdateUI_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpdateUI.Tick
        ' Verify that a Counter exists
        '   If it does, get its type and value. (Use Try-Catch, just in case.)
        Try
            If Not m_Counter Is Nothing Then
                Me.txtCounterValue.Text = m_Counter.NextValue().ToString()
            End If
        Catch exc As Exception
            Me.txtCounterValue.Text = ""
        End Try

    End Sub

End Class