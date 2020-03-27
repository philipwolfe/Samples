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

public partial class MigratingProperties_aspx : System.Web.UI.Page
{
    // Page events are wired up automatically to methods 
    // with the following names:
    // Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    // Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    // Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    // Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    // Page_SaveStateComplete, Page_Unload

	public string Street;
	public string City;
	public string State;
	public string ZipCode;
     
    protected void Page_Load(object sender, EventArgs e)
    {
		
    }

	protected void Page_PreRender(object sender, EventArgs e)
	{
		if (!Profile.IsAnonymous)
		{
			ArrayList buddies = Profile.BuddyList;
			ProfilePanel.Visible = true;
			AnonUserMsg.Visible = false;

			if (buddies != null)
			{
				if (buddies.Count > 0)
				{
					BuddyDropDownList.DataSource = buddies;
					BuddyDropDownList.DataBind();

					BuddyDropDownList.Visible = true;
					NoBuddiesMsg.Visible = false;
				}
				else
				{
					BuddyDropDownList.Visible = false;
					NoBuddiesMsg.Visible = true;
				}
			}
			else
			{
				BuddyDropDownList.Visible = false;
				NoBuddiesMsg.Visible = true;
			}

			if (Profile.Address != null)
			{
				Street = Profile.Address.Street;
				City = Profile.Address.City;
				State = Profile.Address.State;
				ZipCode = Profile.Address.ZipCode;
			}
		}
		else
		{
			ProfilePanel.Visible = false;
			AnonUserMsg.Visible = true;
		}
	}
}
