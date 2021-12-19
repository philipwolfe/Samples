!IFNDEF CORSDK
#assumes that we are in quickstart\aspplus\samples\classbrowser\vb
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
!include $(CORSDK)\QuickStart\master.mak

#Define Imported Libraries
_IMPORTS=/r:System.Web.dll /r:System.Data.dll 

# Bin dir is \com20sdk\QuickStart\ASPPlus\Bin
_OUTDIR=$(CORSDK)\QuickStart\ASPPlus\Bin

# Define Targets

# issuing "nmake all" will build ClassInfo.dll
all: ClassInfo.dll

ClassInfo.dll : ClassInfo.vb
	$(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $** $(_WIN32RES) $(_KEYFILE)
	
