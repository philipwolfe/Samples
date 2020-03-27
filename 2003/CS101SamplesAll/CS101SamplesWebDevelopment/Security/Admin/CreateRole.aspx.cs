using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CreateRole_aspx : System.Web.UI.Page
{
    protected void CreateButton_Click(object sender, EventArgs e)
    {
		try
		{
			Roles.CreateRole(RoleTextbox.Text);
			MessageLabel.Text = "Role successfully created.";
			RoleTextbox.Text = "";
		}
		catch (System.Configuration.Provider.ProviderException exc)
		{
			MessageLabel.Text = "This Role already exists in the database.";
		}
    }
}
