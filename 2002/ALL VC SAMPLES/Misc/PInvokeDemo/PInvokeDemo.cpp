// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#using <mscorlib.dll>

using namespace System;
using namespace System::Runtime::InteropServices;

// Declare the function that is exported from unmanaged dll (shell32.dll).
[DllImport("shell32.dll")]
extern "C" int _cdecl ShellExecute(	int hwnd,				// Handle to a parent window.
									String *strVerb,		// Action to be performed.
									String *strFileName,	// File or object on which to execute the specified verb.
									String *strParameters,	// Parameters to be passed to the application.
									String *strDirectory,	// Default directory.
									int nShowCmd);			// Flags.

// Managed class demonstrates Runtime's Platform Invocation Service
// (P/Invoke) to call unmanaged code from managed code.
 __gc class Launcher
{
public:
	// Starts program that specified by strFileName parameter
	static int StartProgram(String *strFileName)
	{
		return ShellExecute(0,
							S"Open",
							strFileName,
							String::Empty,
							String::Empty,
							1 /*SW_SHOWNORMAL*/);
	}
};

// This is the entry point for this application
int main( int argc, char *argv[ ])
{
	// Check parameters.
	if(argc < 2)
	{
		Console::WriteLine(S"Not enough parameters.");
	}
	else
	{
		// Call static function of the Launcher class and start program.
		if(Launcher::StartProgram(new String(argv[1])) < 33)
			Console::WriteLine(S"Couldn't launch the program!");
	}

	Console::Write("Press Enter to continue");
	Console::ReadLine();

    return 0;
}