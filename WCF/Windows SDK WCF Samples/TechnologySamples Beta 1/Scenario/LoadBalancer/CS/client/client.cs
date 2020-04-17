
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    //[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    //public interface ILoadBalancedEchoContract
    //{
    //    [OperationContract]
    //    string Echo(string message);
    //}

    class client
    {
        static void Main(string [] args)
        {
            EndpointAddress loadBalancerAddress = new EndpointAddress("net.tcp://localhost/servicemodelsamples/loadBalancerService/");
            NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.None);
            WSHttpBinding httpBinding = new WSHttpBinding();

            // Use the utility resolver class to obtain endpoint address of a service
            LoadBalancerResolver resolver = new LoadBalancerResolver(loadBalancerAddress, tcpBinding);

            EndpointAddress remoteAddress = resolver.GetEndpointAddress<ILoadBalancedEchoContract>(httpBinding).ToEndpointAddress();
            // Alternatively, one can get back a ChannelFactory from the resolver:
            // ChannelFactory<ILoadBalancedEchoContract> channelFactory = resolver.GetChannelFactory<ILoadBalancedEchoContract>(httpBinding);

            LoadBalancedEchoContractClient client = new LoadBalancedEchoContractClient(httpBinding, remoteAddress);
            // If using ChannelFactory returned by resolver:
            // ILoadBalancedEchoContract client = channelFactory.CreateChannel();

            Console.WriteLine("calling service at {0}", remoteAddress.ToString());

            Console.WriteLine(client.Echo("Hello!"));

            client.Close();
            Console.ReadLine();
        }
    }
}
