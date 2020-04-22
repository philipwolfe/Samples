Imports HelloEnterpriseServices
Imports System.Diagnostics
Imports System

Module ModuleMain
    Sub ShowTransaction()
        Try
            Dim MyTxObj As New HelloTx()
            MyTxObj.SayHello("<Your Name>")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub PauseForExit()
        Console.WriteLine("Press <Enter> to exit...")
        Console.Read()
    End Sub

    Sub Main()
        ShowTransaction()
        PauseForExit()
    End Sub

End Module
