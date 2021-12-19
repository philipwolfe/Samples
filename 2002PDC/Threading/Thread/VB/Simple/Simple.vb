imports System
imports System.Threading

public module Simple

public class Alpha 


	' 	The method that will be called when the thread is started
	public sub Beta()
		Console.WriteLine("Alpha.Beta is running in its own thread.")
	end sub

end class	' Alpha

	public sub Main()
		Console.WriteLine("Thread Simple Sample")
		dim oAlpha as Alpha = new Alpha()

		'	Create the thread object, passing in the Alpha.Beta method
		'	via a ThreadStart delegate
		dim oThread as Thread = new Thread(new ThreadStart(AddressOf oAlpha.Beta))

		'	Start the thread
		oThread.Start()

	end sub


end module	' Simple
