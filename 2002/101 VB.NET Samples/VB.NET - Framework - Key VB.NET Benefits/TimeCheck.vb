'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.TimeSpan
Imports System.DateTime

Public Class TimeCheck

    Private m_dtmBegin As DateTime
    Private m_EndSpan As TimeSpan

    ' Begin the timecheck
    Public Sub [Begin]()
        m_dtmBegin = DateTime.Now
    End Sub

    ' End the timecheck
    Public Sub [End]()
        m_EndSpan = DateTime.Now.Subtract(m_dtmBegin)
    End Sub

    Public ReadOnly Property Milliseconds() As Long
        Get
            Milliseconds = CType(m_EndSpan.TotalMilliseconds, Long)
        End Get
    End Property

End Class
