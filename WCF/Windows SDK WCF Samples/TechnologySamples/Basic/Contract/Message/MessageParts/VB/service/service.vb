' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.Runtime.Serialization

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract.
    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator

        <OperationContract(Action:="http://test/MyMessage_action", ReplyAction:="http://test/MyMessage_action")> _
        Function Calculate(ByVal request As MyMessage) As MyMessage

    End Interface

    ' Custom message.
    <MessageContract(IsWrapped:=False)> _
    Public Class MyMessage

        'Constructor - create an empty message.
        Public Sub New()

        End Sub

        'Constructor - create a message and populate its members.
        Public Sub New(ByVal n1 As Double, ByVal n2 As Double, ByVal operation As String, ByVal result As Double)

            Me.n1 = n1
            Me.n2 = n2
            Me.operation = operation
            Me.result = result

        End Sub

        'Constructor - create a message from another message.
        Public Sub New(ByVal message As MyMessage)

            Me.n1 = message.N1Value
            Me.n2 = message.N2Value
            Me.operation = message.OperationValue
            Me.result = message.ResultValue

        End Sub

        <MessageHeader()> _
        Private operation As String

        <MessageBodyMember(Name:="special1", [Namespace]:="http://Microsoft.ServiceModel.Samples/special")> _
        Private n1 As Double

        <MessageBodyMember(Name:="special2", [Namespace]:="http://Microsoft.ServiceModel.Samples/special")> _
        Private n2 As Double

        <MessageBodyMember()> _
        Private result As Double

        Public Property OperationValue() As String

            Get

                Return operation

            End Get

            Set(ByVal value As String)

                operation = value

            End Set

        End Property

        Public Property N1Value() As Double

            Get

                Return n1

            End Get

            Set(ByVal value As Double)

                n1 = value

            End Set

        End Property

        Public Property N2Value() As Double

            Get

                Return n2

            End Get

            Set(ByVal value As Double)

                n2 = value

            End Set

        End Property

        Public Property ResultValue() As Double

            Get

                Return result

            End Get

            Set(ByVal value As Double)

                result = value

            End Set

        End Property

    End Class

    ' Service class which implements the service contract.
    Public Class CalculatorService
        Implements ICalculator

        ' Perform a calculation.
        Public Function Calculate(ByVal request As MyMessage) As MyMessage Implements ICalculator.Calculate

            Dim response As New MyMessage(request)
            Select Case request.OperationValue
                Case "+"
                    response.ResultValue = request.N1Value + request.N2Value
                    Exit Select
                Case "-"
                    response.ResultValue = request.N1Value - request.N2Value
                    Exit Select
                Case "*"
                    response.ResultValue = request.N1Value * request.N2Value
                    Exit Select
                Case "/"
                    response.ResultValue = request.N1Value / request.N2Value
                    Exit Select
                Case Else
                    response.ResultValue = 0
                    Exit Select
            End Select
            Return response

        End Function

    End Class

End Namespace
