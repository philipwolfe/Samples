
Public Class LavaOrbling
    Implements ILocalOrbling

    'GetOptions Method

    Function GetOptions() As OrbOptions Implements ILocalOrbling.GetOptions

        Dim myOptions As New OrbOptions

        myOptions.ComponentName = "LavaOrbling"
        myOptions.ComponentDescription = "Random Colors Display"

        myOptions.ComponentProperties = New Dictionary(Of String, Object)
        Return myOptions
    End Function


    'GetName Method

    Function GetName() As String Implements ILocalOrbling.GetName
        Return "LavaOrbling"
    End Function


    'GetType Method

    Function GetConnectionType() As OrblingType Implements ILocalOrbling.GetConnectionType
        Return OrblingType.Local
    End Function

    'GetTime Method

    Function GetTime() As TimeSpan Implements ILocalOrbling.GetTime
        Return TimeSpan.FromSeconds(10)
    End Function


    'GetInformation Method

    Function GetInformation(ByVal Options As OrbOptionValues) As OrbDisplay Implements ILocalOrbling.GetInformation

        'Return a randomly chosen color
        Dim returnDisplay As New OrbDisplay

        Dim propertyList As Array = GetType(Colors).GetProperties()

        Dim randomColorIndex As Integer = New Random().Next(0, propertyList.Length - 1)

        Dim colorProperty As System.Reflection.PropertyInfo = propertyList(randomColorIndex)

        Dim randomColorValue As Color = CType(colorProperty.GetValue(Nothing, Nothing), Color)

        returnDisplay.DisplayColor = New OrbColor(randomColorValue)

        Return returnDisplay
    End Function

End Class

