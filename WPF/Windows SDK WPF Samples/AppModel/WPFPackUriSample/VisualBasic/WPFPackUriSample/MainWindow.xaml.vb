' Interaction logic for MainWindow.xaml
Partial Public Class MainWindow
    Inherits System.Windows.Window

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub click0(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim uri1 As New Uri("/VersionedReferencedAssembly;v1.0.0.0;component/ResourceFile.xaml", UriKind.RelativeOrAbsolute)
        Me.frame.Source = uri1
    End Sub

    Private Sub click1(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim uri1 As New Uri("/VersionedReferencedAssembly;v1.0.0.1;component/ResourceFile.xaml", UriKind.RelativeOrAbsolute)
        Me.frame.Source = uri1
    End Sub

End Class
