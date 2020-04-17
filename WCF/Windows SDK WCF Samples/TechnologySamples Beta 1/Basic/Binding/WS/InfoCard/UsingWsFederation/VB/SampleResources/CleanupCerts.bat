@echo off
setlocal

REM set path for findPrivateKey
set PATH=%PATH%;%MSSDK%\bin

set CONTOSO=Contoso
set FABRIKAM=Fabrikam
set INFOCARD=INFOCARD

set CF_SUBJECT=CN=Contoso
set CF_SERIAL=27 f2 76 ea 00 01 00 00 00 0d
set CF_THUMB=f8 f6 1b ce 70 da 07 f7 65 86 32 1f a8 24 38 e7 c1 3b db 00

set FC_SUBJECT=CN=Fabrikam
set FC_SERIAL=27 f2 82 63 00 01 00 00 00 0e
set FC_THUMB=9c da 64 fc 5a 94 98 33 57 f1 fb ef dd b9 3d 05 58 d8 d1 e4

set FC_SUBJECT=CN=INFOCARD
set INFOCARD_SERIAL=2d 01 96 a5 23 c1 c1 81 46 4c 1f d3 d9 66 7a 14
set INFOCARD_THUMB=13 cd 6f fd ed 1a b4 8d 85 8e 54 83 31 4d ad a9 bb 5a 9c b7

set VDIR_LOCATION=%SystemDrive%\Inetpub\wwwroot\ServiceModelSamples

REM Set INSTALL_CONTOSO = 1 if using InfoCardSamlSecurityTokenService
set INSTALL_CONTOSO=0
for /f  %%p in (SampleResources\ServiceNames.txt) do (
    if "%%p" == "InfoCardSamlSecurityTokenService" (
        set INSTALL_CONTOSO=1
    )
)

REM Determine which certificates are installed.
set FC_CurrentUser_TrustedPeople=0
set FC_LocalMachine_TrustedPeople=0
set CF_CurrentUser_TrustedPeople=0
set CF_LocalMachine_TrustedPeople=0
set FC_LocalMachine_My=0
set CF_LocalMachine_My=0
set INFOCARD_LocalMachine_My=0

for /f "delims=" %%l in ('certmgr.exe -all -s -r LocalMachine TrustedPeople') do (

       if /i "%%l" == "   %FC_SERIAL%" (
           set FC_LocalMachine_TrustedPeople=1
       )else if /i "%%l" == "   %CF_SERIAL%" (
           set CF_LocalMachine_TrustedPeople=1
       ) 
)

for /f "delims=" %%l in ('certmgr.exe -all -s -r LocalMachine My') do (

       if /i "%%l" == "   %FC_SERIAL%" (
           set FC_LocalMachine_My=1
       ) else if /i "%%l" == "   %CF_SERIAL%" (
           set CF_LocalMachine_My=1
       ) else if /i "%%l" == "   %INFOCARD_SERIAL%" (
           set INFOCARD_LocalMachine_My=1
       )
)

REM Fabrikam public key certs
if %FC_LocalMachine_TrustedPeople% == 1 (
    echo.
    echo Deleting Fabrikam public key certificate...
    echo Deleting LocalMachine TrustedPeople %FABRIKAM%...
    certmgr.exe -del -r LocalMachine -s TrustedPeople -c -n %FABRIKAM% 
)

echo.
echo Deleting infocard sample root public certificate....
certmgr.exe -del -r LocalMachine -s AuthRoot -c -n %INFOCARD% 

if %INSTALL_CONTOSO% == 1 (

    REM Contoso public key certs
    if %CF_LocalMachine_TrustedPeople% == 1 (
        echo.
        echo Deleting Contoso public key certificate...
        echo Deleting LocalMachine TrustedPeople %CONTOSO%...
        certmgr.exe -del -r LocalMachine -s TrustedPeople -c -n %CONTOSO% 
    )

)

REM echo Check for Fabrikam, Contoso, and INFOCARD private key certificates.

if %FC_LocalMachine_My% == 1 (
    echo.
    echo Deleting LocalMachine My %FABRIKAM% ...
    certmgr.exe -del -r LocalMachine -s My -c -n %FABRIKAM% 
)

if %INSTALL_CONTOSO% == 1 (

    if %CF_LocalMachine_My% == 1 (
        echo.
        echo Deleting LocalMachine My %CONTOSO% ...
        certmgr.exe -del -r LocalMachine -s My -c -n %CONTOSO% 
    )
)

if %INFOCARD_LocalMachine_My% == 1 (
    echo.
    echo Deleting LocalMachine My %INFOCARD% ...
    certmgr.exe -del -r LocalMachine -s My -c -n %INFOCARD% 
)

echo.
echo Deleting logo files from %VDIR_LOCATION%...
echo.
del %VDIR_LOCATION%\%CONTOSO%.gif
del %VDIR_LOCATION%\%FABRIKAM%.gif
echo.
echo Certificate clean up completed.

endlocal

