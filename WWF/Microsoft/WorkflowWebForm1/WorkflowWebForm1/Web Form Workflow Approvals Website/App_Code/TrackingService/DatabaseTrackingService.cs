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
using System.Collections.Generic;

public class DatabaseTrackingService : TrackingService
{
	/// <summary>
	/// stores a list of properties of the workflow that we track.
	/// </summary>
	static List<string> trackedProperties;

	/// <summary>
	/// Initializes a new instance of the <see cref="DatabaseTrackingService"/> class.
	/// </summary>
	/// <param name="propertiesToTrack">The properties to track.</param>
	public DatabaseTrackingService(List<string> propertiesToTrack)
	{
		trackedProperties = propertiesToTrack;
	}

	/// <summary>
	/// Must be overridden in the derived class, and when implemented, returns the tracking profile for the specified workflow instance.
	/// </summary>
	/// <param name="workflowInstanceId">The <see cref="T:System.Guid"></see> of the workflow instance.</param>
	/// <returns>
	/// A <see cref="T:System.Workflow.Runtime.Tracking.TrackingProfile"></see>.
	/// </returns>
	protected override TrackingProfile GetProfile(Guid workflowInstanceId)
	{
		throw new NotImplementedException("The method or operation is not implemented.");
	}

	/// <summary>
	/// Must be overridden in the derived class, and when implemented, returns the tracking profile, qualified by version, for the specified workflow <see cref="T:System.Type"></see>.
	/// </summary>
	/// <param name="workflowType">The <see cref="T:System.Type"></see> of the workflow.</param>
	/// <param name="profileVersionId">The <see cref="T:System.Version"></see> of the tracking profile.</param>
	/// <returns>
	/// A <see cref="T:System.Workflow.Runtime.Tracking.TrackingProfile"></see>.
	/// </returns>
	protected override TrackingProfile GetProfile(Type workflowType, Version profileVersionId)
	{
		return GetProfile();
	}

	/// <summary>
	/// Must be overridden in the derived class, and when implemented, returns the channel that the runtime tracking infrastructure uses to send tracking records to the tracking service.
	/// </summary>
	/// <param name="parameters">The <see cref="T:System.Workflow.Runtime.Tracking.TrackingParameters"></see> associated with the workflow instance.</param>
	/// <returns>
	/// The <see cref="T:System.Workflow.Runtime.Tracking.TrackingChannel"></see> that is used to send tracking records to the tracking service.
	/// </returns>
	protected override TrackingChannel GetTrackingChannel(TrackingParameters parameters)
	{
		return new DatabaseTrackingChannel(parameters);
	}

	/// <summary>
	/// Must be overridden in the derived class, and when implemented, retrieves the tracking profile for the specified workflow type if one is available.
	/// </summary>
	/// <param name="workflowType">The <see cref="T:System.Type"></see> of the workflow for which to get the tracking profile.</param>
	/// <param name="profile">When this method returns, contains the <see cref="T:System.Workflow.Runtime.Tracking.TrackingProfile"></see> to load. This parameter is passed un-initialized.</param>
	/// <returns>
	/// true if a <see cref="T:System.Workflow.Runtime.Tracking.TrackingProfile"></see> for the specified workflow <see cref="T:System.Type"></see> is available; otherwise, false. If true, the <see cref="T:System.Workflow.Runtime.Tracking.TrackingProfile"></see> is returned in profile.
	/// </returns>
	protected override bool TryGetProfile(Type workflowType, out TrackingProfile profile)
	{
		profile = GetProfile();
		return true;
	}

	/// <summary>
	/// Must be overridden in the derived class, and when implemented, retrieves a new tracking profile for the specified workflow instance if the tracking profile has changed since it was last loaded.
	/// </summary>
	/// <param name="workflowType">The <see cref="T:System.Type"></see> of the workflow instance.</param>
	/// <param name="workflowInstanceId">The <see cref="T:System.Guid"></see> of the workflow instance.</param>
	/// <param name="profile">When this method returns, contains the <see cref="T:System.Workflow.Runtime.Tracking.TrackingProfile"></see> to load. This parameter is passed un-initialized.</param>
	/// <returns>
	/// true if a new <see cref="T:System.Workflow.Runtime.Tracking.TrackingProfile"></see> should be loaded; otherwise, false. If true, the <see cref="T:System.Workflow.Runtime.Tracking.TrackingProfile"></see> is returned in profile.
	/// </returns>
	protected override bool TryReloadProfile(Type workflowType, Guid workflowInstanceId, out TrackingProfile profile)
	{
		profile = null;
		return false;
	}

	/// <summary>
	/// Returns a TrackingProfile containg all of the necessary infomation telling the TrackingService exactly what to track.
	/// </summary>
	/// <returns></returns>
	private static TrackingProfile GetProfile()
	{
		// Create a Tracking Profile
		TrackingProfile profile = new TrackingProfile();
		profile.Version = new Version("3.0.0");

		// Add a TrackPoint to cover all activity status events
		ActivityTrackPoint activityTrackPoint = new ActivityTrackPoint();
		ActivityTrackingLocation activityLocation = new ActivityTrackingLocation(typeof(Activity));
		activityLocation.MatchDerivedTypes = true;
		foreach (ActivityExecutionStatus status in Enum.GetValues(typeof(ActivityExecutionStatus)))
		{
			activityLocation.ExecutionStatusEvents.Add(status);
		}
		activityTrackPoint.MatchingLocations.Add(activityLocation);


		// Add a TrackPoint to cover all workflow status events
		WorkflowTrackPoint workflowTrackPoint = new WorkflowTrackPoint();
		workflowTrackPoint.MatchingLocation = new WorkflowTrackingLocation();
		foreach (TrackingWorkflowEvent workflowEvent in Enum.GetValues(typeof(TrackingWorkflowEvent)))
		{
			workflowTrackPoint.MatchingLocation.Events.Add(workflowEvent);
		}

		// Add a TrackPoint to cover all user track points
		UserTrackPoint userTrackPoint = new UserTrackPoint();
		UserTrackingLocation userLocation = new UserTrackingLocation();
		userLocation.ActivityType = typeof(Activity);
		userLocation.MatchDerivedActivityTypes = true;
		userLocation.ArgumentType = typeof(object);
		userLocation.MatchDerivedArgumentTypes = true;
		userTrackPoint.MatchingLocations.Add(userLocation);

		// Track our custom data (trackedProperties)
		foreach (string trackedProperty in trackedProperties)
		{
			WorkflowDataTrackingExtract workflowDataExtraction = new WorkflowDataTrackingExtract(trackedProperty);

			activityTrackPoint.Extracts.Add(workflowDataExtraction);
			//workflowTrackPoint.Extracts.Add(workflowDataExtraction);
			userTrackPoint.Extracts.Add(workflowDataExtraction);
		}

		profile.ActivityTrackPoints.Add(activityTrackPoint);
		profile.WorkflowTrackPoints.Add(workflowTrackPoint);
		profile.UserTrackPoints.Add(userTrackPoint);

		return profile;
	}
}
