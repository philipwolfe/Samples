Imports System
Imports System.Diagnostics

Namespace LogWrite

    Module LogWrite

        Public Sub Main()

            Dim args As String()
            Dim appName As String
            args = Environment.GetCommandLineArgs()
            appName = args(0)

            If (args.Length <> 4) Then
                Console.WriteLine("Usage: " + appName + " <log> <message> <source>")
                Exit Sub
            End If

            Dim log As String
            Dim source As String

            log = args(1)
            source = args(3)

            If (Not EventLog.SourceExists(source)) Then
                EventLog.CreateEventSource(source, log)
            End If

            Dim aLog As EventLog
            aLog = New EventLog
            aLog.Source = source

            If (aLog.Log.ToUpper() <> log.ToUpper()) Then
                Console.WriteLine("Some other application is using the source!")
                Exit Sub
            End If

            aLog.WriteEntry(args(2), EventLogEntryType.Information)
            Console.WriteLine("Entry written successfuly!")
        End Sub

    End Module

End Namespace
