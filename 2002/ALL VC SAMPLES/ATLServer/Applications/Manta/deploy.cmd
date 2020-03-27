@echo off

set WEB_DIR=c:\inetpub\wwwroot\MantaWeb
if "%1"=="" goto Start
if "%1"=="release" goto Start
set WEB_DIR=%1

:Start

mkdir "%WEB_DIR%"
mkdir "%WEB_DIR%\images"
mkdir "%WEB_DIR%\cgi-bin"

del /Q "%WEB_DIR%\cgi-bin\*.pdb"
del /Q "%WEB_DIR%\cgi-bin\*.dll"

if "%1"=="release" goto Release
if "%2"=="release" goto Release

ECHO ------------------------------------------------
ECHO Copying DEBUG outputs...
ECHO ------------------------------------------------

copy /Y ".\Calendar\Debug\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\Calendar\Debug\*.pdb" "%WEB_DIR%\cgi-bin"

copy /Y ".\FileStore\Debug\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\FileStore\Debug\*.pdb" "%WEB_DIR%\cgi-bin"

copy /Y ".\Login\Debug\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\Login\Debug\*.pdb" "%WEB_DIR%\cgi-bin"

copy /Y ".\Mailbox\Debug\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\Mailbox\Debug\*.pdb" "%WEB_DIR%\cgi-bin"

copy /Y ".\Main\Debug\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\Main\Debug\*.pdb" "%WEB_DIR%\cgi-bin"

copy /Y ".\MantaWeb\Debug\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\MantaWeb\Debug\*.pdb" "%WEB_DIR%\cgi-bin"

copy /Y ".\MailService\Debug\*.pdb" "%WEB_DIR%\cgi-bin"
copy /Y ".\MailService\Debug\*.dll" "%WEB_DIR%\cgi-bin"

copy /Y ".\MailClientMFC\Debug\*.exe" "%WEB_DIR%\cgi-bin"

goto Common

:Release

ECHO ------------------------------------------------
ECHO Copying RELEASE outputs...
ECHO ------------------------------------------------


copy /Y ".\Calendar\Release\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\FileStore\Release\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\Login\Release\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\Mailbox\Release\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\Main\Release\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\MantaWeb\Release\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\MailService\Release\*.dll" "%WEB_DIR%\cgi-bin"
copy /Y ".\MailClientMFC\Release\*.exe" "%WEB_DIR%\cgi-bin"

:Common
copy /Y ".\MantaWeb\images\*.*" "%WEB_DIR%\images"

copy /Y ".\Calendar\*.srf" "%WEB_DIR%"
copy /Y ".\Calendar\*.htm" "%WEB_DIR%"
copy /Y ".\Calendar\*.css" "%WEB_DIR%"

copy /Y ".\FileStore\*.srf" "%WEB_DIR%"
copy /Y ".\FileStore\*.htm" "%WEB_DIR%"
copy /Y ".\FileStore\*.css" "%WEB_DIR%"

copy /Y ".\Login\*.srf" "%WEB_DIR%"
copy /Y ".\Login\*.htm" "%WEB_DIR%"
copy /Y ".\Login\*.css" "%WEB_DIR%"

copy /Y ".\Mailbox\*.srf" "%WEB_DIR%"
copy /Y ".\Mailbox\*.htm" "%WEB_DIR%"
copy /Y ".\Mailbox\*.css" "%WEB_DIR%"

copy /Y ".\Main\*.srf" "%WEB_DIR%"
copy /Y ".\Main\*.htm" "%WEB_DIR%"
copy /Y ".\Main\*.css" "%WEB_DIR%"

copy /Y ".\MantaWeb\*.srf" "%WEB_DIR%"
copy /Y ".\MantaWeb\*.htm" "%WEB_DIR%"
copy /Y ".\MantaWeb\*.css" "%WEB_DIR%"

copy /Y ".\MailService\*.disco" "%WEB_DIR%"

if not exist c:\mantaweb.mdb copy .\MantaWeb\mantaweb.mdb c:\mantaweb.mdb

del "%WEB_DIR%\cgi-bin\vc70.pdb"
del "%WEB_DIR%\confirm.htm"
del "%WEB_DIR%\mail_redirect.htm"
del "%WEB_DIR%\thankyou.htm"