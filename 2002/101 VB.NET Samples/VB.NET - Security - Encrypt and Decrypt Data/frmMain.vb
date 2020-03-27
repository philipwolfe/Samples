'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO
Imports System.Text.Encoding
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography

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
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents optTripleDESAdv As System.Windows.Forms.RadioButton
    Friend WithEvents optRijndaelAdv As System.Windows.Forms.RadioButton
    Friend WithEvents btnCreateKey As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents chkAdvanced As System.Windows.Forms.CheckBox
    Friend WithEvents odlgSourceFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtCrypto As System.Windows.Forms.TextBox
    Friend WithEvents btnDecrypt As System.Windows.Forms.Button
    Friend WithEvents btnEncrypt As System.Windows.Forms.Button
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnDecrypt = New System.Windows.Forms.Button()
        Me.btnEncrypt = New System.Windows.Forms.Button()
        Me.txtCrypto = New System.Windows.Forms.TextBox()
        Me.optTripleDESAdv = New System.Windows.Forms.RadioButton()
        Me.optRijndaelAdv = New System.Windows.Forms.RadioButton()
        Me.btnCreateKey = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.chkAdvanced = New System.Windows.Forms.CheckBox()
        Me.odlgSourceFile = New System.Windows.Forms.OpenFileDialog()
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
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = resources.GetString("btnLoad.AccessibleDescription")
        Me.btnLoad.AccessibleName = resources.GetString("btnLoad.AccessibleName")
        Me.btnLoad.Anchor = CType(resources.GetObject("btnLoad.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.BackgroundImage = CType(resources.GetObject("btnLoad.BackgroundImage"), System.Drawing.Image)
        Me.btnLoad.Dock = CType(resources.GetObject("btnLoad.Dock"), System.Windows.Forms.DockStyle)
        Me.btnLoad.Enabled = CType(resources.GetObject("btnLoad.Enabled"), Boolean)
        Me.btnLoad.FlatStyle = CType(resources.GetObject("btnLoad.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnLoad.Font = CType(resources.GetObject("btnLoad.Font"), System.Drawing.Font)
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.ImageAlign = CType(resources.GetObject("btnLoad.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnLoad.ImageIndex = CType(resources.GetObject("btnLoad.ImageIndex"), Integer)
        Me.btnLoad.ImeMode = CType(resources.GetObject("btnLoad.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnLoad.Location = CType(resources.GetObject("btnLoad.Location"), System.Drawing.Point)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.RightToLeft = CType(resources.GetObject("btnLoad.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnLoad.Size = CType(resources.GetObject("btnLoad.Size"), System.Drawing.Size)
        Me.btnLoad.TabIndex = CType(resources.GetObject("btnLoad.TabIndex"), Integer)
        Me.btnLoad.Text = resources.GetString("btnLoad.Text")
        Me.btnLoad.TextAlign = CType(resources.GetObject("btnLoad.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnLoad.Visible = CType(resources.GetObject("btnLoad.Visible"), Boolean)
        '
        'btnDecrypt
        '
        Me.btnDecrypt.AccessibleDescription = resources.GetString("btnDecrypt.AccessibleDescription")
        Me.btnDecrypt.AccessibleName = resources.GetString("btnDecrypt.AccessibleName")
        Me.btnDecrypt.Anchor = CType(resources.GetObject("btnDecrypt.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnDecrypt.BackgroundImage = CType(resources.GetObject("btnDecrypt.BackgroundImage"), System.Drawing.Image)
        Me.btnDecrypt.Dock = CType(resources.GetObject("btnDecrypt.Dock"), System.Windows.Forms.DockStyle)
        Me.btnDecrypt.Enabled = CType(resources.GetObject("btnDecrypt.Enabled"), Boolean)
        Me.btnDecrypt.FlatStyle = CType(resources.GetObject("btnDecrypt.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnDecrypt.Font = CType(resources.GetObject("btnDecrypt.Font"), System.Drawing.Font)
        Me.btnDecrypt.Image = CType(resources.GetObject("btnDecrypt.Image"), System.Drawing.Image)
        Me.btnDecrypt.ImageAlign = CType(resources.GetObject("btnDecrypt.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnDecrypt.ImageIndex = CType(resources.GetObject("btnDecrypt.ImageIndex"), Integer)
        Me.btnDecrypt.ImeMode = CType(resources.GetObject("btnDecrypt.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnDecrypt.Location = CType(resources.GetObject("btnDecrypt.Location"), System.Drawing.Point)
        Me.btnDecrypt.Name = "btnDecrypt"
        Me.btnDecrypt.RightToLeft = CType(resources.GetObject("btnDecrypt.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnDecrypt.Size = CType(resources.GetObject("btnDecrypt.Size"), System.Drawing.Size)
        Me.btnDecrypt.TabIndex = CType(resources.GetObject("btnDecrypt.TabIndex"), Integer)
        Me.btnDecrypt.Text = resources.GetString("btnDecrypt.Text")
        Me.btnDecrypt.TextAlign = CType(resources.GetObject("btnDecrypt.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnDecrypt.Visible = CType(resources.GetObject("btnDecrypt.Visible"), Boolean)
        '
        'btnEncrypt
        '
        Me.btnEncrypt.AccessibleDescription = resources.GetString("btnEncrypt.AccessibleDescription")
        Me.btnEncrypt.AccessibleName = resources.GetString("btnEncrypt.AccessibleName")
        Me.btnEncrypt.Anchor = CType(resources.GetObject("btnEncrypt.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnEncrypt.BackgroundImage = CType(resources.GetObject("btnEncrypt.BackgroundImage"), System.Drawing.Image)
        Me.btnEncrypt.Dock = CType(resources.GetObject("btnEncrypt.Dock"), System.Windows.Forms.DockStyle)
        Me.btnEncrypt.Enabled = CType(resources.GetObject("btnEncrypt.Enabled"), Boolean)
        Me.btnEncrypt.FlatStyle = CType(resources.GetObject("btnEncrypt.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnEncrypt.Font = CType(resources.GetObject("btnEncrypt.Font"), System.Drawing.Font)
        Me.btnEncrypt.Image = CType(resources.GetObject("btnEncrypt.Image"), System.Drawing.Image)
        Me.btnEncrypt.ImageAlign = CType(resources.GetObject("btnEncrypt.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnEncrypt.ImageIndex = CType(resources.GetObject("btnEncrypt.ImageIndex"), Integer)
        Me.btnEncrypt.ImeMode = CType(resources.GetObject("btnEncrypt.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnEncrypt.Location = CType(resources.GetObject("btnEncrypt.Location"), System.Drawing.Point)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.RightToLeft = CType(resources.GetObject("btnEncrypt.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnEncrypt.Size = CType(resources.GetObject("btnEncrypt.Size"), System.Drawing.Size)
        Me.btnEncrypt.TabIndex = CType(resources.GetObject("btnEncrypt.TabIndex"), Integer)
        Me.btnEncrypt.Text = resources.GetString("btnEncrypt.Text")
        Me.btnEncrypt.TextAlign = CType(resources.GetObject("btnEncrypt.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnEncrypt.Visible = CType(resources.GetObject("btnEncrypt.Visible"), Boolean)
        '
        'txtCrypto
        '
        Me.txtCrypto.AccessibleDescription = resources.GetString("txtCrypto.AccessibleDescription")
        Me.txtCrypto.AccessibleName = resources.GetString("txtCrypto.AccessibleName")
        Me.txtCrypto.Anchor = CType(resources.GetObject("txtCrypto.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCrypto.AutoSize = CType(resources.GetObject("txtCrypto.AutoSize"), Boolean)
        Me.txtCrypto.BackgroundImage = CType(resources.GetObject("txtCrypto.BackgroundImage"), System.Drawing.Image)
        Me.txtCrypto.Dock = CType(resources.GetObject("txtCrypto.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCrypto.Enabled = CType(resources.GetObject("txtCrypto.Enabled"), Boolean)
        Me.txtCrypto.Font = CType(resources.GetObject("txtCrypto.Font"), System.Drawing.Font)
        Me.txtCrypto.ImeMode = CType(resources.GetObject("txtCrypto.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCrypto.Location = CType(resources.GetObject("txtCrypto.Location"), System.Drawing.Point)
        Me.txtCrypto.MaxLength = CType(resources.GetObject("txtCrypto.MaxLength"), Integer)
        Me.txtCrypto.Multiline = CType(resources.GetObject("txtCrypto.Multiline"), Boolean)
        Me.txtCrypto.Name = "txtCrypto"
        Me.txtCrypto.PasswordChar = CType(resources.GetObject("txtCrypto.PasswordChar"), Char)
        Me.txtCrypto.ReadOnly = True
        Me.txtCrypto.RightToLeft = CType(resources.GetObject("txtCrypto.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCrypto.ScrollBars = CType(resources.GetObject("txtCrypto.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCrypto.Size = CType(resources.GetObject("txtCrypto.Size"), System.Drawing.Size)
        Me.txtCrypto.TabIndex = CType(resources.GetObject("txtCrypto.TabIndex"), Integer)
        Me.txtCrypto.Text = resources.GetString("txtCrypto.Text")
        Me.txtCrypto.TextAlign = CType(resources.GetObject("txtCrypto.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCrypto.Visible = CType(resources.GetObject("txtCrypto.Visible"), Boolean)
        Me.txtCrypto.WordWrap = CType(resources.GetObject("txtCrypto.WordWrap"), Boolean)
        '
        'optTripleDESAdv
        '
        Me.optTripleDESAdv.AccessibleDescription = resources.GetString("optTripleDESAdv.AccessibleDescription")
        Me.optTripleDESAdv.AccessibleName = resources.GetString("optTripleDESAdv.AccessibleName")
        Me.optTripleDESAdv.Anchor = CType(resources.GetObject("optTripleDESAdv.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optTripleDESAdv.Appearance = CType(resources.GetObject("optTripleDESAdv.Appearance"), System.Windows.Forms.Appearance)
        Me.optTripleDESAdv.BackgroundImage = CType(resources.GetObject("optTripleDESAdv.BackgroundImage"), System.Drawing.Image)
        Me.optTripleDESAdv.CheckAlign = CType(resources.GetObject("optTripleDESAdv.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optTripleDESAdv.Dock = CType(resources.GetObject("optTripleDESAdv.Dock"), System.Windows.Forms.DockStyle)
        Me.optTripleDESAdv.Enabled = CType(resources.GetObject("optTripleDESAdv.Enabled"), Boolean)
        Me.optTripleDESAdv.FlatStyle = CType(resources.GetObject("optTripleDESAdv.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optTripleDESAdv.Font = CType(resources.GetObject("optTripleDESAdv.Font"), System.Drawing.Font)
        Me.optTripleDESAdv.Image = CType(resources.GetObject("optTripleDESAdv.Image"), System.Drawing.Image)
        Me.optTripleDESAdv.ImageAlign = CType(resources.GetObject("optTripleDESAdv.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optTripleDESAdv.ImageIndex = CType(resources.GetObject("optTripleDESAdv.ImageIndex"), Integer)
        Me.optTripleDESAdv.ImeMode = CType(resources.GetObject("optTripleDESAdv.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optTripleDESAdv.Location = CType(resources.GetObject("optTripleDESAdv.Location"), System.Drawing.Point)
        Me.optTripleDESAdv.Name = "optTripleDESAdv"
        Me.optTripleDESAdv.RightToLeft = CType(resources.GetObject("optTripleDESAdv.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optTripleDESAdv.Size = CType(resources.GetObject("optTripleDESAdv.Size"), System.Drawing.Size)
        Me.optTripleDESAdv.TabIndex = CType(resources.GetObject("optTripleDESAdv.TabIndex"), Integer)
        Me.optTripleDESAdv.Tag = ""
        Me.optTripleDESAdv.Text = resources.GetString("optTripleDESAdv.Text")
        Me.optTripleDESAdv.TextAlign = CType(resources.GetObject("optTripleDESAdv.TextAlign"), System.Drawing.ContentAlignment)
        Me.optTripleDESAdv.Visible = CType(resources.GetObject("optTripleDESAdv.Visible"), Boolean)
        '
        'optRijndaelAdv
        '
        Me.optRijndaelAdv.AccessibleDescription = resources.GetString("optRijndaelAdv.AccessibleDescription")
        Me.optRijndaelAdv.AccessibleName = resources.GetString("optRijndaelAdv.AccessibleName")
        Me.optRijndaelAdv.Anchor = CType(resources.GetObject("optRijndaelAdv.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optRijndaelAdv.Appearance = CType(resources.GetObject("optRijndaelAdv.Appearance"), System.Windows.Forms.Appearance)
        Me.optRijndaelAdv.BackgroundImage = CType(resources.GetObject("optRijndaelAdv.BackgroundImage"), System.Drawing.Image)
        Me.optRijndaelAdv.CheckAlign = CType(resources.GetObject("optRijndaelAdv.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optRijndaelAdv.Checked = True
        Me.optRijndaelAdv.Dock = CType(resources.GetObject("optRijndaelAdv.Dock"), System.Windows.Forms.DockStyle)
        Me.optRijndaelAdv.Enabled = CType(resources.GetObject("optRijndaelAdv.Enabled"), Boolean)
        Me.optRijndaelAdv.FlatStyle = CType(resources.GetObject("optRijndaelAdv.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optRijndaelAdv.Font = CType(resources.GetObject("optRijndaelAdv.Font"), System.Drawing.Font)
        Me.optRijndaelAdv.Image = CType(resources.GetObject("optRijndaelAdv.Image"), System.Drawing.Image)
        Me.optRijndaelAdv.ImageAlign = CType(resources.GetObject("optRijndaelAdv.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optRijndaelAdv.ImageIndex = CType(resources.GetObject("optRijndaelAdv.ImageIndex"), Integer)
        Me.optRijndaelAdv.ImeMode = CType(resources.GetObject("optRijndaelAdv.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optRijndaelAdv.Location = CType(resources.GetObject("optRijndaelAdv.Location"), System.Drawing.Point)
        Me.optRijndaelAdv.Name = "optRijndaelAdv"
        Me.optRijndaelAdv.RightToLeft = CType(resources.GetObject("optRijndaelAdv.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optRijndaelAdv.Size = CType(resources.GetObject("optRijndaelAdv.Size"), System.Drawing.Size)
        Me.optRijndaelAdv.TabIndex = CType(resources.GetObject("optRijndaelAdv.TabIndex"), Integer)
        Me.optRijndaelAdv.TabStop = True
        Me.optRijndaelAdv.Text = resources.GetString("optRijndaelAdv.Text")
        Me.optRijndaelAdv.TextAlign = CType(resources.GetObject("optRijndaelAdv.TextAlign"), System.Drawing.ContentAlignment)
        Me.optRijndaelAdv.Visible = CType(resources.GetObject("optRijndaelAdv.Visible"), Boolean)
        '
        'btnCreateKey
        '
        Me.btnCreateKey.AccessibleDescription = resources.GetString("btnCreateKey.AccessibleDescription")
        Me.btnCreateKey.AccessibleName = resources.GetString("btnCreateKey.AccessibleName")
        Me.btnCreateKey.Anchor = CType(resources.GetObject("btnCreateKey.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateKey.BackgroundImage = CType(resources.GetObject("btnCreateKey.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateKey.Dock = CType(resources.GetObject("btnCreateKey.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateKey.Enabled = CType(resources.GetObject("btnCreateKey.Enabled"), Boolean)
        Me.btnCreateKey.FlatStyle = CType(resources.GetObject("btnCreateKey.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateKey.Font = CType(resources.GetObject("btnCreateKey.Font"), System.Drawing.Font)
        Me.btnCreateKey.Image = CType(resources.GetObject("btnCreateKey.Image"), System.Drawing.Image)
        Me.btnCreateKey.ImageAlign = CType(resources.GetObject("btnCreateKey.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateKey.ImageIndex = CType(resources.GetObject("btnCreateKey.ImageIndex"), Integer)
        Me.btnCreateKey.ImeMode = CType(resources.GetObject("btnCreateKey.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateKey.Location = CType(resources.GetObject("btnCreateKey.Location"), System.Drawing.Point)
        Me.btnCreateKey.Name = "btnCreateKey"
        Me.btnCreateKey.RightToLeft = CType(resources.GetObject("btnCreateKey.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateKey.Size = CType(resources.GetObject("btnCreateKey.Size"), System.Drawing.Size)
        Me.btnCreateKey.TabIndex = CType(resources.GetObject("btnCreateKey.TabIndex"), Integer)
        Me.btnCreateKey.Text = resources.GetString("btnCreateKey.Text")
        Me.btnCreateKey.TextAlign = CType(resources.GetObject("btnCreateKey.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateKey.Visible = CType(resources.GetObject("btnCreateKey.Visible"), Boolean)
        '
        'txtPassword
        '
        Me.txtPassword.AccessibleDescription = resources.GetString("txtPassword.AccessibleDescription")
        Me.txtPassword.AccessibleName = resources.GetString("txtPassword.AccessibleName")
        Me.txtPassword.Anchor = CType(resources.GetObject("txtPassword.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.AutoSize = CType(resources.GetObject("txtPassword.AutoSize"), Boolean)
        Me.txtPassword.BackgroundImage = CType(resources.GetObject("txtPassword.BackgroundImage"), System.Drawing.Image)
        Me.txtPassword.Dock = CType(resources.GetObject("txtPassword.Dock"), System.Windows.Forms.DockStyle)
        Me.txtPassword.Enabled = CType(resources.GetObject("txtPassword.Enabled"), Boolean)
        Me.txtPassword.Font = CType(resources.GetObject("txtPassword.Font"), System.Drawing.Font)
        Me.txtPassword.ImeMode = CType(resources.GetObject("txtPassword.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtPassword.Location = CType(resources.GetObject("txtPassword.Location"), System.Drawing.Point)
        Me.txtPassword.MaxLength = CType(resources.GetObject("txtPassword.MaxLength"), Integer)
        Me.txtPassword.Multiline = CType(resources.GetObject("txtPassword.Multiline"), Boolean)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = CType(resources.GetObject("txtPassword.PasswordChar"), Char)
        Me.txtPassword.RightToLeft = CType(resources.GetObject("txtPassword.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtPassword.ScrollBars = CType(resources.GetObject("txtPassword.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtPassword.Size = CType(resources.GetObject("txtPassword.Size"), System.Drawing.Size)
        Me.txtPassword.TabIndex = CType(resources.GetObject("txtPassword.TabIndex"), Integer)
        Me.txtPassword.Text = resources.GetString("txtPassword.Text")
        Me.txtPassword.TextAlign = CType(resources.GetObject("txtPassword.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtPassword.Visible = CType(resources.GetObject("txtPassword.Visible"), Boolean)
        Me.txtPassword.WordWrap = CType(resources.GetObject("txtPassword.WordWrap"), Boolean)
        '
        'lblPassword
        '
        Me.lblPassword.AccessibleDescription = resources.GetString("lblPassword.AccessibleDescription")
        Me.lblPassword.AccessibleName = resources.GetString("lblPassword.AccessibleName")
        Me.lblPassword.Anchor = CType(resources.GetObject("lblPassword.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblPassword.AutoSize = CType(resources.GetObject("lblPassword.AutoSize"), Boolean)
        Me.lblPassword.Dock = CType(resources.GetObject("lblPassword.Dock"), System.Windows.Forms.DockStyle)
        Me.lblPassword.Enabled = CType(resources.GetObject("lblPassword.Enabled"), Boolean)
        Me.lblPassword.Font = CType(resources.GetObject("lblPassword.Font"), System.Drawing.Font)
        Me.lblPassword.Image = CType(resources.GetObject("lblPassword.Image"), System.Drawing.Image)
        Me.lblPassword.ImageAlign = CType(resources.GetObject("lblPassword.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblPassword.ImageIndex = CType(resources.GetObject("lblPassword.ImageIndex"), Integer)
        Me.lblPassword.ImeMode = CType(resources.GetObject("lblPassword.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblPassword.Location = CType(resources.GetObject("lblPassword.Location"), System.Drawing.Point)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.RightToLeft = CType(resources.GetObject("lblPassword.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblPassword.Size = CType(resources.GetObject("lblPassword.Size"), System.Drawing.Size)
        Me.lblPassword.TabIndex = CType(resources.GetObject("lblPassword.TabIndex"), Integer)
        Me.lblPassword.Text = resources.GetString("lblPassword.Text")
        Me.lblPassword.TextAlign = CType(resources.GetObject("lblPassword.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblPassword.Visible = CType(resources.GetObject("lblPassword.Visible"), Boolean)
        '
        'chkAdvanced
        '
        Me.chkAdvanced.AccessibleDescription = resources.GetString("chkAdvanced.AccessibleDescription")
        Me.chkAdvanced.AccessibleName = resources.GetString("chkAdvanced.AccessibleName")
        Me.chkAdvanced.Anchor = CType(resources.GetObject("chkAdvanced.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkAdvanced.Appearance = CType(resources.GetObject("chkAdvanced.Appearance"), System.Windows.Forms.Appearance)
        Me.chkAdvanced.BackgroundImage = CType(resources.GetObject("chkAdvanced.BackgroundImage"), System.Drawing.Image)
        Me.chkAdvanced.CheckAlign = CType(resources.GetObject("chkAdvanced.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkAdvanced.Dock = CType(resources.GetObject("chkAdvanced.Dock"), System.Windows.Forms.DockStyle)
        Me.chkAdvanced.Enabled = CType(resources.GetObject("chkAdvanced.Enabled"), Boolean)
        Me.chkAdvanced.FlatStyle = CType(resources.GetObject("chkAdvanced.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkAdvanced.Font = CType(resources.GetObject("chkAdvanced.Font"), System.Drawing.Font)
        Me.chkAdvanced.Image = CType(resources.GetObject("chkAdvanced.Image"), System.Drawing.Image)
        Me.chkAdvanced.ImageAlign = CType(resources.GetObject("chkAdvanced.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkAdvanced.ImageIndex = CType(resources.GetObject("chkAdvanced.ImageIndex"), Integer)
        Me.chkAdvanced.ImeMode = CType(resources.GetObject("chkAdvanced.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkAdvanced.Location = CType(resources.GetObject("chkAdvanced.Location"), System.Drawing.Point)
        Me.chkAdvanced.Name = "chkAdvanced"
        Me.chkAdvanced.RightToLeft = CType(resources.GetObject("chkAdvanced.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkAdvanced.Size = CType(resources.GetObject("chkAdvanced.Size"), System.Drawing.Size)
        Me.chkAdvanced.TabIndex = CType(resources.GetObject("chkAdvanced.TabIndex"), Integer)
        Me.chkAdvanced.Text = resources.GetString("chkAdvanced.Text")
        Me.chkAdvanced.TextAlign = CType(resources.GetObject("chkAdvanced.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkAdvanced.Visible = CType(resources.GetObject("chkAdvanced.Visible"), Boolean)
        '
        'odlgSourceFile
        '
        Me.odlgSourceFile.Filter = resources.GetString("odlgSourceFile.Filter")
        Me.odlgSourceFile.Title = resources.GetString("odlgSourceFile.Title")
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAdvanced, Me.btnCreateKey, Me.txtPassword, Me.lblPassword, Me.btnLoad, Me.btnDecrypt, Me.btnEncrypt, Me.txtCrypto, Me.optTripleDESAdv, Me.optRijndaelAdv})
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

    Private crpSample As SampleCrypto
    Private FormHasLoaded As Boolean = False
    Private strCurrentKeyFile As String
    Private strSourcePath As String
    Private strRijndaelSaltIVFile As String
    Private strTripleDESSaltIVFile As String

    ' This routine handles the "Create Salt / IV Key" button click event.
    Private Sub btnCreateKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateKey.Click
        Try
            If PasswordIsValid() Then
                crpSample.Password = txtPassword.Text
            Else
                Exit Sub
            End If

            If crpSample.CreateSaltIVFile(strCurrentKeyFile) Then
                MsgBox("Salt and IV successfully generated and saved to a .dat " & vbCrLf & _
                    "file in the Visual Studio .NET Solution root folder.", _
                    MsgBoxStyle.Information, Me.Text)
            End If
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    ' This routine handles the "Encrypt" and "Decrypt" button click events.
    Private Sub EncryptDecrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncrypt.Click, btnDecrypt.Click
        Dim btn As Button = CType(sender, Button)

        Try
            If chkAdvanced.Checked Then
                If IsValid() Then
                    With crpSample
                        .SaltIVFile = strCurrentKeyFile
                        .Password = txtPassword.Text
                    End With
                Else
                    Exit Sub
                End If
            End If

            crpSample.SourceFileName = strSourcePath

            If btn.Name = "btnEncrypt" Then
                crpSample.EncryptFile()
            Else
                crpSample.DecryptFile()
            End If

            txtCrypto.Text = ReadFileAsString(strSourcePath)

        Catch expCrypto As CryptographicException
            MsgBox("The file could not be decrypted. Make sure you entered " & _
                "the correct password. " & vbCrLf & "This error can also be caused by changing " & _
                "crypto type between encryption and decryption.", _
                MsgBoxStyle.Critical, Me.Text)
        Catch exp As Exception
            MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    ' This routine handles the "Load" button click event.
    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        With odlgSourceFile
            .InitialDirectory = "C:\"
            ' The file could be of any type. The Filter is restricted to Text Format 
            ' files only for demonstration purposes.
            .Filter = "Text Format (*.txt)|*.txt"
            .FilterIndex = 1

            ' The OpenFileDialog control only has an Open button, not an OK button.
            ' However, there is no DialogResult.Open enum so use DialogResult.OK.
            If .ShowDialog() = DialogResult.OK Then
                Try
                    txtCrypto.Text = _
                       ReadFileAsString(.FileName)
                    strSourcePath = .FileName
                Catch exp As ArgumentException
                    MsgBox(exp.Message, MsgBoxStyle.Critical, Me.Text)
                End Try
            End If
        End With
    End Sub

    ' This routine handles the CheckedChanged event for the "Advanced" checkbox.
    Private Sub chkAdvanced_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdvanced.CheckedChanged
        If chkAdvanced.Checked Then
            lblPassword.Enabled = True
            txtPassword.Enabled = True
            btnCreateKey.Enabled = True
        Else
            lblPassword.Enabled = False
            txtPassword.Enabled = False
            btnCreateKey.Enabled = False
        End If
    End Sub

    ' This routine handles the Form's Load event, setting up the sample.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the default crypto type.
        crpSample = New SampleCrypto("Rijndael")

        ' Set the path to save the key file to the Solution root folder by stripping 
        ' "bin" from the current directory.
        Dim strCurrentDirectory As String = _
            Microsoft.VisualBasic.Left(Environment.CurrentDirectory, _
            Len(Environment.CurrentDirectory) - 3)

        ' Initialize paths for both types of key files.
        strRijndaelSaltIVFile = strCurrentDirectory & "RijndaelSaltIV.dat"
        strTripleDESSaltIVFile = strCurrentDirectory & "TripleDESSaltIV.dat"

        ' Set the current key file path to the key for default crypto type.
        strCurrentKeyFile = strRijndaelSaltIVFile

        ' Call Select() to put focus on the "Encrypt" button and prevent the text in 
        ' the TextBox from being automatically highlighted.
        btnEncrypt.Select()

        FormHasLoaded = True
    End Sub

    ' This routine handles the CheckedChanged event for the RadioButton controls.
    Private Sub RadioButtons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRijndaelAdv.CheckedChanged, optTripleDESAdv.CheckedChanged
        If FormHasLoaded Then
            If optRijndaelAdv.Checked Then
                crpSample = New SampleCrypto("Rijndael")
                strCurrentKeyFile = strRijndaelSaltIVFile
            Else
                crpSample = New SampleCrypto("TripleDES")
                strCurrentKeyFile = strTripleDESSaltIVFile
            End If
        End If
    End Sub

    ' This routine validates all data entry.
    Private Function IsValid() As Boolean
        If Not PasswordIsValid() Then
            Return False
        End If

        If strSourcePath = "" Then
            MsgBox("You must first load a source file!", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        Return True
    End Function

    ' This routine validates the password.
    Private Function PasswordIsValid() As Boolean
        If Not Regex.IsMatch(txtPassword.Text, "^\s*(\w){8}\s*$") Then
            MsgBox("You must enter an 8-digit password consisting of numbers " & _
                "and/or letters.", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If

        Return True
    End Function

    ' This routine reads in the contents of a file and converts it to a string.
    Shared Function ReadFileAsString(ByVal path As String) As String
        Dim fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
        Dim abyt(CInt(fs.Length - 1)) As Byte

        fs.Read(abyt, 0, abyt.Length)
        fs.Close()

        Return UTF8.GetString(abyt)
    End Function

End Class