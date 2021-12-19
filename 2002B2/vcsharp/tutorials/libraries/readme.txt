This sample shows how to create and use a DLL in C#. 

This sample contains the source code for the Libraries Tutorial.

Building and Running the Sample Within Visual Studio

To build and run the Libraries sample


	Open the solution (Libraries.sln).

	In Solution Explorer, right-click the FunctionTest project and click Set as StartUp Project.

	From the Debug menu, click Start Without Debugging. This will automatically build the library in Functions and execute the program.


Building and Running the Sample from the Command Line

To build and run the Libraries sample


	Use the cd command to change to the Functions directory.

	Type the following:
csc /target:library /out:Functions.dll Factorial.cs DigitCounter.cs


	Use the cd command to change to the FunctionTest directory.

	Type the following:
csc /out:FunctionTest.exe /R:..\Functions.DLL FunctionClient.cs 
FunctionTest



