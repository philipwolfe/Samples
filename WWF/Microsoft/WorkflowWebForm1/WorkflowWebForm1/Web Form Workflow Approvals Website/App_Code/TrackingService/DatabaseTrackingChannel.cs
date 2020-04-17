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
using System.IO;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Tracking;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities.Rules;

using WorkItemsTrackingDataSetTableAdapters;
using Workflows;

/// <summary>
/// Summary description for DatabaseTrackingChannel
/// </summary>
public class DatabaseTrackingChannel : TrackingChannel
{
	private TrackingParameters parameters = null;

	/// <summary>
	/// Initializes a new instance of the <see cref="DatabaseTrackingChannel"/> class.
	/// </summary>
	protected DatabaseTrackingChannel()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DatabaseTrackingChannel"/> class.
	/// </summary>
	/// <param name="parameters">The parameters.</param>
	public DatabaseTrackingChannel(TrackingParameters parameters)
	{
		this.parameters = parameters;
	}

	/// <summary>
	/// When implemented in a derived class, sends a <see cref="T:System.Workflow.Runtime.Tracking.TrackingRecord"></see> on the <see cref="T:System.Workflow.Runtime.Tracking.TrackingChannel"></see>.
	/// </summary>
	/// <param name="record">The <see cref="T:System.Workflow.Runtime.Tracking.TrackingRecord"></see> to send.</param>
	protected override void Send(TrackingRecord record)
	{
		if (record is ActivityTrackingRecord)
		{
			DumpActivityTrackingRecord((ActivityTrackingRecord)record);
		}
	}

	/// <summary>
	/// Dumps the activity tracking record.
	/// </summary>
	/// <param name="activityTrackingRecord">The activity tracking record.</param>
	private void DumpActivityTrackingRecord(ActivityTrackingRecord activityTrackingRecord)
	{
		foreach (TrackingDataItem dataItem in activityTrackingRecord.Body)
		{
			/* Inside UserActivitiesHelper when we created 'propertiesToTrack'
			 * we added 'WorkItems', here we pull out the 'WorkItems' property
			 * and output it to the database.
			 */
			if (dataItem.FieldName == "WorkItems")
			{
				WorkItemsDataSet workItemDataSet = (WorkItemsDataSet)dataItem.Data;
				InsertActivityTrackingRecord(activityTrackingRecord, workItemDataSet);
			}
			/* act on a different dataItem.FieldName */
		}
	}

	/// <summary>
	/// Inserts the contents of the workItemDataSet into the tracking store.
	/// </summary>
	/// <param name="activityTrackingRecord">The activity tracking record.</param>
	/// <param name="workItemDataSet">The work item data set.</param>
	void InsertActivityTrackingRecord(ActivityTrackingRecord activityTrackingRecord, WorkItemsDataSet workItemDataSet)
	{
		if (workItemDataSet == null)
		{
			/* the workflow has just been created, so we dont have any infomation about the WorkItem just yet
			 * so we just log the fact that something happened 
			 */
			using (ActivityTrackingTableAdapter activityTrackingAdapter = new ActivityTrackingTableAdapter())
				activityTrackingAdapter.Insert(
					/* the data */
						null, null, null, null, null,
						null, null, null, null,
					/* versioning infomation */
						activityTrackingRecord.ContextGuid,
						activityTrackingRecord.ExecutionStatus.ToString(),
						activityTrackingRecord.QualifiedName,
						activityTrackingRecord.ActivityType.FullName.ToString(),
						activityTrackingRecord.EventOrder,
						activityTrackingRecord.EventDateTime.ToString()
		);
		}
		else
		{
			/* we have actual data so we log it as well as the activity state */
			using (ActivityTrackingTableAdapter activityTrackingAdapter = new ActivityTrackingTableAdapter())
			{
				foreach (WorkItemsDataSet.WorkItemsRow workItemRow in workItemDataSet.Tables["WorkItems"].Rows)
				{
					activityTrackingAdapter.Insert(
						/* the data */
					workItemRow.WorkItemName,
					workItemRow.WorkItemType,
					workItemRow.Description,
					workItemRow.Reason,
					workItemRow.DateRequested,
					workItemRow.FundingCostCenter,
					workItemRow.AreaAffected,
					workItemRow.Approved,
					workItemRow.Result,
						/* versioning infomation */
					activityTrackingRecord.ContextGuid,
					activityTrackingRecord.ExecutionStatus.ToString(),
					activityTrackingRecord.QualifiedName,
					activityTrackingRecord.ActivityType.FullName.ToString(),
					activityTrackingRecord.EventOrder,
					activityTrackingRecord.EventDateTime.ToString()
					);
				}
			}
		}
	}

	/// <summary>
	/// When implemented in a derived class, notifies a receiver of data on the tracking channel that the workflow instance associated with the tracking channel has either completed or terminated.
	/// </summary>
	protected override void InstanceCompletedOrTerminated()
	{
	}
}
