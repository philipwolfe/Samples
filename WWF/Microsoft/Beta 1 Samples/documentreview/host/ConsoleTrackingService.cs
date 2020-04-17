//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
namespace Microsoft.Samples.Workflow.Applications.DocumentReview
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Workflow.ComponentModel;
    using System.Workflow.Runtime;
    using System.Workflow.Runtime.Hosting;

    public class ConsoleTrackingService : TrackingService
    {
        public ConsoleTrackingService()
        {
        }

        public override TrackingProfile GetProfile(Type workflowType)
        {
            return GetDefaultProfile();
        }

        public override TrackingProfile GetProfile(Type workflowType, Version profileVersionId)
        {
            return GetDefaultProfile();
        }

        public override TrackingProfile GetProfile(Guid workflowInstanceId)
        {
            //
            // Does not support reloading/instance profiles
            return null;
        }

        public override TrackingChannel GetTrackingChannel(TrackingParameters parameters)
        {
            return new ConsoleTrackingChannel();
        }

        public override bool ReloadProfile(Type workflowType, Guid workflowInstanceId, out TrackingProfile profile)
        {
            //
            // Does not support reloading/instance profiles
            profile = null;
            return false;
        }

        private static TrackingProfile GetDefaultProfile()
        {
            // Create TrackingProfile, to get notified of all 
            // activity status change events

            TrackingProfile profile = new TrackingProfile();
            profile.Version = new Version("3.0.0");

            ActivityTrackPoint atp = new ActivityTrackPoint();
            ActivityLocation location = new ActivityLocation(typeof(Activity));
            location.MatchDerivedTypes = true;
            foreach (Status s in Enum.GetValues(typeof(Status)))
            {
                location.Events.Add(s);
            }

            atp.MatchingLocations.Add(location);

            profile.ActivityTrackPoints.Add(atp);

            return profile;
        }
    }

    public class ConsoleTrackingChannel : TrackingChannel
    {
        public ConsoleTrackingChannel()
        {
        }

        public override void Send(TrackingRecord record)
        {
            ActivityTrackingRecord act = record as ActivityTrackingRecord;

            if (act != null)
            {
                Console.WriteLine("Activity {0} - {1}", act.QualifiedId, act.Status);
            }
        }

        public override void InstanceCompletedOrTerminated()
        {
        }
    }
}
