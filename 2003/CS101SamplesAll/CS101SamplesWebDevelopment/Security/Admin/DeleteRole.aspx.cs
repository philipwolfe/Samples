using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DeleteRole_aspx : System.Web.UI.Page
{
    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        if (Roles.DeleteRole(RoleTextbox.Text, false) == true)
        {
            MessageLabel.Text = "Role has been deleted. Note that all users associated with this role have also been deleted. If you want to protect against this, do not set the DeleteRole method's throwOnPopulatedRole property to false.";
        }
        else
        {
            MessageLabel.Text = "Unable to delete role.";
        }
    }
}
