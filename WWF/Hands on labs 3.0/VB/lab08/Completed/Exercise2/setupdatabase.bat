osql /S %COMPUTERNAME%\SQLEXPRESS /E /i BankScripts.sql

osql /S %COMPUTERNAME%\SQLEXPRESS /E /i dumptables.sql
pause