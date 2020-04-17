.NET Framework 3.0 Media Center Application Readme
----------------------------------
.NET Framework 3.0 Media Center Applications run in a sandbox with "Internet Permissions".
Only those .NET Framework 3.0 features that have been successfully security reviewed and validated as safe by the .NET Framework 3.0 team will run inside the sandbox.


.NET Framework 3.0 Item Templates - which work in the sandbox?
--------------------------------------------------------
Won't work by design - .NET Framework 3.0 Window - In the Internet zone, you don't have the permission to "popup" new windows.


Debugging .NET Framework 3.0 Media Center Applications - (F5)
--------------------------------------------------------
In order to successfully debug a .NET Framework 3.0 Media Center Application in Visual Studio, you must enable unmanaged code debugging
via the Debug page in the Properties view. Developers using Visual C# and Visual Basic Express do not need to do this.
 
The first time that this project is debugged, a dialog may appear stating that there 
is no debug information available for PresentationHost.exe.  This dialog can be
safely dismissed.

Visual Studio will create a "$(OutputPath)\WordGameWMC.mcl" file on a successful Build.
Press F5 in Visual Studio to build this project and start the debugger. Double-click on
"$(OutputPath)\WordGameWMC.mcl" to launch your application within Media Center and you will be
able to debug your application normally.

It is good practice to perform the following steps in between each debug or run iteration to ensure
that you are debugging the most recently built version of your .NET Framework 3.0 Media Center Application:
  1. Close Windows Media Center.
  2. Use Task Manager to verify that the PresentationHost.exe process is no longer running.
  3. Open a "CMD Shell" from the "Microsoft Windows SDK" group in the Start Menu.
  4  Run the command "mage -cc" and verify that the %localappdata%\apps\2.0 folder is empty.
