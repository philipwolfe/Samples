'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' Create a class variable to store the temporary file name
    Dim m_FileName As String = ""

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
    Friend WithEvents lblTempDirectory As System.Windows.Forms.Label
    Friend WithEvents btnFindTempDirectory As System.Windows.Forms.Button
    Friend WithEvents txtTempDirectory As System.Windows.Forms.TextBox
    Friend WithEvents sbrStatus As System.Windows.Forms.StatusBar
    Friend WithEvents txtTempFile As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateTempFile As System.Windows.Forms.Button
    Friend WithEvents lblTempFile As System.Windows.Forms.Label
    Friend WithEvents btnUseTempFilebtnUseTempFile As System.Windows.Forms.Button
    Friend WithEvents btnDeleteTempFile As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.lblTempDirectory = New System.Windows.Forms.Label()
        Me.btnFindTempDirectory = New System.Windows.Forms.Button()
        Me.txtTempDirectory = New System.Windows.Forms.TextBox()
        Me.sbrStatus = New System.Windows.Forms.StatusBar()
        Me.txtTempFile = New System.Windows.Forms.TextBox()
        Me.btnCreateTempFile = New System.Windows.Forms.Button()
        Me.lblTempFile = New System.Windows.Forms.Label()
        Me.btnUseTempFilebtnUseTempFile = New System.Windows.Forms.Button()
        Me.btnDeleteTempFile = New System.Windows.Forms.Button()
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
        'lblTempDirectory
        '
        Me.lblTempDirectory.AccessibleDescription = resources.GetString("lblTempDirectory.AccessibleDescription")
        Me.lblTempDirectory.AccessibleName = resources.GetString("lblTempDirectory.AccessibleName")
        Me.lblTempDirectory.Anchor = CType(resources.GetObject("lblTempDirectory.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTempDirectory.AutoSize = CType(resources.GetObject("lblTempDirectory.AutoSize"), Boolean)
        Me.lblTempDirectory.Dock = CType(resources.GetObject("lblTempDirectory.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTempDirectory.Enabled = CType(resources.GetObject("lblTempDirectory.Enabled"), Boolean)
        Me.lblTempDirectory.Font = CType(resources.GetObject("lblTempDirectory.Font"), System.Drawing.Font)
        Me.lblTempDirectory.Image = CType(resources.GetObject("lblTempDirectory.Image"), System.Drawing.Image)
        Me.lblTempDirectory.ImageAlign = CType(resources.GetObject("lblTempDirectory.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTempDirectory.ImageIndex = CType(resources.GetObject("lblTempDirectory.ImageIndex"), Integer)
        Me.lblTempDirectory.ImeMode = CType(resources.GetObject("lblTempDirectory.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTempDirectory.Location = CType(resources.GetObject("lblTempDirectory.Location"), System.Drawing.Point)
        Me.lblTempDirectory.Name = "lblTempDirectory"
        Me.lblTempDirectory.RightToLeft = CType(resources.GetObject("lblTempDirectory.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTempDirectory.Size = CType(resources.GetObject("lblTempDirectory.Size"), System.Drawing.Size)
        Me.lblTempDirectory.TabIndex = CType(resources.GetObject("lblTempDirectory.TabIndex"), Integer)
        Me.lblTempDirectory.Text = resources.GetString("lblTempDirectory.Text")
        Me.lblTempDirectory.TextAlign = CType(resources.GetObject("lblTempDirectory.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTempDirectory.Visible = CType(resources.GetObject("lblTempDirectory.Visible"), Boolean)
        '
        'btnFindTempDirectory
        '
        Me.btnFindTempDirectory.AccessibleDescription = resources.GetString("btnFindTempDirectory.AccessibleDescription")
        Me.btnFindTempDirectory.AccessibleName = resources.GetString("btnFindTempDirectory.AccessibleName")
        Me.btnFindTempDirectory.Anchor = CType(resources.GetObject("btnFindTempDirectory.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnFindTempDirectory.BackgroundImage = CType(resources.GetObject("btnFindTempDirectory.BackgroundImage"), System.Drawing.Image)
        Me.btnFindTempDirectory.Dock = CType(resources.GetObject("btnFindTempDirectory.Dock"), System.Windows.Forms.DockStyle)
        Me.btnFindTempDirectory.Enabled = CType(resources.GetObject("btnFindTempDirectory.Enabled"), Boolean)
        Me.btnFindTempDirectory.FlatStyle = CType(resources.GetObject("btnFindTempDirectory.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnFindTempDirectory.Font = CType(resources.GetObject("btnFindTempDirectory.Font"), System.Drawing.Font)
        Me.btnFindTempDirectory.Image = CType(resources.GetObject("btnFindTempDirectory.Image"), System.Drawing.Image)
        Me.btnFindTempDirectory.ImageAlign = CType(resources.GetObject("btnFindTempDirectory.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnFindTempDirectory.ImageIndex = CType(resources.GetObject("btnFindTempDirectory.ImageIndex"), Integer)
        Me.btnFindTempDirectory.ImeMode = CType(resources.GetObject("btnFindTempDirectory.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnFindTempDirectory.Location = CType(resources.GetObject("btnFindTempDirectory.Location"), System.Drawing.Point)
        Me.btnFindTempDirectory.Name = "btnFindTempDirectory"
        Me.btnFindTempDirectory.RightToLeft = CType(resources.GetObject("btnFindTempDirectory.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnFindTempDirectory.Size = CType(resources.GetObject("btnFindTempDirectory.Size"), System.Drawing.Size)
        Me.btnFindTempDirectory.TabIndex = CType(resources.GetObject("btnFindTempDirectory.TabIndex"), Integer)
        Me.btnFindTempDirectory.Text = resources.GetString("btnFindTempDirectory.Text")
        Me.btnFindTempDirectory.TextAlign = CType(resources.GetObject("btnFindTempDirectory.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnFindTempDirectory.Visible = CType(resources.GetObject("btnFindTempDirectory.Visible"), Boolean)
        '
        'txtTempDirectory
        '
        Me.txtTempDirectory.AccessibleDescription = resources.GetString("txtTempDirectory.AccessibleDescription")
        Me.txtTempDirectory.AccessibleName = resources.GetString("txtTempDirectory.AccessibleName")
        Me.txtTempDirectory.Anchor = CType(resources.GetObject("txtTempDirectory.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtTempDirectory.AutoSize = CType(resources.GetObject("txtTempDirectory.AutoSize"), Boolean)
        Me.txtTempDirectory.BackgroundImage = CType(resources.GetObject("txtTempDirectory.BackgroundImage"), System.Drawing.Image)
        Me.txtTempDirectory.Dock = CType(resources.GetObject("txtTempDirectory.Dock"), System.Windows.Forms.DockStyle)
        Me.txtTempDirectory.Enabled = CType(resources.GetObject("txtTempDirectory.Enabled"), Boolean)
        Me.txtTempDirectory.Font = CType(resources.GetObject("txtTempDirectory.Font"), System.Drawing.Font)
        Me.txtTempDirectory.ImeMode = CType(resources.GetObject("txtTempDirectory.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtTempDirectory.Location = CType(resources.GetObject("txtTempDirectory.Location"), System.Drawing.Point)
        Me.txtTempDirectory.MaxLength = CType(resources.GetObject("txtTempDirectory.MaxLength"), Integer)
        Me.txtTempDirectory.Multiline = CType(resources.GetObject("txtTempDirectory.Multiline"), Boolean)
        Me.txtTempDirectory.Name = "txtTempDirectory"
        Me.txtTempDirectory.PasswordChar = CType(resources.GetObject("txtTempDirectory.PasswordChar"), Char)
        Me.txtTempDirectory.RightToLeft = CType(resources.GetObject("txtTempDirectory.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtTempDirectory.ScrollBars = CType(resources.GetObject("txtTempDirectory.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtTempDirectory.Size = CType(resources.GetObject("txtTempDirectory.Size"), System.Drawing.Size)
        Me.txtTempDirectory.TabIndex = CType(resources.GetObject("txtTempDirectory.TabIndex"), Integer)
        Me.txtTempDirectory.TabStop = False
        Me.txtTempDirectory.Text = resources.GetString("txtTempDirectory.Text")
        Me.txtTempDirectory.TextAlign = CType(resources.GetObject("txtTempDirectory.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtTempDirectory.Visible = CType(resources.GetObject("txtTempDirectory.Visible"), Boolean)
        Me.txtTempDirectory.WordWrap = CType(resources.GetObject("txtTempDirectory.WordWrap"), Boolean)
        '
        'sbrStatus
        '
        Me.sbrStatus.AccessibleDescription = CType(resources.GetObject("sbrStatus.AccessibleDescription"), String)
        Me.sbrStatus.AccessibleName = CType(resources.GetObject("sbrStatus.AccessibleName"), String)
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
        'txtTempFile
        '
        Me.txtTempFile.AccessibleDescription = resources.GetString("txtTempFile.AccessibleDescription")
        Me.txtTempFile.AccessibleName = resources.GetString("txtTempFile.AccessibleName")
        Me.txtTempFile.Anchor = CType(resources.GetObject("txtTempFile.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtTempFile.AutoSize = CType(resources.GetObject("txtTempFile.AutoSize"), Boolean)
        Me.txtTempFile.BackgroundImage = CType(resources.GetObject("txtTempFile.BackgroundImage"), System.Drawing.Image)
        Me.txtTempFile.Dock = CType(resources.GetObject("txtTempFile.Dock"), System.Windows.Forms.DockStyle)
        Me.txtTempFile.Enabled = CType(resources.GetObject("txtTempFile.Enabled"), Boolean)
        Me.txtTempFile.Font = CType(resources.GetObject("txtTempFile.Font"), System.Drawing.Font)
        Me.txtTempFile.ImeMode = CType(resources.GetObject("txtTempFile.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtTempFile.Location = CType(resources.GetObject("txtTempFile.Location"), System.Drawing.Point)
        Me.txtTempFile.MaxLength = CType(resources.GetObject("txtTempFile.MaxLength"), Integer)
        Me.txtTempFile.Multiline = CType(resources.GetObject("txtTempFile.Multiline"), Boolean)
        Me.txtTempFile.Name = "txtTempFile"
        Me.txtTempFile.PasswordChar = CType(resources.GetObject("txtTempFile.PasswordChar"), Char)
        Me.txtTempFile.RightToLeft = CType(resources.GetObject("txtTempFile.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtTempFile.ScrollBars = CType(resources.GetObject("txtTempFile.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtTempFile.Size = CType(resources.GetObject("txtTempFile.Size"), System.Drawing.Size)
        Me.txtTempFile.TabIndex = CType(resources.GetObject("txtTempFile.TabIndex"), Integer)
        Me.txtTempFile.TabStop = False
        Me.txtTempFile.Text = resources.GetString("txtTempFile.Text")
        Me.txtTempFile.TextAlign = CType(resources.GetObject("txtTempFile.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtTempFile.Visible = CType(resources.GetObject("txtTempFile.Visible"), Boolean)
        Me.txtTempFile.WordWrap = CType(resources.GetObject("txtTempFile.WordWrap"), Boolean)
        '
        'btnCreateTempFile
        '
        Me.btnCreateTempFile.AccessibleDescription = resources.GetString("btnCreateTempFile.AccessibleDescription")
        Me.btnCreateTempFile.AccessibleName = resources.GetString("btnCreateTempFile.AccessibleName")
        Me.btnCreateTempFile.Anchor = CType(resources.GetObject("btnCreateTempFile.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateTempFile.BackgroundImage = CType(resources.GetObject("btnCreateTempFile.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateTempFile.Dock = CType(resources.GetObject("btnCreateTempFile.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateTempFile.Enabled = CType(resources.GetObject("btnCreateTempFile.Enabled"), Boolean)
        Me.btnCreateTempFile.FlatStyle = CType(resources.GetObject("btnCreateTempFile.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateTempFile.Font = CType(resources.GetObject("btnCreateTempFile.Font"), System.Drawing.Font)
        Me.btnCreateTempFile.Image = CType(resources.GetObject("btnCreateTempFile.Image"), System.Drawing.Image)
        Me.btnCreateTempFile.ImageAlign = CType(resources.GetObject("btnCreateTempFile.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateTempFile.ImageIndex = CType(resources.GetObject("btnCreateTempFile.ImageIndex"), Integer)
        Me.btnCreateTempFile.ImeMode = CType(resources.GetObject("btnCreateTempFile.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateTempFile.Location = CType(resources.GetObject("btnCreateTempFile.Location"), System.Drawing.Point)
        Me.btnCreateTempFile.Name = "btnCreateTempFile"
        Me.btnCreateTempFile.RightToLeft = CType(resources.GetObject("btnCreateTempFile.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateTempFile.Size = CType(resources.GetObject("btnCreateTempFile.Size"), System.Drawing.Size)
        Me.btnCreateTempFile.TabIndex = CType(resources.GetObject("btnCreateTempFile.TabIndex"), Integer)
        Me.btnCreateTempFile.Text = resources.GetString("btnCreateTempFile.Text")
        Me.btnCreateTempFile.TextAlign = CType(resources.GetObject("btnCreateTempFile.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateTempFile.Visible = CType(resources.GetObject("btnCreateTempFile.Visible"), Boolean)
        '
        'lblTempFile
        '
        Me.lblTempFile.AccessibleDescription = resources.GetString("lblTempFile.AccessibleDescription")
        Me.lblTempFile.AccessibleName = resources.GetString("lblTempFile.AccessibleName")
        Me.lblTempFile.Anchor = CType(resources.GetObject("lblTempFile.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTempFile.AutoSize = CType(resources.GetObject("lblTempFile.AutoSize"), Boolean)
        Me.lblTempFile.Dock = CType(resources.GetObject("lblTempFile.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTempFile.Enabled = CType(resources.GetObject("lblTempFile.Enabled"), Boolean)
        Me.lblTempFile.Font = CType(resources.GetObject("lblTempFile.Font"), System.Drawing.Font)
        Me.lblTempFile.Image = CType(resources.GetObject("lblTempFile.Image"), System.Drawing.Image)
        Me.lblTempFile.ImageAlign = CType(resources.GetObject("lblTempFile.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTempFile.ImageIndex = CType(resources.GetObject("lblTempFile.ImageIndex"), Integer)
        Me.lblTempFile.ImeMode = CType(resources.GetObject("lblTempFile.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTempFile.Location = CType(resources.GetObject("lblTempFile.Location"), System.Drawing.Point)
        Me.lblTempFile.Name = "lblTempFile"
        Me.lblTempFile.RightToLeft = CType(resources.GetObject("lblTempFile.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTempFile.Size = CType(resources.GetObject("lblTempFile.Size"), System.Drawing.Size)
        Me.lblTempFile.TabIndex = CType(resources.GetObject("lblTempFile.TabIndex"), Integer)
        Me.lblTempFile.Text = resources.GetString("lblTempFile.Text")
        Me.lblTempFile.TextAlign = CType(resources.GetObject("lblTempFile.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTempFile.Visible = CType(resources.GetObject("lblTempFile.Visible"), Boolean)
        '
        'btnUseTempFilebtnUseTempFile
        '
        Me.btnUseTempFilebtnUseTempFile.AccessibleDescription = resources.GetString("btnUseTempFilebtnUseTempFile.AccessibleDescription")
        Me.btnUseTempFilebtnUseTempFile.AccessibleName = resources.GetString("btnUseTempFilebtnUseTempFile.AccessibleName")
        Me.btnUseTempFilebtnUseTempFile.Anchor = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnUseTempFilebtnUseTempFile.BackgroundImage = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.BackgroundImage"), System.Drawing.Image)
        Me.btnUseTempFilebtnUseTempFile.Dock = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.Dock"), System.Windows.Forms.DockStyle)
        Me.btnUseTempFilebtnUseTempFile.Enabled = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.Enabled"), Boolean)
        Me.btnUseTempFilebtnUseTempFile.FlatStyle = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnUseTempFilebtnUseTempFile.Font = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.Font"), System.Drawing.Font)
        Me.btnUseTempFilebtnUseTempFile.Image = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.Image"), System.Drawing.Image)
        Me.btnUseTempFilebtnUseTempFile.ImageAlign = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnUseTempFilebtnUseTempFile.ImageIndex = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.ImageIndex"), Integer)
        Me.btnUseTempFilebtnUseTempFile.ImeMode = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnUseTempFilebtnUseTempFile.Location = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.Location"), System.Drawing.Point)
        Me.btnUseTempFilebtnUseTempFile.Name = "btnUseTempFilebtnUseTempFile"
        Me.btnUseTempFilebtnUseTempFile.RightToLeft = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnUseTempFilebtnUseTempFile.Size = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.Size"), System.Drawing.Size)
        Me.btnUseTempFilebtnUseTempFile.TabIndex = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.TabIndex"), Integer)
        Me.btnUseTempFilebtnUseTempFile.Text = resources.GetString("btnUseTempFilebtnUseTempFile.Text")
        Me.btnUseTempFilebtnUseTempFile.TextAlign = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnUseTempFilebtnUseTempFile.Visible = CType(resources.GetObject("btnUseTempFilebtnUseTempFile.Visible"), Boolean)
        '
        'btnDeleteTempFile
        '
        Me.btnDeleteTempFile.AccessibleDescription = resources.GetString("btnDeleteTempFile.AccessibleDescription")
        Me.btnDeleteTempFile.AccessibleName = resources.GetString("btnDeleteTempFile.AccessibleName")
        Me.btnDeleteTempFile.Anchor = CType(resources.GetObject("btnDeleteTempFile.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteTempFile.BackgroundImage = CType(resources.GetObject("btnDeleteTempFile.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteTempFile.Dock = CType(resources.GetObject("btnDeleteTempFile.Dock"), System.Windows.Forms.DockStyle)
        Me.btnDeleteTempFile.Enabled = CType(resources.GetObject("btnDeleteTempFile.Enabled"), Boolean)
        Me.btnDeleteTempFile.FlatStyle = CType(resources.GetObject("btnDeleteTempFile.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnDeleteTempFile.Font = CType(resources.GetObject("btnDeleteTempFile.Font"), System.Drawing.Font)
        Me.btnDeleteTempFile.Image = CType(resources.GetObject("btnDeleteTempFile.Image"), System.Drawing.Image)
        Me.btnDeleteTempFile.ImageAlign = CType(resources.GetObject("btnDeleteTempFile.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnDeleteTempFile.ImageIndex = CType(resources.GetObject("btnDeleteTempFile.ImageIndex"), Integer)
        Me.btnDeleteTempFile.ImeMode = CType(resources.GetObject("btnDeleteTempFile.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnDeleteTempFile.Location = CType(resources.GetObject("btnDeleteTempFile.Location"), System.Drawing.Point)
        Me.btnDeleteTempFile.Name = "btnDeleteTempFile"
        Me.btnDeleteTempFile.RightToLeft = CType(resources.GetObject("btnDeleteTempFile.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnDeleteTempFile.Size = CType(resources.GetObject("btnDeleteTempFile.Size"), System.Drawing.Size)
        Me.btnDeleteTempFile.TabIndex = CType(resources.GetObject("btnDeleteTempFile.TabIndex"), Integer)
        Me.btnDeleteTempFile.Text = resources.GetString("btnDeleteTempFile.Text")
        Me.btnDeleteTempFile.TextAlign = CType(resources.GetObject("btnDeleteTempFile.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnDeleteTempFile.Visible = CType(resources.GetObject("btnDeleteTempFile.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteTempFile, Me.btnUseTempFilebtnUseTempFile, Me.txtTempFile, Me.btnCreateTempFile, Me.lblTempFile, Me.sbrStatus, Me.txtTempDirectory, Me.btnFindTempDirectory, Me.lblTempDirectory})
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

    ' This subrouting Creates a Temporary file and sets its Attribute
    '   property to Temporary.
    Private Sub btnCreateTempFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateTempFile.Click

        ' Clear the Status Bar
        Me.sbrStatus.Text = ""

        Try
            ' Return the path and name of a newly created Temporary
            '   file. Note that the GetTempFileName() method actually creates
            '   a 0-byte file and returns the name of the created file.
            m_FileName = Path.GetTempFileName()

            ' Craete a FileInfo object to manipulate properties of 
            '   the created temporary file
            Dim myFileInfo As New FileInfo(m_FileName)
            ' Use the FileInfo object to set the Attribute property of this
            '   file to Temporary. Although this is not completely necessary, 
            '   the .NET Framework is able to optimize the use of Temporary
            '   files by keeping them cached in memory.
            ' Inexplicably, the Attribute given to a file created with
            '   the GetTempFileName() method is Archive, which prevents the 
            '   .NET Framework from optimizing its use.
            myFileInfo.Attributes = FileAttributes.Temporary

        Catch exc As Exception
            ' Warn the user if there is a problem
            Me.sbrStatus.Text = "Unable to create a TEMP file or set its attributes."
        End Try

        ' Display the Temporary Filename in the txtTempFile text box.
        Me.txtTempFile.Text = m_FileName

    End Sub

    ' This subrouting deletes the temporary file that was created earlier.
    Private Sub btnDeleteTempFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTempFile.Click

        ' Clear the Status Bar or show error if there is no current file
        If m_FileName = "" Then
            Me.sbrStatus.Text = "Temp file not yet created."
            Return
        Else
            Me.sbrStatus.Text = ""
        End If

        ' Attempt to delete the file.
        Try
            File.Delete(m_FileName)
            m_FileName = ""
            Me.txtTempFile.Text = ""
        Catch exc As Exception
            ' Show error to user.
            Me.sbrStatus.Text = "Error deleteing Temp file."
        End Try
    End Sub


    ' This subroutine finds the path to the Temp directory
    '   on the local machine. It is ALWAYS important to wrap any Path
    '   method calls in a Try-Catch block since exceptions are thrown based
    '   on the permissions granted to the current user.
    Private Sub btnFindTempDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindTempDirectory.Click

        ' Create outside of Try-Catch, and initialize to an empty string.
        Dim tempPathString As String = ""

        ' Clear the Status Bar.
        Me.sbrStatus.Text = ""

        ' Attempt to get the path to the Temp directory
        Try
            tempPathString = Path.GetTempPath()
        Catch sex As Security.SecurityException
            ' Show error to user, if they don't have the proper permissions
            Me.sbrStatus.Text = "You do not have the required permissions."
        Catch exc As Exception
            ' Show error to user.
            Me.sbrStatus.Text = "Unable to retrieve TEMP directory path."
        End Try

        ' Set txtTempDirectory equal to the Temp path.
        Me.txtTempDirectory.Text = tempPathString

    End Sub


    ' This subroutine uses the temp file that was created earlier.
    Private Sub btnUseTempFilebtnUseTempFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseTempFilebtnUseTempFile.Click

        ' Clear the Status Bar or show error if there is no current file
        If m_FileName = "" Then
            Me.sbrStatus.Text = "Temp file not yet created."
            Return
        Else
            Me.sbrStatus.Text = ""
        End If

        ' Attempt to use the temporary file, by adding some text to it
        '   and reading the text back out.
        Try
            ' Write to the temp file.
            Dim myWriter As StreamWriter = File.AppendText(m_FileName)
            myWriter.WriteLine("Data written to temporary file.")
            myWriter.Flush()
            myWriter.Close()

            ' Read from the temp file.
            Dim myReader As StreamReader = File.OpenText(m_FileName)
            ' Show contents of temp file to user.
            Me.sbrStatus.Text = "Temp file: " + myReader.ReadToEnd()
            myReader.Close()

        Catch exc As Exception
            ' Show error to user.
            Me.sbrStatus.Text = "Error writing to or reading from Temp file."
        End Try
    End Sub

End Class