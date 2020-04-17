
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Web.Administration;
using System.IO;
using System.Web.Hosting;
using Microsoft.ServiceModel.Samples;

namespace Microsoft.ServiceModel.Samples.Hosting
{
    class HostedUdpTransportConfigurationImpl
    {
        static HostedUdpTransportConfigurationImpl singleton;
        static object syncRoot = new object();
        List<Uri> baseAddresses;
        HostedUdpTransportManager transportManager;

        HostedUdpTransportConfigurationImpl()
        {
            ServerManager serverManager = new ServerManager();
            Site site = serverManager.Sites[HostingEnvironment.SiteName];

            List<string> bindingInfoList = new List<string>();
            foreach (Binding binding in site.Bindings)
            {
                if (string.Compare(binding.Protocol, UdpConstants.Scheme, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    bindingInfoList.Add(binding.BindingInformation);
                }
            }

            if (bindingInfoList.Count == 0)
            {
                throw new InvalidOperationException(string.Format("No binding is found for the protocol '{0}'", UdpConstants.Scheme));
            }

            baseAddresses = new List<Uri>();
            foreach (string bindingInfo in bindingInfoList)
            {
                int port;
                if (!int.TryParse(bindingInfo, out port))
                {
                    throw new InvalidDataException(string.Format("The binding information '{0}' is invalid for the protocol '{1}'",
                        bindingInfo, UdpConstants.Scheme));
                }

                // FUTURE: Use configured host from WAS config as HTTP case.
                UriBuilder builder = new UriBuilder(UdpConstants.Scheme, "localhost", port,
                    HostingEnvironment.ApplicationVirtualPath);

                baseAddresses.Add(builder.Uri);
            }

            // FUTURE: add support with multiple transport managers.
            transportManager = new HostedUdpTransportManager(baseAddresses[0]);
            UdpTransportManager.Add(transportManager);
        }

        static object StaticLock
        {
            get
            {
                return syncRoot;
            }
        }

        public Uri[] GetBaseAddresses(string virtualPath)
        {
            Uri[] addresses = new Uri[baseAddresses.Count];
            for (int i = 0; i < baseAddresses.Count; i++)
            {
                addresses[i] = new Uri(baseAddresses[i], virtualPath);
            }

            return addresses;
        }

        public HostedUdpTransportManager TransportManager
        {
            get
            {
                return this.transportManager;
            }
        }

        public static HostedUdpTransportConfigurationImpl Value
        {
            get
            {
                if (singleton != null)
                {
                    return singleton;
                }

                lock (StaticLock)
                {
                    if (singleton != null)
                    {
                        return singleton;
                    }

                    singleton = new HostedUdpTransportConfigurationImpl();
                    return singleton;
                }
            }
        }
    }
}
