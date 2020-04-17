'---------------------------------------------------------------------
'  This file is part of the Windows Workflow Foundation SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Drawing
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules

Namespace Microsoft.Samples.Workflow.Tutorials.StateMachineWorkflow
    <Serializable()> _
       Public Class NewOrderEventArgs : Inherits ExternalDataEventArgs
        Private orderItemId As Guid
        Private orderItem As String
        Private orderQuantity As Integer

        Public Sub New(ByVal itemId As Guid, ByVal item As String, _
            ByVal quantity As Integer)
            MyBase.New(itemId)
            Me.orderItemId = itemId
            Me.orderItem = item
            Me.orderQuantity = quantity
        End Sub

        Public Property ItemId() As Guid
            Get
                Return orderItemId
            End Get
            Set(ByVal value As Guid)
                orderItemId = Value
            End Set
        End Property

        Public Property Item() As String
            Get
                Return orderItem
            End Get
            Set(ByVal value As String)
                orderItem = Value
            End Set
        End Property

        Public Property Quantity() As Integer
            Get
                Return orderQuantity
            End Get
            Set(ByVal value As Integer)
                orderQuantity = Value
            End Set
        End Property
    End Class

    <ExternalDataExchange()> _
       Public Interface IOrderingService
        Sub ItemStatusUpdate(ByVal orderId As Guid, ByVal newStatus As String)
        Event NewOrder As EventHandler(Of NewOrderEventArgs)
    End Interface

    Public Class OrderProcessingWorkflow : Inherits StateMachineWorkflowActivity
        Private WaitingForOrderStateActivity As StateActivity
        Private OrderProcessingStateActivity As StateActivity
        Private OrderCompletedStateActivity As StateActivity

        Private eventDriven1 As EventDrivenActivity
        Private newOrderExternalEvent As HandleExternalEventActivity
        Private updatestatusOrderReceived As CallExternalMethodActivity
        Private setStateActivityOrderProcessing As SetStateActivity
        Public receivedOrderDetails As NewOrderEventArgs

        ' OrderProcessingStateActivity Activities
        Private initializeOrderOpenStateActivity As StateInitializationActivity
        Private invokeProcessingNewOrderStatusUpdate As CallExternalMethodActivity
        Private invokeOrderProcessedStatusUpdate As CallExternalMethodActivity
        Private setStateActivityOrderCompleted As SetStateActivity

        Public orderId As Guid
        Private orderItem As String
        Private orderQuantity As Integer
        Public orderItemStatus As String

        Public ReadOnly Property Id() As Guid
            Get
                Return Me.orderId
            End Get
        End Property

        Public ReadOnly Property ItemStatus() As String
            Get
                Return Me.orderItemStatus
            End Get
        End Property

        Public ReadOnly Property Item() As String
            Get
                Return Me.orderItem
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.CanModifyActivities = True
            Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = _
                New System.Workflow.ComponentModel.ActivityBind()
            Dim activitybind2 As System.Workflow.ComponentModel.ActivityBind = _
                New System.Workflow.ComponentModel.ActivityBind()
            Dim activitybind3 As System.Workflow.ComponentModel.ActivityBind = _
                New System.Workflow.ComponentModel.ActivityBind()
            Dim workflowparameterbinding1 As _
                System.Workflow.ComponentModel.WorkflowParameterBinding = _
                New System.Workflow.ComponentModel.WorkflowParameterBinding()
            Dim workflowparameterbinding2 As _
                System.Workflow.ComponentModel.WorkflowParameterBinding = _
                New System.Workflow.ComponentModel.WorkflowParameterBinding()
            Dim workflowparameterbinding3 As _
            System.Workflow.ComponentModel.WorkflowParameterBinding = _
            New System.Workflow.ComponentModel.WorkflowParameterBinding()

            Me.WaitingForOrderStateActivity = New _
                System.Workflow.Activities.StateActivity()
            Me.OrderProcessingStateActivity = New _
                System.Workflow.Activities.StateActivity()
            Me.OrderCompletedStateActivity = New _
                System.Workflow.Activities.StateActivity()

            ' WaitingForOrderStateActivity Activities
            Me.eventDriven1 = New System.Workflow.Activities.EventDrivenActivity()
            Me.newOrderExternalEvent = New _
                System.Workflow.Activities.HandleExternalEventActivity()
            Me.updatestatusOrderReceived = New _
                System.Workflow.Activities.CallExternalMethodActivity()
            Me.setStateActivityOrderProcessing = New _
                System.Workflow.Activities.SetStateActivity()

            ' OrderProcessingStateActivity Activities
            Me.initializeOrderOpenStateActivity = New _
                System.Workflow.Activities.StateInitializationActivity()
            Me.invokeProcessingNewOrderStatusUpdate = New _
                System.Workflow.Activities.CallExternalMethodActivity()
            Me.invokeOrderProcessedStatusUpdate = New _
                System.Workflow.Activities.CallExternalMethodActivity()
            Me.setStateActivityOrderCompleted = New _
                System.Workflow.Activities.SetStateActivity()
            ' 
            ' WaitingForOrderStateActivity
            ' 
            Me.WaitingForOrderStateActivity.Activities.Add(Me.eventDriven1)
            Me.WaitingForOrderStateActivity.Name = "WaitingForOrderStateActivity"
            ' 
            ' OrderProcessingStateActivity
            ' 
            Me.OrderProcessingStateActivity.Activities.Add _
                (Me.initializeOrderOpenStateActivity)
            Me.OrderProcessingStateActivity.Name = "OrderProcessingStateActivity"
            ' 
            ' OrderCompletedStateActivity
            ' 
            Me.OrderCompletedStateActivity.Name = "OrderCompletedStateActivity"
            ' 
            ' eventDriven1
            ' 
            Me.eventDriven1.Activities.Add(Me.newOrderExternalEvent)
            Me.eventDriven1.Activities.Add(Me.updatestatusOrderReceived)
            Me.eventDriven1.Activities.Add(Me.setStateActivityOrderProcessing)
            Me.eventDriven1.Name = "eventDriven1"
            ' 
            ' newOrderExternalEvent
            ' 
            Me.newOrderExternalEvent.EventName = "NewOrder"
            Me.newOrderExternalEvent.InterfaceType = _
                GetType(StateMachineWorkflow.IOrderingService)
            Me.newOrderExternalEvent.Name = "newOrderExternalEvent"
            activitybind1.Name = "OrderProcessingWorkflow"
            activitybind1.Path = "receivedOrderDetails"
            workflowparameterbinding1.ParameterName = "e"
            workflowparameterbinding1.SetBinding( _
                System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, _
                (CType(activitybind1, System.Workflow.ComponentModel.ActivityBind)))
            Me.newOrderExternalEvent.ParameterBindings.Add(workflowparameterbinding1)
            ' 
            ' updatestatusOrderReceived
            ' 
            Me.updatestatusOrderReceived.InterfaceType = _
                GetType(StateMachineWorkflow.IOrderingService)
            Me.updatestatusOrderReceived.MethodName = "ItemStatusUpdate"
            Me.updatestatusOrderReceived.Name = "updatestatusOrderReceived"
            activitybind2.Name = "OrderProcessingWorkflow"
            activitybind2.Path = "orderId"
            workflowparameterbinding2.ParameterName = "orderId"
            workflowparameterbinding2.SetBinding( _
                System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, _
                (CType(activitybind2, System.Workflow.ComponentModel.ActivityBind)))
            activitybind3.Name = "OrderProcessingWorkflow"
            activitybind3.Path = "orderItemStatus"
            workflowparameterbinding3.ParameterName = "newStatus"
            workflowparameterbinding3.SetBinding( _
                System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, _
                (CType(activitybind3, System.Workflow.ComponentModel.ActivityBind)))
            Me.updatestatusOrderReceived.ParameterBindings.Add(workflowparameterbinding2)
            Me.updatestatusOrderReceived.ParameterBindings.Add(workflowparameterbinding3)
            AddHandler updatestatusOrderReceived.MethodInvoking, _
                AddressOf Me.OrderReceived
            ' 
            ' setStateActivityOrderProcessing
            ' 
            Me.setStateActivityOrderProcessing.Name = "setStateActivityOrderProcessing"
            Me.setStateActivityOrderProcessing.TargetStateName = _
                "OrderProcessingStateActivity"
            ' 
            ' initializeOrderOpenStateActivity
            ' 
            Me.initializeOrderOpenStateActivity.Activities.Add _
                (Me.invokeProcessingNewOrderStatusUpdate)
            Me.initializeOrderOpenStateActivity.Activities.Add _
                (Me.invokeOrderProcessedStatusUpdate)
            Me.initializeOrderOpenStateActivity.Activities.Add _
                (Me.setStateActivityOrderCompleted)
            Me.initializeOrderOpenStateActivity.Name = "initializeOrderOpenStateActivity"
            ' 
            ' invokeProcessingNewOrderStatusUpdate
            ' 
            Me.invokeProcessingNewOrderStatusUpdate.InterfaceType = _
                GetType(StateMachineWorkflow.IOrderingService)
            Me.invokeProcessingNewOrderStatusUpdate.MethodName = "ItemStatusUpdate"
            Me.invokeProcessingNewOrderStatusUpdate.ParameterBindings.Add _
                (workflowparameterbinding2)
            Me.invokeProcessingNewOrderStatusUpdate.ParameterBindings.Add _
                (workflowparameterbinding3)
            AddHandler invokeProcessingNewOrderStatusUpdate.MethodInvoking, _
                AddressOf ProcessNewOrder
            Me.invokeProcessingNewOrderStatusUpdate.Name = _
                "invokeProcessingNewOrderStatusUpdate"
            ' 
            ' invokeOrderProcessedStatusUpdate
            ' 
            Me.invokeOrderProcessedStatusUpdate.InterfaceType = _
                GetType(StateMachineWorkflow.IOrderingService)
            Me.invokeOrderProcessedStatusUpdate.MethodName = "ItemStatusUpdate"
            Me.invokeOrderProcessedStatusUpdate.ParameterBindings.Add _
                (workflowparameterbinding2)
            Me.invokeOrderProcessedStatusUpdate.ParameterBindings.Add _
                (workflowparameterbinding3)
            AddHandler invokeOrderProcessedStatusUpdate.MethodInvoking, _
                AddressOf FinalizeOrder
            Me.invokeOrderProcessedStatusUpdate.Name = "invokeOrderProcessedStatusUpdate"
            ' 
            ' setStateActivityOrderCompleted
            ' 
            Me.setStateActivityOrderCompleted.Name = "setStateActivityOrderCompleted"
            Me.setStateActivityOrderCompleted.TargetStateName = _
                "OrderCompletedStateActivity"
            ' 
            ' OrderProcessingWorkflow
            ' 
            Me.Activities.Add(Me.WaitingForOrderStateActivity)
            Me.Activities.Add(Me.OrderProcessingStateActivity)
            Me.Activities.Add(Me.OrderCompletedStateActivity)
            Me.InitialStateName = "WaitingForOrderStateActivity"
            Me.CompletedStateName = "OrderCompletedStateActivity"
            Me.DynamicUpdateCondition = Nothing
            Me.Name = "OrderProcessingWorkflow"
            Me.CanModifyActivities = False
        End Sub

        Private Sub OrderReceived(ByVal sender As Object, ByVal e As EventArgs)
            Me.orderId = receivedOrderDetails.ItemId
            Me.orderItem = receivedOrderDetails.Item
            Me.orderQuantity = receivedOrderDetails.Quantity
            Me.orderItemStatus = "Received order"
        End Sub

        Private Sub ProcessNewOrder(ByVal sender As Object, ByVal e As EventArgs)
            Me.orderItemStatus = "Processing order"
        End Sub

        Private Sub FinalizeOrder(ByVal sender As Object, ByVal e As EventArgs)
            Me.orderItemStatus = "Order processed"
        End Sub

    End Class
End Namespace
