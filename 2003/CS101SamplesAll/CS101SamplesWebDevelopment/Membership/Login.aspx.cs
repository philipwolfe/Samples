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
			MessageLabel.Text = "<b>Anonymous Access Forbidden:</b> You are not allowed to enter the secure members area until you log in.";
		}
	}
}
