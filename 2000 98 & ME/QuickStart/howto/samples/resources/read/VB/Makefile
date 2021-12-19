!IFNDEF CORSDK
#assumes directory of com20sdk\QuickStart\aspplus\samples\webforms\ctrlauth\simple
CORSDK=C:\com20sdk
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include ..\..\..\..\..\master.mak


# Since we are a protocol of putting all the dlls in a bin dir
# let's reset our global variable to point to the bin directory
#_OUTDIR=..\..\..\..\bin

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=

#our dependancy list
#since the filename of the dll does not match filename for .cs
#we must specify the command line for the compile


all:  ReadResource.exe


#use explicit rule to include resources
ReadResource.exe: ReadResource.vb Strings.resources
	$(_BC) $(_VB_EXE_FLAGS) $(_IMPORTS) /res:Strings.resources,Errors.resources /out:$(_OUTDIR)\$@ ReadResource.vb

#Generate resource file via tool this time.
Strings.resources:
	resgen ..\Strings.txt Strings.resources