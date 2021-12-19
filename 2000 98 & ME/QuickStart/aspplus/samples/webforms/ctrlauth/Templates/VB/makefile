!IFNDEF CORSDK
#assumes directory of com20sdk
CORSDK=..\..\..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

# Bin dir is \com20sdk\QuickStart\ASPPlus\Bin
_OUTDIR=$(CORSDK)\QuickStart\ASPPlus\Bin

#Define Imported Libraries
_IMPORTS=/r:System.Web.dll /r:System.dll

#issuing "nmake all" will build TemplateControlSamplesVB.dll
all: TemplateControlSamplesVB.dll

TemplateControlSamplesVB.dll : Template1.vb Repeater1.vb Repeater2.vb RepeaterItem.vb RepeaterItemCollection.vb
	$(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**

