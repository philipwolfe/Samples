
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples

    'The service contract is defined in generatedProxy.vb, generated from the service by the svcutil tool.

    'Client implementation code.
    Class Client

        Shared Sub Main()

            ' Create a proxy with given client endpoint configuration
            Using proxy As InstanceContextCalculatorProxy = New InstanceContextCalculatorProxy()

                ' Call the Add service operation.
                Dim value1 As Integer = 15
                Dim value2 As Integer = 3
                Dim result As Integer = proxy.Add(value1, value2)
                Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

                ' Call the Subtract service operation.
                value1 = 145
                value2 = 76
                result = proxy.Subtract(value1, value2)
                Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

                ' Call the Multiply service operation.
                value1 = 9
                value2 = 81
                result = proxy.Multiply(value1, value2)
                Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

                ' Call the Divide service operation - trigger a divide by zero error.
                value1 = 22
                value2 = 7
                result = proxy.Divide(value1, value2)
                Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)

                ' Obtain InstanceContext information from the service.
                Console.WriteLine("GetInstanceContextInfo")
                Console.WriteLine(proxy.GetInstanceContextInfo())

            End Using

            Console.WriteLine()
            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()
        End Sub
    End Class
End Namespace
