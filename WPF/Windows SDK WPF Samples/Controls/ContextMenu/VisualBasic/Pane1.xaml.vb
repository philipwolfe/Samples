Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media


Namespace ContextMenusVB

    '@ <summary>
    '@ Interaction logic for Pane1_xaml.xaml
    '@ </summary>
    Partial Class Pane1
        Sub OnOpened(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cmButton.Content = "The ContextMenu Opened"
        End Sub

        Sub OnClosed(ByVal sender As Object, ByVal args As RoutedEventArgs)
            cmButton.Content = "The ContextMenu Closed" 
        End Sub

        Sub OnClick(ByVal sender As Object, ByVal args As RoutedEventArgs)
           Dim btn As New Button()
           Dim contextmenu As New ContextMenu()
           Dim mi As New MenuItem()
           Dim mia As New MenuItem()

           btn.Background = Brushes.Red
           btn.Height = 30
           btn.Content = "Created with Visual Basic."
 
           mi.Header = ("Item 1")
           contextmenu.Items.Add(mi)
           mia.Header = ("Item 2")
           contextmenu.Items.Add(mia)

           btn.ContextMenu = (contextmenu)
           cv2.Children.Add(btn)

        End Sub
    End Class

End Namespace