This sample demonstrates how a C# program can interoperate with an unmanaged COM component.

This sample contains the source code for the COM Interop Part 1: C# Client Tutorial.

Building and Running the Sample Within Visual Studio

To build and run the COM Interop Part 1 samples


	Open the solution (COMInteropPart1.sln).

	In Solution Explorer, right-click the Interop1 project and click Set as StartUp Project.

	In Solution Explorer, right-click the Interop1 project and click Properties.

	Open the Configuration Properties folder and click Debugging.

	In the Command Line Arguments property, enter an avi file (such as c:\winnt\clock.avi).

	Click OK.

	From the Debug menu, click Start Without Debugging.

	Repeat steps 2 through 7 for Interop2.


If the QuartzTypeLib.dll included with Interop1 is out of date


	In Solution Explorer, open Interop1's References.

	Right-click QuartzTypeLib and click Remove.

	Right-click References and click Add Reference.

	In the COM tab, select the component named "ActiveMovie control type library."

	Click Select and OK.

	Rebuild Interop1.



Note&nbsp;&nbsp;&nbsp;Adding a reference to the component does the same thing as invoking tlbimp at the command line to create QuartzTypeLib.dll (as in step 2 below).

Building and Running the Sample from the Command Line

To build and run the COM Interop Part 1 samples


	Use the cd command to change to the Interop1 directory.

	Type the following:
tlbimp %windir%\system32\quartz.dll /out:QuartzTypeLib.dll
csc /r:QuartzTypeLib.dll interop1.cs
interop1 %windir%\clock.avi


	Use the cd command to change to the Interop2 directory.

	Type the following:
csc interop2.cs
interop2 %windir%\clock.avi



