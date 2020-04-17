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
        Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
        Me.compensateActivity1 = New System.Workflow.ComponentModel.CompensateActivity
        Me.WorkflowExceptionHandler = New System.Workflow.Activities.CodeActivity
        Me.compensateOperation = New System.Workflow.Activities.CodeActivity
        Me.faultHandlerActivity1 = New System.Workflow.ComponentModel.FaultHandlerActivity
        Me.compensationHandlerActivity1 = New System.Workflow.ComponentModel.CompensationHandlerActivity
        Me.Credit = New System.Workflow.Activities.CodeActivity
        Me.Debit = New System.Workflow.Activities.CodeActivity
        Me.faultHandlersActivity1 = New System.Workflow.ComponentModel.FaultHandlersActivity
        Me.FinishWorkflow = New System.Workflow.Activities.CodeActivity
        Me.throwActivity1 = New System.Workflow.ComponentModel.ThrowActivity
        Me.compensatableTransactionScopeActivity1 = New System.Workflow.ComponentModel.CompensatableTransactionScopeActivity
        '
        'compensateActivity1
        '
        Me.compensateActivity1.Name = "compensateActivity1"
        Me.compensateActivity1.TargetActivityName = "compensatableTransactionScopeActivity1"
        '
        'WorkflowExceptionHandler
        '
        Me.WorkflowExceptionHandler.Name = "WorkflowExceptionHandler"
        AddHandler Me.WorkflowExceptionHandler.ExecuteCode, AddressOf Me.OnException
        '
        'compensateOperation
        '
        Me.compensateOperation.Name = "compensateOperation"
        AddHandler Me.compensateOperation.ExecuteCode, AddressOf Me.OnCompensation
        '
        'faultHandlerActivity1
        '
        Me.faultHandlerActivity1.Activities.Add(Me.WorkflowExceptionHandler)
        Me.faultHandlerActivity1.Activities.Add(Me.compensateActivity1)
        Me.faultHandlerActivity1.FaultType = GetType(System.Exception)
        Me.faultHandlerActivity1.Name = "faultHandlerActivity1"
        '
        'compensationHandlerActivity1
        '
        Me.compensationHandlerActivity1.Activities.Add(Me.compensateOperation)
        Me.compensationHandlerActivity1.Name = "compensationHandlerActivity1"
        '
        'Credit
        '
        Me.Credit.Name = "Credit"
        AddHandler Me.Credit.ExecuteCode, AddressOf Me.CreditCodeHandler
        '
        'Debit
        '
        Me.Debit.Name = "Debit"
        AddHandler Me.Debit.ExecuteCode, AddressOf Me.DebitCodeHandler
        '
        'faultHandlersActivity1
        '
        Me.faultHandlersActivity1.Activities.Add(Me.faultHandlerActivity1)
        Me.faultHandlersActivity1.Name = "faultHandlersActivity1"
        '
        'FinishWorkflow
        '
        Me.FinishWorkflow.Name = "FinishWorkflow"
        AddHandler Me.FinishWorkflow.ExecuteCode, AddressOf Me.OnFinishWorkflow
        activitybind1.Name = "Workflow1"
        activitybind1.Path = "exception"
        '
        'throwActivity1
        '
        Me.throwActivity1.FaultType = GetType(System.Exception)
        Me.throwActivity1.Name = "throwActivity1"
        Me.throwActivity1.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        '
        'compensatableTransactionScopeActivity1
        '
        Me.compensatableTransactionScopeActivity1.Activities.Add(Me.Debit)
        Me.compensatableTransactionScopeActivity1.Activities.Add(Me.Credit)
        Me.compensatableTransactionScopeActivity1.Activities.Add(Me.compensationHandlerActivity1)
        Me.compensatableTransactionScopeActivity1.Name = "compensatableTransactionScopeActivity1"
        Me.compensatableTransactionScopeActivity1.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable
        '
        'Workflow1
        '
        Me.Activities.Add(Me.compensatableTransactionScopeActivity1)
        Me.Activities.Add(Me.throwActivity1)
        Me.Activities.Add(Me.FinishWorkflow)
        Me.Activities.Add(Me.faultHandlersActivity1)
        Me.Name = "Workflow1"
        Me.CanModifyActivities = False

    End Sub
    Private throwActivity1 As System.Workflow.ComponentModel.ThrowActivity
    Private Credit As System.Workflow.Activities.CodeActivity
    Private Debit As System.Workflow.Activities.CodeActivity
    Private compensatableTransactionScopeActivity1 As System.Workflow.ComponentModel.CompensatableTransactionScopeActivity
    Private compensateOperation As System.Workflow.Activities.CodeActivity
    Private compensationHandlerActivity1 As System.Workflow.ComponentModel.CompensationHandlerActivity
    Private compensateActivity1 As System.Workflow.ComponentModel.CompensateActivity
    Private WorkflowExceptionHandler As System.Workflow.Activities.CodeActivity
    Private faultHandlerActivity1 As System.Workflow.ComponentModel.FaultHandlerActivity
    Private faultHandlersActivity1 As System.Workflow.ComponentModel.FaultHandlersActivity
    Private FinishWorkflow As System.Workflow.Activities.CodeActivity

End Class
