OverloadDemo.sln

For the OverloadDemo.sln to run, it needs to reference the FindSPooch.mdb file 
inside of the FindAPooch/bin directory.  

The VB.Net code looks to the current directory for the FindaPooch.mdb file.
In Visual Studio 7 debug mode, the current directory is the bin directory where the code is 
compiled.

Example:  OverloadDemo/FindAPooch/bin/FindAPooch.mdb

If you do choose to compile the Solution and move the FindAPooch.exe and the PoochObjects.dll 
files to a different directory, please make sure that the FindaPooch.mdb file is in the same 
directory as the OverloadDemo.exe file, as this will be the current directory.
