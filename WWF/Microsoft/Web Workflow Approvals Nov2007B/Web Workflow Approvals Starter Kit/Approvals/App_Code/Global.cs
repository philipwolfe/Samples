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

public class Global
{
	public class QuerystringKeys
	{
		public const string ActivityGuid = "activityid";
		public const string WorkflowGuid = "workflowid";
		public const string Result = "result";
		public const string Message = "msg";

	}

	public class SessionKeys
	{
		public const string TaskDataSet = "taskData";
	}

    public static string GetPageForActivityType(UserActivityType activityType)
    {
        string page = string.Empty;

        switch (activityType)
        {
            case UserActivityType.EnterApprovalRequest:
                page = "EnterApprovalRequestTask.aspx";
                break;
            case UserActivityType.ManagerApproval:
                page = "ManagerApprovalTask.aspx";
                break;
            case UserActivityType.EnterResolution:
                page = "EnterResolutionTask.aspx";
                break;
            default:
                throw new ArgumentException(string.Format("There is no page associated with the activity type {0}", activityType.ToString()), activityType.ToString());
        }

        return page;
    }
}
