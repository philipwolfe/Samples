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
_IMPORTS=/r:System.Web.dll 

#issuing "nmake all" will build SimpleControlSamples.dll
all: SimpleControlSamples.dll

SimpleControlSamples.dll : Simple.cs SimpleProperty.cs SimpleSubProperty.cs SimpleInnerContent.cs
	$(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**

