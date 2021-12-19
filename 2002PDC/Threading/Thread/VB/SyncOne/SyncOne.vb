imports System
imports System.Threading

public module SyncOne

public class Alpha

	' The method that will be called when the thread is started
	public sub Beta()
		dim iThreadID as integer = Thread.CurrentThread.GetHashCode( )
		dim cLoop as integer = 100

		while ( cLoop > 0)
			' Obtain the lock
			Monitor.Enter(Me)
			Console.Write("{0} Thread, ",Thread.CurrentThread.Name)
			Console.WriteLine("Hash: {0}, Hello!",iThreadID)
			' Release the lock
			Monitor.Exit(Me)

                        cLoop = cLoop - 1
		end while
	end sub
end class	' Alpha

	public sub Main()
		Console.WriteLine("Thread Sync One Sample")

		dim oAlpha as Alpha = new Alpha( )

		' Create the 1st thread object, passing in the Alpha.Beta method
		' via a ThreadStart delegate
		dim oThread1 as Thread	= new Thread(new ThreadStart(AddressOf oAlpha.Beta))
		oThread1.Name = "Yellow"

		' Start the 1st thread
		oThread1.Start( )

		' Spin waiting for the started thread to become alive
		while (oThread1.IsAlive <> True)   
		end while

		' Create the 2nd thread object, passing in the Alpha.Beta method
		' via a ThreadStart delegate, on the same oAlpha instance
		dim oThread2 as Thread	= new Thread(new ThreadStart(AddressOf oAlpha.Beta) )
		oThread2.Name = " Green"

		' Start the 2nd thread
		oThread2.Start( )

		' Spin waiting for the started thread to Start
		while (oThread2.ThreadState = ThreadState.Unstarted)  
		end while
	end sub

end module	' SyncOne
