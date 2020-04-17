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

        Private noItemsError As String = "You must add items to the shopping cart"
        Public Property NoItemsErrorMessage() As String
            Get
                Return Me.noItemsError
            End Get
            Set(ByVal value As String)
                Me.noItemsError = value
            End Set
        End Property
        Private checkNumItems As IfElseActivity
        Private ifNoItems As IfElseBranchActivity
        Private elseHasItems As IfElseBranchActivity
        Private terminateNoItems As TerminateActivity

        Private setTotal As CodeActivity
        Private getSubtotal As CodeActivity
        Private sortCart As CodeActivity
        Private checkNumCoupons As IfElseActivity
        Private ifNoCoupons As IfElseBranchActivity
        Private elseHasCoupons As IfElseBranchActivity
        Private conditionedActivityGroup1 As ConditionedActivityGroup
        Private removeCoupon As CodeActivity

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
            Me.CanModifyActivities = True
            Dim ruleconditionreference2 As RuleConditionReference = _
                New RuleConditionReference()
            Dim ruleconditionreference3 As RuleConditionReference = _
                New RuleConditionReference()
            Me.conditionedActivityGroup1 = _
                New System.Workflow.Activities.ConditionedActivityGroup()
            Me.removeCoupon = New System.Workflow.Activities.CodeActivity()
            Me.checkNumItems = New System.Workflow.Activities.IfElseActivity()
            Me.ifNoItems = New System.Workflow.Activities.IfElseBranchActivity()
            Me.elseHasItems = New System.Workflow.Activities.IfElseBranchActivity()
            Dim codecondition1 As System.Workflow.Activities.CodeCondition = _
                New System.Workflow.Activities.CodeCondition()

            Me.terminateNoItems = New System.Workflow.ComponentModel.TerminateActivity()
            Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = _
                New System.Workflow.ComponentModel.ActivityBind()
            Me.sortCart = New System.Workflow.Activities.CodeActivity()
            Me.getSubtotal = New System.Workflow.Activities.CodeActivity()
            Me.setTotal = New System.Workflow.Activities.CodeActivity()
            Me.checkNumCoupons = New System.Workflow.Activities.IfElseActivity()
            Me.ifNoCoupons = New System.Workflow.Activities.IfElseBranchActivity()
            Me.elseHasCoupons = New System.Workflow.Activities.IfElseBranchActivity()
            Dim ruleconditionreference1 As RuleConditionReference = _
                New RuleConditionReference()
            ' 
            ' checkNumItems
            ' 
            Me.checkNumItems.Activities.Add(Me.ifNoItems)
            Me.checkNumItems.Activities.Add(Me.elseHasItems)
            Me.checkNumItems.Name = "checkNumItems"
            ' 
            ' ifNoItems
            ' 
            Me.ifNoItems.Activities.Add(Me.terminateNoItems)
            AddHandler codecondition1.Condition, AddressOf ifNoItems_Condition
            Me.ifNoItems.Condition = codecondition1
            Me.ifNoItems.Name = "ifNoItems"
            ' 
            ' elseHasItems
            ' 
            Me.elseHasItems.Activities.Add(Me.sortCart)
            Me.elseHasItems.Activities.Add(Me.getSubtotal)
            Me.elseHasItems.Activities.Add(Me.checkNumCoupons)
            Me.elseHasItems.Activities.Add(Me.setTotal)
            Me.elseHasItems.Name = "elseHasItems"
            ' 
            ' terminateNoItems
            ' 
            activitybind1.Name = "DiscountWorkflow"
            activitybind1.Path = "NoItemsErrorMessage"
            Me.terminateNoItems.Name = "terminateNoItems"
            Me.terminateNoItems.SetBinding _
                (System.Workflow.ComponentModel.TerminateActivity.ErrorProperty, _
                (CType(activitybind1, System.Workflow.ComponentModel.ActivityBind)))
            ' 
            ' sortCart
            ' 
            Me.sortCart.Name = "sortCart"
            AddHandler Me.sortCart.ExecuteCode, AddressOf Me.SortCartCode
            ' 
            ' getSubtotal
            ' 
            Me.getSubtotal.Name = "getSubtotal"
            AddHandler Me.getSubtotal.ExecuteCode, AddressOf Me.CalculateSubtotalCode
            ' 
            ' setTotal
            ' 
            Me.setTotal.Name = "setTotal"
            AddHandler Me.setTotal.ExecuteCode, AddressOf Me.SetTotalCode
            ' 
            ' checkNumCoupons
            ' 
            Me.checkNumCoupons.Activities.Add(Me.ifNoCoupons)
            Me.checkNumCoupons.Activities.Add(Me.elseHasCoupons)
            Me.checkNumCoupons.Name = "checkNumCoupons"
            ' 
            ' ifNoCoupons
            ' 
            ruleconditionreference1.ConditionName = "noCouponsCondition"
            Me.ifNoCoupons.Condition = ruleconditionreference1
            Me.ifNoCoupons.Name = "ifNoCoupons"
            ' 
            ' elseHasCoupons
            ' 
            Me.elseHasCoupons.Activities.Add(Me.conditionedActivityGroup1)
            Me.elseHasCoupons.Name = "elseHasCoupons"
            ' 
            ' conditionedActivityGroup1
            ' 
            Me.conditionedActivityGroup1.Activities.Add(Me.removeCoupon)
            Me.conditionedActivityGroup1.Name = "conditionedActivityGroup1"
            ruleconditionreference2.ConditionName = "noCouponsCondition"
            Me.conditionedActivityGroup1.UntilCondition = ruleconditionreference2
            ' 
            ' removeCoupon
            ' 
            ruleconditionreference3.ConditionName = "couponsRemaining"
            Me.removeCoupon.Name = "removeCoupon"
            AddHandler Me.removeCoupon.ExecuteCode, AddressOf Me.removeCoupon_ExecuteCode
            Me.removeCoupon.SetValue( _
                ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference3)
            ' 
            ' DiscountWorkflow
            ' 
            Me.Name = "DiscountWorkflow"
            Me.Activities.Add(Me.checkNumItems)
            Me.CanModifyActivities = False
        End Sub

        Private Sub ifNoItems_Condition(ByVal sender As Object, _
            ByVal e As ConditionalEventArgs)
            If Me.Items.Count = 0 Then
                e.Result = True
            Else
                e.Result = False
            End If
        End Sub

        Private Sub CalculateSubtotalCode(ByVal sender As Object, ByVal e As EventArgs)
            For Each item As ItemData In Me.Items
                Me.cartSubTotal += item.price
            Next item
        End Sub

        Private Sub SortCartCode(ByVal sender As Object, ByVal e As EventArgs)
            Me.Items.Sort(New ItemSorter())
        End Sub

        Private Sub SetTotalCode(ByVal sender As Object, ByVal e As EventArgs)
            Me.cartTotal = Me.cartSubTotal - Me.cartDiscount
        End Sub

        Private Sub removeCoupon_ExecuteCode(ByVal sender As Object, _
            ByVal e As EventArgs)
            Me.Coupons.Dequeue()
        End Sub
    End Class

    Public Class ItemSorter : Implements IComparer(Of DiscountWorkflow.ItemData)
        Public Function Compare(ByVal item1 As DiscountWorkflow.ItemData, _
            ByVal item2 As DiscountWorkflow.ItemData) As Integer _
            Implements System.Collections.Generic.IComparer _
            (Of DiscountWorkflow.ItemData).Compare
            Return item1.price.CompareTo(item2.price)
        End Function
    End Class
End Namespace
