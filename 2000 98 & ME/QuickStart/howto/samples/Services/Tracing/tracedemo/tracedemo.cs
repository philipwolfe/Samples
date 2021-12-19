using System;
using System.Diagnostics;
using System.IO;

// Set DWORD value of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\COMPlus\Switches\TraceMethods to 0 (false) or 1 (true)
// Set DWORD value of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\COMPlus\Switches\Arithmetic to 0 (off), 1(error), 2 (warning), 3(info)4(verbose)

public class TraceDemo
{
	static BooleanSwitch traceMethods; 
	static TraceSwitch arithmeticSwitch;

	public static void Main(String[] args) 
	{
		Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
		traceMethods = new BooleanSwitch("TraceMethods", "TraceDemo Method Tracing Switch");
		arithmeticSwitch = new TraceSwitch("Arithmetic","Arithemtic Operations");
			
		for(int a = 0; a <= 4; a++)
			for(int b = 0; b <= 4; b++)
				Console.WriteLine(a+"/"+b+"="+Percent(a,b));
	}

	public static Int64 Divide(Int64 a, Int64 b)
	{
		if(traceMethods.Enabled) Trace.WriteLine("Divide("+a+","+b+") called");
		
		if(b==0)
		{
			Trace.WriteLineIf(arithmeticSwitch.TraceWarning,"!!!!!!!!!!!!!!!!!!Division by 0!!!!!!!!!!!!!!!!");
			b = 1;
		}
		
		Int64 ratio = a / b;
	
		if(traceMethods.Enabled)
			Trace.WriteLine("Divide("+a+","+b+") returns "+ratio);

		return ratio;
	}

	public static Int64 Percent(Int64 a, Int64 b)
	{
		if(traceMethods.Enabled)
			Trace.WriteLine("Percent("+a+","+b+") called");
		
		Int64 percent = Divide(100*a, b);
	
		if(traceMethods.Enabled)
			Trace.WriteLine("Percent("+a+","+b+") returns "+percent);

		return percent;
	}
}