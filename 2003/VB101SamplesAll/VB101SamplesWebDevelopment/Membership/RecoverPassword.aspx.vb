Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class RecoverPassword_aspx
    Inherits System.Web.UI.Page

    Public Sub SendMailError(ByVal sender As Object, ByVal e As SendMailErrorEventArgs)
        Response.Redirect("~/smtperror.htm")
    End Sub
End Class 'RecoverPassword_aspx
