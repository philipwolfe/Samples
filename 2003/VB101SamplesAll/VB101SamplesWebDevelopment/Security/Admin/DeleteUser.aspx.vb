Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class DeleteUser_aspx
    Inherits System.Web.UI.Page

    Protected Sub DeleteButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim user As String = UserNameTextbox.Text

        ' First let's make sure the user exists by trying to retrieve it from the database
        Dim userObj As MembershipUser = Membership.GetUser(user)
        If userObj Is Nothing Then
            MessageLabel.Text = "User does not exist."
            Return
        End If

        ' Get all the roles for the user. The GetRolesForUser method returns an array of
        ' strings, so we'll need to loop through that array and remove the user from each role.
        Dim allroles As String() = Roles.GetRolesForUser(user)
        Dim i As Integer
        For i = 0 To allroles.Length - 1
            Roles.RemoveUserFromRole(user, allroles(i))
        Next i

        ' Now let's delete the user from the database (and all related data)
        Dim result As Boolean = Membership.DeleteUser(user, True)
        If result = True Then
            MessageLabel.Text = "User has been deleted. <a href=viewusers.aspx>Click here</a> to view all users."
        Else
            MessageLabel.Text = "Unable to delete user."
        End If
    End Sub 'DeleteButton_Click
End Class 'DeleteUser_aspx