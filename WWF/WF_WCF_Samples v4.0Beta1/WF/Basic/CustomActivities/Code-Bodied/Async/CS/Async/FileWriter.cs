//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.WorkflowModel
{
    using System;
    using System.IO;
    using System.Text;
    using System.Activities;

    public sealed class FileWriter : CodeActivity
    {
        public FileWriter()
            : base() 
        { 
        }

        protected override void Execute(CodeActivityContext context)
        {
            AsyncOperationContext operationContext = context.SetupAsyncOperationBlock();

            string tempFileName = Path.GetTempFileName();
            Console.WriteLine("Writing to file: " + tempFileName);

            FileStream file = File.Open(tempFileName, FileMode.Create);

            operationContext.UserState = file;

            byte[] bytes = UnicodeEncoding.Unicode.GetBytes("123456789");
            file.BeginWrite(bytes, 0, bytes.Length, new AsyncCallback(Callback), operationContext);
        }

        void Callback(IAsyncResult result)
        {
            AsyncOperationContext operationContext = (AsyncOperationContext)result.AsyncState;
            operationContext.CompleteOperation(new BookmarkCallback(Continue), result);
        }

        void Continue(ActivityExecutionContext context, Bookmark bookmark, object state)
        {
            IAsyncResult result = (IAsyncResult)state;
            FileStream file = (FileStream)((AsyncOperationContext)result.AsyncState).UserState;

            try
            {
                file.EndWrite(result);
                file.Flush();
            }
            finally
            {
                file.Close();
            }
        }
    }
}