!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#TODO
_CS=csc

#Define Imported Libraries
_IMPORTS=/r:System.Data.dll /r:System.dll

# Bin dir is \com20sdk\QuickStart\ASPPlus\Bin
_OUTDIR=$(CORSDK)\QuickStart\ASPPlus\Bin

# Define Targets

#issuing "nmake all" will build HelloObj.dll and DataObj.dll and BusObj.dll
all: HelloObjVB.dll DataObjVB.dll BusObjVB.dll

HelloObjVB.dll : HelloObj.vb
	$(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**

DataObjVB.dll : DataObj.vb
	$(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**

BusObjVB.dll : BusObj.vb
	$(_BC) $(_VB_DLL_FLAGS) /r:$(_OUTDIR)\DataObjVB.dll $(_IMPORTS) /out:$(_OUTDIR)\$@ $**




