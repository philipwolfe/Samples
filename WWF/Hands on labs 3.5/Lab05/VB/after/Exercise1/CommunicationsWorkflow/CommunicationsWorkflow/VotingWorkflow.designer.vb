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
Partial Class VotingWorkflow

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
        Dim workflowparameterbinding3 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Me.JimReject = New System.Workflow.Activities.HandleExternalEventActivity
        Me.JimApprove = New System.Workflow.Activities.HandleExternalEventActivity
        Me.WaitForWimRejection = New System.Workflow.Activities.EventDrivenActivity
        Me.WaitForWimApproval = New System.Workflow.Activities.EventDrivenActivity
        Me.WaitForJimApproval = New System.Workflow.Activities.ListenActivity
        Me.CreateBallotForJim = New System.Workflow.Activities.CallExternalMethodActivity
        '
        'JimReject
        '
        Me.JimReject.EventName = "RejectProposal"
        Me.JimReject.InterfaceType = GetType(CommunicationsWorkflow.IVotingService)
        Me.JimReject.Name = "JimReject"
        activitybind1.Name = "VotingWorkflow"
        activitybind1.Path = "votingArgs"
        workflowparameterbinding1.ParameterName = "e"
        workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        Me.JimReject.ParameterBindings.Add(workflowparameterbinding1)
        AddHandler Me.JimReject.Invoked, AddressOf Me.OnRejected
        '
        'JimApprove
        '
        Me.JimApprove.EventName = "ApproveProposal"
        Me.JimApprove.InterfaceType = GetType(CommunicationsWorkflow.IVotingService)
        Me.JimApprove.Name = "JimApprove"
        activitybind2.Name = "VotingWorkflow"
        activitybind2.Path = "votingArgs"
        workflowparameterbinding2.ParameterName = "e"
        workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        Me.JimApprove.ParameterBindings.Add(workflowparameterbinding2)
        AddHandler Me.JimApprove.Invoked, AddressOf Me.OnApproved
        '
        'WaitForWimRejection
        '
        Me.WaitForWimRejection.Activities.Add(Me.JimReject)
        Me.WaitForWimRejection.Name = "WaitForWimRejection"
        '
        'WaitForWimApproval
        '
        Me.WaitForWimApproval.Activities.Add(Me.JimApprove)
        Me.WaitForWimApproval.Name = "WaitForWimApproval"
        '
        'WaitForJimApproval
        '
        Me.WaitForJimApproval.Activities.Add(Me.WaitForWimApproval)
        Me.WaitForJimApproval.Activities.Add(Me.WaitForWimRejection)
        Me.WaitForJimApproval.Name = "WaitForJimApproval"
        '
        'CreateBallotForJim
        '
        Me.CreateBallotForJim.InterfaceType = GetType(CommunicationsWorkflow.IVotingService)
        Me.CreateBallotForJim.MethodName = "CreateBallot"
        Me.CreateBallotForJim.Name = "CreateBallotForJim"
        workflowparameterbinding3.ParameterName = "alias"
        workflowparameterbinding3.Value = "Jim"
        Me.CreateBallotForJim.ParameterBindings.Add(workflowparameterbinding3)
        '
        'VotingWorkflow
        '
        Me.Activities.Add(Me.CreateBallotForJim)
        Me.Activities.Add(Me.WaitForJimApproval)
        Me.Name = "VotingWorkflow"
        Me.CanModifyActivities = False

    End Sub
    Private JimReject As System.Workflow.Activities.HandleExternalEventActivity
    Private WaitForWimRejection As System.Workflow.Activities.EventDrivenActivity
    Private WaitForWimApproval As System.Workflow.Activities.EventDrivenActivity
    Private WaitForJimApproval As System.Workflow.Activities.ListenActivity
    Private JimApprove As System.Workflow.Activities.HandleExternalEventActivity
    Private CreateBallotForJim As System.Workflow.Activities.CallExternalMethodActivity

End Class
