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
        Me.codeActivity1 = New System.Workflow.Activities.CodeActivity
        Me.ifElseBranchActivity1 = New System.Workflow.Activities.IfElseBranchActivity
        Me.codeActivity2 = New System.Workflow.Activities.CodeActivity
        Me.ifElseActivity1 = New System.Workflow.Activities.IfElseActivity
        '
        'codeActivity1
        '
        Me.codeActivity1.Name = "codeActivity1"
        AddHandler Me.codeActivity1.ExecuteCode, AddressOf Me.AddApproval
        '
        'ifElseBranchActivity1
        '
        Me.ifElseBranchActivity1.Activities.Add(Me.codeActivity1)
        AddHandler codecondition1.Condition, AddressOf Me.CheckAmount
        Me.ifElseBranchActivity1.Condition = codecondition1
        Me.ifElseBranchActivity1.Name = "ifElseBranchActivity1"
        '
        'codeActivity2
        '
        Me.codeActivity2.Name = "codeActivity2"
        AddHandler Me.codeActivity2.ExecuteCode, AddressOf Me.PurchaseOrderCreate
        '
        'ifElseActivity1
        '
        Me.ifElseActivity1.Activities.Add(Me.ifElseBranchActivity1)
        Me.ifElseActivity1.Name = "ifElseActivity1"
        '
        'Workflow1
        '
        Me.Activities.Add(Me.ifElseActivity1)
        Me.Activities.Add(Me.codeActivity2)
        Me.Name = "Workflow1"
        Me.CanModifyActivities = False

    End Sub
    Private ifElseBranchActivity1 As System.Workflow.Activities.IfElseBranchActivity
    Private codeActivity1 As System.Workflow.Activities.CodeActivity
    Private codeActivity2 As System.Workflow.Activities.CodeActivity
    Private ifElseActivity1 As System.Workflow.Activities.IfElseActivity

End Class
