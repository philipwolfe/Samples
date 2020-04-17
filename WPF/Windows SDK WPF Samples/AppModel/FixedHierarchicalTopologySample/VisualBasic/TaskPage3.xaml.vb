Public Class TaskPage3
    Inherits PageFunction(Of TaskResult)

    Public Sub New(ByVal taskData As TaskData)
        Me.InitializeComponent()
        MyBase.DataContext = taskData
    End Sub

    Private Sub backButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MyBase.NavigationService.GoBack()
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.OnReturn(New ReturnEventArgs(Of TaskResult)(TaskResult.Canceled))
    End Sub

    Private Sub finishButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.OnReturn(New ReturnEventArgs(Of TaskResult)(TaskResult.Finished))
    End Sub

End Class