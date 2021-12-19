'==========================================================================
'	File:		Monitor.cs
'
'	Summary:	Example shows use of Monitor in threads.
'					Monitor.Enter(Object)
'					Monitor.Exit(Object)
'					Monitor.Pulse(Object)
'					Monitor.Wait(Object)
'
'----------------------------------------------------------------------------
'	This file is part of the Microsoft COM+ Runtime Samples.
'
'	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
'===========================================================================
imports System 
imports System.Threading 

public module MonitorSample
	Sub Main()
		dim result As Integer = 0 		'	result initialized to say there is no error
		Dim cell As ClsCell = new ClsCell( ) 

		Dim prod As CellProd = new CellProd(cell,20) 	'	use cell for storage, produce 20 items
		Dim cons As CellCons = new CellCons(cell,20) 	'	use cell for storage, consume 20 items

		Dim producer As Thread = new Thread(new ThreadStart(AddressOf prod.ThreadRun)) 
		Dim consumer As Thread = new Thread(new ThreadStart(AddressOf cons.ThreadRun)) 
		'	threads producer and consumer have been created, but not started at this point.

		try
			producer.Start( ) 
			consumer.Start( ) 

			producer.Join( ) 		'	Join with no Stop.  Run producer thread until it is done.
			consumer.Join( ) 		'	Join with no Stop.  Run consumer thread until it is done.
		'	threads producer and consumer are dead at this point.
		catch e As ThreadStateException
			Console.WriteLine(e) 			'	display text of exception
			result = 1 						'	result says there was an error
		catch e As ThreadInterruptedException
			Console.WriteLine(e) 			'	display text of exception
			result = 1 						'	result says there was an error
		end try

		Environment.ExitCode = result 		'	eventhough Main with a return type of void, this sets
	end sub										'		a return code to parent process.


public class CellProd
	Dim cell As Clscell 							'	Field to hold cell object to be used
	Dim quantity As Integer = 1 				'	Field for "How many items to produce in cell?"

	public Sub New(box As ClsCell, request As Integer)
                MyBase.New
		cell = box 							'	Pass in what cell object to be used
		quantity = request 					'	Pass in "How many items to produce in cell?"
	end sub

	public sub ThreadRun( )
                dim looper As Integer

		for looper = 1 To quantity
			cell.WriteToCell(looper) 		'	"producing"
                next
	end sub
end class '	End of public class CellProd

public class CellCons
	dim cell as Clscell 							'	Field to hold cell object to be used
	dim quantity as integer	= 1 				'	Field for "How many items to consume from cell?"

	public sub New(box as clsCell, request as integer)
                MyBase.New
		cell = box 							'	Pass in what cell object to be used
		quantity = request 					'	Pass in "How many items to consume from cell?"
	end sub

	public sub ThreadRun( )
		dim valReturned as integer
                dim looper as integer

		for looper = 1 To quantity
			valReturned=cell.ReadFromCell( ) 	'	if you wanted to "consume" the result, see valReturned
		next
	end sub
end class	'	End of public class CellCons


public class ClsCell
	dim cellContents as integer				'	Cell Contentents
	dim readerFlag As boolean = false 	'	State Flag

	public Function ReadFromCell( ) as integer
		Monitor.Enter(Me) 			'	Enter Synchronization block
		if not readerFlag then
			try
				Monitor.Wait(Me) 		'	Waits until it gets a Monitor.Pulse(this)
			catch e As SynchronizationLockException
				Console.WriteLine(e) 
			catch e As ThreadInterruptedException
				Console.WriteLine(e) 
			end try
		end if
		Console.WriteLine("Consume: {0}",cellContents) 
		readerFlag = false 			'	Reset the State Flag to say, done
		Monitor.Pulse(Me) 		'	Pulse tells Cell.WriteToCell that Cell.ReadFromCell is done.
		Monitor.Exit(Me) 			'	Exit Synchronization block
		ReadFromCell = cellContents 
	end function	'	End of method public int ReadFromCell( )
	
	public sub WriteToCell(n as integer)
		Monitor.Enter(Me) 			'	Enter Synchronization block
		if readerFlag then
			try
				Monitor.Wait(Me) 		'	Waits until it gets a Monitor.Pulse(this)
			catch e As SynchronizationLockException
				Console.WriteLine(e) 
			catch e As ThreadInterruptedException
				Console.WriteLine(e) 
			end try
		end if
		cellContents = n 
		Console.WriteLine("Produce: {0}",cellContents) 
		readerFlag = true 			'	Reset the State Flag to say, done
		Monitor.Pulse(Me) 		'	Pulse tells Cell.ReadFromCell that Cell.WriteToCell is done.
		Monitor.Exit(Me) 			'	Exit Synchronization block
	end sub	'	End of method public void WriteToCell(int value)
end class '	End of public class Cell

end module	' MonitorSample


'Output

'Produce: 1
'Consume: 1
'Produce: 2
'Consume: 2
'Produce: 3
'Consume: 3
'Produce: 4
'Consume: 4
'Produce: 5
'Consume: 5
'Produce: 6
'Consume: 6
'Produce: 7
'Consume: 7
'Produce: 8
'Consume: 8
'Produce: 9
'Consume: 9
'Produce: 10
'Consume: 10
'Produce: 11
'Consume: 11
'Produce: 12
'Consume: 12
'Produce: 13
'Consume: 13
'Produce: 14
'Consume: 14
'Produce: 15
'Consume: 15
'Produce: 16
'Consume: 16
'Produce: 17
'Consume: 17
'Produce: 18
'Consume: 18
'Produce: 19
'Consume: 19
'Produce: 20
'Consume: 20

