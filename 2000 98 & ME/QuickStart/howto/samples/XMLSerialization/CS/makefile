!IFNDEF CORSDK
#assumes we are in com20sdk\quickstart\HowTo\samples\Xml\DataSetMapXMLData
CORSDK=..\..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
#!include ..\..\..\..\master.mak
!include ..\..\xml\master.mak

#since we want the compiler to import from some dll's, let's specify it here.
#(_CS_XML_IMPORTS is defined in \QuickStart\HowTo\samples\xml\master.mak)
_IMPORTS=$(_CS_XML_IMPORTS)

all: purchaseorder readwritexml

purchaseorder: purchaseorder.dll

purchaseorder.dll: purchaseorder.cs
	$(_CS) $(_CS_DLL_FLAGS) -r:system.xml.serialization.dll purchaseorder.cs

readwritexml: readwritexml.exe

readwritexml.exe: ReadWriteXml.cs
	$(_CS) ReadWriteXml.cs $(_CS_EXE_FLAGS) -r:system.xml.serialization.dll;PurchaseOrder.dll;system.dll

purchaseorder.cs: ..\purchaseorder.xsd
	xsd -c -l:c# -n:XmlSerializationHowTo ..\purchaseorder.xsd