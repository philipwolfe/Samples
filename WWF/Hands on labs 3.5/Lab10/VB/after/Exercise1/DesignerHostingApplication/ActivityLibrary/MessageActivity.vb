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

    Private m_message As String
    Public Property Message() As String
        Get
            Return m_message
        End Get
        Set(ByVal value As String)
            m_message = value
        End Set
    End Property
    Protected Overrides Function Execute(ByVal executionContext As ActivityExecutionContext) As ActivityExecutionStatus
        MessageBox.Show(Me.Message)
        Return ActivityExecutionStatus.Closed
    End Function




End Class
