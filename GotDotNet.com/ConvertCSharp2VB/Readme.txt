What is in the zip file?
------------------------
The zip file extracts into a new folder ConvertCSharp2VB that contains the following folders and files:
- ConvertCSharp2VB 
	- ConvertCSharp2VB.EXE (A Windows EXE that converts C# source code to VB .NET)
	- ConvertCSharp2VB.DLL (DLL that actually performs the conversion from C# to VB .NET)
	- Readme.txt
	- Source Folder
		- ConvertCSharp2VB Folder (Contains the DLL and source that does the actual conversion)
		- ConvertCSharp2VB_offline Folder (Contains the implementation of a UI for the conversion)

How to use:
------------------------
- Simply extract the files into seperate folder and run the ConvertCSharp2VB.EXE

Recommend method:
------------------------
- If you are using Visual Studio .NET for your developement environment, I would recommend that you add this utility under the Tools menu so it is always available.
- Select [External Tools] from the [Tools] menu. Click on the [Add] button and specify the following:
	. Title: Convert C# to VB .NET
	. Command: (locate the ConvertCSharp2VB.EXE) and specify it here with full path 
		   e.g. C:\ConvertCSharp2VB\ConvertCSharp2VB.exe
	.Arguments: 
	.Initial Directory: 


------------------------
------------------------
Please read the copyright 
notice for Convert C# to 
VB .NET in Copyright.doc.
------------------------
------------------------

Enjoy!
Kamal Patel (kppatel@yahoo.com)