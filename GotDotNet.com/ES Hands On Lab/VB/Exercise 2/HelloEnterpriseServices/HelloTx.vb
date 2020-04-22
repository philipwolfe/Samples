Imports System.Windows.Forms
'
' TODO: Add import and reference for EnterpriseServices
'


' 
' TODO: Add Transaction attribute to the HelloTx class
' TODO: HelloTx class must inherit from ServicedComponent
'
Public Class HelloTx

    Public Sub SayHello(ByVal Name As String)
        '
        ' TODO: Get the transaction ID from the ContextUtil object
        '

        '
        ' TODO: Ask the user if they want to commit the transaction
        '
        MessageBox.Show(String.Format("Hello {0}", Name))

        '
        ' TODO: If the user said Yes, commit, otherwise abort
        '
    End Sub

End Class
