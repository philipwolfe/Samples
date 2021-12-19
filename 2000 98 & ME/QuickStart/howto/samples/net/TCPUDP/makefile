!IFNDEF CORSDK
#assumes directory of com20sdk\QuickStart\aspplus\samples\webforms\ctrlauth\simple
CORSDK= ..\..\..\..\..
!ENDIF

#tell nmake where to find the master rules for building COM+ applications
#assumes file is \com20sdk\QuickStart\master.mak
!include $(CORSDK)\QuickStart\master.mak

#since we want the compiler to import from some dll's, let's specify it here
_IMPORTS=/r:System.Net.dll

#our dependancy list
#since the filename of the dll does not match filename for .cs
#we must specify the command line for the compile

all:  chat.exe DateTimeClient.exe DateTimeServer.exe

Chat.exe: chat.cs
DateTimeClient.exe: datetimeclient.cs
DateTimeServer.exe: datetimeServer.cs