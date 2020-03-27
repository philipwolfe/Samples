'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports ADODB

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Protected Const MSDE_CONNECTION_STRING As String = _
            "driver={SQL Server};server=(local)\VSDotNet;uid=;pwd=;database=Northwind"

    Protected Const SQL_CONNECTION_STRING As String = _
        "driver={SQL Server};server=localhost;uid=;pwd=;database=Northwind"

    Private ConnectionString As String = SQL_CONNECTION_STRING
    Private HasConnected As Boolean = False

    Dim cnn As New Connection()
    Dim cm As New Command()
    Dim rs As New Recordset()


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

        PopulateSimpleNavigationForm()

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
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tpDatasetExample As System.Windows.Forms.TabPage
    Friend WithEvents btnDataset As System.Windows.Forms.Button
    Friend WithEvents dgMain As System.Windows.Forms.DataGrid
    Friend WithEvents tpRecordNavigation As System.Windows.Forms.TabPage
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtContactName As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents tpInsert As System.Windows.Forms.TabPage
    Friend WithEvents txtCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents lblCategoryName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tpUpdate As System.Windows.Forms.TabPage
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbCategoryName As System.Windows.Forms.ComboBox
    Friend WithEvents txtUpdateDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpRecordNavigation = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtContactName = New System.Windows.Forms.TextBox()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.tpInsert = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCategoryName = New System.Windows.Forms.Label()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtCategoryName = New System.Windows.Forms.TextBox()
        Me.tpUpdate = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUpdateDescription = New System.Windows.Forms.TextBox()
        Me.cbCategoryName = New System.Windows.Forms.ComboBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.tpDatasetExample = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnDataset = New System.Windows.Forms.Button()
        Me.dgMain = New System.Windows.Forms.DataGrid()
        Me.tcMain.SuspendLayout()
        Me.tpRecordNavigation.SuspendLayout()
        Me.tpInsert.SuspendLayout()
        Me.tpUpdate.SuspendLayout()
        Me.tpDatasetExample.SuspendLayout()
        CType(Me.dgMain, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'tcMain
        '
        Me.tcMain.AccessibleDescription = CType(resources.GetObject("tcMain.AccessibleDescription"), String)
        Me.tcMain.AccessibleName = CType(resources.GetObject("tcMain.AccessibleName"), String)
        Me.tcMain.Alignment = CType(resources.GetObject("tcMain.Alignment"), System.Windows.Forms.TabAlignment)
        Me.tcMain.Anchor = CType(resources.GetObject("tcMain.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tcMain.Appearance = CType(resources.GetObject("tcMain.Appearance"), System.Windows.Forms.TabAppearance)
        Me.tcMain.BackgroundImage = CType(resources.GetObject("tcMain.BackgroundImage"), System.Drawing.Image)
        Me.tcMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpRecordNavigation, Me.tpInsert, Me.tpUpdate, Me.tpDatasetExample})
        Me.tcMain.Dock = CType(resources.GetObject("tcMain.Dock"), System.Windows.Forms.DockStyle)
        Me.tcMain.Enabled = CType(resources.GetObject("tcMain.Enabled"), Boolean)
        Me.tcMain.Font = CType(resources.GetObject("tcMain.Font"), System.Drawing.Font)
        Me.tcMain.ImeMode = CType(resources.GetObject("tcMain.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tcMain.ItemSize = CType(resources.GetObject("tcMain.ItemSize"), System.Drawing.Size)
        Me.tcMain.Location = CType(resources.GetObject("tcMain.Location"), System.Drawing.Point)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.Padding = CType(resources.GetObject("tcMain.Padding"), System.Drawing.Point)
        Me.tcMain.RightToLeft = CType(resources.GetObject("tcMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.ShowToolTips = CType(resources.GetObject("tcMain.ShowToolTips"), Boolean)
        Me.tcMain.Size = CType(resources.GetObject("tcMain.Size"), System.Drawing.Size)
        Me.tcMain.TabIndex = CType(resources.GetObject("tcMain.TabIndex"), Integer)
        Me.tcMain.Text = resources.GetString("tcMain.Text")
        Me.tcMain.Visible = CType(resources.GetObject("tcMain.Visible"), Boolean)
        '
        'tpRecordNavigation
        '
        Me.tpRecordNavigation.AccessibleDescription = CType(resources.GetObject("tpRecordNavigation.AccessibleDescription"), String)
        Me.tpRecordNavigation.AccessibleName = CType(resources.GetObject("tpRecordNavigation.AccessibleName"), String)
        Me.tpRecordNavigation.Anchor = CType(resources.GetObject("tpRecordNavigation.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpRecordNavigation.AutoScroll = CType(resources.GetObject("tpRecordNavigation.AutoScroll"), Boolean)
        Me.tpRecordNavigation.AutoScrollMargin = CType(resources.GetObject("tpRecordNavigation.AutoScrollMargin"), System.Drawing.Size)
        Me.tpRecordNavigation.AutoScrollMinSize = CType(resources.GetObject("tpRecordNavigation.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpRecordNavigation.BackgroundImage = CType(resources.GetObject("tpRecordNavigation.BackgroundImage"), System.Drawing.Image)
        Me.tpRecordNavigation.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.btnLast, Me.btnNext, Me.btnPrev, Me.btnFirst, Me.txtPhone, Me.txtContactName, Me.txtCompanyName})
        Me.tpRecordNavigation.Dock = CType(resources.GetObject("tpRecordNavigation.Dock"), System.Windows.Forms.DockStyle)
        Me.tpRecordNavigation.Enabled = CType(resources.GetObject("tpRecordNavigation.Enabled"), Boolean)
        Me.tpRecordNavigation.Font = CType(resources.GetObject("tpRecordNavigation.Font"), System.Drawing.Font)
        Me.tpRecordNavigation.ImageIndex = CType(resources.GetObject("tpRecordNavigation.ImageIndex"), Integer)
        Me.tpRecordNavigation.ImeMode = CType(resources.GetObject("tpRecordNavigation.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpRecordNavigation.Location = CType(resources.GetObject("tpRecordNavigation.Location"), System.Drawing.Point)
        Me.tpRecordNavigation.Name = "tpRecordNavigation"
        Me.tpRecordNavigation.RightToLeft = CType(resources.GetObject("tpRecordNavigation.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpRecordNavigation.Size = CType(resources.GetObject("tpRecordNavigation.Size"), System.Drawing.Size)
        Me.tpRecordNavigation.TabIndex = CType(resources.GetObject("tpRecordNavigation.TabIndex"), Integer)
        Me.tpRecordNavigation.Text = resources.GetString("tpRecordNavigation.Text")
        Me.tpRecordNavigation.ToolTipText = resources.GetString("tpRecordNavigation.ToolTipText")
        Me.tpRecordNavigation.Visible = CType(resources.GetObject("tpRecordNavigation.Visible"), Boolean)
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = CType(resources.GetObject("Label7.AccessibleDescription"), String)
        Me.Label7.AccessibleName = CType(resources.GetObject("Label7.AccessibleName"), String)
        Me.Label7.Anchor = CType(resources.GetObject("Label7.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = CType(resources.GetObject("Label7.AutoSize"), Boolean)
        Me.Label7.Dock = CType(resources.GetObject("Label7.Dock"), System.Windows.Forms.DockStyle)
        Me.Label7.Enabled = CType(resources.GetObject("Label7.Enabled"), Boolean)
        Me.Label7.Font = CType(resources.GetObject("Label7.Font"), System.Drawing.Font)
        Me.Label7.ForeColor = System.Drawing.Color.Blue
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
        Me.Label6.AccessibleDescription = CType(resources.GetObject("Label6.AccessibleDescription"), String)
        Me.Label6.AccessibleName = CType(resources.GetObject("Label6.AccessibleName"), String)
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
        'Label5
        '
        Me.Label5.AccessibleDescription = CType(resources.GetObject("Label5.AccessibleDescription"), String)
        Me.Label5.AccessibleName = CType(resources.GetObject("Label5.AccessibleName"), String)
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
        'Label4
        '
        Me.Label4.AccessibleDescription = CType(resources.GetObject("Label4.AccessibleDescription"), String)
        Me.Label4.AccessibleName = CType(resources.GetObject("Label4.AccessibleName"), String)
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
        'btnLast
        '
        Me.btnLast.AccessibleDescription = CType(resources.GetObject("btnLast.AccessibleDescription"), String)
        Me.btnLast.AccessibleName = CType(resources.GetObject("btnLast.AccessibleName"), String)
        Me.btnLast.Anchor = CType(resources.GetObject("btnLast.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnLast.BackgroundImage = CType(resources.GetObject("btnLast.BackgroundImage"), System.Drawing.Image)
        Me.btnLast.Dock = CType(resources.GetObject("btnLast.Dock"), System.Windows.Forms.DockStyle)
        Me.btnLast.Enabled = CType(resources.GetObject("btnLast.Enabled"), Boolean)
        Me.btnLast.FlatStyle = CType(resources.GetObject("btnLast.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnLast.Font = CType(resources.GetObject("btnLast.Font"), System.Drawing.Font)
        Me.btnLast.Image = CType(resources.GetObject("btnLast.Image"), System.Drawing.Image)
        Me.btnLast.ImageAlign = CType(resources.GetObject("btnLast.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnLast.ImageIndex = CType(resources.GetObject("btnLast.ImageIndex"), Integer)
        Me.btnLast.ImeMode = CType(resources.GetObject("btnLast.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnLast.Location = CType(resources.GetObject("btnLast.Location"), System.Drawing.Point)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.RightToLeft = CType(resources.GetObject("btnLast.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnLast.Size = CType(resources.GetObject("btnLast.Size"), System.Drawing.Size)
        Me.btnLast.TabIndex = CType(resources.GetObject("btnLast.TabIndex"), Integer)
        Me.btnLast.Text = resources.GetString("btnLast.Text")
        Me.btnLast.TextAlign = CType(resources.GetObject("btnLast.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnLast.Visible = CType(resources.GetObject("btnLast.Visible"), Boolean)
        '
        'btnNext
        '
        Me.btnNext.AccessibleDescription = CType(resources.GetObject("btnNext.AccessibleDescription"), String)
        Me.btnNext.AccessibleName = CType(resources.GetObject("btnNext.AccessibleName"), String)
        Me.btnNext.Anchor = CType(resources.GetObject("btnNext.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnNext.BackgroundImage = CType(resources.GetObject("btnNext.BackgroundImage"), System.Drawing.Image)
        Me.btnNext.Dock = CType(resources.GetObject("btnNext.Dock"), System.Windows.Forms.DockStyle)
        Me.btnNext.Enabled = CType(resources.GetObject("btnNext.Enabled"), Boolean)
        Me.btnNext.FlatStyle = CType(resources.GetObject("btnNext.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnNext.Font = CType(resources.GetObject("btnNext.Font"), System.Drawing.Font)
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.ImageAlign = CType(resources.GetObject("btnNext.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnNext.ImageIndex = CType(resources.GetObject("btnNext.ImageIndex"), Integer)
        Me.btnNext.ImeMode = CType(resources.GetObject("btnNext.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnNext.Location = CType(resources.GetObject("btnNext.Location"), System.Drawing.Point)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.RightToLeft = CType(resources.GetObject("btnNext.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnNext.Size = CType(resources.GetObject("btnNext.Size"), System.Drawing.Size)
        Me.btnNext.TabIndex = CType(resources.GetObject("btnNext.TabIndex"), Integer)
        Me.btnNext.Text = resources.GetString("btnNext.Text")
        Me.btnNext.TextAlign = CType(resources.GetObject("btnNext.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnNext.Visible = CType(resources.GetObject("btnNext.Visible"), Boolean)
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleDescription = CType(resources.GetObject("btnPrev.AccessibleDescription"), String)
        Me.btnPrev.AccessibleName = CType(resources.GetObject("btnPrev.AccessibleName"), String)
        Me.btnPrev.Anchor = CType(resources.GetObject("btnPrev.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPrev.BackgroundImage = CType(resources.GetObject("btnPrev.BackgroundImage"), System.Drawing.Image)
        Me.btnPrev.Dock = CType(resources.GetObject("btnPrev.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPrev.Enabled = CType(resources.GetObject("btnPrev.Enabled"), Boolean)
        Me.btnPrev.FlatStyle = CType(resources.GetObject("btnPrev.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPrev.Font = CType(resources.GetObject("btnPrev.Font"), System.Drawing.Font)
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.ImageAlign = CType(resources.GetObject("btnPrev.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPrev.ImageIndex = CType(resources.GetObject("btnPrev.ImageIndex"), Integer)
        Me.btnPrev.ImeMode = CType(resources.GetObject("btnPrev.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPrev.Location = CType(resources.GetObject("btnPrev.Location"), System.Drawing.Point)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.RightToLeft = CType(resources.GetObject("btnPrev.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPrev.Size = CType(resources.GetObject("btnPrev.Size"), System.Drawing.Size)
        Me.btnPrev.TabIndex = CType(resources.GetObject("btnPrev.TabIndex"), Integer)
        Me.btnPrev.Text = resources.GetString("btnPrev.Text")
        Me.btnPrev.TextAlign = CType(resources.GetObject("btnPrev.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPrev.Visible = CType(resources.GetObject("btnPrev.Visible"), Boolean)
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleDescription = CType(resources.GetObject("btnFirst.AccessibleDescription"), String)
        Me.btnFirst.AccessibleName = CType(resources.GetObject("btnFirst.AccessibleName"), String)
        Me.btnFirst.Anchor = CType(resources.GetObject("btnFirst.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnFirst.BackgroundImage = CType(resources.GetObject("btnFirst.BackgroundImage"), System.Drawing.Image)
        Me.btnFirst.Dock = CType(resources.GetObject("btnFirst.Dock"), System.Windows.Forms.DockStyle)
        Me.btnFirst.Enabled = CType(resources.GetObject("btnFirst.Enabled"), Boolean)
        Me.btnFirst.FlatStyle = CType(resources.GetObject("btnFirst.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnFirst.Font = CType(resources.GetObject("btnFirst.Font"), System.Drawing.Font)
        Me.btnFirst.Image = CType(resources.GetObject("btnFirst.Image"), System.Drawing.Image)
        Me.btnFirst.ImageAlign = CType(resources.GetObject("btnFirst.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnFirst.ImageIndex = CType(resources.GetObject("btnFirst.ImageIndex"), Integer)
        Me.btnFirst.ImeMode = CType(resources.GetObject("btnFirst.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnFirst.Location = CType(resources.GetObject("btnFirst.Location"), System.Drawing.Point)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.RightToLeft = CType(resources.GetObject("btnFirst.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnFirst.Size = CType(resources.GetObject("btnFirst.Size"), System.Drawing.Size)
        Me.btnFirst.TabIndex = CType(resources.GetObject("btnFirst.TabIndex"), Integer)
        Me.btnFirst.Text = resources.GetString("btnFirst.Text")
        Me.btnFirst.TextAlign = CType(resources.GetObject("btnFirst.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnFirst.Visible = CType(resources.GetObject("btnFirst.Visible"), Boolean)
        '
        'txtPhone
        '
        Me.txtPhone.AccessibleDescription = CType(resources.GetObject("txtPhone.AccessibleDescription"), String)
        Me.txtPhone.AccessibleName = CType(resources.GetObject("txtPhone.AccessibleName"), String)
        Me.txtPhone.Anchor = CType(resources.GetObject("txtPhone.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtPhone.AutoSize = CType(resources.GetObject("txtPhone.AutoSize"), Boolean)
        Me.txtPhone.BackgroundImage = CType(resources.GetObject("txtPhone.BackgroundImage"), System.Drawing.Image)
        Me.txtPhone.Dock = CType(resources.GetObject("txtPhone.Dock"), System.Windows.Forms.DockStyle)
        Me.txtPhone.Enabled = CType(resources.GetObject("txtPhone.Enabled"), Boolean)
        Me.txtPhone.Font = CType(resources.GetObject("txtPhone.Font"), System.Drawing.Font)
        Me.txtPhone.ImeMode = CType(resources.GetObject("txtPhone.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtPhone.Location = CType(resources.GetObject("txtPhone.Location"), System.Drawing.Point)
        Me.txtPhone.MaxLength = CType(resources.GetObject("txtPhone.MaxLength"), Integer)
        Me.txtPhone.Multiline = CType(resources.GetObject("txtPhone.Multiline"), Boolean)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.PasswordChar = CType(resources.GetObject("txtPhone.PasswordChar"), Char)
        Me.txtPhone.RightToLeft = CType(resources.GetObject("txtPhone.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtPhone.ScrollBars = CType(resources.GetObject("txtPhone.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtPhone.Size = CType(resources.GetObject("txtPhone.Size"), System.Drawing.Size)
        Me.txtPhone.TabIndex = CType(resources.GetObject("txtPhone.TabIndex"), Integer)
        Me.txtPhone.Text = resources.GetString("txtPhone.Text")
        Me.txtPhone.TextAlign = CType(resources.GetObject("txtPhone.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtPhone.Visible = CType(resources.GetObject("txtPhone.Visible"), Boolean)
        Me.txtPhone.WordWrap = CType(resources.GetObject("txtPhone.WordWrap"), Boolean)
        '
        'txtContactName
        '
        Me.txtContactName.AccessibleDescription = CType(resources.GetObject("txtContactName.AccessibleDescription"), String)
        Me.txtContactName.AccessibleName = CType(resources.GetObject("txtContactName.AccessibleName"), String)
        Me.txtContactName.Anchor = CType(resources.GetObject("txtContactName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtContactName.AutoSize = CType(resources.GetObject("txtContactName.AutoSize"), Boolean)
        Me.txtContactName.BackgroundImage = CType(resources.GetObject("txtContactName.BackgroundImage"), System.Drawing.Image)
        Me.txtContactName.Dock = CType(resources.GetObject("txtContactName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtContactName.Enabled = CType(resources.GetObject("txtContactName.Enabled"), Boolean)
        Me.txtContactName.Font = CType(resources.GetObject("txtContactName.Font"), System.Drawing.Font)
        Me.txtContactName.ImeMode = CType(resources.GetObject("txtContactName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtContactName.Location = CType(resources.GetObject("txtContactName.Location"), System.Drawing.Point)
        Me.txtContactName.MaxLength = CType(resources.GetObject("txtContactName.MaxLength"), Integer)
        Me.txtContactName.Multiline = CType(resources.GetObject("txtContactName.Multiline"), Boolean)
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.PasswordChar = CType(resources.GetObject("txtContactName.PasswordChar"), Char)
        Me.txtContactName.RightToLeft = CType(resources.GetObject("txtContactName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtContactName.ScrollBars = CType(resources.GetObject("txtContactName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtContactName.Size = CType(resources.GetObject("txtContactName.Size"), System.Drawing.Size)
        Me.txtContactName.TabIndex = CType(resources.GetObject("txtContactName.TabIndex"), Integer)
        Me.txtContactName.Text = resources.GetString("txtContactName.Text")
        Me.txtContactName.TextAlign = CType(resources.GetObject("txtContactName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtContactName.Visible = CType(resources.GetObject("txtContactName.Visible"), Boolean)
        Me.txtContactName.WordWrap = CType(resources.GetObject("txtContactName.WordWrap"), Boolean)
        '
        'txtCompanyName
        '
        Me.txtCompanyName.AccessibleDescription = CType(resources.GetObject("txtCompanyName.AccessibleDescription"), String)
        Me.txtCompanyName.AccessibleName = CType(resources.GetObject("txtCompanyName.AccessibleName"), String)
        Me.txtCompanyName.Anchor = CType(resources.GetObject("txtCompanyName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCompanyName.AutoSize = CType(resources.GetObject("txtCompanyName.AutoSize"), Boolean)
        Me.txtCompanyName.BackgroundImage = CType(resources.GetObject("txtCompanyName.BackgroundImage"), System.Drawing.Image)
        Me.txtCompanyName.Dock = CType(resources.GetObject("txtCompanyName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCompanyName.Enabled = CType(resources.GetObject("txtCompanyName.Enabled"), Boolean)
        Me.txtCompanyName.Font = CType(resources.GetObject("txtCompanyName.Font"), System.Drawing.Font)
        Me.txtCompanyName.ImeMode = CType(resources.GetObject("txtCompanyName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCompanyName.Location = CType(resources.GetObject("txtCompanyName.Location"), System.Drawing.Point)
        Me.txtCompanyName.MaxLength = CType(resources.GetObject("txtCompanyName.MaxLength"), Integer)
        Me.txtCompanyName.Multiline = CType(resources.GetObject("txtCompanyName.Multiline"), Boolean)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.PasswordChar = CType(resources.GetObject("txtCompanyName.PasswordChar"), Char)
        Me.txtCompanyName.RightToLeft = CType(resources.GetObject("txtCompanyName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCompanyName.ScrollBars = CType(resources.GetObject("txtCompanyName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCompanyName.Size = CType(resources.GetObject("txtCompanyName.Size"), System.Drawing.Size)
        Me.txtCompanyName.TabIndex = CType(resources.GetObject("txtCompanyName.TabIndex"), Integer)
        Me.txtCompanyName.Text = resources.GetString("txtCompanyName.Text")
        Me.txtCompanyName.TextAlign = CType(resources.GetObject("txtCompanyName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCompanyName.Visible = CType(resources.GetObject("txtCompanyName.Visible"), Boolean)
        Me.txtCompanyName.WordWrap = CType(resources.GetObject("txtCompanyName.WordWrap"), Boolean)
        '
        'tpInsert
        '
        Me.tpInsert.AccessibleDescription = CType(resources.GetObject("tpInsert.AccessibleDescription"), String)
        Me.tpInsert.AccessibleName = CType(resources.GetObject("tpInsert.AccessibleName"), String)
        Me.tpInsert.Anchor = CType(resources.GetObject("tpInsert.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpInsert.AutoScroll = CType(resources.GetObject("tpInsert.AutoScroll"), Boolean)
        Me.tpInsert.AutoScrollMargin = CType(resources.GetObject("tpInsert.AutoScrollMargin"), System.Drawing.Size)
        Me.tpInsert.AutoScrollMinSize = CType(resources.GetObject("tpInsert.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpInsert.BackgroundImage = CType(resources.GetObject("tpInsert.BackgroundImage"), System.Drawing.Image)
        Me.tpInsert.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.Label1, Me.lblCategoryName, Me.btnInsert, Me.txtDescription, Me.txtCategoryName})
        Me.tpInsert.Dock = CType(resources.GetObject("tpInsert.Dock"), System.Windows.Forms.DockStyle)
        Me.tpInsert.Enabled = CType(resources.GetObject("tpInsert.Enabled"), Boolean)
        Me.tpInsert.Font = CType(resources.GetObject("tpInsert.Font"), System.Drawing.Font)
        Me.tpInsert.ImageIndex = CType(resources.GetObject("tpInsert.ImageIndex"), Integer)
        Me.tpInsert.ImeMode = CType(resources.GetObject("tpInsert.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpInsert.Location = CType(resources.GetObject("tpInsert.Location"), System.Drawing.Point)
        Me.tpInsert.Name = "tpInsert"
        Me.tpInsert.RightToLeft = CType(resources.GetObject("tpInsert.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpInsert.Size = CType(resources.GetObject("tpInsert.Size"), System.Drawing.Size)
        Me.tpInsert.TabIndex = CType(resources.GetObject("tpInsert.TabIndex"), Integer)
        Me.tpInsert.Text = resources.GetString("tpInsert.Text")
        Me.tpInsert.ToolTipText = resources.GetString("tpInsert.ToolTipText")
        Me.tpInsert.Visible = CType(resources.GetObject("tpInsert.Visible"), Boolean)
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = CType(resources.GetObject("Label8.AccessibleDescription"), String)
        Me.Label8.AccessibleName = CType(resources.GetObject("Label8.AccessibleName"), String)
        Me.Label8.Anchor = CType(resources.GetObject("Label8.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = CType(resources.GetObject("Label8.AutoSize"), Boolean)
        Me.Label8.Dock = CType(resources.GetObject("Label8.Dock"), System.Windows.Forms.DockStyle)
        Me.Label8.Enabled = CType(resources.GetObject("Label8.Enabled"), Boolean)
        Me.Label8.Font = CType(resources.GetObject("Label8.Font"), System.Drawing.Font)
        Me.Label8.ForeColor = System.Drawing.Color.Blue
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
        'lblCategoryName
        '
        Me.lblCategoryName.AccessibleDescription = CType(resources.GetObject("lblCategoryName.AccessibleDescription"), String)
        Me.lblCategoryName.AccessibleName = CType(resources.GetObject("lblCategoryName.AccessibleName"), String)
        Me.lblCategoryName.Anchor = CType(resources.GetObject("lblCategoryName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblCategoryName.AutoSize = CType(resources.GetObject("lblCategoryName.AutoSize"), Boolean)
        Me.lblCategoryName.Dock = CType(resources.GetObject("lblCategoryName.Dock"), System.Windows.Forms.DockStyle)
        Me.lblCategoryName.Enabled = CType(resources.GetObject("lblCategoryName.Enabled"), Boolean)
        Me.lblCategoryName.Font = CType(resources.GetObject("lblCategoryName.Font"), System.Drawing.Font)
        Me.lblCategoryName.Image = CType(resources.GetObject("lblCategoryName.Image"), System.Drawing.Image)
        Me.lblCategoryName.ImageAlign = CType(resources.GetObject("lblCategoryName.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblCategoryName.ImageIndex = CType(resources.GetObject("lblCategoryName.ImageIndex"), Integer)
        Me.lblCategoryName.ImeMode = CType(resources.GetObject("lblCategoryName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblCategoryName.Location = CType(resources.GetObject("lblCategoryName.Location"), System.Drawing.Point)
        Me.lblCategoryName.Name = "lblCategoryName"
        Me.lblCategoryName.RightToLeft = CType(resources.GetObject("lblCategoryName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblCategoryName.Size = CType(resources.GetObject("lblCategoryName.Size"), System.Drawing.Size)
        Me.lblCategoryName.TabIndex = CType(resources.GetObject("lblCategoryName.TabIndex"), Integer)
        Me.lblCategoryName.Text = resources.GetString("lblCategoryName.Text")
        Me.lblCategoryName.TextAlign = CType(resources.GetObject("lblCategoryName.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblCategoryName.Visible = CType(resources.GetObject("lblCategoryName.Visible"), Boolean)
        '
        'btnInsert
        '
        Me.btnInsert.AccessibleDescription = CType(resources.GetObject("btnInsert.AccessibleDescription"), String)
        Me.btnInsert.AccessibleName = CType(resources.GetObject("btnInsert.AccessibleName"), String)
        Me.btnInsert.Anchor = CType(resources.GetObject("btnInsert.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnInsert.BackgroundImage = CType(resources.GetObject("btnInsert.BackgroundImage"), System.Drawing.Image)
        Me.btnInsert.Dock = CType(resources.GetObject("btnInsert.Dock"), System.Windows.Forms.DockStyle)
        Me.btnInsert.Enabled = CType(resources.GetObject("btnInsert.Enabled"), Boolean)
        Me.btnInsert.FlatStyle = CType(resources.GetObject("btnInsert.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnInsert.Font = CType(resources.GetObject("btnInsert.Font"), System.Drawing.Font)
        Me.btnInsert.Image = CType(resources.GetObject("btnInsert.Image"), System.Drawing.Image)
        Me.btnInsert.ImageAlign = CType(resources.GetObject("btnInsert.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnInsert.ImageIndex = CType(resources.GetObject("btnInsert.ImageIndex"), Integer)
        Me.btnInsert.ImeMode = CType(resources.GetObject("btnInsert.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnInsert.Location = CType(resources.GetObject("btnInsert.Location"), System.Drawing.Point)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.RightToLeft = CType(resources.GetObject("btnInsert.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnInsert.Size = CType(resources.GetObject("btnInsert.Size"), System.Drawing.Size)
        Me.btnInsert.TabIndex = CType(resources.GetObject("btnInsert.TabIndex"), Integer)
        Me.btnInsert.Text = resources.GetString("btnInsert.Text")
        Me.btnInsert.TextAlign = CType(resources.GetObject("btnInsert.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnInsert.Visible = CType(resources.GetObject("btnInsert.Visible"), Boolean)
        '
        'txtDescription
        '
        Me.txtDescription.AccessibleDescription = CType(resources.GetObject("txtDescription.AccessibleDescription"), String)
        Me.txtDescription.AccessibleName = CType(resources.GetObject("txtDescription.AccessibleName"), String)
        Me.txtDescription.Anchor = CType(resources.GetObject("txtDescription.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.AutoSize = CType(resources.GetObject("txtDescription.AutoSize"), Boolean)
        Me.txtDescription.BackgroundImage = CType(resources.GetObject("txtDescription.BackgroundImage"), System.Drawing.Image)
        Me.txtDescription.Dock = CType(resources.GetObject("txtDescription.Dock"), System.Windows.Forms.DockStyle)
        Me.txtDescription.Enabled = CType(resources.GetObject("txtDescription.Enabled"), Boolean)
        Me.txtDescription.Font = CType(resources.GetObject("txtDescription.Font"), System.Drawing.Font)
        Me.txtDescription.ImeMode = CType(resources.GetObject("txtDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtDescription.Location = CType(resources.GetObject("txtDescription.Location"), System.Drawing.Point)
        Me.txtDescription.MaxLength = CType(resources.GetObject("txtDescription.MaxLength"), Integer)
        Me.txtDescription.Multiline = CType(resources.GetObject("txtDescription.Multiline"), Boolean)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.PasswordChar = CType(resources.GetObject("txtDescription.PasswordChar"), Char)
        Me.txtDescription.RightToLeft = CType(resources.GetObject("txtDescription.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtDescription.ScrollBars = CType(resources.GetObject("txtDescription.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtDescription.Size = CType(resources.GetObject("txtDescription.Size"), System.Drawing.Size)
        Me.txtDescription.TabIndex = CType(resources.GetObject("txtDescription.TabIndex"), Integer)
        Me.txtDescription.Text = resources.GetString("txtDescription.Text")
        Me.txtDescription.TextAlign = CType(resources.GetObject("txtDescription.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtDescription.Visible = CType(resources.GetObject("txtDescription.Visible"), Boolean)
        Me.txtDescription.WordWrap = CType(resources.GetObject("txtDescription.WordWrap"), Boolean)
        '
        'txtCategoryName
        '
        Me.txtCategoryName.AccessibleDescription = CType(resources.GetObject("txtCategoryName.AccessibleDescription"), String)
        Me.txtCategoryName.AccessibleName = CType(resources.GetObject("txtCategoryName.AccessibleName"), String)
        Me.txtCategoryName.Anchor = CType(resources.GetObject("txtCategoryName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCategoryName.AutoSize = CType(resources.GetObject("txtCategoryName.AutoSize"), Boolean)
        Me.txtCategoryName.BackgroundImage = CType(resources.GetObject("txtCategoryName.BackgroundImage"), System.Drawing.Image)
        Me.txtCategoryName.Dock = CType(resources.GetObject("txtCategoryName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCategoryName.Enabled = CType(resources.GetObject("txtCategoryName.Enabled"), Boolean)
        Me.txtCategoryName.Font = CType(resources.GetObject("txtCategoryName.Font"), System.Drawing.Font)
        Me.txtCategoryName.ImeMode = CType(resources.GetObject("txtCategoryName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCategoryName.Location = CType(resources.GetObject("txtCategoryName.Location"), System.Drawing.Point)
        Me.txtCategoryName.MaxLength = CType(resources.GetObject("txtCategoryName.MaxLength"), Integer)
        Me.txtCategoryName.Multiline = CType(resources.GetObject("txtCategoryName.Multiline"), Boolean)
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.PasswordChar = CType(resources.GetObject("txtCategoryName.PasswordChar"), Char)
        Me.txtCategoryName.RightToLeft = CType(resources.GetObject("txtCategoryName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCategoryName.ScrollBars = CType(resources.GetObject("txtCategoryName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCategoryName.Size = CType(resources.GetObject("txtCategoryName.Size"), System.Drawing.Size)
        Me.txtCategoryName.TabIndex = CType(resources.GetObject("txtCategoryName.TabIndex"), Integer)
        Me.txtCategoryName.Text = resources.GetString("txtCategoryName.Text")
        Me.txtCategoryName.TextAlign = CType(resources.GetObject("txtCategoryName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCategoryName.Visible = CType(resources.GetObject("txtCategoryName.Visible"), Boolean)
        Me.txtCategoryName.WordWrap = CType(resources.GetObject("txtCategoryName.WordWrap"), Boolean)
        '
        'tpUpdate
        '
        Me.tpUpdate.AccessibleDescription = CType(resources.GetObject("tpUpdate.AccessibleDescription"), String)
        Me.tpUpdate.AccessibleName = CType(resources.GetObject("tpUpdate.AccessibleName"), String)
        Me.tpUpdate.Anchor = CType(resources.GetObject("tpUpdate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpUpdate.AutoScroll = CType(resources.GetObject("tpUpdate.AutoScroll"), Boolean)
        Me.tpUpdate.AutoScrollMargin = CType(resources.GetObject("tpUpdate.AutoScrollMargin"), System.Drawing.Size)
        Me.tpUpdate.AutoScrollMinSize = CType(resources.GetObject("tpUpdate.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpUpdate.BackgroundImage = CType(resources.GetObject("tpUpdate.BackgroundImage"), System.Drawing.Image)
        Me.tpUpdate.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.Label2, Me.Label3, Me.txtUpdateDescription, Me.cbCategoryName, Me.btnUpdate})
        Me.tpUpdate.Dock = CType(resources.GetObject("tpUpdate.Dock"), System.Windows.Forms.DockStyle)
        Me.tpUpdate.Enabled = CType(resources.GetObject("tpUpdate.Enabled"), Boolean)
        Me.tpUpdate.Font = CType(resources.GetObject("tpUpdate.Font"), System.Drawing.Font)
        Me.tpUpdate.ImageIndex = CType(resources.GetObject("tpUpdate.ImageIndex"), Integer)
        Me.tpUpdate.ImeMode = CType(resources.GetObject("tpUpdate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpUpdate.Location = CType(resources.GetObject("tpUpdate.Location"), System.Drawing.Point)
        Me.tpUpdate.Name = "tpUpdate"
        Me.tpUpdate.RightToLeft = CType(resources.GetObject("tpUpdate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpUpdate.Size = CType(resources.GetObject("tpUpdate.Size"), System.Drawing.Size)
        Me.tpUpdate.TabIndex = CType(resources.GetObject("tpUpdate.TabIndex"), Integer)
        Me.tpUpdate.Text = resources.GetString("tpUpdate.Text")
        Me.tpUpdate.ToolTipText = resources.GetString("tpUpdate.ToolTipText")
        Me.tpUpdate.Visible = CType(resources.GetObject("tpUpdate.Visible"), Boolean)
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = CType(resources.GetObject("Label9.AccessibleDescription"), String)
        Me.Label9.AccessibleName = CType(resources.GetObject("Label9.AccessibleName"), String)
        Me.Label9.Anchor = CType(resources.GetObject("Label9.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = CType(resources.GetObject("Label9.AutoSize"), Boolean)
        Me.Label9.Dock = CType(resources.GetObject("Label9.Dock"), System.Windows.Forms.DockStyle)
        Me.Label9.Enabled = CType(resources.GetObject("Label9.Enabled"), Boolean)
        Me.Label9.Font = CType(resources.GetObject("Label9.Font"), System.Drawing.Font)
        Me.Label9.ForeColor = System.Drawing.Color.Blue
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
        'Label3
        '
        Me.Label3.AccessibleDescription = CType(resources.GetObject("Label3.AccessibleDescription"), String)
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
        'txtUpdateDescription
        '
        Me.txtUpdateDescription.AccessibleDescription = CType(resources.GetObject("txtUpdateDescription.AccessibleDescription"), String)
        Me.txtUpdateDescription.AccessibleName = CType(resources.GetObject("txtUpdateDescription.AccessibleName"), String)
        Me.txtUpdateDescription.Anchor = CType(resources.GetObject("txtUpdateDescription.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtUpdateDescription.AutoSize = CType(resources.GetObject("txtUpdateDescription.AutoSize"), Boolean)
        Me.txtUpdateDescription.BackgroundImage = CType(resources.GetObject("txtUpdateDescription.BackgroundImage"), System.Drawing.Image)
        Me.txtUpdateDescription.Dock = CType(resources.GetObject("txtUpdateDescription.Dock"), System.Windows.Forms.DockStyle)
        Me.txtUpdateDescription.Enabled = CType(resources.GetObject("txtUpdateDescription.Enabled"), Boolean)
        Me.txtUpdateDescription.Font = CType(resources.GetObject("txtUpdateDescription.Font"), System.Drawing.Font)
        Me.txtUpdateDescription.ImeMode = CType(resources.GetObject("txtUpdateDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtUpdateDescription.Location = CType(resources.GetObject("txtUpdateDescription.Location"), System.Drawing.Point)
        Me.txtUpdateDescription.MaxLength = CType(resources.GetObject("txtUpdateDescription.MaxLength"), Integer)
        Me.txtUpdateDescription.Multiline = CType(resources.GetObject("txtUpdateDescription.Multiline"), Boolean)
        Me.txtUpdateDescription.Name = "txtUpdateDescription"
        Me.txtUpdateDescription.PasswordChar = CType(resources.GetObject("txtUpdateDescription.PasswordChar"), Char)
        Me.txtUpdateDescription.RightToLeft = CType(resources.GetObject("txtUpdateDescription.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtUpdateDescription.ScrollBars = CType(resources.GetObject("txtUpdateDescription.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtUpdateDescription.Size = CType(resources.GetObject("txtUpdateDescription.Size"), System.Drawing.Size)
        Me.txtUpdateDescription.TabIndex = CType(resources.GetObject("txtUpdateDescription.TabIndex"), Integer)
        Me.txtUpdateDescription.Text = resources.GetString("txtUpdateDescription.Text")
        Me.txtUpdateDescription.TextAlign = CType(resources.GetObject("txtUpdateDescription.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtUpdateDescription.Visible = CType(resources.GetObject("txtUpdateDescription.Visible"), Boolean)
        Me.txtUpdateDescription.WordWrap = CType(resources.GetObject("txtUpdateDescription.WordWrap"), Boolean)
        '
        'cbCategoryName
        '
        Me.cbCategoryName.AccessibleDescription = resources.GetString("cbCategoryName.AccessibleDescription")
        Me.cbCategoryName.AccessibleName = resources.GetString("cbCategoryName.AccessibleName")
        Me.cbCategoryName.Anchor = CType(resources.GetObject("cbCategoryName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cbCategoryName.BackgroundImage = CType(resources.GetObject("cbCategoryName.BackgroundImage"), System.Drawing.Image)
        Me.cbCategoryName.Dock = CType(resources.GetObject("cbCategoryName.Dock"), System.Windows.Forms.DockStyle)
        Me.cbCategoryName.Enabled = CType(resources.GetObject("cbCategoryName.Enabled"), Boolean)
        Me.cbCategoryName.Font = CType(resources.GetObject("cbCategoryName.Font"), System.Drawing.Font)
        Me.cbCategoryName.ImeMode = CType(resources.GetObject("cbCategoryName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cbCategoryName.IntegralHeight = CType(resources.GetObject("cbCategoryName.IntegralHeight"), Boolean)
        Me.cbCategoryName.ItemHeight = CType(resources.GetObject("cbCategoryName.ItemHeight"), Integer)
        Me.cbCategoryName.Location = CType(resources.GetObject("cbCategoryName.Location"), System.Drawing.Point)
        Me.cbCategoryName.MaxDropDownItems = CType(resources.GetObject("cbCategoryName.MaxDropDownItems"), Integer)
        Me.cbCategoryName.MaxLength = CType(resources.GetObject("cbCategoryName.MaxLength"), Integer)
        Me.cbCategoryName.Name = "cbCategoryName"
        Me.cbCategoryName.RightToLeft = CType(resources.GetObject("cbCategoryName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cbCategoryName.Size = CType(resources.GetObject("cbCategoryName.Size"), System.Drawing.Size)
        Me.cbCategoryName.TabIndex = CType(resources.GetObject("cbCategoryName.TabIndex"), Integer)
        Me.cbCategoryName.Text = resources.GetString("cbCategoryName.Text")
        Me.cbCategoryName.Visible = CType(resources.GetObject("cbCategoryName.Visible"), Boolean)
        '
        'btnUpdate
        '
        Me.btnUpdate.AccessibleDescription = resources.GetString("btnUpdate.AccessibleDescription")
        Me.btnUpdate.AccessibleName = resources.GetString("btnUpdate.AccessibleName")
        Me.btnUpdate.Anchor = CType(resources.GetObject("btnUpdate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdate.Dock = CType(resources.GetObject("btnUpdate.Dock"), System.Windows.Forms.DockStyle)
        Me.btnUpdate.Enabled = CType(resources.GetObject("btnUpdate.Enabled"), Boolean)
        Me.btnUpdate.FlatStyle = CType(resources.GetObject("btnUpdate.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnUpdate.Font = CType(resources.GetObject("btnUpdate.Font"), System.Drawing.Font)
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = CType(resources.GetObject("btnUpdate.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnUpdate.ImageIndex = CType(resources.GetObject("btnUpdate.ImageIndex"), Integer)
        Me.btnUpdate.ImeMode = CType(resources.GetObject("btnUpdate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnUpdate.Location = CType(resources.GetObject("btnUpdate.Location"), System.Drawing.Point)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.RightToLeft = CType(resources.GetObject("btnUpdate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnUpdate.Size = CType(resources.GetObject("btnUpdate.Size"), System.Drawing.Size)
        Me.btnUpdate.TabIndex = CType(resources.GetObject("btnUpdate.TabIndex"), Integer)
        Me.btnUpdate.Text = resources.GetString("btnUpdate.Text")
        Me.btnUpdate.TextAlign = CType(resources.GetObject("btnUpdate.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnUpdate.Visible = CType(resources.GetObject("btnUpdate.Visible"), Boolean)
        '
        'tpDatasetExample
        '
        Me.tpDatasetExample.AccessibleDescription = CType(resources.GetObject("tpDatasetExample.AccessibleDescription"), String)
        Me.tpDatasetExample.AccessibleName = CType(resources.GetObject("tpDatasetExample.AccessibleName"), String)
        Me.tpDatasetExample.Anchor = CType(resources.GetObject("tpDatasetExample.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpDatasetExample.AutoScroll = CType(resources.GetObject("tpDatasetExample.AutoScroll"), Boolean)
        Me.tpDatasetExample.AutoScrollMargin = CType(resources.GetObject("tpDatasetExample.AutoScrollMargin"), System.Drawing.Size)
        Me.tpDatasetExample.AutoScrollMinSize = CType(resources.GetObject("tpDatasetExample.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpDatasetExample.BackgroundImage = CType(resources.GetObject("tpDatasetExample.BackgroundImage"), System.Drawing.Image)
        Me.tpDatasetExample.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label10, Me.btnDataset, Me.dgMain})
        Me.tpDatasetExample.Dock = CType(resources.GetObject("tpDatasetExample.Dock"), System.Windows.Forms.DockStyle)
        Me.tpDatasetExample.Enabled = CType(resources.GetObject("tpDatasetExample.Enabled"), Boolean)
        Me.tpDatasetExample.Font = CType(resources.GetObject("tpDatasetExample.Font"), System.Drawing.Font)
        Me.tpDatasetExample.ImageIndex = CType(resources.GetObject("tpDatasetExample.ImageIndex"), Integer)
        Me.tpDatasetExample.ImeMode = CType(resources.GetObject("tpDatasetExample.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpDatasetExample.Location = CType(resources.GetObject("tpDatasetExample.Location"), System.Drawing.Point)
        Me.tpDatasetExample.Name = "tpDatasetExample"
        Me.tpDatasetExample.RightToLeft = CType(resources.GetObject("tpDatasetExample.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpDatasetExample.Size = CType(resources.GetObject("tpDatasetExample.Size"), System.Drawing.Size)
        Me.tpDatasetExample.TabIndex = CType(resources.GetObject("tpDatasetExample.TabIndex"), Integer)
        Me.tpDatasetExample.Text = resources.GetString("tpDatasetExample.Text")
        Me.tpDatasetExample.ToolTipText = resources.GetString("tpDatasetExample.ToolTipText")
        Me.tpDatasetExample.Visible = CType(resources.GetObject("tpDatasetExample.Visible"), Boolean)
        '
        'Label10
        '
        Me.Label10.AccessibleDescription = CType(resources.GetObject("Label10.AccessibleDescription"), String)
        Me.Label10.AccessibleName = CType(resources.GetObject("Label10.AccessibleName"), String)
        Me.Label10.Anchor = CType(resources.GetObject("Label10.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = CType(resources.GetObject("Label10.AutoSize"), Boolean)
        Me.Label10.Dock = CType(resources.GetObject("Label10.Dock"), System.Windows.Forms.DockStyle)
        Me.Label10.Enabled = CType(resources.GetObject("Label10.Enabled"), Boolean)
        Me.Label10.Font = CType(resources.GetObject("Label10.Font"), System.Drawing.Font)
        Me.Label10.ForeColor = System.Drawing.Color.Blue
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
        'btnDataset
        '
        Me.btnDataset.AccessibleDescription = resources.GetString("btnDataset.AccessibleDescription")
        Me.btnDataset.AccessibleName = resources.GetString("btnDataset.AccessibleName")
        Me.btnDataset.Anchor = CType(resources.GetObject("btnDataset.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnDataset.BackgroundImage = CType(resources.GetObject("btnDataset.BackgroundImage"), System.Drawing.Image)
        Me.btnDataset.Dock = CType(resources.GetObject("btnDataset.Dock"), System.Windows.Forms.DockStyle)
        Me.btnDataset.Enabled = CType(resources.GetObject("btnDataset.Enabled"), Boolean)
        Me.btnDataset.FlatStyle = CType(resources.GetObject("btnDataset.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnDataset.Font = CType(resources.GetObject("btnDataset.Font"), System.Drawing.Font)
        Me.btnDataset.Image = CType(resources.GetObject("btnDataset.Image"), System.Drawing.Image)
        Me.btnDataset.ImageAlign = CType(resources.GetObject("btnDataset.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnDataset.ImageIndex = CType(resources.GetObject("btnDataset.ImageIndex"), Integer)
        Me.btnDataset.ImeMode = CType(resources.GetObject("btnDataset.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnDataset.Location = CType(resources.GetObject("btnDataset.Location"), System.Drawing.Point)
        Me.btnDataset.Name = "btnDataset"
        Me.btnDataset.RightToLeft = CType(resources.GetObject("btnDataset.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnDataset.Size = CType(resources.GetObject("btnDataset.Size"), System.Drawing.Size)
        Me.btnDataset.TabIndex = CType(resources.GetObject("btnDataset.TabIndex"), Integer)
        Me.btnDataset.Text = resources.GetString("btnDataset.Text")
        Me.btnDataset.TextAlign = CType(resources.GetObject("btnDataset.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnDataset.Visible = CType(resources.GetObject("btnDataset.Visible"), Boolean)
        '
        'dgMain
        '
        Me.dgMain.AccessibleDescription = resources.GetString("dgMain.AccessibleDescription")
        Me.dgMain.AccessibleName = resources.GetString("dgMain.AccessibleName")
        Me.dgMain.Anchor = CType(resources.GetObject("dgMain.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.dgMain.BackgroundImage = CType(resources.GetObject("dgMain.BackgroundImage"), System.Drawing.Image)
        Me.dgMain.CaptionFont = CType(resources.GetObject("dgMain.CaptionFont"), System.Drawing.Font)
        Me.dgMain.CaptionText = resources.GetString("dgMain.CaptionText")
        Me.dgMain.DataMember = ""
        Me.dgMain.Dock = CType(resources.GetObject("dgMain.Dock"), System.Windows.Forms.DockStyle)
        Me.dgMain.Enabled = CType(resources.GetObject("dgMain.Enabled"), Boolean)
        Me.dgMain.Font = CType(resources.GetObject("dgMain.Font"), System.Drawing.Font)
        Me.dgMain.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgMain.ImeMode = CType(resources.GetObject("dgMain.ImeMode"), System.Windows.Forms.ImeMode)
        Me.dgMain.Location = CType(resources.GetObject("dgMain.Location"), System.Drawing.Point)
        Me.dgMain.Name = "dgMain"
        Me.dgMain.ReadOnly = True
        Me.dgMain.RightToLeft = CType(resources.GetObject("dgMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.dgMain.Size = CType(resources.GetObject("dgMain.Size"), System.Drawing.Size)
        Me.dgMain.TabIndex = CType(resources.GetObject("dgMain.TabIndex"), Integer)
        Me.dgMain.Visible = CType(resources.GetObject("dgMain.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcMain})
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
        Me.tcMain.ResumeLayout(False)
        Me.tpRecordNavigation.ResumeLayout(False)
        Me.tpInsert.ResumeLayout(False)
        Me.tpUpdate.ResumeLayout(False)
        Me.tpDatasetExample.ResumeLayout(False)
        CType(Me.dgMain, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private Sub btnDataset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataset.Click
        ' An ADO 2.6 connection and recordset are created to pull back
        ' data using a SELECT statement.  A data adapter and dataset are
        ' created.  The data Adapters fill method is used to populate
        ' the dataset with the data in the ADO 2.6 recordset.
        ' The dataset is then assigned to the data grid control.

        Dim strSQL As String = "SELECT CustomerID, " & _
                               "       CompanyName, " & _
                               "       ContactName, " & _
                               "       COuntry, " & _
                               "       Region, " & _
                               "       Phone, " & _
                               "       Fax " & _
                               "FROM Customers"

        rs = cnn.Execute(strSQL)

        ' Create Dataset and data adapter objects
        Dim ds As New DataSet("Recordset")
        Dim da As New OleDb.OleDbDataAdapter()

        ' Call data adapter's Fill method to fill data from ADO
        ' Recordset to ADO.NET dataset
        da.Fill(ds, rs, "Customers")

        ' Assign data set to grid control
        dgMain.DataSource = ds
        dgMain.DataMember = "Customers"
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        rs.MoveFirst()
        PopulateSimpleNavigationForm()
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        rs.MoveLast()
        PopulateSimpleNavigationForm()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        ' this code is used to prevent going to EOF
        If Not rs.EOF Then
            rs.MoveNext()

            If rs.EOF Then
                rs.MovePrevious()
            End If

            PopulateSimpleNavigationForm()
        End If
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        ' this code is used to prevent going to BOF
        If Not rs.BOF Then
            rs.MovePrevious()

            If rs.BOF Then
                rs.MoveNext()
            End If

            PopulateSimpleNavigationForm()
        End If
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        ' This event will insert a new record into the Categories table

        ' Validate form
        If txtCategoryName.Text = "" Or txtDescription.Text = "" Then
            MsgBox("Please fill in all the text boxes.", _
                    MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        Dim recordsEffected As Object
        Dim strSQL As String = "INSERT INTO Categories(CategoryName, Description) " & _
                               "VALUES ('" & txtCategoryName.Text & _
                               "','" & txtDescription.Text & "')"

        ' Execute SQL statement
        cnn.Execute(strSQL, recordsEffected)

        If CInt(recordsEffected) = 1 Then
            MsgBox("Insert Successful!", MsgBoxStyle.Exclamation, Me.Text)
        End If

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ' This event updates the description field of the categories
        ' table with the value in the description text box

        If txtUpdateDescription.Text = "" Then
            MsgBox("Please fill in description text box.", _
                    MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        Dim strSQL As String = "UPDATE Categories SET Description = " & _
                                       "'" & txtUpdateDescription.Text & "' " & _
                                       "WHERE CategoryName = " & "'" & _
                                       cbCategoryName.Text & "'"

        cm.ActiveConnection = cnn
        cm.CommandText = strSQL

        Dim recordsEffected As Object
        cm.Execute(recordsEffected)

        ' Check to see if 1 record was effected
        If CInt(recordsEffected) > 0 Then
            MsgBox("Update Successful!", MsgBoxStyle.Exclamation, Me.Text)
        Else
            MsgBox("Update Failed!", MsgBoxStyle.Critical, Me.Text)
        End If
    End Sub

    Private Sub cbCategoryName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCategoryName.SelectedIndexChanged
        ' This event controls what heppens when a category is selected
        ' on the Update example.
        ' When a category is selected the description is displayed
        ' in the test box so the user can change it.

        Dim strSQL As String = "SELECT Description " & _
                               "FROM Categories " & _
                               "WHERE CategoryName = '" & cbCategoryName.Text & "'"

        rs.ActiveConnection = cnn
        rs.CursorType = CursorTypeEnum.adOpenStatic
        rs.Open(strSQL)

        ' Set the text box to the value in the result
        txtUpdateDescription.Text = CStr(rs.Fields("Description").Value)

        rs.Close()
    End Sub

    Private Sub tcMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcMain.SelectedIndexChanged

        ' Close recordset if tab is changed
        If rs.State = 1 Then
            rs.Close()
        End If

        ' Run init subs for sertain tabs when they are selected
        Select Case tcMain.SelectedIndex
            Case 0
                InitRecordNavigation()
            Case 2
                InitSimpleUpdate()
        End Select

    End Sub

    Private Sub InitRecordNavigation()
        ' Simple code showing how to connect to a database
        ' using ADO 2.6 and navigate a recordset

        Dim frmStatusMessage As New frmStatus()
        If Not HasConnected Then
            frmStatusMessage.Show("Connecting to SQL Server")

            ' Attempt to connect to SQL server or MSDE
            Dim IsConnecting As Boolean = True
            While IsConnecting
                Try
                    ' Open a Connection 
                    cnn.ConnectionTimeout = 5
                    cnn.Open(ConnectionString)

                    If cnn.State <> 1 Then
                        Throw New System.Exception("Connection failed.")
                    End If

                    If Not HasConnected Then
                        frmStatusMessage.Close()
                    End If

                    IsConnecting = False
                    HasConnected = True

                Catch Exp As Exception
                    If ConnectionString = SQL_CONNECTION_STRING Then
                        ' Couldn't connect to SQL server. Now try MSDE
                        ConnectionString = MSDE_CONNECTION_STRING
                        frmStatusMessage.Show("Connecting to MSDE")
                    Else
                        ' Unable to connect to SQL Server or MSDE
                        frmStatusMessage.Close()
                        MsgBox("To run this sample you must have SQL Server ot MSDE with " & _
                               "the Northwind database installed.  For instructions on " & _
                               "installing MSDE, view the Readme file.", MsgBoxStyle.Critical, _
                               "SQL Server/MSDE not found")
                        ' Quit program if neither connection method was successful.
                        End

                    End If
                End Try
            End While
        End If

        ' Build SQL statement.
        Dim strSQL As String = "SELECT CompanyName, " & _
                               "       ContactName, " & _
                               "       Phone " & _
                               "FROM Customers"

        rs.ActiveConnection = cnn
        rs.CursorType = CursorTypeEnum.adOpenStatic
        rs.Open(strSQL)
        rs.MoveFirst()

    End Sub

    Private Sub InitSimpleUpdate()

        ' Populate Combo box with categories

        Dim strSQL As String = "SELECT CategoryName " & _
                               "FROM Categories"

        rs.ActiveConnection = cnn
        rs.CursorType = CursorTypeEnum.adOpenStatic
        rs.Open(strSQL)

        ' Loop through records and add them to the combo box
        While Not rs.EOF
            cbCategoryName.Items.Add(rs.Fields("CategoryName").Value)
            rs.MoveNext()
        End While

        rs.Close()
        cbCategoryName.SelectedIndex = 0

    End Sub

    Private Sub PopulateSimpleNavigationForm()

        ' Populate form with data from recordset

        txtCompanyName.Text = CStr(rs.Fields("CompanyName").Value)
        txtContactName.Text = CStr(rs.Fields("ContactName").Value)
        txtPhone.Text = CStr(rs.Fields("Phone").Value)

    End Sub

End Class