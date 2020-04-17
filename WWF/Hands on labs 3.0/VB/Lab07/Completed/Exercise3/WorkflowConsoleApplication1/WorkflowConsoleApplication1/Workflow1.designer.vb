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
        Dim rulesetreference1 As System.Workflow.Activities.Rules.RuleSetReference = New System.Workflow.Activities.Rules.RuleSetReference
        Me.policyActivity1 = New System.Workflow.Activities.PolicyActivity
        '
        'policyActivity1
        '
        Me.policyActivity1.Name = "policyActivity1"
        rulesetreference1.RuleSetName = "Rule Set1"
        Me.policyActivity1.RuleSetReference = rulesetreference1
        '
        'Workflow1
        '
        Me.Activities.Add(Me.policyActivity1)
        Me.Name = "Workflow1"
        AddHandler Completed, AddressOf Me.WorkflowCompleted
        Me.CanModifyActivities = False

    End Sub
    Private policyActivity1 As System.Workflow.Activities.PolicyActivity

End Class
