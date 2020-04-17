
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;

namespace Microsoft.ServiceModel.Samples
{
    public interface IChannelMessageInspector 
    {
        void OnSend(ref Message message);
        void OnReceive(ref Message message);

        IChannelMessageInspector Clone();
    }
}
