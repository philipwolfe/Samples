//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Messaging;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace Microsoft.Samples.Queues
{
    class Program
    {
        private const string queueLocation = "net.msmq://localhost/private/";
        private const string queueName = "calculatorservice";
        private const string queuePrefix = ".\\Private$\\";

        static void Main(string[] args)
        {
            CreateMessageQueue(queuePrefix + queueName);

            NetMsmqBinding binding = new NetMsmqBinding(NetMsmqSecurityMode.None);
            Uri address = new Uri(queueLocation + queueName);

            ServiceHost serviceHost = new ServiceHost(typeof(ProductCalculator),
                                    new Uri("http://localhost:8043/testservice/"));
            serviceHost.AddServiceEndpoint(typeof(IProductCalculator), binding, address);

            try
            {
                serviceHost.Open();

		SendTwoRandomNumbers.SendNumbers(address, 10);

		// Wait for the service hosts to process the messages.
		Console.WriteLine("Press enter when messages have been received.");
		Console.ReadLine();

		serviceHost.Close();

		DeleteMessageQueue(queuePrefix + queueName);
            }
            catch (AddressAccessDeniedException)
            {
                Console.WriteLine("Ensure this process is running with elevated"
                        + " privileges.");
            }
            catch (TimeoutException)
            {
                Console.WriteLine("ServiceHost timed out during the open or close"
                        + " operation.");
            }
            catch (CommunicationException)
            {
                Console.WriteLine("ServiceHost was unable to open or close properly.");
            }
        }

        private static void CreateMessageQueue(string queuePath)
        {
            if (MessageQueue.Exists(queuePath))
            {
                DeleteMessageQueue(queuePath);
            }
            MessageQueue.Create(queuePath, true);
        }

        private static void DeleteMessageQueue(string queuePath)
        {
            MessageQueue.Delete(queuePath);
        }
    }
}
