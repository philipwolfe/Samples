!IFNDEF CORSDK
#assumes we are in com20sdk\quickstart\winforms\samples\Cs\SimpleHelloWorld
CORSDK=..\..\..\..\..
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

$(_CS_OUTDIR)\SimpleHelloWorld.exe : SimpleHelloWorld.exe
        copy $** $(_CS_OUTDIR)

SimpleHelloWorld.exe : SimpleHelloWorld.cs
        $(_CS) $(_CS_EXE_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build SimpleHelloWorld.exe
all: $(_CS_OUTDIR)\SimpleHelloWorld.exe
