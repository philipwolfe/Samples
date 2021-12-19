!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\axhosting
CORSDK=..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
TARGET_NAME=MDIBrowser.exe
SOURCE_NAMES=MainForm.vb Document.vb 


#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_VB_WINFORMS_IMPORTS) /R:shdocvw.dll /R:AxShDocVw.DLL

#Build Sample directives
$(_VB_OUTDIR)\$(TARGET_NAME) : $(TARGET_NAME)
        copy $** $(_VB_OUTDIR)
        
$(_VB_OUTDIR)\AxShDocVw.DLL : AxShDocVw.DLL
        copy $** $(_VB_OUTDIR)
        copy ShDocVw.DLL $(_VB_OUTDIR)

!IF EXIST ( $(WINDIR)\System\shdocvw.dll )

AxShDocVw.DLL : $(WINDIR)\System\shdocvw.dll
	aximp $(WINDIR)\System\shdocvw.dll

!ELSEIF EXIST ( $(WINDIR)\System32\shdocvw.dll )

AxShDocVw.DLL : $(WINDIR)\System32\shdocvw.dll
	aximp $(WINDIR)\System32\shdocvw.dll

!ENDIF

$(TARGET_NAME) : $(SOURCE_NAMES) 
        $(_BC) $(_VB_EXE_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build target
all: $(_VB_OUTDIR)\AxShDocVw.DLL $(_VB_OUTDIR)\$(TARGET_NAME)

