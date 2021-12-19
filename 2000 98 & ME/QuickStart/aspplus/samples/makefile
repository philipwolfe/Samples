
!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all::
	cd webforms\intro
	$(_CONTINUE) nmake all
	cd ..\..
	cd webforms\ctrlauth
	cd Composition
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..\CustomParsing
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all	
	cd ..\..\NonComposition
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..\Simple
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..\Templates
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..\ViewState
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..\..\..
	cd webforms\busobjs
	$(_CONTINUE) nmake all
	cd ..\..
	cd webforms\busobjs\VB
	$(_CONTINUE) nmake all
	cd ..\..\..
	cd apps\handler
	$(_CONTINUE) nmake all
	cd ..\..
	cd apps\VB\handler
	$(_CONTINUE) nmake all
	cd ..\..\..
	cd classbrowser
	$(_CONTINUE) nmake all
	cd ..
	cd grocertogo
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..
	cd localize\resources
	$(_CONTINUE) nmake all
	cd ..\..
	cd portal\personalization
	$(_CONTINUE) nmake all
	cd ..\..
	cd services\mathservice
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..\..
	cd services\datatypes
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..\..
	cd services\dataservice
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..\..
	cd services\textmatching
	$(_CONTINUE) nmake all
	cd ..\..
	cd services\intrinsics
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..\..

clean::
	del /s *.pdb *.dll *.exe



   