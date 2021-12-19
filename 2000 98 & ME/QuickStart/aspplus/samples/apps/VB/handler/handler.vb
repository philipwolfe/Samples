
Imports System.Web

Namespace Acme

    Public Class SimpleHandlerVB : Implements IHttpHandler
    
        Public Sub ProcessRequest(Context As HttpContext) Implements IHttpHandler.ProcessRequest
            Context.Response.Write("Hello World!")
        End Sub

        Public Function IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Return true
        End Function

    End Class

End Namespace
