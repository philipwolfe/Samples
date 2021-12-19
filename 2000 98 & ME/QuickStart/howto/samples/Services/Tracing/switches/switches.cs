using System;
using System.Diagnostics;
using System.IO;

// Set DWORD value of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\COMPlus\Switches\ABooleanSwitch to 0 (false) or 1 (true)
// Set DWORD value of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\COMPlus\Switches\ATraceSwitch to 0 (off), 1(error), 2 (warning), 3(info)4(verbose)

public class Switches
{
    public static void Main(String[] args) 
	{
		// setup listeners
		SetupListeners();

		// setup switches
		BooleanSwitch boolSwitch= new BooleanSwitch("ABooleanSwitch", "Demo bool switch"); 
		TraceSwitch traceSwitch = new TraceSwitch("ATraceSwitch","Demo trace switch");

		Debug.WriteLine("The app was compiled with DEBUG directive!");
		Trace.WriteLine("The app was compiled with TRACE directive!");

		Trace.WriteLineIf(boolSwitch.Enabled, "This is controlled by boolSwitch!");
	
		Trace.WriteLineIf(traceSwitch.TraceError, "This is controlled by traceSwitch.Error!");
		Trace.WriteLineIf(traceSwitch.TraceWarning, "This is controlled by traceSwitch.Warning!");
		Trace.WriteLineIf(traceSwitch.TraceInfo, "This is controlled by traceSwitch.Info!");
		Trace.WriteLineIf(traceSwitch.TraceVerbose, "This is controlled by traceSwitch.Verbose!");	
    }

	public static void SetupListeners(){
		Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
		Debug.Listeners.Add(new TextWriterTraceListener(File.Create("output.txt")));
		if(!EventLog.SourceExists("SwitchesDemo"))
		{
			EventLog.CreateEventSource("SwitchesDemo","SwitchesDemo");
		}
		Debug.Listeners.Add(new EventLogTraceListener("SwitchesDemo"));
	}
}