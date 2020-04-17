@echo off
iisreset /stop
mkdir %SystemDrive%\inetpub\wwwroot\ServiceModelSamples\bin
cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs CREATE w3svc/1/root/ServiceModelSamples "IIsWebVirtualDir"
cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs SET w3svc/1/root/ServiceModelSamples/Path %SystemDrive%\inetpub\wwwroot\ServiceModelSamples
cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs SET w3svc/1/root/ServiceModelSamples/AppRoot "w3svc/1/Root/ServiceModelSamples"
cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs APPCREATEPOOLPROC w3svc/1/root/ServiceModelSamples
iisreset /start

