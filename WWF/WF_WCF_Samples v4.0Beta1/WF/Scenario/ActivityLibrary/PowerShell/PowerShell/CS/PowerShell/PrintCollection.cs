//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Activities;
using System.Collections.Generic;
using System.Windows.Markup;
using System.ComponentModel;

namespace Microsoft.Samples.PowerShell
{
    [ContentProperty("Body")]
    public sealed class PrintCollection<T> : CodeActivity<T>
    {
        [DefaultValue(null)]
        public InArgument<ICollection<T>> Collection { get; set; }

        [DefaultValue(null)]
        public string Header { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            ICollection<T> underlyingCollection = this.Collection.Get<ICollection<T>>(context);

            Console.WriteLine(this.Header);
            if (underlyingCollection.Count == 0)
            {
                Console.WriteLine("The collection is empty");
            }
            else
            {
                foreach (T obj in underlyingCollection)
                {
                    Console.WriteLine(obj.ToString());
                }
            }
            Console.WriteLine();
        }
    }
}
