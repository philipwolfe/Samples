========================================================================
       ATL SERVER : inputIsapi Project Overview
========================================================================

AppWizard has created this inputIsapi application for you.  This application
not only demonstrates the basics of using the ATL Server Classes
but is also a starting point for writing your application.

This file contains a summary of what you will find in each of the files that
make up your inputIsapi application.

inputIsapi.vcproj
    This is the main project file for VC++ projects generated using an Application Wizard. 
    It contains information about the version of Visual C++ that generated the file, and 
    information about the platforms, configurations, and project features selected with the
    Application Wizard.
inputIsapi.cpp
    This file is your root ISAPI Extension file.  It contains the ISAPI Extension code 
	and additional ATL Server code.  You can customize the ATL Server code to the 
	specific needs of your projects.
inputIsapi.def
	This file contains the functions that will be exported from your ISAPI Extension DLL.  
	This includes the ISAPI Extension functions HttpExtensionProc, GetExtensionVersion, 
	and TerminateExtension. These functions are delegated to the instance of your
	CIsapiExtension class.

/////////////////////////////////////////////////////////////////////////////
Other standard files:

StdAfx.h, StdAfx.cpp
    These files are used to build a precompiled header (PCH) file
    and a precompiled types file.

/////////////////////////////////////////////////////////////////////////////

Other notes:

AppWizard uses "TODO:" to indicate parts of the source code you
should add to or customize.

/////////////////////////////////////////////////////////////////////////////
