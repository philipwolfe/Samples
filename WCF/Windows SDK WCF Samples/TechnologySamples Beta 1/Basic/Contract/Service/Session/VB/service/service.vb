' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract which requires a session.
    ' ICalculatorSession allows one to perform multiple operations on a running result
    ' One can retrieve the current result by calling Equals()
    ' One can begin calculating a new result by calling Clear()
    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples", SessionMode:=SessionMode.Required)> _
    Public Interface ICalculatorSession

        <OperationContract(IsOneWay:=True)> _
        Sub Clear()
        <OperationContract(IsOneWay:=True)> _
        Sub AddTo(ByVal n As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub SubtractFrom(ByVal n As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub MultiplyBy(ByVal n As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub DivideBy(ByVal n As Double)
        <OperationContract()> _
        Function Equals() As Double

    End Interface

    ' Service class which implements the service contract.
    ' Use an InstanceContextMode of PrivateSession to store the result
    ' An instance of the service will be bound to each session
    <ServiceBehavior(InstanceContextMode:=InstanceContextMode.PerSession)> _
    Public Class CalculatorService
        Implements ICalculatorSession

        Private result As Double = 0

        Public Sub Clear() Implements ICalculatorSession.Clear

            result = 0

        End Sub

        Public Sub AddTo(ByVal n As Double) Implements ICalculatorSession.AddTo

            result += n

        End Sub

        Public Sub SubtractFrom(ByVal n As Double) Implements ICalculatorSession.SubtractFrom

            result -= n

        End Sub

        Public Sub MultiplyBy(ByVal n As Double) Implements ICalculatorSession.MultiplyBy

            result *= n

        End Sub

        Public Sub DivideBy(ByVal n As Double) Implements ICalculatorSession.DivideBy

            result /= n

        End Sub

        Public Function Equals() As Double Implements ICalculatorSession.Equals

            Return result

        End Function

    End Class

End Namespace
