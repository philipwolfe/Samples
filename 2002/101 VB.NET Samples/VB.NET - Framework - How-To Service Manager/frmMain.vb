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

	' Used to access an instance of the selected service.
	Private msvc As ServiceController
	Private mcolSvcs As New Collection()

	' Used to control UI updates.
	Private fUpdatingUI As Boolean

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
	Friend WithEvents sbInfo As System.Windows.Forms.StatusBar
	Friend WithEvents pnlCommands As System.Windows.Forms.Panel
	Friend WithEvents lvServices As System.Windows.Forms.ListView
	Friend WithEvents chName As System.Windows.Forms.ColumnHeader
	Friend WithEvents chStatus As System.Windows.Forms.ColumnHeader
	Friend WithEvents cmdStart As System.Windows.Forms.Button
	Friend WithEvents cmdStop As System.Windows.Forms.Button
	Friend WithEvents cmdPause As System.Windows.Forms.Button
	Friend WithEvents cmdResume As System.Windows.Forms.Button
	Friend WithEvents chSvcType As System.Windows.Forms.ColumnHeader
	Friend WithEvents tmrStatus As System.Windows.Forms.Timer
	Friend WithEvents chkAutoRefresh As System.Windows.Forms.CheckBox
	Friend WithEvents mnuTools As System.Windows.Forms.MenuItem
	Friend WithEvents mnuRelist As System.Windows.Forms.MenuItem
	Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.sbInfo = New System.Windows.Forms.StatusBar()
		Me.pnlCommands = New System.Windows.Forms.Panel()
		Me.chkAutoRefresh = New System.Windows.Forms.CheckBox()
		Me.cmdResume = New System.Windows.Forms.Button()
		Me.cmdPause = New System.Windows.Forms.Button()
		Me.cmdStop = New System.Windows.Forms.Button()
		Me.cmdStart = New System.Windows.Forms.Button()
		Me.lvServices = New System.Windows.Forms.ListView()
		Me.chName = New System.Windows.Forms.ColumnHeader()
		Me.chStatus = New System.Windows.Forms.ColumnHeader()
		Me.chSvcType = New System.Windows.Forms.ColumnHeader()
		Me.tmrStatus = New System.Windows.Forms.Timer(Me.components)
		Me.mnuTools = New System.Windows.Forms.MenuItem()
		Me.mnuRelist = New System.Windows.Forms.MenuItem()
		Me.MenuItem3 = New System.Windows.Forms.MenuItem()
		Me.mnuRefresh = New System.Windows.Forms.MenuItem()
		Me.pnlCommands.SuspendLayout()
		Me.SuspendLayout()
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuTools, Me.mnuHelp})
		'
		'mnuFile
		'
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
		Me.mnuFile.Text = "&File"
		'
		'mnuExit
		'
		Me.mnuExit.Index = 0
		Me.mnuExit.Text = "E&xit"
		'
		'mnuHelp
		'
		Me.mnuHelp.Index = 2
		Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
		Me.mnuHelp.Text = "&Help"
		'
		'mnuAbout
		'
		Me.mnuAbout.Index = 0
		Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
		'
		'sbInfo
		'
		Me.sbInfo.Location = New System.Drawing.Point(0, 192)
		Me.sbInfo.Name = "sbInfo"
		Me.sbInfo.Size = New System.Drawing.Size(552, 22)
		Me.sbInfo.TabIndex = 2
		Me.sbInfo.Text = "Ready"
		'
		'pnlCommands
		'
		Me.pnlCommands.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAutoRefresh, Me.cmdResume, Me.cmdPause, Me.cmdStop, Me.cmdStart})
		Me.pnlCommands.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.pnlCommands.Location = New System.Drawing.Point(0, 152)
		Me.pnlCommands.Name = "pnlCommands"
		Me.pnlCommands.Size = New System.Drawing.Size(552, 40)
		Me.pnlCommands.TabIndex = 1
		'
		'chkAutoRefresh
		'
		Me.chkAutoRefresh.Checked = True
		Me.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkAutoRefresh.Location = New System.Drawing.Point(336, 8)
		Me.chkAutoRefresh.Name = "chkAutoRefresh"
		Me.chkAutoRefresh.TabIndex = 4
		Me.chkAutoRefresh.Text = "&Auto Refresh"
		'
		'cmdResume
		'
		Me.cmdResume.Location = New System.Drawing.Point(248, 8)
		Me.cmdResume.Name = "cmdResume"
		Me.cmdResume.TabIndex = 3
		Me.cmdResume.Text = "&Resume"
		'
		'cmdPause
		'
		Me.cmdPause.Location = New System.Drawing.Point(168, 8)
		Me.cmdPause.Name = "cmdPause"
		Me.cmdPause.TabIndex = 2
		Me.cmdPause.Text = "&Pause"
		'
		'cmdStop
		'
		Me.cmdStop.Location = New System.Drawing.Point(88, 8)
		Me.cmdStop.Name = "cmdStop"
		Me.cmdStop.TabIndex = 1
		Me.cmdStop.Text = "S&top"
		'
		'cmdStart
		'
		Me.cmdStart.Location = New System.Drawing.Point(8, 8)
		Me.cmdStart.Name = "cmdStart"
		Me.cmdStart.TabIndex = 0
		Me.cmdStart.Text = "&Start"
		'
		'lvServices
		'
		Me.lvServices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chStatus, Me.chSvcType})
		Me.lvServices.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lvServices.FullRowSelect = True
		Me.lvServices.HideSelection = False
		Me.lvServices.MultiSelect = False
		Me.lvServices.Name = "lvServices"
		Me.lvServices.Size = New System.Drawing.Size(552, 152)
		Me.lvServices.Sorting = System.Windows.Forms.SortOrder.Ascending
		Me.lvServices.TabIndex = 0
		Me.lvServices.View = System.Windows.Forms.View.Details
		'
		'chName
		'
		Me.chName.Text = "Name"
		Me.chName.Width = 200
		'
		'chStatus
		'
		Me.chStatus.Text = "Status"
		Me.chStatus.Width = 100
		'
		'chSvcType
		'
		Me.chSvcType.Text = "Service Type"
		Me.chSvcType.Width = 225
		'
		'tmrStatus
		'
		Me.tmrStatus.Enabled = True
		Me.tmrStatus.Interval = 5000
		'
		'mnuTools
		'
		Me.mnuTools.Index = 1
		Me.mnuTools.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRelist, Me.MenuItem3, Me.mnuRefresh})
		Me.mnuTools.Text = "&Tools"
		'
		'mnuRelist
		'
		Me.mnuRelist.Index = 0
		Me.mnuRelist.Text = "Relist &All Services"
		'
		'MenuItem3
		'
		Me.MenuItem3.Index = 1
		Me.MenuItem3.Text = "-"
		'
		'mnuRefresh
		'
		Me.mnuRefresh.Index = 2
		Me.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5
		Me.mnuRefresh.Text = "&Refresh"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(552, 214)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvServices, Me.pnlCommands, Me.sbInfo})
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.pnlCommands.ResumeLayout(False)
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

	Private Sub chkAutoRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoRefresh.CheckedChanged
		' Turn the timer on or off
		If Me.chkAutoRefresh.CheckState = CheckState.Checked Then
			Me.tmrStatus.Enabled = True
		Else
			Me.tmrStatus.Enabled = False
		End If
	End Sub

	Private Sub cmdPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPause.Click
		Try
			msvc.Pause()
			fUpdatingUI = True
			UpdateUIForSelectedService()
			fUpdatingUI = False

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub cmdResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResume.Click
		Try
			msvc.Continue()
			fUpdatingUI = True
			UpdateUIForSelectedService()
			fUpdatingUI = False
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
		Try
			msvc.Start()
			fUpdatingUI = True
			UpdateUIForSelectedService()
			fUpdatingUI = False
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
		Try
			msvc.Stop()
			fUpdatingUI = True
			UpdateUIForSelectedService()
			fUpdatingUI = False
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		EnumServices()
	End Sub

	Private Sub lvServices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvServices.SelectedIndexChanged
		fUpdatingUI = True
		UpdateUIForSelectedService()
		fUpdatingUI = False
	End Sub

	Private Sub tmrStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStatus.Tick
		If Not fUpdatingUI Then
			UpdateServiceStatus()
		End If
	End Sub

	Private Sub EnumServices()
		' Get the list of available services and
		' load the list view control with the information
		Try
			fUpdatingUI = True
			Me.sbInfo.Text = "Loading Service List, pleasse wait"
			Me.sbInfo.Refresh()

			Me.lvServices.Items.Clear()

			If Not mcolSvcs Is Nothing Then
				mcolSvcs = New Collection()
			End If

			Dim svc As ServiceController
			Dim svcs As ServiceController() = ServiceController.GetServices()

			For Each svc In svcs
				With Me.lvServices.Items.Add(svc.DisplayName)
					.SubItems.Add(svc.Status.ToString())
					.SubItems.Add(svc.ServiceType.ToString())
				End With
				mcolSvcs.Add(svc, svc.DisplayName)
			Next svc

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

		Finally
			Me.sbInfo.Text = "Ready"
			fUpdatingUI = False
		End Try
	End Sub

	Private Sub UpdateServiceStatus()
		' Check each service
		Try
			fUpdatingUI = True

			Me.sbInfo.Text = "Checking Service Status . . "
			Me.sbInfo.Refresh()

			Dim lvi As ListViewItem

			' We could walk through the collection of services
			' two ways. One would be to enumerate all the services
			' via mcolSvc and then find the particular item in the
			' list view control to update its status.
			' The second method is to do the following code which
			' seems a bit easier since the collection is keyed by
			' the service display name which we get from the list view 
			' control.
			For Each lvi In Me.lvServices.Items
				msvc = CType(mcolSvcs.Item(lvi.Text), ServiceController)
				msvc.Refresh()

				lvi.SubItems(1).Text = msvc.Status.ToString()
			Next lvi


			UpdateUIForSelectedService()

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			Me.sbInfo.Text = "Ready"
			fUpdatingUI = False
		End Try
	End Sub

	Private Sub UpdateUIForSelectedService()
		' Update the command buttons for the selected service.
		Dim strName As String
		Dim i As Integer

		Try
			If Me.lvServices.SelectedItems.Count = 1 Then
				strName = Me.lvServices.SelectedItems(0).SubItems(0).Text
				msvc = CType(mcolSvcs.Item(strName), ServiceController)
				With msvc
					' If it's stopped, we should be able to start it
					Me.cmdStart.Enabled = (.Status = ServiceControllerStatus.Stopped)
					' Check if we're allowed to try and stop it and make sure it's not
					' already stopped.
					Me.cmdStop.Enabled = (.CanStop AndAlso (Not .Status = ServiceControllerStatus.Stopped))
					' Check if we're allowed to pause it and see if it is not paused
					' already.
					Me.cmdPause.Enabled = (.CanPauseAndContinue AndAlso (Not .Status = ServiceControllerStatus.Paused))
					' If it's paused, we must be able to resume it.
					Me.cmdResume.Enabled = (.Status = ServiceControllerStatus.Paused)
				End With
			End If
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub mnuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click
		If Not fUpdatingUI Then
			UpdateServiceStatus()
		End If
	End Sub

	Private Sub mnuRelist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelist.Click
		If Not fUpdatingUI Then
			EnumServices()
		End If
	End Sub
End Class