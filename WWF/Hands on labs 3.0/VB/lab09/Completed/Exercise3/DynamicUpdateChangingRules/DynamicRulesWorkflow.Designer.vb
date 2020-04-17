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
Partial class DynamicRulesWorkflow

    'NOTE: The following procedure is required by the Workflow Designer
    'It can be modified using the Workflow Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Dim ruleconditionreference1 As System.Workflow.Activities.Rules.RuleConditionReference = New System.Workflow.Activities.Rules.RuleConditionReference
        Dim codecondition1 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition
        Me.getVPApproval = New System.Workflow.Activities.CodeActivity
        Me.getManagerApproval = New System.Workflow.Activities.CodeActivity
        Me.ifElseBranchActivity2 = New System.Workflow.Activities.IfElseBranchActivity
        Me.ifElseBranchActivity1 = New System.Workflow.Activities.IfElseBranchActivity
        Me.delayActivity1 = New System.Workflow.Activities.DelayActivity
        Me.ifElseActivity1 = New System.Workflow.Activities.IfElseActivity
        Me.initAmount = New System.Workflow.Activities.CodeActivity
        Me.sequenceActivity1 = New System.Workflow.Activities.SequenceActivity
        Me.whileActivity1 = New System.Workflow.Activities.WhileActivity
        '
        'getVPApproval
        '
        Me.getVPApproval.Name = "getVPApproval"
        AddHandler Me.getVPApproval.ExecuteCode, AddressOf Me.getVPApproval_ExecuteCode
        '
        'getManagerApproval
        '
        Me.getManagerApproval.Name = "getManagerApproval"
        AddHandler Me.getManagerApproval.ExecuteCode, AddressOf Me.getManagerApproval_ExecuteCode
        '
        'ifElseBranchActivity2
        '
        Me.ifElseBranchActivity2.Activities.Add(Me.getVPApproval)
        Me.ifElseBranchActivity2.Name = "ifElseBranchActivity2"
        '
        'ifElseBranchActivity1
        '
        Me.ifElseBranchActivity1.Activities.Add(Me.getManagerApproval)
        ruleconditionreference1.ConditionName = "Condition1"
        Me.ifElseBranchActivity1.Condition = ruleconditionreference1
        Me.ifElseBranchActivity1.Name = "ifElseBranchActivity1"
        '
        'delayActivity1
        '
        Me.delayActivity1.Name = "delayActivity1"
        Me.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:02")
        '
        'ifElseActivity1
        '
        Me.ifElseActivity1.Activities.Add(Me.ifElseBranchActivity1)
        Me.ifElseActivity1.Activities.Add(Me.ifElseBranchActivity2)
        Me.ifElseActivity1.Name = "ifElseActivity1"
        '
        'initAmount
        '
        Me.initAmount.Name = "initAmount"
        AddHandler Me.initAmount.ExecuteCode, AddressOf Me.initAmount_ExecuteCode
        '
        'sequenceActivity1
        '
        Me.sequenceActivity1.Activities.Add(Me.initAmount)
        Me.sequenceActivity1.Activities.Add(Me.ifElseActivity1)
        Me.sequenceActivity1.Activities.Add(Me.delayActivity1)
        Me.sequenceActivity1.Name = "sequenceActivity1"
        '
        'whileActivity1
        '
        Me.whileActivity1.Activities.Add(Me.sequenceActivity1)
        AddHandler codecondition1.Condition, AddressOf Me.ReRun
        Me.whileActivity1.Condition = codecondition1
        Me.whileActivity1.Name = "whileActivity1"
        '
        'DynamicRulesWorkflow
        '
        Me.Activities.Add(Me.whileActivity1)
        Me.Name = "DynamicRulesWorkflow"
        Me.CanModifyActivities = False

    End Sub
    Private getVPApproval As System.Workflow.Activities.CodeActivity
    Private getManagerApproval As System.Workflow.Activities.CodeActivity
    Private ifElseBranchActivity2 As System.Workflow.Activities.IfElseBranchActivity
    Private ifElseBranchActivity1 As System.Workflow.Activities.IfElseBranchActivity
    Private delayActivity1 As System.Workflow.Activities.DelayActivity
    Private ifElseActivity1 As System.Workflow.Activities.IfElseActivity
    Private initAmount As System.Workflow.Activities.CodeActivity
    Private sequenceActivity1 As System.Workflow.Activities.SequenceActivity
    Private whileActivity1 As System.Workflow.Activities.WhileActivity

End Class
