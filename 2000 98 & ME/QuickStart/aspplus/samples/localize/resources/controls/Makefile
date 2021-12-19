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
_IMPORTS=/r:System.Web.dll /r:System.Data.dll 

# Bin dir is QuickStart\aspplus\samples\localize\resources
_OUTDIR=..\Bin

TARGETS = 	$(_OUTDIR)\LocalizedControls.dll \
		$(_OUTDIR)\LocalizedControls_vb.dll \
		$(_OUTDIR)\de\LocalizedControls.resources.dll \
		$(_OUTDIR)\ja\LocalizedControls.resources.dll 


.SUFFIXES: .txt .resources


.txt.resources:
	resgen $*.txt $*.resources



#issuing "nmake all" will build Acme.dll and WebMarket.dll
all: $(TARGETS)


LINKRES=/res:en-us\lcontrols.resources,LocalizedStrings.resources

# 
$(_OUTDIR)\LocalizedControls.dll: LocalizedButtons.cs en-us\lcontrols.resources
	$(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) $(LINKRES) /out:$(_OUTDIR)\$@ LocalizedButtons.cs

$(_OUTDIR)\LocalizedControls_vb.dll: LocalizedButtons.vb en-us\lcontrols.resources
	$(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) $(LINKRES) /out:$(_OUTDIR)\$@ LocalizedButtons.vb


# 
$(_OUTDIR)\de\LocalizedControls.resources.dll: de\lcontrols.resources
	al /out:$(_OUTDIR)\de\LocalizedControls.resources.dll \
	   /embed:de\lcontrols.resources,LocalizedStrings.de.resources \
	   /culture:de 


$(_OUTDIR)\ja\LocalizedControls.resources.dll: ja\lcontrols.resources
	al /out:$(_OUTDIR)\ja\LocalizedControls.resources.dll \
	   /embed:ja\lcontrols.resources,LocalizedStrings.ja.resources \
	   /culture:ja


cleanres:
	del /q /s *.resources




