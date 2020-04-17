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
using System.Data.SqlClient;
using WorkItemsTrackingDataSetTableAdapters;

public class DatabaseTrackingHelper
{
	/// <summary>
	/// Gets a DataView containing all of the current executing workflows applying the given sort and filter.
	/// </summary>
	/// <param name="sort">The sort.</param>
	/// <param name="filter">The filter.</param>
	/// <returns>a DataView containg all of the Currently Executing workflows</returns>
	public static DataView GetCurrentWorkflows(string sort, string filter)
	{
		return new DataView(GetCurrentWorkflows(),
				filter,
				sort,
				DataViewRowState.CurrentRows);
	}

	/// <summary>
	/// Gets the current workflows.
	/// </summary>
	/// <returns></returns>
	public static WorkItemsTrackingDataSet.ActivityTrackingSummaryDataTable GetCurrentWorkflows()
	{
		using (ActivityTrackingSummaryTableAdapter trackingSummaryTableAdapter = new ActivityTrackingSummaryTableAdapter())
		{
			return trackingSummaryTableAdapter.GetDataByCurrentWorkflows();
		}
	}

	/// <summary>
	/// Gets a DataView containing all of the completed workflows applying the given sort and filter.
	/// </summary>
	/// <param name="sort">The sort.</param>
	/// <param name="filter">The filter.</param>
	/// <returns>a DataView containg all of the completed workflows</returns>
	public static DataView GetCompletedWorkflows(string sort, string filter)
	{
		return new DataView(GetCompletedWorkflows(),
				filter,
				sort,
				DataViewRowState.CurrentRows);
	}

	/// <summary>
	/// Gets the completed workflows.
	/// </summary>
	/// <returns></returns>
	public static WorkItemsTrackingDataSet.ActivityTrackingSummaryDataTable GetCompletedWorkflows()
	{
		using (ActivityTrackingSummaryTableAdapter trackingSummaryTableAdapter = new ActivityTrackingSummaryTableAdapter())
		{
			return trackingSummaryTableAdapter.GetDataByCompleteWorkflows();
		}
	}

	/// <summary>
	/// Gets a DataView containing the Tracking Detail for the given workflow guid, applying the given sort and filter.
	/// </summary>
	/// <param name="workflowGuid">The workflow GUID.</param>
	/// <param name="sort">The sort.</param>
	/// <param name="filter">The filter.</param>
	/// <returns>a DataView containg the tracking detail for the given workflow guid</returns>
	public static DataView GetCurrentWorkflowTrackingDetail(Guid workflowGuid, string sort, string filter)
	{
		return new DataView(GetCurrentWorkflowTrackingDetail(workflowGuid),
				filter,
				sort,
				DataViewRowState.CurrentRows);
	}

	/// <summary>
	/// Gets the current workflow tracking detail.
	/// </summary>
	/// <param name="workflowGuid">The workflow GUID.</param>
	/// <returns></returns>
	public static WorkItemsTrackingDataSet.ActivityTrackingDataTable GetCurrentWorkflowTrackingDetail(Guid workflowGuid)
	{
		using (ActivityTrackingTableAdapter trackingDetailTableAdapter = new ActivityTrackingTableAdapter())
		{
			return trackingDetailTableAdapter.GetDataByWorkflowGuid(workflowGuid);
		}
	}

	/// <summary>
	/// Returns the youngest (latest) workflow event for a given workflow, used to determine what portion of the workflow image to highlight
	/// </summary>
	/// <param name="workflowGuid">The GUID of the workflow in question</param>
	/// <returns>A Strongly Typed datarow representing the youngest tracking event</returns>
	public static WorkItemsTrackingDataSet.ActivityTrackingRow GetYoungestTrackingRecordForWorkflow(Guid workflowGuid)
	{
		using (ActivityTrackingTableAdapter trackingDetailTableAdapter = new ActivityTrackingTableAdapter())
		{
			return (WorkItemsTrackingDataSet.ActivityTrackingRow)trackingDetailTableAdapter.GetDataByYoungestTrackingRecordForWorkflow(workflowGuid).Rows[0];
		}
	}
}
