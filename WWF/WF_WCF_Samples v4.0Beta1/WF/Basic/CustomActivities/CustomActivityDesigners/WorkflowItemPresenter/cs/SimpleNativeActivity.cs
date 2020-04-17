//-------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved
//-------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Microsoft.Samples.UsingWorkflowItemPresenter
{
    public sealed class SimpleNativeActivity : NativeActivity
    {
        public WorkflowElement Body { get; set; }

        protected override void OnGetChildren(IList<WorkflowElement> children)
        {
            children.Add(Body);
        }

        protected override void Execute(ActivityExecutionContext context)
        {
            context.ScheduleActivity(Body);
        }
    }
}
