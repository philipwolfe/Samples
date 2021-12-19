!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\axhosting
CORSDK=..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
TARGET_NAME=GDIPBrushes.exe
SOURCE_NAMES=GDIPBrushes.cs 

RESOURCES=/res:colorbars.jpg,Microsoft.Samples.WinForms.Cs.GDIPlus.GDIPBrushes.colorbars.jpg

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_CS_WINFORMS_IMPORTS)  

#Build Sample directives
$(_CS_OUTDIR)\$(TARGET_NAME) : $(TARGET_NAME)
        copy $** $(_CS_OUTDIR)

$(TARGET_NAME) : $(SOURCE_NAMES)
        $(_CS) $(_CS_EXE_FLAGS) $(_IMPORTS) $(RESOURCES) /out:$@ $**

#issuing "nmake" will build target
all: $(_CS_OUTDIR)\$(TARGET_NAME)
