using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CacheDependency_aspx : System.Web.UI.Page
{
    // Page events are wired up automatically to methods 
    // with the following names:
    // Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    // Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    // Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    // Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    // Page_SaveStateComplete, Page_Unload

	protected void Page_Load(object sender, EventArgs e)
	{
		CurrentTimeLiteral.Text = System.DateTime.Now.ToString();

		if (Cache["LastRetrieval"] != null)
		{
			RetrievalTimeLiteral.Text = Cache["LastRetrieval"].ToString();
		}
	}

	protected void DepartmentSqlDataSource_Selected(object sender, SqlDataSourceStatusEventArgs e)
	{
		RetrievalTimeLiteral.Text = System.DateTime.Now.ToString();
		Cache["LastRetrieval"] = System.DateTime.Now.ToString();
	}
}
