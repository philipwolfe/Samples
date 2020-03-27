========================================================================
       ATL SERVER : SoapDataTypes Project Overview
========================================================================

AppWizard has created this SoapDataTypes application for you.  This application
not only demonstrates the basics of using the ATL Server Classes
but is also a starting point for writing your application.

This file contains a summary of what you will find in each of the files that
make up your SoapDataTypes application.

SoapDataTypes.vcproj
    This is the main project file for VC++ projects generated using an Application Wizard. 
    It contains information about the version of Visual C++ that generated the file, and 
    information about the platforms, configurations, and project features selected with the
    Application Wizard.

WebTier.vdp
    This is the main project file for Deployment projects. It will deploy all required
	content and executables to the server and virtual directory you specified in the 
	wizard.  If the virtual directory does not exist, it will create a directory under
	the default web site for the server and deploy to that location.
SoapDataTypes.cpp
    This file is your root ISAPI Extension file.  It contains the ISAPI Extension code 
	and additional ATL Server code.  You can customize the ATL Server code to the 
	specific needs of your projects.
SoapDataTypes.h
	This file contains your ATL Server request handler class customized based on the 
	options you chose in the the ATL Server Wizard.
SoapDataTypes.def
	This file contains the functions that will be exported from your ISAPI Extension DLL.  
	This includes the ISAPI Extension functions HttpExtensionProc, GetExtensionVersion, 
	and TerminateExtension. These functions are delegated to the instance of your
	CIsapiExtension class.
SoapDataTypes.disco
	This file contains information that allows your web service to be exposed via
	web servers supporting the DISCO protocol.

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
