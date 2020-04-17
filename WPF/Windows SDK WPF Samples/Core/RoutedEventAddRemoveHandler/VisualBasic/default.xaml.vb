Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
    Public Partial Class RoutedEventAddRemoveHandler
        Public Sub MakeButton(sender As Object, e As RoutedEventArgs)
            Dim b2 As Button  = New Button()
            b2.Content = "New Button"
            AddHandler b2.Click, AddressOf Onb2Click
            root.Children.Insert(root.Children.Count, b2)
            DockPanel.SetDock(b2, Dock.Top)
            text1.Text = "Now click the second button..."
            b1.IsEnabled = False
        End Sub
        Public Sub Onb2Click(sender As Object, e As RoutedEventArgs)
            text1.Text = "New Button (b2) Was Clicked!!"
        End Sub
    End Class
End Namespace