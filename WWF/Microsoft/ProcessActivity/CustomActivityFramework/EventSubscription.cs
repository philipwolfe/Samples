//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
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

namespace Microsoft.Samples.Workflow.CustomActivityFramework
{
    /// <summary>
    /// The EventSubscription class.
    /// </summary>
    public class EventSubscription
    {
        public EventSubscription()
        {

        }

        public EventSubscription(IComparable queueName, Guid workflowInstanceId)
        {
            this.queueName = queueName;
            this.workflowInstanceId = workflowInstanceId;
            this.subscriptionId = Guid.NewGuid();
        }

        private IComparable queueName;

        public IComparable QueueName
        {
            get { return queueName; }
            set { queueName = value; }
        }

        private Guid workflowInstanceId;

        public Guid WorkflowInstanceId
        {
            get { return workflowInstanceId; }
            set { workflowInstanceId = value; }
        }

        private Guid subscriptionId;

        public Guid SubscriptionId
        {
            get { return subscriptionId; }
        }
    }
}
