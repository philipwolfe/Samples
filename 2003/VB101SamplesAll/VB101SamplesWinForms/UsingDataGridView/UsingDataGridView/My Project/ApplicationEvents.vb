Namespace My

    'The following events are available for MyApplication
    '
    'Startup: Raised when the application starts, before the startup form is created.
    'Shutdown: Raised after all application forms are closed.  This event is not raised if the application is terminating abnormally.
    'UnhandledException: Raised if the application encounters an unhandled exception.
    'StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    'NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Class MyApplication
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            If Not My.Computer.FileSystem.FileExists("C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf") Then
                MessageBox.Show("You do not have the Adventure Works database installed", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
        End Sub

        Public Sub Me_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MessageBox.Show(e.Exception.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.ExitApplication = True
        End Sub

    End Class

End Namespace
