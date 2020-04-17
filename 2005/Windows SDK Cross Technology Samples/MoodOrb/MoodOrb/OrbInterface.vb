

Public Interface IOrb

    'GetOptions Method

    Function GetOptions() As OrbOptions

    'GetInformation Method

    Function GetInformation(ByVal Options As OrbOptionValues) As OrbDisplay

    'GetTime Method

    Function GetTime() As TimeSpan

End Interface

Public Enum OrbAnimationType
    StaticColor = 0
    Pulse = 1
    Range = 2
End Enum

Public Structure OrbOptions
    Public ComponentName As String
    Public ComponentDescription As String
    Public ComponentProperties As Dictionary(Of String, Object)
End Structure

Public Class OrbDisplay
    'Set the default animation to none
    Public DisplayType As OrbAnimationType = OrbAnimationType.StaticColor
    Public DisplayColor As Color
    'Set the default pulse information to a never ending pulse (even though the default animation is solid color)
    Public PulseInformation As PulseDescriber = PulseDescriber.Forever

    Public Class PulseDescriber

        Private m_PulseCount As Integer
        Private m_IsForever As Boolean
        Private m_PulseColor As Color


        Sub New(ByVal count As Integer)
            Me.New(count, Colors.White)
        End Sub

        Sub New(ByVal count As Integer, ByVal pulseColor As Color)
            m_PulseCount = count
            m_PulseColor = pulseColor
        End Sub

        Public Shared ReadOnly Property Forever() As PulseDescriber
            Get
                Dim pCounter As New PulseDescriber(0)
                pCounter.m_IsForever = True

                Return pCounter
            End Get
        End Property

	'Is this a never-ending pulse?
        Public ReadOnly Property IsForever() As Boolean
            Get
                Return m_IsForever
            End Get
        End Property

        Public ReadOnly Property Color() As Color
            Get
                Return m_PulseColor
            End Get
        End Property

	'How many counts does this pulse have?
        Public ReadOnly Property Count() As Integer
            Get
                If m_IsForever Then
                    Throw New InvalidOperationException("A Non-terminating PulseCounter cannot have a finite count.")
                Else
                    Return m_PulseCount
                End If
            End Get
        End Property

    End Class

End Class

Public Structure OrbOptionValues
    Public ComponentProperties As Dictionary(Of String, Object)
End Structure
