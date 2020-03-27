================================================================================
    MICROSOFT FOUNDATION CLASS LIBRARY : MMXSwarm Sample Overview
===============================================================================

This file contains a summary of what you will find in each of the files that
make up your MMXSwarm application.

MMXSwarm is a simple SDI MFC application that draws swarms of colors 
on the screen. The trails on these swarms fade away with time.

MMXSwarm demonstrates several things:
- A simple SDI non-Doc/View application.
- Using CImage to manipulate image bits directly in the 3 common
  bitdepths.
- Using CImage to Load and Store images in arbitrary graphics formats.
- Using the C++ compiler's new processor intrinsics to optimize
  pixel processing by taking advantage of MMX.
- The build settings enable strict for-loop compliance, 64-bit pointer
  warnings, and Global Optimization (Link time code generation).

For the Sample Purposes:
ChildView.h, ChildView.cpp
	This is a CWnd derived class, not a view in the doc/view sense.
	It handles the loading and saving of images via the new CImage
	class in the methods OnFileSave() and OnFileOpen().
	
	On resizing, this view creates the Surface object and the swarm.
	At startup, it picks a bit depth that matches the desktop. The
	Surface object is re-created whenever a selection from the CImage
	menu is done.
	
	WM_ERASEBKGND is also handled since the app always repaints the
	full screen.

Surface.h, Surface.cpp
	CSurface wraps the CImage object. This is mostly needed because
	CSurface creates a border of 'black' pixels around a virtual
	image canvas so that blur processing does not need to be special
	cased on the edges.
	
	These files also define and implement the generic non-bit-depth
	specific versions of several DIB manipulation routines for
	clearing the screen, drawing lines and creating noise.  This
	file also contains the generic blur routine.

MMXSurface.h, MMXSurface16/24/32.cpp
	These classes derive from CSurface.  They implement optimized
	versions of the Blur routine for MMX processors at specific
	bit depths.  These classes all use the CMMXUnsigned16Saturated
	helper class defined in MMXWrapper.h
	
	The 32 bit Blur processes 2 pixels at a time and writes the result
	out as a single 64 bit quantity.  Helper routines are over-ridden
	to make sure the buffer will be aligned sufficiently.
	
	The 24 bit Blur processes 4 color spaces at a time (1.25 pixels).
	This essentially mimics 32 bit processing, but a couple non-aligned
	reads have to be done. This is usually bad, but on x86 seems to
	have better performance than aligned reads with shifts/ands/ors.
	
	The 16 bit processor acts quite a bit different than the other two.
	It processes 4 pixels at a time.  It is 'unrolled' 3 times, once
	for each color space (R, G and B).  Each color space is processed
	independently, and the final result or'd and written out to memory
	as a 64 bit quantity.  Helper routines are over-ridden to make sure
	the buffer will be aligned sufficiently.

MMXWrapper.h
	A non-complete class for wrapping the compilers new processor intrinsics.
	This class wraps the 16 bit mmx saturated functions required by
	the sample.  This class actually adds no overhead to the generated
	optimized code, and makes the source more easily read.

Swarm.h, Swarm.cpp
	A straight forward flocking algorithm. Used to give the screen
	something interesting to blur.  The algorithm was originally
	written by Jeff Butterworth on 7/11/90.

/////////////////////////////////////////////////////////////////////////////
For the main baseline application:
MMXSwarm.vcproj
    This is the main project file for VC++ projects generated using an Application Wizard. 
    It contains information about the version of Visual C++ that generated the file, and 
    information about the platforms, configurations, and project features selected with the
    Application Wizard.

MMXSwarm.h
    This is the main header file for the application.  It includes other
    project specific headers (including Resource.h) and declares the
    CMMXSwarmApp application class.

MMXSwarm.cpp
    This is the main application source file that contains the application
    class CMMXSwarmApp.  Contains idle handler that forwards to the view
    for updating the swarm.

MMXSwarm.rc
    This is a listing of all of the Microsoft Windows resources that the
    program uses.  It includes the icons, bitmaps, and cursors that are stored
    in the RES subdirectory.  This file can be directly edited in Microsoft
    Visual C++. Your project resources are in 1033.

res\MMXSwarm.ico
    This is an icon file, which is used as the application's icon.  This
    icon is included by the main resource file MMXSwarm.rc.

res\MMXSwarm.rc2
    This file contains resources that are not edited by Microsoft 
    Visual C++. You should place all resources not editable by
    the resource editor in this file.

/////////////////////////////////////////////////////////////////////////////
For the main frame window:
    The project includes a standard MFC interface.
MainFrm.h, MainFrm.cpp
    These files contain the frame class CMainFrame, which is derived from
    CFrameWnd and controls all SDI frame features.  This frame hosts
    a child window directly, and the application bypasses the doc/view
    architecture.
    
res\Toolbar.bmp
    This bitmap file is used to create tiled images for the toolbar.
    The initial toolbar and status bar are constructed in the CMainFrame
    class. Edit this toolbar bitmap using the resource editor, and
    update the IDR_MAINFRAME TOOLBAR array in MMXSwarm.rc to add
    toolbar buttons.

/////////////////////////////////////////////////////////////////////////////
Other standard files:

StdAfx.h, StdAfx.cpp
    These files are used to build a precompiled header (PCH) file
    named MMXSwarm.pch and a precompiled types file named StdAfx.obj.
    A general utility routine to determine if MMX is available is
    also in these files.

Resource.h
    This is the standard header file, which defines new resource IDs.
    Microsoft Visual C++ reads and updates this file.


/////////////////////////////////////////////////////////////////////////////