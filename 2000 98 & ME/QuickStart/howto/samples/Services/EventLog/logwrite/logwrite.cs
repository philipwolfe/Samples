using System;
using System.Diagnostics;

public class WriteLog {
    public static void Main(String[] args) {
        string appName = Environment.GetCommandLineArgs()[0];

        if ( args.Length != 3 ) {
            Console.WriteLine("Usage: " + appName +" <log> <message> <source>");
            return;
        }

        string log = args[0];
        string source = args[2];

        if ( !EventLog.SourceExists(source) ) {
            EventLog.CreateEventSource(source,log);
        }

        EventLog aLog = new EventLog();
        aLog.Source = source;

        if ( aLog.Log.ToUpper() != log.ToUpper() ) {
            Console.WriteLine("Some other application is using the source!");
            return;
        }

        aLog.WriteEntry(args[1],EventLogEntryType.Information);
        Console.WriteLine("Entry written successfuly!");
    }
}

