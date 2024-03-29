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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendMailWorkflow

    'NOTE: The following procedure is required by the Workflow Designer
    'It can be modified using the Workflow Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Me.sendMail = New SendMailActivityLibrary.SendMailActivity
        '
        'sendMail
        '
        Me.sendMail.Body = "body of email"
        Me.sendMail.MailFrom = "email@any.domain"
        Me.sendMail.MailTo = "email@some.domain"
        Me.sendMail.Name = "sendMail"
        Me.sendMail.Subject = "subject of email"
        '
        'SendMailWorkflow
        '
        Me.Activities.Add(Me.sendMail)
        Me.Name = "SendMailWorkflow"
        Me.CanModifyActivities = False

    End Sub
    Private WithEvents sendMail As SendMailActivityLibrary.SendMailActivity

End Class
