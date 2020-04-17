SafePad Sample

Introduction:
SafePad demonstrates how to use some of the new APIs available to developers creating applications for Microsoft® Windows Vista™. SafePad is a much-simplified version of Notepad, designed to demonstrate some of the features in Windows Vista that make applications more robust, reliable, and easier to use.

To build the sample:
1.	 Run MSBuild from the sample root directory, or open the solution file (.sln) with Visual Studio and build the solution.

To run the sample:
2.	If necessary, deploy SafePad.exe and README.txt to a Windows Vista machine. Be sure to deploy it to the My Documents folder for your user account, as Least-privileged User Accounts (LUA) will prevent modifying files in most other locations. 
3.	Double-click SafePad.exe or open a Command Prompt and type safepad.exe.
See Comments for command line options and notes for using the sample.

Requirements: 
The sample can built on any operating system that supports the Windows SDK, but it will only run successfully on the Windows Vista operating system.

Demonstrates:
New features demonstrated include the application restart and document recovery APIs, and advanced error reporting.

Comments:
SafePad.exe can be invoked with a command-line parameter, which indicates the text file to edit. If the file doesn't already exist, a new file is created. SafePad.exe can be invoked without a command-line parameter, in which case the README.txt file is opened for editing.

The 'Special' menu in SafePad can be used to turn on various reliability features within the application. These options can be checked and unchecked in almost any combination, with different results. 
The 'Special' menu also has two commands that will intentionally either hang or crash the application. Note that the crash command is disabled until the application has been open for at least *60* seconds, as several parts of the reliability infrastructure are enabled only after a delay to avoid endless start-fail-restart loops.

If error reporting is enabled, be sure to check the SafePad entries in the local Error Reporting panel in the Control Panel. Note that individual error reports do not become visible on the winqual.microsoft.com site until 2-4 days have elapsed, due to propagation delays.

If an error report is submitted, you can go to https://winqual.microsoft.com and login as user 'sdkuser', with the password 'Admin98!' to check on the crash information. Once you've logged-in, visit the 'Software' tab and examine the various statistics for the application.



