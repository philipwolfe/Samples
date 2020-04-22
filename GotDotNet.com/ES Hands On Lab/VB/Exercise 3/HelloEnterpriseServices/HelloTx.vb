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

    '
    ' TODO: Add RandomOutcome function
    '
End Class
