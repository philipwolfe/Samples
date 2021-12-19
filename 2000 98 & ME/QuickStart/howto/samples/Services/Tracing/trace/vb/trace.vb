Imports System
Imports System.Diagnostics

public class TraceSample
       	public shared sub Main() 
		Debug.Listeners.Add(new TextWriterTraceListener(Console.Out))
	
		Debug.WriteLine("The app was compiled with DEBUG directive!")
		Trace.WriteLine("The app was compiled with TRACE directive!")
		
		Dim doTrace As boolean

		doTrace = false
		Trace.WriteLineIf(doTrace, "This should not show up!")
		Debug.WriteLineIf(doTrace, "This should not show up!")
	
		doTrace = true
		Trace.WriteLineIf(doTrace, "The app was indeed compiled with TRACE directive!")
		Debug.WriteLineIf(doTrace, "The app was indded compiled with DEBUG directive!")			
       	end sub
end class