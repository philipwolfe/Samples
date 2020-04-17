//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.ProceduralActivities.GuessingGame
{
    using System;
    using System.Activities;

    /// <summary>
    /// This activity reads a line of text. To achieve its goal, this activity 
    /// creates a bookmark that will be resumed by the host when the text 
    /// is entered by the user. 
    /// </summary>
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