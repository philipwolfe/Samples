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
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflows;

public class Security
{
	/// <summary>
	/// Does a quick check to ensure that the required roles exists in the databsse
	/// </summary>
	public static void EnsureRolesExist()
	{
		foreach (Workflows.UserRole userRole in Enum.GetValues(typeof(Workflows.UserRole)))
		{
			if (!Roles.RoleExists(Workflows.UserRole.Administrator.ToString()))
			{
				Roles.CreateRole(Workflows.UserRole.Administrator.ToString());
			}
		}
	}

	/// <summary>
	/// Ensures our list of users exist in the database and are assigned to the correct roles
	/// </summary>
	public static void EnsureUsersExist()
	{
		Security.EnsureUserExists("Charles", new string[] { UserRole.Administrator.ToString() });
		Security.EnsureUserExists("Jane", new string[] { UserRole.Manager.ToString() });
		Security.EnsureUserExists("Rachel", new string[] { UserRole.EnterResolution.ToString(), UserRole.RequestApproval.ToString() });
	}

	/// <summary>
	/// Ensures our user exists and is assigned to the correct role
	/// </summary>
	/// <param name="userName">The user name to check</param>
	/// <param name="roles">The list of roles to assign the user if they need to be created</param>
	private static void EnsureUserExists(string userName, string[] roles)
	{
		if (Membership.GetUser(userName) == null)
		{
			Membership.CreateUser(userName, "password");
			Roles.AddUserToRoles(userName, roles);
		}
	}
}
