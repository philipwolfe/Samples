Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class CreateUser_aspx
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        If Not IsPostBack Then
            ' The method GetAllRoles returns an array of strings, so let's get that and
            ' bind the dropdownlist to the array
            Dim roles As String() = System.Web.Security.Roles.GetAllRoles()

            If roles.Length = 0 Then
                NewUserPanel.Enabled = False
                MessageLabel.Text = "There are no roles in the application database. You must <a href=createrole.aspx>create at least one role</a> before adding a user."
            Else
                RolesDropDownList.DataSource = roles
                RolesDropDownList.DataBind()
            End If
        End If
    End Sub 'OnLoad


    Protected Sub CreateUserButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Page.Validate()
        If Page.IsValid Then
            ' First get all the values
            Dim user As String = UserNameTextbox.Text
            Dim pswd As String = PasswordTextbox.Text
            Dim email As String = EmailTextbox.Text
            Dim question As String = SecurityQuestionTextbox.Text
            Dim answer As String = SecurityAnswerTextbox.Text

            ' TODO: Double-check this; doesn't seem to be picking up the right value
            Dim role As String = RolesDropDownList.SelectedValue

            ' Create the user. The CreateUser method is overloaded and takes in all the data we
            ' collected on the form. Two things to note: the method returns a MembershipUser
            ' object and passes out a MembershipCreateStatus enumeration. If the MembershipUser
            ' object is null when the method returns, check the MembershipCreateStatus enumeration
            ' for the reason.
            Dim status As MembershipCreateStatus
            Dim userObj As MembershipUser = Membership.CreateUser(user, pswd, email, question, answer, True, status)

            If Not (userObj Is Nothing) Then
                ' Now add the user to the role and display message
                Roles.AddUserToRole(userObj.UserName, role)
                MessageLabel.Text = "The user was successfully created. <a href=viewusers.aspx>Click here</a> to view all users."

                UserNameTextbox.Text = ""
                PasswordTextbox.Text = ""
                EmailTextbox.Text = ""
                SecurityQuestionTextbox.Text = ""
                SecurityAnswerTextbox.Text = ""
            Else
                ' These are just three values to check for in the status
                ' enumeration; there are others.
                Select Case status
                    Case MembershipCreateStatus.DuplicateEmail
                        MessageLabel.Text = "Could not create user: duplicate email."
                    Case MembershipCreateStatus.DuplicateUserName
                        MessageLabel.Text = "Could not create user: duplicate user name."
                    Case MembershipCreateStatus.ProviderError
                        MessageLabel.Text = "Could not create user: provider error."
                    Case MembershipCreateStatus.InvalidPassword
                        MessageLabel.Text = "The password is not strong enough. You need to enter at least 7 characters consisting of at least 1 letter, 1 number and 1 symbold (e.g., @ or #)."
                    Case Else
                        MessageLabel.Text = "The user was not created. The unhandled MembershipCreateStatus enum value is " + status.ToString() + "."
                End Select
            End If
        End If
    End Sub 'CreateUserButton_Click
End Class 'CreateUser_aspx