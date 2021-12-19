#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include ..\..\..\..\master.mak

#Used as a local variable to use the local C# compiler so that "set CUST_CS=csc" will do local build
!IFDEF CUST_CS
_CS=$(CUST_CS)
!ENDIF

#since we want the compiler to import from some dll's, let's specify it here and the XML one
_CS_XML_IMPORTS=/R:System.dll /R:System.Data.dll /R:System.XML.dll

# Bin dir is ... undefined
#_OUTDIR=$(CORSDK)\QuickStart\Bin ...undefined
#_CS_OUTDIR=$(CORSDK)\QuickStart\Bin\Cs .... undefined


