@echo off
echo Creating tracking database...
Osql -S %COMPUTERNAME% -E  -n -i "Create_TrackingStore.Sql" 

echo Creating tracking tables...
Osql -S %COMPUTERNAME% -E  -n -d TrackingStore -i "%windir%\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\Tracking_Schema.sql" 

echo creating tracking stored procedures...
Osql -S %COMPUTERNAME% -E  -n -d TrackingStore -i "%windir%\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\Tracking_Logic.sql" 

echo Creating persistence database...
Osql -S %COMPUTERNAME% -E  -n -i "Create_PersistenceStore.sql" 

echo Creating persistence tables...
Osql -S %COMPUTERNAME% -E  -n -d PersistenceStore -i "%windir%\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Schema.sql" 

echo creating persistence stored procedures...
Osql -S %COMPUTERNAME% -E  -n -d PersistenceStore -i "%windir%\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Logic.sql"

Pause