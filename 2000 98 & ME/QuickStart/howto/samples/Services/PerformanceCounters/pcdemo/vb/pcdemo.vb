Imports System
Imports System.Diagnostics
Imports System.Timers
Imports System.Threading

Public class PCDemo

	shared theCounter as PerformanceCounter

	public shared sub Main()
		Dim objectName As String = "ACounterDemo"
		Dim counterName As String = "CountPerSecond"
		Dim instanceName As String = "_Total"
		
		if(not PerformanceCounter.CategoryExists(objectName)) then
			Dim ccd As CounterCreationData = new CounterCreationData()
			ccd.CounterName = counterName
			ccd.CounterType = PerformanceCounterType.RateOfChangePerSecond32
			Dim ccds(1) As CounterCreationData
			ccds(0) = ccd

			PerformanceCounterCategory.Create(objectName,"Sample Object",ccds)
		end if
		
		theCounter = new PerformanceCounter(objectName, counterName ,instanceName)

		Dim aTimer As new System.Timers.Timer
		AddHandler aTimer.Tick, AddressOf OnTimer

		aTimer.Interval = 100
		aTimer.Enabled = true
		aTimer.AutoReset = false

		Console.WriteLine("Press '+' to increase the interval")
		Console.WriteLine("Press '-' to decrease the interval")
		Console.WriteLine("Press 'q' to quit the sample")
		Console.WriteLine("Started")
		
		Dim command As Integer
		do
			command = Console.Read()
			if(command=43) then			' + = ASCII 43
				aTimer.Interval = Math.Max(1,aTimer.Interval/2)
			elseif(command=45) then		' - = ASCII 45
				aTimer.Interval *= 2
			end if

		loop until command=113
		
		PerformanceCounter.DeleteCategory(objectName)	  
	end sub
	
	public shared sub OnTimer(source as Object, e As EventArgs)
		theCounter.IncrementBy(1)
		Dim theTimer As System.Timers.Timer = CType(source,System.Timers.Timer)
		theTimer.Enabled = true
	end sub
end class