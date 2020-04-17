@echo off
echo Creating loan approval process database...
Osql -S %COMPUTERNAME% -E  -n -i "Create_LoanApprovalProcess.Sql" 

echo Creating tables...
Osql -S %COMPUTERNAME% -E  -n -d LoanApprovalProcess -i "Create_Tables.sql" 

Pause