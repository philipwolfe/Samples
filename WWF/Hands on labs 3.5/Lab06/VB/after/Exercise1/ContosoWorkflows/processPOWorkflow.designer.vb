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
Partial Class processPOWorkflow

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
        Dim activitybind3 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding3 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim activitybind4 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Dim workflowparameterbinding4 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
        Dim ruleconditionreference1 As System.Workflow.Activities.Rules.RuleConditionReference = New System.Workflow.Activities.Rules.RuleConditionReference
        Me.afterWSNorthwindInvoke = New System.Workflow.Activities.CodeActivity
        Me.invokePOSubmissionWSNorthwind = New System.Workflow.Activities.InvokeWebServiceActivity
        Me.afterWSFabrikamInvoke = New System.Workflow.Activities.CodeActivity
        Me.invokePOSubmissionWSFabrikam = New System.Workflow.Activities.InvokeWebServiceActivity
        Me.Else_ = New System.Workflow.Activities.IfElseBranchActivity
        Me.ifOrderSmallerThan1000 = New System.Workflow.Activities.IfElseBranchActivity
        Me.checkOrderTotal = New System.Workflow.Activities.IfElseActivity
        '
        'afterWSNorthwindInvoke
        '
        Me.afterWSNorthwindInvoke.Name = "afterWSNorthwindInvoke"
        AddHandler Me.afterWSNorthwindInvoke.ExecuteCode, AddressOf Me.afterWSNorthwindInvoke_ExecuteCode
        '
        'invokePOSubmissionWSNorthwind
        '
        Me.invokePOSubmissionWSNorthwind.MethodName = "SubmitPO"
        Me.invokePOSubmissionWSNorthwind.Name = "invokePOSubmissionWSNorthwind"
        activitybind1.Name = "processPOWorkflow"
        activitybind1.Path = "outgoingPOforNorthwind"
        workflowparameterbinding1.ParameterName = "incomingPO"
        workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        activitybind2.Name = "processPOWorkflow"
        activitybind2.Path = "POResponsefromNorthwind"
        workflowparameterbinding2.ParameterName = "(ReturnValue)"
        workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
        Me.invokePOSubmissionWSNorthwind.ParameterBindings.Add(workflowparameterbinding1)
        Me.invokePOSubmissionWSNorthwind.ParameterBindings.Add(workflowparameterbinding2)
        Me.invokePOSubmissionWSNorthwind.ProxyClass = GetType(ContosoWorkflows.Northwind.Service)
        AddHandler Me.invokePOSubmissionWSNorthwind.Invoking, AddressOf Me.invokePOSubmissionWSNorthwind_Invoking
        AddHandler Me.invokePOSubmissionWSNorthwind.Invoked, AddressOf Me.invokePOSubmissionWSNorthwind_Invoked
        '
        'afterWSFabrikamInvoke
        '
        Me.afterWSFabrikamInvoke.Name = "afterWSFabrikamInvoke"
        AddHandler Me.afterWSFabrikamInvoke.ExecuteCode, AddressOf Me.afterWSFabrikamInvoke_ExecuteCode
        '
        'invokePOSubmissionWSFabrikam
        '
        Me.invokePOSubmissionWSFabrikam.MethodName = "SubmitPO"
        Me.invokePOSubmissionWSFabrikam.Name = "invokePOSubmissionWSFabrikam"
        activitybind3.Name = "processPOWorkflow"
        activitybind3.Path = "outgoingPOforFabrikam"
        workflowparameterbinding3.ParameterName = "incomingPO"
        workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind3, System.Workflow.ComponentModel.ActivityBind))
        activitybind4.Name = "processPOWorkflow"
        activitybind4.Path = "POResponsefromFabrikam"
        workflowparameterbinding4.ParameterName = "(ReturnValue)"
        workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind4, System.Workflow.ComponentModel.ActivityBind))
        Me.invokePOSubmissionWSFabrikam.ParameterBindings.Add(workflowparameterbinding3)
        Me.invokePOSubmissionWSFabrikam.ParameterBindings.Add(workflowparameterbinding4)
        Me.invokePOSubmissionWSFabrikam.ProxyClass = GetType(ContosoWorkflows.Fabrikam.Service)
        AddHandler Me.invokePOSubmissionWSFabrikam.Invoking, AddressOf Me.invokePOSubmissionWSFabrikam_Invoking
        AddHandler Me.invokePOSubmissionWSFabrikam.Invoked, AddressOf Me.invokePOSubmissionWSFabrikam_Invoked
        '
        'Else_
        '
        Me.Else_.Activities.Add(Me.invokePOSubmissionWSNorthwind)
        Me.Else_.Activities.Add(Me.afterWSNorthwindInvoke)
        Me.Else_.Name = "Else_"
        '
        'ifOrderSmallerThan1000
        '
        Me.ifOrderSmallerThan1000.Activities.Add(Me.invokePOSubmissionWSFabrikam)
        Me.ifOrderSmallerThan1000.Activities.Add(Me.afterWSFabrikamInvoke)
        ruleconditionreference1.ConditionName = "ifOrderSmallerThan1000"
        Me.ifOrderSmallerThan1000.Condition = ruleconditionreference1
        Me.ifOrderSmallerThan1000.Name = "ifOrderSmallerThan1000"
        '
        'checkOrderTotal
        '
        Me.checkOrderTotal.Activities.Add(Me.ifOrderSmallerThan1000)
        Me.checkOrderTotal.Activities.Add(Me.Else_)
        Me.checkOrderTotal.Name = "checkOrderTotal"
        '
        'processPOWorkflow
        '
        Me.Activities.Add(Me.checkOrderTotal)
        Me.Name = "processPOWorkflow"
        Me.CanModifyActivities = False

    End Sub
    Private afterWSNorthwindInvoke As System.Workflow.Activities.CodeActivity
    Private afterWSFabrikamInvoke As System.Workflow.Activities.CodeActivity
    Private invokePOSubmissionWSNorthwind As System.Workflow.Activities.InvokeWebServiceActivity
    Private invokePOSubmissionWSFabrikam As System.Workflow.Activities.InvokeWebServiceActivity
    Private Else_ As System.Workflow.Activities.IfElseBranchActivity
    Private ifOrderSmallerThan1000 As System.Workflow.Activities.IfElseBranchActivity
    Private checkOrderTotal As System.Workflow.Activities.IfElseActivity

End Class
