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

$(_VB_OUTDIR)\PrintingExample4.exe : PrintingExample4.exe
        copy $** $(_VB_OUTDIR)

PrintingExample4.exe : TextFilePrintDocument.vb PrintForm.vb
        $(_BC) $(_VB_EXE_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build PrintingExample4.exe
all: $(_VB_OUTDIR)\PrintingExample4.exe


