Partial Public Class App
    Inherits System.Windows.Application

    Private Sub App_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
        MyBase.Properties.Item("Blue") = DirectCast(Application.LoadComponent(New Uri("BlueTheme.xaml", UriKind.Relative)), ResourceDictionary)
        MyBase.Properties.Item("Yellow") = DirectCast(Application.LoadComponent(New Uri("YellowTheme.xaml", UriKind.Relative)), ResourceDictionary)
    End Sub

End Class
