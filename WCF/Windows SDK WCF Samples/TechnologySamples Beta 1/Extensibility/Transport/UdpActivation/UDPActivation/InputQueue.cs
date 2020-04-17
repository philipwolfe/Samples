//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Diagnostics;
using System.Threading;

namespace Microsoft.ServiceModel.Samples
{
    // ItemDequeuedCallback is called as an item is dequeued from the InputQueue.  The 
    // InputQueue lock is not held during the callback.  However, the user code will
    // not be notified of the item being available until the callback returns.  If you
    // are not sure if the callback will block for a long time, then first call 
    // IOThreadScheduler.ScheduleCallback to get to a "safe" thread.
    delegate void ItemDequeuedCallback();

    /// <summary>
    /// Handles asynchronous interactions between producers and consumers. 
    /// Producers can dispatch available data to the input queue, 
    /// where it will be dispatched to a waiting consumer or stored until a
    /// consumer becomes available. Consumers can synchronously or asynchronously
    /// request data from the queue, which will be returned when data becomes
    /// available.
    /// </summary>
    /// <typeparam name="T">The concrete type of the consumer objects that are waiting for data.</typeparam>
    class InputQueue<T> : IDisposable where T : class, IDisposable
    {
        //Stores items that are waiting to be consumed.
        ItemQueue itemQueue;

        //Each IQueueReader represents some consumer that is waiting for
        //items to appear in the queue. The readerQueue stores them
        //in an ordered list so consumers get serviced in a FIFO manner.
        Queue<IQueueReader> readerQueue;

        //Represents the current state of the InputQueue
        //as it transitions through its lifecycle.
        QueueState queueState;
        enum QueueState
        {
            Created,
            Open,
            Shutdown,
            Closed
        }

        //Each IQueueWaiter represents some waiter that is waiting for
        //items to appear in the queue.  When any item appears, all
        //waiters are signalled.
        List<IQueueWaiter> waiterList;

        static WaitCallback onInvokeDequeuedCallback;
        static WaitCallback onDispatchCallback;
        static WaitCallback completeOutstandingReadersCallback;
        static WaitCallback completeWaitersFalseCallback;
        static WaitCallback completeWaitersTrueCallback;


        public InputQueue()
        {
            itemQueue = new ItemQueue();
            readerQueue = new Queue<IQueueReader>();
            waiterList = new List<IQueueWaiter>();
            queueState = QueueState.Created;
        }

        public int PendingCount
        {
            get
            {
                lock (ThisLock)
                {                    
                    return itemQueue.ItemCount;
                }
            }
        }

        object ThisLock
        {
            get { return itemQueue; }
        }

