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

Imports System.Workflow.ComponentModel
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Hosting
Imports System.Workflow.Activities
Imports System.Threading
Imports StateMachineTracking

Public Class Form1
    Private _WFRuntime As WorkflowRuntime
    Private _OrderService As OrderLocalServices.OrderService
    Private stateMachineTrackingService As StateMachineTrackingService
    Private stateMachineInstances As Dictionary(Of String, StateMachineInstance)
    Private Delegate Sub UpdateListItemDelegate(ByVal wfinstance As WorkflowInstance, ByVal WorkflowState As String, ByVal WorkflowStatus As String)
    Private Delegate Sub UpdateButtonStatusDelegate()

    Private Sub StartWorkflowRuntime()

        ' Create a new Workflow Runtime for this application
        _WFRuntime = New WorkflowRuntime()

        ' Create EventHandlers for the WorkflowRuntime
        AddHandler _WFRuntime.WorkflowCompleted, AddressOf WorkflowRuntime_WorkflowCompleted
        AddHandler _WFRuntime.WorkflowTerminated, AddressOf WorkflowRuntime_WorkflowTerminated

        stateMachineTrackingService = New StateMachineTrackingService(_WFRuntime)

        ' Add a new instance of the OrderService to the runtime
        Dim dataService As ExternalDataExchangeService = New ExternalDataExchangeService()
        _WFRuntime.AddService(dataService)
        _OrderService = New OrderLocalServices.OrderService()
        dataService.AddService(_OrderService)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.stateMachineInstances = New Dictionary(Of String, StateMachineInstance)()
        Me.DisableButtons()
        Me.StartWorkflowRuntime()

    End Sub

    Sub WorkflowRuntime_WorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)

        Me.UpdateListItem(e.WorkflowInstance, "", "Completed")

    End Sub

    Sub WorkflowRuntime_WorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)

        Me.UpdateListItem(e.WorkflowInstance, "", "Terminated")

    End Sub

    Private Sub btnOrderCreated_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrderCreated.Click

        ' Get the OrderId that was entered by the user
        Dim strOrderId As String = Me.txtOrderID.Text

        ' Start the Order Workflow
        Dim WorkflowInstanceId As System.Guid = _
        Me.StartOrderWorkflow(strOrderId)

        ' Raise an OrderCreated event using the Order Local Service
        _OrderService.RaiseOrderCreatedEvent(strOrderId, WorkflowInstanceId)

        ' Add a new item to the ListView for the new workflow
        AddListViewItem(strOrderId, WorkflowInstanceId)

        ' Reset the form for adding another Order
        Me.txtOrderID.Text = ""

    End Sub

    Private Function StartOrderWorkflow(ByVal strOrderID As String) As System.Guid

        ' Create a new GUID for the WorkflowInstanceId
        Dim WorkflowInstanceId As System.Guid = System.Guid.NewGuid()


        Dim stateMachineInstance As StateMachineInstance = _
        stateMachineTrackingService.RegisterInstance(GetType(OrderWorkflows.Workflow1), WorkflowInstanceId)
        AddHandler stateMachineInstance.StateChanged, AddressOf StateMachineInstance_StateChanged


        stateMachineInstance.StartWorkflow()
        stateMachineInstances.Add(WorkflowInstanceId.ToString(), _
                                       stateMachineInstance)

        

        ' Return the WorkflowInstanceId
        Return WorkflowInstanceId

    End Function

    Private Function AddListViewItem(ByVal strOrderID As String, ByVal WorkflowInstanceId As System.Guid) As ListViewItem

        ' Add a new item to the Listview control using the WorkflowInstanceId
        ' ...as the Text and Key value
        Dim lstvwitem As ListViewItem = _
        Me.lstvwOrders.Items.Add(WorkflowInstanceId.ToString(), _
                                WorkflowInstanceId.ToString(), "")

        ' add the OrderId, Workflow State, and Workflow Status columns
        lstvwitem.SubItems.Add(txtOrderID.Text)
        lstvwitem.SubItems.Add("")
        lstvwitem.SubItems.Add("")
        lstvwitem.Tag = WorkflowInstanceId.ToString()

        ' Select the new ListItem, which will cause the buttons to refresh.
        lstvwitem.Selected = True

        ' Return the new ListViewItem
        Return lstvwitem

    End Function
    Private Function GetSelectedWorkflowInstanceID() As System.Guid

        If Me.lstvwOrders.SelectedItems.Count = 0 Then

            Throw New ApplicationException("No Orders are selected")

        End If

        ' Get the WorkflowInstanceId for the selected ListItem
        Dim strWorkflowInstanceId As String = _
        Me.lstvwOrders.SelectedItems(0).Text()

        ' Create a new GUID for the WorkflowInstanceID
        Return New System.Guid(strWorkflowInstanceId)

    End Function

    Private Function GetSelectedOrderId() As String

        If Me.lstvwOrders.SelectedItems.Count = 0 Then
            Throw New ApplicationException("No Orders are selected")
        End If

        ' Get the OrderID for the selected order
        Return Me.lstvwOrders.SelectedItems(0).SubItems(1).Text

    End Function

    Private Sub btnOrderEvent_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOrderUpdated.Click, btnOrderShipped.Click, btnOrderProcessed.Click, btnOrderCanceled.Click
        ' Get the Name for the button that was clicked
        Dim strButtonName As String = (CType(sender, Button)).Name

        ' Get the WorkflowInstanceId for the selected order
        Dim WorkflowInstanceId As System.Guid = Me.GetSelectedWorkflowInstanceID()

        ' Get the OrderID for the selected order
        Dim strOrderId As String = Me.GetSelectedOrderId()

        Me.DisableButtons()

        Select Case strButtonName
            Case "btnOrderShipped"
                ' Raise an OrderShipped event using the Order Local Service
                _OrderService.RaiseOrderShippedEvent(strOrderId, WorkflowInstanceId)
                Exit Sub


            Case "btnOrderUpdated"
                ' Raise an OrderUpdated event using the Order Local Service
                _OrderService.RaiseOrderUpdatedEvent(strOrderId, WorkflowInstanceId)
                Exit Sub

            Case "btnOrderCanceled"
                ' Raise an OrderCanceled event using the Order Local Service
                _OrderService.RaiseOrderCanceledEvent(strOrderId, WorkflowInstanceId)
                Exit Sub


            Case "btnOrderProcessed"
                ' Raise an OrderProcessed event using the Order Local Service
                _OrderService.RaiseOrderProcessedEvent(strOrderId, WorkflowInstanceId)
                Exit Sub
        End Select
    End Sub

    Private Sub UpdateListItem(ByVal wfinstance As WorkflowInstance, ByVal WorkflowState As String, ByVal WorkflowStatus As String)


        If (Me.lstvwOrders.InvokeRequired) Then

            ' This code is executing on a different thread than the one that
            ' ...created the ListView, so we need to use the Invoke method.

            ' Create an instance of the delegate for invoking this method
            Dim dlgtUpdateListViewItem As UpdateListItemDelegate = _
            New UpdateListItemDelegate(AddressOf Me.UpdateListItem)

            ' Create the array of parameters for this method
            Dim args() As Object = New Object(2) {wfinstance, WorkflowState, WorkflowStatus}


            ' Invoke this method on the UI thread
            Me.lstvwOrders.Invoke(dlgtUpdateListViewItem, args)

        Else

            ' Get the ListViewItem for the specified WorkflowInstance
            Dim strInstanceId As String = wfinstance.InstanceId.ToString()
            Dim lvitemOrder As ListViewItem = lstvwOrders.Items(strInstanceId)

            If (lvitemOrder Is Nothing) Then

                Return
            End If


            ' Update the Workflow State & Status column values
            lvitemOrder.SubItems(2).Text = WorkflowState
            lvitemOrder.SubItems(3).Text = WorkflowStatus
            End If

    End Sub
    Private Sub DisableButtons()
        Me.btnOrderCanceled.Enabled = False
        Me.btnOrderProcessed.Enabled = False
        Me.btnOrderShipped.Enabled = False
        Me.btnOrderUpdated.Enabled = False
    End Sub

    Private Sub EnableButtons()

        If Me.lstvwOrders.SelectedItems.Count = 0 Then
            Return
        End If

        Dim workflowStatus As String = _
        Me.lstvwOrders.SelectedItems(0).SubItems(3).Text()

        If (workflowStatus.Equals("Completed") Or workflowStatus.Equals("Terminated")) Then
            Return
        End If


        ' Return the StateMachineInstance object 
        Dim stateMachineInstance As StateMachineInstance = _
        Me.GetSelectedStateMachineInstance()

        If StateMachineInstance.CurrentState Is Nothing Then
            Return
        End If


        If StateMachineInstance.MessagesAllowed.Contains("OrderCanceled") Then
            Me.btnOrderCanceled.Enabled = True
        End If

        If StateMachineInstance.MessagesAllowed.Contains("OrderProcessed") Then
            Me.btnOrderProcessed.Enabled = True
        End If

        If StateMachineInstance.MessagesAllowed.Contains("OrderShipped") Then
            Me.btnOrderShipped.Enabled = True
        End If

        If StateMachineInstance.MessagesAllowed.Contains("OrderUpdated") Then
            Me.btnOrderUpdated.Enabled = True
        End If

    End Sub
    Private Function GetSelectedStateMachineInstance() As StateMachineInstance
        ' Get the WorkflowInstanceId for the selected item
        Dim workflowInstanceId As String = Me.lstvwOrders.SelectedItems(0).Text

        ' Return the StateMachineInstance object 
        Return stateMachineInstances(workflowInstanceId)
    End Function

    Private Sub UpdateButtonStatus()

        If (Me.InvokeRequired) Then

            Dim updateButtonStatus As UpdateButtonStatusDelegate = _
                New UpdateButtonStatusDelegate(AddressOf Me.UpdateButtonStatus)
            Me.Invoke(updateButtonStatus)

        Else

            DisableButtons()
            EnableButtons()
        End If

    End Sub

    Protected Sub StateMachineInstance_StateChanged(ByVal sender As Object, ByVal e As ActivityEventArgs)


        Dim StateMachineInstance As StateMachineInstance = CType(sender, StateMachineInstance)

        If e.QualifiedId <> StateMachineInstance.CompletedState Then
            Dim workflowInstance As WorkflowInstance = StateMachineInstance.WorkflowInstance()

            Me.UpdateListItem(workflowInstance, e.QualifiedId.ToString(), "Running")
            Me.UpdateButtonStatus()
        End If

    End Sub

    Private Sub lstvwOrders_ItemSelectionChanged(ByVal sender As System.Object, _
    ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstvwOrders.ItemSelectionChanged
        If e.Item.Selected Then
            Me.UpdateButtonStatus()
        Else
            Me.DisableButtons()
        End If

    End Sub
End Class
