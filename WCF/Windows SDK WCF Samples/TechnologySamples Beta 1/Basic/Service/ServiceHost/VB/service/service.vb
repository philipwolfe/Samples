' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Activation
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract.
    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator

        <OperationContract()> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double

    End Interface

    ' Service class which implements the service contract.
    Public Class CalculatorService
        Implements ICalculator

        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add

            Return n1 + n2

        End Function

        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract

            Return n1 - n2

        End Function

        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply

            Return n1 * n2

        End Function

        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide

            Return n1 / n2

        End Function

    End Class

    ' Implement a ServiceHostFactoryBase to control initialization of a Service
    ' Service.svc file is modified to activate this ServiceHost
    Public Class CalculatorServiceHostFactory
        Inherits ServiceHostFactoryBase

        Public Overloads Overrides Function CreateServiceHost(ByVal constructorString As String, ByVal baseAddresses As Uri()) As ServiceHostBase

            Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddresses)

            ' Remove all configured endpoints
            serviceHost.Description.Endpoints.Clear()

            ' Add an endpoint that supports BasicHttpBinding
            serviceHost.AddServiceEndpoint(GetType(ICalculator), New BasicHttpBinding(), "")
            ' Add a mex endpoint
            serviceHost.AddServiceEndpoint("IMetadataExchange", System.ServiceModel.Description.MetadataExchangeBindings.CreateMexHttpBinding(), "/mex")
            Return serviceHost

        End Function

    End Class

End Namespace
