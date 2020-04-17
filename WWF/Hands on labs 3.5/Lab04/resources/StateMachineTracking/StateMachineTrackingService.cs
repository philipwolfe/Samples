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

#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Runtime;
using System.Reflection;
using System.Workflow.Runtime.Tracking;

#endregion

namespace StateMachineTracking
{
    public class StateMachineTrackingService : TrackingService
    {
        private class TrackingData
        {
            private StateMachineInstance stateMachineInstance;
            private TrackingRecord trackingRecord;
            public TrackingData(StateMachineInstance stateMachineInstance,
                TrackingRecord trackingRecord)
            {
                this.stateMachineInstance = stateMachineInstance;
                this.trackingRecord = trackingRecord;
            }
            public StateMachineInstance StateMachineInstance
            {
                get
                {
                    return this.stateMachineInstance;
                }
            }
            public TrackingRecord TrackingRecord
            {
                get
                {
                    return this.trackingRecord;
                }
            }
        }

        #region Member Variables

        private Dictionary<Guid, StateMachineInstance> trackedInstances = new Dictionary<Guid, StateMachineInstance>();
        private WorkflowRuntime container = null;

        #endregion

        #region Constructors

        public StateMachineTrackingService(WorkflowRuntime container)
        {
            this.container = container;
            WorkflowRuntime instanceService = this.container;
            instanceService.WorkflowCreated += new EventHandler<WorkflowEventArgs>(WorkflowCreated);
            instanceService.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(WorkflowCompleted);
            instanceService.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(WorkflowTerminated);

            this.container.AddService(this);
        }

        #endregion

        #region StartWorkflow



        public StateMachineInstance RegisterInstance(Type workflowType, Guid instanceId)
        {
            StateMachineInstance stateMachine = new StateMachineInstance(this.container, workflowType, instanceId,this);
            lock (this.trackedInstances)
            {
                this.trackedInstances[instanceId] = stateMachine;
            }
            return stateMachine;
        }

        public void UnregisterInstance(Guid instanceId)
        {
            if (this.trackedInstances.ContainsKey(instanceId))
            {
                lock (this.trackedInstances)
                {
                    this.trackedInstances.Remove(instanceId);
                }
            }
        }

        #endregion

        #region TrackingService implementation

        protected override TrackingChannel GetTrackingChannel(TrackingParameters parameters)
        {
            return new StateMachineTrackingChannel(parameters, this);
        }

        protected override TrackingProfile GetProfile(Type scheduleType, Version profileVersionId)
        {
            TrackingProfile profile = new TrackingProfile();
            profile.Version = new Version("1.0");

            ActivityTrackPoint atp = new ActivityTrackPoint();
            ActivityTrackingLocation location = new ActivityTrackingLocation(typeof(Activity));
            location.MatchDerivedTypes = true;
            foreach (ActivityExecutionStatus s in Enum.GetValues(typeof(ActivityExecutionStatus)))
            {
                location.ExecutionStatusEvents.Add(s);
            }

            atp.MatchingLocations.Add(location);

            profile.ActivityTrackPoints.Add(atp);

            return profile;
        }

        protected override TrackingProfile GetProfile(Guid scheduleInstanceId)
        {
            //
            // Does not support reloading/instance profiles
            return null;
        }

        protected override bool TryGetProfile(Type workflowType, out TrackingProfile profile)
        {
            profile = GetProfile(workflowType, new Version("1.0"));
            return true;
        }

        protected override bool TryReloadProfile(Type workflowType, Guid workflowInstanceId, out TrackingProfile profile)
        {
            // Does not support reloading/instance profiles
            profile = null;
            return false;
        }

        public virtual void Track(Guid instanceId, System.Collections.ICollection modelChanges, DateTime changeDateTime)
        {
            Console.WriteLine("Dynamic update is applied");
        }

        public virtual void Track(Guid instanceId, TrackingRecord record)
        {
            if (!this.trackedInstances.ContainsKey(instanceId))
                return;
            StateMachineInstance instance = this.trackedInstances[instanceId];

            ActivityTrackingRecord act = record as ActivityTrackingRecord;

            if (null == act)
                return;

            switch (act.ExecutionStatus)
            {
                case ActivityExecutionStatus.Closed:
                    TrackClosed(instance, act);
                    break;
                case ActivityExecutionStatus.Executing:
                    TrackExecuting(instance, act);
                    break;
            }
        }

