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
using System.Workflow.Activities;
using UserActivitiesDataSetTableAdapters;
using Workflows;
using System.Web.Security;
using System.Web;

/// <summary>
/// An implementation of <see cref="IUserActivityService"/>.
/// </summary>
public class UserActivityService : IUserActivityService
{
	#region Singleton

	private static UserActivityService singleton;

	/// <summary>
	/// Initialises the singleton instance.
	/// </summary>
	static UserActivityService()
	{
		singleton = new UserActivityService();
		Helper.UserActivityService = singleton;
	}

	/// <summary>
	/// The singleton instance.
	/// </summary>
	public static UserActivityService Singleton
	{
		get { return singleton; }
	}

	#endregion

	private UserActivityService()
	{
	}

	#region IUserActivityService Members

    /// <summary>
    /// Creates a user activity record in the database using <see cref="UserActivitiesDataSet"/> according to <see cref="IUserActivityService.CreateUserActivity"/>.
    /// </summary>
	public void CreateUserActivity(Guid workflowGuid, Guid activityGuid, UserActivityType type, UserRole requiredRole, string description, DataSet activityData)
	{
		UserActivitiesDataSet dataSet = UserActivitiesHelper.GetDataSetWithReferenceData();

		UserActivitiesDataSet.UserActivitiesRow userActivity = dataSet.UserActivities.NewUserActivitiesRow();
		userActivity.ActivityGuid = activityGuid.ToString();
		userActivity.WorkflowGuid = workflowGuid.ToString();
		userActivity.ActivityTypeName = type.ToString();
		userActivity.aspnet_RolesRow = dataSet.aspnet_Roles.FindByApplicationIdLoweredRoleName(UserActivitiesHelper.ApplicationGuid, requiredRole.ToString().ToLower());
		userActivity.Description = description;
		userActivity.Complete = false;
		dataSet.UserActivities.Rows.Add(userActivity);

		using (UserActivitiesTableAdapter userActivitiesAdapter = new UserActivitiesTableAdapter())
			userActivitiesAdapter.Update(userActivity);

		ActivityDataInterface.InitialiseActivityData(workflowGuid, activityGuid, type, activityData);
	}

    /// <summary>
    /// Removes a user activity record from the database using <see cref="UserActivitiesDataSet"/> according to <see cref="IUserActivityService.CancelUserActivity"/>.
    /// </summary>
	public void CancelUserActivity(Guid activityGuid)
	{
		using (UserActivitiesTableAdapter activitiesAdapter = new UserActivitiesTableAdapter())
			activitiesAdapter.DeleteActivity(activityGuid.ToString());
	}

	#endregion

	/// <summary>
	/// Notifies the workflow of a completed UserActivity.
	/// </summary>
	/// <returns>A <see cref="Result"/> for the activity completion.</returns>
	public Result CompleteUserActivity(Guid workflowGuid, Guid activityGuid, DataSet activityData, Guid completingUser)
	{
		if (UserActivitiesHelper.UserIsAssignedToActivity(activityGuid, completingUser))
		{
			UserActivitiesHelper.Runtime.GetWorkflow(workflowGuid).EnqueueItem(
							Helper.MakeQueueName(activityGuid),
							new UserActivityCompletedEventArgs(activityData),
							null, null);

			using (UserActivitiesTableAdapter activitiesAdapter = new UserActivitiesTableAdapter())
				activitiesAdapter.CompleteActivity(activityGuid.ToString());

			// Because we configured the WorkflowRuntime with the ManualWorkflowSchedulerService replacing 
			// the DefaultWorkflowSchedulerService in Web.config, we need to manually tell a workflow instance 
			// to progress as far as it can. This allows us to control the threads that the workflows execute on, 
			// an important consideration when running workflows in a constrained threading environment, 
			// such as ASP.NET on IIS.
			// This also allows us to easily synchronize user interaction with workflow progress.
			UserActivitiesHelper.SchedulerService.RunWorkflow(workflowGuid);

			return new Result("Task complete.");
		}
		else
			return new Result(false, "Only the assigned user can complete a task.");
	}

	/// <summary>
	/// Assigns a user activity to a user.
	/// </summary>
	/// <param name="activityGuid">The activity to assign.</param>
	/// <param name="assigningUser">The user assigning the activity.</param>
	/// <param name="userToAssign">The user being assigned to the activity.</param>
	/// <param name="comment">A comment on the assignment.</param>
	/// <returns>A <see cref="Result"/> for the assignment.</returns>
	public Result AssignUserActivity(Guid activityGuid, Guid assigningUser, Guid userToAssign, string comment)
	{
		if (!UserActivitiesHelper.CanUserWorkOnActivity(activityGuid, assigningUser))
			return new Result(false, "You do not have the role required for the task, and can not assign it because of this.");
		if (!UserActivitiesHelper.CanUserWorkOnActivity(activityGuid, userToAssign))
			return new Result(false, "The user this task is being assigned to does not have the required role and can not be assigned to it.");

		using (UserActivityAssignmentsTableAdapter assignmentsAdapter = new UserActivityAssignmentsTableAdapter())
			assignmentsAdapter.Insert(activityGuid.ToString(), userToAssign, assigningUser, DateTime.Now, comment);
		return new Result("Task assigned.");
	}

	/// <summary>
	/// Assigns a required role to an activity, deleting all previous activity assignments.
	/// </summary>
	/// <param name="activityGuid">The activity.</param>
	/// <param name="roleToAssignTo">The role.</param>
	/// <returns>A <see cref="Result"/> for the assignment.</returns>
	public Result AssignUserActivityToRole(Guid activityGuid, Guid roleToAssignTo)
	{
		using (UserActivitiesTableAdapter userActivitiesAdapter = new UserActivitiesTableAdapter())
			userActivitiesAdapter.SetRole(roleToAssignTo, activityGuid.ToString());

		return new Result("Task assigned to role.");
	}

	/// <summary>
	/// Get's the user's activities from the database.
	/// </summary>
	/// <param name="userGuid">The user.</param>
	/// <returns>A typed dataset containing the user activity data and assignments.</returns>
	public UserActivitiesDataSet GetUsersActivities(Guid userGuid)
	{
		UserActivitiesDataSet dataSet = UserActivitiesHelper.GetDataSetWithReferenceData();

		using (UserActivitiesTableAdapter userAcitivitiesAdapter = new UserActivitiesTableAdapter())
			userAcitivitiesAdapter.FillByUserGuid(dataSet.UserActivities, userGuid);
        using (UserActivityAssignmentsTableAdapter userActivityAssignmentsAdapter = new UserActivityAssignmentsTableAdapter())
        {
            userActivityAssignmentsAdapter.ClearBeforeFill = false;
            foreach (UserActivitiesDataSet.UserActivitiesRow userActivity in dataSet.UserActivities.Rows)
                userActivityAssignmentsAdapter.FillByActivityGuid(dataSet.UserActivityAssignments, userActivity.ActivityGuid);
        }

		return dataSet;
	}

	/// <summary>
	/// Gets the incomplete activities for the Workflow
	/// </summary>
	/// <param name="workflowGuid">The Guid of the Workflow to get the incomplete activities</param>
	/// <returns>A typed datatable containing the activities</returns>
	public UserActivitiesDataSet.UserActivitiesDataTable GetIncompleteActivities(Guid workflowGuid)
	{
		using (UserActivitiesTableAdapter activitiesAdapter = new UserActivitiesTableAdapter())
			return activitiesAdapter.GetDataByIncomplete(workflowGuid.ToString());
	}
}
