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
        Dim codecondition1 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition
        Dim codecondition2 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition
        Dim codecondition3 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition
        Me.codeActivity2 = New System.Workflow.Activities.CodeActivity
        Me.codeActivity1 = New System.Workflow.Activities.CodeActivity
        Me.conditionedActivityGroup1 = New System.Workflow.Activities.ConditionedActivityGroup
        AddHandler codecondition1.Condition, AddressOf Me.evenCondition
        '
        'codeActivity2
        '
        Me.codeActivity2.Name = "codeActivity2"
        AddHandler Me.codeActivity2.ExecuteCode, AddressOf Me.codeActivity2_ExecuteCode
        Me.codeActivity2.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition1)
        AddHandler codecondition2.Condition, AddressOf Me.oddCondition
        '
        'codeActivity1
        '
        Me.codeActivity1.Name = "codeActivity1"
        AddHandler Me.codeActivity1.ExecuteCode, AddressOf Me.codeActivity1_ExecuteCode
        Me.codeActivity1.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition2)
        '
        'conditionedActivityGroup1
        '
        Me.conditionedActivityGroup1.Activities.Add(Me.codeActivity1)
        Me.conditionedActivityGroup1.Activities.Add(Me.codeActivity2)
        Me.conditionedActivityGroup1.Name = "conditionedActivityGroup1"
        AddHandler codecondition3.Condition, AddressOf Me.timeToExit
        Me.conditionedActivityGroup1.UntilCondition = codecondition3
        '
        'Workflow1
        '
        Me.Activities.Add(Me.conditionedActivityGroup1)
        Me.Name = "Workflow1"
        Me.CanModifyActivities = False

    End Sub
    Private codeActivity2 As System.Workflow.Activities.CodeActivity
    Private codeActivity1 As System.Workflow.Activities.CodeActivity
    Private conditionedActivityGroup1 As System.Workflow.Activities.ConditionedActivityGroup

End Class
