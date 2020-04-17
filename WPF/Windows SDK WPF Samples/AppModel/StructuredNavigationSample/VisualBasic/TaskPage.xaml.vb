Public Class TaskPage
    Inherits Page

    Public Sub New(ByVal initialDataItem1Value As String)
        Me.InitializeComponent()

        ' Set initial value
        Me.dataItem1TextBox.Text = initialDataItem1Value

    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Cancel task
        Me.TaskPageReturn(False)
    End Sub

    Private Sub okButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Accept task when Ok button is clicked
        Me.TaskPageReturn(True)
    End Sub

    Private Sub TaskPageReturn(ByVal taskResult As Boolean)
        Application.Current.Properties.Item("TaskResult") = taskResult
        Application.Current.Properties.Item("TaskData") = Me.dataItem1TextBox.Text
        ' Return to calling page
        MyBase.NavigationService.GoBack()
        ' Removing this page from navigation history
        MyBase.NavigationService.RemoveBackEntry()
    End Sub

End Class
