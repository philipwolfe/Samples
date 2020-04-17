
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            Console.WriteLine("Username authentication required.");
            Console.WriteLine("Provide a valid machine or domain account. [domain\\user]");
            Console.WriteLine("   Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("   Enter password:");
            StringBuilder password = new StringBuilder();

            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    password.Append(info.KeyChar);
                    info = Console.ReadKey(true);
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (password.Length != 0)
                    {
                        password.Remove(password.Length - 1, 1);
                    }
                    info = Console.ReadKey(true);
                }
            }

            for (int i = 0; i < password.Length; i++)
                Console.Write("*");

            Console.WriteLine();

            // WARNING: This code is only needed for test certificates such as those created by makecert. It is 
            // not recommended for production code.
            PermissiveCertificatePolicy.Enact("CN=ServiceModelSamples-HTTPS-Server");

            // Create a proxy with given client endpoint configuration
            using (CalculatorProxy proxy = new CalculatorProxy())
            {
                // Setup the UserName credential
                proxy.ClientCredentials.UserName.UserName = username;
                proxy.ClientCredentials.UserName.Password = password.ToString();

                // Call the GetCallerIdentity service operation
                Console.WriteLine(proxy.GetCallerIdentity());

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

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }

        // WARNING: This code is only needed for test certificates such as those created by makecert. It is 
        // not recommended for production code.
        class PermissiveCertificatePolicy
        {
            string subjectName;
            static PermissiveCertificatePolicy currentPolicy;
            PermissiveCertificatePolicy(string subjectName)
            {
                this.subjectName = subjectName;
                ServicePointManager.ServerCertificateValidationCallback +=
                    new System.Net.Security.RemoteCertificateValidationCallback(RemoteCertValidate);
            }

            public static void Enact(string subjectName)
            {
                currentPolicy = new PermissiveCertificatePolicy(subjectName);
            }

            bool RemoteCertValidate(object sender, X509Certificate cert, X509Chain chain, System.Net.Security.SslPolicyErrors error)
            {
                if (cert.Subject == subjectName)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
