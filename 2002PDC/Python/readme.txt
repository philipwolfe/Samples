Managed Python - the COM+ 2.0 Python Compiler - PDC release - July 2000

*** This has only been tested with NGWS build 1812
*** It should run on later builds, but this is far from guaranteed
***
*** For updates, visit http://www.ActiveState.com/complus

Complete documentation is in the HTML in the docs directory.

In a nutshell:

* You must have Python 1.5 installed:
    via http://www.python.org/download/download_windows.html

* You must have the Python for Windows extensions installed:
    http://starship.python.net/crew/mhammond/downloads/win32all-132.exe

* Run "nmake" from the root installation directory.  This builds the compiler and
  the runtime (including runtime builtins)

* Run "testall.bat" from the "p2c" directory.  This compiles and runs
  the test suite.  There will be lots of noise printed, but there should
  be NO exceptions generated or printed.

* For your amusement, from the "p2c" directory, run the command:

  C:\...> make HelloWorld

  This will invoke the compiler over the trivial HelloWorld.py sample, resulting
  in HelloWorld.exe

  

*** To Remove the compiler ***
To help keep your registry and disk clean, you can run "nmake clean" in each of the "CORGlue", "PyRuntime" and "P2C" directories (sorry - no top-level, recursive clean process!)


All feedback/comments to MarkH@ActiveState.com

-- eof --

