using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DeleteUser_aspx : System.Web.UI.Page
{
    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        string user = UserNameTextbox.Text;

        // First let's make sure the user exists by trying to retrieve it from the database
        MembershipUser userObj = Membership.GetUser(user);
        if (userObj == null)
        {
            MessageLabel.Text = "User does not exist.";
            return;
        }

        // Get all the roles for the user. The GetRolesForUser method returns an array of
        // strings, so we'll need to loop through that array and remove the user from each role.
        string[] roles = Roles.GetRolesForUser(user);
        for (int i = 0; i < roles.Length; i++)
        {
            Roles.RemoveUserFromRole(user, roles[i]);
        }

        // Now let's delete the user from the database (and all related data)
        bool result = Membership.DeleteUser(user, true);
        if (result == true)
        {
			MessageLabel.Text = "User has been deleted. <a href=viewusers.aspx>Click here</a> to view all users.";
        }
        else
        {
            MessageLabel.Text = "Unable to delete user.";
        }
    }
}
