
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Security.Cryptography;


namespace Microsoft.ServiceModel.Samples
{
    public class CustomHeader
    {
        public static String HeaderName = "InstanceId";
        public static String HeaderNamespace = "http://Microsoft.ServiceModel.Samples/Sharing";
    }

    //The service contract is defined in generatedProxy.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        static RNGCryptoServiceProvider randomNumberGenerator = new RNGCryptoServiceProvider();

        static string NewInstanceId()
        {
            byte[] random = new byte[256 / 8];
            randomNumberGenerator.GetBytes(random);
            return Convert.ToBase64String(random);
        }

        static void Main()
        {
            // Create a proxy to default endpoint configuration
            CalculatorInstanceProxy proxy1 = new CalculatorInstanceProxy();
            using (proxy1)

            {
                //Create a new 1028 bit strong InstanceContextId that we want the server to associate 
                //the InstanceContext that will process all message's from this proxy.
                String uniqueId = NewInstanceId();

                MessageHeader Proxy1InstanceContextHeader = MessageHeader.CreateHeader(
                    CustomHeader.HeaderName,
                    CustomHeader.HeaderNamespace,
                    uniqueId);

                using (new OperationContextScope(proxy1.InnerChannel))
                {
                    //Add the header as a header to the scope so it gets sent for each message.
                    OperationContext.Current.OutgoingMessageHeaders.Add(Proxy1InstanceContextHeader);
                    DoCalculations(proxy1);
                }

                // Create a second proxy
                CalculatorInstanceProxy proxy2 = new CalculatorInstanceProxy();
                
                //We want this to communicate with InstanceContext created by Proxy1

                using (new OperationContextScope(proxy2.InnerChannel))
                {
                    //Add the same header that prxoy1 used so we will connect to that same InstanceContext

                    using (proxy2)
                    {
                        OperationContext.Current.OutgoingMessageHeaders.Add(Proxy1InstanceContextHeader);
                        DoCalculations(proxy2);
                    }
                }

            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }

        static void DoCalculations(CalculatorInstanceProxy proxy)
        {
            // Call the Add service operation.
            double value1 = 100.00D;
            double value2 = 15.99D;
            double result = proxy.Add(value1, value2);
            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);
            Console.Write("InstanceId: {0}", proxy.GetInstanceId());
            Console.WriteLine(" , OperationCount: {0}", proxy.GetOperationCount());

            // Call the Subtract service operation.
            value1 = 145.00D;
            value2 = 76.54D;
            result = proxy.Subtract(value1, value2);
            Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);
            Console.Write("InstanceId: {0}", proxy.GetInstanceId());
            Console.WriteLine(" , OperationCount: {0}", proxy.GetOperationCount());

            // Call the Multiply service operation.
            value1 = 9.00D;
            value2 = 81.25D;
            result = proxy.Multiply(value1, value2);
            Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);
            Console.Write("InstanceId: {0}", proxy.GetInstanceId());
            Console.WriteLine(" , OperationCount: {0}", proxy.GetOperationCount());

            // Call the Divide service operation.
            value1 = 22.00D;
            value2 = 7.00D;
            result = proxy.Divide(value1, value2);
            Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);
            Console.Write("InstanceId: {0}", proxy.GetInstanceId());
            Console.WriteLine(" , OperationCount: {0}", proxy.GetOperationCount());
        }

    }
}
