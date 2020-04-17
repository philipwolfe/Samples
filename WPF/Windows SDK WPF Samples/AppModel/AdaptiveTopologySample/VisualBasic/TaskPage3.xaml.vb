Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Markup
Imports System.Windows.Navigation

Namespace AdaptiveTopologySample
    Public Class TaskPage3
        Inherits PageFunction(Of TaskResult)

        Public Sub New(ByVal taskData As Object)
            Me.InitializeComponent()

            ' Bind task state to UI
            MyBase.DataContext = taskData

            AddHandler MyBase.Loaded, New RoutedEventHandler(AddressOf Me.taskPage_Loaded)
        End Sub

        Private Sub backButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Go to previous task page
            MyBase.NavigationService.GoBack()
        End Sub

        Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Cancel the task and don't return any data
            Me.OnReturn(New ReturnEventArgs(Of TaskResult)(TaskResult.Canceled))
        End Sub

        Private Sub finishButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Finish the task and return bound data to calling page
            Me.OnReturn(New ReturnEventArgs(Of TaskResult)(TaskResult.Finished))
        End Sub

        Private Sub nextButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Go to next task page
            If MyBase.NavigationService.CanGoForward Then
                MyBase.NavigationService.GoForward()
            Else
                Dim nextPage As PageFunction(Of TaskResult) = TaskNavigationHub.Current.GetNextTaskPage(Me)
                AddHandler nextPage.Return, New ReturnEventHandler(Of TaskResult)(AddressOf Me.taskPage_Return)
                MyBase.NavigationService.Navigate(nextPage)
            End If
        End Sub

        Public Sub taskPage_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of TaskResult))
            ' This is called when the next page returns, so return what they are returning
            Me.OnReturn(e)
        End Sub

        Private Sub taskPage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

            ' Enable buttons based on position
            Me.backButton.IsEnabled = TaskNavigationHub.Current.CanGoBack(Me)
            Me.nextButton.IsEnabled = TaskNavigationHub.Current.CanGoNext(Me)
            Me.nextButton.IsDefault = TaskNavigationHub.Current.CanGoNext(Me)
            Me.finishButton.IsEnabled = TaskNavigationHub.Current.CanFinish(Me)
            Me.finishButton.IsDefault = TaskNavigationHub.Current.CanFinish(Me)
        End Sub

    End Class
End Namespace
