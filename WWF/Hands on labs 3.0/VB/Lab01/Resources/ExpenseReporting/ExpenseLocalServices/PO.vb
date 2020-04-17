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

Imports System.Workflow.Activities
Imports System.Security.Principal

<Serializable()> _
Public Class InitiatePOArgs
    Inherits ExternalDataEventArgs

    Private myItemId As Integer
    Private myItemName As String
    Private myAmount As Single

    Public Sub New()
        MyBase.New(Guid.NewGuid)

    End Sub

    Public Sub New(ByVal instanceId As Guid, ByVal itemID As Integer, ByVal itemName As String, ByVal amount As Single)
        MyBase.New(instanceId)
        Me.itemId = itemID
        Me.itemName = itemName
        Me.amount = amount
    End Sub

    Public Property ItemId() As Integer
        Get
            Return Me.myItemId
        End Get
        Set(ByVal value As Integer)
            Me.myItemId = value
        End Set
    End Property

    Public Property ItemName() As String
        Get
            Return Me.myItemName
        End Get
        Set(ByVal value As String)
            Me.myItemName = value
        End Set
    End Property

    Public Property Amount() As Single
        Get
            Return Me.myAmount
        End Get
        Set(ByVal value As Single)
            Me.myAmount = value
        End Set
    End Property
End Class

<ExternalDataExchangeAttribute()> _
Public Interface IStartPurchaseOrder

    Event InitiatePurchaseOrder As EventHandler(Of InitiatePOArgs)
End Interface
' Use the code example below to register the workflow communications interface with WorkflowServiceContainer
' WorkflowRuntime container = new WorkflowRuntime(new WorkflowRuntimeSection());
'
' container.AddService(new IStartPurchaseOrderImpl());
Public Class IStartPurchaseOrderImpl
    Implements IStartPurchaseOrder

    Public Event InitiatePurchaseOrder As EventHandler(Of InitiatePOArgs) Implements IStartPurchaseOrder.InitiatePurchaseOrder

    Public Sub InvokePORequest(ByVal instanceId As Guid, ByVal itemId As Integer, ByVal itemCost As Single, ByVal itemName As String, ByVal identity As IIdentity)
        Dim args As InitiatePOArgs = New InitiatePOArgs(instanceId, itemId, itemName, itemCost)
        args.Identity = CStr(identity)

        Console.WriteLine("Purchase Order initiated by: {0}", identity.Name)

        RaiseEvent InitiatePurchaseOrder(Nothing, args)

    End Sub
End Class

