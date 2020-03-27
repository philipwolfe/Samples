Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class CreateRole_aspx
    Inherits System.Web.UI.Page

    Protected Sub CreateButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
			Roles.CreateRole(RoleTextbox.Text)
			MessageLabel.Text = "Role successfully created."
			RoleTextbox.Text = ""
        Catch exc As System.Configuration.Provider.ProviderException
            MessageLabel.Text = "This Role already exists in the database."
        End Try
    End Sub 'CreateButton_Click
End Class 'CreateRole_aspx