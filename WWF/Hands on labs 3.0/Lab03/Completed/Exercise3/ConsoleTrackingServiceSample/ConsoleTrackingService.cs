//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
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

namespace ConsoleTrackingServiceSample
{
    public class ConsoleTrackingService : TrackingService
    {
        protected override TrackingProfile GetProfile(Guid workflowInstanceId)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        protected override TrackingProfile GetProfile(Type workflowType, Version profileVersionId)
        {
            return GetProfile();
        }

        protected override TrackingChannel GetTrackingChannel(TrackingParameters parameters)
        {
            return new ConsoleTrackingChannel(parameters);
        }

        protected override bool TryGetProfile(Type workflowType, out TrackingProfile profile)
        {
            profile = GetProfile();
            return true;
        }

        protected override bool TryReloadProfile(Type workflowType, Guid workflowInstanceId, out TrackingProfile profile)
        {
            profile = null;
            return false;
        }

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
            profile.ActivityTrackPoints.Add(activityTrackPoint);

            // Add a TrackPoint to cover all workflow status events
            WorkflowTrackPoint workflowTrackPoint = new WorkflowTrackPoint();
            workflowTrackPoint.MatchingLocation = new WorkflowTrackingLocation();
            foreach (TrackingWorkflowEvent workflowEvent in Enum.GetValues(typeof(TrackingWorkflowEvent)))
            {
                workflowTrackPoint.MatchingLocation.Events.Add(workflowEvent);
            }
            profile.WorkflowTrackPoints.Add(workflowTrackPoint);

            // Add a TrackPoint to cover all user track points
            UserTrackPoint userTrackPoint = new UserTrackPoint();
            UserTrackingLocation userLocation = new UserTrackingLocation();
            userLocation.ActivityType = typeof(Activity);
            userLocation.MatchDerivedActivityTypes = true;
            userLocation.ArgumentType = typeof(object);
            userLocation.MatchDerivedArgumentTypes = true;
            userTrackPoint.MatchingLocations.Add(userLocation);
            profile.UserTrackPoints.Add(userTrackPoint);

            return profile;
        }
    }
}
