!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\util\showcode
CORSDK=..\..\..\..
!ENDIF

!IFNDEF QSDIR
#assumes that we are in com20sdk\tutorial\quickstart\util\showcode
QSDIR=$(CORSDK)\Tutorial\QuickStart
!ENDIF

!include $(QSDIR)\master.mak

#since we want the compiler to import from some dll's, let's specify the std WinForms ones here
_IMPORTS=/R:System.DLL /R:System.WinForms.dll /R:System.Data.DLL /R:Microsoft.VisualStudio.dll

# Bin dir is \com20sdk\QuickStart\Bin
_OUTDIR=$(QSDIR)\Bin

#Define what we are building from what
TARGET_NAME=TDGUtil.exe
SOURCE_NAMES=TDGUtil.cs 

#Build Sample directives
$(_OUTDIR)\$(TARGET_NAME) : $(TARGET_NAME)
        copy $** $(_OUTDIR)

$(TARGET_NAME) : $(SOURCE_NAMES) 
        $(_CS) $(_CS_EXE_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build target
all: $(_OUTDIR)\$(TARGET_NAME)
