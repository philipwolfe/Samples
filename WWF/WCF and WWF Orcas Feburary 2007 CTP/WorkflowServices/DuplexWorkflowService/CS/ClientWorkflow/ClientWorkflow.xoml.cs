using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.ServiceModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Microsoft.WorkflowServices.Samples
{
	public partial class ClientWorkflow: StateMachineWorkflowActivity
	{
        Random generator = new Random();

        // TODO: pass uri into Workflow from Host
        [NonSerialized] // input for IHostForwardContract.BeginWork
        public string ReturnUri = default(string);
        [NonSerialized] // input for IHostForwardContract.SubmitWorkItem
        public string SubmitWorkItemInput = default(string);
        [NonSerialized] // output for IForwardContract.BeginWorkflow
        public EndpointAddress10 ReturnAddress = default(EndpointAddress10);

        public int WorkItemCount = 0;
        public int WorkItemValue = 0;
        public string WorkItemLastPart = default(string);
        public WorkItem WorkItem = null;
        
        private void SetReturnAddress(object sender, EventArgs e)
        {
            EndpointAddress epr = ContextManager.CreateEndpointAddress(ReturnUri, this.ReceiveWorkItemComplete);
            ReturnAddress = EndpointAddress10.FromEndpointAddress(epr);
            DebugOutput("[ClientWorkflow:SetReturnAddress] " + epr.Headers[0].GetValue<string>());
        }

        private void GenerateWorkItemCount(object sender, EventArgs e)
        {
            WorkItemCount = generator.Next(1, 8);
            WorkItemLastPart = SubmitWorkItemInput + "_Completed";
            // TODO: debug to determine if race condition
            //System.Threading.Thread.Sleep(25);
            DebugOutput("[ClientWorkflow:GenerateWorkItemCount] " + WorkItemCount.ToString());
        }

        private void GenerateNextWorkItemValue(object sender, EventArgs e)
        {
            WorkItemCount--;
            WorkItemValue = generator.Next(1000, 9999);
            // TODO: debug to determine if race condition
            //System.Threading.Thread.Sleep(25);
            DebugOutput("[ClientWorkflow:GenerateNextWorkItemValue] " + WorkItemCount.ToString() + ", " + WorkItemValue.ToString());
        }

        private void DebugOutput(string output)
        {
            Console.WriteLine(output);
            //System.Threading.Thread.Sleep(15);
        }

        private void CheckItemCount(object sender, ConditionalEventArgs e)
        {
            if (this.WorkItemCount > 0)
            {
                e.Result = true;
            }
            else
            {
                e.Result = false;
            }
        }
	}

}
