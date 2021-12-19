!IFNDEF CORSDK
#assumes we are in com20sdk\quickstart\winforms\samples\VB\SimpleHelloWorld
CORSDK=..\..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\Samples\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
CTL_TARGET_NAME=CustomerControl.DLL
CTL_SOURCE_NAMES=CustomerControl.vb Customer.vb
APP_TARGET_NAME=UserControl.exe
APP_SOURCE_NAMES=HostApp.vb

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_VB_WINFORMS_IMPORTS)  
_APP_IMPORTS=$(_IMPORTS) /R:$(CTL_TARGET_NAME)

#Build Sample directives
$(_VB_OUTDIR)\$(APP_TARGET_NAME) : $(APP_TARGET_NAME)
        copy $** $(_VB_OUTDIR)
        
$(_VB_OUTDIR)\$(CTL_TARGET_NAME) : $(CTL_TARGET_NAME)
        copy $** $(_VB_OUTDIR)

$(APP_TARGET_NAME) : $(APP_SOURCE_NAMES) 
        $(_BC) $(_VB_EXE_FLAGS) $(_APP_IMPORTS) /out:$@ $**

$(CTL_TARGET_NAME) : $(CTL_SOURCE_NAMES) 
        $(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$@ $**
#TODO: SORT THIS OUT
        @copy makefile $(APP_TARGET_NAME) >nul
        @erase $(APP_TARGET_NAME)

#issuing "nmake" will build target
all: $(_VB_OUTDIR)\$(CTL_TARGET_NAME) $(_VB_OUTDIR)\$(APP_TARGET_NAME)
