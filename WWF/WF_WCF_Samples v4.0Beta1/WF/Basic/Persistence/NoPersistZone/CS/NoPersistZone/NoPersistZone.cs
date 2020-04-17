//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System.Activities;

namespace Microsoft.Samples.NoPersistZone
{
    public sealed class NoPeristZone : NativeActivity
    {
        public WorkflowElement Body { get; set; }

        protected override void Execute(ActivityExecutionContext context)
        {
            context.SetupNoPersistenceBlock();
            if (Body != null)
            {
                context.ScheduleActivity(Body);
            }
        }

        protected override void OnGetChildren(System.Collections.Generic.IList<WorkflowElement> children)
        {
            if (Body != null)
            {
                children.Add(Body);
            }
        }
    }
}