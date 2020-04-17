@echo off

echo Creating Tracking database...
Osql -S localhost\SQLExpress -E  -n -i "Create_WorkflowTracking.Sql" 

echo Creating Tracking tables...
Osql -S localhost\SQLExpress -E  -n -d WorkflowTracking -i "C:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\Tracking_Schema.sql" 

echo creating Tracking stored procedures...
Osql -S localhost\SQLExpress -E  -n -d WorkflowTracking -i "C:\WINDOWS\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN\Tracking_Logic.sql" 


Pause