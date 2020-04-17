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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Workflow.Activities;
using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Reflection;

#endregion

namespace StateMachineTracking
{
    public class ActivityEventArgs : EventArgs
    {
        private Type type;
        private string qualifiedId;

        public Type Type
        {
            get
            {
                return type;
            }
        }

        public string QualifiedId
        {
            get
            {
                return qualifiedId;
            }
        }

        public ActivityEventArgs(Type type, string qualifiedId)
        {
            this.type = type;
            this.qualifiedId = qualifiedId;
        }
    }


    //public delegate void StateEventHandler(object sender, ActivityEventArgs e);
    //public delegate void EventDrivenEventHandler(object sender, ActivityEventArgs e);
    
    public class StateMachineInstance
    {
        #region Member Variables

        private Type workflowType;
        private Guid instanceId;
        private WorkflowInstance workflowInstance;
        private string currentStateQualifiedId;
        private WorkflowRuntime WorkflowRuntime;
        private bool isRunning = false;
        private StateMachineTrackingService stateMachineTrackingService;

        #endregion

        #region Constructors

        internal StateMachineInstance(WorkflowRuntime WorkflowRuntime, Type workflowType, Guid instanceId,StateMachineTrackingService stateTrackingService)
        {
            Debug.Assert(workflowType != null);
            Debug.Assert(WorkflowRuntime != null);
            Debug.Assert(!instanceId.Equals(Guid.Empty));

            this.WorkflowRuntime = WorkflowRuntime;
            this.workflowType = workflowType;
            this.instanceId = instanceId;
            this.stateMachineTrackingService = stateTrackingService;
        }

        #endregion

        #region Properties

        public WorkflowInstance WorkflowInstance
        {
            get
            {
                CheckRunning();
                if (this.workflowInstance == null)
                {
                    WorkflowRuntime instanceService = WorkflowRuntime;
                    this.workflowInstance = instanceService.GetWorkflow(this.instanceId);
                }
                return this.workflowInstance;
            }
        }

        internal StateMachineWorkflowActivity StateMachineWorkflow
        {
            get
            {
                CheckRunning();
                StateMachineWorkflowActivity stateMachineWorkflow = (StateMachineWorkflowActivity)this.WorkflowInstance.GetWorkflowDefinition();
                return stateMachineWorkflow;
            }
        }

        public Guid InstanceId
        {
            get
            {
                return this.instanceId;
            }
        }

