Imports System.Windows.Forms
Imports System.EnterpriseServices

<Transaction(TransactionOption.Required)> _
Public Class HelloTx
    Inherits ServicedComponent

    Public Sub SayHello(ByVal Name As String)
        Dim txId As Guid
        txId = ContextUtil.TransactionId
        Select Case MessageBox.Show(String.Format( _
                    "Hello {0} - Should I commit transaction {1}?", Name, txId), _
                    "Transaction", MessageBoxButtons.YesNo)
            Case DialogResult.Yes
                ContextUtil.SetComplete()
            Case DialogResult.No
                ContextUtil.SetAbort()
        End Select
    End Sub

    Private Function RandomCommit(ByRef Message As String)
        Dim Commit As Boolean
        Dim r As New Random(DateTime.Now.Millisecond)
        ' Commit if an even number is returned from the random generator
        Commit = ((r.Next() Mod 2) = 0)
        Message = String.Format("RandomOutcome Result: {0} Transaction ID: {1}", IIf(Commit, "commit", "abort"), ContextUtil.TransactionId)
        Return Commit
    End Function

    <AutoComplete()> _
    Public Sub RandomOutcome()
        Dim Message As String
        If Not RandomCommit(Message) Then
            Throw New Exception(Message)
        Else
            Console.WriteLine(Message)
        End If
    End Sub
End Class
