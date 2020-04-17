//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Activities;
using System.ComponentModel;

namespace Microsoft.Samples.WF.WorkflowInstances
{
    public sealed class GetCurrentStepCount : CodeActivity<int>, IActivityExtensionProvider
    {
        void IActivityExtensionProvider.EnsureExtensions(IExtensionHost host)
        {
            if (host.GetExtension<StepCountExtension>() == null)
            {
                host.Extensions.Add(new StepCountExtension());
            }
        }

        protected override void Execute(CodeActivityContext context)
        {
            StepCountExtension stepCountExtension = context.GetExtension<StepCountExtension>();
            Result.Set(context, stepCountExtension.CurrentCount);
        }
    }
}
