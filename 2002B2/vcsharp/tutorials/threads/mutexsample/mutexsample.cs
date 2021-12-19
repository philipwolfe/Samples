// Threads\MutexSample.cs
using System;
using System.Threading;

public class MutexSample
{
   static Mutex gM1;
   static Mutex gM2;
   const int ITERS = 100;
   static AutoResetEvent Event1 = new AutoResetEvent(false);
   static AutoResetEvent Event2 = new AutoResetEvent(false);
   static AutoResetEvent Event3 = new AutoResetEvent(false);
   static AutoResetEvent Event4 = new AutoResetEvent(false);
   
   public static void Main(String[] args)
   {
      Console.WriteLine("Mutex Sample ...");
      // Create Mutex initialOwned, with name of "MyMutex".
      gM1 = new Mutex(true,"MyMutex");
      // Create Mutex initialOwned, with no name.
      gM2 = new Mutex(true);
      Console.WriteLine(" - Main Owns gM1 and gM2");

      AutoResetEvent[] evs = new AutoResetEvent[4];
      evs[0] = Event1;    // Event for t1
      evs[1] = Event2;    // Event for t2
      evs[2] = Event3;    // Event for t3
      evs[3] = Event4;    // Event for t4

      MutexSample tm = new MutexSample( );
      Thread t1 = new Thread(new ThreadStart(tm.t1Start));
      Thread t2 = new Thread(new ThreadStart(tm.t2Start));
      Thread t3 = new Thread(new ThreadStart(tm.t3Start));
      Thread t4 = new Thread(new ThreadStart(tm.t4Start));
      t1.Start( );   // Does Mutex.WaitAll(Mutex[] of gM1 and gM2)
      t2.Start( );   // Does Mutex.WaitOne(Mutex gM1)
      t3.Start( );   // Does Mutex.WaitAny(Mutex[] of gM1 and gM2)
      t4.Start( );   // Does Mutex.WaitOne(Mutex gM2)

      Thread.Sleep(2000);
      Console.WriteLine(" - Main releases gM1");
      gM1.ReleaseMutex( );  // t2 and t3 will end and signal

      Thread.Sleep(1000);
      Console.WriteLine(" - Main releases gM2");
      gM2.ReleaseMutex( );  // t1 and t4 will end and signal

      // Waiting until all four threads signal that they are done.
      WaitHandle.WaitAll(evs); 
      Console.WriteLine("... Mutex Sample");
   }

   public void t1Start( )
   {
      Console.WriteLine("t1Start started,  Mutex.WaitAll(Mutex[])");
      Mutex[] gMs = new Mutex[2];
      gMs[0] = gM1;  // Create and load an array of Mutex for WaitAll call
      gMs[1] = gM2;
      Mutex.WaitAll(gMs);  // Waits until both gM1 and gM2 are released
      Thread.Sleep(2000);
      Console.WriteLine("t1Start finished, Mutex.WaitAll(Mutex[]) satisfied");
      Event1.Set( );      // AutoResetEvent.Set() flagging method is done
   }

   public void t2Start( )
   {
      Console.WriteLine("t2Start started,  gM1.WaitOne( )");
      gM1.WaitOne( );    // Waits until Mutex gM1 is released
      Console.WriteLine("t2Start finished, gM1.WaitOne( ) satisfied");
      Event2.Set( );     // AutoResetEvent.Set() flagging method is done
   }

   public void t3Start( )
   {
      Console.WriteLine("t3Start started,  Mutex.WaitAny(Mutex[])");
      Mutex[] gMs = new Mutex[2];
      gMs[0] = gM1;  // Create and load an array of Mutex for WaitAny call
      gMs[1] = gM2;
      Mutex.WaitAny(gMs);  // Waits until either Mutex is released
      Console.WriteLine("t3Start finished, Mutex.WaitAny(Mutex[])");
      Event3.Set( );       // AutoResetEvent.Set() flagging method is done
   }

   public void t4Start( )
   {
      Console.WriteLine("t4Start started,  gM2.WaitOne( )");
      gM2.WaitOne( );   // Waits until Mutex gM2 is released
      Console.WriteLine("t4Start finished, gM2.WaitOne( )");
      Event4.Set( );    // AutoResetEvent.Set() flagging method is done
   }
}
