@echo off

echo Removing Sample Database ...
Osql -S localhost\SQLExpress -E  -n -i "cleanup.sql"

Pause