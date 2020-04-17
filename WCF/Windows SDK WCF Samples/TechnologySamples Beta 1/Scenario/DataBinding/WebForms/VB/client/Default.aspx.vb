' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports Microsoft.ServiceModel.Samples

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' This page is marked Async='true' so we need to 
        ' setup the begin and end event handlers for asynchronous processing of the
        ' PreRender step in the page lifecycle
        Dim bh As New BeginEventHandler(AddressOf Me.BeginGetWeather)
        Dim eh As New EndEventHandler(AddressOf Me.EndGetWeather)
        AddOnPreRenderCompleteAsync(bh, eh)

    End Sub

    Private Function BeginGetWeather(ByVal src As Object, ByVal args As EventArgs, ByVal cb As AsyncCallback, ByVal state As Object) As IAsyncResult

        Dim localities As String() = {"Los Angeles", "Rio de Janeiro", "New York", "London", "Paris", "Rome", _
         "Cairo", "Beijing"}

        ' capture the client we are using to get the weather asynchronously
        ' we want to use this same instance of the client when we call EndGetWeatherData
        ' in order for any exceptions on the client to bubble up
        ' if we didn't do this, there is a chance that the Global.Client instance could be
        ' replaced and we may mask certain error conditions
        Dim client As WeatherServiceClient = [Global].Client

        ' invoke the client asynchronously, and pass it in as the asyncState so we can pick it up
        ' from the IAsyncResult when it gets passed back
        Return client.BeginGetWeatherData(localities, cb, client)

    End Function

    Private Sub EndGetWeather(ByVal ar As IAsyncResult)

        ' retrieve the instance of the client we stored in BeginGetWeather
        Dim client As WeatherServiceClient = DirectCast(ar.AsyncState, WeatherServiceClient)

        ' call EndGetWeatherData with the IAsyncResult in order to get the results of the call
        Dim myData As WeatherData() = client.EndGetWeatherData(ar)

        ' bind the results to the datagrid
        dataGrid1.DataSource = myData
        dataGrid1.DataBind()

    End Sub

End Class
