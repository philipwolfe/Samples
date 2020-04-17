'--------------------------------------------------------------------------------
' This file is part of the Windows Workflow Foundation Sample Code
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

Imports System.Xml
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Workflow.Activities
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Hosting
Imports System.Workflow.Runtime.Tracking
Imports WorkflowLibrary1
Partial Class Order
    Inherits System.Web.UI.Page

    Private Sub StartWorkflow()
        Dim workflowRuntime As WorkflowRuntime = GetRuntimeAndSubscribeWorkflowCompleted()

        '   Now get a reference to the ManualWorkflowSchedulerService
        Dim scheduler As ManualWorkflowSchedulerService = workflowRuntime.GetService(Of ManualWorkflowSchedulerService)()

        Dim reader As XmlReader = XmlReader.Create(Page.MapPath("Workflow1.xoml"))

        Dim workflowInstance As WorkflowInstance = workflowRuntime.CreateWorkflow(reader)

        workflowInstance.Start()

        '   Now run the workflow.  This is necessary when 
        '   ...using the ManualWorkflowSchedulerService
        scheduler.RunWorkflow(workflowInstance.InstanceId)

        lblWorkflowInstanceId.Text = workflowInstance.InstanceId.ToString()
        lblOrderStatus.Text = GetCurrentState(workflowInstance.InstanceId)
    End Sub

    Private Function GetRuntimeAndSubscribeWorkflowCompleted() As WorkflowRuntime
        Dim workflowRuntime As WorkflowRuntime = Application("WorkflowRuntime")

        AddHandler workflowRuntime.WorkflowCompleted, AddressOf Me.WorkflowRuntime_WorkflowCompleted

        Return workflowRuntime
    End Function

    Sub WorkflowRuntime_WorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
        ' Release the WorkflowCompleted event
        RemoveHandler e.WorkflowInstance.WorkflowRuntime.WorkflowCompleted, AddressOf Me.WorkflowRuntime_WorkflowCompleted
        HttpContext.Current.Response.Redirect(String.Format("OrderCompleted.aspx?OrderNumber={0}&InstanceID={1}", txtOrderNumber.Text, lblWorkflowInstanceId.Text), False)
    End Sub

    Private Function GetCurrentState(ByVal instanceId As Guid) As String
        Dim stateInstance As StateMachineWorkflowInstance = New StateMachineWorkflowInstance(Application("WorkflowRuntime"), instanceId)

        Return stateInstance.CurrentStateName
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim orderNumber As String = HttpContext.Current.Request.QueryString("OrderNumber")

        If Not IsPostBack Then
            If orderNumber Is Nothing Then
                lblWorkflowInstanceId.Text = String.Empty
                StartWorkflow()
                btnCreateOrder.Enabled = True
            Else
                GetRuntimeAndSubscribeWorkflowCompleted()
                lblWorkflowInstanceId.Text = orderNumber
                lblOrderStatus.Text = GetCurrentState(New Guid(orderNumber))
                txtOrderNumber.Text = GetOrderNumber(orderNumber)

                Select Case lblOrderStatus.Text
                    Case "WaitingForOrderState"
                        btnCreateOrder.Enabled = True
                    Case "OrderOpenState"
                        btnProcessOrder.Enabled = True
                    Case "OrderProcessedState"
                        btnShipOrder.Enabled = True
                End Select
            End If
        End If
    End Sub

    Private Function GetOrderNumber(ByVal orderId As String) As String

        Dim queriedWorkflows As IList(Of SqlTrackingWorkflowInstance) = New List(Of SqlTrackingWorkflowInstance)()

        Dim sqlTrackingQuery As SqlTrackingQuery = New SqlTrackingQuery(ConfigurationManager.ConnectionStrings("SharedStoreConnectionString").ConnectionString)

        queriedWorkflows = sqlTrackingQuery.GetWorkflows(New SqlTrackingQueryOptions())

        For Each sqlTrackingWorkflowInstance As SqlTrackingWorkflowInstance In queriedWorkflows
            If sqlTrackingWorkflowInstance.WorkflowInstanceId.ToString().Equals(orderId) Then
                Dim records As IList(Of ActivityTrackingRecord) = sqlTrackingWorkflowInstance.ActivityEvents
                Dim record As ActivityTrackingRecord = records(records.Count - 1)

                Dim ordEventArgs As WorkflowLibrary1.OrderEventArgs = record.Body(0).Data

                If ordEventArgs Is Nothing Then Exit For
                Return ordEventArgs.OrderId
            End If
        Next
        '  If we didn't find it send back the default value.
        Return "12345"
    End Function

    Protected Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShipOrder.Click, btnProcessOrder.Click, btnCreateOrder.Click
        Dim currentButton As Button = sender
        Dim instanceId As Guid = New Guid(Me.lblWorkflowInstanceId.Text)
        Dim workflowRuntime As WorkflowRuntime = Application("WorkflowRuntime")
        Dim orderService As OrderService = workflowRuntime.GetService(Of OrderService)()
        Dim scheduler As ManualWorkflowSchedulerService = workflowRuntime.GetService(Of ManualWorkflowSchedulerService)()

        If currentButton.Enabled Then
            Select Case currentButton.ID
                Case "btnCreateOrder"
                    currentButton.Enabled = False

                    orderService.RaiseOrderCreatedEvent(txtOrderNumber.Text, instanceId)
                    scheduler.RunWorkflow(instanceId)
                    lblOrderStatus.Text = GetCurrentState(instanceId)

                    btnProcessOrder.Enabled = True
                Case "btnProcessOrder"
                    currentButton.Enabled = False

                    orderService.RaiseOrderProcessedEvent(txtOrderNumber.Text, instanceId)
                    scheduler.RunWorkflow(instanceId)
                    lblOrderStatus.Text = GetCurrentState(instanceId)

                    btnShipOrder.Enabled = True
                Case "btnShipOrder"
                    currentButton.Enabled = False

                    orderService.RaiseOrderShippedEvent(txtOrderNumber.Text, instanceId)
                    scheduler.RunWorkflow(instanceId)
            End Select
        End If
    End Sub
End Class
