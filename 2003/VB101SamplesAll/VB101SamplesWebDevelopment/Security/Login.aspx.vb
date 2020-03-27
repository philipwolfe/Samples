Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class Login_aspx
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Request.QueryString("access")) Then
            MessageLabel.Text = "You are not authorized to view the page you tried to access."
        End If
    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim user As String = UserNameTextbox.Text
        Dim pswd As String = PasswordTextbox.Text

        ' Here's the call to validate the user's credentials and redirect to the appropriate
        ' page if valid.
        If Membership.ValidateUser(user, pswd) Then
            ' For this sample, always set the persist flag to false.
            If Not IsNothing(Request.QueryString("returnurl")) Then
                FormsAuthentication.RedirectFromLoginPage(user, False)
            Else
                FormsAuthentication.SetAuthCookie(user, False)

                If Me.User.IsInRole("Administrator") Then
                    Response.Redirect("~/admin/admin.aspx")
                Else
                    Response.Redirect("~/home.aspx")
                End If
            End If
        Else
            MessageLabel.Text = "Invalid login. Please try again."
        End If
    End Sub 'LoginButton_Click
End Class 'Login_aspx