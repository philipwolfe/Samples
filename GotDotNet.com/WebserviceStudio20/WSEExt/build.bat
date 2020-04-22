@if (%_echo%)==() echo off
setlocal
set CSC_FLAGS=
set FILES=

:LParseArgs
if (%1)==() goto LRun
if exist %1 (
 set FILES=%FILES% %1
) else (
 set CSC_FLAGS=%CSC_FLAGS% %1
)
shift
@goto LParseArgs

:LRun

@rem set CSC_FLAGS=%CSC_FLAGS% /r:System.Web.Services.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Data.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Design.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.dll 
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Drawing.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Web.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Web.Services.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.DirectoryServices.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Windows.Forms.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Runtime.Remoting.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Drawing.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Runtime.Serialization.Formatters.Soap.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Xml.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:System.Security.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:microsoft.web.services.dll
@set CSC_FLAGS=%CSC_FLAGS% /r:..\bin\webservicestudio.exe

@set CSC_FLAGS=%CSC_FLAGS% /out:..\bin\wseext.dll /t:library /optimize+
@echo on
csc %CSC_FLAGS%  *.cs   
