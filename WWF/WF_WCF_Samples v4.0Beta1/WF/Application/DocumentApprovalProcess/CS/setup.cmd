@echo off

echo Creating User Management Database ...
Osql -S localhost\SQLExpress -E  -n -i "users.sql"

echo Creating Persistence Database and Schema ...
Osql -S localhost\SQLExpress -E  -n -i "SqlPersistenceProviderSchema40.sql"

echo Creating Persistence Logic ...
Osql -S localhost\SQLExpress -E  -n -i "SqlPersistenceProviderLogic40.sql"

Pause