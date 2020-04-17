Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Markup
Imports System.Windows.Navigation

Namespace AdaptiveTopologySample
    Public Class DataEntryPage
        Inherits PageFunction(Of TaskContext)

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Cancel the task and don't return any data
            Me.OnReturn(New ReturnEventArgs(Of TaskContext)(New TaskContext(TaskResult.Canceled, Nothing)))
        End Sub

        Private Sub okButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Go to next task - as determined by the navigation hub
            Dim direction1 As TaskNavigationDirection = IIf(Me.forwardsRadioButton.IsChecked.Value, TaskNavigationDirection.Forwards, TaskNavigationDirection.Reverse)
            Me.OnReturn(New ReturnEventArgs(Of TaskContext)(New TaskContext(TaskResult.Finished, direction1)))
        End Sub

    End Class
End Namespace