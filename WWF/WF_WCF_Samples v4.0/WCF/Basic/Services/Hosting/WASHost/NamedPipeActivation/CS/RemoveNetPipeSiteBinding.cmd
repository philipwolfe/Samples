%windir%\system32\inetsrv\appcmd.exe set app "Default Web Site/servicemodelsamples" /enabledProtocols:http
%windir%\system32\inetsrv\appcmd.exe delete app /app.name:"Default Web Site/servicemodelsamples"
%windir%\system32\inetsrv\appcmd.exe set site "Default Web Site" --bindings.[protocol='net.pipe',bindingInformation='*']