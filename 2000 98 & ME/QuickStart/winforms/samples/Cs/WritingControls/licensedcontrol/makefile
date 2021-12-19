!IFNDEF CORSDK
CORSDK=..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
CTL_TARGET_NAME=LicensedControl.DLL
CTL_SOURCE_NAMES=LicensedControl.cs
APP_TARGET_NAME=LicensedControl.exe
APP_SOURCE_NAMES=HostApp.cs

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_CS_WINFORMS_IMPORTS)  
_APP_IMPORTS=$(_IMPORTS) /R:$(CTL_TARGET_NAME)

#Build Sample directives
$(_CS_OUTDIR)\$(APP_TARGET_NAME) : $(APP_TARGET_NAME)
        copy $** $(_CS_OUTDIR)
        
$(_CS_OUTDIR)\$(CTL_TARGET_NAME) : $(CTL_TARGET_NAME)
        copy $** $(_CS_OUTDIR)

$(APP_TARGET_NAME).licenses : $(APP_TARGET_NAME).Licenses.txt \
                              Microsoft.Samples.WinForms.Cs.LicensedControl.LicensedControl.lic
        lc /target:$(APP_TARGET_NAME) /complist:$(APP_TARGET_NAME).Licenses.txt /i:$(CTL_TARGET_NAME)
#TODO: SORT THIS OUT
        @copy makefile $(APP_TARGET_NAME) >nul
        @erase $(APP_TARGET_NAME)

$(APP_TARGET_NAME) : $(APP_SOURCE_NAMES) 
        $(_CS) $(_CS_EXE_FLAGS) $(_APP_IMPORTS) /res:$(APP_TARGET_NAME).licenses /out:$@ $**

$(CTL_TARGET_NAME) : $(CTL_SOURCE_NAMES) 
        $(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$@ $**
#TODO: SORT THIS OUT
        @copy makefile $(APP_TARGET_NAME) >nul
        @erase $(APP_TARGET_NAME)

#issuing "nmake" will build target
all: $(_CS_OUTDIR)\$(CTL_TARGET_NAME) $(APP_TARGET_NAME).licenses $(_CS_OUTDIR)\$(APP_TARGET_NAME) 

