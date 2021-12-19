Public Class FormInfo

    Public Name As String
    Public Description As String
    Public AssemblyName As String
    Public TypeName As String
    Public UrlLocation As String
    Public UrlImage As String

End Class


<AttributeUsage(AttributeTargets.Class)> Public Class FormNameAttribute
    Inherits System.Attribute

    Private myName As String = ""

    Public Sub New(ByVal value As String)
        myName = value
    End Sub

    Public ReadOnly Property Name() As String
        Get
            Return myName
        End Get
    End Property

End Class

<AttributeUsage(AttributeTargets.Class)> Public Class FormDescriptionAttribute
    Inherits System.Attribute

    Private myDescription As String = ""

    Public Sub New(ByVal value As String)
        myDescription = value
    End Sub

    Public ReadOnly Property Description() As String
        Get
            Return myDescription
        End Get
    End Property

End Class
