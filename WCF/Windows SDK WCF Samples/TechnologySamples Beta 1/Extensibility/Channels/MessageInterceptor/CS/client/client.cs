
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceContract]
    public interface ISampleContract
    {
        [OperationContract(IsOneWay = true)]
        void ReportWindSpeed(int speed);
    }

    public class MessageModifier : IChannelMessageInspector
    {
        int send = 0;

        public void OnSend(ref Message msg)
        {
            send++;
            if (send % 2 == 0)
            {
                // Add extra header so that when the message arrives on service side, the message won't be dropped
                msg.Headers.Add(MessageHeader.CreateHeader("ByPass", "urn:InterceptorNamespace", "ByPassPassword"));
            }
        }

        public void OnReceive(ref Message message)
        {
            // do nothing
        }

        public IChannelMessageInspector Clone()
        {
            return new MessageModifier();
        }
    }

    class MessageModifierElement : InspectingElement
    {
        protected override IChannelMessageInspector CreateMessageInspector()
        {
            return new MessageModifier();
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            ChannelFactory<ISampleContract> channelFactory = new ChannelFactory<ISampleContract>("sampleProxy");
            ISampleContract proxy = channelFactory.CreateChannel();

            int[] windSpeeds = new int[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10 };

            Console.WriteLine("Reporting the next 10 wind speeds.");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(windSpeeds[i] + " kph");
                proxy.ReportWindSpeed(windSpeeds[i]);
            }

            Console.WriteLine("Press ENTER to shut down client");
            Console.ReadLine();

            ((IChannel)proxy).Close();
        }
    }
}
