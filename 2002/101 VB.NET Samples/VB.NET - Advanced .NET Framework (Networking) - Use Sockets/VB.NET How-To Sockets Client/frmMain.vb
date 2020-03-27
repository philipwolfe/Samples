'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Net.Sockets
Imports System.Text
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
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents tpChatPage As System.Windows.Forms.TabPage
    Friend WithEvents tpListUsers As System.Windows.Forms.TabPage
    Friend WithEvents lstUsers As System.Windows.Forms.ListBox
    Friend WithEvents btnListUsers As System.Windows.Forms.Button
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpChatPage = New System.Windows.Forms.TabPage()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.txtDisplay = New System.Windows.Forms.TextBox()
        Me.tpListUsers = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnListUsers = New System.Windows.Forms.Button()
        Me.lstUsers = New System.Windows.Forms.ListBox()
        Me.TabControl1.SuspendLayout()
        Me.tpChatPage.SuspendLayout()
        Me.tpListUsers.SuspendLayout()
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
        Me.TabControl1.AccessibleDescription = CType(resources.GetObject("TabControl1.AccessibleDescription"), String)
        Me.TabControl1.AccessibleName = CType(resources.GetObject("TabControl1.AccessibleName"), String)
        Me.TabControl1.Alignment = CType(resources.GetObject("TabControl1.Alignment"), System.Windows.Forms.TabAlignment)
        Me.TabControl1.Anchor = CType(resources.GetObject("TabControl1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = CType(resources.GetObject("TabControl1.Appearance"), System.Windows.Forms.TabAppearance)
        Me.TabControl1.BackgroundImage = CType(resources.GetObject("TabControl1.BackgroundImage"), System.Drawing.Image)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpChatPage, Me.tpListUsers})
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
        'tpChatPage
        '
        Me.tpChatPage.AccessibleDescription = resources.GetString("tpChatPage.AccessibleDescription")
        Me.tpChatPage.AccessibleName = resources.GetString("tpChatPage.AccessibleName")
        Me.tpChatPage.Anchor = CType(resources.GetObject("tpChatPage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpChatPage.AutoScroll = CType(resources.GetObject("tpChatPage.AutoScroll"), Boolean)
        Me.tpChatPage.AutoScrollMargin = CType(resources.GetObject("tpChatPage.AutoScrollMargin"), System.Drawing.Size)
        Me.tpChatPage.AutoScrollMinSize = CType(resources.GetObject("tpChatPage.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpChatPage.BackgroundImage = CType(resources.GetObject("tpChatPage.BackgroundImage"), System.Drawing.Image)
        Me.tpChatPage.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInstructions, Me.btnSend, Me.txtSend, Me.txtDisplay})
        Me.tpChatPage.Dock = CType(resources.GetObject("tpChatPage.Dock"), System.Windows.Forms.DockStyle)
        Me.tpChatPage.Enabled = CType(resources.GetObject("tpChatPage.Enabled"), Boolean)
        Me.tpChatPage.Font = CType(resources.GetObject("tpChatPage.Font"), System.Drawing.Font)
        Me.tpChatPage.ImageIndex = CType(resources.GetObject("tpChatPage.ImageIndex"), Integer)
        Me.tpChatPage.ImeMode = CType(resources.GetObject("tpChatPage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpChatPage.Location = CType(resources.GetObject("tpChatPage.Location"), System.Drawing.Point)
        Me.tpChatPage.Name = "tpChatPage"
        Me.tpChatPage.RightToLeft = CType(resources.GetObject("tpChatPage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpChatPage.Size = CType(resources.GetObject("tpChatPage.Size"), System.Drawing.Size)
        Me.tpChatPage.TabIndex = CType(resources.GetObject("tpChatPage.TabIndex"), Integer)
        Me.tpChatPage.Text = resources.GetString("tpChatPage.Text")
        Me.tpChatPage.ToolTipText = resources.GetString("tpChatPage.ToolTipText")
        Me.tpChatPage.Visible = CType(resources.GetObject("tpChatPage.Visible"), Boolean)
        '
        'lblInstructions
        '
        Me.lblInstructions.AccessibleDescription = resources.GetString("lblInstructions.AccessibleDescription")
        Me.lblInstructions.AccessibleName = resources.GetString("lblInstructions.AccessibleName")
        Me.lblInstructions.Anchor = CType(resources.GetObject("lblInstructions.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblInstructions.AutoSize = CType(resources.GetObject("lblInstructions.AutoSize"), Boolean)
        Me.lblInstructions.Dock = CType(resources.GetObject("lblInstructions.Dock"), System.Windows.Forms.DockStyle)
        Me.lblInstructions.Enabled = CType(resources.GetObject("lblInstructions.Enabled"), Boolean)
        Me.lblInstructions.Font = CType(resources.GetObject("lblInstructions.Font"), System.Drawing.Font)
        Me.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.lblInstructions.Image = CType(resources.GetObject("lblInstructions.Image"), System.Drawing.Image)
        Me.lblInstructions.ImageAlign = CType(resources.GetObject("lblInstructions.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblInstructions.ImageIndex = CType(resources.GetObject("lblInstructions.ImageIndex"), Integer)
        Me.lblInstructions.ImeMode = CType(resources.GetObject("lblInstructions.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblInstructions.Location = CType(resources.GetObject("lblInstructions.Location"), System.Drawing.Point)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.RightToLeft = CType(resources.GetObject("lblInstructions.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblInstructions.Size = CType(resources.GetObject("lblInstructions.Size"), System.Drawing.Size)
        Me.lblInstructions.TabIndex = CType(resources.GetObject("lblInstructions.TabIndex"), Integer)
        Me.lblInstructions.Text = resources.GetString("lblInstructions.Text")
        Me.lblInstructions.TextAlign = CType(resources.GetObject("lblInstructions.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblInstructions.Visible = CType(resources.GetObject("lblInstructions.Visible"), Boolean)
        '
        'btnSend
        '
        Me.btnSend.AccessibleDescription = resources.GetString("btnSend.AccessibleDescription")
        Me.btnSend.AccessibleName = resources.GetString("btnSend.AccessibleName")
        Me.btnSend.Anchor = CType(resources.GetObject("btnSend.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSend.BackgroundImage = CType(resources.GetObject("btnSend.BackgroundImage"), System.Drawing.Image)
        Me.btnSend.Dock = CType(resources.GetObject("btnSend.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSend.Enabled = CType(resources.GetObject("btnSend.Enabled"), Boolean)
        Me.btnSend.FlatStyle = CType(resources.GetObject("btnSend.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSend.Font = CType(resources.GetObject("btnSend.Font"), System.Drawing.Font)
        Me.btnSend.Image = CType(resources.GetObject("btnSend.Image"), System.Drawing.Image)
        Me.btnSend.ImageAlign = CType(resources.GetObject("btnSend.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSend.ImageIndex = CType(resources.GetObject("btnSend.ImageIndex"), Integer)
        Me.btnSend.ImeMode = CType(resources.GetObject("btnSend.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSend.Location = CType(resources.GetObject("btnSend.Location"), System.Drawing.Point)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.RightToLeft = CType(resources.GetObject("btnSend.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSend.Size = CType(resources.GetObject("btnSend.Size"), System.Drawing.Size)
        Me.btnSend.TabIndex = CType(resources.GetObject("btnSend.TabIndex"), Integer)
        Me.btnSend.Text = resources.GetString("btnSend.Text")
        Me.btnSend.TextAlign = CType(resources.GetObject("btnSend.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSend.Visible = CType(resources.GetObject("btnSend.Visible"), Boolean)
        '
        'txtSend
        '
        Me.txtSend.AccessibleDescription = resources.GetString("txtSend.AccessibleDescription")
        Me.txtSend.AccessibleName = resources.GetString("txtSend.AccessibleName")
        Me.txtSend.Anchor = CType(resources.GetObject("txtSend.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtSend.AutoSize = CType(resources.GetObject("txtSend.AutoSize"), Boolean)
        Me.txtSend.BackgroundImage = CType(resources.GetObject("txtSend.BackgroundImage"), System.Drawing.Image)
        Me.txtSend.Dock = CType(resources.GetObject("txtSend.Dock"), System.Windows.Forms.DockStyle)
        Me.txtSend.Enabled = CType(resources.GetObject("txtSend.Enabled"), Boolean)
        Me.txtSend.Font = CType(resources.GetObject("txtSend.Font"), System.Drawing.Font)
        Me.txtSend.ImeMode = CType(resources.GetObject("txtSend.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtSend.Location = CType(resources.GetObject("txtSend.Location"), System.Drawing.Point)
        Me.txtSend.MaxLength = CType(resources.GetObject("txtSend.MaxLength"), Integer)
        Me.txtSend.Multiline = CType(resources.GetObject("txtSend.Multiline"), Boolean)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.PasswordChar = CType(resources.GetObject("txtSend.PasswordChar"), Char)
        Me.txtSend.RightToLeft = CType(resources.GetObject("txtSend.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtSend.ScrollBars = CType(resources.GetObject("txtSend.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtSend.Size = CType(resources.GetObject("txtSend.Size"), System.Drawing.Size)
        Me.txtSend.TabIndex = CType(resources.GetObject("txtSend.TabIndex"), Integer)
        Me.txtSend.Text = resources.GetString("txtSend.Text")
        Me.txtSend.TextAlign = CType(resources.GetObject("txtSend.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtSend.Visible = CType(resources.GetObject("txtSend.Visible"), Boolean)
        Me.txtSend.WordWrap = CType(resources.GetObject("txtSend.WordWrap"), Boolean)
        '
        'txtDisplay
        '
        Me.txtDisplay.AccessibleDescription = resources.GetString("txtDisplay.AccessibleDescription")
        Me.txtDisplay.AccessibleName = resources.GetString("txtDisplay.AccessibleName")
        Me.txtDisplay.Anchor = CType(resources.GetObject("txtDisplay.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtDisplay.AutoSize = CType(resources.GetObject("txtDisplay.AutoSize"), Boolean)
        Me.txtDisplay.BackColor = System.Drawing.SystemColors.Window
        Me.txtDisplay.BackgroundImage = CType(resources.GetObject("txtDisplay.BackgroundImage"), System.Drawing.Image)
        Me.txtDisplay.Dock = CType(resources.GetObject("txtDisplay.Dock"), System.Windows.Forms.DockStyle)
        Me.txtDisplay.Enabled = CType(resources.GetObject("txtDisplay.Enabled"), Boolean)
        Me.txtDisplay.Font = CType(resources.GetObject("txtDisplay.Font"), System.Drawing.Font)
        Me.txtDisplay.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDisplay.ImeMode = CType(resources.GetObject("txtDisplay.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtDisplay.Location = CType(resources.GetObject("txtDisplay.Location"), System.Drawing.Point)
        Me.txtDisplay.MaxLength = CType(resources.GetObject("txtDisplay.MaxLength"), Integer)
        Me.txtDisplay.Multiline = CType(resources.GetObject("txtDisplay.Multiline"), Boolean)
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.PasswordChar = CType(resources.GetObject("txtDisplay.PasswordChar"), Char)
        Me.txtDisplay.ReadOnly = True
        Me.txtDisplay.RightToLeft = CType(resources.GetObject("txtDisplay.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtDisplay.ScrollBars = CType(resources.GetObject("txtDisplay.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtDisplay.Size = CType(resources.GetObject("txtDisplay.Size"), System.Drawing.Size)
        Me.txtDisplay.TabIndex = CType(resources.GetObject("txtDisplay.TabIndex"), Integer)
        Me.txtDisplay.Text = resources.GetString("txtDisplay.Text")
        Me.txtDisplay.TextAlign = CType(resources.GetObject("txtDisplay.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtDisplay.Visible = CType(resources.GetObject("txtDisplay.Visible"), Boolean)
        Me.txtDisplay.WordWrap = CType(resources.GetObject("txtDisplay.WordWrap"), Boolean)
        '
        'tpListUsers
        '
        Me.tpListUsers.AccessibleDescription = resources.GetString("tpListUsers.AccessibleDescription")
        Me.tpListUsers.AccessibleName = resources.GetString("tpListUsers.AccessibleName")
        Me.tpListUsers.Anchor = CType(resources.GetObject("tpListUsers.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpListUsers.AutoScroll = CType(resources.GetObject("tpListUsers.AutoScroll"), Boolean)
        Me.tpListUsers.AutoScrollMargin = CType(resources.GetObject("tpListUsers.AutoScrollMargin"), System.Drawing.Size)
        Me.tpListUsers.AutoScrollMinSize = CType(resources.GetObject("tpListUsers.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpListUsers.BackgroundImage = CType(resources.GetObject("tpListUsers.BackgroundImage"), System.Drawing.Image)
        Me.tpListUsers.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnListUsers, Me.lstUsers})
        Me.tpListUsers.Dock = CType(resources.GetObject("tpListUsers.Dock"), System.Windows.Forms.DockStyle)
        Me.tpListUsers.Enabled = CType(resources.GetObject("tpListUsers.Enabled"), Boolean)
        Me.tpListUsers.Font = CType(resources.GetObject("tpListUsers.Font"), System.Drawing.Font)
        Me.tpListUsers.ImageIndex = CType(resources.GetObject("tpListUsers.ImageIndex"), Integer)
        Me.tpListUsers.ImeMode = CType(resources.GetObject("tpListUsers.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpListUsers.Location = CType(resources.GetObject("tpListUsers.Location"), System.Drawing.Point)
        Me.tpListUsers.Name = "tpListUsers"
        Me.tpListUsers.RightToLeft = CType(resources.GetObject("tpListUsers.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpListUsers.Size = CType(resources.GetObject("tpListUsers.Size"), System.Drawing.Size)
        Me.tpListUsers.TabIndex = CType(resources.GetObject("tpListUsers.TabIndex"), Integer)
        Me.tpListUsers.Text = resources.GetString("tpListUsers.Text")
        Me.tpListUsers.ToolTipText = resources.GetString("tpListUsers.ToolTipText")
        Me.tpListUsers.Visible = CType(resources.GetObject("tpListUsers.Visible"), Boolean)
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
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
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
        'btnListUsers
        '
        Me.btnListUsers.AccessibleDescription = CType(resources.GetObject("btnListUsers.AccessibleDescription"), String)
        Me.btnListUsers.AccessibleName = CType(resources.GetObject("btnListUsers.AccessibleName"), String)
        Me.btnListUsers.Anchor = CType(resources.GetObject("btnListUsers.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnListUsers.BackgroundImage = CType(resources.GetObject("btnListUsers.BackgroundImage"), System.Drawing.Image)
        Me.btnListUsers.Dock = CType(resources.GetObject("btnListUsers.Dock"), System.Windows.Forms.DockStyle)
        Me.btnListUsers.Enabled = CType(resources.GetObject("btnListUsers.Enabled"), Boolean)
        Me.btnListUsers.FlatStyle = CType(resources.GetObject("btnListUsers.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnListUsers.Font = CType(resources.GetObject("btnListUsers.Font"), System.Drawing.Font)
        Me.btnListUsers.Image = CType(resources.GetObject("btnListUsers.Image"), System.Drawing.Image)
        Me.btnListUsers.ImageAlign = CType(resources.GetObject("btnListUsers.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnListUsers.ImageIndex = CType(resources.GetObject("btnListUsers.ImageIndex"), Integer)
        Me.btnListUsers.ImeMode = CType(resources.GetObject("btnListUsers.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnListUsers.Location = CType(resources.GetObject("btnListUsers.Location"), System.Drawing.Point)
        Me.btnListUsers.Name = "btnListUsers"
        Me.btnListUsers.RightToLeft = CType(resources.GetObject("btnListUsers.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnListUsers.Size = CType(resources.GetObject("btnListUsers.Size"), System.Drawing.Size)
        Me.btnListUsers.TabIndex = CType(resources.GetObject("btnListUsers.TabIndex"), Integer)
        Me.btnListUsers.Text = resources.GetString("btnListUsers.Text")
        Me.btnListUsers.TextAlign = CType(resources.GetObject("btnListUsers.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnListUsers.Visible = CType(resources.GetObject("btnListUsers.Visible"), Boolean)
        '
        'lstUsers
        '
        Me.lstUsers.AccessibleDescription = CType(resources.GetObject("lstUsers.AccessibleDescription"), String)
        Me.lstUsers.AccessibleName = CType(resources.GetObject("lstUsers.AccessibleName"), String)
        Me.lstUsers.Anchor = CType(resources.GetObject("lstUsers.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lstUsers.BackgroundImage = CType(resources.GetObject("lstUsers.BackgroundImage"), System.Drawing.Image)
        Me.lstUsers.ColumnWidth = CType(resources.GetObject("lstUsers.ColumnWidth"), Integer)
        Me.lstUsers.Dock = CType(resources.GetObject("lstUsers.Dock"), System.Windows.Forms.DockStyle)
        Me.lstUsers.Enabled = CType(resources.GetObject("lstUsers.Enabled"), Boolean)
        Me.lstUsers.Font = CType(resources.GetObject("lstUsers.Font"), System.Drawing.Font)
        Me.lstUsers.HorizontalExtent = CType(resources.GetObject("lstUsers.HorizontalExtent"), Integer)
        Me.lstUsers.HorizontalScrollbar = CType(resources.GetObject("lstUsers.HorizontalScrollbar"), Boolean)
        Me.lstUsers.ImeMode = CType(resources.GetObject("lstUsers.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lstUsers.IntegralHeight = CType(resources.GetObject("lstUsers.IntegralHeight"), Boolean)
        Me.lstUsers.ItemHeight = CType(resources.GetObject("lstUsers.ItemHeight"), Integer)
        Me.lstUsers.Location = CType(resources.GetObject("lstUsers.Location"), System.Drawing.Point)
        Me.lstUsers.Name = "lstUsers"
        Me.lstUsers.RightToLeft = CType(resources.GetObject("lstUsers.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lstUsers.ScrollAlwaysVisible = CType(resources.GetObject("lstUsers.ScrollAlwaysVisible"), Boolean)
        Me.lstUsers.Size = CType(resources.GetObject("lstUsers.Size"), System.Drawing.Size)
        Me.lstUsers.TabIndex = CType(resources.GetObject("lstUsers.TabIndex"), Integer)
        Me.lstUsers.Visible = CType(resources.GetObject("lstUsers.Visible"), Boolean)
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
        Me.tpChatPage.ResumeLayout(False)
        Me.tpListUsers.ResumeLayout(False)
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

    Const READ_BUFFER_SIZE As Integer = 255
    Const PORT_NUM As Integer = 10000

    Private client As TcpClient
    Private readBuffer(READ_BUFFER_SIZE) As Byte

    ' Pop up a Connect user dialog and send a message requesting user to log in to chat.
    Sub AttemptLogin()
        Dim frmConnectUser As New frmConnectUser()
        frmConnectUser.StartPosition = FormStartPosition.CenterParent
        frmConnectUser.ShowDialog(Me)
        SendData("CONNECT|" & frmConnectUser.txtUserLogin.Text)
        frmConnectUser.Dispose()
    End Sub

    ' Clear the Users listbox, and request the server to send the list of users.
    Private Sub btnListUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListUsers.Click
        lstUsers.Items.Clear()
        SendData("REQUESTUSERS")
    End Sub

    ' Send the contents of the Send textbox if it isn't blank.
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If txtSend.Text <> "" Then
            DisplayText("You say: " & txtSend.Text & Chr(13) & Chr(10))
            SendData("CHAT|" & txtSend.Text)
            txtSend.Text = ""
        End If
    End Sub

    ' Writes text to the output textbox.
    Private Sub DisplayText(ByVal text As String)
        txtDisplay.AppendText(text)
    End Sub

    ' This is the callback function for TcpClient.GetStream.Begin to get an
    ' asynchronous read.
    Private Sub DoRead(ByVal ar As IAsyncResult)
        Dim BytesRead As Integer
        Dim strMessage As String

        Try
            ' Finish asynchronous read into readBuffer and return number of bytes read.
            BytesRead = client.GetStream.EndRead(ar)
            If BytesRead < 1 Then
                ' If no bytes were read server has close.  Disable input window.
                MarkAsDisconnected()
                Exit Sub
            End If

            ' Convert the byte array the message was saved into, minus two for the
            ' Chr(13) and Chr(10)
            strMessage = Encoding.ASCII.GetString(readBuffer, 0, BytesRead - 2)

            ProcessCommands(strMessage)

            ' Start a new asynchronous read into readBuffer.
            client.GetStream.BeginRead(readBuffer, 0, READ_BUFFER_SIZE, AddressOf DoRead, Nothing)
        Catch e As Exception
            MarkAsDisconnected()
        End Try
    End Sub

    ' Send the server a disconnect message  
    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' Send only if server is still running.
        If btnSend.Enabled = True Then
            SendData("DISCONNECT")
        End If
    End Sub

    ' When the form starts, this subroutine will connect to the server and attempt to
    ' log in.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frmConnectUser As New frmConnectUser()

        Try
            ' The TcpClient is a subclass of Socket, providing higher level 
            ' functionality like streaming.
            client = New TcpClient("localhost", PORT_NUM)

            ' Start an asynchronous read invoking DoRead to avoid lagging the user
            ' interface.
            client.GetStream.BeginRead(readBuffer, 0, READ_BUFFER_SIZE, AddressOf DoRead, Nothing)

            ' Make sure the window is showing before popping up connection dialog.
            Me.Show()

            AttemptLogin()
        Catch Ex As Exception
            MsgBox("Server is not active.  Please start server and try again.", _
                   MsgBoxStyle.Exclamation, Me.Text)
            Me.Dispose()
        End Try

    End Sub

    ' This subroutine adds a list of users to listbox.
    Private Sub ListUsers(ByVal users() As String)
        Dim I As Integer
        For I = 1 To users.Length - 1
            lstUsers.Items.Add(users(I))
        Next
    End Sub

    ' When the server disconnects, prevent further chat messages from being sent.
    Private Sub MarkAsDisconnected()
        txtSend.ReadOnly = True
        btnSend.Enabled = False
    End Sub

    ' Process the command received from the server, and take appropriate action.
    Private Sub ProcessCommands(ByVal strMessage As String)
        Dim dataArray() As String

        ' Message parts are divided by "|"  Break the string into an array accordingly.
        dataArray = strMessage.Split(Chr(124))

        ' dataArray(0) is the command.
        Select Case dataArray(0)
            Case "JOIN"
                ' Server acknowledged login.
                DisplayText("You have joined the chat" & Chr(13) & Chr(10))
            Case "CHAT"
                ' Received chat message, display it.
                DisplayText(dataArray(1) & Chr(13) & Chr(10))
            Case "REFUSE"
                ' Server refused login with this user name, try to log in with another.
                AttemptLogin()
            Case "LISTUSERS"
                ' Server sent a list of users.
                ListUsers(dataArray)
            Case "BROAD"
                ' Server sent a broadcast message
                DisplayText("ServerMessage: " & dataArray(1) & Chr(13) & Chr(10))
        End Select
    End Sub

    ' Use a StreamWriter to send a message to server.
    Private Sub SendData(ByVal data As String)
        Dim writer As New IO.StreamWriter(client.GetStream)
        writer.Write(data & vbCr)
        writer.Flush()
    End Sub
End Class


