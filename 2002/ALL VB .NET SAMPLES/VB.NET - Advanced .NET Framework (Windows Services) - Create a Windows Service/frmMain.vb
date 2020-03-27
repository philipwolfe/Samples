'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.ServiceProcess

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private isServiceInstalled As Boolean = False
    Private isServiceRunning As Boolean
    Private myService As ServiceController ' Used as a reference to the service

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
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents lblInstallationStatus As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents sbrServiceStatus As System.Windows.Forms.StatusBar
    Friend WithEvents tmrCheckStatus As System.Windows.Forms.Timer
    Friend WithEvents btnVerifyInstall As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.lblInstallationStatus = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.sbrServiceStatus = New System.Windows.Forms.StatusBar()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnVerifyInstall = New System.Windows.Forms.Button()
        Me.tmrCheckStatus = New System.Windows.Forms.Timer(Me.components)
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
        'lblInstructions
        '
        Me.lblInstructions.AccessibleDescription = resources.GetString("lblInstructions.AccessibleDescription")
        Me.lblInstructions.AccessibleName = resources.GetString("lblInstructions.AccessibleName")
        Me.lblInstructions.Anchor = CType(resources.GetObject("lblInstructions.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblInstructions.AutoSize = CType(resources.GetObject("lblInstructions.AutoSize"), Boolean)
        Me.lblInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInstructions.Dock = CType(resources.GetObject("lblInstructions.Dock"), System.Windows.Forms.DockStyle)
        Me.lblInstructions.Enabled = CType(resources.GetObject("lblInstructions.Enabled"), Boolean)
        Me.lblInstructions.Font = CType(resources.GetObject("lblInstructions.Font"), System.Drawing.Font)
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
        'lblInstallationStatus
        '
        Me.lblInstallationStatus.AccessibleDescription = resources.GetString("lblInstallationStatus.AccessibleDescription")
        Me.lblInstallationStatus.AccessibleName = resources.GetString("lblInstallationStatus.AccessibleName")
        Me.lblInstallationStatus.Anchor = CType(resources.GetObject("lblInstallationStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblInstallationStatus.AutoSize = CType(resources.GetObject("lblInstallationStatus.AutoSize"), Boolean)
        Me.lblInstallationStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInstallationStatus.Dock = CType(resources.GetObject("lblInstallationStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.lblInstallationStatus.Enabled = CType(resources.GetObject("lblInstallationStatus.Enabled"), Boolean)
        Me.lblInstallationStatus.Font = CType(resources.GetObject("lblInstallationStatus.Font"), System.Drawing.Font)
        Me.lblInstallationStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblInstallationStatus.Image = CType(resources.GetObject("lblInstallationStatus.Image"), System.Drawing.Image)
        Me.lblInstallationStatus.ImageAlign = CType(resources.GetObject("lblInstallationStatus.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblInstallationStatus.ImageIndex = CType(resources.GetObject("lblInstallationStatus.ImageIndex"), Integer)
        Me.lblInstallationStatus.ImeMode = CType(resources.GetObject("lblInstallationStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblInstallationStatus.Location = CType(resources.GetObject("lblInstallationStatus.Location"), System.Drawing.Point)
        Me.lblInstallationStatus.Name = "lblInstallationStatus"
        Me.lblInstallationStatus.RightToLeft = CType(resources.GetObject("lblInstallationStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblInstallationStatus.Size = CType(resources.GetObject("lblInstallationStatus.Size"), System.Drawing.Size)
        Me.lblInstallationStatus.TabIndex = CType(resources.GetObject("lblInstallationStatus.TabIndex"), Integer)
        Me.lblInstallationStatus.Text = resources.GetString("lblInstallationStatus.Text")
        Me.lblInstallationStatus.TextAlign = CType(resources.GetObject("lblInstallationStatus.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblInstallationStatus.Visible = CType(resources.GetObject("lblInstallationStatus.Visible"), Boolean)
        '
        'btnStart
        '
        Me.btnStart.AccessibleDescription = resources.GetString("btnStart.AccessibleDescription")
        Me.btnStart.AccessibleName = resources.GetString("btnStart.AccessibleName")
        Me.btnStart.Anchor = CType(resources.GetObject("btnStart.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStart.BackgroundImage = CType(resources.GetObject("btnStart.BackgroundImage"), System.Drawing.Image)
        Me.btnStart.Dock = CType(resources.GetObject("btnStart.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStart.Enabled = CType(resources.GetObject("btnStart.Enabled"), Boolean)
        Me.btnStart.FlatStyle = CType(resources.GetObject("btnStart.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStart.Font = CType(resources.GetObject("btnStart.Font"), System.Drawing.Font)
        Me.btnStart.Image = CType(resources.GetObject("btnStart.Image"), System.Drawing.Image)
        Me.btnStart.ImageAlign = CType(resources.GetObject("btnStart.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStart.ImageIndex = CType(resources.GetObject("btnStart.ImageIndex"), Integer)
        Me.btnStart.ImeMode = CType(resources.GetObject("btnStart.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStart.Location = CType(resources.GetObject("btnStart.Location"), System.Drawing.Point)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.RightToLeft = CType(resources.GetObject("btnStart.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStart.Size = CType(resources.GetObject("btnStart.Size"), System.Drawing.Size)
        Me.btnStart.TabIndex = CType(resources.GetObject("btnStart.TabIndex"), Integer)
        Me.btnStart.Text = resources.GetString("btnStart.Text")
        Me.btnStart.TextAlign = CType(resources.GetObject("btnStart.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStart.Visible = CType(resources.GetObject("btnStart.Visible"), Boolean)
        '
        'sbrServiceStatus
        '
        Me.sbrServiceStatus.AccessibleDescription = resources.GetString("sbrServiceStatus.AccessibleDescription")
        Me.sbrServiceStatus.AccessibleName = resources.GetString("sbrServiceStatus.AccessibleName")
        Me.sbrServiceStatus.Anchor = CType(resources.GetObject("sbrServiceStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.sbrServiceStatus.BackgroundImage = CType(resources.GetObject("sbrServiceStatus.BackgroundImage"), System.Drawing.Image)
        Me.sbrServiceStatus.Dock = CType(resources.GetObject("sbrServiceStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.sbrServiceStatus.Enabled = CType(resources.GetObject("sbrServiceStatus.Enabled"), Boolean)
        Me.sbrServiceStatus.Font = CType(resources.GetObject("sbrServiceStatus.Font"), System.Drawing.Font)
        Me.sbrServiceStatus.ImeMode = CType(resources.GetObject("sbrServiceStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.sbrServiceStatus.Location = CType(resources.GetObject("sbrServiceStatus.Location"), System.Drawing.Point)
        Me.sbrServiceStatus.Name = "sbrServiceStatus"
        Me.sbrServiceStatus.RightToLeft = CType(resources.GetObject("sbrServiceStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.sbrServiceStatus.Size = CType(resources.GetObject("sbrServiceStatus.Size"), System.Drawing.Size)
        Me.sbrServiceStatus.TabIndex = CType(resources.GetObject("sbrServiceStatus.TabIndex"), Integer)
        Me.sbrServiceStatus.Text = resources.GetString("sbrServiceStatus.Text")
        Me.sbrServiceStatus.Visible = CType(resources.GetObject("sbrServiceStatus.Visible"), Boolean)
        '
        'btnPause
        '
        Me.btnPause.AccessibleDescription = resources.GetString("btnPause.AccessibleDescription")
        Me.btnPause.AccessibleName = resources.GetString("btnPause.AccessibleName")
        Me.btnPause.Anchor = CType(resources.GetObject("btnPause.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPause.BackgroundImage = CType(resources.GetObject("btnPause.BackgroundImage"), System.Drawing.Image)
        Me.btnPause.Dock = CType(resources.GetObject("btnPause.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPause.Enabled = CType(resources.GetObject("btnPause.Enabled"), Boolean)
        Me.btnPause.FlatStyle = CType(resources.GetObject("btnPause.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPause.Font = CType(resources.GetObject("btnPause.Font"), System.Drawing.Font)
        Me.btnPause.Image = CType(resources.GetObject("btnPause.Image"), System.Drawing.Image)
        Me.btnPause.ImageAlign = CType(resources.GetObject("btnPause.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPause.ImageIndex = CType(resources.GetObject("btnPause.ImageIndex"), Integer)
        Me.btnPause.ImeMode = CType(resources.GetObject("btnPause.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPause.Location = CType(resources.GetObject("btnPause.Location"), System.Drawing.Point)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.RightToLeft = CType(resources.GetObject("btnPause.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPause.Size = CType(resources.GetObject("btnPause.Size"), System.Drawing.Size)
        Me.btnPause.TabIndex = CType(resources.GetObject("btnPause.TabIndex"), Integer)
        Me.btnPause.Text = resources.GetString("btnPause.Text")
        Me.btnPause.TextAlign = CType(resources.GetObject("btnPause.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPause.Visible = CType(resources.GetObject("btnPause.Visible"), Boolean)
        '
        'btnContinue
        '
        Me.btnContinue.AccessibleDescription = resources.GetString("btnContinue.AccessibleDescription")
        Me.btnContinue.AccessibleName = resources.GetString("btnContinue.AccessibleName")
        Me.btnContinue.Anchor = CType(resources.GetObject("btnContinue.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnContinue.BackgroundImage = CType(resources.GetObject("btnContinue.BackgroundImage"), System.Drawing.Image)
        Me.btnContinue.Dock = CType(resources.GetObject("btnContinue.Dock"), System.Windows.Forms.DockStyle)
        Me.btnContinue.Enabled = CType(resources.GetObject("btnContinue.Enabled"), Boolean)
        Me.btnContinue.FlatStyle = CType(resources.GetObject("btnContinue.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnContinue.Font = CType(resources.GetObject("btnContinue.Font"), System.Drawing.Font)
        Me.btnContinue.Image = CType(resources.GetObject("btnContinue.Image"), System.Drawing.Image)
        Me.btnContinue.ImageAlign = CType(resources.GetObject("btnContinue.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnContinue.ImageIndex = CType(resources.GetObject("btnContinue.ImageIndex"), Integer)
        Me.btnContinue.ImeMode = CType(resources.GetObject("btnContinue.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnContinue.Location = CType(resources.GetObject("btnContinue.Location"), System.Drawing.Point)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.RightToLeft = CType(resources.GetObject("btnContinue.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnContinue.Size = CType(resources.GetObject("btnContinue.Size"), System.Drawing.Size)
        Me.btnContinue.TabIndex = CType(resources.GetObject("btnContinue.TabIndex"), Integer)
        Me.btnContinue.Text = resources.GetString("btnContinue.Text")
        Me.btnContinue.TextAlign = CType(resources.GetObject("btnContinue.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnContinue.Visible = CType(resources.GetObject("btnContinue.Visible"), Boolean)
        '
        'btnStop
        '
        Me.btnStop.AccessibleDescription = resources.GetString("btnStop.AccessibleDescription")
        Me.btnStop.AccessibleName = resources.GetString("btnStop.AccessibleName")
        Me.btnStop.Anchor = CType(resources.GetObject("btnStop.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnStop.BackgroundImage = CType(resources.GetObject("btnStop.BackgroundImage"), System.Drawing.Image)
        Me.btnStop.Dock = CType(resources.GetObject("btnStop.Dock"), System.Windows.Forms.DockStyle)
        Me.btnStop.Enabled = CType(resources.GetObject("btnStop.Enabled"), Boolean)
        Me.btnStop.FlatStyle = CType(resources.GetObject("btnStop.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnStop.Font = CType(resources.GetObject("btnStop.Font"), System.Drawing.Font)
        Me.btnStop.Image = CType(resources.GetObject("btnStop.Image"), System.Drawing.Image)
        Me.btnStop.ImageAlign = CType(resources.GetObject("btnStop.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnStop.ImageIndex = CType(resources.GetObject("btnStop.ImageIndex"), Integer)
        Me.btnStop.ImeMode = CType(resources.GetObject("btnStop.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnStop.Location = CType(resources.GetObject("btnStop.Location"), System.Drawing.Point)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.RightToLeft = CType(resources.GetObject("btnStop.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnStop.Size = CType(resources.GetObject("btnStop.Size"), System.Drawing.Size)
        Me.btnStop.TabIndex = CType(resources.GetObject("btnStop.TabIndex"), Integer)
        Me.btnStop.Text = resources.GetString("btnStop.Text")
        Me.btnStop.TextAlign = CType(resources.GetObject("btnStop.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnStop.Visible = CType(resources.GetObject("btnStop.Visible"), Boolean)
        '
        'btnVerifyInstall
        '
        Me.btnVerifyInstall.AccessibleDescription = resources.GetString("btnVerifyInstall.AccessibleDescription")
        Me.btnVerifyInstall.AccessibleName = resources.GetString("btnVerifyInstall.AccessibleName")
        Me.btnVerifyInstall.Anchor = CType(resources.GetObject("btnVerifyInstall.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnVerifyInstall.BackgroundImage = CType(resources.GetObject("btnVerifyInstall.BackgroundImage"), System.Drawing.Image)
        Me.btnVerifyInstall.Dock = CType(resources.GetObject("btnVerifyInstall.Dock"), System.Windows.Forms.DockStyle)
        Me.btnVerifyInstall.Enabled = CType(resources.GetObject("btnVerifyInstall.Enabled"), Boolean)
        Me.btnVerifyInstall.FlatStyle = CType(resources.GetObject("btnVerifyInstall.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnVerifyInstall.Font = CType(resources.GetObject("btnVerifyInstall.Font"), System.Drawing.Font)
        Me.btnVerifyInstall.Image = CType(resources.GetObject("btnVerifyInstall.Image"), System.Drawing.Image)
        Me.btnVerifyInstall.ImageAlign = CType(resources.GetObject("btnVerifyInstall.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnVerifyInstall.ImageIndex = CType(resources.GetObject("btnVerifyInstall.ImageIndex"), Integer)
        Me.btnVerifyInstall.ImeMode = CType(resources.GetObject("btnVerifyInstall.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnVerifyInstall.Location = CType(resources.GetObject("btnVerifyInstall.Location"), System.Drawing.Point)
        Me.btnVerifyInstall.Name = "btnVerifyInstall"
        Me.btnVerifyInstall.RightToLeft = CType(resources.GetObject("btnVerifyInstall.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnVerifyInstall.Size = CType(resources.GetObject("btnVerifyInstall.Size"), System.Drawing.Size)
        Me.btnVerifyInstall.TabIndex = CType(resources.GetObject("btnVerifyInstall.TabIndex"), Integer)
        Me.btnVerifyInstall.Text = resources.GetString("btnVerifyInstall.Text")
        Me.btnVerifyInstall.TextAlign = CType(resources.GetObject("btnVerifyInstall.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnVerifyInstall.Visible = CType(resources.GetObject("btnVerifyInstall.Visible"), Boolean)
        '
        'tmrCheckStatus
        '
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnVerifyInstall, Me.btnStop, Me.btnContinue, Me.btnPause, Me.sbrServiceStatus, Me.btnStart, Me.lblInstallationStatus, Me.lblInstructions})
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


    ' This sub forces the service to Continue
    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        myService.Continue()
        UpdateServiceStatus()
    End Sub

    ' This sub forces the service to Pause
    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        myService.Pause()
        UpdateServiceStatus()
    End Sub

    ' This sub forces the service to Stop
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        myService.Stop()
        UpdateServiceStatus()
    End Sub

    ' This sub forces the service to Start
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        myService.Start()
        UpdateServiceStatus()
    End Sub

    ' This sub is used to find if the Service is currently installed.
    Private Sub btnVerifyInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerifyInstall.Click
        CheckServiceInstallation()
    End Sub

    ' This sub runs when the form is loaded.  Basically, it checks to
    '   see if the service is installed, and what the status is.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This project is only here to provide an introduction and user
        '   interface to the How-To.  The important code is in the 
        '   VB.NET How-To Windows Service Demo project.  This is where 
        '   the Windows Service is defined.  Also important, is the 
        '   VB.NET How-To Windows Service - Time Track Install project. 
        '   This project shows how to create a deployment project for the 
        '   Windows Service.  (You can also use InstallUtil.exe to install
        '   a service.)
        ' The following code ensures that the Service is already installed.
        '   If it isn't, it directs the user to run the included MSI file.

        CheckServiceInstallation()
        UpdateServiceStatus()
        Me.tmrCheckStatus.Enabled = True

    End Sub

    ' This sub updates the Service status every time it is fired.
    Private Sub tmrCheckStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCheckStatus.Tick
        UpdateServiceStatus()
    End Sub

    ' Methods are below

    ' CheckServiceInstallation verifies that the service is actually
    '   installed on the system. It also assigns the service
    '   to the myService class variable if it is. 
    ' The assignment to myService is important and must be refreshed, since
    '   unlike most objects, the myService doesn't get changes to the
    '   status of the actual service. So it must be continually reassigned.
    Private Sub CheckServiceInstallation()
        ' Verify to see if the service is installed.
        Dim installedServices() As ServiceController
        Dim tmpService As ServiceController
        Dim i As Integer = 0

        ' Shut off the timer so it doesn't raise events while were
        '   in this code
        Me.tmrCheckStatus.Enabled = False

        installedServices = ServiceController.GetServices()

        For Each tmpService In installedServices
            If tmpService.DisplayName = "VB_NET_HowTo_TimeTrackerService" Then
                isServiceInstalled = True
                Me.lblInstallationStatus.Text = _
                    "The Windows Service is currently installed.  Use the " & _
                    "Computer Management console to Start and Stop the " & _
                    "service. (On Windows XP, click Start, then right-click " & _
                    "My Computer, then select Manage. Then click on " & _
                    "Services and Applications -> Services.) Or use the " & _
                    "buttons below"
                ' Assign the service to myService, so we can use it later.
                myService = tmpService
            End If
        Next tmpService

        Me.tmrCheckStatus.Enabled = True

    End Sub

    Private Sub UpdateServiceStatus()

        ' Shut off the timer so it doesn't raise events while were
        '   in this code
        Me.tmrCheckStatus.Enabled = False

        If Not (myService Is Nothing) Then

            ' Recreate myServer, otherwise the status for myServer never
            '   changes, despite changes in the status of the 
            '   windows service
            CheckServiceInstallation()

            Select Case myService.Status
                Case ServiceControllerStatus.Stopped
                    Me.btnContinue.Enabled = False
                    Me.btnPause.Enabled = False
                    Me.btnStart.Enabled = True
                    Me.btnStop.Enabled = False
                Case ServiceControllerStatus.Running
                    Me.btnContinue.Enabled = False
                    Me.btnPause.Enabled = True
                    Me.btnStart.Enabled = False
                    Me.btnStop.Enabled = True
                Case ServiceControllerStatus.Paused
                    Me.btnContinue.Enabled = True
                    Me.btnPause.Enabled = False
                    Me.btnStart.Enabled = False
                    Me.btnStop.Enabled = True
                Case Else
                    ' This can occur when an action is pending. In this case
                    '   don't allow the user to push any buttons.
                    Me.btnContinue.Enabled = False
                    Me.btnPause.Enabled = False
                    Me.btnStart.Enabled = False
                    Me.btnStop.Enabled = False
            End Select

            ' Output the status to the Status Bar
            Me.sbrServiceStatus.Text = "Service Status: " + myService.Status.ToString()
        Else
            ' The service isn't running so dim everything but refresh.
            Me.btnContinue.Enabled = False
            Me.btnPause.Enabled = False
            Me.btnStart.Enabled = False
            Me.btnStop.Enabled = False
        End If
        Me.tmrCheckStatus.Enabled = True
    End Sub


End Class