This sample demonstrates how to call platform invokes (exported DLL functions) from C#.

This sample contains the source code for the Platform Invoke Tutorial.

Building and Running the Sample Within Visual Studio

To build and run the Platform Invoke samples


	Open the solution (Pinvoke.sln).

	In Solution Explorer, right-click the PinvokeTest project and click Set as StartUp Project.

	From the Debug menu, click Start Without Debugging.

	Repeat steps 2 and 3 for Marshal and Pinvoke.


Building and Running the Sample from the Command Line

To build and run the Platform Invoke samples


	Use the cd command to change to the PinvokeTest directory.

	Type the following:
csc PinvokeTest.cs
PinvokeTest


	Use the cd command to change to the Marshal directory.

	Type the following:
csc Marshal.cs
Marshal


	Use the cd command to change to the Pinvoke directory.

	Type the following:
csc logfont.cs pinvoke.cs
pinvoke



