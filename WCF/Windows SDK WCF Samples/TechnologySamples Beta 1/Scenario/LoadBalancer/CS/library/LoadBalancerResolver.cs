
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    public class LoadBalancerResolver
    {
        const string MicrosoftNamespace = "http://schemas.microsoft.com/2005/07/ServiceModel";

        EndpointAddress loadBalancerAddress;
        Binding loadBalancerBinding;

        public LoadBalancerResolver(EndpointAddress loadBalancerAddress, Binding loadBalancerBinding)
        {
            this.loadBalancerAddress = loadBalancerAddress;
            this.loadBalancerBinding = loadBalancerBinding;
        }

        public EndpointAddress10 GetEndpointAddress<TChannel>(Binding binding)
        {
            ContractDescription contractDesc = ContractDescription.GetContract(typeof(TChannel));

            string contractQName = contractDesc.Namespace + ":" + contractDesc.Name;
            string bindingQName = binding.Namespace + ":" + binding.Name;

            ChannelFactory<ILoadBalancer> factory = new ChannelFactory<ILoadBalancer>(loadBalancerBinding, loadBalancerAddress);
            ILoadBalancer loadBalancer = factory.CreateChannel();

            EndpointAddress10 epr = loadBalancer.GetServiceAddress(contractQName, bindingQName);

            ((IChannel)loadBalancer).Close();

            return epr;
        }

        public ChannelFactory<TChannel> GetChannelFactory<TChannel>(Binding binding)
        {
            EndpointAddress remoteAddress = GetEndpointAddress<TChannel>(binding).ToEndpointAddress();

            if (remoteAddress == null)
            {
                return null;
            }
            return new ChannelFactory<TChannel>(binding, remoteAddress);
        }
    }
}
