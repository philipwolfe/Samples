' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Activation
Imports System.ServiceModel
Imports System.Web

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract that uses a session.
    ' ICalculatorSession allows one to perform multiple operations on a running result
    ' One can retrieve the current result by calling Equals()
    ' One can begin calculating a new result by calling Clear()
    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculatorSession

        <OperationContract()> _
        Sub Clear()
        <OperationContract()> _
        Sub AddTo(ByVal n As Double)
        <OperationContract()> _
        Sub SubtractFrom(ByVal n As Double)
        <OperationContract()> _
        Sub MultiplyBy(ByVal n As Double)
        <OperationContract()> _
        Sub DivideBy(ByVal n As Double)
        <OperationContract()> _
        Function Equals() As Double

    End Interface

    ' Service class which implements the service contract.
    ' Utilize AspSessionState to manage each calculator session.
    ' Requiring AspNetCompatibilityMode allows one access to the HttpContext and Session.
    <AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Required)> _
    Public Class CalculatorService
        Implements ICalculatorSession

        Private Property result() As Double

            ' store result in AspNet Session
            Get

                If HttpContext.Current.Session("Result") IsNot Nothing Then
                    Return DirectCast(HttpContext.Current.Session("Result"), Double)
                End If
                Return 0

            End Get
            Set(ByVal value As Double)

                HttpContext.Current.Session("Result") = value

            End Set

        End Property

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
