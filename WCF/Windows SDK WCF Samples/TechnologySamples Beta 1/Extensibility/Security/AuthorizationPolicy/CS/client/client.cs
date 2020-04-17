//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;

using System.Security.Cryptography.X509Certificates;

using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Security.Principal;


namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.
    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create a proxy with Username endpoint configuration
            using (CalculatorProxy proxy = new CalculatorProxy("Username"))
            {
                proxy.ClientCredentials.UserName.UserName = "test1";
                proxy.ClientCredentials.UserName.Password = "1tset";

				try
				{
					// Call the Add service operation.
					double value1 = 100.00D;
					double value2 = 15.99D;
					double result = proxy.Add(value1, value2);
					Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

					// Call the Subtract service operation.
					value1 = 145.00D;
					value2 = 76.54D;
					result = proxy.Subtract(value1, value2);
					Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

					// Call the Multiply service operation.
					value1 = 9.00D;
					value2 = 81.25D;
					result = proxy.Multiply(value1, value2);
					Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

					// Call the Divide service operation.
					value1 = 22.00D;
					value2 = 7.00D;
					result = proxy.Divide(value1, value2);
					Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
				}
				catch (Exception e)
				{
					Console.WriteLine("Call failed : {0}", e.Message);
				}

            }

            // Create a proxy with Certificate endpoint configuration
            using (CalculatorProxy proxy = new CalculatorProxy("Certificate"))
            {
                proxy.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.TrustedPeople, X509FindType.FindBySubjectName, "test1");

                try
                {
                    // Call the Add service operation.
                    double value1 = 100.00D;
                    double value2 = 15.99D;
                    double result = proxy.Add(value1, value2);
                    Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

                    // Call the Subtract service operation.
                    value1 = 145.00D;
                    value2 = 76.54D;
                    result = proxy.Subtract(value1, value2);
                    Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

                    // Call the Multiply service operation.
                    value1 = 9.00D;
                    value2 = 81.25D;
                    result = proxy.Multiply(value1, value2);
                    Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

                    // Call the Divide service operation.
                    value1 = 22.00D;
                    value2 = 7.00D;
                    result = proxy.Divide(value1, value2);
                    Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Call failed : {0}", e.Message);
                }

            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
