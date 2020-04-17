//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Bookmarks
{
    using System;
    using System.Activities;

    public sealed class Read<T> : NativeActivity<T>
    {
        public Read()
            : base()
        {
        }

        public string BookmarkName { get; set; }

        protected override void Execute(ActivityExecutionContext context)
        {
            context.CreateNamedBookmark(this.BookmarkName, new BookmarkCallback(this.Continue));
        }

        void Continue(ActivityExecutionContext context, Bookmark bookmark, object obj)
        {
            this.Result.Set(context, (T)obj); 
        }
    }
}