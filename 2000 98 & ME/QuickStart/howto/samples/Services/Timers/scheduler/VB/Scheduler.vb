Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Timers
Imports System.Timers.Design
Imports System.WinForms

Namespace Scheduler

    Module Scheduler

        Public executablePath As String

        Public Sub Main()
            Dim args As String()
            Dim sampleName As String
            args = Environment.GetCommandLineArgs()
            sampleName = args(0)

            If (args.Length <> 2) Then
                Console.WriteLine("Usage: " + sampleName + " <executable>")
                Exit Sub
            End If

            executablePath = args(1)

            Dim aSchedule As Schedule
            aSchedule = New Schedule

            Dim dlg As RecurrencePatternsDialog
            dlg = New RecurrencePatternsDialog

            dlg.RecurrencePatterns = aSchedule.RecurrencePatterns
            dlg.ShowDialog()

            aSchedule.RecurrencePatterns.All = dlg.RecurrencePatterns.All
            AddHandler aSchedule.EventOccurred, AddressOf OnScheduledEvent
            aSchedule.Enabled = True

            Console.WriteLine("Press 'q' to quit the sample")
            While (Console.Read() <> 113)
            End While
        End Sub

        Public Sub OnScheduledEvent(ByVal source As Object, ByVal e As OccurredEventArgs)
            Process.Start(executablePath)
        End Sub

    End Module

End Namespace
