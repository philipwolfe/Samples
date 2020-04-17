@echo off

echo Creating Sample Database ...
Osql -S localhost\SQLExpress -E  -n -i "DatabaseCreation.sql"

echo Creating Persistence Schema ...
Osql -S localhost\SQLExpress -E  -n -i "SqlPersistenceProviderSchema40.sql"

echo Creating Persistence Logic ...
Osql -S localhost\SQLExpress -E  -n -i "SqlPersistenceProviderLogic40.sql"

echo Creating DurableTimer Schema ...
Osql -S localhost\SQLExpress -E  -n -i "DurableTimer_Schema.sql"

echo Creating DurableTimer Logic ...
Osql -S localhost\SQLExpress -E  -n -i "DurableTimer_Logic.sql"

Pause