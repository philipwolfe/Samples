@echo off
iisreset /stop
mkdir %SystemDrive%\inetpub\wwwroot\NetFx35Samples\bin
VER | FINDSTR /c:" 6.0." >NUL
IF NOT ERRORLEVEL 1 (
    IF EXIST %windir%\system32\inetsrv\appcmd.exe (
        %windir%\system32\inetsrv\appcmd.exe add app /site.name:"Default Web Site" /path:/NetFx35Samples /physicalPath:%systemdrive%\inetpub\wwwroot\NetFx35Samples
    ) ELSE (
        Echo "Could not find %windir%\system32\inetsrv\appcmd.exe.  Please ensure IIS is installed.  See 'Internet Information Service (IIS) Hosting Instructions' in the WCF samples Setup Instructions."
    )
) ELSE (
    IF EXIST %SystemDrive%\inetpub\adminscripts\adsutil.vbs (
        cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs CREATE w3svc/1/root/NetFx35Samples "IIsWebVirtualDir"
        cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs SET w3svc/1/root/NetFx35Samples/Path %SystemDrive%\inetpub\wwwroot\NetFx35Samples
        cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs SET w3svc/1/root/NetFx35Samples/AppRoot "w3svc/1/Root/NetFx35Samples"
        cscript.exe %SystemDrive%\inetpub\adminscripts\adsutil.vbs APPCREATEPOOLPROC w3svc/1/root/NetFx35Samples
    ) ELSE (
        Echo "Could not find %SystemDrive%\inetpub\adminscripts\adsutil.vbs.  Please ensure IIS is installed.  See 'Internet Information Service (IIS) Hosting Instructions' in the WCF samples Setup Instructions."
    )
    
)
iisreset /start

