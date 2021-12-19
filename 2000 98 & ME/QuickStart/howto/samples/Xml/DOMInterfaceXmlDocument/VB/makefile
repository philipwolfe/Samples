!IFNDEF CORSDK
#assumes we are in com20sdk\quickstart\HowTo\samples\Xml\DOMInterfaceXmlDocument
CORSDK=..\..\..\..\..\..\..
#CORSDK=C:\com20sdk
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include ..\..\mastervb.mak

#since we want the compiler to import from some dll's, let's specify it here.
#(_VB_XML_IMPORTS is defined in \QuickStart\HowTo\samples\xml\master.mak)
_IMPORTS=$(_VB_XML_IMPORTS)

DOMInterfaceXmlDocument.exe : DOMInterfaceXmlDocument.vb
	$(_BC) DOMInterfaceXmlDocument.vb /t:exe $(_VB_EXE_FLAGS) $(_IMPORTS)

all: DOMInterfaceXmlDocument.exe
