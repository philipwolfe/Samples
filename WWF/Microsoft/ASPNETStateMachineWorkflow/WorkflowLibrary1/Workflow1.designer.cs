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

namespace OrderWorkflows
{
    public sealed partial class Workflow1
    {
		#region Designer generated code
        
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding6 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding7 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding8 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding9 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding10 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding11 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding12 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.WaitingForOrderState = new System.Workflow.Activities.StateActivity();
            this.OrderOpenState = new System.Workflow.Activities.StateActivity();
            this.OrderProcessedState = new System.Workflow.Activities.StateActivity();
            this.OrderCompletedState = new System.Workflow.Activities.StateActivity();
            this.OrderCreatedEvent = new System.Workflow.Activities.EventDrivenActivity();
            this.OrderUpdatedEvent = new System.Workflow.Activities.EventDrivenActivity();
            this.OrderProcessedEvent = new System.Workflow.Activities.EventDrivenActivity();
            this.OrderUpdatedEvent2 = new System.Workflow.Activities.EventDrivenActivity();
            this.OrderCanceled = new System.Workflow.Activities.EventDrivenActivity();
            this.OrderShippedEvent = new System.Workflow.Activities.EventDrivenActivity();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.handleExternalEventActivity2 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setStateActivity2 = new System.Workflow.Activities.SetStateActivity();
            this.handleExternalEventActivity3 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setStateActivity3 = new System.Workflow.Activities.SetStateActivity();
            this.handleExternalEventActivity5 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setStateActivity5 = new System.Workflow.Activities.SetStateActivity();
            this.handleExternalEventActivity4 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.terminateActivity1 = new System.Workflow.ComponentModel.TerminateActivity();
            this.handleExternalEventActivity6 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setStateActivity4 = new System.Workflow.Activities.SetStateActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.setStateActivity6 = new System.Workflow.Activities.SetStateActivity();
            // 
            // WaitingForOrderState
            // 
            this.WaitingForOrderState.Activities.Add(this.OrderCreatedEvent);
            this.WaitingForOrderState.Name = "WaitingForOrderState";
            // 
            // OrderOpenState
            // 
            this.OrderOpenState.Activities.Add(this.OrderUpdatedEvent);
            this.OrderOpenState.Activities.Add(this.OrderProcessedEvent);
            this.OrderOpenState.Activities.Add(this.eventDrivenActivity1);
            this.OrderOpenState.Name = "OrderOpenState";
            // 
            // OrderProcessedState
            // 
            this.OrderProcessedState.Activities.Add(this.OrderUpdatedEvent2);
            this.OrderProcessedState.Activities.Add(this.OrderCanceled);
            this.OrderProcessedState.Activities.Add(this.OrderShippedEvent);
            this.OrderProcessedState.Name = "OrderProcessedState";
            // 
            // OrderCompletedState
            // 
            this.OrderCompletedState.Name = "OrderCompletedState";
            // 
            // OrderCreatedEvent
            // 
            this.OrderCreatedEvent.Activities.Add(this.handleExternalEventActivity1);
            this.OrderCreatedEvent.Activities.Add(this.setStateActivity1);
            this.OrderCreatedEvent.Name = "OrderCreatedEvent";
            // 
            // OrderUpdatedEvent
            // 
            this.OrderUpdatedEvent.Activities.Add(this.handleExternalEventActivity2);
            this.OrderUpdatedEvent.Activities.Add(this.setStateActivity2);
            this.OrderUpdatedEvent.Name = "OrderUpdatedEvent";
            // 
            // OrderProcessedEvent
            // 
            this.OrderProcessedEvent.Activities.Add(this.handleExternalEventActivity3);
            this.OrderProcessedEvent.Activities.Add(this.setStateActivity3);
            this.OrderProcessedEvent.Name = "OrderProcessedEvent";
            // 
            // OrderUpdatedEvent2
            // 
            this.OrderUpdatedEvent2.Activities.Add(this.handleExternalEventActivity5);
            this.OrderUpdatedEvent2.Activities.Add(this.setStateActivity5);
            this.OrderUpdatedEvent2.Name = "OrderUpdatedEvent2";
            // 
            // OrderCanceled
            // 
            this.OrderCanceled.Activities.Add(this.handleExternalEventActivity4);
            this.OrderCanceled.Activities.Add(this.terminateActivity1);
            this.OrderCanceled.Name = "OrderCanceled";
            // 
            // OrderShippedEvent
            // 
            this.OrderShippedEvent.Activities.Add(this.handleExternalEventActivity6);
            this.OrderShippedEvent.Activities.Add(this.setStateActivity4);
            this.OrderShippedEvent.Name = "OrderShippedEvent";
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.EventName = "OrderCreated";
            this.handleExternalEventActivity1.InterfaceType = typeof(OrderLocalServices.IOrderService);
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "OrderSender";
            workflowparameterbinding1.ParameterName = "sender";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "OrderEvtArgs";
            workflowparameterbinding2.ParameterName = "e";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.handleExternalEventActivity1.ParameterBindings.Add(workflowparameterbinding1);
            this.handleExternalEventActivity1.ParameterBindings.Add(workflowparameterbinding2);
            this.handleExternalEventActivity1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OrderCreated_Invoked);
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "OrderOpenState";
            // 
            // handleExternalEventActivity2
            // 
            this.handleExternalEventActivity2.EventName = "OrderUpdated";
            this.handleExternalEventActivity2.InterfaceType = typeof(OrderLocalServices.IOrderService);
            this.handleExternalEventActivity2.Name = "handleExternalEventActivity2";
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "OrderEvtArgs";
            workflowparameterbinding3.ParameterName = "e";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "Workflow1";
            activitybind4.Path = "OrderSender";
            workflowparameterbinding4.ParameterName = "sender";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.handleExternalEventActivity2.ParameterBindings.Add(workflowparameterbinding3);
            this.handleExternalEventActivity2.ParameterBindings.Add(workflowparameterbinding4);
            // 
            // setStateActivity2
            // 
            this.setStateActivity2.Name = "setStateActivity2";
            this.setStateActivity2.TargetStateName = "OrderOpenState";
            // 
            // handleExternalEventActivity3
            // 
            this.handleExternalEventActivity3.EventName = "OrderProcessed";
            this.handleExternalEventActivity3.InterfaceType = typeof(OrderLocalServices.IOrderService);
            this.handleExternalEventActivity3.Name = "handleExternalEventActivity3";
            activitybind5.Name = "Workflow1";
            activitybind5.Path = "OrderEvtArgs";
            workflowparameterbinding5.ParameterName = "e";
            workflowparameterbinding5.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            activitybind6.Name = "Workflow1";
            activitybind6.Path = "OrderSender";
            workflowparameterbinding6.ParameterName = "sender";
            workflowparameterbinding6.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.handleExternalEventActivity3.ParameterBindings.Add(workflowparameterbinding5);
            this.handleExternalEventActivity3.ParameterBindings.Add(workflowparameterbinding6);
            // 
            // setStateActivity3
            // 
            this.setStateActivity3.Name = "setStateActivity3";
            this.setStateActivity3.TargetStateName = "OrderProcessedState";
            // 
            // handleExternalEventActivity5
            // 
            this.handleExternalEventActivity5.EventName = "OrderUpdated";
            this.handleExternalEventActivity5.InterfaceType = typeof(OrderLocalServices.IOrderService);
            this.handleExternalEventActivity5.Name = "handleExternalEventActivity5";
            activitybind7.Name = "Workflow1";
            activitybind7.Path = "OrderEvtArgs";
            workflowparameterbinding7.ParameterName = "e";
            workflowparameterbinding7.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            activitybind8.Name = "Workflow1";
            activitybind8.Path = "OrderSender";
            workflowparameterbinding8.ParameterName = "sender";
            workflowparameterbinding8.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.handleExternalEventActivity5.ParameterBindings.Add(workflowparameterbinding7);
            this.handleExternalEventActivity5.ParameterBindings.Add(workflowparameterbinding8);
            // 
            // setStateActivity5
            // 
            this.setStateActivity5.Name = "setStateActivity5";
            this.setStateActivity5.TargetStateName = "OrderOpenState";
            // 
            // handleExternalEventActivity4
            // 
            this.handleExternalEventActivity4.EventName = "OrderCanceled";
            this.handleExternalEventActivity4.InterfaceType = typeof(OrderLocalServices.IOrderService);
            this.handleExternalEventActivity4.Name = "handleExternalEventActivity4";
            activitybind9.Name = "Workflow1";
            activitybind9.Path = "OrderEvtArgs";
            workflowparameterbinding9.ParameterName = "e";
            workflowparameterbinding9.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            activitybind10.Name = "Workflow1";
            activitybind10.Path = "OrderSender";
            workflowparameterbinding10.ParameterName = "sender";
            workflowparameterbinding10.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.handleExternalEventActivity4.ParameterBindings.Add(workflowparameterbinding9);
            this.handleExternalEventActivity4.ParameterBindings.Add(workflowparameterbinding10);
            activitybind11.Name = "Workflow1";
            activitybind11.Path = "OrderCanceledError";
            // 
            // terminateActivity1
            // 
            this.terminateActivity1.Name = "terminateActivity1";
            this.terminateActivity1.SetBinding(System.Workflow.ComponentModel.TerminateActivity.ErrorProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // handleExternalEventActivity6
            // 
            this.handleExternalEventActivity6.EventName = "OrderShipped";
            this.handleExternalEventActivity6.InterfaceType = typeof(OrderLocalServices.IOrderService);
            this.handleExternalEventActivity6.Name = "handleExternalEventActivity6";
            activitybind12.Name = "Workflow1";
            activitybind12.Path = "OrderEvtArgs";
            workflowparameterbinding11.ParameterName = "e";
            workflowparameterbinding11.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            activitybind13.Name = "Workflow1";
            activitybind13.Path = "OrderSender";
            workflowparameterbinding12.ParameterName = "sender";
            workflowparameterbinding12.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.handleExternalEventActivity6.ParameterBindings.Add(workflowparameterbinding11);
            this.handleExternalEventActivity6.ParameterBindings.Add(workflowparameterbinding12);
            this.handleExternalEventActivity6.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OrderShipped_Invoked);
            // 
            // setStateActivity4
            // 
            this.setStateActivity4.Name = "setStateActivity4";
            this.setStateActivity4.TargetStateName = "OrderCompletedState";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.delayActivity1);
            this.eventDrivenActivity1.Activities.Add(this.setStateActivity6);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:10");
            // 
            // setStateActivity6
            // 
            this.setStateActivity6.Name = "setStateActivity6";
            this.setStateActivity6.TargetStateName = "OrderCompletedState";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.WaitingForOrderState);
            this.Activities.Add(this.OrderOpenState);
            this.Activities.Add(this.OrderProcessedState);
            this.Activities.Add(this.OrderCompletedState);
            this.CompletedStateName = "OrderCompletedState";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "WaitingForOrderState";
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private EventDrivenActivity eventDrivenActivity1;
        private DelayActivity delayActivity1;
        private SetStateActivity setStateActivity6;
        private EventDrivenActivity OrderShippedEvent;
        private HandleExternalEventActivity handleExternalEventActivity6;
        private SetStateActivity setStateActivity4;
        private TerminateActivity terminateActivity1;
        private SetStateActivity setStateActivity1;
        private EventDrivenActivity OrderUpdatedEvent;
        private HandleExternalEventActivity handleExternalEventActivity2;
        private SetStateActivity setStateActivity2;
        private EventDrivenActivity OrderProcessedEvent;
        private HandleExternalEventActivity handleExternalEventActivity3;
        private SetStateActivity setStateActivity3;
        private EventDrivenActivity OrderUpdatedEvent2;
        private HandleExternalEventActivity handleExternalEventActivity5;
        private SetStateActivity setStateActivity5;
        private EventDrivenActivity OrderCanceled;
        private HandleExternalEventActivity handleExternalEventActivity4;
        private StateActivity OrderOpenState;
        private StateActivity OrderProcessedState;
        private StateActivity OrderCompletedState;
        private EventDrivenActivity OrderCreatedEvent;
        private HandleExternalEventActivity handleExternalEventActivity1;
        private StateActivity WaitingForOrderState;






































    }
}
