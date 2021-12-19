using System;
using System.Diagnostics;
using System.Threading;
	
public class LogMonitor
{
       	public static void Main(String[] args) 
	{
		string appName = Environment.GetCommandLineArgs()[0];

		if(args.Length != 1 && args.Length != 2)
		{
			Console.WriteLine("Usage: " + appName + " <log> [<machine>]");
			return;
		}
		string log = args[0];
		string machine;
		if(args.Length == 2)
		{
			machine= args[1];
		}
		else
		{
			machine = "."; // local machine
		}
				
		if(!EventLog.Exists(log,machine))
		{
			Console.WriteLine("The log does not exist!");
			return;
		}
	
		EventLog aLog = new EventLog();
		aLog.Log = log;
		aLog.MachineName = machine;
		
		aLog.EntryWritten += new EventLogEventHandler(OnEntryWritten);
		aLog.Monitoring = true;
        
		Console.WriteLine("Press \'q\' to quit the sample");	
		while(Console.Read()!='q')
		{
			Thread.Sleep(500);	
		}
       	}

	public static void OnEntryWritten(Object source, EventLogEvent e)
	{
		Console.WriteLine("Written: " + e.Entry.Message);
	}
}