'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Drawing.Imaging

Public Class frmMain
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Private blnPictureBoxSizeHasChanged As Boolean = False

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
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents grpSizeMode As System.Windows.Forms.GroupBox
    Friend WithEvents optCenterImage As System.Windows.Forms.RadioButton
    Friend WithEvents optAutoSize As System.Windows.Forms.RadioButton
    Friend WithEvents optStretchImage As System.Windows.Forms.RadioButton
    Friend WithEvents optNormal As System.Windows.Forms.RadioButton
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents odlgImage As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sdlgImage As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnZoomOut As System.Windows.Forms.Button
    Friend WithEvents btnZoomIn As System.Windows.Forms.Button
    Friend WithEvents btnFit As System.Windows.Forms.Button
    Friend WithEvents btnRotateLeft As System.Windows.Forms.Button
    Friend WithEvents grpCropping As System.Windows.Forms.GroupBox
    Friend WithEvents txtYCoord As System.Windows.Forms.TextBox
    Friend WithEvents txtXCoord As System.Windows.Forms.TextBox
    Friend WithEvents lblXCoord As System.Windows.Forms.Label
    Friend WithEvents lblYCoord As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents btnCrop As System.Windows.Forms.Button
    Friend WithEvents btnRotateRight As System.Windows.Forms.Button
    Friend WithEvents btnUndo As System.Windows.Forms.Button
    Friend WithEvents btnShowBox As System.Windows.Forms.Button
    Friend WithEvents chkThumbnail As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.odlgImage = New System.Windows.Forms.OpenFileDialog()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.grpSizeMode = New System.Windows.Forms.GroupBox()
        Me.optCenterImage = New System.Windows.Forms.RadioButton()
        Me.optAutoSize = New System.Windows.Forms.RadioButton()
        Me.optStretchImage = New System.Windows.Forms.RadioButton()
        Me.optNormal = New System.Windows.Forms.RadioButton()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.sdlgImage = New System.Windows.Forms.SaveFileDialog()
        Me.btnZoomOut = New System.Windows.Forms.Button()
        Me.btnZoomIn = New System.Windows.Forms.Button()
        Me.btnFit = New System.Windows.Forms.Button()
        Me.btnRotateLeft = New System.Windows.Forms.Button()
        Me.grpCropping = New System.Windows.Forms.GroupBox()
        Me.btnShowBox = New System.Windows.Forms.Button()
        Me.btnUndo = New System.Windows.Forms.Button()
        Me.btnCrop = New System.Windows.Forms.Button()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.lblYCoord = New System.Windows.Forms.Label()
        Me.lblXCoord = New System.Windows.Forms.Label()
        Me.txtYCoord = New System.Windows.Forms.TextBox()
        Me.txtXCoord = New System.Windows.Forms.TextBox()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.btnRotateRight = New System.Windows.Forms.Button()
        Me.chkThumbnail = New System.Windows.Forms.CheckBox()
        Me.grpSizeMode.SuspendLayout()
        Me.grpCropping.SuspendLayout()
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
        'odlgImage
        '
        Me.odlgImage.Filter = resources.GetString("odlgImage.Filter")
        Me.odlgImage.Title = resources.GetString("odlgImage.Title")
        '
        'picImage
        '
        Me.picImage.AccessibleDescription = resources.GetString("picImage.AccessibleDescription")
        Me.picImage.AccessibleName = resources.GetString("picImage.AccessibleName")
        Me.picImage.Anchor = CType(resources.GetObject("picImage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.picImage.BackgroundImage = CType(resources.GetObject("picImage.BackgroundImage"), System.Drawing.Image)
        Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picImage.Dock = CType(resources.GetObject("picImage.Dock"), System.Windows.Forms.DockStyle)
        Me.picImage.Enabled = CType(resources.GetObject("picImage.Enabled"), Boolean)
        Me.picImage.Font = CType(resources.GetObject("picImage.Font"), System.Drawing.Font)
        Me.picImage.Image = CType(resources.GetObject("picImage.Image"), System.Drawing.Bitmap)
        Me.picImage.ImeMode = CType(resources.GetObject("picImage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.picImage.Location = CType(resources.GetObject("picImage.Location"), System.Drawing.Point)
        Me.picImage.Name = "picImage"
        Me.picImage.RightToLeft = CType(resources.GetObject("picImage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.picImage.Size = CType(resources.GetObject("picImage.Size"), System.Drawing.Size)
        Me.picImage.SizeMode = CType(resources.GetObject("picImage.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.picImage.TabIndex = CType(resources.GetObject("picImage.TabIndex"), Integer)
        Me.picImage.TabStop = False
        Me.picImage.Text = resources.GetString("picImage.Text")
        Me.picImage.Visible = CType(resources.GetObject("picImage.Visible"), Boolean)
        '
        'grpSizeMode
        '
        Me.grpSizeMode.AccessibleDescription = resources.GetString("grpSizeMode.AccessibleDescription")
        Me.grpSizeMode.AccessibleName = resources.GetString("grpSizeMode.AccessibleName")
        Me.grpSizeMode.Anchor = CType(resources.GetObject("grpSizeMode.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grpSizeMode.BackgroundImage = CType(resources.GetObject("grpSizeMode.BackgroundImage"), System.Drawing.Image)
        Me.grpSizeMode.Controls.AddRange(New System.Windows.Forms.Control() {Me.optCenterImage, Me.optAutoSize, Me.optStretchImage, Me.optNormal})
        Me.grpSizeMode.Dock = CType(resources.GetObject("grpSizeMode.Dock"), System.Windows.Forms.DockStyle)
        Me.grpSizeMode.Enabled = CType(resources.GetObject("grpSizeMode.Enabled"), Boolean)
        Me.grpSizeMode.Font = CType(resources.GetObject("grpSizeMode.Font"), System.Drawing.Font)
        Me.grpSizeMode.ImeMode = CType(resources.GetObject("grpSizeMode.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grpSizeMode.Location = CType(resources.GetObject("grpSizeMode.Location"), System.Drawing.Point)
        Me.grpSizeMode.Name = "grpSizeMode"
        Me.grpSizeMode.RightToLeft = CType(resources.GetObject("grpSizeMode.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grpSizeMode.Size = CType(resources.GetObject("grpSizeMode.Size"), System.Drawing.Size)
        Me.grpSizeMode.TabIndex = CType(resources.GetObject("grpSizeMode.TabIndex"), Integer)
        Me.grpSizeMode.TabStop = False
        Me.grpSizeMode.Text = resources.GetString("grpSizeMode.Text")
        Me.grpSizeMode.Visible = CType(resources.GetObject("grpSizeMode.Visible"), Boolean)
        '
        'optCenterImage
        '
        Me.optCenterImage.AccessibleDescription = resources.GetString("optCenterImage.AccessibleDescription")
        Me.optCenterImage.AccessibleName = resources.GetString("optCenterImage.AccessibleName")
        Me.optCenterImage.Anchor = CType(resources.GetObject("optCenterImage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optCenterImage.Appearance = CType(resources.GetObject("optCenterImage.Appearance"), System.Windows.Forms.Appearance)
        Me.optCenterImage.BackgroundImage = CType(resources.GetObject("optCenterImage.BackgroundImage"), System.Drawing.Image)
        Me.optCenterImage.CheckAlign = CType(resources.GetObject("optCenterImage.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optCenterImage.Dock = CType(resources.GetObject("optCenterImage.Dock"), System.Windows.Forms.DockStyle)
        Me.optCenterImage.Enabled = CType(resources.GetObject("optCenterImage.Enabled"), Boolean)
        Me.optCenterImage.FlatStyle = CType(resources.GetObject("optCenterImage.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optCenterImage.Font = CType(resources.GetObject("optCenterImage.Font"), System.Drawing.Font)
        Me.optCenterImage.Image = CType(resources.GetObject("optCenterImage.Image"), System.Drawing.Image)
        Me.optCenterImage.ImageAlign = CType(resources.GetObject("optCenterImage.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optCenterImage.ImageIndex = CType(resources.GetObject("optCenterImage.ImageIndex"), Integer)
        Me.optCenterImage.ImeMode = CType(resources.GetObject("optCenterImage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optCenterImage.Location = CType(resources.GetObject("optCenterImage.Location"), System.Drawing.Point)
        Me.optCenterImage.Name = "optCenterImage"
        Me.optCenterImage.RightToLeft = CType(resources.GetObject("optCenterImage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optCenterImage.Size = CType(resources.GetObject("optCenterImage.Size"), System.Drawing.Size)
        Me.optCenterImage.TabIndex = CType(resources.GetObject("optCenterImage.TabIndex"), Integer)
        Me.optCenterImage.Tag = "3"
        Me.optCenterImage.Text = resources.GetString("optCenterImage.Text")
        Me.optCenterImage.TextAlign = CType(resources.GetObject("optCenterImage.TextAlign"), System.Drawing.ContentAlignment)
        Me.optCenterImage.Visible = CType(resources.GetObject("optCenterImage.Visible"), Boolean)
        '
        'optAutoSize
        '
        Me.optAutoSize.AccessibleDescription = resources.GetString("optAutoSize.AccessibleDescription")
        Me.optAutoSize.AccessibleName = resources.GetString("optAutoSize.AccessibleName")
        Me.optAutoSize.Anchor = CType(resources.GetObject("optAutoSize.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optAutoSize.Appearance = CType(resources.GetObject("optAutoSize.Appearance"), System.Windows.Forms.Appearance)
        Me.optAutoSize.BackgroundImage = CType(resources.GetObject("optAutoSize.BackgroundImage"), System.Drawing.Image)
        Me.optAutoSize.CheckAlign = CType(resources.GetObject("optAutoSize.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optAutoSize.Dock = CType(resources.GetObject("optAutoSize.Dock"), System.Windows.Forms.DockStyle)
        Me.optAutoSize.Enabled = CType(resources.GetObject("optAutoSize.Enabled"), Boolean)
        Me.optAutoSize.FlatStyle = CType(resources.GetObject("optAutoSize.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optAutoSize.Font = CType(resources.GetObject("optAutoSize.Font"), System.Drawing.Font)
        Me.optAutoSize.Image = CType(resources.GetObject("optAutoSize.Image"), System.Drawing.Image)
        Me.optAutoSize.ImageAlign = CType(resources.GetObject("optAutoSize.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optAutoSize.ImageIndex = CType(resources.GetObject("optAutoSize.ImageIndex"), Integer)
        Me.optAutoSize.ImeMode = CType(resources.GetObject("optAutoSize.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optAutoSize.Location = CType(resources.GetObject("optAutoSize.Location"), System.Drawing.Point)
        Me.optAutoSize.Name = "optAutoSize"
        Me.optAutoSize.RightToLeft = CType(resources.GetObject("optAutoSize.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optAutoSize.Size = CType(resources.GetObject("optAutoSize.Size"), System.Drawing.Size)
        Me.optAutoSize.TabIndex = CType(resources.GetObject("optAutoSize.TabIndex"), Integer)
        Me.optAutoSize.Tag = "2"
        Me.optAutoSize.Text = resources.GetString("optAutoSize.Text")
        Me.optAutoSize.TextAlign = CType(resources.GetObject("optAutoSize.TextAlign"), System.Drawing.ContentAlignment)
        Me.optAutoSize.Visible = CType(resources.GetObject("optAutoSize.Visible"), Boolean)
        '
        'optStretchImage
        '
        Me.optStretchImage.AccessibleDescription = resources.GetString("optStretchImage.AccessibleDescription")
        Me.optStretchImage.AccessibleName = resources.GetString("optStretchImage.AccessibleName")
        Me.optStretchImage.Anchor = CType(resources.GetObject("optStretchImage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optStretchImage.Appearance = CType(resources.GetObject("optStretchImage.Appearance"), System.Windows.Forms.Appearance)
        Me.optStretchImage.BackgroundImage = CType(resources.GetObject("optStretchImage.BackgroundImage"), System.Drawing.Image)
        Me.optStretchImage.CheckAlign = CType(resources.GetObject("optStretchImage.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optStretchImage.Dock = CType(resources.GetObject("optStretchImage.Dock"), System.Windows.Forms.DockStyle)
        Me.optStretchImage.Enabled = CType(resources.GetObject("optStretchImage.Enabled"), Boolean)
        Me.optStretchImage.FlatStyle = CType(resources.GetObject("optStretchImage.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optStretchImage.Font = CType(resources.GetObject("optStretchImage.Font"), System.Drawing.Font)
        Me.optStretchImage.Image = CType(resources.GetObject("optStretchImage.Image"), System.Drawing.Image)
        Me.optStretchImage.ImageAlign = CType(resources.GetObject("optStretchImage.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optStretchImage.ImageIndex = CType(resources.GetObject("optStretchImage.ImageIndex"), Integer)
        Me.optStretchImage.ImeMode = CType(resources.GetObject("optStretchImage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optStretchImage.Location = CType(resources.GetObject("optStretchImage.Location"), System.Drawing.Point)
        Me.optStretchImage.Name = "optStretchImage"
        Me.optStretchImage.RightToLeft = CType(resources.GetObject("optStretchImage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optStretchImage.Size = CType(resources.GetObject("optStretchImage.Size"), System.Drawing.Size)
        Me.optStretchImage.TabIndex = CType(resources.GetObject("optStretchImage.TabIndex"), Integer)
        Me.optStretchImage.Tag = "1"
        Me.optStretchImage.Text = resources.GetString("optStretchImage.Text")
        Me.optStretchImage.TextAlign = CType(resources.GetObject("optStretchImage.TextAlign"), System.Drawing.ContentAlignment)
        Me.optStretchImage.Visible = CType(resources.GetObject("optStretchImage.Visible"), Boolean)
        '
        'optNormal
        '
        Me.optNormal.AccessibleDescription = resources.GetString("optNormal.AccessibleDescription")
        Me.optNormal.AccessibleName = resources.GetString("optNormal.AccessibleName")
        Me.optNormal.Anchor = CType(resources.GetObject("optNormal.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.optNormal.Appearance = CType(resources.GetObject("optNormal.Appearance"), System.Windows.Forms.Appearance)
        Me.optNormal.BackgroundImage = CType(resources.GetObject("optNormal.BackgroundImage"), System.Drawing.Image)
        Me.optNormal.CheckAlign = CType(resources.GetObject("optNormal.CheckAlign"), System.Drawing.ContentAlignment)
        Me.optNormal.Checked = True
        Me.optNormal.Dock = CType(resources.GetObject("optNormal.Dock"), System.Windows.Forms.DockStyle)
        Me.optNormal.Enabled = CType(resources.GetObject("optNormal.Enabled"), Boolean)
        Me.optNormal.FlatStyle = CType(resources.GetObject("optNormal.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.optNormal.Font = CType(resources.GetObject("optNormal.Font"), System.Drawing.Font)
        Me.optNormal.Image = CType(resources.GetObject("optNormal.Image"), System.Drawing.Image)
        Me.optNormal.ImageAlign = CType(resources.GetObject("optNormal.ImageAlign"), System.Drawing.ContentAlignment)
        Me.optNormal.ImageIndex = CType(resources.GetObject("optNormal.ImageIndex"), Integer)
        Me.optNormal.ImeMode = CType(resources.GetObject("optNormal.ImeMode"), System.Windows.Forms.ImeMode)
        Me.optNormal.Location = CType(resources.GetObject("optNormal.Location"), System.Drawing.Point)
        Me.optNormal.Name = "optNormal"
        Me.optNormal.RightToLeft = CType(resources.GetObject("optNormal.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.optNormal.Size = CType(resources.GetObject("optNormal.Size"), System.Drawing.Size)
        Me.optNormal.TabIndex = CType(resources.GetObject("optNormal.TabIndex"), Integer)
        Me.optNormal.TabStop = True
        Me.optNormal.Tag = "0"
        Me.optNormal.Text = resources.GetString("optNormal.Text")
        Me.optNormal.TextAlign = CType(resources.GetObject("optNormal.TextAlign"), System.Drawing.ContentAlignment)
        Me.optNormal.Visible = CType(resources.GetObject("optNormal.Visible"), Boolean)
        '
        'btnBrowse
        '
        Me.btnBrowse.AccessibleDescription = resources.GetString("btnBrowse.AccessibleDescription")
        Me.btnBrowse.AccessibleName = resources.GetString("btnBrowse.AccessibleName")
        Me.btnBrowse.Anchor = CType(resources.GetObject("btnBrowse.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackgroundImage = CType(resources.GetObject("btnBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse.Dock = CType(resources.GetObject("btnBrowse.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBrowse.Enabled = CType(resources.GetObject("btnBrowse.Enabled"), Boolean)
        Me.btnBrowse.FlatStyle = CType(resources.GetObject("btnBrowse.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBrowse.Font = CType(resources.GetObject("btnBrowse.Font"), System.Drawing.Font)
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
        'btnSave
        '
        Me.btnSave.AccessibleDescription = resources.GetString("btnSave.AccessibleDescription")
        Me.btnSave.AccessibleName = resources.GetString("btnSave.AccessibleName")
        Me.btnSave.Anchor = CType(resources.GetObject("btnSave.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.Dock = CType(resources.GetObject("btnSave.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSave.Enabled = CType(resources.GetObject("btnSave.Enabled"), Boolean)
        Me.btnSave.FlatStyle = CType(resources.GetObject("btnSave.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSave.Font = CType(resources.GetObject("btnSave.Font"), System.Drawing.Font)
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = CType(resources.GetObject("btnSave.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSave.ImageIndex = CType(resources.GetObject("btnSave.ImageIndex"), Integer)
        Me.btnSave.ImeMode = CType(resources.GetObject("btnSave.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSave.Location = CType(resources.GetObject("btnSave.Location"), System.Drawing.Point)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RightToLeft = CType(resources.GetObject("btnSave.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSave.Size = CType(resources.GetObject("btnSave.Size"), System.Drawing.Size)
        Me.btnSave.TabIndex = CType(resources.GetObject("btnSave.TabIndex"), Integer)
        Me.btnSave.Text = resources.GetString("btnSave.Text")
        Me.btnSave.TextAlign = CType(resources.GetObject("btnSave.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSave.Visible = CType(resources.GetObject("btnSave.Visible"), Boolean)
        '
        'sdlgImage
        '
        Me.sdlgImage.FileName = "doc1"
        Me.sdlgImage.Filter = resources.GetString("sdlgImage.Filter")
        Me.sdlgImage.Title = resources.GetString("sdlgImage.Title")
        '
        'btnZoomOut
        '
        Me.btnZoomOut.AccessibleDescription = resources.GetString("btnZoomOut.AccessibleDescription")
        Me.btnZoomOut.AccessibleName = resources.GetString("btnZoomOut.AccessibleName")
        Me.btnZoomOut.Anchor = CType(resources.GetObject("btnZoomOut.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnZoomOut.BackgroundImage = CType(resources.GetObject("btnZoomOut.BackgroundImage"), System.Drawing.Image)
        Me.btnZoomOut.Dock = CType(resources.GetObject("btnZoomOut.Dock"), System.Windows.Forms.DockStyle)
        Me.btnZoomOut.Enabled = CType(resources.GetObject("btnZoomOut.Enabled"), Boolean)
        Me.btnZoomOut.FlatStyle = CType(resources.GetObject("btnZoomOut.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnZoomOut.Font = CType(resources.GetObject("btnZoomOut.Font"), System.Drawing.Font)
        Me.btnZoomOut.Image = CType(resources.GetObject("btnZoomOut.Image"), System.Drawing.Image)
        Me.btnZoomOut.ImageAlign = CType(resources.GetObject("btnZoomOut.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnZoomOut.ImageIndex = CType(resources.GetObject("btnZoomOut.ImageIndex"), Integer)
        Me.btnZoomOut.ImeMode = CType(resources.GetObject("btnZoomOut.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnZoomOut.Location = CType(resources.GetObject("btnZoomOut.Location"), System.Drawing.Point)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.RightToLeft = CType(resources.GetObject("btnZoomOut.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnZoomOut.Size = CType(resources.GetObject("btnZoomOut.Size"), System.Drawing.Size)
        Me.btnZoomOut.TabIndex = CType(resources.GetObject("btnZoomOut.TabIndex"), Integer)
        Me.btnZoomOut.Text = resources.GetString("btnZoomOut.Text")
        Me.btnZoomOut.TextAlign = CType(resources.GetObject("btnZoomOut.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnZoomOut.Visible = CType(resources.GetObject("btnZoomOut.Visible"), Boolean)
        '
        'btnZoomIn
        '
        Me.btnZoomIn.AccessibleDescription = resources.GetString("btnZoomIn.AccessibleDescription")
        Me.btnZoomIn.AccessibleName = resources.GetString("btnZoomIn.AccessibleName")
        Me.btnZoomIn.Anchor = CType(resources.GetObject("btnZoomIn.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnZoomIn.BackgroundImage = CType(resources.GetObject("btnZoomIn.BackgroundImage"), System.Drawing.Image)
        Me.btnZoomIn.Dock = CType(resources.GetObject("btnZoomIn.Dock"), System.Windows.Forms.DockStyle)
        Me.btnZoomIn.Enabled = CType(resources.GetObject("btnZoomIn.Enabled"), Boolean)
        Me.btnZoomIn.FlatStyle = CType(resources.GetObject("btnZoomIn.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnZoomIn.Font = CType(resources.GetObject("btnZoomIn.Font"), System.Drawing.Font)
        Me.btnZoomIn.Image = CType(resources.GetObject("btnZoomIn.Image"), System.Drawing.Image)
        Me.btnZoomIn.ImageAlign = CType(resources.GetObject("btnZoomIn.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnZoomIn.ImageIndex = CType(resources.GetObject("btnZoomIn.ImageIndex"), Integer)
        Me.btnZoomIn.ImeMode = CType(resources.GetObject("btnZoomIn.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnZoomIn.Location = CType(resources.GetObject("btnZoomIn.Location"), System.Drawing.Point)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.RightToLeft = CType(resources.GetObject("btnZoomIn.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnZoomIn.Size = CType(resources.GetObject("btnZoomIn.Size"), System.Drawing.Size)
        Me.btnZoomIn.TabIndex = CType(resources.GetObject("btnZoomIn.TabIndex"), Integer)
        Me.btnZoomIn.Text = resources.GetString("btnZoomIn.Text")
        Me.btnZoomIn.TextAlign = CType(resources.GetObject("btnZoomIn.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnZoomIn.Visible = CType(resources.GetObject("btnZoomIn.Visible"), Boolean)
        '
        'btnFit
        '
        Me.btnFit.AccessibleDescription = resources.GetString("btnFit.AccessibleDescription")
        Me.btnFit.AccessibleName = resources.GetString("btnFit.AccessibleName")
        Me.btnFit.Anchor = CType(resources.GetObject("btnFit.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnFit.BackgroundImage = CType(resources.GetObject("btnFit.BackgroundImage"), System.Drawing.Image)
        Me.btnFit.Dock = CType(resources.GetObject("btnFit.Dock"), System.Windows.Forms.DockStyle)
        Me.btnFit.Enabled = CType(resources.GetObject("btnFit.Enabled"), Boolean)
        Me.btnFit.FlatStyle = CType(resources.GetObject("btnFit.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnFit.Font = CType(resources.GetObject("btnFit.Font"), System.Drawing.Font)
        Me.btnFit.Image = CType(resources.GetObject("btnFit.Image"), System.Drawing.Image)
        Me.btnFit.ImageAlign = CType(resources.GetObject("btnFit.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnFit.ImageIndex = CType(resources.GetObject("btnFit.ImageIndex"), Integer)
        Me.btnFit.ImeMode = CType(resources.GetObject("btnFit.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnFit.Location = CType(resources.GetObject("btnFit.Location"), System.Drawing.Point)
        Me.btnFit.Name = "btnFit"
        Me.btnFit.RightToLeft = CType(resources.GetObject("btnFit.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnFit.Size = CType(resources.GetObject("btnFit.Size"), System.Drawing.Size)
        Me.btnFit.TabIndex = CType(resources.GetObject("btnFit.TabIndex"), Integer)
        Me.btnFit.Text = resources.GetString("btnFit.Text")
        Me.btnFit.TextAlign = CType(resources.GetObject("btnFit.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnFit.Visible = CType(resources.GetObject("btnFit.Visible"), Boolean)
        '
        'btnRotateLeft
        '
        Me.btnRotateLeft.AccessibleDescription = resources.GetString("btnRotateLeft.AccessibleDescription")
        Me.btnRotateLeft.AccessibleName = resources.GetString("btnRotateLeft.AccessibleName")
        Me.btnRotateLeft.Anchor = CType(resources.GetObject("btnRotateLeft.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRotateLeft.BackgroundImage = CType(resources.GetObject("btnRotateLeft.BackgroundImage"), System.Drawing.Image)
        Me.btnRotateLeft.Dock = CType(resources.GetObject("btnRotateLeft.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRotateLeft.Enabled = CType(resources.GetObject("btnRotateLeft.Enabled"), Boolean)
        Me.btnRotateLeft.FlatStyle = CType(resources.GetObject("btnRotateLeft.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRotateLeft.Font = CType(resources.GetObject("btnRotateLeft.Font"), System.Drawing.Font)
        Me.btnRotateLeft.Image = CType(resources.GetObject("btnRotateLeft.Image"), System.Drawing.Image)
        Me.btnRotateLeft.ImageAlign = CType(resources.GetObject("btnRotateLeft.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRotateLeft.ImageIndex = CType(resources.GetObject("btnRotateLeft.ImageIndex"), Integer)
        Me.btnRotateLeft.ImeMode = CType(resources.GetObject("btnRotateLeft.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRotateLeft.Location = CType(resources.GetObject("btnRotateLeft.Location"), System.Drawing.Point)
        Me.btnRotateLeft.Name = "btnRotateLeft"
        Me.btnRotateLeft.RightToLeft = CType(resources.GetObject("btnRotateLeft.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRotateLeft.Size = CType(resources.GetObject("btnRotateLeft.Size"), System.Drawing.Size)
        Me.btnRotateLeft.TabIndex = CType(resources.GetObject("btnRotateLeft.TabIndex"), Integer)
        Me.btnRotateLeft.Text = resources.GetString("btnRotateLeft.Text")
        Me.btnRotateLeft.TextAlign = CType(resources.GetObject("btnRotateLeft.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRotateLeft.Visible = CType(resources.GetObject("btnRotateLeft.Visible"), Boolean)
        '
        'grpCropping
        '
        Me.grpCropping.AccessibleDescription = resources.GetString("grpCropping.AccessibleDescription")
        Me.grpCropping.AccessibleName = resources.GetString("grpCropping.AccessibleName")
        Me.grpCropping.Anchor = CType(resources.GetObject("grpCropping.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grpCropping.BackgroundImage = CType(resources.GetObject("grpCropping.BackgroundImage"), System.Drawing.Image)
        Me.grpCropping.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnShowBox, Me.btnUndo, Me.btnCrop, Me.txtHeight, Me.txtWidth, Me.lblYCoord, Me.lblXCoord, Me.txtYCoord, Me.txtXCoord, Me.lblHeight, Me.lblWidth})
        Me.grpCropping.Dock = CType(resources.GetObject("grpCropping.Dock"), System.Windows.Forms.DockStyle)
        Me.grpCropping.Enabled = CType(resources.GetObject("grpCropping.Enabled"), Boolean)
        Me.grpCropping.Font = CType(resources.GetObject("grpCropping.Font"), System.Drawing.Font)
        Me.grpCropping.ImeMode = CType(resources.GetObject("grpCropping.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grpCropping.Location = CType(resources.GetObject("grpCropping.Location"), System.Drawing.Point)
        Me.grpCropping.Name = "grpCropping"
        Me.grpCropping.RightToLeft = CType(resources.GetObject("grpCropping.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grpCropping.Size = CType(resources.GetObject("grpCropping.Size"), System.Drawing.Size)
        Me.grpCropping.TabIndex = CType(resources.GetObject("grpCropping.TabIndex"), Integer)
        Me.grpCropping.TabStop = False
        Me.grpCropping.Text = resources.GetString("grpCropping.Text")
        Me.grpCropping.Visible = CType(resources.GetObject("grpCropping.Visible"), Boolean)
        '
        'btnShowBox
        '
        Me.btnShowBox.AccessibleDescription = resources.GetString("btnShowBox.AccessibleDescription")
        Me.btnShowBox.AccessibleName = resources.GetString("btnShowBox.AccessibleName")
        Me.btnShowBox.Anchor = CType(resources.GetObject("btnShowBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnShowBox.BackgroundImage = CType(resources.GetObject("btnShowBox.BackgroundImage"), System.Drawing.Image)
        Me.btnShowBox.Dock = CType(resources.GetObject("btnShowBox.Dock"), System.Windows.Forms.DockStyle)
        Me.btnShowBox.Enabled = CType(resources.GetObject("btnShowBox.Enabled"), Boolean)
        Me.btnShowBox.FlatStyle = CType(resources.GetObject("btnShowBox.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnShowBox.Font = CType(resources.GetObject("btnShowBox.Font"), System.Drawing.Font)
        Me.btnShowBox.Image = CType(resources.GetObject("btnShowBox.Image"), System.Drawing.Image)
        Me.btnShowBox.ImageAlign = CType(resources.GetObject("btnShowBox.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnShowBox.ImageIndex = CType(resources.GetObject("btnShowBox.ImageIndex"), Integer)
        Me.btnShowBox.ImeMode = CType(resources.GetObject("btnShowBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnShowBox.Location = CType(resources.GetObject("btnShowBox.Location"), System.Drawing.Point)
        Me.btnShowBox.Name = "btnShowBox"
        Me.btnShowBox.RightToLeft = CType(resources.GetObject("btnShowBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnShowBox.Size = CType(resources.GetObject("btnShowBox.Size"), System.Drawing.Size)
        Me.btnShowBox.TabIndex = CType(resources.GetObject("btnShowBox.TabIndex"), Integer)
        Me.btnShowBox.Text = resources.GetString("btnShowBox.Text")
        Me.btnShowBox.TextAlign = CType(resources.GetObject("btnShowBox.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnShowBox.Visible = CType(resources.GetObject("btnShowBox.Visible"), Boolean)
        '
        'btnUndo
        '
        Me.btnUndo.AccessibleDescription = resources.GetString("btnUndo.AccessibleDescription")
        Me.btnUndo.AccessibleName = resources.GetString("btnUndo.AccessibleName")
        Me.btnUndo.Anchor = CType(resources.GetObject("btnUndo.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnUndo.BackgroundImage = CType(resources.GetObject("btnUndo.BackgroundImage"), System.Drawing.Image)
        Me.btnUndo.Dock = CType(resources.GetObject("btnUndo.Dock"), System.Windows.Forms.DockStyle)
        Me.btnUndo.Enabled = CType(resources.GetObject("btnUndo.Enabled"), Boolean)
        Me.btnUndo.FlatStyle = CType(resources.GetObject("btnUndo.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnUndo.Font = CType(resources.GetObject("btnUndo.Font"), System.Drawing.Font)
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageAlign = CType(resources.GetObject("btnUndo.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnUndo.ImageIndex = CType(resources.GetObject("btnUndo.ImageIndex"), Integer)
        Me.btnUndo.ImeMode = CType(resources.GetObject("btnUndo.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnUndo.Location = CType(resources.GetObject("btnUndo.Location"), System.Drawing.Point)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.RightToLeft = CType(resources.GetObject("btnUndo.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnUndo.Size = CType(resources.GetObject("btnUndo.Size"), System.Drawing.Size)
        Me.btnUndo.TabIndex = CType(resources.GetObject("btnUndo.TabIndex"), Integer)
        Me.btnUndo.Text = resources.GetString("btnUndo.Text")
        Me.btnUndo.TextAlign = CType(resources.GetObject("btnUndo.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnUndo.Visible = CType(resources.GetObject("btnUndo.Visible"), Boolean)
        '
        'btnCrop
        '
        Me.btnCrop.AccessibleDescription = resources.GetString("btnCrop.AccessibleDescription")
        Me.btnCrop.AccessibleName = resources.GetString("btnCrop.AccessibleName")
        Me.btnCrop.Anchor = CType(resources.GetObject("btnCrop.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCrop.BackgroundImage = CType(resources.GetObject("btnCrop.BackgroundImage"), System.Drawing.Image)
        Me.btnCrop.Dock = CType(resources.GetObject("btnCrop.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCrop.Enabled = CType(resources.GetObject("btnCrop.Enabled"), Boolean)
        Me.btnCrop.FlatStyle = CType(resources.GetObject("btnCrop.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCrop.Font = CType(resources.GetObject("btnCrop.Font"), System.Drawing.Font)
        Me.btnCrop.Image = CType(resources.GetObject("btnCrop.Image"), System.Drawing.Image)
        Me.btnCrop.ImageAlign = CType(resources.GetObject("btnCrop.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCrop.ImageIndex = CType(resources.GetObject("btnCrop.ImageIndex"), Integer)
        Me.btnCrop.ImeMode = CType(resources.GetObject("btnCrop.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCrop.Location = CType(resources.GetObject("btnCrop.Location"), System.Drawing.Point)
        Me.btnCrop.Name = "btnCrop"
        Me.btnCrop.RightToLeft = CType(resources.GetObject("btnCrop.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCrop.Size = CType(resources.GetObject("btnCrop.Size"), System.Drawing.Size)
        Me.btnCrop.TabIndex = CType(resources.GetObject("btnCrop.TabIndex"), Integer)
        Me.btnCrop.Text = resources.GetString("btnCrop.Text")
        Me.btnCrop.TextAlign = CType(resources.GetObject("btnCrop.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCrop.Visible = CType(resources.GetObject("btnCrop.Visible"), Boolean)
        '
        'txtHeight
        '
        Me.txtHeight.AccessibleDescription = resources.GetString("txtHeight.AccessibleDescription")
        Me.txtHeight.AccessibleName = resources.GetString("txtHeight.AccessibleName")
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
        Me.txtHeight.Tag = "Height"
        Me.txtHeight.Text = resources.GetString("txtHeight.Text")
        Me.txtHeight.TextAlign = CType(resources.GetObject("txtHeight.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtHeight.Visible = CType(resources.GetObject("txtHeight.Visible"), Boolean)
        Me.txtHeight.WordWrap = CType(resources.GetObject("txtHeight.WordWrap"), Boolean)
        '
        'txtWidth
        '
        Me.txtWidth.AccessibleDescription = resources.GetString("txtWidth.AccessibleDescription")
        Me.txtWidth.AccessibleName = resources.GetString("txtWidth.AccessibleName")
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
        Me.txtWidth.Tag = "Width"
        Me.txtWidth.Text = resources.GetString("txtWidth.Text")
        Me.txtWidth.TextAlign = CType(resources.GetObject("txtWidth.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtWidth.Visible = CType(resources.GetObject("txtWidth.Visible"), Boolean)
        Me.txtWidth.WordWrap = CType(resources.GetObject("txtWidth.WordWrap"), Boolean)
        '
        'lblYCoord
        '
        Me.lblYCoord.AccessibleDescription = resources.GetString("lblYCoord.AccessibleDescription")
        Me.lblYCoord.AccessibleName = resources.GetString("lblYCoord.AccessibleName")
        Me.lblYCoord.Anchor = CType(resources.GetObject("lblYCoord.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblYCoord.AutoSize = CType(resources.GetObject("lblYCoord.AutoSize"), Boolean)
        Me.lblYCoord.Dock = CType(resources.GetObject("lblYCoord.Dock"), System.Windows.Forms.DockStyle)
        Me.lblYCoord.Enabled = CType(resources.GetObject("lblYCoord.Enabled"), Boolean)
        Me.lblYCoord.Font = CType(resources.GetObject("lblYCoord.Font"), System.Drawing.Font)
        Me.lblYCoord.Image = CType(resources.GetObject("lblYCoord.Image"), System.Drawing.Image)
        Me.lblYCoord.ImageAlign = CType(resources.GetObject("lblYCoord.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblYCoord.ImageIndex = CType(resources.GetObject("lblYCoord.ImageIndex"), Integer)
        Me.lblYCoord.ImeMode = CType(resources.GetObject("lblYCoord.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblYCoord.Location = CType(resources.GetObject("lblYCoord.Location"), System.Drawing.Point)
        Me.lblYCoord.Name = "lblYCoord"
        Me.lblYCoord.RightToLeft = CType(resources.GetObject("lblYCoord.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblYCoord.Size = CType(resources.GetObject("lblYCoord.Size"), System.Drawing.Size)
        Me.lblYCoord.TabIndex = CType(resources.GetObject("lblYCoord.TabIndex"), Integer)
        Me.lblYCoord.Text = resources.GetString("lblYCoord.Text")
        Me.lblYCoord.TextAlign = CType(resources.GetObject("lblYCoord.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblYCoord.Visible = CType(resources.GetObject("lblYCoord.Visible"), Boolean)
        '
        'lblXCoord
        '
        Me.lblXCoord.AccessibleDescription = resources.GetString("lblXCoord.AccessibleDescription")
        Me.lblXCoord.AccessibleName = resources.GetString("lblXCoord.AccessibleName")
        Me.lblXCoord.Anchor = CType(resources.GetObject("lblXCoord.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblXCoord.AutoSize = CType(resources.GetObject("lblXCoord.AutoSize"), Boolean)
        Me.lblXCoord.Dock = CType(resources.GetObject("lblXCoord.Dock"), System.Windows.Forms.DockStyle)
        Me.lblXCoord.Enabled = CType(resources.GetObject("lblXCoord.Enabled"), Boolean)
        Me.lblXCoord.Font = CType(resources.GetObject("lblXCoord.Font"), System.Drawing.Font)
        Me.lblXCoord.Image = CType(resources.GetObject("lblXCoord.Image"), System.Drawing.Image)
        Me.lblXCoord.ImageAlign = CType(resources.GetObject("lblXCoord.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblXCoord.ImageIndex = CType(resources.GetObject("lblXCoord.ImageIndex"), Integer)
        Me.lblXCoord.ImeMode = CType(resources.GetObject("lblXCoord.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblXCoord.Location = CType(resources.GetObject("lblXCoord.Location"), System.Drawing.Point)
        Me.lblXCoord.Name = "lblXCoord"
        Me.lblXCoord.RightToLeft = CType(resources.GetObject("lblXCoord.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblXCoord.Size = CType(resources.GetObject("lblXCoord.Size"), System.Drawing.Size)
        Me.lblXCoord.TabIndex = CType(resources.GetObject("lblXCoord.TabIndex"), Integer)
        Me.lblXCoord.Text = resources.GetString("lblXCoord.Text")
        Me.lblXCoord.TextAlign = CType(resources.GetObject("lblXCoord.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblXCoord.Visible = CType(resources.GetObject("lblXCoord.Visible"), Boolean)
        '
        'txtYCoord
        '
        Me.txtYCoord.AccessibleDescription = resources.GetString("txtYCoord.AccessibleDescription")
        Me.txtYCoord.AccessibleName = resources.GetString("txtYCoord.AccessibleName")
        Me.txtYCoord.Anchor = CType(resources.GetObject("txtYCoord.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtYCoord.AutoSize = CType(resources.GetObject("txtYCoord.AutoSize"), Boolean)
        Me.txtYCoord.BackgroundImage = CType(resources.GetObject("txtYCoord.BackgroundImage"), System.Drawing.Image)
        Me.txtYCoord.Dock = CType(resources.GetObject("txtYCoord.Dock"), System.Windows.Forms.DockStyle)
        Me.txtYCoord.Enabled = CType(resources.GetObject("txtYCoord.Enabled"), Boolean)
        Me.txtYCoord.Font = CType(resources.GetObject("txtYCoord.Font"), System.Drawing.Font)
        Me.txtYCoord.ImeMode = CType(resources.GetObject("txtYCoord.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtYCoord.Location = CType(resources.GetObject("txtYCoord.Location"), System.Drawing.Point)
        Me.txtYCoord.MaxLength = CType(resources.GetObject("txtYCoord.MaxLength"), Integer)
        Me.txtYCoord.Multiline = CType(resources.GetObject("txtYCoord.Multiline"), Boolean)
        Me.txtYCoord.Name = "txtYCoord"
        Me.txtYCoord.PasswordChar = CType(resources.GetObject("txtYCoord.PasswordChar"), Char)
        Me.txtYCoord.RightToLeft = CType(resources.GetObject("txtYCoord.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtYCoord.ScrollBars = CType(resources.GetObject("txtYCoord.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtYCoord.Size = CType(resources.GetObject("txtYCoord.Size"), System.Drawing.Size)
        Me.txtYCoord.TabIndex = CType(resources.GetObject("txtYCoord.TabIndex"), Integer)
        Me.txtYCoord.Tag = "The Y Coordinate"
        Me.txtYCoord.Text = resources.GetString("txtYCoord.Text")
        Me.txtYCoord.TextAlign = CType(resources.GetObject("txtYCoord.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtYCoord.Visible = CType(resources.GetObject("txtYCoord.Visible"), Boolean)
        Me.txtYCoord.WordWrap = CType(resources.GetObject("txtYCoord.WordWrap"), Boolean)
        '
        'txtXCoord
        '
        Me.txtXCoord.AccessibleDescription = resources.GetString("txtXCoord.AccessibleDescription")
        Me.txtXCoord.AccessibleName = resources.GetString("txtXCoord.AccessibleName")
        Me.txtXCoord.Anchor = CType(resources.GetObject("txtXCoord.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtXCoord.AutoSize = CType(resources.GetObject("txtXCoord.AutoSize"), Boolean)
        Me.txtXCoord.BackgroundImage = CType(resources.GetObject("txtXCoord.BackgroundImage"), System.Drawing.Image)
        Me.txtXCoord.Dock = CType(resources.GetObject("txtXCoord.Dock"), System.Windows.Forms.DockStyle)
        Me.txtXCoord.Enabled = CType(resources.GetObject("txtXCoord.Enabled"), Boolean)
        Me.txtXCoord.Font = CType(resources.GetObject("txtXCoord.Font"), System.Drawing.Font)
        Me.txtXCoord.ImeMode = CType(resources.GetObject("txtXCoord.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtXCoord.Location = CType(resources.GetObject("txtXCoord.Location"), System.Drawing.Point)
        Me.txtXCoord.MaxLength = CType(resources.GetObject("txtXCoord.MaxLength"), Integer)
        Me.txtXCoord.Multiline = CType(resources.GetObject("txtXCoord.Multiline"), Boolean)
        Me.txtXCoord.Name = "txtXCoord"
        Me.txtXCoord.PasswordChar = CType(resources.GetObject("txtXCoord.PasswordChar"), Char)
        Me.txtXCoord.RightToLeft = CType(resources.GetObject("txtXCoord.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtXCoord.ScrollBars = CType(resources.GetObject("txtXCoord.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtXCoord.Size = CType(resources.GetObject("txtXCoord.Size"), System.Drawing.Size)
        Me.txtXCoord.TabIndex = CType(resources.GetObject("txtXCoord.TabIndex"), Integer)
        Me.txtXCoord.Tag = "The X Coordinate"
        Me.txtXCoord.Text = resources.GetString("txtXCoord.Text")
        Me.txtXCoord.TextAlign = CType(resources.GetObject("txtXCoord.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtXCoord.Visible = CType(resources.GetObject("txtXCoord.Visible"), Boolean)
        Me.txtXCoord.WordWrap = CType(resources.GetObject("txtXCoord.WordWrap"), Boolean)
        '
        'lblHeight
        '
        Me.lblHeight.AccessibleDescription = resources.GetString("lblHeight.AccessibleDescription")
        Me.lblHeight.AccessibleName = resources.GetString("lblHeight.AccessibleName")
        Me.lblHeight.Anchor = CType(resources.GetObject("lblHeight.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblHeight.AutoSize = CType(resources.GetObject("lblHeight.AutoSize"), Boolean)
        Me.lblHeight.Dock = CType(resources.GetObject("lblHeight.Dock"), System.Windows.Forms.DockStyle)
        Me.lblHeight.Enabled = CType(resources.GetObject("lblHeight.Enabled"), Boolean)
        Me.lblHeight.Font = CType(resources.GetObject("lblHeight.Font"), System.Drawing.Font)
        Me.lblHeight.Image = CType(resources.GetObject("lblHeight.Image"), System.Drawing.Image)
        Me.lblHeight.ImageAlign = CType(resources.GetObject("lblHeight.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblHeight.ImageIndex = CType(resources.GetObject("lblHeight.ImageIndex"), Integer)
        Me.lblHeight.ImeMode = CType(resources.GetObject("lblHeight.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblHeight.Location = CType(resources.GetObject("lblHeight.Location"), System.Drawing.Point)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.RightToLeft = CType(resources.GetObject("lblHeight.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblHeight.Size = CType(resources.GetObject("lblHeight.Size"), System.Drawing.Size)
        Me.lblHeight.TabIndex = CType(resources.GetObject("lblHeight.TabIndex"), Integer)
        Me.lblHeight.Text = resources.GetString("lblHeight.Text")
        Me.lblHeight.TextAlign = CType(resources.GetObject("lblHeight.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblHeight.Visible = CType(resources.GetObject("lblHeight.Visible"), Boolean)
        '
        'lblWidth
        '
        Me.lblWidth.AccessibleDescription = resources.GetString("lblWidth.AccessibleDescription")
        Me.lblWidth.AccessibleName = resources.GetString("lblWidth.AccessibleName")
        Me.lblWidth.Anchor = CType(resources.GetObject("lblWidth.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblWidth.AutoSize = CType(resources.GetObject("lblWidth.AutoSize"), Boolean)
        Me.lblWidth.Dock = CType(resources.GetObject("lblWidth.Dock"), System.Windows.Forms.DockStyle)
        Me.lblWidth.Enabled = CType(resources.GetObject("lblWidth.Enabled"), Boolean)
        Me.lblWidth.Font = CType(resources.GetObject("lblWidth.Font"), System.Drawing.Font)
        Me.lblWidth.Image = CType(resources.GetObject("lblWidth.Image"), System.Drawing.Image)
        Me.lblWidth.ImageAlign = CType(resources.GetObject("lblWidth.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblWidth.ImageIndex = CType(resources.GetObject("lblWidth.ImageIndex"), Integer)
        Me.lblWidth.ImeMode = CType(resources.GetObject("lblWidth.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblWidth.Location = CType(resources.GetObject("lblWidth.Location"), System.Drawing.Point)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.RightToLeft = CType(resources.GetObject("lblWidth.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblWidth.Size = CType(resources.GetObject("lblWidth.Size"), System.Drawing.Size)
        Me.lblWidth.TabIndex = CType(resources.GetObject("lblWidth.TabIndex"), Integer)
        Me.lblWidth.Text = resources.GetString("lblWidth.Text")
        Me.lblWidth.TextAlign = CType(resources.GetObject("lblWidth.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblWidth.Visible = CType(resources.GetObject("lblWidth.Visible"), Boolean)
        '
        'btnRotateRight
        '
        Me.btnRotateRight.AccessibleDescription = resources.GetString("btnRotateRight.AccessibleDescription")
        Me.btnRotateRight.AccessibleName = resources.GetString("btnRotateRight.AccessibleName")
        Me.btnRotateRight.Anchor = CType(resources.GetObject("btnRotateRight.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRotateRight.BackgroundImage = CType(resources.GetObject("btnRotateRight.BackgroundImage"), System.Drawing.Image)
        Me.btnRotateRight.Dock = CType(resources.GetObject("btnRotateRight.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRotateRight.Enabled = CType(resources.GetObject("btnRotateRight.Enabled"), Boolean)
        Me.btnRotateRight.FlatStyle = CType(resources.GetObject("btnRotateRight.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRotateRight.Font = CType(resources.GetObject("btnRotateRight.Font"), System.Drawing.Font)
        Me.btnRotateRight.Image = CType(resources.GetObject("btnRotateRight.Image"), System.Drawing.Image)
        Me.btnRotateRight.ImageAlign = CType(resources.GetObject("btnRotateRight.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRotateRight.ImageIndex = CType(resources.GetObject("btnRotateRight.ImageIndex"), Integer)
        Me.btnRotateRight.ImeMode = CType(resources.GetObject("btnRotateRight.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRotateRight.Location = CType(resources.GetObject("btnRotateRight.Location"), System.Drawing.Point)
        Me.btnRotateRight.Name = "btnRotateRight"
        Me.btnRotateRight.RightToLeft = CType(resources.GetObject("btnRotateRight.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRotateRight.Size = CType(resources.GetObject("btnRotateRight.Size"), System.Drawing.Size)
        Me.btnRotateRight.TabIndex = CType(resources.GetObject("btnRotateRight.TabIndex"), Integer)
        Me.btnRotateRight.Text = resources.GetString("btnRotateRight.Text")
        Me.btnRotateRight.TextAlign = CType(resources.GetObject("btnRotateRight.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRotateRight.Visible = CType(resources.GetObject("btnRotateRight.Visible"), Boolean)
        '
        'chkThumbnail
        '
        Me.chkThumbnail.AccessibleDescription = resources.GetString("chkThumbnail.AccessibleDescription")
        Me.chkThumbnail.AccessibleName = resources.GetString("chkThumbnail.AccessibleName")
        Me.chkThumbnail.Anchor = CType(resources.GetObject("chkThumbnail.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkThumbnail.Appearance = CType(resources.GetObject("chkThumbnail.Appearance"), System.Windows.Forms.Appearance)
        Me.chkThumbnail.BackgroundImage = CType(resources.GetObject("chkThumbnail.BackgroundImage"), System.Drawing.Image)
        Me.chkThumbnail.CheckAlign = CType(resources.GetObject("chkThumbnail.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkThumbnail.Dock = CType(resources.GetObject("chkThumbnail.Dock"), System.Windows.Forms.DockStyle)
        Me.chkThumbnail.Enabled = CType(resources.GetObject("chkThumbnail.Enabled"), Boolean)
        Me.chkThumbnail.FlatStyle = CType(resources.GetObject("chkThumbnail.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkThumbnail.Font = CType(resources.GetObject("chkThumbnail.Font"), System.Drawing.Font)
        Me.chkThumbnail.Image = CType(resources.GetObject("chkThumbnail.Image"), System.Drawing.Image)
        Me.chkThumbnail.ImageAlign = CType(resources.GetObject("chkThumbnail.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkThumbnail.ImageIndex = CType(resources.GetObject("chkThumbnail.ImageIndex"), Integer)
        Me.chkThumbnail.ImeMode = CType(resources.GetObject("chkThumbnail.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkThumbnail.Location = CType(resources.GetObject("chkThumbnail.Location"), System.Drawing.Point)
        Me.chkThumbnail.Name = "chkThumbnail"
        Me.chkThumbnail.RightToLeft = CType(resources.GetObject("chkThumbnail.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkThumbnail.Size = CType(resources.GetObject("chkThumbnail.Size"), System.Drawing.Size)
        Me.chkThumbnail.TabIndex = CType(resources.GetObject("chkThumbnail.TabIndex"), Integer)
        Me.chkThumbnail.Text = resources.GetString("chkThumbnail.Text")
        Me.chkThumbnail.TextAlign = CType(resources.GetObject("chkThumbnail.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkThumbnail.Visible = CType(resources.GetObject("chkThumbnail.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkThumbnail, Me.btnRotateRight, Me.grpCropping, Me.btnRotateLeft, Me.btnZoomOut, Me.btnZoomIn, Me.btnFit, Me.btnSave, Me.grpSizeMode, Me.btnBrowse, Me.picImage})
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
        Me.grpSizeMode.ResumeLayout(False)
        Me.grpCropping.ResumeLayout(False)
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

    Const PICTUREBOX_WIDTH As Int32 = 608
    Const PICTUREBOX_HEIGHT As Int32 = 380
    Const THUMBNAIL_MIN_SIZE As Int32 = 64

    Private IsFitForZoomIn As Boolean = False
    Private imgUndo As Image
    Private intVal As Int32

    ' Handles the Browse button click event, allowing the user to find an image, 
    ' display it in a PictureBox control, and save the image to the database.
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ' Use an OpenFileDialog to enable the user to browse for an image to open
        ' in the PictureBox. Provide a pipe-delimited set of file name-type pairs 
        ' to filter what the user can load into the PictureBox. Set the FilterIndex 
        ' to the default file type.
        With odlgImage
            .InitialDirectory = "C:\"
            .Filter = "All Image Formats (*.bmp;*.jpg;*.jpeg;*.gif;*.tif)|" & _
                "*.bmp;*.jpg;*.jpeg;*.gif;*.tif|Bitmaps (*.bmp)|*.bmp|" & _
                "GIFs (*.gif)|*.gif|JPEGs (*.jpg)|*.jpg;*.jpeg|TIFs (*.tif)|*.tif"
            .FilterIndex = 1
        End With

        ' When the user clicks the Open button (DialogResult.OK is the only option;
        ' there is not DialogResult.Open), display the image centered in the 
        ' PictureBox and display the full path of the image.
        If odlgImage.ShowDialog() = DialogResult.OK Then
            With picImage
                ' Keep the original width and height of the PictureBox, regardless
                ' of the image size being loaded.
                .Width = PICTUREBOX_WIDTH
                .Height = PICTUREBOX_HEIGHT
                .Image = Image.FromFile(odlgImage.FileName)
                .SizeMode = PictureBoxSizeMode.Normal
            End With
            optNormal.Checked = True
        End If
    End Sub

    ' Handles the Click event for the Fit button.
    Private Sub btnFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFit.Click
        ' SizeMode controls work well after an image has been fit.
        grpSizeMode.Enabled = True

        ' Reset the PictureBox dimensions. Fitting and zooming work best with
        ' StretchImage SizeMode.
        With picImage
            .Width = PICTUREBOX_WIDTH
            .Height = PICTUREBOX_HEIGHT
            .SizeMode = PictureBoxSizeMode.StretchImage
        End With
        ' Update the UI to reflect the SizeMode change.
        optStretchImage.Checked = True

        Fit()
    End Sub

    ' Handles the Click event of the Crop button.
    Private Sub btnCrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrop.Click
        If IsValidCropValues() Then
            ' Initialize the variable that holds a copy of the bitmap before 
            ' cropping, so the crop can be undone.
            imgUndo = picImage.Image
            btnUndo.Enabled = True

            ' Create a rectangle defined by the user's X,Y coordinates relative
            ' to the upper left corner of the PictureBox, and the desired width
            ' and length.
            Dim recSource As New Rectangle(CInt(txtXCoord.Text), CInt(txtYCoord.Text), CInt(txtWidth.Text), CInt(txtHeight.Text))

            ' Create a new, blank Bitmap on which you will draw the cropped 
            ' image. Note: It is worth mentioning here a pitfall to avoid. You might
            ' be led to think that the process should involve creating a Graphics
            ' object off the PictureBox (not a new Bitmap) and then drawing the
            ' cropped image onto the PictureBox after clearing it, as such:
            '
            '   Dim grPicImage As Graphics = picImage.CreateGraphics
            '   grPicImage.Clear(picImage.BackColor)
            '   grPicImage.DrawImage(picImage.Image, 0, 0, recSource, _
            '        GraphicsUnit.Pixel)
            '
            ' This will appear to work. However, as soon as you use any of the other
            ' controls it will become apparent that the PictureBox image is still 
            ' set to the original image, not the cropped image.

            Dim bmpCropped As New Bitmap(CInt(txtWidth.Text), CInt(txtHeight.Text))
            ' Get a Graphics object from the Bitmap for drawing.
            Dim grBitmap As Graphics = Graphics.FromImage(bmpCropped)
            ' Draw the image on the Bitmap anchored at the upper left corner.
            grBitmap.DrawImage(picImage.Image, 0, 0, recSource, GraphicsUnit.Pixel)
            ' Set the PictureBox image to the new cropped image.
            picImage.Image = bmpCropped
        End If
    End Sub

    ' Handles the Click event of the Rotate Left button.
    Private Sub btnRotateLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotateLeft.Click
        ' Rotating 270 degrees is equivalent to rotating -90 degrees.
        picImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        picImage.Refresh()
    End Sub

    ' Handles the Click event of the Rotate Right button.
    Private Sub btnRotateRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotateRight.Click
        picImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        picImage.Refresh()
    End Sub

    ' Handles the Click event for the Save button, which allows the user to save
    ' the image displayed in the PictureBox to a file.
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        With sdlgImage
            .InitialDirectory = "C:\"
            .FileName = "myimage"
            .Filter = "Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif|" & _
                "JPEG (*.jpg)|*.jpg;*.jpeg|TIF (*.tif)|*.tif"
            .FilterIndex = 3
        End With

        If sdlgImage.ShowDialog() = DialogResult.OK Then
            Dim strMsg As String

            Try
                If chkThumbnail.Checked Then
                    ' Save image as a Thumbnail.
                    With picImage
                        Dim ratio As Double = CalculateAspectRatioAndSetDimensions()
                        Dim intThumbWidth As Int32 = THUMBNAIL_MIN_SIZE
                        Dim intThumbHeight As Int32 = THUMBNAIL_MIN_SIZE

                        Dim imgSource As Image = .Image
                        Dim imgThumbnail As Image

                        If .Image.Width > .Image.Height Then
                            intThumbWidth = CInt(CDbl(intThumbWidth * ratio))
                            imgThumbnail = _
                                imgSource.GetThumbnailImage(intThumbWidth, _
                                intThumbHeight, Nothing, Nothing)
                        Else
                            intThumbHeight = CInt(CDbl(intThumbHeight * ratio))
                            imgThumbnail = _
                                imgSource.GetThumbnailImage(intThumbWidth, _
                                intThumbHeight, Nothing, Nothing)
                        End If

                        imgThumbnail.Save(sdlgImage.FileName, GetImageFormat())
                    End With

                    strMsg = "Image successfully saved as thumbnail to " & _
                        sdlgImage.FileName
                Else
                    ' Save the image to the file name specified in the SaveFileDialog.
                    ' Get the image format based on the FilterIndex as set above.
                    picImage.Image.Save(sdlgImage.FileName, GetImageFormat())
                    strMsg = "Image successfully saved to " & sdlgImage.FileName
                End If

                MessageBox.Show("Image successfully saved to " & _
                    sdlgImage.FileName, Me.Text, _
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch exp As Exception
                MessageBox.Show("The following error occurred while trying to " & _
                    "save the image: " & exp.Message, Me.Text, _
                     MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Handles the Click event of the Show button. Displays the cropping rectangle.
    Private Sub btnShowBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowBox.Click
        If IsValidCropValues() Then
            ' Call Refresh to erase the rectangle, if one already exists.
            picImage.Refresh()

            ' Draw a red rectangle to show where the image will be cropped.
            Dim recCropBox As New Rectangle(CInt(txtXCoord.Text), _
                CInt(txtYCoord.Text), CInt(txtWidth.Text), CInt(txtHeight.Text))
            picImage.CreateGraphics.DrawRectangle(Pens.Red, recCropBox)
        End If
    End Sub

    ' Handles the Click event of the Undo button. (For use with cropping.)
    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        picImage.Image = imgUndo
        picImage.Refresh()
        ' Disable the button until the Crop button is clicked again.
        btnUndo.Enabled = False
    End Sub

    ' Handles the Click event for the Zoom In button.
    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click
        ' When zooming in or out the SizeMode controls are disabled or the zooming
        ' doesn't work as anticipated. This check ensures that the initial Zoom in 
        ' transition is smooth. Without this, if the SizeMode = something other
        ' than AutoSize, the image can appear to get smaller on the first click, 
        ' and then begin zooming in, which is not expected behavior.
        If grpSizeMode.Enabled Then
            picImage.SizeMode = PictureBoxSizeMode.AutoSize
        End If

        ' Set UI and UI flags.
        grpSizeMode.Enabled = False
        btnFit.Enabled = True
        IsFitForZoomIn = True

        ' StretchMode works best for zooming. When Zooming In, the SizeMode should 
        ' be set prior to calling Fit(). The reason for this becomes apparent only
        ' when loading images that are smaller than the PictureBox dimensions.
        picImage.SizeMode = PictureBoxSizeMode.StretchImage

        ' Zoom works best if you first fit the image according to its true aspect 
        ' ratio.
        Fit()

        ' Make the PictureBox dimensions larger by 25% to effect the Zoom.
        picImage.Width = CInt(picImage.Width * 1.25)
        picImage.Height = CInt(picImage.Height * 1.25)
    End Sub

    ' Handles the Click event for the Zoom Out button.
    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        ' Set UI and UI flags.
        grpSizeMode.Enabled = False
        btnFit.Enabled = True

        ' Zoom works best if you first fit the image according to its true aspect 
        ' ratio.
        Fit()
        ' StretchImage SizeMode works best for zooming.
        picImage.SizeMode = PictureBoxSizeMode.StretchImage

        ' Make the PictureBox dimensions smaller by 25% to effect the Zoom.
        picImage.Width = CInt(picImage.Width / 1.25)
        picImage.Height = CInt(picImage.Height / 1.25)
    End Sub

    ' Handles the CheckedChanged event for the group of RadioButton controls, 
    ' which causes the PictureBox.SizeMode property to change in response to
    ' RadioButton selection.
    Private Sub SizeModeRadioButtons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAutoSize.CheckedChanged, optCenterImage.CheckedChanged, optNormal.CheckedChanged, optStretchImage.CheckedChanged
        Dim opt As RadioButton = CType(sender, RadioButton)
        ' Each RadioButton stores the value of the PictureBoxSizeMode enum in its 
        ' Tag property. 
        Dim sm As PictureBoxSizeMode = CType(opt.Tag, PictureBoxSizeMode)

        If opt.Checked Then
            picImage.SizeMode = sm

            ' You must reset the PictureBox to its original size if AutoSize has 
            ' been set. It will not automatically return to the size set in the 
            ' Designer.
            If sm = PictureBoxSizeMode.AutoSize Then
                btnFit.Enabled = False
            Else
                btnFit.Enabled = True
                picImage.Width = PICTUREBOX_WIDTH
                picImage.Height = PICTUREBOX_HEIGHT
            End If
        End If
    End Sub

    ' This method makes the image fit properly in the PictureBox. You might think 
    ' that the AutoSize SizeMode enum would make the image appear in the PictureBox 
    ' according to its true aspect ratio within the fixed bounds of the PictureBox.
    ' However, it merely expands or shrinks the PictureBox.
    Private Sub Fit()
        ' If Fit was called by the Zoom In button, then center the image. This is
        ' only needed when working with images that are smaller than the PictureBox.
        ' Feel free to uncomment the line that sets the SizeMode and then see how
        ' it causes Zoom In for small images to show unexpected behavior.
        If picImage.Image.Width < picImage.Width And _
            picImage.Image.Height < picImage.Height Then
            If Not IsFitForZoomIn Then
                picImage.SizeMode = PictureBoxSizeMode.CenterImage
            End If
        End If

        CalculateAspectRatioAndSetDimensions()
    End Sub

    ' Calculates and returns the image's aspect ratio, and sets 
    ' its proper dimensions. This is used for Fit() and for saving thumbnails
    ' of images.
    Private Function CalculateAspectRatioAndSetDimensions() As Double
        ' Calculate the proper aspect ratio and set the image's dimensions.
        Dim ratio As Double
        If picImage.Image.Width > picImage.Image.Height Then
            ratio = picImage.Image.Width / _
                    picImage.Image.Height
            picImage.Height = CInt(CDbl(picImage.Width) / ratio)
        Else
            ratio = picImage.Image.Height / _
                    picImage.Image.Width
            picImage.Width = CInt(CDbl(picImage.Height) / ratio)
        End If

        Return ratio
    End Function

    ' Sets the proper image format for saving images by referencing the Filter
    ' index of the SaveFileDialog.
    Private Function GetImageFormat() As ImageFormat
        Select Case sdlgImage.FilterIndex
            Case 1
                Return ImageFormat.Bmp
            Case 2
                Return ImageFormat.Jpeg
            Case 3
                Return ImageFormat.Gif
            Case Else
                Return ImageFormat.Tiff
        End Select
    End Function

    ' Validates the data entered by the user in the Cropping TextBox controls.
    Private Function IsValidCropValues() As Boolean
        ' Loop through all the TextBox controls and perform the validation.
        ' This allows the same routine to be used by all four controls.
        Dim objControl As Object
        For Each objControl In grpCropping.Controls
            If objControl.GetType.ToString = "System.Windows.Forms.TextBox" Then

                Dim txt As TextBox = CType(objControl, TextBox)
                Dim ValidationMsg As String = _
                    txt.Tag.ToString & " must be a positive integer"

                With txt
                    If .Name = "txtXCoord" Or .Name = "txtYCoord" Then
                        ValidationMsg &= " or zero."
                    Else
                        ValidationMsg &= "."
                    End If

                    If .Text.Trim = "" Then
                        MessageBox.Show(ValidationMsg, Me.Text, _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
                        .SelectAll()
                        .Focus()
                        Return False
                    End If

                    If Not IsNumeric(.Text.Trim) Then
                        MessageBox.Show(ValidationMsg, Me.Text, _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
                        .SelectAll()
                        .Focus()
                        Return False
                    Else
                        Try
                            intVal = CInt(.Text.Trim)
                            If txt.Name = "txtXCoord" Or txt.Name = "txtYCoord" Then
                                If intVal < 0 Then
                                    MessageBox.Show(ValidationMsg, Me.Text, _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Error)
                                    .SelectAll()
                                    .Focus()
                                    Return False
                                End If
                            ElseIf intVal <= 0 Then
                                MessageBox.Show(ValidationMsg, Me.Text, _
                                    MessageBoxButtons.OK, _
                                    MessageBoxIcon.Error)
                                .SelectAll()
                                .Focus()
                                Return False
                            End If
                        Catch Exp As Exception
                            MessageBox.Show("Value must be a positive " & _
                                "integer.", Me.Text, MessageBoxButtons.OK, _
                                MessageBoxIcon.Error)
                            .SelectAll()
                            .Focus()
                            Return False
                        End Try
                    End If
                End With
            End If
        Next

        Return True
    End Function

End Class