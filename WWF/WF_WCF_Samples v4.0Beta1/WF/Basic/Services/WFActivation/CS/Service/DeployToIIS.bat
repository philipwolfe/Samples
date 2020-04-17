@echo off
iisreset /stop
mkdir %SystemDrive%\inetpub\wwwroot\WFActivation\bin
VER | FINDSTR /c:" 6.0." >NUL
IF NOT ERRORLEVEL 1 (
    IF EXIST %windir%\system32\inetsrv\appcmd.exe (
        %windir%\system32\inetsrv\appcmd.exe add app /site.name:"Default Web Site" /path:/WFActivation /physicalPath:%systemdrive%\inetpub\wwwroot\WFActivation
    ) ELSE (
        Echo "Could not find %windir%\system32\inetsrv\appcmd.exe.  Please ensure IIS is installed.  See 'Internet Information Service (IIS) Hosting Instructions' in the WCF samples Setup Instructions."
    )
) ELSE (
    IF EXIST %SystemDrive%\inetpub\adminscripts\adsutil.vbs (
        cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs CREATE w3svc/1/root/WFActivation "IIsWebVirtualDir"
        cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs SET w3svc/1/root/WFActivation/Path %SystemDrive%\inetpub\wwwroot\WFActivation
        cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs SET w3svc/1/root/WFActivation/AppRoot "w3svc/1/Root/WFActivation"
        cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs APPCREATEPOOLPROC w3svc/1/root/WFActivation
    ) ELSE (
        Echo "Could not find %SystemDrive%\inetpub\adminscripts\adsutil.vbs.  Please ensure IIS is installed.  See 'Internet Information Service (IIS) Hosting Instructions' in the WCF samples Setup Instructions."
    )
    
)
iisreset /start
copy bin\service.dll /y %SystemDrive%\inetpub\wwwroot\WFActivation\bin\
copy Web.config /y %SystemDrive%\inetpub\wwwroot\WFActivation\
copy service.xamlx /y %SystemDrive%\inetpub\wwwroot\WFActivation\

