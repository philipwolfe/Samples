================================================================================
    MICROSOFT FOUNDATION CLASS LIBRARY : Canvas Project Overview
===============================================================================

AppWizard has created this Canvas application for you.  This application
not only demonstrates the basics of using the Microsoft Foundation Classes
but is also a starting point for writing your application.

This file contains a summary of what you will find in each of the files that
make up your Canvas application.

Canvas.vcproj
    This is the main project file for VC++ projects generated using an Application Wizard. 
    It contains information about the version of Visual C++ that generated the file, and 
    information about the platforms, configurations, and project features selected with the
    Application Wizard.

Canvas.h
    This is the main header file for the application.  It includes other
    project specific headers (including Resource.h) and declares the
    CCanvasApp application class.

Canvas.cpp
    This is the main application source file that contains the application
    class CCanvasApp.

Canvas.rc
    This is a listing of all of the Microsoft Windows resources that the
    program uses.  It includes the icons, bitmaps, and cursors that are stored
    in the RES subdirectory.  This file can be directly edited in Microsoft
    Visual C++. Your project resources are in 1033.

res\Canvas.ico
    This is an icon file, which is used as the application's icon.  This
    icon is included by the main resource file Canvas.rc.

res\Canvas.rc2
    This file contains resources that are not edited by Microsoft 
    Visual C++. You should place all resources not editable by
    the resource editor in this file.
Canvas.reg
    This is an example .REG file that shows you the kind of registration
    settings the framework will set for you.  You can use this as a .REG
    file to go along with your application.
Canvas.idl
    This file contains the Interface Description Language source code for the
    type library of your application.

/////////////////////////////////////////////////////////////////////////////

AppWizard creates one dialog class and automation proxy class:
CanvasDlg.h, CanvasDlg.cpp - the dialog
    These files contain your CCanvasDlg class.  This class defines
    the behavior of your application's main dialog.  The dialog's template is
    in Canvas.rc, which can be edited in Microsoft Visual C++.
DlgProxy.h, DlgProxy.cpp - the automation object
    These files contain your CCanvasDlgAutoProxy class.  This class
    is called the "automation proxy" class for your dialog, because it
    takes care of exposing the automation methods and properties that
    automation controllers can use to access your dialog.  These methods
    and properties are not exposed from the dialog class directly, because
    in the case of a modal dialog-based MFC application it is cleaner and
    easier to keep the automation object separate from the user interface.
/////////////////////////////////////////////////////////////////////////////

Other Features:

ActiveX Controls
    The application includes support to use ActiveX controls.
/////////////////////////////////////////////////////////////////////////////

Other standard files:

StdAfx.h, StdAfx.cpp
    These files are used to build a precompiled header (PCH) file
    named Canvas.pch and a precompiled types file named StdAfx.obj.

Resource.h
    This is the standard header file, which defines new resource IDs.
    Microsoft Visual C++ reads and updates this file.

/////////////////////////////////////////////////////////////////////////////

Other notes:

AppWizard uses "TODO:" to indicate parts of the source code you
should add to or customize.

If your application uses MFC in a shared DLL, and your application is 
in a language other than the operating system's current language, you
will need to copy the corresponding localized resources MFC70XXX.DLL
from the Microsoft Visual C++ CD-ROM onto the system or system32 directory,
and rename it to be MFCLOC.DLL.  ("XXX" stands for the language abbreviation.
For example, MFC70DEU.DLL contains resources translated to German.)  If you
don't do this, some of the UI elements of your application will remain in the
language of the operating system.

/////////////////////////////////////////////////////////////////////////////
