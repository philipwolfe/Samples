
!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all: LogWrite LogInfo LogMonitor

LogWrite::
	cd LogWrite
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..

LogInfo::
	cd LogInfo
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..

LogMonitor::
	cd LogMonitor
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..
