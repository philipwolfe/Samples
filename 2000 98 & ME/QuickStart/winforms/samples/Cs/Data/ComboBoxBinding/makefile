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
EXE_TARGET_NAME=ComboBoxBinding.exe
EXE_SOURCE_NAMES=ComboBoxBinding.cs State.cs

DLL_TARGET_NAME=Microsoft.Samples.WinForms.Cs.ComboBoxBinding.Data.DLL
DLL_SOURCE_NAMES=CustomersDataSet.cs

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_CS_WINFORMS_IMPORTS) /R:System.Data.DLL
_EXE_IMPORTS=$(_CS_WINFORMS_IMPORTS) /R:System.Data.DLL /R:$(DLL_TARGET_NAME)

#Build Sample directives
$(_CS_OUTDIR)\$(EXE_TARGET_NAME) : $(EXE_TARGET_NAME)
        copy $** $(_CS_OUTDIR)

$(_CS_OUTDIR)\$(DLL_TARGET_NAME) : $(DLL_TARGET_NAME)
        copy $** $(_CS_OUTDIR)

$(EXE_TARGET_NAME) : $(EXE_SOURCE_NAMES)
        $(_CS) $(_CS_EXE_FLAGS) $(_EXE_IMPORTS) /out:$@ $**

$(DLL_TARGET_NAME) : $(DLL_SOURCE_NAMES)
        $(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build target
all: $(_CS_OUTDIR)\$(DLL_TARGET_NAME) $(_CS_OUTDIR)\$(EXE_TARGET_NAME)
