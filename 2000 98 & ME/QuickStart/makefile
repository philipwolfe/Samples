
!IFNDEF CORSDK
#assumes that we are in com20sdk\quickstart\aspplus\samples\webforms\intro
CORSDK=..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

all: Remoting Util  Data BCL XML Global Services WinForms ASPX Net Assemblies

clean::
	$(_CONTINUE) del /s *.pdb *.exe *.dll
	$(_CONTINUE) del aspplus\samples\services\MathService\MathService.cs
	$(_CONTINUE) del aspplus\samples\services\MathService\VB\MathService.vb
	$(_CONTINUE) del aspplus\samples\services\MathService\VB\MathService.cls
	$(_CONTINUE) del aspplus\samples\services\DataService\DataService.cs
	$(_CONTINUE) del aspplus\samples\services\DataService\VB\DataService.vb
	$(_CONTINUE) del aspplus\samples\services\DataService\VB\DataService.cls
	$(_CONTINUE) del aspplus\samples\services\DataTypes\DataTypes.cs
	$(_CONTINUE) del aspplus\samples\services\DataTypes\VB\DataTypes.vb
	$(_CONTINUE) del aspplus\samples\services\DataTypes\VB\DataTypes.cls
	$(_CONTINUE) del aspplus\samples\services\Intrinsics\SessionService1.cs
	$(_CONTINUE) del aspplus\samples\services\Intrinsics\VB\SessionService1.vb
	$(_CONTINUE) del aspplus\samples\services\Intrinsics\VB\SessionService1.cls
	$(_CONTINUE) del aspplus\samples\services\TextMatching\MatchService.cs

ASPX::
	cd aspplus\samples
	$(_CONTINUE) nmake all
	cd ..\..


Assemblies::
	cd howto\samples\Assemblies
	cd gac
	$(_CONTINUE) nmake all
	cd ..
	cd SearchPath
	$(_CONTINUE) nmake all
	cd ..
	cd SharedName
	$(_CONTINUE) nmake all
	cd ..
	cd version
	$(_CONTINUE) nmake all
	cd ..
	cd ..\..\..


Data::
	cd howto
	cd samples\adoplus\cs\typeddata
	$(_CONTINUE) nmake all
	cd ..\..\..\..\..   

BCL::
	

  

	cd howto\samples\xmlserialization\cs
	$(_CONTINUE) nmake all
	cd ..\vb
	$(_CONTINUE) nmake all

	cd ..\..\..\..
	cd howto\samples
	cd BaseDataTypes\Compare
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd BaseDataTypes\Format
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd BaseDataTypes\parse
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd BaseDataTypes\Sort
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Collections\HashTable
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Collections\List
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd CompMod\CodeDom
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Cryptography\FileEncrypt
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..
	cd ..\..
	cd Exceptions\Catch
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Exceptions\Throw
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd IO\anagrams
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd IO\Directory
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd IO\LargeReadWrite
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd IO\LogFile
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd IO\readwrite
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Reflection\gettypes
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Reflection\Invoke
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Reflection\ListMembers
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Serialization\ISerializable
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Serialization\Serialize
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Win32Wrappers\Win32Call
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Win32Wrappers\Win32Marshal
	$(_CONTINUE) nmake all
	cd ..\..
	cd ..\..

Global::
	cd howto\samples
	cd Globalization\CultureRegion
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd  Globalization\Encoding
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Resources\Custom
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Resources\Read
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd Resources\Write
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
        cd ..
	cd ..\..
	cd ..\..

Util::
	cd util\tabcontrol
	$(_CONTINUE) nmake all
	cd ..\..
	cd util\langswitch
	$(_CONTINUE) nmake all
	cd ..\..

WinForms:: 
	cd WinForms
	$(_CONTINUE) nmake all	
	cd ..
	cd howto\samples\WinForms
	$(_CONTINUE) nmake all
	cd ..\..\..


XML::
	cd howto\samples\Xml
	$(_CONTINUE) nmake all
	cd ..\..\..

Services::
	cd howto
	cd samples\Services
	$(_CONTINUE) nmake all
	cd ..\..\..

Net::
	cd howto\samples\Net\TCPUDP
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..\WebRequests
	$(_CONTINUE) nmake all
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..\..\..\..

Remoting::
	cd howto\samples\remoting
	cd async
	$(_CONTINUE) nmake all	
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..
	cd byreference
	$(_CONTINUE) nmake all	
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..
	cd byvalue
	$(_CONTINUE) nmake all	
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..
	cd hello
	$(_CONTINUE) nmake all	
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..
	cd interface
	$(_CONTINUE) nmake all	
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..
	cd singleton
	$(_CONTINUE) nmake all	
	cd VB
	$(_CONTINUE) nmake all
	cd ..\..\..\..\..
