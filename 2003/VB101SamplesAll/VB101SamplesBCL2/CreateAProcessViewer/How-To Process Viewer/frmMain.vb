'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio 2005.


Public Class frmMain
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

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, MyBase.Click
        ' Load the list of processes
        EnumProcesses()
    End Sub

    Private Sub lvProcesses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProcesses.SelectedIndexChanged, lvProcesses.Click
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

            Dim strProcessId As String = Nothing

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

            AddNameValuePair("Working Set", p.WorkingSet64.ToString("N0"))
            AddNameValuePair("Peak Working Set", p.WorkingSet64.ToString("N0"))

            AddNameValuePair("Private Memory Size", p.PrivateMemorySize64.ToString("N0"))
            AddNameValuePair("Nonpaged System Memory Size", p.PrivateMemorySize64.ToString("N0"))
            AddNameValuePair("Paged Memory Size", p.PrivateMemorySize64.ToString("N0"))
            AddNameValuePair("Peak Paged Memory Size", p.PrivateMemorySize64.ToString("N0"))
            AddNameValuePair("Virtual Memory Size", p.PrivateMemorySize64.ToString("N0"))
            AddNameValuePair("Peak Virtual Memory Size", p.PrivateMemorySize64.ToString("N0"))

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
                Try
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
                Catch
                    '
                    'handles access to the system idle process.
                    'the 2.0 framework does not support access to the system idle process.
                    '
                End Try
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