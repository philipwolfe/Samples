Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
    Public Partial Class RoutedEventSource
        Public Sub HandleClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            'You must cast the object as a Button element, or at least as FrameworkElement, to set Width
            Dim srcButton As Button
            srcButton = CType(e.Source, Button)
            srcButton.Width = 200
        End Sub
    End Class
End Namespace