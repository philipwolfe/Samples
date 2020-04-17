-- Copyright (c) Microsoft Corporation.  All rights reserved.
Use Master
Go
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'PersistenceStore')
	DROP DATABASE PersistenceStore
GO
CREATE DATABASE PersistenceStore
GO

