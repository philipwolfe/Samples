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
	partial class Workflow1
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
            System.Workflow.Activities.ContextToken contexttoken1 = new System.Workflow.Activities.ContextToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo1 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.Endpoint endpoint1 = new System.Workflow.Activities.Endpoint();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo2 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.ContextToken contexttoken2 = new System.Workflow.Activities.ContextToken();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo3 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.Endpoint endpoint2 = new System.Workflow.Activities.Endpoint();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding6 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding7 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding8 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo4 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.ContextToken contexttoken3 = new System.Workflow.Activities.ContextToken();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding9 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo5 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.Endpoint endpoint3 = new System.Workflow.Activities.Endpoint();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding10 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding11 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding12 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo6 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.Endpoint endpoint4 = new System.Workflow.Activities.Endpoint();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding13 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding14 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding15 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo7 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding16 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding17 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding18 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo8 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.WorkflowServiceAttributes workflowserviceattributes1 = new System.Workflow.Activities.WorkflowServiceAttributes();
            this.codeActivity4 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity3 = new System.Workflow.Activities.CodeActivity();
            this.receiveActivity4 = new System.Workflow.Activities.ReceiveActivity();
            this.sendActivity3 = new System.Workflow.Activities.SendActivity();
            this.receiveActivity3 = new System.Workflow.Activities.ReceiveActivity();
            this.sendActivity2 = new System.Workflow.Activities.SendActivity();
            this.receiveActivity2 = new System.Workflow.Activities.ReceiveActivity();
            this.sendActivity1 = new System.Workflow.Activities.SendActivity();
            this.USPSQuote = new System.Workflow.Activities.SequenceActivity();
            this.FedExQuote = new System.Workflow.Activities.SequenceActivity();
            this.UPSQuote = new System.Workflow.Activities.SequenceActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.sendActivity4 = new System.Workflow.Activities.SendActivity();
            this.GetLogisticsQuotes = new System.Workflow.Activities.ParallelActivity();
            this.receiveActivity1 = new System.Workflow.Activities.ReceiveActivity();
            // 
            // codeActivity4
            // 
            this.codeActivity4.Name = "codeActivity4";
            this.codeActivity4.ExecuteCode += new System.EventHandler(this.codeActivity4_ExecuteCode);
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.ReceiveFedexLogisticsQuote);
            // 
            // codeActivity3
            // 
            this.codeActivity3.Name = "codeActivity3";
            this.codeActivity3.ExecuteCode += new System.EventHandler(this.codeActivity3_ExecuteCode_1);
            // 
            // receiveActivity4
            // 
            this.receiveActivity4.Activities.Add(this.codeActivity4);
            contexttoken1.Name = "USPSContext";
            contexttoken1.OwnerActivityName = "GetLogisticsQuotes";
            this.receiveActivity4.ContextToken = contexttoken1;
            this.receiveActivity4.Name = "receiveActivity4";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "USPSLogisticsQuote";
            workflowparameterbinding1.ParameterName = "lq";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.receiveActivity4.ParameterBindings.Add(workflowparameterbinding1);
            typedoperationinfo1.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderLogisticsQuotes);
            typedoperationinfo1.Name = "ReceiveLogisticsQuote";
            this.receiveActivity4.ServiceOperationInfo = typedoperationinfo1;
            // 
            // sendActivity3
            // 
            endpoint1.ConfigurationName = "USPSEndPoint";
            endpoint1.Name = "USPSEndPoint";
            this.sendActivity3.Endpoint = endpoint1;
            this.sendActivity3.Name = "sendActivity3";
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "ReceivedPO";
            workflowparameterbinding2.ParameterName = "po";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "USPSContext";
            workflowparameterbinding3.ParameterName = "context";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "Workflow1";
            activitybind4.Path = "USPSLogisticsAck";
            workflowparameterbinding4.ParameterName = "(ReturnValue)";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.sendActivity3.ParameterBindings.Add(workflowparameterbinding2);
            this.sendActivity3.ParameterBindings.Add(workflowparameterbinding3);
            this.sendActivity3.ParameterBindings.Add(workflowparameterbinding4);
            typedoperationinfo2.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderLogisticsRequest);
            typedoperationinfo2.Name = "RequestLogisticsQuote";
            this.sendActivity3.ServiceOperationInfo = typedoperationinfo2;
            this.sendActivity3.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareUSPSMessage);
            // 
            // receiveActivity3
            // 
            this.receiveActivity3.Activities.Add(this.codeActivity2);
            contexttoken2.Name = "FedExContext";
            contexttoken2.OwnerActivityName = "GetLogisticsQuotes";
            this.receiveActivity3.ContextToken = contexttoken2;
            this.receiveActivity3.Name = "receiveActivity3";
            activitybind5.Name = "Workflow1";
            activitybind5.Path = "FedExLogisticsQuote";
            workflowparameterbinding5.ParameterName = "lq";
            workflowparameterbinding5.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.receiveActivity3.ParameterBindings.Add(workflowparameterbinding5);
            typedoperationinfo3.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderLogisticsQuotes);
            typedoperationinfo3.Name = "ReceiveLogisticsQuote";
            this.receiveActivity3.ServiceOperationInfo = typedoperationinfo3;
            // 
            // sendActivity2
            // 
            endpoint2.ConfigurationName = "FedExEndPoint";
            endpoint2.Name = "FedExEndPoint";
            this.sendActivity2.Endpoint = endpoint2;
            this.sendActivity2.Name = "sendActivity2";
            activitybind6.Name = "Workflow1";
            activitybind6.Path = "ReceivedPO";
            workflowparameterbinding6.ParameterName = "po";
            workflowparameterbinding6.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            activitybind7.Name = "Workflow1";
            activitybind7.Path = "FedExContext";
            workflowparameterbinding7.ParameterName = "context";
            workflowparameterbinding7.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            activitybind8.Name = "Workflow1";
            activitybind8.Path = "FedExLogisticsAck";
            workflowparameterbinding8.ParameterName = "(ReturnValue)";
            workflowparameterbinding8.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.sendActivity2.ParameterBindings.Add(workflowparameterbinding6);
            this.sendActivity2.ParameterBindings.Add(workflowparameterbinding7);
            this.sendActivity2.ParameterBindings.Add(workflowparameterbinding8);
            typedoperationinfo4.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderLogisticsRequest);
            typedoperationinfo4.Name = "RequestLogisticsQuote";
            this.sendActivity2.ServiceOperationInfo = typedoperationinfo4;
            this.sendActivity2.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareFedExMessage);
            // 
            // receiveActivity2
            // 
            this.receiveActivity2.Activities.Add(this.codeActivity3);
            contexttoken3.Name = "UPSContext";
            contexttoken3.OwnerActivityName = "GetLogisticsQuotes";
            this.receiveActivity2.ContextToken = contexttoken3;
            this.receiveActivity2.Name = "receiveActivity2";
            activitybind9.Name = "Workflow1";
            activitybind9.Path = "UPSLogisticsQuote";
            workflowparameterbinding9.ParameterName = "lq";
            workflowparameterbinding9.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.receiveActivity2.ParameterBindings.Add(workflowparameterbinding9);
            typedoperationinfo5.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderLogisticsQuotes);
            typedoperationinfo5.Name = "ReceiveLogisticsQuote";
            this.receiveActivity2.ServiceOperationInfo = typedoperationinfo5;
            // 
            // sendActivity1
            // 
            endpoint3.ConfigurationName = "UPSEndPoint";
            endpoint3.Name = "UPSEndPoint";
            this.sendActivity1.Endpoint = endpoint3;
            this.sendActivity1.Name = "sendActivity1";
            activitybind10.Name = "Workflow1";
            activitybind10.Path = "UPSLogisticsAck";
            workflowparameterbinding10.ParameterName = "(ReturnValue)";
            workflowparameterbinding10.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            activitybind11.Name = "Workflow1";
            activitybind11.Path = "ReceivedPO";
            workflowparameterbinding11.ParameterName = "po";
            workflowparameterbinding11.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            activitybind12.Name = "Workflow1";
            activitybind12.Path = "UPSContext";
            workflowparameterbinding12.ParameterName = "context";
            workflowparameterbinding12.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.sendActivity1.ParameterBindings.Add(workflowparameterbinding10);
            this.sendActivity1.ParameterBindings.Add(workflowparameterbinding11);
            this.sendActivity1.ParameterBindings.Add(workflowparameterbinding12);
            typedoperationinfo6.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderLogisticsRequest);
            typedoperationinfo6.Name = "RequestLogisticsQuote";
            this.sendActivity1.ServiceOperationInfo = typedoperationinfo6;
            this.sendActivity1.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareUPSMessage);
            // 
            // USPSQuote
            // 
            this.USPSQuote.Activities.Add(this.sendActivity3);
            this.USPSQuote.Activities.Add(this.receiveActivity4);
            this.USPSQuote.Name = "USPSQuote";
            // 
            // FedExQuote
            // 
            this.FedExQuote.Activities.Add(this.sendActivity2);
            this.FedExQuote.Activities.Add(this.receiveActivity3);
            this.FedExQuote.Name = "FedExQuote";
            // 
            // UPSQuote
            // 
            this.UPSQuote.Activities.Add(this.sendActivity1);
            this.UPSQuote.Activities.Add(this.receiveActivity2);
            this.UPSQuote.Name = "UPSQuote";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // sendActivity4
            // 
            endpoint4.ConfigurationName = "BuyerEndPoint";
            endpoint4.Name = "BuyerEndPoint";
            endpoint4.OwnerActivityName = "";
            this.sendActivity4.Endpoint = endpoint4;
            this.sendActivity4.Name = "sendActivity4";
            activitybind13.Name = "Workflow1";
            activitybind13.Path = "POToCustomer";
            workflowparameterbinding13.ParameterName = "po";
            workflowparameterbinding13.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            activitybind14.Name = "Workflow1";
            activitybind14.Path = "LogisticsQuoteToCustomer";
            workflowparameterbinding14.ParameterName = "lq";
            workflowparameterbinding14.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            activitybind15.Name = "Workflow1";
            activitybind15.Path = "POAcknowledgement";
            workflowparameterbinding15.ParameterName = "(ReturnValue)";
            workflowparameterbinding15.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.sendActivity4.ParameterBindings.Add(workflowparameterbinding13);
            this.sendActivity4.ParameterBindings.Add(workflowparameterbinding14);
            this.sendActivity4.ParameterBindings.Add(workflowparameterbinding15);
            typedoperationinfo7.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IOrderDetails);
            typedoperationinfo7.Name = "ReceiveOrderDetails";
            this.sendActivity4.ServiceOperationInfo = typedoperationinfo7;
            this.sendActivity4.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareCustomerMessage);
            // 
            // GetLogisticsQuotes
            // 
            this.GetLogisticsQuotes.Activities.Add(this.UPSQuote);
            this.GetLogisticsQuotes.Activities.Add(this.FedExQuote);
            this.GetLogisticsQuotes.Activities.Add(this.USPSQuote);
            this.GetLogisticsQuotes.Name = "GetLogisticsQuotes";
            // 
            // receiveActivity1
            // 
            this.receiveActivity1.Activities.Add(this.codeActivity1);
            this.receiveActivity1.CanCreateInstance = true;
            this.receiveActivity1.Name = "receiveActivity1";
            activitybind16.Name = "Workflow1";
            activitybind16.Path = "ReceivedPO";
            workflowparameterbinding16.ParameterName = "po";
            workflowparameterbinding16.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            activitybind17.Name = "Workflow1";
            activitybind17.Path = "POAcknowledgement";
            workflowparameterbinding17.ParameterName = "(ReturnValue)";
            workflowparameterbinding17.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            activitybind18.Name = "Workflow1";
            activitybind18.Path = "BuyerContext";
            workflowparameterbinding18.ParameterName = "BuyerContext";
            workflowparameterbinding18.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding16);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding17);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding18);
            typedoperationinfo8.ContractType = typeof(Microsoft.NetFx35.Silver.Samples.IReceiveOrder);
            typedoperationinfo8.Name = "ReceiveOrder";
            this.receiveActivity1.ServiceOperationInfo = typedoperationinfo8;
            // 
            // Workflow1
            // 
            this.Activities.Add(this.receiveActivity1);
            this.Activities.Add(this.GetLogisticsQuotes);
            this.Activities.Add(this.sendActivity4);
            this.Name = "Workflow1";
            this.SetValue(System.Workflow.Activities.ReceiveActivity.WorkflowServiceAttributesProperty, workflowserviceattributes1);
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeActivity4;
        private CodeActivity codeActivity3;
        private CodeActivity codeActivity2;
        private SendActivity sendActivity4;
        private ReceiveActivity receiveActivity4;
        private SendActivity sendActivity3;
        private ReceiveActivity receiveActivity3;
        private SendActivity sendActivity2;
        private ReceiveActivity receiveActivity2;
        private SendActivity sendActivity1;
        private SequenceActivity USPSQuote;
        private SequenceActivity FedExQuote;
        private SequenceActivity UPSQuote;
        private ParallelActivity GetLogisticsQuotes;
        private CodeActivity codeActivity1;
        private ReceiveActivity receiveActivity1;
















































    }
}
