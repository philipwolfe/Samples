!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all: Example1 Example2 Example3 Example4 Example5 SimplePad

Example1::
	cd Example1
	$(_CONTINUE) nmake 
	cd ..

Example2::
	cd Example2
	$(_CONTINUE) nmake 
	cd ..

Example3::
	cd Example3
	$(_CONTINUE) nmake 
	cd ..

Example4::
	cd Example4
	$(_CONTINUE) nmake 
	cd ..

Example5::
	cd Example5
	$(_CONTINUE) nmake 
	cd ..

SimplePad::
	cd SimplePad
	$(_CONTINUE) nmake 
	cd ..

