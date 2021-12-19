!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all: SimpleBinding \
     ComboBoxBinding  \
     Grid    \
     WebServiceBinding \
     MasterDetails \
     Update

SimpleBinding::
	cd SimpleBinding
	$(_CONTINUE) nmake 
	cd ..

ComboBoxBinding::
	cd ComboBoxBinding
	$(_CONTINUE) nmake 
	cd ..
        
Grid::
	cd Grid
	$(_CONTINUE) nmake 
	cd ..

WebServiceBinding::
	cd WebServiceBinding
	$(_CONTINUE) nmake 
	cd ..

MasterDetails::
 	cd MasterDetails
 	$(_CONTINUE) nmake 
 	cd ..

Update::
	cd Update
	$(_CONTINUE) nmake 
	cd ..
