Imports System
Imports System.Environment
Imports System.Diagnostics

Namespace LogInfo

    Module LogInfo

        Public Sub Main()

            Dim appName As String
            Dim args As String()

            args = Environment.GetCommandLineArgs()
            appName = args(0)

            If (args.Length <> 2 And args.Length <> 3) Then
                Console.WriteLine("Usage: " + appName + " <log> [<machine>]")
                Exit Sub
            End If

            Dim log As String
            log = args(1)

            Dim machine As String
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
		
            Console.WriteLine("There are " + CStr(aLog.Entries.Count) + " entr[y|ies] in the log:")
            Dim entry As EventLogEntry

            For Each entry In alog.entries
                Console.WriteLine("    Entry: " + entry.Message)
            Next entry

        End Sub

    End Module

End Namespace
