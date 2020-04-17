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
using UserActivitiesDataSetTableAdapters;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Runtime.Hosting;
using System.Configuration;
using System.Web.Security;
using Workflows;
using System.Workflow.Runtime.Tracking;
using System.Data.SqlClient;
using System.Collections.Generic;
using Workflows.Tracking;

public static class UserActivitiesHelper
{
    private static WorkflowRuntime runtime;

    /// <summary>
    /// The <see cref="WorkflowRuntime"/>.
    /// </summary>
    public static WorkflowRuntime Runtime
    {
        get { return runtime; }
    }

    /// <summary>
    /// The workflow scheduler service for the runtime that is used to run workflow instances until they idle or complete.
    /// </summary>
    public static ManualWorkflowSchedulerService SchedulerService
    {
        get { return runtime.GetService<ManualWorkflowSchedulerService>(); }
    }

    private static Guid applicationGuid;

    /// <summary>
    /// The ASP.NET application identifier.
    /// </summary>
    public static Guid ApplicationGuid
    {
        get { return applicationGuid; }
    }

    /// <summary>
    /// Initialises the workflow runtime and retrieves the application identifier.
    /// </summary>
    static UserActivitiesHelper()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ApprovalsConnectionString"].ConnectionString;

        /* Clear the database data each time the service starts. */
        ClearDataBase(connectionString);

        runtime = new WorkflowRuntime();
        Helper.Runtime = runtime;
        Helper.UserActivityService = UserActivityService.Singleton;

        runtime.AddService(new UserActivityTrackingService());
        runtime.AddService(new SqlWorkflowPersistenceService(connectionString));
        runtime.AddService(new SharedConnectionWorkflowCommitWorkBatchService(connectionString));
        runtime.AddService(new ManualWorkflowSchedulerService(true));

        runtime.StartRuntime();


        using (ApplicationGuidAdapter applicationGuidAdapter = new ApplicationGuidAdapter())
            applicationGuid = (Guid)applicationGuidAdapter.GetApplicationGuid(Membership.ApplicationName);
    }

    private static void ClearDataBase(string connectionString)
    {
        SqlCommand clearDB = new SqlCommand("AllClearDatabase", new SqlConnection(connectionString));
        clearDB.CommandType = CommandType.StoredProcedure;
        clearDB.Connection.Open();
        clearDB.ExecuteNonQuery();
        clearDB.Connection.Close();
    }

    /// <summary>
    /// Creates a <see cref="UserActivitiesDataSet"/> and fills it with roles, users, users in roles and activity types.
    /// </summary>
    /// <returns>a new filled dataset.</returns>
    public static UserActivitiesDataSet GetDataSetWithReferenceData()
    {
        UserActivitiesDataSet dataSet = new UserActivitiesDataSet();

        using (aspnet_RolesTableAdapter rolesAdapter = new aspnet_RolesTableAdapter())
        using (aspnet_UsersTableAdapter usersAdapter = new aspnet_UsersTableAdapter())
        using (aspnet_UsersInRolesTableAdapter usersInRolesAdapter = new aspnet_UsersInRolesTableAdapter())
        using (UserActivityTypesTableAdapter activityTypesAdapter = new UserActivityTypesTableAdapter())
        {
            rolesAdapter.Fill(dataSet.aspnet_Roles);
            usersAdapter.Fill(dataSet.aspnet_Users);
            usersInRolesAdapter.Fill(dataSet.aspnet_UsersInRoles);
            activityTypesAdapter.Fill(dataSet.UserActivityTypes);
        }

        return dataSet;
    }

    /// <summary>
    /// Determines whether a user has the role necessary to work on an activity.
    /// </summary>
    /// <param name="activityGuid">The activity.</param>
    /// <param name="userGuid">The user.</param>
    /// <returns>true if the user has the role required by the activity.</returns>
    public static bool CanUserWorkOnActivity(Guid activityGuid, Guid userGuid)
    {
        using (UserActivitiesTableAdapter activitiesAdapter = new UserActivitiesTableAdapter())
            return (int)activitiesAdapter.CanUserWorkOnActivity(activityGuid.ToString(), userGuid) > 0;
    }

    /// <summary>
    /// Determines whether a user is currently assigned to an actvity.
    /// </summary>
    /// <param name="activityGuid">The activity.</param>
    /// <param name="userGuid">The user.</param>
    /// <returns>true if the user is assigned to the activity.</returns>
    public static bool UserIsAssignedToActivity(Guid activityGuid, Guid userGuid)
    {
        UserActivitiesDataSet.UserActivityAssignmentsDataTable assignments;
        using (UserActivityAssignmentsTableAdapter assignmentsAdapter = new UserActivityAssignmentsTableAdapter())
            assignments = new UserActivityAssignmentsTableAdapter().GetDataByActivityGuid(activityGuid.ToString());

        DataRow[] orderedAssignments = assignments.Select(string.Empty, assignments.DateAssignedColumn.ColumnName + " DESC");

        return orderedAssignments.Length > 0 && userGuid == (Guid)orderedAssignments[0][assignments.AssignedUserColumn];
    }

    /// <summary>
    /// Determines is an activity is incomplete.
    /// </summary>
    /// <param name="activityGuid">The activity.</param>
    /// <returns>true if the activity is not complete.</returns>
    public static bool ActivityIsIncomplete(Guid activityGuid)
    {
        using (UserActivitiesTableAdapter activitiesAdapter = new UserActivitiesTableAdapter())
            return (int)activitiesAdapter.IsActivityIncomplete(activityGuid.ToString()) > 0;
    }
}
