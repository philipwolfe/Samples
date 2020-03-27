'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO
Imports System.Net
Imports System.Threading
Imports Microsoft.Uddi

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Const WS_DATA_RETRIEVAL_ERROR As String = _
        "An error occurred trying to retrieve the data from the Web Service." & _
        "The Web service may currently be down. You might attempt to access " & _
        "it directly: "

    Const WS_CONNECTION_STATUS As String = _
        "Contacting the Web Service and retrieving data. Please stand by..."

    ' For the Fallback (UDDI) tab.
    Const SERVICE_KEY As String = "906e9751-6677-454e-ad7c-dca3c6699ccd"

    Protected frmStatus As frmStatus

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
    Friend WithEvents chAmazonPrice As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAmazonRank As System.Windows.Forms.ColumnHeader
    Friend WithEvents chBNPrice As System.Windows.Forms.ColumnHeader
    Friend WithEvents chBNRank As System.Windows.Forms.ColumnHeader
    Friend WithEvents chISBN As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnGetWeather As System.Windows.Forms.Button
    Friend WithEvents pnlWeatherInfo As System.Windows.Forms.Panel
    Friend WithEvents lblconditions As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents lblCurrentTemp As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnConvert As System.Windows.Forms.Button
    Friend WithEvents lblConvertedAmount As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents btnGetTime As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCartoon As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFallbackTime As System.Windows.Forms.Label
    Friend WithEvents btnFallbackTime As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tabWebServices = New System.Windows.Forms.TabControl()
        Me.pgeTime = New System.Windows.Forms.TabPage()
        Me.btnGetTime = New System.Windows.Forms.Button()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtZipCodeForTime = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pgeCurrency = New System.Windows.Forms.TabPage()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.lblConvertedAmount = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.cboConvertTo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pgeBooks = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtISBN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGetBookData = New System.Windows.Forms.Button()
        Me.lvwBooks = New System.Windows.Forms.ListView()
        Me.chISBN = New System.Windows.Forms.ColumnHeader()
        Me.chAmazonPrice = New System.Windows.Forms.ColumnHeader()
        Me.chAmazonRank = New System.Windows.Forms.ColumnHeader()
        Me.chBNPrice = New System.Windows.Forms.ColumnHeader()
        Me.chBNRank = New System.Windows.Forms.ColumnHeader()
        Me.pgeDilbert = New System.Windows.Forms.TabPage()
        Me.btnCartoon = New System.Windows.Forms.Button()
        Me.txtAsyncWaitPeriod = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.picDilbert = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pgeFallback = New System.Windows.Forms.TabPage()
        Me.btnFallbackTime = New System.Windows.Forms.Button()
        Me.lblFallbackTime = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pgeWeather = New System.Windows.Forms.TabPage()
        Me.pnlWeatherInfo = New System.Windows.Forms.Panel()
        Me.lblconditions = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.lblCurrentTemp = New System.Windows.Forms.Label()
        Me.picConditions = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtZipCodeForWeather = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnGetWeather = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabWebServices.SuspendLayout()
        Me.pgeTime.SuspendLayout()
        Me.pgeCurrency.SuspendLayout()
        Me.pgeBooks.SuspendLayout()
        Me.pgeDilbert.SuspendLayout()
        Me.pgeFallback.SuspendLayout()
        Me.pgeWeather.SuspendLayout()
        Me.pnlWeatherInfo.SuspendLayout()
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
        'tabWebServices
        '
        Me.tabWebServices.AccessibleDescription = resources.GetString("tabWebServices.AccessibleDescription")
        Me.tabWebServices.AccessibleName = resources.GetString("tabWebServices.AccessibleName")
        Me.tabWebServices.Alignment = CType(resources.GetObject("tabWebServices.Alignment"), System.Windows.Forms.TabAlignment)
        Me.tabWebServices.Anchor = CType(resources.GetObject("tabWebServices.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tabWebServices.Appearance = CType(resources.GetObject("tabWebServices.Appearance"), System.Windows.Forms.TabAppearance)
        Me.tabWebServices.BackgroundImage = CType(resources.GetObject("tabWebServices.BackgroundImage"), System.Drawing.Image)
        Me.tabWebServices.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeTime, Me.pgeCurrency, Me.pgeBooks, Me.pgeDilbert, Me.pgeWeather, Me.pgeFallback})
        Me.tabWebServices.Dock = CType(resources.GetObject("tabWebServices.Dock"), System.Windows.Forms.DockStyle)
        Me.tabWebServices.Enabled = CType(resources.GetObject("tabWebServices.Enabled"), Boolean)
        Me.tabWebServices.Font = CType(resources.GetObject("tabWebServices.Font"), System.Drawing.Font)
        Me.tabWebServices.ImeMode = CType(resources.GetObject("tabWebServices.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tabWebServices.ItemSize = CType(resources.GetObject("tabWebServices.ItemSize"), System.Drawing.Size)
        Me.tabWebServices.Location = CType(resources.GetObject("tabWebServices.Location"), System.Drawing.Point)
        Me.tabWebServices.Name = "tabWebServices"
        Me.tabWebServices.Padding = CType(resources.GetObject("tabWebServices.Padding"), System.Drawing.Point)
        Me.tabWebServices.RightToLeft = CType(resources.GetObject("tabWebServices.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tabWebServices.SelectedIndex = 0
        Me.tabWebServices.ShowToolTips = CType(resources.GetObject("tabWebServices.ShowToolTips"), Boolean)
        Me.tabWebServices.Size = CType(resources.GetObject("tabWebServices.Size"), System.Drawing.Size)
        Me.tabWebServices.TabIndex = CType(resources.GetObject("tabWebServices.TabIndex"), Integer)
        Me.tabWebServices.Text = resources.GetString("tabWebServices.Text")
        Me.tabWebServices.Visible = CType(resources.GetObject("tabWebServices.Visible"), Boolean)
        '
        'pgeTime
        '
        Me.pgeTime.AccessibleDescription = resources.GetString("pgeTime.AccessibleDescription")
        Me.pgeTime.AccessibleName = resources.GetString("pgeTime.AccessibleName")
        Me.pgeTime.Anchor = CType(resources.GetObject("pgeTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeTime.AutoScroll = CType(resources.GetObject("pgeTime.AutoScroll"), Boolean)
        Me.pgeTime.AutoScrollMargin = CType(resources.GetObject("pgeTime.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeTime.AutoScrollMinSize = CType(resources.GetObject("pgeTime.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeTime.BackgroundImage = CType(resources.GetObject("pgeTime.BackgroundImage"), System.Drawing.Image)
        Me.pgeTime.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGetTime, Me.lblTime, Me.Label18, Me.txtZipCodeForTime, Me.Label17, Me.Label15})
        Me.pgeTime.Dock = CType(resources.GetObject("pgeTime.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeTime.Enabled = CType(resources.GetObject("pgeTime.Enabled"), Boolean)
        Me.pgeTime.Font = CType(resources.GetObject("pgeTime.Font"), System.Drawing.Font)
        Me.pgeTime.ImageIndex = CType(resources.GetObject("pgeTime.ImageIndex"), Integer)
        Me.pgeTime.ImeMode = CType(resources.GetObject("pgeTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeTime.Location = CType(resources.GetObject("pgeTime.Location"), System.Drawing.Point)
        Me.pgeTime.Name = "pgeTime"
        Me.pgeTime.RightToLeft = CType(resources.GetObject("pgeTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeTime.Size = CType(resources.GetObject("pgeTime.Size"), System.Drawing.Size)
        Me.pgeTime.TabIndex = CType(resources.GetObject("pgeTime.TabIndex"), Integer)
        Me.pgeTime.Text = resources.GetString("pgeTime.Text")
        Me.pgeTime.ToolTipText = resources.GetString("pgeTime.ToolTipText")
        Me.pgeTime.Visible = CType(resources.GetObject("pgeTime.Visible"), Boolean)
        '
        'btnGetTime
        '
        Me.btnGetTime.AccessibleDescription = resources.GetString("btnGetTime.AccessibleDescription")
        Me.btnGetTime.AccessibleName = resources.GetString("btnGetTime.AccessibleName")
        Me.btnGetTime.Anchor = CType(resources.GetObject("btnGetTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetTime.BackgroundImage = CType(resources.GetObject("btnGetTime.BackgroundImage"), System.Drawing.Image)
        Me.btnGetTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetTime.Dock = CType(resources.GetObject("btnGetTime.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetTime.Enabled = CType(resources.GetObject("btnGetTime.Enabled"), Boolean)
        Me.btnGetTime.FlatStyle = CType(resources.GetObject("btnGetTime.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetTime.Font = CType(resources.GetObject("btnGetTime.Font"), System.Drawing.Font)
        Me.btnGetTime.Image = CType(resources.GetObject("btnGetTime.Image"), System.Drawing.Image)
        Me.btnGetTime.ImageAlign = CType(resources.GetObject("btnGetTime.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetTime.ImageIndex = CType(resources.GetObject("btnGetTime.ImageIndex"), Integer)
        Me.btnGetTime.ImeMode = CType(resources.GetObject("btnGetTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetTime.Location = CType(resources.GetObject("btnGetTime.Location"), System.Drawing.Point)
        Me.btnGetTime.Name = "btnGetTime"
        Me.btnGetTime.RightToLeft = CType(resources.GetObject("btnGetTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetTime.Size = CType(resources.GetObject("btnGetTime.Size"), System.Drawing.Size)
        Me.btnGetTime.TabIndex = CType(resources.GetObject("btnGetTime.TabIndex"), Integer)
        Me.btnGetTime.Text = resources.GetString("btnGetTime.Text")
        Me.btnGetTime.TextAlign = CType(resources.GetObject("btnGetTime.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetTime.Visible = CType(resources.GetObject("btnGetTime.Visible"), Boolean)
        '
        'lblTime
        '
        Me.lblTime.AccessibleDescription = resources.GetString("lblTime.AccessibleDescription")
        Me.lblTime.AccessibleName = resources.GetString("lblTime.AccessibleName")
        Me.lblTime.Anchor = CType(resources.GetObject("lblTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTime.AutoSize = CType(resources.GetObject("lblTime.AutoSize"), Boolean)
        Me.lblTime.Dock = CType(resources.GetObject("lblTime.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTime.Enabled = CType(resources.GetObject("lblTime.Enabled"), Boolean)
        Me.lblTime.Font = CType(resources.GetObject("lblTime.Font"), System.Drawing.Font)
        Me.lblTime.Image = CType(resources.GetObject("lblTime.Image"), System.Drawing.Image)
        Me.lblTime.ImageAlign = CType(resources.GetObject("lblTime.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTime.ImageIndex = CType(resources.GetObject("lblTime.ImageIndex"), Integer)
        Me.lblTime.ImeMode = CType(resources.GetObject("lblTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTime.Location = CType(resources.GetObject("lblTime.Location"), System.Drawing.Point)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.RightToLeft = CType(resources.GetObject("lblTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTime.Size = CType(resources.GetObject("lblTime.Size"), System.Drawing.Size)
        Me.lblTime.TabIndex = CType(resources.GetObject("lblTime.TabIndex"), Integer)
        Me.lblTime.Text = resources.GetString("lblTime.Text")
        Me.lblTime.TextAlign = CType(resources.GetObject("lblTime.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTime.Visible = CType(resources.GetObject("lblTime.Visible"), Boolean)
        '
        'Label18
        '
        Me.Label18.AccessibleDescription = resources.GetString("Label18.AccessibleDescription")
        Me.Label18.AccessibleName = resources.GetString("Label18.AccessibleName")
        Me.Label18.Anchor = CType(resources.GetObject("Label18.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = CType(resources.GetObject("Label18.AutoSize"), Boolean)
        Me.Label18.Dock = CType(resources.GetObject("Label18.Dock"), System.Windows.Forms.DockStyle)
        Me.Label18.Enabled = CType(resources.GetObject("Label18.Enabled"), Boolean)
        Me.Label18.Font = CType(resources.GetObject("Label18.Font"), System.Drawing.Font)
        Me.Label18.Image = CType(resources.GetObject("Label18.Image"), System.Drawing.Image)
        Me.Label18.ImageAlign = CType(resources.GetObject("Label18.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label18.ImageIndex = CType(resources.GetObject("Label18.ImageIndex"), Integer)
        Me.Label18.ImeMode = CType(resources.GetObject("Label18.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label18.Location = CType(resources.GetObject("Label18.Location"), System.Drawing.Point)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = CType(resources.GetObject("Label18.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label18.Size = CType(resources.GetObject("Label18.Size"), System.Drawing.Size)
        Me.Label18.TabIndex = CType(resources.GetObject("Label18.TabIndex"), Integer)
        Me.Label18.Text = resources.GetString("Label18.Text")
        Me.Label18.TextAlign = CType(resources.GetObject("Label18.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label18.Visible = CType(resources.GetObject("Label18.Visible"), Boolean)
        '
        'txtZipCodeForTime
        '
        Me.txtZipCodeForTime.AccessibleDescription = resources.GetString("txtZipCodeForTime.AccessibleDescription")
        Me.txtZipCodeForTime.AccessibleName = resources.GetString("txtZipCodeForTime.AccessibleName")
        Me.txtZipCodeForTime.Anchor = CType(resources.GetObject("txtZipCodeForTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtZipCodeForTime.AutoSize = CType(resources.GetObject("txtZipCodeForTime.AutoSize"), Boolean)
        Me.txtZipCodeForTime.BackgroundImage = CType(resources.GetObject("txtZipCodeForTime.BackgroundImage"), System.Drawing.Image)
        Me.txtZipCodeForTime.Dock = CType(resources.GetObject("txtZipCodeForTime.Dock"), System.Windows.Forms.DockStyle)
        Me.txtZipCodeForTime.Enabled = CType(resources.GetObject("txtZipCodeForTime.Enabled"), Boolean)
        Me.txtZipCodeForTime.Font = CType(resources.GetObject("txtZipCodeForTime.Font"), System.Drawing.Font)
        Me.txtZipCodeForTime.ImeMode = CType(resources.GetObject("txtZipCodeForTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtZipCodeForTime.Location = CType(resources.GetObject("txtZipCodeForTime.Location"), System.Drawing.Point)
        Me.txtZipCodeForTime.MaxLength = CType(resources.GetObject("txtZipCodeForTime.MaxLength"), Integer)
        Me.txtZipCodeForTime.Multiline = CType(resources.GetObject("txtZipCodeForTime.Multiline"), Boolean)
        Me.txtZipCodeForTime.Name = "txtZipCodeForTime"
        Me.txtZipCodeForTime.PasswordChar = CType(resources.GetObject("txtZipCodeForTime.PasswordChar"), Char)
        Me.txtZipCodeForTime.RightToLeft = CType(resources.GetObject("txtZipCodeForTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtZipCodeForTime.ScrollBars = CType(resources.GetObject("txtZipCodeForTime.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtZipCodeForTime.Size = CType(resources.GetObject("txtZipCodeForTime.Size"), System.Drawing.Size)
        Me.txtZipCodeForTime.TabIndex = CType(resources.GetObject("txtZipCodeForTime.TabIndex"), Integer)
        Me.txtZipCodeForTime.Text = resources.GetString("txtZipCodeForTime.Text")
        Me.txtZipCodeForTime.TextAlign = CType(resources.GetObject("txtZipCodeForTime.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtZipCodeForTime.Visible = CType(resources.GetObject("txtZipCodeForTime.Visible"), Boolean)
        Me.txtZipCodeForTime.WordWrap = CType(resources.GetObject("txtZipCodeForTime.WordWrap"), Boolean)
        '
        'Label17
        '
        Me.Label17.AccessibleDescription = resources.GetString("Label17.AccessibleDescription")
        Me.Label17.AccessibleName = resources.GetString("Label17.AccessibleName")
        Me.Label17.Anchor = CType(resources.GetObject("Label17.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = CType(resources.GetObject("Label17.AutoSize"), Boolean)
        Me.Label17.Dock = CType(resources.GetObject("Label17.Dock"), System.Windows.Forms.DockStyle)
        Me.Label17.Enabled = CType(resources.GetObject("Label17.Enabled"), Boolean)
        Me.Label17.Font = CType(resources.GetObject("Label17.Font"), System.Drawing.Font)
        Me.Label17.Image = CType(resources.GetObject("Label17.Image"), System.Drawing.Image)
        Me.Label17.ImageAlign = CType(resources.GetObject("Label17.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label17.ImageIndex = CType(resources.GetObject("Label17.ImageIndex"), Integer)
        Me.Label17.ImeMode = CType(resources.GetObject("Label17.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label17.Location = CType(resources.GetObject("Label17.Location"), System.Drawing.Point)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = CType(resources.GetObject("Label17.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label17.Size = CType(resources.GetObject("Label17.Size"), System.Drawing.Size)
        Me.Label17.TabIndex = CType(resources.GetObject("Label17.TabIndex"), Integer)
        Me.Label17.Text = resources.GetString("Label17.Text")
        Me.Label17.TextAlign = CType(resources.GetObject("Label17.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label17.Visible = CType(resources.GetObject("Label17.Visible"), Boolean)
        '
        'Label15
        '
        Me.Label15.AccessibleDescription = resources.GetString("Label15.AccessibleDescription")
        Me.Label15.AccessibleName = resources.GetString("Label15.AccessibleName")
        Me.Label15.Anchor = CType(resources.GetObject("Label15.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = CType(resources.GetObject("Label15.AutoSize"), Boolean)
        Me.Label15.Dock = CType(resources.GetObject("Label15.Dock"), System.Windows.Forms.DockStyle)
        Me.Label15.Enabled = CType(resources.GetObject("Label15.Enabled"), Boolean)
        Me.Label15.Font = CType(resources.GetObject("Label15.Font"), System.Drawing.Font)
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Image = CType(resources.GetObject("Label15.Image"), System.Drawing.Image)
        Me.Label15.ImageAlign = CType(resources.GetObject("Label15.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label15.ImageIndex = CType(resources.GetObject("Label15.ImageIndex"), Integer)
        Me.Label15.ImeMode = CType(resources.GetObject("Label15.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label15.Location = CType(resources.GetObject("Label15.Location"), System.Drawing.Point)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = CType(resources.GetObject("Label15.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label15.Size = CType(resources.GetObject("Label15.Size"), System.Drawing.Size)
        Me.Label15.TabIndex = CType(resources.GetObject("Label15.TabIndex"), Integer)
        Me.Label15.Text = resources.GetString("Label15.Text")
        Me.Label15.TextAlign = CType(resources.GetObject("Label15.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label15.Visible = CType(resources.GetObject("Label15.Visible"), Boolean)
        '
        'pgeCurrency
        '
        Me.pgeCurrency.AccessibleDescription = resources.GetString("pgeCurrency.AccessibleDescription")
        Me.pgeCurrency.AccessibleName = resources.GetString("pgeCurrency.AccessibleName")
        Me.pgeCurrency.Anchor = CType(resources.GetObject("pgeCurrency.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeCurrency.AutoScroll = CType(resources.GetObject("pgeCurrency.AutoScroll"), Boolean)
        Me.pgeCurrency.AutoScrollMargin = CType(resources.GetObject("pgeCurrency.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeCurrency.AutoScrollMinSize = CType(resources.GetObject("pgeCurrency.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeCurrency.BackgroundImage = CType(resources.GetObject("pgeCurrency.BackgroundImage"), System.Drawing.Image)
        Me.pgeCurrency.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnConvert, Me.lblConvertedAmount, Me.Label16, Me.txtAmount, Me.cboConvertTo, Me.Label11, Me.Label13, Me.Label14})
        Me.pgeCurrency.Dock = CType(resources.GetObject("pgeCurrency.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeCurrency.Enabled = CType(resources.GetObject("pgeCurrency.Enabled"), Boolean)
        Me.pgeCurrency.Font = CType(resources.GetObject("pgeCurrency.Font"), System.Drawing.Font)
        Me.pgeCurrency.ImageIndex = CType(resources.GetObject("pgeCurrency.ImageIndex"), Integer)
        Me.pgeCurrency.ImeMode = CType(resources.GetObject("pgeCurrency.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeCurrency.Location = CType(resources.GetObject("pgeCurrency.Location"), System.Drawing.Point)
        Me.pgeCurrency.Name = "pgeCurrency"
        Me.pgeCurrency.RightToLeft = CType(resources.GetObject("pgeCurrency.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeCurrency.Size = CType(resources.GetObject("pgeCurrency.Size"), System.Drawing.Size)
        Me.pgeCurrency.TabIndex = CType(resources.GetObject("pgeCurrency.TabIndex"), Integer)
        Me.pgeCurrency.Text = resources.GetString("pgeCurrency.Text")
        Me.pgeCurrency.ToolTipText = resources.GetString("pgeCurrency.ToolTipText")
        Me.pgeCurrency.Visible = CType(resources.GetObject("pgeCurrency.Visible"), Boolean)
        '
        'btnConvert
        '
        Me.btnConvert.AccessibleDescription = resources.GetString("btnConvert.AccessibleDescription")
        Me.btnConvert.AccessibleName = resources.GetString("btnConvert.AccessibleName")
        Me.btnConvert.Anchor = CType(resources.GetObject("btnConvert.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnConvert.BackgroundImage = CType(resources.GetObject("btnConvert.BackgroundImage"), System.Drawing.Image)
        Me.btnConvert.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConvert.Dock = CType(resources.GetObject("btnConvert.Dock"), System.Windows.Forms.DockStyle)
        Me.btnConvert.Enabled = CType(resources.GetObject("btnConvert.Enabled"), Boolean)
        Me.btnConvert.FlatStyle = CType(resources.GetObject("btnConvert.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnConvert.Font = CType(resources.GetObject("btnConvert.Font"), System.Drawing.Font)
        Me.btnConvert.Image = CType(resources.GetObject("btnConvert.Image"), System.Drawing.Image)
        Me.btnConvert.ImageAlign = CType(resources.GetObject("btnConvert.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnConvert.ImageIndex = CType(resources.GetObject("btnConvert.ImageIndex"), Integer)
        Me.btnConvert.ImeMode = CType(resources.GetObject("btnConvert.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnConvert.Location = CType(resources.GetObject("btnConvert.Location"), System.Drawing.Point)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.RightToLeft = CType(resources.GetObject("btnConvert.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnConvert.Size = CType(resources.GetObject("btnConvert.Size"), System.Drawing.Size)
        Me.btnConvert.TabIndex = CType(resources.GetObject("btnConvert.TabIndex"), Integer)
        Me.btnConvert.Text = resources.GetString("btnConvert.Text")
        Me.btnConvert.TextAlign = CType(resources.GetObject("btnConvert.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnConvert.Visible = CType(resources.GetObject("btnConvert.Visible"), Boolean)
        '
        'lblConvertedAmount
        '
        Me.lblConvertedAmount.AccessibleDescription = resources.GetString("lblConvertedAmount.AccessibleDescription")
        Me.lblConvertedAmount.AccessibleName = resources.GetString("lblConvertedAmount.AccessibleName")
        Me.lblConvertedAmount.Anchor = CType(resources.GetObject("lblConvertedAmount.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblConvertedAmount.AutoSize = CType(resources.GetObject("lblConvertedAmount.AutoSize"), Boolean)
        Me.lblConvertedAmount.Dock = CType(resources.GetObject("lblConvertedAmount.Dock"), System.Windows.Forms.DockStyle)
        Me.lblConvertedAmount.Enabled = CType(resources.GetObject("lblConvertedAmount.Enabled"), Boolean)
        Me.lblConvertedAmount.Font = CType(resources.GetObject("lblConvertedAmount.Font"), System.Drawing.Font)
        Me.lblConvertedAmount.Image = CType(resources.GetObject("lblConvertedAmount.Image"), System.Drawing.Image)
        Me.lblConvertedAmount.ImageAlign = CType(resources.GetObject("lblConvertedAmount.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblConvertedAmount.ImageIndex = CType(resources.GetObject("lblConvertedAmount.ImageIndex"), Integer)
        Me.lblConvertedAmount.ImeMode = CType(resources.GetObject("lblConvertedAmount.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblConvertedAmount.Location = CType(resources.GetObject("lblConvertedAmount.Location"), System.Drawing.Point)
        Me.lblConvertedAmount.Name = "lblConvertedAmount"
        Me.lblConvertedAmount.RightToLeft = CType(resources.GetObject("lblConvertedAmount.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblConvertedAmount.Size = CType(resources.GetObject("lblConvertedAmount.Size"), System.Drawing.Size)
        Me.lblConvertedAmount.TabIndex = CType(resources.GetObject("lblConvertedAmount.TabIndex"), Integer)
        Me.lblConvertedAmount.Text = resources.GetString("lblConvertedAmount.Text")
        Me.lblConvertedAmount.TextAlign = CType(resources.GetObject("lblConvertedAmount.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblConvertedAmount.Visible = CType(resources.GetObject("lblConvertedAmount.Visible"), Boolean)
        '
        'Label16
        '
        Me.Label16.AccessibleDescription = resources.GetString("Label16.AccessibleDescription")
        Me.Label16.AccessibleName = resources.GetString("Label16.AccessibleName")
        Me.Label16.Anchor = CType(resources.GetObject("Label16.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = CType(resources.GetObject("Label16.AutoSize"), Boolean)
        Me.Label16.Dock = CType(resources.GetObject("Label16.Dock"), System.Windows.Forms.DockStyle)
        Me.Label16.Enabled = CType(resources.GetObject("Label16.Enabled"), Boolean)
        Me.Label16.Font = CType(resources.GetObject("Label16.Font"), System.Drawing.Font)
        Me.Label16.Image = CType(resources.GetObject("Label16.Image"), System.Drawing.Image)
        Me.Label16.ImageAlign = CType(resources.GetObject("Label16.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label16.ImageIndex = CType(resources.GetObject("Label16.ImageIndex"), Integer)
        Me.Label16.ImeMode = CType(resources.GetObject("Label16.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label16.Location = CType(resources.GetObject("Label16.Location"), System.Drawing.Point)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = CType(resources.GetObject("Label16.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label16.Size = CType(resources.GetObject("Label16.Size"), System.Drawing.Size)
        Me.Label16.TabIndex = CType(resources.GetObject("Label16.TabIndex"), Integer)
        Me.Label16.Text = resources.GetString("Label16.Text")
        Me.Label16.TextAlign = CType(resources.GetObject("Label16.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label16.Visible = CType(resources.GetObject("Label16.Visible"), Boolean)
        '
        'txtAmount
        '
        Me.txtAmount.AccessibleDescription = resources.GetString("txtAmount.AccessibleDescription")
        Me.txtAmount.AccessibleName = resources.GetString("txtAmount.AccessibleName")
        Me.txtAmount.Anchor = CType(resources.GetObject("txtAmount.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.AutoSize = CType(resources.GetObject("txtAmount.AutoSize"), Boolean)
        Me.txtAmount.BackgroundImage = CType(resources.GetObject("txtAmount.BackgroundImage"), System.Drawing.Image)
        Me.txtAmount.Dock = CType(resources.GetObject("txtAmount.Dock"), System.Windows.Forms.DockStyle)
        Me.txtAmount.Enabled = CType(resources.GetObject("txtAmount.Enabled"), Boolean)
        Me.txtAmount.Font = CType(resources.GetObject("txtAmount.Font"), System.Drawing.Font)
        Me.txtAmount.ImeMode = CType(resources.GetObject("txtAmount.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtAmount.Location = CType(resources.GetObject("txtAmount.Location"), System.Drawing.Point)
        Me.txtAmount.MaxLength = CType(resources.GetObject("txtAmount.MaxLength"), Integer)
        Me.txtAmount.Multiline = CType(resources.GetObject("txtAmount.Multiline"), Boolean)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.PasswordChar = CType(resources.GetObject("txtAmount.PasswordChar"), Char)
        Me.txtAmount.RightToLeft = CType(resources.GetObject("txtAmount.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtAmount.ScrollBars = CType(resources.GetObject("txtAmount.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtAmount.Size = CType(resources.GetObject("txtAmount.Size"), System.Drawing.Size)
        Me.txtAmount.TabIndex = CType(resources.GetObject("txtAmount.TabIndex"), Integer)
        Me.txtAmount.Text = resources.GetString("txtAmount.Text")
        Me.txtAmount.TextAlign = CType(resources.GetObject("txtAmount.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtAmount.Visible = CType(resources.GetObject("txtAmount.Visible"), Boolean)
        Me.txtAmount.WordWrap = CType(resources.GetObject("txtAmount.WordWrap"), Boolean)
        '
        'cboConvertTo
        '
        Me.cboConvertTo.AccessibleDescription = resources.GetString("cboConvertTo.AccessibleDescription")
        Me.cboConvertTo.AccessibleName = resources.GetString("cboConvertTo.AccessibleName")
        Me.cboConvertTo.Anchor = CType(resources.GetObject("cboConvertTo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboConvertTo.BackgroundImage = CType(resources.GetObject("cboConvertTo.BackgroundImage"), System.Drawing.Image)
        Me.cboConvertTo.Dock = CType(resources.GetObject("cboConvertTo.Dock"), System.Windows.Forms.DockStyle)
        Me.cboConvertTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConvertTo.Enabled = CType(resources.GetObject("cboConvertTo.Enabled"), Boolean)
        Me.cboConvertTo.Font = CType(resources.GetObject("cboConvertTo.Font"), System.Drawing.Font)
        Me.cboConvertTo.ImeMode = CType(resources.GetObject("cboConvertTo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboConvertTo.IntegralHeight = CType(resources.GetObject("cboConvertTo.IntegralHeight"), Boolean)
        Me.cboConvertTo.ItemHeight = CType(resources.GetObject("cboConvertTo.ItemHeight"), Integer)
        Me.cboConvertTo.Location = CType(resources.GetObject("cboConvertTo.Location"), System.Drawing.Point)
        Me.cboConvertTo.MaxDropDownItems = CType(resources.GetObject("cboConvertTo.MaxDropDownItems"), Integer)
        Me.cboConvertTo.MaxLength = CType(resources.GetObject("cboConvertTo.MaxLength"), Integer)
        Me.cboConvertTo.Name = "cboConvertTo"
        Me.cboConvertTo.RightToLeft = CType(resources.GetObject("cboConvertTo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboConvertTo.Size = CType(resources.GetObject("cboConvertTo.Size"), System.Drawing.Size)
        Me.cboConvertTo.TabIndex = CType(resources.GetObject("cboConvertTo.TabIndex"), Integer)
        Me.cboConvertTo.Text = resources.GetString("cboConvertTo.Text")
        Me.cboConvertTo.Visible = CType(resources.GetObject("cboConvertTo.Visible"), Boolean)
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
        'Label13
        '
        Me.Label13.AccessibleDescription = resources.GetString("Label13.AccessibleDescription")
        Me.Label13.AccessibleName = resources.GetString("Label13.AccessibleName")
        Me.Label13.Anchor = CType(resources.GetObject("Label13.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = CType(resources.GetObject("Label13.AutoSize"), Boolean)
        Me.Label13.Dock = CType(resources.GetObject("Label13.Dock"), System.Windows.Forms.DockStyle)
        Me.Label13.Enabled = CType(resources.GetObject("Label13.Enabled"), Boolean)
        Me.Label13.Font = CType(resources.GetObject("Label13.Font"), System.Drawing.Font)
        Me.Label13.Image = CType(resources.GetObject("Label13.Image"), System.Drawing.Image)
        Me.Label13.ImageAlign = CType(resources.GetObject("Label13.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label13.ImageIndex = CType(resources.GetObject("Label13.ImageIndex"), Integer)
        Me.Label13.ImeMode = CType(resources.GetObject("Label13.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label13.Location = CType(resources.GetObject("Label13.Location"), System.Drawing.Point)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = CType(resources.GetObject("Label13.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label13.Size = CType(resources.GetObject("Label13.Size"), System.Drawing.Size)
        Me.Label13.TabIndex = CType(resources.GetObject("Label13.TabIndex"), Integer)
        Me.Label13.Text = resources.GetString("Label13.Text")
        Me.Label13.TextAlign = CType(resources.GetObject("Label13.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label13.Visible = CType(resources.GetObject("Label13.Visible"), Boolean)
        '
        'Label14
        '
        Me.Label14.AccessibleDescription = resources.GetString("Label14.AccessibleDescription")
        Me.Label14.AccessibleName = resources.GetString("Label14.AccessibleName")
        Me.Label14.Anchor = CType(resources.GetObject("Label14.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = CType(resources.GetObject("Label14.AutoSize"), Boolean)
        Me.Label14.Dock = CType(resources.GetObject("Label14.Dock"), System.Windows.Forms.DockStyle)
        Me.Label14.Enabled = CType(resources.GetObject("Label14.Enabled"), Boolean)
        Me.Label14.Font = CType(resources.GetObject("Label14.Font"), System.Drawing.Font)
        Me.Label14.Image = CType(resources.GetObject("Label14.Image"), System.Drawing.Image)
        Me.Label14.ImageAlign = CType(resources.GetObject("Label14.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label14.ImageIndex = CType(resources.GetObject("Label14.ImageIndex"), Integer)
        Me.Label14.ImeMode = CType(resources.GetObject("Label14.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label14.Location = CType(resources.GetObject("Label14.Location"), System.Drawing.Point)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = CType(resources.GetObject("Label14.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label14.Size = CType(resources.GetObject("Label14.Size"), System.Drawing.Size)
        Me.Label14.TabIndex = CType(resources.GetObject("Label14.TabIndex"), Integer)
        Me.Label14.Text = resources.GetString("Label14.Text")
        Me.Label14.TextAlign = CType(resources.GetObject("Label14.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label14.Visible = CType(resources.GetObject("Label14.Visible"), Boolean)
        '
        'pgeBooks
        '
        Me.pgeBooks.AccessibleDescription = resources.GetString("pgeBooks.AccessibleDescription")
        Me.pgeBooks.AccessibleName = resources.GetString("pgeBooks.AccessibleName")
        Me.pgeBooks.Anchor = CType(resources.GetObject("pgeBooks.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeBooks.AutoScroll = CType(resources.GetObject("pgeBooks.AutoScroll"), Boolean)
        Me.pgeBooks.AutoScrollMargin = CType(resources.GetObject("pgeBooks.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeBooks.AutoScrollMinSize = CType(resources.GetObject("pgeBooks.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeBooks.BackColor = System.Drawing.SystemColors.Control
        Me.pgeBooks.BackgroundImage = CType(resources.GetObject("pgeBooks.BackgroundImage"), System.Drawing.Image)
        Me.pgeBooks.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.Label3, Me.txtISBN, Me.Label2, Me.btnGetBookData, Me.lvwBooks})
        Me.pgeBooks.Dock = CType(resources.GetObject("pgeBooks.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeBooks.Enabled = CType(resources.GetObject("pgeBooks.Enabled"), Boolean)
        Me.pgeBooks.Font = CType(resources.GetObject("pgeBooks.Font"), System.Drawing.Font)
        Me.pgeBooks.ImageIndex = CType(resources.GetObject("pgeBooks.ImageIndex"), Integer)
        Me.pgeBooks.ImeMode = CType(resources.GetObject("pgeBooks.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeBooks.Location = CType(resources.GetObject("pgeBooks.Location"), System.Drawing.Point)
        Me.pgeBooks.Name = "pgeBooks"
        Me.pgeBooks.RightToLeft = CType(resources.GetObject("pgeBooks.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeBooks.Size = CType(resources.GetObject("pgeBooks.Size"), System.Drawing.Size)
        Me.pgeBooks.TabIndex = CType(resources.GetObject("pgeBooks.TabIndex"), Integer)
        Me.pgeBooks.Text = resources.GetString("pgeBooks.Text")
        Me.pgeBooks.ToolTipText = resources.GetString("pgeBooks.ToolTipText")
        Me.pgeBooks.Visible = CType(resources.GetObject("pgeBooks.Visible"), Boolean)
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
        'Label3
        '
        Me.Label3.AccessibleDescription = resources.GetString("Label3.AccessibleDescription")
        Me.Label3.AccessibleName = resources.GetString("Label3.AccessibleName")
        Me.Label3.Anchor = CType(resources.GetObject("Label3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = CType(resources.GetObject("Label3.AutoSize"), Boolean)
        Me.Label3.Dock = CType(resources.GetObject("Label3.Dock"), System.Windows.Forms.DockStyle)
        Me.Label3.Enabled = CType(resources.GetObject("Label3.Enabled"), Boolean)
        Me.Label3.Font = CType(resources.GetObject("Label3.Font"), System.Drawing.Font)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
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
        'txtISBN
        '
        Me.txtISBN.AccessibleDescription = resources.GetString("txtISBN.AccessibleDescription")
        Me.txtISBN.AccessibleName = resources.GetString("txtISBN.AccessibleName")
        Me.txtISBN.Anchor = CType(resources.GetObject("txtISBN.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtISBN.AutoSize = CType(resources.GetObject("txtISBN.AutoSize"), Boolean)
        Me.txtISBN.BackgroundImage = CType(resources.GetObject("txtISBN.BackgroundImage"), System.Drawing.Image)
        Me.txtISBN.Dock = CType(resources.GetObject("txtISBN.Dock"), System.Windows.Forms.DockStyle)
        Me.txtISBN.Enabled = CType(resources.GetObject("txtISBN.Enabled"), Boolean)
        Me.txtISBN.Font = CType(resources.GetObject("txtISBN.Font"), System.Drawing.Font)
        Me.txtISBN.ImeMode = CType(resources.GetObject("txtISBN.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtISBN.Location = CType(resources.GetObject("txtISBN.Location"), System.Drawing.Point)
        Me.txtISBN.MaxLength = CType(resources.GetObject("txtISBN.MaxLength"), Integer)
        Me.txtISBN.Multiline = CType(resources.GetObject("txtISBN.Multiline"), Boolean)
        Me.txtISBN.Name = "txtISBN"
        Me.txtISBN.PasswordChar = CType(resources.GetObject("txtISBN.PasswordChar"), Char)
        Me.txtISBN.RightToLeft = CType(resources.GetObject("txtISBN.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtISBN.ScrollBars = CType(resources.GetObject("txtISBN.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtISBN.Size = CType(resources.GetObject("txtISBN.Size"), System.Drawing.Size)
        Me.txtISBN.TabIndex = CType(resources.GetObject("txtISBN.TabIndex"), Integer)
        Me.txtISBN.Text = resources.GetString("txtISBN.Text")
        Me.txtISBN.TextAlign = CType(resources.GetObject("txtISBN.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtISBN.Visible = CType(resources.GetObject("txtISBN.Visible"), Boolean)
        Me.txtISBN.WordWrap = CType(resources.GetObject("txtISBN.WordWrap"), Boolean)
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
        'btnGetBookData
        '
        Me.btnGetBookData.AccessibleDescription = resources.GetString("btnGetBookData.AccessibleDescription")
        Me.btnGetBookData.AccessibleName = resources.GetString("btnGetBookData.AccessibleName")
        Me.btnGetBookData.Anchor = CType(resources.GetObject("btnGetBookData.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetBookData.BackColor = System.Drawing.SystemColors.Control
        Me.btnGetBookData.BackgroundImage = CType(resources.GetObject("btnGetBookData.BackgroundImage"), System.Drawing.Image)
        Me.btnGetBookData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetBookData.Dock = CType(resources.GetObject("btnGetBookData.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetBookData.Enabled = CType(resources.GetObject("btnGetBookData.Enabled"), Boolean)
        Me.btnGetBookData.FlatStyle = CType(resources.GetObject("btnGetBookData.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetBookData.Font = CType(resources.GetObject("btnGetBookData.Font"), System.Drawing.Font)
        Me.btnGetBookData.Image = CType(resources.GetObject("btnGetBookData.Image"), System.Drawing.Image)
        Me.btnGetBookData.ImageAlign = CType(resources.GetObject("btnGetBookData.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetBookData.ImageIndex = CType(resources.GetObject("btnGetBookData.ImageIndex"), Integer)
        Me.btnGetBookData.ImeMode = CType(resources.GetObject("btnGetBookData.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetBookData.Location = CType(resources.GetObject("btnGetBookData.Location"), System.Drawing.Point)
        Me.btnGetBookData.Name = "btnGetBookData"
        Me.btnGetBookData.RightToLeft = CType(resources.GetObject("btnGetBookData.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetBookData.Size = CType(resources.GetObject("btnGetBookData.Size"), System.Drawing.Size)
        Me.btnGetBookData.TabIndex = CType(resources.GetObject("btnGetBookData.TabIndex"), Integer)
        Me.btnGetBookData.Text = resources.GetString("btnGetBookData.Text")
        Me.btnGetBookData.TextAlign = CType(resources.GetObject("btnGetBookData.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetBookData.Visible = CType(resources.GetObject("btnGetBookData.Visible"), Boolean)
        '
        'lvwBooks
        '
        Me.lvwBooks.AccessibleDescription = resources.GetString("lvwBooks.AccessibleDescription")
        Me.lvwBooks.AccessibleName = resources.GetString("lvwBooks.AccessibleName")
        Me.lvwBooks.Alignment = CType(resources.GetObject("lvwBooks.Alignment"), System.Windows.Forms.ListViewAlignment)
        Me.lvwBooks.Anchor = CType(resources.GetObject("lvwBooks.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lvwBooks.BackgroundImage = CType(resources.GetObject("lvwBooks.BackgroundImage"), System.Drawing.Image)
        Me.lvwBooks.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chISBN, Me.chAmazonPrice, Me.chAmazonRank, Me.chBNPrice, Me.chBNRank})
        Me.lvwBooks.Dock = CType(resources.GetObject("lvwBooks.Dock"), System.Windows.Forms.DockStyle)
        Me.lvwBooks.Enabled = CType(resources.GetObject("lvwBooks.Enabled"), Boolean)
        Me.lvwBooks.Font = CType(resources.GetObject("lvwBooks.Font"), System.Drawing.Font)
        Me.lvwBooks.FullRowSelect = True
        Me.lvwBooks.GridLines = True
        Me.lvwBooks.ImeMode = CType(resources.GetObject("lvwBooks.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lvwBooks.LabelWrap = CType(resources.GetObject("lvwBooks.LabelWrap"), Boolean)
        Me.lvwBooks.Location = CType(resources.GetObject("lvwBooks.Location"), System.Drawing.Point)
        Me.lvwBooks.Name = "lvwBooks"
        Me.lvwBooks.RightToLeft = CType(resources.GetObject("lvwBooks.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lvwBooks.Size = CType(resources.GetObject("lvwBooks.Size"), System.Drawing.Size)
        Me.lvwBooks.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvwBooks.TabIndex = CType(resources.GetObject("lvwBooks.TabIndex"), Integer)
        Me.lvwBooks.Text = resources.GetString("lvwBooks.Text")
        Me.lvwBooks.View = System.Windows.Forms.View.Details
        Me.lvwBooks.Visible = CType(resources.GetObject("lvwBooks.Visible"), Boolean)
        '
        'chISBN
        '
        Me.chISBN.Text = resources.GetString("chISBN.Text")
        Me.chISBN.TextAlign = CType(resources.GetObject("chISBN.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.chISBN.Width = CType(resources.GetObject("chISBN.Width"), Integer)
        '
        'chAmazonPrice
        '
        Me.chAmazonPrice.Text = resources.GetString("chAmazonPrice.Text")
        Me.chAmazonPrice.TextAlign = CType(resources.GetObject("chAmazonPrice.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.chAmazonPrice.Width = CType(resources.GetObject("chAmazonPrice.Width"), Integer)
        '
        'chAmazonRank
        '
        Me.chAmazonRank.Text = resources.GetString("chAmazonRank.Text")
        Me.chAmazonRank.TextAlign = CType(resources.GetObject("chAmazonRank.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.chAmazonRank.Width = CType(resources.GetObject("chAmazonRank.Width"), Integer)
        '
        'chBNPrice
        '
        Me.chBNPrice.Text = resources.GetString("chBNPrice.Text")
        Me.chBNPrice.TextAlign = CType(resources.GetObject("chBNPrice.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.chBNPrice.Width = CType(resources.GetObject("chBNPrice.Width"), Integer)
        '
        'chBNRank
        '
        Me.chBNRank.Text = resources.GetString("chBNRank.Text")
        Me.chBNRank.TextAlign = CType(resources.GetObject("chBNRank.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.chBNRank.Width = CType(resources.GetObject("chBNRank.Width"), Integer)
        '
        'pgeDilbert
        '
        Me.pgeDilbert.AccessibleDescription = resources.GetString("pgeDilbert.AccessibleDescription")
        Me.pgeDilbert.AccessibleName = resources.GetString("pgeDilbert.AccessibleName")
        Me.pgeDilbert.Anchor = CType(resources.GetObject("pgeDilbert.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeDilbert.AutoScroll = CType(resources.GetObject("pgeDilbert.AutoScroll"), Boolean)
        Me.pgeDilbert.AutoScrollMargin = CType(resources.GetObject("pgeDilbert.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeDilbert.AutoScrollMinSize = CType(resources.GetObject("pgeDilbert.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeDilbert.BackColor = System.Drawing.SystemColors.Control
        Me.pgeDilbert.BackgroundImage = CType(resources.GetObject("pgeDilbert.BackgroundImage"), System.Drawing.Image)
        Me.pgeDilbert.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCartoon, Me.txtAsyncWaitPeriod, Me.Label5, Me.picDilbert, Me.Label10})
        Me.pgeDilbert.Dock = CType(resources.GetObject("pgeDilbert.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeDilbert.Enabled = CType(resources.GetObject("pgeDilbert.Enabled"), Boolean)
        Me.pgeDilbert.Font = CType(resources.GetObject("pgeDilbert.Font"), System.Drawing.Font)
        Me.pgeDilbert.ImageIndex = CType(resources.GetObject("pgeDilbert.ImageIndex"), Integer)
        Me.pgeDilbert.ImeMode = CType(resources.GetObject("pgeDilbert.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeDilbert.Location = CType(resources.GetObject("pgeDilbert.Location"), System.Drawing.Point)
        Me.pgeDilbert.Name = "pgeDilbert"
        Me.pgeDilbert.RightToLeft = CType(resources.GetObject("pgeDilbert.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeDilbert.Size = CType(resources.GetObject("pgeDilbert.Size"), System.Drawing.Size)
        Me.pgeDilbert.TabIndex = CType(resources.GetObject("pgeDilbert.TabIndex"), Integer)
        Me.pgeDilbert.Text = resources.GetString("pgeDilbert.Text")
        Me.pgeDilbert.ToolTipText = resources.GetString("pgeDilbert.ToolTipText")
        Me.pgeDilbert.Visible = CType(resources.GetObject("pgeDilbert.Visible"), Boolean)
        '
        'btnCartoon
        '
        Me.btnCartoon.AccessibleDescription = resources.GetString("btnCartoon.AccessibleDescription")
        Me.btnCartoon.AccessibleName = resources.GetString("btnCartoon.AccessibleName")
        Me.btnCartoon.Anchor = CType(resources.GetObject("btnCartoon.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCartoon.BackgroundImage = CType(resources.GetObject("btnCartoon.BackgroundImage"), System.Drawing.Image)
        Me.btnCartoon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCartoon.Dock = CType(resources.GetObject("btnCartoon.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCartoon.Enabled = CType(resources.GetObject("btnCartoon.Enabled"), Boolean)
        Me.btnCartoon.FlatStyle = CType(resources.GetObject("btnCartoon.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCartoon.Font = CType(resources.GetObject("btnCartoon.Font"), System.Drawing.Font)
        Me.btnCartoon.Image = CType(resources.GetObject("btnCartoon.Image"), System.Drawing.Image)
        Me.btnCartoon.ImageAlign = CType(resources.GetObject("btnCartoon.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCartoon.ImageIndex = CType(resources.GetObject("btnCartoon.ImageIndex"), Integer)
        Me.btnCartoon.ImeMode = CType(resources.GetObject("btnCartoon.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCartoon.Location = CType(resources.GetObject("btnCartoon.Location"), System.Drawing.Point)
        Me.btnCartoon.Name = "btnCartoon"
        Me.btnCartoon.RightToLeft = CType(resources.GetObject("btnCartoon.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCartoon.Size = CType(resources.GetObject("btnCartoon.Size"), System.Drawing.Size)
        Me.btnCartoon.TabIndex = CType(resources.GetObject("btnCartoon.TabIndex"), Integer)
        Me.btnCartoon.Text = resources.GetString("btnCartoon.Text")
        Me.btnCartoon.TextAlign = CType(resources.GetObject("btnCartoon.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCartoon.Visible = CType(resources.GetObject("btnCartoon.Visible"), Boolean)
        '
        'txtAsyncWaitPeriod
        '
        Me.txtAsyncWaitPeriod.AccessibleDescription = resources.GetString("txtAsyncWaitPeriod.AccessibleDescription")
        Me.txtAsyncWaitPeriod.AccessibleName = resources.GetString("txtAsyncWaitPeriod.AccessibleName")
        Me.txtAsyncWaitPeriod.Anchor = CType(resources.GetObject("txtAsyncWaitPeriod.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtAsyncWaitPeriod.AutoSize = CType(resources.GetObject("txtAsyncWaitPeriod.AutoSize"), Boolean)
        Me.txtAsyncWaitPeriod.BackgroundImage = CType(resources.GetObject("txtAsyncWaitPeriod.BackgroundImage"), System.Drawing.Image)
        Me.txtAsyncWaitPeriod.Dock = CType(resources.GetObject("txtAsyncWaitPeriod.Dock"), System.Windows.Forms.DockStyle)
        Me.txtAsyncWaitPeriod.Enabled = CType(resources.GetObject("txtAsyncWaitPeriod.Enabled"), Boolean)
        Me.txtAsyncWaitPeriod.Font = CType(resources.GetObject("txtAsyncWaitPeriod.Font"), System.Drawing.Font)
        Me.txtAsyncWaitPeriod.ImeMode = CType(resources.GetObject("txtAsyncWaitPeriod.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtAsyncWaitPeriod.Location = CType(resources.GetObject("txtAsyncWaitPeriod.Location"), System.Drawing.Point)
        Me.txtAsyncWaitPeriod.MaxLength = CType(resources.GetObject("txtAsyncWaitPeriod.MaxLength"), Integer)
        Me.txtAsyncWaitPeriod.Multiline = CType(resources.GetObject("txtAsyncWaitPeriod.Multiline"), Boolean)
        Me.txtAsyncWaitPeriod.Name = "txtAsyncWaitPeriod"
        Me.txtAsyncWaitPeriod.PasswordChar = CType(resources.GetObject("txtAsyncWaitPeriod.PasswordChar"), Char)
        Me.txtAsyncWaitPeriod.RightToLeft = CType(resources.GetObject("txtAsyncWaitPeriod.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtAsyncWaitPeriod.ScrollBars = CType(resources.GetObject("txtAsyncWaitPeriod.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtAsyncWaitPeriod.Size = CType(resources.GetObject("txtAsyncWaitPeriod.Size"), System.Drawing.Size)
        Me.txtAsyncWaitPeriod.TabIndex = CType(resources.GetObject("txtAsyncWaitPeriod.TabIndex"), Integer)
        Me.txtAsyncWaitPeriod.Text = resources.GetString("txtAsyncWaitPeriod.Text")
        Me.txtAsyncWaitPeriod.TextAlign = CType(resources.GetObject("txtAsyncWaitPeriod.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtAsyncWaitPeriod.Visible = CType(resources.GetObject("txtAsyncWaitPeriod.Visible"), Boolean)
        Me.txtAsyncWaitPeriod.WordWrap = CType(resources.GetObject("txtAsyncWaitPeriod.WordWrap"), Boolean)
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
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
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
        'picDilbert
        '
        Me.picDilbert.AccessibleDescription = resources.GetString("picDilbert.AccessibleDescription")
        Me.picDilbert.AccessibleName = resources.GetString("picDilbert.AccessibleName")
        Me.picDilbert.Anchor = CType(resources.GetObject("picDilbert.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.picDilbert.BackColor = System.Drawing.SystemColors.Menu
        Me.picDilbert.BackgroundImage = CType(resources.GetObject("picDilbert.BackgroundImage"), System.Drawing.Image)
        Me.picDilbert.Dock = CType(resources.GetObject("picDilbert.Dock"), System.Windows.Forms.DockStyle)
        Me.picDilbert.Enabled = CType(resources.GetObject("picDilbert.Enabled"), Boolean)
        Me.picDilbert.Font = CType(resources.GetObject("picDilbert.Font"), System.Drawing.Font)
        Me.picDilbert.Image = CType(resources.GetObject("picDilbert.Image"), System.Drawing.Image)
        Me.picDilbert.ImeMode = CType(resources.GetObject("picDilbert.ImeMode"), System.Windows.Forms.ImeMode)
        Me.picDilbert.Location = CType(resources.GetObject("picDilbert.Location"), System.Drawing.Point)
        Me.picDilbert.Name = "picDilbert"
        Me.picDilbert.RightToLeft = CType(resources.GetObject("picDilbert.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.picDilbert.Size = CType(resources.GetObject("picDilbert.Size"), System.Drawing.Size)
        Me.picDilbert.SizeMode = CType(resources.GetObject("picDilbert.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.picDilbert.TabIndex = CType(resources.GetObject("picDilbert.TabIndex"), Integer)
        Me.picDilbert.TabStop = False
        Me.picDilbert.Text = resources.GetString("picDilbert.Text")
        Me.picDilbert.Visible = CType(resources.GetObject("picDilbert.Visible"), Boolean)
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
        'pgeFallback
        '
        Me.pgeFallback.AccessibleDescription = resources.GetString("pgeFallback.AccessibleDescription")
        Me.pgeFallback.AccessibleName = resources.GetString("pgeFallback.AccessibleName")
        Me.pgeFallback.Anchor = CType(resources.GetObject("pgeFallback.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeFallback.AutoScroll = CType(resources.GetObject("pgeFallback.AutoScroll"), Boolean)
        Me.pgeFallback.AutoScrollMargin = CType(resources.GetObject("pgeFallback.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeFallback.AutoScrollMinSize = CType(resources.GetObject("pgeFallback.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeFallback.BackgroundImage = CType(resources.GetObject("pgeFallback.BackgroundImage"), System.Drawing.Image)
        Me.pgeFallback.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnFallbackTime, Me.lblFallbackTime, Me.Label12})
        Me.pgeFallback.Dock = CType(resources.GetObject("pgeFallback.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeFallback.Enabled = CType(resources.GetObject("pgeFallback.Enabled"), Boolean)
        Me.pgeFallback.Font = CType(resources.GetObject("pgeFallback.Font"), System.Drawing.Font)
        Me.pgeFallback.ImageIndex = CType(resources.GetObject("pgeFallback.ImageIndex"), Integer)
        Me.pgeFallback.ImeMode = CType(resources.GetObject("pgeFallback.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeFallback.Location = CType(resources.GetObject("pgeFallback.Location"), System.Drawing.Point)
        Me.pgeFallback.Name = "pgeFallback"
        Me.pgeFallback.RightToLeft = CType(resources.GetObject("pgeFallback.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeFallback.Size = CType(resources.GetObject("pgeFallback.Size"), System.Drawing.Size)
        Me.pgeFallback.TabIndex = CType(resources.GetObject("pgeFallback.TabIndex"), Integer)
        Me.pgeFallback.Text = resources.GetString("pgeFallback.Text")
        Me.pgeFallback.ToolTipText = resources.GetString("pgeFallback.ToolTipText")
        Me.pgeFallback.Visible = CType(resources.GetObject("pgeFallback.Visible"), Boolean)
        '
        'btnFallbackTime
        '
        Me.btnFallbackTime.AccessibleDescription = resources.GetString("btnFallbackTime.AccessibleDescription")
        Me.btnFallbackTime.AccessibleName = resources.GetString("btnFallbackTime.AccessibleName")
        Me.btnFallbackTime.Anchor = CType(resources.GetObject("btnFallbackTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnFallbackTime.BackgroundImage = CType(resources.GetObject("btnFallbackTime.BackgroundImage"), System.Drawing.Image)
        Me.btnFallbackTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFallbackTime.Dock = CType(resources.GetObject("btnFallbackTime.Dock"), System.Windows.Forms.DockStyle)
        Me.btnFallbackTime.Enabled = CType(resources.GetObject("btnFallbackTime.Enabled"), Boolean)
        Me.btnFallbackTime.FlatStyle = CType(resources.GetObject("btnFallbackTime.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnFallbackTime.Font = CType(resources.GetObject("btnFallbackTime.Font"), System.Drawing.Font)
        Me.btnFallbackTime.Image = CType(resources.GetObject("btnFallbackTime.Image"), System.Drawing.Image)
        Me.btnFallbackTime.ImageAlign = CType(resources.GetObject("btnFallbackTime.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnFallbackTime.ImageIndex = CType(resources.GetObject("btnFallbackTime.ImageIndex"), Integer)
        Me.btnFallbackTime.ImeMode = CType(resources.GetObject("btnFallbackTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnFallbackTime.Location = CType(resources.GetObject("btnFallbackTime.Location"), System.Drawing.Point)
        Me.btnFallbackTime.Name = "btnFallbackTime"
        Me.btnFallbackTime.RightToLeft = CType(resources.GetObject("btnFallbackTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnFallbackTime.Size = CType(resources.GetObject("btnFallbackTime.Size"), System.Drawing.Size)
        Me.btnFallbackTime.TabIndex = CType(resources.GetObject("btnFallbackTime.TabIndex"), Integer)
        Me.btnFallbackTime.Text = resources.GetString("btnFallbackTime.Text")
        Me.btnFallbackTime.TextAlign = CType(resources.GetObject("btnFallbackTime.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnFallbackTime.Visible = CType(resources.GetObject("btnFallbackTime.Visible"), Boolean)
        '
        'lblFallbackTime
        '
        Me.lblFallbackTime.AccessibleDescription = resources.GetString("lblFallbackTime.AccessibleDescription")
        Me.lblFallbackTime.AccessibleName = resources.GetString("lblFallbackTime.AccessibleName")
        Me.lblFallbackTime.Anchor = CType(resources.GetObject("lblFallbackTime.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblFallbackTime.AutoSize = CType(resources.GetObject("lblFallbackTime.AutoSize"), Boolean)
        Me.lblFallbackTime.Dock = CType(resources.GetObject("lblFallbackTime.Dock"), System.Windows.Forms.DockStyle)
        Me.lblFallbackTime.Enabled = CType(resources.GetObject("lblFallbackTime.Enabled"), Boolean)
        Me.lblFallbackTime.Font = CType(resources.GetObject("lblFallbackTime.Font"), System.Drawing.Font)
        Me.lblFallbackTime.Image = CType(resources.GetObject("lblFallbackTime.Image"), System.Drawing.Image)
        Me.lblFallbackTime.ImageAlign = CType(resources.GetObject("lblFallbackTime.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblFallbackTime.ImageIndex = CType(resources.GetObject("lblFallbackTime.ImageIndex"), Integer)
        Me.lblFallbackTime.ImeMode = CType(resources.GetObject("lblFallbackTime.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblFallbackTime.Location = CType(resources.GetObject("lblFallbackTime.Location"), System.Drawing.Point)
        Me.lblFallbackTime.Name = "lblFallbackTime"
        Me.lblFallbackTime.RightToLeft = CType(resources.GetObject("lblFallbackTime.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblFallbackTime.Size = CType(resources.GetObject("lblFallbackTime.Size"), System.Drawing.Size)
        Me.lblFallbackTime.TabIndex = CType(resources.GetObject("lblFallbackTime.TabIndex"), Integer)
        Me.lblFallbackTime.Text = resources.GetString("lblFallbackTime.Text")
        Me.lblFallbackTime.TextAlign = CType(resources.GetObject("lblFallbackTime.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblFallbackTime.Visible = CType(resources.GetObject("lblFallbackTime.Visible"), Boolean)
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
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
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
        'pgeWeather
        '
        Me.pgeWeather.AccessibleDescription = resources.GetString("pgeWeather.AccessibleDescription")
        Me.pgeWeather.AccessibleName = resources.GetString("pgeWeather.AccessibleName")
        Me.pgeWeather.Anchor = CType(resources.GetObject("pgeWeather.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pgeWeather.AutoScroll = CType(resources.GetObject("pgeWeather.AutoScroll"), Boolean)
        Me.pgeWeather.AutoScrollMargin = CType(resources.GetObject("pgeWeather.AutoScrollMargin"), System.Drawing.Size)
        Me.pgeWeather.AutoScrollMinSize = CType(resources.GetObject("pgeWeather.AutoScrollMinSize"), System.Drawing.Size)
        Me.pgeWeather.BackgroundImage = CType(resources.GetObject("pgeWeather.BackgroundImage"), System.Drawing.Image)
        Me.pgeWeather.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlWeatherInfo, Me.Label9, Me.txtZipCodeForWeather, Me.Label8, Me.btnGetWeather})
        Me.pgeWeather.Dock = CType(resources.GetObject("pgeWeather.Dock"), System.Windows.Forms.DockStyle)
        Me.pgeWeather.Enabled = CType(resources.GetObject("pgeWeather.Enabled"), Boolean)
        Me.pgeWeather.Font = CType(resources.GetObject("pgeWeather.Font"), System.Drawing.Font)
        Me.pgeWeather.ImageIndex = CType(resources.GetObject("pgeWeather.ImageIndex"), Integer)
        Me.pgeWeather.ImeMode = CType(resources.GetObject("pgeWeather.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pgeWeather.Location = CType(resources.GetObject("pgeWeather.Location"), System.Drawing.Point)
        Me.pgeWeather.Name = "pgeWeather"
        Me.pgeWeather.RightToLeft = CType(resources.GetObject("pgeWeather.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pgeWeather.Size = CType(resources.GetObject("pgeWeather.Size"), System.Drawing.Size)
        Me.pgeWeather.TabIndex = CType(resources.GetObject("pgeWeather.TabIndex"), Integer)
        Me.pgeWeather.Text = resources.GetString("pgeWeather.Text")
        Me.pgeWeather.ToolTipText = resources.GetString("pgeWeather.ToolTipText")
        Me.pgeWeather.Visible = CType(resources.GetObject("pgeWeather.Visible"), Boolean)
        '
        'pnlWeatherInfo
        '
        Me.pnlWeatherInfo.AccessibleDescription = resources.GetString("pnlWeatherInfo.AccessibleDescription")
        Me.pnlWeatherInfo.AccessibleName = resources.GetString("pnlWeatherInfo.AccessibleName")
        Me.pnlWeatherInfo.Anchor = CType(resources.GetObject("pnlWeatherInfo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.pnlWeatherInfo.AutoScroll = CType(resources.GetObject("pnlWeatherInfo.AutoScroll"), Boolean)
        Me.pnlWeatherInfo.AutoScrollMargin = CType(resources.GetObject("pnlWeatherInfo.AutoScrollMargin"), System.Drawing.Size)
        Me.pnlWeatherInfo.AutoScrollMinSize = CType(resources.GetObject("pnlWeatherInfo.AutoScrollMinSize"), System.Drawing.Size)
        Me.pnlWeatherInfo.BackgroundImage = CType(resources.GetObject("pnlWeatherInfo.BackgroundImage"), System.Drawing.Image)
        Me.pnlWeatherInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblconditions, Me.Label6, Me.Label7, Me.lblInfo, Me.lblCurrentTemp, Me.picConditions})
        Me.pnlWeatherInfo.Dock = CType(resources.GetObject("pnlWeatherInfo.Dock"), System.Windows.Forms.DockStyle)
        Me.pnlWeatherInfo.Enabled = CType(resources.GetObject("pnlWeatherInfo.Enabled"), Boolean)
        Me.pnlWeatherInfo.Font = CType(resources.GetObject("pnlWeatherInfo.Font"), System.Drawing.Font)
        Me.pnlWeatherInfo.ImeMode = CType(resources.GetObject("pnlWeatherInfo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.pnlWeatherInfo.Location = CType(resources.GetObject("pnlWeatherInfo.Location"), System.Drawing.Point)
        Me.pnlWeatherInfo.Name = "pnlWeatherInfo"
        Me.pnlWeatherInfo.RightToLeft = CType(resources.GetObject("pnlWeatherInfo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.pnlWeatherInfo.Size = CType(resources.GetObject("pnlWeatherInfo.Size"), System.Drawing.Size)
        Me.pnlWeatherInfo.TabIndex = CType(resources.GetObject("pnlWeatherInfo.TabIndex"), Integer)
        Me.pnlWeatherInfo.Text = resources.GetString("pnlWeatherInfo.Text")
        Me.pnlWeatherInfo.Visible = CType(resources.GetObject("pnlWeatherInfo.Visible"), Boolean)
        '
        'lblconditions
        '
        Me.lblconditions.AccessibleDescription = resources.GetString("lblconditions.AccessibleDescription")
        Me.lblconditions.AccessibleName = resources.GetString("lblconditions.AccessibleName")
        Me.lblconditions.Anchor = CType(resources.GetObject("lblconditions.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblconditions.AutoSize = CType(resources.GetObject("lblconditions.AutoSize"), Boolean)
        Me.lblconditions.Dock = CType(resources.GetObject("lblconditions.Dock"), System.Windows.Forms.DockStyle)
        Me.lblconditions.Enabled = CType(resources.GetObject("lblconditions.Enabled"), Boolean)
        Me.lblconditions.Font = CType(resources.GetObject("lblconditions.Font"), System.Drawing.Font)
        Me.lblconditions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblconditions.Image = CType(resources.GetObject("lblconditions.Image"), System.Drawing.Image)
        Me.lblconditions.ImageAlign = CType(resources.GetObject("lblconditions.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblconditions.ImageIndex = CType(resources.GetObject("lblconditions.ImageIndex"), Integer)
        Me.lblconditions.ImeMode = CType(resources.GetObject("lblconditions.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblconditions.Location = CType(resources.GetObject("lblconditions.Location"), System.Drawing.Point)
        Me.lblconditions.Name = "lblconditions"
        Me.lblconditions.RightToLeft = CType(resources.GetObject("lblconditions.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblconditions.Size = CType(resources.GetObject("lblconditions.Size"), System.Drawing.Size)
        Me.lblconditions.TabIndex = CType(resources.GetObject("lblconditions.TabIndex"), Integer)
        Me.lblconditions.Text = resources.GetString("lblconditions.Text")
        Me.lblconditions.TextAlign = CType(resources.GetObject("lblconditions.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblconditions.Visible = CType(resources.GetObject("lblconditions.Visible"), Boolean)
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
        'lblInfo
        '
        Me.lblInfo.AccessibleDescription = resources.GetString("lblInfo.AccessibleDescription")
        Me.lblInfo.AccessibleName = resources.GetString("lblInfo.AccessibleName")
        Me.lblInfo.Anchor = CType(resources.GetObject("lblInfo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblInfo.AutoSize = CType(resources.GetObject("lblInfo.AutoSize"), Boolean)
        Me.lblInfo.Dock = CType(resources.GetObject("lblInfo.Dock"), System.Windows.Forms.DockStyle)
        Me.lblInfo.Enabled = CType(resources.GetObject("lblInfo.Enabled"), Boolean)
        Me.lblInfo.Font = CType(resources.GetObject("lblInfo.Font"), System.Drawing.Font)
        Me.lblInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInfo.Image = CType(resources.GetObject("lblInfo.Image"), System.Drawing.Image)
        Me.lblInfo.ImageAlign = CType(resources.GetObject("lblInfo.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblInfo.ImageIndex = CType(resources.GetObject("lblInfo.ImageIndex"), Integer)
        Me.lblInfo.ImeMode = CType(resources.GetObject("lblInfo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblInfo.Location = CType(resources.GetObject("lblInfo.Location"), System.Drawing.Point)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.RightToLeft = CType(resources.GetObject("lblInfo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblInfo.Size = CType(resources.GetObject("lblInfo.Size"), System.Drawing.Size)
        Me.lblInfo.TabIndex = CType(resources.GetObject("lblInfo.TabIndex"), Integer)
        Me.lblInfo.Text = resources.GetString("lblInfo.Text")
        Me.lblInfo.TextAlign = CType(resources.GetObject("lblInfo.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblInfo.Visible = CType(resources.GetObject("lblInfo.Visible"), Boolean)
        '
        'lblCurrentTemp
        '
        Me.lblCurrentTemp.AccessibleDescription = resources.GetString("lblCurrentTemp.AccessibleDescription")
        Me.lblCurrentTemp.AccessibleName = resources.GetString("lblCurrentTemp.AccessibleName")
        Me.lblCurrentTemp.Anchor = CType(resources.GetObject("lblCurrentTemp.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentTemp.AutoSize = CType(resources.GetObject("lblCurrentTemp.AutoSize"), Boolean)
        Me.lblCurrentTemp.Dock = CType(resources.GetObject("lblCurrentTemp.Dock"), System.Windows.Forms.DockStyle)
        Me.lblCurrentTemp.Enabled = CType(resources.GetObject("lblCurrentTemp.Enabled"), Boolean)
        Me.lblCurrentTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCurrentTemp.Font = CType(resources.GetObject("lblCurrentTemp.Font"), System.Drawing.Font)
        Me.lblCurrentTemp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentTemp.Image = CType(resources.GetObject("lblCurrentTemp.Image"), System.Drawing.Image)
        Me.lblCurrentTemp.ImageAlign = CType(resources.GetObject("lblCurrentTemp.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblCurrentTemp.ImageIndex = CType(resources.GetObject("lblCurrentTemp.ImageIndex"), Integer)
        Me.lblCurrentTemp.ImeMode = CType(resources.GetObject("lblCurrentTemp.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblCurrentTemp.Location = CType(resources.GetObject("lblCurrentTemp.Location"), System.Drawing.Point)
        Me.lblCurrentTemp.Name = "lblCurrentTemp"
        Me.lblCurrentTemp.RightToLeft = CType(resources.GetObject("lblCurrentTemp.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblCurrentTemp.Size = CType(resources.GetObject("lblCurrentTemp.Size"), System.Drawing.Size)
        Me.lblCurrentTemp.TabIndex = CType(resources.GetObject("lblCurrentTemp.TabIndex"), Integer)
        Me.lblCurrentTemp.Text = resources.GetString("lblCurrentTemp.Text")
        Me.lblCurrentTemp.TextAlign = CType(resources.GetObject("lblCurrentTemp.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblCurrentTemp.Visible = CType(resources.GetObject("lblCurrentTemp.Visible"), Boolean)
        '
        'picConditions
        '
        Me.picConditions.AccessibleDescription = resources.GetString("picConditions.AccessibleDescription")
        Me.picConditions.AccessibleName = resources.GetString("picConditions.AccessibleName")
        Me.picConditions.Anchor = CType(resources.GetObject("picConditions.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.picConditions.BackColor = System.Drawing.SystemColors.Control
        Me.picConditions.BackgroundImage = CType(resources.GetObject("picConditions.BackgroundImage"), System.Drawing.Image)
        Me.picConditions.Dock = CType(resources.GetObject("picConditions.Dock"), System.Windows.Forms.DockStyle)
        Me.picConditions.Enabled = CType(resources.GetObject("picConditions.Enabled"), Boolean)
        Me.picConditions.Font = CType(resources.GetObject("picConditions.Font"), System.Drawing.Font)
        Me.picConditions.Image = CType(resources.GetObject("picConditions.Image"), System.Drawing.Image)
        Me.picConditions.ImeMode = CType(resources.GetObject("picConditions.ImeMode"), System.Windows.Forms.ImeMode)
        Me.picConditions.Location = CType(resources.GetObject("picConditions.Location"), System.Drawing.Point)
        Me.picConditions.Name = "picConditions"
        Me.picConditions.RightToLeft = CType(resources.GetObject("picConditions.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.picConditions.Size = CType(resources.GetObject("picConditions.Size"), System.Drawing.Size)
        Me.picConditions.SizeMode = CType(resources.GetObject("picConditions.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.picConditions.TabIndex = CType(resources.GetObject("picConditions.TabIndex"), Integer)
        Me.picConditions.TabStop = False
        Me.picConditions.Text = resources.GetString("picConditions.Text")
        Me.picConditions.Visible = CType(resources.GetObject("picConditions.Visible"), Boolean)
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
        'txtZipCodeForWeather
        '
        Me.txtZipCodeForWeather.AccessibleDescription = resources.GetString("txtZipCodeForWeather.AccessibleDescription")
        Me.txtZipCodeForWeather.AccessibleName = resources.GetString("txtZipCodeForWeather.AccessibleName")
        Me.txtZipCodeForWeather.Anchor = CType(resources.GetObject("txtZipCodeForWeather.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtZipCodeForWeather.AutoSize = CType(resources.GetObject("txtZipCodeForWeather.AutoSize"), Boolean)
        Me.txtZipCodeForWeather.BackgroundImage = CType(resources.GetObject("txtZipCodeForWeather.BackgroundImage"), System.Drawing.Image)
        Me.txtZipCodeForWeather.Dock = CType(resources.GetObject("txtZipCodeForWeather.Dock"), System.Windows.Forms.DockStyle)
        Me.txtZipCodeForWeather.Enabled = CType(resources.GetObject("txtZipCodeForWeather.Enabled"), Boolean)
        Me.txtZipCodeForWeather.Font = CType(resources.GetObject("txtZipCodeForWeather.Font"), System.Drawing.Font)
        Me.txtZipCodeForWeather.ImeMode = CType(resources.GetObject("txtZipCodeForWeather.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtZipCodeForWeather.Location = CType(resources.GetObject("txtZipCodeForWeather.Location"), System.Drawing.Point)
        Me.txtZipCodeForWeather.MaxLength = CType(resources.GetObject("txtZipCodeForWeather.MaxLength"), Integer)
        Me.txtZipCodeForWeather.Multiline = CType(resources.GetObject("txtZipCodeForWeather.Multiline"), Boolean)
        Me.txtZipCodeForWeather.Name = "txtZipCodeForWeather"
        Me.txtZipCodeForWeather.PasswordChar = CType(resources.GetObject("txtZipCodeForWeather.PasswordChar"), Char)
        Me.txtZipCodeForWeather.RightToLeft = CType(resources.GetObject("txtZipCodeForWeather.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtZipCodeForWeather.ScrollBars = CType(resources.GetObject("txtZipCodeForWeather.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtZipCodeForWeather.Size = CType(resources.GetObject("txtZipCodeForWeather.Size"), System.Drawing.Size)
        Me.txtZipCodeForWeather.TabIndex = CType(resources.GetObject("txtZipCodeForWeather.TabIndex"), Integer)
        Me.txtZipCodeForWeather.Text = resources.GetString("txtZipCodeForWeather.Text")
        Me.txtZipCodeForWeather.TextAlign = CType(resources.GetObject("txtZipCodeForWeather.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtZipCodeForWeather.Visible = CType(resources.GetObject("txtZipCodeForWeather.Visible"), Boolean)
        Me.txtZipCodeForWeather.WordWrap = CType(resources.GetObject("txtZipCodeForWeather.WordWrap"), Boolean)
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
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
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
        'btnGetWeather
        '
        Me.btnGetWeather.AccessibleDescription = resources.GetString("btnGetWeather.AccessibleDescription")
        Me.btnGetWeather.AccessibleName = resources.GetString("btnGetWeather.AccessibleName")
        Me.btnGetWeather.Anchor = CType(resources.GetObject("btnGetWeather.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetWeather.BackColor = System.Drawing.SystemColors.Control
        Me.btnGetWeather.BackgroundImage = CType(resources.GetObject("btnGetWeather.BackgroundImage"), System.Drawing.Image)
        Me.btnGetWeather.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetWeather.Dock = CType(resources.GetObject("btnGetWeather.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetWeather.Enabled = CType(resources.GetObject("btnGetWeather.Enabled"), Boolean)
        Me.btnGetWeather.FlatStyle = CType(resources.GetObject("btnGetWeather.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetWeather.Font = CType(resources.GetObject("btnGetWeather.Font"), System.Drawing.Font)
        Me.btnGetWeather.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGetWeather.Image = CType(resources.GetObject("btnGetWeather.Image"), System.Drawing.Image)
        Me.btnGetWeather.ImageAlign = CType(resources.GetObject("btnGetWeather.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetWeather.ImageIndex = CType(resources.GetObject("btnGetWeather.ImageIndex"), Integer)
        Me.btnGetWeather.ImeMode = CType(resources.GetObject("btnGetWeather.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetWeather.Location = CType(resources.GetObject("btnGetWeather.Location"), System.Drawing.Point)
        Me.btnGetWeather.Name = "btnGetWeather"
        Me.btnGetWeather.RightToLeft = CType(resources.GetObject("btnGetWeather.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetWeather.Size = CType(resources.GetObject("btnGetWeather.Size"), System.Drawing.Size)
        Me.btnGetWeather.TabIndex = CType(resources.GetObject("btnGetWeather.TabIndex"), Integer)
        Me.btnGetWeather.Text = resources.GetString("btnGetWeather.Text")
        Me.btnGetWeather.TextAlign = CType(resources.GetObject("btnGetWeather.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetWeather.Visible = CType(resources.GetObject("btnGetWeather.Visible"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription")
        Me.Label1.AccessibleName = resources.GetString("Label1.AccessibleName")
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.tabWebServices})
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
        Me.tabWebServices.ResumeLayout(False)
        Me.pgeTime.ResumeLayout(False)
        Me.pgeCurrency.ResumeLayout(False)
        Me.pgeBooks.ResumeLayout(False)
        Me.pgeDilbert.ResumeLayout(False)
        Me.pgeFallback.ResumeLayout(False)
        Me.pgeWeather.ResumeLayout(False)
        Me.pnlWeatherInfo.ResumeLayout(False)
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

    ' Uses classes that inherit WebRequest to retrieve a response stream
    ' containing an image that is used to generate a Bitmap for the Weather
    ' Web service current conditions PictureBox.
    Private Function GetImage(ByVal url As String) As System.Drawing.Image
        Dim httpRequest As HttpWebRequest
        Dim httpResponse As HttpWebResponse

        ' Create the request using the WebRequestFactory.
        httpRequest = CType(WebRequest.Create(url), HttpWebRequest)
        With httpRequest
            .UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0b; Windows NT 5.1)"
            .Method = "GET"
            .Timeout = 10000
        End With

        Try
            ' Get the response stream and return a Bitmap generated from it.
            httpResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
            Return New Bitmap(httpResponse.GetResponseStream())
        Catch exp As Exception
            MessageBox.Show("An error occurred trying to retrieve the weather " & _
                "conditions picture.", "Web Service Demo Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            httpResponse.Close()
        End Try
    End Function

    ' Retrieves a Url from the Microsoft UDDI service.
    Public Function GetUrlFromUDDI() As String

        Dim strNewUrl As String = ""

        'Use the live UDDI registry.
        Inquire.Url = "http://uddi.microsoft.com/inquire"

        Try
            Dim gsd As New GetServiceDetail()
            gsd.ServiceKeys.Add(SERVICE_KEY)

            ' Call UDDI and get the service details.
            Dim sd As ServiceDetail = gsd.Send()

            ' Return the returned URL, simulating an updated URL for the Alethea
            ' Local Time Web service.
            strNewUrl = sd.BusinessServices.Item(0).BindingTemplates.Item(0).AccessPoint.Text
            Return strNewUrl

        Catch ex As Exception
            MessageBox.Show("Unable to retrieve an updated Url for the " & _
                "Web Service. Please try again later.", _
                "Web Service UDDI Demo Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return strNewUrl
        End Try
    End Function

    ' Calls the EuroConvert Web service to get a DataSet of all the possible
    ' currencies that can be converted from the Euro dollar. The DataSet is then
    ' bound to a ComboBox for use on the Currency tab.
    Private Sub LoadCurrencyConverterComboBox()
        ' Create and fill a DataSet from an XML document.
        Dim dsCountries As New DataSet()

        Try
            dsCountries.ReadXml("..\ecc_countries.xml")
        Catch exp As Exception
            MessageBox.Show("Error loading DataSet from XML: " & _
                exp.Message, _
                "Web Service Demo Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Bind the DataSet to the ComboBox for display.
        With cboConvertTo
            .DataSource = dsCountries.Tables(0)
            .DisplayMember = "Description"
            .ValueMember = "Currency"
        End With
    End Sub

#Region " PersistCurrencyConverterCountriesToXML "
    ' Loads a DataSet from an XML file that contains the ECC-member nations and then
    ' binds the DataSet to a ComboBox for display. This is for use on the Currency
    ' tab.
    Sub PersistCurrencyConverterCountriesToXML()
        ' Display status text and appropriate cursor. Make sure you call DoEvents()
        ' or this code will not run until the entire Click event is processed, at 
        ' which point it will not matter (nor will it even be visible).
        ShowStatusIndicators("Connecting to the Euro Converter Web Service to " & _
            "download the Euro conversion currencies. Please stand by...")

        ' Create an instance of the Web service proxy class and a DataSet.
        Dim wsEuroConverter As New XML_WebServices.EuroConvert()
        Dim dsCountries As DataSet

        Try
            ' Retrieve the countries from the Web service and persist to XML.
            dsCountries = wsEuroConverter.CurrenciesToDataSet
            ' The file is written to the solution's root, one up from the bin 
            ' folder.
            dsCountries.WriteXml("..\ecc_countries.xml")
        Catch exp As Exception
            MessageBox.Show("Error retrieving Euro currencies." & _
                wsEuroConverter.Url, _
                "Web Service Demo Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            ' Reset the status indicators, no matter what happens.
            ResetStatusIndicators()
        End Try
    End Sub
#End Region

    ' Turns off the status indicators activated by ShowStatusIndicators().
    Private Sub ResetStatusIndicators()
        ' Reset the status indicators, no matter what happens.
        Me.Cursor = Cursors.Default
        frmStatus.Hide()
    End Sub

    ' Displays various Web service connection and data status indicators for UI 
    ' feedback.
    Private Sub ShowStatusIndicators(ByVal strMessage As String)
        ' Display status text and appropriate cursor. Make sure you call DoEvents()
        ' or this code will not run until the entire Click event is processed, at 
        ' which point it will not matter (nor will it even be visible).
        frmStatus = New frmStatus()
        frmStatus.Show(strMessage)
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
    End Sub

    ' Handles the "Convert" button click event for the Currency tab. This handler 
    ' connects to a Web service, passes in the country that the currency is being
    ' converted from and the country the currency is being converted to, and 
    ' returns the exchange rate. This is then used to calculate the final value.
    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert.Click

        ' Create an instance of the Web service proxy class.
        Dim wsEuroConverter As New XML_WebServices.EuroConvert()

        ShowStatusIndicators(WS_CONNECTION_STATUS)

        ' Retrieve the data from the Web service.
        Try
            lblConvertedAmount.Text = wsEuroConverter.FromEurosToAmount(CLng(txtAmount.Text), cboConvertTo.SelectedValue.ToString).ToString
        Catch exp As Exception
            MessageBox.Show(WS_DATA_RETRIEVAL_ERROR & _
                wsEuroConverter.Url, _
                "Web Service Demo Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            ResetStatusIndicators()
        End Try
    End Sub

    ' Handles the "Get Cartoon!" button click event for the Dilbert tab. 
    ' This handler connects to a Web service asynchronously using the 
    ' AsyncWaitHandle.WaitOne method found in the System.Threading namespace.
    ' The user can enter the number of seconds they are willing to wait for the
    ' cartoon to be retrieved from the Web service.
    Private Sub btnCartoon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCartoon.Click

        If txtAsyncWaitPeriod.Text = "" Then
            MessageBox.Show("You must enter a number of seconds you wish to wait.", _
                "Web Service Demo Information", _
               MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Create an instance of the Web service proxy class.
        Dim wsDailyDilbert As New Esynaps.DailyDilbert()

        ' Display a status form so that the delay caused by accessing the Web 
        ' service is not mistaken as the Form not loading properly or some other
        ' problem.
        ShowStatusIndicators("Connecting to the Daily Dilbert Web Service and " & _
            "downloading today's cartoon. Please stand by...")

        ' Retrieve the data from the Web service. The Web service also exposes a 
        ' method that returns a Url to the image, but using that method here would 
        ' not have been as instructive.
        Dim arrPicture() As Byte
        Try
            ' Call the Web method asynchronously by calling the Begin___ proxy
            ' method.
            Dim result As IAsyncResult = _
                wsDailyDilbert.BeginDailyDilbertImage(Nothing, Nothing)

            ' Wait as many seconds as the user entered in the TextBox.
            result.AsyncWaitHandle.WaitOne _
                (New TimeSpan(0, 0, CInt(txtAsyncWaitPeriod.Text)), False)

            ' If result completed in time, display the cartoon, if not, display
            ' the message.
            If (result.IsCompleted) Then
                ' Load the byte array into a memory stream by calling the End__
                ' async proxy method.
                arrPicture = _
                    CType(wsDailyDilbert.EndDailyDilbertImage(result), Byte())
                Dim ms As New MemoryStream(arrPicture)

                ' Display in the PictureBox control with a simple call to the 
                ' FromStream method.
                With picDilbert
                    .Image = Image.FromStream(ms)
                    .SizeMode = PictureBoxSizeMode.CenterImage
                    .BorderStyle = BorderStyle.Fixed3D
                End With
            Else
                MessageBox.Show("The cartoon was not retrieved in the " & _
                    "time you specified.", "Web Service Demo Information", _
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch exp As Exception
            MessageBox.Show(WS_DATA_RETRIEVAL_ERROR & _
                wsDailyDilbert.Url, _
                "Web Service Demo Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            ' Hide the status form, whether the cartoon is retrieved or an error
            ' occurred.
            ResetStatusIndicators()
        End Try
    End Sub

    ' Handles the "Get Time!" button click event for the Fallback tab. 
    ' This handler simulates connecting to a Web service with a bad Url. It then
    ' implements a "fallback plan" by contacting the UDDI service. It simulates 
    ' getting an updated Url for the Web service and then reconnects to finally
    ' display the time.
    Private Sub btnFallbackTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFallbackTime.Click

        ' Create an instance of the Web service proxy class.
        Dim wsLocalTime As New Alethea.LocalTime()

        ' Change the Web service's Url to point somewhere else in order to simulate
        ' the Web service moving, and thus throwing a WebException when a call to 
        ' the Web method is attempted.
        wsLocalTime.Url = "http://www.alethea.net"

        ShowStatusIndicators(WS_CONNECTION_STATUS)

        Try
            ' Attempt to retrieve the time from the Web service.
            lblFallbackTime.Text = wsLocalTime.LocalTimeByZipCode(txtZipCodeForTime.Text)

        Catch expWeb As System.Net.WebException

            ResetStatusIndicators()
            ShowStatusIndicators("Could not call Web service. Attempting to " & _
                "retrieve current Web Service location from UDDI. " & _
                "Please stand by...")

            Dim strNewUrl As String = GetUrlFromUDDI()

            If strNewUrl.Length > 0 Then

                ResetStatusIndicators()
                ShowStatusIndicators("Updated Url retrieved from UDDI. " & _
                    "Reattempting contact...")

                ' For demo purposes only, create an instance of the proxy class for
                ' the Web service at the address returned by UDDI. If this was just
                ' an address change for the Alethea Web service then all you would
                ' need to do is type wsLocalTime.Url = strNewUrl and call the Web
                ' method again. In this case, however, you call an entirely 
                ' different to get some time value.
                Dim wsNewLocalTime As New VBWS.ServerTime()

                Try
                    ' Attempt to retrieve the time from the Web service at
                    ' the address provided by UDDI.
                    lblFallbackTime.Text = wsNewLocalTime.GetTime.ToString

                Catch exp As Exception
                    MessageBox.Show(WS_DATA_RETRIEVAL_ERROR & _
                        wsNewLocalTime.Url, _
                        "Web Service Demo Error", _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    ' Reset the status indicators, no matter what happens.
                    ResetStatusIndicators()
                End Try
            End If
        Finally
            ' Reset the status indicators, no matter what happens.
            ResetStatusIndicators()
        End Try
    End Sub

    ' Handles "Get Data" button click event for the Books tab. This handler connects
    ' to the SalesRankNPrice Web service and downloads Amazon and Barnes & Noble 
    ' sales ranking and price for a given book by ISBN number.
    Private Sub btnGetBookData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBookData.Click

        ' Create an instance of the Web service proxy class and the All class, also
        ' provided by the Web service as a convenient type for holding the data
        ' returned by the GetAll method.
        Dim wsSalesRankNPrice As New PerfectXML.SalesRankNPrice()
        Dim strBookData As PerfectXML.All

        ShowStatusIndicators(WS_CONNECTION_STATUS)

        ' Retrieve the data from the Web service.
        Try
            strBookData = wsSalesRankNPrice.GetAll(txtISBN.Text)
        Catch exp As Exception
            MessageBox.Show(WS_DATA_RETRIEVAL_ERROR & _
                wsSalesRankNPrice.Url, _
                "Web Service Demo Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            ' Reset the status indicators, no matter what happens.
            ResetStatusIndicators()
        End Try

        ' Create a ListViewItem object and set the first column's text.
        Dim lvItem As New ListViewItem()
        lvItem.Text = txtISBN.Text

        ' Set the text in the remaining columns and add the ListViewItem object
        ' to the ListView.
        With lvItem.SubItems
            .Add(strBookData.AmazonPrice)
            .Add(strBookData.AmazonSalesRank)
            .Add(strBookData.BNPrice)
            .Add(strBookData.BNSalesRank)
        End With
        lvwBooks.Items.Add(lvItem)
    End Sub

    ' Handles "Get Time" button click event for the Local Time tab. This handler 
    ' connects to the Local Time Web service and downloads the date and time for a 
    ' given zip code. It's a good example of a very easy Web service to implement. 
    ' Like many Web services, you could consume this Web service with only two lines 
    ' of code:
    ' 
    '   Dim wsLocalTime As New Alethea.LocalTime()
    '   lblTime.Text = wsLocalTime.LocalTimeByZipCode(txtZipCodeForTime.Text)
    '
    ' However, the code that follows is in keeping with the rest of the event handlers, 
    ' providing structured error handling and user interface feedback.
    Private Sub btnGetTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTime.Click

        ' Create an instance of the Web service proxy class.
        Dim wsLocalTime As New Alethea.LocalTime()

        ShowStatusIndicators(WS_CONNECTION_STATUS)

        Try
            ' Retrieve the time from the Web service.
            lblTime.Text = wsLocalTime.LocalTimeByZipCode(txtZipCodeForTime.Text)
        Catch exp As Exception
            MessageBox.Show(WS_DATA_RETRIEVAL_ERROR & _
                wsLocalTime.Url, _
                "Web Service Demo Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            ' Reset the status indicators, no matter what happens.
            ResetStatusIndicators()
        End Try
    End Sub

    ' Handles the "Get Weather" button click event for the Weather tab. This handler 
    ' connects to the LearningXMLws Web service and downloads current weather
    ' conditions for a Zip code entered by the user.
    Private Sub btnGetWeather_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetWeather.Click

        ' Hide the weather information until the new data is retrieved.
        pnlWeatherInfo.Visible = False

        ' Create an instance of the Web service proxy class and a custom class
        ' provided by the Web service to hold the returned data.
        Dim wsWeather As New LearnXMLWS.WeatherRetriever()
        Dim weatherData As LearnXMLWS.CurrentWeather

        ShowStatusIndicators(WS_CONNECTION_STATUS)

        Try
            ' Get the weather data from the Web service.
            weatherData = wsWeather.GetWeather(txtZipCodeForWeather.Text)

            ' Display the weather conditions picture in the PictureBox
            ' by calling the custom GetImage function.
            With picConditions
                .Image = GetImage(weatherData.IconUrl)
                .SizeMode = PictureBoxSizeMode.CenterImage
            End With
        Catch exp As Exception
            MessageBox.Show(WS_DATA_RETRIEVAL_ERROR & _
                wsWeather.Url, _
                "Web Service Demo Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            ' Reset the status indicators, no matter what happens.
            ResetStatusIndicators()
        End Try

        ' Display the weather data.
        With weatherData
            lblCurrentTemp.Text = CType(.CurrentTemp, String)
            lblconditions.Text = .Conditions
            lblInfo.Text = " Barometer at " & CType(.Barometer, String) & _
                " and " & .BarometerDirection & vbCrLf & " Humidity at " & _
                CType(.Humidity * 100, String) & "%" & vbCrLf & _
                " Last updated on " & .LastUpdated
        End With

        pnlWeatherInfo.Visible = True
    End Sub

    ' Handles the Form's load event which binds a ComboBox used on the Currency
    ' tab.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This is for the Currency tab. The Currency Convert Web service exposes a
        ' method that returns a DataSet containing a list of all the ECC-member 
        ' nations. As this list does not change frequently, it was persisted to
        ' XML using the following subroutine, which was left in the code for 
        ' instructional purposes and in case you want to generate a new list.
        'PersistCurrencyConverterCountriesToXML()

        ' It's best to preload the ComboBox so there is no delay when the user 
        'accesses the Currency tab.
        LoadCurrencyConverterComboBox()
    End Sub

    Friend WithEvents txtZipCodeForWeather As System.Windows.Forms.TextBox
    Friend WithEvents picConditions As System.Windows.Forms.PictureBox
    Friend WithEvents picDilbert As System.Windows.Forms.PictureBox
    Friend WithEvents txtAsyncWaitPeriod As System.Windows.Forms.TextBox
    Friend WithEvents lvwBooks As System.Windows.Forms.ListView
    Friend WithEvents txtISBN As System.Windows.Forms.TextBox
    Friend WithEvents cboConvertTo As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtZipCodeForTime As System.Windows.Forms.TextBox
    Friend WithEvents pgeWeather As System.Windows.Forms.TabPage
    Friend WithEvents pgeFallback As System.Windows.Forms.TabPage
    Friend WithEvents pgeDilbert As System.Windows.Forms.TabPage
    Friend WithEvents pgeBooks As System.Windows.Forms.TabPage
    Friend WithEvents pgeCurrency As System.Windows.Forms.TabPage
    Friend WithEvents pgeTime As System.Windows.Forms.TabPage
    Friend WithEvents tabWebServices As System.Windows.Forms.TabControl
    Friend WithEvents btnGetBookData As System.Windows.Forms.Button
End Class