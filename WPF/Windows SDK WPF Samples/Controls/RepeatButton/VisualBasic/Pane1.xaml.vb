Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data

Namespace RepeatButton_vb

    '@ <summary>
    '@ Interaction logic for Pane1_xaml.xaml
    '@ </summary>
    Partial Class Pane1
        Dim Num As Integer
        Sub Increase(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Num = CInt(btn.Content)

            btn.Content = ((Num + 1).ToString())
        End Sub

        Sub Decrease(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Num = CInt(btn.Content)

            btn.Content = ((Num - 1).ToString())
        End Sub

        Sub Increase2(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Num = CInt(btn2.Content)
            If Num >= 50 Then 
                btn2.Content = 50
	    Else
                btn2.Content = ((Num + 1).ToString())
            End If
        End Sub

        Sub Decrease2(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Num = CInt(btn2.Content)
            If Num <= 0 Then 
                 btn2.Content = 0
            Else
                 btn2.Content = ((Num - 1).ToString())
            End If
        End Sub
        
    End Class

End Namespace