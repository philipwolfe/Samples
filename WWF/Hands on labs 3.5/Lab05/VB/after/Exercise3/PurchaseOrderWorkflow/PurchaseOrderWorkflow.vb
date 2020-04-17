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

Public Class PurchaseOrderWorkflow
    Inherits SequentialWorkflowActivity

    Private Sub OnSetupRoles(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim poInitiatorsRole As New WebWorkflowRole("Clerk")
        ' Add the role to the WorkflowRoleCollection representing the POInitiators
        POInitiators.Add(poInitiatorsRole)

    End Sub

    Private Sub OnPOInitiated(ByVal sender As System.Object, ByVal e As ExternalDataEventArgs)
        Console.WriteLine("PO Initiated successfully")
    End Sub

    Private poInitiatorsValue As New WorkflowRoleCollection()

    Public ReadOnly Property POInitiators() As WorkflowRoleCollection
        Get
            Return poInitiatorsValue
        End Get
    End Property

    Private Sub OnInitiatePO(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.ExternalDataEventArgs)
        Console.WriteLine("Purchase Order initiated successfully")
    End Sub

    Private Sub codeActivity1_ExecuteCode(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine("Exception message: {0}", faultHandlerActivity1.Fault.Message.ToString())
    End Sub
End Class
