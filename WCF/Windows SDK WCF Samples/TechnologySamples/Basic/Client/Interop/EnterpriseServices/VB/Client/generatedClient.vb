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





<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
 System.ServiceModel.ServiceContractAttribute([Namespace]:="http://tempuri.org/C551FBA9-E3AA-4272-8C2A-84BD8D290AC7", ConfigurationName:="ICalculator", SessionMode:=System.ServiceModel.SessionMode.Required)>  _
Public Interface ICalculator
    
    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/C551FBA9-E3AA-4272-8C2A-84BD8D290AC7/ICalculator/Add", ReplyAction:="http://tempuri.org/C551FBA9-E3AA-4272-8C2A-84BD8D290AC7/ICalculator/AddResponse")>  _
    Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
    
    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/C551FBA9-E3AA-4272-8C2A-84BD8D290AC7/ICalculator/Subtract", ReplyAction:="http://tempuri.org/C551FBA9-E3AA-4272-8C2A-84BD8D290AC7/ICalculator/SubtractRespo"& _ 
        "nse")>  _
    Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
    
    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/C551FBA9-E3AA-4272-8C2A-84BD8D290AC7/ICalculator/Multiply", ReplyAction:="http://tempuri.org/C551FBA9-E3AA-4272-8C2A-84BD8D290AC7/ICalculator/MultiplyRespo"& _ 
        "nse")>  _
    Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
    
    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/C551FBA9-E3AA-4272-8C2A-84BD8D290AC7/ICalculator/Divide", ReplyAction:="http://tempuri.org/C551FBA9-E3AA-4272-8C2A-84BD8D290AC7/ICalculator/DivideRespons"& _ 
        "e")>  _
    Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
End Interface

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
Public Interface ICalculatorChannel
    Inherits ICalculator, System.ServiceModel.IClientChannel
End Interface

<System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
Partial Public Class CalculatorClient
    Inherits System.ServiceModel.ClientBase(Of ICalculator)
    Implements ICalculator
    
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
    
    Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
        Return MyBase.Channel.Add(n1, n2)
    End Function
    
    Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
        Return MyBase.Channel.Subtract(n1, n2)
    End Function
    
    Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
        Return MyBase.Channel.Multiply(n1, n2)
    End Function
    
    Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
        Return MyBase.Channel.Divide(n1, n2)
    End Function
End Class
