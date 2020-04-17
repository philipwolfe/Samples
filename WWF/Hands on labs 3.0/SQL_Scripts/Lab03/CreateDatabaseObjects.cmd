@echo off
echo Creating Tracking database...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -i "Create_TrackingStore.Sql" 

echo Creating Tracking tables...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d TrackingStore -i "C:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\Tracking_Schema.sql" 

echo creating Tracking stored procedures...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d TrackingStore -i "C:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\Tracking_Logic.sql" 

echo Creating persistence tables...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d TrackingStore -i "C:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Schema.sql" 

echo creating persistence stored procedures...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d TrackingStore -i "C:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Logic.sql" 

Pause