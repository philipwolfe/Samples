
SELECT name FROM master.dbo.sysdatabases WHERE has_dbaccess(name) = 1 ORDER BY name;

