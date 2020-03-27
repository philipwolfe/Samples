using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Start_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		//TODO: Replace the path with ConfigurationSettings.ConnectionStrings["AppConnectionString1"].ConnectionString
		//when this will work again. Currently causes compilation error.
		if (!File.Exists(@"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf"))
		{
			Response.Redirect("ConfigurationError.htm", true);
		}
	}
}
