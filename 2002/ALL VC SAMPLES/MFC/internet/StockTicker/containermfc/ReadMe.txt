========================================================================
	   MICROSOFT FOUNDATION CLASS LIBRARY : containerMFC
========================================================================


AppWizard has created this containerMFC application for you.  This application
not only demonstrates the basics of using the Microsoft Foundation classes
but is also a starting point for writing your application.

This file contains a summary of what you will find in each of the files that
make up your containerMFC application.

containerMFC.h
	This is the main header file for the application.  It includes other
	project specific headers (including Resource.h) and declares the
	CContainerMFCApp application class.

containerMFC.cpp
	This is the main application source file that contains the application
	class CContainerMFCApp.

containerMFC.rc
	This is a listing of all of the Microsoft Windows resources that the
	program uses.  It includes the icons, bitmaps, and cursors that are stored
	in the RES subdirectory.  This file can be directly edited in Microsoft
	Developer Studio.

res\containerMFC.ico
	This is an icon file, which is used as the application's icon.  This
	icon is included by the main resource file containerMFC.rc.

res\containerMFC.rc2
	This file contains resources that are not edited by Microsoft
	Developer Studio.  You should place all resources not
	editable by the resource editor in this file.

containerMFC.reg
	This is an example .REG file that shows you the kind of registration
	settings the framework will set for you.  You can use this as a .REG
	file to go along with your application or just delete it and rely
	on the default RegisterShellFileTypes registration.


/////////////////////////////////////////////////////////////////////////////

For the main frame window:

MainFrm.h, MainFrm.cpp
	These files contain the frame class CMainFrame, which is derived from
	CFrameWnd and controls all SDI frame features.


/////////////////////////////////////////////////////////////////////////////

AppWizard creates one document type and one view:

containerMFCDoc.h, containerMFCDoc.cpp - the document
	These files contain your CContainerMFCDoc class.  Edit these files to
	add your special document data and to implement file saving and loading
	(via CContainerMFCDoc::Serialize).

containerMFCView.h, containerMFCView.cpp - the view of the document
	These files contain your CContainerMFCView class.
	CContainerMFCView objects are used to view CContainerMFCDoc objects.


/////////////////////////////////////////////////////////////////////////////

AppWizard has also created classes specific to OLE

CntrItem.h, CntrItem.cpp - this class is used to
	manipulate OLE objects.  They are usually displayed by your
	CContainerMFCView class and serialized as part of your CContainerMFCDoc class.


/////////////////////////////////////////////////////////////////////////////
Other standard files:

StdAfx.h, StdAfx.cpp
	These files are used to build a precompiled header (PCH) file
	named containerMFC.pch and a precompiled types file named StdAfx.obj.

Resource.h
	This is the standard header file, which defines new resource IDs.
	Microsoft Developer Studio reads and updates this file.

/////////////////////////////////////////////////////////////////////////////
Other notes:

AppWizard uses "TODO:" to indicate parts of the source code you
should add to or customize.

/////////////////////////////////////////////////////////////////////////////
