
!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all: Timer Scheduler ScheduleDemo

Timer::
	cd Timer
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..

Scheduler::
	cd Scheduler
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..

ScheduleDemo::
	cd ScheduleDemo
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..
