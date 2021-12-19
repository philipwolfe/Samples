!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\axhosting
CORSDK=..\..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\Samples\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
TARGET_NAME=StatusBarCtl.exe
SOURCE_NAMES=StatusBarCtl.cs 
TARGET_RES=Microsoft.Samples.WinForms.Cs.StatusBarCtl.StatusBarCtl.resources
SOURCE_RES=StatusBarCtl.resX

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_CS_WINFORMS_IMPORTS)

#Build Sample directives
$(_CS_OUTDIR)\$(TARGET_NAME) : $(TARGET_NAME)
        copy $** $(_CS_OUTDIR)

$(TARGET_NAME) : $(SOURCE_NAMES)
        $(_CS) $(_CS_EXE_FLAGS) $(_IMPORTS) /res:$(TARGET_RES) /out:$@ $**

$(TARGET_RES): $(SOURCE_RES)
        ResXtoResources /compile $(SOURCE_RES) $(TARGET_RES)
#TODO: SORT THIS OUT
        @copy makefile $(TARGET_NAME) >nul
        @erase $(TARGET_NAME)

#issuing "nmake" will build target
all: $(TARGET_RES) $(_CS_OUTDIR)\$(TARGET_NAME) 
