echo off
echo ************
echo Client cert setup starting
echo ************
set CLIENT_NAME=Alice
set SERVER_NAME=localhost

echo ****************
echo Cleanup starting
echo ****************

echo -------------------------
echo del client certs
echo -------------------------
certmgr.exe -del -r CurrentUser -s My -c -n %CLIENT_NAME%
certmgr.exe -del -r CurrentUser -s TrustedPeople -c -n %SERVER_NAME%

echo -------------------------
echo del service certs
echo -------------------------
certmgr.exe -del -r LocalMachine -s My -c -n %SERVER_NAME%
certmgr.exe -del -r LocalMachine -s TrustedPeople -c -n %CLIENT_NAME%

echo *****************
echo Cleanup completed
echo *****************

 
echo ************
echo making client cert
echo ************
makecert.exe -sr CurrentUser -ss MY -a sha1 -n CN=%CLIENT_NAME% -sky exchange -pe
echo ************
echo copying client cert to server's CurrentUserstore
echo ************
certmgr.exe -add -r CurrentUser -s My -c -n %CLIENT_NAME% -r LocalMachine -s TrustedPeople


echo ************
echo Server cert setup starting
echo %SERVER_NAME%
echo ************
echo making server cert
echo ************
makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe
echo ************
echo copying server cert to client's CurrentUser store
echo ************
certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople


echo ************
echo setting privileges on server certificates
echo ************
%MSSDK%\bin\CertKeyFileTool.exe -l localMachine -s My -n %SERVER_NAME% +r

iisreset