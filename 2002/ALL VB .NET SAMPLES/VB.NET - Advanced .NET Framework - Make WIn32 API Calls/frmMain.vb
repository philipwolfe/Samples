'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System
Imports System.Text
Imports System.Runtime.InteropServices

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Const STRING_BUFFER_LENGTH As Integer = 255

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
    Friend WithEvents lvwProcessList As System.Windows.Forms.ListView
    Friend WithEvents WindowsTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClassName As System.Windows.Forms.ColumnHeader
    Friend WithEvents WindowsHandle As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents tpActiveProcesses As System.Windows.Forms.TabPage
    Friend WithEvents tpActiveWindows As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshActiveWindows As System.Windows.Forms.Button
    Friend WithEvents lbActiveWindows As System.Windows.Forms.ListBox
    Friend WithEvents tpShowWindow As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents txtWindowCaption As System.Windows.Forms.TextBox
    Friend WithEvents txtClassName As System.Windows.Forms.TextBox
    Friend WithEvents lblFunctionCalled As System.Windows.Forms.Label
    Friend WithEvents btnRefreshActiveProcesses As System.Windows.Forms.Button
    Friend WithEvents tpAPICalls As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnGetFreeSpace As System.Windows.Forms.Button
    Friend WithEvents txtDriveLetter As System.Windows.Forms.TextBox
    Friend WithEvents txtFunctionOutput As System.Windows.Forms.TextBox
    Friend WithEvents btnGetDiskFreeSpaceEx As System.Windows.Forms.Button
    Friend WithEvents btnGetDriveType As System.Windows.Forms.Button
    Friend WithEvents DriveGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents btnCreateDirectory As System.Windows.Forms.Button
    Friend WithEvents txtDirectory As System.Windows.Forms.TextBox
    Friend WithEvents DirectoryGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents MiscGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetOSVersion As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnHibernate As System.Windows.Forms.Button
    Friend WithEvents btnBeep As System.Windows.Forms.Button
    Friend WithEvents rbAuto As System.Windows.Forms.RadioButton
    Friend WithEvents rbANSI As System.Windows.Forms.RadioButton
    Friend WithEvents rbUnicode As System.Windows.Forms.RadioButton
    Friend WithEvents rbDLLImport As System.Windows.Forms.RadioButton
    Friend WithEvents rbDeclare As System.Windows.Forms.RadioButton
    Friend WithEvents MouseGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetMouseButton As System.Windows.Forms.Button
    Friend WithEvents btnSwapMouseButton As System.Windows.Forms.Button
    Friend WithEvents CallingVariationGroupBox As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.tpActiveProcesses = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRefreshActiveProcesses = New System.Windows.Forms.Button()
        Me.lvwProcessList = New System.Windows.Forms.ListView()
        Me.WindowsTitle = New System.Windows.Forms.ColumnHeader()
        Me.ClassName = New System.Windows.Forms.ColumnHeader()
        Me.WindowsHandle = New System.Windows.Forms.ColumnHeader()
        Me.tpActiveWindows = New System.Windows.Forms.TabPage()
        Me.btnRefreshActiveWindows = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbActiveWindows = New System.Windows.Forms.ListBox()
        Me.tpShowWindow = New System.Windows.Forms.TabPage()
        Me.lblFunctionCalled = New System.Windows.Forms.Label()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtClassName = New System.Windows.Forms.TextBox()
        Me.txtWindowCaption = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tpAPICalls = New System.Windows.Forms.TabPage()
        Me.CallingVariationGroupBox = New System.Windows.Forms.GroupBox()
        Me.btnBeep = New System.Windows.Forms.Button()
        Me.rbAuto = New System.Windows.Forms.RadioButton()
        Me.rbANSI = New System.Windows.Forms.RadioButton()
        Me.rbUnicode = New System.Windows.Forms.RadioButton()
        Me.rbDLLImport = New System.Windows.Forms.RadioButton()
        Me.rbDeclare = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DirectoryGroupBox = New System.Windows.Forms.GroupBox()
        Me.txtDirectory = New System.Windows.Forms.TextBox()
        Me.btnCreateDirectory = New System.Windows.Forms.Button()
        Me.MouseGroupBox = New System.Windows.Forms.GroupBox()
        Me.btnResetMouseButton = New System.Windows.Forms.Button()
        Me.btnSwapMouseButton = New System.Windows.Forms.Button()
        Me.DriveGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDriveLetter = New System.Windows.Forms.TextBox()
        Me.btnGetDriveType = New System.Windows.Forms.Button()
        Me.btnGetDiskFreeSpaceEx = New System.Windows.Forms.Button()
        Me.btnGetFreeSpace = New System.Windows.Forms.Button()
        Me.txtFunctionOutput = New System.Windows.Forms.TextBox()
        Me.MiscGroupBox = New System.Windows.Forms.GroupBox()
        Me.btnHibernate = New System.Windows.Forms.Button()
        Me.btnGetOSVersion = New System.Windows.Forms.Button()
        Me.MainTabControl.SuspendLayout()
        Me.tpActiveProcesses.SuspendLayout()
        Me.tpActiveWindows.SuspendLayout()
        Me.tpShowWindow.SuspendLayout()
        Me.tpAPICalls.SuspendLayout()
        Me.CallingVariationGroupBox.SuspendLayout()
        Me.DirectoryGroupBox.SuspendLayout()
        Me.MouseGroupBox.SuspendLayout()
        Me.DriveGroupBox.SuspendLayout()
        Me.MiscGroupBox.SuspendLayout()
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
        Me.MainTabControl.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpActiveProcesses, Me.tpActiveWindows, Me.tpShowWindow, Me.tpAPICalls})
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
        'tpActiveProcesses
        '
        Me.tpActiveProcesses.AccessibleDescription = resources.GetString("tpActiveProcesses.AccessibleDescription")
        Me.tpActiveProcesses.AccessibleName = resources.GetString("tpActiveProcesses.AccessibleName")
        Me.tpActiveProcesses.Anchor = CType(resources.GetObject("tpActiveProcesses.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpActiveProcesses.AutoScroll = CType(resources.GetObject("tpActiveProcesses.AutoScroll"), Boolean)
        Me.tpActiveProcesses.AutoScrollMargin = CType(resources.GetObject("tpActiveProcesses.AutoScrollMargin"), System.Drawing.Size)
        Me.tpActiveProcesses.AutoScrollMinSize = CType(resources.GetObject("tpActiveProcesses.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpActiveProcesses.BackgroundImage = CType(resources.GetObject("tpActiveProcesses.BackgroundImage"), System.Drawing.Image)
        Me.tpActiveProcesses.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.btnRefreshActiveProcesses, Me.lvwProcessList})
        Me.tpActiveProcesses.Dock = CType(resources.GetObject("tpActiveProcesses.Dock"), System.Windows.Forms.DockStyle)
        Me.tpActiveProcesses.Enabled = CType(resources.GetObject("tpActiveProcesses.Enabled"), Boolean)
        Me.tpActiveProcesses.Font = CType(resources.GetObject("tpActiveProcesses.Font"), System.Drawing.Font)
        Me.tpActiveProcesses.ImageIndex = CType(resources.GetObject("tpActiveProcesses.ImageIndex"), Integer)
        Me.tpActiveProcesses.ImeMode = CType(resources.GetObject("tpActiveProcesses.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpActiveProcesses.Location = CType(resources.GetObject("tpActiveProcesses.Location"), System.Drawing.Point)
        Me.tpActiveProcesses.Name = "tpActiveProcesses"
        Me.tpActiveProcesses.RightToLeft = CType(resources.GetObject("tpActiveProcesses.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpActiveProcesses.Size = CType(resources.GetObject("tpActiveProcesses.Size"), System.Drawing.Size)
        Me.tpActiveProcesses.TabIndex = CType(resources.GetObject("tpActiveProcesses.TabIndex"), Integer)
        Me.tpActiveProcesses.Text = resources.GetString("tpActiveProcesses.Text")
        Me.tpActiveProcesses.ToolTipText = resources.GetString("tpActiveProcesses.ToolTipText")
        Me.tpActiveProcesses.Visible = CType(resources.GetObject("tpActiveProcesses.Visible"), Boolean)
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
        Me.Label2.ForeColor = System.Drawing.Color.Black
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
        'btnRefreshActiveProcesses
        '
        Me.btnRefreshActiveProcesses.AccessibleDescription = resources.GetString("btnRefreshActiveProcesses.AccessibleDescription")
        Me.btnRefreshActiveProcesses.AccessibleName = resources.GetString("btnRefreshActiveProcesses.AccessibleName")
        Me.btnRefreshActiveProcesses.Anchor = CType(resources.GetObject("btnRefreshActiveProcesses.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshActiveProcesses.BackColor = System.Drawing.SystemColors.Control
        Me.btnRefreshActiveProcesses.BackgroundImage = CType(resources.GetObject("btnRefreshActiveProcesses.BackgroundImage"), System.Drawing.Image)
        Me.btnRefreshActiveProcesses.Dock = CType(resources.GetObject("btnRefreshActiveProcesses.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRefreshActiveProcesses.Enabled = CType(resources.GetObject("btnRefreshActiveProcesses.Enabled"), Boolean)
        Me.btnRefreshActiveProcesses.FlatStyle = CType(resources.GetObject("btnRefreshActiveProcesses.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRefreshActiveProcesses.Font = CType(resources.GetObject("btnRefreshActiveProcesses.Font"), System.Drawing.Font)
        Me.btnRefreshActiveProcesses.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnRefreshActiveProcesses.Image = CType(resources.GetObject("btnRefreshActiveProcesses.Image"), System.Drawing.Image)
        Me.btnRefreshActiveProcesses.ImageAlign = CType(resources.GetObject("btnRefreshActiveProcesses.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRefreshActiveProcesses.ImageIndex = CType(resources.GetObject("btnRefreshActiveProcesses.ImageIndex"), Integer)
        Me.btnRefreshActiveProcesses.ImeMode = CType(resources.GetObject("btnRefreshActiveProcesses.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRefreshActiveProcesses.Location = CType(resources.GetObject("btnRefreshActiveProcesses.Location"), System.Drawing.Point)
        Me.btnRefreshActiveProcesses.Name = "btnRefreshActiveProcesses"
        Me.btnRefreshActiveProcesses.RightToLeft = CType(resources.GetObject("btnRefreshActiveProcesses.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRefreshActiveProcesses.Size = CType(resources.GetObject("btnRefreshActiveProcesses.Size"), System.Drawing.Size)
        Me.btnRefreshActiveProcesses.TabIndex = CType(resources.GetObject("btnRefreshActiveProcesses.TabIndex"), Integer)
        Me.btnRefreshActiveProcesses.Text = resources.GetString("btnRefreshActiveProcesses.Text")
        Me.btnRefreshActiveProcesses.TextAlign = CType(resources.GetObject("btnRefreshActiveProcesses.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRefreshActiveProcesses.Visible = CType(resources.GetObject("btnRefreshActiveProcesses.Visible"), Boolean)
        '
        'lvwProcessList
        '
        Me.lvwProcessList.AccessibleDescription = resources.GetString("lvwProcessList.AccessibleDescription")
        Me.lvwProcessList.AccessibleName = resources.GetString("lvwProcessList.AccessibleName")
        Me.lvwProcessList.Alignment = CType(resources.GetObject("lvwProcessList.Alignment"), System.Windows.Forms.ListViewAlignment)
        Me.lvwProcessList.AllowColumnReorder = True
        Me.lvwProcessList.Anchor = CType(resources.GetObject("lvwProcessList.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lvwProcessList.BackgroundImage = CType(resources.GetObject("lvwProcessList.BackgroundImage"), System.Drawing.Image)
        Me.lvwProcessList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.WindowsTitle, Me.ClassName, Me.WindowsHandle})
        Me.lvwProcessList.Dock = CType(resources.GetObject("lvwProcessList.Dock"), System.Windows.Forms.DockStyle)
        Me.lvwProcessList.Enabled = CType(resources.GetObject("lvwProcessList.Enabled"), Boolean)
        Me.lvwProcessList.Font = CType(resources.GetObject("lvwProcessList.Font"), System.Drawing.Font)
        Me.lvwProcessList.FullRowSelect = True
        Me.lvwProcessList.ImeMode = CType(resources.GetObject("lvwProcessList.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lvwProcessList.LabelWrap = CType(resources.GetObject("lvwProcessList.LabelWrap"), Boolean)
        Me.lvwProcessList.Location = CType(resources.GetObject("lvwProcessList.Location"), System.Drawing.Point)
        Me.lvwProcessList.Name = "lvwProcessList"
        Me.lvwProcessList.RightToLeft = CType(resources.GetObject("lvwProcessList.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lvwProcessList.Size = CType(resources.GetObject("lvwProcessList.Size"), System.Drawing.Size)
        Me.lvwProcessList.TabIndex = CType(resources.GetObject("lvwProcessList.TabIndex"), Integer)
        Me.lvwProcessList.Text = resources.GetString("lvwProcessList.Text")
        Me.lvwProcessList.View = System.Windows.Forms.View.Details
        Me.lvwProcessList.Visible = CType(resources.GetObject("lvwProcessList.Visible"), Boolean)
        '
        'WindowsTitle
        '
        Me.WindowsTitle.Text = resources.GetString("WindowsTitle.Text")
        Me.WindowsTitle.TextAlign = CType(resources.GetObject("WindowsTitle.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.WindowsTitle.Width = CType(resources.GetObject("WindowsTitle.Width"), Integer)
        '
        'ClassName
        '
        Me.ClassName.Text = resources.GetString("ClassName.Text")
        Me.ClassName.TextAlign = CType(resources.GetObject("ClassName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.ClassName.Width = CType(resources.GetObject("ClassName.Width"), Integer)
        '
        'WindowsHandle
        '
        Me.WindowsHandle.Text = resources.GetString("WindowsHandle.Text")
        Me.WindowsHandle.TextAlign = CType(resources.GetObject("WindowsHandle.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.WindowsHandle.Width = CType(resources.GetObject("WindowsHandle.Width"), Integer)
        '
        'tpActiveWindows
        '
        Me.tpActiveWindows.AccessibleDescription = resources.GetString("tpActiveWindows.AccessibleDescription")
        Me.tpActiveWindows.AccessibleName = resources.GetString("tpActiveWindows.AccessibleName")
        Me.tpActiveWindows.Anchor = CType(resources.GetObject("tpActiveWindows.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpActiveWindows.AutoScroll = CType(resources.GetObject("tpActiveWindows.AutoScroll"), Boolean)
        Me.tpActiveWindows.AutoScrollMargin = CType(resources.GetObject("tpActiveWindows.AutoScrollMargin"), System.Drawing.Size)
        Me.tpActiveWindows.AutoScrollMinSize = CType(resources.GetObject("tpActiveWindows.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpActiveWindows.BackgroundImage = CType(resources.GetObject("tpActiveWindows.BackgroundImage"), System.Drawing.Image)
        Me.tpActiveWindows.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshActiveWindows, Me.Label1, Me.lbActiveWindows})
        Me.tpActiveWindows.Dock = CType(resources.GetObject("tpActiveWindows.Dock"), System.Windows.Forms.DockStyle)
        Me.tpActiveWindows.Enabled = CType(resources.GetObject("tpActiveWindows.Enabled"), Boolean)
        Me.tpActiveWindows.Font = CType(resources.GetObject("tpActiveWindows.Font"), System.Drawing.Font)
        Me.tpActiveWindows.ImageIndex = CType(resources.GetObject("tpActiveWindows.ImageIndex"), Integer)
        Me.tpActiveWindows.ImeMode = CType(resources.GetObject("tpActiveWindows.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpActiveWindows.Location = CType(resources.GetObject("tpActiveWindows.Location"), System.Drawing.Point)
        Me.tpActiveWindows.Name = "tpActiveWindows"
        Me.tpActiveWindows.RightToLeft = CType(resources.GetObject("tpActiveWindows.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpActiveWindows.Size = CType(resources.GetObject("tpActiveWindows.Size"), System.Drawing.Size)
        Me.tpActiveWindows.TabIndex = CType(resources.GetObject("tpActiveWindows.TabIndex"), Integer)
        Me.tpActiveWindows.Text = resources.GetString("tpActiveWindows.Text")
        Me.tpActiveWindows.ToolTipText = resources.GetString("tpActiveWindows.ToolTipText")
        Me.tpActiveWindows.Visible = CType(resources.GetObject("tpActiveWindows.Visible"), Boolean)
        '
        'btnRefreshActiveWindows
        '
        Me.btnRefreshActiveWindows.AccessibleDescription = resources.GetString("btnRefreshActiveWindows.AccessibleDescription")
        Me.btnRefreshActiveWindows.AccessibleName = resources.GetString("btnRefreshActiveWindows.AccessibleName")
        Me.btnRefreshActiveWindows.Anchor = CType(resources.GetObject("btnRefreshActiveWindows.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshActiveWindows.BackColor = System.Drawing.SystemColors.Control
        Me.btnRefreshActiveWindows.BackgroundImage = CType(resources.GetObject("btnRefreshActiveWindows.BackgroundImage"), System.Drawing.Image)
        Me.btnRefreshActiveWindows.Dock = CType(resources.GetObject("btnRefreshActiveWindows.Dock"), System.Windows.Forms.DockStyle)
        Me.btnRefreshActiveWindows.Enabled = CType(resources.GetObject("btnRefreshActiveWindows.Enabled"), Boolean)
        Me.btnRefreshActiveWindows.FlatStyle = CType(resources.GetObject("btnRefreshActiveWindows.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnRefreshActiveWindows.Font = CType(resources.GetObject("btnRefreshActiveWindows.Font"), System.Drawing.Font)
        Me.btnRefreshActiveWindows.ForeColor = System.Drawing.SystemColors.WindowText
        Me.btnRefreshActiveWindows.Image = CType(resources.GetObject("btnRefreshActiveWindows.Image"), System.Drawing.Image)
        Me.btnRefreshActiveWindows.ImageAlign = CType(resources.GetObject("btnRefreshActiveWindows.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnRefreshActiveWindows.ImageIndex = CType(resources.GetObject("btnRefreshActiveWindows.ImageIndex"), Integer)
        Me.btnRefreshActiveWindows.ImeMode = CType(resources.GetObject("btnRefreshActiveWindows.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnRefreshActiveWindows.Location = CType(resources.GetObject("btnRefreshActiveWindows.Location"), System.Drawing.Point)
        Me.btnRefreshActiveWindows.Name = "btnRefreshActiveWindows"
        Me.btnRefreshActiveWindows.RightToLeft = CType(resources.GetObject("btnRefreshActiveWindows.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnRefreshActiveWindows.Size = CType(resources.GetObject("btnRefreshActiveWindows.Size"), System.Drawing.Size)
        Me.btnRefreshActiveWindows.TabIndex = CType(resources.GetObject("btnRefreshActiveWindows.TabIndex"), Integer)
        Me.btnRefreshActiveWindows.Text = resources.GetString("btnRefreshActiveWindows.Text")
        Me.btnRefreshActiveWindows.TextAlign = CType(resources.GetObject("btnRefreshActiveWindows.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnRefreshActiveWindows.Visible = CType(resources.GetObject("btnRefreshActiveWindows.Visible"), Boolean)
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
        Me.Label1.ForeColor = System.Drawing.Color.Black
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
        'lbActiveWindows
        '
        Me.lbActiveWindows.AccessibleDescription = resources.GetString("lbActiveWindows.AccessibleDescription")
        Me.lbActiveWindows.AccessibleName = resources.GetString("lbActiveWindows.AccessibleName")
        Me.lbActiveWindows.Anchor = CType(resources.GetObject("lbActiveWindows.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lbActiveWindows.BackgroundImage = CType(resources.GetObject("lbActiveWindows.BackgroundImage"), System.Drawing.Image)
        Me.lbActiveWindows.ColumnWidth = CType(resources.GetObject("lbActiveWindows.ColumnWidth"), Integer)
        Me.lbActiveWindows.Dock = CType(resources.GetObject("lbActiveWindows.Dock"), System.Windows.Forms.DockStyle)
        Me.lbActiveWindows.Enabled = CType(resources.GetObject("lbActiveWindows.Enabled"), Boolean)
        Me.lbActiveWindows.Font = CType(resources.GetObject("lbActiveWindows.Font"), System.Drawing.Font)
        Me.lbActiveWindows.HorizontalExtent = CType(resources.GetObject("lbActiveWindows.HorizontalExtent"), Integer)
        Me.lbActiveWindows.HorizontalScrollbar = CType(resources.GetObject("lbActiveWindows.HorizontalScrollbar"), Boolean)
        Me.lbActiveWindows.ImeMode = CType(resources.GetObject("lbActiveWindows.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lbActiveWindows.IntegralHeight = CType(resources.GetObject("lbActiveWindows.IntegralHeight"), Boolean)
        Me.lbActiveWindows.ItemHeight = CType(resources.GetObject("lbActiveWindows.ItemHeight"), Integer)
        Me.lbActiveWindows.Location = CType(resources.GetObject("lbActiveWindows.Location"), System.Drawing.Point)
        Me.lbActiveWindows.Name = "lbActiveWindows"
        Me.lbActiveWindows.RightToLeft = CType(resources.GetObject("lbActiveWindows.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lbActiveWindows.ScrollAlwaysVisible = CType(resources.GetObject("lbActiveWindows.ScrollAlwaysVisible"), Boolean)
        Me.lbActiveWindows.Size = CType(resources.GetObject("lbActiveWindows.Size"), System.Drawing.Size)
        Me.lbActiveWindows.TabIndex = CType(resources.GetObject("lbActiveWindows.TabIndex"), Integer)
        Me.lbActiveWindows.Visible = CType(resources.GetObject("lbActiveWindows.Visible"), Boolean)
        '
        'tpShowWindow
        '
        Me.tpShowWindow.AccessibleDescription = resources.GetString("tpShowWindow.AccessibleDescription")
        Me.tpShowWindow.AccessibleName = resources.GetString("tpShowWindow.AccessibleName")
        Me.tpShowWindow.Anchor = CType(resources.GetObject("tpShowWindow.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpShowWindow.AutoScroll = CType(resources.GetObject("tpShowWindow.AutoScroll"), Boolean)
        Me.tpShowWindow.AutoScrollMargin = CType(resources.GetObject("tpShowWindow.AutoScrollMargin"), System.Drawing.Size)
        Me.tpShowWindow.AutoScrollMinSize = CType(resources.GetObject("tpShowWindow.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpShowWindow.BackgroundImage = CType(resources.GetObject("tpShowWindow.BackgroundImage"), System.Drawing.Image)
        Me.tpShowWindow.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFunctionCalled, Me.btnShow, Me.Label6, Me.txtClassName, Me.txtWindowCaption, Me.Label5, Me.Label4, Me.Label3})
        Me.tpShowWindow.Dock = CType(resources.GetObject("tpShowWindow.Dock"), System.Windows.Forms.DockStyle)
        Me.tpShowWindow.Enabled = CType(resources.GetObject("tpShowWindow.Enabled"), Boolean)
        Me.tpShowWindow.Font = CType(resources.GetObject("tpShowWindow.Font"), System.Drawing.Font)
        Me.tpShowWindow.ImageIndex = CType(resources.GetObject("tpShowWindow.ImageIndex"), Integer)
        Me.tpShowWindow.ImeMode = CType(resources.GetObject("tpShowWindow.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpShowWindow.Location = CType(resources.GetObject("tpShowWindow.Location"), System.Drawing.Point)
        Me.tpShowWindow.Name = "tpShowWindow"
        Me.tpShowWindow.RightToLeft = CType(resources.GetObject("tpShowWindow.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpShowWindow.Size = CType(resources.GetObject("tpShowWindow.Size"), System.Drawing.Size)
        Me.tpShowWindow.TabIndex = CType(resources.GetObject("tpShowWindow.TabIndex"), Integer)
        Me.tpShowWindow.Text = resources.GetString("tpShowWindow.Text")
        Me.tpShowWindow.ToolTipText = resources.GetString("tpShowWindow.ToolTipText")
        Me.tpShowWindow.Visible = CType(resources.GetObject("tpShowWindow.Visible"), Boolean)
        '
        'lblFunctionCalled
        '
        Me.lblFunctionCalled.AccessibleDescription = resources.GetString("lblFunctionCalled.AccessibleDescription")
        Me.lblFunctionCalled.AccessibleName = resources.GetString("lblFunctionCalled.AccessibleName")
        Me.lblFunctionCalled.Anchor = CType(resources.GetObject("lblFunctionCalled.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblFunctionCalled.AutoSize = CType(resources.GetObject("lblFunctionCalled.AutoSize"), Boolean)
        Me.lblFunctionCalled.Dock = CType(resources.GetObject("lblFunctionCalled.Dock"), System.Windows.Forms.DockStyle)
        Me.lblFunctionCalled.Enabled = CType(resources.GetObject("lblFunctionCalled.Enabled"), Boolean)
        Me.lblFunctionCalled.Font = CType(resources.GetObject("lblFunctionCalled.Font"), System.Drawing.Font)
        Me.lblFunctionCalled.Image = CType(resources.GetObject("lblFunctionCalled.Image"), System.Drawing.Image)
        Me.lblFunctionCalled.ImageAlign = CType(resources.GetObject("lblFunctionCalled.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblFunctionCalled.ImageIndex = CType(resources.GetObject("lblFunctionCalled.ImageIndex"), Integer)
        Me.lblFunctionCalled.ImeMode = CType(resources.GetObject("lblFunctionCalled.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblFunctionCalled.Location = CType(resources.GetObject("lblFunctionCalled.Location"), System.Drawing.Point)
        Me.lblFunctionCalled.Name = "lblFunctionCalled"
        Me.lblFunctionCalled.RightToLeft = CType(resources.GetObject("lblFunctionCalled.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblFunctionCalled.Size = CType(resources.GetObject("lblFunctionCalled.Size"), System.Drawing.Size)
        Me.lblFunctionCalled.TabIndex = CType(resources.GetObject("lblFunctionCalled.TabIndex"), Integer)
        Me.lblFunctionCalled.Text = resources.GetString("lblFunctionCalled.Text")
        Me.lblFunctionCalled.TextAlign = CType(resources.GetObject("lblFunctionCalled.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblFunctionCalled.Visible = CType(resources.GetObject("lblFunctionCalled.Visible"), Boolean)
        '
        'btnShow
        '
        Me.btnShow.AccessibleDescription = resources.GetString("btnShow.AccessibleDescription")
        Me.btnShow.AccessibleName = resources.GetString("btnShow.AccessibleName")
        Me.btnShow.Anchor = CType(resources.GetObject("btnShow.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnShow.BackgroundImage = CType(resources.GetObject("btnShow.BackgroundImage"), System.Drawing.Image)
        Me.btnShow.Dock = CType(resources.GetObject("btnShow.Dock"), System.Windows.Forms.DockStyle)
        Me.btnShow.Enabled = CType(resources.GetObject("btnShow.Enabled"), Boolean)
        Me.btnShow.FlatStyle = CType(resources.GetObject("btnShow.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnShow.Font = CType(resources.GetObject("btnShow.Font"), System.Drawing.Font)
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.ImageAlign = CType(resources.GetObject("btnShow.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnShow.ImageIndex = CType(resources.GetObject("btnShow.ImageIndex"), Integer)
        Me.btnShow.ImeMode = CType(resources.GetObject("btnShow.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnShow.Location = CType(resources.GetObject("btnShow.Location"), System.Drawing.Point)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.RightToLeft = CType(resources.GetObject("btnShow.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnShow.Size = CType(resources.GetObject("btnShow.Size"), System.Drawing.Size)
        Me.btnShow.TabIndex = CType(resources.GetObject("btnShow.TabIndex"), Integer)
        Me.btnShow.Text = resources.GetString("btnShow.Text")
        Me.btnShow.TextAlign = CType(resources.GetObject("btnShow.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnShow.Visible = CType(resources.GetObject("btnShow.Visible"), Boolean)
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
        Me.Label6.ForeColor = System.Drawing.Color.Black
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
        'txtClassName
        '
        Me.txtClassName.AccessibleDescription = resources.GetString("txtClassName.AccessibleDescription")
        Me.txtClassName.AccessibleName = resources.GetString("txtClassName.AccessibleName")
        Me.txtClassName.Anchor = CType(resources.GetObject("txtClassName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtClassName.AutoSize = CType(resources.GetObject("txtClassName.AutoSize"), Boolean)
        Me.txtClassName.BackgroundImage = CType(resources.GetObject("txtClassName.BackgroundImage"), System.Drawing.Image)
        Me.txtClassName.Dock = CType(resources.GetObject("txtClassName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtClassName.Enabled = CType(resources.GetObject("txtClassName.Enabled"), Boolean)
        Me.txtClassName.Font = CType(resources.GetObject("txtClassName.Font"), System.Drawing.Font)
        Me.txtClassName.ImeMode = CType(resources.GetObject("txtClassName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtClassName.Location = CType(resources.GetObject("txtClassName.Location"), System.Drawing.Point)
        Me.txtClassName.MaxLength = CType(resources.GetObject("txtClassName.MaxLength"), Integer)
        Me.txtClassName.Multiline = CType(resources.GetObject("txtClassName.Multiline"), Boolean)
        Me.txtClassName.Name = "txtClassName"
        Me.txtClassName.PasswordChar = CType(resources.GetObject("txtClassName.PasswordChar"), Char)
        Me.txtClassName.RightToLeft = CType(resources.GetObject("txtClassName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtClassName.ScrollBars = CType(resources.GetObject("txtClassName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtClassName.Size = CType(resources.GetObject("txtClassName.Size"), System.Drawing.Size)
        Me.txtClassName.TabIndex = CType(resources.GetObject("txtClassName.TabIndex"), Integer)
        Me.txtClassName.Text = resources.GetString("txtClassName.Text")
        Me.txtClassName.TextAlign = CType(resources.GetObject("txtClassName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtClassName.Visible = CType(resources.GetObject("txtClassName.Visible"), Boolean)
        Me.txtClassName.WordWrap = CType(resources.GetObject("txtClassName.WordWrap"), Boolean)
        '
        'txtWindowCaption
        '
        Me.txtWindowCaption.AccessibleDescription = resources.GetString("txtWindowCaption.AccessibleDescription")
        Me.txtWindowCaption.AccessibleName = resources.GetString("txtWindowCaption.AccessibleName")
        Me.txtWindowCaption.Anchor = CType(resources.GetObject("txtWindowCaption.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtWindowCaption.AutoSize = CType(resources.GetObject("txtWindowCaption.AutoSize"), Boolean)
        Me.txtWindowCaption.BackgroundImage = CType(resources.GetObject("txtWindowCaption.BackgroundImage"), System.Drawing.Image)
        Me.txtWindowCaption.Dock = CType(resources.GetObject("txtWindowCaption.Dock"), System.Windows.Forms.DockStyle)
        Me.txtWindowCaption.Enabled = CType(resources.GetObject("txtWindowCaption.Enabled"), Boolean)
        Me.txtWindowCaption.Font = CType(resources.GetObject("txtWindowCaption.Font"), System.Drawing.Font)
        Me.txtWindowCaption.ImeMode = CType(resources.GetObject("txtWindowCaption.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtWindowCaption.Location = CType(resources.GetObject("txtWindowCaption.Location"), System.Drawing.Point)
        Me.txtWindowCaption.MaxLength = CType(resources.GetObject("txtWindowCaption.MaxLength"), Integer)
        Me.txtWindowCaption.Multiline = CType(resources.GetObject("txtWindowCaption.Multiline"), Boolean)
        Me.txtWindowCaption.Name = "txtWindowCaption"
        Me.txtWindowCaption.PasswordChar = CType(resources.GetObject("txtWindowCaption.PasswordChar"), Char)
        Me.txtWindowCaption.RightToLeft = CType(resources.GetObject("txtWindowCaption.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtWindowCaption.ScrollBars = CType(resources.GetObject("txtWindowCaption.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtWindowCaption.Size = CType(resources.GetObject("txtWindowCaption.Size"), System.Drawing.Size)
        Me.txtWindowCaption.TabIndex = CType(resources.GetObject("txtWindowCaption.TabIndex"), Integer)
        Me.txtWindowCaption.Text = resources.GetString("txtWindowCaption.Text")
        Me.txtWindowCaption.TextAlign = CType(resources.GetObject("txtWindowCaption.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtWindowCaption.Visible = CType(resources.GetObject("txtWindowCaption.Visible"), Boolean)
        Me.txtWindowCaption.WordWrap = CType(resources.GetObject("txtWindowCaption.WordWrap"), Boolean)
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
        Me.Label3.ForeColor = System.Drawing.Color.Black
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
        'tpAPICalls
        '
        Me.tpAPICalls.AccessibleDescription = resources.GetString("tpAPICalls.AccessibleDescription")
        Me.tpAPICalls.AccessibleName = resources.GetString("tpAPICalls.AccessibleName")
        Me.tpAPICalls.Anchor = CType(resources.GetObject("tpAPICalls.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.tpAPICalls.AutoScroll = CType(resources.GetObject("tpAPICalls.AutoScroll"), Boolean)
        Me.tpAPICalls.AutoScrollMargin = CType(resources.GetObject("tpAPICalls.AutoScrollMargin"), System.Drawing.Size)
        Me.tpAPICalls.AutoScrollMinSize = CType(resources.GetObject("tpAPICalls.AutoScrollMinSize"), System.Drawing.Size)
        Me.tpAPICalls.BackgroundImage = CType(resources.GetObject("tpAPICalls.BackgroundImage"), System.Drawing.Image)
        Me.tpAPICalls.Controls.AddRange(New System.Windows.Forms.Control() {Me.CallingVariationGroupBox, Me.Label9, Me.DirectoryGroupBox, Me.MouseGroupBox, Me.DriveGroupBox, Me.txtFunctionOutput, Me.MiscGroupBox})
        Me.tpAPICalls.Dock = CType(resources.GetObject("tpAPICalls.Dock"), System.Windows.Forms.DockStyle)
        Me.tpAPICalls.Enabled = CType(resources.GetObject("tpAPICalls.Enabled"), Boolean)
        Me.tpAPICalls.Font = CType(resources.GetObject("tpAPICalls.Font"), System.Drawing.Font)
        Me.tpAPICalls.ImageIndex = CType(resources.GetObject("tpAPICalls.ImageIndex"), Integer)
        Me.tpAPICalls.ImeMode = CType(resources.GetObject("tpAPICalls.ImeMode"), System.Windows.Forms.ImeMode)
        Me.tpAPICalls.Location = CType(resources.GetObject("tpAPICalls.Location"), System.Drawing.Point)
        Me.tpAPICalls.Name = "tpAPICalls"
        Me.tpAPICalls.RightToLeft = CType(resources.GetObject("tpAPICalls.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.tpAPICalls.Size = CType(resources.GetObject("tpAPICalls.Size"), System.Drawing.Size)
        Me.tpAPICalls.TabIndex = CType(resources.GetObject("tpAPICalls.TabIndex"), Integer)
        Me.tpAPICalls.Text = resources.GetString("tpAPICalls.Text")
        Me.tpAPICalls.ToolTipText = resources.GetString("tpAPICalls.ToolTipText")
        Me.tpAPICalls.Visible = CType(resources.GetObject("tpAPICalls.Visible"), Boolean)
        '
        'CallingVariationGroupBox
        '
        Me.CallingVariationGroupBox.AccessibleDescription = CType(resources.GetObject("CallingVariationGroupBox.AccessibleDescription"), String)
        Me.CallingVariationGroupBox.AccessibleName = CType(resources.GetObject("CallingVariationGroupBox.AccessibleName"), String)
        Me.CallingVariationGroupBox.Anchor = CType(resources.GetObject("CallingVariationGroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.CallingVariationGroupBox.BackgroundImage = CType(resources.GetObject("CallingVariationGroupBox.BackgroundImage"), System.Drawing.Image)
        Me.CallingVariationGroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBeep, Me.rbAuto, Me.rbANSI, Me.rbUnicode, Me.rbDLLImport, Me.rbDeclare})
        Me.CallingVariationGroupBox.Dock = CType(resources.GetObject("CallingVariationGroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.CallingVariationGroupBox.Enabled = CType(resources.GetObject("CallingVariationGroupBox.Enabled"), Boolean)
        Me.CallingVariationGroupBox.Font = CType(resources.GetObject("CallingVariationGroupBox.Font"), System.Drawing.Font)
        Me.CallingVariationGroupBox.ImeMode = CType(resources.GetObject("CallingVariationGroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.CallingVariationGroupBox.Location = CType(resources.GetObject("CallingVariationGroupBox.Location"), System.Drawing.Point)
        Me.CallingVariationGroupBox.Name = "CallingVariationGroupBox"
        Me.CallingVariationGroupBox.RightToLeft = CType(resources.GetObject("CallingVariationGroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.CallingVariationGroupBox.Size = CType(resources.GetObject("CallingVariationGroupBox.Size"), System.Drawing.Size)
        Me.CallingVariationGroupBox.TabIndex = CType(resources.GetObject("CallingVariationGroupBox.TabIndex"), Integer)
        Me.CallingVariationGroupBox.TabStop = False
        Me.CallingVariationGroupBox.Text = resources.GetString("CallingVariationGroupBox.Text")
        Me.CallingVariationGroupBox.Visible = CType(resources.GetObject("CallingVariationGroupBox.Visible"), Boolean)
        '
        'btnBeep
        '
        Me.btnBeep.AccessibleDescription = resources.GetString("btnBeep.AccessibleDescription")
        Me.btnBeep.AccessibleName = resources.GetString("btnBeep.AccessibleName")
        Me.btnBeep.Anchor = CType(resources.GetObject("btnBeep.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBeep.BackgroundImage = CType(resources.GetObject("btnBeep.BackgroundImage"), System.Drawing.Image)
        Me.btnBeep.Dock = CType(resources.GetObject("btnBeep.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBeep.Enabled = CType(resources.GetObject("btnBeep.Enabled"), Boolean)
        Me.btnBeep.FlatStyle = CType(resources.GetObject("btnBeep.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBeep.Font = CType(resources.GetObject("btnBeep.Font"), System.Drawing.Font)
        Me.btnBeep.Image = CType(resources.GetObject("btnBeep.Image"), System.Drawing.Image)
        Me.btnBeep.ImageAlign = CType(resources.GetObject("btnBeep.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBeep.ImageIndex = CType(resources.GetObject("btnBeep.ImageIndex"), Integer)
        Me.btnBeep.ImeMode = CType(resources.GetObject("btnBeep.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBeep.Location = CType(resources.GetObject("btnBeep.Location"), System.Drawing.Point)
        Me.btnBeep.Name = "btnBeep"
        Me.btnBeep.RightToLeft = CType(resources.GetObject("btnBeep.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBeep.Size = CType(resources.GetObject("btnBeep.Size"), System.Drawing.Size)
        Me.btnBeep.TabIndex = CType(resources.GetObject("btnBeep.TabIndex"), Integer)
        Me.btnBeep.Text = resources.GetString("btnBeep.Text")
        Me.btnBeep.TextAlign = CType(resources.GetObject("btnBeep.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBeep.Visible = CType(resources.GetObject("btnBeep.Visible"), Boolean)
        '
        'rbAuto
        '
        Me.rbAuto.AccessibleDescription = resources.GetString("rbAuto.AccessibleDescription")
        Me.rbAuto.AccessibleName = resources.GetString("rbAuto.AccessibleName")
        Me.rbAuto.Anchor = CType(resources.GetObject("rbAuto.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rbAuto.Appearance = CType(resources.GetObject("rbAuto.Appearance"), System.Windows.Forms.Appearance)
        Me.rbAuto.BackgroundImage = CType(resources.GetObject("rbAuto.BackgroundImage"), System.Drawing.Image)
        Me.rbAuto.CheckAlign = CType(resources.GetObject("rbAuto.CheckAlign"), System.Drawing.ContentAlignment)
        Me.rbAuto.Dock = CType(resources.GetObject("rbAuto.Dock"), System.Windows.Forms.DockStyle)
        Me.rbAuto.Enabled = CType(resources.GetObject("rbAuto.Enabled"), Boolean)
        Me.rbAuto.FlatStyle = CType(resources.GetObject("rbAuto.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.rbAuto.Font = CType(resources.GetObject("rbAuto.Font"), System.Drawing.Font)
        Me.rbAuto.Image = CType(resources.GetObject("rbAuto.Image"), System.Drawing.Image)
        Me.rbAuto.ImageAlign = CType(resources.GetObject("rbAuto.ImageAlign"), System.Drawing.ContentAlignment)
        Me.rbAuto.ImageIndex = CType(resources.GetObject("rbAuto.ImageIndex"), Integer)
        Me.rbAuto.ImeMode = CType(resources.GetObject("rbAuto.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rbAuto.Location = CType(resources.GetObject("rbAuto.Location"), System.Drawing.Point)
        Me.rbAuto.Name = "rbAuto"
        Me.rbAuto.RightToLeft = CType(resources.GetObject("rbAuto.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rbAuto.Size = CType(resources.GetObject("rbAuto.Size"), System.Drawing.Size)
        Me.rbAuto.TabIndex = CType(resources.GetObject("rbAuto.TabIndex"), Integer)
        Me.rbAuto.Text = resources.GetString("rbAuto.Text")
        Me.rbAuto.TextAlign = CType(resources.GetObject("rbAuto.TextAlign"), System.Drawing.ContentAlignment)
        Me.rbAuto.Visible = CType(resources.GetObject("rbAuto.Visible"), Boolean)
        '
        'rbANSI
        '
        Me.rbANSI.AccessibleDescription = resources.GetString("rbANSI.AccessibleDescription")
        Me.rbANSI.AccessibleName = resources.GetString("rbANSI.AccessibleName")
        Me.rbANSI.Anchor = CType(resources.GetObject("rbANSI.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rbANSI.Appearance = CType(resources.GetObject("rbANSI.Appearance"), System.Windows.Forms.Appearance)
        Me.rbANSI.BackgroundImage = CType(resources.GetObject("rbANSI.BackgroundImage"), System.Drawing.Image)
        Me.rbANSI.CheckAlign = CType(resources.GetObject("rbANSI.CheckAlign"), System.Drawing.ContentAlignment)
        Me.rbANSI.Dock = CType(resources.GetObject("rbANSI.Dock"), System.Windows.Forms.DockStyle)
        Me.rbANSI.Enabled = CType(resources.GetObject("rbANSI.Enabled"), Boolean)
        Me.rbANSI.FlatStyle = CType(resources.GetObject("rbANSI.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.rbANSI.Font = CType(resources.GetObject("rbANSI.Font"), System.Drawing.Font)
        Me.rbANSI.Image = CType(resources.GetObject("rbANSI.Image"), System.Drawing.Image)
        Me.rbANSI.ImageAlign = CType(resources.GetObject("rbANSI.ImageAlign"), System.Drawing.ContentAlignment)
        Me.rbANSI.ImageIndex = CType(resources.GetObject("rbANSI.ImageIndex"), Integer)
        Me.rbANSI.ImeMode = CType(resources.GetObject("rbANSI.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rbANSI.Location = CType(resources.GetObject("rbANSI.Location"), System.Drawing.Point)
        Me.rbANSI.Name = "rbANSI"
        Me.rbANSI.RightToLeft = CType(resources.GetObject("rbANSI.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rbANSI.Size = CType(resources.GetObject("rbANSI.Size"), System.Drawing.Size)
        Me.rbANSI.TabIndex = CType(resources.GetObject("rbANSI.TabIndex"), Integer)
        Me.rbANSI.Text = resources.GetString("rbANSI.Text")
        Me.rbANSI.TextAlign = CType(resources.GetObject("rbANSI.TextAlign"), System.Drawing.ContentAlignment)
        Me.rbANSI.Visible = CType(resources.GetObject("rbANSI.Visible"), Boolean)
        '
        'rbUnicode
        '
        Me.rbUnicode.AccessibleDescription = resources.GetString("rbUnicode.AccessibleDescription")
        Me.rbUnicode.AccessibleName = resources.GetString("rbUnicode.AccessibleName")
        Me.rbUnicode.Anchor = CType(resources.GetObject("rbUnicode.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rbUnicode.Appearance = CType(resources.GetObject("rbUnicode.Appearance"), System.Windows.Forms.Appearance)
        Me.rbUnicode.BackgroundImage = CType(resources.GetObject("rbUnicode.BackgroundImage"), System.Drawing.Image)
        Me.rbUnicode.CheckAlign = CType(resources.GetObject("rbUnicode.CheckAlign"), System.Drawing.ContentAlignment)
        Me.rbUnicode.Dock = CType(resources.GetObject("rbUnicode.Dock"), System.Windows.Forms.DockStyle)
        Me.rbUnicode.Enabled = CType(resources.GetObject("rbUnicode.Enabled"), Boolean)
        Me.rbUnicode.FlatStyle = CType(resources.GetObject("rbUnicode.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.rbUnicode.Font = CType(resources.GetObject("rbUnicode.Font"), System.Drawing.Font)
        Me.rbUnicode.Image = CType(resources.GetObject("rbUnicode.Image"), System.Drawing.Image)
        Me.rbUnicode.ImageAlign = CType(resources.GetObject("rbUnicode.ImageAlign"), System.Drawing.ContentAlignment)
        Me.rbUnicode.ImageIndex = CType(resources.GetObject("rbUnicode.ImageIndex"), Integer)
        Me.rbUnicode.ImeMode = CType(resources.GetObject("rbUnicode.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rbUnicode.Location = CType(resources.GetObject("rbUnicode.Location"), System.Drawing.Point)
        Me.rbUnicode.Name = "rbUnicode"
        Me.rbUnicode.RightToLeft = CType(resources.GetObject("rbUnicode.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rbUnicode.Size = CType(resources.GetObject("rbUnicode.Size"), System.Drawing.Size)
        Me.rbUnicode.TabIndex = CType(resources.GetObject("rbUnicode.TabIndex"), Integer)
        Me.rbUnicode.Text = resources.GetString("rbUnicode.Text")
        Me.rbUnicode.TextAlign = CType(resources.GetObject("rbUnicode.TextAlign"), System.Drawing.ContentAlignment)
        Me.rbUnicode.Visible = CType(resources.GetObject("rbUnicode.Visible"), Boolean)
        '
        'rbDLLImport
        '
        Me.rbDLLImport.AccessibleDescription = resources.GetString("rbDLLImport.AccessibleDescription")
        Me.rbDLLImport.AccessibleName = resources.GetString("rbDLLImport.AccessibleName")
        Me.rbDLLImport.Anchor = CType(resources.GetObject("rbDLLImport.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rbDLLImport.Appearance = CType(resources.GetObject("rbDLLImport.Appearance"), System.Windows.Forms.Appearance)
        Me.rbDLLImport.BackgroundImage = CType(resources.GetObject("rbDLLImport.BackgroundImage"), System.Drawing.Image)
        Me.rbDLLImport.CheckAlign = CType(resources.GetObject("rbDLLImport.CheckAlign"), System.Drawing.ContentAlignment)
        Me.rbDLLImport.Dock = CType(resources.GetObject("rbDLLImport.Dock"), System.Windows.Forms.DockStyle)
        Me.rbDLLImport.Enabled = CType(resources.GetObject("rbDLLImport.Enabled"), Boolean)
        Me.rbDLLImport.FlatStyle = CType(resources.GetObject("rbDLLImport.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.rbDLLImport.Font = CType(resources.GetObject("rbDLLImport.Font"), System.Drawing.Font)
        Me.rbDLLImport.Image = CType(resources.GetObject("rbDLLImport.Image"), System.Drawing.Image)
        Me.rbDLLImport.ImageAlign = CType(resources.GetObject("rbDLLImport.ImageAlign"), System.Drawing.ContentAlignment)
        Me.rbDLLImport.ImageIndex = CType(resources.GetObject("rbDLLImport.ImageIndex"), Integer)
        Me.rbDLLImport.ImeMode = CType(resources.GetObject("rbDLLImport.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rbDLLImport.Location = CType(resources.GetObject("rbDLLImport.Location"), System.Drawing.Point)
        Me.rbDLLImport.Name = "rbDLLImport"
        Me.rbDLLImport.RightToLeft = CType(resources.GetObject("rbDLLImport.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rbDLLImport.Size = CType(resources.GetObject("rbDLLImport.Size"), System.Drawing.Size)
        Me.rbDLLImport.TabIndex = CType(resources.GetObject("rbDLLImport.TabIndex"), Integer)
        Me.rbDLLImport.Text = resources.GetString("rbDLLImport.Text")
        Me.rbDLLImport.TextAlign = CType(resources.GetObject("rbDLLImport.TextAlign"), System.Drawing.ContentAlignment)
        Me.rbDLLImport.Visible = CType(resources.GetObject("rbDLLImport.Visible"), Boolean)
        '
        'rbDeclare
        '
        Me.rbDeclare.AccessibleDescription = resources.GetString("rbDeclare.AccessibleDescription")
        Me.rbDeclare.AccessibleName = resources.GetString("rbDeclare.AccessibleName")
        Me.rbDeclare.Anchor = CType(resources.GetObject("rbDeclare.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rbDeclare.Appearance = CType(resources.GetObject("rbDeclare.Appearance"), System.Windows.Forms.Appearance)
        Me.rbDeclare.BackgroundImage = CType(resources.GetObject("rbDeclare.BackgroundImage"), System.Drawing.Image)
        Me.rbDeclare.CheckAlign = CType(resources.GetObject("rbDeclare.CheckAlign"), System.Drawing.ContentAlignment)
        Me.rbDeclare.Checked = True
        Me.rbDeclare.Dock = CType(resources.GetObject("rbDeclare.Dock"), System.Windows.Forms.DockStyle)
        Me.rbDeclare.Enabled = CType(resources.GetObject("rbDeclare.Enabled"), Boolean)
        Me.rbDeclare.FlatStyle = CType(resources.GetObject("rbDeclare.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.rbDeclare.Font = CType(resources.GetObject("rbDeclare.Font"), System.Drawing.Font)
        Me.rbDeclare.Image = CType(resources.GetObject("rbDeclare.Image"), System.Drawing.Image)
        Me.rbDeclare.ImageAlign = CType(resources.GetObject("rbDeclare.ImageAlign"), System.Drawing.ContentAlignment)
        Me.rbDeclare.ImageIndex = CType(resources.GetObject("rbDeclare.ImageIndex"), Integer)
        Me.rbDeclare.ImeMode = CType(resources.GetObject("rbDeclare.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rbDeclare.Location = CType(resources.GetObject("rbDeclare.Location"), System.Drawing.Point)
        Me.rbDeclare.Name = "rbDeclare"
        Me.rbDeclare.RightToLeft = CType(resources.GetObject("rbDeclare.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rbDeclare.Size = CType(resources.GetObject("rbDeclare.Size"), System.Drawing.Size)
        Me.rbDeclare.TabIndex = CType(resources.GetObject("rbDeclare.TabIndex"), Integer)
        Me.rbDeclare.TabStop = True
        Me.rbDeclare.Text = resources.GetString("rbDeclare.Text")
        Me.rbDeclare.TextAlign = CType(resources.GetObject("rbDeclare.TextAlign"), System.Drawing.ContentAlignment)
        Me.rbDeclare.Visible = CType(resources.GetObject("rbDeclare.Visible"), Boolean)
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
        Me.Label9.ForeColor = System.Drawing.Color.Black
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
        'DirectoryGroupBox
        '
        Me.DirectoryGroupBox.AccessibleDescription = CType(resources.GetObject("DirectoryGroupBox.AccessibleDescription"), String)
        Me.DirectoryGroupBox.AccessibleName = CType(resources.GetObject("DirectoryGroupBox.AccessibleName"), String)
        Me.DirectoryGroupBox.Anchor = CType(resources.GetObject("DirectoryGroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.DirectoryGroupBox.BackgroundImage = CType(resources.GetObject("DirectoryGroupBox.BackgroundImage"), System.Drawing.Image)
        Me.DirectoryGroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDirectory, Me.btnCreateDirectory})
        Me.DirectoryGroupBox.Dock = CType(resources.GetObject("DirectoryGroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.DirectoryGroupBox.Enabled = CType(resources.GetObject("DirectoryGroupBox.Enabled"), Boolean)
        Me.DirectoryGroupBox.Font = CType(resources.GetObject("DirectoryGroupBox.Font"), System.Drawing.Font)
        Me.DirectoryGroupBox.ImeMode = CType(resources.GetObject("DirectoryGroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.DirectoryGroupBox.Location = CType(resources.GetObject("DirectoryGroupBox.Location"), System.Drawing.Point)
        Me.DirectoryGroupBox.Name = "DirectoryGroupBox"
        Me.DirectoryGroupBox.RightToLeft = CType(resources.GetObject("DirectoryGroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.DirectoryGroupBox.Size = CType(resources.GetObject("DirectoryGroupBox.Size"), System.Drawing.Size)
        Me.DirectoryGroupBox.TabIndex = CType(resources.GetObject("DirectoryGroupBox.TabIndex"), Integer)
        Me.DirectoryGroupBox.TabStop = False
        Me.DirectoryGroupBox.Text = resources.GetString("DirectoryGroupBox.Text")
        Me.DirectoryGroupBox.Visible = CType(resources.GetObject("DirectoryGroupBox.Visible"), Boolean)
        '
        'txtDirectory
        '
        Me.txtDirectory.AccessibleDescription = resources.GetString("txtDirectory.AccessibleDescription")
        Me.txtDirectory.AccessibleName = resources.GetString("txtDirectory.AccessibleName")
        Me.txtDirectory.Anchor = CType(resources.GetObject("txtDirectory.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtDirectory.AutoSize = CType(resources.GetObject("txtDirectory.AutoSize"), Boolean)
        Me.txtDirectory.BackgroundImage = CType(resources.GetObject("txtDirectory.BackgroundImage"), System.Drawing.Image)
        Me.txtDirectory.Dock = CType(resources.GetObject("txtDirectory.Dock"), System.Windows.Forms.DockStyle)
        Me.txtDirectory.Enabled = CType(resources.GetObject("txtDirectory.Enabled"), Boolean)
        Me.txtDirectory.Font = CType(resources.GetObject("txtDirectory.Font"), System.Drawing.Font)
        Me.txtDirectory.ImeMode = CType(resources.GetObject("txtDirectory.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtDirectory.Location = CType(resources.GetObject("txtDirectory.Location"), System.Drawing.Point)
        Me.txtDirectory.MaxLength = CType(resources.GetObject("txtDirectory.MaxLength"), Integer)
        Me.txtDirectory.Multiline = CType(resources.GetObject("txtDirectory.Multiline"), Boolean)
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.PasswordChar = CType(resources.GetObject("txtDirectory.PasswordChar"), Char)
        Me.txtDirectory.RightToLeft = CType(resources.GetObject("txtDirectory.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtDirectory.ScrollBars = CType(resources.GetObject("txtDirectory.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtDirectory.Size = CType(resources.GetObject("txtDirectory.Size"), System.Drawing.Size)
        Me.txtDirectory.TabIndex = CType(resources.GetObject("txtDirectory.TabIndex"), Integer)
        Me.txtDirectory.Text = resources.GetString("txtDirectory.Text")
        Me.txtDirectory.TextAlign = CType(resources.GetObject("txtDirectory.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtDirectory.Visible = CType(resources.GetObject("txtDirectory.Visible"), Boolean)
        Me.txtDirectory.WordWrap = CType(resources.GetObject("txtDirectory.WordWrap"), Boolean)
        '
        'btnCreateDirectory
        '
        Me.btnCreateDirectory.AccessibleDescription = resources.GetString("btnCreateDirectory.AccessibleDescription")
        Me.btnCreateDirectory.AccessibleName = resources.GetString("btnCreateDirectory.AccessibleName")
        Me.btnCreateDirectory.Anchor = CType(resources.GetObject("btnCreateDirectory.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCreateDirectory.BackgroundImage = CType(resources.GetObject("btnCreateDirectory.BackgroundImage"), System.Drawing.Image)
        Me.btnCreateDirectory.Dock = CType(resources.GetObject("btnCreateDirectory.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCreateDirectory.Enabled = CType(resources.GetObject("btnCreateDirectory.Enabled"), Boolean)
        Me.btnCreateDirectory.FlatStyle = CType(resources.GetObject("btnCreateDirectory.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCreateDirectory.Font = CType(resources.GetObject("btnCreateDirectory.Font"), System.Drawing.Font)
        Me.btnCreateDirectory.Image = CType(resources.GetObject("btnCreateDirectory.Image"), System.Drawing.Image)
        Me.btnCreateDirectory.ImageAlign = CType(resources.GetObject("btnCreateDirectory.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateDirectory.ImageIndex = CType(resources.GetObject("btnCreateDirectory.ImageIndex"), Integer)
        Me.btnCreateDirectory.ImeMode = CType(resources.GetObject("btnCreateDirectory.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCreateDirectory.Location = CType(resources.GetObject("btnCreateDirectory.Location"), System.Drawing.Point)
        Me.btnCreateDirectory.Name = "btnCreateDirectory"
        Me.btnCreateDirectory.RightToLeft = CType(resources.GetObject("btnCreateDirectory.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCreateDirectory.Size = CType(resources.GetObject("btnCreateDirectory.Size"), System.Drawing.Size)
        Me.btnCreateDirectory.TabIndex = CType(resources.GetObject("btnCreateDirectory.TabIndex"), Integer)
        Me.btnCreateDirectory.Text = resources.GetString("btnCreateDirectory.Text")
        Me.btnCreateDirectory.TextAlign = CType(resources.GetObject("btnCreateDirectory.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCreateDirectory.Visible = CType(resources.GetObject("btnCreateDirectory.Visible"), Boolean)
        '
        'MouseGroupBox
        '
        Me.MouseGroupBox.AccessibleDescription = CType(resources.GetObject("MouseGroupBox.AccessibleDescription"), String)
        Me.MouseGroupBox.AccessibleName = CType(resources.GetObject("MouseGroupBox.AccessibleName"), String)
        Me.MouseGroupBox.Anchor = CType(resources.GetObject("MouseGroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.MouseGroupBox.BackgroundImage = CType(resources.GetObject("MouseGroupBox.BackgroundImage"), System.Drawing.Image)
        Me.MouseGroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnResetMouseButton, Me.btnSwapMouseButton})
        Me.MouseGroupBox.Dock = CType(resources.GetObject("MouseGroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.MouseGroupBox.Enabled = CType(resources.GetObject("MouseGroupBox.Enabled"), Boolean)
        Me.MouseGroupBox.Font = CType(resources.GetObject("MouseGroupBox.Font"), System.Drawing.Font)
        Me.MouseGroupBox.ImeMode = CType(resources.GetObject("MouseGroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.MouseGroupBox.Location = CType(resources.GetObject("MouseGroupBox.Location"), System.Drawing.Point)
        Me.MouseGroupBox.Name = "MouseGroupBox"
        Me.MouseGroupBox.RightToLeft = CType(resources.GetObject("MouseGroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.MouseGroupBox.Size = CType(resources.GetObject("MouseGroupBox.Size"), System.Drawing.Size)
        Me.MouseGroupBox.TabIndex = CType(resources.GetObject("MouseGroupBox.TabIndex"), Integer)
        Me.MouseGroupBox.TabStop = False
        Me.MouseGroupBox.Text = resources.GetString("MouseGroupBox.Text")
        Me.MouseGroupBox.Visible = CType(resources.GetObject("MouseGroupBox.Visible"), Boolean)
        '
        'btnResetMouseButton
        '
        Me.btnResetMouseButton.AccessibleDescription = resources.GetString("btnResetMouseButton.AccessibleDescription")
        Me.btnResetMouseButton.AccessibleName = resources.GetString("btnResetMouseButton.AccessibleName")
        Me.btnResetMouseButton.Anchor = CType(resources.GetObject("btnResetMouseButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnResetMouseButton.BackgroundImage = CType(resources.GetObject("btnResetMouseButton.BackgroundImage"), System.Drawing.Image)
        Me.btnResetMouseButton.Dock = CType(resources.GetObject("btnResetMouseButton.Dock"), System.Windows.Forms.DockStyle)
        Me.btnResetMouseButton.Enabled = CType(resources.GetObject("btnResetMouseButton.Enabled"), Boolean)
        Me.btnResetMouseButton.FlatStyle = CType(resources.GetObject("btnResetMouseButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnResetMouseButton.Font = CType(resources.GetObject("btnResetMouseButton.Font"), System.Drawing.Font)
        Me.btnResetMouseButton.Image = CType(resources.GetObject("btnResetMouseButton.Image"), System.Drawing.Image)
        Me.btnResetMouseButton.ImageAlign = CType(resources.GetObject("btnResetMouseButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnResetMouseButton.ImageIndex = CType(resources.GetObject("btnResetMouseButton.ImageIndex"), Integer)
        Me.btnResetMouseButton.ImeMode = CType(resources.GetObject("btnResetMouseButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnResetMouseButton.Location = CType(resources.GetObject("btnResetMouseButton.Location"), System.Drawing.Point)
        Me.btnResetMouseButton.Name = "btnResetMouseButton"
        Me.btnResetMouseButton.RightToLeft = CType(resources.GetObject("btnResetMouseButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnResetMouseButton.Size = CType(resources.GetObject("btnResetMouseButton.Size"), System.Drawing.Size)
        Me.btnResetMouseButton.TabIndex = CType(resources.GetObject("btnResetMouseButton.TabIndex"), Integer)
        Me.btnResetMouseButton.Text = resources.GetString("btnResetMouseButton.Text")
        Me.btnResetMouseButton.TextAlign = CType(resources.GetObject("btnResetMouseButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnResetMouseButton.Visible = CType(resources.GetObject("btnResetMouseButton.Visible"), Boolean)
        '
        'btnSwapMouseButton
        '
        Me.btnSwapMouseButton.AccessibleDescription = resources.GetString("btnSwapMouseButton.AccessibleDescription")
        Me.btnSwapMouseButton.AccessibleName = resources.GetString("btnSwapMouseButton.AccessibleName")
        Me.btnSwapMouseButton.Anchor = CType(resources.GetObject("btnSwapMouseButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSwapMouseButton.BackgroundImage = CType(resources.GetObject("btnSwapMouseButton.BackgroundImage"), System.Drawing.Image)
        Me.btnSwapMouseButton.Dock = CType(resources.GetObject("btnSwapMouseButton.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSwapMouseButton.Enabled = CType(resources.GetObject("btnSwapMouseButton.Enabled"), Boolean)
        Me.btnSwapMouseButton.FlatStyle = CType(resources.GetObject("btnSwapMouseButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSwapMouseButton.Font = CType(resources.GetObject("btnSwapMouseButton.Font"), System.Drawing.Font)
        Me.btnSwapMouseButton.Image = CType(resources.GetObject("btnSwapMouseButton.Image"), System.Drawing.Image)
        Me.btnSwapMouseButton.ImageAlign = CType(resources.GetObject("btnSwapMouseButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSwapMouseButton.ImageIndex = CType(resources.GetObject("btnSwapMouseButton.ImageIndex"), Integer)
        Me.btnSwapMouseButton.ImeMode = CType(resources.GetObject("btnSwapMouseButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSwapMouseButton.Location = CType(resources.GetObject("btnSwapMouseButton.Location"), System.Drawing.Point)
        Me.btnSwapMouseButton.Name = "btnSwapMouseButton"
        Me.btnSwapMouseButton.RightToLeft = CType(resources.GetObject("btnSwapMouseButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSwapMouseButton.Size = CType(resources.GetObject("btnSwapMouseButton.Size"), System.Drawing.Size)
        Me.btnSwapMouseButton.TabIndex = CType(resources.GetObject("btnSwapMouseButton.TabIndex"), Integer)
        Me.btnSwapMouseButton.Text = resources.GetString("btnSwapMouseButton.Text")
        Me.btnSwapMouseButton.TextAlign = CType(resources.GetObject("btnSwapMouseButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSwapMouseButton.Visible = CType(resources.GetObject("btnSwapMouseButton.Visible"), Boolean)
        '
        'DriveGroupBox
        '
        Me.DriveGroupBox.AccessibleDescription = CType(resources.GetObject("DriveGroupBox.AccessibleDescription"), String)
        Me.DriveGroupBox.AccessibleName = CType(resources.GetObject("DriveGroupBox.AccessibleName"), String)
        Me.DriveGroupBox.Anchor = CType(resources.GetObject("DriveGroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.DriveGroupBox.BackgroundImage = CType(resources.GetObject("DriveGroupBox.BackgroundImage"), System.Drawing.Image)
        Me.DriveGroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.txtDriveLetter, Me.btnGetDriveType, Me.btnGetDiskFreeSpaceEx, Me.btnGetFreeSpace})
        Me.DriveGroupBox.Dock = CType(resources.GetObject("DriveGroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.DriveGroupBox.Enabled = CType(resources.GetObject("DriveGroupBox.Enabled"), Boolean)
        Me.DriveGroupBox.Font = CType(resources.GetObject("DriveGroupBox.Font"), System.Drawing.Font)
        Me.DriveGroupBox.ImeMode = CType(resources.GetObject("DriveGroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.DriveGroupBox.Location = CType(resources.GetObject("DriveGroupBox.Location"), System.Drawing.Point)
        Me.DriveGroupBox.Name = "DriveGroupBox"
        Me.DriveGroupBox.RightToLeft = CType(resources.GetObject("DriveGroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.DriveGroupBox.Size = CType(resources.GetObject("DriveGroupBox.Size"), System.Drawing.Size)
        Me.DriveGroupBox.TabIndex = CType(resources.GetObject("DriveGroupBox.TabIndex"), Integer)
        Me.DriveGroupBox.TabStop = False
        Me.DriveGroupBox.Text = resources.GetString("DriveGroupBox.Text")
        Me.DriveGroupBox.Visible = CType(resources.GetObject("DriveGroupBox.Visible"), Boolean)
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
        'txtDriveLetter
        '
        Me.txtDriveLetter.AccessibleDescription = resources.GetString("txtDriveLetter.AccessibleDescription")
        Me.txtDriveLetter.AccessibleName = resources.GetString("txtDriveLetter.AccessibleName")
        Me.txtDriveLetter.Anchor = CType(resources.GetObject("txtDriveLetter.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtDriveLetter.AutoSize = CType(resources.GetObject("txtDriveLetter.AutoSize"), Boolean)
        Me.txtDriveLetter.BackgroundImage = CType(resources.GetObject("txtDriveLetter.BackgroundImage"), System.Drawing.Image)
        Me.txtDriveLetter.Dock = CType(resources.GetObject("txtDriveLetter.Dock"), System.Windows.Forms.DockStyle)
        Me.txtDriveLetter.Enabled = CType(resources.GetObject("txtDriveLetter.Enabled"), Boolean)
        Me.txtDriveLetter.Font = CType(resources.GetObject("txtDriveLetter.Font"), System.Drawing.Font)
        Me.txtDriveLetter.ImeMode = CType(resources.GetObject("txtDriveLetter.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtDriveLetter.Location = CType(resources.GetObject("txtDriveLetter.Location"), System.Drawing.Point)
        Me.txtDriveLetter.MaxLength = CType(resources.GetObject("txtDriveLetter.MaxLength"), Integer)
        Me.txtDriveLetter.Multiline = CType(resources.GetObject("txtDriveLetter.Multiline"), Boolean)
        Me.txtDriveLetter.Name = "txtDriveLetter"
        Me.txtDriveLetter.PasswordChar = CType(resources.GetObject("txtDriveLetter.PasswordChar"), Char)
        Me.txtDriveLetter.RightToLeft = CType(resources.GetObject("txtDriveLetter.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtDriveLetter.ScrollBars = CType(resources.GetObject("txtDriveLetter.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtDriveLetter.Size = CType(resources.GetObject("txtDriveLetter.Size"), System.Drawing.Size)
        Me.txtDriveLetter.TabIndex = CType(resources.GetObject("txtDriveLetter.TabIndex"), Integer)
        Me.txtDriveLetter.Text = resources.GetString("txtDriveLetter.Text")
        Me.txtDriveLetter.TextAlign = CType(resources.GetObject("txtDriveLetter.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtDriveLetter.Visible = CType(resources.GetObject("txtDriveLetter.Visible"), Boolean)
        Me.txtDriveLetter.WordWrap = CType(resources.GetObject("txtDriveLetter.WordWrap"), Boolean)
        '
        'btnGetDriveType
        '
        Me.btnGetDriveType.AccessibleDescription = resources.GetString("btnGetDriveType.AccessibleDescription")
        Me.btnGetDriveType.AccessibleName = resources.GetString("btnGetDriveType.AccessibleName")
        Me.btnGetDriveType.Anchor = CType(resources.GetObject("btnGetDriveType.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetDriveType.BackgroundImage = CType(resources.GetObject("btnGetDriveType.BackgroundImage"), System.Drawing.Image)
        Me.btnGetDriveType.Dock = CType(resources.GetObject("btnGetDriveType.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetDriveType.Enabled = CType(resources.GetObject("btnGetDriveType.Enabled"), Boolean)
        Me.btnGetDriveType.FlatStyle = CType(resources.GetObject("btnGetDriveType.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetDriveType.Font = CType(resources.GetObject("btnGetDriveType.Font"), System.Drawing.Font)
        Me.btnGetDriveType.Image = CType(resources.GetObject("btnGetDriveType.Image"), System.Drawing.Image)
        Me.btnGetDriveType.ImageAlign = CType(resources.GetObject("btnGetDriveType.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetDriveType.ImageIndex = CType(resources.GetObject("btnGetDriveType.ImageIndex"), Integer)
        Me.btnGetDriveType.ImeMode = CType(resources.GetObject("btnGetDriveType.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetDriveType.Location = CType(resources.GetObject("btnGetDriveType.Location"), System.Drawing.Point)
        Me.btnGetDriveType.Name = "btnGetDriveType"
        Me.btnGetDriveType.RightToLeft = CType(resources.GetObject("btnGetDriveType.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetDriveType.Size = CType(resources.GetObject("btnGetDriveType.Size"), System.Drawing.Size)
        Me.btnGetDriveType.TabIndex = CType(resources.GetObject("btnGetDriveType.TabIndex"), Integer)
        Me.btnGetDriveType.Text = resources.GetString("btnGetDriveType.Text")
        Me.btnGetDriveType.TextAlign = CType(resources.GetObject("btnGetDriveType.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetDriveType.Visible = CType(resources.GetObject("btnGetDriveType.Visible"), Boolean)
        '
        'btnGetDiskFreeSpaceEx
        '
        Me.btnGetDiskFreeSpaceEx.AccessibleDescription = resources.GetString("btnGetDiskFreeSpaceEx.AccessibleDescription")
        Me.btnGetDiskFreeSpaceEx.AccessibleName = resources.GetString("btnGetDiskFreeSpaceEx.AccessibleName")
        Me.btnGetDiskFreeSpaceEx.Anchor = CType(resources.GetObject("btnGetDiskFreeSpaceEx.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetDiskFreeSpaceEx.BackgroundImage = CType(resources.GetObject("btnGetDiskFreeSpaceEx.BackgroundImage"), System.Drawing.Image)
        Me.btnGetDiskFreeSpaceEx.Dock = CType(resources.GetObject("btnGetDiskFreeSpaceEx.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetDiskFreeSpaceEx.Enabled = CType(resources.GetObject("btnGetDiskFreeSpaceEx.Enabled"), Boolean)
        Me.btnGetDiskFreeSpaceEx.FlatStyle = CType(resources.GetObject("btnGetDiskFreeSpaceEx.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetDiskFreeSpaceEx.Font = CType(resources.GetObject("btnGetDiskFreeSpaceEx.Font"), System.Drawing.Font)
        Me.btnGetDiskFreeSpaceEx.Image = CType(resources.GetObject("btnGetDiskFreeSpaceEx.Image"), System.Drawing.Image)
        Me.btnGetDiskFreeSpaceEx.ImageAlign = CType(resources.GetObject("btnGetDiskFreeSpaceEx.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetDiskFreeSpaceEx.ImageIndex = CType(resources.GetObject("btnGetDiskFreeSpaceEx.ImageIndex"), Integer)
        Me.btnGetDiskFreeSpaceEx.ImeMode = CType(resources.GetObject("btnGetDiskFreeSpaceEx.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetDiskFreeSpaceEx.Location = CType(resources.GetObject("btnGetDiskFreeSpaceEx.Location"), System.Drawing.Point)
        Me.btnGetDiskFreeSpaceEx.Name = "btnGetDiskFreeSpaceEx"
        Me.btnGetDiskFreeSpaceEx.RightToLeft = CType(resources.GetObject("btnGetDiskFreeSpaceEx.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetDiskFreeSpaceEx.Size = CType(resources.GetObject("btnGetDiskFreeSpaceEx.Size"), System.Drawing.Size)
        Me.btnGetDiskFreeSpaceEx.TabIndex = CType(resources.GetObject("btnGetDiskFreeSpaceEx.TabIndex"), Integer)
        Me.btnGetDiskFreeSpaceEx.Text = resources.GetString("btnGetDiskFreeSpaceEx.Text")
        Me.btnGetDiskFreeSpaceEx.TextAlign = CType(resources.GetObject("btnGetDiskFreeSpaceEx.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetDiskFreeSpaceEx.Visible = CType(resources.GetObject("btnGetDiskFreeSpaceEx.Visible"), Boolean)
        '
        'btnGetFreeSpace
        '
        Me.btnGetFreeSpace.AccessibleDescription = resources.GetString("btnGetFreeSpace.AccessibleDescription")
        Me.btnGetFreeSpace.AccessibleName = resources.GetString("btnGetFreeSpace.AccessibleName")
        Me.btnGetFreeSpace.Anchor = CType(resources.GetObject("btnGetFreeSpace.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetFreeSpace.BackgroundImage = CType(resources.GetObject("btnGetFreeSpace.BackgroundImage"), System.Drawing.Image)
        Me.btnGetFreeSpace.Dock = CType(resources.GetObject("btnGetFreeSpace.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetFreeSpace.Enabled = CType(resources.GetObject("btnGetFreeSpace.Enabled"), Boolean)
        Me.btnGetFreeSpace.FlatStyle = CType(resources.GetObject("btnGetFreeSpace.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetFreeSpace.Font = CType(resources.GetObject("btnGetFreeSpace.Font"), System.Drawing.Font)
        Me.btnGetFreeSpace.Image = CType(resources.GetObject("btnGetFreeSpace.Image"), System.Drawing.Image)
        Me.btnGetFreeSpace.ImageAlign = CType(resources.GetObject("btnGetFreeSpace.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetFreeSpace.ImageIndex = CType(resources.GetObject("btnGetFreeSpace.ImageIndex"), Integer)
        Me.btnGetFreeSpace.ImeMode = CType(resources.GetObject("btnGetFreeSpace.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetFreeSpace.Location = CType(resources.GetObject("btnGetFreeSpace.Location"), System.Drawing.Point)
        Me.btnGetFreeSpace.Name = "btnGetFreeSpace"
        Me.btnGetFreeSpace.RightToLeft = CType(resources.GetObject("btnGetFreeSpace.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetFreeSpace.Size = CType(resources.GetObject("btnGetFreeSpace.Size"), System.Drawing.Size)
        Me.btnGetFreeSpace.TabIndex = CType(resources.GetObject("btnGetFreeSpace.TabIndex"), Integer)
        Me.btnGetFreeSpace.Text = resources.GetString("btnGetFreeSpace.Text")
        Me.btnGetFreeSpace.TextAlign = CType(resources.GetObject("btnGetFreeSpace.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetFreeSpace.Visible = CType(resources.GetObject("btnGetFreeSpace.Visible"), Boolean)
        '
        'txtFunctionOutput
        '
        Me.txtFunctionOutput.AccessibleDescription = resources.GetString("txtFunctionOutput.AccessibleDescription")
        Me.txtFunctionOutput.AccessibleName = resources.GetString("txtFunctionOutput.AccessibleName")
        Me.txtFunctionOutput.Anchor = CType(resources.GetObject("txtFunctionOutput.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtFunctionOutput.AutoSize = CType(resources.GetObject("txtFunctionOutput.AutoSize"), Boolean)
        Me.txtFunctionOutput.BackgroundImage = CType(resources.GetObject("txtFunctionOutput.BackgroundImage"), System.Drawing.Image)
        Me.txtFunctionOutput.Dock = CType(resources.GetObject("txtFunctionOutput.Dock"), System.Windows.Forms.DockStyle)
        Me.txtFunctionOutput.Enabled = CType(resources.GetObject("txtFunctionOutput.Enabled"), Boolean)
        Me.txtFunctionOutput.Font = CType(resources.GetObject("txtFunctionOutput.Font"), System.Drawing.Font)
        Me.txtFunctionOutput.ImeMode = CType(resources.GetObject("txtFunctionOutput.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtFunctionOutput.Location = CType(resources.GetObject("txtFunctionOutput.Location"), System.Drawing.Point)
        Me.txtFunctionOutput.MaxLength = CType(resources.GetObject("txtFunctionOutput.MaxLength"), Integer)
        Me.txtFunctionOutput.Multiline = CType(resources.GetObject("txtFunctionOutput.Multiline"), Boolean)
        Me.txtFunctionOutput.Name = "txtFunctionOutput"
        Me.txtFunctionOutput.PasswordChar = CType(resources.GetObject("txtFunctionOutput.PasswordChar"), Char)
        Me.txtFunctionOutput.RightToLeft = CType(resources.GetObject("txtFunctionOutput.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtFunctionOutput.ScrollBars = CType(resources.GetObject("txtFunctionOutput.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtFunctionOutput.Size = CType(resources.GetObject("txtFunctionOutput.Size"), System.Drawing.Size)
        Me.txtFunctionOutput.TabIndex = CType(resources.GetObject("txtFunctionOutput.TabIndex"), Integer)
        Me.txtFunctionOutput.Text = resources.GetString("txtFunctionOutput.Text")
        Me.txtFunctionOutput.TextAlign = CType(resources.GetObject("txtFunctionOutput.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtFunctionOutput.Visible = CType(resources.GetObject("txtFunctionOutput.Visible"), Boolean)
        Me.txtFunctionOutput.WordWrap = CType(resources.GetObject("txtFunctionOutput.WordWrap"), Boolean)
        '
        'MiscGroupBox
        '
        Me.MiscGroupBox.AccessibleDescription = CType(resources.GetObject("MiscGroupBox.AccessibleDescription"), String)
        Me.MiscGroupBox.AccessibleName = CType(resources.GetObject("MiscGroupBox.AccessibleName"), String)
        Me.MiscGroupBox.Anchor = CType(resources.GetObject("MiscGroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.MiscGroupBox.BackgroundImage = CType(resources.GetObject("MiscGroupBox.BackgroundImage"), System.Drawing.Image)
        Me.MiscGroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnHibernate, Me.btnGetOSVersion})
        Me.MiscGroupBox.Dock = CType(resources.GetObject("MiscGroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.MiscGroupBox.Enabled = CType(resources.GetObject("MiscGroupBox.Enabled"), Boolean)
        Me.MiscGroupBox.Font = CType(resources.GetObject("MiscGroupBox.Font"), System.Drawing.Font)
        Me.MiscGroupBox.ImeMode = CType(resources.GetObject("MiscGroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.MiscGroupBox.Location = CType(resources.GetObject("MiscGroupBox.Location"), System.Drawing.Point)
        Me.MiscGroupBox.Name = "MiscGroupBox"
        Me.MiscGroupBox.RightToLeft = CType(resources.GetObject("MiscGroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.MiscGroupBox.Size = CType(resources.GetObject("MiscGroupBox.Size"), System.Drawing.Size)
        Me.MiscGroupBox.TabIndex = CType(resources.GetObject("MiscGroupBox.TabIndex"), Integer)
        Me.MiscGroupBox.TabStop = False
        Me.MiscGroupBox.Text = resources.GetString("MiscGroupBox.Text")
        Me.MiscGroupBox.Visible = CType(resources.GetObject("MiscGroupBox.Visible"), Boolean)
        '
        'btnHibernate
        '
        Me.btnHibernate.AccessibleDescription = resources.GetString("btnHibernate.AccessibleDescription")
        Me.btnHibernate.AccessibleName = resources.GetString("btnHibernate.AccessibleName")
        Me.btnHibernate.Anchor = CType(resources.GetObject("btnHibernate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnHibernate.BackgroundImage = CType(resources.GetObject("btnHibernate.BackgroundImage"), System.Drawing.Image)
        Me.btnHibernate.Dock = CType(resources.GetObject("btnHibernate.Dock"), System.Windows.Forms.DockStyle)
        Me.btnHibernate.Enabled = CType(resources.GetObject("btnHibernate.Enabled"), Boolean)
        Me.btnHibernate.FlatStyle = CType(resources.GetObject("btnHibernate.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnHibernate.Font = CType(resources.GetObject("btnHibernate.Font"), System.Drawing.Font)
        Me.btnHibernate.Image = CType(resources.GetObject("btnHibernate.Image"), System.Drawing.Image)
        Me.btnHibernate.ImageAlign = CType(resources.GetObject("btnHibernate.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnHibernate.ImageIndex = CType(resources.GetObject("btnHibernate.ImageIndex"), Integer)
        Me.btnHibernate.ImeMode = CType(resources.GetObject("btnHibernate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnHibernate.Location = CType(resources.GetObject("btnHibernate.Location"), System.Drawing.Point)
        Me.btnHibernate.Name = "btnHibernate"
        Me.btnHibernate.RightToLeft = CType(resources.GetObject("btnHibernate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnHibernate.Size = CType(resources.GetObject("btnHibernate.Size"), System.Drawing.Size)
        Me.btnHibernate.TabIndex = CType(resources.GetObject("btnHibernate.TabIndex"), Integer)
        Me.btnHibernate.Text = resources.GetString("btnHibernate.Text")
        Me.btnHibernate.TextAlign = CType(resources.GetObject("btnHibernate.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnHibernate.Visible = CType(resources.GetObject("btnHibernate.Visible"), Boolean)
        '
        'btnGetOSVersion
        '
        Me.btnGetOSVersion.AccessibleDescription = resources.GetString("btnGetOSVersion.AccessibleDescription")
        Me.btnGetOSVersion.AccessibleName = resources.GetString("btnGetOSVersion.AccessibleName")
        Me.btnGetOSVersion.Anchor = CType(resources.GetObject("btnGetOSVersion.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnGetOSVersion.BackgroundImage = CType(resources.GetObject("btnGetOSVersion.BackgroundImage"), System.Drawing.Image)
        Me.btnGetOSVersion.Dock = CType(resources.GetObject("btnGetOSVersion.Dock"), System.Windows.Forms.DockStyle)
        Me.btnGetOSVersion.Enabled = CType(resources.GetObject("btnGetOSVersion.Enabled"), Boolean)
        Me.btnGetOSVersion.FlatStyle = CType(resources.GetObject("btnGetOSVersion.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnGetOSVersion.Font = CType(resources.GetObject("btnGetOSVersion.Font"), System.Drawing.Font)
        Me.btnGetOSVersion.Image = CType(resources.GetObject("btnGetOSVersion.Image"), System.Drawing.Image)
        Me.btnGetOSVersion.ImageAlign = CType(resources.GetObject("btnGetOSVersion.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnGetOSVersion.ImageIndex = CType(resources.GetObject("btnGetOSVersion.ImageIndex"), Integer)
        Me.btnGetOSVersion.ImeMode = CType(resources.GetObject("btnGetOSVersion.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnGetOSVersion.Location = CType(resources.GetObject("btnGetOSVersion.Location"), System.Drawing.Point)
        Me.btnGetOSVersion.Name = "btnGetOSVersion"
        Me.btnGetOSVersion.RightToLeft = CType(resources.GetObject("btnGetOSVersion.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnGetOSVersion.Size = CType(resources.GetObject("btnGetOSVersion.Size"), System.Drawing.Size)
        Me.btnGetOSVersion.TabIndex = CType(resources.GetObject("btnGetOSVersion.TabIndex"), Integer)
        Me.btnGetOSVersion.Text = resources.GetString("btnGetOSVersion.Text")
        Me.btnGetOSVersion.TextAlign = CType(resources.GetObject("btnGetOSVersion.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnGetOSVersion.Visible = CType(resources.GetObject("btnGetOSVersion.Visible"), Boolean)
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
        Me.tpActiveProcesses.ResumeLayout(False)
        Me.tpActiveWindows.ResumeLayout(False)
        Me.tpShowWindow.ResumeLayout(False)
        Me.tpAPICalls.ResumeLayout(False)
        Me.CallingVariationGroupBox.ResumeLayout(False)
        Me.DirectoryGroupBox.ResumeLayout(False)
        Me.MouseGroupBox.ResumeLayout(False)
        Me.DriveGroupBox.ResumeLayout(False)
        Me.MiscGroupBox.ResumeLayout(False)
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

#Region "API Calls"
    ' This demonstrates the different calling variations using the function Beep.  Check
    ' The declarations in class CallingVariations.
    Private Sub btnBeep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeep.Click
        If rbDeclare.Checked Then
            CallingVariations.DeclareBeep(1000, 1000)
        ElseIf rbDLLImport.Checked Then
            CallingVariations.DLLImportBeep(1000, 1000)
        ElseIf rbANSI.Checked Then
            CallingVariations.ANSIBeep(1000, 1000)
        ElseIf rbUnicode.Checked Then
            CallingVariations.UnicodeBeep(1000, 1000)
        ElseIf rbAuto.Checked Then
            CallingVariations.AutoBeep(1000, 1000)
        End If
    End Sub

    ' This creates a directory if possible, and updates the status in the function 
    ' output text box.
    Private Sub btnCreateDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDirectory.Click
        Dim security As New Win32API.SECURITY_ATTRIBUTES()
        If Win32API.CreateDirectory(txtDirectory.Text, security) Then
            txtFunctionOutput.Text = "Directory created."
        Else
            txtFunctionOutput.Text = "Directory not created."
        End If
    End Sub

    ' This gets the number of free clusters on a disk, by Win32 API call GetDiskFreeSpace
    ' and updates the function output textbox.
    Private Sub btnGetFreeSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetFreeSpace.Click
        Dim rootPathName As String
        Dim sectorsPerCluster As Integer
        Dim bytesPerSector As Integer
        Dim numberOfFreeClusters As Integer
        Dim totalNumberOfClusters As Integer

        rootPathName = txtDriveLetter.Text + ":\"

        Win32API.GetDiskFreeSpace(rootPathName, sectorsPerCluster, bytesPerSector, _
            numberOfFreeClusters, totalNumberOfClusters)

        txtFunctionOutput.Text = "Number of Free Clusters: " & _
            numberOfFreeClusters.ToString()
    End Sub

    ' This gets the number of free bytes on a disk, by Win32 API call GetDiskFreeSpaceEx
    ' and updates the function output textbox.
    Private Sub btnGetDiskFreeSpaceEx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDiskFreeSpaceEx.Click
        Dim rootPathName As String
        Dim freeBytesToCaller As Integer
        Dim totalNumberOfBytes As Integer
        Dim totalNumberOfFreeBytes As UInt32

        rootPathName = txtDriveLetter.Text + ":\"

        Win32API.GetDiskFreeSpaceEx(rootPathName, freeBytesToCaller, totalNumberOfBytes, _
            totalNumberOfFreeBytes)

        txtFunctionOutput.Text = "Number of Free Bytes: " & _
            totalNumberOfFreeBytes.ToString()
    End Sub

    ' This shows the drive type by Win32 API call GetDriveTypeand updates the function
    ' output textbox.
    Private Sub btnGetDriveType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDriveType.Click
        Dim rootPathName As String
        rootPathName = txtDriveLetter.Text + ":\"

        Select Case Win32API.GetDriveType(rootPathName)
            Case 2
                txtFunctionOutput.Text = "Drive type: Removable"
            Case 3
                txtFunctionOutput.Text = "Drive type: Fixed"
            Case Is = 4
                txtFunctionOutput.Text = "Drive type: Remote"
            Case Is = 5
                txtFunctionOutput.Text = "Drive type: Cd-Rom"
            Case Is = 6
                txtFunctionOutput.Text = "Drive type: Ram disk"
            Case Else
                txtFunctionOutput.Text = "Drive type: Unrecognized"
        End Select
    End Sub

    ' This gets the Operating system version and updates the function output text box. 
    Private Sub btnGetOSVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetOSVersion.Click
        Dim versionInfo As New Win32API.OSVersionInfo()

        'This is being passed into the struct so it knows the size
        versionInfo.OSVersionInfoSize = Marshal.SizeOf(versionInfo)
        Win32API.GetVersionEx(versionInfo)

        txtFunctionOutput.Text = "Build Number is: " & versionInfo.buildNumber.ToString() & Chr(13) & Chr(10)
        txtFunctionOutput.Text += "Major Version Number is: " & versionInfo.majorVersion.ToString()
    End Sub

    ' This suspends the computer if it is possible.
    Private Sub btnHibernate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHibernate.Click
        If Win32API.IsPwrHibernateAllowed() <> 0 Then
            Win32API.SetSuspendState(1, 0, 0)
        Else
            txtFunctionOutput.Text = "Your computer doesn't support hibernation.  " & _
                "This may be due to system settings or simply a computer bios that does not support hibernation."
        End If
    End Sub


    ' Sets the mouse buttons as they should be.
    Private Sub btnResetMouseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMouseButton.Click
        Win32API.SwapMouseButton(0)
    End Sub

    ' Swaps the mouse buttons.
    Private Sub btnSwapMouseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSwapMouseButton.Click
        Win32API.SwapMouseButton(1)
    End Sub
#End Region

    '  This subroutine clears the process list view and fills it with all active processes.
    Private Sub btnRefreshActiveProcesses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshActiveProcesses.Click
        lvwProcessList.Items.Clear()

        ' Call WinAPI function EnumWindows, specifying FillActiveProcessList function as
        ' the function to be called once per active process.  Since EnumWindows is 
        ' unmanaged code, it is necessary to create a delegate to allow it to call 
        ' FillActiveProcessList which is managed code.
        Win32API.EnumWindows(New Win32API.EnumWindowsCallback(AddressOf _
            FillActiveProcessList), 0)
    End Sub

    ' This subroutine clears the active windows list and fills it with all active windows.
    Private Sub btnRefreshActiveWindows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshActiveWindows.Click
        lbActiveWindows.Items.Clear()

        ' EnumWindowDllImport works the same as in btnRefreshActiveProcesses_Click, 
        ' however, it is defined using DllImport instead of Declare.
        Win32API.EnumWindowsDllImport(New Win32API.EnumWindowsCallback(AddressOf _
            FillActiveWindowsList), 0)
    End Sub


    ' This Sub finds an active window based on the values in the window caption and class 
    ' name text boxes, and brings it to the foreground.
    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim hWnd As Integer

        ' There are four overloads for the Win32API function FindWindow in the Win32API 
        ' class, allowing either a String or an Integer to be passed to the class name 
        ' and window name.  If either of the fields are blank, passing a 0 to the 
        ' parameter marshalls NULL to the function call.
        If txtWindowCaption.Text = "" And txtClassName.Text = "" Then
            ' FindWindowAny takes to Integer parameters and finds any available window.
            hWnd = Win32API.FindWindowAny(0, 0)
        ElseIf txtWindowCaption.Text = "" And txtClassName.Text <> "" Then
            ' FindWindowNullWindowCaption attempts to locate a window by class name alone.
            hWnd = Win32API.FindWindowNullWindowCaption(txtClassName.Text, 0)
        ElseIf txtWindowCaption.Text <> "" And txtClassName.Text = "" Then
            ' FindWindowNullClassName attempts to locate a window by window name alone. 
            hWnd = Win32API.FindWindowNullClassName(0, txtWindowCaption.Text)
        Else
            ' FindWindow searches for a window by class name and window name.
            hWnd = Win32API.FindWindow(txtClassName.Text, txtWindowCaption.Text)
        End If

        ' If the window isn't found FindWindow sets the windows handle to 0.  If the 
        ' handle is 0 display an error message, otherwise bring window to foreground.
        If hWnd = 0 Then
            MsgBox("Specified window is not running.", MsgBoxStyle.Exclamation, Me.Text)
        Else
            ' Set the window as foreground.
            Win32API.SetForegroundWindow(hWnd)

            ' If window is minimized, simply restore, otherwise show it.  Notice the 
            ' declaration of Win32API.IsIconic defines the return value as Boolean
            ' allowing .NET to marshall the integer value to a Boolean.
            If Win32API.IsIconic(hWnd) Then
                Win32API.ShowWindow(hWnd, Win32API.SW_RESTORE)
            Else
                Win32API.ShowWindow(hWnd, Win32API.SW_SHOW)
            End If
        End If
    End Sub


    ' This Sub checks the window caption and class name text boxes and updates 
    ' lblFunctionCalled label accordingly.  
    Private Sub ChangeFunctionCalledLabel()
        If txtWindowCaption.Text = "" And txtClassName.Text = "" Then
            lblFunctionCalled.Text = _
                "FindWindow (ClassName As Integer, WindowName As Integer) will be called."
        ElseIf txtWindowCaption.Text = "" And txtClassName.Text <> "" Then
            lblFunctionCalled.Text = _
                "FindWindow (ClassName As String, WindowName As Integer) will be called."
        ElseIf txtWindowCaption.Text <> "" And txtClassName.Text = "" Then
            lblFunctionCalled.Text = _
                "FindWindow (ClassName As Integer, WindowName As String) will be called."
        Else
            lblFunctionCalled.Text = _
                "FindWindow (ClassName As String, WindowName As String) will be called."
        End If
    End Sub

    ' This function is called once for each active process by EnumWindows.  It gets the
    ' Window caption and class name and updates the process item listview.
    Function FillActiveProcessList(ByVal hWnd As Integer, ByVal lParam As Integer) As Boolean
        Dim windowText As New StringBuilder(STRING_BUFFER_LENGTH)
        Dim className As New StringBuilder(STRING_BUFFER_LENGTH)

        ' Get the Window Caption and Class Name.  Notice that the definition of Win32API
        ' functions in the Win32API class are declared differently than in VB6.  All Longs
        ' have been replaced with Integers, and Strings by StringBuilders.
        Win32API.GetWindowText(hWnd, windowText, STRING_BUFFER_LENGTH)
        Win32API.GetClassName(hWnd, className, STRING_BUFFER_LENGTH)

        ' Add a new process item to the Processes list view.
        Dim processItem As New ListViewItem(windowText.ToString, 0)
        processItem.SubItems.Add(className.ToString)
        processItem.SubItems.Add(hWnd.ToString)
        lvwProcessList.Items.Add(processItem)

        Return True
    End Function

    ' This function is called once for each active process by EnumWindows.  
    ' It calls ProcessIsActiveWindow to verify that it is a valid window, and
    ' updates the active window listbox.
    Function FillActiveWindowsList(ByVal hWnd As Integer, ByVal lParam As Integer) As Boolean
        Dim windowText As New StringBuilder(STRING_BUFFER_LENGTH)

        ' Get the Window Caption.
        Win32API.GetWindowText(hWnd, windowText, STRING_BUFFER_LENGTH)

        ' Only add valid windows to the active windows listbox.
        If ProcessIsActiveWindow(hWnd) Then
            lbActiveWindows.Items.Add(windowText)
        End If

        Return True
    End Function

    ' This function calls various Win32API functions to determine if a windows process
    ' is a valid active window..
    Function ProcessIsActiveWindow(ByVal hWnd As Integer) As Boolean
        Dim windowText As New StringBuilder(STRING_BUFFER_LENGTH)
        Dim windowIsOwned As Boolean
        Dim windowStyle As Integer

        ' Get the windows caption, owner information, and window style.
        Win32API.GetWindowText(hWnd, windowText, STRING_BUFFER_LENGTH)
        windowIsOwned = Win32API.GetWindow(hWnd, Win32API.GW_OWNER) <> 0
        windowStyle = Win32API.GetWindowLong(hWnd, Win32API.GWL_EXSTYLE)

        ' Do not allow invisible processes.  
        If Not Win32API.IsWindowVisible(hWnd) Then
            Return False
        End If

        ' Window must have a caption
        If windowText.ToString.Equals("") Then
            Return False
        End If

        ' Should not have a parent
        If Win32API.GetParent(hWnd) <> 0 Then
            Return False
        End If

        ' Don't allow unowned tool tips
        If (windowStyle And Win32API.WS_EX_TOOLWINDOW) <> 0 And Not windowIsOwned Then
            Return False
        End If

        ' Don't allow applications with owners
        If (windowStyle And Win32API.WS_EX_APPWINDOW) = 0 And windowIsOwned Then
            Return False
        End If

        ' All criteria were met, window is a valid active window.
        Return True
    End Function

    ' When txtClassName changes, update the lblFunctionCalled label to show which 
    ' function will be called.
    Private Sub txtClassName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClassName.TextChanged
        ChangeFunctionCalledLabel()
    End Sub

    ' When txtWindowCaption changes, update the lblFunctionCalled label to show which 
    ' function will be called.
    Private Sub txtWindowCaption_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWindowCaption.TextChanged
        ChangeFunctionCalledLabel()
    End Sub
End Class

