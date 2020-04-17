//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System.Activities;

namespace Microsoft.Samples.NoPersistZone
{
    public sealed class ReadLine : NativeActivity<string>
    {
        public string BookmarkName { get; set; }

        protected override void Execute(ActivityExecutionContext context)
        {
            context.CreateNamedBookmark(this.BookmarkName, this.Continue);
        }

        void Continue(ActivityExecutionContext context, Bookmark bookmark, object value)
        {
            if (value is string)
            {
                context.SetValue(this.Result, (string)value);
            }
        }
    }
}