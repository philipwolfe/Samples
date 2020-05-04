Module StartUp

    Private mainForm As Form1

    Public Sub Main()
        Dim aSplash As SplashForm
        aSplash = New SplashForm()

        'Run the splash screen
        'it will call load
        'and close after the load finishes
        aSplash.Startup(AddressOf Load)

        'If the load worked on then
        If Not mainForm Is Nothing Then
            'Show the main form
            Application.Run(mainForm)
        End If
    End Sub

    'This method loads the applications forms
    'You could also use this to download data from a
    'web service etc...
    Private Sub Load()
        mainForm = New Form1()
        'Pretend to do something else for 5 seconds...
        Threading.Thread.Sleep(5000)
    End Sub

End Module
