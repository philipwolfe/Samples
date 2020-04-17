@echo off
setlocal

makecert.exe -a sha1 -n CN=BookStoreService.com -sr LocalMachine -ss TrustedPeople -sky exchange -sk BookStoreService
makecert.exe -a sha1 -n CN=BookStoreSTS.com -sr LocalMachine -ss TrustedPeople -sky exchange -sk BookStoreSTS
makecert.exe -a sha1 -n CN=HomeRealmSTS.com -sr LocalMachine -ss TrustedPeople -sky exchange -sk HomeRealmSTS
"%MSSDK%\bin\CertKeyFileTool.exe" -l localmachine -s TrustedPeople -n BookStoreService.com +r
"%MSSDK%\bin\CertKeyFileTool.exe" -l localmachine -s TrustedPeople -n BookStoreSTS.com +r
"%MSSDK%\bin\CertKeyFileTool.exe" -l localmachine -s TrustedPeople -n HomeRealmSTS.com +r

iisreset