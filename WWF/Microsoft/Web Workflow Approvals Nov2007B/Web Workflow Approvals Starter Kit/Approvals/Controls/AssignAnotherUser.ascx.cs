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

public partial class Controls_AssignAnotherUser : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.BindUserList();

			if (this.ShowActivitySelector)
			{
				this.BindActivitiesList();
			}

			this.dropDownList.Visible = this.ShowActivitySelector;
		}
	}

	public bool ShowActivitySelector
	{
		get
		{
			object obj = this.ViewState["showActivitySelector"];

			return obj == null ? false : Convert.ToBoolean(obj);
		}
		set
		{
			this.ViewState["showActivitySelector"] = value;
		}
	}

	private void BindUserList()
	{
		this.radioButtonList.DataSource = Membership.GetAllUsers();
		this.radioButtonList.DataTextField = "UserName";
		this.radioButtonList.DataValueField = "ProviderUserKey";
		this.radioButtonList.DataBind();
	}

	private void BindActivitiesList()
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
			this.commentTextBox.Enabled = false;
		}
	}

	/// <summary>
	/// Gets the Workflow activity guid from the Querystring
	/// </summary>
	public Guid? ActivityGuid
	{
		get
		{
			Guid? activityGuid = null;

			if (this.ShowActivitySelector)
			{
				//Get the selected activity from the drop down list
				if (!string.IsNullOrEmpty(this.dropDownList.SelectedValue))
				{
					activityGuid = new Guid(this.dropDownList.SelectedValue);
				}
			}
			else
			{
				//Get the selected activity from the querystring
				activityGuid = QueryStringHelper.GetActivityGuid(this.Page);
			}

			return activityGuid;
		}
	}

	private void Reassign()
	{
		string message = string.Empty;

		Guid? activityGuid = this.ActivityGuid;

		if (!activityGuid.HasValue)
		{
			message = "Please select a task to assign.";
		}
		else if (String.IsNullOrEmpty(this.radioButtonList.SelectedValue))
		{
			message = "Please select a user to assign the task too.";
		}
		else
		{
			message = UserActivityService.Singleton.AssignUserActivity(activityGuid.Value,
					(Guid)Membership.GetUser().ProviderUserKey,
					new Guid(this.radioButtonList.SelectedValue),
					this.commentTextBox.Text.Trim()).Message;
		}

		JavascriptHelper.Alert(this.Page, message, "reassignResult");
	}

	protected void reassignImageButton_Click(object sender, ImageClickEventArgs e)
	{
		this.Reassign();
	}
}
