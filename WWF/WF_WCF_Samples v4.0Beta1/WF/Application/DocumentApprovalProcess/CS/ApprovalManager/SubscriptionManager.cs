//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManager
{
    [ServiceContract]
    interface ISubscriptionService
    {
        [OperationContract]
        User Subscribe(User newuser);
        [OperationContract]
        void Unsubscribe(User id);
    }

    class SubscriptionManager : ISubscriptionService
    {

        public User Subscribe(User newuser)
        {
            return UserManager.AddUser(newuser.Name, newuser.Type, newuser.AddressRequest, newuser.AddressResponse);
        }

        public void Unsubscribe(User id)
        {
            UserManager.RemoveUser(id);
        }
    }
}
