Abstract:
This sample demonstrates a number of things related to localization
and globalization:
1.)		How to set up a solution that builds one main EXE file and individual
satellite DLLs containing different language versions of the user interface.
2.)		The recommended way to implement a satellite DLL loading mechanism.
3.)		Code to detect the preferred language for the user interface on any
version of Windows.
4.)		How to dynamically switch the user interface language upon a change
request from a user (what isn't demonstrated is how the user choice for the user
interface language can be persisted).
5.)		How to use the generic character encoding mapping functions to be able
to build ANSI and Unicode versions of an application from the same source code.

System Requirements:
In the default configuration this solution builds a Unicode application which
requires Windows 2000 or higher with language support for Western European 
languages and Japanese installed to display all characters in the user interface
correctly.

By changing the Character Set in the general project settings to
"Use Multi-Byte Character Set" the sample can be compiled for earlier Windows
platforms.