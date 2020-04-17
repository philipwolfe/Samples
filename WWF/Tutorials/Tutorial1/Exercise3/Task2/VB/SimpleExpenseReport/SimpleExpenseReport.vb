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
Imports Microsoft.VisualBasic
Imports System
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules
Imports System.Workflow.ComponentModel

Namespace Microsoft.Samples.Workflow.Tutorials.SequentialWorkflow
    <ExternalDataExchange()> _
    Public Interface IExpenseReportService
        Sub GetLeadApproval(ByVal message As String)
        Sub GetManagerApproval(ByVal message As String)
        Event ExpenseReportApproved As EventHandler(Of ExternalDataEventArgs)
        Event ExpenseReportRejected As EventHandler(Of ExternalDataEventArgs)
    End Interface

    Public Class ExpenseReportWorkflow : Inherits SequentialWorkflowActivity
        Private evaluateExpenseReportAmount As IfElseActivity
        Private ifNeedsLeadApproval As IfElseBranchActivity
        Private elseNeedsManagerApproval As IfElseBranchActivity
        Private invokeGetLeadApproval As CallExternalMethodActivity
        Private invokeGetManagerApproval As CallExternalMethodActivity
        
        Private listenApproveReject As ListenActivity
        Private eventDriven1 As EventDrivenActivity
        Private eventDriven2 As EventDrivenActivity
        Private approveEvent As HandleExternalEventActivity
        Private rejectEvent As HandleExternalEventActivity

        Private reportAmount As Integer = 0
        Private reportResult As String = ""

        Public WriteOnly Property Amount() As Integer
            Set(ByVal value As Integer)
                Me.reportAmount = Value
            End Set
        End Property

        Public ReadOnly Property Result() As String
            Get
                Return Me.reportResult
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.CanModifyActivities = True
            Me.evaluateExpenseReportAmount = _
                New System.Workflow.Activities.IfElseActivity()
            Me.ifNeedsLeadApproval = _
                New System.Workflow.Activities.IfElseBranchActivity()
            Me.elseNeedsManagerApproval = _
                New System.Workflow.Activities.IfElseBranchActivity()
            Dim ifElseLogicStatement As System.Workflow.Activities.CodeCondition = _
                        New System.Workflow.Activities.CodeCondition()
            Dim workflowparameterbinding1 As WorkflowParameterBinding = _
                         New System.Workflow.ComponentModel.WorkflowParameterBinding()
            Dim workflowparameterbinding2 As WorkflowParameterBinding = _
                         New System.Workflow.ComponentModel.WorkflowParameterBinding()
            Me.invokeGetLeadApproval = New _
                         System.Workflow.Activities.CallExternalMethodActivity()
            Me.invokeGetManagerApproval = New _
                         System.Workflow.Activities.CallExternalMethodActivity()
            Me.eventDriven1 = New System.Workflow.Activities.EventDrivenActivity()
            Me.eventDriven2 = New System.Workflow.Activities.EventDrivenActivity()
            Me.listenApproveReject = New System.Workflow.Activities.ListenActivity()
            Me.approveEvent = New _
                System.Workflow.Activities.HandleExternalEventActivity()
            Me.rejectEvent = New System.Workflow.Activities.HandleExternalEventActivity()
            ' 
            ' evaluateExpenseReportAmount
            ' 
            Me.evaluateExpenseReportAmount.Activities.Add(Me.ifNeedsLeadApproval)
            Me.evaluateExpenseReportAmount.Activities.Add(Me.elseNeedsManagerApproval)
            Me.evaluateExpenseReportAmount.Name = "evaluateExpenseReportAmount"
            ' 
            ' ifNeedsLeadApproval
            ' 
            Me.ifNeedsLeadApproval.Activities.Add(Me.invokeGetLeadApproval)
            AddHandler ifElseLogicStatement.Condition, AddressOf Me.DetermineApprovalContact
            Me.ifNeedsLeadApproval.Condition = ifElseLogicStatement
            Me.ifNeedsLeadApproval.Name = "ifNeedsLeadApproval"
            ' 
            ' elseNeedsManagerApproval
            ' 
            Me.elseNeedsManagerApproval.Activities.Add(Me.invokeGetManagerApproval)
            Me.elseNeedsManagerApproval.Name = "elseNeedsManagerApproval"
            ' 
            ' invokeGetLeadApproval
            ' 
            Me.invokeGetLeadApproval.InterfaceType = GetType(IExpenseReportService)
            Me.invokeGetLeadApproval.MethodName = "GetLeadApproval"
            Me.invokeGetLeadApproval.Name = "invokeGetLeadApproval"
            workflowparameterbinding1.ParameterName = "message"
            workflowparameterbinding1.Value = "Lead approval needed"
            Me.invokeGetLeadApproval.ParameterBindings.Add(workflowparameterbinding1)
            ' 
            ' invokeGetManagerApproval
            ' 
            Me.invokeGetManagerApproval.InterfaceType = GetType(IExpenseReportService)
            Me.invokeGetManagerApproval.MethodName = "GetManagerApproval"
            Me.invokeGetManagerApproval.Name = "invokeGetManagerApproval"
            workflowparameterbinding2.ParameterName = "message"
            workflowparameterbinding2.Value = "Manager approval needed"
            Me.invokeGetManagerApproval.ParameterBindings.Add(workflowparameterbinding2)
            ' 
            ' eventDriven1
            ' 
            Me.eventDriven1.Activities.Add(Me.approveEvent)
            Me.eventDriven1.Name = "eventDriven1"
            ' 
            ' eventDriven2
            ' 
            Me.eventDriven2.Activities.Add(Me.rejectEvent)
            Me.eventDriven2.Name = "eventDriven2"
            ' 
            ' listenApproveReject
            ' 
            Me.listenApproveReject.Activities.Add(Me.eventDriven1)
            Me.listenApproveReject.Activities.Add(Me.eventDriven2)
            Me.listenApproveReject.Name = "listenApproveReject"
            ' 
            ' approveEvent
            ' 
            Me.approveEvent.EventName = "ExpenseReportApproved"
            Me.approveEvent.InterfaceType = GetType(IExpenseReportService)
            Me.approveEvent.Name = "approveEvent"
            AddHandler Me.approveEvent.Invoked, AddressOf Me.approveEvent_Invoked
            ' 
            ' rejectEvent
            ' 
            Me.rejectEvent.EventName = "ExpenseReportRejected"
            Me.rejectEvent.InterfaceType = GetType(IExpenseReportService)
            Me.rejectEvent.Name = "rejectEvent"
            AddHandler Me.rejectEvent.Invoked, AddressOf Me.rejectEvent_Invoked
            ' 
            ' ExpenseReportWorkflow
            ' 
            Me.Activities.Add(Me.evaluateExpenseReportAmount)
            Me.Activities.Add(Me.listenApproveReject)
            Me.Name = "ExpenseReportWorkflow"
            Me.CanModifyActivities = False
        End Sub

        Private Sub DetermineApprovalContact(ByVal sender As Object, _
                  ByVal e As ConditionalEventArgs)
            If Me.reportAmount < 1000 Then
                e.Result = True
            Else
                e.Result = False
            End If
        End Sub

        Private Sub approveEvent_Invoked(ByVal sender As Object, _
            ByVal e As ExternalDataEventArgs)
            Me.reportResult = "Report Approved"
        End Sub

        Private Sub rejectEvent_Invoked(ByVal sender As Object, _
            ByVal e As ExternalDataEventArgs)
            Me.reportResult = "Report Rejected"
        End Sub
    End Class
End Namespace
