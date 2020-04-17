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
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Hosting

Namespace Microsoft.Samples.Workflow.Tutorials.RulesAndConditions
    Public Class PointOfSaleSimulator : Inherits Form
        Private cartSubTotal As Double = 0
        Private cartDiscount As Double = 0
        Private cartTotal As Double = 0
        Private workflowArgs As Dictionary(Of String, Object)
        Private workflowRuntime As WorkflowRuntime = New WorkflowRuntime()


#Region "UI Controls"
        Private groupBox1 As System.Windows.Forms.GroupBox
        Private groupBox2 As System.Windows.Forms.GroupBox
        Private WithEvents btnMoveToCart As System.Windows.Forms.Button
        Private WithEvents btnRemoveFromCart As System.Windows.Forms.Button
        Private lvAvailableItems As System.Windows.Forms.ListView
        Private lvCartItems As System.Windows.Forms.ListView
        Private groupBox3 As System.Windows.Forms.GroupBox
        Private lvAvailableCoupons As System.Windows.Forms.ListView
        Private groupBox4 As System.Windows.Forms.GroupBox
        Private lvUsedCoupons As System.Windows.Forms.ListView
        Private WithEvents btnMoveFromCoupons As System.Windows.Forms.Button
        Private WithEvents btnMoveToCoupons As System.Windows.Forms.Button
        Private chItemName As System.Windows.Forms.ColumnHeader
        Private chItemPrice As System.Windows.Forms.ColumnHeader
        Private label1 As System.Windows.Forms.Label
        Private tbSubTotal As System.Windows.Forms.TextBox
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private tbDiscount As System.Windows.Forms.TextBox
        Private label4 As System.Windows.Forms.Label
        Private tbTotal As System.Windows.Forms.TextBox
        Private WithEvents btnCheckout As System.Windows.Forms.Button
        Private columnHeader1 As System.Windows.Forms.ColumnHeader
        Private columnHeader2 As System.Windows.Forms.ColumnHeader
