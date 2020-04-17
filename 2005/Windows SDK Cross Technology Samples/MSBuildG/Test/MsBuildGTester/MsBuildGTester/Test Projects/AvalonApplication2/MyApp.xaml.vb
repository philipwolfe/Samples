' Interaction logic for MyApp.xaml
Partial Public Class MyApp
    Inherits Application
    Sub AppStartingUp(ByVal sender As Object, ByVal e As StartingUpCancelEventArgs) Handles Me.StartingUp
        Dim mainWindow As Window1 = New Window1
        mainWindow.Show()
    End Sub

End Class
