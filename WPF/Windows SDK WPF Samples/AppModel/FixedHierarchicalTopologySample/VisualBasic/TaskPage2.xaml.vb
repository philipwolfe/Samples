Public Class TaskPage2
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

    Private Sub nextButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If Me.youngRadioButton.IsChecked.Value Then
            DirectCast(MyBase.DataContext, TaskData).DataItem4 = Nothing
            Dim nextPageYoung As New TaskPage3(DirectCast(MyBase.DataContext, TaskData))
            AddHandler nextPageYoung.Return, New ReturnEventHandler(Of TaskResult)(AddressOf Me.taskPage_Return)
            MyBase.NavigationService.Navigate(nextPageYoung)
        Else
            DirectCast(MyBase.DataContext, TaskData).DataItem3 = Nothing
            Dim nextPageOld As New TaskPage4(DirectCast(MyBase.DataContext, TaskData))
            AddHandler nextPageOld.Return, New ReturnEventHandler(Of TaskResult)(AddressOf Me.taskPage_Return)
            MyBase.NavigationService.Navigate(nextPageOld)
        End If
    End Sub

    Public Sub taskPage_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of TaskResult))
        Me.OnReturn(e)
    End Sub

End Class