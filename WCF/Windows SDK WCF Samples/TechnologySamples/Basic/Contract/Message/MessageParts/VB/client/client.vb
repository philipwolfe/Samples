' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    'The service contract is defined in generatedClient.vb, generated from the service by the svcutil tool.

    'Client implementation code.
    Class Client

        Public Shared Sub Main()

            ' Create a client
            Dim client As New CalculatorClient()

            ' Perform addition using a typed message.
            Dim request As New MyMessage()
            request.special1 = 100
            request.special2 = 15.99
            request.operation = "+"
            Dim response As MyMessage = client.Calculate(request)

            Console.WriteLine("Add({0},{1}) = {2}", request.special1, request.special2, response.result)

            ' Perform subtraction using a typed message.
            request = New MyMessage()
            request.special1 = 145
            request.special2 = 76.54
            request.operation = "-"
            response = client.Calculate(request)
            Console.WriteLine("Subtract({0},{1}) = {2}", request.special1, request.special2, response.result)

            ' Perform multiplication using a typed message.
            request = New MyMessage()
            request.special1 = 9
            request.special2 = 81.25
            request.operation = "*"
            response = client.Calculate(request)
            Console.WriteLine("Multiply({0},{1}) = {2}", request.special1, request.special2, response.result)

            ' Perform multiplication using a typed message.
            request = New MyMessage()
            request.special1 = 22
            request.special2 = 7
            request.operation = "/"
            response = client.Calculate(request)
            Console.WriteLine("Divide({0},{1}) = {2}", request.special1, request.special2, response.result)

            'Closing the client gracefully closes the connection and cleans up resources
            client.Close()

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()

        End Sub

    End Class

End Namespace
