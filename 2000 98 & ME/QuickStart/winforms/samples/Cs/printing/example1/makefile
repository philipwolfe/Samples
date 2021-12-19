!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\printing\example1
CORSDK=..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak


#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_CS_WINFORMS_IMPORTS)

#our dependency list
#since the filename of the dll does not match filename for .cs
#we must specify the command line for the compile

$(_CS_OUTDIR)\PrintingExample1.exe : PrintingExample1.exe
        copy $** $(_CS_OUTDIR)

PrintingExample1.exe : PrintingExample1.cs
        $(_CS) $(_CS_EXE_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build PrintingExample1.exe
all: $(_CS_OUTDIR)\PrintingExample1.exe


