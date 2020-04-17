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
using Workflows;
using System.Collections.Generic;

public partial class Controls_TaskList : System.Web.UI.UserControl
{
	public enum TaskListType
	{
		UsersTasks,
		RolesTasks
	}

	private const string TaskListTypeKey = "taskListType";

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.BindActivities();
		}
	}

	public TaskListType ListType
	{
		get
		{
			object obj = this.ViewState[TaskListTypeKey];

			if (obj == null)
			{
				//Default
				obj = TaskListType.UsersTasks;
			}

			return (TaskListType)Enum.Parse(typeof(TaskListType), obj.ToString());
		}
		set
		{
			this.ViewState[TaskListTypeKey] = value;
		}
	}

	public string BodyCssClass
	{
		get
		{
            this.EnsureChildControls();

            return this.panel.CssClass;
		}
		set
		{
            this.EnsureChildControls();

            this.panel.CssClass = value;
		}
	}

	public string Title
	{
		get
		{
            this.EnsureChildControls();

            return this.label.Text;
		}
		set
		{
			this.EnsureChildControls();

            this.label.Text = value;
		}
	}

    public string ImageUrl
    {
        get
        {
            this.EnsureChildControls();

            return this.image.ImageUrl;
        }
        set
        {
            this.EnsureChildControls();

            this.image.ImageUrl= value;
        }
    }

	public void BindActivities()
	{
		if (this.Page.User.Identity.IsAuthenticated)
		{
			Guid userID = (Guid)Membership.GetUser().ProviderUserKey;

			UserActivitiesDataSet dataSet = UserActivityService.Singleton.GetUsersActivities(userID);

			List<UserActivitiesDataSet.UserActivitiesRow> usersTasksList = new List<UserActivitiesDataSet.UserActivitiesRow>();
			List<UserActivitiesDataSet.UserActivitiesRow> rolesTasksList = new List<UserActivitiesDataSet.UserActivitiesRow>();

			DataView dataView = new DataView(dataSet.UserActivityAssignments,
					string.Empty,
					string.Format("{0} DESC", dataSet.UserActivityAssignments.DateAssignedColumn.ColumnName),
					DataViewRowState.CurrentRows);

			foreach (UserActivitiesDataSet.UserActivitiesRow activityRow in dataSet.UserActivities)
			{
				dataView.RowFilter = string.Format("{0} = '{1}'",
						dataSet.UserActivities.ActivityGuidColumn.ColumnName,
						activityRow.ActivityGuid);

				if (!dataView.Count.Equals(0) &&
						((UserActivitiesDataSet.UserActivityAssignmentsRow)dataView[0].Row).AssignedUser.Equals(userID))
				{
					//This is assigned to the current user
					usersTasksList.Add(activityRow);
				}
				else
				{
					//This is for anyone in the role
					rolesTasksList.Add(activityRow);
				}
			}

			this.repeater.DataSource = this.ListType.Equals(TaskListType.UsersTasks) ? usersTasksList : rolesTasksList;
			this.repeater.DataBind();
		}
	}

	/// <summary>
	/// Refreshes the list of tasks
	/// </summary>
	public void Refresh()
	{
		this.BindActivities();
	}
}
