!IFNDEF CORSDK
#assumes we are in com20sdk\quickstart\HowTo\samples\Xml\DataSetMapXMLData
CORSDK=..\..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
#!include ..\..\..\..\master.mak
!include ..\..\xml\master.mak

#since we want the compiler to import from some dll's, let's specify it here.
#(_VB_XML_IMPORTS is defined in \QuickStart\HowTo\samples\xml\master.mak)
_IMPORTS=$(_VB_XML_IMPORTS)

all: purchaseorder readwritexml

purchaseorder: purchaseorder.dll

purchaseorder.dll: purchaseorder.vb
	$(_BC) $(_VB_DLL_FLAGS) /r:system.xml.serialization.dll purchaseorder.vb

readwritexml: readwritexml.exe

readwritexml.exe: ReadWriteXml.vb
	$(_BC) $(_VB_EXE_FLAGS) /r:system.xml.serialization.dll /r:PurchaseOrder.dll /r:system.dll ReadWriteXml.vb

#workaround for problem with xsd.exe building writing improper vb code
purchaseorder.vb: ..\purchaseorder.xsd
	xsd -c -l:VB -n:XmlSerializationHowTo ..\purchaseorder.xsd