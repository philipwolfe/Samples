// StopJoin.cs
using System;
using System.Threading;

public class Alpha
{

   // This method that will be called when the thread is started
   public void Beta()
   {
      while (true)
      {
         Console.WriteLine("Alpha.Beta is running in its own thread.");
      }
   }
};

public class Simple
{
   public static int Main()
   {
      Console.WriteLine("Thread Start/Stop/Join Sample");
      
      Alpha oAlpha = new Alpha();

      // Create the thread object, passing in the Alpha.Beta method
      // via a ThreadStart delegate. This does not start the thread.
      Thread oThread = new Thread(new ThreadStart(oAlpha.Beta));

      // Start the thread
      oThread.Start();

      // Spin for a while waiting for the started thread to become
      // alive:
      while (!oThread.IsAlive);
      
      // Put the Main thread to sleep for 1 millisecond to allow oThread
      // to do some work:
      Thread.Sleep(1);
      
      // Request that oThread be stopped
      oThread.Abort();
      
      // Wait until oThread finishes. Join also has overloads
      // that take a millisecond interval or a TimeSpan object.
      oThread.Join();
      
      Console.WriteLine();
      Console.WriteLine("Alpha.Beta has finished");
      
      try 
      {
         Console.WriteLine("Try to restart the Alpha.Beta thread");
         oThread.Start();
      }
      catch (ThreadStateException) 
      {
         Console.Write("ThreadStateException trying to restart Alpha.Beta. ");
         Console.WriteLine("Expected since aborted threads cannot be restarted.");
      }
      return 0;
   }
}