        internal bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                isRunning = value;
            }
        }

        public StateActivity[] GetStates()
        {
            CheckRunning();
            List<StateActivity> states = new List<StateActivity>();
            FindStates(this.StateMachineWorkflow, states);
            return states.ToArray();
        }

        public StateActivity CurrentState
        {
            get
            {
                CheckRunning();
                StateMachineWorkflowActivity stateMachineWorkflow = this.StateMachineWorkflow;
                return (StateActivity)FindActivityByQualifiedId(currentStateQualifiedId);
            }
        }

        private string initialState;

        public string InitialState
        {
            get { return initialState; }
            set { initialState = value; }
        }


        private string completedState;

        public string CompletedState
        {
            get { return completedState; }
            set { completedState = value; }
        }



        public StateActivity[] PossibleStateTransitions
        {
            get
            {
                CheckRunning();
                List<StateActivity> states = new List<StateActivity>();
                foreach (Activity a in this.CurrentState.EnabledActivities)
                {
                    if (a is EventDrivenActivity)
                    {
                        this.FindSetStates((CompositeActivity)a, states);
                    }
                }

                // Get set states from the event drivens in the super states
                CompositeActivity curactivity = this.CurrentState;
                while (curactivity != null)
                {
                    foreach (Activity b in curactivity.EnabledActivities)
                    {
                        if (b is EventDrivenActivity)
                        {
                            this.FindSetStates((CompositeActivity)b, states);
                        }
                    }
                    curactivity = curactivity.Parent;
                }

                return states.ToArray();

            }
        }

        public ReadOnlyCollection<string> MessagesAllowed
        {
            get
            {
                CheckRunning();
                List<string> messages = new List<string>();
                foreach (Activity a in this.CurrentState.EnabledActivities)
                {
                    if (a is EventDrivenActivity)
                    {
                        this.FindMessagesAllowed((CompositeActivity)a, messages);
                    }
                }

                // Get set event from the event drivens in the super states
                CompositeActivity curactivity = this.CurrentState.Parent;
                while (curactivity != null)
                {
                    foreach (Activity b in curactivity.EnabledActivities)
                    {
                        if (b is EventDrivenActivity)
                        {
                            this.FindMessagesAllowed((CompositeActivity)b, messages);
                        }
                    }
                    curactivity = curactivity.Parent;
                }

                return messages.AsReadOnly();
            }

        }
        #endregion

        #region Events

        public event EventHandler<ActivityEventArgs> StateExecuting;
        public event EventHandler<ActivityEventArgs> StateClosed;
        public event EventHandler<ActivityEventArgs> StateChanged;
        public event EventHandler<ActivityEventArgs> EventDrivenExecuting;
        //public event EventDrivenEventHandler EventDrivenExecuting;
        public event EventHandler<ActivityEventArgs> EventDrivenClosed;

        //public event EventDrivenEventHandler EventDrivenClosed;

        internal void OnStateExecuting(ActivityEventArgs e)
        {
            Debug.Assert(e != null);

            this.currentStateQualifiedId = e.QualifiedId;

            if (this.StateExecuting == null)
                return;

            for (int i = 0; i < 10; i++)
                System.Threading.Thread.Sleep(10);

            this.StateExecuting(this, e);
        }

        internal void OnStateClosed(ActivityEventArgs e)
        {
            Debug.Assert(e != null);

            if (this.StateClosed == null)
                return;

            this.StateClosed(this, e);
        }

        internal void OnStateChanged(ActivityEventArgs e)
        {
            Debug.Assert(e != null);

            if (this.StateChanged == null)
                return;

            for (int i = 0; i < 10; i++)
                System.Threading.Thread.Sleep(10);

            this.StateChanged(this, e);
        }

        internal void OnEventDrivenExecuting(ActivityEventArgs e)
        {
            Debug.Assert(e != null);

            if (this.EventDrivenExecuting == null)
                return;

            this.EventDrivenExecuting(this, e);
        }

        internal void OnEventDrivenClosed(ActivityEventArgs e)
        {
            Debug.Assert(e != null);

            if (this.EventDrivenClosed == null)
                return;

            this.EventDrivenClosed(this, e);
        }

        #endregion

        #region Public Methods

        public void StartWorkflow()
        {
            WorkflowRuntime instanceService = this.WorkflowRuntime;
            WorkflowInstance workflowInstance = instanceService.CreateWorkflow(this.workflowType, null, this.instanceId);
            workflowInstance.Start();
            this.initialState = this.StateMachineWorkflow.InitialStateName;
            this.completedState = this.StateMachineWorkflow.CompletedStateName;
            this.workflowInstance = workflowInstance;
            this.isRunning = true;
        }

        public void SetState(string stateId)
        {
            CheckRunning();
            SetStateEventArgs eventArgs = new SetStateEventArgs(stateId);
            workflowInstance.EnqueueItem(System.Workflow.Activities.StateMachineWorkflowActivity.SetStateQueueName, eventArgs, null, null);
        }
     

        public void SetState(Activity state)
        {
            CheckRunning();
            SetState(state.Name);
        }

        #endregion

        #region Helper Methods

        private void CheckRunning()
        {
            if (!isRunning)
                throw new InvalidOperationException("StateMachineInstance is not running");
        }


        private void FindStates(CompositeActivity parent, List<StateActivity> states)
        {
            foreach (Activity activity in parent.EnabledActivities)
            {
                if (activity is StateActivity)
                {
                    states.Add((StateActivity)activity);
                }
                else
                {
                    if (activity is CompositeActivity)
                    {
                        FindStates((CompositeActivity)activity, states);
                    }
                }
            }
        }

        private void FindSetStates(CompositeActivity parent, List<StateActivity> states)
        {
            foreach (Activity activity in parent.EnabledActivities)
            {
                if (activity is SetStateActivity)
                {
                    StateActivity transition = (StateActivity)this.FindActivityByQualifiedId(((SetStateActivity)activity).TargetStateName);
                    if (transition != null)
                        states.Add(transition);
                }
                else
                {
                    if (activity is CompositeActivity)
                    {
                        FindSetStates((CompositeActivity)activity, states);
                    }
                }
            }
        }

        private void FindMessagesAllowed(CompositeActivity parent, List<string> messages)
        {
            foreach (Activity activity in parent.EnabledActivities)
            {
                if (activity is HandleExternalEventActivity)
                {
                    string message = ((HandleExternalEventActivity)activity).EventName;
                    if (message != null)
                        messages.Add(message);
                }
                else
                {
                    if (activity is CompositeActivity)
                    {
                        FindMessagesAllowed((CompositeActivity)activity, messages);
                    }
                }
            }
        }

        internal Activity FindActivity(string id)
        {
            return StateMachineInstance.FindActivity(this.StateMachineWorkflow, id);
        }

        internal static Activity FindActivity(CompositeActivity parent, string id)
        {
            foreach (Activity activity in parent.EnabledActivities)
            {
                if (activity.Name.Equals(id))
                    return activity;

                if (activity is CompositeActivity)
                {
                    Activity found = FindActivity((CompositeActivity)activity, id);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }

        internal Activity FindActivityByQualifiedId(string qualifiedId)
        {
            return StateMachineInstance.FindActivityByQualifiedId(this.StateMachineWorkflow, qualifiedId);
        }

        internal static Activity FindActivityByQualifiedId(CompositeActivity parent, string qualifiedId)
        {
            foreach (Activity activity in parent.EnabledActivities)
            {
                if (activity.QualifiedName.Equals(qualifiedId))
                    return activity;

                if (activity is CompositeActivity)
                {
                    Activity found = FindActivityByQualifiedId((CompositeActivity)activity, qualifiedId);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }

        #endregion
    }
}
