Public Class MainWindow
    Inherits Window

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub browserFrame_FragmentNavigation(ByVal sender As Object, ByVal e As FragmentNavigationEventArgs)
        Dim element As FrameworkElement = TryCast(LogicalTreeHelper.FindLogicalNode(DirectCast(DirectCast(e.Navigator, ContentControl).Content, DependencyObject), e.Fragment), FrameworkElement)
        If (Not element Is Nothing) Then
            ' Go to fragment if found
            element.BringIntoView()
        Else
            ' Redirect to error page
            Me.browserFrame.Navigate(New Uri("FragmentNotFoundPage.xaml", UriKind.Relative))
        End If
        e.Handled = True
    End Sub

    Private Sub goButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Navigate to Uri, with or with out fragment
        ' NOTE - Uri with fragment looks like "DocumentPage.xaml#Fragment5"
        Me.browserFrame.Navigate(New Uri(Me.addressTextBox.Text, UriKind.RelativeOrAbsolute))
    End Sub

End Class