using System;
using System.Diagnostics;
using System.Timers;
using System.Threading;

public class PCDemo{

	static PerformanceCounter theCounter;

	public static void Main(string[] args){

		string objectName   = "ACounterDemo";
		string counterName  = "CountPerSecond";
		string instanceName = "_Total";

		if(!PerformanceCounter.CategoryExists(objectName))
		{
			CounterCreationData ccd = new CounterCreationData();
			ccd.CounterName = counterName;
			ccd.CounterType = PerformanceCounterType.RateOfChangePerSecond32;
			CounterCreationData[] ccds = new CounterCreationData[1];
			ccds[0] = ccd;

			PerformanceCounterCategory.Create(objectName,"Sample Object",ccds);
		}
		
		theCounter = new PerformanceCounter(objectName, counterName ,instanceName);

		System.Timers.Timer aTimer = new System.Timers.Timer();
		aTimer.Tick += new EventHandler(OnTimer);

		aTimer.Interval  = 100;
		aTimer.Enabled   = true;
		aTimer.AutoReset = false;
		
		Console.WriteLine("Press \'+\' to increase the interval");
		Console.WriteLine("Press \'-\' to decrease the interval");
		Console.WriteLine("Press \'q\' to quit the sample");
		Console.WriteLine("Started");

		int command;
		do
		{
			command = Console.Read();
			if(command=='+')
				aTimer.Interval = Math.Max(1,aTimer.Interval/2);
			if(command=='-')
				aTimer.Interval *= 2;


			Thread.Sleep(500);
		}
		while(command!='q');
		PerformanceCounter.DeleteCategory(objectName);
	}

	public static void OnTimer(Object source, EventArgs e)
	{
		theCounter.IncrementBy(1);
		System.Timers.Timer theTimer = (System.Timers.Timer)source;
		theTimer.Enabled = true;
	}
}