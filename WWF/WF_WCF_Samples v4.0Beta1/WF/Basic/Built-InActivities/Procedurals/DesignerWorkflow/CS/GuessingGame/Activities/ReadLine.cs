//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;

namespace Microsoft.Samples.GuessingGame
{
    public sealed class ReadLine : NativeActivity
    {
        public OutArgument<string> Result { get; set; }
        public InArgument<string> BookmarkName { get; set; }

        protected override void Execute(ActivityExecutionContext context)
        {
            string name = this.BookmarkName.Get(context);

            if (name == null)
            {
                throw new Exception(
                    string.Format(
                        "ReadLine {0}: BookmarkName cannot be null",
                        this.DisplayName));
            }

            context.CreateNamedBookmark(name, new BookmarkCallback(OnReadComplete));
        }

        void OnReadComplete(ActivityExecutionContext context, Bookmark bookmark, object state)
        {
            string input = state as string;
            context.SetValue(this.Result, input);
        }
    }
}