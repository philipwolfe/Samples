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
        Me.WorkflowExceptionHandler = New System.Workflow.Activities.CodeActivity
        Me.faultHandlerActivity1 = New System.Workflow.ComponentModel.FaultHandlerActivity
        Me.throwActivity1 = New System.Workflow.ComponentModel.ThrowActivity
        Me.Credit = New System.Workflow.Activities.CodeActivity
        Me.Debit = New System.Workflow.Activities.CodeActivity
        Me.cancellationHandlerActivity1 = New System.Workflow.ComponentModel.CancellationHandlerActivity
        Me.faultHandlersActivity1 = New System.Workflow.ComponentModel.FaultHandlersActivity
        Me.FinishWorkflow = New System.Workflow.Activities.CodeActivity
        Me.transactionScopeActivity1 = New System.Workflow.ComponentModel.TransactionScopeActivity
        '
        'WorkflowExceptionHandler
        '
        Me.WorkflowExceptionHandler.Name = "WorkflowExceptionHandler"
        AddHandler Me.WorkflowExceptionHandler.ExecuteCode, AddressOf Me.OnException
        '
        'faultHandlerActivity1
        '
        Me.faultHandlerActivity1.Activities.Add(Me.WorkflowExceptionHandler)
        Me.faultHandlerActivity1.FaultType = GetType(System.Exception)
        Me.faultHandlerActivity1.Name = "faultHandlerActivity1"
        activitybind1.Name = "Workflow1"
        activitybind1.Path = "exception"
        '
        'throwActivity1
        '
        Me.throwActivity1.Enabled = False
        Me.throwActivity1.FaultType = GetType(System.Exception)
        Me.throwActivity1.Name = "throwActivity1"
        Me.throwActivity1.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
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
        'cancellationHandlerActivity1
        '
        Me.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1"
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
        '
        'transactionScopeActivity1
        '
        Me.transactionScopeActivity1.Activities.Add(Me.Debit)
        Me.transactionScopeActivity1.Activities.Add(Me.Credit)
        Me.transactionScopeActivity1.Activities.Add(Me.throwActivity1)
        Me.transactionScopeActivity1.Name = "transactionScopeActivity1"
        Me.transactionScopeActivity1.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable
        '
        'Workflow1
        '
        Me.Activities.Add(Me.transactionScopeActivity1)
        Me.Activities.Add(Me.FinishWorkflow)
        Me.Activities.Add(Me.faultHandlersActivity1)
        Me.Activities.Add(Me.cancellationHandlerActivity1)
        Me.Name = "Workflow1"
        Me.CanModifyActivities = False

    End Sub
    Private cancellationHandlerActivity1 As System.Workflow.ComponentModel.CancellationHandlerActivity
    Private throwActivity1 As System.Workflow.ComponentModel.ThrowActivity
    Private Credit As System.Workflow.Activities.CodeActivity
    Private Debit As System.Workflow.Activities.CodeActivity
    Private transactionScopeActivity1 As System.Workflow.ComponentModel.TransactionScopeActivity
    Private WorkflowExceptionHandler As System.Workflow.Activities.CodeActivity
    Private faultHandlerActivity1 As System.Workflow.ComponentModel.FaultHandlerActivity
    Private faultHandlersActivity1 As System.Workflow.ComponentModel.FaultHandlersActivity
    Private FinishWorkflow As System.Workflow.Activities.CodeActivity

End Class
