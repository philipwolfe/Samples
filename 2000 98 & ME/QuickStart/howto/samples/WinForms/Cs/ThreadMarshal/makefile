!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\axhosting
CORSDK=..\..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\Samples\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_CS_WINFORMS_IMPORTS)


#Define what we are building from what
TARGET_NAME=ThreadMarshal.exe
SOURCE_NAMES=ThreadMarshal.cs 

#Build Sample directives
$(_CS_OUTDIR)\$(TARGET_NAME) : $(TARGET_NAME)
        copy $** $(_CS_OUTDIR)

$(TARGET_NAME) : $(SOURCE_NAMES)
        $(_CS) $(_CS_EXE_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build target
all: $(_CS_OUTDIR)\$(TARGET_NAME)
