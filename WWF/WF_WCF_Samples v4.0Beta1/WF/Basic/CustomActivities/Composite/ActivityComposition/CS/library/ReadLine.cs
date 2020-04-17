﻿//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.Activities
{
    using System;
    using System.Activities;

    public sealed class ReadLine: NativeActivity<string>
    {
        public InArgument<string> BookmarkName { get; set; }

        protected override void Execute(ActivityExecutionContext context)
        {
            string name = this.BookmarkName.Get(context);

            if (name == null)
            {
                throw new Exception(string.Format("ReadLine {0}: BookmarkName cannot be null", this.DisplayName));
            }

            context.CreateNamedBookmark(name, new BookmarkCallback(OnReadComplete));
        }

        void OnReadComplete(ActivityExecutionContext context, Bookmark bookmark, object state)
        {
            string input = state as string; 
            
            if (input == null)
            {
                throw new Exception(string.Format("ReadLine {0}: ReadLine must be resumed with a non-null string"));
            }

            context.SetValue(base.Result, input);
        }
    }
}
