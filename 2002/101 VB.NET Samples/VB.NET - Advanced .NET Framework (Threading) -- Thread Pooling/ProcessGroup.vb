Option Strict On

' This class encapsulates a two second process for non-threaded, threaded, and thread-
' pool operations.
Public Class ProcessGroup
    ' Constructor
    Public Sub New(ByVal ActiveLabel As Label, _
                   ByVal ThreadNumLabel As Label, _
                   ByVal IsPoolThreadLabel As Label)
        lblActive = ActiveLabel
        lblThreadNum = ThreadNumLabel
        lblIsPoolThread = IsPoolThreadLabel

        ' Add one to the shared property numberOfProcesses.
        numberOfProcesses += 1
    End Sub

    Private lblActive As Label
    Private lblIsPoolThread As Label
    Private lblThreadNum As Label

    ' Shared members
    Private Shared highIntensity As Boolean
    Private Shared numberOfProcesses As Integer = 0
    Private Shared processesCompleted As Integer
    Private Shared ticksElapsed As Integer

    Shared ReadOnly Property GetTicksElapsed() As Integer
        Get
            Return ticksElapsed
        End Get
    End Property

    Shared WriteOnly Property SetHighIntensity() As Boolean
        Set(ByVal Value As Boolean)
            highIntensity = Value
        End Set
    End Property

    Public Event Completed()

    ' Initialize Shared members for another run
    Shared Sub PrepareToRun()
        processesCompleted = 0
        ticksElapsed = Environment.TickCount
    End Sub

    ' This procedure runs a two second process, updating the appropriate labels, 
    ' forcing refresh in case Main thread is starved.
    Public Sub Run()
        ' Show that we are active in green.
        lblActive.Text = "Active"
        lblActive.ForeColor = Color.Green
        lblActive.Refresh()

        ' Update ThreadNum label with current thread number.  GetHashCode will contain
        ' a unique value for each thread.
        lblThreadNum.Text = Threading.Thread.CurrentThread.GetHashCode().ToString
        lblThreadNum.Refresh()

        ' Update the IsThreadPooled label with Yes/No depending on whether the current
        ' thread is a pool thread.
        If Threading.Thread.CurrentThread.IsThreadPoolThread Then
            lblIsPoolThread.Text = "Yes"
        Else
            lblIsPoolThread.Text = "No"
        End If
        lblIsPoolThread.Refresh()

        ' If highIntensity is selected loop based on TickCount for two seconds to max 
        ' out the CPU, otherwise let this thread sleep for 2 seconds. 
        If highIntensity Then
            Dim ticks As Integer = Environment.TickCount
            While Environment.TickCount - ticks < 2000
            End While
        Else
            Threading.Thread.CurrentThread.Sleep(2000)
        End If

        ' Process is finished, display inactive in red
        lblActive.Text = "Inactive"
        lblActive.ForeColor = Color.Red
        lblActive.Refresh()

        ' Add to the shared property ProcessCompleted.  If all processes are done, 
        ' raise a completed event.  This is necessary for the threaded processes,
        ' to allow the user interface to know when to enable buttons, and update
        ' time elapsed, since they return immediately.
        processesCompleted += 1
        If processesCompleted = numberOfProcesses Then
            ticksElapsed = Environment.TickCount - ticksElapsed
            RaiseEvent Completed()
        End If
    End Sub

    ' This subroutine is callback for Threadpool.QueueWorkItem.  This is the necessary
    ' subroutine signiture for QueueWorkItem, and run is proper for creating a Thread
    ' so the two subroutines cannot be combined, so instead just call Run from here.
    Private Sub RunPooledThread(ByVal state As Object)
        Run()
    End Sub

    ' Add a queue request to Threadpool with a callback to RunPooledThread (which calls
    ' Run()
    Sub StartPooledThread()
        ' Create a callback to subroutine RunPooledThread
        Dim callback As New Threading.WaitCallback(AddressOf RunPooledThread)
        ' And put in a request to ThreadPool to run the process.
        Threading.ThreadPool.QueueUserWorkItem(callback, Nothing)
    End Sub

    ' Start a new thread, running subroutine Run.
    Sub StartThread()
        Dim newThread As New Threading.Thread(AddressOf Run)
        newThread.Start()
    End Sub
End Class
