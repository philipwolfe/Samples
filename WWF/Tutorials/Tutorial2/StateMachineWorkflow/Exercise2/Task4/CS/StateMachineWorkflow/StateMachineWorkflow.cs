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
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Microsoft.Samples.Workflow.Tutorials.StateMachineWorkflow
{
    [Serializable]
    public class NewOrderEventArgs : ExternalDataEventArgs
    {
        private Guid orderItemId;
        private string orderItem;
        private int orderQuantity;

        public NewOrderEventArgs(Guid itemId, string item, int quantity)
            : base(itemId)
        {
            this.orderItemId = itemId;
            this.orderItem = item;
            this.orderQuantity = quantity;
        }

        public Guid ItemId
        {
            get { return orderItemId; }
            set { orderItemId = value; }
        }

        public string Item
        {
            get { return orderItem; }
            set { orderItem = value; }
        }

        public int Quantity
        {
            get { return orderQuantity; }
            set { orderQuantity = value; }
        }
    }

    [ExternalDataExchange]
    public interface IOrderingService
    {
        void ItemStatusUpdate(Guid orderId, string newStatus);
        event EventHandler<NewOrderEventArgs> NewOrder;
    }

    public class OrderProcessingWorkflow : StateMachineWorkflowActivity
    {
        private StateActivity WaitingForOrderStateActivity;
        private StateActivity OrderProcessingStateActivity;
        private StateActivity OrderCompletedStateActivity;

        // WaitingForOrderStateActivity Activities
        private EventDrivenActivity eventDriven1;
        private HandleExternalEventActivity newOrderExternalEvent;
        private CallExternalMethodActivity updatestatusOrderReceived;
        private SetStateActivity setStateActivityOrderProcessing;
        public NewOrderEventArgs receivedOrderDetails = null;

        public Guid orderId;
        private string orderItem;
        private int orderQuantity;
        public string orderItemStatus;

        public Guid Id
        {
            get
            {
                return this.orderId;
            }
        }

        public string ItemStatus
        {
            get
            {
                return this.orderItemStatus;
            }
        }

        public string Item
        {
            get
            {
                return this.orderItem;
            }
        }
        public OrderProcessingWorkflow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            ActivityBind activitybind1 = new ActivityBind();
            ActivityBind activitybind2 = new ActivityBind();
            ActivityBind activitybind3 = new ActivityBind();
            WorkflowParameterBinding workflowparameterbinding1 = 
                new WorkflowParameterBinding();
            WorkflowParameterBinding workflowparameterbinding2 = 
                new WorkflowParameterBinding();
            WorkflowParameterBinding workflowparameterbinding3 = 
                new WorkflowParameterBinding();

            this.WaitingForOrderStateActivity = new StateActivity();
            this.OrderProcessingStateActivity = new StateActivity();
            this.OrderCompletedStateActivity = new StateActivity();

            // WaitingForOrderStateActivity child activities
            this.eventDriven1 = new EventDrivenActivity();
            this.newOrderExternalEvent = new HandleExternalEventActivity();
            this.updatestatusOrderReceived = new CallExternalMethodActivity();
            this.setStateActivityOrderProcessing = new SetStateActivity();
            // 
            // WaitingForOrderStateActivity
            // 
            this.WaitingForOrderStateActivity.Activities.Add(this.eventDriven1);
            this.WaitingForOrderStateActivity.Name = "WaitingForOrderStateActivity";
            // 
            // OrderProcessingStateActivity
            // 
            this.OrderProcessingStateActivity.Name = "OrderProcessingStateActivity";
            // 
            // OrderCompletedStateActivity
            // 
            this.OrderCompletedStateActivity.Name = "OrderCompletedStateActivity";
            // 
            // eventDriven1
            // 
            this.eventDriven1.Activities.Add(this.newOrderExternalEvent);
            this.eventDriven1.Activities.Add(this.updatestatusOrderReceived);
            this.eventDriven1.Activities.Add(this.setStateActivityOrderProcessing);
            this.eventDriven1.Name = "eventDriven1";
            // 
            // newOrderExternalEvent
            // 
            this.newOrderExternalEvent.EventName = "NewOrder";
            this.newOrderExternalEvent.InterfaceType = typeof(IOrderingService);
            activitybind1.Name = "OrderProcessingWorkflow";
            activitybind1.Path = "receivedOrderDetails";
            workflowparameterbinding1.ParameterName = "e";
            workflowparameterbinding1.SetBinding(
                System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty,
                ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.newOrderExternalEvent.ParameterBindings.Add(workflowparameterbinding1);
            this.newOrderExternalEvent.Name = "newOrderExternalEvent";
            // 
            // updatestatusOrderReceived
            // 
            this.updatestatusOrderReceived.InterfaceType = typeof(IOrderingService);
            this.updatestatusOrderReceived.MethodName = "ItemStatusUpdate";
            this.updatestatusOrderReceived.Name = "updatestatusOrderReceived";
            activitybind2.Name = "OrderProcessingWorkflow";
            activitybind2.Path = "orderId";
            workflowparameterbinding2.ParameterName = "orderId";
            workflowparameterbinding2.SetBinding(WorkflowParameterBinding.ValueProperty,
                ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind3.Name = "OrderProcessingWorkflow";
            activitybind3.Path = "orderItemStatus";
            workflowparameterbinding3.ParameterName = "newStatus";
            workflowparameterbinding3.SetBinding(WorkflowParameterBinding.ValueProperty,
                ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.updatestatusOrderReceived.ParameterBindings.Add
                (workflowparameterbinding2);
            this.updatestatusOrderReceived.ParameterBindings.Add
                (workflowparameterbinding3);
            this.updatestatusOrderReceived.MethodInvoking += 
                new System.EventHandler(this.OrderReceived);
            // 
            // setStateActivityOrderProcessing
            // 
            this.setStateActivityOrderProcessing.Name = 
                "setStateActivityOrderProcessing";
            this.setStateActivityOrderProcessing.TargetStateName = 
                "OrderProcessingStateActivity";
            // 
            // OrderProcessingWorkflow
            // 
            this.Activities.Add(this.WaitingForOrderStateActivity);
            this.Activities.Add(this.OrderProcessingStateActivity);
            this.Activities.Add(this.OrderCompletedStateActivity);
            this.InitialStateName = "WaitingForOrderStateActivity";
            this.CompletedStateName = "OrderCompletedStateActivity";
            this.DynamicUpdateCondition = null;
            this.Name = "OrderProcessingWorkflow";
            this.CanModifyActivities = false;
        }

        private void OrderReceived(object sender, EventArgs e)
        {
            this.orderId = receivedOrderDetails.ItemId;
            this.orderItem = receivedOrderDetails.Item;
            this.orderQuantity = receivedOrderDetails.Quantity;
            this.orderItemStatus = "Received order";
        }
    }
}
