echo off
setlocal
echo ************
echo cert setup starting
echo ************

call :setscriptvariables %1
IF NOT DEFINED SUPPORTED_MODE call :displayusage
IF DEFINED SUPPORTED_MODE call :cleancerts
IF DEFINED SETUP_SERVICE call :setupservice
IF DEFINED SETUP_CLIENT call :setupclient
GOTO end

:cleancerts
REM cleans up certs from previous runs.
echo ****************
echo Cleanup starting
echo ****************

echo -------------------------
echo del client certs
echo -------------------------
certmgr.exe -del -r CurrentUser -s My -c -n %CLIENT_NAME%
certmgr.exe -del -r CurrentUser -s TrustedPeople -c -n localhost

echo -------------------------
echo del service certs
echo -------------------------
certmgr.exe -del -r LocalMachine -s My -c -n localhost
certmgr.exe -del -r LocalMachine -s TrustedPeople -c -n %CLIENT_NAME%
certmgr.exe -put -r LocalMachine -s My -c -n %COMPUTER_NAME% computer.cer

IF %ERRORLEVEL% NEQ 0 GOTO cleanupcompleted

certmgr.exe -del -r LocalMachine -s My -c -n %COMPUTER_NAME%
DEL computer.cer

:cleanupcompleted
echo *****************
echo Cleanup completed
echo *****************

GOTO :EOF

:setupclient

echo ************
echo making client cert
echo ************
makecert.exe -sr CurrentUser -ss MY -a sha1 -n CN=%CLIENT_NAME% -sky exchange -pe

IF DEFINED EXPORT_CLIENT GOTO exportclient

echo ************
echo copying client cert to server's CurrentUserstore
echo ************
certmgr.exe -add -r CurrentUser -s My -c -n %CLIENT_NAME% -r LocalMachine -s TrustedPeople
GOTO :EOF

:exportclient

echo ************
echo exporting client cert to client.cer
echo ************
certmgr.exe -put -r CurrentUser -s My -c -n %CLIENT_NAME% client.cer
GOTO :EOF

:setupservice

echo ************
echo Server cert setup starting
echo %SERVER_NAME%
echo ************
echo making server cert
echo ************
makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe

IF DEFINED EXPORT_SERVICE GOTO exportservice

echo ************
echo copying server cert to client's CurrentUser store
echo ************
certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople
GOTO :EOF

:exportservice

echo ************
echo exporting service cert to service.cer
echo ************
certmgr.exe -put -r LocalMachine -s My -c -n %SERVER_NAME% service.cer
GOTO :EOF

:setscriptvariables
REM Parses the input to determine if we are setting this up for a single machine, client, or server
REM sets the appropriate name variables
call :setcomputername
IF [%1]==[] CALL :singlemachine
IF [%1]==[service] CALL :service
IF [%1]==[client] CALL :client

set CLIENT_NAME=client.com

GOTO :EOF

:singlemachine
echo ************
echo Running setup script for Single Machine
echo ************
SET SUPPORTED_MODE=1
SET SETUP_CLIENT=1
SET SETUP_SERVICE=1
SET SERVER_NAME=localhost
GOTO :EOF

:service
echo ************
echo Running setup script for Service
echo ************
SET SUPPORTED_MODE=1
SET SETUP_SERVICE=1
SET EXPORT_SERVICE=1
SET SERVER_NAME=%COMPUTER_NAME%
GOTO :EOF

:client
echo ************
echo Running setup script for Client
echo ************
SET SUPPORTED_MODE=1
SET SETUP_CLIENT=1
SET EXPORT_CLIENT=1
GOTO :EOF

:setcomputername
REM Puts the Fully Qualified Name of the Computer into a variable named COMPUTER_NAME
net config workstation | find "Full Computer name" > TEMP.BAT
>> Full.BAT ECHO SET COMPUTER_NAME=%%3
CALL TEMP.BAT
DEL TEMP.BAT
DEL Full.BAT
GOTO :EOF

:displayusage
ECHO Correct usage:
ECHO     Single Machine - Setup.bat
ECHO     Client Machine - Setup.bat client
ECHO     Service Machine - Setup.bat service
:end
