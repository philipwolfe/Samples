' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' Copyright (c) Microsoft Corporation. All rights reserved.

'Installation class required for NT Service installation
<RunInstaller(True)> _
Public Class ProjectInstaller
    Inherits Installer

    Private process As ServiceProcessInstaller
    Private service As ServiceInstaller

    Public Sub New()

        process = New ServiceProcessInstaller()
        process.Account = ServiceAccount.LocalSystem
        service = New ServiceInstaller()
        'Specify the name and description of the service here
        service.ServiceName = "WeatherOrblingService"
        service.Description = "This is a service which downloads weather information and is consumed by the Mood Orb Sample"
        Installers.Add(process)
        Installers.Add(service)
    End Sub
End Class


Public Class WeatherService
    Inherits ServiceBase
    Implements IOrbling

    Private m_ServiceHost As ServiceHost
    Private m_ZipCode As Integer
    Private m_Location As GeographicLocation
    Private m_ZipList As Dictionary(Of String, GeographicLocation)

    Public Shared Sub Main()
        'Run the service when this executable is started
        ServiceBase.Run(New WeatherService())
    End Sub

    Public Sub New()

        'This service name must match that used above in the installer
        Me.ServiceName = "WeatherOrblingService"
    End Sub

    Protected Overrides Sub OnStart(ByVal args As String())

        If Not (m_ServiceHost Is Nothing) Then
            m_ServiceHost.Close()
        End If

        Try
            'Get the Address from the settings (this can be found in App.config)
            Dim baseAddress As New Uri(System.Configuration.ConfigurationManager.AppSettings("baseAddress"))

            'Open the service on the saved address

            m_ServiceHost = New ServiceHost(GetType(WeatherService), baseAddress)

            m_ServiceHost.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub


    Protected Overrides Sub OnStop()
        If Not (m_ServiceHost Is Nothing) Then
            m_ServiceHost.Close()
            m_ServiceHost = Nothing
        End If
    End Sub

    Public Function GetInformation(ByVal options As OrbOptionValues) As OrbDisplay Implements IOrbling.GetInformation

        'Define the colors used
        Dim RainyColor = Colors.DarkBlue
        Dim SnowyColor = Colors.WhiteSmoke
        Dim CloudyColor = Colors.Gray
        Dim SunnyColor = Colors.SkyBlue
        Dim DefaultColor = Colors.Blue

        'Pick and choose color information as a result of weather conditions
        Dim displayInformation As New OrbDisplay

        'Deserialize the options
        options.ComponentProperties = OrbOption.DeserializeOptions(options.ComponentProperties)

        Try

            'Check the zip code for changes
            Dim ZipOption As OrbZipCodeOption = CType(options.ComponentProperties("Zip Code"), OrbZipCodeOption)

            If Not (m_ZipCode = ZipOption.Value) Then
                'We have a new zip code, save it and load its lat and long
                m_ZipCode = ZipOption.Value

                SetLocationFromZipCode(ZipOption.StringValue)

            End If

            'Get the weather data

            'NOTE: The following code is commented out due to a known issue with
            'the communication protocol at the time of PDC
            'Therefore, a blank XML document is sent in instread

            'TODO: When proxy is fixed, uncomment below:

            'Dim service As New ndfdXMLPortTypeProxy("WeatherDefault")

            'Dim requestDay As New Microsoft.Samples.MoodOrb.NDFDgenByDay_RequestMessage

            'requestDay.format = formatType.Item12hourly
            ' requestDay.latitude = m_Location.Latitude
            ' requestDay.longitude = m_Location.Longitude
            'requestDay.startDate = DateTime.Now
            'requestDay.numDays = "1"

            'Dim responseDay As Microsoft.Samples.MoodOrb.NDFDgenByDay_ResponseMessage = service.NDFDgenByDay(requestDay)

            'TODO: When proxy is fixed, uncomment above


            'Process the weather XML
            Dim weatherXML As New XmlDocument

            'TODO: When proxy is fixed, uncomment below:
            'weatherXML.LoadXml(responseDay.dwmlByDayOut)


            'Get the time code
            Dim timeNode As XmlNode = weatherXML.SelectSingleNode("dwml/data/time-layout")

            If timeNode Is Nothing Then
                Throw New InvalidOperationException("The weather data returned is invalid. Please check http://www.weather.gov/xml for any changes.")
            End If

            Dim timeCode As String = ""
            Dim startNode As XmlNode = timeNode.SelectSingleNode("start-valid-time")

            'Check to make sure it is the node we want
            If Not startNode Is Nothing Then
                If startNode.Attributes("period-name").Value = "Today" Then
                    timeCode = timeNode.SelectSingleNode("layout-key").InnerText
                End If
            End If

            If timeCode.Length = 0 Then
                Throw New InvalidOperationException("The weather data returned is invalid. Please check http://www.weather.gov/xml for any changes.")
            End If

            Dim todayHigh As Double = 0

            'Get the high for today
            Dim temperatureNodes As XmlNodeList = weatherXML.SelectNodes("dwml/data/parameters/temperature")

            For Each tempNode As XmlNode In temperatureNodes
                If tempNode.Attributes("time-layout").Value = timeCode Then
                    If tempNode.Attributes("type").Value = "maximum" Then
                        'today's high temperature
                        todayHigh = Double.Parse(tempNode.SelectSingleNode("value").InnerText)
                        Exit For
                    End If
                End If
            Next

            'Get the conditions for today
            Dim weatherNode As XmlNode = weatherXML.SelectSingleNode("dwml/data/parameters/weather/weather-conditions")
            Dim weatherSummary As String = weatherNode.Attributes("weather-summary").Value

            Dim isHandled As Boolean = False

            'Choose the appropriate color
            If weatherSummary.Contains("Rain") Then
                displayInformation.DisplayColor = DetermineColor(RainyColor, todayHigh)
                isHandled = True
            End If

            If weatherSummary.Contains("Snow") Then
                displayInformation.DisplayColor = DetermineColor(SnowyColor, todayHigh)
                isHandled = True
            End If

            If weatherSummary.Contains("Cloud") Then
                displayInformation.DisplayColor = DetermineColor(CloudyColor, todayHigh)
                isHandled = True
            End If

            If weatherSummary.Contains("Sun") Then
                displayInformation.DisplayColor = DetermineColor(SunnyColor, todayHigh)
                isHandled = True
            End If

            If Not isHandled Then
                'Default weather
                displayInformation.DisplayColor = DetermineColor(DefaultColor, todayHigh)
            End If

            displayInformation.DisplayMessage = "Current Conditions: " & weatherSummary & ". Temperature: " & todayHigh.ToString() & "."

        Catch ex As Exception
            'An error occured

            displayInformation.DisplayColor = New OrbColor(Colors.Red)
            displayInformation.DisplayType = OrbAnimationType.Pulse
            displayInformation.PulseInformation = OrbPulseDescriber.Forever
            displayInformation.DisplayMessage = "Weather Service Error."
        End Try

        Return displayInformation

    End Function

    Private Function DetermineColor(ByVal BaseColor As Color, ByVal Temperature As Double) As OrbColor

        Dim NewColor As Color = BaseColor

        'define ranges of temps

        '75-85 is great, so do nothing

        '>85 we add to make it more white
        If Temperature > 85 Then
            NewColor = AddToColor(BaseColor, 20, 20, 20)
        End If

        '>100 we add to make it much more
        If Temperature > 100 Then
            NewColor = AddToColor(BaseColor, 40, 40, 40)
        End If

        '<75 we subtract to make it darker
        If Temperature < 75 Then
            NewColor = AddToColor(BaseColor, -20, -20, -20)
        End If

        '<50 we make darker
        If Temperature < 32 Then
            NewColor = AddToColor(BaseColor, -40, -40, -40)
        End If

        '<32 we make it very dark
        If Temperature < 32 Then
            NewColor = AddToColor(BaseColor, -50, -50, -50)
        End If

        Return New OrbColor(NewColor)

    End Function

    Private Function AddToColor(ByVal BaseColor As Color, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Color

        Dim baseR As Integer = CInt(BaseColor.R) + R
        Dim baseG As Integer = CInt(BaseColor.G) + G
        Dim baseB As Integer = CInt(BaseColor.B) + B

        'Do bounds checking on the byte portions of the color
        If (baseR > 255) Then baseR = 255
        If (baseG > 255) Then baseG = 255
        If (baseB > 255) Then baseB = 255

        If (baseR < 0) Then baseR = 0
        If (baseG < 0) Then baseG = 0
        If (baseB < 0) Then baseB = 0

        Return Color.FromRgb(CByte(baseR), CByte(baseG), CByte(baseB))
    End Function

    'Get the longitude and latitude from a given zip code
    Private Sub SetLocationFromZipCode(ByVal ZipString As String)

        'If we don't have a saved list, load it from the zip code list resource
        If m_ZipList Is Nothing Then

            m_ZipList = New Dictionary(Of String, GeographicLocation)

            Dim fileContents As String = My.Resources.ZipCodeData

            Dim zipcodeList() As String = fileContents.Split(vbCrLf)

            For Each zipcodeListing As String In zipcodeList
                Dim listingParts() As String = zipcodeListing.Split(","c)

                If listingParts.Length > 1 Then
                    Dim zipCode As String = listingParts(0).Replace("""", "").Trim()

                    If listingParts(1).Length > 0 Then
                        Dim latitude As Decimal = Decimal.Parse(listingParts(1).Replace("""", ""))
                        Dim longitude As Decimal = Decimal.Parse(listingParts(2).Replace("""", ""))

                        Dim currentLocation As New GeographicLocation(zipCode, latitude, longitude)

                        m_ZipList.Add(zipCode, currentLocation)
                    End If
                End If
            Next
        End If

        If Not m_ZipList.ContainsKey(ZipString) Then
            'Somehow we got an invalid zip code, reset to a known zip code
            ZipString = "98052"
        End If

        m_Location = m_ZipList(ZipString)
    End Sub

    Public Function GetOptions() As OrbOptions Implements IOrbling.GetOptions

        Dim optionsList As New OrbOptions()
        optionsList.ComponentName = "Weather Service Orbling"
        optionsList.ComponentDescription = "Get the weather for any zip code"
        optionsList.ComponentProperties = New Dictionary(Of String, Object)()

        optionsList.ComponentProperties.Add("Zip Code", New OrbZipCodeOption(98052))

        Return (Me.SerializeOptions(optionsList))

    End Function

    Public Function GetTime() As System.TimeSpan Implements IOrbling.GetTime

        Return TimeSpan.FromMinutes(1)

    End Function

    Private Function SerializeOptions(ByVal preserialized As OrbOptions) As OrbOptions

        Dim serialized As New OrbOptions()
        serialized.ComponentName = preserialized.ComponentName
        serialized.ComponentDescription = preserialized.ComponentDescription

        serialized.ComponentProperties = OrbOption.SerializeOptions(preserialized.ComponentProperties)

        Return (serialized)
    End Function

    'Class which holds the longitude and latitude of a given zip code
    Private Class GeographicLocation

        Private m_Latitude As Decimal
        Private m_Longitude As Decimal
        Private m_ZipCode As String

        Public Sub New(ByVal ZipCode As String, ByVal latitude As Decimal, ByVal longitude As Decimal)
            m_Latitude = latitude
            m_Longitude = longitude
            m_ZipCode = ZipCode
        End Sub

        Public ReadOnly Property Latitude() As Decimal
            Get
                Return m_Latitude
            End Get
        End Property

        Public ReadOnly Property Longitude() As Decimal
            Get
                Return m_Longitude
            End Get
        End Property


        Public ReadOnly Property ZipCode() As String
            Get
                Return m_ZipCode
            End Get
        End Property
    End Class


End Class


