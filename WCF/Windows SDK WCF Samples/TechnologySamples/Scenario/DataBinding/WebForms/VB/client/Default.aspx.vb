'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.ServiceModel.Samples

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private client As WeatherServiceClient

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        ' capture a reference to the cached client.  This reference will stay with this page for the
        ' lifetime of the page.
        ' we want to use this same instance of the client for calling BeginGetWeatherData and EndGetWeatherData
        ' in order for any exceptions on the client to bubble up
        ' if we didn't do this, there is a chance that the Global.Client instance could be
        ' replaced and we may mask certain error conditions
        Me.client = [Global].Client

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

        ' invoke the client asynchronously
        Return client.BeginGetWeatherData(localities, cb, state)

    End Function

    Private Sub EndGetWeather(ByVal ar As IAsyncResult)

        Dim myData As WeatherData() = Nothing
        Try

            ' call EndGetWeatherData with the IAsyncResult in order to get the results of the call
            myData = Me.client.EndGetWeatherData(ar)

        Catch

            [Global].Client = Nothing
            Throw

        End Try

        ' bind the results to the datagrid
        dataGrid1.DataSource = myData
        dataGrid1.DataBind()

    End Sub

End Class