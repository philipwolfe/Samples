echo off
set SERVER_NAME=localhost
set USER_NAME=Alice
echo ---------------------------------------------------------------------
echo cleaning up the certificates from previous run
certmgr -del -r CurrentUser -s TrustedPeople -c -n %SERVER_NAME%
certmgr -del -r CurrentUser -s TrustedPeople -c -n %USER_NAME%

echo ---------------------------------------------------------------------
echo Server cert setup starting
echo for server: %SERVER_NAME%
echo making server cert
makecert.exe -sr CurrentUser -ss TrustedPeople -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe
echo ---------------------------------------------------------------------
echo ---------------------------------------------------------------------
echo Server cert setup starting
echo for client: %USER_NAME%
echo making server cert
makecert.exe -sr CurrentUser -ss TrustedPeople -a sha1 -n CN=%USER_NAME% -sky exchange -pe
echo ---------------------------------------------------------------------