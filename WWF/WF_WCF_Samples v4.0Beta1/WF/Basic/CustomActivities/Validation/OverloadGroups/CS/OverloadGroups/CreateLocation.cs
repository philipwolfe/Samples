//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Activities;

namespace Microsoft.Samples.OverloadIsRequired
{
    class CreateLocation: CodeActivity
    {
        [IsRequired]
        public InArgument<string> Name { get; set; }
       
        public InArgument<string> Description { get; set; }

        [IsRequired]
        [OverloadGroup("G1")]
        public InArgument<int> Latitude { get; set; }
        
        [IsRequired]
        [OverloadGroup("G1")]
        public InArgument<int> Longitude { get; set; }

        [IsRequired]
        [OverloadGroup("G2")]
        [OverloadGroup("G3")]
        public InArgument<string> Street { get; set; }

        [IsRequired]
        [OverloadGroup("G2")]
        public InArgument<string> City { get; set; }

        [IsRequired]
        [OverloadGroup("G2")]
        public InArgument<string> State { get; set; }
        
        [IsRequired]
        [OverloadGroup("G3")]
        public InArgument<int> Zip { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            // not needed for the sample
        }        
    }
}
