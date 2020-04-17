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

public partial class Controls_Workflows : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.LoadFilterControls();
		}
	}

	private void LoadFilterControls()
	{
		WorkItemsTrackingDataSet.ActivityTrackingSummaryDataTable table = new WorkItemsTrackingDataSet.ActivityTrackingSummaryDataTable();

		DataColumn[] columns = new DataColumn[4];
		columns[0] = table.NameColumn;
		columns[1] = table.StartedOnColumn;
		columns[2] = table.StartedByColumn;
		columns[3] = table.WaitingOnColumn;

		this.currentFilterControl.Initialise(columns);

		//Replace the last column for the completed grid filter
		columns[3] = table.CompleteOnColumn;

		this.completedFilterControl.Initialise(columns);
	}

	protected void btnCompletedInactive_Click(object sender, EventArgs e)
	{
		this.multiView.SetActiveView(this.completedView);
	}

	protected void btnCurrentInactive_Click(object sender, EventArgs e)
	{
		this.multiView.SetActiveView(this.currentView);
	}

	protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName.Equals("ViewDetails"))
		{
			Response.Redirect(string.Format("WorkflowInstance.aspx?{0}={1}",
			Global.QuerystringKeys.WorkflowGuid,
			e.CommandArgument));
		}
	}


	protected void exportCurrentImageButton_Click(object sender, ImageClickEventArgs e)
	{
		DataView dataView = DatabaseTrackingHelper.GetCurrentWorkflows(string.Format("{0}{1}",
				this.currentGridView.SortExpression,
				this.currentGridView.SortDirection.Equals(SortDirection.Descending) ? " DESC" : string.Empty),
				this.currentFilterControl.FilterExpression);

		WorkItemsTrackingDataSet.ActivityTrackingSummaryDataTable dataTable = (WorkItemsTrackingDataSet.ActivityTrackingSummaryDataTable)dataView.Table;

		string[] columns = new string[4];

		columns[0] = dataTable.NameColumn.ColumnName;
		columns[1] = dataTable.StartedOnColumn.ColumnName;
		columns[2] = dataTable.StartedByColumn.ColumnName;
		columns[3] = dataTable.WaitingOnColumn.ColumnName;

		this.ExportWorkflowListCsv(dataView, columns);
	}

	protected void exportCompleteImageButton_Click(object sender, ImageClickEventArgs e)
	{
		DataView dataView = DatabaseTrackingHelper.GetCompletedWorkflows(string.Format("{0}{1}",
				this.completedGridView.SortExpression,
				this.completedGridView.SortDirection.Equals(SortDirection.Descending) ? " DESC" : string.Empty),
				this.completedFilterControl.FilterExpression);

		WorkItemsTrackingDataSet.ActivityTrackingSummaryDataTable dataTable = (WorkItemsTrackingDataSet.ActivityTrackingSummaryDataTable)dataView.Table;

		string[] columns = new string[5];

		columns[0] = dataTable.NameColumn.ColumnName;
		columns[1] = dataTable.StartedOnColumn.ColumnName;
		columns[2] = dataTable.StartedByColumn.ColumnName;
		columns[3] = dataTable.CompleteOnColumn.ColumnName;

		this.ExportWorkflowListCsv(dataView, columns);
	}

	private void ExportWorkflowListCsv(DataView dataView, string[] columns)
	{
		CSVHelper.Export(this.Page,
				dataView,
				columns,
				",",
				"WorkflowList.csv",
				true);
	}

	protected void currentFilter_FilterChanged(object sender, FilterChangedEventArgs e)
	{
		this.currentWorkflowsObjectDataSource.Select();
	}

	protected void completedFilter_FilterChanged(object sender, FilterChangedEventArgs e)
	{
		this.completedWorkflowsObjectDataSource.Select();
	}

}
