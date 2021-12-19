
!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak


all: WinFormsCs WinFormsVB

WinFormsCs::
	cd Cs
	$(_CONTINUE) nmake 
	cd ..

WinFormsVB::
# TBD	
