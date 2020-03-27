
Public Class Sheet1
    Dim userControl As EmployeeSelectorUserControl

    Private Sub Sheet1_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        userControl = New EmployeeSelectorUserControl()

        Globals.ThisWorkbook.ActionsPane.Controls.Add(userControl)
    End Sub

    Private Sub Sheet1_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
