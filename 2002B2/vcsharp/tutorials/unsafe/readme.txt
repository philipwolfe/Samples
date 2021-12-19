This sample demonstrates how to use unmanaged code (code using pointers) in C#.

This sample contains the source code for the Unsafe Code Tutorial.

Building and Running the Sample Within Visual Studio

To build and run the Unsafe Code samples


	Open the solution (Unsafe.sln).

	In Solution Explorer, right-click the FastCopy project and click Set as StartUp Project.

	From the Debug menu, click Start Without Debugging.

	In Solution Explorer, right-click the ReadFile project and click Set as StartUp Project.

	In Solution Explorer, right-click the ReadFile project and click Properties.

	Open the Configuration Properties folder and click Debugging.

	In the Command Line Arguments property, enter ..\..\ReadFile.cs.

	Click OK.

	From the Debug menu, click Start Without Debugging.

	In Solution Explorer, right-click the PrintVersion project and click Set as StartUp Project.

	From the Debug menu, click Start Without Debugging.


Building and Running the Sample from the Command Line

To build and run the Unsafe Code samples


	Use the cd command to change to the Unsafe directory.

	Type the following:
cd FastCopy
csc FastCopy.cs /unsafe
FastCopy


	Type the following:
cd ..\ReadFile
csc ReadFile.cs /unsafe
ReadFile ReadFile.cs


	Type the following:
cd ..\PrintVersion
csc PrintVersion.cs /unsafe
PrintVersion



