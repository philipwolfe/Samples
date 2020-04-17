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
using System.Collections.Generic;

public partial class Controls_AssignUsersToRoles : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.LoadUsers();
			this.LoadRoles();
			this.LoadUsersRoles();
		}
	}

	private void LoadUsers()
	{
		this.usersListBox.DataSource = Membership.GetAllUsers();
		this.usersListBox.DataBind();
	}

	private void LoadRoles()
	{
		this.rolesCheckedListBox.DataSource = Roles.GetAllRoles();
		this.rolesCheckedListBox.DataBind();
	}

	private void LoadUsersRoles()
	{
		this.rolesCheckedListBox.ClearSelection();

		ListItem item = null;

		foreach (string role in Roles.GetRolesForUser(this.usersListBox.SelectedValue))
		{
			item = this.rolesCheckedListBox.Items.FindByValue(role);

			if (item != null)
			{
				item.Selected = true;
			}
		}

		this.rolesCheckedListBox.Enabled =
				this.saveImageButton.Enabled = (this.usersListBox.SelectedItem != null);
	}

	protected void usersListBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.LoadUsersRoles();
	}

	protected void Save(object sender, ImageClickEventArgs e)
	{
		string selectedUser = this.usersListBox.SelectedValue;

		if (String.IsNullOrEmpty(selectedUser))
		{
			//Should never make it this far as the save button will be disabled...
			JavascriptHelper.Alert(this.Page, "Please select a user.", "noUserMessage");
		}
		else
		{
			List<string> currentRoles = new List<string>();
			List<string> selectedRoles = new List<string>();
			List<string> unselectedRoles = new List<string>();

			currentRoles.AddRange(Roles.GetRolesForUser(selectedUser));

			foreach (ListItem item in this.rolesCheckedListBox.Items)
			{
				if (item.Selected &&
						!currentRoles.Contains(item.Value))
				{
					selectedRoles.Add(item.Value);
				}
				else if (!item.Selected &&
						currentRoles.Contains(item.Value))
				{
					unselectedRoles.Add(item.Value);
				}
			}

			if (!unselectedRoles.Count.Equals(0))
			{
				Roles.RemoveUserFromRoles(selectedUser, unselectedRoles.ToArray());
			}

			if (!selectedRoles.Count.Equals(0))
			{
				Roles.AddUserToRoles(selectedUser, selectedRoles.ToArray());
			}
		}
	}
}
