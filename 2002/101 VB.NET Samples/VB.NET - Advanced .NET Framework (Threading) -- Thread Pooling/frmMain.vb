'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private autoResetEvent1 As Threading.AutoResetEvent
    Private manualResetEvent1 As Threading.ManualResetEvent
    Private mutex1 As Threading.Mutex

    Private processGroup1 As ProcessGroup
    Private processGroup2 As ProcessGroup
    Private processGroup3 As ProcessGroup

    Private timerGroup1 As TimerGroup
    Private timerGroup2 As TimerGroup


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
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents Process1GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents btnNonthreaded As System.Windows.Forms.Button
    Friend WithEvents lblProcess1Active As System.Windows.Forms.Label
    Friend WithEvents Process2GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents lblProcess2Active As System.Windows.Forms.Label
    Friend WithEvents Process3GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents lblProcess3Active As System.Windows.Forms.Label
    Friend WithEvents lblThreadNumber As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblProcess1ThreadNum As System.Windows.Forms.Label
    Friend WithEvents lblProcess2ThreadNum As System.Windows.Forms.Label
    Friend WithEvents lblProcess3ThreadNum As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblProcess1IsPoolThread As System.Windows.Forms.Label
    Friend WithEvents lblProcess2IsPoolThread As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblProcess3IsPoolThread As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnThreaded As System.Windows.Forms.Button
    Friend WithEvents btnThreadPool As System.Windows.Forms.Button
    Friend WithEvents FunctionTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkHighIntensity As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSecondsElapsed As System.Windows.Forms.Label
    Friend WithEvents TimersTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Timer1GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents lblTimer1IsThreadPool As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTimer1ThreadNum As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTimer1Output As System.Windows.Forms.Label
    Friend WithEvents Timer2GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTimer2ThreadNum As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblTimer2Output As System.Windows.Forms.Label
    Friend WithEvents lblTimer2IsThreadPool As System.Windows.Forms.Label
    Friend WithEvents btnStartStop As System.Windows.Forms.Button
    Friend WithEvents SyncObjectsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents MutexGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblMutexThreadNum As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblMutexThreadStatus As System.Windows.Forms.Label
    Friend WithEvents ManualEventGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents AutoEventGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnWaitForMutex As System.Windows.Forms.Button
    Friend WithEvents btnReleaseMutex As System.Windows.Forms.Button
    Friend WithEvents lblMutexIsPoolThread As System.Windows.Forms.Label
    Friend WithEvents lblManualEventIsPoolThread As System.Windows.Forms.Label
    Friend WithEvents lblManualEventThreadNum As System.Windows.Forms.Label
    Friend WithEvents lblManualEventThreadStatus As System.Windows.Forms.Label
    Friend WithEvents btnWaitForManualEvent As System.Windows.Forms.Button
    Friend WithEvents btnSetManualEvent As System.Windows.Forms.Button
    Friend WithEvents lblAutoEventIsPoolThread As System.Windows.Forms.Label
    Friend WithEvents lblAutoEventThreadNum As System.Windows.Forms.Label
    Friend WithEvents lblAutoEventStatus As System.Windows.Forms.Label
    Friend WithEvents btnWaitForAutoEvent As System.Windows.Forms.Button
    Friend WithEvents btnSetAutoEvent As System.Windows.Forms.Button
    Friend WithEvents btnSetReleaseAll As System.Windows.Forms.Button
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents lblInstructions2 As System.Windows.Forms.Label
    Friend WithEvents lblInstructions3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.FunctionTabPage = New System.Windows.Forms.TabPage()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkHighIntensity = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnThreadPool = New System.Windows.Forms.Button()
        Me.btnThreaded = New System.Windows.Forms.Button()
        Me.lblSecondsElapsed = New System.Windows.Forms.Label()
        Me.Process3GroupBox = New System.Windows.Forms.GroupBox()
        Me.lblProcess3IsPoolThread = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblProcess3ThreadNum = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblProcess3Active = New System.Windows.Forms.Label()
        Me.Process2GroupBox = New System.Windows.Forms.GroupBox()
        Me.lblProcess2IsPoolThread = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblProcess2ThreadNum = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblProcess2Active = New System.Windows.Forms.Label()
        Me.btnNonthreaded = New System.Windows.Forms.Button()
        Me.Process1GroupBox = New System.Windows.Forms.GroupBox()
        Me.lblProcess1IsPoolThread = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblProcess1ThreadNum = New System.Windows.Forms.Label()
        Me.lblThreadNumber = New System.Windows.Forms.Label()
        Me.lblProcess1Active = New System.Windows.Forms.Label()
        Me.TimersTabPage = New System.Windows.Forms.TabPage()
        Me.lblInstructions2 = New System.Windows.Forms.Label()
        Me.btnStartStop = New System.Windows.Forms.Button()
        Me.Timer2GroupBox = New System.Windows.Forms.GroupBox()
        Me.lblTimer2IsThreadPool = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTimer2ThreadNum = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblTimer2Output = New System.Windows.Forms.Label()
        Me.Timer1GroupBox = New System.Windows.Forms.GroupBox()
        Me.lblTimer1IsThreadPool = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTimer1ThreadNum = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblTimer1Output = New System.Windows.Forms.Label()
        Me.SyncObjectsTabPage = New System.Windows.Forms.TabPage()
        Me.lblInstructions3 = New System.Windows.Forms.Label()
        Me.btnSetReleaseAll = New System.Windows.Forms.Button()
        Me.btnSetAutoEvent = New System.Windows.Forms.Button()
        Me.btnWaitForAutoEvent = New System.Windows.Forms.Button()
        Me.btnSetManualEvent = New System.Windows.Forms.Button()
        Me.btnWaitForManualEvent = New System.Windows.Forms.Button()
        Me.btnReleaseMutex = New System.Windows.Forms.Button()
        Me.btnWaitForMutex = New System.Windows.Forms.Button()
        Me.AutoEventGroupBox = New System.Windows.Forms.GroupBox()
        Me.lblAutoEventIsPoolThread = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblAutoEventThreadNum = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblAutoEventStatus = New System.Windows.Forms.Label()
        Me.ManualEventGroupBox = New System.Windows.Forms.GroupBox()
        Me.lblManualEventIsPoolThread = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblManualEventThreadNum = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblManualEventThreadStatus = New System.Windows.Forms.Label()
        Me.MutexGroupBox = New System.Windows.Forms.GroupBox()
        Me.lblMutexIsPoolThread = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblMutexThreadNum = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblMutexThreadStatus = New System.Windows.Forms.Label()
        Me.MainTabControl.SuspendLayout()
        Me.FunctionTabPage.SuspendLayout()
        Me.Process3GroupBox.SuspendLayout()
        Me.Process2GroupBox.SuspendLayout()
        Me.Process1GroupBox.SuspendLayout()
        Me.TimersTabPage.SuspendLayout()
        Me.Timer2GroupBox.SuspendLayout()
        Me.Timer1GroupBox.SuspendLayout()
        Me.SyncObjectsTabPage.SuspendLayout()
        Me.AutoEventGroupBox.SuspendLayout()
        Me.ManualEventGroupBox.SuspendLayout()
        Me.MutexGroupBox.SuspendLayout()
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
        Me.MainTabControl.Controls.AddRange(New System.Windows.Forms.Control() {Me.FunctionTabPage, Me.TimersTabPage, Me.SyncObjectsTabPage})
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
        'FunctionTabPage
        '
        Me.FunctionTabPage.AccessibleDescription = resources.GetString("FunctionTabPage.AccessibleDescription")
        Me.FunctionTabPage.AccessibleName = resources.GetString("FunctionTabPage.AccessibleName")
        Me.FunctionTabPage.Anchor = CType(resources.GetObject("FunctionTabPage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.FunctionTabPage.AutoScroll = CType(resources.GetObject("FunctionTabPage.AutoScroll"), Boolean)
        Me.FunctionTabPage.AutoScrollMargin = CType(resources.GetObject("FunctionTabPage.AutoScrollMargin"), System.Drawing.Size)
        Me.FunctionTabPage.AutoScrollMinSize = CType(resources.GetObject("FunctionTabPage.AutoScrollMinSize"), System.Drawing.Size)
        Me.FunctionTabPage.BackgroundImage = CType(resources.GetObject("FunctionTabPage.BackgroundImage"), System.Drawing.Image)
        Me.FunctionTabPage.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInstructions, Me.Label8, Me.chkHighIntensity, Me.Label6, Me.btnThreadPool, Me.btnThreaded, Me.lblSecondsElapsed, Me.Process3GroupBox, Me.Process2GroupBox, Me.btnNonthreaded, Me.Process1GroupBox})
        Me.FunctionTabPage.Dock = CType(resources.GetObject("FunctionTabPage.Dock"), System.Windows.Forms.DockStyle)
        Me.FunctionTabPage.Enabled = CType(resources.GetObject("FunctionTabPage.Enabled"), Boolean)
        Me.FunctionTabPage.Font = CType(resources.GetObject("FunctionTabPage.Font"), System.Drawing.Font)
        Me.FunctionTabPage.ImageIndex = CType(resources.GetObject("FunctionTabPage.ImageIndex"), Integer)
        Me.FunctionTabPage.ImeMode = CType(resources.GetObject("FunctionTabPage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.FunctionTabPage.Location = CType(resources.GetObject("FunctionTabPage.Location"), System.Drawing.Point)
        Me.FunctionTabPage.Name = "FunctionTabPage"
        Me.FunctionTabPage.RightToLeft = CType(resources.GetObject("FunctionTabPage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.FunctionTabPage.Size = CType(resources.GetObject("FunctionTabPage.Size"), System.Drawing.Size)
        Me.FunctionTabPage.TabIndex = CType(resources.GetObject("FunctionTabPage.TabIndex"), Integer)
        Me.FunctionTabPage.Text = resources.GetString("FunctionTabPage.Text")
        Me.FunctionTabPage.ToolTipText = resources.GetString("FunctionTabPage.ToolTipText")
        Me.FunctionTabPage.Visible = CType(resources.GetObject("FunctionTabPage.Visible"), Boolean)
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
        'chkHighIntensity
        '
        Me.chkHighIntensity.AccessibleDescription = CType(resources.GetObject("chkHighIntensity.AccessibleDescription"), String)
        Me.chkHighIntensity.AccessibleName = CType(resources.GetObject("chkHighIntensity.AccessibleName"), String)
        Me.chkHighIntensity.Anchor = CType(resources.GetObject("chkHighIntensity.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.chkHighIntensity.Appearance = CType(resources.GetObject("chkHighIntensity.Appearance"), System.Windows.Forms.Appearance)
        Me.chkHighIntensity.BackgroundImage = CType(resources.GetObject("chkHighIntensity.BackgroundImage"), System.Drawing.Image)
        Me.chkHighIntensity.CheckAlign = CType(resources.GetObject("chkHighIntensity.CheckAlign"), System.Drawing.ContentAlignment)
        Me.chkHighIntensity.Dock = CType(resources.GetObject("chkHighIntensity.Dock"), System.Windows.Forms.DockStyle)
        Me.chkHighIntensity.Enabled = CType(resources.GetObject("chkHighIntensity.Enabled"), Boolean)
        Me.chkHighIntensity.FlatStyle = CType(resources.GetObject("chkHighIntensity.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.chkHighIntensity.Font = CType(resources.GetObject("chkHighIntensity.Font"), System.Drawing.Font)
        Me.chkHighIntensity.Image = CType(resources.GetObject("chkHighIntensity.Image"), System.Drawing.Image)
        Me.chkHighIntensity.ImageAlign = CType(resources.GetObject("chkHighIntensity.ImageAlign"), System.Drawing.ContentAlignment)
        Me.chkHighIntensity.ImageIndex = CType(resources.GetObject("chkHighIntensity.ImageIndex"), Integer)
        Me.chkHighIntensity.ImeMode = CType(resources.GetObject("chkHighIntensity.ImeMode"), System.Windows.Forms.ImeMode)
        Me.chkHighIntensity.Location = CType(resources.GetObject("chkHighIntensity.Location"), System.Drawing.Point)
        Me.chkHighIntensity.Name = "chkHighIntensity"
        Me.chkHighIntensity.RightToLeft = CType(resources.GetObject("chkHighIntensity.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.chkHighIntensity.Size = CType(resources.GetObject("chkHighIntensity.Size"), System.Drawing.Size)
        Me.chkHighIntensity.TabIndex = CType(resources.GetObject("chkHighIntensity.TabIndex"), Integer)
        Me.chkHighIntensity.Text = resources.GetString("chkHighIntensity.Text")
        Me.chkHighIntensity.TextAlign = CType(resources.GetObject("chkHighIntensity.TextAlign"), System.Drawing.ContentAlignment)
        Me.chkHighIntensity.Visible = CType(resources.GetObject("chkHighIntensity.Visible"), Boolean)
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
        'btnThreadPool
        '
        Me.btnThreadPool.AccessibleDescription = resources.GetString("btnThreadPool.AccessibleDescription")
        Me.btnThreadPool.AccessibleName = resources.GetString("btnThreadPool.AccessibleName")
        Me.btnThreadPool.Anchor = CType(resources.GetObject("btnThreadPool.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnThreadPool.BackgroundImage = CType(resources.GetObject("btnThreadPool.BackgroundImage"), System.Drawing.Image)
        Me.btnThreadPool.Dock = CType(resources.GetObject("btnThreadPool.Dock"), System.Windows.Forms.DockStyle)
        Me.btnThreadPool.Enabled = CType(resources.GetObject("btnThreadPool.Enabled"), Boolean)
        Me.btnThreadPool.FlatStyle = CType(resources.GetObject("btnThreadPool.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnThreadPool.Font = CType(resources.GetObject("btnThreadPool.Font"), System.Drawing.Font)
        Me.btnThreadPool.Image = CType(resources.GetObject("btnThreadPool.Image"), System.Drawing.Image)
        Me.btnThreadPool.ImageAlign = CType(resources.GetObject("btnThreadPool.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnThreadPool.ImageIndex = CType(resources.GetObject("btnThreadPool.ImageIndex"), Integer)
        Me.btnThreadPool.ImeMode = CType(resources.GetObject("btnThreadPool.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnThreadPool.Location = CType(resources.GetObject("btnThreadPool.Location"), System.Drawing.Point)
        Me.btnThreadPool.Name = "btnThreadPool"
        Me.btnThreadPool.RightToLeft = CType(resources.GetObject("btnThreadPool.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnThreadPool.Size = CType(resources.GetObject("btnThreadPool.Size"), System.Drawing.Size)
        Me.btnThreadPool.TabIndex = CType(resources.GetObject("btnThreadPool.TabIndex"), Integer)
        Me.btnThreadPool.Text = resources.GetString("btnThreadPool.Text")
        Me.btnThreadPool.TextAlign = CType(resources.GetObject("btnThreadPool.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnThreadPool.Visible = CType(resources.GetObject("btnThreadPool.Visible"), Boolean)
        '
        'btnThreaded
        '
        Me.btnThreaded.AccessibleDescription = resources.GetString("btnThreaded.AccessibleDescription")
        Me.btnThreaded.AccessibleName = resources.GetString("btnThreaded.AccessibleName")
        Me.btnThreaded.Anchor = CType(resources.GetObject("btnThreaded.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnThreaded.BackgroundImage = CType(resources.GetObject("btnThreaded.BackgroundImage"), System.Drawing.Image)
        Me.btnThreaded.Dock = CType(resources.GetObject("btnThreaded.Dock"), System.Windows.Forms.DockStyle)
        Me.btnThreaded.Enabled = CType(resources.GetObject("btnThreaded.Enabled"), Boolean)
        Me.btnThreaded.FlatStyle = CType(resources.GetObject("btnThreaded.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnThreaded.Font = CType(resources.GetObject("btnThreaded.Font"), System.Drawing.Font)
        Me.btnThreaded.Image = CType(resources.GetObject("btnThreaded.Image"), System.Drawing.Image)
        Me.btnThreaded.ImageAlign = CType(resources.GetObject("btnThreaded.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnThreaded.ImageIndex = CType(resources.GetObject("btnThreaded.ImageIndex"), Integer)
        Me.btnThreaded.ImeMode = CType(resources.GetObject("btnThreaded.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnThreaded.Location = CType(resources.GetObject("btnThreaded.Location"), System.Drawing.Point)
        Me.btnThreaded.Name = "btnThreaded"
        Me.btnThreaded.RightToLeft = CType(resources.GetObject("btnThreaded.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnThreaded.Size = CType(resources.GetObject("btnThreaded.Size"), System.Drawing.Size)
        Me.btnThreaded.TabIndex = CType(resources.GetObject("btnThreaded.TabIndex"), Integer)
        Me.btnThreaded.Text = resources.GetString("btnThreaded.Text")
        Me.btnThreaded.TextAlign = CType(resources.GetObject("btnThreaded.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnThreaded.Visible = CType(resources.GetObject("btnThreaded.Visible"), Boolean)
        '
        'lblSecondsElapsed
        '
        Me.lblSecondsElapsed.AccessibleDescription = CType(resources.GetObject("lblSecondsElapsed.AccessibleDescription"), String)
        Me.lblSecondsElapsed.AccessibleName = CType(resources.GetObject("lblSecondsElapsed.AccessibleName"), String)
        Me.lblSecondsElapsed.Anchor = CType(resources.GetObject("lblSecondsElapsed.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblSecondsElapsed.AutoSize = CType(resources.GetObject("lblSecondsElapsed.AutoSize"), Boolean)
        Me.lblSecondsElapsed.Dock = CType(resources.GetObject("lblSecondsElapsed.Dock"), System.Windows.Forms.DockStyle)
        Me.lblSecondsElapsed.Enabled = CType(resources.GetObject("lblSecondsElapsed.Enabled"), Boolean)
        Me.lblSecondsElapsed.Font = CType(resources.GetObject("lblSecondsElapsed.Font"), System.Drawing.Font)
        Me.lblSecondsElapsed.Image = CType(resources.GetObject("lblSecondsElapsed.Image"), System.Drawing.Image)
        Me.lblSecondsElapsed.ImageAlign = CType(resources.GetObject("lblSecondsElapsed.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblSecondsElapsed.ImageIndex = CType(resources.GetObject("lblSecondsElapsed.ImageIndex"), Integer)
        Me.lblSecondsElapsed.ImeMode = CType(resources.GetObject("lblSecondsElapsed.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblSecondsElapsed.Location = CType(resources.GetObject("lblSecondsElapsed.Location"), System.Drawing.Point)
        Me.lblSecondsElapsed.Name = "lblSecondsElapsed"
        Me.lblSecondsElapsed.RightToLeft = CType(resources.GetObject("lblSecondsElapsed.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblSecondsElapsed.Size = CType(resources.GetObject("lblSecondsElapsed.Size"), System.Drawing.Size)
        Me.lblSecondsElapsed.TabIndex = CType(resources.GetObject("lblSecondsElapsed.TabIndex"), Integer)
        Me.lblSecondsElapsed.Text = resources.GetString("lblSecondsElapsed.Text")
        Me.lblSecondsElapsed.TextAlign = CType(resources.GetObject("lblSecondsElapsed.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblSecondsElapsed.Visible = CType(resources.GetObject("lblSecondsElapsed.Visible"), Boolean)
        '
        'Process3GroupBox
        '
        Me.Process3GroupBox.AccessibleDescription = resources.GetString("Process3GroupBox.AccessibleDescription")
        Me.Process3GroupBox.AccessibleName = resources.GetString("Process3GroupBox.AccessibleName")
        Me.Process3GroupBox.Anchor = CType(resources.GetObject("Process3GroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Process3GroupBox.BackgroundImage = CType(resources.GetObject("Process3GroupBox.BackgroundImage"), System.Drawing.Image)
        Me.Process3GroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProcess3IsPoolThread, Me.Label7, Me.lblProcess3ThreadNum, Me.Label2, Me.lblProcess3Active})
        Me.Process3GroupBox.Dock = CType(resources.GetObject("Process3GroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.Process3GroupBox.Enabled = CType(resources.GetObject("Process3GroupBox.Enabled"), Boolean)
        Me.Process3GroupBox.Font = CType(resources.GetObject("Process3GroupBox.Font"), System.Drawing.Font)
        Me.Process3GroupBox.ImeMode = CType(resources.GetObject("Process3GroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Process3GroupBox.Location = CType(resources.GetObject("Process3GroupBox.Location"), System.Drawing.Point)
        Me.Process3GroupBox.Name = "Process3GroupBox"
        Me.Process3GroupBox.RightToLeft = CType(resources.GetObject("Process3GroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Process3GroupBox.Size = CType(resources.GetObject("Process3GroupBox.Size"), System.Drawing.Size)
        Me.Process3GroupBox.TabIndex = CType(resources.GetObject("Process3GroupBox.TabIndex"), Integer)
        Me.Process3GroupBox.TabStop = False
        Me.Process3GroupBox.Text = resources.GetString("Process3GroupBox.Text")
        Me.Process3GroupBox.Visible = CType(resources.GetObject("Process3GroupBox.Visible"), Boolean)
        '
        'lblProcess3IsPoolThread
        '
        Me.lblProcess3IsPoolThread.AccessibleDescription = resources.GetString("lblProcess3IsPoolThread.AccessibleDescription")
        Me.lblProcess3IsPoolThread.AccessibleName = resources.GetString("lblProcess3IsPoolThread.AccessibleName")
        Me.lblProcess3IsPoolThread.Anchor = CType(resources.GetObject("lblProcess3IsPoolThread.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProcess3IsPoolThread.AutoSize = CType(resources.GetObject("lblProcess3IsPoolThread.AutoSize"), Boolean)
        Me.lblProcess3IsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProcess3IsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcess3IsPoolThread.Dock = CType(resources.GetObject("lblProcess3IsPoolThread.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProcess3IsPoolThread.Enabled = CType(resources.GetObject("lblProcess3IsPoolThread.Enabled"), Boolean)
        Me.lblProcess3IsPoolThread.Font = CType(resources.GetObject("lblProcess3IsPoolThread.Font"), System.Drawing.Font)
        Me.lblProcess3IsPoolThread.Image = CType(resources.GetObject("lblProcess3IsPoolThread.Image"), System.Drawing.Image)
        Me.lblProcess3IsPoolThread.ImageAlign = CType(resources.GetObject("lblProcess3IsPoolThread.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess3IsPoolThread.ImageIndex = CType(resources.GetObject("lblProcess3IsPoolThread.ImageIndex"), Integer)
        Me.lblProcess3IsPoolThread.ImeMode = CType(resources.GetObject("lblProcess3IsPoolThread.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProcess3IsPoolThread.Location = CType(resources.GetObject("lblProcess3IsPoolThread.Location"), System.Drawing.Point)
        Me.lblProcess3IsPoolThread.Name = "lblProcess3IsPoolThread"
        Me.lblProcess3IsPoolThread.RightToLeft = CType(resources.GetObject("lblProcess3IsPoolThread.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProcess3IsPoolThread.Size = CType(resources.GetObject("lblProcess3IsPoolThread.Size"), System.Drawing.Size)
        Me.lblProcess3IsPoolThread.TabIndex = CType(resources.GetObject("lblProcess3IsPoolThread.TabIndex"), Integer)
        Me.lblProcess3IsPoolThread.Text = resources.GetString("lblProcess3IsPoolThread.Text")
        Me.lblProcess3IsPoolThread.TextAlign = CType(resources.GetObject("lblProcess3IsPoolThread.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess3IsPoolThread.Visible = CType(resources.GetObject("lblProcess3IsPoolThread.Visible"), Boolean)
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
        'lblProcess3ThreadNum
        '
        Me.lblProcess3ThreadNum.AccessibleDescription = resources.GetString("lblProcess3ThreadNum.AccessibleDescription")
        Me.lblProcess3ThreadNum.AccessibleName = resources.GetString("lblProcess3ThreadNum.AccessibleName")
        Me.lblProcess3ThreadNum.Anchor = CType(resources.GetObject("lblProcess3ThreadNum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProcess3ThreadNum.AutoSize = CType(resources.GetObject("lblProcess3ThreadNum.AutoSize"), Boolean)
        Me.lblProcess3ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProcess3ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcess3ThreadNum.Dock = CType(resources.GetObject("lblProcess3ThreadNum.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProcess3ThreadNum.Enabled = CType(resources.GetObject("lblProcess3ThreadNum.Enabled"), Boolean)
        Me.lblProcess3ThreadNum.Font = CType(resources.GetObject("lblProcess3ThreadNum.Font"), System.Drawing.Font)
        Me.lblProcess3ThreadNum.Image = CType(resources.GetObject("lblProcess3ThreadNum.Image"), System.Drawing.Image)
        Me.lblProcess3ThreadNum.ImageAlign = CType(resources.GetObject("lblProcess3ThreadNum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess3ThreadNum.ImageIndex = CType(resources.GetObject("lblProcess3ThreadNum.ImageIndex"), Integer)
        Me.lblProcess3ThreadNum.ImeMode = CType(resources.GetObject("lblProcess3ThreadNum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProcess3ThreadNum.Location = CType(resources.GetObject("lblProcess3ThreadNum.Location"), System.Drawing.Point)
        Me.lblProcess3ThreadNum.Name = "lblProcess3ThreadNum"
        Me.lblProcess3ThreadNum.RightToLeft = CType(resources.GetObject("lblProcess3ThreadNum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProcess3ThreadNum.Size = CType(resources.GetObject("lblProcess3ThreadNum.Size"), System.Drawing.Size)
        Me.lblProcess3ThreadNum.TabIndex = CType(resources.GetObject("lblProcess3ThreadNum.TabIndex"), Integer)
        Me.lblProcess3ThreadNum.Text = resources.GetString("lblProcess3ThreadNum.Text")
        Me.lblProcess3ThreadNum.TextAlign = CType(resources.GetObject("lblProcess3ThreadNum.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess3ThreadNum.Visible = CType(resources.GetObject("lblProcess3ThreadNum.Visible"), Boolean)
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
        'lblProcess3Active
        '
        Me.lblProcess3Active.AccessibleDescription = CType(resources.GetObject("lblProcess3Active.AccessibleDescription"), String)
        Me.lblProcess3Active.AccessibleName = CType(resources.GetObject("lblProcess3Active.AccessibleName"), String)
        Me.lblProcess3Active.Anchor = CType(resources.GetObject("lblProcess3Active.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProcess3Active.AutoSize = CType(resources.GetObject("lblProcess3Active.AutoSize"), Boolean)
        Me.lblProcess3Active.Dock = CType(resources.GetObject("lblProcess3Active.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProcess3Active.Enabled = CType(resources.GetObject("lblProcess3Active.Enabled"), Boolean)
        Me.lblProcess3Active.Font = CType(resources.GetObject("lblProcess3Active.Font"), System.Drawing.Font)
        Me.lblProcess3Active.ForeColor = System.Drawing.Color.Red
        Me.lblProcess3Active.Image = CType(resources.GetObject("lblProcess3Active.Image"), System.Drawing.Image)
        Me.lblProcess3Active.ImageAlign = CType(resources.GetObject("lblProcess3Active.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess3Active.ImageIndex = CType(resources.GetObject("lblProcess3Active.ImageIndex"), Integer)
        Me.lblProcess3Active.ImeMode = CType(resources.GetObject("lblProcess3Active.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProcess3Active.Location = CType(resources.GetObject("lblProcess3Active.Location"), System.Drawing.Point)
        Me.lblProcess3Active.Name = "lblProcess3Active"
        Me.lblProcess3Active.RightToLeft = CType(resources.GetObject("lblProcess3Active.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProcess3Active.Size = CType(resources.GetObject("lblProcess3Active.Size"), System.Drawing.Size)
        Me.lblProcess3Active.TabIndex = CType(resources.GetObject("lblProcess3Active.TabIndex"), Integer)
        Me.lblProcess3Active.Text = resources.GetString("lblProcess3Active.Text")
        Me.lblProcess3Active.TextAlign = CType(resources.GetObject("lblProcess3Active.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess3Active.Visible = CType(resources.GetObject("lblProcess3Active.Visible"), Boolean)
        '
        'Process2GroupBox
        '
        Me.Process2GroupBox.AccessibleDescription = resources.GetString("Process2GroupBox.AccessibleDescription")
        Me.Process2GroupBox.AccessibleName = resources.GetString("Process2GroupBox.AccessibleName")
        Me.Process2GroupBox.Anchor = CType(resources.GetObject("Process2GroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Process2GroupBox.BackgroundImage = CType(resources.GetObject("Process2GroupBox.BackgroundImage"), System.Drawing.Image)
        Me.Process2GroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProcess2IsPoolThread, Me.Label5, Me.lblProcess2ThreadNum, Me.Label1, Me.lblProcess2Active})
        Me.Process2GroupBox.Dock = CType(resources.GetObject("Process2GroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.Process2GroupBox.Enabled = CType(resources.GetObject("Process2GroupBox.Enabled"), Boolean)
        Me.Process2GroupBox.Font = CType(resources.GetObject("Process2GroupBox.Font"), System.Drawing.Font)
        Me.Process2GroupBox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Process2GroupBox.ImeMode = CType(resources.GetObject("Process2GroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Process2GroupBox.Location = CType(resources.GetObject("Process2GroupBox.Location"), System.Drawing.Point)
        Me.Process2GroupBox.Name = "Process2GroupBox"
        Me.Process2GroupBox.RightToLeft = CType(resources.GetObject("Process2GroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Process2GroupBox.Size = CType(resources.GetObject("Process2GroupBox.Size"), System.Drawing.Size)
        Me.Process2GroupBox.TabIndex = CType(resources.GetObject("Process2GroupBox.TabIndex"), Integer)
        Me.Process2GroupBox.TabStop = False
        Me.Process2GroupBox.Text = resources.GetString("Process2GroupBox.Text")
        Me.Process2GroupBox.Visible = CType(resources.GetObject("Process2GroupBox.Visible"), Boolean)
        '
        'lblProcess2IsPoolThread
        '
        Me.lblProcess2IsPoolThread.AccessibleDescription = resources.GetString("lblProcess2IsPoolThread.AccessibleDescription")
        Me.lblProcess2IsPoolThread.AccessibleName = resources.GetString("lblProcess2IsPoolThread.AccessibleName")
        Me.lblProcess2IsPoolThread.Anchor = CType(resources.GetObject("lblProcess2IsPoolThread.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProcess2IsPoolThread.AutoSize = CType(resources.GetObject("lblProcess2IsPoolThread.AutoSize"), Boolean)
        Me.lblProcess2IsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProcess2IsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcess2IsPoolThread.Dock = CType(resources.GetObject("lblProcess2IsPoolThread.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProcess2IsPoolThread.Enabled = CType(resources.GetObject("lblProcess2IsPoolThread.Enabled"), Boolean)
        Me.lblProcess2IsPoolThread.Font = CType(resources.GetObject("lblProcess2IsPoolThread.Font"), System.Drawing.Font)
        Me.lblProcess2IsPoolThread.Image = CType(resources.GetObject("lblProcess2IsPoolThread.Image"), System.Drawing.Image)
        Me.lblProcess2IsPoolThread.ImageAlign = CType(resources.GetObject("lblProcess2IsPoolThread.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess2IsPoolThread.ImageIndex = CType(resources.GetObject("lblProcess2IsPoolThread.ImageIndex"), Integer)
        Me.lblProcess2IsPoolThread.ImeMode = CType(resources.GetObject("lblProcess2IsPoolThread.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProcess2IsPoolThread.Location = CType(resources.GetObject("lblProcess2IsPoolThread.Location"), System.Drawing.Point)
        Me.lblProcess2IsPoolThread.Name = "lblProcess2IsPoolThread"
        Me.lblProcess2IsPoolThread.RightToLeft = CType(resources.GetObject("lblProcess2IsPoolThread.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProcess2IsPoolThread.Size = CType(resources.GetObject("lblProcess2IsPoolThread.Size"), System.Drawing.Size)
        Me.lblProcess2IsPoolThread.TabIndex = CType(resources.GetObject("lblProcess2IsPoolThread.TabIndex"), Integer)
        Me.lblProcess2IsPoolThread.Text = resources.GetString("lblProcess2IsPoolThread.Text")
        Me.lblProcess2IsPoolThread.TextAlign = CType(resources.GetObject("lblProcess2IsPoolThread.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess2IsPoolThread.Visible = CType(resources.GetObject("lblProcess2IsPoolThread.Visible"), Boolean)
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
        'lblProcess2ThreadNum
        '
        Me.lblProcess2ThreadNum.AccessibleDescription = resources.GetString("lblProcess2ThreadNum.AccessibleDescription")
        Me.lblProcess2ThreadNum.AccessibleName = resources.GetString("lblProcess2ThreadNum.AccessibleName")
        Me.lblProcess2ThreadNum.Anchor = CType(resources.GetObject("lblProcess2ThreadNum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProcess2ThreadNum.AutoSize = CType(resources.GetObject("lblProcess2ThreadNum.AutoSize"), Boolean)
        Me.lblProcess2ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProcess2ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcess2ThreadNum.Dock = CType(resources.GetObject("lblProcess2ThreadNum.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProcess2ThreadNum.Enabled = CType(resources.GetObject("lblProcess2ThreadNum.Enabled"), Boolean)
        Me.lblProcess2ThreadNum.Font = CType(resources.GetObject("lblProcess2ThreadNum.Font"), System.Drawing.Font)
        Me.lblProcess2ThreadNum.Image = CType(resources.GetObject("lblProcess2ThreadNum.Image"), System.Drawing.Image)
        Me.lblProcess2ThreadNum.ImageAlign = CType(resources.GetObject("lblProcess2ThreadNum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess2ThreadNum.ImageIndex = CType(resources.GetObject("lblProcess2ThreadNum.ImageIndex"), Integer)
        Me.lblProcess2ThreadNum.ImeMode = CType(resources.GetObject("lblProcess2ThreadNum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProcess2ThreadNum.Location = CType(resources.GetObject("lblProcess2ThreadNum.Location"), System.Drawing.Point)
        Me.lblProcess2ThreadNum.Name = "lblProcess2ThreadNum"
        Me.lblProcess2ThreadNum.RightToLeft = CType(resources.GetObject("lblProcess2ThreadNum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProcess2ThreadNum.Size = CType(resources.GetObject("lblProcess2ThreadNum.Size"), System.Drawing.Size)
        Me.lblProcess2ThreadNum.TabIndex = CType(resources.GetObject("lblProcess2ThreadNum.TabIndex"), Integer)
        Me.lblProcess2ThreadNum.Text = resources.GetString("lblProcess2ThreadNum.Text")
        Me.lblProcess2ThreadNum.TextAlign = CType(resources.GetObject("lblProcess2ThreadNum.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess2ThreadNum.Visible = CType(resources.GetObject("lblProcess2ThreadNum.Visible"), Boolean)
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
        'lblProcess2Active
        '
        Me.lblProcess2Active.AccessibleDescription = CType(resources.GetObject("lblProcess2Active.AccessibleDescription"), String)
        Me.lblProcess2Active.AccessibleName = CType(resources.GetObject("lblProcess2Active.AccessibleName"), String)
        Me.lblProcess2Active.Anchor = CType(resources.GetObject("lblProcess2Active.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProcess2Active.AutoSize = CType(resources.GetObject("lblProcess2Active.AutoSize"), Boolean)
        Me.lblProcess2Active.Dock = CType(resources.GetObject("lblProcess2Active.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProcess2Active.Enabled = CType(resources.GetObject("lblProcess2Active.Enabled"), Boolean)
        Me.lblProcess2Active.Font = CType(resources.GetObject("lblProcess2Active.Font"), System.Drawing.Font)
        Me.lblProcess2Active.ForeColor = System.Drawing.Color.Red
        Me.lblProcess2Active.Image = CType(resources.GetObject("lblProcess2Active.Image"), System.Drawing.Image)
        Me.lblProcess2Active.ImageAlign = CType(resources.GetObject("lblProcess2Active.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess2Active.ImageIndex = CType(resources.GetObject("lblProcess2Active.ImageIndex"), Integer)
        Me.lblProcess2Active.ImeMode = CType(resources.GetObject("lblProcess2Active.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProcess2Active.Location = CType(resources.GetObject("lblProcess2Active.Location"), System.Drawing.Point)
        Me.lblProcess2Active.Name = "lblProcess2Active"
        Me.lblProcess2Active.RightToLeft = CType(resources.GetObject("lblProcess2Active.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProcess2Active.Size = CType(resources.GetObject("lblProcess2Active.Size"), System.Drawing.Size)
        Me.lblProcess2Active.TabIndex = CType(resources.GetObject("lblProcess2Active.TabIndex"), Integer)
        Me.lblProcess2Active.Text = resources.GetString("lblProcess2Active.Text")
        Me.lblProcess2Active.TextAlign = CType(resources.GetObject("lblProcess2Active.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess2Active.Visible = CType(resources.GetObject("lblProcess2Active.Visible"), Boolean)
        '
        'btnNonthreaded
        '
        Me.btnNonthreaded.AccessibleDescription = CType(resources.GetObject("btnNonthreaded.AccessibleDescription"), String)
        Me.btnNonthreaded.AccessibleName = CType(resources.GetObject("btnNonthreaded.AccessibleName"), String)
        Me.btnNonthreaded.Anchor = CType(resources.GetObject("btnNonthreaded.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnNonthreaded.BackgroundImage = CType(resources.GetObject("btnNonthreaded.BackgroundImage"), System.Drawing.Image)
        Me.btnNonthreaded.Dock = CType(resources.GetObject("btnNonthreaded.Dock"), System.Windows.Forms.DockStyle)
        Me.btnNonthreaded.Enabled = CType(resources.GetObject("btnNonthreaded.Enabled"), Boolean)
        Me.btnNonthreaded.FlatStyle = CType(resources.GetObject("btnNonthreaded.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnNonthreaded.Font = CType(resources.GetObject("btnNonthreaded.Font"), System.Drawing.Font)
        Me.btnNonthreaded.Image = CType(resources.GetObject("btnNonthreaded.Image"), System.Drawing.Image)
        Me.btnNonthreaded.ImageAlign = CType(resources.GetObject("btnNonthreaded.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnNonthreaded.ImageIndex = CType(resources.GetObject("btnNonthreaded.ImageIndex"), Integer)
        Me.btnNonthreaded.ImeMode = CType(resources.GetObject("btnNonthreaded.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnNonthreaded.Location = CType(resources.GetObject("btnNonthreaded.Location"), System.Drawing.Point)
        Me.btnNonthreaded.Name = "btnNonthreaded"
        Me.btnNonthreaded.RightToLeft = CType(resources.GetObject("btnNonthreaded.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnNonthreaded.Size = CType(resources.GetObject("btnNonthreaded.Size"), System.Drawing.Size)
        Me.btnNonthreaded.TabIndex = CType(resources.GetObject("btnNonthreaded.TabIndex"), Integer)
        Me.btnNonthreaded.Text = resources.GetString("btnNonthreaded.Text")
        Me.btnNonthreaded.TextAlign = CType(resources.GetObject("btnNonthreaded.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnNonthreaded.Visible = CType(resources.GetObject("btnNonthreaded.Visible"), Boolean)
        '
        'Process1GroupBox
        '
        Me.Process1GroupBox.AccessibleDescription = resources.GetString("Process1GroupBox.AccessibleDescription")
        Me.Process1GroupBox.AccessibleName = resources.GetString("Process1GroupBox.AccessibleName")
        Me.Process1GroupBox.Anchor = CType(resources.GetObject("Process1GroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Process1GroupBox.BackgroundImage = CType(resources.GetObject("Process1GroupBox.BackgroundImage"), System.Drawing.Image)
        Me.Process1GroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProcess1IsPoolThread, Me.Label3, Me.lblProcess1ThreadNum, Me.lblThreadNumber, Me.lblProcess1Active})
        Me.Process1GroupBox.Dock = CType(resources.GetObject("Process1GroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.Process1GroupBox.Enabled = CType(resources.GetObject("Process1GroupBox.Enabled"), Boolean)
        Me.Process1GroupBox.Font = CType(resources.GetObject("Process1GroupBox.Font"), System.Drawing.Font)
        Me.Process1GroupBox.ImeMode = CType(resources.GetObject("Process1GroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Process1GroupBox.Location = CType(resources.GetObject("Process1GroupBox.Location"), System.Drawing.Point)
        Me.Process1GroupBox.Name = "Process1GroupBox"
        Me.Process1GroupBox.RightToLeft = CType(resources.GetObject("Process1GroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Process1GroupBox.Size = CType(resources.GetObject("Process1GroupBox.Size"), System.Drawing.Size)
        Me.Process1GroupBox.TabIndex = CType(resources.GetObject("Process1GroupBox.TabIndex"), Integer)
        Me.Process1GroupBox.TabStop = False
        Me.Process1GroupBox.Text = resources.GetString("Process1GroupBox.Text")
        Me.Process1GroupBox.Visible = CType(resources.GetObject("Process1GroupBox.Visible"), Boolean)
        '
        'lblProcess1IsPoolThread
        '
        Me.lblProcess1IsPoolThread.AccessibleDescription = resources.GetString("lblProcess1IsPoolThread.AccessibleDescription")
        Me.lblProcess1IsPoolThread.AccessibleName = resources.GetString("lblProcess1IsPoolThread.AccessibleName")
        Me.lblProcess1IsPoolThread.Anchor = CType(resources.GetObject("lblProcess1IsPoolThread.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProcess1IsPoolThread.AutoSize = CType(resources.GetObject("lblProcess1IsPoolThread.AutoSize"), Boolean)
        Me.lblProcess1IsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProcess1IsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcess1IsPoolThread.Dock = CType(resources.GetObject("lblProcess1IsPoolThread.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProcess1IsPoolThread.Enabled = CType(resources.GetObject("lblProcess1IsPoolThread.Enabled"), Boolean)
        Me.lblProcess1IsPoolThread.Font = CType(resources.GetObject("lblProcess1IsPoolThread.Font"), System.Drawing.Font)
        Me.lblProcess1IsPoolThread.Image = CType(resources.GetObject("lblProcess1IsPoolThread.Image"), System.Drawing.Image)
        Me.lblProcess1IsPoolThread.ImageAlign = CType(resources.GetObject("lblProcess1IsPoolThread.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess1IsPoolThread.ImageIndex = CType(resources.GetObject("lblProcess1IsPoolThread.ImageIndex"), Integer)
        Me.lblProcess1IsPoolThread.ImeMode = CType(resources.GetObject("lblProcess1IsPoolThread.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProcess1IsPoolThread.Location = CType(resources.GetObject("lblProcess1IsPoolThread.Location"), System.Drawing.Point)
        Me.lblProcess1IsPoolThread.Name = "lblProcess1IsPoolThread"
        Me.lblProcess1IsPoolThread.RightToLeft = CType(resources.GetObject("lblProcess1IsPoolThread.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProcess1IsPoolThread.Size = CType(resources.GetObject("lblProcess1IsPoolThread.Size"), System.Drawing.Size)
        Me.lblProcess1IsPoolThread.TabIndex = CType(resources.GetObject("lblProcess1IsPoolThread.TabIndex"), Integer)
        Me.lblProcess1IsPoolThread.Text = resources.GetString("lblProcess1IsPoolThread.Text")
        Me.lblProcess1IsPoolThread.TextAlign = CType(resources.GetObject("lblProcess1IsPoolThread.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess1IsPoolThread.Visible = CType(resources.GetObject("lblProcess1IsPoolThread.Visible"), Boolean)
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
        'lblProcess1ThreadNum
        '
        Me.lblProcess1ThreadNum.AccessibleDescription = resources.GetString("lblProcess1ThreadNum.AccessibleDescription")
        Me.lblProcess1ThreadNum.AccessibleName = resources.GetString("lblProcess1ThreadNum.AccessibleName")
        Me.lblProcess1ThreadNum.Anchor = CType(resources.GetObject("lblProcess1ThreadNum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProcess1ThreadNum.AutoSize = CType(resources.GetObject("lblProcess1ThreadNum.AutoSize"), Boolean)
        Me.lblProcess1ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblProcess1ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcess1ThreadNum.Dock = CType(resources.GetObject("lblProcess1ThreadNum.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProcess1ThreadNum.Enabled = CType(resources.GetObject("lblProcess1ThreadNum.Enabled"), Boolean)
        Me.lblProcess1ThreadNum.Font = CType(resources.GetObject("lblProcess1ThreadNum.Font"), System.Drawing.Font)
        Me.lblProcess1ThreadNum.Image = CType(resources.GetObject("lblProcess1ThreadNum.Image"), System.Drawing.Image)
        Me.lblProcess1ThreadNum.ImageAlign = CType(resources.GetObject("lblProcess1ThreadNum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess1ThreadNum.ImageIndex = CType(resources.GetObject("lblProcess1ThreadNum.ImageIndex"), Integer)
        Me.lblProcess1ThreadNum.ImeMode = CType(resources.GetObject("lblProcess1ThreadNum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProcess1ThreadNum.Location = CType(resources.GetObject("lblProcess1ThreadNum.Location"), System.Drawing.Point)
        Me.lblProcess1ThreadNum.Name = "lblProcess1ThreadNum"
        Me.lblProcess1ThreadNum.RightToLeft = CType(resources.GetObject("lblProcess1ThreadNum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProcess1ThreadNum.Size = CType(resources.GetObject("lblProcess1ThreadNum.Size"), System.Drawing.Size)
        Me.lblProcess1ThreadNum.TabIndex = CType(resources.GetObject("lblProcess1ThreadNum.TabIndex"), Integer)
        Me.lblProcess1ThreadNum.Text = resources.GetString("lblProcess1ThreadNum.Text")
        Me.lblProcess1ThreadNum.TextAlign = CType(resources.GetObject("lblProcess1ThreadNum.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess1ThreadNum.Visible = CType(resources.GetObject("lblProcess1ThreadNum.Visible"), Boolean)
        '
        'lblThreadNumber
        '
        Me.lblThreadNumber.AccessibleDescription = CType(resources.GetObject("lblThreadNumber.AccessibleDescription"), String)
        Me.lblThreadNumber.AccessibleName = CType(resources.GetObject("lblThreadNumber.AccessibleName"), String)
        Me.lblThreadNumber.Anchor = CType(resources.GetObject("lblThreadNumber.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblThreadNumber.AutoSize = CType(resources.GetObject("lblThreadNumber.AutoSize"), Boolean)
        Me.lblThreadNumber.Dock = CType(resources.GetObject("lblThreadNumber.Dock"), System.Windows.Forms.DockStyle)
        Me.lblThreadNumber.Enabled = CType(resources.GetObject("lblThreadNumber.Enabled"), Boolean)
        Me.lblThreadNumber.Font = CType(resources.GetObject("lblThreadNumber.Font"), System.Drawing.Font)
        Me.lblThreadNumber.Image = CType(resources.GetObject("lblThreadNumber.Image"), System.Drawing.Image)
        Me.lblThreadNumber.ImageAlign = CType(resources.GetObject("lblThreadNumber.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblThreadNumber.ImageIndex = CType(resources.GetObject("lblThreadNumber.ImageIndex"), Integer)
        Me.lblThreadNumber.ImeMode = CType(resources.GetObject("lblThreadNumber.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblThreadNumber.Location = CType(resources.GetObject("lblThreadNumber.Location"), System.Drawing.Point)
        Me.lblThreadNumber.Name = "lblThreadNumber"
        Me.lblThreadNumber.RightToLeft = CType(resources.GetObject("lblThreadNumber.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblThreadNumber.Size = CType(resources.GetObject("lblThreadNumber.Size"), System.Drawing.Size)
        Me.lblThreadNumber.TabIndex = CType(resources.GetObject("lblThreadNumber.TabIndex"), Integer)
        Me.lblThreadNumber.Text = resources.GetString("lblThreadNumber.Text")
        Me.lblThreadNumber.TextAlign = CType(resources.GetObject("lblThreadNumber.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblThreadNumber.Visible = CType(resources.GetObject("lblThreadNumber.Visible"), Boolean)
        '
        'lblProcess1Active
        '
        Me.lblProcess1Active.AccessibleDescription = resources.GetString("lblProcess1Active.AccessibleDescription")
        Me.lblProcess1Active.AccessibleName = resources.GetString("lblProcess1Active.AccessibleName")
        Me.lblProcess1Active.Anchor = CType(resources.GetObject("lblProcess1Active.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProcess1Active.AutoSize = CType(resources.GetObject("lblProcess1Active.AutoSize"), Boolean)
        Me.lblProcess1Active.Dock = CType(resources.GetObject("lblProcess1Active.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProcess1Active.Enabled = CType(resources.GetObject("lblProcess1Active.Enabled"), Boolean)
        Me.lblProcess1Active.Font = CType(resources.GetObject("lblProcess1Active.Font"), System.Drawing.Font)
        Me.lblProcess1Active.ForeColor = System.Drawing.Color.Red
        Me.lblProcess1Active.Image = CType(resources.GetObject("lblProcess1Active.Image"), System.Drawing.Image)
        Me.lblProcess1Active.ImageAlign = CType(resources.GetObject("lblProcess1Active.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess1Active.ImageIndex = CType(resources.GetObject("lblProcess1Active.ImageIndex"), Integer)
        Me.lblProcess1Active.ImeMode = CType(resources.GetObject("lblProcess1Active.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProcess1Active.Location = CType(resources.GetObject("lblProcess1Active.Location"), System.Drawing.Point)
        Me.lblProcess1Active.Name = "lblProcess1Active"
        Me.lblProcess1Active.RightToLeft = CType(resources.GetObject("lblProcess1Active.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProcess1Active.Size = CType(resources.GetObject("lblProcess1Active.Size"), System.Drawing.Size)
        Me.lblProcess1Active.TabIndex = CType(resources.GetObject("lblProcess1Active.TabIndex"), Integer)
        Me.lblProcess1Active.Text = resources.GetString("lblProcess1Active.Text")
        Me.lblProcess1Active.TextAlign = CType(resources.GetObject("lblProcess1Active.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProcess1Active.Visible = CType(resources.GetObject("lblProcess1Active.Visible"), Boolean)
        '
        'TimersTabPage
        '
        Me.TimersTabPage.AccessibleDescription = CType(resources.GetObject("TimersTabPage.AccessibleDescription"), String)
        Me.TimersTabPage.AccessibleName = CType(resources.GetObject("TimersTabPage.AccessibleName"), String)
        Me.TimersTabPage.Anchor = CType(resources.GetObject("TimersTabPage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TimersTabPage.AutoScroll = CType(resources.GetObject("TimersTabPage.AutoScroll"), Boolean)
        Me.TimersTabPage.AutoScrollMargin = CType(resources.GetObject("TimersTabPage.AutoScrollMargin"), System.Drawing.Size)
        Me.TimersTabPage.AutoScrollMinSize = CType(resources.GetObject("TimersTabPage.AutoScrollMinSize"), System.Drawing.Size)
        Me.TimersTabPage.BackgroundImage = CType(resources.GetObject("TimersTabPage.BackgroundImage"), System.Drawing.Image)
        Me.TimersTabPage.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInstructions2, Me.btnStartStop, Me.Timer2GroupBox, Me.Timer1GroupBox})
        Me.TimersTabPage.Dock = CType(resources.GetObject("TimersTabPage.Dock"), System.Windows.Forms.DockStyle)
        Me.TimersTabPage.Enabled = CType(resources.GetObject("TimersTabPage.Enabled"), Boolean)
        Me.TimersTabPage.Font = CType(resources.GetObject("TimersTabPage.Font"), System.Drawing.Font)
        Me.TimersTabPage.ImageIndex = CType(resources.GetObject("TimersTabPage.ImageIndex"), Integer)
        Me.TimersTabPage.ImeMode = CType(resources.GetObject("TimersTabPage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TimersTabPage.Location = CType(resources.GetObject("TimersTabPage.Location"), System.Drawing.Point)
        Me.TimersTabPage.Name = "TimersTabPage"
        Me.TimersTabPage.RightToLeft = CType(resources.GetObject("TimersTabPage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TimersTabPage.Size = CType(resources.GetObject("TimersTabPage.Size"), System.Drawing.Size)
        Me.TimersTabPage.TabIndex = CType(resources.GetObject("TimersTabPage.TabIndex"), Integer)
        Me.TimersTabPage.Text = resources.GetString("TimersTabPage.Text")
        Me.TimersTabPage.ToolTipText = resources.GetString("TimersTabPage.ToolTipText")
        Me.TimersTabPage.Visible = CType(resources.GetObject("TimersTabPage.Visible"), Boolean)
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
        'btnStartStop
        '
        Me.btnStartStop.AccessibleDescription = resources.GetString("btnStartStop.AccessibleDescription")
        Me.btnStartStop.AccessibleName = resources.GetString("btnStartStop.AccessibleName")
        Me.btnStartStop.Anchor = CType(resources.GetObject("btnStartStop.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStartStop.BackgroundImage = CType(resources.GetObject("btnStartStop.BackgroundImage"), System.Drawing.Image)
        Me.btnStartStop.Dock = CType(resources.GetObject("btnStartStop.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStartStop.Enabled = CType(resources.GetObject("btnStartStop.Enabled"), Boolean)
        Me.btnStartStop.FlatStyle = CType(resources.GetObject("btnStartStop.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStartStop.Font = CType(resources.GetObject("btnStartStop.Font"), System.Drawing.Font)
        Me.btnStartStop.Image = CType(resources.GetObject("btnStartStop.Image"), System.Drawing.Image)
        Me.btnStartStop.ImageAlign = CType(resources.GetObject("btnStartStop.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStartStop.ImageIndex = CType(resources.GetObject("btnStartStop.ImageIndex"), Integer)
        Me.btnStartStop.ImeMode = CType(resources.GetObject("btnStartStop.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStartStop.Location = CType(resources.GetObject("btnStartStop.Location"), System.Drawing.Point)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.RightToLeft = CType(resources.GetObject("btnStartStop.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStartStop.Size = CType(resources.GetObject("btnStartStop.Size"), System.Drawing.Size)
        Me.btnStartStop.TabIndex = CType(resources.GetObject("btnStartStop.TabIndex"), Integer)
        Me.btnStartStop.Text = resources.GetString("btnStartStop.Text")
        Me.btnStartStop.TextAlign = CType(resources.GetObject("btnStartStop.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStartStop.Visible = CType(resources.GetObject("btnStartStop.Visible"), Boolean)
        '
        'Timer2GroupBox
        '
        Me.Timer2GroupBox.AccessibleDescription = resources.GetString("Timer2GroupBox.AccessibleDescription")
        Me.Timer2GroupBox.AccessibleName = resources.GetString("Timer2GroupBox.AccessibleName")
        Me.Timer2GroupBox.Anchor = CType(resources.GetObject("Timer2GroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Timer2GroupBox.BackgroundImage = CType(resources.GetObject("Timer2GroupBox.BackgroundImage"), System.Drawing.Image)
        Me.Timer2GroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTimer2IsThreadPool, Me.Label14, Me.lblTimer2ThreadNum, Me.Label16, Me.lblTimer2Output})
        Me.Timer2GroupBox.Dock = CType(resources.GetObject("Timer2GroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.Timer2GroupBox.Enabled = CType(resources.GetObject("Timer2GroupBox.Enabled"), Boolean)
        Me.Timer2GroupBox.Font = CType(resources.GetObject("Timer2GroupBox.Font"), System.Drawing.Font)
        Me.Timer2GroupBox.ImeMode = CType(resources.GetObject("Timer2GroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Timer2GroupBox.Location = CType(resources.GetObject("Timer2GroupBox.Location"), System.Drawing.Point)
        Me.Timer2GroupBox.Name = "Timer2GroupBox"
        Me.Timer2GroupBox.RightToLeft = CType(resources.GetObject("Timer2GroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Timer2GroupBox.Size = CType(resources.GetObject("Timer2GroupBox.Size"), System.Drawing.Size)
        Me.Timer2GroupBox.TabIndex = CType(resources.GetObject("Timer2GroupBox.TabIndex"), Integer)
        Me.Timer2GroupBox.TabStop = False
        Me.Timer2GroupBox.Text = resources.GetString("Timer2GroupBox.Text")
        Me.Timer2GroupBox.Visible = CType(resources.GetObject("Timer2GroupBox.Visible"), Boolean)
        '
        'lblTimer2IsThreadPool
        '
        Me.lblTimer2IsThreadPool.AccessibleDescription = resources.GetString("lblTimer2IsThreadPool.AccessibleDescription")
        Me.lblTimer2IsThreadPool.AccessibleName = resources.GetString("lblTimer2IsThreadPool.AccessibleName")
        Me.lblTimer2IsThreadPool.Anchor = CType(resources.GetObject("lblTimer2IsThreadPool.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTimer2IsThreadPool.AutoSize = CType(resources.GetObject("lblTimer2IsThreadPool.AutoSize"), Boolean)
        Me.lblTimer2IsThreadPool.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTimer2IsThreadPool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimer2IsThreadPool.Dock = CType(resources.GetObject("lblTimer2IsThreadPool.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTimer2IsThreadPool.Enabled = CType(resources.GetObject("lblTimer2IsThreadPool.Enabled"), Boolean)
        Me.lblTimer2IsThreadPool.Font = CType(resources.GetObject("lblTimer2IsThreadPool.Font"), System.Drawing.Font)
        Me.lblTimer2IsThreadPool.Image = CType(resources.GetObject("lblTimer2IsThreadPool.Image"), System.Drawing.Image)
        Me.lblTimer2IsThreadPool.ImageAlign = CType(resources.GetObject("lblTimer2IsThreadPool.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer2IsThreadPool.ImageIndex = CType(resources.GetObject("lblTimer2IsThreadPool.ImageIndex"), Integer)
        Me.lblTimer2IsThreadPool.ImeMode = CType(resources.GetObject("lblTimer2IsThreadPool.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTimer2IsThreadPool.Location = CType(resources.GetObject("lblTimer2IsThreadPool.Location"), System.Drawing.Point)
        Me.lblTimer2IsThreadPool.Name = "lblTimer2IsThreadPool"
        Me.lblTimer2IsThreadPool.RightToLeft = CType(resources.GetObject("lblTimer2IsThreadPool.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTimer2IsThreadPool.Size = CType(resources.GetObject("lblTimer2IsThreadPool.Size"), System.Drawing.Size)
        Me.lblTimer2IsThreadPool.TabIndex = CType(resources.GetObject("lblTimer2IsThreadPool.TabIndex"), Integer)
        Me.lblTimer2IsThreadPool.Text = resources.GetString("lblTimer2IsThreadPool.Text")
        Me.lblTimer2IsThreadPool.TextAlign = CType(resources.GetObject("lblTimer2IsThreadPool.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer2IsThreadPool.Visible = CType(resources.GetObject("lblTimer2IsThreadPool.Visible"), Boolean)
        '
        'Label14
        '
        Me.Label14.AccessibleDescription = CType(resources.GetObject("Label14.AccessibleDescription"), String)
        Me.Label14.AccessibleName = CType(resources.GetObject("Label14.AccessibleName"), String)
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
        'lblTimer2ThreadNum
        '
        Me.lblTimer2ThreadNum.AccessibleDescription = resources.GetString("lblTimer2ThreadNum.AccessibleDescription")
        Me.lblTimer2ThreadNum.AccessibleName = resources.GetString("lblTimer2ThreadNum.AccessibleName")
        Me.lblTimer2ThreadNum.Anchor = CType(resources.GetObject("lblTimer2ThreadNum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTimer2ThreadNum.AutoSize = CType(resources.GetObject("lblTimer2ThreadNum.AutoSize"), Boolean)
        Me.lblTimer2ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTimer2ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimer2ThreadNum.Dock = CType(resources.GetObject("lblTimer2ThreadNum.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTimer2ThreadNum.Enabled = CType(resources.GetObject("lblTimer2ThreadNum.Enabled"), Boolean)
        Me.lblTimer2ThreadNum.Font = CType(resources.GetObject("lblTimer2ThreadNum.Font"), System.Drawing.Font)
        Me.lblTimer2ThreadNum.Image = CType(resources.GetObject("lblTimer2ThreadNum.Image"), System.Drawing.Image)
        Me.lblTimer2ThreadNum.ImageAlign = CType(resources.GetObject("lblTimer2ThreadNum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer2ThreadNum.ImageIndex = CType(resources.GetObject("lblTimer2ThreadNum.ImageIndex"), Integer)
        Me.lblTimer2ThreadNum.ImeMode = CType(resources.GetObject("lblTimer2ThreadNum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTimer2ThreadNum.Location = CType(resources.GetObject("lblTimer2ThreadNum.Location"), System.Drawing.Point)
        Me.lblTimer2ThreadNum.Name = "lblTimer2ThreadNum"
        Me.lblTimer2ThreadNum.RightToLeft = CType(resources.GetObject("lblTimer2ThreadNum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTimer2ThreadNum.Size = CType(resources.GetObject("lblTimer2ThreadNum.Size"), System.Drawing.Size)
        Me.lblTimer2ThreadNum.TabIndex = CType(resources.GetObject("lblTimer2ThreadNum.TabIndex"), Integer)
        Me.lblTimer2ThreadNum.Text = resources.GetString("lblTimer2ThreadNum.Text")
        Me.lblTimer2ThreadNum.TextAlign = CType(resources.GetObject("lblTimer2ThreadNum.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer2ThreadNum.Visible = CType(resources.GetObject("lblTimer2ThreadNum.Visible"), Boolean)
        '
        'Label16
        '
        Me.Label16.AccessibleDescription = CType(resources.GetObject("Label16.AccessibleDescription"), String)
        Me.Label16.AccessibleName = CType(resources.GetObject("Label16.AccessibleName"), String)
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
        'lblTimer2Output
        '
        Me.lblTimer2Output.AccessibleDescription = resources.GetString("lblTimer2Output.AccessibleDescription")
        Me.lblTimer2Output.AccessibleName = resources.GetString("lblTimer2Output.AccessibleName")
        Me.lblTimer2Output.Anchor = CType(resources.GetObject("lblTimer2Output.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTimer2Output.AutoSize = CType(resources.GetObject("lblTimer2Output.AutoSize"), Boolean)
        Me.lblTimer2Output.Dock = CType(resources.GetObject("lblTimer2Output.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTimer2Output.Enabled = CType(resources.GetObject("lblTimer2Output.Enabled"), Boolean)
        Me.lblTimer2Output.Font = CType(resources.GetObject("lblTimer2Output.Font"), System.Drawing.Font)
        Me.lblTimer2Output.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTimer2Output.Image = CType(resources.GetObject("lblTimer2Output.Image"), System.Drawing.Image)
        Me.lblTimer2Output.ImageAlign = CType(resources.GetObject("lblTimer2Output.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer2Output.ImageIndex = CType(resources.GetObject("lblTimer2Output.ImageIndex"), Integer)
        Me.lblTimer2Output.ImeMode = CType(resources.GetObject("lblTimer2Output.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTimer2Output.Location = CType(resources.GetObject("lblTimer2Output.Location"), System.Drawing.Point)
        Me.lblTimer2Output.Name = "lblTimer2Output"
        Me.lblTimer2Output.RightToLeft = CType(resources.GetObject("lblTimer2Output.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTimer2Output.Size = CType(resources.GetObject("lblTimer2Output.Size"), System.Drawing.Size)
        Me.lblTimer2Output.TabIndex = CType(resources.GetObject("lblTimer2Output.TabIndex"), Integer)
        Me.lblTimer2Output.Text = resources.GetString("lblTimer2Output.Text")
        Me.lblTimer2Output.TextAlign = CType(resources.GetObject("lblTimer2Output.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer2Output.Visible = CType(resources.GetObject("lblTimer2Output.Visible"), Boolean)
        '
        'Timer1GroupBox
        '
        Me.Timer1GroupBox.AccessibleDescription = resources.GetString("Timer1GroupBox.AccessibleDescription")
        Me.Timer1GroupBox.AccessibleName = resources.GetString("Timer1GroupBox.AccessibleName")
        Me.Timer1GroupBox.Anchor = CType(resources.GetObject("Timer1GroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Timer1GroupBox.BackgroundImage = CType(resources.GetObject("Timer1GroupBox.BackgroundImage"), System.Drawing.Image)
        Me.Timer1GroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTimer1IsThreadPool, Me.Label9, Me.lblTimer1ThreadNum, Me.Label11, Me.lblTimer1Output})
        Me.Timer1GroupBox.Dock = CType(resources.GetObject("Timer1GroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.Timer1GroupBox.Enabled = CType(resources.GetObject("Timer1GroupBox.Enabled"), Boolean)
        Me.Timer1GroupBox.Font = CType(resources.GetObject("Timer1GroupBox.Font"), System.Drawing.Font)
        Me.Timer1GroupBox.ImeMode = CType(resources.GetObject("Timer1GroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Timer1GroupBox.Location = CType(resources.GetObject("Timer1GroupBox.Location"), System.Drawing.Point)
        Me.Timer1GroupBox.Name = "Timer1GroupBox"
        Me.Timer1GroupBox.RightToLeft = CType(resources.GetObject("Timer1GroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Timer1GroupBox.Size = CType(resources.GetObject("Timer1GroupBox.Size"), System.Drawing.Size)
        Me.Timer1GroupBox.TabIndex = CType(resources.GetObject("Timer1GroupBox.TabIndex"), Integer)
        Me.Timer1GroupBox.TabStop = False
        Me.Timer1GroupBox.Text = resources.GetString("Timer1GroupBox.Text")
        Me.Timer1GroupBox.Visible = CType(resources.GetObject("Timer1GroupBox.Visible"), Boolean)
        '
        'lblTimer1IsThreadPool
        '
        Me.lblTimer1IsThreadPool.AccessibleDescription = resources.GetString("lblTimer1IsThreadPool.AccessibleDescription")
        Me.lblTimer1IsThreadPool.AccessibleName = resources.GetString("lblTimer1IsThreadPool.AccessibleName")
        Me.lblTimer1IsThreadPool.Anchor = CType(resources.GetObject("lblTimer1IsThreadPool.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTimer1IsThreadPool.AutoSize = CType(resources.GetObject("lblTimer1IsThreadPool.AutoSize"), Boolean)
        Me.lblTimer1IsThreadPool.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTimer1IsThreadPool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimer1IsThreadPool.Dock = CType(resources.GetObject("lblTimer1IsThreadPool.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTimer1IsThreadPool.Enabled = CType(resources.GetObject("lblTimer1IsThreadPool.Enabled"), Boolean)
        Me.lblTimer1IsThreadPool.Font = CType(resources.GetObject("lblTimer1IsThreadPool.Font"), System.Drawing.Font)
        Me.lblTimer1IsThreadPool.Image = CType(resources.GetObject("lblTimer1IsThreadPool.Image"), System.Drawing.Image)
        Me.lblTimer1IsThreadPool.ImageAlign = CType(resources.GetObject("lblTimer1IsThreadPool.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer1IsThreadPool.ImageIndex = CType(resources.GetObject("lblTimer1IsThreadPool.ImageIndex"), Integer)
        Me.lblTimer1IsThreadPool.ImeMode = CType(resources.GetObject("lblTimer1IsThreadPool.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTimer1IsThreadPool.Location = CType(resources.GetObject("lblTimer1IsThreadPool.Location"), System.Drawing.Point)
        Me.lblTimer1IsThreadPool.Name = "lblTimer1IsThreadPool"
        Me.lblTimer1IsThreadPool.RightToLeft = CType(resources.GetObject("lblTimer1IsThreadPool.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTimer1IsThreadPool.Size = CType(resources.GetObject("lblTimer1IsThreadPool.Size"), System.Drawing.Size)
        Me.lblTimer1IsThreadPool.TabIndex = CType(resources.GetObject("lblTimer1IsThreadPool.TabIndex"), Integer)
        Me.lblTimer1IsThreadPool.Text = resources.GetString("lblTimer1IsThreadPool.Text")
        Me.lblTimer1IsThreadPool.TextAlign = CType(resources.GetObject("lblTimer1IsThreadPool.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer1IsThreadPool.Visible = CType(resources.GetObject("lblTimer1IsThreadPool.Visible"), Boolean)
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
        'lblTimer1ThreadNum
        '
        Me.lblTimer1ThreadNum.AccessibleDescription = resources.GetString("lblTimer1ThreadNum.AccessibleDescription")
        Me.lblTimer1ThreadNum.AccessibleName = resources.GetString("lblTimer1ThreadNum.AccessibleName")
        Me.lblTimer1ThreadNum.Anchor = CType(resources.GetObject("lblTimer1ThreadNum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTimer1ThreadNum.AutoSize = CType(resources.GetObject("lblTimer1ThreadNum.AutoSize"), Boolean)
        Me.lblTimer1ThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTimer1ThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimer1ThreadNum.Dock = CType(resources.GetObject("lblTimer1ThreadNum.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTimer1ThreadNum.Enabled = CType(resources.GetObject("lblTimer1ThreadNum.Enabled"), Boolean)
        Me.lblTimer1ThreadNum.Font = CType(resources.GetObject("lblTimer1ThreadNum.Font"), System.Drawing.Font)
        Me.lblTimer1ThreadNum.Image = CType(resources.GetObject("lblTimer1ThreadNum.Image"), System.Drawing.Image)
        Me.lblTimer1ThreadNum.ImageAlign = CType(resources.GetObject("lblTimer1ThreadNum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer1ThreadNum.ImageIndex = CType(resources.GetObject("lblTimer1ThreadNum.ImageIndex"), Integer)
        Me.lblTimer1ThreadNum.ImeMode = CType(resources.GetObject("lblTimer1ThreadNum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTimer1ThreadNum.Location = CType(resources.GetObject("lblTimer1ThreadNum.Location"), System.Drawing.Point)
        Me.lblTimer1ThreadNum.Name = "lblTimer1ThreadNum"
        Me.lblTimer1ThreadNum.RightToLeft = CType(resources.GetObject("lblTimer1ThreadNum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTimer1ThreadNum.Size = CType(resources.GetObject("lblTimer1ThreadNum.Size"), System.Drawing.Size)
        Me.lblTimer1ThreadNum.TabIndex = CType(resources.GetObject("lblTimer1ThreadNum.TabIndex"), Integer)
        Me.lblTimer1ThreadNum.Text = resources.GetString("lblTimer1ThreadNum.Text")
        Me.lblTimer1ThreadNum.TextAlign = CType(resources.GetObject("lblTimer1ThreadNum.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer1ThreadNum.Visible = CType(resources.GetObject("lblTimer1ThreadNum.Visible"), Boolean)
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
        'lblTimer1Output
        '
        Me.lblTimer1Output.AccessibleDescription = resources.GetString("lblTimer1Output.AccessibleDescription")
        Me.lblTimer1Output.AccessibleName = resources.GetString("lblTimer1Output.AccessibleName")
        Me.lblTimer1Output.Anchor = CType(resources.GetObject("lblTimer1Output.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTimer1Output.AutoSize = CType(resources.GetObject("lblTimer1Output.AutoSize"), Boolean)
        Me.lblTimer1Output.Dock = CType(resources.GetObject("lblTimer1Output.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTimer1Output.Enabled = CType(resources.GetObject("lblTimer1Output.Enabled"), Boolean)
        Me.lblTimer1Output.Font = CType(resources.GetObject("lblTimer1Output.Font"), System.Drawing.Font)
        Me.lblTimer1Output.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTimer1Output.Image = CType(resources.GetObject("lblTimer1Output.Image"), System.Drawing.Image)
        Me.lblTimer1Output.ImageAlign = CType(resources.GetObject("lblTimer1Output.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer1Output.ImageIndex = CType(resources.GetObject("lblTimer1Output.ImageIndex"), Integer)
        Me.lblTimer1Output.ImeMode = CType(resources.GetObject("lblTimer1Output.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTimer1Output.Location = CType(resources.GetObject("lblTimer1Output.Location"), System.Drawing.Point)
        Me.lblTimer1Output.Name = "lblTimer1Output"
        Me.lblTimer1Output.RightToLeft = CType(resources.GetObject("lblTimer1Output.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTimer1Output.Size = CType(resources.GetObject("lblTimer1Output.Size"), System.Drawing.Size)
        Me.lblTimer1Output.TabIndex = CType(resources.GetObject("lblTimer1Output.TabIndex"), Integer)
        Me.lblTimer1Output.Text = resources.GetString("lblTimer1Output.Text")
        Me.lblTimer1Output.TextAlign = CType(resources.GetObject("lblTimer1Output.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTimer1Output.Visible = CType(resources.GetObject("lblTimer1Output.Visible"), Boolean)
        '
        'SyncObjectsTabPage
        '
        Me.SyncObjectsTabPage.AccessibleDescription = CType(resources.GetObject("SyncObjectsTabPage.AccessibleDescription"), String)
        Me.SyncObjectsTabPage.AccessibleName = CType(resources.GetObject("SyncObjectsTabPage.AccessibleName"), String)
        Me.SyncObjectsTabPage.Anchor = CType(resources.GetObject("SyncObjectsTabPage.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.SyncObjectsTabPage.AutoScroll = CType(resources.GetObject("SyncObjectsTabPage.AutoScroll"), Boolean)
        Me.SyncObjectsTabPage.AutoScrollMargin = CType(resources.GetObject("SyncObjectsTabPage.AutoScrollMargin"), System.Drawing.Size)
        Me.SyncObjectsTabPage.AutoScrollMinSize = CType(resources.GetObject("SyncObjectsTabPage.AutoScrollMinSize"), System.Drawing.Size)
        Me.SyncObjectsTabPage.BackgroundImage = CType(resources.GetObject("SyncObjectsTabPage.BackgroundImage"), System.Drawing.Image)
        Me.SyncObjectsTabPage.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInstructions3, Me.btnSetReleaseAll, Me.btnSetAutoEvent, Me.btnWaitForAutoEvent, Me.btnSetManualEvent, Me.btnWaitForManualEvent, Me.btnReleaseMutex, Me.btnWaitForMutex, Me.AutoEventGroupBox, Me.ManualEventGroupBox, Me.MutexGroupBox})
        Me.SyncObjectsTabPage.Dock = CType(resources.GetObject("SyncObjectsTabPage.Dock"), System.Windows.Forms.DockStyle)
        Me.SyncObjectsTabPage.Enabled = CType(resources.GetObject("SyncObjectsTabPage.Enabled"), Boolean)
        Me.SyncObjectsTabPage.Font = CType(resources.GetObject("SyncObjectsTabPage.Font"), System.Drawing.Font)
        Me.SyncObjectsTabPage.ImageIndex = CType(resources.GetObject("SyncObjectsTabPage.ImageIndex"), Integer)
        Me.SyncObjectsTabPage.ImeMode = CType(resources.GetObject("SyncObjectsTabPage.ImeMode"), System.Windows.Forms.ImeMode)
        Me.SyncObjectsTabPage.Location = CType(resources.GetObject("SyncObjectsTabPage.Location"), System.Drawing.Point)
        Me.SyncObjectsTabPage.Name = "SyncObjectsTabPage"
        Me.SyncObjectsTabPage.RightToLeft = CType(resources.GetObject("SyncObjectsTabPage.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.SyncObjectsTabPage.Size = CType(resources.GetObject("SyncObjectsTabPage.Size"), System.Drawing.Size)
        Me.SyncObjectsTabPage.TabIndex = CType(resources.GetObject("SyncObjectsTabPage.TabIndex"), Integer)
        Me.SyncObjectsTabPage.Text = resources.GetString("SyncObjectsTabPage.Text")
        Me.SyncObjectsTabPage.ToolTipText = resources.GetString("SyncObjectsTabPage.ToolTipText")
        Me.SyncObjectsTabPage.Visible = CType(resources.GetObject("SyncObjectsTabPage.Visible"), Boolean)
        '
        'lblInstructions3
        '
        Me.lblInstructions3.AccessibleDescription = CType(resources.GetObject("lblInstructions3.AccessibleDescription"), String)
        Me.lblInstructions3.AccessibleName = CType(resources.GetObject("lblInstructions3.AccessibleName"), String)
        Me.lblInstructions3.Anchor = CType(resources.GetObject("lblInstructions3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblInstructions3.AutoSize = CType(resources.GetObject("lblInstructions3.AutoSize"), Boolean)
        Me.lblInstructions3.Dock = CType(resources.GetObject("lblInstructions3.Dock"), System.Windows.Forms.DockStyle)
        Me.lblInstructions3.Enabled = CType(resources.GetObject("lblInstructions3.Enabled"), Boolean)
        Me.lblInstructions3.Font = CType(resources.GetObject("lblInstructions3.Font"), System.Drawing.Font)
        Me.lblInstructions3.ForeColor = System.Drawing.Color.Blue
        Me.lblInstructions3.Image = CType(resources.GetObject("lblInstructions3.Image"), System.Drawing.Image)
        Me.lblInstructions3.ImageAlign = CType(resources.GetObject("lblInstructions3.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblInstructions3.ImageIndex = CType(resources.GetObject("lblInstructions3.ImageIndex"), Integer)
        Me.lblInstructions3.ImeMode = CType(resources.GetObject("lblInstructions3.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblInstructions3.Location = CType(resources.GetObject("lblInstructions3.Location"), System.Drawing.Point)
        Me.lblInstructions3.Name = "lblInstructions3"
        Me.lblInstructions3.RightToLeft = CType(resources.GetObject("lblInstructions3.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblInstructions3.Size = CType(resources.GetObject("lblInstructions3.Size"), System.Drawing.Size)
        Me.lblInstructions3.TabIndex = CType(resources.GetObject("lblInstructions3.TabIndex"), Integer)
        Me.lblInstructions3.Text = resources.GetString("lblInstructions3.Text")
        Me.lblInstructions3.TextAlign = CType(resources.GetObject("lblInstructions3.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblInstructions3.Visible = CType(resources.GetObject("lblInstructions3.Visible"), Boolean)
        '
        'btnSetReleaseAll
        '
        Me.btnSetReleaseAll.AccessibleDescription = CType(resources.GetObject("btnSetReleaseAll.AccessibleDescription"), String)
        Me.btnSetReleaseAll.AccessibleName = CType(resources.GetObject("btnSetReleaseAll.AccessibleName"), String)
        Me.btnSetReleaseAll.Anchor = CType(resources.GetObject("btnSetReleaseAll.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSetReleaseAll.BackgroundImage = CType(resources.GetObject("btnSetReleaseAll.BackgroundImage"), System.Drawing.Image)
        Me.btnSetReleaseAll.Dock = CType(resources.GetObject("btnSetReleaseAll.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSetReleaseAll.Enabled = CType(resources.GetObject("btnSetReleaseAll.Enabled"), Boolean)
        Me.btnSetReleaseAll.FlatStyle = CType(resources.GetObject("btnSetReleaseAll.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSetReleaseAll.Font = CType(resources.GetObject("btnSetReleaseAll.Font"), System.Drawing.Font)
        Me.btnSetReleaseAll.Image = CType(resources.GetObject("btnSetReleaseAll.Image"), System.Drawing.Image)
        Me.btnSetReleaseAll.ImageAlign = CType(resources.GetObject("btnSetReleaseAll.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSetReleaseAll.ImageIndex = CType(resources.GetObject("btnSetReleaseAll.ImageIndex"), Integer)
        Me.btnSetReleaseAll.ImeMode = CType(resources.GetObject("btnSetReleaseAll.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSetReleaseAll.Location = CType(resources.GetObject("btnSetReleaseAll.Location"), System.Drawing.Point)
        Me.btnSetReleaseAll.Name = "btnSetReleaseAll"
        Me.btnSetReleaseAll.RightToLeft = CType(resources.GetObject("btnSetReleaseAll.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSetReleaseAll.Size = CType(resources.GetObject("btnSetReleaseAll.Size"), System.Drawing.Size)
        Me.btnSetReleaseAll.TabIndex = CType(resources.GetObject("btnSetReleaseAll.TabIndex"), Integer)
        Me.btnSetReleaseAll.Text = resources.GetString("btnSetReleaseAll.Text")
        Me.btnSetReleaseAll.TextAlign = CType(resources.GetObject("btnSetReleaseAll.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSetReleaseAll.Visible = CType(resources.GetObject("btnSetReleaseAll.Visible"), Boolean)
        '
        'btnSetAutoEvent
        '
        Me.btnSetAutoEvent.AccessibleDescription = CType(resources.GetObject("btnSetAutoEvent.AccessibleDescription"), String)
        Me.btnSetAutoEvent.AccessibleName = CType(resources.GetObject("btnSetAutoEvent.AccessibleName"), String)
        Me.btnSetAutoEvent.Anchor = CType(resources.GetObject("btnSetAutoEvent.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSetAutoEvent.BackgroundImage = CType(resources.GetObject("btnSetAutoEvent.BackgroundImage"), System.Drawing.Image)
        Me.btnSetAutoEvent.Dock = CType(resources.GetObject("btnSetAutoEvent.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSetAutoEvent.Enabled = CType(resources.GetObject("btnSetAutoEvent.Enabled"), Boolean)
        Me.btnSetAutoEvent.FlatStyle = CType(resources.GetObject("btnSetAutoEvent.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSetAutoEvent.Font = CType(resources.GetObject("btnSetAutoEvent.Font"), System.Drawing.Font)
        Me.btnSetAutoEvent.Image = CType(resources.GetObject("btnSetAutoEvent.Image"), System.Drawing.Image)
        Me.btnSetAutoEvent.ImageAlign = CType(resources.GetObject("btnSetAutoEvent.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSetAutoEvent.ImageIndex = CType(resources.GetObject("btnSetAutoEvent.ImageIndex"), Integer)
        Me.btnSetAutoEvent.ImeMode = CType(resources.GetObject("btnSetAutoEvent.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSetAutoEvent.Location = CType(resources.GetObject("btnSetAutoEvent.Location"), System.Drawing.Point)
        Me.btnSetAutoEvent.Name = "btnSetAutoEvent"
        Me.btnSetAutoEvent.RightToLeft = CType(resources.GetObject("btnSetAutoEvent.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSetAutoEvent.Size = CType(resources.GetObject("btnSetAutoEvent.Size"), System.Drawing.Size)
        Me.btnSetAutoEvent.TabIndex = CType(resources.GetObject("btnSetAutoEvent.TabIndex"), Integer)
        Me.btnSetAutoEvent.Text = resources.GetString("btnSetAutoEvent.Text")
        Me.btnSetAutoEvent.TextAlign = CType(resources.GetObject("btnSetAutoEvent.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSetAutoEvent.Visible = CType(resources.GetObject("btnSetAutoEvent.Visible"), Boolean)
        '
        'btnWaitForAutoEvent
        '
        Me.btnWaitForAutoEvent.AccessibleDescription = CType(resources.GetObject("btnWaitForAutoEvent.AccessibleDescription"), String)
        Me.btnWaitForAutoEvent.AccessibleName = CType(resources.GetObject("btnWaitForAutoEvent.AccessibleName"), String)
        Me.btnWaitForAutoEvent.Anchor = CType(resources.GetObject("btnWaitForAutoEvent.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnWaitForAutoEvent.BackgroundImage = CType(resources.GetObject("btnWaitForAutoEvent.BackgroundImage"), System.Drawing.Image)
        Me.btnWaitForAutoEvent.Dock = CType(resources.GetObject("btnWaitForAutoEvent.Dock"), System.Windows.Forms.DockStyle)
        Me.btnWaitForAutoEvent.Enabled = CType(resources.GetObject("btnWaitForAutoEvent.Enabled"), Boolean)
        Me.btnWaitForAutoEvent.FlatStyle = CType(resources.GetObject("btnWaitForAutoEvent.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnWaitForAutoEvent.Font = CType(resources.GetObject("btnWaitForAutoEvent.Font"), System.Drawing.Font)
        Me.btnWaitForAutoEvent.Image = CType(resources.GetObject("btnWaitForAutoEvent.Image"), System.Drawing.Image)
        Me.btnWaitForAutoEvent.ImageAlign = CType(resources.GetObject("btnWaitForAutoEvent.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnWaitForAutoEvent.ImageIndex = CType(resources.GetObject("btnWaitForAutoEvent.ImageIndex"), Integer)
        Me.btnWaitForAutoEvent.ImeMode = CType(resources.GetObject("btnWaitForAutoEvent.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnWaitForAutoEvent.Location = CType(resources.GetObject("btnWaitForAutoEvent.Location"), System.Drawing.Point)
        Me.btnWaitForAutoEvent.Name = "btnWaitForAutoEvent"
        Me.btnWaitForAutoEvent.RightToLeft = CType(resources.GetObject("btnWaitForAutoEvent.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnWaitForAutoEvent.Size = CType(resources.GetObject("btnWaitForAutoEvent.Size"), System.Drawing.Size)
        Me.btnWaitForAutoEvent.TabIndex = CType(resources.GetObject("btnWaitForAutoEvent.TabIndex"), Integer)
        Me.btnWaitForAutoEvent.Text = resources.GetString("btnWaitForAutoEvent.Text")
        Me.btnWaitForAutoEvent.TextAlign = CType(resources.GetObject("btnWaitForAutoEvent.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnWaitForAutoEvent.Visible = CType(resources.GetObject("btnWaitForAutoEvent.Visible"), Boolean)
        '
        'btnSetManualEvent
        '
        Me.btnSetManualEvent.AccessibleDescription = resources.GetString("btnSetManualEvent.AccessibleDescription")
        Me.btnSetManualEvent.AccessibleName = resources.GetString("btnSetManualEvent.AccessibleName")
        Me.btnSetManualEvent.Anchor = CType(resources.GetObject("btnSetManualEvent.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnSetManualEvent.BackgroundImage = CType(resources.GetObject("btnSetManualEvent.BackgroundImage"), System.Drawing.Image)
        Me.btnSetManualEvent.Dock = CType(resources.GetObject("btnSetManualEvent.Dock"), System.Windows.Forms.DockStyle)
        Me.btnSetManualEvent.Enabled = CType(resources.GetObject("btnSetManualEvent.Enabled"), Boolean)
        Me.btnSetManualEvent.FlatStyle = CType(resources.GetObject("btnSetManualEvent.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnSetManualEvent.Font = CType(resources.GetObject("btnSetManualEvent.Font"), System.Drawing.Font)
        Me.btnSetManualEvent.Image = CType(resources.GetObject("btnSetManualEvent.Image"), System.Drawing.Image)
        Me.btnSetManualEvent.ImageAlign = CType(resources.GetObject("btnSetManualEvent.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnSetManualEvent.ImageIndex = CType(resources.GetObject("btnSetManualEvent.ImageIndex"), Integer)
        Me.btnSetManualEvent.ImeMode = CType(resources.GetObject("btnSetManualEvent.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnSetManualEvent.Location = CType(resources.GetObject("btnSetManualEvent.Location"), System.Drawing.Point)
        Me.btnSetManualEvent.Name = "btnSetManualEvent"
        Me.btnSetManualEvent.RightToLeft = CType(resources.GetObject("btnSetManualEvent.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnSetManualEvent.Size = CType(resources.GetObject("btnSetManualEvent.Size"), System.Drawing.Size)
        Me.btnSetManualEvent.TabIndex = CType(resources.GetObject("btnSetManualEvent.TabIndex"), Integer)
        Me.btnSetManualEvent.Text = resources.GetString("btnSetManualEvent.Text")
        Me.btnSetManualEvent.TextAlign = CType(resources.GetObject("btnSetManualEvent.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnSetManualEvent.Visible = CType(resources.GetObject("btnSetManualEvent.Visible"), Boolean)
        '
        'btnWaitForManualEvent
        '
        Me.btnWaitForManualEvent.AccessibleDescription = CType(resources.GetObject("btnWaitForManualEvent.AccessibleDescription"), String)
        Me.btnWaitForManualEvent.AccessibleName = CType(resources.GetObject("btnWaitForManualEvent.AccessibleName"), String)
        Me.btnWaitForManualEvent.Anchor = CType(resources.GetObject("btnWaitForManualEvent.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnWaitForManualEvent.BackgroundImage = CType(resources.GetObject("btnWaitForManualEvent.BackgroundImage"), System.Drawing.Image)
        Me.btnWaitForManualEvent.Dock = CType(resources.GetObject("btnWaitForManualEvent.Dock"), System.Windows.Forms.DockStyle)
        Me.btnWaitForManualEvent.Enabled = CType(resources.GetObject("btnWaitForManualEvent.Enabled"), Boolean)
        Me.btnWaitForManualEvent.FlatStyle = CType(resources.GetObject("btnWaitForManualEvent.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnWaitForManualEvent.Font = CType(resources.GetObject("btnWaitForManualEvent.Font"), System.Drawing.Font)
        Me.btnWaitForManualEvent.Image = CType(resources.GetObject("btnWaitForManualEvent.Image"), System.Drawing.Image)
        Me.btnWaitForManualEvent.ImageAlign = CType(resources.GetObject("btnWaitForManualEvent.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnWaitForManualEvent.ImageIndex = CType(resources.GetObject("btnWaitForManualEvent.ImageIndex"), Integer)
        Me.btnWaitForManualEvent.ImeMode = CType(resources.GetObject("btnWaitForManualEvent.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnWaitForManualEvent.Location = CType(resources.GetObject("btnWaitForManualEvent.Location"), System.Drawing.Point)
        Me.btnWaitForManualEvent.Name = "btnWaitForManualEvent"
        Me.btnWaitForManualEvent.RightToLeft = CType(resources.GetObject("btnWaitForManualEvent.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnWaitForManualEvent.Size = CType(resources.GetObject("btnWaitForManualEvent.Size"), System.Drawing.Size)
        Me.btnWaitForManualEvent.TabIndex = CType(resources.GetObject("btnWaitForManualEvent.TabIndex"), Integer)
        Me.btnWaitForManualEvent.Text = resources.GetString("btnWaitForManualEvent.Text")
        Me.btnWaitForManualEvent.TextAlign = CType(resources.GetObject("btnWaitForManualEvent.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnWaitForManualEvent.Visible = CType(resources.GetObject("btnWaitForManualEvent.Visible"), Boolean)
        '
        'btnReleaseMutex
        '
        Me.btnReleaseMutex.AccessibleDescription = CType(resources.GetObject("btnReleaseMutex.AccessibleDescription"), String)
        Me.btnReleaseMutex.AccessibleName = CType(resources.GetObject("btnReleaseMutex.AccessibleName"), String)
        Me.btnReleaseMutex.Anchor = CType(resources.GetObject("btnReleaseMutex.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnReleaseMutex.BackgroundImage = CType(resources.GetObject("btnReleaseMutex.BackgroundImage"), System.Drawing.Image)
        Me.btnReleaseMutex.Dock = CType(resources.GetObject("btnReleaseMutex.Dock"), System.Windows.Forms.DockStyle)
        Me.btnReleaseMutex.Enabled = CType(resources.GetObject("btnReleaseMutex.Enabled"), Boolean)
        Me.btnReleaseMutex.FlatStyle = CType(resources.GetObject("btnReleaseMutex.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnReleaseMutex.Font = CType(resources.GetObject("btnReleaseMutex.Font"), System.Drawing.Font)
        Me.btnReleaseMutex.Image = CType(resources.GetObject("btnReleaseMutex.Image"), System.Drawing.Image)
        Me.btnReleaseMutex.ImageAlign = CType(resources.GetObject("btnReleaseMutex.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnReleaseMutex.ImageIndex = CType(resources.GetObject("btnReleaseMutex.ImageIndex"), Integer)
        Me.btnReleaseMutex.ImeMode = CType(resources.GetObject("btnReleaseMutex.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnReleaseMutex.Location = CType(resources.GetObject("btnReleaseMutex.Location"), System.Drawing.Point)
        Me.btnReleaseMutex.Name = "btnReleaseMutex"
        Me.btnReleaseMutex.RightToLeft = CType(resources.GetObject("btnReleaseMutex.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnReleaseMutex.Size = CType(resources.GetObject("btnReleaseMutex.Size"), System.Drawing.Size)
        Me.btnReleaseMutex.TabIndex = CType(resources.GetObject("btnReleaseMutex.TabIndex"), Integer)
        Me.btnReleaseMutex.Text = resources.GetString("btnReleaseMutex.Text")
        Me.btnReleaseMutex.TextAlign = CType(resources.GetObject("btnReleaseMutex.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnReleaseMutex.Visible = CType(resources.GetObject("btnReleaseMutex.Visible"), Boolean)
        '
        'btnWaitForMutex
        '
        Me.btnWaitForMutex.AccessibleDescription = CType(resources.GetObject("btnWaitForMutex.AccessibleDescription"), String)
        Me.btnWaitForMutex.AccessibleName = CType(resources.GetObject("btnWaitForMutex.AccessibleName"), String)
        Me.btnWaitForMutex.Anchor = CType(resources.GetObject("btnWaitForMutex.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnWaitForMutex.BackgroundImage = CType(resources.GetObject("btnWaitForMutex.BackgroundImage"), System.Drawing.Image)
        Me.btnWaitForMutex.Dock = CType(resources.GetObject("btnWaitForMutex.Dock"), System.Windows.Forms.DockStyle)
        Me.btnWaitForMutex.Enabled = CType(resources.GetObject("btnWaitForMutex.Enabled"), Boolean)
        Me.btnWaitForMutex.FlatStyle = CType(resources.GetObject("btnWaitForMutex.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnWaitForMutex.Font = CType(resources.GetObject("btnWaitForMutex.Font"), System.Drawing.Font)
        Me.btnWaitForMutex.Image = CType(resources.GetObject("btnWaitForMutex.Image"), System.Drawing.Image)
        Me.btnWaitForMutex.ImageAlign = CType(resources.GetObject("btnWaitForMutex.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnWaitForMutex.ImageIndex = CType(resources.GetObject("btnWaitForMutex.ImageIndex"), Integer)
        Me.btnWaitForMutex.ImeMode = CType(resources.GetObject("btnWaitForMutex.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnWaitForMutex.Location = CType(resources.GetObject("btnWaitForMutex.Location"), System.Drawing.Point)
        Me.btnWaitForMutex.Name = "btnWaitForMutex"
        Me.btnWaitForMutex.RightToLeft = CType(resources.GetObject("btnWaitForMutex.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnWaitForMutex.Size = CType(resources.GetObject("btnWaitForMutex.Size"), System.Drawing.Size)
        Me.btnWaitForMutex.TabIndex = CType(resources.GetObject("btnWaitForMutex.TabIndex"), Integer)
        Me.btnWaitForMutex.Text = resources.GetString("btnWaitForMutex.Text")
        Me.btnWaitForMutex.TextAlign = CType(resources.GetObject("btnWaitForMutex.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnWaitForMutex.Visible = CType(resources.GetObject("btnWaitForMutex.Visible"), Boolean)
        '
        'AutoEventGroupBox
        '
        Me.AutoEventGroupBox.AccessibleDescription = resources.GetString("AutoEventGroupBox.AccessibleDescription")
        Me.AutoEventGroupBox.AccessibleName = resources.GetString("AutoEventGroupBox.AccessibleName")
        Me.AutoEventGroupBox.Anchor = CType(resources.GetObject("AutoEventGroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoEventGroupBox.BackgroundImage = CType(resources.GetObject("AutoEventGroupBox.BackgroundImage"), System.Drawing.Image)
        Me.AutoEventGroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAutoEventIsPoolThread, Me.Label23, Me.lblAutoEventThreadNum, Me.Label25, Me.lblAutoEventStatus})
        Me.AutoEventGroupBox.Dock = CType(resources.GetObject("AutoEventGroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.AutoEventGroupBox.Enabled = CType(resources.GetObject("AutoEventGroupBox.Enabled"), Boolean)
        Me.AutoEventGroupBox.Font = CType(resources.GetObject("AutoEventGroupBox.Font"), System.Drawing.Font)
        Me.AutoEventGroupBox.ImeMode = CType(resources.GetObject("AutoEventGroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.AutoEventGroupBox.Location = CType(resources.GetObject("AutoEventGroupBox.Location"), System.Drawing.Point)
        Me.AutoEventGroupBox.Name = "AutoEventGroupBox"
        Me.AutoEventGroupBox.RightToLeft = CType(resources.GetObject("AutoEventGroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.AutoEventGroupBox.Size = CType(resources.GetObject("AutoEventGroupBox.Size"), System.Drawing.Size)
        Me.AutoEventGroupBox.TabIndex = CType(resources.GetObject("AutoEventGroupBox.TabIndex"), Integer)
        Me.AutoEventGroupBox.TabStop = False
        Me.AutoEventGroupBox.Text = resources.GetString("AutoEventGroupBox.Text")
        Me.AutoEventGroupBox.Visible = CType(resources.GetObject("AutoEventGroupBox.Visible"), Boolean)
        '
        'lblAutoEventIsPoolThread
        '
        Me.lblAutoEventIsPoolThread.AccessibleDescription = resources.GetString("lblAutoEventIsPoolThread.AccessibleDescription")
        Me.lblAutoEventIsPoolThread.AccessibleName = resources.GetString("lblAutoEventIsPoolThread.AccessibleName")
        Me.lblAutoEventIsPoolThread.Anchor = CType(resources.GetObject("lblAutoEventIsPoolThread.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblAutoEventIsPoolThread.AutoSize = CType(resources.GetObject("lblAutoEventIsPoolThread.AutoSize"), Boolean)
        Me.lblAutoEventIsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblAutoEventIsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAutoEventIsPoolThread.Dock = CType(resources.GetObject("lblAutoEventIsPoolThread.Dock"), System.Windows.Forms.DockStyle)
        Me.lblAutoEventIsPoolThread.Enabled = CType(resources.GetObject("lblAutoEventIsPoolThread.Enabled"), Boolean)
        Me.lblAutoEventIsPoolThread.Font = CType(resources.GetObject("lblAutoEventIsPoolThread.Font"), System.Drawing.Font)
        Me.lblAutoEventIsPoolThread.Image = CType(resources.GetObject("lblAutoEventIsPoolThread.Image"), System.Drawing.Image)
        Me.lblAutoEventIsPoolThread.ImageAlign = CType(resources.GetObject("lblAutoEventIsPoolThread.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblAutoEventIsPoolThread.ImageIndex = CType(resources.GetObject("lblAutoEventIsPoolThread.ImageIndex"), Integer)
        Me.lblAutoEventIsPoolThread.ImeMode = CType(resources.GetObject("lblAutoEventIsPoolThread.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblAutoEventIsPoolThread.Location = CType(resources.GetObject("lblAutoEventIsPoolThread.Location"), System.Drawing.Point)
        Me.lblAutoEventIsPoolThread.Name = "lblAutoEventIsPoolThread"
        Me.lblAutoEventIsPoolThread.RightToLeft = CType(resources.GetObject("lblAutoEventIsPoolThread.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblAutoEventIsPoolThread.Size = CType(resources.GetObject("lblAutoEventIsPoolThread.Size"), System.Drawing.Size)
        Me.lblAutoEventIsPoolThread.TabIndex = CType(resources.GetObject("lblAutoEventIsPoolThread.TabIndex"), Integer)
        Me.lblAutoEventIsPoolThread.Text = resources.GetString("lblAutoEventIsPoolThread.Text")
        Me.lblAutoEventIsPoolThread.TextAlign = CType(resources.GetObject("lblAutoEventIsPoolThread.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblAutoEventIsPoolThread.Visible = CType(resources.GetObject("lblAutoEventIsPoolThread.Visible"), Boolean)
        '
        'Label23
        '
        Me.Label23.AccessibleDescription = CType(resources.GetObject("Label23.AccessibleDescription"), String)
        Me.Label23.AccessibleName = CType(resources.GetObject("Label23.AccessibleName"), String)
        Me.Label23.Anchor = CType(resources.GetObject("Label23.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = CType(resources.GetObject("Label23.AutoSize"), Boolean)
        Me.Label23.Dock = CType(resources.GetObject("Label23.Dock"), System.Windows.Forms.DockStyle)
        Me.Label23.Enabled = CType(resources.GetObject("Label23.Enabled"), Boolean)
        Me.Label23.Font = CType(resources.GetObject("Label23.Font"), System.Drawing.Font)
        Me.Label23.Image = CType(resources.GetObject("Label23.Image"), System.Drawing.Image)
        Me.Label23.ImageAlign = CType(resources.GetObject("Label23.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label23.ImageIndex = CType(resources.GetObject("Label23.ImageIndex"), Integer)
        Me.Label23.ImeMode = CType(resources.GetObject("Label23.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label23.Location = CType(resources.GetObject("Label23.Location"), System.Drawing.Point)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = CType(resources.GetObject("Label23.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label23.Size = CType(resources.GetObject("Label23.Size"), System.Drawing.Size)
        Me.Label23.TabIndex = CType(resources.GetObject("Label23.TabIndex"), Integer)
        Me.Label23.Text = resources.GetString("Label23.Text")
        Me.Label23.TextAlign = CType(resources.GetObject("Label23.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label23.Visible = CType(resources.GetObject("Label23.Visible"), Boolean)
        '
        'lblAutoEventThreadNum
        '
        Me.lblAutoEventThreadNum.AccessibleDescription = resources.GetString("lblAutoEventThreadNum.AccessibleDescription")
        Me.lblAutoEventThreadNum.AccessibleName = resources.GetString("lblAutoEventThreadNum.AccessibleName")
        Me.lblAutoEventThreadNum.Anchor = CType(resources.GetObject("lblAutoEventThreadNum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblAutoEventThreadNum.AutoSize = CType(resources.GetObject("lblAutoEventThreadNum.AutoSize"), Boolean)
        Me.lblAutoEventThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblAutoEventThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAutoEventThreadNum.Dock = CType(resources.GetObject("lblAutoEventThreadNum.Dock"), System.Windows.Forms.DockStyle)
        Me.lblAutoEventThreadNum.Enabled = CType(resources.GetObject("lblAutoEventThreadNum.Enabled"), Boolean)
        Me.lblAutoEventThreadNum.Font = CType(resources.GetObject("lblAutoEventThreadNum.Font"), System.Drawing.Font)
        Me.lblAutoEventThreadNum.Image = CType(resources.GetObject("lblAutoEventThreadNum.Image"), System.Drawing.Image)
        Me.lblAutoEventThreadNum.ImageAlign = CType(resources.GetObject("lblAutoEventThreadNum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblAutoEventThreadNum.ImageIndex = CType(resources.GetObject("lblAutoEventThreadNum.ImageIndex"), Integer)
        Me.lblAutoEventThreadNum.ImeMode = CType(resources.GetObject("lblAutoEventThreadNum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblAutoEventThreadNum.Location = CType(resources.GetObject("lblAutoEventThreadNum.Location"), System.Drawing.Point)
        Me.lblAutoEventThreadNum.Name = "lblAutoEventThreadNum"
        Me.lblAutoEventThreadNum.RightToLeft = CType(resources.GetObject("lblAutoEventThreadNum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblAutoEventThreadNum.Size = CType(resources.GetObject("lblAutoEventThreadNum.Size"), System.Drawing.Size)
        Me.lblAutoEventThreadNum.TabIndex = CType(resources.GetObject("lblAutoEventThreadNum.TabIndex"), Integer)
        Me.lblAutoEventThreadNum.Text = resources.GetString("lblAutoEventThreadNum.Text")
        Me.lblAutoEventThreadNum.TextAlign = CType(resources.GetObject("lblAutoEventThreadNum.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblAutoEventThreadNum.Visible = CType(resources.GetObject("lblAutoEventThreadNum.Visible"), Boolean)
        '
        'Label25
        '
        Me.Label25.AccessibleDescription = CType(resources.GetObject("Label25.AccessibleDescription"), String)
        Me.Label25.AccessibleName = CType(resources.GetObject("Label25.AccessibleName"), String)
        Me.Label25.Anchor = CType(resources.GetObject("Label25.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = CType(resources.GetObject("Label25.AutoSize"), Boolean)
        Me.Label25.Dock = CType(resources.GetObject("Label25.Dock"), System.Windows.Forms.DockStyle)
        Me.Label25.Enabled = CType(resources.GetObject("Label25.Enabled"), Boolean)
        Me.Label25.Font = CType(resources.GetObject("Label25.Font"), System.Drawing.Font)
        Me.Label25.Image = CType(resources.GetObject("Label25.Image"), System.Drawing.Image)
        Me.Label25.ImageAlign = CType(resources.GetObject("Label25.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label25.ImageIndex = CType(resources.GetObject("Label25.ImageIndex"), Integer)
        Me.Label25.ImeMode = CType(resources.GetObject("Label25.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label25.Location = CType(resources.GetObject("Label25.Location"), System.Drawing.Point)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = CType(resources.GetObject("Label25.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label25.Size = CType(resources.GetObject("Label25.Size"), System.Drawing.Size)
        Me.Label25.TabIndex = CType(resources.GetObject("Label25.TabIndex"), Integer)
        Me.Label25.Text = resources.GetString("Label25.Text")
        Me.Label25.TextAlign = CType(resources.GetObject("Label25.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label25.Visible = CType(resources.GetObject("Label25.Visible"), Boolean)
        '
        'lblAutoEventStatus
        '
        Me.lblAutoEventStatus.AccessibleDescription = resources.GetString("lblAutoEventStatus.AccessibleDescription")
        Me.lblAutoEventStatus.AccessibleName = resources.GetString("lblAutoEventStatus.AccessibleName")
        Me.lblAutoEventStatus.Anchor = CType(resources.GetObject("lblAutoEventStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblAutoEventStatus.AutoSize = CType(resources.GetObject("lblAutoEventStatus.AutoSize"), Boolean)
        Me.lblAutoEventStatus.Dock = CType(resources.GetObject("lblAutoEventStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.lblAutoEventStatus.Enabled = CType(resources.GetObject("lblAutoEventStatus.Enabled"), Boolean)
        Me.lblAutoEventStatus.Font = CType(resources.GetObject("lblAutoEventStatus.Font"), System.Drawing.Font)
        Me.lblAutoEventStatus.ForeColor = System.Drawing.Color.Red
        Me.lblAutoEventStatus.Image = CType(resources.GetObject("lblAutoEventStatus.Image"), System.Drawing.Image)
        Me.lblAutoEventStatus.ImageAlign = CType(resources.GetObject("lblAutoEventStatus.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblAutoEventStatus.ImageIndex = CType(resources.GetObject("lblAutoEventStatus.ImageIndex"), Integer)
        Me.lblAutoEventStatus.ImeMode = CType(resources.GetObject("lblAutoEventStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblAutoEventStatus.Location = CType(resources.GetObject("lblAutoEventStatus.Location"), System.Drawing.Point)
        Me.lblAutoEventStatus.Name = "lblAutoEventStatus"
        Me.lblAutoEventStatus.RightToLeft = CType(resources.GetObject("lblAutoEventStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblAutoEventStatus.Size = CType(resources.GetObject("lblAutoEventStatus.Size"), System.Drawing.Size)
        Me.lblAutoEventStatus.TabIndex = CType(resources.GetObject("lblAutoEventStatus.TabIndex"), Integer)
        Me.lblAutoEventStatus.Text = resources.GetString("lblAutoEventStatus.Text")
        Me.lblAutoEventStatus.TextAlign = CType(resources.GetObject("lblAutoEventStatus.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblAutoEventStatus.Visible = CType(resources.GetObject("lblAutoEventStatus.Visible"), Boolean)
        '
        'ManualEventGroupBox
        '
        Me.ManualEventGroupBox.AccessibleDescription = resources.GetString("ManualEventGroupBox.AccessibleDescription")
        Me.ManualEventGroupBox.AccessibleName = resources.GetString("ManualEventGroupBox.AccessibleName")
        Me.ManualEventGroupBox.Anchor = CType(resources.GetObject("ManualEventGroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ManualEventGroupBox.BackgroundImage = CType(resources.GetObject("ManualEventGroupBox.BackgroundImage"), System.Drawing.Image)
        Me.ManualEventGroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblManualEventIsPoolThread, Me.Label18, Me.lblManualEventThreadNum, Me.Label20, Me.lblManualEventThreadStatus})
        Me.ManualEventGroupBox.Dock = CType(resources.GetObject("ManualEventGroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.ManualEventGroupBox.Enabled = CType(resources.GetObject("ManualEventGroupBox.Enabled"), Boolean)
        Me.ManualEventGroupBox.Font = CType(resources.GetObject("ManualEventGroupBox.Font"), System.Drawing.Font)
        Me.ManualEventGroupBox.ImeMode = CType(resources.GetObject("ManualEventGroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ManualEventGroupBox.Location = CType(resources.GetObject("ManualEventGroupBox.Location"), System.Drawing.Point)
        Me.ManualEventGroupBox.Name = "ManualEventGroupBox"
        Me.ManualEventGroupBox.RightToLeft = CType(resources.GetObject("ManualEventGroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ManualEventGroupBox.Size = CType(resources.GetObject("ManualEventGroupBox.Size"), System.Drawing.Size)
        Me.ManualEventGroupBox.TabIndex = CType(resources.GetObject("ManualEventGroupBox.TabIndex"), Integer)
        Me.ManualEventGroupBox.TabStop = False
        Me.ManualEventGroupBox.Text = resources.GetString("ManualEventGroupBox.Text")
        Me.ManualEventGroupBox.Visible = CType(resources.GetObject("ManualEventGroupBox.Visible"), Boolean)
        '
        'lblManualEventIsPoolThread
        '
        Me.lblManualEventIsPoolThread.AccessibleDescription = resources.GetString("lblManualEventIsPoolThread.AccessibleDescription")
        Me.lblManualEventIsPoolThread.AccessibleName = resources.GetString("lblManualEventIsPoolThread.AccessibleName")
        Me.lblManualEventIsPoolThread.Anchor = CType(resources.GetObject("lblManualEventIsPoolThread.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblManualEventIsPoolThread.AutoSize = CType(resources.GetObject("lblManualEventIsPoolThread.AutoSize"), Boolean)
        Me.lblManualEventIsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblManualEventIsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblManualEventIsPoolThread.Dock = CType(resources.GetObject("lblManualEventIsPoolThread.Dock"), System.Windows.Forms.DockStyle)
        Me.lblManualEventIsPoolThread.Enabled = CType(resources.GetObject("lblManualEventIsPoolThread.Enabled"), Boolean)
        Me.lblManualEventIsPoolThread.Font = CType(resources.GetObject("lblManualEventIsPoolThread.Font"), System.Drawing.Font)
        Me.lblManualEventIsPoolThread.Image = CType(resources.GetObject("lblManualEventIsPoolThread.Image"), System.Drawing.Image)
        Me.lblManualEventIsPoolThread.ImageAlign = CType(resources.GetObject("lblManualEventIsPoolThread.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblManualEventIsPoolThread.ImageIndex = CType(resources.GetObject("lblManualEventIsPoolThread.ImageIndex"), Integer)
        Me.lblManualEventIsPoolThread.ImeMode = CType(resources.GetObject("lblManualEventIsPoolThread.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblManualEventIsPoolThread.Location = CType(resources.GetObject("lblManualEventIsPoolThread.Location"), System.Drawing.Point)
        Me.lblManualEventIsPoolThread.Name = "lblManualEventIsPoolThread"
        Me.lblManualEventIsPoolThread.RightToLeft = CType(resources.GetObject("lblManualEventIsPoolThread.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblManualEventIsPoolThread.Size = CType(resources.GetObject("lblManualEventIsPoolThread.Size"), System.Drawing.Size)
        Me.lblManualEventIsPoolThread.TabIndex = CType(resources.GetObject("lblManualEventIsPoolThread.TabIndex"), Integer)
        Me.lblManualEventIsPoolThread.Text = resources.GetString("lblManualEventIsPoolThread.Text")
        Me.lblManualEventIsPoolThread.TextAlign = CType(resources.GetObject("lblManualEventIsPoolThread.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblManualEventIsPoolThread.Visible = CType(resources.GetObject("lblManualEventIsPoolThread.Visible"), Boolean)
        '
        'Label18
        '
        Me.Label18.AccessibleDescription = CType(resources.GetObject("Label18.AccessibleDescription"), String)
        Me.Label18.AccessibleName = CType(resources.GetObject("Label18.AccessibleName"), String)
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
        'lblManualEventThreadNum
        '
        Me.lblManualEventThreadNum.AccessibleDescription = resources.GetString("lblManualEventThreadNum.AccessibleDescription")
        Me.lblManualEventThreadNum.AccessibleName = resources.GetString("lblManualEventThreadNum.AccessibleName")
        Me.lblManualEventThreadNum.Anchor = CType(resources.GetObject("lblManualEventThreadNum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblManualEventThreadNum.AutoSize = CType(resources.GetObject("lblManualEventThreadNum.AutoSize"), Boolean)
        Me.lblManualEventThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblManualEventThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblManualEventThreadNum.Dock = CType(resources.GetObject("lblManualEventThreadNum.Dock"), System.Windows.Forms.DockStyle)
        Me.lblManualEventThreadNum.Enabled = CType(resources.GetObject("lblManualEventThreadNum.Enabled"), Boolean)
        Me.lblManualEventThreadNum.Font = CType(resources.GetObject("lblManualEventThreadNum.Font"), System.Drawing.Font)
        Me.lblManualEventThreadNum.Image = CType(resources.GetObject("lblManualEventThreadNum.Image"), System.Drawing.Image)
        Me.lblManualEventThreadNum.ImageAlign = CType(resources.GetObject("lblManualEventThreadNum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblManualEventThreadNum.ImageIndex = CType(resources.GetObject("lblManualEventThreadNum.ImageIndex"), Integer)
        Me.lblManualEventThreadNum.ImeMode = CType(resources.GetObject("lblManualEventThreadNum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblManualEventThreadNum.Location = CType(resources.GetObject("lblManualEventThreadNum.Location"), System.Drawing.Point)
        Me.lblManualEventThreadNum.Name = "lblManualEventThreadNum"
        Me.lblManualEventThreadNum.RightToLeft = CType(resources.GetObject("lblManualEventThreadNum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblManualEventThreadNum.Size = CType(resources.GetObject("lblManualEventThreadNum.Size"), System.Drawing.Size)
        Me.lblManualEventThreadNum.TabIndex = CType(resources.GetObject("lblManualEventThreadNum.TabIndex"), Integer)
        Me.lblManualEventThreadNum.Text = resources.GetString("lblManualEventThreadNum.Text")
        Me.lblManualEventThreadNum.TextAlign = CType(resources.GetObject("lblManualEventThreadNum.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblManualEventThreadNum.Visible = CType(resources.GetObject("lblManualEventThreadNum.Visible"), Boolean)
        '
        'Label20
        '
        Me.Label20.AccessibleDescription = CType(resources.GetObject("Label20.AccessibleDescription"), String)
        Me.Label20.AccessibleName = CType(resources.GetObject("Label20.AccessibleName"), String)
        Me.Label20.Anchor = CType(resources.GetObject("Label20.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = CType(resources.GetObject("Label20.AutoSize"), Boolean)
        Me.Label20.Dock = CType(resources.GetObject("Label20.Dock"), System.Windows.Forms.DockStyle)
        Me.Label20.Enabled = CType(resources.GetObject("Label20.Enabled"), Boolean)
        Me.Label20.Font = CType(resources.GetObject("Label20.Font"), System.Drawing.Font)
        Me.Label20.Image = CType(resources.GetObject("Label20.Image"), System.Drawing.Image)
        Me.Label20.ImageAlign = CType(resources.GetObject("Label20.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label20.ImageIndex = CType(resources.GetObject("Label20.ImageIndex"), Integer)
        Me.Label20.ImeMode = CType(resources.GetObject("Label20.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label20.Location = CType(resources.GetObject("Label20.Location"), System.Drawing.Point)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = CType(resources.GetObject("Label20.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label20.Size = CType(resources.GetObject("Label20.Size"), System.Drawing.Size)
        Me.Label20.TabIndex = CType(resources.GetObject("Label20.TabIndex"), Integer)
        Me.Label20.Text = resources.GetString("Label20.Text")
        Me.Label20.TextAlign = CType(resources.GetObject("Label20.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label20.Visible = CType(resources.GetObject("Label20.Visible"), Boolean)
        '
        'lblManualEventThreadStatus
        '
        Me.lblManualEventThreadStatus.AccessibleDescription = resources.GetString("lblManualEventThreadStatus.AccessibleDescription")
        Me.lblManualEventThreadStatus.AccessibleName = resources.GetString("lblManualEventThreadStatus.AccessibleName")
        Me.lblManualEventThreadStatus.Anchor = CType(resources.GetObject("lblManualEventThreadStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblManualEventThreadStatus.AutoSize = CType(resources.GetObject("lblManualEventThreadStatus.AutoSize"), Boolean)
        Me.lblManualEventThreadStatus.Dock = CType(resources.GetObject("lblManualEventThreadStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.lblManualEventThreadStatus.Enabled = CType(resources.GetObject("lblManualEventThreadStatus.Enabled"), Boolean)
        Me.lblManualEventThreadStatus.Font = CType(resources.GetObject("lblManualEventThreadStatus.Font"), System.Drawing.Font)
        Me.lblManualEventThreadStatus.ForeColor = System.Drawing.Color.Red
        Me.lblManualEventThreadStatus.Image = CType(resources.GetObject("lblManualEventThreadStatus.Image"), System.Drawing.Image)
        Me.lblManualEventThreadStatus.ImageAlign = CType(resources.GetObject("lblManualEventThreadStatus.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblManualEventThreadStatus.ImageIndex = CType(resources.GetObject("lblManualEventThreadStatus.ImageIndex"), Integer)
        Me.lblManualEventThreadStatus.ImeMode = CType(resources.GetObject("lblManualEventThreadStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblManualEventThreadStatus.Location = CType(resources.GetObject("lblManualEventThreadStatus.Location"), System.Drawing.Point)
        Me.lblManualEventThreadStatus.Name = "lblManualEventThreadStatus"
        Me.lblManualEventThreadStatus.RightToLeft = CType(resources.GetObject("lblManualEventThreadStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblManualEventThreadStatus.Size = CType(resources.GetObject("lblManualEventThreadStatus.Size"), System.Drawing.Size)
        Me.lblManualEventThreadStatus.TabIndex = CType(resources.GetObject("lblManualEventThreadStatus.TabIndex"), Integer)
        Me.lblManualEventThreadStatus.Text = resources.GetString("lblManualEventThreadStatus.Text")
        Me.lblManualEventThreadStatus.TextAlign = CType(resources.GetObject("lblManualEventThreadStatus.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblManualEventThreadStatus.Visible = CType(resources.GetObject("lblManualEventThreadStatus.Visible"), Boolean)
        '
        'MutexGroupBox
        '
        Me.MutexGroupBox.AccessibleDescription = resources.GetString("MutexGroupBox.AccessibleDescription")
        Me.MutexGroupBox.AccessibleName = resources.GetString("MutexGroupBox.AccessibleName")
        Me.MutexGroupBox.Anchor = CType(resources.GetObject("MutexGroupBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.MutexGroupBox.BackgroundImage = CType(resources.GetObject("MutexGroupBox.BackgroundImage"), System.Drawing.Image)
        Me.MutexGroupBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMutexIsPoolThread, Me.Label10, Me.lblMutexThreadNum, Me.Label13, Me.lblMutexThreadStatus})
        Me.MutexGroupBox.Dock = CType(resources.GetObject("MutexGroupBox.Dock"), System.Windows.Forms.DockStyle)
        Me.MutexGroupBox.Enabled = CType(resources.GetObject("MutexGroupBox.Enabled"), Boolean)
        Me.MutexGroupBox.Font = CType(resources.GetObject("MutexGroupBox.Font"), System.Drawing.Font)
        Me.MutexGroupBox.ImeMode = CType(resources.GetObject("MutexGroupBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.MutexGroupBox.Location = CType(resources.GetObject("MutexGroupBox.Location"), System.Drawing.Point)
        Me.MutexGroupBox.Name = "MutexGroupBox"
        Me.MutexGroupBox.RightToLeft = CType(resources.GetObject("MutexGroupBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.MutexGroupBox.Size = CType(resources.GetObject("MutexGroupBox.Size"), System.Drawing.Size)
        Me.MutexGroupBox.TabIndex = CType(resources.GetObject("MutexGroupBox.TabIndex"), Integer)
        Me.MutexGroupBox.TabStop = False
        Me.MutexGroupBox.Text = resources.GetString("MutexGroupBox.Text")
        Me.MutexGroupBox.Visible = CType(resources.GetObject("MutexGroupBox.Visible"), Boolean)
        '
        'lblMutexIsPoolThread
        '
        Me.lblMutexIsPoolThread.AccessibleDescription = resources.GetString("lblMutexIsPoolThread.AccessibleDescription")
        Me.lblMutexIsPoolThread.AccessibleName = resources.GetString("lblMutexIsPoolThread.AccessibleName")
        Me.lblMutexIsPoolThread.Anchor = CType(resources.GetObject("lblMutexIsPoolThread.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblMutexIsPoolThread.AutoSize = CType(resources.GetObject("lblMutexIsPoolThread.AutoSize"), Boolean)
        Me.lblMutexIsPoolThread.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMutexIsPoolThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMutexIsPoolThread.Dock = CType(resources.GetObject("lblMutexIsPoolThread.Dock"), System.Windows.Forms.DockStyle)
        Me.lblMutexIsPoolThread.Enabled = CType(resources.GetObject("lblMutexIsPoolThread.Enabled"), Boolean)
        Me.lblMutexIsPoolThread.Font = CType(resources.GetObject("lblMutexIsPoolThread.Font"), System.Drawing.Font)
        Me.lblMutexIsPoolThread.Image = CType(resources.GetObject("lblMutexIsPoolThread.Image"), System.Drawing.Image)
        Me.lblMutexIsPoolThread.ImageAlign = CType(resources.GetObject("lblMutexIsPoolThread.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblMutexIsPoolThread.ImageIndex = CType(resources.GetObject("lblMutexIsPoolThread.ImageIndex"), Integer)
        Me.lblMutexIsPoolThread.ImeMode = CType(resources.GetObject("lblMutexIsPoolThread.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblMutexIsPoolThread.Location = CType(resources.GetObject("lblMutexIsPoolThread.Location"), System.Drawing.Point)
        Me.lblMutexIsPoolThread.Name = "lblMutexIsPoolThread"
        Me.lblMutexIsPoolThread.RightToLeft = CType(resources.GetObject("lblMutexIsPoolThread.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblMutexIsPoolThread.Size = CType(resources.GetObject("lblMutexIsPoolThread.Size"), System.Drawing.Size)
        Me.lblMutexIsPoolThread.TabIndex = CType(resources.GetObject("lblMutexIsPoolThread.TabIndex"), Integer)
        Me.lblMutexIsPoolThread.Text = resources.GetString("lblMutexIsPoolThread.Text")
        Me.lblMutexIsPoolThread.TextAlign = CType(resources.GetObject("lblMutexIsPoolThread.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblMutexIsPoolThread.Visible = CType(resources.GetObject("lblMutexIsPoolThread.Visible"), Boolean)
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
        'lblMutexThreadNum
        '
        Me.lblMutexThreadNum.AccessibleDescription = resources.GetString("lblMutexThreadNum.AccessibleDescription")
        Me.lblMutexThreadNum.AccessibleName = resources.GetString("lblMutexThreadNum.AccessibleName")
        Me.lblMutexThreadNum.Anchor = CType(resources.GetObject("lblMutexThreadNum.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblMutexThreadNum.AutoSize = CType(resources.GetObject("lblMutexThreadNum.AutoSize"), Boolean)
        Me.lblMutexThreadNum.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMutexThreadNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMutexThreadNum.Dock = CType(resources.GetObject("lblMutexThreadNum.Dock"), System.Windows.Forms.DockStyle)
        Me.lblMutexThreadNum.Enabled = CType(resources.GetObject("lblMutexThreadNum.Enabled"), Boolean)
        Me.lblMutexThreadNum.Font = CType(resources.GetObject("lblMutexThreadNum.Font"), System.Drawing.Font)
        Me.lblMutexThreadNum.Image = CType(resources.GetObject("lblMutexThreadNum.Image"), System.Drawing.Image)
        Me.lblMutexThreadNum.ImageAlign = CType(resources.GetObject("lblMutexThreadNum.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblMutexThreadNum.ImageIndex = CType(resources.GetObject("lblMutexThreadNum.ImageIndex"), Integer)
        Me.lblMutexThreadNum.ImeMode = CType(resources.GetObject("lblMutexThreadNum.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblMutexThreadNum.Location = CType(resources.GetObject("lblMutexThreadNum.Location"), System.Drawing.Point)
        Me.lblMutexThreadNum.Name = "lblMutexThreadNum"
        Me.lblMutexThreadNum.RightToLeft = CType(resources.GetObject("lblMutexThreadNum.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblMutexThreadNum.Size = CType(resources.GetObject("lblMutexThreadNum.Size"), System.Drawing.Size)
        Me.lblMutexThreadNum.TabIndex = CType(resources.GetObject("lblMutexThreadNum.TabIndex"), Integer)
        Me.lblMutexThreadNum.Text = resources.GetString("lblMutexThreadNum.Text")
        Me.lblMutexThreadNum.TextAlign = CType(resources.GetObject("lblMutexThreadNum.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblMutexThreadNum.Visible = CType(resources.GetObject("lblMutexThreadNum.Visible"), Boolean)
        '
        'Label13
        '
        Me.Label13.AccessibleDescription = CType(resources.GetObject("Label13.AccessibleDescription"), String)
        Me.Label13.AccessibleName = CType(resources.GetObject("Label13.AccessibleName"), String)
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
        'lblMutexThreadStatus
        '
        Me.lblMutexThreadStatus.AccessibleDescription = resources.GetString("lblMutexThreadStatus.AccessibleDescription")
        Me.lblMutexThreadStatus.AccessibleName = resources.GetString("lblMutexThreadStatus.AccessibleName")
        Me.lblMutexThreadStatus.Anchor = CType(resources.GetObject("lblMutexThreadStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblMutexThreadStatus.AutoSize = CType(resources.GetObject("lblMutexThreadStatus.AutoSize"), Boolean)
        Me.lblMutexThreadStatus.Dock = CType(resources.GetObject("lblMutexThreadStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.lblMutexThreadStatus.Enabled = CType(resources.GetObject("lblMutexThreadStatus.Enabled"), Boolean)
        Me.lblMutexThreadStatus.Font = CType(resources.GetObject("lblMutexThreadStatus.Font"), System.Drawing.Font)
        Me.lblMutexThreadStatus.ForeColor = System.Drawing.Color.Red
        Me.lblMutexThreadStatus.Image = CType(resources.GetObject("lblMutexThreadStatus.Image"), System.Drawing.Image)
        Me.lblMutexThreadStatus.ImageAlign = CType(resources.GetObject("lblMutexThreadStatus.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblMutexThreadStatus.ImageIndex = CType(resources.GetObject("lblMutexThreadStatus.ImageIndex"), Integer)
        Me.lblMutexThreadStatus.ImeMode = CType(resources.GetObject("lblMutexThreadStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblMutexThreadStatus.Location = CType(resources.GetObject("lblMutexThreadStatus.Location"), System.Drawing.Point)
        Me.lblMutexThreadStatus.Name = "lblMutexThreadStatus"
        Me.lblMutexThreadStatus.RightToLeft = CType(resources.GetObject("lblMutexThreadStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblMutexThreadStatus.Size = CType(resources.GetObject("lblMutexThreadStatus.Size"), System.Drawing.Size)
        Me.lblMutexThreadStatus.TabIndex = CType(resources.GetObject("lblMutexThreadStatus.TabIndex"), Integer)
        Me.lblMutexThreadStatus.Text = resources.GetString("lblMutexThreadStatus.Text")
        Me.lblMutexThreadStatus.TextAlign = CType(resources.GetObject("lblMutexThreadStatus.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblMutexThreadStatus.Visible = CType(resources.GetObject("lblMutexThreadStatus.Visible"), Boolean)
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
        Me.FunctionTabPage.ResumeLayout(False)
        Me.Process3GroupBox.ResumeLayout(False)
        Me.Process2GroupBox.ResumeLayout(False)
        Me.Process1GroupBox.ResumeLayout(False)
        Me.TimersTabPage.ResumeLayout(False)
        Me.Timer2GroupBox.ResumeLayout(False)
        Me.Timer1GroupBox.ResumeLayout(False)
        Me.SyncObjectsTabPage.ResumeLayout(False)
        Me.AutoEventGroupBox.ResumeLayout(False)
        Me.ManualEventGroupBox.ResumeLayout(False)
        Me.MutexGroupBox.ResumeLayout(False)
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

    ' This subroutine calls three process consecutively, without using threading.
    Private Sub btnNonthreaded_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNonthreaded.Click
        ' Do not allow another process to be kicked off till this one is finished.
        btnNonthreaded.Enabled = False
        btnThreaded.Enabled = False
        btnThreadPool.Enabled = False

        ' Prepare the shared variables to run
        ProcessGroup.PrepareToRun()

        ' Run each process.
        processGroup1.Run()
        processGroup2.Run()
        processGroup3.Run()
    End Sub

    ' This subroutine releases the mutex, allowing OnMutexReleased to fire.
    Private Sub btnReleaseMutex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReleaseMutex.Click
        ' If mutex is released again before resetting exception will be thrown, so
        ' disable the buttons to allow this.
        btnReleaseMutex.Enabled = False
        btnSetReleaseAll.Enabled = False

        mutex1.ReleaseMutex()
    End Sub

    ' This signals the Auto Reset event, allowing OnAutoEventSet to fire.
    Private Sub btnSetAutoEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAutoEvent.Click
        ' Do not allow Event to be set again till OnAutoEventSet finishes
        btnSetAutoEvent.Enabled = False
        btnSetReleaseAll.Enabled = False

        autoResetEvent1.Set()
    End Sub

    ' This signals the Manual Reset event, allowing OnManualEventSet to fire.
    Private Sub btnSetManualEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetManualEvent.Click
        ' Do not allow the event to be set again, until it has been reset.
        btnSetManualEvent.Enabled = False
        btnSetReleaseAll.Enabled = False

        manualResetEvent1.Set()
    End Sub

    ' This releases the mutex, and sets the auto and manual reset events.
    Private Sub btnSetReleaseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetReleaseAll.Click
        ' Disable all release and set buttons till each finishes.
        btnReleaseMutex.Enabled = False
        btnSetManualEvent.Enabled = False
        btnSetAutoEvent.Enabled = False
        btnSetReleaseAll.Enabled = False

        mutex1.ReleaseMutex()
        manualResetEvent1.Set()
        autoResetEvent1.Set()
    End Sub

    ' This starts and stops the timers.  The button caption toggles between start and 
    ' stop.
    Private Sub btnStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartStop.Click
        ' If caption is "Start" then start a 1 second timer and a 2 second timer, 
        ' and change the caption to stop, otherwise stop the timers and change the
        ' caption to "Start"
        If btnStartStop.Text = "&Start" Then
            btnStartStop.Text = "&Stop"
            timerGroup1.StartTimer(1000)
            timerGroup2.StartTimer(2000)
        Else
            btnStartStop.Text = "&Start"
            timerGroup1.StopTimer()
            timerGroup2.StopTimer()
        End If
    End Sub

    ' This subroutine calls three processes in three separate threads.
    Private Sub btnThreaded_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThreaded.Click
        ' Do not allow another process to be kicked off till this one is finished.
        btnNonthreaded.Enabled = False
        btnThreaded.Enabled = False
        btnThreadPool.Enabled = False

        ' Prepare the shared variables to run
        ProcessGroup.PrepareToRun()

        ' Run each process in its own thread.
        processGroup1.StartThread()
        processGroup2.StartThread()
        processGroup3.StartThread()
    End Sub

    ' This subroutine calls requests the ThreadPool to run the three processes.
    Private Sub btnThreadPool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThreadPool.Click
        ' Do not allow another process to be kicked off till this one is finished.
        btnNonthreaded.Enabled = False
        btnThreaded.Enabled = False
        btnThreadPool.Enabled = False

        ' Prepare the shared variables to run
        ProcessGroup.PrepareToRun()

        ' Send requests to ThreadPool to run the three processes.
        processGroup1.StartPooledThread()
        processGroup2.StartPooledThread()
        processGroup3.StartPooledThread()
    End Sub


    ' This subroutine creates an auto reset event, and puts the auto reset process into
    ' waiting until the event is set.
    Private Sub btnWaitForAutoEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitForAutoEvent.Click
        ' Create the auto reset event starting with a state not signalled. 
        autoResetEvent1 = New Threading.AutoResetEvent(False)

        ' Create a callback to function OnAutoEventSet
        Dim callback As New Threading.WaitOrTimerCallback(AddressOf OnAutoEventSet)

        ' Register the event to fire OnAutoEventSet when set, specifying it to continue 
        ' to monitor the event even after it has run once.  This puts the process into
        ' waiting.
        Threading.ThreadPool.RegisterWaitForSingleObject(autoResetEvent1, callback, _
            Nothing, Threading.Timeout.Infinite, False)

        ' Show that process is waiting in blue.
        lblAutoEventStatus.Text = "Waiting"
        lblAutoEventStatus.ForeColor = Color.Blue

        ' Allow the event to be set, but don't let it be put into waiting again until
        ' it has already been set.
        btnWaitForAutoEvent.Enabled = False
        btnSetAutoEvent.Enabled = True

        ' If mutex and events are all in waiting status, allow SetRelease all button
        If Not btnWaitForManualEvent.Enabled And Not btnWaitForMutex.Enabled Then
            btnSetReleaseAll.Enabled = True
        End If
    End Sub

    ' This subroutine creates an manual reset event, and puts the manual reset process 
    ' into waiting until the event is set.
    Private Sub btnWaitForManualEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitForManualEvent.Click
        ' Create the auto reset event starting with a state not signalled. 
        manualResetEvent1 = New Threading.ManualResetEvent(False)

        ' Create a callback to function OnManualEventSet
        Dim callback As New Threading.WaitOrTimerCallback(AddressOf OnManualEventSet)

        ' Register the event to fire OnManualEventSet when set, specifying it to run
        ' only once.  This puts the process into waiting.
        Threading.ThreadPool.RegisterWaitForSingleObject(manualResetEvent1, callback, _
            Nothing, Threading.Timeout.Infinite, True)

        ' Show that process is waiting in blue.
        lblManualEventThreadStatus.Text = "Waiting"
        lblManualEventThreadStatus.ForeColor = Color.Blue

        ' Allow the event to be set, but don't let it be put into waiting again until
        ' it has already been set.
        btnWaitForManualEvent.Enabled = False
        btnSetManualEvent.Enabled = True

        ' If mutex and events are all in waiting status, allow SetRelease all button
        If Not btnWaitForMutex.Enabled And Not btnWaitForAutoEvent.Enabled Then
            btnSetReleaseAll.Enabled = True
        End If
    End Sub

    ' This subroutine creates an mutex, and puts the mutex process into waiting until
    ' the mutex is released.
    Private Sub btnWaitForMutex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitForMutex.Click
        ' Create the mutex, setting the starting owner to this thread. 
        mutex1 = New Threading.Mutex(True)

        ' Create a callback to function OnMutexReleased
        Dim callback As New Threading.WaitOrTimerCallback(AddressOf OnMutexReleased)

        ' Register the mutex to fire OnManualEventSet when release, specifying it to run
        ' only once.  This puts the process into waiting.
        Threading.ThreadPool.RegisterWaitForSingleObject(mutex1, callback, Nothing, _
            Threading.Timeout.Infinite, True)

        ' Show that process is waiting in blue.
        lblMutexThreadStatus.Text = "Waiting"
        lblMutexThreadStatus.ForeColor = Color.Blue

        ' Allow the mutex to be released, but don't let it be put into waiting again 
        ' until it has already been released.
        btnWaitForMutex.Enabled = False
        btnReleaseMutex.Enabled = True

        ' If mutex and events are all in waiting status, allow SetRelease all button
        If Not btnWaitForManualEvent.Enabled And Not btnWaitForAutoEvent.Enabled Then
            btnSetReleaseAll.Enabled = True
        End If
    End Sub

    ' Toggles HighIntensity property for ProcessGroup  
    Private Sub chkHighIntensity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHighIntensity.CheckedChanged
        ProcessGroup.SetHighIntensity = chkHighIntensity.Checked
    End Sub

    ' Set up all the groups and event handlers.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        processGroup1 = New ProcessGroup(lblProcess1Active, lblProcess1ThreadNum, _
                                         lblProcess1IsPoolThread)
        processGroup2 = New ProcessGroup(lblProcess2Active, lblProcess2ThreadNum, _
                                         lblProcess2IsPoolThread)
        processGroup3 = New ProcessGroup(lblProcess3Active, lblProcess3ThreadNum, _
                                         lblProcess3IsPoolThread)

        AddHandler processGroup1.Completed, AddressOf OnProcessesCompleted
        AddHandler processGroup2.Completed, AddressOf OnProcessesCompleted
        AddHandler processGroup3.Completed, AddressOf OnProcessesCompleted

        ProcessGroup.PrepareToRun()

        timerGroup1 = New TimerGroup(lblTimer1Output, lblTimer1ThreadNum, _
                                     lblTimer1IsThreadPool)
        timerGroup2 = New TimerGroup(lblTimer2Output, lblTimer2ThreadNum, _
                                     lblTimer2IsThreadPool)
    End Sub

    ' This is the callback subroutine for when the auto reset event is set.
    Private Sub OnAutoEventSet(ByVal obj As Object, ByVal TimedOut As Boolean)
        ' Show that process is running in green.
        lblAutoEventStatus.Text = "Running"
        lblAutoEventStatus.ForeColor = Color.Green

        ' Update ThreadNum label with current thread number.  GetHashCode will contain
        ' a unique value for each thread.
        lblAutoEventThreadNum.Text = _
            Threading.Thread.CurrentThread.GetHashCode().ToString

        ' Update the IsThreadPooled label with Yes/No depending on whether the current
        ' thread is a pool thread.
        If Threading.Thread.CurrentThread.IsThreadPoolThread Then
            lblAutoEventIsPoolThread.Text = "Yes"
        Else
            lblAutoEventIsPoolThread.Text = "No"
        End If

        ' Put the current thread to sleep for 2 seconds.
        Threading.Thread.CurrentThread.Sleep(2000)

        ' Show that process is waiting in blue.
        lblAutoEventStatus.Text = "Waiting"
        lblAutoEventStatus.ForeColor = Color.Blue

        ' Since this is an auto reset event, reenable the set button.
        btnSetAutoEvent.Enabled = True

        ' If mutex and events are all waiting then allow SetReleaseAll button.
        If Not btnWaitForManualEvent.Enabled And Not btnWaitForMutex.Enabled Then
            btnSetReleaseAll.Enabled = True
        End If
    End Sub

    ' This is the callback subroutine for when the manual reset event is set.
    Private Sub OnManualEventSet(ByVal obj As Object, ByVal TimedOut As Boolean)
        ' Show that process is running in green.
        lblManualEventThreadStatus.Text = "Running"
        lblManualEventThreadStatus.ForeColor = Color.Green

        ' Update ThreadNum label with current thread number.  GetHashCode will contain
        ' a unique value for each thread.
        lblManualEventThreadNum.Text = _
            Threading.Thread.CurrentThread.GetHashCode().ToString

        ' Update the IsThreadPooled label with Yes/No depending on whether the current
        ' thread is a pool thread.
        If Threading.Thread.CurrentThread.IsThreadPoolThread Then
            lblManualEventIsPoolThread.Text = "Yes"
        Else
            lblManualEventIsPoolThread.Text = "No"
        End If

        ' Put the current thread to sleep for 2 seconds.
        Threading.Thread.CurrentThread.Sleep(2000)

        ' Show that the process is inactive in read.
        lblManualEventThreadStatus.Text = "Inactive"
        lblManualEventThreadStatus.ForeColor = Color.Red

        ' Dispose of the event.
        manualResetEvent1.Close()

        ' Reenable the WaitForManualEvent button.
        btnWaitForManualEvent.Enabled = True
    End Sub

    ' This is the callback subroutine for when the mutex is released.
    Private Sub OnMutexReleased(ByVal obj As Object, ByVal TimedOut As Boolean)
        ' Show that process is running in green.
        lblMutexThreadStatus.Text = "Running"
        lblMutexThreadStatus.ForeColor = Color.Green

        ' Update ThreadNum label with current thread number.  GetHashCode will contain
        ' a unique value for each thread.
        lblMutexThreadNum.Text = Threading.Thread.CurrentThread.GetHashCode().ToString

        ' Update the IsThreadPooled label with Yes/No depending on whether the current
        ' thread is a pool thread.
        If Threading.Thread.CurrentThread.IsThreadPoolThread Then
            lblMutexIsPoolThread.Text = "Yes"
        Else
            lblMutexIsPoolThread.Text = "No"
        End If

        ' Put the current thread to sleep for 2 seconds.
        Threading.Thread.CurrentThread.Sleep(2000)

        ' Show that the process is inactive in read.
        lblMutexThreadStatus.Text = "Inactive"
        lblMutexThreadStatus.ForeColor = Color.Red

        ' Dispose of the mutex.
        mutex1.Close()

        ' Reenable the WaitForMutex button.
        btnWaitForMutex.Enabled = True
    End Sub

    ' This is the subroutine that is called when all three processes are finished.
    Private Sub OnProcessesCompleted()
        ' Get the number of seconds the processes took to run, and fill in the label.
        Dim secondsElapsed As Double = ProcessGroup.GetTicksElapsed / 1000
        lblSecondsElapsed.Text = secondsElapsed.ToString

        ' Enable all of the process buttons.
        btnNonthreaded.Enabled = True
        btnThreaded.Enabled = True
        btnThreadPool.Enabled = True

        ' Reset the processed to run again.
        ProcessGroup.PrepareToRun()
    End Sub
End Class