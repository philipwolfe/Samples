// SimplePool.cs
// Simple thread pool sample
using System;
using System.Collections;
using System.Threading;

// Useful way to store info that can be passed as a state on a work item
public class SomeState
{
   public int Cookie;
   public SomeState(int iCookie)
   {
      Cookie = iCookie;
   }
}

public class Alpha
{
   public Hashtable HashCount;
   public ManualResetEvent eventX;
   public static int iCount = 0;
   public static int iMaxCount = 0;
   public Alpha(int MaxCount) 
   {
      HashCount = new Hashtable(MaxCount);
      iMaxCount = MaxCount;
   }

   // Beta is the method that will be called when the work item is
   // serviced on the thread pool.
   // That means this method will be called when the thread pool has
   // an available thread for the work item.
   public void Beta(Object state)
   {
      // Write out the hashcode and cookie for the current thread
      Console.WriteLine(" {0} {1} :", Thread.CurrentThread.GetHashCode(),
         ((SomeState)state).Cookie);
      // The lock keyword allows thread-safe modification
      // of variables accessible across multiple threads.
      Console.WriteLine(
         "HashCount.Count=={0}, Thread.CurrentThread.GetHashCode()=={1}",
         HashCount.Count, 
         Thread.CurrentThread.GetHashCode());
      lock (HashCount) 
      {
         if (!HashCount.ContainsKey(Thread.CurrentThread.GetHashCode()))
            HashCount.Add (Thread.CurrentThread.GetHashCode(), 0);
         HashCount[Thread.CurrentThread.GetHashCode()] = 
            ((int)HashCount[Thread.CurrentThread.GetHashCode()])+1;
      }

      // Do some busy work.
      // Note: Depending on the speed of your machine, if you 
      // increase this number, the dispersement of the thread
      // loads should be wider.
      int iX  = 2000;
      Thread.Sleep(iX);
      // The Interlocked.Increment method allows thread-safe modification
      // of variables accessible across multiple threads.
      Interlocked.Increment(ref iCount);
      if (iCount == iMaxCount)
      {
         Console.WriteLine();
         Console.WriteLine("Setting eventX ");
         eventX.Set();
      }
   }
}

public class SimplePool
{
   public static int Main(string[] args)
   {
      Console.WriteLine("Thread Pool Sample:");
      bool W2K = false;
      int MaxCount = 10;  // Allow a total of 10 threads in the pool
      // Mark the event as unsignaled.
      ManualResetEvent eventX = new ManualResetEvent(false);
      Console.WriteLine("Queuing {0} items to Thread Pool", MaxCount);
      Alpha oAlpha = new Alpha(MaxCount);  // Create the work items.
      // Make sure the work items have a reference to the signaling event.
      oAlpha.eventX = eventX;
      Console.WriteLine("Queue to Thread Pool 0");
      try
      {
         // Queue the work items, which has the added effect of checking
         // which OS is running.
         ThreadPool.QueueUserWorkItem(new WaitCallback(oAlpha.Beta),
            new SomeState(0));
         W2K = true;
      }
      catch (NotSupportedException)
      {
         Console.WriteLine("These API's may fail when called on a non-Windows 2000 system.");
         W2K = false;
      }
      if (W2K)  // If running on an OS which supports the ThreadPool methods.
      {
         for (int iItem=1;iItem < MaxCount;iItem++)
         {
            // Queue the work items:
            Console.WriteLine("Queue to Thread Pool {0}", iItem);
            ThreadPool.QueueUserWorkItem(new WaitCallback(oAlpha.Beta),new SomeState(iItem));
         }
         Console.WriteLine("Waiting for Thread Pool to drain");
         // The call to exventX.WaitOne sets the event to wait until
         // eventX.Set() occurs.
         // (See oAlpha.Beta).
         // Wait until event is fired, meaning eventX.Set() was called:
         eventX.WaitOne(Timeout.Infinite,true);
         // The WaitOne won't return until the event has been signaled.
         Console.WriteLine("Thread Pool has been drained (Event fired)");
         Console.WriteLine();
         Console.WriteLine("Load across threads");
         foreach(object o in oAlpha.HashCount.Keys)
            Console.WriteLine("{0} {1}", o, oAlpha.HashCount[o]);
      }
      return 0;
   }
}
