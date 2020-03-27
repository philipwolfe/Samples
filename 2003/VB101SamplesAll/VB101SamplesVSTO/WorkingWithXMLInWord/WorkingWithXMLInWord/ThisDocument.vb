Public Class ThisDocument
    ' Declare a class-level variable for adding an ActionsPane control.
    ' To learn how to add an ActionsPage control to a Word project see
    ' http://msdn2.microsoft.com/en-us/library/kfzd656e.
    Private myRssNavActionsPane As New RssNavActionsPane()

    Private Sub ThisDocument_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        ' Add the ActionsPane control to the ActionsPane Controls collection.
        Me.ActionsPane.Controls.Add(myRssNavActionsPane)
    End Sub

    Private Sub ThisDocument_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
