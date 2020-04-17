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
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Drawing
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules

Namespace Microsoft.Samples.Workflow.Tutorials.StateMachineWorkflow
    Public Class OrderProcessingWorkflow : Inherits StateMachineWorkflowActivity
        Private WaitingForOrderStateActivity As StateActivity
        Private OrderProcessingStateActivity As StateActivity
        Private OrderCompletedStateActivity As StateActivity

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.CanModifyActivities = True
            Me.WaitingForOrderStateActivity = New _
                System.Workflow.Activities.StateActivity()
            Me.OrderProcessingStateActivity = _
                New System.Workflow.Activities.StateActivity()
            Me.OrderCompletedStateActivity = _
                New System.Workflow.Activities.StateActivity()
            ' 
            ' WaitingForOrderStateActivity
            ' 
            Me.WaitingForOrderStateActivity.Name = "WaitingForOrderStateActivity"
            ' 
            ' OrderProcessingStateActivity
            ' 
            Me.OrderProcessingStateActivity.Name = "OrderProcessingStateActivity"
            ' 
            ' OrderCompletedStateActivity
            ' 
            Me.OrderCompletedStateActivity.Name = "OrderCompletedStateActivity"
            ' 
            ' OrderProcessingWorkflow
            ' 
            Me.Activities.Add(Me.WaitingForOrderStateActivity)
            Me.Activities.Add(Me.OrderProcessingStateActivity)
            Me.Activities.Add(Me.OrderCompletedStateActivity)
            Me.InitialStateName = "WaitingForOrderStateActivity"
            Me.CompletedStateName = "OrderCompletedStateActivity"
            Me.DynamicUpdateCondition = Nothing
            Me.Name = "OrderProcessingWorkflow"
            Me.CanModifyActivities = False
        End Sub
    End Class
End Namespace
