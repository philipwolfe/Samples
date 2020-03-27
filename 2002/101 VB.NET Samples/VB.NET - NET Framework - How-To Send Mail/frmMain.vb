'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Web.Mail
Imports System.Text
Imports System.ServiceProcess

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' For use with the WndProc override routine
    Dim WM_SYSCOMMAND As Integer = &H112
    Dim SC_CLOSE As Integer = &HF060

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
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents lblBody As System.Windows.Forms.Label
    Friend WithEvents lblBCC As System.Windows.Forms.Label
    Friend WithEvents lblCC As System.Windows.Forms.Label
    Friend WithEvents erpEmailAddresses As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtBody As System.Windows.Forms.TextBox
    Friend WithEvents txtCC As System.Windows.Forms.TextBox
    Friend WithEvents txtBCC As System.Windows.Forms.TextBox
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents odlgAttachment As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstAttachments As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.lblBody = New System.Windows.Forms.Label()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.txtBody = New System.Windows.Forms.TextBox()
        Me.txtCC = New System.Windows.Forms.TextBox()
        Me.lblBCC = New System.Windows.Forms.Label()
        Me.lblCC = New System.Windows.Forms.Label()
        Me.erpEmailAddresses = New System.Windows.Forms.ErrorProvider()
        Me.txtBCC = New System.Windows.Forms.TextBox()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstAttachments = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.odlgAttachment = New System.Windows.Forms.OpenFileDialog()
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
        'btnSend
        '
        Me.btnSend.AccessibleDescription = CType(resources.GetObject("btnSend.AccessibleDescription"), String)
        Me.btnSend.AccessibleName = CType(resources.GetObject("btnSend.AccessibleName"), String)
        Me.btnSend.Anchor = CType(resources.GetObject("btnSend.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSend.BackColor = System.Drawing.SystemColors.Control
        Me.btnSend.BackgroundImage = CType(resources.GetObject("btnSend.BackgroundImage"), System.Drawing.Image)
        Me.btnSend.Dock = CType(resources.GetObject("btnSend.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSend.Enabled = CType(resources.GetObject("btnSend.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.btnSend, resources.GetString("btnSend.Error"))
        Me.btnSend.FlatStyle = CType(resources.GetObject("btnSend.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSend.Font = CType(resources.GetObject("btnSend.Font"), System.Drawing.Font)
        Me.btnSend.ForeColor = System.Drawing.SystemColors.ControlText
        Me.erpEmailAddresses.SetIconAlignment(Me.btnSend, CType(resources.GetObject("btnSend.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.btnSend, CType(resources.GetObject("btnSend.IconPadding"), Integer))
        Me.btnSend.Image = CType(resources.GetObject("btnSend.Image"), System.Drawing.Bitmap)
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
        'txtFrom
        '
        Me.txtFrom.AccessibleDescription = CType(resources.GetObject("txtFrom.AccessibleDescription"), String)
        Me.txtFrom.AccessibleName = CType(resources.GetObject("txtFrom.AccessibleName"), String)
        Me.txtFrom.Anchor = CType(resources.GetObject("txtFrom.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtFrom.AutoSize = CType(resources.GetObject("txtFrom.AutoSize"), Boolean)
        Me.txtFrom.BackColor = System.Drawing.SystemColors.Window
        Me.txtFrom.BackgroundImage = CType(resources.GetObject("txtFrom.BackgroundImage"), System.Drawing.Image)
        Me.txtFrom.Dock = CType(resources.GetObject("txtFrom.Dock"), System.Windows.Forms.DockStyle)
        Me.txtFrom.Enabled = CType(resources.GetObject("txtFrom.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.txtFrom, resources.GetString("txtFrom.Error"))
        Me.txtFrom.Font = CType(resources.GetObject("txtFrom.Font"), System.Drawing.Font)
        Me.erpEmailAddresses.SetIconAlignment(Me.txtFrom, CType(resources.GetObject("txtFrom.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.txtFrom, CType(resources.GetObject("txtFrom.IconPadding"), Integer))
        Me.txtFrom.ImeMode = CType(resources.GetObject("txtFrom.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtFrom.Location = CType(resources.GetObject("txtFrom.Location"), System.Drawing.Point)
        Me.txtFrom.MaxLength = CType(resources.GetObject("txtFrom.MaxLength"), Integer)
        Me.txtFrom.Multiline = CType(resources.GetObject("txtFrom.Multiline"), Boolean)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.PasswordChar = CType(resources.GetObject("txtFrom.PasswordChar"), Char)
        Me.txtFrom.RightToLeft = CType(resources.GetObject("txtFrom.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtFrom.ScrollBars = CType(resources.GetObject("txtFrom.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtFrom.Size = CType(resources.GetObject("txtFrom.Size"), System.Drawing.Size)
        Me.txtFrom.TabIndex = CType(resources.GetObject("txtFrom.TabIndex"), Integer)
        Me.txtFrom.Text = resources.GetString("txtFrom.Text")
        Me.txtFrom.TextAlign = CType(resources.GetObject("txtFrom.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtFrom.Visible = CType(resources.GetObject("txtFrom.Visible"), Boolean)
        Me.txtFrom.WordWrap = CType(resources.GetObject("txtFrom.WordWrap"), Boolean)
        '
        'lblFrom
        '
        Me.lblFrom.AccessibleDescription = CType(resources.GetObject("lblFrom.AccessibleDescription"), String)
        Me.lblFrom.AccessibleName = CType(resources.GetObject("lblFrom.AccessibleName"), String)
        Me.lblFrom.Anchor = CType(resources.GetObject("lblFrom.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblFrom.AutoSize = CType(resources.GetObject("lblFrom.AutoSize"), Boolean)
        Me.lblFrom.BackColor = System.Drawing.SystemColors.Control
        Me.lblFrom.CausesValidation = False
        Me.lblFrom.Dock = CType(resources.GetObject("lblFrom.Dock"), System.Windows.Forms.DockStyle)
        Me.lblFrom.Enabled = CType(resources.GetObject("lblFrom.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.lblFrom, resources.GetString("lblFrom.Error"))
        Me.lblFrom.Font = CType(resources.GetObject("lblFrom.Font"), System.Drawing.Font)
        Me.lblFrom.ForeColor = System.Drawing.SystemColors.ControlText
        Me.erpEmailAddresses.SetIconAlignment(Me.lblFrom, CType(resources.GetObject("lblFrom.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.lblFrom, CType(resources.GetObject("lblFrom.IconPadding"), Integer))
        Me.lblFrom.Image = CType(resources.GetObject("lblFrom.Image"), System.Drawing.Image)
        Me.lblFrom.ImageAlign = CType(resources.GetObject("lblFrom.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblFrom.ImageIndex = CType(resources.GetObject("lblFrom.ImageIndex"), Integer)
        Me.lblFrom.ImeMode = CType(resources.GetObject("lblFrom.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblFrom.Location = CType(resources.GetObject("lblFrom.Location"), System.Drawing.Point)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.RightToLeft = CType(resources.GetObject("lblFrom.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblFrom.Size = CType(resources.GetObject("lblFrom.Size"), System.Drawing.Size)
        Me.lblFrom.TabIndex = CType(resources.GetObject("lblFrom.TabIndex"), Integer)
        Me.lblFrom.Text = resources.GetString("lblFrom.Text")
        Me.lblFrom.TextAlign = CType(resources.GetObject("lblFrom.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblFrom.Visible = CType(resources.GetObject("lblFrom.Visible"), Boolean)
        '
        'lblTo
        '
        Me.lblTo.AccessibleDescription = CType(resources.GetObject("lblTo.AccessibleDescription"), String)
        Me.lblTo.AccessibleName = CType(resources.GetObject("lblTo.AccessibleName"), String)
        Me.lblTo.Anchor = CType(resources.GetObject("lblTo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTo.AutoSize = CType(resources.GetObject("lblTo.AutoSize"), Boolean)
        Me.lblTo.BackColor = System.Drawing.SystemColors.Control
        Me.lblTo.CausesValidation = False
        Me.lblTo.Dock = CType(resources.GetObject("lblTo.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTo.Enabled = CType(resources.GetObject("lblTo.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.lblTo, resources.GetString("lblTo.Error"))
        Me.lblTo.Font = CType(resources.GetObject("lblTo.Font"), System.Drawing.Font)
        Me.lblTo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.erpEmailAddresses.SetIconAlignment(Me.lblTo, CType(resources.GetObject("lblTo.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.lblTo, CType(resources.GetObject("lblTo.IconPadding"), Integer))
        Me.lblTo.Image = CType(resources.GetObject("lblTo.Image"), System.Drawing.Image)
        Me.lblTo.ImageAlign = CType(resources.GetObject("lblTo.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTo.ImageIndex = CType(resources.GetObject("lblTo.ImageIndex"), Integer)
        Me.lblTo.ImeMode = CType(resources.GetObject("lblTo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTo.Location = CType(resources.GetObject("lblTo.Location"), System.Drawing.Point)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.RightToLeft = CType(resources.GetObject("lblTo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTo.Size = CType(resources.GetObject("lblTo.Size"), System.Drawing.Size)
        Me.lblTo.TabIndex = CType(resources.GetObject("lblTo.TabIndex"), Integer)
        Me.lblTo.Text = resources.GetString("lblTo.Text")
        Me.lblTo.TextAlign = CType(resources.GetObject("lblTo.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTo.Visible = CType(resources.GetObject("lblTo.Visible"), Boolean)
        '
        'lblSubject
        '
        Me.lblSubject.AccessibleDescription = CType(resources.GetObject("lblSubject.AccessibleDescription"), String)
        Me.lblSubject.AccessibleName = CType(resources.GetObject("lblSubject.AccessibleName"), String)
        Me.lblSubject.Anchor = CType(resources.GetObject("lblSubject.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblSubject.AutoSize = CType(resources.GetObject("lblSubject.AutoSize"), Boolean)
        Me.lblSubject.BackColor = System.Drawing.SystemColors.Control
        Me.lblSubject.CausesValidation = False
        Me.lblSubject.Dock = CType(resources.GetObject("lblSubject.Dock"), System.Windows.Forms.DockStyle)
        Me.lblSubject.Enabled = CType(resources.GetObject("lblSubject.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.lblSubject, resources.GetString("lblSubject.Error"))
        Me.lblSubject.Font = CType(resources.GetObject("lblSubject.Font"), System.Drawing.Font)
        Me.lblSubject.ForeColor = System.Drawing.SystemColors.ControlText
        Me.erpEmailAddresses.SetIconAlignment(Me.lblSubject, CType(resources.GetObject("lblSubject.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.lblSubject, CType(resources.GetObject("lblSubject.IconPadding"), Integer))
        Me.lblSubject.Image = CType(resources.GetObject("lblSubject.Image"), System.Drawing.Image)
        Me.lblSubject.ImageAlign = CType(resources.GetObject("lblSubject.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblSubject.ImageIndex = CType(resources.GetObject("lblSubject.ImageIndex"), Integer)
        Me.lblSubject.ImeMode = CType(resources.GetObject("lblSubject.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblSubject.Location = CType(resources.GetObject("lblSubject.Location"), System.Drawing.Point)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.RightToLeft = CType(resources.GetObject("lblSubject.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblSubject.Size = CType(resources.GetObject("lblSubject.Size"), System.Drawing.Size)
        Me.lblSubject.TabIndex = CType(resources.GetObject("lblSubject.TabIndex"), Integer)
        Me.lblSubject.Text = resources.GetString("lblSubject.Text")
        Me.lblSubject.TextAlign = CType(resources.GetObject("lblSubject.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblSubject.Visible = CType(resources.GetObject("lblSubject.Visible"), Boolean)
        '
        'lblBody
        '
        Me.lblBody.AccessibleDescription = CType(resources.GetObject("lblBody.AccessibleDescription"), String)
        Me.lblBody.AccessibleName = CType(resources.GetObject("lblBody.AccessibleName"), String)
        Me.lblBody.Anchor = CType(resources.GetObject("lblBody.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblBody.AutoSize = CType(resources.GetObject("lblBody.AutoSize"), Boolean)
        Me.lblBody.BackColor = System.Drawing.SystemColors.Control
        Me.lblBody.CausesValidation = False
        Me.lblBody.Dock = CType(resources.GetObject("lblBody.Dock"), System.Windows.Forms.DockStyle)
        Me.lblBody.Enabled = CType(resources.GetObject("lblBody.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.lblBody, resources.GetString("lblBody.Error"))
        Me.lblBody.Font = CType(resources.GetObject("lblBody.Font"), System.Drawing.Font)
        Me.lblBody.ForeColor = System.Drawing.SystemColors.ControlText
        Me.erpEmailAddresses.SetIconAlignment(Me.lblBody, CType(resources.GetObject("lblBody.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.lblBody, CType(resources.GetObject("lblBody.IconPadding"), Integer))
        Me.lblBody.Image = CType(resources.GetObject("lblBody.Image"), System.Drawing.Image)
        Me.lblBody.ImageAlign = CType(resources.GetObject("lblBody.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblBody.ImageIndex = CType(resources.GetObject("lblBody.ImageIndex"), Integer)
        Me.lblBody.ImeMode = CType(resources.GetObject("lblBody.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblBody.Location = CType(resources.GetObject("lblBody.Location"), System.Drawing.Point)
        Me.lblBody.Name = "lblBody"
        Me.lblBody.RightToLeft = CType(resources.GetObject("lblBody.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblBody.Size = CType(resources.GetObject("lblBody.Size"), System.Drawing.Size)
        Me.lblBody.TabIndex = CType(resources.GetObject("lblBody.TabIndex"), Integer)
        Me.lblBody.Text = resources.GetString("lblBody.Text")
        Me.lblBody.TextAlign = CType(resources.GetObject("lblBody.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblBody.Visible = CType(resources.GetObject("lblBody.Visible"), Boolean)
        '
        'txtTo
        '
        Me.txtTo.AccessibleDescription = CType(resources.GetObject("txtTo.AccessibleDescription"), String)
        Me.txtTo.AccessibleName = CType(resources.GetObject("txtTo.AccessibleName"), String)
        Me.txtTo.Anchor = CType(resources.GetObject("txtTo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtTo.AutoSize = CType(resources.GetObject("txtTo.AutoSize"), Boolean)
        Me.txtTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtTo.BackgroundImage = CType(resources.GetObject("txtTo.BackgroundImage"), System.Drawing.Image)
        Me.txtTo.Dock = CType(resources.GetObject("txtTo.Dock"), System.Windows.Forms.DockStyle)
        Me.txtTo.Enabled = CType(resources.GetObject("txtTo.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.txtTo, resources.GetString("txtTo.Error"))
        Me.txtTo.Font = CType(resources.GetObject("txtTo.Font"), System.Drawing.Font)
        Me.erpEmailAddresses.SetIconAlignment(Me.txtTo, CType(resources.GetObject("txtTo.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.txtTo, CType(resources.GetObject("txtTo.IconPadding"), Integer))
        Me.txtTo.ImeMode = CType(resources.GetObject("txtTo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtTo.Location = CType(resources.GetObject("txtTo.Location"), System.Drawing.Point)
        Me.txtTo.MaxLength = CType(resources.GetObject("txtTo.MaxLength"), Integer)
        Me.txtTo.Multiline = CType(resources.GetObject("txtTo.Multiline"), Boolean)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.PasswordChar = CType(resources.GetObject("txtTo.PasswordChar"), Char)
        Me.txtTo.RightToLeft = CType(resources.GetObject("txtTo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtTo.ScrollBars = CType(resources.GetObject("txtTo.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtTo.Size = CType(resources.GetObject("txtTo.Size"), System.Drawing.Size)
        Me.txtTo.TabIndex = CType(resources.GetObject("txtTo.TabIndex"), Integer)
        Me.txtTo.Text = resources.GetString("txtTo.Text")
        Me.txtTo.TextAlign = CType(resources.GetObject("txtTo.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtTo.Visible = CType(resources.GetObject("txtTo.Visible"), Boolean)
        Me.txtTo.WordWrap = CType(resources.GetObject("txtTo.WordWrap"), Boolean)
        '
        'txtSubject
        '
        Me.txtSubject.AccessibleDescription = CType(resources.GetObject("txtSubject.AccessibleDescription"), String)
        Me.txtSubject.AccessibleName = CType(resources.GetObject("txtSubject.AccessibleName"), String)
        Me.txtSubject.Anchor = CType(resources.GetObject("txtSubject.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.AutoSize = CType(resources.GetObject("txtSubject.AutoSize"), Boolean)
        Me.txtSubject.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubject.BackgroundImage = CType(resources.GetObject("txtSubject.BackgroundImage"), System.Drawing.Image)
        Me.txtSubject.CausesValidation = False
        Me.txtSubject.Dock = CType(resources.GetObject("txtSubject.Dock"), System.Windows.Forms.DockStyle)
        Me.txtSubject.Enabled = CType(resources.GetObject("txtSubject.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.txtSubject, resources.GetString("txtSubject.Error"))
        Me.txtSubject.Font = CType(resources.GetObject("txtSubject.Font"), System.Drawing.Font)
        Me.erpEmailAddresses.SetIconAlignment(Me.txtSubject, CType(resources.GetObject("txtSubject.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.txtSubject, CType(resources.GetObject("txtSubject.IconPadding"), Integer))
        Me.txtSubject.ImeMode = CType(resources.GetObject("txtSubject.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtSubject.Location = CType(resources.GetObject("txtSubject.Location"), System.Drawing.Point)
        Me.txtSubject.MaxLength = CType(resources.GetObject("txtSubject.MaxLength"), Integer)
        Me.txtSubject.Multiline = CType(resources.GetObject("txtSubject.Multiline"), Boolean)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.PasswordChar = CType(resources.GetObject("txtSubject.PasswordChar"), Char)
        Me.txtSubject.RightToLeft = CType(resources.GetObject("txtSubject.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtSubject.ScrollBars = CType(resources.GetObject("txtSubject.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtSubject.Size = CType(resources.GetObject("txtSubject.Size"), System.Drawing.Size)
        Me.txtSubject.TabIndex = CType(resources.GetObject("txtSubject.TabIndex"), Integer)
        Me.txtSubject.Text = resources.GetString("txtSubject.Text")
        Me.txtSubject.TextAlign = CType(resources.GetObject("txtSubject.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtSubject.Visible = CType(resources.GetObject("txtSubject.Visible"), Boolean)
        Me.txtSubject.WordWrap = CType(resources.GetObject("txtSubject.WordWrap"), Boolean)
        '
        'txtBody
        '
        Me.txtBody.AccessibleDescription = CType(resources.GetObject("txtBody.AccessibleDescription"), String)
        Me.txtBody.AccessibleName = CType(resources.GetObject("txtBody.AccessibleName"), String)
        Me.txtBody.Anchor = CType(resources.GetObject("txtBody.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtBody.AutoSize = CType(resources.GetObject("txtBody.AutoSize"), Boolean)
        Me.txtBody.BackColor = System.Drawing.SystemColors.Window
        Me.txtBody.BackgroundImage = CType(resources.GetObject("txtBody.BackgroundImage"), System.Drawing.Image)
        Me.txtBody.CausesValidation = False
        Me.txtBody.Dock = CType(resources.GetObject("txtBody.Dock"), System.Windows.Forms.DockStyle)
        Me.txtBody.Enabled = CType(resources.GetObject("txtBody.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.txtBody, resources.GetString("txtBody.Error"))
        Me.txtBody.Font = CType(resources.GetObject("txtBody.Font"), System.Drawing.Font)
        Me.erpEmailAddresses.SetIconAlignment(Me.txtBody, CType(resources.GetObject("txtBody.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.txtBody, CType(resources.GetObject("txtBody.IconPadding"), Integer))
        Me.txtBody.ImeMode = CType(resources.GetObject("txtBody.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtBody.Location = CType(resources.GetObject("txtBody.Location"), System.Drawing.Point)
        Me.txtBody.MaxLength = CType(resources.GetObject("txtBody.MaxLength"), Integer)
        Me.txtBody.Multiline = CType(resources.GetObject("txtBody.Multiline"), Boolean)
        Me.txtBody.Name = "txtBody"
        Me.txtBody.PasswordChar = CType(resources.GetObject("txtBody.PasswordChar"), Char)
        Me.txtBody.RightToLeft = CType(resources.GetObject("txtBody.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtBody.ScrollBars = CType(resources.GetObject("txtBody.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtBody.Size = CType(resources.GetObject("txtBody.Size"), System.Drawing.Size)
        Me.txtBody.TabIndex = CType(resources.GetObject("txtBody.TabIndex"), Integer)
        Me.txtBody.Text = resources.GetString("txtBody.Text")
        Me.txtBody.TextAlign = CType(resources.GetObject("txtBody.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtBody.Visible = CType(resources.GetObject("txtBody.Visible"), Boolean)
        Me.txtBody.WordWrap = CType(resources.GetObject("txtBody.WordWrap"), Boolean)
        '
        'txtCC
        '
        Me.txtCC.AccessibleDescription = CType(resources.GetObject("txtCC.AccessibleDescription"), String)
        Me.txtCC.AccessibleName = CType(resources.GetObject("txtCC.AccessibleName"), String)
        Me.txtCC.Anchor = CType(resources.GetObject("txtCC.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCC.AutoSize = CType(resources.GetObject("txtCC.AutoSize"), Boolean)
        Me.txtCC.BackColor = System.Drawing.SystemColors.Window
        Me.txtCC.BackgroundImage = CType(resources.GetObject("txtCC.BackgroundImage"), System.Drawing.Image)
        Me.txtCC.CausesValidation = False
        Me.txtCC.Dock = CType(resources.GetObject("txtCC.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCC.Enabled = CType(resources.GetObject("txtCC.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.txtCC, resources.GetString("txtCC.Error"))
        Me.txtCC.Font = CType(resources.GetObject("txtCC.Font"), System.Drawing.Font)
        Me.erpEmailAddresses.SetIconAlignment(Me.txtCC, CType(resources.GetObject("txtCC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.txtCC, CType(resources.GetObject("txtCC.IconPadding"), Integer))
        Me.txtCC.ImeMode = CType(resources.GetObject("txtCC.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCC.Location = CType(resources.GetObject("txtCC.Location"), System.Drawing.Point)
        Me.txtCC.MaxLength = CType(resources.GetObject("txtCC.MaxLength"), Integer)
        Me.txtCC.Multiline = CType(resources.GetObject("txtCC.Multiline"), Boolean)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.PasswordChar = CType(resources.GetObject("txtCC.PasswordChar"), Char)
        Me.txtCC.RightToLeft = CType(resources.GetObject("txtCC.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCC.ScrollBars = CType(resources.GetObject("txtCC.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCC.Size = CType(resources.GetObject("txtCC.Size"), System.Drawing.Size)
        Me.txtCC.TabIndex = CType(resources.GetObject("txtCC.TabIndex"), Integer)
        Me.txtCC.Text = resources.GetString("txtCC.Text")
        Me.txtCC.TextAlign = CType(resources.GetObject("txtCC.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCC.Visible = CType(resources.GetObject("txtCC.Visible"), Boolean)
        Me.txtCC.WordWrap = CType(resources.GetObject("txtCC.WordWrap"), Boolean)
        '
        'lblBCC
        '
        Me.lblBCC.AccessibleDescription = CType(resources.GetObject("lblBCC.AccessibleDescription"), String)
        Me.lblBCC.AccessibleName = CType(resources.GetObject("lblBCC.AccessibleName"), String)
        Me.lblBCC.Anchor = CType(resources.GetObject("lblBCC.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblBCC.AutoSize = CType(resources.GetObject("lblBCC.AutoSize"), Boolean)
        Me.lblBCC.BackColor = System.Drawing.SystemColors.Control
        Me.lblBCC.CausesValidation = False
        Me.lblBCC.Dock = CType(resources.GetObject("lblBCC.Dock"), System.Windows.Forms.DockStyle)
        Me.lblBCC.Enabled = CType(resources.GetObject("lblBCC.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.lblBCC, resources.GetString("lblBCC.Error"))
        Me.lblBCC.Font = CType(resources.GetObject("lblBCC.Font"), System.Drawing.Font)
        Me.lblBCC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.erpEmailAddresses.SetIconAlignment(Me.lblBCC, CType(resources.GetObject("lblBCC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.lblBCC, CType(resources.GetObject("lblBCC.IconPadding"), Integer))
        Me.lblBCC.Image = CType(resources.GetObject("lblBCC.Image"), System.Drawing.Image)
        Me.lblBCC.ImageAlign = CType(resources.GetObject("lblBCC.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblBCC.ImageIndex = CType(resources.GetObject("lblBCC.ImageIndex"), Integer)
        Me.lblBCC.ImeMode = CType(resources.GetObject("lblBCC.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblBCC.Location = CType(resources.GetObject("lblBCC.Location"), System.Drawing.Point)
        Me.lblBCC.Name = "lblBCC"
        Me.lblBCC.RightToLeft = CType(resources.GetObject("lblBCC.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblBCC.Size = CType(resources.GetObject("lblBCC.Size"), System.Drawing.Size)
        Me.lblBCC.TabIndex = CType(resources.GetObject("lblBCC.TabIndex"), Integer)
        Me.lblBCC.Text = resources.GetString("lblBCC.Text")
        Me.lblBCC.TextAlign = CType(resources.GetObject("lblBCC.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblBCC.Visible = CType(resources.GetObject("lblBCC.Visible"), Boolean)
        '
        'lblCC
        '
        Me.lblCC.AccessibleDescription = CType(resources.GetObject("lblCC.AccessibleDescription"), String)
        Me.lblCC.AccessibleName = CType(resources.GetObject("lblCC.AccessibleName"), String)
        Me.lblCC.Anchor = CType(resources.GetObject("lblCC.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblCC.AutoSize = CType(resources.GetObject("lblCC.AutoSize"), Boolean)
        Me.lblCC.BackColor = System.Drawing.SystemColors.Control
        Me.lblCC.CausesValidation = False
        Me.lblCC.Dock = CType(resources.GetObject("lblCC.Dock"), System.Windows.Forms.DockStyle)
        Me.lblCC.Enabled = CType(resources.GetObject("lblCC.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.lblCC, resources.GetString("lblCC.Error"))
        Me.lblCC.Font = CType(resources.GetObject("lblCC.Font"), System.Drawing.Font)
        Me.lblCC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.erpEmailAddresses.SetIconAlignment(Me.lblCC, CType(resources.GetObject("lblCC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.lblCC, CType(resources.GetObject("lblCC.IconPadding"), Integer))
        Me.lblCC.Image = CType(resources.GetObject("lblCC.Image"), System.Drawing.Image)
        Me.lblCC.ImageAlign = CType(resources.GetObject("lblCC.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblCC.ImageIndex = CType(resources.GetObject("lblCC.ImageIndex"), Integer)
        Me.lblCC.ImeMode = CType(resources.GetObject("lblCC.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblCC.Location = CType(resources.GetObject("lblCC.Location"), System.Drawing.Point)
        Me.lblCC.Name = "lblCC"
        Me.lblCC.RightToLeft = CType(resources.GetObject("lblCC.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblCC.Size = CType(resources.GetObject("lblCC.Size"), System.Drawing.Size)
        Me.lblCC.TabIndex = CType(resources.GetObject("lblCC.TabIndex"), Integer)
        Me.lblCC.Text = resources.GetString("lblCC.Text")
        Me.lblCC.TextAlign = CType(resources.GetObject("lblCC.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblCC.Visible = CType(resources.GetObject("lblCC.Visible"), Boolean)
        '
        'erpEmailAddresses
        '
        Me.erpEmailAddresses.Icon = CType(resources.GetObject("erpEmailAddresses.Icon"), System.Drawing.Icon)
        '
        'txtBCC
        '
        Me.txtBCC.AccessibleDescription = CType(resources.GetObject("txtBCC.AccessibleDescription"), String)
        Me.txtBCC.AccessibleName = CType(resources.GetObject("txtBCC.AccessibleName"), String)
        Me.txtBCC.Anchor = CType(resources.GetObject("txtBCC.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtBCC.AutoSize = CType(resources.GetObject("txtBCC.AutoSize"), Boolean)
        Me.txtBCC.BackColor = System.Drawing.SystemColors.Window
        Me.txtBCC.BackgroundImage = CType(resources.GetObject("txtBCC.BackgroundImage"), System.Drawing.Image)
        Me.txtBCC.CausesValidation = False
        Me.txtBCC.Dock = CType(resources.GetObject("txtBCC.Dock"), System.Windows.Forms.DockStyle)
        Me.txtBCC.Enabled = CType(resources.GetObject("txtBCC.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.txtBCC, resources.GetString("txtBCC.Error"))
        Me.txtBCC.Font = CType(resources.GetObject("txtBCC.Font"), System.Drawing.Font)
        Me.erpEmailAddresses.SetIconAlignment(Me.txtBCC, CType(resources.GetObject("txtBCC.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.txtBCC, CType(resources.GetObject("txtBCC.IconPadding"), Integer))
        Me.txtBCC.ImeMode = CType(resources.GetObject("txtBCC.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtBCC.Location = CType(resources.GetObject("txtBCC.Location"), System.Drawing.Point)
        Me.txtBCC.MaxLength = CType(resources.GetObject("txtBCC.MaxLength"), Integer)
        Me.txtBCC.Multiline = CType(resources.GetObject("txtBCC.Multiline"), Boolean)
        Me.txtBCC.Name = "txtBCC"
        Me.txtBCC.PasswordChar = CType(resources.GetObject("txtBCC.PasswordChar"), Char)
        Me.txtBCC.RightToLeft = CType(resources.GetObject("txtBCC.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtBCC.ScrollBars = CType(resources.GetObject("txtBCC.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtBCC.Size = CType(resources.GetObject("txtBCC.Size"), System.Drawing.Size)
        Me.txtBCC.TabIndex = CType(resources.GetObject("txtBCC.TabIndex"), Integer)
        Me.txtBCC.Text = resources.GetString("txtBCC.Text")
        Me.txtBCC.TextAlign = CType(resources.GetObject("txtBCC.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtBCC.Visible = CType(resources.GetObject("txtBCC.Visible"), Boolean)
        Me.txtBCC.WordWrap = CType(resources.GetObject("txtBCC.WordWrap"), Boolean)
        '
        'cboPriority
        '
        Me.cboPriority.AccessibleDescription = CType(resources.GetObject("cboPriority.AccessibleDescription"), String)
        Me.cboPriority.AccessibleName = CType(resources.GetObject("cboPriority.AccessibleName"), String)
        Me.cboPriority.Anchor = CType(resources.GetObject("cboPriority.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cboPriority.BackgroundImage = CType(resources.GetObject("cboPriority.BackgroundImage"), System.Drawing.Image)
        Me.cboPriority.CausesValidation = False
        Me.cboPriority.Dock = CType(resources.GetObject("cboPriority.Dock"), System.Windows.Forms.DockStyle)
        Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriority.Enabled = CType(resources.GetObject("cboPriority.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.cboPriority, resources.GetString("cboPriority.Error"))
        Me.cboPriority.Font = CType(resources.GetObject("cboPriority.Font"), System.Drawing.Font)
        Me.erpEmailAddresses.SetIconAlignment(Me.cboPriority, CType(resources.GetObject("cboPriority.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.cboPriority, CType(resources.GetObject("cboPriority.IconPadding"), Integer))
        Me.cboPriority.ImeMode = CType(resources.GetObject("cboPriority.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cboPriority.IntegralHeight = CType(resources.GetObject("cboPriority.IntegralHeight"), Boolean)
        Me.cboPriority.ItemHeight = CType(resources.GetObject("cboPriority.ItemHeight"), Integer)
        Me.cboPriority.Location = CType(resources.GetObject("cboPriority.Location"), System.Drawing.Point)
        Me.cboPriority.MaxDropDownItems = CType(resources.GetObject("cboPriority.MaxDropDownItems"), Integer)
        Me.cboPriority.MaxLength = CType(resources.GetObject("cboPriority.MaxLength"), Integer)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.RightToLeft = CType(resources.GetObject("cboPriority.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cboPriority.Size = CType(resources.GetObject("cboPriority.Size"), System.Drawing.Size)
        Me.cboPriority.TabIndex = CType(resources.GetObject("cboPriority.TabIndex"), Integer)
        Me.cboPriority.Text = resources.GetString("cboPriority.Text")
        Me.cboPriority.Visible = CType(resources.GetObject("cboPriority.Visible"), Boolean)
        '
        'btnBrowse
        '
        Me.btnBrowse.AccessibleDescription = CType(resources.GetObject("btnBrowse.AccessibleDescription"), String)
        Me.btnBrowse.AccessibleName = CType(resources.GetObject("btnBrowse.AccessibleName"), String)
        Me.btnBrowse.Anchor = CType(resources.GetObject("btnBrowse.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackgroundImage = CType(resources.GetObject("btnBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse.CausesValidation = False
        Me.btnBrowse.Dock = CType(resources.GetObject("btnBrowse.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBrowse.Enabled = CType(resources.GetObject("btnBrowse.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.btnBrowse, resources.GetString("btnBrowse.Error"))
        Me.btnBrowse.FlatStyle = CType(resources.GetObject("btnBrowse.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBrowse.Font = CType(resources.GetObject("btnBrowse.Font"), System.Drawing.Font)
        Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.erpEmailAddresses.SetIconAlignment(Me.btnBrowse, CType(resources.GetObject("btnBrowse.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.btnBrowse, CType(resources.GetObject("btnBrowse.IconPadding"), Integer))
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Bitmap)
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
        Me.erpEmailAddresses.SetError(Me.Label1, resources.GetString("Label1.Error"))
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.erpEmailAddresses.SetIconAlignment(Me.Label1, CType(resources.GetObject("Label1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.Label1, CType(resources.GetObject("Label1.IconPadding"), Integer))
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
        'lstAttachments
        '
        Me.lstAttachments.AccessibleDescription = CType(resources.GetObject("lstAttachments.AccessibleDescription"), String)
        Me.lstAttachments.AccessibleName = CType(resources.GetObject("lstAttachments.AccessibleName"), String)
        Me.lstAttachments.Anchor = CType(resources.GetObject("lstAttachments.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lstAttachments.BackgroundImage = CType(resources.GetObject("lstAttachments.BackgroundImage"), System.Drawing.Image)
        Me.lstAttachments.CausesValidation = False
        Me.lstAttachments.ColumnWidth = CType(resources.GetObject("lstAttachments.ColumnWidth"), Integer)
        Me.lstAttachments.Dock = CType(resources.GetObject("lstAttachments.Dock"), System.Windows.Forms.DockStyle)
        Me.lstAttachments.Enabled = CType(resources.GetObject("lstAttachments.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.lstAttachments, resources.GetString("lstAttachments.Error"))
        Me.lstAttachments.Font = CType(resources.GetObject("lstAttachments.Font"), System.Drawing.Font)
        Me.lstAttachments.HorizontalExtent = CType(resources.GetObject("lstAttachments.HorizontalExtent"), Integer)
        Me.lstAttachments.HorizontalScrollbar = CType(resources.GetObject("lstAttachments.HorizontalScrollbar"), Boolean)
        Me.erpEmailAddresses.SetIconAlignment(Me.lstAttachments, CType(resources.GetObject("lstAttachments.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.lstAttachments, CType(resources.GetObject("lstAttachments.IconPadding"), Integer))
        Me.lstAttachments.ImeMode = CType(resources.GetObject("lstAttachments.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lstAttachments.IntegralHeight = CType(resources.GetObject("lstAttachments.IntegralHeight"), Boolean)
        Me.lstAttachments.ItemHeight = CType(resources.GetObject("lstAttachments.ItemHeight"), Integer)
        Me.lstAttachments.Items.AddRange(New Object() {resources.GetString("lstAttachments.Items.Items")})
        Me.lstAttachments.Location = CType(resources.GetObject("lstAttachments.Location"), System.Drawing.Point)
        Me.lstAttachments.Name = "lstAttachments"
        Me.lstAttachments.RightToLeft = CType(resources.GetObject("lstAttachments.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lstAttachments.ScrollAlwaysVisible = CType(resources.GetObject("lstAttachments.ScrollAlwaysVisible"), Boolean)
        Me.lstAttachments.Size = CType(resources.GetObject("lstAttachments.Size"), System.Drawing.Size)
        Me.lstAttachments.TabIndex = CType(resources.GetObject("lstAttachments.TabIndex"), Integer)
        Me.lstAttachments.Visible = CType(resources.GetObject("lstAttachments.Visible"), Boolean)
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = CType(resources.GetObject("Label2.AccessibleDescription"), String)
        Me.Label2.AccessibleName = CType(resources.GetObject("Label2.AccessibleName"), String)
        Me.Label2.Anchor = CType(resources.GetObject("Label2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = CType(resources.GetObject("Label2.AutoSize"), Boolean)
        Me.Label2.Dock = CType(resources.GetObject("Label2.Dock"), System.Windows.Forms.DockStyle)
        Me.Label2.Enabled = CType(resources.GetObject("Label2.Enabled"), Boolean)
        Me.erpEmailAddresses.SetError(Me.Label2, resources.GetString("Label2.Error"))
        Me.Label2.Font = CType(resources.GetObject("Label2.Font"), System.Drawing.Font)
        Me.erpEmailAddresses.SetIconAlignment(Me.Label2, CType(resources.GetObject("Label2.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.erpEmailAddresses.SetIconPadding(Me.Label2, CType(resources.GetObject("Label2.IconPadding"), Integer))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Bitmap)
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
        'odlgAttachment
        '
        Me.odlgAttachment.Filter = resources.GetString("odlgAttachment.Filter")
        Me.odlgAttachment.Title = resources.GetString("odlgAttachment.Title")
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
        Me.CausesValidation = False
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.lstAttachments, Me.btnBrowse, Me.cboPriority, Me.txtBCC, Me.txtCC, Me.lblBCC, Me.lblCC, Me.txtBody, Me.txtSubject, Me.txtTo, Me.txtFrom, Me.btnSend, Me.lblBody, Me.lblSubject, Me.lblTo, Me.lblFrom, Me.Label1})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.ForeColor = System.Drawing.Color.Blue
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
        ' Turn of validation for all controls with CausesValidation = True or else
        ' you will not be able to close the Form until valid data is entered.
        txtTo.CausesValidation = False
        txtFrom.CausesValidation = False

        ' Close the current form
        Me.Close()
    End Sub
#End Region

    Dim arlAttachments As ArrayList

    ' Checks for empty strings and does basic check for valid email
    ' address.
    Private Sub ValidateEmailAddress(ByVal txt As TextBox)
        ' Confirm there is text in the control.
        If txt.TextLength = 0 Then
            Throw New Exception("Email address is a required field")
        Else
            ' Confirm that there is a "." and an "@" in the e-mail address.
            If txt.Text.IndexOf(".") = -1 Or txt.Text.IndexOf("@") = -1 Then
                Throw New Exception("E-mail address must be valid e-mail " & _
                    "address format." & ControlChars.Cr & "For example " & _
                    "'someone@microsoft.com'")
            End If
        End If
    End Sub

    ' This method overrides the WndProc of the Form and catches the Close message
    ' passed when the user attempts to exit the Form. Without this there is no way
    ' to prevent the ErrorProvider control from attempting to validate the "To" and 
    ' "From" TextBox controls (the only controls with CausesValidation = True). If
    ' invalid or no data is entered when the user attempts to close the Form, the
    ' validators fire and the Form will not close.
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_SYSCOMMAND Then
            If m.WParam.ToInt32 = SC_CLOSE Then
                ' Turn off validation for all controls with CausesValidation = True or else
                ' you will not be able to close the Form until valid data is entered.
                txtTo.CausesValidation = False
                txtFrom.CausesValidation = False
            End If
        End If

        ' Pass other messages on to the original WndProc.
        MyBase.WndProc(m)
    End Sub

    ' Handles the Browse button click event. Uses an OpenFileDialog to allow the 
    ' user to find an attachment to send, which is then added to an arraylist of
    ' MailAttachment objects.
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        With odlgAttachment
            .InitialDirectory = "C:\"
            .Filter = "All Files (*.*)|*.*|HTML Files (*.htm;*.html)|*.htm|Microsoft Mail Documents (*.msg)|*.msg|Word Documents (*.doc)|*.doc|Excel Files(*.xl*)|*.xl*|Excel Worksheets (*.xls)|*.xls|Excel Charts (*.xlc)|*.xlc|PowerPoint Presentations (*.ppt)|*.ppt|Text Files (*.txt)|*.txt"
            .FilterIndex = 1

            ' The OpenFileDialog control only has an Open button, not an OK button.
            ' However, there is no DialogResult.Open enum so use DialogResult.OK.
            If .ShowDialog() = DialogResult.OK Then
                If IsNothing(arlAttachments) Then
                    arlAttachments = New ArrayList()

                    ' Clear the "(No Attachments)" default text in the ListView
                    lstAttachments.Items.Clear()
                End If
                arlAttachments.Add(New MailAttachment(.FileName))

                ' You only want to show the file name. The OpenFileDialog.FileName
                ' property contains the full path. So Split the path and reverse it
                ' to grab the first string in the array, which is just the FileName.
                Dim strFileName() As String = .FileName.Split(New Char() {CChar("\")})
                strFileName.Reverse(strFileName)
                lstAttachments.Items.Add(strFileName(0))
            End If
        End With
    End Sub

    ' Handles the Send button click event. This routine checks for valid email
    ' addresses, builds the body of a message using StringBuilder, creates a 
    ' mail message, and then attempts to send it.
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        ' Perform validation on the To and From email address fields, which are
        ' both required for sending an email.
        Try
            ValidateEmailAddress(txtFrom)
        Catch ex As Exception
            txtFrom.Select(0, txtFrom.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            erpEmailAddresses.SetError(txtFrom, ex.Message)
            Exit Sub
        End Try

        Try
            ValidateEmailAddress(txtTo)
        Catch exp As Exception
            txtTo.Select(0, txtTo.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            erpEmailAddresses.SetError(txtTo, exp.Message)
            Exit Sub
        End Try

        ' Use the StringBuilder class instead of traditional string concatenation.
        ' It is optimized for building strings because it is capable of modifying
        ' the underlying buffer instead of having to make a copy of the string for 
        ' each concatenation. Consult the SDK documentation for more information on 
        ' this new class.
        Dim sb As New StringBuilder()

        ' Build the email message body.
        sb.Append("The following email was sent to you from the Send Mail How-To " & _
            "sample application:")
        sb.Append(vbCrLf)
        sb.Append(vbCrLf)
        sb.Append("SUBJECT: ")
        sb.Append(Trim(txtSubject.Text))
        sb.Append(vbCrLf)
        sb.Append(vbCrLf)
        sb.Append("MESSAGE: ")
        sb.Append(Trim(txtBody.Text))
        sb.Append(vbCrLf)

        ' Creating a mail message is as simple as instantiating a class and 
        ' setting a few properties.
        Dim mailMsg As New MailMessage()
        With mailMsg
            .From = txtFrom.Text.Trim
            .To = txtTo.Text.Trim
            .Cc = txtCC.Text.Trim
            .Bcc = txtBCC.Text.Trim
            .Subject = txtSubject.Text.Trim
            .Body = sb.ToString
            .Priority = CType(cboPriority.SelectedIndex, MailPriority)

            If Not IsNothing(arlAttachments) Then
                Dim mailAttachment As Object
                For Each mailAttachment In arlAttachments
                    .Attachments.Add(mailAttachment)
                Next
            End If
        End With

        ' Set the SmtpServer name. This can be any of the following depending on
        ' your local security settings:

        ' a) Local IP Address (assuming your local machine's SMTP server has the 
        ' right to send messages through a local firewall (if present).

        ' b) 127.0.0.1 the loopback of the local machine.

        ' c) "smarthost" or the name or the IP address of the exchange server you 
        ' utilize for messaging. This is usually what is needed if you are behind
        ' a corporate firewall.

        ' See the Readme file for more information.
        SmtpMail.SmtpServer = "smarthost"

        ' Use structured error handling to attempt to send the email message and 
        ' provide feedback to the user about the success or failure of their 
        ' attempt.
        Try
            SmtpMail.Send(mailMsg)
            lstAttachments.Items.Clear()
            lstAttachments.Items.Add("(No Attachments)")

            MessageBox.Show("Your email has been successfully sent!", _
                "Email Send Status", MessageBoxButtons.OK, _
                MessageBoxIcon.Information)
        Catch exp As Exception
            MessageBox.Show("The following problem occurred when attempting to " & _
                "send your email: " & exp.Message, _
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Handles the event fired when the control is validated.
    Private Sub emailAddresses_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrom.Validated, txtTo.Validated
        ' Clear the ErrorProvider of errors.
        erpEmailAddresses.SetError(CType(sender, TextBox), "")
    End Sub

    ' Handles the event fired when the control starts validating. Cast the sender 
    ' instead of hardcoding the ID of the TextBox (e.g., "txtFrom") undergoing 
    ' validation so that a single routine can handle the validating event for 
    ' more than one TextBox control.
    Private Sub emailAddresses_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFrom.Validating, txtTo.Validating
        Dim txt As TextBox = CType(sender, TextBox)

        Try
            ValidateEmailAddress(txt)
        Catch exp As Exception
            ' Cancel the event and highlight the text to be corrected by the user.
            e.Cancel = True
            txt.Select(0, txt.Text.Length)

            ' Set the ErrorProvider error with the text to display. 
            erpEmailAddresses.SetError(txt, exp.Message)
        End Try
    End Sub

    ' Handles the form Load event. Checks to make sure that the SMTP Service is 
    ' both installed and running.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Ensure the SMTP Service is installed.
        Dim services() As ServiceController = ServiceController.GetServices
        Dim service As ServiceController
        Dim blnHasSmtpService As Boolean = False

        ' Loop through all the services on the machine and find the SMTP Service.
        For Each service In services
            If service.ServiceName.ToLower = "smtpsvc" Then
                blnHasSmtpService = True
                Exit For
            End If
        Next

        If Not blnHasSmtpService Then
            MessageBox.Show("You do not have SMTP Service installed on this " & _
                "machine. Please check the Readme file for information on how " & _
                "to install SMTP Service.", Me.Text, _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' Ensure the SMTP Service is running. If not, start it.
        If Not service.Status = ServiceControllerStatus.Running Then
            Dim frmStatusMessage As New frmStatus()
            frmStatusMessage.Show("SMTP Service not currently running. " & _
                "Starting service...")
            Try
                service.Start()
                frmStatusMessage.Close()
            Catch
                MessageBox.Show("There was an error when attempting " & _
                    "to start SMTP Service. Please consult the Readme " & _
                    "file for more information.", Me.Text, _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        ' Fill the Priority ComboBox with the MailPriority values
        With cboPriority
            .Items.AddRange(New String() {"Normal", "Low", "High"})
            .SelectedIndex = 0
        End With
    End Sub

End Class