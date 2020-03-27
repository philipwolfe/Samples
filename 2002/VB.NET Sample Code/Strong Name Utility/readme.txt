Any assembly that you want to install to the Global Assembly Cache must be compiled with a strong name.

Any assembly that you want to have access to COM+ services must be compiled with a strong name.

It used to be easy to compile with a strong name (Beta 1 and Beta 2) but they took the simple GUI interface out of the final version of Visual Studio.NET (I don't know why).

snutil.exe lets you compile with a strong name with just a few keystrokes.

How it works:

This program has a single button. When you press it, it will shell out to a hidden command window and run sn.exe, which comes with the .NET Framework SDK, and create a Strong Name Key file in the  c:\strongnames folder (which it creates).  Then it copies a line of code to the clipboard which you then must paste into your AssemblyInfo.vb file right under the following line: 

	<Assembly: CLSCompliant(True)>
	
Then, just recompile, and your assembly will have a strong name version.	

I hope you like this simple but useful utility. 

Carl Franklin
carl@franklins.net