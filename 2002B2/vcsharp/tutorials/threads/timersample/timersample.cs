// Threads\TimerSample.cs
using System;
using System.Threading;

public class Alpha
{
   private ManualResetEvent e;
   public Alpha(ManualResetEvent ev)
   {
      e = ev;
   }
   // Alpha1, Alpha2, Alpha3, and Alpha4 are used as timer callback methods.
   // In addition, Alpha1 signals the ManualResetEvent
   public void Alpha1(Object o)
   {
      Console.WriteLine("Alpha1");
      e.Set( );
   }
   public void Alpha2(Object o)
   {
      Console.WriteLine("Alpha2");
   }
   public void Alpha3(Object o)
   {
      Console.WriteLine("Alpha3");
   }
   public void Alpha4(Object o)
   {
      Console.WriteLine("Alpha4");
   }
}

public class TimersSample
{
   public void test_timer( )
   {
      ManualResetEvent ev = new ManualResetEvent(false);
      // Create the object that encapsulates the timer callback methods.
      Alpha alpha = new Alpha(ev);
      bool w2k = true;
      try
      {
         // Create a timer object just to make sure timers work on this 
         // system. Call the callback (Alpha1) after 1/10 of a second, and 
         // don't repeat. The call/dispose sequence happens quickly enough 
         // that you probably won't see the message from the callback 
         // function.
         Timer testX = new Timer
                        (new TimerCallback(alpha.Alpha1), this, 100, 0);
         // Dispose of the timer after it is finished.
         testX.Dispose(ev);
      }
      catch (NotSupportedException)
      {
         Console.WriteLine("NotSupportedException was caught because: ");
         Console.WriteLine("\tSystem.Timer Not Supported on this system.");
         Console.WriteLine("\tMust be running on Windows 2000, or the .NET Framework Win32 Support");
         w2k = false;
      }
      if (w2k)
      {
         int iF = 10000;
         int iP = 0;
         uint uiF = 2000;
         uint uiP = 1000;
         long lF = 3000L;
         long lP = 500L;
         long lFc = 4000L;
         long lPc = 2000L;
         ev.Reset( );
         Console.WriteLine("Wait for 1 second using just the event timeout value");
         ev.WaitOne(1000,false);
         // We need to reset the event because it stays signaled until
         // manually reset.
         ev.Reset( );
         Console.WriteLine("1 second wait expired");
         
         //Create 4 callbacks, one for each method in Alpha
         TimerCallback timer_cb_1 = new TimerCallback(alpha.Alpha1);
         TimerCallback timer_cb_2 = new TimerCallback(alpha.Alpha2);
         TimerCallback timer_cb_3 = new TimerCallback(alpha.Alpha3);
         TimerCallback timer_cb_4 = new TimerCallback(alpha.Alpha4);

         // Create three timers using three different overloads of the 
         // timer constructor.
         // This timer will call Alpha1 after 10 seconds(iF==10000) and 
         // will not repeat(iP==0).
         Timer t1 = new Timer(timer_cb_1,this,iF,iP);    // iF and iP are ints
         // This timer will wait 2 seconds and then start calling Alpha2
         // every second.
         Timer t2 = new Timer(timer_cb_2,this,uiF,uiP);  // uiF and uiP are uints
         // This timer will call Alpha3 after 3 seconds and will repeat
         // every half second.
         Timer t3 = new Timer(timer_cb_3,this,lF,lP);    // lF and lP are longs

         // The main program thread will wait here for 10 seconds, 
         // at which time the t1 timer will fire. The t2 and t3
         // timers will repeatedly fire until then.
         Console.WriteLine ("Waiting for t1 to fire, t2 and t3 will fire repeatedly...");
         ev.WaitOne( );
         Console.WriteLine("t1 fired");
         Console.WriteLine("Changing timer t2 to 4 second initial delay with 2 second repeat period.");
         t2.Change(lFc,lPc);
         ev.Reset( );

         try
         {
            // Dispose of t3, and signal ev when done.
            t3.Dispose(ev);
         }
         catch (ApplicationException)
         {
            Console.WriteLine("Caught an informational ApplicationException  t3.Dispose(ev)");
         }
         // Wait until t3 is shut down.
         ev.WaitOne( );

         // Change t3 to call Alpha4 every 1/10 second after 1 second
         // initial delay.
         t3 = new Timer(timer_cb_4,this,1000,100);
         Console.WriteLine("Timer t3 changed to call Alpha4 every 1/10 second after 1 second initial delay.");
         ev.Reset();

         Console.WriteLine("Entering wait for 4 seconds.");
         ev.WaitOne(4000,false);
         Console.WriteLine("4 second wait expired.");
         ev.Reset();

         Console.WriteLine("Now dispose of all timers, including t3, which is still calling Alpha4.");
         ev.Reset();
         ev.WaitOne(2000,false);
         try
         {
            t1.Dispose(ev);
         }
         catch (ApplicationException)
         {
            Console.WriteLine("Caught an informational ApplicationException  t1.Dispose(ev)");
         }
         // Wait till ev is signaled, indicating that t1 is shut down:
         ev.WaitOne( );
         Console.WriteLine ("t1 is shut down.");
         try
         {
            t2.Dispose(ev);
         }
         catch (ApplicationException)
         {
            Console.WriteLine("Caught an informational ApplicationException  t2.Dispose(ev)");
         }
         // Wait till ev is signaled, indicating that t2 is shut down:
         ev.WaitOne( );
         Console.WriteLine ("t2 is shut down.");
         try
         {
            t3.Dispose(ev);
         }
         catch (ApplicationException)
         {
            Console.WriteLine("Caught an informational ApplicationException  t3.Dispose( )");
         }
         // Wait till ev is signaled, indicating that t3 is shut down:
         ev.WaitOne( );
         Console.WriteLine ("t3 is shut down.");
         Console.WriteLine("All timers are deleted");
      }
      Console.WriteLine("#########");
   }

   public static void Main(String[] args)
   {
      Console.WriteLine("TimersSample.cs");
      Console.WriteLine("Run on Build {0}",Environment.Version);
      TimersSample X = new TimersSample( );
      X.test_timer( );
   }
}
