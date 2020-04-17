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

Imports System.Windows.Forms

Public Class MessageActivity
    Inherits Activity

    Public Shared MessageProperty As DependencyProperty = DependencyProperty.Register("Message", GetType(String), GetType(MessageActivity))

    <Description("The Message to display in the MessageBox")> _
    <Browsable(True)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Message() As String
        Get
            Return (CType((MyBase.GetValue(MessageActivity.MessageProperty)), String))
        End Get
        Set(ByVal Value As String)
            MyBase.SetValue(MessageActivity.MessageProperty, Value)
        End Set
    End Property

    Protected Overrides Function Execute(ByVal executionContext As ActivityExecutionContext) As ActivityExecutionStatus
        MessageBox.Show(Me.Message)
        Return ActivityExecutionStatus.Closed
    End Function




End Class
