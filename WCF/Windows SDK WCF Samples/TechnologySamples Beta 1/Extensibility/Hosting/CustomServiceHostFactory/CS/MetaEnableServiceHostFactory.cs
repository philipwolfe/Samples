using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;

namespace Microsoft.Samples.Indigo
{
    //
    // Custom ServiceHostFactory, which will produce a Custom ServiceHost.
    //
    public class MetaEnableServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new MetaEnableServiceHost(serviceType, baseAddresses);
        }
    };

    //
    // Custom MetaData Enable ServiceHost,  which will enable metadata publishing.
    //
    class MetaEnableServiceHost : ServiceHost
    {
        public MetaEnableServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void ApplyConfiguration()
        {
            base.ApplyConfiguration();

            //
            // Add the metadata behavior if not already added.
            //
            ServiceMetadataBehavior mexBehavior = this.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (mexBehavior == null)
            {
                mexBehavior = new ServiceMetadataBehavior();
                this.Description.Behaviors.Add(mexBehavior);
            }

            //
            // Add service endpoint depending on the base address schemes.
            //
            foreach (Uri baseAddress in this.BaseAddresses)
            {
                if (baseAddress.Scheme == Uri.UriSchemeHttp)
                {
                    mexBehavior.HttpGetEnabled = true;
                    this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                                            MetadataExchangeBindings.CreateMexHttpBinding(),
                                            "mex");
                }
                else if (baseAddress.Scheme == Uri.UriSchemeHttps)
                {
                    mexBehavior.HttpsGetEnabled = true;
                    this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                                            MetadataExchangeBindings.CreateMexHttpsBinding(),
                                            "mex");
                }
                else if (baseAddress.Scheme == Uri.UriSchemeNetPipe)
                {
                    this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                                            MetadataExchangeBindings.CreateMexNamedPipeBinding(),
                                            "mex");
                }
                else if (baseAddress.Scheme == Uri.UriSchemeNetTcp)
                {
                    this.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                                            MetadataExchangeBindings.CreateMexTcpBinding(),
                                            "mex");
                }
            }

        }
    }


}