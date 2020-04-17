using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.ServiceModel.Samples
{
    public class CustomHeader
    {
        public static String HeaderName = "InstanceId";
        public static String HeaderNamespace = "http://Microsoft.ServiceModel.Samples/Sharing";
    }

    /***
     * To enable sharing, implement the IInstanceContextProvider.
     * IInstanceContextInitializer is implemented as this class would like to be notified whenever a new 
     * InstanceContext is created so the AddressableInstanceContext extension can be added to it.
     * Its via this extension the unique id and custom headers needed to share a particular InstanceContext
     * will be retrieved.
     */ 
    public class CalculatorExtension : IInstanceContextProvider
	{
        Dictionary<String, InstanceContext> contextMap;
        //Use this internal variable if you want all messages to be processed by same instance context.
        //InstanceContext singleton;
        public CalculatorExtension()
        {
            this.contextMap = new Dictionary<string, InstanceContext>();
        }

        #region IInstanceContextProvider Members

        public InstanceContext GetExistingInstanceContext(Message message, IContextChannel channel)
        {
            //Singleton behavior
            //if (mode == InstanceContextMode.Single)
            //    return this.singleton;

            //PerCall behavior
            //If a new InstanceContext is needed to server each call, just return null so internally WCF will create
            //a new one.
            //if (mode == InstanceContextMode.PerCall)
            //    return null;

            //Per Session behavior
            //To implement a PerSession behavior (If underlyin binding supports it) where in all 
            //methods from one ChannelFactory will be serviced by the same InstanceContext

            //Check if the incoming request has the InstanceContext id it wants to connect with.
            if (message.Headers.FindHeader(CustomHeader.HeaderName, CustomHeader.HeaderNamespace) != -1)
            {
                String sharingId = message.Headers.GetHeader<string>(CustomHeader.HeaderName, CustomHeader.HeaderNamespace);
                if (sharingId != null && contextMap.ContainsKey(sharingId))
                {
                    //Retrieve the InstanceContext from the map
                    InstanceContext context = contextMap[sharingId];
                    if (context != null)
                    {
                        if (!context.IncomingChannels.Contains(channel))
                        {
                            //Add this channel that is about to be associated with this InstanceContext so it doesnt
                            //get disposed when the original Channel that created this closes.
                            context.IncomingChannels.Add(channel);
                        }
                        return contextMap[sharingId];
                    }
                }
            }

            //Look in each InstanceContext to see if this channel is already in the list of IncomingChannels. 
            //This is similar to how WCF runtime internally implements PerSession.
            foreach (InstanceContext context in contextMap.Values)
            {
                if (context.IncomingChannels.Contains(channel))
                    return context;
            }

            //No existing InstanceContext was found so return null and WCF will create a new one.
            return null;

        }

        public bool IsIdle(InstanceContext instanceContext)
        {
            //Return if this InstanceContext has no pending channels using it.
            return (instanceContext.IncomingChannels.Count == 0);
        }

        public void NotifyIdle(InstanceContextIdleCallback callback, InstanceContext instanceContext)
        {
        }

        public void InitializeInstanceContext(InstanceContext instanceContext, Message message, IContextChannel channel)
        {
            //Enable the line if singleton behavior is desired.
            //this.singleton = instanceContext;

            //Bind this channel to the instancecontext so that WCF doesnt close it after processing the message
            instanceContext.IncomingChannels.Add(channel);

            //Look if the Client has given us a unique ID to add to this InstanceContext
            int headerIndex = message.Headers.FindHeader(CustomHeader.HeaderName, CustomHeader.HeaderNamespace);

            AddressableInstanceContextExtension extension = null;
            String headerId = null;
            if (headerIndex != -1)
            {
                headerId = message.Headers.GetHeader<string>(headerIndex);
            }
            //Add this Id to the extension
            extension = new AddressableInstanceContextExtension(headerId);
            instanceContext.Extensions.Add(extension);
            this.contextMap[extension.InstanceId] = instanceContext;

            //Register the Closing event of this InstancContext so it can be removed from the collection
            instanceContext.Closing += this.RemoveInstanceContext;
        }

        #endregion

        public void RemoveInstanceContext(object o, EventArgs args)
        {
            InstanceContext context = o as InstanceContext;
            AddressableInstanceContextExtension extension = context.Extensions.Find<AddressableInstanceContextExtension>();
            String id = (extension != null) ? extension.InstanceId : null;
            if (this.contextMap[id] != null)
            {
                this.contextMap.Remove(id);
            }
        }
    }

    //Create an Extension that will attach to each InstanceContext and let it retrieve the Id, Headers needed for sending 
    //to the client
    public class AddressableInstanceContextExtension : IExtension<InstanceContext>
    {
        String instanceId;

        public AddressableInstanceContextExtension(String id)
        {
            if (String.IsNullOrEmpty(id))
            {
                this.instanceId = Guid.NewGuid().ToString();
            }
            else
            {
                this.instanceId = id;
            }
        }

        public String InstanceId
        {
            get
            {
                return this.instanceId;
            }
        }

        #region IExtension<InstanceContext> Members

        public void Attach(InstanceContext owner)
        {
            //Need not implement for this scenario
        }

        public void Detach(InstanceContext owner)
        {
            //Need not implement for this scenario
        }

        #endregion
    }
}