        public bool TryDequeue(TimeSpan timeout, out T value)
        {
            WaitQueueReader reader = null;
            Item item = new Item();

            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        item = itemQueue.DequeueAvailableItem();
                    }
                    else
                    {
                        reader = new WaitQueueReader(this);
                        readerQueue.Enqueue(reader);
                    }
                }
                else if (queueState == QueueState.Shutdown)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        item = itemQueue.DequeueAvailableItem();
                    }
                    else if (itemQueue.HasAnyItem)
                    {
                        reader = new WaitQueueReader(this);
                        readerQueue.Enqueue(reader);
                    }
                    else
                    {
                        value = default(T);
                        return true;
                    }
                }
                else if (queueState == QueueState.Closed)
                {
                    throw new ObjectDisposedException(this.GetType().ToString());
                }
                else // queueState == QueueState.Created
                {
                    throw new InvalidOperationException("Object must be opened to Dequeue");
                }
            }

            if (reader != null)
            {
                return reader.Wait(timeout, out value);
            }
            else
            {
                InvokeDequeuedCallback(item.DequeuedCallback);
                value = item.Value;
                return true;
            }
        }

        public IAsyncResult BeginTryDequeue(TimeSpan timeout, AsyncCallback callback, object state)
        {
            Item item;

            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        item = itemQueue.DequeueAvailableItem();
                    }
                    else
                    {
                        AsyncQueueReader reader = new AsyncQueueReader(this, timeout, callback, state);
                        readerQueue.Enqueue(reader);
                        return reader;
                    }
                }
                else if (queueState == QueueState.Shutdown)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        item = itemQueue.DequeueAvailableItem();
                    }
                    else if (itemQueue.HasAnyItem)
                    {
                        AsyncQueueReader reader = new AsyncQueueReader(this, timeout, callback, state);
                        readerQueue.Enqueue(reader);
                        return reader;
                    }
                    else
                    {
                        return new TypedCompletedAsyncResult<T>(null, callback, state);
                    }
                }
                else if (queueState == QueueState.Closed)
                {
                    throw new ObjectDisposedException(this.GetType().ToString());
                }
                else // queueState == QueueState.Created 
                {
                    throw new InvalidOperationException("Object must be opened to Dequeue");
                }
            }

            InvokeDequeuedCallback(item.DequeuedCallback);
            return new TypedCompletedAsyncResult<T>(item.Value, callback, state);
        }

        //Ends an asynchronous Dequeue operation.
        public bool EndTryDequeue(IAsyncResult result, out T value)
        {
            TypedCompletedAsyncResult<T> typedResult = result as TypedCompletedAsyncResult<T>;

            if (typedResult != null)
            {
                value = TypedCompletedAsyncResult<T>.End(result);
                return true;
            }

            return AsyncQueueReader.End(result, out value);
        }

        static void CompleteOutstandingReadersCallback(object state)
        {
            IQueueReader[] outstandingReaders = (IQueueReader[])state;

            for (int i = 0; i < outstandingReaders.Length; i++)
            {
                outstandingReaders[i].Set(null);
            }
        }

        static void CompleteWaitersFalseCallback(object state)
        {
            CompleteWaiters(false, (IQueueWaiter[])state);
        }

        static void CompleteWaitersTrueCallback(object state)
        {
            CompleteWaiters(true, (IQueueWaiter[])state);
        }

        static void CompleteWaiters(bool itemAvailable, IQueueWaiter[] waiters)
        {
            for (int i=0; i<waiters.Length; i++)
            {
                waiters[i].Set(itemAvailable);
            }
        }

        static void CompleteWaitersLater(bool itemAvailable, IQueueWaiter[] waiters)
        {
            if (itemAvailable)
            {
                if (completeWaitersTrueCallback == null)
                    completeWaitersTrueCallback = new WaitCallback(CompleteWaitersTrueCallback);

                ThreadPool.QueueUserWorkItem(completeWaitersTrueCallback, waiters);
            }
            else
            {
                if (completeWaitersFalseCallback == null)
                    completeWaitersFalseCallback = new WaitCallback(CompleteWaitersFalseCallback);

                ThreadPool.QueueUserWorkItem(completeWaitersFalseCallback, waiters);
            }
        }

        void GetWaiters(out bool itemAvailable, out IQueueWaiter[] waiters)
        {
            if (waiterList.Count > 0)
            {
                waiters = waiterList.ToArray();
                waiterList.Clear();
            }
            else
            {
                waiters = null;
            }

            itemAvailable = !((queueState == QueueState.Closed) || (queueState == QueueState.Shutdown));
        }

        public void Close()
        {
            ((IDisposable)this).Dispose();
        }

        public void Shutdown()
        {
            IQueueReader[] outstandingReaders = null;
            lock (ThisLock)
            {
                if (queueState == QueueState.Shutdown)
                    return;

                if (queueState == QueueState.Closed)
                    return;

                this.queueState = QueueState.Shutdown;

                if (readerQueue.Count > 0 && this.itemQueue.ItemCount == 0)
                {
                    outstandingReaders = new IQueueReader[readerQueue.Count];
                    readerQueue.CopyTo(outstandingReaders, 0);
                    readerQueue.Clear();
                }
            }

            if (outstandingReaders != null)
            {
                for (int i = 0; i < outstandingReaders.Length; i++)
                {
                    outstandingReaders[i].Set(null);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                bool dispose = false;

                lock (ThisLock)
                {
                    if (queueState != QueueState.Closed)
                    {
                        queueState = QueueState.Closed;
                        dispose = true;
                    }
                }

                if (dispose)
                {
                    while (readerQueue.Count > 0)
                    {
                        IQueueReader reader = readerQueue.Dequeue();
                        reader.Set(null);
                    }

                    while (itemQueue.HasAnyItem)
                    {
                        Item item = itemQueue.DequeueAnyItem();
                        item.Value.Dispose();
                        InvokeDequeuedCallback(item.DequeuedCallback);
                    }
                }
            }
        }

        public void Dispatch()
        {
            IQueueReader reader = null;
            Item item = new Item();
            IQueueReader[] outstandingReaders = null;
            IQueueWaiter[] waiters = null;
            bool itemAvailable = true;

            lock (ThisLock)
            {
                this.GetWaiters(out itemAvailable, out waiters);

                if (queueState != QueueState.Closed)
                {
                    itemQueue.MakePendingItemAvailable();

                    if (readerQueue.Count > 0)
                    {
                        item = itemQueue.DequeueAvailableItem();
                        reader = readerQueue.Dequeue();

                        if (queueState == QueueState.Shutdown && readerQueue.Count > 0 && itemQueue.ItemCount == 0)
                        {
                            outstandingReaders = new IQueueReader[readerQueue.Count];
                            readerQueue.CopyTo(outstandingReaders, 0);
                            readerQueue.Clear();

                            itemAvailable = false;
                        }
                    }
                }
            }

            if (outstandingReaders != null)
            {
                if (completeOutstandingReadersCallback == null)
                    completeOutstandingReadersCallback = new WaitCallback(CompleteOutstandingReadersCallback);

                ThreadPool.QueueUserWorkItem(completeOutstandingReadersCallback, outstandingReaders);
            }

            if (waiters != null)
            {
                CompleteWaitersLater(itemAvailable, waiters);
            }

            if (reader != null)
            {
                InvokeDequeuedCallback(item.DequeuedCallback);
                reader.Set(item.Value);
            }
        }

        public void EnqueueAndDispatch(T item)
        {
            EnqueueAndDispatch(item, null);
        }

        public void EnqueueAndDispatch(T item, ItemDequeuedCallback dequeuedCallback)
        {
            EnqueueAndDispatch(item, dequeuedCallback, true);
        }

        public void EnqueueAndDispatch(T item, ItemDequeuedCallback dequeuedCallback, bool canDispatchOnThisThread)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            bool disposeItem = false;
            IQueueReader reader = null;
            bool dispatchLater = false;
            IQueueWaiter[] waiters = null;
            bool itemAvailable = true;

            lock (ThisLock)
            {
                this.GetWaiters(out itemAvailable, out waiters);

                if (queueState == QueueState.Open)
                {
                    if (canDispatchOnThisThread)
                    {
                        if (readerQueue.Count == 0)
                        {
                            itemQueue.EnqueueAvailableItem(item, dequeuedCallback);
                        }
                        else
                        {
                            reader = readerQueue.Dequeue();
                        }
                    }
                    else
                    {
                        if (readerQueue.Count == 0)
                        {
                            itemQueue.EnqueueAvailableItem(item, dequeuedCallback);
                        }
                        else
                        {
                            itemQueue.EnqueuePendingItem(item, dequeuedCallback);
                            dispatchLater = true;
                        }
                    }
                }
                else if (queueState == QueueState.Closed || queueState == QueueState.Shutdown)
                {
                    disposeItem = true;
                }
                else // queueState == QueueState.Created
                {
                    itemQueue.EnqueueAvailableItem(item, dequeuedCallback);
                }
            }

            if (waiters != null)
            {
                if (canDispatchOnThisThread)
                {
                    CompleteWaiters(itemAvailable, waiters);
                }
                else
                {
                    CompleteWaitersLater(itemAvailable, waiters);
                }
            }

            if (reader != null)
            {
                InvokeDequeuedCallback(dequeuedCallback);
                reader.Set(item);
            }

            if (dispatchLater)
            {
                if (onDispatchCallback == null)
                    onDispatchCallback = new WaitCallback(OnDispatchCallback);
                ThreadPool.QueueUserWorkItem(onDispatchCallback, this);
            }
            else if (disposeItem)
            {
                InvokeDequeuedCallback(dequeuedCallback);
                item.Dispose();
            }
        }

        // This will not block, however, Dispatch() must be called later if this function
        // returns true.
        public bool EnqueueWithoutDispatch(T item, ItemDequeuedCallback dequeuedCallback)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            lock (ThisLock)
            {
                // Open || Created
                if (queueState != QueueState.Closed && queueState != QueueState.Shutdown)
                {
                    if (readerQueue.Count == 0)
                    {
                        itemQueue.EnqueueAvailableItem(item, dequeuedCallback);
                        return false;
                    }
                    else
                    {
                        itemQueue.EnqueuePendingItem(item, dequeuedCallback);
                        return true;
                    }
                }
            }

            item.Dispose();
            InvokeDequeuedCallbackLater(dequeuedCallback);
            return false;
        }

        static void OnDispatchCallback(object state)
        {
            ((InputQueue<T>)state).Dispatch();
        }

        static void InvokeDequeuedCallbackLater(ItemDequeuedCallback dequeuedCallback)
        {
            if (dequeuedCallback != null)
            {
                if (onInvokeDequeuedCallback == null)
                    onInvokeDequeuedCallback = OnInvokeDequeuedCallback;
                ThreadPool.QueueUserWorkItem(onInvokeDequeuedCallback, dequeuedCallback);
            }
        }

        static void InvokeDequeuedCallback(ItemDequeuedCallback dequeuedCallback)
        {
            if (dequeuedCallback != null)
            {
                dequeuedCallback();
            }
        }

        static void OnInvokeDequeuedCallback(object state)
        {
            ItemDequeuedCallback dequeuedCallback = (ItemDequeuedCallback)state;
            dequeuedCallback();
        }

        //Opens the InputQueue and allows it to start
        //dispatching items to consumers
        public void Open()
        {
            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    return;
                }

                if (queueState == QueueState.Closed)
                    throw new ObjectDisposedException(this.GetType().ToString());

                if (queueState == QueueState.Created)
                {
                    queueState = QueueState.Open;
                }
            }
        }

        bool RemoveReader(IQueueReader reader)
        {
            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    bool removed = false;

                    for (int i = readerQueue.Count; i > 0; i--)
                    {
                        IQueueReader temp = readerQueue.Dequeue();
                        if (Object.ReferenceEquals(temp, reader))
                        {
                            removed = true;
                        }
                        else
                        {
                            readerQueue.Enqueue(temp);
                        }
                    }

                    return removed;
                }
            }

            return false;
        }

        public bool WaitForItem(TimeSpan timeout)
        {
            WaitQueueWaiter waiter = null;
            bool itemAvailable = false;

            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        itemAvailable = true;
                    }
                    else
                    {
                        waiter = new WaitQueueWaiter();
                        waiterList.Add(waiter);
                    }
                }
                else if (queueState == QueueState.Shutdown)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        itemAvailable = true;
                    }
                    else if (itemQueue.HasAnyItem)
                    {
                        waiter = new WaitQueueWaiter();
                        waiterList.Add(waiter);
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (queueState == QueueState.Closed)
                {
                    throw new ObjectDisposedException(this.GetType().ToString());
                }
                else // queueState == QueueState.Created
                {
                    throw new InvalidOperationException("Object must be opened to WaitForItem");
                }
            }

            if (waiter != null)
            {
                return waiter.Wait(timeout);
            }
            else
            {
                return itemAvailable;
            }
        }

        public IAsyncResult BeginWaitForItem(TimeSpan timeout, AsyncCallback callback, object state)
        {
            bool itemAvailable;

            lock (ThisLock)
            {
                if (queueState == QueueState.Open)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        itemAvailable = true;
                    }
                    else
                    {
                        AsyncQueueWaiter waiter = new AsyncQueueWaiter(timeout, callback, state);
                        waiterList.Add(waiter);
                        return waiter;
                    }
                }
                else if (queueState == QueueState.Shutdown)
                {
                    if (itemQueue.HasAvailableItem)
                    {
                        itemAvailable = true;
                    }
                    else if (itemQueue.HasAnyItem)
                    {
                        AsyncQueueWaiter waiter = new AsyncQueueWaiter(timeout, callback, state);
                        waiterList.Add(waiter);
                        return waiter;
                    }
                    else
                    {
                        return new TypedCompletedAsyncResult<bool>(false, callback, state);
                    }
                }
                else if (queueState == QueueState.Closed)
                {
                    throw new ObjectDisposedException(this.GetType().ToString());
                }
                else // queueState == QueueState.Created 
                {
                    throw new InvalidOperationException("Object must be opened to WaitForItem");
                }
            }

            return new TypedCompletedAsyncResult<bool>(itemAvailable, callback, state);
        }

        public bool EndWaitForItem(IAsyncResult result)
        {
            TypedCompletedAsyncResult<bool> typedResult = result as TypedCompletedAsyncResult<bool>;
            if (typedResult != null)
                return TypedCompletedAsyncResult<bool>.End(result);

            return AsyncQueueWaiter.End(result);
        }

        interface IQueueReader
        {
            void Set(T item);
        }

        interface IQueueWaiter
        {
            void Set(bool itemAvailable);
        }

        class WaitQueueReader : IQueueReader
        {
            InputQueue<T> inputQueue;
            T item;
            ManualResetEvent waitEvent;

            public WaitQueueReader(InputQueue<T> inputQueue)
            {
                this.inputQueue = inputQueue;
                waitEvent = new ManualResetEvent(false);
            }

            public void Set(T item)
            {
                lock (this)
                {
                    this.item = item;
                    waitEvent.Set();
                }
            }

            public bool Wait(TimeSpan timeout, out T value)
            {
                if (timeout == TimeSpan.MaxValue)
                {
                    waitEvent.WaitOne();
                }
                else if (!waitEvent.WaitOne(timeout, false))
                {
                    if (this.inputQueue.RemoveReader(this))
                    {
                        value = default(T);
                        return false;
                    }
                    else
                    {
                        waitEvent.WaitOne();
                    }
                }

                value = item;
                return true;
            }
        }

        class AsyncQueueReader : AsyncResult, IQueueReader
        {
// TODO (kennyw): enable timeout
//             static WaitCallback timerCallback = new WaitCallback(AsyncQueueReader.TimerCallback);

//             bool expired;
            InputQueue<T> inputQueue;
            T item;
//             IOThreadTimer timer;

            public AsyncQueueReader(InputQueue<T> inputQueue, TimeSpan timeout, AsyncCallback callback, object state)
                : base(callback, state)
            {
                this.inputQueue = inputQueue;
//                 if (timeout != TimeSpan.MaxValue)
//                     this.timer = new IOThreadTimer(timerCallback, this, false);
            }

            public static bool End(IAsyncResult result, out T value)
            {
                AsyncQueueReader readerResult = result as AsyncQueueReader;
                if (readerResult == null)
                    throw new ArgumentException("result");
                AsyncResult.End(readerResult);

//                 if (readerResult.expired)
//                 {
//                     value = default(T);
//                     return false;
//                 }
//                 else
//                 {
                    value = readerResult.item;
                    return true;
//                 }
            }

//             static void TimerCallback(object state)
//             {
//                 AsyncQueueReader _this = (AsyncQueueReader)state;
//                 if (_this.inputQueue.RemoveReader(_this))
//                 {
//                     _this.expired = true;
//                     _this.Complete(false);
//                 }
//             }

            public void Set(T item)
            {
                this.item = item;
//                 this.timer.Cancel();
                Complete(false);
            }
        }

        struct Item
        {
            T value;
            ItemDequeuedCallback dequeuedCallback;

            public Item(T value, ItemDequeuedCallback dequeuedCallback)
            {
                this.value = value;
                this.dequeuedCallback = dequeuedCallback;
            }

            public T Value
            {
                get { return value; }
            }

            public ItemDequeuedCallback DequeuedCallback
            {
                get { return dequeuedCallback; }
            }
        }

        class WaitQueueWaiter : IQueueWaiter
        {
            bool itemAvailable;
            ManualResetEvent waitEvent;

            public WaitQueueWaiter()
            {
                waitEvent = new ManualResetEvent(false);
            }

            public void Set(bool itemAvailable)
            {
                lock (this)
                {
                    this.itemAvailable = itemAvailable;
                    waitEvent.Set();
                }
            }

            public bool Wait(TimeSpan timeout)
            {
                if (timeout == TimeSpan.MaxValue)
                {
                    waitEvent.WaitOne();
                }
                else if (!waitEvent.WaitOne(timeout, false))
                {
                    return false;
                }

                return this.itemAvailable;
            }
        }

        class AsyncQueueWaiter : AsyncResult, IQueueWaiter
        {
//             static WaitCallback timerCallback = new WaitCallback(AsyncQueueWaiter.TimerCallback);
// TODO (kennyw): enable timeout
//             IOThreadTimer timer;
            bool itemAvailable;

            public AsyncQueueWaiter(TimeSpan timeout, AsyncCallback callback, object state) : base(callback, state)
            {
//                 if (timeout != TimeSpan.MaxValue)
//                     this.timer = new IOThreadTimer(timerCallback, this, false);
            }

            public static bool End(IAsyncResult result)
            {
                AsyncQueueWaiter waiterResult = result as AsyncQueueWaiter;
                if (waiterResult == null)
                    throw new ArgumentException("result");
                AsyncResult.End(waiterResult);

                return waiterResult.itemAvailable;
            }

//             static void TimerCallback(object state)
//             {
//                 AsyncQueueWaiter _this = (AsyncQueueWaiter)state;
//                 _this.Complete(false);
//             }

            public void Set(bool itemAvailable)
            {
//                 bool timely;

                lock (this)
                {
//                     timely = (this.timer == null) || this.timer.Cancel();
                    this.itemAvailable = itemAvailable;
                }

//                 if (timely)
                    Complete(false);
            }
        }

        class ItemQueue
        {
            Item[] items;
            int head;
            int pendingCount;
            int totalCount;

            public ItemQueue()
            {
                items = new Item[1];
            }

            public Item DequeueAvailableItem()
            {
                return DequeueItemCore();
            }

            public Item DequeueAnyItem()
            {
                if (pendingCount == totalCount)
                    pendingCount--;
                return DequeueItemCore();
            }

            void EnqueueItemCore(T value, ItemDequeuedCallback dequeuedCallback)
            {
                if (totalCount == items.Length)
                {
                    Item[] newItems = new Item[items.Length * 2];
                    for (int i = 0; i < totalCount; i++)
                        newItems[i] = items[(head + i) % items.Length];
                    head = 0;
                    items = newItems;
                }
                int tail = (head + totalCount) % items.Length;
                items[tail] = new Item(value, dequeuedCallback);
                totalCount++;
            }

            Item DequeueItemCore()
            {
                Item item = items[head];
                items[head] = new Item();
                totalCount--;
                head = (head + 1) % items.Length;
                return item;
            }

            public void EnqueuePendingItem(T value, ItemDequeuedCallback dequeuedCallback)
            {
                EnqueueItemCore(value, dequeuedCallback);
                pendingCount++;
            }

            public void EnqueueAvailableItem(T value, ItemDequeuedCallback dequeuedCallback)
            {
                EnqueueItemCore(value, dequeuedCallback);
            }

            public void MakePendingItemAvailable()
            {
                pendingCount--;
            }
            
            public bool HasAvailableItem
            {
                get { return totalCount > pendingCount; }
            }

            public bool HasAnyItem
            {
                get { return totalCount > 0; }
            }

            public int ItemCount
            {
                get { return totalCount; }
            }
        }
    }
}
