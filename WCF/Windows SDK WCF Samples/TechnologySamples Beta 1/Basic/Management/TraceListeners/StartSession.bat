setlocal

if "%1" == "" (
set output=trace.ETL
) else (
set output=%1
)

rem @echo off
rem if NOT "%_echo%" == "" @echo on
@echo *** %0 Starting ***

call StopSession.bat

logman create trace Indigo -o %output% -p "{411a0819-c24b-428c-83e2-26b41091702e}" 
logman start Indigo 

@echo *** %0 Complete ***

endlocal