Imports System
Imports System.Environment
Imports System.Diagnostics
Imports System.Threading

Namespace LogMonitor

    Module LogMonitor

        Public Sub Main()

            Dim args As String()
            Dim appName As String
            args = Environment.GetCommandLineArgs()
            appName = args(0)

            If (args.Length <> 2 And args.Length <> 3) Then
                Console.WriteLine("Usage: " + appName + " <log> [<machine>]")
                Exit Sub
            End If

            Dim log As String
            Dim machine As String
            log = args(1)

            If (args.Length = 3) Then
                machine = args(2)
            Else
                machine = "." ' local machine
            End If

            If (Not EventLog.Exists(log, machine)) Then
                Console.WriteLine("The log does not exist!")
                Exit Sub
            End If

            Dim aLog As EventLog
            aLog = New EventLog
            aLog.Log = log
            aLog.MachineName = machine
		
            AddHandler aLog.EntryWritten, AddressOf OnEntryWritten
            aLog.Monitoring = True
        
            Console.WriteLine("Press 'q' to quit the sample")
            While (Console.Read() <> 113)
                Thread.Sleep(500)
            End While
        End Sub

        Sub OnEntryWritten(ByVal source As Object, ByVal e As EventLogEvent)
            Console.WriteLine("Written: " + e.Entry.Message)
        End Sub

    End Module

End Namespace
