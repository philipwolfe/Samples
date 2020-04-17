' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Globalization
Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.Xml

Namespace Microsoft.ServiceModel.Samples

    'The service contract is defined in generatedClient.vb, generated from the service by the svcutil tool.

    'Client implementation code.
    Class Client

        Public Shared Sub Main()

            ' Create a client
            Dim client As New CalculatorClient()

            ' Call the Add service operation.
            Dim value1 As Double = 100
            Dim value2 As Double = 15.99
            Dim result As Double = client.Add(value1, value2)
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

            ' Call the Subtract service operation.
            value1 = 145
            value2 = 76.54
            result = client.Subtract(value1, value2)
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

            ' Call the Multiply service operation.
            value1 = 9
            value2 = 81.25
            result = client.Multiply(value1, value2)
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

            ' Call the Divide service operation.
            value1 = 22
            value2 = 7
            result = client.Divide(value1, value2)
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

            ' Call the Sum service operation.
            Dim values As Integer() = {1, 2, 3, 4, 5}
            Dim request As Message = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "http://Microsoft.ServiceModel.Samples/ICalculator/Sum", values)
            Dim reply As Message = client.Sum(request)
            Dim response As String = reply.GetBody(Of String)()
            Dim sum As Integer = Convert.ToInt32(response, CultureInfo.InvariantCulture)

            Console.WriteLine("Sum(1,2,3,4,5) = {0}", sum)

            'Closing the client gracefully closes the connection and cleans up resources
            client.Close()

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()

        End Sub

    End Class

End Namespace
