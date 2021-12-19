!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all: CustomUITypeEditor HelloWorldControl LicensedControl SimpleControl UserControl

CustomUITypeEditor::
	cd CustomUITypeEditor
	$(_CONTINUE) nmake 
	cd ..

HelloWorldControl::
	cd HelloWorldControl
	$(_CONTINUE) nmake 
	cd ..

LicensedControl::
	cd LicensedControl
	$(_CONTINUE) nmake 
	cd ..

SimpleControl::
	cd SimpleControl
	$(_CONTINUE) nmake 		
	cd ..

UserControl::
	cd UserControl
	$(_CONTINUE) nmake 
	cd ..

