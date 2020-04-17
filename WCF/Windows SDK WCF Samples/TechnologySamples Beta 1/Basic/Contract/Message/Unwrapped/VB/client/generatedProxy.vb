'------------------------------------------------------------------------------
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

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), _
     System.ServiceModel.MessageContractAttribute(IsWrapped := false)> _
    Public Class RequestMessage

        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://Microsoft.ServiceModel.Samples", Order:=0)> _
        Public n1 As Double

        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://Microsoft.ServiceModel.Samples", Order:=1)> _
        Public n2 As Double

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal n1 As Double, ByVal n2 As Double)
            MyBase.New()
            Me.n1 = n1
            Me.n2 = n2
        End Sub
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), _
     System.ServiceModel.MessageContractAttribute(IsWrapped := false)> _
    Public Class ResponseMessage

        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://Microsoft.ServiceModel.Samples", Order:=0)> _
        Public vResult As Double

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal vResult As Double)
            MyBase.New()
            Me.vResult = vResult
        End Sub
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator

        'CODEGEN: Generating message contract since the operation Add is neither RPC nor document wrapped.
        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Add", ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")> _
        Function Add(ByVal request As RequestMessage) As ResponseMessage

        'CODEGEN: Generating message contract since the operation Subtract is neither RPC nor document wrapped.
        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Subtract", ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/SubtractResponse")> _
        Function Subtract(ByVal request As RequestMessage) As ResponseMessage

        'CODEGEN: Generating message contract since the operation Multiply is neither RPC nor document wrapped.
        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Multiply", ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/MultiplyResponse")> _
        Function Multiply(ByVal request As RequestMessage) As ResponseMessage

        'CODEGEN: Generating message contract since the operation Divide is neither RPC nor document wrapped.
        <System.ServiceModel.OperationContractAttribute(Action:="http://Microsoft.ServiceModel.Samples/ICalculator/Divide", ReplyAction:="http://Microsoft.ServiceModel.Samples/ICalculator/DivideResponse")> _
        Function Divide(ByVal request As RequestMessage) As ResponseMessage
    End Interface

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Interface ICalculatorChannel
        Inherits ICalculator, System.ServiceModel.IClientChannel
    End Interface

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Partial Public Class CalculatorProxy
        Inherits System.ServiceModel.ClientBase(Of ICalculator)
        Implements ICalculator

        Public Sub New()
            MyBase.New()
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

        Function ICalculator_Add(ByVal request As RequestMessage) As ResponseMessage Implements ICalculator.Add
            Return MyBase.Channel.Add(request)
        End Function

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
            Dim inValue As RequestMessage = New RequestMessage
            inValue.n1 = n1
            inValue.n2 = n2
            Dim retVal As ResponseMessage = CType(Me, ICalculator).Add(inValue)
            Return retVal.vResult
        End Function

        Function ICalculator_Subtract(ByVal request As RequestMessage) As ResponseMessage Implements ICalculator.Subtract
            Return MyBase.Channel.Subtract(request)
        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
            Dim inValue As RequestMessage = New RequestMessage
            inValue.n1 = n1
            inValue.n2 = n2
            Dim retVal As ResponseMessage = CType(Me, ICalculator).Subtract(inValue)
            Return retVal.vResult
        End Function

        Function ICalculator_Multiply(ByVal request As RequestMessage) As ResponseMessage Implements ICalculator.Multiply
            Return MyBase.Channel.Multiply(request)
        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
            Dim inValue As RequestMessage = New RequestMessage
            inValue.n1 = n1
            inValue.n2 = n2
            Dim retVal As ResponseMessage = CType(Me, ICalculator).Multiply(inValue)
            Return retVal.vResult
        End Function

        Function ICalculator_Divide(ByVal request As RequestMessage) As ResponseMessage Implements ICalculator.Divide
            Return MyBase.Channel.Divide(request)
        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
            Dim inValue As RequestMessage = New RequestMessage
            inValue.n1 = n1
            inValue.n2 = n2
            Dim retVal As ResponseMessage = CType(Me, ICalculator).Divide(inValue)
            Return retVal.vResult
        End Function
    End Class
End Namespace
