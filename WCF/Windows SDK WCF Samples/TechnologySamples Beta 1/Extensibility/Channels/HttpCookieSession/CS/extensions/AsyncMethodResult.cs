
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

#region using

using System;
using System.Threading;

#endregion

namespace Microsoft.ServiceModel.Samples
{
    /// <summary>
    /// This class contains the IAsyncResult implementation 
    /// used to manage the state between asynchronous 
    /// Begin/End method calls.
    /// </summary>
    class AsyncMethodResult : IAsyncResult
    {
        #region Private Fields

        private object state;
        private AsyncCallback callback;
        private WaitHandle waitHandle;

        private bool isCompleted;
        private bool completedSynchronously;
        
        private object additionalData;        
        private object thisLock = new object();

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of AsyncMethodResult class
        /// with the specified arguments.
        /// </summary>        
        public AsyncMethodResult(AsyncCallback callback, 
            object state)
        {                        
            this.callback = callback;
            this.state = state;
            completedSynchronously = false;
        }
        
        #endregion

        #region IAsyncResult Members

        /// <summary>
        /// Gets the AsyncState.
        /// </summary>
        public object AsyncState
        {
            get { return state; }
        }

        /// <summary>
        /// Gets the AsyncWaitHandle.
        /// </summary>
        public WaitHandle AsyncWaitHandle
        {
            get 
            { 
                waitHandle = new ManualResetEvent(true);
                return waitHandle;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the asynchronous 
        /// request was served in synchronous fashion.
        /// Q: Should we always return false for this?         
        /// </summary>
        public bool CompletedSynchronously
        {
            get
            {
                lock (thisLock)
                {
                    return completedSynchronously;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the asynchronous 
        /// operation is completed or not.
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                lock (thisLock)
                {
                    return isCompleted;
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Sets the state of the asynchronous call.
        /// </summary>        
        public void SetCompleted(bool value)
        {
            lock (thisLock)
            {
                isCompleted = value;
            }
        }        

        /// <summary>
        /// Sets additional data associated with this 
        /// async result.
        /// </summary>
        public object AdditionalData
        {
            get { return additionalData; }
            set { additionalData = value; }
        }

        /// <summary>
        /// Gets the callback function.
        /// </summary>
        public AsyncCallback Callback
        {
            get { return this.callback; }
        }

        /// <summary>
        /// Sets the AsyncState object. 
        /// </summary>
        /// <param name="state"></param>
        public void SetAsyncState(object state)
        {
            lock (thisLock)
            {
                this.state = state;
            }
        }

        #endregion
    }
}
