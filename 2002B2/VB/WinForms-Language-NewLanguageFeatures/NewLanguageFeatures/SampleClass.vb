Public Class SampleClass
    Protected mstrValue As String
    Protected mstrValue1 As String
    'Overloads the constructor of class
    Public Sub New()
        mstrValue = " the default value."
    End Sub
    'Overloads the constructor of class
    Public Sub New(ByVal strValue As String)
        mstrValue = strValue
    End Sub

    Public Overridable Function GetValue() As String
        Return "Loaded with " & mstrValue
    End Function

    Public Property MyProp() As String
        Get
            Return mstrValue
        End Get
        Set(ByVal Value As String)
            mstrValue = Value
        End Set
    End Property
    Public Property MyProp1() As String
        Get
            Return mstrValue1
        End Get
        Set(ByVal Value As String)
            mstrValue1 = Value
        End Set
    End Property

End Class
