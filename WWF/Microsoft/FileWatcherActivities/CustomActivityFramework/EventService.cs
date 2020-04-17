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
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Diagnostics;

namespace Microsoft.Samples.Workflow.CustomActivityFramework
{
    /// <summary>
    /// The EventService class is a WorkflowRuntimeService designed to allow 
    /// long-running work to execute within a workflow.  It takes a generic 
    /// type of EventSubscription, which is stored in a collection of subscriptions
    /// maintained by this service.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventService<T> : WorkflowRuntimeService where T : System.Workflow.Runtime.Hosting.EventSubscription
	{
        private Dictionary<Guid, T> subscriptions = new Dictionary<Guid,T>();

        /// <summary>
        /// Returns the dictionary of Subscriptions managed by this EventService.
        /// </summary>
        public virtual Dictionary<Guid, T> Subscriptions
        {
            get
            {
                return subscriptions;
            }
        }

        /// <summary>
        /// Used to enque event arguments to a specific WorkflowInstance and Queue.  
        /// </summary>
        /// <param name="workflowInstanceId"></param>
        /// <param name="queueName"></param>
        /// <param name="e"></param>
        public virtual void DeliverToWorkflow(Guid workflowInstanceId, IComparable queueName, EventArgs e)
        {
            try
            {

                // Write out the information about the message being Enqueued to the Trace
                Trace.TraceInformation("EventService EnqueItem - InstanceId={0}, QueueName={1}'",
                    workflowInstanceId.ToString(), queueName);

                // Enqueue the event data so it can be received by the activity.  
                WorkflowInstance workflowInstance = this.Runtime.GetWorkflow(workflowInstanceId);
                workflowInstance.EnqueueItem(queueName, e, null, null);

            }
            catch (Exception excp)
            {
                // Write the exception out to the Debug console and throw the exception
                System.Diagnostics.Debug.WriteLine(excp);
                throw excp;
            }
        }


        /// <summary>
        /// Used to remove an EventSubscription object from the collection of subscriptions.
        /// </summary>
        /// <param name="subscriptionId"></param>        
        public virtual void UnregisterListener(Guid subscriptionId)
        {

            //// Remove the subscription from the list.
            //string subscriptionId = workflowInstanceId.ToString() + "_" + queueName.ToString();

            if (this.Subscriptions.ContainsKey(subscriptionId))
            {
                T subscription = this.Subscriptions[subscriptionId];
                this.Subscriptions.Remove(subscriptionId);

                // Write out the subscription information to the Trace
                Trace.TraceInformation("EventService subscription deleted.  InstanceId={0}, QueueName={1}'",
                    subscription.WorkflowInstanceId.ToString(), subscription.QueueName);
            }

        }
	}
}
