using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Workflow.Runtime;
using System.Xml;

namespace Microsoft.WorkflowServices.Samples
{
    /// <summary>
    /// This is a helper class for allowing a local host application to interact with a
    /// single WorkflowService instance. All interaction is accomplished using messaging
    /// via ServiceContracts. 
    /// 
    /// This ServiceHost creates both a ServiceHost for a singleton Service implementation
    /// provided by the local host AND a WorkflowServiceHost for the Workflow Service
    /// implementation. It automatically creates local listener endpoints for the
    /// local Service and Workflow Service, such that each can communicate to eachother.
    ///
    /// The Workflow can communicate with those local host endpoints using a client endpoint 
    /// named "HostEndpoint". The local host can use CreateLocalChannel<T> to create channels
    /// to the Workflow Service.
    /// 
    /// This class also manages the context for a single Workflow instance, such that an
    /// application can shut-down and restarted, recovering the previous Workflow instance.
    /// This presumes the Workflow instance is being durably stored.
    /// </summary>
    public class LocalWorkflowServiceHost : WorkflowServiceHost
    {
        const string localBaseAddress = "net.pipe://localhost/";
        const string localServiceName = "/Listener.svc";
        const string localWorkflowServiceName = "/Workflow.svc";
        const string contextFileExtension = ".ctx";
        static Binding localBinding = new CustomBinding(new ContextBindingElement(), new BinaryMessageEncodingBindingElement(), new NamedPipeTransportBindingElement());
        
        LocalServiceHost localServiceHost = null;
        string localWorkflowAddress;
        string contextFileName;

        public LocalWorkflowServiceHost(Type workflowType, object localServiceInstance, params Uri[] baseAddress)
            : base(workflowType, baseAddress)
        {
            localServiceHost = new LocalServiceHost(localServiceInstance, baseAddress);
        }

        bool recoveredContext = false;
        public bool RecoveredContext
        {
            get { return recoveredContext; }
        }

        public TChannel CreateLocalChannel<TChannel>()
        {
            ChannelFactory<TChannel> channelFactory = new ChannelFactory<TChannel>(localBinding, localWorkflowAddress);
            TChannel channel = channelFactory.CreateChannel();
            IDictionary<XmlQualifiedName, string> context = ContextManager.DepersistContext(contextFileName);
            if (context != null && context.Count > 0)
            {
                ContextManager.ApplyContextToChannel(context, (IClientChannel)channel);
                recoveredContext = true;
                // register handlers to cleanup context file when Workflow completes or terminates.
                this.WorkflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { ContextManager.DeleteContext(contextFileName); };
                this.WorkflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e) { ContextManager.DeleteContext(contextFileName); };
            }
            return channel;
        }

        public IDictionary<XmlQualifiedName,string> MaintainContext(IClientChannel channel)
        {
            IDictionary<XmlQualifiedName, string> context = null;
            if (!RecoveredContext)
            {
                context = ContextManager.ExtractContextFromChannel((IClientChannel)channel);
                ContextManager.PersistContext(context, contextFileName);
                // register handlers to cleanup context file when Workflow completes or terminates.
                this.WorkflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { ContextManager.DeleteContext(contextFileName); };
                this.WorkflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e) { ContextManager.DeleteContext(contextFileName); };
            }
            return context;
        }

        // Override to add client endpoints for each local service endpoints
        protected override void ApplyConfiguration()
        {
            // TODO: Need to add fix-named client endpoints for Workflow to send back to local host.
            base.ApplyConfiguration();
        }

        // Override to add local endpoints for each implemented Contract
        protected override ServiceDescription CreateDescription(out System.Collections.Generic.IDictionary<string, ContractDescription> implementedContracts)
        {
            // TODO: support restricted list of Contracts which have local endpoints
            ServiceDescription sd = base.CreateDescription(out implementedContracts);
            if (implementedContracts.Count > 0)
            {
                localWorkflowAddress = localBaseAddress + sd.Name + localWorkflowServiceName;
                foreach (KeyValuePair<string, ContractDescription> item in implementedContracts)
                {
                    sd.Endpoints.Add(new ServiceEndpoint(item.Value, localBinding, new EndpointAddress(localWorkflowAddress)));
                }
            }
            return sd;
        }

        // Override to open LocalServiceHost
        protected override void OnOpening()
        {
            //TODO: set path for .ctx file in TEMP directory
            contextFileName = localServiceHost.Description.ServiceType.Name + contextFileExtension;
            localServiceHost.Open();
            base.OnOpening();
        }

        // Override to close LocalServiceHost
        protected override void OnClosed()
        {
            base.OnClosed();
            localServiceHost.Close();
        }

#region private nested class LocalServiceHost

        // Private class to automatically populate local endpoints for local Service
        class LocalServiceHost : ServiceHost
        {
            public LocalServiceHost(object singletonInstance, params Uri[] baseAddresses)
                : base(singletonInstance, baseAddresses)
            {
            }

            // Override to add local endpoints for each implemented Contract
            protected override ServiceDescription CreateDescription(out System.Collections.Generic.IDictionary<string, ContractDescription> implementedContracts)
            {   
                ServiceDescription sd = base.CreateDescription(out implementedContracts);
                if (implementedContracts.Count > 0)
                {
                    string localAddress = localBaseAddress + sd.ServiceType.Name + localServiceName;
                    foreach (KeyValuePair<string, ContractDescription> item in implementedContracts)
                    {
                        sd.Endpoints.Add(new ServiceEndpoint(item.Value,localBinding,new EndpointAddress(localAddress)));
                    }
                }
                return sd;
            }

        }
#endregion

    }
}
