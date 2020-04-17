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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Data;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Workflows
{
	/// <summary>
	/// A custom designer theme for <see cref="UserActivity"/>.
	/// </summary>
	internal sealed class UserActivityDesignerTheme : ActivityDesignerTheme
	{
		public UserActivityDesignerTheme(WorkflowTheme theme)
			: base(theme)
		{
			this.BorderColor = Color.DarkSlateBlue;
			this.BorderStyle = DashStyle.Solid;
			this.BackColorStart = Color.AliceBlue;
			this.BackColorEnd = Color.CadetBlue;
			this.BackgroundStyle = LinearGradientMode.ForwardDiagonal;
		}
	}

	/// <summary>
	/// A custom designer for <see cref="UserActivity"/>.
	/// </summary>
	[ActivityDesignerThemeAttribute(typeof(UserActivityDesignerTheme))]
	public class UserActivityDesigner : ActivityDesigner
	{
	}

	[Designer(typeof(UserActivityDesigner), typeof(IDesigner))]
	public partial class UserActivity : Activity, IEventActivity, IActivityEventListener<QueueEventArgs>
	{
        public enum Status 
        { 
            /// <summary>
            /// Waiting for input from the workflow queue.
            /// </summary>
            Waiting, 

            /// <summary>
            /// Has successfully received input from the workflow queue.
            /// </summary>
            Completed, 

            /// <summary>
            /// Has unsubscribed from the workflow queue without receiving input.
            /// </summary>
            Cancelled 
        }

        public UserActivity()
		{
			InitializeComponent();

			queueName = Helper.MakeQueueName(this.ActivityGuid);
        }

		#region IEventActivity Members

		private string queueName;

        /// <summary>
        /// The name of the queue that a parent activity should create to support this <see cref="IEventActivity"/>.
        /// This class also uses this queue name when it is executed normally too.
        /// </summary>
		public IComparable QueueName
		{
			get { return queueName; }
		}

        /// <summary>
        /// This is called when the activity is a child of an <see cref="EventDrivenActivity"/> and the activity is not actually executing itself, 
        /// the parent of the event driven activity is - e.g. a <see cref="ListenActivity"/>.
        /// </summary>
        /// <param name="parentContext">The execution context of the parent activity that is executing.</param>
        /// <param name="parentEventHandler">The handler that the executing parent activity supplies to determine when a child 
        /// <see cref="IEventActivity"/> receives an event.</param>
		public void Subscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
		{
			ChangeToSubscribedState(parentContext, parentEventHandler);
		}

        /// <summary>
        /// This is called when a parent activity wants the child to remove it's event handler from the appropriate queue.
        /// </summary>
        /// <param name="parentContext">The execution context of the parent activity that is executing.</param>
        /// <param name="parentEventHandler">The handler that the executing parent activity supplies to determine when a child 
        /// <see cref="IEventActivity"/> receives an event.</param>
        public void Unsubscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
		{
			ChangeToUnsubscribedState(parentContext, parentEventHandler);
		}

		#endregion

		#region Activity Overrides

        /// <summary>
        /// For this activity, this method serves two purposes depending on whether the activity is executed sequentially, 
        /// or as a child of an event driven activity.
        /// For sequential execution, this simply creates the queue, subscribes to it, and tells the workflow runtime that it is in the process of executing.
        /// When this activity is a child of an event driven activity, the queue will already have been created, and will have received input before this
        /// activity is executed. In this case this method handles the input.
        /// </summary>
        /// <param name="context">The execution context for this activity.</param>
        /// <returns>Closed if there is input, executing otherwise.</returns>
		protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
		{
            if (TryToComplete(context) == Status.Completed)
            {
                TrackThis(context);
                return ActivityExecutionStatus.Closed;
            }

			this.ChangeToSubscribedState(context, this);
			return ActivityExecutionStatus.Executing;
		}

        /// <summary>
        /// This is called when an instance of this activity is being executed sequentially and is cancelled.
        /// It unsubscribes and deletes the queue, checking for input on the way through.
        /// </summary>
        /// <param name="context">The execution context for this activity.</param>
        /// <returns>Closed.</returns>
        protected override ActivityExecutionStatus Cancel(ActivityExecutionContext context)
		{
            Close(context, false);

			return ActivityExecutionStatus.Closed;
		}

		#endregion
        
        #region IActivityEventListener<UserActivityCompletedEventArgs> Members

        /// <summary>
        /// When executing in a normal sequence, the queue event is handled by this method, which checks that the 
        /// input has been received and closes the activity if it has.
        /// </summary>
        /// <param name="sender">Usually an <see cref="ActivityExecutionContext"/>.</param>
        /// <param name="e">The arguments for the queue event.</param>
        public void OnEvent(object sender, QueueEventArgs e)
		{
			ActivityExecutionContext context = sender as ActivityExecutionContext;

            if (context == null || this.ExecutionStatus != ActivityExecutionStatus.Executing)
                return;

            else if (TryToComplete(context) == Status.Completed)
                Close(context, true);
        }

        #endregion

        /// <summary>
        /// Changes this activity to be subscribed, notifying the UserActivityService that a new user activity has been created.
        /// This gets the existing queue or creates a new one for this activity and registers the appropriate listener.
        /// </summary>
        /// <param name="context">The execution context within which the state change occurs.</param>
        /// <param name="listener">The delegate that will handle events from the queue.</param>
        private void ChangeToSubscribedState(ActivityExecutionContext context, IActivityEventListener<QueueEventArgs> listener)
        {
            WorkflowQueue queue = GetOrCreateQueue(context);

            queue.RegisterForQueueItemAvailable(listener);

            Helper.UserActivityService.CreateUserActivity(WorkflowGuid, ActivityGuid, ActivityType, RequiredRole, Description, DataSet);

            currentStatus = Status.Waiting;
            TrackThis(context);
        }

        private WorkflowQueue GetOrCreateQueue(ActivityExecutionContext context)
        {
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (qService.Exists(this.QueueName))
                return qService.GetWorkflowQueue(this.QueueName);
            else
                return qService.CreateWorkflowQueue(this.QueueName, true);
        }

        private void Close(ActivityExecutionContext context, bool closeActivity)
        {
            ChangeToUnsubscribedState(context, this);
            EnsureQueueDoesNotExist(context);

            TrackThis(context);

            if (closeActivity)
                context.CloseActivity();
        }

        /// <summary>
        /// Changes to the unsubscribed state, which may involve unregistering a listener from the queue and detecting and recording
        /// whether the usubscription happened before input was received, meaning the activity has been cancelled.
        /// </summary>
        /// <param name="context">The execution context within which the state change occurs.</param>
        /// <param name="listener">The delegate to remove as a handler of events from the queue.</param>
        private void ChangeToUnsubscribedState(ActivityExecutionContext context, IActivityEventListener<QueueEventArgs> listener)
        {
            if (TryToComplete(context) != Status.Completed)
                RecordCancellation(context);

            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (qService.Exists(this.QueueName))
            {
                WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);
                queue.UnregisterForQueueItemAvailable(listener);
            }
        }

        private void RecordCancellation(ActivityExecutionContext context)
        {
            Helper.UserActivityService.CancelUserActivity(ActivityGuid);
            this.currentStatus = Status.Cancelled;
            TrackThis(context);
        }

        private void EnsureQueueDoesNotExist(ActivityExecutionContext context)
		{
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (qService.Exists(this.QueueName))
                qService.DeleteWorkflowQueue(this.QueueName);
		}

        /// <summary>
        /// A simple gathering point for user tracking calls.
        /// </summary>
        private void TrackThis(ActivityExecutionContext context)
        {
            context.TrackData(this);
        }

        /// <summary>
        /// If the user activity is already complete, simply returns the <see cref="CurrentStatus"/>,
        /// otherwise attempts to change the user activity's status to complete by successfully retrieving input using <see cref="TryGetInput"/>.
        /// </summary>
        /// <param name="context">The context the user activity is executing in.</param>
        /// <returns>The user activity's status after the attempt at completion.</returns>
        private Status TryToComplete(ActivityExecutionContext context)
        {
            if (CurrentStatus == Status.Completed)
                return CurrentStatus;

            UserActivityCompletedEventArgs input = TryGetInput(context);
            if (input != null)
            {
                DataSet = input.ActivityData;
                currentStatus = Status.Completed;
            }

            return CurrentStatus;
        }

        /// <summary>
        /// Gets input from the queue.
        /// </summary>
        /// <param name="context">The context from which to retrieve the queue and input.</param>
        /// <returns>Null if the context is null, the queue doesn't exist, the queue has no items, or the top item in the queue is not an instance of 
        /// <see cref="UserActivityCompletedEventArgs"/>.
        /// Otherwise returns the top queued input from the queue.</returns>
        private UserActivityCompletedEventArgs TryGetInput(ActivityExecutionContext context)
        {
            if (context == null)
                return null;

            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (!qService.Exists(this.QueueName))
                return null;

            WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);
            if (queue.Count == 0)
                return null;

            UserActivityCompletedEventArgs eventArgs = queue.Dequeue() as UserActivityCompletedEventArgs;
            if (eventArgs == null)
                return null;

            return eventArgs;
        }

		#region Properties

        private Status currentStatus;

        /// <summary>
        /// Indicates the current status of the user activity, distinct from it's execution status.
        /// </summary>
        public Status CurrentStatus
        {
            get { return currentStatus; }
        }

		private Guid? activityGuid = null;

		/// <summary>
		/// This identifies the user activity this creates so that messages can be correlated correctly.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Guid ActivityGuid
		{
			get
			{
				if (!activityGuid.HasValue)
					activityGuid = Guid.NewGuid();

				return activityGuid.Value;
			}
		}

		/// <summary>
		/// Exposes the identifier of the containing workflow for message correlation.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Guid WorkflowGuid
		{
			get { return this.WorkflowInstanceId; }
		}

		public static DependencyProperty DataSetProperty = System.Workflow.ComponentModel.DependencyProperty.Register("DataSet", typeof(DataSet), typeof(UserActivity));

		[Description("The dataset that a user edits when doing this activity.")]
		[Category("Parameters")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public DataSet DataSet
		{
			get { return ((DataSet)(base.GetValue(UserActivity.DataSetProperty))); }
			set { base.SetValue(UserActivity.DataSetProperty, value); }
		}

		public static DependencyProperty ActivityTypeProperty = System.Workflow.ComponentModel.DependencyProperty.Register("ActivityType", typeof(UserActivityType), typeof(UserActivity));

		[Description("The type of activity the user will do.")]
		[Category("Parameters")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public UserActivityType ActivityType
		{
			get { return ((UserActivityType)(base.GetValue(UserActivity.ActivityTypeProperty))); }
			set { base.SetValue(UserActivity.ActivityTypeProperty, value); }
		}

		public static DependencyProperty RequiredRoleProperty = System.Workflow.ComponentModel.DependencyProperty.Register("RequiredRole", typeof(UserRole), typeof(UserActivity));

		[Description("The role a user must have to work on this task.")]
		[Category("Parameters")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public UserRole RequiredRole
		{
			get { return ((UserRole)(base.GetValue(UserActivity.RequiredRoleProperty))); }
			set { base.SetValue(UserActivity.RequiredRoleProperty, value); }
		}

		#endregion
	}
}
