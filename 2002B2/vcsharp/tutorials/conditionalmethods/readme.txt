This sample demonstrates conditional methods, which provide a powerful mechanism by which calls to methods can be included or omitted depending on whether a symbol is defined.

This sample contains the source code for the Conditional Methods Tutorial.

Building and Running the Sample Within Visual Studio

To build and run the Conditional Methods sample


	Open the solution (ConditionalMethods.sln).

	In Solution Explorer, right-click the project and click Properties.

	Open the Configuration Properties folder and click Debugging.

	Set the Command Line Arguments property to "A B C" (without the quotation marks).

	In the Configuration Properties folder, click Build.

	Modify the Conditional Compilation Constants property (for example, add or delete DEBUG) and click OK.

	From the Debug menu, click Start Without Debugging.


Building and Running the Sample from the Command Line

To build and run the Conditional Methods sample


	To include the conditional method, compile and run the sample program by typing the following at the command prompt:
csc CondMethod.cs tracetest.cs /d:DEBUG
tracetest A B C



