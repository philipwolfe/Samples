'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System

' This allows use of WMI objects, to get this statement to compile a reference must
' be set.
Imports System.Management

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Const CRLF As String = Chr(13) & Chr(10)

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
    Friend WithEvents tpWMIQueries As System.Windows.Forms.TabPage
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents btnOperatingSytem As System.Windows.Forms.Button
    Friend WithEvents btnComputerSystem As System.Windows.Forms.Button
    Friend WithEvents btnProcessor As System.Windows.Forms.Button
    Friend WithEvents btnBios As System.Windows.Forms.Button
    Friend WithEvents btnTimeZone As System.Windows.Forms.Button
    Friend WithEvents tpAsynchEnum As System.Windows.Forms.TabPage
    Friend WithEvents DriveName As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnStartEnum As System.Windows.Forms.Button
    Friend WithEvents DriveLabel As System.Windows.Forms.ColumnHeader
    Friend WithEvents DriveSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents DriveFreeSpace As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDriveList As System.Windows.Forms.ListView
    Friend WithEvents tpWMIClasses As System.Windows.Forms.TabPage
    Friend WithEvents lstWMIClasses As System.Windows.Forms.ListBox
    Friend WithEvents btnClassEnum As System.Windows.Forms.Button
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents lblInstructions2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkIncludeSubclasses As System.Windows.Forms.CheckBox
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.tpWMIQueries = New System.Windows.Forms.TabPage()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.btnTimeZone = New System.Windows.Forms.Button()
        Me.btnBios = New System.Windows.Forms.Button()
        Me.btnProcessor = New System.Windows.Forms.Button()
        Me.btnComputerSystem = New System.Windows.Forms.Button()
        Me.btnOperatingSytem = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.tpAsynchEnum = New System.Windows.Forms.TabPage()
        Me.lblInstructions2 = New System.Windows.Forms.Label()
        Me.btnStartEnum = New System.Windows.Forms.Button()
        Me.lvDriveList = New System.Windows.Forms.ListView()
        Me.DriveName = New System.Windows.Forms.ColumnHeader()
        Me.DriveLabel = New System.Windows.Forms.ColumnHeader()
        Me.DriveSize = New System.Windows.Forms.ColumnHeader()
        Me.DriveFreeSpace = New System.Windows.Forms.ColumnHeader()
        Me.tpWMIClasses = New System.Windows.Forms.TabPage()
        Me.chkIncludeSubclasses = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClassEnum = New System.Windows.Forms.Button()
        Me.lstWMIClasses = New System.Windows.Forms.ListBox()
        Me.MainTabControl.SuspendLayout()
        Me.tpWMIQueries.SuspendLayout()
        Me.tpAsynchEnum.SuspendLayout()
        Me.tpWMIClasses.SuspendLayout()
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
        'MainTabControl
        '
        Me.MainTabControl.AccessibleDescription = resources.GetString("MainTabControl.AccessibleDescription")
        Me.MainTabControl.AccessibleName = resources.GetString("MainTabControl.AccessibleName")
        Me.MainTabControl.Alignment = CType(resources.GetObject("MainTabControl.Alignment"), System.Windows.Forms.TabAlignment)
        Me.MainTabControl.Anchor = CType(resources.GetObject("MainTabControl.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.MainTabControl.Appearance = CType(resources.GetObject("MainTabControl.Appearance"), System.Windows.Forms.TabAppearance)
        Me.MainTabControl.BackgroundImage = CType(resources.GetObject("MainTabControl.BackgroundImage"), System.Drawing.Image)
        Me.MainTabControl.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpWMIQueries, Me.tpAsynchEnum, Me.tpWMIClasses})
        Me.MainTabControl.Dock = CType(resources.GetObject("MainTabControl.Dock"), System.Windows.Forms.DockStyle)
        Me.MainTabControl.Enabled = CType(resources.GetObject("MainTabControl.Enabled"), Boolean)
        Me.MainTabControl.Font = CType(resources.GetObject("MainTabControl.Font"), System.Drawing.Font)
        Me.MainTabControl.ImeMode = CType(resources.GetObject("MainTabControl.ImeMode"), System.Windows.Forms.ImeMode)
        Me.MainTabControl.ItemSize = CType(resources.GetObject("MainTabControl.ItemSize"), System.Drawing.Size)
        Me.MainTabControl.Location = CType(resources.GetObject("MainTabControl.Location"), System.Drawing.Point)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.Padding = CType(resources.GetObject("MainTabControl.Padding"), System.Drawing.Point)
        Me.MainTabControl.RightToLeft = CType(resources.GetObject("MainTabControl.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.ShowToolTips = CType(resources.GetObject("MainTabControl.ShowToolTips"), Boolean)
        Me.MainTabControl.Size = CType(resources.GetObject("MainTabControl.Size"), System.Drawing.Size)
        Me.MainTabControl.TabIndex = CType(resources.GetObject("MainTabControl.TabIndex"), Integer)
        Me.MainTabControl.Text = resources.GetString("MainTabControl.Text")
        Me.MainTabControl.Visible = CType(resources.GetObject("MainTabControl.Visible"), Boolean)
        '
        'tpWMIQueries
        '
        Me.tpWMIQueries.AccessibleDescription = resources.GetString("tpWMIQueries.AccessibleDescription")
        Me.tpWMIQueries.AccessibleName = resources.GetString("tpWMIQueries.AccessibleName")
        Me.tpWMIQueries.Anchor = CType(resources.GetObject("tpWMIQueries.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpWMIQueries.AutoScroll = CType(resources.GetObject("tpWMIQueries.AutoScroll"), Boolean)
        Me.tpWMIQueries.AutoScrollMargin = CType(resources.GetObject("tpWMIQueries.AutoScrollMargin"), System.Drawing.Size)
        Me.tpWMIQueries.AutoScrollMinSize = CType(resources.GetObject("tpWMIQueries.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpWMIQueries.BackgroundImage = CType(resources.GetObject("tpWMIQueries.BackgroundImage"), System.Drawing.Image)
        Me.tpWMIQueries.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInstructions, Me.btnTimeZone, Me.btnBios, Me.btnProcessor, Me.btnComputerSystem, Me.btnOperatingSytem, Me.txtOutput})
        Me.tpWMIQueries.Dock = CType(resources.GetObject("tpWMIQueries.Dock"), System.Windows.Forms.DockStyle)
        Me.tpWMIQueries.Enabled = CType(resources.GetObject("tpWMIQueries.Enabled"), Boolean)
        Me.tpWMIQueries.Font = CType(resources.GetObject("tpWMIQueries.Font"), System.Drawing.Font)
        Me.tpWMIQueries.ImageIndex = CType(resources.GetObject("tpWMIQueries.ImageIndex"), Integer)
        Me.tpWMIQueries.ImeMode = CType(resources.GetObject("tpWMIQueries.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpWMIQueries.Location = CType(resources.GetObject("tpWMIQueries.Location"), System.Drawing.Point)
        Me.tpWMIQueries.Name = "tpWMIQueries"
        Me.tpWMIQueries.RightToLeft = CType(resources.GetObject("tpWMIQueries.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpWMIQueries.Size = CType(resources.GetObject("tpWMIQueries.Size"), System.Drawing.Size)
        Me.tpWMIQueries.TabIndex = CType(resources.GetObject("tpWMIQueries.TabIndex"), Integer)
        Me.tpWMIQueries.Text = resources.GetString("tpWMIQueries.Text")
        Me.tpWMIQueries.ToolTipText = resources.GetString("tpWMIQueries.ToolTipText")
        Me.tpWMIQueries.Visible = CType(resources.GetObject("tpWMIQueries.Visible"), Boolean)
        '
        'lblInstructions
        '
        Me.lblInstructions.AccessibleDescription = CType(resources.GetObject("lblInstructions.AccessibleDescription"), String)
        Me.lblInstructions.AccessibleName = CType(resources.GetObject("lblInstructions.AccessibleName"), String)
        Me.lblInstructions.Anchor = CType(resources.GetObject("lblInstructions.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblInstructions.AutoSize = CType(resources.GetObject("lblInstructions.AutoSize"), Boolean)
        Me.lblInstructions.Dock = CType(resources.GetObject("lblInstructions.Dock"), System.Windows.Forms.DockStyle)
        Me.lblInstructions.Enabled = CType(resources.GetObject("lblInstructions.Enabled"), Boolean)
        Me.lblInstructions.Font = CType(resources.GetObject("lblInstructions.Font"), System.Drawing.Font)
        Me.lblInstructions.ForeColor = System.Drawing.Color.Blue
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
        'btnTimeZone
        '
        Me.btnTimeZone.AccessibleDescription = resources.GetString("btnTimeZone.AccessibleDescription")
        Me.btnTimeZone.AccessibleName = resources.GetString("btnTimeZone.AccessibleName")
        Me.btnTimeZone.Anchor = CType(resources.GetObject("btnTimeZone.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnTimeZone.BackgroundImage = CType(resources.GetObject("btnTimeZone.BackgroundImage"), System.Drawing.Image)
        Me.btnTimeZone.Dock = CType(resources.GetObject("btnTimeZone.Dock"), System.Windows.Forms.DockStyle)
        Me.btnTimeZone.Enabled = CType(resources.GetObject("btnTimeZone.Enabled"), Boolean)
        Me.btnTimeZone.FlatStyle = CType(resources.GetObject("btnTimeZone.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnTimeZone.Font = CType(resources.GetObject("btnTimeZone.Font"), System.Drawing.Font)
        Me.btnTimeZone.Image = CType(resources.GetObject("btnTimeZone.Image"), System.Drawing.Image)
        Me.btnTimeZone.ImageAlign = CType(resources.GetObject("btnTimeZone.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnTimeZone.ImageIndex = CType(resources.GetObject("btnTimeZone.ImageIndex"), Integer)
        Me.btnTimeZone.ImeMode = CType(resources.GetObject("btnTimeZone.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnTimeZone.Location = CType(resources.GetObject("btnTimeZone.Location"), System.Drawing.Point)
        Me.btnTimeZone.Name = "btnTimeZone"
        Me.btnTimeZone.RightToLeft = CType(resources.GetObject("btnTimeZone.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnTimeZone.Size = CType(resources.GetObject("btnTimeZone.Size"), System.Drawing.Size)
        Me.btnTimeZone.TabIndex = CType(resources.GetObject("btnTimeZone.TabIndex"), Integer)
        Me.btnTimeZone.Text = resources.GetString("btnTimeZone.Text")
        Me.btnTimeZone.TextAlign = CType(resources.GetObject("btnTimeZone.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnTimeZone.Visible = CType(resources.GetObject("btnTimeZone.Visible"), Boolean)
        '
        'btnBios
        '
        Me.btnBios.AccessibleDescription = resources.GetString("btnBios.AccessibleDescription")
        Me.btnBios.AccessibleName = resources.GetString("btnBios.AccessibleName")
        Me.btnBios.Anchor = CType(resources.GetObject("btnBios.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBios.BackgroundImage = CType(resources.GetObject("btnBios.BackgroundImage"), System.Drawing.Image)
        Me.btnBios.Dock = CType(resources.GetObject("btnBios.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBios.Enabled = CType(resources.GetObject("btnBios.Enabled"), Boolean)
        Me.btnBios.FlatStyle = CType(resources.GetObject("btnBios.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBios.Font = CType(resources.GetObject("btnBios.Font"), System.Drawing.Font)
        Me.btnBios.Image = CType(resources.GetObject("btnBios.Image"), System.Drawing.Image)
        Me.btnBios.ImageAlign = CType(resources.GetObject("btnBios.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBios.ImageIndex = CType(resources.GetObject("btnBios.ImageIndex"), Integer)
        Me.btnBios.ImeMode = CType(resources.GetObject("btnBios.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBios.Location = CType(resources.GetObject("btnBios.Location"), System.Drawing.Point)
        Me.btnBios.Name = "btnBios"
        Me.btnBios.RightToLeft = CType(resources.GetObject("btnBios.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBios.Size = CType(resources.GetObject("btnBios.Size"), System.Drawing.Size)
        Me.btnBios.TabIndex = CType(resources.GetObject("btnBios.TabIndex"), Integer)
        Me.btnBios.Text = resources.GetString("btnBios.Text")
        Me.btnBios.TextAlign = CType(resources.GetObject("btnBios.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBios.Visible = CType(resources.GetObject("btnBios.Visible"), Boolean)
        '
        'btnProcessor
        '
        Me.btnProcessor.AccessibleDescription = resources.GetString("btnProcessor.AccessibleDescription")
        Me.btnProcessor.AccessibleName = resources.GetString("btnProcessor.AccessibleName")
        Me.btnProcessor.Anchor = CType(resources.GetObject("btnProcessor.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnProcessor.BackgroundImage = CType(resources.GetObject("btnProcessor.BackgroundImage"), System.Drawing.Image)
        Me.btnProcessor.Dock = CType(resources.GetObject("btnProcessor.Dock"), System.Windows.Forms.DockStyle)
        Me.btnProcessor.Enabled = CType(resources.GetObject("btnProcessor.Enabled"), Boolean)
        Me.btnProcessor.FlatStyle = CType(resources.GetObject("btnProcessor.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnProcessor.Font = CType(resources.GetObject("btnProcessor.Font"), System.Drawing.Font)
        Me.btnProcessor.Image = CType(resources.GetObject("btnProcessor.Image"), System.Drawing.Image)
        Me.btnProcessor.ImageAlign = CType(resources.GetObject("btnProcessor.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnProcessor.ImageIndex = CType(resources.GetObject("btnProcessor.ImageIndex"), Integer)
        Me.btnProcessor.ImeMode = CType(resources.GetObject("btnProcessor.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnProcessor.Location = CType(resources.GetObject("btnProcessor.Location"), System.Drawing.Point)
        Me.btnProcessor.Name = "btnProcessor"
        Me.btnProcessor.RightToLeft = CType(resources.GetObject("btnProcessor.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnProcessor.Size = CType(resources.GetObject("btnProcessor.Size"), System.Drawing.Size)
        Me.btnProcessor.TabIndex = CType(resources.GetObject("btnProcessor.TabIndex"), Integer)
        Me.btnProcessor.Text = resources.GetString("btnProcessor.Text")
        Me.btnProcessor.TextAlign = CType(resources.GetObject("btnProcessor.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnProcessor.Visible = CType(resources.GetObject("btnProcessor.Visible"), Boolean)
        '
        'btnComputerSystem
        '
        Me.btnComputerSystem.AccessibleDescription = resources.GetString("btnComputerSystem.AccessibleDescription")
        Me.btnComputerSystem.AccessibleName = resources.GetString("btnComputerSystem.AccessibleName")
        Me.btnComputerSystem.Anchor = CType(resources.GetObject("btnComputerSystem.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnComputerSystem.BackgroundImage = CType(resources.GetObject("btnComputerSystem.BackgroundImage"), System.Drawing.Image)
        Me.btnComputerSystem.Dock = CType(resources.GetObject("btnComputerSystem.Dock"), System.Windows.Forms.DockStyle)
        Me.btnComputerSystem.Enabled = CType(resources.GetObject("btnComputerSystem.Enabled"), Boolean)
        Me.btnComputerSystem.FlatStyle = CType(resources.GetObject("btnComputerSystem.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnComputerSystem.Font = CType(resources.GetObject("btnComputerSystem.Font"), System.Drawing.Font)
        Me.btnComputerSystem.Image = CType(resources.GetObject("btnComputerSystem.Image"), System.Drawing.Image)
        Me.btnComputerSystem.ImageAlign = CType(resources.GetObject("btnComputerSystem.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnComputerSystem.ImageIndex = CType(resources.GetObject("btnComputerSystem.ImageIndex"), Integer)
        Me.btnComputerSystem.ImeMode = CType(resources.GetObject("btnComputerSystem.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnComputerSystem.Location = CType(resources.GetObject("btnComputerSystem.Location"), System.Drawing.Point)
        Me.btnComputerSystem.Name = "btnComputerSystem"
        Me.btnComputerSystem.RightToLeft = CType(resources.GetObject("btnComputerSystem.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnComputerSystem.Size = CType(resources.GetObject("btnComputerSystem.Size"), System.Drawing.Size)
        Me.btnComputerSystem.TabIndex = CType(resources.GetObject("btnComputerSystem.TabIndex"), Integer)
        Me.btnComputerSystem.Text = resources.GetString("btnComputerSystem.Text")
        Me.btnComputerSystem.TextAlign = CType(resources.GetObject("btnComputerSystem.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnComputerSystem.Visible = CType(resources.GetObject("btnComputerSystem.Visible"), Boolean)
        '
        'btnOperatingSytem
        '
        Me.btnOperatingSytem.AccessibleDescription = resources.GetString("btnOperatingSytem.AccessibleDescription")
        Me.btnOperatingSytem.AccessibleName = resources.GetString("btnOperatingSytem.AccessibleName")
        Me.btnOperatingSytem.Anchor = CType(resources.GetObject("btnOperatingSytem.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnOperatingSytem.BackgroundImage = CType(resources.GetObject("btnOperatingSytem.BackgroundImage"), System.Drawing.Image)
        Me.btnOperatingSytem.Dock = CType(resources.GetObject("btnOperatingSytem.Dock"), System.Windows.Forms.DockStyle)
        Me.btnOperatingSytem.Enabled = CType(resources.GetObject("btnOperatingSytem.Enabled"), Boolean)
        Me.btnOperatingSytem.FlatStyle = CType(resources.GetObject("btnOperatingSytem.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnOperatingSytem.Font = CType(resources.GetObject("btnOperatingSytem.Font"), System.Drawing.Font)
        Me.btnOperatingSytem.Image = CType(resources.GetObject("btnOperatingSytem.Image"), System.Drawing.Image)
        Me.btnOperatingSytem.ImageAlign = CType(resources.GetObject("btnOperatingSytem.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnOperatingSytem.ImageIndex = CType(resources.GetObject("btnOperatingSytem.ImageIndex"), Integer)
        Me.btnOperatingSytem.ImeMode = CType(resources.GetObject("btnOperatingSytem.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnOperatingSytem.Location = CType(resources.GetObject("btnOperatingSytem.Location"), System.Drawing.Point)
        Me.btnOperatingSytem.Name = "btnOperatingSytem"
        Me.btnOperatingSytem.RightToLeft = CType(resources.GetObject("btnOperatingSytem.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnOperatingSytem.Size = CType(resources.GetObject("btnOperatingSytem.Size"), System.Drawing.Size)
        Me.btnOperatingSytem.TabIndex = CType(resources.GetObject("btnOperatingSytem.TabIndex"), Integer)
        Me.btnOperatingSytem.Text = resources.GetString("btnOperatingSytem.Text")
        Me.btnOperatingSytem.TextAlign = CType(resources.GetObject("btnOperatingSytem.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnOperatingSytem.Visible = CType(resources.GetObject("btnOperatingSytem.Visible"), Boolean)
        '
        'txtOutput
        '
        Me.txtOutput.AccessibleDescription = resources.GetString("txtOutput.AccessibleDescription")
        Me.txtOutput.AccessibleName = resources.GetString("txtOutput.AccessibleName")
        Me.txtOutput.Anchor = CType(resources.GetObject("txtOutput.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtOutput.AutoSize = CType(resources.GetObject("txtOutput.AutoSize"), Boolean)
        Me.txtOutput.BackgroundImage = CType(resources.GetObject("txtOutput.BackgroundImage"), System.Drawing.Image)
        Me.txtOutput.Dock = CType(resources.GetObject("txtOutput.Dock"), System.Windows.Forms.DockStyle)
        Me.txtOutput.Enabled = CType(resources.GetObject("txtOutput.Enabled"), Boolean)
        Me.txtOutput.Font = CType(resources.GetObject("txtOutput.Font"), System.Drawing.Font)
        Me.txtOutput.ImeMode = CType(resources.GetObject("txtOutput.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtOutput.Location = CType(resources.GetObject("txtOutput.Location"), System.Drawing.Point)
        Me.txtOutput.MaxLength = CType(resources.GetObject("txtOutput.MaxLength"), Integer)
        Me.txtOutput.Multiline = CType(resources.GetObject("txtOutput.Multiline"), Boolean)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.PasswordChar = CType(resources.GetObject("txtOutput.PasswordChar"), Char)
        Me.txtOutput.RightToLeft = CType(resources.GetObject("txtOutput.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtOutput.ScrollBars = CType(resources.GetObject("txtOutput.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtOutput.Size = CType(resources.GetObject("txtOutput.Size"), System.Drawing.Size)
        Me.txtOutput.TabIndex = CType(resources.GetObject("txtOutput.TabIndex"), Integer)
        Me.txtOutput.Text = resources.GetString("txtOutput.Text")
        Me.txtOutput.TextAlign = CType(resources.GetObject("txtOutput.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtOutput.Visible = CType(resources.GetObject("txtOutput.Visible"), Boolean)
        Me.txtOutput.WordWrap = CType(resources.GetObject("txtOutput.WordWrap"), Boolean)
        '
        'tpAsynchEnum
        '
        Me.tpAsynchEnum.AccessibleDescription = resources.GetString("tpAsynchEnum.AccessibleDescription")
        Me.tpAsynchEnum.AccessibleName = resources.GetString("tpAsynchEnum.AccessibleName")
        Me.tpAsynchEnum.Anchor = CType(resources.GetObject("tpAsynchEnum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpAsynchEnum.AutoScroll = CType(resources.GetObject("tpAsynchEnum.AutoScroll"), Boolean)
        Me.tpAsynchEnum.AutoScrollMargin = CType(resources.GetObject("tpAsynchEnum.AutoScrollMargin"), System.Drawing.Size)
        Me.tpAsynchEnum.AutoScrollMinSize = CType(resources.GetObject("tpAsynchEnum.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpAsynchEnum.BackgroundImage = CType(resources.GetObject("tpAsynchEnum.BackgroundImage"), System.Drawing.Image)
        Me.tpAsynchEnum.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInstructions2, Me.btnStartEnum, Me.lvDriveList})
        Me.tpAsynchEnum.Dock = CType(resources.GetObject("tpAsynchEnum.Dock"), System.Windows.Forms.DockStyle)
        Me.tpAsynchEnum.Enabled = CType(resources.GetObject("tpAsynchEnum.Enabled"), Boolean)
        Me.tpAsynchEnum.Font = CType(resources.GetObject("tpAsynchEnum.Font"), System.Drawing.Font)
        Me.tpAsynchEnum.ImageIndex = CType(resources.GetObject("tpAsynchEnum.ImageIndex"), Integer)
        Me.tpAsynchEnum.ImeMode = CType(resources.GetObject("tpAsynchEnum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpAsynchEnum.Location = CType(resources.GetObject("tpAsynchEnum.Location"), System.Drawing.Point)
        Me.tpAsynchEnum.Name = "tpAsynchEnum"
        Me.tpAsynchEnum.RightToLeft = CType(resources.GetObject("tpAsynchEnum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpAsynchEnum.Size = CType(resources.GetObject("tpAsynchEnum.Size"), System.Drawing.Size)
        Me.tpAsynchEnum.TabIndex = CType(resources.GetObject("tpAsynchEnum.TabIndex"), Integer)
        Me.tpAsynchEnum.Text = resources.GetString("tpAsynchEnum.Text")
        Me.tpAsynchEnum.ToolTipText = resources.GetString("tpAsynchEnum.ToolTipText")
        Me.tpAsynchEnum.Visible = CType(resources.GetObject("tpAsynchEnum.Visible"), Boolean)
        '
        'lblInstructions2
        '
        Me.lblInstructions2.AccessibleDescription = CType(resources.GetObject("lblInstructions2.AccessibleDescription"), String)
        Me.lblInstructions2.AccessibleName = CType(resources.GetObject("lblInstructions2.AccessibleName"), String)
        Me.lblInstructions2.Anchor = CType(resources.GetObject("lblInstructions2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblInstructions2.AutoSize = CType(resources.GetObject("lblInstructions2.AutoSize"), Boolean)
        Me.lblInstructions2.Dock = CType(resources.GetObject("lblInstructions2.Dock"), System.Windows.Forms.DockStyle)
        Me.lblInstructions2.Enabled = CType(resources.GetObject("lblInstructions2.Enabled"), Boolean)
        Me.lblInstructions2.Font = CType(resources.GetObject("lblInstructions2.Font"), System.Drawing.Font)
        Me.lblInstructions2.ForeColor = System.Drawing.Color.Blue
        Me.lblInstructions2.Image = CType(resources.GetObject("lblInstructions2.Image"), System.Drawing.Image)
        Me.lblInstructions2.ImageAlign = CType(resources.GetObject("lblInstructions2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblInstructions2.ImageIndex = CType(resources.GetObject("lblInstructions2.ImageIndex"), Integer)
        Me.lblInstructions2.ImeMode = CType(resources.GetObject("lblInstructions2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblInstructions2.Location = CType(resources.GetObject("lblInstructions2.Location"), System.Drawing.Point)
        Me.lblInstructions2.Name = "lblInstructions2"
        Me.lblInstructions2.RightToLeft = CType(resources.GetObject("lblInstructions2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblInstructions2.Size = CType(resources.GetObject("lblInstructions2.Size"), System.Drawing.Size)
        Me.lblInstructions2.TabIndex = CType(resources.GetObject("lblInstructions2.TabIndex"), Integer)
        Me.lblInstructions2.Text = resources.GetString("lblInstructions2.Text")
        Me.lblInstructions2.TextAlign = CType(resources.GetObject("lblInstructions2.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblInstructions2.Visible = CType(resources.GetObject("lblInstructions2.Visible"), Boolean)
        '
        'btnStartEnum
        '
        Me.btnStartEnum.AccessibleDescription = resources.GetString("btnStartEnum.AccessibleDescription")
        Me.btnStartEnum.AccessibleName = resources.GetString("btnStartEnum.AccessibleName")
        Me.btnStartEnum.Anchor = CType(resources.GetObject("btnStartEnum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStartEnum.BackgroundImage = CType(resources.GetObject("btnStartEnum.BackgroundImage"), System.Drawing.Image)
        Me.btnStartEnum.Dock = CType(resources.GetObject("btnStartEnum.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStartEnum.Enabled = CType(resources.GetObject("btnStartEnum.Enabled"), Boolean)
        Me.btnStartEnum.FlatStyle = CType(resources.GetObject("btnStartEnum.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStartEnum.Font = CType(resources.GetObject("btnStartEnum.Font"), System.Drawing.Font)
        Me.btnStartEnum.Image = CType(resources.GetObject("btnStartEnum.Image"), System.Drawing.Image)
        Me.btnStartEnum.ImageAlign = CType(resources.GetObject("btnStartEnum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStartEnum.ImageIndex = CType(resources.GetObject("btnStartEnum.ImageIndex"), Integer)
        Me.btnStartEnum.ImeMode = CType(resources.GetObject("btnStartEnum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStartEnum.Location = CType(resources.GetObject("btnStartEnum.Location"), System.Drawing.Point)
        Me.btnStartEnum.Name = "btnStartEnum"
        Me.btnStartEnum.RightToLeft = CType(resources.GetObject("btnStartEnum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStartEnum.Size = CType(resources.GetObject("btnStartEnum.Size"), System.Drawing.Size)
        Me.btnStartEnum.TabIndex = CType(resources.GetObject("btnStartEnum.TabIndex"), Integer)
        Me.btnStartEnum.Text = resources.GetString("btnStartEnum.Text")
        Me.btnStartEnum.TextAlign = CType(resources.GetObject("btnStartEnum.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStartEnum.Visible = CType(resources.GetObject("btnStartEnum.Visible"), Boolean)
        '
        'lvDriveList
        '
        Me.lvDriveList.AccessibleDescription = resources.GetString("lvDriveList.AccessibleDescription")
        Me.lvDriveList.AccessibleName = resources.GetString("lvDriveList.AccessibleName")
        Me.lvDriveList.Alignment = CType(resources.GetObject("lvDriveList.Alignment"), System.Windows.Forms.ListViewAlignment)
        Me.lvDriveList.Anchor = CType(resources.GetObject("lvDriveList.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lvDriveList.BackgroundImage = CType(resources.GetObject("lvDriveList.BackgroundImage"), System.Drawing.Image)
        Me.lvDriveList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DriveName, Me.DriveLabel, Me.DriveSize, Me.DriveFreeSpace})
        Me.lvDriveList.Dock = CType(resources.GetObject("lvDriveList.Dock"), System.Windows.Forms.DockStyle)
        Me.lvDriveList.Enabled = CType(resources.GetObject("lvDriveList.Enabled"), Boolean)
        Me.lvDriveList.Font = CType(resources.GetObject("lvDriveList.Font"), System.Drawing.Font)
        Me.lvDriveList.ImeMode = CType(resources.GetObject("lvDriveList.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lvDriveList.LabelWrap = CType(resources.GetObject("lvDriveList.LabelWrap"), Boolean)
        Me.lvDriveList.Location = CType(resources.GetObject("lvDriveList.Location"), System.Drawing.Point)
        Me.lvDriveList.Name = "lvDriveList"
        Me.lvDriveList.RightToLeft = CType(resources.GetObject("lvDriveList.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lvDriveList.Size = CType(resources.GetObject("lvDriveList.Size"), System.Drawing.Size)
        Me.lvDriveList.TabIndex = CType(resources.GetObject("lvDriveList.TabIndex"), Integer)
        Me.lvDriveList.Text = resources.GetString("lvDriveList.Text")
        Me.lvDriveList.View = System.Windows.Forms.View.Details
        Me.lvDriveList.Visible = CType(resources.GetObject("lvDriveList.Visible"), Boolean)
        '
        'DriveName
        '
        Me.DriveName.Text = resources.GetString("DriveName.Text")
        Me.DriveName.TextAlign = CType(resources.GetObject("DriveName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.DriveName.Width = CType(resources.GetObject("DriveName.Width"), Integer)
        '
        'DriveLabel
        '
        Me.DriveLabel.Text = resources.GetString("DriveLabel.Text")
        Me.DriveLabel.TextAlign = CType(resources.GetObject("DriveLabel.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.DriveLabel.Width = CType(resources.GetObject("DriveLabel.Width"), Integer)
        '
        'DriveSize
        '
        Me.DriveSize.Text = resources.GetString("DriveSize.Text")
        Me.DriveSize.TextAlign = CType(resources.GetObject("DriveSize.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.DriveSize.Width = CType(resources.GetObject("DriveSize.Width"), Integer)
        '
        'DriveFreeSpace
        '
        Me.DriveFreeSpace.Text = resources.GetString("DriveFreeSpace.Text")
        Me.DriveFreeSpace.TextAlign = CType(resources.GetObject("DriveFreeSpace.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.DriveFreeSpace.Width = CType(resources.GetObject("DriveFreeSpace.Width"), Integer)
        '
        'tpWMIClasses
        '
        Me.tpWMIClasses.AccessibleDescription = CType(resources.GetObject("tpWMIClasses.AccessibleDescription"), String)
        Me.tpWMIClasses.AccessibleName = CType(resources.GetObject("tpWMIClasses.AccessibleName"), String)
        Me.tpWMIClasses.Anchor = CType(resources.GetObject("tpWMIClasses.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpWMIClasses.AutoScroll = CType(resources.GetObject("tpWMIClasses.AutoScroll"), Boolean)
        Me.tpWMIClasses.AutoScrollMargin = CType(resources.GetObject("tpWMIClasses.AutoScrollMargin"), System.Drawing.Size)
        Me.tpWMIClasses.AutoScrollMinSize = CType(resources.GetObject("tpWMIClasses.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpWMIClasses.BackgroundImage = CType(resources.GetObject("tpWMIClasses.BackgroundImage"), System.Drawing.Image)
        Me.tpWMIClasses.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkIncludeSubclasses, Me.Label1, Me.btnClassEnum, Me.lstWMIClasses})
        Me.tpWMIClasses.Dock = CType(resources.GetObject("tpWMIClasses.Dock"), System.Windows.Forms.DockStyle)
        Me.tpWMIClasses.Enabled = CType(resources.GetObject("tpWMIClasses.Enabled"), Boolean)
        Me.tpWMIClasses.Font = CType(resources.GetObject("tpWMIClasses.Font"), System.Drawing.Font)
        Me.tpWMIClasses.ImageIndex = CType(resources.GetObject("tpWMIClasses.ImageIndex"), Integer)
        Me.tpWMIClasses.ImeMode = CType(resources.GetObject("tpWMIClasses.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpWMIClasses.Location = CType(resources.GetObject("tpWMIClasses.Location"), System.Drawing.Point)
        Me.tpWMIClasses.Name = "tpWMIClasses"
        Me.tpWMIClasses.RightToLeft = CType(resources.GetObject("tpWMIClasses.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpWMIClasses.Size = CType(resources.GetObject("tpWMIClasses.Size"), System.Drawing.Size)
        Me.tpWMIClasses.TabIndex = CType(resources.GetObject("tpWMIClasses.TabIndex"), Integer)
        Me.tpWMIClasses.Text = resources.GetString("tpWMIClasses.Text")
        Me.tpWMIClasses.ToolTipText = resources.GetString("tpWMIClasses.ToolTipText")
        Me.tpWMIClasses.Visible = CType(resources.GetObject("tpWMIClasses.Visible"), Boolean)
        '
        'chkIncludeSubclasses
        '
        Me.chkIncludeSubclasses.AccessibleDescription = resources.GetString("chkIncludeSubclasses.AccessibleDescription")
        Me.chkIncludeSubclasses.AccessibleName = resources.GetString("chkIncludeSubclasses.AccessibleName")
        Me.chkIncludeSubclasses.Anchor = CType(resources.GetObject("chkIncludeSubclasses.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkIncludeSubclasses.Appearance = CType(resources.GetObject("chkIncludeSubclasses.Appearance"), System.Windows.Forms.Appearance)
        Me.chkIncludeSubclasses.BackgroundImage = CType(resources.GetObject("chkIncludeSubclasses.BackgroundImage"), System.Drawing.Image)
        Me.chkIncludeSubclasses.CheckAlign = CType(resources.GetObject("chkIncludeSubclasses.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkIncludeSubclasses.Dock = CType(resources.GetObject("chkIncludeSubclasses.Dock"), System.Windows.Forms.DockStyle)
        Me.chkIncludeSubclasses.Enabled = CType(resources.GetObject("chkIncludeSubclasses.Enabled"), Boolean)
        Me.chkIncludeSubclasses.FlatStyle = CType(resources.GetObject("chkIncludeSubclasses.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkIncludeSubclasses.Font = CType(resources.GetObject("chkIncludeSubclasses.Font"), System.Drawing.Font)
        Me.chkIncludeSubclasses.Image = CType(resources.GetObject("chkIncludeSubclasses.Image"), System.Drawing.Image)
        Me.chkIncludeSubclasses.ImageAlign = CType(resources.GetObject("chkIncludeSubclasses.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkIncludeSubclasses.ImageIndex = CType(resources.GetObject("chkIncludeSubclasses.ImageIndex"), Integer)
        Me.chkIncludeSubclasses.ImeMode = CType(resources.GetObject("chkIncludeSubclasses.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkIncludeSubclasses.Location = CType(resources.GetObject("chkIncludeSubclasses.Location"), System.Drawing.Point)
        Me.chkIncludeSubclasses.Name = "chkIncludeSubclasses"
        Me.chkIncludeSubclasses.RightToLeft = CType(resources.GetObject("chkIncludeSubclasses.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkIncludeSubclasses.Size = CType(resources.GetObject("chkIncludeSubclasses.Size"), System.Drawing.Size)
        Me.chkIncludeSubclasses.TabIndex = CType(resources.GetObject("chkIncludeSubclasses.TabIndex"), Integer)
        Me.chkIncludeSubclasses.Text = resources.GetString("chkIncludeSubclasses.Text")
        Me.chkIncludeSubclasses.TextAlign = CType(resources.GetObject("chkIncludeSubclasses.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkIncludeSubclasses.Visible = CType(resources.GetObject("chkIncludeSubclasses.Visible"), Boolean)
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
        Me.Label1.ForeColor = System.Drawing.Color.Blue
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
        'btnClassEnum
        '
        Me.btnClassEnum.AccessibleDescription = resources.GetString("btnClassEnum.AccessibleDescription")
        Me.btnClassEnum.AccessibleName = resources.GetString("btnClassEnum.AccessibleName")
        Me.btnClassEnum.Anchor = CType(resources.GetObject("btnClassEnum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnClassEnum.BackgroundImage = CType(resources.GetObject("btnClassEnum.BackgroundImage"), System.Drawing.Image)
        Me.btnClassEnum.Dock = CType(resources.GetObject("btnClassEnum.Dock"), System.Windows.Forms.DockStyle)
        Me.btnClassEnum.Enabled = CType(resources.GetObject("btnClassEnum.Enabled"), Boolean)
        Me.btnClassEnum.FlatStyle = CType(resources.GetObject("btnClassEnum.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnClassEnum.Font = CType(resources.GetObject("btnClassEnum.Font"), System.Drawing.Font)
        Me.btnClassEnum.Image = CType(resources.GetObject("btnClassEnum.Image"), System.Drawing.Image)
        Me.btnClassEnum.ImageAlign = CType(resources.GetObject("btnClassEnum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnClassEnum.ImageIndex = CType(resources.GetObject("btnClassEnum.ImageIndex"), Integer)
        Me.btnClassEnum.ImeMode = CType(resources.GetObject("btnClassEnum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnClassEnum.Location = CType(resources.GetObject("btnClassEnum.Location"), System.Drawing.Point)
        Me.btnClassEnum.Name = "btnClassEnum"
        Me.btnClassEnum.RightToLeft = CType(resources.GetObject("btnClassEnum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnClassEnum.Size = CType(resources.GetObject("btnClassEnum.Size"), System.Drawing.Size)
        Me.btnClassEnum.TabIndex = CType(resources.GetObject("btnClassEnum.TabIndex"), Integer)
        Me.btnClassEnum.Text = resources.GetString("btnClassEnum.Text")
        Me.btnClassEnum.TextAlign = CType(resources.GetObject("btnClassEnum.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnClassEnum.Visible = CType(resources.GetObject("btnClassEnum.Visible"), Boolean)
        '
        'lstWMIClasses
        '
        Me.lstWMIClasses.AccessibleDescription = CType(resources.GetObject("lstWMIClasses.AccessibleDescription"), String)
        Me.lstWMIClasses.AccessibleName = CType(resources.GetObject("lstWMIClasses.AccessibleName"), String)
        Me.lstWMIClasses.Anchor = CType(resources.GetObject("lstWMIClasses.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lstWMIClasses.BackgroundImage = CType(resources.GetObject("lstWMIClasses.BackgroundImage"), System.Drawing.Image)
        Me.lstWMIClasses.ColumnWidth = CType(resources.GetObject("lstWMIClasses.ColumnWidth"), Integer)
        Me.lstWMIClasses.Dock = CType(resources.GetObject("lstWMIClasses.Dock"), System.Windows.Forms.DockStyle)
        Me.lstWMIClasses.Enabled = CType(resources.GetObject("lstWMIClasses.Enabled"), Boolean)
        Me.lstWMIClasses.Font = CType(resources.GetObject("lstWMIClasses.Font"), System.Drawing.Font)
        Me.lstWMIClasses.HorizontalExtent = CType(resources.GetObject("lstWMIClasses.HorizontalExtent"), Integer)
        Me.lstWMIClasses.HorizontalScrollbar = CType(resources.GetObject("lstWMIClasses.HorizontalScrollbar"), Boolean)
        Me.lstWMIClasses.ImeMode = CType(resources.GetObject("lstWMIClasses.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lstWMIClasses.IntegralHeight = CType(resources.GetObject("lstWMIClasses.IntegralHeight"), Boolean)
        Me.lstWMIClasses.ItemHeight = CType(resources.GetObject("lstWMIClasses.ItemHeight"), Integer)
        Me.lstWMIClasses.Location = CType(resources.GetObject("lstWMIClasses.Location"), System.Drawing.Point)
        Me.lstWMIClasses.Name = "lstWMIClasses"
        Me.lstWMIClasses.RightToLeft = CType(resources.GetObject("lstWMIClasses.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lstWMIClasses.ScrollAlwaysVisible = CType(resources.GetObject("lstWMIClasses.ScrollAlwaysVisible"), Boolean)
        Me.lstWMIClasses.Size = CType(resources.GetObject("lstWMIClasses.Size"), System.Drawing.Size)
        Me.lstWMIClasses.TabIndex = CType(resources.GetObject("lstWMIClasses.TabIndex"), Integer)
        Me.lstWMIClasses.Visible = CType(resources.GetObject("lstWMIClasses.Visible"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.MainTabControl})
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
        Me.MainTabControl.ResumeLayout(False)
        Me.tpWMIQueries.ResumeLayout(False)
        Me.tpAsynchEnum.ResumeLayout(False)
        Me.tpWMIClasses.ResumeLayout(False)
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

    ' This subroutine fills in the output text box with bios information from WMI
    Private Sub btnBios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBios.Click
        ' This is to show how to use the SelectQuery object in the place of a SELECT 
        ' statement.
        Dim query As New SelectQuery("Win32_bios")

        'ManagementObjectSearcher retrieves a collection of WMI objects based on 
        ' the query.
        Dim search As New ManagementObjectSearcher(query)

        ' Display each entry for Win32_bios
        Dim info As ManagementObject
        For Each info In search.Get()
            txtOutput.Text = "Bios version: " & info("version").ToString() & CRLF
        Next
    End Sub

    ' This subroutine fills in the output text box with computer system information
    ' from WMI
    Private Sub btnComputerSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComputerSystem.Click
        ' ManagementObjectSearcher retrieves a collection of WMI objects based on 
        ' the query.  In this case a string is used instead of a SelectQuery object.
        Dim search As New ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem")

        ' Display each entry for Win32_ComputerSystem
        Dim info As ManagementObject
        For Each info In search.Get()
            txtOutput.Text = "Manufacturer: " & info("manufacturer").ToString() & CRLF
            txtOutput.Text += "Model: " & info("model").ToString() & CRLF
            txtOutput.Text += "System Type: " & info("systemtype").ToString() & CRLF
            txtOutput.Text += "Total Physical Memory: " & _
                info("totalphysicalmemory").ToString() & CRLF
        Next
    End Sub

    ' This subroutine fills a list box with all WMI classes. 
    Private Sub btnClassEnum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClassEnum.Click
        ' Clear out the list box
        lstWMIClasses.Items.Clear()

        ' Default constructor for ManagementClass will return cim root.  
        Dim root As New ManagementClass()

        ' If Subclasses checkbox check we will get all subclasses as well as the top
        ' level classes.
        Dim options As New EnumerationOptions()
        options.EnumerateDeep = chkIncludeSubclasses.Checked

        ' Add each WMI class in the enumeration to the list box.
        Dim info As ManagementObject
        For Each info In root.GetSubclasses(options)
            lstWMIClasses.Items.Add(info("__Class"))
        Next
    End Sub

    ' This subroutine fills in the output text box with Operating System information
    ' from WMI
    Private Sub btnOperatingSytem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOperatingSytem.Click
        ' ManagementObjectSearcher retrieves a collection of WMI objects based on 
        ' the query.  In this case a string is used instead of a SelectQuery object.
        Dim search As New ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")

        ' Display each entry for Win32_OperatingSystem
        Dim info As ManagementObject
        For Each info In search.Get()
            txtOutput.Text = "Name: " & info("name").ToString() & CRLF
            txtOutput.Text += "Version: " & info("version").ToString() & CRLF
            txtOutput.Text += "Manufacturer: " & info("manufacturer").ToString() & CRLF
            txtOutput.Text += "Computer name: " & info("csname").ToString() & CRLF
            txtOutput.Text += "Windows Directory: " & _
                info("windowsdirectory").ToString() & CRLF
        Next
    End Sub

    ' This subroutine fills in the output text box with Processor information
    ' from WMI
    Private Sub btnProcessor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessor.Click
        ' This is to show how to use the SelectQuery object in the place of a SELECT 
        ' statement.
        Dim query As New SelectQuery("Win32_processor")

        'ManagementObjectSearcher retrieves a collection of WMI objects based on 
        ' the query.
        Dim search As New ManagementObjectSearcher(query)

        ' Display each entry for Win32_processor
        Dim info As ManagementObject
        For Each info In search.Get()
            txtOutput.Text = "Processor: " & info("caption").ToString() & CRLF
        Next
    End Sub

    ' This subroutine starts an asynchronous operation to fill the DriveList list view
    ' with all logical drives.
    Private Sub btnStartEnum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartEnum.Click
        ' Clear out the list view
        lvDriveList.Items.Clear()

        ' Get the WMI object for Win32_Logical_Disk
        Dim disks As New ManagementClass("Win32_LogicalDisk")

        ' ManagementOperationObserver handles the the collection asynchronously
        ' by use of a callback.
        Dim observer As New ManagementOperationObserver()

        ' Add an event handler for the observer to call for each logical drive.
        AddHandler observer.ObjectReady, AddressOf OnEnumObjectReady

        ' Returns the collection of all Logical drives, asynchronously.
        disks.GetInstances(observer)
    End Sub

    ' This subroutine fills in the output text box with Time zone information from WMI
    Private Sub btnTimeZone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeZone.Click
        ' This is to show how to use the SelectQuery object in the place of a SELECT 
        ' statement.
        Dim query As New SelectQuery("Win32_timezone")

        'ManagementObjectSearcher retrieves a collection of WMI objects based on 
        ' the query.
        Dim search As New ManagementObjectSearcher(query)

        ' Display each entry for Win32_timezone
        Dim info As ManagementObject
        For Each info In search.Get()
            txtOutput.Text = "Time zone: " & info("caption").ToString() & CRLF
        Next
    End Sub

    ' This is the callback subroutine that the WMI class ManagementOperationObserver
    ' calls in btnStartEnum_Click.
    Sub OnEnumObjectReady(ByVal sender As Object, ByVal e As ObjectReadyEventArgs)
        ' Create a new item to add to DriveList ListView, add drive letter
        Dim item As New ListViewItem(e.NewObject("Name").ToString(), 0)

        ' If VolumeName is null (A: without disk, Cd-ROM empty, etc.) then only
        ' list the drive letter
        If Not IsNothing(e.NewObject("VolumeName")) Then
            item.SubItems.Add(e.NewObject("VolumeName").ToString())
            item.SubItems.Add(e.NewObject("Size").ToString() & " bytes")

            ' If 0 bytes display (none)
            If e.NewObject("FreeSpace").ToString() <> "0" Then
                item.SubItems.Add(e.NewObject("FreeSpace").ToString() & " bytes")
            Else
                item.SubItems.Add("(none)")
            End If
        End If

        ' Add the item
        lvDriveList.Items.Add(item)
    End Sub
End Class
