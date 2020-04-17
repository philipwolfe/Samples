//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Beta 2 Hands on Labs
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Workflow.ComponentModel;

namespace LongRunningWorkflow
{
    //
    // This is the service class which is added to the workflow runtime and
    // run on the workflow host thread
    //
    public class FactoringService
    {
		private WorkflowRuntime runtime;

		public FactoringService(WorkflowRuntime runtime)
		{
			this.runtime = runtime;
		}

        //
        // A class to hold the state required for the factoring service. This
        // is required since the QueueUserWorkfItem delegate only accepts
        // a single parameter
        // 
		private class FactoringState
		{
			public Guid instanceId;
			public IComparable resultQueueName;

			public FactoringState(Guid instanceId, IComparable resultQueueName)
			{
				this.instanceId = instanceId;
				this.resultQueueName = resultQueueName;
			}
		}

        //
        // This is called in the activity thread to start the prime factoring
        //
        public void FactorPrimes(IComparable resultQueueName)
        {
            ThreadPool.QueueUserWorkItem(FactorPrimes, new FactoringState(WorkflowEnvironment.WorkflowInstanceId, resultQueueName));
        }

        //
        // This runs in the new thread created by QueueUserWorkItem
        //
        private void FactorPrimes(object state)
        {
			FactoringState factState = state as FactoringState;

            Console.WriteLine("Beginning Factoring Prime Numbers");

            DateTime start = DateTime.Now;

            int topNumber = 100000000;
            BitArray numbers = new BitArray(topNumber, true);

            for (int i = 2; i < topNumber; i++)
            {
                if (numbers[i])
                {
                    for (int j = i * 2; j < topNumber; j += i)
                    {
                        numbers[j] = false;
                    }
                }
            }

            int primes = 0;

            for (int i = 1; i < topNumber; i++)
            {
                if (numbers[i])
                {
                    primes++;
                }
            }

            Console.WriteLine("Finished Factoring Prime Numbers (" + Math.Round(DateTime.Now.Subtract(start).TotalSeconds, 0) + " seconds)");

			WorkflowInstance wi = runtime.GetWorkflow(factState.instanceId);

            //
            // Send the message back to the activity and pass the result
            //
            wi.EnqueueItem(factState.resultQueueName, primes, null, null);
        }
    }

    //
    // This is the activity class as dragged onto the workflow
    //
	public class FactorPrimesActivity : Activity
	{
		private int result;

		public int Result
		{
			get
			{
				return result;
			}
		}

        //
        // This is called when the activity is first executed on the workflow thread
        //
		protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
		{
			string qName = this.QualifiedName + "ResultQueue";
			WorkflowQueuingService qServ = context.GetService<WorkflowQueuingService>();
			WorkflowQueue q = qServ.CreateWorkflowQueue(qName, false);
			q.QueueItemAvailable += OnItemAvailable;

			FactoringService factServ = context.GetService<FactoringService>();
			factServ.FactorPrimes(qName);

			return ActivityExecutionStatus.Executing;
		}

        //
        // This is called on the workflow thread when the prime factoring is complete
        // and the queue message is received
        //
		private void OnItemAvailable(object sender, QueueEventArgs e)
		{
			ActivityExecutionContext context = sender as ActivityExecutionContext;

			WorkflowQueuingService qServ = context.GetService<WorkflowQueuingService>();
			WorkflowQueue q = qServ.GetWorkflowQueue(e.QueueName);
			
			result = (int)q.Dequeue();
			qServ.DeleteWorkflowQueue(e.QueueName);

            context.CloseActivity();
		}
	}
}

