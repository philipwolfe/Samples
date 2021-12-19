!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\
CORSDK=..\..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#TODO
_CS=csc

#Define Imported Libraries
_IMPORTS=/r:System.data.dll /r:System.Data.dll /r:System.dll

# Bin dir is \com20sdk\QuickStart\Howto\Bin
_OUTDIR=$(CORSDK)\QuickStart\howto\bin

# Define Targets

#issuing "nmake all" will build SimpleHandler.dll
all: CustDS.cs TypedData.dll

CustDS.cs : custds.xsd
	xsd.exe /namespace:customerDataSet /d /l:C# $**

TypedData.dll : CustDS.cs
	$(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$(_OUTDIR)\$@ $**


