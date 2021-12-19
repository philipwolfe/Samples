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

#issuing "nmake all" will build TemplateControlSamples.dll
all: TemplateControlSamples.dll

TemplateControlSamples.dll : Template1.cs Repeater1.cs Repeater2.cs RepeaterItem.cs RepeaterItemCollection.cs
	$(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**

