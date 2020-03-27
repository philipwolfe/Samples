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

public partial class GridViewPagingSorting_aspx : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        if (Page.IsPostBack)
        {
            EmployeesGridView.Visible = true;
            EmployeesGridView.AllowSorting = EnableSortCheckbox.Checked;
            EmployeesGridView.PageSize = Convert.ToInt32(NumPerPageTextBox.Text);
        }
    }
}
