' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    ' The service contract is defined in generatedClient.vb, generated from the service by the svcutil tool.

    ' Define class which implements callback interface of duplex contract
    Public Class CallbackHandler
        Implements ICalculatorDuplexCallback

        Public Sub Equals(ByVal result As Double) Implements ICalculatorDuplexCallback.Equals

            Console.WriteLine("Equals({0})", result)

        End Sub

        Public Sub Equation(ByVal eqn As String) Implements ICalculatorDuplexCallback.Equation

            Console.WriteLine("Equation({0})", eqn)

        End Sub

    End Class

    Class Client

        Public Shared Sub Main()

            ' Construct InstanceContext to handle messages on callback interface
            Dim instanceContext As New InstanceContext(New CallbackHandler())

            ' Create a client
            Dim client As New CalculatorDuplexClient(instanceContext)
            Console.WriteLine("Press <ENTER> to terminate client once the output is displayed.")
            Console.WriteLine()

            ' Call the AddTo service operation.
            Dim value As Double = 100
            client.AddTo(value)

            ' Call the SubtractFrom service operation.
            value = 50
            client.SubtractFrom(value)

            ' Call the MultiplyBy service operation.
            value = 17.65
            client.MultiplyBy(value)

            ' Call the DivideBy service operation.
            value = 2
            client.DivideBy(value)

            ' Complete equation
            client.Clear()

            Console.ReadLine()

            'Closing the client gracefully closes the connection and cleans up resources
            client.Close()

        End Sub

    End Class

End Namespace