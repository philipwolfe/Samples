!IFNDEF CORSDK
#assumes that we are in com20sdk\tutorial\quickstart\winforms\samples\cs\axhosting
CORSDK=..\..\..\..\..\..
!ENDIF

!IFNDEF QSDIR
QSDIR=$(CORSDK)\QuickStart
!ENDIF

#Cleanup these
_CLEANFILES=*.exe *.dll *.pdb ListCustomers.cs UpdateCustomers.cs

!include $(QSDIR)\WinForms\samples\master.mak

#Define what we are building from what
EXE_TARGET_NAME=Update.exe
EXE_SOURCE_NAMES=UpdateForm.cs ListCustomers.cs UpdateCustomers.cs State.cs

DLL_TARGET_NAME=Microsoft.Samples.WinForms.Cs.Data.Update.Data.DLL
DLL_SOURCE_NAMES=CustomersDataSet.cs
PDB_TARGET_NAME=Microsoft.Samples.WinForms.Cs.Data.Update.Data.PDB

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=$(_CS_WINFORMS_IMPORTS) /R:System.Data.DLL
_EXE_IMPORTS=/R:$(DLL_TARGET_NAME) $(_CS_WINFORMS_IMPORTS) /R:System.Data.DLL /R:System.Net.DLL /R:System.Xml.Serialization.DLL /R:System.Web.Services.Dll

#Build Sample directives

#Build the ListCustomers SDL File by navigating to the URL in the browser or by using
#webserviceutil /c:getSDL /URL:http://localhost/quickstart/winforms/Samples/Cs/Data/Update/ListCustomers.asmx?SDL
ListCustomers.SDL : ListCustomers.asmx
        @ECHO ***
        @ECHO ***
        @ECHO *** You need to rebuild the ListCustomers SDL file - see makefile for details
        @ECHO ***
        @ECHO ***

#Build the UpdateCustomers SDL File by navigating to the URL in the browser or by using
#webserviceutil /c:getSDL /URL:http://localhost/quickstart/winforms/Samples/Cs/Data/Update/UpdateCustomers.asmx?SDL
UpdateCustomers.SDL : UpdateCustomers.asmx
        @ECHO ***
        @ECHO ***
        @ECHO *** You need to rebuild the UpdateCustomers SDL file - see makefile for details
        @ECHO ***
        @ECHO ***

ListCustomers.cs : ListCustomers.SDL
        webserviceutil /c:proxy /pa:$** /l:CSharp /n:ListCustomers

UpdateCustomers.cs : UpdateCustomers.SDL
        webserviceutil /c:proxy /pa:$** /l:CSharp /n:UpdateCustomers

$(_CS_OUTDIR)\$(EXE_TARGET_NAME) : $(EXE_TARGET_NAME)
        copy $** $(_CS_OUTDIR)

$(_CS_OUTDIR)\$(DLL_TARGET_NAME) : $(DLL_TARGET_NAME)
        copy $** $(_CS_OUTDIR)
        copy $** $(QSDIR)\WinForms\Bin
        copy $(PDB_TARGET_NAME) $(_CS_OUTDIR)
        copy $(PDB_TARGET_NAME) $(QSDIR)\WinForms\Bin

$(EXE_TARGET_NAME) : $(EXE_SOURCE_NAMES)
        $(_CS) $(_CS_EXE_FLAGS) $(_EXE_IMPORTS) /out:$@ $**

$(DLL_TARGET_NAME) : $(DLL_SOURCE_NAMES)
        $(_CS) $(_CS_DLL_FLAGS) $(_IMPORTS) /out:$@ $**

#issuing "nmake" will build target
all: $(_CS_OUTDIR)\$(DLL_TARGET_NAME) $(_CS_OUTDIR)\$(EXE_TARGET_NAME)
