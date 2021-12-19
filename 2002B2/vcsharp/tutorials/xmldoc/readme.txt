This sample shows how to document code using XML.

This sample contains the source code for the XML Documentation Tutorial.

Building and Running the Sample Within Visual Studio

To build the XML Documentation sample


	Open the solution (XMLdoc.sln).

	In Solution Explorer, right-click the project and click Properties.

	Open the Configuration Properties folder and click Build.

	Set the XML Documentation File property to XMLsample.xml.

	From the Build menu, click Build. The XML output file will be in the debug directory.


Building and Running the Sample from the Command Line

To build the XML Documentation sample


	To generate the sample XML documentation, type the following at the command prompt:
csc XMLsample.cs /doc:XMLsample.xml


	To see the generated XML, issue the following command:
type XMLsample.xml



