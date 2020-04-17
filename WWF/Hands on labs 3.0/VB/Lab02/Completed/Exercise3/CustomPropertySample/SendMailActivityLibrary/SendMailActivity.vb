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

Imports System.Net.Mail

'NOTE: When changing the namespace; please update XmlnsDefinitionAttribute in AssemblyInfo.vb
<ActivityValidator(GetType(ParametersValidator))> _
Public Class SendMailActivity
    Inherits System.Workflow.ComponentModel.Activity
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Public Shared MailToProperty As DependencyProperty = _
                DependencyProperty.Register("MailTo", GetType(String), GetType(SendMailActivity))

    <Description("To Email Address")> _
    <Category("EmailActivity")> _
    <Browsable(True)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property MailTo() As String
        Get
            Return (CType((MyBase.GetValue(SendMailActivity.MailToProperty)), String))
        End Get
        Set(ByVal Value As String)
            MyBase.SetValue(SendMailActivity.MailToProperty, Value)
        End Set
    End Property

    Public Shared MailFromProperty As DependencyProperty = DependencyProperty.Register("MailFrom", GetType(String), GetType(SendMailActivity))

    <Description("From Email Address")> _
    <Category("EmailActivity")> _
    <Browsable(True)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property MailFrom() As String
        Get
            Return (CType((MyBase.GetValue(SendMailActivity.MailFromProperty)), String))
        End Get
        Set(ByVal Value As String)
            MyBase.SetValue(SendMailActivity.MailFromProperty, Value)
        End Set
    End Property

    Public Shared SubjectProperty As DependencyProperty = DependencyProperty.Register("Subject", GetType(String), GetType(SendMailActivity))

    <Description("Subject of Email")> _
    <Category("EmailActivity")> _
    <Browsable(True)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Subject() As String
        Get
            Return (CType((MyBase.GetValue(SendMailActivity.SubjectProperty)), String))
        End Get
        Set(ByVal Value As String)
            MyBase.SetValue(SendMailActivity.SubjectProperty, Value)
        End Set
    End Property

    Public Shared BodyProperty As DependencyProperty = DependencyProperty.Register("Body", GetType(String), GetType(SendMailActivity))

    <Description("Body of Email")> _
    <Category("EmailActivity")> _
    <Browsable(True)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Body() As String
        Get
            Return (CType((MyBase.GetValue(SendMailActivity.BodyProperty)), String))
        End Get
        Set(ByVal Value As String)
            MyBase.SetValue(SendMailActivity.BodyProperty, Value)
        End Set
    End Property

    Protected Overrides Function Execute(ByVal executionContext As ActivityExecutionContext) _
                                As ActivityExecutionStatus
        Dim toAddress As MailAddress = New MailAddress(MailTo)
        Dim fromAddress As MailAddress = New MailAddress(MailFrom)

        Dim addresses As MailAddressCollection = New MailAddressCollection
        addresses.Add(toAddress)

        Dim msg As MailMessage = New MailMessage(fromAddress, toAddress)

        msg.Subject = Subject
        msg.Body = Body

        Dim mail As SmtpClient = New SmtpClient("localhost")

        mail.Send(msg)
        Return ActivityExecutionStatus.Closed
    End Function
End Class
