osql /S %COMPUTERNAME%\SQLEXPRESS /E /i CreateStatePersistenceDB.sql
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d WorkflowStore -i "C:\WINNT\WinFX\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Schema.sql"
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d WorkflowStore -i "C:\WINNT\WinFX\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Logic.sql"
pause