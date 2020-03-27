'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Text

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' Initialize constants for connecting to the database
    ' and displaying a connection error to the user.
    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    ' Change the path to the Northwind database, as needed. If you get a runtime 
    ' error that the database cannot be found, make sure you have installed
    ' the Northwind database. See the Readme for more information.
    Protected Const ACCESS_CONNECTION_STRING As String = _
    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\Northwind.mdb"

    Protected Const CONNECTION_ERROR_MSG As String = _
        "To run this sample, you must have SQL " & _
        "or MSDE with the Northwind database installed.  For " & _
        "instructions on installing MSDE, view the ReadMe file."

    Protected DidPreviouslyConnect As Boolean = False
    Protected HasCreatedSprocs As Boolean = False
    Protected strConn As String

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
    Friend WithEvents tabApp As System.Windows.Forms.TabControl
    Friend WithEvents pgeCreateSprocs As System.Windows.Forms.TabPage
    Friend WithEvents pgeNoParams As System.Windows.Forms.TabPage
    Friend WithEvents pgeInputParam As System.Windows.Forms.TabPage
    Friend WithEvents pgeMSAccess As System.Windows.Forms.TabPage
    Friend WithEvents btnCreateSprocs As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdProducts As System.Windows.Forms.DataGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGet10MostExpProds As System.Windows.Forms.Button
    Friend WithEvents txtTenMostExpProds As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGetProducts As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnGetProductCountAndAvgPrice As System.Windows.Forms.Button
    Friend WithEvents lblProductCountAndAvgPrice As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBeginningDate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtEndingDate As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateReport As System.Windows.Forms.Button
    Friend WithEvents grdSales As System.Windows.Forms.DataGrid
    Friend WithEvents lblNoSales As System.Windows.Forms.Label
    Friend WithEvents pgeAllTypes As System.Windows.Forms.TabPage
    Friend WithEvents cboCategoriesInputParam As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategoriesAllTypes As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tabApp = New System.Windows.Forms.TabControl()
        Me.pgeCreateSprocs = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCreateSprocs = New System.Windows.Forms.Button()
        Me.pgeNoParams = New System.Windows.Forms.TabPage()
        Me.txtTenMostExpProds = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGet10MostExpProds = New System.Windows.Forms.Button()
        Me.pgeInputParam = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grdProducts = New System.Windows.Forms.DataGrid()
        Me.btnGetProducts = New System.Windows.Forms.Button()
        Me.cboCategoriesInputParam = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pgeAllTypes = New System.Windows.Forms.TabPage()
        Me.lblProductCountAndAvgPrice = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGetProductCountAndAvgPrice = New System.Windows.Forms.Button()
        Me.cboCategoriesAllTypes = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pgeMSAccess = New System.Windows.Forms.TabPage()
        Me.btnCreateReport = New System.Windows.Forms.Button()
        Me.txtEndingDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBeginningDate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grdSales = New System.Windows.Forms.DataGrid()
        Me.lblNoSales = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tabApp.SuspendLayout()
        Me.pgeCreateSprocs.SuspendLayout()
        Me.pgeNoParams.SuspendLayout()
        Me.pgeInputParam.SuspendLayout()
        CType(Me.grdProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pgeAllTypes.SuspendLayout()
        Me.pgeMSAccess.SuspendLayout()
        CType(Me.grdSales, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'tabApp
        '
        Me.tabApp.AccessibleDescription = resources.GetString("tabApp.AccessibleDescription")
        Me.tabApp.AccessibleName = resources.GetString("tabApp.AccessibleName")
        Me.tabApp.Alignment = CType(resources.GetObject("tabApp.Alignment"), System.Windows.Forms.TabAlignment)
        Me.tabApp.Anchor = CType(resources.GetObject("tabApp.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tabApp.Appearance = CType(resources.GetObject("tabApp.Appearance"), System.Windows.Forms.TabAppearance)
        Me.tabApp.BackgroundImage = CType(resources.GetObject("tabApp.BackgroundImage"), System.Drawing.Image)
        Me.tabApp.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeCreateSprocs, Me.pgeNoParams, Me.pgeInputParam, Me.pgeAllTypes, Me.pgeMSAccess})
        Me.tabApp.Dock = CType(resources.GetObject("tabApp.Dock"), System.Windows.Forms.DockStyle)
        Me.tabApp.Enabled = CType(resources.GetObject("tabApp.Enabled"), Boolean)
        Me.tabApp.Font = CType(resources.GetObject("tabApp.Font"), System.Drawing.Font)
        Me.tabApp.ImeMode = CType(resources.GetObject("tabApp.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tabApp.ItemSize = CType(resources.GetObject("tabApp.ItemSize"), System.Drawing.Size)
        Me.tabApp.Location = CType(resources.GetObject("tabApp.Location"), System.Drawing.Point)
        Me.tabApp.Name = "tabApp"
        Me.tabApp.Padding = CType(resources.GetObject("tabApp.Padding"), System.Drawing.Point)
        Me.tabApp.RightToLeft = CType(resources.GetObject("tabApp.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tabApp.SelectedIndex = 0
        Me.tabApp.ShowToolTips = CType(resources.GetObject("tabApp.ShowToolTips"), Boolean)
        Me.tabApp.Size = CType(resources.GetObject("tabApp.Size"), System.Drawing.Size)
        Me.tabApp.TabIndex = CType(resources.GetObject("tabApp.TabIndex"), Integer)
        Me.tabApp.Text = resources.GetString("tabApp.Text")
        Me.tabApp.Visible = CType(resources.GetObject("tabApp.Visible"), Boolean)
        '
        'pgeCreateSprocs
        '
        Me.pgeCreateSprocs.AccessibleDescription = resources.GetString("pgeCreateSprocs.AccessibleDescription")
        Me.pgeCreateSprocs.AccessibleName = resources.GetString("pgeCreateSprocs.AccessibleName")
        Me.pgeCreateSprocs.Anchor = CType(resources.GetObject("pgeCreateSprocs.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeCreateSprocs.AutoScroll = CType(resources.GetObject("pgeCreateSprocs.AutoScroll"), Boolean)
        Me.pgeCreateSprocs.AutoScrollMargin = CType(resources.GetObject("pgeCreateSprocs.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeCreateSprocs.AutoScrollMinSize = CType(resources.GetObject("pgeCreateSprocs.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeCreateSprocs.BackgroundImage = CType(resources.GetObject("pgeCreateSprocs.BackgroundImage"), System.Drawing.Image)
        Me.pgeCreateSprocs.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.btnCreateSprocs})
        Me.pgeCreateSprocs.Dock = CType(resources.GetObject("pgeCreateSprocs.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeCreateSprocs.Enabled = CType(resources.GetObject("pgeCreateSprocs.Enabled"), Boolean)
        Me.pgeCreateSprocs.Font = CType(resources.GetObject("pgeCreateSprocs.Font"), System.Drawing.Font)
        Me.pgeCreateSprocs.ImageIndex = CType(resources.GetObject("pgeCreateSprocs.ImageIndex"), Integer)
        Me.pgeCreateSprocs.ImeMode = CType(resources.GetObject("pgeCreateSprocs.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeCreateSprocs.Location = CType(resources.GetObject("pgeCreateSprocs.Location"), System.Drawing.Point)
        Me.pgeCreateSprocs.Name = "pgeCreateSprocs"
        Me.pgeCreateSprocs.RightToLeft = CType(resources.GetObject("pgeCreateSprocs.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeCreateSprocs.Size = CType(resources.GetObject("pgeCreateSprocs.Size"), System.Drawing.Size)
        Me.pgeCreateSprocs.TabIndex = CType(resources.GetObject("pgeCreateSprocs.TabIndex"), Integer)
        Me.pgeCreateSprocs.Text = resources.GetString("pgeCreateSprocs.Text")
        Me.pgeCreateSprocs.ToolTipText = resources.GetString("pgeCreateSprocs.ToolTipText")
        Me.pgeCreateSprocs.Visible = CType(resources.GetObject("pgeCreateSprocs.Visible"), Boolean)
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
        'btnCreateSprocs
        '
        Me.btnCreateSprocs.AccessibleDescription = resources.GetString("btnCreateSprocs.AccessibleDescription")
        Me.btnCreateSprocs.AccessibleName = resources.GetString("btnCreateSprocs.AccessibleName")
        Me.btnCreateSprocs.Anchor = CType(resources.GetObject("btnCreateSprocs.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateSprocs.BackgroundImage = CType(resources.GetObject("btnCreateSprocs.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateSprocs.Dock = CType(resources.GetObject("btnCreateSprocs.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateSprocs.Enabled = CType(resources.GetObject("btnCreateSprocs.Enabled"), Boolean)
        Me.btnCreateSprocs.FlatStyle = CType(resources.GetObject("btnCreateSprocs.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateSprocs.Font = CType(resources.GetObject("btnCreateSprocs.Font"), System.Drawing.Font)
        Me.btnCreateSprocs.Image = CType(resources.GetObject("btnCreateSprocs.Image"), System.Drawing.Image)
        Me.btnCreateSprocs.ImageAlign = CType(resources.GetObject("btnCreateSprocs.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateSprocs.ImageIndex = CType(resources.GetObject("btnCreateSprocs.ImageIndex"), Integer)
        Me.btnCreateSprocs.ImeMode = CType(resources.GetObject("btnCreateSprocs.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateSprocs.Location = CType(resources.GetObject("btnCreateSprocs.Location"), System.Drawing.Point)
        Me.btnCreateSprocs.Name = "btnCreateSprocs"
        Me.btnCreateSprocs.RightToLeft = CType(resources.GetObject("btnCreateSprocs.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateSprocs.Size = CType(resources.GetObject("btnCreateSprocs.Size"), System.Drawing.Size)
        Me.btnCreateSprocs.TabIndex = CType(resources.GetObject("btnCreateSprocs.TabIndex"), Integer)
        Me.btnCreateSprocs.Text = resources.GetString("btnCreateSprocs.Text")
        Me.btnCreateSprocs.TextAlign = CType(resources.GetObject("btnCreateSprocs.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateSprocs.Visible = CType(resources.GetObject("btnCreateSprocs.Visible"), Boolean)
        '
        'pgeNoParams
        '
        Me.pgeNoParams.AccessibleDescription = resources.GetString("pgeNoParams.AccessibleDescription")
        Me.pgeNoParams.AccessibleName = resources.GetString("pgeNoParams.AccessibleName")
        Me.pgeNoParams.Anchor = CType(resources.GetObject("pgeNoParams.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeNoParams.AutoScroll = CType(resources.GetObject("pgeNoParams.AutoScroll"), Boolean)
        Me.pgeNoParams.AutoScrollMargin = CType(resources.GetObject("pgeNoParams.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeNoParams.AutoScrollMinSize = CType(resources.GetObject("pgeNoParams.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeNoParams.BackgroundImage = CType(resources.GetObject("pgeNoParams.BackgroundImage"), System.Drawing.Image)
        Me.pgeNoParams.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTenMostExpProds, Me.Label1, Me.btnGet10MostExpProds})
        Me.pgeNoParams.Dock = CType(resources.GetObject("pgeNoParams.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeNoParams.Enabled = CType(resources.GetObject("pgeNoParams.Enabled"), Boolean)
        Me.pgeNoParams.Font = CType(resources.GetObject("pgeNoParams.Font"), System.Drawing.Font)
        Me.pgeNoParams.ImageIndex = CType(resources.GetObject("pgeNoParams.ImageIndex"), Integer)
        Me.pgeNoParams.ImeMode = CType(resources.GetObject("pgeNoParams.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeNoParams.Location = CType(resources.GetObject("pgeNoParams.Location"), System.Drawing.Point)
        Me.pgeNoParams.Name = "pgeNoParams"
        Me.pgeNoParams.RightToLeft = CType(resources.GetObject("pgeNoParams.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeNoParams.Size = CType(resources.GetObject("pgeNoParams.Size"), System.Drawing.Size)
        Me.pgeNoParams.TabIndex = CType(resources.GetObject("pgeNoParams.TabIndex"), Integer)
        Me.pgeNoParams.Text = resources.GetString("pgeNoParams.Text")
        Me.pgeNoParams.ToolTipText = resources.GetString("pgeNoParams.ToolTipText")
        Me.pgeNoParams.Visible = CType(resources.GetObject("pgeNoParams.Visible"), Boolean)
        '
        'txtTenMostExpProds
        '
        Me.txtTenMostExpProds.AccessibleDescription = resources.GetString("txtTenMostExpProds.AccessibleDescription")
        Me.txtTenMostExpProds.AccessibleName = resources.GetString("txtTenMostExpProds.AccessibleName")
        Me.txtTenMostExpProds.Anchor = CType(resources.GetObject("txtTenMostExpProds.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtTenMostExpProds.AutoSize = CType(resources.GetObject("txtTenMostExpProds.AutoSize"), Boolean)
        Me.txtTenMostExpProds.BackgroundImage = CType(resources.GetObject("txtTenMostExpProds.BackgroundImage"), System.Drawing.Image)
        Me.txtTenMostExpProds.Dock = CType(resources.GetObject("txtTenMostExpProds.Dock"), System.Windows.Forms.DockStyle)
        Me.txtTenMostExpProds.Enabled = CType(resources.GetObject("txtTenMostExpProds.Enabled"), Boolean)
        Me.txtTenMostExpProds.Font = CType(resources.GetObject("txtTenMostExpProds.Font"), System.Drawing.Font)
        Me.txtTenMostExpProds.ImeMode = CType(resources.GetObject("txtTenMostExpProds.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtTenMostExpProds.Location = CType(resources.GetObject("txtTenMostExpProds.Location"), System.Drawing.Point)
        Me.txtTenMostExpProds.MaxLength = CType(resources.GetObject("txtTenMostExpProds.MaxLength"), Integer)
        Me.txtTenMostExpProds.Multiline = CType(resources.GetObject("txtTenMostExpProds.Multiline"), Boolean)
        Me.txtTenMostExpProds.Name = "txtTenMostExpProds"
        Me.txtTenMostExpProds.PasswordChar = CType(resources.GetObject("txtTenMostExpProds.PasswordChar"), Char)
        Me.txtTenMostExpProds.RightToLeft = CType(resources.GetObject("txtTenMostExpProds.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtTenMostExpProds.ScrollBars = CType(resources.GetObject("txtTenMostExpProds.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtTenMostExpProds.Size = CType(resources.GetObject("txtTenMostExpProds.Size"), System.Drawing.Size)
        Me.txtTenMostExpProds.TabIndex = CType(resources.GetObject("txtTenMostExpProds.TabIndex"), Integer)
        Me.txtTenMostExpProds.Text = resources.GetString("txtTenMostExpProds.Text")
        Me.txtTenMostExpProds.TextAlign = CType(resources.GetObject("txtTenMostExpProds.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtTenMostExpProds.Visible = CType(resources.GetObject("txtTenMostExpProds.Visible"), Boolean)
        Me.txtTenMostExpProds.WordWrap = CType(resources.GetObject("txtTenMostExpProds.WordWrap"), Boolean)
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
        'btnGet10MostExpProds
        '
        Me.btnGet10MostExpProds.AccessibleDescription = resources.GetString("btnGet10MostExpProds.AccessibleDescription")
        Me.btnGet10MostExpProds.AccessibleName = resources.GetString("btnGet10MostExpProds.AccessibleName")
        Me.btnGet10MostExpProds.Anchor = CType(resources.GetObject("btnGet10MostExpProds.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGet10MostExpProds.BackgroundImage = CType(resources.GetObject("btnGet10MostExpProds.BackgroundImage"), System.Drawing.Image)
        Me.btnGet10MostExpProds.Dock = CType(resources.GetObject("btnGet10MostExpProds.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGet10MostExpProds.Enabled = CType(resources.GetObject("btnGet10MostExpProds.Enabled"), Boolean)
        Me.btnGet10MostExpProds.FlatStyle = CType(resources.GetObject("btnGet10MostExpProds.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGet10MostExpProds.Font = CType(resources.GetObject("btnGet10MostExpProds.Font"), System.Drawing.Font)
        Me.btnGet10MostExpProds.Image = CType(resources.GetObject("btnGet10MostExpProds.Image"), System.Drawing.Image)
        Me.btnGet10MostExpProds.ImageAlign = CType(resources.GetObject("btnGet10MostExpProds.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGet10MostExpProds.ImageIndex = CType(resources.GetObject("btnGet10MostExpProds.ImageIndex"), Integer)
        Me.btnGet10MostExpProds.ImeMode = CType(resources.GetObject("btnGet10MostExpProds.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGet10MostExpProds.Location = CType(resources.GetObject("btnGet10MostExpProds.Location"), System.Drawing.Point)
        Me.btnGet10MostExpProds.Name = "btnGet10MostExpProds"
        Me.btnGet10MostExpProds.RightToLeft = CType(resources.GetObject("btnGet10MostExpProds.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGet10MostExpProds.Size = CType(resources.GetObject("btnGet10MostExpProds.Size"), System.Drawing.Size)
        Me.btnGet10MostExpProds.TabIndex = CType(resources.GetObject("btnGet10MostExpProds.TabIndex"), Integer)
        Me.btnGet10MostExpProds.Text = resources.GetString("btnGet10MostExpProds.Text")
        Me.btnGet10MostExpProds.TextAlign = CType(resources.GetObject("btnGet10MostExpProds.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGet10MostExpProds.Visible = CType(resources.GetObject("btnGet10MostExpProds.Visible"), Boolean)
        '
        'pgeInputParam
        '
        Me.pgeInputParam.AccessibleDescription = resources.GetString("pgeInputParam.AccessibleDescription")
        Me.pgeInputParam.AccessibleName = resources.GetString("pgeInputParam.AccessibleName")
        Me.pgeInputParam.Anchor = CType(resources.GetObject("pgeInputParam.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeInputParam.AutoScroll = CType(resources.GetObject("pgeInputParam.AutoScroll"), Boolean)
        Me.pgeInputParam.AutoScrollMargin = CType(resources.GetObject("pgeInputParam.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeInputParam.AutoScrollMinSize = CType(resources.GetObject("pgeInputParam.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeInputParam.BackgroundImage = CType(resources.GetObject("pgeInputParam.BackgroundImage"), System.Drawing.Image)
        Me.pgeInputParam.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.grdProducts, Me.btnGetProducts, Me.cboCategoriesInputParam, Me.Label3})
        Me.pgeInputParam.Dock = CType(resources.GetObject("pgeInputParam.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeInputParam.Enabled = CType(resources.GetObject("pgeInputParam.Enabled"), Boolean)
        Me.pgeInputParam.Font = CType(resources.GetObject("pgeInputParam.Font"), System.Drawing.Font)
        Me.pgeInputParam.ImageIndex = CType(resources.GetObject("pgeInputParam.ImageIndex"), Integer)
        Me.pgeInputParam.ImeMode = CType(resources.GetObject("pgeInputParam.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeInputParam.Location = CType(resources.GetObject("pgeInputParam.Location"), System.Drawing.Point)
        Me.pgeInputParam.Name = "pgeInputParam"
        Me.pgeInputParam.RightToLeft = CType(resources.GetObject("pgeInputParam.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeInputParam.Size = CType(resources.GetObject("pgeInputParam.Size"), System.Drawing.Size)
        Me.pgeInputParam.TabIndex = CType(resources.GetObject("pgeInputParam.TabIndex"), Integer)
        Me.pgeInputParam.Text = resources.GetString("pgeInputParam.Text")
        Me.pgeInputParam.ToolTipText = resources.GetString("pgeInputParam.ToolTipText")
        Me.pgeInputParam.Visible = CType(resources.GetObject("pgeInputParam.Visible"), Boolean)
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
        'btnGetProducts
        '
        Me.btnGetProducts.AccessibleDescription = resources.GetString("btnGetProducts.AccessibleDescription")
        Me.btnGetProducts.AccessibleName = resources.GetString("btnGetProducts.AccessibleName")
        Me.btnGetProducts.Anchor = CType(resources.GetObject("btnGetProducts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetProducts.BackgroundImage = CType(resources.GetObject("btnGetProducts.BackgroundImage"), System.Drawing.Image)
        Me.btnGetProducts.Dock = CType(resources.GetObject("btnGetProducts.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetProducts.Enabled = CType(resources.GetObject("btnGetProducts.Enabled"), Boolean)
        Me.btnGetProducts.FlatStyle = CType(resources.GetObject("btnGetProducts.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetProducts.Font = CType(resources.GetObject("btnGetProducts.Font"), System.Drawing.Font)
        Me.btnGetProducts.Image = CType(resources.GetObject("btnGetProducts.Image"), System.Drawing.Image)
        Me.btnGetProducts.ImageAlign = CType(resources.GetObject("btnGetProducts.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetProducts.ImageIndex = CType(resources.GetObject("btnGetProducts.ImageIndex"), Integer)
        Me.btnGetProducts.ImeMode = CType(resources.GetObject("btnGetProducts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetProducts.Location = CType(resources.GetObject("btnGetProducts.Location"), System.Drawing.Point)
        Me.btnGetProducts.Name = "btnGetProducts"
        Me.btnGetProducts.RightToLeft = CType(resources.GetObject("btnGetProducts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetProducts.Size = CType(resources.GetObject("btnGetProducts.Size"), System.Drawing.Size)
        Me.btnGetProducts.TabIndex = CType(resources.GetObject("btnGetProducts.TabIndex"), Integer)
        Me.btnGetProducts.Text = resources.GetString("btnGetProducts.Text")
        Me.btnGetProducts.TextAlign = CType(resources.GetObject("btnGetProducts.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetProducts.Visible = CType(resources.GetObject("btnGetProducts.Visible"), Boolean)
        '
        'cboCategoriesInputParam
        '
        Me.cboCategoriesInputParam.AccessibleDescription = resources.GetString("cboCategoriesInputParam.AccessibleDescription")
        Me.cboCategoriesInputParam.AccessibleName = resources.GetString("cboCategoriesInputParam.AccessibleName")
        Me.cboCategoriesInputParam.Anchor = CType(resources.GetObject("cboCategoriesInputParam.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboCategoriesInputParam.BackgroundImage = CType(resources.GetObject("cboCategoriesInputParam.BackgroundImage"), System.Drawing.Image)
        Me.cboCategoriesInputParam.Dock = CType(resources.GetObject("cboCategoriesInputParam.Dock"), System.Windows.Forms.DockStyle)
        Me.cboCategoriesInputParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoriesInputParam.Enabled = CType(resources.GetObject("cboCategoriesInputParam.Enabled"), Boolean)
        Me.cboCategoriesInputParam.Font = CType(resources.GetObject("cboCategoriesInputParam.Font"), System.Drawing.Font)
        Me.cboCategoriesInputParam.ImeMode = CType(resources.GetObject("cboCategoriesInputParam.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboCategoriesInputParam.IntegralHeight = CType(resources.GetObject("cboCategoriesInputParam.IntegralHeight"), Boolean)
        Me.cboCategoriesInputParam.ItemHeight = CType(resources.GetObject("cboCategoriesInputParam.ItemHeight"), Integer)
        Me.cboCategoriesInputParam.Location = CType(resources.GetObject("cboCategoriesInputParam.Location"), System.Drawing.Point)
        Me.cboCategoriesInputParam.MaxDropDownItems = CType(resources.GetObject("cboCategoriesInputParam.MaxDropDownItems"), Integer)
        Me.cboCategoriesInputParam.MaxLength = CType(resources.GetObject("cboCategoriesInputParam.MaxLength"), Integer)
        Me.cboCategoriesInputParam.Name = "cboCategoriesInputParam"
        Me.cboCategoriesInputParam.RightToLeft = CType(resources.GetObject("cboCategoriesInputParam.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboCategoriesInputParam.Size = CType(resources.GetObject("cboCategoriesInputParam.Size"), System.Drawing.Size)
        Me.cboCategoriesInputParam.TabIndex = CType(resources.GetObject("cboCategoriesInputParam.TabIndex"), Integer)
        Me.cboCategoriesInputParam.Text = resources.GetString("cboCategoriesInputParam.Text")
        Me.cboCategoriesInputParam.Visible = CType(resources.GetObject("cboCategoriesInputParam.Visible"), Boolean)
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
        'pgeAllTypes
        '
        Me.pgeAllTypes.AccessibleDescription = resources.GetString("pgeAllTypes.AccessibleDescription")
        Me.pgeAllTypes.AccessibleName = resources.GetString("pgeAllTypes.AccessibleName")
        Me.pgeAllTypes.Anchor = CType(resources.GetObject("pgeAllTypes.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeAllTypes.AutoScroll = CType(resources.GetObject("pgeAllTypes.AutoScroll"), Boolean)
        Me.pgeAllTypes.AutoScrollMargin = CType(resources.GetObject("pgeAllTypes.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeAllTypes.AutoScrollMinSize = CType(resources.GetObject("pgeAllTypes.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeAllTypes.BackgroundImage = CType(resources.GetObject("pgeAllTypes.BackgroundImage"), System.Drawing.Image)
        Me.pgeAllTypes.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProductCountAndAvgPrice, Me.Label5, Me.btnGetProductCountAndAvgPrice, Me.cboCategoriesAllTypes, Me.Label6})
        Me.pgeAllTypes.Dock = CType(resources.GetObject("pgeAllTypes.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeAllTypes.Enabled = CType(resources.GetObject("pgeAllTypes.Enabled"), Boolean)
        Me.pgeAllTypes.Font = CType(resources.GetObject("pgeAllTypes.Font"), System.Drawing.Font)
        Me.pgeAllTypes.ImageIndex = CType(resources.GetObject("pgeAllTypes.ImageIndex"), Integer)
        Me.pgeAllTypes.ImeMode = CType(resources.GetObject("pgeAllTypes.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeAllTypes.Location = CType(resources.GetObject("pgeAllTypes.Location"), System.Drawing.Point)
        Me.pgeAllTypes.Name = "pgeAllTypes"
        Me.pgeAllTypes.RightToLeft = CType(resources.GetObject("pgeAllTypes.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeAllTypes.Size = CType(resources.GetObject("pgeAllTypes.Size"), System.Drawing.Size)
        Me.pgeAllTypes.TabIndex = CType(resources.GetObject("pgeAllTypes.TabIndex"), Integer)
        Me.pgeAllTypes.Text = resources.GetString("pgeAllTypes.Text")
        Me.pgeAllTypes.ToolTipText = resources.GetString("pgeAllTypes.ToolTipText")
        Me.pgeAllTypes.Visible = CType(resources.GetObject("pgeAllTypes.Visible"), Boolean)
        '
        'lblProductCountAndAvgPrice
        '
        Me.lblProductCountAndAvgPrice.AccessibleDescription = resources.GetString("lblProductCountAndAvgPrice.AccessibleDescription")
        Me.lblProductCountAndAvgPrice.AccessibleName = resources.GetString("lblProductCountAndAvgPrice.AccessibleName")
        Me.lblProductCountAndAvgPrice.Anchor = CType(resources.GetObject("lblProductCountAndAvgPrice.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProductCountAndAvgPrice.AutoSize = CType(resources.GetObject("lblProductCountAndAvgPrice.AutoSize"), Boolean)
        Me.lblProductCountAndAvgPrice.Dock = CType(resources.GetObject("lblProductCountAndAvgPrice.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProductCountAndAvgPrice.Enabled = CType(resources.GetObject("lblProductCountAndAvgPrice.Enabled"), Boolean)
        Me.lblProductCountAndAvgPrice.Font = CType(resources.GetObject("lblProductCountAndAvgPrice.Font"), System.Drawing.Font)
        Me.lblProductCountAndAvgPrice.Image = CType(resources.GetObject("lblProductCountAndAvgPrice.Image"), System.Drawing.Image)
        Me.lblProductCountAndAvgPrice.ImageAlign = CType(resources.GetObject("lblProductCountAndAvgPrice.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProductCountAndAvgPrice.ImageIndex = CType(resources.GetObject("lblProductCountAndAvgPrice.ImageIndex"), Integer)
        Me.lblProductCountAndAvgPrice.ImeMode = CType(resources.GetObject("lblProductCountAndAvgPrice.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProductCountAndAvgPrice.Location = CType(resources.GetObject("lblProductCountAndAvgPrice.Location"), System.Drawing.Point)
        Me.lblProductCountAndAvgPrice.Name = "lblProductCountAndAvgPrice"
        Me.lblProductCountAndAvgPrice.RightToLeft = CType(resources.GetObject("lblProductCountAndAvgPrice.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProductCountAndAvgPrice.Size = CType(resources.GetObject("lblProductCountAndAvgPrice.Size"), System.Drawing.Size)
        Me.lblProductCountAndAvgPrice.TabIndex = CType(resources.GetObject("lblProductCountAndAvgPrice.TabIndex"), Integer)
        Me.lblProductCountAndAvgPrice.Text = resources.GetString("lblProductCountAndAvgPrice.Text")
        Me.lblProductCountAndAvgPrice.TextAlign = CType(resources.GetObject("lblProductCountAndAvgPrice.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProductCountAndAvgPrice.Visible = CType(resources.GetObject("lblProductCountAndAvgPrice.Visible"), Boolean)
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
        'btnGetProductCountAndAvgPrice
        '
        Me.btnGetProductCountAndAvgPrice.AccessibleDescription = resources.GetString("btnGetProductCountAndAvgPrice.AccessibleDescription")
        Me.btnGetProductCountAndAvgPrice.AccessibleName = resources.GetString("btnGetProductCountAndAvgPrice.AccessibleName")
        Me.btnGetProductCountAndAvgPrice.Anchor = CType(resources.GetObject("btnGetProductCountAndAvgPrice.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetProductCountAndAvgPrice.BackgroundImage = CType(resources.GetObject("btnGetProductCountAndAvgPrice.BackgroundImage"), System.Drawing.Image)
        Me.btnGetProductCountAndAvgPrice.Dock = CType(resources.GetObject("btnGetProductCountAndAvgPrice.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetProductCountAndAvgPrice.Enabled = CType(resources.GetObject("btnGetProductCountAndAvgPrice.Enabled"), Boolean)
        Me.btnGetProductCountAndAvgPrice.FlatStyle = CType(resources.GetObject("btnGetProductCountAndAvgPrice.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetProductCountAndAvgPrice.Font = CType(resources.GetObject("btnGetProductCountAndAvgPrice.Font"), System.Drawing.Font)
        Me.btnGetProductCountAndAvgPrice.Image = CType(resources.GetObject("btnGetProductCountAndAvgPrice.Image"), System.Drawing.Image)
        Me.btnGetProductCountAndAvgPrice.ImageAlign = CType(resources.GetObject("btnGetProductCountAndAvgPrice.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetProductCountAndAvgPrice.ImageIndex = CType(resources.GetObject("btnGetProductCountAndAvgPrice.ImageIndex"), Integer)
        Me.btnGetProductCountAndAvgPrice.ImeMode = CType(resources.GetObject("btnGetProductCountAndAvgPrice.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetProductCountAndAvgPrice.Location = CType(resources.GetObject("btnGetProductCountAndAvgPrice.Location"), System.Drawing.Point)
        Me.btnGetProductCountAndAvgPrice.Name = "btnGetProductCountAndAvgPrice"
        Me.btnGetProductCountAndAvgPrice.RightToLeft = CType(resources.GetObject("btnGetProductCountAndAvgPrice.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetProductCountAndAvgPrice.Size = CType(resources.GetObject("btnGetProductCountAndAvgPrice.Size"), System.Drawing.Size)
        Me.btnGetProductCountAndAvgPrice.TabIndex = CType(resources.GetObject("btnGetProductCountAndAvgPrice.TabIndex"), Integer)
        Me.btnGetProductCountAndAvgPrice.Text = resources.GetString("btnGetProductCountAndAvgPrice.Text")
        Me.btnGetProductCountAndAvgPrice.TextAlign = CType(resources.GetObject("btnGetProductCountAndAvgPrice.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetProductCountAndAvgPrice.Visible = CType(resources.GetObject("btnGetProductCountAndAvgPrice.Visible"), Boolean)
        '
        'cboCategoriesAllTypes
        '
        Me.cboCategoriesAllTypes.AccessibleDescription = resources.GetString("cboCategoriesAllTypes.AccessibleDescription")
        Me.cboCategoriesAllTypes.AccessibleName = resources.GetString("cboCategoriesAllTypes.AccessibleName")
        Me.cboCategoriesAllTypes.Anchor = CType(resources.GetObject("cboCategoriesAllTypes.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboCategoriesAllTypes.BackgroundImage = CType(resources.GetObject("cboCategoriesAllTypes.BackgroundImage"), System.Drawing.Image)
        Me.cboCategoriesAllTypes.Dock = CType(resources.GetObject("cboCategoriesAllTypes.Dock"), System.Windows.Forms.DockStyle)
        Me.cboCategoriesAllTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoriesAllTypes.Enabled = CType(resources.GetObject("cboCategoriesAllTypes.Enabled"), Boolean)
        Me.cboCategoriesAllTypes.Font = CType(resources.GetObject("cboCategoriesAllTypes.Font"), System.Drawing.Font)
        Me.cboCategoriesAllTypes.ImeMode = CType(resources.GetObject("cboCategoriesAllTypes.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboCategoriesAllTypes.IntegralHeight = CType(resources.GetObject("cboCategoriesAllTypes.IntegralHeight"), Boolean)
        Me.cboCategoriesAllTypes.ItemHeight = CType(resources.GetObject("cboCategoriesAllTypes.ItemHeight"), Integer)
        Me.cboCategoriesAllTypes.Location = CType(resources.GetObject("cboCategoriesAllTypes.Location"), System.Drawing.Point)
        Me.cboCategoriesAllTypes.MaxDropDownItems = CType(resources.GetObject("cboCategoriesAllTypes.MaxDropDownItems"), Integer)
        Me.cboCategoriesAllTypes.MaxLength = CType(resources.GetObject("cboCategoriesAllTypes.MaxLength"), Integer)
        Me.cboCategoriesAllTypes.Name = "cboCategoriesAllTypes"
        Me.cboCategoriesAllTypes.RightToLeft = CType(resources.GetObject("cboCategoriesAllTypes.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboCategoriesAllTypes.Size = CType(resources.GetObject("cboCategoriesAllTypes.Size"), System.Drawing.Size)
        Me.cboCategoriesAllTypes.TabIndex = CType(resources.GetObject("cboCategoriesAllTypes.TabIndex"), Integer)
        Me.cboCategoriesAllTypes.Text = resources.GetString("cboCategoriesAllTypes.Text")
        Me.cboCategoriesAllTypes.Visible = CType(resources.GetObject("cboCategoriesAllTypes.Visible"), Boolean)
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
        'pgeMSAccess
        '
        Me.pgeMSAccess.AccessibleDescription = resources.GetString("pgeMSAccess.AccessibleDescription")
        Me.pgeMSAccess.AccessibleName = resources.GetString("pgeMSAccess.AccessibleName")
        Me.pgeMSAccess.Anchor = CType(resources.GetObject("pgeMSAccess.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeMSAccess.AutoScroll = CType(resources.GetObject("pgeMSAccess.AutoScroll"), Boolean)
        Me.pgeMSAccess.AutoScrollMargin = CType(resources.GetObject("pgeMSAccess.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeMSAccess.AutoScrollMinSize = CType(resources.GetObject("pgeMSAccess.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeMSAccess.BackgroundImage = CType(resources.GetObject("pgeMSAccess.BackgroundImage"), System.Drawing.Image)
        Me.pgeMSAccess.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCreateReport, Me.txtEndingDate, Me.Label10, Me.Label9, Me.txtBeginningDate, Me.Label8, Me.grdSales, Me.lblNoSales})
        Me.pgeMSAccess.Dock = CType(resources.GetObject("pgeMSAccess.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeMSAccess.Enabled = CType(resources.GetObject("pgeMSAccess.Enabled"), Boolean)
        Me.pgeMSAccess.Font = CType(resources.GetObject("pgeMSAccess.Font"), System.Drawing.Font)
        Me.pgeMSAccess.ImageIndex = CType(resources.GetObject("pgeMSAccess.ImageIndex"), Integer)
        Me.pgeMSAccess.ImeMode = CType(resources.GetObject("pgeMSAccess.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeMSAccess.Location = CType(resources.GetObject("pgeMSAccess.Location"), System.Drawing.Point)
        Me.pgeMSAccess.Name = "pgeMSAccess"
        Me.pgeMSAccess.RightToLeft = CType(resources.GetObject("pgeMSAccess.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeMSAccess.Size = CType(resources.GetObject("pgeMSAccess.Size"), System.Drawing.Size)
        Me.pgeMSAccess.TabIndex = CType(resources.GetObject("pgeMSAccess.TabIndex"), Integer)
        Me.pgeMSAccess.Text = resources.GetString("pgeMSAccess.Text")
        Me.pgeMSAccess.ToolTipText = resources.GetString("pgeMSAccess.ToolTipText")
        Me.pgeMSAccess.Visible = CType(resources.GetObject("pgeMSAccess.Visible"), Boolean)
        '
        'btnCreateReport
        '
        Me.btnCreateReport.AccessibleDescription = resources.GetString("btnCreateReport.AccessibleDescription")
        Me.btnCreateReport.AccessibleName = resources.GetString("btnCreateReport.AccessibleName")
        Me.btnCreateReport.Anchor = CType(resources.GetObject("btnCreateReport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateReport.BackgroundImage = CType(resources.GetObject("btnCreateReport.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateReport.Dock = CType(resources.GetObject("btnCreateReport.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateReport.Enabled = CType(resources.GetObject("btnCreateReport.Enabled"), Boolean)
        Me.btnCreateReport.FlatStyle = CType(resources.GetObject("btnCreateReport.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateReport.Font = CType(resources.GetObject("btnCreateReport.Font"), System.Drawing.Font)
        Me.btnCreateReport.Image = CType(resources.GetObject("btnCreateReport.Image"), System.Drawing.Image)
        Me.btnCreateReport.ImageAlign = CType(resources.GetObject("btnCreateReport.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateReport.ImageIndex = CType(resources.GetObject("btnCreateReport.ImageIndex"), Integer)
        Me.btnCreateReport.ImeMode = CType(resources.GetObject("btnCreateReport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateReport.Location = CType(resources.GetObject("btnCreateReport.Location"), System.Drawing.Point)
        Me.btnCreateReport.Name = "btnCreateReport"
        Me.btnCreateReport.RightToLeft = CType(resources.GetObject("btnCreateReport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateReport.Size = CType(resources.GetObject("btnCreateReport.Size"), System.Drawing.Size)
        Me.btnCreateReport.TabIndex = CType(resources.GetObject("btnCreateReport.TabIndex"), Integer)
        Me.btnCreateReport.Text = resources.GetString("btnCreateReport.Text")
        Me.btnCreateReport.TextAlign = CType(resources.GetObject("btnCreateReport.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateReport.Visible = CType(resources.GetObject("btnCreateReport.Visible"), Boolean)
        '
        'txtEndingDate
        '
        Me.txtEndingDate.AccessibleDescription = resources.GetString("txtEndingDate.AccessibleDescription")
        Me.txtEndingDate.AccessibleName = resources.GetString("txtEndingDate.AccessibleName")
        Me.txtEndingDate.Anchor = CType(resources.GetObject("txtEndingDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtEndingDate.AutoSize = CType(resources.GetObject("txtEndingDate.AutoSize"), Boolean)
        Me.txtEndingDate.BackgroundImage = CType(resources.GetObject("txtEndingDate.BackgroundImage"), System.Drawing.Image)
        Me.txtEndingDate.Dock = CType(resources.GetObject("txtEndingDate.Dock"), System.Windows.Forms.DockStyle)
        Me.txtEndingDate.Enabled = CType(resources.GetObject("txtEndingDate.Enabled"), Boolean)
        Me.txtEndingDate.Font = CType(resources.GetObject("txtEndingDate.Font"), System.Drawing.Font)
        Me.txtEndingDate.ImeMode = CType(resources.GetObject("txtEndingDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtEndingDate.Location = CType(resources.GetObject("txtEndingDate.Location"), System.Drawing.Point)
        Me.txtEndingDate.MaxLength = CType(resources.GetObject("txtEndingDate.MaxLength"), Integer)
        Me.txtEndingDate.Multiline = CType(resources.GetObject("txtEndingDate.Multiline"), Boolean)
        Me.txtEndingDate.Name = "txtEndingDate"
        Me.txtEndingDate.PasswordChar = CType(resources.GetObject("txtEndingDate.PasswordChar"), Char)
        Me.txtEndingDate.RightToLeft = CType(resources.GetObject("txtEndingDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtEndingDate.ScrollBars = CType(resources.GetObject("txtEndingDate.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtEndingDate.Size = CType(resources.GetObject("txtEndingDate.Size"), System.Drawing.Size)
        Me.txtEndingDate.TabIndex = CType(resources.GetObject("txtEndingDate.TabIndex"), Integer)
        Me.txtEndingDate.Text = resources.GetString("txtEndingDate.Text")
        Me.txtEndingDate.TextAlign = CType(resources.GetObject("txtEndingDate.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtEndingDate.Visible = CType(resources.GetObject("txtEndingDate.Visible"), Boolean)
        Me.txtEndingDate.WordWrap = CType(resources.GetObject("txtEndingDate.WordWrap"), Boolean)
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
        'txtBeginningDate
        '
        Me.txtBeginningDate.AccessibleDescription = resources.GetString("txtBeginningDate.AccessibleDescription")
        Me.txtBeginningDate.AccessibleName = resources.GetString("txtBeginningDate.AccessibleName")
        Me.txtBeginningDate.Anchor = CType(resources.GetObject("txtBeginningDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtBeginningDate.AutoSize = CType(resources.GetObject("txtBeginningDate.AutoSize"), Boolean)
        Me.txtBeginningDate.BackgroundImage = CType(resources.GetObject("txtBeginningDate.BackgroundImage"), System.Drawing.Image)
        Me.txtBeginningDate.Dock = CType(resources.GetObject("txtBeginningDate.Dock"), System.Windows.Forms.DockStyle)
        Me.txtBeginningDate.Enabled = CType(resources.GetObject("txtBeginningDate.Enabled"), Boolean)
        Me.txtBeginningDate.Font = CType(resources.GetObject("txtBeginningDate.Font"), System.Drawing.Font)
        Me.txtBeginningDate.ImeMode = CType(resources.GetObject("txtBeginningDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtBeginningDate.Location = CType(resources.GetObject("txtBeginningDate.Location"), System.Drawing.Point)
        Me.txtBeginningDate.MaxLength = CType(resources.GetObject("txtBeginningDate.MaxLength"), Integer)
        Me.txtBeginningDate.Multiline = CType(resources.GetObject("txtBeginningDate.Multiline"), Boolean)
        Me.txtBeginningDate.Name = "txtBeginningDate"
        Me.txtBeginningDate.PasswordChar = CType(resources.GetObject("txtBeginningDate.PasswordChar"), Char)
        Me.txtBeginningDate.RightToLeft = CType(resources.GetObject("txtBeginningDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtBeginningDate.ScrollBars = CType(resources.GetObject("txtBeginningDate.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtBeginningDate.Size = CType(resources.GetObject("txtBeginningDate.Size"), System.Drawing.Size)
        Me.txtBeginningDate.TabIndex = CType(resources.GetObject("txtBeginningDate.TabIndex"), Integer)
        Me.txtBeginningDate.Text = resources.GetString("txtBeginningDate.Text")
        Me.txtBeginningDate.TextAlign = CType(resources.GetObject("txtBeginningDate.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtBeginningDate.Visible = CType(resources.GetObject("txtBeginningDate.Visible"), Boolean)
        Me.txtBeginningDate.WordWrap = CType(resources.GetObject("txtBeginningDate.WordWrap"), Boolean)
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
        'grdSales
        '
        Me.grdSales.AccessibleDescription = resources.GetString("grdSales.AccessibleDescription")
        Me.grdSales.AccessibleName = resources.GetString("grdSales.AccessibleName")
        Me.grdSales.Anchor = CType(resources.GetObject("grdSales.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdSales.BackgroundImage = CType(resources.GetObject("grdSales.BackgroundImage"), System.Drawing.Image)
        Me.grdSales.CaptionFont = CType(resources.GetObject("grdSales.CaptionFont"), System.Drawing.Font)
        Me.grdSales.CaptionText = resources.GetString("grdSales.CaptionText")
        Me.grdSales.DataMember = ""
        Me.grdSales.Dock = CType(resources.GetObject("grdSales.Dock"), System.Windows.Forms.DockStyle)
        Me.grdSales.Enabled = CType(resources.GetObject("grdSales.Enabled"), Boolean)
        Me.grdSales.Font = CType(resources.GetObject("grdSales.Font"), System.Drawing.Font)
        Me.grdSales.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdSales.ImeMode = CType(resources.GetObject("grdSales.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grdSales.Location = CType(resources.GetObject("grdSales.Location"), System.Drawing.Point)
        Me.grdSales.Name = "grdSales"
        Me.grdSales.RightToLeft = CType(resources.GetObject("grdSales.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grdSales.Size = CType(resources.GetObject("grdSales.Size"), System.Drawing.Size)
        Me.grdSales.TabIndex = CType(resources.GetObject("grdSales.TabIndex"), Integer)
        Me.grdSales.Visible = CType(resources.GetObject("grdSales.Visible"), Boolean)
        '
        'lblNoSales
        '
        Me.lblNoSales.AccessibleDescription = resources.GetString("lblNoSales.AccessibleDescription")
        Me.lblNoSales.AccessibleName = resources.GetString("lblNoSales.AccessibleName")
        Me.lblNoSales.Anchor = CType(resources.GetObject("lblNoSales.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblNoSales.AutoSize = CType(resources.GetObject("lblNoSales.AutoSize"), Boolean)
        Me.lblNoSales.Dock = CType(resources.GetObject("lblNoSales.Dock"), System.Windows.Forms.DockStyle)
        Me.lblNoSales.Enabled = CType(resources.GetObject("lblNoSales.Enabled"), Boolean)
        Me.lblNoSales.Font = CType(resources.GetObject("lblNoSales.Font"), System.Drawing.Font)
        Me.lblNoSales.Image = CType(resources.GetObject("lblNoSales.Image"), System.Drawing.Image)
        Me.lblNoSales.ImageAlign = CType(resources.GetObject("lblNoSales.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblNoSales.ImageIndex = CType(resources.GetObject("lblNoSales.ImageIndex"), Integer)
        Me.lblNoSales.ImeMode = CType(resources.GetObject("lblNoSales.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblNoSales.Location = CType(resources.GetObject("lblNoSales.Location"), System.Drawing.Point)
        Me.lblNoSales.Name = "lblNoSales"
        Me.lblNoSales.RightToLeft = CType(resources.GetObject("lblNoSales.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblNoSales.Size = CType(resources.GetObject("lblNoSales.Size"), System.Drawing.Size)
        Me.lblNoSales.TabIndex = CType(resources.GetObject("lblNoSales.TabIndex"), Integer)
        Me.lblNoSales.Text = resources.GetString("lblNoSales.Text")
        Me.lblNoSales.TextAlign = CType(resources.GetObject("lblNoSales.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblNoSales.Visible = CType(resources.GetObject("lblNoSales.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.tabApp})
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
        Me.tabApp.ResumeLayout(False)
        Me.pgeCreateSprocs.ResumeLayout(False)
        Me.pgeNoParams.ResumeLayout(False)
        Me.pgeInputParam.ResumeLayout(False)
        CType(Me.grdProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pgeAllTypes.ResumeLayout(False)
        Me.pgeMSAccess.ResumeLayout(False)
        CType(Me.grdSales, System.ComponentModel.ISupportInitialize).EndInit()
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

    ' This subroutine handles the click event for the Create Report button, found 
    ' on the MS Access tab. This routine uses classes from the System.Data.OleDb 
    ' namespace to connect to the Northwind database found in Microsoft Access and 
    ' execute a stored procedure that takes two input parameters.
    Private Sub btnCreateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateReport.Click

        ' Validate the beginning and end dates entered by the user.
        If Not DatesAreValid() Then
            Exit Sub
        End If

        strConn = ACCESS_CONNECTION_STRING

        ' Initialize variables to objects in the OleDb namespace.
        Dim ocnnNorthwind As New OleDbConnection(strConn)
        Dim ocmd As New OleDbCommand("[Sales By Year]", ocnnNorthwind)
        Dim oda As New OleDbDataAdapter(ocmd)
        ' Create a DataSet to be filled using the OleDbDataAdapter.
        Dim dsSales As New DataSet()

        ' By default the CommandType = Text (i.e., ad hoc SQL statements).
        ocmd.CommandType = CommandType.StoredProcedure

        ' Add the parameters required by the stored procedure and set their values.
        ' These are added using shorthand notation. For longhand, see the 
        ' btnGetProducts_Click event handler.
        With ocmd.Parameters
            .Add(New OleDbParameter("@BeginningDate", OleDbType.Date)).Value = _
                CDate(txtBeginningDate.Text.Trim)
            .Add(New OleDbParameter("@EndingDate", OleDbType.Date)).Value = _
                CDate(txtEndingDate.Text.Trim)
        End With

        Try
            ' Fill the DataSet. Optionally, you could also give the DataTable a 
            ' specific name.
            oda.Fill(dsSales)

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Only bind and show the DataGrid if the DataSet contains results.
        If dsSales.Tables(0).Rows.Count > 0 Then

            ' Bind the DataGrid to the desired table in the DataSet. This
            ' will cause the sales information to display.
            grdSales.DataSource = dsSales.Tables(0)

            ' Continue to set DataGrid properties directly, but only
            ' those that are not covered by DataGridTableStyle properties.
            With grdSales
                .BackColor = Color.GhostWhite
                .BackgroundColor = Color.Lavender
                .BorderStyle = BorderStyle.None
                .CaptionBackColor = Color.RoyalBlue
                .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
                .CaptionForeColor = Color.Bisque
                .CaptionText = "Northwind Sales By Year"
                .Font = New Font("Tahoma", 8.0!)
                .ParentRowsBackColor = Color.Lavender
                .ParentRowsForeColor = Color.MidnightBlue
                ' Clear out all table style objects previously added or an
                ' exception is thrown.
                .TableStyles.Clear()
            End With

            ' Put as much of the formatting as possible here.
            Dim grdTableStyle1 As New DataGridTableStyle()
            With grdTableStyle1
                .AlternatingBackColor = Color.GhostWhite
                .BackColor = Color.GhostWhite
                .ForeColor = Color.MidnightBlue
                .GridLineColor = Color.RoyalBlue
                .HeaderBackColor = Color.MidnightBlue
                .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
                .HeaderForeColor = Color.Lavender
                .SelectionBackColor = Color.Teal
                .SelectionForeColor = Color.PaleGreen
                ' Do not forget to set the MappingName property. 
                ' Without this, the DataGridTableStyle properties
                ' and any associated DataGridColumnStyle objects
                ' will have no effect.
                .MappingName = dsSales.Tables(0).TableName
                .PreferredColumnWidth = 125
                .PreferredRowHeight = 15
            End With

            ' Format each column that you want to appear in the DataGrid.
            ' In most cases, the DataGridTextBoxColumn class is appropriate.
            ' However, you can also use the DataGridBoolColumn class. Both
            ' of these extend the MustInherit DataGridColumnStyle class. Notice
            ' that the column style properties available to you are more limited
            ' than those for the table style. For example, you cannot change
            ' the color of an individual column.
            Dim grdColStyle1 As New DataGridTextBoxColumn()
            With grdColStyle1
                .HeaderText = "Date Shipped"
                .MappingName = "ShippedDate"
                .Width = 100
            End With

            Dim grdColStyle2 As New DataGridTextBoxColumn()
            With grdColStyle2
                .HeaderText = "Order ID"
                .MappingName = "OrderID"
            End With

            Dim grdColStyle3 As New DataGridTextBoxColumn()
            With grdColStyle3
                .HeaderText = "Sub Total"
                .MappingName = "Subtotal"
                .Format = "c"
                .Width = 75
                .ReadOnly = True
            End With

            Dim grdColStyle4 As New DataGridTextBoxColumn()
            With grdColStyle4
                .HeaderText = "Year"
                .MappingName = "Year"
                .Width = 50
            End With

            ' Add the style objects to the table style's collection of 
            ' column styles. Without this the styles do not take effect.        
            grdTableStyle1.GridColumnStyles.AddRange _
                (New DataGridColumnStyle() _
                {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4})
            grdSales.TableStyles.Add(grdTableStyle1)

        Else
            lblNoSales.Visible = True
            grdSales.Visible = False
        End If

    End Sub

    ' This subroutine handles the click event for the Create Sprocs button, found 
    ' on the Create Sprocs tab. This routine uses classes from the 
    ' System.Data.SqlClient namespace to execute SQL statements that drop a stored 
    ' procedure (if it exists) and then create it.
    Private Sub btnCreateSprocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateSprocs.Click

        strConn = SQL_CONNECTION_STRING

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to SQL Server")
        End If

        ' Attempt to connect to the local SQL server instance, or a local
        ' MSDE installation.
        Dim IsConnecting As Boolean = True
        While IsConnecting
            Try

                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim northwindConnection As New SqlConnection(strConn)

                ' DROP "GetCategories":
                ' =====================
                ' This SQL statement drops the stored procedure "GetCategories", 
                ' if it exists.
                Dim strSQL As String = _
                    "IF EXISTS (" & _
                    "SELECT * " & _
                    "FROM northwind.dbo.sysobjects " & _
                    "WHERE Name = 'GetCategories' " & _
                    "AND TYPE = 'p')" & vbCrLf & _
                    "DROP PROCEDURE GetCategories"

                ' A SqlCommand object is used to execute the SQL commands.
                Dim scmd As New SqlCommand(strSQL, northwindConnection)

                Try
                    ' Open the connection and leave it open until last SQL statement
                    ' is executed.
                    northwindConnection.Open()

                    ' Connection successful so break out of the While loop and close 
                    ' the status form.
                    IsConnecting = False
                    DidPreviouslyConnect = True
                    frmStatusMessage.Close()

                    ' Execute the SQL statement using ExecuteNonQuery, which is more 
                    ' efficient when not returning any data.
                    scmd.ExecuteNonQuery()

                Catch expSql As SqlException
                    MessageBox.Show(expSql.ToString, Me.Text, _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                ' CREATE "GetCategories"
                ' This SQL statement creates the stored procedure "GetCategories".
                scmd.CommandText = _
                    "CREATE PROCEDURE GetCategories " & vbCrLf & _
                    "AS " & vbCrLf & _
                    "SELECT CategoryID, CategoryName " & _
                    "FROM Northwind.dbo.Categories"

                Try
                    scmd.ExecuteNonQuery()

                Catch expSql As SqlException
                    MessageBox.Show(expSql.ToString, Me.Text, _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                ' DROP "GetProducts"
                ' This SQL statement drops the stored procedure "GetProducts", 
                ' if it exists.
                scmd.CommandText = _
                    "IF EXISTS (" & _
                    "SELECT * " & _
                    "FROM northwind.dbo.sysobjects " & _
                    "WHERE Name = 'GetProducts' " & _
                    "AND TYPE = 'p')" & vbCrLf & _
                    "DROP PROCEDURE GetProducts"

                Try
                    scmd.ExecuteNonQuery()

                Catch expSql As SqlException
                    MessageBox.Show(expSql.ToString, Me.Text, _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                ' CREATE "GetProducts"
                ' This SQL statement creates the stored procedure "GetProducts".
                scmd.CommandText = _
                    "CREATE PROCEDURE GetProducts " & vbCrLf & _
                    "@CategoryID Int " & vbCrLf & _
                    "AS " & vbCrLf & _
                    "SELECT ProductID, ProductName, UnitPrice, UnitsInStock " & _
                    "FROM Northwind.dbo.Products " & _
                    "WHERE CategoryID = @CategoryID"

                Try
                    scmd.ExecuteNonQuery()

                Catch expSql As SqlException
                    MessageBox.Show(expSql.ToString, Me.Text, _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End Try

                ' DROP "GetProductCountAndAveragePrice"
                ' This SQL statement drops the stored procedure 
                ' "GetProductCountAndAveragePrice", if it exists.
                scmd.CommandText = _
                    "IF EXISTS (" & _
                    "SELECT * " & _
                    "FROM northwind.dbo.sysobjects " & _
                    "WHERE Name = 'GetProductCountAndAveragePrice' " & _
                    "AND TYPE = 'p')" & vbCrLf & _
                    "DROP PROCEDURE GetProductCountAndAveragePrice"

                Try
                    scmd.ExecuteNonQuery()

                Catch expSql As SqlException
                    MessageBox.Show(expSql.ToString, Me.Text, _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try

                ' CREATE "GetProductCountAndAveragePrice":
                ' This SQL statement creates the stored procedure 
                ' "GetProductCountAndAveragePrice".
                scmd.CommandText = _
                    "CREATE PROCEDURE GetProductCountAndAveragePrice " & vbCrLf & _
                    "@CategoryID Int, " & vbCrLf & _
                    "@AveragePrice Int OUT" & vbCrLf & _
                    "AS " & vbCrLf & _
                    "DECLARE @SumProdPrices Money " & vbCrLf & _
                    "SELECT @AveragePrice = SUM(UnitPrice)/COUNT(ProductID) " & _
                    "FROM Northwind.dbo.Products " & _
                    "WHERE CategoryID = @CategoryID" & vbCrLf & _
                    "RETURN " & _
                    "(SELECT COUNT(ProductID) " & _
                    "FROM Northwind.dbo.Products " & _
                    "WHERE CategoryID = @CategoryID)"

                Try
                    scmd.ExecuteNonQuery()

                Catch expSql As SqlException
                    MessageBox.Show(expSql.ToString, Me.Text, _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    ' For the final stored procedure, close the connection, no matter 
                    ' what happens. 
                    northwindConnection.Close()
                End Try

            Catch exp As Exception
                If strConn = SQL_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    strConn = MSDE_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to MSDE")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MessageBox.Show("To run this sample, you must have SQL " & _
                        "or MSDE with the Northwind database installed.  For " & _
                        "instructions on installing MSDE, view the ReadMe file.", _
                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End
                End If
            End Try
        End While

        frmStatusMessage.Close()

        MessageBox.Show("The stored procedures were successfully added to the " & _
            "Northwind database.", Me.Text, MessageBoxButtons.OK, _
            MessageBoxIcon.Information)

        HasCreatedSprocs = True
    End Sub

    ' This subroutine handles the Click event for the Get Product Count and 
    ' Avg Price button, found on the All Types tab. The stored procedure used
    ' here requires a single input parameter and sends back both an output
    ' parameter value as well as a return value. After the sproc is executed a 
    ' Label is used to dislay the results.
    Private Sub btnGetProductCountAndAvgPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetProductCountAndAvgPrice.Click
        strConn = SQL_CONNECTION_STRING

        Dim scnnNorthwind As New SqlConnection(strConn)
        Dim scmd As New SqlCommand("GetProductCountAndAveragePrice", scnnNorthwind)
        Dim sda As New SqlDataAdapter(scmd)
        Dim dsProducts As New DataSet()

        scmd.CommandType = CommandType.StoredProcedure

        ' Add the parameter required by the stored procedure. Set the input
        ' parameter's value to that of the ComboBox control's selected value.
        ' Set the Direction of the output parameter. Finally, add a paramter
        ' to capture the return value, i.e., the value sent back from the 
        ' stored procedure by the RETURN statement (or, if RETURN is not 
        ' explicitly used in the stored procedure, the default success/fail
        ' code returned by SQL Server).
        With scmd.Parameters
            .Add(New SqlParameter("@CategoryID", SqlDbType.Int)).Value = _
                cboCategoriesAllTypes.SelectedValue
            ' By default, the value of the Direction property is "Input",
            ' so only in the next two parameters does Direction need to be
            ' explicitly set.
            .Add(New SqlParameter("@AveragePrice", _
                SqlDbType.Money)).Direction = ParameterDirection.Output
            ' Instead of adding a SqlParameter to obtain the Return value you
            ' can also just declare an integer variable and initialize it to
            ' the value returned by the SqlDataAdapter Fill method, or 
            ' whatever method you are using to execute the SQL statement
            ' (as was done with the CREATE "GetProducts" stored procedure,
            ' above).
            .Add(New SqlParameter("ReturnValue", _
                SqlDbType.Int)).Direction = ParameterDirection.ReturnValue
        End With

        Try
            ' For comments on this line of code see the Try...Catch block
            ' in the frmMain Load event handler.
            sda.Fill(dsProducts, "Products")

        Catch expSQL As SqlException
            MessageBox.Show(expSQL.ToString, Me.Text, _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Display the results.
        lblProductCountAndAvgPrice.Text = "There are " & _
            scmd.Parameters("ReturnValue").Value.ToString & " products " & _
            "in the " & cboCategoriesAllTypes.Text & " category, at an average " & _
            "price of " & CType(scmd.Parameters("@AveragePrice").Value, _
                Double).ToString("c")

    End Sub

    ' This subroutine handles the Click event for the Get Products button,
    ' found on the Input Param tab. The "GetProducts" stored procedure requires
    ' a single input parameter. The sproc is executed and a DataGrid used to
    ' dislay the results.
    Private Sub btnGetProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetProducts.Click

        strConn = SQL_CONNECTION_STRING

        ' For comments on these next three lines see the frmMain
        ' Load event handler.
        Dim scnnNorthwind As New SqlConnection(strConn)
        Dim scmd As New SqlCommand("GetProducts", scnnNorthwind)
        Dim sda As New SqlDataAdapter(scmd)
        Dim dsProducts As New DataSet()

        ' Add the parameter required by the stored procedure. Set the input
        ' parameter's value to that of the ComboBox control's selected value.
        ' The following syntax is the long way of adding a SqlParameter and
        ' setting its properties. Look at btnGetProductCountAndAvgPrice_Click
        ' event handler for a much shorter syntax.
        Dim sparCatID As New SqlParameter()
        With sparCatID
            .ParameterName = "@CategoryID"
            .SqlDbType = SqlDbType.Int
            .Value = cboCategoriesInputParam.SelectedValue
        End With

        With scmd
            .Parameters.Add(sparCatID)
            .CommandType = CommandType.StoredProcedure
        End With

        Try
            ' Fill the DataSet and optionally name the DataTable.
            sda.Fill(dsProducts, "Products")

        Catch expSQL As SqlException
            MessageBox.Show(expSQL.ToString, Me.Text, _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Bind the DataGrid to the desired table in the DataSet. This
        ' will cause the product information to display.
        grdProducts.DataSource = dsProducts.Tables(0)

        ' Continue to set DataGrid properties directly, but only
        ' those that are not covered by DataGridTableStyle properties.
        With grdProducts
            .BackColor = Color.GhostWhite
            .BackgroundColor = Color.Lavender
            .BorderStyle = BorderStyle.None
            .CaptionBackColor = Color.RoyalBlue
            .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
            .CaptionForeColor = Color.Bisque
            .CaptionText = "Northwind Products"
            .Font = New Font("Tahoma", 8.0!)
            .ParentRowsBackColor = Color.Lavender
            .ParentRowsForeColor = Color.MidnightBlue
            ' Clear out all table style objects previously added or an
            ' exception is thrown.
            .TableStyles.Clear()
        End With

        ' Put as much of the formatting as possible here.
        Dim grdTableStyle1 As New DataGridTableStyle()
        With grdTableStyle1
            .AlternatingBackColor = Color.GhostWhite
            .BackColor = Color.GhostWhite
            .ForeColor = Color.MidnightBlue
            .GridLineColor = Color.RoyalBlue
            .HeaderBackColor = Color.MidnightBlue
            .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
            .HeaderForeColor = Color.Lavender
            .SelectionBackColor = Color.Teal
            .SelectionForeColor = Color.PaleGreen
            ' Do not forget to set the MappingName property. 
            ' Without this, the DataGridTableStyle properties
            ' and any associated DataGridColumnStyle objects
            ' will have no effect.
            .MappingName = dsProducts.Tables(0).TableName
            .PreferredColumnWidth = 125
            .PreferredRowHeight = 15
        End With

        ' Format each column that you want to appear in the DataGrid.
        ' In most cases, the DataGridTextBoxColumn class is appropriate.
        ' However, you can also use the DataGridBoolColumn class. Both
        ' of these extend the MustInherit DataGridColumnStyle class. Notice
        ' that the column style properties available to you are more limited
        ' than those for the table style. For example, you cannot change
        ' the color of an individual column.
        Dim grdColStyle1 As New DataGridTextBoxColumn()
        With grdColStyle1
            .HeaderText = "ID"
            .MappingName = "ProductID"
            .Width = 50
        End With

        Dim grdColStyle2 As New DataGridTextBoxColumn()
        With grdColStyle2
            .HeaderText = "Name"
            .MappingName = "ProductName"
        End With

        Dim grdColStyle3 As New DataGridTextBoxColumn()
        With grdColStyle3
            .HeaderText = "Price"
            .MappingName = "UnitPrice"
            .Format = "c"
            .Width = 75
            .ReadOnly = True
        End With

        Dim grdColStyle4 As New DataGridTextBoxColumn()
        With grdColStyle4
            .HeaderText = "# In Stock"
            .MappingName = "UnitsInStock"
            .Width = 75
            .Alignment = HorizontalAlignment.Center
        End With

        ' Add the style objects to the table style's collection of 
        ' column styles. Without this the styles do not take effect.        
        grdTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4})
        grdProducts.TableStyles.Add(grdTableStyle1)

    End Sub

    ' This subroutine handles the Click event for the Top Ten Products button,
    ' found on the No Params tab. The stored procedure used here requires no  
    ' input parameters.
    Private Sub btnGet10MostExpProds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGet10MostExpProds.Click

        Dim scnnNorthwind As New SqlConnection(SQL_CONNECTION_STRING)
        ' The SqlCommand object is responsible for executing SQL statements
        ' and managing the associated SQL objects, like parameters. With ad
        ' hoc SQL you would pass the SQL statement as the first argument to 
        ' the constructor. But when using stored procedures, you simply pass
        ' the name of the stored procedure and set the CommandType property 
        ' to the CommandType.StoredProcedure enum.
        Dim scmd As New SqlCommand("[Ten Most Expensive Products]", scnnNorthwind)
        scmd.CommandType = CommandType.StoredProcedure

        ' Open the connection to the database and execute the command, also passing 
        ' in an enum value that immediately closes the connection. This is an option
        ' to explicitly calling scnnNorthwind.Close().
        scnnNorthwind.Open()
        Dim sdr As SqlDataReader = scmd.ExecuteReader(CommandBehavior.CloseConnection)

        ' Instantiate a StringBuilder to concatenate the strings displayed in the
        ' TextBox. The StringBuilder class is optimized for concatenation and is
        ' to be preferred over the traditional &= approach.
        Dim sb As New StringBuilder()
        sb.Append("Product Name")
        sb.Append(vbTab)
        sb.Append(vbTab)
        sb.Append(vbTab)
        sb.Append("Price")
        sb.Append(vbCrLf)
        sb.Append("========================")
        sb.Append(vbTab)
        sb.Append("==========")
        sb.Append(vbCrLf)

        ' Loop through the contents of the SqlDataReader object.
        While sdr.Read
            sb.Append(sdr.GetString(0))
            sb.Append(vbTab)
            sb.Append(vbTab)
            If sdr.GetString(0).Length < 20 Then
                sb.Append(vbTab)
            End If
            ' To format the string as currency you must first convert it to a type
            ' that implements the IFormattable interface.
            sb.Append(sdr.GetSqlMoney(1).ToDouble.ToString("c"))
            sb.Append(vbCrLf)
        End While

        ' Display the results.
        txtTenMostExpProds.Text = sb.ToString
    End Sub

    ' This subroutine handles the SelectedIndexChanged for the TabControl. 
    ' It ensures that the user cannot run any of the examples prior to creating 
    ' the stored procedures. If the sprocs have been created, the "GetCategories" 
    ' sproc is executed to fill the product Categories ComboBox controls on the 
    ' Input Param and All Types tab pages.
    Private Sub tabApp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabApp.SelectedIndexChanged
        If Not HasCreatedSprocs AndAlso tabApp.SelectedTab.TabIndex > 0 Then
            MessageBox.Show("You must first create the required stored procedures.", _
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            tabApp.SelectedIndex = 0
        ElseIf HasCreatedSprocs AndAlso cboCategoriesInputParam.Items.Count = 0 Then
            ' Fill ComboBox controls only if they are empty and the sprocs have 
            ' been created.
            strConn = SQL_CONNECTION_STRING

            ' See other event handlers for comments about the following
            ' lines of code.
            Dim scnnNorthwind As New SqlConnection(strConn)
            Dim dsCategories As DataSet
            Dim scmd As New SqlCommand("GetCategories", scnnNorthwind)
            Dim sda As New SqlDataAdapter(scmd)

            dsCategories = New DataSet()
            scmd.CommandType = CommandType.StoredProcedure

            Try
                ' Fill the DataSet.
                sda.Fill(dsCategories)

            Catch expSql As SqlException
                MessageBox.Show(expSql.ToString, Me.Text, _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' Bind the data to the ComboBox controls
            With cboCategoriesInputParam
                .DataSource = dsCategories.Tables(0)
                .DisplayMember = "CategoryName"
                .ValueMember = "CategoryID"
            End With

            ' Bind the data to the ComboBox controls
            With cboCategoriesAllTypes
                .DataSource = dsCategories.Tables(0)
                .DisplayMember = "CategoryName"
                .ValueMember = "CategoryID"
            End With
        End If
    End Sub

    ' Validates the dates entered into the TextBox controls on the MS Access tab.
    Private Function DatesAreValid() As Boolean
        Dim objControl As Object
        For Each objControl In pgeMSAccess.Controls
            If objControl.GetType.ToString = "System.Windows.Forms.TextBox" Then
                Dim txt As TextBox = CType(objControl, TextBox)

                If Not IsDate(txt.Text.Trim) Then
                    MessageBox.Show("You must enter a correct date in the form " & _
                        "mm/dd/yyyy.", Me.Text, MessageBoxButtons.OK, _
                        MessageBoxIcon.Error)
                    txt.Focus()
                    txt.SelectAll()
                    Return False
                End If
            End If
        Next

        Return True
    End Function

End Class