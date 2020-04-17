-- Copyright (c) Microsoft Corporation.  All rights reserved.
Use Master
Go
IF EXISTS (SELECT * 
	   FROM   master..sysdatabases 
	   WHERE  name = N'SharedStore')
	DROP DATABASE SharedStore
GO
CREATE DATABASE SharedStore
GO

