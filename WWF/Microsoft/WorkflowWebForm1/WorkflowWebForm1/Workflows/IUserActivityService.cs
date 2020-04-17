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
using System.Workflow.Activities;
using System.Data;
using System.Workflow.ComponentModel;

namespace Workflows
{
	/// <summary>
	/// The types of activities available to workflows - these must match up to the names of UserActivityTypes from the database.
	/// </summary>
	public enum UserActivityType { EnterApprovalRequest, ManagerApproval, EnterResolution }

	/// <summary>
	/// The user roles available to workflows - these must match up to the names of roles from the database for this application.
	/// </summary>
	public enum UserRole { Administrator, Manager, RequestApproval, EnterResolution }

	/// <summary>
	/// This enables communication between workflows and user tasks via <see cref="UserActivity"/>.
	/// </summary>
	public interface IUserActivityService
	{
		/// <summary>
		/// Creates a user activity.
		/// </summary>
		/// <param name="workflowGuid">The workflow the activity is created for.</param>
		/// <param name="activityGuid">A unique identifier for the activity.</param>
		/// <param name="type">The type of the activity.</param>
		/// <param name="requiredRole">The role a user must have to work on the activity.</param>
		/// <param name="description">Describes the activity.</param>
		/// <param name="activityData">Any data that is to be initialised with the activity.</param>
		void CreateUserActivity(Guid workflowGuid, Guid activityGuid, UserActivityType type, UserRole requiredRole, string description, DataSet activityData);

		/// <summary>
		/// Cancels an activity.
		/// </summary>
		/// <param name="activityGuid">The activity to cancel.</param>
		void CancelUserActivity(Guid activityGuid);
	}

	/// <summary>
	/// Arguments that are passed when a user activity is completed.
	/// </summary>
	[Serializable]
	public class UserActivityCompletedEventArgs : EventArgs
	{
		private DataSet activityData;

		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		/// <param name="activityData">The data the user has worked on.</param>
		public UserActivityCompletedEventArgs(DataSet activityData)
		{
			this.activityData = activityData;
		}

		/// <summary>
		/// The data the user has worked on.
		/// </summary>
		public DataSet ActivityData
		{
			get { return activityData; }
		}
	}
}
