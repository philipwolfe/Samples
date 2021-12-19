!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#Define Imported Libraries
_IMPORTS=/r:System.Net.dll

# Bin dir is \com20sdk\QuickStart\ASPPlus\Bin
_OUTDIR=.

# Define Targets

#issuing "nmake all" will build
all: clientget.exe clientgetasync.exe clientgetwithntlm.exe clientgetwithproxy.exe clientgetwithssl.exe clientpost.exe clientwebexception.exe


