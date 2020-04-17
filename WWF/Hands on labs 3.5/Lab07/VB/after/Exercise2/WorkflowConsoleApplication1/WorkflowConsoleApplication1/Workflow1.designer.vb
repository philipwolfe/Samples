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
        Me.codeActivity1 = New System.Workflow.Activities.CodeActivity
        Me.replicatorActivity1 = New System.Workflow.Activities.ReplicatorActivity
        '
        'codeActivity1
        '
        Me.codeActivity1.Name = "codeActivity1"
        AddHandler Me.codeActivity1.ExecuteCode, AddressOf Me.codeActivity1_ExecuteCode
        '
        'replicatorActivity1
        '
        Me.replicatorActivity1.Activities.Add(Me.codeActivity1)
        Me.replicatorActivity1.ExecutionType = System.Workflow.Activities.ExecutionType.Sequence
        Me.replicatorActivity1.Name = "replicatorActivity1"
        AddHandler Me.replicatorActivity1.ChildInitialized, AddressOf Me.childInitialized
        AddHandler Me.replicatorActivity1.Initialized, AddressOf Me.replicatorActivity1_Initialized
        AddHandler Me.replicatorActivity1.ChildCompleted, AddressOf Me.childCompleted
        '
        'Workflow1
        '
        Me.Activities.Add(Me.replicatorActivity1)
        Me.Name = "Workflow1"
        AddHandler Completed, AddressOf Me.WorkflowCompleted
        Me.CanModifyActivities = False

    End Sub
    Private codeActivity1 As System.Workflow.Activities.CodeActivity
    Private replicatorActivity1 As System.Workflow.Activities.ReplicatorActivity

End Class
