@echo off
"C:\Program Files\VSIP 7.1\EnvSDK\tools\bin\x86\VSIPRegPkg" "C:\Documents and Settings\Serdar Dirican\My Documents\Visual Studio Projects\Report\vspackage\VsPackage\Debug\VsPackage.dll"

if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd