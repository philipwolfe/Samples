//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities.Persistence;
using System.Collections.Generic;

namespace Microsoft.Samples.WF.WorkflowInstances
{
    public class StepCountExtension : IPersistenceParticipant
    {
        int currentCount;

        public int CurrentCount
        {
            get
            {
                return this.currentCount;
            }
        }

        internal void IncrementStepCount()
        {
            this.currentCount += 1;
        }

        public IAsyncResult BeginOnDelete(ICollection<object> extensions, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new CompletedAsyncResult(callback, state);
        }

        public IAsyncResult BeginOnSave(ICollection<object> extensions, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new CompletedAsyncResult<int>(currentCount, callback, state);
        }

        public void EndOnDelete(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        public object EndOnSave(IAsyncResult result)
        {
            return CompletedAsyncResult<int>.End(result);
        }

        public void OnDelete(ICollection<object> extensions, TimeSpan timeout)
        {
        }

        public void OnLoad(object loadedObject, ICollection<object> extensions)
        {
            if (loadedObject != null)
            {
                this.currentCount = (int)loadedObject;
            }
        }

        public object OnSave(ICollection<object> extensions, TimeSpan timeout)
        {
            return CurrentCount;
        }
    }
}
