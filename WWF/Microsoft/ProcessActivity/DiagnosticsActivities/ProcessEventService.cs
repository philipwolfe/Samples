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
using System.Collections.Generic;
using System.Workflow.Runtime;
using System.Diagnostics;
using Microsoft.Samples.Workflow.CustomActivityFramework;
using System.Threading;

namespace DiagnosticsActivities
{
    public class ProcessEventService : EventService<EventSubscription>
    {
        public override void UnregisterListener(Guid subscriptionId)
        {
            if (this.Subscriptions.ContainsKey(subscriptionId))
            {
                EventSubscription subscription = this.Subscriptions[subscriptionId];

                this.Subscriptions.Remove(subscriptionId);

                // Write out the subscription information to the Trace
                Trace.TraceInformation("ProcessEventService subscription deleted.  InstanceId={0}, QueueName={1}'", subscription.WorkflowInstanceId.ToString(), subscription.QueueName);
            }
		}

        public Guid RegisterListenerAndRunProcess(ProcessActivity processActivity, Guid workflowInstanceId, IComparable queueName)
        {
            Process process = new Process();

            if (!processActivity.FileName.Equals(string.Empty))
                process.StartInfo.FileName = processActivity.FileName;

            if (!processActivity.Arguments.Equals(string.Empty))
                process.StartInfo.Arguments = processActivity.Arguments;

            process.StartInfo.CreateNoWindow = processActivity.CreateNoWindow;
            process.StartInfo.RedirectStandardError = processActivity.RedirectStandardError;
            process.StartInfo.RedirectStandardInput = processActivity.RedirectStandardInput;
            process.StartInfo.RedirectStandardOutput = processActivity.RedirectStandardOutput;
            process.StartInfo.UseShellExecute = processActivity.UseShellExecute;

            int timeout = processActivity.Timeout ? processActivity.TimeoutLength : int.MaxValue;
            
            // Create a new subscription so we can Enque data back to the activity
            EventSubscription subscription = new EventSubscription(queueName, workflowInstanceId);

            this.Subscriptions.Add(subscription.SubscriptionId, subscription);

            // Write out the subscription information to the Trace
            Trace.TraceInformation("ProcessEventService subscription created.  InstanceId={0}, QueueName={1}'", workflowInstanceId.ToString(), queueName);

            //  Create a new thread to run the process
            Thread thread = new Thread(this.RunProcess);
            ProcessJob processJob = new ProcessJob();
            processJob.process = process;
            processJob.timeout = timeout;
            processJob.processService = this;
            processJob.instanceId = workflowInstanceId;
            processJob.queue = queueName;
            thread.Start(processJob);

            return subscription.SubscriptionId;
        }

        private struct ProcessJob
        {
            public Process process;
            public int timeout;
            public ProcessEventService processService;
            public Guid instanceId;
            public IComparable queue;
        }
         
        void RunProcess(object obj)
        {
            ProcessJob processJob = (ProcessJob)obj;
            processJob.process.Start();
            processJob.process.WaitForExit(processJob.timeout);
            processJob.processService.DeliverToWorkflow(processJob.instanceId, processJob.queue, null);
        }
	}
}
