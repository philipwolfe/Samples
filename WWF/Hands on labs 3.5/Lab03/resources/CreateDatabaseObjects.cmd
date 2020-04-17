@echo off
echo Creating Tracking database...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -i "Create_TrackingStore.Sql" 

echo Creating Tracking tables...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d TrackingStore -i "C:\WF\WF 3.5 Labs\Lab03\resources\Tracking_Schema.sql" 

echo creating Tracking stored procedures...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d TrackingStore -i "C:\WF\WF 3.5 Labs\Lab03\resources\Tracking_Logic.sql" 

echo Creating persistence tables...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d TrackingStore -i "C:\WF\WF 3.5 Labs\Lab03\resources\SqlPersistenceService_Schema.sql" 

echo creating persistence stored procedures...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d TrackingStore -i "C:\WF\WF 3.5 Labs\Lab03\resources\SqlPersistenceService_Logic.sql" 

Pause