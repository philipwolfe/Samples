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

public partial class Authenticated_EnterApprovalRequestTask : ApprovalRequestBasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			//Set the user activity type of the master page
			((MasterPages_WorkflowTask)this.Master).UserActivityType = UserActivityType.EnterApprovalRequest;

			//Clear any old datasets from the session
			this.ClearData();

			//Set the task name
			((MasterPages_WorkflowTask)this.Master).TaskName = "Enter Approval Request";
			((MasterPages_WorkflowTask)this.Master).TaskTip = "Please enter the details of the approval request below";

			this.LoadData();
		}
	}

	private void LoadData()
	{
		WorkItemsDataSet dataSet = this.GetData();
		WorkItemsDataSet.WorkItemsRow dataRow = null;

		if (dataSet.WorkItems.Rows.Count.Equals(0))
		{
			dataRow = dataSet.WorkItems.NewWorkItemsRow();
			dataRow.WorkItemType = dataSet.WorkTypes[0].WorkTypeName;
			dataRow.DateRequested = DateTime.Now;
			dataRow.Approved = false;
			dataRow.WorkItemName =
					dataRow.Description =
					dataRow.Reason =
					dataRow.FundingCostCenter =
					dataRow.AreaAffected =
					dataRow.Result = string.Empty;

			dataSet.WorkItems.AddWorkItemsRow(dataRow);
		}
		else
		{
			dataRow = dataSet.WorkItems[0];
		}

		this.nameFieldControl.DataSource =
				this.descriptionFieldControl.DataSource =
				this.typeOfWorkFieldControl.DataSource =
				this.reasonFieldControl.DataSource =
				this.dateRequestedFieldControl.DataSource =
				this.fundingFieldControl.DataSource =
				this.areaFieldControl.DataSource = dataRow;

		this.typeOfWorkFieldControl.OptionDataSource = dataSet.WorkTypes;
	}
}
