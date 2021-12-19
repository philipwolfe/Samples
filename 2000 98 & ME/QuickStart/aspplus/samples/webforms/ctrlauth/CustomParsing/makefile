!IFNDEF CORSDK
#assumes directory of com20sdk
CORSDK=..\..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#TODO
_CS=csc

# Bin dir is \com20sdk\QuickStart\ASPPlus\Bin
_OUTDIR=$(CORSDK)\QuickStart\ASPPlus\Bin

#Define Imported Libraries
_IMPORTS=/r:System.Web.dll /r:System.dll

#issuing "nmake all" will build CustomParsingControlSamples.dll
all: CustomParsingControlSamples.dll

CustomParsingControlSamples.dll : CustomParse1.cs CustomParse2.cs Item.cs
	$(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**


