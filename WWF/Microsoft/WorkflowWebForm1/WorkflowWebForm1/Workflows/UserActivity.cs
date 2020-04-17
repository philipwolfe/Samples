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

	/// <summary>
	/// Derived from <see cref="HandleExternalEventActivity"/>, this activity creates a user activity via the <see cref="IUserActivityService"/> implementation available to it
	/// from the <see cref="WorkflowRuntime"/>'s <see cref="ExternalDataExchangeService"/>, then waits for the user to complete the activity.
	/// </summary>
	[Designer(typeof(UserActivityDesigner), typeof(IDesigner))]
	public partial class UserActivity : Activity, IEventActivity, IActivityEventListener<QueueEventArgs>
	{
		public UserActivity()
		{
			InitializeComponent();

			queueName = Helper.MakeQueueName(this.ActivityGuid);
		}

		#region IActivityEventListener<UserActivityCompletedEventArgs> Members

		public void OnEvent(object sender, QueueEventArgs e)
		{
			ActivityExecutionContext context = sender as ActivityExecutionContext;
			if (this.ExecutionStatus == ActivityExecutionStatus.Executing && ProcessQueueItem(context))
				context.CloseActivity();
		}

		#endregion

		#region IEventActivity Members

		private string queueName;

		public IComparable QueueName
		{
			get { return queueName; }
		}

		public void Subscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
		{
			DoSubscribe(parentContext, parentEventHandler);
		}

		public void Unsubscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
		{
			DoUnsubscribe(parentContext, parentEventHandler);
		}

		#endregion

		#region Activity Overrides

		protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
		{
			if (this.ProcessQueueItem(context))
				return ActivityExecutionStatus.Closed;

			this.DoSubscribe(context, this);
			return ActivityExecutionStatus.Executing;
		}

		protected override ActivityExecutionStatus Cancel(ActivityExecutionContext context)
		{
			DoUnsubscribe(context, this);
			DeleteQueue(context);
			return ActivityExecutionStatus.Closed;
		}

		#endregion

		private WorkflowQueue CreateQueue(ActivityExecutionContext context)
		{
			WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();

			if (qService.Exists(this.QueueName))
				return qService.GetWorkflowQueue(this.QueueName);
			else
				return qService.CreateWorkflowQueue(this.QueueName, true);
		}

		private void DeleteQueue(ActivityExecutionContext context)
		{
			context.GetService<WorkflowQueuingService>().DeleteWorkflowQueue(this.QueueName);
		}

		private Boolean DoSubscribe(ActivityExecutionContext context, IActivityEventListener<QueueEventArgs> listener)
		{
			WorkflowQueue queue = CreateQueue(context);
			Helper.UserActivityService.CreateUserActivity(WorkflowGuid, ActivityGuid, ActivityType, RequiredRole, Description, DataSet);

			queue.RegisterForQueueItemAvailable(listener);
			return true;
		}

		private bool queueItemReceived = false;

		private void DoUnsubscribe(ActivityExecutionContext context, IActivityEventListener<QueueEventArgs> listener)
		{
			if (!queueItemReceived)
				Helper.UserActivityService.CancelUserActivity(ActivityGuid);

			WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
			WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);

			queue.UnregisterForQueueItemAvailable(listener);
		}

		/// <summary>
		/// Handles the completion of the user activity by pushing the data the user edited back through to the <see cref="DataSet"/> <see cref="DependencyProperty"/>.
		/// </summary>
		private bool ProcessQueueItem(ActivityExecutionContext context)
		{
			if (context == null)
				return false;

			WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
			if (!qService.Exists(this.QueueName))
				return false;

			WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);

			// If the queue has messages, then process the first one
			if (queue.Count == 0)
				return false;

			UserActivityCompletedEventArgs eventArgs = queue.Dequeue() as UserActivityCompletedEventArgs;
			if (eventArgs != null)
			{
				DataSet = eventArgs.ActivityData;
				queueItemReceived = true;
			}

			DoUnsubscribe(context, this);
			DeleteQueue(context);
			return true;
		}

		#region Properties

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
