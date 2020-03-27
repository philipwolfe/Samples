
Public Class ThisWorkbook
    ' Declare a class-level variable for adding an ActionsPane control.
    ' To learn how to add an ActionsPage control to a Word project see
    ' http:'msdn2.microsoft.com/en-us/library/kfzd656e.
    Private myTheaterFinderActionsPane As New theaterFinderActionsPane()

    Private Sub ThisWorkbook_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        ' Add the ActionsPane control to the ActionsPane Controls collection.
        Me.ActionsPane.Controls.Add(myTheaterFinderActionsPane)
    End Sub

    Private Sub ThisWorkbook_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
