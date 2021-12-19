
!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak


all: Brushes \
     Images  \
     Pens    \
     Text

Brushes::
	cd Brushes
	$(_CONTINUE) nmake 
	cd ..

Images::
	cd Images
	$(_CONTINUE) nmake 
	cd ..
        
Pens::
	cd Pens
	$(_CONTINUE) nmake 
	cd ..

Text::
	cd Text
	$(_CONTINUE) nmake 
	cd ..

