Option Strict Off

'***********************************************************************
'* Class ActiveTasksForm
'* 
'* The ActiveTasksForm demonstrates various new language features of
'* Visual Basic 7.  The form supports launching of tasks that are run on
'* background threads.
'***********************************************************************
Public Class ActiveTasksForm
    Inherits System.Windows.Forms.Form

    'Required by the WFC Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents LaunchFractal As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label  
    Private ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private StateColumnHeader As System.Windows.Forms.ColumnHeader
    Private id As System.Windows.Forms.ColumnHeader
    Private complete As System.Windows.Forms.ColumnHeader
    Private task As System.Windows.Forms.ColumnHeader
    Private timer As Timers.Timer

        
    Private ListView1 As System.Windows.Forms.ListView

    Public Sub New()
        MyBase.New()

        'This call is required by the WFC Form Designer.
        InitializeComponent()

        Timer = New Timers.Timer
        AddHandler Timer.Tick, New EventHandler(AddressOf UpdateTaskList)
        timer.Interval = 1000
        Timer.Enabled = True
        Try
            Dim SubMenu As MenuItem = New MenuItem("Set Priority", New MenuItem() {New MenuItem("Highest", AddressOf SetPriorityHighest), New MenuItem("High", AddressOf SetPriorityHigh), New MenuItem("Normal", AddressOf SetPriorityNormal), New MenuItem("Low", AddressOf SetPriorityLow), New MenuItem("Lowest", AddressOf SetPriorityLowest)})
            ListView1.ContextMenu = New ContextMenu(New MenuItem () {New MenuItem("Suspend", AddressOf SuspendSelectedTasks), New MenuItem("Resume", AddressOf RestartSelectedTasks), SubMenu})
        Catch e As Exception
            messagebox.Show(e.Message, CStr(e.Source))
        End Try
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

    'The main entry point for the application
    Shared Sub Main()
        System.Windows.Forms.Application.Run(New ActiveTasksForm())
    End Sub

    'NOTE: The following procedure is required by the WFC Form Designer
    'It can be modified using the WFC Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LaunchFractal = New System.Windows.Forms.Button()
        Me.id = New System.Windows.Forms.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.complete = New System.Windows.Forms.ColumnHeader()
        Me.StateColumnHeader = New System.Windows.Forms.ColumnHeader()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.task = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = True
        '@design Me.TrayAutoArrange = True
        LaunchFractal.Location = New System.Drawing.Point(488, 156)
        LaunchFractal.Size = New System.Drawing.Size(136, 23)
        LaunchFractal.TabIndex = 6
        LaunchFractal.Text = "Launch Fractal Window"

        id.Text = "ID"
        id.Width = 50
        id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left

        Label1.Location = New System.Drawing.Point(20, 12)
        Label1.Text = "Active Windows:"
        Label1.Size = New System.Drawing.Size(168, 16)
        Label1.TabIndex = 5

        complete.Text = "Percent Complete"
        complete.Width = 100
        complete.TextAlign = System.Windows.Forms.HorizontalAlignment.Left

        StateColumnHeader.Text = "State"
        StateColumnHeader.Width = 100
        StateColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Left

        ListView1.Location = New System.Drawing.Point(16, 28)
        ListView1.Text = "ListView1"
        ListView1.Size = New System.Drawing.Size(608, 120)
        ListView1.FullRowSelect = True
        ListView1.View = System.Windows.Forms.View.Details
        ListView1.ForeColor = System.Drawing.SystemColors.WindowText
        ListView1.TabIndex = 0

        Dim a__1(4) As System.Windows.Forms.ColumnHeader
        a__1(0) = id
        a__1(1) = task
        a__1(2) = complete
        a__1(3) = StateColumnHeader
        a__1(4) = ColumnHeader1
        ListView1.Columns.AddRange(a__1)

        task.Text = "Name"
        task.Width = 250
        task.TextAlign = System.Windows.Forms.HorizontalAlignment.Left

        ColumnHeader1.Text = "Priority"
        ColumnHeader1.Width = 100
        ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Text = "Tasks"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(640, 189)

        Me.Controls.Add(LaunchFractal)
        Me.Controls.Add(Label1)
        Me.Controls.Add(ListView1)
    End Sub

    '***********************************************************************
    '* Sub LaunchFractal_Click Handles LaunchFractal.Click
    '*
    '* Create and launch one of four Mandelbrot calculation tasks for 
    '* testing the FractalForm class.  The calculations are nested, so
    '* that they zoom deeper into the fractal.
    '***********************************************************************
    Private FractalNumber As Integer = 0
    Private Sub LaunchFractal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchFractal.Click
        Select Case FractalNumber
            Case 0
                LaunchTask(New FractalForm(180, 1024, 0.336480562440052, 8.97430819128656E-02, 3.09706707162137E-02))
            Case 1
                LaunchTask(New FractalForm(180, 1024, 0.353110794490807, 7.47812592707889E-02, 1.32356100727827E-02))
            Case 2
                LaunchTask(New FractalForm(180, 1024, 0.353837455435979, 0.072705085141725, 5.12555488112665E-03))
            Case 3
                LaunchTask(New FractalForm(180, 1024, 0.357219415177228, 7.06249099273777E-02, 4.25651616425771E-04))
        End Select
        FractalNumber += 1
        If FractalNumber > 3 Then FractalNumber = 0
    End Sub


    '***********************************************************************
    '* Sub SetPriorityLowest
    '*
    '* Set the Priority of the selected tasks to the lowest priority.
    '***********************************************************************
    Private Sub SetPriorityLowest(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetPrioritySelectedItems(ThreadPriority.Lowest)
    End Sub

    '***********************************************************************
    '* Sub SetPriorityLow
    '*
    '* Set the Priority of the selected tasks to the "BelowNormal" priority.
    '***********************************************************************
    Private Sub SetPriorityLow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetPrioritySelectedItems(ThreadPriority.BelowNormal)
    End Sub

    '***********************************************************************
    '* Sub SetPriorityNormal
    '*
    '* Set the Priority of the selected tasks to the "Normal" priority.
    '***********************************************************************
    Private Sub SetPriorityNormal(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetPrioritySelectedItems(ThreadPriority.Normal)
    End Sub

    '***********************************************************************
    '* Sub SetPriorityHigh
    '*
    '* Set the Priority of the selected tasks to the "AboveNormal" priority.
    '***********************************************************************
    Private Sub SetPriorityHigh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetPrioritySelectedItems(ThreadPriority.AboveNormal)
    End Sub

    '***********************************************************************
    '* Sub SetPriorityHighest
    '*
    '* Set the Priority of the selected tasks to the "Highest" priority.
    '***********************************************************************
    Private Sub SetPriorityHighest(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetPrioritySelectedItems(ThreadPriority.Highest)
    End Sub

    '***********************************************************************
    '* Sub SetPrioritySelectedItems(ThreadPriority)
    '*
    '* Set the Priority of the selected tasks to specified ThreadPriority.
    '***********************************************************************
    Private Sub SetPrioritySelectedItems(ByVal priority As ThreadPriority)

        Dim TLI As TaskListItem

        For Each TLI In ListView1.SelectedItems
            If Not (TLI Is Nothing) Then
                TLI.Task.Thread.Priority = priority
                UpdateTaskListItem(TLI)
            End If
        Next
    End Sub

    '***********************************************************************
    '* Sub SuspendSelectedTasks()
    '*
    '* For each of the selected TaskListItems, suspend the thread if the 
    '* if the thread is currently running.
    '***********************************************************************
    Private Sub SuspendSelectedTasks(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim TLI As TaskListItem

        For Each TLI In ListView1.SelectedItems
            If Not (TLI Is Nothing) Then
                Try
                    TLI.Task.Thread.Suspend()
                    UpdateTaskListItem(TLI)
                Catch
                End Try
            End If
        Next
    End Sub

    '***********************************************************************
    '* Sub RestartSelectedTasks()
    '*
    '* For each of the selected TaskListItems, restart the thread if the 
    '* if the thread is currently suspended.
    '***********************************************************************
    Private Sub RestartSelectedTasks(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TLI As TaskListItem

        For Each TLI In ListView1.SelectedItems
            If Not (TLI Is Nothing) Then
                Try
                    TLI.Task.Thread.Resume()
                    UpdateTaskListItem(TLI)
                Catch  'ignore exceptions
                End Try
            End If
        Next
    End Sub

    '***********************************************************************
    '* Sub UpdateTaskListItem(TaskListItem)
    '*
    '* Update the contents of the strings in the display of the TaskListItem
    '* using information in the associated Task.
    '***********************************************************************
    Private Sub UpdateTaskListItem(ByVal TLI As TaskListItem)

        TLI.SubItems(2).Text = CStr(TLI.Task.PercentComplete())
        TLI.SubItems(3).Text = StateToString(TLI.Task.Thread.ThreadState)

        Try
            TLI.SubItems(4).Text = PriorityToString(TLI.Task.Thread.Priority)
        Catch
        End Try
    End Sub

    '***********************************************************************
    '* Function PriorityToString(ThreadPriority)
    '*
    '* Map values of the ThreadPriority enum to their names.
    '***********************************************************************
    Function PriorityToString(ByVal Priority As ThreadPriority) As String
        Select Case Priority
            Case Threading.ThreadPriority.Highest
                Return "Highest"
            Case Threading.ThreadPriority.AboveNormal
                Return "High"
            Case Threading.ThreadPriority.Normal
                Return "Normal"
            Case Threading.ThreadPriority.BelowNormal
                Return "Low"
            Case Threading.ThreadPriority.Lowest
                Return "Lowest"
            Case Else
                Throw New Exception("Invalid Priority")
        End Select
    End Function

    '***********************************************************************
    '* Function StringToState(ThreadState)
    '*
    '* Map values of the ThreadState enum to their names.
    '***********************************************************************
    Function StateToString(ByVal State As ThreadState) As String
        If (State And ThreadState.Suspended) Then
            Return "Suspended"
        ElseIf State And ThreadState.WaitSleepJoin Then
            Return "WaitSleepJoin"
        End If
        Select Case State
            Case ThreadState.Running
                Return "Running"
            Case ThreadState.Aborted
                Return "Aborted"
            Case ThreadState.AbortRequested
                Return "AbortRequested"
            Case ThreadState.Background
                Return "Background"
            Case ThreadState.StopRequested
                Return "StopRequested"
            Case ThreadState.SuspendRequested
                Return "SuspendRequested"
            Case ThreadState.Unstarted
                Return "Unstarted"
            Case ThreadState.Stopped
                Return "Stopped"
            Case ThreadState.WaitSleepJoin
                Return "WaitSleepJoin"
            Case Else
                Return "Other"
        End Select
    End Function

    '***********************************************************************
    '* Sub TaskCompleted(Task)
    '*
    '* Handles the OnTaskComplete event of tasks.
    '* Removes tasks from the tasklist.
    '* Note: executes on the task's thread. 
    '***********************************************************************
    Private Sub TaskCompleted(ByVal Task As task)
        Dim TLI As TaskListItem
        SyncLock ListView1.Items
            For Each TLI In ListView1.Items

                If Not (TLI Is Nothing) Then
                    If TLI.Task Is Task Then
                        ListView1.Items.Remove(TLI)
                        Exit For
                    End If
                End If
            Next
        End SyncLock
    End Sub

    '***********************************************************************
    '* Sub UpdateTaskList()
    '*
    '* Walks the all the TaskListItems and updates them. 
    '* Invoked by a Timer event.
    '***********************************************************************
    Sub UpdateTaskList(ByVal source As Object, ByVal e As EventArgs)
        Dim TLI As TaskListItem

        SyncLock ListView1.Items
            For Each TLI In ListView1.Items
                If Not (TLI Is Nothing) Then
                    UpdateTaskListItem(TLI)
                End If
            Next
        End SyncLock
    End Sub

    '***********************************************************************
    '* Sub LaunchTask(Task)
    '*
    '* Launch the specified task by creating a thread for it and a TaskItem
    '* then starting it on the new thread.
    '***********************************************************************
    Shared TaskID As Long
    Friend Sub LaunchTask(ByVal Task As task)
        Dim Thread As New Thread(AddressOf Task.StartTask)
        Dim ListItem As TaskListItem
        Task.Thread = Thread
        AddHandler Task.OnTaskComplete, AddressOf Me.TaskCompleted
        ListItem = New TaskListItem(Task, New String() {CStr(TaskID), Task.TaskName, "0", "Not Started", "Normal"})
        TaskID += 1
        ListView1.Items.Add(ListItem)
        Thread.Start()
    End Sub
End Class
