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
    using System.Workflow.Runtime;
    using System.Workflow.Runtime.Messaging;

    /// <summary>
    /// This class is used to store the list of active subscriptions
    /// </summary>
    public class SubscriptionService : WorkflowSubscriptionService
    {
        private Dictionary<Guid, MessageEventSubscription> subscriptions = new Dictionary<Guid, MessageEventSubscription>();

        public SubscriptionService()
        {
        }

        private MessageEventSubscription FindMatchingSubscription(
            Type interfaceType,
            string operation,
            string[] parameterNames,
            object[] parameterValues)
        {
            // This method implementation is not the most efficient one,
            // but is enough for illustration of the sample.

            // This method takes message correlation property names and values
            // and performs subscription lookup, which matches the message

            // Loop through subscriptions
            MessageEventSubscription resultSubscription = null;
            foreach (MessageEventSubscription curSubscription in this.subscriptions.Values)
            {
                if ((curSubscription.InterfaceType == interfaceType) &&
                    (curSubscription.MethodName == operation))
                {
                    // check predicates are matching to the message values
                    bool predicatesMatch = true;
                    foreach (CorrelationProperty curPredicate in curSubscription.CorrelationProperties)
                    {
                        bool matchingPropertyFound = false;

                        for (int i = 0; (i < parameterNames.Length) && (i < parameterValues.Length); i++)
                        {
                            if (parameterNames[i] == curPredicate.Property.Name)
                            {
                                matchingPropertyFound = true;

                                if (!parameterValues[i].Equals(curPredicate.Value))
                                {
                                    predicatesMatch = false;
                                    break;
                                }
                            }
                        }

                        if (!matchingPropertyFound)
                        {
                            predicatesMatch = false;
                        }

                        if (!predicatesMatch)
                        {
                            break;
                        }
                    }

                    if (predicatesMatch)
                    {
                        resultSubscription = curSubscription;
                        break;
                    }
                }
            }

            return resultSubscription;
        }

        public Guid FindInstanceIdBySubscription(
            Type contract,
            string operation,
            string[] parameterNames,
            object[] parameterValues)
        {
            // this method gets the workflow instance id based on message
            // properties and matching subscription

            if (parameterNames.Length != parameterValues.Length)
            {
                throw new InvalidOperationException("parameterNames and parameterValues should have the same Length");
            }

            Guid workflowInstanceId;

            lock (this)
            {
                MessageEventSubscription subscription = this.FindMatchingSubscription(contract, operation, parameterNames, parameterValues);

                if (subscription == null)
                {
                    throw new SubscriptionNotFoundException();
                }

                workflowInstanceId = subscription.WorkflowInstanceId;
            }

            return workflowInstanceId;
        }

        public override void CreateSubscription(MessageEventSubscription subscription)
        {
            // this method is called by workflow runtime to notify subscription
            // service that subscription was created
            lock (this)
            {
                this.subscriptions.Add(subscription.SubscriptionId, subscription);
            }
        }

        public override void DeleteSubscription(Guid subscriptionId)
        {
            // this method is called by workflow runtime to notify subscription
            // service that subscription was deleted
            lock (this)
            {
                if (!this.subscriptions.Remove(subscriptionId))
                {
                    throw new InvalidOperationException("Subscription is not found in the collection");
                }
            }
        }
    }

    /// <summary>
    /// This exception will be thrown and handled if the message
    /// did not match any existing subscription
    /// </summary>
    public class SubscriptionNotFoundException : Exception
    {
        public SubscriptionNotFoundException() : base("Subscription not found")
        {
        }
    }
}
