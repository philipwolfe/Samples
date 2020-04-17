//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System.Activities;
using System.IO;

namespace Microsoft.Samples.NoPersistZone
{
    public sealed class CreateTextWriter : CodeActivity<TextWriter>
    {
        public string Filename { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            TextWriter writer = new StreamWriter(this.Filename);
            this.Result.Set(context, writer);
        }
    }
}