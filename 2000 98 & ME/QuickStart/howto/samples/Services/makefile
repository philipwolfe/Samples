
!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all: DirectoryServices EventLog FileSystemWatcher Installers MessageQueue PerformanceCounters Process ServiceApplication Timers Tracing

DirectoryServices::
	cd DirectoryServices
	$(_CONTINUE) nmake all
	cd ..

EventLog::
	cd EventLog
	$(_CONTINUE) nmake all
	cd ..

FileSystemWatcher::
	cd FileSystemWatcher
	$(_CONTINUE) nmake all
	cd ..

Installers::
	cd Installers
	$(_CONTINUE) nmake all
	cd ..

MessageQueue::
	cd MessageQueue
	$(_CONTINUE) nmake all
	cd ..

PerformanceCounters::
	cd PerformanceCounters
	$(_CONTINUE) nmake all
	cd ..

Process::
	cd Process
	$(_CONTINUE) nmake all
	cd ..

ServiceApplication::
	cd ServiceApplication
	$(_CONTINUE) nmake all
	cd ..

Timers::
	cd Timers
	$(_CONTINUE) nmake all
	cd ..

Tracing::
	cd Tracing
	$(_CONTINUE) nmake all
	cd ..

