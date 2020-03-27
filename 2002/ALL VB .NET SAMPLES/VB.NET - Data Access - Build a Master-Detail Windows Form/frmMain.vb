'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient

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
    Friend WithEvents grdOrders As System.Windows.Forms.DataGrid
    Friend WithEvents txtHireDate As System.Windows.Forms.TextBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents lblRecordNumber As System.Windows.Forms.Label
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents txtSalesToDate As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdOrderDetails As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.grdOrders = New System.Windows.Forms.DataGrid()
        Me.txtHireDate = New System.Windows.Forms.TextBox()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.lblRecordNumber = New System.Windows.Forms.Label()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.txtSalesToDate = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdOrderDetails = New System.Windows.Forms.DataGrid()
        CType(Me.grdOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'grdOrders
        '
        Me.grdOrders.AccessibleDescription = resources.GetString("grdOrders.AccessibleDescription")
        Me.grdOrders.AccessibleName = resources.GetString("grdOrders.AccessibleName")
        Me.grdOrders.Anchor = CType(resources.GetObject("grdOrders.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdOrders.BackgroundImage = CType(resources.GetObject("grdOrders.BackgroundImage"), System.Drawing.Image)
        Me.grdOrders.CaptionFont = CType(resources.GetObject("grdOrders.CaptionFont"), System.Drawing.Font)
        Me.grdOrders.CaptionText = resources.GetString("grdOrders.CaptionText")
        Me.grdOrders.DataMember = ""
        Me.grdOrders.Dock = CType(resources.GetObject("grdOrders.Dock"), System.Windows.Forms.DockStyle)
        Me.grdOrders.Enabled = CType(resources.GetObject("grdOrders.Enabled"), Boolean)
        Me.grdOrders.Font = CType(resources.GetObject("grdOrders.Font"), System.Drawing.Font)
        Me.grdOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdOrders.ImeMode = CType(resources.GetObject("grdOrders.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grdOrders.Location = CType(resources.GetObject("grdOrders.Location"), System.Drawing.Point)
        Me.grdOrders.Name = "grdOrders"
        Me.grdOrders.ReadOnly = True
        Me.grdOrders.RightToLeft = CType(resources.GetObject("grdOrders.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grdOrders.Size = CType(resources.GetObject("grdOrders.Size"), System.Drawing.Size)
        Me.grdOrders.TabIndex = CType(resources.GetObject("grdOrders.TabIndex"), Integer)
        Me.grdOrders.Visible = CType(resources.GetObject("grdOrders.Visible"), Boolean)
        '
        'txtHireDate
        '
        Me.txtHireDate.AccessibleDescription = resources.GetString("txtHireDate.AccessibleDescription")
        Me.txtHireDate.AccessibleName = resources.GetString("txtHireDate.AccessibleName")
        Me.txtHireDate.Anchor = CType(resources.GetObject("txtHireDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtHireDate.AutoSize = CType(resources.GetObject("txtHireDate.AutoSize"), Boolean)
        Me.txtHireDate.BackgroundImage = CType(resources.GetObject("txtHireDate.BackgroundImage"), System.Drawing.Image)
        Me.txtHireDate.Dock = CType(resources.GetObject("txtHireDate.Dock"), System.Windows.Forms.DockStyle)
        Me.txtHireDate.Enabled = CType(resources.GetObject("txtHireDate.Enabled"), Boolean)
        Me.txtHireDate.Font = CType(resources.GetObject("txtHireDate.Font"), System.Drawing.Font)
        Me.txtHireDate.ImeMode = CType(resources.GetObject("txtHireDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtHireDate.Location = CType(resources.GetObject("txtHireDate.Location"), System.Drawing.Point)
        Me.txtHireDate.MaxLength = CType(resources.GetObject("txtHireDate.MaxLength"), Integer)
        Me.txtHireDate.Multiline = CType(resources.GetObject("txtHireDate.Multiline"), Boolean)
        Me.txtHireDate.Name = "txtHireDate"
        Me.txtHireDate.PasswordChar = CType(resources.GetObject("txtHireDate.PasswordChar"), Char)
        Me.txtHireDate.ReadOnly = True
        Me.txtHireDate.RightToLeft = CType(resources.GetObject("txtHireDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtHireDate.ScrollBars = CType(resources.GetObject("txtHireDate.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtHireDate.Size = CType(resources.GetObject("txtHireDate.Size"), System.Drawing.Size)
        Me.txtHireDate.TabIndex = CType(resources.GetObject("txtHireDate.TabIndex"), Integer)
        Me.txtHireDate.Text = resources.GetString("txtHireDate.Text")
        Me.txtHireDate.TextAlign = CType(resources.GetObject("txtHireDate.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtHireDate.Visible = CType(resources.GetObject("txtHireDate.Visible"), Boolean)
        Me.txtHireDate.WordWrap = CType(resources.GetObject("txtHireDate.WordWrap"), Boolean)
        '
        'MenuItem1
        '
        Me.MenuItem1.Enabled = CType(resources.GetObject("MenuItem1.Enabled"), Boolean)
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Shortcut = CType(resources.GetObject("MenuItem1.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem1.ShowShortcut = CType(resources.GetObject("MenuItem1.ShowShortcut"), Boolean)
        Me.MenuItem1.Text = resources.GetString("MenuItem1.Text")
        Me.MenuItem1.Visible = CType(resources.GetObject("MenuItem1.Visible"), Boolean)
        '
        'lblRecordNumber
        '
        Me.lblRecordNumber.AccessibleDescription = resources.GetString("lblRecordNumber.AccessibleDescription")
        Me.lblRecordNumber.AccessibleName = resources.GetString("lblRecordNumber.AccessibleName")
        Me.lblRecordNumber.Anchor = CType(resources.GetObject("lblRecordNumber.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblRecordNumber.AutoSize = CType(resources.GetObject("lblRecordNumber.AutoSize"), Boolean)
        Me.lblRecordNumber.Dock = CType(resources.GetObject("lblRecordNumber.Dock"), System.Windows.Forms.DockStyle)
        Me.lblRecordNumber.Enabled = CType(resources.GetObject("lblRecordNumber.Enabled"), Boolean)
        Me.lblRecordNumber.Font = CType(resources.GetObject("lblRecordNumber.Font"), System.Drawing.Font)
        Me.lblRecordNumber.Image = CType(resources.GetObject("lblRecordNumber.Image"), System.Drawing.Image)
        Me.lblRecordNumber.ImageAlign = CType(resources.GetObject("lblRecordNumber.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblRecordNumber.ImageIndex = CType(resources.GetObject("lblRecordNumber.ImageIndex"), Integer)
        Me.lblRecordNumber.ImeMode = CType(resources.GetObject("lblRecordNumber.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblRecordNumber.Location = CType(resources.GetObject("lblRecordNumber.Location"), System.Drawing.Point)
        Me.lblRecordNumber.Name = "lblRecordNumber"
        Me.lblRecordNumber.RightToLeft = CType(resources.GetObject("lblRecordNumber.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblRecordNumber.Size = CType(resources.GetObject("lblRecordNumber.Size"), System.Drawing.Size)
        Me.lblRecordNumber.TabIndex = CType(resources.GetObject("lblRecordNumber.TabIndex"), Integer)
        Me.lblRecordNumber.Text = resources.GetString("lblRecordNumber.Text")
        Me.lblRecordNumber.TextAlign = CType(resources.GetObject("lblRecordNumber.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblRecordNumber.Visible = CType(resources.GetObject("lblRecordNumber.Visible"), Boolean)
        '
        'btnLast
        '
        Me.btnLast.AccessibleDescription = resources.GetString("btnLast.AccessibleDescription")
        Me.btnLast.AccessibleName = resources.GetString("btnLast.AccessibleName")
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
        Me.btnNext.AccessibleDescription = resources.GetString("btnNext.AccessibleDescription")
        Me.btnNext.AccessibleName = resources.GetString("btnNext.AccessibleName")
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
        'btnPrevious
        '
        Me.btnPrevious.AccessibleDescription = resources.GetString("btnPrevious.AccessibleDescription")
        Me.btnPrevious.AccessibleName = resources.GetString("btnPrevious.AccessibleName")
        Me.btnPrevious.Anchor = CType(resources.GetObject("btnPrevious.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPrevious.BackgroundImage = CType(resources.GetObject("btnPrevious.BackgroundImage"), System.Drawing.Image)
        Me.btnPrevious.Dock = CType(resources.GetObject("btnPrevious.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPrevious.Enabled = CType(resources.GetObject("btnPrevious.Enabled"), Boolean)
        Me.btnPrevious.FlatStyle = CType(resources.GetObject("btnPrevious.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPrevious.Font = CType(resources.GetObject("btnPrevious.Font"), System.Drawing.Font)
        Me.btnPrevious.Image = CType(resources.GetObject("btnPrevious.Image"), System.Drawing.Image)
        Me.btnPrevious.ImageAlign = CType(resources.GetObject("btnPrevious.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPrevious.ImageIndex = CType(resources.GetObject("btnPrevious.ImageIndex"), Integer)
        Me.btnPrevious.ImeMode = CType(resources.GetObject("btnPrevious.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPrevious.Location = CType(resources.GetObject("btnPrevious.Location"), System.Drawing.Point)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.RightToLeft = CType(resources.GetObject("btnPrevious.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPrevious.Size = CType(resources.GetObject("btnPrevious.Size"), System.Drawing.Size)
        Me.btnPrevious.TabIndex = CType(resources.GetObject("btnPrevious.TabIndex"), Integer)
        Me.btnPrevious.Text = resources.GetString("btnPrevious.Text")
        Me.btnPrevious.TextAlign = CType(resources.GetObject("btnPrevious.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPrevious.Visible = CType(resources.GetObject("btnPrevious.Visible"), Boolean)
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleDescription = resources.GetString("btnFirst.AccessibleDescription")
        Me.btnFirst.AccessibleName = resources.GetString("btnFirst.AccessibleName")
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
        'txtSalesToDate
        '
        Me.txtSalesToDate.AccessibleDescription = resources.GetString("txtSalesToDate.AccessibleDescription")
        Me.txtSalesToDate.AccessibleName = resources.GetString("txtSalesToDate.AccessibleName")
        Me.txtSalesToDate.Anchor = CType(resources.GetObject("txtSalesToDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtSalesToDate.AutoSize = CType(resources.GetObject("txtSalesToDate.AutoSize"), Boolean)
        Me.txtSalesToDate.BackgroundImage = CType(resources.GetObject("txtSalesToDate.BackgroundImage"), System.Drawing.Image)
        Me.txtSalesToDate.Dock = CType(resources.GetObject("txtSalesToDate.Dock"), System.Windows.Forms.DockStyle)
        Me.txtSalesToDate.Enabled = CType(resources.GetObject("txtSalesToDate.Enabled"), Boolean)
        Me.txtSalesToDate.Font = CType(resources.GetObject("txtSalesToDate.Font"), System.Drawing.Font)
        Me.txtSalesToDate.ImeMode = CType(resources.GetObject("txtSalesToDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtSalesToDate.Location = CType(resources.GetObject("txtSalesToDate.Location"), System.Drawing.Point)
        Me.txtSalesToDate.MaxLength = CType(resources.GetObject("txtSalesToDate.MaxLength"), Integer)
        Me.txtSalesToDate.Multiline = CType(resources.GetObject("txtSalesToDate.Multiline"), Boolean)
        Me.txtSalesToDate.Name = "txtSalesToDate"
        Me.txtSalesToDate.PasswordChar = CType(resources.GetObject("txtSalesToDate.PasswordChar"), Char)
        Me.txtSalesToDate.ReadOnly = True
        Me.txtSalesToDate.RightToLeft = CType(resources.GetObject("txtSalesToDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtSalesToDate.ScrollBars = CType(resources.GetObject("txtSalesToDate.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtSalesToDate.Size = CType(resources.GetObject("txtSalesToDate.Size"), System.Drawing.Size)
        Me.txtSalesToDate.TabIndex = CType(resources.GetObject("txtSalesToDate.TabIndex"), Integer)
        Me.txtSalesToDate.Text = resources.GetString("txtSalesToDate.Text")
        Me.txtSalesToDate.TextAlign = CType(resources.GetObject("txtSalesToDate.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtSalesToDate.Visible = CType(resources.GetObject("txtSalesToDate.Visible"), Boolean)
        Me.txtSalesToDate.WordWrap = CType(resources.GetObject("txtSalesToDate.WordWrap"), Boolean)
        '
        'txtFirstName
        '
        Me.txtFirstName.AccessibleDescription = resources.GetString("txtFirstName.AccessibleDescription")
        Me.txtFirstName.AccessibleName = resources.GetString("txtFirstName.AccessibleName")
        Me.txtFirstName.Anchor = CType(resources.GetObject("txtFirstName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtFirstName.AutoSize = CType(resources.GetObject("txtFirstName.AutoSize"), Boolean)
        Me.txtFirstName.BackgroundImage = CType(resources.GetObject("txtFirstName.BackgroundImage"), System.Drawing.Image)
        Me.txtFirstName.Dock = CType(resources.GetObject("txtFirstName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtFirstName.Enabled = CType(resources.GetObject("txtFirstName.Enabled"), Boolean)
        Me.txtFirstName.Font = CType(resources.GetObject("txtFirstName.Font"), System.Drawing.Font)
        Me.txtFirstName.ImeMode = CType(resources.GetObject("txtFirstName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtFirstName.Location = CType(resources.GetObject("txtFirstName.Location"), System.Drawing.Point)
        Me.txtFirstName.MaxLength = CType(resources.GetObject("txtFirstName.MaxLength"), Integer)
        Me.txtFirstName.Multiline = CType(resources.GetObject("txtFirstName.Multiline"), Boolean)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.PasswordChar = CType(resources.GetObject("txtFirstName.PasswordChar"), Char)
        Me.txtFirstName.ReadOnly = True
        Me.txtFirstName.RightToLeft = CType(resources.GetObject("txtFirstName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtFirstName.ScrollBars = CType(resources.GetObject("txtFirstName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtFirstName.Size = CType(resources.GetObject("txtFirstName.Size"), System.Drawing.Size)
        Me.txtFirstName.TabIndex = CType(resources.GetObject("txtFirstName.TabIndex"), Integer)
        Me.txtFirstName.Text = resources.GetString("txtFirstName.Text")
        Me.txtFirstName.TextAlign = CType(resources.GetObject("txtFirstName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtFirstName.Visible = CType(resources.GetObject("txtFirstName.Visible"), Boolean)
        Me.txtFirstName.WordWrap = CType(resources.GetObject("txtFirstName.WordWrap"), Boolean)
        '
        'txtLastName
        '
        Me.txtLastName.AccessibleDescription = resources.GetString("txtLastName.AccessibleDescription")
        Me.txtLastName.AccessibleName = resources.GetString("txtLastName.AccessibleName")
        Me.txtLastName.Anchor = CType(resources.GetObject("txtLastName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtLastName.AutoSize = CType(resources.GetObject("txtLastName.AutoSize"), Boolean)
        Me.txtLastName.BackgroundImage = CType(resources.GetObject("txtLastName.BackgroundImage"), System.Drawing.Image)
        Me.txtLastName.Dock = CType(resources.GetObject("txtLastName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtLastName.Enabled = CType(resources.GetObject("txtLastName.Enabled"), Boolean)
        Me.txtLastName.Font = CType(resources.GetObject("txtLastName.Font"), System.Drawing.Font)
        Me.txtLastName.ImeMode = CType(resources.GetObject("txtLastName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtLastName.Location = CType(resources.GetObject("txtLastName.Location"), System.Drawing.Point)
        Me.txtLastName.MaxLength = CType(resources.GetObject("txtLastName.MaxLength"), Integer)
        Me.txtLastName.Multiline = CType(resources.GetObject("txtLastName.Multiline"), Boolean)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.PasswordChar = CType(resources.GetObject("txtLastName.PasswordChar"), Char)
        Me.txtLastName.ReadOnly = True
        Me.txtLastName.RightToLeft = CType(resources.GetObject("txtLastName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtLastName.ScrollBars = CType(resources.GetObject("txtLastName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtLastName.Size = CType(resources.GetObject("txtLastName.Size"), System.Drawing.Size)
        Me.txtLastName.TabIndex = CType(resources.GetObject("txtLastName.TabIndex"), Integer)
        Me.txtLastName.Text = resources.GetString("txtLastName.Text")
        Me.txtLastName.TextAlign = CType(resources.GetObject("txtLastName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtLastName.Visible = CType(resources.GetObject("txtLastName.Visible"), Boolean)
        Me.txtLastName.WordWrap = CType(resources.GetObject("txtLastName.WordWrap"), Boolean)
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
        'MenuItem2
        '
        Me.MenuItem2.Enabled = CType(resources.GetObject("MenuItem2.Enabled"), Boolean)
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Shortcut = CType(resources.GetObject("MenuItem2.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem2.ShowShortcut = CType(resources.GetObject("MenuItem2.ShowShortcut"), Boolean)
        Me.MenuItem2.Text = resources.GetString("MenuItem2.Text")
        Me.MenuItem2.Visible = CType(resources.GetObject("MenuItem2.Visible"), Boolean)
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
        'MenuItem3
        '
        Me.MenuItem3.Enabled = CType(resources.GetObject("MenuItem3.Enabled"), Boolean)
        Me.MenuItem3.Index = -1
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        Me.MenuItem3.Shortcut = CType(resources.GetObject("MenuItem3.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem3.ShowShortcut = CType(resources.GetObject("MenuItem3.ShowShortcut"), Boolean)
        Me.MenuItem3.Text = resources.GetString("MenuItem3.Text")
        Me.MenuItem3.Visible = CType(resources.GetObject("MenuItem3.Visible"), Boolean)
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
        'MenuItem4
        '
        Me.MenuItem4.Enabled = CType(resources.GetObject("MenuItem4.Enabled"), Boolean)
        Me.MenuItem4.Index = -1
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        Me.MenuItem4.Shortcut = CType(resources.GetObject("MenuItem4.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem4.ShowShortcut = CType(resources.GetObject("MenuItem4.ShowShortcut"), Boolean)
        Me.MenuItem4.Text = resources.GetString("MenuItem4.Text")
        Me.MenuItem4.Visible = CType(resources.GetObject("MenuItem4.Visible"), Boolean)
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
        'grdOrderDetails
        '
        Me.grdOrderDetails.AccessibleDescription = resources.GetString("grdOrderDetails.AccessibleDescription")
        Me.grdOrderDetails.AccessibleName = resources.GetString("grdOrderDetails.AccessibleName")
        Me.grdOrderDetails.Anchor = CType(resources.GetObject("grdOrderDetails.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdOrderDetails.BackgroundImage = CType(resources.GetObject("grdOrderDetails.BackgroundImage"), System.Drawing.Image)
        Me.grdOrderDetails.CaptionFont = CType(resources.GetObject("grdOrderDetails.CaptionFont"), System.Drawing.Font)
        Me.grdOrderDetails.CaptionText = resources.GetString("grdOrderDetails.CaptionText")
        Me.grdOrderDetails.DataMember = ""
        Me.grdOrderDetails.Dock = CType(resources.GetObject("grdOrderDetails.Dock"), System.Windows.Forms.DockStyle)
        Me.grdOrderDetails.Enabled = CType(resources.GetObject("grdOrderDetails.Enabled"), Boolean)
        Me.grdOrderDetails.Font = CType(resources.GetObject("grdOrderDetails.Font"), System.Drawing.Font)
        Me.grdOrderDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdOrderDetails.ImeMode = CType(resources.GetObject("grdOrderDetails.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grdOrderDetails.Location = CType(resources.GetObject("grdOrderDetails.Location"), System.Drawing.Point)
        Me.grdOrderDetails.Name = "grdOrderDetails"
        Me.grdOrderDetails.ReadOnly = True
        Me.grdOrderDetails.RightToLeft = CType(resources.GetObject("grdOrderDetails.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grdOrderDetails.Size = CType(resources.GetObject("grdOrderDetails.Size"), System.Drawing.Size)
        Me.grdOrderDetails.TabIndex = CType(resources.GetObject("grdOrderDetails.TabIndex"), Integer)
        Me.grdOrderDetails.Visible = CType(resources.GetObject("grdOrderDetails.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdOrderDetails, Me.grdOrders, Me.txtHireDate, Me.lblRecordNumber, Me.btnLast, Me.btnNext, Me.btnPrevious, Me.btnFirst, Me.txtSalesToDate, Me.txtFirstName, Me.txtLastName, Me.Label5, Me.Label3, Me.Label2, Me.Label1})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.KeyPreview = True
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
        CType(Me.grdOrders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
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

    ' Initialize constants for connecting to the database
    ' and displaying a connection error to the user.
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

    Protected DidPreviouslyConnect As Boolean = False
    Private dsEmployeeOrders As DataSet
    Private dtEmployee As DataTable
    Private dtOrders As DataTable
    Private dtOrderDetails As DataTable
    Private dtSales As DataTable
    Private dvOrders As DataView
    Private dvOrderDetails As DataView
    Private dvSales As DataView
    Private sda As SqlDataAdapter
    Protected strConn As String = SQL_CONNECTION_STRING

    ' Handle the << Button click event.
    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        ' Move to the first record
        FirstRecord()
    End Sub

    ' Handle the >> Button click event.
    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        ' Move to the last record
        LastRecord()
    End Sub

    ' Handle the > Button click event.
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        ' Move to the next record
        NextRecord()
    End Sub

    ' Handle the < Button click event.
    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        ' Move to the previous record
        PreviousRecord()
    End Sub

    ' Handle the PositionChanged event of the BindingContext. This event is fired in
    ' response to Position changes initiated in the navigation button Click event 
    ' handlers.
    Protected Sub dtEmployee_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindOrdersGrid()
        BindOrderDetailsGrid()
        ShowTotalSales()
        ShowCurrentRecordNumber()
    End Sub

    ' Handle the KeyDown event for the Form. For this event to fire the KeyPreview
    ' property on the Form must be set to True. It is False by default.
    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ' Let the user scroll through the records using the cursor keys.
        ' Left and right are next and previous. Home and end are first and last.
        If e.KeyCode = Keys.Right Then NextRecord()
        If e.KeyCode = Keys.Left Then PreviousRecord()
        If e.KeyCode = Keys.Home Then FirstRecord()
        If e.KeyCode = Keys.End Then LastRecord()
    End Sub

    ' Handle the Form load event.
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateDataSet()
        InitializeBindings()
        BindOrdersGrid()
        BindOrderDetailsGrid()
        ShowCurrentRecordNumber()
    End Sub

    ' Handle the DataGrid Click event, which fires only when the DataGrid control 
    ' frame--not the rows or cells--is clicked. Therefore, it's also a good idea 
    ' to handle the CurrentCellChanged event.
    Private Sub grdOrders_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOrders.Click
        ' Bind the Order Details grid based on the selection in grdOrders.
        BindOrderDetailsGrid()
    End Sub

    ' Handle the CurrentCellChanged event, which fires when the user clicks a 
    ' different cell on the grid. Along with the DataGrid Click event, this ensures 
    ' that the Order Details grid will update no matter where the user clicks on the 
    ' Orders grid.
    Private Sub grdOrders_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOrders.CurrentCellChanged
        ' Highlight the entire row for user feedback.
        grdOrders.Select(grdOrders.CurrentCell.RowNumber)
        ' Bind the Order Details grid based on the selection in grdOrders.
        BindOrderDetailsGrid()
    End Sub

    ' Bind and format the Order Details grid based on the user's current selection
    ' in the Orders grid.
    Sub BindOrderDetailsGrid()
        ' Get the current OrderID by using the DataGrid's CurrentRowIndex, i.e.,
        ' the currently selected row, and using it to match the row in the 
        ' DataView. Then access the "OrderID" column to get the OrderID for that
        ' DataRowView.
        Dim strCurrentOrderID As String = _
            dvOrders(grdOrders.CurrentRowIndex)("OrderID").ToString
        ' Filter the OrderDetails data based on the currently selected OrderID.
        dvOrderDetails.RowFilter = "OrderID = " & strCurrentOrderID

        With grdOrderDetails
            .CaptionText = "Order# " & strCurrentOrderID
            .DataSource = dvOrderDetails
        End With

        ' You must clear out the TableStyles collection before 
        grdOrderDetails.TableStyles.Clear()

        Dim grdTableStyle1 As New DataGridTableStyle()
        With grdTableStyle1
            ' You must always set the MappingName, even with a DataView that has
            ' only one Table. If not, you will get no errors but the formatting
            ' will not appear. To avoid mistakes, instead of typing the name of 
            ' the table used when creating the DataSet, you can access the 
            ' TableName property.
            .MappingName = dvOrderDetails.Table.TableName
        End With

        ' The use of column styles overrides the automatic generation of columns 
        ' for every column in the DataTable. When column style objects are used,
        ' every column you want to display has to have an associate column style 
        ' object.
        Dim grdColStyle1 As New DataGridTextBoxColumn()
        With grdColStyle1
            .MappingName = "ProductName"
            .HeaderText = "Product"
            .Width = 175
        End With

        Dim grdColStyle2 As New DataGridTextBoxColumn()
        With grdColStyle2
            .MappingName = "UnitPrice"
            .HeaderText = "Price"
            ' Format the data as currency.
            .Format = "c"
            .Width = 75
        End With

        Dim grdColStyle3 As New DataGridTextBoxColumn()
        With grdColStyle3
            .MappingName = "Quantity"
            .HeaderText = "Quantity"
            .Width = 75
        End With

        Dim grdColStyle4 As New DataGridTextBoxColumn()
        With grdColStyle4
            .MappingName = "SubTotal"
            .HeaderText = "Sub Total"
            ' Format the data as currency.
            .Format = "c"
            .Width = 75
        End With

        Dim grdColStyle5 As New DataGridTextBoxColumn()
        With grdColStyle5
            .MappingName = "Discount"
            .HeaderText = "Discount"
            ' Format the data to display as an integer percentage. If the 0 was
            ' left off the default precision of two decimal places would be used.
            .Format = "P0"
            .Width = 50
        End With

        Dim grdColStyle6 As New DataGridTextBoxColumn()
        With grdColStyle6
            .MappingName = "CategoryName"
            .HeaderText = "Category"
            .Width = 125
        End With

        ' Add the column style objects to the table style's collection of 
        ' column styles. Without this the styles do not take effect.        
        grdTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() {grdColStyle1, grdColStyle2, _
                grdColStyle3, grdColStyle4, grdColStyle5, grdColStyle6})

        grdOrderDetails.TableStyles.Add(grdTableStyle1)
    End Sub

    ' Bind and format the Orders grid based on the user's current Employee selection.
    Sub BindOrdersGrid()
        ' Filter the Orders data based on the value of the Tag property bound 
        ' earlier. The tag contains the EmployeeID.
        dvOrders.RowFilter = "EmployeeID = " & txtLastName.Tag.ToString

        With grdOrders
            .CaptionText = "Orders"
            .DataSource = dvOrders
        End With

        ' You must clear out the TableStyles collection before 
        grdOrders.TableStyles.Clear()

        Dim grdTableStyle1 As New DataGridTableStyle()
        With grdTableStyle1
            ' You must always set the MappingName, even with a DataView that has
            ' only one Table. If not, you will get no errors but the formatting
            ' will not appear. To avoid mistakes, instead of typing the name of 
            ' the table used when creating the DataSet, you can access the 
            ' TableName property.
            .MappingName = dvOrders.Table.TableName
        End With

        ' The use of column styles overrides the automatic generation of columns 
        ' for every column in the DataTable. When column style objects are used,
        ' every column you want to display has to have an associate column style 
        ' object.
        Dim grdColStyle1 As New DataGridTextBoxColumn()
        With grdColStyle1
            .MappingName = "OrderID"
            .HeaderText = "Order ID"
            .Width = 50
        End With

        Dim grdColStyle2 As New DataGridTextBoxColumn()
        With grdColStyle2
            .MappingName = "CompanyName"
            .HeaderText = "Customer"
            .Width = 140
        End With

        Dim grdColStyle3 As New DataGridTextBoxColumn()
        With grdColStyle3
            .MappingName = "OrderDate"
            ' Format the data as a date. This removes the time from the DateTime Sql
            ' data type.
            .Format = "d"
            .HeaderText = "Order Date"
            .Width = 75
        End With

        Dim grdColStyle4 As New DataGridTextBoxColumn()
        With grdColStyle4
            .MappingName = "Total"
            .HeaderText = "Total"
            ' Format the data as currency.
            .Format = "c"
            .Width = 75
        End With

        ' Add the column style objects to the table style's collection of 
        ' column styles. Without this the styles do not take effect.        
        grdTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() {grdColStyle1, grdColStyle2, _
                grdColStyle3, grdColStyle4})
        grdOrders.TableStyles.Add(grdTableStyle1)
    End Sub

    ' Create the DataSet used in this sample. It contains four tables consisting of 
    ' Employee info, the Employee's orders, Sales to Date, and the Order Details.
    Sub CreateDataSet()
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
                    "SELECT EmployeeID, LastName, FirstName, HireDate " & _
                    "FROM Employees"

                ' A SqlCommand object is used to execute the SQL commands.
                Dim scmd As New SqlCommand(strSQL, scnnNW)

                ' A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
                sda = New SqlDataAdapter(scmd)

                ' A SqlCommandBuilder automatically generates the SQL commands needed
                ' to update the database later (in the btnSave_Click event handler).
                Dim scb As New SqlCommandBuilder(sda)

                ' The commands generated by the SqlCommandBuilder are based on the 
                ' currently set CommandText of the SqlCommand object. As this will
                ' be changing to a SQL statement that won't be needed for an Update 
                ' in the btnSave Click event handler, you can call GetUpdateCommand
                ' explicitly to generate the Update command based on the current 
                ' CommandText property value.
                scb.GetUpdateCommand()

                ' Create a new DataSet and fill its first DataTable.
                dsEmployeeOrders = New DataSet()
                sda.Fill(dsEmployeeOrders, "Employee")

                ' Reset the CommandText to get the Employee orders.
                scmd.CommandText = _
                    "SELECT od.OrderID, SUM(CONVERT(money, (od.UnitPrice * " & _
                    "   od.Quantity) * (1 - od.Discount) / 100) * 100) " & _
                    "   AS Total, o.EmployeeID, o.OrderDate, " & _
                    "   c.CompanyName" & vbCrLf & _
                    "FROM [Order Details] od " & _
                    "   INNER JOIN Orders o " & _
                    "   ON od.OrderID = o.OrderID" & vbCrLf & _
                    "   INNER JOIN Customers c " & _
                    "   ON o.CustomerID = c.CustomerID" & vbCrLf & _
                    "GROUP BY od.OrderID, o.EmployeeID, o.OrderDate, c.CompanyName"

                ' Fill the second table in the DataSet.
                sda.Fill(dsEmployeeOrders, "Orders")

                ' Reset the CommandText to get the Employee Sales-To-Date.
                scmd.CommandText = _
                    "SELECT e.employeeid, sum(UnitPrice * Quantity) as " & _
                    "   'SalesToDate' " & _
                    "FROM [order details] od " & _
                    "   INNER JOIN orders o " & _
                    "   ON o.orderid = od.orderid " & _
                    "   INNER JOIN employees e " & _
                    "   ON e.employeeid = o.employeeid" & vbCrLf & _
                    "GROUP BY e.employeeid"

                ' Fill the third table in the DataSet.
                sda.Fill(dsEmployeeOrders, "Sales")

                ' Reset the CommandText to get the Order details.
                scmd.CommandText = _
                    "SELECT od.OrderID, od.UnitPrice, od.Quantity, od.Discount, " & _
                    "       p.ProductName, c.CategoryName, " & _
                    "       (od.UnitPrice * od.Quantity) As SubTotal " & _
                    "FROM [order details] od " & _
                    "   INNER JOIN Products p ON od.ProductID = p.ProductID " & _
                    "   INNER JOIN Categories c ON c.CategoryID = p.CategoryID " & _
                    "ORDER BY od.OrderID"

                ' Fill the fourth table in the DataSet.
                sda.Fill(dsEmployeeOrders, "OrderDetails")

                ' Set variables for the DataTables for use later.
                dtEmployee = dsEmployeeOrders.Tables(0)
                dtOrders = dsEmployeeOrders.Tables(1)
                dtSales = dsEmployeeOrders.Tables(2)
                dtOrderDetails = dsEmployeeOrders.Tables(3)

                ' Set up DataViews for the DataGrids and SalesToDate
                ' TextBox.
                dvOrders = dtOrders.DefaultView
                dvOrderDetails = dtOrderDetails.DefaultView
                dvSales = dtSales.DefaultView

                ' OPTIONAL: To see a different kind of Master-Details interface,
                ' in which both the master and details data is contained in the
                ' same DataGrid, uncomment the following line of code, which sets
                ' up a parent-child table relation. Then re-run the app and 
                ' expand the OrderID node and view order details all in the same
                ' DataGrid (the Order Details grid is not needed then). On the 
                ' Orders DataGrid, click the white arrow on the upper right to 
                ' return to the Master view.
                'dsEmployeeOrders.Relations.Add("Order_OrderDetails", _
                '    dtOrders.Columns("OrderID"), dtOrderDetails.Columns("OrderID"))

                ' Data has been successfully retrieved, so break out of the loop
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
            frmStatusMessage.Close()
        End While
    End Sub

    ' Handle the Format event for the Hire Date TextBox
    Protected Sub DateToString(ByVal sender As Object, ByVal e As ConvertEventArgs)
        ' You could use either of the following to convert to the proper date 
        ' format:
        'e.Value = CType(e.Value, DateTime).ToString("d")
        e.Value = CType(e.Value, DateTime).ToShortDateString
    End Sub

    ' Move the BindingContext Position to the first record.
    Public Sub FirstRecord()
        ' The position of the binding context controls the "current record"
        ' Position the first record is record 0 (not 1).
        Me.BindingContext(dtEmployee).Position = 0
    End Sub

    ' Set up all the bindings for various controls.
    Private Sub InitializeBindings()
        txtLastName.DataBindings.Add("Text", dtEmployee, "LastName")
        ' Using the Tag property you can bind a hidden value that is useful when
        ' stepping through the records. In this demo, the EmployeeID numbers match
        ' the DataTable row numbers, so you could just use the Position property
        ' as in ShowCurrentRecordNumber.
        txtLastName.DataBindings.Add("Tag", dtEmployee, "EmployeeID")
        txtFirstName.DataBindings.Add("Text", dtEmployee, "FirstName")

        ' The Binding object binds a single property of a control to a single
        ' field of the data source. After creating a Binding object you add it
        ' to the ControlBindingCollection object exposed by all Windows Forms
        ' controls via the DataBindings property.
        Dim dbnHireDate As New Binding("Text", dtEmployee, "HireDate")
        txtHireDate.DataBindings.Add(dbnHireDate)
        ' If you are using custom format/parse handlers, add them next.
        AddHandler dbnHireDate.Format, AddressOf DateToString
        AddHandler dbnHireDate.Parse, AddressOf StringToDate

        Dim dbnSalesToDate As New Binding("Text", dtSales, "SalesToDate")
        txtSalesToDate.DataBindings.Add(dbnSalesToDate)
        AddHandler dbnSalesToDate.Format, AddressOf MoneyToString
        AddHandler dbnSalesToDate.Parse, AddressOf StringToMoney

        ' The Form's BindingContext property exposes the BindingManagerBase
        ' object, which gathers all the Binding objects associated with the same
        ' data source (in this case, the DataTable dtEmployee). This object fires
        ' a PositionChanged event which is one of the key events to handle in a 
        ' Master-Details application. The position is advanced programmatically in
        ' the Click event handlers for the navigation buttons.
        AddHandler Me.BindingContext(dtEmployee).PositionChanged, _
            AddressOf dtEmployee_PositionChanged
    End Sub

    ' Move the BindingContext Position to the last record.
    Public Sub LastRecord()
        ' The position of the binding context controls the "current record". 
        ' Use dsEmployeeOrders("EmployeeInfo").Rows.Count to figure out the total 
        ' number of records.  -1 because position is zero based.
        Me.BindingContext(dtEmployee).Position = dtEmployee.Rows.Count - 1
    End Sub

    ' Handle the Format event for the SalesToDate TextBox.
    Protected Sub MoneyToString(ByVal sender As Object, ByVal e As ConvertEventArgs)
        e.Value = CType(e.Value, Decimal).ToString("c")
    End Sub

    ' Move the BindingContext Position to the next record.
    Public Sub NextRecord()
        ' The position of the binding context controls the "current record"
        Me.BindingContext(dtEmployee).Position += 1
    End Sub

    ' Move the BindingContext Position to the previous record.
    Public Sub PreviousRecord()
        ' The position of the binding context controls the "current record"
        Me.BindingContext(dtEmployee).Position -= 1
    End Sub

    ' Display the current record number and total records.
    Protected Sub ShowCurrentRecordNumber()
        ' The position  of the binding context contains the current record.
        ' Add 1 so that the first record displays as record 1 (instead of 0).
        ' dtEmployee.Rows.Count gives the total number of records.
        lblRecordNumber.Text = "Record " & _
            Me.BindingContext(dtEmployee).Position + 1 & " of " & _
                dtEmployee.Rows.Count
    End Sub

    ' Update the value of the Sales To Date for each employee as the user
    ' steps through the records.
    Protected Sub ShowTotalSales()
        ' Filter the sales total based on the value of the Tag property bound 
        ' earlier.
        dvSales.RowFilter = "EmployeeID = " & txtLastName.Tag.ToString
    End Sub

    ' Handle the Parse event for the Hire Date TextBox.
    Protected Sub StringToDate(ByVal sender As Object, ByVal e As ConvertEventArgs)
        Try
            e.Value = CDate(e.Value)
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    ' Handle the Parse event for the Sales To Date TextBox.
    Protected Sub StringToMoney(ByVal sender As Object, ByVal e As ConvertEventArgs)
        Try
            ' Double is equivalent to a Money SQL data type.
            e.Value = CType(e.Value, Double)
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

End Class