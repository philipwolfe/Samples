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
    Friend WithEvents mnuCurrentTimeZone As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTimeSinceReboot As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFrameworkVersion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCurrentOSVersion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExitApp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCurrentDate As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCtx As System.Windows.Forms.ContextMenu
    Friend WithEvents ntfSystemInfo As System.Windows.Forms.NotifyIcon
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnTray As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.ntfSystemInfo = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.mnuCtx = New System.Windows.Forms.ContextMenu()
        Me.mnuCurrentDate = New System.Windows.Forms.MenuItem()
        Me.mnuCurrentTimeZone = New System.Windows.Forms.MenuItem()
        Me.mnuTimeSinceReboot = New System.Windows.Forms.MenuItem()
        Me.mnuFrameworkVersion = New System.Windows.Forms.MenuItem()
        Me.mnuCurrentOSVersion = New System.Windows.Forms.MenuItem()
        Me.mnuExitApp = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTray = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
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
        'ntfSystemInfo
        '
        Me.ntfSystemInfo.ContextMenu = Me.mnuCtx
        Me.ntfSystemInfo.Icon = CType(resources.GetObject("ntfSystemInfo.Icon"), System.Drawing.Icon)
        Me.ntfSystemInfo.Text = resources.GetString("ntfSystemInfo.Text")
        Me.ntfSystemInfo.Visible = CType(resources.GetObject("ntfSystemInfo.Visible"), Boolean)
        '
        'mnuCtx
        '
        Me.mnuCtx.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCurrentDate, Me.mnuCurrentTimeZone, Me.mnuTimeSinceReboot, Me.mnuFrameworkVersion, Me.mnuCurrentOSVersion, Me.mnuExitApp})
        Me.mnuCtx.RightToLeft = CType(resources.GetObject("mnuCtx.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'mnuCurrentDate
        '
        Me.mnuCurrentDate.Enabled = CType(resources.GetObject("mnuCurrentDate.Enabled"), Boolean)
        Me.mnuCurrentDate.Index = 0
        Me.mnuCurrentDate.Shortcut = CType(resources.GetObject("mnuCurrentDate.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCurrentDate.ShowShortcut = CType(resources.GetObject("mnuCurrentDate.ShowShortcut"), Boolean)
        Me.mnuCurrentDate.Text = resources.GetString("mnuCurrentDate.Text")
        Me.mnuCurrentDate.Visible = CType(resources.GetObject("mnuCurrentDate.Visible"), Boolean)
        '
        'mnuCurrentTimeZone
        '
        Me.mnuCurrentTimeZone.Enabled = CType(resources.GetObject("mnuCurrentTimeZone.Enabled"), Boolean)
        Me.mnuCurrentTimeZone.Index = 1
        Me.mnuCurrentTimeZone.Shortcut = CType(resources.GetObject("mnuCurrentTimeZone.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCurrentTimeZone.ShowShortcut = CType(resources.GetObject("mnuCurrentTimeZone.ShowShortcut"), Boolean)
        Me.mnuCurrentTimeZone.Text = resources.GetString("mnuCurrentTimeZone.Text")
        Me.mnuCurrentTimeZone.Visible = CType(resources.GetObject("mnuCurrentTimeZone.Visible"), Boolean)
        '
        'mnuTimeSinceReboot
        '
        Me.mnuTimeSinceReboot.Enabled = CType(resources.GetObject("mnuTimeSinceReboot.Enabled"), Boolean)
        Me.mnuTimeSinceReboot.Index = 2
        Me.mnuTimeSinceReboot.Shortcut = CType(resources.GetObject("mnuTimeSinceReboot.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuTimeSinceReboot.ShowShortcut = CType(resources.GetObject("mnuTimeSinceReboot.ShowShortcut"), Boolean)
        Me.mnuTimeSinceReboot.Text = resources.GetString("mnuTimeSinceReboot.Text")
        Me.mnuTimeSinceReboot.Visible = CType(resources.GetObject("mnuTimeSinceReboot.Visible"), Boolean)
        '
        'mnuFrameworkVersion
        '
        Me.mnuFrameworkVersion.Enabled = CType(resources.GetObject("mnuFrameworkVersion.Enabled"), Boolean)
        Me.mnuFrameworkVersion.Index = 3
        Me.mnuFrameworkVersion.Shortcut = CType(resources.GetObject("mnuFrameworkVersion.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuFrameworkVersion.ShowShortcut = CType(resources.GetObject("mnuFrameworkVersion.ShowShortcut"), Boolean)
        Me.mnuFrameworkVersion.Text = resources.GetString("mnuFrameworkVersion.Text")
        Me.mnuFrameworkVersion.Visible = CType(resources.GetObject("mnuFrameworkVersion.Visible"), Boolean)
        '
        'mnuCurrentOSVersion
        '
        Me.mnuCurrentOSVersion.Enabled = CType(resources.GetObject("mnuCurrentOSVersion.Enabled"), Boolean)
        Me.mnuCurrentOSVersion.Index = 4
        Me.mnuCurrentOSVersion.Shortcut = CType(resources.GetObject("mnuCurrentOSVersion.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuCurrentOSVersion.ShowShortcut = CType(resources.GetObject("mnuCurrentOSVersion.ShowShortcut"), Boolean)
        Me.mnuCurrentOSVersion.Text = resources.GetString("mnuCurrentOSVersion.Text")
        Me.mnuCurrentOSVersion.Visible = CType(resources.GetObject("mnuCurrentOSVersion.Visible"), Boolean)
        '
        'mnuExitApp
        '
        Me.mnuExitApp.Enabled = CType(resources.GetObject("mnuExitApp.Enabled"), Boolean)
        Me.mnuExitApp.Index = 5
        Me.mnuExitApp.Shortcut = CType(resources.GetObject("mnuExitApp.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuExitApp.ShowShortcut = CType(resources.GetObject("mnuExitApp.ShowShortcut"), Boolean)
        Me.mnuExitApp.Text = resources.GetString("mnuExitApp.Text")
        Me.mnuExitApp.Visible = CType(resources.GetObject("mnuExitApp.Visible"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription")
        Me.Label1.AccessibleName = resources.GetString("Label1.AccessibleName")
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
        'btnTray
        '
        Me.btnTray.AccessibleDescription = resources.GetString("btnTray.AccessibleDescription")
        Me.btnTray.AccessibleName = resources.GetString("btnTray.AccessibleName")
        Me.btnTray.Anchor = CType(resources.GetObject("btnTray.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnTray.BackgroundImage = CType(resources.GetObject("btnTray.BackgroundImage"), System.Drawing.Image)
        Me.btnTray.Dock = CType(resources.GetObject("btnTray.Dock"), System.Windows.Forms.DockStyle)
        Me.btnTray.Enabled = CType(resources.GetObject("btnTray.Enabled"), Boolean)
        Me.btnTray.FlatStyle = CType(resources.GetObject("btnTray.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnTray.Font = CType(resources.GetObject("btnTray.Font"), System.Drawing.Font)
        Me.btnTray.Image = CType(resources.GetObject("btnTray.Image"), System.Drawing.Image)
        Me.btnTray.ImageAlign = CType(resources.GetObject("btnTray.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnTray.ImageIndex = CType(resources.GetObject("btnTray.ImageIndex"), Integer)
        Me.btnTray.ImeMode = CType(resources.GetObject("btnTray.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnTray.Location = CType(resources.GetObject("btnTray.Location"), System.Drawing.Point)
        Me.btnTray.Name = "btnTray"
        Me.btnTray.RightToLeft = CType(resources.GetObject("btnTray.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnTray.Size = CType(resources.GetObject("btnTray.Size"), System.Drawing.Size)
        Me.btnTray.TabIndex = CType(resources.GetObject("btnTray.TabIndex"), Integer)
        Me.btnTray.Text = resources.GetString("btnTray.Text")
        Me.btnTray.TextAlign = CType(resources.GetObject("btnTray.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnTray.Visible = CType(resources.GetObject("btnTray.Visible"), Boolean)
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription")
        Me.Label2.AccessibleName = resources.GetString("Label2.AccessibleName")
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.btnTray, Me.Label1})
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
        Shutdown()
	End Sub
#End Region

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shutdown()
    End Sub

    Private Sub btnTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTray.Click
        ' Hide the main form, as a program running as a tray icon doesn't typically 
        ' have a visible form.
        Me.Hide()
        ntfSystemInfo.Visible = True
        ntfSystemInfo.Text = "System Information"
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Make sure that the tray icon dosen't appear until the user clicks Start.
        ' Otherwise the tray icon will be visible at the same time as the main form.
        ntfSystemInfo.Visible = False
    End Sub

    Private Sub mnuCurrentOSVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCurrentOSVersion.Click
        ' Grab the OS Information.  Outputs the Build, Major, Minor, and Revision 
        ' Information() for the current OS.  This information can also be accessed 
        ' individually via properties.  Eliminates the need to make API calls for 
        ' some of this information.

        MessageBox.Show("OS Version: " + Environment.OSVersion.ToString(), _
            "Operating System", _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Information)

    End Sub

    Private Sub mnuCurrentTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCurrentDate.Click
        ' Displays the current Date.
        MessageBox.Show("Today's Date is: " + DateTime.Now.ToLongDateString(), _
            "Date", _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Information)
    End Sub

    Private Sub mnuCurrentTimeZone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCurrentTimeZone.Click

        ' Using the TimeZone class display the name of the user's current timezone.  
        ' The(Time Zone) class can also be used to determine if the user's location 
        ' is currently using daylight savings time as well as the time that daylight 
        ' savings time is active for a given time zone.

        If (TimeZone.CurrentTimeZone.IsDaylightSavingTime(DateTime.Now)) Then
            MessageBox.Show( _
                                    "The current time zone is: " + TimeZone.CurrentTimeZone.DaylightName, _
                                    "Time Zone", _
                                    MessageBoxButtons.OK, _
                                    MessageBoxIcon.Information)
        Else
            MessageBox.Show( _
                        "The current time zone is: " + TimeZone.CurrentTimeZone.StandardName, _
                        "Time Zone", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub mnuExitApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExitApp.Click
        Shutdown()
    End Sub

    Private Sub mnuFrameworkVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFrameworkVersion.Click
        ' Grab the current .NET Framework Version.  Outputs the Build, Major, 
        ' Minor information. This information can also be accessed individually 
        ' by properties.

        MessageBox.Show("Framework Version: " + Environment.Version.ToString(), _
            ".NET Framework Version", _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Information)
    End Sub

    Private Sub mnuTimeSinceReboot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTimeSinceReboot.Click
        ' Displays the amount of time that the machine has been up since last being rebooted.
        ' The time retrieved from TickCount is in Milliseconds.  This is converted to minutes.

        Dim timeSinceLastRebootMinutes As Double = ((Environment.TickCount / 1000) / 60)
        MessageBox.Show("It has been : " + CInt(timeSinceLastRebootMinutes).ToString() + " minutes since your last reboot.", _
            "Last Reboot", _
            MessageBoxButtons.OK, _
            MessageBoxIcon.Information)
    End Sub

    Private Sub ntfSystemInfo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntfSystemInfo.DoubleClick
        ' When the user double-clicks the tray icon, display the main form again.
        ' Also, make the tray icon disappear while the form is visible.
        ntfSystemInfo.Visible = False
        Me.Show()
    End Sub

    Protected Sub Shutdown()
        ' It's a good idea to make the system tray icon invisible before ending
        ' the application, otherwise, it can linger in the tray when the application
        ' is no longer running.
        ntfSystemInfo.Visible = False
        Application.Exit()
    End Sub

End Class