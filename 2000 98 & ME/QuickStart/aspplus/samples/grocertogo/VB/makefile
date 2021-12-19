!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#Define Imported Libraries
_IMPORTS=/r:System.Web.dll /r:System.Data.dll /r:System.dll

# Bin dir is \com20sdk\QuickStart\ASPPlus\Samples\GrocerToGo\VB\Bin
_OUTDIR=Bin

# Define Targets

#issuing "nmake all" will build Market.dll
all: Market.dll

Market.dll : Market.vb
	$(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**






