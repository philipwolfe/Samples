!IFNDEF CORSDK
#assumes directory of com20sdk\QuickStart\aspplus\samples\webforms\ctrlauth\simple
CORSDK=C:\com20sdk
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include ..\..\..\..\master.mak


# Since we are a protocol of putting all the dlls in a bin dir
# let's reset our global variable to point to the bin directory
#_OUTDIR=..\..\..\..\bin

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=/r:calcrv5\calcr.dll /r:parser\parser.dll /a.version:5.0.0.0

#our dependancy list
#since the filename of the dll does not match filename for .cs
#we must specify the command line for the compile



all:  Calcrv5 Calcrv6 Parser Math


calcrv5:: 
   cd Calcrv5
   nmake all
   cd ..

calcrv6:: 
   cd Calcrv6
   nmake all
   cd ..

Parser:: 
   cd Parser
   nmake all
   cd ..

Math:  Math.exe	







