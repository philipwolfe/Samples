!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\VB\axhosting
CORSDK=..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
TARGET_NAME=GDIPPens.exe
SOURCE_NAMES=GDIPPens.VB 

RESOURCES=/res:colorbars.jpg,Microsoft.Samples.WinForms.VB.GDIPlus.GDIPPens.colorbars.jpg /res:BoilingPoint.jpg,Microsoft.Samples.WinForms.VB.GDIPlus.GDIPPens.BoilingPoint.jpg

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_VB_WINFORMS_IMPORTS)  

#Build Sample directives
$(_VB_OUTDIR)\$(TARGET_NAME) : $(TARGET_NAME)
        copy $** $(_VB_OUTDIR)

$(TARGET_NAME) : $(SOURCE_NAMES)
        $(_BC) $(_VB_EXE_FLAGS) $(_IMPORTS) $(RESOURCES) /out:$@ $**

#issuing "nmake" will build target
all: $(_VB_OUTDIR)\$(TARGET_NAME)
