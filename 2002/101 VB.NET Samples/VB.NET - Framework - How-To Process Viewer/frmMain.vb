'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Diagnostics

Public Class frmMain
	Inherits System.Windows.Forms.Form

	' Collection to hold processes for faster retrieval
	Private mcolProcesses As New Collection()
	' Child form reference to show module detail
	Private mfrmMod As frmModules

	' String constants for display in listviews
	Private Const PID_NA As String = "N/A"
	Private Const PROCESS_NAME_TOTAL As String = "_Total (0x0)"
	Private Const PROCESS_IDLE As String = "Idle"
	Private Const PROCESS_SYSTEM As String = "System"

	' Used by AddNameValuePair to reduce typing
	Private mits As ListView.ListViewItemCollection

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
	Friend WithEvents mnuView As System.Windows.Forms.MenuItem
	Friend WithEvents mnuRefresh As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
	Friend WithEvents sbInfo As System.Windows.Forms.StatusBar
	Friend WithEvents splVert As System.Windows.Forms.Splitter
	Friend WithEvents chValue As System.Windows.Forms.ColumnHeader
	Friend WithEvents chItem As System.Windows.Forms.ColumnHeader
	Friend WithEvents lvProcessDetail As System.Windows.Forms.ListView
	Friend WithEvents pnlProcess As System.Windows.Forms.Panel
	Friend WithEvents lvThreads As System.Windows.Forms.ListView
	Friend WithEvents chThreads As System.Windows.Forms.ColumnHeader
	Friend WithEvents chBasePri As System.Windows.Forms.ColumnHeader
	Friend WithEvents chCurrentPri As System.Windows.Forms.ColumnHeader
	Friend WithEvents chPriBoostEnabled As System.Windows.Forms.ColumnHeader
	Friend WithEvents chPriLevel As System.Windows.Forms.ColumnHeader
	Friend WithEvents chPrivProcTime As System.Windows.Forms.ColumnHeader
	Friend WithEvents chStartAddress As System.Windows.Forms.ColumnHeader
	Friend WithEvents chStartTime As System.Windows.Forms.ColumnHeader
	Friend WithEvents chTotalProcTime As System.Windows.Forms.ColumnHeader
	Friend WithEvents chUserProcTime As System.Windows.Forms.ColumnHeader
	Friend WithEvents splHor As System.Windows.Forms.Splitter
	Friend WithEvents lvProcesses As System.Windows.Forms.ListView
	Friend WithEvents chProcessName As System.Windows.Forms.ColumnHeader
	Friend WithEvents chPID As System.Windows.Forms.ColumnHeader
	Friend WithEvents chProcessorTime As System.Windows.Forms.ColumnHeader
	Friend WithEvents chPriv As System.Windows.Forms.ColumnHeader
	Friend WithEvents chUser As System.Windows.Forms.ColumnHeader
	Friend WithEvents pnlThreads As System.Windows.Forms.Panel
	Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuModules As System.Windows.Forms.MenuItem
	Friend WithEvents ctxViewMods As System.Windows.Forms.MenuItem
	Friend WithEvents ctxView As System.Windows.Forms.ContextMenu
	Friend WithEvents ctxRefresh As System.Windows.Forms.MenuItem
	Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem

	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuView = New System.Windows.Forms.MenuItem()
		Me.mnuModules = New System.Windows.Forms.MenuItem()
		Me.MenuItem2 = New System.Windows.Forms.MenuItem()
		Me.mnuRefresh = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.sbInfo = New System.Windows.Forms.StatusBar()
		Me.pnlProcess = New System.Windows.Forms.Panel()
		Me.lvProcesses = New System.Windows.Forms.ListView()
		Me.chProcessName = New System.Windows.Forms.ColumnHeader()
		Me.chPID = New System.Windows.Forms.ColumnHeader()
		Me.chProcessorTime = New System.Windows.Forms.ColumnHeader()
		Me.chPriv = New System.Windows.Forms.ColumnHeader()
		Me.chUser = New System.Windows.Forms.ColumnHeader()
		Me.ctxView = New System.Windows.Forms.ContextMenu()
		Me.ctxViewMods = New System.Windows.Forms.MenuItem()
		Me.MenuItem1 = New System.Windows.Forms.MenuItem()
		Me.ctxRefresh = New System.Windows.Forms.MenuItem()
		Me.splVert = New System.Windows.Forms.Splitter()
		Me.lvProcessDetail = New System.Windows.Forms.ListView()
		Me.chItem = New System.Windows.Forms.ColumnHeader()
		Me.chValue = New System.Windows.Forms.ColumnHeader()
		Me.pnlThreads = New System.Windows.Forms.Panel()
		Me.lvThreads = New System.Windows.Forms.ListView()
		Me.chThreads = New System.Windows.Forms.ColumnHeader()
		Me.chBasePri = New System.Windows.Forms.ColumnHeader()
		Me.chCurrentPri = New System.Windows.Forms.ColumnHeader()
		Me.chPriBoostEnabled = New System.Windows.Forms.ColumnHeader()
		Me.chPriLevel = New System.Windows.Forms.ColumnHeader()
		Me.chPrivProcTime = New System.Windows.Forms.ColumnHeader()
		Me.chStartAddress = New System.Windows.Forms.ColumnHeader()
		Me.chStartTime = New System.Windows.Forms.ColumnHeader()
		Me.chTotalProcTime = New System.Windows.Forms.ColumnHeader()
		Me.chUserProcTime = New System.Windows.Forms.ColumnHeader()
		Me.splHor = New System.Windows.Forms.Splitter()
		Me.pnlProcess.SuspendLayout()
		Me.pnlThreads.SuspendLayout()
		Me.SuspendLayout()
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuView, Me.mnuHelp})
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
		'mnuView
		'
		Me.mnuView.Index = 1
		Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuModules, Me.MenuItem2, Me.mnuRefresh})
		Me.mnuView.Text = "&View"
		'
		'mnuModules
		'
		Me.mnuModules.Index = 0
		Me.mnuModules.Shortcut = System.Windows.Forms.Shortcut.CtrlV
		Me.mnuModules.Text = "&Modules"
		'
		'MenuItem2
		'
		Me.MenuItem2.Index = 1
		Me.MenuItem2.Text = "-"
		'
		'mnuRefresh
		'
		Me.mnuRefresh.Index = 2
		Me.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5
		Me.mnuRefresh.Text = "&Refresh"
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
		Me.sbInfo.Location = New System.Drawing.Point(0, 483)
		Me.sbInfo.Name = "sbInfo"
		Me.sbInfo.Size = New System.Drawing.Size(927, 22)
		Me.sbInfo.TabIndex = 6
		Me.sbInfo.Text = "Ready"
		'
		'pnlProcess
		'
		Me.pnlProcess.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvProcesses, Me.splVert, Me.lvProcessDetail})
		Me.pnlProcess.Dock = System.Windows.Forms.DockStyle.Top
		Me.pnlProcess.Name = "pnlProcess"
		Me.pnlProcess.Size = New System.Drawing.Size(927, 368)
		Me.pnlProcess.TabIndex = 10
		'
		'lvProcesses
		'
		Me.lvProcesses.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chProcessName, Me.chPID, Me.chProcessorTime, Me.chPriv, Me.chUser})
		Me.lvProcesses.ContextMenu = Me.ctxView
		Me.lvProcesses.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lvProcesses.FullRowSelect = True
		Me.lvProcesses.MultiSelect = False
		Me.lvProcesses.Name = "lvProcesses"
		Me.lvProcesses.Size = New System.Drawing.Size(540, 368)
		Me.lvProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending
		Me.lvProcesses.TabIndex = 15
		Me.lvProcesses.View = System.Windows.Forms.View.Details
		'
		'chProcessName
		'
		Me.chProcessName.Text = "Process Name"
		Me.chProcessName.Width = 150
		'
		'chPID
		'
		Me.chPID.Text = "PID"
		'
		'chProcessorTime
		'
		Me.chProcessorTime.Text = "Processor Time"
		Me.chProcessorTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.chProcessorTime.Width = 150
		'
		'chPriv
		'
		Me.chPriv.Text = "Priviledged"
		Me.chPriv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.chPriv.Width = 80
		'
		'chUser
		'
		Me.chUser.Text = "User"
		Me.chUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.chUser.Width = 80
		'
		'ctxView
		'
		Me.ctxView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ctxViewMods, Me.MenuItem1, Me.ctxRefresh})
		'
		'ctxViewMods
		'
		Me.ctxViewMods.Index = 0
		Me.ctxViewMods.Shortcut = System.Windows.Forms.Shortcut.CtrlV
		Me.ctxViewMods.Text = "View &Modules"
		'
		'MenuItem1
		'
		Me.MenuItem1.Index = 1
		Me.MenuItem1.Text = "-"
		'
		'ctxRefresh
		'
		Me.ctxRefresh.Index = 2
		Me.ctxRefresh.Shortcut = System.Windows.Forms.Shortcut.F5
		Me.ctxRefresh.Text = "&Refresh"
		'
		'splVert
		'
		Me.splVert.Dock = System.Windows.Forms.DockStyle.Right
		Me.splVert.Location = New System.Drawing.Point(540, 0)
		Me.splVert.Name = "splVert"
		Me.splVert.Size = New System.Drawing.Size(3, 368)
		Me.splVert.TabIndex = 14
		Me.splVert.TabStop = False
		'
		'lvProcessDetail
		'
		Me.lvProcessDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chItem, Me.chValue})
		Me.lvProcessDetail.Dock = System.Windows.Forms.DockStyle.Right
		Me.lvProcessDetail.Location = New System.Drawing.Point(543, 0)
		Me.lvProcessDetail.MultiSelect = False
		Me.lvProcessDetail.Name = "lvProcessDetail"
		Me.lvProcessDetail.Size = New System.Drawing.Size(384, 368)
		Me.lvProcessDetail.TabIndex = 13
		Me.lvProcessDetail.View = System.Windows.Forms.View.Details
		'
		'chItem
		'
		Me.chItem.Text = "Item"
		Me.chItem.Width = 165
		'
		'chValue
		'
		Me.chValue.Text = "Value"
		Me.chValue.Width = 206
		'
		'pnlThreads
		'
		Me.pnlThreads.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvThreads})
		Me.pnlThreads.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlThreads.Location = New System.Drawing.Point(0, 368)
		Me.pnlThreads.Name = "pnlThreads"
		Me.pnlThreads.Size = New System.Drawing.Size(927, 115)
		Me.pnlThreads.TabIndex = 14
		'
		'lvThreads
		'
		Me.lvThreads.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chThreads, Me.chBasePri, Me.chCurrentPri, Me.chPriBoostEnabled, Me.chPriLevel, Me.chPrivProcTime, Me.chStartAddress, Me.chStartTime, Me.chTotalProcTime, Me.chUserProcTime})
		Me.lvThreads.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lvThreads.FullRowSelect = True
		Me.lvThreads.MultiSelect = False
		Me.lvThreads.Name = "lvThreads"
		Me.lvThreads.Size = New System.Drawing.Size(927, 115)
		Me.lvThreads.Sorting = System.Windows.Forms.SortOrder.Ascending
		Me.lvThreads.TabIndex = 14
		Me.lvThreads.View = System.Windows.Forms.View.Details
		'
		'chThreads
		'
		Me.chThreads.Text = "Thread(s)"
		'
		'chBasePri
		'
		Me.chBasePri.Text = "Base Priority"
		Me.chBasePri.Width = 75
		'
		'chCurrentPri
		'
		Me.chCurrentPri.Text = "Current Priority"
		Me.chCurrentPri.Width = 85
		'
		'chPriBoostEnabled
		'
		Me.chPriBoostEnabled.Text = "Priority Boost Enabled"
		Me.chPriBoostEnabled.Width = 115
		'
		'chPriLevel
		'
		Me.chPriLevel.Text = "Priority Level"
		Me.chPriLevel.Width = 75
		'
		'chPrivProcTime
		'
		Me.chPrivProcTime.Text = "Privileged"
		'
		'chStartAddress
		'
		Me.chStartAddress.Text = "Start Address"
		Me.chStartAddress.Width = 80
		'
		'chStartTime
		'
		Me.chStartTime.Text = "Start Time"
		Me.chStartTime.Width = 120
		'
		'chTotalProcTime
		'
		Me.chTotalProcTime.Text = "Processor Time"
		Me.chTotalProcTime.Width = 120
		'
		'chUserProcTime
		'
		Me.chUserProcTime.Text = "User"
		'
		'splHor
		'
		Me.splHor.Dock = System.Windows.Forms.DockStyle.Top
		Me.splHor.Location = New System.Drawing.Point(0, 368)
		Me.splHor.Name = "splHor"
		Me.splHor.Size = New System.Drawing.Size(927, 3)
		Me.splHor.TabIndex = 16
		Me.splHor.TabStop = False
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(927, 505)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.splHor, Me.pnlThreads, Me.pnlProcess, Me.sbInfo})
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.pnlProcess.ResumeLayout(False)
		Me.pnlThreads.ResumeLayout(False)
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

	Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
		' Clean up the child form if it's there
		If Not mfrmMod Is Nothing Then
			Try
				With mfrmMod
					.Owner = Nothing
					.ParentProcess = Nothing
					.Close()
					.Dispose()
				End With
				mfrmMod = Nothing
			Catch exp As Exception
				MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End If
	End Sub

	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Load the list of processes
		EnumProcesses()
	End Sub

	Private Sub lvProcesses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProcesses.SelectedIndexChanged
		' Handle the selection changing.
		Try
			Dim lv As ListView = CType(sender, ListView)

			If lv.SelectedItems.Count = 1 Then
				' Get the process id from the first subitem column
				Dim strProcessId As String = lv.SelectedItems(0).SubItems(1).Text

				' Check to see if we got our fake 'total' process
				If strProcessId = PID_NA Then
					Me.lvProcessDetail.Items.Clear()
					Me.lvThreads.Items.Clear()
					Exit Sub
				End If

				Dim p As Process

				p = CType(mcolProcesses.Item(strProcessId), Process)
				' Get the most current data
				p.Refresh()

				' Get the process detail
				EnumProcess(p)
				' Get the thread detail
				EnumThreads(p)
			End If
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try
	End Sub

	Private Sub mnuModules_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModules.Click, ctxViewMods.Click
		' Load the child form to display module information
		Try
			Dim lv As ListView = Me.lvProcesses

			If lv.SelectedItems.Count = 1 Then

				Dim strProcessId As String = lv.SelectedItems(0).SubItems(1).Text
				' Check to see if we got our fake 'total' process
				If strProcessId = PID_NA Then
					Exit Sub
				End If

				Dim p As Process

				p = CType(mcolProcesses.Item(strProcessId), Process)

				' Don't enumerate the idle process.
				' You will receive an access denied error.
				If p.ProcessName = PROCESS_IDLE Then
					Exit Sub
				End If
				' Nothing to show
				If p.ProcessName = PROCESS_SYSTEM Then
					Exit Sub
				End If
				p.Refresh()

				' Finally check to see if we can even 
				' Get the module count.
				' If not, no point in going further.
				Try
					Dim i As Integer = p.Modules.Count
				Catch exp As System.ComponentModel.Win32Exception
					MessageBox.Show("Sorry, you are not authorized to read this information.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				End Try
				' If the form is not available, load it
				If mfrmMod Is Nothing Then
					mfrmMod = New frmModules()
				End If

				' Pass the selected process
				mfrmMod.ParentProcess = p
				' Get the module data
				mfrmMod.RefreshModules()
				' Show the form
				mfrmMod.ShowDialog(Me)
			End If
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try
	End Sub

	Private Sub mnuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click, ctxRefresh.Click
		' Refresh the process list
		Me.sbInfo.Text = "Refreshing list, please wait"
		Me.sbInfo.Refresh()
		EnumProcesses()
		Me.sbInfo.Text = "Ready"
	End Sub

	Private Sub AddNameValuePair(ByVal Item As String, ByVal SubItem As String)
		' Helper procedure to add name/value pairs to a listview control
		With mits.Add(Item)
			.SubItems.Add(SubItem)
		End With
	End Sub

	Private Sub EnumThreads(ByVal p As Process)
		' Get the thread information for the process.
		' This information is about the physical Win32 threads
		' not System.Threading.Thread threads.
		Try
			Me.lvThreads.Items.Clear()

			Dim strProcessId As String

			If strProcessId = PID_NA Then
				Me.lvThreads.Items.Add(PID_NA)
			Else
				Dim t As ProcessThread

				' Timespans for individual thread times
				Dim tpt As TimeSpan
				Dim tppt As TimeSpan
				Dim tupt As TimeSpan

				For Each t In p.Threads
					' Get thread time and store
					tppt = t.PrivilegedProcessorTime
					tupt = t.UserProcessorTime
					tpt = t.TotalProcessorTime

					' % User Processor Time for thread
					Dim strPUPT As String = CDbl(tupt.Ticks / tpt.Ticks).ToString("#0%")
					If tupt.Ticks = 0 Then
						strPUPT = "0%"
					End If

					' % Privileged Processor Time for thread
					Dim strPPPT As String = CDbl(tppt.Ticks / tpt.Ticks).ToString("#0%")
					If tppt.Ticks = 0 Then
						strPPPT = "0%"
					End If

					Dim strTPT As String
					With tpt
						strTPT = (.Days.ToString("00") & "." & .Hours.ToString("00") & ":" & .Minutes.ToString("00") & ":" & .Seconds.ToString("00"))
					End With

					With Me.lvThreads.Items.Add(t.Id.ToString())
						.SubItems.Add(t.BasePriority.ToString())
						.SubItems.Add(t.CurrentPriority.ToString())
						Try
							.SubItems.Add(t.PriorityBoostEnabled.ToString())
						Catch exp As System.ComponentModel.Win32Exception
							.SubItems.Add("N/A")
						End Try
						Try
							.SubItems.Add(t.PriorityLevel.ToString())
						Catch exp As System.ComponentModel.Win32Exception
							.SubItems.Add("N/A")
						End Try

						.SubItems.Add(strPPPT)
						.SubItems.Add(Hex(t.StartAddress.ToInt32()).ToLower())
						.SubItems.Add(t.StartTime.ToShortDateString() & " " & t.StartTime.ToShortTimeString())
						.SubItems.Add(strTPT)
						.SubItems.Add(strPUPT)
					End With
				Next
			End If
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try

	End Sub

	Private Sub EnumProcess(ByVal p As Process)
		' Get process information
		Dim lv As ListView = Me.lvProcessDetail
		lv.Items.Clear()

		If p.ProcessName = PROCESS_IDLE Then
			Exit Sub
		End If

		mits = lv.Items

		Const NA As String = "Not Authorized"

		Try
			AddNameValuePair("Start Time", p.StartTime.ToLongDateString() & " " & p.StartTime.ToLongTimeString())
			AddNameValuePair("Responding", p.Responding.ToString())

			Try
				AddNameValuePair("Handle", p.Handle.ToString())
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Handle", NA)
			End Try

			AddNameValuePair("Handle Count", p.HandleCount.ToString("N0"))

			Try
				AddNameValuePair("Main Window Handle", p.MainWindowHandle.ToString())
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Main Window Handle", NA)
			End Try

			Try
				AddNameValuePair("Main Window Title", p.MainWindowTitle)
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Main Window Title", NA)
			End Try

			Try
				' Check to make sure we have a valid reference.
				' The System process is most notable for not exposing 
				' any module data.
				If p.MainModule Is Nothing Then
					AddNameValuePair("Main Module", String.Empty)
				Else
					AddNameValuePair("Main Module", p.MainModule.ModuleName)
				End If
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Main Module", NA)
			End Try

			Try
				AddNameValuePair("Module Count", p.Modules.Count.ToString("N0"))
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Module Count", NA)
			End Try

			AddNameValuePair("Base Priority", p.BasePriority.ToString())

			Try
				AddNameValuePair("Priority Boost Enabled", p.PriorityBoostEnabled.ToString())
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Priority Boost Enabled", NA)
			End Try

			Try
				AddNameValuePair("Priority Class", p.PriorityClass.ToString())
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Priority Class", NA)
			End Try

			Try
				AddNameValuePair("Processor Affinity", p.ProcessorAffinity.ToInt32.ToString())
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Processor Affinity", NA)
			End Try

			AddNameValuePair("Thread Count", p.Threads.Count.ToString())

			Try
				AddNameValuePair("Min Working Set", p.MinWorkingSet.ToInt32.ToString("N0"))
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Min Working Set", NA)
			End Try
			Try
				AddNameValuePair("Max Working Set", p.MaxWorkingSet.ToInt32.ToString("N0"))
			Catch exp As System.ComponentModel.Win32Exception
				AddNameValuePair("Max Working Set", NA)
			End Try

			AddNameValuePair("Working Set", p.WorkingSet.ToString("N0"))
			AddNameValuePair("Peak Working Set", p.PeakWorkingSet.ToString("N0"))

			AddNameValuePair("Private Memory Size", p.PrivateMemorySize.ToString("N0"))
			AddNameValuePair("Nonpaged System Memory Size", p.NonpagedSystemMemorySize.ToString("N0"))
			AddNameValuePair("Paged Memory Size", p.PagedMemorySize.ToString("N0"))
			AddNameValuePair("Peak Paged Memory Size", p.PeakPagedMemorySize.ToString("N0"))
			AddNameValuePair("Virtual Memory Size", p.VirtualMemorySize.ToString("N0"))
			AddNameValuePair("Peak Virtual Memory Size", p.PeakVirtualMemorySize.ToString("N0"))

		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

		End Try
	End Sub

	Private Sub EnumProcesses()
		' Enumerate all processes
		Try
			Dim Processes() As Process

			' Timespans for individual process information
			Dim tpt As TimeSpan
			Dim tppt As TimeSpan
			Dim tupt As TimeSpan

			' Timespans for machine
			Dim mtpt As TimeSpan
			Dim mtppt As TimeSpan
			Dim mtupt As TimeSpan

			Dim i As Integer
			Dim p As Process

			If Not mcolProcesses Is Nothing Then
				mcolProcesses = New Collection()
			End If

			If Me.lvProcesses.Items.Count > 0 Then
				Me.lvProcesses.Items.Clear()
				Me.lvProcessDetail.Items.Clear()
				Me.lvThreads.Items.Clear()
			End If
			Processes = Process.GetProcesses()

			For Each p In Processes
				mcolProcesses.Add(p, p.Id.ToString())

				' Get processor time and store
				tppt = p.PrivilegedProcessorTime
				tupt = p.UserProcessorTime
				tpt = p.TotalProcessorTime

				' Add the current process’ times to total times.
				mtpt = mtpt.Add(tpt)
				mtppt = mtppt.Add(tppt)
				mtupt = mtupt.Add(tupt)

				' % User Processor Time
				Dim strPUPT As String = CDbl(tupt.Ticks / tpt.Ticks).ToString("#0%")
				' % Privileged Processor Time
				Dim strPPPT As String = CDbl(tppt.Ticks / tpt.Ticks).ToString("#0%")

				Dim strTPT As String
				With tpt
					strTPT = (.Days.ToString("00") & "." & .Hours.ToString("00") & ":" & .Minutes.ToString("00") & ":" & .Seconds.ToString("00"))
				End With

				With Me.lvProcesses.Items.Add(p.ProcessName & " (0x" & Hex(p.Id).ToLower() & ")")
					.SubItems.Add(p.Id.ToString())
					.SubItems.Add(strTPT)
					.SubItems.Add(strPPPT)
					.SubItems.Add(strPUPT)
				End With
			Next

			' % Total User Processor Time
			Dim mstrPUPT As String = CDbl(mtupt.Ticks / mtpt.Ticks).ToString("#0%")
			' % Total Privileged Processor Time
			Dim mstrPPPT As String = CDbl(mtppt.Ticks / mtpt.Ticks).ToString("#0%")

			Dim mstrTPT As String
			With mtpt
				mstrTPT = (.Days.ToString("00") & "." & .Hours.ToString("00") & ":" & .Minutes.ToString("00") & ":" & .Seconds.ToString("00"))
			End With

			' Add entry for all processes
			With Me.lvProcesses.Items.Add(PROCESS_NAME_TOTAL)
				.SubItems.Add(PID_NA)
				.SubItems.Add(mstrTPT)
				.SubItems.Add(mstrPPPT)
				.SubItems.Add(mstrPUPT)
			End With
		Catch exp As Exception
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

End Class