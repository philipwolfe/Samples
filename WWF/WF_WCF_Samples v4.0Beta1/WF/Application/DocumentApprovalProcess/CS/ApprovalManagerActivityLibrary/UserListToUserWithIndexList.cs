//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManagerActivityLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Activities;
    using System.Activities.Statements;

    using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;
    using System.Activities.Expressions;

    public sealed class UserListToUserWithIndexList : CodeActivity
    {
        public InArgument<List<User>> UserList { get; set; }
        public OutArgument<List<UserWithIndex>> UserListWithIndex { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            List<UserWithIndex> toret = new List<UserWithIndex>();
            int i = 0;

            foreach (User u in UserList.Get(context))
            {
                toret.Add(new UserWithIndex(u, i));
                i++;
                Console.WriteLine(u.Name + " index: " + i.ToString());
            }
            UserListWithIndex.Set(context, toret);
        }
    }
}
