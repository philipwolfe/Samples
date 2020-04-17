Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data

Namespace CheckBox_vb

    '@ <summary>
    '@ Interaction logic for Pane1_xaml.xaml
    '@ </summary>
    Partial Class Pane1
        Sub HandleChange(ByVal sender As Object, ByVal e As RoutedEventArgs)
            cb1.Content = "You clicked the check box."
        End Sub

        Sub HandleChange1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            txt.FontSize = 16
            txt.Text = "I took this photo yesterday."
        End Sub

        Sub HandleChange2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            txt3.FontSize = 16
            txt3.Text = "My favorite photo."
        End Sub

    End Class

End Namespace