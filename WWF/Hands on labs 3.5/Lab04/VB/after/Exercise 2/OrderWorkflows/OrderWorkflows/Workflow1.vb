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

Public class Workflow1
    Inherits StateMachineWorkflowActivity




    Private OrderedCancelledError As String = "Order has been cancelled"

    Public ReadOnly Property OrderCancelledError() As String
        Get
            Return OrderedCancelledError
        End Get
    End Property
    Public Shared OrderEvtArgsProperty As System.Workflow.ComponentModel.DependencyProperty = DependencyProperty.Register("OrderEvtArgs", GetType(OrderLocalServices.OrderEventArgs), GetType(OrderWorkflows.Workflow1))



    <System.ComponentModel.DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <System.ComponentModel.BrowsableAttribute(True)> _
            <System.ComponentModel.CategoryAttribute("Parameters")> _
                Public Property OrderEvtArgs() As OrderLocalServices.OrderEventArgs
        Get
            Return CType(MyBase.GetValue(OrderWorkflows.Workflow1.OrderEvtArgsProperty), OrderLocalServices.OrderEventArgs)

        End Get
        Set(ByVal value As OrderLocalServices.OrderEventArgs)
            MyBase.SetValue(OrderWorkflows.Workflow1.OrderEvtArgsProperty, value)

        End Set
    End Property
    Public Shared OrderSenderProperty As System.Workflow.ComponentModel.DependencyProperty = DependencyProperty.Register("OrderSender", GetType(System.Object), GetType(OrderWorkflows.Workflow1))

    <System.ComponentModel.DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <System.ComponentModel.BrowsableAttribute(True)> _
            <System.ComponentModel.CategoryAttribute("Parameters")> _
                Public Property OrderSender() As System.Object
        Get
            Return CType(MyBase.GetValue(OrderWorkflows.Workflow1.OrderSenderProperty), Object)

        End Get
        Set(ByVal value As System.Object)
            MyBase.SetValue(OrderWorkflows.Workflow1.OrderSenderProperty, value)

        End Set
    End Property




    Private Sub OrderCreated_Invoked(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.ExternalDataEventArgs)

    End Sub

    Private Sub OrderShipped_Invoked(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.ExternalDataEventArgs)

    End Sub
End Class
