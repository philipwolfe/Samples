using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CreateUser_aspx : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
		if (!IsPostBack)
		{
			// The method GetAllRoles returns an array of strings, so let's get that and
			// bind the dropdownlist to the array
			string[] roles = Roles.GetAllRoles();

			if (roles.Length == 0)
			{
				NewUserPanel.Enabled = false;
				MessageLabel.Text = "There are no roles in the application database. You must <a href=createrole.aspx>create at least one role</a> before adding a user.";
			}
			else
			{
				RolesDropDownList.DataSource = roles;
				RolesDropDownList.DataBind();
			}
		}
    }

	protected void CreateUserButton_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            // First get all the values
            string user = UserNameTextbox.Text;
            string pswd = PasswordTextbox.Text;
            string email = EmailTextbox.Text;
            string question = SecurityQuestionTextbox.Text;
            string answer = SecurityAnswerTextbox.Text;

            string role = RolesDropDownList.SelectedValue;

            // Create the user. The CreateUser method is overloaded and takes in all the data we
            // collected on the form. Two things to note: the method returns a MembershipUser
            // object and passes out a MembershipCreateStatus enumeration. If the MembershipUser
            // object is null when the method returns, check the MembershipCreateStatus enumeration
            // for the reason.
            MembershipCreateStatus status;
            MembershipUser userObj = Membership.CreateUser(user, pswd, email,
                question, answer, true, out status);

            if (userObj != null)
            {
                // Now add the user to the role and display message
                Roles.AddUserToRole(userObj.UserName, role);
                MessageLabel.Text = "The user was successfully created. <a href=viewusers.aspx>Click here</a> to view all users.";

				UserNameTextbox.Text = "";
				PasswordTextbox.Text = "";
				EmailTextbox.Text = "";
				SecurityQuestionTextbox.Text = "";
				SecurityAnswerTextbox.Text = "";
			}
            else
            {
                // These are just three values to check for in the status
                // enumeration; there are others.
                switch (status)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        MessageLabel.Text = "Could not create user: duplicate email.";
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        MessageLabel.Text = "Could not create user: duplicate user name.";
                        break;
                    case MembershipCreateStatus.ProviderError:
                        MessageLabel.Text = "Could not create user: provider error.";
                        break;
					case MembershipCreateStatus.InvalidPassword:
						MessageLabel.Text = "The password is not strong enough. You need to enter at least 7 characters consisting of at least 1 letter, 1 number and 1 symbold (e.g., @ or #).";
						break;
					default:
						MessageLabel.Text = "The user was not created. The unhandled MembershipCreateStatus enum value is " + status.ToString() + ".";
						break;
				}
            }
        }
    }
}
