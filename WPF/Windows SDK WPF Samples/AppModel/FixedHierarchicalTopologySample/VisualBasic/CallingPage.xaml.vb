Public Class CallingPage
    Inherits Page

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub startTaskHyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim taskLauncher As New TaskLauncher
        AddHandler taskLauncher.Return, New ReturnEventHandler(Of TaskContext)(AddressOf Me.task_Return)
        MyBase.NavigationService.Navigate(taskLauncher)
    End Sub

    Public Sub task_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of TaskContext))
        Dim taskContext As TaskContext = e.Result
        Me.taskResultsTextBlock.Visibility = System.Windows.Visibility.Visible
        Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & taskContext.Result.ToString)
        If (taskContext.Result = TaskResult.Finished) Then
            Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & "Data Item 1: " & DirectCast(taskContext.Data, TaskData).DataItem1)
            Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & "Data Item 2: " & DirectCast(taskContext.Data, TaskData).DataItem2)
            Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & "Data Item 3: " & DirectCast(taskContext.Data, TaskData).DataItem3)
            Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & "Data Item 4: " & DirectCast(taskContext.Data, TaskData).DataItem4)
        End If
    End Sub

End Class