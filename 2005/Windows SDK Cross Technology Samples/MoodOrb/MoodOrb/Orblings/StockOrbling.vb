Option Strict On
Option Explicit On


Public Class StockOrbling
    Implements ILocalOrbling

    'GetOptions Method

    Function GetOptions() As OrbOptions Implements ILocalOrbling.GetOptions

        Dim myOptions As New OrbOptions

        myOptions.ComponentName = "StockOrbling"
        myOptions.ComponentDescription = "Status Indicator of a given stock symbol"

        myOptions.ComponentProperties = New Dictionary(Of String, Object)

        'The default stock list
        Dim stockList As New OrbListOption()
        stockList.Add("MSFT")

        myOptions.ComponentProperties.Add("Stock Symbols", stockList)
        myOptions.ComponentProperties.Add("Neutral Color", New OrbColorOption(Colors.Yellow))
        myOptions.ComponentProperties.Add("Gain Color", New OrbColorOption(Colors.Green))
        myOptions.ComponentProperties.Add("Loss Color", New OrbColorOption(Colors.Coral))
        myOptions.ComponentProperties.Add("Great Gain Color", New OrbColorOption(Colors.LightBlue))
        myOptions.ComponentProperties.Add("Great Loss Color", New OrbColorOption(Colors.Red))

        Return myOptions
    End Function


    'GetName Method

    Function GetName() As String Implements ILocalOrbling.GetName
        Return "StockOrbling"
    End Function


    'GetType Method

    Function GetConnectionType() As OrblingType Implements ILocalOrbling.GetConnectionType
        Return OrblingType.Remote
    End Function

    'GetTime Method

    Function GetTime() As TimeSpan Implements ILocalOrbling.GetTime
        Return TimeSpan.FromMinutes(10)
    End Function


    'GetInformation Method

    Function GetInformation(ByVal Options As OrbOptionValues) As OrbDisplay Implements ILocalOrbling.GetInformation

        Dim returnDisplay As New OrbDisplay

        Try

            Dim myProxy As New StockQuoteSoapProxy("StockDefault")

            Dim symbolList As OrbListOption = CType(Options.ComponentProperties("Stock Symbols"), OrbListOption)

            Dim symbol As String

            Dim xmlDoc As Xml.XmlDocument

            Dim totalChange As Double = 0

            For Each symbol In symbolList

                xmlDoc = New Xml.XmlDocument()
                xmlDoc.LoadXml(myProxy.GetQuote(symbol))

                Dim percentChange As Double = 0

                Double.TryParse((xmlDoc.SelectSingleNode("StockQuotes/Stock/PercentageChange").InnerText).Replace("%", ""), percentChange)

                totalChange += percentChange
            Next

            returnDisplay.DisplayColor = New OrbColor(CType(Options.ComponentProperties("Neutral Color"), OrbColorOption))

            If (totalChange > 0) Then
                returnDisplay.DisplayColor = New OrbColor(CType(Options.ComponentProperties("Gain Color"), OrbColorOption))
            End If
            If (totalChange > 1) Then
                returnDisplay.DisplayColor = New OrbColor(CType(Options.ComponentProperties("Great Gain Color"), OrbColorOption))
            End If

            If (totalChange < 0) Then
                returnDisplay.DisplayColor = New OrbColor(CType(Options.ComponentProperties("Loss Color"), OrbColorOption))
            End If
            If (totalChange < -1) Then
                returnDisplay.DisplayColor = New OrbColor(CType(Options.ComponentProperties("Great Loss Color"), OrbColorOption))
            End If

        Catch ex As Exception
            returnDisplay.DisplayColor = New OrbColor(Colors.Red)
            returnDisplay.DisplayType = OrbAnimationType.Pulse
            returnDisplay.PulseInformation = OrbPulseDescriber.Forever
            returnDisplay.DisplayMessage = "Stock Service Error."
        End Try

        Return returnDisplay
    End Function

End Class
