'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial class Workflow1

    'NOTE: The following procedure is required by the Workflow Designer
    'It can be modified using the Workflow Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding1 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind2 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding2 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind3 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim activitybind4 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding3 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind5 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding4 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind6 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding5 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind7 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding6 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind8 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding7 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind9 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding8 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind10 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding9 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind11 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding10 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind12 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding11 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind13 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding12 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Me.setStateActivity5 = New System.Workflow.Activities.SetStateActivity
        Me.handleExternalEventActivity6 = New System.Workflow.Activities.HandleExternalEventActivity
        Me.terminateActivity1 = New System.Workflow.ComponentModel.TerminateActivity
        Me.handleExternalEventActivity5 = New System.Workflow.Activities.HandleExternalEventActivity
        Me.setStateActivity4 = New System.Workflow.Activities.SetStateActivity
        Me.handleExternalEventActivity3 = New System.Workflow.Activities.HandleExternalEventActivity
        Me.setStateActivity6 = New System.Workflow.Activities.SetStateActivity
        Me.handleExternalEventActivity4 = New System.Workflow.Activities.HandleExternalEventActivity
        Me.setStateActivity3 = New System.Workflow.Activities.SetStateActivity
        Me.setStateActivity2 = New System.Workflow.Activities.SetStateActivity
        Me.handleExternalEventActivity2 = New System.Workflow.Activities.HandleExternalEventActivity
        Me.setStateActivity1 = New System.Workflow.Activities.SetStateActivity
        Me.handleExternalEventActivity1 = New System.Workflow.Activities.HandleExternalEventActivity
        Me.OrderShippedEvent = New System.Workflow.Activities.EventDrivenActivity
        Me.OrderCanceledEvent = New System.Workflow.Activities.EventDrivenActivity
        Me.OrderUpdatedEvent2 = New System.Workflow.Activities.EventDrivenActivity
        Me.OrderProcessedEvent = New System.Workflow.Activities.EventDrivenActivity
        Me.OrderUpdatedEvent = New System.Workflow.Activities.EventDrivenActivity
        Me.OrderCreatedEvent = New System.Workflow.Activities.EventDrivenActivity
        Me.OrderProcessedState = New System.Workflow.Activities.StateActivity
        Me.OrderCompletedState = New System.Workflow.Activities.StateActivity
        Me.OrderOpenState = New System.Workflow.Activities.StateActivity
        Me.WaitingForOrderState = New System.Workflow.Activities.StateActivity
        '
        'setStateActivity5
        '
        Me.setStateActivity5.Name = "setStateActivity5"
        Me.setStateActivity5.TargetStateName = "OrderCompletedState"
        '
        'handleExternalEventActivity6
        '
        Me.handleExternalEventActivity6.EventName = "OrderShipped"
        Me.handleExternalEventActivity6.InterfaceType = GetType(OrderLocalServices.IOrderService)
        Me.handleExternalEventActivity6.Name = "handleExternalEventActivity6"
        activitybind1.Name = "Workflow1"
        activitybind1.Path = "OrderSender"
        workflowparameterbinding1.ParameterName = "sender"
        workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        activitybind2.Name = "Workflow1"
        activitybind2.Path = "OrderEvtArgs"
        workflowparameterbinding2.ParameterName = "e"
        workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        Me.handleExternalEventActivity6.ParameterBindings.Add(workflowparameterbinding1)
        Me.handleExternalEventActivity6.ParameterBindings.Add(workflowparameterbinding2)
        AddHandler Me.handleExternalEventActivity6.Invoked, AddressOf Me.OrderShipped_Invoked
        activitybind3.Name = "Workflow1"
        activitybind3.Path = "OrderCancelledError"
        '
        'terminateActivity1
        '
        Me.terminateActivity1.Name = "terminateActivity1"
        Me.terminateActivity1.SetBinding(System.Workflow.ComponentModel.TerminateActivity.ErrorProperty, CType(activitybind3, System.Workflow.ComponentModel.ActivityBind))
        '
        'handleExternalEventActivity5
        '
        Me.handleExternalEventActivity5.EventName = "OrderCanceled"
        Me.handleExternalEventActivity5.InterfaceType = GetType(OrderLocalServices.IOrderService)
        Me.handleExternalEventActivity5.Name = "handleExternalEventActivity5"
        activitybind4.Name = "Workflow1"
        activitybind4.Path = "OrderSender"
        workflowparameterbinding3.ParameterName = "sender"
        workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind4, System.Workflow.ComponentModel.ActivityBind))
        activitybind5.Name = "Workflow1"
        activitybind5.Path = "OrderEvtArgs"
        workflowparameterbinding4.ParameterName = "e"
        workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind5, System.Workflow.ComponentModel.ActivityBind))
        Me.handleExternalEventActivity5.ParameterBindings.Add(workflowparameterbinding3)
        Me.handleExternalEventActivity5.ParameterBindings.Add(workflowparameterbinding4)
        '
        'setStateActivity4
        '
        Me.setStateActivity4.Name = "setStateActivity4"
        Me.setStateActivity4.TargetStateName = "OrderOpenState"
        '
        'handleExternalEventActivity3
        '
        Me.handleExternalEventActivity3.EventName = "OrderUpdated"
        Me.handleExternalEventActivity3.InterfaceType = GetType(OrderLocalServices.IOrderService)
        Me.handleExternalEventActivity3.Name = "handleExternalEventActivity3"
        activitybind6.Name = "Workflow1"
        activitybind6.Path = "OrderEvtArgs"
        workflowparameterbinding5.ParameterName = "e"
        workflowparameterbinding5.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind6, System.Workflow.ComponentModel.ActivityBind))
        activitybind7.Name = "Workflow1"
        activitybind7.Path = "OrderSender"
        workflowparameterbinding6.ParameterName = "sender"
        workflowparameterbinding6.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind7, System.Workflow.ComponentModel.ActivityBind))
        Me.handleExternalEventActivity3.ParameterBindings.Add(workflowparameterbinding5)
        Me.handleExternalEventActivity3.ParameterBindings.Add(workflowparameterbinding6)
        '
        'setStateActivity6
        '
        Me.setStateActivity6.Name = "setStateActivity6"
        Me.setStateActivity6.TargetStateName = "OrderProcessedState"
        '
        'handleExternalEventActivity4
        '
        Me.handleExternalEventActivity4.EventName = "OrderProcessed"
        Me.handleExternalEventActivity4.InterfaceType = GetType(OrderLocalServices.IOrderService)
        Me.handleExternalEventActivity4.Name = "handleExternalEventActivity4"
        activitybind8.Name = "Workflow1"
        activitybind8.Path = "OrderEvtArgs"
        workflowparameterbinding7.ParameterName = "e"
        workflowparameterbinding7.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind8, System.Workflow.ComponentModel.ActivityBind))
        activitybind9.Name = "Workflow1"
        activitybind9.Path = "OrderSender"
        workflowparameterbinding8.ParameterName = "sender"
        workflowparameterbinding8.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind9, System.Workflow.ComponentModel.ActivityBind))
        Me.handleExternalEventActivity4.ParameterBindings.Add(workflowparameterbinding7)
        Me.handleExternalEventActivity4.ParameterBindings.Add(workflowparameterbinding8)
        '
        'setStateActivity3
        '
        Me.setStateActivity3.Name = "setStateActivity3"
        Me.setStateActivity3.TargetStateName = "OrderOpenState"
        '
        'setStateActivity2
        '
        Me.setStateActivity2.Name = "setStateActivity2"
        Me.setStateActivity2.TargetStateName = "OrderOpenState"
        '
        'handleExternalEventActivity2
        '
        Me.handleExternalEventActivity2.EventName = "OrderUpdated"
        Me.handleExternalEventActivity2.InterfaceType = GetType(OrderLocalServices.IOrderService)
        Me.handleExternalEventActivity2.Name = "handleExternalEventActivity2"
        activitybind10.Name = "Workflow1"
        activitybind10.Path = "OrderEvtArgs"
        workflowparameterbinding9.ParameterName = "e"
        workflowparameterbinding9.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind10, System.Workflow.ComponentModel.ActivityBind))
        activitybind11.Name = "Workflow1"
        activitybind11.Path = "OrderSender"
        workflowparameterbinding10.ParameterName = "sender"
        workflowparameterbinding10.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind11, System.Workflow.ComponentModel.ActivityBind))
        Me.handleExternalEventActivity2.ParameterBindings.Add(workflowparameterbinding9)
        Me.handleExternalEventActivity2.ParameterBindings.Add(workflowparameterbinding10)
        '
        'setStateActivity1
        '
        Me.setStateActivity1.Name = "setStateActivity1"
        Me.setStateActivity1.TargetStateName = "OrderOpenState"
        '
        'handleExternalEventActivity1
        '
        Me.handleExternalEventActivity1.EventName = "OrderCreated"
        Me.handleExternalEventActivity1.InterfaceType = GetType(OrderLocalServices.IOrderService)
        Me.handleExternalEventActivity1.Name = "handleExternalEventActivity1"
        activitybind12.Name = "Workflow1"
        activitybind12.Path = "OrderEvtArgs"
        workflowparameterbinding11.ParameterName = "e"
        workflowparameterbinding11.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind12, System.Workflow.ComponentModel.ActivityBind))
        activitybind13.Name = "Workflow1"
        activitybind13.Path = "OrderSender"
        workflowparameterbinding12.ParameterName = "sender"
        workflowparameterbinding12.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind13, System.Workflow.ComponentModel.ActivityBind))
        Me.handleExternalEventActivity1.ParameterBindings.Add(workflowparameterbinding11)
        Me.handleExternalEventActivity1.ParameterBindings.Add(workflowparameterbinding12)
        AddHandler Me.handleExternalEventActivity1.Invoked, AddressOf Me.OrderCreated_Invoked
        '
        'OrderShippedEvent
        '
        Me.OrderShippedEvent.Activities.Add(Me.handleExternalEventActivity6)
        Me.OrderShippedEvent.Activities.Add(Me.setStateActivity5)
        Me.OrderShippedEvent.Name = "OrderShippedEvent"
        '
        'OrderCanceledEvent
        '
        Me.OrderCanceledEvent.Activities.Add(Me.handleExternalEventActivity5)
        Me.OrderCanceledEvent.Activities.Add(Me.terminateActivity1)
        Me.OrderCanceledEvent.Name = "OrderCanceledEvent"
        '
        'OrderUpdatedEvent2
        '
        Me.OrderUpdatedEvent2.Activities.Add(Me.handleExternalEventActivity3)
        Me.OrderUpdatedEvent2.Activities.Add(Me.setStateActivity4)
        Me.OrderUpdatedEvent2.Name = "OrderUpdatedEvent2"
        '
        'OrderProcessedEvent
        '
        Me.OrderProcessedEvent.Activities.Add(Me.handleExternalEventActivity4)
        Me.OrderProcessedEvent.Activities.Add(Me.setStateActivity6)
        Me.OrderProcessedEvent.Name = "OrderProcessedEvent"
        '
        'OrderUpdatedEvent
        '
        Me.OrderUpdatedEvent.Activities.Add(Me.handleExternalEventActivity2)
        Me.OrderUpdatedEvent.Activities.Add(Me.setStateActivity2)
        Me.OrderUpdatedEvent.Activities.Add(Me.setStateActivity3)
        Me.OrderUpdatedEvent.Name = "OrderUpdatedEvent"
        '
        'OrderCreatedEvent
        '
        Me.OrderCreatedEvent.Activities.Add(Me.handleExternalEventActivity1)
        Me.OrderCreatedEvent.Activities.Add(Me.setStateActivity1)
        Me.OrderCreatedEvent.Name = "OrderCreatedEvent"
        '
        'OrderProcessedState
        '
        Me.OrderProcessedState.Activities.Add(Me.OrderUpdatedEvent2)
        Me.OrderProcessedState.Activities.Add(Me.OrderCanceledEvent)
        Me.OrderProcessedState.Activities.Add(Me.OrderShippedEvent)
        Me.OrderProcessedState.Name = "OrderProcessedState"
        '
        'OrderCompletedState
        '
        Me.OrderCompletedState.Name = "OrderCompletedState"
        '
        'OrderOpenState
        '
        Me.OrderOpenState.Activities.Add(Me.OrderUpdatedEvent)
        Me.OrderOpenState.Activities.Add(Me.OrderProcessedEvent)
        Me.OrderOpenState.Name = "OrderOpenState"
        '
        'WaitingForOrderState
        '
        Me.WaitingForOrderState.Activities.Add(Me.OrderCreatedEvent)
        Me.WaitingForOrderState.Name = "WaitingForOrderState"
        '
        'Workflow1
        '
        Me.Activities.Add(Me.WaitingForOrderState)
        Me.Activities.Add(Me.OrderOpenState)
        Me.Activities.Add(Me.OrderCompletedState)
        Me.Activities.Add(Me.OrderProcessedState)
        Me.CompletedStateName = "OrderCompletedState"
        Me.DynamicUpdateCondition = Nothing
        Me.InitialStateName = "WaitingForOrderState"
        Me.Name = "Workflow1"
        Me.CanModifyActivities = False

    End Sub
    Private setStateActivity1 As System.Workflow.Activities.SetStateActivity
    Private setStateActivity2 As System.Workflow.Activities.SetStateActivity
    Private handleExternalEventActivity2 As System.Workflow.Activities.HandleExternalEventActivity
    Private OrderUpdatedEvent As System.Workflow.Activities.EventDrivenActivity
    Private setStateActivity3 As System.Workflow.Activities.SetStateActivity
    Private handleExternalEventActivity4 As System.Workflow.Activities.HandleExternalEventActivity
    Private OrderProcessedEvent As System.Workflow.Activities.EventDrivenActivity
    Private setStateActivity6 As System.Workflow.Activities.SetStateActivity
    Private setStateActivity4 As System.Workflow.Activities.SetStateActivity
    Private handleExternalEventActivity3 As System.Workflow.Activities.HandleExternalEventActivity
    Private OrderUpdatedEvent2 As System.Workflow.Activities.EventDrivenActivity
    Private handleExternalEventActivity5 As System.Workflow.Activities.HandleExternalEventActivity
    Private OrderCanceledEvent As System.Workflow.Activities.EventDrivenActivity
    Private terminateActivity1 As System.Workflow.ComponentModel.TerminateActivity
    Private setStateActivity5 As System.Workflow.Activities.SetStateActivity
    Private handleExternalEventActivity6 As System.Workflow.Activities.HandleExternalEventActivity
    Private OrderShippedEvent As System.Workflow.Activities.EventDrivenActivity
    Private OrderCompletedState As System.Workflow.Activities.StateActivity
    Private OrderOpenState As System.Workflow.Activities.StateActivity
    Private OrderProcessedState As System.Workflow.Activities.StateActivity
    Private OrderCreatedEvent As System.Workflow.Activities.EventDrivenActivity
    Private handleExternalEventActivity1 As System.Workflow.Activities.HandleExternalEventActivity
    Private WaitingForOrderState As System.Workflow.Activities.StateActivity


End Class

