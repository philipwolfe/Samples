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

public partial class Authenticated_ManagerApprovalTask : ApprovalRequestBasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			//Set the user activity type of the master page
			((MasterPages_WorkflowTask)this.Master).UserActivityType = UserActivityType.ManagerApproval;

			//Clear any old datasets from the session
			this.ClearData();

			//Set the task name
			((MasterPages_WorkflowTask)this.Master).TaskName = "Manager Approval";
			((MasterPages_WorkflowTask)this.Master).TaskTip = "Please approve or decline the request";

			this.LoadData();
		}
	}

	private void LoadData()
	{
		WorkItemsDataSet dataSet = this.GetData();
		WorkItemsDataSet.WorkItemsRow dataRow = null;

		dataRow = dataSet.WorkItems[0];

		this.nameFieldControl.DataSource =
				this.descriptionFieldControl.DataSource =
				this.typeOfWorkFieldControl.DataSource =
				this.reasonFieldControl.DataSource =
				this.dateRequestedFieldControl.DataSource =
				this.fundingFieldControl.DataSource =
				this.areaFieldControl.DataSource =
				this.approvedFieldControl.DataSource = dataRow;

		this.typeOfWorkFieldControl.OptionDataSource = dataSet.WorkTypes;
	}
}
