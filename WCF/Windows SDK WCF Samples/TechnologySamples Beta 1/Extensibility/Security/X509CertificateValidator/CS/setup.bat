echo off
set SERVER_NAME=localhost
set USER_NAME=test1

echo ---------------------------------------------------------------------
echo cleaning up the certificates from previous run
certmgr.exe -del -r CurrentUser -s TrustedPeople -c -n %SERVER_NAME%
certmgr.exe -del -r CurrentUser -s My -c -n %SERVER_NAME%
certmgr.exe -del -r CurrentUser -s TrustedPeople -c -n %USER_NAME%
certmgr.exe -del -r CurrentUser -s My -c -n %USER_NAME%


echo ---------------------------------------------------------------------
echo Server cert setup starting
echo for server: %SERVER_NAME%
echo making server cert
makecert.exe -sr CurrentUser -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe
echo copying server cert to client's CurrentUser store
certmgr.exe -add -r CurrentUser -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople
echo ---------------------------------------------------------------------

echo ---------------------------------------------------------------------
echo Client cert setup starting
echo for user: %USER_NAME%
echo making user cert
makecert.exe -sr CurrentUser -ss MY -a sha1 -n CN=%USER_NAME% -sky exchange -pe -r
echo copying user cert to client's CurrentUser store
certmgr.exe -add -r CurrentUser -s My -c -n %USER_NAME% -r CurrentUser -s TrustedPeople
echo ---------------------------------------------------------------------