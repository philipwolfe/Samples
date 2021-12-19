// Threads\SpinLockDriver.cs
//Build with "csc /r:spinlock.dll spinlockdriver.cs"

using System;
using System.Threading;

public class MainClass 
{
   public static int Main () {
      SpinLock s1 = new SpinLock("s1");
      SpinLock s2 = new SpinLock("s2");
      SpinLock s3 = new SpinLock("s3");
      SpinLock s4 = new SpinLock("s4");
      SpinLock s5 = new SpinLock("s5");

      // Create five TimerCallback objects for five different instances
      // of the SpinLock class. Create a timer for each callback,
      // scheduled to fire after 1/2 second and every 1/2 second
      // thereafter.
      TimerCallback tc1 = new TimerCallback (s1.ToggleLock);
      Timer t1 = new Timer (tc1, s1, 500, 500);
      TimerCallback tc2 = new TimerCallback (s2.ToggleLock);
      Timer t2 = new Timer (tc2, s2, 500, 500);
      TimerCallback tc3 = new TimerCallback (s3.ToggleLock);
      Timer t3 = new Timer (tc3, s3, 500, 500);
      TimerCallback tc4 = new TimerCallback (s4.ToggleLock);
      Timer t4 = new Timer (tc4, s4, 500, 500);
      TimerCallback tc5 = new TimerCallback (s5.ToggleLock);
      Timer t5 = new Timer (tc5, s5, 500, 500);

      Console.WriteLine ("Main thread going to sleep for 25 seconds...");
      // Sleep for 30 seconds and let the threads fight it out
      Thread.Sleep(30000);
      Console.WriteLine ("Main thread awake, disposing of timers and threads");

      // Be a good citizen and clean up the timers and their associated       // threads:
      t1.Dispose();
      t2.Dispose();
      t3.Dispose();
      t4.Dispose();
      t5.Dispose();
      return 0;
   }
}
