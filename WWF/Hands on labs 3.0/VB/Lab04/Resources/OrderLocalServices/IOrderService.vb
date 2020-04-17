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
Imports System.Workflow.ComponentModel
Imports System.Workflow.Activities
Namespace OrderLocalServices
    <Serializable()> _
    Public Class OrderEventArgs
        Inherits ExternalDataEventArgs
        Private _orderId As String

        Public Sub New(ByVal instanceId As Guid, ByVal orderId As String)
            MyBase.New(instanceId)
            _orderId = orderId
        End Sub

        Public Property OrderId() As String
            Get
                Return _orderId
            End Get
            Set(ByVal Value As String)
                _orderId = Value
            End Set
        End Property
    End Class

    <ExternalDataExchange()> _
Public Interface IOrderService
        ' Events
        Event OrderCanceled As EventHandler(Of OrderEventArgs)
        Event OrderCreated As EventHandler(Of OrderEventArgs)
        Event OrderProcessed As EventHandler(Of OrderEventArgs)
        Event OrderShipped As EventHandler(Of OrderEventArgs)
        Event OrderUpdated As EventHandler(Of OrderEventArgs)

    End Interface


End Namespace