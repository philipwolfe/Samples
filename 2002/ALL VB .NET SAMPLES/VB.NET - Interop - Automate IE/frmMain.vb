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
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabActiveX As System.Windows.Forms.TabPage
    Friend WithEvents tabAutomation As System.Windows.Forms.TabPage
    Friend WithEvents btnForward As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse2 As System.Windows.Forms.Button
    Friend WithEvents tbAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents ieForHosting As AxSHDocVw.AxWebBrowser
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkAddressBar As System.Windows.Forms.CheckBox
    Friend WithEvents chkFullScreen As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTop As System.Windows.Forms.TextBox
    Friend WithEvents txtLeft As System.Windows.Forms.TextBox
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents chkMenuBar As System.Windows.Forms.CheckBox
    Friend WithEvents chkResizable As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatusBar As System.Windows.Forms.CheckBox
    Friend WithEvents chkTheaterMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkToolBar As System.Windows.Forms.CheckBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabActiveX = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.ieForHosting = New AxSHDocVw.AxWebBrowser()
        Me.tabAutomation = New System.Windows.Forms.TabPage()
        Me.chkToolBar = New System.Windows.Forms.CheckBox()
        Me.chkTheaterMode = New System.Windows.Forms.CheckBox()
        Me.chkStatusBar = New System.Windows.Forms.CheckBox()
        Me.chkResizable = New System.Windows.Forms.CheckBox()
        Me.chkMenuBar = New System.Windows.Forms.CheckBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.txtTop = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkFullScreen = New System.Windows.Forms.CheckBox()
        Me.chkAddressBar = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBrowse2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbAddress2 = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.tabActiveX.SuspendLayout()
        CType(Me.ieForHosting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAutomation.SuspendLayout()
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = resources.GetString("OpenFileDialog1.Filter")
        Me.OpenFileDialog1.Title = resources.GetString("OpenFileDialog1.Title")
        '
        'TabControl1
        '
        Me.TabControl1.AccessibleDescription = CType(resources.GetObject("TabControl1.AccessibleDescription"), String)
        Me.TabControl1.AccessibleName = CType(resources.GetObject("TabControl1.AccessibleName"), String)
        Me.TabControl1.Alignment = CType(resources.GetObject("TabControl1.Alignment"), System.Windows.Forms.TabAlignment)
        Me.TabControl1.Anchor = CType(resources.GetObject("TabControl1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = CType(resources.GetObject("TabControl1.Appearance"), System.Windows.Forms.TabAppearance)
        Me.TabControl1.BackgroundImage = CType(resources.GetObject("TabControl1.BackgroundImage"), System.Drawing.Image)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabActiveX, Me.tabAutomation})
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
        'tabActiveX
        '
        Me.tabActiveX.AccessibleDescription = CType(resources.GetObject("tabActiveX.AccessibleDescription"), String)
        Me.tabActiveX.AccessibleName = CType(resources.GetObject("tabActiveX.AccessibleName"), String)
        Me.tabActiveX.Anchor = CType(resources.GetObject("tabActiveX.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tabActiveX.AutoScroll = CType(resources.GetObject("tabActiveX.AutoScroll"), Boolean)
        Me.tabActiveX.AutoScrollMargin = CType(resources.GetObject("tabActiveX.AutoScrollMargin"), System.Drawing.Size)
        Me.tabActiveX.AutoScrollMinSize = CType(resources.GetObject("tabActiveX.AutoScrollMinSize"), System.Drawing.Size)
        Me.tabActiveX.BackColor = System.Drawing.SystemColors.Info
        Me.tabActiveX.BackgroundImage = CType(resources.GetObject("tabActiveX.BackgroundImage"), System.Drawing.Image)
        Me.tabActiveX.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.Label6, Me.btnForward, Me.btnBack, Me.btnBrowse, Me.Label1, Me.tbAddress, Me.ieForHosting})
        Me.tabActiveX.Dock = CType(resources.GetObject("tabActiveX.Dock"), System.Windows.Forms.DockStyle)
        Me.tabActiveX.Enabled = CType(resources.GetObject("tabActiveX.Enabled"), Boolean)
        Me.tabActiveX.Font = CType(resources.GetObject("tabActiveX.Font"), System.Drawing.Font)
        Me.tabActiveX.ImageIndex = CType(resources.GetObject("tabActiveX.ImageIndex"), Integer)
        Me.tabActiveX.ImeMode = CType(resources.GetObject("tabActiveX.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tabActiveX.Location = CType(resources.GetObject("tabActiveX.Location"), System.Drawing.Point)
        Me.tabActiveX.Name = "tabActiveX"
        Me.tabActiveX.RightToLeft = CType(resources.GetObject("tabActiveX.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tabActiveX.Size = CType(resources.GetObject("tabActiveX.Size"), System.Drawing.Size)
        Me.tabActiveX.TabIndex = CType(resources.GetObject("tabActiveX.TabIndex"), Integer)
        Me.tabActiveX.Text = resources.GetString("tabActiveX.Text")
        Me.tabActiveX.ToolTipText = resources.GetString("tabActiveX.ToolTipText")
        Me.tabActiveX.Visible = CType(resources.GetObject("tabActiveX.Visible"), Boolean)
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
        'Label6
        '
        Me.Label6.AccessibleDescription = CType(resources.GetObject("Label6.AccessibleDescription"), String)
        Me.Label6.AccessibleName = CType(resources.GetObject("Label6.AccessibleName"), String)
        Me.Label6.Anchor = CType(resources.GetObject("Label6.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = CType(resources.GetObject("Label6.AutoSize"), Boolean)
        Me.Label6.Dock = CType(resources.GetObject("Label6.Dock"), System.Windows.Forms.DockStyle)
        Me.Label6.Enabled = CType(resources.GetObject("Label6.Enabled"), Boolean)
        Me.Label6.Font = CType(resources.GetObject("Label6.Font"), System.Drawing.Font)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
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
        'btnForward
        '
        Me.btnForward.AccessibleDescription = CType(resources.GetObject("btnForward.AccessibleDescription"), String)
        Me.btnForward.AccessibleName = CType(resources.GetObject("btnForward.AccessibleName"), String)
        Me.btnForward.Anchor = CType(resources.GetObject("btnForward.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnForward.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnForward.BackgroundImage = CType(resources.GetObject("btnForward.BackgroundImage"), System.Drawing.Image)
        Me.btnForward.Dock = CType(resources.GetObject("btnForward.Dock"), System.Windows.Forms.DockStyle)
        Me.btnForward.Enabled = CType(resources.GetObject("btnForward.Enabled"), Boolean)
        Me.btnForward.FlatStyle = CType(resources.GetObject("btnForward.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnForward.Font = CType(resources.GetObject("btnForward.Font"), System.Drawing.Font)
        Me.btnForward.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnForward.Image = CType(resources.GetObject("btnForward.Image"), System.Drawing.Image)
        Me.btnForward.ImageAlign = CType(resources.GetObject("btnForward.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnForward.ImageIndex = CType(resources.GetObject("btnForward.ImageIndex"), Integer)
        Me.btnForward.ImeMode = CType(resources.GetObject("btnForward.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnForward.Location = CType(resources.GetObject("btnForward.Location"), System.Drawing.Point)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.RightToLeft = CType(resources.GetObject("btnForward.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnForward.Size = CType(resources.GetObject("btnForward.Size"), System.Drawing.Size)
        Me.btnForward.TabIndex = CType(resources.GetObject("btnForward.TabIndex"), Integer)
        Me.btnForward.Text = resources.GetString("btnForward.Text")
        Me.btnForward.TextAlign = CType(resources.GetObject("btnForward.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnForward.Visible = CType(resources.GetObject("btnForward.Visible"), Boolean)
        '
        'btnBack
        '
        Me.btnBack.AccessibleDescription = CType(resources.GetObject("btnBack.AccessibleDescription"), String)
        Me.btnBack.AccessibleName = CType(resources.GetObject("btnBack.AccessibleName"), String)
        Me.btnBack.Anchor = CType(resources.GetObject("btnBack.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.Dock = CType(resources.GetObject("btnBack.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBack.Enabled = CType(resources.GetObject("btnBack.Enabled"), Boolean)
        Me.btnBack.FlatStyle = CType(resources.GetObject("btnBack.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBack.Font = CType(resources.GetObject("btnBack.Font"), System.Drawing.Font)
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.ImageAlign = CType(resources.GetObject("btnBack.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBack.ImageIndex = CType(resources.GetObject("btnBack.ImageIndex"), Integer)
        Me.btnBack.ImeMode = CType(resources.GetObject("btnBack.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBack.Location = CType(resources.GetObject("btnBack.Location"), System.Drawing.Point)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.RightToLeft = CType(resources.GetObject("btnBack.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBack.Size = CType(resources.GetObject("btnBack.Size"), System.Drawing.Size)
        Me.btnBack.TabIndex = CType(resources.GetObject("btnBack.TabIndex"), Integer)
        Me.btnBack.Text = resources.GetString("btnBack.Text")
        Me.btnBack.TextAlign = CType(resources.GetObject("btnBack.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBack.Visible = CType(resources.GetObject("btnBack.Visible"), Boolean)
        '
        'btnBrowse
        '
        Me.btnBrowse.AccessibleDescription = CType(resources.GetObject("btnBrowse.AccessibleDescription"), String)
        Me.btnBrowse.AccessibleName = CType(resources.GetObject("btnBrowse.AccessibleName"), String)
        Me.btnBrowse.Anchor = CType(resources.GetObject("btnBrowse.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnBrowse.BackgroundImage = CType(resources.GetObject("btnBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse.Dock = CType(resources.GetObject("btnBrowse.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBrowse.Enabled = CType(resources.GetObject("btnBrowse.Enabled"), Boolean)
        Me.btnBrowse.FlatStyle = CType(resources.GetObject("btnBrowse.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBrowse.Font = CType(resources.GetObject("btnBrowse.Font"), System.Drawing.Font)
        Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.ImageAlign = CType(resources.GetObject("btnBrowse.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBrowse.ImageIndex = CType(resources.GetObject("btnBrowse.ImageIndex"), Integer)
        Me.btnBrowse.ImeMode = CType(resources.GetObject("btnBrowse.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBrowse.Location = CType(resources.GetObject("btnBrowse.Location"), System.Drawing.Point)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.RightToLeft = CType(resources.GetObject("btnBrowse.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBrowse.Size = CType(resources.GetObject("btnBrowse.Size"), System.Drawing.Size)
        Me.btnBrowse.TabIndex = CType(resources.GetObject("btnBrowse.TabIndex"), Integer)
        Me.btnBrowse.Text = resources.GetString("btnBrowse.Text")
        Me.btnBrowse.TextAlign = CType(resources.GetObject("btnBrowse.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBrowse.Visible = CType(resources.GetObject("btnBrowse.Visible"), Boolean)
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
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
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
        'tbAddress
        '
        Me.tbAddress.AccessibleDescription = CType(resources.GetObject("tbAddress.AccessibleDescription"), String)
        Me.tbAddress.AccessibleName = CType(resources.GetObject("tbAddress.AccessibleName"), String)
        Me.tbAddress.Anchor = CType(resources.GetObject("tbAddress.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbAddress.AutoSize = CType(resources.GetObject("tbAddress.AutoSize"), Boolean)
        Me.tbAddress.BackgroundImage = CType(resources.GetObject("tbAddress.BackgroundImage"), System.Drawing.Image)
        Me.tbAddress.Dock = CType(resources.GetObject("tbAddress.Dock"), System.Windows.Forms.DockStyle)
        Me.tbAddress.Enabled = CType(resources.GetObject("tbAddress.Enabled"), Boolean)
        Me.tbAddress.Font = CType(resources.GetObject("tbAddress.Font"), System.Drawing.Font)
        Me.tbAddress.ImeMode = CType(resources.GetObject("tbAddress.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbAddress.Location = CType(resources.GetObject("tbAddress.Location"), System.Drawing.Point)
        Me.tbAddress.MaxLength = CType(resources.GetObject("tbAddress.MaxLength"), Integer)
        Me.tbAddress.Multiline = CType(resources.GetObject("tbAddress.Multiline"), Boolean)
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.PasswordChar = CType(resources.GetObject("tbAddress.PasswordChar"), Char)
        Me.tbAddress.RightToLeft = CType(resources.GetObject("tbAddress.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbAddress.ScrollBars = CType(resources.GetObject("tbAddress.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbAddress.Size = CType(resources.GetObject("tbAddress.Size"), System.Drawing.Size)
        Me.tbAddress.TabIndex = CType(resources.GetObject("tbAddress.TabIndex"), Integer)
        Me.tbAddress.Text = resources.GetString("tbAddress.Text")
        Me.tbAddress.TextAlign = CType(resources.GetObject("tbAddress.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbAddress.Visible = CType(resources.GetObject("tbAddress.Visible"), Boolean)
        Me.tbAddress.WordWrap = CType(resources.GetObject("tbAddress.WordWrap"), Boolean)
        '
        'ieForHosting
        '
        Me.ieForHosting.AccessibleDescription = CType(resources.GetObject("ieForHosting.AccessibleDescription"), String)
        Me.ieForHosting.AccessibleName = CType(resources.GetObject("ieForHosting.AccessibleName"), String)
        Me.ieForHosting.Anchor = CType(resources.GetObject("ieForHosting.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ieForHosting.BackgroundImage = CType(resources.GetObject("ieForHosting.BackgroundImage"), System.Drawing.Image)
        Me.ieForHosting.ContainingControl = Me
        Me.ieForHosting.Dock = CType(resources.GetObject("ieForHosting.Dock"), System.Windows.Forms.DockStyle)
        Me.ieForHosting.Enabled = CType(resources.GetObject("ieForHosting.Enabled"), Boolean)
        Me.ieForHosting.Font = CType(resources.GetObject("ieForHosting.Font"), System.Drawing.Font)
        Me.ieForHosting.ImeMode = CType(resources.GetObject("ieForHosting.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ieForHosting.Location = CType(resources.GetObject("ieForHosting.Location"), System.Drawing.Point)
        Me.ieForHosting.OcxState = CType(resources.GetObject("ieForHosting.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ieForHosting.RightToLeft = CType(resources.GetObject("ieForHosting.RightToLeft"), Boolean)
        Me.ieForHosting.Size = CType(resources.GetObject("ieForHosting.Size"), System.Drawing.Size)
        Me.ieForHosting.TabIndex = CType(resources.GetObject("ieForHosting.TabIndex"), Integer)
        Me.ieForHosting.Text = resources.GetString("ieForHosting.Text")
        Me.ieForHosting.Visible = CType(resources.GetObject("ieForHosting.Visible"), Boolean)
        '
        'tabAutomation
        '
        Me.tabAutomation.AccessibleDescription = CType(resources.GetObject("tabAutomation.AccessibleDescription"), String)
        Me.tabAutomation.AccessibleName = CType(resources.GetObject("tabAutomation.AccessibleName"), String)
        Me.tabAutomation.Anchor = CType(resources.GetObject("tabAutomation.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tabAutomation.AutoScroll = CType(resources.GetObject("tabAutomation.AutoScroll"), Boolean)
        Me.tabAutomation.AutoScrollMargin = CType(resources.GetObject("tabAutomation.AutoScrollMargin"), System.Drawing.Size)
        Me.tabAutomation.AutoScrollMinSize = CType(resources.GetObject("tabAutomation.AutoScrollMinSize"), System.Drawing.Size)
        Me.tabAutomation.BackColor = System.Drawing.SystemColors.Info
        Me.tabAutomation.BackgroundImage = CType(resources.GetObject("tabAutomation.BackgroundImage"), System.Drawing.Image)
        Me.tabAutomation.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkToolBar, Me.chkTheaterMode, Me.chkStatusBar, Me.chkResizable, Me.chkMenuBar, Me.txtWidth, Me.txtHeight, Me.txtLeft, Me.txtTop, Me.Label12, Me.Label11, Me.Label10, Me.Label9, Me.Label8, Me.Label7, Me.chkFullScreen, Me.chkAddressBar, Me.Label4, Me.Label3, Me.btnBrowse2, Me.Label2, Me.tbAddress2})
        Me.tabAutomation.Dock = CType(resources.GetObject("tabAutomation.Dock"), System.Windows.Forms.DockStyle)
        Me.tabAutomation.Enabled = CType(resources.GetObject("tabAutomation.Enabled"), Boolean)
        Me.tabAutomation.Font = CType(resources.GetObject("tabAutomation.Font"), System.Drawing.Font)
        Me.tabAutomation.ImageIndex = CType(resources.GetObject("tabAutomation.ImageIndex"), Integer)
        Me.tabAutomation.ImeMode = CType(resources.GetObject("tabAutomation.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tabAutomation.Location = CType(resources.GetObject("tabAutomation.Location"), System.Drawing.Point)
        Me.tabAutomation.Name = "tabAutomation"
        Me.tabAutomation.RightToLeft = CType(resources.GetObject("tabAutomation.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tabAutomation.Size = CType(resources.GetObject("tabAutomation.Size"), System.Drawing.Size)
        Me.tabAutomation.TabIndex = CType(resources.GetObject("tabAutomation.TabIndex"), Integer)
        Me.tabAutomation.Text = resources.GetString("tabAutomation.Text")
        Me.tabAutomation.ToolTipText = resources.GetString("tabAutomation.ToolTipText")
        Me.tabAutomation.Visible = CType(resources.GetObject("tabAutomation.Visible"), Boolean)
        '
        'chkToolBar
        '
        Me.chkToolBar.AccessibleDescription = CType(resources.GetObject("chkToolBar.AccessibleDescription"), String)
        Me.chkToolBar.AccessibleName = CType(resources.GetObject("chkToolBar.AccessibleName"), String)
        Me.chkToolBar.Anchor = CType(resources.GetObject("chkToolBar.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkToolBar.Appearance = CType(resources.GetObject("chkToolBar.Appearance"), System.Windows.Forms.Appearance)
        Me.chkToolBar.BackgroundImage = CType(resources.GetObject("chkToolBar.BackgroundImage"), System.Drawing.Image)
        Me.chkToolBar.CheckAlign = CType(resources.GetObject("chkToolBar.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkToolBar.Dock = CType(resources.GetObject("chkToolBar.Dock"), System.Windows.Forms.DockStyle)
        Me.chkToolBar.Enabled = CType(resources.GetObject("chkToolBar.Enabled"), Boolean)
        Me.chkToolBar.FlatStyle = CType(resources.GetObject("chkToolBar.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkToolBar.Font = CType(resources.GetObject("chkToolBar.Font"), System.Drawing.Font)
        Me.chkToolBar.Image = CType(resources.GetObject("chkToolBar.Image"), System.Drawing.Image)
        Me.chkToolBar.ImageAlign = CType(resources.GetObject("chkToolBar.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkToolBar.ImageIndex = CType(resources.GetObject("chkToolBar.ImageIndex"), Integer)
        Me.chkToolBar.ImeMode = CType(resources.GetObject("chkToolBar.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkToolBar.Location = CType(resources.GetObject("chkToolBar.Location"), System.Drawing.Point)
        Me.chkToolBar.Name = "chkToolBar"
        Me.chkToolBar.RightToLeft = CType(resources.GetObject("chkToolBar.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkToolBar.Size = CType(resources.GetObject("chkToolBar.Size"), System.Drawing.Size)
        Me.chkToolBar.TabIndex = CType(resources.GetObject("chkToolBar.TabIndex"), Integer)
        Me.chkToolBar.Text = resources.GetString("chkToolBar.Text")
        Me.chkToolBar.TextAlign = CType(resources.GetObject("chkToolBar.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkToolBar.Visible = CType(resources.GetObject("chkToolBar.Visible"), Boolean)
        '
        'chkTheaterMode
        '
        Me.chkTheaterMode.AccessibleDescription = CType(resources.GetObject("chkTheaterMode.AccessibleDescription"), String)
        Me.chkTheaterMode.AccessibleName = CType(resources.GetObject("chkTheaterMode.AccessibleName"), String)
        Me.chkTheaterMode.Anchor = CType(resources.GetObject("chkTheaterMode.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkTheaterMode.Appearance = CType(resources.GetObject("chkTheaterMode.Appearance"), System.Windows.Forms.Appearance)
        Me.chkTheaterMode.BackgroundImage = CType(resources.GetObject("chkTheaterMode.BackgroundImage"), System.Drawing.Image)
        Me.chkTheaterMode.CheckAlign = CType(resources.GetObject("chkTheaterMode.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkTheaterMode.Dock = CType(resources.GetObject("chkTheaterMode.Dock"), System.Windows.Forms.DockStyle)
        Me.chkTheaterMode.Enabled = CType(resources.GetObject("chkTheaterMode.Enabled"), Boolean)
        Me.chkTheaterMode.FlatStyle = CType(resources.GetObject("chkTheaterMode.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkTheaterMode.Font = CType(resources.GetObject("chkTheaterMode.Font"), System.Drawing.Font)
        Me.chkTheaterMode.Image = CType(resources.GetObject("chkTheaterMode.Image"), System.Drawing.Image)
        Me.chkTheaterMode.ImageAlign = CType(resources.GetObject("chkTheaterMode.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkTheaterMode.ImageIndex = CType(resources.GetObject("chkTheaterMode.ImageIndex"), Integer)
        Me.chkTheaterMode.ImeMode = CType(resources.GetObject("chkTheaterMode.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkTheaterMode.Location = CType(resources.GetObject("chkTheaterMode.Location"), System.Drawing.Point)
        Me.chkTheaterMode.Name = "chkTheaterMode"
        Me.chkTheaterMode.RightToLeft = CType(resources.GetObject("chkTheaterMode.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkTheaterMode.Size = CType(resources.GetObject("chkTheaterMode.Size"), System.Drawing.Size)
        Me.chkTheaterMode.TabIndex = CType(resources.GetObject("chkTheaterMode.TabIndex"), Integer)
        Me.chkTheaterMode.Text = resources.GetString("chkTheaterMode.Text")
        Me.chkTheaterMode.TextAlign = CType(resources.GetObject("chkTheaterMode.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkTheaterMode.Visible = CType(resources.GetObject("chkTheaterMode.Visible"), Boolean)
        '
        'chkStatusBar
        '
        Me.chkStatusBar.AccessibleDescription = CType(resources.GetObject("chkStatusBar.AccessibleDescription"), String)
        Me.chkStatusBar.AccessibleName = CType(resources.GetObject("chkStatusBar.AccessibleName"), String)
        Me.chkStatusBar.Anchor = CType(resources.GetObject("chkStatusBar.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkStatusBar.Appearance = CType(resources.GetObject("chkStatusBar.Appearance"), System.Windows.Forms.Appearance)
        Me.chkStatusBar.BackgroundImage = CType(resources.GetObject("chkStatusBar.BackgroundImage"), System.Drawing.Image)
        Me.chkStatusBar.CheckAlign = CType(resources.GetObject("chkStatusBar.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkStatusBar.Dock = CType(resources.GetObject("chkStatusBar.Dock"), System.Windows.Forms.DockStyle)
        Me.chkStatusBar.Enabled = CType(resources.GetObject("chkStatusBar.Enabled"), Boolean)
        Me.chkStatusBar.FlatStyle = CType(resources.GetObject("chkStatusBar.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkStatusBar.Font = CType(resources.GetObject("chkStatusBar.Font"), System.Drawing.Font)
        Me.chkStatusBar.Image = CType(resources.GetObject("chkStatusBar.Image"), System.Drawing.Image)
        Me.chkStatusBar.ImageAlign = CType(resources.GetObject("chkStatusBar.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkStatusBar.ImageIndex = CType(resources.GetObject("chkStatusBar.ImageIndex"), Integer)
        Me.chkStatusBar.ImeMode = CType(resources.GetObject("chkStatusBar.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkStatusBar.Location = CType(resources.GetObject("chkStatusBar.Location"), System.Drawing.Point)
        Me.chkStatusBar.Name = "chkStatusBar"
        Me.chkStatusBar.RightToLeft = CType(resources.GetObject("chkStatusBar.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkStatusBar.Size = CType(resources.GetObject("chkStatusBar.Size"), System.Drawing.Size)
        Me.chkStatusBar.TabIndex = CType(resources.GetObject("chkStatusBar.TabIndex"), Integer)
        Me.chkStatusBar.Text = resources.GetString("chkStatusBar.Text")
        Me.chkStatusBar.TextAlign = CType(resources.GetObject("chkStatusBar.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkStatusBar.Visible = CType(resources.GetObject("chkStatusBar.Visible"), Boolean)
        '
        'chkResizable
        '
        Me.chkResizable.AccessibleDescription = CType(resources.GetObject("chkResizable.AccessibleDescription"), String)
        Me.chkResizable.AccessibleName = CType(resources.GetObject("chkResizable.AccessibleName"), String)
        Me.chkResizable.Anchor = CType(resources.GetObject("chkResizable.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkResizable.Appearance = CType(resources.GetObject("chkResizable.Appearance"), System.Windows.Forms.Appearance)
        Me.chkResizable.BackgroundImage = CType(resources.GetObject("chkResizable.BackgroundImage"), System.Drawing.Image)
        Me.chkResizable.CheckAlign = CType(resources.GetObject("chkResizable.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkResizable.Dock = CType(resources.GetObject("chkResizable.Dock"), System.Windows.Forms.DockStyle)
        Me.chkResizable.Enabled = CType(resources.GetObject("chkResizable.Enabled"), Boolean)
        Me.chkResizable.FlatStyle = CType(resources.GetObject("chkResizable.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkResizable.Font = CType(resources.GetObject("chkResizable.Font"), System.Drawing.Font)
        Me.chkResizable.Image = CType(resources.GetObject("chkResizable.Image"), System.Drawing.Image)
        Me.chkResizable.ImageAlign = CType(resources.GetObject("chkResizable.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkResizable.ImageIndex = CType(resources.GetObject("chkResizable.ImageIndex"), Integer)
        Me.chkResizable.ImeMode = CType(resources.GetObject("chkResizable.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkResizable.Location = CType(resources.GetObject("chkResizable.Location"), System.Drawing.Point)
        Me.chkResizable.Name = "chkResizable"
        Me.chkResizable.RightToLeft = CType(resources.GetObject("chkResizable.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkResizable.Size = CType(resources.GetObject("chkResizable.Size"), System.Drawing.Size)
        Me.chkResizable.TabIndex = CType(resources.GetObject("chkResizable.TabIndex"), Integer)
        Me.chkResizable.Text = resources.GetString("chkResizable.Text")
        Me.chkResizable.TextAlign = CType(resources.GetObject("chkResizable.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkResizable.Visible = CType(resources.GetObject("chkResizable.Visible"), Boolean)
        '
        'chkMenuBar
        '
        Me.chkMenuBar.AccessibleDescription = CType(resources.GetObject("chkMenuBar.AccessibleDescription"), String)
        Me.chkMenuBar.AccessibleName = CType(resources.GetObject("chkMenuBar.AccessibleName"), String)
        Me.chkMenuBar.Anchor = CType(resources.GetObject("chkMenuBar.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkMenuBar.Appearance = CType(resources.GetObject("chkMenuBar.Appearance"), System.Windows.Forms.Appearance)
        Me.chkMenuBar.BackgroundImage = CType(resources.GetObject("chkMenuBar.BackgroundImage"), System.Drawing.Image)
        Me.chkMenuBar.CheckAlign = CType(resources.GetObject("chkMenuBar.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkMenuBar.Dock = CType(resources.GetObject("chkMenuBar.Dock"), System.Windows.Forms.DockStyle)
        Me.chkMenuBar.Enabled = CType(resources.GetObject("chkMenuBar.Enabled"), Boolean)
        Me.chkMenuBar.FlatStyle = CType(resources.GetObject("chkMenuBar.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkMenuBar.Font = CType(resources.GetObject("chkMenuBar.Font"), System.Drawing.Font)
        Me.chkMenuBar.Image = CType(resources.GetObject("chkMenuBar.Image"), System.Drawing.Image)
        Me.chkMenuBar.ImageAlign = CType(resources.GetObject("chkMenuBar.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkMenuBar.ImageIndex = CType(resources.GetObject("chkMenuBar.ImageIndex"), Integer)
        Me.chkMenuBar.ImeMode = CType(resources.GetObject("chkMenuBar.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkMenuBar.Location = CType(resources.GetObject("chkMenuBar.Location"), System.Drawing.Point)
        Me.chkMenuBar.Name = "chkMenuBar"
        Me.chkMenuBar.RightToLeft = CType(resources.GetObject("chkMenuBar.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkMenuBar.Size = CType(resources.GetObject("chkMenuBar.Size"), System.Drawing.Size)
        Me.chkMenuBar.TabIndex = CType(resources.GetObject("chkMenuBar.TabIndex"), Integer)
        Me.chkMenuBar.Text = resources.GetString("chkMenuBar.Text")
        Me.chkMenuBar.TextAlign = CType(resources.GetObject("chkMenuBar.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkMenuBar.Visible = CType(resources.GetObject("chkMenuBar.Visible"), Boolean)
        '
        'txtWidth
        '
        Me.txtWidth.AccessibleDescription = CType(resources.GetObject("txtWidth.AccessibleDescription"), String)
        Me.txtWidth.AccessibleName = CType(resources.GetObject("txtWidth.AccessibleName"), String)
        Me.txtWidth.Anchor = CType(resources.GetObject("txtWidth.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtWidth.AutoSize = CType(resources.GetObject("txtWidth.AutoSize"), Boolean)
        Me.txtWidth.BackgroundImage = CType(resources.GetObject("txtWidth.BackgroundImage"), System.Drawing.Image)
        Me.txtWidth.Dock = CType(resources.GetObject("txtWidth.Dock"), System.Windows.Forms.DockStyle)
        Me.txtWidth.Enabled = CType(resources.GetObject("txtWidth.Enabled"), Boolean)
        Me.txtWidth.Font = CType(resources.GetObject("txtWidth.Font"), System.Drawing.Font)
        Me.txtWidth.ImeMode = CType(resources.GetObject("txtWidth.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtWidth.Location = CType(resources.GetObject("txtWidth.Location"), System.Drawing.Point)
        Me.txtWidth.MaxLength = CType(resources.GetObject("txtWidth.MaxLength"), Integer)
        Me.txtWidth.Multiline = CType(resources.GetObject("txtWidth.Multiline"), Boolean)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.PasswordChar = CType(resources.GetObject("txtWidth.PasswordChar"), Char)
        Me.txtWidth.RightToLeft = CType(resources.GetObject("txtWidth.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtWidth.ScrollBars = CType(resources.GetObject("txtWidth.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtWidth.Size = CType(resources.GetObject("txtWidth.Size"), System.Drawing.Size)
        Me.txtWidth.TabIndex = CType(resources.GetObject("txtWidth.TabIndex"), Integer)
        Me.txtWidth.Text = resources.GetString("txtWidth.Text")
        Me.txtWidth.TextAlign = CType(resources.GetObject("txtWidth.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtWidth.Visible = CType(resources.GetObject("txtWidth.Visible"), Boolean)
        Me.txtWidth.WordWrap = CType(resources.GetObject("txtWidth.WordWrap"), Boolean)
        '
        'txtHeight
        '
        Me.txtHeight.AccessibleDescription = CType(resources.GetObject("txtHeight.AccessibleDescription"), String)
        Me.txtHeight.AccessibleName = CType(resources.GetObject("txtHeight.AccessibleName"), String)
        Me.txtHeight.Anchor = CType(resources.GetObject("txtHeight.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtHeight.AutoSize = CType(resources.GetObject("txtHeight.AutoSize"), Boolean)
        Me.txtHeight.BackgroundImage = CType(resources.GetObject("txtHeight.BackgroundImage"), System.Drawing.Image)
        Me.txtHeight.Dock = CType(resources.GetObject("txtHeight.Dock"), System.Windows.Forms.DockStyle)
        Me.txtHeight.Enabled = CType(resources.GetObject("txtHeight.Enabled"), Boolean)
        Me.txtHeight.Font = CType(resources.GetObject("txtHeight.Font"), System.Drawing.Font)
        Me.txtHeight.ImeMode = CType(resources.GetObject("txtHeight.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtHeight.Location = CType(resources.GetObject("txtHeight.Location"), System.Drawing.Point)
        Me.txtHeight.MaxLength = CType(resources.GetObject("txtHeight.MaxLength"), Integer)
        Me.txtHeight.Multiline = CType(resources.GetObject("txtHeight.Multiline"), Boolean)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.PasswordChar = CType(resources.GetObject("txtHeight.PasswordChar"), Char)
        Me.txtHeight.RightToLeft = CType(resources.GetObject("txtHeight.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtHeight.ScrollBars = CType(resources.GetObject("txtHeight.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtHeight.Size = CType(resources.GetObject("txtHeight.Size"), System.Drawing.Size)
        Me.txtHeight.TabIndex = CType(resources.GetObject("txtHeight.TabIndex"), Integer)
        Me.txtHeight.Text = resources.GetString("txtHeight.Text")
        Me.txtHeight.TextAlign = CType(resources.GetObject("txtHeight.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtHeight.Visible = CType(resources.GetObject("txtHeight.Visible"), Boolean)
        Me.txtHeight.WordWrap = CType(resources.GetObject("txtHeight.WordWrap"), Boolean)
        '
        'txtLeft
        '
        Me.txtLeft.AccessibleDescription = CType(resources.GetObject("txtLeft.AccessibleDescription"), String)
        Me.txtLeft.AccessibleName = CType(resources.GetObject("txtLeft.AccessibleName"), String)
        Me.txtLeft.Anchor = CType(resources.GetObject("txtLeft.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtLeft.AutoSize = CType(resources.GetObject("txtLeft.AutoSize"), Boolean)
        Me.txtLeft.BackgroundImage = CType(resources.GetObject("txtLeft.BackgroundImage"), System.Drawing.Image)
        Me.txtLeft.Dock = CType(resources.GetObject("txtLeft.Dock"), System.Windows.Forms.DockStyle)
        Me.txtLeft.Enabled = CType(resources.GetObject("txtLeft.Enabled"), Boolean)
        Me.txtLeft.Font = CType(resources.GetObject("txtLeft.Font"), System.Drawing.Font)
        Me.txtLeft.ImeMode = CType(resources.GetObject("txtLeft.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtLeft.Location = CType(resources.GetObject("txtLeft.Location"), System.Drawing.Point)
        Me.txtLeft.MaxLength = CType(resources.GetObject("txtLeft.MaxLength"), Integer)
        Me.txtLeft.Multiline = CType(resources.GetObject("txtLeft.Multiline"), Boolean)
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.PasswordChar = CType(resources.GetObject("txtLeft.PasswordChar"), Char)
        Me.txtLeft.RightToLeft = CType(resources.GetObject("txtLeft.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtLeft.ScrollBars = CType(resources.GetObject("txtLeft.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtLeft.Size = CType(resources.GetObject("txtLeft.Size"), System.Drawing.Size)
        Me.txtLeft.TabIndex = CType(resources.GetObject("txtLeft.TabIndex"), Integer)
        Me.txtLeft.Text = resources.GetString("txtLeft.Text")
        Me.txtLeft.TextAlign = CType(resources.GetObject("txtLeft.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtLeft.Visible = CType(resources.GetObject("txtLeft.Visible"), Boolean)
        Me.txtLeft.WordWrap = CType(resources.GetObject("txtLeft.WordWrap"), Boolean)
        '
        'txtTop
        '
        Me.txtTop.AccessibleDescription = CType(resources.GetObject("txtTop.AccessibleDescription"), String)
        Me.txtTop.AccessibleName = CType(resources.GetObject("txtTop.AccessibleName"), String)
        Me.txtTop.Anchor = CType(resources.GetObject("txtTop.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtTop.AutoSize = CType(resources.GetObject("txtTop.AutoSize"), Boolean)
        Me.txtTop.BackgroundImage = CType(resources.GetObject("txtTop.BackgroundImage"), System.Drawing.Image)
        Me.txtTop.Dock = CType(resources.GetObject("txtTop.Dock"), System.Windows.Forms.DockStyle)
        Me.txtTop.Enabled = CType(resources.GetObject("txtTop.Enabled"), Boolean)
        Me.txtTop.Font = CType(resources.GetObject("txtTop.Font"), System.Drawing.Font)
        Me.txtTop.ImeMode = CType(resources.GetObject("txtTop.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtTop.Location = CType(resources.GetObject("txtTop.Location"), System.Drawing.Point)
        Me.txtTop.MaxLength = CType(resources.GetObject("txtTop.MaxLength"), Integer)
        Me.txtTop.Multiline = CType(resources.GetObject("txtTop.Multiline"), Boolean)
        Me.txtTop.Name = "txtTop"
        Me.txtTop.PasswordChar = CType(resources.GetObject("txtTop.PasswordChar"), Char)
        Me.txtTop.RightToLeft = CType(resources.GetObject("txtTop.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtTop.ScrollBars = CType(resources.GetObject("txtTop.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtTop.Size = CType(resources.GetObject("txtTop.Size"), System.Drawing.Size)
        Me.txtTop.TabIndex = CType(resources.GetObject("txtTop.TabIndex"), Integer)
        Me.txtTop.Text = resources.GetString("txtTop.Text")
        Me.txtTop.TextAlign = CType(resources.GetObject("txtTop.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtTop.Visible = CType(resources.GetObject("txtTop.Visible"), Boolean)
        Me.txtTop.WordWrap = CType(resources.GetObject("txtTop.WordWrap"), Boolean)
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = CType(resources.GetObject("Label12.AccessibleDescription"), String)
        Me.Label12.AccessibleName = CType(resources.GetObject("Label12.AccessibleName"), String)
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
        'Label11
        '
        Me.Label11.AccessibleDescription = CType(resources.GetObject("Label11.AccessibleDescription"), String)
        Me.Label11.AccessibleName = CType(resources.GetObject("Label11.AccessibleName"), String)
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
        'Label10
        '
        Me.Label10.AccessibleDescription = CType(resources.GetObject("Label10.AccessibleDescription"), String)
        Me.Label10.AccessibleName = CType(resources.GetObject("Label10.AccessibleName"), String)
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
        Me.Label9.AccessibleDescription = CType(resources.GetObject("Label9.AccessibleDescription"), String)
        Me.Label9.AccessibleName = CType(resources.GetObject("Label9.AccessibleName"), String)
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
        Me.Label8.AccessibleDescription = CType(resources.GetObject("Label8.AccessibleDescription"), String)
        Me.Label8.AccessibleName = CType(resources.GetObject("Label8.AccessibleName"), String)
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
        'Label7
        '
        Me.Label7.AccessibleDescription = CType(resources.GetObject("Label7.AccessibleDescription"), String)
        Me.Label7.AccessibleName = CType(resources.GetObject("Label7.AccessibleName"), String)
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
        'chkFullScreen
        '
        Me.chkFullScreen.AccessibleDescription = CType(resources.GetObject("chkFullScreen.AccessibleDescription"), String)
        Me.chkFullScreen.AccessibleName = CType(resources.GetObject("chkFullScreen.AccessibleName"), String)
        Me.chkFullScreen.Anchor = CType(resources.GetObject("chkFullScreen.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkFullScreen.Appearance = CType(resources.GetObject("chkFullScreen.Appearance"), System.Windows.Forms.Appearance)
        Me.chkFullScreen.BackgroundImage = CType(resources.GetObject("chkFullScreen.BackgroundImage"), System.Drawing.Image)
        Me.chkFullScreen.CheckAlign = CType(resources.GetObject("chkFullScreen.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkFullScreen.Dock = CType(resources.GetObject("chkFullScreen.Dock"), System.Windows.Forms.DockStyle)
        Me.chkFullScreen.Enabled = CType(resources.GetObject("chkFullScreen.Enabled"), Boolean)
        Me.chkFullScreen.FlatStyle = CType(resources.GetObject("chkFullScreen.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkFullScreen.Font = CType(resources.GetObject("chkFullScreen.Font"), System.Drawing.Font)
        Me.chkFullScreen.Image = CType(resources.GetObject("chkFullScreen.Image"), System.Drawing.Image)
        Me.chkFullScreen.ImageAlign = CType(resources.GetObject("chkFullScreen.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkFullScreen.ImageIndex = CType(resources.GetObject("chkFullScreen.ImageIndex"), Integer)
        Me.chkFullScreen.ImeMode = CType(resources.GetObject("chkFullScreen.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkFullScreen.Location = CType(resources.GetObject("chkFullScreen.Location"), System.Drawing.Point)
        Me.chkFullScreen.Name = "chkFullScreen"
        Me.chkFullScreen.RightToLeft = CType(resources.GetObject("chkFullScreen.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkFullScreen.Size = CType(resources.GetObject("chkFullScreen.Size"), System.Drawing.Size)
        Me.chkFullScreen.TabIndex = CType(resources.GetObject("chkFullScreen.TabIndex"), Integer)
        Me.chkFullScreen.Text = resources.GetString("chkFullScreen.Text")
        Me.chkFullScreen.TextAlign = CType(resources.GetObject("chkFullScreen.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkFullScreen.Visible = CType(resources.GetObject("chkFullScreen.Visible"), Boolean)
        '
        'chkAddressBar
        '
        Me.chkAddressBar.AccessibleDescription = CType(resources.GetObject("chkAddressBar.AccessibleDescription"), String)
        Me.chkAddressBar.AccessibleName = CType(resources.GetObject("chkAddressBar.AccessibleName"), String)
        Me.chkAddressBar.Anchor = CType(resources.GetObject("chkAddressBar.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkAddressBar.Appearance = CType(resources.GetObject("chkAddressBar.Appearance"), System.Windows.Forms.Appearance)
        Me.chkAddressBar.BackgroundImage = CType(resources.GetObject("chkAddressBar.BackgroundImage"), System.Drawing.Image)
        Me.chkAddressBar.CheckAlign = CType(resources.GetObject("chkAddressBar.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkAddressBar.Dock = CType(resources.GetObject("chkAddressBar.Dock"), System.Windows.Forms.DockStyle)
        Me.chkAddressBar.Enabled = CType(resources.GetObject("chkAddressBar.Enabled"), Boolean)
        Me.chkAddressBar.FlatStyle = CType(resources.GetObject("chkAddressBar.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkAddressBar.Font = CType(resources.GetObject("chkAddressBar.Font"), System.Drawing.Font)
        Me.chkAddressBar.Image = CType(resources.GetObject("chkAddressBar.Image"), System.Drawing.Image)
        Me.chkAddressBar.ImageAlign = CType(resources.GetObject("chkAddressBar.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkAddressBar.ImageIndex = CType(resources.GetObject("chkAddressBar.ImageIndex"), Integer)
        Me.chkAddressBar.ImeMode = CType(resources.GetObject("chkAddressBar.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkAddressBar.Location = CType(resources.GetObject("chkAddressBar.Location"), System.Drawing.Point)
        Me.chkAddressBar.Name = "chkAddressBar"
        Me.chkAddressBar.RightToLeft = CType(resources.GetObject("chkAddressBar.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkAddressBar.Size = CType(resources.GetObject("chkAddressBar.Size"), System.Drawing.Size)
        Me.chkAddressBar.TabIndex = CType(resources.GetObject("chkAddressBar.TabIndex"), Integer)
        Me.chkAddressBar.Text = resources.GetString("chkAddressBar.Text")
        Me.chkAddressBar.TextAlign = CType(resources.GetObject("chkAddressBar.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkAddressBar.Visible = CType(resources.GetObject("chkAddressBar.Visible"), Boolean)
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
        'Label3
        '
        Me.Label3.AccessibleDescription = CType(resources.GetObject("Label3.AccessibleDescription"), String)
        Me.Label3.AccessibleName = CType(resources.GetObject("Label3.AccessibleName"), String)
        Me.Label3.Anchor = CType(resources.GetObject("Label3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = CType(resources.GetObject("Label3.AutoSize"), Boolean)
        Me.Label3.Dock = CType(resources.GetObject("Label3.Dock"), System.Windows.Forms.DockStyle)
        Me.Label3.Enabled = CType(resources.GetObject("Label3.Enabled"), Boolean)
        Me.Label3.Font = CType(resources.GetObject("Label3.Font"), System.Drawing.Font)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
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
        'btnBrowse2
        '
        Me.btnBrowse2.AccessibleDescription = CType(resources.GetObject("btnBrowse2.AccessibleDescription"), String)
        Me.btnBrowse2.AccessibleName = CType(resources.GetObject("btnBrowse2.AccessibleName"), String)
        Me.btnBrowse2.Anchor = CType(resources.GetObject("btnBrowse2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnBrowse2.BackgroundImage = CType(resources.GetObject("btnBrowse2.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse2.Dock = CType(resources.GetObject("btnBrowse2.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBrowse2.Enabled = CType(resources.GetObject("btnBrowse2.Enabled"), Boolean)
        Me.btnBrowse2.FlatStyle = CType(resources.GetObject("btnBrowse2.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBrowse2.Font = CType(resources.GetObject("btnBrowse2.Font"), System.Drawing.Font)
        Me.btnBrowse2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnBrowse2.Image = CType(resources.GetObject("btnBrowse2.Image"), System.Drawing.Image)
        Me.btnBrowse2.ImageAlign = CType(resources.GetObject("btnBrowse2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBrowse2.ImageIndex = CType(resources.GetObject("btnBrowse2.ImageIndex"), Integer)
        Me.btnBrowse2.ImeMode = CType(resources.GetObject("btnBrowse2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBrowse2.Location = CType(resources.GetObject("btnBrowse2.Location"), System.Drawing.Point)
        Me.btnBrowse2.Name = "btnBrowse2"
        Me.btnBrowse2.RightToLeft = CType(resources.GetObject("btnBrowse2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBrowse2.Size = CType(resources.GetObject("btnBrowse2.Size"), System.Drawing.Size)
        Me.btnBrowse2.TabIndex = CType(resources.GetObject("btnBrowse2.TabIndex"), Integer)
        Me.btnBrowse2.Text = resources.GetString("btnBrowse2.Text")
        Me.btnBrowse2.TextAlign = CType(resources.GetObject("btnBrowse2.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBrowse2.Visible = CType(resources.GetObject("btnBrowse2.Visible"), Boolean)
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
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
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
        'tbAddress2
        '
        Me.tbAddress2.AccessibleDescription = CType(resources.GetObject("tbAddress2.AccessibleDescription"), String)
        Me.tbAddress2.AccessibleName = CType(resources.GetObject("tbAddress2.AccessibleName"), String)
        Me.tbAddress2.Anchor = CType(resources.GetObject("tbAddress2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tbAddress2.AutoSize = CType(resources.GetObject("tbAddress2.AutoSize"), Boolean)
        Me.tbAddress2.BackgroundImage = CType(resources.GetObject("tbAddress2.BackgroundImage"), System.Drawing.Image)
        Me.tbAddress2.Dock = CType(resources.GetObject("tbAddress2.Dock"), System.Windows.Forms.DockStyle)
        Me.tbAddress2.Enabled = CType(resources.GetObject("tbAddress2.Enabled"), Boolean)
        Me.tbAddress2.Font = CType(resources.GetObject("tbAddress2.Font"), System.Drawing.Font)
        Me.tbAddress2.ImeMode = CType(resources.GetObject("tbAddress2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tbAddress2.Location = CType(resources.GetObject("tbAddress2.Location"), System.Drawing.Point)
        Me.tbAddress2.MaxLength = CType(resources.GetObject("tbAddress2.MaxLength"), Integer)
        Me.tbAddress2.Multiline = CType(resources.GetObject("tbAddress2.Multiline"), Boolean)
        Me.tbAddress2.Name = "tbAddress2"
        Me.tbAddress2.PasswordChar = CType(resources.GetObject("tbAddress2.PasswordChar"), Char)
        Me.tbAddress2.RightToLeft = CType(resources.GetObject("tbAddress2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tbAddress2.ScrollBars = CType(resources.GetObject("tbAddress2.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.tbAddress2.Size = CType(resources.GetObject("tbAddress2.Size"), System.Drawing.Size)
        Me.tbAddress2.TabIndex = CType(resources.GetObject("tbAddress2.TabIndex"), Integer)
        Me.tbAddress2.Text = resources.GetString("tbAddress2.Text")
        Me.tbAddress2.TextAlign = CType(resources.GetObject("tbAddress2.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.tbAddress2.Visible = CType(resources.GetObject("tbAddress2.Visible"), Boolean)
        Me.tbAddress2.WordWrap = CType(resources.GetObject("tbAddress2.WordWrap"), Boolean)
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnBrowse
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
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
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmMain"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.TabControl1.ResumeLayout(False)
        Me.tabActiveX.ResumeLayout(False)
        CType(Me.ieForHosting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAutomation.ResumeLayout(False)
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

    Protected htmlDocActiveX, htmlDocAutomation As mshtml.IHTMLDocument2
    Protected WithEvents ieForAutomation As SHDocVw.InternetExplorer
    Protected ieElement As mshtml.IHTMLElement
    Protected frmStatus As frmStatus

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' ieForHosting is the embedded ActiveX control. The AxSHDocVw.WebBrowser 
        ' object is used when you want to run IE as an embedded control.
        ieForHosting.Navigate("www.microsoft.com")
        EnableNavIfHistory()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ' Notice here, unlike the Back and Forward button click event handlers, that 
        ' you use the WebBrowser object not the Document object assigned to the 
        ' htmlDocActiveX interface. If you use the latter the navigation will not occur. 
        ieForHosting.Navigate(tbAddress.Text)
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        htmlDocActiveX.parentWindow.history.go(-1)
        tbAddress.Text = htmlDocActiveX.url
    End Sub

    Private Sub btnForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        htmlDocActiveX.parentWindow.history.go(+1)
        tbAddress.Text = htmlDocActiveX.url
    End Sub

    Private Sub btnBrowse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse2.Click
        ' Open internet explorer, and configure its user interface based on
        ' the options selected by the user.
        If ieForAutomation Is Nothing Then
            ieForAutomation = New SHDocVw.InternetExplorer()
        End If

        ieForAutomation.AddressBar = chkAddressBar.Checked
        ieForAutomation.FullScreen = chkFullScreen.Checked
        ieForAutomation.MenuBar = chkMenuBar.Checked
        ieForAutomation.Resizable = chkResizable.Checked
        ieForAutomation.StatusBar = chkStatusBar.Checked
        ieForAutomation.TheaterMode = chkTheaterMode.Checked
        ieForAutomation.ToolBar = Convert.ToInt32(chkToolBar.Checked)

        If IsNumeric(txtHeight.Text) Then
            ieForAutomation.Height = Int32.Parse(txtHeight.Text)
        End If

        If IsNumeric(txtWidth.Text) Then
            ieForAutomation.Width = Int32.Parse(txtWidth.Text)
        End If

        If IsNumeric(txtTop.Text) Then
            ieForAutomation.Top = Int32.Parse(txtTop.Text)
        End If

        If IsNumeric(txtLeft.Text) Then
            ieForAutomation.Left = Int32.Parse(txtLeft.Text)
        End If

        Me.Cursor = Cursors.WaitCursor
        frmStatus = New frmStatus()
        frmStatus.Show("Connecting to Web page and processing HTML. Please stand by...")

        ieForAutomation.Visible = True
        ieForAutomation.Navigate(tbAddress2.Text)
    End Sub

    Private Sub chkAddressBar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddressBar.CheckedChanged
        ' The address bar will only display if the toolbar is also enabled.
        If chkAddressBar.Checked = True AndAlso _
            chkToolBar.Checked = False Then

            If MessageBox.Show("You must also enable the toolbar for the " & _
                "address bar to be visible.  Do you want to enable the " & _
                "tool bar?", _
                "Enable ToolBar?", _
                MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question) = DialogResult.Yes Then

                chkToolBar.Checked = True

            End If
        End If
    End Sub

    ' Fires when the document has completely loaded.
    Private Sub ieForAutomation_DocumentComplete(ByVal pDisp As Object, ByRef URL As Object) Handles ieForAutomation.DocumentComplete
        ' This event will fire in a different thread than the one that created the
        ' form.  You can only modify the user interface through the thread that
        ' created it because the underlying UI libraries are not thread safe.
        ' To overcome this problem, you "marshal" the information back to the main
        ' thread through the Invoke method.
        Me.Invoke(New HideStatusDelegate(AddressOf Me.HideStatus))
    End Sub

    Private Sub ieForAutomation_OnQuit() Handles ieForAutomation.OnQuit
        ieForAutomation = Nothing
    End Sub

    ' Fires when the document has completely loaded. If you don't attempt to assign
    ' htmlDocActiveX somewhere other than this handler you will get a null object reference 
    ' if a document has not been completely loaded.
    Private Sub ieForHosting_DocumentComplete(ByVal sender As System.Object, ByVal e As AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent) Handles ieForHosting.DocumentComplete
        htmlDocActiveX = CType(ieForHosting.Document, mshtml.IHTMLDocument2)
        Me.Invoke(New OnCompleteDelegate(AddressOf Me.OnComplete), _
            New Object() {htmlDocActiveX})
    End Sub

    Protected Sub EnableNavIfHistory()
        ' If the history is empty, disable the forward and back buttons.
        If htmlDocActiveX Is Nothing OrElse htmlDocActiveX.parentWindow.history.length = 0 Then
            btnBack.Enabled = False
            btnForward.Enabled = False
        Else
            btnBack.Enabled = True
            btnForward.Enabled = True
        End If
    End Sub

    ' Hide the status form when the page finishes loading.
    Delegate Sub HideStatusDelegate()
    Protected Sub HideStatus()
        frmStatus.Hide()
        Me.Cursor = Cursors.Default
    End Sub

    ' Fires when the browser ActiveX control finishes loading a document
    Delegate Sub OnCompleteDelegate(ByVal htmlDoc As mshtml.IHTMLDocument2)
    Public Sub OnComplete(ByVal htmlDoc As mshtml.IHTMLDocument2)
        tbAddress.Text = htmlDoc.url
        EnableNavIfHistory()
    End Sub
End Class