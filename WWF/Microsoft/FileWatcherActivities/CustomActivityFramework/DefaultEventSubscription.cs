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
using System.IO;

namespace Microsoft.Samples.Workflow.CustomActivityFramework
{
    /// <summary>
    /// The DefaultEventSubscription class is a creatable version of the 
    /// System.Workflow.Runtime.Hosting.EventSubscription class.
    /// </summary>
    public class DefaultEventSubscription : System.Workflow.Runtime.Hosting.EventSubscription
    {
        public DefaultEventSubscription()
        {

        }

        public DefaultEventSubscription(IComparable queueName, Guid workflowInstanceId)
            : base(queueName, workflowInstanceId)
        {
        }
    }
}
