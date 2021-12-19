!IFNDEF CORSDK
#assumes we are in com20sdk\quickstart\winforms\samples\Cs\SimpleHelloWorld
CORSDK=..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_VB_WINFORMS_IMPORTS)

$(_VB_OUTDIR)\SimpleHelloWorld.exe : SimpleHelloWorld.exe
        copy $** $(_VB_OUTDIR)

SimpleHelloWorld.exe : SimpleHelloWorld.vb
        $(_BC) $(_VB_EXE_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build SimpleHelloWorld.exe
all: $(_VB_OUTDIR)\SimpleHelloWorld.exe
