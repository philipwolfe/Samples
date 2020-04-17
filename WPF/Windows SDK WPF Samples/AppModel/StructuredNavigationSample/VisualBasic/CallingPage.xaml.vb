Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Navigation

Public Class CallingPage
    Inherits Page

    Public Sub New()

        Me.InitializeComponent()

    End Sub

    Private Sub callingPage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

        ' If a task happened, get task result
        If (Application.Current.Properties.Item("TaskResult") Is Nothing) Then Return

        ' Display task result and data
        Dim taskResult As Boolean = CBool(Application.Current.Properties.Item("TaskResult"))
        Me.taskResultsTextBlock.Visibility = Windows.Visibility.Visible

        ' Display task result
        If (taskResult) Then
            Me.taskResultsTextBlock.Text = "Accepted"
            ' Display task data
            Dim taskData As String = CStr(Application.Current.Properties.Item("TaskData"))
            If (taskData Is Nothing) Then Return
            Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & taskData)
        Else
            Me.taskResultsTextBlock.Text = "Canceled"
        End If

        ' Remove result and data
        Application.Current.Properties.Item("TaskResult") = Nothing
        Application.Current.Properties.Item("TaskData") = Nothing

    End Sub

    Private Sub startTaskUNHyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        ' Instantiate and navigate to task page
        Dim taskPage As TaskPage = New TaskPage("Initial Data Item Value")
        Me.NavigationService.Navigate(taskPage)

    End Sub

    Private Sub startTaskSNHyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        ' Instantiate and navigate to task page function
        Dim taskPageFunction As New TaskPageFunction("Initial Data Item Value")
        AddHandler taskPageFunction.Return, New ReturnEventHandler(Of String)(AddressOf Me.taskPageFunction_Return)
        MyBase.NavigationService.Navigate(taskPageFunction)

    End Sub

    Private Sub taskPageFunction_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of String))

        ' Display task result and data
        Me.taskResultsTextBlock.Visibility = Windows.Visibility.Visible

        ' Display task result
        Me.taskResultsTextBlock.Text = IIf((Not e Is Nothing), "Accepted", "Canceled")

        ' If a task happened, display task data
        If (Not e Is Nothing) Then
            Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & e.Result)
        End If

    End Sub

End Class

