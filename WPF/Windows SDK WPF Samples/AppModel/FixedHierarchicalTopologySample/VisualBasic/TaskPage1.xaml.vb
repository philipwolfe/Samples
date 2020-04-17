Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Markup
Imports System.Windows.Navigation

Public Class TaskPage1
    Inherits PageFunction(Of TaskResult)

    Public Sub New(ByVal taskData As TaskData)
        Me.InitializeComponent()
        MyBase.DataContext = taskData
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.OnReturn(New ReturnEventArgs(Of TaskResult)(TaskResult.Canceled))
    End Sub

    Private Sub nextButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim nextPage As New TaskPage2(DirectCast(MyBase.DataContext, TaskData))
        AddHandler nextPage.Return, New ReturnEventHandler(Of TaskResult)(AddressOf Me.taskPage_Return)
        MyBase.NavigationService.Navigate(nextPage)
    End Sub

    Public Sub taskPage_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of TaskResult))
        Me.OnReturn(e)
    End Sub

End Class