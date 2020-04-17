echo off
set SERVER_NAME=identity.com

echo ************
echo cleaning up the certificates from previous run
echo ************
certmgr.exe -del -r CurrentUser -s TrustedPeople -c -n %SERVER_NAME%
certmgr.exe -del -r LocalMachine -s My -c -n %SERVER_NAME%

 
echo ************
echo Server cert setup starting
echo %SERVER_NAME%
echo ************
echo making server cert
echo ************
REM Create a Cert for this sample
makecert.exe -sr LocalMachine -ss MY -a sha1 -n "CN=%SERVER_NAME%, O=Contoso" -sky exchange -pe
echo ************
echo copying server cert to client's CurrentUser store
echo ************
certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople


echo ************
echo setting privileges on server certificates
echo ************

echo on
set FILENAME = FindPrivateKey.exe" My LocalMachine "CN=%SERVER_NAME%, O=Contoso" -a do set PRIVATE_KEY_FILE=%%i
echo %FILENAME%
REM for /F "delims=" %%i in ('"%MSSDK%\bin\FindPrivateKey.exe" My LocalMachine -n %FILENAME% -a') do set PRIVATE_KEY_FILE=%%i
for /F "delims=" %%i in (%FILENAME%) do set PRIVATE_KEY_FILE=%%i
set WP_ACCOUNT=NT AUTHORITY\NETWORK SERVICE
(ver | findstr "5.1") && set WP_ACCOUNT=%COMPUTERNAME%\ASPNET
echo Y|cacls.exe "%PRIVATE_KEY_FILE%" /E /G "%WP_ACCOUNT%":R
iisreset
