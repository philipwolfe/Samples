
!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all: Installers CustomAction

Installers::
	cd Installers
	$(_CONTINUE) nmake all
        cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..

CustomAction::
	cd CustomAction
	$(_CONTINUE) nmake all
        cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..

