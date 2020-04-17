Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Navigation

Namespace AdaptiveTopologySample
    Public Class TaskNavigationHub
        Inherits PageFunction(Of TaskContext)

        Public Sub New()
            Me.navigationOrder = New List(Of PageFunction(Of TaskResult))
            Me.taskData = New TaskData
            taskNavigationHub.taskNavigationHub = Me
        End Sub

        Public Function CanFinish(ByVal currentPageFunction As PageFunction(Of TaskResult)) As Boolean
            Dim index As Integer = Me.navigationOrder.IndexOf(DirectCast(currentPageFunction, PageFunction(Of TaskResult)))
            Return (index = (Me.navigationOrder.Count - 1))
        End Function

        Public Function CanGoBack(ByVal currentPageFunction As PageFunction(Of TaskResult)) As Boolean
            Dim index As Integer = Me.navigationOrder.IndexOf(DirectCast(currentPageFunction, PageFunction(Of TaskResult)))
            Return (index > 0)
        End Function

        Public Function CanGoNext(ByVal currentPageFunction As PageFunction(Of TaskResult)) As Boolean
            Dim index As Integer = Me.navigationOrder.IndexOf(DirectCast(currentPageFunction, PageFunction(Of TaskResult)))
            Return (index < (Me.navigationOrder.Count - 1))
        End Function

        Private Sub dataEntryPage_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of TaskContext))

            Dim taskContext As TaskContext = e.Result

            ' Cancel task if data entry page was canceled
            If (taskContext.Result = TaskResult.Canceled) Then
                Me.OnReturn(New ReturnEventArgs(Of TaskContext)(New TaskContext(TaskResult.Canceled, Nothing)))
                Return
            End If

            ' Organize navigation direction
            If (DirectCast(taskContext.Data, TaskNavigationDirection) = TaskNavigationDirection.Forwards) Then
                Me.navigationOrder.Add(DirectCast(New TaskPage1(Me.taskData), PageFunction(Of TaskResult)))
                Me.navigationOrder.Add(DirectCast(New TaskPage2(Me.taskData), PageFunction(Of TaskResult)))
                Me.navigationOrder.Add(DirectCast(New TaskPage3(Me.taskData), PageFunction(Of TaskResult)))
            Else
                Me.navigationOrder.Add(DirectCast(New TaskPage3(Me.taskData), PageFunction(Of TaskResult)))
                Me.navigationOrder.Add(DirectCast(New TaskPage2(Me.taskData), PageFunction(Of TaskResult)))
                Me.navigationOrder.Add(DirectCast(New TaskPage1(Me.taskData), PageFunction(Of TaskResult)))
            End If

            ' Navigate to first page
            AddHandler Me.navigationOrder.Item(0).Return, New ReturnEventHandler(Of TaskResult)(AddressOf Me.NavigationHub_Return)
            DirectCast(Application.Current.MainWindow, NavigationWindow).Navigate(Me.navigationOrder.Item(0))

        End Sub

        Public Function GetNextTaskPage(ByVal currentPageFunction As PageFunction(Of TaskResult)) As PageFunction(Of TaskResult)
            Dim index As Integer = Me.navigationOrder.IndexOf(DirectCast(currentPageFunction, PageFunction(Of TaskResult)))
            Return Me.navigationOrder.Item((index + 1))
        End Function

        Private Sub NavigationHub_Return(ByVal sender As Object, ByVal e As ReturnEventArgs(Of TaskResult))
            ' If returning, task was completed (finished or canceled),
            ' so continue returning to calling page
            Me.OnReturn(New ReturnEventArgs(Of TaskContext)(New TaskContext(e.Result, Me.taskData)))
        End Sub

        Protected Overrides Sub Start()
            ' Keep this page function instance in navigation history until completion
            JournalEntry.SetKeepAlive(Me, True)
            MyBase.RemoveFromJournal = True

            ' Navigate to data entry page to determine navigation sequence
            Dim dataEntryPage As New DataEntryPage
            AddHandler dataEntryPage.Return, New ReturnEventHandler(Of TaskContext)(AddressOf Me.dataEntryPage_Return)
            MyBase.NavigationService.Navigate(dataEntryPage)

        End Sub

        Public Shared ReadOnly Property Current() As TaskNavigationHub
            Get
                Return taskNavigationHub.taskNavigationHub
            End Get
        End Property

        Private navigationOrder As List(Of PageFunction(Of TaskResult))
        Private taskData As TaskData
        Private Shared taskNavigationHub As TaskNavigationHub

    End Class
End Namespace


