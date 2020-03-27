'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Net

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents pgeScreenScrape As System.Windows.Forms.TabPage
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblResultCount As System.Windows.Forms.Label
    Friend WithEvents chkShowCaptures As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowGroups As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents chkMultiline As System.Windows.Forms.CheckBox
    Friend WithEvents chkIgnoreCase As System.Windows.Forms.CheckBox
    Friend WithEvents btnSplit As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtReplace As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents pgeRegExTester As System.Windows.Forms.TabPage
    Friend WithEvents txtRegEx As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lvwImages As System.Windows.Forms.ListView
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents btnScrape As System.Windows.Forms.Button
    Friend WithEvents optImages As System.Windows.Forms.RadioButton
    Friend WithEvents optLinks As System.Windows.Forms.RadioButton
    Friend WithEvents lvcSrc As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcAlt As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcHeight As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcWidth As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwLinks As System.Windows.Forms.ListView
    Friend WithEvents lvcUrl As System.Windows.Forms.ColumnHeader
    Friend WithEvents pgeSimple As System.Windows.Forms.TabPage
    Friend WithEvents chkSingleLine As System.Windows.Forms.CheckBox
    Friend WithEvents grpValidation As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblResults As System.Windows.Forms.Label
    Friend WithEvents btnFindNumber As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFindNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblValid As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pgeSimple = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.btnFindNumber = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFindNumber = New System.Windows.Forms.TextBox()
        Me.grpValidation = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pgeScreenScrape = New System.Windows.Forms.TabPage()
        Me.optImages = New System.Windows.Forms.RadioButton()
        Me.optLinks = New System.Windows.Forms.RadioButton()
        Me.btnScrape = New System.Windows.Forms.Button()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lvwImages = New System.Windows.Forms.ListView()
        Me.lvcSrc = New System.Windows.Forms.ColumnHeader()
        Me.lvcAlt = New System.Windows.Forms.ColumnHeader()
        Me.lvcHeight = New System.Windows.Forms.ColumnHeader()
        Me.lvcWidth = New System.Windows.Forms.ColumnHeader()
        Me.lvwLinks = New System.Windows.Forms.ListView()
        Me.lvcUrl = New System.Windows.Forms.ColumnHeader()
        Me.pgeRegExTester = New System.Windows.Forms.TabPage()
        Me.chkSingleLine = New System.Windows.Forms.CheckBox()
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnReplace = New System.Windows.Forms.Button()
        Me.btnSplit = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtReplace = New System.Windows.Forms.TextBox()
        Me.txtRegEx = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblResultCount = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkMultiline = New System.Windows.Forms.CheckBox()
        Me.chkIgnoreCase = New System.Windows.Forms.CheckBox()
        Me.chkShowCaptures = New System.Windows.Forms.CheckBox()
        Me.chkShowGroups = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.lblValid = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.pgeSimple.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpValidation.SuspendLayout()
        Me.pgeScreenScrape.SuspendLayout()
        Me.pgeRegExTester.SuspendLayout()
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
        'TabControl1
        '
        Me.TabControl1.AccessibleDescription = resources.GetString("TabControl1.AccessibleDescription")
        Me.TabControl1.AccessibleName = resources.GetString("TabControl1.AccessibleName")
        Me.TabControl1.Alignment = CType(resources.GetObject("TabControl1.Alignment"), System.Windows.Forms.TabAlignment)
        Me.TabControl1.Anchor = CType(resources.GetObject("TabControl1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = CType(resources.GetObject("TabControl1.Appearance"), System.Windows.Forms.TabAppearance)
        Me.TabControl1.BackgroundImage = CType(resources.GetObject("TabControl1.BackgroundImage"), System.Drawing.Image)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeSimple, Me.pgeScreenScrape, Me.pgeRegExTester})
        Me.TabControl1.Dock = CType(resources.GetObject("TabControl1.Dock"), System.Windows.Forms.DockStyle)
        Me.TabControl1.Enabled = CType(resources.GetObject("TabControl1.Enabled"), Boolean)
        Me.TabControl1.Font = CType(resources.GetObject("TabControl1.Font"), System.Drawing.Font)
        Me.TabControl1.ImeMode = CType(resources.GetObject("TabControl1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TabControl1.ItemSize = CType(resources.GetObject("TabControl1.ItemSize"), System.Drawing.Size)
        Me.TabControl1.Location = CType(resources.GetObject("TabControl1.Location"), System.Drawing.Point)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = CType(resources.GetObject("TabControl1.Padding"), System.Drawing.Point)
        Me.TabControl1.RightToLeft = CType(resources.GetObject("TabControl1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = CType(resources.GetObject("TabControl1.ShowToolTips"), Boolean)
        Me.TabControl1.Size = CType(resources.GetObject("TabControl1.Size"), System.Drawing.Size)
        Me.TabControl1.TabIndex = CType(resources.GetObject("TabControl1.TabIndex"), Integer)
        Me.TabControl1.Text = resources.GetString("TabControl1.Text")
        Me.TabControl1.Visible = CType(resources.GetObject("TabControl1.Visible"), Boolean)
        '
        'pgeSimple
        '
        Me.pgeSimple.AccessibleDescription = CType(resources.GetObject("pgeSimple.AccessibleDescription"), String)
        Me.pgeSimple.AccessibleName = CType(resources.GetObject("pgeSimple.AccessibleName"), String)
        Me.pgeSimple.Anchor = CType(resources.GetObject("pgeSimple.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeSimple.AutoScroll = CType(resources.GetObject("pgeSimple.AutoScroll"), Boolean)
        Me.pgeSimple.AutoScrollMargin = CType(resources.GetObject("pgeSimple.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeSimple.AutoScrollMinSize = CType(resources.GetObject("pgeSimple.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeSimple.BackgroundImage = CType(resources.GetObject("pgeSimple.BackgroundImage"), System.Drawing.Image)
        Me.pgeSimple.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.grpValidation})
        Me.pgeSimple.Dock = CType(resources.GetObject("pgeSimple.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeSimple.Enabled = CType(resources.GetObject("pgeSimple.Enabled"), Boolean)
        Me.pgeSimple.Font = CType(resources.GetObject("pgeSimple.Font"), System.Drawing.Font)
        Me.pgeSimple.ImageIndex = CType(resources.GetObject("pgeSimple.ImageIndex"), Integer)
        Me.pgeSimple.ImeMode = CType(resources.GetObject("pgeSimple.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeSimple.Location = CType(resources.GetObject("pgeSimple.Location"), System.Drawing.Point)
        Me.pgeSimple.Name = "pgeSimple"
        Me.pgeSimple.RightToLeft = CType(resources.GetObject("pgeSimple.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeSimple.Size = CType(resources.GetObject("pgeSimple.Size"), System.Drawing.Size)
        Me.pgeSimple.TabIndex = CType(resources.GetObject("pgeSimple.TabIndex"), Integer)
        Me.pgeSimple.Text = resources.GetString("pgeSimple.Text")
        Me.pgeSimple.ToolTipText = resources.GetString("pgeSimple.ToolTipText")
        Me.pgeSimple.Visible = CType(resources.GetObject("pgeSimple.Visible"), Boolean)
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = resources.GetString("GroupBox1.AccessibleDescription")
        Me.GroupBox1.AccessibleName = resources.GetString("GroupBox1.AccessibleName")
        Me.GroupBox1.Anchor = CType(resources.GetObject("GroupBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblResults, Me.btnFindNumber, Me.Label12, Me.txtFindNumber})
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
        'btnFindNumber
        '
        Me.btnFindNumber.AccessibleDescription = resources.GetString("btnFindNumber.AccessibleDescription")
        Me.btnFindNumber.AccessibleName = resources.GetString("btnFindNumber.AccessibleName")
        Me.btnFindNumber.Anchor = CType(resources.GetObject("btnFindNumber.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnFindNumber.BackgroundImage = CType(resources.GetObject("btnFindNumber.BackgroundImage"), System.Drawing.Image)
        Me.btnFindNumber.Dock = CType(resources.GetObject("btnFindNumber.Dock"), System.Windows.Forms.DockStyle)
        Me.btnFindNumber.Enabled = CType(resources.GetObject("btnFindNumber.Enabled"), Boolean)
        Me.btnFindNumber.FlatStyle = CType(resources.GetObject("btnFindNumber.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnFindNumber.Font = CType(resources.GetObject("btnFindNumber.Font"), System.Drawing.Font)
        Me.btnFindNumber.Image = CType(resources.GetObject("btnFindNumber.Image"), System.Drawing.Image)
        Me.btnFindNumber.ImageAlign = CType(resources.GetObject("btnFindNumber.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnFindNumber.ImageIndex = CType(resources.GetObject("btnFindNumber.ImageIndex"), Integer)
        Me.btnFindNumber.ImeMode = CType(resources.GetObject("btnFindNumber.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnFindNumber.Location = CType(resources.GetObject("btnFindNumber.Location"), System.Drawing.Point)
        Me.btnFindNumber.Name = "btnFindNumber"
        Me.btnFindNumber.RightToLeft = CType(resources.GetObject("btnFindNumber.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnFindNumber.Size = CType(resources.GetObject("btnFindNumber.Size"), System.Drawing.Size)
        Me.btnFindNumber.TabIndex = CType(resources.GetObject("btnFindNumber.TabIndex"), Integer)
        Me.btnFindNumber.Text = resources.GetString("btnFindNumber.Text")
        Me.btnFindNumber.TextAlign = CType(resources.GetObject("btnFindNumber.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnFindNumber.Visible = CType(resources.GetObject("btnFindNumber.Visible"), Boolean)
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
        'txtFindNumber
        '
        Me.txtFindNumber.AccessibleDescription = resources.GetString("txtFindNumber.AccessibleDescription")
        Me.txtFindNumber.AccessibleName = resources.GetString("txtFindNumber.AccessibleName")
        Me.txtFindNumber.Anchor = CType(resources.GetObject("txtFindNumber.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtFindNumber.AutoSize = CType(resources.GetObject("txtFindNumber.AutoSize"), Boolean)
        Me.txtFindNumber.BackgroundImage = CType(resources.GetObject("txtFindNumber.BackgroundImage"), System.Drawing.Image)
        Me.txtFindNumber.Dock = CType(resources.GetObject("txtFindNumber.Dock"), System.Windows.Forms.DockStyle)
        Me.txtFindNumber.Enabled = CType(resources.GetObject("txtFindNumber.Enabled"), Boolean)
        Me.txtFindNumber.Font = CType(resources.GetObject("txtFindNumber.Font"), System.Drawing.Font)
        Me.txtFindNumber.ImeMode = CType(resources.GetObject("txtFindNumber.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtFindNumber.Location = CType(resources.GetObject("txtFindNumber.Location"), System.Drawing.Point)
        Me.txtFindNumber.MaxLength = CType(resources.GetObject("txtFindNumber.MaxLength"), Integer)
        Me.txtFindNumber.Multiline = CType(resources.GetObject("txtFindNumber.Multiline"), Boolean)
        Me.txtFindNumber.Name = "txtFindNumber"
        Me.txtFindNumber.PasswordChar = CType(resources.GetObject("txtFindNumber.PasswordChar"), Char)
        Me.txtFindNumber.RightToLeft = CType(resources.GetObject("txtFindNumber.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtFindNumber.ScrollBars = CType(resources.GetObject("txtFindNumber.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtFindNumber.Size = CType(resources.GetObject("txtFindNumber.Size"), System.Drawing.Size)
        Me.txtFindNumber.TabIndex = CType(resources.GetObject("txtFindNumber.TabIndex"), Integer)
        Me.txtFindNumber.Text = resources.GetString("txtFindNumber.Text")
        Me.txtFindNumber.TextAlign = CType(resources.GetObject("txtFindNumber.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtFindNumber.Visible = CType(resources.GetObject("txtFindNumber.Visible"), Boolean)
        Me.txtFindNumber.WordWrap = CType(resources.GetObject("txtFindNumber.WordWrap"), Boolean)
        '
        'grpValidation
        '
        Me.grpValidation.AccessibleDescription = resources.GetString("grpValidation.AccessibleDescription")
        Me.grpValidation.AccessibleName = CType(resources.GetObject("grpValidation.AccessibleName"), String)
        Me.grpValidation.Anchor = CType(resources.GetObject("grpValidation.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grpValidation.BackgroundImage = CType(resources.GetObject("grpValidation.BackgroundImage"), System.Drawing.Image)
        Me.grpValidation.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblValid, Me.Label11, Me.Label9, Me.Label8, Me.btnValidate, Me.txtEmail, Me.txtDate, Me.txtZip, Me.Label5, Me.Label7, Me.Label6})
        Me.grpValidation.Dock = CType(resources.GetObject("grpValidation.Dock"), System.Windows.Forms.DockStyle)
        Me.grpValidation.Enabled = CType(resources.GetObject("grpValidation.Enabled"), Boolean)
        Me.grpValidation.Font = CType(resources.GetObject("grpValidation.Font"), System.Drawing.Font)
        Me.grpValidation.ImeMode = CType(resources.GetObject("grpValidation.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grpValidation.Location = CType(resources.GetObject("grpValidation.Location"), System.Drawing.Point)
        Me.grpValidation.Name = "grpValidation"
        Me.grpValidation.RightToLeft = CType(resources.GetObject("grpValidation.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grpValidation.Size = CType(resources.GetObject("grpValidation.Size"), System.Drawing.Size)
        Me.grpValidation.TabIndex = CType(resources.GetObject("grpValidation.TabIndex"), Integer)
        Me.grpValidation.TabStop = False
        Me.grpValidation.Text = resources.GetString("grpValidation.Text")
        Me.grpValidation.Visible = CType(resources.GetObject("grpValidation.Visible"), Boolean)
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
        'Label9
        '
        Me.Label9.AccessibleDescription = resources.GetString("Label9.AccessibleDescription")
        Me.Label9.AccessibleName = resources.GetString("Label9.AccessibleName")
        Me.Label9.Anchor = CType(resources.GetObject("Label9.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = CType(resources.GetObject("Label9.AutoSize"), Boolean)
        Me.Label9.Dock = CType(resources.GetObject("Label9.Dock"), System.Windows.Forms.DockStyle)
        Me.Label9.Enabled = CType(resources.GetObject("Label9.Enabled"), Boolean)
        Me.Label9.Font = CType(resources.GetObject("Label9.Font"), System.Drawing.Font)
        Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
        Me.Label9.ImageAlign = CType(resources.GetObject("Label9.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label9.ImageIndex = CType(resources.GetObject("Label9.ImageIndex"), Integer)
        Me.Label9.ImeMode = CType(resources.GetObject("Label9.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label9.Location = CType(resources.GetObject("Label9.Location"), System.Drawing.Point)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = CType(resources.GetObject("Label9.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label9.Size = CType(resources.GetObject("Label9.Size"), System.Drawing.Size)
        Me.Label9.TabIndex = CType(resources.GetObject("Label9.TabIndex"), Integer)
        Me.Label9.Text = resources.GetString("Label9.Text")
        Me.Label9.TextAlign = CType(resources.GetObject("Label9.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label9.Visible = CType(resources.GetObject("Label9.Visible"), Boolean)
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = resources.GetString("Label8.AccessibleDescription")
        Me.Label8.AccessibleName = resources.GetString("Label8.AccessibleName")
        Me.Label8.Anchor = CType(resources.GetObject("Label8.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = CType(resources.GetObject("Label8.AutoSize"), Boolean)
        Me.Label8.Dock = CType(resources.GetObject("Label8.Dock"), System.Windows.Forms.DockStyle)
        Me.Label8.Enabled = CType(resources.GetObject("Label8.Enabled"), Boolean)
        Me.Label8.Font = CType(resources.GetObject("Label8.Font"), System.Drawing.Font)
        Me.Label8.Image = CType(resources.GetObject("Label8.Image"), System.Drawing.Image)
        Me.Label8.ImageAlign = CType(resources.GetObject("Label8.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label8.ImageIndex = CType(resources.GetObject("Label8.ImageIndex"), Integer)
        Me.Label8.ImeMode = CType(resources.GetObject("Label8.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label8.Location = CType(resources.GetObject("Label8.Location"), System.Drawing.Point)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = CType(resources.GetObject("Label8.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label8.Size = CType(resources.GetObject("Label8.Size"), System.Drawing.Size)
        Me.Label8.TabIndex = CType(resources.GetObject("Label8.TabIndex"), Integer)
        Me.Label8.Text = resources.GetString("Label8.Text")
        Me.Label8.TextAlign = CType(resources.GetObject("Label8.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label8.Visible = CType(resources.GetObject("Label8.Visible"), Boolean)
        '
        'btnValidate
        '
        Me.btnValidate.AccessibleDescription = resources.GetString("btnValidate.AccessibleDescription")
        Me.btnValidate.AccessibleName = resources.GetString("btnValidate.AccessibleName")
        Me.btnValidate.Anchor = CType(resources.GetObject("btnValidate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnValidate.BackgroundImage = CType(resources.GetObject("btnValidate.BackgroundImage"), System.Drawing.Image)
        Me.btnValidate.Dock = CType(resources.GetObject("btnValidate.Dock"), System.Windows.Forms.DockStyle)
        Me.btnValidate.Enabled = CType(resources.GetObject("btnValidate.Enabled"), Boolean)
        Me.btnValidate.FlatStyle = CType(resources.GetObject("btnValidate.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnValidate.Font = CType(resources.GetObject("btnValidate.Font"), System.Drawing.Font)
        Me.btnValidate.Image = CType(resources.GetObject("btnValidate.Image"), System.Drawing.Image)
        Me.btnValidate.ImageAlign = CType(resources.GetObject("btnValidate.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnValidate.ImageIndex = CType(resources.GetObject("btnValidate.ImageIndex"), Integer)
        Me.btnValidate.ImeMode = CType(resources.GetObject("btnValidate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnValidate.Location = CType(resources.GetObject("btnValidate.Location"), System.Drawing.Point)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.RightToLeft = CType(resources.GetObject("btnValidate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnValidate.Size = CType(resources.GetObject("btnValidate.Size"), System.Drawing.Size)
        Me.btnValidate.TabIndex = CType(resources.GetObject("btnValidate.TabIndex"), Integer)
        Me.btnValidate.Text = resources.GetString("btnValidate.Text")
        Me.btnValidate.TextAlign = CType(resources.GetObject("btnValidate.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnValidate.Visible = CType(resources.GetObject("btnValidate.Visible"), Boolean)
        '
        'txtEmail
        '
        Me.txtEmail.AccessibleDescription = resources.GetString("txtEmail.AccessibleDescription")
        Me.txtEmail.AccessibleName = resources.GetString("txtEmail.AccessibleName")
        Me.txtEmail.Anchor = CType(resources.GetObject("txtEmail.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.AutoSize = CType(resources.GetObject("txtEmail.AutoSize"), Boolean)
        Me.txtEmail.BackgroundImage = CType(resources.GetObject("txtEmail.BackgroundImage"), System.Drawing.Image)
        Me.txtEmail.Dock = CType(resources.GetObject("txtEmail.Dock"), System.Windows.Forms.DockStyle)
        Me.txtEmail.Enabled = CType(resources.GetObject("txtEmail.Enabled"), Boolean)
        Me.txtEmail.Font = CType(resources.GetObject("txtEmail.Font"), System.Drawing.Font)
        Me.txtEmail.ImeMode = CType(resources.GetObject("txtEmail.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtEmail.Location = CType(resources.GetObject("txtEmail.Location"), System.Drawing.Point)
        Me.txtEmail.MaxLength = CType(resources.GetObject("txtEmail.MaxLength"), Integer)
        Me.txtEmail.Multiline = CType(resources.GetObject("txtEmail.Multiline"), Boolean)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.PasswordChar = CType(resources.GetObject("txtEmail.PasswordChar"), Char)
        Me.txtEmail.RightToLeft = CType(resources.GetObject("txtEmail.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtEmail.ScrollBars = CType(resources.GetObject("txtEmail.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtEmail.Size = CType(resources.GetObject("txtEmail.Size"), System.Drawing.Size)
        Me.txtEmail.TabIndex = CType(resources.GetObject("txtEmail.TabIndex"), Integer)
        Me.txtEmail.Text = resources.GetString("txtEmail.Text")
        Me.txtEmail.TextAlign = CType(resources.GetObject("txtEmail.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtEmail.Visible = CType(resources.GetObject("txtEmail.Visible"), Boolean)
        Me.txtEmail.WordWrap = CType(resources.GetObject("txtEmail.WordWrap"), Boolean)
        '
        'txtDate
        '
        Me.txtDate.AccessibleDescription = resources.GetString("txtDate.AccessibleDescription")
        Me.txtDate.AccessibleName = resources.GetString("txtDate.AccessibleName")
        Me.txtDate.Anchor = CType(resources.GetObject("txtDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtDate.AutoSize = CType(resources.GetObject("txtDate.AutoSize"), Boolean)
        Me.txtDate.BackgroundImage = CType(resources.GetObject("txtDate.BackgroundImage"), System.Drawing.Image)
        Me.txtDate.Dock = CType(resources.GetObject("txtDate.Dock"), System.Windows.Forms.DockStyle)
        Me.txtDate.Enabled = CType(resources.GetObject("txtDate.Enabled"), Boolean)
        Me.txtDate.Font = CType(resources.GetObject("txtDate.Font"), System.Drawing.Font)
        Me.txtDate.ImeMode = CType(resources.GetObject("txtDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtDate.Location = CType(resources.GetObject("txtDate.Location"), System.Drawing.Point)
        Me.txtDate.MaxLength = CType(resources.GetObject("txtDate.MaxLength"), Integer)
        Me.txtDate.Multiline = CType(resources.GetObject("txtDate.Multiline"), Boolean)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.PasswordChar = CType(resources.GetObject("txtDate.PasswordChar"), Char)
        Me.txtDate.RightToLeft = CType(resources.GetObject("txtDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtDate.ScrollBars = CType(resources.GetObject("txtDate.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtDate.Size = CType(resources.GetObject("txtDate.Size"), System.Drawing.Size)
        Me.txtDate.TabIndex = CType(resources.GetObject("txtDate.TabIndex"), Integer)
        Me.txtDate.Text = resources.GetString("txtDate.Text")
        Me.txtDate.TextAlign = CType(resources.GetObject("txtDate.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtDate.Visible = CType(resources.GetObject("txtDate.Visible"), Boolean)
        Me.txtDate.WordWrap = CType(resources.GetObject("txtDate.WordWrap"), Boolean)
        '
        'txtZip
        '
        Me.txtZip.AccessibleDescription = resources.GetString("txtZip.AccessibleDescription")
        Me.txtZip.AccessibleName = resources.GetString("txtZip.AccessibleName")
        Me.txtZip.Anchor = CType(resources.GetObject("txtZip.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtZip.AutoSize = CType(resources.GetObject("txtZip.AutoSize"), Boolean)
        Me.txtZip.BackgroundImage = CType(resources.GetObject("txtZip.BackgroundImage"), System.Drawing.Image)
        Me.txtZip.Dock = CType(resources.GetObject("txtZip.Dock"), System.Windows.Forms.DockStyle)
        Me.txtZip.Enabled = CType(resources.GetObject("txtZip.Enabled"), Boolean)
        Me.txtZip.Font = CType(resources.GetObject("txtZip.Font"), System.Drawing.Font)
        Me.txtZip.ImeMode = CType(resources.GetObject("txtZip.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtZip.Location = CType(resources.GetObject("txtZip.Location"), System.Drawing.Point)
        Me.txtZip.MaxLength = CType(resources.GetObject("txtZip.MaxLength"), Integer)
        Me.txtZip.Multiline = CType(resources.GetObject("txtZip.Multiline"), Boolean)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.PasswordChar = CType(resources.GetObject("txtZip.PasswordChar"), Char)
        Me.txtZip.RightToLeft = CType(resources.GetObject("txtZip.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtZip.ScrollBars = CType(resources.GetObject("txtZip.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtZip.Size = CType(resources.GetObject("txtZip.Size"), System.Drawing.Size)
        Me.txtZip.TabIndex = CType(resources.GetObject("txtZip.TabIndex"), Integer)
        Me.txtZip.Text = resources.GetString("txtZip.Text")
        Me.txtZip.TextAlign = CType(resources.GetObject("txtZip.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtZip.Visible = CType(resources.GetObject("txtZip.Visible"), Boolean)
        Me.txtZip.WordWrap = CType(resources.GetObject("txtZip.WordWrap"), Boolean)
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
        'Label7
        '
        Me.Label7.AccessibleDescription = resources.GetString("Label7.AccessibleDescription")
        Me.Label7.AccessibleName = resources.GetString("Label7.AccessibleName")
        Me.Label7.Anchor = CType(resources.GetObject("Label7.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = CType(resources.GetObject("Label7.AutoSize"), Boolean)
        Me.Label7.Dock = CType(resources.GetObject("Label7.Dock"), System.Windows.Forms.DockStyle)
        Me.Label7.Enabled = CType(resources.GetObject("Label7.Enabled"), Boolean)
        Me.Label7.Font = CType(resources.GetObject("Label7.Font"), System.Drawing.Font)
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.ImageAlign = CType(resources.GetObject("Label7.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label7.ImageIndex = CType(resources.GetObject("Label7.ImageIndex"), Integer)
        Me.Label7.ImeMode = CType(resources.GetObject("Label7.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label7.Location = CType(resources.GetObject("Label7.Location"), System.Drawing.Point)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = CType(resources.GetObject("Label7.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label7.Size = CType(resources.GetObject("Label7.Size"), System.Drawing.Size)
        Me.Label7.TabIndex = CType(resources.GetObject("Label7.TabIndex"), Integer)
        Me.Label7.Text = resources.GetString("Label7.Text")
        Me.Label7.TextAlign = CType(resources.GetObject("Label7.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label7.Visible = CType(resources.GetObject("Label7.Visible"), Boolean)
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = resources.GetString("Label6.AccessibleDescription")
        Me.Label6.AccessibleName = resources.GetString("Label6.AccessibleName")
        Me.Label6.Anchor = CType(resources.GetObject("Label6.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = CType(resources.GetObject("Label6.AutoSize"), Boolean)
        Me.Label6.Dock = CType(resources.GetObject("Label6.Dock"), System.Windows.Forms.DockStyle)
        Me.Label6.Enabled = CType(resources.GetObject("Label6.Enabled"), Boolean)
        Me.Label6.Font = CType(resources.GetObject("Label6.Font"), System.Drawing.Font)
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.ImageAlign = CType(resources.GetObject("Label6.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label6.ImageIndex = CType(resources.GetObject("Label6.ImageIndex"), Integer)
        Me.Label6.ImeMode = CType(resources.GetObject("Label6.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label6.Location = CType(resources.GetObject("Label6.Location"), System.Drawing.Point)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = CType(resources.GetObject("Label6.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label6.Size = CType(resources.GetObject("Label6.Size"), System.Drawing.Size)
        Me.Label6.TabIndex = CType(resources.GetObject("Label6.TabIndex"), Integer)
        Me.Label6.Text = resources.GetString("Label6.Text")
        Me.Label6.TextAlign = CType(resources.GetObject("Label6.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label6.Visible = CType(resources.GetObject("Label6.Visible"), Boolean)
        '
        'pgeScreenScrape
        '
        Me.pgeScreenScrape.AccessibleDescription = CType(resources.GetObject("pgeScreenScrape.AccessibleDescription"), String)
        Me.pgeScreenScrape.AccessibleName = CType(resources.GetObject("pgeScreenScrape.AccessibleName"), String)
        Me.pgeScreenScrape.Anchor = CType(resources.GetObject("pgeScreenScrape.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeScreenScrape.AutoScroll = CType(resources.GetObject("pgeScreenScrape.AutoScroll"), Boolean)
        Me.pgeScreenScrape.AutoScrollMargin = CType(resources.GetObject("pgeScreenScrape.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeScreenScrape.AutoScrollMinSize = CType(resources.GetObject("pgeScreenScrape.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeScreenScrape.BackgroundImage = CType(resources.GetObject("pgeScreenScrape.BackgroundImage"), System.Drawing.Image)
        Me.pgeScreenScrape.Controls.AddRange(New System.Windows.Forms.Control() {Me.optImages, Me.optLinks, Me.btnScrape, Me.txtURL, Me.Label10, Me.lvwImages, Me.lvwLinks})
        Me.pgeScreenScrape.Dock = CType(resources.GetObject("pgeScreenScrape.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeScreenScrape.Enabled = CType(resources.GetObject("pgeScreenScrape.Enabled"), Boolean)
        Me.pgeScreenScrape.Font = CType(resources.GetObject("pgeScreenScrape.Font"), System.Drawing.Font)
        Me.pgeScreenScrape.ImageIndex = CType(resources.GetObject("pgeScreenScrape.ImageIndex"), Integer)
        Me.pgeScreenScrape.ImeMode = CType(resources.GetObject("pgeScreenScrape.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeScreenScrape.Location = CType(resources.GetObject("pgeScreenScrape.Location"), System.Drawing.Point)
        Me.pgeScreenScrape.Name = "pgeScreenScrape"
        Me.pgeScreenScrape.RightToLeft = CType(resources.GetObject("pgeScreenScrape.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeScreenScrape.Size = CType(resources.GetObject("pgeScreenScrape.Size"), System.Drawing.Size)
        Me.pgeScreenScrape.TabIndex = CType(resources.GetObject("pgeScreenScrape.TabIndex"), Integer)
        Me.pgeScreenScrape.Text = resources.GetString("pgeScreenScrape.Text")
        Me.pgeScreenScrape.ToolTipText = resources.GetString("pgeScreenScrape.ToolTipText")
        Me.pgeScreenScrape.Visible = CType(resources.GetObject("pgeScreenScrape.Visible"), Boolean)
        '
        'optImages
        '
        Me.optImages.AccessibleDescription = resources.GetString("optImages.AccessibleDescription")
        Me.optImages.AccessibleName = resources.GetString("optImages.AccessibleName")
        Me.optImages.Anchor = CType(resources.GetObject("optImages.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optImages.Appearance = CType(resources.GetObject("optImages.Appearance"), System.Windows.Forms.Appearance)
        Me.optImages.BackgroundImage = CType(resources.GetObject("optImages.BackgroundImage"), System.Drawing.Image)
        Me.optImages.CheckAlign = CType(resources.GetObject("optImages.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optImages.Checked = True
        Me.optImages.Dock = CType(resources.GetObject("optImages.Dock"), System.Windows.Forms.DockStyle)
        Me.optImages.Enabled = CType(resources.GetObject("optImages.Enabled"), Boolean)
        Me.optImages.FlatStyle = CType(resources.GetObject("optImages.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optImages.Font = CType(resources.GetObject("optImages.Font"), System.Drawing.Font)
        Me.optImages.Image = CType(resources.GetObject("optImages.Image"), System.Drawing.Image)
        Me.optImages.ImageAlign = CType(resources.GetObject("optImages.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optImages.ImageIndex = CType(resources.GetObject("optImages.ImageIndex"), Integer)
        Me.optImages.ImeMode = CType(resources.GetObject("optImages.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optImages.Location = CType(resources.GetObject("optImages.Location"), System.Drawing.Point)
        Me.optImages.Name = "optImages"
        Me.optImages.RightToLeft = CType(resources.GetObject("optImages.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optImages.Size = CType(resources.GetObject("optImages.Size"), System.Drawing.Size)
        Me.optImages.TabIndex = CType(resources.GetObject("optImages.TabIndex"), Integer)
        Me.optImages.TabStop = True
        Me.optImages.Text = resources.GetString("optImages.Text")
        Me.optImages.TextAlign = CType(resources.GetObject("optImages.TextAlign"), System.Drawing.ContentAlignment)
        Me.optImages.Visible = CType(resources.GetObject("optImages.Visible"), Boolean)
        '
        'optLinks
        '
        Me.optLinks.AccessibleDescription = resources.GetString("optLinks.AccessibleDescription")
        Me.optLinks.AccessibleName = resources.GetString("optLinks.AccessibleName")
        Me.optLinks.Anchor = CType(resources.GetObject("optLinks.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optLinks.Appearance = CType(resources.GetObject("optLinks.Appearance"), System.Windows.Forms.Appearance)
        Me.optLinks.BackgroundImage = CType(resources.GetObject("optLinks.BackgroundImage"), System.Drawing.Image)
        Me.optLinks.CheckAlign = CType(resources.GetObject("optLinks.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optLinks.Dock = CType(resources.GetObject("optLinks.Dock"), System.Windows.Forms.DockStyle)
        Me.optLinks.Enabled = CType(resources.GetObject("optLinks.Enabled"), Boolean)
        Me.optLinks.FlatStyle = CType(resources.GetObject("optLinks.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optLinks.Font = CType(resources.GetObject("optLinks.Font"), System.Drawing.Font)
        Me.optLinks.Image = CType(resources.GetObject("optLinks.Image"), System.Drawing.Image)
        Me.optLinks.ImageAlign = CType(resources.GetObject("optLinks.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optLinks.ImageIndex = CType(resources.GetObject("optLinks.ImageIndex"), Integer)
        Me.optLinks.ImeMode = CType(resources.GetObject("optLinks.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optLinks.Location = CType(resources.GetObject("optLinks.Location"), System.Drawing.Point)
        Me.optLinks.Name = "optLinks"
        Me.optLinks.RightToLeft = CType(resources.GetObject("optLinks.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optLinks.Size = CType(resources.GetObject("optLinks.Size"), System.Drawing.Size)
        Me.optLinks.TabIndex = CType(resources.GetObject("optLinks.TabIndex"), Integer)
        Me.optLinks.Text = resources.GetString("optLinks.Text")
        Me.optLinks.TextAlign = CType(resources.GetObject("optLinks.TextAlign"), System.Drawing.ContentAlignment)
        Me.optLinks.Visible = CType(resources.GetObject("optLinks.Visible"), Boolean)
        '
        'btnScrape
        '
        Me.btnScrape.AccessibleDescription = resources.GetString("btnScrape.AccessibleDescription")
        Me.btnScrape.AccessibleName = resources.GetString("btnScrape.AccessibleName")
        Me.btnScrape.Anchor = CType(resources.GetObject("btnScrape.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnScrape.BackColor = System.Drawing.SystemColors.Control
        Me.btnScrape.BackgroundImage = CType(resources.GetObject("btnScrape.BackgroundImage"), System.Drawing.Image)
        Me.btnScrape.Dock = CType(resources.GetObject("btnScrape.Dock"), System.Windows.Forms.DockStyle)
        Me.btnScrape.Enabled = CType(resources.GetObject("btnScrape.Enabled"), Boolean)
        Me.btnScrape.FlatStyle = CType(resources.GetObject("btnScrape.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnScrape.Font = CType(resources.GetObject("btnScrape.Font"), System.Drawing.Font)
        Me.btnScrape.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnScrape.Image = CType(resources.GetObject("btnScrape.Image"), System.Drawing.Image)
        Me.btnScrape.ImageAlign = CType(resources.GetObject("btnScrape.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnScrape.ImageIndex = CType(resources.GetObject("btnScrape.ImageIndex"), Integer)
        Me.btnScrape.ImeMode = CType(resources.GetObject("btnScrape.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnScrape.Location = CType(resources.GetObject("btnScrape.Location"), System.Drawing.Point)
        Me.btnScrape.Name = "btnScrape"
        Me.btnScrape.RightToLeft = CType(resources.GetObject("btnScrape.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnScrape.Size = CType(resources.GetObject("btnScrape.Size"), System.Drawing.Size)
        Me.btnScrape.TabIndex = CType(resources.GetObject("btnScrape.TabIndex"), Integer)
        Me.btnScrape.Text = resources.GetString("btnScrape.Text")
        Me.btnScrape.TextAlign = CType(resources.GetObject("btnScrape.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnScrape.Visible = CType(resources.GetObject("btnScrape.Visible"), Boolean)
        '
        'txtURL
        '
        Me.txtURL.AccessibleDescription = resources.GetString("txtURL.AccessibleDescription")
        Me.txtURL.AccessibleName = resources.GetString("txtURL.AccessibleName")
        Me.txtURL.Anchor = CType(resources.GetObject("txtURL.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtURL.AutoSize = CType(resources.GetObject("txtURL.AutoSize"), Boolean)
        Me.txtURL.BackgroundImage = CType(resources.GetObject("txtURL.BackgroundImage"), System.Drawing.Image)
        Me.txtURL.Dock = CType(resources.GetObject("txtURL.Dock"), System.Windows.Forms.DockStyle)
        Me.txtURL.Enabled = CType(resources.GetObject("txtURL.Enabled"), Boolean)
        Me.txtURL.Font = CType(resources.GetObject("txtURL.Font"), System.Drawing.Font)
        Me.txtURL.ImeMode = CType(resources.GetObject("txtURL.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtURL.Location = CType(resources.GetObject("txtURL.Location"), System.Drawing.Point)
        Me.txtURL.MaxLength = CType(resources.GetObject("txtURL.MaxLength"), Integer)
        Me.txtURL.Multiline = CType(resources.GetObject("txtURL.Multiline"), Boolean)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.PasswordChar = CType(resources.GetObject("txtURL.PasswordChar"), Char)
        Me.txtURL.RightToLeft = CType(resources.GetObject("txtURL.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtURL.ScrollBars = CType(resources.GetObject("txtURL.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtURL.Size = CType(resources.GetObject("txtURL.Size"), System.Drawing.Size)
        Me.txtURL.TabIndex = CType(resources.GetObject("txtURL.TabIndex"), Integer)
        Me.txtURL.Text = resources.GetString("txtURL.Text")
        Me.txtURL.TextAlign = CType(resources.GetObject("txtURL.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtURL.Visible = CType(resources.GetObject("txtURL.Visible"), Boolean)
        Me.txtURL.WordWrap = CType(resources.GetObject("txtURL.WordWrap"), Boolean)
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = resources.GetString("Label10.AccessibleDescription")
        Me.Label10.AccessibleName = resources.GetString("Label10.AccessibleName")
        Me.Label10.Anchor = CType(resources.GetObject("Label10.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = CType(resources.GetObject("Label10.AutoSize"), Boolean)
        Me.Label10.Dock = CType(resources.GetObject("Label10.Dock"), System.Windows.Forms.DockStyle)
        Me.Label10.Enabled = CType(resources.GetObject("Label10.Enabled"), Boolean)
        Me.Label10.Font = CType(resources.GetObject("Label10.Font"), System.Drawing.Font)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Image = CType(resources.GetObject("Label10.Image"), System.Drawing.Image)
        Me.Label10.ImageAlign = CType(resources.GetObject("Label10.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label10.ImageIndex = CType(resources.GetObject("Label10.ImageIndex"), Integer)
        Me.Label10.ImeMode = CType(resources.GetObject("Label10.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label10.Location = CType(resources.GetObject("Label10.Location"), System.Drawing.Point)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = CType(resources.GetObject("Label10.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label10.Size = CType(resources.GetObject("Label10.Size"), System.Drawing.Size)
        Me.Label10.TabIndex = CType(resources.GetObject("Label10.TabIndex"), Integer)
        Me.Label10.Text = resources.GetString("Label10.Text")
        Me.Label10.TextAlign = CType(resources.GetObject("Label10.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label10.Visible = CType(resources.GetObject("Label10.Visible"), Boolean)
        '
        'lvwImages
        '
        Me.lvwImages.AccessibleDescription = resources.GetString("lvwImages.AccessibleDescription")
        Me.lvwImages.AccessibleName = resources.GetString("lvwImages.AccessibleName")
        Me.lvwImages.Alignment = CType(resources.GetObject("lvwImages.Alignment"), System.Windows.Forms.ListViewAlignment)
        Me.lvwImages.Anchor = CType(resources.GetObject("lvwImages.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lvwImages.BackgroundImage = CType(resources.GetObject("lvwImages.BackgroundImage"), System.Drawing.Image)
        Me.lvwImages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvcSrc, Me.lvcAlt, Me.lvcHeight, Me.lvcWidth})
        Me.lvwImages.Dock = CType(resources.GetObject("lvwImages.Dock"), System.Windows.Forms.DockStyle)
        Me.lvwImages.Enabled = CType(resources.GetObject("lvwImages.Enabled"), Boolean)
        Me.lvwImages.Font = CType(resources.GetObject("lvwImages.Font"), System.Drawing.Font)
        Me.lvwImages.FullRowSelect = True
        Me.lvwImages.GridLines = True
        Me.lvwImages.ImeMode = CType(resources.GetObject("lvwImages.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lvwImages.LabelWrap = CType(resources.GetObject("lvwImages.LabelWrap"), Boolean)
        Me.lvwImages.Location = CType(resources.GetObject("lvwImages.Location"), System.Drawing.Point)
        Me.lvwImages.Name = "lvwImages"
        Me.lvwImages.RightToLeft = CType(resources.GetObject("lvwImages.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lvwImages.Size = CType(resources.GetObject("lvwImages.Size"), System.Drawing.Size)
        Me.lvwImages.TabIndex = CType(resources.GetObject("lvwImages.TabIndex"), Integer)
        Me.lvwImages.Text = resources.GetString("lvwImages.Text")
        Me.lvwImages.View = System.Windows.Forms.View.Details
        Me.lvwImages.Visible = CType(resources.GetObject("lvwImages.Visible"), Boolean)
        '
        'lvcSrc
        '
        Me.lvcSrc.Text = resources.GetString("lvcSrc.Text")
        Me.lvcSrc.TextAlign = CType(resources.GetObject("lvcSrc.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.lvcSrc.Width = CType(resources.GetObject("lvcSrc.Width"), Integer)
        '
        'lvcAlt
        '
        Me.lvcAlt.Text = resources.GetString("lvcAlt.Text")
        Me.lvcAlt.TextAlign = CType(resources.GetObject("lvcAlt.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.lvcAlt.Width = CType(resources.GetObject("lvcAlt.Width"), Integer)
        '
        'lvcHeight
        '
        Me.lvcHeight.Text = resources.GetString("lvcHeight.Text")
        Me.lvcHeight.TextAlign = CType(resources.GetObject("lvcHeight.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.lvcHeight.Width = CType(resources.GetObject("lvcHeight.Width"), Integer)
        '
        'lvcWidth
        '
        Me.lvcWidth.Text = resources.GetString("lvcWidth.Text")
        Me.lvcWidth.TextAlign = CType(resources.GetObject("lvcWidth.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.lvcWidth.Width = CType(resources.GetObject("lvcWidth.Width"), Integer)
        '
        'lvwLinks
        '
        Me.lvwLinks.AccessibleDescription = resources.GetString("lvwLinks.AccessibleDescription")
        Me.lvwLinks.AccessibleName = resources.GetString("lvwLinks.AccessibleName")
        Me.lvwLinks.Alignment = CType(resources.GetObject("lvwLinks.Alignment"), System.Windows.Forms.ListViewAlignment)
        Me.lvwLinks.Anchor = CType(resources.GetObject("lvwLinks.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lvwLinks.BackgroundImage = CType(resources.GetObject("lvwLinks.BackgroundImage"), System.Drawing.Image)
        Me.lvwLinks.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvcUrl})
        Me.lvwLinks.Dock = CType(resources.GetObject("lvwLinks.Dock"), System.Windows.Forms.DockStyle)
        Me.lvwLinks.Enabled = CType(resources.GetObject("lvwLinks.Enabled"), Boolean)
        Me.lvwLinks.Font = CType(resources.GetObject("lvwLinks.Font"), System.Drawing.Font)
        Me.lvwLinks.FullRowSelect = True
        Me.lvwLinks.GridLines = True
        Me.lvwLinks.ImeMode = CType(resources.GetObject("lvwLinks.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lvwLinks.LabelWrap = CType(resources.GetObject("lvwLinks.LabelWrap"), Boolean)
        Me.lvwLinks.Location = CType(resources.GetObject("lvwLinks.Location"), System.Drawing.Point)
        Me.lvwLinks.Name = "lvwLinks"
        Me.lvwLinks.RightToLeft = CType(resources.GetObject("lvwLinks.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lvwLinks.Size = CType(resources.GetObject("lvwLinks.Size"), System.Drawing.Size)
        Me.lvwLinks.TabIndex = CType(resources.GetObject("lvwLinks.TabIndex"), Integer)
        Me.lvwLinks.Text = resources.GetString("lvwLinks.Text")
        Me.lvwLinks.View = System.Windows.Forms.View.Details
        Me.lvwLinks.Visible = CType(resources.GetObject("lvwLinks.Visible"), Boolean)
        '
        'lvcUrl
        '
        Me.lvcUrl.Text = resources.GetString("lvcUrl.Text")
        Me.lvcUrl.TextAlign = CType(resources.GetObject("lvcUrl.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.lvcUrl.Width = CType(resources.GetObject("lvcUrl.Width"), Integer)
        '
        'pgeRegExTester
        '
        Me.pgeRegExTester.AccessibleDescription = CType(resources.GetObject("pgeRegExTester.AccessibleDescription"), String)
        Me.pgeRegExTester.AccessibleName = CType(resources.GetObject("pgeRegExTester.AccessibleName"), String)
        Me.pgeRegExTester.Anchor = CType(resources.GetObject("pgeRegExTester.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeRegExTester.AutoScroll = CType(resources.GetObject("pgeRegExTester.AutoScroll"), Boolean)
        Me.pgeRegExTester.AutoScrollMargin = CType(resources.GetObject("pgeRegExTester.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeRegExTester.AutoScrollMinSize = CType(resources.GetObject("pgeRegExTester.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeRegExTester.BackgroundImage = CType(resources.GetObject("pgeRegExTester.BackgroundImage"), System.Drawing.Image)
        Me.pgeRegExTester.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkSingleLine, Me.txtResults, Me.txtSource, Me.Label3, Me.btnReplace, Me.btnSplit, Me.btnFind, Me.txtReplace, Me.txtRegEx, Me.Label1, Me.Label2, Me.lblResultCount, Me.Label4, Me.chkMultiline, Me.chkIgnoreCase, Me.chkShowCaptures, Me.chkShowGroups})
        Me.pgeRegExTester.Dock = CType(resources.GetObject("pgeRegExTester.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeRegExTester.Enabled = CType(resources.GetObject("pgeRegExTester.Enabled"), Boolean)
        Me.pgeRegExTester.Font = CType(resources.GetObject("pgeRegExTester.Font"), System.Drawing.Font)
        Me.pgeRegExTester.ImageIndex = CType(resources.GetObject("pgeRegExTester.ImageIndex"), Integer)
        Me.pgeRegExTester.ImeMode = CType(resources.GetObject("pgeRegExTester.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeRegExTester.Location = CType(resources.GetObject("pgeRegExTester.Location"), System.Drawing.Point)
        Me.pgeRegExTester.Name = "pgeRegExTester"
        Me.pgeRegExTester.RightToLeft = CType(resources.GetObject("pgeRegExTester.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeRegExTester.Size = CType(resources.GetObject("pgeRegExTester.Size"), System.Drawing.Size)
        Me.pgeRegExTester.TabIndex = CType(resources.GetObject("pgeRegExTester.TabIndex"), Integer)
        Me.pgeRegExTester.Text = resources.GetString("pgeRegExTester.Text")
        Me.pgeRegExTester.ToolTipText = resources.GetString("pgeRegExTester.ToolTipText")
        Me.pgeRegExTester.Visible = CType(resources.GetObject("pgeRegExTester.Visible"), Boolean)
        '
        'chkSingleLine
        '
        Me.chkSingleLine.AccessibleDescription = resources.GetString("chkSingleLine.AccessibleDescription")
        Me.chkSingleLine.AccessibleName = resources.GetString("chkSingleLine.AccessibleName")
        Me.chkSingleLine.Anchor = CType(resources.GetObject("chkSingleLine.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkSingleLine.Appearance = CType(resources.GetObject("chkSingleLine.Appearance"), System.Windows.Forms.Appearance)
        Me.chkSingleLine.BackgroundImage = CType(resources.GetObject("chkSingleLine.BackgroundImage"), System.Drawing.Image)
        Me.chkSingleLine.CheckAlign = CType(resources.GetObject("chkSingleLine.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkSingleLine.Dock = CType(resources.GetObject("chkSingleLine.Dock"), System.Windows.Forms.DockStyle)
        Me.chkSingleLine.Enabled = CType(resources.GetObject("chkSingleLine.Enabled"), Boolean)
        Me.chkSingleLine.FlatStyle = CType(resources.GetObject("chkSingleLine.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkSingleLine.Font = CType(resources.GetObject("chkSingleLine.Font"), System.Drawing.Font)
        Me.chkSingleLine.Image = CType(resources.GetObject("chkSingleLine.Image"), System.Drawing.Image)
        Me.chkSingleLine.ImageAlign = CType(resources.GetObject("chkSingleLine.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkSingleLine.ImageIndex = CType(resources.GetObject("chkSingleLine.ImageIndex"), Integer)
        Me.chkSingleLine.ImeMode = CType(resources.GetObject("chkSingleLine.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkSingleLine.Location = CType(resources.GetObject("chkSingleLine.Location"), System.Drawing.Point)
        Me.chkSingleLine.Name = "chkSingleLine"
        Me.chkSingleLine.RightToLeft = CType(resources.GetObject("chkSingleLine.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkSingleLine.Size = CType(resources.GetObject("chkSingleLine.Size"), System.Drawing.Size)
        Me.chkSingleLine.TabIndex = CType(resources.GetObject("chkSingleLine.TabIndex"), Integer)
        Me.chkSingleLine.Text = resources.GetString("chkSingleLine.Text")
        Me.chkSingleLine.TextAlign = CType(resources.GetObject("chkSingleLine.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkSingleLine.Visible = CType(resources.GetObject("chkSingleLine.Visible"), Boolean)
        '
        'txtResults
        '
        Me.txtResults.AcceptsReturn = True
        Me.txtResults.AcceptsTab = True
        Me.txtResults.AccessibleDescription = resources.GetString("txtResults.AccessibleDescription")
        Me.txtResults.AccessibleName = resources.GetString("txtResults.AccessibleName")
        Me.txtResults.Anchor = CType(resources.GetObject("txtResults.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtResults.AutoSize = CType(resources.GetObject("txtResults.AutoSize"), Boolean)
        Me.txtResults.BackgroundImage = CType(resources.GetObject("txtResults.BackgroundImage"), System.Drawing.Image)
        Me.txtResults.Dock = CType(resources.GetObject("txtResults.Dock"), System.Windows.Forms.DockStyle)
        Me.txtResults.Enabled = CType(resources.GetObject("txtResults.Enabled"), Boolean)
        Me.txtResults.Font = CType(resources.GetObject("txtResults.Font"), System.Drawing.Font)
        Me.txtResults.ImeMode = CType(resources.GetObject("txtResults.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtResults.Location = CType(resources.GetObject("txtResults.Location"), System.Drawing.Point)
        Me.txtResults.MaxLength = CType(resources.GetObject("txtResults.MaxLength"), Integer)
        Me.txtResults.Multiline = CType(resources.GetObject("txtResults.Multiline"), Boolean)
        Me.txtResults.Name = "txtResults"
        Me.txtResults.PasswordChar = CType(resources.GetObject("txtResults.PasswordChar"), Char)
        Me.txtResults.RightToLeft = CType(resources.GetObject("txtResults.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtResults.ScrollBars = CType(resources.GetObject("txtResults.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtResults.Size = CType(resources.GetObject("txtResults.Size"), System.Drawing.Size)
        Me.txtResults.TabIndex = CType(resources.GetObject("txtResults.TabIndex"), Integer)
        Me.txtResults.Text = resources.GetString("txtResults.Text")
        Me.txtResults.TextAlign = CType(resources.GetObject("txtResults.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtResults.Visible = CType(resources.GetObject("txtResults.Visible"), Boolean)
        Me.txtResults.WordWrap = CType(resources.GetObject("txtResults.WordWrap"), Boolean)
        '
        'txtSource
        '
        Me.txtSource.AcceptsReturn = True
        Me.txtSource.AcceptsTab = True
        Me.txtSource.AccessibleDescription = resources.GetString("txtSource.AccessibleDescription")
        Me.txtSource.AccessibleName = resources.GetString("txtSource.AccessibleName")
        Me.txtSource.Anchor = CType(resources.GetObject("txtSource.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtSource.AutoSize = CType(resources.GetObject("txtSource.AutoSize"), Boolean)
        Me.txtSource.BackgroundImage = CType(resources.GetObject("txtSource.BackgroundImage"), System.Drawing.Image)
        Me.txtSource.Dock = CType(resources.GetObject("txtSource.Dock"), System.Windows.Forms.DockStyle)
        Me.txtSource.Enabled = CType(resources.GetObject("txtSource.Enabled"), Boolean)
        Me.txtSource.Font = CType(resources.GetObject("txtSource.Font"), System.Drawing.Font)
        Me.txtSource.ImeMode = CType(resources.GetObject("txtSource.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtSource.Location = CType(resources.GetObject("txtSource.Location"), System.Drawing.Point)
        Me.txtSource.MaxLength = CType(resources.GetObject("txtSource.MaxLength"), Integer)
        Me.txtSource.Multiline = CType(resources.GetObject("txtSource.Multiline"), Boolean)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.PasswordChar = CType(resources.GetObject("txtSource.PasswordChar"), Char)
        Me.txtSource.RightToLeft = CType(resources.GetObject("txtSource.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtSource.ScrollBars = CType(resources.GetObject("txtSource.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtSource.Size = CType(resources.GetObject("txtSource.Size"), System.Drawing.Size)
        Me.txtSource.TabIndex = CType(resources.GetObject("txtSource.TabIndex"), Integer)
        Me.txtSource.Text = resources.GetString("txtSource.Text")
        Me.txtSource.TextAlign = CType(resources.GetObject("txtSource.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtSource.Visible = CType(resources.GetObject("txtSource.Visible"), Boolean)
        Me.txtSource.WordWrap = CType(resources.GetObject("txtSource.WordWrap"), Boolean)
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
        'btnReplace
        '
        Me.btnReplace.AccessibleDescription = resources.GetString("btnReplace.AccessibleDescription")
        Me.btnReplace.AccessibleName = resources.GetString("btnReplace.AccessibleName")
        Me.btnReplace.Anchor = CType(resources.GetObject("btnReplace.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnReplace.BackgroundImage = CType(resources.GetObject("btnReplace.BackgroundImage"), System.Drawing.Image)
        Me.btnReplace.Dock = CType(resources.GetObject("btnReplace.Dock"), System.Windows.Forms.DockStyle)
        Me.btnReplace.Enabled = CType(resources.GetObject("btnReplace.Enabled"), Boolean)
        Me.btnReplace.FlatStyle = CType(resources.GetObject("btnReplace.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnReplace.Font = CType(resources.GetObject("btnReplace.Font"), System.Drawing.Font)
        Me.btnReplace.Image = CType(resources.GetObject("btnReplace.Image"), System.Drawing.Image)
        Me.btnReplace.ImageAlign = CType(resources.GetObject("btnReplace.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnReplace.ImageIndex = CType(resources.GetObject("btnReplace.ImageIndex"), Integer)
        Me.btnReplace.ImeMode = CType(resources.GetObject("btnReplace.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnReplace.Location = CType(resources.GetObject("btnReplace.Location"), System.Drawing.Point)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.RightToLeft = CType(resources.GetObject("btnReplace.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnReplace.Size = CType(resources.GetObject("btnReplace.Size"), System.Drawing.Size)
        Me.btnReplace.TabIndex = CType(resources.GetObject("btnReplace.TabIndex"), Integer)
        Me.btnReplace.Text = resources.GetString("btnReplace.Text")
        Me.btnReplace.TextAlign = CType(resources.GetObject("btnReplace.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnReplace.Visible = CType(resources.GetObject("btnReplace.Visible"), Boolean)
        '
        'btnSplit
        '
        Me.btnSplit.AccessibleDescription = resources.GetString("btnSplit.AccessibleDescription")
        Me.btnSplit.AccessibleName = resources.GetString("btnSplit.AccessibleName")
        Me.btnSplit.Anchor = CType(resources.GetObject("btnSplit.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSplit.BackgroundImage = CType(resources.GetObject("btnSplit.BackgroundImage"), System.Drawing.Image)
        Me.btnSplit.Dock = CType(resources.GetObject("btnSplit.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSplit.Enabled = CType(resources.GetObject("btnSplit.Enabled"), Boolean)
        Me.btnSplit.FlatStyle = CType(resources.GetObject("btnSplit.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSplit.Font = CType(resources.GetObject("btnSplit.Font"), System.Drawing.Font)
        Me.btnSplit.Image = CType(resources.GetObject("btnSplit.Image"), System.Drawing.Image)
        Me.btnSplit.ImageAlign = CType(resources.GetObject("btnSplit.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSplit.ImageIndex = CType(resources.GetObject("btnSplit.ImageIndex"), Integer)
        Me.btnSplit.ImeMode = CType(resources.GetObject("btnSplit.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSplit.Location = CType(resources.GetObject("btnSplit.Location"), System.Drawing.Point)
        Me.btnSplit.Name = "btnSplit"
        Me.btnSplit.RightToLeft = CType(resources.GetObject("btnSplit.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSplit.Size = CType(resources.GetObject("btnSplit.Size"), System.Drawing.Size)
        Me.btnSplit.TabIndex = CType(resources.GetObject("btnSplit.TabIndex"), Integer)
        Me.btnSplit.Text = resources.GetString("btnSplit.Text")
        Me.btnSplit.TextAlign = CType(resources.GetObject("btnSplit.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSplit.Visible = CType(resources.GetObject("btnSplit.Visible"), Boolean)
        '
        'btnFind
        '
        Me.btnFind.AccessibleDescription = resources.GetString("btnFind.AccessibleDescription")
        Me.btnFind.AccessibleName = resources.GetString("btnFind.AccessibleName")
        Me.btnFind.Anchor = CType(resources.GetObject("btnFind.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnFind.BackgroundImage = CType(resources.GetObject("btnFind.BackgroundImage"), System.Drawing.Image)
        Me.btnFind.Dock = CType(resources.GetObject("btnFind.Dock"), System.Windows.Forms.DockStyle)
        Me.btnFind.Enabled = CType(resources.GetObject("btnFind.Enabled"), Boolean)
        Me.btnFind.FlatStyle = CType(resources.GetObject("btnFind.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnFind.Font = CType(resources.GetObject("btnFind.Font"), System.Drawing.Font)
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.ImageAlign = CType(resources.GetObject("btnFind.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnFind.ImageIndex = CType(resources.GetObject("btnFind.ImageIndex"), Integer)
        Me.btnFind.ImeMode = CType(resources.GetObject("btnFind.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnFind.Location = CType(resources.GetObject("btnFind.Location"), System.Drawing.Point)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.RightToLeft = CType(resources.GetObject("btnFind.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnFind.Size = CType(resources.GetObject("btnFind.Size"), System.Drawing.Size)
        Me.btnFind.TabIndex = CType(resources.GetObject("btnFind.TabIndex"), Integer)
        Me.btnFind.Text = resources.GetString("btnFind.Text")
        Me.btnFind.TextAlign = CType(resources.GetObject("btnFind.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnFind.Visible = CType(resources.GetObject("btnFind.Visible"), Boolean)
        '
        'txtReplace
        '
        Me.txtReplace.AccessibleDescription = resources.GetString("txtReplace.AccessibleDescription")
        Me.txtReplace.AccessibleName = resources.GetString("txtReplace.AccessibleName")
        Me.txtReplace.Anchor = CType(resources.GetObject("txtReplace.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtReplace.AutoSize = CType(resources.GetObject("txtReplace.AutoSize"), Boolean)
        Me.txtReplace.BackgroundImage = CType(resources.GetObject("txtReplace.BackgroundImage"), System.Drawing.Image)
        Me.txtReplace.Dock = CType(resources.GetObject("txtReplace.Dock"), System.Windows.Forms.DockStyle)
        Me.txtReplace.Enabled = CType(resources.GetObject("txtReplace.Enabled"), Boolean)
        Me.txtReplace.Font = CType(resources.GetObject("txtReplace.Font"), System.Drawing.Font)
        Me.txtReplace.ImeMode = CType(resources.GetObject("txtReplace.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtReplace.Location = CType(resources.GetObject("txtReplace.Location"), System.Drawing.Point)
        Me.txtReplace.MaxLength = CType(resources.GetObject("txtReplace.MaxLength"), Integer)
        Me.txtReplace.Multiline = CType(resources.GetObject("txtReplace.Multiline"), Boolean)
        Me.txtReplace.Name = "txtReplace"
        Me.txtReplace.PasswordChar = CType(resources.GetObject("txtReplace.PasswordChar"), Char)
        Me.txtReplace.RightToLeft = CType(resources.GetObject("txtReplace.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtReplace.ScrollBars = CType(resources.GetObject("txtReplace.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtReplace.Size = CType(resources.GetObject("txtReplace.Size"), System.Drawing.Size)
        Me.txtReplace.TabIndex = CType(resources.GetObject("txtReplace.TabIndex"), Integer)
        Me.txtReplace.Text = resources.GetString("txtReplace.Text")
        Me.txtReplace.TextAlign = CType(resources.GetObject("txtReplace.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtReplace.Visible = CType(resources.GetObject("txtReplace.Visible"), Boolean)
        Me.txtReplace.WordWrap = CType(resources.GetObject("txtReplace.WordWrap"), Boolean)
        '
        'txtRegEx
        '
        Me.txtRegEx.AccessibleDescription = resources.GetString("txtRegEx.AccessibleDescription")
        Me.txtRegEx.AccessibleName = resources.GetString("txtRegEx.AccessibleName")
        Me.txtRegEx.Anchor = CType(resources.GetObject("txtRegEx.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtRegEx.AutoSize = CType(resources.GetObject("txtRegEx.AutoSize"), Boolean)
        Me.txtRegEx.BackgroundImage = CType(resources.GetObject("txtRegEx.BackgroundImage"), System.Drawing.Image)
        Me.txtRegEx.Dock = CType(resources.GetObject("txtRegEx.Dock"), System.Windows.Forms.DockStyle)
        Me.txtRegEx.Enabled = CType(resources.GetObject("txtRegEx.Enabled"), Boolean)
        Me.txtRegEx.Font = CType(resources.GetObject("txtRegEx.Font"), System.Drawing.Font)
        Me.txtRegEx.ImeMode = CType(resources.GetObject("txtRegEx.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtRegEx.Location = CType(resources.GetObject("txtRegEx.Location"), System.Drawing.Point)
        Me.txtRegEx.MaxLength = CType(resources.GetObject("txtRegEx.MaxLength"), Integer)
        Me.txtRegEx.Multiline = CType(resources.GetObject("txtRegEx.Multiline"), Boolean)
        Me.txtRegEx.Name = "txtRegEx"
        Me.txtRegEx.PasswordChar = CType(resources.GetObject("txtRegEx.PasswordChar"), Char)
        Me.txtRegEx.RightToLeft = CType(resources.GetObject("txtRegEx.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtRegEx.ScrollBars = CType(resources.GetObject("txtRegEx.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtRegEx.Size = CType(resources.GetObject("txtRegEx.Size"), System.Drawing.Size)
        Me.txtRegEx.TabIndex = CType(resources.GetObject("txtRegEx.TabIndex"), Integer)
        Me.txtRegEx.Text = resources.GetString("txtRegEx.Text")
        Me.txtRegEx.TextAlign = CType(resources.GetObject("txtRegEx.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtRegEx.Visible = CType(resources.GetObject("txtRegEx.Visible"), Boolean)
        Me.txtRegEx.WordWrap = CType(resources.GetObject("txtRegEx.WordWrap"), Boolean)
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
        'lblResultCount
        '
        Me.lblResultCount.AccessibleDescription = resources.GetString("lblResultCount.AccessibleDescription")
        Me.lblResultCount.AccessibleName = resources.GetString("lblResultCount.AccessibleName")
        Me.lblResultCount.Anchor = CType(resources.GetObject("lblResultCount.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblResultCount.AutoSize = CType(resources.GetObject("lblResultCount.AutoSize"), Boolean)
        Me.lblResultCount.Dock = CType(resources.GetObject("lblResultCount.Dock"), System.Windows.Forms.DockStyle)
        Me.lblResultCount.Enabled = CType(resources.GetObject("lblResultCount.Enabled"), Boolean)
        Me.lblResultCount.Font = CType(resources.GetObject("lblResultCount.Font"), System.Drawing.Font)
        Me.lblResultCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblResultCount.Image = CType(resources.GetObject("lblResultCount.Image"), System.Drawing.Image)
        Me.lblResultCount.ImageAlign = CType(resources.GetObject("lblResultCount.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblResultCount.ImageIndex = CType(resources.GetObject("lblResultCount.ImageIndex"), Integer)
        Me.lblResultCount.ImeMode = CType(resources.GetObject("lblResultCount.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblResultCount.Location = CType(resources.GetObject("lblResultCount.Location"), System.Drawing.Point)
        Me.lblResultCount.Name = "lblResultCount"
        Me.lblResultCount.RightToLeft = CType(resources.GetObject("lblResultCount.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblResultCount.Size = CType(resources.GetObject("lblResultCount.Size"), System.Drawing.Size)
        Me.lblResultCount.TabIndex = CType(resources.GetObject("lblResultCount.TabIndex"), Integer)
        Me.lblResultCount.Text = resources.GetString("lblResultCount.Text")
        Me.lblResultCount.TextAlign = CType(resources.GetObject("lblResultCount.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblResultCount.Visible = CType(resources.GetObject("lblResultCount.Visible"), Boolean)
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
        'chkMultiline
        '
        Me.chkMultiline.AccessibleDescription = resources.GetString("chkMultiline.AccessibleDescription")
        Me.chkMultiline.AccessibleName = resources.GetString("chkMultiline.AccessibleName")
        Me.chkMultiline.Anchor = CType(resources.GetObject("chkMultiline.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkMultiline.Appearance = CType(resources.GetObject("chkMultiline.Appearance"), System.Windows.Forms.Appearance)
        Me.chkMultiline.BackgroundImage = CType(resources.GetObject("chkMultiline.BackgroundImage"), System.Drawing.Image)
        Me.chkMultiline.CheckAlign = CType(resources.GetObject("chkMultiline.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkMultiline.Dock = CType(resources.GetObject("chkMultiline.Dock"), System.Windows.Forms.DockStyle)
        Me.chkMultiline.Enabled = CType(resources.GetObject("chkMultiline.Enabled"), Boolean)
        Me.chkMultiline.FlatStyle = CType(resources.GetObject("chkMultiline.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkMultiline.Font = CType(resources.GetObject("chkMultiline.Font"), System.Drawing.Font)
        Me.chkMultiline.Image = CType(resources.GetObject("chkMultiline.Image"), System.Drawing.Image)
        Me.chkMultiline.ImageAlign = CType(resources.GetObject("chkMultiline.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkMultiline.ImageIndex = CType(resources.GetObject("chkMultiline.ImageIndex"), Integer)
        Me.chkMultiline.ImeMode = CType(resources.GetObject("chkMultiline.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkMultiline.Location = CType(resources.GetObject("chkMultiline.Location"), System.Drawing.Point)
        Me.chkMultiline.Name = "chkMultiline"
        Me.chkMultiline.RightToLeft = CType(resources.GetObject("chkMultiline.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkMultiline.Size = CType(resources.GetObject("chkMultiline.Size"), System.Drawing.Size)
        Me.chkMultiline.TabIndex = CType(resources.GetObject("chkMultiline.TabIndex"), Integer)
        Me.chkMultiline.Text = resources.GetString("chkMultiline.Text")
        Me.chkMultiline.TextAlign = CType(resources.GetObject("chkMultiline.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkMultiline.Visible = CType(resources.GetObject("chkMultiline.Visible"), Boolean)
        '
        'chkIgnoreCase
        '
        Me.chkIgnoreCase.AccessibleDescription = resources.GetString("chkIgnoreCase.AccessibleDescription")
        Me.chkIgnoreCase.AccessibleName = resources.GetString("chkIgnoreCase.AccessibleName")
        Me.chkIgnoreCase.Anchor = CType(resources.GetObject("chkIgnoreCase.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkIgnoreCase.Appearance = CType(resources.GetObject("chkIgnoreCase.Appearance"), System.Windows.Forms.Appearance)
        Me.chkIgnoreCase.BackgroundImage = CType(resources.GetObject("chkIgnoreCase.BackgroundImage"), System.Drawing.Image)
        Me.chkIgnoreCase.CheckAlign = CType(resources.GetObject("chkIgnoreCase.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkIgnoreCase.Dock = CType(resources.GetObject("chkIgnoreCase.Dock"), System.Windows.Forms.DockStyle)
        Me.chkIgnoreCase.Enabled = CType(resources.GetObject("chkIgnoreCase.Enabled"), Boolean)
        Me.chkIgnoreCase.FlatStyle = CType(resources.GetObject("chkIgnoreCase.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkIgnoreCase.Font = CType(resources.GetObject("chkIgnoreCase.Font"), System.Drawing.Font)
        Me.chkIgnoreCase.Image = CType(resources.GetObject("chkIgnoreCase.Image"), System.Drawing.Image)
        Me.chkIgnoreCase.ImageAlign = CType(resources.GetObject("chkIgnoreCase.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkIgnoreCase.ImageIndex = CType(resources.GetObject("chkIgnoreCase.ImageIndex"), Integer)
        Me.chkIgnoreCase.ImeMode = CType(resources.GetObject("chkIgnoreCase.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkIgnoreCase.Location = CType(resources.GetObject("chkIgnoreCase.Location"), System.Drawing.Point)
        Me.chkIgnoreCase.Name = "chkIgnoreCase"
        Me.chkIgnoreCase.RightToLeft = CType(resources.GetObject("chkIgnoreCase.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkIgnoreCase.Size = CType(resources.GetObject("chkIgnoreCase.Size"), System.Drawing.Size)
        Me.chkIgnoreCase.TabIndex = CType(resources.GetObject("chkIgnoreCase.TabIndex"), Integer)
        Me.chkIgnoreCase.Text = resources.GetString("chkIgnoreCase.Text")
        Me.chkIgnoreCase.TextAlign = CType(resources.GetObject("chkIgnoreCase.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkIgnoreCase.Visible = CType(resources.GetObject("chkIgnoreCase.Visible"), Boolean)
        '
        'chkShowCaptures
        '
        Me.chkShowCaptures.AccessibleDescription = resources.GetString("chkShowCaptures.AccessibleDescription")
        Me.chkShowCaptures.AccessibleName = resources.GetString("chkShowCaptures.AccessibleName")
        Me.chkShowCaptures.Anchor = CType(resources.GetObject("chkShowCaptures.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkShowCaptures.Appearance = CType(resources.GetObject("chkShowCaptures.Appearance"), System.Windows.Forms.Appearance)
        Me.chkShowCaptures.BackgroundImage = CType(resources.GetObject("chkShowCaptures.BackgroundImage"), System.Drawing.Image)
        Me.chkShowCaptures.CheckAlign = CType(resources.GetObject("chkShowCaptures.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkShowCaptures.Dock = CType(resources.GetObject("chkShowCaptures.Dock"), System.Windows.Forms.DockStyle)
        Me.chkShowCaptures.Enabled = CType(resources.GetObject("chkShowCaptures.Enabled"), Boolean)
        Me.chkShowCaptures.FlatStyle = CType(resources.GetObject("chkShowCaptures.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkShowCaptures.Font = CType(resources.GetObject("chkShowCaptures.Font"), System.Drawing.Font)
        Me.chkShowCaptures.Image = CType(resources.GetObject("chkShowCaptures.Image"), System.Drawing.Image)
        Me.chkShowCaptures.ImageAlign = CType(resources.GetObject("chkShowCaptures.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkShowCaptures.ImageIndex = CType(resources.GetObject("chkShowCaptures.ImageIndex"), Integer)
        Me.chkShowCaptures.ImeMode = CType(resources.GetObject("chkShowCaptures.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkShowCaptures.Location = CType(resources.GetObject("chkShowCaptures.Location"), System.Drawing.Point)
        Me.chkShowCaptures.Name = "chkShowCaptures"
        Me.chkShowCaptures.RightToLeft = CType(resources.GetObject("chkShowCaptures.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkShowCaptures.Size = CType(resources.GetObject("chkShowCaptures.Size"), System.Drawing.Size)
        Me.chkShowCaptures.TabIndex = CType(resources.GetObject("chkShowCaptures.TabIndex"), Integer)
        Me.chkShowCaptures.Text = resources.GetString("chkShowCaptures.Text")
        Me.chkShowCaptures.TextAlign = CType(resources.GetObject("chkShowCaptures.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkShowCaptures.Visible = CType(resources.GetObject("chkShowCaptures.Visible"), Boolean)
        '
        'chkShowGroups
        '
        Me.chkShowGroups.AccessibleDescription = resources.GetString("chkShowGroups.AccessibleDescription")
        Me.chkShowGroups.AccessibleName = resources.GetString("chkShowGroups.AccessibleName")
        Me.chkShowGroups.Anchor = CType(resources.GetObject("chkShowGroups.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkShowGroups.Appearance = CType(resources.GetObject("chkShowGroups.Appearance"), System.Windows.Forms.Appearance)
        Me.chkShowGroups.BackgroundImage = CType(resources.GetObject("chkShowGroups.BackgroundImage"), System.Drawing.Image)
        Me.chkShowGroups.CheckAlign = CType(resources.GetObject("chkShowGroups.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkShowGroups.Checked = True
        Me.chkShowGroups.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowGroups.Dock = CType(resources.GetObject("chkShowGroups.Dock"), System.Windows.Forms.DockStyle)
        Me.chkShowGroups.Enabled = CType(resources.GetObject("chkShowGroups.Enabled"), Boolean)
        Me.chkShowGroups.FlatStyle = CType(resources.GetObject("chkShowGroups.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkShowGroups.Font = CType(resources.GetObject("chkShowGroups.Font"), System.Drawing.Font)
        Me.chkShowGroups.Image = CType(resources.GetObject("chkShowGroups.Image"), System.Drawing.Image)
        Me.chkShowGroups.ImageAlign = CType(resources.GetObject("chkShowGroups.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkShowGroups.ImageIndex = CType(resources.GetObject("chkShowGroups.ImageIndex"), Integer)
        Me.chkShowGroups.ImeMode = CType(resources.GetObject("chkShowGroups.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkShowGroups.Location = CType(resources.GetObject("chkShowGroups.Location"), System.Drawing.Point)
        Me.chkShowGroups.Name = "chkShowGroups"
        Me.chkShowGroups.RightToLeft = CType(resources.GetObject("chkShowGroups.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkShowGroups.Size = CType(resources.GetObject("chkShowGroups.Size"), System.Drawing.Size)
        Me.chkShowGroups.TabIndex = CType(resources.GetObject("chkShowGroups.TabIndex"), Integer)
        Me.chkShowGroups.Text = resources.GetString("chkShowGroups.Text")
        Me.chkShowGroups.TextAlign = CType(resources.GetObject("chkShowGroups.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkShowGroups.Visible = CType(resources.GetObject("chkShowGroups.Visible"), Boolean)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = resources.GetString("OpenFileDialog1.Filter")
        Me.OpenFileDialog1.Title = resources.GetString("OpenFileDialog1.Title")
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.Filter = resources.GetString("OpenFileDialog2.Filter")
        Me.OpenFileDialog2.Title = resources.GetString("OpenFileDialog2.Title")
        '
        'lblValid
        '
        Me.lblValid.AccessibleDescription = CType(resources.GetObject("lblValid.AccessibleDescription"), String)
        Me.lblValid.AccessibleName = CType(resources.GetObject("lblValid.AccessibleName"), String)
        Me.lblValid.Anchor = CType(resources.GetObject("lblValid.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblValid.AutoSize = CType(resources.GetObject("lblValid.AutoSize"), Boolean)
        Me.lblValid.Dock = CType(resources.GetObject("lblValid.Dock"), System.Windows.Forms.DockStyle)
        Me.lblValid.Enabled = CType(resources.GetObject("lblValid.Enabled"), Boolean)
        Me.lblValid.Font = CType(resources.GetObject("lblValid.Font"), System.Drawing.Font)
        Me.lblValid.Image = CType(resources.GetObject("lblValid.Image"), System.Drawing.Image)
        Me.lblValid.ImageAlign = CType(resources.GetObject("lblValid.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblValid.ImageIndex = CType(resources.GetObject("lblValid.ImageIndex"), Integer)
        Me.lblValid.ImeMode = CType(resources.GetObject("lblValid.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblValid.Location = CType(resources.GetObject("lblValid.Location"), System.Drawing.Point)
        Me.lblValid.Name = "lblValid"
        Me.lblValid.RightToLeft = CType(resources.GetObject("lblValid.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblValid.Size = CType(resources.GetObject("lblValid.Size"), System.Drawing.Size)
        Me.lblValid.TabIndex = CType(resources.GetObject("lblValid.TabIndex"), Integer)
        Me.lblValid.Text = resources.GetString("lblValid.Text")
        Me.lblValid.TextAlign = CType(resources.GetObject("lblValid.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblValid.Visible = CType(resources.GetObject("lblValid.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
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
        Me.TabControl1.ResumeLayout(False)
        Me.pgeSimple.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grpValidation.ResumeLayout(False)
        Me.pgeScreenScrape.ResumeLayout(False)
        Me.pgeRegExTester.ResumeLayout(False)
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

    Private htImages As Hashtable
    Protected frmImageViewer As frmImageViewer
    Private frmStatus As frmStatus
    Public strDomain As String
    Public strUrlEntered As String
    Private wreqScrape As HttpWebRequest
    Private wresScrape As HttpWebResponse

    ' Handles the "Find" button click event on the "RegEx Tester" tab. This routine
    ' finds matches in the source text and displays the group and capture values in 
    ' the results TextBox.
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim re As Regex
        Dim reOpt As RegexOptions = GetRegexOptions()

        Try
            re = New Regex(txtRegEx.Text, reOpt)
        Catch exp As Exception
            MsgBox("An error was encountered when attempting to parse the " & _
                "source text. This is often caused by an invalid regex pattern." & _
                "  Check your expression and try again. Exp.Msg=" & exp.Message, _
                MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End Try

        ' Get the collection of matches resulting from applying the pattern to the
        ' source text.
        Dim mc As MatchCollection = re.Matches(txtSource.Text)

        ' Display the number of matches and clear any existing results.
        lblResultCount.Text = mc.Count.ToString & " matches"
        txtResults.Clear()

        Dim m As Match
        ' Iterate through the collection of matches and, based on UI settings, 
        ' display the values of the groups and/or captures.
        For Each m In mc
            AppendResults("'" & m.Value & "' at index " & m.Index)

            If m.Groups.Count > 1 And chkShowGroups.Checked Then
                Dim g As Group, i As Integer

                ' Skip the 0th group, which is the entire Match object.
                For i = 1 To m.Groups.Count - 1
                    ' Get a reference to the corresponding group.
                    g = m.Groups(i)

                    AppendResults(String.Format("   group({0}) = '{1}'", i, g.Value))

                    If chkShowCaptures.Checked = True Then
                        ' Get the capture collection for this group.                
                        Dim cc As CaptureCollection = g.Captures
                        ' Display information on each capture.
                        Dim c As Capture
                        For Each c In cc
                            AppendResults(String.Format("      " & _
                                "capture '{0}' at index {1}", c.Value, c.Index))
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    ' This routine handles the "Find the Number!" button Click event. It finds the 
    ' first number in a character string and displays the number and its starting 
    ' position in the string.
    Private Sub btnFindNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindNumber.Click
        ' Create an instance of RegEx and pass in the pattern, which will find one 
        ' or more digits.
        Dim re As New Regex("\d+")
        ' Call Match, passing in the source text.
        Dim m As Match = re.Match(txtFindNumber.Text)

        ' If a match is found, show the results. If not, display an "error" message.
        If m.Success Then
            lblResults.Text = String.Format("RegEx found " & _
                m.Value & " at position " & m.Index.ToString)
        Else
            lblResults.Text = "You didn't enter a string containing a number!"
        End If
    End Sub

    ' Handles the Click event for the "Replace" button. Replaces text in the source
    ' with the replacement text when a match is found.
    Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplace.Click
        Try
            txtResults.Text = Regex.Replace(txtSource.Text, txtRegEx.Text, _
                txtReplace.Text, GetRegexOptions())
        Catch exp As Exception
            MsgBox(exp.ToString, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    ' Handles the "Scrape" button click event.
    Private Sub btnScrape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScrape.Click
        Dim strHttpSource As String

        If UrlIsValid() Then
            ' Get a String containing the Web page's source code. See the two custom
            ' functions used here for further comments.
            Try
                strHttpSource = ConvertStreamToString(GetHttpStream(txtURL.Text))
            Catch exp As Exception
                ' Set text to exp.Message to show the custom error message set in the 
                ' function that was called.
                MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End Try

            Dim strRegExPattern As String

            ' Assign a variable to the full Url entered by the user. 
            strUrlEntered = Trim(txtURL.Text)
            ' Get the Domain name for use in various places. It's best to set the 
            ' value in the Click event so that the items displayed in either ListView
            ' control are always associated with the correct Domain name. If this
            ' value is assigned elsewhere, the user can change the Domain name and 
            ' then double-click an item in the ListView, which could cause an invalid 
            ' Url for the item.
            Dim astrDomain() As String = Regex.Split(strUrlEntered, "/")
            ' The first element (0) is "http:" and the 3rd element is the actual
            ' Domain name.
            strDomain = astrDomain(0) & "//" & astrDomain(2)

            If optLinks.Checked Then
                ShowStatusIndicators("Connecting to Web page to screen scrape " & _
                    "the links. Please stand by...")

                lvwLinks.Items.Clear()

                ' The regular expression used here to parse an HTML anchor, e.g.,
                ' <a href="http://www.microsoft.com/net">Microsoft</a> is explained 
                ' as follows:
                '   <a          The beginning of the HTML anchor
                '   \s+         One or more white space characters
                '   href        Continuing with exact text in HTML anchor
                '   \s*         Zero or more white space characters
                '   =           Continuing with exact text in HTML anchor
                '   \s*         Zero or more white space characters
                '   ""?         Zero or none quotation mark (escaped)
                '   (           Start of group defining a substring: The anchor URL.
                '   [^"" >]+    One or more matches of any character except those 
                '               in brackets.
                '   )           End of first group defining a substring
                '   ""?         Zero or none quotation mark (escaped)
                '   >           Continuing with exact text in HTML anchor
                '   (.+)        A group matching any character: The anchor text.
                '   </a>        Ending exact text of HTML anchor               
                '
                ' CAUTION: If you want to experiment with these patterns in the 
                ' RegEx Tester, make sure you un-escape the double quotes.
                strRegExPattern = "<a\s+href\s*=\s*""?([^"" >]+)""?>(.+)</a>"
            Else
                ShowStatusIndicators("Connecting to Web page to screen scrape the " & _
                    "images. Please stand by...")

                htImages = New Hashtable()
                lvwImages.Items.Clear()

                ' The regular expression to scrape images is conceptually similar to 
                ' the pattern for scraping HTML anchors. However, in this case the 
                ' pattern is conciderably more complex because we are capturing up to
                ' four different attributes which can appear in any order.
                '
                ' To keep the length and complexity of the regular expression used 
                ' here within reason, the following assumptions are made about the 
                ' HTML <img> tags being processed on any given Web page:
                '
                '   1. The src attribute is always present. It is the only required 
                '      attribute.
                '   2. The src attribute precedes width and height. If not, width and
                '      height are not grabbed.
                '   3. The alt attribute follows width and height. If not, alt is not 
                '      grabbed.
                '   4. Width and height can follow src in any order relative to each 
                '      other. The pattern covers both options.
                '
                ' This ensures that all images on the page are scaped. It means, 
                ' however, that some of the other attribute data may not appear.
                '
                ' Some of the key phrases used in this pattern are:
                ' 
                '   [^>]+       Match any characters except >. This is how you can 
                '               move to the next attribute you are interested in.
                '   (?:         Start a non-capturing group. This is used with a
                '               closing )? to create an optional group (zero or one
                '               match). This is how you make all attributes optional
                '               except src.
                '   |           Used with width and height as an Or expression. Notice
                '               that in the first pair width comes first, and in the 
                '               second pair, the order is reversed.
                strRegExPattern = "<img[^>]+(src)\s*=\s*""?([^ "">]+)""?(?:[^>]+(width|height)\s*=\s*""?([^ "">]+)""?\s+(height|width)\s*=\s*""?([^ "">]+)""?)?(?:[^>]+(alt)\s*=\s*""?([^"">]+)""?)?"
            End If

            Dim re As New Regex(strRegExPattern, RegexOptions.IgnoreCase)
            Dim m As Match = re.Match(strHttpSource)

            ' Process the HTML source code. Because the source is a long string, 
            ' instead of using Matches method use the more efficient Match(), which
            ' only returns one match at a time. The Success property determines
            ' whether another match exists. NextMatch() causes the iteration.
            While m.Success
                If optImages.Checked Then

                    Dim strWidth, strHeight As String
                    ' Because the pattern gives optional ordering for the width and 
                    ' height attributes, determine which attribute was listed first
                    ' in order, and then assign the proper Group item value.
                    If m.Groups(3).Value.ToLower = "width" Then
                        strWidth = m.Groups(4).Value
                        strHeight = m.Groups(6).Value
                    Else ' The height attribute came first
                        strWidth = m.Groups(6).Value
                        strHeight = m.Groups(4).Value
                    End If

                    ' Call AddImage to add an instance of the custom ImageAttributes 
                    ' object to a Hashtable. See AddImage for further comments on why
                    ' a Hashtable is used.
                    AddImage(New ImageAttributes(m.Groups(2).Value, _
                        m.Groups(8).Value, strHeight, strWidth))
                Else
                    ' Create a ListViewItem object and set the first column's 
                    ' text ("src").
                    Dim lvi As New ListViewItem()
                    lvi.Text = m.Groups(1).Value
                    lvwLinks.Items.Add(lvi)
                End If

                ' Continue the loop to the next match.
                m = m.NextMatch()
            End While

            HideStatusIndicators()

            ' Display controls appropriate the results.
            If optImages.Checked Then
                If Not IsNothing(htImages) Then
                    FillImagesListView()
                Else
                    MsgBox("No images were found whose attributes matched the " & _
                        "regular expression.", MsgBoxStyle.Information, Me.Text)
                End If
            Else
                If lvwLinks.Items.Count = 0 Then
                    MsgBox("No links were found whose Url matched the regular " & _
                    "expression.", MsgBoxStyle.Information, Me.Text)
                End If
            End If
        End If
    End Sub

    ' Handles the "Split" button click event. This routine splits the source text
    ' into a string array instead of a MatchCollection (as in the "Find" button).
    ' RegEx.Split is similar to String.Split except that it defines the delimiter
    ' by using a regular expression rather than a single character.
    Private Sub btnSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSplit.Click
        ' Clear existing results and then split the source text.
        txtResults.Clear()

        ' Here we are calling the shared Split method, without the use of a 
        ' RegEx instance.  A good split pattern to try is \s*,\s*, which creates 
        ' an array of any characters separated by a comma. In this case, 
        ' RegEx.Split(txtSource.Text, "\s*,\s*") would produce the same results as:
        '
        '       txtRegEx.Text.Split(New Char() {CChar(",")})
        '       Microsoft.VisualBasic.Split(txtRegEx.Text, ",")
        '
        ' You can further modify the regular expression to discard any empty 
        ' elements in the resulting string array: \s*[,]+\s*
        Dim astrResults() As String
        Try
            astrResults = Regex.Split(txtSource.Text, txtRegEx.Text, _
                GetRegexOptions())
        Catch exp As Exception
            MsgBox("An error was encountered when attempting to parse the " & _
                "source text. This is often caused by an invalid regex pattern." & _
                "  Check your expression and try again. Exp.Msg=" & exp.Message, _
                MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End Try

        ' To be split a string array of at least two elements must be created.
        If astrResults.Length > 1 Then
            AppendResults("The source text was split into " & _
                astrResults.Length & " items.")

            Dim s As String
            For Each s In astrResults
                AppendResults(s)
            Next
        Else
            AppendResults("The source text could not be split. " & _
                "Check your regular expression pattern and try again.")
        End If
    End Sub

    ' Handles the Validate! button click event on the "Simple Samples" tab.
    Private Sub btnValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidate.Click
        Dim IsValid As Boolean = True

        ' When performing validation, a couple of pattern elements are normally
        ' used all of the time:
        '
        '   ^ and $     The source string can only contain what is in between, i.e.,
        '               a date. It's a good idea to wrap validation patterns in
        '               these characters or else it will merely match the pattern
        '               whereever it appears. For example, if you do not, this would 
        '               pass as a valid date in this application: "kjdi12-25-2000xpL" 
        '
        '   \s*         At the beginning and end of the string, this indicates
        '               that white space is acceptable.
        '
        ' The following pattern checks whether the input string is a valid zip
        ' code in the format ddddd or ddddd-dddd, where d is any digit 0-9. Key 
        ' pattern elements used are:
        '
        '   \d          Any digit (0-9).
        '   |           A pipe denotes that the Zip code can either be 5 digits
        '               or 5 digits followed by a dash and four digits.
        '
        If Not Regex.IsMatch(txtZip.Text, "^\s*(\d{5}|(\d{5}-\d{4}))\s*$") Then
            txtZip.ForeColor = Color.Red
            IsValid = False
        Else
            txtZip.ForeColor = Color.Black
        End If

        ' The following pattern checks whether the input string is a date in the 
        ' format mm-dd-yy or mm-dd-yyyy. Key pattern elements used are:
        '
        '   \d{1,2}     Month and day numbers can have 1 or 2 digits. The use of
        '               (\d{4}|\d{2}) means the year can have 2 or 4 digits.
        '   (/|-)       Either the slash or the dash are valid date separators.
        '   \1          The separator used for the day and year must be the same
        '               as the separator used for month and day. The 1 refers to the
        '               first numbered group, defined by parentheses, e.g, (/|-).
        '   
        ' You could improve on this pattern by ensuring that digits do not start with
        ' a zero and that they are in a valid numerical range.
        '
        If Not Regex.IsMatch(txtDate.Text, _
            "^\s*\d{1,2}(/|-)\d{1,2}\1(\d{4}|\d{2})\s*$") Then

            txtDate.ForeColor = Color.Red
            IsValid = False
        Else
            txtDate.ForeColor = Color.Black
        End If

        ' The following pattern checks whether the input string is a valid email 
        ' address in the form "name@domain.com". Actually, it does not have to be a 
        ' ".com" address. Any combination of letters following the last period are 
        ' fine. Also, the email name can have a dash or be separated by one or more 
        ' periods. The Domain name can also have multiple words separated by periods. 
        ' Thus, it will validate bob@hotmail.com and bill.michaels@us.office.gov.
        '
        '   ([\w-]+\.)*?    Zero or more matches of any character (a-z, A-Z, 0-9, and
        '                   underscore) or dash, followed by only one period.
        '   [\w-]           On either side of the @ character this ensures the 
        '                   address is in the form name@domainname.
        '   +\.             Ensures there is at least one period in the domain name.
        '
        If Not Regex.IsMatch(txtEmail.Text, _
            "^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$") Then

            txtEmail.ForeColor = Color.Red
            IsValid = False
        Else
            txtEmail.ForeColor = Color.Black
        End If

        If IsValid Then
            lblValid.Visible = True
        Else
            lblValid.Visible = False
        End If
    End Sub

    ' This routine handles the DoubleClick event for the "Images" ListView.
    ' Double-clicking an image opens frmImageViewer, requests the image as a Stream
    ' from the Web server, and then displays it in a PictureBox.
    Private Sub lvImages_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwImages.DoubleClick

        ' Wrap all code in the validation check to ensure the user has not changed
        ' the Url to an invalid value before double-clicking an item.
        If UrlIsValid() Then
            Dim strImgSrc As String = lvwImages.SelectedItems(0).Text

            ShowStatusIndicators("Connecting to Web page to retrieve the " & _
                "selected image. Please stand by...")

            If IsNothing(frmImageViewer) Then
                frmImageViewer = New frmImageViewer()
            End If

            ' If the image path clicked by the user is not an absolute path, correct
            ' it and then Show the ImageViewer Form.
            If Microsoft.VisualBasic.Left(strImgSrc, 7) <> "http://" Then
                strImgSrc = MakeRelativeUrlAbsolute(strImgSrc)
            End If

            frmImageViewer.Show(strImgSrc)

            HideStatusIndicators()
        End If

    End Sub

    ' This routine handles the DoubleClick event for the "Links" ListView. 
    ' Double-clicking a link starts a new instance of Internet Explorer and 
    ' navigates to the requested page.
    Private Sub lvLinks_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwLinks.DoubleClick

        ' Wrap all code in the validation check to ensure the user has not changed
        ' the Url to an invalid value before double-clicking an item.
        If UrlIsValid() Then

            Dim strClickedUrl As String = lvwLinks.SelectedItems(0).Text

            ShowStatusIndicators("Starting Internet Explorer and connecting to " & _
                "the selected Web page. Please stand by...")

            ' If the path to the page clicked by the user is not an absolute path, 
            ' correct it and then start Internet Explorer, navigating to the page.
            If Microsoft.VisualBasic.Left(strClickedUrl, 7) <> "http://" Then
                strClickedUrl = MakeRelativeUrlAbsolute(strClickedUrl)
            End If

            ' It is either a root-relative or relative path. So make the relative 
            ' Url into an absolute Url.
            Process.Start("IExplore.exe", strClickedUrl)

            HideStatusIndicators()

        End If

    End Sub

    ' This routine handles the CheckedChanged event for the RadioButton controls on 
    ' the "Screen Scrape" tab. The ListView controls are swapped out depending on 
    ' which option is checked.
    Private Sub RadioButtons_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optImages.CheckedChanged, optLinks.CheckedChanged
        If optLinks.Checked Then
            lvwLinks.Visible = True
            lvwImages.Visible = False
        Else
            lvwImages.Visible = True
            lvwLinks.Visible = False
        End If
    End Sub

    ' This routine adds an ImageAttributes object to the HashTable if it has not
    ' already been added. The "Src" attribute is used as the key for lookups. If
    ' the Src key already exists, the object is not added. This prevents identical
    ' images from appearing in the list more than once.
    Protected Sub AddImage(ByVal imgAttr As ImageAttributes)
        If Not htImages.Contains(imgAttr.Src) Then
            htImages.Add(imgAttr.Src, imgAttr)
        End If
    End Sub

    ' This is a helper routine for appending text results.
    Sub AppendResults(ByVal msg As String)
        txtResults.AppendText(msg & ControlChars.CrLf)
    End Sub

    ' This function reads a Stream returned by an HttpWebResponse object and 
    ' converts it to a String for RegEx processing.
    Function ConvertStreamToString(ByVal stmSource As Stream) As String
        Dim sr As StreamReader

        If Not IsNothing(stmSource) Then
            Try
                sr = New StreamReader(stmSource)
                ' Read and return the entire contents of the stream.
                Return sr.ReadToEnd
            Catch exp As Exception
                ' Don't show a MsgBox. Simply forward the custom error message 
                ' from GetHttpStream().
                Throw New Exception()
            Finally
                ' Clean up both the Stream and the StreamReader.
                wresScrape.Close()
                sr.Close()
            End Try
        End If

    End Function

    ' This routine iterates through a HashTable and adds a ListViewItem with
    ' ListViewItem.SubItems for each of the custom ImageAttributes objects in
    ' the HashTable.
    Protected Sub FillImagesListView()
        Dim strSrc As String

        For Each strSrc In htImages.Keys
            ' Create a ListViewItem object and set the first column's text.
            Dim lvi As New ListViewItem()
            lvi.Text = strSrc

            ' Set the text in the remaining columns and add the ListViewItem object
            ' to the ListView.
            Dim imgAttr As ImageAttributes = CType(htImages(strSrc), ImageAttributes)
            With lvi.SubItems
                .Add(imgAttr.Alt)
                .Add(imgAttr.Height)
                .Add(imgAttr.Width)
            End With

            ' Add the ListViewItem to the ListView's Items collection.
            lvwImages.Items.Add(lvi)
        Next
    End Sub

    ' This function uses .NET classes that derive from System.Net.WebRequest to 
    ' retrieve an HTTP response Stream that becomes the RegEx parsing source or the 
    ' image to be displayed when called by frmImageViewer.Show().
    Function GetHttpStream(ByVal url As String) As Stream
        ' Create the request using the WebRequestFactory.
        wreqScrape = CType(WebRequest.Create(url), HttpWebRequest)
        With wreqScrape
            .UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0b; Windows NT 5.1)"
            .Method = "GET"
            .Timeout = 10000
        End With

        Try
            ' Return the response stream.
            wresScrape = CType(wreqScrape.GetResponse(), HttpWebResponse)
            Return wresScrape.GetResponseStream()
        Catch exp As Exception
            ' As the error is most likely caused by a mistyped Url or not having
            ' a connection to the Internet, create a custom error message that
            ' is forwarded back to the calling function.
            Throw New Exception("There was an error retrieving the Web page " & _
                "you requested. Please check the Url and your connection to " & _
                "the Internet, and try again.")
        End Try
    End Function

    ' This is a helper routine to retrieve various regular expression pattern 
    ' matching options.
    Function GetRegexOptions() As RegexOptions
        ' Using any of the RegExOptions is the same as placing the entire regular
        ' expression in parentheses (i.e., making the entire pattern its own group)
        ' and then prefacing it inside the left parenthesis with the option 
        ' character. If you want finer control over an option --i.e., within a 
        ' particular group--create a group within the pattern and use the same
        ' syntax. In this case you would not want to use one of the RegexOptions
        ' because these are applied to the entire pattern. To turn off an option 
        ' simply negate it (e.g., to turn case sensitivity off you would type
        ' ?-i: inside the left parenthesis of a group).
        '
        ' All Options are off by default.
        '
        ' The IgnoreCase enum turns case sensitivity on/off for the entire pattern.
        ' Using this enum is the same as typing (?i:OriginalPattern) using only 
        ' regular expression syntax.
        If chkIgnoreCase.Checked Then GetRegexOptions = RegexOptions.IgnoreCase

        ' The Singleline enum changes the behavior of the . (dot) character so that
        ' it now matches any character (instead of its default behavior of any 
        ' character except the newline character, \r or \n). Using this enum is the 
        ' same as typing (?s:OriginalPattern) using only regular expression syntax.
        ' 
        ' Note also that multiple RegExOptions can be used when separated by the
        ' bitwise Or operator. (Alternatively, you could enable multiple options
        ' using only regular expression syntax by placing options together after the
        ' ? character. For example, to turn on Singleline mode and ignore case, you 
        ' would type (?si:OriginalPattern).
        If chkSingleLine.Checked Then
            GetRegexOptions = GetRegexOptions Or RegexOptions.Singleline
        End If

        ' The Multiline enum changes the behavior of the ^ and $ characters so that
        ' they now match the beginning and end of a line instead of the beginning
        ' and of an entire string. Using this enum is the same as typing 
        ' (?m:OriginalPattern) using only regular expression syntax.
        '
        ' It may seem confusing that you can enable both Singleline and Multiline
        ' modes, but the confusion likely stems from the misleading names given to 
        ' these options. If you disregard their name and consider what they actually
        ' effect, there is no conflict.
        If chkMultiline.Checked Then
            GetRegexOptions = GetRegexOptions Or RegexOptions.Multiline
        End If
    End Function

    ' This routine turns off the status indicators enabled by ShowStatusIndicators.
    Private Sub HideStatusIndicators()
        frmStatus.Hide()
        Me.Cursor = Cursors.Default
    End Sub

    ' This function takes a relative Url and makes it absolute. It is a helper 
    ' for the DoubleClick event handlers on the "Screen Scrape" tab. The "href" or 
    ' "url" attributes can contain an absolute path, a root-relative path, or a 
    ' relative path. If the path to the clicked item is not absolute, this function
    ' makes it absolute by prefacing it with the Domain name and a slash, if needed.
    Public Function MakeRelativeUrlAbsolute(ByVal strRelativeUrl As String) As String

        ' If it is a root-relative path (has a leading "/"), then it needs to be 
        ' prefaced by the Domain name. If it is a relative Url it needs to be 
        ' prefaced with the full Url as entered by the user. 

        ' Is it a root-relative path?
        If Microsoft.VisualBasic.Left(strRelativeUrl, 1) = "/" Then
            ' Preface the root-relative path with the Domain name.
            Return strDomain & strRelativeUrl
        ElseIf Microsoft.VisualBasic.Left(strRelativeUrl, 3) = "../" Then
            ' Remove the dots and preface the root-relative path with the 
            ' Domain name.
            Return strDomain & _
                Microsoft.VisualBasic.Replace(strRelativeUrl, "../", "/")
        Else ' It is a relative path.
            ' Check to see if the Url entered by the user has a trailing "/". If not, 
            ' add one.
            If Microsoft.VisualBasic.Right(strUrlEntered, 1) = "/" Then
                Return strUrlEntered & strRelativeUrl
            Else
                Return strUrlEntered & "/" & strRelativeUrl
            End If
        End If
    End Function

    ' This routine provides user feedback by showing a small status form with a 
    ' message and setting the WaitCursor to indicate a task is being performed.
    Private Sub ShowStatusIndicators(ByVal strMsg As String)
        frmStatus = New frmStatus()
        frmStatus.Show(strMsg)
        Me.Cursor = Cursors.WaitCursor
    End Sub

    ' This function checks whether the Url entered by the user starts with 
    ' http://.
    Function UrlIsValid() As Boolean
        If Microsoft.VisualBasic.Left(Trim(txtURL.Text), 7) <> "http://" Then
            MsgBox("The Url must begin with http://.")
            Return False
        End If

        Return True
    End Function

End Class