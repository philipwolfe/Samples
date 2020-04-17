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

		this.RefreshTaskLists();

		//Show a message incase the user is not logged in or does not have the correct role to see the changes to the workflow task lists
		JavascriptHelper.Alert(this.Page, "Your request to create the Approval Request workflow has been actioned.", "workflowstarted");
	}

	protected void refreshTaskListsLinkButton_Click(object sender, EventArgs e)
	{
		this.RefreshTaskLists();
	}

	private void RefreshTaskLists()
	{
        if (User.Identity.IsAuthenticated)
        {
            this.UsersTaskList.Refresh();
            this.RolesTaskList.Refresh();
        }
	}
}
