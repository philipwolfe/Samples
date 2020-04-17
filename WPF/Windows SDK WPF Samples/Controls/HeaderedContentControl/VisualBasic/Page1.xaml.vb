'This is a list of commonly used namespaces for a pane.
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Collections.ObjectModel


	'@ <summary>
	'@ Interaction logic for Page1.xaml
	'@ </summary>
        
        

Partial Public Class Page1
    Inherits Canvas


    Sub OnClick(ByVal Sender As Object, ByVal e As RoutedEventArgs)

        If (hcontCtrl.HasHeader = True) Then

            hcontCtrl.Header = "Has header"
            hcontCtrl.Content = " "
        End If
    End Sub
End Class
      
   
