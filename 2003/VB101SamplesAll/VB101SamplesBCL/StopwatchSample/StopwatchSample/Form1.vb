Public Class Form1

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadStaticInfo()

        m_stopWatch = New Stopwatch()

        LoadInstanceInfo()

        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
    End Sub

    Private Sub LoadStaticInfo()
        Me.SWFrequency.Text = Stopwatch.Frequency.ToString("N")
        Me.checkBox1.Checked = Stopwatch.IsHighResolution
        Me.SWTimeStamp.Text = Stopwatch.GetTimeStamp().ToString("N")
    End Sub

    Private Sub LoadInstanceInfo()
        Me.ElapsedTimeSpan.Text = m_stopWatch.Elapsed.ToString
        Me.ElapsedMilliseconds.Text = m_stopWatch.ElapsedMilliseconds.ToString("N")
        Me.ElapsedTicks.Text = m_stopWatch.ElapsedTicks.ToString("N")
    End Sub

    Private Sub Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Start.Click
        m_stopWatch.Start()
    End Sub

    Private Sub StopTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopTimer.Click
        m_stopWatch.Stop()
        LoadInstanceInfo()
    End Sub

    Private Sub Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset.Click
        m_stopWatch.Reset()
        LoadInstanceInfo()
    End Sub

    Private Sub StartNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartNew.Click
        m_stopWatch = Stopwatch.StartNew()
        LoadInstanceInfo()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If m_stopWatch.IsRunning = True Then
            LoadInstanceInfo()
        End If
    End Sub


    Private m_stopWatch As Stopwatch

End Class
