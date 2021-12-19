'	==========================================================
'	Class:    CS_Timers
'	Copyright (c) Microsoft, 1999-2000
'	==========================================================

imports System
imports System.Threading

public module TimerSample

public class ClsAlpha
	private e As ManualResetEvent

	sub new (ev as ManualResetEvent)
                mybase.new
		e = ev
	end sub

	public sub Alpha2(o as Object)
		Console.WriteLine("Alpha2")
	end sub

	public sub Alpha3(o as Object)
		Console.WriteLine("Alpha3")
	end sub

	public sub Alpha4(o as Object)
		Console.WriteLine("Alpha4")
	end sub

	public sub Alpha1(o as Object)
		Console.WriteLine("Alpha1")
		e.Set( )
	end sub
end class	' Alpha

public class TimersSample
'	public TimersSample( )
'	{
'	}

	public sub test_timer( )
		dim ev as ManualResetEvent = new ManualResetEvent(false)
		dim alpha as ClsAlpha = new ClsAlpha(ev)
		dim w2k as boolean = true

		try
			dim testx as Timer = new Timer(new TimerCallback(AddressOf alpha.Alpha1), me, 100, 0)
			testX.Dispose(ev)
		
		catch e as NotSupportedException

			Console.WriteLine("NotSupportedException was caught because: ")
			Console.WriteLine("\tSystem.Timer Not Supported on this system.")
			Console.WriteLine("\tMust be running on Windows 2000, or the COM+ Win32 Support")
			w2k = false
		end try

		if w2k then
			dim vif as integer = 4000
			dim ip as integer = 0
			dim uif as integer = 2000
			dim uip as integer = 1000
			dim lf as long	= 3000L
			dim lp as long	= 500L
			dim lfc as long = 4000L
			dim lpc as long = 2000L

			ev.Reset( )
			Console.WriteLine("Entering wait for 1 second")
			ev.WaitOne(1000,false)
			Console.WriteLine("Time expired")

			dim timer_cb_1 as TimerCallback = new TimerCallback(AddressOf alpha.Alpha1)
			dim timer_cb_2 as TimerCallback = new TimerCallback(AddressOf alpha.Alpha2)
			dim timer_cb_3 as TimerCallback = new TimerCallback(AddressOf alpha.Alpha3)
			dim timer_cb_4 as TimerCallback	= new TimerCallback(AddressOf alpha.Alpha4)
			dim t1 as Timer = new Timer(timer_cb_1, me,viF,iP)
			dim t2 as Timer = new Timer(timer_cb_2, me, uiF, uiP)
			dim t3 as Timer = new Timer(timer_cb_3, me,lF,lP)

			ev.WaitOne( )
			Console.WriteLine("t1 fired")
			t2.Change(lFc,lPc)
			ev.Reset( )

			dim flag as boolean

			try
				flag = t3.Dispose(ev)
			catch e as ApplicationException
				Console.WriteLine("Caught an informational ApplicationException  t3.Dispose(ev)")
			end try

			ev.WaitOne( )
			t3	= new Timer(timer_cb_4, me, 1000, 100)
			t2.Change( uiF, uiP)
			ev.Reset()
			Console.WriteLine("Entering wait for 3 seconds")
			ev.WaitOne(3000,false)
			t2.Change(viF,iP)
			ev.Reset()
			Console.WriteLine("Entering wait for 3 seconds, again")
			ev.WaitOne(3000,false)
			Console.WriteLine("time expired")

			try
				t1.Dispose(ev)
			catch e as ApplicationException
				Console.WriteLine("Caught an informational ApplicationException  t1.Dispose(ev)")
			end try

			try
				t2.Dispose(ev)
			catch e as ApplicationException
				Console.WriteLine("Caught an informational ApplicationException  t2.Dispose(ev)")
			end try

			try
				t3.Dispose( )
			catch e as ApplicationException
				Console.WriteLine("Caught an informational ApplicationException  t3.Dispose( )")
			end try

			ev.WaitOne( )
			Console.WriteLine("Timers are deleted")
		end if

		Console.WriteLine("#########")
	end sub
end class	' TimerSample

	sub Main()
		Console.WriteLine("TimersSample.cs")
		Console.WriteLine("Run on Build {0}",Environment.Version)
		dim x as TimersSample = new TimersSample( )
		X.test_timer( )
	end sub


End module	' TimerSample
