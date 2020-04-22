Imports HelloEnterpriseServices
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

    Private Function RandomCommit(ByRef Message As String)
        Dim Commit As Boolean
        Dim r As New Random(DateTime.Now.Millisecond)
        ' Commit if an even number is returned from the random generator
        Commit = ((r.Next() Mod 2) = 0)
        Message = String.Format("RandomOutcome Result: {0} Transaction ID: {1}", IIf(Commit, "commit", "abort"), ContextUtil.TransactionId)
        Return Commit
    End Function

    '
    ' TODO: Add Sub DoRandomOutcomeTx
    '

    Sub Main()
        ShowTransaction()
        '
        ' TODO: Add call to DoRandomOutcomeTx
        '
        PauseForExit()
    End Sub

End Module
