Public Class SampleDerivedClass
    Inherits New_Language_Features.SampleClass
    Private mlngValue As Long
    'Overloaded constructors
    Public Sub New(ByVal lngValue As Long)
        mlngValue = lngValue
        mstrValue = "the Numeric value of " & lngValue.ToString
    End Sub
    Public Sub New(ByVal strValue As String)
        mstrValue = "the string " & strValue
    End Sub

    'Overrides the base classes implementation of GetValue but
    'will call the base classes implementation in the derived version.
    Public Overrides Function GetValue() As String
        Return "Derived " & MyBase.GetValue 'Calls the base classes implementation.
    End Function
End Class
