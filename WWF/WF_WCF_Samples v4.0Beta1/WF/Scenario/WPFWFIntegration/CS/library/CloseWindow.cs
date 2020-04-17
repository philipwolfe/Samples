//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Activities.Samples
{
    using System;
    using System.Activities;
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Threading;

    [ContentProperty("Window")]
    public sealed class CloseWindow : CodeActivity
    {
        public InArgument<Window> Window { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            if (Application.Current == null)
            {
                throw new InvalidOperationException("Must have an application");
            }

            Window targetWindow = Window.Get(context);
            targetWindow.Close();
        }
    }
}
