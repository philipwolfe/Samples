' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' Copyright (c) Microsoft Corporation. All rights reserved.

Option Strict On
Option Explicit On

''' <summary>
''' A file which contains the extra information needed by *local* orblings. 
''' Remote orblings retrieve this infromation from the ServiceClasses project.
''' </summary>
''' <remarks></remarks>

Public Enum OrblingType
    Remote 
    Local 
    Application 
    Service
End Enum

Public Interface ILocalOrbling

    Function GetInformation(ByVal Options As OrbOptionValues) As OrbDisplay

    Function GetTime() As TimeSpan

    Function GetOptions() As OrbOptions

    Function GetName() As String

    Function GetConnectionType() As OrblingType

End Interface

Partial Public Class OrbColor

    Public Sub New(ByVal clrOption As OrbColorOption)

        If clrOption Is Nothing Then
            Throw New ArgumentNullException("clrOption")
        End If

        Me.ColorValueR = clrOption.Value.R
        Me.ColorValueG = clrOption.Value.G
        Me.ColorValueB = clrOption.Value.B
    End Sub

    Public Sub New(ByVal clr As Color)
        Me.ColorValueR = clr.R
        Me.ColorValueG = clr.G
        Me.ColorValueB = clr.B
    End Sub

    Public Function GetColor() As Color
        Return Color.FromRgb(CByte(ColorValueR), CByte(ColorValueG), CByte(ColorValueB))
    End Function
End Class

Partial Public Class OrbPulseDescriber

    Sub New(ByVal count As Integer)
        Me.New(count, Colors.White)
    End Sub

    Sub New(ByVal count As Integer, ByVal pulseColor As Color)
        m_PulseCount = count
        m_PulseColor = New OrbColor(pulseColor)
    End Sub

    'Returns a never ending pulse
    Public Shared ReadOnly Property Forever() As OrbPulseDescriber
        Get
            Dim pCounter As New OrbPulseDescriber(0)
            pCounter.m_IsForever = True

            Return pCounter
        End Get
    End Property


    Public ReadOnly Property IsForever() As Boolean
        Get
            Return m_IsForever
        End Get
    End Property

    Public ReadOnly Property PulseColor() As OrbColor
        Get
            Return m_PulseColor
        End Get
    End Property

    Public ReadOnly Property PulseCount() As Integer
        Get
            If m_IsForever Then
                Throw New InvalidOperationException("A Non-terminating PulseCounter cannot have a finite count.")
            Else
                Return m_PulseCount
            End If
        End Get
    End Property
End Class