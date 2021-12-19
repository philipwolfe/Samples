This sample shows how C# classes can declare indexers to provide array-like access to the classes.

This sample contains the source code for the Indexers Tutorial.

Building and Running the Sample Within Visual Studio

To build and run the Indexers sample


	Open the solution (Indexers.sln).

	In Solution Explorer, right-click the indexers project and click Properties.

	Open the Configuration Properties folder and click Debugging.

	In the Command Line Arguments property, enter ..\..\Test.txt.

	Click OK.

	From the Debug menu, click Start Without Debugging.


Building and Running the Sample from the Command Line

To build and run the Indexers sample


	To compile the sample program, type the following at the command prompt:
csc indexer.cs


	The sample program reverses the bytes in a file given as a command-line argument. For example, to reverse the bytes in Test.txt and see the result, issue the following commands:
indexer Test.txt
type Test.txt


	To change the reversed file back to normal, run the program on the same file again.


