using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class MasterDetails_aspx : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        if (Page.IsPostBack)
        {
            EmployeesGridView.Visible = true;
            AddressDetailsView.Visible = true;
        }
    }
}