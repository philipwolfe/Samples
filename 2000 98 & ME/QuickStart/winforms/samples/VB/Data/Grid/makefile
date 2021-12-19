!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\axhosting
CORSDK=..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

#Cleanup these
_CLEANFILES=*.exe *.dll *.pdb

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
EXE_TARGET_NAME=Grid.exe
EXE_SOURCE_NAMES=Grid.vb

DLL_TARGET_NAME=Microsoft.Samples.WinForms.Cs.Grid.Data.DLL
DLL_SOURCE_NAMES=CustomersDataSet.vb

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_VB_WINFORMS_IMPORTS) /R:System.Data.DLL
_EXE_IMPORTS=$(_VB_WINFORMS_IMPORTS) /R:System.Data.DLL /R:$(DLL_TARGET_NAME)

#Build Sample directives
$(_VB_OUTDIR)\$(EXE_TARGET_NAME) : $(EXE_TARGET_NAME)
        copy $** $(_VB_OUTDIR)

$(_VB_OUTDIR)\$(DLL_TARGET_NAME) : $(DLL_TARGET_NAME)
        copy $** $(_VB_OUTDIR)

$(EXE_TARGET_NAME) : $(EXE_SOURCE_NAMES)
        $(_BC) $(_VB_EXE_FLAGS) $(_EXE_IMPORTS) /out:$@ $**

$(DLL_TARGET_NAME) : $(DLL_SOURCE_NAMES)
        $(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build target
all: $(_VB_OUTDIR)\$(DLL_TARGET_NAME) $(_VB_OUTDIR)\$(EXE_TARGET_NAME)
