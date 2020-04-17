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
using Workflows;
using System.Transactions;
using Workflows.WorkItemsDataSetTableAdapters;

public static class ActivityDataInterface
{
	/// <summary>
	/// Initialises a user activity so that it is associated with the user activity entry in the database.
	/// </summary>
	/// <param name="workflowGuid">The workflow the user activity is to be initialised for.</param>
	/// <param name="activityGuid">Identifies the user activity.</param>
	/// <param name="type">The type of user activity it is.</param>
	/// <param name="activityData">The data coming out of the workflow for the user activity.</param>
	public static void InitialiseActivityData(Guid workflowGuid, Guid activityGuid, UserActivityType type, DataSet activityData)
	{
		SaveActivityData(activityGuid, type, activityData);
	}

	/// <summary>
	/// Saves the user activity data to the database.
	/// </summary>
	/// <param name="activityGuid">Identifies the user activity.</param>
	/// <param name="type">The type of user activity it is.</param>
	/// <param name="activityData">The data coming from the user for the user activity.</param>
	public static Result SaveActivityData(Guid activityGuid, UserActivityType type, DataSet activityData)
	{
		switch (type)
		{
			case UserActivityType.EnterApprovalRequest:
			case UserActivityType.EnterResolution:
			case UserActivityType.ManagerApproval:
				return SaveWorkItems(activityGuid, activityData as WorkItemsDataSet);

			default:
				return new Result(false, "Unrecognised activity type, unable to save.");
		}
	}

	private static Result SaveWorkItems(Guid activityGuid, WorkItemsDataSet workItems)
	{
		if (workItems != null)
		{
			try
			{
				string activityGuidString = activityGuid.ToString();
				foreach (WorkItemsDataSet.WorkItemsRow workItem in workItems.WorkItems.Rows)
				{
					WorkItemsDataSet.UserActivitiesWorkItemsRow userActivityWorkItem = workItems.UserActivitiesWorkItems.FindByActivityGuidWorkItemName(activityGuidString, workItem.WorkItemName);
					if (userActivityWorkItem == null)
						workItems.UserActivitiesWorkItems.AddUserActivitiesWorkItemsRow(activityGuidString, workItem);
				}
				using (WorkItemsTableAdapter workItemsAdapter = new WorkItemsTableAdapter())
					workItemsAdapter.Update(workItems.WorkItems);
				using (UserActivitiesWorkItemsTableAdapter userActivitiesWorkItemsAdapter = new UserActivitiesWorkItemsTableAdapter())
					userActivitiesWorkItemsAdapter.Update(workItems.UserActivitiesWorkItems);

				return new Result("Work items saved.");
			}
			catch (Exception ex)
			{
				return new Result(false, ex.ToString());
			}
		}
		else
			return new Result(false, "No work items to save.");
	}

	/// <summary>
	/// Retrieves the data for a user activty. Usually used to give the workflow a fresh copy of the data when a user elects to "submit" an activity, thereby completing it.
	/// </summary>
	/// <param name="activityGuid">Identifies the user activity.</param>
	/// <param name="type">The type of the user activity.</param>
	/// <returns>the data for the activity.</returns>
	public static DataSet GetActivityData(Guid activityGuid, UserActivityType type)
	{
		switch (type)
		{
			case UserActivityType.EnterApprovalRequest:
			case UserActivityType.EnterResolution:
			case UserActivityType.ManagerApproval:

				WorkItemsDataSet workItems = new WorkItemsDataSet();
				string activityGuidString = activityGuid.ToString();
				using (WorkTypesTableAdapter typesAdapter = new WorkTypesTableAdapter())
					typesAdapter.Fill(workItems.WorkTypes);
				using (WorkItemsTableAdapter workItemsAdapter = new WorkItemsTableAdapter())
					workItemsAdapter.FillByActivityGuid(workItems.WorkItems, activityGuidString);
				using (UserActivitiesWorkItemsTableAdapter userActivitiesWorkItemsAdapter = new UserActivitiesWorkItemsTableAdapter())
					userActivitiesWorkItemsAdapter.FillByActivityGuid(workItems.UserActivitiesWorkItems, activityGuidString);

				return workItems;

			default:
				throw new ArgumentException(type.ToString() + " does not have an implementation of retrieving activity data.");
		}
	}
}
