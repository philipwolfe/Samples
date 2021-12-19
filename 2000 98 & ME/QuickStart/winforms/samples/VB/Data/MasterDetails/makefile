!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\axhosting
CORSDK=..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

#Cleanup these
_CLEANFILES=*.exe *.dll *.pdb CustomersAndOrders.vb

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
EXE_TARGET_NAME=MasterDetails.exe
EXE_SOURCE_NAMES=customersform.vb CustomersAndOrders.vb

DLL_TARGET_NAME=Microsoft.Samples.WinForms.VB.MasterDetails.Data.DLL
PDB_TARGET_NAME=Microsoft.Samples.WinForms.VB.MasterDetails.Data.PDB
DLL_SOURCE_NAMES=CustomersAndOrdersDataSet.vb

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_VB_WINFORMS_IMPORTS) /R:System.Data.DLL
_EXE_IMPORTS=/R:$(DLL_TARGET_NAME) $(_VB_WINFORMS_IMPORTS) /R:System.Data.DLL /R:System.Net.DLL /R:System.Xml.Serialization.DLL /R:System.Web.Services.Dll

#Build the SDL File by navigating to the URL in the browser or by using
#webserviceutil /c:getSDL /URL:http://localhost/quickstart/winforms/Samples/VB/Data/MasterDetails/CustomersAndOrdersWebService.asmx?SDL
CustomersAndOrdersWebService.SDL : CustomersAndOrdersWebService.asmx
        @ECHO ***
        @ECHO ***
        @ECHO *** You need to rebuild the SDL file - see makefile for details
        @ECHO ***
        @ECHO ***

CustomersAndOrders.vb : CustomersAndOrdersWebService.SDL
        webserviceutil /c:proxy /pa:$** /l:VB /n:CustomersAndOrdersWebService

$(_VB_OUTDIR)\$(DLL_TARGET_NAME) : $(DLL_TARGET_NAME)
        copy $** $(_VB_OUTDIR)
        copy $** $(QSDIR)\WinForms\Bin
        copy $(PDB_TARGET_NAME) $(_VB_OUTDIR)
        copy $(PDB_TARGET_NAME) $(QSDIR)\WinForms\Bin
        
#Build Sample directives
$(_VB_OUTDIR)\$(EXE_TARGET_NAME) : $(EXE_TARGET_NAME)
        copy $** $(_VB_OUTDIR)

$(EXE_TARGET_NAME) : $(EXE_SOURCE_NAMES)
        $(_BC) $(_VB_EXE_FLAGS) $(_EXE_IMPORTS)  /out:$@ $**

$(DLL_TARGET_NAME) : $(DLL_SOURCE_NAMES)
        $(_BC) $(_VB_DLL_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build target
all: $(_VB_OUTDIR)\$(DLL_TARGET_NAME) $(_VB_OUTDIR)\$(EXE_TARGET_NAME)

