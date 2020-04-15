'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient
Imports DataAccessLayer

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
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents grdSuppliers As System.Windows.Forms.DataGrid
    Friend WithEvents grdProducts As System.Windows.Forms.DataGrid
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.grdSuppliers = New System.Windows.Forms.DataGrid()
        Me.grdProducts = New System.Windows.Forms.DataGrid()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.grdSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProducts, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'MenuItem1
        '
        Me.MenuItem1.Enabled = CType(resources.GetObject("MenuItem1.Enabled"), Boolean)
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Shortcut = CType(resources.GetObject("MenuItem1.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem1.ShowShortcut = CType(resources.GetObject("MenuItem1.ShowShortcut"), Boolean)
        Me.MenuItem1.Text = resources.GetString("MenuItem1.Text")
        Me.MenuItem1.Visible = CType(resources.GetObject("MenuItem1.Visible"), Boolean)
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
        'MenuItem2
        '
        Me.MenuItem2.Enabled = CType(resources.GetObject("MenuItem2.Enabled"), Boolean)
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Shortcut = CType(resources.GetObject("MenuItem2.Shortcut"), System.Windows.Forms.Shortcut)
        Me.MenuItem2.ShowShortcut = CType(resources.GetObject("MenuItem2.ShowShortcut"), Boolean)
        Me.MenuItem2.Text = resources.GetString("MenuItem2.Text")
        Me.MenuItem2.Visible = CType(resources.GetObject("MenuItem2.Visible"), Boolean)
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
        'grdSuppliers
        '
        Me.grdSuppliers.AccessibleDescription = resources.GetString("grdSuppliers.AccessibleDescription")
        Me.grdSuppliers.AccessibleName = resources.GetString("grdSuppliers.AccessibleName")
        Me.grdSuppliers.Anchor = CType(resources.GetObject("grdSuppliers.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdSuppliers.BackgroundImage = CType(resources.GetObject("grdSuppliers.BackgroundImage"), System.Drawing.Image)
        Me.grdSuppliers.CaptionFont = CType(resources.GetObject("grdSuppliers.CaptionFont"), System.Drawing.Font)
        Me.grdSuppliers.CaptionText = resources.GetString("grdSuppliers.CaptionText")
        Me.grdSuppliers.DataMember = ""
        Me.grdSuppliers.Dock = CType(resources.GetObject("grdSuppliers.Dock"), System.Windows.Forms.DockStyle)
        Me.grdSuppliers.Enabled = CType(resources.GetObject("grdSuppliers.Enabled"), Boolean)
        Me.grdSuppliers.Font = CType(resources.GetObject("grdSuppliers.Font"), System.Drawing.Font)
        Me.grdSuppliers.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdSuppliers.ImeMode = CType(resources.GetObject("grdSuppliers.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grdSuppliers.Location = CType(resources.GetObject("grdSuppliers.Location"), System.Drawing.Point)
        Me.grdSuppliers.Name = "grdSuppliers"
        Me.grdSuppliers.RightToLeft = CType(resources.GetObject("grdSuppliers.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grdSuppliers.Size = CType(resources.GetObject("grdSuppliers.Size"), System.Drawing.Size)
        Me.grdSuppliers.TabIndex = CType(resources.GetObject("grdSuppliers.TabIndex"), Integer)
        Me.grdSuppliers.Visible = CType(resources.GetObject("grdSuppliers.Visible"), Boolean)
        '
        'grdProducts
        '
        Me.grdProducts.AccessibleDescription = resources.GetString("grdProducts.AccessibleDescription")
        Me.grdProducts.AccessibleName = resources.GetString("grdProducts.AccessibleName")
        Me.grdProducts.Anchor = CType(resources.GetObject("grdProducts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdProducts.BackgroundImage = CType(resources.GetObject("grdProducts.BackgroundImage"), System.Drawing.Image)
        Me.grdProducts.CaptionFont = CType(resources.GetObject("grdProducts.CaptionFont"), System.Drawing.Font)
        Me.grdProducts.CaptionText = resources.GetString("grdProducts.CaptionText")
        Me.grdProducts.DataMember = ""
        Me.grdProducts.Dock = CType(resources.GetObject("grdProducts.Dock"), System.Windows.Forms.DockStyle)
        Me.grdProducts.Enabled = CType(resources.GetObject("grdProducts.Enabled"), Boolean)
        Me.grdProducts.Font = CType(resources.GetObject("grdProducts.Font"), System.Drawing.Font)
        Me.grdProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdProducts.ImeMode = CType(resources.GetObject("grdProducts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grdProducts.Location = CType(resources.GetObject("grdProducts.Location"), System.Drawing.Point)
        Me.grdProducts.Name = "grdProducts"
        Me.grdProducts.RightToLeft = CType(resources.GetObject("grdProducts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grdProducts.Size = CType(resources.GetObject("grdProducts.Size"), System.Drawing.Size)
        Me.grdProducts.TabIndex = CType(resources.GetObject("grdProducts.TabIndex"), Integer)
        Me.grdProducts.Visible = CType(resources.GetObject("grdProducts.Visible"), Boolean)
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
        'btnRefresh
        '
        Me.btnRefresh.AccessibleDescription = resources.GetString("btnRefresh.AccessibleDescription")
        Me.btnRefresh.AccessibleName = resources.GetString("btnRefresh.AccessibleName")
        Me.btnRefresh.Anchor = CType(resources.GetObject("btnRefresh.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackgroundImage = CType(resources.GetObject("btnRefresh.BackgroundImage"), System.Drawing.Image)
        Me.btnRefresh.Dock = CType(resources.GetObject("btnRefresh.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRefresh.Enabled = CType(resources.GetObject("btnRefresh.Enabled"), Boolean)
        Me.btnRefresh.FlatStyle = CType(resources.GetObject("btnRefresh.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRefresh.Font = CType(resources.GetObject("btnRefresh.Font"), System.Drawing.Font)
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = CType(resources.GetObject("btnRefresh.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRefresh.ImageIndex = CType(resources.GetObject("btnRefresh.ImageIndex"), Integer)
        Me.btnRefresh.ImeMode = CType(resources.GetObject("btnRefresh.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRefresh.Location = CType(resources.GetObject("btnRefresh.Location"), System.Drawing.Point)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.RightToLeft = CType(resources.GetObject("btnRefresh.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRefresh.Size = CType(resources.GetObject("btnRefresh.Size"), System.Drawing.Size)
        Me.btnRefresh.TabIndex = CType(resources.GetObject("btnRefresh.TabIndex"), Integer)
        Me.btnRefresh.Text = resources.GetString("btnRefresh.Text")
        Me.btnRefresh.TextAlign = CType(resources.GetObject("btnRefresh.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRefresh.Visible = CType(resources.GetObject("btnRefresh.Visible"), Boolean)
        '
        'lblTitle
        '
        Me.lblTitle.AccessibleDescription = resources.GetString("lblTitle.AccessibleDescription")
        Me.lblTitle.AccessibleName = resources.GetString("lblTitle.AccessibleName")
        Me.lblTitle.Anchor = CType(resources.GetObject("lblTitle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = CType(resources.GetObject("lblTitle.AutoSize"), Boolean)
        Me.lblTitle.Dock = CType(resources.GetObject("lblTitle.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTitle.Enabled = CType(resources.GetObject("lblTitle.Enabled"), Boolean)
        Me.lblTitle.Font = CType(resources.GetObject("lblTitle.Font"), System.Drawing.Font)
        Me.lblTitle.Image = CType(resources.GetObject("lblTitle.Image"), System.Drawing.Image)
        Me.lblTitle.ImageAlign = CType(resources.GetObject("lblTitle.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTitle.ImageIndex = CType(resources.GetObject("lblTitle.ImageIndex"), Integer)
        Me.lblTitle.ImeMode = CType(resources.GetObject("lblTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTitle.Location = CType(resources.GetObject("lblTitle.Location"), System.Drawing.Point)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = CType(resources.GetObject("lblTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTitle.Size = CType(resources.GetObject("lblTitle.Size"), System.Drawing.Size)
        Me.lblTitle.TabIndex = CType(resources.GetObject("lblTitle.TabIndex"), Integer)
        Me.lblTitle.Text = resources.GetString("lblTitle.Text")
        Me.lblTitle.TextAlign = CType(resources.GetObject("lblTitle.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTitle.Visible = CType(resources.GetObject("lblTitle.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitle, Me.btnRefresh, Me.btnUpdate, Me.grdProducts, Me.grdSuppliers, Me.btnNext, Me.btnPrevious})
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
        CType(Me.grdSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProducts, System.ComponentModel.ISupportInitialize).EndInit()
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

    Protected DidPreviouslyConnect As Boolean = False
    Private dsSupplierProducts As DataSet
    Private dtSupplier As DataTable
    Private dtProduct As DataTable
    Private dvSupplier As DataView
    Private dvProduct As DataView
    Protected WithEvents m_DAL As DataAccess
    Dim frmStatusMessage As New frmStatus()


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

    ' Refresh the data by telling the form to reload. This will get data from the 
    '   database without sending any changes. All changes are abandoned.
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        ' Simply tell the Form to reload
        frmMain_Load(Me, New System.EventArgs())
    End Sub

    ' This button sends any updates to the DataAccessLayer object, and then
    '   reloads the data.
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim m_DAL As New DataAccess()
        m_DAL.UpdateDataSet(dsSupplierProducts.GetChanges())
        frmMain_Load(Me, New System.EventArgs())
    End Sub

    ' Handle the PositionChanged event. 
    Protected Sub dtSupplier_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        BindSuppliersGrid()
        BindProductsGrid()
    End Sub

    ' Handle the KeyDown event for the Form. For this event to fire the KeyPreview
    ' property on the Form must be set to True. It is False by default.
    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ' Let the user scroll through the records using the cursor keys.
        ' Left and right are next and previous. Home and end are first and last.
        If e.KeyCode = Keys.Right Then NextRecord()
        If e.KeyCode = Keys.Left Then PreviousRecord()
    End Sub

    ' Handle the Form load event.
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmStatusMessage = New frmStatus()
        GetDataSet()
        BindSuppliersGrid()
        BindProductsGrid()
    End Sub

    ' This subroutine ensures that if a new row is being added, the correct
    '   SupplierID is automatically added. Note: You should also provide an 
    '   event handler for the grdProducts.CurrentCellChanged event.
    Private Sub grdProducts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProducts.Click
        ' If the row is a new row, that is being added, you should automatically
        '   put in the SupplierID Field (since this is a Master/Detail grid.
        If TypeOf (grdProducts.Item(grdProducts.CurrentRowIndex, 2)) Is DBNull Then
            ' This is a new row, so insert the proper SupplierID
            grdProducts.Item(grdProducts.CurrentRowIndex, 2) = _
                grdSuppliers.Item(grdSuppliers.CurrentRowIndex, 0)
        End If
    End Sub

    ' This subroutine ensures that if a new row is being added, the correct
    '   SupplierID is automatically added. It is in addition to the 
    '   grdProducts_Click event handler, since if the user clicks inside of a
    '   cell, this event is raised instead.
    Private Sub grdProducts_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProducts.CurrentCellChanged
        grdProducts.Select(grdProducts.CurrentCell.RowNumber)

        ' If the row is a new row, that is being added, you should automatically
        '   put in the SupplierID Field (since this is a Master/Detail grid.
        If TypeOf (grdProducts.Item(grdProducts.CurrentRowIndex, 2)) Is DBNull Then
            ' This is a new row, so insert the proper SupplierID
            grdProducts.Item(grdProducts.CurrentRowIndex, 2) = _
                grdSuppliers.Item(grdSuppliers.CurrentRowIndex, 0)
        End If

    End Sub


    ' Handle the DataGrid Click event, which fires only when the DataGrid control 
    ' frame--not the rows or cells--is clicked. Therefore, it's also a good idea 
    ' to handle the CurrentCellChanged event.
    Private Sub grdSuppliers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdSuppliers.Click
        ' Bind the Products grid based on the selection in grdSuppliers.
        BindProductsGrid()
    End Sub

    ' Handle the CurrentCellChanged event, which fires when the user clicks a 
    ' different cell on the grid. Along with the DataGrid Click event, this ensures 
    ' that the Products grid will update no matter where the user clicks on the 
    ' Suppliers grid.
    Private Sub grdSuppliers_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdSuppliers.CurrentCellChanged
        ' Highlight the entire row for user feedback.
        grdSuppliers.Select(grdSuppliers.CurrentCell.RowNumber)
        ' Bind the Products grid based on the selection in grdSuppliers.
        BindProductsGrid()
    End Sub

    ' Close the frmStatusMessage when the connection is completed, regardless
    '   of success.
    Private Sub m_DAL_ConnectionCompleted(ByVal success As Boolean) Handles m_DAL.ConnectionCompleted
        frmStatusMessage.Close()
    End Sub

    ' Alert the user if the DAL failed to connect for some reason.
    Private Sub m_DAL_ConnectionFailure(ByVal reason As String) Handles m_DAL.ConnectionFailure
        MsgBox(reason, MsgBoxStyle.Critical, Me.Text)
        End
    End Sub

    ' Show frmStatus to display connection status.
    Private Sub m_DAL_ConnectionStatusChange(ByVal status As String) Handles m_DAL.ConnectionStatusChange
        frmStatusMessage.Show(status)
    End Sub

    ' Bind and format the Products grid based on the user's current selection
    ' in the Orders grid.
    Sub BindProductsGrid()

        ' Get the current SupplierID by using the DataGrid's CurrentRowIndex, i.e.,
        ' the currently selected row, and using it to match the row in the 
        ' DataView. Then access the "SupplierID" column to get the SupplierID 
        ' for that DataRowView.
        Dim strCurrentSupplierID As String = _
            dvSupplier(grdSuppliers.CurrentRowIndex)("SupplierID").ToString

        ' Filter the OrderDetails data based on the currently selected OrderID.
        '   Since empty SupplierID's are possible (if the user is adding a new supplier)
        '   these must be taken into consideration
        If strCurrentSupplierID = "" Then
            strCurrentSupplierID = "-1"
        End If
        ' Filter the products to display only those with the appropriate
        '   SupplierID
        dvProduct.RowFilter = "SupplierID = " & strCurrentSupplierID

        ' Put a caption on the Grid, and attach a DataSource
        With grdProducts
            .CaptionText = "Products"
            .DataSource = dvProduct
        End With

    End Sub

    ' Bind and format the Products grid
    Sub BindSuppliersGrid()

        ' Put a caption on the Grid, and attach a DataSource
        With grdSuppliers
            .CaptionText = "Suppliers"
            .DataSource = dvSupplier
        End With

    End Sub

    ' Create the DataSet used in this sample. It contains two tables consisting of 
    ' Supplier info and the Products info.
    ' The DataSet is retrieved from a DataAccessLayer object.
    Sub GetDataSet()

        ' Let the user know we're going to get Data from a DAL
        frmStatusMessage.Show("Retrieving Data From Data Access Layer")

        ' Create an instance of the DataAccessLayer and 
        '   retrieve the data (if it hasn't already been created).
        If m_DAL Is Nothing Then
            m_DAL = New DataAccess()
        End If

        ' Call the CreateDataSet to fill our local DataSet with data
        dsSupplierProducts = m_DAL.CreateDataSet()

        ' Set variables for the DataTables for use later.
        dtSupplier = dsSupplierProducts.Tables("Supplier")
        dtProduct = dsSupplierProducts.Tables("Product")

        ' Set up DataViews for the DataGrids 
        dvSupplier = dtSupplier.DefaultView
        dvProduct = dtProduct.DefaultView

    End Sub

    ' Move the selected Supplier Position to the next record.
    Public Sub NextRecord()
        grdSuppliers.UnSelect(grdSuppliers.CurrentRowIndex)
        grdSuppliers.CurrentRowIndex += 1
        grdSuppliers.Select(grdSuppliers.CurrentRowIndex)
    End Sub

    ' Move the selected Supplier Position to the previous record.
    Public Sub PreviousRecord()
        grdSuppliers.UnSelect(grdSuppliers.CurrentRowIndex)
        If grdSuppliers.CurrentRowIndex > 0 Then
            grdSuppliers.CurrentRowIndex -= 1
        End If
        grdSuppliers.Select(grdSuppliers.CurrentRowIndex)
    End Sub

End Class