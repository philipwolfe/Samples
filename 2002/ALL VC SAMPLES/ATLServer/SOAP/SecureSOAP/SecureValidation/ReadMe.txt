========================================================================
       ATL SERVER : SecureValidation Project Overview
========================================================================

AppWizard has created this SecureValidation application for you.  This application
not only demonstrates the basics of using the ATL Server Classes
but is also a starting point for writing your application.

This file contains a summary of what you will find in each of the files that
make up your SecureValidation application.

SecureValidation.vcproj
    This is the main project file for VC++ projects generated using an Application Wizard. 
    It contains information about the version of Visual C++ that generated the file, and 
    information about the platforms, configurations, and project features selected with the
    Application Wizard.
SecureValidation.cpp
    This file is your root ISAPI Extension file.  It contains the ISAPI Extension code 
	and additional ATL Server code.  You can customize the ATL Server code to the 
	specific needs of your projects.
SecureValidation.h
	This file contains your ATL Server request handler class customized based on the 
	options you chose in the the ATL Server Wizard.
SecureValidation.def
	This file contains the functions that will be exported from your ISAPI Extension DLL.  
	This includes the ISAPI Extension functions HttpExtensionProc, GetExtensionVersion, 
	and TerminateExtension. These functions are delegated to the instance of your
	CIsapiExtension class.
SecureValidation.srf
	This file contains a starter SRF (Server Response File) for your application.
	It shows a sample usage of the replacement tag {{Hello}} which is 
	associated with the OnHello method in the CSecureValidationHandler class.

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
