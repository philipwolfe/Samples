// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Threading;

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// A generic base class for IAsyncResult implementations
    /// that wraps a ManualResetEvent.
    /// </summary>
    abstract class AsyncResult : IAsyncResult
    {
        AsyncCallback callback;
        object state;
        bool completedSynchronously;
        bool endCalled;
        Exception exception;
        bool isCompleted;
        ManualResetEvent manualResetEvent;

        protected AsyncResult(AsyncCallback callback, object state)
        {
            this.callback = callback;
            this.state = state;
        }

        public object AsyncState
        {
            get
            {
                return state;
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                if (manualResetEvent != null)
                {
                    return manualResetEvent;
                }

                lock (ThisLock)
                {
                    if (manualResetEvent == null)
                    {
                        manualResetEvent = new ManualResetEvent(isCompleted);
                    }
                }

                return manualResetEvent;
            }
        }

        public bool CompletedSynchronously
        {
            get
            {
                return completedSynchronously;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return isCompleted;
            }
        }

        object ThisLock
        {
            get { return this; }
        }

        //Sets the ManualResetEvent and invokes the callback
        //if necessary.
        protected void Complete(bool completedSynchronously)
        {
            Debug.Assert(!isCompleted);
            this.completedSynchronously = completedSynchronously;

            if (completedSynchronously)
            {
                this.isCompleted = true;
                Debug.Assert(manualResetEvent == null);
            }
            else
            {
                lock (ThisLock)
                {
                    this.isCompleted = true;
                    if (manualResetEvent != null)
                    {
                        manualResetEvent.Set();
                    }
                }
            }

            try
            {
                if (callback != null)
                {
                    callback(this);
                }
            }
            catch (Exception unhandledException)
            {
                unhandledException = new Exception("Async callback exception", unhandledException);
                ThreadPool.QueueUserWorkItem(new WaitCallback(RaiseUnhandledException), unhandledException);
            }
        }

        protected void Complete(bool completedSynchronously, Exception exception)
        {
            this.exception = exception;
            Complete(completedSynchronously);
        }

        protected static void End(AsyncResult asyncResult)
        {
            Debug.Assert(asyncResult != null);
            if (asyncResult.endCalled)
            {
                throw new InvalidOperationException("Async object already ended.");
            }

            asyncResult.endCalled = true;

            if (!asyncResult.isCompleted)
            {
                using (WaitHandle waitHandle = asyncResult.AsyncWaitHandle)
                {
                    waitHandle.WaitOne();
                }
            }

            if (asyncResult.exception != null)
            {
                throw asyncResult.exception;
            }
        }

        void RaiseUnhandledException(object o)
        {
            Exception exception = (Exception)o;
            throw exception;
        }
    }

    //A strongly typed AsyncResult
    abstract class TypedAsyncResult<T> : AsyncResult
    {
        T data;

        public TypedAsyncResult(AsyncCallback callback, object state)
            : base(callback, state)
        {
        }

        public T Data
        {
            get { return data; }
        }

        protected void Complete(T data, bool completedSynchronously)
        {
            this.data = data;
            Complete(completedSynchronously);
        }

        public static T End(IAsyncResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException("result");
            }

            TypedAsyncResult<T> completedResult = result as TypedAsyncResult<T>;

            if (completedResult == null)
            {
                throw new ArgumentException("Invalid async result.", "result");
            }

            AsyncResult.End(completedResult);

            return completedResult.Data;
        }
    }

    //A strongly typed AsyncResult that completes as soon as it is instantiated.
    class TypedCompletedAsyncResult<T> : TypedAsyncResult<T>
    {
        public TypedCompletedAsyncResult(T data, AsyncCallback callback, object state)
            : base(callback, state)
        {
            Complete(data, true);
        }

        public new static T End(IAsyncResult result)
        {
            TypedCompletedAsyncResult<T> completedResult = result as TypedCompletedAsyncResult<T>;
            if (completedResult == null)
            {
                throw new ArgumentException("Invalid async result.", "result");
            }

            return TypedAsyncResult<T>.End(completedResult);
        }
    }
}
