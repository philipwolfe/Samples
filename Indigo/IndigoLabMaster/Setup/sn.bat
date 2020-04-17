@echo on
setlocal

cd Trace
copy Microsoft.MessageBus.Test.Utilities.dll "C:\Program Files\Microsoft Visual Studio .NET Whidbey\SDK\v1.2\Bin\"
cd C:\Program Files\Microsoft Visual Studio .NET Whidbey\SDK\v1.2\Bin
sn -Vr Microsoft.MessageBus.Test.Utilities.dll

pause
