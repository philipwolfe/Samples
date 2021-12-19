This sample shows how the command line can be accessed and two ways of accessing the array of command line parameters.

This sample contains the source code for the Command Line Parameters Tutorial.

Building and Running the Sample Within Visual Studio

To build and run the Command Line Parameters samples


	Open the solution (CommandLine.sln).

	In Solution Explorer, right-click the CmdLine1 project and click Set as StartUp Project.

	In Solution Explorer, right-click the project and click Properties.

	Open the Configuration Properties folder and click Debugging.

	In the Command Line Arguments property, type the command line parameters (see the tutorial for an example) and click OK.

	From the Debug menu, click Start Without Debugging.

	Repeat steps 2 through 6 for CmdLine2.


Building and Running the Sample from the Command Line

To build and run the Command Line Parameters samples


	Use the cd command to change to the CmdLine1 directory.

	Type the following:
csc cmdline1.cs
cmdline1 A B C


	Use the cd command to change to the CmdLine2 directory.

	Type the following:
csc cmdline2.cs
cmdline2 John Paul Mary



