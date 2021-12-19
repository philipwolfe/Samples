' ==========================================================================
' 	File:		MutexSample.cs
' 
' 	Summary:	Example shows use of Mutex, AutoResetEvent and WaitHandle,
' 						in threads.
' 					Mutex.Mutex(bool,String)
' 					Mutex.Mutex(bool)
' 					Mutex.ReleaseMutex( )
' 					Mutex.WaitAll(WaitHandle[])
' 					Mutex.WaitAny(WaitHandle[])
' 					Mutex.WaitOne(WaitHandle)
' 					AutoResetEvent.AutoResetEvent(bool)
' 					AutoResetEvent.Set( )
' 					WaitHandle.WaitAll(WaitHandle[])
' 
' ----------------------------------------------------------------------------
' 	This file is part of the Microsoft COM+ Runtime Samples.
' 
' 	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
' ===========================================================================
imports System
imports System.Threading

public module MutexSample

public class MutexSample
	shared gM1 as Mutex
	shared gM2 as Mutex

	const ITERS as integer = 100

	shared Event1 as AutoResetEvent	= new AutoResetEvent(false)
	shared Event2 as AutoResetEvent	= new AutoResetEvent(false)
	shared Event3 as AutoResetEvent	= new AutoResetEvent(false)
	shared Event4 as AutoResetEvent	= new AutoResetEvent(false)
	

	public sub t1Start( )
		Console.WriteLine("t1Start started,  Mutex.WaitAll(Mutex())")
		dim gMs(2) as Mutex

		gMs(0) = gM1				' 	Create and load an array of Mutex for WaitAll call
		gMs(1) = gM2

		Mutex.WaitAll(gMs)			' 	Waits until both Mutex are released
		Thread.Sleep(2000)
		Console.WriteLine("t1Start finished, Mutex.WaitAll(Mutex())")
		Event1.Set( )				' 	AutoResetEvent.Set( )	flagging method is done
	end sub

	public sub t2Start( )
		Console.WriteLine("t2Start started,  gM1.WaitOne( )")
		gM1.WaitOne( )				' 	Waits until Mutex gM1 is released
		Console.WriteLine("t2Start finished, gM1.WaitOne( )")
		Event2.Set( )				' 	AutoResetEvent.Set( )	flagging method is done
	end sub

	public sub  t3Start( )
	
		Console.WriteLine("t3Start started,  Mutex.WaitAny(Mutex())")
		dim gMs(2) as Mutex
		gMs(0) = gM1				' 	Create and load an array of Mutex for WaitAny call
		gMs(1) = gM2
		Mutex.WaitAny(gMs)			' 	Waits until either Mutex is released
		Console.WriteLine("t3Start finished, Mutex.WaitAny(Mutex())")
		Event3.Set( )				' 	AutoResetEvent.Set( )	flagging method is done
	end sub

	public sub t4Start( )
		Console.WriteLine("t4Start started,  gM2.WaitOne( )")
		gM2.WaitOne( )				' 	Waits until Mutex gM2 is released
		Console.WriteLine("t4Start finished, gM2.WaitOne( )")
		Event4.Set( )				' 	AutoResetEvent.Set( )	flagging method is done
	end sub

	public sub Run()
		Console.WriteLine("MutexSample.cs ...")
		gM1 = new Mutex(true,"MyMutex")			' 	create Mutext initialOwned, with name of "MyMutex"
		gM2 = new Mutex(true)						' 	create Mutext initialOwned, with no name.
		Console.WriteLine(" - Main Owns gM1 and gM2")

		dim evs(4) As AutoResetEvent
		evs(0) = Event1			' 	Event for t1
		evs(1) = Event2			' 	Event for t2
		evs(2) = Event3			' 	Event for t3
		evs(3) = Event4			' 	Event for t4

		dim tm as MutexSample = new MutexSample( )
		dim t1 as Thread = new Thread(new ThreadStart(AddressOf tm.t1Start))
		dim t2 as Thread = new Thread(new ThreadStart(AddressOf tm.t2Start))
		dim t3 as Thread = new Thread(new ThreadStart(AddressOf tm.t3Start))
		dim t4 as Thread = new Thread(new ThreadStart(AddressOf tm.t4Start))

		t1.Start( )				' 	Does Mutex.WaitAll(Mutex[] of gM1 and gM2)
		t2.Start( )				' 	Does Mutex.WaitOne(Mutex gM1)
		t3.Start( )				' 	Does Mutex.WaitAny(Mutex[] of gM1 and gM2)
		t4.Start( )				' 	Does Mutex.WaitOne(Mutex gM2)

		Thread.Sleep(2000)
		Console.WriteLine(" - Main releases gM1")
		gM1.ReleaseMutex( )		' 	t2 and t3 will end and signal

		Thread.Sleep(1000)
		Console.WriteLine(" - Main releases gM2")
		gM2.ReleaseMutex( )		' 	t1 and t4 will end and signal

		WaitHandle.WaitAll(evs)	' 	waiting until all four threads signal that tey are done.
		Console.WriteLine("... MutexSample.cs")
	end sub

end class	' MutexSample

	sub main()
		dim ms as MutexSample = new MutexSample

		ms.Run
	end sub

end module	' MutexSample
