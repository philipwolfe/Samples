Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class DeleteRole_aspx
    Inherits System.Web.UI.Page

    Protected Sub DeleteButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Roles.DeleteRole(RoleTextbox.Text, False) Then
            MessageLabel.Text = "Role has been deleted. Note that all users associated with this role have also been deleted. If you want to protect against this, do not set the DeleteRole method's throwOnPopulatedRole property to false."
        Else
            MessageLabel.Text = "Unable to delete role."
        End If
    End Sub 'DeleteButton_Click
End Class 'DeleteRole_aspx