@echo off

if /I "" == "%1" goto :NoParams

if /I "/?" == "%1" (
    goto :Usage
)

if /I "?" == "%1" (
    goto :Usage
)

set __ETWTracingSampleFilename="%1"

shift
if /I "" == "%1" (
	goto :Filename
) else (
	goto :Usage
)

:NoParams
@echo Calling logman start "ETWTracingSampleSession" -pf providerlist.txt -a -ets ... 
call logman start "ETWTracingSampleSession" -pf providerlist.txt -a -ets
goto :EOF

:Filename
@echo Calling logman start "ETWTracingSampleSession" -pf providerlist.txt -a -o %__ETWTracingSampleFilename% -ets ... 
call logman start "ETWTracingSampleSession" -pf providerlist.txt -a -o %__ETWTracingSampleFilename% -ets

goto :EOF

:Usage
@echo Usage: SetupETW.bat [filename] [/?]
@echo.
@echo Parameters:
@echo.
@echo filename      : The path (optional) and file name of the event trace log (.etl) file to be specified in logman. By default, log file name is the ETWTracingSampleSession.etl
@echo ?             : Display this help
@echo.
@echo Example:
@echo   UpdateClient.cmd TraceData.etl

ENDLOCAL