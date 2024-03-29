'----------------------------------------------------------------------
'   This file is part of the Windows Workflow Foundation SDK Code Samples.
'  
'   Copyright (C) Microsoft Corporation.  All rights reserved.
'  
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
'  
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'----------------------------------------------------------------------

Imports System
Imports System.Workflow.Activities

Public Class SampleWorkflow
    Inherits SequentialWorkflowActivity

    Private Sub ExpenseApproval_Executing(ByVal sender As System.Object, ByVal e As System.Workflow.ComponentModel.ActivityExecutionStatusChangedEventArgs)
        Console.WriteLine("Workflow: waiting for approval")
    End Sub

    Private Sub SubmitExpense_MethodInvoking(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine("Workflow: submits expense report")
    End Sub
End Class
