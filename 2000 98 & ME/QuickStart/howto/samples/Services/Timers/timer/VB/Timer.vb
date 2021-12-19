Imports System
Imports System.Threading
Imports System.Timers
	
Namespace Timer

    Module Timer

        Public Sub Main()
            Dim aTimer As System.Timers.Timer
            aTimer = New System.Timers.Timer
	
            AddHandler aTimer.Tick, AddressOf OnTimer

            aTimer.Interval = 1000
            aTimer.Enabled = True
		
            Console.WriteLine("Press 'q' to quit the sample")
            While (Console.Read() <> 113)
            End While
        End Sub

        Public Sub OnTimer(ByVal source As Object, ByVal e As EventArgs)
            Console.WriteLine("Hello World!")
        End Sub

    End Module

End Namespace
