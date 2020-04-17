@echo off

echo Creating Persistence database...
Osql -S localhost\SQLExpress -E  -n -i "Create_WorkflowPersistence.Sql" 

echo Creating persistence tables...
Osql -S localhost\SQLExpress -E  -n -d WorkflowPersistence -i "C:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Schema.sql" 

echo creating persistence stored procedures...
Osql -S localhost\SQLExpress -E  -n -d WorkflowPersistence -i "C:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\SqlPersistenceService_Logic.sql" 


Pause