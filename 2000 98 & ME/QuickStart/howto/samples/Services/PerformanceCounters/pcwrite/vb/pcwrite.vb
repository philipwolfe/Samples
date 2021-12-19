Imports System
Imports System.Diagnostics
Imports System.Threading

public class PCWrite
	public shared sub Main()
		Dim appName As string = Environment.GetCommandLineArgs()(0)

		if(Environment.GetCommandLineArgs().Length <> 4) then
			Console.WriteLine("Usage: " + appName + " <object> <counter> <instance>")
			exit sub
		end if

		Dim objectName As String = Environment.GetCommandLineArgs()(1)
		Dim counterName As String = Environment.GetCommandLineArgs()(2)
		Dim instanceName As String = Environment.GetCommandLineArgs()(3)

		Dim trim(1) As Char
		trim(0) = " "c
		objectName = objectName.TrimEnd(trim)
		counterName = counterName.TrimEnd(trim)
		instanceName = instanceName.TrimEnd(trim)

		if(not PerformanceCounter.CategoryExists(objectName)) then
			PerformanceCounterCategory.Create(objectName,"Simple Counter Object",counterName,"Simple Counter")
		end if

		if(not PerformanceCounter.Exists(objectName,counterName)) then
			Console.WriteLine("The counter does not exists!")
			exit sub
		end if

		Dim aCounter As PerformanceCounter = new PerformanceCounter(objectName, counterName ,instanceName)
		aCounter.RawValue = 50

		Console.WriteLine("Press 'q' to quit the sample")	
		Console.WriteLine("Press '+' to increment the counter")
		Console.WriteLine("Press '-' to decrement the counter")

		Console.WriteLine("Started")
		Dim command as Integer
		Do
			command = Console.Read()
			if(command=45) then 
				aCounter.IncrementBy(-5)
			end if
			if(command=43) then 
				aCounter.IncrementBy(5)
			end if
		loop until command=113
	end sub
end class
