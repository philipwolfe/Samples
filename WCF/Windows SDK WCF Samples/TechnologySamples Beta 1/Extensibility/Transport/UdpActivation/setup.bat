set ISVISTA=0
ver | findstr /c:" 6." && set ISVISTA=1
if not exist %SystemDrive%\inetpub\wwwroot\servicemodelsamples\bin mkdir %SystemDrive%\inetpub\wwwroot\servicemodelsamples\bin
if "%ISVISTA%" == "1" %windir%\system32\inetsrv\AppCmd.exe set site "Default Web Site" /+bindings.[protocol='net.udp.v1',bindingInformation='8080']
if "%ISVISTA%" == "1" %windir%\system32\inetsrv\AppCmd.exe set app /app.name:"Default Web Site/servicemodelsamples" /enabledProtocols:http,net.udp.v1
