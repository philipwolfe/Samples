//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.Activities
{
    using System;
    using System.Activities;

    public sealed class MessageBox : CodeActivity
    {
        public InArgument<string> Text{ get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            System.Windows.Forms.MessageBox.Show(this.Text.Get(context));
        }
    }
}
