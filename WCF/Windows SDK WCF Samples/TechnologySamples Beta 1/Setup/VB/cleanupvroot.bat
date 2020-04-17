@echo off
iisreset /stop
cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs DELETE w3svc/1/root/ServiceModelSamples
rd /s /q %SystemDrive%\inetpub\wwwroot\ServiceModelSamples
iisreset /start
