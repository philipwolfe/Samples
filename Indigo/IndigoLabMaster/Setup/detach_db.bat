@echo off
setlocal

osql -U sa -P pass@word1 -e /Q "use master" /q "exec sp_detach_db  'dbLabServer', true"

pause
echo on