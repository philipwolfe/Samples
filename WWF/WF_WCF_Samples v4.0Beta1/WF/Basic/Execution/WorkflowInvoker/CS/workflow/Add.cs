//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.WorkflowModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Activities;

    public sealed class Add : CodeActivity<int>
    {
        public InArgument<int> X { get; set; }
        public InArgument<int> Y { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int x = X.Get(context);
            int y = Y.Get(context);

            context.SetValue(base.Result, x + y);
        }
    }
}
