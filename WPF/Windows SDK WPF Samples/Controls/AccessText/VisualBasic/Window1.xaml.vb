' Interaction logic for Window1.xaml
Partial Public Class Window1
    Inherits System.Windows.Controls.StackPanel

    Public Sub New()
        InitializeComponent()
    End Sub

    Sub edit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("Edit button")
    End Sub
    Sub cut_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("Cut button")
    End Sub
    Sub hello_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        MessageBox.Show("Hello button")
    End Sub

End Class