        private void TrackClosed(StateMachineInstance instance, ActivityTrackingRecord record)
        {
            TrackingData trackingData = new TrackingData(instance, record);
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(TrackClosed), trackingData);
        }

        private void TrackClosed(object state)
        {
            Debug.Assert(state != null);
            TrackingData trackingData = (TrackingData)state;
            StateMachineInstance instance = trackingData.StateMachineInstance;
            ActivityTrackingRecord record = trackingData.TrackingRecord as ActivityTrackingRecord;

            if (null == record)
                return;

            if (record.ActivityType.Equals(typeof(StateActivity)))
            {
                instance.OnStateClosed(new ActivityEventArgs(record.ActivityType, record.QualifiedName));
            }
            else if (record.ActivityType.Equals(typeof(EventDrivenActivity)))
            {
                instance.OnEventDrivenClosed(new ActivityEventArgs(record.ActivityType, record.QualifiedName));
            }
        }

        private void TrackExecuting(StateMachineInstance instance, ActivityTrackingRecord record)
        {
            TrackingData trackingData = new TrackingData(instance, record);
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(TrackExecuting), trackingData);
        }

        private void TrackExecuting(object state)
        {
            Debug.Assert(state != null);
            TrackingData trackingData = (TrackingData)state;
            StateMachineInstance instance = trackingData.StateMachineInstance;
            ActivityTrackingRecord record = trackingData.TrackingRecord as ActivityTrackingRecord;

            if (null == record)
                return;


            if (record.ActivityType.Equals(typeof(StateActivity)))
            {
                instance.OnStateExecuting(new ActivityEventArgs(record.ActivityType, record.QualifiedName));
                instance.OnStateChanged(new ActivityEventArgs(record.ActivityType, record.QualifiedName));
            }
            else if (record.ActivityType.Equals(typeof(EventDrivenActivity)))
            {
                instance.OnEventDrivenExecuting(new ActivityEventArgs(record.ActivityType, record.QualifiedName));
            }
        }


        #endregion


        #region WorkflowRuntime Event Handlers

        void WorkflowCreated(object sender, WorkflowEventArgs instance)
        {
            if (trackedInstances.ContainsKey(instance.WorkflowInstance.InstanceId))
            {
                StateMachineInstance stateMachineInstance = trackedInstances[instance.WorkflowInstance.InstanceId];
                stateMachineInstance.IsRunning = true;
            }
        }

        void WorkflowCompleted(object sender, WorkflowEventArgs instance)
        {
            UnregisterInstance(instance.WorkflowInstance.InstanceId);
        }

        void WorkflowTerminated(object sender, WorkflowTerminatedEventArgs instance)
        {
            UnregisterInstance(instance.WorkflowInstance.InstanceId);
        }

        #endregion

      }
      #region StateMachineTrackingChannel
      /// <summary>
      /// 
      /// </summary>
      public class StateMachineTrackingChannel : TrackingChannel
      {
          private StateMachineTrackingService _service = null;
          private TrackingParameters _parameters = null;

          private StateMachineTrackingChannel()
          {
          }

          /// <summary>
          /// 
          /// </summary>
          /// <param name="parameters"></param>
          /// <param name="service"></param>
          public StateMachineTrackingChannel(TrackingParameters parameters, StateMachineTrackingService service)
          {
              _service = service;
              _parameters = parameters;
          }

          /// <summary>
          /// 
          /// </summary>
          /// <param name="record"></param>
          protected override void Send(TrackingRecord record)
          {
              if (record is ActivityTrackingRecord)
              {
                  _service.Track(_parameters.InstanceId, record);
              }
              else if (record is WorkflowTrackingRecord)
              {
                  WorkflowTrackingRecord inst = (WorkflowTrackingRecord)record;
                  if (TrackingWorkflowEvent.Changed != inst.TrackingWorkflowEvent)
                      return;

                  ICollection args = (ICollection)inst.EventArgs;
                  _service.Track(_parameters.InstanceId, args, inst.EventDateTime);
              }

          }
          protected override void InstanceCompletedOrTerminated()
          {
              return;
          }
      }

      #endregion StateMachineTrackingChannel

}
