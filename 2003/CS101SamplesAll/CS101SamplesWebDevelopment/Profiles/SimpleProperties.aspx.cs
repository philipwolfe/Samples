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

public partial class SimpleProperties_aspx : System.Web.UI.Page
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
		if ((Profile.FirstName != string.Empty) && (Profile.LastName != string.Empty))
		{
			WelcomeMsgLabel.Text = GetWelcomeMessageText(Profile.FirstName, Profile.LastName);
		}
    }

	protected void SetProfileButton_Click(object sender, EventArgs e)
	{
		Page.Validate();
		if (Page.IsValid)
		{
			// Set the FirstName and LastName profile properties
			Profile.FirstName = FirstNameTextBox.Text;
			Profile.LastName = LastNameTextBox.Text;

			// Set the welcome message
			WelcomeMsgLabel.Text = GetWelcomeMessageText(Profile.FirstName, Profile.LastName);
		}
	}

	private string GetWelcomeMessageText(string firstName, string lastName)
	{
		return string.Format("Welcome {0} {1}!", firstName, lastName);
	}
}
