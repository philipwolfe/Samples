!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#TODO
_CS=csc

#Define Imported Libraries
_IMPORTS=/r:System.Web.dll /r:System.Data.dll 

# Bin dir is \com20sdk\QuickStart\ASPPlus\Bin
_OUTDIR=$(CORSDK)\QuickStart\ASPPlus\Bin

# Define Targets

#issuing "nmake all" will build ClassInfo.dll
all: ClassInfo.dll

ClassInfo.dll : ClassInfo.cs
	$(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**






