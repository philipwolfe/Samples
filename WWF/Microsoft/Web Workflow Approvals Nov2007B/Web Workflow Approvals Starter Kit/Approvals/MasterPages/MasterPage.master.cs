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
using Workflows;

public partial class MasterPages_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Resets the CreateUserWizard and loads the login controls
    /// </summary>
    private void Reset()
    {
        //Reset the wizard
        this.createUserWizard.ActiveStepIndex = 0;

        //Load the login controls
        this.multiView.SetActiveView(this.signInView);
    }

    /// <summary>
    /// Assigns the newly created user to the default roles
    /// </summary>
    private void AssignNewUserToRoles()
    {
        //Ensure the user exists
        if (Membership.GetUser(this.createUserWizard.UserName) != null)
        {
            Roles.AddUserToRoles(this.createUserWizard.UserName,
                    new string[] { UserRole.WorkItemResolver.ToString(), UserRole.WorkItemRequester.ToString() });
        }
    }

    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        this.multiView.SetActiveView(this.registerView);
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        this.Reset();
    }

    protected void createUserWizard_ContinueButtonClick(object sender, EventArgs e)
    {
        this.Reset();
    }

    protected void createUserWizard_CreatedUser(object sender, EventArgs e)
    {
        this.AssignNewUserToRoles();
    }
}
