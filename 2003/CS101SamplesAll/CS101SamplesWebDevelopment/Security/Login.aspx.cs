using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString["access"] != null)
		{
			MessageLabel.Text = "You are not authorized to view the page you tried to access.";
		}
	}

	protected void LoginButton_Click(object sender, EventArgs e)
    {
        string user = UserNameTextbox.Text;
        string pswd = PasswordTextbox.Text;

        // Here's the call to validate the user's credentials and redirect to the appropriate
        // page if valid.
        if (Membership.ValidateUser(user, pswd))
        {
            // For this sample, always set the persist flag to false.
			if (Request.QueryString["returnurl"] != null)
			{
				FormsAuthentication.RedirectFromLoginPage(user, false);
			}
			else
			{
				FormsAuthentication.SetAuthCookie(user, false);

				if (User.IsInRole("Administrator"))
				{
					Response.Redirect("~/admin/admin.aspx");
				}
				else
				{
					Response.Redirect("~/home.aspx");
				}
			}
        }
        else
        {
            MessageLabel.Text = "Invalid login. Please try again.";
        }
    }
}
