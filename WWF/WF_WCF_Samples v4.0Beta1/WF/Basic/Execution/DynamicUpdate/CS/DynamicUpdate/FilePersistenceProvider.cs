//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel.Persistence;

namespace Microsoft.Samples.DynamicUpdate
{
    public class FilePersistenceProvider : PersistenceProvider
    {
        string fileName;

        public FilePersistenceProvider(string fileName, Guid id)
            : base(id)
        {
            this.fileName = fileName;
        }

        public override void Delete(object instance, TimeSpan timeout)
        {
            File.Delete(fileName);
        }

        public override IAsyncResult BeginDelete(object instance, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Delete(instance, timeout);

            return CompletedAsyncResult.Complete(callback, state);
        }

        public override void EndDelete(IAsyncResult result)
        {
        }

        public override object Create(object instance, TimeSpan timeout)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                serializer.WriteObject(stream, instance);
            }

            return null;
        }

        public override IAsyncResult BeginCreate(object instance, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Create(instance, timeout);
            return CompletedAsyncResult.Complete(callback, state);
        }

        public override object EndCreate(IAsyncResult result)
        {
            return CompletedAsyncResult.End(result);
        }

        public override object Load(TimeSpan timeout)
        {
            return Load(timeout, true);
        }

        public override object Load(TimeSpan timeout, bool lockInstance)
        {
            object result = null;
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                result = serializer.ReadObject(stream);
            }

            return result;
        }

        public override IAsyncResult BeginLoad(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return BeginLoad(timeout, true, callback, state);
        }

        public override IAsyncResult BeginLoad(TimeSpan timeout, bool lockInstance, AsyncCallback callback, object state)
        {
            object instance = Load(timeout, lockInstance);

            return CompletedAsyncResult.Complete(callback, state, instance);
        }

        public override object EndLoad(IAsyncResult result)
        {
            return CompletedAsyncResult.End(result);
        }

        public override object Update(object instance, TimeSpan timeout)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                serializer.WriteObject(stream, instance);
            }

            return null;
        }

        public override IAsyncResult BeginUpdate(object instance, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Create(instance, timeout);
            return CompletedAsyncResult.Complete(callback, state);
        }

        public override object EndUpdate(IAsyncResult result)
        {
            return CompletedAsyncResult.End(result);
        }

        protected override TimeSpan DefaultCloseTimeout
        {
            get { return TimeSpan.FromSeconds(30); }
        }

        protected override TimeSpan DefaultOpenTimeout
        {
            get { return TimeSpan.FromSeconds(30); }
        }

        protected override void OnAbort()
        {
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return CompletedAsyncResult.Complete(callback, state);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return CompletedAsyncResult.Complete(callback, state);
        }

        protected override void OnClose(TimeSpan timeout)
        {
        }

        protected override void OnEndClose(IAsyncResult result)
        {
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
        }

        protected override void OnOpen(TimeSpan timeout)
        {
        }
    }

    public class CompletedAsyncResult : IAsyncResult
    {
        object state;
        object result;

        public CompletedAsyncResult(object state)
        {
            this.state = state;
        }

        public object AsyncState
        {
            get
            {
                return this.state;
            }
        }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get
            {
                return new System.Threading.ManualResetEvent(true);
            }
        }

        public bool CompletedSynchronously
        {
            get
            {
                return true;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return true;
            }
        }

        public static IAsyncResult Complete(AsyncCallback callback, object state)
        {
            return Complete(callback, state, null);
        }

        public static IAsyncResult Complete(AsyncCallback callback, object state, object returnValue)
        {
            CompletedAsyncResult result = new CompletedAsyncResult(state);
            result.result = returnValue;

            if (callback != null)
            {
                callback(result);
            }

            return result;
        }

        public static object End(IAsyncResult result)
        {
            CompletedAsyncResult thisPtr = (CompletedAsyncResult)result;

            return thisPtr.result;
        }
    }
}
