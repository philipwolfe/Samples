
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Configuration;
using System.Collections;

namespace Microsoft.ServiceModel.Samples
{
    // Create a service contract and defing the service operations.
    [ServiceContract]
    public interface ISampleContract
    {
        [OperationContract(IsOneWay = true)]
        void ReportWindSpeed(int speed);
    }

    // The Service implementation implements your service contract.
    public class SampleService : ISampleContract
    {
        public void ReportWindSpeed(int speed)
        {
            if (speed >= 64)
            {
                Console.WriteLine("Dangerous wind detected! Reported speed (" + speed + ") is greater than 64 kph.");
            }
        }
    }

    class DroppingServerElement : InspectingElement
    {
        protected override IChannelMessageInspector CreateMessageInspector()
        {
            return new DroppingServerInspector();
        }
    }

    public class DroppingServerInspector : IChannelMessageInspector
    {
        int messagesSinceLastReport = 0;
        readonly int reportPeriod = 5;

        public DroppingServerInspector() { }

        public void OnSend(ref Message msg)
        {
            // do nothing
        }

        public void OnReceive(ref Message msg)
        {
            if (msg.Headers.FindHeader("ByPass", "urn:InterceptorNamespace") > 0)
            {
                if (++messagesSinceLastReport == this.reportPeriod)
                {
                    Console.WriteLine(reportPeriod + " wind speed reports have been received.");
                }
                return;
            }
            // Drop incoming Message if the Message doesn't have the special header
            msg = null;
        }

        public IChannelMessageInspector Clone()
        {
            return new DroppingServerInspector();
        }
    }

    class Service
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri(ConfigurationManager.AppSettings["baseAddress"]);

            using (ServiceHost serviceHost = new ServiceHost(typeof(SampleService), uri))
            {
                serviceHost.Open();

                System.Console.WriteLine("Press ENTER to exit.");
                System.Console.ReadLine();

                serviceHost.Close();
            }
        }
    }
}
