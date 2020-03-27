' The Category class is a custom type that is used for databinding to a ComboBox.
' Notice the use of public properties instead of merely public fields. You might
' think you could use the following construct:
'
'   Public Class Category
'       Public ID As Integer
'       Public Name As String

'       Sub New(ByVal intID As Integer, ByVal strName As String)
'           ID = intID
'           Name = strName
'       End Sub
'   End Class
'
' This will, however, throw a runtime InvalidArgumentException stating that it 
' cannot bind to the new DisplayMember. The Property does not have to be 
' ReadOnly.
Class Category
    Dim _ID As Integer
    Dim _Name As String

    Sub New(ByVal intID As Integer, ByVal strName As String)
        _ID = intID
        _Name = strName
    End Sub

    Public ReadOnly Property ID() As Integer
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _Name
        End Get
    End Property
End Class