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

namespace Microsoft.WorkflowServices.Samples
{
	partial class SupplierWorkflow
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
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo7 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding15 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding16 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding17 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo8 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.WorkflowServiceAttributes workflowserviceattributes1 = new System.Workflow.Activities.WorkflowServiceAttributes();
            this.USPSShippingQuote = new System.Workflow.Activities.CodeActivity();
            this.FedexShippingQuote = new System.Workflow.Activities.CodeActivity();
            this.UPSShippingQuote = new System.Workflow.Activities.CodeActivity();
            this.ReceiveQuoteFromUSPS = new System.Workflow.Activities.ReceiveActivity();
            this.RequestQuoteFromUSPS = new System.Workflow.Activities.SendActivity();
            this.ReceiveQuoteFromFedex = new System.Workflow.Activities.ReceiveActivity();
            this.RequestQuoteFromFedex = new System.Workflow.Activities.SendActivity();
            this.ReceiveQuoteFromUPS = new System.Workflow.Activities.ReceiveActivity();
            this.RequestQuoteFromUPS = new System.Workflow.Activities.SendActivity();
            this.USPSQuote = new System.Workflow.Activities.SequenceActivity();
            this.FedExQuote = new System.Workflow.Activities.SequenceActivity();
            this.UPSQuote = new System.Workflow.Activities.SequenceActivity();
            this.DoAcceptOrder = new System.Workflow.Activities.CodeActivity();
            this.SendOrderDetails = new System.Workflow.Activities.SendActivity();
            this.GetShippingQuotes = new System.Workflow.Activities.ParallelActivity();
            this.ReceiveSubmitOrder = new System.Workflow.Activities.ReceiveActivity();
            // 
            // USPSShippingQuote
            // 
            this.USPSShippingQuote.Name = "USPSShippingQuote";
            this.USPSShippingQuote.ExecuteCode += new System.EventHandler(this.ReceiveUSPSShippingQuote);
            // 
            // FedexShippingQuote
            // 
            this.FedexShippingQuote.Name = "FedexShippingQuote";
            this.FedexShippingQuote.ExecuteCode += new System.EventHandler(this.ReceiveFedexShippingQuote);
            // 
            // UPSShippingQuote
            // 
            this.UPSShippingQuote.Name = "UPSShippingQuote";
            this.UPSShippingQuote.ExecuteCode += new System.EventHandler(this.ReceiveUPSShippingQuote);
            // 
            // ReceiveQuoteFromUSPS
            // 
            this.ReceiveQuoteFromUSPS.Activities.Add(this.USPSShippingQuote);
            contexttoken1.Name = "USPSContext";
            contexttoken1.OwnerActivityName = "GetShippingQuotes";
            this.ReceiveQuoteFromUSPS.ContextToken = contexttoken1;
            this.ReceiveQuoteFromUSPS.Name = "ReceiveQuoteFromUSPS";
            activitybind1.Name = "SupplierWorkflow";
            activitybind1.Path = "quoteUSPS";
            workflowparameterbinding1.ParameterName = "quote";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.ReceiveQuoteFromUSPS.ParameterBindings.Add(workflowparameterbinding1);
            typedoperationinfo1.ContractType = typeof(Microsoft.WorkflowServices.Samples.IShippingQuote);
            typedoperationinfo1.Name = "ShippingQuote";
            this.ReceiveQuoteFromUSPS.ServiceOperationInfo = typedoperationinfo1;
            // 
            // RequestQuoteFromUSPS
            // 
            endpoint1.ConfigurationName = "USPSEndpoint";
            endpoint1.Name = "USPSEndpoint";
            endpoint1.OwnerActivityName = "GetShippingQuotes";
            this.RequestQuoteFromUSPS.Endpoint = endpoint1;
            this.RequestQuoteFromUSPS.Name = "RequestQuoteFromUSPS";
            activitybind2.Name = "SupplierWorkflow";
            activitybind2.Path = "order";
            workflowparameterbinding2.ParameterName = "po";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "SupplierWorkflow";
            activitybind3.Path = "contextUSPS";
            workflowparameterbinding3.ParameterName = "context";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "SupplierWorkflow";
            activitybind4.Path = "ackUSPS";
            workflowparameterbinding4.ParameterName = "(ReturnValue)";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.RequestQuoteFromUSPS.ParameterBindings.Add(workflowparameterbinding2);
            this.RequestQuoteFromUSPS.ParameterBindings.Add(workflowparameterbinding3);
            this.RequestQuoteFromUSPS.ParameterBindings.Add(workflowparameterbinding4);
            typedoperationinfo2.ContractType = typeof(Microsoft.WorkflowServices.Samples.IShippingRequest);
            typedoperationinfo2.Name = "RequestShippingQuote";
            this.RequestQuoteFromUSPS.ServiceOperationInfo = typedoperationinfo2;
            this.RequestQuoteFromUSPS.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareUSPSRequest);
            // 
            // ReceiveQuoteFromFedex
            // 
            this.ReceiveQuoteFromFedex.Activities.Add(this.FedexShippingQuote);
            contexttoken2.Name = "FedExContext";
            contexttoken2.OwnerActivityName = "GetShippingQuotes";
            this.ReceiveQuoteFromFedex.ContextToken = contexttoken2;
            this.ReceiveQuoteFromFedex.Name = "ReceiveQuoteFromFedex";
            activitybind5.Name = "SupplierWorkflow";
            activitybind5.Path = "quoteFedEx";
            workflowparameterbinding5.ParameterName = "quote";
            workflowparameterbinding5.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.ReceiveQuoteFromFedex.ParameterBindings.Add(workflowparameterbinding5);
            typedoperationinfo3.ContractType = typeof(Microsoft.WorkflowServices.Samples.IShippingQuote);
            typedoperationinfo3.Name = "ShippingQuote";
            this.ReceiveQuoteFromFedex.ServiceOperationInfo = typedoperationinfo3;
            // 
            // RequestQuoteFromFedex
            // 
            endpoint2.ConfigurationName = "FedExEndpoint";
            endpoint2.Name = "FedExEndpoint";
            endpoint2.OwnerActivityName = "GetShippingQuotes";
            this.RequestQuoteFromFedex.Endpoint = endpoint2;
            this.RequestQuoteFromFedex.Name = "RequestQuoteFromFedex";
            activitybind6.Name = "SupplierWorkflow";
            activitybind6.Path = "order";
            workflowparameterbinding6.ParameterName = "po";
            workflowparameterbinding6.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            activitybind7.Name = "SupplierWorkflow";
            activitybind7.Path = "contextFedEx";
            workflowparameterbinding7.ParameterName = "context";
            workflowparameterbinding7.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            activitybind8.Name = "SupplierWorkflow";
            activitybind8.Path = "ackFedEx";
            workflowparameterbinding8.ParameterName = "(ReturnValue)";
            workflowparameterbinding8.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.RequestQuoteFromFedex.ParameterBindings.Add(workflowparameterbinding6);
            this.RequestQuoteFromFedex.ParameterBindings.Add(workflowparameterbinding7);
            this.RequestQuoteFromFedex.ParameterBindings.Add(workflowparameterbinding8);
            typedoperationinfo4.ContractType = typeof(Microsoft.WorkflowServices.Samples.IShippingRequest);
            typedoperationinfo4.Name = "RequestShippingQuote";
            this.RequestQuoteFromFedex.ServiceOperationInfo = typedoperationinfo4;
            this.RequestQuoteFromFedex.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareFedExRequest);
            // 
            // ReceiveQuoteFromUPS
            // 
            this.ReceiveQuoteFromUPS.Activities.Add(this.UPSShippingQuote);
            contexttoken3.Name = "UPSContext";
            contexttoken3.OwnerActivityName = "GetShippingQuotes";
            this.ReceiveQuoteFromUPS.ContextToken = contexttoken3;
            this.ReceiveQuoteFromUPS.Name = "ReceiveQuoteFromUPS";
            activitybind9.Name = "SupplierWorkflow";
            activitybind9.Path = "quoteUPS";
            workflowparameterbinding9.ParameterName = "quote";
            workflowparameterbinding9.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.ReceiveQuoteFromUPS.ParameterBindings.Add(workflowparameterbinding9);
            typedoperationinfo5.ContractType = typeof(Microsoft.WorkflowServices.Samples.IShippingQuote);
            typedoperationinfo5.Name = "ShippingQuote";
            this.ReceiveQuoteFromUPS.ServiceOperationInfo = typedoperationinfo5;
            // 
            // RequestQuoteFromUPS
            // 
            endpoint3.ConfigurationName = "UPSEndpoint";
            endpoint3.Name = "UPSEndpoint";
            endpoint3.OwnerActivityName = "GetShippingQuotes";
            this.RequestQuoteFromUPS.Endpoint = endpoint3;
            this.RequestQuoteFromUPS.Name = "RequestQuoteFromUPS";
            activitybind10.Name = "SupplierWorkflow";
            activitybind10.Path = "ackUPS";
            workflowparameterbinding10.ParameterName = "(ReturnValue)";
            workflowparameterbinding10.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            activitybind11.Name = "SupplierWorkflow";
            activitybind11.Path = "order";
            workflowparameterbinding11.ParameterName = "po";
            workflowparameterbinding11.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            activitybind12.Name = "SupplierWorkflow";
            activitybind12.Path = "contextUPS";
            workflowparameterbinding12.ParameterName = "context";
            workflowparameterbinding12.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.RequestQuoteFromUPS.ParameterBindings.Add(workflowparameterbinding10);
            this.RequestQuoteFromUPS.ParameterBindings.Add(workflowparameterbinding11);
            this.RequestQuoteFromUPS.ParameterBindings.Add(workflowparameterbinding12);
            typedoperationinfo6.ContractType = typeof(Microsoft.WorkflowServices.Samples.IShippingRequest);
            typedoperationinfo6.Name = "RequestShippingQuote";
            this.RequestQuoteFromUPS.ServiceOperationInfo = typedoperationinfo6;
            this.RequestQuoteFromUPS.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareUPSRequest);
            // 
            // USPSQuote
            // 
            this.USPSQuote.Activities.Add(this.RequestQuoteFromUSPS);
            this.USPSQuote.Activities.Add(this.ReceiveQuoteFromUSPS);
            this.USPSQuote.Name = "USPSQuote";
            // 
            // FedExQuote
            // 
            this.FedExQuote.Activities.Add(this.RequestQuoteFromFedex);
            this.FedExQuote.Activities.Add(this.ReceiveQuoteFromFedex);
            this.FedExQuote.Name = "FedExQuote";
            // 
            // UPSQuote
            // 
            this.UPSQuote.Activities.Add(this.RequestQuoteFromUPS);
            this.UPSQuote.Activities.Add(this.ReceiveQuoteFromUPS);
            this.UPSQuote.Name = "UPSQuote";
            // 
            // DoAcceptOrder
            // 
            this.DoAcceptOrder.Name = "DoAcceptOrder";
            this.DoAcceptOrder.ExecuteCode += new System.EventHandler(this.AcceptOrder);
            // 
            // SendOrderDetails
            // 
            endpoint4.ConfigurationName = "CustomerEndpoint";
            endpoint4.Name = "CustomerEndpoint";
            endpoint4.OwnerActivityName = "SupplierWorkflow";
            this.SendOrderDetails.Endpoint = endpoint4;
            this.SendOrderDetails.Name = "SendOrderDetails";
            activitybind13.Name = "SupplierWorkflow";
            activitybind13.Path = "confirmedQuote";
            workflowparameterbinding13.ParameterName = "quote";
            workflowparameterbinding13.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            activitybind14.Name = "SupplierWorkflow";
            activitybind14.Path = "confirmedOrder";
            workflowparameterbinding14.ParameterName = "po";
            workflowparameterbinding14.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.SendOrderDetails.ParameterBindings.Add(workflowparameterbinding13);
            this.SendOrderDetails.ParameterBindings.Add(workflowparameterbinding14);
            typedoperationinfo7.ContractType = typeof(Microsoft.WorkflowServices.Samples.IOrderDetails);
            typedoperationinfo7.Name = "OrderDetails";
            this.SendOrderDetails.ServiceOperationInfo = typedoperationinfo7;
            this.SendOrderDetails.BeforeSend += new System.EventHandler<System.Workflow.Activities.SendActivityEventArgs>(this.PrepareOrderConfirmation);
            // 
            // GetShippingQuotes
            // 
            this.GetShippingQuotes.Activities.Add(this.UPSQuote);
            this.GetShippingQuotes.Activities.Add(this.FedExQuote);
            this.GetShippingQuotes.Activities.Add(this.USPSQuote);
            this.GetShippingQuotes.Name = "GetShippingQuotes";
            // 
            // ReceiveSubmitOrder
            // 
            this.ReceiveSubmitOrder.Activities.Add(this.DoAcceptOrder);
            this.ReceiveSubmitOrder.CanCreateInstance = true;
            this.ReceiveSubmitOrder.Name = "ReceiveSubmitOrder";
            activitybind15.Name = "SupplierWorkflow";
            activitybind15.Path = "order";
            workflowparameterbinding15.ParameterName = "po";
            workflowparameterbinding15.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            activitybind16.Name = "SupplierWorkflow";
            activitybind16.Path = "customerContext";
            workflowparameterbinding16.ParameterName = "context";
            workflowparameterbinding16.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            activitybind17.Name = "SupplierWorkflow";
            activitybind17.Path = "supplierAck";
            workflowparameterbinding17.ParameterName = "(ReturnValue)";
            workflowparameterbinding17.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            this.ReceiveSubmitOrder.ParameterBindings.Add(workflowparameterbinding15);
            this.ReceiveSubmitOrder.ParameterBindings.Add(workflowparameterbinding16);
            this.ReceiveSubmitOrder.ParameterBindings.Add(workflowparameterbinding17);
            typedoperationinfo8.ContractType = typeof(Microsoft.WorkflowServices.Samples.IOrder);
            typedoperationinfo8.Name = "SubmitOrder";
            this.ReceiveSubmitOrder.ServiceOperationInfo = typedoperationinfo8;
            // 
            // SupplierWorkflow
            // 
            this.Activities.Add(this.ReceiveSubmitOrder);
            this.Activities.Add(this.GetShippingQuotes);
            this.Activities.Add(this.SendOrderDetails);
            this.Name = "SupplierWorkflow";
            this.SetValue(System.Workflow.Activities.ReceiveActivity.WorkflowServiceAttributesProperty, workflowserviceattributes1);
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity USPSShippingQuote;
        private CodeActivity UPSShippingQuote;
        private CodeActivity FedexShippingQuote;
        private SendActivity SendOrderDetails;
        private ReceiveActivity ReceiveQuoteFromUSPS;
        private SendActivity RequestQuoteFromUSPS;
        private ReceiveActivity ReceiveQuoteFromFedex;
        private SendActivity RequestQuoteFromFedex;
        private ReceiveActivity ReceiveQuoteFromUPS;
        private SendActivity RequestQuoteFromUPS;
        private SequenceActivity USPSQuote;
        private SequenceActivity FedExQuote;
        private SequenceActivity UPSQuote;
        private ParallelActivity GetShippingQuotes;
        private CodeActivity DoAcceptOrder;
        private ReceiveActivity ReceiveSubmitOrder;


























    }
}
