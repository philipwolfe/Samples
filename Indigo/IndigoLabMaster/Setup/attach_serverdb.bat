@echo off
setlocal

osql -U sa -P pass@word1 -e /Q "use master" /q "exec sp_attach_db @dbname = 'dbLabServer', @filename1 = 'C:\indigolabmaster\Setup\Database\dbLabServer_Data.mdf', @filename2 = 'C:\indigolabmaster\Setup\Database\dbLabServer_Log.ldf'"


pause
echo on