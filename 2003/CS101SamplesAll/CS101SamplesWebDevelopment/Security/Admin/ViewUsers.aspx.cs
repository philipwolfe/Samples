using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ViewUsers_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		// ALTERNATE WAY:
		// The GetAllUsers method returns an object of type MembershipUserCollection. This
		// collection can then be used as a datasource for other controls to bind to, such
		// as the GridView control. The GetAllUsers method is overloaded and also exposes
		// a version to do paging.
		// MembershipUserCollection coll = Membership.GetAllUsers();
		// GridView1.DataSource = coll;
		// GridView1.DataBind();
	}
}
