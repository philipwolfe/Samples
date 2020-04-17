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
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Reflection
Imports System.Workflow.ComponentModel.Compiler
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Design
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.Workflow.Activities.Rules

Namespace Microsoft.Samples.Workflow.Tutorials.RulesAndConditions
    Public NotInheritable Class DiscountWorkflow : Inherits SequentialWorkflowActivity
        Private cartCoupons As Queue(Of Coupon) = New Queue(Of Coupon)()
        Private cartItems As List(Of ItemData) = New List(Of ItemData)()

        Private cartDiscount As Double = 0.0
        Private cartTotal As Double = 0.0
        Private cartSubTotal As Double = 0.0

        Public Enum CouponType
            PercentageOffTotal
            PercentageOffLowest
            PercentageOffHighest
            FreeItem
        End Enum

        Public Structure ItemData
            Public name As String
            Public price As Double

            Public Sub New(ByVal name As String, ByVal price As Double)
                Me.name = name
                Me.price = price
            End Sub
        End Structure

        Public Structure Coupon
            Public type As CouponType
            Public couponData As Integer

            Public Sub New(ByVal type As CouponType, ByVal couponData As Integer)
                Me.type = type
                Me.couponData = couponData
            End Sub
        End Structure

        Public Property Coupons() As Queue(Of Coupon)
            Get
                Return Me.cartCoupons
            End Get
            Set(ByVal value As Queue(Of Coupon))
                Me.cartCoupons = value
            End Set
        End Property

        Public Property Items() As List(Of ItemData)
            Get
                Return Me.cartItems
            End Get
            Set(ByVal value As List(Of ItemData))
                Me.cartItems = value
            End Set
        End Property

        Public Property Discount() As Double
            Get
                Return Me.cartDiscount
            End Get
            Private Set(ByVal value As Double)
                Me.cartDiscount = value
            End Set
        End Property

        Public Property Total() As Double
            Get
                Return Me.cartTotal
            End Get
            Private Set(ByVal value As Double)
                Me.cartTotal = value
            End Set
        End Property

        Private Property SubTotal() As Double
            Get
                Return Me.cartSubTotal
            End Get
            Set(ByVal value as Double)
                Me.cartSubTotal = value
            End Set
        End Property
        
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.Name = "DiscountWorkflow"
        End Sub
    End Class
End Namespace

