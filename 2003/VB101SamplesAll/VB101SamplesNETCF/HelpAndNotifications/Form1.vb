Option Strict On

Imports Microsoft.WindowsCE.Forms ' needed for Notification events
Imports System.Text ' needed for StringBuilder

Public Class Form1

    Private currentTickCount As Integer ' Used with progress bar to show user progress

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Display the OK button for closing the application.
        MinimizeBox = False

        ' Set timer interval
        TimerIntervalTrackBar.Value = 3 ' init to 3 second interval
        StatusBar1.Text = String.Empty

        ' Set instructions in label
        Dim builder As New StringBuilder
        builder.Append("This sample demonstrates both Help and Notification features." & ControlChars.CrLf)
        builder.Append(ControlChars.CrLf & "Click the Start Button to see a notification popup based on a timer that processes an HTML response." & ControlChars.CrLf)
        builder.Append(ControlChars.CrLf & "Use the context menu of the track bar to see tool tip style context sensitive help using a notification popup." & ControlChars.CrLf)
        builder.Append(ControlChars.CrLf & "Use the Pocket PC Start Menu -> Help to see a notification popup." & ControlChars.CrLf)
        DescriptionLabel.Text = builder.ToString
    End Sub

    ' Inits the Notification object based on caption and html string
    Private Sub InitNotification(ByVal caption As String, ByVal html As String)
        HelpNotification.Caption = caption

        ' Notification will display for 10 seconds before closing automatically
        HelpNotification.InitialDuration = 10

        ' If notification is urgent, set to true
        HelpNotification.Critical = False

        ' Set the Text property to the HTML string
        HelpNotification.Text = html

        ' Make the Notification visible
        HelpNotification.Visible = True
    End Sub

    Private Function GetTimerNotificationHtml() As String
        Dim builder As New StringBuilder()
        builder.Append("<html><body>")
        builder.Append("<font color=""#0000FF""><b>Timer Notification Enabled</b></font>")
        builder.Append("<form method=""GET"" action=ChangeInterval>")
        builder.Append("<br>Use the track bar on the form to change ")
        builder.Append("the Notification Timer Interval.<br><br>")
        builder.Append("Or change it here...")
        builder.Append("<SELECT NAME=""TimeListBox"">")
        builder.Append("<OPTION VALUE=""1"">1 sec</OPTION>")
        builder.Append("<OPTION VALUE=""2"">2 sec</OPTION>")
        builder.Append("<OPTION VALUE=""3"">3 sec</OPTION>")
        builder.Append("<OPTION VALUE=""4"">4 sec</OPTION>")
        builder.Append("<OPTION VALUE=""5"">5 sec</OPTION></SELECT>")
        builder.Append("<br><br>")

        ' Add submit to cause response
        builder.Append("<input type='submit'>")

        ' Note if a link or element has a name of "cmd:n", where n is any integer, the following results:
        ' 0 is reserved, 
        ' 1 sends a notification but does not dismiss the bubble, 
        ' 2 dismisses the bubble and places an icon in the title bar and the Microsoft.WindowsCE.Forms.Notification.ResponseSubmitted event is not raised.
        ' 3 or greater closes the bubble the Microsoft.WindowsCE.Forms.Notification.ResponseSubmitted event is not raised.
        builder.Append("<input type=button name='cmd:2' value='Dismiss'>")
        builder.Append("<input type=button name='cmd:3' value='Close'>")
        builder.Append("</body></html>")

        Return builder.ToString()
    End Function

    Private Function GetTrackBarHelpHtml() As String
        Dim builder As New StringBuilder()
        builder.Append("<html><body>")
        builder.Append("<font color=""#0000FF""><b>Track Bar Help</b></font>")
        builder.Append("<br>Use the Track Bar control to adjust the time it takes for a notification to popup.<form method=""GET"" action=notify>")
        builder.Append("<br><br>")
        builder.Append("<input type=button name='cmd:3' value='Close'>") ' value of "cmd:3" closes notification with no response
        builder.Append("</body></html>")

        Return builder.ToString()
    End Function

    Private Function GetFormHelpHtml() As String
        Dim builder As New StringBuilder()

        builder.Append("<html><body>")
        builder.Append("<font color=""#0000FF""><b>Form Help Notification</b></font>")
        builder.Append("<br>Place Form Help here...")
        builder.Append("<br><br>")
        builder.Append("<input type=button name='cmd:3' value='Close'>") ' value of "cmd:3" closes notification with no response
        builder.Append("</body></html>")

        Return builder.ToString()
    End Function

    ' The BalloonChanged event fires before the Notification is displayed or closed
    Private Sub HelpNotification_BalloonChanged(ByVal sender As System.Object, ByVal e As Microsoft.WindowsCE.Forms.BalloonChangedEventArgs) _
        Handles HelpNotification.BalloonChanged
        ' Add Code here to update UI...in this case the status bar
        If e.Visible = True Then
            StatusBar1.Text = HelpNotification.Caption
        Else
            StatusBar1.Text = "Notification Closed"
        End If
    End Sub

    ' When a ResponseSubmitted event occurs, this event handler
    ' parses the response to determine values in the HTML form.
    Private Sub HelpNotification_ResponseSubmitted(ByVal sender As System.Object, ByVal e As Microsoft.WindowsCE.Forms.ResponseSubmittedEventArgs) _
        Handles HelpNotification.ResponseSubmitted
        ' Check the response.  If the action value of the form is "ChangeInterval", then
        ' get the value of the selected option from the SELECT list. Based on how the 
        ' GetFormHelpHtml method created the HTML form we should expect a reponse string like
        ' this:  ChangeInterval?TimeListBox=1
        Dim resStr As String = e.Response
        Dim len As Integer = resStr.Length ' get length once for efficiency

        If resStr.Substring(0, len - 2) = "ChangeInterval?TimeListBox" Then
            TimerIntervalTrackBar.Value = Convert.ToInt32(resStr.Substring(len - 1, 1))
            SecondsLabel.Text = TimerIntervalTrackBar.Value.ToString() & " s"
        End If
    End Sub

    ' Similar to the context-sensitive F1 key on your desktop PC, which opens different help files 
    ' depending on which application is active when you press it, the Start > Help command on your Pocket PC 
    ' will fire the HelpRequested event so that a Help file that is specific to whichever application is 
    ' "in front"
    Private Sub Form1_HelpRequested(ByVal sender As System.Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) _
        Handles MyBase.HelpRequested
        InitNotification("Form Help", GetFormHelpHtml())
    End Sub

    ' Poor man's tool tip on the Pocket PC can be implemented by using a context menu on a control and then
    ' launching a Notification Window
    Private Sub HelpMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles HelpMenuItem.Click
        InitNotification(HelpContextMenu.SourceControl.Name & " Help", GetTrackBarHelpHtml())
    End Sub

    ' Button event starts the timer.  When time is up the notification will display
    Private Sub StartTimerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles StartTimerButton.Click
        Dim secs As Integer = TimerIntervalTrackBar.Value

        ' Init the progress bar
        currentTickCount = 0 ' reset current tick counter
        ProgressBar1.Maximum = secs
        ProgressBar1.Minimum = 0
        ProgressBar1.Value = 0

        ' Init the status Bar
        StatusBar1.Text = "Waiting for Notification..."
        NotificationTimer.Interval = 1000 ' interrupt every second
        NotificationTimer.Enabled = True

    End Sub

    ' Tick event updates counter and progress bar until count is reached.
    Private Sub NotificationTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles NotificationTimer.Tick

        currentTickCount += 1 ' increment current tick count
        ProgressBar1.Value = currentTickCount ' set Progress Bar

        If currentTickCount >= TimerIntervalTrackBar.Value Then
            ' Display the notification because the time interval has been reached
            NotificationTimer.Enabled = False
            StatusBar1.Text = "Timer Notification Enabled."
            InitNotification("Timer Notification Enabled", GetTimerNotificationHtml())
        End If

    End Sub

    ' Display the number of seconds selected by the TrackBar control by updating the SecondsLabel
    Private Sub TrackBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TimerIntervalTrackBar.ValueChanged
        SecondsLabel.Text = TimerIntervalTrackBar.Value.ToString() & " s"
    End Sub

End Class
