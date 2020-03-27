'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSpeak As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dlgOpenWordFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBrowseWord As System.Windows.Forms.Button
    Friend WithEvents btnSpellCheck As System.Windows.Forms.Button
    Friend WithEvents btnGetMenu As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents tabOfficeDemo As System.Windows.Forms.TabControl
    Friend WithEvents optDontRecognize As System.Windows.Forms.RadioButton
    Friend WithEvents optWrite As System.Windows.Forms.RadioButton
    Friend WithEvents optWave As System.Windows.Forms.RadioButton
    Friend WithEvents optApplaud As System.Windows.Forms.RadioButton
    Friend WithEvents optSurprised As System.Windows.Forms.RadioButton
    Friend WithEvents optSuggest As System.Windows.Forms.RadioButton
    Friend WithEvents optAnnounce As System.Windows.Forms.RadioButton
    Friend WithEvents optDoMagic As System.Windows.Forms.RadioButton
    Friend WithEvents optExplain As System.Windows.Forms.RadioButton
    Friend WithEvents optCongrats As System.Windows.Forms.RadioButton
    Friend WithEvents txtSpeak As System.Windows.Forms.TextBox
    Friend WithEvents chkMerlinHide As System.Windows.Forms.CheckBox
    Friend WithEvents rtfDocument As System.Windows.Forms.RichTextBox
    Friend WithEvents grdMenu As System.Windows.Forms.DataGrid
    Friend WithEvents pgeWizard As System.Windows.Forms.TabPage
    Friend WithEvents pgeWord As System.Windows.Forms.TabPage
    Friend WithEvents pgeExcel As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tabOfficeDemo = New System.Windows.Forms.TabControl()
        Me.pgeWizard = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optDontRecognize = New System.Windows.Forms.RadioButton()
        Me.optWrite = New System.Windows.Forms.RadioButton()
        Me.optWave = New System.Windows.Forms.RadioButton()
        Me.optApplaud = New System.Windows.Forms.RadioButton()
        Me.optSurprised = New System.Windows.Forms.RadioButton()
        Me.optSuggest = New System.Windows.Forms.RadioButton()
        Me.optAnnounce = New System.Windows.Forms.RadioButton()
        Me.optDoMagic = New System.Windows.Forms.RadioButton()
        Me.optExplain = New System.Windows.Forms.RadioButton()
        Me.optCongrats = New System.Windows.Forms.RadioButton()
        Me.btnSpeak = New System.Windows.Forms.Button()
        Me.txtSpeak = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgeWord = New System.Windows.Forms.TabPage()
        Me.btnSpellCheck = New System.Windows.Forms.Button()
        Me.rtfDocument = New System.Windows.Forms.RichTextBox()
        Me.btnBrowseWord = New System.Windows.Forms.Button()
        Me.pgeExcel = New System.Windows.Forms.TabPage()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnGetMenu = New System.Windows.Forms.Button()
        Me.grdMenu = New System.Windows.Forms.DataGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dlgOpenWordFile = New System.Windows.Forms.OpenFileDialog()
        Me.chkMerlinHide = New System.Windows.Forms.CheckBox()
        Me.tabOfficeDemo.SuspendLayout()
        Me.pgeWizard.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pgeWord.SuspendLayout()
        Me.pgeExcel.SuspendLayout()
        CType(Me.grdMenu, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'tabOfficeDemo
        '
        Me.tabOfficeDemo.AccessibleDescription = CType(resources.GetObject("tabOfficeDemo.AccessibleDescription"), String)
        Me.tabOfficeDemo.AccessibleName = CType(resources.GetObject("tabOfficeDemo.AccessibleName"), String)
        Me.tabOfficeDemo.Alignment = CType(resources.GetObject("tabOfficeDemo.Alignment"), System.Windows.Forms.TabAlignment)
        Me.tabOfficeDemo.Anchor = CType(resources.GetObject("tabOfficeDemo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tabOfficeDemo.Appearance = CType(resources.GetObject("tabOfficeDemo.Appearance"), System.Windows.Forms.TabAppearance)
        Me.tabOfficeDemo.BackgroundImage = CType(resources.GetObject("tabOfficeDemo.BackgroundImage"), System.Drawing.Image)
        Me.tabOfficeDemo.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeWizard, Me.pgeWord, Me.pgeExcel})
        Me.tabOfficeDemo.Dock = CType(resources.GetObject("tabOfficeDemo.Dock"), System.Windows.Forms.DockStyle)
        Me.tabOfficeDemo.Enabled = CType(resources.GetObject("tabOfficeDemo.Enabled"), Boolean)
        Me.tabOfficeDemo.Font = CType(resources.GetObject("tabOfficeDemo.Font"), System.Drawing.Font)
        Me.tabOfficeDemo.ImeMode = CType(resources.GetObject("tabOfficeDemo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tabOfficeDemo.ItemSize = CType(resources.GetObject("tabOfficeDemo.ItemSize"), System.Drawing.Size)
        Me.tabOfficeDemo.Location = CType(resources.GetObject("tabOfficeDemo.Location"), System.Drawing.Point)
        Me.tabOfficeDemo.Name = "tabOfficeDemo"
        Me.tabOfficeDemo.Padding = CType(resources.GetObject("tabOfficeDemo.Padding"), System.Drawing.Point)
        Me.tabOfficeDemo.RightToLeft = CType(resources.GetObject("tabOfficeDemo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tabOfficeDemo.SelectedIndex = 0
        Me.tabOfficeDemo.ShowToolTips = CType(resources.GetObject("tabOfficeDemo.ShowToolTips"), Boolean)
        Me.tabOfficeDemo.Size = CType(resources.GetObject("tabOfficeDemo.Size"), System.Drawing.Size)
        Me.tabOfficeDemo.TabIndex = CType(resources.GetObject("tabOfficeDemo.TabIndex"), Integer)
        Me.tabOfficeDemo.Text = resources.GetString("tabOfficeDemo.Text")
        Me.tabOfficeDemo.Visible = CType(resources.GetObject("tabOfficeDemo.Visible"), Boolean)
        '
        'pgeWizard
        '
        Me.pgeWizard.AccessibleDescription = resources.GetString("pgeWizard.AccessibleDescription")
        Me.pgeWizard.AccessibleName = resources.GetString("pgeWizard.AccessibleName")
        Me.pgeWizard.Anchor = CType(resources.GetObject("pgeWizard.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeWizard.AutoScroll = CType(resources.GetObject("pgeWizard.AutoScroll"), Boolean)
        Me.pgeWizard.AutoScrollMargin = CType(resources.GetObject("pgeWizard.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeWizard.AutoScrollMinSize = CType(resources.GetObject("pgeWizard.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeWizard.BackColor = System.Drawing.SystemColors.Control
        Me.pgeWizard.BackgroundImage = CType(resources.GetObject("pgeWizard.BackgroundImage"), System.Drawing.Image)
        Me.pgeWizard.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.btnSpeak, Me.txtSpeak, Me.Label2})
        Me.pgeWizard.Dock = CType(resources.GetObject("pgeWizard.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeWizard.Enabled = CType(resources.GetObject("pgeWizard.Enabled"), Boolean)
        Me.pgeWizard.Font = CType(resources.GetObject("pgeWizard.Font"), System.Drawing.Font)
        Me.pgeWizard.ImageIndex = CType(resources.GetObject("pgeWizard.ImageIndex"), Integer)
        Me.pgeWizard.ImeMode = CType(resources.GetObject("pgeWizard.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeWizard.Location = CType(resources.GetObject("pgeWizard.Location"), System.Drawing.Point)
        Me.pgeWizard.Name = "pgeWizard"
        Me.pgeWizard.RightToLeft = CType(resources.GetObject("pgeWizard.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeWizard.Size = CType(resources.GetObject("pgeWizard.Size"), System.Drawing.Size)
        Me.pgeWizard.TabIndex = CType(resources.GetObject("pgeWizard.TabIndex"), Integer)
        Me.pgeWizard.Text = resources.GetString("pgeWizard.Text")
        Me.pgeWizard.ToolTipText = resources.GetString("pgeWizard.ToolTipText")
        Me.pgeWizard.Visible = CType(resources.GetObject("pgeWizard.Visible"), Boolean)
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = resources.GetString("GroupBox1.AccessibleDescription")
        Me.GroupBox1.AccessibleName = resources.GetString("GroupBox1.AccessibleName")
        Me.GroupBox1.Anchor = CType(resources.GetObject("GroupBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.optDontRecognize, Me.optWrite, Me.optWave, Me.optApplaud, Me.optSurprised, Me.optSuggest, Me.optAnnounce, Me.optDoMagic, Me.optExplain, Me.optCongrats})
        Me.GroupBox1.Dock = CType(resources.GetObject("GroupBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.GroupBox1.Enabled = CType(resources.GetObject("GroupBox1.Enabled"), Boolean)
        Me.GroupBox1.Font = CType(resources.GetObject("GroupBox1.Font"), System.Drawing.Font)
        Me.GroupBox1.ImeMode = CType(resources.GetObject("GroupBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.GroupBox1.Location = CType(resources.GetObject("GroupBox1.Location"), System.Drawing.Point)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = CType(resources.GetObject("GroupBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.GroupBox1.Size = CType(resources.GetObject("GroupBox1.Size"), System.Drawing.Size)
        Me.GroupBox1.TabIndex = CType(resources.GetObject("GroupBox1.TabIndex"), Integer)
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = resources.GetString("GroupBox1.Text")
        Me.GroupBox1.Visible = CType(resources.GetObject("GroupBox1.Visible"), Boolean)
        '
        'optDontRecognize
        '
        Me.optDontRecognize.AccessibleDescription = resources.GetString("optDontRecognize.AccessibleDescription")
        Me.optDontRecognize.AccessibleName = resources.GetString("optDontRecognize.AccessibleName")
        Me.optDontRecognize.Anchor = CType(resources.GetObject("optDontRecognize.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optDontRecognize.Appearance = CType(resources.GetObject("optDontRecognize.Appearance"), System.Windows.Forms.Appearance)
        Me.optDontRecognize.BackgroundImage = CType(resources.GetObject("optDontRecognize.BackgroundImage"), System.Drawing.Image)
        Me.optDontRecognize.CheckAlign = CType(resources.GetObject("optDontRecognize.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optDontRecognize.Dock = CType(resources.GetObject("optDontRecognize.Dock"), System.Windows.Forms.DockStyle)
        Me.optDontRecognize.Enabled = CType(resources.GetObject("optDontRecognize.Enabled"), Boolean)
        Me.optDontRecognize.FlatStyle = CType(resources.GetObject("optDontRecognize.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optDontRecognize.Font = CType(resources.GetObject("optDontRecognize.Font"), System.Drawing.Font)
        Me.optDontRecognize.Image = CType(resources.GetObject("optDontRecognize.Image"), System.Drawing.Image)
        Me.optDontRecognize.ImageAlign = CType(resources.GetObject("optDontRecognize.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optDontRecognize.ImageIndex = CType(resources.GetObject("optDontRecognize.ImageIndex"), Integer)
        Me.optDontRecognize.ImeMode = CType(resources.GetObject("optDontRecognize.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optDontRecognize.Location = CType(resources.GetObject("optDontRecognize.Location"), System.Drawing.Point)
        Me.optDontRecognize.Name = "optDontRecognize"
        Me.optDontRecognize.RightToLeft = CType(resources.GetObject("optDontRecognize.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optDontRecognize.Size = CType(resources.GetObject("optDontRecognize.Size"), System.Drawing.Size)
        Me.optDontRecognize.TabIndex = CType(resources.GetObject("optDontRecognize.TabIndex"), Integer)
        Me.optDontRecognize.Tag = "DontRecognize"
        Me.optDontRecognize.Text = resources.GetString("optDontRecognize.Text")
        Me.optDontRecognize.TextAlign = CType(resources.GetObject("optDontRecognize.TextAlign"), System.Drawing.ContentAlignment)
        Me.optDontRecognize.Visible = CType(resources.GetObject("optDontRecognize.Visible"), Boolean)
        '
        'optWrite
        '
        Me.optWrite.AccessibleDescription = resources.GetString("optWrite.AccessibleDescription")
        Me.optWrite.AccessibleName = resources.GetString("optWrite.AccessibleName")
        Me.optWrite.Anchor = CType(resources.GetObject("optWrite.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optWrite.Appearance = CType(resources.GetObject("optWrite.Appearance"), System.Windows.Forms.Appearance)
        Me.optWrite.BackgroundImage = CType(resources.GetObject("optWrite.BackgroundImage"), System.Drawing.Image)
        Me.optWrite.CheckAlign = CType(resources.GetObject("optWrite.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optWrite.Dock = CType(resources.GetObject("optWrite.Dock"), System.Windows.Forms.DockStyle)
        Me.optWrite.Enabled = CType(resources.GetObject("optWrite.Enabled"), Boolean)
        Me.optWrite.FlatStyle = CType(resources.GetObject("optWrite.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optWrite.Font = CType(resources.GetObject("optWrite.Font"), System.Drawing.Font)
        Me.optWrite.Image = CType(resources.GetObject("optWrite.Image"), System.Drawing.Image)
        Me.optWrite.ImageAlign = CType(resources.GetObject("optWrite.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optWrite.ImageIndex = CType(resources.GetObject("optWrite.ImageIndex"), Integer)
        Me.optWrite.ImeMode = CType(resources.GetObject("optWrite.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optWrite.Location = CType(resources.GetObject("optWrite.Location"), System.Drawing.Point)
        Me.optWrite.Name = "optWrite"
        Me.optWrite.RightToLeft = CType(resources.GetObject("optWrite.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optWrite.Size = CType(resources.GetObject("optWrite.Size"), System.Drawing.Size)
        Me.optWrite.TabIndex = CType(resources.GetObject("optWrite.TabIndex"), Integer)
        Me.optWrite.Tag = "Write"
        Me.optWrite.Text = resources.GetString("optWrite.Text")
        Me.optWrite.TextAlign = CType(resources.GetObject("optWrite.TextAlign"), System.Drawing.ContentAlignment)
        Me.optWrite.Visible = CType(resources.GetObject("optWrite.Visible"), Boolean)
        '
        'optWave
        '
        Me.optWave.AccessibleDescription = resources.GetString("optWave.AccessibleDescription")
        Me.optWave.AccessibleName = resources.GetString("optWave.AccessibleName")
        Me.optWave.Anchor = CType(resources.GetObject("optWave.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optWave.Appearance = CType(resources.GetObject("optWave.Appearance"), System.Windows.Forms.Appearance)
        Me.optWave.BackgroundImage = CType(resources.GetObject("optWave.BackgroundImage"), System.Drawing.Image)
        Me.optWave.CheckAlign = CType(resources.GetObject("optWave.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optWave.Dock = CType(resources.GetObject("optWave.Dock"), System.Windows.Forms.DockStyle)
        Me.optWave.Enabled = CType(resources.GetObject("optWave.Enabled"), Boolean)
        Me.optWave.FlatStyle = CType(resources.GetObject("optWave.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optWave.Font = CType(resources.GetObject("optWave.Font"), System.Drawing.Font)
        Me.optWave.Image = CType(resources.GetObject("optWave.Image"), System.Drawing.Image)
        Me.optWave.ImageAlign = CType(resources.GetObject("optWave.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optWave.ImageIndex = CType(resources.GetObject("optWave.ImageIndex"), Integer)
        Me.optWave.ImeMode = CType(resources.GetObject("optWave.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optWave.Location = CType(resources.GetObject("optWave.Location"), System.Drawing.Point)
        Me.optWave.Name = "optWave"
        Me.optWave.RightToLeft = CType(resources.GetObject("optWave.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optWave.Size = CType(resources.GetObject("optWave.Size"), System.Drawing.Size)
        Me.optWave.TabIndex = CType(resources.GetObject("optWave.TabIndex"), Integer)
        Me.optWave.Tag = "Wave"
        Me.optWave.Text = resources.GetString("optWave.Text")
        Me.optWave.TextAlign = CType(resources.GetObject("optWave.TextAlign"), System.Drawing.ContentAlignment)
        Me.optWave.Visible = CType(resources.GetObject("optWave.Visible"), Boolean)
        '
        'optApplaud
        '
        Me.optApplaud.AccessibleDescription = resources.GetString("optApplaud.AccessibleDescription")
        Me.optApplaud.AccessibleName = resources.GetString("optApplaud.AccessibleName")
        Me.optApplaud.Anchor = CType(resources.GetObject("optApplaud.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optApplaud.Appearance = CType(resources.GetObject("optApplaud.Appearance"), System.Windows.Forms.Appearance)
        Me.optApplaud.BackgroundImage = CType(resources.GetObject("optApplaud.BackgroundImage"), System.Drawing.Image)
        Me.optApplaud.CheckAlign = CType(resources.GetObject("optApplaud.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optApplaud.Dock = CType(resources.GetObject("optApplaud.Dock"), System.Windows.Forms.DockStyle)
        Me.optApplaud.Enabled = CType(resources.GetObject("optApplaud.Enabled"), Boolean)
        Me.optApplaud.FlatStyle = CType(resources.GetObject("optApplaud.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optApplaud.Font = CType(resources.GetObject("optApplaud.Font"), System.Drawing.Font)
        Me.optApplaud.Image = CType(resources.GetObject("optApplaud.Image"), System.Drawing.Image)
        Me.optApplaud.ImageAlign = CType(resources.GetObject("optApplaud.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optApplaud.ImageIndex = CType(resources.GetObject("optApplaud.ImageIndex"), Integer)
        Me.optApplaud.ImeMode = CType(resources.GetObject("optApplaud.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optApplaud.Location = CType(resources.GetObject("optApplaud.Location"), System.Drawing.Point)
        Me.optApplaud.Name = "optApplaud"
        Me.optApplaud.RightToLeft = CType(resources.GetObject("optApplaud.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optApplaud.Size = CType(resources.GetObject("optApplaud.Size"), System.Drawing.Size)
        Me.optApplaud.TabIndex = CType(resources.GetObject("optApplaud.TabIndex"), Integer)
        Me.optApplaud.Tag = "Applaud"
        Me.optApplaud.Text = resources.GetString("optApplaud.Text")
        Me.optApplaud.TextAlign = CType(resources.GetObject("optApplaud.TextAlign"), System.Drawing.ContentAlignment)
        Me.optApplaud.Visible = CType(resources.GetObject("optApplaud.Visible"), Boolean)
        '
        'optSurprised
        '
        Me.optSurprised.AccessibleDescription = resources.GetString("optSurprised.AccessibleDescription")
        Me.optSurprised.AccessibleName = resources.GetString("optSurprised.AccessibleName")
        Me.optSurprised.Anchor = CType(resources.GetObject("optSurprised.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optSurprised.Appearance = CType(resources.GetObject("optSurprised.Appearance"), System.Windows.Forms.Appearance)
        Me.optSurprised.BackgroundImage = CType(resources.GetObject("optSurprised.BackgroundImage"), System.Drawing.Image)
        Me.optSurprised.CheckAlign = CType(resources.GetObject("optSurprised.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optSurprised.Dock = CType(resources.GetObject("optSurprised.Dock"), System.Windows.Forms.DockStyle)
        Me.optSurprised.Enabled = CType(resources.GetObject("optSurprised.Enabled"), Boolean)
        Me.optSurprised.FlatStyle = CType(resources.GetObject("optSurprised.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optSurprised.Font = CType(resources.GetObject("optSurprised.Font"), System.Drawing.Font)
        Me.optSurprised.Image = CType(resources.GetObject("optSurprised.Image"), System.Drawing.Image)
        Me.optSurprised.ImageAlign = CType(resources.GetObject("optSurprised.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optSurprised.ImageIndex = CType(resources.GetObject("optSurprised.ImageIndex"), Integer)
        Me.optSurprised.ImeMode = CType(resources.GetObject("optSurprised.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optSurprised.Location = CType(resources.GetObject("optSurprised.Location"), System.Drawing.Point)
        Me.optSurprised.Name = "optSurprised"
        Me.optSurprised.RightToLeft = CType(resources.GetObject("optSurprised.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optSurprised.Size = CType(resources.GetObject("optSurprised.Size"), System.Drawing.Size)
        Me.optSurprised.TabIndex = CType(resources.GetObject("optSurprised.TabIndex"), Integer)
        Me.optSurprised.Tag = "Surprised"
        Me.optSurprised.Text = resources.GetString("optSurprised.Text")
        Me.optSurprised.TextAlign = CType(resources.GetObject("optSurprised.TextAlign"), System.Drawing.ContentAlignment)
        Me.optSurprised.Visible = CType(resources.GetObject("optSurprised.Visible"), Boolean)
        '
        'optSuggest
        '
        Me.optSuggest.AccessibleDescription = resources.GetString("optSuggest.AccessibleDescription")
        Me.optSuggest.AccessibleName = resources.GetString("optSuggest.AccessibleName")
        Me.optSuggest.Anchor = CType(resources.GetObject("optSuggest.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optSuggest.Appearance = CType(resources.GetObject("optSuggest.Appearance"), System.Windows.Forms.Appearance)
        Me.optSuggest.BackgroundImage = CType(resources.GetObject("optSuggest.BackgroundImage"), System.Drawing.Image)
        Me.optSuggest.CheckAlign = CType(resources.GetObject("optSuggest.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optSuggest.Dock = CType(resources.GetObject("optSuggest.Dock"), System.Windows.Forms.DockStyle)
        Me.optSuggest.Enabled = CType(resources.GetObject("optSuggest.Enabled"), Boolean)
        Me.optSuggest.FlatStyle = CType(resources.GetObject("optSuggest.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optSuggest.Font = CType(resources.GetObject("optSuggest.Font"), System.Drawing.Font)
        Me.optSuggest.Image = CType(resources.GetObject("optSuggest.Image"), System.Drawing.Image)
        Me.optSuggest.ImageAlign = CType(resources.GetObject("optSuggest.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optSuggest.ImageIndex = CType(resources.GetObject("optSuggest.ImageIndex"), Integer)
        Me.optSuggest.ImeMode = CType(resources.GetObject("optSuggest.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optSuggest.Location = CType(resources.GetObject("optSuggest.Location"), System.Drawing.Point)
        Me.optSuggest.Name = "optSuggest"
        Me.optSuggest.RightToLeft = CType(resources.GetObject("optSuggest.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optSuggest.Size = CType(resources.GetObject("optSuggest.Size"), System.Drawing.Size)
        Me.optSuggest.TabIndex = CType(resources.GetObject("optSuggest.TabIndex"), Integer)
        Me.optSuggest.Tag = "Suggest"
        Me.optSuggest.Text = resources.GetString("optSuggest.Text")
        Me.optSuggest.TextAlign = CType(resources.GetObject("optSuggest.TextAlign"), System.Drawing.ContentAlignment)
        Me.optSuggest.Visible = CType(resources.GetObject("optSuggest.Visible"), Boolean)
        '
        'optAnnounce
        '
        Me.optAnnounce.AccessibleDescription = resources.GetString("optAnnounce.AccessibleDescription")
        Me.optAnnounce.AccessibleName = resources.GetString("optAnnounce.AccessibleName")
        Me.optAnnounce.Anchor = CType(resources.GetObject("optAnnounce.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optAnnounce.Appearance = CType(resources.GetObject("optAnnounce.Appearance"), System.Windows.Forms.Appearance)
        Me.optAnnounce.BackgroundImage = CType(resources.GetObject("optAnnounce.BackgroundImage"), System.Drawing.Image)
        Me.optAnnounce.CheckAlign = CType(resources.GetObject("optAnnounce.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optAnnounce.Dock = CType(resources.GetObject("optAnnounce.Dock"), System.Windows.Forms.DockStyle)
        Me.optAnnounce.Enabled = CType(resources.GetObject("optAnnounce.Enabled"), Boolean)
        Me.optAnnounce.FlatStyle = CType(resources.GetObject("optAnnounce.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optAnnounce.Font = CType(resources.GetObject("optAnnounce.Font"), System.Drawing.Font)
        Me.optAnnounce.Image = CType(resources.GetObject("optAnnounce.Image"), System.Drawing.Image)
        Me.optAnnounce.ImageAlign = CType(resources.GetObject("optAnnounce.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optAnnounce.ImageIndex = CType(resources.GetObject("optAnnounce.ImageIndex"), Integer)
        Me.optAnnounce.ImeMode = CType(resources.GetObject("optAnnounce.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optAnnounce.Location = CType(resources.GetObject("optAnnounce.Location"), System.Drawing.Point)
        Me.optAnnounce.Name = "optAnnounce"
        Me.optAnnounce.RightToLeft = CType(resources.GetObject("optAnnounce.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optAnnounce.Size = CType(resources.GetObject("optAnnounce.Size"), System.Drawing.Size)
        Me.optAnnounce.TabIndex = CType(resources.GetObject("optAnnounce.TabIndex"), Integer)
        Me.optAnnounce.Tag = "Announce"
        Me.optAnnounce.Text = resources.GetString("optAnnounce.Text")
        Me.optAnnounce.TextAlign = CType(resources.GetObject("optAnnounce.TextAlign"), System.Drawing.ContentAlignment)
        Me.optAnnounce.Visible = CType(resources.GetObject("optAnnounce.Visible"), Boolean)
        '
        'optDoMagic
        '
        Me.optDoMagic.AccessibleDescription = resources.GetString("optDoMagic.AccessibleDescription")
        Me.optDoMagic.AccessibleName = resources.GetString("optDoMagic.AccessibleName")
        Me.optDoMagic.Anchor = CType(resources.GetObject("optDoMagic.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optDoMagic.Appearance = CType(resources.GetObject("optDoMagic.Appearance"), System.Windows.Forms.Appearance)
        Me.optDoMagic.BackgroundImage = CType(resources.GetObject("optDoMagic.BackgroundImage"), System.Drawing.Image)
        Me.optDoMagic.CheckAlign = CType(resources.GetObject("optDoMagic.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optDoMagic.Dock = CType(resources.GetObject("optDoMagic.Dock"), System.Windows.Forms.DockStyle)
        Me.optDoMagic.Enabled = CType(resources.GetObject("optDoMagic.Enabled"), Boolean)
        Me.optDoMagic.FlatStyle = CType(resources.GetObject("optDoMagic.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optDoMagic.Font = CType(resources.GetObject("optDoMagic.Font"), System.Drawing.Font)
        Me.optDoMagic.Image = CType(resources.GetObject("optDoMagic.Image"), System.Drawing.Image)
        Me.optDoMagic.ImageAlign = CType(resources.GetObject("optDoMagic.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optDoMagic.ImageIndex = CType(resources.GetObject("optDoMagic.ImageIndex"), Integer)
        Me.optDoMagic.ImeMode = CType(resources.GetObject("optDoMagic.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optDoMagic.Location = CType(resources.GetObject("optDoMagic.Location"), System.Drawing.Point)
        Me.optDoMagic.Name = "optDoMagic"
        Me.optDoMagic.RightToLeft = CType(resources.GetObject("optDoMagic.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optDoMagic.Size = CType(resources.GetObject("optDoMagic.Size"), System.Drawing.Size)
        Me.optDoMagic.TabIndex = CType(resources.GetObject("optDoMagic.TabIndex"), Integer)
        Me.optDoMagic.Tag = "GetAttention"
        Me.optDoMagic.Text = resources.GetString("optDoMagic.Text")
        Me.optDoMagic.TextAlign = CType(resources.GetObject("optDoMagic.TextAlign"), System.Drawing.ContentAlignment)
        Me.optDoMagic.Visible = CType(resources.GetObject("optDoMagic.Visible"), Boolean)
        '
        'optExplain
        '
        Me.optExplain.AccessibleDescription = resources.GetString("optExplain.AccessibleDescription")
        Me.optExplain.AccessibleName = resources.GetString("optExplain.AccessibleName")
        Me.optExplain.Anchor = CType(resources.GetObject("optExplain.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optExplain.Appearance = CType(resources.GetObject("optExplain.Appearance"), System.Windows.Forms.Appearance)
        Me.optExplain.BackgroundImage = CType(resources.GetObject("optExplain.BackgroundImage"), System.Drawing.Image)
        Me.optExplain.CheckAlign = CType(resources.GetObject("optExplain.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optExplain.Dock = CType(resources.GetObject("optExplain.Dock"), System.Windows.Forms.DockStyle)
        Me.optExplain.Enabled = CType(resources.GetObject("optExplain.Enabled"), Boolean)
        Me.optExplain.FlatStyle = CType(resources.GetObject("optExplain.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optExplain.Font = CType(resources.GetObject("optExplain.Font"), System.Drawing.Font)
        Me.optExplain.Image = CType(resources.GetObject("optExplain.Image"), System.Drawing.Image)
        Me.optExplain.ImageAlign = CType(resources.GetObject("optExplain.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optExplain.ImageIndex = CType(resources.GetObject("optExplain.ImageIndex"), Integer)
        Me.optExplain.ImeMode = CType(resources.GetObject("optExplain.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optExplain.Location = CType(resources.GetObject("optExplain.Location"), System.Drawing.Point)
        Me.optExplain.Name = "optExplain"
        Me.optExplain.RightToLeft = CType(resources.GetObject("optExplain.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optExplain.Size = CType(resources.GetObject("optExplain.Size"), System.Drawing.Size)
        Me.optExplain.TabIndex = CType(resources.GetObject("optExplain.TabIndex"), Integer)
        Me.optExplain.Tag = "Explain"
        Me.optExplain.Text = resources.GetString("optExplain.Text")
        Me.optExplain.TextAlign = CType(resources.GetObject("optExplain.TextAlign"), System.Drawing.ContentAlignment)
        Me.optExplain.Visible = CType(resources.GetObject("optExplain.Visible"), Boolean)
        '
        'optCongrats
        '
        Me.optCongrats.AccessibleDescription = resources.GetString("optCongrats.AccessibleDescription")
        Me.optCongrats.AccessibleName = resources.GetString("optCongrats.AccessibleName")
        Me.optCongrats.Anchor = CType(resources.GetObject("optCongrats.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optCongrats.Appearance = CType(resources.GetObject("optCongrats.Appearance"), System.Windows.Forms.Appearance)
        Me.optCongrats.BackgroundImage = CType(resources.GetObject("optCongrats.BackgroundImage"), System.Drawing.Image)
        Me.optCongrats.CheckAlign = CType(resources.GetObject("optCongrats.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optCongrats.Dock = CType(resources.GetObject("optCongrats.Dock"), System.Windows.Forms.DockStyle)
        Me.optCongrats.Enabled = CType(resources.GetObject("optCongrats.Enabled"), Boolean)
        Me.optCongrats.FlatStyle = CType(resources.GetObject("optCongrats.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optCongrats.Font = CType(resources.GetObject("optCongrats.Font"), System.Drawing.Font)
        Me.optCongrats.Image = CType(resources.GetObject("optCongrats.Image"), System.Drawing.Image)
        Me.optCongrats.ImageAlign = CType(resources.GetObject("optCongrats.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optCongrats.ImageIndex = CType(resources.GetObject("optCongrats.ImageIndex"), Integer)
        Me.optCongrats.ImeMode = CType(resources.GetObject("optCongrats.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optCongrats.Location = CType(resources.GetObject("optCongrats.Location"), System.Drawing.Point)
        Me.optCongrats.Name = "optCongrats"
        Me.optCongrats.RightToLeft = CType(resources.GetObject("optCongrats.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optCongrats.Size = CType(resources.GetObject("optCongrats.Size"), System.Drawing.Size)
        Me.optCongrats.TabIndex = CType(resources.GetObject("optCongrats.TabIndex"), Integer)
        Me.optCongrats.Tag = "Congratulate"
        Me.optCongrats.Text = resources.GetString("optCongrats.Text")
        Me.optCongrats.TextAlign = CType(resources.GetObject("optCongrats.TextAlign"), System.Drawing.ContentAlignment)
        Me.optCongrats.Visible = CType(resources.GetObject("optCongrats.Visible"), Boolean)
        '
        'btnSpeak
        '
        Me.btnSpeak.AccessibleDescription = resources.GetString("btnSpeak.AccessibleDescription")
        Me.btnSpeak.AccessibleName = resources.GetString("btnSpeak.AccessibleName")
        Me.btnSpeak.Anchor = CType(resources.GetObject("btnSpeak.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSpeak.BackColor = System.Drawing.SystemColors.Control
        Me.btnSpeak.BackgroundImage = CType(resources.GetObject("btnSpeak.BackgroundImage"), System.Drawing.Image)
        Me.btnSpeak.Dock = CType(resources.GetObject("btnSpeak.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSpeak.Enabled = CType(resources.GetObject("btnSpeak.Enabled"), Boolean)
        Me.btnSpeak.FlatStyle = CType(resources.GetObject("btnSpeak.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSpeak.Font = CType(resources.GetObject("btnSpeak.Font"), System.Drawing.Font)
        Me.btnSpeak.Image = CType(resources.GetObject("btnSpeak.Image"), System.Drawing.Image)
        Me.btnSpeak.ImageAlign = CType(resources.GetObject("btnSpeak.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSpeak.ImageIndex = CType(resources.GetObject("btnSpeak.ImageIndex"), Integer)
        Me.btnSpeak.ImeMode = CType(resources.GetObject("btnSpeak.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSpeak.Location = CType(resources.GetObject("btnSpeak.Location"), System.Drawing.Point)
        Me.btnSpeak.Name = "btnSpeak"
        Me.btnSpeak.RightToLeft = CType(resources.GetObject("btnSpeak.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSpeak.Size = CType(resources.GetObject("btnSpeak.Size"), System.Drawing.Size)
        Me.btnSpeak.TabIndex = CType(resources.GetObject("btnSpeak.TabIndex"), Integer)
        Me.btnSpeak.Text = resources.GetString("btnSpeak.Text")
        Me.btnSpeak.TextAlign = CType(resources.GetObject("btnSpeak.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSpeak.Visible = CType(resources.GetObject("btnSpeak.Visible"), Boolean)
        '
        'txtSpeak
        '
        Me.txtSpeak.AccessibleDescription = resources.GetString("txtSpeak.AccessibleDescription")
        Me.txtSpeak.AccessibleName = resources.GetString("txtSpeak.AccessibleName")
        Me.txtSpeak.Anchor = CType(resources.GetObject("txtSpeak.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtSpeak.AutoSize = CType(resources.GetObject("txtSpeak.AutoSize"), Boolean)
        Me.txtSpeak.BackgroundImage = CType(resources.GetObject("txtSpeak.BackgroundImage"), System.Drawing.Image)
        Me.txtSpeak.Dock = CType(resources.GetObject("txtSpeak.Dock"), System.Windows.Forms.DockStyle)
        Me.txtSpeak.Enabled = CType(resources.GetObject("txtSpeak.Enabled"), Boolean)
        Me.txtSpeak.Font = CType(resources.GetObject("txtSpeak.Font"), System.Drawing.Font)
        Me.txtSpeak.ImeMode = CType(resources.GetObject("txtSpeak.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtSpeak.Location = CType(resources.GetObject("txtSpeak.Location"), System.Drawing.Point)
        Me.txtSpeak.MaxLength = CType(resources.GetObject("txtSpeak.MaxLength"), Integer)
        Me.txtSpeak.Multiline = CType(resources.GetObject("txtSpeak.Multiline"), Boolean)
        Me.txtSpeak.Name = "txtSpeak"
        Me.txtSpeak.PasswordChar = CType(resources.GetObject("txtSpeak.PasswordChar"), Char)
        Me.txtSpeak.RightToLeft = CType(resources.GetObject("txtSpeak.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtSpeak.ScrollBars = CType(resources.GetObject("txtSpeak.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtSpeak.Size = CType(resources.GetObject("txtSpeak.Size"), System.Drawing.Size)
        Me.txtSpeak.TabIndex = CType(resources.GetObject("txtSpeak.TabIndex"), Integer)
        Me.txtSpeak.Text = resources.GetString("txtSpeak.Text")
        Me.txtSpeak.TextAlign = CType(resources.GetObject("txtSpeak.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtSpeak.Visible = CType(resources.GetObject("txtSpeak.Visible"), Boolean)
        Me.txtSpeak.WordWrap = CType(resources.GetObject("txtSpeak.WordWrap"), Boolean)
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
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
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
        'pgeWord
        '
        Me.pgeWord.AccessibleDescription = resources.GetString("pgeWord.AccessibleDescription")
        Me.pgeWord.AccessibleName = resources.GetString("pgeWord.AccessibleName")
        Me.pgeWord.Anchor = CType(resources.GetObject("pgeWord.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeWord.AutoScroll = CType(resources.GetObject("pgeWord.AutoScroll"), Boolean)
        Me.pgeWord.AutoScrollMargin = CType(resources.GetObject("pgeWord.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeWord.AutoScrollMinSize = CType(resources.GetObject("pgeWord.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeWord.BackColor = System.Drawing.SystemColors.Control
        Me.pgeWord.BackgroundImage = CType(resources.GetObject("pgeWord.BackgroundImage"), System.Drawing.Image)
        Me.pgeWord.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSpellCheck, Me.rtfDocument, Me.btnBrowseWord})
        Me.pgeWord.Dock = CType(resources.GetObject("pgeWord.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeWord.Enabled = CType(resources.GetObject("pgeWord.Enabled"), Boolean)
        Me.pgeWord.Font = CType(resources.GetObject("pgeWord.Font"), System.Drawing.Font)
        Me.pgeWord.ImageIndex = CType(resources.GetObject("pgeWord.ImageIndex"), Integer)
        Me.pgeWord.ImeMode = CType(resources.GetObject("pgeWord.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeWord.Location = CType(resources.GetObject("pgeWord.Location"), System.Drawing.Point)
        Me.pgeWord.Name = "pgeWord"
        Me.pgeWord.RightToLeft = CType(resources.GetObject("pgeWord.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeWord.Size = CType(resources.GetObject("pgeWord.Size"), System.Drawing.Size)
        Me.pgeWord.TabIndex = CType(resources.GetObject("pgeWord.TabIndex"), Integer)
        Me.pgeWord.Text = resources.GetString("pgeWord.Text")
        Me.pgeWord.ToolTipText = resources.GetString("pgeWord.ToolTipText")
        Me.pgeWord.Visible = CType(resources.GetObject("pgeWord.Visible"), Boolean)
        '
        'btnSpellCheck
        '
        Me.btnSpellCheck.AccessibleDescription = resources.GetString("btnSpellCheck.AccessibleDescription")
        Me.btnSpellCheck.AccessibleName = resources.GetString("btnSpellCheck.AccessibleName")
        Me.btnSpellCheck.Anchor = CType(resources.GetObject("btnSpellCheck.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSpellCheck.BackColor = System.Drawing.SystemColors.Control
        Me.btnSpellCheck.BackgroundImage = CType(resources.GetObject("btnSpellCheck.BackgroundImage"), System.Drawing.Image)
        Me.btnSpellCheck.Dock = CType(resources.GetObject("btnSpellCheck.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSpellCheck.Enabled = CType(resources.GetObject("btnSpellCheck.Enabled"), Boolean)
        Me.btnSpellCheck.FlatStyle = CType(resources.GetObject("btnSpellCheck.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSpellCheck.Font = CType(resources.GetObject("btnSpellCheck.Font"), System.Drawing.Font)
        Me.btnSpellCheck.Image = CType(resources.GetObject("btnSpellCheck.Image"), System.Drawing.Image)
        Me.btnSpellCheck.ImageAlign = CType(resources.GetObject("btnSpellCheck.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSpellCheck.ImageIndex = CType(resources.GetObject("btnSpellCheck.ImageIndex"), Integer)
        Me.btnSpellCheck.ImeMode = CType(resources.GetObject("btnSpellCheck.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSpellCheck.Location = CType(resources.GetObject("btnSpellCheck.Location"), System.Drawing.Point)
        Me.btnSpellCheck.Name = "btnSpellCheck"
        Me.btnSpellCheck.RightToLeft = CType(resources.GetObject("btnSpellCheck.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSpellCheck.Size = CType(resources.GetObject("btnSpellCheck.Size"), System.Drawing.Size)
        Me.btnSpellCheck.TabIndex = CType(resources.GetObject("btnSpellCheck.TabIndex"), Integer)
        Me.btnSpellCheck.Text = resources.GetString("btnSpellCheck.Text")
        Me.btnSpellCheck.TextAlign = CType(resources.GetObject("btnSpellCheck.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSpellCheck.Visible = CType(resources.GetObject("btnSpellCheck.Visible"), Boolean)
        '
        'rtfDocument
        '
        Me.rtfDocument.AccessibleDescription = resources.GetString("rtfDocument.AccessibleDescription")
        Me.rtfDocument.AccessibleName = resources.GetString("rtfDocument.AccessibleName")
        Me.rtfDocument.Anchor = CType(resources.GetObject("rtfDocument.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rtfDocument.AutoSize = CType(resources.GetObject("rtfDocument.AutoSize"), Boolean)
        Me.rtfDocument.BackgroundImage = CType(resources.GetObject("rtfDocument.BackgroundImage"), System.Drawing.Image)
        Me.rtfDocument.BulletIndent = CType(resources.GetObject("rtfDocument.BulletIndent"), Integer)
        Me.rtfDocument.Dock = CType(resources.GetObject("rtfDocument.Dock"), System.Windows.Forms.DockStyle)
        Me.rtfDocument.Enabled = CType(resources.GetObject("rtfDocument.Enabled"), Boolean)
        Me.rtfDocument.Font = CType(resources.GetObject("rtfDocument.Font"), System.Drawing.Font)
        Me.rtfDocument.ImeMode = CType(resources.GetObject("rtfDocument.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rtfDocument.Location = CType(resources.GetObject("rtfDocument.Location"), System.Drawing.Point)
        Me.rtfDocument.MaxLength = CType(resources.GetObject("rtfDocument.MaxLength"), Integer)
        Me.rtfDocument.Multiline = CType(resources.GetObject("rtfDocument.Multiline"), Boolean)
        Me.rtfDocument.Name = "rtfDocument"
        Me.rtfDocument.RightMargin = CType(resources.GetObject("rtfDocument.RightMargin"), Integer)
        Me.rtfDocument.RightToLeft = CType(resources.GetObject("rtfDocument.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rtfDocument.ScrollBars = CType(resources.GetObject("rtfDocument.ScrollBars"), System.Windows.Forms.RichTextBoxScrollBars)
        Me.rtfDocument.Size = CType(resources.GetObject("rtfDocument.Size"), System.Drawing.Size)
        Me.rtfDocument.TabIndex = CType(resources.GetObject("rtfDocument.TabIndex"), Integer)
        Me.rtfDocument.Text = resources.GetString("rtfDocument.Text")
        Me.rtfDocument.Visible = CType(resources.GetObject("rtfDocument.Visible"), Boolean)
        Me.rtfDocument.WordWrap = CType(resources.GetObject("rtfDocument.WordWrap"), Boolean)
        Me.rtfDocument.ZoomFactor = CType(resources.GetObject("rtfDocument.ZoomFactor"), Single)
        '
        'btnBrowseWord
        '
        Me.btnBrowseWord.AccessibleDescription = resources.GetString("btnBrowseWord.AccessibleDescription")
        Me.btnBrowseWord.AccessibleName = resources.GetString("btnBrowseWord.AccessibleName")
        Me.btnBrowseWord.Anchor = CType(resources.GetObject("btnBrowseWord.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseWord.BackColor = System.Drawing.SystemColors.Control
        Me.btnBrowseWord.BackgroundImage = CType(resources.GetObject("btnBrowseWord.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowseWord.Dock = CType(resources.GetObject("btnBrowseWord.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBrowseWord.Enabled = CType(resources.GetObject("btnBrowseWord.Enabled"), Boolean)
        Me.btnBrowseWord.FlatStyle = CType(resources.GetObject("btnBrowseWord.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBrowseWord.Font = CType(resources.GetObject("btnBrowseWord.Font"), System.Drawing.Font)
        Me.btnBrowseWord.Image = CType(resources.GetObject("btnBrowseWord.Image"), System.Drawing.Image)
        Me.btnBrowseWord.ImageAlign = CType(resources.GetObject("btnBrowseWord.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBrowseWord.ImageIndex = CType(resources.GetObject("btnBrowseWord.ImageIndex"), Integer)
        Me.btnBrowseWord.ImeMode = CType(resources.GetObject("btnBrowseWord.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBrowseWord.Location = CType(resources.GetObject("btnBrowseWord.Location"), System.Drawing.Point)
        Me.btnBrowseWord.Name = "btnBrowseWord"
        Me.btnBrowseWord.RightToLeft = CType(resources.GetObject("btnBrowseWord.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBrowseWord.Size = CType(resources.GetObject("btnBrowseWord.Size"), System.Drawing.Size)
        Me.btnBrowseWord.TabIndex = CType(resources.GetObject("btnBrowseWord.TabIndex"), Integer)
        Me.btnBrowseWord.Text = resources.GetString("btnBrowseWord.Text")
        Me.btnBrowseWord.TextAlign = CType(resources.GetObject("btnBrowseWord.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBrowseWord.Visible = CType(resources.GetObject("btnBrowseWord.Visible"), Boolean)
        '
        'pgeExcel
        '
        Me.pgeExcel.AccessibleDescription = resources.GetString("pgeExcel.AccessibleDescription")
        Me.pgeExcel.AccessibleName = resources.GetString("pgeExcel.AccessibleName")
        Me.pgeExcel.Anchor = CType(resources.GetObject("pgeExcel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeExcel.AutoScroll = CType(resources.GetObject("pgeExcel.AutoScroll"), Boolean)
        Me.pgeExcel.AutoScrollMargin = CType(resources.GetObject("pgeExcel.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeExcel.AutoScrollMinSize = CType(resources.GetObject("pgeExcel.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeExcel.BackColor = System.Drawing.SystemColors.Control
        Me.pgeExcel.BackgroundImage = CType(resources.GetObject("pgeExcel.BackgroundImage"), System.Drawing.Image)
        Me.pgeExcel.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExport, Me.btnGetMenu, Me.grdMenu})
        Me.pgeExcel.Dock = CType(resources.GetObject("pgeExcel.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeExcel.Enabled = CType(resources.GetObject("pgeExcel.Enabled"), Boolean)
        Me.pgeExcel.Font = CType(resources.GetObject("pgeExcel.Font"), System.Drawing.Font)
        Me.pgeExcel.ImageIndex = CType(resources.GetObject("pgeExcel.ImageIndex"), Integer)
        Me.pgeExcel.ImeMode = CType(resources.GetObject("pgeExcel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeExcel.Location = CType(resources.GetObject("pgeExcel.Location"), System.Drawing.Point)
        Me.pgeExcel.Name = "pgeExcel"
        Me.pgeExcel.RightToLeft = CType(resources.GetObject("pgeExcel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeExcel.Size = CType(resources.GetObject("pgeExcel.Size"), System.Drawing.Size)
        Me.pgeExcel.TabIndex = CType(resources.GetObject("pgeExcel.TabIndex"), Integer)
        Me.pgeExcel.Text = resources.GetString("pgeExcel.Text")
        Me.pgeExcel.ToolTipText = resources.GetString("pgeExcel.ToolTipText")
        Me.pgeExcel.Visible = CType(resources.GetObject("pgeExcel.Visible"), Boolean)
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = resources.GetString("btnExport.AccessibleDescription")
        Me.btnExport.AccessibleName = resources.GetString("btnExport.AccessibleName")
        Me.btnExport.Anchor = CType(resources.GetObject("btnExport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.SystemColors.Control
        Me.btnExport.BackgroundImage = CType(resources.GetObject("btnExport.BackgroundImage"), System.Drawing.Image)
        Me.btnExport.Dock = CType(resources.GetObject("btnExport.Dock"), System.Windows.Forms.DockStyle)
        Me.btnExport.Enabled = CType(resources.GetObject("btnExport.Enabled"), Boolean)
        Me.btnExport.FlatStyle = CType(resources.GetObject("btnExport.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnExport.Font = CType(resources.GetObject("btnExport.Font"), System.Drawing.Font)
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageAlign = CType(resources.GetObject("btnExport.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnExport.ImageIndex = CType(resources.GetObject("btnExport.ImageIndex"), Integer)
        Me.btnExport.ImeMode = CType(resources.GetObject("btnExport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnExport.Location = CType(resources.GetObject("btnExport.Location"), System.Drawing.Point)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.RightToLeft = CType(resources.GetObject("btnExport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnExport.Size = CType(resources.GetObject("btnExport.Size"), System.Drawing.Size)
        Me.btnExport.TabIndex = CType(resources.GetObject("btnExport.TabIndex"), Integer)
        Me.btnExport.Text = resources.GetString("btnExport.Text")
        Me.btnExport.TextAlign = CType(resources.GetObject("btnExport.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnExport.Visible = CType(resources.GetObject("btnExport.Visible"), Boolean)
        '
        'btnGetMenu
        '
        Me.btnGetMenu.AccessibleDescription = resources.GetString("btnGetMenu.AccessibleDescription")
        Me.btnGetMenu.AccessibleName = resources.GetString("btnGetMenu.AccessibleName")
        Me.btnGetMenu.Anchor = CType(resources.GetObject("btnGetMenu.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetMenu.BackColor = System.Drawing.SystemColors.Control
        Me.btnGetMenu.BackgroundImage = CType(resources.GetObject("btnGetMenu.BackgroundImage"), System.Drawing.Image)
        Me.btnGetMenu.Dock = CType(resources.GetObject("btnGetMenu.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetMenu.Enabled = CType(resources.GetObject("btnGetMenu.Enabled"), Boolean)
        Me.btnGetMenu.FlatStyle = CType(resources.GetObject("btnGetMenu.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetMenu.Font = CType(resources.GetObject("btnGetMenu.Font"), System.Drawing.Font)
        Me.btnGetMenu.Image = CType(resources.GetObject("btnGetMenu.Image"), System.Drawing.Image)
        Me.btnGetMenu.ImageAlign = CType(resources.GetObject("btnGetMenu.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetMenu.ImageIndex = CType(resources.GetObject("btnGetMenu.ImageIndex"), Integer)
        Me.btnGetMenu.ImeMode = CType(resources.GetObject("btnGetMenu.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetMenu.Location = CType(resources.GetObject("btnGetMenu.Location"), System.Drawing.Point)
        Me.btnGetMenu.Name = "btnGetMenu"
        Me.btnGetMenu.RightToLeft = CType(resources.GetObject("btnGetMenu.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetMenu.Size = CType(resources.GetObject("btnGetMenu.Size"), System.Drawing.Size)
        Me.btnGetMenu.TabIndex = CType(resources.GetObject("btnGetMenu.TabIndex"), Integer)
        Me.btnGetMenu.Text = resources.GetString("btnGetMenu.Text")
        Me.btnGetMenu.TextAlign = CType(resources.GetObject("btnGetMenu.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetMenu.Visible = CType(resources.GetObject("btnGetMenu.Visible"), Boolean)
        '
        'grdMenu
        '
        Me.grdMenu.AccessibleDescription = resources.GetString("grdMenu.AccessibleDescription")
        Me.grdMenu.AccessibleName = resources.GetString("grdMenu.AccessibleName")
        Me.grdMenu.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.grdMenu.Anchor = CType(resources.GetObject("grdMenu.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdMenu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdMenu.BackgroundColor = System.Drawing.Color.LightGray
        Me.grdMenu.BackgroundImage = CType(resources.GetObject("grdMenu.BackgroundImage"), System.Drawing.Image)
        Me.grdMenu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdMenu.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMenu.CaptionFont = CType(resources.GetObject("grdMenu.CaptionFont"), System.Drawing.Font)
        Me.grdMenu.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.grdMenu.CaptionText = resources.GetString("grdMenu.CaptionText")
        Me.grdMenu.DataMember = ""
        Me.grdMenu.Dock = CType(resources.GetObject("grdMenu.Dock"), System.Windows.Forms.DockStyle)
        Me.grdMenu.Enabled = CType(resources.GetObject("grdMenu.Enabled"), Boolean)
        Me.grdMenu.FlatMode = True
        Me.grdMenu.Font = CType(resources.GetObject("grdMenu.Font"), System.Drawing.Font)
        Me.grdMenu.ForeColor = System.Drawing.Color.MidnightBlue
        Me.grdMenu.GridLineColor = System.Drawing.Color.Gainsboro
        Me.grdMenu.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdMenu.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdMenu.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdMenu.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdMenu.ImeMode = CType(resources.GetObject("grdMenu.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grdMenu.LinkColor = System.Drawing.Color.Teal
        Me.grdMenu.Location = CType(resources.GetObject("grdMenu.Location"), System.Drawing.Point)
        Me.grdMenu.Name = "grdMenu"
        Me.grdMenu.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdMenu.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.grdMenu.RightToLeft = CType(resources.GetObject("grdMenu.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grdMenu.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.grdMenu.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdMenu.Size = CType(resources.GetObject("grdMenu.Size"), System.Drawing.Size)
        Me.grdMenu.TabIndex = CType(resources.GetObject("grdMenu.TabIndex"), Integer)
        Me.grdMenu.Visible = CType(resources.GetObject("grdMenu.Visible"), Boolean)
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
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
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
        'dlgOpenWordFile
        '
        Me.dlgOpenWordFile.Filter = resources.GetString("dlgOpenWordFile.Filter")
        Me.dlgOpenWordFile.Title = resources.GetString("dlgOpenWordFile.Title")
        '
        'chkMerlinHide
        '
        Me.chkMerlinHide.AccessibleDescription = resources.GetString("chkMerlinHide.AccessibleDescription")
        Me.chkMerlinHide.AccessibleName = resources.GetString("chkMerlinHide.AccessibleName")
        Me.chkMerlinHide.Anchor = CType(resources.GetObject("chkMerlinHide.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkMerlinHide.Appearance = CType(resources.GetObject("chkMerlinHide.Appearance"), System.Windows.Forms.Appearance)
        Me.chkMerlinHide.BackgroundImage = CType(resources.GetObject("chkMerlinHide.BackgroundImage"), System.Drawing.Image)
        Me.chkMerlinHide.CheckAlign = CType(resources.GetObject("chkMerlinHide.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkMerlinHide.Dock = CType(resources.GetObject("chkMerlinHide.Dock"), System.Windows.Forms.DockStyle)
        Me.chkMerlinHide.Enabled = CType(resources.GetObject("chkMerlinHide.Enabled"), Boolean)
        Me.chkMerlinHide.FlatStyle = CType(resources.GetObject("chkMerlinHide.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkMerlinHide.Font = CType(resources.GetObject("chkMerlinHide.Font"), System.Drawing.Font)
        Me.chkMerlinHide.Image = CType(resources.GetObject("chkMerlinHide.Image"), System.Drawing.Image)
        Me.chkMerlinHide.ImageAlign = CType(resources.GetObject("chkMerlinHide.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkMerlinHide.ImageIndex = CType(resources.GetObject("chkMerlinHide.ImageIndex"), Integer)
        Me.chkMerlinHide.ImeMode = CType(resources.GetObject("chkMerlinHide.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkMerlinHide.Location = CType(resources.GetObject("chkMerlinHide.Location"), System.Drawing.Point)
        Me.chkMerlinHide.Name = "chkMerlinHide"
        Me.chkMerlinHide.RightToLeft = CType(resources.GetObject("chkMerlinHide.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkMerlinHide.Size = CType(resources.GetObject("chkMerlinHide.Size"), System.Drawing.Size)
        Me.chkMerlinHide.TabIndex = CType(resources.GetObject("chkMerlinHide.TabIndex"), Integer)
        Me.chkMerlinHide.Text = resources.GetString("chkMerlinHide.Text")
        Me.chkMerlinHide.TextAlign = CType(resources.GetObject("chkMerlinHide.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkMerlinHide.Visible = CType(resources.GetObject("chkMerlinHide.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkMerlinHide, Me.Label1, Me.tabOfficeDemo})
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
        Me.tabOfficeDemo.ResumeLayout(False)
        Me.pgeWizard.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pgeWord.ResumeLayout(False)
        Me.pgeExcel.ResumeLayout(False)
        CType(Me.grdMenu, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private agentController As AgentObjects.Agent
    Private agentCharacter As AgentObjects.IAgentCtlCharacter
    Private dsMenu As DataSet

    ' Handles the Browse button on the Word tab which allows the user to find a
    ' Text Format document on their hard drive and load it
    ' into the RichTextBox control.
    Private Sub btnBrowseWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseWord.Click
        With dlgOpenWordFile
            .InitialDirectory = "C:\"
            .Filter = "Text Format (*.txt)|*.txt"
            .FilterIndex = 1

            ' The OpenFileDialog control only has an Open button, not an OK button.
            ' However, there is no DialogResult.Open enum so use DialogResult.OK.
            If .ShowDialog() = DialogResult.OK Then
                Try
                    rtfDocument.LoadFile(.FileName, RichTextBoxStreamType.PlainText)
                Catch exp As ArgumentException
                    MessageBox.Show("The document you are attempting to load " & _
                        "is not in the correct format.", "Document Load Error", _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End With
    End Sub

    ' Handles the "Export to Excel >>" button click event, which allows the user to
    ' export the contents of the DataSet to an Excel spreadsheet and then run a
    ' simple Average function to determine the calorie average for all the foods.
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        ' An Excel spreadsheet involves a hierarchy of objects, from Application
        ' to Workbook to Worksheet.
        Dim excelApp As New Excel.Application()
        Dim excelBook As Excel.Workbook = excelApp.Workbooks.Add
        Dim excelWorksheet As Excel.Worksheet = _
            CType(excelBook.Worksheets(1), Excel.Worksheet)

        ' Unlike the Word demo, we'll make the spreadsheet visible so you can see
        ' the data being entered.
        excelApp.Visible = True

        With excelWorksheet
            ' Set the column headers and desired formatting for the spreadsheet.
            .Columns().ColumnWidth = 21.71
            .Range("A1").Value = "Item"
            .Range("A1").Font.Bold = True
            .Range("B1").Value = "Price"
            .Range("B1").Font.Bold = True
            .Range("C1").Value = "Calories"
            .Range("C1").Font.Bold = True

            ' Start the counter on the second row, following the column headers
            Dim i As Integer = 2
            ' Loop through the Rows collection of the DataSet and write the data
            ' in each row to the cells in Excel. 
            Dim dr As DataRow
            For Each dr In dsMenu.Tables(0).Rows
                .Range("A" & i.ToString).Value = dr("Item")
                .Range("B" & i.ToString).Value = dr("Price")
                .Range("C" & i.ToString).Value = dr("Calories")
                i += 1
            Next

            ' Select and apply formatting to the cell that will display the calorie
            ' average, then call the Average formula.
            .Range("C7").Select()
            .Range("C7").Font.Color = RGB(255, 0, 0)
            .Range("C7").Font.Bold = True
            excelApp.ActiveCell.FormulaR1C1 = "=AVERAGE(R[-5]C:R[-1]C)"
        End With

    End Sub

    ' Handles the "Get Menu" button click event, which creates and fills a DataSet
    ' from an XML document, loads it into a DataGrid, and then applies custom
    ' formatting to the DataGrid.
    Private Sub btnGetMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetMenu.Click
        ' Fill a DataSet by loading an XML document with items from a fictitious 
        ' lunch menu.
        dsMenu = New DataSet()
        dsMenu.ReadXml("..\menu.xml")

        ' Set the DataGrid caption and bind it to the DataSet.
        With grdMenu
            .CaptionText = "Today's Menu"
            .DataSource = dsMenu.Tables(0)
        End With

        ' Use a table style object to apply custom formatting to the DataGrid.
        Dim grdTableStyle1 As New DataGridTableStyle()
        With grdTableStyle1
            .AlternatingBackColor = Color.Lavender
            .BackColor = Color.WhiteSmoke
            .ForeColor = Color.MidnightBlue
            .GridLineColor = Color.Gainsboro
            .GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
            .HeaderBackColor = Color.MidnightBlue
            .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
            .HeaderForeColor = Color.WhiteSmoke
            .LinkColor = Color.Teal
            ' Do not forget to set the MappingName property. 
            ' Without this, the DataGridTableStyle properties
            ' and any associated DataGridColumnStyle objects
            ' will have no effect.
            .MappingName = "Food"
            .SelectionBackColor = Color.CadetBlue
            .SelectionForeColor = Color.WhiteSmoke
        End With

        ' Use column style objects to apply formatting specific to each column.
        Dim grdColStyle1 As New DataGridTextBoxColumn()
        With grdColStyle1
            .HeaderText = "Item"
            .MappingName = "Item"
            .Width = 125
        End With

        Dim grdColStyle2 As New DataGridTextBoxColumn()
        With grdColStyle2
            .HeaderText = "Price"
            .MappingName = "Price"
            .Width = 50
        End With

        Dim grdColStyle3 As New DataGridTextBoxColumn()
        With grdColStyle3
            .HeaderText = "Calories"
            .MappingName = "Calories"
            .Width = 70
        End With

        ' Add the column style objects to the tables style's column styles 
        ' collection. If you fail to do this the column styles will not apply.
        grdTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {grdColStyle1, grdColStyle2, grdColStyle3})
        ' Again, failure to add the style to the collection will cause the style
        ' to not take effect.
        grdMenu.TableStyles.Add(grdTableStyle1)

        ' Now that the DataGrid is filled it is appropriate to show the button
        ' that will allow the user to export the contents of the DataSet to 
        ' an Excel spreadsheet.
        btnExport.Visible = True
    End Sub

    ' Handles the Speak button click event, which makes Merlin say whatever the
    ' user enters into the TextBox.
    Private Sub btnSpeak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeak.Click
        agentCharacter.Speak(txtSpeak.Text)
    End Sub

    ' Handles the Spellcheck button click event, allowing the user to run the Word
    ' spellchecker against whatever text is in the RichTextBox control. Notice that
    ' Word never needs to be seen.
    '
    ' This method simply displays a dialog box.  However you could also leverage 
    ' this functionality to create a more feature  rich application that mimics the
    ' Word spell checker (allows the use of custom dictionaries etc.)
    Private Sub btnSpellCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpellCheck.Click
        Dim wordApp As New Word.Application()
        Dim bolHasNoSpellingErrors As Boolean = _
            wordApp.CheckSpelling(rtfDocument.Text)
        Dim strSpellCheck As String = "Your document has spelling errors."

        If bolHasNoSpellingErrors Then
            strSpellCheck = "Congratulations, your document " & _
                "is free of spelling errors."
        End If

        MessageBox.Show(strSpellCheck, "Spell Check Results", _
            MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Handles the CheckChanged event for the checkbox that hides or shows Merlin.
    Private Sub chkMerlinOnOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMerlinHide.CheckedChanged
        With agentCharacter
            If chkMerlinHide.Checked Then
                ' Animations load into a queue and will play out before the next
                ' command is executed. If you want Merlin to hide immediately when
                ' the CheckBox is checked, you must call StopAll.
                .StopAll()
                .Hide()
            Else
                .Show()
            End If
        End With
    End Sub

    ' Handles the Form load event, which fires when the form is first loaded.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' The Agent object is used to open a connection to the Agent server,
        ' load the character, and then associate the character with the 
        ' variable referencing the IAgentCtlCharacter interface. From then
        ' on you program against the agentCharacter.
        agentController = New AgentObjects.Agent()
        With agentController
            .Connected = True
            .Characters.Load("merlin", "merlin.acs")
            agentCharacter = .Characters("merlin")
        End With

        ' Use the Location property to place Merlin relative to the upper left 
        ' corner of the Form. 
        With agentCharacter
            .MoveTo(CShort(Me.Location.X + 420), CShort(Me.Location.Y + 130))
            .Show()
            .Play("Announce")
            .Speak("Hello, my name is Merlin. " & _
                "Welcome to the Office Automation Demo!")
            .Play("GestureRight")
            ' You can make Merlin's speech sound more natural by inserting speech
            ' output tags like Pau (Pause), Chr (Character of the Voice), 
            ' Emp (Emphasis) or Spd (Speed). Surround each name-value pair with a
            ' backslash character. 
            .Speak("Make me say something,\pau=300\or\pau=500\...")
            .MoveTo(CShort(Me.Location.X + 340), CShort(Me.Location.Y + 250))
            .Play("GestureRight")
            .Speak("...try out some of my animations.")
        End With

        ' Hide the "Export to Excel>>" Button on the Excel tab until the 
        ' DataGrid is databound.
        btnExport.Visible = False
    End Sub

    ' Handles the click events of all the Merlin animations.
    Private Sub rdoAnimations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDontRecognize.Click, optWrite.Click, optWave.Click, optApplaud.Click, optSurprised.Click, optSuggest.Click, optAnnounce.Click, optDoMagic.Click, optExplain.Click, optCongrats.Click
        ' Have Merlin immediately cease what he is doing when the user selects a 
        ' new animation, or else the animations will stack up in a queue and might
        ' appear not to work when selected.
        agentCharacter.StopAll()

        Dim radio As RadioButton = CType(sender, RadioButton)
        With agentCharacter
            Select Case radio.Tag
                Case "GetAttention"
                    ' Some animations require that you call a "Return" animation to
                    ' get Merlin to return to a natural state. Others have this 
                    ' return built in.
                    .Play("GetAttention")
                    .Play("GetAttentionReturn")
                Case "Explain"
                    .Play("Explain")
                Case "Congratulate"
                    .Play("Congratulate")
                Case "Announce"
                    .Play("Announce")
                Case "Applaud"
                    .Play("Congratulate_2")
                Case "DontRecognize"
                    .Play("DontRecognize")
                Case "Write"
                    .Play("Write")
                Case "Surprised"
                    .Play("Surprised")
                Case "Suggest"
                    .Play("Suggest")
                Case "Wave"
                    .Play("Wave")
            End Select
        End With
    End Sub

    ' Handles the TabControl's SelectedIndexChanged event, which fires when either
    ' the Word or Excel tabs are clicked. This moves Merlin out of the way of the
    ' user interface elements on these two tabs.
    Private Sub tabOfficeDemo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabOfficeDemo.SelectedIndexChanged
        If tabOfficeDemo.SelectedIndex <> 0 Then
            With agentCharacter
                .StopAll()
                .MoveTo(CShort(Me.Location.X + 340), CShort(Me.Location.Y + 40))
            End With
        End If
    End Sub

End Class