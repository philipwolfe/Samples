echo off
set SERVER_NAME=localhost
set USER_NAME=Alice
echo ---------------------------------------------------------------------
echo cleaning up the certificates from previous run
certmgr -del -r CurrentUser -s TrustedPeople -c -n %SERVER_NAME%
certmgr -del -r CurrentUser -s TrustedPeople -c -n %USER_NAME%
echo cleanup completed
echo ---------------------------------------------------------------------

