// Threads\SpinLock.cs
// Compile with "csc /target:library SpinLock.cs"
using System;
using System.Threading;

public class SpinLock 
{
   private static int UNINIT = -1;            // State, uninitialized
   private static int UNLOCKED = 0;
   private static int LOCKED = 1;
   private static long BACKOFF_LIMIT = 100;  // Used in SpinToAcquire
   private static int BACKOFF_SLEEP = 100;   // Used in SpinToAcquire
   private static int LOOPETTES = 10000;     // Used in SpinToAcquire
   private static int theLock = UNINIT;
   private string _Name = null;
   private bool myLock;

   public void ToggleLock (Object o) {
      if (myLock) {
         FreeLock();
         myLock = false;
      } else {
         GetLock();
         myLock = true;
      }
   }
      

   // Force the programmer to use the constructor overload.
   private SpinLock () {}

   // Initialize theLock if it is uninitialized.
   public SpinLock(string _name ) 

   {         // Don't change state if it already locked or unlocked.
      Interlocked.CompareExchange(ref theLock,UNLOCKED,UNINIT);
      _Name = _name;
      myLock = false;
   }

   public void GetLock( )   // Acquire theLock, Blocks if unsuccessful
   {
      Console.WriteLine ("SpinLock {0} attempting to get lock", _Name);
      // If you can't get theLock on the first try, "Spin" until you get theLock.
      if (!GetLockNoWait( )) 
      { 
         Console.WriteLine ("{0} spinning to get lock", _Name);
         SpinToAcquire( );
      }
      Console.WriteLine ("!!{0} acquired lock", _Name);
   }

   public void FreeLock( )  // Release theLock
   {
      Console.WriteLine ("{0} freeing lock", _Name);
      lock(this) {theLock = UNLOCKED;}
   }

   public bool IsUnlocked( ) // Report the state of theLock
   // Return true if not locked, false if it is locked
   {
      bool retval = false;
      lock(this) {retval = (theLock==UNLOCKED);}
      return retval;
   }

   // Attempt to acquire theLock, fail immediately if can't get lock.
   public bool GetLockNoWait( )
   {   // Return true if acquired, false if not acquired.
      return (Interlocked.Exchange(ref theLock,LOCKED)==UNLOCKED);
   }

   private void SpinToAcquire( )
   {
      long backoff = 0;  // Used in computing length of 
                         // Thread.Sleep to call.
      // Until we get theLock, we just keep doing the "Spin" here.
      while(true)
      {
         for(int loop=0; loop<LOOPETTES; loop++)
            // If IsUnlocked( ) reports true anytime in this loop,
            // break out of the for loop:
            if(IsUnlocked( ))
               break;

         // If GetLockNoWait() reports true, break out of the while(true) loop:
         if(GetLockNoWait( ))
            break;

         backoff++;
         // If backoff is divisible by BACKOFF_LIMIT then "Back Off" and 
         // sleep for half a BACKOFF_SLEEP milliseconds,
         // else yield the rest of your timeslice, you'll still be in 
         // this loop when you get your next timeslice, and can 
         // do the "Spin".
         if((backoff%BACKOFF_LIMIT)==0)
            Thread.Sleep(BACKOFF_SLEEP);
         else
            Thread.Sleep(1);
      }   // Loop again. The Sleep(1) is used to give 
          // even the lower priority threads in the
          // process a chance at CPU timeslices.
   }
}
