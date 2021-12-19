This sample demonstrates using a C# server with a C++ COM client.

This sample contains the source code for the COM Interop Part 2: C# Server Tutorial.

Building and Running the Sample Within Visual Studio

To build and run the COM Interop Part 2 sample


	Open the solution (COMInteropPart2.sln).

	In Solution Explorer, right-click the COMClient project and click Properties.

	Open the Configuration Properties folder and click Debugging.

	In the Command Line Arguments property, enter a name.

	Click OK.

	From the Debug menu, click Start Without Debugging.


Building and Running the Sample from the Command Line

To build and run the COM Interop Part 2 sample


	Use the cd command to change to the COMInteropPart2\COMClient directory.

	Copy the C# server code into the COMClient directory:
copy ..\CSharpServer\CSharpServer.cs


	Compile the server:
csc /target:library CSharpServer.cs
regasm CSharpServer.dll /tlb:CSharpServer.tlb


	Compile the client (make sure the path and environment variables are set properly with vcvars32.bat):
cl COMClient.cpp


	Run the client:
COMClient friend



