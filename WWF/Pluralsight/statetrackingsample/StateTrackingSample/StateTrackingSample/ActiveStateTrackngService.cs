using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;

namespace StateTrackingSample
{
	public class ActiveStateTrackngService:TrackingService
	{
        protected override TrackingProfile GetProfile(Guid workflowInstanceId)
        {
            return GetDefaultProfile();
        }

        protected override TrackingProfile GetProfile(Type workflowType, Version profileVersionId)
        {
            return GetDefaultProfile();
        }

        protected override TrackingChannel GetTrackingChannel(TrackingParameters parameters)
        {
            return new ActiveStateTrackingChannel(parameters);
        }

        protected override bool TryGetProfile(Type workflowType, out TrackingProfile profile)
        {
            profile = GetDefaultProfile();
            return true;
        }

        protected override bool TryReloadProfile(Type workflowType, Guid workflowInstanceId, out TrackingProfile profile)
        {
            profile = null;
            return false;
        }

        private TrackingProfile GetDefaultProfile()
        {
            TrackingProfile profile = new TrackingProfile();
            profile.Version = new Version(1, 0);
            

            //Add tracking point for state activity executing
            ActivityTrackPoint statePoint = new ActivityTrackPoint();
            ActivityTrackingLocation location = new ActivityTrackingLocation(typeof(StateActivity), new ActivityExecutionStatus[] { ActivityExecutionStatus.Executing });
            statePoint.MatchingLocations.Add(location);
            profile.ActivityTrackPoints.Add(statePoint);

            return profile;

        }
    }

    public class ActiveStateTrackingChannel : TrackingChannel
    {

        private TrackingParameters param = null;

        public ActiveStateTrackingChannel(TrackingParameters parameters)
        {
            param = parameters;
        }

        protected override void InstanceCompletedOrTerminated()
        {
            return;
        }

        protected override void Send(TrackingRecord record)
        {
            
            //get the tracking record and write out the name of the state.  
            ActivityTrackingRecord r = record as ActivityTrackingRecord;

            if(r != null)
                Console.WriteLine("*** Current State: {0} ***", r.QualifiedName);
        }
    }
}
