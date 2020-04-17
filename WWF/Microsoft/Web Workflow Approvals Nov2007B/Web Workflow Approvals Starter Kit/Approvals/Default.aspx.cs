//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

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
using System.Threading;
using System.Workflow;
using System.Workflow.Runtime;
using System.Collections.ObjectModel;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.approvalRequestLinkButton.Visible = WorkflowUserActivityInvestigator.Singleton.CanCurrentUserWorkOnFirstUserActivityForWorkflow(typeof(Workflows.ApprovedWorkItemWorkflow));

            string messageString = QueryStringHelper.GetString(this.Page, Global.QuerystringKeys.Message, false);
            if (!String.IsNullOrEmpty(messageString.Trim()))
                JavascriptHelper.Alert(this.Page, messageString, "defaultMessage");
        }
    }

    private Controls_TaskList GetTaskList(string name)
    {
        return this.loginView.Controls[0].FindControl(name) as Controls_TaskList;
    }

    private Controls_TaskList UsersTaskList
    {
        get
        {
            return this.GetTaskList("usersTaskList");
        }
    }

    private Controls_TaskList RolesTaskList
    {
        get
        {
            return this.GetTaskList("rolesTaskList");
        }
    }

    protected void approvalRequestLinkButton_Click(object sender, EventArgs e)
    {
        WorkflowInstance instance = UserActivitiesHelper.Runtime.CreateWorkflow(typeof(Workflows.ApprovedWorkItemWorkflow));
        instance.Start();

        // Because we configured the WorkflowRuntime with the ManualWorkflowSchedulerService replacing 
        // the DefaultWorkflowSchedulerService in Web.config, we need to manually tell a workflow instance 
        // to progress as far as it can. This allows us to control the threads that the workflows execute on, 
        // an important consideration when running workflows in a constrained threading environment, 
        // such as ASP.NET on IIS.
        // This also allows us to easily synchronize user interaction with workflow progress.
        UserActivitiesHelper.SchedulerService.RunWorkflow(instance.InstanceId);

        TrackingDataSet.UserActivityWorkItemTrackingRow latestTrackingRecord = TrackingHelper.GetYoungestTrackingRecordForWorkflow(instance.InstanceId);

        Response.Redirect(QueryStringHelper.CreateEditTaskLink(latestTrackingRecord.ActivityGuid,
            latestTrackingRecord.ActivityTypeName,
            instance.InstanceId));
    }

    protected void refreshTaskListsLinkButton_Click(object sender, EventArgs e)
    {
        this.RefreshTaskLists();
    }

    private void RefreshTaskLists()
    {
        if (User.Identity.IsAuthenticated)
        {
            Controls_TaskList taskList = this.UsersTaskList;

            if (taskList != null)
            {
                taskList.Refresh();
            }

            taskList = this.RolesTaskList;

            if (taskList != null)
            {
                taskList.Refresh();
            }
        }
    }
}
