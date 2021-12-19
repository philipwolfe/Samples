@echo off

if "%ASSEMBLYLOCATION%" == "" echo ERROR: You must set the ASSEMBLYLOCATION environment variable to the location of System.WinForms.dll
if "%ASSEMBLYLOCATION%" == "" goto done

csc /t:winexe /out:InboxViewer.exe InboxViewerForm.cs MessageForm.cs CDO.cs /r:%ASSEMBLYLOCATION%\System.WinForms.DLL /r:%ASSEMBLYLOCATION%\System.Drawing.dll /r:%ASSEMBLYLOCATION%\System.dll /r:%ASSEMBLYLOCATION%\Microsoft.Win32.Interop.dll

InboxViewer.exe

:done

@echo on