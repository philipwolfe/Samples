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
using Workflows;
using System.Workflow.Activities;

namespace Workflows.Tracking
{
    /// <summary>
    /// An implementation of <see cref="TrackingService"/> tailored specifically to track <see cref="Workflows.UserActivity"/>.
    /// </summary>
    class UserActivityTrackingService : TrackingService
    {
        private TrackingProfile profile;

        public UserActivityTrackingService()
        {
            // Create a Tracking Profile
            profile = new TrackingProfile();
            profile.Version = new Version(1, 0);

            // Add a trackpoint 
            UserTrackPoint userActivitySubscriptionPoints = new UserTrackPoint();

            // track sequential execution of user activities.
            userActivitySubscriptionPoints.MatchingLocations.Add(new UserTrackingLocation(typeof(UserActivity), typeof(UserActivity)));

            // track subscription points from within a listen activity.
            userActivitySubscriptionPoints.MatchingLocations.Add(new UserTrackingLocation(typeof(UserActivity), typeof(ListenActivity)));

            profile.UserTrackPoints.Add(userActivitySubscriptionPoints);
        }

        #region TrackingService Members

        protected override TrackingProfile GetProfile(Type workflowType, Version profileVersionId)
        {
            return this.profile;
        }

        protected override bool TryGetProfile(Type workflowType, out TrackingProfile profile)
        {
            profile = this.profile;
            return true;
        }

        protected override TrackingChannel GetTrackingChannel(TrackingParameters parameters)
        {
            return new UserActivityTrackingChannel(parameters);
        }

        #region Unimplemented Members

        protected override TrackingProfile GetProfile(Guid workflowInstanceId)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        protected override bool TryReloadProfile(Type workflowType, Guid workflowInstanceId, out TrackingProfile profile)
        {
            profile = null;
            return false;
        }

        #endregion

        #endregion
    }
}