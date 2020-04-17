@echo off
setlocal

set SERVER_NAME=localhost

echo ****************
echo Cleanup starting
echo ****************

echo -------------------------
echo del service certs
echo -------------------------
certmgr.exe -del -r LocalMachine -s My -c -n %SERVER_NAME%
certmgr.exe -del -r CurrentUser -s TrustedPeople -c -n %SERVER_NAME%

echo *****************
echo Cleanup completed
echo *****************

 
echo ************
echo Server cert setup starting
echo %SERVER_NAME%
echo ************
echo making server cert
echo ************
makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe
echo ************
echo copying server cert to client's TrustedPeople store
echo ************
certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople


echo ************
echo setting privileges on server certificates
echo ************
%MSSDK%\bin\CertKeyFileTool.exe -l localMachine -s My -n %SERVER_NAME% +r

iisreset