﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



Namespace Microsoft.ServiceModel.Samples
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://Microsoft.ServiceModel.Samples", ConfigurationName:="Microsoft.ServiceModel.Samples.IOrderStatus")>  _
    Public Interface IOrderStatus
        
        <System.ServiceModel.OperationContractAttribute(IsOneWay:=true, Action:="http://Microsoft.ServiceModel.Samples/IOrderStatus/OrderStatus")>  _
        Sub OrderStatus(ByVal poNumber As String, ByVal status As String)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
    Public Interface IOrderStatusChannel
        Inherits Microsoft.ServiceModel.Samples.IOrderStatus, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
    Partial Public Class OrderStatusClient
        Inherits System.ServiceModel.ClientBase(Of Microsoft.ServiceModel.Samples.IOrderStatus)
        Implements Microsoft.ServiceModel.Samples.IOrderStatus
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Sub OrderStatus(ByVal poNumber As String, ByVal status As String) Implements Microsoft.ServiceModel.Samples.IOrderStatus.OrderStatus
            MyBase.Channel.OrderStatus(poNumber, status)
        End Sub
    End Class
End Namespace
