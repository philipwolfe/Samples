// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Web.Hosting;
using Microsoft.ServiceModel.Samples.Channels;
using Microsoft.ServiceModel.Samples.Activation;
using System.Diagnostics;
using System.Collections.Generic;

namespace Microsoft.ServiceModel.Samples.Hosting
{
    class UdpProcessProtocolHandler : ProcessProtocolHandler
    {
        IAdphManager adphManager;
        Dictionary<int, AppInstance> appInstanceTable = new Dictionary<int, AppInstance>();

        public override void StartListenerChannel(IListenerChannelCallback listenerChannelCallback, IAdphManager adphManager)
        {
            int channelId = listenerChannelCallback.GetId();
            AppInstance appInstance;
            if (!this.appInstanceTable.TryGetValue(channelId, out appInstance))
            {
                lock (ThisLock)
                {
                    if (!this.appInstanceTable.TryGetValue(channelId, out appInstance))
                    {
                        int length = listenerChannelCallback.GetBlobLength();
                        byte[] blob = new byte[length];
                        listenerChannelCallback.GetBlob(blob, ref length);
                        appInstance = AppInstance.Deserialize(blob);
                        appInstanceTable.Add(channelId, appInstance);
                    }
                }
            }

            if (this.adphManager == null)
            {
                this.adphManager = adphManager;
            }

            Debug.Assert(channelId == appInstance.Id);
            this.adphManager.StartAppDomainProtocolListenerChannel(appInstance.AppKey,
                UdpConstants.UdpProtocolId, listenerChannelCallback);
        }

        public override void StopListenerChannel(int listenerChannelId, bool immediate)
        {
            AppInstance appInstance = this.appInstanceTable[listenerChannelId];
            this.adphManager.StopAppDomainProtocolListenerChannel(appInstance.AppKey,
                UdpConstants.UdpProtocolId, listenerChannelId, immediate);
        }

        public override void StopProtocol(bool immediate)
        {
            // TODO: we should not receive any new messages.
        }

        object ThisLock
        {
            get
            {
                return this.appInstanceTable;
            }
        }
    }
}
