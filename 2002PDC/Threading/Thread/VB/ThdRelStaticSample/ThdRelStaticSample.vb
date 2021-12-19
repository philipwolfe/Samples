' ==========================================================================
' 	File:		ThdRelStaticSample.cs
' 
' 	Summary:	Example shows how to use the attribute [ThreadStatic( )]
' 					to make a static field be a Thread Relative Static.
' 
' 	Note:		If you compile this sample with the "/D:WITHOUT" switch
' 					you will see mainThd.thd1, mainThd.thd2, and mainThd
' 					all changing the same field "E.stat" on each other.
' 
' ----------------------------------------------------------------------------
' 	This file is part of the Microsoft COM+ Runtime Samples.
' 
' 	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
' ===========================================================================
imports System
imports System.Threading

public module ThdRelStaticSample

public class ThdRelStaticSample
	public E1 as E					' 	object E1 will be one instance of class E
	public E2 as E					' 	object E2 will be another instance of class E
	public thd1 as Thread					' 	Thread thd1 will be running on object E1, method Run1
	public thd2 as Thread					' 	Thread thd1 will be running on object E1, method Run2

	public sub New( )
		MyBase.New
		E1 = new E( )
		E2 = new E( )
		thd1 = new Thread(new ThreadStart(AddressOf E1.Run1))
		thd2 = new Thread(new ThreadStart(AddressOf E1.Run2))
		thd1.Start( )
		thd2.Start( )
	end sub

end class	' ThdRelStaticSample

public class E
										' 	"[ThreadStaticAttribute( )]" is an attribute, much like "public" and/or "static"
											' 	In the next few lines, the "[ThreadStaticAttribute( )]" is applied to the
											' 		field E.stat if this code is compiled without the "/D:WITHOUT"
											' 		switch on the CSharp compiler.
#if not WITHOUT
	dim th as ThreadStaticAttribute = new ThreadStaticAttribute( )
#endif
	public shared stat as integer

	public shared startHere as integer = 3
	public shared jumpChange as integer = 2
	public shared loopRun1First as integer = 10000
	public shared loopRun1Second as integer = 20000
	public shared loopRun2First as integer = -5000
	public shared resetRun2First as integer = 1000
	public shared resetRun2Finally as integer = 2001

	public sub New( )
                MyBase.New
		stat = startHere
	end sub

	public sub Run1( )
		while (stat < loopRun1First)
			stat = stat + 1
                end while

		Monitor.Enter(Me)
		try
			Console.Write("   Run1 L1  ")		' 	loopRun1First, Loop One.
			DebugOut( )
		finally
			Monitor.Exit(Me)
		end try

		while(stat < loopRun1Second)
			stat = stat + 1
                end while

		Monitor.Enter(Me)
		try
			Console.Write("   Run1 L2  ")		' 	loopRun1Second, Loop Two.
			DebugOut( )
		finally 
			Monitor.Exit(Me)
		end try
	end sub

	public sub Run2( )
		try
			while (true)
				stat = stat - 1
				if (stat = loopRun2First) then
					Monitor.Enter(Me)
					try
						Console.Write("   Run2     ")
						DebugOut( )
					finally
						Monitor.Exit(Me)
					end try

					stat = resetRun2First
				end if
			end while
		finally
			' Monitor.Enter(this) and Monitor.Exit(this)
				DebugOut( )					' 		as a wrapper around this single statement.

			stat = resetRun2Finally

			Monitor.Enter(Me)
			try
				Console.Write("   Run2 fin ")			' 	Run2 is in the finally block
				DebugOut( )
			finally
				Monitor.Exit(Me)
			end try
		end try
	end sub

	public sub Change( )
		stat = stat + jumpChange
	end sub

	public sub DebugOut( )
		Console.WriteLine("stat = {0}",stat)
	end sub


	public sub Run()
#if not WITHOUT
		Console.WriteLine("Thread Relative Statics Sample  with ""[ThreadStaticAttribute( )]""")
#else
		Console.WriteLine("Thread Relative Statics Sample  WITHOUT ""[ThreadStaticAttribute( )]""")
#endif
		dim mainThd as ThdRelStaticSample = new ThdRelStaticSample( )

		Monitor.Enter (mainThd.E1)					'  	Monitor.Enter on the same object that mainThd.thd1
		try
			Console.Write("mainThd.E1  ")	' 		Console output on
			mainThd.E1.DebugOut( )
		finally
			Monitor.Exit(mainThd.E1)
		end try

		mainThd.E1.Change( )				' 	Adds E.jumpChange to E.stat

		Monitor.Enter (mainThd.E1)					' 	Monitor.Enter on the same object that mainThd.thd1
		try									' 		and mainThd.thd2 using for cooridinating
			Console.Write("mainThd.E2  ")	' 		Console output on
			mainThd.E2.DebugOut( )
		finally
			Monitor.Exit(mainThd.E1)
		end try

		mainThd.E2.Change( )				' 	Adds E.jumpChange to E.stat

		mainThd.thd1.Join( )				' 	Join on mainThd.thd1, no Stop.  Thread to run to completion
		mainThd.thd2.Stop( )				' 	Stop on mainThd.thd2.
		mainThd.thd2.Join( )				' 	Join on mainThd.thd2.  (Now both of these threads are dead)

		Console.Write("mainThd.E1  ")		' 	mainThd.thd1 and mainThd.thd2 are dead, so we
		mainThd.E1.DebugOut( )				' 		don't need to coordinate Console with anyone.
		
		mainThd.E1.Change( )				' 	Adds E.jumpChange to E.stat

		Console.Write("mainThd.E2  ")		' 	mainThd.thd1 and mainThd.thd2 are dead, so we
		mainThd.E2.DebugOut( )				' 		don't need to coordinate Console with anyone.
	end sub

end class	' E

	sub Main()
		dim obj as E = new E()
		
		obj.Run
	end sub

end module	' ThdRelStaticSample

'  Output of TRSS.exe
'
'Thread Relative Statics Sample  WITHOUT "[ThreadStaticAttribute( )]"
'mainThd.E1  stat = 3
'   Run2     stat = -5000
'   Run1 L1  stat = -5000
'   Run2     stat = 20000
'   Run1 L2  stat = -5000
'   Run2     stat = -5000
'   Run2     stat = -5000
'   Run2     stat = -5000
'   Run2     stat = -5000
'mainThd.E2  stat = -4998
'   Run2     stat = -5000
'   Run2 fin stat = 2001
'mainThd.E1  stat = 2001
'mainThd.E2  stat = 2003
'
'  ======================================================================================
'  Output of ThdRelStaticSample.exe
'
'Thread Relative Statics Sample  with "[ThreadStaticAttribute( )]"
'mainThd.E1  stat = 3
'mainThd.E2  stat = 5
'   Run2     stat = -5000
'   Run1 L1  stat = 10000
'   Run2     stat = -5000
'   Run2     stat = -5000
'   Run1 L2  stat = 20000
'   Run2     stat = -5000
'   Run2 fin stat = 2001
'mainThd.E1  stat = 7
'mainThd.E2  stat = 9
