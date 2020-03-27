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

public partial class CallCenterRepUserControl_ascx : System.Web.UI.UserControl
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
    }

	[Personalizable]
	public string Name
	{
		get
		{
			return NameTextbox.Text;
		}
		set
		{
			NameTextbox.Text = value;
		}
	}

	[Personalizable]
	public string EmployeeId
	{
		get
		{
			return EmployeeIdTextbox.Text;
		}
		set
		{
			EmployeeIdTextbox.Text = value;
		}
	}

	[Personalizable]
	public string Extension
	{
		get
		{
			return ExtensionTextbox.Text;
		}
		set
		{
			ExtensionTextbox.Text = value;
		}
	}

	[Personalizable]
	public string DepartmentNumber
	{
		get
		{
			return DepartmentNumberTextbox.Text;
		}
		set
		{
			DepartmentNumberTextbox.Text = value;
		}
	}
}
