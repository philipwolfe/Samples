﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.0.3705.0
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 1.0.3705.0.
'
Namespace LearnXMLWS
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WeatherRetrieverSoap", [Namespace]:="http://tempuri.org/")>  _
    Public Class WeatherRetriever
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://www.learnxmlws.com/services/weatherRetriever.asmx"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("http://tempuri.org/GetTemperature", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/")>  _
        Public Function GetTemperature(ByVal zipCode As String) As Single
            Dim results() As Object = Me.Invoke("GetTemperature", New Object() {zipCode})
            Return CType(results(0),Single)
        End Function
        
        '<remarks/>
        Public Function BeginGetTemperature(ByVal zipCode As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetTemperature", New Object() {zipCode}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetTemperature(ByVal asyncResult As System.IAsyncResult) As Single
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Single)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("http://tempuri.org/GetWeather", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/")>  _
        Public Function GetWeather(ByVal zipCode As String) As CurrentWeather
            Dim results() As Object = Me.Invoke("GetWeather", New Object() {zipCode})
            Return CType(results(0),CurrentWeather)
        End Function
        
        '<remarks/>
        Public Function BeginGetWeather(ByVal zipCode As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetWeather", New Object() {zipCode}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetWeather(ByVal asyncResult As System.IAsyncResult) As CurrentWeather
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),CurrentWeather)
        End Function
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.SoapTypeAttribute("CurrentWeather", "http://tempuri.org/")>  _
    Public Class CurrentWeather
        
        '<remarks/>
        Public LastUpdated As String
        
        '<remarks/>
        Public IconUrl As String
        
        '<remarks/>
        Public Conditions As String
        
        '<remarks/>
        Public CurrentTemp As Single
        
        '<remarks/>
        Public Humidity As Single
        
        '<remarks/>
        Public Barometer As Single
        
        '<remarks/>
        Public BarometerDirection As String
    End Class
End Namespace
