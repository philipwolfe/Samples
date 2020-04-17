
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Security.Principal;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;


namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {			
            // Create a proxy with given client endpoint configuration
            using (CalculatorProxy proxy = new CalculatorProxy())
            {
                // set new credentials
                proxy.ChannelFactory.Endpoint.Behaviors.Remove(typeof(ClientCredentials));
                proxy.ChannelFactory.Endpoint.Behaviors.Add(new MyUserNameClientCredentials());
                /*
                Setting the CertificateValidationMode to PeerOrChainTrust means that if the certificate 
                is in the Trusted People store, then it will be trusted without performing a
                validation of the certificate's issuer chain. This setting is used here for convenience so that the 
                sample can be run without having to have certificates issued by a certificate authority (CA).
                This setting is less secure than the default, ChainTrust. The security implications of this 
                setting should be carefully considered before using PeerOrChainTrust in production code. 
                */
                proxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;

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
    }
}
