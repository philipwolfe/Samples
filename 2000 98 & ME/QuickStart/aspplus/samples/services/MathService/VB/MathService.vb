﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This class was generated by a tool.
'     Runtime Version: 1.0.2204.14
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Imports System.Xml.Serialization
Imports System.Web.Services.Protocols
Imports System.Web.Services

Namespace MathServiceSpace
    Public Class  MathService
        Inherits System.Web.Services.Protocols.SoapClientProtocol
        
        Public Sub New()
            MyBase.New
            Me.Url = "http://localhost/QuickStart/aspplus/samples/services/MathService/VB/MathService.a"& _ 
"smx"
        End Sub
        
        Public Function <System.Web.Services.Protocols.SoapMethodAttribute("http://tempuri.org/Add")> Add(ByVal <System.Xml.Serialization.XmlElementAttribute("A", IsNullable:=false)> a As Integer, ByVal <System.Xml.Serialization.XmlElementAttribute("B", IsNullable:=false)> b As Integer) As Integer
            Dim results() As Object = Me.Invoke("Add", New Object() {a, b})
            Return CType(results(0),Integer)
        End Function
        Public Function BeginAdd(ByVal a As Integer, ByVal b As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Add", New Object() {a, b}, callback, asyncState)
        End Function
        Public Function EndAdd(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
        Public Function <System.Web.Services.Protocols.SoapMethodAttribute("http://tempuri.org/Subtract")> Subtract(ByVal <System.Xml.Serialization.XmlElementAttribute("A", IsNullable:=false)> a As Integer, ByVal <System.Xml.Serialization.XmlElementAttribute("B", IsNullable:=false)> b As Integer) As Integer
            Dim results() As Object = Me.Invoke("Subtract", New Object() {a, b})
            Return CType(results(0),Integer)
        End Function
        Public Function BeginSubtract(ByVal a As Integer, ByVal b As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Subtract", New Object() {a, b}, callback, asyncState)
        End Function
        Public Function EndSubtract(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
        Public Function <System.Web.Services.Protocols.SoapMethodAttribute("http://tempuri.org/Multiply")> Multiply(ByVal <System.Xml.Serialization.XmlElementAttribute("A", IsNullable:=false)> a As Integer, ByVal <System.Xml.Serialization.XmlElementAttribute("B", IsNullable:=false)> b As Integer) As Integer
            Dim results() As Object = Me.Invoke("Multiply", New Object() {a, b})
            Return CType(results(0),Integer)
        End Function
        Public Function BeginMultiply(ByVal a As Integer, ByVal b As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Multiply", New Object() {a, b}, callback, asyncState)
        End Function
        Public Function EndMultiply(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
        Public Function <System.Web.Services.Protocols.SoapMethodAttribute("http://tempuri.org/Divide")> Divide(ByVal <System.Xml.Serialization.XmlElementAttribute("A", IsNullable:=false)> a As Integer, ByVal <System.Xml.Serialization.XmlElementAttribute("B", IsNullable:=false)> b As Integer) As Integer
            Dim results() As Object = Me.Invoke("Divide", New Object() {a, b})
            Return CType(results(0),Integer)
        End Function
        Public Function BeginDivide(ByVal a As Integer, ByVal b As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Divide", New Object() {a, b}, callback, asyncState)
        End Function
        Public Function EndDivide(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
        
    End Class
End Namespace