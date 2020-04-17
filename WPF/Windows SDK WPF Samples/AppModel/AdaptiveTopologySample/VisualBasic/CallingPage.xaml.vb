Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Markup
Imports System.Windows.Navigation

Namespace AdaptiveTopologySample
    Public Class CallingPage
        Inherits Page

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        ' Determine how the task completed and, if accepted, process the collected task state
        Public Sub navigationHub_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of TaskContext))
            ' Get task state
            Dim taskContext As TaskContext = e.Result

            Me.taskResultsTextBlock.Visibility = Windows.Visibility.Visible

            ' How did the task end?
            Me.taskResultsTextBlock.Text = taskContext.Result.ToString

            ' If the task completed by being accpeted, display task data
            If (taskContext.Result = TaskResult.Finished) Then
                Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & "Data Item 1: " & DirectCast(taskContext.Data, TaskData).DataItem1)
                Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & "Data Item 2: " & DirectCast(taskContext.Data, TaskData).DataItem2)
                Me.taskResultsTextBlock.Text = (Me.taskResultsTextBlock.Text & ChrW(10) & "Data Item 3: " & DirectCast(taskContext.Data, TaskData).DataItem3)
            End If

        End Sub

        Private Sub startTaskHyperlink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            ' Launch the task
            Dim taskNavigationHub As New TaskNavigationHub
            AddHandler taskNavigationHub.Return, New ReturnEventHandler(Of TaskContext)(AddressOf Me.navigationHub_Return)
            MyBase.NavigationService.Navigate(taskNavigationHub)

        End Sub

    End Class
End Namespace


