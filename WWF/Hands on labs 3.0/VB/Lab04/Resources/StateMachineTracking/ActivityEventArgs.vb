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

'Code ported to VB.net by Serge Luca 
'sergeluca@redwood.be
'www.redwood.be

Public Class ActivityEventArgs
    Inherits EventArgs

    ' Methods
    Public Sub New(ByVal type As Type, ByVal qualifiedId As String)
        Me.type = type
        Me._qualifiedId = qualifiedId
    End Sub

    Public ReadOnly Property QualifiedId() As String
        Get
            Return Me._qualifiedId
        End Get
    End Property
    Private _qualifiedId As String
    Private type As Type

End Class
