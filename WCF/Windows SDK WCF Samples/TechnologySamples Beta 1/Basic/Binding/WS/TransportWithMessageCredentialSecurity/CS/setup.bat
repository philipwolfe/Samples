@echo off
REM -------- Make sure makecert.exe is in your path --------
makecert.exe -sr LocalMachine -ss My -n CN=ServiceModelSamples-HTTPS-Server -sky exchange -sk ServiceModelSamples-HTTPS-Key
