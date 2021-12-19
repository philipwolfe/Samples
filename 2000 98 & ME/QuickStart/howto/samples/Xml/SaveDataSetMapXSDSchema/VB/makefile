!IFNDEF CORSDK
#assumes we are in com20sdk\quickstart\HowTo\samples\Xml\SaveDataSetMapXSDSchema\VB
CORSDK=..\..\..\..\..\..
#CORSDK=C:\com20sdk
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include ..\..\mastervb.mak

#since we want the compiler to import from some dll's, let's specify it here.
#(_VB_XML_IMPORTS is defined in \QuickStart\HowTo\samples\xml\mastervb.mak)
_IMPORTS=$(_VB_XML_IMPORTS)

SaveDataSetMapXSDSchema.exe : SaveDataSetMapXSDSchema.vb
	$(_BC) SaveDataSetMapXSDSchema.vb $(_VB_EXE_FLAGS) $(_IMPORTS)

all: SaveDataSetMapXSDSchema.exe
