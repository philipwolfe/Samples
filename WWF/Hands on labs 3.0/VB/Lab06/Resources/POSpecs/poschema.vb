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

Imports System.Threading
Namespace POSchema


    <Serializable()> _
    Public Class PO
        ' Methods


        Public Shared Sub CopyHistoryAndChangeStatus(ByVal sourcePO As PO, ByVal destinationPO As PO, ByVal newStatus As String)
            If (Not sourcePO.History Is Nothing) Then
                destinationPO.History = New POStatus((sourcePO.History.Length + 1) - 1) {}
                Dim num1 As Integer = 0
                Do While (num1 < sourcePO.History.Length)
                    destinationPO.History(num1) = New POStatus
                    destinationPO.History(num1).Contact = sourcePO.History(num1).Contact
                    destinationPO.History(num1).PoStatus = sourcePO.History(num1).PoStatus
                    destinationPO.History(num1).Timestamp = sourcePO.History(num1).Timestamp
                    num1 += 1
                Loop
                destinationPO.History(sourcePO.History.Length) = New POStatus
                destinationPO.History(sourcePO.History.Length).Contact = Thread.CurrentPrincipal.Identity.Name
                If (sourcePO.Items Is Nothing) Then
                    destinationPO.History(sourcePO.History.Length).PoStatus = "Rejected"
                Else
                    destinationPO.History(sourcePO.History.Length).PoStatus = newStatus
                End If
                destinationPO.History(sourcePO.History.Length).Timestamp = DateTime.Now
            Else
                destinationPO.History = New POStatus() {New POStatus}
                destinationPO.History(0).Contact = Thread.CurrentPrincipal.Identity.Name
                destinationPO.History(0).PoStatus = "Rejected due to no history"
            End If
        End Sub



        Public Shared Sub CopyPOItems(ByVal sourcePO As PO, ByVal destinationPO As PO)
            If (Not sourcePO.Items Is Nothing) Then
                destinationPO.Items = New POItem(sourcePO.Items.Length - 1) {}
                Dim num1 As Integer = 0
                Do While (num1 < sourcePO.Items.Length)
                    destinationPO.Items(num1) = New POItem
                    destinationPO.Items(num1).Sku = sourcePO.Items(num1).Sku
                    destinationPO.Items(num1).Price = sourcePO.Items(num1).Price
                    destinationPO.Items(num1).Amount = sourcePO.Items(num1).Amount
                    num1 += 1
                Loop
            End If
        End Sub



        Public Shared Function GeneratePOInstance() As PO
            Dim po1 As New PO
            po1.PONumber = Guid.NewGuid.ToString
            po1.FulfillerTrackingNumber = ""
            po1.History = New POStatus() {New POStatus}
            po1.History(0).Contact = Thread.CurrentPrincipal.Identity.Name
            po1.History(0).PoStatus = "New"
            po1.History(0).Timestamp = DateTime.Now
            po1.Items = New POItem(2 - 1) {}
            po1.Items(0) = New POItem
            po1.Items(0).Sku = "1234"
            po1.Items(0).Price = 12
            po1.Items(0).Amount = 5
            po1.OrderTotal = (po1.OrderTotal + (po1.Items(0).Price * po1.Items(0).Amount))
            po1.Items(1) = New POItem
            po1.Items(1).Sku = "5678"
            po1.Items(1).Price = 43.5
            po1.Items(1).Amount = 3
            po1.OrderTotal = (po1.OrderTotal + (po1.Items(1).Price * po1.Items(1).Amount))
            Return po1
        End Function


        Public Shared Sub GenerateResponseHeader(ByVal sourcePO As PO, ByVal destinationPO As PO, ByVal trackingRef As String)
            destinationPO.PONumber = sourcePO.PONumber
            destinationPO.OrderTotal = sourcePO.OrderTotal
            destinationPO.FulfillerTrackingNumber = (trackingRef & sourcePO.PONumber)
        End Sub




        ' Properties
        Public Property FulfillerTrackingNumber() As String
            Get
                Return Me._fulfillerTrackingNumber
            End Get
            Set(ByVal value As String)
                Me._fulfillerTrackingNumber = value
            End Set
        End Property


        Public Property History() As POStatus()
            Get
                Return Me._history
            End Get
            Set(ByVal value As POStatus())
                Me._history = value
            End Set
        End Property


        Public Property Items() As POItem()
            Get
                Return Me._items
            End Get
            Set(ByVal value As POItem())
                Me._items = value
            End Set
        End Property



        Public Property OrderTotal() As Double
            Get
                Return Me._orderTotal
            End Get
            Set(ByVal value As Double)
                Me._orderTotal = value
            End Set
        End Property



        Public Property PONumber() As String
            Get
                Return Me._poNumber
            End Get
            Set(ByVal value As String)
                Me._poNumber = value
            End Set
        End Property


        ' Fields
        Private _fulfillerTrackingNumber As String
        Private _history As POStatus()
        Private _items As POItem()
        Private _orderTotal As Double
        Private _poNumber As String

    End Class



    <Serializable()> _
    Public Class POItem



        Public Property Amount() As Double
            Get
                Return _amount
            End Get
            Set(ByVal value As Double)
                _amount = value
            End Set
        End Property

        Public Property Price() As Double
            Get
                Return _price
            End Get
            Set(ByVal value As Double)
                _price = value
            End Set
        End Property
        Public Property Sku() As String
            Get
                Return _sku
            End Get
            Set(ByVal value As String)
                _sku = value
            End Set
        End Property

        ' Fields
        Private _amount As Double
        Private _price As Double
        Private _sku As String

    End Class

    <Serializable()> _
    Public Class POStatus

        Public Property Contact() As String
            Get
                Return _contact
            End Get
            Set(ByVal value As String)
                _contact = value
            End Set
        End Property

        Public Property PoStatus() As String
            Get
                Return _poStatus
            End Get
            Set(ByVal value As String)
                _poStatus = value
            End Set
        End Property

        Public Property Timestamp() As DateTime
            Get
                Return _timestamp
            End Get
            Set(ByVal value As DateTime)
                _timestamp = value
            End Set
        End Property


        ' Fields
        Private _contact As String
        Private _poStatus As String
        Private _timestamp As DateTime

    End Class




End Namespace