!IFNDEF CORSDK
#assumes we are in com20sdk\quickstart\HowTo\samples\Xml\StreamXmlDocument
CORSDK=..\..\..\..\..\..
#CORSDK=C:\com20sdk
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
#!include ..\..\..\..\master.mak
!include ..\master.mak

#since we want the compiler to import from some dll's, let's specify it here.
#(_CS_XML_IMPORTS is defined in \QuickStart\HowTo\samples\xml\master.mak)
_IMPORTS=$(_CS_XML_IMPORTS)

StreamXmlDocument.exe : StreamXmlDocument.cs
	$(_CS) StreamXmlDocument.cs $(_CS_EXE_FLAGS) $(_IMPORTS)

all: StreamXmlDocument.exe
