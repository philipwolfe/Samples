Imports System.Windows.Forms

Public Class HelloTx

    Public Sub SayHello(ByVal Name As String)
        MessageBox.Show(String.Format("Hello {0}", Name))
    End Sub

End Class
