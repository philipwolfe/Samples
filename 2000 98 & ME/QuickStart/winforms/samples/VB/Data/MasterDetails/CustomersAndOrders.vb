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

Namespace CustomersAndOrdersWebService
    Public Class  CustomersAndOrders
        Inherits System.Web.Services.Protocols.SoapClientProtocol
        
        Public Sub New()
            MyBase.New
            Me.Url = "http://localhost/QuickStart/winforms/samples/VB/Data/MasterDetails/CustomersAndOr"& _ 
"dersWebService.asmx"
        End Sub
        
        Public Function <System.Web.Services.Protocols.SoapMethodAttribute("http://tempuri.org/GetCustomersAndOrders")> GetCustomersAndOrders() As System.Data.DataSet
            Dim results() As Object = Me.Invoke("GetCustomersAndOrders", New Object(0) {})
            Return CType(results(0),System.Data.DataSet)
        End Function
        Public Function BeginGetCustomersAndOrders(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetCustomersAndOrders", New Object(0) {}, callback, asyncState)
        End Function
        Public Function EndGetCustomersAndOrders(ByVal asyncResult As System.IAsyncResult) As System.Data.DataSet
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Data.DataSet)
        End Function
        Public Function <System.Web.Services.Protocols.SoapMethodAttribute("http://tempuri.org/UpdateCustomersAndOrders")> UpdateCustomersAndOrders(ByVal  ds As System.Data.DataSet) As System.Data.DataSet
            Dim results() As Object = Me.Invoke("UpdateCustomersAndOrders", New Object() {ds})
            Return CType(results(0),System.Data.DataSet)
        End Function
        Public Function BeginUpdateCustomersAndOrders(ByVal ds As System.Data.DataSet, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("UpdateCustomersAndOrders", New Object() {ds}, callback, asyncState)
        End Function
        Public Function EndUpdateCustomersAndOrders(ByVal asyncResult As System.IAsyncResult) As System.Data.DataSet
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Data.DataSet)
        End Function
        
    End Class
End Namespace
