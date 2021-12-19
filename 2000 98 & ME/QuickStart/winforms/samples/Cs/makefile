!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all: SimpleHelloWorld \
     Printing  \
     Accessible \
     AxHosting \
     DesignableHelloWorld \
     GDIPlus \
     HelloWorldForm \
     Layout \
     MDI \
     Menus \
     printing \
     WritingControls \
     ControlReference \
     Data 

Accessible::
	cd Accessible
	$(_CONTINUE) nmake 
	cd ..

ControlReference::
	cd ControlReference
	$(_CONTINUE) nmake 
	cd ..

SimpleHelloWorld::
	cd SimpleHelloWorld
	$(_CONTINUE) nmake 
	cd ..

Printing::
	cd Printing
	$(_CONTINUE) nmake 
	cd ..
        
AxHosting::
	cd AxHosting
	$(_CONTINUE) nmake		
	cd ..

DesignableHelloWorld::
	cd DesignableHelloWorld
	$(_CONTINUE) nmake 
	cd ..

GDIPlus::
	cd GDIPlus
	$(_CONTINUE) nmake
	cd ..


HelloWorldForm::
	cd HelloWorldForm
	$(_CONTINUE) nmake 
	cd ..

Layout::
	cd Layout
	$(_CONTINUE) nmake 
	cd ..

MDI::
	cd MDI
	$(_CONTINUE) nmake 
	cd ..

Menus::
	cd Menus
	$(_CONTINUE) nmake 
	cd ..

WritingControls::
	cd WritingControls
	$(_CONTINUE) nmake 
	cd ..

Data::
	cd Data
	$(_CONTINUE) nmake 
	cd ..


