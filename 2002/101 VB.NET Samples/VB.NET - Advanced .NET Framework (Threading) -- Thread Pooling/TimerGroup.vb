Option Strict On

' This class encapsulates the functionality of the Threading.Timer class.  The main
' purpose to put this in a class is to allow the OnTimer subroutine to be able to 
' know which labels to update, since you cannot pass parameters to it.  
Public Class TimerGroup
    ' Constructor
    Public Sub New(ByVal OutputLabel As Label, _
                   ByVal ThreadNumLabel As Label, _
                   ByVal IsPoolThreadLabel As Label)
        lblOutput = OutputLabel
        lblThreadNum = ThreadNumLabel
        lblIsPoolThread = IsPoolThreadLabel
    End Sub

    Private lblIsPoolThread As Label
    Private lblOutput As Label
    Private lblThreadNum As Label
    Private myTimer As Threading.Timer

    ' This subroutine is the callback function for myTimer, called everytime timer fires
    Private Sub OnTimer(ByVal State As Object)
        ' Update the Output label with the time.
        lblOutput.Text = Now.Hour & ":" & Now.Minute & "." & Now.Second

        ' Update ThreadNum label with current thread number.  GetHashCode will contain
        ' a unique value for each thread.
        lblThreadNum.Text = Threading.Thread.CurrentThread.GetHashCode().ToString

        ' Update the IsThreadPooled label with Yes/No depending on whether the current
        ' thread is a pool thread.
        If Threading.Thread.CurrentThread.IsThreadPoolThread Then
            lblIsPoolThread.Text = "Yes"
        Else
            lblIsPoolThread.Text = "No"
        End If
    End Sub

    ' This subroutine start the timer, by creating a Threading.Timer object with
    ' a callback to OnTimer.  
    Public Sub StartTimer(ByVal period As Integer)
        ' Don't try to start a NULL timer.
        If IsNothing(myTimer) Then
            ' Create a callback to subroutine OnTimer
            Dim callback As New Threading.TimerCallback(AddressOf OnTimer)
            ' And start the timer, passing frequency specified in period.  Note: 
            ' Threading.Timer should not be confused with Timers.Timer.
            myTimer = New Threading.Timer(callback, Nothing, 0, period)
        End If
    End Sub

    ' This subroutine ends the timer by killing the Threading.Timer object. 
    Public Sub StopTimer()
        myTimer.Dispose()
        myTimer = Nothing
    End Sub
End Class
