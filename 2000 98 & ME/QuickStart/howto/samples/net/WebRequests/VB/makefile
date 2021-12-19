
!IFNDEF CORSDK
#assumes directory of com20sdk\QuickStart\aspplus\samples\webforms\ctrlauth\simple
CORSDK=..\..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=/r:System.Net.dll

_OUTDIR=.

#our dependancy list
#since the filename of the dll does not match filename for .cs
#we must specify the command line for the compile

all:  clientgetasync.exe clientget.exe clientgetwithntlm.exe clientgetwithproxy.exe clientgetwithssl.exe clientpost.exe clientwebexception.exe

clientgetasync.exe : clientgetasync.vb
clientget.exe: clientGet.vb
clientgetwithntlm.exe: clientgetwithntlm.vb
clientgetwithproxy.exe: clientgetwithproxy.vb
clientgetwithssl.exe: clientgetwithssl.vb
clientpost.exe: clientpost.vb
clientwebexception.exe: clientwebexception.vb