imports System
imports System.Threading

public module SyncTwo

public class Gamma
end class	' Gamma

public class Alpha
	public oGamma as Gamma

	public sub Beta( )
		' 	Obtain the lock
		Monitor.Enter(oGamma)

		dim cLoop as integer = 10
		while (cLoop > 0)
			Console.Write(" Hello")

			'	Release the lock and wait to be Notified
			Monitor.Wait(oGamma)

			'	Signal for next thread in wait queue to proceed
			Monitor.Pulse(oGamma)
			cLoop = cLoop - 1
		end while

		'	Release the lock
		Monitor.Exit(oGamma)
	end sub
end class	' Alpha

public class Delta
	public oGamma as Gamma

	public sub New(G as Gamma)
		MyBase.New
		oGamma = G
	end sub

	public sub Beta( )
		'	Obtain the lock
		Monitor.Enter(oGamma)

		dim cLoop as integer = 10
		while (cLoop > 0)
			Console.WriteLine(" World")
			'	Signal for next thread in wait queue to proceed
			Monitor.Pulse(oGamma)

			'	Release the lock and wait to be Notified
			Monitor.Wait(oGamma)

			cLoop = cLoop -1
		end while

		'	Release the lock
		Monitor.Exit(oGamma)
	end sub
end class	' Delta

	public sub Main()
		Console.WriteLine("Thread Sync Two Sample")

		dim oGamma as Gamma = new Gamma( )

		dim oAlpha as Alpha = new Alpha( )
		oAlpha.oGamma = oGamma

		'	Create the 1st thread object, passing in the oAlphaBeta method
		'	via a ThreadStart delegate
		dim Thread1 as Thread = new Thread(new ThreadStart(AddressOf oAlpha.Beta) )

		'	Start the 1st thread
		Thread1.Start( )
		while ( not Thread1.IsAlive)
		end while 

		dim oDelta as Delta = new Delta(oGamma)

		'	Create the 2nd thread object, passing in the oDelta.Beta method
		'	via a ThreadStart delegate, on the new oDelta instance
		dim Thread2 as Thread = new Thread(new ThreadStart(Addressof oDelta.Beta) )

		'	Start the 2nd thread
		Thread2.Start( )

	end sub

end module	' SyncTwo
