!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\services\MathService
CORSDK=..\..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#TODO
_CS=csc

#Define Imported Libraries
_IMPORTS=/r:System.Web.Services.dll /r:System.XML.Serialization.dll

# Bin dir is \com20sdk\QuickStart\ASPPlus\Bin
_OUTDIR=$(CORSDK)\QuickStart\ASPPlus\Bin

# Define Targets

#issuing "nmake all" will build the dll
all: SessionService1.dll

SessionService1.vb : 
	webserviceutil -c:proxy /pa:SessionService1.sdl /l:VB /n:SessionService1Space

SessionService1.dll : SessionService1.vb
	$(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**
