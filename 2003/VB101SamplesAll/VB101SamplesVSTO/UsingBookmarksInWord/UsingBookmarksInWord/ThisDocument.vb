
Public Class ThisDocument

    Dim employeeControl As EmployeeSelectorUserControl

    Private Sub ThisDocument_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        ' Create a new instance of the employee selector
        ' user control, then bind to the click event
        employeeControl = New EmployeeSelectorUserControl()

        ' Add the user control to the Document Actions pane.
        Globals.ThisDocument.ActionsPane.Controls.Add(employeeControl)
        CreatePhoneBookmark()
    End Sub

    ' <summary>
    ' The first name, last name, job title, and email address Bookmark
    ' objects are created at design time.  The Phone Bookmark is
    ' created at runtime to demonstrate how it works.
    ' </summary>
    Public Sub CreatePhoneBookmark()
        ' Create a new range from position 139-146
        Dim pb As Word.Range = Range()

        ' The new range spans characters 139 to 146.  As
        ' a placeholder, the documents uses spaces in that
        ' position initially.
        pb.Start = 139
        pb.End = 146

        ' The initial placeholder text is set
        pb.Text = "<Phone>"

        ' Add the new Range object to the Bookmarks collection.
        Globals.ThisDocument.Bookmarks.Add("phoneBookmark", pb)
    End Sub

    Private Sub ThisDocument_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
