!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\VB\axhosting
CORSDK=..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
TARGET_NAME=GDIPImages.exe
SOURCE_NAMES=GDIPImages.VB 

RESOURCES=/res:colorbars.jpg,Microsoft.Samples.WinForms.VB.GDIPlus.GDIPImages.colorbars.jpg

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_VB_WINFORMS_IMPORTS)  /R:System.Net.DLL

#Build Sample directives
$(_VB_OUTDIR)\$(TARGET_NAME) : $(TARGET_NAME)
        copy $** $(_VB_OUTDIR)
        copy Sample.jpg $(_VB_OUTDIR)

$(TARGET_NAME) : $(SOURCE_NAMES)
        $(_BC) $(_VB_EXE_FLAGS) $(_IMPORTS) $(RESOURCES) /out:$@ $**

#issuing "nmake" will build target
all: $(_VB_OUTDIR)\$(TARGET_NAME)
