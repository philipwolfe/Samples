'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' Declare a class variable containing  a GcTest object.
    Private m_TestObject As GcTest
    Private Const OBJECT_DEPTH As Integer = 3


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
    Friend WithEvents lstCreatedObjects As System.Windows.Forms.ListBox
    Friend WithEvents txtActivity As System.Windows.Forms.TextBox
    Friend WithEvents btnKillObject As System.Windows.Forms.Button
    Friend WithEvents btnDisposeObject As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnRunGC As System.Windows.Forms.Button
    Friend WithEvents chkIsFinalizeSuppressed As System.Windows.Forms.CheckBox
    Friend WithEvents btnCreateObjects As System.Windows.Forms.Button
    Friend WithEvents lblActivityLog As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.txtActivity = New System.Windows.Forms.TextBox()
        Me.btnCreateObjects = New System.Windows.Forms.Button()
        Me.lstCreatedObjects = New System.Windows.Forms.ListBox()
        Me.btnKillObject = New System.Windows.Forms.Button()
        Me.btnDisposeObject = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnRunGC = New System.Windows.Forms.Button()
        Me.chkIsFinalizeSuppressed = New System.Windows.Forms.CheckBox()
        Me.lblActivityLog = New System.Windows.Forms.Label()
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
        'txtActivity
        '
        Me.txtActivity.AccessibleDescription = resources.GetString("txtActivity.AccessibleDescription")
        Me.txtActivity.AccessibleName = resources.GetString("txtActivity.AccessibleName")
        Me.txtActivity.Anchor = CType(resources.GetObject("txtActivity.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtActivity.AutoSize = CType(resources.GetObject("txtActivity.AutoSize"), Boolean)
        Me.txtActivity.BackgroundImage = CType(resources.GetObject("txtActivity.BackgroundImage"), System.Drawing.Image)
        Me.txtActivity.Dock = CType(resources.GetObject("txtActivity.Dock"), System.Windows.Forms.DockStyle)
        Me.txtActivity.Enabled = CType(resources.GetObject("txtActivity.Enabled"), Boolean)
        Me.txtActivity.Font = CType(resources.GetObject("txtActivity.Font"), System.Drawing.Font)
        Me.txtActivity.ImeMode = CType(resources.GetObject("txtActivity.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtActivity.Location = CType(resources.GetObject("txtActivity.Location"), System.Drawing.Point)
        Me.txtActivity.MaxLength = CType(resources.GetObject("txtActivity.MaxLength"), Integer)
        Me.txtActivity.Multiline = CType(resources.GetObject("txtActivity.Multiline"), Boolean)
        Me.txtActivity.Name = "txtActivity"
        Me.txtActivity.PasswordChar = CType(resources.GetObject("txtActivity.PasswordChar"), Char)
        Me.txtActivity.RightToLeft = CType(resources.GetObject("txtActivity.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtActivity.ScrollBars = CType(resources.GetObject("txtActivity.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtActivity.Size = CType(resources.GetObject("txtActivity.Size"), System.Drawing.Size)
        Me.txtActivity.TabIndex = CType(resources.GetObject("txtActivity.TabIndex"), Integer)
        Me.txtActivity.TabStop = False
        Me.txtActivity.Text = resources.GetString("txtActivity.Text")
        Me.txtActivity.TextAlign = CType(resources.GetObject("txtActivity.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtActivity.Visible = CType(resources.GetObject("txtActivity.Visible"), Boolean)
        Me.txtActivity.WordWrap = CType(resources.GetObject("txtActivity.WordWrap"), Boolean)
        '
        'btnCreateObjects
        '
        Me.btnCreateObjects.AccessibleDescription = resources.GetString("btnCreateObjects.AccessibleDescription")
        Me.btnCreateObjects.AccessibleName = resources.GetString("btnCreateObjects.AccessibleName")
        Me.btnCreateObjects.Anchor = CType(resources.GetObject("btnCreateObjects.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateObjects.BackgroundImage = CType(resources.GetObject("btnCreateObjects.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateObjects.Dock = CType(resources.GetObject("btnCreateObjects.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateObjects.Enabled = CType(resources.GetObject("btnCreateObjects.Enabled"), Boolean)
        Me.btnCreateObjects.FlatStyle = CType(resources.GetObject("btnCreateObjects.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateObjects.Font = CType(resources.GetObject("btnCreateObjects.Font"), System.Drawing.Font)
        Me.btnCreateObjects.Image = CType(resources.GetObject("btnCreateObjects.Image"), System.Drawing.Image)
        Me.btnCreateObjects.ImageAlign = CType(resources.GetObject("btnCreateObjects.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateObjects.ImageIndex = CType(resources.GetObject("btnCreateObjects.ImageIndex"), Integer)
        Me.btnCreateObjects.ImeMode = CType(resources.GetObject("btnCreateObjects.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateObjects.Location = CType(resources.GetObject("btnCreateObjects.Location"), System.Drawing.Point)
        Me.btnCreateObjects.Name = "btnCreateObjects"
        Me.btnCreateObjects.RightToLeft = CType(resources.GetObject("btnCreateObjects.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateObjects.Size = CType(resources.GetObject("btnCreateObjects.Size"), System.Drawing.Size)
        Me.btnCreateObjects.TabIndex = CType(resources.GetObject("btnCreateObjects.TabIndex"), Integer)
        Me.btnCreateObjects.Text = resources.GetString("btnCreateObjects.Text")
        Me.btnCreateObjects.TextAlign = CType(resources.GetObject("btnCreateObjects.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateObjects.Visible = CType(resources.GetObject("btnCreateObjects.Visible"), Boolean)
        '
        'lstCreatedObjects
        '
        Me.lstCreatedObjects.AccessibleDescription = resources.GetString("lstCreatedObjects.AccessibleDescription")
        Me.lstCreatedObjects.AccessibleName = resources.GetString("lstCreatedObjects.AccessibleName")
        Me.lstCreatedObjects.Anchor = CType(resources.GetObject("lstCreatedObjects.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lstCreatedObjects.BackgroundImage = CType(resources.GetObject("lstCreatedObjects.BackgroundImage"), System.Drawing.Image)
        Me.lstCreatedObjects.ColumnWidth = CType(resources.GetObject("lstCreatedObjects.ColumnWidth"), Integer)
        Me.lstCreatedObjects.Dock = CType(resources.GetObject("lstCreatedObjects.Dock"), System.Windows.Forms.DockStyle)
        Me.lstCreatedObjects.Enabled = CType(resources.GetObject("lstCreatedObjects.Enabled"), Boolean)
        Me.lstCreatedObjects.Font = CType(resources.GetObject("lstCreatedObjects.Font"), System.Drawing.Font)
        Me.lstCreatedObjects.HorizontalExtent = CType(resources.GetObject("lstCreatedObjects.HorizontalExtent"), Integer)
        Me.lstCreatedObjects.HorizontalScrollbar = CType(resources.GetObject("lstCreatedObjects.HorizontalScrollbar"), Boolean)
        Me.lstCreatedObjects.ImeMode = CType(resources.GetObject("lstCreatedObjects.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lstCreatedObjects.IntegralHeight = CType(resources.GetObject("lstCreatedObjects.IntegralHeight"), Boolean)
        Me.lstCreatedObjects.ItemHeight = CType(resources.GetObject("lstCreatedObjects.ItemHeight"), Integer)
        Me.lstCreatedObjects.Location = CType(resources.GetObject("lstCreatedObjects.Location"), System.Drawing.Point)
        Me.lstCreatedObjects.Name = "lstCreatedObjects"
        Me.lstCreatedObjects.RightToLeft = CType(resources.GetObject("lstCreatedObjects.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lstCreatedObjects.ScrollAlwaysVisible = CType(resources.GetObject("lstCreatedObjects.ScrollAlwaysVisible"), Boolean)
        Me.lstCreatedObjects.Size = CType(resources.GetObject("lstCreatedObjects.Size"), System.Drawing.Size)
        Me.lstCreatedObjects.TabIndex = CType(resources.GetObject("lstCreatedObjects.TabIndex"), Integer)
        Me.lstCreatedObjects.TabStop = False
        Me.lstCreatedObjects.Visible = CType(resources.GetObject("lstCreatedObjects.Visible"), Boolean)
        '
        'btnKillObject
        '
        Me.btnKillObject.AccessibleDescription = resources.GetString("btnKillObject.AccessibleDescription")
        Me.btnKillObject.AccessibleName = resources.GetString("btnKillObject.AccessibleName")
        Me.btnKillObject.Anchor = CType(resources.GetObject("btnKillObject.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnKillObject.BackgroundImage = CType(resources.GetObject("btnKillObject.BackgroundImage"), System.Drawing.Image)
        Me.btnKillObject.Dock = CType(resources.GetObject("btnKillObject.Dock"), System.Windows.Forms.DockStyle)
        Me.btnKillObject.Enabled = CType(resources.GetObject("btnKillObject.Enabled"), Boolean)
        Me.btnKillObject.FlatStyle = CType(resources.GetObject("btnKillObject.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnKillObject.Font = CType(resources.GetObject("btnKillObject.Font"), System.Drawing.Font)
        Me.btnKillObject.Image = CType(resources.GetObject("btnKillObject.Image"), System.Drawing.Image)
        Me.btnKillObject.ImageAlign = CType(resources.GetObject("btnKillObject.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnKillObject.ImageIndex = CType(resources.GetObject("btnKillObject.ImageIndex"), Integer)
        Me.btnKillObject.ImeMode = CType(resources.GetObject("btnKillObject.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnKillObject.Location = CType(resources.GetObject("btnKillObject.Location"), System.Drawing.Point)
        Me.btnKillObject.Name = "btnKillObject"
        Me.btnKillObject.RightToLeft = CType(resources.GetObject("btnKillObject.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnKillObject.Size = CType(resources.GetObject("btnKillObject.Size"), System.Drawing.Size)
        Me.btnKillObject.TabIndex = CType(resources.GetObject("btnKillObject.TabIndex"), Integer)
        Me.btnKillObject.Text = resources.GetString("btnKillObject.Text")
        Me.btnKillObject.TextAlign = CType(resources.GetObject("btnKillObject.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnKillObject.Visible = CType(resources.GetObject("btnKillObject.Visible"), Boolean)
        '
        'btnDisposeObject
        '
        Me.btnDisposeObject.AccessibleDescription = resources.GetString("btnDisposeObject.AccessibleDescription")
        Me.btnDisposeObject.AccessibleName = resources.GetString("btnDisposeObject.AccessibleName")
        Me.btnDisposeObject.Anchor = CType(resources.GetObject("btnDisposeObject.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnDisposeObject.BackgroundImage = CType(resources.GetObject("btnDisposeObject.BackgroundImage"), System.Drawing.Image)
        Me.btnDisposeObject.Dock = CType(resources.GetObject("btnDisposeObject.Dock"), System.Windows.Forms.DockStyle)
        Me.btnDisposeObject.Enabled = CType(resources.GetObject("btnDisposeObject.Enabled"), Boolean)
        Me.btnDisposeObject.FlatStyle = CType(resources.GetObject("btnDisposeObject.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnDisposeObject.Font = CType(resources.GetObject("btnDisposeObject.Font"), System.Drawing.Font)
        Me.btnDisposeObject.Image = CType(resources.GetObject("btnDisposeObject.Image"), System.Drawing.Image)
        Me.btnDisposeObject.ImageAlign = CType(resources.GetObject("btnDisposeObject.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnDisposeObject.ImageIndex = CType(resources.GetObject("btnDisposeObject.ImageIndex"), Integer)
        Me.btnDisposeObject.ImeMode = CType(resources.GetObject("btnDisposeObject.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnDisposeObject.Location = CType(resources.GetObject("btnDisposeObject.Location"), System.Drawing.Point)
        Me.btnDisposeObject.Name = "btnDisposeObject"
        Me.btnDisposeObject.RightToLeft = CType(resources.GetObject("btnDisposeObject.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnDisposeObject.Size = CType(resources.GetObject("btnDisposeObject.Size"), System.Drawing.Size)
        Me.btnDisposeObject.TabIndex = CType(resources.GetObject("btnDisposeObject.TabIndex"), Integer)
        Me.btnDisposeObject.Text = resources.GetString("btnDisposeObject.Text")
        Me.btnDisposeObject.TextAlign = CType(resources.GetObject("btnDisposeObject.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnDisposeObject.Visible = CType(resources.GetObject("btnDisposeObject.Visible"), Boolean)
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
        'btnRunGC
        '
        Me.btnRunGC.AccessibleDescription = resources.GetString("btnRunGC.AccessibleDescription")
        Me.btnRunGC.AccessibleName = resources.GetString("btnRunGC.AccessibleName")
        Me.btnRunGC.Anchor = CType(resources.GetObject("btnRunGC.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRunGC.BackgroundImage = CType(resources.GetObject("btnRunGC.BackgroundImage"), System.Drawing.Image)
        Me.btnRunGC.Dock = CType(resources.GetObject("btnRunGC.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRunGC.Enabled = CType(resources.GetObject("btnRunGC.Enabled"), Boolean)
        Me.btnRunGC.FlatStyle = CType(resources.GetObject("btnRunGC.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRunGC.Font = CType(resources.GetObject("btnRunGC.Font"), System.Drawing.Font)
        Me.btnRunGC.Image = CType(resources.GetObject("btnRunGC.Image"), System.Drawing.Image)
        Me.btnRunGC.ImageAlign = CType(resources.GetObject("btnRunGC.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRunGC.ImageIndex = CType(resources.GetObject("btnRunGC.ImageIndex"), Integer)
        Me.btnRunGC.ImeMode = CType(resources.GetObject("btnRunGC.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRunGC.Location = CType(resources.GetObject("btnRunGC.Location"), System.Drawing.Point)
        Me.btnRunGC.Name = "btnRunGC"
        Me.btnRunGC.RightToLeft = CType(resources.GetObject("btnRunGC.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRunGC.Size = CType(resources.GetObject("btnRunGC.Size"), System.Drawing.Size)
        Me.btnRunGC.TabIndex = CType(resources.GetObject("btnRunGC.TabIndex"), Integer)
        Me.btnRunGC.Text = resources.GetString("btnRunGC.Text")
        Me.btnRunGC.TextAlign = CType(resources.GetObject("btnRunGC.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRunGC.Visible = CType(resources.GetObject("btnRunGC.Visible"), Boolean)
        '
        'chkIsFinalizeSuppressed
        '
        Me.chkIsFinalizeSuppressed.AccessibleDescription = resources.GetString("chkIsFinalizeSuppressed.AccessibleDescription")
        Me.chkIsFinalizeSuppressed.AccessibleName = resources.GetString("chkIsFinalizeSuppressed.AccessibleName")
        Me.chkIsFinalizeSuppressed.Anchor = CType(resources.GetObject("chkIsFinalizeSuppressed.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkIsFinalizeSuppressed.Appearance = CType(resources.GetObject("chkIsFinalizeSuppressed.Appearance"), System.Windows.Forms.Appearance)
        Me.chkIsFinalizeSuppressed.BackgroundImage = CType(resources.GetObject("chkIsFinalizeSuppressed.BackgroundImage"), System.Drawing.Image)
        Me.chkIsFinalizeSuppressed.CheckAlign = CType(resources.GetObject("chkIsFinalizeSuppressed.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkIsFinalizeSuppressed.Checked = True
        Me.chkIsFinalizeSuppressed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsFinalizeSuppressed.Dock = CType(resources.GetObject("chkIsFinalizeSuppressed.Dock"), System.Windows.Forms.DockStyle)
        Me.chkIsFinalizeSuppressed.Enabled = CType(resources.GetObject("chkIsFinalizeSuppressed.Enabled"), Boolean)
        Me.chkIsFinalizeSuppressed.FlatStyle = CType(resources.GetObject("chkIsFinalizeSuppressed.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkIsFinalizeSuppressed.Font = CType(resources.GetObject("chkIsFinalizeSuppressed.Font"), System.Drawing.Font)
        Me.chkIsFinalizeSuppressed.Image = CType(resources.GetObject("chkIsFinalizeSuppressed.Image"), System.Drawing.Image)
        Me.chkIsFinalizeSuppressed.ImageAlign = CType(resources.GetObject("chkIsFinalizeSuppressed.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkIsFinalizeSuppressed.ImageIndex = CType(resources.GetObject("chkIsFinalizeSuppressed.ImageIndex"), Integer)
        Me.chkIsFinalizeSuppressed.ImeMode = CType(resources.GetObject("chkIsFinalizeSuppressed.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkIsFinalizeSuppressed.Location = CType(resources.GetObject("chkIsFinalizeSuppressed.Location"), System.Drawing.Point)
        Me.chkIsFinalizeSuppressed.Name = "chkIsFinalizeSuppressed"
        Me.chkIsFinalizeSuppressed.RightToLeft = CType(resources.GetObject("chkIsFinalizeSuppressed.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkIsFinalizeSuppressed.Size = CType(resources.GetObject("chkIsFinalizeSuppressed.Size"), System.Drawing.Size)
        Me.chkIsFinalizeSuppressed.TabIndex = CType(resources.GetObject("chkIsFinalizeSuppressed.TabIndex"), Integer)
        Me.chkIsFinalizeSuppressed.Text = resources.GetString("chkIsFinalizeSuppressed.Text")
        Me.chkIsFinalizeSuppressed.TextAlign = CType(resources.GetObject("chkIsFinalizeSuppressed.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkIsFinalizeSuppressed.Visible = CType(resources.GetObject("chkIsFinalizeSuppressed.Visible"), Boolean)
        '
        'lblActivityLog
        '
        Me.lblActivityLog.AccessibleDescription = resources.GetString("lblActivityLog.AccessibleDescription")
        Me.lblActivityLog.AccessibleName = resources.GetString("lblActivityLog.AccessibleName")
        Me.lblActivityLog.Anchor = CType(resources.GetObject("lblActivityLog.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblActivityLog.AutoSize = CType(resources.GetObject("lblActivityLog.AutoSize"), Boolean)
        Me.lblActivityLog.Dock = CType(resources.GetObject("lblActivityLog.Dock"), System.Windows.Forms.DockStyle)
        Me.lblActivityLog.Enabled = CType(resources.GetObject("lblActivityLog.Enabled"), Boolean)
        Me.lblActivityLog.Font = CType(resources.GetObject("lblActivityLog.Font"), System.Drawing.Font)
        Me.lblActivityLog.Image = CType(resources.GetObject("lblActivityLog.Image"), System.Drawing.Image)
        Me.lblActivityLog.ImageAlign = CType(resources.GetObject("lblActivityLog.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblActivityLog.ImageIndex = CType(resources.GetObject("lblActivityLog.ImageIndex"), Integer)
        Me.lblActivityLog.ImeMode = CType(resources.GetObject("lblActivityLog.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblActivityLog.Location = CType(resources.GetObject("lblActivityLog.Location"), System.Drawing.Point)
        Me.lblActivityLog.Name = "lblActivityLog"
        Me.lblActivityLog.RightToLeft = CType(resources.GetObject("lblActivityLog.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblActivityLog.Size = CType(resources.GetObject("lblActivityLog.Size"), System.Drawing.Size)
        Me.lblActivityLog.TabIndex = CType(resources.GetObject("lblActivityLog.TabIndex"), Integer)
        Me.lblActivityLog.Text = resources.GetString("lblActivityLog.Text")
        Me.lblActivityLog.TextAlign = CType(resources.GetObject("lblActivityLog.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblActivityLog.Visible = CType(resources.GetObject("lblActivityLog.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblActivityLog, Me.btnRunGC, Me.btnClear, Me.btnDisposeObject, Me.btnKillObject, Me.lstCreatedObjects, Me.btnCreateObjects, Me.txtActivity, Me.chkIsFinalizeSuppressed})
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
    ' This subroutine simple clears the txtActivity TextBox so that 
    '   the user can get a new clean look at activity.
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ' Clear the TextBox.
        txtActivity.Clear()
    End Sub

    ' This subroutine creates a hierarchy of OBJECT_DEPTH + 1 objects -- the 
    '   main object, and OBJECT_DEPTH children
    Private Sub btnCreateObjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateObjects.Click

        ' Test for existence of m_TextObject. Only allow the user to create
        '   one object tree at a time.
        If m_TestObject Is Nothing Then

            ' Output activity to log.
            Me.AddToActivityLog(" -- Creating Object Tree -- ")

            ' Create the test object. This will automatically create the 
            '   object hierarchy since the GcTest constructor automatically
            '   calls itself recursively OBJECT_DEPTH number of times.
            m_TestObject = New GcTest("TestObject", OBJECT_DEPTH)

            ' Add an event handler to handle the information events that
            '   are raised by the GcTest object
            AddHandler m_TestObject.ObjectGcInfo, AddressOf myObjectEventHandler

            ' Show the generation numbers and display them in the activity log.
            ' Output the ArrayList strings (Generations) to the Activity Log
            Dim myObject As Object
            For Each myObject In m_TestObject.GetSelfAndChildGenerations()
                AddToActivityLog(myObject.ToString())
            Next

            ' Redisplay the object hierarchy in the ListBox
            ShowTestObjects()

        Else
            ' Only let the user create one tree. Object exists so just
            '   warn the user.
            MsgBox("Please Kill existing objects before creating new objects.", _
                MsgBoxStyle.OKOnly, Me.Text)
        End If

    End Sub

    ' This subroutine disposes of the object selected in the lstCreatedObjects
    '   ListBox. How the objects are Disposed depends on whether the 
    '   chkIsFinalizeSuppressed is checked. If it is checked, then the Dispose
    '   method will suppress the finalization of the object and its children, 
    '   otherwise the garbage collector will run.
    ' The way the Dispose method of the GcTest class is designed, it will Dispose
    '   and kill each of its child objects, but will not kill itself.
    Private Sub btnDisposeObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisposeObject.Click

        ' Check to ensure that there is a selected item 
        If Me.lstCreatedObjects.SelectedItem Is Nothing Then
            Return
        End If

        ' Get the name of the selected object from the ListBox
        Dim strName As String = Me.lstCreatedObjects.SelectedItem.ToString()

        ' Output activity to log.
        AddToActivityLog(" -- Disposing of " + strName + " -- ")

        ' Check to see what object is being Disposed. If it is not 
        '   the current object, then call the DisposeChildNamed() 
        '   subroutine to try to find the right object to dispose of.
        If strName = Me.m_TestObject.Name Then
            ' Dispose of m_TestObject.
            m_TestObject.Dispose(chkIsFinalizeSuppressed.Checked)
            ' Set it equal to Nothing.
            m_TestObject = Nothing
        Else
            ' Try to find object to Dispose by searching through
            '   child hierarchy.
            m_TestObject.DisposeChildNamed(strName, _
                    chkIsFinalizeSuppressed.Checked)
        End If

        ' Redisplay the object hierarchy in the ListBox.
        ShowTestObjects()

    End Sub

    ' This subroutine kills the object selected in the lstCreatedObjects
    '   ListBox by setting it to Nothing, which opens it up for Garbage
    '   Collection. 
    Private Sub btnKillObject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKillObject.Click

        ' Check to ensure that there is a selected item 
        If Me.lstCreatedObjects.SelectedItem Is Nothing Then
            Return
        End If

        ' Get the name of the selected object from the ListBox
        Dim strName As String = Me.lstCreatedObjects.SelectedItem.ToString()

        ' Output activity to log.
        Me.AddToActivityLog(" -- Killing " + strName + " -- ")

        ' Check to see what object is being killed. If it is not 
        '   the current object, then call the KillChildNamed() 
        '   subroutine to try to find the right object to kill.
        If strName = Me.m_TestObject.Name Then
            ' Kill m_TestObject by setting it equal to Nothing.
            m_TestObject = Nothing
        Else
            ' Try to find object to Dispose by searching through
            '   child hierarchy.
            m_TestObject.KillChildNamed(strName)
        End If

        ' Redisplay the object hierarchy in the ListBox
        ShowTestObjects()

    End Sub

    ' This subroutine forces the Garbage Collector (GC) to run. Remember, though, 
    '  even the GC.Collect() method is not deterministic. That means that the OS 
    '  may delay running the Garbage Collector to finish some currently running
    '  tasks. In practice, you can expect the GC to run within a second or
    '  so of the Collect() method being called.
    Private Sub btnRunGC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunGC.Click
        ' Get rid of reference to object in the ListBox
        Me.lstCreatedObjects.Items.Clear()
        Me.lstCreatedObjects.Refresh()

        ' Output activity to log.
        Me.AddToActivityLog(" -- Running GC -- ")

        ' Run the Garbage Collector.
        GC.Collect()
        ' Tell the current thread to wait until all of the
        '   Finalizers have been called. This method stops the 
        '   tread from executing further instructions, until all 
        '   Finalize methods have been called for objects that
        '   are awaiting finalization.
        GC.WaitForPendingFinalizers()

        ' If m_TestObject exists, get the generation numbers and display them.
        If Not m_TestObject Is Nothing Then

            ' Output the ArrayList strings to the Activity Log
            Dim myObject As Object
            For Each myObject In m_TestObject.GetSelfAndChildGenerations()
                ' Add the information to the Activity Log
                Me.AddToActivityLog(myObject.ToString())
            Next
        End If

        ' Display any objects that may have been created in the ListBox
        ShowTestObjects()

    End Sub


    ' Simple function to add text to the Activity Textbox
    Private Sub AddToActivityLog(ByVal message As String)
        Try
            Me.txtActivity.AppendText(message + vbCrLf)
            Me.txtActivity.ScrollToCaret()
        Catch ode As ObjectDisposedException
            ' This occurs when the User closes the form. This causes the TextBox
            '   to be disposed. Yet objects are still being garbage collected
            '   (finalized in this case), and so this method is still being
            '   called. Therefore, simple catch this exception and use a 
            '   MsgBox instead. (Thrown by the ScrollToCaret method.)
            MsgBox(message, MsgBoxStyle.OKOnly, Me.Text)
        Catch aoor As System.ArgumentOutOfRangeException
            ' This occurs when the User closes the form. This causes the TextBox
            '   to be disposed. Yet objects are still being garbage collected
            '   (finalized in this case), and so this method is still being
            '   called. Therefore, simple catch this exception and use a 
            '   MsgBox instead. (Thrown by the AppendText method.)
            MsgBox(message, MsgBoxStyle.OKOnly, Me.Text)
        Catch ex As Exception
            ' Alert the user to the exception.
            MsgBox("Exception Occurred. " + ex.ToString(), _
                MsgBoxStyle.OKOnly, Me.Text)
        End Try
    End Sub

    ' This subroutine handles all of the events raised by 
    '   the GcTest objects. It simply outputs the passed message
    '   to the Activity Log.
    Private Sub myObjectEventHandler(ByVal message As String)
        ' Add the message to the Activity Log.
        AddToActivityLog(message)
    End Sub

    ' This subroutine clears and fills the lstCreatedObjects
    '   ListBox.
    Private Sub ShowTestObjects()

        ' Clear the ListBox.
        Me.lstCreatedObjects.Items.Clear()

        ' Fill the ListBox with the created GcTest object names hierarchy.
        ' Test to ensure that m_TestObject has been created.
        If Not Me.m_TestObject Is Nothing Then
            Dim tmpObject As Object
            ' Add the names of the objects to the ListBox
            For Each tmpObject In m_TestObject.GetSelfAndChildNames()
                Me.lstCreatedObjects.Items.Add(tmpObject)
            Next
        End If

    End Sub

End Class