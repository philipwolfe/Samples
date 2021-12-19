using System;
using System.Diagnostics;
using System.Threading;

public class PCWrite{

	public static void Main(string[] args){

		string appName = Environment.GetCommandLineArgs()[0];

		if(args.Length != 3)
		{
			Console.WriteLine("Usage: " + appName + " <object> <counter> <instance>");
			return;
		}

		string objectName	= args[0];
		string counterName	= args[1];
		string instanceName = args[2];

		if(!PerformanceCounter.CategoryExists(objectName))
		{
			PerformanceCounterCategory.Create(objectName,"Simple Counter Object",counterName,"Simple Counter");
		}

		Console.WriteLine("Category Exists");

		Thread.Sleep(30000);
		if(!PerformanceCounter.Exists(objectName,counterName))
		{
			Console.WriteLine("The counter does not exists!");
			return;
		}

		Console.WriteLine("Counter Exists");

		PerformanceCounter aCounter = new PerformanceCounter(objectName, counterName ,instanceName);
		aCounter.RawValue = 50;

		Console.WriteLine("Press \'q\' to quit the sample");   
		Console.WriteLine("Press \'+\' to increment the counter");
		Console.WriteLine("Press \'-\' to decrement the counter");

		Console.WriteLine("Started");
		int command;
		do
		{
			command = Console.Read();
			if(command=='-') aCounter.IncrementBy(-5);
			if(command=='+') aCounter.IncrementBy(5);

			Thread.Sleep(500);
		}
		while(command!='q');
	}
}