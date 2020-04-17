//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;

using System.Collections.Generic;

using System.IdentityModel.Claims;

using System.Security.Cryptography.X509Certificates;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.ServiceModel.Samples
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Call the two different endpoints
            CallEndpoint("CalcSymm");
            CallEndpoint("CalcAsymm");

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }

        /// <summary>
        /// Makes calls to the specified endpoint name in app.config
        /// </summary>
        /// <param name="endpointName">The endpoint to use from app.config</param>
        private static void CallEndpoint(string endpointName)
        {
            Console.WriteLine("\nCalling endpoint {0}\n", endpointName);

            // Create a client with given client endpoint configuration
            CalculatorClient client = new CalculatorClient(endpointName);

            // Create new credentials class
            SamlClientCredentials samlCC = new SamlClientCredentials();

            // Set the client certificate. This is the cert that will be used to sign the SAML token in the symmetric proof key case
            samlCC.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectName, "Alice");

            // Set the service certificate. This is the cert that will be used to encrypt the proof key in the symmetric proof key case
            samlCC.ServiceCertificate.SetDefaultCertificate(StoreLocation.CurrentUser, StoreName.TrustedPeople, X509FindType.FindBySubjectName, "localhost");

            // Create some claims to put in the SAML assertion
            IList<Claim> claims = new List<Claim>();
            claims.Add(Claim.CreateNameClaim(samlCC.ClientCertificate.Certificate.Subject));
            ClaimSet claimset = new DefaultClaimSet(claims);
            samlCC.Claims = claimset;

            // set new credentials
            client.ChannelFactory.Endpoint.Behaviors.Remove(typeof(ClientCredentials));
            client.ChannelFactory.Endpoint.Behaviors.Add(samlCC);

            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = client.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = client.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = client.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = client.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

            client.Close();
        }
    }
}
