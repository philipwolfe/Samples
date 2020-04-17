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

public partial class Controls_TaskTracking : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.LoadFilter();
		}
	}

	private void LoadFilter()
	{
        TrackingDataSet.UserActivityTrackingRecordDataTable dataTable = new TrackingDataSet.UserActivityTrackingRecordDataTable();

        DataColumn[] columns = new DataColumn[14];

        columns[0] = dataTable.WorkItemNameColumn;
        columns[1] = dataTable.WorkItemTypeColumn;
        columns[2] = dataTable.DescriptionColumn;
        columns[3] = dataTable.ReasonColumn;
        columns[4] = dataTable.DateRequestedColumn;
        columns[5] = dataTable.FundingCostCenterColumn;
        columns[6] = dataTable.AreaAffectedColumn;
        columns[7] = dataTable.ApprovedColumn;
        columns[8] = dataTable.ResultColumn;
        columns[9] = dataTable.StatusColumn;
        columns[10] = dataTable.ActivityDescriptionColumn;
        columns[11] = dataTable.ActivityNameColumn;
        columns[12] = dataTable.ActivityTypeNameColumn;
        columns[13] = dataTable.TrackedAtColumn;

        this.filterControl.Initialise(columns);
	}

	protected void filterControl_FilterChanged(object sender, FilterChangedEventArgs e)
	{
		this.trackingObjectDataSource.Select();
	}

	protected void exportImageButton_Click(object sender, ImageClickEventArgs e)
	{
        DataView dataView = TrackingHelper.GetCurrentWorkflowTrackingDetail(QueryStringHelper.GetWorkflowGuid(this.Page),
                string.Format("{0}{1}",
                        this.trackingGridView.SortExpression,
                        this.trackingGridView.SortDirection.Equals(SortDirection.Descending) ? " DESC" : string.Empty),
                this.filterControl.FilterExpression);

        TrackingDataSet.UserActivityTrackingRecordDataTable dataTable = (TrackingDataSet.UserActivityTrackingRecordDataTable)dataView.Table;

        string[] columns = new string[14];

        columns[0] = dataTable.WorkItemNameColumn.ColumnName;
        columns[1] = dataTable.WorkItemTypeColumn.ColumnName;
        columns[2] = dataTable.DescriptionColumn.ColumnName;
        columns[3] = dataTable.ReasonColumn.ColumnName;
        columns[4] = dataTable.DateRequestedColumn.ColumnName;
        columns[5] = dataTable.FundingCostCenterColumn.ColumnName;
        columns[6] = dataTable.AreaAffectedColumn.ColumnName;
        columns[7] = dataTable.ApprovedColumn.ColumnName;
        columns[8] = dataTable.ResultColumn.ColumnName;
        columns[9] = dataTable.StatusColumn.ColumnName;
        columns[10] = dataTable.ActivityDescriptionColumn.ColumnName;
        columns[11] = dataTable.ActivityNameColumn.ColumnName;
        columns[12] = dataTable.ActivityTypeNameColumn.ColumnName;
        columns[13] = dataTable.TrackedAtColumn.ColumnName;

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
}