#End Region

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Not components Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim listViewItem1 As ListViewItem = New ListViewItem( _
                New String() {"Apples", "1.00"}, -1)
            Dim listViewItem2 As ListViewItem = New ListViewItem( _
                New String() {"Oranges", "1.00"}, -1)
            Dim listViewItem3 As ListViewItem = New ListViewItem( _
                New String() {"Cheese", "5.00"}, -1)
            Dim listViewItem4 As ListViewItem = New ListViewItem( _
                New String() {"Magazine", "3.00"}, -1)
            Dim listViewItem5 As ListViewItem = New ListViewItem( _
                New String() {"Toy Car", "2.00"}, -1)
            Dim listViewItem6 As ListViewItem = New ListViewItem( _
                New String() {"Game", "50.00"}, -1)
            Dim listViewItem7 As ListViewItem = New ListViewItem( _
                New String() {"Lettuce", "0.60"}, -1)
            Dim listViewItem8 As ListViewItem = New ListViewItem( _
                New String() {"20% Off Total Price", "Total", "20"}, -1)
            Dim listViewItem9 As ListViewItem = New ListViewItem( _
                New String() {"15% Off Lowest Item", "Lowest", "15"}, -1)
            Dim listViewItem10 As ListViewItem = New ListViewItem( _
                New String() {"Buy Any 5 Get Lowest Free", "FreeItem", "5"}, -1)
            Dim listViewItem11 As ListViewItem = New ListViewItem( _
                New String() {"10% Off Highest Item", "Highest", "10"}, -1)
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.lvAvailableItems = New System.Windows.Forms.ListView()
            Me.chItemName = New System.Windows.Forms.ColumnHeader()
            Me.chItemPrice = New System.Windows.Forms.ColumnHeader()
            Me.groupBox2 = New System.Windows.Forms.GroupBox()
            Me.lvCartItems = New System.Windows.Forms.ListView()
            Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
            Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
            Me.btnMoveToCart = New System.Windows.Forms.Button()
            Me.btnRemoveFromCart = New System.Windows.Forms.Button()
            Me.groupBox3 = New System.Windows.Forms.GroupBox()
            Me.lvAvailableCoupons = New System.Windows.Forms.ListView()
            Me.groupBox4 = New System.Windows.Forms.GroupBox()
            Me.lvUsedCoupons = New System.Windows.Forms.ListView()
            Me.btnMoveFromCoupons = New System.Windows.Forms.Button()
            Me.btnMoveToCoupons = New System.Windows.Forms.Button()
            Me.label1 = New System.Windows.Forms.Label()
            Me.tbSubTotal = New System.Windows.Forms.TextBox()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.tbDiscount = New System.Windows.Forms.TextBox()
            Me.label4 = New System.Windows.Forms.Label()
            Me.tbTotal = New System.Windows.Forms.TextBox()
            Me.btnCheckout = New System.Windows.Forms.Button()
            Me.groupBox1.SuspendLayout()
            Me.groupBox2.SuspendLayout()
            Me.groupBox3.SuspendLayout()
            Me.groupBox4.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Controls.Add(Me.lvAvailableItems)
            Me.groupBox1.Location = New System.Drawing.Point(13, 12)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(246, 167)
            Me.groupBox1.TabIndex = 0
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Available Store Items"
            ' 
            ' lvAvailableItems
            ' 
            Me.lvAvailableItems.Columns.AddRange(New ColumnHeader() _
                {Me.chItemName, Me.chItemPrice})
            Me.lvAvailableItems.FullRowSelect = True
            Me.lvAvailableItems.HideSelection = False
            Me.lvAvailableItems.Items.AddRange(New ListViewItem() _
                {listViewItem1, listViewItem2, listViewItem3, listViewItem4, _
                listViewItem5, listViewItem6, listViewItem7})
            Me.lvAvailableItems.Location = New System.Drawing.Point(7, 20)
            Me.lvAvailableItems.Name = "lvAvailableItems"
            Me.lvAvailableItems.Size = New System.Drawing.Size(233, 141)
            Me.lvAvailableItems.TabIndex = 0
            Me.lvAvailableItems.UseCompatibleStateImageBehavior = False
            Me.lvAvailableItems.View = System.Windows.Forms.View.Details
            ' 
            ' chItemName
            ' 
            Me.chItemName.Name = "chItemName"
            Me.chItemName.Text = "Item"
            ' 
            ' chItemPrice
            ' 
            Me.chItemPrice.Name = "chItemPrice"
            Me.chItemPrice.Text = "Price"
            ' 
            ' groupBox2
            ' 
            Me.groupBox2.Controls.Add(Me.lvCartItems)
            Me.groupBox2.Location = New System.Drawing.Point(307, 12)
            Me.groupBox2.Name = "groupBox2"
            Me.groupBox2.Size = New System.Drawing.Size(246, 167)
            Me.groupBox2.TabIndex = 1
            Me.groupBox2.TabStop = False
            Me.groupBox2.Text = "Shopping Cart"
            ' 
            ' lvCartItems
            ' 
            Me.lvCartItems.Columns.AddRange(New ColumnHeader() _
                {Me.columnHeader1, Me.columnHeader2})
            Me.lvCartItems.FullRowSelect = True
            Me.lvCartItems.HideSelection = False
            Me.lvCartItems.Location = New System.Drawing.Point(6, 19)
            Me.lvCartItems.Name = "lvCartItems"
            Me.lvCartItems.Size = New System.Drawing.Size(233, 141)
            Me.lvCartItems.TabIndex = 1
            Me.lvCartItems.UseCompatibleStateImageBehavior = False
            Me.lvCartItems.View = System.Windows.Forms.View.Details
            ' 
            ' columnHeader1
            ' 
            Me.columnHeader1.Name = "columnHeader1"
            Me.columnHeader1.Text = "Item"
            ' 
            ' columnHeader2
            ' 
            Me.columnHeader2.Name = "columnHeader2"
            Me.columnHeader2.Text = "Price"
            ' 
            ' btnMoveToCart
            ' 
            Me.btnMoveToCart.Location = New System.Drawing.Point(265, 63)
            Me.btnMoveToCart.Name = "btnMoveToCart"
            Me.btnMoveToCart.Size = New System.Drawing.Size(36, 23)
            Me.btnMoveToCart.TabIndex = 2
            Me.btnMoveToCart.Text = ">>"
            Me.btnMoveToCart.UseVisualStyleBackColor = True
            ' 
            ' btnRemoveFromCart
            ' 
            Me.btnRemoveFromCart.Location = New System.Drawing.Point(265, 101)
            Me.btnRemoveFromCart.Name = "btnRemoveFromCart"
            Me.btnRemoveFromCart.Size = New System.Drawing.Size(36, 23)
            Me.btnRemoveFromCart.TabIndex = 3
            Me.btnRemoveFromCart.Text = "<<"
            Me.btnRemoveFromCart.UseVisualStyleBackColor = True
            ' 
            ' groupBox3
            ' 
            Me.groupBox3.Controls.Add(Me.lvAvailableCoupons)
            Me.groupBox3.Location = New System.Drawing.Point(13, 185)
            Me.groupBox3.Name = "groupBox3"
            Me.groupBox3.Size = New System.Drawing.Size(246, 130)
            Me.groupBox3.TabIndex = 1
            Me.groupBox3.TabStop = False
            Me.groupBox3.Text = "Available Coupons"
            ' 
            ' lvAvailableCoupons
            ' 
            Me.lvAvailableCoupons.HideSelection = False
            Me.lvAvailableCoupons.Items.AddRange(New ListViewItem() _
                {listViewItem8, listViewItem9, listViewItem10, listViewItem11})
            Me.lvAvailableCoupons.Location = New System.Drawing.Point(6, 19)
            Me.lvAvailableCoupons.Name = "lvAvailableCoupons"
            Me.lvAvailableCoupons.Size = New System.Drawing.Size(233, 101)
            Me.lvAvailableCoupons.TabIndex = 2
            Me.lvAvailableCoupons.UseCompatibleStateImageBehavior = False
            Me.lvAvailableCoupons.View = System.Windows.Forms.View.List
            ' 
            ' groupBox4
            ' 
            Me.groupBox4.Controls.Add(Me.lvUsedCoupons)
            Me.groupBox4.Location = New System.Drawing.Point(307, 185)
            Me.groupBox4.Name = "groupBox4"
            Me.groupBox4.Size = New System.Drawing.Size(246, 130)
            Me.groupBox4.TabIndex = 1
            Me.groupBox4.TabStop = False
            Me.groupBox4.Text = "Used Coupons"
            ' 
            ' lvUsedCoupons
            ' 
            Me.lvUsedCoupons.HideSelection = False
            Me.lvUsedCoupons.Location = New System.Drawing.Point(6, 19)
            Me.lvUsedCoupons.Name = "lvUsedCoupons"
            Me.lvUsedCoupons.Size = New System.Drawing.Size(233, 101)
            Me.lvUsedCoupons.TabIndex = 3
            Me.lvUsedCoupons.UseCompatibleStateImageBehavior = False
            Me.lvUsedCoupons.View = System.Windows.Forms.View.List
            ' 
            ' btnMoveFromCoupons
            ' 
            Me.btnMoveFromCoupons.Location = New System.Drawing.Point(265, 260)
            Me.btnMoveFromCoupons.Name = "btnMoveFromCoupons"
            Me.btnMoveFromCoupons.Size = New System.Drawing.Size(36, 23)
            Me.btnMoveFromCoupons.TabIndex = 5
            Me.btnMoveFromCoupons.Text = "<<"
            Me.btnMoveFromCoupons.UseVisualStyleBackColor = True
            ' 
            ' btnMoveToCoupons
            ' 
            Me.btnMoveToCoupons.Location = New System.Drawing.Point(265, 221)
            Me.btnMoveToCoupons.Name = "btnMoveToCoupons"
            Me.btnMoveToCoupons.Size = New System.Drawing.Size(36, 23)
            Me.btnMoveToCoupons.TabIndex = 4
            Me.btnMoveToCoupons.Text = ">>"
            Me.btnMoveToCoupons.UseVisualStyleBackColor = True
            AddHandler btnMoveToCoupons.Click, AddressOf btnMoveToCoupons_Click
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(206, 333)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(46, 13)
            Me.label1.TabIndex = 6
            Me.label1.Text = "Subtotal"
            ' 
            ' tbSubTotal
            ' 
            Me.tbSubTotal.Location = New System.Drawing.Point(258, 329)
            Me.tbSubTotal.Name = "tbSubTotal"
            Me.tbSubTotal.ReadOnly = True
            Me.tbSubTotal.Size = New System.Drawing.Size(100, 20)
            Me.tbSubTotal.TabIndex = 7
            ' 
            ' label2
            ' 
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(206, 361)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(49, 13)
            Me.label2.TabIndex = 8
            Me.label2.Text = "Discount"
            ' 
            ' label3
            ' 
            Me.label3.AutoSize = True
            Me.label3.Location = New System.Drawing.Point(206, 374)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(175, 13)
            Me.label3.TabIndex = 9
            Me.label3.Text = "____________________________"
            ' 
            ' tbDiscount
            ' 
            Me.tbDiscount.Location = New System.Drawing.Point(258, 357)
            Me.tbDiscount.Name = "tbDiscount"
            Me.tbDiscount.ReadOnly = True
            Me.tbDiscount.Size = New System.Drawing.Size(100, 20)
            Me.tbDiscount.TabIndex = 10
            ' 
            ' label4
            ' 
            Me.label4.AutoSize = True
            Me.label4.Location = New System.Drawing.Point(206, 398)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(31, 13)
            Me.label4.TabIndex = 11
            Me.label4.Text = "Total"
            ' 
            ' tbTotal
            ' 
            Me.tbTotal.Location = New System.Drawing.Point(258, 395)
            Me.tbTotal.Name = "tbTotal"
            Me.tbTotal.ReadOnly = True
            Me.tbTotal.Size = New System.Drawing.Size(100, 20)
            Me.tbTotal.TabIndex = 12
            ' 
            ' btnCheckout
            ' 
            Me.btnCheckout.Location = New System.Drawing.Point(113, 333)
            Me.btnCheckout.Name = "btnCheckout"
            Me.btnCheckout.Size = New System.Drawing.Size(75, 23)
            Me.btnCheckout.TabIndex = 13
            Me.btnCheckout.Text = "Checkout"
            Me.btnCheckout.UseVisualStyleBackColor = True
            ' 
            ' PointOfSaleSimulator
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(569, 425)
            Me.Controls.Add(Me.btnCheckout)
            Me.Controls.Add(Me.tbTotal)
            Me.Controls.Add(Me.label4)
            Me.Controls.Add(Me.tbDiscount)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.tbSubTotal)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.btnMoveFromCoupons)
            Me.Controls.Add(Me.btnMoveToCoupons)
            Me.Controls.Add(Me.groupBox4)
            Me.Controls.Add(Me.groupBox3)
            Me.Controls.Add(Me.btnRemoveFromCart)
            Me.Controls.Add(Me.btnMoveToCart)
            Me.Controls.Add(Me.groupBox2)
            Me.Controls.Add(Me.groupBox1)
            Me.Name = "PointOfSaleSimulator"
            Me.Text = "Point of Sale Simulator"
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox2.ResumeLayout(False)
            Me.groupBox3.ResumeLayout(False)
            Me.groupBox4.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Public Sub New()
            InitializeComponent()
            workflowRuntime.StartRuntime()

            AddHandler workflowRuntime.WorkflowCompleted, _
                AddressOf workflowRuntime_WorkflowCompleted
            AddHandler workflowRuntime.WorkflowTerminated, _
                AddressOf workflowRuntime_WorkflowTerminated
        End Sub

        Public Property SubTotal() As Double
            Get
                Return Me.cartSubTotal
            End Get
            Set(ByVal value As Double)
                Me.cartSubTotal = value
                Me.tbSubTotal.Text = Me.cartSubTotal.ToString("C")
            End Set
        End Property

        Public Property Discount() As Double
            Get
                Return Me.cartDiscount
            End Get
            Set(ByVal value As Double)
                Me.cartDiscount = value
                Me.tbDiscount.Text = Me.cartDiscount.ToString("C")
            End Set
        End Property

        Public Property Total() As Double
            Get
                Return Me.cartTotal
            End Get
            Set(ByVal value As Double)
                Me.cartTotal = value
                Me.tbTotal.Text = Me.cartTotal.ToString("C")
            End Set
        End Property

        Private Sub btnMoveToCart_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles btnMoveToCart.Click
            For Each item As ListViewItem In lvAvailableItems.SelectedItems
                Dim newItem As ListViewItem = CType(item.Clone(), ListViewItem)
                Me.lvCartItems.Items.Add(newItem)

                Me.SubTotal += Double.Parse(item.SubItems(1).Text)
            Next item
        End Sub

        Private Sub btnRemoveFromCart_Click(ByVal sender As Object, _
            ByVal e As EventArgs) Handles btnRemoveFromCart.Click
            For Each item As ListViewItem In lvCartItems.SelectedItems
                lvCartItems.Items.Remove(item)
                Me.SubTotal -= Double.Parse(item.SubItems(1).Text)
            Next item
        End Sub

        Private Sub btnMoveToCoupons_Click(ByVal sender As Object, _
            ByVal e As EventArgs) Handles btnMoveToCoupons.Click
            For Each item As ListViewItem In Me.lvAvailableCoupons.SelectedItems
                Me.lvAvailableCoupons.Items.Remove(item)
                Me.lvUsedCoupons.Items.Add(item)
            Next item
        End Sub

        Private Sub btnMoveFromCoupons_Click(ByVal sender As Object, _
            ByVal e As EventArgs) Handles btnMoveFromCoupons.Click
            For Each item As ListViewItem In Me.lvUsedCoupons.SelectedItems
                Me.lvUsedCoupons.Items.Remove(item)
                Me.lvAvailableCoupons.Items.Add(item)
            Next item
        End Sub
        Private Sub btnCheckout_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles btnCheckout.Click
            BuildWorkflowArgs()

            Dim type As Type = GetType(DiscountWorkflow)
            workflowRuntime.CreateWorkflow(type, workflowArgs).Start()
        End Sub

        Private Sub BuildWorkflowArgs()
            Dim coupons As Queue(Of DiscountWorkflow.Coupon) = _
                New Queue(Of DiscountWorkflow.Coupon)()
            Dim items As List(Of DiscountWorkflow.ItemData) = _
                New List(Of DiscountWorkflow.ItemData)()

            For Each item As ListViewItem In lvCartItems.Items
                items.Add(New DiscountWorkflow.ItemData(item.Text, _
                    Double.Parse(item.SubItems(1).Text)))
            Next item

            For Each item As ListViewItem In lvUsedCoupons.Items
                Select Case item.SubItems(1).Text
                    Case "Highest"
                        coupons.Enqueue(New DiscountWorkflow.Coupon( _
                            DiscountWorkflow.CouponType.PercentageOffHighest, _
                            Int32.Parse(item.SubItems(2).Text)))
                    Case "Lowest"
                        coupons.Enqueue(New DiscountWorkflow.Coupon( _
                            DiscountWorkflow.CouponType.PercentageOffLowest, _
                            Int32.Parse(item.SubItems(2).Text)))
                    Case "FreeItem"
                        coupons.Enqueue(New DiscountWorkflow.Coupon( _
                            DiscountWorkflow.CouponType.FreeItem, _
                            Int32.Parse(item.SubItems(2).Text)))
                    Case "Total"
                        coupons.Enqueue(New DiscountWorkflow.Coupon( _
                            DiscountWorkflow.CouponType.PercentageOffTotal, _
                            Int32.Parse(item.SubItems(2).Text)))
                End Select
            Next item

            Me.workflowArgs = New Dictionary(Of String, Object)()
            Me.workflowArgs("Coupons") = coupons
            Me.workflowArgs("Items") = items

            Return
        End Sub

        Private Sub workflowRuntime_WorkflowTerminated(ByVal sender As Object, _
            ByVal e As WorkflowTerminatedEventArgs)
            MessageBox.Show("Workflow terminated: " & e.Exception.Message)
        End Sub

        Private Sub UpdateDiscountAndTotal(ByVal sender As Object, _
            ByVal e As DiscountUpdateEventArgs)
            Me.Discount = e.Discount
            Me.Total = e.Total
        End Sub

        Private Sub workflowRuntime_WorkflowCompleted(ByVal sender As Object, _
            ByVal e As WorkflowCompletedEventArgs)
            If Me.InvokeRequired Then
                Dim discount As Double = Double.Parse( _
                    e.OutputParameters("Discount").ToString())
                Dim total As Double = Double.Parse( _
                    e.OutputParameters("Total").ToString())

                Dim values As DiscountUpdateEventArgs = _
                    New DiscountUpdateEventArgs(discount, total)
                Me.Invoke(New EventHandler(Of DiscountUpdateEventArgs) _
                    (AddressOf UpdateDiscountAndTotal), New Object() {sender, values})
            Else
                Me.Discount = Double.Parse(e.OutputParameters("Discount").ToString())
                Me.Total = Double.Parse(e.OutputParameters("Total").ToString())
            End If
        End Sub
    End Class

    Public Class DiscountUpdateEventArgs : Inherits EventArgs
        Private cartDiscount As Double
        Private cartTotal As Double

        Public Sub New(ByVal discount As Double, ByVal total As Double)
            Me.cartDiscount = discount
            Me.cartTotal = Total
        End Sub

        Public ReadOnly Property Discount() As Double
            Get
                Return cartDiscount
            End Get
        End Property

        Public ReadOnly Property Total() As Double
            Get
                Return cartTotal
            End Get
        End Property
    End Class
End Namespace
