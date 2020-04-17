//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Activities;

namespace Microsoft.Samples.ContainmentValidation
{
    public sealed class ActivityCountry: NativeActivity
    {
        public ActivityCountry(): base()
        {
            this.Cities = new DesignTimeAwareCollection<WorkflowElement>(this);            
        }
        
        public Collection<WorkflowElement> Cities { get; set; }
        public string Name { get; set; }

        protected override void Execute(ActivityExecutionContext context)
        {
            // not needed for the sample
        }
    }   

}
