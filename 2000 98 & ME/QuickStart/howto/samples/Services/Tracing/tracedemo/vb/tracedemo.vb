Imports System
Imports System.Diagnostics
Imports System.IO

' Set DWORD value of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\COMPlus\Switches\TraceMethods to 0 (false) or 1 (true)
' Set DWORD value of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\COMPlus\Switches\Arithmetic to 0 (off), 1(error), 2 (warning), 3(info)4(verbose)

public class TraceDemo
	shared traceMethods As BooleanSwitch 
	shared arithmeticSwitch As TraceSwitch

	public shared sub Main() 
		Debug.Listeners.Add(new TextWriterTraceListener(Console.Out))
		traceMethods = new BooleanSwitch("TraceMethods", "TraceDemo Method Tracing Switch")
		arithmeticSwitch = new TraceSwitch("Arithmetic","Arithemtic Operations")
		
		Dim a As Integer
		Dim b As Integer	
		for a = 0 to  4
			for b = 0 to 4
				Console.WriteLine(CStr(a)+"/"+CStr(b)+"="+CStr(Percent(a,b)))
			next b
		next a
	end sub

	public shared function Divide(a as Int64, b as Int64) As Int64
		if(traceMethods.Enabled) then 
			Trace.WriteLine("Divide("+CStr(a)+","+CStr(b)+") called") 
		end if
		
		if(b=0) then
			Trace.WriteLineIf(arithmeticSwitch.TraceWarning,"!!!!!!!!!!!!!!!!!!Division by 0!!!!!!!!!!!!!!!!")
			b = 1
		end if
		
		Dim ratio As Int64 = CType(a / b,Int64)
	
		if(traceMethods.Enabled) then 
			Trace.WriteLine("Divide("+CStr(a)+","+CStr(b)+") returns "+CStr(ratio))
		end if
		Divide = ratio
	end function

	public shared function Percent(a as Int64, b as Int64) as Int64
		if(traceMethods.Enabled) then 
			Trace.WriteLine("Percent("+CStr(a)+","+CStr(b)+") called")
		end if
		
		Dim percentResult As Int64 = CType(Divide(100*a, b),Int64)

		if(traceMethods.Enabled) then 
			Trace.WriteLine("Percent("+CStr(a)+","+CStr(b)+") returns "+CStr(percentResult))
		end if
		Percent = percentResult
	end function
end class