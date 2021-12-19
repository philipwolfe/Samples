!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\axhosting
CORSDK=..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
TARGET_NAME=DesignableHelloWorld.exe
SOURCE_NAMES=DesignableHelloWorld.vb 
TARGET_RES=DesignableHelloWorld.resources
SOURCE_RES=designablehelloworld-en-us.resx
RES_CMD=/res:$(TARGET_RES),Microsoft.Samples.WinForms.VB.DesignableHelloWorld.DesignableHelloWorld.resources

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_CS_WINFORMS_IMPORTS)

#Build Sample directives
$(_VB_OUTDIR)\$(TARGET_NAME) : $(TARGET_NAME)
        copy $** $(_VB_OUTDIR)

$(TARGET_NAME) : $(SOURCE_NAMES)
        $(_BC) $(_VB_EXE_FLAGS) $(_IMPORTS) $(RES_CMD) /out:$@ $**

$(TARGET_RES): $(SOURCE_RES)
        ResGen $(SOURCE_RES) $(TARGET_RES)
#TODO: SORT THIS OUT
        @copy makefile $(TARGET_NAME) >nul
        @erase $(TARGET_NAME)



#issuing "nmake" will build target
all: $(TARGET_RES) $(_VB_OUTDIR)\$(TARGET_NAME) 
