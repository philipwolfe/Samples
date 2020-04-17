' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' Copyright (c) Microsoft Corporation. All rights reserved.

Option Strict On
Option Explicit On

'Class to display an Orbling in the "Current Orbling" list in the options window
Public Class OrblingElement
    Inherits ItemsControl

    Private m_Orbling As ILocalOrbling

    Public Sub New(ByVal orbling As ILocalOrbling)

        If orbling Is Nothing Then
            Throw New ArgumentNullException("orbling")
        End If

        m_Orbling = orbling

        Me.AddText(orbling.GetName())

    End Sub

    Public ReadOnly Property Orbling() As ILocalOrbling
        Get
            Return m_Orbling
        End Get
    End Property

End Class
