﻿//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManagerActivityLibrary
{
    public class UserWithIndex
    {
        public UserWithIndex(User u, int index)
        {
            U = u;
            Index = index;
        }
        public UserWithIndex() { }
        public User U { get; set; }
        public int Index { get; set; }
    }
}
