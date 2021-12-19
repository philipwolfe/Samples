Imports System.Windows.Forms

Public Class MyAccount
    Private Balance As Single

    ' Constructor to automatically set Balance
    Public Sub New()
        Balance = 5
    End Sub

    ' Withdraw will check to see if funds are available, if so then it will reduce
    '  balance by Amount, otherwise it will throw an InsufficientFundsException
    Public Sub WithDraw(ByVal Amount As Single)

        Try
            'Check to see if funds are available
            If Amount > Balance Then
                ' Throw a new InsufficientFundsException
                Throw New InsufficientFundsException()
            Else
                'Reduce balance
                Balance = Balance - Amount
            End If

        Catch exc As Exception
            'Any necessary tasks can be done before the exception is sent back to the caller
            MessageBox.Show("Exception Caught in MyAccount.WithDraw")

            'Throw the exception back to the caller
            Throw exc

        End Try
    End Sub
End Class
