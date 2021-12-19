!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\portal\personalization
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#TODO
_CS=csc

#Define Imported Libraries
_IMPORTS=/r:System.Web.dll /r:System.dll /r:System.Data.dll 

# Bin dir is \com20sdk\QuickStart\ASPPlus\Samples\Portal\Bin
_OUTDIR=$(CORSDK)\QuickStart\ASPPlus\Samples\Portal\Bin

# Define Targets

#issuing "nmake all" will build Acme.dll and WebMarket.dll
all: Personalization.dll PortalModule.dll PortalModulePage.dll

Personalization.dll : Personalization.cs
	$(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**

PortalModule.dll : PortalModule.cs
	$(_CS) $(_CS_DLL_FLAGS) /r:$(_OUTDIR)\Personalization.dll $(_IMPORTS) /out:$(_OUTDIR)\$@ $**

PortalModulePage.dll : PortalModulePage.cs
	$(_CS) $(_CS_DLL_FLAGS) /r:$(_OUTDIR)\Personalization.dll $(_IMPORTS) /out:$(_OUTDIR)\$@ $**



