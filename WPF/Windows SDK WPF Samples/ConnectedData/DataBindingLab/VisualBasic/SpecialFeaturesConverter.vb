Public Class SpecialFeaturesConverter
    Implements IMultiValueConverter

    Public Overridable Function Convert(ByVal values As Object(), ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IMultiValueConverter.Convert
        Dim Rating As Integer = CType(values(0), Integer)
        Dim DateVal As DateTime = CType(values(1), DateTime)

        If ((Rating >= 10) And (DateVal.Date < (DateTime.Now.Date - New TimeSpan(365, 0, 0, 0)))) Then
            Return True
        End If

        Return False
    End Function

    Public Overridable Function ConvertBack(ByVal value As Object, ByVal targetTypes As Type(), ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Return New Object(1) {Binding.DoNothing, Binding.DoNothing}
    End Function

End Class
