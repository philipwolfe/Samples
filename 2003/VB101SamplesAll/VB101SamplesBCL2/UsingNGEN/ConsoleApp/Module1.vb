Imports System.Diagnostics
Imports SharedLib1

Module Module1
    Sub Main()
        Dim numbers As Numbers = New Numbers()

        Dim stopWatch As Stopwatch = New Stopwatch()
        stopWatch.Start()

        Dim i As Long
        For i = 0 To 10 - 1 Step i + 1
            Console.WriteLine(String.Format("Start: " & i & " Count: 1000 " & "Step: 2 " & "Mean: " & _
                numbers.CalculateMean(i, 100000000, 2)))
        Next

        stopWatch.Stop()

        Console.WriteLine("Elapsed Time [hh:mm:sec:msec]: {0}", stopWatch.Elapsed.ToString())

        Console.ReadKey(False)
    End Sub
End Module