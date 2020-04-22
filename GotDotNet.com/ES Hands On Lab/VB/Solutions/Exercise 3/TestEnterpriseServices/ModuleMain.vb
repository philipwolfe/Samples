Imports HelloEnterpriseServices
Imports System.Diagnostics
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

    Sub Main()
        ShowTransaction()
        DoRandomOutcomeTx()
        PauseForExit()
    End Sub

End Module
