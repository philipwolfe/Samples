Option Strict On

Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Init the checkboxes based on the current state of the MonthCalendar
        ShowTodayCheckBox.Checked = MonthPicker.ShowToday
        ShowTodayCircleCheckBox.Checked = MonthPicker.ShowTodayCircle

        ' Init the Combo box to first selection (Sunday)
        FirstDayOfWeekComboBox.SelectedIndex = 0

        ' Init the date and time labels
        ShowSelectedDateTime()

        ' set initial value of label to today
        MonthDateLabel.Text = MonthPicker.TodayDate.ToShortDateString
    End Sub

    ' Modify the DateTimeLabel text to reflect the currently selected date and time.
    Private Sub ShowSelectedDateTime()
        Dim dateStr As String = DatePicker.Value.ToShortDateString
        Dim timeStr As String = TimePicker.Value.ToShortTimeString

        ' Concatenate the date picker value with the time picker value
        DateTimeLabel.Text = dateStr & " " & timeStr
    End Sub

    ' Event when user changes the date
    Private Sub DatePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatePicker.ValueChanged
        ShowSelectedDateTime()
    End Sub

    ' Event when user changes the time
    Private Sub TimePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimePicker.ValueChanged
        ShowSelectedDateTime()
    End Sub

    ' Event when the user clicks on a date
    Private Sub MonthPicker_DateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthPicker.DateChanged
        ' Show the start and end dates
        MonthDateLabel.Text = e.Start.ToShortDateString() & " -- " & e.End.ToShortDateString()
    End Sub

    'ShowToday: Default value is set to True which displays the current date at the bottom of the Calendar. Setting it to False will hide it.
    Private Sub TodayCheckBox_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowTodayCheckBox.CheckStateChanged
        MonthPicker.ShowToday = ShowTodayCheckBox.Checked
    End Sub

    'ShowTodayCircle: Default value is set to True which displays a red circle on the current date. Setting it to False will make the circle disappear.
    Private Sub TodayCircleCheckBox_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowTodayCircleCheckBox.CheckStateChanged
        MonthPicker.ShowTodayCircle = ShowTodayCircleCheckBox.Checked
    End Sub

    'FirstDayOfWeek: Default value is Default which means that the week starts with Sunday as the first day and Saturday as last. You can set the first day of the week depending upon your choice by selecting from the predefined list with this property.
    Private Sub FirstDayOfWeekComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstDayOfWeekComboBox.SelectedIndexChanged
        Select Case FirstDayOfWeekComboBox.SelectedIndex
            Case 0 : MonthPicker.FirstDayOfWeek = Day.Sunday
            Case 1 : MonthPicker.FirstDayOfWeek = Day.Monday
            Case 2 : MonthPicker.FirstDayOfWeek = Day.Tuesday
            Case 3 : MonthPicker.FirstDayOfWeek = Day.Wednesday
            Case 4 : MonthPicker.FirstDayOfWeek = Day.Thursday
            Case 5 : MonthPicker.FirstDayOfWeek = Day.Friday
            Case 6 : MonthPicker.FirstDayOfWeek = Day.Saturday
            Case Else : MonthPicker.FirstDayOfWeek = Day.Default
        End Select
    End Sub

End Class
