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

'Code ported to VB.net by Serge Luca 
'sergeluca@redwood.be
'www.redwood.be


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports OrderLocalServices
Namespace OrderLocalServices
    Public Class OrderService
        Implements IOrderService
     

        Public Sub RaiseOrderCreatedEvent(ByVal orderId As String, ByVal instanceId As Guid)

            'If Not OrderCreated Is Nothing Then
            RaiseEvent OrderCreated(Nothing, New OrderEventArgs(instanceId, orderId))
            'End If
        End Sub

        Public Sub RaiseOrderShippedEvent(ByVal orderId As String, ByVal instanceId As Guid)
            'If Not OrderShipped Is Nothing Then
            RaiseEvent OrderShipped(Nothing, New OrderEventArgs(instanceId, orderId))
            'End If
        End Sub

        Public Sub RaiseOrderUpdatedEvent(ByVal orderId As String, ByVal instanceId As Guid)
            'If Not OrderUpdated Is Nothing Then
            RaiseEvent OrderUpdated(Nothing, New OrderEventArgs(instanceId, orderId))
            'End If
        End Sub
        Public Sub RaiseOrderProcessedEvent(ByVal orderId As String, ByVal instanceId As Guid)
            'If Not OrderProcessed Is Nothing Then
            RaiseEvent OrderProcessed(Nothing, New OrderEventArgs(instanceId, orderId))
            'End If
        End Sub
        Public Sub RaiseOrderCanceledEvent(ByVal orderId As String, ByVal instanceId As Guid)
            'If Not OrderCanceledx Is Nothing Then
            RaiseEvent OrderCanceled(Nothing, New OrderEventArgs(instanceId, orderId))
            'End If
        End Sub

        Public Event OrderCanceled(ByVal sender As Object, ByVal e As OrderEventArgs) Implements IOrderService.OrderCanceled
        Public Event OrderCreated(ByVal sender As Object, ByVal e As OrderEventArgs) Implements IOrderService.OrderCreated
        Public Event OrderProcessed(ByVal sender As Object, ByVal e As OrderEventArgs) Implements IOrderService.OrderProcessed
        Public Event OrderShipped(ByVal sender As Object, ByVal e As OrderEventArgs) Implements IOrderService.OrderShipped
        Public Event OrderUpdated(ByVal sender As Object, ByVal e As OrderEventArgs) Implements IOrderService.OrderUpdated

    End Class

End Namespace