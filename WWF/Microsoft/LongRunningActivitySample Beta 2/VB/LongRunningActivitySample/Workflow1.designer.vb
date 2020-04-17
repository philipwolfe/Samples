'--------------------------------------------------------------------------------
' This file is a "Sample" from Windows Workflow Foundation
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
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Drawing
Imports System.Reflection
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules

Namespace LongRunningWorkflow
	Public NotInheritable Partial Class Workflow1
		#Region "Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.CanModifyActivities = True
            Me.AfterDelay = New System.Workflow.Activities.CodeActivity
            Me.delayActivity1 = New System.Workflow.Activities.DelayActivity
            Me.BeforeDelay = New System.Workflow.Activities.CodeActivity
            Me.factorPrimesActivity1 = New WorkflowConsoleApplication1.LongRunningWorkflow.FactorPrimesActivity
            Me.delaySequence = New System.Workflow.Activities.SequenceActivity
            Me.factoringSequence = New System.Workflow.Activities.SequenceActivity
            Me.AfterBranch = New System.Workflow.Activities.CodeActivity
            Me.parallelActivity1 = New System.Workflow.Activities.ParallelActivity
            Me.BeforeBranch = New System.Workflow.Activities.CodeActivity
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
            'factorPrimesActivity1
            '
            Me.factorPrimesActivity1.Name = "factorPrimesActivity1"
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
            Me.factoringSequence.Activities.Add(Me.factorPrimesActivity1)
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
            'BeforeBranch
            '
            Me.BeforeBranch.Name = "BeforeBranch"
            AddHandler Me.BeforeBranch.ExecuteCode, AddressOf Me.BeforeBranch_Execute
            '
            'Workflow1
            '
            Me.Activities.Add(Me.BeforeBranch)
            Me.Activities.Add(Me.parallelActivity1)
            Me.Activities.Add(Me.AfterBranch)
            Me.Name = "Workflow1"
            Me.CanModifyActivities = False

        End Sub
        Private parallelActivity1 As System.Workflow.Activities.ParallelActivity
        Private factoringSequence As System.Workflow.Activities.SequenceActivity
        Private BeforeDelay As System.Workflow.Activities.CodeActivity
        Private delayActivity1 As System.Workflow.Activities.DelayActivity
        Private AfterDelay As System.Workflow.Activities.CodeActivity
        Private BeforeBranch As System.Workflow.Activities.CodeActivity
        Private AfterBranch As System.Workflow.Activities.CodeActivity
        Private factorPrimesActivity1 As WorkflowConsoleApplication1.LongRunningWorkflow.FactorPrimesActivity
        Private delaySequence As System.Workflow.Activities.SequenceActivity

		#End Region
	End Class
End Namespace
