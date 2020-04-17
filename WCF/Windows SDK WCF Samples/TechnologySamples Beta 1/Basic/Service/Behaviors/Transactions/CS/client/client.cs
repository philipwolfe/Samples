//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.Transactions;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {

            TransactionOptions transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;

            try
            {
                using (TransactionScope tx = new TransactionScope(
                                                    TransactionScopeOption.RequiresNew, transactionOptions))
                {
                    Console.WriteLine("Starting transaction");

                    // Create a client
                    CalculatorClient client = new CalculatorClient();

                    Console.WriteLine("Performing calculations...");

                    // Call the Add service operation.
                    double value = 100.00D;
                    Console.WriteLine("  Adding {0}, running total={1}",
                                                        value, client.Add(value));

                    // Call the Subtract service operation.
                    value = 45.00D;
                    Console.WriteLine("  Subtracting {0}, running total={1}",
                                                        value, client.Subtract(value));
                    // Call the Multiply service operation.
                    value = 9.00D;
                    Console.WriteLine("  Multiplying by {0}, running total={1}",
                                                        value, client.Multiply(value));
                    // Call the Divide service operation.
                    value = 15.00D;
                    Console.WriteLine("  Dividing by {0}, running total={1}",
                                                        value, client.Divide(value));

                    //Closing the client gracefully closes the connection and cleans up resources
                    client.Close();

                    Console.WriteLine("Completing transaction");
                    tx.Complete();
                }
                Console.WriteLine("Transaction committed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
                Console.WriteLine("Transaction NOT committed");
            }

            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
