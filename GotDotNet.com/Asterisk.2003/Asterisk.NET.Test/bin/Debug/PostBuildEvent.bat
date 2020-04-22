@echo off
"C:\Docs.dnz\private\Projects\Asterisk.2003\Asterisk.NET.Test\compile-resource.cmd" "bin\Debug\"
if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd