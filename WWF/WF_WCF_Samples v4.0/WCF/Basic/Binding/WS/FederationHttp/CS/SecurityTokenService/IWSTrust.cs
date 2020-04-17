﻿//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;

using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Samples.WSFederationHttpBinding
{
    [ServiceContract]
    interface IWSTrust
    {
        [OperationContract(Action = Constants.Trust.Actions.Issue, ReplyAction = Constants.Trust.Actions.IssueReply)]
        Message Issue(Message request);
    }
}

