Imports System
Imports System.Windows.Navigation

Public Class TaskLauncher
    Inherits PageFunction(Of TaskContext)

    Public Sub New()
        Me.taskData = New TaskData
    End Sub

    Protected Overrides Sub Start()
        MyBase.Start()
        MyBase.KeepAlive = True
        Dim page1 As New TaskPage1(Me.taskData)
        AddHandler page1.Return, New ReturnEventHandler(Of TaskResult)(AddressOf Me.taskPage_Return)
        MyBase.NavigationService.Navigate(page1)
    End Sub

    Public Sub taskPage_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of TaskResult))
        Me.OnReturn(New ReturnEventArgs(Of TaskContext)(New TaskContext(e.Result, Me.taskData)))
    End Sub

    Private taskData As TaskData

End Class


