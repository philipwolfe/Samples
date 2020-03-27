Imports System.Windows.Forms.Design
Imports System.Text


#Region "Latitude type"

' Implement custom types for Latitude.
Public Class Latitude

    Public Enum DirectionEnum
        North
        South
    End Enum

    Private v As Single
    Private d As DirectionEnum

    Public Property Direction() As DirectionEnum
        Get
            Return d
        End Get
        Set(ByVal value As DirectionEnum)
            d = value
        End Set
    End Property

    Public Property Value() As Single
        Get
            Return v
        End Get
        Set(ByVal value As Single)
            If (0 <= value And value <= 90) Then
                v = value
            Else
                Throw New Exception("Invalid Latitude value.")
            End If
        End Set
    End Property

    Public Sub New(ByVal value As Single, ByVal direction As DirectionEnum)

        Me.Value = value
        Me.Direction = direction
    End Sub

    ' Constructor: "97.3 N", "123 S"
    Public Sub New(ByVal latitude As String)

        Dim parts As String() = latitude.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
        Me.Value = Single.Parse(parts(0))

        Select Case parts(1).ToUpper()
            Case "N"
                Me.Direction = DirectionEnum.North
                Exit Select
            Case "S"
                Me.Direction = DirectionEnum.South
                Exit Select
            Case Else
                Throw New ApplicationException("Invalid latitude. You must specify N or S.")
        End Select
    End Sub

    Public Overrides Function ToString() As String
        Dim directionString As String
        If Me.Direction = DirectionEnum.North Then
            directionString = "N"
        Else
            directionString = "S"
        End If

        Return Me.Value.ToString() + " " + directionString
    End Function

    ' A public static Parse method is required for MaskedTextBox 
    ' custom type validation
    Public Shared Function Parse(ByVal latitude As String) As Latitude
        Return New Latitude(latitude)
    End Function

End Class

#End Region

#Region "LatitudeMaskDescriptor"

' Implement a MaskDescriptor for the Latitude type.  
' The InputMask dialog will display all types for which
' a MaskDescriptor is found.
Public Class LatitudeMaskDescriptor
    Inherits MaskDescriptor

    Public Overrides ReadOnly Property Mask() As String
        Get
            Return "00 >L"
        End Get
    End Property

    Public Overrides ReadOnly Property Name() As String
        Get
            Return "Latitude"
        End Get
    End Property

    Public Overrides ReadOnly Property Sample() As String
        Get
            Return "58 N"
        End Get
    End Property

    Public Overrides ReadOnly Property ValidatingType() As Type
        Get
            Return GetType(Latitude)
        End Get
    End Property

End Class

#End Region
