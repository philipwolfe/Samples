!include ..\..\master.mak

_IMPORTS=/r:System.Web.dll /r:System.dll

_OUTDIR=..\..\Bin
_WF_OUTDIR=..\..\WINFORMS\Bin
_HT_OUTDIR=..\..\HowTo\Bin
_AP_OUTDIR=..\..\AspPlus\Bin

#Define what we are building from what
TARGET_NAME=TabControl.dll
SOURCE_NAMES=TabControl.cs Tab.cs

$(TARGET_NAME) : $(SOURCE_NAMES) 
	$(_CS) /t:library /debug- $(_IMPORTS) /out:$@ $**
	copy $(TARGET_NAME) $(_OUTDIR)
	copy $(TARGET_NAME) $(_AP_OUTDIR)
	copy $(TARGET_NAME) $(_WF_OUTDIR)
	copy $(TARGET_NAME) $(_HT_OUTDIR)
	del $(TARGET_NAME)
        
#issuing "nmake" will build target
all: $(TARGET_NAME) 




