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
        Me.AfterDelay = New System.Workflow.Activities.CodeActivity
        Me.delayActivity1 = New System.Workflow.Activities.DelayActivity
        Me.BeforeDelay = New System.Workflow.Activities.CodeActivity
        Me.FactoringComplete = New System.Workflow.Activities.HandleExternalEventActivity
        Me.BeginFactoring = New System.Workflow.Activities.CallExternalMethodActivity
        Me.delaySequence = New System.Workflow.Activities.SequenceActivity
        Me.factoringSequence = New System.Workflow.Activities.SequenceActivity
        Me.AfterBranch = New System.Workflow.Activities.CodeActivity
        Me.parallelActivity1 = New System.Workflow.Activities.ParallelActivity
        Me.beforeBranch = New System.Workflow.Activities.CodeActivity
        '
        'AfterDelay
        '
        Me.AfterDelay.Name = "AfterDelay"
        AddHandler Me.AfterDelay.ExecuteCode, AddressOf Me.AfterDelay_Execute
        '
        'delayActivity1
        '
        Me.delayActivity1.Name = "delayActivity1"
        Me.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:05")
        '
        'BeforeDelay
        '
        Me.BeforeDelay.Name = "BeforeDelay"
        AddHandler Me.BeforeDelay.ExecuteCode, AddressOf Me.BeforeDelay_Execute
        '
        'FactoringComplete
        '
        Me.FactoringComplete.EventName = "FactoredPrimes"
        Me.FactoringComplete.InterfaceType = GetType(LongRunningWorkflow.IPrimeFactoring)
        Me.FactoringComplete.Name = "FactoringComplete"
        '
        'BeginFactoring
        '
        Me.BeginFactoring.InterfaceType = GetType(LongRunningWorkflow.IPrimeFactoring)
        Me.BeginFactoring.MethodName = "FactorPrimes"
        Me.BeginFactoring.Name = "BeginFactoring"
        '
        'delaySequence
        '
        Me.delaySequence.Activities.Add(Me.BeforeDelay)
        Me.delaySequence.Activities.Add(Me.delayActivity1)
        Me.delaySequence.Activities.Add(Me.AfterDelay)
        Me.delaySequence.Name = "delaySequence"
        '
        'factoringSequence
        '
        Me.factoringSequence.Activities.Add(Me.BeginFactoring)
        Me.factoringSequence.Activities.Add(Me.FactoringComplete)
        Me.factoringSequence.Name = "factoringSequence"
        '
        'AfterBranch
        '
        Me.AfterBranch.Name = "AfterBranch"
        AddHandler Me.AfterBranch.ExecuteCode, AddressOf Me.AfterBranch_Execute
        '
        'parallelActivity1
        '
        Me.parallelActivity1.Activities.Add(Me.factoringSequence)
        Me.parallelActivity1.Activities.Add(Me.delaySequence)
        Me.parallelActivity1.Name = "parallelActivity1"
        '
        'beforeBranch
        '
        Me.beforeBranch.Name = "beforeBranch"
        AddHandler Me.beforeBranch.ExecuteCode, AddressOf Me.BeforeBranch_Execute
        '
        'Workflow1
        '
        Me.Activities.Add(Me.beforeBranch)
        Me.Activities.Add(Me.parallelActivity1)
        Me.Activities.Add(Me.AfterBranch)
        Me.Name = "Workflow1"
        Me.CanModifyActivities = False

    End Sub
    Private delayActivity1 As System.Workflow.Activities.DelayActivity
    Private FactoringComplete As System.Workflow.Activities.HandleExternalEventActivity
    Private BeginFactoring As System.Workflow.Activities.CallExternalMethodActivity
    Private delaySequence As System.Workflow.Activities.SequenceActivity
    Private factoringSequence As System.Workflow.Activities.SequenceActivity
    Private AfterDelay As System.Workflow.Activities.CodeActivity
    Private BeforeDelay As System.Workflow.Activities.CodeActivity
    Private AfterBranch As System.Workflow.Activities.CodeActivity
    Private beforeBranch As System.Workflow.Activities.CodeActivity
    Private parallelActivity1 As System.Workflow.Activities.ParallelActivity

End Class
