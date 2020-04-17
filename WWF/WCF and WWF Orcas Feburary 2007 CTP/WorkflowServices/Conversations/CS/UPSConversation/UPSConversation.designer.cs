using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Microsoft.NetFx35.Silver.Samples
{
	partial class UPSConversation
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.Activities.Endpoint endpoint1 = new System.Workflow.Activities.Endpoint();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo1 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo2 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.WorkflowServiceAttributes workflowserviceattributes1 = new System.Workflow.Activities.WorkflowServiceAttributes();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.sendActivity1 = new System.Workflow.Activities.SendActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.receiveActivity1 = new System.Workflow.Activities.ReceiveActivity();
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // sendActivity1
            // 
            endpoint1.ConfigurationName = "LogisticsEndPoint";
            endpoint1.Name = "LogisticsEndPoint";
            this.sendActivity1.Endpoint = endpoint1;
            this.sendActivity1.Name = "sendActivity1";
            activitybind1.Name = "UPSConversation";
            activitybind1.Path = "logisticsQuote";
            workflowparameterbinding1.ParameterName = "lq";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.sendActivity1.ParameterBindings.Add(workflowparameterbinding1);
            typedoperationinfo1.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderLogisticsQuotes);
            typedoperationinfo1.Name = "ReceiveLogisticsQuote";
            this.sendActivity1.ServiceOperationInfo = typedoperationinfo1;
            this.sendActivity1.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareLogisticsQuote);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
            // 
            // receiveActivity1
            // 
            this.receiveActivity1.Activities.Add(this.codeActivity1);
            this.receiveActivity1.CanCreateInstance = true;
            this.receiveActivity1.Name = "receiveActivity1";
            activitybind2.Name = "UPSConversation";
            activitybind2.Path = "ReceivedContext";
            workflowparameterbinding2.ParameterName = "context";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "UPSConversation";
            activitybind3.Path = "ReceivedPO";
            workflowparameterbinding3.ParameterName = "po";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "UPSConversation";
            activitybind4.Path = "UPSAck";
            workflowparameterbinding4.ParameterName = "(ReturnValue)";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding3);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding4);
            typedoperationinfo2.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderLogisticsRequest);
            typedoperationinfo2.Name = "RequestLogisticsQuote";
            this.receiveActivity1.ServiceOperationInfo = typedoperationinfo2;
            workflowserviceattributes1.ConfigurationName = "UPSConversation";
            // 
            // UPSConversation
            // 
            this.Activities.Add(this.receiveActivity1);
            this.Activities.Add(this.delayActivity1);
            this.Activities.Add(this.sendActivity1);
            this.Name = "UPSConversation";
            this.SetValue(System.Workflow.Activities.ReceiveActivity.WorkflowServiceAttributesProperty, workflowserviceattributes1);
            this.CanModifyActivities = false;

		}

		#endregion

        private DelayActivity delayActivity1;
        private ReceiveActivity receiveActivity1;
        private CodeActivity codeActivity1;
        private SendActivity sendActivity1;














    }
}
