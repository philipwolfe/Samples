'This is a list of commonly used namespaces for a pane.
Imports System
Imports System.Windows
Imports System.Windows.Controls

'@ <summary>
'@ Interaction logic for Page1.xaml
'@ </summary>



Partial Public Class Page1
    Inherits Canvas

    Sub OnClick(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (contCtrl.HasContent = True) Then
            contCtrl.Content = "Has content"
        End If

    End Sub
End Class

