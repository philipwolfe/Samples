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
        Dim correlationtoken1 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken
        Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding1 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind2 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding2 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim correlationtoken2 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken
        Dim activitybind3 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding3 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind4 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding4 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim workflowparameterbinding5 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim workflowparameterbinding6 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Me.AliceReject = New System.Workflow.Activities.HandleExternalEventActivity
        Me.AliceApprove = New System.Workflow.Activities.HandleExternalEventActivity
        Me.JimReject = New System.Workflow.Activities.HandleExternalEventActivity
        Me.JimApprove = New System.Workflow.Activities.HandleExternalEventActivity
        Me.eventDrivenActivity2 = New System.Workflow.Activities.EventDrivenActivity
        Me.eventDrivenActivity1 = New System.Workflow.Activities.EventDrivenActivity
        Me.WaitForWimRejection = New System.Workflow.Activities.EventDrivenActivity
        Me.WaitForWimApproval = New System.Workflow.Activities.EventDrivenActivity
        Me.listenActivity1 = New System.Workflow.Activities.ListenActivity
        Me.CreateBallotForAlice = New System.Workflow.Activities.CallExternalMethodActivity
        Me.WaitForJimApproval = New System.Workflow.Activities.ListenActivity
        Me.CreateBallotForJim = New System.Workflow.Activities.CallExternalMethodActivity
        Me.AliceSequence = New System.Workflow.Activities.SequenceActivity
        Me.JimSequence = New System.Workflow.Activities.SequenceActivity
        Me.SendBallots = New System.Workflow.Activities.ParallelActivity
        '
        'AliceReject
        '
        correlationtoken1.Name = "correlationTokenForAlice"
        correlationtoken1.OwnerActivityName = "AliceSequence"
        Me.AliceReject.CorrelationToken = correlationtoken1
        Me.AliceReject.EventName = "RejectProposal"
        Me.AliceReject.InterfaceType = GetType(CommunicationsWorkflow.IVotingServiceCorrelated)
        Me.AliceReject.Name = "AliceReject"
        activitybind1.Name = "VotingWorkflow"
        activitybind1.Path = "votingArgs"
        workflowparameterbinding1.ParameterName = "e"
        workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        Me.AliceReject.ParameterBindings.Add(workflowparameterbinding1)
        AddHandler Me.AliceReject.Invoked, AddressOf Me.OnRejected
        '
        'AliceApprove
        '
        Me.AliceApprove.CorrelationToken = correlationtoken1
        Me.AliceApprove.EventName = "ApproveProposal"
        Me.AliceApprove.InterfaceType = GetType(CommunicationsWorkflow.IVotingServiceCorrelated)
        Me.AliceApprove.Name = "AliceApprove"
        activitybind2.Name = "VotingWorkflow"
        activitybind2.Path = "votingArgs"
        workflowparameterbinding2.ParameterName = "e"
        workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        Me.AliceApprove.ParameterBindings.Add(workflowparameterbinding2)
        AddHandler Me.AliceApprove.Invoked, AddressOf Me.OnApproved
        '
        'JimReject
        '
        correlationtoken2.Name = "correlationTokenForJim"
        correlationtoken2.OwnerActivityName = "JimSequence"
        Me.JimReject.CorrelationToken = correlationtoken2
        Me.JimReject.EventName = "RejectProposal"
        Me.JimReject.InterfaceType = GetType(CommunicationsWorkflow.IVotingServiceCorrelated)
        Me.JimReject.Name = "JimReject"
        activitybind3.Name = "VotingWorkflow"
        activitybind3.Path = "votingArgs"
        workflowparameterbinding3.ParameterName = "e"
        workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind3, System.Workflow.ComponentModel.ActivityBind))
        Me.JimReject.ParameterBindings.Add(workflowparameterbinding3)
        AddHandler Me.JimReject.Invoked, AddressOf Me.OnRejected
        '
        'JimApprove
        '
        Me.JimApprove.CorrelationToken = correlationtoken2
        Me.JimApprove.EventName = "ApproveProposal"
        Me.JimApprove.InterfaceType = GetType(CommunicationsWorkflow.IVotingServiceCorrelated)
        Me.JimApprove.Name = "JimApprove"
        activitybind4.Name = "VotingWorkflow"
        activitybind4.Path = "votingArgs"
        workflowparameterbinding4.ParameterName = "e"
        workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind4, System.Workflow.ComponentModel.ActivityBind))
        Me.JimApprove.ParameterBindings.Add(workflowparameterbinding4)
        AddHandler Me.JimApprove.Invoked, AddressOf Me.OnApproved
        '
        'eventDrivenActivity2
        '
        Me.eventDrivenActivity2.Activities.Add(Me.AliceReject)
        Me.eventDrivenActivity2.Name = "eventDrivenActivity2"
        '
        'eventDrivenActivity1
        '
        Me.eventDrivenActivity1.Activities.Add(Me.AliceApprove)
        Me.eventDrivenActivity1.Name = "eventDrivenActivity1"
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
        'listenActivity1
        '
        Me.listenActivity1.Activities.Add(Me.eventDrivenActivity1)
        Me.listenActivity1.Activities.Add(Me.eventDrivenActivity2)
        Me.listenActivity1.Name = "listenActivity1"
        '
        'CreateBallotForAlice
        '
        Me.CreateBallotForAlice.CorrelationToken = correlationtoken1
        Me.CreateBallotForAlice.InterfaceType = GetType(CommunicationsWorkflow.IVotingServiceCorrelated)
        Me.CreateBallotForAlice.MethodName = "CreateBallot"
        Me.CreateBallotForAlice.Name = "CreateBallotForAlice"
        workflowparameterbinding5.ParameterName = "alias"
        workflowparameterbinding5.Value = "Alice"
        Me.CreateBallotForAlice.ParameterBindings.Add(workflowparameterbinding5)
        '
        'WaitForJimApproval
        '
        Me.WaitForJimApproval.Activities.Add(Me.WaitForWimApproval)
        Me.WaitForJimApproval.Activities.Add(Me.WaitForWimRejection)
        Me.WaitForJimApproval.Name = "WaitForJimApproval"
        '
        'CreateBallotForJim
        '
        Me.CreateBallotForJim.CorrelationToken = correlationtoken2
        Me.CreateBallotForJim.InterfaceType = GetType(CommunicationsWorkflow.IVotingServiceCorrelated)
        Me.CreateBallotForJim.MethodName = "CreateBallot"
        Me.CreateBallotForJim.Name = "CreateBallotForJim"
        workflowparameterbinding6.ParameterName = "alias"
        workflowparameterbinding6.Value = "Jim"
        Me.CreateBallotForJim.ParameterBindings.Add(workflowparameterbinding6)
        '
        'AliceSequence
        '
        Me.AliceSequence.Activities.Add(Me.CreateBallotForAlice)
        Me.AliceSequence.Activities.Add(Me.listenActivity1)
        Me.AliceSequence.Name = "AliceSequence"
        '
        'JimSequence
        '
        Me.JimSequence.Activities.Add(Me.CreateBallotForJim)
        Me.JimSequence.Activities.Add(Me.WaitForJimApproval)
        Me.JimSequence.Name = "JimSequence"
        '
        'SendBallots
        '
        Me.SendBallots.Activities.Add(Me.JimSequence)
        Me.SendBallots.Activities.Add(Me.AliceSequence)
        Me.SendBallots.Name = "SendBallots"
        '
        'VotingWorkflow
        '
        Me.Activities.Add(Me.SendBallots)
        Me.Name = "VotingWorkflow"
        Me.CanModifyActivities = False

    End Sub
    Private AliceSequence As System.Workflow.Activities.SequenceActivity
    Private JimSequence As System.Workflow.Activities.SequenceActivity
    Private SendBallots As System.Workflow.Activities.ParallelActivity
    Private AliceReject As System.Workflow.Activities.HandleExternalEventActivity
    Private AliceApprove As System.Workflow.Activities.HandleExternalEventActivity
    Private eventDrivenActivity2 As System.Workflow.Activities.EventDrivenActivity
    Private eventDrivenActivity1 As System.Workflow.Activities.EventDrivenActivity
    Private listenActivity1 As System.Workflow.Activities.ListenActivity
    Private CreateBallotForAlice As System.Workflow.Activities.CallExternalMethodActivity
    Private JimReject As System.Workflow.Activities.HandleExternalEventActivity
    Private WaitForWimRejection As System.Workflow.Activities.EventDrivenActivity
    Private WaitForWimApproval As System.Workflow.Activities.EventDrivenActivity
    Private WaitForJimApproval As System.Workflow.Activities.ListenActivity
    Private JimApprove As System.Workflow.Activities.HandleExternalEventActivity
    Private CreateBallotForJim As System.Workflow.Activities.CallExternalMethodActivity

End Class
