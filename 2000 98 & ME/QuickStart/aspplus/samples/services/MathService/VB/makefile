!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\services\MathService
CORSDK=..\..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#Define Imported Libraries
_IMPORTS=/r:System.Web.Services.dll /r:System.XML.Serialization.dll

# Bin dir is \com20sdk\QuickStart\ASPPlus\Bin
_OUTDIR=$(CORSDK)\QuickStart\ASPPlus\Bin

# Define Targets

#issuing "nmake all" will build the dll
all: MathService.dll

MathService.vb : 
	webserviceutil -c:proxy /pa:MathService.sdl /l:VB /n:MathServiceSpace

MathService.dll : MathService.vb
	$(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**


