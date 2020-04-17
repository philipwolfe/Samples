//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Microsoft.Samples.Workflow.CustomActivityFramework
{
    /// <summary>
    /// Base class for activities that dequeue data from a workflow queue
    /// </summary>
    public abstract class InputActivity : Activity, IEventActivity, IActivityEventListener<QueueEventArgs>
    {

        #region Private variables
        private Guid eventSubscriptionId;
        #endregion


        #region Properties

        /// <summary>
        /// Used to store (serialize) the Guid identifying the EventSubscription
        /// </summary>
        [Browsable(false)]
        public Guid EventSubscriptionId
        {
            get { return eventSubscriptionId; }
            set { eventSubscriptionId = value; }
        }
        #endregion


        #region Abstract Methods

        /// <summary>
        /// The Queue name used for creating the Workflow Queue.  The default value is 
        /// the Activity's QualifiedName
        /// </summary>
        protected virtual IComparable QueueName
        {
            get
            {
                return this.QualifiedName;
            }
        }

        /// <summary>
        /// This method should be used by the deriving activity to process an item (EventArgs) that 
        /// have been received in the Workflow queue.  
        /// </summary>
        /// <param name="context"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        protected abstract bool ProcessQueueItem(ActivityExecutionContext context, object item);

        /// <summary>
        /// This method should be overridden by the deriving activity to hook on to the external event.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected abstract bool SubscribeExternalEvent(ActivityExecutionContext context);

        /// <summary>
        /// This method should be used by the deriving activity to unsubscribe from the external event.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected abstract bool UnsubscribeExternalEvent(ActivityExecutionContext context);
        #endregion


        #region Activity Execution Methods
        protected override void Initialize(IServiceProvider provider)
        {
            // Create a new queue for receiving the event data
            this.CreateQueue(provider.GetService(typeof(WorkflowQueuingService)) as WorkflowQueuingService, false);
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            // Check if we have any items in the queue.  If so, complete this activity.
            if (this.ProcessQueueItem(context))
            {
                return ActivityExecutionStatus.Closed;
            }

            // Otherwise, subscribe for the external event and continue executing
            this.Subscribe(context, this);
            return ActivityExecutionStatus.Executing;
        }

        protected override ActivityExecutionStatus Cancel(ActivityExecutionContext context)
        {
            // Unsubscribe for the external event and complete our processing
            Unsubscribe(context, this);
            return ActivityExecutionStatus.Closed;
        }
        #endregion


        #region IEventActivity Implementation

        /// <summary>
        /// The queue name to use for receiving messages into this activity.
        /// By default the QueueName will be the activity's name within the workflow.  
        /// </summary>
        IComparable IEventActivity.QueueName
        {
            get
            { 
                return this.QueueName;
            }
        }


        /// <summary>
        /// The subscribe is called when a parent activity would like to subscribe to the event.  
        /// For example, an Event Driven activity calls into the Subscribe method.  
        /// At this point, we should create a subscription for the underlying event.
        /// </summary>
        /// <param name="parentContext"></param>
        /// <param name="parentEventHandler"></param>
        void IEventActivity.Subscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
        {
            Subscribe(parentContext, parentEventHandler);
        }

        /// <summary>
        /// The Unsubscribe method is called when the parent activity is done subscribing for the event.
        /// At this point, we should remove our subscription for the underlying event.  
        /// </summary>
        /// <param name="parentContext"></param>
        /// <param name="parentEventHandler"></param>
        void IEventActivity.Unsubscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
        {
            Unsubscribe(parentContext, parentEventHandler);
        }
        #endregion


        #region Protected methods 

        /// <summary>
        /// This overload of CreateQueue will create a new queue if one doesn't exist.
        /// </summary>
        /// <param name="qService"></param>
        /// <param name="transactional"></param>
        /// <returns></returns>
        protected WorkflowQueue CreateQueue(WorkflowQueuingService qService, bool transactional)
        {
            IComparable queueName = this.QueueName;

            if (!qService.Exists(queueName))
            {
                return qService.CreateWorkflowQueue(queueName, transactional);
            }

            return qService.GetWorkflowQueue(queueName);
        }

        /// <summary>
        /// This overload of CreateQueue will just always create a new queue.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="transactional"></param>
        /// <returns></returns>
        protected WorkflowQueue CreateQueue(ActivityExecutionContext context, bool transactional)
        {
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            return CreateQueue(qService, transactional);
        }


        /// <summary>
        /// The Subscribe method is called when this activity is read to subscribe to events.
        /// At this point the activity will hook on to the queue's event.
        /// Work specific to the derived activity should be performed in SubscribeExternalEvent method.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="listener"></param>
        protected void Subscribe(ActivityExecutionContext context, IActivityEventListener<QueueEventArgs> listener)
        {
            WorkflowQueue queue = CreateQueue(context, false);
            queue.RegisterForQueueItemAvailable(listener);

            // Begin listening for the external event.  
            this.SubscribeExternalEvent(context);
        }

        /// <summary>
        /// DeleteQueue is called to remove the queue that was created by this activity.
        /// </summary>
        /// <param name="context"></param>
        protected void DeleteQueue(ActivityExecutionContext context)
        {
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            qService.DeleteWorkflowQueue(this.QueueName);
        }

        /// <summary>
        /// The Unsubscribe method is called when the activity is ready to unsubscribe for events.
        /// At this point the activity will unhook from to the queue's event.
        /// Work specific to the derived activity should be performed in the UnsubscribeExternalEvent method.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="listener"></param>
        protected void Unsubscribe(ActivityExecutionContext context, IActivityEventListener<QueueEventArgs> listener)
        {
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (!qService.Exists(this.QueueName))
            {
                return;
            }
            WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);

            queue.UnregisterForQueueItemAvailable(listener);

            // Begin listening for the external event.  
            this.UnsubscribeExternalEvent(context);
        }


        /// <summary>
        /// The OnEvent method is called when data is enqued in the workflow queue monitored by this activity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void IActivityEventListener<QueueEventArgs>.OnEvent(object sender, QueueEventArgs e)
        {
            // Ignores the event unless the activity is executing
            if (this.ExecutionStatus == ActivityExecutionStatus.Executing)
            {
                ActivityExecutionContext context = sender as ActivityExecutionContext;
                if (this.ProcessQueueItem(context))
                {
                    context.CloseActivity();
                }
            }
        }


        /// <summary>
        /// ProcessQueueItem performs the basic processing when an item is received in the queue.
        /// Functionality specific to the activity can be performed in the other overloaded version 
        /// of ProcessQueueItem.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected bool ProcessQueueItem(ActivityExecutionContext context)
        {
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            WorkflowQueue queue = null;
            if (qService.Exists(this.QueueName))
            {
                queue = qService.GetWorkflowQueue(this.QueueName);
            }

            bool results = false;
            // If the queue still has messages, then process the first one
            if (queue != null && queue.Count > 0)
            {
                results = ProcessQueueItem(context, queue.Dequeue());
                this.Unsubscribe(context, this);
                this.DeleteQueue(context);
            }
            return results;
        }
        #endregion
    }
}