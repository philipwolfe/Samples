@echo off
setlocal

certmgr.exe -del -c -n BookStoreService.com -r localmachine -s trustedpeople
certmgr.exe -del -c -n BookStoreSTS.com -r localmachine -s trustedpeople
certmgr.exe -del -c -n HomeRealmSTS.com -r localmachine -s trustedpeople
