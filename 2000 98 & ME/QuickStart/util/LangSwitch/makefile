!include ..\..\master.mak

#since we want the compiler to import from some dll's, let's specify the std WinForms ones here
_CS_WEBFORMS_IMPORTS=/R:System.DLL /R:System.Web.dll 

_OUTDIR=..\..\Bin
_WF_OUTDIR=..\..\WINFORMS\Bin
_HT_OUTDIR=..\..\HowTo\Bin
_AP_OUTDIR=..\..\AspPlus\Bin

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_CS_WEBFORMS_IMPORTS)

#Define what we are building from what
TARGET_NAME=LangSwitch.dll
SOURCE_NAMES=LangSwitch.cs 

$(TARGET_NAME) : $(SOURCE_NAMES) 
	$(_CS) /t:library /debug- $(_IMPORTS) /out:$@ $**
	copy $(TARGET_NAME) $(_OUTDIR)
	copy $(TARGET_NAME) $(_AP_OUTDIR)
	copy $(TARGET_NAME) $(_WF_OUTDIR)
	copy $(TARGET_NAME) $(_HT_OUTDIR)
	del $(TARGET_NAME)
        
#issuing "nmake" will build target
all: $(TARGET_NAME) 

