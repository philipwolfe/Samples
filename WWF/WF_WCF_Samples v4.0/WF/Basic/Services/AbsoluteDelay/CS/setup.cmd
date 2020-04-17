@echo off

echo ------------------------------------------------------------------
echo   Preparing your system for the Absolute Delay Sample
echo ------------------------------------------------------------------
echo.

If "%frameworkdir%"=="" goto missingvars
If "%FrameworkVersion%%"=="" goto missingvars

echo Creating Sample Database ...
sqlcmd -S localhost\SQLExpress -E -i "DatabaseCreation.sql" -o setup-sqlcmd.log
If ERRORLEVEL 1 goto sqlerror

echo Creating Persistence Schema ...
sqlcmd -S localhost\SQLExpress -E -d AbsoluteDelaySampleDB -i "%frameworkdir%%FrameworkVersion%\sql\en\SqlWorkflowInstanceStoreSchema.sql" -o setup-sqlcmd.log
If ERRORLEVEL 1 goto sqlerror

echo Creating Persistence Logic ...
sqlcmd -S localhost\SQLExpress -E -d AbsoluteDelaySampleDB -i "%frameworkdir%%FrameworkVersion%\sql\en\SqlWorkflowInstanceStoreLogic.sql" -o setup-sqlcmd.log
If ERRORLEVEL 1 goto sqlerror

del setup-sqlcmd.log

echo.
echo --------------------------------
echo   Setup completed successfully
echo --------------------------------
goto :eof

:missingvars
echo -----------------------
echo   Error Running Setup
echo -----------------------
echo Environment variables needed to located the built-in instance store sql setup
echo scripts were not found. This may be the result of not executing this script in
echo a Visual Studio command prompt.
echo.
echo Try executing this script in a Visual Studio command prompt if you have not 
echo already.
goto :eof

:sqlerror
echo -----------------------
echo   Error Running Setup
echo -----------------------
echo A sqlcmd command in the setup script failed to execute.  This is most likely
echo because your current user account does not have the required access to the
echo sample database or because the server name used in the script 
echo ('localhost\SQLExpress') does not match your SQL server name.  See 
echo setup-sqlcmd.log for the output from the failed sqlcmd command.
goto :eof
