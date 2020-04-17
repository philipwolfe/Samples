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

Imports System
Imports System.Workflow.Activities

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class PurchaseOrderWorkflow

    'NOTE: The following procedure is required by the Workflow Designer
    'It can be modified using the Workflow Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Dim activitybind1 As New System.Workflow.ComponentModel.ActivityBind
        Me.codeActivity1 = New System.Workflow.Activities.CodeActivity
        Me.faultHandlerActivity1 = New System.Workflow.ComponentModel.FaultHandlerActivity
        Me.faultHandlersActivity1 = New System.Workflow.ComponentModel.FaultHandlersActivity
        Me.InitiatePO = New System.Workflow.Activities.HandleExternalEventActivity
        Me.SetupRoles = New System.Workflow.Activities.CodeActivity
        '
        'codeActivity1
        '
        Me.codeActivity1.Name = "codeActivity1"
        AddHandler Me.codeActivity1.ExecuteCode, AddressOf Me.codeActivity1_ExecuteCode
        '
        'faultHandlerActivity1
        '
        Me.faultHandlerActivity1.Activities.Add(Me.codeActivity1)
        Me.faultHandlerActivity1.FaultType = GetType(System.Workflow.Activities.WorkflowAuthorizationException)
        Me.faultHandlerActivity1.Name = "faultHandlerActivity1"
        '
        'faultHandlersActivity1
        '
        Me.faultHandlersActivity1.Activities.Add(Me.faultHandlerActivity1)
        Me.faultHandlersActivity1.Name = "faultHandlersActivity1"
        activitybind1.Name = "PurchaseOrderWorkflow"
        activitybind1.Path = "POInitiators"
        '
        'InitiatePO
        '
        Me.InitiatePO.EventName = "InitiatePurchaseOrderEventHandler"
        Me.InitiatePO.InterfaceType = GetType(Microsoft.Samples.Workflow.WebWorkflow.IStartPurchaseOrder)
        Me.InitiatePO.Name = "InitiatePO"
        AddHandler Me.InitiatePO.Invoked, AddressOf Me.OnInitiatePO
        Me.InitiatePO.SetBinding(System.Workflow.Activities.HandleExternalEventActivity.RolesProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
        '
        'SetupRoles
        '
        Me.SetupRoles.Name = "SetupRoles"
        AddHandler Me.SetupRoles.ExecuteCode, AddressOf Me.OnSetupRoles
        '
        'PurchaseOrderWorkflow
        '
        Me.Activities.Add(Me.SetupRoles)
        Me.Activities.Add(Me.InitiatePO)
        Me.Activities.Add(Me.faultHandlersActivity1)
        Me.Name = "PurchaseOrderWorkflow"
        Me.CanModifyActivities = False

    End Sub
    Private codeActivity1 As System.Workflow.Activities.CodeActivity
    Private faultHandlerActivity1 As System.Workflow.ComponentModel.FaultHandlerActivity
    Private faultHandlersActivity1 As System.Workflow.ComponentModel.FaultHandlersActivity
    Private SetupRoles As System.Workflow.Activities.CodeActivity
    Private InitiatePO As System.Workflow.Activities.HandleExternalEventActivity

End Class
