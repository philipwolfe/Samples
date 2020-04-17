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
Imports System.Workflow.ComponentModel
Imports System.Windows.Forms
Imports Outlook = Microsoft.Office.Interop.Outlook

Partial Public Class AutoReplyEmail
    Inherits System.Workflow.ComponentModel.Activity
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overrides Function Execute(ByVal executionContext As System.Workflow.ComponentModel.ActivityExecutionContext) As System.Workflow.ComponentModel.ActivityExecutionStatus
        MessageBox.Show("Process Auto-Reply for Email")
        ' Create an Outlook Application object. 
        Dim outlookApp As Outlook.Application = New Outlook.Application()

        Dim oMailItem As Outlook._MailItem = CType(outlookApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook._MailItem)
        oMailItem.To = outlookApp.Session.CurrentUser.Address
        oMailItem.Subject = "Auto-Reply"
        oMailItem.Body = "Out of Office"

        'adds it to the outbox      
        oMailItem.Send()

        Return ActivityExecutionStatus.Closed
    End Function

    Dim smtpHostValue As String
    Public Property SmtpHost() As String
        Get
            Return Me.smtpHostValue
        End Get
        Set(ByVal value As String)
            Me.smtpHostValue = value
        End Set
    End Property

    Dim fromValue As String
    Public Property From() As String
        Get
            Return Me.fromValue
        End Get
        Set(ByVal value As String)
            Me.fromValue = value
        End Set
    End Property

    Dim toValue As String
    Public Property [To]() As String
        Get
            Return Me.toValue
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Dim subjectValue As String
    Public Property Subject() As String
        Get
            Return Me.subjectValue
        End Get
        Set(ByVal value As String)
            Me.subjectValue = value
        End Set
    End Property
End Class