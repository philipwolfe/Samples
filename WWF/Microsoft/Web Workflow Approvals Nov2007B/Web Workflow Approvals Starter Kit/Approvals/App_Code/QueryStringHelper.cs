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

public class QueryStringHelper
{
	public static string GetString(Page page, string key, bool throwOnNull)
	{
		string result = page.Request.QueryString[key];

		if (result == null)
		{
			if (throwOnNull)
			{
				throw new Exception(string.Format("{0} cannot be null", key));
			}
			else
			{
				result = string.Empty;
			}
		}

		return page.Server.UrlDecode(result);
	}

	public static Guid? GetGuid(Page page, string key, bool throwOnNull)
	{
		Guid? result = null;

		string s = GetString(page, key, throwOnNull);

		if (!string.IsNullOrEmpty(s))
		{
			result = new Guid(s);
		}

		return result;
	}

	/// <summary>
	/// Retrieves the Workflow Guid from the QueryString
	/// </summary>
	public static Guid GetWorkflowGuid(Page page)
	{
		return GetGuid(page, Global.QuerystringKeys.WorkflowGuid, true).Value;
	}

	/// <summary>
	/// Retrieves the Activity Guid from the QueryString
	/// </summary>
	public static Guid GetActivityGuid(Page page)
	{
		return GetGuid(page, Global.QuerystringKeys.ActivityGuid, true).Value;
	}

    public static string CreateEditTaskLink(object activityGuid, object activityTypeName, object workflowGuid)
    {
        return string.Format("Authenticated/{0}?{1}={2}&{3}={4}",
                Global.GetPageForActivityType((UserActivityType)Enum.Parse(typeof(UserActivityType), activityTypeName.ToString())),
                Global.QuerystringKeys.ActivityGuid,
                HttpContext.Current.Server.UrlEncode(activityGuid.ToString()),
                Global.QuerystringKeys.WorkflowGuid,
                HttpContext.Current.Server.UrlEncode(workflowGuid.ToString()));
    }
}
