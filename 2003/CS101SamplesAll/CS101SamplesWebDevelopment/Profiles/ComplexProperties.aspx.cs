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
using Samples.Web.Profiles;

public partial class ComplexProperties_aspx : System.Web.UI.Page
{
    // Page events are wired up automatically to methods 
    // with the following names:
    // Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    // Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    // Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    // Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    // Page_SaveStateComplete, Page_Unload
     
	protected void Page_PreRender(object sender, EventArgs e)
	{
		UpdateBuddyList();
		DisplayAddress();
	}

	private void DisplayAddress()
	{
		if (Profile.Address != null)
		{
			StreetTextBox.Text = Profile.Address.Street;
			CityTextBox.Text = Profile.Address.City;
			StateTextBox.Text = Profile.Address.State;
			ZipCodeTextBox.Text = Profile.Address.ZipCode;
		}
	}

	private void UpdateBuddyList()
	{
		ArrayList buddies = Profile.BuddyList;

		if (buddies != null)
		{
			if (buddies.Count > 0)
			{
				BuddyDropDownList.DataSource = buddies;
				BuddyDropDownList.DataBind();

				BuddyDropDownList.Visible = true;
				DeleteButton.Visible = true;
				NoBuddiesMsg.Visible = false;
			}
			else
			{
				BuddyDropDownList.Visible = false;
				DeleteButton.Visible = false;
				NoBuddiesMsg.Visible = true;
			}
		}
		else
		{
			BuddyDropDownList.Visible = false;
			DeleteButton.Visible = false;
			NoBuddiesMsg.Visible = true;
		}
	}

	protected void AddButton_Click(object sender, EventArgs e)
	{
		if (BuddyNameTextBox.Text != string.Empty)
		{
			if (Profile.BuddyList == null)
			{
				Profile.BuddyList = new ArrayList();
			}
			Profile.BuddyList.Add(BuddyNameTextBox.Text);
			UpdateBuddyList();
			BuddyNameTextBox.Text = "";
		}
	}

	protected void DeleteButton_Click(object sender, EventArgs e)
	{
		Profile.BuddyList.RemoveAt(BuddyDropDownList.SelectedIndex);
		UpdateBuddyList();
	}

	protected void SaveButton_Click(object sender, EventArgs e)
	{
		if (Profile.Address == null)
		{
			// Create a new Address object
			Address addr = new Address();
			addr.Street = StreetTextBox.Text;
			addr.City = CityTextBox.Text;
			addr.State = StateTextBox.Text;
			addr.ZipCode = ZipCodeTextBox.Text;

			// Add it to the profile
			Profile.Address = addr;
			Profile.Save();
		}
		else
		{
			// Update the one we already have
			Profile.Address.Street = StreetTextBox.Text;
			Profile.Address.City = CityTextBox.Text;
			Profile.Address.State = StateTextBox.Text;
			Profile.Address.ZipCode = ZipCodeTextBox.Text;
		}
	}
}
