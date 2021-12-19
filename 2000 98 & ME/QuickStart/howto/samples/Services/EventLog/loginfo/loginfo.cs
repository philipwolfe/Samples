using System;
using System.Diagnostics;
	
public class LogInfo
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
		
		Console.WriteLine("There are " + aLog.Entries.Count + " entr[y|ies] in the log:");  
		foreach (EventLogEntry entry in aLog.Entries) 
		{
			Console.WriteLine("\tEntry: " + entry.Message);
		}

       	}
}

