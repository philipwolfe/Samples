
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    public class LoadBalancerBehavior : IEndpointBehavior
    {
        EndpointAddress loadBalancerAddress;
        Binding loadBalancerBinding;
        string registrationId;

        public LoadBalancerBehavior(EndpointAddress loadBalancerAddress, Binding loadBalancerBinding)
        {
            this.loadBalancerAddress = loadBalancerAddress;
            this.loadBalancerBinding = loadBalancerBinding;
        }

        public EndpointAddress Address
        {
            get { return this.loadBalancerAddress; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this.loadBalancerAddress = value;
            }
        }

        public Binding Binding
        {
            get { return this.loadBalancerBinding; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this.loadBalancerBinding = value;
            }
        }

        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime clientRuntime)
        {
		}

        public void Validate(ServiceEndpoint serviceEndpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection parameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
        {
            if (endpointDispatcher == null)
                throw new ArgumentNullException("endpointDispatcher");

            string contractQName = serviceEndpoint.Contract.Namespace + ":" + serviceEndpoint.Contract.Name;
            string bindingQName = serviceEndpoint.Binding.Namespace + ":" + serviceEndpoint.Binding.Name;
            EndpointAddress serviceAddress = endpointDispatcher.EndpointAddress;
                        
            ChannelFactory<ILoadBalancer> factory = new ChannelFactory<ILoadBalancer>(loadBalancerBinding, loadBalancerAddress);
            ILoadBalancer loadBalancer = factory.CreateChannel();

            registrationId = loadBalancer.Register(contractQName, bindingQName, EndpointAddress10.FromEndpointAddress(serviceAddress));

            ((IChannel)loadBalancer).Close();

            endpointDispatcher.ChannelDispatcher.Closing += new EventHandler(channelDispatcher_Closing);
        }

        void channelDispatcher_Closing(object sender, EventArgs e)
        {
            ChannelFactory<ILoadBalancer> factory = new ChannelFactory<ILoadBalancer>(loadBalancerBinding, loadBalancerAddress);
            ILoadBalancer loadBalancer = factory.CreateChannel();

            loadBalancer.Unregister(registrationId);

            ((IChannel)loadBalancer).Close();
        }
    }
}
