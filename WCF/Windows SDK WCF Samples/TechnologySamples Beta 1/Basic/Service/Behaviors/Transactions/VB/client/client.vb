' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel
Imports System.Transactions
Imports Microsoft.VisualBasic

Namespace Microsoft.ServiceModel.Samples

    'The service contract is defined in generatedClient.vb, generated from the service by the svcutil tool.

    'Client implementation code.
    Class Client

        Public Shared Sub Main()

            ' Create a client
            Dim client As New CalculatorLogClient()

            PerformMathOperations(True, client)

            Console.WriteLine("Reading the log")
            ReadLog(client)

            Console.WriteLine("Clearing the log" & vbNewLine)
            client.ClearLog()

            PerformMathOperations(False, client)

            Console.WriteLine("Reading the log")
            ReadLog(client)

            'Closing the client gracefully closes the connection and cleans up resources
            client.Close()

            Console.WriteLine("Press <ENTER> to terminate client.")
            Console.ReadLine()

        End Sub

        Private Shared Sub PerformMathOperations(ByVal commitTransaction As Boolean, ByVal client As CalculatorLogClient)

            Dim transactionOptions As New TransactionOptions()
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted

            Using ts As New TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions)

                Console.WriteLine("Starting transaction")

                Console.WriteLine("Performing calculations...")
                ' Call the Add service operation.
                Dim value1 As Double = 100
                Dim value2 As Double = 15.99
                Dim result As Double = client.Add(value1, value2)

                ' Call the Subtract service operation.
                value1 = 145
                value2 = 76.54
                result = client.Subtract(value1, value2)

                ' Call the Multiply service operation.
                value1 = 9
                value2 = 81.25
                result = client.Multiply(value1, value2)

                ' Call the Divide service operation.
                value1 = 22
                value2 = 7
                result = client.Divide(value1, value2)
                Console.WriteLine("{0} transaction" & vbNewLine, IIf(commitTransaction, "committing", "rolling back"))

                If commitTransaction Then
                    ts.Complete()
                End If

            End Using

        End Sub

        Private Shared Sub ReadLog(ByVal client As CalculatorLogClient)

            Dim entries As String() = client.ReadLog()

            If entries.Length > 0 Then
                Console.WriteLine("The log entries are:" & vbNewLine + String.Join(vbNewLine, entries) + vbNewLine)
            Else
                Console.WriteLine("The log is empty" & vbNewLine)
            End If

        End Sub

    End Class

End Namespace
