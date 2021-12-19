!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\printing\example1
CORSDK=..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak


#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_VB_WINFORMS_IMPORTS)

$(_VB_OUTDIR)\PrintingExample1.exe : PrintingExample1.exe
        copy $** $(_VB_OUTDIR)

PrintingExample1.exe : PrintingExample1.vb
        $(_BC) $(_VB_EXE_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build PrintingExample1.exe
all: $(_VB_OUTDIR)\PrintingExample1.exe


