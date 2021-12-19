' Every Wednesday from 7:00am till 6:00pm prints "Hello World" every 5 seconds

Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Timers

Namespace ScheduleDemo

    Module ScheduleDemo

        Public Sub Main()
            Dim aSchedule As Schedule
            aSchedule = New Schedule
                    
            AddHandler aSchedule.EventOccurred, AddressOf OnScheduledEvent
                        
            Dim days As WeeklyPattern
            days = New WeeklyPattern(DaysOfWeek.Wednesday, 1)
            days.StartTime = New TimeSpan(7, 0, 0)
            days.EndTime = New TimeSpan(18, 0, 0)
            days.Interval = New TimeSpan(0, 0, 5)
	    days.ValidFrom = new DateTime(1900,1,1)
    
            aSchedule.RecurrencePatterns.Add(days)
            
            aSchedule.Enabled = False
            Console.WriteLine("Move the system clock to a Wednesday between 7:00am and 6:00pm and press 'r'") 
            While (Console.Read() <> 114)
            End While
            aSchedule.Enabled = True
				
            Console.WriteLine("Press 'q' to quit the sample")
            While (Console.Read() <> 113)
            End While
        End Sub

        Public Sub OnScheduledEvent(ByVal source As Object, ByVal e As OccurredEventArgs)
            Console.WriteLine("Hello World!")
        End Sub

    End Module

End Namespace
