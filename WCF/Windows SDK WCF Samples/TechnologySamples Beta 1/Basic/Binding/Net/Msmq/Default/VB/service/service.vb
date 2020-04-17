' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel.Channels
Imports System.Configuration
Imports System.Messaging
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract. 
    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface IQueueCalculator

        <OperationContract(IsOneWay:=True)> _
        Sub Add(ByVal n1 As Double, ByVal n2 As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub Subtract(ByVal n1 As Double, ByVal n2 As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub Multiply(ByVal n1 As Double, ByVal n2 As Double)
        <OperationContract(IsOneWay:=True)> _
        Sub Divide(ByVal n1 As Double, ByVal n2 As Double)

    End Interface

    ' Service class which implements the service contract.
    ' Added code to write output to the console window
    Public Class CalculatorService
        Implements IQueueCalculator

        Public Sub Add(ByVal n1 As Double, ByVal n2 As Double) Implements IQueueCalculator.Add

            Dim result As Double = n1 + n2
            Console.WriteLine("Received Add({0},{1}) - result: {2}", n1, n2, result)

        End Sub

        Public Sub Subtract(ByVal n1 As Double, ByVal n2 As Double) Implements IQueueCalculator.Subtract

            Dim result As Double = n1 - n2
            Console.WriteLine("Received Subtract({0},{1}) - result: {2}", n1, n2, result)

        End Sub

        Public Sub Multiply(ByVal n1 As Double, ByVal n2 As Double) Implements IQueueCalculator.Multiply

            Dim result As Double = n1 * n2
            Console.WriteLine("Received Multiply({0},{1}) - result: {2}", n1, n2, result)

        End Sub

        Public Sub Divide(ByVal n1 As Double, ByVal n2 As Double) Implements IQueueCalculator.Divide

            Dim result As Double = n1 / n2
            Console.WriteLine("Received Divide({0},{1}) - result: {2}", n1, n2, result)

        End Sub

        ' Host the service within this EXE console application.
        Public Shared Sub Main()

            ' Get MSMQ queue name from app settings in configuration
            Dim queueName As String = ConfigurationManager.AppSettings("queueName")

            ' Create the transacted MSMQ queue if necessary.
            If Not MessageQueue.Exists(queueName) Then
                MessageQueue.Create(queueName, True)
            End If

            ' Create a ServiceHost for the CalculatorService type.
            Using serviceHost As New ServiceHost(GetType(CalculatorService))

                ' Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()

                ' Close the ServiceHost to shutdown the service.
                serviceHost.Close()

            End Using

        End Sub

    End Class

End Namespace
