Option Strict On

Imports System.Diagnostics

' This class is used to store a counter, as well as define a
'   ToString() method that can be used by a ComboBox to display the
'   instance and name of the counter.
' Note: This is an excellent way to define how a ComboBox displays
'   values.
Public Class CounterDisplayItem
    ' Store an instance of the counter inside the class
    Private m_Counter As PerformanceCounter

    ' Define a constructor, that requires that the PerformanceCounter
    '   be passed.  Store the passed counter.
    Public Sub New(ByVal inCounter As PerformanceCounter)
        ' Only store the passed value if it is, indeed, a counter.
        If TypeName(inCounter) = "PerformanceCounter" Then
            m_Counter = inCounter
        Else
            m_Counter = Nothing
        End If
    End Sub

    ' This property gets or sets the PerformanceCounter stored by 
    '   a CounterDisplayItem object.
    Public Property Counter() As PerformanceCounter
        Get
            Return m_Counter
        End Get
        Set(ByVal Value As PerformanceCounter)
            m_Counter = Value
        End Set
    End Property

    ' This function overrides the ToString() method to display the
    '   information about the Counter that will be necessary for the 
    '   user to select the proper counter.
    Public Overrides Function ToString() As String
        If Not m_Counter Is Nothing Then
            Return m_Counter.InstanceName + " - " + m_Counter.CounterName
        Else
            Return ""
        End If
    End Function

    ' This property returns a True if the counter is a custom counter, and 
    '   a false otherwise. Since there is no IsCustom property of a 
    '   PerformanceCounter object, a special bit of code is used. This code
    '   simple attempts to set the ReadOnly property to False, then read a 
    '   value from the counter. This will raise an exception if the counter
    '   is NOT a custom counter, otherwise it will not.
    Public ReadOnly Property IsCustom() As Boolean
        Get
            ' Store the current value of the ReadOnly property
            Dim isReadOnly As Boolean = m_Counter.ReadOnly
            Try
                ' The only way NextValue works when ReadOnly
                '   is False, is if the Counter is a Custom counter.
                '   Unfortunately, there is no property in the 
                '   PerformanceCounter object that already returns whether
                '   the counter is Custom.
                m_Counter.ReadOnly = False
                m_Counter.NextValue()

                ' If it makes it here, it is a custom counter
                Return True
            Catch exc As Exception
                ' This is not a custom counter
                Return False
            Finally
                ' Reset the value to the previous value
                m_Counter.ReadOnly = isReadOnly
            End Try
        End Get
    End Property
End Class
