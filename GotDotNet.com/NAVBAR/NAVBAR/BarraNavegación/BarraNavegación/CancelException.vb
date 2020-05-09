'***********************************************************************************************************
' From Spain: November 2002
'
' All code has been developed by:
' Jesús López is MCP SQL Server and Microsoft .NET MVP
' You can contact with Jesús in his web site (SqlRanger - http://www.sqlranger.com/)
'
' With a little contribution of:
' Jorge Serrano is Microsoft .NET MVP
' You can contact with Jorge in his web site (PortalVB.com - http://www.portalvb.com/)
'***********************************************************************************************************

Imports System.Threading
Imports System.Windows.Forms

Public Class CancelException
    Inherits Exception
End Class

Public Class ExceptionHandler
    Friend Sub OnThreadException(ByVal sender As Object, ByVal t As ThreadExceptionEventArgs)
        Static ExitCalled As Boolean
        If ExitCalled Then Return
        If Not TypeOf t.Exception Is CancelException Then
            Try
                Dim Msg As String = "An Error has happened in the application and the program will be closed: " & vbNewLine & vbNewLine
                Msg &= "Error Type: " & t.Exception.GetType.ToString & vbNewLine
                Msg &= "Description: " & t.Exception.Message & vbNewLine & vbNewLine
                Msg &= "Calls: " & vbNewLine & t.Exception.StackTrace
                MessageBox.Show(Msg, "Application Error", MessageBoxButtons.OK, MsgBoxStyle.Critical)
            Finally
                Application.Exit()
                ExitCalled = True
            End Try
        End If
    End Sub
End Class