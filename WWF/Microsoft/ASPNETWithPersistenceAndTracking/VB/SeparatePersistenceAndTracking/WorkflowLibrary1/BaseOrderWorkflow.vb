'--------------------------------------------------------------------------------
' This file is part of the Windows Workflow Foundation Sample Code
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

Public class BaseOrderWorkflow
    Inherits StateMachineWorkflowActivity

    Public OrderSender As System.Object = New System.Object
    Public OrderCanceledError As String = "Order has been canceled"
    Public OrderEvtArgs As OrderEventArgs = Nothing

    Public Sub OrderCreated_Invoked(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.ExternalDataEventArgs)

    End Sub
    Public Sub OrderShipped_Invoked(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.ExternalDataEventArgs)

    End Sub
End Class
