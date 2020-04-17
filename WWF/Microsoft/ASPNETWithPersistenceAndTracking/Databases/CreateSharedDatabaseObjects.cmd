@echo off
echo Creating shared database...
Osql -S %COMPUTERNAME% -E  -n -i "Create_SharedStore.Sql" 

echo Creating tracking tables...
Osql -S %COMPUTERNAME% -E  -n -d SharedStore -i "%windir%\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\Tracking_Schema.sql" 

echo creating tracking stored procedures...
Osql -S %COMPUTERNAME% -E  -n -d SharedStore -i "%windir%\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\Tracking_Logic.sql" 

echo Creating persistence tables...
Osql -S %COMPUTERNAME% -E  -n -d SharedStore -i "%windir%\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Schema.sql" 

echo creating persistence stored procedures...
Osql -S %COMPUTERNAME% -E  -n -d SharedStore -i "%windir%\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Logic.sql" 

Pause