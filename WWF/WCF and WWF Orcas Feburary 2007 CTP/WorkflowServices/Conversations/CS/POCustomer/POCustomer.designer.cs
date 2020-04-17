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
    partial class POCustomer
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo1 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.Endpoint endpoint1 = new System.Workflow.Activities.Endpoint();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding6 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo2 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.WorkflowServiceAttributes workflowserviceattributes1 = new System.Workflow.Activities.WorkflowServiceAttributes();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.receiveActivity1 = new System.Workflow.Activities.ReceiveActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.sendActivity1 = new System.Workflow.Activities.SendActivity();
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // receiveActivity1
            // 
            this.receiveActivity1.Activities.Add(this.codeActivity1);
            this.receiveActivity1.Name = "receiveActivity1";
            activitybind1.Name = "POCustomer";
            activitybind1.Path = "POReceived";
            workflowparameterbinding1.ParameterName = "po";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "POCustomer";
            activitybind2.Path = "ReceivedLogisticsQuote";
            workflowparameterbinding2.ParameterName = "lq";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "POCustomer";
            activitybind3.Path = "BuyerAck";
            workflowparameterbinding3.ParameterName = "(ReturnValue)";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding1);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding3);
            typedoperationinfo1.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderDetails);
            typedoperationinfo1.Name = "ReceiveOrderDetails";
            this.receiveActivity1.ServiceOperationInfo = typedoperationinfo1;
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // sendActivity1
            // 
            endpoint1.ConfigurationName = "SellerEndPoint";
            endpoint1.Name = "SellerEndPoint";
            endpoint1.OwnerActivityName = "";
            this.sendActivity1.Endpoint = endpoint1;
            this.sendActivity1.Name = "sendActivity1";
            activitybind4.Name = "POCustomer";
            activitybind4.Path = "PORequest";
            workflowparameterbinding4.ParameterName = "po";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            activitybind5.Name = "POCustomer";
            activitybind5.Path = "SellerAck";
            workflowparameterbinding5.ParameterName = "(ReturnValue)";
            workflowparameterbinding5.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            activitybind6.Name = "POCustomer";
            activitybind6.Path = "contextToSend";
            workflowparameterbinding6.ParameterName = "BuyerContext";
            workflowparameterbinding6.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.sendActivity1.ParameterBindings.Add(workflowparameterbinding4);
            this.sendActivity1.ParameterBindings.Add(workflowparameterbinding5);
            this.sendActivity1.ParameterBindings.Add(workflowparameterbinding6);
            typedoperationinfo2.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IReceiveOrder);
            typedoperationinfo2.Name = "ReceiveOrder";
            this.sendActivity1.ServiceOperationInfo = typedoperationinfo2;
            this.sendActivity1.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareMessage);
            // 
            // POCustomer
            // 
            this.Activities.Add(this.sendActivity1);
            this.Activities.Add(this.codeActivity2);
            this.Activities.Add(this.receiveActivity1);
            this.Name = "POCustomer";
            this.SetValue(System.Workflow.Activities.ReceiveActivity.WorkflowServiceAttributesProperty, workflowserviceattributes1);
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeActivity2;
        private CodeActivity codeActivity1;
        private ReceiveActivity receiveActivity1;
        private SendActivity sendActivity1;













    }
}
