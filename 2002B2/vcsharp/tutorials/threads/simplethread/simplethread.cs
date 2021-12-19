// Threads\SimpleThread.cs
using System;
using System.Threading;

public class Alpha 
{
   // The method that will be called when the thread is started:
   public void Beta()
   {
      Console.WriteLine("Alpha.Beta is running in its own thread.");
   }
}

public class Simple
{
   public static int Main()
   {
      Console.WriteLine("Thread Simple Example:");
      Alpha oAlpha = new Alpha();

      // Create the thread object, passing in the Alpha.Beta method
      // via a ThreadStart delegate
      Thread oThread = new Thread(new ThreadStart(oAlpha.Beta));

      // Start the thread
      // Note that you don't have to stop or free the thread; this
      // will happen automatically by the runtime.
      oThread.Start();

      return 0;
   }
}
