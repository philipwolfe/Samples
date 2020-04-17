@echo off
echo Creating loan approval process database...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -i "Create_LoanApprovalProcess.Sql" 

echo Creating tables...
Osql -S %COMPUTERNAME%\SQLExpress -E  -n -d LoanApprovalProcess -i "Create_Tables.sql" 

Pause