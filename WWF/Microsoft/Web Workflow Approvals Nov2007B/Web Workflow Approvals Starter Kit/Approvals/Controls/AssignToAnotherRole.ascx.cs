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
using UserActivitiesDataSetTableAdapters;
using Workflows;

public partial class Controls_AssignToAnotherRole : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.LoadRoles();
			this.LoadActivities();
		}
	}

	private void LoadRoles()
	{
		this.radioButtonList.DataSource = Roles.GetAllRoles();
		this.radioButtonList.DataBind();
	}

	private void LoadActivities()
	{
		this.dropDownList.DataSource = UserActivityService.Singleton.GetIncompleteActivities(QueryStringHelper.GetWorkflowGuid(this.Page));
		this.dropDownList.DataTextField = "Description";
		this.dropDownList.DataValueField = "ActivityGuid";
		this.dropDownList.DataBind();

		//If incomplete activites list is empty then disable reassignemnt
		if (this.dropDownList.Items.Count == 0)
		{
			this.reassignImageButton.Enabled = false;
			this.dropDownList.Enabled = false;
			this.radioButtonList.Enabled = false;
		}
	}

	private void Reassign()
	{
		string message = string.Empty;

		if (!Roles.IsUserInRole(UserRole.Administrator.ToString()))
		{
			message = "You must be an administrator to change the role.";
		}
		else if (String.IsNullOrEmpty(this.radioButtonList.SelectedValue))
		{
			message = "Please select a role to assign the task too.";
		}
		else
		{
			UserActivitiesDataSet.aspnet_RolesDataTable table = null;

			using (aspnet_RolesTableAdapter adapter = new aspnet_RolesTableAdapter())
			{
				table = adapter.GetData();
			}

			message = UserActivityService.Singleton.AssignUserActivityToRole(new Guid(this.dropDownList.SelectedValue),
					table.FindByApplicationIdLoweredRoleName(UserActivitiesHelper.ApplicationGuid, this.radioButtonList.SelectedValue.ToLower()).RoleId).Message;
		}

		JavascriptHelper.Alert(this.Page, message, "reassignResult");
	}

	protected void reassignImageButton_Click(object sender, ImageClickEventArgs e)
	{
		this.Reassign();
	}
}
