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

Imports System
Imports System.Workflow.Activities
Imports System.Workflow.ComponentModel
Imports System.Workflow.ComponentModel.Compiler
Imports System.Text.RegularExpressions
Imports System.Net.Mail

Public Class ParametersValidator
    Inherits ActivityValidator

    Public Overrides Function ValidateProperties(ByVal manager As ValidationManager, _
                        ByVal obj As Object) As ValidationErrorCollection

        Dim validationErrors As ValidationErrorCollection = _
                        New ValidationErrorCollection(MyBase.ValidateProperties(manager, obj))

        Dim sendMailActivityToBeValidated As SendMailActivity = CType(obj, SendMailActivity)
        If IsNothing(sendMailActivityToBeValidated) Then
            Throw New InvalidOperationException("Parameter obj is not of type SendMailActivity")
        End If

        If Not IsValidEmailAddress(sendMailActivityToBeValidated.MailTo) Then
            Dim CustomActivityValidationError As ValidationError = _
                New ValidationError(String.Format("\'{0}\' is an Invalid destination e-mail address", _
                                sendMailActivityToBeValidated.MailTo), 1)

            validationErrors.Add(CustomActivityValidationError)
        End If

        If Not IsValidEmailAddress(sendMailActivityToBeValidated.MailFrom) Then
            Dim CustomActivityValidationError As ValidationError = _
                New ValidationError(String.Format("\'{0}\' is an Invalid source e-mail address", _
                                sendMailActivityToBeValidated.MailFrom), 1)

            validationErrors.Add(CustomActivityValidationError)
        End If

        Return validationErrors
    End Function

    Public Function IsValidEmailAddress(ByVal address As String) As Boolean
        ' must only proceed with validation if we have data to validate
        If ((address = Nothing) OrElse (address.Length = 0)) Then
            Return True
        End If

        Dim rx As Regex = New Regex("[^A-Za-z0-9@\-_.]", RegexOptions.Compiled)
        Dim matches As MatchCollection = rx.Matches(address)

        If (matches.Count > 0) Then
            Return False
        End If

        ' Must have an '@' character
        Dim i As Integer = address.IndexOf(Microsoft.VisualBasic.ChrW(64))

        ' Must be at least three chars after the @
        If ((i <= 0) OrElse (i >= (address.Length - 3))) Then
            Return False
        End If

        ' Must only be one '@' character
        If (address.IndexOf(Microsoft.VisualBasic.ChrW(64), (i + 1)) >= 0) Then
            Return False
        End If

        ' Find the last . in the address
        Dim j As Integer = address.LastIndexOf(Microsoft.VisualBasic.ChrW(46))

        ' The dot can't be before or immediately after the @ char
        If ((j >= 0) AndAlso (j <= (i + 1))) Then
            Return False
        End If

        Return True
    End Function

End Class

