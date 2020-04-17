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
using System.ComponentModel;

public partial class MasterPages_WorkflowTask : MasterPage, IBaseWorkflowTaskMasterPage
{
    protected const string UserActivityTypeKey = "UserActivityType";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.detailsHyperLink.NavigateUrl = string.Format("~/Authenticated/WorkflowInstance.aspx?{0}={1}",
                    Global.QuerystringKeys.WorkflowGuid,
                    Server.UrlEncode(QueryStringHelper.GetWorkflowGuid(this.Page).ToString()));

            //Ensure task has not been completed
            if (!ActivityIsIncomplete())
                return;

            //Ensure the current user can work on the task
            else if (!UserActivitiesHelper.CanUserWorkOnActivity(QueryStringHelper.GetActivityGuid(this.Page),
                     (Guid)Membership.GetUser().ProviderUserKey))
            {
                //Let the user know that they cannot work on the task and disable the save and submit buttons
                JavascriptHelper.Alert(this.Page,
                        "Sorry but you do not have the required role to work on this task\\n\\nSaving has been disabled.",
                        "savingDisabled");

                this.saveImageButton.Enabled =
                        this.submitImageButton.Enabled = false;
            }
        }
    }

    public bool ActivityIsIncomplete()
    {
        if (!UserActivitiesHelper.ActivityIsIncomplete(QueryStringHelper.GetActivityGuid(this.Page)))
        {
            //JavascriptHelper.Alert(this.Page, result.Message, "completeActivityResult");
            Response.Redirect(string.Format("~/Default.aspx?{0}={1}",
                    Global.QuerystringKeys.Message,
                    Server.UrlEncode("This activity has already been completed and can no longer be worked on.")));

            return false;
        }
        else
            return true;
    }

    /// <summary>
    /// Gets or sets the <see cref="UserActivityType"/> for the page
    /// </summary>
    public UserActivityType UserActivityType
    {
        get
        {
            object obj = this.ViewState[UserActivityTypeKey];

            if (obj == null)
            {
                //Default
                obj = UserActivityType.EnterApprovalRequest;
            }

            return (UserActivityType)Enum.Parse(typeof(UserActivityType), obj.ToString());
        }
        set
        {
            this.ViewState[UserActivityTypeKey] = value;
        }
    }

    public string TaskName
    {
        get
        {
            return this.taskNameLabel.Text;
        }
        set
        {
            this.taskNameLabel.Text = value;
        }
    }

    public string TaskTip
    {
        get
        {
            return this.taskTipLabel.Text;
        }
        set
        {
            this.taskTipLabel.Text = value;
        }
    }

    /// <summary>
    /// Gets the activity data for the current activity
    /// </summary>
    public DataSet TaskDataSet
    {
        get
        {
            DataSet dataSet = null;

            object obj = this.Session[Global.SessionKeys.TaskDataSet];

            if (obj == null)
            {
                dataSet = ActivityDataInterface.GetActivityData(QueryStringHelper.GetActivityGuid(this.Page), this.UserActivityType);

                this.Session[Global.SessionKeys.TaskDataSet] = dataSet;
            }
            else
            {
                dataSet = (DataSet)obj;
            }

            return dataSet;
        }
        set
        {
            this.Session[Global.SessionKeys.TaskDataSet] = value;
        }
    }

    public event EventHandler<CancelEventArgs> BeforeSave;

    private CancelEventArgs OnBeforeSave()
    {
        CancelEventArgs e = new CancelEventArgs();

        if (this.BeforeSave != null)
        {
            this.BeforeSave(this, e);
        }

        return e;
    }

    public event EventHandler<CancelEventArgs> BeforeSubmit;

    private CancelEventArgs OnBeforeSubmit()
    {
        CancelEventArgs e = new CancelEventArgs();

        if (this.BeforeSubmit != null)
        {
            this.BeforeSubmit(this, e);
        }

        return e;
    }

    public event EventHandler<CancelEventArgs> BeforeCancel;

    private CancelEventArgs OnBeforeCancel()
    {
        CancelEventArgs e = new CancelEventArgs();

        if (this.BeforeCancel != null)
        {
            this.BeforeCancel(this, e);
        }

        return e;
    }

    private bool Save()
    {
        return this.Save(true);
    }

    private bool Save(bool showMessage)
    {
        if (!ActivityIsIncomplete())
            return true;

        bool isCancelled = this.OnBeforeSave().Cancel;

        if (!isCancelled)
        {
            Result result = ActivityDataInterface.SaveActivityData(QueryStringHelper.GetActivityGuid(this.Page),
                    this.UserActivityType,
                    this.TaskDataSet);

            if (showMessage)
            {
                JavascriptHelper.Alert(this.Page,
                        result.Message,
                        "saveActivityResult");
            }
        }

        return !isCancelled;
    }

    private bool Submit()
    {
        if (!ActivityIsIncomplete())
            return true;

        bool isCancelled = !this.Save(false);

        if (!isCancelled)
        {
            isCancelled = this.OnBeforeSubmit().Cancel;

            Result result;

            if (!isCancelled)
            {
                Guid workflowGuid = QueryStringHelper.GetWorkflowGuid(this.Page);
                Guid activityGuid = QueryStringHelper.GetActivityGuid(this.Page);
                Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;

                //Check if the user is already assigned to the task
                if (!UserActivitiesHelper.UserIsAssignedToActivity(activityGuid, userGuid))
                {
                    //Attempt to assign the task to the user so they can complete it
                    result = UserActivityService.Singleton.AssignUserActivity(activityGuid,
                            userGuid,
                            userGuid,
                            "Assigning to self so task can be completed");

                    if (!result.IsSuccessful)
                    {
                        JavascriptHelper.Alert(this.Page, result.Message, "assignActivityResult");

                        return false;
                    }
                }

                //Now that the task is asssigned we can try and complete it
                result = UserActivityService.Singleton.CompleteUserActivity(workflowGuid,
                        activityGuid,
                        this.TaskDataSet,
                        userGuid);

                //JavascriptHelper.Alert(this.Page, result.Message, "completeActivityResult");
                Response.Redirect(string.Format("~/Default.aspx?{0}={1}&{2}={3}",
                        Global.QuerystringKeys.Message,
                        Server.UrlEncode(result.Message),
                        Global.QuerystringKeys.Result,
                        Server.UrlEncode(result.IsSuccessful.ToString())));
            }
        }

        return !isCancelled;
    }

    private bool Cancel()
    {
        bool isCancelled = this.OnBeforeCancel().Cancel;

        if (!isCancelled)
        {
            this.ReturnHome();
        }

        return !isCancelled;
    }

    private void ReturnHome()
    {
        this.Response.Redirect("~/Default.aspx");
    }

    protected void Save(object sender, ImageClickEventArgs e)
    {
        this.Save();
    }

    protected void Submit(object sender, ImageClickEventArgs e)
    {
        this.Submit();
    }

    protected void Cancel(object sender, ImageClickEventArgs e)
    {
        this.Cancel();
    }
}
