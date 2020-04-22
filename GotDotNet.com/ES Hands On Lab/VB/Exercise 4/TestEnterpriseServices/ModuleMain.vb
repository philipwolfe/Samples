Imports HelloEnterpriseServices
Imports System

Module ModuleMain
    Const MAX_CACHE_GET As Integer = 100
    Sub ShowTransaction()
        Try
            Dim MyTxObj As New HelloTx()
            MyTxObj.SayHello("<Your Name>")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub DoRandomOutcomeTx()
        Dim MyTxObj As New HelloTx()
        Dim x As Integer
        For x = 1 To 50
            Try
                MyTxObj.RandomOutcome()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Next
    End Sub

    Sub PauseForExit()
        Console.WriteLine("Press <Enter> to exit...")
        Console.Read()
    End Sub

    Sub GetStuffFromCache()
        Dim start As DateTime
        start = DateTime.Now
        Dim r As New Random(DateTime.Now.Millisecond)
        Dim i As Integer
        For i = 1 To MAX_CACHE_GET
            Console.WriteLine("{0} of {1} - {2}", i, MAX_CACHE_GET, GetRandomCacheValue(r))
        Next
        Console.WriteLine("Duration: {0} ", DateTime.Now.Subtract(start))
    End Sub

    '
    ' TODO: Add the GetRandomCacheValue function
    '

    Sub Main()
        ShowTransaction()
        DoRandomOutcomeTx()
        '
        ' TODO: call GetStuffFromCache
        '
        PauseForExit()
    End Sub

End Module
