#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include ..\..\..\..\..\master.mak

#since we want the compiler to import from some dll's, let's specify it here and the XML one
_VB_XML_IMPORTS=/R:System.dll /R:System.Data.dll /R:System.XML.dll

# Bin dir is ... undefined
#_OUTDIR=$(CORSDK)\QuickStart\Bin ...undefined
#_VB_OUTDIR=$(CORSDK)\QuickStart\Bin\VB .... undefined


