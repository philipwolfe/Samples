' ============================================================
'
'	Class:		SimplePool
'
'	Purpose:	Simple Thread Pool Sample
'
'	Copyright (c) Microsoft, 1999-2000
'
' ============================================================

imports System
imports System.Threading

option strict off

public module SimplePool


public class SomeState
	public Cookie as integer

	public sub New (iCookie as integer)
                Mybase.New
		Cookie = iCookie
	end sub
end class	' Somestate

public class Alpha
	public HashCount() as integer
	public eventX As ManualResetEvent		
	public shared iCount As integer = 0
	public shared iMaxCount as integer = 0

	public Sub New(MaxCount as integer) 
                mybase.new
		redim HashCount(30)
		iMaxCount = MaxCount
	end sub

	' 	The method that will be called when the Work Item is serviced
	' 	on the Thread Pool
	public sub Beta(state as Object)
		Console.WriteLine(" {0} {1} :", Thread.CurrentThread.GetHashCode(), state.Cookie)
		Interlocked.Increment(HashCount(Thread.CurrentThread.GetHashCode()))

		' 	Do some busy work
		Dim ix as integer = 10000
		while (iX > 0)
			iX = ix - 1
		end while

		Interlocked.Increment(iCount)
		if iCount = iMaxCount then
			Console.WriteLine("")
			Console.WriteLine("Setting EventX ")
			eventX.Set()
		end if

	end sub
end class	' Alpha

	Sub Main()
		Console.WriteLine("Thread Simple Thread Pool Sample")

		dim w2k As boolean = false
		dim MaxCount As integer = 1000
		dim eventX As ManualResetEvent = new ManualResetEvent(false)
                dim iItem As integer
                dim iIndex As integer

		Console.WriteLine("Queuing {0} items to Thread Pool", MaxCount)
		dim oAlpha As Alpha = new Alpha(MaxCount)
		oAlpha.eventX = eventX
		Console.WriteLine("Queue to Thread Pool 0")

		try
			ThreadPool.QueueUserWorkItem(new WaitCallback(AddressOf oAlpha.Beta),  new SomeState(0))
			W2K = true
		catch e As NotSupportedException
			Console.WriteLine("These API's may fail when called on a non-Windows 2000 system.")
		end try

		if (W2K) then
			for iItem = 1 To MaxCount
				Console.WriteLine("Queue to Thread Pool {0}", iItem)
				ThreadPool.QueueUserWorkItem(new WaitCallback( AddressOf oAlpha.Beta),new SomeState(iItem))
			next

			Console.WriteLine("Waiting for Thread Pool to drain")
			eventX.WaitOne(Timeout.Infinite,true)
			Console.WriteLine("Thread Pool has been drained (Event fired)")
			Console.WriteLine("")
			Console.WriteLine("Load across threads")

			for iIndex = 0 to oAlpha.HashCount.Length - 1
				Console.WriteLine("{0} {1}", iIndex, oAlpha.HashCount(iIndex))
                        next
		end if
	end sub


End module ' SimplePool
