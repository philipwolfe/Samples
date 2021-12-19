imports System
imports System.Threading

option strict off

public module StopJoin

public class Alpha

	'	The method that will be called when the thread is started
	public sub Beta()
		while true
			Console.WriteLine("Alpha.Beta is running in its own thread.")
			Thread.Sleep(0)
		end while
	end sub
end class	' Alpha

	public sub Main()
		Console.WriteLine("Thread Stop Join Sample")
		
		dim oAlpha as Alpha = new Alpha()

		'	Create the thread object, passing in the Alpha.Beta method
		'	via a ThreadStart delegate
		dim oThread1 as Thread	= new Thread(new ThreadStart(AddressOf oAlpha.Beta))

		'	Start the thread
		oThread1.Start()

		'	Spin waiting for the started thread to become alive
		while (oThread1.ThreadState = ThreadState.Unstarted)
		end while
		
		'	Sleep. Allow oThread1 to do some work.
		Thread.Sleep(100)
		
		'	Request that oThread1 be stopped
		oThread1.Stop()
		
		'	Wait for the oThread1 to finish
		oThread1.Join()
		
		Console.WriteLine()
		Console.WriteLine("Alpha.Beta has finished")
		
		try 
			Console.WriteLine("Try to restart the Alpha.Beta thread")
			oThread1.Start()
		catch e as ThreadStateException
			Console.Write("Cannot restart Alpha.Beta.  ")
			Console.WriteLine("Expected since stopped threads cannot be restarted.")
		end try
	end sub

end module	' StopJoin
